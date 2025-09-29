//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   同期実行管理 DB仲介クラス
//                  :   PMSCM00211G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   田建委
// Date             :   2014/08/01
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 同期実行管理 DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISynchExecuteMngDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接JoinPartsUDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2014/08/01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSynchExecuteMngDB
    {
        /// <summary>
        /// 同期実行管理 DB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public MediationSynchExecuteMngDB()
        {

        }

        /// <summary>
        /// ISynchExecuteMngDBインターフェース取得
        /// </summary>
        /// <returns>ISynchExecuteMngDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : ISynchExecuteMngDBインターフェースを取得する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public static ISynchExecuteMngDB GetSynchExecuteMngDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8008";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISynchExecuteMngDB)Activator.GetObject(typeof(ISynchExecuteMngDB), string.Format("{0}/MyAppSynchExecuteMng", wkStr));
        }
    }
}
