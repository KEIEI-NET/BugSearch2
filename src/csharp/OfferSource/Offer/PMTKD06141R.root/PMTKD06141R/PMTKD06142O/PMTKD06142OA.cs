using System;
using System.Collections;
using Broadleaf.Library.Resources;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
	
namespace Broadleaf.Application.Remoting
{	
	
	/// <summary>
    /// 類別装備部品情報取得 RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 類別装備部品情報取得 RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.07.29</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface ICategoryEquipmentDB
	{		
		/// <summary>
        /// 指定されたパラメータで類別装備部品(TBO)情報を取得します
		/// </summary>
        /// <param name="retbyte">検索結果</param>
        /// <param name="modelDesignationNo">型式指定番号</param>		
        /// <param name="categoryNo">類別番号</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 30290</br>
		/// <br>Date       : 2008.07.29</br>
		[MustCustomSerialization]
		int SearchCategoryEquipment(
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CategoryEquipmentRetWork")]
			out object retbyte,
			Int32 modelDesignationNo,
			Int32 categoryNo
		);

	}
}
