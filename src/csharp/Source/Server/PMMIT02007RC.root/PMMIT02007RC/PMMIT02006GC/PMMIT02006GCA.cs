//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 得意先別見積書・棚卸表 
// プログラム概要   : 得意先別見積書・棚卸表 DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10970531-00  作成担当 : songg
// 作 成 日  K2013/12/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// TakekawaQuotaInventWorkDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはITakekawaQuotaInventWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接TakekawaQuotaInventWorkDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : songg</br>
	/// <br>Date       : K2013/12/03</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
    public class MediationTakekawaQuotaInventWorkDB
	{
		/// <summary>
        /// PaymentBalanceLedgerDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
		/// </remarks>
        public MediationTakekawaQuotaInventWorkDB()
		{
		}
		/// <summary>
        /// ITakekawaQuotaInventWorkDBインターフェース取得
		/// </summary>
        /// <returns>ITakekawaQuotaInventWorkDBオブジェクト</returns>
        public static ITakekawaQuotaInventWorkDB GetTakekawaQuotaInventWorkDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ITakekawaQuotaInventWorkDB)Activator.GetObject(typeof(ITakekawaQuotaInventWorkDB), string.Format("{0}/MyAppTakekawaQuotaInventWork", wkStr));
		}
	}
}
