using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入データ検索 RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入データ検索 RemoteObjectインターフェース</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.02.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISearchStockSlipDB
    {
        /// <summary>
        /// 指定されたパラメータの条件を満たす全ての仕入データLISTを戻します
        /// </summary>
        /// <param name="searchParaStockSlip">検索パラメータ</param>
        /// <param name="retStockSlipWork">検索結果仕入データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された検索キーの仕入データLISTを全て戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object searchParaStockSlip,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retStockSlipWork);

        /// <summary>
        /// 指定されたパラメータの条件を満たす指定件数分の仕入データLISTを戻します
        /// </summary>
        /// <param name="searchParaStockSlip">仕入検索パラメータ（NextRead時は前回最終レコードキー）</param>
        /// <param name="retStockSlipWork">検索結果仕入データ</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="readCnt">検索指定件数</param>		
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        [MustCustomSerialization]
        int SearchSpecificationPara([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]ref object searchParaStockSlip, [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]out object retStockSlipWork, out int retTotalCnt, out bool nextData, int readCnt);

        /// <summary>
        /// 指定されたパラメータの条件を満たす仕入データLIST件数を戻します
        /// </summary>
        /// <param name="searchParaStockSlip">検索パラメータ</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された検索キーの仕入データLISTを全て戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        [MustCustomSerialization]
        int SearchCntPara([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]ref object searchParaStockSlip, out int retTotalCnt);

        /// <summary>
        /// 指定された企業コードの仕入データLISTを全て戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="retStockSlipWork">検索結果仕入データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入データLISTを全て戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        [MustCustomSerialization]
        int SearchEnterprise(string enterpriseCode, [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]out object retStockSlipWork);

        /// <summary>
        /// 指定された企業コードの指定件数分の仕入データLISTを戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="retStockSlipWork">検索結果仕入データ</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="readCnt">検索指定件数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入データLISTを全て戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        [MustCustomSerialization]
        int SearchSpecificationEnterprise(string enterpriseCode, [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]out object retStockSlipWork, out int retTotalCnt, out bool nextData, int readCnt);

        /// <summary>
        /// 指定された企業コードの仕入データLIST件数を戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="retCnt">該当データ件数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        int SearchCntEnterprise(string enterpriseCode, out int retCnt);
    }
}
