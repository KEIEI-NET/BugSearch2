using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// NoMngSetDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはINoMngSetDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接NoMngSetDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 95016　牟田口　昌彦</br>
	/// <br>Date       : 2005.04.27</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationNoMngSetDB
	{
		/// <summary>
		/// NoMngSetDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 95016　牟田口　昌彦</br>
		/// <br>Date       : 2005.04.27</br>
		/// </remarks>
		public MediationNoMngSetDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static INoMngSetDB GetNoMngSetDB()
		{
//			return (INoMngSetDB)Activator.GetObject(typeof(INoMngSetDB),System.Configuration.ConfigurationSettings.AppSettings["NoMngSetDBUrl"]);

            //アプリケーションサーバー接続切り替え対応↓↓↓↓↓
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG

#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (INoMngSetDB)Activator.GetObject(typeof(INoMngSetDB),string.Format("{0}/MyAppNoMngSet",wkStr));
            //アプリケーションサーバー接続切り替え対応↑↑↑↑↑
        }
	}
}
