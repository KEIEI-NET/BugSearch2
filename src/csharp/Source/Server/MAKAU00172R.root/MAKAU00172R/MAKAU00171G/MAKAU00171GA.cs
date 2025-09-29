using System;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// 請求情報取得 DB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはICustDmdPrcInfGetDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接CustDmdPrcInfGetDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2007.05.08</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationCustDmdPrcInfGetDB
	{
		/// <summary>
		/// CustDmdPrcInfGetDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.05.08</br>
		/// </remarks>
		public MediationCustDmdPrcInfGetDB()
		{
		}
		/// <summary>
		/// CustDmdPrcInfGetDBインターフェース取得
		/// </summary>
		/// <returns>CustDmdPrcInfGetDBオブジェクト</returns>
		public static ICustDmdPrcInfGetDB GetCustDmdPrcInfGetDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
			return (ICustDmdPrcInfGetDB)Activator.GetObject(typeof(ICustDmdPrcInfGetDB), string.Format("{0}/MyAppCustDmdPrcInfGet", wkStr));
		}
	}
}
