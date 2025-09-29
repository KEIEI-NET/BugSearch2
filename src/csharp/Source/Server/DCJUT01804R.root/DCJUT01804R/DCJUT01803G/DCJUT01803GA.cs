using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// AcceptOdrDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIAcceptOdrDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接AcceptOdrDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.09.12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationAcceptOdrDB
    {
        /// <summary>
        /// AcceptOdrDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        /// </remarks>
        public MediationAcceptOdrDB()
        {
        }
        /// <summary>
        /// IAcceptOdrDBインターフェース取得
        /// </summary>
        /// <returns>IAcceptOdrDBオブジェクト</returns>
        public static IAcceptOdrDB GetAcceptOdrDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8008";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IAcceptOdrDB)Activator.GetObject(typeof(IAcceptOdrDB),string.Format("{0}/MyAppAcceptOdr",wkStr));
        }
    }
}
