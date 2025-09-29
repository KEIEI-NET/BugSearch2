//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   CustSlipNoSetDBインターフェース
//                  :   PMKHN09105O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 疋田 勇人
// Date             :   2008.06.16
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
    /// CustSlipNoSetDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : CustSlipNoSetDBインターフェースです。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.06.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustSlipNoSetDB
    {
        /// <summary>
        /// 単一のCustSlipNoSet情報を取得します。
        /// </summary>
        /// <param name="custSlipNoSetObj">CustSlipNoSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetのキー値が一致するCustSlipNoSet情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09106D", "Broadleaf.Application.Remoting.ParamData.CustSlipNoSetWork")]
            ref object custSlipNoSetObj,
            int readMode);

        /// <summary>
        /// CustSlipNoSet情報を物理削除します
        /// </summary>
        /// <param name="custSlipNoSetList">物理削除するCustSlipNoSet情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetのキー値が一致するCustSlipNoSet情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09106D", "Broadleaf.Application.Remoting.ParamData.CustSlipNoSetWork")]
            object custSlipNoSetList);

        /// <summary>
        /// CustSlipNoSet情報のリストを取得します。
        /// </summary>
        /// <param name="custSlipNoSetList">検索結果</param>
        /// <param name="custSlipNoSetObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetのキー値が一致する、全てのCustSlipNoSet情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09106D", "Broadleaf.Application.Remoting.ParamData.CustSlipNoSetWork")]
            ref object custSlipNoSetList,
            object custSlipNoSetObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// CustSlipNoSet情報を追加・更新します。
        /// </summary>
        /// <param name="custSlipNoSetList">追加・更新するCustSlipNoSet情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetList に格納されているCustSlipNoSet情報を追加・更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09106D", "Broadleaf.Application.Remoting.ParamData.CustSlipNoSetWork")]
            ref object custSlipNoSetList);

        /// <summary>
        /// CustSlipNoSet情報を論理削除します。
        /// </summary>
        /// <param name="custSlipNoSetList">論理削除するCustSlipNoSet情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetWork に格納されているCustSlipNoSet情報を論理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09106D", "Broadleaf.Application.Remoting.ParamData.CustSlipNoSetWork")]
            ref object custSlipNoSetList);

        /// <summary>
        /// CustSlipNoSet情報の論理削除を解除します。
        /// </summary>
        /// <param name="custSlipNoSetList">論理削除を解除するCustSlipNoSet情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetWork に格納されているCustSlipNoSet情報の論理削除を解除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09106D","Broadleaf.Application.Remoting.ParamData.CustSlipNoSetWork")]
            ref object custSlipNoSetList);
    }
}
