using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上データ検索 RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データ検索 RemoteObjectインターフェース</br>
    /// <br>Programmer : 19026　湯山　美樹</br>
    /// <br>Date       : 2007.03.23</br>
    /// <br></br>
    /// <br>Update Note: 980081 山田 明友</br>
    /// <br>Date       : 2007.10.05</br>
    /// <br>             DistributionCore対応</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISearchSalesSlipDB
    {
        /// <summary>
        /// 指定されたパラメータの条件を満たす全ての売上データLISTを戻します
        /// </summary>
        /// <param name="salesSlipSearchResult">検索結果</param>
        /// <param name="salesSlipSearchWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された検索キーの売上データLISTを全て戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.03.23</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("MAHNB04116D", "Broadleaf.Application.Remoting.ParamData.SalesSlipSearchResultWork")]
            out object salesSlipSearchResult,
            object salesSlipSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        #region 未使用の為、削除
        /*
        /// <summary>
        /// 指定されたパラメータの条件を満たす指定件数分の売上データLISTを戻します
        /// </summary>
        /// <param name="salesSlipSearchResult">検索結果</param>
        /// <param name="salesSlipSearchWork">売上検索パラメータ（NextRead時は前回最終レコードキー）</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="readCnt">検索指定件数</param>        
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの条件を満たす指定件数分の売上データLISTを戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.03.23</br>
        [MustCustomSerialization]
        int TopSearch(
            [CustomSerializationMethodParameterAttribute("MAHNB04116D", "Broadleaf.Application.Remoting.ParamData.SalesSlipSearchResultWork")]
            out object salesSlipSearchResult,
            object salesSlipSearchWork, out int retTotalCnt, out bool nextData, int readCnt,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 指定されたパラメータの条件を満たす売上データ件数を戻します
        /// </summary>
        /// <param name="salesSlipSearchWork">検索パラメータ</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの条件を満たす売上データ件数を戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.03.23</br>
        int SearchCount(object salesSlipSearchWork, out int retTotalCnt, int readMode, ConstantManagement.LogicalMode logicalMode);
        */
        #endregion

        /// <summary>
        /// 指定されたパラメータの条件を満たす全ての売上明細データLISTを戻します
        /// </summary>
        /// <param name="salesSlipDetailSearchResult">検索結果</param>
        /// <param name="salesSlipDetailSearchWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された検索キーの売上明細データLISTを全て戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.10.17</br>
        [MustCustomSerialization]
        int SearchDetail(
            [CustomSerializationMethodParameterAttribute("MAHNB04116D", "Broadleaf.Application.Remoting.ParamData.SalesSlipDetailSearchResultWork")]
            out object salesSlipDetailSearchResult,
            object salesSlipDetailSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode);
    }
}
