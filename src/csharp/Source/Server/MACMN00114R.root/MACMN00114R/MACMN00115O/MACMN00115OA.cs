using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 操作履歴ログデータDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 操作履歴ログデータDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 23015 森本 大輝</br>
	/// <br>Date       : 2008.07.24</br>
	/// <br></br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IOprtnHisLogDB
	{
        /// <summary>
        /// 操作履歴ログデータLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="oprtnHisLogWork">検索結果</param>
        /// <param name="oprtnHisLogSrchWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("MACMN00116D", "Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork")]
			ref object oprtnHisLogWork,
            object oprtnHisLogSrchWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode
            );

        /// <summary>
        /// 操作履歴ログデータLIST(UOE分)を全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="oprtnHisLogWork">検索結果</param>
        /// <param name="oprationLogOrderWorkWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.12.03</br>
        [MustCustomSerialization]
        int SearchUOE(
            [CustomSerializationMethodParameterAttribute("MACMN00116D", "Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork")]
			ref object oprtnHisLogWork,
            object oprationLogOrderWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode
            );

		/// <summary>
		/// 指定された操作履歴ログデータGuidの操作履歴ログデータを戻します
		/// </summary>
        /// <param name="oprtnHisLogWork">oprtnHisLogWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された操作履歴ログデータGuidの操作履歴ログデータを戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("MACMN00116D", "Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork")]
			ref object oprtnHisLogWork,
            int readMode
            );

        /// <summary>
        /// 操作履歴ログデータ情報を登録、更新します
        /// </summary>
        /// <param name="oprtnHisLogWork">OprtnHisLogWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 操作履歴ログデータ情報を登録、更新します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MACMN00116D", "Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork")]
			ref object oprtnHisLogWork
            );

		/// <summary>
		/// 操作履歴ログデータ情報を物理削除します
		/// </summary>
        /// <param name="oprtnHisLogWork">OprtnHisLogWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 操作履歴ログデータ情報を物理削除します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("MACMN00116D", "Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork")]
            object oprtnHisLogWork
            );

        /// <summary>
        /// 操作履歴ログデータ情報(UOE分)を物理削除します
        /// </summary>
        /// <param name="oprtnHisLogWork">OprtnHisLogWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 操作履歴ログデータ情報を物理削除します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.12.02</br>
        int DeleteUOE(object oprationLogOrderWork
            );

        /// <summary>
		/// 操作履歴ログデータ情報を論理削除します
		/// </summary>
		/// <param name="oprtnHisLogWork">OprtnHisLogWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 操作履歴ログデータ情報を論理削除します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        [MustCustomSerialization]
        int LogicalDelete(
			[CustomSerializationMethodParameterAttribute("MACMN00116D","Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork")]
			ref object oprtnHisLogWork
			);

		/// <summary>
		/// 論理削除操作履歴ログデータ情報を復活します
		/// </summary>
		/// <param name="oprtnHisLogWork">OprtnHisLogWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除操作履歴ログデータ情報を復活します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
			[CustomSerializationMethodParameterAttribute("MACMN00116D","Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork")]
			ref object oprtnHisLogWork
			);
	}
}
