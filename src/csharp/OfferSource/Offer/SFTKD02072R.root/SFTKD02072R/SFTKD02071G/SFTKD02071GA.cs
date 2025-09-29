using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// PMakerNmDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIPMakerNmDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接PMakerNmDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 22027　橋本　将樹</br>
	/// <br>Date       : 2006.06.08</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationPMakerNmDB
	{
		/// <summary>
		/// PMakerNmDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2006.06.08</br>
		/// </remarks>
		public MediationPMakerNmDB()
		{
		}
		/// <summary>
		/// IPMakerNmDBインターフェース取得
		/// </summary>
		/// <returns>IPMakerNmDBオブジェクト</returns>
		public static IPMakerNmDB GetPMakerNmDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif
			return (IPMakerNmDB)Activator.GetObject(typeof(IPMakerNmDB),string.Format("{0}/MyAppPMakerNm",wkStr));
		}
	}
}
