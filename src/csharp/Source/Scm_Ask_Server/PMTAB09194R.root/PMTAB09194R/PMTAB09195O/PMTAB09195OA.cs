//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PMTAB初期表示従業員設定マスタDBインターフェース
// プログラム概要   : PMTAB初期表示従業員設定マスタDBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/08/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMTAB初期表示従業員設定マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB初期表示従業員設定マスタDBインターフェースです。</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    public interface IPmtDefEmpDB
    {
        /// <summary>
        /// 単一のPMTAB初期表示従業員設定マスタ情報を取得します。
        /// </summary>
        /// <param name="pmtDefEmpObj">PmtDefEmpWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB初期表示従業員設定マスタのキー値が一致するPMTAB初期表示従業員設定マスタ情報を取得します。</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMTAB09196D", "Broadleaf.Application.Remoting.ParamData.PmtDefEmpWork")]
            ref object pmtDefEmpObj
            );

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報リストを取得します。
        /// </summary>
        /// <param name="pmtDefEmpObj">抽出条件リスト(PmtDefEmpWork)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB初期表示従業員設定マスタのキー値が一致するPMTAB初期表示従業員設定マスタ情報を取得します。</br>
        int ReadAll(
            [CustomSerializationMethodParameterAttribute("PMTAB09196D", "Broadleaf.Application.Remoting.ParamData.PmtDefEmpWork")]
            ref object pmtDefEmpObj);

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="pmtDefEmpList">物理削除するPMTAB初期表示従業員設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB初期表示従業員設定マスタのキー値が一致するPMTAB初期表示従業員設定マスタ情報を物理削除します。</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMTAB09196D", "Broadleaf.Application.Remoting.ParamData.PmtDefEmpWork")]
            object pmtDefEmpList);

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="pmtDefEmpList">検索結果</param>
        /// <param name="pmtDefEmpObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB初期表示従業員設定マスタのキー値が一致する、全てのPMTAB初期表示従業員設定マスタ情報を取得します。</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTAB09196D", "Broadleaf.Application.Remoting.ParamData.PmtDefEmpWork")]
            ref object pmtDefEmpList,
            object pmtDefEmpObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="pmtDefEmpList">追加・更新するPMTAB初期表示従業員設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpList に格納されているPMTAB初期表示従業員設定マスタ情報を追加・更新します。</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMTAB09196D", "Broadleaf.Application.Remoting.ParamData.PmtDefEmpWork")]
            ref object pmtDefEmpList);

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="pmtDefEmpList">論理削除するPMTAB初期表示従業員設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpWord に格納されているPMTAB初期表示従業員設定マスタ情報を論理削除します。</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMTAB09196D", "Broadleaf.Application.Remoting.ParamData.PmtDefEmpWork")]
            ref object pmtDefEmpList);

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="pmtDefEmpList">論理削除を解除するPMTAB初期表示従業員設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpWord に格納されているPMTAB初期表示従業員設定マスタ情報の論理削除を解除します。</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMTAB09196D", "Broadleaf.Application.Remoting.ParamData.PmtDefEmpWork")]
            ref object pmtDefEmpList);
    }
}