using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売掛残高一覧表(総括)DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売掛残高一覧表(総括)DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2009/04/20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISumBillBalanceTableDB
    {

        /// <summary>
        /// 売掛残高一覧表(総括)を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009/04/20</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMHNB02279D", "Broadleaf.Application.Remoting.ParamData.SumRsltInfo_BillBalanceWork")]
            out object retObj,
            object paraObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode
            );

    }
}
