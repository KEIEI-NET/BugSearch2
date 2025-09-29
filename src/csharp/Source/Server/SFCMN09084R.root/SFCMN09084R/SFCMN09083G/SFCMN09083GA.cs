using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// AllDefSetDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIAllDefSetDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接AllDefSetDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 21052　山田　圭</br>
	/// <br>Date       : 2005.10.03</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationAllDefSetDB
	{
		/// <summary>
		/// AllDefSetDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public MediationAllDefSetDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static IAllDefSetDB GetAllDefSetDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif            

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IAllDefSetDB)Activator.GetObject(typeof(IAllDefSetDB),string.Format("{0}/MyAppAllDefSet",wkStr));
		}
	}
}
