using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入年間実績DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入年間実績DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 長内 数馬</br>
    /// <br>Date       : 2008.11.20</br>
    /// <br>Update Note: 2012/09/18 FSI今野 利裕</br>
    /// <br>             仕入先総括対応</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISuppYearResultDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 仕入年間実績を全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="suppYearResultAccPayWork">残高照会検索結果クラス</param>
        /// <param name="suppYearResultSuppResultWorkList">実績照会検索結果リスト</param>
        /// <param name="suppYearResultCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 長内 数馬</br>
        /// <br>Date       : 2008.11.20</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKOU04126D", "Broadleaf.Application.Remoting.ParamData.SuppYearResultAccPayWork")]
			out object suppYearResultAccPayWork,
            [CustomSerializationMethodParameterAttribute("PMKOU04126D", "Broadleaf.Application.Remoting.ParamData.SuppYearResultSuppResultWork")]
			out object suppYearResultSuppResultWorkList,
            object suppYearResultCndtnWork);

        // --- ADD 2012/09/18 ---------->>>>>
        #region 仕入先総括
        /// <summary>
        /// 仕入年間実績を全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="suppYearResultAccPayWork">残高照会検索結果クラス</param>
        /// <param name="suppYearResultSuppResultWorkList">実績照会検索結果リスト</param>
        /// <param name="suppYearResultCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI今野 利裕</br>
        /// <br>Date       : 2012/09/18</br>
        [MustCustomSerialization]
        int SearchSuppSum(
            [CustomSerializationMethodParameterAttribute("PMKOU04126D", "Broadleaf.Application.Remoting.ParamData.SuppYearResultAccPayWork")]
			out object suppYearResultAccPayWork,
            [CustomSerializationMethodParameterAttribute("PMKOU04126D", "Broadleaf.Application.Remoting.ParamData.SuppYearResultSuppResultWork")]
			out object suppYearResultSuppResultWorkList,
            object suppYearResultCndtnWork);
        #endregion 仕入先総括
        // --- ADD 2012/09/18 ----------<<<<<

        #endregion

        // --- ADD 2012/11/08 ---------->>>>>
        /// <summary>
        /// 拠点別仕入先買掛金額マスタ締日取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="prevTotalDay">計上年月日</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI今野 利裕</br>
        /// <br>Date       : 2012/11/08</br>
        int SearchMonthlyAccPay(string enterpriseCode, string sectionCode, int supplierCd, out DateTime prevTotalDay);
        // --- ADD 2012/11/08 ----------<<<<<
    }
}
