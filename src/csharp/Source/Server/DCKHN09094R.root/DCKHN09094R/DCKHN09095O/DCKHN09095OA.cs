using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// BLコードマスタ(ユーザ)DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLコードマスタ(ユーザ)DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 22008　長内　数馬</br>
    /// <br>Date       : 2007.08.17</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // アプリケーションの接続先を属性で指定
    public interface IBLGoodsCdUDB
    {
        /// <summary>
        /// 指定されたBLコードマスタ(ユーザ)を戻します
        /// </summary>
        /// <param name="parabyte">BLGoodsCdUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたBLコードマスタ(ユーザ)戻りデータGuidのBLコードマスタ(ユーザ)を戻します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// BLコードマスタ(ユーザ)を物理削除します
        /// </summary>
        /// <param name="parabyte">BLGoodsCdUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードマスタ(ユーザ)を物理削除します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// BLコード情報を登録、更新します
        /// </summary>
        /// <param name="paraList">BLGoodsCdUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコード情報を登録、更新します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09096D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdUWork")]
            ref object paraList
            );

        /// <summary>
        /// BLコードマスタ(ユーザ)LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCKHN09096D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdUWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// BLコードマスタ(ユーザ)を論理削除します
        /// </summary>
        /// <param name="paraObj">BLGoodsCdUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードマスタ(ユーザ)を論理削除します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09096D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdUWork")]
			ref object paraObj
            );

        /// <summary>
        /// 論理削除BLコードマスタ(ユーザ)を復活します
        /// </summary>
        /// <param name="paraObj">BLGoodsCdUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除BLコードマスタ(ユーザ)を復活します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09096D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdUWork")]
			ref object paraObj
            );
    }
}
