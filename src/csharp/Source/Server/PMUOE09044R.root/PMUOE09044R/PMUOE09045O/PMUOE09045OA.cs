//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE 自社設定マスタDBインターフェース
//                  :   PMUOE09045O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 疋田 勇人
// Date             :   2008.06.06
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
    /// UOE 自社設定マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE 自社設定マスタDBインターフェースです。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUOESettingDB
    {
        /// <summary>
        /// 単一のUOE 自社設定マスタ情報を取得します。
        /// </summary>
        /// <param name="uoeSettingObj">UOESettingWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE 自社設定マスタのキー値が一致するUOE 自社設定マスタ情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMUOE09046D", "Broadleaf.Application.Remoting.ParamData.UOESettingWork")]
            ref object uoeSettingObj,
            int readMode);

        /// <summary>
        /// UOE 自社設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="uoeSettingList">物理削除するUOE 自社設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE 自社設定マスタのキー値が一致するUOE 自社設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMUOE09046D", "Broadleaf.Application.Remoting.ParamData.UOESettingWork")]
            object uoeSettingList);

        /// <summary>
        /// UOE 自社設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="uoeSettingList">検索結果</param>
        /// <param name="uoeSettingObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE 自社設定マスタのキー値が一致する、全てのUOE 自社設定マスタ情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMUOE09046D", "Broadleaf.Application.Remoting.ParamData.UOESettingWork")]
            ref object uoeSettingList,
            object uoeSettingObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// UOE 自社設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="uoeSettingList">追加・更新するUOE 自社設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESettingList に格納されているUOE 自社設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMUOE09046D", "Broadleaf.Application.Remoting.ParamData.UOESettingWork")]
            ref object uoeSettingList);

        /// <summary>
        /// UOE 自社設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="uoeSettingList">論理削除するUOE 自社設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESettingWork に格納されているUOE 自社設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE09046D", "Broadleaf.Application.Remoting.ParamData.UOESettingWork")]
            ref object uoeSettingList);

        /// <summary>
        /// UOE 自社設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="uoeSettingList">論理削除を解除するUOE 自社設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESettingWork に格納されているUOE 自社設定マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE09046D","Broadleaf.Application.Remoting.ParamData.UOESettingWork")]
            ref object uoeSettingList);
    }
}
