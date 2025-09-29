//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 入荷差異表DB RemoteObjectインターフェース
// プログラム概要   : 入荷差異表DB RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570136-00  作成担当 : 譚洪
// 作 成 日  K2019/08/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 入荷差異表 リモートオブジェクトインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入荷差異表 リモート インターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : K2019/08/14</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IArrGoodsDiffResultDB
    {
        #region [カスタムシリアライズ対応メソッド]
        /// <summary>
        /// 入荷差異表データを戻します:カスタムシリアライズ
        /// </summary>
        /// <param name="ArrGoodsDiffResultWork">検索結果</param>
        /// <param name="ArrGoodsDiffCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKOU02358D", "Broadleaf.Application.Remoting.ParamData.ArrGoodsDiffResultWork")]
            out object ArrGoodsDiffResultWork,
            object ArrGoodsDiffCndtnWork);
        #endregion
    }
}
