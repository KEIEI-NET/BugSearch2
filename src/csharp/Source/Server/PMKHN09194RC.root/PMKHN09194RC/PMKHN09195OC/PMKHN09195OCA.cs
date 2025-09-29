//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品（テキスト変換）
// プログラム概要   : 商品マスタテキスト変換  DBRemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10902160-00  作成担当 : 高陽
// 作 成 日  K2013/08/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 商品マスタテキスト変換  DBRemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 商品マスタテキスト変換 DBRemoteObject Interfaceです。</br>
    /// <br>Programmer : 高陽</br>
    /// <br>Date       : K2013/08/08</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsTextExpDB
	{
        /// <summary>
        /// 商品マスタLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="goodsTextExpRetWork">検索結果</param>
        /// <param name="goodsTextExpWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 高陽</br>
        /// <br>Date       : K2013/08/08</br>
        [MustCustomSerialization]
		int Search(
             [CustomSerializationMethodParameterAttribute("PMKHN09196DC", "Broadleaf.Application.Remoting.ParamData.GoodsTextExpRetWork")]
			 out object goodsTextExpRetWork
            ,object goodsTextExpWork
            ,ConstantManagement.LogicalMode logicalMode
            );
	}
}
