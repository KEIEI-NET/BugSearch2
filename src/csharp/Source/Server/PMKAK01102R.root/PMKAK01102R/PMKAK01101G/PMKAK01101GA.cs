//***************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入返品計上更新部品
// プログラム概要   : 仕入返品計上更新部品 DBRemoteObject仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI斎藤 和宏
// 作 成 日  2013/01/22  修正内容 : 仕入返品予定機能追加対応
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockSlipRetPlnDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIStockSlipRetPlnDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接StockSlipRetPlnDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : FSI斎藤 和宏</br>
    /// <br>Date       : 2013/01/22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockSlipRetPlnDB
    {
        /// <summary>
        /// StockSlipRetPlnDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2013/01/22</br>
        /// </remarks>
        public MediationStockSlipRetPlnDB()
        {
        }
        /// <summary>
        /// IStockSlipRetPlnDBインターフェース取得
        /// </summary>
        /// <returns>IStockSlipRetPlnDBオブジェクト</returns>
        public static IStockSlipRetPlnDB GetStockSlipRetPlnDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9011";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockSlipRetPlnDB)Activator.GetObject(typeof(IStockSlipRetPlnDB), string.Format("{0}/MyAppStockSlipRetPln", wkStr));
        }
    }
}
