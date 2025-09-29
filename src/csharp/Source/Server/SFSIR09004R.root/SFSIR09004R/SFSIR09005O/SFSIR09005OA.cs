using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 仕入在庫全体設定DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入在庫全体設定DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21052　山田　圭</br>
	/// <br>Date       : 2005.04.12</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IStockTtlStDB
	{
		#region 基底クラスを使ったメソッド
		//		/// <summary>
		//		/// 指定された企業コードの自社情報LISTを全て戻します
		//		/// </summary>
		//		/// <param name="retbyte">検索結果</param>
		//		/// <param name="parabyte">検索パラメータ</param>
		//		/// <param name="readMode">検索区分</param>
		//		/// <param name="readCnt">READ件数（0の場合はALL）</param>
		//		/// <returns>STATUS</returns>
		//		/// <br>Note       : 指定された企業コードの自社情報LISTを全て戻します</br>
		//		/// <br>Programmer : 21052　山田　圭</br>
		//		/// <br>Date       : 2005.04.13</br>
		//		int Search(out byte[] retbyte,byte[] parabyte, int readMode,int readCnt);
		//
		//		/// <summary>
		//		/// 指定された企業コードの自社情報設定を戻します
		//		/// </summary>
		//		/// <param name="parabyte">PaymentSetWorkオブジェクト</param>
		//		/// <param name="readMode">検索区分</param>
		//		/// <returns>STATUS</returns>
		//		/// <br>Note       : 指定された企業コードの自社情報設定を戻します</br>
		//		/// <br>Programmer : 21052　山田　圭</br>
		//		/// <br>Date       : 2005.04.13</br>
		//		int Read(ref byte[] parabyte , int readMode);
		//
		//		/// <summary>
		//		/// 自社情報設定情報を登録、更新します
		//		/// </summary>
		//		/// <param name="parabyte">PaymentSetWorkオブジェクト</param>
		//		/// <param name="writeMode">登録、更新モード</param>
		//		/// <returns>STATUS</returns>
		//		/// <br>Note       : 自社情報設定情報を登録、更新します</br>
		//		/// <br>Programmer : 21052　山田　圭</br>
		//		/// <br>Date       : 2005.04.13</br>
		//		int Write(ref byte[] parabyte, int writeMode);
		//
		//		/// <summary>
		//		/// 自社情報を論理削除します
		//		/// </summary>
		//		/// <param name="parabyte">PaymentSetWorkオブジェクト</param>
		//		/// <param name="deleteMode">削除モード</param>
		//		/// <returns>STATUS</returns>
		//		/// <br>Note       : 自社情報を論理削除します</br>
		//		/// <br>Programmer : 21052　山田　圭</br>
		//		/// <br>Date       : 2005.04.13</br>
		//		int LogicalDelete(ref byte[] parabyte, int deleteMode);
		//		
		//		/// <summary>
		//		/// 自社情報を物理削除します
		//		/// </summary>
		//		/// <param name="parabyte">自社情報オブジェクト</param>
		//		/// <param name="deleteMode">削除モード</param>
		//		/// <returns></returns>
		//		/// <br>Note       : 自社情報を物理削除します</br>
		//		/// <br>Programmer : 21052　山田　圭</br>
		//		/// <br>Date       : 2005.04.13</br>
		//		int Delete(byte[] parabyte, int deleteMode);
		#endregion
        
        #region 
        /*
		/// <summary>
		/// 指定された企業コードの仕入在庫全体設定LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.12</br>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// 仕入在庫全体設定LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.12</br>
		int Search(out byte[] retbyte, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 指定された企業コードの仕入在庫全体設定LISTを指定件数分全て戻します（論理削除除く）
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
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.12</br>
		int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt);
        */ 
        #endregion

        /// <summary>
        /// 仕入全体設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008  長内 数馬</br>
        /// <br>Date       : 2008.06.03</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFSIR09006D", "Broadleaf.Application.Remoting.ParamData.StockTtlStWork")]
            out object retList, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);
        
		/// <summary>
		/// 指定された仕入在庫全体設定Guidの仕入在庫全体設定を戻します
		/// </summary>
		/// <param name="parabyte">StockTtlStWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された仕入在庫全体設定Guidの仕入在庫全体設定を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.12</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// 仕入在庫全体設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">StockTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 仕入在庫全体設定情報を登録、更新します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.12</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// 仕入在庫全体設定情報を物理削除します
		/// </summary>
		/// <param name="parabyte">StockTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 仕入在庫全体設定情報を物理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.12</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// 仕入在庫全体設定情報を論理削除します
		/// </summary>
		/// <param name="parabyte">StockTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 仕入在庫全体設定情報を論理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.12</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// 論理削除仕入在庫全体設定情報を復活します
		/// </summary>
		/// <param name="parabyte">StockTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除仕入在庫全体設定情報を復活します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.12</br>
		int RevivalLogicalDelete(ref byte[] parabyte);
	}
}
