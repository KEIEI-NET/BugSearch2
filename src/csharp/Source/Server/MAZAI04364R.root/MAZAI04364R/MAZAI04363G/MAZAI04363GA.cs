using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// StockAdjustDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIStockAdjustDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接StockAdjustDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2007.02.14</br>
	/// <br></br>
    /// <br>Update Note: 2007.10.11 横川 DC.NS用に修正</br>
    /// </remarks>
	public class MediationStockAdjustDB
	{
		/// <summary>
		/// StockAdjustDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.02.14</br>
		/// </remarks>
		public MediationStockAdjustDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static IStockAdjustDB GetStockAdjustDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IStockAdjustDB)Activator.GetObject(typeof(IStockAdjustDB),string.Format("{0}/MyAppStockAdjust",wkStr));
		}
	}
}
