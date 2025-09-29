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
        string MakeSelectString(ref SqlCommand sqlCommand, StockTransListCndtnWork CndtnWork);
        StockTransListResultWork CopyToStockRsltListResultWorkFromReader(ref SqlDataReader myReader, StockTransListCndtnWork CndtnWork);

    }

    enum TermDiv
    {
        MonthBound = 0,
        YearBound = 1
    };

    class MTtlStSlipBase
    {
        protected string IFBySection(int GroupBySectionDiv, string Text)
        {
            string Result = "";
            if (GroupBySectionDiv == 1)
                Result = Text;

            return Result;
        }

        protected int IncMonth(int YearMonth, int nMonth)
        {
            int YM = YearMonth + nMonth;
            int Year = YM / 100;
            int Month = YM % 100;

            while (Month > 12)
            {
                Year += 1;
                Month -= 12;
            }
            int result = Year * 100 + Month;
            
            return result;
        }
    }
}
