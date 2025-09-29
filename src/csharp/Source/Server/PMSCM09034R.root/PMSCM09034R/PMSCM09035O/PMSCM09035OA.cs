using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// SCM納期設定マスタDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : SCM納期設定マスタDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 30350　櫻井　亮太</br>
	/// <br>Date       : 2009.04.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISCMDeliDateStDB
	{

		/// <summary>
        /// 指定されたSCM納期設定マスタGuidのSCM納期設定マスタを戻します
		/// </summary>
        /// <param name="parabyte">SCMDeliDateStWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 指定されたSCM納期設定マスタGuidのSCM納期設定マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
        /// SCM納期設定マスタ情報を物理削除します
		/// </summary>
        /// <param name="parabyte">SCMDeliDateStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : SCM納期設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
		int Delete(byte[] parabyte);

		#region カスタムシリアライズ対応メソッド
		/// <summary>
        /// SCM納期設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
        /// <param name="scmDeliDateStWork">検索結果</param>
        /// <param name="parascmDeliDateStWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMSCM09036D", "Broadleaf.Application.Remoting.ParamData.SCMDeliDateStWork")]
			out object scmDeliDateStWork,
           object parascmDeliDateStWork, int readMode, ConstantManagement.LogicalMode logicalMode);

		/// <summary>
        /// SCM納期設定マスタ情報を登録、更新します
		/// </summary>
        /// <param name="scmDeliDateStWork">SCMDeliDateStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫管理全体設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMSCM09036D", "Broadleaf.Application.Remoting.ParamData.SCMDeliDateStWork")]
			ref object scmDeliDateStWork
			);

		/// <summary>
        /// SCM納期設定マスタ情報を論理削除します
		/// </summary>
        /// <param name="scmDeliDateStWork">SCMDeliDateStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫管理全体設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM09036D", "Broadleaf.Application.Remoting.ParamData.SCMDeliDateStWork")]
			ref object scmDeliDateStWork
			);

		/// <summary>
        /// 論理削除SCM納期設定マスタ情報を復活します
		/// </summary>
        /// <param name="scmDeliDateStWork">SCMDeliDateStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 論理削除SCM納期設定マスタ情報を復活します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM09036D", "Broadleaf.Application.Remoting.ParamData.SCMDeliDateStWork")]
			ref object scmDeliDateStWork
			);
		#endregion
	}
}
