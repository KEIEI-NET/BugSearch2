//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫移動電子元帳
// プログラム概要   : 在庫移動電子元帳 DBRemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 作 成 日  2011/04/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 在庫移動電子元帳 DBRemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 在庫移動電子元帳　DBRemoteObjectインターフェースです。</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br></br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockMoveWorkDB
	{
        /// <summary>
        /// 在庫移動電子元帳明細表示のリストを抽出します
		/// </summary>
        /// <param name="stockMoveWork">検索結果(売上データ)</param>
        /// <param name="stockMovePrtWork">検索パラメータ</param>
        /// <param name="recordCount">検索結果(件数)</param>
        /// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        [MustCustomSerialization]
        int SearchRef(
           [CustomSerializationMethodParameterAttribute("PMZAI04616D", "Broadleaf.Application.Remoting.ParamData.StockMoveWork")]
            ref object stockMoveWork,
           object stockMovePrtWork,
            out Int64 recordCount,
			int readMode,
            ConstantManagement.LogicalMode logicalMode
            );
	}
}
