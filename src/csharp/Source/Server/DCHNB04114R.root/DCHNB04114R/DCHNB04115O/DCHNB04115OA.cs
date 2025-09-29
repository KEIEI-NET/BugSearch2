using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上履歴照会DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上履歴照会DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2007.10.04</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalHisRefDB
    {
        /// <summary>
        /// 指定されたパラメータの条件を満たす全ての売上履歴照会LISTを戻します
        /// </summary>
        /// <param name="salHisRefResultParam">検索結果</param>
        /// <param name="salHisRefExtraParamWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された検索キーのLISTを全て戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.10.04</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCHNB04116D", "Broadleaf.Application.Remoting.ParamData.SalHisRefResultParamWork")]
            out object salHisRefResultParam,
            object salHisRefExtraParamWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        #region 指定件数読み込み未使用の為、削除
        /*
        /// <summary>
        /// 指定されたパラメータの条件を満たす指定件数分の売上履歴照会LISTを戻します
        /// </summary>
        /// <param name="salHisRefResultParam">検索結果</param>
        /// <param name="salHisRefExtraParamWork">売上検索パラメータ（NextRead時は前回最終レコードキー）</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="readCnt">検索指定件数</param>        
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの条件を満たす指定件数分の売上データLISTを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.10.04</br>
        [MustCustomSerialization]
        int TopSearch(
            [CustomSerializationMethodParameterAttribute("DCHNB04116D", "Broadleaf.Application.Remoting.ParamData.SalHisRefResultParamWork")]
            out object salHisRefResultParam,
            object salHisRefExtraParamWork, out int retTotalCnt, out bool nextData, int readCnt,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 指定されたパラメータの条件を満たす売上履歴照会件数を戻します
        /// </summary>
        /// <param name="salHisRefExtraParamWork">検索パラメータ</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの条件を満たす売上データ件数を戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.10.04</br>
        int SearchCount(object salHisRefExtraParamWork, out int retTotalCnt, int readMode, ConstantManagement.LogicalMode logicalMode);
        */
        #endregion
    }
}
