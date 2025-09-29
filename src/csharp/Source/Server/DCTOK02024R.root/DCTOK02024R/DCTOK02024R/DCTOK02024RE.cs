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
    class SalesSlipReport_Gcd : SalesSlipReportBase, ISalesSlipReport
    {
        #region [判別用フラグ宣言]
        private bool bSectionCode = false;  //拠点コード検索フラグ
        #endregion  //[判別用フラグ宣言]

        #region [GcdSalesTarget用 Select文]
        /// <summary>
        /// 商品別売上目標設定マスタ用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条</param>
        /// <returns>商品別売上目標設定マスタ用SELECT文</returns>
        /// <br>Note       : 商品別売上目標設定マスタ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, paramWork);
        }
        #endregion  //[GcdSalesTarget用 Select文]

        #region [GcdSalesTarget用 Select文生成処理]
        /// <summary>
        /// 商品別売上目標設定マスタ用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条</param>
        /// <returns>商品別売上目標設定マスタ用SELECT文</returns>
        /// <br>Note       : 商品別売上目標設定マスタ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork)
        {
            #region [判別用フラグ]
            //拠点コード検索フラグ
            if (paramWork.TtlType == 1)
            {
                bSectionCode = true;
            }
            #endregion

            // 対象テーブル
            // SALESHISTORYRF   SALHIS 売上履歴データ
            // SALESHISTDTLRF   SALHID 売上履歴明細データ
            // GCDSALESTARGETRF GCSTGT 商品別売上目標設定マスタ
            // USERGDBDURF      USRGBU ユーザーガイドマスタ(ボディ)
            // SECINFOSETRF     SCINST 拠点情報設定マスタ

            string selectTxt = "";

            #region [Select文作成]

            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  SALHIS.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " ,SALHIS.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += " ,SALHIS.TERMSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += " ,SALHIS.TERMSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += " ,SALHIS.TERMSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += " ,SALHIS.TERMSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += " ,SALHIS.TERMTOTALCOST" + Environment.NewLine;
            selectTxt += " ,SALHIS.TERMSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += " ,SALHIS.TERMSALESTARGETPROFIT" + Environment.NewLine;
            selectTxt += " ,SALHIS.MONTHSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += " ,SALHIS.MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += " ,SALHIS.MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += " ,SALHIS.MONTHSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += " ,SALHIS.MONTHTOTALCOST" + Environment.NewLine;
            selectTxt += " ,SALHIS.MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += " ,SALHIS.MONTHSALESTARGETPROFIT" + Environment.NewLine;
            selectTxt += " ,SALHIS.SALESCODERF" + Environment.NewLine;
            selectTxt += " ,USRGBU.GUIDENAMERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode, " ,SALHIS.SECTIONCODERF" + Environment.NewLine);
            selectTxt += IFBy(bSectionCode, " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);

            //FROM
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            #region [売上履歴明細データ＋商品別売上目標設定マスタ抽出用サブクエリ]
            selectTxt += "  SELECT" + Environment.NewLine;
            //selectTxt += "   SALHIST.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  ,SALHIST.SALESSLIPCDRF" + Environment.NewLine;
            //selectTxt += "  ,SALHIST.SALESCODERF" + Environment.NewLine;
            selectTxt += "   SALHISMSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.SALESCODERF" + Environment.NewLine;

            selectTxt += "  ,SALHIST.TERMSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMTOTALCOST" + Environment.NewLine;
            selectTxt += "  ,GCSTGTT.TERMSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "  ,GCSTGTT.TERMSALESTARGETPROFIT" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHTOTALCOST" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESTARGETPROFIT" + Environment.NewLine;
            //selectTxt += IFBy(bSectionCode,
            //             "  ,SALHIST.SECTIONCODERF" + Environment.NewLine);
            selectTxt += IFBy(bSectionCode,
                         "  ,SALHISMSUB.SECTIONCODERF" + Environment.NewLine);

            //FROM
            selectTxt += "  FROM" + Environment.NewLine;
            selectTxt += "  (" + Environment.NewLine;

            #region [データ抽出メインQuery]

            #region [期間分抽出Query]
            //売上履歴明細データ
            selectTxt += MakeSubQueryString(ref sqlCommand, paramWork, "SALHISSUB1", 0);
            selectTxt += "  ) AS SALHIST" + Environment.NewLine;

            //商品別売上目標設定マスタ
            selectTxt += "  LEFT JOIN (" + Environment.NewLine;
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     GCSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,GCSTGTSUB1.SALESCODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,GCSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "    ,SUM(GCSTGTSUB1.SALESTARGETMONEYRF)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "    ,SUM(GCSTGTSUB1.SALESTARGETPROFITRF)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESTARGETPROFIT" + Environment.NewLine;
            //selectTxt += "   FROM GCDSALESTARGETRF AS GCSTGTSUB1" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += "   FROM GCDSALESTARGETRF AS GCSTGTSUB1 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            selectTxt += MakeWhereString_Gcd(ref sqlCommand, paramWork, "GCSTGTSUB1",0);
            selectTxt += "   GROUP BY" + Environment.NewLine;
            selectTxt += "     GCSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,GCSTGTSUB1.SALESCODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,GCSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "  ) AS GCSTGTT" + Environment.NewLine;
            selectTxt += "  ON  GCSTGTT.ENTERPRISECODERF=SALHIST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND GCSTGTT.SALESCODERF=SALHIST.SALESCODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "  AND GCSTGTT.SECTIONCODERF=SALHIST.SECTIONCODERF" + Environment.NewLine);
            #endregion  //[期間分抽出Query]

            #region [当月分抽出Query]
            //売上履歴明細データ
            //selectTxt += "  LEFT JOIN (" + Environment.NewLine;
            selectTxt += "  RIGHT JOIN (" + Environment.NewLine;
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     SALHISM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISM.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += "    ,SALHISM.SALESCODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,SALHISM.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "    ,SALHISM.MONTHSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHTOTALCOST" + Environment.NewLine;
            selectTxt += "    ,GCSTGTM.MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "    ,GCSTGTM.MONTHSALESTARGETPROFIT" + Environment.NewLine;
            selectTxt += "   FROM" + Environment.NewLine;
            selectTxt += "   (" + Environment.NewLine;
            selectTxt += MakeSubQueryString(ref sqlCommand, paramWork, "SALHISSUB2", 1);
            selectTxt += "  ) AS SALHISM" + Environment.NewLine;

            //商品別売上目標設定マスタ
            selectTxt += "  LEFT JOIN (" + Environment.NewLine;
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     GCSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,GCSTGTSUB2.SALESCODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,GCSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "    ,SUM(GCSTGTSUB2.SALESTARGETMONEYRF)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "    ,SUM(GCSTGTSUB2.SALESTARGETPROFITRF)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESTARGETPROFIT" + Environment.NewLine;
            //selectTxt += "   FROM GCDSALESTARGETRF AS GCSTGTSUB2" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += "   FROM GCDSALESTARGETRF AS GCSTGTSUB2 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            selectTxt += MakeWhereString_Gcd(ref sqlCommand, paramWork, "GCSTGTSUB2",1);
            selectTxt += "   GROUP BY" + Environment.NewLine;
            selectTxt += "     GCSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,GCSTGTSUB2.SALESCODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,GCSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "  ) AS GCSTGTM" + Environment.NewLine;
            selectTxt += "  ON  GCSTGTM.ENTERPRISECODERF=SALHISM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND GCSTGTM.SALESCODERF=SALHISM.SALESCODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "  AND GCSTGTM.SECTIONCODERF=SALHISM.SECTIONCODERF" + Environment.NewLine);
            #endregion  //[当月分抽出Query]

            #endregion  //[データ抽出メインQuery]

            //期間分と当月分の結合条件
            selectTxt += "  ) AS SALHISMSUB" + Environment.NewLine;
            selectTxt += "  ON  SALHISMSUB.ENTERPRISECODERF=SALHIST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND SALHISMSUB.SALESSLIPCDRF=SALHIST.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += "  AND SALHISMSUB.SALESCODERF=SALHIST.SALESCODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "  AND SALHISMSUB.SECTIONCODERF=SALHIST.SECTIONCODERF" + Environment.NewLine);

            #endregion //[売上履歴明細データ＋商品別売上目標設定マスタ抽出用サブクエリ]

            selectTxt += " ) AS SALHIS" + Environment.NewLine;

            #region [JOIN]
            //ユーザーガイドマスタ(ボディ)
            int iSalesCode = (int)UserGuideDivCd.SalesCode;
            //selectTxt += " LEFT JOIN USERGDBDURF USRGBU" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += " LEFT JOIN USERGDBDURF USRGBU WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            selectTxt += " ON  USRGBU.ENTERPRISECODERF=SALHIS.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USRGBU.USERGUIDEDIVCDRF=" + iSalesCode.ToString();
            selectTxt += " AND USRGBU.GUIDECODERF=SALHIS.SALESCODERF";

            if (bSectionCode)
            {
                //拠点情報設定マスタ
                //selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
                selectTxt += " ON  SCINST.ENTERPRISECODERF=SALHIS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SCINST.SECTIONCODERF=SALHIS.SECTIONCODERF" + Environment.NewLine;
            }
            #endregion  //[JOIN]

            #endregion  //[Select文作成]

            return selectTxt;
        }
        #endregion  //[GcdSalesTarget用 Select文生成処理]

        #region [売上履歴明細データ用 SubQuery生成処理]
        /// <summary>
        /// 売上履歴明細データ用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条</param>
        /// <param name="sTblNm">テーブル略称</param>
        /// <param name="iType">0:期間 1:当月</param>
        /// <returns>売上履歴明細データ用SELECT文</returns>
        /// <br>Note       : 売上履歴明細データ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.06</br>
        private string MakeSubQueryString(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork, string sTblNm, int iType)
        {
            string sType = "";
            if (iType == 0)
                sType = "TERM";
            else
                sType = "MONTH";

            string retstring = "";

            #region [売上履歴明細データ抽出サブQuery]
            retstring += " SELECT" + Environment.NewLine;
            retstring += "   " + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".SALESSLIPCDRF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".SALESCODERF" + Environment.NewLine;
            retstring += IFBy(bSectionCode,
                         "  ," + sTblNm + ".SECTIONCODERF" + Environment.NewLine);
            retstring += "  ,COUNT(" + sTblNm + ".SALESSLIPNUMRF) AS " + sType + "SALESSLIPCOUNT" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".SALESTOTALTAXEXC + " + sTblNm + ".SALESDISTTLTAXEXCGYO ) AS " + sType + "SALESTOTALTAXEXC" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".SALESBACKTOTALTAXEXC + " + sTblNm + ".RETSALESDISTTLTAXEXCGYO ) AS " + sType + "SALESBACKTOTALTAXEXC" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".SALESDISTTLTAXEXC) AS " + sType + "SALESDISTTLTAXEXC" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".TOTALCOST) AS " + sType + "TOTALCOST" + Environment.NewLine;
            retstring += " FROM" + Environment.NewLine;
            retstring += " (" + Environment.NewLine;

            #region [売上履歴明細データ抽出]
            retstring += "  SELECT" + Environment.NewLine;
            retstring += "    " + sTblNm + "SUB.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "   ," + sTblNm + "SUB.SALESSLIPCDRF" + Environment.NewLine;
            retstring += "   ," + sTblNm + "SUB.CUSTOMERCODERF" + Environment.NewLine;
            //retstring += "   ,SALHID" + sTblNm + ".SECTIONCODERF" + Environment.NewLine;// DEL 2008.12.08
            retstring += "   ," + sTblNm + "SUB.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine; // ADD 2008.12.08
            retstring += "   ,SALHID" + sTblNm + ".SALESCODERF" + Environment.NewLine;
            retstring += "   ,SALHID" + sTblNm + ".SALESSLIPNUMRF" + Environment.NewLine;
            //retstring += "   ,(CASE WHEN " + sTblNm + "SUB.SALESSLIPCDRF=0 THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            //retstring += "   ,(CASE WHEN SALHID" + sTblNm + ".SALESSLIPCDDTLRF=0 THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            retstring += "   ,(CASE WHEN " + sTblNm + "SUB.SALESSLIPCDRF=0 AND SALHID" + sTblNm + ".SALESSLIPCDDTLRF!=2 THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            retstring += "    AS SALESTOTALTAXEXC" + Environment.NewLine;
            //retstring += "   ,(CASE WHEN " + sTblNm + "SUB.SALESSLIPCDRF=1 THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            //retstring += "   ,(CASE WHEN SALHID" + sTblNm + ".SALESSLIPCDDTLRF=1 THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            retstring += "   ,(CASE WHEN " + sTblNm + "SUB.SALESSLIPCDRF=1 AND SALHID" + sTblNm + ".SALESSLIPCDDTLRF!=2 THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            retstring += "    AS SALESBACKTOTALTAXEXC" + Environment.NewLine;
            //retstring += "   ,(CASE WHEN " + sTblNm + "SUB.SALESSLIPCDRF=2 THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            retstring += "   ,(CASE WHEN SALHID" + sTblNm + ".SALESSLIPCDDTLRF=2 AND SALHID" + sTblNm + ".SHIPMENTCNTRF != 0 THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            retstring += "    AS SALESDISTTLTAXEXC" + Environment.NewLine;

            retstring += "   ,(CASE WHEN " + sTblNm + "SUB.SALESSLIPCDRF=0 AND SALHID" + sTblNm + ".SALESSLIPCDDTLRF=2 AND SALHID" + sTblNm + ".SHIPMENTCNTRF = 0 " + Environment.NewLine;
            retstring += "     THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            retstring += "    AS SALESDISTTLTAXEXCGYO" + Environment.NewLine;
            retstring += "   ,(CASE WHEN " + sTblNm + "SUB.SALESSLIPCDRF=1 AND SALHID" + sTblNm + ".SALESSLIPCDDTLRF=2 AND SALHID" + sTblNm + ".SHIPMENTCNTRF = 0 " + Environment.NewLine;
            retstring += "     THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            retstring += "    AS RETSALESDISTTLTAXEXCGYO" + Environment.NewLine;

            // 修正 2009.02.06 >>>
            //retstring += "   ,SALHID" + sTblNm + ".SALESMONEYTAXEXCRF-SALHID" + sTblNm + ".COSTRF" + Environment.NewLine;
            retstring += "   ,SALHID" + sTblNm + ".COSTRF" + Environment.NewLine;
            // 修正 2009.02.06 <<<            
            retstring += "    AS TOTALCOST" + Environment.NewLine;
            //----- Del 2012/02/28 zhangyong for Redmine#28712----->>>>>>>
            //retstring += "  FROM SALESHISTORYRF AS " + sTblNm + "SUB" + Environment.NewLine;
            //retstring += "  LEFT JOIN SALESHISTDTLRF SALHID" + sTblNm + Environment.NewLine;
            //----- Del 2012/02/28 zhangyong for Redmine#28712-----<<<<<<<
            //----- Add 2012/02/28 zhangyong for Redmine#28712----->>>>>>>
            retstring += "  FROM SALESHISTORYRF AS " + sTblNm + "SUB WITH (READUNCOMMITTED)" + Environment.NewLine;
            retstring += "  LEFT JOIN SALESHISTDTLRF SALHID" + sTblNm + " WITH (READUNCOMMITTED)" + Environment.NewLine;
            //----- Add 2012/02/28 zhangyong for Redmine#28712-----<<<<<<<
            retstring += "  ON  SALHID" + sTblNm + ".ENTERPRISECODERF=" + sTblNm + "SUB.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "  AND SALHID" + sTblNm + ".ACPTANODRSTATUSRF=" + sTblNm + "SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
            retstring += "  AND SALHID" + sTblNm + ".SALESSLIPNUMRF=" + sTblNm + "SUB.SALESSLIPNUMRF" + Environment.NewLine;
            retstring += MakeWhereString(ref sqlCommand, paramWork, sTblNm, iType);
            #endregion  //[売上履歴明細データ抽出]

            retstring += " ) AS " + sTblNm + Environment.NewLine;

            #region [GROUP BY]
            retstring += " GROUP BY" + Environment.NewLine;
            retstring += "   " + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".SALESSLIPCDRF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".SALESCODERF" + Environment.NewLine;
            retstring += IFBy(bSectionCode,
                         "  ," + sTblNm + ".SECTIONCODERF" + Environment.NewLine);
            #endregion  //[GROUP BY]

            #endregion  //[売上履歴明細データ抽出サブQuery]

            return retstring;
        }
        #endregion  //[売上履歴明細データ用 SubQuery生成処理]

        #region [SalesHistory用 Where句生成処理]
        /// <summary>
        /// 売上履歴データ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件</param>
        /// <param name="sTblNm">テーブル略称</param>
        /// <param name="iType">0:期間 1:当月</param>
        /// <returns>売上履歴データ用WHERE句</returns>
        /// <br>Note       : 売上履歴データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.13</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork, string sTblNm, int iType)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " " + sTblNm + "SUB.ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //論理削除区分
            retstring += " AND " + sTblNm + "SUB.LOGICALDELETECODERF=0 " + Environment.NewLine;

            //受注ステータス
            retstring += " AND " + sTblNm + "SUB.ACPTANODRSTATUSRF=30" + Environment.NewLine;

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
                    //retstring += " AND " + sTblNm + "SUB.SECTIONCODERF IN (" + sectionCodestr + ") "; // DEL 2008.12.08
                    retstring += " AND " + sTblNm + "SUB.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";// ADD 2008.12.08
                }
                retstring += Environment.NewLine;
            }

            //対象日付
            if (iType == 0)
            {
                //開始対象年月日(期間)
                // -- UPD 2010/05/10 ------------------------------------------------->>>
                //retstring += " AND " + sTblNm + "SUB.SALESDATERF>=@" + sTblNm + "SALESDATEST" + Environment.NewLine;
                retstring += " AND " + sTblNm + "SUB.SALESDATERF>=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.SalesDateSt).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------------------<<<
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESDATEST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.SalesDateSt);
                
                //終了対象年月日(期間)
                // -- UPD 2010/05/10 ------------------------------------------------->>>
                //retstring += " AND " + sTblNm + "SUB.SALESDATERF<=@" + sTblNm + "SALESDATEED" + Environment.NewLine;
                retstring += " AND " + sTblNm + "SUB.SALESDATERF<=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.SalesDateEd).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------------------<<<
                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESDATEED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.SalesDateEd);

            }
            else
            {
                // -- UPD 2010/05/10 ------------------------------------------------->>>
                //開始対象年月日(当月)
                //retstring += " AND " + sTblNm + "SUB.SALESDATERF>=@MO" + sTblNm + "SALESDATEST" + Environment.NewLine;
                retstring += " AND " + sTblNm + "SUB.SALESDATERF>=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.MonthReportDateSt).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------------------<<<
                SqlParameter paraMOSalesDateSt = sqlCommand.Parameters.Add("@MO" + sTblNm + "SALESDATEST", SqlDbType.Int);
                paraMOSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.MonthReportDateSt);

                //終了対象年月日(当月)
                // -- UPD 2010/05/10 ------------------------------------------------->>>
                //retstring += " AND " + sTblNm + "SUB.SALESDATERF<=@MO" + sTblNm + "SALESDATEED" + Environment.NewLine;
                retstring += " AND " + sTblNm + "SUB.SALESDATERF<=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.MonthReportDateEd).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------------------<<<
                SqlParameter paraMOSalesDateEd = sqlCommand.Parameters.Add("@MO" + sTblNm + "SALESDATEED", SqlDbType.Int);
                paraMOSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.MonthReportDateEd);

            }

            //得意先コード
            if (paramWork.CustomerCodeSt != 0)
            {
                retstring += " AND " + sTblNm + "SUB.CUSTOMERCODERF>=@" + sTblNm + "CUSTOMERCODEST" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeSt);
            }
            if (paramWork.CustomerCodeEd != 99999999)
            {
                retstring += " AND " + sTblNm + "SUB.CUSTOMERCODERF<=@" + sTblNm + "CUSTOMERCODEED" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeEd);
            }

            //販売区分コード
            if (paramWork.SrchCodeSt != "")
            {
                Int32 iSalesCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //パラメータのキャスト
                retstring += " AND SALHID" + sTblNm + ".SALESCODERF>=@" + sTblNm + "SALESCODEST" + Environment.NewLine;
                SqlParameter paraSrchCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESCODEST", SqlDbType.Int);
                paraSrchCodeSt.Value = SqlDataMediator.SqlSetInt32(iSalesCodeSt);
            }
            if ((paramWork.SrchCodeEd != ""))
            {
                Int32 iSalesCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //パラメータのキャスト
                retstring += " AND SALHID" + sTblNm + ".SALESCODERF<=@" + sTblNm + "SALESCODEED" + Environment.NewLine;
                SqlParameter paraSrchCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESCODEED", SqlDbType.Int);
                paraSrchCodeEd.Value = SqlDataMediator.SqlSetInt32(iSalesCodeEd);
            }
            #endregion

            return retstring;
        }
        #endregion  //[SalesHistory用 Where句生成処理]

        #region [GcdSalesTarget用 Where句生成処理]
        /// <summary>
        /// 商品別売上目標設定マスタ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件</param>
        /// <returns>商品別売上目標設定マスタ用WHERE句</returns>
        /// <br>Note       : 商品別売上目標設定マスタ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.13</br>
        /// <br>UpdateNote : 2012/05/22 李亜博 </br>
        /// <br>管理番号   : 10801804-00 06/27配信分</br>
        /// <br>             Redmine#29898 売上日報月報 進捗率算出時に営業日を参照していないパターンが存在する</br> 
        private string MakeWhereString_Gcd(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork, string sTblNm, Int32 iPrintType)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //販売区分コード
            if (paramWork.SrchCodeSt != "")
            {
                Int32 iSalesCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //パラメータのキャスト
                retstring += " AND " + sTblNm + ".SALESCODERF>=@" + sTblNm + "SALESCODEST" + Environment.NewLine;
                SqlParameter paraSrchCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESCODEST", SqlDbType.Int);
                paraSrchCodeSt.Value = SqlDataMediator.SqlSetInt32(iSalesCodeSt);
            }
            if ((paramWork.SrchCodeEd != ""))
            {
                Int32 iSalesCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //パラメータのキャスト
                retstring += " AND " + sTblNm + ".SALESCODERF<=@" + sTblNm + "SALESCODEED" + Environment.NewLine;
                SqlParameter paraSrchCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESCODEED", SqlDbType.Int);
                paraSrchCodeEd.Value = SqlDataMediator.SqlSetInt32(iSalesCodeEd);
            }
            // --------------- ADD START 2012/05/22 Redmine#29898 李亜博-------->>>>
            if (paramWork.TtlType == 0)
            {
                //集計方法：全社
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
            // --------------- ADD END 2012/05/22 Redmine#29898 李亜博--------<<<<
            // ADD 2008.12.26 >>>
            if (iPrintType == 0) // 対象期間
            {
                retstring += " AND " + sTblNm + ".TARGETDIVIDECODERF>=@" + sTblNm + "TARGETDIVIDECODEST" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "TARGETDIVIDECODEST", SqlDbType.Int);
                // 修正 2009.01.16 >>>
                //paraTargetDivideCodeSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.SalesDateSt);
                paraTargetDivideCodeSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.TargetYearMonthSt);
                // 修正 2009.01.16 <<<

                retstring += " AND " + sTblNm + ".TARGETDIVIDECODERF<=@" + sTblNm + "TARGETDIVIDECODEED" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "TARGETDIVIDECODEED", SqlDbType.Int);
                // 修正 2009.01.16 >>>
                //paraTargetDivideCodeEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.SalesDateEd);
                paraTargetDivideCodeEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.TargetYearMonthEd);
                // 修正 2009.01.16 <<<
            }
            else if (iPrintType == 1) // 当月
            {
                retstring += " AND " + sTblNm + ".TARGETDIVIDECODERF>=@" + sTblNm + "TARGETDIVIDECODEST" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "TARGETDIVIDECODEST", SqlDbType.Int);
                // 修正 2009.01.16 >>>
                //paraTargetDivideCodeSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.MonthReportDateSt);
                paraTargetDivideCodeSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.TargetYearMonthSt);
                // 修正 2009.01.16 <<<

                retstring += " AND " + sTblNm + ".TARGETDIVIDECODERF<=@" + sTblNm + "TARGETDIVIDECODEED" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "TARGETDIVIDECODEED", SqlDbType.Int);
                // 修正 2009.01.16 >>>
                //paraTargetDivideCodeEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.MonthReportDateEd);
                paraTargetDivideCodeEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.TargetYearMonthEd);
                // 修正 2009.01.16 <<<
            }
            // ADD 2008.12.26 <<<

            #endregion

            return retstring;
        }
        #endregion  //[GcdSalesTarget用 Where句生成処理]

        #region [SalesDayMonthReportResultWork処理 呼出]
        /// <summary>
        /// クラス格納処理 Reader → SalesDayMonthReportResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesDayMonthReportResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.13</br>
        /// </remarks>
        public SalesDayMonthReportResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader, SalesDayMonthReportParamWork paramWork)
        {
            return this.CopyToResultWorkFromReaderProc(ref myReader, paramWork);
        }
        #endregion  //[SalesDayMonthReportResultWork処理 呼出]

        #region [SalesDayMonthReportResultWork処理]
        /// <summary>
        /// クラス格納処理 Reader → SalesDayMonthReportResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesDayMonthReportResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.13</br>
        /// </remarks>
        private SalesDayMonthReportResultWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, SalesDayMonthReportParamWork paramWork)
        {
            #region [抽出結果-値セット]
            SalesDayMonthReportResultWork resultWork = new SalesDayMonthReportResultWork();

            Int32 iSalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
            resultWork.Code = iSalesCode.ToString();
            resultWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));

            if (paramWork.TtlType == 1)
            {
                resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                resultWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            }

            resultWork.TermSalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TERMSALESSLIPCOUNT"));
            resultWork.TermSalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESTOTALTAXEXC"));
            resultWork.TermSalesBackTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESBACKTOTALTAXEXC"));
            resultWork.TermSalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESDISTTLTAXEXC"));
            resultWork.TermTotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMTOTALCOST"));
            resultWork.TermSalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESTARGETMONEY"));
            resultWork.TermSalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESTARGETPROFIT"));
            resultWork.MonthSalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONTHSALESSLIPCOUNT"));
            resultWork.MonthSalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESTOTALTAXEXC"));
            resultWork.MonthSalesBackTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESBACKTOTALTAXEXC"));
            resultWork.MonthSalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESDISTTLTAXEXC"));
            resultWork.MonthTotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHTOTALCOST"));
            resultWork.MonthSalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESTARGETMONEY"));
            resultWork.MonthSalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESTARGETPROFIT"));
            #endregion

            return resultWork;
        }
        #endregion  //[SalesDayMonthReportResultWork処理]
    }
}
