//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形期日別表DB仲介クラス
// プログラム概要   : ITegataKibiListReportResultDBオブジェクトを取得します
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 作 成 日  2010/5/5    修正内容 : 新規作成
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
    /// 手形期日別表 リモートオブジェクト仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはITegataKibiListReportResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接TegataKibiListReportResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 王開強</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public class MediationTegataKibiListReportResultDB
    {
        /// <summary>
        /// TegataKibiListReportResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public MediationTegataKibiListReportResultDB()
        {
        }
        /// <summary>
        /// ITegataKibiListReportResultDBインターフェース取得
        /// </summary>
        /// <returns>ITegataKibiListReportResultDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : ITegataKibiListReportResultDBインターフェースを取得する。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public static ITegataKibiListReportResultDB GetTegataKibiListReportResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ITegataKibiListReportResultDB)Activator.GetObject(typeof(ITegataKibiListReportResultDB), string.Format("{0}/MyAppTegataKibiListReportResult", wkStr));
        }
    }
}
