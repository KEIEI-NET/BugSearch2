//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   得意先(掛率グループ)マスタDBインターフェース
//                  :   PMKHN09175O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   23012　畠中 啓次朗
// Date             :   2008.10.07
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先(掛率グループ)マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先(掛率グループ)マスタDBインターフェースです。</br>
    /// <br>Programmer : 23012　畠中 啓次朗</br>
    /// <br>Date       : 2008.10.07</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustRateGroupDB
    {
        /// <summary>
        /// 単一の得意先(掛率グループ)マスタ情報を取得します。
        /// </summary>
        /// <param name="custRateGroupObj">CustRateGroupWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(掛率グループ)マスタのキー値が一致する得意先(掛率グループ)マスタ情報を取得します。</br>
        /// <br>Programmer : 23012　畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09176D", "Broadleaf.Application.Remoting.ParamData.CustRateGroup")]
            ref object custRateGroupObj,
            int readMode);

        /// <summary>
        /// 得意先(掛率グループ)マスタ情報を物理削除します
        /// </summary>
        /// <param name="custRateGroupList">物理削除する得意先(掛率グループ)マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(掛率グループ)マスタのキー値が一致する得意先(掛率グループ)マスタ情報を物理削除します。</br>
        /// <br>Programmer : 23012　畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09176D", "Broadleaf.Application.Remoting.ParamData.CustRateGroupWork")]
            object custRateGroupList);

        /// <summary>
        /// 得意先(掛率グループ)マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="custRateGroupList">検索結果</param>
        /// <param name="custRateGroupObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(掛率グループ)マスタのキー値が一致する、全ての得意先(掛率グループ)マスタ情報を取得します。</br>
        /// <br>Programmer : 23012　畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09176D", "Broadleaf.Application.Remoting.ParamData.CustRateGroupWork")]
            ref object custRateGroupList,
            object custRateGroupObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 得意先(掛率グループ)マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="custRateGroupList">追加・更新する得意先(掛率グループ)マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : custRateGroupList に格納されている得意先(掛率グループ)マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 23012　畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09176D", "Broadleaf.Application.Remoting.ParamData.CustRateGroupWork")]
            ref object custRateGroupList);

        /// <summary>
        /// 得意先(掛率グループ)マスタ情報を論理削除します。
        /// </summary>
        /// <param name="custRateGroupList">論理削除する得意先(掛率グループ)マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : custRateGroupWork に格納されている得意先(掛率グループ)マスタ情報を論理削除します。</br>
        /// <br>Programmer : 23012　畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09176D", "Broadleaf.Application.Remoting.ParamData.CustRateGroupWork")]
            ref object custRateGroupList);

        /// <summary>
        /// 得意先(掛率グループ)マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="custRateGroupList">論理削除を解除する得意先(掛率グループ)マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : custRateGroupWork に格納されている得意先(掛率グループ)マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 23012　畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09176D", "Broadleaf.Application.Remoting.ParamData.CustRateGroupWork")]
            ref object custRateGroupList);
    }
}
