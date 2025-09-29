//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 表示区分マスタメンテナンス
// プログラム概要   : 表示区分マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/10/16  修正内容 : 新規作成
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
    /// SAndESettingDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISAndESettingDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SAndESettingDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.10.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPriceSelectSetDB
    {
        /// <summary>
        /// SAndESettingDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        /// </remarks>
        public MediationPriceSelectSetDB()
        {

        }

        /// <summary>
        /// ISupplierDBインターフェース取得
        /// </summary>
        /// <returns>ISupplierDBオブジェクト</returns>
        public static IPriceSelectSetDB GetPriceSelectSetDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPriceSelectSetDB)Activator.GetObject(typeof(IPriceSelectSetDB), string.Format("{0}/MyAppPriceSelectSet", wkStr));
        }
    }
}
