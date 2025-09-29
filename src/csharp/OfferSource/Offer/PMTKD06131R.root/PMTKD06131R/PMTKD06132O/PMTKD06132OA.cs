using System;
using System.Collections;
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
	public interface IPrdTypYearDB
	{		
		/// <summary>
		/// 生産年式情報を戻します
		/// </summary>
		/// <param name="prdTypYearRetWork"></param>
		/// <param name="prdTypYearCondWork"></param>
		/// <returns></returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 96186　立花　裕輔</br>
		/// <br>Date       : 2007.03.05</br>
		[MustCustomSerialization]
		int SearchPrdTypYearInf(
            [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.PrdTypYearRetWork")]
			out object prdTypYearRetWork,
			object prdTypYearCondWork
		);


	}
}
