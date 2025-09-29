//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE発注用I/OWriteDBインターフェース
//                  :   PMUOE01007O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112　久保田
// Date             :   2008.09.22
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// UOE発注用I/OWriteDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE発注用I/OWriteDBインターフェースです。</br>
    /// <br>Programmer : 21112　久保田</br>
    /// <br>Date       : 2008.09.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IIOWriteUOEOdrDtlDB
    {
        /// <summary>
        /// UOE発注データと、それに紐付く仕入明細データのリストを取得します。
        /// </summary>
        /// <param name="uoeSendProcCndtn">検索条件</param>
        /// <param name="uoeOrderDtlList">検索結果(UOE発注データ)</param>
        /// <param name="stockDtlList">検索結果(仕入明細データ)</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 検索条件に一致するUOE発注データと、それに紐付く仕入明細データを取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        [MustCustomSerialization]
        int Search(
            object uoeSendProcCndtn,
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList,
            [CustomSerializationMethodParameterAttribute("MAKON01826D", "Broadleaf.Application.Remoting.ParamData.StockDetailWork")]
            ref object stockDtlList,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// UOE発注データの特定項目をキーに、UOE発注データとそれに紐付く仕入データ＋仕入明細データを取得します。
        /// </summary>
        /// <param name="uoeOrderDtlList">検索条件となるUOE発注データ</param>
        /// <param name="slipGroupList">検索結果(UOE発注データ、仕入データ、仕入明細データ)</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 検索条件に一致するUOE発注データと、それに紐付く仕入明細データを取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.12.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object slipGroupList,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        // ------ADD 2023/01/20 田村顕成 卸商仕入受信処理障害対応 ------>>>>>        	
        /// <summary>
        /// UOE発注データの特定項目をキーに、UOE発注データとそれに紐付く仕入データ＋仕入明細データを取得します。
        /// </summary>
        /// <param name="uoeOrderDtlList">検索条件となるUOE発注データ</param>
        /// <param name="slipGroupList">検索結果(UOE発注データ、仕入データ、仕入明細データ)</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: PMKOBETSU-4202 卸商仕入受信処理障害対応</br>
        /// <br>Programmer : 田村顕成</br>
        /// <br>Date       : 2023/01/20</br>
        [MustCustomSerialization]
        int Search2(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object slipGroupList,
            int readMode, ConstantManagement.LogicalMode logicalMode);
        // ------ADD 2023/01/20 田村顕成 卸商仕入受信処理障害対応 ------<<<<<

        /// <summary>
        /// UOE発注データを追加・更新します。
        /// </summary>
        /// <param name="uoeOdrDtlList">追加・更新するUOE発注データを含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList に格納されているUOE発注データを追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOdrDtlList);

        /// <summary>
        /// UOE発注用I/OWrite情報を論理削除します。
        /// </summary>
        /// <param name="uoeOdrDtlList">論理削除するUOE発注データを含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ioWriteUOEOdrDtlWork に格納されているUOE発注用I/OWrite情報を論理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOdrDtlList);

        /// <summary>
        /// UOE発注確定処理を行います。
        /// </summary>
        /// <param name="uoeOdrSlipList">UOE発注データを含むArrayListと発注データを含むArrayListを格納したCustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE発注確定処理を行います</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        [MustCustomSerialization]
        int OrderFixation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object uoeOdrSlipList);

        /// <summary>
        /// UOE発注データの特定項目をキーに、UOE発注データとそれに紐付く仕入データ＋仕入明細データを取得します。
        /// </summary>
        /// <param name="paraList">検索条件</param>
        /// <param name="uoeOrderDtlList">検索結果(UOE発注データ)</param>
        /// <param name="stockDtlList">検索結果(仕入明細データ)</param>        
        /// <returns>STATUS</returns>
        /// <br>Note       : 検索条件に一致するUOE発注データと、それに紐付く仕入明細データを取得します。</br>
        /// <br>Programmer : 22008　長内</br>
        /// <br>Date       : 2009.05.25</br>
        [MustCustomSerialization]
        int UoeOdrDtlGodsReadAll(object paraList,
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeOrderDtlList,
          [CustomSerializationMethodParameterAttribute("MAKON01826D", "Broadleaf.Application.Remoting.ParamData.StockDetailWork")]
            ref object stockDtlList);

        #region ADD 2013/04/3 Redmine#35210 wangl2 for No.1802の対応
        /// <summary>
        /// UOE発注データを追加・更新します。
        /// </summary>
        /// <param name="uoeOdrDtlList">UOE発注データリスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList に格納されているUOE発注データを追加・更新します。</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013.04.03</br>
        [MustCustomSerialization]
        int WriteUOESalesOrderNo(
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref ArrayList uoeOdrDtlList);
        #endregion

    }
}
