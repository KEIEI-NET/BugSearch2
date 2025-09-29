using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// 商品マスタエクスポート  DB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIGoodsExportDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接GoodsExportDBを</br>
	/// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date       : 2010/05/12</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationGoodsExportDB
	{
		/// <summary>
        /// GoodsExportDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30517 夏野 駿希</br>
        /// <br>Date       : 2010/05/12</br>
        /// </remarks>
        public MediationGoodsExportDB()
		{
		}
		/// <summary>
        /// IGoodsExportDBインターフェース取得
		/// </summary>
        /// <returns>IGoodsExportDBオブジェクト</returns>
        public static IGoodsExportDB GetGoodsExportDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			//AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IGoodsExportDB)Activator.GetObject(typeof(IGoodsExportDB), string.Format("{0}/MyAppGoodsExport", wkStr));
		}
	}
}
