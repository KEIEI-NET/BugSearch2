using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMTAB全体設定マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB全体設定マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 許培珠</br>
    /// <br>Date       : 2013/05/31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // アプリケーションの接続先を属性で指定
    public interface IPmTabTtlStSecDB
    {
        /// <summary>
        /// PMTAB全体設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="PmTabTtlStSecWork">PmTabTtlStSecWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB全体設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMTAB09106D", "Broadleaf.Application.Remoting.ParamData.PmTabTtlStSecWork")]
			ref object PmTabTtlStSecWork
            );


        /// <summary>
        /// PMTAB全体設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">PmTabTtlStSecWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB全体設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// PMTAB全体設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="paraobj">PmTabTtlStSecWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB全体設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMTAB09106D", "Broadleaf.Application.Remoting.ParamData.PmTabTtlStSecWork")]
            object paraobj);

        /// <summary>
        /// PMTAB全体設定マスタデータLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTAB09106D", "Broadleaf.Application.Remoting.ParamData.PmTabTtlStSecWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PMTAB全体設定マスタを論理削除します
        /// </summary>
        /// <param name="paraObj">PmTabTtlStSecWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB全体設定マスタを論理削除します</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMTAB09106D", "Broadleaf.Application.Remoting.ParamData.PmTabTtlStSecWork")]
			ref object paraObj
            );

        /// <summary>
        /// 論理削除PMTAB全体設定マスタを復活します
        /// </summary>
        /// <param name="paraObj">PmTabTtlStSecWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除PMTAB全体設定マスタを復活します</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMTAB09106D", "Broadleaf.Application.Remoting.ParamData.PmTabTtlStSecWork")]
			ref object paraObj
            );
    }
}
