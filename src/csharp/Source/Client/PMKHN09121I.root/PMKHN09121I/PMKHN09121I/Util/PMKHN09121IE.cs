//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限設定UI：操作権限設定マスタ
// プログラム概要   : フォームコントロールに関する共通処理を実装します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

using Broadleaf.Application.Controller.Util;

using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Application.Common.Util
{
    /// <summary>
    /// フォームコントロールのユーティリティ
    /// </summary>
    public static class FormControlUtil
    {
        #region <UltraGrid/>

        /// <summary>
        /// データグリッドのカラムの表示を設定します。
        /// </summary>
        /// <param name="targetGrid">設定するデータグリッド</param>
        /// <param name="columnIndexAndCaptionThatHiddenIsFalseList">表示するカラムのインデックスとキャプションのペアのリスト</param>
        public static void SetDataGridColumnHidden(
            UltraGrid targetGrid,
            IList<Pair<int, string>> columnIndexAndCaptionThatHiddenIsFalseList
        )
        {
            // バンドを取得
            UltraGridBand band = targetGrid.DisplayLayout.Bands[0];

            // 列の表示／非表示
            for (int iClm = 0; iClm < band.Columns.Count; iClm++) band.Columns[iClm].Hidden = true;
            foreach (Pair<int, string> enmIndexAndCaption in columnIndexAndCaptionThatHiddenIsFalseList)
            {
                band.Columns[enmIndexAndCaption.First].Hidden = false;

                if (!enmIndexAndCaption.Second.Equals(string.Empty))
                {
                    band.Columns[enmIndexAndCaption.First].Header.Caption = enmIndexAndCaption.Second;
                }
            }
        }

        /// <summary>
        /// データグリッドのカラムの表示順を設定します。
        /// </summary>
        /// <param name="targetGrid">設定するデータグリッド</param>
        /// <param name="sortedIndexByVisiblePositionList">表示順にソートされたカラムインデックスのリスト</param>
        public static void SetDataGridColumnHeaderVisiblePosition(
            UltraGrid targetGrid,
            IList<Pair<int, string>> sortedIndexByVisiblePositionList
        )
        {
            // バンドを取得
            UltraGridBand band = targetGrid.DisplayLayout.Bands[0];

            for (int i = 0; i < sortedIndexByVisiblePositionList.Count; i++)
            {
                band.Columns[sortedIndexByVisiblePositionList[i].First].Header.VisiblePosition = i;
            }
        }

        #endregion  // <UltraGrid/>
    }
}
