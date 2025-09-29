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
    /// TotalTypeから対象の集計単位を列挙します。
    /// </summary>
    enum TotalType
    {
        Goods = 0,     //0:商品別
        Customer = 1,  //1:得意先別
        Agent = 2,     //2:担当者別
        Whouse = 3,    //3:倉庫別
        Supplier = 4   //4:仕入先別  // ADD 2009/04/11
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

    /// <summary>
    /// 発行タイプを列挙します。
    /// </summary>
    enum PrintType
    {
        SecWhous = 0,   //0:拠点別倉庫別
        WhousCstm = 1,  //1:倉庫別得意先別
        WhousSec = 2    //2:倉庫別拠点別
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
