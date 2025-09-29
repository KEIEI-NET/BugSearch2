//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売価原価アンマッチリスト
// プログラム概要   : 売価原価アンマッチリストDB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/07  修正内容 : 新規作成
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
    /// RateUnMatchDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIRateUnMatchDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接RateUnMatchDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.04.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRateUnMatchDB
    {
        /// <summary>
        /// RateUnMatchDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.03</br>
        /// </remarks>
        public MediationRateUnMatchDB()
        {
        }

        /// <summary>
        /// IRateUnMatchDBインターフェース取得
        /// </summary>
        /// <returns>IRateUnMatchDBオブジェクト</returns>
        public static IRateUnMatchDB GetRateUnMatchDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IRateUnMatchDB)Activator.GetObject(typeof(IRateUnMatchDB), string.Format("{0}/MyAppRateUnMatch", wkStr));
        }
    }
}
