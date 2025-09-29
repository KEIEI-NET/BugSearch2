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
using Broadleaf.Application.Controller;
using Broadleaf.Library;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 単価算出クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 掛率に従って売上単価、仕入単価、定価の算出を行います。</br>
	/// <br>Programmer	: 21024　佐々木 健</br>
	/// <br>Date		: 2008.06.19</br>
    /// <br></br>
    /// <br>UpdateNote : 2009.06.16  22018 鈴木 正臣</br>
    /// <br>           : 得意先掛率グループ=0000の設定に対応。</br>
    /// <br>UpdateNote : 2010/03/01 李占川 PM.NS保守依頼５次改良対応</br>
    /// <br>             単価モジュールの掛率優先管理マスタキャッシュ処理を使用するように変更</br>
    /// <br>UpdateNote : 2010/06/02 張凱 PM.NS障害・改良対応（７月リリース案件）No.4</br>
    /// <br>             定価や掛率を変更しても売価、原価が正しく再計算されないに改修</br>
    /// <br>UpdateNote : 2010/12/02 20056 對馬 大輔 </br>
    /// <br>           : 定価算出時の端数処理単位、端数処理区分を売単価の単位と区分を参照しないように変更</br>
    /// <br>UpdateNote : 2011/02/16 22018 鈴木 正臣</br>
    /// <br>           : 結果クラスにロット範囲の開始/終了を追加(エントリで使用)</br>
    /// <br>UpdateNote : 2011/07/20 wangf</br>
    /// <br>           : 優先案件連番16対応  掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）</br>
    /// <br>Update Note: 2011/09/01 連番681 徐錦山 10704766-00 </br>
    /// <br>             元定価が表示のを追加</br>
    /// <br>Update Note: 2011/11/22 yangmj</br>
    /// <br>             redmine #7729 BLコード検索結果で原価がゼロになるの変更 </br>
    /// <br>Update Note: 2013/05/30 huangt</br>
    /// <br>             PM-TAB対応 </br>
    /// <br>Update Note: 2014/02/05 吉岡</br>
    /// <br>             仕掛一覧№10631 自動回答速度改善 掛率マスタキャッシュ</br>
    /// <br>Update Note: K2014/02/09 yangyi</br>
    /// <br>管理番号   : 10970681-00 前橋京和商会個別個別対応</br>
    /// <br>           : 売上伝票入力の改良対応</br>
    /// </remarks>
	public class UnitPriceCalculation
	{
        // ===================================================================================== //
        // パブリック変数
        // ===================================================================================== //
        #region ■Public Members

		/// <summary>単価種類（売上単価）</summary>
		public const string ctUnitPriceKind_SalesUnitPrice = "1";
		/// <summary>単価種類（原価設定）</summary>
		public const string ctUnitPriceKind_UnitCost = "2";
		/// <summary>単価種類（価格設定）</summary>
		public const string ctUnitPriceKind_ListPrice = "3";
		///// <summary>単価種類（作業原価）</summary>
		//public const string ctUnitPriceKind_WorkCost = "4";
		///// <summary>単価種類（作業売価）</summary>
		//public const string ctUnitPriceKind_WorkSalesUnitPrice = "5";

		#endregion

        // 2011/07/20 add wangf start
        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ■ Public Property
        /// <summary> 拠点優先プロパティ </summary>
        public int RatePriorityDiv
        {
            get { return this._ratePriorityDiv; }
            set { this._ratePriorityDiv = value; }
        }
        #endregion
        // 2011/07/20 add wangf end

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members

		private List<SalesProcMoney> _salesProcMoneyList;										// 売上金額処理区分設定リスト
		private List<StockProcMoney> _stockProcMoneyList;										// 仕入金額処理区分設定リスト
		private string _enterpriseCode;

		private const int ctAllSet = 1000;														// 全社設定との境目

        // --- UPD 2010/03/01 ---------->>>>>
        //private static List<RateProtyMng> _rateProtyMngAllList = null;                          // 掛率優先順位情報リスト（全情報）
        private List<RateProtyMng> _rateProtyMngAllList = null;                                 // 掛率優先順位情報リスト（全情報）
        // --- UPD 2010/03/01 ----------<<<<<
        private List<RateProtyMng> _lastRateProtyMngList = null;                                // 掛率優先順位情報リスト（最後に掛率優先順位を取得した情報のキャッシュ）
        private string _lastSectionCode = string.Empty;                                         // 最後に掛率優先順位を取得した拠点コード
        private UnitPriceKind _lastUnitPriceKind;                                               // 最後に掛率優先順位を取得した単価種類
        // 2011/07/20 add wangf start
        private int _ratePriorityDiv = 0;                                                       // 拠点優先
        // 2011/07/20 add wangf end

        // ADD 2014/02/05 №10631 吉岡 掛率マスタキャッシュ ------->>>>>>>>>>>>>>>>>>>
        /// <summary> 検索済み掛率マスタキャッシュ ＤＢ登録有り </summary>
        private List<Rate> _rateMstList;
        /// <summary> 検索済み掛率マスタキャッシュ ＤＢ登録無し </summary>
        private List<Rate> _rateMstListNotFound;
        /// <summary> 検索済み掛率マスタキャッシュフラグ </summary>
        private bool rateCache;
        // ADD 2014/02/05 №10631 吉岡 掛率マスタキャッシュ -------<<<<<<<<<<<<<<<<<<<
		# endregion

        // ===================================================================================== //
        // 列挙型
        // ===================================================================================== //
        #region ■Enums

		/// <summary>
		/// 単価種類列挙型
		/// </summary>
		public enum UnitPriceKind : int
		{
			/// <summary>売上単価</summary>
			SalesUnitPrice = 1,
			/// <summary>原価単価</summary>
			UnitCost = 2,
			/// <summary>定価</summary>
			ListPrice = 3
			///// <summary>作業原価</summary>
			//WorkCost = 4,
			///// <summary>作業売価</summary>
			//WorkSalesUnitPrice = 5
		}

		/// <summary>
		/// 単価算出方法
		/// </summary>
		public enum UnitPrcCalcDiv
		{
			/// <summary>単価直接指定</summary>
			Price = 0,
			/// <summary>掛率</summary>
			RateVal = 1,
			/// <summary>UP率</summary>
			UpRate = 2,
			/// <summary>粗利率</summary>
			GrsProfitSecureRate = 3,
		}
		#endregion

        // ===================================================================================== //
        // 構造体
        // ===================================================================================== //
        #region ■Struct

        # region [掛率マスタの検索条件]
        /// <summary>
        /// 掛率マスタの検索条件
        /// </summary>
        private struct RateSeachConf
        {
            /// <summary>拠点コード</summary>
            private string _sectionCode;
            /// <summary>単価掛率設定区分</summary>
            private string _unitRateSetDivCd;
            /// <summary>商品メーカーコード</summary>
            private int _goodsMakerCd;
            /// <summary>商品番号</summary>
            private string _goodsNo;
            /// <summary>商品掛率ランク</summary>
            private string _goodsRateRank;
            /// <summary>商品掛率グループコード</summary>
            private int _goodsRateGrpCode;
            /// <summary>BLグループコード</summary>
            private int _bLGroupCode;
            /// <summary>BL商品コード</summary>
            private int _bLGoodsCode;
            /// <summary>得意先コード</summary>
            private int _customerCode;
            /// <summary>得意先掛率グループコード</summary>
            private int _custRateGrpCode;
            /// <summary>仕入先コード</summary>
            private int _supplierCd;
            /// <summary>
            /// 拠点コード
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>
            /// 単価掛率設定区分
            /// </summary>
            public string UnitRateSetDivCd
            {
                get { return _unitRateSetDivCd; }
                set { _unitRateSetDivCd = value; }
            }
            /// <summary>
            /// 商品メーカーコード
            /// </summary>
            public int GoodsMakerCd
            {
                get { return _goodsMakerCd; }
                set { _goodsMakerCd = value; }
            }
            /// <summary>
            /// 商品番号
            /// </summary>
            public string GoodsNo
            {
                get { return _goodsNo; }
                set { _goodsNo = value; }
            }
            /// <summary>
            /// 商品掛率ランク
            /// </summary>
            public string GoodsRateRank
            {
                get { return _goodsRateRank; }
                set { _goodsRateRank = value; }
            }
            /// <summary>
            /// 商品掛率グループコード
            /// </summary>
            public int GoodsRateGrpCode
            {
                get { return _goodsRateGrpCode; }
                set { _goodsRateGrpCode = value; }
            }
            /// <summary>
            /// BLグループコード
            /// </summary>
            public int BLGroupCode
            {
                get { return _bLGroupCode; }
                set { _bLGroupCode = value; }
            }
            /// <summary>
            /// BL商品コード
            /// </summary>
            public int BLGoodsCode
            {
                get { return _bLGoodsCode; }
                set { _bLGoodsCode = value; }
            }
            /// <summary>
            /// 得意先コード
            /// </summary>
            public int CustomerCode
            {
                get { return _customerCode; }
                set { _customerCode = value; }
            }
            /// <summary>
            /// 得意先掛率グループコード
            /// </summary>
            public int CustRateGrpCode
            {
                get { return _custRateGrpCode; }
                set { _custRateGrpCode = value; }
            }
            /// <summary>
            /// 仕入先コード
            /// </summary>
            public int SupplierCd
            {
                get { return _supplierCd; }
                set { _supplierCd = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="sectionCode">拠点コード</param>
            /// <param name="unitRateSetDivCd">単価掛率設定区分</param>
            /// <param name="goodsMakerCd">商品メーカーコード</param>
            /// <param name="goodsNo">商品番号</param>
            /// <param name="goodsRateRank">商品掛率ランク</param>
            /// <param name="goodsRateGrpCode">商品掛率グループコード</param>
            /// <param name="bLGroupCode">BLグループコード</param>
            /// <param name="bLGoodsCode">BL商品コード</param>
            /// <param name="customerCode">得意先コード</param>
            /// <param name="custRateGrpCode">得意先掛率グループコード</param>
            /// <param name="supplierCd">仕入先コード</param>
            public RateSeachConf(string sectionCode, string unitRateSetDivCd, int goodsMakerCd, string goodsNo, string goodsRateRank, int goodsRateGrpCode, int bLGroupCode, int bLGoodsCode, int customerCode, int custRateGrpCode, int supplierCd)
            {
                _sectionCode = sectionCode;
                _unitRateSetDivCd = unitRateSetDivCd;
                _goodsMakerCd = goodsMakerCd;
                _goodsNo = goodsNo;
                _goodsRateRank = goodsRateRank;
                _goodsRateGrpCode = goodsRateGrpCode;
                _bLGroupCode = bLGroupCode;
                _bLGoodsCode = bLGoodsCode;
                _customerCode = customerCode;
                _custRateGrpCode = custRateGrpCode;
                _supplierCd = supplierCd;
            }
        }
        # endregion

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constracter

		/// <summary>
		/// 単価算出クラス コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Programmer : 21024　佐々木 健</br>
		/// <br>Date       : 2007.11.12</br>
		/// </remarks>
		public UnitPriceCalculation()
		{
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ADD 2014/02/05 №10631 吉岡 掛率マスタキャッシュ ------->>>>>>>>>>>>>>>>>>>
            _rateMstList = new List<Rate>();
            _rateMstListNotFound = new List<Rate>();
            rateCache = false;
            // ADD 2014/02/05 №10631 吉岡 掛率マスタキャッシュ -------<<<<<<<<<<<<<<<<<<<
		}

		/// <summary>
		/// 単価算出クラス コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Programmer : 21024　佐々木 健</br>
		/// <br>Date       : 2007.11.12</br>
		/// </remarks>
		public UnitPriceCalculation( List<SalesProcMoney> salesProcMoneyList, List<StockProcMoney> stockProcMoneyList )
		{
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			this.CacheSalesProcMoneyList(salesProcMoneyList);
			this.CacheStockProcMoneyList(stockProcMoneyList);
		}

		# endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region■Public Methods

		#region マスタキャッシュ

		/// <summary>
		/// 仕入金額端数処理区分設定マスタを単価算出クラス内にキャッシュします。
		/// </summary>
        /// <param name="stockProcMoneyList">仕入金額処理区分設定マスタリスト</param>
        public void CacheStockProcMoneyList( List<StockProcMoney> stockProcMoneyList )
		{
			this._stockProcMoneyList = stockProcMoneyList;

            this._stockProcMoneyList.Sort(new DCKHN01060CF.StockProcMoneyComparer());
		}

		/// <summary>
        /// 売上金額端数処理区分設定マスタを単価算出クラス内にキャッシュします。
		/// </summary>
		/// <param name="salesProcMoneyList">売上金額処理区分設定マスタリスト</param>
        public void CacheSalesProcMoneyList( List<SalesProcMoney> salesProcMoneyList )
		{
			this._salesProcMoneyList = salesProcMoneyList;

            this._salesProcMoneyList.Sort(new DCKHN01060CF.SalesProcMoneyComparer());
		}

        // --- ADD 2010/03/01 ---------->>>>>
        /// <summary>
        /// 掛率優先管理マスタを単価算出クラス内にキャッシュします。
        /// </summary>
        /// <param name="rateProtyMngAllList">掛率優先管理マスタリスト</param>
        public void CacheRateProtyMngAllList(List<RateProtyMng> rateProtyMngAllList)
        {
            this._rateProtyMngAllList = rateProtyMngAllList;

            this._rateProtyMngAllList.Sort(new DCKHN01060CF.RateProtyMngComparer());
        }
        // --- ADD 2010/03/01 ----------<<<<<
		#endregion

		#region 原価単価計算処理
		/// <summary>
		/// 掛率を使用して原価単価を算出します。
		/// </summary>
		/// <param name="unitPriceCalcParam">単価計算パラメータオブジェクト</param>
		/// <param name="goodsUnitData">商品連結データオブジェクト</param>
		/// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
		public void CalculateUnitCost( UnitPriceCalcParam unitPriceCalcParam, GoodsUnitData goodsUnitData, out List<UnitPriceCalcRet> unitPriceCalcRetList )
		{
            unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            this.CalculateUnitPriceProc(UnitPriceKind.UnitCost, unitPriceCalcParam, goodsUnitData, ref unitPriceCalcRetList);
		}

        /// <summary>
        /// 掛率を使用して原価単価を算出します。
        /// </summary>
        /// <param name="unitPriceCalcParamList">単価計算パラメータオブジェクトリスト</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        public void CalculateUnitCost( List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList )
        {
            unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            this.CalculateUnitPriceProc(UnitPriceKind.UnitCost, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
        }

		#endregion

		#region 定価計算処理
		/// <summary>
        /// 掛率を使用して定価を算出します。
		/// </summary>
		/// <param name="unitPriceCalcParam">単価計算パラメータオブジェクト</param>
		/// <param name="goodsUnitData">商品連結データオブジェクト</param>
		/// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
		public void CalculateListPrice( UnitPriceCalcParam unitPriceCalcParam, GoodsUnitData goodsUnitData, out List<UnitPriceCalcRet> unitPriceCalcRetList )
		{
			unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            this.CalculateUnitPriceProc(UnitPriceKind.ListPrice, unitPriceCalcParam, goodsUnitData, ref unitPriceCalcRetList);
		}

		/// <summary>
        /// 掛率を使用して定価を算出します。
		/// </summary>
		/// <param name="unitPriceCalcParamList">単価計算パラメータオブジェクトリスト</param>
		/// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
		/// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
		public void CalculateListPrice( List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList )
		{
			unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            this.CalculateUnitPriceProc(UnitPriceKind.ListPrice, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
		}

		#endregion

		#region 売価単価計算処理
		/// <summary>
        /// 掛率を使用して売上単価を算出します。
		/// </summary>
		/// <param name="unitPriceCalcParam">単価計算パラメータオブジェクト</param>
		/// <param name="goodsUnitData">商品連結データオブジェクト</param>
		/// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
		/// <remarks>
		///		Note	: 原価UP率,粗利率指定時は、原価単価も自動算出します。
		/// </remarks>
		public void CalculateSalesUnitPrice( UnitPriceCalcParam unitPriceCalcParam, GoodsUnitData goodsUnitData, out List<UnitPriceCalcRet> unitPriceCalcRetList )
		{
			unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            this.CalculateUnitPriceProc(UnitPriceKind.SalesUnitPrice, unitPriceCalcParam, goodsUnitData, ref unitPriceCalcRetList);
		}
        
        /// <summary>
        /// 掛率を使用して売上単価を算出します。
		/// </summary>
		/// <param name="unitPriceCalcParamList">単価計算パラメータオブジェクトリスト</param>
		/// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
		/// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
		/// <remarks>
		///		Note	: 原価UP率,粗利率指定時は、原価単価も自動算出します。
		/// </remarks>
		public void CalculateSalesUnitPrice( List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList )
		{
			unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(UnitPriceKind.SalesUnitPrice);

            this.CalculateUnitPriceProc(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);

		}	
        #endregion

		#region 売上関係の一括計算

		/// <summary>
        /// 掛率を使用して定価、売上原価単価、売上単価を算出します。
		/// </summary>
		/// <param name="unitPriceCalcParam">単価計算パラメータオブジェクト</param>
		/// <param name="goodsUnitData">商品連結データオブジェクト</param>
		/// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
		/// <remarks>
		///		Note	: 原価UP率,粗利確保率指定時は、原価単価も自動算出します。
		/// </remarks>
		public void CalculateSalesRelevanceUnitPrice( UnitPriceCalcParam unitPriceCalcParam, GoodsUnitData goodsUnitData, out List<UnitPriceCalcRet> unitPriceCalcRetList )
		{
			unitPriceCalcRetList = new List<UnitPriceCalcRet>();

			List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
			unitPriceKindList.Add(UnitPriceKind.ListPrice);
			unitPriceKindList.Add(UnitPriceKind.UnitCost);
			unitPriceKindList.Add(UnitPriceKind.SalesUnitPrice);

			this.CalculateUnitPriceProc(unitPriceKindList, unitPriceCalcParam, goodsUnitData, ref unitPriceCalcRetList);
		}

        /// <summary>
        /// 掛率を使用して定価、売上原価単価、売上単価を算出します。
        /// </summary>
        /// <param name="unitPriceCalcParamList">単価計算パラメータオブジェクトリスト</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <remarks>
        ///		Note	: 原価UP率,粗利確保率指定時は、原価単価も自動算出します。
        /// </remarks>
        public void CalculateSalesRelevanceUnitPrice( List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList )
        {
            unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(UnitPriceKind.ListPrice);
            unitPriceKindList.Add(UnitPriceKind.UnitCost);
            unitPriceKindList.Add(UnitPriceKind.SalesUnitPrice);

            this.CalculateUnitPriceProc(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
        }

        // ADD 2014/02/05 №10631 吉岡 掛率マスタキャッシュ ------->>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 掛率を使用して定価、売上原価単価、売上単価を算出します。
        /// 掛率マスタをキャッシュします。
        /// </summary>
        /// <param name="unitPriceCalcParam">単価計算パラメータオブジェクト</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <remarks>
        ///		Note	: 原価UP率,粗利確保率指定時は、原価単価も自動算出します。
        /// </remarks>
        public void CalculateSalesRelevanceUnitPriceRateCache(UnitPriceCalcParam unitPriceCalcParam, GoodsUnitData goodsUnitData, out List<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            this.rateCache = true;
            this.CalculateSalesRelevanceUnitPrice(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);
        }

        /// <summary>
        /// 掛率を使用して定価、売上原価単価、売上単価を算出します。
        /// 掛率マスタをキャッシュします。
        /// </summary>
        /// <param name="unitPriceCalcParamList">単価計算パラメータオブジェクトリスト</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <remarks>
        ///		Note	: 原価UP率,粗利確保率指定時は、原価単価も自動算出します。
        /// </remarks>
        public void CalculateSalesRelevanceUnitPriceRateCache(List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            this.rateCache = true;
            this.CalculateSalesRelevanceUnitPrice(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);
        }
        // ADD 2014/02/05 №10631 吉岡 掛率マスタキャッシュ -------<<<<<<<<<<<<<<<<<<<

        // --- ADD huangt 2013/05/30 PM-TAB対応 ---------- >>>>>
        /// <summary>
        /// 掛率を使用して定価、売上原価単価、売上単価を算出します。
        /// </summary>
        /// <param name="unitPriceCalcParamList">単価計算パラメータオブジェクトリスト</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <param name="rateList">掛率マスタリスト</param>
        /// <remarks>
        ///		Note	: 原価UP率,粗利確保率指定時は、原価単価も自動算出します。
        /// </remarks>
        public void CalculateSalesRelevanceUnitPriceForTablet(List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList, out List<Rate> rateList)
        {
            unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            rateList = new List<Rate>();

            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(UnitPriceKind.ListPrice);
            unitPriceKindList.Add(UnitPriceKind.UnitCost);
            unitPriceKindList.Add(UnitPriceKind.SalesUnitPrice);

            this.CalculateUnitPriceForTabletProc(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList, ref rateList);
        }
        // --- ADD huangt 2013/05/30 PM-TAB対応 ---------- <<<<<

        #endregion

		#region 率、粗利率による単価計算

		/// <summary>
		/// 基準単価から掛率を使用して単価を算出します。
		/// </summary>
		/// <param name="unitPriceKind">単価種類</param>
		/// <param name="unitPrcCalcDiv">計算方法</param>
		/// <param name="totalAmountDispWayCd">総額表示区分</param>
		/// <param name="ttlAmntDspRateDivCd">掛率適用区分</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="taxationCode">課税区分</param>
		/// <param name="stdPrice">基準単価（外税品：税抜き単価、内税品：税込み単価）</param>
		/// <param name="taxRate">税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
		/// <param name="rate">掛率</param>
		/// <param name="fracProcUnit">端数処理単位（未設定時は金額処理区分設定マスタから取得）</param>
		/// <param name="fracProcCd">端数処理区分（未設定時は金額処理区分設定マスタから取得）</param>
		/// <param name="unitPriceTaxExc">単価（税抜き）</param>
		/// <param name="unitPriceTaxInc">単価（税込み）</param>
		public void CalculateUnitPriceByRate( UnitPriceKind unitPriceKind, UnitPrcCalcDiv unitPrcCalcDiv, int totalAmountDispWayCd, int ttlAmntDspRateDivCd, int fractionProcCode, int taxationCode, double stdPrice, double taxRate, double taxFracProcUnit, int taxFracProcCd, double rate, ref  double fracProcUnit, ref int fracProcCd, out double unitPriceTaxExc, out double unitPriceTaxInc )
		{
			double stdPriceWk = stdPrice;
			int taxationCodeWk = taxationCode;

			// 基準単価×掛率の場合は、基準単価を補正する
			if (( unitPrcCalcDiv == UnitPrcCalcDiv.RateVal ))
			{
				if (( totalAmountDispWayCd == 1 ) &&		// 総額表示する
					( ttlAmntDspRateDivCd == 0 ) &&			// 掛率適用区分「0：税込単価」
					( taxationCode == 0 ))					// 外税品
				{
					// 税込単価を基準とし、内税と同じ計算を行う
					stdPriceWk += CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, stdPrice);
					taxationCodeWk = 2;
				}
			}

            this.CalculateUnitPriceByRate(unitPriceKind, fractionProcCode, taxationCodeWk, stdPriceWk, taxRate, taxFracProcUnit, taxFracProcCd, rate, ref fracProcUnit, ref fracProcCd, out unitPriceTaxExc, out unitPriceTaxInc);
		}

		/// <summary>
		/// 基準単価から粗利率を使用して単価を算出します。
		/// </summary>
		/// <param name="unitPriceKind">単価種類</param>
		/// <param name="totalAmountDispWayCd">総額表示区分</param>
		/// <param name="ttlAmntDspRateDivCd">掛率適用区分</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="taxationCode">課税区分</param>
		/// <param name="costPrice">原価単価（外税品：税抜き単価、内税品：税込み単価）</param>
		/// <param name="taxRate">税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
		/// <param name="marginRate">粗利率</param>
		/// <param name="fracProcUnit">端数処理単位（未設定時は金額処理区分設定マスタから取得）</param>
		/// <param name="fracProcCd">端数処理区分（未設定時は金額処理区分設定マスタから取得）</param>
		/// <param name="unitPriceTaxExc">単価（税抜き）</param>
		/// <param name="unitPriceTaxInc">単価（税込み）</param>
		public void CalculateUnitPriceByMarginRate( UnitPriceKind unitPriceKind, int totalAmountDispWayCd, int ttlAmntDspRateDivCd, int fractionProcCode, int taxationCode, double costPrice, double taxRate, double taxFracProcUnit, int taxFracProcCd, double marginRate, ref double fracProcUnit, ref int fracProcCd, out double unitPriceTaxExc, out double unitPriceTaxInc )
		{
			double costPriceWk = costPrice;
			int taxationCodeWk = taxationCode;

			//if (( totalAmountDispWayCd == 1 ) &&		// 総額表示する
			//    ( ttlAmntDspRateDivCd == 0 ) &&			// 掛率適用区分「0：税込単価」
			//    ( taxationCode == 0 ))					// 外税品
			//{
			//    // 税込単価を基準とし、内税と同じ計算を行う
			//    costPriceWk += CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, costPrice);
			//    taxationCodeWk = 2;
			//}

			this.CalculateUnitPriceByMarginRate(unitPriceKind, fractionProcCode, taxationCodeWk, costPriceWk, taxRate, taxFracProcUnit, taxFracProcCd, marginRate, ref fracProcUnit, ref fractionProcCode, out unitPriceTaxExc, out unitPriceTaxInc);
		}

		#endregion

		#endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods

        /// <summary>
        /// 単価計算処理
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="unitPriceCalcParam">単価計算パラメータ</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        private void CalculateUnitPriceProc( UnitPriceKind unitPriceKind, UnitPriceCalcParam unitPriceCalcParam, GoodsUnitData goodsUnitData, ref List<UnitPriceCalcRet> unitPriceCalcRetList )
        {
            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(unitPriceKind);

            this.CalculateUnitPriceProc(unitPriceKindList, unitPriceCalcParam, goodsUnitData, ref unitPriceCalcRetList);
        }

		/// <summary>
        /// 単価計算処理
		/// </summary>
		/// <param name="unitPriceKindList">単価種類リスト</param>
		/// <param name="unitPriceCalcParam">単価計算パラメータ</param>
		/// <param name="goodsUnitData">商品連結データオブジェクト</param>
		/// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
		private void CalculateUnitPriceProc( List<UnitPriceKind> unitPriceKindList, UnitPriceCalcParam unitPriceCalcParam, GoodsUnitData goodsUnitData, ref List<UnitPriceCalcRet> unitPriceCalcRetList )
		{
			// 価格リストが無い場合は処理しない
			if (( goodsUnitData == null ) || ( goodsUnitData.GoodsNo != unitPriceCalcParam.GoodsNo ) || ( goodsUnitData.GoodsMakerCd != unitPriceCalcParam.GoodsMakerCd ))
			{
				return;
			}
			List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
			unitPriceCalcParamList.Add(unitPriceCalcParam);
			List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();

			goodsUnitDataList.Add(goodsUnitData);
			this.CalculateUnitPriceProc(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
		}

        /// <summary>
        /// 単価計算処理
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="unitPriceCalcParamList">単価計算パラメータリスト</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        private void CalculateUnitPriceProc( UnitPriceKind unitPriceKind, List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, ref List<UnitPriceCalcRet> unitPriceCalcRetList )
        {
            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(unitPriceKind);
            this.CalculateUnitPriceProc(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
        }

		/// <summary>
        /// 単価計算処理
		/// </summary>
		/// <param name="unitPriceKindList">単価種類リスト</param>
		/// <param name="unitPriceCalcParamList">単価計算パラメータリスト</param>
		/// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
		/// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
		private void CalculateUnitPriceProc( List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, ref List<UnitPriceCalcRet> unitPriceCalcRetList )
		{
            LogWrite(string.Format("単価算出 開始 {0}件:", unitPriceCalcParamList.Count));

            // パラメータリスト、商品連結データオブジェクトリストが無ければ処理しない
			if (( unitPriceCalcParamList == null ) || ( unitPriceCalcParamList.Count == 0 ) || ( goodsUnitDataList == null ) || ( goodsUnitDataList.Count == 0 ))
			{
				return;
            }

            LogWrite("掛率読み込み");

            // 掛率マスタの読み込み
            List<Rate> rateList;

            // UPD 2014/02/05 №10631 吉岡 掛率マスタキャッシュ ------->>>>>>>>>>>>>>>>>>>
            // int status = this.SearchRate(unitPriceKindList, unitPriceCalcParamList, out rateList);
            int status;
            if (rateCache)
            {
                status = this.SearchRateCache(unitPriceKindList, unitPriceCalcParamList, out rateList);
            }
            else
            {
                status = this.SearchRate(unitPriceKindList, unitPriceCalcParamList, out rateList);
            }
            // UPD 2014/02/05 №10631 吉岡 掛率マスタキャッシュ -------<<<<<<<<<<<<<<<<<<<

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                rateList = null;
            }
            else
            {
                LogWrite(string.Format("掛率 {0}件取得", rateList.Count));
            }

            LogWrite("原価計算");

            // 原価計算処理
            if (unitPriceKindList.Contains(UnitPriceKind.UnitCost))
            {
                this.CalculateUnitCostPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, ref unitPriceCalcRetList);

            }

            LogWrite("定価計算");

            // 定価計算処理
            if (unitPriceKindList.Contains(UnitPriceKind.ListPrice))
            {
                this.CalculateListPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, ref unitPriceCalcRetList);
            }

            LogWrite("売価計算");

            // 売価計算処理
            if (unitPriceKindList.Contains(UnitPriceKind.SalesUnitPrice))
            {
                this.CalculateSalesUnitPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, ref unitPriceCalcRetList);
            }

            LogWrite("単価算出 終了");
        }

		/// <summary>
		/// 売単価計算処理
		/// </summary>
		/// <param name="unitPriceCalcParamList">単価算出パラメータリスト</param>
		/// <param name="goodsUnitDataList">商品構成データリスト</param>
        /// <param name="rateList">掛率マスタリスト</param>
		/// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        private void CalculateSalesUnitPriceProc(List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, List<Rate> rateList, ref List<UnitPriceCalcRet> unitPriceCalcRetList)
		{
            List<RateProtyMng> rateProtyMngList = null;
        
			foreach (UnitPriceCalcParam unitPriceCalcParam in unitPriceCalcParamList)
			{
                GoodsUnitData goodsUnitData = SearchGoodsUnitData(goodsUnitDataList, unitPriceCalcParam);

				// 掛率優先管理情報を取得する
                rateProtyMngList = this.GetRateProtyMngList(unitPriceCalcParam.SectionCode, UnitPriceKind.SalesUnitPrice);

                if (rateProtyMngList != null && rateProtyMngList.Count > 0)
                {
                    this.CalculateUnitPriceByRateList(UnitPriceKind.SalesUnitPrice, unitPriceCalcParam, rateProtyMngList, rateList, goodsUnitData, ref unitPriceCalcRetList);
                }
			}
		}

		/// <summary>
		/// 原価単価計算処理
		/// </summary>
		/// <param name="unitPriceCalcParamList">単価算出パラメータリスト</param>
		/// <param name="goodsUnitDataList">商品構成データリスト</param>
        /// <param name="rateList">掛率リスト</param>
		/// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <br>Update Note: 2011/09/01 連番681 徐錦山 10704766-00 </br>
        /// <br>             元定価が表示のを追加</br>
        /// <br>Update Note: 2011/11/22 yangmj</br>
        /// <br>             redmine #7729 BLコード検索結果で原価がゼロになるの変更 </br>
        private void CalculateUnitCostPriceProc(List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, List<Rate> rateList, ref List<UnitPriceCalcRet> unitPriceCalcRetList)
		{
            List<RateProtyMng> rateProtyMngList = null;
        
			foreach (UnitPriceCalcParam unitPriceCalcParam in unitPriceCalcParamList)
			{
                // 消費税の端数処理単位、端数処理区分を取得
				double taxFractionProcUnit;
				int taxFractionProcCd;
				this.GetStockFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.StockCnsTaxFrcProcCd, 0, out taxFractionProcUnit, out taxFractionProcCd);

                UnitPrcCalcDiv unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;

				GoodsUnitData goodsUnitData = SearchGoodsUnitData(goodsUnitDataList, unitPriceCalcParam);
				GoodsPrice goodsPrice;
				bool calcPrice = false;
				this.GetPrice(unitPriceCalcParam.PriceApplyDate, goodsUnitData, out goodsPrice);

                // -----ADD 2011/11/22----->>>>>
                GoodsPrice goodsPriceForUnitCost;
                this.GetPriceForUnitCost(unitPriceCalcParam.PriceApplyDate, goodsUnitData, out goodsPriceForUnitCost);
                // -----ADD 2011/11/22-----<<<<<
				if (goodsPrice != null)
				{
					double unitPriceTaxExc = 0;
					double unitPriceTaxInc = 0;
					int fractionProcCode = 0;
					double unPrcFracProcUnit = 0;
					int unPrcFracProcDiv = 0;
					double stdPrice = 0;
					int taxationCode = 0;
                    double stockRate = 0;

                    stdPrice = goodsPrice.ListPrice; //ADD 2011/09/01
					// 原単価が直接セットされている場合
                    //if (goodsPrice.SalesUnitCost != 0)// DEL 2011/11/22
                    if (goodsPriceForUnitCost.SalesUnitCost != 0)// ADD 2011/11/22
                    {
                        calcPrice = true;

                        unitPrcCalcDiv = UnitPrcCalcDiv.Price;

                        // 商品の課税方式に従って分岐
                        switch (goodsUnitData.TaxationDivCd)
                        {
                            case (int)CalculateTax.TaxationCode.TaxInc:
                                //unitPriceTaxInc = goodsPrice.SalesUnitCost;// DEL 2011/11/22
                                unitPriceTaxInc = goodsPriceForUnitCost.SalesUnitCost;// ADD 2011/11/22
                                unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxInc);
                                break;
                            case (int)CalculateTax.TaxationCode.TaxExc:
                                //unitPriceTaxExc = goodsPrice.SalesUnitCost;// DEL 2011/11/22
                                unitPriceTaxExc = goodsPriceForUnitCost.SalesUnitCost;// ADD 2011/11/22
                                unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxExc);
                                break;
                            case (int)CalculateTax.TaxationCode.TaxNone:
                                //unitPriceTaxExc = goodsPrice.SalesUnitCost;// DEL 2011/11/22
                                //unitPriceTaxInc = goodsPrice.SalesUnitCost;// DEL 2011/11/22
                                unitPriceTaxExc = goodsPriceForUnitCost.SalesUnitCost;// ADD 2011/11/22
                                unitPriceTaxInc = goodsPriceForUnitCost.SalesUnitCost;// ADD 2011/11/22
                                break;
                        }
                        // 転嫁方式「非課税」時は、税込単価に税抜き単価をセット
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            unitPriceTaxInc = unitPriceTaxExc;
                        }
                    }
                    // 仕入率がセットされていて、定価がゼロ以外
                    else if (( goodsPrice.StockRate != 0 ) && ( goodsPrice.ListPrice != 0 ))
                    {
                        calcPrice = true;

                        unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;

                        stockRate = goodsPrice.StockRate;

                        stdPrice = goodsPrice.ListPrice;
                        double stdPriceWk = goodsPrice.ListPrice;
                        taxationCode = unitPriceCalcParam.TaxationDivCd;

                        //--------------------------------------------------
                        // 計算用定価の算定
                        //--------------------------------------------------
                        // 転嫁方式「非課税」時は、基準単価を税抜き単価として計算する
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            if (unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                stdPrice -= CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, stdPrice);
                                stdPriceWk = stdPrice;
                            }
                            taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        }

                        fractionProcCode = unitPriceCalcParam.StockUnPrcFrcProcCd;	// 仕入単価端数処理コード

                        this.CalculateUnitPriceByRate(UnitPriceKind.UnitCost,
                            fractionProcCode,
                            taxationCode,
                            stdPriceWk,
                            unitPriceCalcParam.TaxRate,
                            taxFractionProcUnit,
                            taxFractionProcCd,
                            goodsPrice.StockRate,
                            ref unPrcFracProcUnit,
                            ref unPrcFracProcDiv,
                            out unitPriceTaxExc,
                            out unitPriceTaxInc);
                    }

					// ここまでで原価計算された場合は結果をセット
					if (calcPrice)
					{
						UnitPriceCalcRet unitPriceCalcRet = new UnitPriceCalcRet();

                        unitPriceCalcRet.UnitPriceKind = ( (int)UnitPriceKind.UnitCost ).ToString();
                        unitPriceCalcRet.UnitPrcCalcDiv = (int)unitPrcCalcDiv;
						unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;
						unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;
                        unitPriceCalcRet.RateVal = stockRate;
						unitPriceCalcRet.UnPrcFracProcUnit = unPrcFracProcUnit;
						unitPriceCalcRet.UnPrcFracProcDiv = unPrcFracProcDiv;
                        unitPriceCalcRet.StdUnitPrice = stdPrice;
						unitPriceCalcRet.UnitPriceTaxExcFl = unitPriceTaxExc;
						unitPriceCalcRet.UnitPriceTaxIncFl = unitPriceTaxInc;
                        unitPriceCalcRet.PriceStartDate = goodsPrice.PriceStartDate;
                        unitPriceCalcRet.SupplierCd = unitPriceCalcParam.SupplierCd;
                        unitPriceCalcRet.RateUpdateTimeUnit = goodsPrice.UpdateDateTimeAdFormal;  //ADD yangyi K2014/02/09
						unitPriceCalcRetList.Add(unitPriceCalcRet);
					}
					else
					{
                        // 掛率優先管理情報を取得する
                        rateProtyMngList = this.GetRateProtyMngList(unitPriceCalcParam.SectionCode, UnitPriceKind.UnitCost);

                        if (rateProtyMngList != null && rateProtyMngList.Count > 0)
                        {
                            this.CalculateUnitPriceByRateList(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, goodsUnitData, ref unitPriceCalcRetList);
                        }

					}
				}
			}
		}

		/// <summary>
		/// 定価計算処理
		/// </summary>
		/// <param name="unitPriceCalcParamList">単価算出パラメータリスト</param>
		/// <param name="goodsUnitDataList">商品構成データリスト</param>
		/// <param name="rateList">掛率リスト</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        private void CalculateListPriceProc(List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, List<Rate> rateList, ref List<UnitPriceCalcRet> unitPriceCalcRetList)
		{
            List<RateProtyMng> rateProtyMngList = null;
        
			foreach (UnitPriceCalcParam unitPriceCalcParam in unitPriceCalcParamList)
			{
				// 消費税の端数処理単位、端数処理区分を取得
				double taxFractionProcUnit;
				int taxFractionProcCd;
				this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.SalesCnsTaxFrcProcCd, 0, out taxFractionProcUnit, out taxFractionProcCd);

				GoodsUnitData goodsUnitData = SearchGoodsUnitData(goodsUnitDataList, unitPriceCalcParam);
				List<UnitPriceCalcRet> unitPriceCalcRetListWk = new List<UnitPriceCalcRet>();

                // 掛率優先管理情報を取得する
                rateProtyMngList = this.GetRateProtyMngList(unitPriceCalcParam.SectionCode, UnitPriceKind.ListPrice);
                if (rateProtyMngList != null && rateProtyMngList.Count > 0)
                {
                    this.CalculateUnitPriceByRateList(UnitPriceKind.ListPrice, unitPriceCalcParam, rateProtyMngList, rateList, goodsUnitData, ref unitPriceCalcRetListWk);
                }

				UnitPriceCalcRet listPriceCalcRet = null;
				if (( unitPriceCalcRetListWk != null ) && ( unitPriceCalcRetListWk.Count > 0 ))
				{
					listPriceCalcRet = SearchUnitPriceCalcRet(UnitPriceKind.ListPrice, unitPriceCalcRetListWk, unitPriceCalcParam);
				}
				// 掛率からの定価算出に失敗した場合、定価をそのままセットする
				if (listPriceCalcRet == null)
				{
					GoodsPrice goodsPrice;
					this.GetPrice(unitPriceCalcParam.PriceApplyDate, goodsUnitData, out goodsPrice);

					if (goodsPrice != null)
					{
						double unitPriceTaxExc = 0;
						double unitPriceTaxInc = 0;
						double unPrcFracProcUnit = 0;
						int unPrcFracProcDiv = 0;

						// 定価がセットされている場合
						if (goodsPrice.ListPrice != 0)
						{

                            switch (goodsUnitData.TaxationDivCd)
                            {
                                case (int)CalculateTax.TaxationCode.TaxInc:
                                    unitPriceTaxInc = goodsPrice.ListPrice;
                                    unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxInc);
                                    break;
                                case (int)CalculateTax.TaxationCode.TaxExc:
                                    unitPriceTaxExc = goodsPrice.ListPrice;
                                    unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxExc);
                                    break;
                                case (int)CalculateTax.TaxationCode.TaxNone:
                                    unitPriceTaxExc = goodsPrice.ListPrice;
                                    unitPriceTaxInc = goodsPrice.ListPrice;
                                    break;
                            }
                            // 転嫁方式「非課税」時は税抜き単価をセットする
                            if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                            {
                                unitPriceTaxInc = unitPriceTaxExc;
                            }

							listPriceCalcRet = new UnitPriceCalcRet();
                            listPriceCalcRet.UnitPriceKind = ( (int)UnitPriceKind.ListPrice ).ToString();
							listPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;
							listPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;
							listPriceCalcRet.UnPrcFracProcUnit = unPrcFracProcUnit;
							listPriceCalcRet.UnPrcFracProcDiv = unPrcFracProcDiv;
							//listPriceCalcRet.StdUnitPrice = goodsPrice.ListPrice;
                            listPriceCalcRet.StdUnitPrice = 0;
							listPriceCalcRet.OpenPriceDiv = goodsPrice.OpenPriceDiv;
							listPriceCalcRet.UnitPriceTaxExcFl = unitPriceTaxExc;
							listPriceCalcRet.UnitPriceTaxIncFl = unitPriceTaxInc;
                            listPriceCalcRet.PriceStartDate = goodsPrice.PriceStartDate;
                            listPriceCalcRet.SupplierCd = unitPriceCalcParam.SupplierCd;
						}
					}
				}

				if (listPriceCalcRet != null)
				{
					unitPriceCalcRetList.Add(listPriceCalcRet);
				}
			}
		}

		/// <summary>
		/// 掛率優先順位、掛率マスタによる単価計算
		/// </summary>
		/// <param name="unitPriceKind">単価種類</param>
		/// <param name="unitPriceCalcParam">単価計算パラメータ</param>
		/// <param name="rateProtyMngList">掛率優先管理マスタリスト</param>
        /// <param name="rateList">掛率リスト</param>
		/// <param name="goodsUnitData">商品連結データオブジェクト</param>
		/// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        private void CalculateUnitPriceByRateList(UnitPriceKind unitPriceKind, UnitPriceCalcParam unitPriceCalcParam, List<RateProtyMng> rateProtyMngList, List<Rate> rateList, GoodsUnitData goodsUnitData, ref List<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            if (rateList == null || rateList.Count == 0) return;

            // 掛率優先順位順に単価計算する
            try
            {
                foreach (RateProtyMng rateProtyMng in rateProtyMngList)
                {
                    if (this.CalculateUnitPrice(unitPriceKind, unitPriceCalcParam, rateProtyMng.SectionCode, rateProtyMng, rateList, goodsUnitData, ref unitPriceCalcRetList))
                    {
                        break;
                    }
                }
            }
            finally
            {
            }
        }

		/// <summary>
		/// 掛率設定区分に従って単価を算出します。
		/// </summary>
		/// <param name="unitPriceKind">単価種類</param>
		/// <param name="unitPriceCalcParam">単価計算パラメータオブジェクト</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="rateProtyMng">掛率優先管理マスタオブジェクト</param>
        /// <param name="rateList">掛率マスタリスト</param>
		/// <param name="goodsUnitData">商品連結データオブジェクト</param>
		/// <param name="unitPriceCalcRetList">単価算出結果オブジェクトリスト</param>
		/// <returns>True:単価算出成功、False:単価算出失敗</returns>
        private bool CalculateUnitPrice(UnitPriceKind unitPriceKind, UnitPriceCalcParam unitPriceCalcParam, string sectionCode, RateProtyMng rateProtyMng, List<Rate> rateList, GoodsUnitData goodsUnitData, ref List<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            #region [ 対象の掛率マスタを抽出 ]
            Rate rateCndtn = MakeRateFilter(sectionCode, unitPriceKind, unitPriceCalcParam, rateProtyMng.RateSettingDivide);


            List<Rate> findList = rateList.FindAll(delegate(Rate rate2)
                                        {
                                            if (( rate2.UnitPriceKind.Trim() == rateCndtn.UnitPriceKind.Trim() ) &&
                                                ( rate2.RateSettingDivide.Trim() == rateCndtn.RateSettingDivide.Trim() ) &&
                                                ( rate2.GoodsNo == rateCndtn.GoodsNo ) &&
                                                ( rate2.SectionCode.Trim() == rateCndtn.SectionCode.Trim() ) &&
                                                ( rate2.GoodsMakerCd == rateCndtn.GoodsMakerCd ) &&
                                                ( rate2.GoodsRateRank.Trim() == rateCndtn.GoodsRateRank.Trim() ) &&
                                                ( rate2.GoodsRateGrpCode == rateCndtn.GoodsRateGrpCode ) &&
                                                ( rate2.BLGroupCode == rateCndtn.BLGroupCode ) &&
                                                ( rate2.BLGoodsCode == rateCndtn.BLGoodsCode ) &&
                                                ( rate2.CustomerCode == rateCndtn.CustomerCode ) &&
                                                ( rate2.CustRateGrpCode == rateCndtn.CustRateGrpCode ) &&
                                                ( rate2.SupplierCd == rateCndtn.SupplierCd ) &&
                                                ( rate2.LotCount >= rateCndtn.LotCount ))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });

            if (findList == null || findList.Count == 0) return false;

            findList.Sort(new DCKHN01060CF.RateComparer());

            #endregion

            double stdPrice = 0;			// 基準価格
            double stdPriceWk = stdPrice;	// 基準価格（実際の計算用の値）
            double unitPriceTaxExc = 0;		// 税抜き単価
            double unitPriceTaxInc = 0;		// 税込み単価
            int fractionProcCode = 0;		// 端数処理コード(0:全社)
            int taxationCode = unitPriceCalcParam.TaxationDivCd;	// 課税方式
            int openPriceDiv = 0;
            UnitPrcCalcDiv unitPrcCalcDiv = UnitPrcCalcDiv.Price;
            double count = ( unitPriceCalcParam.CountFl == 0 ) ? 1 : Math.Abs(unitPriceCalcParam.CountFl);	// 数量(0の場合は1つで計算、0以外は絶対値)

            //--------------------------------------------------
            // 端数処理コードの決定
            //--------------------------------------------------
            // 定価、売上単価
            if (( unitPriceKind == UnitPriceKind.ListPrice ) || ( unitPriceKind == UnitPriceKind.SalesUnitPrice ))
            {
                fractionProcCode = unitPriceCalcParam.SalesUnPrcFrcProcCd;	// 売上単価端数処理コード
            }
            // 仕入単価
            else if (unitPriceKind == UnitPriceKind.UnitCost)
            {
                fractionProcCode = unitPriceCalcParam.StockUnPrcFrcProcCd;	// 仕入単価端数処理コード
            }

            //--------------------------------------------------
            // 課税方式の決定
            //--------------------------------------------------

            if (( unitPriceCalcParam.ConsTaxLayMethod != 9 ) &&                                 // 転嫁方式「非課税」を除く
                ( unitPriceKind == UnitPriceKind.SalesUnitPrice ) &&                            // 売上単価
                ( unitPriceCalcParam.TotalAmountDispWayCd == 1 ) &&								// 総額表示する
                ( unitPriceCalcParam.TtlAmntDspRateDivCd == 0 ) &&								// 掛率適用区分「0：税込単価」
                ( unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc ))	// 外税
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxInc;	// 内税と同じ計算をする
            }

            // 先頭行のデータが対象データ
            Rate rate = findList[0];

            // --- ADD m.suzuki 2011/02/16 ---------->>>>>
            // 対象データの直前のデータを取得（ロット範囲の開始を取得する為）
            Rate bfRate = null;
            if ( rate != null )
            {
                List<Rate> wkList = rateList.FindAll( delegate( Rate rate0 )
                                            {
                                                if ( (rate0.UnitPriceKind.Trim() == rate.UnitPriceKind.Trim()) &&
                                                    (rate0.RateSettingDivide.Trim() == rate.RateSettingDivide.Trim()) &&
                                                    (rate0.GoodsNo == rate.GoodsNo) &&
                                                    (rate0.SectionCode.Trim() == rate.SectionCode.Trim()) &&
                                                    (rate0.GoodsMakerCd == rate.GoodsMakerCd) &&
                                                    (rate0.GoodsRateRank.Trim() == rate.GoodsRateRank.Trim()) &&
                                                    (rate0.GoodsRateGrpCode == rate.GoodsRateGrpCode) &&
                                                    (rate0.BLGroupCode == rate.BLGroupCode) &&
                                                    (rate0.BLGoodsCode == rate.BLGoodsCode) &&
                                                    (rate0.CustomerCode == rate.CustomerCode) &&
                                                    (rate0.CustRateGrpCode == rate.CustRateGrpCode) &&
                                                    (rate0.SupplierCd == rate.SupplierCd) &&
                                                    (rate0.LotCount < rate.LotCount) )
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    return false;
                                                }
                                            } );
                if ( wkList.Count > 0 )
                {
                    // ヒットした掛率の直前までで、最終行を取得
                    bfRate = wkList[wkList.Count - 1];
                }
            }
            // --- ADD m.suzuki 2011/02/16 ----------<<<<<

            // 掛率マスタの端数処理単位、端数処理区分は定価計算時のみ使用する（0にすると、金額処理区分設定から取得）
            double unPrcFracProcUnit = ( unitPriceKind == UnitPriceKind.ListPrice ) ? rate.UnPrcFracProcUnit : 0;
            int unPrcFracProcDiv = ( unitPriceKind == UnitPriceKind.ListPrice ) ? rate.UnPrcFracProcDiv : 0;

            // 消費税の端数処理単位、端数処理区分
            double taxFractionProcUnit;
            int taxFractionProcCd;

            double rateVal = 0;                 // 掛率

            // 価格情報の取得
            GoodsPrice goodsPrice;
            this.GetPrice(unitPriceCalcParam.PriceApplyDate, goodsUnitData, out goodsPrice);

            if (goodsPrice == null) goodsPrice = new GoodsPrice();

            // 単価種類により処理分岐（単価種類毎の優先順位に従って計算）
            // ※計算方法は同一ですが、仕様変更や追加された場合を考慮して単価種類毎に分けておきます
            switch (unitPriceKind)
            {
                #region ●売価
                case UnitPriceKind.SalesUnitPrice:
                    // 売上消費税の端数処理単位、端数処理区分を取得
                    this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.SalesCnsTaxFrcProcCd, 0, out taxFractionProcUnit, out taxFractionProcCd);

                    // 価格指定
                    if (rate.PriceFl != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.Price;

                        CalclateUnitPrice(unitPriceCalcParam.TaxationDivCd,
                            //(double)row[RateAcs.PRICEFL],
                                          rate.PriceFl,
                                          unitPriceCalcParam.TaxRate,
                                          taxFractionProcUnit,
                                          taxFractionProcCd,
                            //(double)row[RateAcs.RATEVAL],
                                          rate.RateVal,
                                          out unitPriceTaxExc,
                                          out unitPriceTaxInc);
                        // 転嫁方式「非課税」時は、税込単価に税抜き単価をセット
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            unitPriceTaxInc = unitPriceTaxExc;
                        }
                    }
                    // UP率
                    else if (rate.UpRate != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.UpRate;

                        // 掛率にUP率をセット
                        rateVal = rate.UpRate;

                        UnitPriceCalcRet salesCostCalcRet = SearchUnitPriceCalcRet(UnitPriceKind.UnitCost, unitPriceCalcRetList, unitPriceCalcParam);

                        // 原価設定が取得できない場合は計算する
                        if (salesCostCalcRet == null)
                        {
                            List<UnitPriceCalcRet> salesCostCalcRetList = new List<UnitPriceCalcRet>();
                            this.CalculateUnitPriceProc(UnitPriceKind.UnitCost, unitPriceCalcParam, goodsUnitData, ref salesCostCalcRetList);

                            salesCostCalcRet = SearchUnitPriceCalcRet(UnitPriceKind.UnitCost, salesCostCalcRetList, unitPriceCalcParam);

                            if (salesCostCalcRet != null)
                            {
                                // 原価計算結果をセットする
                                unitPriceCalcRetList.Add(salesCostCalcRet.Clone());
                            }
                            else
                            {
                                salesCostCalcRet = new UnitPriceCalcRet();
                            }
                        }

                        // 転嫁方式「非課税」時は、扱う価格は常に税抜き価格
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            // 基準価格セット
                            stdPrice = salesCostCalcRet.UnitPriceTaxExcFl;
                            // 計算用の基準価格セット
                            stdPriceWk = salesCostCalcRet.UnitPriceTaxExcFl;
                            // 非課税として計算
                            taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        }
                        else
                        {
                            // 基準価格セット（内税品：税込み単価、外税･非課税品：税抜き単価）
                            stdPrice = ( unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ? salesCostCalcRet.UnitPriceTaxIncFl : salesCostCalcRet.UnitPriceTaxExcFl;

                            // 計算用の基準価格セット(内税計算の場合は税込単価を基に計算)
                            stdPriceWk = ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ) ? salesCostCalcRet.UnitPriceTaxIncFl : salesCostCalcRet.UnitPriceTaxExcFl;
                        }

                        this.CalculateUnitPriceByRate(unitPriceKind,
                                                         fractionProcCode,
                                                         taxationCode,
                                                         stdPriceWk,
                                                         unitPriceCalcParam.TaxRate,
                                                         taxFractionProcUnit,
                                                         taxFractionProcCd,
                                                         rateVal,
                                                         ref unPrcFracProcUnit,
                                                         ref unPrcFracProcDiv,
                                                         out unitPriceTaxExc,
                                                         out unitPriceTaxInc);
                    }
                    // 粗利確保率
                    else if (rate.GrsProfitSecureRate != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.GrsProfitSecureRate;

                        // 掛率に粗利確保率をセット
                        rateVal = rate.GrsProfitSecureRate;

                        UnitPriceCalcRet salesCostCalcRet = SearchUnitPriceCalcRet(UnitPriceKind.UnitCost, unitPriceCalcRetList, unitPriceCalcParam);

                        // 原価設定が取得できない場合は計算する
                        if (salesCostCalcRet == null)
                        {
                            List<UnitPriceCalcRet> salesCostCalcRetList = new List<UnitPriceCalcRet>();
                            this.CalculateUnitPriceProc(UnitPriceKind.UnitCost, unitPriceCalcParam, goodsUnitData, ref salesCostCalcRetList);

                            salesCostCalcRet = SearchUnitPriceCalcRet(UnitPriceKind.UnitCost, salesCostCalcRetList, unitPriceCalcParam);

                            if (salesCostCalcRet != null)
                            {
                                // 原価計算結果をセットする
                                unitPriceCalcRetList.Add(salesCostCalcRet.Clone());
                            }
                            else
                            {
                                salesCostCalcRet = new UnitPriceCalcRet();
                            }
                        }
                        // 転嫁方式「非課税」時は、扱う価格は常に税抜き価格
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            // 基準価格セット
                            stdPrice = salesCostCalcRet.UnitPriceTaxExcFl;
                            // 計算用の基準価格セット
                            stdPriceWk = salesCostCalcRet.UnitPriceTaxExcFl;

                            // 非課税として計算
                            taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        }
                        else
                        {
                            // 基準価格セット（内税品：税込み単価、外税･非課税品：税抜き単価）
                            stdPrice = ( unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ? salesCostCalcRet.UnitPriceTaxIncFl : salesCostCalcRet.UnitPriceTaxExcFl;

                            // 計算用の基準価格セット(内税計算の場合は税込単価を基に計算)
                            stdPriceWk = ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ) ? salesCostCalcRet.UnitPriceTaxIncFl : salesCostCalcRet.UnitPriceTaxExcFl;
                        }

                        this.CalculateUnitPriceByMarginRate(unitPriceKind,
                                                               fractionProcCode,
                                                               taxationCode,
                                                               stdPriceWk,
                                                               unitPriceCalcParam.TaxRate,
                                                               taxFractionProcUnit,
                                                               taxFractionProcCd,
                                                               rateVal,
                                                               ref unPrcFracProcUnit,
                                                               ref unPrcFracProcDiv,
                                                               out unitPriceTaxExc,
                                                               out unitPriceTaxInc);
                    }
                    // 売価率
                    else if (rate.RateVal != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;

                        // 掛率に売価率をセット
                        rateVal = rate.RateVal;

                        UnitPriceCalcRet listPricaCalcRet = SearchUnitPriceCalcRet(UnitPriceKind.ListPrice, unitPriceCalcRetList, unitPriceCalcParam);

                        // 定価設定が取得できない場合は計算する
                        if (listPricaCalcRet == null)
                        {
                            List<UnitPriceCalcRet> listPricaCalcRetList = new List<UnitPriceCalcRet>();
                            this.CalculateUnitPriceProc(UnitPriceKind.ListPrice, unitPriceCalcParam, goodsUnitData, ref listPricaCalcRetList);

                            listPricaCalcRet = SearchUnitPriceCalcRet(UnitPriceKind.ListPrice, listPricaCalcRetList, unitPriceCalcParam);

                            if (listPricaCalcRet != null)
                            {
                                // 原価計算結果をセットする
                                unitPriceCalcRetList.Add(listPricaCalcRet.Clone());
                            }
                            else
                            {
                                listPricaCalcRet = new UnitPriceCalcRet();
                            }
                        }
                        openPriceDiv = listPricaCalcRet.OpenPriceDiv;

                        // 転嫁方式「非課税」時は、扱う価格は常に税抜き価格
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            // 基準価格セット
                            stdPrice = listPricaCalcRet.UnitPriceTaxExcFl;
                            // 計算用の基準価格セット
                            stdPriceWk = listPricaCalcRet.UnitPriceTaxExcFl;

                            // 非課税として計算
                            taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        }
                        else
                        {
                            // 基準価格セット（内税品：税込み単価、外税･非課税品：税抜き単価）
                            stdPrice = ( unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ? listPricaCalcRet.UnitPriceTaxIncFl : listPricaCalcRet.UnitPriceTaxExcFl;

                            // 計算用の基準価格セット(内税計算の場合は税込単価を基に計算)
                            stdPriceWk = ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ) ? listPricaCalcRet.UnitPriceTaxIncFl : listPricaCalcRet.UnitPriceTaxExcFl;
                        }

                        this.CalculateUnitPriceByRate(unitPriceKind,
                                                         fractionProcCode,
                                                         taxationCode,
                                                         stdPriceWk,
                                                         unitPriceCalcParam.TaxRate,
                                                         taxFractionProcUnit,
                                                         taxFractionProcCd,
                                                         rateVal,
                                                         ref unPrcFracProcUnit,
                                                         ref unPrcFracProcDiv,
                                                         out unitPriceTaxExc,
                                                         out unitPriceTaxInc);
                    }
                    break;
                #endregion

                #region ●定価
                case UnitPriceKind.ListPrice:

                    // 売上消費税の端数処理単位、端数処理区分を取得
                    this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.SalesCnsTaxFrcProcCd, 0, out taxFractionProcUnit, out taxFractionProcCd);

                    // 価格指定(ユーザー定価)
                    if (rate.PriceFl != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.Price;
                        openPriceDiv = goodsPrice.OpenPriceDiv;

                        CalclateUnitPrice(unitPriceCalcParam.TaxationDivCd,
                                          rate.PriceFl,
                                          unitPriceCalcParam.TaxRate,
                                          taxFractionProcUnit,
                                          taxFractionProcCd,
                                          rate.RateVal,
                                          out unitPriceTaxExc,
                                          out unitPriceTaxInc);

                        // 転嫁方式「非課税」時は、税込単価に税抜き単価をセット
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            unitPriceTaxInc = unitPriceTaxExc;
                        }
                    }
                    // UP率
                    else if (rate.UpRate != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.UpRate;

                        // 掛率にUP率をセット
                        rateVal = rate.UpRate;

                        // オープン価格区分、基準単価のセット
                        openPriceDiv = goodsPrice.OpenPriceDiv;
                        stdPrice = goodsPrice.ListPrice;

                        // オープン価格で、価格がゼロの場合は取得失敗扱い(次の掛率を検索する)
                        if (( openPriceDiv == 1 ) && ( stdPrice == 0 )) return false;

                        stdPriceWk = stdPrice;

                        //--------------------------------------------------
                        // 計算用定価の算定
                        //--------------------------------------------------
                        // 転嫁方式「非課税」時は、基準単価を税抜き単価として計算する
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            if (unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                stdPrice -= CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, stdPrice);
                                stdPriceWk = stdPrice;
                            }
                            taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        }


                        this.CalculateUnitPriceByRate(unitPriceKind,
                                                      fractionProcCode,
                                                      taxationCode,
                                                      stdPriceWk,
                                                      unitPriceCalcParam.TaxRate,
                                                      taxFractionProcUnit,
                                                      taxFractionProcCd,
                                                      rateVal,
                                                      ref unPrcFracProcUnit,
                                                      ref unPrcFracProcDiv,
                                                      out unitPriceTaxExc,
                                                      out unitPriceTaxInc);

                    }
                    break;
                #endregion

                #region ●原価
                case UnitPriceKind.UnitCost:

                    // 仕入消費税の端数処理単位、端数処理区分を取得
                    this.GetStockFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.StockCnsTaxFrcProcCd, 0, out taxFractionProcUnit, out taxFractionProcCd);

                    // 価格指定
                    if (rate.PriceFl != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.Price;

                        CalclateUnitPrice(unitPriceCalcParam.TaxationDivCd,
                                          rate.PriceFl,
                                          unitPriceCalcParam.TaxRate,
                                          taxFractionProcUnit,
                                          taxFractionProcCd,
                                          rate.RateVal,
                                          out unitPriceTaxExc,
                                          out unitPriceTaxInc);
                        // 転嫁方式「非課税」時は、税込単価に税抜き単価をセット
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            unitPriceTaxInc = unitPriceTaxExc;
                        }
                    }
                    // 仕入率
                    else if (rate.RateVal != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;

                        // 掛率に仕入率をセット
                        rateVal = rate.RateVal;

                        // オープン価格区分、基準単価のセット
                        openPriceDiv = goodsPrice.OpenPriceDiv;
                        stdPrice = goodsPrice.ListPrice;

                        // オープン価格で、価格がゼロの場合は取得失敗扱い(次の掛率を検索する)
                        if (( openPriceDiv == 1 ) && ( stdPrice == 0 )) return false;

                        stdPriceWk = stdPrice;

                        //--------------------------------------------------
                        // 計算用定価の算定
                        //--------------------------------------------------
                        // 転嫁方式「非課税」時は、基準単価を税抜き単価として計算する
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            if (unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                stdPrice -= CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, stdPrice);
                                stdPriceWk = stdPrice;
                            }
                            taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        }

                        this.CalculateUnitPriceByRate(unitPriceKind,
                                                     fractionProcCode,
                                                     taxationCode,
                                                     stdPriceWk,
                                                     unitPriceCalcParam.TaxRate,
                                                     taxFractionProcUnit,
                                                     taxFractionProcCd,
                                                     rateVal,
                                                     ref unPrcFracProcUnit,
                                                     ref unPrcFracProcDiv,
                                                     out unitPriceTaxExc,
                                                     out unitPriceTaxInc);
                    }
                    break;
                #endregion

                default:
                    break;
            }

            #region 単価計算結果クラス生成

            UnitPriceCalcRet unitPriceCalcRet = new UnitPriceCalcRet();

            unitPriceCalcRet.UnitPriceKind = ( (int)unitPriceKind ).ToString();				// 単価種類
            unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;							// 商品コード
            unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;				// メーカーコード
            unitPriceCalcRet.RatePriorityOrder = rateProtyMng.RatePriorityOrder;			// 掛率優先順位
            unitPriceCalcRet.RateSettingDivide = rate.RateSettingDivide;	                // 掛率設定区分
            unitPriceCalcRet.RateMngGoodsCd = rate.RateMngGoodsCd;                          // 掛率設定区分（商品）
            unitPriceCalcRet.RateMngCustCd = rate.RateMngCustCd;                            // 掛率設定区分（得意先）

            if (rateProtyMng.RateSettingDivide.Trim() == rate.RateSettingDivide.Trim())
            {
                unitPriceCalcRet.RateMngGoodsNm = rateProtyMng.RateMngGoodsNm;				// 掛率設定名称（商品）
                unitPriceCalcRet.RateMngCustNm = rateProtyMng.RateMngCustNm;				// 掛率設定名称（得意先）
            }

            unitPriceCalcRet.UnitPrcCalcDiv = (int)unitPrcCalcDiv;							// 単価算出区分
            unitPriceCalcRet.SectionCode = rate.SectionCode;                                // 拠点コード
            unitPriceCalcRet.RateVal = rateVal;					                            // 掛率
            unitPriceCalcRet.UnPrcFracProcUnit = unPrcFracProcUnit;                         // 単価端数処理単位
            unitPriceCalcRet.UnPrcFracProcDiv = unPrcFracProcDiv;                           // 単価端数処理区分
            unitPriceCalcRet.StdUnitPrice = stdPrice;										// 基準単価
            unitPriceCalcRet.OpenPriceDiv = openPriceDiv;									// オープン価格区分
            unitPriceCalcRet.UnitPriceTaxExcFl = unitPriceTaxExc;							// 単価（税抜，浮動）
            unitPriceCalcRet.UnitPriceTaxIncFl = unitPriceTaxInc;							// 単価（税込，浮動）
            unitPriceCalcRet.PriceStartDate = goodsPrice.PriceStartDate;                    // 価格開始日
            unitPriceCalcRet.SupplierCd = unitPriceCalcParam.SupplierCd;                    // 仕入先コード
            // --- ADD m.suzuki 2011/02/16 ---------->>>>>
            if ( bfRate != null )
            {
                // 前レコードが有る場合は 「前レコード + 0.01」
                unitPriceCalcRet.LotSt = bfRate.LotCount + 0.01;
            }
            else
            {
                // 前レコードが無い場合は 0 から始まる
                unitPriceCalcRet.LotSt = 0;
            }
            unitPriceCalcRet.LotEd = rate.LotCount;
            // --- ADD m.suzuki 2011/02/16 ----------<<<<<
            unitPriceCalcRet.RateUpdateTimeSales = rate.UpdateDateTimeAdFormal; //ADD yangyi K2014/02/09 
            unitPriceCalcRet.RateUpdateTimeUnit = rate.UpdateDateTimeAdFormal; //ADD yangyi K2014/02/09 
            #endregion

            unitPriceCalcRetList.Add(unitPriceCalcRet);

            return true;
		}

        /// <summary>
        /// 掛率を使用して単価を計算します。
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="taxationCode">課税方式</param>
        /// <param name="stdPrice">基準価格</param>
        /// <param name="taxRate">税率</param>
        /// <param name="taxFracProcUnit">消費税端数処理単位</param>
        /// <param name="taxFracProcCd">消費税端数処理コード</param>
        /// <param name="rate">掛率</param>
        /// <param name="fracProcUnit">単価端数処理単位</param>
        /// <param name="fracProcCd">単価端数処理区分</param>
        /// <param name="unitPriceTaxExc">税抜き単価</param>
        /// <param name="unitPriceTaxInc">税込み単価</param>
        private void CalculateUnitPriceByRate( UnitPriceKind unitPriceKind, int fractionProcCode, int taxationCode, double stdPrice, double taxRate, double taxFracProcUnit, int taxFracProcCd, double rate, ref  double fracProcUnit, ref int fracProcCd, out double unitPriceTaxExc, out double unitPriceTaxInc )
        {
            unitPriceTaxExc = 0;
            unitPriceTaxInc = 0;

            // 外税の場合
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                // ①税抜き単価 = 基準単価から掛率計算した結果
                unitPriceTaxExc = CalclateUnitPriceByRate(unitPriceKind, fractionProcCode, stdPrice, rate, ref fracProcUnit, ref fracProcCd);

                // ②税込み単価 = 税抜き単価 + 税抜き単価の消費税
                unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceTaxExc);
            }
            // 内税の場合
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                // ①税込み単価 = 基準単価から掛率計算した結果
                unitPriceTaxInc = CalclateUnitPriceByRate(unitPriceKind, fractionProcCode, stdPrice, rate, ref fracProcUnit, ref fracProcCd);

                // ②税抜き単価 = 税込み単価 - 税込み単価の消費税
                unitPriceTaxExc = (double)( (decimal)unitPriceTaxInc - (decimal)CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceTaxInc) );
            }
            // 非課税
            else
            {
                // ①税抜き単価 = 基準単価から掛率計算した結果
                unitPriceTaxExc = CalclateUnitPriceByRate(unitPriceKind, fractionProcCode, stdPrice, rate, ref fracProcUnit, ref fracProcCd);

                // ②税込み単価 = 税抜き単価
                unitPriceTaxInc = unitPriceTaxExc;
            }
        }

		/// <summary>
		/// 掛率を使用して単価を計算します。
		/// </summary>
		/// <param name="unitPriceKind">単価種類</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="stdPrice">基準価格</param>
		/// <param name="rate">掛率</param>
		/// <param name="fracProcUnit">端数処理単位</param>
		/// <param name="fracProcCd">端数処理区分</param>
		/// <returns></returns>
		private double CalclateUnitPriceByRate( UnitPriceKind unitPriceKind, int fractionProcCode, double stdPrice, double rate, ref double fracProcUnit, ref int fracProcCd )
		{
			if (( rate == 0 ) || ( stdPrice == 0 )) return 0;

			double unitPrice = ( rate < 0 ) ? stdPrice * ( 100 + rate ) * 0.01 : stdPrice * rate * 0.01;

			SettingFracProcInfo(unitPriceKind, fractionProcCode, unitPrice, ref fracProcUnit, ref fracProcCd);

			FractionCalculate.FracCalcMoney(unitPrice, fracProcUnit, fracProcCd, out unitPrice);

			return unitPrice;
		}

		/// <summary>
		/// 対象単価より、税抜き、税込み単価を算出します。
		/// </summary>
		/// <param name="taxationCode">課税方式</param>
		/// <param name="targetPrice">対象価格</param>
		/// <param name="taxRate">税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理コード</param>
		/// <param name="rate">掛率</param>
		/// <param name="unitPriceTaxExc">税抜き単価</param>
		/// <param name="unitPriceTaxInc">税込み単価</param>
		private void CalclateUnitPrice( int taxationCode, double targetPrice, double taxRate, double taxFracProcUnit, int taxFracProcCd, double rate, out double unitPriceTaxExc, out double unitPriceTaxInc )
		{
			unitPriceTaxExc = 0;
			unitPriceTaxInc = 0;

			// 外税の場合
			if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
			{
				// ①税抜き単価 = 基準単価から掛率計算した結果
				unitPriceTaxExc = targetPrice;

				// ②税込み単価 = 税抜き単価 + 税抜き単価の消費税
				unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceTaxExc);
			}
			// 内税の場合
			else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
			{
				// ①税込み単価 = 基準単価から掛率計算した結果
				unitPriceTaxInc = targetPrice;

				// ②税抜き単価 = 税込み単価 - 税込み単価の消費税
				unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceTaxInc);
			}
			// 非課税
			else
			{
				// ①税抜き単価 = 基準単価から掛率計算した結果
				unitPriceTaxExc = targetPrice;

				// ②税込み単価 = 税抜き単価
				unitPriceTaxInc = unitPriceTaxExc;
			}
		}

		/// <summary>
		/// 粗利率を使用して単価を計算します。
		/// </summary>
		/// <param name="unitPriceKind">単価種類</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="taxationCode">課税区分</param>
		/// <param name="costPrice">原価</param>
		/// <param name="taxRate">税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
		/// <param name="marginRate">粗利率</param>
		/// <param name="fracProcUnit">単価端数処理単位</param>
		/// <param name="fracProcCd">単価端数処理区分</param>
		/// <param name="unitPriceTaxExc">税抜き単価</param>
		/// <param name="unitPriceTaxInc">税込み単価</param>
		private void CalculateUnitPriceByMarginRate( UnitPriceKind unitPriceKind, int fractionProcCode, int taxationCode, double costPrice, double taxRate, double taxFracProcUnit, int taxFracProcCd, double marginRate, ref double fracProcUnit, ref int fracProcCd, out double unitPriceTaxExc, out double unitPriceTaxInc )
		{
			unitPriceTaxExc = 0;
			unitPriceTaxInc = 0;

			// 外税の場合
			if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
			{
				// ①税抜き単価 = 基準単価から掛率計算した結果
				unitPriceTaxExc = CalclateUnitPriceByMarginRate(unitPriceKind, fractionProcCode, costPrice, marginRate, ref fracProcUnit, ref fracProcCd);

				// ②税込み単価 = 税抜き単価 + 税抜き単価の消費税
				unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceTaxExc);
			}
			// 内税の場合
			else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
			{
				// ①税込み単価 = 基準単価から掛率計算した結果
				unitPriceTaxInc = CalclateUnitPriceByMarginRate(unitPriceKind, fractionProcCode, costPrice, marginRate, ref fracProcUnit, ref fracProcCd);

				// ②税抜き単価 = 税込み単価 - 税込み単価の消費税
				unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceTaxInc);
			}
			// 非課税
			else
			{
				// ①税抜き単価 = 基準単価から掛率計算した結果
				unitPriceTaxExc = CalclateUnitPriceByMarginRate(unitPriceKind, fractionProcCode, costPrice, marginRate, ref fracProcUnit, ref fracProcCd);

				// ②税込み単価 = 税抜き単価
				unitPriceTaxInc = unitPriceTaxExc;
			}
		}

		/// <summary>
		/// 粗利率を使用して単価を計算します。
		/// </summary>
		/// <param name="unitPriceKind">単価種類</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="costPrice">原価単価</param>
		/// <param name="marginRate">粗利率</param>
		/// <param name="fracProcUnit">端数処理単位</param>
		/// <param name="fracProcCd">端数処理区分</param>
		/// <returns>単価</returns>
		private double CalclateUnitPriceByMarginRate( UnitPriceKind unitPriceKind, int fractionProcCode, double costPrice, double marginRate, ref double fracProcUnit, ref int fracProcCd )
		{
			if (( marginRate == 0 ) || ( costPrice == 0 )) return 0;

			double unitPrice = costPrice / ( 1 - marginRate * 0.01 );

			SettingFracProcInfo(unitPriceKind, fractionProcCode, unitPrice, ref fracProcUnit, ref fracProcCd);

			FractionCalculate.FracCalcMoney(unitPrice, fracProcUnit, fracProcCd, out unitPrice);

			return unitPrice;
		}

		/// <summary>
		/// 商品連結オブジェクトより、対象日の価格情報を取得します。
		/// </summary>
		/// <param name="targetDay">対象日</param>
		/// <param name="goodsUnitData">商品連結データオブジェクト</param>
		/// <param name="goodsPrice">価格情報オブジェクト</param>
		private void GetPrice( DateTime targetDay, GoodsUnitData goodsUnitData, out GoodsPrice goodsPrice )
		{
			goodsPrice = null;
			if (( goodsUnitData == null ) || ( goodsUnitData.GoodsPriceList == null )) return;

			List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;

			DateTime dateWk = DateTime.MinValue;
			foreach (GoodsPrice goodsPriceWk in goodsPriceList)
			{
				if (( goodsPriceWk.PriceStartDate <= targetDay ) && ( goodsPriceWk.PriceStartDate > dateWk ))
				{
					dateWk = goodsPriceWk.PriceStartDate;
					goodsPrice = goodsPriceWk.Clone();
				}
			}
		}

        // -----ADD 2011/11/22----->>>>>
        /// <summary>
        /// 商品連結オブジェクトより、対象日の価格情報を取得します。(原価用)
        /// </summary>
        /// <param name="targetDay">対象日</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="goodsPrice">価格情報オブジェクト</param>
        private void GetPriceForUnitCost(DateTime targetDay, GoodsUnitData goodsUnitData, out GoodsPrice goodsPrice)
        {
            goodsPrice = null;
            if ((goodsUnitData == null) || (goodsUnitData.GoodsPriceList == null)) return;

            List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;

            DateTime dateWk = DateTime.MinValue;
            foreach (GoodsPrice goodsPriceWk in goodsPriceList)
            {
                if ((!string.IsNullOrEmpty(goodsPriceWk.EnterpriseCode)) && (goodsPriceWk.PriceStartDate <= targetDay) && (goodsPriceWk.PriceStartDate > dateWk)) // ユーザ分優先
                {
                    dateWk = goodsPriceWk.PriceStartDate;
                    goodsPrice = goodsPriceWk.Clone();
                }
            }

            if (goodsPrice == null)
            {
                foreach (GoodsPrice goodsPriceWk in goodsPriceList)
                {
                    if ((string.IsNullOrEmpty(goodsPriceWk.EnterpriseCode)) && (goodsPriceWk.PriceStartDate <= targetDay) && (goodsPriceWk.PriceStartDate > dateWk)) // 提供分
                    {
                        dateWk = goodsPriceWk.PriceStartDate;
                        goodsPrice = goodsPriceWk.Clone();
                    }
                }
            }
        }
        // -----ADD 2011/11/22-----<<<<<

        /// <summary>
        /// 掛率優先管理検索
        /// </summary>
        private void SearchRateProtyMng()
        {
            _rateProtyMngAllList = new List<RateProtyMng>();
            RateProtyMngAcs rateProtyMngAcs = new RateProtyMngAcs();

            bool nextdata;
            int totalcnt;
            string msg;
            ArrayList list;
            rateProtyMngAcs.Search(out list, out totalcnt, out nextdata, this._enterpriseCode, "", out msg);

            if (list != null)
            {
                _rateProtyMngAllList = new List<RateProtyMng>();
                _rateProtyMngAllList.AddRange((RateProtyMng[])list.ToArray(typeof(RateProtyMng)));

                // 拠点、単価種類、優先順位でソート
                _rateProtyMngAllList.Sort(new DCKHN01060CF.RateProtyMngComparer());
            }
        }

        /// <summary>
        /// 掛率優先管理情報のリストを取得します。
        /// </summary>
        /// <returns></returns>
        private List<RateProtyMng> GetRateProtyMngList(string sectionCode, UnitPriceKind unitPriceKind)
        {
            if (_rateProtyMngAllList == null) SearchRateProtyMng();

            if (_rateProtyMngAllList == null || _rateProtyMngAllList.Count == 0) return null;

            if (( _lastSectionCode == sectionCode ) && ( unitPriceKind == _lastUnitPriceKind ))
            {
                // 2011/07/20 add wangf start
                if (this._ratePriorityDiv == 1)
                {
                    _lastRateProtyMngList.Sort(new DCKHN01060CF.RateProtyMngComparerUnitPriceKind());
                }
                // 2011/07/20 add wangf end
                return _lastRateProtyMngList;
            }


            // 対象拠点分の優先管理を取得
            _lastRateProtyMngList = _rateProtyMngAllList.FindAll(
                delegate(RateProtyMng rateProtyMng)
                {
                    if (( rateProtyMng.SectionCode.Trim() == sectionCode.Trim() ) &&
                        ( rateProtyMng.UnitPriceKind == (int)unitPriceKind ))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            if (sectionCode.Trim() != "00")
            {
                // 全社設定分を追加
                _lastRateProtyMngList.AddRange(_rateProtyMngAllList.FindAll(
                    delegate(RateProtyMng rateProtyMng)
                    {
                        if (( rateProtyMng.SectionCode.Trim() == "00" ) &&
                            ( rateProtyMng.UnitPriceKind == (int)unitPriceKind ))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }));
            }
            // 2011/07/20 add wangf start
            if (this._ratePriorityDiv == 1)
            {
                _lastRateProtyMngList.Sort(new DCKHN01060CF.RateProtyMngComparerUnitPriceKind());
            }
            // 2011/07/20 add wangf end
            _lastSectionCode = sectionCode;
            _lastUnitPriceKind = unitPriceKind;
            return _lastRateProtyMngList;

        }

        /// <summary>
        /// 掛率マスタを検索します。
        /// </summary>
        /// <param name="unitPriceKindList">単価種類リスト</param>
        /// <param name="unitPriceCalcParamList">単価算出パラメータリスト</param>
        /// <param name="rateList">掛率リスト</param>
        /// <returns>掛率検索ステータス</returns>
        private int SearchRate(List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParam> unitPriceCalcParamList, out List<Rate> rateList)
        {
            RateAcs rateAcs = new RateAcs();

            rateList = new List<Rate>();
            List<RateProtyMng> rateProtyMngList = null;

            LogWrite("掛率 検索パラメータ作成");

            foreach (UnitPriceKind unitPriceKind in unitPriceKindList)
            {
                List<Rate> kindRateList = new List<Rate>();
                foreach (UnitPriceCalcParam unitPriceCalcParam in unitPriceCalcParamList)
                {
                    rateProtyMngList = this.GetRateProtyMngList(unitPriceCalcParam.SectionCode, unitPriceKind);

                    if (rateProtyMngList != null && rateProtyMngList.Count > 0)
                    {
                        this.MakeRateReadParam(unitPriceCalcParam, rateProtyMngList, ref kindRateList);
                    }
                }
                rateList.AddRange(kindRateList);
            }

            LogWrite("掛率 Search パラメータ:" + rateList.Count.ToString());

            int status = -1;
            if (rateList.Count > 0)
            {
                string msg;
                status = rateAcs.Search(out rateList, rateList, out msg);
            }

            LogWrite("掛率取得終了");
            return status;
        }

        // ADD 2014/02/05 №10631 吉岡 掛率マスタキャッシュ ------->>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 掛率マスタを検索します。
        /// 掛率マスタキャッシュ対応用
        /// </summary>
        /// <param name="unitPriceKindList">単価種類リスト</param>
        /// <param name="unitPriceCalcParamList">単価算出パラメータリスト</param>
        /// <param name="rateList">掛率リスト</param>
        /// <returns>掛率検索ステータス</returns>
        private int SearchRateCache(List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParam> unitPriceCalcParamList, out List<Rate> rateList)
        {
            RateAcs rateAcs = new RateAcs();
            // 掛率マスタ ワーク
            List<Rate> rateListWork = new List<Rate>();
            // 検索条件用掛率マスタ
            List<Rate> rateListSearch = new List<Rate>();
            // 掛率マスタ検索結果
            List<Rate> rateListRtn = new List<Rate>();

            rateList = new List<Rate>();
            List<RateProtyMng> rateProtyMngList = null;

            LogWrite("掛率 検索パラメータ作成");

            // 検索パラメータを生成し、掛率マスタワークにセット
            foreach (UnitPriceKind unitPriceKind in unitPriceKindList)
            {
                List<Rate> kindRateList = new List<Rate>();
                foreach (UnitPriceCalcParam unitPriceCalcParam in unitPriceCalcParamList)
                {
                    rateProtyMngList = this.GetRateProtyMngList(unitPriceCalcParam.SectionCode, unitPriceKind);

                    if (rateProtyMngList != null && rateProtyMngList.Count > 0)
                    {
                        this.MakeRateReadParamCache(unitPriceCalcParam, rateProtyMngList, ref kindRateList);
                    }
                }
                rateListWork.AddRange(kindRateList);
            }

            LogWrite("掛率 Search パラメータ:" + rateList.Count.ToString());

            // 検索済み掛率マスタの場合は、返値用掛率マスタにセット
            // 未検索であれば、検索条件用掛率マスタにセット
            foreach (Rate rate in rateListWork)
            {
                // 検索済み掛率マスタから取得
                List<Rate> wk = _rateMstList.FindAll(
                                    delegate(Rate rate2)
                                    {
                                        return rateParaMuch(rate, rate2);
                                    });

                if (wk == null || wk.Count.Equals(0))
                {
                    // 検索条件用掛率マスタに追加
                    rateListSearch.Add(rate);
                }
                else
                {
                    // 返値用掛率マスタに追加
                    rateList.AddRange(wk);
                }
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            // 検索条件用掛率マスタがあれば検索実行
            if (rateListSearch.Count > 0)
            {
                string msg;
                status = rateAcs.Search(out rateListRtn, rateListSearch, out msg);
                // 検索結果をDBから取得できた場合
                if (rateListRtn != null)
                {
                    // 返値用掛率マスタと検索済み掛率マスタキャッシュ(DB登録有り)に追加
                    rateList.AddRange(rateListRtn);
                    _rateMstList.AddRange(rateListRtn);
                }

                if (rateListRtn == null || rateListRtn.Count.Equals(0))
                {
                    // 掛率マスタ検索結果がNULLの場合
                    // 検索済み掛率マスタキャッシュ(DB登録無し)に検索条件用掛率マスタを全件追加
                    _rateMstListNotFound.AddRange(rateListSearch);
                }
                else
                {
                    // 掛率マスタ検索結果がNot NULLの場合
                    // 検索条件用掛率マスタより、DBより取得できなかった掛率マスタを、検索済み掛率マスタキャッシュ(DB登録無し)に追加
                    foreach (Rate rate in rateListSearch)
                    {
                        if (rateListRtn.Find(
                                            delegate(Rate rate2)
                                            {
                                                return rateParaMuch(rate, rate2);
                                            }) == null)
                        {
                            _rateMstListNotFound.Add(rate);
                        }
                    }
                }
            }

            if (rateList != null)
            {
                if (rateList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else if (rateList.Count.Equals(0))
                {
                    rateList = null;
                }
            }

            rateListWork = null;
            rateListSearch = null;
            rateListRtn = null;

            LogWrite("掛率取得終了");
            return status;
        }
        
        /// <summary>
        /// 掛率マスタ検索条件が一致するか否か
        /// </summary>
        /// <param name="rate">対象掛率マスタ</param>
        /// <param name="rate2">対象掛率マスタ２</param>
        /// <returns>true：一致する  false：一致しない </returns>
        private bool rateParaMuch(Rate rate,Rate rate2)
        {
            if ((rate2.GoodsNo.Trim() == rate.GoodsNo.Trim()) &&
                (rate2.UnitPriceKind.Trim() == rate.UnitPriceKind.Trim()) &&
                (rate2.RateSettingDivide.Trim() == rate.RateSettingDivide.Trim()) &&
                (rate2.SectionCode.Trim() == rate.SectionCode.Trim()) &&
                (rate2.GoodsMakerCd == rate.GoodsMakerCd) &&
                (rate2.GoodsRateRank.Trim() == rate.GoodsRateRank.Trim()) &&
                (rate2.GoodsRateGrpCode == rate.GoodsRateGrpCode) &&
                (rate2.BLGroupCode == rate.BLGroupCode) &&
                (rate2.BLGoodsCode == rate.BLGoodsCode) &&
                (rate2.CustomerCode == rate.CustomerCode) &&
                (rate2.CustRateGrpCode == rate.CustRateGrpCode) &&
                (rate2.SupplierCd == rate.SupplierCd))
            {
                return true;
            }
            else
            {
                return false;
            };
        }
        
        /// <summary>
        /// 掛率マスタの読み込みパラメータを生成します。
        /// 掛率マスタキャッシュ対応用
        /// </summary>
        /// <param name="unitPriceCalcParam">単価算出パラメータ</param>
        /// <param name="rateProtyMngList">掛率優先管理マスタリスト</param>
        /// <param name="rateList">掛率マスタリスト</param>
        private void MakeRateReadParamCache(UnitPriceCalcParam unitPriceCalcParam, List<RateProtyMng> rateProtyMngList, ref List<Rate> rateList)
        {
            foreach (RateProtyMng rateProtyMng in rateProtyMngList)
            {
                // 掛率マスタを読み込む条件が全て入力されている場合のみ検索リストに追加
                if (CanCreateCheck(rateProtyMng.RateSettingDivide, unitPriceCalcParam))
                {
                    Rate rate = CreateRateFromUnitPriceCalcParam((UnitPriceKind)rateProtyMng.UnitPriceKind, rateProtyMng.RateSettingDivide, rateProtyMng.SectionCode, unitPriceCalcParam);

                    // 検索済みでDBより取得できなかった掛率マスタは検索条件パラメータから除外する
                    if (_rateMstListNotFound.Find(
                                        delegate(Rate rate2)
                                        {
                                            return rateParaMuch(rate, rate2);
                                        }) != null)
                    {
                        continue;
                    }

                    if(rateList.Find(
                                        delegate(Rate rate2)
                                        {
                                            return rateParaMuch(rate, rate2);
                                        }) != null)
                    {
                        continue;
                    }

                    rate.EnterpriseCode = this._enterpriseCode;
                    rateList.Add(rate);
                }
            }
        }
        // ADD 2014/02/05 №10631 吉岡 掛率マスタキャッシュ -------<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// 掛率マスタの読み込みパラメータを生成します。
		/// </summary>
		/// <param name="unitPriceCalcParam">単価算出パラメータ</param>
        /// <param name="rateProtyMngList">掛率優先管理マスタリスト</param>
        /// <param name="rateList">掛率マスタリスト</param>
        private void MakeRateReadParam(UnitPriceCalcParam unitPriceCalcParam, List<RateProtyMng> rateProtyMngList, ref List<Rate> rateList)
		{
            foreach (RateProtyMng rateProtyMng in rateProtyMngList)
            {
                // 掛率マスタを読み込む条件が全て入力されている場合のみ検索リストに追加
                if (CanCreateCheck(rateProtyMng.RateSettingDivide, unitPriceCalcParam))
                {
                    Rate rate = CreateRateFromUnitPriceCalcParam((UnitPriceKind)rateProtyMng.UnitPriceKind, rateProtyMng.RateSettingDivide, rateProtyMng.SectionCode, unitPriceCalcParam);

                    Rate findRate = rateList.Find(
                                        delegate(Rate rate2)
                                        {
                                            if (( rate2.GoodsNo == rate.GoodsNo ) &&
                                                ( rate2.UnitPriceKind == rate.UnitPriceKind ) &&
                                                ( rate2.RateSettingDivide == rate.RateSettingDivide ) &&
                                                ( rate2.SectionCode == rate.SectionCode ) &&
                                                ( rate2.GoodsMakerCd == rate.GoodsMakerCd ) &&
                                                ( rate2.GoodsRateRank == rate.GoodsRateRank ) &&
                                                ( rate2.GoodsRateGrpCode == rate.GoodsRateGrpCode ) &&
                                                ( rate2.BLGroupCode == rate.BLGroupCode ) &&
                                                ( rate2.BLGoodsCode == rate.BLGoodsCode ) &&
                                                ( rate2.CustomerCode == rate.CustomerCode ) &&
                                                ( rate2.CustRateGrpCode == rate.CustRateGrpCode ) &&
                                                ( rate2.SupplierCd == rate.SupplierCd ))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
                    if (findRate != null)
                    {
                        continue;
                    }

                    rate.EnterpriseCode = this._enterpriseCode;
                    rateList.Add(rate);
                }
            }
		}

		#region 金額処理区マスタ関連

		/// <summary>
		/// 単価種類、金額に従って端数処理単位、端数処理区分を設定します。
		/// </summary>
		/// <param name="unitPriceKind">単価種類</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="price">対象金額</param>
		/// <param name="fractionProcUnit">端数処理単位</param>
		/// <param name="fractionProcCd">端数処理区分</param>
        /// <br>UpdateNote : 2010/06/02 張凱 PM.NS障害・改良対応（７月リリース案件）No.4</br>
        /// <br>             定価や掛率を変更しても売価、原価が正しく再計算されないに改修</br>
		private void SettingFracProcInfo( UnitPriceKind unitPriceKind, int fractionProcCode, double price, ref double fractionProcUnit, ref int fractionProcCd )
		{
            //if (fractionProcUnit == 0) DEL 2010/06/02
			//{
				switch (unitPriceKind)
				{
					//// 売上原価単価
					//case UnitPriceKind.SalesUnitCost:
					//    {
					//        this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_CostUnitPrice, fractionProcCode, price, out fractionProcUnit, out fractionProcCd);
					//        break;
					//    }
					// 仕入単価
					case UnitPriceKind.UnitCost:
						{
							this.GetStockFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_UnitPrice, fractionProcCode, price, out fractionProcUnit, out fractionProcCd);
							break;
						}
                    //>>>2010/12/02
                    //// 定価、売上単価
                    //case UnitPriceKind.ListPrice:
                    //case UnitPriceKind.SalesUnitPrice:
                    //{
                    //  this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_UnitPrice, fractionProcCode, price, out fractionProcUnit, out fractionProcCd);
                    //  break;
                    //  }
                    //}

                    // 定価
                    case UnitPriceKind.ListPrice:
                        {
                            break;
                        }

                    // 売上単価
                    case UnitPriceKind.SalesUnitPrice:
                        {
                            this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_UnitPrice, fractionProcCode, price, out fractionProcUnit, out fractionProcCd);
                            break;
                        }
                    //<<<2010/12/02
                }
			//}
		}

		/// <summary>
		/// 売上金額処理区分設定マスタより、対象金額に該当する端数処理単位、端数処理コードを取得します。
		/// </summary>
		/// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="price">対象金額</param>
		/// <param name="fractionProcUnit">端数処理単位</param>
		/// <param name="fractionProcCd">端数処理区分</param>
		private void GetSalesFractionProcInfo( int fracProcMoneyDiv, int fractionProcCode, double price, out double fractionProcUnit, out int fractionProcCd )
		{
            fractionProcUnit = DCKHN01060CF.GetDefaultFractionProcUnit(fracProcMoneyDiv);
            fractionProcCd = DCKHN01060CF.GetDefaultFractionProcCd(fracProcMoneyDiv);

            if (_salesProcMoneyList == null || _salesProcMoneyList.Count == 0) return;

            List<SalesProcMoney> salesProcMoneyList = _salesProcMoneyList.FindAll(
                                        delegate(SalesProcMoney salesProcMoney)
                                        {
                                            if (( salesProcMoney.FracProcMoneyDiv == fracProcMoneyDiv ) &&
                                                ( salesProcMoney.FractionProcCode == fractionProcCode ) &&
                                                ( salesProcMoney.UpperLimitPrice >= price ))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (salesProcMoneyList != null && salesProcMoneyList.Count > 0)
            {
                fractionProcUnit = salesProcMoneyList[0].FractionProcUnit;
                fractionProcCd = salesProcMoneyList[0].FractionProcCd;
            }
		}

		/// <summary>
		/// 仕入金額処理区分設定マスタより、対象金額に該当する端数処理単位、端数処理コードを取得します。
		/// </summary>
		/// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="price">対象金額</param>
		/// <param name="fractionProcUnit">端数処理単位</param>
		/// <param name="fractionProcCd">端数処理区分</param>
		private void GetStockFractionProcInfo( int fracProcMoneyDiv, int fractionProcCode, double price, out double fractionProcUnit, out int fractionProcCd )
		{
            fractionProcUnit = DCKHN01060CF.GetDefaultFractionProcUnit(fracProcMoneyDiv);
            fractionProcCd = DCKHN01060CF.GetDefaultFractionProcCd(fracProcMoneyDiv);

            if (_stockProcMoneyList == null || _stockProcMoneyList.Count == 0) return;

            List<StockProcMoney> stockProcMoneyList = _stockProcMoneyList.FindAll(
                                        delegate(StockProcMoney stockProcMoney)
                                        {
                                            if (( stockProcMoney.FracProcMoneyDiv == fracProcMoneyDiv ) &&
                                                ( stockProcMoney.FractionProcCode == fractionProcCode ) &&
                                                ( stockProcMoney.UpperLimitPrice >= price ))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (stockProcMoneyList != null && stockProcMoneyList.Count > 0)
            {
                fractionProcUnit = stockProcMoneyList[0].FractionProcUnit;
                fractionProcCd = stockProcMoneyList[0].FractionProcCd;
            }
		}
		#endregion

        // --- ADD huangt 2013/05/30 PM-TAB対応 ---------- >>>>>
        /// <summary>
        /// 単価計算処理
        /// </summary>
        /// <param name="unitPriceKindList">単価種類リスト</param>
        /// <param name="unitPriceCalcParamList">単価計算パラメータリスト</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <param name="rateList">掛率マスタリスト</param>
        private void CalculateUnitPriceForTabletProc(List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, ref List<UnitPriceCalcRet> unitPriceCalcRetList, ref List<Rate> rateList)
        {
            LogWrite(string.Format("単価算出 開始 {0}件:", unitPriceCalcParamList.Count));

            // パラメータリスト、商品連結データオブジェクトリストが無ければ処理しない
            if ((unitPriceCalcParamList == null) || (unitPriceCalcParamList.Count == 0) || (goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
            {
                return;
            }

            LogWrite("掛率読み込み");

            // 掛率マスタの読み込み
            int status = this.SearchRate(unitPriceKindList, unitPriceCalcParamList, out rateList);


            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                rateList = null;
            }
            else
            {
                LogWrite(string.Format("掛率 {0}件取得", rateList.Count));
            }

            LogWrite("原価計算");

            // 原価計算処理
            if (unitPriceKindList.Contains(UnitPriceKind.UnitCost))
            {
                this.CalculateUnitCostPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, ref unitPriceCalcRetList);

            }

            LogWrite("定価計算");

            // 定価計算処理
            if (unitPriceKindList.Contains(UnitPriceKind.ListPrice))
            {
                this.CalculateListPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, ref unitPriceCalcRetList);
            }

            LogWrite("売価計算");

            // 売価計算処理
            if (unitPriceKindList.Contains(UnitPriceKind.SalesUnitPrice))
            {
                this.CalculateSalesUnitPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, ref unitPriceCalcRetList);
            }

            LogWrite("単価算出 終了");
        }
        // --- ADD huangt 2013/05/30 PM-TAB対応 ---------- <<<<<

		#endregion

        // ===================================================================================== //
        // スタティックメソッド
        // ===================================================================================== //
        #region ■Static Methods

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
		/// 単価種類、掛率設定区分、単価計算パラメータオブジェクトより、掛率マスタオブジェクトを生成します。
		/// </summary>
		/// <param name="unitPriceKind">単価種類</param>
		/// <param name="rateSettingDivide">掛率設定区分</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="unitPriceCalcParam">掛率計算パラメータ</param>
		/// <returns></returns>
		private static Rate CreateRateFromUnitPriceCalcParam( UnitPriceKind unitPriceKind, string rateSettingDivide, string sectionCode, UnitPriceCalcParam unitPriceCalcParam )
		{
			Rate rate = new Rate();

			rate.UnitPriceKind = ( (int)unitPriceKind ).ToString();
			rate.RateSettingDivide = rateSettingDivide;
			rate.SectionCode = sectionCode;
			rate.RateMngGoodsCd = GetRateMngCustCd(rateSettingDivide);
			rate.RateMngCustCd = GetRateMngCustCd(rateSettingDivide);
			rate.GoodsNo = RateAcs.IsGoodsNoSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsNo : "";
            rate.GoodsMakerCd = RateAcs.IsMakerSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsMakerCd : 0;
            rate.GoodsRateRank = RateAcs.IsGoodsRateRankSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsRateRank : "";
            rate.GoodsRateGrpCode = RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsRateGrpCode : 0;
            rate.BLGroupCode = RateAcs.IsBLGroupCodeSetting(rateSettingDivide) ? unitPriceCalcParam.BLGroupCode : 0;
            rate.BLGoodsCode = RateAcs.IsBLGoodsSetting(rateSettingDivide) ? unitPriceCalcParam.BLGoodsCode : 0;
            rate.CustomerCode = RateAcs.IsCustomerSetting(rateSettingDivide) ? unitPriceCalcParam.CustomerCode : 0;
            rate.CustRateGrpCode = RateAcs.IsCustRateGrpSetting(rateSettingDivide) ? unitPriceCalcParam.CustRateGrpCode : 0;
            rate.SupplierCd = RateAcs.IsSupplierSetting(rateSettingDivide) ? unitPriceCalcParam.SupplierCd : 0;

			return rate;
		}

		/// <summary>
		/// 掛率マスタを読み込む条件が設定されているかチェックします。
		/// </summary>
		/// <param name="rateSettingDivide"></param>
		/// <param name="unitPriceCalcParam"></param>
		/// <returns></returns>
        private static bool CanCreateCheck( string rateSettingDivide, UnitPriceCalcParam unitPriceCalcParam )
        {
            if ( ((RateAcs.IsGoodsNoSetting( rateSettingDivide ) && (string.IsNullOrEmpty( unitPriceCalcParam.GoodsNo.Trim() )))) ||
                ((RateAcs.IsMakerSetting( rateSettingDivide ) && (unitPriceCalcParam.GoodsMakerCd == 0))) ||
                ((RateAcs.IsGoodsRateRankSetting( rateSettingDivide ) && (string.IsNullOrEmpty( unitPriceCalcParam.GoodsRateRank.Trim() )))) ||
                ((RateAcs.IsGoodsRateGrpCodeSetting( rateSettingDivide ) && (unitPriceCalcParam.GoodsRateGrpCode == 0))) ||
                ((RateAcs.IsBLGroupCodeSetting( rateSettingDivide ) && (unitPriceCalcParam.BLGroupCode == 0))) ||
                ((RateAcs.IsBLGoodsSetting( rateSettingDivide ) && (unitPriceCalcParam.BLGoodsCode == 0))) ||
                ((RateAcs.IsCustomerSetting( rateSettingDivide ) && (unitPriceCalcParam.CustomerCode == 0))) ||
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/16 DEL
                //( ( RateAcs.IsCustRateGrpSetting(rateSettingDivide) && ( unitPriceCalcParam.CustRateGrpCode == 0 ) ) ) ||
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/16 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/16 ADD
                ((RateAcs.IsCustRateGrpSetting( rateSettingDivide ) && (unitPriceCalcParam.CustRateGrpCode < 0))) ||
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/16 ADD
                ((RateAcs.IsSupplierSetting( rateSettingDivide ) && (unitPriceCalcParam.SupplierCd == 0))) )
            {
                return false;
            }

            return true;
        }

		#endregion

		/// <summary>
		/// 検索条件
		/// </summary>
		/// <param name="unitPriceKind">単価種類</param>
		/// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
		/// <param name="unitPriceCalcParam">単価算出パラメータ</param>
		/// <returns></returns>
		private static UnitPriceCalcRet SearchUnitPriceCalcRet( UnitPriceKind unitPriceKind, List<UnitPriceCalcRet> unitPriceCalcRetList, UnitPriceCalcParam unitPriceCalcParam )
		{
			UnitPriceCalcRet unitPriceCalcRet = null;

			foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
			{
				if (( unitPriceCalcRetWk.UnitPriceKind == ( (int)unitPriceKind ).ToString() ) &&
						( unitPriceCalcRetWk.GoodsNo == unitPriceCalcParam.GoodsNo ) &&
						( unitPriceCalcRetWk.GoodsMakerCd == unitPriceCalcParam.GoodsMakerCd ))
				{
					unitPriceCalcRet = unitPriceCalcRetWk.Clone();
				}
			}

			return unitPriceCalcRet;
		}

        /// <summary>
        /// 掛率データテーブルフィルター文字列生成
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="unitPriceCalcParam">単価算出パラメータ</param>
        /// <param name="rateSettingDivide">掛率設定区分</param>
        /// <returns></returns>
        private static Rate MakeRateFilter(string sectionCode, UnitPriceKind unitPriceKind, UnitPriceCalcParam unitPriceCalcParam, string rateSettingDivide)
        {
            Rate rate = new Rate();

            // 掛率設定区分に従って設定有無を判断してフィルター用の掛率マスタクラスを生成
            rate.SectionCode = sectionCode;
            rate.UnitPriceKind = ( (int)unitPriceKind ).ToString();
            rate.RateSettingDivide = rateSettingDivide;
            rate.GoodsMakerCd = RateAcs.IsMakerSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsMakerCd : 0;
            rate.GoodsNo = RateAcs.IsGoodsNoSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsNo : string.Empty;
            rate.GoodsRateRank = RateAcs.IsGoodsRateRankSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsRateRank : string.Empty;
            rate.GoodsRateGrpCode = RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsRateGrpCode : 0;
            rate.BLGroupCode = RateAcs.IsBLGroupCodeSetting(rateSettingDivide) ? unitPriceCalcParam.BLGroupCode : 0;
            rate.BLGoodsCode = RateAcs.IsBLGoodsSetting(rateSettingDivide) ? unitPriceCalcParam.BLGoodsCode : 0;
            rate.CustomerCode = RateAcs.IsCustomerSetting(rateSettingDivide) ? unitPriceCalcParam.CustomerCode : 0;
            rate.CustRateGrpCode = RateAcs.IsCustRateGrpSetting(rateSettingDivide) ? unitPriceCalcParam.CustRateGrpCode : 0;
            rate.SupplierCd = RateAcs.IsSupplierSetting(rateSettingDivide) ? unitPriceCalcParam.SupplierCd : 0;
            rate.LotCount = unitPriceCalcParam.CountFl;

            return rate;
        }


		/// <summary>
		/// 商品構成情報検索処理
		/// </summary>
		/// <param name="goodsUnitDataList">商品構成情報リスト</param>
		/// <param name="unitPriceCalcParam">単価算出パラメータ</param>
		/// <returns>商品構成情報オブジェクト</returns>
		private GoodsUnitData SearchGoodsUnitData( List<GoodsUnitData> goodsUnitDataList, UnitPriceCalcParam unitPriceCalcParam )
		{
			GoodsUnitData retGoodsUnitData = null;

			foreach (GoodsUnitData goodsUnitDataWk in goodsUnitDataList)
			{
				if (( goodsUnitDataWk.GoodsNo == unitPriceCalcParam.GoodsNo ) && ( goodsUnitDataWk.GoodsMakerCd == unitPriceCalcParam.GoodsMakerCd ))
				{
					retGoodsUnitData = goodsUnitDataWk;
				}
			}

			return retGoodsUnitData;
		}

		#endregion

        /// <summary>
        /// ログ出力(DEBUG)処理
        /// </summary>
        /// <param name="pMsg">メッセージ</param>
        public static void LogWrite(string pMsg)
        {
#if LOG
			System.IO.FileStream _fs;										// ファイルストリーム
			System.IO.StreamWriter _sw;										// ストリームwriter
            _fs = new System.IO.FileStream("DCKHN01060C.Log", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
			_sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
			DateTime edt = DateTime.Now;
			//yyyy/MM/dd hh:mm:ss
			_sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
			if (_sw != null)
				_sw.Close();
			if (_fs != null)
				_fs.Close();
#endif
        }

	}

}