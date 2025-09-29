//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   車両管理マスタDBインターフェース
//                  :   PMSYR09012O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112　久保田
// Date             :   2008.06.02
//----------------------------------------------------------------------
// Update Note      :   2009/09/11 李占川
//                      車輌管理マスタ LDNS開発対応
//----------------------------------------------------------------------
// Update Note      :   2009/10/10 張莉莉
//                      管理番号ガイドの表示速度アップの対応
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
    /// 車両管理マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車両管理マスタDBインターフェースです。</br>
    /// <br>Programmer : 21112　久保田</br>
    /// <br>Date       : 2008.06.02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICarManagementDB
    {
        /// <summary>
        /// 単一の車両管理マスタ情報を取得します。
        /// </summary>
        /// <param name="carManagementObj">CarManagementWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車両管理マスタのキー値が一致する車両管理マスタ情報を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMSYR09013D", "Broadleaf.Application.Remoting.ParamData.CarManagementWork")]
            ref object carManagementObj,
            int readMode);

        /// <summary>
        /// 車両管理マスタ情報を物理削除します
        /// </summary>
        /// <param name="carManagementList">物理削除する車両管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車両管理マスタのキー値が一致する車両管理マスタ情報を物理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            object carManagementList);

        /// <summary>
        /// 車両管理マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="carManagementList">検索結果</param>
        /// <param name="carManagementObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車両管理マスタのキー値が一致する、全ての車両管理マスタ情報を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        [MustCustomSerialization]
        int Search(
            // --- UPD 2009/09/11 -------------->>>
            //[CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            [CustomSerializationMethodParameterAttribute("PMSYR09013D", "Broadleaf.Application.Remoting.ParamData.CarManagementWork")]
            // --- UPD 2009/09/11 --------------<<<
            ref object carManagementList,
            object carManagementObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        // --- ADD 2009/09/11 -------------->>>
        /// <summary>
        /// 車両管理マスタガイド用情報のリストを取得します。
        /// </summary>
        /// <param name="carMngGuideWorkObj">検索条件</param>
        /// <param name="carMngWorkListObj">検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車両管理マスタのキー値が一致する、全ての車両管理マスタ情報を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/11</br>
        [MustCustomSerialization]
        int SearchGuide(
            // --- UPD 2009/10/10 -------------->>>
           // [CustomSerializationMethodParameterAttribute("PMSYR09013D", "Broadleaf.Application.Remoting.ParamData.CarManagementWork")]
            object carMngGuideWorkObj,
        [CustomSerializationMethodParameterAttribute("PMSYR09013D", "Broadleaf.Application.Remoting.ParamData.CarManagementWork")]
            out object carMngWorkListObj);
        // --- UPD 2009/10/10  --------------<<<

        /// <summary>
        /// 車両管理マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="carManagementList">追加・更新する車両管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList に格納されている車両管理マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object carManagementList);

        /// <summary>
        /// 車両管理マスタ情報を論理削除します。
        /// </summary>
        /// <param name="carManagementList">論理削除する車両管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementWork に格納されている車両管理マスタ情報を論理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object carManagementList);

        /// <summary>
        /// 車両管理マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="carManagementList">論理削除を解除する車両管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementWork に格納されている車両管理マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSYR09013D","Broadleaf.Application.Remoting.ParamData.CarManagementWork")]
            ref object carManagementList);

        /// <summary>
        /// 車両管理マスタ情報の書込と論理削除処理。
        /// </summary>
        /// <param name="carManagementList">論理削除すると書込する車両管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : carManagementWork に格納されている車両管理マスタ情報を書込と論理削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        [MustCustomSerialization]
        int WriteAndLogicDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object carManagementList);
    }
}
