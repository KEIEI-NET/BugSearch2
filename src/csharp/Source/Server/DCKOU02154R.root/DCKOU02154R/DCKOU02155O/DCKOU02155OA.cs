using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入日計累計表DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入日計累計表DBインターフェースです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.09.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockDayTotalDataDB
    {
        /// <summary>
        /// 仕入日計累計表LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="stockdaytotalDataWork">検索結果</param>
        /// <param name="parastockdaytotalDataWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(0:担当者別,1:担当者・仕入先別)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.13</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCKOU02156D","Broadleaf.Application.Remoting.ParamData.StockDayTotalDataWork")]
            out object stockdaytotalDataWork,
            object parastockdaytotalDataWork,
            int readMode);
    }
}
