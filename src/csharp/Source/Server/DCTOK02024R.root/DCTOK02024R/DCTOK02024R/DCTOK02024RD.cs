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
    /// <summary>
    /// 得意先別用
    /// </summary>
    /// <remarks>
    /// <br>Update Note: 速度アップ対応</br>
    /// <br>           : 22008 長内 数馬</br>
    /// <br>           : 2009/10/09</br>
    /// <br>UpdateNote : 2010/08/05 楊明俊 PM1012 得意先マスタのコードで集計して印字する</br>
    /// <br>UpdateNote : 2011/01/28 長内 数馬 2010/08/05の修正に関して、業種別が未対応だったため修正</br>
    /// <br>Update Note: Redmine#28712 ReadUnCommitted対応</br>
    /// <br>           : zhangyong</br>
    /// <br>           : 2012/02/28</br>
    /// <br>Update Note: 2012/04/16 許培珠</br>
    /// <br>管理番号   : 10801804-00 5/24配信分</br>
    /// <br>             Redmine#29135   売上日報月報　達成率・進捗率の計算について</br>
    /// <br>Update Note: 2012/05/22 李亜博</br>
    /// <br>管理番号   : 10801804-00 06/27配信分</br>
    /// <br>             Redmine#29901   売上日報月報 売上目標が不正に印字される場合がある</br>
    /// <br>Update Note: 2012/05/22 李亜博</br>
    /// <br>管理番号   : 10801804-00 06/27配信分</br>
    /// <br>             Redmine#29898   売上日報月報 進捗率算出時に営業日を参照していないパターンが存在する</br>
    /// <br>Update Note: 2015/12/16 長内数馬</br>
    /// <br>管理番号   : 11070149-00 </br>
    /// <br>             イスコの環境にて得意先別で全社データを抽出時にイスコ個別用のインデックスが参照され、遅延が発生する件の修正</br>
    /// </remarks>
    class SalesSlipReport_Cust : SalesSlipReportBase, ISalesSlipReport
    {
        #region [CustSalesTarget用 Select文]
        /// <summary>
        /// 得意先別売上目標設定マスタ用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件格納クラス</param>
        /// <returns>得意先別売上目標設定マスタ用SELECT文</returns>
        /// <br>Note       : 得意先別売上目標設定マスタ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.13</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork)
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
        #endregion  //[CustSalesTarget用 Select文]

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
        /// <br>UpdateNote : 2012/05/22 李亜博 </br>
        /// <br>管理番号   : 10801804-00 06/27配信分</br>
        /// <br>             Redmine#29898 売上日報月報 進捗率算出時に営業日を参照していないパターンが存在する</br>
        private string MakeTypeCustomerQuery(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork)
        {
            #region [判別用フラグ]
            //得意先コード検索フラグ
            bool bCustomerCode = false;
            if ((paramWork.OutType == 0) ||
                (paramWork.OutType == 2) ||
                (paramWork.OutType == 3))
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
            if ((paramWork.OutType == 0) ||
                (paramWork.OutType == 2) ||
                (paramWork.OutType == 3))
            {
                bCustomerRF = true;
            }

            //自社名称マスタ検索フラグ
            bool bCompanyNmRF = false;
            if (paramWork.TtlType == 1)
            {
                bCompanyNmRF = true;
            }

            //WHERE句の拠点コード判別(拠点と管理拠点)
            //string sSecName = "SECTIONCODERF";
            string sSecName = "RESULTSADDUPSECCDRF";
            #endregion

            string selectTxt = "";

            // 対象テーブル
            // SALESHISTORYRF    SALHIS 売上履歴データ
            // CUSTSALESTARGETRF CUSTGT 得意先別売上目標設定マスタ
            // CUSTOMERRF        CUTMER 得意先マスタ
            // SECINFOSETRF      SCINST 拠点情報設定マスタ

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
            //出力順によって抽出項目を動的生成する
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHIS");
            selectTxt += IFBy(bCustomerRF, " ,CUTMER.CUSTOMERSNMRF" + Environment.NewLine);
            selectTxt += IFBy(bCustomerRF, " ,CUTMER.MNGSECTIONCODERF AS CUTMERMNGSECTIONCODERF" + Environment.NewLine);//ADD 2012/05/22 Redmine#29898 李亜博
            selectTxt += IFBy(bCompanyNmRF, " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
            selectTxt += IFBy(bMngSectionCode, " ,SALHIS.MNGSECTIONCODERF" + Environment.NewLine);

            //FROM
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            #region [売上履歴データ＋得意先別売上目標設定マスタ抽出用サブクエリ]
            selectTxt += "  SELECT" + Environment.NewLine;
            //selectTxt += "   SALHIST.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  ,SALHIST.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += "   SALHISMSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.SALESSLIPCDRF" + Environment.NewLine;

            selectTxt += "  ,SALHIST.TERMSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMTOTALCOST" + Environment.NewLine;
            selectTxt += "  ,CUSTGTT.TERMSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "  ,CUSTGTT.TERMSALESTARGETPROFIT" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHTOTALCOST" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESTARGETPROFIT" + Environment.NewLine;
            //selectTxt += IFBy(bMngSectionCode,
            //             "  ,SALHIST.MNGSECTIONCODERF" + Environment.NewLine);
            //selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHIST");
            selectTxt += IFBy(bMngSectionCode,
                         "  ,SALHISMSUB.MNGSECTIONCODERF" + Environment.NewLine);
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISMSUB");

            //FROM
            selectTxt += "  FROM" + Environment.NewLine;
            selectTxt += "  (" + Environment.NewLine;

            #region [データ抽出メインQuery]

            //期間分集計
            #region [期間分抽出Query]

            #region [売上履歴データ]
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     SALHISSUB1.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISSUB1.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISSUB1");
            selectTxt += "    ,COUNT(SALHISSUB1.SALESSLIPNUMRF)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESSLIPCOUNT" + Environment.NewLine;
            // DEL 2008.12.08 >>>
            //selectTxt += "    ,SUM(CASE WHEN SALHISSUB1.SALESSLIPCDRF=0" + Environment.NewLine;
            //selectTxt += "         THEN SALHISSUB1.SALESTOTALTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            //selectTxt += "      AS TERMSALESTOTALTAXEXC" + Environment.NewLine;
            //selectTxt += "    ,SUM(CASE WHEN SALHISSUB1.SALESSLIPCDRF=1" + Environment.NewLine;
            //selectTxt += "         THEN SALHISSUB1.SALESTOTALTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            //selectTxt += "      AS TERMSALESBACKTOTALTAXEXC" + Environment.NewLine;
            // DEL 2008.12.08 <<<
            // ADD 2008.12.08 >>>
            selectTxt += "    ,SUM(CASE WHEN SALHISSUB1.SALESSLIPCDRF=0" + Environment.NewLine;
            selectTxt += "         THEN SALHISSUB1.SALESNETPRICERF + DTL.SALESMONEYTAXEXC  ELSE 0 END)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SUM(CASE WHEN SALHISSUB1.SALESSLIPCDRF=1" + Environment.NewLine;
            selectTxt += "         THEN SALHISSUB1.SALESNETPRICERF + DTL.SALESMONEYTAXEXC ELSE 0 END)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESBACKTOTALTAXEXC" + Environment.NewLine;
            // ADD 2008.12.08 <<<
            //selectTxt += "    ,SUM(SALHISSUB1.SALESDISTTLTAXEXCRF)" + Environment.NewLine;
            selectTxt += "    ,SUM(DTL.SALESMONEYTAXEXCGOODS)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SUM(SALHISSUB1.TOTALCOSTRF)" + Environment.NewLine;
            selectTxt += "      AS TERMTOTALCOST" + Environment.NewLine;
            selectTxt += IFBy(bMngSectionCode,
                         "    ,SALHISSUB1.MNGSECTIONCODERF" + Environment.NewLine);

            if (bMngSectionCode)
            {
                #region [管理拠点順絞込み用サブクエリ]
                selectTxt += "   FROM" + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                selectTxt += "    SELECT" + Environment.NewLine;
                selectTxt += "      SALHISSUB1_1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.SALESTOTALTAXEXCRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.SALESDISTTLTAXEXCRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.TOTALCOSTRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.SALESSLIPCDRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.SALESDATERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.SALESNETPRICERF" + Environment.NewLine;
                selectTxt += "     ,CUTMERSUB1_1.MNGSECTIONCODERF" + Environment.NewLine;
                //----- Del 2012/02/28 zhangyong for Redmine#28712----->>>>>>>
                //selectTxt += "    FROM SALESHISTORYRF AS SALHISSUB1_1" + Environment.NewLine;
                //selectTxt += "    LEFT JOIN CUSTOMERRF CUTMERSUB1_1" + Environment.NewLine;
                //----- Del 2012/02/28 zhangyong for Redmine#28712-----<<<<<<<
                //----- Add 2012/02/28 zhangyong for Redmine#28712----->>>>>>>
                selectTxt += "    FROM SALESHISTORYRF AS SALHISSUB1_1 WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "    LEFT JOIN CUSTOMERRF CUTMERSUB1_1 WITH (READUNCOMMITTED)" + Environment.NewLine;
                //----- Add 2012/02/28 zhangyong for Redmine#28712-----<<<<<<<
                selectTxt += "    ON  CUTMERSUB1_1.ENTERPRISECODERF=SALHISSUB1_1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    AND CUTMERSUB1_1.CUSTOMERCODERF=SALHISSUB1_1.CUSTOMERCODERF" + Environment.NewLine;
                //selectTxt += MakeWhereString(ref sqlCommand, paramWork, 0, "SALHISSUB1_1", sSecName); // DEL 2008.12.08
                //selectTxt += MakeWhereString(ref sqlCommand, paramWork, 0, "SALHISSUB1_1", "RESULTSADDUPSECCDRF"); // ADD 2008.12.08
                selectTxt += MakeWhereString(ref sqlCommand, paramWork, 0, "SALHISSUB1_1", sSecName); // DEL 2008.12.08
                selectTxt += "   ) AS SALHISSUB1" + Environment.NewLine;
                #endregion  //[管理拠点順絞込み用サブクエリ]

                //次のWHERE句用に拠点コードＤＤ名を変更
                sSecName = "MNGSECTIONCODERF";
            }
            else
            {
                //管理拠点順以外
                //selectTxt += "   FROM SALESHISTORYRF AS SALHISSUB1" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
                selectTxt += "   FROM SALESHISTORYRF AS SALHISSUB1 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            }
            selectTxt += "   LEFT JOIN " + Environment.NewLine;
            selectTxt += "     (" + Environment.NewLine;
            selectTxt += "       SELECT " + Environment.NewLine;
            selectTxt += "        ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "        ,ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "        ,SALESSLIPNUMRF" + Environment.NewLine;
            selectTxt += "        ,SUM( CASE WHEN SALESSLIPCDDTLRF = 2 AND SHIPMENTCNTRF =0 THEN SALESMONEYTAXEXCRF ELSE 0 END ) AS SALESMONEYTAXEXC" + Environment.NewLine;
            selectTxt += "        ,SUM( CASE WHEN SALESSLIPCDDTLRF = 2 AND SHIPMENTCNTRF!=0 THEN SALESMONEYTAXEXCRF ELSE 0 END ) AS SALESMONEYTAXEXCGOODS" + Environment.NewLine;
            selectTxt += "       FROM          " + Environment.NewLine;
            //selectTxt += "        SALESHISTDTLRF " + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            //selectTxt += "        SALESHISTDTLRF WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712  //DEL 2015/12/16 osanai
            selectTxt += "        SALESHISTDTLRF WITH (READUNCOMMITTED,INDEX(SALESHISTDTLRF_IDX1))" + Environment.NewLine; //ADD 2015/12/16 osanai イスコ用の個別インデックスを参照しないようにパッケージ同様クラスタインデックス固定化
            //selectTxt += "       WHERE" + Environment.NewLine;
            //selectTxt += "        SALESSLIPCDDTLRF = 2  -- 値引" + Environment.NewLine;
            // -- ADD 2009/10/09 ------------------------->>>
            selectTxt += "       WHERE" + Environment.NewLine;
            selectTxt += "            SALESHISTDTLRF.ENTERPRISECODERF = @SALHISSUB1ENTERPRISECODE" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.ACPTANODRSTATUSRF = 30" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.SALESDATERF>=@SALHISSUB1SALESDATEST" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.SALESDATERF<=@SALHISSUB1SALESDATEED" + Environment.NewLine;
            // -- ADD 2009/10/09 -------------------------<<<
            selectTxt += "       GROUP BY" + Environment.NewLine;
            selectTxt += "        ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "        ,ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "        ,SALESSLIPNUMRF" + Environment.NewLine;
            selectTxt += "     ) AS DTL" + Environment.NewLine;
            selectTxt += "   ON ( SALHISSUB1.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   AND SALHISSUB1.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "   AND SALHISSUB1.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF)" + Environment.NewLine;

            //selectTxt += MakeWhereString(ref sqlCommand, paramWork, 0, "SALHISSUB1", sSecName); // DEL 2008.12.08
            //selectTxt += MakeWhereString(ref sqlCommand, paramWork, 0, "SALHISSUB1", "RESULTSADDUPSECCDRF"); // ADD 2008.12.08
            selectTxt += MakeWhereString(ref sqlCommand, paramWork, 0, "SALHISSUB1", sSecName); 
            selectTxt += "   GROUP BY" + Environment.NewLine;
            selectTxt += "     SALHISSUB1.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISSUB1.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISSUB1");
            selectTxt += IFBy(bMngSectionCode,
                         "    ,SALHISSUB1.MNGSECTIONCODERF" + Environment.NewLine);
            selectTxt += "  ) AS SALHIST" + Environment.NewLine;

            //次のWHERE句用に拠点コードＤＤ名を変更
            //sSecName = "SECTIONCODERF";
            sSecName = "RESULTSADDUPSECCDRF";
            #endregion  //[売上履歴データ]

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
            selectTxt += "      AS TERMSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "    ,SUM(CUSTGTSUB1.SALESTARGETPROFITRF)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESTARGETPROFIT" + Environment.NewLine;
            //selectTxt += "   FROM CUSTSALESTARGETRF AS CUSTGTSUB1" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            //selectTxt += "   FROM CUSTSALESTARGETRF AS CUSTGTSUB1 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712 // DEL 2012/04/16 xupz for redmine#29135
            // ----- ADD 2012/04/16 xupz for redmine#29135---------->>>>>
            //出力順が「1：拠点」の場合、「従業員別売上目標設定マスタ」テーブルから拠点単位の売上目標を集計する
            if (paramWork.OutType == 1)
            {
                selectTxt += "   FROM EMPSALESTARGETRF AS CUSTGTSUB1 WITH (READUNCOMMITTED)" + Environment.NewLine;
            }
            else 
            {
                selectTxt += "   FROM CUSTSALESTARGETRF AS CUSTGTSUB1 WITH (READUNCOMMITTED)" + Environment.NewLine;
            }
            // ----- ADD 2012/04/16 xupz for redmine#29135----------<<<<<
            selectTxt += MakeWhereString_Cust(ref sqlCommand, paramWork, "CUSTGTSUB1",0);
            // ----- ADD 2012/04/16 xupz for redmine#29135---------->>>>>
            //目標対比区分 10:拠点
            if (paramWork.OutType == 1)
            {
                selectTxt += "   AND CUSTGTSUB1.TARGETCONTRASTCDRF = 10 ";
            }
            // ----- ADD 2012/04/16 xupz for redmine#29135----------<<<<<
            
            selectTxt += "   GROUP BY" + Environment.NewLine;
            selectTxt += "     CUSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,CUSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
            selectTxt += IFBy(bMngSectionCode,
                         "    ,CUSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
            selectTxt += IFBy(bCustomerCode,
                         "    ,CUSTGTSUB1.CUSTOMERCODERF" + Environment.NewLine);
            selectTxt += "  ) AS CUSTGTT" + Environment.NewLine;
            selectTxt += "  ON  CUSTGTT.ENTERPRISECODERF=SALHIST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         //"  AND CUSTGTT.SECTIONCODERF=SALHIST.SECTIONCODERF" + Environment.NewLine); // DEL 2008.12.08
                         "  AND CUSTGTT.SECTIONCODERF=SALHIST.RESULTSADDUPSECCDRF" + Environment.NewLine); // DEL 2008.12.08
            selectTxt += IFBy(bMngSectionCode,
                         "  AND CUSTGTT.SECTIONCODERF=SALHIST.MNGSECTIONCODERF" + Environment.NewLine);
            selectTxt += IFBy(bCustomerCode,
                         "  AND CUSTGTT.CUSTOMERCODERF=SALHIST.CUSTOMERCODERF" + Environment.NewLine);
            #endregion  //[得意先別売上目標設定マスタ]

            #endregion  //[期間分抽出Query]

            //当月分集計
            #region [当月分抽出Query]

            #region [売上履歴データ]
            //selectTxt += "  LEFT JOIN (" + Environment.NewLine;
            selectTxt += "  RIGHT JOIN (" + Environment.NewLine;
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     SALHISM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISM.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISM");
            selectTxt += "    ,SALHISM.MONTHSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHTOTALCOST" + Environment.NewLine;
            selectTxt += "    ,CUSTGTM.MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "    ,CUSTGTM.MONTHSALESTARGETPROFIT" + Environment.NewLine;
            selectTxt += IFBy(bMngSectionCode,
                         "    ,SALHISM.MNGSECTIONCODERF" + Environment.NewLine);
            selectTxt += "   FROM" + Environment.NewLine;
            selectTxt += "   (" + Environment.NewLine;

            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     SALHISSUB2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISSUB2.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISSUB2");
            selectTxt += "    ,COUNT(SALHISSUB2.SALESSLIPNUMRF)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESSLIPCOUNT" + Environment.NewLine;
            // DEL 2008.12.08 >>>
            //selectTxt += "    ,SUM(CASE WHEN SALHISSUB2.SALESSLIPCDRF=0" + Environment.NewLine;
            //selectTxt += "         THEN SALHISSUB2.SALESTOTALTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            //selectTxt += "      AS MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            //selectTxt += "    ,SUM(CASE WHEN SALHISSUB2.SALESSLIPCDRF=1" + Environment.NewLine;
            //selectTxt += "         THEN SALHISSUB2.SALESTOTALTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            //selectTxt += "      AS MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            // DEL 2008.12.08 <<<
            // ADD 2008.12.08 >>>
            selectTxt += "    ,SUM(CASE WHEN SALHISSUB2.SALESSLIPCDRF=0" + Environment.NewLine;
            selectTxt += "         THEN SALHISSUB2.SALESNETPRICERF + DTL2.SALESMONEYTAXEXC ELSE 0 END)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SUM(CASE WHEN SALHISSUB2.SALESSLIPCDRF=1" + Environment.NewLine;
            selectTxt += "         THEN SALHISSUB2.SALESNETPRICERF + DTL2.SALESMONEYTAXEXC ELSE 0 END)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            // ADD 2008.12.08 <<<
            //selectTxt += "    ,SUM(SALHISSUB2.SALESDISTTLTAXEXCRF)" + Environment.NewLine;
            selectTxt += "    ,SUM(DTL2.SALESMONEYTAXEXCGOODS)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESDISTTLTAXEXC" + Environment.NewLine;

            selectTxt += "    ,SUM(SALHISSUB2.TOTALCOSTRF)" + Environment.NewLine;
            selectTxt += "      AS MONTHTOTALCOST" + Environment.NewLine;
            selectTxt += IFBy(bMngSectionCode,
                         "    ,SALHISSUB2.MNGSECTIONCODERF" + Environment.NewLine);

            if (bMngSectionCode)
            {
                #region [管理拠点順絞込み用サブクエリ]
                selectTxt += "   FROM" + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                selectTxt += "    SELECT" + Environment.NewLine;
                selectTxt += "      SALHISSUB2_1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.SALESTOTALTAXEXCRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.SALESDISTTLTAXEXCRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.TOTALCOSTRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.SALESSLIPCDRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.SALESDATERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.SALESNETPRICERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.RESULTSADDUPSECCDRF" + Environment.NewLine;
                selectTxt += "     ,CUTMERSUB2_1.MNGSECTIONCODERF" + Environment.NewLine;
                //----- Del 2012/02/28 zhangyong for Redmine#28712----->>>>>>>
                //selectTxt += "    FROM SALESHISTORYRF AS SALHISSUB2_1" + Environment.NewLine;
                //selectTxt += "    LEFT JOIN CUSTOMERRF CUTMERSUB2_1" + Environment.NewLine;
                //----- Del 2012/02/28 zhangyong for Redmine#28712-----<<<<<<<
                //----- Add 2012/02/28 zhangyong for Redmine#28712----->>>>>>>
                selectTxt += "    FROM SALESHISTORYRF AS SALHISSUB2_1 WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "    LEFT JOIN CUSTOMERRF CUTMERSUB2_1 WITH (READUNCOMMITTED)" + Environment.NewLine;
                //----- Add 2012/02/28 zhangyong for Redmine#28712-----<<<<<<<
                selectTxt += "    ON  CUTMERSUB2_1.ENTERPRISECODERF=SALHISSUB2_1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    AND CUTMERSUB2_1.CUSTOMERCODERF=SALHISSUB2_1.CUSTOMERCODERF" + Environment.NewLine;
                //selectTxt += MakeWhereString(ref sqlCommand, paramWork, 1, "SALHISSUB2_1", sSecName); // DEL 2008.12.08 
                //selectTxt += MakeWhereString(ref sqlCommand, paramWork, 1, "SALHISSUB2_1", "RESULTSADDUPSECCDRF"); // ADD 2008.12.08
                selectTxt += MakeWhereString(ref sqlCommand, paramWork, 1, "SALHISSUB2_1", sSecName); // DEL 2008.12.08 
                selectTxt += "   ) AS SALHISSUB2" + Environment.NewLine;
                #endregion  //[管理拠点順絞込み用サブクエリ]

                //次のWHERE句用に拠点コードＤＤ名を変更
                sSecName = "MNGSECTIONCODERF";
            }
            else
            {
                //管理拠点順以外
                //selectTxt += "   FROM SALESHISTORYRF AS SALHISSUB2" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
                selectTxt += "   FROM SALESHISTORYRF AS SALHISSUB2 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            }
            selectTxt += "   LEFT JOIN " + Environment.NewLine;
            selectTxt += "     (" + Environment.NewLine;
            selectTxt += "       SELECT " + Environment.NewLine;
            selectTxt += "        ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "        ,ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "        ,SALESSLIPNUMRF" + Environment.NewLine;
            selectTxt += "        ,SUM( CASE WHEN SALESSLIPCDDTLRF = 2 AND SHIPMENTCNTRF =0 THEN SALESMONEYTAXEXCRF ELSE 0 END ) AS SALESMONEYTAXEXC" + Environment.NewLine;
            selectTxt += "        ,SUM( CASE WHEN SALESSLIPCDDTLRF = 2 AND SHIPMENTCNTRF!=0 THEN SALESMONEYTAXEXCRF ELSE 0 END ) AS SALESMONEYTAXEXCGOODS" + Environment.NewLine;
            selectTxt += "       FROM          " + Environment.NewLine;
            //selectTxt += "        SALESHISTDTLRF " + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            //selectTxt += "        SALESHISTDTLRF WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712  //DEL 2015/12/16 osanai
            selectTxt += "        SALESHISTDTLRF WITH (READUNCOMMITTED,INDEX(SALESHISTDTLRF_IDX1))" + Environment.NewLine;//ADD 2015/12/16 osanai イスコ用の個別インデックスを参照しないようにパッケージ同様クラスタインデックス固定化
            //selectTxt += "       WHERE" + Environment.NewLine;
            //selectTxt += "        SALESSLIPCDDTLRF = 2  -- 値引" + Environment.NewLine;
            // -- ADD 2009/10/09 ------------------------->>>
            selectTxt += "       WHERE" + Environment.NewLine;
            selectTxt += "            SALESHISTDTLRF.ENTERPRISECODERF = @SALHISSUB2ENTERPRISECODE" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.ACPTANODRSTATUSRF = 30" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.SALESDATERF>=@MOSALHISSUB2SALESDATEST" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.SALESDATERF<=@MOSALHISSUB2SALESDATEED" + Environment.NewLine;
            // -- ADD 2009/10/09 -------------------------<<<
            selectTxt += "       GROUP BY" + Environment.NewLine;
            selectTxt += "        ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "        ,ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "        ,SALESSLIPNUMRF" + Environment.NewLine;
            selectTxt += "     ) AS DTL2" + Environment.NewLine;
            selectTxt += "   ON ( SALHISSUB2.ENTERPRISECODERF = DTL2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   AND SALHISSUB2.ACPTANODRSTATUSRF = DTL2.ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "   AND SALHISSUB2.SALESSLIPNUMRF = DTL2.SALESSLIPNUMRF)" + Environment.NewLine;

            //selectTxt += MakeWhereString(ref sqlCommand, paramWork, 1, "SALHISSUB2", sSecName); // DEL 2008.12.08
            //selectTxt += MakeWhereString(ref sqlCommand, paramWork, 1, "SALHISSUB2", "RESULTSADDUPSECCDRF"); // ADD 2008.12.08
            selectTxt += MakeWhereString(ref sqlCommand, paramWork, 1, "SALHISSUB2", sSecName); 
            selectTxt += "   GROUP BY" + Environment.NewLine;
            selectTxt += "     SALHISSUB2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISSUB2.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISSUB2");
            selectTxt += IFBy(bMngSectionCode,
                         "    ,SALHISSUB2.MNGSECTIONCODERF" + Environment.NewLine);
            selectTxt += "  ) AS SALHISM" + Environment.NewLine;

            //次のWHERE句用に拠点コードＤＤ名を変更
            //sSecName = "SECTIONCODERF";
            sSecName = "RESULTSADDUPSECCDRF";
            #endregion  //[売上履歴データ]

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
            selectTxt += "      AS MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "    ,SUM(CUSTGTSUB2.SALESTARGETPROFITRF)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESTARGETPROFIT" + Environment.NewLine;
            //selectTxt += "   FROM CUSTSALESTARGETRF AS CUSTGTSUB2" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            //selectTxt += "   FROM CUSTSALESTARGETRF AS CUSTGTSUB2 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712 // DEL 2012/04/16 xupz for redmine#29135
            // ----- ADD 2012/04/16 xupz for redmine#29135---------->>>>>
            //出力順が「1：拠点」の場合、「従業員別売上目標設定マスタ」テーブルから拠点単位の売上目標を集計する
            if (paramWork.OutType == 1)
            {
                selectTxt += "   FROM EMPSALESTARGETRF AS CUSTGTSUB2 WITH (READUNCOMMITTED)" + Environment.NewLine;
            }
            else
            {
                selectTxt += "   FROM CUSTSALESTARGETRF AS CUSTGTSUB2 WITH (READUNCOMMITTED)" + Environment.NewLine;
            }
            // ----- ADD 2012/04/16 xupz for redmine#29135----------<<<<<
            selectTxt += MakeWhereString_Cust(ref sqlCommand, paramWork, "CUSTGTSUB2",1);
            // ----- ADD 2012/04/16 xupz for redmine#29135---------->>>>>
            //目標対比区分 10:拠点
            if (paramWork.OutType == 1)
            {
                selectTxt += "   AND CUSTGTSUB2.TARGETCONTRASTCDRF = 10 ";
            }
            // ----- ADD 2012/04/16 xupz for redmine#29135----------<<<<<
            selectTxt += "   GROUP BY" + Environment.NewLine;
            selectTxt += "     CUSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,CUSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
            selectTxt += IFBy(bMngSectionCode,
                         "    ,CUSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
            selectTxt += IFBy(bCustomerCode,
                         "    ,CUSTGTSUB2.CUSTOMERCODERF" + Environment.NewLine);
            selectTxt += "  ) AS CUSTGTM" + Environment.NewLine;
            selectTxt += "  ON  CUSTGTM.ENTERPRISECODERF=SALHISM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         //"  AND CUSTGTM.SECTIONCODERF=SALHISM.SECTIONCODERF" + Environment.NewLine); // DEl 2008.12.08
                         "  AND CUSTGTM.SECTIONCODERF=SALHISM.RESULTSADDUPSECCDRF" + Environment.NewLine); // ADD 2008.12.08
            selectTxt += IFBy(bMngSectionCode,
                         "  AND CUSTGTM.SECTIONCODERF=SALHISM.MNGSECTIONCODERF" + Environment.NewLine);
            selectTxt += IFBy(bCustomerCode,
                         "  AND CUSTGTM.CUSTOMERCODERF=SALHISM.CUSTOMERCODERF" + Environment.NewLine);
            #endregion  //[得意先別売上目標設定マスタ]

            #endregion  //[当月分抽出Query]

            #endregion  //[データ抽出メインQuery]

            //期間分と当月分の結合条件
            selectTxt += "  ) AS SALHISMSUB" + Environment.NewLine;
            selectTxt += "  ON  SALHISMSUB.ENTERPRISECODERF=SALHIST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND SALHISMSUB.SALESSLIPCDRF=SALHIST.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += IFBy(bCustomerCode,
                         "  AND SALHISMSUB.CUSTOMERCODERF=SALHIST.CUSTOMERCODERF" + Environment.NewLine);
            selectTxt += IFBy(bSectionCode,
                         //"  AND SALHISMSUB.SECTIONCODERF=SALHIST.SECTIONCODERF" + Environment.NewLine);// DEL 2008.12.08
                         "  AND SALHISMSUB.RESULTSADDUPSECCDRF=SALHIST.RESULTSADDUPSECCDRF" + Environment.NewLine); // ADD 2008.12.08
            selectTxt += IFBy(bMngSectionCode,
                         "  AND SALHISMSUB.MNGSECTIONCODERF=SALHIST.MNGSECTIONCODERF" + Environment.NewLine);

            #endregion  //[売上履歴データ＋得意先別売上目標設定マスタ抽出用サブクエリ]

            selectTxt += " ) AS SALHIS" + Environment.NewLine;

            #region [JOIN]
            if (bCustomerRF)
            {
                //得意先マスタ
                //selectTxt += " LEFT JOIN CUSTOMERRF CUTMER" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
                selectTxt += " LEFT JOIN CUSTOMERRF CUTMER WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
                selectTxt += " ON  CUTMER.ENTERPRISECODERF=SALHIS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUTMER.CUSTOMERCODERF=SALHIS.CUSTOMERCODERF" + Environment.NewLine;
            }
            if (bCompanyNmRF)
            {
                //拠点情報設定マスタ
                //selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
                selectTxt += " ON  SCINST.ENTERPRISECODERF=SALHIS.ENTERPRISECODERF" + Environment.NewLine;
                if (bMngSectionCode)
                    selectTxt += " AND SCINST.SECTIONCODERF=SALHIS.MNGSECTIONCODERF" + Environment.NewLine;
                else
                    //selectTxt += " AND SCINST.SECTIONCODERF=SALHIS.SECTIONCODERF" + Environment.NewLine; // DEL 2008.12.08
                    selectTxt += " AND SCINST.SECTIONCODERF=SALHIS.RESULTSADDUPSECCDRF" + Environment.NewLine;  // ADD 2008.12.08

            }
            #endregion  //[JOIN]

            #endregion

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
        /// <br>UpdateNote : 2010/08/05 楊明俊 PM1012 得意先マスタのコードで集計して印字する</br>
        /// <br>UpdateNote : 2012/05/22 李亜博 </br>
        /// <br>管理番号   : 10801804-00 06/27配信分</br>
        /// <br>             Redmine#29901 売上日報月報 売上目標が不正に印字される場合がある</br>
        private string MakeTypeAreaBzTypeQuery(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork)
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
            if (paramWork.TtlType == 1)
            {
                bSectionCode = true;
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

            //WHERE句の拠点コード判別(拠点と管理拠点)
            string sSecName = "SECTIONCODERF";
            #endregion

            string selectTxt = "";

            // 対象テーブル
            // SALESHISTORYRF    SALHIS 売上履歴データ
            // CUSTSALESTARGETRF CUSTGT 得意先別売上目標設定マスタ
            // CUSTOMERRF        CUTMER 得意先マスタ
            // SECINFOSETRF      SCINST 拠点情報設定マスタ
            // USERGDBDURF       USRGBU ユーザーガイドマスタ(ボディ)

            #region [Select文作成]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  SALHIS.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " ,SALHIS.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += " ,SALHIS." + sTblName + Environment.NewLine;
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
            //出力順によって抽出項目を動的生成する
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHIS");
            selectTxt += " ,USRGBU.GUIDENAMERF" + Environment.NewLine;
            selectTxt += IFBy(bCustomerRF, " ,CUTMER.CUSTOMERSNMRF" + Environment.NewLine);
            selectTxt += IFBy(bCompanyNmRF, " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
            
            //FROM
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            #region [売上履歴データ＋得意先別売上目標設定マスタ抽出用サブクエリ]
            selectTxt += "  SELECT" + Environment.NewLine;
            //selectTxt += "   SALHIST.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  ,SALHIST.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += "   SALHISMSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.SALESSLIPCDRF" + Environment.NewLine;

            selectTxt += "  ,SALHISMSUB." + sTblName + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMTOTALCOST" + Environment.NewLine;
            selectTxt += "  ,CUSTGTT.TERMSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "  ,CUSTGTT.TERMSALESTARGETPROFIT" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHTOTALCOST" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESTARGETPROFIT" + Environment.NewLine;
            //selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHIST");
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISMSUB");

            //FROM
            selectTxt += "  FROM" + Environment.NewLine;
            selectTxt += "  (" + Environment.NewLine;

            #region [データ抽出メインQuery]

            //期間分集計
            #region [期間分抽出Query]

            #region [売上履歴データ]
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     SALHISSUB1.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISSUB1.SALESSLIPCDRF" + Environment.NewLine;

            // -- UPD 2010/08/05 ------------------------->>>>>
            //selectTxt += "    ,SALHISSUB1." + sTblName + Environment.NewLine;
            selectTxt += "    ,CUTMER1." + sTblName + Environment.NewLine;
            // -- UPD 2010/08/05 -------------------------<<<<<

            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISSUB1");
            selectTxt += "    ,COUNT(SALHISSUB1.SALESSLIPNUMRF)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESSLIPCOUNT" + Environment.NewLine;
            // DEL 2008.12.08 >>>
            //selectTxt += "    ,SUM(CASE WHEN SALHISSUB1.SALESSLIPCDRF=0" + Environment.NewLine;
            //selectTxt += "         THEN SALHISSUB1.SALESTOTALTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            //selectTxt += "      AS TERMSALESTOTALTAXEXC" + Environment.NewLine;
            //selectTxt += "    ,SUM(CASE WHEN SALHISSUB1.SALESSLIPCDRF=1" + Environment.NewLine;
            //selectTxt += "         THEN SALHISSUB1.SALESTOTALTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            //selectTxt += "      AS TERMSALESBACKTOTALTAXEXC" + Environment.NewLine;
            // DEL 2008.12.08 <<<
            // ADD 2008.12.08 >>>
            selectTxt += "    ,SUM(CASE WHEN SALHISSUB1.SALESSLIPCDRF=0" + Environment.NewLine;
            selectTxt += "         THEN SALHISSUB1.SALESNETPRICERF + DTL.SALESMONEYTAXEXC ELSE 0 END)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SUM(CASE WHEN SALHISSUB1.SALESSLIPCDRF=1" + Environment.NewLine;
            selectTxt += "         THEN SALHISSUB1.SALESNETPRICERF + DTL.SALESMONEYTAXEXC ELSE 0 END)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESBACKTOTALTAXEXC" + Environment.NewLine;
            // ADD 2008.12.08 <<<
            //selectTxt += "    ,SUM(SALHISSUB1.SALESDISTTLTAXEXCRF)" + Environment.NewLine;
            selectTxt += "    ,SUM(DTL.SALESMONEYTAXEXCGOODS)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SUM(SALHISSUB1.TOTALCOSTRF)" + Environment.NewLine;
            selectTxt += "      AS TERMTOTALCOST" + Environment.NewLine;
            //selectTxt += "   FROM SALESHISTORYRF AS SALHISSUB1" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += "   FROM SALESHISTORYRF AS SALHISSUB1 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712

            // -- ADD 2010/08/05 ------------------------->>>>>
            //selectTxt += " LEFT JOIN CUSTOMERRF CUTMER1" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += " LEFT JOIN CUSTOMERRF CUTMER1 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            selectTxt += " ON  CUTMER1.ENTERPRISECODERF=SALHISSUB1.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND CUTMER1.CUSTOMERCODERF=SALHISSUB1.CUSTOMERCODERF" + Environment.NewLine;
            // -- ADD 2010/08/05 -------------------------<<<<<

            selectTxt += "   LEFT JOIN " + Environment.NewLine;
            selectTxt += "     (" + Environment.NewLine;
            selectTxt += "       SELECT " + Environment.NewLine;
            selectTxt += "        ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "        ,ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "        ,SALESSLIPNUMRF" + Environment.NewLine;
            selectTxt += "        ,SUM( CASE WHEN SALESSLIPCDDTLRF = 2 AND SHIPMENTCNTRF =0 THEN SALESMONEYTAXEXCRF ELSE 0 END ) AS SALESMONEYTAXEXC" + Environment.NewLine;
            selectTxt += "        ,SUM( CASE WHEN SALESSLIPCDDTLRF = 2 AND SHIPMENTCNTRF!=0 THEN SALESMONEYTAXEXCRF ELSE 0 END ) AS SALESMONEYTAXEXCGOODS" + Environment.NewLine;
            selectTxt += "       FROM          " + Environment.NewLine;
            //selectTxt += "        SALESHISTDTLRF " + Environment.NewLine;;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += "        SALESHISTDTLRF WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            //selectTxt += "       WHERE" + Environment.NewLine;
            //selectTxt += "        SALESSLIPCDDTLRF = 2  -- 値引" + Environment.NewLine;
            // -- ADD 2009/10/09 ------------------------->>>
            selectTxt += "       WHERE" + Environment.NewLine;
            selectTxt += "            SALESHISTDTLRF.ENTERPRISECODERF = @SALHISSUB1ENTERPRISECODE" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.ACPTANODRSTATUSRF = 30" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.SALESDATERF>=@SALHISSUB1SALESDATEST" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.SALESDATERF<=@SALHISSUB1SALESDATEED" + Environment.NewLine;
            // -- ADD 2009/10/09 -------------------------<<<
            selectTxt += "       GROUP BY" + Environment.NewLine;
            selectTxt += "        ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "        ,ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "        ,SALESSLIPNUMRF" + Environment.NewLine;
            selectTxt += "     ) AS DTL" + Environment.NewLine;
            selectTxt += "   ON ( SALHISSUB1.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   AND SALHISSUB1.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "   AND SALHISSUB1.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF)" + Environment.NewLine;

            //selectTxt += MakeWhereString(ref sqlCommand, paramWork, 0, "SALHISSUB1", sSecName);// DEL 2008.12.08
            selectTxt += MakeWhereString(ref sqlCommand, paramWork, 0, "SALHISSUB1", "RESULTSADDUPSECCDRF"); // ADD 2008.12.08
            // -- ADD 2010/08/05 ------------------------->>>>>
            selectTxt += MakeWhereStringForArea(ref sqlCommand, paramWork,"CUTMER1");
            // -- ADD 2010/08/05 -------------------------<<<<<
            selectTxt += "   GROUP BY" + Environment.NewLine;
            selectTxt += "     SALHISSUB1.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISSUB1.SALESSLIPCDRF" + Environment.NewLine;
            // -- UPD 2010/08/05 ------------------------->>>>>
            //selectTxt += "    ,SALHISSUB1." + sTblName + Environment.NewLine;
            selectTxt += "    ,CUTMER1." + sTblName + Environment.NewLine;
            // -- UPD 2010/08/05 -------------------------<<<<<
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISSUB1");
            selectTxt += "  ) AS SALHIST" + Environment.NewLine;
            #endregion  //[売上履歴データ]

            #region [得意先別売上目標設定マスタ]
            selectTxt += "  LEFT JOIN (" + Environment.NewLine;
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     CUSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,CUSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "    ,CUSTGTSUB1." + sTblName + Environment.NewLine;
            selectTxt += IFBy(bCustomerCode,
                         "    ,CUSTGTSUB1.CUSTOMERCODERF" + Environment.NewLine);
            selectTxt += "    ,SUM(CUSTGTSUB1.SALESTARGETMONEYRF)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "    ,SUM(CUSTGTSUB1.SALESTARGETPROFITRF)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESTARGETPROFIT" + Environment.NewLine;
            //selectTxt += "   FROM CUSTSALESTARGETRF AS CUSTGTSUB1" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += "   FROM CUSTSALESTARGETRF AS CUSTGTSUB1 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            selectTxt += MakeWhereString_Cust(ref sqlCommand, paramWork, "CUSTGTSUB1",0);
            // --------------- ADD START 2012/05/22 Redmine#29901 李亜博-------->>>>
            //目標対比区分 32:地区別
            if (paramWork.TotalType == (int)TotalType.Area)
            {
                selectTxt += "   AND CUSTGTSUB1.TARGETCONTRASTCDRF = 32 ";
            }
            //目標対比区分 31:業種別
            else if (paramWork.TotalType == (int)TotalType.BzType)
            {
                selectTxt += "   AND CUSTGTSUB1.TARGETCONTRASTCDRF = 31 ";
            }
            // --------------- ADD END 2012/05/22 Redmine#29901 李亜博--------<<<<
            selectTxt += "   GROUP BY" + Environment.NewLine;
            selectTxt += "     CUSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,CUSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "    ,CUSTGTSUB1." + sTblName + Environment.NewLine;
            selectTxt += IFBy(bCustomerCode,
                         "    ,CUSTGTSUB1.CUSTOMERCODERF" + Environment.NewLine);
            selectTxt += "  ) AS CUSTGTT" + Environment.NewLine;
            selectTxt += "  ON  CUSTGTT.ENTERPRISECODERF=SALHIST.ENTERPRISECODERF" + Environment.NewLine;
            // 修正 2009/06/22 >>>
            //selectTxt += "  AND CUSTGTT.SECTIONCODERF = SALHIST.RESULTSADDUPSECCDRF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode, "  AND CUSTGTT.SECTIONCODERF = SALHIST.RESULTSADDUPSECCDRF" + Environment.NewLine);
            // 修正 2009/06/22 <<<
            selectTxt += "  AND CUSTGTT." + sTblName + "=SALHIST." + sTblName + Environment.NewLine;
            // ----- DEL 2012/04/16 xupz for redmine#29135---------->>>>>
            //redmine#29135 得意先別売上目標設定マスタから地区別、業者別の売上目標集計条件に、得意先の集計条件を削除する
            //selectTxt += IFBy(bCustomerCode,
            //             "  AND CUSTGTT.CUSTOMERCODERF=SALHIST.CUSTOMERCODERF" + Environment.NewLine);
            // ----- DEL 2012/04/16 xupz for redmine#29135----------<<<<<
            #endregion  //[得意先別売上目標設定マスタ]

            #endregion  //[期間分抽出Query]

            //当月分集計
            #region [当月分抽出Query]

            #region [売上履歴データ]
            //selectTxt += "  LEFT JOIN (" + Environment.NewLine;
            selectTxt += "  RIGHT JOIN (" + Environment.NewLine;
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     SALHISM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISM.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += "    ,SALHISM." + sTblName + Environment.NewLine;
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISM");
            selectTxt += "    ,SALHISM.MONTHSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHTOTALCOST" + Environment.NewLine;
            selectTxt += "    ,CUSTGTM.MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "    ,CUSTGTM.MONTHSALESTARGETPROFIT" + Environment.NewLine;
            selectTxt += "   FROM" + Environment.NewLine;
            selectTxt += "   (" + Environment.NewLine;

            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     SALHISSUB2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISSUB2.SALESSLIPCDRF" + Environment.NewLine;
            // -- UPD 2010/08/05 ------------------------->>>>>
            //selectTxt += "    ,SALHISSUB2." + sTblName + Environment.NewLine;
            selectTxt += "    ,CUTMER2." + sTblName + Environment.NewLine;
            // -- UPD 2010/08/05 -------------------------<<<<<
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISSUB2");
            selectTxt += "    ,COUNT(SALHISSUB2.SALESSLIPNUMRF)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESSLIPCOUNT" + Environment.NewLine;
            // DEL 2008.12.08 >>>
            //selectTxt += "    ,SUM(CASE WHEN SALHISSUB2.SALESSLIPCDRF=0" + Environment.NewLine;
            //selectTxt += "         THEN SALHISSUB2.SALESTOTALTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            //selectTxt += "      AS MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            //selectTxt += "    ,SUM(CASE WHEN SALHISSUB2.SALESSLIPCDRF=1" + Environment.NewLine;
            //selectTxt += "         THEN SALHISSUB2.SALESTOTALTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            //selectTxt += "      AS MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            // DEL 2008.12.08 <<<
            // ADD 2008.12.08 >>>
            selectTxt += "    ,SUM(CASE WHEN SALHISSUB2.SALESSLIPCDRF=0" + Environment.NewLine;
            selectTxt += "         THEN SALHISSUB2.SALESNETPRICERF + DTL2.SALESMONEYTAXEXC  ELSE 0 END)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SUM(CASE WHEN SALHISSUB2.SALESSLIPCDRF=1" + Environment.NewLine;
            selectTxt += "         THEN SALHISSUB2.SALESNETPRICERF + DTL2.SALESMONEYTAXEXC  ELSE 0 END)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            // ADD 2008.12.08 <<<
            //selectTxt += "    ,SUM(SALHISSUB2.SALESDISTTLTAXEXCRF)" + Environment.NewLine;
            selectTxt += "    ,SUM(DTL2.SALESMONEYTAXEXCGOODS)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SUM(SALHISSUB2.TOTALCOSTRF)" + Environment.NewLine;
            selectTxt += "      AS MONTHTOTALCOST" + Environment.NewLine;
            //selectTxt += "   FROM SALESHISTORYRF AS SALHISSUB2" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += "   FROM SALESHISTORYRF AS SALHISSUB2 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712

            // -- ADD 2010/08/05 ------------------------->>>>>
            //selectTxt += " LEFT JOIN CUSTOMERRF CUTMER2" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += " LEFT JOIN CUSTOMERRF CUTMER2 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            selectTxt += " ON  CUTMER2.ENTERPRISECODERF=SALHISSUB2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND CUTMER2.CUSTOMERCODERF=SALHISSUB2.CUSTOMERCODERF" + Environment.NewLine;
            // -- ADD 2010/08/05 -------------------------<<<<<

            selectTxt += "   LEFT JOIN " + Environment.NewLine;
            selectTxt += "     (" + Environment.NewLine;
            selectTxt += "       SELECT " + Environment.NewLine;
            selectTxt += "        ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "        ,ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "        ,SALESSLIPNUMRF" + Environment.NewLine;
            selectTxt += "        ,SUM( CASE WHEN SALESSLIPCDDTLRF = 2 AND SHIPMENTCNTRF =0 THEN SALESMONEYTAXEXCRF ELSE 0 END ) AS SALESMONEYTAXEXC" + Environment.NewLine;
            selectTxt += "        ,SUM( CASE WHEN SALESSLIPCDDTLRF = 2 AND SHIPMENTCNTRF!=0 THEN SALESMONEYTAXEXCRF ELSE 0 END ) AS SALESMONEYTAXEXCGOODS" + Environment.NewLine;
            selectTxt += "       FROM          " + Environment.NewLine;
            //selectTxt += "        SALESHISTDTLRF " + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += "        SALESHISTDTLRF  WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            //selectTxt += "       WHERE" + Environment.NewLine;
            //selectTxt += "        SALESSLIPCDDTLRF = 2  -- 値引" + Environment.NewLine;
            // -- ADD 2009/10/09 ------------------------->>>
            selectTxt += "       WHERE" + Environment.NewLine;
            selectTxt += "            SALESHISTDTLRF.ENTERPRISECODERF = @SALHISSUB2ENTERPRISECODE" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.ACPTANODRSTATUSRF = 30" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.SALESDATERF>=@MOSALHISSUB2SALESDATEST" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.SALESDATERF<=@MOSALHISSUB2SALESDATEED" + Environment.NewLine;
            // -- ADD 2009/10/09 -------------------------<<<
            selectTxt += "       GROUP BY" + Environment.NewLine;
            selectTxt += "        ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "        ,ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "        ,SALESSLIPNUMRF" + Environment.NewLine;
            selectTxt += "     ) AS DTL2" + Environment.NewLine;
            selectTxt += "   ON ( SALHISSUB2.ENTERPRISECODERF = DTL2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   AND SALHISSUB2.ACPTANODRSTATUSRF = DTL2.ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "   AND SALHISSUB2.SALESSLIPNUMRF = DTL2.SALESSLIPNUMRF)" + Environment.NewLine;
            //selectTxt += MakeWhereString(ref sqlCommand, paramWork, 1, "SALHISSUB2", sSecName); // DEL 2008.12.08
            selectTxt += MakeWhereString(ref sqlCommand, paramWork, 1, "SALHISSUB2", "RESULTSADDUPSECCDRF"); // ADD 2008.12.08
            // -- ADD 2010/08/05 ------------------------->>>>>
            selectTxt += MakeWhereStringForArea(ref sqlCommand, paramWork, "CUTMER2");
            // -- ADD 2010/08/05 -------------------------<<<<<
            selectTxt += "   GROUP BY" + Environment.NewLine;
            selectTxt += "     SALHISSUB2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISSUB2.SALESSLIPCDRF" + Environment.NewLine;
            // -- UPD 2010/08/05 ------------------------->>>>>
            //selectTxt += "    ,SALHISSUB2." + sTblName + Environment.NewLine;
            selectTxt += "    ,CUTMER2." + sTblName + Environment.NewLine;

            // -- UPD 2010/08/05 -------------------------<<<<<
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISSUB2");
            selectTxt += "  ) AS SALHISM" + Environment.NewLine;
            #endregion  //[売上履歴データ]

            #region [得意先別売上目標設定マスタ]
            selectTxt += "  LEFT JOIN (" + Environment.NewLine;
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     CUSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,CUSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "    ,CUSTGTSUB2." + sTblName + Environment.NewLine;
            selectTxt += IFBy(bCustomerCode,
                         "    ,CUSTGTSUB2.CUSTOMERCODERF" + Environment.NewLine);
            selectTxt += "    ,SUM(CUSTGTSUB2.SALESTARGETMONEYRF)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "    ,SUM(CUSTGTSUB2.SALESTARGETPROFITRF)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESTARGETPROFIT" + Environment.NewLine;
            //selectTxt += "   FROM CUSTSALESTARGETRF AS CUSTGTSUB2" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += "   FROM CUSTSALESTARGETRF AS CUSTGTSUB2 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            selectTxt += MakeWhereString_Cust(ref sqlCommand, paramWork, "CUSTGTSUB2",1);
            // --------------- ADD START 2012/05/22 Redmine#29901 李亜博-------->>>>
                //目標対比区分 32:地区別
                if (paramWork.TotalType == (int)TotalType.Area)
                {
                    selectTxt += "   AND CUSTGTSUB2.TARGETCONTRASTCDRF = 32 ";
                }
                //目標対比区分 31:業種別
                else if (paramWork.TotalType == (int)TotalType.BzType)
                {
                    selectTxt += "   AND CUSTGTSUB2.TARGETCONTRASTCDRF = 31 ";
                }
            // --------------- ADD END 2012/05/22 Redmine#29901 李亜博--------<<<<
            selectTxt += "   GROUP BY" + Environment.NewLine;
            selectTxt += "     CUSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,CUSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "    ,CUSTGTSUB2." + sTblName + Environment.NewLine;
            selectTxt += IFBy(bCustomerCode,
                         "    ,CUSTGTSUB2.CUSTOMERCODERF" + Environment.NewLine);
            selectTxt += "  ) AS CUSTGTM" + Environment.NewLine;
            selectTxt += "  ON  CUSTGTM.ENTERPRISECODERF=SALHISM.ENTERPRISECODERF" + Environment.NewLine;
            // 修正 2009/06/22 >>>
            //selectTxt += "  AND CUSTGTM.SECTIONCODERF = SALHISM.RESULTSADDUPSECCDRF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode, "  AND CUSTGTM.SECTIONCODERF = SALHISM.RESULTSADDUPSECCDRF" + Environment.NewLine);
            // 修正 2009/06/22 <<<
            selectTxt += "  AND CUSTGTM." + sTblName + "=SALHISM." + sTblName + Environment.NewLine;
            // ----- DEL 2012/04/16 xupz for redmine#29135---------->>>>>
            //redmine#29135 得意先別売上目標設定マスタから地区別、業者別の売上目標集計条件に、得意先の集計条件を削除する
            //selectTxt += IFBy(bCustomerCode,
            //             "  AND CUSTGTM.CUSTOMERCODERF=SALHISM.CUSTOMERCODERF" + Environment.NewLine);
            // ----- DEL 2012/04/16 xupz for redmine#29135----------<<<<<
            #endregion  //[得意先別売上目標設定マスタ]

            #endregion  //[当月分抽出Query]

            #endregion  //[データ抽出メインQuery]

            //期間分と当月分の結合条件
            selectTxt += "  ) AS SALHISMSUB" + Environment.NewLine;
            selectTxt += "  ON  SALHISMSUB.ENTERPRISECODERF=SALHIST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND SALHISMSUB.SALESSLIPCDRF=SALHIST.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += "  AND SALHISMSUB." + sTblName + "=SALHIST." + sTblName + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         //"  AND SALHISMSUB.SECTIONCODERF=SALHIST.SECTIONCODERF" + Environment.NewLine); // DEL 2008.12.08
                         "  AND SALHISMSUB.RESULTSADDUPSECCDRF=SALHIST.RESULTSADDUPSECCDRF" + Environment.NewLine); // ADD 2008.12.08
            selectTxt += IFBy(bCustomerCode,
                         "  AND SALHISMSUB.CUSTOMERCODERF=SALHIST.CUSTOMERCODERF" + Environment.NewLine);

            #endregion  //[売上履歴データ＋得意先別売上目標設定マスタ抽出用サブクエリ]

            selectTxt += " ) AS SALHIS" + Environment.NewLine;

            #region [JOIN]
            //ユーザーガイド区分判別
            int iUserGuideDivCd = 0;
            if (paramWork.TotalType == (int)TotalType.Area)
                iUserGuideDivCd = (int)UserGuideDivCd.SalesAreaCode;
            if (paramWork.TotalType == (int)TotalType.BzType)
                iUserGuideDivCd = (int)UserGuideDivCd.BusinessTypeCode;
            //ユーザーガイドマスタ(ボディ)
            //selectTxt += " LEFT JOIN USERGDBDURF USRGBU" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += " LEFT JOIN USERGDBDURF USRGBU WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            selectTxt += " ON  USRGBU.ENTERPRISECODERF=SALHIS.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USRGBU.USERGUIDEDIVCDRF=" + iUserGuideDivCd.ToString();
            selectTxt += " AND USRGBU.GUIDECODERF=SALHIS." + sTblName;

            if (bCustomerRF)
            {
                //得意先マスタ
                //selectTxt += " LEFT JOIN CUSTOMERRF CUTMER" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
                selectTxt += " LEFT JOIN CUSTOMERRF CUTMER WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
                selectTxt += " ON  CUTMER.ENTERPRISECODERF=SALHIS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUTMER.CUSTOMERCODERF=SALHIS.CUSTOMERCODERF" + Environment.NewLine;
            }
            if (bCompanyNmRF)
            {
                //拠点情報設定マスタ
                //selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
                selectTxt += " ON  SCINST.ENTERPRISECODERF=SALHIS.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND SCINST.SECTIONCODERF=SALHIS.SECTIONCODERF" + Environment.NewLine; // DEL 2008.12.08
                selectTxt += " AND SCINST.SECTIONCODERF=SALHIS.RESULTSADDUPSECCDRF" + Environment.NewLine; // ADD 2008.12.08
            }
            #endregion

            #endregion

            return selectTxt;
        }
        #endregion  //[地区別用・業種別用 Select文生成処理]

        #region [SalesHistory用 Where句生成処理]
        /// <summary>
        /// 売上履歴データ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件</param>
        /// <param name="iType">印刷タイプ 0:期間 1:当月</param>
        /// <param name="sTblNm">テーブル略称</param>
        /// <param name="sSecName">拠点コード項目名</param>
        /// <returns>売上履歴データ用WHERE句</returns>
        /// <br>Note       : 売上履歴データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.13</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork, int iType, string sTblNm, string sSecName)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //論理削除区分
            retstring += " AND " + sTblNm + ".LOGICALDELETECODERF=0 " + Environment.NewLine;

            //受注ステータス
            retstring += " AND " + sTblNm + ".ACPTANODRSTATUSRF=30" + Environment.NewLine;

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
                    retstring += " AND " + sTblNm + "." + sSecName + " IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //対象日付
            if (iType == 0)
            {
                //開始対象年月日(期間)
                // -- UPD 2010/05/10 ------------------------------------------------->>>
                //retstring += " AND " + sTblNm + ".SALESDATERF>=@" + sTblNm + "SALESDATEST" + Environment.NewLine;
                retstring += " AND " + sTblNm + ".SALESDATERF>=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.SalesDateSt).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------------------<<<
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESDATEST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.SalesDateSt);

                //終了対象年月日(期間)
                // -- UPD 2010/05/10 ------------------------------------------------->>>
                //retstring += " AND " + sTblNm + ".SALESDATERF<=@" + sTblNm + "SALESDATEED" + Environment.NewLine;
                retstring += " AND " + sTblNm + ".SALESDATERF<=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.SalesDateEd).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------------------<<<
                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESDATEED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.SalesDateEd);

            }
            else
            {
                //開始対象年月日(当月)
                // -- UPD 2010/05/10 ------------------------------------------------->>>
                //retstring += " AND " + sTblNm + ".SALESDATERF>=@MO" + sTblNm + "SALESDATEST" + Environment.NewLine;
                retstring += " AND " + sTblNm + ".SALESDATERF>=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.MonthReportDateSt).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------------------<<<
                SqlParameter paraMOSalesDateSt = sqlCommand.Parameters.Add("@MO" + sTblNm + "SALESDATEST", SqlDbType.Int);
                paraMOSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.MonthReportDateSt);

                //終了対象年月日(当月)
                // -- UPD 2010/05/10 ------------------------------------------------->>>
                //retstring += " AND " + sTblNm + ".SALESDATERF<=@MO" + sTblNm + "SALESDATEED" + Environment.NewLine;
                retstring += " AND " + sTblNm + ".SALESDATERF<=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.MonthReportDateEd).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------------------<<<
                SqlParameter paraMOSalesDateEd = sqlCommand.Parameters.Add("@MO" + sTblNm + "SALESDATEED", SqlDbType.Int);
                paraMOSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.MonthReportDateEd);

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

            // -- DEL 2011/01/28 -------------------------------------------------------->>>
            #region [削除]
            ////検索コード
            //switch (paramWork.TotalType)
            //{
            //    case (int)TotalType.Customer:
            //        //なし
            //        break;
            //    case (int)TotalType.Area:
            //        #region [地区別]
            //        //-----DEL 2010/08/05------>>>>>
            //        //地区コード
            //        //if (paramWork.SrchCodeSt != "")
            //        //{
            //        //    Int32 iSalesAreaCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //パラメータのキャスト
            //        //    retstring += " AND " + sTblNm + ".SALESAREACODERF>=@" + sTblNm + "SALESAREACODEST" + Environment.NewLine;
            //        //    SqlParameter paraSalesAreaCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESAREACODEST", SqlDbType.Int);
            //        //    paraSalesAreaCodeSt.Value = SqlDataMediator.SqlSetInt32(iSalesAreaCodeSt);
            //        //}
            //        //if ((paramWork.SrchCodeEd != ""))
            //        //{
            //        //    Int32 iSalesAreaCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //パラメータのキャスト
            //        //    retstring += " AND " + sTblNm + ".SALESAREACODERF<=@" + sTblNm + "SALESAREACODEED" + Environment.NewLine;
            //        //    SqlParameter paraSalesAreaCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESAREACODEED", SqlDbType.Int);
            //        //    paraSalesAreaCodeEd.Value = SqlDataMediator.SqlSetInt32(iSalesAreaCodeEd);
            //        //}
            //        //-----DEL 2010/08/05------<<<<<
            //        #endregion
            //        break;
            //    case (int)TotalType.BzType:
            //        #region [業種別]
            //        //業種コード
            //        if (paramWork.SrchCodeSt != "")
            //        {
            //            Int32 iBusinessTypeCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //パラメータのキャスト
            //            retstring += " AND " + sTblNm + ".BUSINESSTYPECODERF>=@" + sTblNm + "BUSINESSTYPECODEST" + Environment.NewLine;
            //            SqlParameter paraBusinessTypeCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "BUSINESSTYPECODEST", SqlDbType.Int);
            //            paraBusinessTypeCodeSt.Value = SqlDataMediator.SqlSetInt32(iBusinessTypeCodeSt);
            //        }
            //        if ((paramWork.SrchCodeEd != ""))
            //        {
            //            Int32 iBusinessTypeCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //パラメータのキャスト
            //            retstring += " AND " + sTblNm + ".BUSINESSTYPECODERF<=@" + sTblNm + "BUSINESSTYPECODEED" + Environment.NewLine;
            //            SqlParameter paraBusinessTypeCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "BUSINESSTYPECODEED", SqlDbType.Int);
            //            paraBusinessTypeCodeEd.Value = SqlDataMediator.SqlSetInt32(iBusinessTypeCodeEd);
            //        }
            //        #endregion
            //        break;
            //    default:
            //        break;
            //}
            #endregion
            // -- DEL 2011/01/28 --------------------------------------------------------<<<
            #endregion

            return retstring;
        }

        //-----ADD 2010/08/05------>>>>> 
        /// <summary>
        /// 売上履歴データ用WHERE句 (地区別)生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件</param>
        /// <param name="sTblNm">テーブル略称</param>
        /// <returns>売上履歴データ用WHERE句</returns>
        /// <br>Note       : 売上履歴データ用(地区別)WHERE句を作成して戻します</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/05</br>
        private string MakeWhereStringForArea(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork, string sTblNm)
        {
            #region WHERE文作成

            string retstring = "";
            //検索コード
            switch (paramWork.TotalType)
            {
                case (int)TotalType.Customer:
                    //なし
                    break;
                case (int)TotalType.Area:
                    #region [地区別]
                    //地区コード
                    if (paramWork.SrchCodeSt != "")
                    {
                        Int32 iSalesAreaCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //パラメータのキャスト
                        retstring += " AND " + sTblNm + ".SALESAREACODERF>=@" + sTblNm + "SALESAREACODEST" + Environment.NewLine;
                        SqlParameter paraSalesAreaCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESAREACODEST", SqlDbType.Int);
                        paraSalesAreaCodeSt.Value = SqlDataMediator.SqlSetInt32(iSalesAreaCodeSt);
                    }
                    if ((paramWork.SrchCodeEd != ""))
                    {
                        Int32 iSalesAreaCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //パラメータのキャスト
                        retstring += " AND " + sTblNm + ".SALESAREACODERF<=@" + sTblNm + "SALESAREACODEED" + Environment.NewLine;
                        SqlParameter paraSalesAreaCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESAREACODEED", SqlDbType.Int);
                        paraSalesAreaCodeEd.Value = SqlDataMediator.SqlSetInt32(iSalesAreaCodeEd);
                    }
                    #endregion
                    break;
                case (int)TotalType.BzType:
                    // -- ADD 2011/01/28 ------------------------->>>
                    #region [業種別]
                    //業種コード
                    if (paramWork.SrchCodeSt != "")
                    {
                        Int32 iBusinessTypeCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //パラメータのキャスト
                        retstring += " AND " + sTblNm + ".BUSINESSTYPECODERF>=@" + sTblNm + "BUSINESSTYPECODEST" + Environment.NewLine;
                        SqlParameter paraBusinessTypeCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "BUSINESSTYPECODEST", SqlDbType.Int);
                        paraBusinessTypeCodeSt.Value = SqlDataMediator.SqlSetInt32(iBusinessTypeCodeSt);
                    }
                    if ((paramWork.SrchCodeEd != ""))
                    {
                        Int32 iBusinessTypeCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //パラメータのキャスト
                        retstring += " AND " + sTblNm + ".BUSINESSTYPECODERF<=@" + sTblNm + "BUSINESSTYPECODEED" + Environment.NewLine;
                        SqlParameter paraBusinessTypeCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "BUSINESSTYPECODEED", SqlDbType.Int);
                        paraBusinessTypeCodeEd.Value = SqlDataMediator.SqlSetInt32(iBusinessTypeCodeEd);
                    }
                    #endregion
                    // -- ADD 2011/01/28 -------------------------<<<
                    break;
                default:
                    break;
            }
            #endregion

            return retstring;
        }
        //-----ADD 2010/08/05------<<<<<

        #endregion  //[SalesHistory用 Where句生成処理]

        #region [CustSalesTarget用 Where句生成処理]
        /// <summary>
        /// 得意先別売上目標設定マスタ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件</param>
        /// <returns>得意先別売上目標設定マスタ用WHERE句</returns>
        /// <br>Note       : 得意先別売上目標設定マスタ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.13</br>
        /// <br>UpdateNote : 2012/05/22 李亜博 </br>
        /// <br>管理番号   : 10801804-00 06/27配信分</br>
        /// <br>             Redmine#29898 売上日報月報 進捗率算出時に営業日を参照していないパターンが存在する</br> 
        private string MakeWhereString_Cust(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork, string sTblNm, Int32 iPrintType)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //検索コード
            switch (paramWork.TotalType)
            {
                case (int)TotalType.Customer:
                    // --------------- DEL START 2012/05/22 Redmine#29898 李亜博-------->>>>
                    // --------------- ADD START 2012/05/22 Redmine#29898 李亜博-------->>>>
                    //if (paramWork.TtlType == 0 && paramWork.OutType==1)
                    //{
                    //    //集計方法：全社  出力順:拠点
                    //    string sectionCodestr = "";
                    //    foreach (string seccdstr in paramWork.SectionCodes)
                    //    {
                    //        if (sectionCodestr != "")
                    //        {
                    //            sectionCodestr += ",";
                    //        }
                    //        sectionCodestr += "'" + seccdstr + "'";
                    //    }
                    //    if (sectionCodestr != "")
                    //    {
                    //        retstring += " AND " + sTblNm + ".SECTIONCODERF IN (" + sectionCodestr + ") ";
                    //    }
                    //    retstring += Environment.NewLine;
                    //}
                    // --------------- ADD END 2012/05/22 Redmine#29898 李亜博--------<<<<
                    // --------------- DEL END 2012/05/22 Redmine#29898 李亜博--------<<<<
                    break;
                case (int)TotalType.Area:
                    #region [地区別]
                    //地区コード
                    if (paramWork.SrchCodeSt != "")
                    {
                        Int32 iSalesAreaCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //パラメータのキャスト
                        retstring += " AND " + sTblNm + ".SALESAREACODERF>=@" + sTblNm + "SALESAREACODEST" + Environment.NewLine;
                        SqlParameter paraSalesAreaCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESAREACODEST", SqlDbType.Int);
                        paraSalesAreaCodeSt.Value = SqlDataMediator.SqlSetInt32(iSalesAreaCodeSt);
                    }
                    if ((paramWork.SrchCodeEd != ""))
                    {
                        Int32 iSalesAreaCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //パラメータのキャスト
                        retstring += " AND " + sTblNm + ".SALESAREACODERF<=@" + sTblNm + "SALESAREACODEED" + Environment.NewLine;
                        SqlParameter paraSalesAreaCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESAREACODEED", SqlDbType.Int);
                        paraSalesAreaCodeEd.Value = SqlDataMediator.SqlSetInt32(iSalesAreaCodeEd);
                    }
                    // --------------- DEL START 2012/05/22 Redmine#29898 李亜博-------->>>>
                    // --------------- ADD START 2012/05/22 Redmine#29898 李亜博-------->>>>
                    //if (paramWork.TtlType == 0)
                    //{
                    //    //集計方法：全社  
                    //    string sectionCodestr = "";
                    //    foreach (string seccdstr in paramWork.SectionCodes)
                    //    {
                    //        if (sectionCodestr != "")
                    //        {
                    //            sectionCodestr += ",";
                    //        }
                    //        sectionCodestr += "'" + seccdstr + "'";
                    //    }
                    //    if (sectionCodestr != "")
                    //    {
                    //        retstring += " AND " + sTblNm + ".SECTIONCODERF IN (" + sectionCodestr + ") ";
                    //    }
                    //    retstring += Environment.NewLine;
                    //}
                    // --------------- ADD END 2012/05/22 Redmine#29898 李亜博--------<<<<
                    // --------------- DEL END 2012/05/22 Redmine#29898 李亜博--------<<<<
                    #endregion
                    break;
                case (int)TotalType.BzType:
                    #region [業種別]
                    //業種コード
                    if (paramWork.SrchCodeSt != "")
                    {
                        Int32 iBusinessTypeCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //パラメータのキャスト
                        retstring += " AND " + sTblNm + ".BUSINESSTYPECODERF>=@" + sTblNm + "BUSINESSTYPECODEST" + Environment.NewLine;
                        SqlParameter paraBusinessTypeCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "BUSINESSTYPECODEST", SqlDbType.Int);
                        paraBusinessTypeCodeSt.Value = SqlDataMediator.SqlSetInt32(iBusinessTypeCodeSt);
                    }
                    if ((paramWork.SrchCodeEd != ""))
                    {
                        Int32 iBusinessTypeCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //パラメータのキャスト
                        retstring += " AND " + sTblNm + ".BUSINESSTYPECODERF<=@" + sTblNm + "BUSINESSTYPECODEED" + Environment.NewLine;
                        SqlParameter paraBusinessTypeCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "BUSINESSTYPECODEED", SqlDbType.Int);
                        paraBusinessTypeCodeEd.Value = SqlDataMediator.SqlSetInt32(iBusinessTypeCodeEd);
                    }
                    // --------------- DEL START 2012/05/22 Redmine#29898 李亜博-------->>>>
                    // --------------- ADD START 2012/05/22 Redmine#29898 李亜博-------->>>>
                    //if (paramWork.TtlType == 0)
                    //{
                    //    //集計方法：全社  
                    //    string sectionCodestr = "";
                    //    foreach (string seccdstr in paramWork.SectionCodes)
                    //    {
                    //        if (sectionCodestr != "")
                    //        {
                    //            sectionCodestr += ",";
                    //        }
                    //        sectionCodestr += "'" + seccdstr + "'";
                    //    }
                    //    if (sectionCodestr != "")
                    //    {
                    //        retstring += " AND " + sTblNm + ".SECTIONCODERF IN (" + sectionCodestr + ") ";
                    //    }
                    //    retstring += Environment.NewLine;
                    //}
                    // --------------- ADD END 2012/05/22 Redmine#29898 李亜博--------<<<<
                    // --------------- DEL END 2012/05/22 Redmine#29898 李亜博--------<<<<
                    #endregion
                    break;
                default:
                    break;
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
        #endregion  //[CustSalesTarget用 Where句生成処理]

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
        /// <br>UpdateNote : 2012/05/22 李亜博 </br>
        /// <br>管理番号   : 10801804-00 06/27配信分</br>
        /// <br>             Redmine#29898 売上日報月報 進捗率算出時に営業日を参照していないパターンが存在する</br>
        /// </remarks>
        private SalesDayMonthReportResultWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, SalesDayMonthReportParamWork paramWork)
        {
            #region [抽出結果-値セット]
            SalesDayMonthReportResultWork resultWork = new SalesDayMonthReportResultWork();

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
                            //resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); // DEL 2008.12.08
                            resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF")); // ADD 2008.12.08
                        resultWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    }

                    if ((paramWork.OutType == 0) ||
                        (paramWork.OutType == 2) ||
                        (paramWork.OutType == 3))
                    {
                        resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                        resultWork.SectionMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUTMERMNGSECTIONCODERF"));//ADD 2012/05/22 李亜博 Redmine#29898
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
                        //resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); // DEL 2008.12.08
                        resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF")); // ADD 2008.12.08
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
                        //resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); // DEL 2008.12.08
                        resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF")); // ADD 2008.12.08
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
