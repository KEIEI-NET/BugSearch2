using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// CompanyNmDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはICompanyNmDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接CompanyNmDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 22027　橋本　将樹</br>
	/// <br>Date       : 2005.09.08</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationCompanyNmDB
	{
		/// <summary>
		/// CompanyNmDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public MediationCompanyNmDB()
		{
		}
		/// <summary>
		/// ICompanyNmDBインターフェース取得
		/// </summary>
		/// <returns>ICompanyNmDBオブジェクト</returns>
		public static ICompanyNmDB GetCompanyNmDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

			//AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (ICompanyNmDB)Activator.GetObject(typeof(ICompanyNmDB),string.Format("{0}/MyAppCompanyNm",wkStr));
		}
	}
}
