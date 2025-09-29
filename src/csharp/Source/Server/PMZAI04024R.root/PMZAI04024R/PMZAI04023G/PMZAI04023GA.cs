using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// 在庫組立・分解処理  DB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIStckAssemOvhulDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接StckAssemOvhulDBを</br>
	/// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 23015 森本 大輝</br>
    /// <br>Date       : 2008.10.06</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationStckAssemOvhulDB
	{
		/// <summary>
		/// StckAssemOvhulDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.10.06</br>
        /// </remarks>
        public MediationStckAssemOvhulDB()
		{
		}
		/// <summary>
        /// IStckAssemOvhulDBインターフェース取得
		/// </summary>
        /// <returns>IStckAssemOvhulDBオブジェクト</returns>
        public static IStckAssemOvhulDB GetStckAssemOvhulDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			//AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStckAssemOvhulDB)Activator.GetObject(typeof(IStckAssemOvhulDB), string.Format("{0}/MyAppStckAssemOvhul", wkStr));
		}
	}
}
