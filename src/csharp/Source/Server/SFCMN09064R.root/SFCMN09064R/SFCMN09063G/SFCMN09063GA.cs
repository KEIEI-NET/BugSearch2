using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// UserGdBdUDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIUserGdBdUDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接UserGdBdUDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationUserGdBdUDB
	{
		/// <summary>
		/// UserGdBdUDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		/// </remarks>
		public MediationUserGdBdUDB()
		{
		}
		/// <summary>
		/// IUserGdBdUDBインターフェース取得
		/// </summary>
		/// <returns>IUserGdBdUDBオブジェクト</returns>
		/// <br>Note       : IUserGdBdUDBインターフェースを取得します。</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public static IUserGdBdUDB GetUserGdBdUDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8008";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IUserGdBdUDB)Activator.GetObject(typeof(IUserGdBdUDB),string.Format("{0}/MyAppUserGdBdU",wkStr));
		}
	}
}
