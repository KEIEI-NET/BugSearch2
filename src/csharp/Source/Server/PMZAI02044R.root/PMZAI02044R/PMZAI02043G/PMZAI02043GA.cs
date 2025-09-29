using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SalesOrderRemainClearDB 仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISalesOrderRemainClearDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SalesOrderRemainClearDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.08.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSalesOrderRemainClearDB
    {
        /// <summary>
        /// SalesOrderRemainClearDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        public MediationSalesOrderRemainClearDB()
        {
        }
        /// <summary>
        /// ISalesOrderRemainClearDBインターフェース取得
        /// </summary>
        /// <returns>ISalesOrderRemainClearDBオブジェクト</returns>
        public static ISalesOrderRemainClearDB GetSalesOrderRemainClearDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISalesOrderRemainClearDB)Activator.GetObject(typeof(ISalesOrderRemainClearDB), string.Format("{0}/MyAppSalesOrderRemainClear", wkStr));
        }
    }
}
