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
    class MTtlSaSlipWhouse : MTtlSaSlipBase, IMTtlSaSlip
    {
        #region [判別用フラグ宣言]
        private bool bSectionCode = false;    //拠点コード
        private bool bWarehouseCode = false;  //倉庫コード
        private bool bCustomerCode = false;   //得意先コード
        private bool bGoodsMakerCd = false;   //商品メーカーコード
        private bool bBLGoodsCode = false;    //BL商品コード
        private bool bGoodsNo = false;        //商品番号
        private bool bBLGroupCode = false;    //BLグループコード
        private bool bGoodsMGroup = false;    //商品中分類コード
        private bool bGoodsLGroup = false;    //商品大分類コード
        private bool bAnnual = false;        //当期印刷
        #endregion  //[判別用フラグ宣言]

        #region [倉庫用 Select文]
        /// <summary>
        /// 倉庫用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>倉庫用SELECT文</returns>
        /// <br>Note       : 倉庫用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.02</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, CndtnWork);
        }
        #endregion  //[倉庫用 Select文]

        #region [倉庫用 Select文生成処理]
        /// <summary>
        /// 倉庫用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>倉庫用SELECT文</returns>
        /// <br>Note       : 倉庫用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.02</br>
        /// <br>Update Note: 2009.04.28 張莉莉</br>
        /// <br>            ・メーカー略称==>メーカー名称
        /// <br>Update Note: 2012/03/30 郭永祥 </br>
        /// <br>管理番号   ：10801804-00 2012/05/24配信分</br>
        /// <br>             Redmine#29142 「商品値引」の場合は集計対象外となるように修正する</br>。
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork)
        {
            #region [判別用フラグ]
            //拠点コード
            if (((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.TtlType == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.TtlType == 1) && (CndtnWork.Detail != 7)))
            {
                bSectionCode = true;
            }

            //倉庫コード
            if (((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 0)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 4)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 5)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 6)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 0)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 4)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 5)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 6)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 7)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 0)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 4)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 5)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 6)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 7)))
            {
                bWarehouseCode = true;
            }

            //得意先コード
            if (((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 0)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 4)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 5)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 6)))
            {
                bCustomerCode = true;
            }

            //商品番号
            if (CndtnWork.Detail == 0)
            {
                bGoodsNo = true;
            }

            //商品メーカーコード
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 5) ||
                ((CndtnWork.MakerPrintDiv == 1) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.MakerPrintDiv == 1) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.MakerPrintDiv == 1) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.MakerPrintDiv == 1) && (CndtnWork.Detail == 4)))
            {
                bGoodsMakerCd = true;
            }

            //BL商品コード
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1))
            {
                bBLGoodsCode = true;
            }

            //BLグループコード
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1) ||
                (CndtnWork.Detail == 2))
            {
                bBLGroupCode = true;
            }

            //商品中分類コード
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1) ||
                (CndtnWork.Detail == 2) ||
                (CndtnWork.Detail == 3))
            {
                bGoodsMGroup = true;
            }

            //商品大分類コード
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1) ||
                (CndtnWork.Detail == 2) ||
                (CndtnWork.Detail == 3) ||
                (CndtnWork.Detail == 4))
            {
                bGoodsLGroup = true;
            }

            //当期印刷
            if (CndtnWork.AnnualPrintDiv == 1)
            {
                bAnnual = true;
            }
            #endregion  //[判別用フラグ]

            string selectTxt = "";

            // 対象テーブル
            // SALESHISTORYRF    SALHIS 売上履歴データ
            // SALESHISTDTLRF    SALDTL 売上履歴明細データ
            // GOODSURF          GOODSU 商品マスタ(ユーザー)
            // BLGOODSCDURF      BLGCDU BL商品コードマスタ(ユーザー)
            // BLGROUPURF        BLGRPU BLグループマスタ(ユーザー)
            // MAKERURF          MAKERU メーカーマスタ(ユーザー登録分)
            // USERGDBDURF       USGDBU ユーザーガイドマスタ(ボディ)(ユーザ変更分)
            // SECINFOSETRF      SCINST 拠点情報設定マスタ
            // WAREHOUSERF       WARHUS 倉庫マスタ
            // CUSTOMERRF        CUSTMR 得意先マスタ
            // GOODSGROUPURF     GSGRPU 商品中分類マスタ(ユーザー登録分)

            #region [Select文作成]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  SALDTL.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bWarehouseCode,
                         " ,SALDTL.WAREHOUSECODERF" + Environment.NewLine);
            selectTxt += IFBy(bWarehouseCode,
                         " ,WARHUS.WAREHOUSENAMERF" + Environment.NewLine);
            selectTxt += IFBy(bCustomerCode,
                         " ,SALDTL.CUSTOMERCODERF" + Environment.NewLine);
            selectTxt += IFBy(bCustomerCode,
                         " ,CUSTMR.CUSTOMERSNMRF" + Environment.NewLine);
            selectTxt += IFBy(bSectionCode,
                         //" ,SALDTL.SECTIONCODERF" + Environment.NewLine);      // DEL 2011/04/21
                         " ,SALDTL.RESULTSADDUPSECCDRF" + Environment.NewLine);  // ADD 2011/04/21
            selectTxt += IFBy(bSectionCode,
                         " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMakerCd,
                         " ,SALDTL.GOODSMAKERCDRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMakerCd,
                         " ,MAKERU.MAKERNAMERF" + Environment.NewLine);  // Update 2009/04/28
            selectTxt += IFBy(bBLGoodsCode,
                         " ,SALDTL.BLGOODSCODERF" + Environment.NewLine);
            selectTxt += IFBy(bBLGoodsCode,
                         " ,BLGCDU.BLGOODSHALFNAMERF" + Environment.NewLine);
            selectTxt += IFBy(bBLGroupCode,
                         " ,SALDTL.BLGROUPCODERF" + Environment.NewLine);
            selectTxt += IFBy(bBLGroupCode,
                         " ,BLGRPU.BLGROUPKANANAMERF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMGroup,
                         " ,SALDTL.GOODSMGROUPRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMGroup,
                         " ,GSGRPU.GOODSMGROUPNAMERF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsLGroup,
                         " ,SALDTL.GOODSLGROUPRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsLGroup,
                         " ,USGDBUL.GUIDENAMERF AS GOODSLGROUPNAME" + Environment.NewLine);
            selectTxt += IFBy(bGoodsNo,
                         " ,SALDTL.GOODSNORF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsNo,
                         " ,GOODSU.GOODSNAMEKANARF" + Environment.NewLine);
            //当月
            selectTxt += " ,SALDTL.MONTHTOTALSALESCOUNT" + Environment.NewLine;
            selectTxt += " ,SALDTL.MONTHSALESMONEY" + Environment.NewLine;
            selectTxt += " ,SALDTL.MONTHGROSSPROFIT" + Environment.NewLine;
            //当期
            if (bAnnual)
            {
                selectTxt += " ,SALDTL.ANNUALTOTALSALESCOUNT" + Environment.NewLine;
                selectTxt += " ,SALDTL.ANNUALSALESMONEY" + Environment.NewLine;
                selectTxt += " ,SALDTL.ANNUALGROSSPROFIT" + Environment.NewLine;
            }
            //FROM
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            #region [データ抽出メインQuery]
            selectTxt += "  SELECT" + Environment.NewLine;
            selectTxt += "    SALDTLSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bWarehouseCode,
                         "   ,SALDTLSUB.WAREHOUSECODERF" + Environment.NewLine);
            selectTxt += IFBy(bCustomerCode,
                         "   ,SALDTLSUB.CUSTOMERCODERF" + Environment.NewLine);
            selectTxt += IFBy(bSectionCode,
                         //"   ,SALDTLSUB.SECTIONCODERF" + Environment.NewLine);   // DEL 2011/04/21 
                         "   ,SALDTLSUB.RESULTSADDUPSECCDRF" + Environment.NewLine);   // ADD 2011/04/21 
            selectTxt += IFBy(bGoodsMakerCd,
                         "   ,SALDTLSUB.GOODSMAKERCDRF" + Environment.NewLine);
            selectTxt += IFBy(bBLGoodsCode,
                         "   ,SALDTLSUB.BLGOODSCODERF" + Environment.NewLine);
            selectTxt += IFBy(bBLGroupCode,
                         "   ,SALDTLSUB.BLGROUPCODERF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMGroup,
                         "   ,SALDTLSUB.GOODSMGROUPRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsLGroup,
                         "   ,SALDTLSUB.GOODSLGROUPRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsNo,
                         "   ,SALDTLSUB.GOODSNORF" + Environment.NewLine);
            selectTxt += "   ,SUM(SALDTLSUB.M_TOTALSALESCOUNTRF) AS MONTHTOTALSALESCOUNT" + Environment.NewLine;
            selectTxt += "   ,SUM(SALDTLSUB.M_SALESMONEYRF) AS MONTHSALESMONEY" + Environment.NewLine;
            selectTxt += "   ,SUM(SALDTLSUB.M_GROSSPROFITRF) AS MONTHGROSSPROFIT" + Environment.NewLine;
            if (bAnnual)
            {
                selectTxt += "   ,SUM(SALDTLSUB.A_TOTALSALESCOUNTRF) AS ANNUALTOTALSALESCOUNT" + Environment.NewLine;
                selectTxt += "   ,SUM(SALDTLSUB.A_SALESMONEYRF) AS ANNUALSALESMONEY" + Environment.NewLine;
                selectTxt += "   ,SUM(SALDTLSUB.A_GROSSPROFITRF) AS ANNUALGROSSPROFIT" + Environment.NewLine;
            }
            selectTxt += "  FROM" + Environment.NewLine;
            selectTxt += "  (" + Environment.NewLine;

            #region [売上履歴明細データ抽出]

            if (bAnnual)
            {
                #region [当期分を抽出する]

                #region [当期分抽出]
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     SALHISSUBA.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,SALHISSUBA.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBA.SALESSLIPDTLNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALHISSUBA.SALESDATERF" + Environment.NewLine;
                selectTxt += "    ,SALHISSUBA.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBA.WAREHOUSECODERF" + Environment.NewLine;
                //selectTxt += "    ,SALDTLSUBA.SECTIONCODERF" + Environment.NewLine;  // DEL 2011/04/21
                selectTxt += "    ,SALHISSUBA.RESULTSADDUPSECCDRF" + Environment.NewLine;  // ADD 2011/04/21
                selectTxt += "    ,SALDTLSUBA.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBA.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBA.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBA.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBA.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBA.GOODSNORF" + Environment.NewLine;
                //selectTxt += "    ,(CASE WHEN SALDTLSUBA.SHIPMENTCNTRF IS NULL THEN 0 ELSE" + Environment.NewLine;  //DEL 郭永祥 2012/03/30 Redmine#29142　
                selectTxt += "    ,(CASE WHEN SALDTLSUBA.SHIPMENTCNTRF IS NULL OR (SALDTLSUBA.SHIPMENTCNTRF != 0 AND SALDTLSUBA.SALESSLIPCDDTLRF = 2) THEN 0 ELSE" + Environment.NewLine;  //ADD 郭永祥 2012/03/30 Redmine#29142
                selectTxt += "      SALDTLSUBA.SHIPMENTCNTRF END) AS A_TOTALSALESCOUNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBA.SALESMONEYTAXEXCRF AS A_SALESMONEYRF" + Environment.NewLine;
                selectTxt += "    ,(SALDTLSUBA.SALESMONEYTAXEXCRF-SALDTLSUBA.COSTRF) AS A_GROSSPROFITRF" + Environment.NewLine;
                //selectTxt += "    ,(CASE WHEN SALDTLSUBM.M_TOTALSALESCOUNTRF IS NULL THEN 0 ELSE" + Environment.NewLine;  //DEL 郭永祥 2012/03/30 Redmine#29142
                selectTxt += "    ,(CASE WHEN SALDTLSUBM.M_TOTALSALESCOUNTRF IS NULL OR (SALDTLSUBM.M_TOTALSALESCOUNTRF != 0 AND SALDTLSUBM.SALESSLIPCDDTLRF = 2) THEN 0 ELSE" + Environment.NewLine;  //ADD 郭永祥 2012/03/30 Redmine#29142
                selectTxt += "      SALDTLSUBM.M_TOTALSALESCOUNTRF END) AS M_TOTALSALESCOUNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.M_SALESMONEYRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.M_GROSSPROFITRF" + Environment.NewLine;
                // 2011/07/29 >>>
                //selectTxt += "   FROM SALESHISTORYRF AS SALHISSUBA" + Environment.NewLine;
                //selectTxt += "   LEFT JOIN SALESHISTDTLRF SALDTLSUBA" + Environment.NewLine;
                selectTxt += "   FROM SALESHISTORYRF AS SALHISSUBA WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "   LEFT JOIN SALESHISTDTLRF SALDTLSUBA WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += "   ON  SALDTLSUBA.ENTERPRISECODERF=SALHISSUBA.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   AND SALDTLSUBA.ACPTANODRSTATUSRF=SALHISSUBA.ACPTANODRSTATUSRF" + Environment.NewLine;  // ADD 2011/04/21
                selectTxt += "   AND SALDTLSUBA.SALESSLIPNUMRF=SALHISSUBA.SALESSLIPNUMRF" + Environment.NewLine;
                #endregion  //[当期分抽出]

                #region [当月分抽出]
                selectTxt += "   LEFT JOIN" + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                selectTxt += "    SELECT" + Environment.NewLine;
                selectTxt += "      SALHISSUBM2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUBM2.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.SALESSLIPDTLNUMRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUBM2.SALESDATERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUBM2.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.WAREHOUSECODERF" + Environment.NewLine;
                //selectTxt += "     ,SALDTLSUBM2.SECTIONCODERF" + Environment.NewLine;    // DEL 2011/04/21
                selectTxt += "     ,SALHISSUBM2.RESULTSADDUPSECCDRF" + Environment.NewLine;  // ADD 2011/04/21
                selectTxt += "     ,SALDTLSUBM2.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.GOODSNORF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.SHIPMENTCNTRF AS M_TOTALSALESCOUNTRF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.SALESMONEYTAXEXCRF AS M_SALESMONEYRF" + Environment.NewLine;
                selectTxt += "     ,(SALDTLSUBM2.SALESMONEYTAXEXCRF-SALDTLSUBM2.COSTRF) AS M_GROSSPROFITRF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.SALESSLIPCDDTLRF" + Environment.NewLine;//ADD 郭永祥 2012/03/30 Redmine#29142
                // 2011/07/29 >>>
                //selectTxt += "    FROM SALESHISTORYRF AS SALHISSUBM2" + Environment.NewLine;
                //selectTxt += "    LEFT JOIN SALESHISTDTLRF SALDTLSUBM2" + Environment.NewLine;
                selectTxt += "    FROM SALESHISTORYRF AS SALHISSUBM2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "    LEFT JOIN SALESHISTDTLRF SALDTLSUBM2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += "    ON  SALDTLSUBM2.ENTERPRISECODERF=SALHISSUBM2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    AND SALDTLSUBM2.ACPTANODRSTATUSRF=SALHISSUBM2.ACPTANODRSTATUSRF" + Environment.NewLine;  // ADD 2011/04/21
                selectTxt += "    AND SALDTLSUBM2.SALESSLIPNUMRF=SALHISSUBM2.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += MakeWhereString(ref sqlCommand, CndtnWork, "SALHISSUBM2", "SALDTLSUBM2", 0);
                selectTxt += "   ) AS SALDTLSUBM" + Environment.NewLine;
                selectTxt += "   ON  SALDTLSUBM.ENTERPRISECODERF=SALHISSUBA.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   AND SALDTLSUBM.SALESSLIPNUMRF=SALHISSUBA.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "   AND SALDTLSUBM.SALESSLIPDTLNUMRF=SALDTLSUBA.SALESSLIPDTLNUMRF" + Environment.NewLine;
                #endregion  //[当月分抽出]

                //当期分のWHERE句
                selectTxt += MakeWhereString(ref sqlCommand, CndtnWork, "SALHISSUBA", "SALDTLSUBA", 1);

                #endregion  //[当期分を抽出する]
            }
            else
            {
                #region [当月分のみ抽出]
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     SALHISSUBM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,SALHISSUBM.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.SALESSLIPDTLNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALHISSUBM.SALESDATERF" + Environment.NewLine;
                selectTxt += "    ,SALHISSUBM.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.WAREHOUSECODERF" + Environment.NewLine;
                //selectTxt += "    ,SALDTLSUBM.SECTIONCODERF" + Environment.NewLine;  // DEL 2011/04/21
                selectTxt += "    ,SALHISSUBM.RESULTSADDUPSECCDRF" + Environment.NewLine;    // ADD 2011/04/21
                selectTxt += "    ,SALDTLSUBM.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.GOODSNORF" + Environment.NewLine;
                //selectTxt += "    ,(CASE WHEN SALDTLSUBM.SHIPMENTCNTRF IS NULL THEN 0 ELSE" + Environment.NewLine;  //DEL 郭永祥 2012/03/30 Redmine#29142
                selectTxt += "    ,(CASE WHEN SALDTLSUBM.SHIPMENTCNTRF IS NULL OR (SALDTLSUBM.SHIPMENTCNTRF != 0 AND SALDTLSUBM.SALESSLIPCDDTLRF = 2) THEN 0 ELSE" + Environment.NewLine;  //ADD 郭永祥 2012/03/30 Redmine#29142
                selectTxt += "      SALDTLSUBM.SHIPMENTCNTRF END) AS M_TOTALSALESCOUNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.SALESMONEYTAXEXCRF AS M_SALESMONEYRF" + Environment.NewLine;
                selectTxt += "    ,(SALDTLSUBM.SALESMONEYTAXEXCRF-SALDTLSUBM.COSTRF) AS M_GROSSPROFITRF" + Environment.NewLine;
                // 2011/07/29 >>>
                //selectTxt += "   FROM SALESHISTORYRF AS SALHISSUBM" + Environment.NewLine;
                //selectTxt += "   LEFT JOIN SALESHISTDTLRF SALDTLSUBM" + Environment.NewLine;
                selectTxt += "   FROM SALESHISTORYRF AS SALHISSUBM WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "   LEFT JOIN SALESHISTDTLRF SALDTLSUBM WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += "   ON  SALDTLSUBM.ENTERPRISECODERF=SALHISSUBM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   AND SALDTLSUBM.SALESSLIPNUMRF=SALHISSUBM.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += MakeWhereString(ref sqlCommand, CndtnWork, "SALHISSUBM", "SALDTLSUBM", 0);
                #endregion  //[当月分のみ抽出]
            }

            #endregion  //[売上履歴明細データ抽出]

            selectTxt += "  ) AS SALDTLSUB" + Environment.NewLine;

            #region [GROUP BY]
            selectTxt += "  GROUP BY" + Environment.NewLine;
            selectTxt += "    SALDTLSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bWarehouseCode,
                         "   ,SALDTLSUB.WAREHOUSECODERF" + Environment.NewLine);
            selectTxt += IFBy(bCustomerCode,
                         "   ,SALDTLSUB.CUSTOMERCODERF" + Environment.NewLine);
            selectTxt += IFBy(bSectionCode,
                         //"   ,SALDTLSUB.SECTIONCODERF" + Environment.NewLine);  // DEL 2011/04/21
                         "   ,SALDTLSUB.RESULTSADDUPSECCDRF" + Environment.NewLine);  // ADD 2011/04/21
            selectTxt += IFBy(bGoodsMakerCd,
                         "   ,SALDTLSUB.GOODSMAKERCDRF" + Environment.NewLine);
            selectTxt += IFBy(bBLGoodsCode,
                         "   ,SALDTLSUB.BLGOODSCODERF" + Environment.NewLine);
            selectTxt += IFBy(bBLGroupCode,
                         "   ,SALDTLSUB.BLGROUPCODERF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMGroup,
                         "   ,SALDTLSUB.GOODSMGROUPRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsLGroup,
                         "   ,SALDTLSUB.GOODSLGROUPRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsNo,
                         "   ,SALDTLSUB.GOODSNORF" + Environment.NewLine);
            #endregion  //[GROUP BY]

            #endregion  //[データ抽出メインQuery]

            selectTxt += " ) AS SALDTL" + Environment.NewLine;

            #region [JOIN]
            if (bWarehouseCode)
            {
                //倉庫マスタ
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN WAREHOUSERF WARHUS" + Environment.NewLine;
                selectTxt += " LEFT JOIN WAREHOUSERF WARHUS WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  WARHUS.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND WARHUS.WAREHOUSECODERF=SALDTL.WAREHOUSECODERF" + Environment.NewLine;
            }
            if (bCustomerCode)
            {
                //得意先マスタ
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN CUSTOMERRF CUSTMR" + Environment.NewLine;
                selectTxt += " LEFT JOIN CUSTOMERRF CUSTMR WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  CUSTMR.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUSTMR.CUSTOMERCODERF=SALDTL.CUSTOMERCODERF" + Environment.NewLine;
            }
            if (bSectionCode)
            {
                //拠点情報設定マスタ
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  SCINST.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND SCINST.SECTIONCODERF=SALDTL.SECTIONCODERF" + Environment.NewLine;  // DEL 2011/04/21
                selectTxt += " AND SCINST.SECTIONCODERF=SALDTL.RESULTSADDUPSECCDRF" + Environment.NewLine;  // ADD 2011/04/21
            }
            if (bGoodsMakerCd)
            {
                //メーカーマスタ(ユーザー登録分)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN MAKERURF MAKERU" + Environment.NewLine;
                selectTxt += " LEFT JOIN MAKERURF MAKERU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  MAKERU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND MAKERU.GOODSMAKERCDRF=SALDTL.GOODSMAKERCDRF" + Environment.NewLine;
            }
            if (bGoodsMGroup)
            {
                //商品中分類マスタ(ユーザー登録分)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN GOODSGROUPURF GSGRPU" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSGROUPURF GSGRPU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  GSGRPU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GSGRPU.GOODSMGROUPRF=SALDTL.GOODSMGROUPRF" + Environment.NewLine;
            }
            if (bGoodsLGroup)
            {
                //ユーザーガイドマスタ ※商品大分類ガイド名称取得用
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN USERGDBDURF USGDBUL" + Environment.NewLine;
                selectTxt += " LEFT JOIN USERGDBDURF USGDBUL WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  USGDBUL.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND USGDBUL.GUIDECODERF=SALDTL.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += " AND USGDBUL.USERGUIDEDIVCDRF=70" + Environment.NewLine;
            }
            if (bBLGroupCode)
            {
                //BLグループマスタ(ユーザー)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN BLGROUPURF BLGRPU" + Environment.NewLine;
                selectTxt += " LEFT JOIN BLGROUPURF BLGRPU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  BLGRPU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGRPU.BLGROUPCODERF=SALDTL.BLGROUPCODERF" + Environment.NewLine;
            }
            if (bBLGoodsCode)
            {
                //BL商品コードマスタ(ユーザー)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN BLGOODSCDURF BLGCDU" + Environment.NewLine;
                selectTxt += " LEFT JOIN BLGOODSCDURF BLGCDU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  BLGCDU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGCDU.BLGOODSCODERF=SALDTL.BLGOODSCODERF" + Environment.NewLine;
            }
            if (bGoodsNo)
            {
                //商品マスタ(ユーザー)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN GOODSURF GOODSU" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSURF GOODSU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  GOODSU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GOODSU.GOODSMAKERCDRF=SALDTL.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GOODSU.GOODSNORF=SALDTL.GOODSNORF" + Environment.NewLine;
            }
            #endregion  //[JOIN]

            #region [WHERE句]
            selectTxt += " WHERE" + Environment.NewLine;
            selectTxt += " SALDTL.ENTERPRISECODERF=@SALDTLENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@SALDTLENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //出荷指定区分判別
            string sFstNm = "";
            if (CndtnWork.PrintRangeDiv == 0)
                sFstNm = "MONTH";
            else
                sFstNm = "ANNUAL";

            //印刷範囲指定
            if (CndtnWork.PrintRangeSt != -99999999)
            {
                selectTxt += " AND SALDTL." + sFstNm + "TOTALSALESCOUNT>=@TOTALSALESCOUNTST" + Environment.NewLine;
                SqlParameter paraPrintRangeSt = sqlCommand.Parameters.Add("@TOTALSALESCOUNTST", SqlDbType.Int);
                paraPrintRangeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PrintRangeSt);
            }
            if (CndtnWork.PrintRangeEd != 999999999)
            {
                selectTxt += " AND SALDTL." + sFstNm + "TOTALSALESCOUNT<=@TOTALSALESCOUNTED" + Environment.NewLine;
                SqlParameter paraPrintRangeEd = sqlCommand.Parameters.Add("@TOTALSALESCOUNTED", SqlDbType.Int);
                paraPrintRangeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PrintRangeEd);
            }
            #endregion  //[WHERE句]

            #endregion  //[Select文作成]

            return selectTxt;
        }
        #endregion  //[倉庫用 Select文生成処理]

        #region [売上履歴明細データ用 Where句 生成処理]
        /// <summary>
        /// 売上履歴明細データ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <param name="sSALHIS">テーブル名略称：売上履歴データ</param>
        /// <param name="sSALDTL">テーブル名略称：売上履歴明細データ</param>
        /// <param name="iType">対象年月 0:当月 1:当期</param>
        /// <returns>売上履歴明細データ用WHERE句</returns>
        /// <br>Note       : 売上履歴明細データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.02</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork, string sSALHIS, string sSALDTL, int iType)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " " + sSALHIS + ".ENTERPRISECODERF=@" + sSALHIS + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sSALHIS + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //論理削除区分
            retstring += " AND " + sSALDTL + ".LOGICALDELETECODERF=0 " + Environment.NewLine;

            //拠点コード
            if (CndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in CndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    // -- UPD 2011/04/21 ------------------------------->>>
                    //retstring += " AND " + sSALDTL + ".SECTIONCODERF IN (" + sectionCodestr + ") ";
                    retstring += " AND " + sSALHIS + ".RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                    // -- UPD 2011/04/21 -------------------------------<<<
                }
                retstring += Environment.NewLine;
            }

            //売上伝票区分(明細)
            retstring += " AND " + sSALDTL + ".SALESSLIPCDDTLRF IN ( 0, 1, 2 )" + Environment.NewLine;

            //対象年月
            if (iType == 0)
            {
                //当月
                retstring += " AND " + sSALHIS + ".SALESDATERF>=@" + sSALHIS + "SALESDATEST" + Environment.NewLine;
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sSALHIS + "SALESDATEST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.SalesDateSt);

                retstring += " AND " + sSALHIS + ".SALESDATERF<=@" + sSALHIS + "SALESDATEHED" + Environment.NewLine;
                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sSALHIS + "SALESDATEHED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.SalesDateEd);

                // -- ADD 2011/04/21 -------------------------------------------------->>>
                //売上履歴明細データも日付を指定する。
                retstring += " AND " + sSALDTL + ".SALESDATERF>=@" + sSALHIS + "SALESDATEST" + Environment.NewLine;

                retstring += " AND " + sSALDTL + ".SALESDATERF<=@" + sSALHIS + "SALESDATEHED" + Environment.NewLine;
                // -- ADD 2011/04/21 --------------------------------------------------<<<
            }
            else
            {
                //当期
                retstring += " AND " + sSALHIS + ".SALESDATERF>=@" + sSALHIS + "SALESDATEST" + Environment.NewLine;
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sSALHIS + "SALESDATEST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.AnnualSalesDateSt);

                retstring += " AND " + sSALHIS + ".SALESDATERF<=@" + sSALHIS + "SALESDATEHED" + Environment.NewLine;
                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sSALHIS + "SALESDATEHED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.AnnualSalesDateEd);

                // -- ADD 2011/04/21 -------------------------------------------------->>>
                //売上履歴明細データも日付を指定する。
                retstring += " AND " + sSALDTL + ".SALESDATERF>=@" + sSALHIS + "SALESDATEST" + Environment.NewLine;

                retstring += " AND " + sSALDTL + ".SALESDATERF<=@" + sSALHIS + "SALESDATEHED" + Environment.NewLine;
                // -- ADD 2011/04/21 --------------------------------------------------<<<
            }

            //倉庫コード
            if (CndtnWork.WarehouseCodeSt != "")
            {
                retstring += " AND " + sSALDTL + ".WAREHOUSECODERF>=@" + sSALDTL + "WAREHOUSECODEST" + Environment.NewLine;
                SqlParameter paraWarehouseCodeSt = sqlCommand.Parameters.Add("@" + sSALDTL + "WAREHOUSECODEST", SqlDbType.NChar);
                paraWarehouseCodeSt.Value = SqlDataMediator.SqlSetString(CndtnWork.WarehouseCodeSt);
            }
            if (CndtnWork.WarehouseCodeEd != "")
            {
                retstring += " AND " + sSALDTL + ".WAREHOUSECODERF<=@" + sSALDTL + "WAREHOUSECODEED" + Environment.NewLine;
                SqlParameter paraWarehouseCodeEd = sqlCommand.Parameters.Add("@" + sSALDTL + "WAREHOUSECODEED", SqlDbType.NChar);
                paraWarehouseCodeEd.Value = SqlDataMediator.SqlSetString(CndtnWork.WarehouseCodeEd);
            }

            // 2010/01/07 Add >>>
            retstring += " AND " + sSALDTL + ".WAREHOUSECODERF<>0" + Environment.NewLine;
            // 2010/01/07 Add <<<

            //得意先コード
            if (CndtnWork.CustomerCodeSt != 0)
            {
                retstring += " AND " + sSALHIS + ".CUSTOMERCODERF>=@" + sSALHIS + "CUSTOMERCODEST" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@" + sSALHIS + "CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CustomerCodeSt);
            }
            // -- UPD 2011/04/21 ------------------------------->>>
            //if (CndtnWork.CustomerCodeEd != 999999999)
            if (CndtnWork.CustomerCodeEd != 99999999)
            // -- UPD 2011/04/21 -------------------------------<<<
            {
                retstring += " AND " + sSALHIS + ".CUSTOMERCODERF<=@" + sSALHIS + "CUSTOMERCODEED" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@" + sSALHIS + "CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CustomerCodeEd);
            }

            //商品メーカーコード
            if (CndtnWork.GoodsMakerCdSt != 0)
            {
                retstring += " AND " + sSALDTL + ".GOODSMAKERCDRF>=@" + sSALDTL + "GOODSMAKERCDST" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@" + sSALDTL + "GOODSMAKERCDST", SqlDbType.Int);
                paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMakerCdSt);
            }
            // -- UPD 2011/04/21 ---------------------------->>>
            //if (CndtnWork.GoodsMakerCdEd != 999999)
            if (CndtnWork.GoodsMakerCdEd != 9999)
            // -- UPD 2011/04/21 ----------------------------<<<
            {
                retstring += " AND " + sSALDTL + ".GOODSMAKERCDRF<=@" + sSALDTL + "GOODSMAKERCDED" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@" + sSALDTL + "GOODSMAKERCDED", SqlDbType.Int);
                paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMakerCdEd);
            }

            //BL商品コード
            if (CndtnWork.BLGoodsCodeSt != 0)
            {
                retstring += " AND " + sSALDTL + ".BLGOODSCODERF>=@" + sSALDTL + "BLGOODSCODEST" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@" + sSALDTL + "BLGOODSCODEST", SqlDbType.Int);
                paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeSt);
            }
            // -- UPD 2011/04/24 -------------------------->>>
            //if (CndtnWork.BLGoodsCodeEd != 99999999)
            if (CndtnWork.BLGoodsCodeEd != 99999)
            // -- UPD 2011/04/24 --------------------------<<<
            {
                retstring += " AND " + sSALDTL + ".BLGOODSCODERF<=@" + sSALDTL + "BLGOODSCODEED" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@" + sSALDTL + "BLGOODSCODEED", SqlDbType.Int);
                paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeEd);
            }

            //商品番号
            if (CndtnWork.GoodsNoSt != "")
            {
                retstring += " AND " + sSALDTL + ".GOODSNORF>=@" + sSALDTL + "GOODSNOST" + Environment.NewLine;
                SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@" + sSALDTL + "GOODSNOST", SqlDbType.NVarChar);
                paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoSt);
            }
            if (CndtnWork.GoodsNoEd != "")
            {
                retstring += " AND " + sSALDTL + ".GOODSNORF<=@" + sSALDTL + "GOODSNOED" + Environment.NewLine;
                SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@" + sSALDTL + "GOODSNOED", SqlDbType.NVarChar);
                paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoEd);
            }

            //BLグループコード
            if (CndtnWork.BLGroupCodeSt != 0)
            {
                retstring += " AND " + sSALDTL + ".BLGROUPCODERF>=@" + sSALDTL + "BLGROUPCODEST" + Environment.NewLine;
                SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@" + sSALDTL + "BLGROUPCODEST", SqlDbType.Int);
                paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeSt);
            }
            if (CndtnWork.BLGroupCodeEd != 99999)
            {
                retstring += " AND ( " + sSALDTL + ".BLGROUPCODERF<=@" + sSALDTL + "BLGROUPCODEED OR " + sSALDTL + ".BLGROUPCODERF IS NULL )" + Environment.NewLine;
                SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@" + sSALDTL + "BLGROUPCODEED", SqlDbType.Int);
                paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeEd);
            }

            //開始商品大分類コード
            if (CndtnWork.GoodsLGroupSt != 0)
            {
                retstring += " AND " + sSALDTL + ".GOODSLGROUPRF>=@" + sSALDTL + "GOODSLGROUPST" + Environment.NewLine;
                SqlParameter paraGoodsLGroupSt = sqlCommand.Parameters.Add("@" + sSALDTL + "GOODSLGROUPST", SqlDbType.Int);
                paraGoodsLGroupSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsLGroupSt);
            }
            if (CndtnWork.GoodsLGroupEd != 9999)
            {
                retstring += " AND ( " + sSALDTL + ".GOODSLGROUPRF<=@" + sSALDTL + "GOODSLGROUPED OR " + sSALDTL + ".GOODSLGROUPRF IS NULL)" + Environment.NewLine;
                SqlParameter paraGoodsLGroupEd = sqlCommand.Parameters.Add("@" + sSALDTL + "GOODSLGROUPED", SqlDbType.Int);
                paraGoodsLGroupEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsLGroupEd);
            }

            //開始商品中分類コード
            if (CndtnWork.GoodsMGroupSt != 0)
            {
                retstring += " AND " + sSALDTL + ".GOODSMGROUPRF>=@" + sSALDTL + "GOODSMGROUPST" + Environment.NewLine;
                SqlParameter paraGoodsMGroupSt = sqlCommand.Parameters.Add("@" + sSALDTL + "GOODSMGROUPST", SqlDbType.Int);
                paraGoodsMGroupSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMGroupSt);
            }
            if (CndtnWork.GoodsMGroupEd != 9999)
            {
                retstring += " AND ( " + sSALDTL + ".GOODSMGROUPRF<=@" + sSALDTL + "GOODSMGROUPED OR " + sSALDTL + ".GOODSMGROUPRF IS NULL)" + Environment.NewLine;
                SqlParameter paraGoodsMGroupEd = sqlCommand.Parameters.Add("@" + sSALDTL + "GOODSMGROUPED", SqlDbType.Int);
                paraGoodsMGroupEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMGroupEd);
            }
            #endregion  //WHERE文作成

            return retstring;
        }
        #endregion  //[売上履歴明細データ用 Where句 生成処理]

        #region [CopyToSalesRsltListResultWorkFromReader処理 呼出]
        /// <summary>
        /// クラス格納処理 Reader → CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CopyToSalesRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.02</br>
        /// </remarks>
        public SalesRsltListResultWork CopyToSalesRsltListResultWorkFromReader(ref SqlDataReader myReader, SalesRsltListCndtnWork CndtnWork)
        {
            return this.CopyToSalesRsltListResultWorkFromReaderProc(ref myReader, CndtnWork);
        }
        #endregion  //[CopyToSalesRsltListResultWorkFromReader処理 呼出]

        #region [CopyToSalesRsltListResultWorkFromReader処理]
        /// <summary>
        /// クラス格納処理 Reader → CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CopyToSalesRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.02</br>
        /// <br>Update Note: 2009.04.28 張莉莉</br>
        /// <br>            ・メーカー略称==>メーカー名称
        /// </remarks>
        private SalesRsltListResultWork CopyToSalesRsltListResultWorkFromReaderProc(ref SqlDataReader myReader, SalesRsltListCndtnWork CndtnWork)
        {
            #region [判別用フラグ]
            //拠点コード
            if (((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.TtlType == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.TtlType == 1) && (CndtnWork.Detail != 7)))
            {
                bSectionCode = true;
            }

            //倉庫コード
            if (((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 0)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 4)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 5)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 6)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 0)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 4)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 5)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 6)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 7)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 0)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 4)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 5)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 6)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 7)))
            {
                bWarehouseCode = true;
            }

            //得意先コード
            if (((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 0)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 4)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 5)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 6)))
            {
                bCustomerCode = true;
            }

            //商品番号
            if (CndtnWork.Detail == 0)
            {
                bGoodsNo = true;
            }

            //商品メーカーコード
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 5) ||
                ((CndtnWork.MakerPrintDiv == 1) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.MakerPrintDiv == 1) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.MakerPrintDiv == 1) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.MakerPrintDiv == 1) && (CndtnWork.Detail == 4)))
            {
                bGoodsMakerCd = true;
            }

            //BL商品コード
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1))
            {
                bBLGoodsCode = true;
            }

            //BLグループコード
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1) ||
                (CndtnWork.Detail == 2))
            {
                bBLGroupCode = true;
            }

            //商品中分類コード
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1) ||
                (CndtnWork.Detail == 2) ||
                (CndtnWork.Detail == 3))
            {
                bGoodsMGroup = true;
            }

            //商品大分類コード
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1) ||
                (CndtnWork.Detail == 2) ||
                (CndtnWork.Detail == 3) ||
                (CndtnWork.Detail == 4))
            {
                bGoodsLGroup = true;
            }

            //当期印刷
            if (CndtnWork.AnnualPrintDiv == 1)
            {
                bAnnual = true;
            }
            #endregion  //[判別用フラグ]

            #region [抽出結果-値セット]
            SalesRsltListResultWork ResultWork = new SalesRsltListResultWork();

            if (bWarehouseCode)
            {
                ResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                ResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            }
            if (bCustomerCode)
            {
                ResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                ResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            }
            if (bSectionCode)
            {
                //ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // DEL 2011/04/21
                ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));  // ADD 2011/04/21
                ResultWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            }
            if (bGoodsMakerCd)
            {
                ResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                ResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));  // Update 2009/04/28
            }
            if (bGoodsLGroup)
            {
                ResultWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                ResultWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAME"));
            }
            if (bGoodsMGroup)
            {
                ResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                ResultWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
            }
            if (bBLGroupCode)
            {
                ResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                ResultWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
            }
            if (bBLGoodsCode)
            {
                ResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                ResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            }
            if (bGoodsNo)
            {
                ResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                ResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            }

            //当月
            ResultWork.MonthTotalSalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHTOTALSALESCOUNT"));
            ResultWork.MonthSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESMONEY"));
            ResultWork.MonthGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHGROSSPROFIT"));
            //当期
            if (bAnnual)
            {
                ResultWork.AnnualTotalSalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANNUALTOTALSALESCOUNT"));
                ResultWork.AnnualSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALSALESMONEY"));
                ResultWork.AnnualGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALGROSSPROFIT"));
            }
            #endregion  //[抽出結果-値セット]

            return ResultWork;
        }
        #endregion //[CopyToSalesRsltListResultWorkFromReader処理]
    }
}

