using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// CreditMngListWorkDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはICreditMngListWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接CreditMngListWorkDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 22008 長内 数馬</br>
	/// <br>Date       : 2007.11.15</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
    public class MediationCreditMngListWorkDB
	{
		/// <summary>
        /// CreditMngListWorkDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.15</br>
		/// </remarks>
        public MediationCreditMngListWorkDB()
		{
		}
		/// <summary>
        /// ICreditMngListWorkDBインターフェース取得
		/// </summary>
        /// <returns>ICreditMngListWorkDBオブジェクト</returns>
        public static ICreditMngListWorkDB GetCreditMngListWorkDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
			
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICreditMngListWorkDB)Activator.GetObject(typeof(ICreditMngListWorkDB), string.Format("{0}/MyAppCreditMngListWork", wkStr));
		}
	}
}
