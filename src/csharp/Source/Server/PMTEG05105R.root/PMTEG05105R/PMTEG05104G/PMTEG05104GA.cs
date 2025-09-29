//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 決済手形消込処理
// プログラム概要   : 決済手形消込処理DB仲介クラス。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 決済手形消込処理
// 作 成 日  2010/04/22  修正内容 : 新規作成
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
    /// 決済手形消込処理DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスは決済手形消込処理DBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SettlementBillDelDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 決済手形消込処理</br>
    /// <br>Date       : 2010/04/22</br>
    /// </remarks>
    public class MediationSettlementBillDelDB
    {
        /// <summary>
        /// 決済手形消込処理仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 決済手形消込処理</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>
        public MediationSettlementBillDelDB()
        {
        }
        /// <summary>
        /// ISettlementBillDelDBインターフェース取得
        /// </summary>
        /// <returns>ISettlementBillDelDBオブジェクト</returns>
        public static ISettlementBillDelDB GetSettlementBillDelDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISettlementBillDelDB)Activator.GetObject(typeof(ISettlementBillDelDB), string.Format("{0}/MyAppSettlementBillDel", wkStr));
        }
    }
}
