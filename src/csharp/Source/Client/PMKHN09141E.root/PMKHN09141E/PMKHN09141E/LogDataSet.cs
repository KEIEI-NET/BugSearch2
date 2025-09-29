namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 表示用ログデータセット
    /// </summary>
    partial class LogDataSet
    {
        /// <summary>
        /// 表示用ログデータテーブルのカラムインデックス列挙体
        /// </summary>
        /// <remarks>
        /// ①カラム名を変更した場合、列挙値名も変更すること（カラム名と列挙値名を同じにする）。<br/>
        /// ②カラム順を変更した場合、列挙値の定義位置も変更すること（定義位置がインデックスを表す）。
        /// </remarks>
        public enum ClmIdx : int
        {
            /// <summary>日付</summary>
            Date,
            /// <summary>時刻</summary>
            Time,
            /// <summary>ログ種別コード</summary>
            LogKindCode,
            /// <summary>ログ種別</summary>
            LogKind,
            /// <summary>拠点コード</summary>
            SectionCode,
            /// <summary>拠点名称</summary>
            SectionName,
            /// <summary>端末名称</summary>
            MachineName,
            /// <summary>職種(権限レベル1)</summary>
            JobTypeLevel,
            /// <summary>職種名称</summary>
            JobTypeName,
            /// <summary>雇用形態(権限レベル2)</summary>
            EmploymentFormLevel,
            /// <summary>雇用形態名称</summary>
            EmploymentFormName,
            /// <summary>従業員コード</summary>
            EmployeeCode,
            /// <summary>従業員名称</summary>
            EmployeeName,
            /// <summary>カテゴリコード</summary>
            CategoryCode,
            /// <summary>カテゴリ名称</summary>
            CategoryName,
            /// <summary>プログラムID</summary>
            PgId,
            /// <summary>機能名称</summary>
            PgName,
            /// <summary>操作コード</summary>
            OperationCode,
            /// <summary>操作名称</summary>
            OperationName,
            /// <summary>メッセージ</summary>
            Message,
            /// <summary>日時</summary>
            LogDateTime
        }
    }
}
