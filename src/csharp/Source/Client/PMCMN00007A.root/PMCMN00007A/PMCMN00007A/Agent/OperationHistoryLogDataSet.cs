namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// 操作履歴ログデータDBのデータセット
    /// </summary>
    partial class OperationHistoryLogDataSet
    {
        /// <summary>
        /// 操作履歴ログデータテーブルのカラムインデックス列挙体
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
            /// <summary>ログデータ作成日時</summary>
            LogDataCreateDateTime,
            /// <summary>ログデータGUID</summary>
            LogDataGuid,
            /// <summary>ログイン拠点コード</summary>
            LoginSectionCd,
            /// <summary>ログデータ種別区分コード</summary>
            LogDataKindCd,
            /// <summary>ログデータ端末名</summary>
            LogDataMachineName,
            /// <summary>ログデータ担当者コード</summary>
            LogDataAgentCd,
            /// <summary>ログデータ担当者名</summary>
            LogDataAgentNm,
            /// <summary>ログデータ対象起動プログラム名称</summary>
            LogDataObjBootProgramNm,
            /// <summary>ログデータ対象アセンブリID</summary>
            LogDataObjAssemblyID,
            /// <summary>ログデータ対象アセンブリ名称</summary>
            LogDataObjAssemblyNm,
            /// <summary>ログデータ対象クラスID</summary>
            LogDataObjClassID,
            /// <summary>ログデータ対象処理名</summary>
            LogDataObjProcNm,
            /// <summary>ログデータオペレーションコード</summary>
            LogDataOperationCd,
            /// <summary>ログデータオペレーターデータ処理レベル</summary>
            LogOperaterDtProcLvl,
            /// <summary>ログデータオペレーター機能処理レベル</summary>
            LogOperaterFuncLvl,
            /// <summary>ログデータシステムバージョン</summary>
            LogDataSystemVersion,
            /// <summary>ログオペレーションステータス</summary>
            LogOperationStatus,
            /// <summary>ログデータメッセージ</summary>
            LogDataMassage,
            /// <summary>ログオペレーションデータ</summary>
            LogOperationData
        }

        /// <summary>
        /// ログ種別名を取得します。
        /// </summary>
        /// <param name="logKind">ログ種別</param>
        /// <returns>ログ種別名</returns>
        public static string GetLogKingName(int logKind)
        {
            switch (logKind)
            {
                case 0:
                    return "記録";  // LITERAL:
                case 1:
                    return "エラー";    // LITERAL:
                case 9:
                    return "システム";  // LITERAL:
                case 10:
                    return "UOE(DSP)";  // LITERAL:
                case 11:
                    return "UOE(通信)"; // LITERAL:
                default:
                    return string.Empty;
            }
        }
    }
}
