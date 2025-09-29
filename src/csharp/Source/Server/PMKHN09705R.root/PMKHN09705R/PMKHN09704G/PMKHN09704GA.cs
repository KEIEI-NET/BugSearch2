using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// AutoAnsItemStDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIAutoAnsItemStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接AutoAnsItemStDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 30745　吉岡　孝憲</br>
	/// <br>Date       : 2012/10/25</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationAutoAnsItemStDB
	{
		/// <summary>
        /// AutoAnsItemStDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// </remarks>
        public MediationAutoAnsItemStDB()
		{
		}
		/// <summary>
        /// IAutoAnsItemStDBインターフェース取得
		/// </summary>
        /// <returns>IAutoAnsItemStDBオブジェクト</returns>
        public static IAutoAnsItemStDB GetAutoAnsItemStDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IAutoAnsItemStDB)Activator.GetObject(typeof(IAutoAnsItemStDB), string.Format("{0}/MyAppAutoAnsItemSt", wkStr));
		}
	}
}
