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
    interface ISalesSlipReport
    {
        string MakeSelectString(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork cndtnWork);
        SalesDayMonthReportResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader, SalesDayMonthReportParamWork paramWork);
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
    };

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

    class SalesSlipReportBase
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
        /// 集計単位と出力順から対応するSQL文を生成します。
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
                        //sRetBuf += "," + sTblNm + ".SECTIONCODERF" + Environment.NewLine;   //拠点コード // DEL 2008.12.08
                        sRetBuf += "," + sTblNm + ".RESULTSADDUPSECCDRF" + Environment.NewLine;   //拠点コード // ADD 2008.12.08
                    if ((iOutType == 0) ||
                        (iOutType == 2) ||
                        (iOutType == 3))
                    {
                        sRetBuf += "," + sTblNm + ".CUSTOMERCODERF" + Environment.NewLine;  //得意先コード
                    }
                    #endregion
                    break;
                case (int)TotalType.Agent:     //1:担当者別
                case (int)TotalType.AcpOdr:    //2:受注者別
                case (int)TotalType.Pblsher:   //3:発行者別
                    #region [出力順確認]
                    //共通使用
                    sRetBuf += IFBy(iTotalType == (int)TotalType.Agent,
                               "," + sTblNm + ".SALESEMPLOYEECDRF" + Environment.NewLine);  //販売従業員コード
                    sRetBuf += IFBy(iTotalType == (int)TotalType.AcpOdr,
                               "," + sTblNm + ".FRONTEMPLOYEECDRF" + Environment.NewLine);  //受付従業員コード
                    sRetBuf += IFBy(iTotalType == (int)TotalType.Pblsher,
                               "," + sTblNm + ".SALESINPUTCODERF" + Environment.NewLine);   //売上入力者コード
                    if ((iTtlType == 1) && (iOutType != 3))
                        //sRetBuf += "," + sTblNm + ".SECTIONCODERF" + Environment.NewLine;   //拠点コード // DEL 2008.12.08
                        sRetBuf += "," + sTblNm + ".RESULTSADDUPSECCDRF" + Environment.NewLine;   //拠点コード // ADD 2008.12.08
                    if (iOutType == 1)
                        sRetBuf += "," + sTblNm + ".CUSTOMERCODERF" + Environment.NewLine;  //得意先コード
                    #endregion
                    break;
                case (int)TotalType.Area:      //4:地区別
                case (int)TotalType.BzType:    //5:業種別
                    #region [出力順確認]
                    if (iTtlType == 1)
                        //sRetBuf += "," + sTblNm + ".SECTIONCODERF" + Environment.NewLine;   //拠点コード // DEL 2008.12.08
                        sRetBuf += "," + sTblNm + ".RESULTSADDUPSECCDRF" + Environment.NewLine;   //拠点コード // ADD 2008.12.08
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
