//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索部品マスタ印刷
// プログラム概要   : 自由検索部品マスタ印刷 DBRemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 自由検索部品マスタ印刷用DB Access RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索部品マスタ印刷用DB Access RemoteObjectインターフェースです。</br>
    /// <br>Programmer : 王海立</br>
    /// <br>Date       : 2010/04/27</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IFreeSearchPartsPrintDB
    {
        /// <summary>
        /// 自由検索部品マスタ検索処理
        /// </summary>
        /// <param name="paraWork">自由検索部品マスタ（印刷）条件クラス</param>
        /// <param name="retList">結果コレクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索部品マスタ検索処理を行うクラスです。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchAll(object paraWork, [CustomSerializationMethodParameterAttribute("PMJKN02019D", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsPrintWork")]out object retList);
    }
}
