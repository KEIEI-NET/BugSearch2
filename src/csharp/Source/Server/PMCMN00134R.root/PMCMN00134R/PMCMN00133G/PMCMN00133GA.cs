//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : コンバート対象バージョン管理マスタメンテナンス
// プログラム概要   : コンバート対象バージョン管理マスタの登録・変更を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 佐々木亘
// 作 成 日  2020/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ConvObjVerMngDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIConvObjVerMngDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接ConvObjVerMngDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 佐々木亘</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    public class MediationConvObjVerMngDB 
    {
        /// <summary>
        /// IConvObjVerMngDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public MediationConvObjVerMngDB()
        {
        }
        /// <summary>
        /// IConvObjVerMngDBインターフェース取得
        /// </summary>
        /// <returns>IConvObjVerMngDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IConvObjVerMngDBインターフェース取得</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// <br></br>
        /// </remarks>
        public static IConvObjVerMngDB GetConvObjVerMngDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IConvObjVerMngDB)Activator.GetObject(typeof(IConvObjVerMngDB), string.Format("{0}/MyAppConvObjVerMng", wkStr));
        }
    }
}
