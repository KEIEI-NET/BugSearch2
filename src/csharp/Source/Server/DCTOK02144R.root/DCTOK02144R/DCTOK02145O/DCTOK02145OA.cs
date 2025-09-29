using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上推移表DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上推移表DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2007.11.27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalesTransListResultDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 売上推移表データを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="SalesTransListResult">検索結果</param>
        /// <param name="salesTransListCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.27</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCTOK02146D", "Broadleaf.Application.Remoting.ParamData.SalesTransListResultWork")]
			out object salesTransListResultWork,
            object salesTransListCndtnWork);
        #endregion
    }
}
