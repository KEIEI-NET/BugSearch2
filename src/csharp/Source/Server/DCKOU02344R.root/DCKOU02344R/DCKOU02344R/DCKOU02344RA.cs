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
    /// 入荷一覧表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入荷一覧表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2008.01.31</br>
    /// <br></br>
    /// <br>Update Note: 30290 得意先・仕入先分離対応</br>
    /// <br>Date       : 2008.04.23</br>
    /// <br></br>
    /// <br>Update Note: 20081 疋田 勇人 ＰＭ.ＮＳ用に変更</br>
    /// <br>Date       : 2008.06.24</br>
    /// <br>           : </br>
    /// <br>Update Note: 22008 長内 数馬 条件、結果に項目追加</br>
    /// <br>Date       : 2009.04.07</br>
    /// <br>           : </br>
    /// </remarks>
    [Serializable]
    public class ArrivalListDB : RemoteDB, IArrivalListDB
    {
        /// <summary>
        /// 入荷一覧表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2008.01.31</br>
        /// </remarks>
        public ArrivalListDB()
            :
            base("DCKOU02346D", "Broadleaf.Application.Remoting.ParamData.ArrivalListResultWork", "ARRIVALLISTRESULTRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の入荷一覧表情報LISTを戻します
        /// </summary>
        /// <param name="arrivalListResultWork">検索結果</param>
        /// <param name="arrivalListParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の入荷一覧表情報LISTを戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2008.01.31</br>
        public int Search(out object arrivalListResultWork, object arrivalListParamWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            arrivalListResultWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchArrivalList(out arrivalListResultWork, arrivalListParamWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ArrivalListDB.Search");
                arrivalListResultWork = new ArrayList();
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
        /// 指定された条件の入荷一覧表情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objArrivalListResultWork">検索結果</param>
        /// <param name="objArrivalListParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の入荷一覧表情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2008.01.31</br>
        public int SearchArrivalList(out object objArrivalListResultWork, object objArrivalListParamWork, ref SqlConnection sqlConnection)
        {
            ArrivalListParamWork arrivalListParamWork = null;

            ArrayList arrivalListParamWorkList = objArrivalListParamWork as ArrayList;
            //ArrayList arrivalListResultWorkList = new ArrayList();
            ArrayList arrivalListResultWorkList = null;

            if (arrivalListParamWorkList == null)
            {
                arrivalListParamWork = objArrivalListParamWork as ArrivalListParamWork;
            }
            else
            {
                if (arrivalListParamWorkList.Count > 0)
                    arrivalListParamWork = arrivalListParamWorkList[0] as ArrivalListParamWork;
            }

            int status = SearchArrivalListProc(out arrivalListResultWorkList, arrivalListParamWork, ref sqlConnection);
            objArrivalListResultWork = arrivalListResultWorkList;
            return status;

        }

        /// <summary>
        /// 指定された条件の入荷一覧表情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arrivalListResultWorkList">検索結果</param>
        /// <param name="arrivalListParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の入荷一覧表情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2008.01.31</br>
        public int SearchArrivalListProc(out ArrayList arrivalListResultWorkList, ArrivalListParamWork arrivalListParamWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                sqlCommand.CommandText += MakeSelectString(ref sqlCommand, arrivalListParamWork)
                                       + MakeWhereString(ref sqlCommand, arrivalListParamWork)
                                       + MakeOrderByString(ref sqlCommand, arrivalListParamWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToArrivalListResultWorkFromReader(ref myReader));

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

            arrivalListResultWorkList = al;

            return status;
        }
        #endregion

        #region [SQL生成処理]
        /// <summary>
        /// SQL生成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="arrivalListParamWork">検索条件格納クラス</param>
        /// <returns>入荷一覧表のSQL文字列</returns>
        /// <br>Note       : 入荷一覧表のSQLを作成して戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2008.01.31</br>
        private string MakeSelectString(ref SqlCommand sqlCommand, ArrivalListParamWork arrivalListParamWork)
        {
            // 2008.06.24 upd start --------------------------------------------->>
            //string sqlstring = "";
            //sqlstring = "SELECT "
            //    + "A.SECTIONCODERF  SECTIONCODERF, "
            //    + "C.SECTIONGUIDENMRF  SECTIONGUIDENMRF, "
            //    + "A.SUPPLIERSLIPNORF  SUPPLIERSLIPNORF, "
            //    + "A.SUPPLIERSLIPCDRF  SUPPLIERSLIPCDRF, "
            //    + "A.ACCPAYDIVCDRF  ACCPAYDIVCDRF, "
            //    + "A.DEBITNOTEDIVRF  DEBITNOTEDIVRF, "
            //    + "A.INPUTDAYRF  INPUTDAYRF, "
            //    + "A.ARRIVALGOODSDAYRF  ARRIVALGOODSDAYRF, "
            //    + "A.STOCKDATERF  STOCKDATERF, "
            //    + "A.SUPPLIERCDRF  SUPPLIERCDRF, "
            //    + "A.SUPPLIERNM1RF  SUPPLIERNM1RF, "
            //    + "A.PAYEECODERF  PAYEECODERF, "
            //    + "A.PAYEESNMRF  PAYEESNMRF, "
            //    + "A.STOCKAGENTCODERF  STOCKAGENTCODERF, "
            //    + "A.STOCKAGENTNAMERF  STOCKAGENTNAMERF, "
            //    + "A.STOCKINPUTCODERF  STOCKINPUTCODERF, "
            //    + "A.STOCKINPUTNAMERF  STOCKINPUTNAMERF, "
            //    + "A.PARTYSALESLIPNUMRF  PARTYSALESLIPNUMRF, "
            //    + "B.STOCKROWNORF  STOCKROWNORF, "
            //    + "B.STOCKSLIPCDDTLRF  STOCKSLIPCDDTLRF, "
            //    + "B.GOODSMAKERCDRF  GOODSMAKERCDRF, "
            //    + "B.MAKERNAMERF  MAKERNAMERF, "
            //    + "B.GOODSNORF  GOODSNORF, "
            //    + "B.GOODSNAMERF  GOODSNAMERF, "
            //    + "B.STOCKCOUNTRF  STOCKCOUNTRF, "
            //    + "B.ORDERCNTRF  ORDERCNTRF, "
            //    + "B.ORDERADJUSTCNTRF  ORDERADJUSTCNTRF, "
            //    + "B.ORDERREMAINCNTRF  ORDERREMAINCNTRF, "
            //    + "B.UNITCODERF  UNITCODERF, "
            //    + "B.UNITNAMERF  UNITNAMERF, "
            //    + "B.STOCKUNITTAXPRICEFLRF  STOCKUNITTAXPRICEFLRF, "
            //    + "B.STOCKUNITPRICEFLRF  STOCKUNITPRICEFLRF, "
            //    + "B.STOCKPRICETAXINCRF  STOCKPRICETAXINCRF, "
            //    + "B.STOCKPRICETAXEXCRF  STOCKPRICETAXEXCRF, "
            //    + "B.TAXATIONCODERF  TAXATIONCODERF, "
            //    + "B.WAREHOUSECODERF  WAREHOUSECODERF, "
            //    + "B.WAREHOUSENAMERF  WAREHOUSENAMERF, "
            //    + "B.STOCKDTISLIPNOTE1RF  STOCKDTLSLIPNOTE1RF "
            //    + "FROM "
            //    + "STOCKSLIPRF A "	//仕入
            //    + "INNER JOIN STOCKDETAILRF B "	//仕入明細
            //    + "ON (B.ENTERPRISECODERF = A.ENTERPRISECODERF AND B.SUPPLIERFORMALRF = A.SUPPLIERFORMALRF AND B.SUPPLIERSLIPNORF = A.SUPPLIERSLIPNORF) "
            //    + "INNER JOIN SECINFOSETRF C "  //拠点情報設定マスタ
            //    + "ON (C.ENTERPRISECODERF = A.ENTERPRISECODERF AND C.SECTIONCODERF = A.SECTIONCODERF) ";
            string sqlstring = string.Empty;
            sqlstring += "SELECT A.STOCKSECTIONCDRF" + Environment.NewLine;
            sqlstring += "    ,C.SECTIONGUIDESNMRF" + Environment.NewLine;
            sqlstring += "    ,A.SUPPLIERSLIPNORF" + Environment.NewLine;
            sqlstring += "    ,A.SUPPLIERSLIPCDRF" + Environment.NewLine;
            sqlstring += "    ,A.ACCPAYDIVCDRF" + Environment.NewLine;
            sqlstring += "    ,A.DEBITNOTEDIVRF" + Environment.NewLine;
            sqlstring += "    ,A.INPUTDAYRF" + Environment.NewLine;
            sqlstring += "    ,A.ARRIVALGOODSDAYRF" + Environment.NewLine;
            sqlstring += "    ,A.STOCKDATERF" + Environment.NewLine;
            sqlstring += "    ,A.SUPPLIERCDRF" + Environment.NewLine;
            sqlstring += "    ,A.SUPPLIERSNMRF" + Environment.NewLine;
            sqlstring += "    ,A.PAYEECODERF" + Environment.NewLine;
            sqlstring += "    ,A.PAYEESNMRF" + Environment.NewLine;
            sqlstring += "    ,A.STOCKAGENTCODERF" + Environment.NewLine;
            sqlstring += "    ,A.STOCKAGENTNAMERF" + Environment.NewLine;
            sqlstring += "    ,A.STOCKINPUTCODERF" + Environment.NewLine;
            sqlstring += "    ,A.STOCKINPUTNAMERF" + Environment.NewLine;
            sqlstring += "    ,A.PARTYSALESLIPNUMRF" + Environment.NewLine;
            sqlstring += "    ,B.STOCKROWNORF" + Environment.NewLine;
            sqlstring += "    ,B.STOCKSLIPCDDTLRF" + Environment.NewLine;
            sqlstring += "    ,B.GOODSMAKERCDRF" + Environment.NewLine;
            sqlstring += "    ,B.MAKERNAMERF" + Environment.NewLine;
            sqlstring += "    ,B.GOODSNORF" + Environment.NewLine;
            sqlstring += "    ,B.GOODSNAMERF" + Environment.NewLine;
            sqlstring += "    ,B.STOCKCOUNTRF" + Environment.NewLine;
            sqlstring += "    ,B.ORDERCNTRF" + Environment.NewLine;
            sqlstring += "    ,B.ORDERADJUSTCNTRF" + Environment.NewLine;
            sqlstring += "    ,B.ORDERREMAINCNTRF" + Environment.NewLine;
            sqlstring += "    ,B.STOCKUNITPRICEFLRF" + Environment.NewLine;
            sqlstring += "    ,B.STOCKUNITTAXPRICEFLRF" + Environment.NewLine;
            sqlstring += "    ,B.STOCKPRICETAXEXCRF" + Environment.NewLine;
            sqlstring += "    ,B.STOCKPRICETAXINCRF" + Environment.NewLine;
            sqlstring += "    ,B.TAXATIONCODERF" + Environment.NewLine;
            sqlstring += "    ,B.WAREHOUSECODERF" + Environment.NewLine;
            sqlstring += "    ,B.WAREHOUSENAMERF" + Environment.NewLine;
            sqlstring += "    ,B.STOCKDTISLIPNOTE1RF" + Environment.NewLine;
            // 2009/04/07 ADD >>>>>>>>>>>>>>>>>>>
            sqlstring += "    ,A.STOCKADDUPADATERF" + Environment.NewLine;
            sqlstring += "    ,A.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
            sqlstring += "    ,A.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
            sqlstring += "    ,A.SUPPCTAXLAYCDRF" + Environment.NewLine;
            sqlstring += "    ,B.BLGOODSCODERF" + Environment.NewLine;
            sqlstring += "    ,B.BLGOODSFULLNAMERF" + Environment.NewLine;
            sqlstring += "    ,B.STOCKORDERDIVCDRF" + Environment.NewLine;
            sqlstring += "    ,B.STOCKPRICECONSTAXRF" + Environment.NewLine;
            // 2009/04/07 <<<<<<<<<<<<<<<<<<<<<<<
            sqlstring += " FROM STOCKSLIPRF A" + Environment.NewLine;        //仕入
            sqlstring += "INNER JOIN STOCKDETAILRF B" + Environment.NewLine; //仕入明細
            sqlstring += "ON (B.ENTERPRISECODERF = A.ENTERPRISECODERF AND B.SUPPLIERFORMALRF = A.SUPPLIERFORMALRF AND B.SUPPLIERSLIPNORF = A.SUPPLIERSLIPNORF)" + Environment.NewLine;
            sqlstring += "INNER JOIN SECINFOSETRF C" + Environment.NewLine;  //拠点情報設定マスタ
            sqlstring += "ON (C.ENTERPRISECODERF = A.ENTERPRISECODERF AND C.SECTIONCODERF = A.STOCKSECTIONCDRF)" + Environment.NewLine; ;
            // 2008.06.24 upd end -----------------------------------------------<<
            return sqlstring;
        }
        #endregion

        #region [WHERE句生成処理]
        /// <summary>
        /// WHERE句生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="arrivalListParamWork">検索条件格納クラス</param>
        /// <returns>入荷一覧表のSQL文字列</returns>
        /// <br>Note       : 入荷一覧表のSQLを作成して戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2008.01.31</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ArrivalListParamWork arrivalListParamWork)
        {

            string wherestring = "WHERE ";
            //固定条件
            //企業コード
            wherestring += "A.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(arrivalListParamWork.EnterpriseCode);

            //論理削除区分
            wherestring += "AND A.LOGICALDELETECODERF=0 ";
            wherestring += "AND B.LOGICALDELETECODERF=0 ";

            //仕入形式 (受注ステータス) (1：入荷)
            wherestring += "AND A.SUPPLIERFORMALRF=1 ";

            //これよりパラメータの値により動的変化の項目
            //拠点コード (配列)
            if (arrivalListParamWork.SectionCodes.Length > 0)
            {
                string[] sections = arrivalListParamWork.SectionCodes;

                for (int i = 0; i < sections.Length; i++)
                {
                    sections[i] = "'" + sections[i] + "'";
                }

                string inText = string.Join(", ", sections);

                wherestring += "AND A.STOCKSECTIONCDRF IN (" + inText + ") ";
            }

            //開始得意先コード
            if (arrivalListParamWork.SupplierCdSt != 0)
            {
                wherestring += "AND A.SUPPLIERCDRF>=@SUPPLIERCDST ";
                SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@SUPPLIERCDST", SqlDbType.Int);
                paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(arrivalListParamWork.SupplierCdSt);
            }

            //終了得意先コード
            if (arrivalListParamWork.SupplierCdEd != 0)
            {
                wherestring += "AND A.SUPPLIERCDRF<=@SUPPLIERCDED ";
                SqlParameter paraSupplierCdEd = sqlCommand.Parameters.Add("@SUPPLIERCDED", SqlDbType.Int);
                paraSupplierCdEd.Value = SqlDataMediator.SqlSetInt32(arrivalListParamWork.SupplierCdEd);
            }

            // 2008.06.24 del start ---------------------------------------------------->>
            //開始仕入入力者コード
            //if (arrivalListParamWork.StockInputCodeSt != "")
            //{
            //    wherestring += "AND A.STOCKINPUTCODERF>=@STOCKINPUTCODEST ";
            //    SqlParameter paraStockInputCodeSt = sqlCommand.Parameters.Add("@STOCKINPUTCODEST", SqlDbType.NChar);
            //    paraStockInputCodeSt.Value = SqlDataMediator.SqlSetString(arrivalListParamWork.StockInputCodeSt);
            //}

            ////終了仕入入力者コード
            //if (arrivalListParamWork.StockInputCodeEd != "")
            //{
            //    wherestring += "AND A.STOCKINPUTCODERF<=@STOCKINPUTCODEED ";
            //    SqlParameter paraStockInputCodeEd = sqlCommand.Parameters.Add("@STOCKINPUTCODEED", SqlDbType.NChar);
            //    paraStockInputCodeEd.Value = SqlDataMediator.SqlSetString(arrivalListParamWork.StockInputCodeEd);
            //}
            // 2008.06.24 del end ------------------------------------------------------<<

            //開始仕入担当者コード
            if (arrivalListParamWork.StockAgentCodeSt != "")
            {
                wherestring += "AND A.STOCKAGENTCODERF>=@STOCKAGENTCODEST ";
                SqlParameter paraStockAgentCodeSt = sqlCommand.Parameters.Add("@STOCKAGENTCODEST", SqlDbType.NChar);
                paraStockAgentCodeSt.Value = SqlDataMediator.SqlSetString(arrivalListParamWork.StockAgentCodeSt);
            }

            //終了仕入担当者コード
            if (arrivalListParamWork.StockAgentCodeEd != "")
            {
                wherestring += "AND A.STOCKAGENTCODERF<=@STOCKAGENTCODEED ";
                SqlParameter paraStockAgentCodeEd = sqlCommand.Parameters.Add("@STOCKAGENTCODEED", SqlDbType.NChar);
                paraStockAgentCodeEd.Value = SqlDataMediator.SqlSetString(arrivalListParamWork.StockAgentCodeEd);
            }

            //開始仕入伝票番号
            if (arrivalListParamWork.SupplierSlipNoSt != 0)
            {
                wherestring += "AND A.SUPPLIERSLIPNORF>=@SUPPLIERSLIPNOST ";
                SqlParameter paraSupplierSlipNoSt = sqlCommand.Parameters.Add("@SUPPLIERSLIPNOST", SqlDbType.Int);
                paraSupplierSlipNoSt.Value = SqlDataMediator.SqlSetInt32(arrivalListParamWork.SupplierSlipNoSt);
            }

            //終了仕入伝票番号
            if (arrivalListParamWork.SupplierSlipNoEd != 0)
            {
                wherestring += "AND A.SUPPLIERSLIPNORF<=@SUPPLIERSLIPNOED ";
                SqlParameter paraSupplierSlipNoEd = sqlCommand.Parameters.Add("@SUPPLIERSLIPNOED", SqlDbType.Int);
                paraSupplierSlipNoEd.Value = SqlDataMediator.SqlSetInt32(arrivalListParamWork.SupplierSlipNoEd);
            }

            //開始仕入日
            if (arrivalListParamWork.StockDateSt != 0)
            {
                wherestring += "AND A.STOCKDATERF>=@STOCKDATEST ";
                SqlParameter paraStockDateSt = sqlCommand.Parameters.Add("@STOCKDATEST", SqlDbType.Int);
                paraStockDateSt.Value = SqlDataMediator.SqlSetInt32(arrivalListParamWork.StockDateSt);
            }

            //終了仕入日
            if (arrivalListParamWork.StockDateEd != 0)
            {
                wherestring += "AND A.STOCKDATERF<=@STOCKDATEED ";
                SqlParameter paraStockDateEd = sqlCommand.Parameters.Add("@STOCKDATEED", SqlDbType.Int);
                paraStockDateEd.Value = SqlDataMediator.SqlSetInt32(arrivalListParamWork.StockDateEd);
            }

            //開始入荷日
            if (arrivalListParamWork.ArrivalGoodsDaySt != 0)
            {
                wherestring += "AND A.ARRIVALGOODSDAYRF>=@ARRIVALGOODSDAYST ";
                SqlParameter paraArrivalGoodsDaySt = sqlCommand.Parameters.Add("@ARRIVALGOODSDAYST", SqlDbType.Int);
                paraArrivalGoodsDaySt.Value = SqlDataMediator.SqlSetInt32(arrivalListParamWork.ArrivalGoodsDaySt);
            }

            //終了入荷日
            if (arrivalListParamWork.ArrivalGoodsDayEd != 0)
            {
                wherestring += "AND A.ARRIVALGOODSDAYRF<=@ARRIVALGOODSDAYED ";
                SqlParameter paraArrivalGoodsDayEd = sqlCommand.Parameters.Add("@ARRIVALGOODSDAYED", SqlDbType.Int);
                paraArrivalGoodsDayEd.Value = SqlDataMediator.SqlSetInt32(arrivalListParamWork.ArrivalGoodsDayEd);
            }

            //開始入力日
            if (arrivalListParamWork.InputDaySt != 0)
            {
                wherestring += "AND A.INPUTDAYRF>=@INPUTDAYST ";
                SqlParameter paraInputDaySt = sqlCommand.Parameters.Add("@INPUTDAYST", SqlDbType.Int);
                paraInputDaySt.Value = SqlDataMediator.SqlSetInt32(arrivalListParamWork.InputDaySt);
            }

            //終了入力日
            if (arrivalListParamWork.InputDayEd != 0)
            {
                wherestring += "AND A.INPUTDAYRF<=@INPUTDAYED ";
                SqlParameter paraInputDayEd = sqlCommand.Parameters.Add("@INPUTDAYED", SqlDbType.Int);
                paraInputDayEd.Value = SqlDataMediator.SqlSetInt32(arrivalListParamWork.InputDayEd);
            }

            // 2009/02/13 MAINTIS 11154>>>>>>>>>>>>>>>>>>
            ////発行タイプ
            ////0:全て印刷,1:入荷計上
            //if (arrivalListParamWork.MakeShowDiv == 1)
            //{
            //    //発注残数>0
            //    wherestring += "AND B.ORDERREMAINCNTRF>0 ";
            //}
            // 2009/02/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            //伝票区分
            //0:入荷,1:返品,2:入荷＋返品
            if (arrivalListParamWork.SlipDiv == 0)
            {
                wherestring += "AND A.SUPPLIERSLIPCDRF=10 ";
            }
            else if (arrivalListParamWork.SlipDiv == 1)
            {
                wherestring += "AND A.SUPPLIERSLIPCDRF=20 ";
            }

            //赤伝区分
            //0:黒伝,1:赤伝,2:元黒,3:全て
            if (arrivalListParamWork.DebitNoteDiv == 0)
            {
                wherestring += "AND A.DEBITNOTEDIVRF=0 ";
            }
            else if (arrivalListParamWork.DebitNoteDiv == 1)
            {
                wherestring += "AND A.DEBITNOTEDIVRF=1 ";
            }
            else if (arrivalListParamWork.DebitNoteDiv == 2)
            {
                wherestring += "AND A.DEBITNOTEDIVRF=2 ";
            }

            // 2009/04/07 ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>
            //開始相手先伝票番号
            if (string.IsNullOrEmpty(arrivalListParamWork.St_PartySaleSlipNum) == false)
            {
                wherestring += "AND A.PARTYSALESLIPNUMRF>=@PARTYSALESLIPNUMST ";
                SqlParameter paraPartySaleSlipNumSt = sqlCommand.Parameters.Add("@PARTYSALESLIPNUMST", SqlDbType.NVarChar);
                paraPartySaleSlipNumSt.Value = SqlDataMediator.SqlSetString(arrivalListParamWork.St_PartySaleSlipNum);
            }
            //終了相手先伝票番号
            if (string.IsNullOrEmpty(arrivalListParamWork.Ed_PartySaleSlipNum) == false)
            {
                wherestring += "AND A.PARTYSALESLIPNUMRF<=@PARTYSALESLIPNUMED ";
                SqlParameter paraPartySaleSlipNumEd = sqlCommand.Parameters.Add("@PARTYSALESLIPNUMED", SqlDbType.NVarChar);
                paraPartySaleSlipNumEd.Value = SqlDataMediator.SqlSetString(arrivalListParamWork.Ed_PartySaleSlipNum);
            }
            // 2009/04/07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return wherestring;
        }
        #endregion


        #region [ORDER BY句生成処理]
        /// <summary>
        /// ORDER BY句生成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="arrivalListParamWork">検索条件格納クラス</param>
        /// <returns>入荷一覧表のSQL文字列</returns>
        /// <br>Note       : 入荷一覧表のSQLを作成して戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.10.23</br>
        private string MakeOrderByString(ref SqlCommand sqlCommand, ArrivalListParamWork arrivalListParamWork)
        {
            //0:得意先→入荷日→伝票番号、
            //1:入荷日→得意先→伝票番号、
            //2:担当者→得意先→入荷日→伝票番号、
            //3:入荷日→伝票番号、
            //4:伝票番号

            string sqlstring = "";
            switch (arrivalListParamWork.SortOrder)
            {
                case 0:
                    sqlstring += "ORDER BY A.STOCKSECTIONCDRF, A.SUPPLIERCDRF, A.ARRIVALGOODSDAYRF, A.SUPPLIERSLIPNORF, B.STOCKROWNORF ";
                    break;
                case 1:
                    sqlstring += "ORDER BY A.STOCKSECTIONCDRF, A.ARRIVALGOODSDAYRF, A.SUPPLIERCDRF, A.SUPPLIERSLIPNORF, B.STOCKROWNORF ";
                    break;
                case 2:
                    sqlstring += "ORDER BY A.STOCKSECTIONCDRF, A.STOCKAGENTCODERF, A.SUPPLIERCDRF, A.ARRIVALGOODSDAYRF, A.SUPPLIERSLIPNORF, B.STOCKROWNORF ";
                    break;
                case 3:
                    sqlstring += "ORDER BY A.STOCKSECTIONCDRF, A.ARRIVALGOODSDAYRF, A.SUPPLIERSLIPNORF, B.STOCKROWNORF ";
                    break;
                case 4:
                    sqlstring += "ORDER BY A.STOCKSECTIONCDRF, A.SUPPLIERSLIPNORF, B.STOCKROWNORF ";
                    break;
                default:
                    break;
            }
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
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2008.01.31</br>
        /// </remarks>
        private ArrivalListResultWork CopyToArrivalListResultWorkFromReader(ref SqlDataReader myReader)
        {
            ArrivalListResultWork arrivalListResultWork = new ArrivalListResultWork();

            #region クラスへ格納
            arrivalListResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            arrivalListResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            arrivalListResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            arrivalListResultWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            arrivalListResultWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
            arrivalListResultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            arrivalListResultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            arrivalListResultWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            arrivalListResultWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            arrivalListResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            arrivalListResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            arrivalListResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            arrivalListResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            arrivalListResultWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            arrivalListResultWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            arrivalListResultWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            arrivalListResultWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            arrivalListResultWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            arrivalListResultWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
            arrivalListResultWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
            arrivalListResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            arrivalListResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            arrivalListResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            arrivalListResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            arrivalListResultWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            arrivalListResultWork.OrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERCNTRF"));
            arrivalListResultWork.OrderAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERADJUSTCNTRF"));
            arrivalListResultWork.OrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERREMAINCNTRF"));
            arrivalListResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            arrivalListResultWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
            arrivalListResultWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            arrivalListResultWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
            arrivalListResultWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
            arrivalListResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            arrivalListResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            arrivalListResultWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));

            // 2009/04/07 ADD >>>>>>>>>>>>>>>>>>
            arrivalListResultWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            arrivalListResultWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            arrivalListResultWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            arrivalListResultWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            arrivalListResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            arrivalListResultWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            arrivalListResultWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
            arrivalListResultWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            // 2009/04/07 <<<<<<<<<<<<<<<<<<<<<
            #endregion

            return arrivalListResultWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2008.01.31</br>
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