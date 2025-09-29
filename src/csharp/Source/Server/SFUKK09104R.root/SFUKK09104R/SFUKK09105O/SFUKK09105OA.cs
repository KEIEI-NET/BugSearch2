//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   請求全体設定マスタDBインターフェース
//                  :   SFUKK09105O.DLL
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
    /// 請求全体設定マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求全体設定マスタDBインターフェースです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.06.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IBillAllStDB
    {
        /// <summary>
        /// 単一の請求全体設定マスタ情報を取得します。
        /// </summary>
        /// <param name="billAllStObj">BillAllStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 請求全体設定マスタのキー値が一致する請求全体設定マスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("SFUKK09106D", "Broadleaf.Application.Remoting.ParamData.BillAllStWork")]
            ref object billAllStObj,
            int readMode);

        /// <summary>
        /// 請求全体設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="billAllStList">物理削除する請求全体設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 請求全体設定マスタのキー値が一致する請求全体設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("SFUKK09106D", "Broadleaf.Application.Remoting.ParamData.BillAllStWork")]
            object billAllStList);

        /// <summary>
        /// 請求全体設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="billAllStList">検索結果</param>
        /// <param name="billAllStObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 請求全体設定マスタのキー値が一致する、全ての請求全体設定マスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFUKK09106D", "Broadleaf.Application.Remoting.ParamData.BillAllStWork")]
            ref object billAllStList,
            object billAllStObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 請求全体設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="billAllStList">追加・更新する請求全体設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStList に格納されている請求全体設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFUKK09106D", "Broadleaf.Application.Remoting.ParamData.BillAllStWork")]
            ref object billAllStList);

        /// <summary>
        /// 請求全体設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="billAllStList">論理削除する請求全体設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStWork に格納されている請求全体設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFUKK09106D", "Broadleaf.Application.Remoting.ParamData.BillAllStWork")]
            ref object billAllStList);

        /// <summary>
        /// 請求全体設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="billAllStList">論理削除を解除する請求全体設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStWork に格納されている請求全体設定マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFUKK09106D", "Broadleaf.Application.Remoting.ParamData.BillAllStWork")]
            ref object billAllStList);
    }
}
