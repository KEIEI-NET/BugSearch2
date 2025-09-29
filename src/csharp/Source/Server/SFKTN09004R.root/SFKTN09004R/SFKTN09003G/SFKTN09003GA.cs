using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// SecInfoSetDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはISecInfoSetDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接SecInfoSetDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationSecInfoSetDB
	{
		/// <summary>
		/// SecInfoSetDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		/// </remarks>
		public MediationSecInfoSetDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static ISecInfoSetDB GetSecInfoSetDB()
		{
			//アプリケーションサーバー接続切り替え対応↓↓↓↓↓
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (ISecInfoSetDB)Activator.GetObject(typeof(ISecInfoSetDB),string.Format("{0}/MyAppSecInfoSet",wkStr));
			//アプリケーションサーバー接続切り替え対応↑↑↑↑↑
		}
	}
}
