using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入返品伝票(鑑部)DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入返品伝票(鑑部)DBインターフェースです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.09.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStcRetGdsSlipTtlDataDB
    {
        /// <summary>
        /// 仕入返品伝票(鑑部)LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="stcretgdsslipttlDataWork">検索結果</param>
        /// <param name="parastcretgdsslipttlExtraWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.26</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object stcretgdsslipttlDataWork,
            object parastcretgdsslipttlExtraWork);
    }
}
