//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫移動電子元帳
// プログラム概要   : 在庫移動電子元帳 リモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 作 成 日  2011/04/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱俊成
// 作 成 日  2011/05/20  修正内容 : Redmine#21657 仕入先と仕入先名を追加します
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
using Broadleaf.Library.Globarization;
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫移動電子元帳 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫移動電子元帳 リモートオブジェクトです。</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2011/04/06</br>
    /// </remarks>
    [Serializable]
    public class StockMoveWorkDB : RemoteDB, IStockMoveWorkDB
    {
        /// <summary>
        /// 在庫移動電子元帳 リモートオブジェクトクラスコンストラクタ
        /// </summary>
        public StockMoveWorkDB()
            :
            base("PMZAI04616D", "Broadleaf.Application.Remoting.ParamData.StockMoveWork", "STOCKMOVERF")
        {
        }

        #region [明細表示検索]

        #region [SearchRef]
        /// <summary>
        /// 指定された検索条件に該当する表示のリストを抽出します
        /// </summary>
        /// <param name="stockMoveWork">検索結果(売上データ)</param>
        /// <param name="stockMovePrtWork">検索パラメータ</param>
        /// <param name="recordCount">検索結果(件数)</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: </br>
        /// <remarks>
        /// <br>Note       : 指定された検索条件に該当する表示のリストを抽出します。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/20 朱俊成 仕入先と仕入先名を追加します</br>
        /// </remarks>
        public int SearchRef(ref object stockMoveWork, object stockMovePrtWork, out Int64 recordCount, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            //初期化
            recordCount = 0;
            Int64 iRecCnt = 0;
            stockMoveWork = null;

            try
            {
                //パラメータチェック
                if (stockMovePrtWork == null) return status;

                #region [パラメータのキャスト]
                //検索パラメータ
                StockMovePrtWork _stockMovePrtWork = stockMovePrtWork as StockMovePrtWork;
                ArrayList stockMoveWorkArray = stockMoveWork as ArrayList;
                if (stockMoveWorkArray == null)
                {
                    stockMoveWorkArray = new ArrayList();
                }
                #endregion

                //コネクション生成
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //Search実行
                #region [在庫移動データ検索]

                //在庫移動データ検索
                status = SearchRefProc(ref stockMoveWorkArray, _stockMovePrtWork, out recordCount, iRecCnt, readMode, logicalMode, ref sqlConnection);
                if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                {
                    //実行時エラー
                    throw new Exception("検索実行時エラー：Status=" + status.ToString());
                }
                #endregion

                //実行結果セット
                stockMoveWork = stockMoveWorkArray;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveWorkDB.SearchProc Exception=" + ex.Message);
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
        #endregion  //[SearchRef]

        #region [SearchRefProc]
        /// <summary>
        /// 指定された検索条件に該当する表示データのリストを抽出します
        /// </summary>
        /// <param name="rsltWorkArray">検索結果(売上データ)</param>
        /// <param name="_stockMovePrtWork">検索パラメータ</param>
        /// <param name="recordCount">検索結果(件数)戻り値用</param>
        /// <param name="iRecCnt">検索結果(件数)内部チェック用</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br></br>
        /// <remarks>
        /// <br>Note       : 指定された検索条件に該当する表示データのリストを抽出します。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        /// </remarks>
        private int SearchRefProc(ref ArrayList rsltWorkArray, StockMovePrtWork _stockMovePrtWork, out Int64 recordCount, Int64 iRecCnt, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT文生成
                sqlCommand.CommandText = MakeSelectString(ref sqlCommand, _stockMovePrtWork, logicalMode);

                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                //件数チェック
                while (myReader.Read())
                {
                    object retWork = CopyToResultWorkFromReaderProc(ref myReader, _stockMovePrtWork);
                    if (retWork != null)
                    {
                        rsltWorkArray.Add(retWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                        iRecCnt++;
                        if (iRecCnt >= _stockMovePrtWork.SearchCnt)
                        {
                            //検索上限オーバーの場合はBreak
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            recordCount = iRecCnt;
                            break;
                        }
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
                base.WriteErrorLog(ex, "StockMoveWorkDB.SearchRefProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                    myReader = null;
                }
            }
            recordCount = iRecCnt;

            return status;
        }
        #endregion  //[SearchRefProc]

        #endregion  //明細表示検索]

        #region [StockMoveWork用 SELECT文]
        /// <summary>
        /// リスト抽出クエリ作成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>リスト抽出SELECT文</returns>
        /// <remarks>
        /// <br>Note       : リスト抽出クエリ作成。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        /// </remarks>
        public string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            StockMovePrtWork _ctockMoveWork = paramWork as StockMovePrtWork;
            string selectTxt = "";

            // 対象テーブル
            // STOCKMOVERF  STOCK  在庫移動データ
            #region [Select文作成]
            selectTxt += "  SELECT TOP " + _ctockMoveWork.SearchCnt + Environment.NewLine; // 検索上限件数を超えるまで取得
            selectTxt += "STOCK.STOCKMOVEFORMALRF" + Environment.NewLine;        // 在庫移動形式
            selectTxt += " ,STOCK.STOCKMOVESLIPNORF" + Environment.NewLine;        // 在庫移動伝票番号
            selectTxt += " ,STOCK.STOCKMOVEROWNORF" + Environment.NewLine;         // 在庫移動行番号
            selectTxt += " ,STOCK.UPDATESECCDRF" + Environment.NewLine;            // 更新拠点コード
            selectTxt += " ,STOCK.BFSECTIONCODERF" + Environment.NewLine;          // 移動元拠点コード
            selectTxt += " ,STOCK.BFSECTIONGUIDESNMRF" + Environment.NewLine;      // 移動元拠点ガイド略称
            selectTxt += " ,STOCK.BFENTERWAREHCODERF" + Environment.NewLine;       // 移動元倉庫コード
            selectTxt += " ,STOCK.BFENTERWAREHNAMERF" + Environment.NewLine;       // 移動元倉庫名称
            selectTxt += " ,STOCK.AFSECTIONCODERF" + Environment.NewLine;          // 移動先拠点コード
            selectTxt += " ,STOCK.AFSECTIONGUIDESNMRF" + Environment.NewLine;      // 移動先拠点ガイド略称
            selectTxt += " ,STOCK.AFENTERWAREHCODERF" + Environment.NewLine;       // 移動先倉庫コード
            selectTxt += " ,STOCK.AFENTERWAREHNAMERF" + Environment.NewLine;       // 移動先倉庫名称
            selectTxt += " ,STOCK.SHIPMENTFIXDAYRF" + Environment.NewLine;         // 出荷確定日
            selectTxt += " ,STOCK.ARRIVALGOODSDAYRF" + Environment.NewLine;        // 入荷日
            selectTxt += " ,STOCK.INPUTDAYRF" + Environment.NewLine;               // 入力日
            selectTxt += " ,STOCK.MOVESTATUSRF" + Environment.NewLine;             // 移動状態
            selectTxt += " ,STOCK.STOCKMVEMPNAMERF" + Environment.NewLine;         // 在庫移動入力従業員名称
            selectTxt += " ,STOCK.RECEIVEAGENTNMRF" + Environment.NewLine;         // 引取担当従業員名称
            selectTxt += " ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;           // 商品メーカーコード
            selectTxt += " ,STOCK.MAKERNAMERF" + Environment.NewLine;              // メーカー名称
            selectTxt += " ,STOCK.GOODSNORF" + Environment.NewLine;                // 商品番号
            selectTxt += " ,STOCK.GOODSNAMERF" + Environment.NewLine;              // 商品名称
            selectTxt += " ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;       // 仕入単価（税抜,浮動）
            selectTxt += " ,STOCK.MOVECOUNTRF" + Environment.NewLine;              // 移動数
            selectTxt += " ,STOCK.BFSHELFNORF" + Environment.NewLine;              // 移動元棚番
            selectTxt += " ,STOCK.AFSHELFNORF" + Environment.NewLine;              // 移動先棚番
            selectTxt += " ,STOCK.BLGOODSCODERF" + Environment.NewLine;            // BL商品コード
            selectTxt += " ,STOCK.LISTPRICEFLRF" + Environment.NewLine;            // 定価（浮動）
            selectTxt += " ,STOCK.OUTLINERF" + Environment.NewLine;                // 伝票摘要
            selectTxt += " ,STOCK.STOCKMOVEPRICERF" + Environment.NewLine;         // 移動金額
            // ADD 2011/05/20 -------------------->>>>>>
            selectTxt += " ,STOCK.SUPPLIERCDRF" + Environment.NewLine;           // 仕入先コード
            selectTxt += " ,STOCK.SUPPLIERSNMRF" + Environment.NewLine;              // 仕入先名
            // ADD 2011/05/20 --------------------<<<<<<
            selectTxt += " ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;           // 拠点ガイド名称
            selectTxt += " FROM STOCKMOVERF AS STOCK  WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 拠点情報設定マスタ.拠点ガイド名称を取得する
            selectTxt += " LEFT JOIN  SECINFOSETRF AS SEC" + Environment.NewLine;
            selectTxt += " ON " + Environment.NewLine;
            selectTxt += " STOCK.ENTERPRISECODERF = SEC.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += " AND STOCK.UPDATESECCDRF = SEC.SECTIONCODERF " + Environment.NewLine;
            selectTxt += " AND SEC.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            //WHERE文の作成
            selectTxt += MakeWhereString(ref sqlCommand, _ctockMoveWork, logicalMode);

            selectTxt += "  ORDER BY  " + Environment.NewLine;
            // 入出荷/伝票日付,移動伝票番号
            if (_ctockMoveWork.StockMoveFixCode == 1)
            {
                if (_ctockMoveWork.OutputDiv == 0 || _ctockMoveWork.OutputDiv == 2)
                {
                    selectTxt += " SHIPMENTFIXDAYRF ASC" + Environment.NewLine;
                }
                else
                {
                    selectTxt += " ARRIVALGOODSDAYRF ASC" + Environment.NewLine;
                }
            }
            else
            {
                selectTxt += " ARRIVALGOODSDAYRF ASC" + Environment.NewLine;
            }
            selectTxt += " , STOCKMOVESLIPNORF ASC" + Environment.NewLine;
            #endregion

            return selectTxt;
        }
        #endregion

        #region [StockMoveWork用 WHERE文生成処理]
        private string MakeWhereString(ref SqlCommand sqlCommand, StockMovePrtWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " STOCK.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //売上伝票番号
            if (paramWork.SalesSlipNum != "")
            {
                retstring += " AND STOCK.STOCKMOVESLIPNORF >=@FINDSALESSLIPNUM" + Environment.NewLine;
                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(paramWork.SalesSlipNum);
            }

            //入力日付(伝票検索日付)
            if (paramWork.St_AddUpADate != DateTime.MinValue)
            {
                retstring += " AND STOCK.INPUTDAYRF>=@STSEARCHSLIPDATE" + Environment.NewLine;
                SqlParameter paraStAddUpADate = sqlCommand.Parameters.Add("@STSEARCHSLIPDATE", SqlDbType.Int);
                paraStAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_AddUpADate);
            }
            if (paramWork.Ed_AddUpADate != DateTime.MinValue)
            {
                retstring += " AND STOCK.INPUTDAYRF<=@EDSEARCHSLIPDATE" + Environment.NewLine;
                SqlParameter paraEdAddUpADate = sqlCommand.Parameters.Add("@EDSEARCHSLIPDATE", SqlDbType.Int);
                paraEdAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_AddUpADate);
            }

            //仕入先(仕入先コード)
            if (paramWork.SupplierCd != 0)
            {
                retstring += " AND STOCK.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SupplierCd);
            }

            //品名(商品名称) ※あいまい検索あり
            if (paramWork.GoodsName != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.GoodsName, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring += " AND STOCK.GOODSNAMERF LIKE @FINDGOODSNAME" + Environment.NewLine;

                }
                else
                {
                    //あいまい検索じゃない
                    retstring += " AND STOCK.GOODSNAMERF=@FINDGOODSNAME" + Environment.NewLine;
                }
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAME", SqlDbType.NVarChar);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(paramWork.GoodsName);
            }

            //品番(商品番号) ※あいまい検索あり
            if (paramWork.GoodsNo != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.GoodsNo, "(%)").Success == true)
                {
                    //あいまい検索
                    if (paramWork.GoodsNo.Contains("-"))
                    {
                        retstring += " AND STOCK.GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND REPLACE (STOCK.GOODSNORF, '-', '') LIKE @FINDGOODSNO" + Environment.NewLine;
                    }
                }
                else
                {
                    //あいまい検索じゃない
                    if (paramWork.GoodsNo.Contains("-"))
                    {
                        retstring += " AND STOCK.GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND REPLACE (STOCK.GOODSNORF, '-', '') = @FINDGOODSNO" + Environment.NewLine;
                    }
                }
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(paramWork.GoodsNo);
            }

            //メーカー(商品メーカーコード)
            if (paramWork.GoodsMakerCd != 0)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCd);
            }

            //ＢＬコード(BL商品コード)
            if (paramWork.BLGoodsCode != 0)
            {
                retstring += " AND STOCK.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGoodsCode);
            }

            //明細備考 ※あいまい検索あり
            if (paramWork.SlipNote != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SlipNote, "(%)").Success == true)
                {
                    retstring += " AND STOCK.OUTLINERF LIKE @FINDDTLNOTE" + Environment.NewLine;
                }
                else
                {
                    //あいまい検索じゃない
                    retstring += " AND STOCK.OUTLINERF=@FINDDTLNOTE" + Environment.NewLine;
                }
                SqlParameter paraDtlNote = sqlCommand.Parameters.Add("@FINDDTLNOTE", SqlDbType.NVarChar);
                paraDtlNote.Value = SqlDataMediator.SqlSetString(paramWork.SlipNote);
            }

            // 出力区分の場合
            if (paramWork.StockMoveFixCode == 1)
            {
                // 在庫移動形式
                retstring += " AND (STOCK.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL1" + Environment.NewLine;
                retstring += " OR STOCK.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL2)" + Environment.NewLine;
                SqlParameter paraStockMoveFormal1 = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL1", SqlDbType.Int);
                SqlParameter paraStockMoveFormal2 = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL2", SqlDbType.Int);
                if (paramWork.OutputDiv == 0)
                {
                    // 出荷分
                    paraStockMoveFormal1.Value = SqlDataMediator.SqlSetInt(1);
                    paraStockMoveFormal2.Value = SqlDataMediator.SqlSetInt(2);

                    // 移動元拠点コード
                    if (!string.IsNullOrEmpty(paramWork.SectionCode))
                    {
                        retstring += " AND STOCK.BFSECTIONCODERF=@FINDBFSECTIONCODE" + Environment.NewLine;
                        SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@FINDBFSECTIONCODE", SqlDbType.NChar);
                        // 出荷分 出庫拠点
                        paraBfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                    }

                    // 移動元倉庫コード
                    if (!string.IsNullOrEmpty(paramWork.WarehouseCode))
                    {
                        retstring += " AND STOCK.BFENTERWAREHCODERF=@FINDBFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@FINDBFENTERWAREHCODE", SqlDbType.NChar);
                        // 出庫倉庫
                        paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
                    }

                    // 移動先拠点コード
                    if (!string.IsNullOrEmpty(paramWork.AfSectionCode))
                    {
                        retstring += " AND STOCK.AFSECTIONCODERF=@FINDAFSECTIONCODE" + Environment.NewLine;
                        SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@FINDAFSECTIONCODE", SqlDbType.NChar);
                        //相手倉庫
                        paraAfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.AfSectionCode);
                    }
                    // 移動先倉庫コード
                    if (!string.IsNullOrEmpty(paramWork.AfEnterWarehCode))
                    {
                        retstring += " AND STOCK.AFENTERWAREHCODERF=@FINDAFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@FINDAFENTERWAREHCODE", SqlDbType.NChar);
                        //相手倉庫
                        paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.AfEnterWarehCode);
                    }
                    // 出荷確定日
                    if (paramWork.St_Date != DateTime.MinValue)
                    {
                        retstring += " AND STOCK.SHIPMENTFIXDAYRF>=@FINDSHIPMENTFIXDAYST" + Environment.NewLine;
                        SqlParameter paraShipmentFixDaySt = sqlCommand.Parameters.Add("@FINDSHIPMENTFIXDAYST", SqlDbType.Int);
                        //入出荷日(開始)
                        paraShipmentFixDaySt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_Date);
                    }
                    if (paramWork.Ed_Date != DateTime.MinValue)
                    {
                        retstring += " AND STOCK.SHIPMENTFIXDAYRF<=@FINDSHIPMENTFIXDAYED" + Environment.NewLine;
                        SqlParameter paraShipmentFixDayEd = sqlCommand.Parameters.Add("@FINDSHIPMENTFIXDAYED", SqlDbType.Int);
                        //入出荷日(終了)
                        paraShipmentFixDayEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_Date);
                    }
                    // 入荷区分arrivalGoodsFlag
                    if (paramWork.ArrivalGoodsFlag != 0)
                    {
                        retstring += " AND STOCK.MOVESTATUSRF =@FINDMOVESTATUS" + Environment.NewLine;
                        SqlParameter paraMoveStatus = sqlCommand.Parameters.Add("@FINDMOVESTATUS", SqlDbType.Int);
                        // 移動状態
                        if (paramWork.ArrivalGoodsFlag == 1)
                        {
                            paraMoveStatus.Value = SqlDataMediator.SqlSetInt(9);
                        }
                        else
                        {
                            paraMoveStatus.Value = SqlDataMediator.SqlSetInt(2);
                        }
                    }
                    // 在庫移動入力従業員コード
                    if (!string.IsNullOrEmpty(paramWork.SalesEmployeeCd))
                    {
                        retstring += " AND STOCK.STOCKMVEMPCODERF=@FINDSTOCKMVEMPCODE" + Environment.NewLine;
                        SqlParameter paraStockMvEmpCode = sqlCommand.Parameters.Add("@FINDSTOCKMVEMPCODE", SqlDbType.NChar);
                        //相手倉庫
                        paraStockMvEmpCode.Value = SqlDataMediator.SqlSetString(paramWork.SalesEmployeeCd);
                    }

                    // 棚番 移動元棚番
                    if (paramWork.WarehouseShelfNo != string.Empty)
                    {
                        //あいまい検索かどうかをチェック
                        if (System.Text.RegularExpressions.Regex.Match(paramWork.WarehouseShelfNo, "(%)").Success == true)
                        {
                            //あいまい検索
                            retstring += " AND STOCK.BFSHELFNORF LIKE @FINDWAREHOUSESHELFNO" + Environment.NewLine;
                        }
                        else
                        {
                            //あいまい検索じゃない
                            retstring += " AND STOCK.BFSHELFNORF=@FINDWAREHOUSESHELFNO" + Environment.NewLine;
                        }
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseShelfNo);
                    }
                }
                else if (paramWork.OutputDiv == 1)
                {
                    // 入荷済分
                    paraStockMoveFormal1.Value = SqlDataMediator.SqlSetInt(3);
                    paraStockMoveFormal2.Value = SqlDataMediator.SqlSetInt(4);

                    // 移動元拠点コード
                    if (!string.IsNullOrEmpty(paramWork.AfSectionCode))
                    {
                        retstring += " AND STOCK.BFSECTIONCODERF=@FINDBFSECTIONCODE" + Environment.NewLine;
                        SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@FINDBFSECTIONCODE", SqlDbType.NChar);
                        // 相手拠点
                        paraBfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.AfSectionCode);
                    }

                    // 移動元倉庫コード
                    if (!string.IsNullOrEmpty(paramWork.AfEnterWarehCode))
                    {
                        retstring += " AND STOCK.BFENTERWAREHCODERF=@FINDBFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@FINDBFENTERWAREHCODE", SqlDbType.NChar);
                        //相手倉庫
                        paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.AfEnterWarehCode);
                    }
                    // 移動先拠点コード
                    if (!string.IsNullOrEmpty(paramWork.SectionCode))
                    {
                        retstring += " AND STOCK.AFSECTIONCODERF=@FINDAFSECTIONCODE" + Environment.NewLine;
                        SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@FINDAFSECTIONCODE", SqlDbType.NChar);
                        //入庫拠点
                        paraAfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                    }
                    // 移動先倉庫コード
                    if (!string.IsNullOrEmpty(paramWork.WarehouseCode))
                    {
                        retstring += " AND STOCK.AFENTERWAREHCODERF=@FINDAFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@FINDAFENTERWAREHCODE", SqlDbType.NChar);
                        //入庫倉庫
                        paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
                    }
                    // 入荷日
                    if (paramWork.St_Date != DateTime.MinValue)
                    {
                        retstring += " AND STOCK.ARRIVALGOODSDAYRF>=@FINDSHIPMENTFIXDAYST" + Environment.NewLine;
                        SqlParameter paraShipmentFixDaySt = sqlCommand.Parameters.Add("@FINDSHIPMENTFIXDAYST", SqlDbType.Int);
                        //入出荷日(開始)
                        paraShipmentFixDaySt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_Date);
                    }
                    if (paramWork.Ed_Date != DateTime.MinValue)
                    {
                        retstring += " AND STOCK.ARRIVALGOODSDAYRF<=@FINDSHIPMENTFIXDAYED" + Environment.NewLine;
                        SqlParameter paraShipmentFixDayEd = sqlCommand.Parameters.Add("@FINDSHIPMENTFIXDAYED", SqlDbType.Int);
                        //入出荷日(終了)
                        paraShipmentFixDayEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_Date);
                    }
                    // 引取担当従業員コード
                    if (!string.IsNullOrEmpty(paramWork.SalesEmployeeCd))
                    {
                        retstring += " AND STOCK.RECEIVEAGENTCDRF=@FINDSTOCKMVEMPCODE" + Environment.NewLine;
                        SqlParameter paraStockMvEmpCode = sqlCommand.Parameters.Add("@FINDSTOCKMVEMPCODE", SqlDbType.NChar);
                        // 担当者
                        paraStockMvEmpCode.Value = SqlDataMediator.SqlSetString(paramWork.SalesEmployeeCd);
                    }
                    // 棚番 移動先棚番
                    if (paramWork.WarehouseShelfNo != string.Empty)
                    {
                        //あいまい検索かどうかをチェック
                        if (System.Text.RegularExpressions.Regex.Match(paramWork.WarehouseShelfNo, "(%)").Success == true)
                        {
                            //あいまい検索
                            retstring += " AND STOCK.AFSHELFNORF LIKE @FINDWAREHOUSESHELFNO" + Environment.NewLine;
                        }
                        else
                        {
                            //あいまい検索じゃない
                            retstring += " AND STOCK.AFSHELFNORF=@FINDWAREHOUSESHELFNO" + Environment.NewLine;
                        }
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseShelfNo);
                    }
                }
                else
                {
                    //未入荷分
                    paraStockMoveFormal1.Value = SqlDataMediator.SqlSetInt(1);
                    paraStockMoveFormal2.Value = SqlDataMediator.SqlSetInt(2);

                    // 移動元拠点コード
                    if (!string.IsNullOrEmpty(paramWork.AfSectionCode))
                    {
                        retstring += " AND STOCK.BFSECTIONCODERF=@FINDBFSECTIONCODE" + Environment.NewLine;
                        SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@FINDBFSECTIONCODE", SqlDbType.NChar);
                        // 相手拠点
                        paraBfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.AfSectionCode);
                    }

                    // 移動元倉庫コード
                    if (!string.IsNullOrEmpty(paramWork.AfEnterWarehCode))
                    {
                        retstring += " AND STOCK.BFENTERWAREHCODERF=@FINDBFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@FINDBFENTERWAREHCODE", SqlDbType.NChar);
                        //相手倉庫
                        paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.AfEnterWarehCode);
                    }

                    // 移動先拠点コード
                    if (!string.IsNullOrEmpty(paramWork.SectionCode))
                    {
                        retstring += " AND STOCK.AFSECTIONCODERF=@FINDAFSECTIONCODE" + Environment.NewLine;
                        SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@FINDAFSECTIONCODE", SqlDbType.NChar);
                        //入庫拠点
                        paraAfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                    }
                    // 移動先倉庫コード
                    if (!string.IsNullOrEmpty(paramWork.WarehouseCode))
                    {
                        retstring += " AND STOCK.AFENTERWAREHCODERF=@FINDAFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@FINDAFENTERWAREHCODE", SqlDbType.NChar);
                        //入庫倉庫
                        paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
                    }
                    // 出荷確定日
                    if (paramWork.St_Date != DateTime.MinValue)
                    {
                        retstring += " AND STOCK.SHIPMENTFIXDAYRF>=@FINDSHIPMENTFIXDAYST" + Environment.NewLine;
                        SqlParameter paraShipmentFixDaySt = sqlCommand.Parameters.Add("@FINDSHIPMENTFIXDAYST", SqlDbType.Int);
                        //入出荷日(開始)
                        paraShipmentFixDaySt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_Date);
                    }
                    if (paramWork.Ed_Date != DateTime.MinValue)
                    {
                        retstring += " AND STOCK.SHIPMENTFIXDAYRF<=@FINDSHIPMENTFIXDAYED" + Environment.NewLine;
                        SqlParameter paraShipmentFixDayEd = sqlCommand.Parameters.Add("@FINDSHIPMENTFIXDAYED", SqlDbType.Int);
                        //入出荷日(終了)
                        paraShipmentFixDayEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_Date);
                    }
                    // 入荷区分
                    retstring += " AND STOCK.MOVESTATUSRF =@FINDMOVESTATUS" + Environment.NewLine;
                    SqlParameter paraMoveStatus = sqlCommand.Parameters.Add("@FINDMOVESTATUS", SqlDbType.Int);
                    //入出荷日(終了)
                    paraMoveStatus.Value = SqlDataMediator.SqlSetInt(2);

                    // 在庫移動入力従業員コード
                    if (!string.IsNullOrEmpty(paramWork.SalesEmployeeCd))
                    {
                        retstring += " AND STOCK.STOCKMVEMPCODERF=@FINDSTOCKMVEMPCODE" + Environment.NewLine;
                        SqlParameter paraStockMvEmpCode = sqlCommand.Parameters.Add("@FINDSTOCKMVEMPCODE", SqlDbType.NChar);
                        //担当者
                        paraStockMvEmpCode.Value = SqlDataMediator.SqlSetString(paramWork.SalesEmployeeCd);
                    }

                    // 棚番 移動先棚番
                    if (paramWork.WarehouseShelfNo != string.Empty)
                    {
                        //あいまい検索かどうかをチェック
                        if (System.Text.RegularExpressions.Regex.Match(paramWork.WarehouseShelfNo, "(%)").Success == true)
                        {
                            //あいまい検索
                            retstring += " AND STOCK.AFSHELFNORF LIKE @FINDWAREHOUSESHELFNO" + Environment.NewLine;
                        }
                        else
                        {
                            //あいまい検索じゃない
                            retstring += " AND STOCK.AFSHELFNORF=@FINDWAREHOUSESHELFNO" + Environment.NewLine;
                        }
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseShelfNo);
                    }
                }
            }
            // 伝票区分の場合
            else
            {
                // 更新拠点コード
                if (!string.IsNullOrEmpty(paramWork.InputSectionCode))
                {
                    retstring += " AND STOCK.UPDATESECCDRF=@FINDUPDATESECCD" + Environment.NewLine;
                    SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@FINDUPDATESECCD", SqlDbType.NChar);
                    // 入力拠点
                    paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(paramWork.InputSectionCode);
                }

                // 入荷日
                if (paramWork.St_Date != DateTime.MinValue)
                {
                    retstring += " AND STOCK.ARRIVALGOODSDAYRF>=@FINDSHIPMENTFIXDAYST" + Environment.NewLine;
                    SqlParameter paraShipmentFixDaySt = sqlCommand.Parameters.Add("@FINDSHIPMENTFIXDAYST", SqlDbType.Int);
                    //入出荷日(開始)
                    paraShipmentFixDaySt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_Date);
                }
                if (paramWork.Ed_Date != DateTime.MinValue)
                {
                    retstring += " AND STOCK.ARRIVALGOODSDAYRF<=@FINDSHIPMENTFIXDAYED" + Environment.NewLine;
                    SqlParameter paraShipmentFixDayEd = sqlCommand.Parameters.Add("@FINDSHIPMENTFIXDAYED", SqlDbType.Int);
                    //入出荷日(終了)
                    paraShipmentFixDayEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_Date);
                }

                // 在庫移動入力従業員コード
                if (!string.IsNullOrEmpty(paramWork.SalesEmployeeCd))
                {
                    retstring += " AND STOCK.STOCKMVEMPCODERF=@FINDSTOCKMVEMPCODE" + Environment.NewLine;
                    SqlParameter paraStockMvEmpCode = sqlCommand.Parameters.Add("@FINDSTOCKMVEMPCODE", SqlDbType.NChar);
                    // 担当者
                    paraStockMvEmpCode.Value = SqlDataMediator.SqlSetString(paramWork.SalesEmployeeCd);
                }

                // 在庫移動形式
                if (paramWork.SalesSlipDiv != 0)
                {
                    retstring += " AND (STOCK.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL1" + Environment.NewLine;
                    retstring += " OR STOCK.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL2)" + Environment.NewLine;
                    SqlParameter paraStockMoveFormal1 = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL1", SqlDbType.Int);
                    SqlParameter paraStockMoveFormal2 = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL2", SqlDbType.Int);
                    if (paramWork.SalesSlipDiv == 1)
                    {
                        // 出庫
                        paraStockMoveFormal1.Value = SqlDataMediator.SqlSetInt(1);
                        paraStockMoveFormal2.Value = SqlDataMediator.SqlSetInt(2);

                        //移動元拠点コード
                        if (!string.IsNullOrEmpty(paramWork.SectionCode))
                        {
                            retstring += " AND STOCK.BFSECTIONCODERF=@FINDBFSECTIONCODE" + Environment.NewLine;
                            SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@FINDBFSECTIONCODE", SqlDbType.NChar);
                            // 出庫拠点
                            paraBfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                        }
                        //移動元倉庫コード
                        if (!string.IsNullOrEmpty(paramWork.WarehouseCode))
                        {
                            retstring += " AND STOCK.BFENTERWAREHCODERF=@FINDBFENTERWAREHCODE" + Environment.NewLine;
                            SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@FINDBFENTERWAREHCODE", SqlDbType.NChar);
                            // 出庫倉庫
                            paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
                        }
                        // 移動先拠点コード
                        if (!string.IsNullOrEmpty(paramWork.AfSectionCode))
                        {
                            retstring += " AND STOCK.AFSECTIONCODERF=@FINDAFSECTIONCODE" + Environment.NewLine;
                            SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@FINDAFSECTIONCODE", SqlDbType.NChar);
                            //相手倉庫
                            paraAfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.AfSectionCode);
                        }
                        // 移動先倉庫コード
                        if (!string.IsNullOrEmpty(paramWork.AfEnterWarehCode))
                        {
                            retstring += " AND STOCK.AFENTERWAREHCODERF=@FINDAFENTERWAREHCODE" + Environment.NewLine;
                            SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@FINDAFENTERWAREHCODE", SqlDbType.NChar);
                            //相手倉庫
                            paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.AfEnterWarehCode);
                        }
                        // 棚番 移動元棚番
                        if (paramWork.WarehouseShelfNo != string.Empty)
                        {
                            //あいまい検索かどうかをチェック
                            if (System.Text.RegularExpressions.Regex.Match(paramWork.WarehouseShelfNo, "(%)").Success == true)
                            {
                                //あいまい検索
                                retstring += " AND STOCK.BFSHELFNORF LIKE @FINDWAREHOUSESHELFNO" + Environment.NewLine;
                            }
                            else
                            {
                                //あいまい検索じゃない
                                retstring += " AND STOCK.BFSHELFNORF=@FINDWAREHOUSESHELFNO" + Environment.NewLine;
                            }
                            SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseShelfNo);
                        }
                    }
                    else
                    {
                        // 入庫
                        paraStockMoveFormal1.Value = SqlDataMediator.SqlSetInt(3);
                        paraStockMoveFormal2.Value = SqlDataMediator.SqlSetInt(4);

                        //移動元拠点コード
                        if (!string.IsNullOrEmpty(paramWork.AfSectionCode))
                        {
                            retstring += " AND STOCK.BFSECTIONCODERF=@FINDBFSECTIONCODE" + Environment.NewLine;
                            SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@FINDBFSECTIONCODE", SqlDbType.NChar);
                            // 相手拠点
                            paraBfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.AfSectionCode);
                        }
                        // 移動元倉庫コード
                        if (!string.IsNullOrEmpty(paramWork.AfEnterWarehCode))
                        {
                            retstring += " AND STOCK.BFENTERWAREHCODERF=@FINDBFENTERWAREHCODE" + Environment.NewLine;
                            SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@FINDBFENTERWAREHCODE", SqlDbType.NChar);
                            // 相手倉庫
                            paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.AfEnterWarehCode);
                        }
                        // 移動先拠点コード
                        if (!string.IsNullOrEmpty(paramWork.SectionCode))
                        {
                            retstring += " AND STOCK.AFSECTIONCODERF=@FINDAFSECTIONCODE" + Environment.NewLine;
                            SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@FINDAFSECTIONCODE", SqlDbType.NChar);
                            // 入庫拠点
                            paraAfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                        }
                        // 移動先倉庫コード
                        if (!string.IsNullOrEmpty(paramWork.WarehouseCode))
                        {
                            retstring += " AND STOCK.AFENTERWAREHCODERF=@FINDAFENTERWAREHCODE" + Environment.NewLine;
                            SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@FINDAFENTERWAREHCODE", SqlDbType.NChar);
                            // 入庫倉庫
                            paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
                        }
                        // 棚番 移動先棚番
                        if (paramWork.WarehouseShelfNo != string.Empty)
                        {
                            //あいまい検索かどうかをチェック
                            if (System.Text.RegularExpressions.Regex.Match(paramWork.WarehouseShelfNo, "(%)").Success == true)
                            {
                                //あいまい検索
                                retstring += " AND STOCK.AFSHELFNORF LIKE @FINDWAREHOUSESHELFNO" + Environment.NewLine;
                            }
                            else
                            {
                                //あいまい検索じゃない
                                retstring += " AND STOCK.AFSHELFNORF=@FINDWAREHOUSESHELFNO" + Environment.NewLine;
                            }
                            SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseShelfNo);
                        }

                    }
                }

            }
            #endregion

            return retstring;
        }
        #endregion

        #region [StockMoveWork処理]
        /// <summary>
        /// クラス格納処理 Reader → StockMoveWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">CustPrtPprBlnceWork</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理 Reader → StockMoveWork。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/20 朱俊成 仕入先と仕入先名を追加します</br>
        /// </remarks>
        private StockMoveWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, StockMovePrtWork paramWork)
        {
            #region 抽出結果-値セット
            StockMoveWork resultWork = new StockMoveWork();

            resultWork.StockMoveFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEFORMALRF"));
            resultWork.StockMoveSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVESLIPNORF"));
            resultWork.StockMoveRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEROWNORF"));
            resultWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF")).Trim();
            resultWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF")).Trim();
            resultWork.BfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF"));
            resultWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF")).Trim();
            resultWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
            resultWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF")).Trim();
            resultWork.AfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDESNMRF"));
            resultWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF")).Trim();
            resultWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
            resultWork.ShipmentFixDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF"));
            resultWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            resultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            resultWork.MoveStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTATUSRF"));
            resultWork.StockMvEmpName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKMVEMPNAMERF"));
            resultWork.ReceiveAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVEAGENTNMRF"));
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            resultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            resultWork.MoveCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
            resultWork.BfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
            resultWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
            resultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            resultWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
            resultWork.WarehouseNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
            resultWork.StockMovePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMOVEPRICERF"));
            resultWork.UpdateSecNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            // ADD 2011/05/20 ------------------------->>>>>>
            resultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            resultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            // ADD 2011/05/20 -------------------------<<<<<<
            #endregion

            return resultWork;
        }
        #endregion
    }
}