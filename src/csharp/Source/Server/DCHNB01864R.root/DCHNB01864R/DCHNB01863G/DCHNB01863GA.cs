using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// IOWriteControlDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIIOWriteControlDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接IOWriteControlDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2008.02.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationIOWriteControlDB
    {
        /// <summary>
        /// IOWriteControlDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.02.13</br>
        /// </remarks>
        public MediationIOWriteControlDB()
        {
        }
        /// <summary>
        /// IIOWriteControlDBインターフェース取得
        /// </summary>
        /// <returns>IIOWriteControlDBオブジェクト</returns>
        public static IIOWriteControlDB GetIOWriteControlDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9011";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IIOWriteControlDB)Activator.GetObject(typeof(IIOWriteControlDB),string.Format("{0}/MyAppIOWriteControl",wkStr));
        }
    }
}
