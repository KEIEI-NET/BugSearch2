//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン実績表
// プログラム概要   : キャンペーン実績表　販売区分別用ｓｑｌ
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/05/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/07/05  修正内容 : Redmine 障害報告 #22746 の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/07/07  修正内容 : Redmine 仕様連絡 #22792 の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/07/11  修正内容 : Redmine 仕様変更 #22860 の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/07/27  修正内容 : Redmine 障害報告 #23232 の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : chenyd
// 作 成 日  2012/04/09  修正内容 : 2012/05/24配信分、Redmine#29314           
//                                  タイムアウトエラーの対応
//----------------------------------------------------------------------------//
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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    class MTtlCampaignGuide : MTtlCampaignBase, IMTtlCampaign
    {
        #region [判別用フラグ宣言]
        private bool bBLGroupCode = false;   // BLグループコード
        private bool bBLGoodsCode = false;   // BL商品コード
        private bool bGoodsNo = false;       // 商品番号
        private bool bMakerCode = false;     // メーカーコード
        private FinYearTableGenerator _finYearTableGenerator;
        private int _monthCount = 0;
        #endregion  //[判別用フラグ宣言]

        /// <summary>
        /// 会計年度テーブル生成部品取得
        /// </summary>
        /// <returns></returns>
        private FinYearTableGenerator GetFinYearTableGenerator(string enterpriseCode, ref SqlConnection sqlConnection)
        {
            FinYearTableGenerator finYearTableGenerator = null;

            // 自社情報レコード取得
            CompanyInfDB companyInfDB = new CompanyInfDB();
            CompanyInfWork paraWork = new CompanyInfWork();
            paraWork.EnterpriseCode = enterpriseCode;
            ArrayList retList;
            companyInfDB.Search(out retList, paraWork, ref sqlConnection);
            if (retList != null && retList.Count > 0)
            {
                // 会計年度部品生成
                finYearTableGenerator = new FinYearTableGenerator((CompanyInfWork)retList[0]);
            }

            return finYearTableGenerator;
        }

        /// <summary>
        /// 月数算出
        /// </summary>
        /// <param name="edDate"></param>
        /// <param name="stDate"></param>
        /// <returns></returns>
        private int GetMonthsCount(DateTime edDate, DateTime stDate)
        {
            int difOfYear = edDate.Year - stDate.Year;
            int difOfMonth = edDate.Month - stDate.Month;

            return ((difOfYear * 12) + (difOfMonth)) + 1;
        }

        #region [販売区分別用売上Select文]
        /// <summary>
        /// 販売区分別用売上SELECT文 生成処理
        /// </summary>
        /// <param name="sqlConnection">sqlConnectionオブジェクト</param>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>販売区分別用SELECT文</returns>
        /// <br>Note       : 販売区分別用SELECT文を作成して戻します</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        public string MakeSalesSelectString(ref SqlConnection sqlConnection, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            return this.MakeSalesSelectStringProc(ref sqlConnection, ref sqlCommand, CndtnWork);
        }
        #endregion  // 販売区分別用売上Select文

        #region [販売区分別用売上Select文生成処理]
        /// <summary>
        /// 販売区分別用売上SELECT文 生成処理
        /// </summary>
        /// <param name="sqlConnection">sqlConnectionオブジェクト</param>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>販売区分別用売上SELECT文</returns>
        /// <br>Note       : 販売区分別用売上SELECT文を作成して戻します</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        private string MakeSalesSelectStringProc(ref SqlConnection sqlConnection, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            #region [判別用フラグ]
            // BLグループコード
            if ((CndtnWork.Detail == 0 && CndtnWork.Total == 0) || CndtnWork.Detail == 2)
            {
                bBLGroupCode = true;
            }

            // BL商品コード
            if ((CndtnWork.Detail == 0 && CndtnWork.Total == 1) || CndtnWork.Detail == 1)
            {
                bBLGoodsCode = true;
            }

            if (CndtnWork.Detail == 0)
            {
                bGoodsNo = true;
            }

            // メーカーコード
            if (CndtnWork.PrintType != 1)
            {
                bMakerCode = true;
            }
            #endregion

            string selectTxt = string.Empty;

            if (CndtnWork.PrintType == 1)
            {
                _finYearTableGenerator = this.GetFinYearTableGenerator(CndtnWork.EnterpriseCode, ref sqlConnection);
                //日付取得部品
                _monthCount = GetMonthsCount(CndtnWork.AddUpYearMonthEd, CndtnWork.AddUpYearMonthSt);
            }
            #region SELECT文
            selectTxt += "SELECT DISTINCT " + Environment.NewLine;
            selectTxt += "  B.SALESSLIPNUMRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESROWNORF " + Environment.NewLine;
            selectTxt += "  ,B.SALESSLIPCDDTLRF " + Environment.NewLine; // ADD 2011/07/27
            selectTxt += "  ,A.RESULTSADDUPSECCDRF AS RESULTSADDUPSECCD " + Environment.NewLine;//実績計上拠点コード
            selectTxt += "  ,A.SALESDATERF " + Environment.NewLine;
            selectTxt += "  ,B. SALESCODERF AS SALESCODE " + Environment.NewLine;//販売区分コード
            selectTxt += "  ,B. GOODSMAKERCDRF AS GOODSMAKERCD " + Environment.NewLine;//商品メーカーコード
            selectTxt += "  ,B. GOODSNORF AS GOODSNO" + Environment.NewLine;//商品番号
            selectTxt += "  ,B. GOODSNAMEKANARF AS GOODSNAMEKANA" + Environment.NewLine;//商品名称カナ
            selectTxt += "  ,B. BLGOODSCODERF AS BLGOODSCODE" + Environment.NewLine;//BL商品コード
            selectTxt += "  ,B. BLGROUPCODERF AS BLGROUPCODE" + Environment.NewLine;//BLグループコード            
            selectTxt += "  ,B.SHIPMENTCNTRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESMONEYTAXEXCRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESMONEYTAXEXCRF - B.COSTRF AS GRSPROFITRF " + Environment.NewLine;
            selectTxt += "  ,CAMPST.CAMPAIGNCODERF " + Environment.NewLine;
            selectTxt += "  ,CAMPST.CAMPAIGNNAMERF " + Environment.NewLine;
            selectTxt += "  ,CAMPST.CAMPAIGNOBJDIVRF " + Environment.NewLine;
            selectTxt += "  ,CAMPST.APPLYSTADATERF " + Environment.NewLine;
            selectTxt += "  ,CAMPST.APPLYENDDATERF " + Environment.NewLine;
            //selectTxt += "  ,CAMPMNG.SECTIONCODERF " + Environment.NewLine; // DEL 2011/07/05
            selectTxt += "  ,SEC.SECTIONGUIDESNMRF AS SECTIONGUIDESNM1 " + Environment.NewLine;//拠点ガイド略称
            selectTxt += "  ,USERGD.GUIDENAMERF AS GUIDENAME " + Environment.NewLine;//拠点ガイド略称
            selectTxt += "  ,MAKER.MAKERNAMERF AS MAKERKANANAME" + Environment.NewLine;
            selectTxt += " ,BLGROUP.BLGROUPKANANAMERF AS BLGROUPKANANAME" + Environment.NewLine;
            selectTxt += " ,BL.BLGOODSHALFNAMERF AS BLGOODSHALFNAME" + Environment.NewLine;

            //売上履歴データ
            selectTxt += "FROM SALESHISTORYRF AS A WITH (READUNCOMMITTED)" + Environment.NewLine;

            #region 売上履歴明細データ
            selectTxt += "LEFT JOIN SALESHISTDTLRF AS B WITH (READUNCOMMITTED)" + Environment.NewLine;
            selectTxt += "ON A.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "AND A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF" + Environment.NewLine;// 受注ステータス
            selectTxt += "AND A.SALESSLIPNUMRF = B.SALESSLIPNUMRF" + Environment.NewLine;//売上伝票番号
            #endregion

            #region 拠点情報設定マスタ
            //selectTxt += " LEFT JOIN SECINFOSETRF AS " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += " LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += " ON SEC.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND SEC.SECTIONCODERF = A.RESULTSADDUPSECCDRF" + Environment.NewLine;// 実績計上拠点コード 
            selectTxt += " AND SEC.LOGICALDELETECODERF = 0" + Environment.NewLine;
            #endregion

            #region ユーザーガイドマスタ
            //selectTxt += " LEFT JOIN USERGDBDURF AS USERGD " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += " LEFT JOIN USERGDBDURF AS USERGD WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += " ON USERGD.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USERGD.GUIDECODERF = B.SALESCODERF" + Environment.NewLine;// 販売区分コード
            selectTxt += " AND USERGD.LOGICALDELETECODERF = 0" + Environment.NewLine;
            selectTxt += " AND USERGD.USERGUIDEDIVCDRF = 71" + Environment.NewLine;            
            #endregion

            #region ＢＬ商品コードマスタ
            //selectTxt += " LEFT JOIN BLGOODSCDURF AS BL " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += " LEFT JOIN BLGOODSCDURF AS BL WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += " ON BL.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND BL.BLGOODSCODERF = B.BLGOODSCODERF" + Environment.NewLine;//BL商品コード
            selectTxt += " AND BL.LOGICALDELETECODERF = 0" + Environment.NewLine;
            #endregion

            #region BLグループマスタ（ユーザー登録分）
            //selectTxt += " LEFT JOIN BLGROUPURF AS BLGROUP " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += " LEFT JOIN BLGROUPURF AS BLGROUP WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += " ON BLGROUP.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND BLGROUP.BLGROUPCODERF = B.BLGROUPCODERF" + Environment.NewLine;//BLグループマスタ
            selectTxt += " AND BLGROUP.LOGICALDELETECODERF = 0" + Environment.NewLine;
            #endregion

            #region メーカーマスタ
            //selectTxt += " LEFT JOIN MAKERURF AS MAKER " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += " LEFT JOIN MAKERURF AS MAKER WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += " ON MAKER.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND MAKER.GOODSMAKERCDRF = B.GOODSMAKERCDRF" + Environment.NewLine;//メーカー
            selectTxt += " AND MAKER.LOGICALDELETECODERF = 0" + Environment.NewLine;
            #endregion

            //selectTxt += "LEFT JOIN CAMPAIGNSTRF CAMPST " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN CAMPAIGNSTRF CAMPST WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON A.ENTERPRISECODERF = CAMPST.ENTERPRISECODERF " + Environment.NewLine;
            // ----- ADD 2012/04/09 chenyd for Redmine#29314 ----- >>>>>
            // キャンペーンコード
            selectTxt += "AND CAMPST.CAMPAIGNCODERF = @FINDCAMPAIGNCODE2  " + Environment.NewLine;
            SqlParameter paraCampaignCode2 = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE2", SqlDbType.Int);
            paraCampaignCode2.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);
            // ----- ADD 2012/04/09 chenyd for Redmine#29314 ----- <<<<<
            //selectTxt += "LEFT JOIN CAMPAIGNMNGRF CAMPMNG " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN CAMPAIGNMNGRF CAMPMNG WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON CAMPST.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND CAMPST.CAMPAIGNCODERF = CAMPMNG.CAMPAIGNCODERF " + Environment.NewLine;            

            #endregion

            #region WHERE文
            selectTxt += MakeWhereString(ref sqlCommand, CndtnWork);

            selectTxt += " AND ((CAMPMNG.CAMPAIGNSETTINGKINDRF = 1 AND CAMPMNG.GOODSNORF = B.GOODSNORF AND CAMPMNG.GOODSMAKERCDRF = B.GOODSMAKERCDRF)" + Environment.NewLine;
            selectTxt += "   OR (CAMPMNG.CAMPAIGNSETTINGKINDRF = 2 AND CAMPMNG.GOODSMAKERCDRF = B.GOODSMAKERCDRF AND CAMPMNG.BLGOODSCODERF = B.BLGOODSCODERF)  " + Environment.NewLine;
            selectTxt += "   OR (CAMPMNG.CAMPAIGNSETTINGKINDRF = 3 AND CAMPMNG.GOODSMAKERCDRF = B.GOODSMAKERCDRF AND CAMPMNG.BLGROUPCODERF = B.BLGROUPCODERF)  " + Environment.NewLine;
            selectTxt += "   OR (CAMPMNG.CAMPAIGNSETTINGKINDRF = 4 AND CAMPMNG.GOODSMAKERCDRF = B.GOODSMAKERCDRF)  " + Environment.NewLine;
            selectTxt += "   OR (CAMPMNG.CAMPAIGNSETTINGKINDRF = 5 AND CAMPMNG.BLGOODSCODERF = B.BLGOODSCODERF)  " + Environment.NewLine;
            selectTxt += "   OR (CAMPMNG.CAMPAIGNSETTINGKINDRF = 6 AND CAMPMNG.SALESCODERF = B.SALESCODERF)  " + Environment.NewLine;
            selectTxt += " ) " + Environment.NewLine;

            // ----- ADD 2011/07/11 ----->>>>>
            selectTxt += " AND ((CAMPMNG.SECTIONCODERF <> '00' AND A.RESULTSADDUPSECCDRF = CAMPMNG.SECTIONCODERF) OR (CAMPMNG.SECTIONCODERF = '00')) " + Environment.NewLine;
            // ----- ADD 2011/07/11 -----<<<<<

            selectTxt += " AND ((CAMPST.CAMPAIGNOBJDIVRF = 1 " + Environment.NewLine;
            selectTxt += "   AND A.CUSTOMERCODERF IN ( " + Environment.NewLine;
            selectTxt += "     SELECT CUSTOMERCODERF " + Environment.NewLine;
            //selectTxt += "     FROM CAMPAIGNLINKRF " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "     FROM CAMPAIGNLINKRF WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "     WHERE " + Environment.NewLine;
            selectTxt += "       ENTERPRISECODERF = @FINDENTERPRISECODE1 " + Environment.NewLine;
            SqlParameter paraEnterpriseCode1 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE1", SqlDbType.NChar);
            paraEnterpriseCode1.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);
            selectTxt += "       AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE1 " + Environment.NewLine;
            SqlParameter paraCampaignCode1 = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE1", SqlDbType.Int);
            paraCampaignCode1.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);

            selectTxt += "       AND LOGICALDELETECODERF = 0)) " + Environment.NewLine;
            selectTxt += "    OR (CAMPST.CAMPAIGNOBJDIVRF <> 1)) " + Environment.NewLine;

            #region ORDER BY
            selectTxt += "  ORDER BY " + Environment.NewLine;
            selectTxt += "    A.RESULTSADDUPSECCDRF " + Environment.NewLine;
            selectTxt += "    ,B.SALESCODERF " + Environment.NewLine;
            if (bBLGroupCode == true)
            {
                selectTxt += "    ,B.BLGROUPCODERF " + Environment.NewLine;
            }
            if (bBLGoodsCode == true)
            {
                selectTxt += "    ,B.BLGOODSCODERF " + Environment.NewLine;
            }
            if (bMakerCode == true)
            {
                selectTxt += "   ,B.GOODSMAKERCDRF " + Environment.NewLine;
            }
            if (bGoodsNo == true)
            {
                selectTxt += "   ,B.GOODSNORF " + Environment.NewLine;
            }
            #endregion
            #endregion

            return selectTxt;
        }
        #endregion  // 販売区分別用売上Select文生成処理

        #region [Where文の作成]
        /// <summary>
        /// Where文の作成
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="CndtnWork"></param>
        /// <returns></returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            string selectTxt = string.Empty;
            selectTxt += "WHERE " + Environment.NewLine;
            // 企業コード
            selectTxt += "  A.ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            // 論理削除区分
            selectTxt += "  AND A.LOGICALDELETECODERF=0 " + Environment.NewLine;
            selectTxt += "  AND B.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            selectTxt += "  AND CAMPMNG.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            // 受注ステータス
            selectTxt += "  AND A.ACPTANODRSTATUSRF=30 " + Environment.NewLine;

            // キャンペーンコード
            selectTxt += "  AND CAMPST.CAMPAIGNCODERF=@FINDCAMPAIGNCODE " + Environment.NewLine;
            SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);

            // 実績計上拠点コード
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
                    selectTxt += " AND A.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                }
                selectTxt += Environment.NewLine;
            }

            // 得意先コード
            if (CndtnWork.CustomerCodeSt != 0)
            {
                selectTxt += "  AND A.CUSTOMERCODERF >= @FINDCUSTOMERCODEST " + Environment.NewLine;
                SqlParameter paraCustomerCdSt = sqlCommand.Parameters.Add("@FINDCUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCdSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CustomerCodeSt);
            }

            if (CndtnWork.CustomerCodeEd != 0)
            {
                selectTxt += "  AND A.CUSTOMERCODERF <= @FINDCUSTOMERCODEED " + Environment.NewLine;
                SqlParameter paraCustomerCdEd = sqlCommand.Parameters.Add("@FINDCUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCdEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CustomerCodeEd);
            }

            // 販売区分コード
            if (CndtnWork.SalesCodeSt != 0)
            {
                selectTxt += "  AND B.SALESCODERF >= @FINDSALESCODEST " + Environment.NewLine;
                SqlParameter paraSaleCodeSt = sqlCommand.Parameters.Add("@FINDSALESCODEST", SqlDbType.Int);
                paraSaleCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SalesCodeSt);
            }

            if (CndtnWork.SalesCodeEd != 0)
            {
                selectTxt += "  AND B.SALESCODERF <= @FINDSALESCODESTED " + Environment.NewLine;
                SqlParameter paraSaleCodeEd = sqlCommand.Parameters.Add("@FINDSALESCODESTED", SqlDbType.Int);
                paraSaleCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SalesCodeEd);
            }

            // 売上伝票区分（明細）
            //selectTxt += "  AND (B.SALESSLIPCDDTLRF = 0 OR B.SALESSLIPCDDTLRF = 1) " + Environment.NewLine; // DEL 2011/07/27
            selectTxt += "  AND (B.SALESSLIPCDDTLRF = 0 OR B.SALESSLIPCDDTLRF = 1 OR B.SALESSLIPCDDTLRF = 2) " + Environment.NewLine; // ADD 2011/07/27

            // ----- UPD 2011/07/27 ----- >>>>>
            //// 売上履歴データの売上日付
            //if (CndtnWork.ApplyStaDate != 0)
            //{
            //    selectTxt += "  AND A.SALESDATERF >= @FINDSTSALESDATEST " + Environment.NewLine;
            //    SqlParameter paraStSalesDateSt = sqlCommand.Parameters.Add("@FINDSTSALESDATEST", SqlDbType.Int);
            //    paraStSalesDateSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyStaDate);
            //}

            //if (CndtnWork.ApplyEndDate != 0)
            //{
            //    selectTxt += "  AND A.SALESDATERF <= @FINDSTSALESDATEED " + Environment.NewLine;
            //    SqlParameter paraStSalesDateEd = sqlCommand.Parameters.Add("@FINDSTSALESDATEED", SqlDbType.Int);
            //    paraStSalesDateEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyEndDate);
            //}

            //selectTxt += "  AND A.SALESDATERF >= @FINDSALESDTST " + Environment.NewLine;

            //selectTxt += "  AND A.SALESDATERF <= @FINDSALESDTED " + Environment.NewLine;

            //selectTxt += "  AND B.SALESDATERF >= @FINDSALESDTST " + Environment.NewLine;
            //SqlParameter paraSeSalesDtSt = sqlCommand.Parameters.Add("@FINDSALESDTST", SqlDbType.Int);
            //paraSeSalesDtSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.AddUpYearMonthDaySt);

            //selectTxt += "  AND B.SALESDATERF <= @FINDSALESDTED " + Environment.NewLine;
            //SqlParameter paraSeSalesDtEd = sqlCommand.Parameters.Add("@FINDSALESDTED", SqlDbType.Int);
            //paraSeSalesDtEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.AddUpYearMonthDayEd);

            //// 売上履歴明細データの売上日付
            //if (CndtnWork.ApplyStaDate != 0)
            //{
            //    selectTxt += "  AND B.SALESDATERF >= @FINDDTSALESDATEST " + Environment.NewLine;
            //    SqlParameter paraDtSalesDateSt = sqlCommand.Parameters.Add("@FINDDTSALESDATEST", SqlDbType.Int);
            //    paraDtSalesDateSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyStaDate);
            //}

            //if (CndtnWork.ApplyEndDate != 0)
            //{
            //    selectTxt += "  AND B.SALESDATERF <= @FINDDTSALESDATEED " + Environment.NewLine;
            //    SqlParameter paraDtSalesDateEd = sqlCommand.Parameters.Add("@FINDDTSALESDATEED", SqlDbType.Int);
            //    paraDtSalesDateEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyEndDate);
            //}

            // 売上履歴データの売上日付
            if (CndtnWork.ApplyStaDate != 0)
            {
                selectTxt += "  AND ((A.SALESDATERF >= @FINDSTSALESDATEST " + Environment.NewLine;
                SqlParameter paraStSalesDateSt = sqlCommand.Parameters.Add("@FINDSTSALESDATEST", SqlDbType.Int);
                paraStSalesDateSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyStaDate);
            }

            if (CndtnWork.ApplyEndDate != 0)
            {
                selectTxt += "  AND A.SALESDATERF <= @FINDSTSALESDATEED) " + Environment.NewLine;
                SqlParameter paraStSalesDateEd = sqlCommand.Parameters.Add("@FINDSTSALESDATEED", SqlDbType.Int);
                paraStSalesDateEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyEndDate);
            }

            selectTxt += "  OR (A.SALESDATERF >= @FINDSALESDTST " + Environment.NewLine;

            selectTxt += "  AND A.SALESDATERF <= @FINDSALESDTED)) " + Environment.NewLine;

            selectTxt += "  AND ((B.SALESDATERF >= @FINDSALESDTST " + Environment.NewLine;
            SqlParameter paraSeSalesDtSt = sqlCommand.Parameters.Add("@FINDSALESDTST", SqlDbType.Int);
            paraSeSalesDtSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.AddUpYearMonthDaySt);

            selectTxt += "  AND B.SALESDATERF <= @FINDSALESDTED) " + Environment.NewLine;
            SqlParameter paraSeSalesDtEd = sqlCommand.Parameters.Add("@FINDSALESDTED", SqlDbType.Int);
            paraSeSalesDtEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.AddUpYearMonthDayEd);

            // 売上履歴明細データの売上日付
            if (CndtnWork.ApplyStaDate != 0)
            {
                selectTxt += "  OR (B.SALESDATERF >= @FINDDTSALESDATEST " + Environment.NewLine;
                SqlParameter paraDtSalesDateSt = sqlCommand.Parameters.Add("@FINDDTSALESDATEST", SqlDbType.Int);
                paraDtSalesDateSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyStaDate);
            }

            if (CndtnWork.ApplyEndDate != 0)
            {
                selectTxt += "  AND B.SALESDATERF <= @FINDDTSALESDATEED)) " + Environment.NewLine;
                SqlParameter paraDtSalesDateEd = sqlCommand.Parameters.Add("@FINDDTSALESDATEED", SqlDbType.Int);
                paraDtSalesDateEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyEndDate);
            }
            // ----- UPD 2011/07/27 ----- <<<<<

            return selectTxt;
        }
        #endregion // Where文の作成

        #region [CopyToCampaignSalesWorkFromReader処理 呼出]
        /// <summary>
        /// クラス格納処理 Reader → CopyToCampaignSalesWorkFromReader
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="CndtnWork">CndtnWork</param>
        /// <returns>CopyToCampaignResultWork</returns>
        /// <remarks>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        public CampaignstRsltListResultWork CopyToCampaignSalesWorkFromReader(ref SqlDataReader myReader, CampaignstRsltListPrtWork CndtnWork)
        {
            return this.CopyToCampaignSalesWorkFromReaderProc(ref myReader, CndtnWork);
        }
        #endregion  // CopyToCampaignSalesWorkFromReader処理 呼出

        #region [CopyToCampaignSalesWorkFromReaderProc処理]
        /// <summary>
        /// クラス格納処理 Reader → CopyToCampaignSalesWorkFromReaderProc
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="CndtnWork">CndtnWork</param>
        /// <returns>CopyToCampaignResultWork</returns>
        /// <remarks>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private CampaignstRsltListResultWork CopyToCampaignSalesWorkFromReaderProc(ref SqlDataReader myReader, CampaignstRsltListPrtWork CndtnWork)
        {
            CampaignstRsltListResultWork wkCampaignstRsltListResultWork = new CampaignstRsltListResultWork();

            #region クラスへ格納
            wkCampaignstRsltListResultWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCD")); // 実績計上拠点コード
            wkCampaignstRsltListResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNM1")); // 拠点ガイド略称
            wkCampaignstRsltListResultWork.SalesEmployeeCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODE")).ToString("0000"); // 販売区分コード
            wkCampaignstRsltListResultWork.EmployeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAME")); // 名称
            wkCampaignstRsltListResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD")); // 商品メーカーコード
            wkCampaignstRsltListResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAME")); // 商品メーカー名称
            wkCampaignstRsltListResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNO")); // 商品番号
            wkCampaignstRsltListResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANA")); // 商品名称カナ
            wkCampaignstRsltListResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODE")); // BL商品コード
            wkCampaignstRsltListResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAME")); // BL商品コード名称（半角）
            wkCampaignstRsltListResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODE")); // BLグループコード
            wkCampaignstRsltListResultWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAME")); // BLグループコードカナ名称
            wkCampaignstRsltListResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF")); // 対象出荷数
            wkCampaignstRsltListResultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF")); // 売上金額（税抜き）
            wkCampaignstRsltListResultWork.SalesProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GRSPROFITRF")); // 粗利金額
            wkCampaignstRsltListResultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF")); // 計上日付
            wkCampaignstRsltListResultWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF")); // キャンペーンコード
            wkCampaignstRsltListResultWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF")); // キャンペーンコード名称
            wkCampaignstRsltListResultWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTADATERF")); // 適用開始日
            wkCampaignstRsltListResultWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF")); // 適用終了日
            wkCampaignstRsltListResultWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF")); // 売上伝票区分（明細） // ADD 2011/07/27
            #endregion

            return wkCampaignstRsltListResultWork;
        }
        #endregion // CopyToCampaignSalesWorkFromReaderProc処理



        #region [販売区分別用目標設定Select文]
        /// <summary>
        /// 販売区分別用目標設定SELECT文 生成処理
        /// <summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>販売区分別用目標設定SELECT文</returns>
        /// <br>Note       : 販売区分別用目標設定SELECT文を作成して戻します</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        /// </summary>
        /// </summary>
        public string MakeTargetSelectString(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            return this.MakeTargetSelectStringProc(ref sqlCommand, CndtnWork);
        }
        #endregion // 販売区分別用目標設定Select文

        #region [販売区分別用目標設定Select文生成処理]
        /// <summary>
        /// 販売区分別用目標設定SELECT文 生成処理
        /// <summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>販売区分別用目標設定SELECT文</returns>
        /// <br>Note       : 販売区分別用目標設定SELECT文を作成して戻します</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        /// </summary>
        /// </summary>
        private string MakeTargetSelectStringProc(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            string selectTxt = string.Empty;

            #region SELECT文
            selectTxt += "SELECT " + Environment.NewLine;
            selectTxt += "  CAMPTAR.CAMPAIGNCODERF " + Environment.NewLine;              // キャンペーンコード
            selectTxt += "  ,CAMPTAR.TARGETCONTRASTCDRF " + Environment.NewLine;         // 目標対比区分
            selectTxt += "  ,CAMPTAR.SECTIONCODERF " + Environment.NewLine;              // 拠点コード
            selectTxt += "  ,CAMPTAR.SALESCODERF " + Environment.NewLine;                // 販売区分コード
            selectTxt += "  ,CAMPTAR.BLGROUPCODERF " + Environment.NewLine;              // BLグループコード
            selectTxt += "  ,CAMPTAR.BLGOODSCODERF " + Environment.NewLine;              // BL商品コード
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY1RF " + Environment.NewLine;        // 売上目標金額1
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY2RF " + Environment.NewLine;        // 売上目標金額2
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY3RF " + Environment.NewLine;        // 売上目標金額3
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY4RF " + Environment.NewLine;        // 売上目標金額4
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY5RF " + Environment.NewLine;        // 売上目標金額5
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY6RF " + Environment.NewLine;        // 売上目標金額6
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY7RF " + Environment.NewLine;        // 売上目標金額7
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY8RF " + Environment.NewLine;        // 売上目標金額8
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY9RF " + Environment.NewLine;        // 売上目標金額9
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY10RF " + Environment.NewLine;       // 売上目標金額10
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY11RF " + Environment.NewLine;       // 売上目標金額11
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY12RF " + Environment.NewLine;       // 売上目標金額12
            selectTxt += "  ,CAMPTAR.MONTHLYSALESTARGETRF " + Environment.NewLine;       // 売上月間目標金額
            selectTxt += "  ,CAMPTAR.TERMSALESTARGETRF " + Environment.NewLine;          // 売上期間目標金額
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT1RF " + Environment.NewLine;       // 売上目標粗利額1
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT2RF " + Environment.NewLine;       // 売上目標粗利額2
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT3RF " + Environment.NewLine;       // 売上目標粗利額3
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT4RF " + Environment.NewLine;       // 売上目標粗利額4
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT5RF " + Environment.NewLine;       // 売上目標粗利額5
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT6RF " + Environment.NewLine;       // 売上目標粗利額6
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT7RF " + Environment.NewLine;       // 売上目標粗利額7
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT8RF " + Environment.NewLine;       // 売上目標粗利額8
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT9RF " + Environment.NewLine;       // 売上目標粗利額9
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT10RF " + Environment.NewLine;      // 売上目標粗利額10
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT11RF " + Environment.NewLine;      // 売上目標粗利額11
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT12RF " + Environment.NewLine;      // 売上目標粗利額12
            selectTxt += "  ,CAMPTAR.MONTHLYSALESTARGETPROFITRF " + Environment.NewLine; // 売上月間目標粗利額
            selectTxt += "  ,CAMPTAR.TERMSALESTARGETPROFITRF " + Environment.NewLine;    // 売上期間目標粗利額
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT1RF " + Environment.NewLine;        // 売上目標数量1
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT2RF " + Environment.NewLine;        // 売上目標数量2
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT3RF " + Environment.NewLine;        // 売上目標数量3
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT4RF " + Environment.NewLine;        // 売上目標数量4
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT5RF " + Environment.NewLine;        // 売上目標数量5
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT6RF " + Environment.NewLine;        // 売上目標数量6
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT7RF " + Environment.NewLine;        // 売上目標数量7
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT8RF " + Environment.NewLine;        // 売上目標数量8
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT9RF " + Environment.NewLine;        // 売上目標数量9
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT10RF " + Environment.NewLine;       // 売上目標数量10
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT11RF " + Environment.NewLine;       // 売上目標数量11
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT12RF " + Environment.NewLine;       // 売上目標数量12
            selectTxt += "  ,CAMPTAR.MONTHLYSALESTARGETCOUNTRF " + Environment.NewLine;  // 売上月間目標数量
            selectTxt += "  ,CAMPTAR.TERMSALESTARGETCOUNTRF " + Environment.NewLine;     // 売上期間目標数量
            //selectTxt += "FROM CAMPAIGNTARGETRF AS CAMPTAR " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "FROM CAMPAIGNTARGETRF AS CAMPTAR WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07

            selectTxt += "WHERE " + Environment.NewLine;
            // 企業コード
            selectTxt += "  CAMPTAR.ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            // 論理削除区分
            selectTxt += "  AND CAMPTAR.LOGICALDELETECODERF=0 " + Environment.NewLine;

            // キャンペーンコード
            selectTxt += "  AND CAMPTAR.CAMPAIGNCODERF=@FINDCAMPAIGNCODE " + Environment.NewLine;
            SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);

            selectTxt += "  AND ( " + Environment.NewLine;

            selectTxt += "  CAMPTAR.TARGETCONTRASTCDRF=44 " + Environment.NewLine;

            selectTxt += "  OR CAMPTAR.TARGETCONTRASTCDRF=10) " + Environment.NewLine;
            #endregion

            return selectTxt;
        }
        #endregion // 販売区分別用目標設定Select文生成処理

        #region [CopyToCampaignTargetWorkFromReader処理 呼出]
        /// <summary>
        /// クラス格納処理 Reader → CopyToCampaignTargetWorkFromReader
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">paramWork</param>
        /// <returns>CopyToCampaignResultWork</returns>
        /// <remarks>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        public CampaignstRsltListResultWork CopyToCampaignTargetWorkFromReader(ref SqlDataReader myReader, CampaignstRsltListPrtWork paramWork)
        {
            return this.CopyToCampaignTargetWorkFromReaderProc(ref myReader, paramWork);
        }
        #endregion  // CopyToCampaignTargetWorkFromReader処理 呼出

        #region [CopyToCampaignTargetWorkFromReaderProc処理]
        /// <summary>
        /// クラス格納処理 Reader → CopyToCampaignTargetWorkFromReaderProc
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">paramWork</param>
        /// <returns>CopyToCampaignResultWork</returns>
        /// <remarks>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private CampaignstRsltListResultWork CopyToCampaignTargetWorkFromReaderProc(ref SqlDataReader myReader, CampaignstRsltListPrtWork paramWork)
        {
            CampaignstRsltListResultWork CampaignTargetWork = new CampaignstRsltListResultWork();

            #region クラスへ格納
            CampaignTargetWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF")); // キャンペーンコード
            CampaignTargetWork.TargetContrastCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETCONTRASTCDRF")); // 目標対比区分
            CampaignTargetWork.ManageSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); // 拠点コード
            CampaignTargetWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF")); // BLグループコード
            CampaignTargetWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // BL商品コード
            CampaignTargetWork.EmployeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF")).ToString("0000"); // 販売区分コード
            CampaignTargetWork.SalesTargetMoney1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY1RF")); // 売上目標金額1
            CampaignTargetWork.SalesTargetMoney2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY2RF")); // 売上目標金額2
            CampaignTargetWork.SalesTargetMoney3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY3RF")); // 売上目標金額3
            CampaignTargetWork.SalesTargetMoney4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY4RF")); // 売上目標金額4
            CampaignTargetWork.SalesTargetMoney5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY5RF")); // 売上目標金額5
            CampaignTargetWork.SalesTargetMoney6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY6RF")); // 売上目標金額6
            CampaignTargetWork.SalesTargetMoney7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY7RF")); // 売上目標金額7
            CampaignTargetWork.SalesTargetMoney8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY8RF")); // 売上目標金額8
            CampaignTargetWork.SalesTargetMoney9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY9RF")); // 売上目標金額9
            CampaignTargetWork.SalesTargetMoney10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY10RF")); // 売上目標金額10
            CampaignTargetWork.SalesTargetMoney11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY11RF")); // 売上目標金額11
            CampaignTargetWork.SalesTargetMoney12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY12RF")); // 売上目標金額12
            CampaignTargetWork.MonthlySalesTarget = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHLYSALESTARGETRF")); // 売上月間目標金額
            CampaignTargetWork.TermSalesTarget = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESTARGETRF")); // 売上期間目標金額
            CampaignTargetWork.SalesTargetProfit1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT1RF")); // 売上目標粗利額1
            CampaignTargetWork.SalesTargetProfit2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT2RF")); // 売上目標粗利額2
            CampaignTargetWork.SalesTargetProfit3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT3RF")); // 売上目標粗利額3
            CampaignTargetWork.SalesTargetProfit4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT4RF")); // 売上目標粗利額4
            CampaignTargetWork.SalesTargetProfit5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT5RF")); // 売上目標粗利額5
            CampaignTargetWork.SalesTargetProfit6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT6RF")); // 売上目標粗利額6
            CampaignTargetWork.SalesTargetProfit7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT7RF")); // 売上目標粗利額7
            CampaignTargetWork.SalesTargetProfit8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT8RF")); // 売上目標粗利額8
            CampaignTargetWork.SalesTargetProfit9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT9RF")); // 売上目標粗利額9
            CampaignTargetWork.SalesTargetProfit10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT10RF")); // 売上目標粗利額10
            CampaignTargetWork.SalesTargetProfit11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT11RF")); // 売上目標粗利額11
            CampaignTargetWork.SalesTargetProfit12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT12RF")); // 売上目標粗利額12
            CampaignTargetWork.MonthlySalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHLYSALESTARGETPROFITRF")); // 売上月間目標粗利額
            CampaignTargetWork.TermSalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESTARGETPROFITRF")); // 売上期間目標粗利額
            CampaignTargetWork.SalesTargetCount1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT1RF")); // 売上目標数量1
            CampaignTargetWork.SalesTargetCount2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT2RF")); // 売上目標数量2
            CampaignTargetWork.SalesTargetCount3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT3RF")); // 売上目標数量3
            CampaignTargetWork.SalesTargetCount4 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT4RF")); // 売上目標数量4
            CampaignTargetWork.SalesTargetCount5 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT5RF")); // 売上目標数量5
            CampaignTargetWork.SalesTargetCount6 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT6RF")); // 売上目標数量6
            CampaignTargetWork.SalesTargetCount7 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT7RF")); // 売上目標数量7
            CampaignTargetWork.SalesTargetCount8 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT8RF")); // 売上目標数量8
            CampaignTargetWork.SalesTargetCount9 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT9RF")); // 売上目標数量9
            CampaignTargetWork.SalesTargetCount10 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT10RF")); // 売上目標数量10
            CampaignTargetWork.SalesTargetCount11 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT11RF")); // 売上目標数量11
            CampaignTargetWork.SalesTargetCount12 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT12RF")); // 売上目標数量12
            CampaignTargetWork.MonthlySalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHLYSALESTARGETCOUNTRF")); // 売上月間目標数量
            CampaignTargetWork.TermSalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TERMSALESTARGETCOUNTRF")); // 売上期間目標数量
            #endregion

            return CampaignTargetWork;
        }
        #endregion // CopyToCampaignTargetWorkFromReaderProc処理

    }
}
