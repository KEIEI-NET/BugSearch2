using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 部門マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部門マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 96050  横川　昌令</br>
    /// <br>Date       : 2007.08.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // アプリケーションの接続先を属性で指定
    public interface ISubSectionDB
    {
        /// <summary>
        /// 指定された部門マスタを戻します
        /// </summary>
        /// <param name="parabyte">SubSectionWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された部門マスタ戻りデータGuidの部門マスタを戻します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.10</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// 指定された部門マスタを戻します
        /// </summary>
        /// <param name="paraobj">SubSectionWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された部門マスタ戻りデータGuidの部門マスタを戻します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.10</br>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("DCKHN09016D", "Broadleaf.Application.Remoting.ParamData.SubSectionWork")]
            ref object paraobj, int readMode);

        /// <summary>
        /// 部門マスタ情報を登録、更新します
        /// </summary>
        /// <param name="SubSectionWork">SubSectionWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部門マスタ情報を登録、更新します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.10</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09016D", "Broadleaf.Application.Remoting.ParamData.SubSectionWork")]
			ref object SubSectionWork
            );


        /// <summary>
        /// 部門マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">SubSectionWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部門マスタ情報を物理削除します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.10</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// 部門マスタ情報を物理削除します
        /// </summary>
        /// <param name="paraobj">SubSectionWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部門マスタ情報を物理削除します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.10</br>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("DCKHN09016D", "Broadleaf.Application.Remoting.ParamData.SubSectionWork")]
            object paraobj);

        /// <summary>
        /// 部門マスタデータLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCKHN09016D", "Broadleaf.Application.Remoting.ParamData.SubSectionWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 部門マスタを論理削除します
        /// </summary>
        /// <param name="paraObj">SubSectionWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部門マスタを論理削除します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.10</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09016D", "Broadleaf.Application.Remoting.ParamData.SubSectionWork")]
			ref object paraObj
            );

        /// <summary>
        /// 論理削除部門マスタを復活します
        /// </summary>
        /// <param name="paraObj">SubSectionWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除部門マスタを復活します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.10</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09016D", "Broadleaf.Application.Remoting.ParamData.SubSectionWork")]
			ref object paraObj
            );
    }
}
