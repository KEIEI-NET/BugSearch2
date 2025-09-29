//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/08/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Windows.Forms;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 手動回答処理のコンフィグクラス
    /// </summary>
    public sealed class SCMManualConfig
    {
        #region <所有者フォーム>

        /// <summary>所有者フォーム</summary>
        private readonly IWin32Window _ownerForm;
        /// <summary>所有者フォームを取得または設定します。</summary>
        public IWin32Window OwnerForm { get { return _ownerForm; } }

        #endregion // </所有者フォーム>

        #region <手動検索条件>

        /// <summary>手動検索条件</summary>
        private readonly GoodsCndtn _seachingConditionManually;
        /// <summary>手動検索条件を取得します。</summary>
        public GoodsCndtn SeachingConditionManually { get { return _seachingConditionManually; } }

        #endregion // </手動検索条件>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="ownerForm">所有者フォーム</param>
        /// <param name="seachingConditionManually">手動検索条件</param>
        public SCMManualConfig(
            IWin32Window ownerForm,
            GoodsCndtn seachingConditionManually
        )
        {
            _ownerForm = ownerForm;
            _seachingConditionManually = seachingConditionManually;
        }

        #endregion // </Constructor>
    }
}
