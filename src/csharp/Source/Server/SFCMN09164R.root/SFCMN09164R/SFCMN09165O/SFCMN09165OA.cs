using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;



namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 全体項目表示名称DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 全体項目表示名称DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 90027　高口　勝</br>
	/// <br>Date       : 2006.08.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IAlItmDspNmDB
	{

		#region カスタムシリアライズ

		/// <summary>
		/// 全体項目表示名称LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2006.08.28</br>
		int Search(
			[CustomSerializationMethodParameterAttribute("SFCMN09166D","Broadleaf.Application.Remoting.ParamData.AlItmDspNmWork")]
			out object retobj,
			object paraobj,
			int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 指定された企業コードの全体項目表示名称を戻します
		/// </summary>
		/// <param name="alItmDspNmWork">AlItmDspNmWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの全体項目表示名称を戻します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2006.08.28</br>
		[MustCustomSerialization]
		int Read(
			[CustomSerializationMethodParameterAttribute("SFCMN09166D","Broadleaf.Application.Remoting.ParamData.AlItmDspNmWork")]
			ref object alItmDspNmWork,
			int readMode
			);
			
		#endregion


		/// <summary>
		/// 全体項目表示名称LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2006.08.28</br>
		int Search(out byte[] retbyte, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 指定された全体項目表示名称Guidの全体項目表示名称を戻します
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された全体項目表示名称Guidの全体項目表示名称を戻します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2006.08.28</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// 全体項目表示名称情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 全体項目表示名称情報を登録、更新します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2006.08.28</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// 全体項目表示名称情報を物理削除します
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 全体項目表示名称情報を物理削除します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2006.08.28</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// 全体項目表示名称情報を論理削除します
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 全体項目表示名称情報を論理削除します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2006.08.28</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// 論理削除全体項目表示名称情報を復活します
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除全体項目表示名称情報を復活します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2006.08.28</br>
		int RevivalLogicalDelete(ref byte[] parabyte);






        /// <summary>
		/// 全体項目表示名称LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2006.08.28</br>
		int Search(
			[CustomSerializationMethodParameterAttribute("SFCMN09166D","Broadleaf.Application.Remoting.ParamData.AlItmDspNmWork")]
			out object retobj,
			object paraobj,
			int readMode,ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection);

		/// <summary>
		/// 指定された企業コードの全体項目表示名称を戻します
		/// </summary>
		/// <param name="alItmDspNmWork">AlItmDspNmWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの全体項目表示名称を戻します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2006.08.28</br>
		[MustCustomSerialization]
		int Read(
			[CustomSerializationMethodParameterAttribute("SFCMN09166D","Broadleaf.Application.Remoting.ParamData.AlItmDspNmWork")]
			ref object alItmDspNmWork,
			int readMode,
            ref SqlConnection sqlConnection);

		/// <summary>
		/// 全体項目表示名称LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2006.08.28</br>
		int Search(out byte[] retbyte, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,ref SqlConnection sqlConnection);

		/// <summary>
		/// 指定された全体項目表示名称Guidの全体項目表示名称を戻します
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された全体項目表示名称Guidの全体項目表示名称を戻します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2006.08.28</br>
		int Read(ref byte[] parabyte , int readMode ,ref SqlConnection sqlConnection);






    }
}
