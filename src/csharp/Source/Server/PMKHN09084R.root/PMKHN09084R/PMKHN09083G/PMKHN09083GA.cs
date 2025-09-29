//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   得意先（請求書）DB仲介クラス
//                  :   PMKHN09083G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   22008 長内 数馬
// Date             :   2008.06.06
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
    /// CustDmdSetDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICustDmdSetDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接CustDmdSetDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCustDmdSetDB
    {
        /// <summary>
        /// CustDmdSetDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        public MediationCustDmdSetDB()
        {

        }

        /// <summary>
        /// ICustDmdSetDBインターフェース取得
        /// </summary>
        /// <returns>ICustDmdSetDBオブジェクト</returns>
        public static ICustDmdSetDB GetCustDmdSetDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICustDmdSetDB)Activator.GetObject(typeof(ICustDmdSetDB),string.Format("{0}/MyAppCustDmdSet",wkStr));
        }
    }
}
