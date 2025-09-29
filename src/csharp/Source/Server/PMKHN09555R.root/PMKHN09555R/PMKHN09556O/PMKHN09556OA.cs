using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 重点品目設定マスタDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 重点品目設定マスタDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 30350　櫻井　亮太</br>
	/// <br>Date       : 2009.04.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IImportantPrtStDB
	{
		/// <summary>
        /// 指定された重点品目設定マスタGuidの重点品目設定マスタを戻します
		/// </summary>
		/// <param name="parabyte">StockMngTtlStWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 指定された重点品目設定マスタGuidの重点品目設定マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
        /// 重点品目設定マスタ情報を物理削除します
		/// </summary>
		/// <param name="parabyte">StockMngTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 重点品目設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
		int Delete(byte[] parabyte);

		#region カスタムシリアライズ対応メソッド
		/// <summary>
        /// 重点品目設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
        /// <param name="importantPrtStWork">検索結果</param>
        /// <param name="paraimportantPrtStWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09557D", "Broadleaf.Application.Remoting.ParamData.ImportantPrtStWork")]
			out object importantPrtStWork,
           object paraimportantPrtStWork, int readMode, ConstantManagement.LogicalMode logicalMode);

		/// <summary>
        /// 重点品目設定マスタ情報を登録、更新します
		/// </summary>
        /// <param name="importantPrtStWork">StockMngTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 重点品目設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09557D", "Broadleaf.Application.Remoting.ParamData.ImportantPrtStWork")]
			ref object importantPrtStWork
			);

		/// <summary>
        /// 重点品目設定マスタ情報を論理削除します
		/// </summary>
        /// <param name="importantPrtStWork">StockMngTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 重点品目設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09557D", "Broadleaf.Application.Remoting.ParamData.ImportantPrtStWork")]
			ref object importantPrtStWork
			);

		/// <summary>
        /// 論理削除重点品目設定マスタ情報を復活します
		/// </summary>
        /// <param name="importantPrtStWork">StockMngTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 論理削除重点品目設定マスタ情報を復活します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09557D", "Broadleaf.Application.Remoting.ParamData.ImportantPrtStWork")]
			ref object importantPrtStWork
			);
		#endregion
	}
}
