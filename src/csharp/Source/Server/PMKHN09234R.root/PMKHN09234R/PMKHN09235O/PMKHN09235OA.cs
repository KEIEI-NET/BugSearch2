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
    /// BLコードガイドマスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLコードガイドマスタDBインターフェースです。</br>
    /// <br>Programmer : 23015　森本 大輝</br>
    /// <br>Date       : 2008.09.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IBLCodeGuideDB
    {
        /// <summary>
        /// 単一のBLコードガイドマスタ情報を取得します。
        /// </summary>
        /// <param name="bLCodeGuideObj">BLCodeGuideWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードガイドマスタのキー値が一致するBLコードガイドマスタ情報を取得します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09236D", "Broadleaf.Application.Remoting.ParamData.BLCodeGuideWork")]
            ref object bLCodeGuideObjObj,
            int readMode);

        /// <summary>
        /// BLコードガイドマスタ情報のリストを取得します。
        /// </summary>
        /// <param name="bLCodeGuideObjList">検索結果</param>
        /// <param name="bLCodeGuideObjObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードガイドマスタのキー値が一致する、全てのBLコードガイドマスタ情報を取得します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09236D", "Broadleaf.Application.Remoting.ParamData.BLCodeGuideWork")]
            ref object bLCodeGuideObjList,
            object bLCodeGuideObjObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// BLコードガイドマスタ情報を追加・更新します。
        /// </summary>
        /// <param name="bLCodeGuideObjList">追加・更新するBLコードガイドマスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideObjList に格納されているBLコードガイドマスタ情報を追加・更新します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09236D", "Broadleaf.Application.Remoting.ParamData.BLCodeGuideWork")]
            ref object bLCodeGuideObjList);

        /// <summary>
        /// BLコードガイドマスタ情報を物理削除します
        /// </summary>
        /// <param name="bLCodeGuideObjList">物理削除するBLコードガイドマスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードガイドマスタのキー値が一致するBLコードガイドマスタ情報を物理削除します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09236D", "Broadleaf.Application.Remoting.ParamData.BLCodeGuideWork")]
            object bLCodeGuideObjList);

        /// <summary>
        /// BLコードガイドマスタ情報を論理削除します。
        /// </summary>
        /// <param name="bLCodeGuideObjList">論理削除するBLコードガイドマスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideWork に格納されているBLコードガイドマスタ情報を論理削除します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09236D", "Broadleaf.Application.Remoting.ParamData.BLCodeGuideWork")]
            ref object bLCodeGuideObjList);

        /// <summary>
        /// BLコードガイドマスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="bLCodeGuideObjList">論理削除を解除するBLコードガイドマスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideWork に格納されているBLコードガイドマスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09236D", "Broadleaf.Application.Remoting.ParamData.BLCodeGuideWork")]
            ref object bLCodeGuideObjList);
    }
}
