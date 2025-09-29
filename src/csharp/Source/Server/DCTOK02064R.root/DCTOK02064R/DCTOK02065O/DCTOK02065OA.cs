using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 出荷商品分析表DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出荷商品分析表DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2007.11.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IShipGoodsAnalyzeDB
    {

        /// <summary>
        /// 出荷商品分析表を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の出荷商品分析表を戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.11.21</br>
        [MustCustomSerialization]
        int SearchShipGoodsAnalyze(
            [CustomSerializationMethodParameterAttribute("DCTOK02066D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_ShipGoodsAnalyzeWork")]
            out object retObj,
            object paraObj,
            ConstantManagement.LogicalMode logicalMode
            );

    }
}
