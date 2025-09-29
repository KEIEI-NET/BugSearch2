using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// MoneyKindDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIMoneyKindDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接MoneyKindDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 21052　山田　圭</br>
	/// <br>Date       : 2005.04.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationMoneyKindDB
	{
		/// <summary>
		/// MoneyKindDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.06</br>
		/// </remarks>
		public MediationMoneyKindDB()
		{
		}
		/// <summary>
		/// IMoneyKindDBインターフェース取得
		/// </summary>
		/// <returns>IMoneyKindDBオブジェクト</returns>
		public static IMoneyKindDB GetMoneyKindDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
			//AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IMoneyKindDB)Activator.GetObject(typeof(IMoneyKindDB),string.Format("{0}/MyAppMoneyKind",wkStr));
		}
	}
}
