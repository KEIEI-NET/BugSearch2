//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE発注データDBインターフェース
//                  :   PMUOE01052O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.07.16
//----------------------------------------------------------------------
// Update Note      :   2018/06/20  miyatsu
//                      不要になった過去の発注データが速度に悪影響を与える為
//                      日付指定で一括物理削除する処理を追加
//                      (PMKHN02060:処理済みデータ削除ツールで使用)
//----------------------------------------------------------------------
// 管理番号  11400910-00  作成担当 : 田建委
// 作 成 日  2018/07/26   修正内容 : Redmine#49725 UOE発注データ削除処理対応
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// UOE発注データDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE発注データDBインターフェースです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.07.16</br>
    /// <br>Update Note: Redmine#49725 UOE発注データ削除処理対応</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2018/07/26</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUOEOrderDtlDB
    {
        /// <summary>
        /// 単一のUOE発注データ情報を取得します。
        /// </summary>
        /// <param name="uoeOrderDtlObj">UOEOrderDtlWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE発注データのキー値が一致するUOE発注データ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.07.16</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlObj,
            int readMode);

        /// <summary>
        /// UOE発注データ情報を物理削除します
        /// </summary>
        /// <param name="uoeOrderDtlList">物理削除するUOE発注データ情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE発注データのキー値が一致するUOE発注データ情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.07.16</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            object uoeOrderDtlList);

        //2018/06/20 ADD >>>>
        /// <summary>
        /// UOE発注データ情報を一括物理削除します
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : 条件に一致するUOE発注データ情報を一括物理削除します。</br>
        /// <br>Programmer : 30365 miyatsu</br>
        /// <br>Date       : 2018/06/20</br>
        // ---UPD 田建委 2018/07/26 Redmine#49725 UOE発注データ削除処理対応 ------>>>>>
        //int DeleteForce(
        //    string enterpriseCode,
        //    int sectionCode,
        //    int inputDay,
        //    out int delcnt);
        int DeleteForce(
            string enterpriseCode,
            string sectionCode,
            int inputDay,
            out int delcnt);
        // ---UPD 田建委 2018/07/26 Redmine#49725 UOE発注データ削除処理対応 ------<<<<<
        //2018/06/20 ADD <<<<

        /// <summary>
        /// UOE発注データ情報のリストを取得します。
        /// </summary>
        /// <param name="uoeOrderDtlList">検索結果</param>
        /// <param name="uoeOrderDtlObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE発注データのキー値が一致する、全てのUOE発注データ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.07.16</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList,
            object uoeOrderDtlObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// UOE発注データ情報を追加・更新します。
        /// </summary>
        /// <param name="uoeOrderDtlList">追加・更新するUOE発注データ情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlList に格納されているUOE発注データ情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.07.16</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList);

        /// <summary>
        /// UOE発注データ情報を論理削除します。
        /// </summary>
        /// <param name="uoeOrderDtlList">論理削除するUOE発注データ情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlWork に格納されているUOE発注データ情報を論理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.07.16</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList);

        /// <summary>
        /// UOE発注データ情報の論理削除を解除します。
        /// </summary>
        /// <param name="uoeOrderDtlList">論理削除を解除するUOE発注データ情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlWork に格納されているUOE発注データ情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.07.16</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D","Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList);

        /// <summary>
        /// UOE発注データ情報のリストを取得します。
        /// </summary>
        /// <param name="uoeOrderDtlList">検索結果</param>
        /// <param name="paraobj">検索条件</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE発注データのキー値が一致する、全てのUOE発注データ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.07.16</br>
        [MustCustomSerialization]
        int UoeOdrDtlGodsReadAll(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList, object paraobj);

    }
}
