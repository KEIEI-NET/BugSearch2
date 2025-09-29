//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車検期日更新
// プログラム概要   : 車検期日更新DB仲介クラス。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 車検期日更新DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスは車検期日更新DBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SupplierDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 王海立</br>
    /// <br>Date       : 2010/04/21</br>
    /// </remarks>
    public class MediationInspectDateUpdDB
    {
        /// <summary>
        /// 車検期日更新仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        public MediationInspectDateUpdDB()
        {
        }
        /// <summary>
        /// ISupplierChangeProcDBインターフェース取得
        /// </summary>
        /// <returns>ISupplierChangeProcDBオブジェクト</returns>
        public static IInspectDateUpdDB GetInspectDateUpdDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IInspectDateUpdDB)Activator.GetObject(typeof(IInspectDateUpdDB), string.Format("{0}/MyAppInspectDateUpd", wkStr));
        }
    }
}
