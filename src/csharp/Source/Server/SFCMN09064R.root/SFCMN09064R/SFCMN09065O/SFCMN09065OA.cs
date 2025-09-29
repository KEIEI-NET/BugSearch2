using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ユーザーガイドDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : ユーザーガイドDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IUserGdBdUDB
	{
		#region 共通化メソッド
		/// <summary>
		/// 指定された企業コードのユーザーガイド情報LISTの件数を戻します
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
		/// ユーザーガイド情報LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFCMN09066D","Broadleaf.Application.Remoting.ParamData.UserGdBdUWork")]
			out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 指定されたGuideDivCodeのユーザーガイド情報LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		[MustCustomSerialization]
		int SearchGuideDivCode(
			[CustomSerializationMethodParameterAttribute("SFCMN09066D","Broadleaf.Application.Remoting.ParamData.UserGdBdUWork")]
			out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 指定されたユーザーガイドGuidのユーザーガイド情報を戻します
		/// </summary>
		/// <param name="parabyte">OcrDefSetWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定されたユーザーガイドGuidのユーザーガイドを戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// ユーザーガイド情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">OcrDefSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ユーザーガイド情報を登録、更新します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// ユーザーガイド情報を物理削除します
		/// </summary>
		/// <param name="parabyte">OcrDefSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ユーザーガイド情報を物理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// ユーザーガイド情報を論理削除します
		/// </summary>
		/// <param name="parabyte">OcrDefSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ユーザーガイド情報を論理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// 論理削除ユーザーガイド情報を復活します
		/// </summary>
		/// <param name="parabyte">OcrDefSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除ユーザーガイド情報を復活します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int RevivalLogicalDelete(ref byte[] parabyte);

              /// <summary>
        /// ユーザーガイドマスタ(ヘッダ)(ユーザ変更分)情報LISTを全て戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索条件</param>
        /// <param name="readMode">モード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns></returns>
        /// <br>Note       : ユーザーガイドマスタ(ヘッダ)(ユーザ変更分)情報LISTを全て戻します</br>
        /// <br>Programmer : xueqi</br>
        /// <br>Date       : 2009.06.01</br>
        [MustCustomSerialization]
        int SearchHeader(            
            [CustomSerializationMethodParameterAttribute("SFCMN09066D", "Broadleaf.Application.Remoting.ParamData.UserGdHdUWork")]
            out object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode,
            out bool msgDiv, out string errMsg);

        /// <summary>
        /// ユーザーガイドマスタ(ヘッダ)(ユーザ変更分)情報を登録、更新します
        /// </summary>
        /// <param name="paraObj">更新対象</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザーガイドマスタ(ヘッダ)(ユーザ変更分)の更新処理</br>
        /// <br>Programmer : xueqi</br>
        /// <br>Date       : 2009.06.01</br>
        int WriteHeader(ref object paraObj, out bool msgDiv, out string errMsg);
		#endregion
	}

}
