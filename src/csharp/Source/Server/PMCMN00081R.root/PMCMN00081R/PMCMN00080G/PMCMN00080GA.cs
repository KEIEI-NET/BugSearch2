using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : このクラスはIDepsitListWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>               完全スタンドアロンにする場合にはこのクラスで直接リモートオブジェクトを</br>
    /// <br>               インスタンス化して戻します。</br>
    /// <br>Programmer   : 脇田 靖之</br>
    /// <br>Date         : 2015/09/24</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationLSMLogCheckDB
    {
        /// <summary>
        /// DB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/09/24</br>
        /// </remarks>
        public MediationLSMLogCheckDB()
        {
        }
        /// <summary>
        /// DBインターフェース取得
        /// </summary>
        /// <returns>DBオブジェクト</returns>
        public static ILSMLogCheckDB GetLSMLogCheckDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain( ConstantManagement_SF_PRO.ServerCode_UserAP );
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ILSMLogCheckDB)Activator.GetObject(typeof(ILSMLogCheckDB), string.Format("{0}/MyAppLSMLogCheck", wkStr));
        }
    }
}
