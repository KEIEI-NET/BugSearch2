using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上年間実績DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上年間実績DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2007.10.26</br>
    /// <br></br>
    /// <br>Update Note: 2010/08/02 徐後継  テキスト出力対応</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalesAnnualDataSelectResultDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 売上年間実績を全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWork">検索結果</param>
        /// <param name="salesAnnualDataSelectParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.10.26</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCHNB04196D", "Broadleaf.Application.Remoting.ParamData.SalesAnnualDataSelectResultWork")]
			out object salesAnnualDataSelectResultWork,
           object salesAnnualDataSelectParamWork);

        /// <summary>
        /// 指定された条件の残高照会データを戻します
        /// </summary>
        /// <param name="custsalesAnnualDataSelectResultWorkk">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の残高照会データを戻します</br>
        /// <br>Programmer : 畠中 啓次朗</br>
        /// <br>Date       : 2008.09.22</br>
        [MustCustomSerialization]
        int CustSearch(
            [CustomSerializationMethodParameterAttribute("DCHNB04196D", "Broadleaf.Application.Remoting.ParamData.CustSalesAnnualDataSelectResultWork")]
            out object custsalesAnnualDataSelectResultWork,
          object salesAnnualDataSelectParamWork);

        // --- ADD 2010/08/02 -------------------------------->>>>>
        /// <summary>
        /// 売上年間実績を全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retListObj">検索結果</param>
        /// <param name="paraList">検索パラメータリスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/08/02</br>
        int SearchAll(
			out object retListObj, object paraList);
        // --- ADD 2010/08/02 --------------------------------<<<<<

        #endregion
    }
}
