//***************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入返品予定一覧表
// プログラム概要   : 仕入返品予定一覧表 仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI高橋 文彰
// 作 成 日   2013/01/28 修正内容 : 新規作成 仕入返品予定機能対応
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockRetPlnTableDB 仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIArivaltListDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接StockRetPlnTableDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : FSI高橋 文彰</br>
    /// <br>Date       :  2013/01/28</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockRetPlnTableDB
    {
        /// <summary>
        /// StockRetPlnTableDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        public MediationStockRetPlnTableDB()
        {
        }
        /// <summary>
        /// IStockRetPlnTableDBインターフェース取得
        /// </summary>
        /// <returns>IStockRetPlnTableDBオブジェクト</returns>
        public static IStockRetPlnTableDB GetStockRetPlnTableDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockRetPlnTableDB)Activator.GetObject(typeof(IStockRetPlnTableDB), string.Format("{0}/MyAppStockRetPlnTable", wkStr));
        }
    }
}
