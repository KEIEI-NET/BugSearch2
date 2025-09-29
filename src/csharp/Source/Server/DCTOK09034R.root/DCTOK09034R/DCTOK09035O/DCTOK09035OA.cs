using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 従業員詳細マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 従業員詳細マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 21024　佐々木　健</br>
    /// <br>Date       : 2007.08.16</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // アプリケーションの接続先を属性で指定
    public interface IEmployeeDtlDB
    {
        /// <summary>
        /// 指定された従業員詳細マスタを戻します
        /// </summary>
        /// <param name="parabyte">EmployeeDtlWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された従業員詳細マスタGuidの従業員詳細マスタを戻します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// 指定された従業員詳細マスタを戻します
        /// </summary>
        /// <param name="paraobj">EmployeeDtlWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された従業員詳細マスタGuidの従業員詳細マスタを戻します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("DCTOK09036D", "Broadleaf.Application.Remoting.ParamData.EmployeeDtlWork")]
            ref object paraobj, int readMode);

        /// <summary>
        /// 従業員詳細マスタを物理削除します
        /// </summary>
        /// <param name="parabyte">EmployeeDtlWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員詳細マスタを物理削除します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// 従業員詳細マスタを物理削除します
        /// </summary>
        /// <param name="paraobj">EmployeeDtlWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員詳細マスタを物理削除します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("DCTOK09036D", "Broadleaf.Application.Remoting.ParamData.EmployeeDtlWork")]
            object paraobj);

        /// <summary>
        /// 従業員詳細マスタを登録、更新します
        /// </summary>
        /// <param name="paraList">EmployeeDtlWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員詳細マスタを登録、更新します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCTOK09036D", "Broadleaf.Application.Remoting.ParamData.EmployeeDtlWork")]
            ref object paraList
            );

        /// <summary>
        /// 従業員詳細マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCTOK09036D", "Broadleaf.Application.Remoting.ParamData.EmployeeDtlWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 従業員詳細マスタを論理削除します
        /// </summary>
        /// <param name="paraObj">EmployeeDtlWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員詳細マスタを論理削除します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        [MustCustomSerialization]
        int LogicalDelete( 
            [CustomSerializationMethodParameterAttribute("DCTOK09036D", "Broadleaf.Application.Remoting.ParamData.EmployeeDtlWork")]
			ref object paraObj );

        /// <summary>
        /// 論理削除従業員詳細マスタを復活します
        /// </summary>
        /// <param name="paraObj">EmployeeDtlWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除従業員詳細マスタを復活します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete( [CustomSerializationMethodParameterAttribute("DCTOK09036D", "Broadleaf.Application.Remoting.ParamData.EmployeeDtlWork")]
			ref object paraObj );
    }
}
