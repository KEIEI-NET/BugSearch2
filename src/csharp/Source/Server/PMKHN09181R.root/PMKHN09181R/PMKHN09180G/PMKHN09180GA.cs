using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// PosTerminalMgDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIPosTerminalMgDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接PosTerminalMgDBを</br>
	/// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2009.06.09</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationPosTerminalMgDB
	{
		/// <summary>
        /// PosTerminalMgDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.06.09</br>
		/// </remarks>
        public MediationPosTerminalMgDB()
		{
		}
		/// <summary>
        /// IPosTerminalMgDBインターフェース取得
		/// </summary>
        /// <returns>IPosTerminalMgDBオブジェクト</returns>
        public static IPosTerminalMgDB GetPosTerminalMgDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPosTerminalMgDB)Activator.GetObject(typeof(IPosTerminalMgDB), string.Format("{0}/MyAppPosTerminalMg", wkStr));
		}
	}
}
