//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 目標自動設定
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
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
    /// 目標自動設定DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスは目標自動設定DBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SupplierDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.4.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class ObjAutoSetDB
    {
        /// <summary>
        /// 目標自動設定仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.4.31</br>
        /// </remarks>
        public ObjAutoSetDB()
        {
        }
        /// <summary>
        /// ISalesSlipDBインターフェース取得
        /// </summary>
        /// <returns>IIOWriteMAHNBDBオブジェクト</returns>
        public static IObjAutoSetControlDB GetObjAutoSetControlDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:20020";
# endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IObjAutoSetControlDB)Activator.GetObject(typeof(IObjAutoSetControlDB), string.Format("{0}/MyAppObjAutoSetControl", wkStr));
        }
    }
}
