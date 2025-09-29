using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 在庫管理全体設定マスタDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫管理全体設定マスタDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 20036　斉藤　雅明</br>
	/// <br>Date       : 2007.03.02</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IStockMngTtlStDB
	{

		/// <summary>
		/// 指定された在庫管理全体設定マスタGuidの在庫管理全体設定マスタを戻します
		/// </summary>
		/// <param name="parabyte">StockMngTtlStWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された在庫管理全体設定マスタGuidの在庫管理全体設定マスタを戻します</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.03.02</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// 在庫管理全体設定マスタ情報を物理削除します
		/// </summary>
		/// <param name="parabyte">StockMngTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫管理全体設定マスタ情報を物理削除します</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.03.02</br>
		int Delete(byte[] parabyte);

		#region カスタムシリアライズ対応メソッド
		/// <summary>
		/// 在庫管理全体設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="stockmngttlstWork">検索結果</param>
		/// <param name="parastockmngttlstWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.03.02</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("MAZAI09116D","Broadleaf.Application.Remoting.ParamData.StockMngTtlStWork")]
			out object stockmngttlstWork,
			object parastockmngttlstWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 在庫管理全体設定マスタ情報を登録、更新します
		/// </summary>
		/// <param name="stockmngttlstWork">StockMngTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫管理全体設定マスタ情報を登録、更新します</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.03.02</br>
        [MustCustomSerialization]
        int Write(
			[CustomSerializationMethodParameterAttribute("MAZAI09116D","Broadleaf.Application.Remoting.ParamData.StockMngTtlStWork")]
			ref object stockmngttlstWork
			);

		/// <summary>
		/// 在庫管理全体設定マスタ情報を論理削除します
		/// </summary>
		/// <param name="stockmngttlstWork">StockMngTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫管理全体設定マスタ情報を論理削除します</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.03.02</br>
        [MustCustomSerialization]
        int LogicalDelete(
			[CustomSerializationMethodParameterAttribute("MAZAI09116D","Broadleaf.Application.Remoting.ParamData.StockMngTtlStWork")]
			ref object stockmngttlstWork
			);

		/// <summary>
		/// 論理削除在庫管理全体設定マスタ情報を復活します
		/// </summary>
		/// <param name="stockmngttlstWork">StockMngTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除在庫管理全体設定マスタ情報を復活します</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.03.02</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
			[CustomSerializationMethodParameterAttribute("MAZAI09116D","Broadleaf.Application.Remoting.ParamData.StockMngTtlStWork")]
			ref object stockmngttlstWork
			);
		#endregion
	}
}
