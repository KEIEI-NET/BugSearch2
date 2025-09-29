using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 自動回答品目設定マスタDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自動回答品目設定マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30745　吉岡　孝憲</br>
    /// <br>Date       : 2012/10/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IAutoAnsItemStDB
	{
        /// <summary>
        /// 自動回答品目設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="AutoAnsItemStWork">検索結果</param>
        /// <param name="parabyte">AutoAnsItemStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        int Read2(
            out object AutoAnsItemStWork,
            byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 自動回答品目設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="AutoAnsItemStWork">検索結果</param>
        /// <param name="parabyte">AutoAnsItemStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        int Read3(
            out object AutoAnsItemStWork,
            byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
		/// 自動回答品目設定マスタ情報を物理削除します
		/// </summary>
        /// <param name="parabyte">AutoAnsItemStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫管理全体設定マスタ情報を物理削除します</br>
		int Delete(byte[] parabyte);

		#region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 自動回答品目設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="AutoAnsItemStWork">検索結果</param>
        /// <param name="paraAutoAnsItemStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09707D", "Broadleaf.Application.Remoting.ParamData.AutoAnsItemStWork")]
			out object AutoAnsItemStWork,
           object paraAutoAnsItemStWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
		/// 自動回答品目設定マスタ情報を登録、更新します
		/// </summary>
        /// <param name="AutoAnsItemStWork">AutoAnsItemStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫管理全体設定マスタ情報を登録、更新します</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09707D", "Broadleaf.Application.Remoting.ParamData.AutoAnsItemStWork")]
			ref object AutoAnsItemStWork
			);

		/// <summary>
		/// 在庫管理全体設定マスタ情報を論理削除します
		/// </summary>
        /// <param name="AutoAnsItemStWork">AutoAnsItemStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫管理全体設定マスタ情報を論理削除します</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09707D", "Broadleaf.Application.Remoting.ParamData.AutoAnsItemStWork")]
			ref object AutoAnsItemStWork
			);

		/// <summary>
		/// 論理削除在庫管理全体設定マスタ情報を復活します
		/// </summary>
        /// <param name="AutoAnsItemStWork">AutoAnsItemStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除在庫管理全体設定マスタ情報を復活します</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09707D", "Broadleaf.Application.Remoting.ParamData.AutoAnsItemStWork")]
			ref object AutoAnsItemStWork
			);
		#endregion
	}
}
