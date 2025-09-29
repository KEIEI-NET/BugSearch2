using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockMasterTblDB 仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIStockMasterTblDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接StockMasterTblDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.08.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockMasterTblDB
    {
        /// <summary>
        /// StockMasterTblDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        public MediationStockMasterTblDB()
        {
        }
        /// <summary>
        /// IStockMasterTblDBインターフェース取得
        /// </summary>
        /// <returns>IStockMasterTblDBオブジェクト</returns>
        public static IStockMasterTblDB GetStockMasterTblDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockMasterTblDB)Activator.GetObject(typeof(IStockMasterTblDB), string.Format("{0}/MyAppStockMasterTbl", wkStr));
        }
    }
}
