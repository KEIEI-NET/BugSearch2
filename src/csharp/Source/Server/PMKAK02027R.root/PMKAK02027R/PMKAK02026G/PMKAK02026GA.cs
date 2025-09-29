//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 買掛残高一覧表（総括）DBRemoteObject仲介クラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI冨樫 紗由里
// 作 成 日  2012/09/14  修正内容 : 新規作成 仕入総括機能対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// SumAccPaymentListWorkDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはISumAccPaymentListWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SumAccPaymentListWorkDBを</br>
	/// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : FSI冨樫 紗由里</br>
    /// <br>Date       : 2012/09/14</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
    public class MediationSumAccPaymentListWorkDB
	{
		/// <summary>
        /// PaymentBalanceLedgerDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
		/// </remarks>
        public MediationSumAccPaymentListWorkDB()
		{
		}
		/// <summary>
        /// ISumAccPaymentListWorkDBインターフェース取得
		/// </summary>
        /// <returns>ISumAccPaymentListWorkDBオブジェクト</returns>
        public static ISumAccPaymentListWorkDB GetSumAccPaymentListWorkDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISumAccPaymentListWorkDB)Activator.GetObject(typeof(ISumAccPaymentListWorkDB), string.Format("{0}/MyAppSumAccPaymentListWork", wkStr));
		}
	}
}
