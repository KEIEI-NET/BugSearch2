//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定マスタメンテナンス
// プログラム概要   : 発注点設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/03/31  修正内容 : 新規作成
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
    /// 発注点設定マスタDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISecMngSetDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SupplierDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.04.08</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationOrderPointStDB
    {
        /// <summary>
        /// 発注点設定マスタDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        public MediationOrderPointStDB()
        {

        }

        /// <summary>
        /// IOrderPointStDBインターフェース取得
        /// </summary>
        /// <returns>IOrderPointStDBオブジェクト</returns>
        public static IOrderPointStDB GetOrderPointStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IOrderPointStDB)Activator.GetObject(typeof(IOrderPointStDB), string.Format("{0}/MyAppOrderPointSt", wkStr));
        }
    }
}
