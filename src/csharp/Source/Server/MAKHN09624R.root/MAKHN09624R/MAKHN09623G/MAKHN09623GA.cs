using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// GoodsSetDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIGoodsSetDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>            完全スタンドアロンにする場合にはこのクラスで直接GoodsSetDBを</br>
    /// <br>            インスタンス化して戻します。</br>
    /// <br>Programmer : 19026　湯山　美樹</br>
    /// <br>Date       : 2007.04.27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationGoodsSetDB
    {
        /// <summary>
        /// GoodsSetDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        /// </remarks>
        public MediationGoodsSetDB()
        {
        }
        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        public static IGoodsSetDB GetGoodsSetDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IGoodsSetDB)Activator.GetObject(typeof(IGoodsSetDB),string.Format("{0}/MyAppGoodsSet",wkStr));
        }
    }
}
