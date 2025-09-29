using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入履歴照会DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入履歴照会DBインターフェースです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.09.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStcHisRefDataDB
    {
        /// <summary>
        /// 仕入履歴照会LISTを全て戻します(論理削除除く)
        /// </summary>
        /// <param name="stchisrefDataWork">検索結果</param>
        /// <param name="paramstchisrefExtraWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.21</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCKOU04116D", "Broadleaf.Application.Remoting.ParamData.StcHisRefDataWork")]
            out object stchisrefDataWork, object paramstchisrefExtraWork);
    }
}
