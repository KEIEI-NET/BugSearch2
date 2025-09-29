//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   優良設定マスタ（ユーザー登録分）DBインターフェース
//                  :   PMKEN09033O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 疋田 勇人
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
    /// 優良設定マスタ（ユーザー登録分）DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 優良設定マスタ（ユーザー登録分）DBインターフェースです。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.06.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPrmSettingUDB
    {
        /// <summary>
        /// 単一の優良設定マスタ（ユーザー登録分）情報を取得します。
        /// </summary>
        /// <param name="prmSettingUObj">PrmSettingUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優良設定マスタ（ユーザー登録分）のキー値が一致する優良設定マスタ（ユーザー登録分）情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKEN09034D", "Broadleaf.Application.Remoting.ParamData.PrmSettingUWork")]
            ref object prmSettingUObj,
            int readMode);

        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報を物理削除します
        /// </summary>
        /// <param name="prmSettingUList">物理削除する優良設定マスタ（ユーザー登録分）情報を含む ArrayList</param>
        /// <param name="goodsMngList">商品管理情報 ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優良設定マスタ（ユーザー登録分）のキー値が一致する優良設定マスタ（ユーザー登録分）情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKEN09034D", "Broadleaf.Application.Remoting.ParamData.PrmSettingUWork")]
            object prmSettingUList,
            object goodsMngList);

        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報のリストを取得します。
        /// </summary>
        /// <param name="prmSettingUList">検索結果</param>
        /// <param name="prmSettingUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優良設定マスタ（ユーザー登録分）のキー値が一致する、全ての優良設定マスタ（ユーザー登録分）情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKEN09034D", "Broadleaf.Application.Remoting.ParamData.PrmSettingUWork")]
            ref object prmSettingUList,
            object prmSettingUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報を追加・更新します。
        /// </summary>
        /// <param name="prmSettingUList">追加・更新する優良設定マスタ（ユーザー登録分）情報を含む ArrayList</param>
        /// <param name="goodsMngList">更新する商品管理情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUList に格納されている優良設定マスタ（ユーザー登録分）情報を追加・更新します。</br>
        /// <br>Note       : GoodsMngList に格納されている商品管理情報を更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKEN09034D", "Broadleaf.Application.Remoting.ParamData.PrmSettingUWork")]
            ref object prmSettingUList,
            ref object goodsMngList);

        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報を論理削除します。
        /// </summary>
        /// <param name="prmSettingUList">論理削除する優良設定マスタ（ユーザー登録分）情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUWork に格納されている優良設定マスタ（ユーザー登録分）情報を論理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKEN09034D", "Broadleaf.Application.Remoting.ParamData.PrmSettingUWork")]
            ref object prmSettingUList);

        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報の論理削除を解除します。
        /// </summary>
        /// <param name="prmSettingUList">論理削除を解除する優良設定マスタ（ユーザー登録分）情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUWork に格納されている優良設定マスタ（ユーザー登録分）情報の論理削除を解除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKEN09034D","Broadleaf.Application.Remoting.ParamData.PrmSettingUWork")]
            ref object prmSettingUList);
    }
}
