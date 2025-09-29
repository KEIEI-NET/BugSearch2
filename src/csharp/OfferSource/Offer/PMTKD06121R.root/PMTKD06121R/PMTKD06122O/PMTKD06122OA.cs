using System;
using System.Collections;
using Broadleaf.Library.Resources;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 提供車輌情報結合検索DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 提供車輌情報結合検索 RemoteObject Interfaceです。</br>
    /// <br>Programmer : 96186　立花　裕輔</br>
    /// <br>Date       : 2007.03.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//←アプリケーションサーバーの接続先を属性で指示
    public interface IColTrmEquInfDB
    {
        /// <summary>
        /// カラー・トリム・装備情報を戻します
        /// </summary>
        /// <param name="colorCdRetWork"></param>
        /// <param name="trimCdRetWork"></param>
        /// <param name="cEqpDefDspRetWork"></param>
        /// <param name="colTrmEquSearchCondWork"></param>
        /// <returns></returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 96186　立花　裕輔</br>
        /// <br>Date       : 2007.03.05</br>
        [MustCustomSerialization]
        int SearchColTrmEquInf(
            [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.ColorCdRetWork")]
			out object colorCdRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.TrimCdRetWork")]
			out object trimCdRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CEqpDefDspRetWork")]
			out object cEqpDefDspRetWork,
            ref object colTrmEquSearchCondWork
        );
    }
}
