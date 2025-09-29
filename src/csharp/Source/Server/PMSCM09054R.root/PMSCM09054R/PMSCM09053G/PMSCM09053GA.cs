using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// SCMMrktPriStDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはISCMMrktPriStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SCMMrktPriStDBを</br>
	/// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2009.05.08</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationSCMMrktPriStDB
	{
		/// <summary>
        /// SCMMrktPriStDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
		/// </remarks>
        public MediationSCMMrktPriStDB()
		{
		}
		/// <summary>
        /// ISCMMrktPriStDBインターフェース取得
		/// </summary>
        /// <returns>ISCMMrktPriStDBオブジェクト</returns>
        public static ISCMMrktPriStDB GetSCMMrktPriStDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISCMMrktPriStDB)Activator.GetObject(typeof(ISCMMrktPriStDB), string.Format("{0}/MyAppSCMMrktPriSt", wkStr));
		}
	}
}
