//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   売上月次集計データ更新DB仲介クラス
//                  :   PMHNB01100G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   21112　久保田　誠
// Date             :   2008.05.19
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
    /// MonthlyTtlSalesUpdDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIMonthlyTtlSalesUpdDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接MonthlyTtlSalesUpdDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2008.05.19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationMonthlyTtlSalesUpdDB
    {
        /// <summary>
        /// MonthlyTtlSalesUpdDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.05.19</br>
        /// </remarks>
        public MediationMonthlyTtlSalesUpdDB()
        {

        }

        /// <summary>
        /// IMonthlyTtlSalesUpdDBインターフェース取得
        /// </summary>
        /// <returns>IMonthlyTtlSalesUpdDBオブジェクト</returns>
        public static IMonthlyTtlSalesUpdDB GetMonthlyTtlSalesUpdDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IMonthlyTtlSalesUpdDB)Activator.GetObject(typeof(IMonthlyTtlSalesUpdDB),string.Format("{0}/MyAppMonthlyTtlSalesUpd",wkStr));
        }
    }
}
