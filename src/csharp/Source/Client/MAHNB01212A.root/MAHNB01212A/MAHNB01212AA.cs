using System;
using System.Collections;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 請求売上データ検索アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 請求売上データの検索操作を行うアクセスクラスです。</br>
	/// <br>Programmer : 18322 T.Kimura</br>
	/// <br>Date       : 2007.01.19</br>
	/// <br></br>
	/// <br>Update Note: 20081 疋田 勇人</br>
    /// <br>           : 2008.01.08 DC.NS用に変更</br>
    /// <br>Update Note: 30414 忍 幸史</br>
    /// <br>           : 2008/06/26 Partsman用に変更</br>
    /// </remarks>
	public class SearchClaimSalesAcs
	{
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private IClaimSalesReadDB _iClaimSalesReadDB = null;

		# region Public Methods
		/// <summary>
		/// 請求売上データ検索アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 請求売上データ検索アクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 18322 T.Kimura</br>
		/// <br>Date       : 2007.01.19</br>
		/// </remarks>
		public SearchClaimSalesAcs()
		{
			try
			{
				// リモートオブジェクト取得
				this._iClaimSalesReadDB= (IClaimSalesReadDB)MediationClaimSalesReadDB.GetClaimSalesReadDB();
			}
			catch (Exception)
			{				
				// オフライン時はnullをセット
				this._iClaimSalesReadDB = null;
			}
		}

		/// <summary>
		///   請求売上データ読込処理
		/// </summary>
		/// <param name="enterpriseCode">検索 企業コード</param>
		/// <param name="demandAddUpSecCd">検索 請求計上拠点コード</param>
		/// <param name="claimCode">検索 請求先コード</param>
		/// <param name="AcceptAnOrderNo">検索 受注番号</param>
		/// <param name="searchClaimSales">請求売上データ情報</param>
		/// <param name="errmsg">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : 条件を元に請求売上データ（売上データ＋顧客締情報）の取得を行います</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		public int ReadCusDB(     string           enterpriseCode
		                    ,     string           demandAddUpSecCd
		                    ,     int              claimCode
		                    ,     int              AcceptAnOrderNo
		                    , out SearchClaimSales searchClaimSales
		                    , out string errmsg
                            )
		{

			byte[] searchClaimSalesByte = null;

			searchClaimSales = null;
			errmsg = "";
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// 請求売上データ読込み
				status = this._iClaimSalesReadDB.ReadCus(ref searchClaimSalesByte
				                                        ,    enterpriseCode
				                                        ,    AcceptAnOrderNo
				                                        ,    claimCode
				                                        ,    demandAddUpSecCd
				                                        ,    ConstantManagement.LogicalMode.GetData0
				                                        );
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					SearchClaimSalesWork searchClaimSalesWork = (SearchClaimSalesWork)XmlByteSerializer.Deserialize(searchClaimSalesByte, typeof(SearchClaimSalesWork));

					// クラスメンバーコピー処理（請求売上マスタワーククラス⇒請求売上マスタクラス）
					searchClaimSales = this.CopyToClaimSalesFromClaimSalesWork(searchClaimSalesWork);
				}
			}
			catch (Exception ex)
			{
				//オフライン時はnullをセット
				this._iClaimSalesReadDB = null;
				status = (int)ConstantManagement.DB_Status.ctDB_OFFLINE;

				errmsg = ex.Message;
			}

			return status;
		}

		/// <summary>
		///   請求売上データ読込処理
		/// </summary>
		/// <param name="searchParaClaimSalesRead">検索条件</param>
		/// <param name="searchClaimSalesList">請求売上データ情報</param>
		/// <param name="errmsg">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : 条件を元に請求売上データ（売上データ）の取得を行います</br>
		/// <br>Programmer : 18322 T.Kimura</br>
		/// <br>Date       : 2007.01.19</br>
		/// </remarks>
		public int SearchDB(     SearchParaClaimSalesRead searchParaClaimSalesRead
                           , out ArrayList                searchClaimSalesList
                           , out string                   errmsg
                           )
		{
			object searchClaimSalesWorkListObj = null;

			searchClaimSalesList = null;
			errmsg = "";
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// 売上データ読込み
				status = this._iClaimSalesReadDB.Search(out searchClaimSalesWorkListObj
                                                       ,    searchParaClaimSalesRead
                                                       ,    0
                                                       ,    ConstantManagement.LogicalMode.GetData0
                                                       );
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					ArrayList searchClaimSalseWorkList = (ArrayList)searchClaimSalesWorkListObj;

					// クラスメンバーコピー処理（売上データワーククラス⇒売上データクラス）
					searchClaimSalesList = this.CopyToSalesSlipListFromSalesSlipWork(searchClaimSalseWorkList);
				}
			}
			catch (Exception ex)
			{
				//オフライン時はnullをセット
				this._iClaimSalesReadDB = null;
				status = (int)ConstantManagement.DB_Status.ctDB_OFFLINE;

				errmsg = ex.Message;
			}

			return status;
		}

		/// <summary>
		/// 請求売上読込処理
		/// </summary>
		/// <param name="searchParaClaimSalesRead">検索条件</param>
		/// <param name="searchClaimSalesList">請求売上情報</param>
		/// <param name="errmsg">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : 条件を元に請求売上データ（売上データ＋顧客締情報）の取得を行います</br>
		/// <br>Programmer : 18322 T.Kimura</br>
		/// <br>Date       : 2007.01.19</br>
		/// </remarks>
		public int SearchCustDB(SearchParaClaimSalesRead searchParaClaimSalesRead, out ArrayList searchClaimSalesList, out string errmsg)
		{

			object searchClaimSalesListWorkListObj = null;

			searchClaimSalesList = null;
			errmsg = "";
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// 請求売上データ読込み
				status = this._iClaimSalesReadDB.SearchCus(out searchClaimSalesListWorkListObj
                                                          ,    searchParaClaimSalesRead
                                                          ,    0
                                                          ,    ConstantManagement.LogicalMode.GetData0
                                                          );
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					ArrayList searchClaimSalesWorkList = (ArrayList)searchClaimSalesListWorkListObj;

					// クラスメンバーコピー処理（請求売上マスタワーククラス⇒請求売上マスタクラス）
					searchClaimSalesList = this.CopyToSalesSlipCustomerListFromSalesSlipCustomerWork(searchClaimSalesWorkList);
				}
			}
			catch (Exception ex)
			{
				//オフライン時はnullをセット
				this._iClaimSalesReadDB = null;
				status = (int)ConstantManagement.DB_Status.ctDB_OFFLINE;

				errmsg = ex.Message;
			}

			return status;
		}
		# endregion

		# region Private Methods
		/// <summary>
		/// クラスメンバーコピー処理（請求売上マスタワーククラス⇒請求売上マスタクラス）
		/// </summary>
		/// <param name="claimSalesWorkList">請求売上マスタワーククラス</param>
		/// <returns>請求売上マスタクラス</returns>
		/// <remarks>
		/// <br>Note       : 請求売上マスタワーククラスから請求売上マスタクラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 18322 T.Kimura</br>
		/// <br>Date       : 2007.01.19</br>
		/// </remarks>
		private ArrayList CopyToSalesSlipListFromSalesSlipWork(ArrayList claimSalesWorkList)
		{
			ArrayList claimSalesList = new ArrayList();

			foreach (SearchClaimSalesWork searchClaimSalesWork in claimSalesWorkList)
			{
				SearchClaimSales ClaimSales = this.CopyToClaimSalesFromClaimSalesWork(searchClaimSalesWork);

				claimSalesList.Add(ClaimSales);
			}

			return claimSalesList;
		}

		/// <summary>
		/// クラスメンバーコピー処理（請求売上マスタワーククラス⇒請求売上マスタクラス）
		/// </summary>
		/// <param name="searchClaimSalesWorkList">請求売上マスタワーククラス</param>
		/// <returns>請求売上マスタクラス</returns>
		/// <remarks>
		/// <br>Note       : 請求売上マスタワーククラスから請求売上マスタクラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 18322 T.Kimura</br>
		/// <br>Date       : 2007.01.19</br>
		/// </remarks>
		private ArrayList CopyToSalesSlipCustomerListFromSalesSlipCustomerWork(ArrayList searchClaimSalesWorkList)
		{
			ArrayList searchClaimSalesList = new ArrayList();

			foreach (SearchClaimSalesWork searchClaimSalesWork in searchClaimSalesWorkList)
			{
				SearchClaimSales searchClaimSales = CopyToClaimSalesFromClaimSalesWork(searchClaimSalesWork);

				searchClaimSalesList.Add(searchClaimSales);
			}

			return searchClaimSalesList;
		}

		/// <summary>
		/// クラスメンバーコピー処理（請求売上データ検索ワーククラス⇒請求売上データ検索クラス）
		/// </summary>
		/// <param name="searchClaimSalesWork">請求売上マスタワーククラス</param>
		/// <returns>請求売上マスタクラス</returns>
		/// <remarks>
		/// <br>Note       : 請求売上データ検索ワーククラスから請求売上データ検索クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 18322 T.Kimura</br>
		/// <br>Date       : 2007.01.19</br>
		/// </remarks>
		private SearchClaimSales CopyToClaimSalesFromClaimSalesWork(SearchClaimSalesWork searchClaimSalesWork)
		{
			SearchClaimSales claimSales = new SearchClaimSales();

            // 作成日時
            claimSales.CreateDateTime       = searchClaimSalesWork.CreateDateTime;
            // 更新日時                                   
            claimSales.UpdateDateTime       = searchClaimSalesWork.UpdateDateTime;
            // 企業コード                                 
            claimSales.EnterpriseCode       = searchClaimSalesWork.EnterpriseCode;
            // GUID                                       
            claimSales.FileHeaderGuid       = searchClaimSalesWork.FileHeaderGuid;
            // 更新従業員コード                           
            claimSales.UpdEmployeeCode      = searchClaimSalesWork.UpdEmployeeCode;
            // 更新アセンブリID1                          
            claimSales.UpdAssemblyId1       = searchClaimSalesWork.UpdAssemblyId1;
            // 更新アセンブリID2                          
            claimSales.UpdAssemblyId2       = searchClaimSalesWork.UpdAssemblyId2;
            // 論理削除区分                               
            claimSales.LogicalDeleteCode    = searchClaimSalesWork.LogicalDeleteCode;
            // 受注ステータス               
            claimSales.AcptAnOdrStatus      = searchClaimSalesWork.AcptAnOdrStatus;
            // 売上伝票番号                 
            claimSales.SalesSlipNum         = searchClaimSalesWork.SalesSlipNum;
            // 拠点コード
            claimSales.SectionCode          = searchClaimSalesWork.SectionCode;
            // 部門コード
            claimSales.SubSectionCode       = searchClaimSalesWork.SubSectionCode;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            // 課コード
            claimSales.MinSectionCode       = searchClaimSalesWork.MinSectionCode;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            // 赤伝区分                     
            claimSales.DebitNoteDiv         = searchClaimSalesWork.DebitNoteDiv;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            // 赤黒連結受注番号             
            claimSales.DebitNLnkAcptAnOdr   = searchClaimSalesWork.DebitNLnkAcptAnOdr;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            // 売上伝票区分                 
            claimSales.SalesSlipCd          = searchClaimSalesWork.SalesSlipCd;
            // 売上商品区分                 
            claimSales.SalesGoodsCd         = searchClaimSalesWork.SalesGoodsCd;
            // 売掛区分                 
            claimSales.AccRecDivCd         = searchClaimSalesWork.AccRecDivCd;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            // サービス伝票区分             
            claimSales.ServiceSlipCd        = searchClaimSalesWork.ServiceSlipCd;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            // 売上入力拠点コード           
            claimSales.SalesInpSecCd        = searchClaimSalesWork.SalesInpSecCd;
            // 請求計上拠点コード           
            claimSales.DemandAddUpSecCd     = searchClaimSalesWork.DemandAddUpSecCd;
            // 実績計上拠点コード           
            claimSales.ResultsAddUpSecCd    = searchClaimSalesWork.ResultsAddUpSecCd;
            // 更新拠点コード               
            claimSales.UpdateSecCd          = searchClaimSalesWork.UpdateSecCd;
            // 伝票検索日付                 
            claimSales.SearchSlipDate       = searchClaimSalesWork.SearchSlipDate;
            // 出荷日付                     
            claimSales.ShipmentDay          = searchClaimSalesWork.ShipmentDay;
            // 売上日付                     
            claimSales.SalesDate            = searchClaimSalesWork.SalesDate;
            // 計上日付                     
            claimSales.AddUpADate           = searchClaimSalesWork.AddUpADate;
            // 来勘区分
            claimSales.DelayPaymentDiv      = searchClaimSalesWork.DelayPaymentDiv;
            // 売上入力者コード
            claimSales.SalesInputCode       = searchClaimSalesWork.SalesInputCode;
            // 売上入力者名称
            claimSales.SalesInputName       = searchClaimSalesWork.SalesInputName;
            // 受付従業員コード             
            claimSales.FrontEmployeeCd      = searchClaimSalesWork.FrontEmployeeCd;
            // 受付従業員名称               
            claimSales.FrontEmployeeNm      = searchClaimSalesWork.FrontEmployeeNm;
            // 販売従業員コード             
            claimSales.SalesEmployeeCd      = searchClaimSalesWork.SalesEmployeeCd;
            // 販売従業員名称               
            claimSales.SalesEmployeeNm      = searchClaimSalesWork.SalesEmployeeNm;
            // 総額表示方法区分             
            claimSales.TotalAmountDispWayCd = searchClaimSalesWork.TotalAmountDispWayCd;
            // 総額表示掛率適用区分
            claimSales.TtlAmntDispRateApy   = searchClaimSalesWork.TtlAmntDispRateApy;
            // 売上伝票合計（税込み）       
            claimSales.SalesTotalTaxInc     = searchClaimSalesWork.SalesTotalTaxInc;
            // 売上伝票合計（税抜き）       
            claimSales.SalesTotalTaxExc     = searchClaimSalesWork.SalesTotalTaxExc;
            // 売上小計（税込み）           
            claimSales.SalesSubtotalTaxInc  = searchClaimSalesWork.SalesSubtotalTaxInc;
            // 売上小計（税抜き）           
            claimSales.SalesSubtotalTaxExc  = searchClaimSalesWork.SalesSubtotalTaxExc;
            // 売上正価金額
            claimSales.SalesNetPrice        = searchClaimSalesWork.SalesNetPrice;
            // 売上小計（税）               
            claimSales.SalesSubtotalTax     = searchClaimSalesWork.SalesSubtotalTax;
            // 売上外税対象額
            claimSales.ItdedSalesOutTax     = searchClaimSalesWork.ItdedSalesOutTax;
            // 売上内税対象額
            claimSales.ItdedSalesInTax      = searchClaimSalesWork.ItdedSalesInTax;
            // 売上小計非課税対象額         
            claimSales.SalSubttlSubToTaxFre = searchClaimSalesWork.SalSubttlSubToTaxFre;
            // 売上金額消費税額（外税）         
            claimSales.SalesOutTax          = searchClaimSalesWork.SalesOutTax;
            // 売上金額消費税額（内税）         
            claimSales.SalAmntConsTaxInclu  = searchClaimSalesWork.SalAmntConsTaxInclu;
            // 売上値引金額計（税抜き）         
            claimSales.SalesDisTtlTaxExc    = searchClaimSalesWork.SalesDisTtlTaxExc;
            // 売上値引外税対象額合計      
            claimSales.ItdedSalesDisOutTax  = searchClaimSalesWork.ItdedSalesDisOutTax;
            // 売上値引内税対象額合計      
            claimSales.ItdedSalesDisInTax   = searchClaimSalesWork.ItdedSalesDisInTax;
            // 売上値引非課税対象額合計      
            claimSales.ItdedSalesDisTaxFre  = searchClaimSalesWork.ItdedSalesDisTaxFre;
            // 売上値引消費税額（外税）      
            claimSales.SalesDisOutTax       = searchClaimSalesWork.SalesDisOutTax;
            // 仕入値引消費税額（内税）      
            claimSales.SalesDisTtlTaxInclu  = searchClaimSalesWork.SalesDisTtlTaxInclu;
            // 原価金額計                   
            claimSales.TotalCost            = searchClaimSalesWork.TotalCost;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            // サービス預り金               
            claimSales.ServiceDeposits      = searchClaimSalesWork.ServiceDeposits;

            // 消費税調整額                 
            claimSales.TaxAdjust            = searchClaimSalesWork.TaxAdjust;
            
            // 残高調整額                   
            claimSales.BalanceAdjust        = searchClaimSalesWork.BalanceAdjust;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            // 消費税転嫁方式               
            claimSales.ConsTaxLayMethod     = searchClaimSalesWork.ConsTaxLayMethod;
            // 消費税税率                   
            claimSales.ConsTaxRate          = searchClaimSalesWork.ConsTaxRate;
            // 端数処理区分                 
            claimSales.FractionProcCd       = searchClaimSalesWork.FractionProcCd;
            // 売掛消費税                 
            claimSales.AccRecConsTax        = searchClaimSalesWork.AccRecConsTax;
            // 自動入金区分                 
            claimSales.AutoDepositCd        = searchClaimSalesWork.AutoDepositCd;
            // 自動入金伝票番号               
            claimSales.AutoDepositSlipNo    = searchClaimSalesWork.AutoDepositSlipNo;
            // 入金引当合計額               
            claimSales.DepositAllowanceTtl  = searchClaimSalesWork.DepositAllowanceTtl;
            // 入金引当残高                 
            claimSales.DepositAlwcBlnce     = searchClaimSalesWork.DepositAlwcBlnce;
            // 請求先コード                 
            claimSales.ClaimCode            = searchClaimSalesWork.ClaimCode;
            // 請求先名称                  
            claimSales.ClaimName            = searchClaimSalesWork.ClaimName;
            // 請求先名称2                  
            claimSales.ClaimName2           = searchClaimSalesWork.ClaimName2;
            // 請求先略称                  
            claimSales.ClaimSnm             = searchClaimSalesWork.ClaimSnm;
            // 得意先コード                 
            claimSales.CustomerCode         = searchClaimSalesWork.CustomerCode;
            // 得意先名称                   
            claimSales.CustomerName         = searchClaimSalesWork.CustomerName;
            // 得意先名称2                  
            claimSales.CustomerName2        = searchClaimSalesWork.CustomerName2;
            // 得意先略称                  
            claimSales.CustomerSnm          = searchClaimSalesWork.CustomerSnm;
            // 敬称                         
            claimSales.HonorificTitle       = searchClaimSalesWork.HonorificTitle;
            // 諸口コード                         
            claimSales.OutputNameCode       = searchClaimSalesWork.OutputNameCode;
            // 伝票住所区分                         
            claimSales.SlipAddressDiv       = searchClaimSalesWork.SlipAddressDiv;
            // 納品先コード                 
            claimSales.AddresseeCode        = searchClaimSalesWork.AddresseeCode;
            // 納品先名称                   
            claimSales.AddresseeName        = searchClaimSalesWork.AddresseeName;
            // 納品先名称2                  
            claimSales.AddresseeName2       = searchClaimSalesWork.AddresseeName2;
            // 納品先郵便番号                         
            claimSales.AddresseePostNo      = searchClaimSalesWork.AddresseePostNo;
            // 納品先住所1(都道府県市区郡・町村・字)
            claimSales.AddresseeAddr1       = searchClaimSalesWork.AddresseeAddr1;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            // 納品先住所2(丁目)            
            claimSales.AddresseeAddr2       = searchClaimSalesWork.AddresseeAddr2;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            
            // 納品先住所3(番地)            
            claimSales.AddresseeAddr3       = searchClaimSalesWork.AddresseeAddr3;
            // 納品先住所4(アパート名称)    
            claimSales.AddresseeAddr4       = searchClaimSalesWork.AddresseeAddr4;
            // 納品先電話番号               
            claimSales.AddresseeTelNo       = searchClaimSalesWork.AddresseeTelNo;
            // 納品先FAX番号               
            claimSales.AddresseeFaxNo       = searchClaimSalesWork.AddresseeFaxNo;
            // 相手先伝票番号               
            claimSales.PartySaleSlipNum     = searchClaimSalesWork.PartySaleSlipNum;
            // 伝票備考     
            if (searchClaimSalesWork.SlipNote != null)
            {
                claimSales.SlipNote = searchClaimSalesWork.SlipNote;
            }
            // 伝票備考２                
            if (searchClaimSalesWork.SlipNote2 != null)
            {
                claimSales.SlipNote2 = searchClaimSalesWork.SlipNote2;
            }
            // 伝票備考３                
            if (searchClaimSalesWork.SlipNote3 != null)
            {
                claimSales.SlipNote3 = searchClaimSalesWork.SlipNote3;
            }
            // 返品理由コード               
            claimSales.RetGoodsReasonDiv    = searchClaimSalesWork.RetGoodsReasonDiv;
            // 返品理由                     
            claimSales.RetGoodsReason       = searchClaimSalesWork.RetGoodsReason;
            // 明細行数                     
            claimSales.DetailRowCount       = searchClaimSalesWork.DetailRowCount;
            // ＥＤＩ送信日                     
            claimSales.EdiSendDate          = searchClaimSalesWork.EdiSendDate;
            // ＥＤＩ取込日                     
            claimSales.EdiTakeInDate        = searchClaimSalesWork.EdiTakeInDate;
            // ＵＯＥリマーク１                     
            claimSales.UoeRemark1           = searchClaimSalesWork.UoeRemark1;
            // ＵＯＥリマーク２                     
            claimSales.UoeRemark2           = searchClaimSalesWork.UoeRemark2;
            // 伝票発行区分                     
            claimSales.SlipPrintDivCd       = searchClaimSalesWork.SlipPrintDivCd;
            // 伝票発行済区分                     
            claimSales.SlipPrintFinishCd    = searchClaimSalesWork.SlipPrintFinishCd;
            // 売上伝票発行日                     
            claimSales.SalesSlipPrintDate   = searchClaimSalesWork.SalesSlipPrintDate;
            // 業種コード                     
            claimSales.BusinessTypeCode     = searchClaimSalesWork.BusinessTypeCode;
            // 業種名称                     
            claimSales.BusinessTypeName     = searchClaimSalesWork.BusinessTypeName;
            // 納品区分                     
            claimSales.DeliveredGoodsDiv    = searchClaimSalesWork.DeliveredGoodsDiv;
            // 納品区分名称                     
            claimSales.DeliveredGoodsDivNm  = searchClaimSalesWork.DeliveredGoodsDivNm;
            // 販売エリアコード                     
            claimSales.SalesAreaCode        = searchClaimSalesWork.SalesAreaCode;
            // 販売エリア名称                     
            claimSales.SalesAreaName        = searchClaimSalesWork.SalesAreaName;
            // 伝票印刷設定用帳票ID                     
            claimSales.SlipPrtSetPaperId    = searchClaimSalesWork.SlipPrtSetPaperId;
            // 一式伝票区分                     
            claimSales.CompleteCd           = searchClaimSalesWork.CompleteCd;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            // 請求先区分                     
            claimSales.ClaimType            = searchClaimSalesWork.ClaimType;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            // 売上金額端数処理区分                     
            claimSales.SalesPriceFracProcCd = searchClaimSalesWork.SalesPriceFracProcCd;
            // 在庫商品合計金額（税抜）                     
            claimSales.StockGoodsTtlTaxExc  = searchClaimSalesWork.StockGoodsTtlTaxExc;
            // 純正商品合計金額（税抜）                     
            claimSales.PureGoodsTtlTaxExc   = searchClaimSalesWork.PureGoodsTtlTaxExc;
            // 定価印刷区分                     
            claimSales.ListPricePrintDiv    = searchClaimSalesWork.ListPricePrintDiv;
            // 元号表示区分１                     
            claimSales.EraNameDispCd1       = searchClaimSalesWork.EraNameDispCd1;
            // 締日                         
            claimSales.TotalDay             = searchClaimSalesWork.TotalDay;
            // 最終締次更新年月日           
            claimSales.LastTotalAddUpDt     = searchClaimSalesWork.LastTotalAddUpDt;

            //-----ADD 2010/12/20----->>>>>
            claimSales.DepSalesSlipNum      = searchClaimSalesWork.DepSalesSlipNum;
            //-----ADD 2010/12/20-----<<<<<
			return claimSales;
		}

		# endregion
	}
}
