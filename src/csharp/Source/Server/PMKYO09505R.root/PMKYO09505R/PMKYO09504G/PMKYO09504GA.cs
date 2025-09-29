//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理ログ参照ツール
// プログラム概要   : 送信履歴の追加更新、抽出、物理削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 張曼
// 作 成 日  2012/07/23  修正内容 : 新規作成
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
    /// DC送受信履歴　リモートオブジェクト仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISecMngSetDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SupplierDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 張曼</br>
    /// <br>Date       : 2012/07/23</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSndRcvHisTableDB
    {
        /// <summary>
        /// 拠点管理DC送信履歴ログDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/07/23</br>
        /// </remarks>
        public MediationSndRcvHisTableDB()
        {

        }

        /// <summary>
        /// ISupplierDBインターフェース取得
        /// </summary>
        /// <returns>ISupplierDBオブジェクト</returns>
        public static ISndRcvHisTableDB GetSndRcvHisTableDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_Center_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISndRcvHisTableDB)Activator.GetObject(typeof(ISndRcvHisTableDB), string.Format("{0}/MyAppSndRcvHisTable", wkStr));
        }
    }
}
