using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// 優良部品情報取得DB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 30290</br>
	/// <br>Date       : 2008.05.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationPrimePartsInfo
	{
		/// <summary>
		/// CompanyInfDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// </remarks>
		public MediationPrimePartsInfo()
		{
			
		}
		
		/// <summary>
		/// IOfferWorkInfoインターフェース取得
		/// </summary>
		/// <returns>IOfferWorkInfoオブジェクト</returns>
        public static IPrimePartsInfo GetRemoteObject()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif

            return (IPrimePartsInfo)Activator.GetObject(typeof(IPrimePartsInfo), string.Format("{0}/MyAppPrimePartsInf", wkStr));
		}
	}
}
