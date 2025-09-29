using System;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{

    /// public class name:   IIOWriteMASIRDB
    /// <summary>
    ///                      仕入エントリ更新リモートオブジェクトInterface
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入エントリ更新リモートオブジェクトInterface</br>
    /// <br>Programmer       :   斉藤　雅明</br>
    /// <br>Date             :   2006/12/25</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IIOWriteMASIRDB
    {
        //--- DEL 2008/06/03 M.Kubota ｰｰｰ>>>
        # region [これらのメソッドをUI側からは直接使用せず、IIOWriteControlDBのメソッドを使用する]
#if false
        /// <summary>
        /// エントリ入力初期処理
        /// </summary>
        /// <param name="paraList">初期処理パラメータオブジェクトリスト</param>
        /// <param name="retList">初期処理結果オブジェクト</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int NewEntry([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]ref object paraList, [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]out object retList);

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
#endif
        #endregion
        //--- DEL 2008/06/03 M.Kubota ---<<<

        # region [発注入力用メソッド]

        /// <summary>
        /// 発注入力用 追加・更新処理
        /// </summary>
        /// <param name="paraList">更新情報オブジェクトリスト</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int WriteforOrderInput([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                  ref object paraList,
                  out string retMsg, out string retItemInfo);

        /// <summary>
        /// 発注入力用 削除処理
        /// </summary>
        /// <param name="paraList">物理削除情報オブジェクトリスト</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int DeleteforOrderInput([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                   ref object paraList,
                   out string retMsg, out string retItemInfo);

        # endregion

        # region [発注書発行用メソッド]

        /// <summary>
        /// 発注書発行用 追加・更新処理
        /// </summary>
        /// <param name="paraList">更新情報オブジェクトリスト</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int WriteforSalesOrderPrint([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                  ref object paraList,
                  out string retMsg, out string retItemInfo);

        /// <summary>
        /// 発注書発行用 削除処理
        /// </summary>
        /// <param name="paraList">物理削除情報オブジェクトリスト</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int DeleteforSalesOrderPrint([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                   ref object paraList,
                   out string retMsg, out string retItemInfo);

        # endregion
    }
}
