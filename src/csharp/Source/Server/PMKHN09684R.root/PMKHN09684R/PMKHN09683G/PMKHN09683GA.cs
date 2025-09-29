//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタコンバート
// プログラム概要   : 在庫管理全体設定の現在庫表示区分より、出荷可能数を更新する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2011/08/26  修正内容 : 連番No.1016 新規作成
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
    /// 在庫マスタコンバートDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスは仕入先変換ツールDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SupplierDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2011/08/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockConvertDB
    {
        /// <summary>
        /// 在庫マスタコンバート仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        public MediationStockConvertDB()
        {
        }
        /// <summary>
        /// IStockConverDBインターフェース取得
        /// </summary>
        /// <returns>IStockConverDBオブジェクト</returns>
        public static IStockConvertDB GetStockConvertDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:20020";
# endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockConvertDB)Activator.GetObject(typeof(IStockConvertDB), string.Format("{0}/MyAppStockConvert", wkStr));
        }
    }
}
