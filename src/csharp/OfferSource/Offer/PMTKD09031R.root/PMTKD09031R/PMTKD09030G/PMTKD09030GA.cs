using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// TbsPartsCodeDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPartsCodeDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接TbsPartsCodeDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 22008　長内　数馬</br>
    /// <br>Date       : 2008.06.04</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationTbsPartsCodeDB
    {
        /// <summary>
        /// TbsPartsCodeDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.04</br>
        /// </remarks>
        public MediationTbsPartsCodeDB()
        {
        }
        /// <summary>
        /// ITbsPartsCodeDBインターフェース取得
        /// </summary>
        /// <returns>ITbsPartsCodeDBオブジェクト</returns>
        public static ITbsPartsCodeDB GetTbsPartsCodeDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
            
#if DEBUG
    wkStr = "http://localhost:9002";
#endif            

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ITbsPartsCodeDB)Activator.GetObject(typeof(ITbsPartsCodeDB), string.Format("{0}/MyAppTbsPartsCode", wkStr));
        }
    }
}
