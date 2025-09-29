using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// BillPrtStDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIBillPrtStDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接BillPrtStDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 21052　山田　圭</br>
	/// <br>Date       : 2005.07.20</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationBillPrtStDB
	{
		/// <summary>
		/// BillPrtStDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.07.20</br>
		/// </remarks>
		public MediationBillPrtStDB()
		{
		}
		/// <summary>
		/// IBillPrtStDBインターフェース取得
		/// </summary>
		/// <returns>IBillPrtStDBオブジェクト</returns>
		public static IBillPrtStDB GetBillPrtStDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
			//AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IBillPrtStDB)Activator.GetObject(typeof(IBillPrtStDB),string.Format("{0}/MyAppBillPrtSt",wkStr));
		}
	}
}
