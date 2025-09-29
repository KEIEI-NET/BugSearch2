using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// GoodsRelationDataDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIGoodsRelationDataDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接GoodsRelationDataDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2007.02.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationGoodsRelationDataDB
	{
		/// <summary>
		/// GoodsRelationDataDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.02.06</br>
		/// </remarks>
		public MediationGoodsRelationDataDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static IGoodsRelationDataDB GetGoodsRelationDataDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);

#if DEBUG
    wkStr = "http://localhost:9001";
#endif


            //AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IGoodsRelationDataDB)Activator.GetObject(typeof(IGoodsRelationDataDB),string.Format("{0}/MyAppGoodsRelationData",wkStr));
		}
	}
}
