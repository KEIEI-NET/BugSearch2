//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 卸商商品価格改正
// プログラム概要   : 卸商商品価格改正を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 卸商商品価格改正DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 卸商商品価格改正DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009/04/28</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsInfoWorkDB
    {

        /// <summary>
        /// 卸商商品価格改正のLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="trustStockResultWork">検索結果</param>
        /// <param name="trustStockOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        [MustCustomSerialization]
        int WriteGoodsInfo(
            // [CustomSerializationMethodParameterAttribute("PMKHN02313D", "Broadleaf.Application.Remoting.ParamData.TrustStockResultWork")]
               out object countNum,
              [CustomSerializationMethodParameterAttribute("PMKHN02313D", "Broadleaf.Application.Remoting.ParamData.GoodsInfoDataWork")] out  object writeError,
              [CustomSerializationMethodParameterAttribute("PMKHN02313D", "Broadleaf.Application.Remoting.ParamData.GoodsInfoDataWork")] ref  object noramlGoodsInfoDataWorkLst,
              [CustomSerializationMethodParameterAttribute("PMKHN02313D", "Broadleaf.Application.Remoting.ParamData.GoodsInfoDataWork")] ref  object warnGoodsInfoDataWorkLst,
           object goodsInfoCndtnWork);

    }
}
