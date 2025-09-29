using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 優良BLコード検索情報取得DBRemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 優良BLコード検索情報取得インターフェースクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
    public interface IOfferPrimeBlSearchDB
    {
        /// <summary>
        /// 指定されたパラメータで優良BL検索をします
        /// </summary>
        /// <param name="offerPrimeBlSearchCondWork">検索パラメータ</param>
        /// <param name="offerPrimeSearchRetWork">取得した情報</param>	
        /// <param name="offerPrimePriceRetWork"></param>
        /// <param name="offerPrimeBlSearchSetPartsRetWork"></param>
        /// <param name="offerSetPartPrice"></param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Search(
            OfferPrimeBlSearchCondWork offerPrimeBlSearchCondWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06034D", "Broadleaf.Application.Remoting.ParamData.OfferPrimeSearchRetWork")]
			out ArrayList offerPrimeSearchRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
            out ArrayList offerPrimePriceRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferSetPartsRetWork")]
            out ArrayList offerPrimeBlSearchSetPartsRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
            out ArrayList offerSetPartPrice);

        // 不要
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="searchSetPartsCondWork"></param>
        ///// <param name="offerPrimeBlSearchSetPartsRetWork"></param>
        ///// <returns></returns>
        //[MustCustomSerialization]
        //int Search(
        //    ArrayList searchSetPartsCondWork,
        //    [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferSetPartsRetWork")]
        //    out ArrayList offerPrimeBlSearchSetPartsRetWork);

    }
}
