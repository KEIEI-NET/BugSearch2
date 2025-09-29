using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// CustomerChangeDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICustomerChangeDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接CustomerChangeDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer : 20081　疋田　勇人</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCustomerChangeDB
    {
        /// <summary>
        /// CustomerChangeDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public MediationCustomerChangeDB()
        {
        }
        /// <summary>
        /// ICustomerChangeDBインターフェース取得
        /// </summary>
        /// <returns>ICustomerChangeDBオブジェクト</returns>
        public static ICustomerChangeDB GetCustomerChangeDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICustomerChangeDB)Activator.GetObject(typeof(ICustomerChangeDB), string.Format("{0}/MyAppCustomerChange", wkStr));
        }
    }
}
