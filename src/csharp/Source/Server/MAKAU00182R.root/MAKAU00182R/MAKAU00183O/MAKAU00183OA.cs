using System;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 売掛情報取得 DBRemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売掛情報取得 DBRemoteObject Interfaceです。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2007.05.08</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface ICustAccRecInfGetDB
	{
        /// <summary>
		/// 売掛情報取得処理:カスタムシリアライズ
		/// </summary>
		/// <param name="objCustAccRecInfGetWorkList">得意先売掛金額クラスワークリスト</param>
		/// <param name="objLedgerSalesSlipWorkList">売上情報リスト</param>
		/// <param name="objLedgerDepsitMainWorkList">入金情報リスト</param>
		/// <param name="custAccRecInfSearchParameter">売掛情報取得抽出条件パラメータクラス</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で得意先売掛情報を取得します。
		///                : 主に得意先元帳にて使用します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.05.08</br>
		[MustCustomSerialization]
		int SearchSlip(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objCustAccRecInfGetWorkList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerSalesSlipWorkList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerDepsitMainWorkList,
			CustAccRecInfSearchParameter custAccRecInfSearchParameter
			);

        /// <summary>
        /// 売掛情報取得処理(売上明細):カスタムシリアライズ
        /// </summary>
        /// <param name="objCustAccRecInfGetWorkList">得意先売掛金額クラスワークリスト</param>
        /// <param name="objLedgerSalesSlipWorkList">売上情報リスト</param>
        /// <param name="objLedgerDepsitMainWorkList">入金情報リスト</param>
        /// <param name="custAccRecInfSearchParameter">売掛情報取得抽出条件パラメータクラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で得意先売掛情報を取得します。
        ///                : 主に得意先元帳にて使用します。</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.04</br>
        [MustCustomSerialization]
        int SearchDtl(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objCustAccRecInfGetWorkList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerSalesSlipWorkList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerDepsitMainWorkList,
            CustAccRecInfSearchParameter custAccRecInfSearchParameter
            );
	}
}
