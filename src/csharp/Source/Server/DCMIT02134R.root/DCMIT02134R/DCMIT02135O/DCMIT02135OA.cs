using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入月報年報DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入月報年報DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2007.11.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockMonthYearReportResultDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 仕入月報年報データを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="stockMonthYearReportResultWork">検索結果</param>
        /// <param name="stockMonthYearReportParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.21</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCMIT02136D", "Broadleaf.Application.Remoting.ParamData.StockMonthYearReportResultWork")]
			out object stockMonthYearReportResultWork,
          object stockMonthYearReportParamWork);
        #endregion
    }
}
