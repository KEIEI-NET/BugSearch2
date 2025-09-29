using System;
using System.Collections;
using System.Data.SqlClient;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 支払更新DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       :支払更新DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 99033　岩本　勇</br>
	/// <br>Date       : 2005.08.08</br>
	/// <br></br>
	/// <br>Update Note: 2006.12.22 木村 武正</br>
	/// <br>             携帯.NS用に赤伝のインターフェースを追加</br>
    /// <br></br>
    /// <br>Update Note: 2008.01.11 山田 明友</br>
    /// <br>             論理削除機能を追加(LogicalDelete)</br>
    /// <br>Update Note : 2010.04.27 gejun</br>
    /// <br>              M1007A-支払手形データ更新追加</br>
    //  <br>Update Note : 2013/02/21 脇田 靖之 
    //                    支払伝票削除時、手形データ紐付け解除対応
    //----------------------------------------------------------------------//
    /// <br></br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
    public interface IPaymentSlpDB
	{
		/// <summary>
		/// 支払更新処理
		/// </summary>
		/// <param name="paymentSlpWorkByte">支払情報ワーク</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 支払情報・支払引当情報を元にデータ更新を行います</br>
		/// <br>           : 支払番号無しの時、新規支払作成とします</br>
		/// <br>           : 論理削除を立てた場合、削除処理を行います</br>
		/// <br>           : 支払引当の削除を行う場合は削除したい引当レコードのみ論理削除を立てます</br>
		/// <br>Programmer : 95089 岩本　勇</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
        int Write(ref byte[] paymentSlpWorkByte);
        // --- ADD 2012/10/11 -------------------------------------------------->>>>>
        /// <summary>
        /// 支払、手形(支払・受取)更新処理
        /// </summary>
        /// <param name="paymentSlpWorkByte">支払情報ワーク</param>
        /// <param name="payDraftDataWorkByte">支払手形データワーク</param>
        /// <param name="payDraftDataDelWorkByte">支払手形データワーク(削除用)</param>
        /// <param name="rcvDraftDataWorkByte">受取手形データワーク</param>
        /// <param name="rcvDraftDataDelWorkByte">受取手形データワーク(削除用)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払情報・支払引当情報・手形データを元にデータ更新を行います</br>
        /// <br>           : 支払番号無しの時、新規支払・手形データ作成とします</br>
        /// <br>           : 論理削除を立てた場合、削除処理を行います</br>
        /// <br>           : 支払引当の削除を行う場合は削除したい引当レコードのみ論理削除を立てます</br>
        /// <br>Programmer : 宮本</br>
        /// <br>Date       : 2012.10.11</br>
        /// </remarks>
        int WriteWithDraft(ref byte[] paymentSlpWorkByte, byte[] payDraftDataWorkByte, byte[] payDraftDataDelWorkByte
                                                        , byte[] rcvDraftDataWorkByte, byte[] rcvDraftDataDelWorkByte);
        // --- ADD 2012/10/11 --------------------------------------------------<<<<<
        // --------------- ADD START 2010.04.27 gejun FOR M1007A-M1007A-支払手形データ更新追加------->>>>
        /// <summary>
        /// 支払、手形更新処理
        /// </summary>
        /// <param name="paymentSlpWorkByte">支払情報ワーク</param>
        /// <param name="payDraftDataWorkByte">支払手形データワーク</param>
        /// <param name="payDraftDataDelWorkByte">支払手形データワーク(削除用)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払情報・支払引当情報・手形データを元にデータ更新を行います</br>
        /// <br>           : 支払番号無しの時、新規支払・手形データ作成とします</br>
        /// <br>           : 論理削除を立てた場合、削除処理を行います</br>
        /// <br>           : 支払引当の削除を行う場合は削除したい引当レコードのみ論理削除を立てます</br>
        /// <br>Programmer : gejun</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        int WriteWithPayDraft(ref byte[] paymentSlpWorkByte, byte[] payDraftDataWorkByte, byte[] payDraftDataDelWorkByte);
        // --------------- END START 2010.04.27 gejun FOR M1007A-M1007A-支払手形データ更新追加-------->>>>
		/// <summary>
		/// 支払読込処理
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="paymentSlipNo">支払番号</param>
		/// <param name="paymentSlpWorkByte">支払情報</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 支払情報を支払番号を元にデータ取得を行います</br>
		/// <br>Programmer : 95089 岩本　勇</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		int Read(string EnterpriseCode, int paymentSlipNo, out byte[] paymentSlpWorkByte);

        // ↓ 2008.01.11 980081 a
        ///// <summary>
        ///// 支払論理削除処理
        ///// </summary>
        ///// <param name="EnterpriseCode">企業コード</param>
        ///// <param name="DepositSlipNo">支払番号</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 指定した支払番号の支払情報論理削除を行います</br>
        ///// <br>Programmer : 980081 山田 明友</br>
        ///// <br>Date       : 2008.01.11</br>
        ///// </remarks>
        //int LogicalDelete(string EnterpriseCode, int DepositSlipNo);

        ///// <summary>
        ///// 支払論理削除処理
        ///// </summary>
        ///// <param name="EnterpriseCode">企業コード</param>
        ///// <param name="paymentSlipNo">支払番号</param>
        ///// <param name="RetPaymentSlpWorkByte">更新支払データ(赤削除時の元黒レコード)</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 指定した支払番号の支払情報論理削除を行います</br>
        ///// <br>Programmer : 980081 山田 明友</br>
        ///// <br>Date       : 2008.01.11</br>
        ///// </remarks>
        //int LogicalDelete(string EnterpriseCode, int paymentSlipNo, out byte[] RetPaymentSlpWorkByte);
        // ↑ 2008.01.11 980081 a

		/// <summary>
		/// 支払削除処理
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
        /// <param name="PaymentSlipNo">支払番号</param>
        /// <param name="payDraftDataWorkByte">支払手形情報</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した支払番号の支払情報削除を行います</br>
		/// <br>Programmer : 95089 岩本　勇</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
        // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
        //int Delete(string EnterpriseCode, int PaymentSlipNo);
        int Delete(string EnterpriseCode, int PaymentSlipNo, byte[] payDraftDataWorkByte);
        // --- UPD 2013/02/21 Y.Wakita ----------<<<<<


		/// <summary>
		/// 支払削除処理
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
        /// <param name="PaymentSlipNo">支払番号</param>
        /// <param name="payDraftDataWorkByte">支払手形情報</param>
        /// <param name="RetPaymentSlpWorkByte">更新支払データ(赤削除時の元黒レコード)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した支払番号の支払情報削除を行います</br>
		/// <br>Programmer : 95089 岩本　勇</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
        // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
        //int Delete(string EnterpriseCode, int PaymentSlipNo, out byte[] RetPaymentSlpWorkByte);
        int Delete(string EnterpriseCode, int PaymentSlipNo, byte[] payDraftDataWorkByte, out byte[] RetPaymentSlpWorkByte);
        // --- UPD 2013/02/21 Y.Wakita ----------<<<<<

        // ↓ 20061222 18322 c 赤伝の為のインターフェースを追加
        /// <summary>
        /// 支払伝票赤伝処理
        /// </summary>
        /// <param name="Mode">赤伝作成モード 0:赤入金作成</param>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="UpdateSecCd">更新拠点コード</param>
        /// <param name="PaymentAgentCode">支払担当者コード</param>
        /// <param name="PaymentAgentNm">支払担当者名</param>
        /// <param name="AddUpADate">計上日</param>
        /// <param name="PaymentSlipNo">支払伝票番号(赤伝を行う黒伝)</param>
        /// <param name="RetPaymentSlpWorkList">支払伝票マスタ(更新結果)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した支払伝票番号の赤支払作成処理を行います</br>
        /// <br>Programmer : 18322 木村 武正</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        [MustCustomSerialization]
        int RedCreate(int Mode,
                      string EnterpriseCode,
                      string UpdateSecCd,
                      string PaymentAgentCode,
                      string PaymentAgentNm,
                      DateTime AddUpADate,
                      int PaymentSlipNo,
                      [CustomSerializationMethodParameterAttribute("SFSIR02140D", "Broadleaf.Application.Remoting.ParamData.PaymentDataWork")]
                      out object RetPaymentSlpWorkList);
        // ↑ 20061222 18322 c

		//int Write(string EnterpriseCode, byte[] createDepsitMainWorkListByte);
		//int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo );
		//int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo, out byte[] RetDepsitMainWorkListByte, out byte[] RetDepositAlwWorkListByte);
		//int ReadDmdSalesRec(string EnterpriseCode, int ClaimCode, out byte[] dmdSalesWorkListByte);	// 仮
	}
}
