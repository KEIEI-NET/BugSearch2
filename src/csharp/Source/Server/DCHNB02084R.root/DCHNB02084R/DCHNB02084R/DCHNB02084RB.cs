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
    interface IMTtlSaSlip
    {
        string MakeSelectString(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork cndtnWork);
        SalesMonthYearReportResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader, SalesMonthYearReportParamWork paramWork);
    }

    /// <summary>
    /// TotalTypeから対象の集計単位を列挙します。
    /// </summary>
    enum TotalType
    {
        Customer = 0,  //0:得意先別
        Agent = 1,     //1:担当者別
        AcpOdr = 2,    //2:受注者別
        Pblsher = 3,   //3:発行者別
        Area = 4,      //4:地区別
        BzType = 5,    //5:業種別
        SaleCd = 6     //6:販売区分別
    }

    /// <summary>
    /// 従業員区分を列挙します。
    /// </summary>
    enum EmployeeDivCd
    {
        Agent = 10,   //10:販売担当者
        AcpOdr = 20,  //20:受付担当者
        Pblsher = 30  //30:入力担当者
    }

    /// <summary>
    /// ユーザーガイドマスタ参照用ユーザーガイド区分を列挙します。
    /// </summary>
    enum UserGuideDivCd
    {
        SalesAreaCode = 21,     //販売エリア区分
        BusinessTypeCode = 33,  //業種
        SalesCode = 71          //販売区分
    }

    /// <summary>
    /// 印刷タイプを列挙します。
    /// </summary>
    enum PrintType
    {
        Month = 0,   //当月
        Annual = 1,  //当期
        All = 2      //当月＆当期
    }

    class MTtlSaSlipBase
    {
        /// <summary>
        /// 引数文字列の表示/非表示を判定します。
        /// </summary>
        /// <param name="bCondition">条件式</param>
        /// <param name="Text">文字列</param>
        /// <returns></returns>
        protected string IFBy(Boolean bCondition, string Text)
        {
            if (bCondition) return Text;
            else return "";
        }

        /// <summary>
        /// 印刷タイプで異なるSQL文を生成します。(売上月次集計データ)
        /// SELECT文の抽出項目の選定とGROUP BYに使用します。
        /// </summary>
        /// <param name="iPrintType">0:当月 1:当期 2:当月＆当期</param>
        /// <param name="sTblNm">テーブル名</param>
        /// <returns></returns>
        protected string GetPrintType_SQLCMD_MT(Int32 iPrintType, string sTblNm)
        {
            string sRetBuf = null;

            #region [印刷タイプ確認]
            //当月分を抽出するかどうか
            if (iPrintType == (int)PrintType.Month)
            {
                #region [当月]
                sRetBuf += " ," + sTblNm + ".MONTHSALESMONEY" + Environment.NewLine;
                sRetBuf += " ," + sTblNm + ".MONTHSALESRETGOODSPRICE" + Environment.NewLine;
                sRetBuf += " ," + sTblNm + ".MONTHDISCOUNTPRICE" + Environment.NewLine;
                sRetBuf += " ," + sTblNm + ".MONTHGROSSPROFIT" + Environment.NewLine;
                #endregion
            }
            //当期分を抽出するかどうか
            if (iPrintType == (int)PrintType.Annual)
            {
                #region [当期]
                sRetBuf += " ," + sTblNm + ".ANNUALSALESMONEY" + Environment.NewLine;
                sRetBuf += " ," + sTblNm + ".ANNUALSALESRETGOODSPRICE" + Environment.NewLine;
                sRetBuf += " ," + sTblNm + ".ANNUALDISCOUNTPRICE" + Environment.NewLine;
                sRetBuf += " ," + sTblNm + ".ANNUALGROSSPROFIT" + Environment.NewLine;
                #endregion
            }
            #endregion

            return sRetBuf;
        }

        /// <summary>
        /// 印刷タイプで異なるSQL文を生成します。(売上目標設定マスタ)
        /// SELECT文の抽出項目の選定とGROUP BYに使用します。
        /// </summary>
        /// <param name="iPrintType">0:当月 1:当期 2:当月＆当期</param>
        /// <param name="sTblNm">テーブル名</param>
        /// <returns></returns>
        protected string GetPrintType_SQLCMD_ST(Int32 iPrintType, string sTblNm)
        {
            string sRetBuf = null;

            #region [印刷タイプ確認]
            //当月分を抽出するかどうか
            if (iPrintType == (int)PrintType.Month)
            {
                #region [当月]
                sRetBuf += " ," + sTblNm + ".MONTHSALESTARGETMONEY" + Environment.NewLine;
                sRetBuf += " ," + sTblNm + ".MONTHSALESTARGETPROFIT" + Environment.NewLine;
                #endregion
            }
            //当期分を抽出するかどうか
            if (iPrintType == (int)PrintType.Annual)
            {
                #region [当期]
                sRetBuf += " ," + sTblNm + ".ANNUALSALESTARGETMONEY" + Environment.NewLine;
                sRetBuf += " ," + sTblNm + ".ANNUALSALESTARGETPROFIT" + Environment.NewLine;
                #endregion
            }
            #endregion

            return sRetBuf;
        }

        /// <summary>
        /// 集計単位と出力順から対応するSQL文を生成します。(売上月次集計データ)
        /// </summary>
        /// <param name="iTotalType">集計単位</param>
        /// <param name="iOutType">出力順</param>
        /// <param name="iTtlType">集計方法</param>
        /// <param name="sTblNm">テーブル名略称</param>
        /// <returns></returns>
        protected string GetOutType_SQLCMD_MT(Int32 iTotalType, Int32 iOutType, Int32 iTtlType, string sTblNm)
        {
            string sRetBuf = null;

            #region [集計単位確認]
            switch (iTotalType)
            {
                case (int)TotalType.Customer:  //0:得意先別
                    #region [出力順確認]
                    if ((iTtlType == 1) && (iOutType != 3))
                        sRetBuf += "," + sTblNm + ".ADDUPSECCODERF" + Environment.NewLine;  //計上拠点コード
                    if ((iOutType == 0) ||
                        (iOutType == 2) ||
                        (iOutType == 3) ||
                        (iOutType == 4))
                    {
                        sRetBuf += "," + sTblNm + ".CUSTOMERCODERF" + Environment.NewLine;  //得意先コード
                    }
                    #endregion
                    break;
                case (int)TotalType.Agent:     //1:担当者別
                case (int)TotalType.AcpOdr:    //2:受注者別
                case (int)TotalType.Pblsher:   //3:発行者別
                    #region [出力順確認]
                    sRetBuf += "," + sTblNm + ".EMPLOYEECODERF" + Environment.NewLine;      //従業員コード
                    if ((iTtlType == 1) && (iOutType != 3))
                        sRetBuf += "," + sTblNm + ".ADDUPSECCODERF" + Environment.NewLine;  //計上拠点コード
                    if (iOutType == 1)
                        sRetBuf += "," + sTblNm + ".CUSTOMERCODERF" + Environment.NewLine;  //得意先コード
                    #endregion
                    break;
                case (int)TotalType.Area:      //4:地区別
                case (int)TotalType.BzType:    //5:業種別
                    #region [出力順確認]
                    if ((iTtlType == 1) && (iOutType != 3))
                        sRetBuf += "," + sTblNm + ".ADDUPSECCODERF" + Environment.NewLine;  //計上拠点コード
                    if (iOutType == 1)
                        sRetBuf += "," + sTblNm + ".CUSTOMERCODERF" + Environment.NewLine;  //得意先コード
                    #endregion
                    break;
                case (int)TotalType.SaleCd:    //6:販売区分別
                    //販売区分別の場合はなし
                    break;
                default:
                    break;
            }
            #endregion

            return sRetBuf;
        }
    }
}
