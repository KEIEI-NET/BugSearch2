using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// CustDmdPrcDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICustDmdPrcDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接CustDmdPrcDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.03.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCustDmdPrcDB
    {
        /// <summary>
        /// CustDmdPrcDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.14</br>
        /// </remarks>
        public MediationCustDmdPrcDB()
        {
        }

        /// <summary>
        /// ICustDmdPrcDBインターフェース取得
        /// </summary>
        /// <returns>ICustDmdPrcDBオブジェクト</returns>
        public static ICustDmdPrcDB GetCustDmdPrcDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICustDmdPrcDB)Activator.GetObject(typeof(ICustDmdPrcDB), string.Format("{0}/MyAppCustDmdPrc", wkStr));
        }
    }
}
