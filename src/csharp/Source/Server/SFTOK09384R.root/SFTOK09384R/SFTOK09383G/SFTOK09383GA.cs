using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// EmployeeDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIEmployeeDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接EmployeeDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 96137　山田　圭</br>
	/// <br>Date       : 2005.03.17</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationEmployeeDB
	{
		/// <summary>
		/// EmployeeDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 96137　山田　圭</br>
		/// <br>Date       : 2005.03.17</br>
		/// </remarks>
		public MediationEmployeeDB()
		{
		}
		/// <summary>
		/// IEmployeeDBインターフェース取得
		/// </summary>
		/// <returns>IEmployeeDBオブジェクト</returns>
		public static IEmployeeDB GetEmployeeDB()
		{
			//アプリケーションサーバー接続切り替え対応↓↓↓↓↓
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
			//AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IEmployeeDB)Activator.GetObject(typeof(IEmployeeDB),string.Format("{0}/MyAppEmployee",wkStr));
			//アプリケーションサーバー接続切り替え対応↑↑↑↑↑
		}
	}
}
