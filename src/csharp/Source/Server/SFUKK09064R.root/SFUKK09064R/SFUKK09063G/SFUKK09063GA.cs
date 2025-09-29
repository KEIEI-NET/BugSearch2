using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// DepositStDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIDepositStDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接DepositStDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 90027　高口　勝</br>
	/// <br>Date       : 2005.07.23</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationDepositStDB
	{
		/// <summary>
		/// DepositStDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		/// </remarks>
		public MediationDepositStDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static IDepositStDB GetDepositStDB()
		{
//			return (IDepositStDB)Activator.GetObject(typeof(IDepositStDB),System.Configuration.ConfigurationSettings.AppSettings["DepositStDBUrl"]);

            //アプリケーションサーバー接続切り替え対応↓↓↓↓↓
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IDepositStDB)Activator.GetObject(typeof(IDepositStDB),string.Format("{0}/MyAppDepositSt",wkStr));
            //アプリケーションサーバー接続切り替え対応↑↑↑↑↑
        }
	}
}
