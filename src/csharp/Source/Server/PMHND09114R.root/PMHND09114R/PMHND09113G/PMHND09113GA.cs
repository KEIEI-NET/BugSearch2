using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// InspectTtlStDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIInspectTtlStDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接InspectTtlStDBを</br>
	/// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 3H 楊善娟</br>
    /// <br>Date       : K2017/06/02</br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationInspectTtlStDB
	{
		/// <summary>
		/// InspectTtlStDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
		public MediationInspectTtlStDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static IInspectTtlStDB GetInspectTtlStDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            //wkStr = "http://localhost:9001";  // dbg
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IInspectTtlStDB)Activator.GetObject(typeof(IInspectTtlStDB),string.Format("{0}/MyAppInspectTtlSt",wkStr));
		}
	}
}
