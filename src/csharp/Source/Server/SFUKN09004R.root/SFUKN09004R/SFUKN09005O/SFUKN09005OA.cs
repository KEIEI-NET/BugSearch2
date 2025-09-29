using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 自社情報設定DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自社情報設定DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
        /// <br>Update Note: データクリア時間処理追加</br>
        /// <br>Programmer : LDNS wangqx</br>
        /// <br>Date       : 2011.07.14</br>
	/// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示

	public interface ICompanyInfDB
	{

		/// <summary>
		/// 指定された企業コードの自社情報設定LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// 自社情報設定LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int Search(out byte[] retbyte, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 指定された企業コードの自社情報設定LISTを指定件数分全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="parabyte">検索パラメータ（NextRead時は前回最終レコードクラス）</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">検索件数</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt);

		/// <summary>
		/// 指定された自社情報設定Guidの自社情報設定を戻します
		/// </summary>
		/// <param name="parabyte">CompanyInfWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された自社情報設定Guidの自社情報設定を戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int Read(ref byte[] parabyte , int readMode);

        /// <summary>
        /// 指定された自社情報設定Guidの自社情報設定を戻します
        /// </summary>
        /// <param name="paraobj">CompanyInfWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された自社情報設定Guidの自社情報設定を戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2005.03.24</br>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("SFUKN09006D", "Broadleaf.Application.Remoting.ParamData.CompanyInfWork")]
            ref object paraobj, int readMode);
        
        /// <summary>
		/// 自社情報設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">CompanyInfWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 自社情報設定情報を登録、更新します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// 自社情報設定情報を物理削除します
		/// </summary>
		/// <param name="parabyte">CompanyInfWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 自社情報設定情報を物理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// 自社情報設定情報を論理削除します
		/// </summary>
		/// <param name="parabyte">CompanyInfWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 自社情報設定情報を論理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// 論理削除自社情報設定情報を復活します
		/// </summary>
		/// <param name="parabyte">CompanyInfWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除自社情報設定情報を復活します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int RevivalLogicalDelete(ref byte[] parabyte);

        // -- ADD 2011/07/14 ------------------------------------------->>>
        /// <summary>
        /// 自社情報にデータクリア時間更新します
        /// </summary>
        /// <param name="paraobj">更新条件</param>
        /// <param name="DelYMD">データクリア年月日</param>
        /// <param name="DelHMSXXX">データクリア時分秒ミリ秒</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 自社情報にデータクリア時間更新します</br>
        /// <br>Programmer : LDNS wangqx</br>
        /// <br>Date       : 2011.07.14</br>
        int WriteClearTime(
            [CustomSerializationMethodParameterAttribute("SFUKN09006D", "Broadleaf.Application.Remoting.ParamData.CompanyInfWork")]
            object paraobj, String DelYMD, String DelHMSXXX, out string errMsg);

        /// <summary>
        /// 指定された企業コードのデータクリア時間を戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="DelYMD">データクリア年月日</param>
        /// <param name="DelHMSXXX">データクリア時分秒ミリ秒</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのデータクリア時間を戻します</br>
        /// <br>Programmer : LDNS wangqx</br>
        /// <br>Date       : 2011.07.14</br>
        int ReadClearTime(string enterpriseCode, out Int32 DelYMD, out Int32 DelHMSXXX);
        // -- ADD 2011/07/14 -------------------------------------------<<<
	}
}
