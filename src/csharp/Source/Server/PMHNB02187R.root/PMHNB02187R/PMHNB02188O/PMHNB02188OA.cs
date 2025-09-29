using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先別取引分布表DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先別取引分布表DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 23012 畠中　啓次朗</br>
    /// <br>Date       : 2008.11.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustSalesDistributionReportResultDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 得意先別取引分布表データを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="CustSalesDistributionReportResult">検索結果</param>
        /// <param name="custSalesDistributionReportParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23012 畠中　啓次朗</br>
        /// <br>Date       : 2008.11.21</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMHNB02189D", "Broadleaf.Application.Remoting.ParamData.CustSalesDistributionReportResultWork")]
			out object custSalesDistributionReportResultWork,
            object custSalesDistributionReportParamWork);
        #endregion
    }
}
