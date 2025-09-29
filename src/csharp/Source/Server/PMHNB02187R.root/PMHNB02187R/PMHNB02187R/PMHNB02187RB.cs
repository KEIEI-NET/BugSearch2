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
    /// TotalType����Ώۂ̏W�v�P�ʂ�񋓂��܂��B
    /// </summary>
    enum TotalType
    {
        Customer = 0,  //0:���Ӑ�
        Agent = 1,     //1:�S����
        Area = 2,      //2:�n��

    }

    /// <summary>
    /// �݌Ɏ�񂹋敪��񋓂��܂��B
    /// </summary>
    enum RsltTtlDivCd
    {
        PrtTtl = 0,  //���v
        Stock = 1,   //�݌�
        Order = 2    //���
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
