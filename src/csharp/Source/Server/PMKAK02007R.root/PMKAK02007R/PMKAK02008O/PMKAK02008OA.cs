//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 支払一覧表（総括）
// プログラム概要   : 支払一覧表（総括）の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI東　隆史
// 作 成 日  2012/09/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 支払一覧表（総括）DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払一覧表（総括）DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : FSI東 隆史</br>
    /// <br>Date       : 2012/09/04</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISumPaymentTableDB
    {

        /// <summary>
        /// 支払一覧表（総括）を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/09/04</br>
        [MustCustomSerialization]
        int SearchPaymentTable([CustomSerializationMethodParameterAttribute("PMKAK02009D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_SumPaymentTotalWork")]out object retObj, object paraObj);

    }
}
