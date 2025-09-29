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
    class MTtlSaSlipCust : MTtlSaSlipBase, IMTtlSaSlip
    {
        #region [判別用フラグ宣言]
        private bool bAddUpSecCode = false;  //計上拠点コード
        private bool bGoodsNo = false;       //品番
        private bool bBLGroupCode = false;   //グループコード
        #endregion  //[判別用フラグ宣言]

        #region [得意先別用 Select文]
        /// <summary>
        /// 得意先別用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>得意先別用SELECT文</returns>
        /// <br>Note       : 得意先別用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.25</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, ShipmGoodsOdrReportParamWork CndtnWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, CndtnWork);
        }
        #endregion  //[得意先別用 Select文]

        #region [得意先別用 Select文生成処理]
        /// <summary>
        /// 得意先別用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>得意先別用SELECT文</returns>
        /// <br>Note       : 得意先別用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.25</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, ShipmGoodsOdrReportParamWork CndtnWork)
        {
            #region [判別用フラグ]
            //計上拠点コード
            if (CndtnWork.TtlType == 1)
            {
                bAddUpSecCode = true;
            }

            //品番
            if (CndtnWork.Detail == 0)
            {
                bGoodsNo = true;
            }

            //グループコード
            if (CndtnWork.Detail == 1)
            {
                bBLGroupCode = true;
            }
            #endregion  //[判別用フラグ]

            string selectTxt = "";

            // 対象テーブル
            // GOODSMTTLSASLIPRF GSMSLP 商品別売上月次集計データ
            // GOODSURF          GOODSU 商品マスタ(ユーザー)
            // BLGOODSCDURF      BLGCDU BL商品コードマスタ(ユーザー)
            // BLGROUPURF        BLGRPU BLグループマスタ(ユーザー)
            // SECINFOSETRF      SCINST 拠点情報設定マスタ
            // CUSTOMERRF        CUSTMR 得意先マスタ
            // MAKERURF          MAKERU メーカーマスタ(ユーザー登録分)

            #region [Select文作成]

            #region 2008.11.04 削除
            /*
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " ,GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;
            selectTxt += " ,MAKERU.MAKERSHORTNAMERF" + Environment.NewLine;
            selectTxt += " ,GSMSLP.CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += " ,CUSTMR.CUSTOMERSNMRF" + Environment.NewLine;
            selectTxt += " ,BLGCDU.BLGROUPCODERF" + Environment.NewLine;
            selectTxt += " ,BLGRPU.BLGROUPKANANAMERF" + Environment.NewLine;
            selectTxt += " ,GSMSLP.BLGOODSCODERF" + Environment.NewLine;
            selectTxt += " ,BLGRPU.GOODSLGROUPRF" + Environment.NewLine;
            selectTxt += " ,BLGRPU.GOODSMGROUPRF" + Environment.NewLine;
            selectTxt += IFBy(bAddUpSecCode,
                         " ,GSMSLP.ADDUPSECCODERF" + Environment.NewLine);
            selectTxt += IFBy(bAddUpSecCode,
                         " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsNo,
                         " ,GSMSLP.GOODSNORF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsNo,
                         " ,GOODSU.GOODSNAMEKANARF" + Environment.NewLine);
            selectTxt += IFBy(bBLGroupCode,
                         " ,BLGCDU.BLGOODSHALFNAMERF" + Environment.NewLine);
            //月計(数量)
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT1" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT2" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT3" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT4" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT5" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT6" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT7" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT8" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT9" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT10" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT11" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT12" + Environment.NewLine;
            //月計(回数)
            selectTxt += " ,GSMSLP.SALESTIMES1" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESTIMES2" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESTIMES3" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESTIMES4" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESTIMES5" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESTIMES6" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESTIMES7" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESTIMES8" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESTIMES9" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESTIMES10" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESTIMES11" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESTIMES12" + Environment.NewLine;
            //月計(金額)
            selectTxt += " ,GSMSLP.SALESMONEY1" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY2" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY3" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY4" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY5" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY6" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY7" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY8" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY9" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY10" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY11" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY12" + Environment.NewLine;
            //FROM
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;
            */
            #endregion 

            #region [データ抽出メインQuery]
            //在庫取寄せ区分で変わる項目を動的生成
            if (CndtnWork.RsltTtlDivCd == (int)RsltTtlDivCd.Order)
            {
                #region [取寄せの場合]
                // ADD 2008.11.04 >>>
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;
                //selectTxt += " ,MAKERU.MAKERSHORTNAMERF" + Environment.NewLine;
                selectTxt += " ,MAKERU.MAKERNAMERF" + Environment.NewLine;
                selectTxt += " ,GSMSLP.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += " ,CUSTMR.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += " ,BLGCDU.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += " ,BLGRPU.BLGROUPKANANAMERF" + Environment.NewLine;
                selectTxt += " ,GSMSLP.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " ,BLGRPU.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += " ,BLGRPU.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             " ,GSMSLP.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bAddUpSecCode,
                             " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsNo,
                             " ,GSMSLP.GOODSNORF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsNo,
                // -- UPD 2010/05/13 ------------------------------------------>>>
                //             " ,GOODSU.GOODSNAMEKANARF" + Environment.NewLine);
                             " ,(CASE WHEN GOODSU.GOODSNAMEKANARF IS NULL THEN GSMSLP2.GOODSNAMEKANARF ELSE GOODSU.GOODSNAMEKANARF END) AS GOODSNAMEKANARF" + Environment.NewLine);
                // -- UPD 2010/05/13 ------------------------------------------<<<
                selectTxt += IFBy(bBLGroupCode,
                             " ,BLGCDU.BLGOODSHALFNAMERF" + Environment.NewLine);
                //月計(数量)
                selectTxt += " ,SUM(GSMSLP.TOTALSALESCOUNT1) AS TOTALSALESCOUNT1" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.TOTALSALESCOUNT2) AS TOTALSALESCOUNT2" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.TOTALSALESCOUNT3) AS TOTALSALESCOUNT3" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.TOTALSALESCOUNT4) AS TOTALSALESCOUNT4" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.TOTALSALESCOUNT5) AS TOTALSALESCOUNT5" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.TOTALSALESCOUNT6) AS TOTALSALESCOUNT6" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.TOTALSALESCOUNT7) AS TOTALSALESCOUNT7" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.TOTALSALESCOUNT8) AS TOTALSALESCOUNT8" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.TOTALSALESCOUNT9) AS TOTALSALESCOUNT9" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.TOTALSALESCOUNT10) AS TOTALSALESCOUNT10" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.TOTALSALESCOUNT11) AS TOTALSALESCOUNT11" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.TOTALSALESCOUNT12) AS TOTALSALESCOUNT12" + Environment.NewLine;
                //月計(回数)
                selectTxt += " ,SUM(GSMSLP.SALESTIMES1) AS SALESTIMES1" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESTIMES2) AS SALESTIMES2" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESTIMES3) AS SALESTIMES3" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESTIMES4) AS SALESTIMES4" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESTIMES5) AS SALESTIMES5" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESTIMES6) AS SALESTIMES6" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESTIMES7) AS SALESTIMES7" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESTIMES8) AS SALESTIMES8" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESTIMES9) AS SALESTIMES9" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESTIMES10) AS SALESTIMES10" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESTIMES11) AS SALESTIMES11" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESTIMES12) AS SALESTIMES12" + Environment.NewLine;
                //月計(金額)
                selectTxt += " ,SUM(GSMSLP.SALESMONEY1) AS SALESMONEY1" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESMONEY2) AS SALESMONEY2" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESMONEY3) AS SALESMONEY3" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESMONEY4) AS SALESMONEY4" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESMONEY5) AS SALESMONEY5" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESMONEY6) AS SALESMONEY6" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESMONEY7) AS SALESMONEY7" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESMONEY8) AS SALESMONEY8" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESMONEY9) AS SALESMONEY9" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESMONEY10) AS SALESMONEY10" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESMONEY11) AS SALESMONEY11" + Environment.NewLine;
                selectTxt += " ,SUM(GSMSLP.SALESMONEY12) AS SALESMONEY12" + Environment.NewLine;

                //FROM
                selectTxt += " FROM" + Environment.NewLine;
                selectTxt += " (" + Environment.NewLine;
                // ADD 2008.11.04 <<<


                #region [合計分抽出]
                selectTxt += "  SELECT" + Environment.NewLine;
                selectTxt += "    GSMSLPM1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   ,GSMSLPM1.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += "   ,GSMSLPM1.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "   ,GSMSLPM1.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "   ,GSMSLPM1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "   ,GSMSLPM1.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsNo,
                             "   ,GSMSLPM1.GOODSNORF" + Environment.NewLine);
                //月計(数量)
                selectTxt += "   ,(CASE WHEN GSMSLPM1.TOTALSALESCOUNT1<>0.0 THEN (CASE WHEN GSMSLPM2.TOTALSALESCOUNT1<>0.0 THEN (GSMSLPM1.TOTALSALESCOUNT1-GSMSLPM2.TOTALSALESCOUNT1) ELSE GSMSLPM1.TOTALSALESCOUNT1 END) ELSE 0.0 END) AS TOTALSALESCOUNT1" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.TOTALSALESCOUNT2<>0.0 THEN (CASE WHEN GSMSLPM2.TOTALSALESCOUNT2<>0.0 THEN (GSMSLPM1.TOTALSALESCOUNT2-GSMSLPM2.TOTALSALESCOUNT2) ELSE GSMSLPM1.TOTALSALESCOUNT2 END) ELSE 0.0 END) AS TOTALSALESCOUNT2" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.TOTALSALESCOUNT3<>0.0 THEN (CASE WHEN GSMSLPM2.TOTALSALESCOUNT3<>0.0 THEN (GSMSLPM1.TOTALSALESCOUNT3-GSMSLPM2.TOTALSALESCOUNT3) ELSE GSMSLPM1.TOTALSALESCOUNT3 END) ELSE 0.0 END) AS TOTALSALESCOUNT3" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.TOTALSALESCOUNT4<>0.0 THEN (CASE WHEN GSMSLPM2.TOTALSALESCOUNT4<>0.0 THEN (GSMSLPM1.TOTALSALESCOUNT4-GSMSLPM2.TOTALSALESCOUNT4) ELSE GSMSLPM1.TOTALSALESCOUNT4 END) ELSE 0.0 END) AS TOTALSALESCOUNT4" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.TOTALSALESCOUNT5<>0.0 THEN (CASE WHEN GSMSLPM2.TOTALSALESCOUNT5<>0.0 THEN (GSMSLPM1.TOTALSALESCOUNT5-GSMSLPM2.TOTALSALESCOUNT5) ELSE GSMSLPM1.TOTALSALESCOUNT5 END) ELSE 0.0 END) AS TOTALSALESCOUNT5" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.TOTALSALESCOUNT6<>0.0 THEN (CASE WHEN GSMSLPM2.TOTALSALESCOUNT6<>0.0 THEN (GSMSLPM1.TOTALSALESCOUNT6-GSMSLPM2.TOTALSALESCOUNT6) ELSE GSMSLPM1.TOTALSALESCOUNT6 END) ELSE 0.0 END) AS TOTALSALESCOUNT6" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.TOTALSALESCOUNT7<>0.0 THEN (CASE WHEN GSMSLPM2.TOTALSALESCOUNT7<>0.0 THEN (GSMSLPM1.TOTALSALESCOUNT7-GSMSLPM2.TOTALSALESCOUNT7) ELSE GSMSLPM1.TOTALSALESCOUNT7 END) ELSE 0.0 END) AS TOTALSALESCOUNT7" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.TOTALSALESCOUNT8<>0.0 THEN (CASE WHEN GSMSLPM2.TOTALSALESCOUNT8<>0.0 THEN (GSMSLPM1.TOTALSALESCOUNT8-GSMSLPM2.TOTALSALESCOUNT8) ELSE GSMSLPM1.TOTALSALESCOUNT8 END) ELSE 0.0 END) AS TOTALSALESCOUNT8" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.TOTALSALESCOUNT9<>0.0 THEN (CASE WHEN GSMSLPM2.TOTALSALESCOUNT9<>0.0 THEN (GSMSLPM1.TOTALSALESCOUNT9-GSMSLPM2.TOTALSALESCOUNT9) ELSE GSMSLPM1.TOTALSALESCOUNT9 END) ELSE 0.0 END) AS TOTALSALESCOUNT9" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.TOTALSALESCOUNT10<>0.0 THEN (CASE WHEN GSMSLPM2.TOTALSALESCOUNT10<>0.0 THEN (GSMSLPM1.TOTALSALESCOUNT10-GSMSLPM2.TOTALSALESCOUNT10) ELSE GSMSLPM1.TOTALSALESCOUNT10 END) ELSE 0.0 END) AS TOTALSALESCOUNT10" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.TOTALSALESCOUNT11<>0.0 THEN (CASE WHEN GSMSLPM2.TOTALSALESCOUNT11<>0.0 THEN (GSMSLPM1.TOTALSALESCOUNT11-GSMSLPM2.TOTALSALESCOUNT11) ELSE GSMSLPM1.TOTALSALESCOUNT11 END) ELSE 0.0 END) AS TOTALSALESCOUNT11" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.TOTALSALESCOUNT12<>0.0 THEN (CASE WHEN GSMSLPM2.TOTALSALESCOUNT12<>0.0 THEN (GSMSLPM1.TOTALSALESCOUNT12-GSMSLPM2.TOTALSALESCOUNT12) ELSE GSMSLPM1.TOTALSALESCOUNT12 END) ELSE 0.0 END) AS TOTALSALESCOUNT12" + Environment.NewLine;
                //月計(回数)
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESTIMES1<>0 THEN (CASE WHEN GSMSLPM2.SALESTIMES1<>0 THEN (GSMSLPM1.SALESTIMES1-GSMSLPM2.SALESTIMES1) ELSE GSMSLPM1.SALESTIMES1 END) ELSE 0 END) AS SALESTIMES1" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESTIMES2<>0 THEN (CASE WHEN GSMSLPM2.SALESTIMES2<>0 THEN (GSMSLPM1.SALESTIMES2-GSMSLPM2.SALESTIMES2) ELSE GSMSLPM1.SALESTIMES2 END) ELSE 0 END) AS SALESTIMES2" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESTIMES3<>0 THEN (CASE WHEN GSMSLPM2.SALESTIMES3<>0 THEN (GSMSLPM1.SALESTIMES3-GSMSLPM2.SALESTIMES3) ELSE GSMSLPM1.SALESTIMES3 END) ELSE 0 END) AS SALESTIMES3" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESTIMES4<>0 THEN (CASE WHEN GSMSLPM2.SALESTIMES4<>0 THEN (GSMSLPM1.SALESTIMES4-GSMSLPM2.SALESTIMES4) ELSE GSMSLPM1.SALESTIMES4 END) ELSE 0 END) AS SALESTIMES4" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESTIMES5<>0 THEN (CASE WHEN GSMSLPM2.SALESTIMES5<>0 THEN (GSMSLPM1.SALESTIMES5-GSMSLPM2.SALESTIMES5) ELSE GSMSLPM1.SALESTIMES5 END) ELSE 0 END) AS SALESTIMES5" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESTIMES6<>0 THEN (CASE WHEN GSMSLPM2.SALESTIMES6<>0 THEN (GSMSLPM1.SALESTIMES6-GSMSLPM2.SALESTIMES6) ELSE GSMSLPM1.SALESTIMES6 END) ELSE 0 END) AS SALESTIMES6" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESTIMES7<>0 THEN (CASE WHEN GSMSLPM2.SALESTIMES7<>0 THEN (GSMSLPM1.SALESTIMES7-GSMSLPM2.SALESTIMES7) ELSE GSMSLPM1.SALESTIMES7 END) ELSE 0 END) AS SALESTIMES7" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESTIMES8<>0 THEN (CASE WHEN GSMSLPM2.SALESTIMES8<>0 THEN (GSMSLPM1.SALESTIMES8-GSMSLPM2.SALESTIMES8) ELSE GSMSLPM1.SALESTIMES8 END) ELSE 0 END) AS SALESTIMES8" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESTIMES9<>0 THEN (CASE WHEN GSMSLPM2.SALESTIMES9<>0 THEN (GSMSLPM1.SALESTIMES9-GSMSLPM2.SALESTIMES9) ELSE GSMSLPM1.SALESTIMES9 END) ELSE 0 END) AS SALESTIMES9" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESTIMES10<>0 THEN (CASE WHEN GSMSLPM2.SALESTIMES10<>0 THEN (GSMSLPM1.SALESTIMES10-GSMSLPM2.SALESTIMES10) ELSE GSMSLPM1.SALESTIMES10 END) ELSE 0 END) AS SALESTIMES10" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESTIMES11<>0 THEN (CASE WHEN GSMSLPM2.SALESTIMES11<>0 THEN (GSMSLPM1.SALESTIMES11-GSMSLPM2.SALESTIMES11) ELSE GSMSLPM1.SALESTIMES11 END) ELSE 0 END) AS SALESTIMES11" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESTIMES12<>0 THEN (CASE WHEN GSMSLPM2.SALESTIMES12<>0 THEN (GSMSLPM1.SALESTIMES12-GSMSLPM2.SALESTIMES12) ELSE GSMSLPM1.SALESTIMES12 END) ELSE 0 END) AS SALESTIMES12" + Environment.NewLine;
                //月計(金額)
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESMONEY1<>0 THEN (CASE WHEN GSMSLPM2.SALESMONEY1<>0 THEN (GSMSLPM1.SALESMONEY1-GSMSLPM2.SALESMONEY1) ELSE GSMSLPM1.SALESMONEY1 END) ELSE 0 END) AS SALESMONEY1" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESMONEY2<>0 THEN (CASE WHEN GSMSLPM2.SALESMONEY2<>0 THEN (GSMSLPM1.SALESMONEY2-GSMSLPM2.SALESMONEY2) ELSE GSMSLPM1.SALESMONEY2 END) ELSE 0 END) AS SALESMONEY2" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESMONEY3<>0 THEN (CASE WHEN GSMSLPM2.SALESMONEY3<>0 THEN (GSMSLPM1.SALESMONEY3-GSMSLPM2.SALESMONEY3) ELSE GSMSLPM1.SALESMONEY3 END) ELSE 0 END) AS SALESMONEY3" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESMONEY4<>0 THEN (CASE WHEN GSMSLPM2.SALESMONEY4<>0 THEN (GSMSLPM1.SALESMONEY4-GSMSLPM2.SALESMONEY4) ELSE GSMSLPM1.SALESMONEY4 END) ELSE 0 END) AS SALESMONEY4" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESMONEY5<>0 THEN (CASE WHEN GSMSLPM2.SALESMONEY5<>0 THEN (GSMSLPM1.SALESMONEY5-GSMSLPM2.SALESMONEY5) ELSE GSMSLPM1.SALESMONEY5 END) ELSE 0 END) AS SALESMONEY5" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESMONEY6<>0 THEN (CASE WHEN GSMSLPM2.SALESMONEY6<>0 THEN (GSMSLPM1.SALESMONEY6-GSMSLPM2.SALESMONEY6) ELSE GSMSLPM1.SALESMONEY6 END) ELSE 0 END) AS SALESMONEY6" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESMONEY7<>0 THEN (CASE WHEN GSMSLPM2.SALESMONEY7<>0 THEN (GSMSLPM1.SALESMONEY7-GSMSLPM2.SALESMONEY7) ELSE GSMSLPM1.SALESMONEY7 END) ELSE 0 END) AS SALESMONEY7" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESMONEY8<>0 THEN (CASE WHEN GSMSLPM2.SALESMONEY8<>0 THEN (GSMSLPM1.SALESMONEY8-GSMSLPM2.SALESMONEY8) ELSE GSMSLPM1.SALESMONEY8 END) ELSE 0 END) AS SALESMONEY8" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESMONEY9<>0 THEN (CASE WHEN GSMSLPM2.SALESMONEY9<>0 THEN (GSMSLPM1.SALESMONEY9-GSMSLPM2.SALESMONEY9) ELSE GSMSLPM1.SALESMONEY9 END) ELSE 0 END) AS SALESMONEY9" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESMONEY10<>0 THEN (CASE WHEN GSMSLPM2.SALESMONEY10<>0 THEN (GSMSLPM1.SALESMONEY10-GSMSLPM2.SALESMONEY10) ELSE GSMSLPM1.SALESMONEY10 END) ELSE 0 END) AS SALESMONEY10" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESMONEY11<>0 THEN (CASE WHEN GSMSLPM2.SALESMONEY11<>0 THEN (GSMSLPM1.SALESMONEY11-GSMSLPM2.SALESMONEY11) ELSE GSMSLPM1.SALESMONEY11 END) ELSE 0 END) AS SALESMONEY11" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.SALESMONEY12<>0 THEN (CASE WHEN GSMSLPM2.SALESMONEY12<>0 THEN (GSMSLPM1.SALESMONEY12-GSMSLPM2.SALESMONEY12) ELSE GSMSLPM1.SALESMONEY12 END) ELSE 0 END) AS SALESMONEY12" + Environment.NewLine;
                selectTxt += "  FROM" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                //合計分抽出サブQuery
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPM1SUB", (int)RsltTtlDivCd.PrtTtl,1);
                selectTxt += "  ) AS GSMSLPM1" + Environment.NewLine;
                #endregion  //[合計分抽出]

                #region [在庫分抽出]
                selectTxt += "  LEFT JOIN" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     GSMSLPM2SUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,GSMSLPM2SUB.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsNo,
                             "    ,GSMSLPM2SUB.GOODSNORF" + Environment.NewLine);
                //月計(数量)
                selectTxt += "    ,GSMSLPM2SUB.TOTALSALESCOUNT1" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.TOTALSALESCOUNT2" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.TOTALSALESCOUNT3" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.TOTALSALESCOUNT4" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.TOTALSALESCOUNT5" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.TOTALSALESCOUNT6" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.TOTALSALESCOUNT7" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.TOTALSALESCOUNT8" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.TOTALSALESCOUNT9" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.TOTALSALESCOUNT10" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.TOTALSALESCOUNT11" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.TOTALSALESCOUNT12" + Environment.NewLine;
                //月計(回数)
                selectTxt += "    ,GSMSLPM2SUB.SALESTIMES1" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESTIMES2" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESTIMES3" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESTIMES4" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESTIMES5" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESTIMES6" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESTIMES7" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESTIMES8" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESTIMES9" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESTIMES10" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESTIMES11" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESTIMES12" + Environment.NewLine;
                //月計(金額)
                selectTxt += "    ,GSMSLPM2SUB.SALESMONEY1" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESMONEY2" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESMONEY3" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESMONEY4" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESMONEY5" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESMONEY6" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESMONEY7" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESMONEY8" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESMONEY9" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESMONEY10" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESMONEY11" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SALESMONEY12" + Environment.NewLine;
                selectTxt += "   FROM" + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                //在庫分抽出サブQuery
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPM2SUB", (int)RsltTtlDivCd.Stock,1);
                selectTxt += "   ) AS GSMSLPM2SUB" + Environment.NewLine;
                selectTxt += "  ) AS GSMSLPM2" + Environment.NewLine;
                selectTxt += "  ON  GSMSLPM2.ENTERPRISECODERF=GSMSLPM1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GSMSLPM2.ADDUPYEARMONTHRF=GSMSLPM1.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += "  AND GSMSLPM2.CUSTOMERCODERF=GSMSLPM1.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  AND GSMSLPM2.BLGOODSCODERF=GSMSLPM1.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  AND GSMSLPM2.GOODSMAKERCDRF=GSMSLPM1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "  AND GSMSLPM2.ADDUPSECCODERF=GSMSLPM1.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsNo,
                             "  AND GSMSLPM2.GOODSNORF=GSMSLPM1.GOODSNORF" + Environment.NewLine);
                #endregion  //[在庫分抽出]

                #endregion  //[取寄せの場合]
            }
            else
            {
                #region 合計or在庫の場合
                // ADD 2008.11.04 >>>
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;
                //selectTxt += " ,MAKERU.MAKERSHORTNAMERF" + Environment.NewLine;
                selectTxt += " ,MAKERU.MAKERNAMERF" + Environment.NewLine;
                selectTxt += " ,GSMSLP.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += " ,CUSTMR.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += " ,BLGCDU.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += " ,BLGRPU.BLGROUPKANANAMERF" + Environment.NewLine;
                selectTxt += " ,GSMSLP.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " ,BLGRPU.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += " ,BLGRPU.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             " ,GSMSLP.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bAddUpSecCode,
                             " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsNo,
                             " ,GSMSLP.GOODSNORF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsNo,
                // -- UPD 2010/05/13 ------------------------------------------>>>
                             //" ,GOODSU.GOODSNAMEKANARF" + Environment.NewLine);
                             " ,(CASE WHEN GOODSU.GOODSNAMEKANARF IS NULL THEN GSMSLP2.GOODSNAMEKANARF ELSE GOODSU.GOODSNAMEKANARF END) AS GOODSNAMEKANARF" + Environment.NewLine);
                // -- UPD 2010/05/13 ------------------------------------------<<<
                selectTxt += IFBy(bBLGroupCode,
                             " ,BLGCDU.BLGOODSHALFNAMERF" + Environment.NewLine);
                //月計(数量)
                selectTxt += " ,GSMSLP.TOTALSALESCOUNT1" + Environment.NewLine;
                selectTxt += " ,GSMSLP.TOTALSALESCOUNT2" + Environment.NewLine;
                selectTxt += " ,GSMSLP.TOTALSALESCOUNT3" + Environment.NewLine;
                selectTxt += " ,GSMSLP.TOTALSALESCOUNT4" + Environment.NewLine;
                selectTxt += " ,GSMSLP.TOTALSALESCOUNT5" + Environment.NewLine;
                selectTxt += " ,GSMSLP.TOTALSALESCOUNT6" + Environment.NewLine;
                selectTxt += " ,GSMSLP.TOTALSALESCOUNT7" + Environment.NewLine;
                selectTxt += " ,GSMSLP.TOTALSALESCOUNT8" + Environment.NewLine;
                selectTxt += " ,GSMSLP.TOTALSALESCOUNT9" + Environment.NewLine;
                selectTxt += " ,GSMSLP.TOTALSALESCOUNT10" + Environment.NewLine;
                selectTxt += " ,GSMSLP.TOTALSALESCOUNT11" + Environment.NewLine;
                selectTxt += " ,GSMSLP.TOTALSALESCOUNT12" + Environment.NewLine;
                //月計(回数)
                selectTxt += " ,GSMSLP.SALESTIMES1" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESTIMES2" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESTIMES3" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESTIMES4" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESTIMES5" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESTIMES6" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESTIMES7" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESTIMES8" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESTIMES9" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESTIMES10" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESTIMES11" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESTIMES12" + Environment.NewLine;
                //月計(金額)
                selectTxt += " ,GSMSLP.SALESMONEY1" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESMONEY2" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESMONEY3" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESMONEY4" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESMONEY5" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESMONEY6" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESMONEY7" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESMONEY8" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESMONEY9" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESMONEY10" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESMONEY11" + Environment.NewLine;
                selectTxt += " ,GSMSLP.SALESMONEY12" + Environment.NewLine;
                //FROM
                selectTxt += " FROM" + Environment.NewLine;
                selectTxt += " (" + Environment.NewLine;
                // ADD 2008.11.04 <<<

                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPM", CndtnWork.RsltTtlDivCd,0);
                #endregion
            }
            #endregion  //[データ抽出メインQuery]

            selectTxt += " ) AS GSMSLP" + Environment.NewLine;

            #region [JOIN]
            //BL商品コードマスタ(ユーザー)
            // 2011/08/01 >>>
            //selectTxt += " LEFT JOIN BLGOODSCDURF BLGCDU" + Environment.NewLine;
            selectTxt += " LEFT JOIN BLGOODSCDURF BLGCDU WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            selectTxt += " ON  BLGCDU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND BLGCDU.BLGOODSCODERF=GSMSLP.BLGOODSCODERF" + Environment.NewLine;

            //BLグループマスタ(ユーザー)
            // 2011/08/01 >>>
            //selectTxt += " LEFT JOIN BLGROUPURF BLGRPU" + Environment.NewLine;
            selectTxt += " LEFT JOIN BLGROUPURF BLGRPU WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            selectTxt += " ON  BLGRPU.ENTERPRISECODERF=BLGCDU.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND BLGRPU.BLGROUPCODERF=BLGCDU.BLGROUPCODERF" + Environment.NewLine;

            //得意先マスタ
            // 2011/08/01 >>>
            //selectTxt += " LEFT JOIN CUSTOMERRF CUSTMR" + Environment.NewLine;
            selectTxt += " LEFT JOIN CUSTOMERRF CUSTMR WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            selectTxt += " ON  CUSTMR.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND CUSTMR.CUSTOMERCODERF=GSMSLP.CUSTOMERCODERF" + Environment.NewLine;

            //メーカーマスタ(ユーザー登録分)
            // 2011/08/01 >>>
            //selectTxt += " LEFT JOIN MAKERURF MAKERU" + Environment.NewLine;
            selectTxt += " LEFT JOIN MAKERURF MAKERU WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            selectTxt += " ON  MAKERU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND MAKERU.GOODSMAKERCDRF=GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;

            if (bGoodsNo)
            {
                //商品マスタ(ユーザー)
                // 2011/08/01 >>>
                //selectTxt += " LEFT JOIN GOODSURF GOODSU" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSURF GOODSU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
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
                // 2011/08/01 >>>
                //selectTxt += "     GOODSMTTLSASLIPRF" + Environment.NewLine;
                selectTxt += "     GOODSMTTLSASLIPRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
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
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.SalesDateSt);

                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@GSMSLP2ADDUPYEARMONTHED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.SalesDateEd);
                //-- ADD 2010/05/13 --------------------------------------------<<<

            }
            if (bAddUpSecCode)
            {
                //拠点情報設定マスタ
                // 2011/08/01 >>>
                //selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += " ON  SCINST.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SCINST.SECTIONCODERF=GSMSLP.ADDUPSECCODERF" + Environment.NewLine;
            }
            #endregion  //[JOIN]

            #region [WHERE句]
            selectTxt += " WHERE" + Environment.NewLine;
            selectTxt += " GSMSLP.ENTERPRISECODERF=@GSMSLPENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@GSMSLPENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //印刷範囲指定
            //if (CndtnWork.PrintRangeSt != 0)
            if (CndtnWork.PrintRangeSt != -99999999)
            {
                selectTxt += " AND ((" + Environment.NewLine;
                for (int i = 1; i <= 12; i++)
                {
                    //selectTxt += " GSMSLP.TOTALSALESCOUNT" + i.ToString() + ">=@TOTALSALESCOUNTST" + Environment.NewLine;
                    //if (i <= 11)
                    //    selectTxt += " OR " + Environment.NewLine;
                    selectTxt += " GSMSLP.TOTALSALESCOUNT" + i.ToString();
                    if (i <= 11)
                        selectTxt += " + " + Environment.NewLine;

                }
                selectTxt += " ) >=@TOTALSALESCOUNTST ) " + Environment.NewLine;
                SqlParameter paraPrintRangeSt = sqlCommand.Parameters.Add("@TOTALSALESCOUNTST", SqlDbType.Int);
                paraPrintRangeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PrintRangeSt);
            }
            if (CndtnWork.PrintRangeEd != 999999999)
            {
                selectTxt += " AND ((" + Environment.NewLine;
                for (int i = 1; i <= 12; i++)
                {
                    selectTxt += " GSMSLP.TOTALSALESCOUNT" + i.ToString();
                    if (i <= 11)
                        selectTxt += " + " + Environment.NewLine;
                }
                selectTxt += ") <= @TOTALSALESCOUNTED)" + Environment.NewLine;
                SqlParameter paraPrintRangeEd = sqlCommand.Parameters.Add("@TOTALSALESCOUNTED", SqlDbType.Int);
                paraPrintRangeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PrintRangeEd);
            }
            // ADD 2008.11.04  >>>
            selectTxt += " AND (" + Environment.NewLine;
            for (int cnt = 1; cnt <= 12; cnt++)
            {
                selectTxt += " TOTALSALESCOUNT" + cnt.ToString() + "!=0 " + Environment.NewLine;
                selectTxt += " OR ";
                selectTxt += " SALESTIMES" + cnt.ToString() + " !=0 " + Environment.NewLine;
                selectTxt += " OR ";
                selectTxt += " SALESMONEY" + cnt.ToString() + " !=0 " + Environment.NewLine;
                if (cnt != 12) selectTxt += " OR ";
            }
            selectTxt += " )" + Environment.NewLine;
            // ADD 2008.11.04 <<<

            #endregion  //[WHERE句]

            #endregion  //[Select文作成]

            // ADD 2008.11.04 >>>
            if (CndtnWork.RsltTtlDivCd == (int)RsltTtlDivCd.Order)
            {
                #region [GROUP BY]
                selectTxt += " GROUP BY" + Environment.NewLine;
                selectTxt += "  GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;
                //selectTxt += " ,MAKERU.MAKERSHORTNAMERF" + Environment.NewLine;
                selectTxt += " ,MAKERU.MAKERNAMERF" + Environment.NewLine;
                selectTxt += " ,GSMSLP.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += " ,CUSTMR.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += " ,BLGCDU.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += " ,BLGRPU.BLGROUPKANANAMERF" + Environment.NewLine;
                selectTxt += " ,GSMSLP.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " ,BLGRPU.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += " ,BLGRPU.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             " ,GSMSLP.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bAddUpSecCode,
                             " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsNo,
                             " ,GSMSLP.GOODSNORF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsNo,
                // -- UPD 2010/05/13 ------------------------------------------>>>
                             //" ,GOODSU.GOODSNAMEKANARF" + Environment.NewLine);
                             " ,(CASE WHEN GOODSU.GOODSNAMEKANARF IS NULL THEN GSMSLP2.GOODSNAMEKANARF ELSE GOODSU.GOODSNAMEKANARF END)" + Environment.NewLine);
                // -- UPD 2010/05/13 ------------------------------------------<<<
                selectTxt += IFBy(bBLGroupCode,
                             " ,BLGCDU.BLGOODSHALFNAMERF" + Environment.NewLine);
                #endregion
            }
            // ADD 2008.11.04 <<<

            return selectTxt;
        }
        #endregion  //[得意先別用 Select文生成処理]

        #region [月計抽出用 SubQuery生成処理]
        /// <summary>
        /// 月計抽出用 SubQuery生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>月計抽出用SELECT文</returns>
        /// <br>Note       : 月計抽出用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.25</br>
        private string MakeSubQueryString(ref SqlCommand sqlCommand, ShipmGoodsOdrReportParamWork CndtnWork, string sTblNm, int iRsltTtlDivCd, int ReadMode)
        {
            string retstring = "";
            DateTime stDate = CndtnWork.SalesDateSt;
            DateTime edDate = CndtnWork.SalesDateEd;
            Int32 setDate = stDate.Year * 100 + stDate.Month;

            #region [商品別売上月次集計データ抽出Query]
            retstring += " SELECT" + Environment.NewLine;
            retstring += "   " + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            if (ReadMode == 1)  retstring += "  ," + sTblNm + ".ADDUPYEARMONTHRF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".CUSTOMERCODERF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".BLGOODSCODERF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".GOODSMAKERCDRF" + Environment.NewLine;
            retstring += IFBy(bAddUpSecCode,
                         "  ," + sTblNm + ".ADDUPSECCODERF" + Environment.NewLine);
            retstring += IFBy(bGoodsNo,
                         "  ," + sTblNm + ".GOODSNORF" + Environment.NewLine);
            //月計(数量)
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR1) AS TOTALSALESCOUNT1" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR2) AS TOTALSALESCOUNT2" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR3) AS TOTALSALESCOUNT3" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR4) AS TOTALSALESCOUNT4" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR5) AS TOTALSALESCOUNT5" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR6) AS TOTALSALESCOUNT6" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR7) AS TOTALSALESCOUNT7" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR8) AS TOTALSALESCOUNT8" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR9) AS TOTALSALESCOUNT9" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR10) AS TOTALSALESCOUNT10" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR11) AS TOTALSALESCOUNT11" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR12) AS TOTALSALESCOUNT12" + Environment.NewLine;
            //月計(回数)
            retstring += "  ,SUM(" + sTblNm + ".M_SALESTIMES1) AS SALESTIMES1" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESTIMES2) AS SALESTIMES2" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESTIMES3) AS SALESTIMES3" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESTIMES4) AS SALESTIMES4" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESTIMES5) AS SALESTIMES5" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESTIMES6) AS SALESTIMES6" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESTIMES7) AS SALESTIMES7" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESTIMES8) AS SALESTIMES8" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESTIMES9) AS SALESTIMES9" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESTIMES10) AS SALESTIMES10" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESTIMES11) AS SALESTIMES11" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESTIMES12) AS SALESTIMES12" + Environment.NewLine;
            //月計(金額)
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY1) AS SALESMONEY1" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY2) AS SALESMONEY2" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY3) AS SALESMONEY3" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY4) AS SALESMONEY4" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY5) AS SALESMONEY5" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY6) AS SALESMONEY6" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY7) AS SALESMONEY7" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY8) AS SALESMONEY8" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY9) AS SALESMONEY9" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY10) AS SALESMONEY10" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY11) AS SALESMONEY11" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY12) AS SALESMONEY12" + Environment.NewLine;
            retstring += " FROM" + Environment.NewLine;
            retstring += " (" + Environment.NewLine;

            #region [月計集計]
            retstring += "  SELECT" + Environment.NewLine;
            retstring += "    " + sTblNm + "SUB.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "   ," + sTblNm + "SUB.ADDUPYEARMONTHRF" + Environment.NewLine;
            retstring += "   ," + sTblNm + "SUB.CUSTOMERCODERF" + Environment.NewLine;
            retstring += "   ," + sTblNm + "SUB.BLGOODSCODERF" + Environment.NewLine;
            retstring += "   ," + sTblNm + "SUB.GOODSMAKERCDRF" + Environment.NewLine;
            retstring += IFBy(bAddUpSecCode,
                         "   ," + sTblNm + "SUB.ADDUPSECCODERF" + Environment.NewLine);
            retstring += IFBy(bGoodsNo,
                         "   ," + sTblNm + "SUB.GOODSNORF" + Environment.NewLine);

            for (int i = 1; i <= 12; i++)
            {
                //月計(数量)
                retstring += "   ,CASE WHEN " + sTblNm + "SUB.ADDUPYEARMONTHRF=" + setDate.ToString() + " THEN " + sTblNm + "SUB.TOTALSALESCOUNTRF ELSE 0.0 END AS M_TOTALSALESCOUNTR" + i.ToString() + Environment.NewLine;
                //月計(回数)
                retstring += "   ,CASE WHEN " + sTblNm + "SUB.ADDUPYEARMONTHRF=" + setDate.ToString() + " THEN " + sTblNm + "SUB.SALESTIMESRF ELSE 0 END AS M_SALESTIMES" + i.ToString() + Environment.NewLine;
                //月計(金額)
                if (CndtnWork.Order != (int)Order.GrossProfit)
                {
                    //retstring += "   ,CASE WHEN " + sTblNm + "SUB.ADDUPYEARMONTHRF=" + setDate.ToString() + " THEN " + sTblNm + "SUB.SALESMONEYRF ELSE 0 END AS M_SALESMONEY" + i.ToString() + Environment.NewLine; // DEL 2008.11.04
                    retstring += "   ,CASE WHEN " + sTblNm + "SUB.ADDUPYEARMONTHRF=" + setDate.ToString() + " THEN (" + sTblNm + "SUB.SALESMONEYRF +" + sTblNm + "SUB.SALESRETGOODSPRICERF + " + sTblNm + "SUB.DISCOUNTPRICERF ) " + "ELSE 0 END AS M_SALESMONEY" + i.ToString() + Environment.NewLine; // ADD 2008.11.04

                }
                else
                {
                    retstring += "   ,CASE WHEN " + sTblNm + "SUB.ADDUPYEARMONTHRF=" + setDate.ToString() + " THEN " + sTblNm + "SUB.GROSSPROFITRF ELSE 0 END AS M_SALESMONEY" + i.ToString() + Environment.NewLine;
                }

                if (setDate % 100 >= 12)
                {
                    setDate = (setDate + 100) / 100 * 100 + 1;
                }
                else
                {
                    setDate = setDate + 1;
                }
            }

            retstring += "  FROM" + Environment.NewLine;
            retstring += "  (" + Environment.NewLine;

            #region [商品別売上月次集計データ抽出]
            retstring += "   SELECT" + Environment.NewLine;
            retstring += "     " + sTblNm + "SUB2.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.ADDUPSECCODERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.ADDUPYEARMONTHRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.CUSTOMERCODERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.BLGOODSCODERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.GOODSMAKERCDRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.GOODSNORF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.TOTALSALESCOUNTRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.SALESTIMESRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.SALESMONEYRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.GROSSPROFITRF" + Environment.NewLine;
            // ADD 2008.11.04 >>>
            retstring += "    ," + sTblNm + "SUB2.SALESRETGOODSPRICERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.DISCOUNTPRICERF" + Environment.NewLine;
            // ADD 2008.11.04 <<<
            retstring += "    ,BLGCDU" + sTblNm + ".BLGROUPCODERF" + Environment.NewLine;
            retstring += "    ,BLGRPU" + sTblNm + ".GOODSMGROUPRF" + Environment.NewLine;
            // 2011/08/01 >>>
            //retstring += "   FROM GOODSMTTLSASLIPRF AS " + sTblNm + "SUB2" + Environment.NewLine;
            //retstring += "   LEFT JOIN BLGOODSCDURF BLGCDU" + sTblNm + Environment.NewLine;
            retstring += "   FROM GOODSMTTLSASLIPRF AS " + sTblNm + "SUB2 WITH (READUNCOMMITTED) " + Environment.NewLine;
            retstring += "   LEFT JOIN BLGOODSCDURF BLGCDU" + sTblNm + " WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            retstring += "   ON  BLGCDU" + sTblNm + ".ENTERPRISECODERF=" + sTblNm + "SUB2.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "   AND BLGCDU" + sTblNm + ".BLGOODSCODERF=" + sTblNm + "SUB2.BLGOODSCODERF" + Environment.NewLine;
            // 2011/08/01 >>>
            //retstring += "   LEFT JOIN BLGROUPURF BLGRPU" + sTblNm + Environment.NewLine;
            retstring += "   LEFT JOIN BLGROUPURF BLGRPU" + sTblNm + " WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            retstring += "   ON  BLGRPU" + sTblNm + ".ENTERPRISECODERF=BLGCDU" + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "   AND BLGRPU" + sTblNm + ".BLGROUPCODERF=BLGCDU" + sTblNm + ".BLGROUPCODERF" + Environment.NewLine;
            retstring += MakeWhereString(ref sqlCommand, CndtnWork, sTblNm, iRsltTtlDivCd);
            #endregion  //[商品別売上月次集計データ抽出]

            retstring += "  ) AS " + sTblNm + "SUB" + Environment.NewLine;
            #endregion  //[月計集計]

            retstring += " ) AS " + sTblNm + Environment.NewLine;

            #region [GROUP BY]
            retstring += " GROUP BY" + Environment.NewLine;
            retstring += "   " + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            if (ReadMode == 1)  retstring += "  ," + sTblNm + ".ADDUPYEARMONTHRF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".CUSTOMERCODERF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".BLGOODSCODERF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".GOODSMAKERCDRF" + Environment.NewLine;
            retstring += IFBy(bAddUpSecCode,
                         "  ," + sTblNm + ".ADDUPSECCODERF" + Environment.NewLine);
            retstring += IFBy(bGoodsNo,
                         "  ," + sTblNm + ".GOODSNORF" + Environment.NewLine);
            #endregion  //[GROUP BY]

            #endregion  //[商品別売上月次集計データ抽出Query]

            return retstring;
        }
        #endregion //[月計抽出用 SubQuery生成処理]

        #region [商品別売上月次集計データ用 Where句 生成処理]
        /// <summary>
        /// 商品別売上月次集計データ用WHERE句 生成処理 (月計用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <param name="sTblNm">テーブル名略称</param>
        /// <returns>商品別売上月次集計データ用WHERE句</returns>
        /// <br>Note       : 商品別売上月次集計データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.25</br>
        /// <br>Update Note: 2012/08/09 wangf</br>
        /// <br>           : 10801804-00、9/12配信分、Redmine#31531 売上順位表 品番指定時の抽出不正の対応</br>
        /// <br>           : 品番を「*」で入力した場合、売上順位表抽出可能になります。</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ShipmGoodsOdrReportParamWork CndtnWork, string sTblNm, int iRsltTtlDivCd)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            #region [商品別売上月次集計データ]
            //企業コード
            retstring += " " + sTblNm + "SUB2.ENTERPRISECODERF=@" + sTblNm + "SUB2ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "SUB2ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //論理削除区分
            retstring += " AND " + sTblNm + "SUB2.LOGICALDELETECODERF=0 " + Environment.NewLine;

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
                    retstring += " AND " + sTblNm + "SUB2.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //実績集計区分
            retstring += " AND " + sTblNm + "SUB2.RSLTTTLDIVCDRF=@" + sTblNm + "SUB2RSLTTTLDIVCD" + Environment.NewLine;
            SqlParameter paraRsltTtlDivCd = sqlCommand.Parameters.Add("@" + sTblNm + "SUB2RSLTTTLDIVCD", SqlDbType.Int);
            paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(iRsltTtlDivCd);

            //対象年月
            retstring += " AND " + sTblNm + "SUB2.ADDUPYEARMONTHRF>=@" + sTblNm + "SUB2SALESDATEST" + Environment.NewLine;
            SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sTblNm + "SUB2SALESDATEST", SqlDbType.Int);
            paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.SalesDateSt);

            retstring += " AND " + sTblNm + "SUB2.ADDUPYEARMONTHRF<=@" + sTblNm + "SUB2SALESDATEED" + Environment.NewLine;
            SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sTblNm + "SUB2SALESDATEED", SqlDbType.Int);
            paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.SalesDateEd);

            //得意先コード
            if (CndtnWork.CustomerCodeSt != 0)
            {
                retstring += " AND " + sTblNm + "SUB2.CUSTOMERCODERF>=@" + sTblNm + "SUB2CUSTOMERCODEST" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "SUB2CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CustomerCodeSt);
            }
            if (CndtnWork.CustomerCodeEd != 99999999)
            {
                retstring += " AND " + sTblNm + "SUB2.CUSTOMERCODERF<=@" + sTblNm + "SUB2CUSTOMERCODEED" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SUB2CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CustomerCodeEd);
            }

            //商品メーカーコード
            if (CndtnWork.GoodsMakerCdSt != 0)
            {
                retstring += " AND " + sTblNm + "SUB2.GOODSMAKERCDRF>=@" + sTblNm + "SUB2GOODSMAKERCDST" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@" + sTblNm + "SUB2GOODSMAKERCDST", SqlDbType.Int);
                paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMakerCdSt);
            }
            if (CndtnWork.GoodsMakerCdEd != 9999)
            {
                retstring += " AND " + sTblNm + "SUB2.GOODSMAKERCDRF<=@" + sTblNm + "SUB2GOODSMAKERCDED" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@" + sTblNm + "SUB2GOODSMAKERCDED", SqlDbType.Int);
                paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMakerCdEd);
            }

            //BL商品コード
            if (CndtnWork.BLGoodsCodeSt != 0)
            {
                retstring += " AND " + sTblNm + "SUB2.BLGOODSCODERF>=@" + sTblNm + "SUB2BLGOODSCODEST" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "SUB2BLGOODSCODEST", SqlDbType.Int);
                paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeSt);
            }
            if (CndtnWork.BLGoodsCodeEd != 99999)
            {
                retstring += " AND ( " + sTblNm + "SUB2.BLGOODSCODERF<=@" + sTblNm + "SUB2BLGOODSCODEED OR " + sTblNm + "SUB2.BLGOODSCODERF IS NULL )" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SUB2BLGOODSCODEED", SqlDbType.Int);
                paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeEd);
            }

            //商品番号
            if (CndtnWork.GoodsNoSt != "")
            {
                /* ------------DEL wangf 2012/08/09 FOR Redmine#31531--------->>>>
                // ADD 2008.11.04 曖昧検索 >>> 
                if (CndtnWork.GoodsNoSt.LastIndexOf("*") >= 0)
                {
                    String[] GoodsNoSt = CndtnWork.GoodsNoSt.Split(new Char[] { '*' });
                    retstring += " AND ( " + sTblNm + "SUB2.GOODSNORF>=@" + sTblNm + "SUB2GOODSNOST OR " + sTblNm + "SUB2.GOODSNORF LIKE @" + sTblNm + "SUB2GOODSNOST )" + Environment.NewLine;
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@" + sTblNm + "SUB2GOODSNOST", SqlDbType.NVarChar);
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(GoodsNoSt[0] + "%");
                }
                else
                {
                // ADD 2008.11.04 <<<

                    retstring += " AND " + sTblNm + "SUB2.GOODSNORF>=@" + sTblNm + "SUB2GOODSNOST" + Environment.NewLine;
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@" + sTblNm + "SUB2GOODSNOST", SqlDbType.NVarChar);
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoSt);
                }// ADD 2008.11.04
                // ------------DEL wangf 2012/08/09 FOR Redmine#31531---------<<<<*/
                // ------------ADD wangf 2012/08/09 FOR Redmine#31531--------->>>>
                // PM7と合わせて、比較する時、ただの文字列比較をする、曖昧検索をしない
                string goodsNoSt = this.SplitString(CndtnWork.GoodsNoSt, 0);
                if (goodsNoSt.Length == 24)
                {
                    retstring += " AND " + sTblNm + "SUB2.GOODSNORF + REPLICATE('',24-LEN(" + sTblNm + "SUB2.GOODSNORF))>='" + goodsNoSt + "'COLLATE JAPANESE_BIN " + Environment.NewLine;
                }
                else
                {
                    retstring += " AND SUBSTRING(" + sTblNm + "SUB2.GOODSNORF, 1," + goodsNoSt.Length + ")>='" + goodsNoSt + "'COLLATE JAPANESE_BIN " + Environment.NewLine;
                }
                // ------------ADD wangf 2012/08/09 FOR Redmine#31531---------<<<<
            }
            if (CndtnWork.GoodsNoEd != "")
            {
                /* ------------DEL wangf 2012/08/09 FOR Redmine#31531--------->>>>
                // ADD 2008.10.30 >>>
                if (CndtnWork.GoodsNoEd.LastIndexOf("*") >= 0)
                {
                    String[] GoodsNoEd = CndtnWork.GoodsNoEd.Split(new Char[] { '*' });

                    retstring += " AND (" + sTblNm + "SUB2.GOODSNORF<=@" + sTblNm + "SUB2GOODSNOED OR " + sTblNm + "SUB2.GOODSNORF LIKE @" + sTblNm + "SUB2GOODSNOED )" + Environment.NewLine;
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@" + sTblNm + "SUB2GOODSNOED", SqlDbType.NVarChar);
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(GoodsNoEd[0] + "%");
                }
                else
                {
                // ADD 2008.11.04 <<<
                    retstring += " AND " + sTblNm + "SUB2.GOODSNORF<=@" + sTblNm + "SUB2GOODSNOED" + Environment.NewLine;
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@" + sTblNm + "SUB2GOODSNOED", SqlDbType.NVarChar);
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoEd);
                } // ADD 2008.11.04
                // ------------DEL wangf 2012/08/09 FOR Redmine#31531---------<<<<*/
                // ------------ADD wangf 2012/08/09 FOR Redmine#31531--------->>>>
                // PM7と合わせて、比較する時、ただの文字列比較をする、曖昧検索をしない
                string goodsNoEd = this.SplitString(CndtnWork.GoodsNoEd, 1);
                if (goodsNoEd.Length == 24)
                {
                    retstring += " AND " + sTblNm + "SUB2.GOODSNORF + REPLICATE('',24-LEN(" + sTblNm + "SUB2.GOODSNORF))<='" + goodsNoEd + "'COLLATE JAPANESE_BIN " + Environment.NewLine;
                }
                else
                {
                    retstring += " AND SUBSTRING(" + sTblNm + "SUB2.GOODSNORF, 1," + goodsNoEd.Length + ")<='" + goodsNoEd + "'COLLATE JAPANESE_BIN " + Environment.NewLine;
                }
                // ------------ADD wangf 2012/08/09 FOR Redmine#31531---------<<<<
            }
            #endregion  //[商品別売上月次集計データ]

            #region [BL商品コードマスタ・BLグループマスタ]
            //BLグループコード
            string groupString = string.Empty;
            string stString = string.Empty;
            string edString = string.Empty;

            if (CndtnWork.BLGroupCodeAry != null && CndtnWork.BLGroupCodeAry.Length != 0)
            {
                string BLGroupCodeArystr = "";
                foreach (int BLGCAry in CndtnWork.BLGroupCodeAry)
                {
                    if (BLGroupCodeArystr != "")
                    {
                        BLGroupCodeArystr += ",";
                    }
                    BLGroupCodeArystr += BLGCAry.ToString();
                }
                if (BLGroupCodeArystr != "")
                {
                    groupString += " BLGCDU" + sTblNm + ".BLGROUPCODERF IN (" + BLGroupCodeArystr + ") ";
                }
                groupString += Environment.NewLine;
            }

            if (CndtnWork.BLGroupCodeSt != 0)
            {
                stString += " BLGCDU" + sTblNm + ".BLGROUPCODERF>=@" + sTblNm + "BLGROUPCODEST" + Environment.NewLine;
                SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "BLGROUPCODEST", SqlDbType.Int);
                paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeSt);
            }

            if (CndtnWork.BLGroupCodeEd != 99999)
            {
                edString += " BLGCDU" + sTblNm + ".BLGROUPCODERF<=@" + sTblNm + "BLGROUPCODEED" + Environment.NewLine;
                SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "BLGROUPCODEED", SqlDbType.Int);
                paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeEd);
            }

            //グループコード用文字列生成
            if ((groupString != string.Empty) || (stString != string.Empty) || (edString != string.Empty))
            {
                retstring += " AND (";

                if (groupString != string.Empty)
                {
                    retstring += groupString;
                }

                if (stString != string.Empty)
                {
                    if (groupString != string.Empty)
                    {
                        retstring += " OR" + stString;
                    }
                    else
                    {
                        retstring += stString;
                    }
                }

                if (edString != string.Empty)
                {
                    if (stString != string.Empty)
                    {
                        retstring += " AND" + edString;
                    }
                    else
                    {
                        if (groupString != string.Empty)
                        {
                            retstring += " OR" + edString;
                        }
                        else
                        {
                            retstring += edString;
                            retstring += " OR BLGCDU" + sTblNm + ".BLGROUPCODERF IS NULL";
                        }
                    }
                }

                retstring += " )" + Environment.NewLine;
            }

            //開始商品大分類コード
            if (CndtnWork.GoodsLGroupSt != 0)
            {
                retstring += " AND BLGRPU" + sTblNm + ".GOODSLGROUPRF>=@" + sTblNm + "GOODSLGROUPST" + Environment.NewLine;
                SqlParameter paraGoodsLGroupSt = sqlCommand.Parameters.Add("@" + sTblNm + "GOODSLGROUPST", SqlDbType.Int);
                paraGoodsLGroupSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsLGroupSt);
            }
            if (CndtnWork.GoodsLGroupEd != 9999)
            {
                retstring += " AND ( BLGRPU" + sTblNm + ".GOODSLGROUPRF<=@" + sTblNm + "GOODSLGROUPED OR  BLGRPU" + sTblNm + ".GOODSLGROUPRF IS NULL )" + Environment.NewLine;
                SqlParameter paraGoodsLGroupEd = sqlCommand.Parameters.Add("@" + sTblNm + "GOODSLGROUPED", SqlDbType.Int);
                paraGoodsLGroupEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsLGroupEd);
            }

            //開始商品中分類コード
            if (CndtnWork.GoodsMGroupSt != 0)
            {
                retstring += " AND BLGRPU" + sTblNm + ".GOODSMGROUPRF>=@" + sTblNm + "GOODSMGROUPST" + Environment.NewLine;
                SqlParameter paraGoodsMGroupSt = sqlCommand.Parameters.Add("@" + sTblNm + "GOODSMGROUPST", SqlDbType.Int);
                paraGoodsMGroupSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMGroupSt);
            }
            if (CndtnWork.GoodsMGroupEd != 9999)
            {
                retstring += " AND ( BLGRPU" + sTblNm + ".GOODSMGROUPRF<=@" + sTblNm + "GOODSMGROUPED OR  BLGRPU" + sTblNm + ".GOODSMGROUPRF IS NULL )" + Environment.NewLine;
                SqlParameter paraGoodsMGroupEd = sqlCommand.Parameters.Add("@" + sTblNm + "GOODSMGROUPED", SqlDbType.Int);
                paraGoodsMGroupEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMGroupEd);
            }
            #endregion  //[BL商品コードマスタ・BLグループマスタ]

            #endregion  //WHERE文作成

            return retstring;
        }
        // ------------ADD wangf 2012/08/09 FOR Redmine#31531--------->>>>
        /// <summary>
        /// 文字処理後でただ「＊」の前の文字を戻る
        /// </summary>
        /// <param name="input">処理前の文字</param>
        /// <param name="mode">モード（0:開始位置、1:終了位置）</param>
        /// <returns>処理後の文字</returns>
        /// <remarks>
        /// <br>Note       : 無し</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/08/09</br>
        /// </remarks>
        private String SplitString(String input, int mode)
        {
            string retString = string.Empty;
            String stringWithOutLastStar = input;
            if (mode == 0)
            {
                int intLastStarIndex = input.LastIndexOf('*');
                if (intLastStarIndex >= 0)
                {
                    stringWithOutLastStar = input.Substring(0, intLastStarIndex) + input.Substring(intLastStarIndex + 1);
                }
            }
            if (stringWithOutLastStar.LastIndexOf('*') <= 0)
            {
                retString = stringWithOutLastStar.PadRight(24);
            }
            else
            {
                retString = stringWithOutLastStar.Substring(0, stringWithOutLastStar.LastIndexOf('*'));
            }
            return retString;
        }
        // ------------ADD wangf 2012/08/09 FOR Redmine#31531---------<<<<
        #endregion  //[商品別売上月次集計データ用 Where句 生成処理]

        #region [CopyToSalesRsltListResultWorkFromReader処理 呼出]
        /// <summary>
        /// クラス格納処理 Reader → CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CopyToSalesRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.25</br>
        /// </remarks>
        public ShipmGoodsOdrReportResultWork CopyToSalesRsltListResultWorkFromReader(ref SqlDataReader myReader, ShipmGoodsOdrReportParamWork CndtnWork)
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
        /// <br>Date       : 2008.08.25</br>
        /// </remarks>
        private ShipmGoodsOdrReportResultWork CopyToSalesRsltListResultWorkFromReaderProc(ref SqlDataReader myReader, ShipmGoodsOdrReportParamWork CndtnWork)
        {
            #region [抽出結果-値セット]
            ShipmGoodsOdrReportResultWork ResultWork = new ShipmGoodsOdrReportResultWork();

            if (CndtnWork.Detail == 0)
            {
                ResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                ResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            }
            if (CndtnWork.Detail == 1)
            {
                ResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            }
            if (CndtnWork.TtlType == 1)
            {
                ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                ResultWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            }
            ResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            ResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            ResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            ResultWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
            ResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            //ResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERSHORTNAMERF"));
            ResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            ResultWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
            ResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            ResultWork.TotalSalesCount1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT1"));
            ResultWork.TotalSalesCount2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT2"));
            ResultWork.TotalSalesCount3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT3"));
            ResultWork.TotalSalesCount4 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT4"));
            ResultWork.TotalSalesCount5 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT5"));
            ResultWork.TotalSalesCount6 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT6"));
            ResultWork.TotalSalesCount7 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT7"));
            ResultWork.TotalSalesCount8 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT8"));
            ResultWork.TotalSalesCount9 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT9"));
            ResultWork.TotalSalesCount10 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT10"));
            ResultWork.TotalSalesCount11 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT11"));
            ResultWork.TotalSalesCount12 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT12"));
            ResultWork.SalesTimes1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES1"));
            ResultWork.SalesTimes2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES2"));
            ResultWork.SalesTimes3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES3"));
            ResultWork.SalesTimes4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES4"));
            ResultWork.SalesTimes5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES5"));
            ResultWork.SalesTimes6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES6"));
            ResultWork.SalesTimes7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES7"));
            ResultWork.SalesTimes8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES8"));
            ResultWork.SalesTimes9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES9"));
            ResultWork.SalesTimes10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES10"));
            ResultWork.SalesTimes11 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES11"));
            ResultWork.SalesTimes12 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES12"));
            ResultWork.SalesMoney1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY1"));
            ResultWork.SalesMoney2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY2"));
            ResultWork.SalesMoney3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY3"));
            ResultWork.SalesMoney4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY4"));
            ResultWork.SalesMoney5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY5"));
            ResultWork.SalesMoney6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY6"));
            ResultWork.SalesMoney7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY7"));
            ResultWork.SalesMoney8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY8"));
            ResultWork.SalesMoney9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY9"));
            ResultWork.SalesMoney10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY10"));
            ResultWork.SalesMoney11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY11"));
            ResultWork.SalesMoney12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY12"));
            #endregion  //[抽出結果-値セット]

            return ResultWork;
        }
        #endregion //[CopyToSalesRsltListResultWorkFromReader処理]
    }
}
