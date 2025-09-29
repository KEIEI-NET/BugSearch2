//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナルログイン情報取得条件ワーク
// プログラム概要   : ハンディターミナルログイン情報取得条件ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 朱宝軍
// 作 成 日  2017/06/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyLoginInfoCondWork
    /// <summary>
    ///                      ハンディターミナルログイン情報取得条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ハンディターミナルログイン情報取得条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/06/05</br>
    /// <br>Genarated Date   :   2017/06/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyLoginInfoCondWork
    {
        /// <summary>企業コード</summary>
        private string _enterpriseCode = "";

        /// <summary>ログインID</summary>
        private string _loginId = "";

        /// <summary>コンピュータ名</summary>
        private string _machineName = "";

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  LoginId
        /// <summary>ログインIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログインIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LoginId
        {
            get { return _loginId; }
            set { _loginId = value; }
        }

        /// public propaty name  :  MachineName
        /// <summary>コンピュータ名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コンピュータ名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
        }

        /// <summary>
        /// ハンディターミナルログイン情報取得条件ワークコンストラクタ
        /// </summary>
        /// <returns>HandyLoginInfoCondWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyLoginInfoCondWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public HandyLoginInfoCondWork()
        {
        }

    }
}
