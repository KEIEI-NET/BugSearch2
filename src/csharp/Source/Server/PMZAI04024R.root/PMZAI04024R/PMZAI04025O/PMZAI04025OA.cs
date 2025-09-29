using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 在庫組立・分解処理  DBRemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 在庫組立・分解処理 DBRemoteObject Interfaceです。</br>
    /// <br>Programmer : 23015 森本 大輝</br>
    /// <br>Date       : 2008.10.06</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStckAssemOvhulDB
	{
        /// <summary>
        /// 在庫組立・分解処理LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="paraStckAssemOvhulRstWork">検索結果</param>
        /// <param name="paraStckAssemOvhulReqWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.10.06</br>
        [MustCustomSerialization]
		int Search(
             [CustomSerializationMethodParameterAttribute("PMZAI04026D", "Broadleaf.Application.Remoting.ParamData.StckAssemOvhulRstWork")]
			 out object paraStckAssemOvhulRstWork
            ,object paraStckAssemOvhulReqWork
            ,ConstantManagement.LogicalMode logicalMode
            );
	}
}
