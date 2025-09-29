//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン実績表
// プログラム概要   : キャンペーン実績表　地区別用ｓｑｌ
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/05/19  修正内容 : 新規作成
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
    class MTtlCampaignArea : MTtlCampaignBase, IMTtlCampaign
    {
        #region [判別用フラグ宣言]
        private bool bAddUpSecCode = false;  // 実績計上拠点コード
        private bool bBelongSecCode = false; // 管理拠点コード
        private bool bCustomerCode = false;  // 得意先コード
        private bool bBLGroupCode = false;   // BLグループコード
        private bool bBLGoodsCode = false;   // BL商品コード
        private bool bGoodsMakerCd = false;  // 商品メーカーコード
        private bool bGoodsNo = false;       // 商品番号
        #endregion  //[判別用フラグ宣言]

        #region [会計年度テーブル生成部品取得]
        private FinYearTableGenerator _finYearTableGenerator;

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
        #endregion

        #region [地区別用売上Select文]
        /// <summary>
        /// 地区別用売上SELECT文 生成処理
        /// </summary>
        /// <param name="sqlConnection">sqlConnectionオブジェクト</param>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>地区別用SELECT文</returns>
        /// <br>Note       : 地区別用SELECT文を作成して戻します</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/05/19</br>

        public string MakeSalesSelectString(ref SqlConnection sqlConnection, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            return this.MakeSalesSelectStringProc(ref sqlConnection, ref sqlCommand, CndtnWork);
        }
        #endregion  // 地区別用売上Select文

        #region [地区別用売上Select文生成処理]
        /// <summary>
        /// 地区別用売上SELECT文 生成処理
        /// </summary>
        /// <param name="sqlConnection">sqlConnectionオブジェクト</param>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>地区別用売上SELECT文</returns>
        /// <br>Note       : 地区別用売上SELECT文を作成して戻します</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/05/19</br>
        private string MakeSalesSelectStringProc(ref SqlConnection sqlConnection, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            #region [判別用フラグ]
            //実績計上拠点コード
            if (CndtnWork.OutputSort != 3)
            {
                bAddUpSecCode = true;
            }

            // 管理拠点コード
            if (CndtnWork.OutputSort == 3)
            {
                bBelongSecCode = true;
            }

            // 得意先コード
            if (CndtnWork.OutputSort == 1)
            {
                bCustomerCode = true;
            }

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

            // 商品メーカーコード
            if (CndtnWork.PrintType != 1)
            {
                bGoodsMakerCd = true;
            }

            // 商品番号
            if (CndtnWork.Detail == 0)
            {
                bGoodsNo = true;
            }
            #endregion

            string selectTxt = string.Empty;

            if (CndtnWork.PrintType == 1)
            {
                _finYearTableGenerator = this.GetFinYearTableGenerator(CndtnWork.EnterpriseCode, ref sqlConnection);
            }

            #region SELECT文
            selectTxt += "SELECT DISTINCT " + Environment.NewLine;
            selectTxt += "  B.SALESSLIPNUMRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESROWNORF " + Environment.NewLine;
            selectTxt += "  ,B.SALESSLIPCDDTLRF " + Environment.NewLine; // ADD 2011/07/27
            selectTxt += "  ,A.RESULTSADDUPSECCDRF " + Environment.NewLine;
            selectTxt += "  ,C.SECTIONGUIDESNMRF AS SECTIONGUIDESNMRF1" + Environment.NewLine;
            selectTxt += "  ,A.CUSTOMERCODERF " + Environment.NewLine;
            selectTxt += "  ,E.CUSTOMERSNMRF " + Environment.NewLine;
            selectTxt += "  ,A.SALESDATERF " + Environment.NewLine;
            selectTxt += "  ,E.MNGSECTIONCODERF " + Environment.NewLine;
            selectTxt += "  ,G.SECTIONGUIDESNMRF AS SECTIONGUIDESNMRF2" + Environment.NewLine;
            selectTxt += "  ,A.SALESAREACODERF " + Environment.NewLine;
            selectTxt += "  ,R.GUIDENAMERF " + Environment.NewLine;
            selectTxt += "  ,B.GOODSMAKERCDRF " + Environment.NewLine;
            selectTxt += "  ,B.GOODSNORF " + Environment.NewLine;
            selectTxt += "  ,B.GOODSNAMEKANARF " + Environment.NewLine;
            selectTxt += "  ,B.BLGOODSCODERF " + Environment.NewLine;
            selectTxt += "  ,D.BLGOODSHALFNAMERF " + Environment.NewLine;
            selectTxt += "  ,B.BLGROUPCODERF " + Environment.NewLine;
            selectTxt += "  ,F.BLGROUPKANANAMERF " + Environment.NewLine;
            selectTxt += "  ,B.SHIPMENTCNTRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESMONEYTAXEXCRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESMONEYTAXEXCRF - B.COSTRF AS GRSPROFITRF " + Environment.NewLine;
            selectTxt += "  ,J.CAMPAIGNCODERF " + Environment.NewLine;
            selectTxt += "  ,J.CAMPAIGNNAMERF " + Environment.NewLine;
            selectTxt += "  ,H.MAKERNAMERF " + Environment.NewLine;
            selectTxt += "  ,J.APPLYSTADATERF " + Environment.NewLine;
            selectTxt += "  ,J.APPLYENDDATERF " + Environment.NewLine;

            selectTxt += "FROM SALESHISTORYRF AS A WITH (READUNCOMMITTED) " + Environment.NewLine;
            selectTxt += "LEFT JOIN SALESHISTDTLRF AS B WITH (READUNCOMMITTED) " + Environment.NewLine;
            selectTxt += "ON A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF " + Environment.NewLine;
            selectTxt += "AND A.SALESSLIPNUMRF = B.SALESSLIPNUMRF " + Environment.NewLine;

            //selectTxt += "LEFT JOIN CUSTOMERRF AS E " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN CUSTOMERRF AS E WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON E.ENTERPRISECODERF = A.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND E.CUSTOMERCODERF = A.CUSTOMERCODERF " + Environment.NewLine;
            selectTxt += "AND E.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            //selectTxt += "LEFT JOIN SECINFOSETRF AS C " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN SECINFOSETRF AS C WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON A.ENTERPRISECODERF = C.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND C.SECTIONCODERF = A.RESULTSADDUPSECCDRF " + Environment.NewLine;
            selectTxt += "AND C.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            //selectTxt += "LEFT JOIN BLGOODSCDURF AS D " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN BLGOODSCDURF AS D WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON D.ENTERPRISECODERF = A.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND D.BLGOODSCODERF = B.BLGOODSCODERF " + Environment.NewLine;
            selectTxt += "AND D.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            //selectTxt += "LEFT JOIN BLGROUPURF AS F " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN BLGROUPURF AS F WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON F.ENTERPRISECODERF = A.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND F.BLGROUPCODERF = B.BLGROUPCODERF " + Environment.NewLine;
            selectTxt += "AND F.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            //selectTxt += "LEFT JOIN SECINFOSETRF AS G " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN SECINFOSETRF AS G WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON G.ENTERPRISECODERF = A.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND G.SECTIONCODERF = E.MNGSECTIONCODERF " + Environment.NewLine;
            selectTxt += "AND G.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            selectTxt += "LEFT JOIN MAKERURF AS H " + Environment.NewLine;
            selectTxt += "ON H.ENTERPRISECODERF = A.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND H.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
            selectTxt += "AND H.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            //selectTxt += "LEFT JOIN USERGDBDURF AS R " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN USERGDBDURF AS R WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON R.ENTERPRISECODERF = A.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND R.GUIDECODERF = A.SALESAREACODERF " + Environment.NewLine;
            selectTxt += "AND R.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            //selectTxt += "LEFT JOIN CAMPAIGNSTRF AS J " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN CAMPAIGNSTRF AS J WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON J.ENTERPRISECODERF = A.ENTERPRISECODERF " + Environment.NewLine;
            // ----- ADD 2012/04/09 chenyd for Redmine#29314 ----- >>>>>
            // キャンペーンコード
            selectTxt += "AND J.CAMPAIGNCODERF = @FINDCAMPAIGNCODE1  " + Environment.NewLine;
            SqlParameter paraCampaignCode1 = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE1", SqlDbType.Int);
            paraCampaignCode1.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);
            // ----- ADD 2012/04/09 chenyd for Redmine#29314 ----- <<<<<
            //selectTxt += "LEFT JOIN CAMPAIGNMNGRF AS L " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN CAMPAIGNMNGRF AS L WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON L.ENTERPRISECODERF = A.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND L.CAMPAIGNCODERF = J.CAMPAIGNCODERF " + Environment.NewLine;            

            #region WHERE
            selectTxt += MakeWhereString(ref sqlCommand, CndtnWork) + Environment.NewLine;
            #endregion

            selectTxt += " AND ((J.CAMPAIGNOBJDIVRF = 1 " + Environment.NewLine;
            selectTxt += " AND A.CUSTOMERCODERF IN(  " + Environment.NewLine;
            selectTxt += " SELECT  " + Environment.NewLine;
            selectTxt += " CUSTOMERCODERF " + Environment.NewLine;
            selectTxt += " FROM " + Environment.NewLine;
            //selectTxt += " CAMPAIGNLINKRF " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += " CAMPAIGNLINKRF WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += " WHERE " + Environment.NewLine;

            selectTxt += " ENTERPRISECODERF = @FINDENTERPRISECODE3 " + Environment.NewLine;
            SqlParameter paraEnterpriseCode3 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE3", SqlDbType.NChar);
            paraEnterpriseCode3.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            // キャンペーンコード
            selectTxt += "  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE3 " + Environment.NewLine;
            SqlParameter paraCampaignCd3 = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE3", SqlDbType.Int);
            paraCampaignCd3.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);

            selectTxt += " AND LOGICALDELETECODERF = 0)) " + Environment.NewLine;
            selectTxt += " OR (J.CAMPAIGNOBJDIVRF <> 1)) " + Environment.NewLine;

            selectTxt += " AND ((L.CAMPAIGNSETTINGKINDRF = 1 AND L.GOODSNORF = B.GOODSNORF AND L.GOODSMAKERCDRF = B.GOODSMAKERCDRF)" + Environment.NewLine;
            selectTxt += "   OR (L.CAMPAIGNSETTINGKINDRF = 2 AND L.GOODSMAKERCDRF = B.GOODSMAKERCDRF AND L.BLGOODSCODERF = B.BLGOODSCODERF)  " + Environment.NewLine;
            selectTxt += "   OR (L.CAMPAIGNSETTINGKINDRF = 3 AND L.GOODSMAKERCDRF = B.GOODSMAKERCDRF AND L.BLGROUPCODERF = B.BLGROUPCODERF)  " + Environment.NewLine;
            selectTxt += "   OR (L.CAMPAIGNSETTINGKINDRF = 4 AND L.GOODSMAKERCDRF = B.GOODSMAKERCDRF)  " + Environment.NewLine;
            selectTxt += "   OR (L.CAMPAIGNSETTINGKINDRF = 5 AND L.BLGOODSCODERF = B.BLGOODSCODERF)  " + Environment.NewLine;
            selectTxt += "   OR (L.CAMPAIGNSETTINGKINDRF = 6 AND L.SALESCODERF = B.SALESCODERF)  " + Environment.NewLine;
            selectTxt += " ) " + Environment.NewLine;

            // ----- ADD 2011/07/11 ----->>>>>
            if (CndtnWork.OutputSort == 3)
            {
                selectTxt += " AND ((L.SECTIONCODERF <> '00' AND E.MNGSECTIONCODERF = L.SECTIONCODERF) OR (L.SECTIONCODERF = '00')) " + Environment.NewLine;
            }
            else
            {
                selectTxt += " AND ((L.SECTIONCODERF <> '00' AND A.RESULTSADDUPSECCDRF = L.SECTIONCODERF) OR (L.SECTIONCODERF = '00')) " + Environment.NewLine;
            }
            // ----- ADD 2011/07/11 -----<<<<<

            #region ORDER BY
            selectTxt += "  ORDER BY " + Environment.NewLine;
            if (bBelongSecCode == true)
            {
                selectTxt += "    E.MNGSECTIONCODERF, " + Environment.NewLine;
            }
            if (CndtnWork.OutputSort == 2)
            {
                selectTxt += "    A.SALESAREACODERF " + Environment.NewLine;
                selectTxt += "    ,A.RESULTSADDUPSECCDRF " + Environment.NewLine;
            }
            else
            {
                if (bAddUpSecCode == true)
                {
                    selectTxt += "    A.RESULTSADDUPSECCDRF, " + Environment.NewLine;
                }
                selectTxt += "    A.SALESAREACODERF " + Environment.NewLine;
            }
            if (bCustomerCode == true)
            {
                selectTxt += "    ,A.CUSTOMERCODERF " + Environment.NewLine;
            }
            if (bBLGroupCode == true)
            {
                selectTxt += "    ,B.BLGROUPCODERF " + Environment.NewLine;
            }
            if (bBLGoodsCode == true)
            {
                selectTxt += "    ,B.BLGOODSCODERF " + Environment.NewLine;
            }
            if (bGoodsMakerCd == true)
            {
                selectTxt += "    ,B.GOODSMAKERCDRF " + Environment.NewLine;
            }
            if (bGoodsNo == true)
            {
                selectTxt += "    ,B.GOODSNORF " + Environment.NewLine;
            }
            #endregion
            #endregion

            return selectTxt;
        }
        #endregion  // 担当者別用売上Select文生成処理

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
            #region WHERE
            // 企業コード
            selectTxt += "WHERE " + Environment.NewLine;
            selectTxt += "  A.ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            // 論理削除区分
            selectTxt += "  AND A.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            selectTxt += "  AND B.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            selectTxt += "  AND L.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            // 受注ステータス
            selectTxt += "  AND A.ACPTANODRSTATUSRF = 30 " + Environment.NewLine;

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

            // 地区コード
            if (CndtnWork.AreaCodeSt != 0)
            {
                selectTxt += "  AND A.SALESAREACODERF >= @FINDEAREACDST " + Environment.NewLine;
                SqlParameter paraAreaCdSt = sqlCommand.Parameters.Add("@FINDEAREACDST", SqlDbType.Int);
                paraAreaCdSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.AreaCodeSt);
            }

            if (CndtnWork.AreaCodeEd != 0)
            {
                selectTxt += "  AND A.SALESAREACODERF <= @FINDEAREACDED " + Environment.NewLine;
                SqlParameter paraAreaCdEd = sqlCommand.Parameters.Add("@FINDEAREACDED", SqlDbType.Int);
                paraAreaCdEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.AreaCodeEd);
            }

            // キャンペーンコード
            selectTxt += "  AND J.CAMPAIGNCODERF = @FINDCAMPAIGNCD " + Environment.NewLine;
            SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCD", SqlDbType.Int);
            paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);

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

            // ガイド区分
            selectTxt += "  AND R.USERGUIDEDIVCDRF = 21 " + Environment.NewLine;

            #endregion
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
        /// <br>Programmer : 丁建雄</br>
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
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private CampaignstRsltListResultWork CopyToCampaignSalesWorkFromReaderProc(ref SqlDataReader myReader, CampaignstRsltListPrtWork CndtnWork)
        {
            CampaignstRsltListResultWork wkCampaignstRsltListResultWork = new CampaignstRsltListResultWork();

            #region クラスへ格納
            wkCampaignstRsltListResultWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF")); // 実績計上拠点コード
            wkCampaignstRsltListResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF1")); // 拠点ガイド略称
            wkCampaignstRsltListResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF")); // 得意先コード
            wkCampaignstRsltListResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF")); // 得意先略称
            wkCampaignstRsltListResultWork.ManageSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF")); // 管理拠点コード
            wkCampaignstRsltListResultWork.ManageSectionSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF2")); // 拠点ガイド略称
            wkCampaignstRsltListResultWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF")); // 販売エリアコード
            wkCampaignstRsltListResultWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF")); // ユーザーガイド名称
            wkCampaignstRsltListResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); // 商品メーカーコード
            wkCampaignstRsltListResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF")); // 商品メーカー名称
            wkCampaignstRsltListResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF")); // 商品番号
            wkCampaignstRsltListResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF")); // 商品名称カナ
            wkCampaignstRsltListResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // BL商品コード
            wkCampaignstRsltListResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF")); // BL商品コード名称（半角）
            wkCampaignstRsltListResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF")); // BLグループコード
            wkCampaignstRsltListResultWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF")); // BLグループコードカナ名称
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



        #region [地区別用目標設定Select文]
        /// <summary>
        /// 地区別用目標設定SELECT文 生成処理
        /// <summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>地区別用目標設定SELECT文</returns>
        /// <br>Note       : 地区別用目標設定SELECT文を作成して戻します</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/05/19</br>
        /// </summary>
        /// </summary>
        public string MakeTargetSelectString(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            return this.MakeTargetSelectStringProc(ref sqlCommand, CndtnWork);
        }
        #endregion // 地区別用目標設定Select文

        #region [地区別用目標設定Select文生成処理]
        /// <summary>
        /// 地区別用目標設定SELECT文 生成処理
        /// <summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>地区別用目標設定SELECT文</returns>
        /// <br>Note       : 地区別用目標設定SELECT文を作成して戻します</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/05/19</br>
        /// </summary>
        /// </summary>
        private string MakeTargetSelectStringProc(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            string selectTxt = string.Empty;

            #region SELECT文
            selectTxt += "SELECT " + Environment.NewLine;
            selectTxt += "  CAMPTAR.CAMPAIGNCODERF " + Environment.NewLine;             // キャンペーンコード
            selectTxt += "  ,CAMPTAR.TARGETCONTRASTCDRF " + Environment.NewLine;         // 目標対比区分
            selectTxt += "  ,CAMPTAR.SECTIONCODERF " + Environment.NewLine;              // 拠点コード
            selectTxt += "  ,CAMPTAR.CUSTOMERCODERF " + Environment.NewLine;             // 得意先コード
            selectTxt += "  ,CAMPTAR.SALESAREACODERF " + Environment.NewLine;             // 販売エリアコード
            selectTxt += "  ,CAMPTAR.BLGROUPCODERF " + Environment.NewLine;             // BLグループコード
            selectTxt += "  ,CAMPTAR.BLGOODSCODERF " + Environment.NewLine;             // BL商品コード
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
            selectTxt += "  ,CAMPTAR.MONTHLYSALESTARGETPROFITRF " + Environment.NewLine;       // 売上月間目標粗利額
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

            selectTxt += "  (CAMPTAR.TARGETCONTRASTCDRF=32) " + Environment.NewLine;

            selectTxt += "  OR CAMPTAR.TARGETCONTRASTCDRF=10) " + Environment.NewLine;
            #endregion

            return selectTxt;
        }
        #endregion // 地区別用目標設定Select文生成処理

        #region [CopyToCampaignTargetWorkFromReader処理 呼出]
        /// <summary>
        /// クラス格納処理 Reader → CopyToCampaignTargetWorkFromReader
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">paramWork</param>
        /// <returns>CopyToCampaignResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 丁建雄</br>
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
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private CampaignstRsltListResultWork CopyToCampaignTargetWorkFromReaderProc(ref SqlDataReader myReader, CampaignstRsltListPrtWork paramWork)
        {
            CampaignstRsltListResultWork CampaignTargetWork = new CampaignstRsltListResultWork();

            #region クラスへ格納
            CampaignTargetWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF")); // キャンペーンコード
            CampaignTargetWork.TargetContrastCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETCONTRASTCDRF")); // 目標対比区分
            CampaignTargetWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); // 拠点コード
            CampaignTargetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF")); // 得意先コード
            CampaignTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF")); // 販売エリアコード
            CampaignTargetWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF")); // BLグループコード
            CampaignTargetWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // BL商品コード
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

        #region Private Method
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
        #endregion
    }
}
