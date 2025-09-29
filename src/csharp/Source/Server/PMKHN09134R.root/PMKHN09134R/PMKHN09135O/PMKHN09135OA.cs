using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// オペレーション設定DBRemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : オペレーション設定DBRemoteObjectインターフェースです。</br>
    /// <br>Programmer : 23015 森本 大輝</br>
    /// <br>Date       : 2008.07.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IOperationStDB
    {
        /// <summary>
        /// 単一のOperationSt情報を取得します。
        /// </summary>
        /// <param name="operationStObj">OperationStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStのキー値が一致するOperationSt情報を取得します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09136D", "Broadleaf.Application.Remoting.ParamData.OperationStWork")]
            ref object operationStObj,
            int readMode);

        /// <summary>
        /// OperationSt情報を物理削除します
        /// </summary>
        /// <param name="operationStList">物理削除するOperationSt情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStのキー値が一致するOperationSt情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09136D", "Broadleaf.Application.Remoting.ParamData.OperationStWork")]
            object operationStList);

        /// <summary>
        /// OperationSt情報のリストを取得します。
        /// </summary>
        /// <param name="operationStList">検索結果</param>
        /// <param name="operationStObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStのキー値が一致する、全てのOperationSt情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09136D", "Broadleaf.Application.Remoting.ParamData.OperationStWork")]
            ref object operationStList,
            object operationStObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// OperationSt情報を追加・更新します。
        /// </summary>
        /// <param name="operationStList">追加・更新するOperationSt情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStList に格納されているOperationSt情報を追加・更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09136D", "Broadleaf.Application.Remoting.ParamData.OperationStWork")]
            ref object operationStList);

        /// <summary>
        /// OperationSt情報を論理削除します。
        /// </summary>
        /// <param name="operationStList">論理削除するOperationSt情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStWork に格納されているOperationSt情報を論理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09136D", "Broadleaf.Application.Remoting.ParamData.OperationStWork")]
            ref object operationStList);

        /// <summary>
        /// OperationSt情報の論理削除を解除します。
        /// </summary>
        /// <param name="operationStList">論理削除を解除するOperationSt情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStWork に格納されているOperationSt情報の論理削除を解除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09136D", "Broadleaf.Application.Remoting.ParamData.OperationStWork")]
            ref object operationStList);
    }
}
