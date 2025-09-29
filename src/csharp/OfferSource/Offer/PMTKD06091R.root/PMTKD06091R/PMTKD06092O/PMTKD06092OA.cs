using System;
using System.Collections;
//using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 部品情報検索DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部品情報検索 RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//←アプリケーションサーバーの接続先を属性で指示
    public interface IClgPrmPartsInfoSearchDB
    {
        /// <summary>
        /// 提供品番検索 DBリモートオブジェクト
        /// </summary>
        /// <param name="partsNoSearchCondList"></param>
        /// <param name="listOfrPartsRet"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int Search(
            ArrayList partsNoSearchCondList,
            [CustomSerializationMethodParameterAttribute("PMTKD06093D", "Broadleaf.Application.Remoting.ParamData.OfrPartsRetWork")]
			out ArrayList listOfrPartsRet,
            [CustomSerializationMethodParameterAttribute("PMTKD06093D", "Broadleaf.Application.Remoting.ParamData.OfrPartsPriceRetWork")]
            out ArrayList listOfrPartsPriceRet
        );

        /// <summary>
        /// 提供品番検索＜セットなし・結合なし＞ DBリモートオブジェクト
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="offerPrimePartsRetWork"></param>
        /// <param name="offerPrimePartsPriceRet"></param>
        /// <param name="ptMkrPriceRetWork"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int Search(
            PartsNoSearchCondWork partsNoSearchCondWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06093D", "Broadleaf.Application.Remoting.ParamData.OfrPartsRetWork")]
			out ArrayList offerPrimePartsRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06093D", "Broadleaf.Application.Remoting.ParamData.OfrPartsPriceRetWork")]
            out ArrayList offerPrimePartsPriceRet,
            [CustomSerializationMethodParameterAttribute("PMTKD06093D", "Broadleaf.Application.Remoting.ParamData.OfrPartsRetWork")]
			out ArrayList ptMkrPriceRetWork
        );

        /// <summary>
        /// 提供品番検索＜セットあり・結合あり＞ DBリモートオブジェクト
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="offerPrimePartsRetWork"></param>
        /// <param name="ptMkrPriceRetWork"></param>
        /// <param name="offerJoinPartsRetWork"></param>
        /// <param name="offerSetPartsRetWork"></param>
        /// <param name="opt">検索対象 1:提供結合情報検索　2:提供セット情報検索　3:両方検索</param>
        /// <returns></returns>
        [MustCustomSerialization]
        int Search(
            PartsNoSearchCondWork partsNoSearchCondWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06093D", "Broadleaf.Application.Remoting.ParamData.OfrPartsRetWork")]
			out ArrayList offerPrimePartsRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06093D", "Broadleaf.Application.Remoting.ParamData.OfrPartsRetWork")]
			out ArrayList ptMkrPriceRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPartsRetWork")]
			out ArrayList offerJoinPartsRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferSetPartsRetWork")]
			out ArrayList offerSetPartsRetWork,
            int opt
        );
    }
}
