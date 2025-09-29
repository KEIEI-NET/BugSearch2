using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// SCM優先設定マスタDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : SCM優先設定マスタDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 30350　櫻井　亮太</br>
	/// <br>Date       : 2009.05.12</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISCMPriorStDB
	{

		/// <summary>
        /// 指定されたSCM優先設定マスタGuidのSCM優先設定マスタを戻します
		/// </summary>
        /// <param name="parabyte">SCMPriorStWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 指定されたSCM優先設定マスタGuidのSCM優先設定マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
		int Read(ref byte[] parabyte , int readMode);

        /// <summary>
        /// 指定されたSCM優先設定マスタGuidのSCM優先設定マスタを戻します(PCCUOE)
        /// </summary>
        /// <param name="parabyte">SCMPriorStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたSCM優先設定マスタGuidのSCM優先設定マスタを戻します</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011.08.10</br>
        int ReadPCCUOE(ref byte[] parabyte, int readMode);

		/// <summary>
        /// SCM優先設定マスタ情報を物理削除します
		/// </summary>
        /// <param name="parabyte">SCMPriorStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : SCM優先設定マスタ情報を物理削除します</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.03.02</br>
		int Delete(byte[] parabyte);

		#region カスタムシリアライズ対応メソッド
		/// <summary>
        /// SCM優先設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
        /// <param name="scmPriorStWork">検索結果</param>
        /// <param name="parascmPriorStWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMSCM09066D", "Broadleaf.Application.Remoting.ParamData.SCMPriorStWork")]
			out object scmPriorStWork,
			object parascmPriorStWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
        /// SCM優先設定マスタ情報を登録、更新します
		/// </summary>
        /// <param name="scmPriorStWork">StockMngTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : SCM優先設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMSCM09066D", "Broadleaf.Application.Remoting.ParamData.SCMPriorStWork")]
			ref object scmPriorStWork
			);

		/// <summary>
        /// SCM優先設定マスタ情報を論理削除します
		/// </summary>
        /// <param name="scmPriorStWork">StockMngTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : SCM優先設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM09066D", "Broadleaf.Application.Remoting.ParamData.SCMPriorStWork")]
			ref object scmPriorStWork
			);

		/// <summary>
        /// 論理削除SCM優先設定マスタ情報を復活します
		/// </summary>
        /// <param name="scmPriorStWork">StockMngTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 論理削除SCM優先設定マスタ情報を復活します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM09066D", "Broadleaf.Application.Remoting.ParamData.SCMPriorStWork")]
			ref object scmPriorStWork
			);
		#endregion
	}
}
