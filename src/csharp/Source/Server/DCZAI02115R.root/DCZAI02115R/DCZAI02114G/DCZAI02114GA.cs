using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockManagementListWorkDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIStockManagementWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接StockManagementListWorkDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2007.09.19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockManagementListWorkDB
    {
        /// <summary>
        /// MediationStockManagementListWorkDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public MediationStockManagementListWorkDB()
        {
        }
        /// <summary>
        /// IStockMoveListWorkDBインターフェース取得
        /// </summary>
        /// <returns>IStockMoveListWorkDBオブジェクト</returns>
        public static IStockManagementListWorkDB GetStockManagementListWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockManagementListWorkDB)Activator.GetObject(typeof(IStockManagementListWorkDB), string.Format("{0}/MyAppStockManagementListWork", wkStr));
        }
    }
}
