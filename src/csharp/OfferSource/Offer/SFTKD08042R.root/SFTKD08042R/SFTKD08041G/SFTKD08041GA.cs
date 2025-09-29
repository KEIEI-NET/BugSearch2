using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// UserGdBdDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIUserGdBdDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接UserGdBdDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationUserGdBdDB
	{
		/// <summary>
		/// UserGdBdDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		/// </remarks>
		public MediationUserGdBdDB()
		{
		}
		/// <summary>
		/// IUserGdBdDBインターフェース取得
		/// </summary>
		/// <returns>IUserGdBdDBオブジェクト</returns>
		/// <br>Note       : IUserGdBdDBインターフェースを取得します。</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public static IUserGdBdDB GetUserGdBdDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
			//AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IUserGdBdDB)Activator.GetObject(typeof(IUserGdBdDB),string.Format("{0}/MyAppUserGdBd",wkStr));
		}
	}
}
