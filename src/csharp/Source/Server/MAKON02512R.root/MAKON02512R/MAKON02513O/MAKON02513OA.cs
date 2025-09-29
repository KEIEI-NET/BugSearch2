using System;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 支払情報取得 DBRemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 支払情報取得 DBRemoteObject Interfaceです。</br>
	/// <br>Programmer : 22035 三橋 弘憲</br>
	/// <br>Date       : 2007.05.11</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface ISuplierPayInfGetDB
	{
		/// <summary>
		/// 支払情報取得処理[鑑＋明細]:カスタムシリアライズ
		/// </summary>
		/// <param name="objSuplierPayInfGetWorkList">仕入先支払金額クラスワークリスト</param>
        /// <param name="objLedgerStockSlipWorkList">仕入情報リスト</param>
        /// <param name="objLedgerPaymentSlpWorkList">支払伝票情報リスト</param>
		/// <param name="objSuplierPayInfGetParameter">支払金額情報取得抽出条件パラメータクラス</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で仕入先情報を取得します。
		///                : 主に仕入先元帳にて使用します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.05.11</br>
		[MustCustomSerialization]
		int SearchSlip(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objSuplierPayInfGetWorkList,
           [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerStockSlipWorkList,
           [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerPaymentSlpWorkList,
           SuplierPayInfGetParameter objSuplierPayInfGetParameter
            );

        /// <summary>
        /// 支払情報取得処理[鑑＋明細(仕入明細込み)]:カスタムシリアライズ
        /// </summary>
        /// <param name="objSuplierPayInfGetWorkList">仕入先支払金額クラスワークリスト</param>
        /// <param name="objLedgerStockSlipWorkList">仕入情報リスト</param>
        /// <param name="objLedgerPaymentSlpWorkList">支払伝票情報リスト</param>
        /// <param name="objSuplierPayInfGetParameter">支払金額情報取得抽出条件パラメータクラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で仕入先情報を取得します。
        ///                : 主に仕入先元帳にて使用します。</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.04</br>
        [MustCustomSerialization]
        int SearchDtl(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objSuplierPayInfGetWorkList,
           [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerStockSlipWorkList,
           [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerPaymentSlpWorkList,
           SuplierPayInfGetParameter objSuplierPayInfGetParameter
            );
    }
}
