//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCMデータ受信処理起動DBインターフェース
//                  :   PMSCM01056O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21024　佐々木 健
// Date             :   2010/05/20
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// SCMデータ受信処理起動DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCMデータ受信処理起動DBインターフェースです。</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/03/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISCMDtRcveExecDB
    {
        /// <summary>
        /// SCMデータ受信処理を起動します
        /// </summary>
        /// <param name="wait">True:受信処理の終了を待ちます</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCMデータ受信処理を起動します</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/05/20</br>
        int ExecuteDataReceive(
            bool wait
            );
    }
}
