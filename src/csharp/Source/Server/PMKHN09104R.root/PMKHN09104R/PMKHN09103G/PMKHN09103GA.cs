//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   CustSlipNoSetDB仲介クラス
//                  :   PMKHN09103G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   20081 疋田 勇人
// Date             :   2008.06.16
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
    /// CustSlipNoSetDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICustSlipNoSetDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接CustSlipNoSetDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.06.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCustSlipNoSetDB
    {
        /// <summary>
        /// CustSlipNoSetDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        public MediationCustSlipNoSetDB()
        {

        }

        /// <summary>
        /// ICustSlipNoSetDBインターフェース取得
        /// </summary>
        /// <returns>ICustSlipNoSetDBオブジェクト</returns>
        public static ICustSlipNoSetDB GetCustSlipNoSetDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICustSlipNoSetDB)Activator.GetObject(typeof(ICustSlipNoSetDB),string.Format("{0}/MyAppCustSlipNoSet",wkStr));
        }
    }
}
