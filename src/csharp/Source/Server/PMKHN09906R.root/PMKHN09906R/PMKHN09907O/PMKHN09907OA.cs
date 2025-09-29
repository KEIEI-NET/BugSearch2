//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：掛率一括登録・修正Ⅱ
// プログラム概要   ：掛率マスタの登録・修正をを一括で行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：caohh
// 修正日    2013/02/19     修正内容：新規作成
// ---------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 掛率一括登録・修正ⅡDBRemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率一括登録・修正ⅡDBRemoteObject Interfaceです。</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2013/02/19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // アプリケーションの接続先を属性で指定
    public interface IRate2DB
    {
        /// <summary>
        /// 掛率マスタ情報を登録、更新します
        /// </summary>
        /// <param name="Rate2Work">RateMtWorkオブジェクト</param>
        /// <param name="eFlag">新追加行フラグ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率マスタ情報を登録、更新します</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09908D", "Broadleaf.Application.Remoting.ParamData.Rate2Work")]
			ref object Rate2Work,
            bool eFlag
            );

        /// <summary>
        /// 掛率マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">RateMtWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率マスタ情報を物理削除します</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        int DeleteRate(byte[] parabyte);

        /// <summary>
        /// 純正データの掛率一括検索処理
        /// </summary>
        /// <param name="retGoodsMngList">商品管理情報リスト</param>
        /// <param name="retRateList">掛率情報リスト</param>
        /// <param name="paraObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>ステータス</returns>
        /// <br>Date       : 2013/03/01</br>
        [MustCustomSerialization]
        int SearchPureRate(
            [CustomSerializationMethodParameterAttribute("PMKHN09908D", "Broadleaf.Application.Remoting.ParamData.Rate2SearchResultWork")]
			out object retGoodsMngList,
            [CustomSerializationMethodParameterAttribute("PMKHN09908D", "Broadleaf.Application.Remoting.ParamData.Rate2Work")]
            out object retRateList,
            object paraObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 優良データの掛率一括検索処理
        /// </summary>
        /// <param name="retPrmSettingList">優良設定情報リスト</param>
        /// <param name="retGoodsMngList">商品管理情報リスト</param>
        /// <param name="retRateList">掛率情報リスト</param>
        /// <param name="paraObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>ステータス</returns>
        /// <br>Date       : 2013/03/01</br>
        [MustCustomSerialization]
        int SearchPrmRate(
            [CustomSerializationMethodParameterAttribute("PMKHN09908D", "Broadleaf.Application.Remoting.ParamData.Rate2SearchResultWork")]
			out object retPrmSettingList,
            [CustomSerializationMethodParameterAttribute("PMKHN09908D", "Broadleaf.Application.Remoting.ParamData.Rate2SearchResultWork")]
			out object retGoodsMngList,
            [CustomSerializationMethodParameterAttribute("PMKHN09908D", "Broadleaf.Application.Remoting.ParamData.Rate2Work")]
            out object retRateList,
            object paraObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 単一商品情報の掛率検索処理
        /// </summary>
        /// <param name="retRateList">掛率情報リスト</param>
        /// <param name="paraObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>ステータス</returns>
        /// <br>Date       : 2013/04/03</br>
        [MustCustomSerialization]
        int SearchRate(
            [CustomSerializationMethodParameterAttribute("PMKHN09908D", "Broadleaf.Application.Remoting.ParamData.Rate2Work")]
            out object retRateList,
            object paraObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);
    }
}
