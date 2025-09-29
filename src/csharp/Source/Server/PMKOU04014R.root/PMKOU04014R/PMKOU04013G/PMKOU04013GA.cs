using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 仕入先電子元帳 DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISuppPrtPprWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SuppPrtPprWorkDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 23015 森本 大輝</br>
    /// <br>Date       : 2008.08.18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSuppPrtPprWorkDB
    {
        /// <summary>
        /// 仕入先電子元帳 DB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        /// </remarks>
        public MediationSuppPrtPprWorkDB()
        {
        }

        /// <summary>
        /// ISuppPrtPprWorkDBインターフェース取得
        /// </summary>
        /// <returns>ISuppPrtPprWorkDBオブジェクト</returns>
        public static ISuppPrtPprWorkDB GetSuppPrtPprWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISuppPrtPprWorkDB)Activator.GetObject(typeof(ISuppPrtPprWorkDB), string.Format("{0}/MyAppSuppPrtPprWork", wkStr));
        }
    }
}
