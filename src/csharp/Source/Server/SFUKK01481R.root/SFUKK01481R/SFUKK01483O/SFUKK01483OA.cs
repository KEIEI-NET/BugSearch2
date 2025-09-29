using System;
using System.Collections;
using System.Data.SqlClient;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 入金引当操作DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       :入金引当操作DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 95089　徳永　誠</br>
	/// <br>Date       : 2005.08.08</br>
	/// <br></br>
    /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
    /// <br>Update Note: K2014/05/28 11001635-00 zhujw ㈱カト―個別対応</br>
    /// <br>Update Note: K2014/06/19 11001635-00 zhujw RedMine#42902</br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IControlDepsitAlwDB
	{
        // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 ------->>>>> 
        /// <summary>
        /// 入金伝票入力(売上指定型)リストの取得処理。
        /// </summary>
        /// <param name="ControlKaToDepsitAlwResultWork">検索結果</param>
        /// <param name="ControlKaToDepsitAlwCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : 入金伝票入力(売上指定型)のキー値が一致する、全ての売上データテキスト情報を取得します。</br>
        /// <br>Programmer	: zhujw</br>
        /// <br>Date		: K2014/05/28</br>
        [MustCustomSerialization]
        int Search(
            //[CustomSerializationMethodParameterAttribute("SFUKK01484DC", "Broadleaf.Application.Remoting.ParamData.ControlKaToDepsitAlwWork")] // DEL zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する
            [CustomSerializationMethodParameterAttribute("SFUKK01346D", "Broadleaf.Application.Remoting.ParamData.DepositAlwWork")] // ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する
            out object ControlKaToDepsitAlwResultWork,
            object ControlKaToDepsitAlwCndtnWork);
        // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 -------<<<<<

		/// <summary>
		/// 入金引当削除
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="CustomerCode">得意先コード</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="SalesSlipNum">売上伝票番号</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 指定した得意先コード・受注ステータス・売上伝票番号に引当られている入金引当MTを削除し、入金MTの引当額を減算更新します</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        // ↓ 2008.03.07 980081 c 
        //int DeleteDB(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo);
        int DeleteDB(string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum);
        // ↑ 2008.03.07 980081 c

		/// <summary>
		/// 入金引当情報取得
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="CustomerCode">得意先コード</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="SalesSlipNum">売上伝票番号</param>
        /// <param name="depositAlwWorkListByte">入金引当情報配列</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した得意先コード・受注番号に引当られている入金引当MTを取得し返します</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        // ↓ 2008.03.07 980081 c
        //int ReadDB(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, out byte[] depositAlwWorkListByte);
        int ReadDB(string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, out byte[] depositAlwWorkListByte);
        // ↑ 2008.03.07 980081 c

		/// <summary>
		/// 入金引当チェック処理
		/// </summary>
		/// <param name="mode">赤黒入金引当取得区分 0:カウントする 1:カウントしない</param>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="CustomerCode">得意先コード</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="SalesSlipNum">売上伝票番号</param>
        /// <param name="count">入金引当数</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した得意先コード・受注番号に引当られている入金引当数を取得し返します</br>
		///	<br>           : modeに1を指定することで、赤入金・相殺済み黒入金への引当数を未カウントにすることができます</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        // ↓ 2008.03.07 980081 c
        //int GetCountDB(int mode, string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, out int count);
        int GetCountDB(int mode, string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, out int count);
        // ↑ 2008.03.07 980081 c

        // ↓ 20070131 18322 c MA.NS用に変更
		//int CreateRedDepositAllowance(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, int NewAcceptAnOrderNo);

		/// <summary>
		/// 売赤伝作成時入金引当赤作成処理
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="CustomerCode">得意先コード</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="SalesSlipNum">売上伝票番号</param>
        /// <param name="depositAgentCode">入金担当者コード</param>
		/// <param name="depositAgentNm">入金担当者名</param>
		/// <param name="akaAddUpADate">赤伝計上日</param>
        /// <param name="NewSalesSlipNum">赤伝売上伝票番号</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した得意先コード・受注番号に引当られている入金引当MTから赤受注に対する赤引当作成し、入金MTの引当額を減算更新します</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2006.03.07</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        // 売赤伝作成時入金引当赤作成処理
        // ↓ 2008.03.07 980081 c
        //int CreateRedDepositAllowance(string EnterpriseCode
        //                             , int CustomerCode
        //                             , int AcceptAnOrderNo
        //                             , string depositAgentCode
        //                             , string depositAgentNm
        //                             , DateTime akaAddUpADate
        //                             , int NewAcceptAnOrderNo);
        int CreateRedDepositAllowance(string EnterpriseCode
                                     , int CustomerCode
                                     , int AcptAnOdrStatus
                                     , string SalesSlipNum
                                     , string depositAgentCode
                                     , string depositAgentNm
                                     , DateTime akaAddUpADate
                                     , string NewSalesSlipNum);
        // ↑ 2008.03.07 980081 c
        // ↑ 20070131 18322 c
	}
}
