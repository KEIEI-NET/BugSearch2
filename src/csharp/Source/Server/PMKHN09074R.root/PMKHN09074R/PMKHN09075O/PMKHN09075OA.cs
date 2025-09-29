//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   商品中分類マスタDBインターフェース
//                  :   PMKHN09075O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.06.05
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
    /// 商品中分類マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品中分類マスタDBインターフェースです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.06.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsGroupUDB
    {
        /// <summary>
        /// 単一の商品中分類マスタ情報を取得します。
        /// </summary>
        /// <param name="goodsGroupUObj">GoodsGroupUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品中分類マスタのキー値が一致する商品中分類マスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09076D", "Broadleaf.Application.Remoting.ParamData.GoodsGroupUWork")]
            ref object goodsGroupUObj,
            int readMode);

        /// <summary>
        /// 商品中分類マスタ情報を物理削除します
        /// </summary>
        /// <param name="goodsGroupUList">物理削除する商品中分類マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品中分類マスタのキー値が一致する商品中分類マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09076D", "Broadleaf.Application.Remoting.ParamData.GoodsGroupUWork")]
            object goodsGroupUList);

        /// <summary>
        /// 商品中分類マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="goodsGroupUList">検索結果</param>
        /// <param name="goodsGroupUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品中分類マスタのキー値が一致する、全ての商品中分類マスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09076D", "Broadleaf.Application.Remoting.ParamData.GoodsGroupUWork")]
            ref object goodsGroupUList,
            object goodsGroupUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 商品中分類マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="goodsGroupUList">追加・更新する商品中分類マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : goodsGroupUList に格納されている商品中分類マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09076D", "Broadleaf.Application.Remoting.ParamData.GoodsGroupUWork")]
            ref object goodsGroupUList);

        /// <summary>
        /// 商品中分類マスタ情報を論理削除します。
        /// </summary>
        /// <param name="goodsGroupUList">論理削除する商品中分類マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : goodsGroupUWork に格納されている商品中分類マスタ情報を論理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09076D", "Broadleaf.Application.Remoting.ParamData.GoodsGroupUWork")]
            ref object goodsGroupUList);

        /// <summary>
        /// 商品中分類マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="goodsGroupUList">論理削除を解除する商品中分類マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : goodsGroupUWork に格納されている商品中分類マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09076D", "Broadleaf.Application.Remoting.ParamData.GoodsGroupUWork")]
            ref object goodsGroupUList);
    }
}
