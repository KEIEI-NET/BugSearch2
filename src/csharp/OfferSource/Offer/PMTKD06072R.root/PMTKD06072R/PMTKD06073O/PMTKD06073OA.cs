using System;
using System.Collections;
using Broadleaf.Library.Resources;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 提供車輌情報結合検索[TBO検索マスタ]DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 提供車輌情報結合検索 RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//←アプリケーションサーバーの接続先を属性で指示
    public interface ITBOSearchInfDB
    {
        /// <summary>
        /// 指定されたパラメータで提供車輌情報結合検索取得します
        /// </summary>
        /// <param name="tBOSearchCondWork">検索パラメータ</param>
        /// <param name="tBOSearchRetWork">取得した情報</param>
        /// <param name="tBOSearchPriceRetWork"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.15</br>
        [MustCustomSerialization]
        int Search(
            TBOSearchCondWork tBOSearchCondWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06074D", "Broadleaf.Application.Remoting.ParamData.TBOSearchRetWork")]
			out ArrayList tBOSearchRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06074D", "Broadleaf.Application.Remoting.ParamData.TBOSearchPriceRetWork")]
            out ArrayList tBOSearchPriceRetWork);

    }
}
