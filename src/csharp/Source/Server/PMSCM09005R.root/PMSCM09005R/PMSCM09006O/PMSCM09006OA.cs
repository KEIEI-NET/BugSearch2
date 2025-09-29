using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// SCM品目設定マスタDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : SCM品目設定マスタDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 30350　櫻井　亮太</br>
	/// <br>Date       : 2009.04.27</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISCMPrtSettingDB
	{

		/// <summary>
		/// 指定されたSCM品目設定マスタGuidのSCM品目設定マスタを戻します
		/// </summary>
        /// <param name="parabyte">SCMPrtSettingWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定されたSCM品目設定マスタGuidのSCM品目設定マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
		/// <br>Date       : 2009.04.27</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// SCM品目設定マスタ情報を物理削除します
		/// </summary>
        /// <param name="parabyte">SCMPrtSettingWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫管理全体設定マスタ情報を物理削除します</br>
		/// <br>Programmer : 30350　櫻井　亮太</br>
		/// <br>Date       : 2009.04.27</br>
		int Delete(byte[] parabyte);

		#region カスタムシリアライズ対応メソッド
		/// <summary>
        /// SCM品目設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
        /// <param name="scmPrtSettingWork">検索結果</param>
        /// <param name="parascmPrtSettingWork">検索パラメータ</param>
        /// <param name="scmPrtSettingOrderWork">抽出条件クラス</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 30350　櫻井　亮太</br>
		/// <br>Date       : 2009.04.27</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMSCM09007D", "Broadleaf.Application.Remoting.ParamData.SCMPrtSettingWork")]
			out object scmPrtSettingWork,
           object parascmPrtSettingWork, int readMode, ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// SCM品目設定マスタ情報を登録、更新します
		/// </summary>
        /// <param name="scmPrtSettingWork">SCMPrtSettingWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫管理全体設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMSCM09007D", "Broadleaf.Application.Remoting.ParamData.SCMPrtSettingWork")]
			ref object scmPrtSettingWork
			);

		/// <summary>
		/// 在庫管理全体設定マスタ情報を論理削除します
		/// </summary>
        /// <param name="scmPrtSettingWork">SCMPrtSettingWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫管理全体設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM09007D", "Broadleaf.Application.Remoting.ParamData.SCMPrtSettingWork")]
			ref object scmPrtSettingWork
			);

		/// <summary>
		/// 論理削除在庫管理全体設定マスタ情報を復活します
		/// </summary>
        /// <param name="stockmngttlstWork">SCMPrtSettingWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除在庫管理全体設定マスタ情報を復活します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM09007D", "Broadleaf.Application.Remoting.ParamData.SCMPrtSettingWork")]
			ref object scmPrtSettingWork
			);
		#endregion
	}
}
