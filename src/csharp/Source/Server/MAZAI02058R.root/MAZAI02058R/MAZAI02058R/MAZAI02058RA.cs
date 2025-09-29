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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫調整確認表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫調整確認表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22035 三橋 弘憲</br>
    /// <br>Date       : 2007.03.17</br>
    /// <br></br>
    /// <br>UpdateNote : 2007.10.02 長内 DC.NS用に修正</br>
	/// <br></br>
	/// <br>Update Note: 2008.03.26 佐々木 健</br>
	/// <br>           : 商品コードの絞り込みを修正</br>
    /// <br></br>
    /// <br>Update Note: 2008.06.30 20081</br>
    /// <br>           : ＰＭ.ＮＳ用に変更</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/05/10 長内 速度チューニング</br>
    /// <br>Update Note: 2011.11.15 許培珠</br>
    /// <br>           : redmine#26559</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class StockAdjustWorkDB : RemoteDB, IStockAdjustWorkDB
    {
        /// <summary>
        /// 在庫調整確認表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.17</br>
        /// </remarks>
        public StockAdjustWorkDB()
            :
        base("MAZAI02056D", "Broadleaf.Application.Remoting.ParamData.StockAdjustResultWork", "STOCKADJUSTDTLRF") //基底クラスのコンストラクタ
        {
        }

        #region Search
        /// <summary>
        /// 指定された企業コードの在庫調整確認表LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="stockAdjustResultWork">検索結果</param>
        /// <param name="stockAdjustCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの受託残一覧表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.17</br>
        public int Search(out object stockAdjustResultWork, object stockAdjustCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockAdjustResultWork = null;

            StockAdjustCndtnWork _stockAdjustCndtnWork = stockAdjustCndtnWork as StockAdjustCndtnWork;

            try
            {
                status = SearchProc(out stockAdjustResultWork, _stockAdjustCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAdjustWorkDB.Search Exception=" + ex.Message);
                stockAdjustResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの在庫調整確認表LISTを全て戻します
        /// </summary>
        /// <param name="stockAdjustResultWork">検索結果</param>
        /// <param name="_stockAdjustCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの受託残一覧表LISTを全て戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.17</br>
        private int SearchProc(out object stockAdjustResultWork, StockAdjustCndtnWork _stockAdjustCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            stockAdjustResultWork = null;

            ArrayList al = new ArrayList();   //抽出結果

            //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return status;

            //SQL文生成
            sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // 対象テーブル
                // STOCKADJUSTRF    SAJ   在庫調整データ
                // STOCKADJUSTDTLRF SAD   在庫調整明細データ
                // SECINFOSETRF     SIS   拠点情報設定マスタ

                string selectTxt = "";

                #region Select文作成
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "     SAJ.STOCKSECTIONCDRF" + Environment.NewLine;
                selectTxt += "    ,SIS.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "    ,SAD.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "    ,SAD.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "    ,SAD.ACPAYSLIPCDRF" + Environment.NewLine;
                selectTxt += "    ,SAD.ACPAYTRANSCDRF" + Environment.NewLine;
                selectTxt += "    ,SAD.ADJUSTDATERF" + Environment.NewLine;
                selectTxt += "    ,SAD.STOCKADJUSTSLIPNORF" + Environment.NewLine;
                selectTxt += "    ,SAD.STOCKADJUSTROWNORF" + Environment.NewLine;
                selectTxt += "    ,SAD.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "    ,SAD.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "    ,SAD.GOODSNORF" + Environment.NewLine;
                selectTxt += "    ,SAD.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "    ,SAJ.INPUTDAYRF" + Environment.NewLine;
                // ----- DEL 2011/11/15 xupz---------->>>>>
                //selectTxt += "    ,SAJ.STOCKINPUTCODERF" + Environment.NewLine; //仕入入力者コード
                //selectTxt += "    ,SAJ.STOCKINPUTNAMERF" + Environment.NewLine; //仕入入力者名称
                // ----- DEL 2011/11/15 xupz----------<<<<<
                // ----- ADD 2011/11/15 xupz---------->>>>>
                selectTxt += "    ,SAJ.STOCKAGENTCODERF" + Environment.NewLine; //仕入担当者コード
                selectTxt += "    ,SAJ.STOCKAGENTNAMERF" + Environment.NewLine; //仕入担当者名称
                // ----- ADD 2011/11/15 xupz----------<<<<<
                selectTxt += "    ,SAD.ADJUSTCOUNTRF" + Environment.NewLine;
                selectTxt += "    ,SAD.LISTPRICEFLRF" + Environment.NewLine;
                selectTxt += "    ,SAD.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "    ,SAD.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "    ,SAD.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "    ,SAD.DTLNOTERF" + Environment.NewLine;
                selectTxt += "    ,SAJ.SLIPNOTERF" + Environment.NewLine;
                selectTxt += "    ,SAD.OPENPRICEDIVRF" + Environment.NewLine;
                selectTxt += "    ,SAD.STOCKPRICETAXEXCRF" + Environment.NewLine;
                selectTxt += " FROM STOCKADJUSTRF AS SAJ" + Environment.NewLine;

                //在庫調整明細データ結合
                selectTxt += " LEFT JOIN STOCKADJUSTDTLRF SAD ON SAD.ENTERPRISECODERF=SAJ.ENTERPRISECODERF AND SAD.STOCKADJUSTSLIPNORF=SAJ.STOCKADJUSTSLIPNORF" + Environment.NewLine;
                //拠点情報設定結合
                selectTxt += " LEFT JOIN SECINFOSETRF SIS ON SIS.ENTERPRISECODERF=SAD.ENTERPRISECODERF AND SIS.SECTIONCODERF=SAJ.STOCKSECTIONCDRF" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _stockAdjustCndtnWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    StockAdjustResultWork wkStockAdjustResultWork = new StockAdjustResultWork();

                    //在庫車両入出庫管理マスタ結果取得内容格納
                    wkStockAdjustResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                    wkStockAdjustResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    wkStockAdjustResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkStockAdjustResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    wkStockAdjustResultWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
                    wkStockAdjustResultWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
                    wkStockAdjustResultWork.AdjustDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
                    wkStockAdjustResultWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF"));
                    wkStockAdjustResultWork.StockAdjustRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTROWNORF"));
                    wkStockAdjustResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkStockAdjustResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkStockAdjustResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkStockAdjustResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkStockAdjustResultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    // ----- DEL 2011/11/15 xupz---------->>>>>
                    //wkStockAdjustResultWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF")); //仕入入力者コード
                    //wkStockAdjustResultWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF")); //仕入入力者名称
                    // ----- DEL 2011/11/15 xupz----------<<<<<
                    // ----- ADD 2011/11/15 xupz---------->>>>>
                    wkStockAdjustResultWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF")); //仕入担当者コード
                    wkStockAdjustResultWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF")); //仕入担当者名称
                    // ----- ADD 2011/11/15 xupz----------<<<<<
                    wkStockAdjustResultWork.AdjustCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
                    wkStockAdjustResultWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
                    wkStockAdjustResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    wkStockAdjustResultWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
                    wkStockAdjustResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkStockAdjustResultWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
                    wkStockAdjustResultWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
                    wkStockAdjustResultWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    wkStockAdjustResultWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                    #endregion

                    al.Add(wkStockAdjustResultWork);

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
                base.WriteErrorLog(ex, "StockAdjustWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            stockAdjustResultWork = al;

            return status;
        }
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_stockAdjustCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockAdjustCndtnWork _stockAdjustCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;

            //企業コード
            // -- UPD 2010/05/10 ------------------------------------->>>
            //retstring += " SAD.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            retstring += " SAJ.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            // -- UPD 2010/05/10 -------------------------------------<<<
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                // -- UPD 2010/05/10 ------------------------------------->>>
                //retstring += " AND SAD.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                retstring += " AND SAJ.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------<<<
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                // -- UPD 2010/05/10 ------------------------------------->>>
                //retstring += " AND SAD.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                retstring += " AND SAJ.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------<<<
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //拠点コード    ※配列で複数指定される
            if (_stockAdjustCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _stockAdjustCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND SAJ.STOCKSECTIONCDRF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //倉庫コード設定
            if (_stockAdjustCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND SAD.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.St_WarehouseCode);
            }
            if (_stockAdjustCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND SAD.WAREHOUSECODERF<=@EDWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.Ed_WarehouseCode);
            }

            //受払元伝票区分    ※配列で複数指定される
            if (_stockAdjustCndtnWork.AcPaySlipCds != null)
            {
                string acPaySlipCd = "";
                foreach (Int32 code in _stockAdjustCndtnWork.AcPaySlipCds)
                {
                    if (acPaySlipCd != "")
                    {
                        acPaySlipCd += ",";
                    }
                    acPaySlipCd += code;
                }

                if (acPaySlipCd != "")
                {
                    // -- UPD 2010/05/10 ------------------------------------->>>
                    //retstring += " AND SAD.ACPAYSLIPCDRF IN (" + acPaySlipCd + ") ";
                    retstring += " AND SAJ.ACPAYSLIPCDRF IN (" + acPaySlipCd + ") ";
                    // -- UPD 2010/05/10 -------------------------------------<<<
                }
                retstring += Environment.NewLine;
            }


            //受払元取引区分
            if (_stockAdjustCndtnWork.AcPayTransCd != -1)
            {
                retstring += " AND SAD.ACPAYTRANSCDRF=@ACPAYTRANSCD" + Environment.NewLine;
                SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
                paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(_stockAdjustCndtnWork.AcPayTransCd);
            }

            //調整日付
            if (_stockAdjustCndtnWork.St_AdjustDate != DateTime.MinValue)
            {
                int startymd = TDateTime.DateTimeToLongDate(_stockAdjustCndtnWork.St_AdjustDate);
                retstring += " AND SAJ.ADJUSTDATERF >= " + startymd.ToString() + Environment.NewLine;
            }
            if (_stockAdjustCndtnWork.Ed_AdjustDate != DateTime.MinValue)
            {
                if (_stockAdjustCndtnWork.St_AdjustDate == DateTime.MinValue)
                {
                    retstring += " AND (SAJ.ADJUSTDATERF IS NULL OR";
                }
                else
                {
                    retstring += " AND";
                }

                int endymd = TDateTime.DateTimeToLongDate(_stockAdjustCndtnWork.Ed_AdjustDate);
                retstring += " SAJ.ADJUSTDATERF <= " + endymd.ToString();

                if (_stockAdjustCndtnWork.St_AdjustDate == DateTime.MinValue)
                {
                    retstring += " ) ";
                }
                retstring += Environment.NewLine;
            }

            // 2008.06.30 del start ------------------------------------------------>>
            ////在庫調整伝票番号
            //if (_stockAdjustCndtnWork.St_StockAdjustSlipNo != 0)
            //{
            //    retstring += " AND SAD.STOCKADJUSTSLIPNORF>=@STSTOCKADJUSTSLIPNO" + Environment.NewLine;
            //    SqlParameter paraStStockAdjustSlipNo = sqlCommand.Parameters.Add("@STSTOCKADJUSTSLIPNO", SqlDbType.Int);
            //    paraStStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(_stockAdjustCndtnWork.St_StockAdjustSlipNo);
            //}
            //if (_stockAdjustCndtnWork.Ed_StockAdjustSlipNo != 999999999)
            //{
            //    retstring += " AND SAD.STOCKADJUSTSLIPNORF<=@EDSTOCKADJUSTSLIPNO" + Environment.NewLine;
            //    SqlParameter paraEdStockAdjustSlipNo = sqlCommand.Parameters.Add("@EDSTOCKADJUSTSLIPNO", SqlDbType.Int);
            //    paraEdStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(_stockAdjustCndtnWork.Ed_StockAdjustSlipNo);
            //}

            ////メーカーコード
            //if (_stockAdjustCndtnWork.St_GoodsMakerCd != 0)
            //{
            //    retstring += " AND SAD.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
            //    SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
            //    paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockAdjustCndtnWork.St_GoodsMakerCd);
            //}
            //if (_stockAdjustCndtnWork.Ed_GoodsMakerCd != 999999)
            //{
            //    retstring += " AND SAD.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
            //    SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
            //    paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockAdjustCndtnWork.Ed_GoodsMakerCd);
            //}

            ////商品番号
            //if (_stockAdjustCndtnWork.St_GoodsNo != "")
            //{
            //    retstring += " AND SAD.GOODSNORF>=@STGOODSNO" + Environment.NewLine;
            //    SqlParameter paraStGoodsCode = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
            //    paraStGoodsCode.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.St_GoodsNo);
            //}
            //if (_stockAdjustCndtnWork.Ed_GoodsNo != "")
            //{
            //    retstring += " AND (SAD.GOODSNORF<=@EDGOODSNO OR SAD.GOODSNORF LIKE @EDGOODSNO)" + Environment.NewLine;
            //    SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
            //    // 2008.03.26 >>
            //    //paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.Ed_GoodsNo + "%");
            //    paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.Ed_GoodsNo);
            //    // 2008.03.26 <<
            //}
            // 2008.06.30 del end --------------------------------------------------<<

            // 2008.06.30 add start ------------------------------------------------>>
            // 入力日
            if (_stockAdjustCndtnWork.St_InputDay != DateTime.MinValue)
            {
                int startInymd = TDateTime.DateTimeToLongDate(_stockAdjustCndtnWork.St_InputDay);
                retstring += " AND SAJ.INPUTDAYRF >= " + startInymd.ToString() + Environment.NewLine;
            }
            if (_stockAdjustCndtnWork.Ed_InputDay != DateTime.MinValue)
            {
                if (_stockAdjustCndtnWork.St_InputDay == DateTime.MinValue)
                {
                    retstring += " AND (SAJ.INPUTDAYRF IS NULL OR";
                }   
                else
                {
                    retstring += " AND";
                }

                int endInymd = TDateTime.DateTimeToLongDate(_stockAdjustCndtnWork.Ed_InputDay);
                retstring += " SAJ.INPUTDAYRF <= " + endInymd.ToString();

                if (_stockAdjustCndtnWork.St_InputDay == DateTime.MinValue)
                {
                    retstring += ") ";
                }
                retstring += Environment.NewLine;
            }
            // 2008.06.30 add end --------------------------------------------------<<

            // ----- DEL 2011/11/15 xupz---------->>>>>
            //仕入入力者コード
            //if (_stockAdjustCndtnWork.St_InputAgenCd != "")
            //{
            //    retstring += " AND SAJ.STOCKINPUTCODERF>=@STINPUTAGENCD" + Environment.NewLine;
            //    SqlParameter paraStInputAgenCd = sqlCommand.Parameters.Add("@STINPUTAGENCD", SqlDbType.NVarChar);
            //    paraStInputAgenCd.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.St_InputAgenCd);
            //}
            //if (_stockAdjustCndtnWork.Ed_InputAgenCd != "")
            //{
            //    if (_stockAdjustCndtnWork.St_InputAgenCd == "")
            //    {
            //        retstring += " AND (SAJ.STOCKINPUTCODERF IS NULL OR";
            //    }
            //    else
            //    {
            //        retstring += " AND (";
            //    }

            //    retstring += " SAJ.STOCKINPUTCODERF<=@EDINPUTAGENCD)" + Environment.NewLine;
            //    SqlParameter paraEdInputAgenCd = sqlCommand.Parameters.Add("@EDINPUTAGENCD", SqlDbType.NVarChar);
            //    paraEdInputAgenCd.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.Ed_InputAgenCd);
            //}
            // ----- DEL 2011/11/15 xupz----------<<<<<

            // ----- ADD 2011/11/15 xupz---------->>>>>
            //仕入担当者コード
            if (_stockAdjustCndtnWork.St_InputAgenCd != "")
            {
                retstring += " AND SAJ.STOCKAGENTCODERF>=@STINPUTAGENCD" + Environment.NewLine;
                SqlParameter paraStInputAgenCd = sqlCommand.Parameters.Add("@STINPUTAGENCD", SqlDbType.NVarChar);
                paraStInputAgenCd.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.St_InputAgenCd);
            }
            if (_stockAdjustCndtnWork.Ed_InputAgenCd != "")
            {
                if (_stockAdjustCndtnWork.St_InputAgenCd == "")
                {
                    retstring += " AND (SAJ.STOCKAGENTCODERF IS NULL OR";
                }
                else
                {
                    retstring += " AND (";
                }

                retstring += " SAJ.STOCKAGENTCODERF<=@EDINPUTAGENCD)" + Environment.NewLine;
                SqlParameter paraEdInputAgenCd = sqlCommand.Parameters.Add("@EDINPUTAGENCD", SqlDbType.NVarChar);
                paraEdInputAgenCd.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.Ed_InputAgenCd);
            }
            // ----- ADD 2011/11/15 xupz----------<<<<<

            ////在庫区分
            //if (_stockAdjustCndtnWork.StockDiv != -1)
            //{
            //    retstring += " AND SAD.STOCKDIVRF=@STOCKDIV" + Environment.NewLine;
            //    SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
            //    paraStockDiv.Value = SqlDataMediator.SqlSetInt32(_stockAdjustCndtnWork.StockDiv);
            //}

            #endregion
            return retstring;
        }
    }
}
