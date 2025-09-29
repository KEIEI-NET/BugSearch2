//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 従業員別販売区分別売上目標設定マスタ
// プログラム概要   : 従業員別販売区分別売上目標設定マスタ　DBRemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11500865-00  作成担当 : 譚洪
// 作 成 日  2019/09/02   修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 従業員別販売区分別売上目標設定マスタDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 従業員別販売区分別売上目標設定マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2019/09/02</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IEmpScSalesTargetDB
    {
        #region
        /// <summary>
		/// 従業員別販売区分別売上目標設定マスタ情報を物理削除します
		/// </summary>
		/// <param name="parabyte">EmpSalesTargetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <remarks>
		/// <br>Note       : 従業員別販売区分別売上目標設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
		int Delete(byte[] parabyte);

		/// <summary>
		/// 従業員別販売区分別売上目標設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="empsalestargetWork">検索結果</param>
		/// <param name="paraempsalestargetWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
        /// <remarks>
		/// <br>Note       : </br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09196D", "Broadleaf.Application.Remoting.ParamData.EmpScSalesTargetWork")]
			out object empsalestargetWork,
			object paraempsalestargetWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 従業員別販売区分別売上目標設定マスタ情報を登録、更新します
		/// </summary>
        /// <param name="empsalestargetWork">従業員別販売区分別売上目標設定マスタ情報オブジェクト</param>
		/// <returns>STATUS</returns>
        /// <remarks>
		/// <br>Note       : 従業員別販売区分別売上目標設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09196D", "Broadleaf.Application.Remoting.ParamData.EmpScSalesTargetWork")]
			ref object empsalestargetWork
			);

		/// <summary>
		/// 従業員別販売区分別売上目標設定マスタ情報を論理削除します
		/// </summary>
        /// <param name="empsalestargetWork">従業員別販売区分別売上目標設定マスタ情報オブジェクト</param>
		/// <returns>STATUS</returns>
        /// <remarks>
		/// <br>Note       : 従業員別販売区分別売上目標設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09196D", "Broadleaf.Application.Remoting.ParamData.EmpScSalesTargetWork")]
			ref object empsalestargetWork
			);

		/// <summary>
		/// 論理削除従業員別販売区分別売上目標設定マスタ情報を復活します
		/// </summary>
        /// <param name="empsalestargetWork">従業員別販売区分別売上目標設定マスタ情報オブジェクト</param>
		/// <returns>STATUS</returns>
        /// <remarks>
		/// <br>Note       : 論理削除従業員別販売区分別売上目標設定マスタ情報を復活します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09196D", "Broadleaf.Application.Remoting.ParamData.EmpScSalesTargetWork")]
			ref object empsalestargetWork
			);

        /// <summary>
        /// 従業員別販売区分別売上目標設定マスタ情報を更新します
        /// </summary>
        /// <param name="empsalestargetWork">従業員別販売区分別売上目標設定マスタ情報オブジェクト(write用)</param>
        /// <param name="parabyte">EmpSalesTargetWorkオブジェクト(delete用)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員別販売区分別売上目標設定マスタ情報を更新します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        [MustCustomSerialization]
        int WriteProc(
            [CustomSerializationMethodParameterAttribute("PMKHN09196D", "Broadleaf.Application.Remoting.ParamData.EmpScSalesTargetWork")]
            ref object empsalestargetWork,
            byte[] parabyte
            );
        #endregion
	}
}
