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
        string MakeSelectString(ref SqlCommand sqlCommand, CustSalesDistributionReportParamWork ParamWork);
        CustSalesDistributionReportResultWork CopyToSalesRsltListResultWorkFromReader(ref SqlDataReader myReader, CustSalesDistributionReportParamWork ParamWork);

    }

    enum TermDiv
    {
        MonthBound = 0,
        YearBound = 1
    };

    /// <summary>
    /// TotalTypeから対象の集計単位を列挙します。
    /// </summary>
    enum TotalType
    {
        Customer = 0,  //0:得意先
        Agent = 1,     //1:担当者
        Area = 2,      //2:地区

    }

    /// <summary>
    /// 在庫取寄せ区分を列挙します。
    /// </summary>
    enum RsltTtlDivCd
    {
        PrtTtl = 0,  //合計
        Stock = 1,   //在庫
        Order = 2    //取寄せ
    }

    class MTtlSaSlipBase
    {
        protected string IFBy(Boolean bCondition, string Text)
        {
            if (bCondition) return Text;
            else return "";
        }
    }
}
