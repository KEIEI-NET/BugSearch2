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
    class MTtlSaSlip_Emp : MTtlSaSlipBase, IMTtlSaSlip
    {
        #region [EmpSalesTarget用 Select文]
        /// <summary>
        /// 従業員別売上目標設定マスタ用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件</param>
        /// <returns>従業員別売上目標設定マスタ用SELECT文</returns>
        /// <br>Note       : 従業員別売上目標設定マスタ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, paramWork);
        }
        #endregion  //[EmpSalesTarget用 Select文]

        #region [EmpSalesTarget用 Select文生成処理]
        /// <summary>
        /// 従業員別売上目標設定マスタ用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件</param>
        /// <returns>従業員別売上目標設定マスタ用SELECT文</returns>
        /// <br>Note       : 従業員別売上目標設定マスタ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork)
        {
            #region [判別用フラグ]
            //得意先コード検索フラグ
            bool bCustomerCode = false;
            if (paramWork.OutType == 1)
            {
                bCustomerCode = true;
            }

            //拠点コード検索フラグ
            bool bAddUpSecCode = false;
            if (((paramWork.TtlType == 1) && (paramWork.OutType == 0)) ||
                ((paramWork.TtlType == 1) && (paramWork.OutType == 1)) ||
                ((paramWork.TtlType == 1) && (paramWork.OutType == 2)))
            {
                bAddUpSecCode = true;
            }

            //管理拠点コード検索フラグ
            bool bMngSectionCode = false;
            if ((paramWork.TtlType == 1) && (paramWork.OutType == 3))
            {
                bMngSectionCode = true;
            }

            //得意先マスタ検索フラグ
            bool bCustomerRF = false;
            if (paramWork.OutType == 1)
            {
                bCustomerRF = true;
            }

            //自社名称マスタ検索フラグ
            bool bCompanyNmRF = false;
            if (paramWork.TtlType == 1)
            {
                bCompanyNmRF = true;
            }
            #endregion  //[判別用フラグ]

            string selectTxt = "";

            // 対象テーブル
            // MTTLSALESSLIPRF  MTSSLP 売上月次集計データ
            // EMPSALESTARGETRF EMSTGT 従業員別売上目標設定マスタ
            // CUSTOMERRF       CUTMER 得意先マスタ
            // SECINFOSETRF     SCINST 拠点情報設定マスタ
            // EMPLOYEERF       EMPLOY 従業員マスタ

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
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLP");
            selectTxt += " ,EMPLOY.NAMERF" + Environment.NewLine;
            selectTxt += IFBy(bCustomerRF, " ,CUTMER.CUSTOMERSNMRF" + Environment.NewLine);
            selectTxt += IFBy(bCompanyNmRF, " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
            selectTxt += IFBy(bMngSectionCode, " ,MTSSLP.MNGSECTIONCODERF" + Environment.NewLine);

            //FROM
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            #region [売上月次集計データ＋従業員別売上目標設定マスタ抽出用サブクエリ]
            selectTxt += "  SELECT" + Environment.NewLine;
            //印刷タイプによって抽出項目を動的生成する
            switch (paramWork.PrintType)
            {
                #region [印刷タイプ判別]

                case (int)PrintType.Month:
                    #region [当月]
                    selectTxt += "   MTSSLPM.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bMngSectionCode,
                                 "  ,MTSSLPM.MNGSECTIONCODERF" + Environment.NewLine);
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLPM");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "EMSTGTM");
                    selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPM");
                    #endregion
                    break;
                case (int)PrintType.Annual:
                    #region [当期]
                    selectTxt += "   MTSSLPA.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bMngSectionCode,
                                 "  ,MTSSLPA.MNGSECTIONCODERF" + Environment.NewLine);
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Annual, "MTSSLPA");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Annual, "EMSTGTA");
                    selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPA");
                    #endregion
                    break;
                case (int)PrintType.All:
                    #region [当月＆当期]
                    selectTxt += "   MTSSLPASUB.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bMngSectionCode,
                                 "  ,MTSSLPASUB.MNGSECTIONCODERF" + Environment.NewLine);
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLPM");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "EMSTGTM");
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Annual, "MTSSLPASUB");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Annual, "MTSSLPASUB");
                    selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPASUB");
                    #endregion
                    break;
                default:
                    break;

                #endregion  //[印刷タイプ判別]
            }

            //FROM
            selectTxt += "  FROM" + Environment.NewLine;
            selectTxt += "  (" + Environment.NewLine;

            #region [データ抽出メインQuery]

            //当月分を抽出するかどうか
            if (paramWork.PrintType != (int)PrintType.Annual)  //PrintType -> 0:当月 1:当期 2:当月＆当期
            {
                //当月分集計

                #region [売上月次集計データ]
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,MTSSLPSUB1.EMPLOYEEDIVCDRF" + Environment.NewLine;
                selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPSUB1");
                selectTxt += "    ,SUM(MTSSLPSUB1.SALESMONEYRF)" + Environment.NewLine;
                selectTxt += "      AS MONTHSALESMONEY" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB1.SALESRETGOODSPRICERF)" + Environment.NewLine;
                selectTxt += "      AS MONTHSALESRETGOODSPRICE" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB1.DISCOUNTPRICERF)" + Environment.NewLine;
                selectTxt += "      AS MONTHDISCOUNTPRICE" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB1.GROSSPROFITRF)" + Environment.NewLine;
                selectTxt += "      AS MONTHGROSSPROFIT" + Environment.NewLine;
                selectTxt += IFBy(bMngSectionCode,
                             "    ,MTSSLPSUB1.MNGSECTIONCODERF" + Environment.NewLine);

                if (bMngSectionCode)
                {
                    #region [管理拠点順絞込み用サブクエリ]
                    selectTxt += "   FROM" + Environment.NewLine;
                    selectTxt += "   (" + Environment.NewLine;
                    selectTxt += "    SELECT" + Environment.NewLine;
                    selectTxt += "      MTSSLPSUB1_1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB1_1.LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB1_1.EMPLOYEEDIVCDRF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB1_1.EMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB1_1.SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB1_1.SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB1_1.DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB1_1.GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB1_1.RSLTTTLDIVCDRF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB1_1.ADDUPYEARMONTHRF" + Environment.NewLine;
                    selectTxt += "     ,CUTMERSUB1_1.CUSTOMERCODERF" + Environment.NewLine; // ADD 2008.12.08
                    selectTxt += "     ,CUTMERSUB1_1.MNGSECTIONCODERF" + Environment.NewLine;
                    // 2011/07/29 >>>
                    //selectTxt += "    FROM MTTLSALESSLIPRF AS MTSSLPSUB1_1" + Environment.NewLine;
                    //selectTxt += "    LEFT JOIN CUSTOMERRF CUTMERSUB1_1" + Environment.NewLine;
                    selectTxt += "    FROM MTTLSALESSLIPRF AS MTSSLPSUB1_1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "    LEFT JOIN CUSTOMERRF CUTMERSUB1_1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    // 2011/07/29 <<<
                    selectTxt += "    ON  CUTMERSUB1_1.ENTERPRISECODERF=MTSSLPSUB1_1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "    AND CUTMERSUB1_1.CUSTOMERCODERF=MTSSLPSUB1_1.CUSTOMERCODERF" + Environment.NewLine;
                    selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.Month, "MTSSLPSUB1_1");
                    selectTxt += "   ) AS MTSSLPSUB1" + Environment.NewLine;
                    #endregion  //[管理拠点順絞込み用サブクエリ]
                }
                else
                {
                    //管理拠点順以外
                    // 2011/07/29 >>>
                    //selectTxt += "   FROM MTTLSALESSLIPRF AS MTSSLPSUB1" + Environment.NewLine;
                    selectTxt += "   FROM MTTLSALESSLIPRF AS MTSSLPSUB1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    // 2011/07/29 <<<
                }

                selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.Month, "MTSSLPSUB1");
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,MTSSLPSUB1.EMPLOYEEDIVCDRF" + Environment.NewLine;
                selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPSUB1");
                selectTxt += IFBy(bMngSectionCode,
                             "    ,MTSSLPSUB1.MNGSECTIONCODERF" + Environment.NewLine);
                selectTxt += "  ) AS MTSSLPM" + Environment.NewLine;
                #endregion  //[売上月次集計データ]


                if (bCustomerRF == true)
                {
                    #region [得意先別売上目標設定マスタ]
                    selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                    selectTxt += "   SELECT" + Environment.NewLine;
                    selectTxt += "     CUSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bAddUpSecCode,
                                 "    ,CUSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bMngSectionCode,
                                 "    ,CUSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bCustomerCode,
                                 "    ,CUSTGTSUB1.CUSTOMERCODERF" + Environment.NewLine);
                    selectTxt += "    ,SUM(CUSTGTSUB1.SALESTARGETMONEYRF)" + Environment.NewLine;
                    selectTxt += "      AS MONTHSALESTARGETMONEY" + Environment.NewLine;
                    selectTxt += "    ,SUM(CUSTGTSUB1.SALESTARGETPROFITRF)" + Environment.NewLine;
                    selectTxt += "      AS MONTHSALESTARGETPROFIT" + Environment.NewLine;
                    // 2011/07/29 >>>
                    //selectTxt += "   FROM CUSTSALESTARGETRF AS CUSTGTSUB1" + Environment.NewLine;
                    selectTxt += "   FROM CUSTSALESTARGETRF AS CUSTGTSUB1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    // 2011/07/29 <<<
                    selectTxt += MakeWhereString_CustTgt(ref sqlCommand, paramWork, (int)PrintType.Month, "CUSTGTSUB1");
                    selectTxt += "   GROUP BY" + Environment.NewLine;
                    selectTxt += "     CUSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bAddUpSecCode,
                                 "    ,CUSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bMngSectionCode,
                                 "    ,CUSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bCustomerCode,
                                 "    ,CUSTGTSUB1.CUSTOMERCODERF" + Environment.NewLine);
                    selectTxt += "  ) AS EMSTGTM" + Environment.NewLine;
                    selectTxt += "  ON  EMSTGTM.ENTERPRISECODERF=MTSSLPM.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bAddUpSecCode,
                                 "  AND EMSTGTM.SECTIONCODERF=MTSSLPM.ADDUPSECCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bMngSectionCode,
                                 "  AND EMSTGTM.SECTIONCODERF=MTSSLPM.MNGSECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bCustomerCode,
                                 "  AND EMSTGTM.CUSTOMERCODERF=MTSSLPM.CUSTOMERCODERF" + Environment.NewLine);
                    #endregion  //[得意先別売上目標設定マスタ]
                }
                else
                {
                    #region [従業員別売上目標設定マスタ]
                    selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                    selectTxt += "   SELECT" + Environment.NewLine;
                    selectTxt += "     EMSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bAddUpSecCode,
                                 "    ,EMSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bMngSectionCode,
                                 "    ,EMSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                    selectTxt += "    ,EMSTGTSUB1.EMPLOYEEDIVCDRF" + Environment.NewLine;
                    selectTxt += "    ,EMSTGTSUB1.EMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += "    ,SUM(EMSTGTSUB1.SALESTARGETMONEYRF)" + Environment.NewLine;
                    selectTxt += "      AS MONTHSALESTARGETMONEY" + Environment.NewLine;
                    selectTxt += "    ,SUM(EMSTGTSUB1.SALESTARGETPROFITRF)" + Environment.NewLine;
                    selectTxt += "      AS MONTHSALESTARGETPROFIT" + Environment.NewLine;
                    // 2011/07/29 >>>
                    //selectTxt += "   FROM EMPSALESTARGETRF AS EMSTGTSUB1" + Environment.NewLine;
                    selectTxt += "   FROM EMPSALESTARGETRF AS EMSTGTSUB1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    // 2011/07/29 <<<
                    selectTxt += MakeWhereString_EmpTgt(ref sqlCommand, paramWork, (int)PrintType.Month, "EMSTGTSUB1");
                    selectTxt += "   GROUP BY" + Environment.NewLine;
                    selectTxt += "     EMSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bAddUpSecCode,
                                 "    ,EMSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bMngSectionCode,
                                 "    ,EMSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                    selectTxt += "    ,EMSTGTSUB1.EMPLOYEEDIVCDRF" + Environment.NewLine;
                    selectTxt += "    ,EMSTGTSUB1.EMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += "  ) AS EMSTGTM" + Environment.NewLine;
                    selectTxt += "  ON  EMSTGTM.ENTERPRISECODERF=MTSSLPM.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  AND EMSTGTM.EMPLOYEEDIVCDRF=MTSSLPM.EMPLOYEEDIVCDRF" + Environment.NewLine;
                    selectTxt += "  AND EMSTGTM.EMPLOYEECODERF=MTSSLPM.EMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bAddUpSecCode,
                                 "  AND EMSTGTM.SECTIONCODERF=MTSSLPM.ADDUPSECCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bMngSectionCode,
                                 "  AND EMSTGTM.SECTIONCODERF=MTSSLPM.MNGSECTIONCODERF" + Environment.NewLine);
                    #endregion  //従業員別売上目標設定マスタ]
                }


            }

            //当期分を抽出するかどうか
            if (paramWork.PrintType != (int)PrintType.Month)  //PrintType -> 0:当月 1:当期 2:当月＆当期
            {
                //当期分集計

                #region [売上月次集計データ]
                if (paramWork.PrintType == (int)PrintType.All)
                {
                    #region [当月＆当期の場合の当期抽出条件]
                    //selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                    selectTxt += "  RIGHT JOIN (" + Environment.NewLine;
                    selectTxt += "   SELECT" + Environment.NewLine;
                    selectTxt += "     MTSSLPA.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "    ,MTSSLPA.EMPLOYEEDIVCDRF" + Environment.NewLine;
                    selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPA");
                    selectTxt += "    ,MTSSLPA.ANNUALSALESMONEY" + Environment.NewLine;
                    selectTxt += "    ,MTSSLPA.ANNUALSALESRETGOODSPRICE" + Environment.NewLine;
                    selectTxt += "    ,MTSSLPA.ANNUALDISCOUNTPRICE" + Environment.NewLine;
                    selectTxt += "    ,MTSSLPA.ANNUALGROSSPROFIT" + Environment.NewLine;
                    selectTxt += "    ,EMSTGTA.ANNUALSALESTARGETMONEY" + Environment.NewLine;
                    selectTxt += "    ,EMSTGTA.ANNUALSALESTARGETPROFIT" + Environment.NewLine;
                    selectTxt += IFBy(bMngSectionCode,
                                 "     ,MTSSLPA.MNGSECTIONCODERF" + Environment.NewLine);
                    selectTxt += "   FROM" + Environment.NewLine;
                    selectTxt += "   (" + Environment.NewLine;
                    #endregion  //[当月＆当期の場合の当期抽出条件]
                }
                selectTxt += "    SELECT" + Environment.NewLine;
                selectTxt += "      MTSSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     ,MTSSLPSUB2.EMPLOYEEDIVCDRF" + Environment.NewLine;
                selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPSUB2");
                selectTxt += "     ,SUM(MTSSLPSUB2.SALESMONEYRF)" + Environment.NewLine;
                selectTxt += "       AS ANNUALSALESMONEY" + Environment.NewLine;
                selectTxt += "     ,SUM(MTSSLPSUB2.SALESRETGOODSPRICERF)" + Environment.NewLine;
                selectTxt += "       AS ANNUALSALESRETGOODSPRICE" + Environment.NewLine;
                selectTxt += "     ,SUM(MTSSLPSUB2.DISCOUNTPRICERF)" + Environment.NewLine;
                selectTxt += "       AS ANNUALDISCOUNTPRICE" + Environment.NewLine;
                selectTxt += "     ,SUM(MTSSLPSUB2.GROSSPROFITRF)" + Environment.NewLine;
                selectTxt += "       AS ANNUALGROSSPROFIT" + Environment.NewLine;
                selectTxt += IFBy(bMngSectionCode,
                             "     ,MTSSLPSUB2.MNGSECTIONCODERF" + Environment.NewLine);

                if (bMngSectionCode)
                {
                    #region [管理拠点順絞込み様サブクエリ]
                    selectTxt += "    FROM" + Environment.NewLine;
                    selectTxt += "    (" + Environment.NewLine;

                    selectTxt += "     SELECT" + Environment.NewLine;
                    selectTxt += "       MTSSLPSUB2_1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "      ,MTSSLPSUB2_1.LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += "      ,MTSSLPSUB2_1.EMPLOYEEDIVCDRF" + Environment.NewLine;
                    selectTxt += "      ,MTSSLPSUB2_1.EMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += "      ,MTSSLPSUB2_1.SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "      ,MTSSLPSUB2_1.SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "      ,MTSSLPSUB2_1.DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "      ,MTSSLPSUB2_1.GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "      ,MTSSLPSUB2_1.RSLTTTLDIVCDRF" + Environment.NewLine;
                    selectTxt += "      ,MTSSLPSUB2_1.ADDUPYEARMONTHRF" + Environment.NewLine;
                    selectTxt += "      ,MTSSLPSUB2_1.CUSTOMERCODERF" + Environment.NewLine;
                    selectTxt += "      ,CUTMERSUB2_1.MNGSECTIONCODERF" + Environment.NewLine;
                    // 2011/07/29 >>>
                    //selectTxt += "     FROM MTTLSALESSLIPRF AS MTSSLPSUB2_1" + Environment.NewLine;
                    //selectTxt += "     LEFT JOIN CUSTOMERRF CUTMERSUB2_1" + Environment.NewLine;
                    selectTxt += "     FROM MTTLSALESSLIPRF AS MTSSLPSUB2_1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "     LEFT JOIN CUSTOMERRF CUTMERSUB2_1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    // 2011/07/29 <<<
                    selectTxt += "     ON  CUTMERSUB2_1.ENTERPRISECODERF=MTSSLPSUB2_1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "     AND CUTMERSUB2_1.CUSTOMERCODERF=MTSSLPSUB2_1.CUSTOMERCODERF" + Environment.NewLine;
                    selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.Annual, "MTSSLPSUB2_1");
                    selectTxt += "    ) AS MTSSLPSUB2" + Environment.NewLine;
                    #endregion  //[管理拠点順絞込み様サブクエリ]
                }
                else
                {
                    //管理拠点順以外
                    // 2011/07/29 >>>
                    //selectTxt += "   FROM MTTLSALESSLIPRF AS MTSSLPSUB2" + Environment.NewLine;
                    selectTxt += "   FROM MTTLSALESSLIPRF AS MTSSLPSUB2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    // 2011/07/29 <<<
                }
                selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.Annual, "MTSSLPSUB2");
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,MTSSLPSUB2.EMPLOYEEDIVCDRF" + Environment.NewLine;
                selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPSUB2");
                selectTxt += IFBy(bMngSectionCode,
                             "    ,MTSSLPSUB2.MNGSECTIONCODERF" + Environment.NewLine);
                selectTxt += "  ) AS MTSSLPA" + Environment.NewLine;
                #endregion  //[売上月次集計データ]

                if (bCustomerRF == true)
                {
                    #region [得意先別売上目標設定マスタ]
                    selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                    selectTxt += "   SELECT" + Environment.NewLine;
                    selectTxt += "     CUSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bAddUpSecCode,
                                 "    ,CUSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bMngSectionCode,
                                 "    ,CUSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bCustomerCode,
                                 "    ,CUSTGTSUB2.CUSTOMERCODERF" + Environment.NewLine);
                    selectTxt += "    ,SUM(CUSTGTSUB2.SALESTARGETMONEYRF)" + Environment.NewLine;
                    selectTxt += "      AS ANNUALSALESTARGETMONEY" + Environment.NewLine;
                    selectTxt += "    ,SUM(CUSTGTSUB2.SALESTARGETPROFITRF)" + Environment.NewLine;
                    selectTxt += "      AS ANNUALSALESTARGETPROFIT" + Environment.NewLine;
                    // 2011/07/29 >>>
                    //selectTxt += "   FROM CUSTSALESTARGETRF AS CUSTGTSUB2" + Environment.NewLine;
                    selectTxt += "   FROM CUSTSALESTARGETRF AS CUSTGTSUB2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    // 2011/07/29 <<<
                    selectTxt += MakeWhereString_CustTgt(ref sqlCommand, paramWork, (int)PrintType.Annual, "CUSTGTSUB2");
                    selectTxt += "   GROUP BY" + Environment.NewLine;
                    selectTxt += "     CUSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bAddUpSecCode,
                                 "    ,CUSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bMngSectionCode,
                                 "    ,CUSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bCustomerCode,
                                 "    ,CUSTGTSUB2.CUSTOMERCODERF" + Environment.NewLine);
                    selectTxt += "  ) AS EMSTGTA" + Environment.NewLine;
                    selectTxt += "  ON  EMSTGTA.ENTERPRISECODERF=MTSSLPA.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bAddUpSecCode,
                                 "  AND EMSTGTA.SECTIONCODERF=MTSSLPA.ADDUPSECCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bMngSectionCode,
                                 "  AND EMSTGTA.SECTIONCODERF=MTSSLPA.MNGSECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bCustomerCode,
                                 "  AND EMSTGTA.CUSTOMERCODERF=MTSSLPA.CUSTOMERCODERF" + Environment.NewLine);
                    #endregion  //[得意先別売上目標設定マスタ]
                }
                else
                {
                    #region [従業員別売上目標設定マスタ]
                    selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                    selectTxt += "   SELECT" + Environment.NewLine;
                    selectTxt += "     EMSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bAddUpSecCode,
                                 "    ,EMSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bMngSectionCode,
                                 "    ,EMSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                    selectTxt += "    ,EMSTGTSUB2.EMPLOYEEDIVCDRF" + Environment.NewLine;
                    selectTxt += "    ,EMSTGTSUB2.EMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += "    ,SUM(EMSTGTSUB2.SALESTARGETMONEYRF)" + Environment.NewLine;
                    selectTxt += "      AS ANNUALSALESTARGETMONEY" + Environment.NewLine;
                    selectTxt += "    ,SUM(EMSTGTSUB2.SALESTARGETPROFITRF)" + Environment.NewLine;
                    selectTxt += "      AS ANNUALSALESTARGETPROFIT" + Environment.NewLine;
                    // 2011/07/29 >>>
                    //selectTxt += "   FROM EMPSALESTARGETRF AS EMSTGTSUB2" + Environment.NewLine;
                    selectTxt += "   FROM EMPSALESTARGETRF AS EMSTGTSUB2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    // 2011/07/29 <<<
                    selectTxt += MakeWhereString_EmpTgt(ref sqlCommand, paramWork, (int)PrintType.Annual, "EMSTGTSUB2");
                    selectTxt += "   GROUP BY" + Environment.NewLine;
                    selectTxt += "     EMSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bAddUpSecCode,
                                 "    ,EMSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bMngSectionCode,
                                 "    ,EMSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                    selectTxt += "    ,EMSTGTSUB2.EMPLOYEEDIVCDRF" + Environment.NewLine;
                    selectTxt += "    ,EMSTGTSUB2.EMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += "  ) AS EMSTGTA" + Environment.NewLine;
                    selectTxt += "  ON  EMSTGTA.ENTERPRISECODERF=MTSSLPA.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  AND EMSTGTA.EMPLOYEEDIVCDRF=MTSSLPA.EMPLOYEEDIVCDRF" + Environment.NewLine;
                    selectTxt += "  AND EMSTGTA.EMPLOYEECODERF=MTSSLPA.EMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bAddUpSecCode,
                                 "  AND EMSTGTA.SECTIONCODERF=MTSSLPA.ADDUPSECCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bMngSectionCode,
                                 "  AND EMSTGTA.SECTIONCODERF=MTSSLPA.MNGSECTIONCODERF" + Environment.NewLine);
                    #endregion  //[従業員別売上目標設定マスタ]
                }

            }

            #endregion  //[データ抽出メインQuery]

            #region [当月＆当期の場合の当月分と当期分の結合条件]
            if (paramWork.PrintType == (int)PrintType.All)  //PrintType -> 0:当月 1:当期 2:当月＆当期
            {
                selectTxt += "  ) AS MTSSLPASUB" + Environment.NewLine;
                selectTxt += "  ON  MTSSLPASUB.ENTERPRISECODERF=MTSSLPM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND MTSSLPASUB.EMPLOYEEDIVCDRF=MTSSLPM.EMPLOYEEDIVCDRF" + Environment.NewLine;
                selectTxt += "  AND MTSSLPASUB.EMPLOYEECODERF=MTSSLPM.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += IFBy(bCustomerCode,
                             "  AND MTSSLPASUB.CUSTOMERCODERF=MTSSLPM.CUSTOMERCODERF" + Environment.NewLine);
                if (paramWork.TtlType == 1)
                {
                    if (bMngSectionCode)
                        selectTxt += "  AND MTSSLPASUB.MNGSECTIONCODERF=MTSSLPM.MNGSECTIONCODERF" + Environment.NewLine;
                    else
                        selectTxt += "  AND MTSSLPASUB.ADDUPSECCODERF=MTSSLPM.ADDUPSECCODERF" + Environment.NewLine;
                }
            }
            #endregion

            #endregion  //[売上月次集計データ＋従業員別売上目標設定マスタ抽出用サブクエリ]

            selectTxt += " ) AS MTSSLP" + Environment.NewLine;

            #region [JOIN]
            //従業員マスタ
            // 2011/07/29 >>>
            //selectTxt += " LEFT JOIN EMPLOYEERF EMPLOY" + Environment.NewLine;
            selectTxt += " LEFT JOIN EMPLOYEERF EMPLOY WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<
            selectTxt += " ON  EMPLOY.ENTERPRISECODERF=MTSSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND EMPLOY.EMPLOYEECODERF=MTSSLP.EMPLOYEECODERF" + Environment.NewLine;

            if (bCustomerRF)
            {
                //得意先マスタ
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN CUSTOMERRF CUTMER" + Environment.NewLine;
                selectTxt += " LEFT JOIN CUSTOMERRF CUTMER WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  CUTMER.ENTERPRISECODERF=MTSSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUTMER.CUSTOMERCODERF=MTSSLP.CUSTOMERCODERF" + Environment.NewLine;
            }
            if (bCompanyNmRF)
            {
                //拠点情報設定マスタ
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  SCINST.ENTERPRISECODERF=MTSSLP.ENTERPRISECODERF" + Environment.NewLine;
                if (bMngSectionCode)
                    selectTxt += " AND SCINST.SECTIONCODERF=MTSSLP.MNGSECTIONCODERF" + Environment.NewLine;
                else
                    selectTxt += " AND SCINST.SECTIONCODERF=MTSSLP.ADDUPSECCODERF" + Environment.NewLine;
            }
            #endregion  //[JOIN]

            #endregion  //[Select文作成]

            return selectTxt;
        }
        #endregion  //[EmpSalesTarget用 Select文生成処理]

        #region [MTtlSalesSlip用 Where句生成処理]
        /// <summary>
        /// 売上月次集計データ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件</param>
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
            switch ((int)paramWork.TotalType)
            {
                case (int)TotalType.Agent:    //Agent   -> 担当者別
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)EmployeeDivCd.Agent);
                    break;
                case (int)TotalType.AcpOdr:   //AcpOdr  -> 受注者別
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)EmployeeDivCd.AcpOdr);
                    break;
                case (int)TotalType.Pblsher:  //Pblsher -> 発行者別
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)EmployeeDivCd.Pblsher);
                    break;
                default:
                    break;
            }

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
            if (paramWork.CustomerCodeEd != 99999999)
            {
                retstring += " AND " + sTblNm + ".CUSTOMERCODERF<=@" + sTblNm + "CUSTOMERCODEED" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeEd);
            }

            //従業員コード
            if (paramWork.SrchCodeSt != "")
            {
                retstring += " AND " + sTblNm + ".EMPLOYEECODERF>=@" + sTblNm + "EMPLOYEECODEST" + Environment.NewLine;
                SqlParameter paraSrchCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "EMPLOYEECODEST", SqlDbType.NChar);
                paraSrchCodeSt.Value = SqlDataMediator.SqlSetString(paramWork.SrchCodeSt);
            }
            if ((paramWork.SrchCodeEd != ""))
            {
                retstring += " AND " + sTblNm + ".EMPLOYEECODERF<=@" + sTblNm + "EMPLOYEECODEED" + Environment.NewLine;
                SqlParameter paraSrchCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "EMPLOYEECODEED", SqlDbType.NChar);
                paraSrchCodeEd.Value = SqlDataMediator.SqlSetString(paramWork.SrchCodeEd);
            }
            #endregion

            return retstring;
        }
        #endregion  //[MTtlSalesSlip用 Where句生成処理]

        #region [EmpSalesTarget用 Where句生成処理]
        /// <summary>
        /// 従業員別売上目標設定マスタ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件</param>
        /// <returns>従業員別売上目標設定マスタ用WHERE句</returns>
        /// <br>Note       : 売上履歴データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        private string MakeWhereString_EmpTgt(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork, Int32 iPrintType, string sTblNm)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //従業員区分
            retstring += " AND " + sTblNm + ".EMPLOYEEDIVCDRF=@" + sTblNm + "EMPLOYEEDIVCD" + Environment.NewLine;
            SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@" + sTblNm + "EMPLOYEEDIVCD", SqlDbType.Int);
            switch ((int)paramWork.TotalType)
            {
                case (int)TotalType.Agent:    //Agent   -> 担当者別
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)EmployeeDivCd.Agent);
                    // ADD 2008.12.08 >>>
                    retstring += " AND " + sTblNm + ".TARGETCONTRASTCDRF=22 AND EMPLOYEEDIVCDRF=10 " + Environment.NewLine;
                    // ADD 2008.12.08 <<<

                    break;
                case (int)TotalType.AcpOdr:   //AcpOdr  -> 受注者別
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)EmployeeDivCd.AcpOdr);
                    // ADD 2008.12.08 >>>
                    retstring += " AND " + sTblNm + ".TARGETCONTRASTCDRF=22 AND EMPLOYEEDIVCDRF=20 " + Environment.NewLine;
                    // ADD 2008.12.08 <<<
                    break;
                case (int)TotalType.Pblsher:  //Pblsher -> 発行者別
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)EmployeeDivCd.Pblsher);
                    // ADD 2008.12.08 >>>
                    retstring += " AND " + sTblNm + ".TARGETCONTRASTCDRF=22 AND EMPLOYEEDIVCDRF=30 " + Environment.NewLine;
                    // ADD 2008.12.08 <<<
                    break;
                default:
                    break;
            }
            // ADD 2008.12.08 >>>
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
        #endregion  //[EmpSalesTarget用 Where句生成処理]

        #region [CustSalesTarget用 Where句生成処理]
        /// <summary>
        /// 得意先別売上目標設定マスタ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件</param>
        /// <returns>得意先別売上目標設定マスタ用WHERE句</returns>
        /// <br>Note       : 得意先別売上目標設定マスタ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        private string MakeWhereString_CustTgt(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork, Int32 iPrintType, string sTblNm)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            // DEL 2008.12.08 >>>
            //得意先コード
            //if (paramWork.CustomerCodeSt != 0)
            //{
            //    retstring += " AND " + sTblNm + ".CUSTOMERCODERF>=@" + sTblNm + "CUSTOMERCODEST" + Environment.NewLine;
            //    SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEST", SqlDbType.Int);
            //    paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeSt);
            //}
            //if (paramWork.CustomerCodeEd != 99999999)
            //{
            //    retstring += " AND " + sTblNm + ".CUSTOMERCODERF<=@" + sTblNm + "CUSTOMERCODEED" + Environment.NewLine;
            //    SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEED", SqlDbType.Int);
            //    paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeEd);
            //}
            // DEL 2008.12.08 <<<

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


            //検索コード
            switch (paramWork.TotalType)
            {
                case (int)TotalType.Customer:
                    // ADD 2008.12.08 >>>
                    retstring += " AND " + sTblNm + ".TARGETCONTRASTCDRF=30" + Environment.NewLine;
                    // ADD 2008.12.08 <<<
                    //得意先コード
                    if (paramWork.CustomerCodeSt != 0)
                    {
                        retstring += " AND " + sTblNm + ".CUSTOMERCODERF>=@" + sTblNm + "CUSTOMERCODEST" + Environment.NewLine;
                        SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEST", SqlDbType.Int);
                        paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeSt);
                    }
                    if (paramWork.CustomerCodeEd != 99999999)
                    {
                        retstring += " AND " + sTblNm + ".CUSTOMERCODERF<=@" + sTblNm + "CUSTOMERCODEED" + Environment.NewLine;
                        SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEED", SqlDbType.Int);
                        paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeEd);
                    }

                    break;
                case (int)TotalType.Area:
                    #region [地区別]
                    //地区コード
                    // ADD 2008.12.08 >>>
                    retstring += " AND " + sTblNm + ".TARGETCONTRASTCDRF=32" + Environment.NewLine;
                    // ADD 2008.12.08 <<<
                    //if (paramWork.SrchCodeSt != "") // DEL 2008.12.08
                    if (paramWork.SrchCodeSt != "" && paramWork.SrchCodeSt != null) // ADD 2008.12.08
                    {
                        Int32 iSalesAreaCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //パラメータのキャスト
                        retstring += " AND " + sTblNm + ".SALESAREACODERF>=@" + sTblNm + "SALESAREACODEST" + Environment.NewLine;
                        SqlParameter paraSalesAreaCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESAREACODEST", SqlDbType.Int);
                        paraSalesAreaCodeSt.Value = SqlDataMediator.SqlSetInt32(iSalesAreaCodeSt);
                    }
                    //if ((paramWork.SrchCodeEd != "")) // DEL 2008.12.08
                    if ((paramWork.SrchCodeEd != "") && (paramWork.SrchCodeEd != null)) // ADD 2008.12.08
                    {
                        Int32 iSalesAreaCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //パラメータのキャスト
                        retstring += " AND " + sTblNm + ".SALESAREACODERF<=@" + sTblNm + "SALESAREACODEED" + Environment.NewLine;
                        SqlParameter paraSalesAreaCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESAREACODEED", SqlDbType.Int);
                        paraSalesAreaCodeEd.Value = SqlDataMediator.SqlSetInt32(iSalesAreaCodeEd);
                    }
                    #endregion
                    break;
                case (int)TotalType.BzType:
                    #region [業種別]
                    //業種コード
                    // ADD 2008.12.08 >>>
                    retstring += " AND " + sTblNm + ".TARGETCONTRASTCDRF=31" + Environment.NewLine;
                    // ADD 2008.12.08 <<<
                    //if (paramWork.SrchCodeSt != "") // DEL 2008.12.08
                    if (paramWork.SrchCodeSt != "" && paramWork.SrchCodeSt != null) // ADD 2008.12.08
                    {
                        Int32 iBusinessTypeCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //パラメータのキャスト
                        retstring += " AND " + sTblNm + ".BUSINESSTYPECODERF>=@" + sTblNm + "BUSINESSTYPECODEST" + Environment.NewLine;
                        SqlParameter paraBusinessTypeCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "BUSINESSTYPECODEST", SqlDbType.Int);
                        paraBusinessTypeCodeSt.Value = SqlDataMediator.SqlSetInt32(iBusinessTypeCodeSt);
                    }
                    //if ((paramWork.SrchCodeEd != "")) // DEL 2008.12.08
                    if ((paramWork.SrchCodeEd != "") && (paramWork.SrchCodeEd != null)) // ADD 2008.12.08
                    {
                        Int32 iBusinessTypeCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //パラメータのキャスト
                        retstring += " AND " + sTblNm + ".BUSINESSTYPECODERF<=@" + sTblNm + "BUSINESSTYPECODEED" + Environment.NewLine;
                        SqlParameter paraBusinessTypeCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "BUSINESSTYPECODEED", SqlDbType.Int);
                        paraBusinessTypeCodeEd.Value = SqlDataMediator.SqlSetInt32(iBusinessTypeCodeEd);
                    }
                    #endregion
                    break;
                default:
                    break;
            }
            #endregion

            return retstring;
        }
        #endregion  //[CustSalesTarget用 Where句生成処理]


        #region [SalesMonthYearReportResultWork処理 呼出]
        /// <summary>
        /// クラス格納処理 Reader → SalesMonthYearReportResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesMonthYearReportResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
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
        /// </remarks>
        private SalesMonthYearReportResultWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, SalesMonthYearReportParamWork paramWork)
        {
            #region [抽出結果-値セット]
            SalesMonthYearReportResultWork resultWork = new SalesMonthYearReportResultWork();

            resultWork.Code = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            resultWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));

            if (paramWork.TtlType == 1)
            {
                if (paramWork.OutType == 3)
                    resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                else
                    resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                resultWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            }

            if (paramWork.OutType == 1)
            {
                resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
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
