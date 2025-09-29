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
    class MTtlSaSlipBLCd : MTtlSaSlipBase, IMTtlSaSlip
    {
        #region [判別用フラグ宣言]
        private bool bAddUpSecCode = false;  //計上拠点コード
        #endregion  //[判別用フラグ宣言]

        #region [BLコード別用 Select文]
        /// <summary>
        /// BLコード別用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>BLコード別用SELECT文</returns>
        /// <br>Note       : BLコード別用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.25</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, ShipmGoodsOdrReportParamWork CndtnWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, CndtnWork);
        }
        #endregion  //[BLコード別用 Select文]

        #region [BLコード別用 Select文生成処理]
        /// <summary>
        /// BLコード別用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>BLコード別用SELECT文</returns>
        /// <br>Note       : BLコード別用SELECT文を作成して戻します</br>
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
            #endregion  //[判別用フラグ]

            string selectTxt = "";

            // 対象テーブル
            // GOODSMTTLSASLIPRF GSMSLP 商品別売上月次集計データ
            // MAKERURF          MAKERU メーカーマスタ(ユーザー登録分)
            // BLGOODSCDURF      BLGCDU BL商品コードマスタ(ユーザー)
            // BLGROUPURF        BLGRPU BLグループマスタ(ユーザー)
            // USERGDBDURF       USGDBU ユーザーガイドマスタ(ボディ)(ユーザ変更分)
            // SECINFOSETRF      SCINST 拠点情報設定マスタ
            // SUPPLIERRF        SUPLER 仕入先マスタ
            // GOODSGROUPURF     GSGRPU 商品中分類マスタ(ユーザー登録分)

            #region [Select文作成]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " ,GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SUPPLIERCDRF" + Environment.NewLine;
            selectTxt += " ,SUPLER.SUPPLIERSNMRF" + Environment.NewLine;
            selectTxt += " ,GSMSLP.BLGOODSCODERF" + Environment.NewLine;
            selectTxt += " ,BLGCDU.BLGOODSHALFNAMERF" + Environment.NewLine;
            //selectTxt += " ,MAKERU.MAKERSHORTNAMERF" + Environment.NewLine;
            selectTxt += " ,MAKERU.MAKERNAMERF" + Environment.NewLine;
            selectTxt += " ,BLGRPU.GOODSLGROUPRF" + Environment.NewLine;
            selectTxt += " ,USGDBUL.GUIDENAMERF AS GOODSLGROUPNAME" + Environment.NewLine;
            selectTxt += " ,BLGRPU.GOODSMGROUPRF" + Environment.NewLine;
            selectTxt += " ,GSGRPU.GOODSMGROUPNAMERF" + Environment.NewLine;
            selectTxt += " ,BLGCDU.BLGROUPCODERF" + Environment.NewLine;
            selectTxt += " ,BLGRPU.BLGROUPKANANAMERF" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESMONEY" + Environment.NewLine;
            selectTxt += " ,GSMSLP.GROSSPROFIT" + Environment.NewLine;
            selectTxt += IFBy(bAddUpSecCode,
                         " ,GSMSLP.ADDUPSECCODERF" + Environment.NewLine);
            selectTxt += IFBy(bAddUpSecCode,
                         " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
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
                selectTxt += "    GSMSLPM1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   ,GSMSLPM1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "   ,GSMSLPM1.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "   ,GSMSLPM1.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "   ,GSMSLPM1.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += "   ,(CASE WHEN GSMSLPM1.TOTALSALESCOUNT<>0.0 THEN (CASE WHEN GSMSLPM2.TOTALSALESCOUNT<>0.0 THEN (GSMSLPM1.TOTALSALESCOUNT-GSMSLPM2.TOTALSALESCOUNT) ELSE GSMSLPM1.TOTALSALESCOUNT END) ELSE 0.0 END) AS TOTALSALESCOUNT" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.TOTALSALESMONEY<>0 THEN (CASE WHEN GSMSLPM2.TOTALSALESMONEY<>0 THEN (GSMSLPM1.TOTALSALESMONEY-GSMSLPM2.TOTALSALESMONEY) ELSE GSMSLPM1.TOTALSALESMONEY END) ELSE 0 END) AS TOTALSALESMONEY" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.GROSSPROFIT<>0 THEN (CASE WHEN GSMSLPM2.GROSSPROFIT<>0 THEN (GSMSLPM1.GROSSPROFIT-GSMSLPM2.GROSSPROFIT) ELSE GSMSLPM1.GROSSPROFIT END) ELSE 0 END) AS GROSSPROFIT" + Environment.NewLine;
                selectTxt += "  FROM" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                //合計分抽出サブQuery
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPM1SUB", (int)RsltTtlDivCd.PrtTtl);
                selectTxt += "  ) AS GSMSLPM1" + Environment.NewLine;
                #endregion  //[合計分抽出]

                #region [在庫分抽出]
                selectTxt += "  LEFT JOIN" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     GSMSLPM2SUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.TOTALSALESCOUNT" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.TOTALSALESMONEY" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.GROSSPROFIT" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,GSMSLPM2SUB.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += "   FROM" + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                //在庫分抽出サブQuery
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPM2SUB", (int)RsltTtlDivCd.Stock);
                selectTxt += "   ) AS GSMSLPM2SUB" + Environment.NewLine;
                selectTxt += "  ) AS GSMSLPM2" + Environment.NewLine;
                selectTxt += "  ON  GSMSLPM2.ENTERPRISECODERF=GSMSLPM1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GSMSLPM2.GOODSMAKERCDRF=GSMSLPM1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND GSMSLPM2.SUPPLIERCDRF=GSMSLPM1.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  AND GSMSLPM2.BLGOODSCODERF=GSMSLPM1.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "  AND GSMSLPM2.ADDUPSECCODERF=GSMSLPM1.ADDUPSECCODERF" + Environment.NewLine);
                #endregion  //[在庫分抽出]

                #endregion  //[取寄せの場合]
            }
            else
            {
                //合計or在庫の場合
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPM", CndtnWork.RsltTtlDivCd);
            }
            #endregion  //[データ抽出メインQuery]

            selectTxt += " ) AS GSMSLP" + Environment.NewLine;

            #region [JOIN]
            //メーカーマスタ(ユーザー登録分)
            // 2011/08/01 >>>
            //selectTxt += " LEFT JOIN MAKERURF MAKERU" + Environment.NewLine;
            selectTxt += " LEFT JOIN MAKERURF MAKERU WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            selectTxt += " ON  MAKERU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND MAKERU.GOODSMAKERCDRF=GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;

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

            //ユーザーガイドマスタ ※商品大分類ガイド名称取得用
            // 2011/08/01 >>>
            //selectTxt += " LEFT JOIN USERGDBDURF USGDBUL" + Environment.NewLine;
            selectTxt += " LEFT JOIN USERGDBDURF USGDBUL WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            selectTxt += " ON  USGDBUL.ENTERPRISECODERF=BLGRPU.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USGDBUL.GUIDECODERF=BLGRPU.GOODSLGROUPRF" + Environment.NewLine;
            selectTxt += " AND USGDBUL.USERGUIDEDIVCDRF=70" + Environment.NewLine;

            //商品中分類マスタ(ユーザー登録分)
            // 2011/08/01 >>>
            //selectTxt += " LEFT JOIN GOODSGROUPURF GSGRPU" + Environment.NewLine;
            selectTxt += " LEFT JOIN GOODSGROUPURF GSGRPU WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            selectTxt += " ON  GSGRPU.ENTERPRISECODERF=BLGRPU.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND GSGRPU.GOODSMGROUPRF=BLGRPU.GOODSMGROUPRF" + Environment.NewLine;

            //仕入先マスタ
            // 2011/08/01 >>>
            //selectTxt += " LEFT JOIN SUPPLIERRF SUPLER" + Environment.NewLine;
            selectTxt += " LEFT JOIN SUPPLIERRF SUPLER WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            selectTxt += " ON  SUPLER.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND SUPLER.SUPPLIERCDRF=GSMSLP.SUPPLIERCDRF" + Environment.NewLine;

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

            //WHERE句
            selectTxt += MakeWhereString(ref sqlCommand, CndtnWork);

            #endregion  //[Select文作成]

            return selectTxt;
        }
        #endregion  //[BLコード別用 Select文生成処理]

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
        private string MakeSubQueryString(ref SqlCommand sqlCommand, ShipmGoodsOdrReportParamWork CndtnWork, string sTblNm, int iRsltTtlDivCd)
        {
            string retstring = "";

            #region [商品別売上月次集計データ抽出Query]
            retstring += " SELECT" + Environment.NewLine;
            retstring += "   " + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".GOODSMAKERCDRF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".SUPPLIERCDRF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".BLGOODSCODERF" + Environment.NewLine;
            retstring += IFBy(bAddUpSecCode,
                         "  ," + sTblNm + ".ADDUPSECCODERF" + Environment.NewLine);
            retstring += "  ,SUM(" + sTblNm + ".TOTALSALESCOUNTRF) AS TOTALSALESCOUNT" + Environment.NewLine;

             retstring += "  ,(SUM(" + sTblNm + ".SALESMONEYRF) + SUM(" + sTblNm + ".SALESRETGOODSPRICERF) + SUM(" + sTblNm + ".DISCOUNTPRICERF)) AS TOTALSALESMONEY" + Environment.NewLine; // DEL 2008.11.04
            retstring += "  ,SUM(" + sTblNm + ".GROSSPROFITRF) AS GROSSPROFIT" + Environment.NewLine;
            // 2011/08/01 >>>
            //retstring += " FROM GOODSMTTLSASLIPRF AS " + sTblNm + Environment.NewLine;
            retstring += " FROM GOODSMTTLSASLIPRF AS " + sTblNm + " WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            retstring += MakeWhereString_GSMSLP(ref sqlCommand, CndtnWork, sTblNm, iRsltTtlDivCd);
            retstring += " GROUP BY" + Environment.NewLine;
            retstring += "   " + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".GOODSMAKERCDRF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".SUPPLIERCDRF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".BLGOODSCODERF" + Environment.NewLine;
            retstring += IFBy(bAddUpSecCode,
                         "  ," + sTblNm + ".ADDUPSECCODERF" + Environment.NewLine);
            #endregion  //[商品別売上月次集計データ抽出Query]

            return retstring;
        }
        #endregion //月計抽出用 SubQuery生成処理

        #region [BLコード別用 Where句 生成処理]
        /// <summary>
        /// BLコード別用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件<検索条件/param>
        /// <returns>BLコード別用WHERE句</returns>
        /// <br>Note       : BLコード別用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.25</br>
        public string MakeWhereString(ref SqlCommand sqlCommand, ShipmGoodsOdrReportParamWork CndtnWork)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " GSMSLP.ENTERPRISECODERF=@GSMSLPENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@GSMSLPENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

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
                    groupString += " BLGCDU.BLGROUPCODERF IN (" + BLGroupCodeArystr + ") ";
                }
                groupString += Environment.NewLine;
            }

            if (CndtnWork.BLGroupCodeSt != 0)
            {
                stString += " BLGCDU.BLGROUPCODERF>=@BLGROUPCODEST" + Environment.NewLine;
                SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@BLGROUPCODEST", SqlDbType.Int);
                paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeSt);
            }

            if (CndtnWork.BLGroupCodeEd != 99999)
            {
                edString += " BLGCDU.BLGROUPCODERF<=@BLGROUPCODEED" + Environment.NewLine;
                SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@BLGROUPCODEED", SqlDbType.Int);
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
                            retstring += " OR BLGCDU.BLGROUPCODERF IS NULL " + Environment.NewLine;
                        }
                    }
                }

                retstring += " )" + Environment.NewLine;
            }

            //開始商品大分類コード
            if (CndtnWork.GoodsLGroupSt != 0)
            {
                retstring += " AND  BLGRPU.GOODSLGROUPRF>=@GOODSLGROUPST" + Environment.NewLine;
                SqlParameter paraGoodsLGroupSt = sqlCommand.Parameters.Add("@GOODSLGROUPST", SqlDbType.Int);
                paraGoodsLGroupSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsLGroupSt);
            }
            if (CndtnWork.GoodsLGroupEd != 9999)
            {
                retstring += " AND ( BLGRPU.GOODSLGROUPRF<=@GOODSLGROUPED OR BLGRPU.GOODSLGROUPRF IS NULL ) " + Environment.NewLine;
                SqlParameter paraGoodsLGroupEd = sqlCommand.Parameters.Add("@GOODSLGROUPED", SqlDbType.Int);
                paraGoodsLGroupEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsLGroupEd);
            }

            //開始商品中分類コード
            if (CndtnWork.GoodsMGroupSt != 0)
            {
                retstring += " AND BLGRPU.GOODSMGROUPRF>=@GOODSMGROUPST" + Environment.NewLine;
                SqlParameter paraGoodsMGroupSt = sqlCommand.Parameters.Add("@GOODSMGROUPST", SqlDbType.Int);
                paraGoodsMGroupSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMGroupSt);
            }
            if (CndtnWork.GoodsMGroupEd != 9999)
            {
                retstring += " AND ( BLGRPU.GOODSMGROUPRF<=@GOODSMGROUPED OR BLGRPU.GOODSMGROUPRF IS NULL )" + Environment.NewLine;
                SqlParameter paraGoodsMGroupEd = sqlCommand.Parameters.Add("@GOODSMGROUPED", SqlDbType.Int);
                paraGoodsMGroupEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMGroupEd);
            }
            #endregion  //WHERE文作成

            return retstring;
        }
        #endregion //[BLコード別用 Where句生成処理]

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
        private string MakeWhereString_GSMSLP(ref SqlCommand sqlCommand, ShipmGoodsOdrReportParamWork CndtnWork, string sTblNm, int iRsltTtlDivCd)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //論理削除区分
            retstring += " AND " + sTblNm + ".LOGICALDELETECODERF=0 " + Environment.NewLine;

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
                    retstring += " AND " + sTblNm + ".ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //実績集計区分
            retstring += " AND " + sTblNm + ".RSLTTTLDIVCDRF=@" + sTblNm + "RSLTTTLDIVCD" + Environment.NewLine;
            SqlParameter paraRsltTtlDivCd = sqlCommand.Parameters.Add("@" + sTblNm + "RSLTTTLDIVCD", SqlDbType.Int);
            paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(iRsltTtlDivCd);

            //対象年月
            retstring += " AND " + sTblNm + ".ADDUPYEARMONTHRF>=@" + sTblNm + "SALESDATEST" + Environment.NewLine;
            SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESDATEST", SqlDbType.Int);
            paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.SalesDateSt);

            retstring += " AND " + sTblNm + ".ADDUPYEARMONTHRF<=@" + sTblNm + "SALESDATEED" + Environment.NewLine;
            SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESDATEED", SqlDbType.Int);
            paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.SalesDateEd);

            //仕入先コード
            if (CndtnWork.SupplierCdSt != 0)
            {
                retstring += " AND " + sTblNm + ".SUPPLIERCDRF>=@" + sTblNm + "SUPPLIERCDST" + Environment.NewLine;
                SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@" + sTblNm + "SUPPLIERCDST", SqlDbType.Int);
                paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SupplierCdSt);
            }
            if (CndtnWork.SupplierCdEd != 999999)
            {
                retstring += " AND " + sTblNm + ".SUPPLIERCDRF<=@" + sTblNm + "SUPPLIERCDED" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SUPPLIERCDED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SupplierCdEd);
            }

            //商品メーカーコード
            if (CndtnWork.GoodsMakerCdSt != 0)
            {
                retstring += " AND " + sTblNm + ".GOODSMAKERCDRF>=@" + sTblNm + "GOODSMAKERCDST" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@" + sTblNm + "GOODSMAKERCDST", SqlDbType.Int);
                paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMakerCdSt);
            }
            if (CndtnWork.GoodsMakerCdEd != 9999)
            {
                retstring += " AND " + sTblNm + ".GOODSMAKERCDRF<=@" + sTblNm + "GOODSMAKERCDED" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@" + sTblNm + "GOODSMAKERCDED", SqlDbType.Int);
                paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMakerCdEd);
            }

            //BL商品コード
            if (CndtnWork.BLGoodsCodeSt != 0)
            {
                retstring += " AND " + sTblNm + ".BLGOODSCODERF>=@" + sTblNm + "BLGOODSCODEST" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "BLGOODSCODEST", SqlDbType.Int);
                paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeSt);
            }
            if (CndtnWork.BLGoodsCodeEd != 99999999)
            {
                retstring += " AND " + sTblNm + ".BLGOODSCODERF<=@" + sTblNm + "BLGOODSCODEED" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "BLGOODSCODEED", SqlDbType.Int);
                paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeEd);
            }

            //商品番号
            if (CndtnWork.GoodsNoSt != "")
            {
                retstring += " AND " + sTblNm + ".GOODSNORF>=@" + sTblNm + "GOODSNOST" + Environment.NewLine;
                SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@" + sTblNm + "GOODSNOST", SqlDbType.NVarChar);
                paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoSt);
            }
            if (CndtnWork.GoodsNoEd != "")
            {
                retstring += " AND " + sTblNm + ".GOODSNORF<=@" + sTblNm + "GOODSNOED" + Environment.NewLine;
                SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@" + sTblNm + "GOODSNOED", SqlDbType.NVarChar);
                paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoEd);
            }
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

            if (CndtnWork.TtlType == 1)
            {
                ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                ResultWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            }
            ResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            ResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            ResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            ResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            ResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            ResultWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
            ResultWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAME"));
            ResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            ResultWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
            ResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            ResultWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
            //ResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERSHORTNAMERF"));
            ResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            ResultWork.TotalSalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT"));
            ResultWork.TotalSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALSALESMONEY"));
            ResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFIT"));
            #endregion  //[抽出結果-値セット]

            return ResultWork;
        }
        #endregion //[CopyToSalesRsltListResultWorkFromReader処理]
    }
}