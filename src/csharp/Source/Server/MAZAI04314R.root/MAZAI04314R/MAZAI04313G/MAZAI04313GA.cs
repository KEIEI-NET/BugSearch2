using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// StockAcPayHisSearchDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIStockAcPayHisSearchDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接StockAcPayHisSearchDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2007.01.18</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationStockAcPayHisSearchDB
	{
		/// <summary>
		/// StockAcPayHisSearchDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.18</br>
		/// </remarks>
		public MediationStockAcPayHisSearchDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static IStockAcPayHisSearchDB GetStockAcPayHisSearchDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IStockAcPayHisSearchDB)Activator.GetObject(typeof(IStockAcPayHisSearchDB),string.Format("{0}/MyAppStockAcPayHisSearch",wkStr));
		}
	}
}
