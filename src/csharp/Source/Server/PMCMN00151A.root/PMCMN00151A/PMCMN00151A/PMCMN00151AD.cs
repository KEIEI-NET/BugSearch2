//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 環境調査
// プログラム概要   : 環境調査アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00  作成担当 : 佐々木亘
// 作 成 日  2020/06/15   修正内容 : ＥＢＥ対策
//----------------------------------------------------------------------------//
using Broadleaf.Library.Resources;
using Microsoft.Win32;
using System;
using System.Collections;
using System.IO;
using System.Xml;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 影響調査データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 影響調査のアクセス制御を行います。</br>
    /// <br>Programmer	: 佐々木亘</br>
    /// <br>Date		: 2020/06/15</br>
    /// </remarks>
    public class EnvSurvDataParam
    {
        #region ■ Private Members

        /// <summary>ログ出力内容</summary>
        /// <remarks>ログ出力内容</remarks>
        private string _logOutputMsg = string.Empty;

        #endregion // ■ Private Members

        /// public propaty name  :  LogOutputMsg
        /// <summary>ログ出力内容プロパティ</summary>
        /// <value>ログ出力内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログ出力内容プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogOutputMsg
        {
            get { return _logOutputMsg; }
            set { _logOutputMsg = value; }
        }

        # region ■ Constructor

        /// <summary>
        /// 影響調査データクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 影響調査データクラスの新しいインスタンスを生成します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        public EnvSurvDataParam()
        {
        }

        /// <summary>
        /// 影響調査データクラスコンストラクタ
        /// </summary>
        /// <param name="logOutputMsg">ログ出力内容</param>
        /// <remarks>
        /// <br>Note       : 影響調査データクラスの新しいインスタンスを生成します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        public EnvSurvDataParam(string logOutputMsg)
        {
            this._logOutputMsg = logOutputMsg;
        }

        # endregion // ■ Constructor

        #region ■ Public Methods

        #endregion // ■ Public Methods
    }
}
