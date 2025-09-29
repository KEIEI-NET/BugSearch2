using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// InventoryDataUpdateDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIInventoryDataUpdateDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接InventoryDataUpdateDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 22035 三橋 弘憲　  </br>
	/// <br>Date       : 2007.04.07</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationInventoryDataUpdateDB
	{
		/// <summary>
		/// InventoryDataUpdateDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 22035 三橋 弘憲　  </br>
		/// <br>Date       : 2007.04.07</br>
		/// </remarks>
		public MediationInventoryDataUpdateDB()
		{
		}
		/// <summary>
		/// IInventoryDataUpdateDBインターフェース取得
		/// </summary>
		/// <returns>IInventoryDataUpdateDBオブジェクト</returns>
		/// <br>Note       : IInventoryDataUpdateDBインターフェースを取得します。</br>
		/// <br>Programmer : 22035 三橋 弘憲　  </br>
		/// <br>Date       : 2007.04.07</br>
		public static IInventoryDataUpdateDB GetInventoryDataUpdateDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IInventoryDataUpdateDB)Activator.GetObject(typeof(IInventoryDataUpdateDB),string.Format("{0}/MyAppInventoryDataUpdate",wkStr));
		}
	}
}
