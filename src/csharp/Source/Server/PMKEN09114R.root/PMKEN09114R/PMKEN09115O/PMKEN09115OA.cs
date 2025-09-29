//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   TBO検索マスタ(ユーザー登録)DBインターフェース
//                  :   PMKEN09115O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.11.17
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
    /// TBO検索マスタ(ユーザー登録)DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : TBO検索マスタ(ユーザー登録)DBインターフェースです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.11.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITBOSearchUDB
    {
        /// <summary>
        /// 単一のTBO検索マスタ(ユーザー登録)情報を取得します。
        /// </summary>
        /// <param name="tboSearchUObj">TBOSearchUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ(ユーザー登録)のキー値が一致するTBO検索マスタ(ユーザー登録)情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            ref object tboSearchUObj,
            int readMode);

        /// <summary>
        /// TBO検索マスタ(ユーザー登録)情報を物理削除します
        /// </summary>
        /// <param name="tboSearchUList">物理削除するTBO検索マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ(ユーザー登録)のキー値が一致するTBO検索マスタ(ユーザー登録)情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            object tboSearchUList);

        /// <summary>
        /// TBO検索マスタ(ユーザー登録)情報のリストを取得します。
        /// </summary>
        /// <param name="tboSearchUList">検索結果</param>
        /// <param name="tboSearchUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ(ユーザー登録)のキー値が一致する、全てのTBO検索マスタ(ユーザー登録)情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            ref object tboSearchUList,
            object tboSearchUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 装備名称ガイド用のリストを取得します。
        /// </summary>
        /// <param name="tboSearchUList">検索結果</param>
        /// <param name="tboSearchUObj">検索条件</param>
        /// <param name="equipNameSrchTyp">装備名称検索タイプ 0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 装備名称ガイド用のリストを取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        int SearchEquipNameGuide(
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            ref object tboSearchUList, object tboSearchUObj, int equipNameSrchTyp);

        /// <summary>
        /// TBO検索マスタ(ユーザー登録)情報を追加・更新します。
        /// </summary>
        /// <param name="tboSearchUList">追加・更新するTBO検索マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList に格納されているTBO検索マスタ(ユーザー登録)情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            ref object tboSearchUList);

        /// <summary>
        /// <br>TBO検索マスタ情報を登録、更新します</br>
        /// <br>同一装備名称、メーカーコードのデータをいったんDELETEし、新規で内容を登録します</br>
        /// </summary>
        /// <param name="tboSearchUWork">追加・更新するTBO検索マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="equipGenreCode">装備分類</param>
        /// <param name="equipName">装備名称</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList に格納されているTBO検索マスタ(ユーザー登録)情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            ref object tboSearchUWork,
            string enterpriseCode, Int32 equipGenreCode, string equipName
           );

        /// <summary>
        /// TBO検索マスタ(ユーザー登録)情報を論理削除します。
        /// </summary>
        /// <param name="tboSearchUList">論理削除するTBO検索マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUWork に格納されているTBO検索マスタ(ユーザー登録)情報を論理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            ref object tboSearchUList);

        /// <summary>
        /// TBO検索マスタ(ユーザー登録)情報の論理削除を解除します。
        /// </summary>
        /// <param name="tboSearchUList">論理削除を解除するTBO検索マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUWork に格納されているTBO検索マスタ(ユーザー登録)情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            ref object tboSearchUList);
    }
}
