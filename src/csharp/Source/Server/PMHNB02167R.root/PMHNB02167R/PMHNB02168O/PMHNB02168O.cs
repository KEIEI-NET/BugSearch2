using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 売上内容分析表DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 売上内容分析表DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 23012 畠中 啓次朗</br>
	/// <br>Date       : 2008.11.05</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalesHistAnalyzeResultWorkDB
	{
        
        /// <summary>
        /// 売上内容分析表のLISTを全て戻します（論理削除除く）
		/// </summary>
        /// <param name="salesHistAnalyzeResultList">検索結果</param>
        /// <param name=" salesHistAnalyzeCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
		/// <br>Date       : 2008.11.05</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMHNB02169D", "Broadleaf.Application.Remoting.ParamData.SalesHistAnalyzeResultWork")]
			out object salesHistAnalyzeResultList,
            object salesHistAnalyzeCndtnWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

	}
}
