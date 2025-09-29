using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockMoveListWorkDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIStockMoveListWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接StockMoveListWorkDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 22035 三橋 弘憲</br>
    /// <br>Date       : 2007.03.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockMoveListWorkDB
    {
        /// <summary>
        /// StockMoveListWorkDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.14</br>
        /// </remarks>
        public MediationStockMoveListWorkDB()
        {
        }
        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        public static IStockMoveListWorkDB GetStockMoveListWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockMoveListWorkDB)Activator.GetObject(typeof(IStockMoveListWorkDB), string.Format("{0}/MyAppStockMoveListWork", wkStr));
        }
    }
}
