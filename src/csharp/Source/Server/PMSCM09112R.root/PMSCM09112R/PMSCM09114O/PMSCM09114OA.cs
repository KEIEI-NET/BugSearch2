using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 同期状態表示端末設定DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 同期状態表示端末設定DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 劉超</br>
    /// <br>Date       : 2014/08/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // アプリケーションの接続先を属性で指定
    public interface ISyncStateDspTermStDB
    {
        /// <summary>
        /// 同期状態表示端末設定情報を登録、更新します
        /// </summary>
        /// <param name="warehouseWork">SyncStateDspTermStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 同期状態表示端末設定情報を登録、更新します</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMSCM09115D", "Broadleaf.Application.Remoting.ParamData.SyncStateDspTermStWork")]
			ref object warehouseWork
            );

        /// <summary>
        /// 同期状態表示端末設定情報を物理削除します
        /// </summary>
        /// <param name="paraobj">SyncStateDspTermStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 同期状態表示端末設定情報を物理削除します</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        int Delete(object paraobj);

        /// <summary>
        /// 同期状態表示端末設定マスタデータLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMSCM09115D", "Broadleaf.Application.Remoting.ParamData.SyncStateDspTermStWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 同期状態表示端末設定マスタを論理削除します
        /// </summary>
        /// <param name="paraObj">SyncStateDspTermStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 同期状態表示端末設定マスタを論理削除します</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM09115D", "Broadleaf.Application.Remoting.ParamData.SyncStateDspTermStWork")]
			ref object paraObj
            );

        /// <summary>
        /// 論理削除同期状態表示端末設定マスタを復活します
        /// </summary>
        /// <param name="paraObj">SyncStateDspTermStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除同期状態表示端末設定マスタを復活します</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM09115D", "Broadleaf.Application.Remoting.ParamData.SyncStateDspTermStWork")]
			ref object paraObj
            );
    }
}
