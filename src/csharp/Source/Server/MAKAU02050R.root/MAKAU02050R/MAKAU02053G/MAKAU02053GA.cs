using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// BillDetailTableDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIBillDetailTableDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接BillDetailTableDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 20036　斉藤　雅明</br>
	/// <br>Date       : 2007.05.14</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationBillDetailTableDB
	{
		/// <summary>
        /// BillDetailTableDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.14</br>
		/// </remarks>
		public MediationBillDetailTableDB()
		{
		}
		/// <summary>
        /// IBillDetailTableDBインターフェース取得
		/// </summary>
        /// <returns>IBillDetailTableDBオブジェクト</returns>
        public static IBillDetailTableDB GetBillDetailTableDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			//AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IBillDetailTableDB)Activator.GetObject(typeof(IBillDetailTableDB), string.Format("{0}/MyAppBillDetailTable", wkStr));
		}
	}
}
