using System;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// 売掛情報取得 DB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはICustAccRecInfGetDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接CustAccRecInfGetDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2007.05.08</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationCustAccRecInfGetDB
	{
		/// <summary>
		/// CustAccRecInfGetDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.05.08</br>
		/// </remarks>
		public MediationCustAccRecInfGetDB()
		{
		}
		/// <summary>
		/// CustAccRecInfGetDBインターフェース取得
		/// </summary>
		/// <returns>CustAccRecInfGetDBオブジェクト</returns>
		public static ICustAccRecInfGetDB GetCustAccRecInfGetDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            return (ICustAccRecInfGetDB)Activator.GetObject(typeof(ICustAccRecInfGetDB), string.Format("{0}/MyAppCustAccRecInfGet", wkStr));
		}
	}
}
