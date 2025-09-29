using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 車両検索メソッド結果値
    /// </summary>
    /// <remarks>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public enum CarSearchResultReport
    {
        /// <summary> 検索結果0件 </summary>
        retFailed = 0,

        /// <summary> 車種複数件検索[次型式検索要り] </summary>
        retMultipleCarKind = 1,

        /// <summary> 型式複数件検索 </summary>
        retMultipleCarModel = 2,

        /// <summary> 型式1件検索 </summary>
        retSingleCarModel = 4,

        /// <summary> 検索中エラー発生 </summary>
        retError = 99
    }

    // --- ADD 2013/03/21 ---------->>>>>
    /// <summary>
    /// 車両検索ハンドル位置情報結果値
    /// </summary>
    /// <remarks>
    /// <br>Note       : 10900269-00 SPK車台番号文字列対応</br>
    /// <br>Programmer : FSI斎藤 和宏</br>
    /// <br>Date       : 2013/03/21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public enum HandleInfoCdRet
    {
        /// <summary> 判断不可 </summary>
        PositionError = -1,
        
        /// <summary> 左右両方(全型式) </summary>
        PositionBoth = 0,

        /// <summary> ハンドル位置 (右) </summary>
        PositionRight = 1,

        /// <summary> ハンドル位置 (左) </summary>
        PositionLeft = 2,
    }
    // --- ADD 2013/03/21 ----------<<<<<
}
