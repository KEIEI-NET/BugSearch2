//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : TSP連携マスタ設定
// プログラム概要   : TSP連携マスタ設定を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11670305-00  作成担当 : 3H 劉星光
// 作 成 日 : 2020/11/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// TSP連携マスタ設定 DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : このクラスはITspCprtStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>               完全スタンドアロンにする場合にはこのクラスで直接TspCprtStDBを</br>
    /// <br>               インスタンス化して戻します。</br>
    /// <br>Programmer   : 3H 劉星光</br>
    /// <br>Date         : 2020/11/23</br>
    /// <br>依頼番号     : 11670305-00</br>
    /// <br></br>
    /// </remarks>
    public class MediationTspCprtStDB
    {
        /// <summary>
        /// TspCprtStDB DB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public MediationTspCprtStDB()
        {
        }

        /// <summary>
        /// TspCprtStDBインターフェース取得
        /// </summary>
        /// <returns>ITspCprtStDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : TspCprtStDBインターフェース取得</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public static ITspCprtStDB GetTspCprtStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:9001";
# endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ITspCprtStDB)Activator.GetObject(typeof(ITspCprtStDB), string.Format("{0}/MyAppTspCprtStDB", wkStr));
        }
    }
}