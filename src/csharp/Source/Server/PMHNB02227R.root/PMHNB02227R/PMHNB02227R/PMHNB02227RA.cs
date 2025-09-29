//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上不整合確認表
// プログラム概要   : 売上不整合確認表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;

namespace Broadleaf.Application.Remoting
{


    /// <summary>
    /// 売上不整合確認表リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上不整合確認表リモートオブジェクトの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.04.10</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SalesStockInfoTableDB : RemoteDB, ISalesStockInfoTableDB
    {
        #region [Const]
        /// <summary>エラーフラグ </summary>
        const string saleOnleFlgConst = "2";
        /// <summary>エラーフラグ </summary>
        const string errFlgConst = "1";
        /// <summary>正常フラグ </summary>
        const string normalFlgConst = "0";
        /// <summary>共通 日付フォーマット yyyyMMdd </summary>
        public const string ct_DateFomat = "yyyyMMdd";
        /// <summary>共通 日付フォーマット yyyy/MM/dd</summary>
        public const string ct_DateFomatWithLine = "yyyy/MM/dd";
        /// <summary>共通 -1</summary>
        public const int ct_UnderZeroFlgConst = -1;
        #endregion

        #region [Constructor]
        /// <summary>
        /// 売上不整合確認表一覧表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上不整合確認表リモートオブジェクトを行います。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.10</br>
        /// </remarks>
        public SalesStockInfoTableDB()
            :
            base("PMHNB02229D", "Broadleaf.Application.Remoting.ParamData.SalesStockInfoWork", "SalesStockInfoTableDB")
        {
        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件の売上不整合確認表一覧表情報LISTを戻します
        /// </summary>
        /// <param name="stockSalesInfoWork">検索結果</param>
        /// <param name="paraStockSalesInfoCndWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上不整合確認表一覧表情報LISTを戻しますことを行います。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.10</br>
        public int Search(out object stockSalesInfoWork, object paraStockSalesInfoCndWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            stockSalesInfoWork = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (null == sqlConnection)
                {
                    return status;
                }
                sqlConnection.Open();

                return SearchStockSalesInfoProc(out stockSalesInfoWork, paraStockSalesInfoCndWork, ref sqlConnection);
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "SalesStockInfoTableDB.Search");
                stockSalesInfoWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesStockInfoTableDB.Search");
                stockSalesInfoWork = new ArrayList();
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
        /// 指定された条件の売上不整合確認表一覧表情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objStockSalesInfoWork">検索結果</param>
        /// <param name="paraStockSalesInfoCndWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上不整合確認表一覧表情報LISTを戻しますこと(外部からのSqlConnectionを使用)を行います。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.10</br>
        public int SearchStockSalesInfoProc(out object objStockSalesInfoWork, object paraStockSalesInfoCndWork, ref SqlConnection sqlConnection)
        {
            SalesStockInfoMainCndtnWork salesStockInfoMainCndtnWork = paraStockSalesInfoCndWork as SalesStockInfoMainCndtnWork;
            ArrayList stockSalesInfoWorkList = null;
            int status = SearchStockSalesInfoProc(out stockSalesInfoWorkList, salesStockInfoMainCndtnWork, ref sqlConnection);
            objStockSalesInfoWork = stockSalesInfoWorkList;
            return status;
        }



        /// <summary>
        /// 指定された条件の売上不整合確認表一覧表情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockSalesInfoWorkList">検索結果</param>
        /// <param name="salesStockInfoMainCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上不整合確認表一覧表情報LISTを戻しますこと(外部からのSqlConnectionを使用)を行います。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.10</br>
        private int SearchStockSalesInfoProc(out ArrayList stockSalesInfoWorkList, SalesStockInfoMainCndtnWork salesStockInfoMainCndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            StringBuilder selectTxt = new StringBuilder(string.Empty);

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                selectTxt.Append("SELECT ");
                selectTxt.Append("  STOCKSALES.ENTERPRISECODE AS ENTERPRISECODE,  ");
                selectTxt.Append("  STOCKSALES.SUPPLIERSLIPNO AS SUPPLIERSLIPNO,  ");
                selectTxt.Append("  STOCKSALES.STOCKROWNO AS STOCKROWNO,  ");

                selectTxt.Append("  STOCKSALES.SUPPLIERFORMALSYNC AS SUPPLIERFORMALSYNC,  ");
                selectTxt.Append("  STOCKSALES.STOCKSLIPDTLNUMSYNC AS STOCKSLIPDTLNUMSYNC,  ");
                selectTxt.Append("  STOCKSALES.SECTIONCODE AS SECTIONCODE,  ");
                selectTxt.Append("  STOCKSALES.CUSTOMERCODE AS CUSTOMERCODE,  ");
                selectTxt.Append("  STOCKSALES.CUSTOMERSNM AS CUSTOMERSNM,  ");
                selectTxt.Append("  STOCKSALES.SALESDATE AS SALESDATE,  ");
                selectTxt.Append("  STOCKSALES.SEARCHSLIPDATE AS SEARCHSLIPDATE,  ");
                selectTxt.Append("  STOCKSALES.INPUTAGENCD AS INPUTAGENCD,  ");
                selectTxt.Append("  STOCKSALES.SALESINPUTCODE AS SALESINPUTCODE,  ");
                selectTxt.Append("  STOCKSALES.FRONTEMPLOYEECD AS FRONTEMPLOYEECD,  ");
                selectTxt.Append("  STOCKSALES.SALESEMPLOYEECD AS SALESEMPLOYEECD,  ");
                selectTxt.Append("  STOCKSALES.SALESAREACODE AS SALESAREACODE,  ");
                selectTxt.Append("  STOCKSALES.BUSINESSTYPECODE AS BUSINESSTYPECODE,  ");
                selectTxt.Append("  STOCKSALES.ACPTANODRSTATUS AS ACPTANODRSTATUS,  ");

                selectTxt.Append("  STOCKSALES.STOCKCOUNT AS STOCKCOUNT,  ");
                selectTxt.Append("  STOCKSALES.STOCKUNITPRICEFL AS STOCKUNITPRICEFL,  ");
                selectTxt.Append("  STOCKSALES.SHIPMENTCNT AS SHIPMENTCNT,  ");
                selectTxt.Append("  STOCKSALES.SALESUNITCOST AS SALESUNITCOST,  ");

                selectTxt.Append("  STOCKSALES.GOODSNO AS GOODSNO,  ");
                selectTxt.Append("  STOCKSALES.BLGOODSCODE AS BLGOODSCODE,  ");
                selectTxt.Append("  STOCKSALES.BLGROUPCODE AS BLGROUPCODE,  ");
                selectTxt.Append("  STOCKSALES.WAREHOUSECODE AS WAREHOUSECODE,  ");
                selectTxt.Append("  STOCKSALES.SUPPLIERCD AS SUPPLIERCD,  ");

                selectTxt.Append("  STOCKSALES.PARTYSALESLIPNUM AS PARTYSALESLIPNUM,  ");
                selectTxt.Append("  STOCKSALES.SALESSLIPNUM AS SALESSLIPNUM,  ");
                selectTxt.Append("  STOCKSALES.SALESROWNO AS SALESROWNO,  ");

                selectTxt.Append("  SEC.SECTIONCODERF,   ");
                selectTxt.Append("  SEC.LOGICALDELETECODERF  AS SECTIONCODELOGICALDELETECODERF,  ");
                selectTxt.Append("  SEC.SECTIONGUIDESNMRF AS SECTIONGUIDESNM,  ");

                selectTxt.Append("  CUST.CUSTOMERCODERF,  ");
                selectTxt.Append("  CUST.LOGICALDELETECODERF AS CUSTOMERCODELOGICALDELETECODERF,  ");

                selectTxt.Append("  EMPA.EMPLOYEECODERF AS AEMPLOYEECODE,  ");
                selectTxt.Append("  EMPA.LOGICALDELETECODERF AS AEMPLOYEECODELOGICALDELETECODERF,  ");

                selectTxt.Append("  EMPB.EMPLOYEECODERF AS BEMPLOYEECODE,  ");
                selectTxt.Append("  EMPB.LOGICALDELETECODERF AS BEMPLOYEECODELOGICALDELETECODERF,  ");

                selectTxt.Append("  EMPC.EMPLOYEECODERF AS CEMPLOYEECODE,  ");
                selectTxt.Append("  EMPC.LOGICALDELETECODERF AS CEMPLOYEECODELOGICALDELETECODERF,  ");

                selectTxt.Append("  EMPD.EMPLOYEECODERF AS DEMPLOYEECODE,  ");
                selectTxt.Append("  EMPD.LOGICALDELETECODERF AS DEMPLOYEECODELOGICALDELETECODERF,  ");

                selectTxt.Append("  BLGOODSCD.BLGOODSCODERF,  ");
                selectTxt.Append("  BLGOODSCD.LOGICALDELETECODERF AS BLGOODSCODELOGICALDELETECODERF,  ");

                selectTxt.Append("  BLGROUP.BLGROUPCODERF,  ");
                selectTxt.Append("  BLGROUP.LOGICALDELETECODERF AS BLGROUPCODELOGICALDELETECODERF,  ");

                selectTxt.Append("  WH.WAREHOUSECODERF,  ");
                selectTxt.Append("  WH.LOGICALDELETECODERF AS WAREHOUSECODELOGICALDELETECODERF,  ");

                selectTxt.Append("  SUPPLIER.SUPPLIERCDRF,  ");
                selectTxt.Append("  SUPPLIER.LOGICALDELETECODERF AS SUPPLIERCDLOGICALDELETECODERF,  ");

                selectTxt.Append("  USERA.GUIDECODERF AS AGUIDECODE,  ");
                selectTxt.Append("  USERA.LOGICALDELETECODERF AS AGUIDECODELOGICALDELETECODERF,  ");
                selectTxt.Append("  USERA.USERGUIDEDIVCDRF AS AUSERGUIDEDIVCDRF,  ");

                selectTxt.Append("  USERB.GUIDECODERF AS BGUIDECODE ,  ");
                selectTxt.Append("  USERB.LOGICALDELETECODERF AS BGUIDECODELOGICALDELETECODERF,  ");
                selectTxt.Append("  USERB.USERGUIDEDIVCDRF AS BUSERGUIDEDIVCDRF ");

                selectTxt.Append(" FROM ");
                selectTxt.Append("  (  SELECT ");
                //selectTxt.Append("  STOCK.ENTERPRISECODE AS ENTERPRISECODE,  ");
                selectTxt.Append("  STOCK.SUPPLIERSLIPNO AS SUPPLIERSLIPNO,  ");
                selectTxt.Append("  STOCK.STOCKROWNO AS STOCKROWNO,  ");
                selectTxt.Append("  STOCK.STOCKCOUNT AS STOCKCOUNT,  ");
                selectTxt.Append("  STOCK.STOCKUNITPRICEFL AS STOCKUNITPRICEFL,  ");
                selectTxt.Append("  STOCK.SUPPLIERCD AS SUPPLIERCD,  ");
                selectTxt.Append("  STOCK.PARTYSALESLIPNUM AS PARTYSALESLIPNUM,  ");

                selectTxt.Append("  SALES.ENTERPRISECODE AS ENTERPRISECODE,  ");
                selectTxt.Append("  SALES.SUPPLIERFORMALSYNC AS SUPPLIERFORMALSYNC,  ");
                selectTxt.Append("  SALES.STOCKSLIPDTLNUMSYNC AS STOCKSLIPDTLNUMSYNC,  ");
                selectTxt.Append("  SALES.ACPTANODRSTATUS AS ACPTANODRSTATUS,  ");

                selectTxt.Append("  SALES.SECTIONCODE AS SECTIONCODE,  ");
                selectTxt.Append("  SALES.CUSTOMERCODE AS CUSTOMERCODE,  ");
                selectTxt.Append("  SALES.CUSTOMERSNM AS CUSTOMERSNM,  ");
                selectTxt.Append("  SALES.SALESDATE AS SALESDATE,  ");
                //selectTxt.Append("  CAST( SALES.SALESDATE  AS NVARCHAR) AS SALESDATE,  ");
                selectTxt.Append("  SALES.SEARCHSLIPDATE AS SEARCHSLIPDATE,  ");
                selectTxt.Append("  SALES.INPUTAGENCD AS INPUTAGENCD,  ");
                selectTxt.Append("  SALES.SALESINPUTCODE AS SALESINPUTCODE,  ");
                selectTxt.Append("  SALES.FRONTEMPLOYEECD AS FRONTEMPLOYEECD,  ");
                selectTxt.Append("  SALES.SALESEMPLOYEECD AS SALESEMPLOYEECD,  ");
                selectTxt.Append("  SALES.SALESAREACODE AS SALESAREACODE,  ");
                selectTxt.Append("  SALES.BUSINESSTYPECODE AS BUSINESSTYPECODE,  ");

                selectTxt.Append("  SALES.GOODSNO AS GOODSNO,  ");
                selectTxt.Append("  SALES.BLGOODSCODE AS BLGOODSCODE,  ");
                selectTxt.Append("  SALES.BLGROUPCODE AS BLGROUPCODE,  ");
                selectTxt.Append("  SALES.WAREHOUSECODE AS WAREHOUSECODE,  ");
                //selectTxt.Append("  SALES.SUPPLIERCD AS SUPPLIERCD,  ");
                selectTxt.Append("  SALES.SHIPMENTCNT AS SHIPMENTCNT,  ");
                selectTxt.Append("  SALES.SALESUNITCOST AS SALESUNITCOST,  ");

                selectTxt.Append("  SALES.SALESROWNO AS SALESROWNO,  ");
                //selectTxt.Append("  SALES.PARTYSLIPNUMDTL AS PARTYSLIPNUMDTL,  ");
                selectTxt.Append("  SALES.SALESSLIPNUM AS SALESSLIPNUM  ");


                selectTxt.Append("FROM  ");

                selectTxt.Append("(SELECT ");
                selectTxt.Append("  SALSP.ENTERPRISECODERF AS ENTERPRISECODE,  ");
                selectTxt.Append("  SALSP.LOGICALDELETECODERF AS LOGICALDELETECODE,  ");
                selectTxt.Append("  SALDL.SUPPLIERFORMALSYNCRF AS SUPPLIERFORMALSYNC,  ");
                selectTxt.Append("  SALDL.STOCKSLIPDTLNUMSYNCRF AS STOCKSLIPDTLNUMSYNC,  ");
                selectTxt.Append("  SALDL.ACPTANODRSTATUSRF AS ACPTANODRSTATUS,  ");

                selectTxt.Append("  SALSP.RESULTSADDUPSECCDRF AS SECTIONCODE,  ");
                selectTxt.Append("  SALSP.CUSTOMERCODERF AS CUSTOMERCODE,  ");
                selectTxt.Append("  SALSP.CUSTOMERSNMRF AS CUSTOMERSNM,  ");
                
                selectTxt.Append("  SALSP.ADDUPADATERF AS SALESDATE,  ");
                selectTxt.Append("  SALSP.SEARCHSLIPDATERF AS SEARCHSLIPDATE,  ");
                selectTxt.Append("  SALSP.INPUTAGENCDRF AS INPUTAGENCD,  ");
                selectTxt.Append("  SALSP.SALESINPUTCODERF AS SALESINPUTCODE,  ");
                selectTxt.Append("  SALSP.FRONTEMPLOYEECDRF AS FRONTEMPLOYEECD,  ");
                selectTxt.Append("  SALSP.SALESEMPLOYEECDRF AS SALESEMPLOYEECD,  ");
                selectTxt.Append("  SALSP.SALESAREACODERF AS SALESAREACODE,  ");
                selectTxt.Append("  SALSP.BUSINESSTYPECODERF AS BUSINESSTYPECODE,  ");

                selectTxt.Append("  SALDL.GOODSNORF AS GOODSNO,  ");
                selectTxt.Append("  SALDL.BLGOODSCODERF AS BLGOODSCODE,  ");
                selectTxt.Append("  SALDL.BLGROUPCODERF AS BLGROUPCODE,  ");
                selectTxt.Append("  SALDL.WAREHOUSECODERF AS WAREHOUSECODE,  ");
                selectTxt.Append("  SALDL.SUPPLIERCDRF AS SUPPLIERCD,  ");
                selectTxt.Append("  SALDL.SHIPMENTCNTRF AS SHIPMENTCNT,  ");
                selectTxt.Append("  SALDL.SALESUNITCOSTRF AS SALESUNITCOST,  ");

                //selectTxt.Append("  SALDL.PARTYSLIPNUMDTLRF AS PARTYSLIPNUMDTL,  ");
                selectTxt.Append("  SALDL.SALESROWNORF AS SALESROWNO,  ");
                selectTxt.Append("  SALDL.SALESSLIPNUMRF AS SALESSLIPNUM  ");
                selectTxt.Append("FROM SALESSLIPRF AS SALSP ");
                selectTxt.Append("INNER JOIN SALESDETAILRF AS SALDL ");
                selectTxt.Append("ON");
                selectTxt.Append("     SALSP.ENTERPRISECODERF=SALDL.ENTERPRISECODERF ");
                selectTxt.Append(" AND SALSP.ACPTANODRSTATUSRF=SALDL.ACPTANODRSTATUSRF ");
                selectTxt.Append(" AND SALDL.ACPTANODRSTATUSRF = 30 ");
                //selectTxt.Append(" AND SALDL.SUPPLIERFORMALSYNCRF = 0 ");
                //selectTxt.Append(" AND SALDL.STOCKSLIPDTLNUMSYNCRF >0 ");
                selectTxt.Append(" AND SALSP.SALESSLIPNUMRF=SALDL.SALESSLIPNUMRF ");
                selectTxt.Append(" AND SALSP.LOGICALDELETECODERF=SALDL.LOGICALDELETECODERF ");
                selectTxt.Append(" AND SALSP.LOGICALDELETECODERF=0 ");
                selectTxt.Append(" ) AS SALES ");
                selectTxt.Append("LEFT JOIN ");


                selectTxt.Append("(SELECT ");
                selectTxt.Append("  STKDL.SUPPLIERFORMALRF AS SUPPLIERFORMAL,  ");
                selectTxt.Append("  STKDL.STOCKSLIPDTLNUMRF AS STOCKSLIPDTLNUM,  ");
                selectTxt.Append("  STKDL.ENTERPRISECODERF AS ENTERPRISECODE,  ");
                selectTxt.Append("  STKDL.LOGICALDELETECODERF AS LOGICALDELETECODE,  ");
                selectTxt.Append("  STKDL.SUPPLIERSLIPNORF AS SUPPLIERSLIPNO,  ");
                selectTxt.Append("  STKDL.STOCKCOUNTRF AS STOCKCOUNT,  ");
                selectTxt.Append("  STKDL.STOCKUNITPRICEFLRF AS STOCKUNITPRICEFL,  ");
                selectTxt.Append("  STKSP.SUPPLIERCDRF AS SUPPLIERCD,  ");
                selectTxt.Append("  STKSP.PARTYSALESLIPNUMRF AS PARTYSALESLIPNUM,  ");
                selectTxt.Append("  STKDL.STOCKROWNORF AS STOCKROWNO  ");
                selectTxt.Append("FROM STOCKSLIPRF AS STKSP ");
                selectTxt.Append("INNER JOIN STOCKDETAILRF AS STKDL ");
                selectTxt.Append("ON");
                selectTxt.Append("     STKSP.ENTERPRISECODERF=STKDL.ENTERPRISECODERF ");
                selectTxt.Append(" AND STKSP.SUPPLIERFORMALRF=STKDL.SUPPLIERFORMALRF ");
                selectTxt.Append(" AND STKSP.SUPPLIERSLIPNORF=STKDL.SUPPLIERSLIPNORF ");
                selectTxt.Append(" AND STKSP.LOGICALDELETECODERF=STKDL.LOGICALDELETECODERF ");
                selectTxt.Append(" AND STKSP.LOGICALDELETECODERF=0 ");
                selectTxt.Append(" ) AS STOCK ");




                selectTxt.Append("ON");
                selectTxt.Append("     STOCK.SUPPLIERFORMAL=SALES.SUPPLIERFORMALSYNC ");
                selectTxt.Append(" AND STOCK.STOCKSLIPDTLNUM=SALES.STOCKSLIPDTLNUMSYNC ");
                selectTxt.Append(" AND SALES.SUPPLIERFORMALSYNC = 0 ");
                selectTxt.Append(" AND SALES.STOCKSLIPDTLNUMSYNC >0 ");
                //selectTxt.Append(" AND SALES.ACPTANODRSTATUS = 30 ");
                selectTxt.Append(" AND STOCK.ENTERPRISECODE=SALES.ENTERPRISECODE ");
                selectTxt.Append(" AND STOCK.LOGICALDELETECODE=SALES.LOGICALDELETECODE ");



                selectTxt.Append(MakeWhereString(ref sqlCommand, salesStockInfoMainCndtnWork));
                selectTxt.Append(" ) AS  STOCKSALES");
                // 拠点情報設定マスタ SecInfoSetRF
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" SECINFOSETRF AS SEC ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.SECTIONCODE=SEC.SECTIONCODERF ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=SEC.ENTERPRISECODERF ");

                // 得意先マスタ  CustomerRF
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" CUSTOMERRF AS CUST ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.CUSTOMERCODE=CUST.CUSTOMERCODERF ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=CUST.ENTERPRISECODERF ");

                // 従業員マスタ  EmployeeRF 入力担当者コード
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" EMPLOYEERF AS EMPA ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.INPUTAGENCD=EMPA.EMPLOYEECODERF ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=EMPA.ENTERPRISECODERF ");

                // 従業員マスタ  EmployeeRF 売上入力者コード
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" EMPLOYEERF AS EMPB ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.SALESINPUTCODE=EMPB.EMPLOYEECODERF ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=EMPB.ENTERPRISECODERF ");

                // 従業員マスタ  EmployeeRF 受付従業員コード
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" EMPLOYEERF AS EMPC ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.FRONTEMPLOYEECD=EMPC.EMPLOYEECODERF ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=EMPC.ENTERPRISECODERF ");

                // 従業員マスタ  EmployeeRF 販売従業員コード
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" EMPLOYEERF AS EMPD ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.SALESEMPLOYEECD=EMPD.EMPLOYEECODERF ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=EMPD.ENTERPRISECODERF ");

                // ＢＬ商品コードマスタ(ユーザー)
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" BLGOODSCDURF AS BLGOODSCD ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.BLGOODSCODE=BLGOODSCD.BLGOODSCODERF ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=BLGOODSCD.ENTERPRISECODERF ");

                // BLグループマスタ（ユーザー登録分） BLGroupURF
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" BLGROUPURF AS BLGROUP ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.BLGROUPCODE=BLGROUP.BLGROUPCODERF ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=BLGROUP.ENTERPRISECODERF ");

                //  倉庫マスタ   WarehouseRF
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" WAREHOUSERF AS WH ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.WAREHOUSECODE=WH.WAREHOUSECODERF ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=WH.ENTERPRISECODERF ");

                // 仕入先マスタ SupplierRF
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" SUPPLIERRF AS SUPPLIER ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.SUPPLIERCD=SUPPLIER.SUPPLIERCDRF ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=SUPPLIER.ENTERPRISECODERF ");

                // エリア  ユーザーガイドマスタ（ボディ）（ユーザ変更分）  UserGdBdURF 
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" USERGDBDURF AS USERA ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.SALESAREACODE=USERA.GUIDECODERF ");
                selectTxt.Append(" AND USERA.USERGUIDEDIVCDRF=21 ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=USERA.ENTERPRISECODERF ");

                // 業種   ユーザーガイドマスタ（ボディ）（ユーザ変更分）  UserGdBdURF    
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" USERGDBDURF AS USERB ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.BUSINESSTYPECODE=USERB.GUIDECODERF ");
                selectTxt.Append(" AND USERB.USERGUIDEDIVCDRF=33 ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=USERB.ENTERPRISECODERF ");

                selectTxt.Append(" WHERE ");
                // 拠点情報設定マスタ SecInfoSetRF
                selectTxt.Append("  SEC.SECTIONCODERF IS NULL  ");
                selectTxt.Append("  OR  (  SEC.LOGICALDELETECODERF=1 AND  SEC.SECTIONCODERF IS NOT NULL ) ");
                // 得意先マスタ  CustomerRF
                selectTxt.Append("  OR CUST.CUSTOMERCODERF IS NULL  ");
                selectTxt.Append("  OR  (  CUST.LOGICALDELETECODERF=1 AND  CUST.CUSTOMERCODERF IS NOT NULL ) ");
                // 従業員マスタ  EmployeeRF  入力担当者コード
                selectTxt.Append("  OR EMPA.EMPLOYEECODERF IS NULL  ");
                selectTxt.Append("  OR  (  EMPA.LOGICALDELETECODERF=1 AND  EMPA.EMPLOYEECODERF IS NOT NULL ) ");
                // 従業員マスタ  EmployeeRF  売上入力者コード
                selectTxt.Append("  OR EMPB.EMPLOYEECODERF IS NULL  ");
                selectTxt.Append("  OR  (  EMPB.LOGICALDELETECODERF=1 AND  EMPB.EMPLOYEECODERF IS NOT NULL ) ");

                // 従業員マスタ  EmployeeRF  受付従業員コード
                selectTxt.Append("  OR EMPC.EMPLOYEECODERF IS NULL  ");
                selectTxt.Append("  OR  (  EMPC.LOGICALDELETECODERF=1 AND  EMPC.EMPLOYEECODERF IS NOT NULL ) ");

                // 従業員マスタ  EmployeeRF  販売従業員コード
                selectTxt.Append("  OR EMPD.EMPLOYEECODERF IS NULL  ");
                selectTxt.Append("  OR  (  EMPD.LOGICALDELETECODERF=1 AND  EMPD.EMPLOYEECODERF IS NOT NULL ) ");

                // ＢＬ商品コードマスタ(ユーザー)
                selectTxt.Append("  OR BLGOODSCD.BLGOODSCODERF IS NULL  ");
                selectTxt.Append("  OR  (  BLGOODSCD.LOGICALDELETECODERF=1 AND  BLGOODSCD.BLGOODSCODERF IS NOT NULL ) ");
                // BLグループマスタ（ユーザー登録分）
                selectTxt.Append("  OR BLGROUP.BLGROUPCODERF IS NULL  ");
                selectTxt.Append("  OR  (  BLGROUP.LOGICALDELETECODERF=1 AND  BLGROUP.BLGROUPCODERF IS NOT NULL ) ");
                // 倉庫マスタ
                selectTxt.Append("  OR WH.WAREHOUSECODERF IS NULL  ");
                selectTxt.Append("  OR  (  WH.LOGICALDELETECODERF=1 AND  WH.WAREHOUSECODERF IS NOT NULL ) ");
                // 仕入先マスタ
                selectTxt.Append("  OR SUPPLIER.SUPPLIERCDRF IS NULL  ");
                selectTxt.Append("  OR  (  SUPPLIER.LOGICALDELETECODERF=1 AND  SUPPLIER.SUPPLIERCDRF IS NOT NULL ) ");
                // ユーザーガイドマスタ（ボディ）（ユーザ変更分）    
                selectTxt.Append("  OR USERA.GUIDECODERF IS NULL  ");
                selectTxt.Append("  OR  (  USERA.LOGICALDELETECODERF=1 AND  USERA.GUIDECODERF IS NOT NULL ) ");
                // ユーザーガイドマスタ（ボディ）（ユーザ変更分）    
                selectTxt.Append("  OR USERB.GUIDECODERF IS NULL  ");
                selectTxt.Append("  OR  (  USERB.LOGICALDELETECODERF=1 AND  USERB.GUIDECODERF IS NOT NULL ) ");


                selectTxt.Append(" ORDER BY STOCKSALES.SECTIONCODE , STOCKSALES.CUSTOMERCODE , STOCKSALES.SALESDATE ,STOCKSALES.SEARCHSLIPDATE ,STOCKSALES.SALESSLIPNUM ,STOCKSALES.SALESROWNO  ");

                sqlCommand.CommandText = selectTxt.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockSalesInfoWorkFromReader(ref myReader));

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                }
            }

            stockSalesInfoWorkList = al;

            return status;
        }
        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="salesStockInfoMainCndtnWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.10</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesStockInfoMainCndtnWork salesStockInfoMainCndtnWork)
        {

            string retstring = "WHERE ";

            // 企業コード
            if (!string.IsNullOrEmpty(salesStockInfoMainCndtnWork.EnterpriseCode))
            {
                retstring += "SALES.ENTERPRISECODE=@FINDENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesStockInfoMainCndtnWork.EnterpriseCode);
            }

            //retstring += "AND (STOCK.ENTERPRISECODE IS NULL OR STOCK.ENTERPRISECODE=SALES.ENTERPRISECODE )";

            // 論理削除区分
            retstring += " AND  SALES.LOGICALDELETECODE=0 ";
            //retstring += " AND (STOCK.LOGICALDELETECODE IS NULL OR STOCK.LOGICALDELETECODE=SALES.LOGICALDELETECODE )";



            // 拠点コード
            if (salesStockInfoMainCndtnWork.CollectAddupSecCodeList != null)
            {
                string sectionString = "";
                foreach (string sectionCode in salesStockInfoMainCndtnWork.CollectAddupSecCodeList)
                {
                    if (!string.Empty.Equals(sectionCode))
                    {
                        if (!string.Empty.Equals(sectionString))
                        {
                            sectionString += ",";
                        }
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (!string.Empty.Equals(sectionString))
                {
                    // 拠点コード
                    retstring += "AND SALES.SECTIONCODE IN (" + sectionString + ") ";
                }
            }

            // 売上日
            //if (salesStockInfoMainCndtnWork.YearMonth != DateTime.MinValue)
            //{
            //    int year = salesStockInfoMainCndtnWork.YearMonth.Year;
            //    int month = salesStockInfoMainCndtnWork.YearMonth.Month;
            //    if (month < 10)
            //    {
            //        retstring += "AND SALES.SALESDATE LIKE  " + "'" + year + "0" + month + "%" + "'";
            //    }
            //    else
            //    {
            //        retstring += "AND SALES.SALESDATE LIKE  " + "'" + year + month + "%" + "'";
            //    }
            //}

            // 売上日
            if (salesStockInfoMainCndtnWork.PrevTotalDay != DateTime.MinValue)
            {
                retstring += "AND SALES.SALESDATE>=@FINDPARAPREVTOTALDAY ";
                SqlParameter paraPrevTotalDay = sqlCommand.Parameters.Add("@FINDPARAPREVTOTALDAY", SqlDbType.Int);
                //paraPrevTotalDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesStockInfoMainCndtnWork.PrevTotalDay.AddDays(1.0));
                paraPrevTotalDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesStockInfoMainCndtnWork.PrevTotalDay);
            }

            if (salesStockInfoMainCndtnWork.CurrentTotalDay != DateTime.MinValue)
            {
                retstring += "AND SALES.SALESDATE<=@FINDPARACURRENTTOTALDAY ";
                SqlParameter paraCurrentTotalDay = sqlCommand.Parameters.Add("@FINDPARACURRENTTOTALDAY", SqlDbType.Int);
                paraCurrentTotalDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesStockInfoMainCndtnWork.CurrentTotalDay);
            }

            return retstring;
        }



        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → RsltInfo_DispatchInstsWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>wkStockSalesInfoWork</returns>
        /// <remarks>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.10</br>
        /// </remarks>
        private SalesStockInfoWork CopyToStockSalesInfoWorkFromReader(ref SqlDataReader myReader)
        {
            SalesStockInfoWork wkStockSalesInfoWork = new SalesStockInfoWork();


            #region クラスへ格納
            // 拠点コードヘッダヘッダ
            wkStockSalesInfoWork.SectionCodeHeader = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODE"));


            // 拠点名称
            wkStockSalesInfoWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNM"));

            // 得意先コードヘッダ
            wkStockSalesInfoWork.CustomerCodeHeader = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODE"));

            // 得意先略称
            wkStockSalesInfoWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNM"));

            // 売上日付		Int32		SalesDateRF
            // wkStockSalesInfoWork.SalesDate = Convert.ToInt32(SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESDATE")));
            wkStockSalesInfoWork.SalesDate = Convert.ToInt32(SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESDATE")));

            // 伝票検索日付		Int32	StockDateRF
            wkStockSalesInfoWork.SearchSlipDate = Convert.ToDateTime(DateTime.ParseExact(SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHSLIPDATE")).ToString(), ct_DateFomat, null).ToString(ct_DateFomatWithLine));

            // 相手先伝票番号（明細）		nvarchar		PartySlipNumDtlRF   PARTYSALESLIPNUM
            // wkStockSalesInfoWork.PartySlipNumDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSLIPNUMDTL"));
            wkStockSalesInfoWork.PartySlipNumDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUM"));

            // 仕入伝票番号		Int32	SupplierSlipNoRF
            Int32 tempSupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNO"));
            wkStockSalesInfoWork.SupplierSlipNo = tempSupplierSlipNo;

            // 仕入行番号		Int32		StockRowNoRF
            wkStockSalesInfoWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNO"));


            // 売上伝票番号		nchar		SalesSlipNumRF
            wkStockSalesInfoWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUM"));

            // 売上行番号		nchar		SalesRowNoRF
            wkStockSalesInfoWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNO"));


            // 不整合内容		nvarchar		NayiYouRF
            // wkStockSalesInfoWork.NayiYou = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNM"));

            // マスタのチック
            // 拠点コード
            string tmpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            int tmpSectionCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECTIONCODELOGICALDELETECODERF"));
            if ((string.IsNullOrEmpty(tmpSectionCode)) || ((!(string.IsNullOrEmpty(tmpSectionCode))) && (tmpSectionCodeDelete == 1)))
            {
                wkStockSalesInfoWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODE"));
            }

            // 入力担当者コード
            string tmpAEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AEMPLOYEECODE"));
            int tmpAEmployeeCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AEMPLOYEECODELOGICALDELETECODERF"));
            if ((string.IsNullOrEmpty(tmpAEmployeeCode)) || ((!(string.IsNullOrEmpty(tmpAEmployeeCode))) && (tmpAEmployeeCodeDelete == 1)))
            {
                wkStockSalesInfoWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCD"));
            }

            // 売上入力者コード
            string tmpBEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BEMPLOYEECODE"));
            int tmpBEmployeeCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BEMPLOYEECODELOGICALDELETECODERF"));
            if ((string.IsNullOrEmpty(tmpBEmployeeCode)) || ((!(string.IsNullOrEmpty(tmpBEmployeeCode))) && (tmpBEmployeeCodeDelete == 1)))
            {
                wkStockSalesInfoWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODE"));
            }

            // 受付従業員コード
            string tmpCEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CEMPLOYEECODE"));
            int tmpCEmployeeCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CEMPLOYEECODELOGICALDELETECODERF"));
            if ((string.IsNullOrEmpty(tmpCEmployeeCode)) || ((!(string.IsNullOrEmpty(tmpCEmployeeCode))) && (tmpCEmployeeCodeDelete == 1)))
            {
                wkStockSalesInfoWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECD"));
            }

            // 販売従業員コード
            string tmpDEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMPLOYEECODE"));
            int tmpDEmployeeCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEMPLOYEECODELOGICALDELETECODERF"));
            if ((string.IsNullOrEmpty(tmpDEmployeeCode)) || ((!(string.IsNullOrEmpty(tmpDEmployeeCode))) && (tmpDEmployeeCodeDelete == 1)))
            {
                wkStockSalesInfoWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECD"));
            }


            // 得意先マスタ
            int tmpCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            int tmpCustomerCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODELOGICALDELETECODERF"));
            if ((tmpCustomerCode <= 0) || ((tmpCustomerCode > 0) && (tmpCustomerCodeDelete == 1)))
            {
                // 得意先コード		Int32		CustomerCodeRF
                wkStockSalesInfoWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODE"));
            }
            else
            {
                wkStockSalesInfoWork.CustomerCode = ct_UnderZeroFlgConst;
            }

            // BL商品マスタ
            string goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNO"));
            if (!string.IsNullOrEmpty(goodsNo))
            {
                int tmpBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                int blGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODE"));
                int tmpBLGoodsCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODELOGICALDELETECODERF"));
                if (((tmpBLGoodsCode >= 0)
                    && (blGoodsCode >= 0)
                    && (tmpBLGoodsCode != blGoodsCode))
                    || ((tmpBLGoodsCode > 0) && (tmpBLGoodsCodeDelete == 1)))
                {
                    // BL商品コード		Int32		BLGoodsCodeRF
                    wkStockSalesInfoWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODE"));
                }
                else
                {
                    wkStockSalesInfoWork.BLGoodsCode = ct_UnderZeroFlgConst;
                }
            }
            else 
            {
                wkStockSalesInfoWork.BLGoodsCode = ct_UnderZeroFlgConst;
            }

            // BLグループマスタ
            int tmpBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            int blGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODE"));
            int tmpBLGroupCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODELOGICALDELETECODERF"));
            if (((tmpBLGroupCode >= 0)
                && (blGroupCode >= 0)
                && (tmpBLGroupCode != blGroupCode))
                || ((tmpBLGroupCode > 0) && (tmpBLGroupCodeDelete == 1)))
            {
                // BLグループコード		Int32	BLGroupCodeRF
                wkStockSalesInfoWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODE"));
            }
            else
            {
                wkStockSalesInfoWork.BLGroupCode = ct_UnderZeroFlgConst;
            }

            // 倉庫マスタ
            string tmpWarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            string warehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODE"));
            int tmpWarehouseCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAREHOUSECODELOGICALDELETECODERF"));
            //if (((!(string.IsNullOrEmpty(tmpWarehouseCode)))
            //    && (!(string.IsNullOrEmpty(warehouseCode)))
            //    && ((!("0".Equals(warehouseCode.TrimEnd())))))
            //    || 
            if (((string.IsNullOrEmpty(tmpWarehouseCode))
            && (!string.IsNullOrEmpty(warehouseCode))
            && ((!("0".Equals(warehouseCode.TrimEnd())))))
            || ((!(string.IsNullOrEmpty(tmpWarehouseCode))) && (tmpWarehouseCodeDelete == 1)))
            {
                // 倉庫コード		nchar		WarehouseCodeRF
                wkStockSalesInfoWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODE"));
            }

            // エリア    AGUIDECODE
            int tmpAGuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AGUIDECODE"));
            int guideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODE"));
            int tmpAGuideCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AGUIDECODELOGICALDELETECODERF"));
            int temAUserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUSERGUIDEDIVCDRF"));
            if (((tmpAGuideCode >= 0) &&
                (guideCode >= 0) && (tmpAGuideCode != guideCode))
                || ((tmpAGuideCode > 0) && (tmpAGuideCodeDelete == 1)))
                //|| ((tmpAGuideCode >= 0) && (tmpAGuideCodeDelete == 1))
                //|| ((tmpAGuideCode == 0) && (guideCode == 0) && (tmpAGuideCodeDelete == 0) && (temAUserGuideDivCd == 0)))
            {
                // 倉庫コード		nchar		WarehouseCodeRF
                wkStockSalesInfoWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODE"));
            }
            else
            {
                wkStockSalesInfoWork.SalesAreaCode = ct_UnderZeroFlgConst;
            }

            // 業種
            int tmpBGuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BGUIDECODE"));
            int bGuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODE"));
            int tmpBGuideCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BGUIDECODELOGICALDELETECODERF"));
            int temBUserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSERGUIDEDIVCDRF"));
            if (((tmpBGuideCode >= 0) && (bGuideCode >= 0) && (tmpBGuideCode != bGuideCode))
                || ((tmpBGuideCode > 0) && (tmpBGuideCodeDelete == 1)))
                //|| ((tmpBGuideCode >= 0) && (tmpBGuideCodeDelete == 1))
                //|| ((tmpBGuideCode == 0) && (bGuideCode == 0) && (tmpBGuideCodeDelete == 0) && (temBUserGuideDivCd == 0)))
            {
                // 倉庫コード		nchar		WarehouseCodeRF
                wkStockSalesInfoWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODE"));
            }
            else
            {
                wkStockSalesInfoWork.BusinessTypeCode = ct_UnderZeroFlgConst;
            }

            // 仕入先マスタ
            int tmpSupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            int supplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCD"));
            int tmpSupplierCdDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDLOGICALDELETECODERF"));
            if (((tmpSupplierCd >= 0) && (supplierCd >= 0)
                && (tmpSupplierCd != supplierCd)) || ((tmpSupplierCd > 0) && (tmpSupplierCdDelete == 1)))
            {
                // 仕入先コード		Int32 SupplierCdRF ヘッダ
                wkStockSalesInfoWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCD"));
            }
            else
            {
                wkStockSalesInfoWork.SupplierCd = ct_UnderZeroFlgConst;
            }

            // 存在チェック
            Int32 SupplierFormalSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSYNC"));
            Int64 StockSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSYNC"));
            if (SupplierFormalSync == 0 && StockSlipDtlNumSync > 0)
            {
                if (tempSupplierSlipNo > 0)
                {
                    wkStockSalesInfoWork.ExistFlg = normalFlgConst;
                }
                else
                {
                    wkStockSalesInfoWork.ExistFlg = errFlgConst;
                }
            }
            else
            {
                wkStockSalesInfoWork.ExistFlg = saleOnleFlgConst;
            }

            // 数量
            double salesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT"));
            double stockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNT"));
            if (salesCount != stockCount)
            {
                wkStockSalesInfoWork.CountFlg = errFlgConst;
            }
            else
            {
                wkStockSalesInfoWork.CountFlg = normalFlgConst;
            }

            // 原価
            double salesPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOST"));
            double stockPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFL"));
            if (salesPrice != stockPrice)
            {
                wkStockSalesInfoWork.PriceFlg = errFlgConst;
            }
            else
            {
                wkStockSalesInfoWork.PriceFlg = normalFlgConst;
            }

            #endregion クラスへ格納
            return wkStockSalesInfoWork;
        }


        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.10</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
