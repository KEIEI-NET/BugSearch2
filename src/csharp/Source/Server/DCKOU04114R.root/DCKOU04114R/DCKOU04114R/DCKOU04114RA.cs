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
    /// 仕入履歴照会DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入履歴照会に必要なデータ取得を行うクラスです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.09.21</br>
    /// <br></br>
    /// <br>Update Note: ＰＭ.ＮＳ用に変更</br>
    /// <br>Programmer : 20081　疋田　勇人</br>
    /// <br>Date       : 2008.06.25</br>
    /// <br></br>
    /// <br>Update Note: 不具合修正</br>
    /// <br>Programmer : 23012　畠中 啓次朗</br>
    /// <br>Date       : 2008.11.27</br>
    /// <br></br>
    /// <br>Update Note: 速度チューニング</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2010/05/10</br>
    /// <br>Update Note: 鄧潘ハン</br>
    /// <br>Date       : 2011/03/22</br>
    /// <br>             照会プログラムのログ出力対応</br>
    /// </remarks>
    [Serializable]
    public class StcHisRefDataDB : RemoteDB, IStcHisRefDataDB
    {
        /// <summary>
        /// 仕入履歴照会DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.21</br>
        /// </remarks>
        public StcHisRefDataDB()
            :
            base("DCKOU04116D", "Broadleaf.Application.Remoting.ParamData.StcHisRefDataWork", "STCHISREFDATARF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の仕入履歴照会情報LISTを戻します
        /// </summary>
        /// <param name="stchisrefDataWork">検索結果</param>
        /// <param name="paramstchisrefExtraWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入履歴照会情報LISTを戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.21</br>
        public int Search(out object stchisrefDataWork, object paramstchisrefExtraWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stchisrefDataWork = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();

                if (sqlConnection == null) return status;

                sqlConnection.Open();

                return SearchStcHisRefDataProc(out stchisrefDataWork, paramstchisrefExtraWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StcHisRefDataDB.Search");
                stchisrefDataWork = new ArrayList();
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
        /// 指定された条件の仕入履歴照会情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objstchisrefDataWork">検索結果</param>
        /// <param name="paramstchisrefExtraWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入履歴照会情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.21</br>
        /// <br>Update Note: 鄧潘ハン</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             照会プログラムのログ出力対応</br>
        public int SearchStcHisRefDataProc(out object objstchisrefDataWork, object paramstchisrefExtraWork, ref SqlConnection sqlConnection)
        {
            StcHisRefExtraParamWork stchisrefextraParamWork = null;

            ArrayList paramstchisrefExtraWorkList = paramstchisrefExtraWork as ArrayList;

            if (paramstchisrefExtraWorkList == null)
            {
                stchisrefextraParamWork = paramstchisrefExtraWork as StcHisRefExtraParamWork;
            }
            else
            {
                if (paramstchisrefExtraWorkList.Count > 0)
                {
                    stchisrefextraParamWork = paramstchisrefExtraWorkList[0] as StcHisRefExtraParamWork;
                }
            }

            ArrayList retList = new ArrayList();
            // --- ADD 2011/03/22----------------------------------->>>>>
            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
            oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, stchisrefextraParamWork.EnterpriseCode, "仕入履歴照会", "抽出開始");
            // --- ADD 2011/03/22-----------------------------------<<<<<
            
            int status = SearchStcHisRefDataProc(out retList, stchisrefextraParamWork, ref sqlConnection);

            // --- ADD 2011/03/22----------------------------------->>>>>
            oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, stchisrefextraParamWork.EnterpriseCode, "仕入履歴照会", "抽出終了");
            // --- ADD 2011/03/22-----------------------------------<<<<<
            objstchisrefDataWork = (object)retList;

            return status;
        }

        /// <summary>
        /// 指定された条件の仕入履歴照会情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stchisrefdataWorkList">検索結果</param>
        /// <param name="stchisrefextraParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入履歴照会情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.21</br>
		public int SearchStcHisRefDataProc(out ArrayList stchisrefdataWorkList, StcHisRefExtraParamWork stchisrefextraParamWork, ref SqlConnection sqlConnection)
		{
			return this.SearchStcHisRefDataProcProc(out stchisrefdataWorkList, stchisrefextraParamWork, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の仕入履歴照会情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stchisrefdataWorkList">検索結果</param>
        /// <param name="stchisrefextraParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入履歴照会情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.21</br>
		private int SearchStcHisRefDataProcProc(out ArrayList stchisrefdataWorkList, StcHisRefExtraParamWork stchisrefextraParamWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            int loopcnt = 1;

            try
            {
                if (stchisrefextraParamWork.SupplierFormal >= 0)
                {
                    //仕入形式指定の場合
                    loopcnt = 1;
                }
                else
                {
                    //全ての場合
                    loopcnt = 2;
                }

                for (int i = 1; i <= loopcnt; i++)
                {
                    if (loopcnt == 2)
                    {
                        if (i == 1)
                        {
                            //全ての場合、最初のループで仕入履歴データから0:仕入を取得する。
                            stchisrefextraParamWork.SupplierFormal = 0;
                        }
                        else
                        if (i == 2)
                        {
                            //全ての場合、2回目のループで仕入データから1:入荷を取得する。
                            stchisrefextraParamWork.SupplierFormal = 1;
                            if (!myReader.IsClosed) myReader.Close();
                        }
                    }

                    # region [SELECT文]
                    string sqlText = "";
                    sqlText += "SELECT " + Environment.NewLine;
                    sqlText += "     SLIP.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += "    ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += "    ,SLIP.SECTIONCODERF" + Environment.NewLine;
                    sqlText += "    ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;
                    sqlText += "    ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;
                    sqlText += "    ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;
                    sqlText += "    ,SLIP.ACCPAYDIVCDRF" + Environment.NewLine;
                    sqlText += "    ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine;
                    sqlText += "    ,SLIP.INPUTDAYRF" + Environment.NewLine;
                    sqlText += "    ,SLIP.ARRIVALGOODSDAYRF" + Environment.NewLine;
                    sqlText += "    ,STOCKDATERF" + Environment.NewLine;
                    sqlText += "    ,SLIP.STOCKADDUPADATERF" + Environment.NewLine;
                    sqlText += "    ,SLIP.PAYEECODERF" + Environment.NewLine;
                    sqlText += "    ,SLIP.PAYEESNMRF" + Environment.NewLine;
                    sqlText += "    ,SLIP.STOCKINPUTCODERF" + Environment.NewLine;
                    sqlText += "    ,SLIP.STOCKINPUTNAMERF" + Environment.NewLine;
                    sqlText += "    ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;
                    sqlText += "    ,SLIP.STOCKAGENTNAMERF" + Environment.NewLine;
                    sqlText += "    ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
                    sqlText += "    ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += "    ,SLIP.SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.STOCKROWNORF" + Environment.NewLine;
                    sqlText += "    ,DTIL.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += "    ,DTIL.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.MAKERNAMERF" + Environment.NewLine;
                    sqlText += "    ,DTIL.GOODSNORF" + Environment.NewLine;
                    sqlText += "    ,DTIL.GOODSNAMERF" + Environment.NewLine;
                    sqlText += "    ,DTIL.STOCKSLIPCDDTLRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.SUPPLIERFORMALRF SUPPLIERFORMALDTLRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.BLGOODSCODERF" + Environment.NewLine;
                    sqlText += "    ,DTIL.BLGOODSFULLNAMERF" + Environment.NewLine;
                    sqlText += "    ,DTIL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.LISTPRICETAXINCFLRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.STOCKUNITPRICEFLRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.STOCKUNITTAXPRICEFLRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.STOCKCOUNTRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.STOCKPRICETAXEXCRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.STOCKPRICETAXINCRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.STOCKGOODSCDRF STOCKGOODSCDDTLRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.STOCKPRICECONSTAXRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.WAREHOUSECODERF" + Environment.NewLine;
                    sqlText += "    ,DTIL.WAREHOUSENAMERF" + Environment.NewLine;
                    sqlText += "    ,DTIL.WAREHOUSESHELFNORF" + Environment.NewLine;
                    sqlText += "    ,DTIL.ORDERNUMBERRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.SALESCUSTOMERSNMRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.STOCKDTISLIPNOTE1RF" + Environment.NewLine;
                    sqlText += "    ,DTIL.SLIPMEMO1RF" + Environment.NewLine;
                    sqlText += "    ,DTIL.SLIPMEMO2RF" + Environment.NewLine;
                    sqlText += "    ,DTIL.SLIPMEMO3RF" + Environment.NewLine;
                    sqlText += "    ,DTIL.INSIDEMEMO1RF" + Environment.NewLine;
                    sqlText += "    ,DTIL.INSIDEMEMO2RF" + Environment.NewLine;
                    sqlText += "    ,DTIL.INSIDEMEMO3RF" + Environment.NewLine;
                    sqlText += "    ,DTIL.SALESCUSTOMERCODERF" + Environment.NewLine;
                    sqlText += "    ,SLIP.SUPPCTAXLAYCDRF" + Environment.NewLine;
                    sqlText += "    ,SLIP.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
                    sqlText += "    ,DTIL.TAXATIONCODERF" + Environment.NewLine;
                    sqlText += "    ,SLIP.SUBSECTIONCODERF" + Environment.NewLine;
                    sqlText += "    ,SUBS.SUBSECTIONNAMERF" + Environment.NewLine;

                    sqlText += "FROM" + Environment.NewLine;

                    if (stchisrefextraParamWork.SupplierFormal == 0)
                    {
                        // 0:仕入 の場合は仕入履歴明細データから抽出する
                        sqlText += "  STOCKSLHISTDTLRF AS DTIL" + Environment.NewLine;
                        // 0:仕入 の場合は仕入履歴データから抽出する
                        sqlText += "  INNER JOIN STOCKSLIPHISTRF AS SLIP" + Environment.NewLine;
                    }
                    else
                    {
                        // 1:入荷 の場合は仕入明細データから抽出する
                        sqlText += "  STOCKDETAILRF AS DTIL" + Environment.NewLine;
                        // 1:入荷 の場合は仕入データから抽出する
                        sqlText += "  INNER JOIN STOCKSLIPRF AS SLIP" + Environment.NewLine;
                    }

                    sqlText += "    ON  DTIL.ENTERPRISECODERF = SLIP.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    AND DTIL.SUPPLIERFORMALRF = SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += "    AND DTIL.SUPPLIERSLIPNORF = SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;
                    sqlText += "    ON  SLIP.SECTIONCODERF = SECI.SECTIONCODERF" + Environment.NewLine;
                    sqlText += "    AND SLIP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;

                    sqlText += "  LEFT JOIN SUBSECTIONRF AS SUBS" + Environment.NewLine;
                    sqlText += "    ON  SUBS.ENTERPRISECODERF = SLIP.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    AND SUBS.SUBSECTIONCODERF = SLIP.SUBSECTIONCODERF" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection);

                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;                     // 論理削除区分
                    sqlText += "  AND SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;  // 企業コード

                    //企業コード
                    sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar).Value = SqlDataMediator.SqlSetString(stchisrefextraParamWork.EnterpriseCode);

                    // 入力日
                    // DEL 2008.11.27 >>>
                    //if (stchisrefextraParamWork.InputDaySt > 0 && stchisrefextraParamWork.InputDayEd > 0)
                    //{
                    //    sqlText += "  AND SLIP.INPUTDAYRF BETWEEN @FINDINPUTDAYST AND @FINDINPUTDAYED" + Environment.NewLine;

                    //    sqlCommand.Parameters.Add("@FINDINPUTDAYST", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.InputDaySt);
                    //    sqlCommand.Parameters.Add("@FINDINPUTDAYED", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.InputDayEd);
                    //}
                    // DEL 2008.11.27 <<<
                    // ADD 2008.11.27 >>>
                    if (stchisrefextraParamWork.InputDaySt > 0)
                    {
                        sqlText += "  AND SLIP.INPUTDAYRF >= @FINDINPUTDAYST" + Environment.NewLine;
                        sqlCommand.Parameters.Add("@FINDINPUTDAYST", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.InputDaySt);
                    }
                    if (stchisrefextraParamWork.InputDayEd > 0)
                    {
                        sqlText += "  AND SLIP.INPUTDAYRF <= @FINDINPUTDAYED" + Environment.NewLine;
                        sqlCommand.Parameters.Add("@FINDINPUTDAYED", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.InputDayEd);
                    }
                    // ADD 2008.11.27 <<<

                    if (stchisrefextraParamWork.SupplierFormal == 0)
                    {
                        // DEL 2008.11.27 >>>
                        //if (stchisrefextraParamWork.StockDateSt > 0 && stchisrefextraParamWork.StockDateEd > 0)
                        //{
                        //    // 0:仕入 の場合は仕入日を絞込み対象とする
                        //    sqlText += "  AND SLIP.STOCKDATERF BETWEEN @FINDDAYST AND @FINDDAYED" + Environment.NewLine;

                        //    sqlCommand.Parameters.Add("@FINDDAYST", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.StockDateSt);
                        //    sqlCommand.Parameters.Add("@FINDDAYED", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.StockDateEd);
                        //}
                        // DEL 2008.11.27 <<<
                        // ADD 2008.11.27 >>>
                        if (stchisrefextraParamWork.StockDateSt > 0 )
                        {
                            // 0:仕入 の場合は仕入日を絞込み対象とする
                            // -- UPD 2010/05/10 ------------------------------------>>>
                            //sqlText += "  AND SLIP.STOCKDATERF >= @FINDDAYST" + Environment.NewLine;
                            //sqlCommand.Parameters.Add("@FINDDAYST", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.StockDateSt);
                            sqlText += "  AND SLIP.STOCKDATERF >= " + SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.StockDateSt).ToString() + Environment.NewLine;
                            // -- UPD 2010/05/10 ------------------------------------<<<
                        }
                        if (stchisrefextraParamWork.StockDateEd > 0)
                        {
                            // 0:仕入 の場合は仕入日を絞込み対象とする
                            // -- UPD 2010/05/10 ------------------------------------>>>
                            //sqlText += "  AND SLIP.STOCKDATERF <= @FINDDAYED" + Environment.NewLine;
                            //sqlCommand.Parameters.Add("@FINDDAYED", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.StockDateEd);
                            sqlText += "  AND SLIP.STOCKDATERF <= " + SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.StockDateEd).ToString() + Environment.NewLine;
                            // -- UPD 2010/05/10 ------------------------------------<<<
                        }
                        // ADD 2008.11.27 <<<

                    }
                    else
                    {
                        // 1:入荷 の場合は入荷日を絞込み対象とする
                        // DEL 2008.11.27 >>>
                        //if (stchisrefextraParamWork.ArrivalGoodsDaySt > 0 && stchisrefextraParamWork.ArrivalGoodsDayEd > 0)
                        //{
                        //    sqlText += "  AND SLIP.ARRIVALGOODSDAYRF BETWEEN @FINDDAYST AND @FINDDAYED" + Environment.NewLine;

                        //    sqlCommand.Parameters.Add("@FINDDAYST", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.ArrivalGoodsDaySt);
                        //    sqlCommand.Parameters.Add("@FINDDAYED", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.ArrivalGoodsDayEd);
                        //}
                        // DEL 2008.11.27 <<<
                        // ADD 2008.11.27 >>>
                        if (stchisrefextraParamWork.ArrivalGoodsDaySt > 0 )
                        {
                            sqlText += "  AND SLIP.ARRIVALGOODSDAYRF >= @FINDDAYST" + Environment.NewLine;
                            sqlCommand.Parameters.Add("@FINDDAYST", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.ArrivalGoodsDaySt);
                        }
                        if (stchisrefextraParamWork.ArrivalGoodsDayEd > 0)
                        {
                            sqlText += "  AND SLIP.ARRIVALGOODSDAYRF <= @FINDDAYED" + Environment.NewLine;
                            sqlCommand.Parameters.Add("@FINDDAYED", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.ArrivalGoodsDayEd);
                        }
                        // ADD 208.11.27 <<<

                        // 1:入荷 の場合は計上残数を絞込み対象とする
                        switch (stchisrefextraParamWork.ReconcileFlag)
                        {
                            case 0:
                                {
                                    // 発注残数が有るデータのみを抽出する
                                    sqlText += "  AND DTIL.ORDERREMAINCNTRF > 0" + Environment.NewLine;
                                    break;
                                }
                            case 1:
                                {
                                    // 発注残数が無いデータのみを抽出する
                                    sqlText += "  AND DTIL.ORDERREMAINCNTRF = 0" + Environment.NewLine;
                                    break;
                                }
                            default:
                                {
                                    // 発注残数による絞込みは行わない
                                    break;
                                }
                        }

                    }
                    # endregion

                    sqlText += "  AND SLIP.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;  // 仕入形式
                    sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.SupplierFormal);


                    if (string.IsNullOrEmpty(stchisrefextraParamWork.SectionCode) == false)
                    {
                        sqlText += "  AND SLIP.STOCKSECTIONCDRF = @FINDSECTIONCODE" + Environment.NewLine;     // 仕入拠点コード
                        sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar).Value = SqlDataMediator.SqlSetString(stchisrefextraParamWork.SectionCode);
                    }

                    if (stchisrefextraParamWork.SupplierCd > 0)
                    {
                        sqlText += "  AND SLIP.SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;          // 仕入先コード
                        sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.SupplierCd);
                    }

                    //仕入伝票番号(開始)
                    if (stchisrefextraParamWork.SupplierSlipNoSt > 0)
                    {
                        sqlText += "  AND SLIP.SUPPLIERSLIPNORF>=@FINDSUPPLIERSLIPNOST" + Environment.NewLine;
                        sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOST", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.SupplierSlipNoSt);
                    }
                    //仕入伝票番号(終了)
                    if (stchisrefextraParamWork.SupplierSlipNoEd > 0)
                    {
                        sqlText += "  AND SLIP.SUPPLIERSLIPNORF<=@FINDSUPPLIERSLIPNOED" + Environment.NewLine;
                        sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOED", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.SupplierSlipNoEd);
                    }

                    // 仕入伝票区分
                    if (stchisrefextraParamWork.SupplierSlipCd > 0)
                    {
                        sqlText += "  AND SLIP.SUPPLIERSLIPCDRF = @FINDSUPPLIERSLIPCD" + Environment.NewLine;
                        sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPCD", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.SupplierSlipCd);
                    }

                    // 買掛区分
                    if (stchisrefextraParamWork.AccPayDivCd > -1)
                    {
                        sqlText += "  AND SLIP.ACCPAYDIVCDRF = @FINDACCPAYDIVCD" + Environment.NewLine;
                        sqlCommand.Parameters.Add("@FINDACCPAYDIVCD", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.AccPayDivCd);
                    }

                    // 支払先コード
                    if (stchisrefextraParamWork.PayeeCode > 0)
                    {
                        sqlText += "  AND SLIP.PAYEECODERF = @FINDPAYEECODE" + Environment.NewLine;
                        sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.PayeeCode);
                    }

                    // 発注番号
                    if (!string.IsNullOrEmpty(stchisrefextraParamWork.OrderNumber))
                    {
                        sqlText += "  AND DTIL.ORDERNUMBERRF = @FINDORDERNUMBER" + Environment.NewLine;
                        sqlCommand.Parameters.Add("@FINDORDERNUMBER", SqlDbType.NVarChar).Value = SqlDataMediator.SqlSetString(stchisrefextraParamWork.OrderNumber);
                    }

                    // 仕入担当者コード
                    if (!string.IsNullOrEmpty(stchisrefextraParamWork.StockAgentCode))
                    {
                        sqlText += "  AND SLIP.STOCKAGENTCODERF = @FINDSTOCKAGENTCODE" + Environment.NewLine;
                        sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODE", SqlDbType.NChar).Value = SqlDataMediator.SqlSetString(stchisrefextraParamWork.StockAgentCode);
                    }

                    // 商品メーカーコード
                    if (stchisrefextraParamWork.GoodsMakerCd > 0)
                    {
                        sqlText += "  AND DTIL.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stchisrefextraParamWork.GoodsMakerCd);
                    }

                    //品番
                    if (string.IsNullOrEmpty(stchisrefextraParamWork.GoodsNo) == false)
                    {
                        sqlText += " AND DTIL.GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        //前方一致検索の場合
                        if (stchisrefextraParamWork.GoodsNoSrchTyp == 1) stchisrefextraParamWork.GoodsNo = stchisrefextraParamWork.GoodsNo + "%";
                        //後方一致検索の場合
                        if (stchisrefextraParamWork.GoodsNoSrchTyp == 2) stchisrefextraParamWork.GoodsNo = "%" + stchisrefextraParamWork.GoodsNo;
                        //曖昧検索の場合
                        if (stchisrefextraParamWork.GoodsNoSrchTyp == 3) stchisrefextraParamWork.GoodsNo = "%" + stchisrefextraParamWork.GoodsNo + "%";

                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stchisrefextraParamWork.GoodsNo);
                    }

                    //品名
                    if (string.IsNullOrEmpty(stchisrefextraParamWork.GoodsName) == false)
                    {
                        sqlText += " AND DTIL.GOODSNAMERF LIKE @FINDGOODSNAME" + Environment.NewLine;
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAME", SqlDbType.NVarChar);
                        //前方一致検索の場合
                        if (stchisrefextraParamWork.GoodsNameSrchTyp == 1) stchisrefextraParamWork.GoodsName = stchisrefextraParamWork.GoodsName + "%";
                        //後方一致検索の場合
                        if (stchisrefextraParamWork.GoodsNameSrchTyp == 2) stchisrefextraParamWork.GoodsName = "%" + stchisrefextraParamWork.GoodsName;
                        //曖昧検索の場合
                        if (stchisrefextraParamWork.GoodsNameSrchTyp == 3) stchisrefextraParamWork.GoodsName = "%" + stchisrefextraParamWork.GoodsName + "%";

                        paraGoodsName.Value = SqlDataMediator.SqlSetString(stchisrefextraParamWork.GoodsName);
                    }

                    //相手先伝票番号
                    if (string.IsNullOrEmpty(stchisrefextraParamWork.PartySaleSlipNum) == false)
                    {
                        sqlText += " AND SLIP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUM" + Environment.NewLine;
                        SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUM", SqlDbType.NVarChar);
                        //前方一致検索の場合
                        if (stchisrefextraParamWork.PartySaleSlipNumSrchTyp == 1) stchisrefextraParamWork.PartySaleSlipNum = stchisrefextraParamWork.PartySaleSlipNum + "%";
                        //後方一致検索の場合
                        if (stchisrefextraParamWork.PartySaleSlipNumSrchTyp == 2) stchisrefextraParamWork.PartySaleSlipNum = "%" + stchisrefextraParamWork.PartySaleSlipNum;
                        //曖昧検索の場合
                        if (stchisrefextraParamWork.PartySaleSlipNumSrchTyp == 3) stchisrefextraParamWork.PartySaleSlipNum = "%" + stchisrefextraParamWork.PartySaleSlipNum + "%";

                        paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(stchisrefextraParamWork.PartySaleSlipNum);
                    }


                    // 倉庫コード
                    if (!string.IsNullOrEmpty(stchisrefextraParamWork.WarehouseCode))
                    {
                        sqlText += "  AND DTIL.WAREHOUSECODERF = @FINDWAREHOUSECODE" + Environment.NewLine;
                        sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar).Value = SqlDataMediator.SqlSetString(stchisrefextraParamWork.WarehouseCode);
                    }

                    // 部門コード
                    if (stchisrefextraParamWork.SubSectionCode != 0)
                    {
                        sqlText += " AND SLIP.SUBSECTIONCODERF = @SUBSECTIONCODE" + Environment.NewLine;
                        SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                        paraSubSectionCode.Value = SqlDataMediator.SqlSetInt(stchisrefextraParamWork.SubSectionCode);
                    }

                    sqlText += "ORDER BY" + Environment.NewLine;
                    sqlText += "  SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += " ,DTIL.STOCKROWNORF" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;

#if DEBUG
                    #region [SQL Debug]
                Console.Clear();
                Console.WriteLine("--- 変数 ---");

                foreach (SqlParameter param in sqlCommand.Parameters)
                {
                    string sqlDbType = param.SqlDbType.ToString();
                    if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                    {
                        sqlDbType += string.Format("({0})", param.Value.ToString().Length);
                    }

                    string value = param.Value.ToString();
                    if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                    {
                        value = string.Format("'{0}'", param.Value);
                    }

                    Console.WriteLine(string.Format("DECLARE {0} {1}", param.ParameterName, sqlDbType));                    
                    Console.WriteLine(string.Format("SET {0} = {1}", param.ParameterName, value));
                    Console.WriteLine("");
                }

                Console.WriteLine("--- SQL ---");
                Console.WriteLine(sqlText);
                #endregion
#endif
                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        al.Add(CopyToStcHisRefDataWorkFromReader(ref myReader));
                    }

                }

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
                else
                {
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
                base.WriteErrorLog(ex, "StcHisRefDataDB.SearchStcHisRefDataProc");
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

                stchisrefdataWorkList = al;
            }

            return status;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StcHisRefDataWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StcHisRefDataWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.21</br>
        /// </remarks>
        private StcHisRefDataWork CopyToStcHisRefDataWorkFromReader(ref SqlDataReader myReader)
        {
            StcHisRefDataWork wkStcHisRefDataWork = new StcHisRefDataWork();

            #region クラスへ格納
            wkStcHisRefDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStcHisRefDataWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            wkStcHisRefDataWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            wkStcHisRefDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStcHisRefDataWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkStcHisRefDataWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            wkStcHisRefDataWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            wkStcHisRefDataWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
            wkStcHisRefDataWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            wkStcHisRefDataWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            wkStcHisRefDataWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            wkStcHisRefDataWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            wkStcHisRefDataWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            wkStcHisRefDataWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkStcHisRefDataWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            wkStcHisRefDataWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkStcHisRefDataWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkStcHisRefDataWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            wkStcHisRefDataWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            wkStcHisRefDataWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            wkStcHisRefDataWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            wkStcHisRefDataWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            wkStcHisRefDataWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
            wkStcHisRefDataWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
            wkStcHisRefDataWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
            wkStcHisRefDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStcHisRefDataWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkStcHisRefDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStcHisRefDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkStcHisRefDataWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
            wkStcHisRefDataWork.SupplierFormalDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALDTLRF"));
            wkStcHisRefDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkStcHisRefDataWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkStcHisRefDataWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            wkStcHisRefDataWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
            wkStcHisRefDataWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStcHisRefDataWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
            wkStcHisRefDataWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            wkStcHisRefDataWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            wkStcHisRefDataWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
            wkStcHisRefDataWork.StockGoodsCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDDTLRF"));
            wkStcHisRefDataWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            wkStcHisRefDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStcHisRefDataWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkStcHisRefDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkStcHisRefDataWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
            wkStcHisRefDataWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));
            wkStcHisRefDataWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));
            wkStcHisRefDataWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));
            wkStcHisRefDataWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
            wkStcHisRefDataWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
            wkStcHisRefDataWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
            wkStcHisRefDataWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
            wkStcHisRefDataWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
            wkStcHisRefDataWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));

            // 伝票メモ１～３及び社内メモ１～３のどれか１つにでも文字列(メモ)が格納されていた場合は True とする。
            string summemo = string.Concat(wkStcHisRefDataWork.SlipMemo1, wkStcHisRefDataWork.SlipMemo2, wkStcHisRefDataWork.SlipMemo3,
                                            wkStcHisRefDataWork.InsideMemo1, wkStcHisRefDataWork.InsideMemo2, wkStcHisRefDataWork.InsideMemo3);
                                           
            // メモ存在フラグ
            wkStcHisRefDataWork.MemoExist = (string.IsNullOrEmpty(summemo) ? 0 : 1);

            wkStcHisRefDataWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            wkStcHisRefDataWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
            wkStcHisRefDataWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));

            wkStcHisRefDataWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            wkStcHisRefDataWork.SubSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSECTIONNAMERF"));
            #endregion

            return wkStcHisRefDataWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.21</br>
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
