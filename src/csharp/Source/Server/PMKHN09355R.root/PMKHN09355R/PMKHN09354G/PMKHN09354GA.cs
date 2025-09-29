using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// CustomerCustomerChangeDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICustomerCustomerChangeDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接CustomerCustomerChangeDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 23012　畠中 啓次朗</br>
    /// <br>Date       : 2008.11.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCustomerCustomerChangeDB
    {
        /// <summary>
        /// CustomerCustomerChangeDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 23012　畠中 啓次朗</br>
        /// <br>Date       : 2008.11.10</br>
        /// </remarks>
        public MediationCustomerCustomerChangeDB()
        {

        }

        /// <summary>
        /// ICustomerCustomerChangeDBインターフェース取得
        /// </summary>
        /// <returns>ICustomerCustomerChangeDBオブジェクト</returns>
        public static ICustomerCustomerChangeDB GetCustomerCustomerChangeDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICustomerCustomerChangeDB)Activator.GetObject(typeof(ICustomerCustomerChangeDB), string.Format("{0}/MyAppCustomerCustomerChange", wkStr));
        }
    }
}