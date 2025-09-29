using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SyncStateDspTermStDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISyncStateDspTermStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SyncStateDspTermStDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 劉超</br>
    /// <br>Date       : 2014/08/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSyncStateDspTermStDB
    {
        /// <summary>
        /// SyncStateDspTermStDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public MediationSyncStateDspTermStDB()
        {
        }
        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        public static ISyncStateDspTermStDB GetSyncStateDspTermStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISyncStateDspTermStDB)Activator.GetObject(typeof(ISyncStateDspTermStDB), string.Format("{0}/MyAppSyncStateDspTermSt", wkStr));
        }
    }
}
