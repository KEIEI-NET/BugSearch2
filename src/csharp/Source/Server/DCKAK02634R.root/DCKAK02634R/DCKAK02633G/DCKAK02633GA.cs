using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// AccPaymentListWorkDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIAccPaymentListWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接AccPaymentListWorkDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 22008 長内 数馬</br>
	/// <br>Date       : 2007.11.15</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
    public class MediationAccPaymentListWorkDB
	{
		/// <summary>
        /// PaymentBalanceLedgerDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.15</br>
		/// </remarks>
        public MediationAccPaymentListWorkDB()
		{
		}
		/// <summary>
        /// IAccPaymentListWorkDBインターフェース取得
		/// </summary>
        /// <returns>IAccPaymentListWorkDBオブジェクト</returns>
        public static IAccPaymentListWorkDB GetAccPaymentListWorkDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IAccPaymentListWorkDB)Activator.GetObject(typeof(IAccPaymentListWorkDB), string.Format("{0}/MyAppAccPaymentListWork", wkStr));
		}
	}
}
