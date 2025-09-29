using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// DepsitMainDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIDepsitMainDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接DepsitMainDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 95089　徳永　誠</br>
	/// <br>Date       : 2005.08.08</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationDepsitMainDB
	{
		/// <summary>
		/// DepsitMainDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 95089　徳永　誠</br>
		/// <br>Date       : 2005.08.08</br>
		/// </remarks>
		public MediationDepsitMainDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static IDepsitMainDB GetDepsitMainDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";            
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IDepsitMainDB)Activator.GetObject(typeof(IDepsitMainDB),string.Format("{0}/MyAppDepsitMain",wkStr));
		}
	}
}
