using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SalesTransListResultDB 仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISalesTransListResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SalesTransListResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2007.11.27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSalesTransListResultDB
    {
        /// <summary>
        /// SalesTransListResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.27</br>
        /// </remarks>
        public MediationSalesTransListResultDB()
        {
        }
        /// <summary>
        /// ISalesTransListResultDBインターフェース取得
        /// </summary>
        /// <returns>ISalesTransListResultDBオブジェクト</returns>
        public static ISalesTransListResultDB GetSalesTransListResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISalesTransListResultDB)Activator.GetObject(typeof(ISalesTransListResultDB), string.Format("{0}/MyAppSalesTransListResult", wkStr));
        }
    }
}
