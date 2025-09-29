//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 環境調査
// プログラム概要   : 環境調査を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 佐々木亘
// 作 成 日  2020/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// EnvSurvObjDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIEnvSurvObjDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接EnvSurvObjDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 佐々木亘</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    public class MediationEnvSurvObjDB 
    {
        /// <summary>
        /// IEnvSurvObjDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public MediationEnvSurvObjDB()
        {
        }
        /// <summary>
        /// IEnvSurvObjDBインターフェース取得
        /// </summary>
        /// <returns>IEnvSurvObjDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IEnvSurvObjDBインターフェース取得</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// <br></br>
        /// </remarks>
        public static IEnvSurvObjDB GetEnvSurvObjDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IEnvSurvObjDB)Activator.GetObject(typeof(IEnvSurvObjDB), string.Format("{0}/MyAppEnvSurvObj", wkStr));
        }
    }
}
