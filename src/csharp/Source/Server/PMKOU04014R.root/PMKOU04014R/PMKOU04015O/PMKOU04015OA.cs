using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 仕入先電子元帳 DBRemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 仕入先電子元帳　DBRemoteObjectインターフェースです。</br>
	/// <br>Programmer : 23015 森本 大輝</br>
	/// <br>Date       : 2008.08.18</br>
	/// <br></br>
	/// <br>Update Note: </br>
    //----------------------------------------------------------------------------//
    // 管理番号              作成担当 : FSI千田 晃久
    // 修 正 日  2013/01/21  修正内容 : 仕入返品予定機能対応
    //----------------------------------------------------------------------------//
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISuppPrtPprWorkDB
	{
        /// <summary>
        /// 仕入先電子元帳 残高照会・伝票表示・明細表示のリストを抽出します
		/// </summary>
        /// <param name="suppPrtPprBlDspRsltWork">検索結果(残高照会)</param>
        /// <param name="suppPrtPprStcTblRsltWork">検索結果(仕入データ)</param>
        /// <param name="suppPrtPprWork">検索パラメータ</param>
        /// <param name="recordCount">検索結果(件数)</param>
        /// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        [MustCustomSerialization]
        int SearchRef(
            [CustomSerializationMethodParameterAttribute("PMKOU04016D", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprBlDspRsltWork")]
            ref object suppPrtPprBlDspRsltWork,
            [CustomSerializationMethodParameterAttribute("PMKOU04016D", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprStcTblRsltWork")]
            ref object suppPrtPprStcTblRsltWork,
            object suppPrtPprWork,
            out Int64 recordCount,
			int readMode,
            ConstantManagement.LogicalMode logicalMode
            );

        /// <summary>
        /// 仕入先電子元帳 残高一覧表示のリストを抽出します
        /// </summary>
        /// <param name="suppPrtPprBlTblRsltWork">検索結果</param>
        /// <param name="suppPrtPprBlnceWork">検索パラメータ</param>
        /// <param name="SrchKndDiv">検索種別 0:支払 1:買掛</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        [MustCustomSerialization]
        int SearchBlTbl(
            [CustomSerializationMethodParameterAttribute("PMKOU04016D", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprBlTblRsltWork")]
			ref object suppPrtPprBlTblRsltWork,
            object suppPrtPprBlnceWork,
            int SrchKndDiv,
            int readMode,
            ConstantManagement.LogicalMode logicalMode
            );

        // ----------ADD 2013/01/21----------->>>>>
        /// <summary>
        /// 仕入返品予定情報表示のリストを抽出します
        /// </summary>
        /// <param name="suppPrtPprStcTblRsltWork">検索結果</param>
        /// <param name="suppPrtPprWork">検索パラメータ</param>
        /// <param name="recordCount">検索結果(件数)</param>
        /// <param name="logicalDelDiv">削除指定区分(0:通常 1:削除分のみ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchRefPurchaseReturnSchedule(
            [CustomSerializationMethodParameterAttribute("PMKOU04016D", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprStcTblRsltWork")]
            ref object suppPrtPprStcTblRsltWork,
            object suppPrtPprWork,
            out Int64 recordCount,
            int logicalDelDiv
            );
        // ----------ADD 2013/01/21-----------<<<<<

    }
}
