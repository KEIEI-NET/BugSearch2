using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// CustSlipMngDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはICustSlipMngDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接CustSlipMngDBを</br>
	/// <br>			 インスタンス化して戻します。</br>
	/// <br>Programmer : 20081　疋田　勇人</br>
	/// <br>Date       : 2007.09.18</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationCustSlipMngDB
	{
		/// <summary>
        /// SlipTypeMngDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 20081　疋田　勇人</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public MediationCustSlipMngDB()
		{
		}
		/// <summary>
        /// ICustSlipMngDBインターフェース取得
		/// </summary>
        /// <returns>ICustSlipMngDBオブジェクト</returns>
		public static ICustSlipMngDB GetCustSlipMngDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            
            //wkStr = "http://localhost:9001";

			//AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICustSlipMngDB)Activator.GetObject(typeof(ICustSlipMngDB), string.Format("{0}/MyAppCustSlipMng", wkStr));
		}
	}
}
