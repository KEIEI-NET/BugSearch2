//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限設定データ
// プログラム概要   : 操作権限設定のUI用データセットを実装します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 操作権限設定のUI用データセット
    /// </summary>
    partial class SettingDataSet
    {
        /// <summary>
        /// 操作権限設定のUI用データテーブルのカラムインデックス列挙体
        /// </summary>
        /// <remarks>
        /// ①カラム名を変更した場合、列挙値名も変更すること（カラム名と列挙値名を同じにする）。<br/>
        /// ②カラム順を変更した場合、列挙値の定義位置も変更すること（定義位置がインデックスを表す）。
        /// </remarks>
        public enum ClmIdx : int
        {
            /// <summary>インデックス</summary>
            /// <remarks>1～</remarks>
            Index,

            /// <summary>提供日付</summary>
	        OfferDate,
	        /// <summary>カテゴリコード</summary>
	        CategoryCode,
	        /// <summary>カテゴリ名称</summary>
	        CategoryName,
	        /// <summary>カテゴリ表示順位</summary>
	        CategoryDspOdr,
	        /// <summary>プログラムＩＤ</summary>
	        PgId,
	        /// <summary>プログラム名称</summary>
	        PgName,
	        /// <summary>プログラム表示順位</summary>
	        PgDspOdr,
	        /// <summary>オペレーションコード</summary>
	        OperationCode,
	        /// <summary>オペレーション名称</summary>
	        OperationName,
	        /// <summary>オペレーション表示順位</summary>
	        OperationDspOdr,

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
            /// <summary>職種</summary>
            AuthorityLevel1,
            /// <summary>雇用形態</summary>
            AuthorityLevel2,
            /// <summary>従業員</summary>
            EmployeeCode,
            /// <summary>制限区分</summary>
            LimitDiv,
            /// <summary>適用開始日</summary>
            ApplyStartDate,
            /// <summary>適用終了日</summary>
            ApplyEndDate,

	        /// <summary>許可</summary>
	        Admission,
	        /// <summary>設定適用</summary>
	        SettingApp,
            /// <summary>操作権限</summary>
            OperationLimit,
            /// <summary>制限</summary>
            Limitation
        }

        /// <summary>列数</summary>
        /// <remarks>列を追加または削除したときは値を更新すること。</remarks>
        private const int COLUMNS_COUNT = 30;

        /// <summary>
        /// 列名の配列を取得します。
        /// </summary>
        /// <returns>列名の配列</returns>
        public static string[] GetColumnNames()
        {
            string[] columnNames = new string[COLUMNS_COUNT];

            columnNames[0] = SettingDataSet.ClmIdx.Index.ToString();
            columnNames[1] = SettingDataSet.ClmIdx.OfferDate.ToString();
            columnNames[2] = SettingDataSet.ClmIdx.CategoryCode.ToString();
            columnNames[3] = SettingDataSet.ClmIdx.CategoryName.ToString();
            columnNames[4] = SettingDataSet.ClmIdx.CategoryDspOdr.ToString();
            columnNames[5] = SettingDataSet.ClmIdx.PgId.ToString();
            columnNames[6] = SettingDataSet.ClmIdx.PgName.ToString();
            columnNames[7] = SettingDataSet.ClmIdx.PgDspOdr.ToString();
            columnNames[8] = SettingDataSet.ClmIdx.OperationCode.ToString();
            columnNames[9] = SettingDataSet.ClmIdx.OperationName.ToString();
            columnNames[10] = SettingDataSet.ClmIdx.OperationDspOdr.ToString();
            columnNames[11] = SettingDataSet.ClmIdx.CreateDateTime.ToString();
            columnNames[12] = SettingDataSet.ClmIdx.UpdateDateTime.ToString();
            columnNames[13] = SettingDataSet.ClmIdx.EnterpriseCode.ToString();
            columnNames[14] = SettingDataSet.ClmIdx.FileHeaderGuid.ToString();
            columnNames[15] = SettingDataSet.ClmIdx.UpdEmployeeCode.ToString();
            columnNames[16] = SettingDataSet.ClmIdx.UpdAssemblyId1.ToString();
            columnNames[17] = SettingDataSet.ClmIdx.UpdAssemblyId2.ToString();
            columnNames[18] = SettingDataSet.ClmIdx.LogicalDeleteCode.ToString();
            columnNames[19] = SettingDataSet.ClmIdx.OperationStDiv.ToString();
            columnNames[20] = SettingDataSet.ClmIdx.AuthorityLevel1.ToString();
            columnNames[21] = SettingDataSet.ClmIdx.AuthorityLevel2.ToString();
            columnNames[22] = SettingDataSet.ClmIdx.EmployeeCode.ToString();
            columnNames[23] = SettingDataSet.ClmIdx.LimitDiv.ToString();
            columnNames[24] = SettingDataSet.ClmIdx.ApplyStartDate.ToString();
            columnNames[25] = SettingDataSet.ClmIdx.ApplyEndDate.ToString();
            columnNames[26] = SettingDataSet.ClmIdx.Admission.ToString();
            columnNames[27] = SettingDataSet.ClmIdx.SettingApp.ToString();
            columnNames[28] = SettingDataSet.ClmIdx.OperationLimit.ToString();
            columnNames[29] = SettingDataSet.ClmIdx.Limitation.ToString();

            return columnNames;
        }
    }
}
