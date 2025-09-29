//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   請求全体設定マスタDB仲介クラス
//                  :   SFUKK09103G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   22008 長内 数馬
// Date             :   2008.06.05
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
    /// BillAllStDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIBillAllStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接BillAllStDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.06.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationBillAllStDB
    {
        /// <summary>
        /// BillAllStDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        /// </remarks>
        public MediationBillAllStDB()
        {

        }

        /// <summary>
        /// IBillAllStDBインターフェース取得
        /// </summary>
        /// <returns>IBillAllStDBオブジェクト</returns>
        public static IBillAllStDB GetBillAllStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IBillAllStDB)Activator.GetObject(typeof(IBillAllStDB),string.Format("{0}/MyAppBillAllSt",wkStr));
        }
    }
}
