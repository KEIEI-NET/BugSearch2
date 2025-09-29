using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 商品マスタエクスポート  DBRemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 商品マスタエクスポート DBRemoteObject Interfaceです。</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date       : 2010/05/12</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsExportDB
	{
        /// <summary>
        /// 掛率マスタLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="paraGoodsPrintResultWork">検索結果</param>
        /// <param name="paraGoodsPrintParamWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30517 夏野 駿希</br>
        /// <br>Date       : 2010/05/12</br>
        [MustCustomSerialization]
		int Search(
             [CustomSerializationMethodParameterAttribute("PMKHN07166D", "Broadleaf.Application.Remoting.ParamData.GoodsExportResultWork")]
			 out object paraGoodsExportResultWork
            ,object paraGoodsExportParamWork
            ,ConstantManagement.LogicalMode logicalMode
            );
	}
}
