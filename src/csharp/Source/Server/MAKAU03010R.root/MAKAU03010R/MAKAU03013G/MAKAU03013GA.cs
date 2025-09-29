//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 請求書発行(電子帳簿連携)仲介クラス
// プログラム概要   : 請求書発行(電子帳簿連携)仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright 2022 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570183-00   作成担当 : 陳艶丹
// 作 成 日  2022/03/07    修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// EBooksBillTableDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note        : このクラスはIEBooksBillTableDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>		 	 完全スタンドアロンにする場合にはこのクラスで直接EBooksBillTableDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2022/03/07</br>
	/// <br></br>
	/// </remarks>
	public class MediationEBooksBillTableDB
	{
		/// <summary>
        /// EBooksBillTableDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note        : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		public MediationEBooksBillTableDB()
		{
		}
		/// <summary>
        /// IEBooksBillTableDBインターフェース取得
		/// </summary>
        /// <returns>IEBooksBillTableDBオブジェクト</returns>
        public static IEBooksBillTableDB GetEBooksBillTableDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			//AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IEBooksBillTableDB)Activator.GetObject(typeof(IEBooksBillTableDB), string.Format("{0}/MyAppEBooksBillTable", wkStr));
		}
	}
}
