//============================================================================//
// システム         : PM.NS
// プログラム名称   : 得意先マスタリモートインターフェース
// プログラム概要   : 得意先マスタリモートオブジェクトを取得します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 10402071-00  作成担当 : 21112
// 作 成 日  2008/04/23  修正内容 : SFTOK01132O をベースにPM.NS用を作成
//----------------------------------------------------------------------------//
// 管理番号 10970681-00  作成担当：陳健
// 修正日   K2014/02/06  修正内容：前橋京和商会個別 得意先マスタ改良対応
// -------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 得意先DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21112</br>
	/// <br>Date       : 2008.04.23</br>
	/// <br></br>
    /// <br>Update Note: 物理削除処理追加</br>
    /// <br>Programmer : 23015 森本 大輝</br>
    /// <br>Date       : 2008.09.02</br>
    /// <br></br>
    /// <br>Update Note: 得意先情報関連メモマスタの検索処理、登録処理、更新処理、論理削除処理追加</br>
    /// <br>Programmer : 陳健</br>
    /// <br>Date       : K2014/02/06</br>
    /// <br></br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface ICustomerInfoDB
	{
		/// <summary>
		/// 得意先情報関連マスタ読込処理
		/// </summary>
		/// <param name="paraList">CustomSerializeList</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 検索パラメータの得意先情報関連マスタを戻します</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2008.04.23</br>
		/// </remarks>
		[MustCustomSerialization]
		int Read(
			[CustomSerializationMethodParameterAttribute("SFCMN00021C","Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList);						

		/// <summary>
		/// 得意先情報関連マスタ読込処理
		/// </summary>
		/// <param name="logicalMode">論理削除区分</param>
		/// <param name="paraList">CustomSerializeList</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 検索パラメータの得意先情報関連マスタを戻します</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2008.04.23</br>
		/// </remarks>
        [MustCustomSerialization]
        int Read(
            ConstantManagement.LogicalMode logicalMode,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList);
        // ADD 陳健 K2014/02/06 ------------------------------------->>>>>
        /// <summary>
        /// 得意先情報関連マスタメモ読込処理
        /// </summary>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検索パラメータの得意先情報関連マスタを戻します</br>
        /// <br>Programmer : 陳健</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        [MustCustomSerialization]
        int MaehashiRead(
            ConstantManagement.LogicalMode logicalMode,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList);

        /// <summary>
        /// 得意先情報関連マスタ登録処理
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <param name="duplicationItemList">重複エラー時の重複項目</param>
        /// <param name="carMngNo">得意先と車両を同時登録する際の車両管理番号</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先情報関連マスタを登録、更新します</br>
        /// <br>Programmer : 陳健</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        [MustCustomSerialization]
        int MaehashiWrite(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList, out ArrayList duplicationItemList, int carMngNo);

        /// <summary>
        /// 得意先情報関連マスタメモ論理削除処理
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <param name="carDeleteFlg">車両削除フラグ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先情報関連マスタを論理削除します</br>
        /// <br>Programmer : 陳健</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        [MustCustomSerialization]
        int MaehashiLogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList, bool carDeleteFlg);

        /// <summary>
        /// 得意先情報関連マスタメモ物理削除処理
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先情報関連マスタタメを物理削除します</br>
        /// <br>Programmer : 陳健</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        int MaehashiDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object paraList);

        /// <summary>
        /// 得意先情報関連マスタメモ論理削除復活処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタと得意先メモDBの論理削除デーを復活します</br>
        /// <br>Programmer : 陳健</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        [MustCustomSerialization]
        int MaehashiRevivalLogicalDelete(string enterpriseCode, int customerCode);
        // ADD 陳健 K2014/02/06 -------------------------------------<<<<<

		// ADD 2009.01.19 >>>
        /// <summary>
        /// 得意先情報関連マスタ読込処理
        /// </summary>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検索パラメータの得意先情報関連マスタを戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2009.01.19</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            ConstantManagement.LogicalMode logicalMode,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList);
        // ADD 2009.01.19 <<<

		/// <summary>
		/// 得意先情報関連マスタ登録処理
		/// </summary>
		/// <param name="paraList">CustomSerializeList(得意先マスタ、備考マスタ、家族構成マスタ)</param>
		/// <param name="duplicationItemList">重複エラー時の重複項目</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 得意先情報関連マスタを登録、更新します</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2008.04.23</br>
		/// </remarks>
		[MustCustomSerialization]
		int Write(
			[CustomSerializationMethodParameterAttribute("SFCMN00021C","Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList, out ArrayList duplicationItemList);

		/// <summary>
		/// 得意先情報関連マスタ登録処理
		/// </summary>
		/// <param name="paraList">CustomSerializeList</param>
		/// <param name="duplicationItemList">重複エラー時の重複項目</param>
		/// <param name="carMngNo">得意先と車両を同時登録する際の車両管理番号</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 得意先情報関連マスタを登録、更新します</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2008.04.23</br>
		/// </remarks>
		[MustCustomSerialization]
		int Write(
			[CustomSerializationMethodParameterAttribute("SFCMN00021C","Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList, out ArrayList duplicationItemList, int carMngNo);

        // --- ADD 2008/09/02 ---------->>>>>
        /// <summary>
        /// 得意先情報関連マスタ物理削除処理
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先情報関連マスタを物理削除します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.02</br>
        /// </remarks>
        int Delete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object paraList);
        // --- ADD 2008/09/02 ----------<<<<<

		/// <summary>
		/// 得意先情報関連マスタ論理削除処理
		/// </summary>
		/// <param name="paraList">CustomSerializeList</param>
		/// <param name="carDeleteFlg">車両削除フラグ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 得意先情報関連マスタを論理削除します</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2008.04.23</br>
		/// </remarks>
		[MustCustomSerialization]
		int LogicalDelete(			
			[CustomSerializationMethodParameterAttribute("SFCMN00021C","Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList, bool carDeleteFlg);

		/// <summary>
		/// 得意先マスタ削除チェック処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="message">メッセージ</param>
		/// <param name="checkFlg">チェック結果[true:削除ＯＫ][false:削除ＮＧ]</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 得意先マスタの削除チェック処理を行います</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2008.04.23</br>
		/// </remarks>
		int DeleteCheck(string enterpriseCode, int customerCode, out string message, out bool checkFlg);

		/// <summary>
		/// 得意先マスタ存在チェック処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="logicalMode">論理削除区分</param>
		/// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタの存在チェック処理を行います</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        int ExistData(string enterpriseCode, int customerCode, ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 得意先マスタ論理削除復活処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 得意先マスタの論理削除デーを復活します</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2008.04.23</br>
		/// </remarks>
		[MustCustomSerialization]
		int RevivalLogicalDelete(string enterpriseCode, int customerCode);

		/// <summary>
		/// 更新日チェック処理
		/// </summary>
		/// <param name="updateDateTime">更新日</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>true:変更有り false:変更無し</returns>
		/// <remarks>
		/// <br>Note       : 得意先マスタの更新日が変更されているかどうかをチェックします</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2006.06.15</br>
		/// </remarks>
		bool IsUpdateDateTimeChange(DateTime updateDateTime, string enterpriseCode, int customerCode);

		/// <summary>
		/// 得意先名称取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCodeArray">得意先コード配列</param>
		/// <param name="nameTable">名称Hashtable</param>
		/// <param name="name2Table">名称2Hashtable</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 得意先コードを複数指定し、名称と名称２をHashtableで取得します</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2006.06.28</br>
		/// </remarks>
		int GetName(string enterpriseCode, int[] customerCodeArray, out Hashtable nameTable, out Hashtable name2Table);

        // --- ADD 2010/09/26 ---------->>>>>
		/// <summary>
        /// 得意先マスタのALL読込
        /// </summary>
        /// <param name="paraObj">検索Para</param>
        /// <param name="customerWorkList">検索結果</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタをALL読込します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(object paraObj, out object customerWorkList);
        // --- ADD 2010/09/26 ----------<<<<<
	}
}
