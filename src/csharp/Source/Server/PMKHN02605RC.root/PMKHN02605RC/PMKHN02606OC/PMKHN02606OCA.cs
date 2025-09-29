using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 商品マスタ印刷  DBRemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 商品マスタ印刷 DBRemoteObject Interfaceです。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br></br>
	/// <br>Update Note: </br>
    /// <br>Update Note: 連番 810 zhouyu </br>
    /// <br>Date       : 2011/08/12 </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IFutabaGoodsPrintDB
	{
        /// <summary>
        /// 掛率マスタLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="paraFutabaGoodsPrintResultWork">検索結果</param>
        /// <param name="paraFutabaGoodsPrintParamWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.11</br>
        [MustCustomSerialization]
		int Search(
             [CustomSerializationMethodParameterAttribute("PMKHN02607DC", "Broadleaf.Application.Remoting.ParamData.FutabaGoodsPrintResultWork")]
			 out object paraFutabaGoodsPrintResultWork
            ,object paraFutabaGoodsPrintParamWork
            ,ConstantManagement.LogicalMode logicalMode
            );

        //------------------------ADD 2011/08/12---------------------->>>>>
        /// <summary>
        /// 商品管理情報取得処理と仕入先
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="enterpriceCode">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品管理情報取得処理と仕入先</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/08/12</br>
        int SearchGoodsMsgSpler(
            [CustomSerializationMethodParameterAttribute("MAKHN09526D", "Broadleaf.Application.Remoting.ParamData.GoodsMngWork")]
            [CustomSerializationMethodParameterAttribute("PMKHN09026D", "Broadleaf.Application.Remoting.ParamData.SupplierWork")]
            ref object retObj,
            string enterpriceCode,
            int readMode,
            ConstantManagement.LogicalMode logicalMode
           );
        //------------------------ADD 2011/08/12----------------------<<<<<
	}
}
