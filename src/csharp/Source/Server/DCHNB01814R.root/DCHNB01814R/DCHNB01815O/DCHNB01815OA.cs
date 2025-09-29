using System;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{

    /// public class name:   IIOWriteMAHNBDB
    /// <summary>
    ///                      売上エントリ更新リモートオブジェクトInterface
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上エントリ更新リモートオブジェクトInterface</br>
    /// <br>Programmer       :   久保田　誠</br>
    /// <br>Date             :   2007/11/26</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IIOWriteMAHNBDB
    {
        # region [2008/06/06 M.Kubota - DC.NSの時点から使われていないので凍結]
#if false
        /// <summary>
        /// エントリ入力初期処理
        /// </summary>
        /// <param name="paraList">初期処理パラメータオブジェクトリスト</param>
        /// <param name="retList">初期処理結果オブジェクト</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int NewEntry([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]ref object paraList, [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]out object retList);
#endif
        # endregion

        /// <summary>
        /// エントリ読込
        /// </summary>
        /// <param name="paraList">読込情報オブジェクトリスト</param>
        /// <param name="retList">読込結果オブジェクト</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Read([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                 ref object paraList,
                 [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                 out object retList);

        /// <summary>
        /// エントリ更新
        /// </summary>
        /// <param name="paraList">更新情報オブジェクトリスト</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                  ref object paraList,
                  out string retMsg, out string retItemInfo);

        /// <summary>
        /// エントリ更新(受注・売上計上同時登録用)
        /// </summary>
        /// <param name="orderList">受注データ用更新情報オブジェクトリスト</param>
        /// <param name="salesList">売上データ用更新情報オブジェクトリスト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                  ref object orderList,
                  [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]      
                  ref object salesList,
                  out string retMsg, out string retItemInfo);

        /// <summary>
        /// エントリ物理削除
        /// </summary>
        /// <param name="paraList">物理削除情報オブジェクトリスト</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                   ref object paraList,
                   out string retMsg, out string retItemInfo);

        /// <summary>
        /// 赤伝作成(赤伝作成データを全てパラメータで貰う)
        /// </summary>
        /// <param name="originList">元黒List</param>
        /// <param name="redList">赤伝List</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int RedWrite([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                     ref object originList,
                     [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                     ref object redList,
                     out string retMsg, out string retItemInfo);

        /// <summary>
        /// 前回商品単価取得
        /// </summary>
        /// <param name="param"></param>
        /// <param name="value"></param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int GetLastUnitPrice([CustomSerializationMethodParameterAttribute("DCHNB01846D", "Broadleaf.Application.Remoting.ParamData.GetLastUnitPriceParamWork")]
                             ref object param,
                             [CustomSerializationMethodParameterAttribute("DCHNB01846D", "Broadleaf.Application.Remoting.ParamData.SalesHistDtlWork")]
                             out object value);
    }
}
