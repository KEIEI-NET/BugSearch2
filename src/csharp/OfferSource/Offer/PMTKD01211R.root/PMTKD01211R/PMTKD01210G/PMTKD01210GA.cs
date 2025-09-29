using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// JoinPartsDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIJoinPartsDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接JoinPartsDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30350 櫻井　亮太</br>
    /// <br>Date       : 2009.06.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationJoinPartsDB
    {
        /// <summary>
        /// JoinPartsDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2009.06.22</br>
        /// </remarks>
        public MediationJoinPartsDB()
        {
        }
        /// <summary>
        /// IJoinPartsDBインターフェース取得
        /// </summary>
        /// <returns>IJoinPartsDBオブジェクト</returns>
        public static IJoinPartsDB GetJoinPartsDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
            
#if DEBUG
    wkStr = "http://localhost:9002";
#endif            

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IJoinPartsDB)Activator.GetObject(typeof(IJoinPartsDB), string.Format("{0}/MyAppJoinParts", wkStr));
        }
    }
}
