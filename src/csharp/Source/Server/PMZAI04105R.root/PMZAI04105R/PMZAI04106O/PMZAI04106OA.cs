using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫実績照会DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫実績照会DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.10.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockHisDspDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 在庫実績照会データを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="stockHistoryDspSearchResultWork">検索結果</param>
        /// <param name="stockHistoryDspSearchParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMZAI04107D", "Broadleaf.Application.Remoting.ParamData.StockHistoryDspSearchResultWork")]
            out object stockHistoryDspSearchResultWork,
            object stockHistoryDspSearchParamWork);

        /// <summary>
        /// 指定された条件の在庫実績照会データを戻します
        /// </summary>
        /// <param name="StockHistoryDspSearchResultWork">検索結果</param>
        /// <param name="StockHistoryDspSearchParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫実績照会データを戻します</br>
        /// <br>Programmer : 王増喜</br>
        /// <br>Date       : 2010/07/20</br>
        [MustCustomSerialization]
        int SearchAll(
            [CustomSerializationMethodParameterAttribute("PMZAI04107D", "Broadleaf.Application.Remoting.ParamData.StockHistoryDspSearchResultWork")]
            out object stockHistoryDspSearchResultWork,
            object stockHistoryDspSearchParamWork);
        #endregion
    }
}
