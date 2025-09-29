using System;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{

	/// <summary>
	/// CustomerSearchDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはICustomerSearchDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接CustomerSearchDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 980076　妻鳥　謙一郎</br>
	/// <br>Date       : 2007.02.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationCustomerSearchDB
	{
		/// <summary>
		/// CustomerSearchDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 980076　妻鳥　謙一郎</br>
		/// <br>Date       : 2007.02.13</br>
		/// </remarks>
		public MediationCustomerSearchDB()
		{
		}

		/// <summary>
		/// ICustomerSearchDBインターフェース取得
		/// </summary>
		/// <returns>ICustomerSearchDBオブジェクト</returns>
		public static ICustomerSearchDB GetCustomerSearchDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

			// デバッグ用
#if DEBUG
			wkStr = "http://localhost:9001";
# endif

			return (ICustomerSearchDB)Activator.GetObject(typeof(ICustomerSearchDB),string.Format("{0}/MyAppCustomerSearch",wkStr));
		}
	}
}
