using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// CompanyInfDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはICompanyInfDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接CompanyInfDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationCompanyInfDB
	{
		/// <summary>
		/// CompanyInfDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		/// </remarks>
		public MediationCompanyInfDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static ICompanyInfDB GetCompanyInfDB()
		{
//			return (ICompanyInfDB)Activator.GetObject(typeof(ICompanyInfDB),System.Configuration.ConfigurationSettings.AppSettings["CompanyInfDBUrl"]);

            //アプリケーションサーバー接続切り替え対応↓↓↓↓↓
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
//            return (ICompanyInfDB)Activator.GetObject(typeof(ICompanyInfDB),string.Format("{0}/MyAppCompanyInf",wkStr));
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            return (ICompanyInfDB)Activator.GetObject(typeof(ICompanyInfDB),string.Format("{0}/MyCompanyInf",wkStr));
            //アプリケーションサーバー接続切り替え対応↑↑↑↑↑
		}

	}
}
