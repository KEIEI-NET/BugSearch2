using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// 純正部品情報取得DB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 30290</br>
	/// <br>Date       : 2008.05.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationFreeSearchPartsSearchDB
	{
		/// <summary>
		/// CompanyInfDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// </remarks>
        public MediationFreeSearchPartsSearchDB()
		{
			
		}
		
		/// <summary>
		/// IOfferWorkInfoインターフェース取得
		/// </summary>
        /// <returns>IOfferPartsInfoオブジェクト</returns>
        public static IFreeSearchPartsSearchDB GetRemoteObject()
        {
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "HTTP://localhost:9011";
#endif
            return (IFreeSearchPartsSearchDB)Activator.GetObject( typeof( IFreeSearchPartsSearchDB ), string.Format( "{0}/MyAppFreeSearchPartsSearch", wkStr ) );
        }

	}
}
