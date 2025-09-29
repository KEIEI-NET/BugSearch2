//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   在庫履歴現在庫数設定DB仲介クラス
//                  :   PMZAI09153G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   李占川
// Date             :   2009/12/24
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// MonthlyTtlStockUpdDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIMonthlyTtlStockUpdDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接MonthlyTtlStockUpdDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.12.12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockHistoryUpdateDB
    {
        /// <summary>
        /// StockHistoryUpdateDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        public MediationStockHistoryUpdateDB()
        {

        }

        /// <summary>
        /// IStockHistoryUpdateDBインターフェース取得
        /// </summary>
        /// <returns>IStockHistoryUpdateDBオブジェクト</returns>
        public static IStockHistoryUpdateDB GetStockHistoryUpdateDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockHistoryUpdateDB)Activator.GetObject(typeof(IStockHistoryUpdateDB), string.Format("{0}/MyAppStockHistoryUpdate", wkStr));
        }
    }
}
