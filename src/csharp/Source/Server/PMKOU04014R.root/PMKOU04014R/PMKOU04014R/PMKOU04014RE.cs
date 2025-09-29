//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入返品予定情報DBリモートオブジェクト
// プログラム概要   : 仕入返品予定一覧表のデータ操作を行うクラスです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI千田 晃久
// 修 正 日  2013/01/21  修正内容 : 仕入返品予定機能対応
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI斎藤 和宏
// 修 正 日  2013/02/18  修正内容 : 仕入日のセット内容修正
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI冨樫 紗由里
// 修 正 日  2013/02/21  修正内容 : システムテスト障害No105対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
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
    /// 仕入返品予定情報 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入返品予定情報リモートオブジェクト。</br>
    /// <br>Programmer : FSI千田 晃久</br>
    /// <br>Date       : 2013/01/21</br>
    /// <br></br>
    /// </remarks>

    class SuppPrtPprRetSchStcTblRsltQuery : ISuppPrtPprRetSch
    {
        private const string HORIZONTAL_LINE = "-";
        #region [SuppPrtPprStcTblRsltWork用 SELECT文]
        /// <summary>
        /// 仕入返品予定情報表示のリスト抽出クエリ作成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalDelDiv">削除指定区分(0:通常 1:削除分のみ)</param>
        /// <returns>仕入返品予定情報表示のリスト抽出SELECT文</returns>
        /// <remarks>
        /// <br>Note       : 仕入返品予定情報表示のリスト抽出用SELECT文を作成して戻します</br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        public string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int logicalDelDiv)
        {
            string selectTxt = "";
            SuppPrtPprWork _suppPrtPprWork = paramWork as SuppPrtPprWork;

            selectTxt = MakeTypeStcSlpQuery(ref sqlCommand, _suppPrtPprWork, logicalDelDiv);

            return selectTxt;
        }

        #endregion  //[SuppPrtPprStcTblRsltWork用 SELECT文]

        #region [仕入データ用 SELECT文生成処理]
        /// <summary>
        /// 仕入返品予定情報用SELECT文作成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalDelDiv">削除指定区分(0:通常 1:削除分のみ)</param>
        /// <returns>仕入返品予定情報用SELECT文</returns>
        /// <remarks>
        /// <br>Note       : 仕入返品予定情報用SELECT文を作成して戻します</br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        private string MakeTypeStcSlpQuery(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, int logicalDelDiv)
        {
            StringBuilder sqlText = new StringBuilder();

            // 対象テーブル
            // STOCKSLIPRF     STCSLP   仕入データ
            // STOCKDETAILRF   STCDTL   仕入明細データ
            // SALESSLIPRF     SALSLP   売上データ
            // SALESDETAILRF   SALDTL   売上明細データ
            // SECINFOSETRF    SCINFS   拠点情報設定マスタ

            #region [Select文作成]

            sqlText.Append("SELECT").Append(Environment.NewLine);
            sqlText.Append("   ROW_NUMBER() OVER(ORDER BY STCTBL.SUPPLIERSLIPNORF) AS ROWNUM ").Append(Environment.NewLine);
            sqlText.Append(" , STCTBL.* ").Append(Environment.NewLine);
            sqlText.Append("FROM ").Append(Environment.NewLine);
            sqlText.Append("( ").Append(Environment.NewLine);

            #region [データ抽出メインQuery]
            //検索上限件数を超えるまで取得
            sqlText.Append("SELECT TOP ").Append(paramWork.SearchCnt).Append(Environment.NewLine);
            sqlText.Append("    STCSLP.ENTERPRISECODERF").Append(Environment.NewLine);
            // --- DEL 2013/02/18 ---------->>>>>
            //sqlText.Append("  , STCSLP.STOCKDATERF").Append(Environment.NewLine);
            // --- DEL 2013/02/18 ----------<<<<<
            // --- ADD 2013/02/18 ---------->>>>>
            // 仕入日ではなく、仕入伝票発行日を使用
            sqlText.Append("  , STCSLP.STOCKSLIPPRINTDATERF").Append(Environment.NewLine);
            // --- ADD 2013/02/18 ----------<<<<<
            sqlText.Append("  , STCSLP.PARTYSALESLIPNUMRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKROWNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPLIERFORMALRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPLIERSLIPCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKAGENTNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKTTLPRICTAXEXCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSMAKERCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.MAKERNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.BLGOODSCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.BLGROUPCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKCOUNTRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.LISTPRICETAXEXCFLRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.OPENPRICEDIVRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPCTAXLAYCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKTTLPRICTAXINCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKPRICECONSTAXRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPLIERSLIPNOTE1RF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPLIERSLIPNOTE2RF").Append(Environment.NewLine);
            sqlText.Append("  , SCINFS.SECTIONCODERF").Append(Environment.NewLine);
            sqlText.Append("  , SCINFS.SECTIONGUIDENMRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKINPUTNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPLIERCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPLIERSNMRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKORDERDIVCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.WAREHOUSECODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.WAREHOUSENAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.WAREHOUSESHELFNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.UOEREMARK1RF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.UOEREMARK2RF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPLIERSLIPNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKADDUPADATERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ACCPAYDIVCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.DEBITNOTEDIVRF").Append(Environment.NewLine);
            sqlText.Append("  , SALSLP.SALESSLIPNUMRF").Append(Environment.NewLine);
            sqlText.Append("  , SALSLP.SALESDATERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SALESCUSTOMERCODERF AS CUSTOMERCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SALESCUSTOMERSNMRF AS CUSTOMERSNMRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPTTLAMNTDSPWAYCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.TAXATIONCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STCKPRCCONSTAXINCLURF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STCKDISTTLTAXINCLURF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKUNITPRICEFLRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ARRIVALGOODSDAYRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKTOTALPRICERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKSUBTTLPRICERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKGOODSCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKPRICETAXEXCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKPRICETAXINCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKPRICECONSTAXRF AS DTLSTOCKPRICECONSTAXRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKSLIPCDDTLRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.BFSTOCKUNITPRICEFLRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.BFLISTPRICERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.LOGICALDELETECODERF AS SLPDELETECODE").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.LOGICALDELETECODERF AS DTLDELETECODE").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUBSECTIONCODERF AS SLPSUBSECTIONCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKSECTIONCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPLIERCONSTAXRATERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.INPUTDAYRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SUBSECTIONCODERF AS DTLSUBSECTIONCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ACCEPTANORDERNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.COMMONSEQNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKSLIPDTLNUMRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SUPPLIERFORMALSRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKSLIPDTLNUMSRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ACPTANODRSTATUSSYNCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SALESSLIPDTLNUMSYNCRF").Append(Environment.NewLine);

            sqlText.Append("  , STCDTL.SUBSECTIONCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKINPUTCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKAGENTCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSKINDCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.MAKERKANANAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.CMPLTMAKERKANANAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSNAMEKANARF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSLGROUPRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSLGROUPNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSMGROUPRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSMGROUPNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.BLGROUPNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.BLGOODSFULLNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ENTERPRISEGANRECODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.RATESECTSTCKUNPRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.RATEDIVSTCKUNPRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.UNPRCCALCCDSTCKUNPRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.PRICECDSTCKUNPRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STDUNPRCSTCKUNPRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.FRACPROCUNITSTCUNPRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.FRACPROCSTCKUNPRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKUNITTAXPRICEFLRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKUNITCHNGDIVRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.RATEBLGOODSCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.RATEBLGOODSNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.RATEGOODSRATEGRPCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.RATEGOODSRATEGRPNMRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.RATEBLGROUPCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.RATEBLGROUPNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ORDERCNTRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ORDERADJUSTCNTRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ORDERREMAINCNTRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.REMAINCNTUPDDATERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKDTISLIPNOTE1RF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SALESCUSTOMERCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SALESCUSTOMERSNMRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SLIPMEMO1RF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SLIPMEMO2RF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SLIPMEMO3RF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.INSIDEMEMO1RF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.INSIDEMEMO2RF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.INSIDEMEMO3RF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ADDRESSEECODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ADDRESSEENAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.DIRECTSENDINGCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ORDERNUMBERRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.WAYTOORDERRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.DELIGDSCMPLTDUEDATERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.EXPECTDELIVERYDATERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ORDERDATACREATEDIVRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ORDERDATACREATEDATERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ORDERFORMISSUEDDIVRF").Append(Environment.NewLine);

            sqlText.Append("  , STCDTL.ENTERPRISEGANRENAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSRATERANKRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.CUSTRATEGRPCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SUPPRATEGRPCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.LISTPRICETAXINCFLRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKRATERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKADDUPSECTIONCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.BUSINESSTYPECODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.BUSINESSTYPENAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SALESAREACODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SALESAREANAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.TTLAMNTDISPRATEAPYRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKFRACTIONPROCCDRF").Append(Environment.NewLine);

            sqlText.Append("  , STCSLP.SLIPADDRESSDIVRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEECODERF AS SLPADDRESSEECODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEENAMERF AS SLPADDRESSEENAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEENAME2RF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEEPOSTNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEEADDR1RF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEEADDR3RF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEEADDR4RF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEETELNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEEFAXNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.DIRECTSENDINGCDRF AS SLPDIRECTSENDINGCDRF").Append(Environment.NewLine);

            sqlText.Append("  FROM ").Append(Environment.NewLine);
            sqlText.Append("    STOCKSLIPRF AS STCSLP WITH (READUNCOMMITTED) ").Append(Environment.NewLine);

            #region [JOIN]
            //仕入明細データ
            sqlText.Append("    LEFT JOIN STOCKDETAILRF STCDTL WITH (READUNCOMMITTED)").Append(Environment.NewLine);
            sqlText.Append("      ON STCDTL.ENTERPRISECODERF = STCSLP.ENTERPRISECODERF").Append(Environment.NewLine);
            sqlText.Append("     AND STCDTL.SUPPLIERFORMALRF = STCSLP.SUPPLIERFORMALRF").Append(Environment.NewLine);
            sqlText.Append("     AND STCDTL.SUPPLIERSLIPNORF = STCSLP.SUPPLIERSLIPNORF").Append(Environment.NewLine);

            //拠点情報設定マスタ
            sqlText.Append("    LEFT JOIN SECINFOSETRF SCINFS WITH (READUNCOMMITTED)").Append(Environment.NewLine);
            sqlText.Append("      ON SCINFS.ENTERPRISECODERF = STCSLP.ENTERPRISECODERF").Append(Environment.NewLine);
            sqlText.Append("     AND SCINFS.SECTIONCODERF = STCSLP.STOCKSECTIONCDRF").Append(Environment.NewLine);

            //売上明細データ
            sqlText.Append("    LEFT JOIN SALESDETAILRF SALDTL WITH (READUNCOMMITTED)").Append(Environment.NewLine);
            sqlText.Append("      ON SALDTL.ENTERPRISECODERF = STCDTL.ENTERPRISECODERF").Append(Environment.NewLine);
            sqlText.Append("     AND SALDTL.SALESSLIPDTLNUMRF = STCDTL.SALESSLIPDTLNUMSYNCRF").Append(Environment.NewLine);

            //売上データ
            sqlText.Append("    LEFT JOIN SALESSLIPRF SALSLP WITH (READUNCOMMITTED)").Append(Environment.NewLine);
            sqlText.Append("      ON SALSLP.ENTERPRISECODERF = SALDTL.ENTERPRISECODERF").Append(Environment.NewLine);
            sqlText.Append("     AND SALSLP.ACPTANODRSTATUSRF = SALDTL.ACPTANODRSTATUSRF").Append(Environment.NewLine);
            sqlText.Append("     AND SALSLP.SALESSLIPNUMRF = SALDTL.SALESSLIPNUMRF").Append(Environment.NewLine);

            #endregion  //[JOIN]

            //WHERE句
            sqlText.Append(MakeWhereString_STCDTL(ref sqlCommand, paramWork, logicalDelDiv));

            #endregion  //[データ抽出メインQuery]

            sqlText.Append(" ORDER BY").Append(Environment.NewLine);

            // --- DEL 2013/02/18 ---------->>>>>
            //sqlText.Append("     STCSLP.STOCKDATERF").Append(Environment.NewLine);
            // --- DEL 2013/02/18 ----------<<<<<
            // --- ADD 2013/02/18 ---------->>>>>
            // 仕入日ではなく、仕入伝票発行日を使用
            sqlText.Append("     STCSLP.STOCKSLIPPRINTDATERF").Append(Environment.NewLine);
            // --- ADD 2013/02/18 ----------<<<<<
            sqlText.Append("   , STCSLP.PARTYSALESLIPNUMRF").Append(Environment.NewLine);
            sqlText.Append("   , STCSLP.SUPPLIERFORMALRF").Append(Environment.NewLine);
            sqlText.Append("   , STCSLP.SUPPLIERSLIPCDRF").Append(Environment.NewLine);
            sqlText.Append("   , STCDTL.STOCKROWNORF").Append(Environment.NewLine);

            sqlText.Append(" ) AS STCTBL ").Append(Environment.NewLine);

            //ODER BY
            sqlText.Append(" ORDER BY ROWNUM DESC");

            #endregion

            return sqlText.ToString();

        }
        #endregion  //[SuppPrtPprSalTblRsltWork用 SELECT文生成処理]


        #region [SuppPrtPprStcTblRsltWork用 WHERE文生成処理 (仕入返品予定情報SELECT用)]
        /// <summary>
        /// 仕入返品予定情報表示のリスト抽出用WHERE句 生成処理 (仕入返品予定情報SELECT用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalDelDiv">削除指定区分(0:通常 1:削除分のみ)</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : 仕入返品予定情報のWHERE句を作成</br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        private StringBuilder MakeWhereString_STCDTL(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, int logicalDelDiv)
        {
            #region WHERE文作成

            StringBuilder retstring = new StringBuilder();

            retstring.Append(" WHERE ").Append(Environment.NewLine);

            #region 仕入データ検索条件
            //企業コード
            retstring.Append(" STCSLP.ENTERPRISECODERF=@ENTERPRISECODE").Append(Environment.NewLine);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //論理削除区分
            retstring.Append(" AND STCSLP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE").Append(Environment.NewLine);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalDelDiv);

            //拠点コード
            if (paramWork.SectionCode != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in paramWork.SectionCode)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring.Append(" AND STCSLP.STOCKSECTIONCDRF IN (").Append(sectionCodestr).Append(") ");
                }
                retstring.Append(Environment.NewLine);
            }

            //仕入形式
            retstring.Append(" AND STCSLP.SUPPLIERFORMALRF = 3 ").Append(Environment.NewLine);

            //仕入先コード
            if (paramWork.SupplierCd != 0)
            {
                retstring.Append(" AND STCSLP.SUPPLIERCDRF=@FINDSUPPLIERCD").Append(Environment.NewLine);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SupplierCd);
            }

            //支払先コード
            if (paramWork.PayeeCode != 0)
            {
                retstring.Append(" AND STCSLP.PAYEECODERF=@FINDPAYEECODE").Append(Environment.NewLine);
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paramWork.PayeeCode);
            }

            //仕入日
            if (paramWork.St_StockDate != DateTime.MinValue)
            {
                // --- DEL 2013/02/18 ---------->>>>>
                //retstring.Append(" AND STCSLP.STOCKDATERF>=@STSTOCKDATE ").Append(Environment.NewLine);
                // --- DEL 2013/02/18 ----------<<<<<
                // --- ADD 2013/02/18 ---------->>>>>
                // 仕入日ではなく、仕入伝票発行日を使用
                retstring.Append(" AND STCSLP.STOCKSLIPPRINTDATERF>=@STSTOCKDATE ").Append(Environment.NewLine);
                // --- ADD 2013/02/18 ----------<<<<<
                SqlParameter paraStStockDate = sqlCommand.Parameters.Add("@STSTOCKDATE", SqlDbType.Int);
                paraStStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_StockDate);
            }
            if (paramWork.Ed_StockDate != DateTime.MinValue)
            {
                // --- DEL 2013/02/18 ---------->>>>>
                //retstring.Append(" AND STCSLP.STOCKDATERF<=@EDSTOCKDATE ").Append(Environment.NewLine);
                // --- DEL 2013/02/18 ----------<<<<<
                // --- ADD 2013/02/18 ---------->>>>>
                // 仕入日ではなく、仕入伝票発行日を使用
                retstring.Append(" AND STCSLP.STOCKSLIPPRINTDATERF<=@EDSTOCKDATE ").Append(Environment.NewLine);
                // --- ADD 2013/02/18 ----------<<<<<
                SqlParameter paraEdStockDate = sqlCommand.Parameters.Add("@EDSTOCKDATE", SqlDbType.Int);
                paraEdStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_StockDate);
            }

            //入力日
            if (paramWork.St_InputDay != DateTime.MinValue)
            {
                retstring.Append(" AND STCSLP.INPUTDAYRF>=@STINPUTDAY").Append(Environment.NewLine);
                SqlParameter paraStInputDay = sqlCommand.Parameters.Add("@STINPUTDAY", SqlDbType.Int);
                paraStInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_InputDay);
            }
            if (paramWork.Ed_InputDay != DateTime.MinValue)
            {
                retstring.Append(" AND STCSLP.INPUTDAYRF<=@EDINPUTDAY").Append(Environment.NewLine);
                SqlParameter paraEdInputDay = sqlCommand.Parameters.Add("@EDINPUTDAY", SqlDbType.Int);
                paraEdInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_InputDay);
            }

            //伝票区分
            if (paramWork.SupplierSlipCd != null)
            {
                string supplierSlipCdstr = "";
                foreach (Int32 isupSlpCd in paramWork.SupplierSlipCd)
                {
                    if (supplierSlipCdstr != "")
                    {
                        supplierSlipCdstr += ",";
                    }
                    supplierSlipCdstr += isupSlpCd.ToString();
                }
                if (supplierSlipCdstr != "")
                {
                    retstring.Append(" AND STCSLP.SUPPLIERSLIPCDRF IN (").Append(supplierSlipCdstr).Append(")").Append(Environment.NewLine);
                }
            }

            //伝票番号(相手先伝票番号) ※あいまい検索あり
            if (paramWork.PartySaleSlipNum != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.PartySaleSlipNum, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring.Append(" AND STCSLP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUM").Append(Environment.NewLine);
                }
                else
                {
                    //あいまい検索じゃない
                    retstring.Append(" AND STCSLP.PARTYSALESLIPNUMRF=@FINDPARTYSALESLIPNUM").Append(Environment.NewLine);
                }
                SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUM", SqlDbType.NVarChar);
                paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(paramWork.PartySaleSlipNum);
            }

            //仕入SEQ/支払№(仕入伝票番号)
            if (paramWork.PaymentSlipNo != 0)
            {
                retstring.Append(" AND STCSLP.SUPPLIERSLIPNORF>=@FINDSUPPLIERSLIPNO").Append(Environment.NewLine);
                SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(paramWork.PaymentSlipNo);
            }

            //担当者(仕入担当者コード)
            if (paramWork.StockAgentCode != "")
            {
                retstring.Append(" AND STCSLP.STOCKAGENTCODERF=@FINDSTOCKAGENTCODE").Append(Environment.NewLine);
                SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODE", SqlDbType.NChar);
                paraStockAgentCode.Value = SqlDataMediator.SqlSetString(paramWork.StockAgentCode);
            }

            //備考１(仕入伝票備考1) ※あいまい検索あり
            if (paramWork.SupplierSlipNote1 != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SupplierSlipNote1, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring.Append(" AND STCSLP.SUPPLIERSLIPNOTE1RF LIKE @FINDSUPPLIERSLIPNOTE1").Append(Environment.NewLine);
                }
                else
                {
                    //あいまい検索じゃない
                    retstring.Append(" AND STCSLP.SUPPLIERSLIPNOTE1RF=@FINDSUPPLIERSLIPNOTE1").Append(Environment.NewLine);
                }
                SqlParameter paraSupplierSlipNote1 = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOTE1", SqlDbType.NVarChar);
                paraSupplierSlipNote1.Value = SqlDataMediator.SqlSetString(paramWork.SupplierSlipNote1);
            }

            //備考２(仕入伝票備考2) ※あいまい検索あり
            if (paramWork.SupplierSlipNote2 != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SupplierSlipNote2, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring.Append(" AND STCSLP.SUPPLIERSLIPNOTE2RF LIKE @FINDSUPPLIERSLIPNOTE2").Append(Environment.NewLine);
                }
                else
                {
                    //あいまい検索じゃない
                    retstring.Append(" AND STCSLP.SUPPLIERSLIPNOTE2RF=@FINDSUPPLIERSLIPNOTE2").Append(Environment.NewLine);
                }
                SqlParameter paraSupplierSlipNote2 = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOTE2", SqlDbType.NVarChar);
                paraSupplierSlipNote2.Value = SqlDataMediator.SqlSetString(paramWork.SupplierSlipNote2);
            }

            //ＵＯＥリマーク１ ※あいまい検索あり
            if (paramWork.UoeRemark1 != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.UoeRemark1, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring.Append(" AND STCSLP.UOEREMARK1RF LIKE @FINDUOEREMARK1").Append(Environment.NewLine);
                }
                else
                {
                    //あいまい検索じゃない
                    retstring.Append(" AND STCSLP.UOEREMARK1RF=@FINDUOEREMARK1").Append(Environment.NewLine);
                }
                SqlParameter paraUoeRemark1 = sqlCommand.Parameters.Add("@FINDUOEREMARK1", SqlDbType.NVarChar);
                paraUoeRemark1.Value = SqlDataMediator.SqlSetString(paramWork.UoeRemark1);
            }

            //ＵＯＥリマーク２ ※あいまい検索あり
            if (paramWork.UoeRemark2 != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.UoeRemark2, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring.Append(" AND STCSLP.UOEREMARK2RF LIKE @FINDUOEREMARK2").Append(Environment.NewLine);
                }
                else
                {
                    //あいまい検索じゃない
                    retstring.Append(" AND STCSLP.UOEREMARK2RF=@FINDUOEREMARK2").Append(Environment.NewLine);
                }
                SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@FINDUOEREMARK2", SqlDbType.NVarChar);
                paraUoeRemark2.Value = SqlDataMediator.SqlSetString(paramWork.UoeRemark2);
            }

            #endregion

            #region 仕入明細データ検索条件

            //企業コード
            retstring.Append(" AND STCDTL.ENTERPRISECODERF=@ENTERPRISECODE2").Append(Environment.NewLine);
            SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@ENTERPRISECODE2", SqlDbType.NChar);
            paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //論理削除区分
            if (logicalDelDiv == 0)
            {
                // 通常
                retstring.Append(" AND STCDTL.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);
                retstring.Append(" AND STCDTL.SALESSLIPDTLNUMSYNCRF <> 0 ").Append(Environment.NewLine);
            }
            else
            {
                // 削除分のみ
                retstring.Append(" AND STCDTL.LOGICALDELETECODERF = 1 ").Append(Environment.NewLine);
                retstring.Append(" AND STCDTL.SALESSLIPDTLNUMSYNCRF <> 0 ").Append(Environment.NewLine);
            }

            // 明細区分
            if (paramWork.StockSlipCdDtl == 1)
            {
                // 1:値引除く
                retstring.Append(" AND STCDTL.STOCKSLIPCDDTLRF<>@FINDSTOCKSLIPCDDTL").Append(Environment.NewLine);
                SqlParameter paraStockSlipCdDtl = sqlCommand.Parameters.Add("@FINDSTOCKSLIPCDDTL", SqlDbType.Int);
                paraStockSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(2);
            }
            else if (paramWork.StockSlipCdDtl == 2)
            {
                // 2:値引のみ
                retstring.Append(" AND STCDTL.STOCKSLIPCDDTLRF=@FINDSTOCKSLIPCDDTL").Append(Environment.NewLine);
                SqlParameter paraStockSlipCdDtl = sqlCommand.Parameters.Add("@FINDSTOCKSLIPCDDTL", SqlDbType.Int);
                paraStockSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(2);
            }

            //ＵＯＥ発送(注文方法)
            if (paramWork.WayToOrder != 0)
            {
                if (paramWork.WayToOrder == 2)
                {
                    //UOE送信 -> UOE送信のみ
                    retstring.Append(" AND STCDTL.WAYTOORDERRF=2").Append(Environment.NewLine);
                }
                else
                {
                    //通常 -> UOE送信以外
                    retstring.Append("AND STCDTL.WAYTOORDERRF<>2 ").Append(Environment.NewLine);
                }
            }

            //グループコード(BLグループコード)
            if (paramWork.BLGroupCode != 0)
            {
                retstring.Append(" AND STCDTL.BLGROUPCODERF=@FINDBLGROUPCODE").Append(Environment.NewLine);
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGroupCode);
            }

            //BLコード(BL商品コード)
            if (paramWork.BLGoodsCode != 0)
            {
                retstring.Append(" AND STCDTL.BLGOODSCODERF=@FINDBLGOODSCODE").Append(Environment.NewLine);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGoodsCode);
            }

            //品名(商品名称) ※あいまい検索あり
            if (paramWork.GoodsName != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.GoodsName, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring.Append(" AND STCDTL.GOODSNAMERF LIKE @FINDGOODSNAME").Append(Environment.NewLine);
                }
                else
                {
                    //あいまい検索じゃない
                    retstring.Append(" AND STCDTL.GOODSNAMERF=@FINDGOODSNAME").Append(Environment.NewLine);
                }
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAME", SqlDbType.NVarChar);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(paramWork.GoodsName);
            }

            //品番(商品番号) ※あいまい検索あり
            if (paramWork.GoodsNo != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.GoodsNo, "(%)").Success == true)
                {
                    //あいまい検索
                    if (paramWork.GoodsNo.Contains(HORIZONTAL_LINE))
                    {
                        retstring.Append(" AND STCDTL.GOODSNORF LIKE @FINDGOODSNO").Append(Environment.NewLine);
                    }
                    else
                    {
                        retstring.Append(" AND REPLACE(STCDTL.GOODSNORF, '" + HORIZONTAL_LINE + "', '') LIKE @FINDGOODSNO").Append(Environment.NewLine);
                    }
                }
                else
                {
                    //あいまい検索じゃない
                    if (paramWork.GoodsNo.Contains(HORIZONTAL_LINE))
                    {
                        retstring.Append(" AND STCDTL.GOODSNORF = @FINDGOODSNO").Append(Environment.NewLine);
                    }
                    else
                    {
                        retstring.Append(" AND REPLACE(STCDTL.GOODSNORF, '" + HORIZONTAL_LINE + "', '') = @FINDGOODSNO").Append(Environment.NewLine);
                    }
                }
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(paramWork.GoodsNo);
            }

            //メーカー(商品メーカーコード)
            if (paramWork.GoodsMakerCd != 0)
            {
                retstring.Append("AND STCDTL.GOODSMAKERCDRF=@FINDGOODSMAKERCD ").Append(Environment.NewLine);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCd);
            }

            //在庫取寄区分(仕入在庫取寄せ区分)
            if (paramWork.StockOrderDivCd != -1)
            {
                retstring.Append("AND STCDTL.STOCKORDERDIVCDRF=@FINDSTOCKORDERDIVCD").Append(Environment.NewLine);
                SqlParameter paraStockOrderDivCd = sqlCommand.Parameters.Add("@FINDSTOCKORDERDIVCD", SqlDbType.Int);
                paraStockOrderDivCd.Value = SqlDataMediator.SqlSetInt32(paramWork.StockOrderDivCd);
            }

            //倉庫コード
            if (paramWork.WarehouseCode != "")
            {
                retstring.Append("AND STCDTL.WAREHOUSECODERF=@FINDWAREHOUSECODE ").Append(Environment.NewLine);
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
            }

            #endregion
            #endregion

            return retstring;
        }
        #endregion  //[SuppPrtPprStcTblRsltWork用 WHERE文生成処理 (仕入データSELECT用)]


        #region [SuppPrtPprStcTblRsltWork処理 呼出]
        /// <summary>
        /// クラス格納処理 Reader → SuppPrtPprStcTblRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">SuppPrtPprWork</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        public object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork)
        {
            SuppPrtPprWork _suppPrtPprWork = paramWork as SuppPrtPprWork;
            return this.CopyToResultWorkFromReaderProc(ref myReader);
        }
        #endregion  //[SuppPrtPprStcTblRsltWork処理 呼出]

        #region [SuppPrtPprStcTblRsltWork処理]
        /// <summary>
        /// クラス格納処理 Reader → SuppPrtPprStcTblRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        private SuppPrtPprStcTblRsltWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader)
        {
            #region 抽出結果-値セット
            SuppPrtPprStcTblRsltWork resultWork = new SuppPrtPprStcTblRsltWork();

            resultWork.DataDiv = 0;
            // --- DEL 2013/02/18 ---------->>>>>
            //resultWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            // --- DEL 2013/02/18 ----------<<<<<
            // --- ADD 2013/02/18 ---------->>>>>
            // 仕入伝票発行日を仕入日として使用
            resultWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKSLIPPRINTDATERF"));
            // --- ADD 2013/02/18 ----------<<<<<
            resultWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            resultWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
            resultWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            resultWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            resultWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            resultWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            resultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            resultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            resultWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            resultWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            resultWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            resultWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            resultWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            resultWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            resultWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            resultWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            resultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            resultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            resultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            resultWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
            resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            resultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            resultWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            resultWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            resultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            resultWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            resultWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
            resultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            resultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            resultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            resultWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
            resultWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
            resultWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));
            resultWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
            resultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            resultWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
            resultWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            resultWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            resultWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
            resultWork.StockPriceConsTaxDtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DTLSTOCKPRICECONSTAXRF"));
            //resultWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));  // DEL 2013/02/21
            resultWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
            resultWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));// ADD 2013/02/21

            resultWork.SlpLogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLPDELETECODE"));
            resultWork.DtlLogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLDELETECODE"));
            resultWork.SlpSubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLPSUBSECTIONCODERF"));
            resultWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            resultWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
            resultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            resultWork.DtlSubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLSUBSECTIONCODERF"));
            resultWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
            resultWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
            resultWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
            resultWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));
            resultWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));
            resultWork.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSYNCRF"));
            resultWork.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSYNCRF"));

            resultWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            resultWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            resultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            resultWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
            resultWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));
            resultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            resultWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
            resultWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
            resultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            resultWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
            resultWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
            resultWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            resultWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            resultWork.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSTCKUNPRCRF"));
            resultWork.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSTCKUNPRCRF"));
            resultWork.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSTCKUNPRCRF"));
            resultWork.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSTCKUNPRCRF"));
            resultWork.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSTCKUNPRCRF"));
            resultWork.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSTCUNPRCRF"));
            resultWork.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSTCKUNPRCRF"));
            resultWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
            resultWork.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNITCHNGDIVRF"));
            resultWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
            resultWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));
            resultWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPCDRF"));
            resultWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPNMRF"));
            resultWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGROUPCODERF"));
            resultWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGROUPNAMERF"));
            resultWork.OrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERCNTRF"));
            resultWork.OrderAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERADJUSTCNTRF"));
            resultWork.OrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERREMAINCNTRF"));
            resultWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REMAINCNTUPDDATERF"));
            resultWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));
            resultWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));
            resultWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));
            resultWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
            resultWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
            resultWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
            resultWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
            resultWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
            resultWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
            resultWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
            resultWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
            resultWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));
            resultWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
            resultWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));
            resultWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
            resultWork.ExpectDeliveryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EXPECTDELIVERYDATERF"));
            resultWork.OrderDataCreateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERDATACREATEDIVRF"));
            resultWork.OrderDataCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ORDERDATACREATEDATERF"));
            resultWork.OrderFormIssuedDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERFORMISSUEDDIVRF"));

            resultWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
            resultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            resultWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            resultWork.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPRATEGRPCODERF"));
            resultWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
            resultWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            resultWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
            resultWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            resultWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
            resultWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            resultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
            resultWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
            resultWork.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKFRACTIONPROCCDRF"));

            resultWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));
            resultWork.SlpAddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLPADDRESSEECODERF"));
            resultWork.SlpAddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLPADDRESSEENAMERF"));
            resultWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
            resultWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
            resultWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
            resultWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
            resultWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
            resultWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
            resultWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
            resultWork.SlpDirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLPDIRECTSENDINGCDRF"));

            #endregion

            return resultWork;
        }
        #endregion  //[SuppPrtPprStcTblRsltWork処理]

    }
}
