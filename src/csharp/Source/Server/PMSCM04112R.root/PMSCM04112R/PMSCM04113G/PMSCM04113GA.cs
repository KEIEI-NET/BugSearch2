//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   同期状況確認 DB仲介クラス
//                  :   PMSCM04113G.DLL
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
    /// 同期状況確認 DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISynchConfirmDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接JoinPartsUDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2014/08/01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSynchConfirmDB
    {
        /// <summary>
        /// 同期状況確認 DB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public MediationSynchConfirmDB()
        {

        }

        /// <summary>
        /// ISynchConfirmDBインターフェース取得
        /// </summary>
        /// <returns>ISynchConfirmDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : ISynchConfirmDBインターフェースを取得する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public static ISynchConfirmDB GetSynchConfirmDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISynchConfirmDB)Activator.GetObject(typeof(ISynchConfirmDB), string.Format("{0}/MyAppSynchConfirm", wkStr));
        }
    }
}
