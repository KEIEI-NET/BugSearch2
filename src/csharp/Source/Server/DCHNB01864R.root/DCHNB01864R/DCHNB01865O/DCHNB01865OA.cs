using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上・仕入制御リモートオブジェクトDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上・仕入制御リモートオブジェクトDBインターフェースです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2008.02.13</br>
    /// <br></br>
    /// <br>UpdateNote : K2011/12/09 鄧潘ハン</br>
    /// <br>管理番号   : 10703874-00</br>
    /// <br>作成内容   : イスコ個別対応</br>
    /// <br>Update Note: </br>
    /// <br></br>
    /// <br>UpdateNote : 2012/11/30 脇田 靖之</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>作成内容   : 売上仕入同時入力で売上伝票を別々で入力し仕入伝票番号を同一で作成し、</br>
    /// <br>　　　　   　作成した売上伝票の片方を伝票削除した場合、仕入伝票が呼び出せなくなる件の修正</br>
    /// <br></br>
    /// <br>Update Note: 2014/05/01 宮本 利明</br>
    /// <br>管理番号   : 11070071-00　仕掛一覧 №2257</br>
    /// <br>             計上を含む貸出データの伝票削除を可能にする</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IIOWriteControlDB
    {
        /// <summary>
        /// エントリ読込
        /// </summary>
        /// <param name="paraList">読込情報オブジェクトリスト</param>
        /// <param name="retList">読込結果オブジェクト</param>
        /// <param name="retRelationList">関連データオブジェクト</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Read([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                 ref object paraList,
                 [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                 out object retList,
                 [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                 out object retRelationList);

        /// <summary>
        /// 複数伝票読込
        /// </summary>
        /// <param name="paraList">読込情報オブジェクトリスト</param>
        /// <param name="retList">読込結果オブジェクト</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int ReadMore([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                 ref object paraList,
                 [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                 out object retList);

        /// <summary>
        /// 明細データ読込
        /// </summary>
        /// <param name="paraList">読込情報オブジェクトリスト</param>
        /// <param name="retList">読込結果オブジェクト</param>
        /// <param name="retSynchroList">関連データオブジェクト</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int ReadDetail([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                       ref object paraList,
                       [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                       out object retList,
                       [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                       out object retSynchroList);

        /// <summary>
        /// エントリ更新
        /// </summary>
        /// <param name="paraList">更新情報オブジェクトリスト</param>
        /// <param name="retMsg">メッセージ</param>
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
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                   ref object paraList,
                   out string retMsg, out string retItemInfo);

        // --- ADD 2012/11/30 Y.Wakita ---------->>>>>
        /// <summary>
        /// エントリ物理削除
        /// </summary>
        /// <param name="paraList">物理削除情報オブジェクトリスト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int DeleteA([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                   ref object paraList,
                   out string retMsg, out string retItemInfo);
        // --- ADD 2012/11/30 Y.Wakita ----------<<<<<

        /// <summary>
        /// 赤伝作成(赤伝作成データを全てパラメータで貰う)
        /// </summary>
        /// <param name="orgList">元黒List</param>
        /// <param name="redList">赤伝List</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int RedWrite([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                     ref object orgList,
                     [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                     ref object redList,
                     out string retMsg, out string retItemInfo);

        // ----- ADD K2011/08/12 --------------------------->>>>>
        /// <summary>
        /// サーバーシステム日付取得を戻します		
        /// </summary>
        /// <returns>DateTime.now</returns>
        /// <br>Note        : サーバーシステム日付取得を戻します	</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : K2011/12/09</br>
        /// <br>管理番号    : 10703874-00 イスコ個別対応</br>
        DateTime GetServerNowTime();
        // ----- ADD K2011/08/12 ---------------------------<<<<<

        // --- ADD 2014/05/01 T.Miyamoto 仕掛一覧№2257 ------------------------------>>>>>
        /// <summary>
        /// 返品存在チェック
        /// </summary>
        /// <param name="paraList">売上明細データリスト</param>
        /// <returns>STATUS</returns>
        //[MustCustomSerialization]
        bool CheckReturnData(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            object paraList);
        // --- ADD 2014/05/01 T.Miyamoto 仕掛一覧№2257 ------------------------------<<<<<

# if DEBUG
        int ShLock(
            ref object param, int timeout, int retry, int interval);
# endif
    }
}
