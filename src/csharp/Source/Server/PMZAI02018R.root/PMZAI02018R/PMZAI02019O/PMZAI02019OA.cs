using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 在庫月報年報　DBRemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 在庫月報年報　DBRemoteObjectインターフェースです。</br>
	/// <br>Programmer : 23015 森本 大輝</br>
	/// <br>Date       : 2008.07.17</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockMonthYearReportDataWorkDB
	{
        
        /// <summary>
        /// 在庫月報年報LISTを全て戻します（論理削除除く）
		/// </summary>
        /// <param name="stockMonthYearReportDataWork">検索結果</param>
        /// <param name="stockMonthYearReportWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.17</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMZAI02016D", "Broadleaf.Application.Remoting.ParamData.StockMonthYearReportDataWork")]
			out object stockMonthYearReportDataWork,
            object stockMonthYearReportWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

	}
}
