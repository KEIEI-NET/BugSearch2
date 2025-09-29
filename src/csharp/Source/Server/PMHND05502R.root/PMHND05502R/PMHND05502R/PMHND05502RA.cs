//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル棚卸リモートオブジェクト
// プログラム概要   : ハンディターミナル棚卸検索、登録処理を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/16  修正内容 : 新規作成
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
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ハンディターミナル棚卸リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル棚卸リモートオブジェクトです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/08/16</br>
    /// </remarks>
    [Serializable]
    public class HandyInventoryDataDB : RemoteDB, IHandyInventoryDataDB
    {
        #region [コンストラクタ]
        /// <summary>
        /// ハンディターミナル棚卸リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public HandyInventoryDataDB()
        {
        }
        #endregion

        #region [Public Methods]
        #region [棚卸処理（一斉）]
        /// <summary>
        /// 棚卸処理(一斉)_棚卸対象確認
        /// </summary>
        /// <param name="condObj">検索条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸対象が存在しているかの確認を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int SearchCount(object condObj)
        {
            SqlConnection sqlConnection = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    HandyInventoryCondWork handyWork = (HandyInventoryCondWork)condObj;
                    // 検索条件がnullの場合、
                    if (handyWork == null)
                    {
                        base.WriteErrorLog("HandyInventoryDataDB.SearchCount" + "カスタムシリアライザ失敗");
                        return status;
                    }
                    // 棚卸対象が存在しているかの確認
                    status = SearchProc(handyWork, ref sqlConnection);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInventoryDataDB.SearchCount Exception=" + ex.Message, status);
                }
            }
            return status;
        }

        /// <summary>
        /// 棚卸処理(一斉)_棚卸対象取得
        /// </summary>
        /// <param name="condObj">検索条件</param>
        /// <param name="refObj">検索结果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸対象を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int Search(object condObj, out object refObj)
        {
            SqlConnection sqlConnection = null;
            refObj = null;
            HandyInventoryDataWork handyDataWork = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    HandyInventoryCondWork handyWork = (HandyInventoryCondWork)condObj;
                    // 検索条件がnullの場合、
                    if (handyWork == null)
                    {
                        base.WriteErrorLog("HandyInventoryDataDB.Search" + "カスタムシリアライザ失敗");
                        return status;
                    }
                    // 棚卸対象取得
                    status = SearchDataProc(handyWork, ref handyDataWork, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        refObj = (object)handyDataWork;
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInventoryDataDB.Search Exception=" + ex.Message, status);
                }
            }
            return status;
        }

        // --- ADD 2019/11/13 ---------->>>>>
        /// <summary>
        /// 棚卸処理(一斉)_棚卸対象取得
        /// </summary>
        /// <param name="condObj">検索条件</param>
        /// <param name="refObj">検索结果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸対象を取得します。</br>
        /// <br>Programmer : 岸</br>
        /// <br>Date       : 2019/11/13</br>
        /// </remarks>
        public int SearchHandy(object condObj, out object refObj)
        {
            SqlConnection sqlConnection = null;
            refObj = null;
            ArrayList handyDataWork = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    HandyInventoryCondWork handyWork = (HandyInventoryCondWork)condObj;
                    // 検索条件がnullの場合、
                    if (handyWork == null)
                    {
                        base.WriteErrorLog("HandyInventoryDataDB.SearchHandy" + "カスタムシリアライザ失敗");
                        return status;
                    }
                    // 棚卸対象取得
                    status = SearchHandyDataProc(handyWork, ref handyDataWork, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        refObj = (object)handyDataWork;
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInventoryDataDB.SearchHandy Exception=" + ex.Message, status);
                }
            }
            return status;
        }
        // --- ADD 2019/11/13 ----------<<<<<

        /// <summary>
        /// 棚卸処理(一斉)_棚卸データ登録
        /// </summary>
        /// <param name="condObj">棚卸処理（一斉）登録データオブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸データの更新を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int Write(object condObj)
        {
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    HandyInventoryCondWork handyWork = (HandyInventoryCondWork)condObj;
                    // 検索条件がnullの場合、
                    if (handyWork == null)
                    {
                        base.WriteErrorLog("HandyInventoryDataDB.Write" + "カスタムシリアライザ失敗");
                        return status;
                    }
                    // トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                    // 棚卸データ登録
                    status = WriteProc(handyWork, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // コミット
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInventoryDataDB.Write Exception=" + ex.Message, status);
                }
            }
            return status;
        }
        #endregion

        #region [棚卸処理(循環)]
        /// <summary>
        /// 棚卸処理(循環)_倉庫存在確認処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定倉庫に在庫情報が存在しているかの確認を行います</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int SearchStockCount(byte[] condByte)
        {
            SqlConnection sqlConnection = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    HandyInventoryCondWork condWork = (HandyInventoryCondWork)XmlByteSerializer.Deserialize(condByte, typeof(HandyInventoryCondWork));
                    // 検索条件がnullの場合、
                    if (condWork == null)
                    {
                        base.WriteErrorLog("HandyInventoryDataDB.SearchStockCount" + "カスタムシリアライザ失敗");
                        return status;
                    }
                    status = SearchCountProc(condWork, ref sqlConnection);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInventoryDataDB.SearchStockCount Exception=" + ex.Message, status);
                }
            }
            return status;
        }

        /// <summary>
        /// 棚卸処理（循環)_在庫情報取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫情報を検索します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int SearchStock(byte[] condByte, out object retObj)
        {
            retObj = null;
            SqlConnection sqlConnection = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    HandyStockCondWork condWork = (HandyStockCondWork)XmlByteSerializer.Deserialize(condByte, typeof(HandyStockCondWork));
                    // 検索条件がnullの場合、
                    if (condWork == null)
                    {
                        base.WriteErrorLog("HandyInventoryDataDB.SearchStock" + "カスタムシリアライザ失敗");
                        return status;
                    }
                    HandyStockWork handyStockWork = null;
                    HandyStockDB handyStockDB = new HandyStockDB();
                    status = handyStockDB.SearchProc(condWork, out handyStockWork, ref sqlConnection);
                    // 検索結果ステータスが正常の場合、
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retObj = handyStockWork as object;
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInventoryDataDB.SearchStock Exception=" + ex.Message, status);
                }
            }
            return status;
        }

        // --- ADD 2019/11/13 ---------->>>>>
        /// <summary>
        /// 棚卸処理（循環)_在庫情報取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫情報を検索します。</br>
        /// <br>Programmer : 岸</br>
        /// <br>Date       : 2019/11/13</br>
        /// </remarks>
        public int SearchStockHandy(byte[] condByte, out object retObj)
        {
            retObj = null;
            SqlConnection sqlConnection = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    HandyStockCondWork condWork = (HandyStockCondWork)XmlByteSerializer.Deserialize(condByte, typeof(HandyStockCondWork));
                    // 検索条件がnullの場合、
                    if (condWork == null)
                    {
                        base.WriteErrorLog("HandyInventoryDataDB.SearchStockHandy" + "カスタムシリアライザ失敗");
                        return status;
                    }
                    ArrayList handyStockWork = null;
                    HandyStockDB handyStockDB = new HandyStockDB();
                    status = handyStockDB.SearchHandyProc(condWork, out handyStockWork, ref sqlConnection);
                    // 検索結果ステータスが正常の場合、
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retObj = handyStockWork as object;
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInventoryDataDB.SearchStockHandy Exception=" + ex.Message, status);
                }
            }
            return status;
        }
        // --- ADD 2019/11/13 ----------<<<<<


        /// <summary>
        /// 棚卸処理（循環)_棚卸情報登録
        /// </summary>
        /// <param name="inventDataObj">棚卸処理（循環）登録データオブジェクト</param>
        /// <param name="inventorySeqNo">循環棚卸通番</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 棚卸情報を登録します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int WriteCirculInvent(object inventDataObj, out int inventorySeqNo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            string retMsg = string.Empty;
            inventorySeqNo = 0;
            bool stockAdjustFlg = false;
            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    //パラメータのキャスト
                    CustomSerializeArrayList paraList = inventDataObj as CustomSerializeArrayList;
                    if (paraList == null || paraList.Count == 0)
                    {
                        base.WriteErrorLog("HandyInventoryDataDB.WriteCirculInvent" + "カスタムシリアライザ失敗");
                        return status;
                    }
                    // トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    // 循環棚卸データ登録
                    status = this.WriteCirculProc(paraList, out inventorySeqNo, ref sqlConnection, ref sqlTransaction);

                    // 循環棚卸データ登録失敗場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 在庫調整データ情報登録判断
                    foreach (CustomSerializeArrayList stockAdjustCsList in paraList)
                    {
                        //リストから必要な情報を取得
                        for (int i = 0; i < stockAdjustCsList.Count; i++)
                        {
                            ArrayList wkal = stockAdjustCsList[i] as ArrayList;
                            if (wkal != null)
                            {
                                if (wkal.Count > 0)
                                {
                                    //在庫調整データの場合
                                    if (wkal[0] is StockAdjustWork)
                                    {
                                        stockAdjustFlg = true;
                                        break;

                                    }
                                    //在庫調整明細データの場合
                                    if (wkal[0] is StockAdjustDtlWork)
                                    {
                                        stockAdjustFlg = true;
                                        break;
                                    }
                                    //在庫の場合
                                    if (wkal[0] is StockWork)
                                    {
                                        stockAdjustFlg = true;
                                        break;
                                    }
                                }
                            }
                            if (stockAdjustFlg) break;
                        }
                    }
                    if (stockAdjustFlg && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        StockAdjustDB stockAdjustDB = new StockAdjustDB();
                        //在庫調整リモート呼出し、在庫調整・在庫調整明細・在庫情報の登録を行います。
                        status = stockAdjustDB.WriteBatch(ref inventDataObj, out retMsg, ref sqlConnection, ref sqlTransaction);
                    }

                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInventoryDataDB.WriteCirculInvent Exception=" + ex.Message, status);
                }
                finally
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // コミット
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }

                    if (sqlTransaction != null) sqlTransaction.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [循環棚卸照会]
        /// <summary>
        /// 循環棚卸照会データ抽出処理
        /// </summary>
        /// <param name="condObj">検索条件</param>
        /// <param name="refObj">循環棚卸照会データ情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 循環棚卸照会データ抽出処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int SearchCirculInventData(object condObj, out object refObj)
        {
            refObj = null;
            SqlConnection sqlConnection = null;
            ArrayList handyDataList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    HandyInventoryCondWork handyWork = (HandyInventoryCondWork)condObj;
                    // 検索条件がnullの場合、
                    if (handyWork == null)
                    {
                        base.WriteErrorLog("HandyInventoryDataDB.SearchCirculInventData" + "カスタムシリアライザ失敗");
                        return status;
                    }
                    // 循環棚卸照会データ取得
                    status = SearchCirculInventProc(handyWork, ref handyDataList, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        refObj = (object)handyDataList;
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInventoryDataDB.SearchCirculInventData Exception=" + ex.Message, status);
                }
            }
            return status;
        }

        #endregion
        #endregion

        #region [Private Methods]
        #region [棚卸処理（一斉）]
        /// <summary>
        /// 棚卸対象が存在しているかの確認
        /// </summary>
        /// <param name="handywork">検索条件</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸対象が存在しているかの確認を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private int SearchProc(HandyInventoryCondWork handywork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();
                    #region [Select文作成]
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine(" COUNT(*) ");
                    sqlText.AppendLine(" INVENTORY_COUNT ");
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" INVENTORYDATARF ");
                    sqlText.AppendLine(" WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" WHERE ");
                    sqlText.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    sqlText.AppendLine(" AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
                    sqlText.AppendLine(" AND WAREHOUSECODERF= @FINDWAREHOUSECODE ");
                    sqlText.AppendLine(" AND INVENTORYDATERF= @FINDINVENTORYDATE ");
                    #endregion
                    sqlCommand.CommandText = sqlText.ToString();

                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    SqlParameter findInventoryDate = sqlCommand.Parameters.Add("@FINDINVENTORYDATE", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(handywork.EnterpriseCode);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                    findWarehouseCode.Value = SqlDataMediator.SqlSetString(handywork.WarehouseCode);
                    findInventoryDate.Value = SqlDataMediator.SqlSetInt32(handywork.InventoryDate);

                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    int inventoryCount = 0;
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            inventoryCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORY_COUNT"));
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                    if (inventoryCount == 0)
                    {
                        // 検索結果なし場合、「NOT_FOUND」を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
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
                    base.WriteErrorLog(ex, "HandyInventoryDataDB.SearchProc Exception=" + ex.Message, status);
                }
            }
            return status;
        }

        /// <summary>
        /// 棚卸対象取得
        /// </summary>
        /// <param name="handywork">検索条件</param>
        /// <param name="handyDataWork">検索结果</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸対象取得を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private int SearchDataProc(HandyInventoryCondWork handywork, ref HandyInventoryDataWork handyDataWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();
                    #region [Select文作成]
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine(" IV.INVENTORYSEQNORF, ");   // 循環棚卸通番
                    sqlText.AppendLine(" IV.GOODSMAKERCDRF, "); // 商品メーカーコード
                    sqlText.AppendLine(" IV.GOODSNORF, ");  // 商品番号
                    sqlText.AppendLine(" MU.MAKERNAMERF, ");    // メーカー名称
                    sqlText.AppendLine(" IV.STOCKTOTALRF, ");   // 帳簿数
                    sqlText.AppendLine(" IV.INVENTORYSTOCKCNTRF, ");   // 棚卸数
                    sqlText.AppendLine(" IV.WAREHOUSESHELFNORF, "); // 倉庫棚番
                    sqlText.AppendLine(" IV.SECTIONCODERF, "); // 拠点コード
                    sqlText.AppendLine(" IV.GOODSNAMERF "); // 商品名称
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" INVENTORYDATARF IV WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" INNER JOIN ");
                    sqlText.AppendLine(" GOODSBARCODEREVNRF GB WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" ON IV.ENTERPRISECODERF = GB.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND IV.LOGICALDELETECODERF = GB.LOGICALDELETECODERF ");
                    sqlText.AppendLine(" AND IV.GOODSMAKERCDRF = GB.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" AND IV.GOODSNORF = GB.GOODSNORF ");
                    sqlText.AppendLine(" LEFT JOIN MAKERURF MU WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" ON IV.ENTERPRISECODERF=MU.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND  IV.GOODSMAKERCDRF =MU.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" WHERE ");
                    sqlText.AppendLine(" IV.ENTERPRISECODERF = @FINDENTERPRISECODE ");
                    sqlText.AppendLine(" AND IV.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
                    sqlText.AppendLine(" AND IV.WAREHOUSECODERF = @FINDWAREHOUSECODE ");
                    sqlText.AppendLine(" AND IV.GOODSMAKERCDRF<>0 ");
                    sqlText.AppendLine(" AND IV.GOODSNORF IS NOT NULL ");
                    sqlText.AppendLine(" AND ( IV.WAREHOUSESHELFNORF IS NULL ");
                    sqlText.AppendLine(" OR (IV.WAREHOUSESHELFNORF IS NOT NULL AND IV.WAREHOUSESHELFNORF<>'ｶｼﾀﾞｼ' ");
                    sqlText.AppendLine(" AND  IV.WAREHOUSESHELFNORF<>'ｻｷﾀﾞｼ' ) )");
                    sqlText.AppendLine(" AND GB.GOODSBARCODERF=@FINDGOODSBARCODERF ");
                    sqlText.AppendLine(" ORDER BY IV.GOODSMAKERCDRF,IV.GOODSNORF");
                    #endregion  // [Select文作成]

                    sqlCommand.CommandText = sqlText.ToString();

                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    SqlParameter findGoodsBarCode = sqlCommand.Parameters.Add("@FINDGOODSBARCODERF", SqlDbType.NVarChar);

                    // Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(handywork.EnterpriseCode);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                    findWarehouseCode.Value = SqlDataMediator.SqlSetString(handywork.WarehouseCode);
                    findGoodsBarCode.Value = SqlDataMediator.SqlSetString(handywork.GoodsBarCode);

                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            handyDataWork = new HandyInventoryDataWork();
                            handyDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                            handyDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                            handyDataWork.CirculInventSeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYSEQNORF"));
                            handyDataWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                            handyDataWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALRF"));
                            handyDataWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYSTOCKCNTRF"));
                            handyDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                            handyDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                            handyDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        if (handyDataWork == null)
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
                    base.WriteErrorLog(ex, "HandyInventoryDataDB.SearchDataProc Exception=" + ex.Message, status);
                }
            }
            return status;
        }

        // --- ADD 2019/11/13 ---------->>>>>
        /// <summary>
        /// 棚卸対象取得
        /// </summary>
        /// <param name="handywork">検索条件</param>
        /// <param name="handyDataArray">検索结果</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸対象取得を行う。</br>
        /// <br>Programmer : 岸</br>
        /// <br>Date       : 2019/11/13</br>
        /// </remarks>
        private int SearchHandyDataProc(HandyInventoryCondWork handywork, ref ArrayList handyDataArray, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();
                    #region [Select文作成]
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine(" IV.INVENTORYSEQNORF, ");   // 循環棚卸通番
                    sqlText.AppendLine(" IV.GOODSMAKERCDRF, "); // 商品メーカーコード
                    sqlText.AppendLine(" IV.GOODSNORF, ");  // 商品番号
                    sqlText.AppendLine(" MU.MAKERNAMERF, ");    // メーカー名称
                    sqlText.AppendLine(" IV.STOCKTOTALRF, ");   // 帳簿数
                    sqlText.AppendLine(" IV.INVENTORYSTOCKCNTRF, ");   // 棚卸数
                    sqlText.AppendLine(" IV.WAREHOUSESHELFNORF, "); // 倉庫棚番
                    sqlText.AppendLine(" IV.SECTIONCODERF, "); // 拠点コード
                    sqlText.AppendLine(" IV.GOODSNAMERF "); // 商品名称
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" INVENTORYDATARF IV WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" LEFT OUTER JOIN ");
                    sqlText.AppendLine(" GOODSBARCODEREVNRF GB WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" ON IV.ENTERPRISECODERF = GB.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND IV.LOGICALDELETECODERF = GB.LOGICALDELETECODERF ");
                    sqlText.AppendLine(" AND IV.GOODSMAKERCDRF = GB.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" AND IV.GOODSNORF = GB.GOODSNORF ");
                    sqlText.AppendLine(" LEFT JOIN MAKERURF MU WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" ON IV.ENTERPRISECODERF=MU.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND  IV.GOODSMAKERCDRF =MU.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" WHERE ");
                    sqlText.AppendLine(" IV.ENTERPRISECODERF = @FINDENTERPRISECODE ");
                    sqlText.AppendLine(" AND IV.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
                    sqlText.AppendLine(" AND IV.WAREHOUSECODERF = @FINDWAREHOUSECODE ");
                    sqlText.AppendLine(" AND IV.GOODSMAKERCDRF<>0 ");
                    sqlText.AppendLine(" AND IV.GOODSNORF IS NOT NULL ");
                    sqlText.AppendLine(" AND ( IV.WAREHOUSESHELFNORF IS NULL ");
                    sqlText.AppendLine(" OR (IV.WAREHOUSESHELFNORF IS NOT NULL AND IV.WAREHOUSESHELFNORF<>'ｶｼﾀﾞｼ' ");
                    sqlText.AppendLine(" AND  IV.WAREHOUSESHELFNORF<>'ｻｷﾀﾞｼ' ) )");
                    if (string.IsNullOrEmpty(handywork.GoodsBarCode))
                    {
                        // 品番検索
                        sqlText.AppendLine(" AND IV.GOODSNORF=@FINDGOODSNORF ");
                    }
                    else
                    {
                        // バーコード検索
                        sqlText.AppendLine(" AND GB.GOODSBARCODERF=@FINDGOODSBARCODERF ");
                    }
                    sqlText.AppendLine(" ORDER BY IV.GOODSMAKERCDRF,IV.GOODSNORF");
                    #endregion  // [Select文作成]

                    sqlCommand.CommandText = sqlText.ToString();

                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    if (string.IsNullOrEmpty(handywork.GoodsBarCode))
                    {
                        SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNORF", SqlDbType.NVarChar);
                        findGoodsNo.Value = SqlDataMediator.SqlSetString(handywork.GoodsNo);
                    }
                    else
                    {
                        SqlParameter findGoodsBarCode = sqlCommand.Parameters.Add("@FINDGOODSBARCODERF", SqlDbType.NVarChar);
                        findGoodsBarCode.Value = SqlDataMediator.SqlSetString(handywork.GoodsBarCode);
                    }

                    // Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(handywork.EnterpriseCode);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                    findWarehouseCode.Value = SqlDataMediator.SqlSetString(handywork.WarehouseCode);

                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        if (handyDataArray == null)
                        {
                            handyDataArray = new ArrayList();
                        }

                        while (myReader.Read())
                        {
                            HandyInventoryDataWork handyDataWork = null;

                            handyDataWork = new HandyInventoryDataWork();
                            handyDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                            handyDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                            handyDataWork.CirculInventSeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYSEQNORF"));
                            handyDataWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                            handyDataWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALRF"));
                            handyDataWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYSTOCKCNTRF"));
                            handyDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                            handyDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                            handyDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));

                            handyDataArray.Add(handyDataWork);

                        }

                        if (handyDataArray == null || handyDataArray.Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                    base.WriteErrorLog(ex, "HandyInventoryDataDB.SearchHandyDataProc Exception=" + ex.Message, status);
                }
            }
            return status;
        }
        // --- ADD 2019/11/13 ----------<<<<<

        /// <summary>
        /// 棚卸データ登録
        /// </summary>
        /// <param name="handyWork">検索条件</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸データの更新を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private int WriteProc(HandyInventoryCondWork handyWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
            {
                try
                {
                    CirculInventHisDataWork dataWork = new CirculInventHisDataWork();

                    StringBuilder sqlText = new StringBuilder();
                    #region
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine(" UPDATEDATETIMERF , ");
                    sqlText.AppendLine(" ADJSTCALCCOSTRF ");
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" INVENTORYDATARF");
                    sqlText.AppendLine(" WHERE ");
                    sqlText.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    sqlText.AppendLine(" AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ");
                    sqlText.AppendLine(" AND SECTIONCODERF=@FINDSECTIONCODE ");
                    sqlText.AppendLine(" AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO ");
                    sqlText.AppendLine(" AND WAREHOUSECODERF=@FINDWAREHOUSECODE");
                    #endregion
                    sqlCommand.CommandText = sqlText.ToString();

                    // Parameterオブジェクトの作成(検索用)
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaInventorySeqNo = sqlCommand.Parameters.Add("@FINDINVENTORYSEQNO", SqlDbType.Int);
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                    // Parameterオブジェクトへ値設定(検索用)
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(handyWork.EnterpriseCode);
                    findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(handyWork.BelongSectionCode);
                    findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(handyWork.CirculInventSeqNo);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(handyWork.WarehouseCode);

                    myReader = sqlCommand.ExecuteReader();
                 
                    if (myReader.Read())
                    {
                        Double adjstCalcCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJSTCALCCOSTRF"));

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }
                        StringBuilder sqlTextUp = new StringBuilder();
                        #region [UPDATE文作成]
                        sqlTextUp.AppendLine(" UPDATE ");
                        sqlTextUp.AppendLine(" INVENTORYDATARF ");
                        sqlTextUp.AppendLine(" SET ");
                        sqlTextUp.AppendLine(" UPDATEDATETIMERF=@UPDATEDATETIME , ");
                        sqlTextUp.AppendLine(" UPDEMPLOYEECODERF=@EMPLOYEECODE , ");
                        sqlTextUp.AppendLine(" UPDASSEMBLYID1RF=@UPDASSEMBLYID1 ,  ");
                        sqlTextUp.AppendLine(" UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , ");
                        sqlTextUp.AppendLine(" INVENTORYSTOCKCNTRF=@INVENTORYSTOCKCNT , ");
                        sqlTextUp.AppendLine(" INVENTORYDAYRF=@INVENTORYDAY , ");
                        sqlTextUp.AppendLine(" INVENTORYSTOCKPRICERF=@INVENTORYSTOCKPRICE ");
                        sqlTextUp.AppendLine(" WHERE ");
                        sqlTextUp.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                        sqlTextUp.AppendLine(" AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ");
                        sqlTextUp.AppendLine(" AND SECTIONCODERF=@FINDSECTIONCODE ");
                        sqlTextUp.AppendLine(" AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO ");
                        sqlTextUp.AppendLine(" AND WAREHOUSECODERF=@FINDWAREHOUSECODE");
                        #endregion  // [Select文作成]
                        sqlCommand.CommandText = sqlTextUp.ToString();

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)dataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);

                        // Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraInventoryStockCnt = sqlCommand.Parameters.Add("@INVENTORYSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraInventoryDay = sqlCommand.Parameters.Add("@INVENTORYDAY", SqlDbType.Int);
                        SqlParameter paraInventoryStockPrice = sqlCommand.Parameters.Add("@INVENTORYSTOCKPRICE", SqlDbType.BigInt);

                        // Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dataWork.UpdateDateTime);
                        paraEmployeeCode.Value = SqlDataMediator.SqlSetString(handyWork.EmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dataWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dataWork.UpdAssemblyId2);
                        paraInventoryStockCnt.Value = SqlDataMediator.SqlSetDouble(handyWork.InventoryStockCnt);
                        paraInventoryDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);
                        paraInventoryStockPrice.Value = SqlDataMediator.SqlSetInt64(Convert.ToInt64(handyWork.InventoryStockCnt * adjstCalcCost));

                        myReader = sqlCommand.ExecuteReader();
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        return status;
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
                    base.WriteErrorLog(ex, "HandyInventoryDataDB.WriteProc Exception=" + ex.Message, status);
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
            }
            return status;
        }
        #endregion

        #region [棚卸処理(循環)]
        /// <summary>
        /// 棚卸処理(循環)_倉庫存在確認処理
        /// </summary>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定倉庫に在庫情報が存在しているかの確認を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private int SearchCountProc(HandyInventoryCondWork cndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;

            using (sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlText.AppendLine(" SELECT COUNT(*) STOCK_COUNT");
                    sqlText.AppendLine(" FROM");
                    sqlText.AppendLine(" STOCKRF WITH (READUNCOMMITTED)");
                    sqlText.AppendLine(" WHERE");
                    sqlText.AppendLine(" ENTERPRISECODERF=@ENTERPRISECODE");
                    sqlText.AppendLine(" AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
                    sqlText.AppendLine(" AND WAREHOUSECODERF=@FINDWAREHOUSECODE");
                    // 企業コード
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

                    // 論理削除区分
                    SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);

                    // 倉庫コード
                    SqlParameter findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NVarChar);
                    findWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);

                    sqlCommand.CommandText = sqlText.ToString();

                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    int stockCount = 0;
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            stockCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCK_COUNT"));
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        if (stockCount == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
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
                    base.WriteErrorLog(ex, "HandyCirculInventDB.SearchCountProc Exception=" + ex.Message, status);
                }
            }

            return status;
        }

        /// <summary>
        /// 棚卸処理（循環)_棚卸情報登録
        /// </summary>
        /// <param name="stockAdjustCsList">棚卸情報データオブジェクト</param>
        /// <param name="circulInventSeqNo">循環棚卸通番</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 棚卸情報を登録します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private int WriteCirculProc(CustomSerializeArrayList stockAdjustCsList, out int circulInventSeqNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList circulInventHisDataList = null;    //循環棚卸履歴データリスト
            ArrayList circulInventHisDtlList = null;     //循環棚卸履歴明細データリスト
            circulInventSeqNo = 0;
            try
            {
                foreach (CustomSerializeArrayList paraList in stockAdjustCsList)
                {
                    //リストから必要な情報を取得
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        ArrayList wkal = paraList[i] as ArrayList;
                        
                        if (wkal != null)
                        {
                            if (wkal.Count > 0)
                            {
                                //循環棚卸履歴データリストの場合
                                if (wkal[0] is CirculInventHisDataWork)
                                {
                                    circulInventHisDataList = wkal;
                                }
                                //循環棚卸履歴明細データリストの場合
                                else if (wkal[0] is CirculInventHisDtlWork)
                                {
                                    circulInventHisDtlList = wkal;
                                }
                            }
                        }
                    }
                }
                // 循環棚卸履歴データリスト登録
                if (circulInventHisDataList != null)
                {
                    status = this.WriteCirculInventProc(ref circulInventHisDataList, ref sqlConnection, ref sqlTransaction, out circulInventSeqNo);
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // 循環棚卸履歴明細データリスト登録
                if (circulInventHisDtlList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.WriteCirculInventDtlProc(ref circulInventHisDtlList, ref circulInventSeqNo, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInventoryDataDB.WriteCirculProc Exception=" + ex.Message, status);
            }

            return status;
        }

        #region [循環棚卸履歴明細データ登録]
        /// <summary>
        /// 循環棚卸履歴明細データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="circulInventHisDtlList">循環棚卸履歴明細データリスト</param>
        /// <param name="circulInventSeqNo">循環棚卸通番</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 循環棚卸履歴明細データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private int WriteCirculInventDtlProc(ref ArrayList circulInventHisDtlList, ref int circulInventSeqNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;
            StringBuilder sb = new StringBuilder();
            try
            {
                if (circulInventHisDtlList != null)
                {
                    for (int i = 0; i < circulInventHisDtlList.Count; i++)
                    {
                        CirculInventHisDtlWork circulInventHisDtlWork = circulInventHisDtlList[i] as CirculInventHisDtlWork;
                        int maxCirculInventCnt = 0;
                        status = GetMaxCirculInventCnt(circulInventHisDtlWork, ref circulInventSeqNo, out maxCirculInventCnt, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if (sqlCommand != null)
                            {
                                sqlCommand.Cancel();
                                sqlCommand.Dispose();
                            }
                            return status;
                        }
                        //新規作成時のSQL文を生成
                        sb = new StringBuilder();
                        # region INSERT句生成
                        sb.AppendLine(" INSERT INTO ");
                        sb.AppendLine(" CIRCULINVENTHISDTLRF ");
                        sb.AppendLine(" (CREATEDATETIMERF, ");
                        sb.AppendLine(" UPDATEDATETIMERF, ");
                        sb.AppendLine(" ENTERPRISECODERF, ");
                        sb.AppendLine(" FILEHEADERGUIDRF, ");
                        sb.AppendLine(" UPDEMPLOYEECODERF, ");
                        sb.AppendLine(" UPDASSEMBLYID1RF, ");
                        sb.AppendLine(" UPDASSEMBLYID2RF, ");
                        sb.AppendLine(" LOGICALDELETECODERF, ");
                        sb.AppendLine(" SECTIONCODERF, ");
                        sb.AppendLine(" CIRCULINVENTSEQNORF, ");
                        sb.AppendLine(" WAREHOUSECODERF, ");
                        sb.AppendLine(" GOODSMAKERCDRF, ");
                        sb.AppendLine(" GOODSNORF, ");
                        sb.AppendLine(" CIRCULINVENTCNTRF, ");
                        sb.AppendLine(" WAREHOUSESHELFNORF, ");
                        sb.AppendLine(" PRESENTSTOCKCNTRF, ");
                        sb.AppendLine(" INVENTORYSTOCKCNTRF, ");
                        sb.AppendLine(" INVENTORYDATETIMERF ");
                        sb.AppendLine(" ) VALUES ( ");
                        sb.AppendLine(" @CREATEDATETIME, ");
                        sb.AppendLine(" @UPDATEDATETIME, ");
                        sb.AppendLine(" @ENTERPRISECODE, ");
                        sb.AppendLine(" @FILEHEADERGUID, ");
                        sb.AppendLine(" @UPDEMPLOYEECODE, ");
                        sb.AppendLine(" @UPDASSEMBLYID1, ");
                        sb.AppendLine(" @UPDASSEMBLYID2, ");
                        sb.AppendLine(" @LOGICALDELETECODE, ");
                        sb.AppendLine(" @SECTIONCODE, ");
                        sb.AppendLine(" @INVENTORYSEQNO, ");
                        sb.AppendLine(" @WAREHOUSECODE, ");
                        sb.AppendLine(" @GOODSMAKERCD, ");
                        sb.AppendLine(" @GOODSNO, ");
                        sb.AppendLine(" @CIRCULINVENTCNT, ");
                        sb.AppendLine(" @WAREHOUSESHELFNO, ");
                        sb.AppendLine(" @PRESENTSTOCKCNT, ");
                        sb.AppendLine(" @INVENTORYSTOCKCNT, ");
                        sb.AppendLine(" @INVENTORYDATETIME) ");
                        #endregion

                        //登録ヘッダ情報を設定
                        string employeeCode = circulInventHisDtlWork.UpdEmployeeCode;
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)circulInventHisDtlWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                        circulInventHisDtlWork.UpdEmployeeCode = employeeCode;
                        sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                        #region Parameterオブジェクトの作成(更新用)
                        //Prameterオブジェクトの作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInventorySeqNo = sqlCommand.Parameters.Add("@INVENTORYSEQNO", SqlDbType.Int);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraCirculInventCnt = sqlCommand.Parameters.Add("@CIRCULINVENTCNT", SqlDbType.Int);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraPresentStockCnt = sqlCommand.Parameters.Add("@PRESENTSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraInventoryStockCnt = sqlCommand.Parameters.Add("@INVENTORYSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraInventoryDateTime = sqlCommand.Parameters.Add("@INVENTORYDATETIME", SqlDbType.BigInt);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        //Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(circulInventHisDtlWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(circulInventHisDtlWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(circulInventHisDtlWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(circulInventHisDtlWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(circulInventHisDtlWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(circulInventHisDtlWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(circulInventHisDtlWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(circulInventHisDtlWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(circulInventHisDtlWork.SectionCode);
                        paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(circulInventHisDtlWork.CirculInventSeqNo);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(circulInventHisDtlWork.WarehouseCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(circulInventHisDtlWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(circulInventHisDtlWork.GoodsNo);
                        paraCirculInventCnt.Value = SqlDataMediator.SqlSetInt32(maxCirculInventCnt + 1);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(circulInventHisDtlWork.WarehouseShelfNo);
                        paraPresentStockCnt.Value = SqlDataMediator.SqlSetDouble(circulInventHisDtlWork.PresentStockCnt);
                        paraInventoryStockCnt.Value = SqlDataMediator.SqlSetDouble(circulInventHisDtlWork.InventoryStockCnt);
                        paraInventoryDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(circulInventHisDtlWork.InventoryDateTime);
                        #endregion
                        sqlCommand.ExecuteNonQuery();
                        sb = null;
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInventoryDataDB.WriteCirculInventDtlProc" + ex.Message, status);
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

        /// <summary>
        /// 循環棚卸履歴明細データ内の循環棚卸明細連番を戻します
        /// </summary>
        /// <param name="circulInventHisDtlWork">検索パラメータ</param>
        /// <param name="circulInventSeqNo">循環棚卸通番</param>
        /// <param name="maxCirculInventCnt">循環棚卸明細連番</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 循環棚卸履歴明細データ内の最終明細通番を戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        private int GetMaxCirculInventCnt(CirculInventHisDtlWork circulInventHisDtlWork, ref int circulInventSeqNo, out int maxCirculInventCnt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            maxCirculInventCnt = 0;
            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();
                    #region [Select文作成]
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine(" MAX(CIRCULINVENTCNTRF) AS MAX_CNT ");
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" CIRCULINVENTHISDTLRF ");
                    sqlText.AppendLine(" WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" WHERE ");
                    sqlText.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    sqlText.AppendLine(" AND CIRCULINVENTSEQNORF = @FINDINVENTORYSEQNO ");
                    #endregion
                    sqlCommand.CommandText = sqlText.ToString();

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaInventorySeqNo = sqlCommand.Parameters.Add("@FINDINVENTORYSEQNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(circulInventHisDtlWork.EnterpriseCode);
                    if (circulInventSeqNo != 0)
                    {
                        circulInventHisDtlWork.CirculInventSeqNo = circulInventSeqNo;
                    }
                    else
                    {
                        circulInventSeqNo = circulInventHisDtlWork.CirculInventSeqNo;
                    }
                    findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(circulInventHisDtlWork.CirculInventSeqNo);
                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            maxCirculInventCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAX_CNT"));
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
                    base.WriteErrorLog(ex, "HandyInventoryDataDB.GetMaxInventorySeq Exception=" + ex.Message, status);
                }
            }

            return status;
        }
        #endregion

        #region [循環棚卸履歴データ登録]
        /// <summary>
        /// 循環棚卸履歴データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="circulInventHisDataList">循環棚卸履歴データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="inventorySeqNo">循環棚卸通番</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 循環棚卸履歴データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private int WriteCirculInventProc(ref ArrayList circulInventHisDataList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out int inventorySeqNo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            inventorySeqNo = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            
            try
            {
                if (circulInventHisDataList != null)
                {
                    CirculInventHisDataWork circulInventHisDataWork = circulInventHisDataList[0] as CirculInventHisDataWork;

                    NumberingManager numberingManager = new NumberingManager();
                    // 通番を採番
                    long No;

                    //番号採番
                    status = numberingManager.GetSerialNumber(circulInventHisDataWork.EnterpriseCode, "000000", (SerialNumberCode)4100, out No);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        inventorySeqNo = System.Convert.ToInt32(No);
                    }
                    StringBuilder sb = new StringBuilder();
                    # region INSERT句生成
                    sb.AppendLine(" INSERT INTO ");
                    sb.AppendLine(" CIRCULINVENTHISDATARF ");
                    sb.AppendLine(" (CREATEDATETIMERF, ");
                    sb.AppendLine(" UPDATEDATETIMERF, ");
                    sb.AppendLine(" ENTERPRISECODERF, ");
                    sb.AppendLine(" FILEHEADERGUIDRF, ");
                    sb.AppendLine(" UPDEMPLOYEECODERF, ");
                    sb.AppendLine(" UPDASSEMBLYID1RF, ");
                    sb.AppendLine(" UPDASSEMBLYID2RF, ");
                    sb.AppendLine(" LOGICALDELETECODERF, ");
                    sb.AppendLine(" SECTIONCODERF, ");
                    sb.AppendLine(" CIRCULINVENTSEQNORF, ");
                    sb.AppendLine(" WAREHOUSECODERF, ");
                    sb.AppendLine(" NOTERF, ");
                    sb.AppendLine(" EMPLOYEECODERF ");
                    sb.AppendLine(" ) VALUES ( ");
                    sb.AppendLine(" @CREATEDATETIME, ");
                    sb.AppendLine(" @UPDATEDATETIME, ");
                    sb.AppendLine(" @ENTERPRISECODE, ");
                    sb.AppendLine(" @FILEHEADERGUID, ");
                    sb.AppendLine(" @UPDEMPLOYEECODE, ");
                    sb.AppendLine(" @UPDASSEMBLYID1, ");
                    sb.AppendLine(" @UPDASSEMBLYID2, ");
                    sb.AppendLine(" @LOGICALDELETECODE, ");
                    sb.AppendLine(" @SECTIONCODE, ");
                    sb.AppendLine(" @INVENTORYSEQNO, ");
                    sb.AppendLine(" @WAREHOUSECODE, ");
                    sb.AppendLine(" @NOTE, ");
                    sb.AppendLine(" @EMPLOYEECODE) ");
                    #endregion

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)circulInventHisDataWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                    circulInventHisDataWork.UpdEmployeeCode = circulInventHisDataWork.EmployeeCode;
                    sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                    #region Parameterオブジェクトの作成(更新用)
                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraInventorySeqNo = sqlCommand.Parameters.Add("@INVENTORYSEQNO", SqlDbType.Int);
                    SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                    SqlParameter paraNote = sqlCommand.Parameters.Add("@NOTE", SqlDbType.NVarChar);
                    SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);

                    #endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(circulInventHisDataWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(circulInventHisDataWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(circulInventHisDataWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(circulInventHisDataWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(circulInventHisDataWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(circulInventHisDataWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(circulInventHisDataWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(circulInventHisDataWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(circulInventHisDataWork.SectionCode);
                    paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventorySeqNo);
                    paraWarehouseCode.Value = SqlDataMediator.SqlSetString(circulInventHisDataWork.WarehouseCode);
                    paraNote.Value = SqlDataMediator.SqlSetString(circulInventHisDataWork.Note);
                    paraEmployeeCode.Value = SqlDataMediator.SqlSetString(circulInventHisDataWork.EmployeeCode);
                    #endregion
                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInventoryDataDB.WriteCirculInventDtlProc" + ex.Message, status);
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
        #endregion

        #region [循環棚卸照会]
        /// <summary>
        /// 循環棚卸照会データ取得
        /// </summary>
        /// <param name="handywork">検索条件</param>
        /// <param name="handyDataList">検索结果</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 循環棚卸照会データ取得を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private int SearchCirculInventProc(HandyInventoryCondWork handywork, ref ArrayList handyDataList, ref SqlConnection sqlConnection)
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
                    sqlText.AppendLine(" CDL.INVENTORYDATETIMERF, ");   // 棚卸実施日時
                    sqlText.AppendLine(" CDL.WAREHOUSECODERF, ");   // 倉庫コード
                    sqlText.AppendLine(" CDL.WAREHOUSESHELFNORF, ");  // 倉庫棚番
                    sqlText.AppendLine(" CDL.GOODSMAKERCDRF, ");    // 商品メーカーコード
                    sqlText.AppendLine(" MU.MAKERNAMERF, ");    // メーカー名称
                    sqlText.AppendLine(" GU.GOODSNAMERF, ");   // 商品名称
                    sqlText.AppendLine(" CDL.GOODSNORF, ");     // 商品番号
                    sqlText.AppendLine(" CDL.PRESENTSTOCKCNTRF,  ");    // 帳簿数
                    sqlText.AppendLine(" CDL.INVENTORYSTOCKCNTRF,  ");   // 棚卸数
                    sqlText.AppendLine(" CDA.EMPLOYEECODERF,  ");    // 備考
                    sqlText.AppendLine(" CDA.CIRCULINVENTSEQNORF,  ");    // 循環棚卸通番
                    sqlText.AppendLine(" CDA.NOTERF ");     // 従業員コード
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" CIRCULINVENTHISDTLRF CDL WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" INNER JOIN ");
                    sqlText.AppendLine(" CIRCULINVENTHISDATARF CDA WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" ON CDL.ENTERPRISECODERF=CDA.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND CDL.SECTIONCODERF=CDA.SECTIONCODERF ");
                    sqlText.AppendLine(" AND CDL.CIRCULINVENTSEQNORF=CDA.CIRCULINVENTSEQNORF ");
                    sqlText.AppendLine(" AND CDL.LOGICALDELETECODERF=CDA.LOGICALDELETECODERF ");
                    sqlText.AppendLine(" LEFT JOIN ");
                    sqlText.AppendLine(" GOODSURF GU WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" ON CDL.ENTERPRISECODERF=GU.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND CDL.GOODSMAKERCDRF=GU.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" AND CDL.GOODSNORF=GU.GOODSNORF ");
                    sqlText.AppendLine(" LEFT JOIN MAKERURF MU WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" ON CDL.ENTERPRISECODERF=MU.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND  CDL.GOODSMAKERCDRF =MU.GOODSMAKERCDRF ");

                    // WHERE文
                    sqlText.AppendLine(MakeWhereString(handywork, ref sqlCommand));
                    sqlText.AppendLine(" ORDER BY WAREHOUSECODERF,CIRCULINVENTSEQNORF,INVENTORYDATETIMERF");

                    #endregion

                    sqlCommand.CommandText = sqlText.ToString();


                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            HandyInventoryDataWork handyData = new HandyInventoryDataWork();
                            handyData.InventoryDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("INVENTORYDATETIMERF"));
                            handyData.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                            handyData.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                            handyData.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                            handyData.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                            handyData.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                            handyData.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                            handyData.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRESENTSTOCKCNTRF"));
                            handyData.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYSTOCKCNTRF"));
                            handyData.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                            handyData.Note = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTERF"));

                            handyDataList.Add(handyData);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        if (handyDataList.Count == 0)
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
                    base.WriteErrorLog(ex, "HandyInventoryDataDB.SearchCirculInventProc Exception=" + ex.Message, status);
                }
            }
            return status;
        }

        #region [MakeWhereString]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="handyWork">検索条件格納クラス</param>
        /// <param name="sqlCommand">コマンド</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : 検索条件文字列生成＋条件値設定</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private string MakeWhereString(HandyInventoryCondWork handyWork, ref SqlCommand sqlCommand)
        {
            StringBuilder SqlText = new StringBuilder();
            SqlText.AppendLine("WHERE ");

            // 企業コード
            SqlText.AppendLine(" CDL.ENTERPRISECODERF=@ENTERPRISECODE");
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(handyWork.EnterpriseCode);

            // 論理削除区分
            SqlText.AppendLine(" AND CDL.LOGICALDELETECODERF=@LOGICALDELETECODE");
            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);

            // 倉庫コード(開始)
            if (!String.IsNullOrEmpty(handyWork.WarehouseCode))
            {
                SqlText.AppendLine(" AND CDL.WAREHOUSECODERF >= @WAREHOUSECODE");
                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(handyWork.WarehouseCode);
            }

            // 倉庫コード(終了)
            if (!String.IsNullOrEmpty(handyWork.WarehouseCodeEd))
            {
                SqlText.AppendLine(" AND CDL.WAREHOUSECODERF <= @WAREHOUSECODEED");
                SqlParameter findParaWarehouseCodeEd = sqlCommand.Parameters.Add("@WAREHOUSECODEED", SqlDbType.NChar);
                findParaWarehouseCodeEd.Value = SqlDataMediator.SqlSetString(handyWork.WarehouseCodeEd);
            }

            // 棚卸日(開始)
            if (handyWork.InventoryDateStart > DateTime.MinValue)
            {
                SqlText.AppendLine(" AND CDL.INVENTORYDATETIMERF >= @INVENTORYDATESTART ");
                SqlParameter paraInventoryDateStart = sqlCommand.Parameters.Add("@INVENTORYDATESTART", SqlDbType.BigInt);
                paraInventoryDateStart.Value = SqlDataMediator.SqlSetDateTimeFromTicks(handyWork.InventoryDateStart);
            }

            // 棚卸日(終了)
            if (handyWork.InventoryDateEnd > DateTime.MinValue)
            {
                SqlText.AppendLine(" AND CDL.INVENTORYDATETIMERF < @INVENTORYDATEEND ");
                SqlParameter paraInventoryDateEnd = sqlCommand.Parameters.Add("@INVENTORYDATEEND", SqlDbType.BigInt);
                paraInventoryDateEnd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(handyWork.InventoryDateEnd.AddDays(1));
            }

            // 倉庫棚番(開始)
            if (!String.IsNullOrEmpty(handyWork.WarehouseShelfNoStart))
            {
                SqlText.AppendLine(" AND CDL.WAREHOUSESHELFNORF >= @WAREHOUSESHELFNOSTRAT");
                SqlParameter findParaWarehouseShelfNoStart = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOSTRAT", SqlDbType.NChar);
                findParaWarehouseShelfNoStart.Value = SqlDataMediator.SqlSetString(handyWork.WarehouseShelfNoStart);
            }
            // 倉庫棚番(終了)
            if (!String.IsNullOrEmpty(handyWork.WarehouseShelfNoEnd))
            {
                if (String.IsNullOrEmpty(handyWork.WarehouseShelfNoStart))
                {
                    SqlText.AppendLine(" AND (CDL.WAREHOUSESHELFNORF <= @WAREHOUSESHELFNOEND");
                    SqlText.AppendLine(" OR CDL.WAREHOUSESHELFNORF IS NULL)");
                }
                else
                {
                    SqlText.AppendLine(" AND CDL.WAREHOUSESHELFNORF <= @WAREHOUSESHELFNOEND");
                }
                SqlParameter findParaWarehouseCodeEnd = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOEND", SqlDbType.NChar);
                findParaWarehouseCodeEnd.Value = SqlDataMediator.SqlSetString(handyWork.WarehouseShelfNoEnd);
            }

            // 従業員コード
            if (!String.IsNullOrEmpty(handyWork.EmployeeCode))
            {
                SqlText.AppendLine(" AND CDA.EMPLOYEECODERF=@EMPLOYEECODE");
                SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(handyWork.EmployeeCode);
            }

            // 商品メーカーコード
            if (handyWork.GoodsMakerCd > 0)
            {
                SqlText.AppendLine(" AND CDL.GOODSMAKERCDRF=@GOODSMAKERCD");
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(handyWork.GoodsMakerCd);
            }

            // 備考
            if (!String.IsNullOrEmpty(handyWork.Note))
            {
                SqlText.AppendLine(" AND CDA.NOTERF LIKE @NOTE");
                SqlParameter findParaNote = sqlCommand.Parameters.Add("@NOTE", SqlDbType.NVarChar);
                findParaNote.Value = SqlDataMediator.SqlSetString("%" + handyWork.Note + "%");
            }

            //商品番号
            if (!String.IsNullOrEmpty(handyWork.GoodsNo))
            {
                SqlText.AppendLine(" AND CDL.GOODSNORF LIKE @GOODSNO");
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                //前方一致検索の場合
                if (handyWork.GoodsNoSrchTyp == 1) handyWork.GoodsNo = handyWork.GoodsNo + "%";
                //後方一致検索の場合
                if (handyWork.GoodsNoSrchTyp == 2) handyWork.GoodsNo = "%" + handyWork.GoodsNo;
                //あいまい検索の場合
                if (handyWork.GoodsNoSrchTyp == 3) handyWork.GoodsNo = "%" + handyWork.GoodsNo + "%";
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(handyWork.GoodsNo);
            }

            return SqlText.ToString();
        }
        #endregion
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Note        : SqlConnection生成処理。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/08/16</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            // SqlConnection生成
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            // SqlConnection接続
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }
            else
            {
                base.WriteErrorLog("HandyInventoryDataDB.CreateSqlConnection" + "コネクション取得失敗");
            }

            // SqlConnection返す
            return retSqlConnection;
        }
        #endregion  // コネクション生成処理
        #endregion
    }
}
