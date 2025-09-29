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
    class MTtlSaSlipEmp : MTtlSaSlipBase, IMTtlSaSlip
    {
        #region [判別用フラグ宣言]
        private bool bAddUpSecCode = false;  //計上拠点コード
        private bool bEmployeeCode = false;  //従業員コード
        private bool bGoodsMakerCd = false;  //商品メーカーコード
        private bool bBLGoodsCode = false;   //BL商品コード
        private bool bGoodsNo = false;       //商品番号
        private bool bBLGroupCode = false;   //BLグループコード
        private bool bGoodsMGroup = false;   //商品中分類コード
        private bool bGoodsLGroup = false;   //商品大分類コード
        #endregion  //[判別用フラグ宣言]

        #region [担当者別用 Select文]
        /// <summary>
        /// 担当者別用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>担当者別用SELECT文</returns>
        /// <br>Note       : 担当者別用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.02</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, CndtnWork);
        }
        #endregion  //[担当者別用 Select文]

        #region [担当者別用 Select文生成処理]
        /// <summary>
        /// 担当者別用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>担当者別用SELECT文</returns>
        /// <br>Note       : 担当者別用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.02</br>
        /// <br>Update Note: 2009.04.28 張莉莉</br>
        /// <br>            ・メーカー略称==>メーカー名称
        /// <br>Update Note: 2010/05/13 長内数馬</br>
        /// <br>            ・品名の取得方法を変更
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork)
        {
            #region [判別用フラグ]
            //計上拠点コード
            if (CndtnWork.TtlType == 1)
            {
                bAddUpSecCode = true;
            }

            //従業員コード
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1) ||
                (CndtnWork.Detail == 2) ||
                (CndtnWork.Detail == 3) ||
                (CndtnWork.Detail == 4) ||
                (CndtnWork.Detail == 5) ||
                (CndtnWork.Detail == 6))
            {
                bEmployeeCode = true;
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
            #endregion  //[判別用フラグ]

            string selectTxt = "";

            // 対象テーブル
            // GOODSMTTLSASLIPRF GSMSLP 商品別売上月次集計データ
            // GOODSURF          GOODSU 商品マスタ(ユーザー)
            // BLGOODSCDURF      BLGCDU BL商品コードマスタ(ユーザー)
            // BLGROUPURF        BLGRPU BLグループマスタ(ユーザー)
            // MAKERURF          MAKERU メーカーマスタ(ユーザー登録分)
            // USERGDBDURF       USGDBU ユーザーガイドマスタ(ボディ)(ユーザ変更分)
            // SECINFOSETRF      SCINST 拠点情報設定マスタ
            // EMPLOYEERF        EMPLYE 従業員マスタ
            // GOODSGROUPURF     GSGRPU 商品中分類マスタ(ユーザー登録分)

            #region [Select文作成]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bEmployeeCode,
                         " ,GSMSLP.EMPLOYEECODERF" + Environment.NewLine);
            selectTxt += IFBy(bEmployeeCode,
                         " ,EMPLYE.NAMERF" + Environment.NewLine);
            selectTxt += IFBy(bAddUpSecCode,
                         " ,GSMSLP.ADDUPSECCODERF" + Environment.NewLine);
            selectTxt += IFBy(bAddUpSecCode,
                         " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMakerCd,
                         " ,GSMSLP.GOODSMAKERCDRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMakerCd,
                         " ,MAKERU.MAKERNAMERF" + Environment.NewLine); // Update 2009/04/28
            selectTxt += IFBy(bBLGoodsCode,
                         " ,GSMSLP.BLGOODSCODERF" + Environment.NewLine);
            selectTxt += IFBy(bBLGoodsCode,
                         " ,BLGCDU.BLGOODSHALFNAMERF" + Environment.NewLine);
            selectTxt += IFBy(bBLGroupCode,
                         " ,GSMSLP.BLGROUPCODERF" + Environment.NewLine);
            selectTxt += IFBy(bBLGroupCode,
                         " ,BLGRPU.BLGROUPKANANAMERF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMGroup,
                         " ,GSMSLP.GOODSMGROUPRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMGroup,
                         " ,GSGRPU.GOODSMGROUPNAMERF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsLGroup,
                         " ,GSMSLP.GOODSLGROUPRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsLGroup,
                         " ,USGDBUL.GUIDENAMERF AS GOODSLGROUPNAME" + Environment.NewLine);
            selectTxt += IFBy(bGoodsNo,
                         " ,GSMSLP.GOODSNORF" + Environment.NewLine);
            // -- UPD 2010/05/13 ------------------------------------------>>>
            //selectTxt += IFBy(bGoodsNo,
            //             " ,GOODSU.GOODSNAMEKANARF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsNo,
                         " ,(CASE WHEN GOODSU.GOODSNAMEKANARF IS NULL THEN GSMSLP2.GOODSNAMEKANARF ELSE GOODSU.GOODSNAMEKANARF END) AS GOODSNAMEKANARF" + Environment.NewLine);
            // -- UPD 2010/05/13 ------------------------------------------<<<
            //当月
            selectTxt += " ,GSMSLP.MONTHTOTALSALESCOUNT" + Environment.NewLine;
            selectTxt += " ,GSMSLP.MONTHSALESMONEY" + Environment.NewLine;
            selectTxt += " ,GSMSLP.MONTHSALESRETGOODSPRICE" + Environment.NewLine;
            selectTxt += " ,GSMSLP.MONTHDISCOUNTPRICE" + Environment.NewLine;
            selectTxt += " ,GSMSLP.MONTHGROSSPROFIT" + Environment.NewLine;
            //当期
            selectTxt += " ,GSMSLP.ANNUALTOTALSALESCOUNT" + Environment.NewLine;
            selectTxt += " ,GSMSLP.ANNUALSALESMONEY" + Environment.NewLine;
            selectTxt += " ,GSMSLP.ANNUALSALESRETGOODSPRICE" + Environment.NewLine;
            selectTxt += " ,GSMSLP.ANNUALDISCOUNTPRICE" + Environment.NewLine;
            selectTxt += " ,GSMSLP.ANNUALGROSSPROFIT" + Environment.NewLine;
            //FROM
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            #region [データ抽出メインQuery]
            //在庫取寄せ区分で変わる項目を動的生成
            if (CndtnWork.RsltTtlDivCd == (int)RsltTtlDivCd.Order)
            {
                #region [取寄せの場合]

                #region [合計分抽出]
                selectTxt += "  SELECT" + Environment.NewLine;
                selectTxt += "    GSMSLPP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bEmployeeCode,
                             "   ,GSMSLPP.EMPLOYEECODERF" + Environment.NewLine);
                selectTxt += IFBy(bAddUpSecCode,
                             "   ,GSMSLPP.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsMakerCd,
                             "   ,GSMSLPP.GOODSMAKERCDRF" + Environment.NewLine);
                selectTxt += IFBy(bBLGoodsCode,
                             "   ,GSMSLPP.BLGOODSCODERF" + Environment.NewLine);
                selectTxt += IFBy(bBLGroupCode,
                             "   ,GSMSLPP.BLGROUPCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsMGroup,
                             "   ,GSMSLPP.GOODSMGROUPRF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsLGroup,
                             "   ,GSMSLPP.GOODSLGROUPRF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsNo,
                             "   ,GSMSLPP.GOODSNORF" + Environment.NewLine);
                //当月
                selectTxt += "   ,(CASE WHEN GSMSLPP.MONTHTOTALSALESCOUNT<>0 THEN (CASE WHEN GSMSLPS.MONTHTOTALSALESCOUNT<>0 THEN (GSMSLPP.MONTHTOTALSALESCOUNT-GSMSLPS.MONTHTOTALSALESCOUNT) ELSE GSMSLPP.MONTHTOTALSALESCOUNT END) ELSE 0 END) AS MONTHTOTALSALESCOUNT" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.MONTHSALESMONEY<>0 THEN (CASE WHEN GSMSLPS.MONTHSALESMONEY<>0 THEN (GSMSLPP.MONTHSALESMONEY-GSMSLPS.MONTHSALESMONEY) ELSE GSMSLPP.MONTHSALESMONEY END) ELSE 0 END) AS MONTHSALESMONEY" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.MONTHSALESRETGOODSPRICE<>0 THEN (CASE WHEN GSMSLPS.MONTHSALESRETGOODSPRICE<>0 THEN (GSMSLPP.MONTHSALESRETGOODSPRICE-GSMSLPS.MONTHSALESRETGOODSPRICE) ELSE GSMSLPP.MONTHSALESRETGOODSPRICE END) ELSE 0 END) AS MONTHSALESRETGOODSPRICE" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.MONTHDISCOUNTPRICE<>0 THEN (CASE WHEN GSMSLPS.MONTHDISCOUNTPRICE<>0 THEN (GSMSLPP.MONTHDISCOUNTPRICE-GSMSLPS.MONTHDISCOUNTPRICE) ELSE GSMSLPP.MONTHDISCOUNTPRICE END) ELSE 0 END) AS MONTHDISCOUNTPRICE" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.MONTHGROSSPROFIT<>0 THEN (CASE WHEN GSMSLPS.MONTHGROSSPROFIT<>0 THEN (GSMSLPP.MONTHGROSSPROFIT-GSMSLPS.MONTHGROSSPROFIT) ELSE GSMSLPP.MONTHGROSSPROFIT END) ELSE 0 END) AS MONTHGROSSPROFIT" + Environment.NewLine;
                //当期
                selectTxt += "   ,(CASE WHEN GSMSLPP.ANNUALTOTALSALESCOUNT<>0 THEN (CASE WHEN GSMSLPS.ANNUALTOTALSALESCOUNT<>0 THEN (GSMSLPP.ANNUALTOTALSALESCOUNT-GSMSLPS.ANNUALTOTALSALESCOUNT) ELSE GSMSLPP.ANNUALTOTALSALESCOUNT END) ELSE 0 END) AS ANNUALTOTALSALESCOUNT" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.ANNUALSALESMONEY<>0 THEN (CASE WHEN GSMSLPS.ANNUALSALESMONEY<>0 THEN (GSMSLPP.ANNUALSALESMONEY-GSMSLPS.ANNUALSALESMONEY) ELSE GSMSLPP.ANNUALSALESMONEY END) ELSE 0 END) AS ANNUALSALESMONEY" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.ANNUALSALESRETGOODSPRICE<>0 THEN (CASE WHEN GSMSLPS.ANNUALSALESRETGOODSPRICE<>0 THEN (GSMSLPP.ANNUALSALESRETGOODSPRICE-GSMSLPS.ANNUALSALESRETGOODSPRICE) ELSE GSMSLPP.ANNUALSALESRETGOODSPRICE END) ELSE 0 END) AS ANNUALSALESRETGOODSPRICE" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.ANNUALDISCOUNTPRICE<>0 THEN (CASE WHEN GSMSLPS.ANNUALDISCOUNTPRICE<>0 THEN (GSMSLPP.ANNUALDISCOUNTPRICE-GSMSLPS.ANNUALDISCOUNTPRICE) ELSE GSMSLPP.ANNUALDISCOUNTPRICE END) ELSE 0 END) AS ANNUALDISCOUNTPRICE" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.ANNUALGROSSPROFIT<>0 THEN (CASE WHEN GSMSLPS.ANNUALGROSSPROFIT<>0 THEN (GSMSLPP.ANNUALGROSSPROFIT-GSMSLPS.ANNUALGROSSPROFIT) ELSE GSMSLPP.ANNUALGROSSPROFIT END) ELSE 0 END) AS ANNUALGROSSPROFIT" + Environment.NewLine;
                selectTxt += "  FROM" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                //合計分抽出サブQuery
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPPSUB", (int)RsltTtlDivCd.PrtTtl);
                selectTxt += "  ) AS GSMSLPP" + Environment.NewLine;
                #endregion  //[合計分抽出]

                #region [在庫分抽出]
                selectTxt += "  LEFT JOIN" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     GSMSLPSSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bEmployeeCode,
                             "    ,GSMSLPSSUB.EMPLOYEECODERF" + Environment.NewLine);
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,GSMSLPSSUB.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsMakerCd,
                             "    ,GSMSLPSSUB.GOODSMAKERCDRF" + Environment.NewLine);
                selectTxt += IFBy(bBLGoodsCode,
                             "    ,GSMSLPSSUB.BLGOODSCODERF" + Environment.NewLine);
                // 2010/01/13 >>>
                //selectTxt += IFBy(bBLGroupCode,
                //             "    ,GSMSLPSSUB.BLGROUPCODERF" + Environment.NewLine);
                //selectTxt += IFBy(bGoodsMGroup,
                //             "    ,GSMSLPSSUB.GOODSMGROUPRF" + Environment.NewLine);
                //selectTxt += IFBy(bGoodsLGroup,
                //             "    ,GSMSLPSSUB.GOODSLGROUPRF" + Environment.NewLine);
                selectTxt += IFBy(bBLGroupCode,
                             "    ,(CASE WHEN GSMSLPSSUB.BLGROUPCODERF IS NULL THEN 0 ELSE GSMSLPSSUB.BLGROUPCODERF END) AS BLGROUPCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsMGroup,
                             "    ,(CASE WHEN GSMSLPSSUB.GOODSMGROUPRF IS NULL THEN 0 ELSE GSMSLPSSUB.GOODSMGROUPRF END) AS GOODSMGROUPRF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsLGroup,
                             "    ,(CASE WHEN GSMSLPSSUB.GOODSLGROUPRF IS NULL THEN 0 ELSE GSMSLPSSUB.GOODSLGROUPRF END) AS GOODSLGROUPRF" + Environment.NewLine);
                // 2010/01/13 <<<
                selectTxt += IFBy(bGoodsNo,
                             "    ,GSMSLPSSUB.GOODSNORF" + Environment.NewLine);
                //当月
                selectTxt += "    ,GSMSLPSSUB.MONTHTOTALSALESCOUNT" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.MONTHSALESMONEY" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.MONTHSALESRETGOODSPRICE" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.MONTHDISCOUNTPRICE" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.MONTHGROSSPROFIT" + Environment.NewLine;
                //当期
                selectTxt += "    ,GSMSLPSSUB.ANNUALTOTALSALESCOUNT" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.ANNUALSALESMONEY" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.ANNUALSALESRETGOODSPRICE" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.ANNUALDISCOUNTPRICE" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.ANNUALGROSSPROFIT" + Environment.NewLine;
                selectTxt += "   FROM" + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                //在庫分抽出サブQuery
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPSSUB2", (int)RsltTtlDivCd.Stock);
                selectTxt += "   ) AS GSMSLPSSUB" + Environment.NewLine;
                selectTxt += "  ) AS GSMSLPS" + Environment.NewLine;
                selectTxt += "  ON  GSMSLPS.ENTERPRISECODERF=GSMSLPP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bEmployeeCode,
                             "  AND GSMSLPS.EMPLOYEECODERF=GSMSLPP.EMPLOYEECODERF" + Environment.NewLine);
                selectTxt += IFBy(bAddUpSecCode,
                             "  AND GSMSLPS.ADDUPSECCODERF=GSMSLPP.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsMakerCd,
                             "  AND GSMSLPS.GOODSMAKERCDRF=GSMSLPP.GOODSMAKERCDRF" + Environment.NewLine);
                selectTxt += IFBy(bBLGoodsCode,
                             "  AND GSMSLPS.BLGOODSCODERF=GSMSLPP.BLGOODSCODERF" + Environment.NewLine);
                selectTxt += IFBy(bBLGroupCode,
                             "  AND GSMSLPS.BLGROUPCODERF=GSMSLPP.BLGROUPCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsMGroup,
                             "  AND GSMSLPS.GOODSMGROUPRF=GSMSLPP.GOODSMGROUPRF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsLGroup,
                             "  AND GSMSLPS.GOODSLGROUPRF=GSMSLPP.GOODSLGROUPRF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsNo,
                             "  AND GSMSLPS.GOODSNORF=GSMSLPP.GOODSNORF" + Environment.NewLine);
                #endregion  //[在庫分抽出]

                #endregion  //[取寄せの場合]
            }
            else
            {
                //合計or在庫の場合
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPSUB", CndtnWork.RsltTtlDivCd);
            }
            #endregion  //[データ抽出メインQuery]

            selectTxt += " ) AS GSMSLP" + Environment.NewLine;

            #region [JOIN]
            if (bEmployeeCode)
            {
                //従業員マスタ
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN EMPLOYEERF EMPLYE" + Environment.NewLine;
                selectTxt += " LEFT JOIN EMPLOYEERF EMPLYE WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  EMPLYE.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND EMPLYE.EMPLOYEECODERF=GSMSLP.EMPLOYEECODERF" + Environment.NewLine;
            }
            if (bAddUpSecCode)
            {
                //拠点情報設定マスタ
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  SCINST.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SCINST.SECTIONCODERF=GSMSLP.ADDUPSECCODERF" + Environment.NewLine;
            }
            if (bGoodsMakerCd)
            {
                //メーカーマスタ(ユーザー登録分)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN MAKERURF MAKERU" + Environment.NewLine;
                selectTxt += " LEFT JOIN MAKERURF MAKERU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  MAKERU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND MAKERU.GOODSMAKERCDRF=GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;
            }
            if (bGoodsMGroup)
            {
                //商品中分類マスタ(ユーザー登録分)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN GOODSGROUPURF GSGRPU" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSGROUPURF GSGRPU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  GSGRPU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GSGRPU.GOODSMGROUPRF=GSMSLP.GOODSMGROUPRF" + Environment.NewLine;
            }
            if (bGoodsLGroup)
            {
                //ユーザーガイドマスタ ※商品大分類ガイド名称取得用
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN USERGDBDURF USGDBUL" + Environment.NewLine;
                selectTxt += " LEFT JOIN USERGDBDURF USGDBUL WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  USGDBUL.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND USGDBUL.GUIDECODERF=GSMSLP.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += " AND USGDBUL.USERGUIDEDIVCDRF=70" + Environment.NewLine;
            }
            if (bBLGroupCode)
            {
                //BLグループマスタ(ユーザー)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN BLGROUPURF BLGRPU" + Environment.NewLine;
                selectTxt += " LEFT JOIN BLGROUPURF BLGRPU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  BLGRPU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGRPU.BLGROUPCODERF=GSMSLP.BLGROUPCODERF" + Environment.NewLine;
            }
            if (bBLGoodsCode)
            {
                //BL商品コードマスタ(ユーザー)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN BLGOODSCDURF BLGCDU" + Environment.NewLine;
                selectTxt += " LEFT JOIN BLGOODSCDURF BLGCDU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  BLGCDU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGCDU.BLGOODSCODERF=GSMSLP.BLGOODSCODERF" + Environment.NewLine;
            }
            if ((bGoodsNo))
            {
                //商品マスタ(ユーザー)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN GOODSURF GOODSU" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSURF GOODSU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  GOODSU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GOODSU.GOODSMAKERCDRF=GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GOODSU.GOODSNORF=GSMSLP.GOODSNORF" + Environment.NewLine;

                //-- ADD 2010/05/13 -------------------------------------------->>>
                selectTxt += " LEFT JOIN " + Environment.NewLine;
                selectTxt += " ( " + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "      ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     ,GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "     ,GOODSNORF" + Environment.NewLine;
                selectTxt += "     ,MAX(GOODSNAMEKANARF) AS GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "   FROM" + Environment.NewLine;
                // 2011/07/29 >>>
                //selectTxt += "     GOODSMTTLSASLIPRF" + Environment.NewLine;
                selectTxt += "     GOODSMTTLSASLIPRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += "   WHERE" + Environment.NewLine;
                selectTxt += "         ENTERPRISECODERF=@GSMSLP2ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     AND ADDUPYEARMONTHRF>=@GSMSLP2ADDUPYEARMONTHST" + Environment.NewLine;
                selectTxt += "     AND ADDUPYEARMONTHRF<=@GSMSLP2ADDUPYEARMONTHED" + Environment.NewLine;
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "      ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     ,GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "     ,GOODSNORF" + Environment.NewLine;
                selectTxt += " ) AS GSMSLP2 " + Environment.NewLine;
                selectTxt += " ON  GSMSLP2.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GSMSLP2.GOODSMAKERCDRF=GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GSMSLP2.GOODSNORF=GSMSLP.GOODSNORF" + Environment.NewLine;

                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@GSMSLP2ENTERPRISECODERF", SqlDbType.NChar);
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@GSMSLP2ADDUPYEARMONTHST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AnnualAddUpYearMonthSt);

                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@GSMSLP2ADDUPYEARMONTHED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AnnualAddUpYaerMonthEd);
                //-- ADD 2010/05/13 --------------------------------------------<<<
            }
            #endregion  //[JOIN]

            #region [WHERE句]
            selectTxt += " WHERE" + Environment.NewLine;
            selectTxt += " GSMSLP.ENTERPRISECODERF=@GSMSLPENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@GSMSLPENTERPRISECODE", SqlDbType.NChar);
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
                selectTxt += " AND GSMSLP." + sFstNm + "TOTALSALESCOUNT>=@TOTALSALESCOUNTST" + Environment.NewLine;
                SqlParameter paraPrintRangeSt = sqlCommand.Parameters.Add("@TOTALSALESCOUNTST", SqlDbType.Int);
                paraPrintRangeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PrintRangeSt);
            }
            if (CndtnWork.PrintRangeEd != 999999999)
            {
                selectTxt += " AND GSMSLP." + sFstNm + "TOTALSALESCOUNT<=@TOTALSALESCOUNTED" + Environment.NewLine;
                SqlParameter paraPrintRangeEd = sqlCommand.Parameters.Add("@TOTALSALESCOUNTED", SqlDbType.Int);
                paraPrintRangeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PrintRangeEd);
            }
            #endregion  //[WHERE句]

            #endregion  //[Select文作成]

            return selectTxt;
        }
        #endregion  //[得意先別用 Select文生成処理]

        #region [商品別売上月次集計データ用 SubQuery生成処理]
        /// <summary>
        /// 商品別売上月次集計データ用 SubQuery生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <param name="sTblNm">テーブル略称</param>
        /// <param name="iRsltTtlDivCd">在庫取寄せ区分</param>
        /// <returns>商品別売上月次集計データ用SELECT文</returns>
        /// <br>Note       : 商品別売上月次集計データ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.02</br>
        private string MakeSubQueryString(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork, string sTblNm, int iRsltTtlDivCd)
        {
            string retstring = "";

            #region [商品別売上月次集計データ抽出Query]
            retstring += " SELECT" + Environment.NewLine;
            retstring += "   " + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += IFBy(bEmployeeCode,
                         "  ," + sTblNm + ".EMPLOYEECODERF" + Environment.NewLine);
            retstring += IFBy(bAddUpSecCode,
                         "  ," + sTblNm + ".ADDUPSECCODERF" + Environment.NewLine);
            retstring += IFBy(bGoodsMakerCd,
                         "  ," + sTblNm + ".GOODSMAKERCDRF" + Environment.NewLine);
            retstring += IFBy(bBLGoodsCode,
                         "  ," + sTblNm + ".BLGOODSCODERF" + Environment.NewLine);
            // 2010/01/13 Add >>>
            if (sTblNm == "GSMSLPPSUB")
            {
                retstring += IFBy(bBLGroupCode,
                             "  ,(CASE WHEN " + sTblNm + ".BLGROUPCODERF IS NULL THEN 0 ELSE " + sTblNm + ".BLGROUPCODERF END) AS BLGROUPCODERF" + Environment.NewLine);
                retstring += IFBy(bGoodsMGroup,
                             "  ,(CASE WHEN " + sTblNm + ".GOODSMGROUPRF IS NULL THEN 0 ELSE " + sTblNm + ".GOODSMGROUPRF END) AS GOODSMGROUPRF" + Environment.NewLine);
                retstring += IFBy(bGoodsLGroup,
                             "  ,(CASE WHEN " + sTblNm + ".GOODSLGROUPRF IS NULL THEN 0 ELSE " + sTblNm + ".GOODSLGROUPRF END) AS GOODSLGROUPRF" + Environment.NewLine);
            }
            else
            {
            // 2010/01/13 Add <<<
                retstring += IFBy(bBLGroupCode,
                             "  ," + sTblNm + ".BLGROUPCODERF" + Environment.NewLine);
                retstring += IFBy(bGoodsMGroup,
                             "  ," + sTblNm + ".GOODSMGROUPRF" + Environment.NewLine);
                retstring += IFBy(bGoodsLGroup,
                             "  ," + sTblNm + ".GOODSLGROUPRF" + Environment.NewLine);
            }   // 2010/01/13 Add
            retstring += IFBy(bGoodsNo,
                         "  ," + sTblNm + ".GOODSNORF" + Environment.NewLine);
            //当月
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTRF)" + Environment.NewLine;
            retstring += "    AS MONTHTOTALSALESCOUNT" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEYRF)" + Environment.NewLine;
            retstring += "    AS MONTHSALESMONEY" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESRETGOODSPRICERF)" + Environment.NewLine;
            retstring += "    AS MONTHSALESRETGOODSPRICE" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_DISCOUNTPRICERF)" + Environment.NewLine;
            retstring += "    AS MONTHDISCOUNTPRICE" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_GROSSPROFITRF)" + Environment.NewLine;
            retstring += "    AS MONTHGROSSPROFIT" + Environment.NewLine;
            //当期
            retstring += "  ,SUM(" + sTblNm + ".A_TOTALSALESCOUNTRF)" + Environment.NewLine;
            retstring += "    AS ANNUALTOTALSALESCOUNT" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".A_SALESMONEYRF)" + Environment.NewLine;
            retstring += "    AS ANNUALSALESMONEY" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".A_SALESRETGOODSPRICERF)" + Environment.NewLine;
            retstring += "    AS ANNUALSALESRETGOODSPRICE" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".A_DISCOUNTPRICERF)" + Environment.NewLine;
            retstring += "    AS ANNUALDISCOUNTPRICE" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".A_GROSSPROFITRF)" + Environment.NewLine;
            retstring += "    AS ANNUALGROSSPROFIT" + Environment.NewLine;

            retstring += " FROM" + Environment.NewLine;
            retstring += " (" + Environment.NewLine;

            #region [商品別売上月次集計データ+BL商品コードマスタ+BLグループマスタ抽出]

            #region [当期分抽出]
            retstring += "   SELECT" + Environment.NewLine;
            retstring += "     " + sTblNm + "A.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.ADDUPSECCODERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.ADDUPYEARMONTHRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.GOODSMAKERCDRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.BLGOODSCODERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.GOODSNORF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.EMPLOYEECODERF" + Environment.NewLine;
            retstring += "    ,(CASE WHEN " + sTblNm + "A.TOTALSALESCOUNTRF IS NULL THEN 0 ELSE" + Environment.NewLine;
            retstring += "     " + sTblNm + "A.TOTALSALESCOUNTRF END) AS A_TOTALSALESCOUNTRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.SALESMONEYRF" + Environment.NewLine;
            retstring += "     AS A_SALESMONEYRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.SALESRETGOODSPRICERF" + Environment.NewLine;
            retstring += "     AS A_SALESRETGOODSPRICERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.DISCOUNTPRICERF" + Environment.NewLine;
            retstring += "     AS A_DISCOUNTPRICERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.GROSSPROFITRF" + Environment.NewLine;
            retstring += "     AS A_GROSSPROFITRF" + Environment.NewLine;
            retstring += "    ,(CASE WHEN " + sTblNm + "M.TOTALSALESCOUNTRF IS NULL THEN 0 ELSE" + Environment.NewLine;
            retstring += "     " + sTblNm + "M.TOTALSALESCOUNTRF END) AS M_TOTALSALESCOUNTRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "M.SALESMONEYRF" + Environment.NewLine;
            retstring += "     AS M_SALESMONEYRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "M.SALESRETGOODSPRICERF" + Environment.NewLine;
            retstring += "     AS M_SALESRETGOODSPRICERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "M.DISCOUNTPRICERF" + Environment.NewLine;
            retstring += "     AS M_DISCOUNTPRICERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "M.GROSSPROFITRF" + Environment.NewLine;
            retstring += "     AS M_GROSSPROFITRF" + Environment.NewLine;
            retstring += "    ,BLGCDUA" + sTblNm + ".BLGROUPCODERF" + Environment.NewLine;
            retstring += "    ,BLGRPUA" + sTblNm + ".GOODSMGROUPRF" + Environment.NewLine;
            retstring += "    ,BLGRPUA" + sTblNm + ".GOODSLGROUPRF" + Environment.NewLine;
            // 2011/07/29 >>>
            //retstring += "   FROM GOODSMTTLSASLIPRF AS " + sTblNm + "A" + Environment.NewLine;
            retstring += "   FROM GOODSMTTLSASLIPRF AS " + sTblNm + "A WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<
            //BL商品コードマスタ(ユーザー)
            // 2011/07/29 >>>
            //retstring += "   LEFT JOIN BLGOODSCDURF BLGCDUA" + sTblNm + Environment.NewLine;
            retstring += "   LEFT JOIN BLGOODSCDURF BLGCDUA" + sTblNm + " WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<
            retstring += "   ON  BLGCDUA" + sTblNm + ".ENTERPRISECODERF=" + sTblNm + "A.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "   AND BLGCDUA" + sTblNm + ".BLGOODSCODERF=" + sTblNm + "A.BLGOODSCODERF" + Environment.NewLine;
            //BLグループマスタ(ユーザー)
            // 2011/07/29 >>>
            //retstring += "   LEFT JOIN BLGROUPURF BLGRPUA" + sTblNm + Environment.NewLine;
            retstring += "   LEFT JOIN BLGROUPURF BLGRPUA" + sTblNm + " WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<
            retstring += "   ON  BLGRPUA" + sTblNm + ".ENTERPRISECODERF=BLGCDUA" + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "   AND BLGRPUA" + sTblNm + ".BLGROUPCODERF=BLGCDUA" + sTblNm + ".BLGROUPCODERF" + Environment.NewLine;
            #endregion  //[当期分抽出]

            #region [当月分抽出]
            retstring += "   LEFT JOIN" + Environment.NewLine;
            retstring += "   (" + Environment.NewLine;
            retstring += "    SELECT" + Environment.NewLine;
            retstring += "      " + sTblNm + "M2.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.ADDUPSECCODERF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.ADDUPYEARMONTHRF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.GOODSMAKERCDRF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.BLGOODSCODERF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.GOODSNORF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.EMPLOYEECODERF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.TOTALSALESCOUNTRF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.SALESMONEYRF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.SALESRETGOODSPRICERF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.DISCOUNTPRICERF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.GROSSPROFITRF" + Environment.NewLine;
            // ADD 2009.02.19 >>>
            retstring += "     ," + sTblNm + "M2.CUSTOMERCODERF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.SUPPLIERCDRF" + Environment.NewLine;
            // ADD 2009.02.19 <<<
            retstring += "     ,BLGCDUM" + sTblNm + ".BLGROUPCODERF" + Environment.NewLine;
            retstring += "     ,BLGRPUM" + sTblNm + ".GOODSMGROUPRF" + Environment.NewLine;
            retstring += "     ,BLGRPUM" + sTblNm + ".GOODSLGROUPRF" + Environment.NewLine;
            // 2011/07/29 >>>
            //retstring += "    FROM GOODSMTTLSASLIPRF AS " + sTblNm + "M2" + Environment.NewLine;
            retstring += "    FROM GOODSMTTLSASLIPRF AS " + sTblNm + "M2 WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<
            //BL商品コードマスタ(ユーザー)
            // 2011/07/29 >>>
            //retstring += "    LEFT JOIN BLGOODSCDURF BLGCDUM" + sTblNm + Environment.NewLine;
            retstring += "    LEFT JOIN BLGOODSCDURF BLGCDUM" + sTblNm + " WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<
            retstring += "    ON  BLGCDUM" + sTblNm + ".ENTERPRISECODERF=" + sTblNm + "M2.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "    AND BLGCDUM" + sTblNm + ".BLGOODSCODERF=" + sTblNm + "M2.BLGOODSCODERF" + Environment.NewLine;
            //BLグループマスタ(ユーザー)
            // 2011/07/29 >>>
            //retstring += "    LEFT JOIN BLGROUPURF BLGRPUM" + sTblNm + Environment.NewLine;
            retstring += "    LEFT JOIN BLGROUPURF BLGRPUM" + sTblNm + " WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<
            retstring += "    ON  BLGRPUM" + sTblNm + ".ENTERPRISECODERF=BLGCDUM" + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "    AND BLGRPUM" + sTblNm + ".BLGROUPCODERF=BLGCDUM" + sTblNm + ".BLGROUPCODERF" + Environment.NewLine;
            retstring += MakeWhereString(ref sqlCommand, CndtnWork, sTblNm + "M2", "BLGCDUM" + sTblNm, "BLGRPUM" + sTblNm, iRsltTtlDivCd, 0);
            retstring += "   ) AS " + sTblNm + "M" + Environment.NewLine;
            retstring += "   ON  " + sTblNm + "M.ENTERPRISECODERF=" + sTblNm + "A.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "   AND " + sTblNm + "M.ADDUPSECCODERF=" + sTblNm + "A.ADDUPSECCODERF" + Environment.NewLine;
            retstring += "   AND " + sTblNm + "M.ADDUPYEARMONTHRF=" + sTblNm + "A.ADDUPYEARMONTHRF" + Environment.NewLine;
            retstring += "   AND " + sTblNm + "M.GOODSMAKERCDRF=" + sTblNm + "A.GOODSMAKERCDRF" + Environment.NewLine;
            retstring += "   AND " + sTblNm + "M.BLGOODSCODERF=" + sTblNm + "A.BLGOODSCODERF" + Environment.NewLine;
            retstring += "   AND " + sTblNm + "M.GOODSNORF=" + sTblNm + "A.GOODSNORF" + Environment.NewLine;
            retstring += "   AND " + sTblNm + "M.EMPLOYEECODERF=" + sTblNm + "A.EMPLOYEECODERF" + Environment.NewLine;
            // ADD 2009.02.19 >>>
            retstring += "   AND " + sTblNm + "M.CUSTOMERCODERF =" + sTblNm + "A.CUSTOMERCODERF" + Environment.NewLine;
            retstring += "   AND " + sTblNm + "M.SUPPLIERCDRF=" + sTblNm + "A.SUPPLIERCDRF" + Environment.NewLine;
            // ADD 2009.02.19 <<<
            #endregion  //[当月分抽出]

            //当期分のWHERE句
            retstring += MakeWhereString(ref sqlCommand, CndtnWork, sTblNm + "A", "BLGCDUA" + sTblNm, "BLGRPUA" + sTblNm, iRsltTtlDivCd, 1);

            #endregion  //[商品別売上月次集計データ+BL商品コードマスタ+BLグループマスタ抽出]

            retstring += " ) AS " + sTblNm + Environment.NewLine;

            #region [GROUP BY]
            retstring += " GROUP BY" + Environment.NewLine;
            retstring += "   " + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += IFBy(bEmployeeCode,
                         "  ," + sTblNm + ".EMPLOYEECODERF" + Environment.NewLine);
            retstring += IFBy(bAddUpSecCode,
                         "  ," + sTblNm + ".ADDUPSECCODERF" + Environment.NewLine);
            retstring += IFBy(bGoodsMakerCd,
                         "  ," + sTblNm + ".GOODSMAKERCDRF" + Environment.NewLine);
            retstring += IFBy(bBLGoodsCode,
                         "  ," + sTblNm + ".BLGOODSCODERF" + Environment.NewLine);
            retstring += IFBy(bBLGroupCode,
                         "  ," + sTblNm + ".BLGROUPCODERF" + Environment.NewLine);
            retstring += IFBy(bGoodsMGroup,
                         "  ," + sTblNm + ".GOODSMGROUPRF" + Environment.NewLine);
            retstring += IFBy(bGoodsLGroup,
                         "  ," + sTblNm + ".GOODSLGROUPRF" + Environment.NewLine);
            retstring += IFBy(bGoodsNo,
                         "  ," + sTblNm + ".GOODSNORF" + Environment.NewLine);
            #endregion  //[GROUP BY]

            #endregion  //[商品別売上月次集計データ抽出Query]

            return retstring;
        }
        #endregion //商品別売上月次集計データ用 SubQuery生成処理

        #region [商品別売上月次集計データ用 Where句 生成処理]
        /// <summary>
        /// 商品別売上月次集計データ用WHERE句 生成処理 (月計用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <param name="sGSMSLP">テーブル名略称：商品別売上月次集計データ</param>
        /// <param name="sBLGCDU">テーブル名略称：BL商品コードマスタ</param>
        /// <param name="sBLGRPU">テーブル名略称：BLグループマスタ</param>
        /// <param name="iRsltTtlDivCd">在庫取寄せ区分</param>
        /// <param name="iType">対象年月 0:当月 1:当期</param>
        /// <returns>商品別売上月次集計データ用WHERE句</returns>
        /// <br>Note       : 商品別売上月次集計データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.02</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork, string sGSMSLP, string sBLGCDU, string sBLGRPU, int iRsltTtlDivCd, int iType)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            #region [商品別売上月次集計データ]
            //企業コード
            retstring += " " + sGSMSLP + ".ENTERPRISECODERF=@" + sGSMSLP + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sGSMSLP + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //論理削除区分
            retstring += " AND " + sGSMSLP + ".LOGICALDELETECODERF=0 " + Environment.NewLine;

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
                    retstring += " AND " + sGSMSLP + ".ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //実績集計区分
            retstring += " AND " + sGSMSLP + ".RSLTTTLDIVCDRF=@" + sGSMSLP + "RSLTTTLDIVCD" + Environment.NewLine;
            SqlParameter paraRsltTtlDivCd = sqlCommand.Parameters.Add("@" + sGSMSLP + "RSLTTTLDIVCD", SqlDbType.Int);
            paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(iRsltTtlDivCd);

            //対象年月
            if (iType == 0)
            {
                //当月
                retstring += " AND " + sGSMSLP + ".ADDUPYEARMONTHRF>=@" + sGSMSLP + "ADDUPYEARMONTHST" + Environment.NewLine;
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "ADDUPYEARMONTHST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AddUpYearMonthSt);

                retstring += " AND " + sGSMSLP + ".ADDUPYEARMONTHRF<=@" + sGSMSLP + "ADDUPYEARMONTHED" + Environment.NewLine;
                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "ADDUPYEARMONTHED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AddUpYearMonthEd);
            }
            else
            {
                //当期
                retstring += " AND " + sGSMSLP + ".ADDUPYEARMONTHRF>=@" + sGSMSLP + "ADDUPYEARMONTHST" + Environment.NewLine;
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "ADDUPYEARMONTHST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AnnualAddUpYearMonthSt);

                retstring += " AND " + sGSMSLP + ".ADDUPYEARMONTHRF<=@" + sGSMSLP + "ADDUPYEARMONTHED" + Environment.NewLine;
                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "ADDUPYEARMONTHED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AnnualAddUpYaerMonthEd);
            }

            //従業員コード
            if (CndtnWork.EmployeeCodeSt != "")
            {
                retstring += " AND " + sGSMSLP + ".EMPLOYEECODERF>=@" + sGSMSLP + "EMPLOYEECODEST" + Environment.NewLine;
                SqlParameter paraEmployeeCodeSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "EMPLOYEECODEST", SqlDbType.NChar);
                paraEmployeeCodeSt.Value = SqlDataMediator.SqlSetString(CndtnWork.EmployeeCodeSt);
            }
            if (CndtnWork.EmployeeCodeEd != "")
            {
                retstring += " AND " + sGSMSLP + ".EMPLOYEECODERF<=@" + sGSMSLP + "EMPLOYEECODEED" + Environment.NewLine;
                SqlParameter paraEmployeeCodeEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "EMPLOYEECODEED", SqlDbType.NChar);
                paraEmployeeCodeEd.Value = SqlDataMediator.SqlSetString(CndtnWork.EmployeeCodeEd);
            }

            //商品メーカーコード
            if (CndtnWork.GoodsMakerCdSt != 0)
            {
                retstring += " AND " + sGSMSLP + ".GOODSMAKERCDRF>=@" + sGSMSLP + "GOODSMAKERCDST" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "GOODSMAKERCDST", SqlDbType.Int);
                paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMakerCdSt);
            }
            if (CndtnWork.GoodsMakerCdEd != 999999)
            {
                retstring += " AND " + sGSMSLP + ".GOODSMAKERCDRF<=@" + sGSMSLP + "GOODSMAKERCDED" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "GOODSMAKERCDED", SqlDbType.Int);
                paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMakerCdEd);
            }

            //BL商品コード
            if (CndtnWork.BLGoodsCodeSt != 0)
            {
                retstring += " AND " + sGSMSLP + ".BLGOODSCODERF>=@" + sGSMSLP + "BLGOODSCODEST" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "BLGOODSCODEST", SqlDbType.Int);
                paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeSt);
            }
            if (CndtnWork.BLGoodsCodeEd != 99999999)
            {
                retstring += " AND " + sGSMSLP + ".BLGOODSCODERF<=@" + sGSMSLP + "BLGOODSCODEED" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "BLGOODSCODEED", SqlDbType.Int);
                paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeEd);
            }

            //商品番号
            if (CndtnWork.GoodsNoSt != "")
            {
                retstring += " AND " + sGSMSLP + ".GOODSNORF>=@" + sGSMSLP + "GOODSNOST" + Environment.NewLine;
                SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "GOODSNOST", SqlDbType.NVarChar);
                paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoSt);
            }
            if (CndtnWork.GoodsNoEd != "")
            {
                retstring += " AND " + sGSMSLP + ".GOODSNORF<=@" + sGSMSLP + "GOODSNOED" + Environment.NewLine;
                SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "GOODSNOED", SqlDbType.NVarChar);
                paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoEd);
            }
            #endregion  //[商品別売上月次集計データ]

            #region [BL商品コードマスタ・BLグループマスタ]
            //BLグループコード
            if (CndtnWork.BLGroupCodeSt != 0)
            {
                retstring += " AND " + sBLGCDU + ".BLGROUPCODERF>=@" + sBLGCDU + "BLGROUPCODEST" + Environment.NewLine;
                SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@" + sBLGCDU + "BLGROUPCODEST", SqlDbType.Int);
                paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeSt);
            }
            if (CndtnWork.BLGroupCodeEd != 99999)
            {
                retstring += " AND ( " + sBLGCDU + ".BLGROUPCODERF<=@" + sBLGCDU + "BLGROUPCODEED OR " + sBLGCDU + ".BLGROUPCODERF IS NULL )" + Environment.NewLine;
                SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@" + sBLGCDU + "BLGROUPCODEED", SqlDbType.Int);
                paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeEd);
            }

            //開始商品大分類コード
            if (CndtnWork.GoodsLGroupSt != 0)
            {
                retstring += " AND " + sBLGRPU + ".GOODSLGROUPRF>=@" + sBLGRPU + "GOODSLGROUPST" + Environment.NewLine;
                SqlParameter paraGoodsLGroupSt = sqlCommand.Parameters.Add("@" + sBLGRPU + "GOODSLGROUPST", SqlDbType.Int);
                paraGoodsLGroupSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsLGroupSt);
            }
            if (CndtnWork.GoodsLGroupEd != 9999)
            {
                retstring += " AND ( " + sBLGRPU + ".GOODSLGROUPRF<=@" + sBLGRPU + "GOODSLGROUPED OR " + sBLGRPU + ".GOODSLGROUPRF IS NULL )" + Environment.NewLine;
                SqlParameter paraGoodsLGroupEd = sqlCommand.Parameters.Add("@" + sBLGRPU + "GOODSLGROUPED", SqlDbType.Int);
                paraGoodsLGroupEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsLGroupEd);
            }

            //開始商品中分類コード
            if (CndtnWork.GoodsMGroupSt != 0)
            {
                retstring += " AND " + sBLGRPU + ".GOODSMGROUPRF>=@" + sBLGRPU + "GOODSMGROUPST" + Environment.NewLine;
                SqlParameter paraGoodsMGroupSt = sqlCommand.Parameters.Add("@" + sBLGRPU + "GOODSMGROUPST", SqlDbType.Int);
                paraGoodsMGroupSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMGroupSt);
            }
            if (CndtnWork.GoodsMGroupEd != 9999)
            {
                retstring += " AND ( " + sBLGRPU + ".GOODSMGROUPRF<=@" + sBLGRPU + "GOODSMGROUPED OR " + sBLGRPU + ".GOODSMGROUPRF IS NULL )" + Environment.NewLine;
                SqlParameter paraGoodsMGroupEd = sqlCommand.Parameters.Add("@" + sBLGRPU + "GOODSMGROUPED", SqlDbType.Int);
                paraGoodsMGroupEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMGroupEd);
            }
            #endregion  //[BL商品コードマスタ・BLグループマスタ]

            #endregion  //WHERE文作成

            return retstring;
        }
        #endregion  //[商品別売上月次集計データ用 Where句 生成処理]

        #region [CopyToSalesRsltListResultWorkFromReader処理 呼出]
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
        /// </remarks>
        private SalesRsltListResultWork CopyToSalesRsltListResultWorkFromReaderProc(ref SqlDataReader myReader, SalesRsltListCndtnWork CndtnWork)
        {
            #region [判別用フラグ]
            //計上拠点コード
            if (CndtnWork.TtlType == 1)
            {
                bAddUpSecCode = true;
            }

            //従業員コード
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1) ||
                (CndtnWork.Detail == 2) ||
                (CndtnWork.Detail == 3) ||
                (CndtnWork.Detail == 4) ||
                (CndtnWork.Detail == 5) ||
                (CndtnWork.Detail == 6))
            {
                bEmployeeCode = true;
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
            #endregion  //[判別用フラグ]

            #region [抽出結果-値セット]
            SalesRsltListResultWork ResultWork = new SalesRsltListResultWork();

            if (bEmployeeCode)
            {
                ResultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                ResultWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
            }
            if (bAddUpSecCode)
            {
                ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
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
            ResultWork.MonthSalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESRETGOODSPRICE"));
            ResultWork.MonthDiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHDISCOUNTPRICE"));
            ResultWork.MonthGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHGROSSPROFIT"));
            //当期
            ResultWork.AnnualTotalSalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANNUALTOTALSALESCOUNT"));
            ResultWork.AnnualSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALSALESMONEY"));
            ResultWork.AnnualSalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALSALESRETGOODSPRICE"));
            ResultWork.AnnualDiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALDISCOUNTPRICE"));
            ResultWork.AnnualGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALGROSSPROFIT"));
            #endregion  //[抽出結果-値セット]

            return ResultWork;
        }
        #endregion //[CopyToSalesRsltListResultWorkFromReader処理]
    }
}

