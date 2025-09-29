//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形確認表DB仲介クラス
// プログラム概要   : ITegataConfirmReportResultDBオブジェクトを取得します
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 作 成 日  2010/05/05  修正内容 : 新規作成
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
    /// 手形確認表 リモートオブジェクト仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはITegataConfirmReportResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接TegataConfirmReportResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 張義</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public class MediationTegataConfirmReportResultDB
    {
        /// <summary>
        /// TegataConfirmReportResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public MediationTegataConfirmReportResultDB()
        {
        }
        /// <summary>
        /// ITegataConfirmReportResultDBインターフェース取得
        /// </summary>
        /// <returns>ITegataConfirmReportResultDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : ITegataConfirmReportResultDBインターフェースを取得する。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public static ITegataConfirmReportResultDB GetTegataConfirmReportResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ITegataConfirmReportResultDB)Activator.GetObject(typeof(ITegataConfirmReportResultDB), string.Format("{0}/MyAppTegataConfirmReportResult", wkStr));
        }
    }
}
