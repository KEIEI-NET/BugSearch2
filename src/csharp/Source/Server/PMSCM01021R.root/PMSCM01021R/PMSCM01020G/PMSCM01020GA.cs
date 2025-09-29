//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCM関連データDB仲介クラス
//                  :   PMSCM01020G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   22008 長内 数馬
// Date             :   2009.05.13
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ScmIOWriterDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIScmIOWriterDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接IScmIOWriterDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationIOWriteScmDB
    {
        /// <summary>
        /// IScmIOWriterDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public MediationIOWriteScmDB()
        {

        }

        /// <summary>
        /// IScmIOWriterDBインターフェース取得
        /// </summary>
        /// <returns>IScmIOWriterDBオブジェクト</returns>
        public static IIOWriteScmDB GetIOWriteScmDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8002";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IIOWriteScmDB)Activator.GetObject(typeof(IIOWriteScmDB), string.Format("{0}/MyAppIOWriteScm", wkStr));
        }
    }
}
