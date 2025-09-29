//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 一括リアル更新
// プログラム概要   : 一括リアル更新DB仲介クラス。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/12/24  修正内容 : 新規作成
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
    /// 一括リアル更新DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスは一括リアル更新DBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SupplierDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009/12/24</br>
    /// </remarks>
    public class AllRealUpdToolDB
    {
        /// <summary>
        /// 一括リアル更新仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        public AllRealUpdToolDB()
        {
        }
        /// <summary>
        /// ISupplierChangeProcDBインターフェース取得
        /// </summary>
        /// <returns>ISupplierChangeProcDBオブジェクト</returns>
        public static IAllRealUpdToolDB GetAllRealUpdToolDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
# endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IAllRealUpdToolDB)Activator.GetObject(typeof(IAllRealUpdToolDB), string.Format("{0}/MyAppAllRealUpdTool", wkStr));
        }
    }
}
