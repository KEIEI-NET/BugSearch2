//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : オペレーション設定マスタのデータセット
// プログラム概要   : オペレーション設定マスタのデータセットを実装します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/08/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// オペレーション設定マスタDBのデータセット
    /// </summary>
    public partial class OperationSettingMasterDataSet
    {
        /// <summary>
        /// オペレーション設定マスタテーブルのカラムインデックス列挙体
        /// </summary>
        /// <remarks>
        /// ①カラム名を変更した場合、列挙値名も変更すること（カラム名と列挙値名を同じにする）。<br/>
        /// ②カラム順を変更した場合、列挙値の定義位置も変更すること（定義位置がインデックスを表す）。
        /// </remarks>
        public enum ClmIdx : int
        {
            /// <summary>作成日時</summary>
            CreateDateTime,
            /// <summary>更新日時</summary>
            UpdateDateTime,
            /// <summary>企業コード</summary>
            EnterpriseCode,
            /// <summary>GUID</summary>
            FileHeaderGuid,
            /// <summary>更新従業員コード</summary>
            UpdEmployeeCode,
            /// <summary>更新アセンブリID1</summary>
            UpdAssemblyId1,
            /// <summary>更新アセンブリID2</summary>
            UpdAssemblyId2,
            /// <summary>論理削除区分</summary>
            LogicalDeleteCode,
            /// <summary>オペレーション設定区分</summary>
            OperationStDiv,
            /// <summary>カテゴリーコード</summary>
            CategoryCode,
            /// <summary>プログラムＩＤ</summary>
            PgId,
            /// <summary>オペレーションコード</summary>
            OperationCode,
            /// <summary>権限レベル1</summary>
            AuthorityLevel1,
            /// <summary>権限レベル2</summary>
            AuthorityLevel2,
            /// <summary>従業員コード</summary>
            EmployeeCode,
            /// <summary>制限区分</summary>
            LimitDiv,
            /// <summary>適用開始日</summary>
            ApplyStartDate,
            /// <summary>適用終了日</summary>
            ApplyEndDate
        }

        /// <summary>
        /// 制限区分の列挙体
        /// </summary>
        public enum LimitDiv : int
        {
            /// <summary>ログ</summary>
            WithLog = 0,
            /// <summary>制限</summary>
            Limitation = 1
        }

        /// <summary>
        /// オペレーション設定区分の列挙体
        /// </summary>
        public enum OperationStDiv : int
        {
            /// <summary>権限レベル1(職種)</summary>
            AuthorityLevel1 = 0,
            /// <summary>権限レベル2(雇用形態)</summary>
            AuthorityLevel2 = 1,
            /// <summary>従業員コード</summary>
            EmployeeCode = 2
        }
    }
}
