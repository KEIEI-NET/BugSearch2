using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// public class name:   MediationIOWriteMAHNBDB
    /// <summary>
    ///                      売上エントリ更新リモーティング仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上エントリ更新リモーティング仲介クラス</br>
    /// <br>Programmer       :   久保田　誠</br>
    /// <br>Date             :   2007/11/26</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MediationIOWriteMAHNBDB
    {
        /// <summary>
        /// MediationIOWriteMAHNBDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public MediationIOWriteMAHNBDB()
        {
        }

        /// <summary>
        /// IIOWriteMASIRDBインターフェース取得
        /// </summary>
        /// <returns>IIOWriteMASIRDBオブジェクト</returns>
        public static IIOWriteMAHNBDB GetIOWriteMAHNBDB()
        {
            //USERデータアプリケーションサーバーのPathを取得
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IIOWriteMAHNBDB)Activator.GetObject(typeof(IIOWriteMAHNBDB), string.Format("{0}/MyAppIOWriteMAHNB", wkStr));
        }
    }
}