using System;
using System.Collections;
using Broadleaf.Library.Resources;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// ユーザーマージ処理DBリモートオブジェクトインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : ユーザーマージ処理DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.08</br>
    /// <br></br>
    /// <br>Update Note: 2010/05/24 朱俊成</br>
    /// <br>             PM.NS1009</br>
    /// <br>             価格改正履歴削除</br>
    /// <br>Update Note: 2014/08/21 songg </br>
    /// <br>管理番号   : 11070149-00  PM.NS　PM7相違・要望[第９弾]対応：PM.NS速度改善</br>
    /// <br>           : Redmine#35573 </br>
    /// <br>           : 「提供データ更新」でメモリ違反が発生するため、調査と対策をお願いします（№1923）</br>
    /// <br>Update Note: 2021/07/20 3H 王俊</br>
    /// <br>管理番号   : 11770032-00 先行配信マージ対応</br>
    /// <br>           : 「提供データ更新処理」機能がシリアライズ障害対応</br>
    /// <br>Update Note: 2025/08/11 田村顕成</br>
    /// <br>管理番号   : 12170169-00</br>
    /// <br>           : 提供データの提供日付が未来の日付になっている不具合の救済対応</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IOfferMerge
    {
        /// <summary>
        /// マージ対象のユーザーDBデータを取得する。
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="lstPMaker"></param>
        /// <param name="retList"></param>
        /// <returns></returns>
        /// <br>Update Note : 2021/07/20 3H 王俊</br>
        /// <br>管理番号    : 11770032-00 先行配信マージ対応</br>
        /// <br>            :「提供データ更新処理」機能がシリアライズ障害対応</br>
        [MustCustomSerialization]// ADD 2021/07/20 3H 王俊 「提供データ更新処理」機能がシリアライズ障害対応
        int GetMergeObject(
            MergeObjectCond cond,
            ArrayList lstPMaker,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retList);

        /// <summary>
        /// データを渡し、マージ処理を行う。
        /// </summary>
        /// <param name="updateDataDiv">更新データ区分(0:ＵＩ　1:自動)[履歴記録用]</param>
        /// <param name="offerDate">提供日付[履歴記録用]</param>
        /// <param name="lstData"></param>
        /// <returns></returns>
        int WriteMergeData(
            int updateDataDiv,
            int offerDate,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            object lstData);

        /// <summary>
        /// 価格改正処理
        /// </summary>
        /// <param name="st">価格改正設定</param>
        /// <param name="lst">価格改正処理用データリスト</param>
        /// <param name="retList">処理結果のリスト</param>
        /// <returns></returns>
        int DoPriceRevision(
            PriceMergeSt st, 
            CustomSerializeArrayList lst,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retList
            );

        /// <summary>
        /// 価格改正履歴取得
        /// </summary>
        /// <param name="cond">履歴取得条件</param>
        /// <param name="retList">価格改正履歴データリスト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns></returns>
        /// <br>Update Note : 2021/07/20 3H 王俊</br>
        /// <br>管理番号    : 11770032-00 先行配信マージ対応</br>
        /// <br>            :「提供データ更新処理」機能がシリアライズ障害対応</br>
        [MustCustomSerialization]// ADD 2021/07/20 3H 王俊 「提供データ更新処理」機能がシリアライズ障害対応
        int GetUpdateHistory(
            PriUpdHistCondWork cond,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retList, 
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 価格改正履歴の最新提供日付取得
        /// </summary>
        /// <param name="offerDate">最新提供日付</param>
        /// <returns></returns>
        int GetLastOfferDate(out int offerDate);


        /// <summary>
        /// マージ処理＋価格改正処理
        /// </summary>
        /// <param name="offerDate">最新提供日付</param>
        /// <param name="upDateDiv">更新区分</param>
        /// <param name="st">価格改正設定</param>
        /// <param name="lst">価格改正処理用データリスト</param>
        /// <param name="retList">価格改正処理結果リスト</param>
        /// <param name="lstData">マージ処理リスト</param>
        /// <param name="enterpriseCode">企業コードリスト</param>
        /// <param name="currentVersion">提供バージョン</param>
        /// <param name="PrmSetList">提供優良設定ﾘｽﾄ</param>
        /// <param name="NameChgFlg">優良名称更新ﾌﾗｸﾞ</param>
        /// <param name="allUpdateCount">優良設定更新件数</param>
        /// <param name="partsPsDate">部位マスタ提供日付</param>
        /// <param name="updateMasterObj">画面チェックフラグ</param>
        /// <returns></returns>
        /// <br>Update Note : 2021/07/20 3H 王俊</br>
        /// <br>管理番号    : 11770032-00 先行配信マージ対応</br>
        /// <br>            :「提供データ更新処理」機能がシリアライズ障害対応</br>
        [MustCustomSerialization]// ADD 2021/07/20 3H 王俊 「提供データ更新処理」機能がシリアライズ障害対応
        int WriteManual(int upDateDiv, int offerDate, PriceMergeSt st, CustomSerializeArrayList lst,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retList,
            //[CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]// DEL 2021/07/20 3H 王俊 「提供データ更新処理」機能がシリアライズ障害対応
            object lstData,
            CustomSerializeArrayList PrmSetList,
            string enterpriseCode,
            string currentVersion,
            bool NameChgFlg,
            ref int allUpdateCount,
            object updateMasterObj,
            int partsPsDate);


        /// <summary>
        /// マージチェック
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="MergeResultData">結果</param>
        /// <param name="currentVersion">提供バージョン</param>
        /// <returns></returns>
        int MergeChk(string enterpriseCode,
            out int MergeResultData,
            string currentVersion);



        /// <summary>
        /// 価格改正履歴の最新提供日付取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="LatestList">結果</param>
        /// <returns></returns>
        /// <br>Update Note : 2021/07/20 3H 王俊</br>
        /// <br>管理番号    : 11770032-00 先行配信マージ対応</br>
        /// <br>            :「提供データ更新処理」機能がシリアライズ障害対応</br>
        [MustCustomSerialization]// ADD 2021/07/20 3H 王俊 「提供データ更新処理」機能がシリアライズ障害対応
        int GetLatestHistory(string enterpriseCode,
            //[CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]// DEL 2021/07/20 3H 王俊 「提供データ更新処理」機能がシリアライズ障害対応
            [CustomSerializationMethodParameter("PMKHN09214D", "Broadleaf.Application.Remoting.ParamData.PriUpdTblUpdHisWork")]// ADD 2021/07/20 3H 王俊 「提供データ更新処理」機能がシリアライズ障害対応
            out object LatestList);


        // ADD 2025/08/11 田村顕成 ----->>>>> 
        /// <summary>
        /// 価格改正履歴の全提供日付取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="currentDate">検索用提供データ日付</param>
        /// <param name="tableID">提供データテーブルID</param>
        /// <param name="AllList">結果</param>
        /// <returns></returns>
        [MustCustomSerialization]
        int GetOtherHistories(string enterpriseCode, string currentDate, string tableID,
            [CustomSerializationMethodParameter("PMKHN09214D", "Broadleaf.Application.Remoting.ParamData.PriUpdTblUpdHisWork")]
            out object AllList);
        // ADD 2025/08/11 田村顕成 -----<<<<< 


        // 2010/04/23 >>>
        ///// <summary>
        ///// ユーザー商品連結の最新提供日付取得
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="MakerCd">メーカーコード</param>
        ///// <param name="retList">結果</param>
        ///// <returns></returns>
        //int UsrJoinPartsSearch(string enterpriseCode, int MakerCd,
        //    [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
        //    out ArrayList retList);

        /// <summary>
        /// ユーザー商品検索（商品・価格・優良設定）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="makerCd">メーカーコード</param>
        /// <param name="goodsNoList">検索条件リスト</param>
        /// <param name="retObj">結果</param>
        /// <returns></returns>
        /// <br>Update Note : 2021/07/20 3H 王俊</br>
        /// <br>管理番号    : 11770032-00 先行配信マージ対応</br>
        /// <br>            :「提供データ更新処理」機能がシリアライズ障害対応</br>
        [MustCustomSerialization]// ADD 2021/07/20 3H 王俊 「提供データ更新処理」機能がシリアライズ障害対応
        int UsrPartsSearch(
            string enterpriseCode,
            string sectionCode,
            int makerCd,
            ArrayList goodsNoList, // ADD BY songg 2014/08/21 FOR Redmine#35573 「提供データ更新」でメモリ違反が発生障害対応
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out  object retObj);
        // 2010/04/23 <<<

        // --- ADD 2010/05/24 ---------->>>>>
        /// <summary>
        /// 価格改正履歴削除
        /// </summary>
        /// <param name="historyList">価格改正更新情報を格納する</param>
        /// <remarks>
        /// <br>Note       : 削除処理を追加する</br>
        /// <br>Programmer : 朱俊成</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        int DeleteHistory(ArrayList historyList);
        // --- ADD 2010/05/24 -----------<<<<<

    }
}
