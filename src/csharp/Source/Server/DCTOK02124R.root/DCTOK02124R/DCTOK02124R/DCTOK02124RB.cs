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
        string MakeSelectString(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork);
        SalesRsltListResultWork CopyToSalesRsltListResultWorkFromReader(ref SqlDataReader myReader, SalesRsltListCndtnWork CndtnWork);
    }

    /// <summary>
    /// TotalType����Ώۂ̏W�v�P�ʂ�񋓂��܂��B
    /// </summary>
    enum TotalType
    {
        Goods = 0,     //0:���i��
        Customer = 1,  //1:���Ӑ��
        Agent = 2,     //2:�S���ҕ�
        Whouse = 3,    //3:�q�ɕ�
        Supplier = 4   //4:�d�����  // ADD 2009/04/11
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

    /// <summary>
    /// ���s�^�C�v��񋓂��܂��B
    /// </summary>
    enum PrintType
    {
        SecWhous = 0,   //0:���_�ʑq�ɕ�
        WhousCstm = 1,  //1:�q�ɕʓ��Ӑ��
        WhousSec = 2    //2:�q�ɕʋ��_��
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
