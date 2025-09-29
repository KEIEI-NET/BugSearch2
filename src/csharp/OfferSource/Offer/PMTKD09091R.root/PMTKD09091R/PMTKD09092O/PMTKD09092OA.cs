using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入先マスタ(提供)RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先マスタ(提供) RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.10.29</br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
    public interface IOfrSupplierDB
    {
        /// <summary>
        /// 指定された仕入先コードの仕入先マスタ(提供)を戻します
        /// </summary>
        /// <param name="partsOfrSupplierList">検索結果</param>
        /// <param name="paraOfrSupplierWork">検索パラメータ[OfrSupplierWork]</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された商品中分類コードの商品中分類マスタを戻します</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.10.29</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMTKD09093D", "Broadleaf.Application.Remoting.ParamData.OfrSupplierWork")]
            out object partsOfrSupplierList,
            object paraOfrSupplierWork);

        /// <summary>
        /// 指定された仕入先コードの仕入先マスタ(提供)を戻します
        /// </summary>
        /// <param name="partsOfrSupplierList">検索結果(ArrayList)</param>
        /// <param name="paraOfrSupplierWork">検索パラメータ[OfrSupplierWork/null : 全件検索]</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.10.29</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTKD09093D", "Broadleaf.Application.Remoting.ParamData.OfrSupplierWork")]
			out object partsOfrSupplierList,
            object paraOfrSupplierWork);
    }

}
