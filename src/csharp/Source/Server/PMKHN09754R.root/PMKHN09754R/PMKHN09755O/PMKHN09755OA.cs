//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 優先倉庫マスタ
// プログラム概要   : 優先倉庫の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : huangt
// 作 成 日  K2013/09/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 優先倉庫マスタ　DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 優先倉庫マスタ　DBインターフェースです。</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : K2013/09/10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IProtyWarehouseDB
    {
        /// <summary>
        /// 単一の優先倉庫設定情報を取得します
        /// </summary>
        /// <param name="protyWarehouseList">検索結果</param>
        /// <param name="protyWarehouseObj">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優先倉庫設定のキー値が一致する優先倉庫設定情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09756D", "Broadleaf.Application.Remoting.ParamData.ProtyWarehouseWork")]
            ref object protyWarehouseList,
            object protyWarehouseObj,
            ConstantManagement.LogicalMode logicalMode
            );

        /// <summary>
        /// 単一の優先倉庫設定情報を取得します(売伝からの指示書印刷制御の際に使用)
        /// </summary>
        /// <param name="protyWarehouseList">検索結果</param>
        /// <param name="protyWarehouseObj">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優先倉庫設定のキー値が一致する優先倉庫設定情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        int ReadWithWarehouse(
            [CustomSerializationMethodParameterAttribute("PMKHN09756D", "Broadleaf.Application.Remoting.ParamData.ProtyWarehouseWork")]
            ref object protyWarehouseList,
            object protyWarehouseObj,
            ConstantManagement.LogicalMode logicalMode
            );

        /// <summary>
        /// 優先倉庫設定情報を物理削除します
        /// </summary>
        /// <param name="protyWarehouseList">物理削除する優先倉庫設定情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優先倉庫設定のキー値が一致する優先倉庫設定情報を物理削除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09756D", "Broadleaf.Application.Remoting.ParamData.ProtyWarehouseWork")]
            object protyWarehouseList
            );

        /// <summary>
        /// 優先倉庫設定情報のリストを取得します。
        /// </summary>
        /// <param name="protyWarehouseList">検索結果</param>
        /// <param name="protyWarehouseObj">検索条件</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優先倉庫設定のキー値が一致する、全ての優先倉庫設定情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09756D", "Broadleaf.Application.Remoting.ParamData.ProtyWarehouseWork")]
            ref object protyWarehouseList,
            object protyWarehouseObj
            );

        /// <summary>
        /// 優先倉庫設定情報を追加・更新します。
        /// </summary>
        /// <param name="protyWarehouseList">追加・更新する優先倉庫設定情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : protyWarehouseList に格納されている優先倉庫設定情報を追加・更新します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09756D", "Broadleaf.Application.Remoting.ParamData.ProtyWarehouseWork")]
            ref object protyWarehouseList
            );

        /// <summary>
        /// 優先倉庫設定情報を論理削除します。
        /// </summary>
        /// <param name="protyWarehouseList">論理削除する優先倉庫設定情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ProtyWarehouseWork に格納されている優先倉庫設定情報を論理削除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09756D", "Broadleaf.Application.Remoting.ParamData.ProtyWarehouseWork")]
            ref object protyWarehouseList
            );

        /// <summary>
        /// 優先倉庫設定情報の論理削除を解除します。
        /// </summary>
        /// <param name="protyWarehouseList">論理削除を解除する優先倉庫設定情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ProtyWarehouseWork に格納されている優先倉庫設定情報の論理削除を解除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09756D", "Broadleaf.Application.Remoting.ParamData.ProtyWarehouseWork")]
            ref object protyWarehouseList
            );
    }
}
