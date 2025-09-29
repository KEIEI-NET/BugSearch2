using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// public class name:   MediationIOWriteMASIRDB
    /// <summary>
    ///                      仕入エントリ更新リモーティング仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入エントリ更新リモーティング仲介クラス</br>
    /// <br>Programmer       :   斉藤　雅明</br>
    /// <br>Date             :   2006/12/26</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MediationIOWriteMASIRDB
    {
        /// <summary>
        /// MediationIOWriteSFDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.26</br>
        /// </remarks>
        public MediationIOWriteMASIRDB()
        {
        }

        /// <summary>
        /// IIOWriteMASIRDBインターフェース取得
        /// </summary>
        /// <returns>IIOWriteMASIRDBオブジェクト</returns>
        public static IIOWriteMASIRDB GetIOWriteMASIRDB()
        {
            //USERデータアプリケーションサーバーのPathを取得
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:8008";
#endif
            
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IIOWriteMASIRDB)Activator.GetObject(typeof(IIOWriteMASIRDB), string.Format("{0}/MyAppIOWriteMASIR", wkStr));
        }
    }
}