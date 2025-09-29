//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率設定マスタメン（掛率優先管理パターン）メンテナンス
// プログラム概要   : 掛率設定マスタメン（掛率優先管理パターン）の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/08/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Resources;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 掛率設定マスタメン（掛率優先管理パターン）DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率設定マスタメン（掛率優先管理パターン）DBインターフェースです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2010/08/10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRateProtyMngPatternDB
    {
        /// <summary>
        /// 掛率優先管理マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outRateProtyMngList">検索結果</param>
        /// <param name="paraRateProtyMngWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 検索条件により掛率優先管理マスタ情報のリストを取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        [MustCustomSerialization]
        int Search(out object outRateProtyMngList, object paraRateProtyMngWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 抽出条件によってで掛率掛率マスタとマスタを読み込み処理
        /// </summary>
        /// <param name="newList">新規リスト</param>
        /// <param name="updateList">掛率マスタ(更新リスト)</param>
        /// <param name="paraRateProtyMngPatternWork">rateProtyMngPatternWork</param>
        /// <param name="patternMode">モード(0:BLコード;1:品番指定;2:品番指定;3:品番指定;4:商品掛率G指定;5:商品掛率G指定;6:商品掛率G指定;7:メーカー指定)</param>
        /// <param name="readMode">readMode</param>
        /// <param name="logicalMode">logicalMode</param>
        /// <returns>抽出状態</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件によってで掛率掛率マスタとマスタを読み込みます。 </br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchRateRelationData([CustomSerializationMethodParameterAttribute("PMKHN09484D", "Broadleaf.Application.Remoting.ParamData.RateRlationWork")]
            out object newList, out object updateList, object paraRateProtyMngPatternWork, int patternMode, int readMode, ConstantManagement.LogicalMode logicalMode);


        /// <summary>
        /// 掛率マスタ情報を登録、更新します
        /// </summary>
        /// <param name="updateList">掛率マスタリスト(更新用)</param>
        /// <param name="deleteList">掛率マスタリスト(削除用)</param>
        /// <param name="patternMode">patternMode(0:通常;1:層別)</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタ情報を登録、更新します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        [MustCustomSerialization]
        int WriteRateRelationData(
            ArrayList updateList, ArrayList deleteList, int patternMode,
            out string retMessage);
    }
}
