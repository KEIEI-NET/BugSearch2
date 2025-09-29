using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
	#region 共通化メソッド
	/// <summary>
	/// 金額種別設定DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 金額種別設定DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21052　山田　圭</br>
	/// <br>Date       : 2005.05.09</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IMoneyKindDB
	{
		/// <summary>
		/// 指定された企業コードの金額種別設定LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="getdatatype">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode, GetMoneyKindDataType getdatatype);
		
		/// <summary>
		/// 金額種別設定LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="getdatatype">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		int Search(
            out byte[] retbyte,
            byte[] parabyte,
            int readMode,
            ConstantManagement.LogicalMode logicalMode,
            GetMoneyKindDataType getdatatype);

        /// <summary>
        /// 金額種別設定LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="getdatatype">取得対象データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2005.05.09</br>
        int Search(
            [CustomSerializationMethodParameterAttribute("SFUKK09046D", "Broadleaf.Application.Remoting.ParamData.MoneyKindWork")]
            out object retList,
            object paraWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode,
            GetMoneyKindDataType getdatatype);
        
        /// <summary>
		/// 指定された企業コードの金額種別設定LISTを指定件数分全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="parabyte">検索パラメータ（NextRead時は前回最終レコードクラス）</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">検索件数</param>		
		/// <param name="getdatatype">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt, GetMoneyKindDataType getdatatype);

		/// <summary>
		/// 指定された金額種別設定Guidの金額種別設定を戻します
		/// </summary>
		/// <param name="parabyte">MoneyKindWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="getdatatype">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された金額種別設定Guidの金額種別設定を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		int Read(ref byte[] parabyte , int readMode, GetMoneyKindDataType getdatatype);

		/// <summary>
		/// 金額種別設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">MoneyKindWorkオブジェクト</param>
		/// <param name="getdatatype">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 金額種別設定情報を登録、更新します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		int Write(ref byte[] parabyte, GetMoneyKindDataType getdatatype);

		/// <summary>
		/// 金額種別設定情報を物理削除します
		/// </summary>
		/// <param name="parabyte">MoneyKindWorkオブジェクト</param>
		/// <param name="getdatatype">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 金額種別設定情報を物理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		int Delete(byte[] parabyte, GetMoneyKindDataType getdatatype);

		/// <summary>
		/// 金額種別設定情報を論理削除します
		/// </summary>
		/// <param name="parabyte">MoneyKindWorkオブジェクト</param>
		/// <param name="getdatatype">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 金額種別設定情報を論理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		int LogicalDelete(ref byte[] parabyte, GetMoneyKindDataType getdatatype);

		/// <summary>
		/// 論理削除金額種別設定情報を復活します
		/// </summary>
		/// <param name="parabyte">MoneyKindWorkオブジェクト</param>
		/// <param name="getdatatype">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除金額種別設定情報を復活します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		int RevivalLogicalDelete(ref byte[] parabyte, GetMoneyKindDataType getdatatype);
	}
	#endregion

	#region 取得対象データ定数
	/// <summary>
	/// 取得対象データ定数
	/// </summary>
	/// <br>Note       : ガイド系マスタの取得対象データ定数です。</br>
	/// <br>Programmer : 21052　山田　圭</br>
	/// <br>Date       : 2005.05.09</br>
	public enum GetMoneyKindDataType
	{
		/// <summary>
		/// ボディデータ(ユーザー変更分)
		/// </summary>
		UserMoneyKindData = 1,
		/// <summary>
		/// ボディデータ(提供分)
		/// </summary>
		OfferMoneyKindData
	}
	#endregion
}
