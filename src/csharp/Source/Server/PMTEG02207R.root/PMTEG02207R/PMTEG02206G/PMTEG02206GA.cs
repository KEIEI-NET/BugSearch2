//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形明細表DB仲介クラス
// プログラム概要   : ITegataKessaiReportResultDBオブジェクトを取得します
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛軍
// 作 成 日  2010/5/05  修正内容 : 新規作成
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
    /// 手形決済一覧表 リモートオブジェクト仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはITegataKessaiReportResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接TegataKessaiReportResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 葛軍</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public class MediationTegataKessaiReportResultDB
    {
        /// <summary>
        /// TegataKessaiReportResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public MediationTegataKessaiReportResultDB()
        {
        }
        /// <summary>
        /// ITegataKessaiReportResultDBインターフェース取得
        /// </summary>
        /// <returns>ITegataKessaiReportResultDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : ITegataKessaiReportResultDBインターフェースを取得する。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public static ITegataKessaiReportResultDB GetTegataKessaiReportResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:8001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ITegataKessaiReportResultDB)Activator.GetObject(typeof(ITegataKessaiReportResultDB), string.Format("{0}/MyAppTegataKessaiReportResult", wkStr));
        }
    }
}
