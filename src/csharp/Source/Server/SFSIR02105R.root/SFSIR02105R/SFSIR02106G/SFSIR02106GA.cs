using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// DepositReadDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIDepositReadDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接DepositReadDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 99033 岩本　勇</br>
	/// <br>Date       : 2005.08.16</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationPaymentReadDB
	{
		/// <summary>
        /// MediationPaymentReadDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 99033 岩本　勇</br>
		/// <br>Date       : 2005.08.16</br>
		/// </remarks>
        public MediationPaymentReadDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static IPaymentReadDB GetPaymentReadDB()
		{
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPaymentReadDB)Activator.GetObject(typeof(IPaymentReadDB), string.Format("{0}/MyAppPaymentRead", wkStr));
        }
	}
}
