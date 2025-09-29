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
        string MakeSelectString(ref SqlCommand sqlCommand, ShipmGoodsOdrReportParamWork CndtnWork);
        ShipmGoodsOdrReportResultWork CopyToSalesRsltListResultWorkFromReader(ref SqlDataReader myReader, ShipmGoodsOdrReportParamWork CndtnWork);
    }

    /// <summary>
    /// TotalType����Ώۂ̏W�v�P�ʂ�񋓂��܂��B
    /// </summary>
    enum TotalType
    {
        Goods = 0,     //0:���i��
        BLCode = 1,    //1:BL�R�[�h��
        Customer = 2,  //2:���Ӑ��
        Agent = 3      //3:�S���ҕ�
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
    /// ���ʐݒ��񋓂��܂��B
    /// </summary>
    enum Order
    {
        Quantity = 0,     //0:����
        Count = 1,        //1:��
        SalesMoney = 2,   //2:������z
        GrossProfit = 3,  //3:�e�����z
        GoodsNo = 4       //4:�i�ԁi���ʖ����j
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
