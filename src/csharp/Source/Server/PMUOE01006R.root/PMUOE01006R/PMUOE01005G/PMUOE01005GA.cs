//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE発注用I/OWriteDB仲介クラス
//                  :   PMUOE01005G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   21112　久保田
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
    /// IOWriteUOEOdrDtlDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIIOWriteUOEOdrDtlDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接IOWriteUOEOdrDtlDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 21112　久保田</br>
    /// <br>Date       : 2008.09.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationIOWriteUOEOdrDtlDB
    {
        /// <summary>
        /// IOWriteUOEOdrDtlDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        /// </remarks>
        public MediationIOWriteUOEOdrDtlDB()
        {

        }

        /// <summary>
        /// IIOWriteUOEOdrDtlDBインターフェース取得
        /// </summary>
        /// <returns>IIOWriteUOEOdrDtlDBオブジェクト</returns>
        public static IIOWriteUOEOdrDtlDB GetIOWriteUOEOdrDtlDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IIOWriteUOEOdrDtlDB)Activator.GetObject(typeof(IIOWriteUOEOdrDtlDB),string.Format("{0}/MyAppIOWriteUOEOdrDtl",wkStr));
        }
    }
}
