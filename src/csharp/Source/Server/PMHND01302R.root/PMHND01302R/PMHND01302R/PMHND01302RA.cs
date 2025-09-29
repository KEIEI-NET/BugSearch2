//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル委託在庫補充リモートオブジェクトクラス
// プログラム概要   : ハンディターミナル委託在庫補充リモートオブジェクトクラスです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370104-00 作成担当 : 脇田　靖之
// 修 正 日  2017/12/14  修正内容 :ハンディターミナル三次対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

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
    /// ハンディターミナル委託在庫補充リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル委託在庫補充リモートオブジェクトです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/08/11</br>
    /// </remarks>
    [Serializable]
    public class HandyConsStockRepDB : RemoteDB, IHandyConsStockRepDB
    {
        #region [定数]
        /// <summary>受払元伝票区分「70:補充入庫」</summary>
        private const int AcPaySlipCdData70 = 70;
        /// <summary>受払元取引区分「30:在庫数調整」</summary>
        private const int AcPayTransCdData30 = 30;
        #endregion

        #region [コンストラクタ]
        /// <summary>
        /// ハンディターミナル委託在庫補充リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public HandyConsStockRepDB()
        {
        }
        #endregion

        #region ハンディターミナル委託在庫補充_倉庫情報抽出処理
        /// <summary>
        /// ハンディターミナル委託在庫補充_倉庫情報抽出処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>検索結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル委託在庫補充_倉庫情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchHandyWarehouseInfo(byte[] condByte, out object retListObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            retListObj = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                // コネクションが作成できない場合
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                ConsStockRepWarehouseParamWork condWork = (ConsStockRepWarehouseParamWork)XmlByteSerializer.Deserialize(condByte, typeof(ConsStockRepWarehouseParamWork));
                // 検索ワークが作成できないの場合
                if (condWork == null)
                {
                    base.WriteErrorLog("HandyConsStockRepDB.SearchHandyWarehouseInfo" + "カスタムシリアライザ失敗");
                    return status;
                }

                ArrayList handyConsStockRepList = null;
                status = SearchHandyWarehouseInfoProc(condWork, out handyConsStockRepList, ref sqlConnection);

                // 検索結果ステータスが正常の場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retListObj = (object)handyConsStockRepList;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyConsStockRepDB.SearchHandyWarehouseInfo" + ex.Message, status);
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            }

            return status;
        }

        /// <summary>
        /// ハンディターミナル委託在庫補充_倉庫情報を抽出します
        /// </summary>
        /// <param name="condWork">検索条件</param>
        /// <param name="handyConsStockRepList">検索結果</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>検索結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル委託在庫補充_倉庫情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private int SearchHandyWarehouseInfoProc(ConsStockRepWarehouseParamWork condWork, out ArrayList handyConsStockRepList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            handyConsStockRepList = null;

            try
            {
                // SQL文を生成
                StringBuilder sb = new StringBuilder();

                # region SELECT句生成
                sb.AppendLine("SELECT");
                sb.AppendLine(" WAREHOUSERF.WAREHOUSECODERF CONSIGNWAREHOUSECODE, ");
                sb.AppendLine(" WAREHOUSERF.WAREHOUSENAMERF CONSIGNWAREHOUSENAME, ");
                sb.AppendLine(" SUBWARE.WAREHOUSECODERF MAINMNGWAREHOUSECD, ");
                sb.AppendLine(" SUBWARE.WAREHOUSENAMERF MAINMNGWAREHOUSENAME ");
                sb.AppendLine("FROM WAREHOUSERF WITH (READUNCOMMITTED) ");
                // 倉庫マスタ
                sb.AppendLine(" INNER JOIN WAREHOUSERF SUBWARE WITH (READUNCOMMITTED) ON ");
                sb.AppendLine(" WAREHOUSERF.ENTERPRISECODERF = SUBWARE.ENTERPRISECODERF ");
                sb.AppendLine(" AND WAREHOUSERF.MAINMNGWAREHOUSECDRF = SUBWARE.WAREHOUSECODERF ");
                sb.AppendLine(" AND WAREHOUSERF.LOGICALDELETECODERF = SUBWARE.LOGICALDELETECODERF ");
                sb.AppendLine("WHERE");
                sb.AppendLine(" WAREHOUSERF.ENTERPRISECODERF = @FINDENTERPRISECODE ");
                sb.AppendLine(" AND WAREHOUSERF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
                sb.AppendLine(" AND WAREHOUSERF.WAREHOUSECODERF = @FINDWAREHOUSECODE ");
                # endregion

                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                #region パラメータ設定
                // 企業コード
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                // 論理削除区分
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                // 倉庫コード
                SqlParameter findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                findWarehouseCode.Value = SqlDataMediator.SqlSetString(condWork.WarehouseCode);
                #endregion

                myReader = sqlCommand.ExecuteReader();

                handyConsStockRepList = new ArrayList();

                // データが存在する場合
                while (myReader.Read())
                {
                    // 委託在庫補充_倉庫情報を設定します。
                    handyConsStockRepList.Add(this.CopyToHandyConsStockRepListWorkFromReader(ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                base.WriteErrorLog(ex, "HandyConsStockRepDB.SearchHandyWarehouseInfoProc" + ex.Message, status);
            }
            finally
            {
                // myReaderがnullではない場合
                if (myReader != null)
                {
                    // myReaderが閉じていない場合、
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                    myReader = null;
                }

                // sqlCommandがnullではない場合
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
            }

            return status;
        }

        /// <summary>
        /// クラス格納処理 Reader → ConsStockRepWarehouseRetWork
        /// </summary>
        /// <param name="myReader">読込結果</param>
        /// <returns>ハンディターミナル委託在庫補充_倉庫情報</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private ConsStockRepWarehouseRetWork CopyToHandyConsStockRepListWorkFromReader(ref SqlDataReader myReader)
        {
            ConsStockRepWarehouseRetWork consStockRepWarehouseRetWork = new ConsStockRepWarehouseRetWork();

            #region クラスへ格納
            consStockRepWarehouseRetWork.ConsignWarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONSIGNWAREHOUSECODE"));          // 委託倉庫コード
            consStockRepWarehouseRetWork.ConsignWarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONSIGNWAREHOUSENAME"));          // 委託倉庫名称
            consStockRepWarehouseRetWork.MainMngWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAINMNGWAREHOUSECD"));              // 主管元倉庫コード
            consStockRepWarehouseRetWork.MainMngWarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAINMNGWAREHOUSENAME"));          // 主管元倉庫名称
            #endregion

            return consStockRepWarehouseRetWork;
        }
        #endregion

        #region ハンディターミナル委託在庫補充_検品情報取得処理
        /// <summary>
        /// ハンディターミナル委託在庫補充_検品情報取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>検索結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル委託在庫補充_検品情報を検索します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchHandyInspectInfo(byte[] condByte, out object retListObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            retListObj = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                // コネクションが作成できない場合
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                ConsStockRepInspectParamWork condWork = (ConsStockRepInspectParamWork)XmlByteSerializer.Deserialize(condByte, typeof(ConsStockRepInspectParamWork));
                // 検索ワークが作成できないの場合
                if (condWork == null)
                {
                    base.WriteErrorLog("HandyConsStockRepDB.SearchHandyInspectInfo" + "カスタムシリアライザ失敗");
                    return status;
                }

                ArrayList handyInspectList = null;
                status = SearchHandyInspectInfoProc(condWork, out handyInspectList, ref sqlConnection);

                // ステータスが正常の場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retListObj = (object)handyInspectList;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyConsStockRepDB.SearchHandyInspectInfo" + ex.Message, status);
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null; 
                }
            }

            return status;
        }

        /// <summary>
        /// ハンディターミナル委託在庫補充_検品情報を抽出します
        /// </summary>
        /// <param name="condWork">検品情報検索条件</param>
        /// <param name="handyInspectList">検品情報検索結果</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>ハンディターミナル委託在庫補充_検品情報</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル委託在庫補充_検品情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private int SearchHandyInspectInfoProc(ConsStockRepInspectParamWork condWork, out ArrayList handyInspectList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            handyInspectList = null;

            try
            {
                // SQL文を生成
                StringBuilder sb = new StringBuilder();

                # region SELECT句生成
                sb.AppendLine("SELECT");
                sb.AppendLine(" STOCKADJUSTDTLRF.ACPAYSLIPCDRF, ");
                sb.AppendLine(" STOCKADJUSTDTLRF.ACPAYTRANSCDRF, ");
                sb.AppendLine(" STOCKADJUSTDTLRF.STOCKADJUSTSLIPNORF, ");
                sb.AppendLine(" STOCKADJUSTDTLRF.STOCKADJUSTROWNORF, ");
                sb.AppendLine(" STOCKADJUSTDTLRF.ADJUSTDATERF, ");
                sb.AppendLine(" STOCKADJUSTDTLRF.GOODSMAKERCDRF, ");
                sb.AppendLine(" STOCKADJUSTDTLRF.GOODSNORF, ");
                sb.AppendLine(" STOCKADJUSTDTLRF.GOODSNAMERF, ");
                sb.AppendLine(" STOCKADJUSTDTLRF.ADJUSTCOUNTRF, ");
                // --- ADD 2017/12/14 Y.Wakita ---------->>>>>
                //sb.AppendLine(" STOCKADJUSTDTLRF.WAREHOUSECODERF, ");
                //sb.AppendLine(" STOCKADJUSTDTLRF.WAREHOUSENAMERF, ");
                //sb.AppendLine(" STOCKADJUSTDTLRF.WAREHOUSESHELFNORF, ");
                sb.AppendLine(" STOCKSUB.WAREHOUSECODERF, ");
                sb.AppendLine(" STOCKSUB.WAREHOUSENAMERF, ");
                sb.AppendLine(" STOCKSUB.WAREHOUSESHELFNORF, ");
                // --- ADD 2017/12/14 Y.Wakita ----------<<<<<
                sb.AppendLine(" GOODSBARCODEREVNRF.GOODSBARCODERF, ");
                sb.AppendLine(" INSPECTDATARF.INSPECTSTATUSRF, ");
                sb.AppendLine(" INSPECTDATARF.INSPECTCODERF, ");
                sb.AppendLine(" INSPECTDATARF.INSPECTCNTRF ");
                sb.AppendLine("FROM STOCKADJUSTDTLRF WITH (READUNCOMMITTED) ");
                // 商品バーコード関連付けマスタ
                sb.AppendLine(" LEFT JOIN GOODSBARCODEREVNRF WITH (READUNCOMMITTED) ");
                sb.AppendLine(" ON STOCKADJUSTDTLRF.ENTERPRISECODERF = GOODSBARCODEREVNRF.ENTERPRISECODERF ");
                sb.AppendLine(" AND STOCKADJUSTDTLRF.LOGICALDELETECODERF = GOODSBARCODEREVNRF.LOGICALDELETECODERF ");
                sb.AppendLine(" AND STOCKADJUSTDTLRF.GOODSMAKERCDRF = GOODSBARCODEREVNRF.GOODSMAKERCDRF ");
                sb.AppendLine(" AND STOCKADJUSTDTLRF.GOODSNORF = GOODSBARCODEREVNRF.GOODSNORF ");
                // 検品データ
                sb.AppendLine(" LEFT JOIN INSPECTDATARF WITH (READUNCOMMITTED) ");
                sb.AppendLine(" ON STOCKADJUSTDTLRF.ENTERPRISECODERF = INSPECTDATARF.ENTERPRISECODERF ");
                sb.AppendLine(" AND STOCKADJUSTDTLRF.LOGICALDELETECODERF = INSPECTDATARF.LOGICALDELETECODERF ");
                sb.AppendLine(" AND STOCKADJUSTDTLRF.ACPAYSLIPCDRF = INSPECTDATARF.ACPAYSLIPCDRF ");
                sb.AppendLine(" AND STOCKADJUSTDTLRF.ACPAYTRANSCDRF = INSPECTDATARF.ACPAYTRANSCDRF ");
                sb.AppendLine(" AND STOCKADJUSTDTLRF.STOCKADJUSTSLIPNORF = INSPECTDATARF.ACPAYSLIPNUMRF ");
                sb.AppendLine(" AND STOCKADJUSTDTLRF.STOCKADJUSTROWNORF = INSPECTDATARF.ACPAYSLIPROWNORF ");
                // --- ADD 2017/12/14 Y.Wakita ---------->>>>>
                // 在庫マスタ＋倉庫マスタ
                sb.AppendLine(" LEFT JOIN (");
                sb.AppendLine(" SELECT ");
                sb.AppendLine("  STOCKRF.ENTERPRISECODERF ");
                sb.AppendLine(" ,STOCKRF.LOGICALDELETECODERF ");
                sb.AppendLine(" ,STOCKRF.GOODSMAKERCDRF ");
                sb.AppendLine(" ,STOCKRF.GOODSNORF ");
                sb.AppendLine(" ,STOCKRF.WAREHOUSESHELFNORF ");
                sb.AppendLine(" ,WAREHOUSERF.WAREHOUSECODERF ");
                sb.AppendLine(" ,WAREHOUSERF.WAREHOUSENAMERF ");
                sb.AppendLine(" FROM STOCKRF WITH (READUNCOMMITTED) ");
                sb.AppendLine(" LEFT JOIN WAREHOUSERF WITH (READUNCOMMITTED) ");
                sb.AppendLine("  ON STOCKRF.ENTERPRISECODERF = WAREHOUSERF.ENTERPRISECODERF ");
                sb.AppendLine(" AND STOCKRF.LOGICALDELETECODERF = WAREHOUSERF.LOGICALDELETECODERF ");
                sb.AppendLine(" AND STOCKRF.WAREHOUSECODERF = WAREHOUSERF.WAREHOUSECODERF ");
                sb.AppendLine(" WHERE STOCKRF.WAREHOUSECODERF = @FINDMAINMNGWAREHOUSECODE ");
                sb.AppendLine(" ) STOCKSUB ");
                sb.AppendLine(" ON STOCKADJUSTDTLRF.ENTERPRISECODERF = STOCKSUB.ENTERPRISECODERF ");
                sb.AppendLine(" AND STOCKADJUSTDTLRF.LOGICALDELETECODERF = STOCKSUB.LOGICALDELETECODERF ");
                sb.AppendLine(" AND STOCKADJUSTDTLRF.GOODSMAKERCDRF = STOCKSUB.GOODSMAKERCDRF ");
                sb.AppendLine(" AND STOCKADJUSTDTLRF.GOODSNORF = STOCKSUB.GOODSNORF ");
                // --- ADD 2017/12/14 Y.Wakita ----------<<<<<
                sb.AppendLine("WHERE");
                sb.AppendLine(" STOCKADJUSTDTLRF.ENTERPRISECODERF = @FINDENTERPRISECODE ");
                sb.AppendLine(" AND STOCKADJUSTDTLRF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
                sb.AppendLine(" AND STOCKADJUSTDTLRF.ACPAYSLIPCDRF = @FINDACPAYSLIPCD ");
                sb.AppendLine(" AND STOCKADJUSTDTLRF.ACPAYTRANSCDRF = @FINDACPAYTRANSCD ");
                sb.AppendLine(" AND STOCKADJUSTDTLRF.WAREHOUSECODERF = @FINDWAREHOUSECODE ");
                sb.AppendLine(" AND STOCKADJUSTDTLRF.ADJUSTDATERF = @FINDADJUSTDATE ");
                sb.AppendLine("ORDER BY ");
                sb.AppendLine(" STOCKADJUSTDTLRF.STOCKADJUSTSLIPNORF, STOCKADJUSTDTLRF.STOCKADJUSTROWNORF ");
                # endregion

                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                #region パラメータ設定
                // 企業コード
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                // 論理削除区分
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                // 受払元伝票区分
                SqlParameter findAcPaySlipCd = sqlCommand.Parameters.Add("@FINDACPAYSLIPCD", SqlDbType.Int);
                findAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(AcPaySlipCdData70);
                // 受払元取引区分
                SqlParameter findAcPayTransCd = sqlCommand.Parameters.Add("@FINDACPAYTRANSCD", SqlDbType.Int);
                findAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(AcPayTransCdData30);
                // 倉庫コード
                SqlParameter findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.Int);
                findWarehouseCode.Value = SqlDataMediator.SqlSetString(condWork.ConsignWarehouseCode);
                // 調整日付
                SqlParameter findAdjustDate = sqlCommand.Parameters.Add("@FINDADJUSTDATE", SqlDbType.Int);
                findAdjustDate.Value = SqlDataMediator.SqlSetInt32(condWork.ShipmentDay);
                // --- ADD 2017/12/14 Y.Wakita ---------->>>>>
                // 倉庫コード
                SqlParameter findMainMngWarehouseCode = sqlCommand.Parameters.Add("@FINDMAINMNGWAREHOUSECODE", SqlDbType.Int);
                findMainMngWarehouseCode.Value = SqlDataMediator.SqlSetString(condWork.MainMngWarehouseCode);
                // --- ADD 2017/12/14 Y.Wakita ----------<<<<<
                #endregion

                myReader = sqlCommand.ExecuteReader();

                handyInspectList = new ArrayList();

                // データが存在する場合
                while (myReader.Read())
                {
                    // ハンディターミナル委託在庫補充_検品情報を設定します。
                    handyInspectList.Add(this.CopyToHandyInspectListWorkFromReader(condWork, ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                base.WriteErrorLog(ex, "HandyConsStockRepDB.SearchHandyInspectInfoProc" + ex.Message, status);
            }
            finally
            {
                // myReaderがnullではない場合
                if (myReader != null)
                {
                    // myReaderが閉じていない場合、
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                    myReader = null;
                }

                // sqlCommandがnullではない場合
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
            }

            return status;
        }

        /// <summary>
        /// クラス格納処理 Reader → ConsStockRepInspectRetWork
        /// </summary>
        /// <param name="condWork">検索条件ワーク</param>
        /// <param name="myReader">読込結果</param>
        /// <returns>ハンディターミナル委託在庫補充_検品情報</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private ConsStockRepInspectRetWork CopyToHandyInspectListWorkFromReader(ConsStockRepInspectParamWork condWork, ref SqlDataReader myReader)
        {
            ConsStockRepInspectRetWork consStockRepInspectRetWork = new ConsStockRepInspectRetWork();

            #region クラスへ格納
            consStockRepInspectRetWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF"));                  // 在庫調整伝票番号
            consStockRepInspectRetWork.StockAdjustRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTROWNORF"));                    // 在庫調整行番号
            consStockRepInspectRetWork.AdjustDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADJUSTDATERF"));                                // 調整日付
            consStockRepInspectRetWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));                            // メーカーコード
            consStockRepInspectRetWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));                                     // 商品番号
            consStockRepInspectRetWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));                                 // 商品名称
            consStockRepInspectRetWork.AdjustCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));                             // 調整数
            consStockRepInspectRetWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));                         // 倉庫コード
            consStockRepInspectRetWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));                         // 倉庫名称
            consStockRepInspectRetWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));                   // 倉庫棚番
            consStockRepInspectRetWork.GoodsBarCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSBARCODERF"));                           // 商品バーコード
            consStockRepInspectRetWork.InspectStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTSTATUSRF"));                          // 検品ステータス
            consStockRepInspectRetWork.InspectCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INSPECTCNTRF"));                               // 検品区分
            consStockRepInspectRetWork.InspectCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTCODERF"));                              // 検品数
            #endregion

            return consStockRepInspectRetWork;
        }
        #endregion

        #region [Private Methods]
        /// <summary>
        /// SQLコネクション生成処理
        /// </summary>
        /// <returns>SQLコネクション</returns>
        /// <remarks>
        /// <br>Note       : SQLコネクションを生成します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
            {
                base.WriteErrorLog("HandyConsStockRepDB.CreateSqlConnection" + "コネクション取得失敗");
                return null;
            } 

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
