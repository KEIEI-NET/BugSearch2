//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : コンバート対象バージョン管理マスタメンテナンス
// プログラム概要   : コンバート対象バージョン管理マスタの登録・変更を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 佐々木亘
// 作 成 日  2020/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// コンバート対象バージョン管理マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象バージョン管理マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 佐々木亘</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IConvObjVerMngDB
    {
        /// <summary>
        /// コンバート対象バージョン管理LISTを全て戻します
        /// </summary>
        /// <param name="outConvObjVerMng">検索結果</param>
        /// <param name="paraConvObjVerMngWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象バージョン管理LISTを全て戻します</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMCMN00136D", "Broadleaf.Application.Remoting.ParamData.ConvObjVerMngWork")]
			out object outConvObjVerMng,
            object paraConvObjVerMngWork);
    }
}
