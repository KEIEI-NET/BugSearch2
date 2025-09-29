//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン実績表
// プログラム概要   : キャンペーン実績表　リモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/05/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
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
    interface IMTtlCampaign
    {
        string MakeSalesSelectString(ref SqlConnection sqlConnection, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork);
        string MakeTargetSelectString(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork);
        CampaignstRsltListResultWork CopyToCampaignSalesWorkFromReader(ref SqlDataReader myReader, CampaignstRsltListPrtWork CndtnWork);
        CampaignstRsltListResultWork CopyToCampaignTargetWorkFromReader(ref SqlDataReader myReader, CampaignstRsltListPrtWork CndtnWork);
    }

    /// <summary>
    /// TotalTypeから対象の集計単位を列挙します。
    /// </summary>
    enum TotalType
    {
        Goods = 0,     //0:商品別
        Customer = 1,  //1:得意先別
        Employee = 2,  //2:担当者別
        AcceptOdr = 3, //3:受注者別
        Printer = 4,   //4:発行者別
        Area = 5,      //5:地区別
        Sales = 6,     //6:販売区分別
    }

    class MTtlCampaignBase
    {
        protected string IFBy(Boolean bCondition, string Text)
        {
            if (bCondition) return Text;
            else return "";
        }
    }
}
