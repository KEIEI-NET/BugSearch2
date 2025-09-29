//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 当月車検車両一覧表DB仲介クラス
// プログラム概要   : IMonthCarInspectListResultDBオブジェクトを取得します
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 薛祺
// 作 成 日  2010/04/21  修正内容 : 新規作成
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
    /// 当月車検車両一覧表 リモートオブジェクト仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIMonthCarInspectListResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接MonthCarInspectListResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 薛祺</br>
    /// <br>Date       : 2010.04.21</br>
    /// </remarks>
    public class MediationMonthCarInspectListResultDB
    {
        /// <summary>
        /// MediationMonthCarInspectListResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 薛祺</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public MediationMonthCarInspectListResultDB()
        {
        }
        /// <summary>
        /// IMonthCarInspectListResultDBインターフェース取得
        /// </summary>
        /// <returns>IMonthCarInspectListResultDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IMonthCarInspectListResultDBインターフェースを取得する。</br>
        /// <br>Programmer : 薛祺</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public static IMonthCarInspectListResultDB GetMonthCarInspectListResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IMonthCarInspectListResultDB)Activator.GetObject(typeof(IMonthCarInspectListResultDB), string.Format("{0}/MyAppMonthCarInspectListResult", wkStr));
        }
    }
}
