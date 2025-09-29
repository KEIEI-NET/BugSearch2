using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// GoodsNoChangeDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIGoodsNoChangeDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接GoodsNoChangeDBを</br>
	/// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 陳永康</br>
    /// <br>Date       : 2014/12/23</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationGoodsNoChangeDB
	{
		/// <summary>
		/// GoodsNoChangeDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		public MediationGoodsNoChangeDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static IGoodsNoChangeDB GetGoodsNoChangeDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			//AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IGoodsNoChangeDB)Activator.GetObject(typeof(IGoodsNoChangeDB), string.Format("{0}/MyAppGoodsNoChange", wkStr));
		}
	}
}
