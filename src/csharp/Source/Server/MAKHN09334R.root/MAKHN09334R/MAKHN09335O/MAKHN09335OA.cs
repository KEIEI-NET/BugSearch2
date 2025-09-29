using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 倉庫マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 倉庫マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2006.12.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // アプリケーションの接続先を属性で指定
    public interface IWarehouseDB
    {
        /// <summary>
        /// 指定された倉庫マスタを戻します
        /// </summary>
        /// <param name="parabyte">WarehouseWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された倉庫マスタ戻りデータGuidの倉庫マスタを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// 指定された倉庫マスタを戻します
        /// </summary>
        /// <param name="paraobj">WarehouseWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された倉庫マスタ戻りデータGuidの倉庫マスタを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("MAKHN09336D", "Broadleaf.Application.Remoting.ParamData.WarehouseWork")]
            ref object paraobj, int readMode);

        /// <summary>
        /// 倉庫マスタ情報を登録、更新します
        /// </summary>
        /// <param name="warehouseWork">WarehouseWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 倉庫マスタ情報を登録、更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MAKHN09336D", "Broadleaf.Application.Remoting.ParamData.WarehouseWork")]
			ref object warehouseWork
            );


        /// <summary>
        /// 倉庫マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">WarehouseWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 倉庫マスタ情報を物理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// 倉庫マスタ情報を物理削除します
        /// </summary>
        /// <param name="paraobj">WarehouseWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 倉庫マスタ情報を物理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("MAKHN09336D", "Broadleaf.Application.Remoting.ParamData.WarehouseWork")]
            object paraobj);

        /// <summary>
        /// 倉庫マスタデータLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("MAKHN09336D", "Broadleaf.Application.Remoting.ParamData.WarehouseWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 倉庫マスタを論理削除します
        /// </summary>
        /// <param name="paraObj">WarehouseWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 倉庫マスタを論理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKHN09336D", "Broadleaf.Application.Remoting.ParamData.WarehouseWork")]
			ref object paraObj
            );

        /// <summary>
        /// 論理削除倉庫マスタを復活します
        /// </summary>
        /// <param name="paraObj">WarehouseWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除倉庫マスタを復活します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKHN09336D", "Broadleaf.Application.Remoting.ParamData.WarehouseWork")]
			ref object paraObj
            );
    }
}
