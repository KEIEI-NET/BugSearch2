//****************************************************************************//
// システム         : RC.NS
// プログラム名称   : バックアップ処理クラス
// プログラム概要   : バックアップ処理クラスDB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2011.06.22  修正内容 : 新規作成
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
    /// BackUpExecutionDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIBackUpExecutionDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接BackUpExecutionDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 自動生成</br>
    /// <br>Date       : 2011.06.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationBackUpExecutionDB
    {
        /// <summary>
        /// BackUpExecutionDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 自動生成</br>
        /// <br>Date       : 2011.06.22</br>
        /// </remarks>
        public MediationBackUpExecutionDB()
        {
        }

		/// <summary>
        /// IBackUpExecutionDBインターフェース取得
		/// </summary>
        /// <returns>IBackUpExecutionDBオブジェクト</returns>
        public static IBackUpExecutionDB GetBackUpExecutionDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IBackUpExecutionDB)Activator.GetObject(typeof(IBackUpExecutionDB), string.Format("{0}/MyAppBackUpExecution", wkStr));
        }
    }
}
