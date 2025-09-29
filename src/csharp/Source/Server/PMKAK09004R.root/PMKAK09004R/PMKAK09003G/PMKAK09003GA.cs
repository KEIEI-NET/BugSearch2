//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   仕入先マスタ（総括設定）DB仲介クラス
//                  :   PMKAK09003G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   FSI斎藤 和宏
// Date             :   2012/08/29
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SumSuppStDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISumSuppStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SumSuppStDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : FSI斎藤 和宏</br>
    /// <br>Date       : 2012/08/29</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSumSuppStDB
    {
        /// <summary>
        /// SumSuppStDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        /// </remarks>
        public MediationSumSuppStDB()
        {

        }

        /// <summary>
        /// ISumSuppStDBインターフェース取得
        /// </summary>
        /// <returns>ISumSuppStDBオブジェクト</returns>
        public static ISumSuppStDB GetSumSuppStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISumSuppStDB)Activator.GetObject(typeof(ISumSuppStDB),string.Format("{0}/MyAppSumSuppSt",wkStr));
        }
    }
}
