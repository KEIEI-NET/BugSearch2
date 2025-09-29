using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// 車両情報結合情報コントローラ取得DB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはITBOSearchInfDBクラスオブジェクトを戻します。</br>
	/// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationTBOSearchInfDB
	{
		/// <summary>
        /// 車両情報結合情報コントローラ取得DB仲介クラスコンストラクタ
		/// </summary>
		public MediationTBOSearchInfDB()
		{
			
		}
		
		/// <summary>
        /// ITBOSearchInfDBインターフェース取得
		/// </summary>
        /// <returns>ITBOSearchInfDBオブジェクト</returns>
        public static ITBOSearchInfDB GetTBOSearchInf()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif
            return (ITBOSearchInfDB)Activator.GetObject(typeof(ITBOSearchInfDB), string.Format("{0}/MyAppTBOSearchInf", wkStr));
		}
	}
}
