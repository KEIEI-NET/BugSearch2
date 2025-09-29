using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// OprtnHisLogDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIOprtnHisLogDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接OprtnHisLogDBを</br>
	/// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 23015 森本 大輝</br>
	/// <br>Date       : 2008.07.24</br>
	/// <br></br>
    /// </remarks>
	public class MediationOprtnHisLogDB
	{
		/// <summary>
		/// OprtnHisLogDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        /// </remarks>
		public MediationOprtnHisLogDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static IOprtnHisLogDB GetOprtnHisLogDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
			//AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IOprtnHisLogDB)Activator.GetObject(typeof(IOprtnHisLogDB), string.Format("{0}/MyAppOprtnHisLog", wkStr));
		}
	}
}
