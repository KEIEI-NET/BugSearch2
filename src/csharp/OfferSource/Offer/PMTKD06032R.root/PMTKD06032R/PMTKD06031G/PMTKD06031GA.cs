using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// 優良BLコード検索情報コントローラ取得DB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIOfferPrimeBlSearchDBクラスオブジェクトを戻します。</br>
	/// <br>Programmer : 30290</br>
	/// <br>Date       : 2008.05.16</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationOfferPrimeBlSearchDB
	{
		/// <summary>
        /// 優良BLコード検索情報コントローラ取得DB仲介クラスコンストラクタ
		/// </summary>
		public MediationOfferPrimeBlSearchDB()
		{
			
		}
		
		/// <summary>
		/// IOfferWorkInfoインターフェース取得
		/// </summary>
		/// <returns>IOfferWorkInfoオブジェクト</returns>
		public static IOfferPrimeBlSearchDB GetOfferPrimeBlSearchDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif

            return (IOfferPrimeBlSearchDB)Activator.GetObject(typeof(IOfferPrimeBlSearchDB), string.Format("{0}/MyAppOfferPrimeBlSearch", wkStr));
		}
	}
}
