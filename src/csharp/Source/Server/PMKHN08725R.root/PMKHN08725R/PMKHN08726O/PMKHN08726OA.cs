//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 表示区分マスタ（印刷）
// プログラム概要   : 表示区分マスタ（印刷）DBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 作 成 日  2012/06/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 表示区分マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 表示区分マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 姚学剛</br>
    /// <br>Date       : 2012/06/11</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPriceSelectSetWorkDB
    {
        /// <summary>
        /// 表示区分マスタ印刷のLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="priceSelectSetCndtnWork">検索結果</param>
        /// <param name="priceSelectSetResultWork">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 表示区分マスタ印刷のLISTを全て戻します（論理削除除く）。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN08727D", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetResultWork")]
            out object priceSelectSetResultWork,
            object priceSelectSetCndtnWork,
            ConstantManagement.LogicalMode logicalMode);
    }
}
