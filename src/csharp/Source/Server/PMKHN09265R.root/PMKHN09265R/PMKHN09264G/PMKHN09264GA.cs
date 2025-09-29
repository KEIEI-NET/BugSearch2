//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   得意先マスタ（与信設定）DB仲介クラス
//                  :   PMKHN09264G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   22008 長内 数馬
// Date             :   2008.10.14
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
    /// SumCustStDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICustCreditDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SumCustStDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.10.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCustCreditDB
    {
        /// <summary>
        /// CustCreditDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        /// </remarks>
        public MediationCustCreditDB()
        {

        }

        /// <summary>
        /// ISumCustStDBインターフェース取得
        /// </summary>  
        /// <returns>ISumCustStDBオブジェクト</returns>
        public static ICustCreditDB GetCustCreditDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICustCreditDB)Activator.GetObject(typeof(ICustCreditDB), string.Format("{0}/MyAppCustCredit", wkStr));
        }
    }
}
