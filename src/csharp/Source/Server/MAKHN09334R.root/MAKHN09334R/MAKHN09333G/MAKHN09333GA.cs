using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// WarehouseDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIWarehouseDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接WarehouseDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2006.12.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationWarehouseDB
    {
        /// <summary>
        /// WarehouseDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        /// </remarks>
        public MediationWarehouseDB()
        {
        }
        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        public static IWarehouseDB GetWarehouseDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IWarehouseDB)Activator.GetObject(typeof(IWarehouseDB), string.Format("{0}/MyAppWarehouse", wkStr));
        }
    }
}
