//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 得意先別見積書・棚卸表 
// プログラム概要   : 得意先別見積書・棚卸表 RemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10970531-00  作成担当 : songg
// 作 成 日  K2013/12/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先別見積書・棚卸表DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先別見積書・棚卸表DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : songg</br>
    /// <br>Date       : K2013/12/03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITakekawaQuotaInventWorkDB
    {

        /// <summary>
        /// 得意先別見積書・棚卸表を戻します
        /// </summary>
        /// <param name="takekawaQuotaInventResultWork">検索結果</param>
        /// <param name="goodsPriceUWorkList">価格マスタリスト</param>
        /// <param name=" takekawaQuotaInventCndtnWork">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先別見積書・棚卸表を戻します</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        [MustCustomSerialization]
        int Search(
          [CustomSerializationMethodParameterAttribute("PMMIT02009DC", "Broadleaf.Application.Remoting.ParamData.TakekawaQuotaInventResultWork")]
          out object takekawaQuotaInventResultWork,
          [CustomSerializationMethodParameterAttribute("MAKHN09176D", "Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
          out object goodsPriceUWorkList,     
          object takekawaQuotaInventCndtnWork, ConstantManagement.LogicalMode logicalMode);

    }
}
