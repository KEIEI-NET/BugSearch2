//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   コンバート処理 DB仲介クラス
//                  :   PMKHN08002G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   30290
// Date             :   2008.09.22
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// コンバート処理 DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIConvertProcessDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接JoinPartsUDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationConverProcessDB
    {
        /// <summary>
        /// コンバート処理 DB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        /// </remarks>
        public MediationConverProcessDB()
        {

        }

        /// <summary>
        /// IConvertProcessDBインターフェース取得
        /// </summary>
        /// <returns>IConvertProcessDBオブジェクト</returns>
        public static IConvertProcessDB GetConvertProcessDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IConvertProcessDB)Activator.GetObject(typeof(IConvertProcessDB), string.Format("{0}/MyAppConvertProcess", wkStr));
        }
    }
}
