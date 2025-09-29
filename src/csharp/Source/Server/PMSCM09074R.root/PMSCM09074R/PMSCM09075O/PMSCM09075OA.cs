//********************************************************************//
// System           :   PM.NS                                         //
// Sub System       :                                                 //
// Program name     :   売上連携設定RemoteObjectインターフェース      //
//                  :   PMSCM09075O.DLL                               //
// Name Space       :   Broadleaf.Application.Remoting                //
// Programmer       :   gaoy                                          //
// Date             :   2011.07.23                                    //
//--------------------------------------------------------------------//
// Update Note      :                                                 //
//--------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.               //
//********************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上連携設定RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上連携設定RemoteObjectインターフェースです。</br>
    /// <br>Programmer : gaoy</br>
    /// <br>Date       : 2011.07.25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPM7RkSettingDB
    {

        /// <summary>
        /// 指定された企業コードの売上連携設定を戻します
        /// </summary>
        /// <param name="pm7RkSettingWork">PM7RkSettingWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードの売上連携設定を戻します</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.25</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMSCM09076D", "Broadleaf.Application.Remoting.ParamData.PM7RkSettingWork")]
            ref ArrayList pm7RkSettingWork,
            Int32 readMode);

        /// <summary>
        /// 売上連携設定情報の登録、更新
        /// </summary>
        /// <param name="parabyte">PM7RkSettingWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上連携設定情報を登録、更新します</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.25</br>
        /// </remarks>
        int Write(ref byte[] parabyte);

    }
}