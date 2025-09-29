using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SetPartsDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISetPartsDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SetPartsDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30350 櫻井　亮太</br>
    /// <br>Date       : 2009.06.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSetPartsDB
    {
        /// <summary>
        /// SetPartsDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2009.06.22</br>
        /// </remarks>
        public MediationSetPartsDB()
        {
        }
        /// <summary>
        /// IJoinPartsDBインターフェース取得
        /// </summary>
        /// <returns>IJoinPartsDBオブジェクト</returns>
        public static ISetPartsDB GetSetPartsDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
            
#if DEBUG
    wkStr = "http://localhost:9002";
#endif            

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISetPartsDB)Activator.GetObject(typeof(ISetPartsDB), string.Format("{0}/MyAppSetParts", wkStr));
        }
    }
}
