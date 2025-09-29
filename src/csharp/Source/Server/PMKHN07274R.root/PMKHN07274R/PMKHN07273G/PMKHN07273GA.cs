//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品管理情報マスタ
// プログラム概要   : 商品管理情報マスタのエクスポートを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 朱宝軍
// 作 成 日  2012/06/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// GoodsMngExportDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIGoodsMngExportDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接GoodsMngExportDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2012/06/05</br>
    /// <br></br>
    /// </remarks>
    public class MediationGoodsMngExportDB
    {
        /// <summary>
        /// GoodsMngExportDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2012/06/05</br>
        /// </remarks>
        public MediationGoodsMngExportDB()
        {
        }
        /// <summary>
        /// IGoodsMngExportDBインターフェース取得
        /// </summary>
        /// <returns>IGoodsMngExportDBオブジェクト</returns>
        public static IGoodsMngExportDB GetGoodsMngExportDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IGoodsMngExportDB)Activator.GetObject(typeof(IGoodsMngExportDB), string.Format("{0}/MyAppGoodsMngExport", wkStr));
        }
    }
}
