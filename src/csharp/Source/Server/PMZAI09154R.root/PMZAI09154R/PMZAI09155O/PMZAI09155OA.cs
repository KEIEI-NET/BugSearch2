//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   在庫履歴現在庫数設定DBインターフェース
//                  :   PMZAI09155O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   李占川
// Date             :   2009/12/24
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫履歴現在庫数設定DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫履歴現在庫数設定DBインターフェースです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009/12/24</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockHistoryUpdateDB
    {
        /// <summary>
        /// 指定された条件に基づいて、在庫履歴現在庫数を再集計します。
        /// </summary>
        /// <param name="stockHistoryUpdateWork">StockHistoryUpdateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件に基づいて、在庫履歴現在庫数を再集計します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        int ReCount([CustomSerializationMethodParameterAttribute("PMZAI09156D", "Broadleaf.Application.Remoting.ParamData.StockHistoryUpdateWork")]
            StockHistoryUpdateWork stockHistoryUpdateWork);
    }
}
