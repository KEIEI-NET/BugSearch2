//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形取引先別表DB仲介クラス
// プログラム概要   : ITegataTorihikisakiListReportResultDBオブジェクトを取得します
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 作 成 日  2010/4/21  修正内容 : 新規作成
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
    /// 手形取引先別表 リモートオブジェクト仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはITegataTorihikisakiListReportResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接TegataTorihikisakiListReportResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 王開強</br>
    /// <br>Date       : 2010.04.21</br>
    /// </remarks>
    public class MediationTegataTorihikisakiListReportResultDB
    {
        /// <summary>
        /// TegataTorihikisakiListReportResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public MediationTegataTorihikisakiListReportResultDB()
        {
        }
        /// <summary>
        /// ITegataTorihikisakiListReportResultDBインターフェース取得
        /// </summary>
        /// <returns>ITegataTorihikisakiListReportResultDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : ITegataTorihikisakiListReportResultDBインターフェースを取得する。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public static ITegataTorihikisakiListReportResultDB GetTegataTorihikisakiListReportResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ITegataTorihikisakiListReportResultDB)Activator.GetObject(typeof(ITegataTorihikisakiListReportResultDB), string.Format("{0}/MyAppTegataTorihikisakiListReportResult", wkStr));
        }
    }
}
