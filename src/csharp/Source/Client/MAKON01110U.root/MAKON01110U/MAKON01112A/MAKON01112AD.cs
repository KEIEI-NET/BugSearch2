using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
#if false
	/// <summary>
	/// 仕入同時売上情報アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入同時売上入力の制御全般を行います。</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2008.05.21</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.21 men 新規作成</br>
	/// </remarks>
	public class SalesTempInputAcs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region ■Constructor
		/// <summary>
		/// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
		/// </summary>
		private SalesTempInputAcs()
		{
			//this. = StockSlipInputAcs.GetInstance();
			this._customerInfoAcs = new CustomerInfoAcs();
			this._customerInfoAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;
			this._supplierAcs = new SupplierAcs();
			this._supplierAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;
			this._unitPriceCalculation = new UnitPriceCalculation();
			this._salesPriceCalclate = new SalesPriceCalclate();
			this._stockSlipInputInitDataAcs = StockSlipInputInitDataAcs.GetInstance();
			//this._stockSlipInputInitDataAcs.CacheSalesProcMoneyList += new StockSlipInputInitDataAcs.CacheSalesProcMoneyListEventHandler(this._unitPriceCalculation.CacheSalesProcMoneyList);
			//this._stockSlipInputInitDataAcs.CacheSalesProcMoneyList += new StockSlipInputInitDataAcs.CacheSalesProcMoneyListEventHandler(this._salesPriceCalclate.CacheSalesProcMoneyList);
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
		}

		/// <summary>
		/// 仕入売上情報入力アクセスクラス インスタンス取得処理
		/// </summary>
		/// <returns>仕入入力アクセスクラス インスタンス</returns>
		public static SalesTempInputAcs GetInstance()
		{
			if (_stockSlipSalesInfoInputAcs == null)
			{
				_stockSlipSalesInfoInputAcs = new SalesTempInputAcs();
			}

			return _stockSlipSalesInfoInputAcs;
		}

		#endregion

		// ===================================================================================== //
		// デリゲート
		// ===================================================================================== //
		#region ■Delegete

		/// <summary>売上情報画面セットイベント</summary>
		public delegate void SetDisplaySalesInfoEventHandler( SalesTemp salesTemp );

		/// <summary>売上情報キャッシュイベント</summary>
		public delegate void CacheSalesTempEventHandler( int stockRowNo, SalesTemp salesTemp );

		#endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		#region ■Events
		/// <summary>列最新情報設定イベント</summary>
		public event SetDisplaySalesInfoEventHandler SetDisplay;
		/// <summary>列最新情報設定イベント</summary>
		public event CacheSalesTempEventHandler CacheSalesTemp;

		#endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		#region ■Private Members

		private static SalesTempInputAcs _stockSlipSalesInfoInputAcs;
		private SalesTemp _salesTemp;
		private CustomerInfoAcs _customerInfoAcs;
		private SupplierAcs _supplierAcs;
		private StockSlipInputInitDataAcs _stockSlipInputInitDataAcs;
		private SalesPriceCalclate _salesPriceCalclate;
		private int _stockRowNo = 0;
		private string _enterpriseCode;
		private UnitPriceCalculation _unitPriceCalculation;
		private StockInputDataSet.StockDetailRow _stockDetailRow;

		#endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		#region ■Properties
		/// <summary>売上情報プロパティ</summary>
		public SalesTemp SalesTemp
		{
			get { return this._salesTemp; }
			set { this._salesTemp = value; }
		}

		/// <summary>仕入明細データ行オブジェクト</summary>
		public StockInputDataSet.StockDetailRow StockDetailRow
		{
			get { return _stockDetailRow; }
			set { _stockDetailRow = value; }
		}
		#endregion

		// ===================================================================================== //
		// 列挙体
		// ===================================================================================== //
		#region ■ Enums
		/// <summary>
		/// 単価種類
		/// </summary>
		public enum UnitPriceKind
		{
			/// <summary>売上単価</summary>
			SalesUnitPrice = 1,
			/// <summary>売上原価</summary>
			SalesUnitCost = 2,
			/// <summary>仕入単価</summary>
			StockUnitPrice = 3,
			/// <summary>定価</summary>
			ListPrice = 4,
		}
		#endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		#region ■Public Methods

		/// <summary>
		/// 同時売上オブジェクトを画面に設定します。
		/// </summary>
		/// <param name="stockRowNo">行番号</param>
		/// <param name="salesTemp">同時売上オブジェクト</param>
		/// <param name="stockDetailRow">仕入明細データ行オブジェクト</param>
		public void SettingSalesTemp( int stockRowNo, SalesTemp salesTemp, StockInputDataSet.StockDetailRow stockDetailRow )
		{
			this._salesTemp = salesTemp;
			this._stockRowNo = stockRowNo;
			this._stockDetailRow = stockDetailRow;

			this.SetDisplayCall();
		}

		/// <summary>
		/// 同時売上情報キャッシュ処理（オーバーロード）
		/// </summary>
		/// <param name="salesTemp">同時売上オブジェクト</param>
		public void Cache( SalesTemp salesTemp )
		{
			this._salesTemp = salesTemp.Clone();

			this.CacheCall(this._stockRowNo, salesTemp);
		}

		/// <summary>
		/// 同時売上情報キャッシュ処理（オーバーロード）
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		/// <param name="salesTemp">同時売上オブジェクト</param>
		public void Cache( int stockRowNo, SalesTemp salesTemp )
		{
			this.CacheCall(stockRowNo, salesTemp);
		}

		/// <summary>
		/// 同時売上データ設定処理
		/// </summary>
		/// <param name="salesTemp">同時売上データオブジェクト</param>
		/// <param name="customerInfo">得意先オブジェクト</param>
		public void DataSettingSalesTempFromCustomerInfo( ref SalesTemp salesTemp, CustomerInfo customerInfo )
		{
			if (( customerInfo == null ))
			{
				salesTemp.CustomerCode = 0;			// 得意先コード
				salesTemp.CustomerName = "";		// 得意先名称１
				salesTemp.CustomerName2 = "";		// 得意先名称２
				salesTemp.CustomerSnm = "";			// 略称
				salesTemp.HonorificTitle = "";		// 敬称
				salesTemp.OutputNameCode = 0;		// 諸口コード
				salesTemp.BusinessTypeCode = 0;		// 業種コード
				salesTemp.BusinessTypeName = "";	// 業種名称
				salesTemp.SalesAreaCode = 0;		// 販売エリアコード
				salesTemp.SalesAreaName = "";		// 販売エリア名称
				salesTemp.ClaimType = 0;			// 請求先区分
				salesTemp.CustRateGrpCode = 0;		// 得意先掛率グループコード
				salesTemp.FractionProcCd = 0;		// 端数処理区分
				salesTemp.TotalAmountDispWayCd = 0;	// 総額表示方法参照区分
				salesTemp.TtlAmntDispRateApy = 0;	// 総額表示掛率適用区分
				salesTemp.ConsTaxLayMethod = 0;		// 消費税転嫁方式
				salesTemp.ClaimCode = 0;			// 請求先コード
				salesTemp.ClaimSnm = "";			// 略称
				salesTemp.TotalDay = 0;				// 締日
				salesTemp.NTimeCalcStDate = 0;		// 次回勘定開始日
				salesTemp.DemandAddUpSecCd = "";	// 請求計上拠点コード
				salesTemp.SlipAddressDiv = 0;		// 伝票住所区分
				salesTemp.AddresseeCode = 0;		// 納品先コード
				salesTemp.AddresseeName = "";		// 納品先名称
				salesTemp.AddresseeName2 = "";		// 納品先名称2
				salesTemp.AddresseePostNo = "";		// 納品先郵便番号
				salesTemp.AddresseeAddr1 = "";		// 納品先住所1
				salesTemp.AddresseeAddr2 = 0;		// 納品先住所2
				salesTemp.AddresseeAddr3 = "";		// 納品先住所3
				salesTemp.AddresseeAddr4 = "";		// 納品先住所4
				salesTemp.AddresseeTelNo = "";		// 納品先電話番号
				salesTemp.AddresseeFaxNo = "";		// 納品先FAX番号

			}
			else
			{
				if (customerInfo == null) customerInfo = new CustomerInfo();

				//-----------------------------------------------------
				// 得意先情報
				//-----------------------------------------------------
				salesTemp.CustomerCode = customerInfo.CustomerCode;				// 得意先コード
				salesTemp.CustomerName = customerInfo.Name;						// 得意先名称１
				salesTemp.CustomerName2 = customerInfo.Name2;					// 得意先名称２
				salesTemp.CustomerSnm = customerInfo.CustomerSnm;				// 略称
				salesTemp.HonorificTitle = customerInfo.HonorificTitle;			// 敬称
				salesTemp.OutputNameCode = customerInfo.OutputNameCode;			// 諸口コード
				salesTemp.BusinessTypeCode = customerInfo.BusinessTypeCode;		// 業種コード
				salesTemp.BusinessTypeName = customerInfo.BusinessTypeName;		// 業種名称
				salesTemp.SalesAreaCode = customerInfo.SalesAreaCode;			// 販売エリアコード
				salesTemp.SalesAreaName = customerInfo.SalesAreaName;			// 販売エリア名称
				//salesTemp.ClaimType = customerInfo.ClaimType;					// 請求先区分
				//salesTemp.CustRateGrpCode = customerInfo.CustRateGrpCode;		// 得意先掛率グループコード
				salesTemp.ClaimCode = customerInfo.ClaimCode;					// 請求先コード

				salesTemp.SlipAddressDiv = 1;									// 伝票住所区分
				salesTemp.AddresseeCode = customerInfo.CustomerCode;			// 納品先コード
				salesTemp.AddresseeName = customerInfo.Name;					// 納品先名称
				salesTemp.AddresseeName2 = customerInfo.Name2;					// 納品先名称2
				salesTemp.AddresseePostNo = customerInfo.PostNo;				// 納品先郵便番号
				salesTemp.AddresseeAddr1 = customerInfo.Address1;				// 納品先住所1
				//salesTemp.AddresseeAddr2 = customerInfo.Address2;				// 納品先住所2
				salesTemp.AddresseeAddr3 = customerInfo.Address3;				// 納品先住所3
				salesTemp.AddresseeAddr4 = customerInfo.Address4;				// 納品先住所4
				salesTemp.AddresseeTelNo = customerInfo.OfficeTelNo;			// 納品先電話番号
				salesTemp.AddresseeFaxNo = customerInfo.OfficeFaxNo;			// 納品先FAX番号

				if (( customerInfo.CustomerAgentCd != "" ) && ( this._stockSlipInputInitDataAcs.CodeExist_Employee(customerInfo.CustomerAgentCd) ))
				{
					salesTemp.SalesEmployeeCd = customerInfo.CustomerAgentCd; // 担当者コード
					salesTemp.SalesEmployeeNm = customerInfo.CustomerAgentNm; // 担当者名称
				}

				// 消費税端数処理単位、区分取得
				int taxFracProcCd = 0;
				double taxFracProcUnit = 0;
				this._stockSlipInputInitDataAcs.GetSalesFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, customerInfo.SalesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
				salesTemp.FractionProcCd = taxFracProcCd;

				// 総額表示掛率適用区分
				salesTemp.TtlAmntDispRateApy = this._stockSlipInputInitDataAcs.GetAllDefSet().TtlAmntDspRateDivCd;

				this.DataSettingClaimInfo(ref salesTemp);
			}
		}

		/// <summary>
		/// 売上データ(仕入同時計上)オブジェクトに請求先に関する情報を設定します。
		/// </summary>
		/// <param name="salesTemp">売上データ(仕入同時計上)オブジェクト</param>
		public void DataSettingClaimInfo( ref SalesTemp salesTemp )
		{
			if (salesTemp.ClaimCode == 0)
			{
				salesTemp.ClaimCode = 0;				// 請求先コード
				salesTemp.ClaimSnm = "";				// 略称
				salesTemp.TotalDay = 0;					// 締日
				salesTemp.NTimeCalcStDate = 0;			// 次回勘定開始日
				salesTemp.TotalAmountDispWayCd = 0;
				salesTemp.ConsTaxLayMethod = 0;
				salesTemp.ClaimSnm = "";				// 略称
				salesTemp.TotalDay = 0;					// 締日
				salesTemp.NTimeCalcStDate = 0;			// 次回勘定開始日
				salesTemp.DemandAddUpSecCd = "";
			}
			else
			{
				//-----------------------------------------------------
				// 請求先情報取得
				//-----------------------------------------------------
				CustomerInfo claim;
				int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, salesTemp.ClaimCode, true, out claim);
				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					claim = new CustomerInfo();
				}

				//-----------------------------------------------------
				// 請求先情報
				//-----------------------------------------------------
				// 得意先マスタの総額表示方法参照区分が
				// ｢1:得意先参照」の場合は得意先マスタの「総額表示方法区分」を設定する
				// ｢0:全体設定参照」の場合は全体初期値設定マスタの「総額表示方法区分」を設定する
				if (claim.TotalAmntDspWayRef == 0)
				{
					// 0:全体設定マスタ参照
					salesTemp.TotalAmountDispWayCd = this._stockSlipInputInitDataAcs.GetAllDefSet().TotalAmountDispWayCd;
				}
				else
				{
					// 1:得意先マスタ参照
					salesTemp.TotalAmountDispWayCd = claim.TotalAmountDispWayCd; // 請求先情報
				}

				// 消費税転嫁方式
				if (claim.CustCTaXLayRefCd == 0)
				{
					// 0:税率設定マスタ参照
					salesTemp.ConsTaxLayMethod = this._stockSlipInputInitDataAcs.GetTaxRateSet().ConsTaxLayMethod;
				}
				else
				{
					// 1:得意先マスタ参照
					salesTemp.ConsTaxLayMethod = claim.ConsTaxLayMethod;
				}

				salesTemp.ClaimSnm = claim.CustomerSnm;				// 略称
				salesTemp.TotalDay = claim.TotalDay;				// 締日
				salesTemp.NTimeCalcStDate = claim.NTimeCalcStDate;	// 次回勘定開始日

				string sectionCode;
				string sectionName;
				this._stockSlipInputInitDataAcs.GetOwnSeCtrlCode(claim.MngSectionCode, SecInfoAcs.CtrlFuncCode.DemandAddUpSecCd, out sectionCode, out sectionName);
				salesTemp.DemandAddUpSecCd = sectionCode; // 請求計上拠点コード
			}
		}

		/// <summary>
		/// 所属情報設定処理
		/// </summary>
		/// <param name="salesTemp">売上データ(仕入同時計上)オブジェクト</param>
		public void SalesEmployeeBelongInfoSetting( ref SalesTemp salesTemp )
		{
			string belongSecCd;
			int belongSubSecCd, belongMinSecCd;
			this._stockSlipInputInitDataAcs.GetBelongInfo_FromEmployee(salesTemp.SalesEmployeeCd, out belongSecCd, out belongSubSecCd, out belongMinSecCd);

			salesTemp.ResultsAddUpSecCd = belongSecCd;
			salesTemp.SubSectionCode = belongSubSecCd;
			salesTemp.MinSectionCode = belongMinSecCd;
		}


		/// <summary>
		/// 計上日を設定します。
		/// </summary>
		/// <param name="salesTemp"></param>
		public void SettingAddUpDate( ref SalesTemp salesTemp )
		{
			DateTime addUpDate;
			int delayPaymentDiv;
			StockSlipInputAcs.CalcAddUpDate(salesTemp.SalesDate, salesTemp.TotalDay, salesTemp.NTimeCalcStDate, out addUpDate, out delayPaymentDiv);

			salesTemp.AddUpADate = addUpDate;
			salesTemp.DelayPaymentDiv = delayPaymentDiv;
		}

		/// <summary>
		/// 表示している売上単価の値を取得します。
		/// </summary>
		/// <param name="salesTemp">同時売上オブジェクト</param>
		/// <returns>表示単価</returns>
		public double GetUnitPriceDisplay( SalesTemp salesTemp )
		{
			return ( ( salesTemp.TotalAmountDispWayCd == 1 ) || ( salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ) ? salesTemp.SalesUnPrcTaxIncFl : salesTemp.SalesUnPrcTaxExcFl;
		}

		/// <summary>
		/// 表示している定価の値を取得します。
		/// </summary>
		/// <param name="salesTemp">同時売上オブジェクト</param>
		/// <returns>表示定価</returns>
		public double GetListPriceDisplay( SalesTemp salesTemp )
		{
			return ( ( salesTemp.TotalAmountDispWayCd == 1 ) || ( salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ) ? salesTemp.ListPriceTaxIncFl : salesTemp.ListPriceTaxExcFl;
		}

		/// <summary>
		/// 表示している売上単価の値を取得します。
		/// </summary>
		/// <param name="salesTemp">同時売上オブジェクト</param>
		/// <returns>表示単価</returns>
		public long GetSalesMoneyDisplay( SalesTemp salesTemp )
		{
			return ( ( salesTemp.TotalAmountDispWayCd == 1 ) || ( salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ) ? salesTemp.SalesMoneyTaxInc : salesTemp.SalesMoneyTaxExc;
		}

		/// <summary>
		/// 入力した売上単価を同時売上オブジェクトにセットします。
		/// </summary>
		/// <param name="salesTemp">同時売上オブジェクト</param>
		/// <param name="salesUnitPriceDisplay">入力した売上単価</param>
		public void UnitPriceSetting( ref SalesTemp salesTemp, double salesUnitPriceDisplay )
		{
			double salesUnPrcTaxExcFl;
			double salesUnPrcTaxIncFl;

			// 表示価格より税抜き、税込み価格を算出する
			this.CalcTaxExcAndTaxInc(salesTemp.TaxationDivCd, salesTemp.CustomerCode, salesTemp.ConsTaxRate, salesTemp.TotalAmountDispWayCd, salesUnitPriceDisplay, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl);

			salesTemp.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
			salesTemp.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;
			salesTemp.SalesUnPrcChngCd = 1;
		}

		/// <summary>
		/// 入力した売上原価単価を同時売上オブジェクトにセットします。
		/// </summary>
		/// <param name="salesTemp">同時売上オブジェクト</param>
		/// <param name="salesUnitCostDisplay">入力した売上単価</param>
		public void salesUnitCostSetting( ref SalesTemp salesTemp, double salesUnitCostDisplay )
		{
			salesTemp.SalesUnitCost = salesUnitCostDisplay;

			if (salesTemp.BfUnitCost != salesTemp.SalesUnitCost)
			{
				salesTemp.SalesUnitCostChngDiv = 1;
			}
			else
			{
				salesTemp.SalesUnitCostChngDiv = 0;
			}
		}

		/// <summary>
		/// 入力した売上金額を同時売上オブジェクトにセットします。
		/// </summary>
		/// <param name="salesTemp">同時売上オブジェクト</param>
		/// <param name="salesMoneyDisplay">入力した売上金額</param>
		public void SalesMoneyDirectSetting( ref SalesTemp salesTemp, long salesMoneyDisplay )
		{
			double salesUnPrcTaxExcFl;
			double salesUnPrcTaxIncFl;
			// 表示価格より税抜き、税込み価格を算出する
			this.CalcTaxExcAndTaxInc(salesTemp.TaxationDivCd, salesTemp.CustomerCode, salesTemp.ConsTaxRate, salesTemp.TotalAmountDispWayCd, salesMoneyDisplay, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl);

			salesTemp.SalesMoneyTaxExc = (long)salesUnPrcTaxExcFl;
			salesTemp.SalesMoneyTaxInc = (long)salesUnPrcTaxIncFl;
			salesTemp.SalesUnPrcTaxExcFl = 0;
			salesTemp.SalesUnPrcTaxIncFl = 0;
			if (salesTemp.BfSalesUnitPrice != salesTemp.SalesMoneyTaxExc)
			{
				salesTemp.SalesUnPrcChngCd = 1;
			}
			else
			{
				salesTemp.SalesUnPrcChngCd = 0;
			}
		}

		/// <summary>
		/// 入力した定価を同時売上オブジェクトにセットします。
		/// </summary>
		/// <param name="salesTemp">同時売上オブジェクト</param>
		/// <param name="listPriceDisplay">入力した定価</param>
		public void ListPriceSetting( ref SalesTemp salesTemp, double listPriceDisplay )
		{
			double listPriceTaxExcFl;
			double listPriceTaxIncFl;
			// 表示価格より税抜き、税込み価格を算出する
			this.CalcTaxExcAndTaxInc(salesTemp.TaxationDivCd, salesTemp.CustomerCode, salesTemp.ConsTaxRate, salesTemp.TotalAmountDispWayCd, listPriceDisplay, out listPriceTaxExcFl, out listPriceTaxIncFl);

			salesTemp.ListPriceTaxExcFl = listPriceTaxExcFl;
			salesTemp.ListPriceTaxIncFl = listPriceTaxIncFl;
			if (salesTemp.BfListPrice != salesTemp.ListPriceTaxExcFl)
			{
				salesTemp.ListPriceChngCd = 1;
			}
			else
			{
				salesTemp.ListPriceChngCd = 0;
			}
		}

		/// <summary>
		/// 粗利チェック区分設定処理
		/// </summary>
		/// <param name="salesTemp"></param>
		public void GrsProfitChkDivSetting( ref SalesTemp salesTemp )
		{
			salesTemp.GrsProfitChkDiv = this.MarginCheck(salesTemp);
		}

		/// <summary>
		/// 売上単価再計算チェック
		/// </summary>
		/// <param name="salesTemp">同時売上オブジェクト</param>
		/// <returns></returns>
		public bool SalesUnitPriceReCalcCheck( SalesTemp salesTemp )
		{
			bool ret = false;

#if false
			switch (salesTemp.UnPrcCalcCdSalUnPrc)
			{
				case (int)UnitPriceCalculation.UnitPrcCalcDiv.BasePrice:				// 基準単価×掛率
					{
						break;
					}

				case (int)UnitPriceCalculation.UnitPrcCalcDiv.CostUpRate:				// 原価×原価UP率
				case (int)UnitPriceCalculation.UnitPrcCalcDiv.GrossProfitSecureRate:	// 原価÷(1-粗利率)
					{
						// 原価単価と基準単価が違う場合は再計算
						if (salesTemp.SalesUnitCost != salesTemp.StdUnPrcSalUnPrc)
						{
							ret = true;
						}
						break;
					}
				case (int)UnitPriceCalculation.UnitPrcCalcDiv.InputListPrice:			// 入力定価×掛率
					{
						double targetPrice = ( salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ? salesTemp.ListPriceTaxIncFl : salesTemp.ListPriceTaxExcFl;
						// 基準単価が違う場合は再計算
						if (targetPrice != salesTemp.StdUnPrcSalUnPrc)
						{
							ret = true;
						}
						break;
					}
			}
#endif

			return ret;
		}

		/// <summary>
		/// 単価算出モジュールにより、単価を算出します。
		/// </summary>
		/// <param name="salesTemp">同時売上オブジェクトリスト</param>
		public void CalclationUnitPrice( ref SalesTemp salesTemp )
		{
			if (salesTemp.ShipmentCnt == 0)
			{
				// 売上単価情報
				salesTemp.RateDivSalUnPrc = "";			// 掛率設定区分
				salesTemp.RateSectSalUnPrc = "";		// 掛率設定拠点
				salesTemp.UnPrcCalcCdSalUnPrc = 0;		// 単価算出区分
				salesTemp.PriceCdSalUnPrc = 0;			// 価格区分
				salesTemp.StdUnPrcSalUnPrc = 0;			// 基準単価
				salesTemp.SalesUnPrcTaxExcFl = 0;		// 売単価(税抜)
				salesTemp.SalesUnPrcTaxIncFl = 0;		// 売単価(税込)
				salesTemp.SalesRate = 0;				// 売価率
				salesTemp.FracProcUnitSalUnPrc = 0;		// 端数処理単位
				salesTemp.FracProcSalUnPrc = 0;			// 端数処理区分
				salesTemp.BfSalesUnitPrice = 0;			// 変更前売価
				salesTemp.SalesUnPrcChngCd = 0;			// 単価変更区分
				salesTemp.BargainCd = 0;				// 特売区分
				salesTemp.BargainNm = "";				// 特売区分名称


				// 売上原価情報
				salesTemp.RateDivUnCst = "";			// 掛率設定区分
				salesTemp.RateSectCstUnPrc = "";		// 掛率設定拠点
				salesTemp.UnPrcCalcCdUnCst = 0;			// 単価算出区分
				salesTemp.PriceCdUnCst = 0;				// 価格区分
				salesTemp.StdUnPrcUnCst = 0;			// 基準単価
				salesTemp.SalesUnitCost = 0;			// 原単価(税込)
				salesTemp.CostRate = 0;					// 原価率
				salesTemp.FracProcUnitUnCst = 0;		// 端数処理単位
				salesTemp.FracProcUnCst = 0;			// 端数処理区分
				salesTemp.BfUnitCost = 0;				// 変更前原価
				salesTemp.SalesUnitCostChngDiv = 0;		// 原価単価変更区分

				// 定価情報
				salesTemp.RateDivLPrice = "";			// 掛率設定区分
				salesTemp.UnPrcCalcCdLPrice = 0;		// 単価算出区分
				salesTemp.RateSectPriceUnPrc = "";		// 掛率設定拠点
				salesTemp.PriceCdLPrice = 0;			// 価格区分
				salesTemp.StdUnPrcLPrice = 0;			// 基準単価
				salesTemp.ListPriceTaxExcFl = 0;		// 定価(税抜)
				salesTemp.ListPriceTaxIncFl = 0;		// 定価(税込)
				salesTemp.ListPriceRate = 0;			// 定価率
				salesTemp.FracProcUnitLPrice = 0;		// 端数処理単位
				salesTemp.FracProcLPrice = 0;			// 端数処理区分
				salesTemp.BfListPrice = 0;				// 変更前定価
				salesTemp.ListPriceChngCd = 0;			// 定価変更区分

			}
			else
			{
				int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(salesTemp.EnterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
				int stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(salesTemp.EnterpriseCode, salesTemp.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);

				int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
				double fracProcUnit;
				int fracProcCd;
				this._stockSlipInputInitDataAcs.GetSalesFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

				List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
				UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
				this.SalesTempRateInfoClear(ref salesTemp);
				unitPriceCalcParam.BLGoodsCode = salesTemp.RateBLGoodsCode;							// BLコード
				unitPriceCalcParam.SectionCode = salesTemp.SectionCode;								// 拠点コード
				unitPriceCalcParam.CountFl = salesTemp.ShipmentCnt;									// 数量
				unitPriceCalcParam.CustomerCode = salesTemp.CustomerCode;							// 得意先コード
				unitPriceCalcParam.CustRateGrpCode = salesTemp.CustRateGrpCode;						// 得意先掛率グループコード
				unitPriceCalcParam.SupplierCd = salesTemp.SupplierCd;								// 仕入先コード
				//unitPriceCalcParam.SuppRateGrpCode = salesTemp.SuppRateGrpCode;						// 仕入先掛率グループコード
				//unitPriceCalcParam.DetailGoodsGanreCode = salesTemp.DetailGoodsGanreCode;			// 商品区分詳細コード
				//unitPriceCalcParam.EnterpriseGanreCode = salesTemp.EnterpriseGanreCode;				// 自社分類コード
				unitPriceCalcParam.GoodsMakerCd = salesTemp.GoodsMakerCd;							// メーカーコード
				unitPriceCalcParam.GoodsNo = salesTemp.GoodsNo;										// 商品番号
				unitPriceCalcParam.GoodsRateRank = salesTemp.GoodsRateRank;							// 商品掛率ランク
				//unitPriceCalcParam.LargeGoodsGanreCode = salesTemp.LargeGoodsGanreCode;				// 商品区分グループコード
				//unitPriceCalcParam.ListPriceTaxExcFl = salesTemp.ListPriceTaxExcFl;					// 定価税込
				//unitPriceCalcParam.ListPriceTaxIncFl = salesTemp.ListPriceTaxIncFl;					// 定価税
				//unitPriceCalcParam.MediumGoodsGanreCode = salesTemp.MediumGoodsGanreCode;			// 商品区分コード
				//unitPriceCalcParam.PriceApplyDate = salesTemp.SalesDate;							// 適用日
				unitPriceCalcParam.PriceApplyDate = ( salesTemp.AcptAnOdrStatus == 30 ) ? salesTemp.SalesDate : salesTemp.ShipmentDay; // 適用日
				unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd;						// 売上単価端数処理コード
				unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;						// 仕入単価端数処理コード
				unitPriceCalcParam.SectionCode = salesTemp.SectionCode;								// 拠点コード
				unitPriceCalcParam.TaxationDivCd = salesTemp.TaxationDivCd;							// 課税区分
				//unitPriceCalcParam.TaxFractionProcCd = fracProcCd;									// 消費税端数処理区分
				//unitPriceCalcParam.TaxFractionProcUnit = fracProcUnit;								// 消費税端数処理単位
				unitPriceCalcParam.TaxRate = salesTemp.ConsTaxRate;									// 税率
				unitPriceCalcParam.TotalAmountDispWayCd = salesTemp.TotalAmountDispWayCd;			// 総額表示方法区分
				unitPriceCalcParam.TtlAmntDspRateDivCd = salesTemp.TtlAmntDispRateApy;				// 総額表示掛率適用区分

				//this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParam, out unitPriceCalcRetList);

				bool calcListPrice = false;
				bool calcUnitPrice = false;
				bool calcUnitCost = false;

				if (unitPriceCalcRetList != null)
				{
					foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
					{
						switch (unitPriceCalcRet.UnitPriceKind)
						{
							//--------------------------------------------
							// 売単価
							//--------------------------------------------
							case UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice:
								salesTemp.RateDivSalUnPrc = unitPriceCalcRet.RateSettingDivide;			// 掛率設定区分
								salesTemp.RateSectSalUnPrc = unitPriceCalcRet.SectionCode;				// 掛率設定拠点
								salesTemp.UnPrcCalcCdSalUnPrc = unitPriceCalcRet.UnitPrcCalcDiv;		// 単価算出区分
								salesTemp.PriceCdSalUnPrc = unitPriceCalcRet.PriceDiv;					// 価格区分
								salesTemp.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;				// 基準単価
								salesTemp.SalesUnPrcTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;		// 売単価(税抜)
								salesTemp.SalesUnPrcTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;		// 売単価(税込)
								salesTemp.SalesRate = unitPriceCalcRet.RateVal;							// 売価率
								salesTemp.FracProcUnitSalUnPrc = unitPriceCalcRet.UnPrcFracProcUnit;	// 端数処理単位
								salesTemp.FracProcSalUnPrc = unitPriceCalcRet.UnPrcFracProcDiv;			// 端数処理区分
								salesTemp.BfSalesUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;		// 変更前売価
								salesTemp.SalesUnPrcChngCd = 0;											// 単価変更区分
								calcUnitPrice = true;
								break;
							//--------------------------------------------
							// 原単価
							//--------------------------------------------
							case UnitPriceCalculation.ctUnitPriceKind_UnitCost:
								salesTemp.RateDivUnCst = unitPriceCalcRet.RateSettingDivide;			// 掛率設定区分
								salesTemp.RateSectCstUnPrc = unitPriceCalcRet.SectionCode;				// 掛率設定拠点
								salesTemp.UnPrcCalcCdUnCst = unitPriceCalcRet.UnitPrcCalcDiv;			// 単価算出区分
								salesTemp.PriceCdUnCst = unitPriceCalcRet.PriceDiv;						// 価格区分
								salesTemp.StdUnPrcUnCst = unitPriceCalcRet.StdUnitPrice;				// 基準単価
								// 内税品の場合は税込み金額
								if (salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
								{
									salesTemp.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxIncFl;		// 原単価(税込)
								}
								else
								{
									salesTemp.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;		// 原単価(税抜)
								}
								salesTemp.CostRate = unitPriceCalcRet.RateVal;							// 原価率
								salesTemp.FracProcUnitUnCst = unitPriceCalcRet.UnPrcFracProcUnit;		// 端数処理単位
								salesTemp.FracProcUnCst = unitPriceCalcRet.UnPrcFracProcDiv;			// 端数処理区分
								salesTemp.BfUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;				// 変更前原価
								salesTemp.SalesUnitCostChngDiv = 0;										// 原価単価変更区分
								calcUnitCost = true;
								break;
							//--------------------------------------------
							// 定価
							//--------------------------------------------
							case UnitPriceCalculation.ctUnitPriceKind_ListPrice:
								salesTemp.RateDivLPrice = unitPriceCalcRet.RateSettingDivide;			// 掛率設定区分
								salesTemp.UnPrcCalcCdLPrice = unitPriceCalcRet.UnitPrcCalcDiv;			// 単価算出区分
								salesTemp.RateSectPriceUnPrc = unitPriceCalcRet.SectionCode;			// 掛率設定拠点
								salesTemp.PriceCdLPrice = unitPriceCalcRet.PriceDiv;					// 価格区分
								salesTemp.StdUnPrcLPrice = unitPriceCalcRet.StdUnitPrice;				// 基準単価
								salesTemp.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;		// 定価(税抜)
								salesTemp.ListPriceTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;		// 定価(税込)
								salesTemp.ListPriceRate = unitPriceCalcRet.RateVal;						// 定価率
								salesTemp.FracProcUnitLPrice = unitPriceCalcRet.UnPrcFracProcUnit;		// 端数処理単位
								salesTemp.FracProcLPrice = unitPriceCalcRet.UnPrcFracProcDiv;			// 端数処理区分
								salesTemp.BfListPrice = unitPriceCalcRet.UnitPriceTaxExcFl;				// 変更前定価
								salesTemp.ListPriceChngCd = 0;											// 定価変更区分
								calcListPrice = true;
								break;
							default:
								break;
						}
					}
				}
				// 定価算出して売単価算出に失敗した場合
				if (( calcListPrice ) && ( !calcUnitPrice ))
				{
					// 売価未設定時「定価を表示」の場合に定価を売価に設定する
					if (this._stockSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv == 1)
					{
						salesTemp.SalesUnPrcTaxExcFl = salesTemp.ListPriceTaxExcFl;		// 売単価(税抜)
						salesTemp.SalesUnPrcTaxIncFl = salesTemp.ListPriceTaxIncFl;		// 売単価(税込)
					}
				}
			}
		}



		/// <summary>
		/// 売上金額を計算します。
		/// </summary>
		/// <param name="salesTemp">同時売上データオブジェクト</param>
		public void CalculationSalesMoney( ref SalesTemp salesTemp )
		{
			if (salesTemp.GoodsName == "") return;
			//if (salesTemp.CustomerCode == 0) return;

			// 売上金額を算定
			long salesMoneyTaxInc;
			long salesMoneyTaxExc;
			double taxRate = salesTemp.ConsTaxRate;

			// 得意先マスタから消費税端数処理情報を取得
			int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// 売上消費税端数処理コード
			double fracProcUnit;
			int fracProcCd;
			this._stockSlipInputInitDataAcs.GetSalesFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

			int salesMoneyFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.MoneyFrcProcCd); // 仕入金額端数処理コード

			// 売上金額端数処理単位、区分取得
			int salesMoneyFracProcCd = 0;
			double salesmoneyFracProcUnit = 0;
			this._stockSlipInputInitDataAcs.GetSalesFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Price, salesMoneyFrcProcCd, 0, out salesmoneyFracProcUnit, out salesMoneyFracProcCd);
			salesTemp.SalesPriceFracProcCd = salesMoneyFracProcCd;

			int taxationCode = salesTemp.TaxationDivCd;

			double salesUnitPrice = 0;
			if (( salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) || ( salesTemp.TotalAmountDispWayCd == 1 ))
			{
				salesUnitPrice = salesTemp.SalesUnPrcTaxIncFl;
			}
			else
			{
				salesUnitPrice = salesTemp.SalesUnPrcTaxExcFl;
			}

			// 総額表示時は内税で計算する
			if (( salesTemp.TaxationDivCd != (int)CalculateTax.TaxationCode.TaxInc ) && ( salesTemp.TotalAmountDispWayCd == 1 )) taxationCode = 2;

			if (this.CalculationSalesMoney(
				salesTemp.ShipmentCnt,
				salesUnitPrice,
				taxationCode,
				taxRate,
				fracProcUnit,
				fracProcCd,
				salesMoneyFrcProcCd,
				out salesMoneyTaxInc,
				out salesMoneyTaxExc))
			{
				salesTemp.SalesMoneyTaxExc = salesMoneyTaxExc;
				salesTemp.SalesMoneyTaxInc = salesMoneyTaxInc;
				salesTemp.SalsePriceConsTax = (long)( (decimal)salesTemp.SalesMoneyTaxInc - (decimal)salesTemp.SalesMoneyTaxExc );
			}
		}

		/// <summary>
		/// 売上原価を計算します。
		/// </summary>
		/// <param name="salesTemp">同時売上データオブジェクト</param>
		public void CalculationCost( ref SalesTemp salesTemp )
		{
			if (salesTemp.GoodsName == "") return;
			if (salesTemp.CustomerCode == 0) return;

			// 売上金額を算定
			long salesMoneyTaxInc;
			long salesMoneyTaxExc;
			double taxRate = salesTemp.ConsTaxRate;

			// 得意先マスタから消費税端数処理情報を取得
			int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// 売上消費税端数処理コード
			double fracProcUnit;
			int fracProcCd;
			this._stockSlipInputInitDataAcs.GetSalesFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

			int costFrcProcCd = 0; // 売上原価端数処理コード(0固定)
			int taxationCode = salesTemp.TaxationDivCd;

			double salesUnitPrice = salesTemp.SalesUnitCost;

			if (this.CalculationSalesCost(
				salesTemp.ShipmentCnt,
				salesUnitPrice,
				taxationCode,
				taxRate,
				fracProcUnit,
				fracProcCd,
				costFrcProcCd,
				out salesMoneyTaxInc,
				out salesMoneyTaxExc))
			{
				if (salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
				{
					salesTemp.Cost = salesMoneyTaxInc;
				}
				else
				{
					salesTemp.Cost = salesMoneyTaxExc;
				}
			}
		}

		/// <summary>
		/// 消費税に従って単価を再計算します。
		/// </summary>
		/// <param name="salesTemp">売上データ(仕入同時計上)オブジェクト</param>
		public void SalesTempTaxRateChanged( ref SalesTemp salesTemp )
		{
			// 仕入金額端数処理コード
			int salesMoneyFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.MoneyFrcProcCd);

			// 消費税端数処理区分
			int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// 売上消費税端数処理コード
			double fracProcUnit;
			int fracProcCd;
			this._stockSlipInputInitDataAcs.GetSalesFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

			// 課税方式に従って売上単価の税抜き、税込単価を再計算
			switch (salesTemp.TaxationDivCd)
			{
				case (int)CalculateTax.TaxationCode.TaxExc:
					salesTemp.SalesUnPrcTaxIncFl = (double)( (decimal)salesTemp.SalesUnPrcTaxExcFl + (decimal)CalculateTax.GetTaxFromPriceExc(salesTemp.ConsTaxRate, fracProcUnit, fracProcCd, salesTemp.SalesUnPrcTaxExcFl) );
					break;
				case (int)CalculateTax.TaxationCode.TaxInc:
					salesTemp.SalesUnPrcTaxExcFl = (double)( (decimal)salesTemp.SalesUnPrcTaxIncFl - (decimal)CalculateTax.GetTaxFromPriceInc(salesTemp.ConsTaxRate, fracProcUnit, fracProcCd, salesTemp.SalesUnPrcTaxIncFl) );
					break;
			}
		}

		/// <summary>
		/// 同時売上オブジェクト単価再計算
		/// </summary>
		/// <param name="salesTemp"></param>
		public void SalesTempSalesUnitPriceReSetting( ref SalesTemp salesTemp )
		{
			// 売上単価端数処理コード取得
			int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(salesTemp.EnterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);

			// 得意先マスタから消費税端数処理情報を取得
			int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// 売上消費税端数処理コード
			double taxFracProcUnit;
			int taxFracProcCd;
			this._stockSlipInputInitDataAcs.GetSalesFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

			// 端数処理単位、端数処理区分を取得
			double fracProcUnitSalUnPrc = salesTemp.FracProcUnitSalUnPrc;
			int fracProcSalUnPrc = salesTemp.FracProcSalUnPrc;

			double unitPriceTaxExc = salesTemp.SalesUnPrcTaxExcFl;
			double unitPriceTaxInc = salesTemp.SalesUnPrcTaxIncFl;

			int taxationCode = salesTemp.TaxationDivCd;

			switch (salesTemp.UnPrcCalcCdSalUnPrc)
			{
				//// 入力定価×掛率
				//case (int)UnitPriceCalculation.UnitPrcCalcDiv.InputListPrice:
				//    {
				//        salesTemp.StdUnPrcSalUnPrc = ( salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ? salesTemp.ListPriceTaxIncFl : salesTemp.ListPriceTaxExcFl;

				//        this._unitPriceCalculation.CalculateUnitPriceByRate(
				//            UnitPriceCalculation.UnitPriceKind.SalesUnitPrice,
				//            UnitPriceCalculation.UnitPrcCalcDiv.InputListPrice,
				//            salesTemp.TotalAmountDispWayCd,
				//            salesTemp.TtlAmntDispRateApy,
				//            salesUnPrcFrcProcCd,
				//            salesTemp.TaxationDivCd,
				//            salesTemp.StdUnPrcSalUnPrc,
				//            salesTemp.ConsTaxRate,
				//            taxFracProcUnit,
				//            taxFracProcCd,
				//            salesTemp.SalesRate,
				//            ref fracProcUnitSalUnPrc,
				//            ref fracProcSalUnPrc,
				//            out unitPriceTaxExc,
				//            out unitPriceTaxInc);

				//        salesTemp.SalesUnPrcChngCd = 0;
				//        break;
				//    }
				// 原価×原価UP率
				case (int)UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
					{
						salesTemp.StdUnPrcSalUnPrc = salesTemp.SalesUnitCost;
						this._unitPriceCalculation.CalculateUnitPriceByRate(
							UnitPriceCalculation.UnitPriceKind.SalesUnitPrice,
							UnitPriceCalculation.UnitPrcCalcDiv.UpRate,
							salesTemp.TotalAmountDispWayCd,
							salesTemp.TtlAmntDispRateApy,
							salesUnPrcFrcProcCd,
							salesTemp.TaxationDivCd,
							salesTemp.StdUnPrcSalUnPrc,
							salesTemp.ConsTaxRate,
							taxFracProcUnit,
							taxFracProcCd,
							salesTemp.SalesRate,
							ref fracProcUnitSalUnPrc,
							ref fracProcSalUnPrc,
							out unitPriceTaxExc,
							out unitPriceTaxInc);
						salesTemp.SalesUnPrcChngCd = 0;
						break;
					}

				// 原価×(1-粗利率)
				case (int)UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
					{
						salesTemp.StdUnPrcSalUnPrc = salesTemp.SalesUnitCost;
						this._unitPriceCalculation.CalculateUnitPriceByMarginRate(
							UnitPriceCalculation.UnitPriceKind.SalesUnitPrice,
							salesTemp.TotalAmountDispWayCd,
							salesTemp.TtlAmntDispRateApy,
							salesUnPrcFrcProcCd,
							salesTemp.TaxationDivCd,
							salesTemp.StdUnPrcSalUnPrc,
							salesTemp.ConsTaxRate,
							taxFracProcUnit,
							taxFracProcCd,
							salesTemp.SalesRate,
							ref fracProcUnitSalUnPrc,
							ref fracProcSalUnPrc,
							out unitPriceTaxExc,
							out unitPriceTaxInc);
						salesTemp.SalesUnPrcChngCd = 0;
						break;
					}
			}

			salesTemp.FracProcUnitSalUnPrc = fracProcUnitSalUnPrc;	// 端数処理単位
			salesTemp.FracProcSalUnPrc = fracProcSalUnPrc;			// 端数処理区分
			salesTemp.SalesUnPrcTaxExcFl = unitPriceTaxExc;			// 単価（税抜）
			salesTemp.SalesUnPrcTaxIncFl = unitPriceTaxInc;			// 単価（税込）
		}


		/// <summary>
		/// 単価情報確認用オブジェクト取得
		/// </summary>
		/// <param name="unitPriceKind">単価種類</param>
		/// <param name="salesTemp">同時売上オブジェクト</param>
		/// <returns>単価情報確認用オブジェクト</returns>
		public UnPrcInfoConf GetUnitPriceInfoConf( UnitPriceKind unitPriceKind, SalesTemp salesTemp )
		{
			UnPrcInfoConf unPrcInfoConf = new UnPrcInfoConf();

			if (salesTemp != null)
			{
				unPrcInfoConf.CustomerCode = salesTemp.CustomerCode;  					// 得意先コード
				unPrcInfoConf.CustomerSnm = salesTemp.CustomerSnm;						// 得意先略称
				unPrcInfoConf.SupplierCd = salesTemp.SupplierCd;						// 仕入先コード
				unPrcInfoConf.SupplierSnm = salesTemp.SupplierSnm;						// 仕入先略称
				unPrcInfoConf.CustRateGrpCode = salesTemp.CustRateGrpCode;				// 得意先掛率グループコード
				//unPrcInfoConf.SuppRateGrpCode = salesTemp.SuppRateGrpCode;				// 仕入先掛率グループコード
				unPrcInfoConf.GoodsNo = salesTemp.GoodsNo;								// 商品番号
				unPrcInfoConf.GoodsName = salesTemp.GoodsName;							// 商品名称
				unPrcInfoConf.GoodsMakerCd = salesTemp.GoodsMakerCd;					// 商品メーカーコード
				unPrcInfoConf.MakerName = salesTemp.MakerName;							// メーカー名称
				//unPrcInfoConf.LargeGoodsGanreCode = salesTemp.LargeGoodsGanreCode;		// 商品区分グループコード
				//unPrcInfoConf.LargeGoodsGanreName = salesTemp.LargeGoodsGanreName;		// 商品区分グループ名称
				//unPrcInfoConf.MediumGoodsGanreCode = salesTemp.MediumGoodsGanreCode;	// 商品区分コード
				//unPrcInfoConf.MediumGoodsGanreName = salesTemp.MediumGoodsGanreName;	// 商品区分名称
				//unPrcInfoConf.DetailGoodsGanreCode = salesTemp.DetailGoodsGanreCode;	// 商品区分詳細コード
				//unPrcInfoConf.DetailGoodsGanreName = salesTemp.DetailGoodsGanreName;	// 商品区分詳細名称
				unPrcInfoConf.BLGoodsCode = salesTemp.RateBLGoodsCode;					// BL商品コード
				unPrcInfoConf.BLGoodsFullName = salesTemp.RateBLGoodsName;				// BL商品コード名称（全角）
				//unPrcInfoConf.EnterpriseGanreCode = salesTemp.EnterpriseGanreCode;		// 自社分類コード
				//unPrcInfoConf.EnterpriseGanreName = salesTemp.EnterpriseGanreName;		// 自社分類名称
				unPrcInfoConf.GoodsRateRank = salesTemp.GoodsRateRank;					// 商品掛率ランク
				unPrcInfoConf.PriceApplyDate = ( salesTemp.AcptAnOdrStatus == 30 ) ? salesTemp.AddUpADate : salesTemp.ShipmentDay;	// 価格適用日
				unPrcInfoConf.CountFl = salesTemp.ShipmentCnt;    						// 数量
				//unPrcInfoConf.BargainCd = salesTemp.BargainCd;							// 特売区分コード

				switch (unitPriceKind)
				{
					// 売上単価
					case UnitPriceKind.SalesUnitPrice:
						unPrcInfoConf.RateSettingDivide = salesTemp.RateDivSalUnPrc;		// 掛率設定区分
						unPrcInfoConf.UnitPrcCalcDiv = salesTemp.UnPrcCalcCdSalUnPrc;		// 単価算出区分
						//unPrcInfoConf.PriceDiv = salesTemp.PriceCdSalUnPrc;					// 価格区分
						unPrcInfoConf.RateVal = salesTemp.SalesRate;						// 掛率
						unPrcInfoConf.UnPrcFracProcUnit = salesTemp.FracProcUnitSalUnPrc;	// 単価端数処理単位
						unPrcInfoConf.UnPrcFracProcDiv = salesTemp.FracProcSalUnPrc;		// 単価端数処理区分
						unPrcInfoConf.StdUnitPrice = salesTemp.StdUnPrcSalUnPrc;			// 基準単価
						unPrcInfoConf.SectionCode = salesTemp.RateSectSalUnPrc;				// 掛率設定拠点

						//unPrcInfoConf.UnitPriceFl = this.GetUnitPriceDisplay(salesTemp);	// 単価（浮動）
						//unPrcInfoConf.ListPriceFl = this.GetListPriceDisplay(salesTemp);	// 定価（浮動）
						//unPrcInfoConf.SalesUnitCost = salesTemp.SalesUnitCost;				// 原価単価
						break;
					// 原価単価
					case UnitPriceKind.SalesUnitCost:
						unPrcInfoConf.RateSettingDivide = salesTemp.RateDivUnCst;		   	// 掛率設定区分
						unPrcInfoConf.UnitPrcCalcDiv = salesTemp.UnPrcCalcCdUnCst;			// 単価算出区分
						//unPrcInfoConf.PriceDiv = salesTemp.PriceCdUnCst;				    // 価格区分
						unPrcInfoConf.RateVal = salesTemp.CostRate;						    // 掛率
						unPrcInfoConf.UnPrcFracProcUnit = salesTemp.FracProcUnitUnCst;    	// 単価端数処理単位
						unPrcInfoConf.UnPrcFracProcDiv = salesTemp.FracProcUnCst; 			// 単価端数処理区分
						unPrcInfoConf.SectionCode = salesTemp.RateSectCstUnPrc;				// 掛率設定拠点
						unPrcInfoConf.StdUnitPrice = salesTemp.StdUnPrcUnCst; 				// 基準単価
						//unPrcInfoConf.UnitPriceFl = salesTemp.SalesUnitCost;      			// 単価（浮動）
						break;
					// 定価
					case UnitPriceKind.ListPrice:
						unPrcInfoConf.RateSettingDivide = salesTemp.RateDivLPrice;			// 掛率設定区分
						unPrcInfoConf.UnitPrcCalcDiv = salesTemp.UnPrcCalcCdLPrice;			// 単価算出区分
						//unPrcInfoConf.PriceDiv = salesTemp.PriceCdLPrice;	    			// 価格区分
						unPrcInfoConf.RateVal = salesTemp.ListPriceRate;					// 掛率
						unPrcInfoConf.UnPrcFracProcUnit = salesTemp.FracProcUnitLPrice;		// 単価端数処理単位
						unPrcInfoConf.UnPrcFracProcDiv = salesTemp.FracProcLPrice;			// 単価端数処理区分
						unPrcInfoConf.StdUnitPrice = salesTemp.StdUnPrcLPrice;				// 基準単価
						unPrcInfoConf.SectionCode = salesTemp.RateSectPriceUnPrc;			// 掛率設定拠点
						//unPrcInfoConf.UnitPriceFl = this.GetListPriceDisplay(salesTemp);	// 単価（浮動）
						break;
					default:
						break;
				}
			}

			return unPrcInfoConf;
		}

		/// <summary>
		/// 単価確認画面結果クラスより、単価情報設定を設定します。
		/// </summary>
		/// <param name="unitPriceKind">単価種類</param>
		/// <param name="unPrcInfoConfRet">単価確認画面結果オブジェクト</param>
		/// <param name="salesTemp">同時売りあgえオブジェクト</param>
		public void UnPrcInfoSetting( SalesTempInputAcs.UnitPriceKind unitPriceKind, UnPrcInfoConfRet unPrcInfoConfRet, ref SalesTemp salesTemp )
		{
			if (salesTemp == null) return;
			switch (unitPriceKind)
			{
				// 売上単価
				case UnitPriceKind.SalesUnitPrice:
					salesTemp.UnPrcCalcCdSalUnPrc = unPrcInfoConfRet.UnitPrcCalcDiv;		// 単価算出区分
					//salesTemp.PriceCdSalUnPrc = unPrcInfoConfRet.PriceDiv;					// 価格区分
					salesTemp.SalesRate = unPrcInfoConfRet.RateVal;							// 掛率
					salesTemp.StdUnPrcSalUnPrc = unPrcInfoConfRet.StdUnitPrice;				// 基準単価
					//1this.UnitPriceSetting(ref salesTemp, unPrcInfoConfRet.UnitPriceFl);		// 単価設定
					salesTemp.FracProcUnitSalUnPrc = unPrcInfoConfRet.UnPrcFracProcUnit;	// 端数処理単位
					salesTemp.FracProcSalUnPrc = unPrcInfoConfRet.UnPrcFracProcDiv;			// 端数処理区分
					break;
				// 原価単価
				case UnitPriceKind.SalesUnitCost:
					salesTemp.UnPrcCalcCdUnCst = unPrcInfoConfRet.UnitPrcCalcDiv;			// 単価算出区分
					//salesTemp.PriceCdUnCst = unPrcInfoConfRet.PriceDiv;						// 価格区分
					salesTemp.CostRate = unPrcInfoConfRet.RateVal;							// 掛率
					salesTemp.StdUnPrcUnCst = unPrcInfoConfRet.StdUnitPrice;				// 基準単価
					//salesTemp.SalesUnitCost = unPrcInfoConfRet.UnitPriceFl;					// 単価（浮動）
					salesTemp.FracProcUnitUnCst = unPrcInfoConfRet.UnPrcFracProcUnit;		// 端数処理単位
					salesTemp.FracProcUnCst = unPrcInfoConfRet.UnPrcFracProcDiv;			// 端数処理区分
					break;
				// 定価
				case UnitPriceKind.ListPrice:
					salesTemp.UnPrcCalcCdLPrice = unPrcInfoConfRet.UnitPrcCalcDiv;			// 単価算出区分
					//salesTemp.PriceCdLPrice = unPrcInfoConfRet.PriceDiv;					// 価格区分
					salesTemp.ListPriceRate = unPrcInfoConfRet.RateVal;						// 掛率
					salesTemp.StdUnPrcLPrice = unPrcInfoConfRet.StdUnitPrice;				// 基準単価
					//this.ListPriceSetting(ref salesTemp, unPrcInfoConfRet.UnitPriceFl);		// 定価設定
					salesTemp.FracProcUnitLPrice = unPrcInfoConfRet.UnPrcFracProcUnit;		// 端数処理単位
					salesTemp.FracProcLPrice = unPrcInfoConfRet.UnPrcFracProcDiv;			// 端数処理区分
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// 粗利チェック
		/// </summary>
		/// <param name="salesTemp">売上データ(仕入同時計上)オブジェクト</param>
		/// <returns>0:適正,1:下限値未満,2:上限値以上</returns>
		public int MarginCheck( SalesTemp salesTemp )
		{

			// 得意先が設定されていない場合
			if (( salesTemp == null ) || ( salesTemp.CustomerCode == 0 ))
			{
				return 0;
			}

			double targetPrice = ( salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ? salesTemp.SalesMoneyTaxInc : salesTemp.SalesMoneyTaxExc;

			// 粗利率の計算
			double marginRate = this._salesPriceCalclate.CalculateMarginRate(targetPrice - salesTemp.Cost, targetPrice);

			// 下限値設定有り
			if (this._stockSlipInputInitDataAcs.GetSalesTtlSt().GrsProfitCheckLower != 0)
			{
				if (marginRate < this._stockSlipInputInitDataAcs.GetSalesTtlSt().GrsProfitCheckLower)
				{
					return 1;
				}
			}

			// 上限値設定有り
			if (this._stockSlipInputInitDataAcs.GetSalesTtlSt().GrsProfitCheckUpper != 0)
			{
				if (marginRate >= this._stockSlipInputInitDataAcs.GetSalesTtlSt().GrsProfitCheckUpper)
				{
					return 2;
				}
			}
			return 0;
		}

		#endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		#region ■Private Methods

		/// <summary>
		/// 画面表示イベント実行
		/// </summary>
		private void SetDisplayCall()
		{
			if (this.SetDisplay != null)
			{
				this.SetDisplay(this._salesTemp);
			}
		}

		/// <summary>
		/// キャッシュイベントコール処理
		/// </summary>
		/// <param name="stockRowNo">仕入明細行番号</param>
		/// <param name="salesTemp">売上データ(仕入同時計上)オブジェクト</param>
		private void CacheCall( int stockRowNo, SalesTemp salesTemp )
		{
			if (this.CacheSalesTemp != null)
			{
				this.CacheSalesTemp(stockRowNo, salesTemp);
			}
		}


		/// <summary>
		/// 売上金額を計算します。
		/// </summary>
		/// <param name="count">数量</param>
		/// <param name="unitPrice">単価</param>
		/// <param name="taxationCode">課税区分</param>
		/// <param name="taxRate">消費税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
		/// <param name="fracProcCode">端数処理コード</param>
		/// <param name="salesMoneyTaxInc">金額（税込み）</param>
		/// <param name="salesMoneyTaxExc">仕入金額（税抜き）</param>
		/// <returns></returns>
		private bool CalculationSalesMoney( double count, double unitPrice, int taxationCode, double taxRate, double taxFracProcUnit, int taxFracProcCd, int fracProcCode, out long salesMoneyTaxInc, out long salesMoneyTaxExc )
		{
			salesMoneyTaxInc = 0;
			salesMoneyTaxExc = 0;

			// 仕入数が0または仕入単価が0の場合はすべて0で終了
			if (( count == 0 ) || ( unitPrice == 0 )) return true;

			// 外税の場合
			if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
			{
				double unitPriceExc = unitPrice;	// 単価（税抜き）
				double unitPriceInc;				// 単価（税込み）
				double unitPriceTax;				// 単価（消費税）
				long priceExc = 0;					// 価格（税抜き）
				long priceInc;						// 価格（税込み）
				long priceTax;						// 価格（消費税）

				this._salesPriceCalclate.CalcTaxIncFromTaxExc(taxationCode, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

				salesMoneyTaxInc = priceInc;		// 仕入金額（税込み）
				salesMoneyTaxExc = priceExc;		// 仕入金額（税抜き）		
			}
			// 内税の場合
			else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
			{
				double unitPriceExc;				// 単価（税抜き）
				double unitPriceInc = unitPrice;	// 単価（税込み）
				double unitPriceTax;				// 単価（消費税）
				long priceExc;						// 価格（税抜き）
				long priceInc = 0;					// 価格（税込み）
				long priceTax;						// 価格（消費税）

				this._salesPriceCalclate.CalcTaxExcFromTaxInc(taxationCode, count, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

				salesMoneyTaxInc = priceInc;		// 仕入金額（税込み）
				salesMoneyTaxExc = priceExc;		// 仕入金額（税抜き）
			}
			// 非課税の場合
			else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
			{
				double unitPriceExc = unitPrice;	// 単価（税抜き）
				double unitPriceInc;				// 単価（税込み）
				double unitPriceTax;				// 単価（消費税）
				long priceExc = 0;					// 価格（税抜き）
				long priceInc;						// 価格（税込み）
				long priceTax;						// 価格（消費税）

				this._salesPriceCalclate.CalcTaxIncFromTaxExc(taxationCode, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

				salesMoneyTaxInc = priceExc;		// 仕入金額（税込み）
				salesMoneyTaxExc = priceExc;		// 仕入金額（税込み）
			}

			return true;
		}

		/// <summary>
		/// 売上金額を計算します。
		/// </summary>
		/// <param name="count">数量</param>
		/// <param name="unitPrice">単価</param>
		/// <param name="taxationCode">課税区分</param>
		/// <param name="taxRate">消費税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
		/// <param name="fracProcCode">端数処理コード</param>
		/// <param name="salesMoneyTaxInc">金額（税込み）</param>
		/// <param name="salesMoneyTaxExc">仕入金額（税抜き）</param>
		/// <returns></returns>
		private bool CalculationSalesCost( double count, double unitPrice, int taxationCode, double taxRate, double taxFracProcUnit, int fracProcCode, int taxFracProcCd, out long salesMoneyTaxInc, out long salesMoneyTaxExc )
		{
            salesMoneyTaxInc = 0;
            salesMoneyTaxExc = 0;

            //// 仕入数が0または仕入単価が0の場合はすべて0で終了
            //if (( count == 0 ) || ( unitPrice == 0 )) return true;

            //// 外税の場合
            //if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            //{
            //    double unitPriceExc = unitPrice;	// 単価（税抜き）
            //    double unitPriceInc;				// 単価（税込み）
            //    double unitPriceTax;				// 単価（消費税）
            //    long priceExc = 0;					// 価格（税抜き）
            //    long priceInc;						// 価格（税込み）
            //    long priceTax;						// 価格（消費税）

            //    this._salesPriceCalclate.CalcCostTaxIncFromTaxExc(taxationCode, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

            //    salesMoneyTaxInc = priceInc;		// 仕入金額（税込み）
            //    salesMoneyTaxExc = priceExc;		// 仕入金額（税抜き）		
            //}
            //// 内税の場合
            //else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            //{
            //    double unitPriceExc;				// 単価（税抜き）
            //    double unitPriceInc = unitPrice;	// 単価（税込み）
            //    double unitPriceTax;				// 単価（消費税）
            //    long priceExc;						// 価格（税抜き）
            //    long priceInc = 0;					// 価格（税込み）
            //    long priceTax;						// 価格（消費税）

            //    this._salesPriceCalclate.CalcCostTaxExcFromTaxInc(taxationCode, count, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

            //    salesMoneyTaxInc = priceInc;		// 仕入金額（税込み）
            //    salesMoneyTaxExc = priceExc;		// 仕入金額（税抜き）
            //}
            //// 非課税の場合
            //else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            //{
            //    double unitPriceExc = unitPrice;	// 単価（税抜き）
            //    double unitPriceInc;				// 単価（税込み）
            //    double unitPriceTax;				// 単価（消費税）
            //    long priceExc = 0;					// 価格（税抜き）
            //    long priceInc;						// 価格（税込み）
            //    long priceTax;						// 価格（消費税）

            //    this._salesPriceCalclate.CalcCostTaxIncFromTaxExc(taxationCode, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

            //    salesMoneyTaxInc = priceExc;		// 仕入金額（税込み）
            //    salesMoneyTaxExc = priceExc;		// 仕入金額（税込み）
            //}

			return true;
		}

		/// <summary>
		/// 対象金額より、税抜き、税込み価格を計算します。
		/// </summary>
		/// <param name="taxationCode">課税区分</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="taxRate">税率</param>
		/// <param name="totalAmountDispWayCd">総額表示区分</param>
		/// <param name="displayPrice">対象金額</param>
		/// <param name="priceTaxExc">税抜き金額</param>
		/// <param name="priceTaxInc">税込み金額</param>
		private void CalcTaxExcAndTaxInc( int taxationCode, int customerCode, double taxRate, int totalAmountDispWayCd, double displayPrice, out double priceTaxExc, out double priceTaxInc )
		{
			priceTaxExc = 0;
			priceTaxInc = 0;
			// 得意先マスタから消費税端数処理情報を取得
			int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, customerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// 売上消費税端数処理コード
			double fracProcUnit;
			int fracProcCd;
			this._stockSlipInputInitDataAcs.GetSalesFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

			// 内税品
			if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
			{
				priceTaxInc = displayPrice;
				priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
			}
			// 外税品
			else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
			{
				// 総額表示している場合は税込み価格
				if (totalAmountDispWayCd == 1)
				{
					priceTaxInc = displayPrice;
					priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
				}
				else
				{
					priceTaxExc = displayPrice;
					priceTaxInc = displayPrice + CalculateTax.GetTaxFromPriceExc(taxRate, fracProcUnit, fracProcCd, priceTaxExc);
				}
			}
			// 非課税品
			else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
			{
				priceTaxExc = displayPrice;
				priceTaxInc = displayPrice;
			}
			else
			{
				priceTaxExc = 0;
				priceTaxInc = 0;
			}
		}

		/// <summary>
		/// 同時売上オブジェクトの掛率関係の情報をクリアします。
		/// </summary>
		/// <param name="salesTemp"></param>
		private void SalesTempRateInfoClear( ref SalesTemp salesTemp )
		{
			salesTemp.RateDivSalUnPrc = "";		// 掛率設定区分
			salesTemp.UnPrcCalcCdSalUnPrc = 0;	// 単価算出区分
			salesTemp.PriceCdSalUnPrc = 0;		// 価格区分
			salesTemp.StdUnPrcSalUnPrc = 0;		// 基準単価
			salesTemp.SalesUnPrcTaxExcFl = 0;	// 売単価(税抜)
			salesTemp.SalesUnPrcTaxIncFl = 0;	// 売単価(税込)
			salesTemp.SalesRate = 0;			// 売価率
			salesTemp.FracProcUnitSalUnPrc = 0;	// 端数処理単位
			salesTemp.FracProcSalUnPrc = 0;		// 端数処理区分
			salesTemp.SalesUnPrcChngCd = 0;		// 単価変更区分
			//--------------------------------------------
			// 原単価
			//--------------------------------------------
			salesTemp.RateDivUnCst = "";		// 掛率設定区分
			salesTemp.UnPrcCalcCdUnCst = 0;		// 単価算出区分
			salesTemp.PriceCdUnCst = 0;			// 価格区分
			salesTemp.StdUnPrcUnCst = 0;		// 基準単価
			salesTemp.SalesUnitCost = 0;		// 原単価(税込)
			salesTemp.CostRate = 0;				// 原価率
			salesTemp.FracProcUnitUnCst = 0;	// 端数処理単位
			salesTemp.FracProcUnCst = 0;		// 端数処理区分
			salesTemp.SalesUnitCostChngDiv = 0;	// 原価単価変更区分
			//--------------------------------------------
			// 定価
			//--------------------------------------------
			salesTemp.RateDivLPrice = "";		// 掛率設定区分
			salesTemp.UnPrcCalcCdLPrice = 0;	// 単価算出区分
			salesTemp.PriceCdLPrice = 0;		// 価格区分
			salesTemp.StdUnPrcLPrice = 0;		// 基準単価
			salesTemp.ListPriceTaxExcFl = 0;	// 定価(税抜)
			salesTemp.ListPriceTaxIncFl = 0;	// 定価(税込)
			salesTemp.ListPriceRate = 0;		// 定価率
			salesTemp.FracProcUnitLPrice = 0;	// 端数処理単位
			salesTemp.FracProcLPrice = 0;		// 端数処理区分
			salesTemp.ListPriceChngCd = 0;		// 定価変更区分
		}


		#endregion

		// ===================================================================================== //
		// スタティックメソッド
		// ===================================================================================== //
		#region ■Static Methods

		/// <summary>
		/// 表示用売上伝票区分より、伝票区分、買掛区分を設定します。
		/// </summary>
		/// <param name="salesSlipCdDisplay">売上伝票区分（表示用）</param>
		/// <param name="salesTemp">同時売上情報</param>
		static public void SetSlipCdAndAccPayDivCdByDisplay( int salesSlipCdDisplay, ref SalesTemp salesTemp )
		{
			int salesSlipCd, accPayDivCd;
			GetSlipCdAndAccPayDivCdFromSalesSlipCdDisplay(salesSlipCdDisplay, out salesSlipCd, out accPayDivCd);

			salesTemp.SalesSlipCd = salesSlipCd;
			salesTemp.AccRecDivCd = accPayDivCd;
		}

		/// <summary>
		/// 表示用仕入伝票区分より、仕入伝票区分、買掛区分を取得します。
		/// </summary>
		/// <param name="salesSlipCdDisplay">表示用売上伝票区分</param>
		/// <param name="salesSlipCd">売上伝票区分</param>
		/// <param name="accPayDivCd">買掛区分</param>
		static public void GetSlipCdAndAccPayDivCdFromSalesSlipCdDisplay( int salesSlipCdDisplay, out int salesSlipCd, out int accPayDivCd )
		{
			// 初期値は掛売上
			salesSlipCd = 10;
			accPayDivCd = 1;
			switch (salesSlipCdDisplay)
			{
				// 掛売上
				case 10:
					{
						salesSlipCd = 0;
						accPayDivCd = 1;
						break;
					}
				// 掛返品
				case 20:
					{
						salesSlipCd = 1;
						accPayDivCd = 1;
						break;
					}
				// 現金売上
				case 30:
					{
						salesSlipCd = 0;
						accPayDivCd = 0;
						break;
					}
				// 現金返品
				case 40:
					{
						salesSlipCd = 1;
						accPayDivCd = 0;
						break;
					}
			}
		}

		/// <summary>
		/// 仕入伝票区分、買掛区分より、表示用仕入伝票区分します。
		/// </summary>
		/// <param name="salesSlipCd">伝票区分</param>
		/// <param name="accPayDivCd">買掛区分</param>
		/// <returns>表示用仕入伝票区分</returns>
		static public int GetSalesSlipCdDisplayFromSlipCdAndAccPayDivCd( int salesSlipCd, int accPayDivCd )
		{
			int value = 0;
			// 伝票区分
			switch (salesSlipCd)
			{
				// 売上
				case 0:
					{
						value = 10;
						break;
					}
				// 返品
				case 1:
					{
						value = 20;
						break;
					}
			}

			// 売掛区分
			switch (accPayDivCd)
			{
				case 0:
					{
						value += 20;
						break;
					}
				default:
					{
						break;
					}
			}
			return value;
		}

		#endregion
	}

#endif
}
