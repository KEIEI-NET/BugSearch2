//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   得意先マスタ（総括設定）DBインターフェース
//                  :   PMKHN09246O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.10.14
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
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
    /// 得意先マスタ（総括設定）DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ（総括設定）DBインターフェースです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.10.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISumCustStDB
    {
        /// <summary>
        /// 単一の得意先マスタ（総括設定）情報を取得します。
        /// </summary>
        /// <param name="sumCustStObj">SumCustStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ（総括設定）のキー値が一致する得意先マスタ（総括設定）情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09247D", "Broadleaf.Application.Remoting.ParamData.SumCustStWork")]
            ref object sumCustStObj,
            int readMode);

        /// <summary>
        /// 得意先マスタ（総括設定）情報を物理削除します
        /// </summary>
        /// <param name="sumCustStList">物理削除する得意先マスタ（総括設定）情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ（総括設定）のキー値が一致する得意先マスタ（総括設定）情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09247D", "Broadleaf.Application.Remoting.ParamData.SumCustStWork")]
            object sumCustStList);

        /// <summary>
        /// 得意先マスタ（総括設定）情報のリストを取得します。
        /// </summary>
        /// <param name="sumCustStList">検索結果</param>
        /// <param name="sumCustStObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ（総括設定）のキー値が一致する、全ての得意先マスタ（総括設定）情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09247D", "Broadleaf.Application.Remoting.ParamData.SumCustStWork")]
            ref object sumCustStList,
            object sumCustStObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 得意先マスタ（総括設定）情報を追加・更新します。
        /// </summary>
        /// <param name="sumCustStList">追加・更新する得意先マスタ（総括設定）情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStList に格納されている得意先マスタ（総括設定）情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09247D", "Broadleaf.Application.Remoting.ParamData.SumCustStWork")]
            ref object sumCustStList);

        /// <summary>
        /// 得意先マスタ（総括設定）情報を論理削除します。
        /// </summary>
        /// <param name="sumCustStList">論理削除する得意先マスタ（総括設定）情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStWork に格納されている得意先マスタ（総括設定）情報を論理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09247D", "Broadleaf.Application.Remoting.ParamData.SumCustStWork")]
            ref object sumCustStList);

        /// <summary>
        /// 得意先マスタ（総括設定）情報の論理削除を解除します。
        /// </summary>
        /// <param name="sumCustStList">論理削除を解除する得意先マスタ（総括設定）情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStWork に格納されている得意先マスタ（総括設定）情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09247D","Broadleaf.Application.Remoting.ParamData.SumCustStWork")]
            ref object sumCustStList);
    }
}
