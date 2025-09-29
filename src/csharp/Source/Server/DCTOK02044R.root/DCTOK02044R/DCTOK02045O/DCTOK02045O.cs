using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 売上仕入対比表(日報月報)DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 売上仕入対比表(日報月報)DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 23012 畠中 啓次朗</br>
	/// <br>Date       : 2008.11.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalStcCompReportResultWorkDB
	{
        
        /// <summary>
        /// 売上仕入対比表(日報月報)のLISTを全て戻します（論理削除除く）
		/// </summary>
        /// <param name="salStcCompReportResultList">検索結果</param>
        /// <param name=" salStcCompReportParamWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
		/// <br>Date       : 2008.11.13</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("DCTOK02046D", "Broadleaf.Application.Remoting.ParamData.SalStcCompReportResultWork")]
			out object salStcCompReportResultList,
            object salStcCompReportParamWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

	}
}
