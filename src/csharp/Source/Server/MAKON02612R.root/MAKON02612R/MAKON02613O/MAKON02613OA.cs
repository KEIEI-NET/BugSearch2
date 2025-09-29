using System;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 買掛情報取得 DBRemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 買掛情報取得 DBRemoteObject Interfaceです。</br>
	/// <br>Programmer : 22035 三橋 弘憲</br>
	/// <br>Date       : 2007.05.14</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface ISuplAccInfGetDB
	{
		/// <summary>
		/// 買掛情報取得処理(伝票):カスタムシリアライズ
		/// </summary>
		/// <param name="objSuplAccInfGetWorkList">仕入先買掛金額クラスワークリスト</param>
        /// <param name="objLedgerStockSlipWorkList">仕入情報リスト</param>
        /// <param name="objLedgerPaymentSlpWorkList">支払伝票情報リスト</param>
		/// <param name="objSuplAccInfGetParameter">買掛金額情報取得抽出条件パラメータクラス</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で仕入先情報を取得します。
		///                : 主に仕入先元帳にて使用します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.05.14</br>
		[MustCustomSerialization]
        int SearchSlip(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objSuplAccInfGetWorkList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerStockSlipWorkList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerPaymentSlpWorkList,
			SuplAccInfGetParameter objSuplAccInfGetParameter);

        /// <summary>
        /// 買掛情報取得処理(伝票):カスタムシリアライズ
        /// </summary>
        /// <param name="objSuplAccInfGetWorkList">仕入先買掛金額クラスワークリスト</param>
        /// <param name="objLedgerStockSlipWorkList">仕入情報リスト</param>
        /// <param name="objLedgerPaymentSlpWorkList">支払伝票情報リスト</param>
        /// <param name="objSuplAccInfGetParameter">買掛金額情報取得抽出条件パラメータクラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で仕入先情報を取得します。
        ///                : 主に仕入先元帳にて使用します。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.14</br>
        [MustCustomSerialization]
        int SearchDtl(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objSuplAccInfGetWorkList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerStockSlipWorkList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerPaymentSlpWorkList,
            SuplAccInfGetParameter objSuplAccInfGetParameter);

        // --- ADD 2012/10/02 ---------->>>>>
        #region 仕入先総括
        /// <summary>
        /// 買掛情報取得処理(伝票):カスタムシリアライズ
        /// </summary>
        /// <param name="objSuplAccInfGetWorkList">仕入先買掛金額クラスワークリスト</param>
        /// <param name="objLedgerStockSlipWorkList">仕入情報リスト</param>
        /// <param name="objLedgerPaymentSlpWorkList">支払伝票情報リスト</param>
        /// <param name="objSuplAccInfGetParameter">買掛金額情報取得抽出条件パラメータクラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で仕入先情報を取得します。
        ///                : 主に仕入先元帳にて使用します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/10/02</br>
        [MustCustomSerialization]
        int SearchSlipSumSupp(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objSuplAccInfGetWorkList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerStockSlipWorkList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerPaymentSlpWorkList,
            SuplAccInfGetParameter objSuplAccInfGetParameter);

        /// <summary>
        /// 買掛情報取得処理(伝票):カスタムシリアライズ
        /// </summary>
        /// <param name="objSuplAccInfGetWorkList">仕入先買掛金額クラスワークリスト</param>
        /// <param name="objLedgerStockSlipWorkList">仕入情報リスト</param>
        /// <param name="objLedgerPaymentSlpWorkList">支払伝票情報リスト</param>
        /// <param name="objSuplAccInfGetParameter">買掛金額情報取得抽出条件パラメータクラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で仕入先情報を取得します。
        ///                : 主に仕入先元帳にて使用します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/10/02</br>
        [MustCustomSerialization]
        int SearchDtlSumSupp(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objSuplAccInfGetWorkList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerStockSlipWorkList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object objLedgerPaymentSlpWorkList,
            SuplAccInfGetParameter objSuplAccInfGetParameter);
        #endregion
        // --- ADD 2012/10/02 ----------<<<<<
    }
}
