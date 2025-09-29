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
    /// TotalTypeから対象の集計単位を列挙します。
    /// </summary>
    enum TotalType
    {
        Goods = 0,     //0:商品別
        BLCode = 1,    //1:BLコード別
        Customer = 2,  //2:得意先別
        Agent = 3      //3:担当者別
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
    /// 順位設定を列挙します。
    /// </summary>
    enum Order
    {
        Quantity = 0,     //0:数量
        Count = 1,        //1:回数
        SalesMoney = 2,   //2:売上金額
        GrossProfit = 3,  //3:粗利金額
        GoodsNo = 4       //4:品番（順位無し）
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
