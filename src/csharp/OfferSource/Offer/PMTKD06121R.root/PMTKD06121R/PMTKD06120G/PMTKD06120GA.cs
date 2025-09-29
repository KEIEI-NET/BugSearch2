using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// CompanyInfDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIOfferPrimePartsInfDBクラスオブジェクトを戻します。</br>
	/// <br>Programmer : 96186　立花　裕輔</br>
	/// <br>Date       : 2005.04.16</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationColTrmEquInfDB
	{
		/// <summary>
		/// CompanyInfDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 99033　岩本　勇</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public MediationColTrmEquInfDB()
		{
			
		}
		
		/// <summary>
		/// IOfferWorkInfoインターフェース取得
		/// </summary>
		/// <returns>IOfferWorkInfoオブジェクト</returns>
		public static IColTrmEquInfDB GetRemoteObject()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";// LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#endif

			return (IColTrmEquInfDB)Activator.GetObject(typeof(IColTrmEquInfDB), string.Format("{0}/MyAppColTrmEquInf", wkStr));
		}
	}
}
