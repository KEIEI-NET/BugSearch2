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
    class MTtlSaSlipGoods : MTtlSaSlipBase, IMTtlSaSlip
    {
        #region [商品別用 Select文]
        /// <summary>
        /// 商品別用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>商品別用SELECT文</returns>
        /// <br>Note       : 商品別用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.09.08</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalTrgtPrintParamWork CndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            return this.MakeSelectStringProc(ref sqlCommand, CndtnWork, logicalMode);
        }
        #endregion  //[商品別用 Select文]

        #region [商品別用 Select文生成処理]
        /// <summary>
        /// 商品別用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>商品別用SELECT文</returns>
        /// <br>Note       : 商品別用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.11</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, SalTrgtPrintParamWork CndtnWork, ConstantManagement.LogicalMode logicalMode)
        {

            string Tblnm = "SCINF";

            switch (CndtnWork.PrintType)
            {
                case 44://拠点+販売区分
                    {
                        Tblnm = "USGDUS";
                        break;
                    }
                case 45://拠点+自社分類(商品区分)
                    {
                        Tblnm = "USGDUE";
                        break;
                    }
            }

            string selectTxt = "";
            #region [Select文作成]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "   " + Tblnm + ".UPDATEDATETIMERF" + Environment.NewLine;
            selectTxt += "  ,GSLST.SECTIONCODERF" + Environment.NewLine;
            selectTxt += "  ,SCINF.SECTIONGUIDESNMRF" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESCODERF" + Environment.NewLine;
            selectTxt += "  ,USGDUS.GUIDENAMERF AS SALESCODENAME" + Environment.NewLine;
            selectTxt += "  ,GSLST.ENTERPRISEGANRECODERF" + Environment.NewLine;
            selectTxt += "  ,USGDUE.GUIDENAMERF AS ENTERPRISEGANRECODENAME" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETMONEY1" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETMONEY2" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETMONEY3" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETMONEY4" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETMONEY5" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETMONEY6" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETMONEY7" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETMONEY8" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETMONEY9" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETMONEY10" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETMONEY11" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETMONEY12" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETPROFIT1" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETPROFIT2" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETPROFIT3" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETPROFIT4" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETPROFIT5" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETPROFIT6" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETPROFIT7" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETPROFIT8" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETPROFIT9" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETPROFIT10" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETPROFIT11" + Environment.NewLine;
            selectTxt += "  ,GSLST.SALESTARGETPROFIT12" + Environment.NewLine;
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            //商品別売上目標設定マスタ
            selectTxt += "  SELECT" + Environment.NewLine;
            selectTxt += "    GSLSTSUB.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "   ,GSLSTSUB.UPDATEDATETIMERF" + Environment.NewLine;
            selectTxt += "   ,GSLSTSUB.LOGICALDELETECODERF" + Environment.NewLine;
            selectTxt += "   ,GSLSTSUB.SECTIONCODERF" + Environment.NewLine;
            selectTxt += "   ,GSLSTSUB.SALESCODERF" + Environment.NewLine;
            selectTxt += "   ,GSLSTSUB.ENTERPRISEGANRECODERF" + Environment.NewLine;

            int setDate =  CndtnWork.TargetDivideCodeSt;
            for (int i = 1; i <= 12; i++)
            {
                //売上目標金額
                selectTxt += "   ,SUM((CASE WHEN GSLSTSUB.TARGETDIVIDECODERF= '" + setDate.ToString() + "' THEN GSLSTSUB.SALESTARGETMONEYRF ELSE 0 END)) AS SALESTARGETMONEY" + i.ToString() + Environment.NewLine;
                //売上目標粗利額
                selectTxt += "   ,SUM((CASE WHEN GSLSTSUB.TARGETDIVIDECODERF= '" + setDate.ToString() + "' THEN GSLSTSUB.SALESTARGETPROFITRF ELSE 0 END)) AS SALESTARGETPROFIT" + i.ToString() + Environment.NewLine;

                if (setDate % 100 >= 12)
                {
                    setDate = (setDate + 100) / 100 * 100 + 1;
                }
                else
                {
                    setDate = setDate + 1;
                }
            }
            selectTxt += "  FROM GCDSALESTARGETRF AS GSLSTSUB" + Environment.NewLine;

            //WHERE句
            selectTxt += MakeWhereString(ref sqlCommand, CndtnWork, "GSLSTSUB","", logicalMode);

            selectTxt += "  GROUP BY" + Environment.NewLine;
            selectTxt += "    GSLSTSUB.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "   ,GSLSTSUB.UPDATEDATETIMERF" + Environment.NewLine;
            selectTxt += "   ,GSLSTSUB.LOGICALDELETECODERF" + Environment.NewLine;
            selectTxt += "   ,GSLSTSUB.SECTIONCODERF" + Environment.NewLine;
            selectTxt += "   ,GSLSTSUB.SALESCODERF" + Environment.NewLine;
            selectTxt += "   ,GSLSTSUB.ENTERPRISEGANRECODERF" + Environment.NewLine;

            selectTxt += " ) AS GSLST" + Environment.NewLine;

            #region [JOIN]
            //拠点情報設定マスタ
            selectTxt += " LEFT JOIN SECINFOSETRF SCINF" + Environment.NewLine;
            selectTxt += " ON  SCINF.ENTERPRISECODERF=GSLST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND SCINF.SECTIONCODERF=GSLST.SECTIONCODERF" + Environment.NewLine;

            //ユーザーガイドマスタ(ボディ)※販売区分名称取得用
            selectTxt += " LEFT JOIN USERGDBDURF USGDUS" + Environment.NewLine;
            selectTxt += " ON  USGDUS.ENTERPRISECODERF=GSLST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USGDUS.GUIDECODERF=GSLST.SALESCODERF" + Environment.NewLine;
            selectTxt += " AND USGDUS.USERGUIDEDIVCDRF=71" + Environment.NewLine;

            //ユーザーガイドマスタ(ボディ)※商品区分名称取得用
            selectTxt += " LEFT JOIN USERGDBDURF USGDUE" + Environment.NewLine;
            selectTxt += " ON  USGDUE.ENTERPRISECODERF=GSLST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USGDUE.GUIDECODERF=GSLST.ENTERPRISEGANRECODERF" + Environment.NewLine;
            selectTxt += " AND USGDUE.USERGUIDEDIVCDRF=41" + Environment.NewLine;
            #endregion  //[JOIN]

            #endregion  //[Select文作成]

            return selectTxt;
        }
        #endregion  //[商品別用 Select文生成処理]

        #region [商品別売上目標設定マスタ用 Where句 生成処理]
        /// <summary>
        /// 商品別売上目標設定マスタ用WHERE句 生成処理 (月計用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>商品別売上目標設定マスタ用WHERE句</returns>
        /// <br>Note       : 商品別売上目標設定マスタ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.11</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalTrgtPrintParamWork CndtnWork,String TblNm1,String TblNm2, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            #region [商品別売上目標設定マスタ]

            //企業コード
            retstring += " "+TblNm1+".ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND " + TblNm1 + ".LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND " + TblNm1 + ".LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }


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
                    retstring += " AND " + TblNm1 + ".SECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //目標対比区分
            retstring += " AND " + TblNm1 + ".TARGETCONTRASTCDRF=@TARGETCONTRASTCD" + Environment.NewLine;
            SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
            paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PrintType);

            //目標設定区分　
            retstring += " AND " + TblNm1 + ".TARGETSETCDRF= 10" + Environment.NewLine;             

            //対象年月開始
            if (CndtnWork.TargetDivideCodeSt != 0)
            {
                retstring += " AND " + TblNm1 + ".TARGETDIVIDECODERF>=@TARGETDIVIDECODERFST" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeSt = sqlCommand.Parameters.Add("@TARGETDIVIDECODERFST", SqlDbType.NChar);
                paraTargetDivideCodeSt.Value = SqlDataMediator.SqlSetString(Convert.ToString(CndtnWork.TargetDivideCodeSt));
            }
            //対象年月終了
            if (CndtnWork.TargetDivideCodeEd != 0)
            {
                retstring += " AND " + TblNm1 + ".TARGETDIVIDECODERF<=@TARGETDIVIDECODERFED" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeEd = sqlCommand.Parameters.Add("@TARGETDIVIDECODERFED", SqlDbType.NChar);
                paraTargetDivideCodeEd.Value = SqlDataMediator.SqlSetString(Convert.ToString(CndtnWork.TargetDivideCodeEd));
            }

            //販売区分開始
            if (CndtnWork.SalesCodeSt != 0)
            {
                retstring += " AND " + TblNm1 + ".ENTERPRISEGANRECODERF>=@ENTERPRISEGANRECODEST" + Environment.NewLine;
                SqlParameter paraSalesCodeSt = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODEST", SqlDbType.Int);
                paraSalesCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SalesCodeSt);
            }
            if ((CndtnWork.EnterpriseGanreCodeEd != 9999) && (CndtnWork.EnterpriseGanreCodeEd != 0))
            {
                retstring += " AND " + TblNm1 + ".ENTERPRISEGANRECODERF<=@ENTERPRISEGANRECODEED" + Environment.NewLine;
                SqlParameter paraEnterpriseGanreCodeEd = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODEED", SqlDbType.Int);
                paraEnterpriseGanreCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.EnterpriseGanreCodeEd);
            }

            //商品区分(自社分類)
            if (CndtnWork.EnterpriseGanreCodeSt != 0)
            {
                retstring += " AND " + TblNm1 + ".SALESCODERF>=@SALESCODEST" + Environment.NewLine;
                SqlParameter paraEnterpriseGanreCodeSt = sqlCommand.Parameters.Add("@SALESCODEST", SqlDbType.Int);
                paraEnterpriseGanreCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.EnterpriseGanreCodeSt);
            }
            if ((CndtnWork.SalesCodeEd != 9999) && (CndtnWork.SalesCodeEd != 0))
            {
                retstring += " AND " + TblNm1 + ".SALESCODERF<=@SALESCODEED" + Environment.NewLine;
                SqlParameter paraSalesCodeEd = sqlCommand.Parameters.Add("@SALESCODEED", SqlDbType.Int);
                paraSalesCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SalesCodeEd);
            }

            #endregion  

            #endregion  //WHERE文作成

            return retstring;
        }
        #endregion  //[Where句 生成処理]

        #region [CopyToSalesRsltListResultWorkFromReader処理 呼出]
        /// <summary>
        /// クラス格納処理 Reader → CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CopyToSalesRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.11</br>
        /// </remarks>
        public SalTrgtPrintResultWork CopyToSalesRsltListResultWorkFromReader(ref SqlDataReader myReader, SalTrgtPrintParamWork CndtnWork)
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
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.11</br>
        /// </remarks>
        private SalTrgtPrintResultWork CopyToSalesRsltListResultWorkFromReaderProc(ref SqlDataReader myReader, SalTrgtPrintParamWork CndtnWork)
        {
            #region [抽出結果-値セット]
            SalTrgtPrintResultWork ResultWork = new SalTrgtPrintResultWork();
            ResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            ResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            ResultWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
            ResultWork.SalesCodeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCODENAME"));
            ResultWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            ResultWork.EnterpriseGanreCodeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODENAME"));
            ResultWork.SalesTargetMoney1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY1"));
            ResultWork.SalesTargetMoney2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY2"));
            ResultWork.SalesTargetMoney3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY3"));
            ResultWork.SalesTargetMoney4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY4"));
            ResultWork.SalesTargetMoney5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY5"));
            ResultWork.SalesTargetMoney6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY6"));
            ResultWork.SalesTargetMoney7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY7"));
            ResultWork.SalesTargetMoney8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY8"));
            ResultWork.SalesTargetMoney9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY9"));
            ResultWork.SalesTargetMoney10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY10"));
            ResultWork.SalesTargetMoney11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY11"));
            ResultWork.SalesTargetMoney12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY12"));
            ResultWork.SalesTargetProfit1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT1"));
            ResultWork.SalesTargetProfit2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT2"));
            ResultWork.SalesTargetProfit3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT3"));
            ResultWork.SalesTargetProfit4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT4"));
            ResultWork.SalesTargetProfit5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT5"));
            ResultWork.SalesTargetProfit6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT6"));
            ResultWork.SalesTargetProfit7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT7"));
            ResultWork.SalesTargetProfit8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT8"));
            ResultWork.SalesTargetProfit9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT9"));
            ResultWork.SalesTargetProfit10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT10"));
            ResultWork.SalesTargetProfit11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT11"));
            ResultWork.SalesTargetProfit12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT12"));
            #endregion  //[抽出結果-値セット]

            return ResultWork;
        }
        #endregion //[CopyToSalesRsltListResultWorkFromReader処理]
    }
}
