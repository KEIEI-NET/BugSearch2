//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ロールグループ権限設定マスタ                    //
//                      DB RemoteObject Interface                       //
//                  :   PMKHN09735O.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting                  //
// Programmer       :   30746 高川 悟                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

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
    /// ロールグループ権限設定マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : ロールグループ権限設定マスタDBインターフェースです。</br>
    /// <br>Programmer : 30746 高川 悟</br>
    /// <br>Date       : 2013/02/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRoleGroupAuthDB
    {
        /// <summary>
        /// ロールグループ権限設定マスタ情報を取得します。
        /// </summary>
        /// <param name="roleGroupAuthObj">RoleGroupAuthWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ権限設定マスタのキー値が一致するロールグループ権限設定マスタ情報を取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09736D", "Broadleaf.Application.Remoting.ParamData.RoleGroupAuthWork")]
            ref object roleGroupAuthObj,
            int readMode);

        /// <summary>
        /// ロールグループ権限設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="RoleGroupAuthList">物理削除するロールグループ権限設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ権限設定マスタのキー値が一致するロールグループ権限設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09736D", "Broadleaf.Application.Remoting.ParamData.RoleGroupAuthWork")]
            object roleGroupAuthList);

        /// <summary>
        /// ロールグループ権限設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="roleGroupAuthList">検索結果</param>
        /// <param name="roleGroupAuthObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ権限設定マスタのキー値が一致する、全てのロールグループ権限設定マスタ情報を取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09736D", "Broadleaf.Application.Remoting.ParamData.RoleGroupAuthWork")]
            ref object roleGroupAuthList,
            object rolegroupAuthObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ロールグループ権限設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="roleGroupAuthList">追加・更新するロールグループ権限設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUList に格納されているロールグループ権限設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09736D", "Broadleaf.Application.Remoting.ParamData.RoleGroupAuthWork")]
            ref object roleGroupAuthList);

        /// <summary>
        /// ロールグループ権限設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="roleGroupAuthList">論理削除するロールグループ権限設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUWork に格納されているロールグループ権限設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09736D", "Broadleaf.Application.Remoting.ParamData.RoleGroupAuthWork")]
            ref object roleGroupAuthList);

        /// <summary>
        /// ロールグループ権限設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="roleGroupAuthList">論理削除を解除するロールグループ権限設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUWork に格納されているロールグループ権限設定マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09736D", "Broadleaf.Application.Remoting.ParamData.RoleGroupAuthWork")]
            ref object roleGroupAuthList);
    }
}