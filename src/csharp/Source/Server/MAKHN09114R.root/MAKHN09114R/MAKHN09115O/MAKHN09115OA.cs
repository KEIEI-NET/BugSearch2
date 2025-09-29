using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// メーカーマスタ(ユーザ)DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : メーカーマスタ(ユーザ)DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 21024　佐々木　健</br>
    /// <br>Date       : 2007.08.13</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // アプリケーションの接続先を属性で指定
    public interface IMakerUDB
    {
        /// <summary>
        /// 指定されたメーカーマスタ(ユーザ)を戻します
        /// </summary>
        /// <param name="parabyte">MakerUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたメーカーマスタ(ユーザ)戻りデータGuidのメーカーマスタ(ユーザ)を戻します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// メーカーマスタ(ユーザ)を物理削除します
        /// </summary>
        /// <param name="parabyte">MakerUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカーマスタ(ユーザ)を物理削除します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// メーカーマスタ(ユーザ)を登録、更新します
        /// </summary>
        /// <param name="paraList">MakerUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカーマスタ(ユーザ)を登録、更新します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        int Write(
            [CustomSerializationMethodParameterAttribute("MAKHN09116D", "Broadleaf.Application.Remoting.ParamData.MakerUWork")]
            ref object paraList
            );

        /// <summary>
        /// メーカーマスタ(ユーザ)LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("MAKHN09116D", "Broadleaf.Application.Remoting.ParamData.MakerUWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// メーカーマスタ(ユーザ)を論理削除します
        /// </summary>
        /// <param name="paraObj">MakerUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカーマスタ(ユーザ)を論理削除します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKHN09116D", "Broadleaf.Application.Remoting.ParamData.MakerUWork")]
			ref object paraObj
            );

        /// <summary>
        /// 論理削除メーカーマスタ(ユーザ)を復活します
        /// </summary>
        /// <param name="paraObj">MakerUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除メーカーマスタ(ユーザ)を復活します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKHN09116D", "Broadleaf.Application.Remoting.ParamData.MakerUWork")]
			ref object paraObj
            );
    }
}
