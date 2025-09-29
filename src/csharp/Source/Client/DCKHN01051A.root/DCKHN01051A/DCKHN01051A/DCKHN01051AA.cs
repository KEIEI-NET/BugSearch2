# region ※using
using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Runtime.Serialization;
# endregion

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 単価情報確認画面アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 単価情報確認画面データ検索等を行います。</br>
	/// <br>Programmer	: 21024　佐々木 健</br>
	/// <br>Date		: 2008.06.24</br>
    /// <br>            : 10801804-00 2013/5/15配信分の緊急対応</br>
    /// <br>UpdateNote  : 2013/04/12 xujx　Redmine#35342 対応：価格ガイドの修正</br>
	/// </remarks>
	public class DCKHN01051A
	{
		# region ■Private Members
		
		private string _enterpriseCode;						// 企業コード

		private UnPrcInfoConf _unPrcInfoConf;				// 単価情報確認画面データクラス
		private UnPrcInfoConfRet _unPrcInfoConfRet;			// 単価情報確認画面結果クラス

		private UnPrcInfoConfDataSet _dataSet;				// データセット
		private GoodsAcs _goodsAcs;							// 商品アクセスクラス
		private GoodsUnitData _goodsUnitData;				// 商品連結データ
		private int _unitPriceKindCode;						// 単価種類
        private RateMngGoodsCust _rateMngGoodsCust;         // 掛率設定管理マスタアクセスクラス
        private static DataTable _rateMngTable = new DataTable();

        /// <summary>ユーザーガイド区分コード（価格）</summary>
		public static readonly int ctDIVCODE_UserGuideDivCd_PriceDiv = 47;
		/// <summary>ユーザーガイド区分コード（特売区分）</summary>
		public static readonly int ctDIVCODE_UserGuideDivCd_Bargain = 42;

		# endregion

		# region ■Constructor
		/// <summary>
		/// 単価情報確認画面アクセスクラス コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 単価情報確認画面アクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21024　佐々木 健</br>
		/// <br>Date       : 2008.06.20</br>
		/// </remarks>
		public DCKHN01051A()
		{
			// 企業コードを取得する
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			this._dataSet = new UnPrcInfoConfDataSet();

			this._unPrcInfoConf = new UnPrcInfoConf();
			this._unPrcInfoConfRet = new UnPrcInfoConfRet();

			this._goodsAcs = new GoodsAcs();

            this._rateMngGoodsCust = new RateMngGoodsCust();
		}
		# endregion

		#region■Properties
		/// <summary>ロットテーブルプロパティ</summary>
		public UnPrcInfoConfDataSet.LotInfoDataTable LotInfoTable
		{
			get { return this._dataSet.LotInfo; }
		}

		/// <summary>価格情報テーブルプロパティ</summary>
		public UnPrcInfoConfDataSet.PriceInfoDataTable PriceInfoTable
		{
			get { return this._dataSet.PriceInfo; }
		}

		/// <summary>単価情報</summary>
		public UnPrcInfoConf UnitPriceInfoConf
		{
			set 
			{ 	this._unPrcInfoConf = value;
				this._unPrcInfoConfRet = this.GetUnPrcInfoConfRet(this._unPrcInfoConf);
			}
			get { return this._unPrcInfoConf; }
		}

		/// <summary>単価情報確認結果</summary>
		public UnPrcInfoConfRet UnPrcInfoConfRet
		{
			get { return this._unPrcInfoConfRet; }
		}

		/// <summary>単価種類</summary>
		public int UnitPriceKindCode
		{
			set { this._unitPriceKindCode = value; }
		}
		#endregion

		#region■Public Methods

		/// <summary>
		/// 初期情報検索処理
		/// </summary>
		public void InitialSearch()
		{
			this.SearchGoods();
			this.SearchRate();
            this.SearchRateMngGoodsCust();
		}

		/// <summary>
		/// 単価の計算を行います。
		/// </summary>
		public void CalclationUnitPrice()
		{
			//switch (this._unPrcInfoConf.UnitPrcCalcDiv)
			//{
			//    case 1:	// 基準価格×掛率
			//    case 2:	// 原価×原価UP率
			//    case 4:	// 入力定価×掛率
			//        {
			//            this._unPrcInfoConf.UnitPriceFl = this.CalclateUnitPriceByRate(this._unPrcInfoConf.StdUnitPrice, this._unPrcInfoConf.RateVal, this._unPrcInfoConf.UnPrcFracProcUnit, this._unPrcInfoConf.UnPrcFracProcDiv);
			//            break;
			//        }
			//    case 3:	// 原価÷（１－粗利率）
			//        {
			//            this._unPrcInfoConf.UnitPriceFl = this.CalclateUnitPriceByMarginRate(this._unPrcInfoConf.StdUnitPrice, this._unPrcInfoConf.RateVal, this._unPrcInfoConf.UnPrcFracProcUnit, this._unPrcInfoConf.UnPrcFracProcDiv);
			//            break;
			//        }
			//}
		}

		/// <summary>
		/// 単価直接設定処理
		/// </summary>
		/// <param name="unitPrice"></param>
		public void UnitPriceDirectSetting( double unitPrice )
		{
			double unitPriceTaxInc = 0;
			double unitPriceTaxExc = 0;

			if (( this._unPrcInfoConf.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) || ( this._unPrcInfoConf.TotalAmountDispWayCd == 1 ))
			{
				// ①税込み単価 = 基準単価から掛率計算した結果
				unitPriceTaxInc = unitPrice;

				// ②税抜き単価 = 税込み単価 - 税込み単価の消費税
				unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._unPrcInfoConf.TaxRate, this._unPrcInfoConf.TaxFractionProcUnit, this._unPrcInfoConf.TaxFractionProcCd, unitPriceTaxInc);
			}
			else if (this._unPrcInfoConf.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
			{
				// ①税抜き単価 = 基準単価から掛率計算した結果
				unitPriceTaxExc = unitPrice;

				// ②税込み単価 = 税抜き単価 + 税抜き単価の消費税
				unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._unPrcInfoConf.TaxRate, this._unPrcInfoConf.TaxFractionProcUnit, this._unPrcInfoConf.TaxFractionProcCd, unitPriceTaxExc);
			}
			this._unPrcInfoConf.UnitPriceTaxExcFl = unitPriceTaxExc;	// 単価(税抜)
			this._unPrcInfoConf.UnitPriceTaxIncFl = unitPriceTaxInc;	// 単価(税込)
			this._unPrcInfoConf.StdUnitPrice = 0;			// 基準価格
			this._unPrcInfoConf.RateVal = 0;				// 率
			this._unPrcInfoConf.UnPrcFracProcUnit = 0;		// 端数処理単位
			this._unPrcInfoConf.UnPrcFracProcDiv = 0;		// 端数処理
			this._unPrcInfoConf.UnitPrcCalcDiv = 0;			// 単価算出区分
		}

		/// <summary>
		/// 単価計算方法設定処理
		/// </summary>
		/// <param name="unitPrcCalcDiv"></param>
		public void unitPrcCalcDivSetting( int unitPrcCalcDiv )
		{
			this._unPrcInfoConf.UnitPrcCalcDiv = unitPrcCalcDiv;
			//switch (unitPrcCalcDiv)
			//{
			//    case 0:	// ゼロは無視
			//        {
			//            break;
			//        }
			//    case 2:	// 原価×原価UP率
			//    case 3:	// 原価÷（１－粗利率）
			//        {
			//            // 基準単価区分をゼロにする
			//            this._unPrcInfoConf.PriceDiv = 0;
			//            // 基準単価に原価単価をセット
			//            this._unPrcInfoConf.StdUnitPrice = this._unPrcInfoConf.SalesUnitCost;
			//            break;
			//        }
			//    case 4:	// 入力定価×掛率
			//        {
			//            // 基準単価区分をゼロにする
			//            this._unPrcInfoConf.PriceDiv = 0;
			//            // 基準単価に原価単価をセット
			//            this._unPrcInfoConf.StdUnitPrice = this._unPrcInfoConf.ListPriceFl;
			//            break;
			//        }
			//    default:
			//        {
			//            this.PriceCdSetting(this._unPrcInfoConf.PriceDiv);
			//            break;
			//        }
			//}
		}

		/// <summary>
		/// 基準価格区分設定処理
		/// </summary>
		/// <param name="priceDiv"></param>
		public void PriceCdSetting( int priceDiv )
		{
			//this._unPrcInfoConf.PriceDiv = priceDiv;

			//if (this._itemsPriceDivList.ContainsKey(priceDiv))
			//{
			//    this._unPrcInfoConf.StdUnitPrice = this.GetPriceFromPriceInfoTable(priceDiv);
			//}
			//this.CalclationUnitPrice();
		}

		/// <summary>
		/// 基準価設定処理
		/// </summary>
		/// <param name="stdUnPrc"></param>
		public void StdUnPrcSetting( double stdUnPrc )
		{
			this._unPrcInfoConf.StdUnitPrice = stdUnPrc;
			//this._unPrcInfoConf.PriceDiv = 0;
			this.ReCalcUnitPrice();
		}

		/// <summary>
		/// 率設定処理
		/// </summary>
		/// <param name="rate"></param>
		public void RateSetting( double rate )
		{
			this._unPrcInfoConf.RateVal = rate;

			this.ReCalcUnitPrice();
		}

		/// <summary>
		/// 単価再計算処理
		/// </summary>
		public void ReCalcUnitPrice()
		{
			if (this._unPrcInfoConf.StdUnitPrice == 0) return;
			this.CalclationUnitPrice();
		}

		/// <summary>
		/// 価格情報テーブルより、基準価格を取得します。
		/// </summary>
		/// <returns>基準価格</returns>
		public double GetPriceFromPriceInfoTable()
		{
			//return this.GetPriceFromPriceInfoTable(this._unPrcInfoConf.PriceDiv);
			return 0;
		}

		/// <summary>
		/// キャッシュされている単価情報画面オブジェクトから単価情報確認結果オブジェクトを設定します。
		/// </summary>
		public void UnPrcInfoConfRetSetting()
		{
			this._unPrcInfoConfRet = this.GetUnPrcInfoConfRet(this._unPrcInfoConf);
		}
		#endregion

		#region ■Private Methods

		/// <summary>
		/// 商品検索処理
		/// </summary>
		/// <returns></returns>
		private int SearchGoods()
		{
            GoodsUnitData goodsUnitData = null;
            this._dataSet.PriceInfo.Rows.Clear();

            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsNo = this._unPrcInfoConf.GoodsNo;
            goodsCndtn.GoodsMakerCd = this._unPrcInfoConf.GoodsMakerCd;

            List<GoodsUnitData> goodsUnitDataList;
            string msg;
            int status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtn, out goodsUnitDataList, out msg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (GoodsUnitData retGoodsUnitData in goodsUnitDataList)
                {
                    if (( retGoodsUnitData.GoodsNo == this._unPrcInfoConf.GoodsNo ) &&
                        ( retGoodsUnitData.GoodsMakerCd == this._unPrcInfoConf.GoodsMakerCd ))
                    {
                        goodsUnitData = retGoodsUnitData;
                    }
                }
                if (goodsUnitData != null)
                {
                    this._goodsUnitData = goodsUnitData.Clone();

                    this._dataSet.PriceInfo.Rows.Clear();

                    List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;

                    foreach (GoodsPrice goodsPrice in goodsPriceList)
                    {
                        UnPrcInfoConfDataSet.PriceInfoRow row = this._dataSet.PriceInfo.NewPriceInfoRow();
                        row.PriceStartDate = goodsPrice.PriceStartDate;
                        row.ListPrice = goodsPrice.ListPrice;
                        row.SalesUnitCost = goodsPrice.SalesUnitCost;
                        row.StockRate = goodsPrice.StockRate;

                        this._dataSet.PriceInfo.AddPriceInfoRow(row);
                    }
                }
                else
                {
                    this._goodsUnitData = new GoodsUnitData();
                }
            }

			return status;
		}

		/// <summary>
		/// 掛率マスタを検索し、ロット情報を取得します。
		/// </summary>
		private void SearchRate()
		{
			this._dataSet.LotInfo.Rows.Clear();

			RateAcs rateAcs = new RateAcs();

			DataTable dataTable = new DataTable();
			string msg;

			Rate rate = CreateRateFromUnitPriceInfoConf(this._unPrcInfoConf);
			rate.EnterpriseCode = this._enterpriseCode;
			rate.UnitPriceKind = this._unitPriceKindCode.ToString();

            rateAcs.Search(out dataTable, ref rate, out msg);

            if (( dataTable != null ) && ( dataTable.Rows.Count > 0 ))
            {
                // 対象設定のロットリストを取得(ロット数でソート)
                DataRow[] rows = dataTable.Select(string.Format("{0}={1} AND {2}<>0", RateAcs.LOGICALDELETECODE, 0, RateAcs.LOTCOUNT), string.Format("{0}", RateAcs.LOTCOUNT));
                if (( rows != null ) && ( rows.Length > 0 ))
                {
                    foreach (DataRow row in rows)
                    {
                        UnPrcInfoConfDataSet.LotInfoRow lotInfoRow = this._dataSet.LotInfo.NewLotInfoRow();
                        lotInfoRow.LotCount = (double)row[RateAcs.LOTCOUNT];
                        lotInfoRow.CountRange = string.Format("{0:#.00}以下", (double)row[RateAcs.LOTCOUNT]);
                        lotInfoRow.PriceFl = (double)row[RateAcs.PRICEFL];
                        lotInfoRow.RateVal = (double)row[RateAcs.RATEVAL];
                        lotInfoRow.UpRate = (double)row[RateAcs.UPRATE];
                        lotInfoRow.GrsProfitSecureRate = (double)row[RateAcs.GRSPROFITSECURERATE];
                        lotInfoRow.UnPrcFracProcUnit = (double)row[RateAcs.UNPRCFRACPROCUNIT];
                        lotInfoRow.UnPrcFracProcDiv = (int)row[RateAcs.UNPRCFRACPROCDIV];
                        lotInfoRow.UnPrcFracProcDivName = GetFracProcDivName(lotInfoRow.UnPrcFracProcDiv);
                        this._dataSet.LotInfo.AddLotInfoRow(lotInfoRow);
                    }
                }
            }
		}

        /// <summary>
        /// 掛率設定管理マスタ検索処理
        /// </summary>
        private void SearchRateMngGoodsCust()
        {
            int totalCnt;
            bool nextData;
            string msg;
            int st = this._rateMngGoodsCust.SearchAll(out _rateMngTable, out totalCnt, out nextData, this._enterpriseCode, "", out msg);
        }

		/// <summary>
		/// 掛率を使用して単価を計算します。
		/// </summary>
		/// <param name="stdPrice">基準価格</param>
		/// <param name="rate">掛率</param>
		/// <param name="fracProcUnit">端数処理単位</param>
		/// <param name="fracProcCd">端数処理区分</param>
		/// <returns></returns>
		private double CalclateUnitPriceByRate( double stdPrice, double rate, double fracProcUnit, int fracProcCd )
		{
			if (( rate == 0 ) || ( stdPrice == 0 ) || ( fracProcCd == 0 ) || ( fracProcUnit == 0)) return 0;

			double unitPrice = ( rate < 0 ) ? stdPrice * ( 100 + rate ) * 0.01 : stdPrice * rate * 0.01;

			FractionCalculate.FracCalcMoney(unitPrice, fracProcUnit, fracProcCd, out unitPrice);

			return unitPrice;
		}

		/// <summary>
		/// 粗利率を使用して単価を計算します。
		/// </summary>
		/// <param name="costPrice">原価単価</param>
		/// <param name="marginRate">粗利率</param>
		/// <param name="fracProcUnit">端数処理単位</param>
		/// <param name="fracProcCd">端数処理区分</param>
		/// <returns>単価</returns>
		private double CalclateUnitPriceByMarginRate( double costPrice, double marginRate, double fracProcUnit, int fracProcCd )
		{
			if (( marginRate == 0 ) || ( costPrice == 0 ) || ( fracProcUnit == 0 ) || ( fracProcCd == 0 )) return 0;

			double unitPrice = costPrice / ( 1 - marginRate * 0.01 );

			FractionCalculate.FracCalcMoney(unitPrice, fracProcUnit, fracProcCd, out unitPrice);

			return unitPrice;
		}

		/// <summary>
		/// 単価情報確認結果オブジェクトを生成します。
		/// </summary>
		/// <param name="unPrcInfoConf">単価情報確認オブジェクト</param>
		/// <returns>単価情報確認結果オブジェクト</returns>
		private UnPrcInfoConfRet GetUnPrcInfoConfRet( UnPrcInfoConf unPrcInfoConf )
		{
			UnPrcInfoConfRet unPrcInfoConfRet = new UnPrcInfoConfRet();

            unPrcInfoConfRet.UnitPrcCalcDiv = unPrcInfoConf.UnitPrcCalcDiv;
            unPrcInfoConfRet.RateVal = unPrcInfoConf.RateVal;
            unPrcInfoConfRet.UnPrcFracProcUnit = unPrcInfoConf.UnPrcFracProcUnit;
            unPrcInfoConfRet.UnPrcFracProcDiv = unPrcInfoConf.UnPrcFracProcDiv;
            unPrcInfoConfRet.StdUnitPrice = unPrcInfoConf.StdUnitPrice;
            unPrcInfoConfRet.UnitPriceTaxExcFl = unPrcInfoConf.UnitPriceTaxExcFl;
            unPrcInfoConfRet.UnitPriceTaxIncFl= unPrcInfoConf.UnitPriceTaxIncFl;

			return unPrcInfoConfRet;
		}


		#endregion

		#region ■Static Methods
		/// <summary>
		/// 日付文字列を取得します。
		/// </summary>
		/// <param name="date">日付</param>
		/// <param name="format">フォーマット文字列</param>
		/// <returns>日付文字列</returns>
		private static string GetDateTimeString( DateTime date, string format )
		{
			if (date == DateTime.MinValue)
			{
				return "";
			}
			else
			{
				return date.ToString(format);
			}
		}
		/// <summary>
		/// 端数処理区分名称を取得します。
		/// </summary>
		/// <param name="fracProcDiv">端数処理区分</param>
		/// <returns>端数処理区分名称</returns>
		private static string GetFracProcDivName( int fracProcDiv )
		{
			switch (fracProcDiv)
			{
				case 1:
					return "切捨て";
				case 2:
					return "四捨五入";
				case 3:
					return "切上";
				default:
					return "";
			}
		}

		#region 掛率設定区分からの各項目設定取得
		/// <summary>
		/// 掛率設定区分より掛率設定区分(商品)を取得します。
		/// </summary>
		/// <param name="rateDiv">掛率設定区分</param>
		/// <returns>掛率設定区分(商品)</returns>
		private static string GetRateMngGoodsCd( string rateDiv )
		{
			return ( rateDiv.Length > 0 ) ? rateDiv.Substring(0, 1) : "";
		}

		/// <summary>
		/// 掛率設定区分より掛率設定区分(得意先)を取得します。
		/// </summary>
		/// <param name="rateDiv">掛率設定区分</param>
		/// <returns>掛率設定区分(得意先)</returns>
		private static string GetRateMngCustCd( string rateDiv )
		{
			return ( rateDiv.Length > 1 ) ? rateDiv.Substring(1, 1) : "";
		}

		/// <summary>
		/// 掛率設定区分名称取得
		/// </summary>
		/// <param name="rateDiv">掛率設定区分</param>
		/// <returns>掛率設定区分名称</returns>
		public static string GetRateDivName( string rateDiv )
		{
            string retString = "";

            DataRow[] dr = _rateMngTable.Select(string.Format("{0}='{1}'", RateMngGoodsCust.RATESETTINGDIVIDE, rateDiv));

            if (( dr != null ) && ( dr.Length > 0 ))
            {
                //retString = string.Format("{0}＋{1}", dr[0][RateMngGoodsCust.RATEMNGGOODSNM], dr[0][RateMngGoodsCust.RATEMNGCUSTNM]);//DEL 2013/04/12 xujx 価格ガイドの修正
                retString = string.Format("{0}＋{1}", dr[0][RateMngGoodsCust.RATEMNGCUSTNM], dr[0][RateMngGoodsCust.RATEMNGGOODSNM]);//ADD 2013/04/12 xujx 価格ガイドの修正
            }

			return retString;
		}

		/// <summary>
		/// 対象文字列中に、比較対象リストに含まれる文字列が存在するかを取得します。
		/// </summary>
		/// <param name="target">対象文字列</param>
		/// <param name="startIndex">文字列中の比較文字開始位置</param>
		/// <param name="length">比較文字列の長さ</param>
		/// <param name="judgmentList">比較対象リスト</param>
		/// <returns>true:存在する</returns>
		private static bool IsSetting( string target, int startIndex, int length, List<string> judgmentList )
		{
			bool ret = false;
			if (target.Length >= ( startIndex + length ))
			{
				if (judgmentList.Contains(target.Substring(startIndex, length))) ret = true;
			}
			return ret;
		}


		/// <summary>
		/// 単価情報確認オブジェクトより掛率マスタオブジェクトを生成します。
		/// </summary>
		/// <param name="unitPriceInfoConf"></param>
		/// <returns></returns>
		private static Rate CreateRateFromUnitPriceInfoConf( UnPrcInfoConf unitPriceInfoConf )
		{
			Rate rate = new Rate();

			rate.RateSettingDivide = unitPriceInfoConf.RateSettingDivide;
			rate.SectionCode = unitPriceInfoConf.SectionCode;
			rate.RateMngGoodsCd = GetRateMngGoodsCd(unitPriceInfoConf.RateSettingDivide);
			rate.RateMngCustCd = GetRateMngCustCd(unitPriceInfoConf.RateSettingDivide);
            rate.GoodsNo = RateAcs.IsGoodsNoSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.GoodsNo : "";
            rate.GoodsMakerCd = RateAcs.IsMakerSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.GoodsMakerCd : 0;
            rate.GoodsRateRank = RateAcs.IsGoodsRateRankSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.GoodsRateRank : "";
            rate.GoodsRateGrpCode = RateAcs.IsGoodsRateGrpCodeSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.GoodsRateGrpCode : 0;
            rate.BLGroupCode = RateAcs.IsBLGroupCodeSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.BLGroupCode : 0;
            rate.BLGoodsCode = RateAcs.IsBLGoodsSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.BLGoodsCode : 0;
            rate.CustomerCode = RateAcs.IsCustomerSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.CustomerCode : 0;
            rate.CustRateGrpCode = RateAcs.IsCustRateGrpSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.CustRateGrpCode : 0;
            rate.SupplierCd = RateAcs.IsSupplierSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.SupplierCd : 0;

			return rate;

		}
		#endregion

		#endregion
	}
}
