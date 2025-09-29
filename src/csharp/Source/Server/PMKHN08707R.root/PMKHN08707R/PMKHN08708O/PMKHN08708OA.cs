//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーンマスタ印刷
// プログラム概要   : キャンペーンマスタ印刷 DBRemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// キャンペーンマスタ印刷 DBRemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : キャンペーンマスタ印刷　DBRemoteObjectインターフェースです。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br></br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampaignMasterWorkDB
	{
        /// <summary>
        /// 画面の発行タイプが「マスタリスト」の場合は、抽出条件に該当する、データを取得する。
		/// </summary>
        /// <param name="stockMoveWork">検索結果</param>
        /// <param name="stockMovePrtWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 抽出条件に該当する、データを取得する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/26</br>
        [MustCustomSerialization]
        int SearchForMasterType(
           [CustomSerializationMethodParameterAttribute("PMKHN08709D", "Broadleaf.Application.Remoting.ParamData.CampaignMasterWork")]
            ref object stockMoveWork,
           object stockMovePrtWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode
            );

        /// <summary>
        /// 画面の発行タイプが「マスタリスト」以外の場合は、抽出条件に該当する、データを取得する。
        /// </summary>
        /// <param name="stockMoveWork">検索結果</param>
        /// <param name="stockMovePrtWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 抽出条件に該当する、データを取得する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/26</br>
        [MustCustomSerialization]
        int Search(
           [CustomSerializationMethodParameterAttribute("PMKHN08709D", "Broadleaf.Application.Remoting.ParamData.CampaignMasterWork")]
            ref object stockMoveWork,
           object stockMovePrtWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode
            );
	}
}
