//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 貸出変換処理
// プログラム概要   : 条件を満たしたデータを品番変換する
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 陳永康
// 作 成 日  2015/01/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/02/26  修正内容 : Redmine#44209 メッセージの文言対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/17  修正内容 : Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/29  修正内容 : リストのNULL、とcountは判断する対応
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
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
//using Broadleaf.Application.LocalAccess; // DEL 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 貸出変換処理DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 貸出変換処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 陳永康</br>
    /// <br>Date       : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class ShipmentChangeDB : RemoteDB
    {
        /// <summary>
        /// 貸出変換処理DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        public ShipmentChangeDB()
        {
            // 品番変換処理共通
            if (this._iGoodsNoChgCommonDB == null)
            {
                this._iGoodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
            // 在庫受払履歴リモート
            if (this._stockAcPayHistDB == null)
            {
                this._stockAcPayHistDB = new StockAcPayHistDB();
            }
            // 仕入先マスタリモート
            if (this._supplierDB == null)
            {
                this._supplierDB = new SupplierDB();
            }
            // 得意先マスタリモート
            if (this._customerDB == null)
            {
                this._customerDB = new CustomerDB();
            }
        }

        #region [OtherRemote]
        private StockAcPayHistDB _stockAcPayHistDB;    //在庫受払履歴リモート
        private GoodsNoChgCommonDB _iGoodsNoChgCommonDB;
        private SupplierDB _supplierDB; // 仕入先マスタリモート
        private CustomerDB _customerDB; //得意先マスタリモート
        #endregion

        #region [貸出変換処理]

        #region 貸出データ検索処理
        /// <summary>
        /// 指定された条件の売上明細データ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="resultWorkList">検索結果</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        private int SearchSalesDetailProc(out ArrayList resultWorkList, string enterPriseCode)
        {
            // コネクション生成
            SqlConnection sqlConnection = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            resultWorkList = new ArrayList();
            ShipmentChangeWork shipmentChangeWork = null;

            try
            {
                // コネクション生成
                sqlConnection = _iGoodsNoChgCommonDB.CreateSqlConnection(true);

                #region SQL作成
                string command = string.Empty;
                command = " SELECT " + Environment.NewLine;
                command += " SALDTL.UPDATEDATETIMERF " + Environment.NewLine; 　　　　// 更新日時
                command += " ,GDSCHG.CHGSRCGOODSNORF " + Environment.NewLine; 　　　　// 変換前商品番号
                command += " ,GDSCHG.GOODSMAKERCDRF " + Environment.NewLine;  　　　　// 商品メーカーコード
                command += " ,GDSCHG.CHGDESTGOODSNORF " + Environment.NewLine;　　　　// 変換後商品番号
                command += " ,SALDTL.ACPTANODRSTATUSRF " + Environment.NewLine; 　　　　// 受注ステータス
                command += " ,SALDTL.SALESSLIPNUMRF " + Environment.NewLine; 　　　　// 売上伝票番号
                command += " ,SALDTL.SALESROWNORF " + Environment.NewLine; 　　　　// 売上行番号
                command += " ,SALDTL.SALESSLIPDTLNUMRF " + Environment.NewLine; 　　　　// 売上明細通番
                command += " ,SALDTL.MAKERNAMERF " + Environment.NewLine; 　　　　// メーカー名称
                command += " ,SALDTL.GOODSNAMERF " + Environment.NewLine; 　　　　// 商品名称
                command += " ,SALDTL.BLGOODSCODERF " + Environment.NewLine; 　　　　// BL商品コード
                command += " ,SALDTL.BLGOODSFULLNAMERF " + Environment.NewLine; 　　　　// BL商品コード名称
                command += " ,SALDTL.ACPTANODRREMAINCNTRF " + Environment.NewLine; 　　　　// 受注残数
                command += " ,SALDTL.OPENPRICEDIVRF " + Environment.NewLine; 　　　　// オープン価格区分
                command += " ,SALDTL.LISTPRICETAXEXCFLRF " + Environment.NewLine; 　　　　// 定価（税抜，浮動）
                command += " ,SALDTL.SALESUNITCOSTRF " + Environment.NewLine; 　　　　// 原価単価
                command += " ,SALDTL.SALESUNPRCTAXEXCFLRF " + Environment.NewLine; 　　　　// 売上単価（税抜，浮動）
                command += " ,SALDTL.SUPPLIERCDRF " + Environment.NewLine; 　　　　// 仕入先コード

                command += " ,SALSEC.CUSTOMERCODERF " + Environment.NewLine; 　　　　// 得意先コード
                command += " ,SALSEC.CUSTOMERSNMRF " + Environment.NewLine; 　　　　// 得意先略称
                command += " ,SALSEC.RESULTSADDUPSECCDRF " + Environment.NewLine; 　　　　// 拠点コード
                command += " ,SALSEC.SECTIONGUIDENMRF  " + Environment.NewLine;           // 拠点ガイド名称

                command += " ,SALDTL.WAREHOUSECODERF " + Environment.NewLine; 　　　　// 倉庫コード
                command += " ,SALDTL.WAREHOUSENAMERF " + Environment.NewLine; 　　　　// 倉庫名称
                command += " ,SALDTL.WAREHOUSESHELFNORF " + Environment.NewLine; 　　　　// 倉庫棚番

                command += " ,STKNEW.WAREHOUSECODERF AS WAREHOUSECODENEWRF " + Environment.NewLine;  // 倉庫コード(新品番)
                command += " ,STKNEW.SUPPLIERSTOCKRF " + Environment.NewLine; 　　　　// 仕入在庫数(新品番)
                command += " ,STKNEW.ACPODRCOUNTRF " + Environment.NewLine; 　　　　// 受注数(新品番)
                command += " ,STKNEW.SALESORDERCOUNTRF " + Environment.NewLine; 　　　　// 発注数(新品番)
                command += " ,STKNEW.MOVINGSUPLISTOCKRF " + Environment.NewLine; 　　　　//移動中仕入在庫数(新品番)
                command += " ,STKNEW.SHIPMENTCNTRF AS SHIPMENTCNTNOADDRF " + Environment.NewLine; 　　　　// 出荷数（未計上）(新品番)
                command += " ,STKNEW.ARRIVALCNTRF " + Environment.NewLine; 　　　　// 入荷数（未計上）(新品番)
                command += " ,STKNEW.SHIPMENTPOSCNTRF " + Environment.NewLine; 　　　　// 出荷可能数(新品番)
                command += " ,STKOLD.WAREHOUSECODERF AS WAREHOUSECODEOLDRF " + Environment.NewLine;  // 倉庫コード(旧品番)
                command += " ,STKOLD.SHIPMENTCNTRF AS SHIPMENTCNTNOADDOLDRF " + Environment.NewLine; 　　　　// 出荷数（未計上）(旧品番)
                command += " ,STKOLD.SHIPMENTPOSCNTRF AS SHIPMENTPOSCNTOLDRF " + Environment.NewLine; 　　　　// 出荷可能数(旧品番)

                command += " FROM SALESDETAILRF SALDTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                command += " INNER JOIN GOODSNOCHANGERF GDSCHG WITH (READUNCOMMITTED) " + Environment.NewLine;
                command += "  ON GDSCHG.ENTERPRISECODERF = SALDTL.ENTERPRISECODERF " + Environment.NewLine;
                command += "  AND GDSCHG.CHGSRCGOODSNORF = SALDTL.GOODSNORF " + Environment.NewLine;
                command += "  AND GDSCHG.GOODSMAKERCDRF = SALDTL.GOODSMAKERCDRF " + Environment.NewLine;

                command += " INNER JOIN " + Environment.NewLine;
                command += "   (SELECT " + Environment.NewLine;
                command += "      SALS.ENTERPRISECODERF " + Environment.NewLine;
                command += "     ,SALS.ACPTANODRSTATUSRF " + Environment.NewLine;
                command += "     ,SALS.SALESSLIPNUMRF " + Environment.NewLine;
                command += "     ,SALS.CUSTOMERCODERF " + Environment.NewLine;     // 得意先コード
                command += "     ,SALS.CUSTOMERSNMRF " + Environment.NewLine;        // 得意先略称
                command += "     ,SALS.RESULTSADDUPSECCDRF " + Environment.NewLine;       // 拠点コード
                command += "     ,SECINF.SECTIONGUIDENMRF " + Environment.NewLine;     // 拠点ガイド名称
                command += "    FROM SALESSLIPRF SALS WITH (READUNCOMMITTED) " + Environment.NewLine;
                command += "    LEFT JOIN SECINFOSETRF SECINF WITH (READUNCOMMITTED) " + Environment.NewLine;
                command += "     ON SECINF.ENTERPRISECODERF = SALS.ENTERPRISECODERF " + Environment.NewLine;
                command += "     AND SECINF.SECTIONCODERF = SALS.RESULTSADDUPSECCDRF ) AS SALSEC" + Environment.NewLine;
                command += "  ON SALSEC.ENTERPRISECODERF = SALDTL.ENTERPRISECODERF " + Environment.NewLine;
                command += "  AND SALSEC.ACPTANODRSTATUSRF = SALDTL.ACPTANODRSTATUSRF " + Environment.NewLine;
                command += "  AND SALSEC.SALESSLIPNUMRF = SALDTL.SALESSLIPNUMRF " + Environment.NewLine;

                command += "  LEFT JOIN STOCKRF STKOLD WITH (READUNCOMMITTED)  " + Environment.NewLine;
                command += "  ON STKOLD.ENTERPRISECODERF = SALDTL.ENTERPRISECODERF " + Environment.NewLine;
                command += "  AND STKOLD.WAREHOUSECODERF = SALDTL.WAREHOUSECODERF " + Environment.NewLine;
                command += "  AND STKOLD.GOODSMAKERCDRF = SALDTL.GOODSMAKERCDRF " + Environment.NewLine;
                command += "  AND STKOLD.GOODSNORF = GDSCHG.CHGSRCGOODSNORF " + Environment.NewLine;

                command += "  LEFT JOIN STOCKRF STKNEW WITH (READUNCOMMITTED)  " + Environment.NewLine;
                command += "  ON STKNEW.ENTERPRISECODERF = SALDTL.ENTERPRISECODERF " + Environment.NewLine;
                command += "  AND STKNEW.WAREHOUSECODERF = SALDTL.WAREHOUSECODERF " + Environment.NewLine;
                command += "  AND STKNEW.GOODSMAKERCDRF = SALDTL.GOODSMAKERCDRF " + Environment.NewLine;
                command += "  AND STKNEW.GOODSNORF = GDSCHG.CHGDESTGOODSNORF " + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(command, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, enterPriseCode);
                // クエリ実行時のタイムアウト時間を10分に設定する
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // クラス格納処理
                    CopyToWorkFromReader(ref myReader, out shipmentChangeWork);
                    resultWorkList.Add(shipmentChangeWork);
                }

                if (resultWorkList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException)
            {
                //基底クラスに例外を渡して処理してもらう
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        #endregion

        #region 貸出データ変換処理
        /// <summary>
        /// 指定された条件の貸出変換処理。
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の貸出変換処理。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        public int ShipmentChange(GoodsChangeAllCndWorkWork CndWork, out object sucObjectList, out object errObjectList, out int readCnt)
        {
            // コネクション
            SqlConnection sqlConnection = null;
            // トランザクション
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //変換対象の貸出データ
            ArrayList changeList = new ArrayList();

            // 成功な登録するデータ
            sucObjectList = null;
            ArrayList sucResultList = new ArrayList();

            // 失敗な登録するデータ
            errObjectList = null;
            ArrayList errResultList = new ArrayList();

            // 対象件数
            readCnt = 0;

            try
            {
                // コネクション生成
                sqlConnection = _iGoodsNoChgCommonDB.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = _iGoodsNoChgCommonDB.CreateTransaction(ref sqlConnection);

                // 貸出データ検索処理
                status = this.SearchSalesDetailProc(out changeList, CndWork.EnterpriseCode);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    return status;
                }

                readCnt = changeList.Count;

                status = this.ShipmentChangeProc(CndWork, changeList,out sucResultList, out errResultList, ref sqlConnection, ref sqlTransaction);

                // 戻られるリスト
                sucObjectList = (object)sucResultList;
                errObjectList = (object)errResultList;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    sqlTransaction.Rollback();
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ShipmentChangeDB.shipmentChange");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        #region 貸出データ更新処理
        /// <summary>
        /// 指定された条件の貸出データ更新
        /// </summary>
        /// <param name="cndWork">CndWork</param>
        /// <param name="changeList">対象の貸出データ</param>
        /// <param name="sucResultList">sucessList</param>
        /// <param name="errResultList">errorList</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private int ShipmentChangeProc(GoodsChangeAllCndWorkWork cndWork, ArrayList changeList,out ArrayList sucResultList, out ArrayList errResultList,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 成功な登録するデータ
            sucResultList = new ArrayList();

            // 失敗な登録するデータ
            errResultList = new ArrayList();

            ArrayList shipmentChangeWorkList = null;

            Dictionary<string, ArrayList> changeDic = new Dictionary<string, ArrayList>();

            try
            {

                // 伝票番号ようにDictionaryを作成する
                foreach (ShipmentChangeWork shipmentChangeWork in changeList)
                {
                    string key = shipmentChangeWork.SalesSlipNum;
                    if (!changeDic.ContainsKey(key))
                    {
                        shipmentChangeWorkList = new ArrayList();
                        shipmentChangeWorkList.Add(shipmentChangeWork);
                        changeDic.Add(key, shipmentChangeWorkList);
                    }
                    else
                    {
                        changeDic[key].Add(shipmentChangeWork);
                    }
                }

                foreach (string key in changeDic.Keys)
                {
                    ArrayList shipmentChangelist = new ArrayList();
                    shipmentChangelist = changeDic[key];

                    sqlTransaction.Save("shipmentSavePoint");
                    // 貸出データ更新処理
                    status = ShipmentChangeProcProc(ref shipmentChangelist, cndWork.EnterpriseCode, ref sqlConnection, ref sqlTransaction);

                    // 在庫調整データの登録処理
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = WriteToStockAcPayHist(shipmentChangelist, cndWork, ref sqlConnection, ref sqlTransaction);
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 成功メッセージ登録
                        foreach (ShipmentChangeWork successWork in shipmentChangelist)
                        {
                            sucResultList.Add(successWork);
                        }
                    }
                    else
                    {
                        foreach (ShipmentChangeWork errWork in shipmentChangelist)
                        {
                            errResultList.Add(errWork);
                        }
                        sqlTransaction.Rollback("shipmentSavePoint");
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex, "ShipmentChangeDB.ShipmentChangeProc");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された条件の貸出データ更新処理
        /// </summary>
        /// <param name="shipmentChangeList">対象の貸出データ</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private int ShipmentChangeProcProc(ref ArrayList shipmentChangeList, string enterPriseCode, 
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                string errMsg = string.Empty;
                //貸出データ更新処理
                foreach (ShipmentChangeWork shipmentChangeWork in shipmentChangeList)
                {
                    status = this.ChangeSalesDetailProc(shipmentChangeWork, enterPriseCode, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                        || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                    {
                        //errMsg = "排他エラー、品番の変更に失敗しました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        errMsg = GoodsNoChgCommonDB.RENTUPDATEFAIL; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        break;
                    }
                    else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //errMsg = "登録エラー、品番の変更に失敗しました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        errMsg = GoodsNoChgCommonDB.RENTEXCEPTIONMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        break;
                    }
                }

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (ShipmentChangeWork shipmentChangeWork in shipmentChangeList)
                    {
                        shipmentChangeWork.Message = errMsg;
                    }
                }

                return status;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ShipmentChangeDB.ShipmentChangeProcProc");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }

        /// <summary>
        /// 貸出データ更新処理(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="shipmentChangeWork">貸出データ更新情報オブジェクト</param>
        /// <param name="enterPriseCode">enterPriseCode</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note        : 貸出データ更新処理(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        private int ChangeSalesDetailProc(ShipmentChangeWork shipmentChangeWork, string enterPriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string command = string.Empty;

            command = " SELECT " + Environment.NewLine;
            command += " UPDATEDATETIMERF, ENTERPRISECODERF, ACPTANODRSTATUSRF, SALESSLIPDTLNUMRF, LOGICALDELETECODERF FROM SALESDETAILRF WITH (READUNCOMMITTED)" + Environment.NewLine;
            command += "WHERE" + Environment.NewLine;
            command += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            command += " AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS" + Environment.NewLine;
            command += " AND SALESSLIPDTLNUMRF=@FINDSALESSLIPDTLNUM" + Environment.NewLine;

            try
            {
                sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findParaSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(shipmentChangeWork.AcptAnOdrStatus);
                findParaSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(shipmentChangeWork.SalesSlipDtlNum);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != shipmentChangeWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }

                    // 貸出データ更新処理
                    string sqlTxt = "";
                    sqlTxt += " UPDATE SALESDETAILRF SET " + Environment.NewLine;
                    sqlTxt += "   GOODSNORF=@GOODSNORF " + Environment.NewLine;
                    sqlTxt += "   ,PRTGOODSNORF=@PRTGOODSNORF " + Environment.NewLine; // ADD 陳永康 2015/03/02 印刷用品番変換の対応
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                    sqlTxt += "   AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlTxt += "   AND SALESSLIPDTLNUMRF=@FINDSALESSLIPDTLNUM" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                    findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(shipmentChangeWork.AcptAnOdrStatus);
                    findParaSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(shipmentChangeWork.SalesSlipDtlNum);

                    //Parameterオブジェクトの作成(更新用)
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNORF", SqlDbType.NChar);
                    SqlParameter paraPrtGoodsNo = sqlCommand.Parameters.Add("@PRTGOODSNORF", SqlDbType.NChar); // ADD 陳永康 2015/03/02 印刷用品番変換の対応

                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(shipmentChangeWork.NewGoodsNo);
                    paraPrtGoodsNo.Value = SqlDataMediator.SqlSetString(shipmentChangeWork.NewGoodsNo); // ADD 陳永康 2015/03/02 印刷用品番変換の対応
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    return status;
                }

                if (myReader.IsClosed == false) myReader.Close();
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException)
            {
                //基底クラスに例外を渡して処理してもらう
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

            return status;
        }
        #endregion

        #region 在庫調整データの登録処理
        /// <summary>
        /// 在庫調整データの登録処理(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="shipmentChangelist">データ情報オブジェクト</param>
        /// <param name="cndWork">条件ワーク</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note        : 在庫調整データの登録処理(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Note        : Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : 2015/04/17</br>
        /// <br>Note        : リストのNULL、とcountは判断する対応</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : 2015/04/29</br>
        private int WriteToStockAcPayHist(ArrayList shipmentChangelist, GoodsChangeAllCndWorkWork cndWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList stockAcPayHistWorkList = new ArrayList();

            // 売上金額処理区分マスタ読み込み
            List<SalesProcMoneyWork> salesProcMoneyList = new List<SalesProcMoneyWork>();
            status = getSalesProcMoneyList(cndWork, out salesProcMoneyList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                return status;
            }

            // 仕入金額処理区分マスタ読み込み
            List<StockProcMoneyWork> stockProcMoneyList = new List<StockProcMoneyWork>();
            status = getStockProcMoneyList(cndWork, out stockProcMoneyList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                return status;
            }
            for (int i = 0; i < shipmentChangelist.Count; i++)
            {

                //ShipmentChangeWork work = (ShipmentChangeWork)shipmentChangelist[i];// DEL 2015/04/29 時シン リストのNULL、とcountは判断する対応
                //----- ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応------>>>>>
                ShipmentChangeWork work = null;
                if (shipmentChangelist != null && shipmentChangelist.Count > 0)
                {
                    work = (ShipmentChangeWork)shipmentChangelist[i];
                }
                //----- ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応------<<<<<
                //倉庫コードが存在する場合
                if (!string.IsNullOrEmpty(work.WarehouseCode))
                {
                    #region 受払履歴データを追加作成する
                    StockAcPayHistWork counterStockAcPayHistWork = new StockAcPayHistWork();

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)counterStockAcPayHistWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                    counterStockAcPayHistWork.IoGoodsDay = DateTime.Today; // 入出荷日
                    counterStockAcPayHistWork.AddUpADate = DateTime.MinValue; ;  //計上日付
                    counterStockAcPayHistWork.AcPaySlipCd = 22; //受払元伝票区分
                    counterStockAcPayHistWork.AcPaySlipNum = work.SalesSlipNum; //受払元伝票番号
                    counterStockAcPayHistWork.AcPaySlipRowNo = work.SalesRowNo; //受払元行番号
                    counterStockAcPayHistWork.AcPayHistDateTime = DateTime.Now.Ticks; //受払履歴作成日時
                    counterStockAcPayHistWork.AcPayTransCd = 10; //受払元取引区分
                    counterStockAcPayHistWork.InputSectionCd = cndWork.LoginSectionCode; //入力拠点コード
                    counterStockAcPayHistWork.InputSectionGuidNm = cndWork.LoginSectionNm; //入力拠点ガイド名称
                    counterStockAcPayHistWork.InputAgenCd = cndWork.LoginEmpleeCode; //入力担当者コード
                    counterStockAcPayHistWork.InputAgenNm = cndWork.LoginEmpleeName; //入力担当者名称
                    counterStockAcPayHistWork.MoveStatus = 0; //移動状態
                    counterStockAcPayHistWork.CustSlipNo = null; //相手先伝票番号
                    counterStockAcPayHistWork.SlipDtlNum = work.SalesSlipDtlNum; //明細通番
                    counterStockAcPayHistWork.AcPayNote = null; //受払備考
                    counterStockAcPayHistWork.GoodsMakerCd = work.MakerCode; //商品メーカーコード
                    counterStockAcPayHistWork.MakerName = work.MakerName; //メーカー名称
                    counterStockAcPayHistWork.GoodsNo = work.NewGoodsNo; //商品番号
                    counterStockAcPayHistWork.GoodsName = work.GoodsName; //商品名称
                    counterStockAcPayHistWork.BLGoodsCode = work.BLGoodsCode; //BL商品コード
                    counterStockAcPayHistWork.BLGoodsFullName = work.BLGoodsFullName; //BL商品コード名称
                    counterStockAcPayHistWork.SectionCode = work.SectionCode; //拠点コード
                    counterStockAcPayHistWork.SectionGuideNm = work.SectionGuideNm; //拠点ガイド名称
                    counterStockAcPayHistWork.WarehouseCode = work.WarehouseCode; //倉庫コード
                    counterStockAcPayHistWork.WarehouseName = work.WarehouseName; //倉庫名称
                    counterStockAcPayHistWork.ShelfNo = work.WarehouseShelfNo; //棚番
                    counterStockAcPayHistWork.BfSectionCode = null; //移動元拠点コード
                    counterStockAcPayHistWork.BfSectionGuideNm = null; //移動元拠点ガイド名称
                    counterStockAcPayHistWork.BfEnterWarehCode = null; //移動元倉庫コード
                    counterStockAcPayHistWork.BfEnterWarehName = null; //移動元倉庫名称
                    counterStockAcPayHistWork.BfShelfNo = null; //移動元棚番
                    counterStockAcPayHistWork.AfSectionCode = null; //移動先拠点コード
                    counterStockAcPayHistWork.AfSectionGuideNm = null; //移動先拠点ガイド名称
                    counterStockAcPayHistWork.AfEnterWarehCode = null; //移動先倉庫コード
                    counterStockAcPayHistWork.AfEnterWarehName = null;//移動先倉庫名称
                    counterStockAcPayHistWork.AfShelfNo = null; //移動先棚番
                    counterStockAcPayHistWork.CustomerCode = work.CustomerCode; //得意先コード
                    counterStockAcPayHistWork.CustomerSnm = work.CustomerSnm; //得意先略称
                    counterStockAcPayHistWork.SupplierCd = 0; //仕入先コード
                    counterStockAcPayHistWork.SupplierSnm = null; //仕入先略称
                    counterStockAcPayHistWork.ArrivalCnt = 0; //入荷数
                    counterStockAcPayHistWork.ShipmentCnt = work.ShipmentCnt;//出荷数
                    counterStockAcPayHistWork.OpenPriceDiv = work.OpenPriceDiv; //オープン価格区分
                    counterStockAcPayHistWork.ListPriceTaxExcFl = work.ListPriceTaxExcFl; //定価（税抜，浮動）
                    counterStockAcPayHistWork.StockUnitPriceFl = work.SalesUnitCost; //仕入単価（税抜，浮動）
                    counterStockAcPayHistWork.SalesUnPrcTaxExcFl = work.SalesUnPrcTaxExcFl; //売上単価（税抜，浮動）
                    counterStockAcPayHistWork.SupplierStock = work.SupplierStock; //仕入在庫数
                    counterStockAcPayHistWork.AcpOdrCount = work.AcpOdrCount; //受注数
                    counterStockAcPayHistWork.SalesOrderCount = work.SalesOrderCount; //発注数
                    counterStockAcPayHistWork.MovingSupliStock = work.MovingSupliStock; //移動中仕入在庫数
                    counterStockAcPayHistWork.NonAddUpShipmCnt = work.ShipmentNoAddCnt; //出荷数（未計上）
                    counterStockAcPayHistWork.NonAddUpArrGdsCnt = work.ArrivalCnt; //入荷数（未計上）
                    counterStockAcPayHistWork.ShipmentPosCnt = work.ShipmentPosCnt; //出荷可能数
                    counterStockAcPayHistWork.PresentStockCnt = work.ShipmentPosCnt; //現在庫数量

                    //価格再計算
                    this.calculatePrice(cndWork, stockProcMoneyList, salesProcMoneyList, ref work, ref sqlConnection, ref sqlTransaction);
                    counterStockAcPayHistWork.SalesMoney = work.SalesMoneyTaxExc;
                    counterStockAcPayHistWork.StockPrice = work.Cost;

                    stockAcPayHistWorkList.Add(counterStockAcPayHistWork);
                    #endregion
                }
            }

            // 伝票番号毎に受払履歴データを登録する
            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
            try
            {
            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                status = _stockAcPayHistDB.WriteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "WriteStockAcPayHistProc");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<

            string errMsg = string.Empty;
            // エラーログセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                //errMsg = "排他エラー、在庫受払履歴データの登録に失敗しました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                errMsg = GoodsNoChgCommonDB.RENTUPDATEFAIL; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
            }
            else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //errMsg = "登録エラー、在庫受払履歴データの登録に失敗しました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                errMsg = GoodsNoChgCommonDB.RENTEXCEPTIONMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
            }
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (ShipmentChangeWork errWork in shipmentChangelist)
                {
                    errWork.Message = errMsg;
                }
            }

            return status;
        }
        #endregion

        #endregion

        #region WHERE条件文字列生成

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note        : Where句を作成して戻します</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, string enterPriseCode)
        {
            string retstring = "WHERE ";

            //企業コード
            retstring += "SALDTL.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);

            //論理削除区分
            retstring += "AND GDSCHG.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
            retstring += "AND SALDTL.LOGICALDELETECODERF=@FINDLOGICALDELETECODE2 ";
            SqlParameter paraLogicalDeleteCode2 = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE2", SqlDbType.Int);
            paraLogicalDeleteCode2.Value = SqlDataMediator.SqlSetInt32(0);

            //受注ステータス
            retstring += "AND SALDTL.ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS ";
            SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
            paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(40);

            // 受注残数
            retstring += "AND (SALDTL.ACPTANODRREMAINCNTRF > 0 OR  SALDTL.ACPTANODRREMAINCNTRF < 0) ";

            retstring += " ORDER BY SALDTL.GOODSMAKERCDRF, SALDTL.GOODSNORF ";
            return retstring;
        }

        #endregion

        #region クラス格納処理
        /// <summary>
        /// クラス格納処理 Reader → ShipmentChangeWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="shipmentChangeWork">ShipmentChangeWork</param>
        /// <returns>RateWork</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private void CopyToWorkFromReader(ref SqlDataReader myReader, out ShipmentChangeWork shipmentChangeWork)
        {
            shipmentChangeWork = new ShipmentChangeWork();
            #region クラスへ格納
            shipmentChangeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF")); // 更新日時
            shipmentChangeWork.NewGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF")); // 変換後商品番号 
            shipmentChangeWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); // 商品メーカーコード
            shipmentChangeWork.OldGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF")); // 商品番号
            shipmentChangeWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF")); // 受注ステータス
            shipmentChangeWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF")); // 売上伝票番号
            shipmentChangeWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF")); // 売上行番号
            shipmentChangeWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF")); // 売上明細通番
            shipmentChangeWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF")); // メーカー名称
            shipmentChangeWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF")); // 商品名称
            shipmentChangeWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // BL商品コード
            shipmentChangeWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF")); // BL商品コード名称
            shipmentChangeWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF")); // 受注残数
            shipmentChangeWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF")); // オープン価格区分
            shipmentChangeWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF")); // 定価（税抜，浮動）
            shipmentChangeWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF")); // 原価単価
            shipmentChangeWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF")); // 売上単価（税抜，浮動）
            shipmentChangeWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF")); // 仕入先コード
            shipmentChangeWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF")); // 得意先コード
            shipmentChangeWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF")); // 得意先略称
            shipmentChangeWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF")); // 倉庫コード
            shipmentChangeWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF")); // 倉庫名称
            shipmentChangeWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF")); // 倉庫棚番
            shipmentChangeWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF")); // 拠点コード
            shipmentChangeWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF")); // 拠点ガイド名称
            string WarehouseCodeNew = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODENEWRF")); // 倉庫コード
            string WarehouseCodeOld = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODEOLDRF")); // 倉庫コード
            if (!string.IsNullOrEmpty(WarehouseCodeNew))
            {
                shipmentChangeWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF")); // 仕入在庫数(新品番)
                shipmentChangeWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF")); // 受注数(新品番)
                shipmentChangeWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF")); // 発注数(新品番)
                shipmentChangeWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF")); // 移動中仕入在庫数(新品番)
                shipmentChangeWork.ShipmentNoAddCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTNOADDRF")); // 出荷数（未計上）(新品番)
                shipmentChangeWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF")); // 入荷数（未計上）(新品番)
                shipmentChangeWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF")); // 出荷可能数(新品番)
            }
            else if (!string.IsNullOrEmpty(WarehouseCodeOld))
            {
                shipmentChangeWork.ShipmentNoAddCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTNOADDOLDRF")); // 出荷数（未計上）(旧商品)
                shipmentChangeWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTOLDRF")); // 出荷可能数(旧商品)
                shipmentChangeWork.SupplierStock = shipmentChangeWork.ShipmentNoAddCnt + shipmentChangeWork.ShipmentPosCnt;
            }
            else
            {
                //なし
            }
            #endregion
        }
        #endregion

        #region 価格再計算
        /// <summary>
        /// 価格再計算処理
        /// </summary>
        /// <param name="cndtn">条件ワーク</param>
        /// <param name="_stockProcMoneyList">仕入金額処理区分データ</param>
        /// <param name="_salesProcMoneyList">売上金額処理区分データ</param>
        /// <param name="work">受払履歴データ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 価格再計算処理</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void calculatePrice(GoodsChangeAllCndWorkWork cndtn, List<StockProcMoneyWork> _stockProcMoneyList, List<SalesProcMoneyWork> _salesProcMoneyList, ref ShipmentChangeWork work, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int salesProcCd = 0;
            double salesProcUnit = 0;
            int costProcCd = 0;
            double costProcUnit = 0;
            long afterSales = 0;
            long afterCost = 0;

            double salesUnitCost = work.SalesUnitCost * work.ShipmentCnt; //原価金額
            double salesUnPrcTaxExcFl = work.SalesUnPrcTaxExcFl * work.ShipmentCnt; //売上金額

            // 売上金額端数処理コード
            int salesFrcProcCd = this.GetSalesFractionProcCd(cndtn.EnterpriseCode, work.CustomerCode);
            // 原価金額端数処理コード
            int costFrcProcCd = this.GetCostFractionProcCd(cndtn.EnterpriseCode, work.SupplierCd, ref sqlConnection, ref sqlTransaction);

            // 売上金額端数処理単位、端数処理区分取得
            this.GetSalesFractionProcInfo(0, salesFrcProcCd, (double)salesUnPrcTaxExcFl, _salesProcMoneyList, out salesProcUnit, out salesProcCd);

            // 原価金額端数処理単位、端数処理区分取得
            this.GetStockFractionProcInfo(0, costFrcProcCd, (double)salesUnitCost, _stockProcMoneyList, out costProcUnit, out costProcCd);

            // 売上金額端数処理
            FractionCalculate.FracCalcMoney(salesUnPrcTaxExcFl, salesProcUnit, salesProcCd, out afterSales);
            // 原価金額端数処理
            FractionCalculate.FracCalcMoney(salesUnitCost, costProcUnit, costProcCd, out afterCost);

            work.SalesMoneyTaxExc = afterSales;
            work.Cost = afterCost;
        }

        #region 売上金額
        /// <summary>
        /// 売上金額処理区分マスタ読み込み
        /// </summary>
        /// <param name="cndtn">貸出データ</param>
        /// <param name="salesProcMoneyList"></param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 金額処理区分マスタ読み込み</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private int getSalesProcMoneyList(GoodsChangeAllCndWorkWork cndtn, out List<SalesProcMoneyWork> salesProcMoneyList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            salesProcMoneyList = new List<SalesProcMoneyWork>();

            SalesProcMoneyDB salesProcMoneyDB = new SalesProcMoneyDB();

            SalesProcMoneyWork paraWork = new SalesProcMoneyWork();
            paraWork.EnterpriseCode = cndtn.EnterpriseCode;
            paraWork.FracProcMoneyDiv = -1;
            paraWork.FractionProcCode = -1;

            ArrayList paraList = new ArrayList();
            paraList.Add(paraWork);
            object paraObj = paraList;

            object retobj = null;

            status = salesProcMoneyDB.Search(out retobj, paraObj, 0, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList list = retobj as ArrayList;

                salesProcMoneyList.AddRange((SalesProcMoneyWork[])list.ToArray(typeof(SalesProcMoneyWork)));

                salesProcMoneyList.Sort(new SalesProcMoneyComparer());
            }
            return status;
        }

        /// <summary>
        /// 売上金額処理区分設定マスタより、対象金額に該当する端数処理単位、端数処理コードを取得します。
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="price">対象金額</param>
        /// <param name="_salesProcMoneyList">売上金額処理区分設定マスタ</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// <remarks>
        /// <br>Note       : 金額処理区分マスタ読み込み</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double price, List<SalesProcMoneyWork> _salesProcMoneyList, out double fractionProcUnit, out int fractionProcCd)
        {
            fractionProcUnit = 1;   // 単価以外は1円単位
            fractionProcCd = 1;     // 切捨て

            if (_salesProcMoneyList == null || _salesProcMoneyList.Count == 0) return;

            List<SalesProcMoneyWork> salesProcMoneyList = _salesProcMoneyList.FindAll(
                                        delegate(SalesProcMoneyWork salesProcMoney)
                                        {
                                            if ((salesProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                                                (salesProcMoney.FractionProcCode == fractionProcCode) &&
                                                (salesProcMoney.UpperLimitPrice >= price))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (salesProcMoneyList != null && salesProcMoneyList.Count > 0)
            {
                fractionProcUnit = salesProcMoneyList[0].FractionProcUnit;
                fractionProcCd = salesProcMoneyList[0].FractionProcCd;
            }
        }

        /// <summary>
        /// 売上金額処理区分マスタデータ比較クラス(端数処理対象金額(昇順)、端数処理コード(昇順)、上限金額(昇順))
        /// </summary>
        /// <remarks></remarks>
        private class SalesProcMoneyComparer : Comparer<SalesProcMoneyWork>
        {

            public override int Compare(SalesProcMoneyWork x, SalesProcMoneyWork y)
            {
                int result = x.FracProcMoneyDiv.CompareTo(y.FracProcMoneyDiv);
                if (result != 0) return result;

                result = x.FractionProcCode.CompareTo(y.FractionProcCode);
                if (result != 0) return result;

                result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        /// <summary>
        /// 売上金額端数処理コードを取得します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="customerCode">仕入先コード</param>
        /// <remarks>
        /// <br>Note       : 売上金額端数処理コードを取得します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>Note       : Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/04/17</br>
        /// </remarks>
        private int GetSalesFractionProcCd(string enterpriseCode, int customerCode)
        {
            int salesFrcProcCd = 0;
            CustomerWork customerWork = new CustomerWork();
            customerWork.EnterpriseCode = enterpriseCode;
            customerWork.CustomerCode = customerCode;

            CustomSerializeArrayList paraCustomerArray = new CustomSerializeArrayList();
            paraCustomerArray.Add(customerWork);
            object paraList = paraCustomerArray;

            //int status = _customerDB.Read(0, ref paraList); // DEL 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応
            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = _customerDB.Read(0, ref paraList);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "Read");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CustomSerializeArrayList retCustomerArrayList = paraList as CustomSerializeArrayList;
                foreach (object obj in retCustomerArrayList)
                {
                    if (obj is CustomerWork)
                    {
                        customerWork = (CustomerWork)obj;
                        salesFrcProcCd = customerWork.SalesMoneyFrcProcCd;
                    }
                }
            }

            return salesFrcProcCd;
        }
        #endregion

        #region 原価金額
        /// <summary>
        /// 仕入金額処理区分マスタ読み込み
        /// </summary>
        /// <param name="cndtn">貸出データ</param>
        /// <param name="stockProcMoneyList"></param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 金額処理区分マスタ読み込み</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private int getStockProcMoneyList(GoodsChangeAllCndWorkWork cndtn, out List<StockProcMoneyWork> stockProcMoneyList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            stockProcMoneyList = new List<StockProcMoneyWork>();

            StockProcMoneyDB stockProcMoneyDB = new StockProcMoneyDB();

            StockProcMoneyWork paraWork = new StockProcMoneyWork();
            paraWork.EnterpriseCode = cndtn.EnterpriseCode;
            paraWork.FracProcMoneyDiv = -1;
            paraWork.FractionProcCode = -1;

            ArrayList paraList = new ArrayList();
            paraList.Add(paraWork);

            object retobj = null;

            status = stockProcMoneyDB.Search(out retobj, paraList, 0, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList list = retobj as ArrayList;

                stockProcMoneyList.AddRange((StockProcMoneyWork[])list.ToArray(typeof(StockProcMoneyWork)));

                stockProcMoneyList.Sort(new StockProcMoneyComparer());
            }
            return status;
        }

        /// <summary>
        /// 仕入金額処理区分設定マスタより、対象金額に該当する端数処理単位、端数処理コードを取得します。
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="price">対象金額</param>
        /// <param name="_stockProcMoneyList">仕入金額処理区分設定マスタ</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// <remarks>
        /// <br>Note       : 金額処理区分マスタ読み込み</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void GetStockFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double price, List<StockProcMoneyWork> _stockProcMoneyList, out double fractionProcUnit, out int fractionProcCd)
        {
            fractionProcUnit = 1;   // 単価以外は1円単位
            fractionProcCd = 1;     // 切捨て

            if (_stockProcMoneyList == null || _stockProcMoneyList.Count == 0) return;

            List<StockProcMoneyWork> stockProcMoneyList = _stockProcMoneyList.FindAll(
                                        delegate(StockProcMoneyWork stockProcMoney)
                                        {
                                            if ((stockProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                                                (stockProcMoney.FractionProcCode == fractionProcCode) &&
                                                (stockProcMoney.UpperLimitPrice >= price))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (stockProcMoneyList != null && stockProcMoneyList.Count > 0)
            {
                fractionProcUnit = stockProcMoneyList[0].FractionProcUnit;
                fractionProcCd = stockProcMoneyList[0].FractionProcCd;
            }
        }

        /// <summary>
        /// 仕入金額処理区分マスタデータ比較クラス(端数処理対象金額(昇順)、端数処理コード(昇順)、上限金額(昇順))
        /// </summary>
        /// <remarks></remarks>
        private class StockProcMoneyComparer : Comparer<StockProcMoneyWork> 
        {

            public override int Compare(StockProcMoneyWork x, StockProcMoneyWork y)
            {
                int result = x.FracProcMoneyDiv.CompareTo(y.FracProcMoneyDiv);
                if (result != 0) return result;

                result = x.FractionProcCode.CompareTo(y.FractionProcCode);
                if (result != 0) return result;

                result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        /// <summary>
        /// 原価金額端数処理コードを取得します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <remarks>
        /// <br>Note       : 原価金額端数処理コードを取得します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>Note       : Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/04/17</br>
        /// </remarks>
        private int GetCostFractionProcCd(string enterpriseCode, int supplierCd, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int costFrcProcCd = 0;
            if (supplierCd != 0)
            {
                SupplierWork supplierWork = new SupplierWork();
                supplierWork.EnterpriseCode = enterpriseCode;
                supplierWork.SupplierCd = supplierCd;

                //int status = _supplierDB.Read(ref supplierWork, 0, ref sqlConnection, ref sqlTransaction); // DEL 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応
                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                try
                {
                    status = _supplierDB.Read(ref supplierWork, 0, ref sqlConnection, ref sqlTransaction);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "Read");
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    costFrcProcCd = supplierWork.StockMoneyFrcProcCd;
                }
            }
            return costFrcProcCd;
        }
        #endregion
        
        #endregion

        #endregion

    }
}
