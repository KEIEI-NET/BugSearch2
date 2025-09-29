using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 掛率設定マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率設定マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 96050  横川　昌令</br>
    /// <br>Date       : 2007.10.16</br>
    /// <br>Update Note: PM-TAB対応の追加</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : 2013/06/13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // アプリケーションの接続先を属性で指定
    public interface IRateDB
    {
        /// <summary>
        /// 指定された掛率設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">RateWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタを戻します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// 掛率設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="RateWork">RateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
			ref object RateWork
            );


        /// <summary>
        /// 掛率設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">RateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// 掛率設定マスタデータLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        //　--- ADD hunagt 2013/06/13 PM-TAB対応 ---------- >>>>>
        /// <summary>
        /// 掛率設定マスタデータLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/06/13</br>
        [MustCustomSerialization]
        int SearchForTablet(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);
        //　--- ADD hunagt 2013/06/13 PM-TAB対応 ---------- <<<<<

        /// <summary>
        /// 掛率設定マスタを論理削除します
        /// </summary>
        /// <param name="paraObj">RateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタを論理削除します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
			ref object paraObj
            );

        /// <summary>
        /// 論理削除掛率設定マスタを復活します
        /// </summary>
        /// <param name="paraObj">RateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除掛率設定マスタを復活します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
			ref object paraObj
            );

        /// <summary>
        /// 掛率設定マスタデータLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        [MustCustomSerialization]
        int SearchRate(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateSearchResultWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 掛率設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">RateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        int DeleteRate(byte[] parabyte);

    }
}
