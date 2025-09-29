using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StcHisRefDataDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIStcHisRefDataDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接StcHisRefDataDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.09.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStcHisRefDataDB
    {
        /// <summary>
        /// StcHisRefDataDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.21</br>
        /// </remarks>
        public MediationStcHisRefDataDB()
        {
        }
        /// <summary>
        /// IStcHisRefDataDBインターフェース取得
        /// </summary>
        /// <returns>IStcHisRefDataDBオブジェクト</returns>
        public static IStcHisRefDataDB GetStcHisRefDataDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStcHisRefDataDB)Activator.GetObject(typeof(IStcHisRefDataDB),string.Format("{0}/MyAppStcHisRefData",wkStr));
        }
    }
}
