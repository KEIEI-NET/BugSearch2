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
    interface IMTtlStSlip
    {
        string MakeSelectString(ref SqlCommand sqlCommand, StockMonthYearReportParamWork cndtnWork);
        StockMonthYearReportResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader, StockMonthYearReportParamWork paramWork);
    }

    enum TermDiv
    {
        MonthBound = 0,
        YearBound = 1
    };

    //0:拠点別 1:仕入先別 2:担当者別 3:部署別 4:メーカー別 5:仕入先別メーカー別
    enum TotalTypes
    {
        n0_Section = 0,
        n1_Seller = 1,
        n2_Employee = 2,
        n3_SubSection = 3,
        n4_Maker = 4,
        n5_SellerAndMaker = 5
    };

    enum SectDiv
    {
        n0_Section = 0,
        n1_SubSection = 1,
        n2_MinSection = 2
    }

    class MTtlStSlipBase
    {
        protected string IFBy(Boolean bCondition, string Text)
        {
            if (bCondition) return Text;
            else return "";
        }

        protected string FirstCommaToSpace(string text)
        {
            string s = "";
            if (text.Length > 0)
            {
                if (text[0] == ',')
                    s = text.Substring(1, text.Length - 1);
                else
                    s = text;
            }
            return s;
        }

        protected string FirstANDToSpace(string text)
        {
            string s = "";
            if (text.Length >= 4)
            {
                if (text.Substring(0, 4) == "AND ")
                    s = text.Substring(4, text.Length - 4);
                else
                    s = text;
            }
            return s;
        }
    }
}
