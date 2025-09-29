using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// GoodsDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIGoodsDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接GoodsDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2007.02.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationGoodsDB
	{
		/// <summary>
		/// GoodsDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.02.06</br>
		/// </remarks>
		public MediationGoodsDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static IGoodsDB GetGoodsDB()
		{
			//OFFERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);

			//AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IGoodsDB)Activator.GetObject(typeof(IGoodsDB),string.Format("{0}/MyAppGoods",wkStr));
		}
	}
}
