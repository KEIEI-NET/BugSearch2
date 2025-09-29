//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理接続先設定マスタメンテナンス
// プログラム概要   : 拠点管理接続先設定マスタの登録・変更を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/04/21  修正内容 : 新規作成
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
    /// 接続先設定マスタDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISecMngConnectStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SecMngConnectStDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.03.27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSecMngConnectStDB
    {
        /// <summary>
        /// 接続先設定マスタDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public MediationSecMngConnectStDB()
        {

        }

        /// <summary>
        /// ISecMngConnectStDBインターフェース取得
        /// </summary>
        /// <returns>ISecMngConnectStDBオブジェクト</returns>
        public static ISecMngConnectStDB GetSecMngConnectStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISecMngConnectStDB)Activator.GetObject(typeof(ISecMngConnectStDB), string.Format("{0}/MyAppSecMngConnectSt", wkStr));
        }
    }
}
