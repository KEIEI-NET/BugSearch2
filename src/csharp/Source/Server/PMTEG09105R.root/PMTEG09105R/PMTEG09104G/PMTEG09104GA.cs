//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形データメンテナンス
// プログラム概要   : 手形データ設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛軍
// 作 成 日  2010/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 受取手形データマスタDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISecMngSetDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SupplierDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 葛軍</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRcvDraftDataDB
    {
        /// <summary>
        /// 受取手形データマスタDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public MediationRcvDraftDataDB()
        {

        }

        /// <summary>
        /// IRcvDraftDataDBインターフェース取得
        /// </summary>
        /// <returns>IRcvDraftDataDBオブジェクト</returns>
        public static IRcvDraftDataDB GetRcvDraftDataDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IRcvDraftDataDB)Activator.GetObject(typeof(IRcvDraftDataDB), string.Format("{0}/MyAppRcvDraftData", wkStr));
        }
    }

    /// <summary>
    /// 支払手形データマスタDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISecMngSetDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SupplierDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 葛軍</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br></br> 
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPayDraftDataDB
    {
        /// <summary>
        /// 支払手形データマスタDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public MediationPayDraftDataDB()
        {

        }

        /// <summary>
        /// IPayDraftDataDBインターフェース取得
        /// </summary>
        /// <returns>IPayDraftDataDBオブジェクト</returns>
        public static IPayDraftDataDB GetPayDraftDataDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPayDraftDataDB)Activator.GetObject(typeof(IPayDraftDataDB), string.Format("{0}/MyAppPayDraftData", wkStr));
        }
    }
}
