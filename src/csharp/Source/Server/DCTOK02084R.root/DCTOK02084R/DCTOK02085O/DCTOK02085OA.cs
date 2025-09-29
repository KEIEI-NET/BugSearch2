using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入推移表DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入推移表DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 山田 明友</br>
    /// <br>Date       : 2007.11.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockTransListResultDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 仕入推移表データを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="stockTransListResultWork">検索結果</param>
        /// <param name="stockTransListCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 山田 明友</br>
        /// <br>Date       : 2007.11.30</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCTOK02086D", "Broadleaf.Application.Remoting.ParamData.StockTransListResultWork")]
			out object stockTransListResultWork,
            object stockTransListCndtnWork);
        #endregion
    }
}
