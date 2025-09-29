//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ロールグループ名称設定マスタ                    //
//                      DB RemoteObject Interface                       //
//                  :   PMKHN09726O.DLL                                 //
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
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ロールグループ名称設定マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : ロールグループ名称設定マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30746 高川 悟</br>
    /// <br>Date       : 2013/02/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRoleGroupNameStDB
    {

        /// <summary>
        /// 指定されたロールグループ名称設定マスタGuidのロールグル－プ名称設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">RoleGroupNameStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたロールグループ名称設定マスタGuidのロールグループ名称設定マスタを戻します</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// ロールグループ名称設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">RoleGroupNameStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ名称設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        int Delete(byte[] parabyte);

        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// ロールグループ名称設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="roleGroupNameStWork">検索結果</param>
        /// <param name="pararoleGroupNameStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09727D", "Broadleaf.Application.Remoting.ParamData.RoleGroupNameStWork")]
            out object roleGroupNameStWork,
            object pararoleGroupNameStWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ロールグループ名称設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="roleGroupNameStWork">RoleGroupNameStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ名称設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09727D", "Broadleaf.Application.Remoting.ParamData.RoleGroupNameStWork")]
            ref object roleGroupNameStWork
            );

        /// <summary>
        /// ロールグループ名称設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="roleGroupNameStWork">RoleGroupNameStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ名称設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09727D", "Broadleaf.Application.Remoting.ParamData.RoleGroupNameStWork")]
            ref object roleGroupNameStWork
            );

        /// <summary>
        /// 論理削除ロールグループ名称設定マスタ情報を復活します
        /// </summary>
        /// <param name="roleGroupNameStWork">RoleGroupNameStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除ロールグループ名称設定マスタ情報を復活します</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09727D", "Broadleaf.Application.Remoting.ParamData.RoleGroupNameStWork")]
            ref object roleGroupNameStWork
            );
        #endregion
    }
}