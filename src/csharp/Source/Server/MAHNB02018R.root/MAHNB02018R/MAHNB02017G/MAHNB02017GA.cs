using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// DepsitListWorkDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIDepsitListWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接DepsitListWorkDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 22035 三橋 弘憲</br>
    /// <br>Date       : 2007.03.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>           :   2007.11.15  DC.NS 用に改造  横川昌令</br>
    /// </remarks>
    public class MediationDepsitListWorkDB
    {
        /// <summary>
        /// DepsitListWorkDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        public MediationDepsitListWorkDB()
        {
        }
        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        public static IDepsitListWorkDB GetDepsitListWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IDepsitListWorkDB)Activator.GetObject(typeof(IDepsitListWorkDB), string.Format("{0}/MyAppDepsitListWork", wkStr));
        }
    }
}
