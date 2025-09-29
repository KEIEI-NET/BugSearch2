using System;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 自由帳票印字項目DBRemoteObjectインターフェース	
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票印字項目 RemoteObject Interfaceです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.05.10</br>
	/// <br></br>
	/// <br>Update Note	: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IFrePrtPSetDB
	{
		/// <summary>
		/// ログ出力処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="employeeCode">従業員コード</param>
		/// <param name="logMessage">ログメッセージ</param>
		/// <remarks>
		/// <br>Note		: 指定されたログメッセージを保存します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		void WriteLog(string enterpriseCode, string employeeCode, string logMessage);

		/// <summary>
		/// 最終ユーザー帳票ID枝番号取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="outputFormFileName">出力ファイル名</param>
		/// <returns>最終ユーザー帳票ID枝番号</returns>
		/// <remarks>
		/// <br>Note		: 指定された自由帳票印字位置情報の最終枝番号を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		int GetLastUserPrtPprIdDerivNo(string enterpriseCode, string outputFormFileName);

			/// <summary>
		/// 自由帳票抽出条件明細マスタ取得処理（全件）
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="frePExCndDWorkArray">自由帳票抽出条件明細ワークマスタ配列</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 自由帳票抽出条件明細ワークマスタ配列を全件取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		[MustCustomSerialization]
		int SearchFrePExCndD(
			string enterpriseCode,
			ConstantManagement.LogicalMode logicalMode,
			[CustomSerializationMethodParameterAttribute("SFANL08123D", "Broadleaf.Application.Remoting.ParamData.FrePExCndDWork")]
			out object frePExCndDWorkArray,
			out bool msgDiv,
			out string errMsg
			);

		/// <summary>
		/// 自由帳票印字位置情報取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="outputFormFileName">出力ファイル名</param>
		/// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番号</param>
		/// <param name="retCustomSerializeArrayList">自由帳票印字位置情報カスタムシリアライズLIST</param>
		/// <param name="printPosClassData">印字位置データ</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された自由帳票印字位置情報を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		[MustCustomSerialization]
		int Read(
			string enterpriseCode,
			string outputFormFileName,
			int userPrtPprIdDerivNo,
			[CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object retCustomSerializeArrayList,
			out byte[] printPosClassData,
			out bool msgDiv,
			out string errMsg
			);

		/// <summary>
		/// 自由帳票項目設定マスタ書込処理
		/// </summary>
		/// <param name="saveCustomSerializeArrayList">自由帳票印字位置情報カスタムシリアライズLIST</param>
		/// <param name="printPosClassData">印字位置データ</param>
		/// <param name="isNewWrite">新規登録</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された自由帳票印字位置情報を登録します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		[MustCustomSerialization]
		int Write(
			[CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object saveCustomSerializeArrayList,
			byte[] printPosClassData,
			bool isNewWrite,
			out bool msgDiv,
			out string errMsg
			);
	}
}
