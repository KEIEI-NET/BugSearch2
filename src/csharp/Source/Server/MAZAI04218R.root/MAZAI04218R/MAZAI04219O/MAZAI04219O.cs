using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    ///部品棚卸検索リモートオブジェクトインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部品棚卸検索検索リモートオブジェクトインターフェースです。</br>
    /// <br>Programmer : 22035 三橋 弘憲</br>
    /// <br>Date       : 2007.04.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IInventInputSearchDB
    {
        /// <summary>
        /// 部品棚卸検索結果クラスLISTを全て戻します
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.06</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retobj,
            object paraobj,
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);

        // --- ADD yangyi 2013/10/09 for Redmine#31106 ------->>>>>>>>>>>
        //棚卸検索(過不足專用)
        [MustCustomSerialization]
        int SearchInvent(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retobj,
            object paraobj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode,
            out object retobject);
        // --- ADD yangyi 2013/10/09 for Redmine#31106 -------<<<<<<<<<<<

        /// <summary>
        /// 部品棚卸検索結果クラスLISTを全て戻します
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.06</br>
        [MustCustomSerialization]
        int SearchPrint(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retobj,
            object paraobj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 部品棚卸検索結果の件数のみ返します
        /// </summary>
        /// <param name="count">検索件数</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.06</br>
        int SearchCount(out int count, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode);
    }
}
