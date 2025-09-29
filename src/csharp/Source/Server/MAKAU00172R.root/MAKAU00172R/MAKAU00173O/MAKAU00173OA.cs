using System;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 請求情報取得 DBRemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 請求情報取得 DBRemoteObject Interfaceです。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2007.05.08</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface ICustDmdPrcInfGetDB
	{
        /// <summary>
        /// 請求情報取得処理:カスタムシリアライズ
        /// </summary>
        /// <param name="objCustDmdPrcInfGetWorkList">得意先請求金額クラスワークリスト</param>
        /// <param name="objLedgerSalesSlipWorkList">売上情報リスト</param>
        /// <param name="objLedgerDepsitMainWorkList">入金情報リスト</param>
        /// <param name="custDmdPrcInfSearchParameter">請求情報取得抽出条件パラメータクラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で得意先請求情報を取得します。
        ///                : 主に得意先元帳にて使用します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.05.08</br>
        [MustCustomSerialization]
        int SearchSlip(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objCustDmdPrcInfGetWorkList,
           [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerSalesSlipWorkList,
           [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerDepsitMainWorkList,
            CustDmdPrcInfSearchParameter custDmdPrcInfSearchParameter
            );

        /// <summary>
        /// 請求情報取得処理:カスタムシリアライズ
        /// </summary>
        /// <param name="objCustDmdPrcInfGetWorkList">得意先請求金額クラスワークリスト</param>
        /// <param name="objLedgerSalesSlipWorkList">売上情報リスト</param>
        /// <param name="objLedgerDepsitMainWorkList">入金情報リスト</param>
        /// <param name="custDmdPrcInfSearchParameter">請求情報取得抽出条件パラメータクラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で得意先請求情報を取得します。
        ///                : 主に得意先元帳にて使用します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.05.08</br>
        [MustCustomSerialization]
        int SearchDtl(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objCustDmdPrcInfGetWorkList,
           [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerSalesSlipWorkList,
           [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerDepsitMainWorkList,
            CustDmdPrcInfSearchParameter custDmdPrcInfSearchParameter
            );
    }
}
