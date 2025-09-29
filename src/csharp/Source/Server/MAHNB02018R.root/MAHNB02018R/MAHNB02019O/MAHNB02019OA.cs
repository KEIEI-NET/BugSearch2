using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{

	/// <summary>
    /// 入金確認表DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 入金確認表DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 22035 三橋 弘憲</br>
	/// <br>Date       : 2007.03.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
    /// <br>           :   2007.11.15  DC.NS 用に改造  横川昌令</br>
    /// <br></br>
    /// <br>Update Note: ＰＭ.Ｎ用に変更 </br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.07.01</br>
        /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IDepsitListWorkDB
	{
		/// <summary>
        /// 入金確認表LISTを全て戻します（論理削除除く）
		/// </summary>
        /// <param name="depsitMainListResultWork">検索結果（入金）</param>
        /// <param name="depsitMainListParamWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.03.06</br>
        [MustCustomSerialization]
		int SearchDepsitOnly(
            [CustomSerializationMethodParameterAttribute("MAHNB02016D", "Broadleaf.Application.Remoting.ParamData.DepsitMainListResultWork")]
			out object depsitMainListResultWork,
            object depsitMainListParamWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

        ///// <summary>
        ///// 入金一覧表LISTを全て戻します（論理削除除く）
        ///// </summary>
        ///// <param name="depsitMainListResultWork">検索結果（入金）</param>
        ///// <param name="depsitAlwcListResultWork">検索結果（引当）</param>
        ///// <param name="depsitMainListParamWork">検索パラメータ</param>
        ///// <param name="readMode">検索区分</param>
        ///// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : </br>
        ///// <br>Programmer : 22035 三橋 弘憲</br>
        ///// <br>Date       : 2007.03.06</br>
        //[MustCustomSerialization]
        //int SearchDepsitAndAllowance(
        //    [CustomSerializationMethodParameterAttribute("MAHNB02016D", "Broadleaf.Application.Remoting.ParamData.DepsitMainListResultWork")]
        //    out object depsitMainListResultWork,
        //    [CustomSerializationMethodParameterAttribute("MAHNB02016D", "Broadleaf.Application.Remoting.ParamData.DepsitAlwcListResultWork")]
        //    out object depsitAlwcListResultWork,
        //    object depsitMainListParamWork,
        //    int readMode,
        //    ConstantManagement.LogicalMode logicalMode);

        ///// <summary>
        ///// 入金確認表LISTを全て戻します（論理削除除く）
        ///// </summary>
        ///// <param name="depsitMainListResultWork">検索結果（入金）</param>
        ///// <param name="depsitMainListParamWork">検索パラメータ</param>
        ///// <param name="sectionDepositDiv">0:金種のみ、1:金種＆拠点コード</param>
        ///// <param name="readMode">検索区分</param>
        ///// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : </br>
        ///// <br>Programmer : 22035 三橋 弘憲</br>
        ///// <br>Date       : 2007.03.06</br>
        //[MustCustomSerialization]
        //int SearchAllTotal(
        //    [CustomSerializationMethodParameterAttribute("MAHNB02016D", "Broadleaf.Application.Remoting.ParamData.DepsitMainListResultWork")]
        //    out object depsitMainListResultWork,
        //    object depsitMainListParamWork,
        //    int sectionDepositDiv,
        //    int readMode,
        //    ConstantManagement.LogicalMode logicalMode);
	}
}
