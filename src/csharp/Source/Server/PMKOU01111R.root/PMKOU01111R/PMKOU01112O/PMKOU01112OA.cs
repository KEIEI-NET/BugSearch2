//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   仕入月次集計データ更新DBインターフェース
//                  :   PMKOU01112O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   30290
// Date             :   2008.12.12
//----------------------------------------------------------------------
// Update Note      :　 2009/12/24 譚洪 ＰＭ．ＮＳ保守依頼④
//                             ・一括リアル更新の新規を対応
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;

using System.Data.SqlClient;    // ADD 2009/12/24

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入月次集計データ更新DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入月次集計データ更新DBインターフェースです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.12.12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IMonthlyTtlStockUpdDB
    {
        /// <summary>
        /// 指定された条件に基づいて、各種月次集計データを物理削除します。
        /// </summary>
        /// <param name="MTtlStockUpdParaWork">MTtlStockUpdParaWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に基づいて、各種月次集計データを物理削除します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        int Delete([CustomSerializationMethodParameterAttribute("PMKOU01113D", "Broadleaf.Application.Remoting.ParamData.MTtlStockUpdParaWork")]
            MTtlStockUpdParaWork MTtlStockUpdParaWork);

        /// <summary>
        /// 指定された条件に基づいて、各種月次集計データを再集計します。
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に基づいて、各種月次集計データを再集計します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        int ReCount([CustomSerializationMethodParameterAttribute("PMKOU01113D", "Broadleaf.Application.Remoting.ParamData.MTtlStockUpdParaWork")]
            MTtlStockUpdParaWork mTtlStockUpdParaWork);

        // ---ADD 2009/12/24 -------->>>
        /// <summary>
        /// 指定された条件に基づいて、各種月次集計データを再集計します。
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWorkオブジェクト</param>
        /// <param name="connection">ＤＢ接続オブジェクト</param>
        /// <param name="transaction">sqlTransactionオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に基づいて、各種月次集計データを再集計します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/24</br>
        int ReCountProc([CustomSerializationMethodParameterAttribute("PMKOU01113D", "Broadleaf.Application.Remoting.ParamData.MTtlStockUpdParaWork")]
            MTtlStockUpdParaWork mTtlStockUpdParaWork, ref SqlConnection connection, ref SqlTransaction transaction);
        // ---ADD 2009/12/24 --------<<<
    }
}
