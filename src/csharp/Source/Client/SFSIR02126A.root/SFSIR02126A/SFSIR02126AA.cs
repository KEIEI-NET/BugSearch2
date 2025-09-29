using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 支払伝票検索アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 支払伝票の検索を行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2006.05.31</br>
	/// </remarks>
	public class SearchPaymentAcs
	{
		#region PrivateMember
		// エラーメッセージ
		private string _errorMessage;
		#endregion

		#region Interface
		// リモートオブジェクト格納バッファ
		private IPaymentReadDB _iPaymentReadDB = null;
		#endregion

		#region Property
		/// <summary>エラーメッセージ</summary>
		public string ErrorMessage
		{
			get { return _errorMessage; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SearchPaymentAcs()
		{
			try
			{
				// リモートオブジェクト取得
				this._iPaymentReadDB= (IPaymentReadDB)MediationPaymentReadDB.GetPaymentReadDB();
			}
			catch (Exception)
			{				
				// オフライン時はnullをセット
				this._iPaymentReadDB = null;
			}
		}
		#endregion

		#region PublicMethod
        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 支払伝票検索処理
		/// </summary>
		/// <param name="searchParaPaymentRead">支払伝票検索パラメータ</param>
        /// <param name="searchPaymentSlpList">検索結果LIST</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 支払伝票の検索処理を行います。</br>
		/// <br>Programmer	: 30414 忍 幸史</br>
		/// <br>Date		: 2008/07/08</br>
		/// </remarks>
		public int Search(SearchParaPaymentRead searchParaPaymentRead, out ArrayList searchPaymentSlpList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			searchPaymentSlpList = new ArrayList();

			try
			{
				object paymentSlpWorkObj;
				// 支払データ読込み
				status = this._iPaymentReadDB.Search(out paymentSlpWorkObj, (object)searchParaPaymentRead, 0, ConstantManagement.LogicalMode.GetData0);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
                        ArrayList wkList = paymentSlpWorkObj as ArrayList;
                        foreach (PaymentDataWork paymentDataWork in wkList)
                        {
                            searchPaymentSlpList.Add(CopyToSearchPaymentSlpFromPaymentDataWork(paymentDataWork));
                        }
						break;
					}
				}
			}
			catch (Exception ex)
			{
				//オフライン時はnullをセット
				this._iPaymentReadDB = null;
				status = -1;
				_errorMessage = "支払伝票の検索処理にて例外が発生しました。\r\n" + ex.Message;
			}

			return status;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="paymentDataWork">支払伝票ワーククラス</param>
        /// <returns>支払伝票クラス</returns>
        private SearchPaymentSlp CopyToSearchPaymentSlpFromPaymentDataWork(PaymentDataWork paymentDataWork)
        {
            SearchPaymentSlp searchPaymentSlp = new SearchPaymentSlp();

            searchPaymentSlp.CreateDateTime = paymentDataWork.CreateDateTime;              // 作成日付
            searchPaymentSlp.UpdateDateTime = paymentDataWork.UpdateDateTime;              // 更新日付
            searchPaymentSlp.EnterpriseCode = paymentDataWork.EnterpriseCode;              // 企業コード
            searchPaymentSlp.FileHeaderGuid = paymentDataWork.FileHeaderGuid;              // GUID
            searchPaymentSlp.UpdEmployeeCode = paymentDataWork.UpdEmployeeCode;            // 更新従業員コード
            searchPaymentSlp.UpdAssemblyId1 = paymentDataWork.UpdAssemblyId1;              // 更新アセンブリID1
            searchPaymentSlp.UpdAssemblyId2 = paymentDataWork.UpdAssemblyId2;              // 更新アセンブリID2
            searchPaymentSlp.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;        // 論理削除区分
            searchPaymentSlp.DebitNoteDiv = paymentDataWork.DebitNoteDiv;                  // 赤伝区分
            searchPaymentSlp.PaymentSlipNo = paymentDataWork.PaymentSlipNo;                // 支払伝票番号
            searchPaymentSlp.SupplierCd = paymentDataWork.SupplierCd;                      // 仕入先コード
            searchPaymentSlp.SupplierNm1 = paymentDataWork.SupplierNm1;                    // 仕入先名1
            searchPaymentSlp.SupplierNm2 = paymentDataWork.SupplierNm2;                    // 仕入先名2
            searchPaymentSlp.SupplierSnm = paymentDataWork.SupplierSnm;                    // 仕入先略称
            searchPaymentSlp.PayeeCode = paymentDataWork.PayeeCode;                        // 支払先コード
            searchPaymentSlp.PayeeName = paymentDataWork.PayeeName;                        // 支払先名称
            searchPaymentSlp.PayeeName2 = paymentDataWork.PayeeName2;                      // 支払先名称2
            searchPaymentSlp.PayeeSnm = paymentDataWork.PayeeSnm;                          // 支払先略称
            searchPaymentSlp.PaymentInpSectionCd = paymentDataWork.PaymentInpSectionCd;    // 支払入力拠点コード
            searchPaymentSlp.AddUpSecCode = paymentDataWork.AddUpSecCode;                  // 計上拠点コード
            searchPaymentSlp.UpdateSecCd = paymentDataWork.UpdateSecCd;                    // 更新拠点コード
            searchPaymentSlp.PaymentDate = paymentDataWork.PaymentDate;                    // 支払日付
            searchPaymentSlp.AddUpADate = paymentDataWork.AddUpADate;                      // 計上日付
            searchPaymentSlp.PaymentTotal = paymentDataWork.PaymentTotal;                  // 支払計
            searchPaymentSlp.Payment = paymentDataWork.Payment;                            // 支払金額
            searchPaymentSlp.FeePayment = paymentDataWork.FeePayment;                      // 手数料支払額
            searchPaymentSlp.DiscountPayment = paymentDataWork.DiscountPayment;            // 値引支払額
            searchPaymentSlp.AutoPayment = paymentDataWork.AutoPayment;                    // 自動支払区分
            searchPaymentSlp.DraftDrawingDate = paymentDataWork.DraftDrawingDate;          // 手形振出日
            searchPaymentSlp.DebitNoteLinkPayNo = paymentDataWork.DebitNoteLinkPayNo;      // 赤黒支払連結番号
            searchPaymentSlp.PaymentAgentCode = paymentDataWork.PaymentAgentCode;          // 支払担当者コード
            searchPaymentSlp.PaymentAgentName = paymentDataWork.PaymentAgentName;          // 支払担当者名称
            searchPaymentSlp.PaymentInputAgentCd = paymentDataWork.PaymentInputAgentCd;
            searchPaymentSlp.PaymentInputAgentNm = paymentDataWork.PaymentInputAgentNm;
            searchPaymentSlp.Outline = paymentDataWork.Outline;                            // 伝票摘要
            searchPaymentSlp.DraftKind = paymentDataWork.DraftKind;                        // 手形種類
            searchPaymentSlp.DraftKindName = paymentDataWork.DraftKindName;                // 手形種類名称
            searchPaymentSlp.DraftDivide = paymentDataWork.DraftDivide;                    // 手形区分
            searchPaymentSlp.DraftDivideName = paymentDataWork.DraftDivideName;            // 手形区分名称
            searchPaymentSlp.DraftNo = paymentDataWork.DraftNo;                            // 手形番号
            searchPaymentSlp.BankCode = paymentDataWork.BankCode;                          // 銀行コード
            searchPaymentSlp.BankName = paymentDataWork.BankName;                          // 銀行名称
            searchPaymentSlp.PaymentRowNoDtl = new int[10];
            searchPaymentSlp.PaymentRowNoDtl[0] = paymentDataWork.PaymentRowNo1;
            searchPaymentSlp.PaymentRowNoDtl[1] = paymentDataWork.PaymentRowNo2;
            searchPaymentSlp.PaymentRowNoDtl[2] = paymentDataWork.PaymentRowNo3;
            searchPaymentSlp.PaymentRowNoDtl[3] = paymentDataWork.PaymentRowNo4;
            searchPaymentSlp.PaymentRowNoDtl[4] = paymentDataWork.PaymentRowNo5;
            searchPaymentSlp.PaymentRowNoDtl[5] = paymentDataWork.PaymentRowNo6;
            searchPaymentSlp.PaymentRowNoDtl[6] = paymentDataWork.PaymentRowNo7;
            searchPaymentSlp.PaymentRowNoDtl[7] = paymentDataWork.PaymentRowNo8;
            searchPaymentSlp.PaymentRowNoDtl[8] = paymentDataWork.PaymentRowNo9;
            searchPaymentSlp.PaymentRowNoDtl[9] = paymentDataWork.PaymentRowNo10;
            searchPaymentSlp.MoneyKindCodeDtl = new int[10];
            searchPaymentSlp.MoneyKindCodeDtl[0] = paymentDataWork.MoneyKindCode1;
            searchPaymentSlp.MoneyKindCodeDtl[1] = paymentDataWork.MoneyKindCode2;
            searchPaymentSlp.MoneyKindCodeDtl[2] = paymentDataWork.MoneyKindCode3;
            searchPaymentSlp.MoneyKindCodeDtl[3] = paymentDataWork.MoneyKindCode4;
            searchPaymentSlp.MoneyKindCodeDtl[4] = paymentDataWork.MoneyKindCode5;
            searchPaymentSlp.MoneyKindCodeDtl[5] = paymentDataWork.MoneyKindCode6;
            searchPaymentSlp.MoneyKindCodeDtl[6] = paymentDataWork.MoneyKindCode7;
            searchPaymentSlp.MoneyKindCodeDtl[7] = paymentDataWork.MoneyKindCode8;
            searchPaymentSlp.MoneyKindCodeDtl[8] = paymentDataWork.MoneyKindCode9;
            searchPaymentSlp.MoneyKindCodeDtl[9] = paymentDataWork.MoneyKindCode10;
            searchPaymentSlp.MoneyKindNameDtl = new string[10];
            searchPaymentSlp.MoneyKindNameDtl[0] = paymentDataWork.MoneyKindName1;
            searchPaymentSlp.MoneyKindNameDtl[1] = paymentDataWork.MoneyKindName2;
            searchPaymentSlp.MoneyKindNameDtl[2] = paymentDataWork.MoneyKindName3;
            searchPaymentSlp.MoneyKindNameDtl[3] = paymentDataWork.MoneyKindName4;
            searchPaymentSlp.MoneyKindNameDtl[4] = paymentDataWork.MoneyKindName5;
            searchPaymentSlp.MoneyKindNameDtl[5] = paymentDataWork.MoneyKindName6;
            searchPaymentSlp.MoneyKindNameDtl[6] = paymentDataWork.MoneyKindName7;
            searchPaymentSlp.MoneyKindNameDtl[7] = paymentDataWork.MoneyKindName8;
            searchPaymentSlp.MoneyKindNameDtl[8] = paymentDataWork.MoneyKindName9;
            searchPaymentSlp.MoneyKindNameDtl[9] = paymentDataWork.MoneyKindName10;
            searchPaymentSlp.MoneyKindDivDtl = new int[10];
            searchPaymentSlp.MoneyKindDivDtl[0] = paymentDataWork.MoneyKindDiv1;
            searchPaymentSlp.MoneyKindDivDtl[1] = paymentDataWork.MoneyKindDiv2;
            searchPaymentSlp.MoneyKindDivDtl[2] = paymentDataWork.MoneyKindDiv3;
            searchPaymentSlp.MoneyKindDivDtl[3] = paymentDataWork.MoneyKindDiv4;
            searchPaymentSlp.MoneyKindDivDtl[4] = paymentDataWork.MoneyKindDiv5;
            searchPaymentSlp.MoneyKindDivDtl[5] = paymentDataWork.MoneyKindDiv6;
            searchPaymentSlp.MoneyKindDivDtl[6] = paymentDataWork.MoneyKindDiv7;
            searchPaymentSlp.MoneyKindDivDtl[7] = paymentDataWork.MoneyKindDiv8;
            searchPaymentSlp.MoneyKindDivDtl[8] = paymentDataWork.MoneyKindDiv9;
            searchPaymentSlp.MoneyKindDivDtl[9] = paymentDataWork.MoneyKindDiv10;
            searchPaymentSlp.PaymentDtl = new long[10];
            searchPaymentSlp.PaymentDtl[0] = paymentDataWork.Payment1;
            searchPaymentSlp.PaymentDtl[1] = paymentDataWork.Payment2;
            searchPaymentSlp.PaymentDtl[2] = paymentDataWork.Payment3;
            searchPaymentSlp.PaymentDtl[3] = paymentDataWork.Payment4;
            searchPaymentSlp.PaymentDtl[4] = paymentDataWork.Payment5;
            searchPaymentSlp.PaymentDtl[5] = paymentDataWork.Payment6;
            searchPaymentSlp.PaymentDtl[6] = paymentDataWork.Payment7;
            searchPaymentSlp.PaymentDtl[7] = paymentDataWork.Payment8;
            searchPaymentSlp.PaymentDtl[8] = paymentDataWork.Payment9;
            searchPaymentSlp.PaymentDtl[9] = paymentDataWork.Payment10;
            searchPaymentSlp.ValidityTermDtl = new DateTime[10];
            searchPaymentSlp.ValidityTermDtl[0] = paymentDataWork.ValidityTerm1;
            searchPaymentSlp.ValidityTermDtl[1] = paymentDataWork.ValidityTerm2;
            searchPaymentSlp.ValidityTermDtl[2] = paymentDataWork.ValidityTerm3;
            searchPaymentSlp.ValidityTermDtl[3] = paymentDataWork.ValidityTerm4;
            searchPaymentSlp.ValidityTermDtl[4] = paymentDataWork.ValidityTerm5;
            searchPaymentSlp.ValidityTermDtl[5] = paymentDataWork.ValidityTerm6;
            searchPaymentSlp.ValidityTermDtl[6] = paymentDataWork.ValidityTerm7;
            searchPaymentSlp.ValidityTermDtl[7] = paymentDataWork.ValidityTerm8;
            searchPaymentSlp.ValidityTermDtl[8] = paymentDataWork.ValidityTerm9;
            searchPaymentSlp.ValidityTermDtl[9] = paymentDataWork.ValidityTerm10;
            searchPaymentSlp.InputDay = paymentDataWork.InputDay;

            return searchPaymentSlp;
        }

        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 支払伝票検索処理
        /// </summary>
        /// <param name="searchParaPaymentRead">支払伝票検索パラメータ</param>
        /// <param name="searchPaymentSlpList">検索結果LIST</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票の検索処理を行います。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2006.05.31</br>
        /// </remarks>
        public int Search(SearchParaPaymentRead searchParaPaymentRead, out ArrayList searchPaymentSlpList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            searchPaymentSlpList = new ArrayList();

            try
            {
                object paymentSlpWorkObj;
                // 支払データ読込み
                status = this._iPaymentReadDB.Search(out paymentSlpWorkObj, (object)searchParaPaymentRead, 0, ConstantManagement.LogicalMode.GetData0);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            searchPaymentSlpList = DBAndXMLDataMergeParts.CopyPropertyInList((ArrayList)paymentSlpWorkObj, typeof(SearchPaymentSlp));
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                //オフライン時はnullをセット
                this._iPaymentReadDB = null;
                status = -1;
                _errorMessage = "支払伝票の検索処理にて例外が発生しました。\r\n" + ex.Message;
            }

            return status;
        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        #endregion
    }
}
