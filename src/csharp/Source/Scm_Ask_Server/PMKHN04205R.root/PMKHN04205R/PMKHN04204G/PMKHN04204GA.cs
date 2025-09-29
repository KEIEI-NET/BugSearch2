//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 他社部品検索履歴照会 
// プログラム概要   : 他社部品検索履歴照会を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ScmInqLogInquiryDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIScmInqLogInquiryDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接ScmInqLogInquiryDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 朱 猛</br>
    /// <br>Date       : 2010/11/11</br>
    /// </remarks>
    public class MediationScmInqLogInquiryDB
    {
        /// <summary>
        /// ScmInqLogInquiryDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        public MediationScmInqLogInquiryDB()
        {

        }

        /// <summary>
        /// IScmInqLogDBインターフェース取得
        /// </summary>
        /// <returns>IScmInqLogDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        public static IScmInqLogInquiryDB GetIScmInqLogInquiryDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_ASK_AP_NS);
#if DEBUG
            wkStr = "http://localhost:9010";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IScmInqLogInquiryDB)Activator.GetObject(typeof(IScmInqLogInquiryDB), string.Format("{0}/MyAppScmInqLogInquiry", wkStr));
        }
    }
}
