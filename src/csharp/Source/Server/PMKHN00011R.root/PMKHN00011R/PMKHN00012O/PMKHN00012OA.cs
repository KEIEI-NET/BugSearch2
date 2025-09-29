using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// ユーザーDBバージョンチェックDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : ユーザーDBバージョンチェックDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 30350 櫻井 亮太</br>
	/// <br>Date       : 2009.01.23</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IVersionChkWorkDB
	{
        
        /// <summary>
        /// ユーザーDBバージョンチェックLISTを全て戻します（論理削除除く）
		/// </summary>
        /// <param name="CurrrentVersion">カレントバージョン</param>
        /// <param name="TargetVersion">ターゲットバージョン</param>
        /// <param name="ErrorCode">エラーコード</param>
        /// <param name="ErrorMessage">エラーメッセージ</param>
        /// <param name="MergeCheckResult">マージチェック処理結果</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.01.23</br>
        [MustCustomSerialization]
        int VersionCheckDB(out string CurrrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage);

        /// <summary>
        /// ユーザーAPバージョンチェックLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="CurrrentVersion">カレントバージョン</param>
        /// <param name="TargetVersion">ターゲットバージョン</param>
        /// <param name="ErrorCode">エラーコード</param>
        /// <param name="ErrorMessage">エラーメッセージ</param>
        /// <param name="MergeCheckResult">マージチェック処理結果</param>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.01.23</br>
        [MustCustomSerialization]
        int VersionCheckAP(out string CurrrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage, string EnterpriseCode);

        /// <summary>
        /// ユーザーDBバージョンチェックLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="currentVersion">カレントバージョン</param>
        /// <param name="TargetVersion">ターゲットバージョン</param>
        /// <param name="ErrorCode">エラーコード</param>
        /// <param name="ErrorMessage">エラーメッセージ</param>
        /// <param name="MergeCheckResult">マージチェック処理結果</param>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.01.23</br>
        [MustCustomSerialization]
        int MergeCheck(out int MergeCheckResult, string EnterpriseCode, string currentVersion);

        
        /// <summary>
        /// ユーザーバージョン更新処理
        /// </summary>
        /// <param name="CurrrentVersion">カレントバージョン</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.01.23</br>
        [MustCustomSerialization]
        int UpdateVersion(ref string CurrentVersion);
	}
}
