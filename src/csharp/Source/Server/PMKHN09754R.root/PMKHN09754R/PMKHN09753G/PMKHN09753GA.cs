//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 優先倉庫マスタ
// プログラム概要   : 優先倉庫の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : huangt
// 作 成 日  K2013/09/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 優先倉庫マスタ　DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIProtyWarehouseDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接ProtyWarehouseDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : K2013/09/10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationIProtyWarehouseDB
    {
        /// <summary>
        /// ProtyWarehouseDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public MediationIProtyWarehouseDB()
        {

        }

        /// <summary>
        /// IProtyWarehouseDBインターフェース取得
        /// </summary>
        /// <returns>IProtyWarehouseDBオブジェクト</returns>
        public static IProtyWarehouseDB GetProtyWarehouseDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IProtyWarehouseDB)Activator.GetObject(typeof(IProtyWarehouseDB), string.Format("{0}/MyAppProtyWarehouse", wkStr));
        }
    }
}
