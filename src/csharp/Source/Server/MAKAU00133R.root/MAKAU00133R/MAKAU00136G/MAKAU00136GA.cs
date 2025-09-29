using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// MonthlyAddUpDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIMonthlyAddUpDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接MonthlyAddUpDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.04.04</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationMonthlyAddUpDB
    {
        /// <summary>
        /// MonthlyAddUpDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.04</br>
        /// </remarks>
        public MediationMonthlyAddUpDB()
        {
        }

        /// <summary>
        /// IMonthlyAddUpDBインターフェース取得
        /// </summary>
        /// <returns>IMonthlyAddUpDBオブジェクト</returns>
        public static IMonthlyAddUpDB GetCustMonthlyAddUpDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IMonthlyAddUpDB)Activator.GetObject(typeof(IMonthlyAddUpDB), string.Format("{0}/MyAppMonthlyAddUp", wkStr));
        }
    }
}
