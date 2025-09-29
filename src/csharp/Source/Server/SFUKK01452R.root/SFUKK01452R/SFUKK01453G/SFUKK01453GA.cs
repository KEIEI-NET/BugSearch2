using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// DepositReadDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIDepositReadDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接DepositReadDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 90027　高口　勝</br>
	/// <br>Date       : 2005.08.16</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationDepositReadDB
	{
		/// <summary>
		/// DepositReadDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.08.16</br>
		/// </remarks>
		public MediationDepositReadDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static IDepositReadDB GetDepositReadDB()
		{
//			return (IDepositReadDB)Activator.GetObject(typeof(IDepositReadDB),System.Configuration.ConfigurationSettings.AppSettings["DepositReadDBUrl"]);

            //アプリケーションサーバー接続切り替え対応↓↓↓↓↓
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
         wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IDepositReadDB)Activator.GetObject(typeof(IDepositReadDB),string.Format("{0}/MyAppDepositRead",wkStr));
            //アプリケーションサーバー接続切り替え対応↑↑↑↑↑
        }
	}
}
