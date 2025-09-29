using System;
using System.Collections;
using System.Collections.Generic;
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
    class MTtlSaSlip_Gcd : MTtlSaSlipBase, IMTtlSaSlip
    {
        #region [GcdSalesTarget用 Select文]
        /// <summary>
        /// 商品別売上目標設定マスタ集計用SELECT文 作成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <returns>商品別売上目標設定マスタ集計用SELECT文</returns>
        /// <br>Note       : 商品別売上目標設定マスタ集計用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, paramWork);
        }
        #endregion  //[GcdSalesTarget用 Select文]

        #region [GcdSalesTarget用 Select文生成処理]
        /// <summary>
        /// 商品別売上目標設定マスタ集計用SELECT文 作成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <returns>商品別売上目標設定マスタ集計用SELECT文</returns>
        /// <br>Note       : 商品別売上目標設定マスタ集計用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork)
        {
            #region [判別用フラグ]
            //拠点コード検索フラグ
            bool bAddUpSecCode = false;
            if (paramWork.TtlType == 1)
            {
                bAddUpSecCode = true;
            }
            #endregion

            string selectTxt = "";

            // 対象テーブル
            // MTTLSALESSLIPRF  MTSSLP 売上月次集計データ
            // GCDSALESTARGETRF GCSTGT 商品別売上目標設定マスタ
            // USERGDBDURF      USRGBU ユーザーガイドマスタ(ボディ)
            // SECINFOSETRF     SCINST 拠点情報設定マスタ

            #region [Select文作成]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  MTSSLP.ENTERPRISECODERF" + Environment.NewLine;
            //印刷タイプによって抽出項目を動的生成する
            switch (paramWork.PrintType)
            {
                #region [印刷タイプ判別]

                case (int)PrintType.Month:
                    #region [当月]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLP");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "MTSSLP");
                    #endregion
                    break;
                case (int)PrintType.Annual:
                    #region [当期]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Annual, "MTSSLP");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Annual, "MTSSLP");
                    #endregion
                    break;
                case (int)PrintType.All:
                    #region [当月＆当期]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLP");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "MTSSLP");
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Annual, "MTSSLP");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Annual, "MTSSLP");
                    #endregion
                    break;
                default:
                    break;

                #endregion  //[印刷タイプ判別]
            }
            //出力順によって抽出項目を動的生成する
            selectTxt += IFBy(bAddUpSecCode, " ,MTSSLP.ADDUPSECCODERF" + Environment.NewLine);
            selectTxt += IFBy(bAddUpSecCode, " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
            selectTxt += " ,MTSSLP.SALESCODERF" + Environment.NewLine;
            selectTxt += " ,USRGBU.GUIDENAMERF" + Environment.NewLine;

            //FROM
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            #region [売上月次集計データ＋商品別売上目標設定マスタ抽出用サブクエリ]
            selectTxt += " SELECT" + Environment.NewLine;
            selectTxt += "   MTSSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bAddUpSecCode, " ,MTSSLPSUB.ADDUPSECCODERF" + Environment.NewLine);
            selectTxt += "  ,MTSSLPSUB.SALESCODERF" + Environment.NewLine;
            //印刷タイプによって抽出項目を動的生成する
            switch (paramWork.PrintType)
            {
                #region [印刷タイプ判別]

                case (int)PrintType.Month:
                    #region [当月]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLPM");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "GCSTGTM");
                    #endregion
                    break;
                case (int)PrintType.Annual:
                    #region [当期]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Annual, "MTSSLPA");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Annual, "GCSTGTA");
                    #endregion
                    break;
                case (int)PrintType.All:
                    #region [当月＆当期]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLPM");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "GCSTGTM");
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Annual, "MTSSLPA");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Annual, "GCSTGTA");
                    #endregion
                    break;
                default:
                    break;

                #endregion  //[印刷タイプ判別]
            }

            //FROM
            // 2011/07/29 >>>
            //selectTxt += "  FROM MTTLSALESSLIPRF AS MTSSLPSUB" + Environment.NewLine;
            selectTxt += "  FROM MTTLSALESSLIPRF AS MTSSLPSUB WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<

            #region [データ抽出メインQuery]

            //当月分を抽出するかどうか
            if (paramWork.PrintType != (int)PrintType.Annual)  //PrintType -> 0:当月 1:当期 2:当月＆当期
            {
                //当月分集計

                #region [売上月次集計データ]
                selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,MTSSLPSUB1.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += "    ,MTSSLPSUB1.SALESCODERF" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB1.SALESMONEYRF)" + Environment.NewLine;
                selectTxt += "      AS MONTHSALESMONEY" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB1.SALESRETGOODSPRICERF)" + Environment.NewLine;
                selectTxt += "      AS MONTHSALESRETGOODSPRICE" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB1.DISCOUNTPRICERF)" + Environment.NewLine;
                selectTxt += "      AS MONTHDISCOUNTPRICE" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB1.GROSSPROFITRF)" + Environment.NewLine;
                selectTxt += "      AS MONTHGROSSPROFIT" + Environment.NewLine;
                // 2011/07/29 >>>
                //selectTxt += "   FROM MTTLSALESSLIPRF AS MTSSLPSUB1" + Environment.NewLine;
                selectTxt += "   FROM MTTLSALESSLIPRF AS MTSSLPSUB1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.Month, "MTSSLPSUB1");
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,MTSSLPSUB1.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += "    ,MTSSLPSUB1.SALESCODERF" + Environment.NewLine;
                selectTxt += "  ) AS MTSSLPM" + Environment.NewLine;
                selectTxt += "  ON  MTSSLPM.ENTERPRISECODERF=MTSSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND MTSSLPM.SALESCODERF=MTSSLPSUB.SALESCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "  AND MTSSLPM.ADDUPSECCODERF=MTSSLPSUB.ADDUPSECCODERF" + Environment.NewLine);
                #endregion  //[売上月次集計データ]

                #region [商品別売上目標設定マスタ]
                selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     GCSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,GCSTGTSUB1.SALESCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,GCSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                selectTxt += "    ,SUM(GCSTGTSUB1.SALESTARGETMONEYRF)" + Environment.NewLine;
                selectTxt += "      AS MONTHSALESTARGETMONEY" + Environment.NewLine;
                selectTxt += "    ,SUM(GCSTGTSUB1.SALESTARGETPROFITRF)" + Environment.NewLine;
                selectTxt += "      AS MONTHSALESTARGETPROFIT" + Environment.NewLine;
                // 2011/07/29 >>>
                //selectTxt += "   FROM GCDSALESTARGETRF AS GCSTGTSUB1" + Environment.NewLine;
                selectTxt += "   FROM GCDSALESTARGETRF AS GCSTGTSUB1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += MakeWhereString_GcdTgt(ref sqlCommand, paramWork, (int)PrintType.Month, "GCSTGTSUB1");
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     GCSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,GCSTGTSUB1.SALESCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,GCSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                selectTxt += "  ) AS GCSTGTM" + Environment.NewLine;
                selectTxt += "  ON  GCSTGTM.ENTERPRISECODERF=MTSSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GCSTGTM.SALESCODERF=MTSSLPSUB.SALESCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "  AND GCSTGTM.SECTIONCODERF=MTSSLPSUB.ADDUPSECCODERF" + Environment.NewLine);
                #endregion  //[商品別売上目標設定マスタ]
            }

            //当期分を抽出するかどうか
            if (paramWork.PrintType != (int)PrintType.Month)  //PrintType -> 0:当月 1:当期 2:当月＆当期
            {
                //当期分集計]

                #region [売上月次集計データ]
                //selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                selectTxt += "  RIGHT JOIN (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,MTSSLPSUB2.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += "    ,MTSSLPSUB2.SALESCODERF" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB2.SALESMONEYRF)" + Environment.NewLine;
                selectTxt += "      AS ANNUALSALESMONEY" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB2.SALESRETGOODSPRICERF)" + Environment.NewLine;
                selectTxt += "      AS ANNUALSALESRETGOODSPRICE" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB2.DISCOUNTPRICERF)" + Environment.NewLine;
                selectTxt += "      AS ANNUALDISCOUNTPRICE" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB2.GROSSPROFITRF)" + Environment.NewLine;
                selectTxt += "      AS ANNUALGROSSPROFIT" + Environment.NewLine;
                // 2011/07/29 >>>
                //selectTxt += "   FROM MTTLSALESSLIPRF AS MTSSLPSUB2" + Environment.NewLine;
                selectTxt += "   FROM MTTLSALESSLIPRF AS MTSSLPSUB2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.Annual, "MTSSLPSUB2");
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,MTSSLPSUB2.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += "    ,MTSSLPSUB2.SALESCODERF" + Environment.NewLine;
                selectTxt += "  ) AS MTSSLPA" + Environment.NewLine;
                selectTxt += "  ON  MTSSLPA.ENTERPRISECODERF=MTSSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND MTSSLPA.SALESCODERF=MTSSLPSUB.SALESCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "  AND MTSSLPA.ADDUPSECCODERF=MTSSLPSUB.ADDUPSECCODERF" + Environment.NewLine);
                #endregion  //[売上月次集計データ]

                #region [商品別売上目標設定マスタ]
                selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     GCSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,GCSTGTSUB2.SALESCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,GCSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                selectTxt += "    ,SUM(GCSTGTSUB2.SALESTARGETMONEYRF)" + Environment.NewLine;
                selectTxt += "      AS ANNUALSALESTARGETMONEY" + Environment.NewLine;
                selectTxt += "    ,SUM(GCSTGTSUB2.SALESTARGETPROFITRF)" + Environment.NewLine;
                selectTxt += "      AS ANNUALSALESTARGETPROFIT" + Environment.NewLine;
                // 2011/07/29 >>>
                //selectTxt += "   FROM GCDSALESTARGETRF AS GCSTGTSUB2" + Environment.NewLine;
                selectTxt += "   FROM GCDSALESTARGETRF AS GCSTGTSUB2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += MakeWhereString_GcdTgt(ref sqlCommand, paramWork, (int)PrintType.Annual, "GCSTGTSUB2");
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     GCSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,GCSTGTSUB2.SALESCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,GCSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                selectTxt += "  ) AS GCSTGTA" + Environment.NewLine;
                selectTxt += "  ON  GCSTGTA.ENTERPRISECODERF=MTSSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GCSTGTA.SALESCODERF=MTSSLPSUB.SALESCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "  AND GCSTGTA.SECTIONCODERF=MTSSLPSUB.ADDUPSECCODERF" + Environment.NewLine);
                #endregion  //[商品別売上目標設定マスタ]
            }

            #endregion  //[データ抽出メインQuery]

            //WHERE句
            selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.All, "MTSSLPSUB");

            //GROUP BY
            selectTxt += " GROUP BY" + Environment.NewLine;
            selectTxt += "   MTSSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bAddUpSecCode,
                         "  ,MTSSLPSUB.ADDUPSECCODERF" + Environment.NewLine);
            selectTxt += "  ,MTSSLPSUB.SALESCODERF" + Environment.NewLine;
            switch (paramWork.PrintType)
            {
                #region [印刷タイプ判別]

                case (int)PrintType.Month:
                    #region [当月]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLPM");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "GCSTGTM");
                    #endregion
                    break;
                case (int)PrintType.Annual:
                    #region [当期]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Annual, "MTSSLPA");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Annual, "GCSTGTA");
                    #endregion
                    break;
                case (int)PrintType.All:
                    #region [当月＆当期]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLPM");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "GCSTGTM");
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Annual, "MTSSLPA");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Annual, "GCSTGTA");
                    #endregion
                    break;
                default:
                    break;

                #endregion  //[印刷タイプ判別]
            }

            #endregion  // [売上月次集計データ＋商品別売上目標設定マスタ抽出用サブクエリ]

            selectTxt += " ) AS MTSSLP" + Environment.NewLine;

            #region [JOIN]
            //ユーザーガイドマスタ(ボディ)
            int iSalesCode = (int)UserGuideDivCd.SalesCode;
            // 2011/07/29 >>>
            //selectTxt += " LEFT JOIN USERGDBDURF USRGBU" + Environment.NewLine;
            selectTxt += " LEFT JOIN USERGDBDURF USRGBU WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<
            selectTxt += " ON  USRGBU.ENTERPRISECODERF=MTSSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USRGBU.USERGUIDEDIVCDRF=" + iSalesCode.ToString();
            selectTxt += " AND USRGBU.GUIDECODERF=MTSSLP.SALESCODERF";

            if (bAddUpSecCode)
            {
                //拠点情報設定マスタ
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  SCINST.ENTERPRISECODERF=MTSSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SCINST.SECTIONCODERF=MTSSLP.ADDUPSECCODERF" + Environment.NewLine;
            }
            #endregion  //[JOIN]

            #endregion  //[Select文作成]

            return selectTxt;
        }
        #endregion  //[GcdSalesTarget用 Select文生成処理]

        #region [MTtlSalesSlip用 Where句生成処理]
        /// <summary>
        /// 売上月次集計データ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="iPrintType">印刷タイプ</param>
        /// <param name="sTblNm">テーブル名</param>
        /// <returns>売上月次集計データ用WHERE句</returns>
        /// <br>Note       : 売上月次集計データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork, Int32 iPrintType, string sTblNm)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //論理削除区分
            retstring += " AND " + sTblNm + ".LOGICALDELETECODERF=0 " + Environment.NewLine;

            //実績集計区分
            retstring += " AND " + sTblNm + ".RSLTTTLDIVCDRF=0" + Environment.NewLine;

            //従業員区分
            retstring += " AND " + sTblNm + ".EMPLOYEEDIVCDRF=@" + sTblNm + "EMPLOYEEDIVCD" + Environment.NewLine;
            SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@" + sTblNm + "EMPLOYEEDIVCD", SqlDbType.Int);
            paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)EmployeeDivCd.Agent);

            //拠点コード
            if (paramWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in paramWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND " + sTblNm + ".ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //対象年月
            if (iPrintType == (int)PrintType.Month)
            {
                //当月
                retstring += " AND " + sTblNm + ".ADDUPYEARMONTHRF>=@" + sTblNm + "ADDUPYEARMONTHST" + Environment.NewLine;
                SqlParameter paraAddUpYearMonthSt = sqlCommand.Parameters.Add("@" + sTblNm + "ADDUPYEARMONTHST", SqlDbType.Int);
                paraAddUpYearMonthSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AddUpYearMonthSt);

                retstring += " AND " + sTblNm + ".ADDUPYEARMONTHRF<=@" + sTblNm + "ADDUPYEARMONTHED" + Environment.NewLine;
                SqlParameter paraAddUpYearMonthEd = sqlCommand.Parameters.Add("@" + sTblNm + "ADDUPYEARMONTHED", SqlDbType.Int);
                paraAddUpYearMonthEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AddUpYearMonthEd);
            }
            if (iPrintType == (int)PrintType.Annual)
            {
                //当期
                retstring += " AND " + sTblNm + ".ADDUPYEARMONTHRF>=@AN" + sTblNm + "ADDUPYEARMONTHST" + Environment.NewLine;
                SqlParameter paraANAddUpYearMonthSt = sqlCommand.Parameters.Add("@AN" + sTblNm + "ADDUPYEARMONTHST", SqlDbType.Int);
                paraANAddUpYearMonthSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AnnualAddUpYearMonthSt);

                retstring += " AND " + sTblNm + ".ADDUPYEARMONTHRF<=@AN" + sTblNm + "ADDUPYEARMONTHED" + Environment.NewLine;
                SqlParameter paraANAddUpYearMonthEd = sqlCommand.Parameters.Add("@AN" + sTblNm + "ADDUPYEARMONTHED", SqlDbType.Int);
                paraANAddUpYearMonthEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AnnualAddUpYaerMonthEd);
            }

            //得意先コード
            if (paramWork.CustomerCodeSt != 0)
            {
                retstring += " AND " + sTblNm + ".CUSTOMERCODERF>=@" + sTblNm + "CUSTOMERCODEST" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeSt);
            }
            if (paramWork.CustomerCodeEd != 999999999)
            {
                retstring += " AND " + sTblNm + ".CUSTOMERCODERF<=@" + sTblNm + "CUSTOMERCODEED" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeEd);
            }

            //販売区分コード
            //if (paramWork.SrchCodeSt != "")// DEL 2008.12.08
            if (paramWork.SrchCodeSt != "" && paramWork.SrchCodeSt != null) // ADD 2008.12.08
            {
                Int32 iSalesCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //パラメータのキャスト
                retstring += " AND " + sTblNm + ".SALESCODERF>=@" + sTblNm + "SALESCODEST" + Environment.NewLine;
                SqlParameter paraSrchCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESCODEST", SqlDbType.Int);
                paraSrchCodeSt.Value = SqlDataMediator.SqlSetInt32(iSalesCodeSt);
            }
            //if ((paramWork.SrchCodeEd != ""))// DEL 2008.12.08
            if ((paramWork.SrchCodeEd != "") && (paramWork.SrchCodeEd != null))// ADD 2008.12.08
            {
                Int32 iSalesCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //パラメータのキャスト
                retstring += " AND " + sTblNm + ".SALESCODERF<=@" + sTblNm + "SALESCODEED" + Environment.NewLine;
                SqlParameter paraSrchCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESCODEED", SqlDbType.Int);
                paraSrchCodeEd.Value = SqlDataMediator.SqlSetInt32(iSalesCodeEd);
            }
            #endregion

            return retstring;
        }
        #endregion  //[MTtlSalesSlip用 Where句生成処理]

        #region [GcdSalesTarget用 Where句生成処理]
        /// <summary>
        /// 商品別売上目標設定マスタ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件</param>
        /// <returns>商品別売上目標設定マスタ用WHERE句</returns>
        /// <br>Note       : 商品別売上目標設定マスタ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        private string MakeWhereString_GcdTgt(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork, Int32 iPrintType, string sTblNm)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //販売区分コード
            //if (paramWork.SrchCodeSt != "") // DEL 2008.12.08
            if (paramWork.SrchCodeSt != "" && paramWork.SrchCodeSt != null) // ADD 2008.12.08 
            {
                Int32 iSalesCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //パラメータのキャスト
                retstring += " AND " + sTblNm + ".SALESCODERF>=@" + sTblNm + "SALESCODEST" + Environment.NewLine;
                SqlParameter paraSrchCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESCODEST", SqlDbType.Int);
                paraSrchCodeSt.Value = SqlDataMediator.SqlSetInt32(iSalesCodeSt);
            }
            //if ((paramWork.SrchCodeEd != "")) // DEL 2008.12.08
            if ((paramWork.SrchCodeEd != "") && (paramWork.SrchCodeEd != null)) // ADD 2008.12.08
            {
                Int32 iSalesCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //パラメータのキャスト
                retstring += " AND " + sTblNm + ".SALESCODERF<=@" + sTblNm + "SALESCODEED" + Environment.NewLine;
                SqlParameter paraSrchCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESCODEED", SqlDbType.Int);
                paraSrchCodeEd.Value = SqlDataMediator.SqlSetInt32(iSalesCodeEd);
            }
            // ADD 2008.12.08 >>>
            retstring += " AND " + sTblNm + ".TARGETCONTRASTCDRF=44" + Environment.NewLine;

            //対象年月
            if (iPrintType == (int)PrintType.Month)
            {
                //当月
                retstring += " AND " + sTblNm + ".TARGETDIVIDECODERF>=@" + sTblNm + "TARGETDIVIDECODEST" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "TARGETDIVIDECODEST", SqlDbType.Int);
                paraTargetDivideCodeSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AddUpYearMonthSt);

                retstring += " AND " + sTblNm + ".TARGETDIVIDECODERF<=@" + sTblNm + "TARGETDIVIDECODEED" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "TARGETDIVIDECODEED", SqlDbType.Int);
                paraTargetDivideCodeEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AddUpYearMonthEd);
            }
            if (iPrintType == (int)PrintType.Annual)
            {
                //当期
                retstring += " AND " + sTblNm + ".TARGETDIVIDECODERF>=@AN" + sTblNm + "TARGETDIVIDECODEST" + Environment.NewLine;
                SqlParameter paraANTargetDivideCodeSt = sqlCommand.Parameters.Add("@AN" + sTblNm + "TARGETDIVIDECODEST", SqlDbType.Int);
                paraANTargetDivideCodeSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AnnualAddUpYearMonthSt);

                retstring += " AND " + sTblNm + ".TARGETDIVIDECODERF<=@AN" + sTblNm + "TARGETDIVIDECODEED" + Environment.NewLine;
                SqlParameter paraANTargetDivideCodeEd = sqlCommand.Parameters.Add("@AN" + sTblNm + "TARGETDIVIDECODEED", SqlDbType.Int);
                paraANTargetDivideCodeEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AnnualAddUpYaerMonthEd);
            }
            // ADD 2008.12.08 <<<
            #endregion

            return retstring;
        }
        #endregion  //[GcdSalesTarget用 Where句生成処理]

        #region [SalesMonthYearReportResultWork処理 呼出]
        /// <summary>
        /// クラス格納処理 Reader → SalesMonthYearReportResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesMonthYearReportResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        /// <br></br>
        /// </remarks>
        public SalesMonthYearReportResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader, SalesMonthYearReportParamWork paramWork)
        {
            return this.CopyToResultWorkFromReaderProc(ref myReader, paramWork);
        }
        #endregion  //[SalesMonthYearReportResultWork処理 呼出]

        #region [SalesMonthYearReportResultWork処理]
        /// <summary>
        /// クラス格納処理 Reader → SalesMonthYearReportResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesMonthYearReportResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        /// <br></br>
        /// </remarks>
        private SalesMonthYearReportResultWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, SalesMonthYearReportParamWork paramWork)
        {
            #region [抽出結果-値セット]
            SalesMonthYearReportResultWork resultWork = new SalesMonthYearReportResultWork();

            Int32 iSalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
            resultWork.Code = iSalesCode.ToString();
            resultWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));

            if (paramWork.TtlType == 1)
            {
                resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                resultWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            }

            if (paramWork.PrintType != (int)PrintType.Annual)  //PrintType -> 0:当月 1:当期 2:当月＆当期
            {
                //当月分
                resultWork.MonthSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESMONEY"));
                resultWork.MonthSalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESRETGOODSPRICE"));
                resultWork.MonthDiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHDISCOUNTPRICE"));
                resultWork.MonthSalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESTARGETMONEY"));
                resultWork.MonthGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHGROSSPROFIT"));
                resultWork.MonthSalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESTARGETPROFIT"));
            }
            if (paramWork.PrintType != (int)PrintType.Month)  //PrintType -> 0:当月 1:当期 2:当月＆当期
            {
                //当期分
                resultWork.AnnualSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALSALESMONEY"));
                resultWork.AnnualSalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALSALESRETGOODSPRICE"));
                resultWork.AnnualDiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALDISCOUNTPRICE"));
                resultWork.AnnualSalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALSALESTARGETMONEY"));
                resultWork.AnnualGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALGROSSPROFIT"));
                resultWork.AnnualSalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALSALESTARGETPROFIT"));
            }
            #endregion

            return resultWork;
        }
        #endregion  //[SalesMonthYearReportResultWork処理]
    }
}

