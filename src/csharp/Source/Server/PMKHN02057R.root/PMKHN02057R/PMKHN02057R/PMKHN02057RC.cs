//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン実績表
// プログラム概要   : キャンペーン実績表　商品別用ｓｑｌ
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
// 作 成 日  2011/07/11  修正内容 : Redmine 仕様変更 #22860,#22915 の対応
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
    class MTtlCampaignGoods : MTtlCampaignBase, IMTtlCampaign
    {
        #region [判別用フラグ宣言]
        private bool bBLGroupCode = false;   // BLグループコード
        private bool bBLGoodsCode = false;   // BL商品コード
        private bool bGoodsNo = false;       // 商品番号
        private bool bGoodsMakerCd = false;  // 商品メーカーコード
        private FinYearTableGenerator _finYearTableGenerator = null;
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

        #region [商品別用売上Select文]
        /// <summary>
        /// 商品別用売上SELECT文 生成処理
        /// </summary>
        /// <param name="sqlConnection">SqlConnectionオブジェクト</param>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>商品別用SELECT文</returns>
        /// <remarks>
        /// <br>Note       : 商品別用SELECT文を作成して戻します</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        public string MakeSalesSelectString(ref SqlConnection sqlConnection, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            return this.MakeSalesSelectStringProc(ref sqlConnection, ref sqlCommand, CndtnWork);
        }
        #endregion  // 商品別用売上Select文

        #region [商品別用売上Select文生成処理]
        /// <summary>
        /// 商品別用売上SELECT文 生成処理
        /// </summary>
        /// <param name="sqlConnection">SqlConnectionオブジェクト</param>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>商品別用売上SELECT文</returns>
        /// <remarks>
        /// <br>Note       : 商品別用売上SELECT文を作成して戻します</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private string MakeSalesSelectStringProc(ref SqlConnection sqlConnection, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            // 印刷タイプが「期間」の場合
            if (CndtnWork.PrintType == 1)
            {
                // 会計年度テーブル生成部品取得
                _finYearTableGenerator = this.GetFinYearTableGenerator(CndtnWork.EnterpriseCode, ref sqlConnection);
            }

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

            // 商品メーカーコード
            if (CndtnWork.PrintType != 1)
            {
                bGoodsMakerCd = true;
            }
            #endregion

            string selectTxt = string.Empty;

            #region SELECT文
            selectTxt += "SELECT DISTINCT " + Environment.NewLine;
            selectTxt += "  B.SALESSLIPNUMRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESROWNORF " + Environment.NewLine;
            selectTxt += "  ,B.SALESSLIPCDDTLRF " + Environment.NewLine; // ADD 2011/07/27
            selectTxt += "  ,A.RESULTSADDUPSECCDRF " + Environment.NewLine;              // 実績計上拠点コード
            selectTxt += "  ,A.CUSTOMERCODERF " + Environment.NewLine;              // 得意先コード
            selectTxt += "  ,A.SALESDATERF " + Environment.NewLine;
            selectTxt += "  ,B.GOODSMAKERCDRF " + Environment.NewLine;             // 商品メーカーコード
            selectTxt += "  ,B.GOODSNORF " + Environment.NewLine;              // 商品番号
            selectTxt += "  ,B.GOODSNAMEKANARF " + Environment.NewLine;              // 商品名称カナ
            selectTxt += "  ,B.BLGOODSCODERF " + Environment.NewLine;        // BL商品コード
            selectTxt += "  ,B.BLGROUPCODERF " + Environment.NewLine;        // BLグループコード
            selectTxt += "  ,B.SHIPMENTCNTRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESMONEYTAXEXCRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESMONEYTAXEXCRF - B.COSTRF AS GRSPROFITRF " + Environment.NewLine;             
            selectTxt += "  ,C.SECTIONGUIDESNMRF AS SECTIONGUIDESNMRF1 " + Environment.NewLine;        // 拠点ガイド略称
            selectTxt += "  ,D.CUSTOMERSNMRF " + Environment.NewLine;       // 得意先略称
            selectTxt += "  ,G.BLGOODSHALFNAMERF " + Environment.NewLine;          // BL商品コード名称（半角）
            selectTxt += "  ,H.BLGROUPKANANAMERF " + Environment.NewLine;       // BLグループコードカナ名称
            selectTxt += "  ,I.MAKERNAMERF " + Environment.NewLine;       // ﾒｰｶｰ名称
            selectTxt += "  ,J.CAMPAIGNCODERF " + Environment.NewLine;       // キャンペーンコード
            selectTxt += "  ,J.CAMPAIGNNAMERF " + Environment.NewLine;       // キャンペーンコード名称
            selectTxt += "  ,J.CAMPEXECSECCODERF " + Environment.NewLine;       // キャンペーン実施拠点コード
            selectTxt += "  ,J.CAMPAIGNOBJDIVRF " + Environment.NewLine;       // キャンペーン対象区分
            selectTxt += "  ,J.APPLYSTADATERF " + Environment.NewLine;       // 適用開始日
            selectTxt += "  ,J.APPLYENDDATERF " + Environment.NewLine;       // 適用終了日
            //selectTxt += "  ,L.SECTIONCODERF " + Environment.NewLine;      // キャンペーン実施拠点コード　// DEL 2011/07/05
            // 売上履歴データ
            selectTxt += "FROM SALESHISTORYRF AS A WITH (READUNCOMMITTED) " + Environment.NewLine;
            
            #region 売上履歴明細データ
            // 売上履歴明細データ
            selectTxt += "LEFT JOIN SALESHISTDTLRF AS B WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 企業コード
            selectTxt += "ON A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
            // 受注ステータス
            selectTxt += "AND A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF " + Environment.NewLine;
            // 売上伝票番号
            selectTxt += "AND A.SALESSLIPNUMRF = B.SALESSLIPNUMRF " + Environment.NewLine;
            // 論理削除区分
            selectTxt += "AND A.LOGICALDELETECODERF = B.LOGICALDELETECODERF " + Environment.NewLine;
            #endregion

            #region 拠点情報設定マスタ
            // 拠点情報設定マスタ
            //selectTxt += "LEFT JOIN  SECINFOSETRF AS C " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN  SECINFOSETRF AS C WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            // 企業コード
            selectTxt += "ON A.ENTERPRISECODERF = C.ENTERPRISECODERF " + Environment.NewLine;
            // 拠点コード
            selectTxt += "AND A.RESULTSADDUPSECCDRF = C.SECTIONCODERF " + Environment.NewLine;
            // 論理削除区分
            selectTxt += "AND A.LOGICALDELETECODERF = C.LOGICALDELETECODERF " + Environment.NewLine;
            #endregion

            #region 得意先マスタ
            // 得意先マスタ
            //selectTxt += "LEFT JOIN CUSTOMERRF AS D " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN CUSTOMERRF AS D WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            // 企業コード
            selectTxt += "ON A.ENTERPRISECODERF = D.ENTERPRISECODERF " + Environment.NewLine;
            // 得意先コード
            selectTxt += "AND A.CUSTOMERCODERF = D.CUSTOMERCODERF " + Environment.NewLine;
            // 論理削除区分
            selectTxt += "AND A.LOGICALDELETECODERF = D.LOGICALDELETECODERF " + Environment.NewLine;
            #endregion

            #region ＢＬ商品コードマスタ(ユーザー)
            // ＢＬ商品コードマスタ(ユーザー)
            //selectTxt += "LEFT JOIN BLGOODSCDURF AS G " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN BLGOODSCDURF AS G WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            // 企業コード
            selectTxt += "ON B.ENTERPRISECODERF = G.ENTERPRISECODERF " + Environment.NewLine;
            // BL商品コード
            selectTxt += "AND B.BLGOODSCODERF = G.BLGOODSCODERF " + Environment.NewLine;
            // 論理削除区分
            selectTxt += "AND B.LOGICALDELETECODERF = G.LOGICALDELETECODERF " + Environment.NewLine;
            #endregion

            #region BLグループマスタ（ユーザー登録分）
            // BLグループマスタ（ユーザー登録分）
            //selectTxt += "LEFT JOIN BLGROUPURF AS H " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN BLGROUPURF AS H WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            // 企業コード
            selectTxt += "ON B.ENTERPRISECODERF = H.ENTERPRISECODERF " + Environment.NewLine;
            // BLグループコード
            selectTxt += "AND B.BLGROUPCODERF = H.BLGROUPCODERF " + Environment.NewLine;
            // 論理削除区分
            selectTxt += "AND B.LOGICALDELETECODERF = H.LOGICALDELETECODERF " + Environment.NewLine;
            #endregion

            #region メーカーマスタ
            // メーカーマスタ
            //selectTxt += "LEFT JOIN MAKERURF AS I " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN MAKERURF AS I WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            // 企業コード
            selectTxt += "ON B.ENTERPRISECODERF = I.ENTERPRISECODERF " + Environment.NewLine;
            // 商品メーカーコード
            selectTxt += "AND B.GOODSMAKERCDRF = I.GOODSMAKERCDRF " + Environment.NewLine;
            // 論理削除区分
            selectTxt += "AND B.LOGICALDELETECODERF = I.LOGICALDELETECODERF " + Environment.NewLine;
            #endregion

            #region キャンペーン設定マスタ
            // キャンペーン設定マスタ
            //selectTxt += "LEFT JOIN CAMPAIGNSTRF AS J " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN CAMPAIGNSTRF AS J WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            // 企業コード
            selectTxt += "ON A.ENTERPRISECODERF = J.ENTERPRISECODERF " + Environment.NewLine;
            // 論理削除区分
            selectTxt += "AND A.LOGICALDELETECODERF = J.LOGICALDELETECODERF " + Environment.NewLine;
            // ----- ADD 2012/04/09 chenyd for Redmine#29314 ----- >>>>>
            // キャンペーンコード
            selectTxt += "AND J.CAMPAIGNCODERF = @FINDCAMPAIGNCODE1  " + Environment.NewLine;
            SqlParameter paraCampaignCode1 = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE1", SqlDbType.Int);
            paraCampaignCode1.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);
            // ----- ADD 2012/04/09 chenyd for Redmine#29314 ----- <<<<<
            #endregion

            #region キャンペーン管理マスタ
            //キャンペーン管理マスタ 
            //selectTxt += "LEFT JOIN CAMPAIGNMNGRF AS L " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN CAMPAIGNMNGRF AS L WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            // 企業コード
            selectTxt += "ON J.ENTERPRISECODERF = L.ENTERPRISECODERF " + Environment.NewLine;
            // キャンペーンコード 
            selectTxt += "AND J.CAMPAIGNCODERF = L.CAMPAIGNCODERF " + Environment.NewLine;
            // 論理削除区分
            selectTxt += "AND J.LOGICALDELETECODERF = L.LOGICALDELETECODERF " + Environment.NewLine;
            #endregion

            // Where文
            selectTxt += MakeWhereString(ref sqlCommand, CndtnWork);

            #region ORDER BY
            selectTxt += "  ORDER BY " + Environment.NewLine;

            selectTxt += "    A.RESULTSADDUPSECCDRF " + Environment.NewLine;
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
        #endregion  // 商品別用売上Select文生成処理

        #region [GroupByの作成]
        /// <summary>
        /// GroupByの作成
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="CndtnWork"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 商品別用売上GroupBy文を作成して戻します</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private string GroupByString(int flag, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            string groupByTxt = string.Empty;

            string tableNm = string.Empty;
            if (flag == 0)
            {
                tableNm = "SUB_C";
            }
            else
            {
                tableNm = "SUB_D";
            }

            #region GroupBy文
            groupByTxt += "  GROUP BY " + Environment.NewLine;
            // 実績計上拠点コード
            groupByTxt += tableNm + ".RESULTSADDUPSECCDRF " + Environment.NewLine;

            if (bBLGroupCode == true)
            {
                // グループコード
                groupByTxt += "," + tableNm + ".BLGROUPCODERF " + Environment.NewLine;
            }
            if (bBLGoodsCode == true)
            {
                // ＢＬコード
                groupByTxt += "," + tableNm + ".BLGOODSCODERF " + Environment.NewLine;
            }
            if (bGoodsMakerCd == true)
            {
                // 商品メーカーコード
                groupByTxt += "," + tableNm + ".GOODSMAKERCDRF " + Environment.NewLine;
            }
            if (bGoodsNo == true)
            {
                // 商品番号
                groupByTxt += "," + tableNm + ".GOODSNORF" + Environment.NewLine;
            }
            #endregion GroupBy文

            return groupByTxt;
        }
        #endregion // GroupByの作成

        #region [結合条件の作成]
        /// <summary>
        /// 結合条件の作成
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="CndtnWork"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 商品別用売上結合条件を作成して戻します</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private string JoinOnString(int flag, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            string joinOnTxt = string.Empty;

            string tableNm = string.Empty;
            if (flag == 0)
            {
                tableNm = "O";
            }
            else
            {
                tableNm = "P";
            }

            #region 結合条件
            // 拠点コード
            joinOnTxt += " ON A.RESULTSADDUPSECCDRF = " + tableNm + ".RESULTSADDUPSECCDRF " + Environment.NewLine;
            if (bBLGroupCode == true)
            {
                // グループコード
                joinOnTxt += " AND B.BLGROUPCODERF = " + tableNm + ".BLGROUPCODERF " + Environment.NewLine;
            }
            if (bBLGoodsCode == true)
            {
                // BLコード
                joinOnTxt += " AND B.BLGOODSCODERF = " + tableNm + ".BLGOODSCODERF " + Environment.NewLine;
            }
            if (bGoodsMakerCd == true)
            {
                // 商品メーカーコード
                joinOnTxt += " AND B.GOODSMAKERCDRF = " + tableNm + ".GOODSMAKERCDRF " + Environment.NewLine;
            }
            if (bGoodsNo == true)
            {
                // 商品番号
                joinOnTxt += " AND B.GOODSNORF = " + tableNm + ".GOODSNORF " + Environment.NewLine;
            }
            #endregion 結合条件

            return joinOnTxt;
        }
        #endregion // 結合条件の作成

        #region [Where文の作成]
        /// <summary>
        /// Where文の作成
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="CndtnWork"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 商品別用売上結合条件を作成して戻します</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            string selectTxt = string.Empty;

            #region Where文
            selectTxt += "WHERE " + Environment.NewLine;
            // 企業コード
            selectTxt += "A.ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            // 論理削除区分
            selectTxt += "  AND A.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            // 受注ステータス = 30(売上)
            selectTxt += "  AND A.ACPTANODRSTATUSRF = 30 " + Environment.NewLine;
            // 拠点コード
            if (CndtnWork.SectionCodes != null)
            {
                string strSec = string.Empty;
                foreach (string secCode in CndtnWork.SectionCodes)
                {
                    if (!strSec.Equals(string.Empty))
                    {
                        strSec += ",";
                    }
                    strSec += "'" + secCode + "'";
                }

                if (!strSec.Equals(string.Empty))
                {
                    selectTxt += "  AND A.RESULTSADDUPSECCDRF IN (" + strSec + ")" + Environment.NewLine;
                }
            }
            // 売上履歴データの売上日付
            

            // 売上履歴明細データの売上日付
            
            // 売上日付(キャンペーン適用日)
            // ----- UPD 2011/07/27 ----- >>>>>
            //if (CndtnWork.ApplyStaDate != 0)
            //{
            //    selectTxt += "  AND A.SALESDATERF >=@FINDSTAPPLYDATERF " + Environment.NewLine;
            //}
            //if (CndtnWork.ApplyEndDate != 0)
            //{
            //    selectTxt += "  AND A.SALESDATERF <=@FINDEDAPPLYDATERF " + Environment.NewLine;
            //}

            //selectTxt += "  AND A.SALESDATERF >= @FINDSALESDTST " + Environment.NewLine;

            //selectTxt += "  AND A.SALESDATERF <= @FINDSALESDTED " + Environment.NewLine;

            if (CndtnWork.ApplyStaDate != 0)
            {
                selectTxt += "  AND ((A.SALESDATERF >=@FINDSTAPPLYDATERF " + Environment.NewLine;
            }
            if (CndtnWork.ApplyEndDate != 0)
            {
                selectTxt += "  AND A.SALESDATERF <=@FINDEDAPPLYDATERF) " + Environment.NewLine;
            }

            selectTxt += "  OR (A.SALESDATERF >= @FINDSALESDTST " + Environment.NewLine;

            selectTxt += "  AND A.SALESDATERF <= @FINDSALESDTED)) " + Environment.NewLine;

            //if (CndtnWork.ApplyStaDate != 0)
            //{
            //    selectTxt += "  AND B.SALESDATERF >=@FINDSTAPPLYDATERF " + Environment.NewLine;
            //}
            //if (CndtnWork.ApplyEndDate != 0)
            //{
            //    selectTxt += "  AND B.SALESDATERF <=@FINDEDAPPLYDATERF " + Environment.NewLine;   
            //}

            if (CndtnWork.ApplyStaDate != 0)
            {
                selectTxt += "  AND ((B.SALESDATERF >=@FINDSTAPPLYDATERF " + Environment.NewLine;
            }
            if (CndtnWork.ApplyEndDate != 0)
            {
                selectTxt += "  AND B.SALESDATERF <=@FINDEDAPPLYDATERF) " + Environment.NewLine;
            }
            selectTxt += "  OR (B.SALESDATERF >= @FINDSALESDTST " + Environment.NewLine;
            selectTxt += "  AND B.SALESDATERF <= @FINDSALESDTED)) " + Environment.NewLine;

            // ----- UPD 2011/07/27 ----- <<<<<

            //selectTxt += "  AND B.SALESDATERF >= @FINDSALESDTST " + Environment.NewLine; // ADD 2011/07/27
            SqlParameter paraSeSalesDtSt = sqlCommand.Parameters.Add("@FINDSALESDTST", SqlDbType.Int);
            paraSeSalesDtSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.AddUpYearMonthDaySt);

            //selectTxt += "  AND B.SALESDATERF <= @FINDSALESDTED " + Environment.NewLine; // ADD 2011/07/27
            SqlParameter paraSeSalesDtEd = sqlCommand.Parameters.Add("@FINDSALESDTED", SqlDbType.Int);
            paraSeSalesDtEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.AddUpYearMonthDayEd);

            SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@FINDEDAPPLYDATERF", SqlDbType.Int);
            paraSalesDateEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyEndDate);
            SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@FINDSTAPPLYDATERF", SqlDbType.Int);
            paraSalesDateSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyStaDate);
            
            //グループコード
            if (CndtnWork.BLGroupCodeSt != 0)
            {
                selectTxt += "  AND B.BLGROUPCODERF>=@FINDSTGROUPCODE " + Environment.NewLine;
                SqlParameter paraGroupCodeSt = sqlCommand.Parameters.Add("@FINDSTGROUPCODE", SqlDbType.Int);
                paraGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeSt);
            }
            if (CndtnWork.BLGroupCodeEd != 0)
            {
                selectTxt += "  AND B.BLGROUPCODERF<=@FINDEDGROUPCODE " + Environment.NewLine;
                SqlParameter paraGroupCodeEd = sqlCommand.Parameters.Add("@FINDEDGROUPCODE", SqlDbType.Int);
                paraGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeEd);
            }
            //BLコード
            if (CndtnWork.BLGoodsCodeSt != 0)
            {
                selectTxt += "  AND B.BLGOODSCODERF>=@FINDSTGOODSCODERF " + Environment.NewLine;
                SqlParameter paraGoodsCodeSt = sqlCommand.Parameters.Add("@FINDSTGOODSCODERF", SqlDbType.Int);
                paraGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeSt);
            }
            if (CndtnWork.BLGoodsCodeEd != 0)
            {
                selectTxt += "  AND B.BLGOODSCODERF<=@FINDEDGOODSCODERF " + Environment.NewLine;
                SqlParameter paraGoodsCodeEd = sqlCommand.Parameters.Add("@FINDEDGOODSCODERF", SqlDbType.Int);
                paraGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeEd);
            }

            // ----- ADD 2011/07/11 ----- >>>>>
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
            // ----- ADD 2011/07/11 ----- <<<<<

            // 売上伝票区分（明細）が 0(売上),1(返品)
            //selectTxt += "  AND (B.SALESSLIPCDDTLRF = 0 OR B.SALESSLIPCDDTLRF = 1)" + Environment.NewLine; // DEL 2011/07/27
            selectTxt += "  AND (B.SALESSLIPCDDTLRF = 0 OR B.SALESSLIPCDDTLRF = 1 OR B.SALESSLIPCDDTLRF = 2)" + Environment.NewLine; // ADD 2011/07/27
            // キャンペーンコード
            selectTxt += "  AND J.CAMPAIGNCODERF=@FINDCAMPAIGNCODE " + Environment.NewLine;
            SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);
            //得意先
            selectTxt += "  AND ((J.CAMPAIGNOBJDIVRF = 1 " + Environment.NewLine;
            selectTxt += "      AND A.CUSTOMERCODERF IN  " + Environment.NewLine;
            //selectTxt += "      (SELECT CUSTOMERCODERF FROM CAMPAIGNLINKRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND LOGICALDELETECODERF = 0 AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE) " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "      (SELECT CUSTOMERCODERF FROM CAMPAIGNLINKRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND LOGICALDELETECODERF = 0 AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "      )  OR (J.CAMPAIGNOBJDIVRF <> 1)) " + Environment.NewLine;
            //設定種別
            selectTxt += "  AND ( " + Environment.NewLine;
            selectTxt += "  (L.CAMPAIGNSETTINGKINDRF = 1 AND L.GOODSNORF = B.GOODSNORF AND L.GOODSMAKERCDRF = B.GOODSMAKERCDRF) " + Environment.NewLine;
            selectTxt += "  OR (L.CAMPAIGNSETTINGKINDRF = 2 AND L.GOODSMAKERCDRF = B.GOODSMAKERCDRF AND L.BLGOODSCODERF = B.BLGOODSCODERF) " + Environment.NewLine;
            selectTxt += "  OR (L.CAMPAIGNSETTINGKINDRF = 3 AND L.GOODSMAKERCDRF = B.GOODSMAKERCDRF AND L.BLGROUPCODERF = B.BLGROUPCODERF) " + Environment.NewLine;
            selectTxt += "  OR (L.CAMPAIGNSETTINGKINDRF = 4 AND L.GOODSMAKERCDRF = B.GOODSMAKERCDRF ) " + Environment.NewLine;
            selectTxt += "  OR (L.CAMPAIGNSETTINGKINDRF = 5 AND L.BLGOODSCODERF = B.BLGOODSCODERF ) " + Environment.NewLine;
            selectTxt += "  OR (L.CAMPAIGNSETTINGKINDRF = 6 AND L.SALESCODERF = B.SALESCODERF ) " + Environment.NewLine;
            selectTxt += "  ) " + Environment.NewLine;

            // ----- ADD 2011/07/11 ----->>>>>
            selectTxt += " AND ((L.SECTIONCODERF <> '00' AND A.RESULTSADDUPSECCDRF = L.SECTIONCODERF) OR (L.SECTIONCODERF = '00')) " + Environment.NewLine;
            // ----- ADD 2011/07/11 -----<<<<<
            
            #endregion Where文

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
        /// <br>Note       : クラス格納処理します</br>
        /// <br>Programmer : caohh</br>
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
        /// <br>Note       : クラス格納処理します</br>
        /// <br>Programmer : caohh</br>
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

        #region [商品別用目標設定Select文]
        /// <summary>
        /// 商品別用目標設定SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>商品別用目標設定SELECT文</returns>
        /// <remarks>
        /// <br>Note       : 商品別用目標設定SELECT文を作成して戻します</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        public string MakeTargetSelectString(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            return this.MakeTargetSelectStringProc(ref sqlCommand, CndtnWork);
        }
        #endregion // 商品別用目標設定Select文

        #region [商品別用目標設定Select文生成処理]
        /// <summary>
        /// 商品別用目標設定SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>商品別用目標設定SELECT文</returns>
        /// <remarks>
        /// <br>Note       : 商品別用目標設定SELECT文を作成して戻します</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private string MakeTargetSelectStringProc(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            string selectTxt = string.Empty;

            #region SELECT文
            selectTxt += "SELECT " + Environment.NewLine;
            selectTxt += "  CAMPTAR.CAMPAIGNCODERF " + Environment.NewLine;              // キャンペーンコード
            selectTxt += "  ,CAMPTAR.TARGETCONTRASTCDRF " + Environment.NewLine;         // 目標対比区分
            selectTxt += "  ,CAMPTAR.SECTIONCODERF " + Environment.NewLine;              // 拠点コード
            selectTxt += "  ,CAMPTAR.CUSTOMERCODERF " + Environment.NewLine;             // 得意先コード
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

            selectTxt += "  AND (" + Environment.NewLine;

            selectTxt += "  CAMPTAR.TARGETCONTRASTCDRF=10 " + Environment.NewLine;

            // 小計単位が「グループコード」場合
            if ((CndtnWork.Detail == 0 && CndtnWork.Total == 0) || CndtnWork.Detail == 2)
            {
                selectTxt += "  OR CAMPTAR.TARGETCONTRASTCDRF=50 " + Environment.NewLine;
            }
            else if ((CndtnWork.Detail == 0 && CndtnWork.Total == 1) || CndtnWork.Detail == 1)
            {
                selectTxt += "  OR CAMPTAR.TARGETCONTRASTCDRF=60 " + Environment.NewLine;
            }
            else
            {
                selectTxt += string.Empty;
            }
            selectTxt += "  )" + Environment.NewLine;
            #endregion

            return selectTxt;
        }
        #endregion // 商品別用目標設定Select文生成処理

        #region [CopyToCampaignTargetWorkFromReader処理 呼出]
        /// <summary>
        /// クラス格納処理 Reader → CopyToCampaignTargetWorkFromReader
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">paramWork</param>
        /// <returns>CopyToCampaignResultWork</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理します</br>
        /// <br>Programmer : caohh</br>
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
        /// <br>Note       : クラス格納処理します</br>
        /// <br>Programmer : caohh</br>
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
    }
}
