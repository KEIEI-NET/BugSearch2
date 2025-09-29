//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   仕入月次集計データ更新DB仲介クラス
//                  :   PMKOU01110G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   30290
// Date             :   2008.12.12
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using Broadleaf.Application.Remoting;
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
    public class MediationMonthlyTtlStockUpdDB
    {
        /// <summary>
        /// MonthlyTtlStockUpdDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        public MediationMonthlyTtlStockUpdDB()
        {

        }

        /// <summary>
        /// IMonthlyTtlStockUpdDBインターフェース取得
        /// </summary>
        /// <returns>IMonthlyTtlStockUpdDBオブジェクト</returns>
        public static IMonthlyTtlStockUpdDB GetMonthlyTtlStockUpdDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IMonthlyTtlStockUpdDB)Activator.GetObject(typeof(IMonthlyTtlStockUpdDB),string.Format("{0}/MyAppMonthlyTtlStockUpd",wkStr));
        }
    }
}
