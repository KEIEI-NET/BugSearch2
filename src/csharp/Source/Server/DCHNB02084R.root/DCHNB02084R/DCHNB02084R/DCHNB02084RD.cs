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
    class MTtlSaSlip_Cust : MTtlSaSlipBase, IMTtlSaSlip
    {
        #region [CustSalesTarget用 Select文生]
        /// <summary>
        /// 得意先別売上目標設定マスタ用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <returns>得意先別売上目標設定マスタ用SELECT文</returns>
        /// <br>Note       : 得意先別売上目標設定マスタ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        /// <br>UpdateNote : 2013/07/11 liusy</br>
        /// <br>管理番号   : 10801804-00  redmine #38169 売上月報年報を順位順にして出力先を請求先にした時に</br>
        /// <br>           : 請求の親子関係を組んでいる得意先で請求子の売上金額が請求親に合算されない</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork)
        {
            string selectTxt = "";

            switch (paramWork.TotalType)
            {
                case (int)TotalType.Customer:  //得意先別
                    selectTxt = MakeTypeCustomerQuery(ref sqlCommand, paramWork);
                    break;
                case (int)TotalType.Area:      //地区別
                case (int)TotalType.BzType:    //業種別
                    selectTxt = MakeTypeAreaBzTypeQuery(ref sqlCommand, paramWork);
                    break;
                default:
                    break;
            }

            return selectTxt;
        }
        #endregion  //[CustSalesTarget用 Select文生]

        #region [得意先別用 Select文生成処理]
        /// <summary>
        /// 得意先別売上目標設定マスタ用SELECT文 生成処理(得意先別用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <returns>得意先別用SELECT文</returns>
        /// <br>Note       : 得意先別SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        /// <br>UpdateNote : 2013/07/11 liusy</br>
        /// <br>管理番号   : 10801804-00  redmine #38169</br>
        private string MakeTypeCustomerQuery(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork)
        {
            #region [判別用フラグ]
            //得意先コード検索フラグ
            bool bCustomerCode = false;
            if ((paramWork.OutType == 0) ||
                (paramWork.OutType == 2) ||
                (paramWork.OutType == 3) ||
                (paramWork.OutType == 4))
            {
                bCustomerCode = true;
            }

            //拠点コード検索フラグ
            bool bSectionCode = false;
            if (((paramWork.TtlType == 1) && (paramWork.OutType == 0)) ||
                ((paramWork.TtlType == 1) && (paramWork.OutType == 1)) ||
                ((paramWork.TtlType == 1) && (paramWork.OutType == 2)) ||
                ((paramWork.TtlType == 1) && (paramWork.OutType == 4)))
            {
                bSectionCode = true;
            }

            //管理拠点コード検索フラグ
            bool bMngSectionCode = false;
            if ((paramWork.TtlType == 1) && (paramWork.OutType == 3))
            {
                bMngSectionCode = true;
            }

            //請求先コード検索フラグ
            bool bClaimCode = false;
            if (paramWork.OutType == 4)
            {
                bClaimCode = true;
            }

            //得意先マスタ検索フラグ
            bool bCustomerRF = false;
            if ((paramWork.OutType == 0) ||
                (paramWork.OutType == 2) ||
                (paramWork.OutType == 3) ||
                (paramWork.OutType == 4))
            {
                bCustomerRF = true;
            }

            //自社名称マスタ検索フラグ
            bool bCompanyNmRF = false;
            if (paramWork.TtlType == 1)
            {
                bCompanyNmRF = true;
            }
            #endregion

            string selectTxt = "";

            // 対象テーブル
            // MTTLSALESSLIPRF   MTSSLP 売上月次集計データ
            // CUSTSALESTARGETRF CUSTGT 得意先別売上目標設定マスタ
            // CUSTOMERRF        CUTMER 得意先マスタ
            // SECINFOSETRF      SCINST 拠点情報設定マスタ

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
            selectTxt += IFBy(bCompanyNmRF, " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
            selectTxt += IFBy(bCustomerRF, " ,CUTMER.CUSTOMERSNMRF" + Environment.NewLine);
            selectTxt += IFBy(bMngSectionCode, " ,MTSSLP.MNGSECTIONCODERF" + Environment.NewLine);
            selectTxt += IFBy(bClaimCode, " ,MTSSLP.CLAIMCODERF" + Environment.NewLine);

            //FROM
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            #region [売上月次集計データ＋得意先別売上目標設定マスタ抽出用サブクエリ]
            selectTxt += " SELECT" + Environment.NewLine;
            //印刷タイプによって抽出項目を動的生成する
            switch (paramWork.PrintType)
            {
                #region [印刷タイプ判別]

                case (int)PrintType.Month:
                    #region [当月]
                    selectTxt += "   MTSSLPM.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bMngSectionCode,
                                 "  ,MTSSLPM.MNGSECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bClaimCode,
                                 "  ,MTSSLPM.CLAIMCODERF" + Environment.NewLine);
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLPM");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "CUSTGTM");
                    selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPM");
                    #endregion
                    break;
                case (int)PrintType.Annual:
                    #region [当期]
                    selectTxt += "   MTSSLPA.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bMngSectionCode,
                                 "  ,MTSSLPA.MNGSECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bClaimCode,
                                 "  ,MTSSLPA.CLAIMCODERF" + Environment.NewLine);
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Annual, "MTSSLPA");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Annual, "CUSTGTA");
                    selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPA");
                    #endregion
                    break;
                case (int)PrintType.All:
                    #region [当月＆当期]
                    selectTxt += "   MTSSLPASUB.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += IFBy(bMngSectionCode,
                                 "  ,MTSSLPASUB.MNGSECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bClaimCode,
                                 "  ,MTSSLPASUB.CLAIMCODERF" + Environment.NewLine);
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLPM");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "CUSTGTM");
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
            string sSecNm = "ADDUPSECCODERF";

            //当月分を抽出するかどうか
            if (paramWork.PrintType != (int)PrintType.Annual)  //PrintType -> 0:当月 1:当期 2:当月＆当期
            {
                //当月分集計

                #region [売上月次集計データ]
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB1.ENTERPRISECODERF" + Environment.NewLine;
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
                selectTxt += IFBy(bClaimCode,
                             "    ,MTSSLPSUB1.CLAIMCODERF" + Environment.NewLine);

                if ((bMngSectionCode) || (bClaimCode))
                {
                    #region [管理拠点順、請求先順絞込み用サブクエリ]
                    selectTxt += "   FROM" + Environment.NewLine;
                    selectTxt += "   (" + Environment.NewLine;
                    selectTxt += "    SELECT" + Environment.NewLine;
                    selectTxt += "      MTSSLPSUB1_1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB1_1.SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB1_1.SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB1_1.DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB1_1.GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB1_1.RSLTTTLDIVCDRF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB1_1.EMPLOYEEDIVCDRF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB1_1.ADDUPYEARMONTHRF" + Environment.NewLine;
                    //selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPSUB1_1");  //DEL BY LIUSY #38169 2013/07/11
                    //ADD BY LIUSY #38169 2013/07/11 ---->>>> 
                    if (!bClaimCode)
                    {
                        selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPSUB1_1");
                    }
                    else
                    {
                        selectTxt += "     ,CUTMERSUB1_1.CLAIMSECTIONCODERF AS ADDUPSECCODERF" + Environment.NewLine;
                        selectTxt += "     ,CUTMERSUB1_1.CLAIMCODERF AS CUSTOMERCODERF" + Environment.NewLine;
                    }
                    //ADD BY LIUSY #38169 2013/07/11 ----<<<<
                    selectTxt += IFBy(bMngSectionCode,
                                 "    ,CUTMERSUB1_1.MNGSECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bClaimCode,
                                 "    ,CUTMERSUB1_1.CLAIMCODERF" + Environment.NewLine);
                    // 2011/07/29 >>>
                    //selectTxt += "    FROM MTTLSALESSLIPRF AS MTSSLPSUB1_1" + Environment.NewLine;
                    //selectTxt += "    LEFT JOIN CUSTOMERRF CUTMERSUB1_1" + Environment.NewLine;
                    selectTxt += "    FROM MTTLSALESSLIPRF AS MTSSLPSUB1_1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "    LEFT JOIN CUSTOMERRF CUTMERSUB1_1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    // 2011/07/29 <<<
                    selectTxt += "    ON  CUTMERSUB1_1.ENTERPRISECODERF=MTSSLPSUB1_1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "    AND CUTMERSUB1_1.CUSTOMERCODERF=MTSSLPSUB1_1.CUSTOMERCODERF" + Environment.NewLine;
                    selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.Month, "MTSSLPSUB1_1", sSecNm);
                    selectTxt += MakeWhereString_Cust(ref sqlCommand, paramWork, "CUTMERSUB1_1");
                    selectTxt += "   ) AS MTSSLPSUB1" + Environment.NewLine;
                    #endregion  //[管理拠点順、請求先順絞込み用サブクエリ]

                    if (bMngSectionCode)
                        sSecNm = "MNGSECTIONCODERF";
                }
                else
                {
                    //管理拠点順、請求先順以外
                    // 2011/07/29 >>>
                    //selectTxt += "   FROM MTTLSALESSLIPRF AS MTSSLPSUB1" + Environment.NewLine;
                    selectTxt += "   FROM MTTLSALESSLIPRF AS MTSSLPSUB1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    // 2011/07/29 <<<
                }

                selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.Month, "MTSSLPSUB1", sSecNm);
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPSUB1");
                selectTxt += IFBy(bMngSectionCode,
                             "    ,MTSSLPSUB1.MNGSECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bClaimCode,
                             "    ,MTSSLPSUB1.CLAIMCODERF" + Environment.NewLine);
                selectTxt += "  ) AS MTSSLPM" + Environment.NewLine;
                #endregion  //[売上月次集計データ]

                #region [得意先別売上目標設定マスタ]
                selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     CUSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bSectionCode,
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
                selectTxt += IFBy(bSectionCode,
                             "    ,CUSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bMngSectionCode,
                             "    ,CUSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bCustomerCode,
                             "    ,CUSTGTSUB1.CUSTOMERCODERF" + Environment.NewLine);
                selectTxt += "  ) AS CUSTGTM" + Environment.NewLine;
                selectTxt += "  ON  CUSTGTM.ENTERPRISECODERF=MTSSLPM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bSectionCode,
                             "  AND CUSTGTM.SECTIONCODERF=MTSSLPM.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bMngSectionCode,
                             "  AND CUSTGTM.SECTIONCODERF=MTSSLPM.MNGSECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bCustomerCode,
                             "  AND CUSTGTM.CUSTOMERCODERF=MTSSLPM.CUSTOMERCODERF" + Environment.NewLine);
                #endregion  //[得意先別売上目標設定マスタ]
            }

            //当期分を抽出するかどうか
            if (paramWork.PrintType != (int)PrintType.Month)  //PrintType -> 0:当月 1:当期 2:当月＆当期
            {
                sSecNm = "ADDUPSECCODERF";
                //当期分集計

                #region [売上月次集計データ]
                if (paramWork.PrintType == (int)PrintType.All)
                {
                    #region [当月＆当期の場合の当期抽出条件]
                    //selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                    selectTxt += "  RIGHT JOIN (" + Environment.NewLine;
                    selectTxt += "   SELECT" + Environment.NewLine;
                    selectTxt += "     MTSSLPA.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPA");
                    selectTxt += "    ,MTSSLPA.ANNUALSALESMONEY" + Environment.NewLine;
                    selectTxt += "    ,MTSSLPA.ANNUALSALESRETGOODSPRICE" + Environment.NewLine;
                    selectTxt += "    ,MTSSLPA.ANNUALDISCOUNTPRICE" + Environment.NewLine;
                    selectTxt += "    ,MTSSLPA.ANNUALGROSSPROFIT" + Environment.NewLine;
                    selectTxt += "    ,CUSTGTA.ANNUALSALESTARGETMONEY" + Environment.NewLine;
                    selectTxt += "    ,CUSTGTA.ANNUALSALESTARGETPROFIT" + Environment.NewLine;
                    selectTxt += IFBy(bMngSectionCode,
                                 "     ,MTSSLPA.MNGSECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bClaimCode,
                                 "     ,MTSSLPA.CLAIMCODERF" + Environment.NewLine);
                    selectTxt += "   FROM" + Environment.NewLine;
                    selectTxt += "   (" + Environment.NewLine;
                    #endregion  //[当月＆当期の場合の当期抽出条件]
                }
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPSUB2");
                selectTxt += "    ,SUM(MTSSLPSUB2.SALESMONEYRF)" + Environment.NewLine;
                selectTxt += "      AS ANNUALSALESMONEY" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB2.SALESRETGOODSPRICERF)" + Environment.NewLine;
                selectTxt += "      AS ANNUALSALESRETGOODSPRICE" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB2.DISCOUNTPRICERF)" + Environment.NewLine;
                selectTxt += "      AS ANNUALDISCOUNTPRICE" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB2.GROSSPROFITRF)" + Environment.NewLine;
                selectTxt += "      AS ANNUALGROSSPROFIT" + Environment.NewLine;
                selectTxt += IFBy(bMngSectionCode,
                             "    ,MTSSLPSUB2.MNGSECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bClaimCode,
                             "    ,MTSSLPSUB2.CLAIMCODERF" + Environment.NewLine);

                if ((bMngSectionCode) || (bClaimCode))
                {
                    #region [管理拠点順、請求先順絞込み様サブクエリ]
                    selectTxt += "   FROM" + Environment.NewLine;
                    selectTxt += "   (" + Environment.NewLine;
                    selectTxt += "    SELECT" + Environment.NewLine;
                    selectTxt += "      MTSSLPSUB2_1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB2_1.SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB2_1.SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB2_1.DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB2_1.GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB2_1.RSLTTTLDIVCDRF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB2_1.EMPLOYEEDIVCDRF" + Environment.NewLine;
                    selectTxt += "     ,MTSSLPSUB2_1.ADDUPYEARMONTHRF" + Environment.NewLine;
                    //selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPSUB2_1"); //DEL BY LIUSY #38169 2013/07/11
                    //ADD BY LIUSY #38169 2013/07/11 ---->>>> 
                    if (!bClaimCode)
                    {
                        selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPSUB2_1");
                    }
                    else
                    {
                        selectTxt += "     ,CUTMERSUB2_1.CLAIMSECTIONCODERF AS ADDUPSECCODERF" + Environment.NewLine;
                        selectTxt += "     ,CUTMERSUB2_1.CLAIMCODERF AS CUSTOMERCODERF" + Environment.NewLine;
                    }
                    //ADD BY LIUSY #38169 2013/07/11 ----<<<<

                    selectTxt += IFBy(bMngSectionCode,
                                 "    ,CUTMERSUB2_1.MNGSECTIONCODERF" + Environment.NewLine);
                    selectTxt += IFBy(bClaimCode,
                                 "    ,CUTMERSUB2_1.CLAIMCODERF" + Environment.NewLine);
                    // 2011/07/29 >>>
                    //selectTxt += "    FROM MTTLSALESSLIPRF AS MTSSLPSUB2_1" + Environment.NewLine;
                    //selectTxt += "    LEFT JOIN CUSTOMERRF CUTMERSUB2_1" + Environment.NewLine;
                    selectTxt += "    FROM MTTLSALESSLIPRF AS MTSSLPSUB2_1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "    LEFT JOIN CUSTOMERRF CUTMERSUB2_1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    // 2011/07/29 <<<
                    selectTxt += "    ON  CUTMERSUB2_1.ENTERPRISECODERF=MTSSLPSUB2_1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "    AND CUTMERSUB2_1.CUSTOMERCODERF=MTSSLPSUB2_1.CUSTOMERCODERF" + Environment.NewLine;
                    selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.Annual, "MTSSLPSUB2_1", sSecNm);
                    selectTxt += MakeWhereString_Cust(ref sqlCommand, paramWork, "CUTMERSUB2_1");
                    selectTxt += "   ) AS MTSSLPSUB2" + Environment.NewLine;
                    if (bMngSectionCode)
                        sSecNm = "MNGSECTIONCODERF";
                    #endregion  //[管理拠点順、請求先順絞込み様サブクエリ]
                }
                else
                {
                    //管理拠点順、請求先順以外
                    // 2011/07/29 >>>
                    //selectTxt += "   FROM MTTLSALESSLIPRF AS MTSSLPSUB2" + Environment.NewLine;
                    selectTxt += "   FROM MTTLSALESSLIPRF AS MTSSLPSUB2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    // 2011/07/29 <<<
                }

                selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.Annual, "MTSSLPSUB2", sSecNm);
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPSUB2");
                selectTxt += IFBy(bMngSectionCode,
                             "    ,MTSSLPSUB2.MNGSECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bClaimCode,
                             "    ,MTSSLPSUB2.CLAIMCODERF" + Environment.NewLine);
                selectTxt += "  ) AS MTSSLPA" + Environment.NewLine;
                #endregion  //[売上月次集計データ]

                #region [得意先別売上目標設定マスタ]
                selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     CUSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bSectionCode,
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
                selectTxt += IFBy(bSectionCode,
                             "    ,CUSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bMngSectionCode,
                             "    ,CUSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bCustomerCode,
                             "    ,CUSTGTSUB2.CUSTOMERCODERF" + Environment.NewLine);
                selectTxt += "  ) AS CUSTGTA" + Environment.NewLine;
                selectTxt += "  ON  CUSTGTA.ENTERPRISECODERF=MTSSLPA.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bSectionCode,
                             "  AND CUSTGTA.SECTIONCODERF=MTSSLPA.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bMngSectionCode,
                             "  AND CUSTGTA.SECTIONCODERF=MTSSLPA.MNGSECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bCustomerCode,
                             "  AND CUSTGTA.CUSTOMERCODERF=MTSSLPA.CUSTOMERCODERF" + Environment.NewLine);
                #endregion  //[得意先別売上目標設定マスタ]
            }

            #endregion  //[データ抽出メインQuery]

            #region [当月＆当期の場合の当月分と当期分の結合条件]
            if (paramWork.PrintType == (int)PrintType.All)  //PrintType -> 0:当月 1:当期 2:当月＆当期
            {
                selectTxt += "  ) AS MTSSLPASUB" + Environment.NewLine;
                selectTxt += "  ON  MTSSLPASUB.ENTERPRISECODERF=MTSSLPM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bCustomerCode,
                             "  AND MTSSLPASUB.CUSTOMERCODERF=MTSSLPM.CUSTOMERCODERF" + Environment.NewLine);
                selectTxt += IFBy(bClaimCode,
                             "  AND MTSSLPASUB.CLAIMCODERF=MTSSLPM.CLAIMCODERF" + Environment.NewLine);
                if (paramWork.TtlType == 1)
                {
                    if (bMngSectionCode)
                        selectTxt += "  AND MTSSLPASUB.MNGSECTIONCODERF=MTSSLPM.MNGSECTIONCODERF" + Environment.NewLine;
                    else
                        selectTxt += "  AND MTSSLPASUB.ADDUPSECCODERF=MTSSLPM.ADDUPSECCODERF" + Environment.NewLine;
                }
            }
            #endregion  //[当月＆当期の場合の当月分と当期分の結合条件]

            #endregion  //[売上月次集計データ＋得意先別売上目標設定マスタ抽出用サブクエリ]

            selectTxt += " ) AS MTSSLP" + Environment.NewLine;

            #region [JOIN]
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

            #endregion  //Select文作成]

            return selectTxt;
        }
        #endregion  //[得意先別用 Select文生成処理]

        #region [地区別用・業種別用 Select文生成処理]
        /// <summary>
        /// 得意先別売上目標設定マスタ用SELECT文 生成処理(地区別用・業種別用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <returns>地区別用・業種別用SELECT文</returns>
        /// <br>Note       : 地区別用・業種別用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        /// <br>UpdateNote : 2013/07/26 duzg</br>
        /// <br>管理番号   : 10801804-00  redmine #38722のNo.2</br>
        private string MakeTypeAreaBzTypeQuery(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork)
        {
            #region [判別用フラグ]
            //得意先コード検索フラグ
            bool bCustomerCode = false;
            if (paramWork.OutType == 1)
            {
                bCustomerCode = true;
            }

            //拠点コード検索フラグ
            bool bSectionCode = false;
            if (((paramWork.TtlType == 1) && (paramWork.OutType == 0)) ||
                ((paramWork.TtlType == 1) && (paramWork.OutType == 1)) ||
                ((paramWork.TtlType == 1) && (paramWork.OutType == 2)))
            {
                bSectionCode = true;
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

            //検索コード判別
            string sTblName = "";
            if (paramWork.TotalType == (int)TotalType.Area)
                sTblName = "SALESAREACODERF";
            else if (paramWork.TotalType == (int)TotalType.BzType)
                sTblName = "BUSINESSTYPECODERF";
            #endregion

            string selectTxt = "";

            // 対象テーブル
            // MTTLSALESSLIPRF   MTSSLP 売上月次集計データ
            // CUSTSALESTARGETRF CUSTGT 得意先別売上目標設定マスタ
            // CUSTOMERRF        CUTMER 得意先マスタ
            // SECINFOSETRF      SCINST 拠点情報設定マスタ
            // USERGDBDURF       USRGBU ユーザーガイドマスタ(ボディ)

            #region [Select文作成]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  MTSSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " ,MTSSLP." + sTblName + Environment.NewLine;
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
            selectTxt += " ,USRGBU.GUIDENAMERF" + Environment.NewLine;
            selectTxt += IFBy(bCompanyNmRF, " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
            selectTxt += IFBy(bCustomerRF, " ,CUTMER.CUSTOMERSNMRF" + Environment.NewLine);
            selectTxt += IFBy(bMngSectionCode, " ,MTSSLP.MNGSECTIONCODERF" + Environment.NewLine);

            //FROM
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            #region [売上月次集計データ＋得意先別売上目標設定マスタ抽出用サブクエリ]
            selectTxt += "  SELECT" + Environment.NewLine;
            //印刷タイプによって抽出項目を動的生成する
            switch (paramWork.PrintType)
            {
                #region [印刷タイプ判別]

                case (int)PrintType.Month:
                    #region [当月]
                    selectTxt += "   MTSSLPM.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  ,MTSSLPM." + sTblName + Environment.NewLine;
                    selectTxt += IFBy(bMngSectionCode,
                                 "  ,MTSSLPM.MNGSECTIONCODERF" + Environment.NewLine);
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLPM");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "CUSTGTM");
                    selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPM");
                    #endregion
                    break;
                case (int)PrintType.Annual:
                    #region [当期]
                    selectTxt += "   MTSSLPA.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  ,MTSSLPA." + sTblName + Environment.NewLine;
                    selectTxt += IFBy(bMngSectionCode,
                                 "  ,MTSSLPA.MNGSECTIONCODERF" + Environment.NewLine);
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Annual, "MTSSLPA");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Annual, "CUSTGTA");
                    selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPA");
                    #endregion
                    break;
                case (int)PrintType.All:
                    #region [当月＆当期]
                    selectTxt += "   MTSSLPASUB.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  ,MTSSLPASUB." + sTblName + Environment.NewLine;
                    selectTxt += IFBy(bMngSectionCode,
                                 "  ,MTSSLPASUB.MNGSECTIONCODERF" + Environment.NewLine);
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLPM");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "CUSTGTM");
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

            string sSecNm = "ADDUPSECCODERF";

            #region [データ抽出メインQuery]

            //当月分を抽出するかどうか
            if (paramWork.PrintType != (int)PrintType.Annual)  //PrintType -> 0:当月 1:当期 2:当月＆当期
            {
                //当月分集計

                #region [売上月次集計データ]
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,MTSSLPSUB1." + sTblName + Environment.NewLine;
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
                selectTxt += "   FROM" + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;

                #region [地区別絞込み用サブクエリ]
                selectTxt += "    SELECT" + Environment.NewLine;
                selectTxt += "      MTSSLPSUB1_1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     ,MTSSLPSUB1_1.SALESMONEYRF" + Environment.NewLine;
                selectTxt += "     ,MTSSLPSUB1_1.SALESRETGOODSPRICERF" + Environment.NewLine;
                selectTxt += "     ,MTSSLPSUB1_1.DISCOUNTPRICERF" + Environment.NewLine;
                selectTxt += "     ,MTSSLPSUB1_1.GROSSPROFITRF" + Environment.NewLine;
                selectTxt += "     ,MTSSLPSUB1_1.RSLTTTLDIVCDRF" + Environment.NewLine;
                selectTxt += "     ,MTSSLPSUB1_1.EMPLOYEEDIVCDRF" + Environment.NewLine;
                selectTxt += "     ,MTSSLPSUB1_1.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += "     ,MTSSLPSUB1_1.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "     ,MTSSLPSUB1_1.CUSTOMERCODERF" + Environment.NewLine;
                //selectTxt += "     ,CUTMERSUB1_1." + sTblName + Environment.NewLine;
                selectTxt += "     ,(CASE WHEN  " + "CUTMERSUB1_1." + sTblName + " IS NULL THEN 0 ELSE " + "CUTMERSUB1_1." + sTblName + " END ) AS " + sTblName + Environment.NewLine;
                selectTxt += IFBy(bMngSectionCode,
                             "     ,CUTMERSUB1_1.MNGSECTIONCODERF" + Environment.NewLine);
                // 2011/07/29 >>>
                //selectTxt += "    FROM MTTLSALESSLIPRF AS MTSSLPSUB1_1" + Environment.NewLine;
                //selectTxt += "    LEFT JOIN CUSTOMERRF CUTMERSUB1_1" + Environment.NewLine;
                selectTxt += "    FROM MTTLSALESSLIPRF AS MTSSLPSUB1_1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "    LEFT JOIN CUSTOMERRF CUTMERSUB1_1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += "    ON  CUTMERSUB1_1.ENTERPRISECODERF=MTSSLPSUB1_1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    AND CUTMERSUB1_1.CUSTOMERCODERF=MTSSLPSUB1_1.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.Month, "MTSSLPSUB1_1", sSecNm);
                selectTxt += MakeWhereString_Cust(ref sqlCommand, paramWork, "CUTMERSUB1_1");
                #endregion  //[地区別絞込み用サブクエリ]

                selectTxt += "   ) AS MTSSLPSUB1" + Environment.NewLine;
                selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.Month, "MTSSLPSUB1", sSecNm);
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPSUB1");
                selectTxt += "    ,MTSSLPSUB1." + sTblName + Environment.NewLine;
                selectTxt += IFBy(bMngSectionCode,
                             "    ,MTSSLPSUB1.MNGSECTIONCODERF" + Environment.NewLine);
                selectTxt += "  ) AS MTSSLPM" + Environment.NewLine;
                #endregion  //[売上月次集計データ]

                #region [得意先別売上目標設定マスタ]
                selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     CUSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bSectionCode,
                             "    ,CUSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bMngSectionCode,
                             "    ,CUSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bCustomerCode,
                             "    ,CUSTGTSUB1.CUSTOMERCODERF" + Environment.NewLine);
                // --- Add duzg　2013/07/26  for  Redmine#38722 ------->>>>>>>>>>>>>>>>>>>>>
                if (paramWork.OutType == 1)
                {
                    // 何もない
                }
                else
                {
                    selectTxt += "    ,CUSTGTSUB1." + sTblName + Environment.NewLine;
                }
                // --- Add duzg　2013/07/26  for  Redmine#38722 -------<<<<<<<<<<<<<<<<<<<<<
                //selectTxt += "    ,CUSTGTSUB1." + sTblName + Environment.NewLine;// Del duzg　2013/07/26  for  Redmine#38722
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
                selectTxt += IFBy(bSectionCode,
                             "    ,CUSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bMngSectionCode,
                             "    ,CUSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bCustomerCode,
                             "    ,CUSTGTSUB1.CUSTOMERCODERF" + Environment.NewLine);
                // --- Add duzg　2013/07/26  for  Redmine#38722 ------->>>>>>>>>>>>>>>>>>>>>
                // 地区 業種 出順：得意先
                if (paramWork.OutType == 1)
                {
                    // 何もない
                }
                else
                {
                    selectTxt += "    ,CUSTGTSUB1." + sTblName + Environment.NewLine;
                }
                // --- Add duzg　2013/07/26  for  Redmine#38722 -------<<<<<<<<<<<<<<<<<<<<
                //selectTxt += "    ,CUSTGTSUB1." + sTblName + Environment.NewLine;// Del duzg　2013/07/26  for  Redmine#38722
                selectTxt += "  ) AS CUSTGTM" + Environment.NewLine;
                selectTxt += "  ON  CUSTGTM.ENTERPRISECODERF=MTSSLPM.ENTERPRISECODERF" + Environment.NewLine;
                // --- Add duzg　2013/07/26  for  Redmine#38722 ------->>>>>>>>>>>>>>>>>>>>>
                // 地区 業種 出順：得意先
                if (paramWork.OutType == 1)
                {
                    // 何もない
                }
                else
                {
                    selectTxt += "  AND CUSTGTM." + sTblName + "=MTSSLPM." + sTblName + Environment.NewLine;
                }
                // --- Add duzg　2013/07/26  for  Redmine#38722 -------<<<<<<<<<<<<<<<<<<<<<<
                //selectTxt += "  AND CUSTGTM." + sTblName + "=MTSSLPM." + sTblName + Environment.NewLine;// Del duzg　2013/07/26  for  Redmine#38722
                selectTxt += IFBy(bSectionCode,
                             "  AND CUSTGTM.SECTIONCODERF=MTSSLPM.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bMngSectionCode,
                             "  AND CUSTGTM.SECTIONCODERF=MTSSLPM.MNGSECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bCustomerCode,
                             "  AND CUSTGTM.CUSTOMERCODERF=MTSSLPM.CUSTOMERCODERF" + Environment.NewLine);
                #endregion  //[得意先別売上目標設定マスタ]
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
                    selectTxt += "    ,MTSSLPA." + sTblName + Environment.NewLine;
                    selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPA");
                    selectTxt += "    ,MTSSLPA.ANNUALSALESMONEY" + Environment.NewLine;
                    selectTxt += "    ,MTSSLPA.ANNUALSALESRETGOODSPRICE" + Environment.NewLine;
                    selectTxt += "    ,MTSSLPA.ANNUALDISCOUNTPRICE" + Environment.NewLine;
                    selectTxt += "    ,MTSSLPA.ANNUALGROSSPROFIT" + Environment.NewLine;
                    selectTxt += "    ,CUSTGTA.ANNUALSALESTARGETMONEY" + Environment.NewLine;
                    selectTxt += "    ,CUSTGTA.ANNUALSALESTARGETPROFIT" + Environment.NewLine;
                    selectTxt += IFBy(bMngSectionCode,
                                 "     ,MTSSLPA.MNGSECTIONCODERF" + Environment.NewLine);
                    selectTxt += "   FROM" + Environment.NewLine;
                    selectTxt += "   (" + Environment.NewLine;
                    #endregion  //[当月＆当期の場合の当期抽出条件]
                }
                selectTxt += "    SELECT" + Environment.NewLine;
                selectTxt += "      MTSSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     ,MTSSLPSUB2." + sTblName + Environment.NewLine;
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
                selectTxt += "    FROM" + Environment.NewLine;
                selectTxt += "    (" + Environment.NewLine;

                #region [地区別絞込み様サブクエリ]
                selectTxt += "     SELECT" + Environment.NewLine;
                selectTxt += "       MTSSLPSUB2_1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "      ,MTSSLPSUB2_1.SALESMONEYRF" + Environment.NewLine;
                selectTxt += "      ,MTSSLPSUB2_1.SALESRETGOODSPRICERF" + Environment.NewLine;
                selectTxt += "      ,MTSSLPSUB2_1.DISCOUNTPRICERF" + Environment.NewLine;
                selectTxt += "      ,MTSSLPSUB2_1.GROSSPROFITRF" + Environment.NewLine;
                selectTxt += "      ,MTSSLPSUB2_1.RSLTTTLDIVCDRF" + Environment.NewLine;
                selectTxt += "      ,MTSSLPSUB2_1.EMPLOYEEDIVCDRF" + Environment.NewLine;
                selectTxt += "      ,MTSSLPSUB2_1.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += "      ,MTSSLPSUB2_1.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "      ,MTSSLPSUB2_1.CUSTOMERCODERF" + Environment.NewLine;
                //selectTxt += "      ,CUTMERSUB2_1." + sTblName + Environment.NewLine;
                selectTxt += "      ,(CASE WHEN CUTMERSUB2_1." + sTblName + " IS NULL THEN 0 ELSE CUTMERSUB2_1." + sTblName + " END ) AS  " + sTblName + Environment.NewLine;
                selectTxt += IFBy(bMngSectionCode,
                             "      ,CUTMERSUB2_1.MNGSECTIONCODERF" + Environment.NewLine);
                // 2011/07/29 >>>
                //selectTxt += "     FROM MTTLSALESSLIPRF AS MTSSLPSUB2_1" + Environment.NewLine;
                //selectTxt += "     LEFT JOIN CUSTOMERRF CUTMERSUB2_1" + Environment.NewLine;
                selectTxt += "     FROM MTTLSALESSLIPRF AS MTSSLPSUB2_1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "     LEFT JOIN CUSTOMERRF CUTMERSUB2_1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += "     ON  CUTMERSUB2_1.ENTERPRISECODERF=MTSSLPSUB2_1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     AND CUTMERSUB2_1.CUSTOMERCODERF=MTSSLPSUB2_1.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.Annual, "MTSSLPSUB2_1", sSecNm);
                selectTxt += MakeWhereString_Cust(ref sqlCommand, paramWork, "CUTMERSUB2_1");
                #endregion  //[地区別絞込み様サブクエリ]

                selectTxt += "    ) AS MTSSLPSUB2" + Environment.NewLine;
                selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.Annual, "MTSSLPSUB2", sSecNm);
                selectTxt += "    GROUP BY" + Environment.NewLine;
                selectTxt += "      MTSSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "MTSSLPSUB2");
                selectTxt += "     ,MTSSLPSUB2." + sTblName + Environment.NewLine;
                selectTxt += IFBy(bMngSectionCode,
                             "     ,MTSSLPSUB2.MNGSECTIONCODERF" + Environment.NewLine);
                selectTxt += "   ) AS MTSSLPA" + Environment.NewLine;
                #endregion  //[売上月次集計データ]

                #region [得意先別売上目標設定マスタ]
                selectTxt += "   LEFT JOIN (" + Environment.NewLine;
                selectTxt += "    SELECT" + Environment.NewLine;
                selectTxt += "      CUSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bSectionCode,
                             "    ,CUSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bMngSectionCode,
                             "    ,CUSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bCustomerCode,
                             "     ,CUSTGTSUB2.CUSTOMERCODERF" + Environment.NewLine);
                // --- Add duzg　2013/07/26  for  Redmine#38722 ------->>>>>>>>>>>>>>>>>>>>>
                if (paramWork.OutType == 1)
                {
                    // 何もない
                }
                else
                {
                    selectTxt += "     ,CUSTGTSUB2." + sTblName + Environment.NewLine;
                }
                // --- Add duzg　2013/07/26  for  Redmine#38722 -------<<<<<<<<<<<<<<<<<<<<<
                //selectTxt += "     ,CUSTGTSUB2." + sTblName + Environment.NewLine;// Del duzg　2013/07/26  for  Redmine#38722
                selectTxt += "     ,SUM(CUSTGTSUB2.SALESTARGETMONEYRF)" + Environment.NewLine;
                selectTxt += "       AS ANNUALSALESTARGETMONEY" + Environment.NewLine;
                selectTxt += "     ,SUM(CUSTGTSUB2.SALESTARGETPROFITRF)" + Environment.NewLine;
                selectTxt += "       AS ANNUALSALESTARGETPROFIT" + Environment.NewLine;
                // 2011/07/29 >>>
                //selectTxt += "    FROM CUSTSALESTARGETRF AS CUSTGTSUB2" + Environment.NewLine;
                selectTxt += "    FROM CUSTSALESTARGETRF AS CUSTGTSUB2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += MakeWhereString_CustTgt(ref sqlCommand, paramWork, (int)PrintType.Annual, "CUSTGTSUB2");
                selectTxt += "    GROUP BY" + Environment.NewLine;
                selectTxt += "      CUSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bSectionCode,
                             "    ,CUSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bMngSectionCode,
                             "    ,CUSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bCustomerCode,
                             "     ,CUSTGTSUB2.CUSTOMERCODERF" + Environment.NewLine);
                // --- Add duzg　2013/07/26  for  Redmine#38722 ------->>>>>>>>>>>>>>>>>>>>>
                if (paramWork.OutType == 1)
                {
                    // 何もない
                }
                else
                {
                    selectTxt += "     ,CUSTGTSUB2." + sTblName + Environment.NewLine;
                }
                // --- Add duzg　2013/07/26  for  Redmine#38722 -------<<<<<<<<<<<<<<<<<<<<<
                //selectTxt += "     ,CUSTGTSUB2." + sTblName + Environment.NewLine;// Del duzg　2013/07/26  for  Redmine#38722
                selectTxt += "   ) AS CUSTGTA" + Environment.NewLine;
                selectTxt += "   ON  CUSTGTA.ENTERPRISECODERF=MTSSLPA.ENTERPRISECODERF" + Environment.NewLine;
                // --- Add duzg　2013/07/26  for  Redmine#38722 ------->>>>>>>>>>>>>>>>>>>>>
                if (paramWork.OutType == 1)
                {
                    // 何もない
                }
                else
                {
                    selectTxt += "   AND CUSTGTA." + sTblName + "=MTSSLPA." + sTblName + Environment.NewLine;
                }
                // --- Add duzg　2013/07/26  for  Redmine#38722 -------<<<<<<<<<<<<<<<<<<<<<
                //selectTxt += "   AND CUSTGTA." + sTblName + "=MTSSLPA." + sTblName + Environment.NewLine;// Del duzg　2013/07/26  for  Redmine#38722
                selectTxt += IFBy(bSectionCode,
                             "   AND CUSTGTA.SECTIONCODERF=MTSSLPA.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bMngSectionCode,
                             "   AND CUSTGTA.SECTIONCODERF=MTSSLPA.MNGSECTIONCODERF" + Environment.NewLine);
                selectTxt += IFBy(bCustomerCode,
                             "   AND CUSTGTA.CUSTOMERCODERF=MTSSLPA.CUSTOMERCODERF" + Environment.NewLine);
                #endregion  //[得意先別売上目標設定マスタ]
            }

            #endregion  //[データ抽出メインQuery]

            #region [当月＆当期の場合の当月分と当期分の結合条件]
            if (paramWork.PrintType == (int)PrintType.All)  //PrintType -> 0:当月 1:当期 2:当月＆当期
            {
                selectTxt += "  ) AS MTSSLPASUB" + Environment.NewLine;
                selectTxt += "  ON  MTSSLPASUB.ENTERPRISECODERF=MTSSLPM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND MTSSLPASUB." + sTblName + "=MTSSLPM." + sTblName + Environment.NewLine;
                selectTxt += IFBy(paramWork.OutType == 1,
                             "  AND MTSSLPASUB.CUSTOMERCODERF=MTSSLPM.CUSTOMERCODERF" + Environment.NewLine);
                if (paramWork.TtlType == 1)
                {
                    if (bMngSectionCode)
                        selectTxt += "  AND MTSSLPASUB.MNGSECTIONCODERF=MTSSLPM.MNGSECTIONCODERF" + Environment.NewLine;
                    else
                        selectTxt += "  AND MTSSLPASUB.ADDUPSECCODERF=MTSSLPM.ADDUPSECCODERF" + Environment.NewLine;
                }
            }
            #endregion  //[当月＆当期の場合の当月分と当期分の結合条件]

            #endregion  //[売上月次集計データ＋得意先別売上目標設定マスタ抽出用サブクエリ]

            selectTxt += " ) AS MTSSLP" + Environment.NewLine;

            #region [JOIN]
            //ユーザーガイド区分判別
            int iUserGuideDivCd = 0;
            if (paramWork.TotalType == (int)TotalType.Area)
                iUserGuideDivCd = (int)UserGuideDivCd.SalesAreaCode;
            if (paramWork.TotalType == (int)TotalType.BzType)
                iUserGuideDivCd = (int)UserGuideDivCd.BusinessTypeCode;
            //ユーザーガイドマスタ(ボディ)
            // 2011/07/29 >>>
            //selectTxt += " LEFT JOIN USERGDBDURF USRGBU" + Environment.NewLine;
            selectTxt += " LEFT JOIN USERGDBDURF USRGBU WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<
            selectTxt += " ON  USRGBU.ENTERPRISECODERF=MTSSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USRGBU.USERGUIDEDIVCDRF=" + iUserGuideDivCd.ToString();
            selectTxt += " AND USRGBU.GUIDECODERF=MTSSLP." + sTblName;

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

            #endregion

            return selectTxt;
        }
        #endregion  //[地区別用・業種別用 Select文生成処理]

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
        /// <br>UpdateNote : 2013/07/11 liusy</br>
        /// <br>管理番号   : 10801804-00  redmine #38169</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork, Int32 iPrintType, string sTblNm, string secNm)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //実績集計区分
            retstring += " AND " + sTblNm + ".RSLTTTLDIVCDRF=0" + Environment.NewLine;

            //従業員区分
            retstring += " AND " + sTblNm + ".EMPLOYEEDIVCDRF=@" + sTblNm + "EMPLOYEEDIVCD" + Environment.NewLine;
            SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@" + sTblNm + "EMPLOYEEDIVCD", SqlDbType.Int);
            paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)EmployeeDivCd.Agent);


            if (!(paramWork.TotalType == (int)TotalType.Customer && paramWork.OutType == 4))  //0:得意先別  //ADD BY LIUSY #38169 2013/07/11
            {
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
                        //retstring += " AND " + sTblNm + ".ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                        retstring += " AND " + sTblNm + "." + secNm + " IN (" + sectionCodestr + ") ";

                    }
                    retstring += Environment.NewLine;
                }
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

            if (!(paramWork.TotalType == (int)TotalType.Customer && paramWork.OutType == 4))  //0:得意先別  //ADD BY LIUSY #38169 2013/07/11
            {
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
            }
            #endregion

            return retstring;
        }
        #endregion  //[MTtlSalesSlip用 Where句生成処理]

        #region [Customer用 Where句生成処理]
        /// <summary>
        /// 得意先マスタ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件</param>
        /// <param name="sTblNm">テーブル名</param>
        /// <returns>得意先マスタ用WHERE句</returns>
        /// <br>Note       : 得意先マスタ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        /// <br>UpdateNote : 2013/07/11 liusy</br>
        /// <br>管理番号   : 10801804-00  redmine #38169</br>
        private string MakeWhereString_Cust(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork, string sTblNm)
        {
            #region WHERE文作成
            string retstring = "";

            ////企業コード
            //retstring += " AND " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            //SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            //paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            ////得意先コード
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

            //検索コード
            switch (paramWork.TotalType)
            {
                case (int)TotalType.Customer:
                    //なし
                    //ADD BY LIUSY #38169 2013/07/11 ---->>>>
                    if (paramWork.OutType == 4) //0:得意先別
                    {
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

                                retstring += " AND " + sTblNm + ".CLAIMSECTIONCODERF IN (" + sectionCodestr + ") ";

                            }
                            retstring += Environment.NewLine;
                        }

                        //得意先コード
                        if (paramWork.CustomerCodeSt != 0)
                        {
                            retstring += " AND " + sTblNm + ".CLAIMCODERF>=@" + sTblNm + "CUSTOMERCODEST" + Environment.NewLine;
                            SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEST", SqlDbType.Int);
                            paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeSt);
                        }
                        if (paramWork.CustomerCodeEd != 99999999)
                        {
                            retstring += " AND " + sTblNm + ".CLAIMCODERF<=@" + sTblNm + "CUSTOMERCODEED" + Environment.NewLine;
                            SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEED", SqlDbType.Int);
                            paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeEd);
                        }
                    }
                    //ADD BY LIUSY #38169 2013/07/11 ----<<<<
                    break;
                case (int)TotalType.Area:
                    #region [地区別]
                    //地区コード
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
        #endregion  //[Customer用 Where句生成処理]

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
        /// <br>UpdateNote : 2013/07/26 duzg</br>
        /// <br>管理番号   : 10801804-00  redmine #38722のNo.2</br>
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
                    // --- Add duzg　2013/07/26  for  Redmine#38722 ------->>>>>>>>>>>>>>>>>>>>>
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
                            retstring += " AND " + sTblNm + ".SECTIONCODERF IN (" + sectionCodestr + ") ";

                        }
                        retstring += Environment.NewLine;
                    }

                    // 地区 出順：得意先
                    if ((paramWork.TotalType == 4
                        || paramWork.TotalType == 5) && paramWork.OutType == 1)
                    {
                        retstring += " AND " + sTblNm + ".TARGETCONTRASTCDRF=30" + Environment.NewLine;
                    }
                    else
                    {
                        //地区コード
                        retstring += " AND " + sTblNm + ".TARGETCONTRASTCDRF=32" + Environment.NewLine;
                        if (paramWork.SrchCodeSt != "" && paramWork.SrchCodeSt != null)
                        {
                            Int32 iSalesAreaCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //パラメータのキャスト
                            retstring += " AND " + sTblNm + ".SALESAREACODERF>=@" + sTblNm + "SALESAREACODEST" + Environment.NewLine;
                            SqlParameter paraSalesAreaCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESAREACODEST", SqlDbType.Int);
                            paraSalesAreaCodeSt.Value = SqlDataMediator.SqlSetInt32(iSalesAreaCodeSt);
                        }
                        if ((paramWork.SrchCodeEd != "") && (paramWork.SrchCodeEd != null))
                        {
                            Int32 iSalesAreaCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //パラメータのキャスト
                            retstring += " AND " + sTblNm + ".SALESAREACODERF<=@" + sTblNm + "SALESAREACODEED" + Environment.NewLine;
                            SqlParameter paraSalesAreaCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESAREACODEED", SqlDbType.Int);
                            paraSalesAreaCodeEd.Value = SqlDataMediator.SqlSetInt32(iSalesAreaCodeEd);
                        }
                    }
                    // --- Add duzg　2013/07/26  for  Redmine#38722 -------<<<<<<<<<<<<<<<<<<<<<<<

                    // --- Del duzg　2013/07/26  for  Redmine#38722 ------->>>>>>>>>>>>>>>>>>>>>
                    #region [地区別]
                    ////地区コード
                    //// ADD 2008.12.08 >>>
                    //retstring += " AND " + sTblNm + ".TARGETCONTRASTCDRF=32" + Environment.NewLine;
                    //// ADD 2008.12.08 <<<
                    ////if (paramWork.SrchCodeSt != "") // DEL 2008.12.08
                    //if (paramWork.SrchCodeSt != "" && paramWork.SrchCodeSt != null) // ADD 2008.12.08
                    //{
                    //    Int32 iSalesAreaCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //パラメータのキャスト
                    //    retstring += " AND " + sTblNm + ".SALESAREACODERF>=@" + sTblNm + "SALESAREACODEST" + Environment.NewLine;
                    //    SqlParameter paraSalesAreaCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESAREACODEST", SqlDbType.Int);
                    //    paraSalesAreaCodeSt.Value = SqlDataMediator.SqlSetInt32(iSalesAreaCodeSt);
                    //}
                    ////if ((paramWork.SrchCodeEd != "")) // DEL 2008.12.08
                    //if ((paramWork.SrchCodeEd != "") && (paramWork.SrchCodeEd != null)) // ADD 2008.12.08
                    //{
                    //    Int32 iSalesAreaCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //パラメータのキャスト
                    //    retstring += " AND " + sTblNm + ".SALESAREACODERF<=@" + sTblNm + "SALESAREACODEED" + Environment.NewLine;
                    //    SqlParameter paraSalesAreaCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESAREACODEED", SqlDbType.Int);
                    //    paraSalesAreaCodeEd.Value = SqlDataMediator.SqlSetInt32(iSalesAreaCodeEd);
                    //}
                    #endregion
                    // --- Del duzg　2013/07/26  for  Redmine#38722 -------<<<<<<<<<<<<<<<<<<<<<
                    break;
                case (int)TotalType.BzType:
                    // --- Add duzg　2013/07/26  for  Redmine#38722 ------->>>>>>>>>>>>>>>>>>>>>
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
                            retstring += " AND " + sTblNm + ".SECTIONCODERF IN (" + sectionCodestr + ") ";

                        }
                        retstring += Environment.NewLine;
                    }

                    // 業種 出順：得意先
                    if ((paramWork.TotalType == 4
                        || paramWork.TotalType == 5) && paramWork.OutType == 1)
                    {
                        retstring += " AND " + sTblNm + ".TARGETCONTRASTCDRF=30" + Environment.NewLine;
                    }
                    else
                    {
                        //業種コード
                        retstring += " AND " + sTblNm + ".TARGETCONTRASTCDRF=31" + Environment.NewLine;

                        if (paramWork.SrchCodeSt != "" && paramWork.SrchCodeSt != null)
                        {
                            Int32 iBusinessTypeCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //パラメータのキャスト
                            retstring += " AND " + sTblNm + ".BUSINESSTYPECODERF>=@" + sTblNm + "BUSINESSTYPECODEST" + Environment.NewLine;
                            SqlParameter paraBusinessTypeCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "BUSINESSTYPECODEST", SqlDbType.Int);
                            paraBusinessTypeCodeSt.Value = SqlDataMediator.SqlSetInt32(iBusinessTypeCodeSt);
                        }

                        if ((paramWork.SrchCodeEd != "") && (paramWork.SrchCodeEd != null))
                        {
                            Int32 iBusinessTypeCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //パラメータのキャスト
                            retstring += " AND " + sTblNm + ".BUSINESSTYPECODERF<=@" + sTblNm + "BUSINESSTYPECODEED" + Environment.NewLine;
                            SqlParameter paraBusinessTypeCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "BUSINESSTYPECODEED", SqlDbType.Int);
                            paraBusinessTypeCodeEd.Value = SqlDataMediator.SqlSetInt32(iBusinessTypeCodeEd);
                        }
                    }
                    // --- Add duzg　2013/07/26  for  Redmine#38722 -------<<<<<<<<<<<<<<<<<<<<<
                    // --- Del duzg　2013/07/26  for  Redmine#38722 ------->>>>>>>>>>>>>>>>>>>>>
                    #region [業種別]
                    ////業種コード
                    //// ADD 2008.12.08 >>>
                    //retstring += " AND " + sTblNm + ".TARGETCONTRASTCDRF=31" + Environment.NewLine;
                    //// ADD 2008.12.08 <<<
                    ////if (paramWork.SrchCodeSt != "") // DEL 2008.12.08
                    //if (paramWork.SrchCodeSt != "" && paramWork.SrchCodeSt != null) // ADD 2008.12.08
                    //{
                    //    Int32 iBusinessTypeCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //パラメータのキャスト
                    //    retstring += " AND " + sTblNm + ".BUSINESSTYPECODERF>=@" + sTblNm + "BUSINESSTYPECODEST" + Environment.NewLine;
                    //    SqlParameter paraBusinessTypeCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "BUSINESSTYPECODEST", SqlDbType.Int);
                    //    paraBusinessTypeCodeSt.Value = SqlDataMediator.SqlSetInt32(iBusinessTypeCodeSt);
                    //}
                    ////if ((paramWork.SrchCodeEd != "")) // DEL 2008.12.08
                    //if ((paramWork.SrchCodeEd != "") && (paramWork.SrchCodeEd != null)) // ADD 2008.12.08
                    //{
                    //    Int32 iBusinessTypeCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //パラメータのキャスト
                    //    retstring += " AND " + sTblNm + ".BUSINESSTYPECODERF<=@" + sTblNm + "BUSINESSTYPECODEED" + Environment.NewLine;
                    //    SqlParameter paraBusinessTypeCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "BUSINESSTYPECODEED", SqlDbType.Int);
                    //    paraBusinessTypeCodeEd.Value = SqlDataMediator.SqlSetInt32(iBusinessTypeCodeEd);
                    //}
                    #endregion
                    // --- Del duzg　2013/07/26  for  Redmine#38722 -------<<<<<<<<<<<<<<<<<<<<<<
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

            switch (paramWork.TotalType)
            {
                #region [集計単位判別]
                case (int)TotalType.Customer:
                    #region [得意先別]
                    if (paramWork.TtlType == 1)
                    {
                        if (paramWork.OutType == 3)
                            resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                        else
                            resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        resultWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    }

                    if ((paramWork.OutType == 0) ||
                        (paramWork.OutType == 2) ||
                        (paramWork.OutType == 3) ||
                        (paramWork.OutType == 4))
                    {
                        resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    }
                    #endregion
                    break;
                case (int)TotalType.Area:
                    #region [地区別]
                    Int32 iSalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                    resultWork.Code = iSalesAreaCode.ToString();
                    resultWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));

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
                    #endregion
                    break;
                case (int)TotalType.BzType:
                    #region [業種別]
                    Int32 iBusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                    resultWork.Code = iBusinessTypeCode.ToString();
                    resultWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));

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
                    #endregion
                    break;
                default:
                    break;
                #endregion
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
