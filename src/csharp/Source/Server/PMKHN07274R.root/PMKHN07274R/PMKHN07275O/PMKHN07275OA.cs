//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品管理情報マスタ
// プログラム概要   : 商品管理情報マスタのエクスポートを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 朱宝軍
// 作 成 日  2012/06/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{

	/// <summary>
    /// 商品管理情報DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 商品管理情報DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 朱宝軍</br>
	/// <br>Date       : 2012/06/05</br>
	/// <br></br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsMngExportDB
	{
		/// <summary>
        /// 商品管理情報LISTを全て戻します（論理削除除く）
		/// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
        /// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 朱宝軍</br>
		/// <br>Date       : 2012/06/05</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchGoodsMng(
            [CustomSerializationMethodParameterAttribute("MAKHN09526D", "Broadleaf.Application.Remoting.ParamData.GoodsMngWork")]
			out object retObj,
            object paraObj,
            ConstantManagement.LogicalMode logicalMode);
	}
}
