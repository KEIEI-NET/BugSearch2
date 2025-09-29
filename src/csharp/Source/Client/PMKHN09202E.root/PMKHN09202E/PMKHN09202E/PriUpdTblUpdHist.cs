using System;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 価格改正更新履歴のレコードクラス
    /// </summary>
    public partial class PriUpdTblUpdHist
    {
        /// <summary>
        /// 更新データ区分の列挙体
        /// </summary>
        public enum UpdateDataDivValue : int
        {
            /// <summary>0:UI</summary>
            UI = 0,
            /// <summary>1:自動</summary>
            Auto = 1
        }
    }
}
