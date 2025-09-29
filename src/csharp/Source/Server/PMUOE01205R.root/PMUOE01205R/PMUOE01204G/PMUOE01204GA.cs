//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE入庫更新DB仲介クラス
//                  :   PMUOE01204G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   21112　久保田
// Date             :   2008.10.17
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
    /// UOEStockUpdateDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIUOEStockUpdateDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接UOEStockUpdateDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 21112　久保田</br>
    /// <br>Date       : 2008.10.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationUOEStockUpdateDB
    {
        /// <summary>
        /// UOEStockUpdateDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        public MediationUOEStockUpdateDB()
        {

        }

        /// <summary>
        /// IUOEStockUpdateDBインターフェース取得
        /// </summary>
        /// <returns>IUOEStockUpdateDBオブジェクト</returns>
        public static IUOEStockUpdateDB GetUOEStockUpdateDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IUOEStockUpdateDB)Activator.GetObject(typeof(IUOEStockUpdateDB),string.Format("{0}/MyAppUOEStockUpdate",wkStr));
        }
    }
}
