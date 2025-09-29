//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : BLコード変換マスタ取得設定マスタメンテ
// プログラム概要   : BLコード変換マスタ取得設定マスタメンテDB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡 孝憲 30745
// 作 成 日  2012/08/01  修正内容 : 新規作成
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
    /// BLGoodsCdChgUDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIBLGoodsCdChgUDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接BLGoodsCdChgUDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 吉岡 孝憲 30745</br>
    /// <br>Date       : 2012/08/01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationBLGoodsCdChgUDB
    {
        /// <summary>
        /// BLGoodsCdChgUDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public MediationBLGoodsCdChgUDB()
        {
        }

        /// <summary>
        /// IBLGoodsCdChgUDBインターフェース取得
        /// </summary>
        /// <returns>IBLGoodsCdChgUDBオブジェクト</returns>
        public static IBLGoodsCdChgUDB GetBLGoodsCdChgUDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IBLGoodsCdChgUDB)Activator.GetObject(typeof(IBLGoodsCdChgUDB), string.Format("{0}/MyAppBLGoodsCdChgU", wkStr));
        }
    }
}
