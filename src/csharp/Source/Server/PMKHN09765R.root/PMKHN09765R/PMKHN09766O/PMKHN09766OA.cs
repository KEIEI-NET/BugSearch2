using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 品番変換マスタDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 品番変換マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 陳永康</br>
    /// <br>Date       : 2014/12/23</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IGoodsNoChangeDB
	{

		/// <summary>
		/// 指定された品番変換マスタGuidの品番変換マスタを戻します
		/// </summary>
		/// <param name="parabyte">GoodsNoChangeWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された品番変換マスタGuidの品番変換マスタを戻します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        int Read(ref byte[] parabyte, int readMode);

		/// <summary>
		/// 品番変換マスタ情報を物理削除します
		/// </summary>
		/// <param name="parabyte">GoodsNoChangeWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 品番変換マスタ情報を物理削除します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        int Delete(byte[] parabyte);

		#region カスタムシリアライズ対応メソッド
		/// <summary>
		/// 品番変換マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="goodsNoChangeWork">検索結果</param>
		/// <param name="paragoodsNoChangeWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09767D", "Broadleaf.Application.Remoting.ParamData.GoodsNoChangeWork")]
			out object goodsNoChangeWork,
			object paragoodsNoChangeWork, int readMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
		/// 品番変換マスタ情報を登録、更新します
		/// </summary>
		/// <param name="goodsNoChangeWork">GoodsNoChangeWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 品番変換マスタ情報を登録、更新します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09767D", "Broadleaf.Application.Remoting.ParamData.GoodsNoChangeWork")]
			ref object goodsNoChangeWork
			);

		/// <summary>
		/// 品番変換マスタ情報を論理削除します
		/// </summary>
		/// <param name="goodsNoChangeWork">GoodsNoChangeWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 品番変換マスタ情報を論理削除します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09767D", "Broadleaf.Application.Remoting.ParamData.GoodsNoChangeWork")]
			ref object goodsNoChangeWork
			);

		/// <summary>
		/// 論理削除品番変換マスタ情報を復活します
		/// </summary>
		/// <param name="goodsNoChangeWork">GoodsNoChangeWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除品番変換マスタ情報を復活します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09767D", "Broadleaf.Application.Remoting.ParamData.GoodsNoChangeWork")]
			ref object goodsNoChangeWork
			);

        #endregion
	}
}
