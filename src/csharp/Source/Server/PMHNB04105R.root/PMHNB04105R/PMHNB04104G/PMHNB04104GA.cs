using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SPartsDspDB 仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISPartsDspDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SPartsDspDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.10.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSPartsDspDB
    {
        /// <summary>
        /// SPartsDspDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 23012</br>
        /// <br>Date       : 2008.10.03</br>
        /// </remarks>
        public MediationSPartsDspDB()
        {
        }
        /// <summary>
        /// ISPartsDspDBインターフェース取得
        /// </summary>
        /// <returns>ISPartsDspDBオブジェクト</returns>
        public static ISPartsDspDB GetSPartsDspDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISPartsDspDB)Activator.GetObject(typeof(ISPartsDspDB), string.Format("{0}/MyAppSPartsDsp", wkStr));
        }
    }
}
