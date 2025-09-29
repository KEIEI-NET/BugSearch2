using System;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 入金検索アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金データの検索操作を行うアクセスクラスです。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.19</br>
	/// <br></br>
	/// <br>Update Note: 2007.01.29 18322 T.Kimura MA.NS用に入金・入金引当マスタのメンバコピーを変更</br>
    /// <br>Update Note: 2007.10.05 20081 疋田 勇人 DC.NS用に変更</br>
    /// <br>Update Note: 2008/06/26 30414 忍 幸史 Partsman用に変更</br>
    /// <br>Update Note: 2012/09/21 田建委</br>
    /// <br>管理番号   : 2012/10/17配信分</br>
    /// <br>             Redmine#32415 発行者の追加対応</br>
    /// <br></br>
	/// </remarks>
	public class SearchDepsitAcs
	{
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private IDepositReadDB _iDepositReadDB = null;

		/// <summary>
		/// 入金検索アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金検索アクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		public SearchDepsitAcs()
		{
			try
			{
				// リモートオブジェクト取得
				this._iDepositReadDB= (IDepositReadDB)MediationDepositReadDB.GetDepositReadDB();
			}
			catch (Exception)
			{				
				// オフライン時はnullをセット
				this._iDepositReadDB = null;
			}
        }

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 入金読込処理
		/// </summary>
		/// <param name="searchParaDepositRead">検索条件</param>
		/// <param name="depsitMainList">入金情報</param>
		/// <param name="depositAlwList">入金引当情報</param>
		/// <param name="errmsg">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : 条件を元に入金情報・入金引当情報の取得を行います</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		public int SearchDB(SearchParaDepositRead searchParaDepositRead, out ArrayList depsitMainList,  out ArrayList depositAlwList, out string errmsg)
		{

			object depsitMainWorListkObj = null;
			object depositAlwWorkListObj = null;

			depsitMainList = null;
			depositAlwList = null;
			errmsg = "";
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// 入金データ読込み
				status = this._iDepositReadDB.Search(out depsitMainWorListkObj, out depositAlwWorkListObj, searchParaDepositRead, 0, ConstantManagement.LogicalMode.GetData0);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					ArrayList depsitMainWorkList = (ArrayList)depsitMainWorListkObj;
					ArrayList depositAlwWorkList = (ArrayList)depositAlwWorkListObj;

					// クラスメンバーコピー処理（入金マスタワーククラス⇒入金マスタクラス）
					depsitMainList = this.CopyToDepsitMainFromDepsitMainWork(depsitMainWorkList);

					// クラスメンバーコピー処理（入金引当マスタワーククラス⇒入金引当マスタクラス）
					depositAlwList = this.CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);
				}
			}
			catch (Exception ex)
			{
				//オフライン時はnullをセット
				this._iDepositReadDB = null;
				status = (int)ConstantManagement.DB_Status.ctDB_OFFLINE;

				errmsg = ex.Message;
			}

			return status;
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 入金読込処理
        /// </summary>
        /// <param name="searchParaDepositRead">検索条件</param>
        /// <param name="depsitDataList">入金情報</param>
        /// <param name="depositAlwList">入金引当情報</param>
        /// <param name="errmsg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : 条件を元に入金情報・入金引当情報の取得を行います</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        public int SearchDB(SearchParaDepositRead searchParaDepositRead, out ArrayList depsitDataList, out ArrayList depositAlwList, out string errmsg)
        {
            
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            object objDepsitDataWork = null;
            object objDepsitAlwWork = null;
            object objSearchParaDepositRead = searchParaDepositRead;

            errmsg = "";
            depsitDataList = new ArrayList();
            depositAlwList = new ArrayList();

            try
            {
                // 入金データ読込み
                status = this._iDepositReadDB.Search(out objDepsitDataWork, out objDepsitAlwWork, objSearchParaDepositRead, 0, ConstantManagement.LogicalMode.GetData0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList depsitDataWorkList = (ArrayList)objDepsitDataWork;
                    ArrayList depsitAlwWorkList = (ArrayList)objDepsitAlwWork;

                    // クラスメンバーコピー処理（入金マスタワーククラス⇒入金マスタクラス）
                    depsitDataList = this.CopyToDepsitMainFromDepsitDataWork(depsitDataWorkList);

                    // クラスメンバーコピー処理（入金引当マスタワーククラス⇒入金引当マスタクラス）
                    depositAlwList = this.CopyToDepositAlwFromDepositAlwWork(depsitAlwWorkList);
                }
            }
            catch (Exception ex)
            {
                //オフライン時はnullをセット
                this._iDepositReadDB = null;
                status = (int)ConstantManagement.DB_Status.ctDB_OFFLINE;

                errmsg = ex.Message;
            }

            return status;
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// クラスメンバーコピー処理（入金マスタワーククラス⇒入金マスタクラス）
		/// </summary>
		/// <param name="depsitMainWorkList">入金マスタワーククラス</param>
		/// <returns>入金マスタクラス</returns>
		/// <remarks>
		/// <br>Note       : 入金マスタワーククラスから入金マスタクラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.19</br>
        /// <br>Update Note: 2007.01.29 18322 T.Kimura MA.NS用に変更</br>
	    /// <br></br>
		/// </remarks>
		private ArrayList CopyToDepsitMainFromDepsitMainWork(ArrayList depsitMainWorkList)
		{
			ArrayList depositAlwList = new ArrayList();

			foreach (DepsitMainWork depsitMainWork in depsitMainWorkList)
			{

				SearchDepsitMain depsitMain = new SearchDepsitMain();

                // ↓ 20070129 18322 c MA.NS用に変更
                #region SF 入金マスタワーククラス⇒入金マスタクラス（全てコメントアウト）
                //depsitMain.CreateDateTime		= depsitMainWork.CreateDateTime;
				//depsitMain.UpdateDateTime		= depsitMainWork.UpdateDateTime;
				//depsitMain.EnterpriseCode		= depsitMainWork.EnterpriseCode;
				//depsitMain.FileHeaderGuid		= depsitMainWork.FileHeaderGuid;
				//depsitMain.UpdEmployeeCode		= depsitMainWork.UpdEmployeeCode;
				//depsitMain.UpdAssemblyId1		= depsitMainWork.UpdAssemblyId1;
				//depsitMain.UpdAssemblyId2		= depsitMainWork.UpdAssemblyId2;
				//depsitMain.LogicalDeleteCode	= depsitMainWork.LogicalDeleteCode;
				//depsitMain.DepositDebitNoteCd	= depsitMainWork.DepositDebitNoteCd;
				//depsitMain.DepositSlipNo		= depsitMainWork.DepositSlipNo;
				//depsitMain.DepositKindCode		= depsitMainWork.DepositKindCode;
				//depsitMain.CustomerCode			= depsitMainWork.CustomerCode;
				//depsitMain.DepositCd			= depsitMainWork.DepositCd;
				//depsitMain.DepositTotal			= depsitMainWork.DepositTotal;
				//depsitMain.Outline				= depsitMainWork.Outline;
				//depsitMain.AcceptAnOrderSalesNo	= depsitMainWork.AcceptAnOrderSalesNo;
				//depsitMain.InputDepositSecCd	= depsitMainWork.InputDepositSecCd;
				//depsitMain.DepositDate			= depsitMainWork.DepositDate;
				//depsitMain.AddUpSecCode			= depsitMainWork.AddUpSecCode;
				//depsitMain.AddUpADate			= depsitMainWork.AddUpADate;
				//depsitMain.UpdateSecCd			= depsitMainWork.UpdateSecCd;
				//depsitMain.DepositKindName		= depsitMainWork.DepositKindName;
				//depsitMain.DepositAllowance		= depsitMainWork.DepositAllowance;
				//depsitMain.DepositAlwcBlnce		= depsitMainWork.DepositAlwcBlnce;
				//depsitMain.DepositAgentCode		= depsitMainWork.DepositAgentCode;
				//depsitMain.DepositKindDivCd		= depsitMainWork.DepositKindDivCd;
				//depsitMain.FeeDeposit			= depsitMainWork.FeeDeposit;
				//depsitMain.DiscountDeposit		= depsitMainWork.DiscountDeposit;
				//depsitMain.CreditOrLoanCd		= depsitMainWork.CreditOrLoanCd;
				//depsitMain.CreditCompanyCode	= depsitMainWork.CreditCompanyCode;
				//depsitMain.Deposit				= depsitMainWork.Deposit;
				//depsitMain.DraftDrawingDate		= depsitMainWork.DraftDrawingDate;
				//depsitMain.DraftPayTimeLimit	= depsitMainWork.DraftPayTimeLimit;
				//depsitMain.DebitNoteLinkDepoNo	= depsitMainWork.DebitNoteLinkDepoNo;
				//depsitMain.LastReconcileAddUpDt	= depsitMainWork.LastReconcileAddUpDt;
				//depsitMain.AutoDepositCd		= depsitMainWork.AutoDepositCd;
				//depsitMain.AcpOdrDeposit		= depsitMainWork.AcpOdrDeposit;
				//depsitMain.AcpOdrChargeDeposit	= depsitMainWork.AcpOdrChargeDeposit;
				//depsitMain.AcpOdrDisDeposit		= depsitMainWork.AcpOdrDisDeposit;
				//depsitMain.VariousCostDeposit	= depsitMainWork.VariousCostDeposit;
				//depsitMain.VarCostChargeDeposit	= depsitMainWork.VarCostChargeDeposit;
				//depsitMain.VarCostDisDeposit	= depsitMainWork.VarCostDisDeposit;
				//depsitMain.AcpOdrDepositAlwc	= depsitMainWork.AcpOdrDepositAlwc;
				//depsitMain.AcpOdrDepoAlwcBlnce	= depsitMainWork.AcpOdrDepoAlwcBlnce;
				//depsitMain.VarCostDepoAlwc		= depsitMainWork.VarCostDepoAlwc;
				//depsitMain.VarCostDepoAlwcBlnce	= depsitMainWork.VarCostDepoAlwcBlnce;
                #endregion

                // MA.NS 入金マスタワーククラス⇒入金マスタクラス
                // 作成日時
                depsitMain.CreateDateTime       = depsitMainWork.CreateDateTime;
                // 更新日時                           
                depsitMain.UpdateDateTime       = depsitMainWork.UpdateDateTime;
                // 企業コード                         
                depsitMain.EnterpriseCode       = depsitMainWork.EnterpriseCode;
                // GUID                               
                depsitMain.FileHeaderGuid       = depsitMainWork.FileHeaderGuid;
                // 更新従業員コード                   
                depsitMain.UpdEmployeeCode      = depsitMainWork.UpdEmployeeCode;
                // 更新アセンブリID1                  
                depsitMain.UpdAssemblyId1       = depsitMainWork.UpdAssemblyId1;
                // 更新アセンブリID2                  
                depsitMain.UpdAssemblyId2       = depsitMainWork.UpdAssemblyId2;
                // 論理削除区分                       
                depsitMain.LogicalDeleteCode    = depsitMainWork.LogicalDeleteCode;
                // 入金赤黒区分                       
                depsitMain.DepositDebitNoteCd   = depsitMainWork.DepositDebitNoteCd;
                // 入金伝票番号                       
                depsitMain.DepositSlipNo        = depsitMainWork.DepositSlipNo;
                // 受注番号                           
                // depsitMain.AcceptAnOrderNo      = depsitMainWork.AcceptAnOrderNo;   // 2007.10.05 hikita del
                // 売上伝票番号
                depsitMain.SalesSlipNum         = depsitMainWork.SalesSlipNum;         // 2007.10.05 hikita add
                // 入金入力拠点コード                 
                depsitMain.InputDepositSecCd    = depsitMainWork.InputDepositSecCd;
                // 計上拠点コード                     
                depsitMain.AddUpSecCode         = depsitMainWork.AddUpSecCode;
                // 更新拠点コード                     
                depsitMain.UpdateSecCd          = depsitMainWork.UpdateSecCd;
                // 入金日付                           
                depsitMain.DepositDate          = depsitMainWork.DepositDate;
                // 計上日付                           
                depsitMain.AddUpADate           = depsitMainWork.AddUpADate;
                // 入金金種コード                     
                depsitMain.DepositKindCode      = depsitMainWork.DepositKindCode;
                // 入金金種名称                       
                depsitMain.DepositKindName      = depsitMainWork.DepositKindName;
                // 入金金種区分                       
                depsitMain.DepositKindDivCd     = depsitMainWork.DepositKindDivCd;
                // 入金計                             
                depsitMain.DepositTotal         = depsitMainWork.DepositTotal;
                // 入金金額                           
                depsitMain.Deposit              = depsitMainWork.Deposit;
                // 手数料入金額                       
                depsitMain.FeeDeposit           = depsitMainWork.FeeDeposit;
                // 値引入金額                         
                depsitMain.DiscountDeposit      = depsitMainWork.DiscountDeposit;
                // リベート入金額                     
                // depsitMain.RebateDeposit        = depsitMainWork.RebateDeposit;      // 2007.10.05 hikita del
                // 自動入金区分                       
                depsitMain.AutoDepositCd        = depsitMainWork.AutoDepositCd;
                // 預り金区分                         
                depsitMain.DepositCd            = depsitMainWork.DepositCd;
                // クレジット／ローン区分             
                // depsitMain.CreditOrLoanCd       = depsitMainWork.CreditOrLoanCd;     // 2007.10.05 hikita del
                // クレジット会社コード               
                // depsitMain.CreditCompanyCode    = depsitMainWork.CreditCompanyCode;  // 2007.10.05 hikita del
                // 手形振出日                         
                depsitMain.DraftDrawingDate     = depsitMainWork.DraftDrawingDate;
                // 手形支払期日                       
                depsitMain.DraftPayTimeLimit    = depsitMainWork.DraftPayTimeLimit;
                // 入金引当額                         
                depsitMain.DepositAllowance     = depsitMainWork.DepositAllowance;
                // 入金引当残高                       
                depsitMain.DepositAlwcBlnce     = depsitMainWork.DepositAlwcBlnce;
                // 赤黒入金連結番号                   
                depsitMain.DebitNoteLinkDepoNo  = depsitMainWork.DebitNoteLinkDepoNo;
                // 最終消し込み計上日                 
                depsitMain.LastReconcileAddUpDt = depsitMainWork.LastReconcileAddUpDt;
                // 入金担当者コード                   
                depsitMain.DepositAgentCode     = depsitMainWork.DepositAgentCode;
                // 入金担当者名称                     
                depsitMain.DepositAgentNm       = depsitMainWork.DepositAgentNm;
                // 請求先コード                       
                depsitMain.ClaimCode            = depsitMainWork.ClaimCode;
                // 請求先名称                         
                depsitMain.ClaimName            = depsitMainWork.ClaimName;
                // 請求先名称2                        
                depsitMain.ClaimName2           = depsitMainWork.ClaimName2;
                // 請求先略称                        
                depsitMain.ClaimSnm             = depsitMainWork.ClaimSnm;
                // 得意先コード                       
                depsitMain.CustomerCode         = depsitMainWork.CustomerCode;
                // 得意先名称                         
                depsitMain.CustomerName         = depsitMainWork.CustomerName;
                // 得意先名称2                        
                depsitMain.CustomerName2        = depsitMainWork.CustomerName2;
                // 得意先略称                        
                depsitMain.CustomerSnm          = depsitMainWork.CustomerSnm;
                
                // 伝票摘要                           
                depsitMain.Outline              = depsitMainWork.Outline;
                // ↑ 20070129 18322 c

                // 2007.10.05 hikita add start --------------------------------------------->>
                // 銀行コード
                depsitMain.BankCode             = depsitMainWork.BankCode;
                // 銀行名称
                depsitMain.BankName             = depsitMainWork.BankName;
                // 手形番号
                depsitMain.DraftNo              = depsitMainWork.DraftNo;
                // 手形種類
                depsitMain.DraftKind            = depsitMainWork.DraftKind;
                // 手形種類名称
                depsitMain.DraftKindName        = depsitMainWork.DraftKindName;
                // 手形区分
                depsitMain.DraftDivide          = depsitMainWork.DraftDivide;
                // 手形区分名称
                depsitMain.DraftDivideName      = depsitMainWork.DraftDivideName;
                // 2007.10.05 hikita add end -----------------------------------------------<<

                switch (depsitMain.DepositCd)
				{
					case 0:
						depsitMain.DepositNm = "通常入金";
						break;
					case 1:
						depsitMain.DepositNm = "預り金";
						break;
				}

				depositAlwList.Add(depsitMain);
			}

			return depositAlwList;
		}
        
        /// <summary>
		/// クラスメンバーコピー処理（入金引当マスタワーククラス⇒入金引当マスタクラス）
		/// </summary>
		/// <param name="depositAlwWorkList">入金引当マスタワーククラス</param>
		/// <returns>入金引当マスタクラス</returns>
		/// <remarks>
		/// <br>Note       : 入金引当マスタワーククラスから入金引当マスタクラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.19</br>
        /// <br>Update Note: 2007.01.29 18322 T.Kimura MA.NS用に変更</br>
	    /// <br></br>
		/// </remarks>
		private ArrayList CopyToDepositAlwFromDepositAlwWork(ArrayList depositAlwWorkList)
		{
			ArrayList depositAlwList = new ArrayList();

			foreach (DepositAlwWork depositAlwWork in depositAlwWorkList)
			{
				SearchDepositAlw depositAlw = new SearchDepositAlw();

                // ↓ 20070129 18322 c MA.NS用に変更
                #region SF 入金引当マスタワーククラス⇒入金引当マスタクラス（全てコメントアウト）
                //depositAlw.CreateDateTime		= depositAlwWork.CreateDateTime;
				//depositAlw.UpdateDateTime		= depositAlwWork.UpdateDateTime;
				//depositAlw.EnterpriseCode		= depositAlwWork.EnterpriseCode;
				//depositAlw.FileHeaderGuid		= depositAlwWork.FileHeaderGuid;
				//depositAlw.UpdEmployeeCode		= depositAlwWork.UpdEmployeeCode;
				//depositAlw.UpdAssemblyId1		= depositAlwWork.UpdAssemblyId1;
				//depositAlw.UpdAssemblyId2		= depositAlwWork.UpdAssemblyId2;
				//depositAlw.LogicalDeleteCode	= depositAlwWork.LogicalDeleteCode;
				//depositAlw.CustomerCode			= depositAlwWork.CustomerCode;
				//depositAlw.AddUpSecCode			= depositAlwWork.AddUpSecCode;
				//depositAlw.AcceptAnOrderNo		= depositAlwWork.AcceptAnOrderNo;
				//depositAlw.DepositSlipNo		= depositAlwWork.DepositSlipNo;
				//depositAlw.DepositKindCode		= depositAlwWork.DepositKindCode;
				//depositAlw.DepositInputDate		= depositAlwWork.DepositInputDate;
				//depositAlw.DepositAllowance		= depositAlwWork.DepositAllowance;
				//depositAlw.ReconcileDate		= depositAlwWork.ReconcileDate;
				//depositAlw.ReconcileAddUpDate	= depositAlwWork.ReconcileAddUpDate;
				//depositAlw.DebitNoteOffSetCd	= depositAlwWork.DebitNoteOffSetCd;
				//depositAlw.DepositCd			= depositAlwWork.DepositCd;
				//depositAlw.CreditOrLoanCd		= depositAlwWork.CreditOrLoanCd;
				//depositAlw.AcpOdrDepositAlwc	= depositAlwWork.AcpOdrDepositAlwc;
				//depositAlw.VarCostDepoAlwc		= depositAlwWork.VarCostDepoAlwc;
                #endregion

                // 作成日時
                depositAlw.CreateDateTime      = depositAlwWork.CreateDateTime;
                // 更新日時                          
                depositAlw.UpdateDateTime      = depositAlwWork.UpdateDateTime;
                // 企業コード                        
                depositAlw.EnterpriseCode      = depositAlwWork.EnterpriseCode;
                // GUID                              
                depositAlw.FileHeaderGuid      = depositAlwWork.FileHeaderGuid;
                // 更新従業員コード                  
                depositAlw.UpdEmployeeCode     = depositAlwWork.UpdEmployeeCode;
                // 更新アセンブリID1                 
                depositAlw.UpdAssemblyId1      = depositAlwWork.UpdAssemblyId1;
                // 更新アセンブリID2                 
                depositAlw.UpdAssemblyId2      = depositAlwWork.UpdAssemblyId2;
                // 論理削除区分                      
                depositAlw.LogicalDeleteCode   = depositAlwWork.LogicalDeleteCode;
                // 入金入力拠点コード                
                depositAlw.InputDepositSecCd   = depositAlwWork.InputDepositSecCd;
                // 計上拠点コード                    
                depositAlw.AddUpSecCode        = depositAlwWork.AddUpSecCode;
                // 消込み日                          
                depositAlw.ReconcileDate       = depositAlwWork.ReconcileDate;
                // 消込み計上日                      
                depositAlw.ReconcileAddUpDate  = depositAlwWork.ReconcileAddUpDate;
                // 入金伝票番号                      
                depositAlw.DepositSlipNo       = depositAlwWork.DepositSlipNo;

                // 入金金種コード                    
                depositAlw.DepositKindCode     = depositAlwWork.DepositKindCode;
                // 入金金種名称                      
                depositAlw.DepositKindName     = depositAlwWork.DepositKindName;

                // 入金引当額                        
                depositAlw.DepositAllowance    = depositAlwWork.DepositAllowance;
                // 入金担当者コード                  
                depositAlw.DepositAgentCode    = depositAlwWork.DepositAgentCode;
                // 入金担当者名称                    
                depositAlw.DepositAgentNm      = depositAlwWork.DepositAgentNm;
                // 得意先コード                      
                depositAlw.CustomerCode        = depositAlwWork.CustomerCode;
                // 得意先名称                        
                depositAlw.CustomerName        = depositAlwWork.CustomerName;
                // 得意先名称2                       
                depositAlw.CustomerName2       = depositAlwWork.CustomerName2;
                // 受注番号                          
                //depositAlw.AcceptAnOrderNo     = depositAlwWork.AcceptAnOrderNo;  // 2007.10.05 hikita del
                // 売上伝票番号
                depositAlw.SalesSlipNum        = depositAlwWork.SalesSlipNum;       // 2007.10.05 hikita add
                // 赤伝相殺区分                      
                depositAlw.DebitNoteOffSetCd   = depositAlwWork.DebitNoteOffSetCd;

                // 預り金区分                        
                depositAlw.DepositCd           = depositAlwWork.DepositCd;

                // クレジット／ローン区分            
                // depositAlw.CreditOrLoanCd      = depositAlwWork.CreditOrLoanCd;  // 2007.10.05 hikita del
                // ↑ 20070129 18322 c

                depositAlwList.Add(depositAlw);
			}

			return depositAlwList;
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// クラスメンバーコピー処理（入金マスタワーク⇒入金マスタ）
        /// </summary>
        /// <param name="depsitDataWorkList">入金マスタワーククラス</param>
        /// <returns>入金マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 入金マスタワーククラスから入金マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// <br>Update Note: 2012/09/21 田建委</br>
        /// <br>管理番号   : 2012/10/17配信分</br>
        /// <br>             Redmine#32415 発行者の追加対応</br>
        /// </remarks>
        private ArrayList CopyToDepsitMainFromDepsitDataWork(ArrayList depsitDataWorkList)
        {
            ArrayList depositAlwList = new ArrayList();

            foreach (DepsitDataWork depsitDataWork in depsitDataWorkList)
            {
                SearchDepsitMain depsitMain = new SearchDepsitMain();

                depsitMain.CreateDateTime = depsitDataWork.CreateDateTime;                  // 作成日時
                depsitMain.UpdateDateTime = depsitDataWork.UpdateDateTime;                  // 更新日時
                depsitMain.EnterpriseCode = depsitDataWork.EnterpriseCode;                  // 企業コード
                depsitMain.FileHeaderGuid = depsitDataWork.FileHeaderGuid;                  // GUID
                depsitMain.UpdEmployeeCode = depsitDataWork.UpdEmployeeCode;                // 更新従業員コード
                depsitMain.UpdAssemblyId1 = depsitDataWork.UpdAssemblyId1;                  // 更新アセンブリID1
                depsitMain.UpdAssemblyId2 = depsitDataWork.UpdAssemblyId2;                  // 更新アセンブリID2
                depsitMain.LogicalDeleteCode = depsitDataWork.LogicalDeleteCode;            // 論理削除区分
                depsitMain.DepositDebitNoteCd = depsitDataWork.DepositDebitNoteCd;          // 入金赤黒区分
                depsitMain.DepositSlipNo = depsitDataWork.DepositSlipNo;                    // 入金伝票番号
                depsitMain.SalesSlipNum = depsitDataWork.SalesSlipNum;                      // 売上伝票番号
                depsitMain.InputDepositSecCd = depsitDataWork.InputDepositSecCd;            // 入金入力拠点コード
                depsitMain.AddUpSecCode = depsitDataWork.AddUpSecCode;                      // 計上拠点コード
                depsitMain.UpdateSecCd = depsitDataWork.UpdateSecCd;                        // 更新拠点コード
                depsitMain.AcptAnOdrStatus = depsitDataWork.AcptAnOdrStatus;                // 受注ステータス
                depsitMain.DepositDate = depsitDataWork.DepositDate;                        // 入金日付
                depsitMain.AddUpADate = depsitDataWork.AddUpADate;                          // 計上日付
                depsitMain.Deposit = depsitDataWork.Deposit;                                // 入金金額
                depsitMain.FeeDeposit = depsitDataWork.FeeDeposit;                          // 手数料入金額
                depsitMain.DiscountDeposit = depsitDataWork.DiscountDeposit;                // 値引入金額
                depsitMain.DepositAllowance = depsitDataWork.DepositAllowance;              // 入金引当額
                depsitMain.DepositAlwcBlnce = depsitDataWork.DepositAlwcBlnce;              // 入金引当残高
                depsitMain.AutoDepositCd = depsitDataWork.AutoDepositCd;                    // 自動入金区分
                depsitMain.DraftDrawingDate = depsitDataWork.DraftDrawingDate;              // 手形振出日
                depsitMain.DebitNoteLinkDepoNo = depsitDataWork.DebitNoteLinkDepoNo;        // 赤黒入金連結番号
                depsitMain.LastReconcileAddUpDt = depsitDataWork.LastReconcileAddUpDt;      // 最終消し込み計上日
                depsitMain.DepositAgentCode = depsitDataWork.DepositAgentCode;              // 入金担当者コード
                depsitMain.DepositAgentNm = depsitDataWork.DepositAgentNm;                  // 入金担当者名称
                //----- ADD 2012/09/21 田建委 redmine#32415 ---------->>>>>
                depsitMain.DepositInputAgentCd = depsitDataWork.DepositInputAgentCd;        // 入金入力者コード
                depsitMain.DepositInputAgentNm = depsitDataWork.DepositInputAgentNm;        // 入金入力者名
                //----- ADD 2012/09/21 田建委 redmine#32415 ----------<<<<<
                depsitMain.ClaimCode = depsitDataWork.ClaimCode;                            // 請求先コード
                depsitMain.ClaimName = depsitDataWork.ClaimName;                            // 請求先名称
                depsitMain.ClaimName2 = depsitDataWork.ClaimName2;                          // 請求先名称2
                depsitMain.ClaimSnm = depsitDataWork.ClaimSnm;                              // 請求先略称
                depsitMain.CustomerCode = depsitDataWork.CustomerCode;                      // 得意先コード
                depsitMain.CustomerName = depsitDataWork.CustomerName;                      // 得意先名称
                depsitMain.CustomerName2 = depsitDataWork.CustomerName2;                    // 得意先名称2
                depsitMain.CustomerSnm = depsitDataWork.CustomerSnm;                        // 得意先略称
                depsitMain.Outline = depsitDataWork.Outline;                                // 伝票摘要
                depsitMain.BankCode = depsitDataWork.BankCode;                              // 銀行コード
                depsitMain.BankName = depsitDataWork.BankName;                              // 銀行名称
                depsitMain.DraftNo = depsitDataWork.DraftNo;                                // 手形番号
                depsitMain.DraftKind = depsitDataWork.DraftKind;                            // 手形種類
                depsitMain.DraftKindName = depsitDataWork.DraftKindName;                    // 手形種類名称
                depsitMain.DraftDivide = depsitDataWork.DraftDivide;                        // 手形区分
                depsitMain.DraftDivideName = depsitDataWork.DraftDivideName;                // 手形区分名称
                depsitMain.DepositNm = "通常入金";                                          // 預かり金区分名称
                // 入金行番号1～10
                depsitMain.DepositRowNo = new Int32[10];
                depsitMain.DepositRowNo[0] = depsitDataWork.DepositRowNo1;
                depsitMain.DepositRowNo[1] = depsitDataWork.DepositRowNo2;
                depsitMain.DepositRowNo[2] = depsitDataWork.DepositRowNo3;
                depsitMain.DepositRowNo[3] = depsitDataWork.DepositRowNo4;
                depsitMain.DepositRowNo[4] = depsitDataWork.DepositRowNo5;
                depsitMain.DepositRowNo[5] = depsitDataWork.DepositRowNo6;
                depsitMain.DepositRowNo[6] = depsitDataWork.DepositRowNo7;
                depsitMain.DepositRowNo[7] = depsitDataWork.DepositRowNo8;
                depsitMain.DepositRowNo[8] = depsitDataWork.DepositRowNo9;
                depsitMain.DepositRowNo[9] = depsitDataWork.DepositRowNo10;
                // 金種コード1～10
                depsitMain.MoneyKindCode = new Int32[10];
                depsitMain.MoneyKindCode[0] = depsitDataWork.MoneyKindCode1;
                depsitMain.MoneyKindCode[1] = depsitDataWork.MoneyKindCode2;
                depsitMain.MoneyKindCode[2] = depsitDataWork.MoneyKindCode3;
                depsitMain.MoneyKindCode[3] = depsitDataWork.MoneyKindCode4;
                depsitMain.MoneyKindCode[4] = depsitDataWork.MoneyKindCode5;
                depsitMain.MoneyKindCode[5] = depsitDataWork.MoneyKindCode6;
                depsitMain.MoneyKindCode[6] = depsitDataWork.MoneyKindCode7;
                depsitMain.MoneyKindCode[7] = depsitDataWork.MoneyKindCode8;
                depsitMain.MoneyKindCode[8] = depsitDataWork.MoneyKindCode9;
                depsitMain.MoneyKindCode[9] = depsitDataWork.MoneyKindCode10;
                // 金種名称1～10
                depsitMain.MoneyKindName = new String[10];
                depsitMain.MoneyKindName[0] = depsitDataWork.MoneyKindName1;
                depsitMain.MoneyKindName[1] = depsitDataWork.MoneyKindName2;
                depsitMain.MoneyKindName[2] = depsitDataWork.MoneyKindName3;
                depsitMain.MoneyKindName[3] = depsitDataWork.MoneyKindName4;
                depsitMain.MoneyKindName[4] = depsitDataWork.MoneyKindName5;
                depsitMain.MoneyKindName[5] = depsitDataWork.MoneyKindName6;
                depsitMain.MoneyKindName[6] = depsitDataWork.MoneyKindName7;
                depsitMain.MoneyKindName[7] = depsitDataWork.MoneyKindName8;
                depsitMain.MoneyKindName[8] = depsitDataWork.MoneyKindName9;
                depsitMain.MoneyKindName[9] = depsitDataWork.MoneyKindName10;
                // 金種区分1～10
                depsitMain.MoneyKindDiv = new Int32[10];
                depsitMain.MoneyKindDiv[0] = depsitDataWork.MoneyKindDiv1;
                depsitMain.MoneyKindDiv[1] = depsitDataWork.MoneyKindDiv2;
                depsitMain.MoneyKindDiv[2] = depsitDataWork.MoneyKindDiv3;
                depsitMain.MoneyKindDiv[3] = depsitDataWork.MoneyKindDiv4;
                depsitMain.MoneyKindDiv[4] = depsitDataWork.MoneyKindDiv5;
                depsitMain.MoneyKindDiv[5] = depsitDataWork.MoneyKindDiv6;
                depsitMain.MoneyKindDiv[6] = depsitDataWork.MoneyKindDiv7;
                depsitMain.MoneyKindDiv[7] = depsitDataWork.MoneyKindDiv8;
                depsitMain.MoneyKindDiv[8] = depsitDataWork.MoneyKindDiv9;
                depsitMain.MoneyKindDiv[9] = depsitDataWork.MoneyKindDiv10;
                // 入金金額1～10
                depsitMain.DepositDtl = new Int64[10];
                depsitMain.DepositDtl[0] = depsitDataWork.Deposit1;
                depsitMain.DepositDtl[1] = depsitDataWork.Deposit2;
                depsitMain.DepositDtl[2] = depsitDataWork.Deposit3;
                depsitMain.DepositDtl[3] = depsitDataWork.Deposit4;
                depsitMain.DepositDtl[4] = depsitDataWork.Deposit5;
                depsitMain.DepositDtl[5] = depsitDataWork.Deposit6;
                depsitMain.DepositDtl[6] = depsitDataWork.Deposit7;
                depsitMain.DepositDtl[7] = depsitDataWork.Deposit8;
                depsitMain.DepositDtl[8] = depsitDataWork.Deposit9;
                depsitMain.DepositDtl[9] = depsitDataWork.Deposit10;
                // 有効期限1～10
                depsitMain.ValidityTerm = new DateTime[10];
                depsitMain.ValidityTerm[0] = depsitDataWork.ValidityTerm1;
                depsitMain.ValidityTerm[1] = depsitDataWork.ValidityTerm2;
                depsitMain.ValidityTerm[2] = depsitDataWork.ValidityTerm3;
                depsitMain.ValidityTerm[3] = depsitDataWork.ValidityTerm4;
                depsitMain.ValidityTerm[4] = depsitDataWork.ValidityTerm5;
                depsitMain.ValidityTerm[5] = depsitDataWork.ValidityTerm6;
                depsitMain.ValidityTerm[6] = depsitDataWork.ValidityTerm7;
                depsitMain.ValidityTerm[7] = depsitDataWork.ValidityTerm8;
                depsitMain.ValidityTerm[8] = depsitDataWork.ValidityTerm9;
                depsitMain.ValidityTerm[9] = depsitDataWork.ValidityTerm10;

                depositAlwList.Add(depsitMain);
            }

            return depositAlwList;
        }

		/// <summary>
		/// クラスメンバーコピー処理（入金引当マスタワーク⇒入金引当マスタ）
		/// </summary>
		/// <param name="depositAlwWorkList">入金引当マスタワーククラス</param>
		/// <returns>入金引当マスタクラス</returns>
		/// <remarks>
		/// <br>Note       : 入金引当マスタワーククラスから入金引当マスタクラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/06/26</br>
	    /// <br></br>
		/// </remarks>
		private ArrayList CopyToDepositAlwFromDepositAlwWork(ArrayList depositAlwWorkList)
		{
			ArrayList depositAlwList = new ArrayList();

			foreach (DepositAlwWork depositAlwWork in depositAlwWorkList)
			{
				SearchDepositAlw depositAlw = new SearchDepositAlw();

                depositAlw.CreateDateTime = depositAlwWork.CreateDateTime;          // 作成日時
                depositAlw.UpdateDateTime = depositAlwWork.UpdateDateTime;          // 更新日時
                depositAlw.EnterpriseCode = depositAlwWork.EnterpriseCode;          // 企業コード
                depositAlw.FileHeaderGuid = depositAlwWork.FileHeaderGuid;          // GUID
                depositAlw.UpdEmployeeCode = depositAlwWork.UpdEmployeeCode;        // 更新従業員コード
                depositAlw.UpdAssemblyId1 = depositAlwWork.UpdAssemblyId1;          // 更新アセンブリID1
                depositAlw.UpdAssemblyId2 = depositAlwWork.UpdAssemblyId2;          // 更新アセンブリID2
                depositAlw.LogicalDeleteCode = depositAlwWork.LogicalDeleteCode;    // 論理削除区分
                depositAlw.InputDepositSecCd = depositAlwWork.InputDepositSecCd;    // 入金入力拠点コード
                depositAlw.AddUpSecCode = depositAlwWork.AddUpSecCode;              // 計上拠点コード
                depositAlw.AcptAnOdrStatus = depositAlwWork.AcptAnOdrStatus;        // 受注ステータス
                depositAlw.ReconcileDate = depositAlwWork.ReconcileDate;            // 消込み日
                depositAlw.ReconcileAddUpDate = depositAlwWork.ReconcileAddUpDate;  // 消込み計上日
                depositAlw.DepositSlipNo = depositAlwWork.DepositSlipNo;            // 入金伝票番号
                depositAlw.DepositAllowance = depositAlwWork.DepositAllowance;      // 入金引当額
                depositAlw.DepositAgentCode = depositAlwWork.DepositAgentCode;      // 入金担当者コード
                depositAlw.DepositAgentNm = depositAlwWork.DepositAgentNm;          // 入金担当者名称
                depositAlw.CustomerCode = depositAlwWork.CustomerCode;              // 得意先コード
                depositAlw.CustomerName = depositAlwWork.CustomerName;              // 得意先名称
                depositAlw.CustomerName2 = depositAlwWork.CustomerName2;            // 得意先名称2
                depositAlw.SalesSlipNum = depositAlwWork.SalesSlipNum;              // 売上伝票番号
                depositAlw.DebitNoteOffSetCd = depositAlwWork.DebitNoteOffSetCd;    // 赤伝相殺区分

                depositAlwList.Add(depositAlw);
			}

			return depositAlwList;
		}
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
	}
}
