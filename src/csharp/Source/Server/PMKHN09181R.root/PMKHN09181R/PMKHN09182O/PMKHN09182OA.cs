using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 端末管理マスタDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 端末管理マスタDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 30350　櫻井　亮太</br>
	/// <br>Date       : 2009.06.09</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPosTerminalMgDB
	{

		/// <summary>
        /// 指定された端末管理マスタGuidの端末管理マスタを戻します
		/// </summary>
        /// <param name="parabyte">PosTerminalMgWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 指定された端末管理マスタGuidの端末管理マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.06.09</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
        /// 端末管理マスタ情報を物理削除します
		/// </summary>
        /// <param name="parabyte">PosTerminalMgWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : SCM優先設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.06.09</br>
		int Delete(byte[] parabyte);

		#region カスタムシリアライズ対応メソッド
		/// <summary>
        /// 端末管理マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
        /// <param name="scmPriorStWork">検索結果</param>
        /// <param name="parascmPriorStWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.06.09</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09183D", "Broadleaf.Application.Remoting.ParamData.PosTerminalMgServerWork")]
			out object posTerminalMgWork,
           object paraposTerminalMgWork, int readMode, ConstantManagement.LogicalMode logicalMode);

		/// <summary>
        /// 端末管理マスタ情報を登録、更新します
		/// </summary>
        /// <param name="scmPriorStWork">PosTerminalMgWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 端末管理マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.06.09</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09183D", "Broadleaf.Application.Remoting.ParamData.PosTerminalMgServerWork")]
			ref object posTerminalMgWork
			);

		/// <summary>
        /// 端末管理マスタ情報を論理削除します
		/// </summary>
        /// <param name="scmPriorStWork">PosTerminalMgWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 端末管理マスタ情報を論理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.06.09</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09183D", "Broadleaf.Application.Remoting.ParamData.PosTerminalMgServerWork")]
			ref object posTerminalMgWork
			);

		/// <summary>
        /// 論理削除端末管理マスタ情報を復活します
		/// </summary>
        /// <param name="scmPriorStWork">PosTerminalMgWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 論理削除端末管理マスタ情報を復活します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.06.09</br>
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09183D", "Broadleaf.Application.Remoting.ParamData.PosTerminalMgServerWork")]
			ref object posTerminalMgWork
			);
		#endregion
	}
}
