using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 見積書印刷制御区分　列挙型
    /// </summary>
    public enum EstFmDivState
    {
        /// <summary>全て</summary>
        All = 0,
        /// <summary>純正のみ</summary>
        Pure = 1,
        /// <summary>優良のみ</summary>
        Prime = 2,
        /// <summary>選択分のみ</summary>
        Selection = 3,
    }
}
