//**********************************************************************//
// System           :   PM.NS
// Sub System       :
// Program name     :   入金更新DB RemoteObjectインターフェース
//                  :   SFUKK01363O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programer        :   徳永　誠
// Date             :   2005.08.08
//----------------------------------------------------------------------//
// Update Note      :
// ---------------------------------------------------------------------
// 2007.01.23 T.Kimura : MA.NS用に変更
// 2008.01.11 A.Yamada : 論理削除機能を追加(LogicalDelete)
// 2008.04.25 21112    : PM.NS用に変更
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co,. Ltd
//**********************************************************************//
using System;
using System.Collections;
using System.Data.SqlClient;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 入金更新DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       :入金更新DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 95089　徳永　誠</br>
	/// <br>Date       : 2005.08.08</br>
    /// <br>Update Note : 2010.05.06 gejun</br>
    /// <br>              M1007A-支払手形データ更新追加</br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IDepsitMainDB
	{
		/// <summary>
        /// 入金、手形更新処理
		/// </summary>
		/// <param name="depsitDataWorkByte">入金情報ワーク</param>
		/// <param name="depositAlwWorkListByte">入金引当情報ワーク</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 入金情報・入金引当情報・手形データを元にデータ更新を行います</br>
        /// <br>           : 入金番号無しの時、新規入金・手形データ作成とします</br>
		/// <br>           : 論理削除を立てた場合、削除処理を行います</br>
		/// <br>           : 入金引当の削除を行う場合は削除したい引当レコードのみ論理削除を立てます</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		int Write(ref byte[] depsitDataWorkByte, ref byte[] depositAlwWorkListByte);
        // --------------- ADD START 2010.05.06 gejun FOR M1007A-M1007A-支払手形データ更新追加------->>>>
        /// <summary>
        /// 入金、手形更新処理
        /// </summary>
        /// <param name="depsitDataWorkByte">入金情報ワーク</param>
        /// <param name="depositAlwWorkListByte">入金引当情報ワーク</param>
        /// <param name="rcvDraftDataWorkUpdByte">手形データ（更新用）ワーク</param>
        /// <param name="rcvDraftDataWorkDelByte">手形データ（削除用）ワーク</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 入金情報・入金引当情報・手形情報を元にデータ更新を行います</br>
        /// <br>           : 入金番号無しの時、新規入金作成とします</br>
        /// <br>           : 論理削除を立てた場合、削除処理を行います</br>
        /// <br>           : 入金引当の削除を行う場合は削除したい引当レコードのみ論理削除を立てます</br>
        /// <br>Note　　　  : 手形情報の更新処理も行います。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010/05/06</br>
        /// </remarks>
        int WriteWithDraftData(ref byte[] depsitDataWorkByte, ref byte[] depositAlwWorkListByte, byte[] rcvDraftDataWorkUpdByte, byte[] rcvDraftDataWorkDelByte);
        // --------------- ADD END 2010.05.06 gejun FOR M1007A-M1007A-支払手形データ更新追加------->>>>
		/// <summary>
		/// 入金読込処理
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
		/// <param name="depsitDataWorkByte">入金情報</param>
		/// <param name="depositAlwWorkListByte">入金引当情報</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 入金情報・入金引当情報を入金番号を元にデータ取得を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		//int Read(string EnterpriseCode, int DepositSlipNo, out byte[] depsitDataWorkByte, out byte[] depositAlwWorkListByte);  //DEL 2008/04/25 M.Kubota
        int Read(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out byte[] depsitDataWorkByte, out byte[] depositAlwWorkListByte);  //ADD 2008/04/25 M.Kubota

        // ↓ 2008.01.11 980081 a
        /// <summary>
        /// 入金論理削除処理
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した入金番号の入金情報・入金引当情報論理削除を行います</br>
        /// <br>           : 自動入金データの削除に使用します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        //int LogicalDelete(string EnterpriseCode, int DepositSlipNo);  //DEL 2008/04/25 M.Kubota
        int LogicalDelete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus);  //ADD 2008/04/25 M.Kubota

        /// <summary>
        /// 入金論理削除処理
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="RetDepsitDataWorkByte">更新入金データ(赤削除時の元黒レコード)</param>
        /// <param name="RetDepositAlwWorkListByte">更新入金引当データ(赤削除時の元黒引当レコード)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した入金番号の入金情報・入金引当情報論理削除を行います</br>
        /// <br>           : 自動入金データの削除に使用します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        //int LogicalDelete(string EnterpriseCode, int DepositSlipNo, out byte[] RetDepsitDataWorkByte, out byte[] RetDepositAlwWorkListByte);  //DEL 2008/04/25 M.Kubota
        int LogicalDelete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out byte[] RetDepsitDataWorkByte, out byte[] RetDepositAlwWorkListByte);  //ADD 2008/04/25 M.Kubota
        // ↑ 2008.01.11 980081 a

		/// <summary>
		/// 入金削除処理
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した入金番号の入金情報・入金引当情報削除を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		//int Delete(string EnterpriseCode, int DepositSlipNo);                     //DEL 2008/04/25 M.Kubota
        int Delete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus);  //ADD 2008/04/25 M.Kubota
        

		/// <summary>
		/// 入金削除処理
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
		/// <param name="RetDepsitDataWorkByte">更新入金データ(赤削除時の元黒レコード)</param>
		/// <param name="RetDepositAlwWorkListByte">更新入金引当データ(赤削除時の元黒引当レコード)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した入金番号の入金情報・入金引当情報削除を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		//int Delete(string EnterpriseCode, int DepositSlipNo, out byte[] RetDepsitDataWorkByte, out byte[] RetDepositAlwWorkListByte);  //DEL 2008/04/25 M.Kubota
        int Delete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out byte[] RetDepsitDataWorkByte, out byte[] RetDepositAlwWorkListByte);  //ADD 2008/04/25 M.Kubota

		/// <summary>
		/// 入金一括作成処理（受注指定型）
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
        /// <param name="createDepsitMainWorkListByte">入金更新データパラメータ(受注指定型)</param>
		/// <param name="depositSlipNoList">更新した入金データの入金番号配列</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 一括作成用パラメータから指定受注への引当更新・入金新規作成処理を行います</br>
		/// <br>           : 受注指定型専用であり、新規入金・引当のみ行えます</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		int Write(string EnterpriseCode, byte[] createDepsitMainWorkListByte, out int[] depositSlipNoList);

        // ↓ 20070124 18322 c MA.NS用に変更
		//int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo );
		//int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo, out byte[] RetDepsitDataWorkListByte, out byte[] RetDepositAlwWorkListByte);

		/// <summary>
		/// 赤入金作成処理
		/// </summary>
		/// <param name="mode">0:赤入金作成 1:赤入金・新黒入金作成</param>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="UpdateSecCd">更新拠点コード</param>
		/// <param name="DepositAgentCode">入金担当者コード</param>
		/// <param name="DepositAgentNm">入金担当者名</param>
		/// <param name="AddUpADate">計上日</param>
		/// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した入金番号の赤入金作成処理を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.26</br>
        /// <br></br>
        /// <br>Update Note: 2007.01.24 18322 T.Kimura MA.NS用に変更</br>
        /// <br></br>
		/// </remarks>
		//int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo );     //DEL 2008/04/25 M.Kubota
        int RedCreate(int mode, string EnterpriseCode, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, int AcptAnOdrStatus);  //ADD 2008/04/25 M.Kubota

		/// <summary>
		/// 赤入金作成処理
		/// </summary>
		/// <param name="mode">0:赤入金作成 1:赤入金・新黒入金作成</param>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="UpdateSecCd">更新拠点コード</param>
		/// <param name="DepositAgentCode">入金担当者コード</param>
		/// <param name="DepositAgentNm">入金担当者名</param>
		/// <param name="AddUpADate">計上日</param>
		/// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
		/// <param name="RetDepsitDataWorkListByte">更新入金MTレコード</param>
		/// <param name="RetDepositAlwWorkListByte">更新入金引当MTレコード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した入金番号の赤入金作成処理を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.26</br>
        /// <br></br>
        /// <br>Update Note: 2007.01.24 18322 T.Kimura MA.NS用に変更</br>
        /// <br></br>
		/// </remarks>
        //int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, out byte[] RetDepsitDataWorkListByte, out byte[] RetDepositAlwWorkListByte);  //DEL 2008/04/25 M.Kubota
        int RedCreate(int mode, string EnterpriseCode, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, int AcptAnOdrStatus, out byte[] RetDepsitDataWorkListByte, out byte[] RetDepositAlwWorkListByte);                   //ADD 2008/04/25 M.Kubota
        // ↑ 20070124 18322 c

        // ↓ 20070518 18322 d テスト用ロジックの為削除
		//int ReadDmdSalesRec(string EnterpriseCode, int ClaimCode, out byte[] dmdSalesWorkListByte);	// 仮
        // ↑ 20070518 18322 d
	}
}
