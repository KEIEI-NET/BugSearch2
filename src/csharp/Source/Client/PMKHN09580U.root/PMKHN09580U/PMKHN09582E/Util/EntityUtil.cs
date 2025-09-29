//****************************************************************************//
// システム         : プリンタ設定マスタ（サーバ用）
// プログラム名称   : プリンタ設定マスタ（サーバ用）モデル
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/09/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.UIData.Util
{
    /// <summary>
    /// エンティティユーティリティ
    /// </summary>
    public static class EntityUtil
    {
        /// <summary>
        /// 削除されているか判断します。
        /// </summary>
        /// <param name="record">レコード</param>
        /// <returns>
        /// <c>true</c> :削除されています。<br/>
        /// <c>false</c>:削除されていません。
        /// </returns>
        public static bool Deleted(IRecordHeader record)
        {
            if (record == null) return true;
            return !record.LogicalDeleteCode.Equals(0);
        }

        /// <summary>
        /// 削除されている場合、削除日を取得します。
        /// </summary>
        /// <param name="record">レコード</param>
        /// <param name="specialDeletedDate">削除日を明示的に指定する場合のパラメータ</param>
        /// <returns>更新日時 ※削除されていない場合、<c>string.Empty</c>を返します。</returns>
        public static string GetDeletedDateIf(
            IRecordHeader record,
            string specialDeletedDate
        )
        {
            if (Deleted(record))
            {
                if (string.IsNullOrEmpty(specialDeletedDate))
                {
                    return record.UpdateDateTime.ToString("yyyy/MM/dd");
                }
                return specialDeletedDate;
            }
            return string.Empty;
        }

        /// <summary>
        /// 自然数に変換します。
        /// </summary>
        /// <param name="numberText">自然数のテキスト</param>
        /// <returns>数値 ※数値として扱えない場合、<c>0</c>を返します。</returns>
        public static int ConvertNaturalNumberIf(string numberText)
        {
            #region <Guard Phrase>

            if (string.IsNullOrEmpty(numberText)) return 0;

            #endregion // </Guard Phrase>

            int naturalNumber = 0;
            if (int.TryParse(numberText.Trim(), out naturalNumber))
            {
                return naturalNumber;
            }
            return 0;
        }
    }
}
