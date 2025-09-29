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
        string MakeSelectString(ref SqlCommand sqlCommand, SalesTransListCndtnWork CndtnWork);
        SalesTransListResultWork CopyToSalesRsltListResultWorkFromReader(ref SqlDataReader myReader, SalesTransListCndtnWork CndtnWork);

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
        Goods = 0,     //0:���i��
        Customer = 1,  //1:���Ӑ��
        Agent = 2,     //2:�S���ҕ�
        Supplier = 3,  //3:�d�����   // ADD 2009/04/15
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
