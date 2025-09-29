using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 提供優良設定DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPrimeSettingSearchDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
	public class MediationPrimeSettingDB
	{
		/// <summary>
        /// IPrimeSettingSearchDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// </remarks>
        public MediationPrimeSettingDB()
		{
		}
		/// <summary>
        /// IPrimeSettingSearchDBインターフェース取得
		/// </summary>
        /// <returns>IPrimeSettingSearchDBオブジェクト</returns>
        public static IPrimeSettingDB GetPrimeSettingDB()
		{
			//アプリケーションサーバー接続切り替え対応↓↓↓↓↓
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif
			//AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPrimeSettingDB)Activator.GetObject(typeof(IPrimeSettingDB), string.Format("{0}/MyAppPrimeSetting", wkStr));
			//アプリケーションサーバー接続切り替え対応↑↑↑↑↑
		}
	}
}
