//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   得意先マスタ（総括設定）DB仲介クラス
//                  :   PMKHN09244G.DLL
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
    /// <br>Note       : このクラスはISumCustStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SumCustStDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.10.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSumCustStDB
    {
        /// <summary>
        /// SumCustStDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        /// </remarks>
        public MediationSumCustStDB()
        {

        }

        /// <summary>
        /// ISumCustStDBインターフェース取得
        /// </summary>
        /// <returns>ISumCustStDBオブジェクト</returns>
        public static ISumCustStDB GetSumCustStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISumCustStDB)Activator.GetObject(typeof(ISumCustStDB),string.Format("{0}/MyAppSumCustSt",wkStr));
        }
    }
}
