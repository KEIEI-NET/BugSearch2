//***************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入返品予定一覧表
// プログラム概要   : 仕入返品予定一覧表 リモートクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI高橋 文彰
// 作 成 日   2013/01/28 修正内容 : 新規作成 仕入返品予定機能対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI斎藤 和宏
// 修 正 日  2013/02/18  修正内容 : 仕入日のセット内容修正
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入返品予定一覧表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入返品予定一覧表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : FSI高橋 文彰</br>
    /// <br>Date       :  2013/01/28</br>
    /// </remarks>
    [Serializable]
    public class StockRetPlnTableDB : RemoteDB, IStockRetPlnTableDB
    {
        /// <summary>
        /// 仕入返品予定一覧表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        public StockRetPlnTableDB()
            :
            base("PMKAK02039D", "Broadleaf.Application.Remoting.ParamData.StockRetPlnList", "STOCKSLIPRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の仕入返品予定一覧表情報LISTを戻します
        /// </summary>
        /// <param name="StockRetPlnList">検索結果</param>
        /// <param name="stockRetPlnParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入返品予定一覧表情報LISTを戻します</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        public int Search(out object StockRetPlnList, object stockRetPlnParamWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            StockRetPlnList = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockRetList(out StockRetPlnList, stockRetPlnParamWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockRetPlnTableDB.Search");
                StockRetPlnList = new ArrayList();
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
        /// 指定された条件の仕入返品予定一覧表情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objStockRetPlnList">検索結果</param>
        /// <param name="objStockRetPlnParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入返品予定一覧表情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        public int SearchStockRetList(out object objStockRetPlnList, object objStockRetPlnParamWork, ref SqlConnection sqlConnection)
        {
            StockRetPlnParamWork stockRetPlnParamWork = null;

            ArrayList stockRetPlnParamWorkList = objStockRetPlnParamWork as ArrayList;
            ArrayList StockRetPlnListList = null;

            if (stockRetPlnParamWorkList == null)
            {
                stockRetPlnParamWork = objStockRetPlnParamWork as StockRetPlnParamWork;
            }
            else
            {
                if (stockRetPlnParamWorkList.Count > 0)
                    stockRetPlnParamWork = stockRetPlnParamWorkList[0] as StockRetPlnParamWork;
            }

            int status = SearchArrivalListProc(out StockRetPlnListList, stockRetPlnParamWork, ref sqlConnection);
            objStockRetPlnList = StockRetPlnListList;
            return status;

        }

        /// <summary>
        /// 指定された条件の仕入返品予定一覧表情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="StockRetPlnListList">検索結果</param>
        /// <param name="stockRetPlnParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入返品予定一覧表情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        public int SearchArrivalListProc(out ArrayList StockRetPlnListList, StockRetPlnParamWork stockRetPlnParamWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                sqlCommand.CommandTimeout = 600; // タイムアウトは10分
                sqlCommand.CommandText += MakeSelectString(ref sqlCommand, stockRetPlnParamWork)
                                       + MakeWhereString(ref sqlCommand, stockRetPlnParamWork)
                                       + MakeOrderByString(ref sqlCommand, stockRetPlnParamWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockRetPlnListFromReader(ref myReader));

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

            StockRetPlnListList = al;

            return status;
        }
        #endregion

        #region [SQL生成処理]
        /// <summary>
        /// SQL生成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="stockRetPlnParamWork">検索条件格納クラス</param>
        /// <returns>仕入返品予定一覧表のSQL文字列</returns>
        /// <br>Note       : 仕入返品予定一覧表のSQLを作成して戻します</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        private string MakeSelectString(ref SqlCommand sqlCommand, StockRetPlnParamWork stockRetPlnParamWork)
        {
            string sqlstring = string.Empty;
            sqlstring += "SELECT STKSLP.ENTERPRISECODERF" + Environment.NewLine; //企業コード
            sqlstring += "    ,STKSLP.STOCKSECTIONCDRF" + Environment.NewLine; //拠点コード
            sqlstring += "    ,SECIN.SECTIONGUIDESNMRF" + Environment.NewLine; //拠点名称
            sqlstring += "    ,STKSLP.SUPPLIERCDRF" + Environment.NewLine; //仕入先コード
            sqlstring += "    ,STKSLP.SUPPLIERSNMRF" + Environment.NewLine;//仕入先名
            sqlstring += "    ,STKDTL.SUPPLIERFORMALRF" + Environment.NewLine;//仕入形式
            sqlstring += "    ,STKSLP.INPUTDAYRF" + Environment.NewLine;//入力日
            sqlstring += "    ,STKSLP.STOCKDATERF" + Environment.NewLine;//仕入日
            // --- ADD 2013/02/18 ---------->>>>>
            // 仕入伝票発行日も取得
            sqlstring += "    ,STKSLP.STOCKSLIPPRINTDATERF" + Environment.NewLine;//仕入伝票発行日を
            // --- ADD 2013/02/18 ----------<<<<<
            sqlstring += "    ,STKDTL.SUPPLIERSLIPNORF" + Environment.NewLine;//仕入伝票番号
            sqlstring += "    ,STKDTL.GOODSNORF" + Environment.NewLine;//メーカー名
            sqlstring += "    ,STKDTL.BLGOODSCODERF" + Environment.NewLine;//BLコード
            sqlstring += "    ,STKDTL.GOODSMAKERCDRF" + Environment.NewLine;//部品メーカーコード
            sqlstring += "    ,STKDTL.GOODSNAMERF" + Environment.NewLine;//商品名
            sqlstring += "    ,STKDTL.STOCKCOUNTRF" + Environment.NewLine;//数量
            sqlstring += "    ,STKSLP.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;//備考
            sqlstring += "    ,STKSLP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;//伝票金額（税抜）
            sqlstring += "    ,STKSLP.STOCKTTLPRICTAXINCRF" + Environment.NewLine;//伝票金額（税込）
            sqlstring += "    ,STKSLP.STOCKPRICECONSTAXRF AS SLPCONSTAXRF" + Environment.NewLine;//伝票消費税（税込）
            sqlstring += "    ,STKDTL.STOCKUNITPRICEFLRF" + Environment.NewLine;//単価（税抜）
            sqlstring += "    ,STKDTL.STOCKUNITTAXPRICEFLRF" + Environment.NewLine;//単価（税込）
            sqlstring += "    ,STKDTL.STOCKPRICETAXEXCRF" + Environment.NewLine;//明細仕入金額（税抜）
            sqlstring += "    ,STKDTL.STOCKPRICETAXINCRF" + Environment.NewLine;//明細仕入金額（税込）
            sqlstring += "    ,STKDTL.LISTPRICETAXEXCFLRF" + Environment.NewLine;//定価（税抜）
            sqlstring += "    ,STKDTL.LISTPRICETAXINCFLRF" + Environment.NewLine;//定価（税込）
            sqlstring += "    ,STKDTL.STOCKPRICECONSTAXRF AS DTLCONSTAXRF" + Environment.NewLine;//明細消費税額
            sqlstring += "    ,STKSLP.LOGICALDELETECODERF AS SLPLOGDELCD" + Environment.NewLine;//仕入論理削除区分
            sqlstring += "    ,STKDTL.LOGICALDELETECODERF AS STLLOGDELCD" + Environment.NewLine;//明細論理削除区分
            sqlstring += "    ,STKSLP.SUPPCTAXLAYCDRF" + Environment.NewLine;//消費税転嫁区分
            sqlstring += "    ,STKDTL.TAXATIONCODERF" + Environment.NewLine;//課税区分
            sqlstring += "    ,STKDTL.SALESSLIPDTLNUMSYNCRF" + Environment.NewLine;//売上明細通番（同時）
            sqlstring += "    ,STKSLP.SUPPLIERSLIPCDRF" + Environment.NewLine;//仕入伝票区分
            sqlstring += " FROM STOCKSLIPRF AS STKSLP WITH (READUNCOMMITTED)" + Environment.NewLine;        //仕入金額
            sqlstring += " LEFT JOIN STOCKDETAILRF AS STKDTL WITH (READUNCOMMITTED)" + Environment.NewLine; //仕入明細
            sqlstring += " ON (STKDTL.ENTERPRISECODERF = STKSLP.ENTERPRISECODERF AND STKDTL.SUPPLIERSLIPNORF = STKSLP.SUPPLIERSLIPNORF AND STKDTL.SUPPLIERFORMALRF = STKSLP.SUPPLIERFORMALRF)" + Environment.NewLine;
            sqlstring += " LEFT JOIN SECINFOSETRF AS SECIN WITH (READUNCOMMITTED) " + Environment.NewLine;  //拠点情報設定マスタ
            sqlstring += " ON (SECIN.SECTIONCODERF = STKSLP.STOCKSECTIONCDRF AND SECIN.ENTERPRISECODERF = STKSLP.ENTERPRISECODERF)" + Environment.NewLine;

            return sqlstring;
        }
        #endregion

        #region [WHERE句生成処理]
        /// <summary>
        /// WHERE句生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="stockRetPlnParamWork">検索条件格納クラス</param>
        /// <returns>仕入返品予定一覧表のSQL文字列</returns>
        /// <br>Note       : 仕入返品予定一覧表のSQLを作成して戻します</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockRetPlnParamWork stockRetPlnParamWork)
        {

            string wherestring = "WHERE ";
            //固定条件
            //企業コード
            wherestring += "STKSLP.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockRetPlnParamWork.EnterpriseCode);


            //これよりパラメータの値により動的変化の項目
            //拠点コード (配列)
            if (stockRetPlnParamWork.SectionCodes.Length > 0)
            {
                string[] sections = stockRetPlnParamWork.SectionCodes;

                for (int i = 0; i < sections.Length; i++)
                {
                    sections[i] = "'" + sections[i] + "'";
                }

                string inText = string.Join(", ", sections);

                wherestring += "AND STKSLP.STOCKSECTIONCDRF IN (" + inText + ") ";
            }

            // 仕入形式 3:返品予定
            wherestring += "AND STKDTL.SUPPLIERFORMALRF = 3	";

            //開始仕入先コード
            if (stockRetPlnParamWork.SupplierCdSt != 0)
            {
                wherestring += "AND STKSLP.SUPPLIERCDRF>=@SUPPLIERCDST ";
                SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@SUPPLIERCDST", SqlDbType.Int);
                paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(stockRetPlnParamWork.SupplierCdSt);
            }

            //終了仕入先コード
            if (stockRetPlnParamWork.SupplierCdEd != 0)
            {
                wherestring += "AND STKSLP.SUPPLIERCDRF<=@SUPPLIERCDED ";
                SqlParameter paraSupplierCdEd = sqlCommand.Parameters.Add("@SUPPLIERCDED", SqlDbType.Int);
                paraSupplierCdEd.Value = SqlDataMediator.SqlSetInt32(stockRetPlnParamWork.SupplierCdEd);
            }

            // 日付指定
            // 0:伝票日付 1:入力日付
            if (stockRetPlnParamWork.PrintDailyFooter == 0)
            {
                //開始伝票日付
                if (stockRetPlnParamWork.InputDaySt != 0)
                {
                    // --- DEL 2013/02/18 ---------->>>>>
                    //wherestring += "AND STKSLP.STOCKDATERF>=@INPUTDAYST ";
                    // --- DEL 2013/02/18 ----------<<<<<
                    // --- ADD 2013/02/18 ---------->>>>>
                    wherestring += "AND STKSLP.STOCKSLIPPRINTDATERF>=@INPUTDAYST ";
                    // --- ADD 2013/02/18 ----------<<<<<

                    SqlParameter paraInputDaySt = sqlCommand.Parameters.Add("@INPUTDAYST", SqlDbType.Int);
                    paraInputDaySt.Value = SqlDataMediator.SqlSetInt32(stockRetPlnParamWork.InputDaySt);
                }

                //終了伝票日付
                if (stockRetPlnParamWork.InputDayEd != 0)
                {
                    // --- DEL 2013/02/18 ---------->>>>>
                    //wherestring += "AND STKSLP.STOCKDATERF<=@INPUTDAYED ";
                    // --- DEL 2013/02/18 ----------<<<<<
                    // --- ADD 2013/02/18 ---------->>>>>
                    wherestring += "AND STKSLP.STOCKSLIPPRINTDATERF<=@INPUTDAYED ";
                    // --- ADD 2013/02/18 ----------<<<<<
                    SqlParameter paraInputDayEd = sqlCommand.Parameters.Add("@INPUTDAYED", SqlDbType.Int);
                    paraInputDayEd.Value = SqlDataMediator.SqlSetInt32(stockRetPlnParamWork.InputDayEd);
                }
            }
            else if (stockRetPlnParamWork.PrintDailyFooter == 1)
            {
                //開始入力日付
                if (stockRetPlnParamWork.InputDaySt != 0)
                {
                    wherestring += "AND STKSLP.INPUTDAYRF>=@INPUTDAYST ";
                    SqlParameter paraInputDaySt = sqlCommand.Parameters.Add("@INPUTDAYST", SqlDbType.Int);
                    paraInputDaySt.Value = SqlDataMediator.SqlSetInt32(stockRetPlnParamWork.InputDaySt);
                }

                //終了入力日付
                if (stockRetPlnParamWork.InputDayEd != 0)
                {
                    wherestring += "AND STKSLP.INPUTDAYRF<=@INPUTDAYED ";
                    SqlParameter paraInputDayEd = sqlCommand.Parameters.Add("@INPUTDAYED", SqlDbType.Int);
                    paraInputDayEd.Value = SqlDataMediator.SqlSetInt32(stockRetPlnParamWork.InputDayEd);
                }
            }


            // 発行タイプ(仕入データ論理削除区分)
            if (stockRetPlnParamWork.MakeShowDiv == 0)//通常
            {
                // 出力指定(仕入明細データ論理削除区分)
                if (stockRetPlnParamWork.SlipDiv == 0) // 0:返品予定のみ
                {
                    // 仕入データ 論理削除:0,仕入明細データ 論理削除:0,売上明細通番（同時）:0以外
                    wherestring += "AND STKSLP.LOGICALDELETECODERF=0 AND STKDTL.LOGICALDELETECODERF=0 AND STKDTL.SALESSLIPDTLNUMSYNCRF>0 ";
                }
                else if (stockRetPlnParamWork.SlipDiv == 1)// 1:返品済のみ
                {
                    // 仕入データ論理削除:0、仕入明細データ論理削除:1、売上明細通番（同時）:0
                    // 仕入データ論理削除:1、仕入明細データ論理削除:1、売上明細通番（同時）:0
                    wherestring += "AND (STKSLP.LOGICALDELETECODERF=0 AND STKDTL.LOGICALDELETECODERF=1 AND STKDTL.SALESSLIPDTLNUMSYNCRF=0 OR STKSLP.LOGICALDELETECODERF=1 AND STKDTL.LOGICALDELETECODERF=1 AND STKDTL.SALESSLIPDTLNUMSYNCRF=0) ";
                }
                else if (stockRetPlnParamWork.SlipDiv == 2)// 2:すべて
                {
                    wherestring += "AND (STKSLP.LOGICALDELETECODERF=0 AND STKDTL.LOGICALDELETECODERF IN (0,1) AND STKDTL.SALESSLIPDTLNUMSYNCRF>=0 OR STKSLP.LOGICALDELETECODERF=1 AND STKDTL.LOGICALDELETECODERF=1 AND STKDTL.SALESSLIPDTLNUMSYNCRF=0) ";
                }
            }
            else if (stockRetPlnParamWork.MakeShowDiv == 1)//削除
            {
                wherestring += "AND STKSLP.LOGICALDELETECODERF=1 ";
                wherestring += "AND STKDTL.LOGICALDELETECODERF=1 ";

                // 出力指定(仕入明細データ論理削除区分)
                if (stockRetPlnParamWork.SlipDiv == 0) // 0:返品予定のみ
                {
                    wherestring += "AND STKDTL.SALESSLIPDTLNUMSYNCRF>0 ";
                }
                else if (stockRetPlnParamWork.SlipDiv == 2)// 2:すべて
                {
                    wherestring += "AND STKDTL.SALESSLIPDTLNUMSYNCRF>0 ";
                }
            }
            return wherestring;
        }
        #endregion

        #region [ORDER BY句生成処理]
        /// <summary>
        /// ORDER BY句生成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="stockRetPlnParamWork">検索条件格納クラス</param>
        /// <returns>仕入返品予定一覧表のSQL文字列</returns>
        /// <br>Note       : 仕入返品予定一覧表のSQLを作成して戻します</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       : 2013/01/28</br>
        private string MakeOrderByString(ref SqlCommand sqlCommand, StockRetPlnParamWork stockRetPlnParamWork)
        {
            string sqlstring = "ORDER BY STKSLP.STOCKSECTIONCDRF ,STKSLP.SUPPLIERCDRF,STKSLP.STOCKDATERF,STKSLP.INPUTDAYRF,STKSLP.SUPPLIERSLIPNORF";
    
            return sqlstring;
        }
        #endregion


        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → PreChargedDataSelectResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesConfWork</returns>
        /// <remarks>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private StockRetPlnList CopyToStockRetPlnListFromReader(ref SqlDataReader myReader)
        {
            StockRetPlnList StockRetPlnList = new StockRetPlnList();

            #region クラスへ格納
            StockRetPlnList.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
            StockRetPlnList.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
            StockRetPlnList.SlpConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLPCONSTAXRF"));
            StockRetPlnList.DtlConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DTLCONSTAXRF"));
            StockRetPlnList.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            StockRetPlnList.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
            StockRetPlnList.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            StockRetPlnList.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
            StockRetPlnList.ListPriceTaxExc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            StockRetPlnList.ListPriceTaxInc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
            StockRetPlnList.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            StockRetPlnList.SlpLogDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLPLOGDELCD"));
            StockRetPlnList.DtlLogDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STLLOGDELCD"));
            StockRetPlnList.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSYNCRF"));
            StockRetPlnList.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
            StockRetPlnList.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            StockRetPlnList.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            StockRetPlnList.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            StockRetPlnList.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            StockRetPlnList.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));

            // --- DEL 2013/02/18 ---------->>>>>
            //StockRetPlnList.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            // --- DEL 2013/02/18 ----------<<<<<
            // --- ADD 2013/02/18 ---------->>>>>
            // 伝票日付は仕入伝票発行日から取得
            StockRetPlnList.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKSLIPPRINTDATERF"));
            // --- ADD 2013/02/18 ----------<<<<<
            StockRetPlnList.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            StockRetPlnList.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            StockRetPlnList.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            StockRetPlnList.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            StockRetPlnList.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            StockRetPlnList.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            StockRetPlnList.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            StockRetPlnList.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            #endregion

            return StockRetPlnList;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
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