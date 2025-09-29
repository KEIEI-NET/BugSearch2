using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 部位マスタ（提供）RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部位マスタ（提供） RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]

    public interface IPartsPosCodeDB
    {
        /// <summary>
        /// 指定された部位コードの部位マスタ（提供）を戻します
        /// </summary>
        /// <param name="partsPosInfoList">検索結果</param>
        /// <param name="paraPartsPosCode">検索パラメータ[PartsPosCodeWork]</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された商品中分類コードの商品中分類マスタを戻します</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.06</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMTKD09083D", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeWork")]
            out object partsPosInfoList,
            object paraPartsPosCode);

        /// <summary>
        /// 指定された部位コードの部位マスタ（提供）を戻します
        /// </summary>
        /// <param name="partsPosCodeList">検索結果(ArrayList)</param>
        /// <param name="paraPartsPosCodeWork">検索パラメータ[PartsPosCodeWork/null : 全件検索]</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTKD09083D", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeWork")]
			out object partsPosCodeList,
            object paraPartsPosCodeWork);
    }

}
