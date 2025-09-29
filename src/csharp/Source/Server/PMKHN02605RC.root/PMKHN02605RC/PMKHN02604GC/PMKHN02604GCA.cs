using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// 商品マスタ印刷  DB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIFutabaGoodsPrintDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接FutabaGoodsPrintDBを</br>
	/// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationFutabaGoodsPrintDB
	{
		/// <summary>
		/// FutabaGoodsPrintDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.11</br>
        /// </remarks>
        public MediationFutabaGoodsPrintDB()
		{
		}
		/// <summary>
        /// IFutabaGoodsPrintDBインターフェース取得
		/// </summary>
        /// <returns>IFutabaGoodsPrintDBオブジェクト</returns>
        public static IFutabaGoodsPrintDB GetFutabaGoodsPrintDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			//AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IFutabaGoodsPrintDB)Activator.GetObject(typeof(IFutabaGoodsPrintDB), string.Format("{0}/MyAppFutabaGoodsPrint", wkStr));
		}
	}
}
