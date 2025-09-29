//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形月別予定表DB仲介クラス
// プログラム概要   : ITegataTsukibetsuYoteListReportResultDBオブジェクトを取得します
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 姜凱
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
    /// 手形月別予定表 リモートオブジェクト仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはITegataTsukibetsuYoteListReportResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接TegataTsukibetsuYoteListReportResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 姜凱</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public class MediationTegataTsukibetsuYoteListReportResultDB
    {
        /// <summary>
        /// TegataTsukibetsuYoteListReportResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public MediationTegataTsukibetsuYoteListReportResultDB()
        {
        }
        /// <summary>
        /// ITegataTsukibetsuYoteListReportResultDBインターフェース取得
        /// </summary>
        /// <returns>ITegataTsukibetsuYoteListReportResultDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : ITegataTsukibetsuYoteListReportResultDBインターフェースを取得する。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public static ITegataTsukibetsuYoteListReportResultDB GetTegataTsukibetsuYoteListReportResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ITegataTsukibetsuYoteListReportResultDB)Activator.GetObject(typeof(ITegataTsukibetsuYoteListReportResultDB), string.Format("{0}/MyAppTegataTsukibetsuYoteListReportResult", wkStr));
        }
    }
}
