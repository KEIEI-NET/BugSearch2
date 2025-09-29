using System;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 自由帳票印字項目DBRemoteObjectインターフェース	
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票印字項目 RemoteObject Interfaceです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.05.07</br>
	/// <br></br>
	/// <br>Update Note	: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IPrtItemSetDB
	{
		/// <summary>
		/// 自由帳票項目グループマスタ取得処理（全件）
		/// </summary>
		/// <param name="prtItemGrpWorkArray">自由帳票項目グループマスタ配列</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <br>Note		: 自由帳票項目グループマスタ配列を全件取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.07</br>
		[MustCustomSerialization]
		int SearchPrtItemGrp(
			[CustomSerializationMethodParameterAttribute("SFTKD08113D", "Broadleaf.Application.Remoting.ParamData.PrtItemGrpWork")]
			out object prtItemGrpWorkArray,
			out bool msgDiv,
			out string errMsg
			);

		/// <summary>
		/// 自由帳票項目設定マスタ取得処理
		/// </summary>
		/// <param name="freePrtPprItemGrpCd">自由帳票項目グループコード</param>
		/// <param name="retCustomSerializeArrayList">印字項目情報カスタムシリアライズLIST</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <br>Note		: 指定された自由帳票項目設定マスタ配列を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.07</br>
		[MustCustomSerialization]
		int SearchPrtItemSet(
			int freePrtPprItemGrpCd,
			[CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object retCustomSerializeArrayList,
			out bool msgDiv,
			out string errMsg
			);

		/// <summary>
		/// 自由帳票項目設定マスタ取得処理
		/// </summary>
		/// <param name="freePrtPprItemGrpCd">自由帳票項目グループコード</param>
		/// <param name="freePrtPprSchmGrpCd">自由帳票スキーマグループコード</param>
		/// <param name="retCustomSerializeArrayList">印字項目情報カスタムシリアライズLIST</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <br>Note		: 指定された自由帳票項目設定マスタ配列を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.07</br>
		[MustCustomSerialization]
		int SearchPrtItemSetWithFPprSchmCv(
			int freePrtPprItemGrpCd,
			int freePrtPprSchmGrpCd,
			[CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object retCustomSerializeArrayList,
			out bool msgDiv,
			out string errMsg
			);
	}
}
