//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌出荷部品表示
// プログラム概要   : 車輌出荷部品表示を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/09/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 車輌出荷部品表示DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車輌出荷部品表示DBインターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.09.10</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICarShipmentPartsDispDB
    {
        /// <summary>
        /// 車両管理マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="carManagementList">検索結果</param>
        /// <param name="carManagementObj">検索条件</param>
        /// <remarks>
        /// <br>Note       : 車輌出荷部品表示DBインターフェースです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        [MustCustomSerialization]
        int CarInfoSearch(
            [CustomSerializationMethodParameterAttribute("PMSYA04007D", "Broadleaf.Application.Remoting.ParamData.CarShipmentPartsDispWork")]
            ref ArrayList carManagementList,
            object carManagementObj);
    }
}
