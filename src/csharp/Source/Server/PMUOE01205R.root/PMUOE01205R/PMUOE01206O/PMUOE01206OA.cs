//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE入庫更新DBインターフェース
//                  :   PMUOE01206O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112　久保田
// Date             :   2008.10.17
//----------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内
// 作 成 日  2009/08/24  修正内容 : E-Parts対応に伴う抽出メソッド追加
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
    /// UOE入庫更新DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE入庫更新DBインターフェースです。</br>
    /// <br>Programmer : 21112　久保田</br>
    /// <br>Date       : 2008.10.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUOEStockUpdateDB
    {
        /// <summary>
        /// UOE入庫更新情報のリストを取得します。
        /// </summary>
        /// <param name="uoeStcUpdSearch">検索条件となる UOEStockUpdSearchWork を指定します。</param>
        /// <param name="uoeStcUpdDataList">検索結果を格納 CustomSerializeArrayList を指定します。</param>
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 検索条件に合致するUOE発注データ、仕入データ、仕入明細データを検索します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        [MustCustomSerialization]
        int Search(
            object uoeStcUpdSearch,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object uoeStcUpdDataList,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        // -- ADD 2009/08/24 ---------------------------->>>
        /// <summary>
        /// UOE入庫更新情報のリストを取得します。
        /// </summary>
        /// <param name="uoeStcUpdSearch">検索条件となる UOEStockUpdSearchWork を指定します。</param>
        /// <param name="uoeStcUpdDataList">検索結果を格納 CustomSerializeArrayList を指定します。</param>
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 検索条件に合致するUOE発注データ、仕入データ、仕入明細データを検索します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        [MustCustomSerialization]
        int SearchAllPartySlip(
            object uoeStcUpdSearch,
            [CustomSerializationMethodParameterAttribute("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork")]
            ref object uoeStcUpdDataList,
            int readMode, ConstantManagement.LogicalMode logicalMode);
        // -- ADD 2009/08/24 ----------------------------<<<

        /// <summary>
        /// UOE入庫更新情報を追加・更新します。
        /// </summary>
        /// <param name="uoeStcUpdDataList">追加・更新するUOE入庫更新情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeStockUpdateList に格納されている仕入データや在庫調整データを登録します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        ///
        /// CustomSerializeArrayList     [uoeStockUpdateList]
        /// │
        /// ├IOWriteCtrlOptWork         [売上・仕入制御データ]
        /// │
        /// ├CustomSerializeArrayList   [代替元品番更新用発注データ群]
        /// │├StockSlipWork            [仕入データ(仕入形式=2:発注)]
        /// │└ArrayList
        /// │  └StockDetailWork        [仕入明細データ(複数)]
        /// │
        /// ├CustomSerializeArrayList   [発注計上された仕入データ群]
        /// │├StockSlipWork            [仕入データ(仕入形式=0:仕入)]
        /// │├ArrayList
        /// ││└StockDetailWork        [仕入明細データ(複数)]
        /// │└ArrayList
        /// │  └SlipDetailAddInfoWork  [伝票明細追加情報(複数)]
        /// │
        /// └CustomSerializeArrayList   [在庫調整データ(1伝票分)]
        ///   ├ArrayList
        ///   │└StockAdjustWork        [在庫調整データ(必ず1件分)]
        ///   └ArrayList
        ///     └StockAdjustDtlWork     [在庫調整明細データ(複数)]
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object uoeStcUpdDataList);

        /*
        /// <summary>
        /// 単一のUOE入庫更新情報を取得します。
        /// </summary>
        /// <param name="uoeStockUpdateObj">UOEStockUpdateWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE入庫更新のキー値が一致するUOE入庫更新情報を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMUOE01207D", "Broadleaf.Application.Remoting.ParamData.UOEStockUpdateWork")]
            ref object uoeStockUpdateObj,
            int readMode);

        /// <summary>
        /// UOE入庫更新情報を物理削除します
        /// </summary>
        /// <param name="uoeStockUpdateList">物理削除するUOE入庫更新情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE入庫更新のキー値が一致するUOE入庫更新情報を物理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMUOE01207D", "Broadleaf.Application.Remoting.ParamData.UOEStockUpdateWork")]
            object uoeStockUpdateList);

        /// <summary>
        /// UOE入庫更新情報を追加・更新します。
        /// </summary>
        /// <param name="uoeStockUpdateList">追加・更新するUOE入庫更新情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeStockUpdateList に格納されているUOE入庫更新情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMUOE01207D", "Broadleaf.Application.Remoting.ParamData.UOEStockUpdateWork")]
            ref object uoeStockUpdateList);

        /// <summary>
        /// UOE入庫更新情報を論理削除します。
        /// </summary>
        /// <param name="uoeStockUpdateList">論理削除するUOE入庫更新情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeStockUpdateWork に格納されているUOE入庫更新情報を論理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE01207D", "Broadleaf.Application.Remoting.ParamData.UOEStockUpdateWork")]
            ref object uoeStockUpdateList);

        /// <summary>
        /// UOE入庫更新情報の論理削除を解除します。
        /// </summary>
        /// <param name="uoeStockUpdateList">論理削除を解除するUOE入庫更新情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeStockUpdateWork に格納されているUOE入庫更新情報の論理削除を解除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE01207D","Broadleaf.Application.Remoting.ParamData.UOEStockUpdateWork")]
            ref object uoeStockUpdateList);
        */
    }
}
