using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 入荷一覧表DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入荷一覧表DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2008.01.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IArrivalListDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 入荷一覧表LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="arrivalListResultWork">検索結果</param>
        /// <param name="arrivalListParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2008.01.31</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCKOU02346D", "Broadleaf.Application.Remoting.ParamData.ArrivalListResultWork")]
			out object arrivalListResultWork,
            object arrivalListParamWork);
        #endregion
    }
}
