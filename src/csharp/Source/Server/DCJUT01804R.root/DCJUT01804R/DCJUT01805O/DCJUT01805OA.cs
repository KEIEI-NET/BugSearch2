using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 受注マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 受注マスタDBインターフェースです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2006.10.19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IAcceptOdrDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 受注マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="acceptOdrWork">検索結果</param>
        /// <param name="paraacceptOdrWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2006.10.19</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCCMN00106D","Broadleaf.Application.Remoting.ParamData.AcceptOdrWork")]
            out object acceptOdrWork,
            object paraacceptOdrWork, int readMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 受注マスタ情報を登録、更新します
        /// </summary>
        /// <param name="acceptOdrWork">AcceptOdrWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ情報を登録、更新します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2006.10.19</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCCMN00106D","Broadleaf.Application.Remoting.ParamData.AcceptOdrWork")]
            ref object acceptOdrWork
            );

        /// <summary>
        /// 受注マスタ情報を物理削除します
        /// </summary>
        /// <param name="acceptOdrWork">AcceptOdrWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ情報を物理削除します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2006.10.19</br>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("DCCMN00106D", "Broadleaf.Application.Remoting.ParamData.AcceptOdrWork")]
            object acceptOdrWork
            );

        /// <summary>
        /// 受注マスタ情報を論理削除します
        /// </summary>
        /// <param name="acceptOdrWork">AcceptOdrWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ情報を論理削除します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2006.10.19</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCCMN00106D","Broadleaf.Application.Remoting.ParamData.AcceptOdrWork")]
            ref object acceptOdrWork
            );

        /// <summary>
        /// 論理削除受注マスタ情報を復活します
        /// </summary>
        /// <param name="acceptOdrWork">AcceptOdrWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除受注マスタ情報を復活します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2006.10.19</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCCMN00106D","Broadleaf.Application.Remoting.ParamData.AcceptOdrWork")]
            ref object acceptOdrWork
            );
        #endregion
    }
}
