using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// 価格改正設定マスタ仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIPriceChgProcStDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接TaxRateSetDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 30290</br>
	/// <br>Date       : 2008.09.19</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationPriceChgProcSt
	{
		/// <summary>
        /// 価格改正設定マスタ仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.19</br>
		/// </remarks>
		public MediationPriceChgProcSt()
		{
		}
		/// <summary>
        /// IPriceChgProcStDBインターフェース取得
		/// </summary>
        /// <returns>IPriceChgProcStDBオブジェクト</returns>
        public static IPriceChgProcStDB GetPriceChgProcStDB()
		{
            //アプリケーションサーバー接続切り替え対応↓↓↓↓↓
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "HTTP://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPriceChgProcStDB)Activator.GetObject(typeof(IPriceChgProcStDB), string.Format("{0}/MyAppPriceChgProcSt", wkStr));
            //アプリケーションサーバー接続切り替え対応↑↑↑↑↑
        }
	}
}
