using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// BillTableDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIBillTableDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接BillTableDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 20036　斉藤　雅明</br>
	/// <br>Date       : 2007.05.11</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationSumBillTableDB
	{
		/// <summary>
        /// BillTableDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.11</br>
		/// </remarks>
        public MediationSumBillTableDB()
		{
		}
		/// <summary>
        /// IBillTableDBインターフェース取得
		/// </summary>
        /// <returns>IBillTableDBオブジェクト</returns>
        public static ISumBillTableDB GetSumBillTableDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			//AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISumBillTableDB)Activator.GetObject(typeof(ISumBillTableDB), string.Format("{0}/MyAppSumBillTable", wkStr));
		}
	}
}
