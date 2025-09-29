//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   仕入先マスタ（総括設定）DBインターフェース
//                  :   PMKAK09005O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   FSI斎藤 和宏
// Date             :   2012/08/29
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入先マスタ（総括設定）DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先マスタ（総括設定）DBインターフェースです。</br>
    /// <br>Programmer : FSI斎藤 和宏</br>
    /// <br>Date       : 2012/08/29</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISumSuppStDB
    {
        /// <summary>
        /// 仕入先マスタ（総括設定）情報を物理削除します
        /// </summary>
        /// <param name="sumSuppStList">物理削除する仕入先マスタ（総括設定）情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタ（総括設定）のキー値が一致する仕入先マスタ（総括設定）情報を物理削除します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKAK09006D", "Broadleaf.Application.Remoting.ParamData.SumSuppStWork")]
            object sumSuppStList);

        /// <summary>
        /// 仕入先マスタ（総括設定）情報のリストを取得します。
        /// </summary>
        /// <param name="sumSuppStList">検索結果</param>
        /// <param name="sumSuppStObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタ（総括設定）のキー値が一致する、全ての仕入先マスタ（総括設定）情報を取得します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKAK09006D", "Broadleaf.Application.Remoting.ParamData.SumSuppStWork")]
            ref object sumSuppStList,
            object sumSuppStObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 仕入先マスタ（総括設定）情報を追加・更新します。
        /// </summary>
        /// <param name="sumSuppStList">追加・更新する仕入先マスタ（総括設定）情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList に格納されている仕入先マスタ（総括設定）情報を追加・更新します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKAK09006D", "Broadleaf.Application.Remoting.ParamData.SumSuppStWork")]
            ref object sumSuppStList);

        /// <summary>
        /// 仕入先マスタ（総括設定）情報を論理削除します。
        /// </summary>
        /// <param name="sumSuppStList">論理削除する仕入先マスタ（総括設定）情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStWork に格納されている仕入先マスタ（総括設定）情報を論理削除します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKAK09006D", "Broadleaf.Application.Remoting.ParamData.SumSuppStWork")]
            ref object sumSuppStList);

        /// <summary>
        /// 仕入先マスタ（総括設定）情報の論理削除を解除します。
        /// </summary>
        /// <param name="sumSuppStList">論理削除を解除する仕入先マスタ（総括設定）情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStWork に格納されている仕入先マスタ（総括設定）情報の論理削除を解除します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKAK09006D", "Broadleaf.Application.Remoting.ParamData.SumSuppStWork")]
            ref object sumSuppStList);
    }
}
