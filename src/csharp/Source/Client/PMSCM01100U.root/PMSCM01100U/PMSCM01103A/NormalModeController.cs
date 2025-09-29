//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/06/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 単体起動モード回答送信処理コントローラクラス
    /// </summary>
    public abstract class NormalModeController : SCMSendController
    {
        #region <Override>

        /// <summary>
        /// バッチ処理(送信起動モード)であるか判断します。
        /// </summary>
        /// <value>
        /// <c>true</c> :バッチ処理(送信起動モード)です。<br/>
        /// <c>false</c>:対話処理(単体起動モード)です。
        /// </value>
        /// <see cref="SCMSendController"/>
        public override bool IsBatchMode
        {
            get { return false; }
        }
        #endregion // </Override>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        protected NormalModeController() : base(string.Empty) { }

        #endregion // </Constructor>

        
    }
}
