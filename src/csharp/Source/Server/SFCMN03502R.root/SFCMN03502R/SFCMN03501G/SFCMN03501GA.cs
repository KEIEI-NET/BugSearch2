using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// FeliCaMngDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIFeliCaMngDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接FeliCaMngDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 22011　柏原頼人</br>
	/// <br>Date       : 2008.10.30</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationFeliCaMngDB
	{
		/// <summary>
		/// FeliCaMngDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 22011　柏原頼人</br>
		/// <br>Date       : 2008.10.30</br>
		/// </remarks>
		public MediationFeliCaMngDB()
		{
		}
		/// <summary>
		/// IFeliCaMngDBインターフェース取得
		/// </summary>
		/// <returns>IFeliCaMngDBオブジェクト</returns>
		public static IFeliCaMngDB GetFeliCaMngDB()
		{
			//アプリケーションサーバー接続切り替え対応↓↓↓↓↓
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
#if DEBUG
            string wkStr = "HTTP://localhost:8008";
#else
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#endif
            return (IFeliCaMngDB)Activator.GetObject(typeof(IFeliCaMngDB), string.Format("{0}/MyAppFeliCaMng", wkStr));
            //アプリケーションサーバー接続切り替え対応↑↑↑↑↑
		}
	}
}
