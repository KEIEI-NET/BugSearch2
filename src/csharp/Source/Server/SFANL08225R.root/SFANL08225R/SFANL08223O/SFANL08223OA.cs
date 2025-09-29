using System;
using System.Collections;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 自由帳票グループDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自由帳票グループDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 22011 柏原　頼人</br>
	/// <br>Date       : 2007.05.22</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示

    public interface IFreePprGrpDB
	{
		#region 自由帳票グループ
        /// <summary>
        /// 自由帳票グループLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchFreePprGrp(
            [CustomSerializationMethodParameterAttribute("SFANL08224D", "Broadleaf.Application.Remoting.ParamData.FreePprGrpWork")]
            out object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg);

        /// <summary>
		/// 指定された企業コードの自由帳票グループLISTを全て戻します
		/// </summary>
		/// <param name="retList">検索結果</param>
		/// <param name="freePprGrpWork">検索条件</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="sqlConnection">コネクション情報</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        int SearchFreePprGrp(out ArrayList retList, FreePprGrpWork freePprGrpWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, out bool msgDiv, out string errMsg);
		
        /// <summary>
		/// 指定された自由帳票グループGuidの自由帳票グループを戻します
		/// </summary>
		/// <param name="parabyte">WorkerWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        int ReadFreePprGrp(ref byte[] parabyte, int readMode, out bool msgDiv, out string errMsg);

		/// <summary>
		/// 自由帳票グループ情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">WorkerWorkオブジェクト</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        int WriteFreePprGrp(ref byte[] parabyte, out bool msgDiv, out string errMsg);

        /// <summary>
		/// 自由帳票グループ情報を物理削除します
		/// </summary>
		/// <param name="parabyte1">自由帳票グループオブジェクト</param>
		/// <param name="parabyte2">自由帳票グループ振替オブジェクト</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STASUS</returns>
        int DeleteFreePprGrpAll(ref byte[] parabyte1, ref byte[] parabyte2, out bool msgDiv, out string errMsg);

		/// <summary>
		/// 自由帳票グループマスタ削除チェック処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="freePrtPprGroupCd">自由帳票グループコード</param>
		/// <param name="message">メッセージ</param>
		/// <param name="checkFlg">チェック結果[true:削除ＯＫ][false:削除ＮＧ]</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        int DeleteCheck(string enterpriseCode, Int32 freePrtPprGroupCd, out string message, out bool checkFlg, out bool msgDiv, out string errMsg);
		
		#endregion

		#region 自由帳票グループ振替

        /// <summary>
        /// 指定された企業コード＆自由帳票グループコードの自由帳票グループLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retbyte">検索結果(FrePprGrTrWorkの配列)</param>
        /// <param name="parabyte">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        int SearchFrePprGrTr(out byte[] retbyte, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg);

        /// <summary>
        /// 指定された企業コード＆自由帳票グループコードの自由帳票グループ振替LISTを全て戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="enterpriseCode">検索用企業コード</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchFrePprGrTrAll(
            [CustomSerializationMethodParameterAttribute("SFANL08224D", "Broadleaf.Application.Remoting.ParamData.FrePprGrTrWork")]
            out object retObj, string enterpriseCode, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg);

        /// <summary>
        /// 指定された自由帳票グループ振替Guidの自由帳票グループ振替を戻します
        /// </summary>
        /// <param name="parabyte">WorkerWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        int ReadFrePprGrTr(ref byte[] parabyte, int readMode, out bool msgDiv, out string errMsg);

        /// <summary>
        /// 自由帳票グループ振替情報を登録、更新します
        /// </summary>
        /// <param name="paraobj">FrePprGrTrWorkリストのオブジェクト</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        int WriteFrePprGrTr(ref object paraobj, out bool msgDiv, out string errMsg);

        /// <summary>
        /// 自由帳票グループ振替情報を全グループに登録します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="displayName">出力名称</param>
        /// <param name="outputFormFileName">出力ファイル名</param>
        /// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番号</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="Sqltrance">トランザクション情報</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>ステータス</returns>
        int EntryFrePprGrTr(string enterpriseCode, string displayName, string outputFormFileName, Int32 userPrtPprIdDerivNo, SqlConnection sqlConnection, SqlTransaction Sqltrance,out bool msgDiv, out string errMsg);
        
        // DEL 2007.06.08
        ///// <summary>
        ///// 自由帳票グループ情報と自由帳票グループ振替全てを登録、更新します
        ///// </summary>
        ///// <param name="parabyte1">FreePprGrpWork  オブジェクト</param>
        ///// <param name="parabyte2">FrePprGrTrWorkオブジェクト</param>
        ///// <param name="msgDiv">メッセージ有無区分</param>
        ///// <param name="errMsg">エラーメッセージ文字列</param>
        ///// <returns>STATUS</returns>
        //int WriteFreePprGrpAndDtl(ref byte[] parabyte1, ref byte[] parabyte2, out bool msgDiv, out string errMsg);

        ///// <summary>
        ///// 自由帳票グループ振替を削除し登録します
        ///// </summary>
        ///// <param name="parabyte1">削除する自由帳票グループ振替LIST</param>
        ///// <param name="parabyte2">登録する自由帳票グループ振替LIST</param>
        ///// <returns>STATUS</returns>
        //int DtlDeleteAndWrite(ref byte[] parabyte1, ref byte[] parabyte2);

        /// <summary>
        /// 自由帳票グループ振替情報を物理削除します（複数レコードレコード）
        /// </summary>
        /// <param name="parabyte">FrePprGrTrWorkオブジェクト</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        int DtlDelete(byte[] parabyte, out bool msgDiv, out string errMsg);

        #endregion
    }
}
