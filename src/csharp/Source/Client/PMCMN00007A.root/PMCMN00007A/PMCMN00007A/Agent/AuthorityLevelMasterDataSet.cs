//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限設定データ
// プログラム概要   : 操作権限設定（権限レベルマスタ）のデータセットを実装します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// 権限レベルマスタDBのデータセット
    /// </summary>
    partial class AuthorityLevelMasterDataSet
    {
        /// <summary>
        /// 権限レベルマスタテーブルのカラムインデックス列挙体
        /// </summary>
        /// <remarks>
        /// ①カラム名を変更した場合、列挙値名も変更すること（カラム名と列挙値名を同じにする）。<br/>
        /// ②カラム順を変更した場合、列挙値の定義位置も変更すること（定義位置がインデックスを表す）。
        /// </remarks>
        public enum ClmIdx : int
        {
            /// <summary>提供日付</summary>
            OfferDate,
            /// <summary>権限レベル区分</summary>
            AuthorityLevelDiv,
            /// <summary>権限レベルコード</summary>
            AuthorityLevelCd,
            /// <summary>権限レベル名称</summary>
            AuthorityLevelNm
        }

        /// <summary>
        /// 権限レベル区分の列挙体
        /// </summary>
        public enum AuthorityLevelDiv : int
        {
            /// <summary>職種</summary>
            JobType = 0,
            /// <summary>雇用形態</summary>
            EmploymentForm = 1
        }
    }
}
