using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// 部品情報取得コントローラ取得DB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIClgPrmPartsInfoSearchDBクラスオブジェクトを戻します。</br>
	/// <br>Programmer : 30290</br>
	/// <br>Date       : 2008.05.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationClgPrmPartsInfoSearchDB
	{
		/// <summary>
		/// IClgPrmPartsInfoSearchDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 99033　岩本　勇</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public MediationClgPrmPartsInfoSearchDB()
		{
		}
		
		/// <summary>
		/// IClgPrmPartsInfoSearchDBインターフェース取得
		/// </summary>
		/// <returns>IOfferWorkInfoオブジェクト</returns>
		public static IClgPrmPartsInfoSearchDB GetRemoteObject()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif
			return (IClgPrmPartsInfoSearchDB)Activator.GetObject(typeof(IClgPrmPartsInfoSearchDB),
				string.Format("{0}/MyAppClgPrmPartsInfoSearch", wkStr));
		}
	}
}
