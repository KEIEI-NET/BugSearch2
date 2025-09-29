//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル在庫（仕入・移動）リモートオブジェクト
// プログラム概要   : ハンディターミナル在庫（仕入・移動）検索、登録処理を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/02  修正内容 : 新規作成
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
    /// ハンディターミナル在庫（仕入・移動）リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル在庫（仕入・移動）リモートオブジェクトです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/08/02</br>
    /// </remarks>
    [Serializable]
    public class HandyStockMoveDB : RemoteDB, IHandyStockMoveDB
    {
        #region const
        /// <summary> 受払元取引区分(10:通常伝票) </summary>
        private const int AcPayTransCd = 10;
        /// <summary>ゼロ</summary>
        private const int Zero = 0;
        /// <summary>移動状態(9：入荷済み)</summary>
        private const int AllArrivaled = 9;
        /// <summary>在庫移動形式(1:在庫出庫)</summary>
        private const int StockShip = 1;
        /// <summary>在庫移動形式(2：倉庫出庫)</summary>
        private const int WarehShip = 2; 
        /// <summary>在庫移動形式(3:在庫入庫)</summary>
        private const int StockEnter = 3;
        /// <summary>在庫移動形式(4:倉庫入庫)</summary>
        private const int WarehEnter = 4;
        /// <summary>処理区分(15：在庫移動出荷検品)</summary>
        private const int StockMoveShip = 15;
        /// <summary>処理区分(16：在庫移動入荷検品)</summary>
        private const int StockMoveEnter = 16;
        /// <summary>在庫移動確定区分(1：確定あり)</summary>
        private const int FixCode = 1;
        /// <summary>在庫移動確定区分(2:確定なし)</summary>
        private const int FixCodeNot = 2;
        #endregion

        #region [コンストラクタ]
        /// <summary>
        /// ハンディターミナル在庫（仕入・移動）リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public HandyStockMoveDB()
        {
            // 特になし
        }
        #endregion

        #region [Public Methods]

        /// <summary>
        /// ハンディターミナル在庫仕入の在庫情報取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retByte">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入の在庫情報取得処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int SearchStock(byte[] condByte, out byte[] retByte)
        {
            SqlConnection sqlConnection = null;
            // 検索結果
            retByte = null;
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
                        base.WriteErrorLog("HandyStockMoveDB.SearchStock" + "カスタムシリアライザ失敗");
                        return status;
                    }

                    HandyStockWork handyStockWork = null;
                    // 在庫情報取得(通常)の初回読込(処理区分：0)を呼び出して在庫情報取得を行います。
                    condWork.OpDiv = 0;
                    HandyStockDB handyStockDB = new HandyStockDB();
                    status = handyStockDB.SearchProc(condWork, out handyStockWork, ref sqlConnection);
                    // 検索結果ステータスが正常の場合、
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retByte = XmlByteSerializer.Serialize(handyStockWork);
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyStockMoveDB.SearchStock Exception=" + ex.Message, status);
                }
            }
            return status;
        }

        // --- ADD 2019/11/13 ---------->>>>>
        /// <summary>
        /// ハンディターミナル在庫仕入の在庫情報取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retByte">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入の在庫情報取得処理を行います。</br>
        /// <br>Programmer : 岸</br>
        /// <br>Date       : 2019/11/13</br>
        /// </remarks>
        public int SearchStockHandy(byte[] condByte, out object retByte)
        {
            SqlConnection sqlConnection = null;
            // 検索結果
            retByte = null;
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
                        base.WriteErrorLog("HandyStockMoveDB.SearchStockHandy" + "カスタムシリアライザ失敗");
                        return status;
                    }

                    ArrayList handyStockWork = null;
                    // 在庫情報取得(通常)の初回読込(処理区分：0)を呼び出して在庫情報取得を行います。
                    condWork.OpDiv = 0;
                    HandyStockDB handyStockDB = new HandyStockDB();
                    status = handyStockDB.SearchHandyProc(condWork, out handyStockWork, ref sqlConnection);
                    // 検索結果ステータスが正常の場合、
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // --- MOD 2019/11/13 ---------->>>>>
                        //retByte = XmlByteSerializer.Serialize(handyStockWork);
                        retByte = handyStockWork;
                        // --- MOD 2019/11/13 ----------<<<<<
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyStockMoveDB.SearchStockHandy Exception=" + ex.Message, status);
                }
            }
            return status;
        }
        // --- ADD 2019/11/13 ----------<<<<<


        /// <summary>
        /// ハンディターミナル在庫移動の検品対象取得処理(伝票番号)
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫移動の検品対象取得処理(伝票番号)を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int Search(byte[] condByte, out object retObj)
        {
            SqlConnection sqlConnection = null;
            // 検索結果
            retObj = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    HandyStockMoveCondWork condWork = (HandyStockMoveCondWork)XmlByteSerializer.Deserialize(condByte, typeof(HandyStockMoveCondWork));
                    // 検索条件がnullの場合、
                    if (condWork == null)
                    {
                        base.WriteErrorLog("HandyStockMoveDB.Search" + "カスタムシリアライザ失敗");
                        return status;
                    }

                    ArrayList retList = null;
                    status = SearchProc(out retList, condWork, ref sqlConnection);
                    // 検索結果ステータスが正常の場合
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 検索結果の格納
                        retObj = retList;
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyStockMoveDB.Search Exception=" + ex.Message, status);
                }
            }
            return status;
        }

        #region [Write]
        /// <summary>
        /// 検品データ登録処理（同一キーで物理削除）
        /// </summary>
        /// <param name="inspectDataObj">検品データオブジェクト</param>
        /// <param name="mode">0:検品データ登録、1:検品データ登録(先行検品)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品データ登録処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int Write(ref object inspectDataObj, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    //パラメータのキャスト
                    ArrayList paraList = inspectDataObj as ArrayList;
                    if (paraList == null)
                    {
                        base.WriteErrorLog("HandyStockMoveDB.Write" + "カスタムシリアライザ失敗");
                        return status;
                    }
                    // トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                    InspectDataDB inspectDataDB = new InspectDataDB();
                    //write実行
                    status = inspectDataDB.WriteInspectDataProc(ref paraList, ref sqlConnection, ref sqlTransaction, mode);
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
                    base.WriteErrorLog(ex, "HandyStockMoveDB.Write Exception=" + ex.Message, status);
                }
                finally
                {
                    if (sqlTransaction != null) sqlTransaction.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [SearchStockMove]
        /// <summary>
        /// 指定された条件の在庫移動情報LIST取得
        /// </summary>
        /// <param name="paraStockMoveWork">検索条件</param>
        /// <param name="retObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件で在庫移動情報LISTを戻します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int SearchStockMove(object paraStockMoveWork, out object retObj)
        {
            SqlConnection sqlConnection = null;
            // 検索結果
            retObj = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList stockMoveWorkList = null;
            SqlTransaction sqlTransaction = null;
            

            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    StockMoveSlipSearchCondWork stockMovePara = paraStockMoveWork as StockMoveSlipSearchCondWork;
                    // 検索条件がnullの場合、
                    if (stockMovePara == null)
                    {
                        base.WriteErrorLog("HandyStockMoveDB.SearchStockMove" + "カスタムシリアライザ失敗");
                        return status;
                    }
                    StockMoveDB stockMoveDB = new StockMoveDB();
                    status = stockMoveDB.SearchStockMoveProc(out stockMoveWorkList, stockMovePara, 0, 0, ref sqlConnection, ref sqlTransaction);
                    // 検索結果の格納
                    retObj = stockMoveWorkList;
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyStockMoveDB.SearchStockMove Exception=" + ex.Message, status);
                }
            }
            return status;
        }
        #endregion
        #endregion

        #region [Private Methods]
        /// <summary>
        /// 在庫移動検品対象取得(伝票番号)
        /// </summary>
        /// <param name="retList">出力データ</param>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫移動検品対象取得(伝票番号)を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList,
            HandyStockMoveCondWork cndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            retList = new ArrayList();

            using (sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlText.AppendLine(StockSqlText(cndtnWork, ref sqlCommand));
                    sqlCommand.CommandText = sqlText.ToString();

                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            // 検索結果の格納
                            retList.Add(CopyDataFromReader(myReader));

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }

                    if (retList.Count == 0)
                    {
                        // 検索結果なし場合、「NOT_FOUND」を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
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
                    base.WriteErrorLog(ex, "HandyStockMoveDB.SearchProc Exception=" + ex.Message, status);
                }
            }
            return status;
        }

        /// <summary>
        /// 入出荷検品データの検索
        /// </summary>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="sqlCommand"></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 入出荷検品データの検索を行う</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private string StockSqlText(HandyStockMoveCondWork cndtnWork, ref SqlCommand sqlCommand)
        {
            StringBuilder sqlText = new StringBuilder();

            sqlText.AppendLine(" SELECT ");
            sqlText.AppendLine("  SMOVE.ENTERPRISECODERF ");   // 企業コード
            sqlText.AppendLine(" ,SMOVE.STOCKMOVESLIPNORF ");   // 在庫移動伝票番号
            sqlText.AppendLine(" ,SMOVE.STOCKMOVEROWNORF");  // 在庫移動行番号
            sqlText.AppendLine(" ,SMOVE.GOODSMAKERCDRF");         // 商品メーカーコード
            sqlText.AppendLine(" ,SMOVE.GOODSNORF");              // 商品番号
            sqlText.AppendLine(" ,SMOVE.MAKERNAMERF");          // メーカー名称
            sqlText.AppendLine(" ,SMOVE.GOODSNAMEKANARF");          // 商品名称カナ
            sqlText.AppendLine(" ,SMOVE.MOVECOUNTRF ");           //移動数
            sqlText.AppendLine(" ,SMOVE.BFENTERWAREHCODERF");          // 移動元倉庫コード
            sqlText.AppendLine(" ,SMOVE.BFENTERWAREHNAMERF");              // 移動元倉庫名称
            sqlText.AppendLine(" ,SMOVE.AFENTERWAREHCODERF ");           // 移動先倉庫コード
            sqlText.AppendLine(" ,SMOVE.AFENTERWAREHNAMERF");          // 移動先倉庫名称
            sqlText.AppendLine(" ,SMOVE.BFSHELFNORF  ");    // 移動元棚番
            sqlText.AppendLine(" ,SMOVE.AFSHELFNORF");          // 移動先棚番
            sqlText.AppendLine(" ,SMOVE.MOVESTATUSRF");          // 移動状態
            sqlText.AppendLine(" ,GBAR.GOODSBARCODERF");          // 商品バーコード
            sqlText.AppendLine(" ,I.INSPECTCODERF");          // 検品区分
            sqlText.AppendLine(" ,I.INSPECTSTATUSRF");          // 検品ステータス
            sqlText.AppendLine(" ,I.INSPECTCNTRF");          // 検品数

            // 在庫移動データ
            sqlText.AppendLine(" FROM STOCKMOVERF AS SMOVE WITH (READUNCOMMITTED) ");
            // 商品バーコード関連付けマスタ
            sqlText.AppendLine(" LEFT JOIN GOODSBARCODEREVNRF AS GBAR WITH (READUNCOMMITTED)");
            sqlText.AppendLine(" ON SMOVE.ENTERPRISECODERF = GBAR.ENTERPRISECODERF");
            sqlText.AppendLine(" AND SMOVE.GOODSMAKERCDRF = GBAR.GOODSMAKERCDRF");
            sqlText.AppendLine(" AND SMOVE.GOODSNORF = GBAR.GOODSNORF");
            sqlText.AppendLine(" AND SMOVE.LOGICALDELETECODERF = GBAR.LOGICALDELETECODERF");
            // 検品データ
            sqlText.AppendLine(" LEFT JOIN INSPECTDATARF AS I WITH (READUNCOMMITTED)");
            sqlText.AppendLine(" ON SMOVE.ENTERPRISECODERF = I.ENTERPRISECODERF");
            sqlText.AppendLine(" AND SMOVE.STOCKMOVESLIPNORF = I.ACPAYSLIPNUMRF");
            sqlText.AppendLine(" AND SMOVE.STOCKMOVEROWNORF = I.ACPAYSLIPROWNORF");
            sqlText.AppendLine(" AND I.ACPAYTRANSCDRF = " + AcPayTransCd);
            // 引数.処理区分が「15：在庫移動出荷検品」の場合
            if (cndtnWork.ProcDiv == StockMoveShip)
            {
                sqlText.AppendLine(" AND (I.ACPAYSLIPCDRF = 30 AND SMOVE.STOCKMOVEFORMALRF IN (1,2))");
            }
            // 引数.処理区分が「16：在庫移動入荷検品」の場合､在庫移動確定区分が「1：確定あり」の場合
            else if (cndtnWork.ProcDiv == StockMoveEnter && cndtnWork.StockMoveFixCode == FixCode)
            {
                sqlText.AppendLine(" AND (I.ACPAYSLIPCDRF = 31 AND SMOVE.STOCKMOVEFORMALRF IN (1,2))");
            }
            // 引数.処理区分が「16：在庫移動入荷検品」の場合､在庫移動確定区分が「2：確定無し」の場合
            else if (cndtnWork.ProcDiv == StockMoveEnter && cndtnWork.StockMoveFixCode == FixCodeNot)
            {
                sqlText.AppendLine(" AND (I.ACPAYSLIPCDRF = 31 AND SMOVE.STOCKMOVEFORMALRF IN (3,4))");
            }
            // WHERE文
            sqlText.AppendLine("WHERE ");

            // 企業コード
            sqlText.AppendLine(" SMOVE.ENTERPRISECODERF=@ENTERPRISECODE");
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

            // 論理削除区分
            sqlText.AppendLine(" AND SMOVE.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);

            // 商品メーカーコード
            sqlText.AppendLine(" AND SMOVE.GOODSMAKERCDRF<>@FINDGOODSMAKERCD");
            SqlParameter findParaGoodsMakeCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            findParaGoodsMakeCd.Value = SqlDataMediator.SqlSetInt32(Zero);

            // 在庫移動伝票番号
            sqlText.AppendLine(" AND SMOVE.STOCKMOVESLIPNORF = @FINDSTOCKMOVESLIPNO");
            SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
            findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(cndtnWork.StockMoveSlipNo);

            // 商品番号
            sqlText.AppendLine(" AND SMOVE.GOODSNORF IS NOT NULL");

            // 引数.処理区分が「15：在庫移動出荷検品」の場合
            if (cndtnWork.ProcDiv == StockMoveShip)
            {
                // 在庫移動形式
                sqlText.AppendLine(" AND SMOVE.STOCKMOVEFORMALRF IN (@FINDSTOCKMOVEFORMAL, @FINDSTOCKMOVEFORMAL2)");
                SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(StockShip);
                SqlParameter findParaStockMoveFormal2 = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL2", SqlDbType.Int);
                findParaStockMoveFormal2.Value = SqlDataMediator.SqlSetInt32(WarehShip);
                // 在庫移動確定区分が「2：確定無し」の場合
                if (cndtnWork.StockMoveFixCode == FixCodeNot)
                {
                    // 移動状態
                    sqlText.AppendLine(" AND SMOVE.MOVESTATUSRF = @FINDMOVESTATUS");
                    // 移動状態
                    SqlParameter findParaMoveStatus = sqlCommand.Parameters.Add("@FINDMOVESTATUS", SqlDbType.Int);
                    findParaMoveStatus.Value = SqlDataMediator.SqlSetInt32(AllArrivaled);
                }
            }
            // 在庫移動確定区分が「1：確定あり」の場合
            else if (cndtnWork.ProcDiv == StockMoveEnter && cndtnWork.StockMoveFixCode == FixCode)
            {
                // 在庫移動形式
                sqlText.AppendLine(" AND SMOVE.STOCKMOVEFORMALRF IN (@FINDSTOCKMOVEFORMAL, @FINDSTOCKMOVEFORMAL2)");
                SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(StockShip);
                SqlParameter findParaStockMoveFormal2 = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL2", SqlDbType.Int);
                findParaStockMoveFormal2.Value = SqlDataMediator.SqlSetInt32(WarehShip);
            }
            // 在庫移動確定区分が「2：確定無し」の場合
            else if (cndtnWork.ProcDiv == StockMoveEnter && cndtnWork.StockMoveFixCode == FixCodeNot)
            {
                // 在庫移動形式
                sqlText.AppendLine(" AND SMOVE.STOCKMOVEFORMALRF IN (@FINDSTOCKMOVEFORMAL, @FINDSTOCKMOVEFORMAL2)");
                SqlParameter paraStockMoveEnter = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                paraStockMoveEnter.Value = SqlDataMediator.SqlSetInt32(StockEnter);
                SqlParameter paraStockMoveEnter2 = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL2", SqlDbType.Int);
                paraStockMoveEnter2.Value = SqlDataMediator.SqlSetInt32(WarehEnter);
                // 移動状態
                sqlText.AppendLine(" AND SMOVE.MOVESTATUSRF = @FINDMOVESTATUS");
                // 移動状態
                SqlParameter findParaMoveStatus = sqlCommand.Parameters.Add("@FINDMOVESTATUS", SqlDbType.Int);
                findParaMoveStatus.Value = SqlDataMediator.SqlSetInt32(AllArrivaled);
                
            }
            sqlText.AppendLine(" ORDER BY  SMOVE.STOCKMOVESLIPNORF,SMOVE.STOCKMOVEROWNORF ASC");
            return sqlText.ToString();
        }

        /// <summary>
        /// クラス格納処理 Reader → 在庫（仕入・移動）結果ワーク
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>在庫（仕入・移動）結果ワーク</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        private HandyStockMoveWork CopyDataFromReader(SqlDataReader myReader)
        {
            HandyStockMoveWork resultWork = new HandyStockMoveWork();

            resultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            resultWork.StockMoveSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVESLIPNORF"));
            resultWork.StockMoveRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEROWNORF"));
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            resultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            resultWork.MoveCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
            resultWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
            resultWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
            resultWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
            resultWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
            resultWork.BfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
            resultWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
            resultWork.MoveStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTATUSRF"));
            resultWork.GoodsBarCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSBARCODERF"));
            resultWork.InspectStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTSTATUSRF"));
            resultWork.InspectCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTCODERF"));
            resultWork.InspectCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INSPECTCNTRF"));

            return resultWork;
        }

        #region [コネクション生成処理]
        /// <summary>
        /// コネクション生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Note        : コネクション生成処理を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/08/02</br>
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
                base.WriteErrorLog("HandyStockMoveDB.CreateSqlConnection" + "コネクション取得失敗");
            }

            // SqlConnection返す
            return retSqlConnection;
        }
        #endregion  // コネクション生成処理
        #endregion
    }
}
