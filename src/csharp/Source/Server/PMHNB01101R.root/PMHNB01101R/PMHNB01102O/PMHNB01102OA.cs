//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   売上月次集計データ更新DBインターフェース
//                  :   PMHNB01102O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112　久保田　誠
// Date             :   2008.05.19
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
    /// 売上月次集計データ更新DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上月次集計データ更新DBインターフェースです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2008.05.19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IMonthlyTtlSalesUpdDB
    {
        /// <summary>
        /// 指定された条件に基づいて、各種月次集計データを物理削除します。
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に基づいて、各種月次集計データを物理削除します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.05.19</br>
        int Delete([CustomSerializationMethodParameterAttribute("PMHNB01103D", "Broadleaf.Application.Remoting.ParamData.MTtlSalesUpdParaWork")]
            MTtlSalesUpdParaWork mTtlSalesUpdParaWork);

        /// <summary>
        /// 指定された条件に基づいて、各種月次集計データを再集計します。
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に基づいて、各種月次集計データを再集計します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.05.19</br>
        int ReCount([CustomSerializationMethodParameterAttribute("PMHNB01103D", "Broadleaf.Application.Remoting.ParamData.MTtlSalesUpdParaWork")]
            MTtlSalesUpdParaWork mTtlSalesUpdParaWork);


        // ---ADD 2009/12/24 -------->>>
        /// <summary>
        /// 指定された条件に基づいて、各種月次集計データを再集計します。
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWorkオブジェクト</param>
        /// <param name="connection">ＤＢ接続オブジェクト</param>
        /// <param name="transaction">sqlTransactionオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に基づいて、各種月次集計データを再集計します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/24</br>
        int ReCountProc([CustomSerializationMethodParameterAttribute("PMHNB01103D", "Broadleaf.Application.Remoting.ParamData.MTtlSalesUpdParaWork")]
            MTtlSalesUpdParaWork mTtlSalesUpdParaWork, ref SqlConnection connection, ref SqlTransaction transaction);
        // ---ADD 2009/12/24 --------<<<
    }
}
