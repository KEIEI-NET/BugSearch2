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
//using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    interface IMTtlSaSlip
    {
        string MakeSelectString(ref SqlCommand sqlCommand, SalesAnnualDataSelectParamWork cndtnWork,int paratotalDiv);
        SalesAnnualDataSelectResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader, SalesAnnualDataSelectParamWork paramWork);
        string MakeWhereString(ref SqlCommand sqlCommand, SalesAnnualDataSelectParamWork paramWork, string prefName, SlipTargetDiv slipTargetDiv, int SubSlip);
    }

    enum TermDiv
    {
        MonthBound = 0,
        YearBound = 1
    };

    enum SlipTargetDiv
    {
        Slip = 0,
        Target = 1,
        SalesHist = 2,
        TargetDay = 3
    }

    //0:‹’“_,1:“¾ˆÓæ,2:’S“–ŽÒ,3:’n‹æ,4:‹ÆŽí
    enum TotalDivs
    {
        Section = 0,
        Customer = 1,
        SalesEmp = 2,
        Area = 3,
        BizType = 4
    };

    enum SectDiv
    {
        Section = 0,
        SubSection = 1,
        MinSection = 2
    }

    class MTtlSaSlipBase
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
