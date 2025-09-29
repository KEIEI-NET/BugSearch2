//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : セキュリティ管理インターフェース
// プログラム概要   : セキュリティ管理の子フォーム用共通インタフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// セキュリティ管理フォームコントロールインターフェース
    /// </summary>
    public interface ISecurityManagementForm
    {
        /// <summary>
        /// 保存ボタンを表示するフラグ
        /// </summary>
        /// <value>true :保存ボタンを表示<br/>false:保存ボタンを非表示</value>
        bool CanWrite { get; }

        /// <summary>
        /// 表示更新ボタンを表示するフラグ
        /// </summary>
        /// <value>true :表示更新ボタンを表示<br/>false:表示更新ボタンを非表示</value>
        bool CanUpdateDisplay { get; }

        /// <summary>
        /// 保存ボタン押下時の処理を行います。
        /// </summary>
        /// <returns>成功時に 0(=(int)ResultCode.Normal) を返します。 </returns>
        int Write();

        /// <summary>
        /// 表示更新ボタン押下時の処理を行います。
        /// </summary>
        void UpdateDisplay();

        /// <summary>
        /// 対応するタブがアクティブになった時の処理を行います。
        /// </summary>
        void Active();
    }

    /// <summary>
    /// 結果コード列挙体
    /// </summary>
    public enum ResultCode : int
    {
        /// <summary>正常</summary>
        Normal = 0,
        /// <summary>異常</summary>
        Error
    }
}
