using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 従業員ロール設定マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 従業員ロール設定マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30747 三戸　伸悟</br>
    /// <br>Date       : 2013/02/07</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IEmployeeRoleStDB
    {

        /// <summary>
        /// 指定された従業員ロール設定マスタGuidのロールグル－プ名称設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">EmployeeRoleStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された従業員ロール設定マスタGuidの従業員ロール設定マスタを戻します</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// 従業員ロール設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">EmployeeRoleStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員ロール設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        int Delete(byte[] parabyte);

        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 従業員ロール設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="employeeRoleStWork">検索結果</param>
        /// <param name="paraemployeeRoleStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09747D", "Broadleaf.Application.Remoting.ParamData.EmployeeRoleStWork")]
            out object employeeRoleStWork,
            object paraemployeeRoleStWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 従業員ロール設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="employeeRoleStWork">EmployeeRoleStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員ロール設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09747D", "Broadleaf.Application.Remoting.ParamData.EmployeeRoleStWork")]
            ref object employeeRoleStWork
            );

        /// <summary>
        /// 従業員ロール設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="employeeRoleStWork">EmployeeRoleStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員ロール設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09747D", "Broadleaf.Application.Remoting.ParamData.EmployeeRoleStWork")]
            ref object employeeRoleStWork
            );

        /// <summary>
        /// 論理削除従業員ロール設定マスタ情報を復活します
        /// </summary>
        /// <param name="employeeRoleStWork">EmployeeRoleStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除従業員ロール設定マスタ情報を復活します</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09747D", "Broadleaf.Application.Remoting.ParamData.EmployeeRoleStWork")]
            ref object employeeRoleStWork
            );
        #endregion
    }
}
