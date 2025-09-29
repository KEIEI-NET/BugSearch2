using System;

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// 拠点マスタDBのデータセット
    /// </summary>
    partial class SectionInfoDataSet
    {
        /// <summary>
        /// 拠点マスタデータテーブルのカラムインデックス列挙体
        /// </summary>
        /// <remarks>
        /// ①カラム名を変更した場合、列挙値名も変更すること（カラム名と列挙値名を同じにする）。<br/>
        /// ②カラム順を変更した場合、列挙値の定義位置も変更すること（定義位置がインデックスを表す）。
        /// </remarks>
        public enum ClmIdx : int
        {
            /// <summary>拠点コード</summary>
            SectionCode,
            /// <summary>拠点名称</summary>
            SectionGuideNm
        }
    }
}
