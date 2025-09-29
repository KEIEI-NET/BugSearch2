using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// TaxRateSetDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはITaxRateSetDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接TaxRateSetDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 95016　牟田口　昌彦</br>
	/// <br>Date       : 2005.05.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationTaxRateSetDB
	{
		/// <summary>
		/// TaxRateSetDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 95016　牟田口　昌彦</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public MediationTaxRateSetDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static ITaxRateSetDB GetTaxRateSetDB()
		{
//			return (ITaxRateSetDB)Activator.GetObject(typeof(ITaxRateSetDB),System.Configuration.ConfigurationSettings.AppSettings["TaxRateSetDBUrl"]);

            //アプリケーションサーバー接続切り替え対応↓↓↓↓↓
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ITaxRateSetDB)Activator.GetObject(typeof(ITaxRateSetDB),string.Format("{0}/MyAppTaxRateSet",wkStr));
            //アプリケーションサーバー接続切り替え対応↑↑↑↑↑
        }
	}
}
