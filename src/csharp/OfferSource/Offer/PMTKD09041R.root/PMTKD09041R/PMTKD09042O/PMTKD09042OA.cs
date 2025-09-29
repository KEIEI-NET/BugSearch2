using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ＢＬグループマスタ(提供)更新DBリモートオブジェクトインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : ＢＬグループマスタ(提供)更新DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008/06/05</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]

    public interface IBlGroupDB
    {
        /// <summary>
        /// 指定されたBLグループコードのBLグループマスタを戻します
        /// </summary>
        /// <param name="bLGroupDBWork">検索結果[BLGroupWork]</param>
        /// <param name="paraBLGroupCd">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたBLグループコードのBLグループマスタを戻します</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.13</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMTKD09043D", "Broadleaf.Application.Remoting.ParamData.BLGroupWork")]
            out object bLGroupDBWork,
           object paraBLGroupCd);

        /// <summary>
        /// 指定されたBLグループコードのBLグループマスタを戻します
        /// </summary>
        /// <param name="bLGroupDBWork">検索結果[ArrayList]</param>
        /// <param name="paraBLGroupCd">検索パラメータ[0:全件]</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.23</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTKD09043D", "Broadleaf.Application.Remoting.ParamData.BLGroupWork")]
			out object bLGroupDBWork,
            object paraBLGroupCd);
    }

}
