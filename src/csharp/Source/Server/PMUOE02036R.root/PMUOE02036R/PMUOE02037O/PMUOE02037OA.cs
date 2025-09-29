using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 発注一覧表DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 発注一覧表DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 22008 長内 数馬</br>
	/// <br>Date       : 2007.10.15</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISendBeforOrdeWorkDB
	{
        
        /// <summary>
        /// 発注一覧表LISTを全て戻します（論理削除除く）
		/// </summary>
        /// <param name="orderListResultWork">検索結果</param>
        /// <param name=" orderListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 22008 長内 数馬</br>
		/// <br>Date       : 2007.10.15</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMUOE02038D", "Broadleaf.Application.Remoting.ParamData.SendBeforResultWork")]
			out object sendBeforResultWork,
           object sendBeforOrderCndtnWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

	}
}
