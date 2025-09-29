//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 支払一覧表（総括）
// プログラム概要   : 支払一覧表（総括）の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI東　隆史
// 作 成 日  2012/09/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// SumPaymentTableDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはISumPaymentTableDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SumPaymentTableDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : FSI東 隆史</br>
	/// <br>Date       : 2012/09/04 </br>
	/// </remarks>
	public class MediationSumPaymentTableDB
	{
		/// <summary>
        /// SumPaymentTableDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/09/04 </br>
		/// </remarks>
		public MediationSumPaymentTableDB()
		{
		}
		/// <summary>
        /// ISumPaymentTableDBインターフェース取得
		/// </summary>
        /// <returns>ISumPaymentTableDBオブジェクト</returns>
        public static ISumPaymentTableDB GetSumPaymentTableDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (ISumPaymentTableDB)Activator.GetObject(typeof(ISumPaymentTableDB),string.Format("{0}/MyAppSumPaymentTable",wkStr));
		}
	}
}
