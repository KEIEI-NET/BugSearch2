//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   TBO検索マスタ(ユーザー登録)DB仲介クラス
//                  :   PMKEN09113G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   22008 長内 数馬
// Date             :   2008.11.17
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
    /// TBOSearchUDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはITBOSearchUDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接TBOSearchUDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.11.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationTBOSearchUDB
    {
        /// <summary>
        /// TBOSearchUDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        /// </remarks>
        public MediationTBOSearchUDB()
        {

        }

        /// <summary>
        /// ITBOSearchUDBインターフェース取得
        /// </summary>
        /// <returns>ITBOSearchUDBオブジェクト</returns>
        public static ITBOSearchUDB GetTBOSearchUDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ITBOSearchUDB)Activator.GetObject(typeof(ITBOSearchUDB), string.Format("{0}/MyAppTBOSearchU", wkStr));
        }
    }
}
