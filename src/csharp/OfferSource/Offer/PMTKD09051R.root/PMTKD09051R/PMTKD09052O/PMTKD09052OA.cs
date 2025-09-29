using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品中分類 RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品中分類 RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]

    public interface IGoodsMGroupDB
    {
        /// <summary>
        /// 指定された商品中分類コードの商品中分類マスタを戻します
        /// </summary>
        /// <param name="goodsMGroupList">検索結果</param>
        /// <param name="paraGoodsMGroupCode">検索パラメータ[商品中分類コード(int)]</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された商品中分類コードの商品中分類マスタを戻します</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.06</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMTKD09053D", "Broadleaf.Application.Remoting.ParamData.GoodsMGroupWork")]
            out object goodsMGroupList,
            object paraGoodsMGroupCode);

        /// <summary>
        /// 指定された商品中分類コードの商品中分類マスタを戻します
        /// </summary>
        /// <param name="goodsMGroupList">検索結果</param>
        /// <param name="paraGoodsMGroupWork">検索パラメータ[GoodsMGroupWork(nullの場合は全件検索)]</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTKD09053D", "Broadleaf.Application.Remoting.ParamData.GoodsMGroupWork")]
			out object goodsMGroupList,
            object paraGoodsMGroupWork);
    }

}
