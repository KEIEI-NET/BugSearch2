using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// WorkingPtn仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIHolidaySettingDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接HolidaySettingDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 20096　村瀬　勝也</br>
    /// <br>Date       : 2007.01.25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationHolidaySettingDB
    {
        /// <summary>
        /// HolidaySettingDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        /// </remarks>
        public MediationHolidaySettingDB()
        {
        }
        /// <summary>
        /// IHolidaySettingDBインターフェース取得
        /// </summary>
        /// <returns>IHolidaySettingDBオブジェクト</returns>
        public static IHolidaySettingDB GetHolidaySettingDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IHolidaySettingDB)Activator.GetObject(typeof(IHolidaySettingDB), string.Format("{0}/MyAppHolidaySetting", wkStr));
        }
    }
}
