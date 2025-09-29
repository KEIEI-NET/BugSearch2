//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   得意先(掛率グループ)マスタDB仲介クラス
//                  :   PMKHN09173G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   23012　畠中 啓次朗
// Date             :   2008.10.07
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
    /// CustRateGroupDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICustRateGroupDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接CustRateGroupDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 23012　畠中 啓次朗</br>
    /// <br>Date       : 2008.10.07</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCustRateGroupDB
    {
        /// <summary>
        /// CustRateGroupDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 23012　畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        /// </remarks>
        public MediationCustRateGroupDB()
        {

        }

        /// <summary>
        /// ICustRateGroupDBインターフェース取得
        /// </summary>
        /// <returns>ICustRateGroupDBオブジェクト</returns>
        public static ICustRateGroupDB GetCustRateGroupDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICustRateGroupDB)Activator.GetObject(typeof(ICustRateGroupDB), string.Format("{0}/MyAppCustRateGroup", wkStr));
        }
    }
}
