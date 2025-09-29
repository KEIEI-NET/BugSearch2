//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先変換ツール
// プログラム概要   : 商品管理情報マスタの最適化の為、不要なレコードを削除する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/07/13  修正内容 : 新規作成
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
    /// 仕入先変換ツールDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスは仕入先変換ツールDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SupplierDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009/07/13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SupplierChangeToolDB
    {
        /// <summary>
        /// 仕入先変換ツール仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/07/13</br>
        /// </remarks>
        public SupplierChangeToolDB()
        {
        }
        /// <summary>
        /// ISupplierChangeProcDBインターフェース取得
        /// </summary>
        /// <returns>ISupplierChangeProcDBオブジェクト</returns>
        public static ISupplierChangeProcDB GetSupplierChangeProcDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:20020";
# endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISupplierChangeProcDB)Activator.GetObject(typeof(ISupplierChangeProcDB), string.Format("{0}/MyAppSupplierChangeProc", wkStr));
        }
    }
}
