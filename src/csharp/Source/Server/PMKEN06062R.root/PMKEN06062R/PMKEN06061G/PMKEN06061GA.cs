using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// UsrJoinPartsSearchDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIUsrJoinPartsSearchDBクラスオブジェクトを戻します。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.06.10</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationUsrJoinPartsSearchDB
	{
		/// <summary>
		/// UsrJoinPartsSearchDB仲介クラスコンストラクタ
		/// </summary>
		public MediationUsrJoinPartsSearchDB()
		{
			
		}
		
		/// <summary>
		/// IUsrJoinPartsSearchDBインターフェース取得
		/// </summary>
		/// <returns>IUsrJoinPartsSearchDBオブジェクト</returns>
		public static IUsrJoinPartsSearchDB GetRemoteObject()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "HTTP://localhost:9011";
#endif
			return (IUsrJoinPartsSearchDB)Activator.GetObject(typeof(IUsrJoinPartsSearchDB), string.Format("{0}/MyAppUsrJoinPartsSearch", wkStr));
		}
	}
}
