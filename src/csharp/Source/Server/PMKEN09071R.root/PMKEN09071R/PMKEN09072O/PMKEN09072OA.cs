//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   結合マスタ(ユーザー登録)DBインターフェース
//                  :   PMKEN09072O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.06.11
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 結合マスタ(ユーザー登録)DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 結合マスタ(ユーザー登録)DBインターフェースです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.06.11</br>
    /// <br></br>
    /// <br>Update Note: 2010/01/28 30517 夏野 駿希</br>
    /// <br>             Mantis:14923 結合マスタ処理時にエラー発生する件の修正</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IJoinPartsUDB
    {
        /// <summary>
        /// 単一の結合マスタ(ユーザー登録)情報を取得します。
        /// </summary>
        /// <param name="joinPartsUObj">JoinPartsUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ(ユーザー登録)のキー値が一致する結合マスタ(ユーザー登録)情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            ref object joinPartsUObj,
            int readMode);

        /// <summary>
        /// 結合マスタ(ユーザー登録)情報を物理削除します
        /// </summary>
        /// <param name="joinPartsUList">物理削除する結合マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ(ユーザー登録)のキー値が一致する結合マスタ(ユーザー登録)情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            object joinPartsUList);

        /// <summary>
        /// 結合マスタ(ユーザー登録)情報のリストを取得します。
        /// </summary>
        /// <param name="joinPartsUList">検索結果</param>
        /// <param name="joinPartsUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ(ユーザー登録)のキー値が一致する、全ての結合マスタ(ユーザー登録)情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            ref object joinPartsUList,
            object joinPartsUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 結合マスタ(ユーザー登録)情報を追加・更新します。
        /// </summary>
        /// <param name="joinPartsUList">追加・更新する結合マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUList に格納されている結合マスタ(ユーザー登録)情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            ref object joinPartsUList);

        /// <summary>
        /// <br>結合マスタマスタ情報を登録、更新します</br>
        /// <br>同一親品番、メーカーコードのデータをいったんDELETEし、新規で内容を登録します</br>
        /// </summary>
        /// <param name="joinPartsUWork">追加・更新する結合マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="joinSourceMakerCode">親メーカーコード</param>
        /// <param name="joinSourPartsNoWithH">親品番</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUList に格納されている結合マスタ(ユーザー登録)情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            ref object joinPartsUWork,
            string enterpriseCode, Int32 joinSourceMakerCode, string joinSourPartsNoWithH
           );

        /// <summary>
        /// 結合マスタ(ユーザー登録)情報を論理削除します。
        /// </summary>
        /// <param name="joinPartsUList">論理削除する結合マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUWork に格納されている結合マスタ(ユーザー登録)情報を論理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            ref object joinPartsUList);

        /// <summary>
        /// 結合マスタ(ユーザー登録)情報の論理削除を解除します。
        /// </summary>
        /// <param name="joinPartsUList">論理削除を解除する結合マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUWork に格納されている結合マスタ(ユーザー登録)情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKEN09073D","Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            ref object joinPartsUList);

        // 2010/01/28 Add >>>
        /// <summary>
        /// 結合マスタ(ユーザー登録)情報のリストを検索件数分取得します。
        /// </summary>
        /// <param name="joinPartsUList">検索結果</param>
        /// <param name="joinPartsUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="searchCnt">検索件数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ(ユーザー登録)のキー値が一致する、全ての結合マスタ(ユーザー登録)情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int SearchMstDel(
            [CustomSerializationMethodParameterAttribute("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            ref object joinPartsUList,
            object joinPartsUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode,
            int searchCnt);
        // 2010/01/28 Add <<<

    }
}
