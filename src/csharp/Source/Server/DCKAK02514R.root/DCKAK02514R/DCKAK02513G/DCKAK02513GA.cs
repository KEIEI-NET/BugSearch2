using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// PaymentTableDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIPaymentTableDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接PaymentTableDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 980081 山田 明友</br>
	/// <br>Date       : 2007.09.18</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationPaymentTableDB
	{
		/// <summary>
        /// PaymentTableDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public MediationPaymentTableDB()
		{
		}
		/// <summary>
        /// IPaymentTableDBインターフェース取得
		/// </summary>
        /// <returns>IPaymentTableDBオブジェクト</returns>
        public static IPaymentTableDB GetPaymentTableDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IPaymentTableDB)Activator.GetObject(typeof(IPaymentTableDB),string.Format("{0}/MyAppPaymentTable",wkStr));
		}
	}
}
