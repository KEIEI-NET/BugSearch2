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
	public interface ICtgyMdlLnkDB
	{		
		/// <summary>
		/// 指定されたパラメータで提供車輌情報結合検索取得します
		/// </summary>
        /// <param name="ctgyMdlLnkCondWork">検索パラメータ</param>
        /// <param name="ctgyMdlLnkRetWork">取得した情報</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 96186　立花　裕輔</br>
		/// <br>Date       : 2007.03.05</br>
		[MustCustomSerialization]
		int GetCtgyMdlLnk(
			CtgyMdlLnkCondWork ctgyMdlLnkCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CtgyMdlLnkRetWork")]
			out ArrayList ctgyMdlLnkRetWork);
	
	}
}
