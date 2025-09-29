//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メールメッセージ設定処理
// プログラム概要   : メールメッセージ設定処理DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011.08.09  修正内容 : 新規作成
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
    /// PccMailDtDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPccMailDtDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接PccMailDtDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.08.09</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPccMailDtDB
    {
        /// <summary>
        /// PccMailDtDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public MediationPccMailDtDB()
        {
        }

		/// <summary>
        /// IPccMailDtDBインターフェース取得
		/// </summary>
        /// <returns>IPccMailDtDBオブジェクト</returns>
        public static IPccMailDtDB GetPccMailDtDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);
#if DEBUG
            wkStr = "http://localhost:9006";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPccMailDtDB)Activator.GetObject(typeof(IPccMailDtDB), string.Format("{0}/MyAppPccMailDt", wkStr));
        }
    }
}
