using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// StockMngTtlStDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIStockMngTtlStDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接StockMngTtlStDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 20036　斉藤　雅明</br>
	/// <br>Date       : 2007.03.02</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationStockMngTtlStDB
	{
		/// <summary>
		/// StockMngTtlStDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.03.02</br>
		/// </remarks>
		public MediationStockMngTtlStDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static IStockMngTtlStDB GetStockMngTtlStDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            //wkStr = "http://localhost:9001";  // dbg
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IStockMngTtlStDB)Activator.GetObject(typeof(IStockMngTtlStDB),string.Format("{0}/MyAppStockMngTtlSt",wkStr));
		}
	}
}
