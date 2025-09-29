using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 単価算出クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 掛率に従って仕入単価の算出を行います。（流用元:UI側単価算出モジュール）</br>
	/// <br>Programmer	: 22008　長内 数馬</br>
    /// <br>Date		: 2009.04.13</br>
    /// <br></br>
    /// <br>Note		: 棚卸準備処理_障害対応 該当する単価設定が無い場合、空データを追加するよう変更</br>
    /// <br>Programmer	: 30365　宮津 銀次郎</br>
    /// <br>Date		: 2012/05/21</br>
    /// <br></br>
    /// <br>Note		: 掛率マスタの該当件数が0でも、空の結果を返すよう変更</br>
    /// <br>Programmer	: 30365　宮津 銀次郎</br>
    /// <br>Date		: 2012/06/08</br>
    /// <br>Note		: Redmine#31103棚卸準備処理の速度改良の対応</br>
    /// <br>Programmer	: 凌小青</br>
    /// <br>Date		: 2012/07/10</br>
    /// <br>Update Note: 2013/05/06 yangyi</br>
    /// <br>管理番号   : 10801804-00 PM1301E(速度調査）</br>
    /// <br>           : Redmine#35493 　棚卸準備処理で、掛率マスタの件数が多い時に、処理時間が長く、且つサーバー負荷が高くなる(#1902)</br>
    /// <br>Update Note: 2013/06/07 wangl2</br>
    /// <br>管理番号   : 10801804-00 </br>
    /// <br>           : Redmine#35788 　「棚卸準備処理」の原価取得で掛率優先順位が評価されない（№1949）</br>
    /// <br>                              エラー発生時原価が登録されない件の対応でエラー処理追加(#8の件)</br>
    /// <br>Update Note: 2014/05/13 田建委</br>
    /// <br>管理番号   : 11070071-00 </br>
    /// <br>           : Redmine#36564 棚卸表示速度改善の対応</br>
    /// <br>Update Note: 2015/01/27 陳艶丹</br>
    /// <br>管理番号   : 11100008-00 </br>
    /// <br>           : Redmine#44581 竹之下部品/棚卸調査表にて仕入率項目を追加するよう変更</br>
    /// <br>Update Note: 2015/03/02 30940 河原林 一生</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>           : Redmine#44581 竹之下部品/棚卸調査表 仕入率が印字されない件の修正</br>
    /// <br>Update Note: 2015/03/06 caohh</br>
    /// <br>管理番号   : 11070149-00 </br>
    /// <br>           : Redmine#44951「掛率設定区分」より掛率優先管理をソートの処理を追加</br>
    /// <br>Update Note: 2015/03/23 xuyb</br>
    /// <br>管理番号   : 11070253-00 </br>
    /// <br>           : Redmine#44492の#99 売上月次更新の仕入単価・仕入率算出不具合の修正（#44951の#50のNo.2）対応</br>
    /// <br>Update Note: 2015/06/18 時シン</br>
    /// <br>管理番号   : 11101427-00 </br>
    /// <br>           : メイゴ レス値引一覧表用レス率（売価率）の算出</br>
    /// <br>Update Note: 2020/07/23 譚洪</br>
    /// <br>管理番号   : 11675035-00</br>
    /// <br>             PMKOBETSU-3551：棚卸準備処理を実行すると処理に失敗する現象の解除</br>
    /// <br>Update Note: 2020/10/20 譚洪</br>
    /// <br>管理番号   : 11675035-00</br>
    /// <br>             PMKOBETSU-3551：棚卸表示を実行すると処理に失敗する現象の解除</br>
    /// <br>Update Note: 2021/03/16 譚洪</br>
    /// <br>管理番号   : 11770024-00</br>
    /// <br>             PMKOBETSU-3551 棚卸準備処理と棚卸表示の障害対応</br> 
    /// <br>           : ①GoodsUnitDataの企業コードが空の件</br>
    /// <br>           : ②掛率優先管理マスタの拠点指定が【全社共通】の場合、拠点分の掛率データを使用されてしまう件</br>
    /// <br>           : ③拠点分の単品設定の掛率データがあり、掛率優先管理マスタに[6A]が存在しない場合、拠点分の単品設定の掛率データを使用されてしまう件</br>
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

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members

        /// <summary>掛率設定区分（メーカー表示区分値）</summary>
        private readonly List<string> ctRATEDIVVALUE_Maker = new List<string>(new string[] { "A", "B", "C", "D", "E", "F", "G", "K" });
        /// <summary>掛率設定区分（商品コード,商品名表示区分値）</summary>
        private readonly List<string> ctRATEDIVVALUE_Goods = new List<string>(new string[] { "A" });
        /// <summary>掛率設定区分（層別表示区分値）</summary>
        private readonly List<string> ctRATEDIVVALUE_GoodsRateRank = new List<string>(new string[] { "B", "C", "G" });
        /// <summary>掛率設定区分（商品掛率グループ表示区分値）</summary>
        private readonly List<string> ctRATEDIVVALUE_GoodsRateGrpCode = new List<string>(new string[] { "F", "J" });
        /// <summary>掛率設定区分（BLグループコード）</summary>
        private readonly List<string> ctRATEDIVVALUE_BLGroupCode = new List<string>(new string[] { "C", "E", "I" });
        /// <summary>掛率設定区分（BL商品表示区分値）</summary>
        private readonly List<string> ctRATEDIVVALUE_BLGoods = new List<string>(new string[] { "B", "D", "H" });
        /// <summary>掛率設定区分（得意先表示区分値）</summary>
        private readonly List<string> ctRATEDIVVALUE_Customer = new List<string>(new string[] { "1", "2" });
        /// <summary>掛率設定区分（得意先掛率GR表示区分値）</summary>
        private readonly List<string> ctRATEDIVVALUE_CustRateGrp = new List<string>(new string[] { "3", "4" });
        /// <summary>掛率設定区分（仕入先表示区分値）</summary>
        private readonly List<string> ctRATEDIVVALUE_SupplierCd = new List<string>(new string[] { "1", "3", "5" });
        //private int _ratePriorityDiv = 0; // 拠点優先 // ADD caohh 2015/03/06 for Redmine#44951  // DEL xuyb 2015/03/23 for Redmine#44492
        private Dictionary<string, int> _ratePriorityDivDic = null;  // 企業別拠点優先区分  // ADD xuyb 2015/03/23 for Redmine#44492
        // --- ADD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
        /// <summary>単品掛率</summary>
        private const string ctRateSettingDivByGoodsNo = "6A";
        /// <summary>DICキーフォーマット</summary>
        private const string ctDicKeyFmt = "{0}-{1:D4}-{2}";
        // --- ADD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
        # endregion

        // ===  ================================================================================== //
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

        }

		# endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region■Public Methods

		#region 原価単価計算処理
		/// <summary>
		/// 掛率を使用して原価単価を算出します。
		/// </summary>
		/// <param name="unitPriceCalcParam">単価計算パラメータオブジェクト</param>
		/// <param name="goodsUnitData">商品連結データオブジェクト</param>
		/// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
		public void CalculateUnitCost( UnitPriceCalcParamWork unitPriceCalcParam, GoodsUnitDataWork goodsUnitData, out List<UnitPriceCalcRetWork> unitPriceCalcRetList )
		{
            unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();

            this.CalculateUnitPriceProc(UnitPriceKind.UnitCost, unitPriceCalcParam, goodsUnitData, ref unitPriceCalcRetList);
		}

        /// <summary>
        /// 掛率を使用して原価単価を算出します。
        /// </summary>
        /// <param name="unitPriceCalcParamList">単価計算パラメータオブジェクトリスト</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        public void CalculateUnitCost( List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, out List<UnitPriceCalcRetWork> unitPriceCalcRetList )
        {
            unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();

            this.CalculateUnitPriceProc(UnitPriceKind.UnitCost, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
        }

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
        /// <param name="stockProcMoneyList">仕入金額処理区分設定マスタ</param>
        /// <param name="fracProcUnit">端数処理単位（未設定時は金額処理区分設定マスタから取得）</param>
		/// <param name="fracProcCd">端数処理区分（未設定時は金額処理区分設定マスタから取得）</param>
		/// <param name="unitPriceTaxExc">単価（税抜き）</param>
		/// <param name="unitPriceTaxInc">単価（税込み）</param>
		public void CalculateUnitPriceByRate( UnitPriceKind unitPriceKind, UnitPrcCalcDiv unitPrcCalcDiv, int totalAmountDispWayCd, int ttlAmntDspRateDivCd, int fractionProcCode, int taxationCode, double stdPrice, double taxRate, double taxFracProcUnit, int taxFracProcCd, double rate, List<StockProcMoneyWork> stockProcMoneyList,  ref  double fracProcUnit, ref int fracProcCd, out double unitPriceTaxExc, out double unitPriceTaxInc )
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

            this.CalculateUnitPriceByRate(unitPriceKind, fractionProcCode, taxationCodeWk, stdPriceWk, taxRate, taxFracProcUnit, taxFracProcCd, rate, stockProcMoneyList, ref fracProcUnit, ref fracProcCd, out unitPriceTaxExc, out unitPriceTaxInc);
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
        private void CalculateUnitPriceProc( UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList )
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
		private void CalculateUnitPriceProc( List<UnitPriceKind> unitPriceKindList, UnitPriceCalcParamWork unitPriceCalcParam, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList )
		{
			// 価格リストが無い場合は処理しない
			if (( goodsUnitData == null ) || ( goodsUnitData.GoodsNo != unitPriceCalcParam.GoodsNo ) || ( goodsUnitData.GoodsMakerCd != unitPriceCalcParam.GoodsMakerCd ))
			{
				return;
			}
			List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>();
			unitPriceCalcParamList.Add(unitPriceCalcParam);
			List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();

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
        private void CalculateUnitPriceProc( UnitPriceKind unitPriceKind, List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList )
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
		private void CalculateUnitPriceProc( List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList )
		{
            LogWrite(string.Format("単価算出 開始 {0}件:", unitPriceCalcParamList.Count));

            // パラメータリスト、商品連結データオブジェクトリストが無ければ処理しない
			if (( unitPriceCalcParamList == null ) || ( unitPriceCalcParamList.Count == 0 ) || ( goodsUnitDataList == null ) || ( goodsUnitDataList.Count == 0 ))
			{
				return;

            }
            //企業コード取得
            string enterpriseCode = (goodsUnitDataList[0] as GoodsUnitDataWork).EnterpriseCode;

            LogWrite("仕入金額処理区分読み込み");


            //仕入金額処理区分マスタ読み込み
            List<StockProcMoneyWork> stockProcMoneyList = this.SearchStockProcMoney(enterpriseCode);


            LogWrite("掛率読み込み");
            //優先管理読み込み
            List<RateProtyMngWork> rateProtyMngAllList = SearchRateProtyMng(enterpriseCode);//ADD on 2012/07/10 for Redmine#31103
            // 掛率マスタの読み込み
            List<RateWork> rateList;
            //int status = this.SearchRate(enterpriseCode, unitPriceKindList, unitPriceCalcParamList, out rateList);//DEL on 2012/07/10 for Redmine#31103
            int status = this.SearchRate(enterpriseCode, unitPriceKindList, unitPriceCalcParamList, out rateList, rateProtyMngAllList);//ADD on 2012/07/10 for Redmine#31103

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
                //this.CalculateUnitCostPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, stockProcMoneyList, ref unitPriceCalcRetList);/DEL on 2012/07/10 for Redmine#31103
                this.CalculateUnitCostPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, stockProcMoneyList, ref unitPriceCalcRetList, rateProtyMngAllList);//ADD on 2012/07/10 for Redmine#31103
            }

            LogWrite("単価算出 終了");
        }

		/// <summary>
		/// 原価単価計算処理
		/// </summary>
		/// <param name="unitPriceCalcParamList">単価算出パラメータリスト</param>
		/// <param name="goodsUnitDataList">商品構成データリスト</param>
        /// <param name="rateList">掛率リスト</param>
        /// <param name="stockProcMoneyList">仕入金額処理区分設定マスタ</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <param name="rateProtyMngAllList">掛率優先管理リスト</param>
        /// <br>UpdateNote : Redmine#31103棚卸準備処理の速度改良の対応</br>
        /// <br>Programer  : 凌小青</br>
        /// <br>Date       : 2012/07/10</br>
        //private void CalculateUnitCostPriceProc(List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList,ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)//DEL on 2012/07/10 for Redmine#31103
        private void CalculateUnitCostPriceProc(List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList, List<RateProtyMngWork> rateProtyMngAllList)//ADD on 2012/07/10 for Redmine#31103
		{
            List<RateProtyMngWork> rateProtyMngList = null;
        
			foreach (UnitPriceCalcParamWork unitPriceCalcParam in unitPriceCalcParamList)
			{
                // 消費税の端数処理単位、端数処理区分を取得
				double taxFractionProcUnit;
				int taxFractionProcCd;
				this.GetStockFractionProcInfo(FractionProcMoney.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.StockCnsTaxFrcProcCd, 0, stockProcMoneyList,out taxFractionProcUnit, out taxFractionProcCd);

                UnitPrcCalcDiv unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;

				GoodsUnitDataWork goodsUnitData = SearchGoodsUnitData(goodsUnitDataList, unitPriceCalcParam);
				GoodsPriceUWork goodsPrice;
				bool calcPrice = false;
				this.GetPrice(unitPriceCalcParam.PriceApplyDate, goodsUnitData, out goodsPrice);

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

                    // 原単価が直接セットされている場合
                    if (goodsPrice.SalesUnitCost != 0)
                    {
                        calcPrice = true;

                        unitPrcCalcDiv = UnitPrcCalcDiv.Price;

                        // 商品の課税方式に従って分岐
                        switch (goodsUnitData.TaxationDivCd)
                        {
                            case (int)CalculateTax.TaxationCode.TaxInc:
                                unitPriceTaxInc = goodsPrice.SalesUnitCost;
                                unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxInc);
                                break;
                            case (int)CalculateTax.TaxationCode.TaxExc:
                                unitPriceTaxExc = goodsPrice.SalesUnitCost;
                                unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxExc);
                                break;
                            case (int)CalculateTax.TaxationCode.TaxNone:
                                unitPriceTaxExc = goodsPrice.SalesUnitCost;
                                unitPriceTaxInc = goodsPrice.SalesUnitCost;
                                break;
                        }
                        // 転嫁方式「非課税」時は、税込単価に税抜き単価をセット
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            unitPriceTaxInc = unitPriceTaxExc;
                        }
                    }
                    // 仕入率がセットされていて、定価がゼロ以外
                    else if ((goodsPrice.StockRate != 0) && (goodsPrice.ListPrice != 0))
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
                            stockProcMoneyList,
                            ref unPrcFracProcUnit,
                            ref unPrcFracProcDiv,
                            out unitPriceTaxExc,
                            out unitPriceTaxInc);
                    }

                    // ここまでで原価計算された場合は結果をセット
                    if (calcPrice)
                    {
                        UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                        unitPriceCalcRet.UnitPriceKind = ((int)UnitPriceKind.UnitCost).ToString();
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

                        unitPriceCalcRetList.Add(unitPriceCalcRet);
                    }
                    else
                    {
                        // 掛率優先管理情報を取得する
                        //rateProtyMngList = this.GetRateProtyMngList(goodsUnitData.EnterpriseCode, unitPriceCalcParam.SectionCode, UnitPriceKind.UnitCost);//DEL on 2012/07/10 for Redmine#31103
                        rateProtyMngList = this.GetRateProtyMngList(rateProtyMngAllList, goodsUnitData.EnterpriseCode, unitPriceCalcParam.SectionCode, UnitPriceKind.UnitCost);//ADD on 2012/07/10 for Redmine#31103

                        // -- UPD 2012/06/08 ------------------------------------->>>>
                        //if (rateProtyMngList != null && rateProtyMngList.Count > 0)
                        if (rateProtyMngList != null)
                        // -- UPD 2012/06/08 -------------------------------------<<<<
                        {
                            this.CalculateUnitPriceByRateList(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList);
                        }

                    }
                }
                // -- ADD 2012/05/21 ------------------------------>>>>
                else
                {
                    UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                    unitPriceCalcRet.UnitPriceKind = ((int)UnitPriceKind.UnitCost).ToString();       // 単価種類
                    unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;             // 商品コード
                    unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;   // メーカーコード
                    unitPriceCalcRet.SupplierCd = 0;                                   // 仕入先コード

                    unitPriceCalcRetList.Add(unitPriceCalcRet);
                }
                // -- ADD 2012/05/21 ------------------------------<<<<
			}
		}

		/// <summary>
		/// 掛率優先順位、掛率マスタによる単価計算
		/// </summary>
		/// <param name="unitPriceKind">単価種類</param>
		/// <param name="unitPriceCalcParam">単価計算パラメータ</param>
		/// <param name="rateProtyMngList">掛率優先管理マスタリスト</param>
        /// <param name="rateList">掛率リスト</param>
        /// <param name="stockProcMoneyList">仕入金額処理区分設定マスタ</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
		/// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        private void CalculateUnitPriceByRateList(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, List<RateProtyMngWork> rateProtyMngList, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList,GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            //if (rateList == null || rateList.Count == 0) return; // DEL 2012/06/08
            bool breakFlg = false; // ADD 2012/05/21

            // 掛率優先順位順に単価計算する
            try
            {
                foreach (RateProtyMngWork rateProtyMng in rateProtyMngList)
                {
                    if (this.CalculateUnitPrice(unitPriceKind, unitPriceCalcParam, rateProtyMng.SectionCode, rateProtyMng, rateList, stockProcMoneyList ,goodsUnitData, ref unitPriceCalcRetList))
                    {
                        breakFlg = true; // ADD 2012/05/21
                        break;
                    }
                }
            }
            finally
            {
                // -- ADD 2012/05/21 ------------------------------------>>>>
                if (breakFlg == false)
                {
                    UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                    unitPriceCalcRet.UnitPriceKind = ((int)unitPriceKind).ToString();  // 単価種類
                    unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;             // 商品コード
                    unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;   // メーカーコード
                    unitPriceCalcRet.SupplierCd = 0;                                   // 仕入先コード

                    unitPriceCalcRetList.Add(unitPriceCalcRet);
                }
                // -- ADD 2012/05/21 ------------------------------------<<<<
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
        /// <param name="stockProcMoneyList">仕入金額処理区分設定マスタ</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="unitPriceCalcRetList">単価算出結果オブジェクトリスト</param>
        /// <returns>True:単価算出成功、False:単価算出失敗</returns>
        private bool CalculateUnitPrice(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, string sectionCode, RateProtyMngWork rateProtyMng, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            #region [ 対象の掛率マスタを抽出 ]
            RateWork rateCndtn = MakeRateFilter(sectionCode, unitPriceKind, unitPriceCalcParam, rateProtyMng.RateSettingDivide);

            if (rateList == null || rateList.Count == 0) return false; //ADD 2012/06/08
            List<RateWork> findList = rateList.FindAll(delegate(RateWork rate2)
                                        {
                                            if ((rate2.UnitPriceKind.Trim() == rateCndtn.UnitPriceKind.Trim()) &&
                                                (rate2.RateSettingDivide.Trim() == rateCndtn.RateSettingDivide.Trim()) &&
                                                (rate2.GoodsNo == rateCndtn.GoodsNo) &&
                                                (rate2.SectionCode.Trim() == rateCndtn.SectionCode.Trim()) &&
                                                (rate2.GoodsMakerCd == rateCndtn.GoodsMakerCd) &&
                                                (rate2.GoodsRateRank.Trim() == rateCndtn.GoodsRateRank.Trim()) &&
                                                (rate2.GoodsRateGrpCode == rateCndtn.GoodsRateGrpCode) &&
                                                (rate2.BLGroupCode == rateCndtn.BLGroupCode) &&
                                                (rate2.BLGoodsCode == rateCndtn.BLGoodsCode) &&
                                                (rate2.CustomerCode == rateCndtn.CustomerCode) &&
                                                (rate2.CustRateGrpCode == rateCndtn.CustRateGrpCode) &&
                                                (rate2.SupplierCd == rateCndtn.SupplierCd) &&
                                                (rate2.LotCount >= rateCndtn.LotCount))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });

            if (findList == null || findList.Count == 0) return false;

            findList.Sort(new FractionProcMoney.RateComparer());

            #endregion

            double stdPrice = 0;			// 基準価格
            double stdPriceWk = stdPrice;	// 基準価格（実際の計算用の値）
            double unitPriceTaxExc = 0;		// 税抜き単価
            double unitPriceTaxInc = 0;		// 税込み単価
            int fractionProcCode = 0;		// 端数処理コード(0:全社)
            int taxationCode = unitPriceCalcParam.TaxationDivCd;	// 課税方式
            int openPriceDiv = 0;
            UnitPrcCalcDiv unitPrcCalcDiv = UnitPrcCalcDiv.Price;
            double count = (unitPriceCalcParam.CountFl == 0) ? 1 : Math.Abs(unitPriceCalcParam.CountFl);	// 数量(0の場合は1つで計算、0以外は絶対値)

            //--------------------------------------------------
            // 端数処理コードの決定
            //--------------------------------------------------
            // 定価、売上単価
            if ((unitPriceKind == UnitPriceKind.ListPrice) || (unitPriceKind == UnitPriceKind.SalesUnitPrice))
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

            if ((unitPriceCalcParam.ConsTaxLayMethod != 9) &&                                 // 転嫁方式「非課税」を除く
                (unitPriceKind == UnitPriceKind.SalesUnitPrice) &&                            // 売上単価
                (unitPriceCalcParam.TotalAmountDispWayCd == 1) &&								// 総額表示する
                (unitPriceCalcParam.TtlAmntDspRateDivCd == 0) &&								// 掛率適用区分「0：税込単価」
                (unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc))	// 外税
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxInc;	// 内税と同じ計算をする
            }

            // 先頭行のデータが対象データ
            RateWork rate = findList[0];

            // 掛率マスタの端数処理単位、端数処理区分は定価計算時のみ使用する（0にすると、金額処理区分設定から取得）
            double unPrcFracProcUnit = (unitPriceKind == UnitPriceKind.ListPrice) ? rate.UnPrcFracProcUnit : 0;
            int unPrcFracProcDiv = (unitPriceKind == UnitPriceKind.ListPrice) ? rate.UnPrcFracProcDiv : 0;

            // 消費税の端数処理単位、端数処理区分
            double taxFractionProcUnit;
            int taxFractionProcCd;

            double rateVal = 0;                 // 掛率

            // 価格情報の取得
            GoodsPriceUWork goodsPrice;
            this.GetPrice(unitPriceCalcParam.PriceApplyDate, goodsUnitData, out goodsPrice);

            if (goodsPrice == null) goodsPrice = new GoodsPriceUWork();

            // 単価種類により処理分岐（単価種類毎の優先順位に従って計算）
            // ※計算方法は同一ですが、仕様変更や追加された場合を考慮して単価種類毎に分けておきます
            switch (unitPriceKind)
            {
                #region ●原価
                case UnitPriceKind.UnitCost:

                    // 仕入消費税の端数処理単位、端数処理区分を取得
                    this.GetStockFractionProcInfo(FractionProcMoney.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.StockCnsTaxFrcProcCd, 0, stockProcMoneyList, out taxFractionProcUnit, out taxFractionProcCd);

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
                        if ((openPriceDiv == 1) && (stdPrice == 0)) return false;

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
                                                     stockProcMoneyList,
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

            UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

            unitPriceCalcRet.UnitPriceKind = ((int)unitPriceKind).ToString();				// 単価種類
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
        /// <param name="stockProcMoneyList">仕入金額処理区分設定マスタ</param>
        /// <param name="fracProcUnit">単価端数処理単位</param>
        /// <param name="fracProcCd">単価端数処理区分</param>
        /// <param name="unitPriceTaxExc">税抜き単価</param>
        /// <param name="unitPriceTaxInc">税込み単価</param>
        private void CalculateUnitPriceByRate( UnitPriceKind unitPriceKind, int fractionProcCode, int taxationCode, double stdPrice, double taxRate, double taxFracProcUnit, int taxFracProcCd, double rate, List<StockProcMoneyWork> stockProcMoneyList, ref  double fracProcUnit, ref int fracProcCd, out double unitPriceTaxExc, out double unitPriceTaxInc )
        {
            unitPriceTaxExc = 0;
            unitPriceTaxInc = 0;

            // 外税の場合
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                // ①税抜き単価 = 基準単価から掛率計算した結果
                unitPriceTaxExc = CalclateUnitPriceByRate(unitPriceKind, fractionProcCode, stdPrice, rate, stockProcMoneyList, ref fracProcUnit, ref fracProcCd);

                // ②税込み単価 = 税抜き単価 + 税抜き単価の消費税
                unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceTaxExc);
            }
            // 内税の場合
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                // ①税込み単価 = 基準単価から掛率計算した結果
                unitPriceTaxInc = CalclateUnitPriceByRate(unitPriceKind, fractionProcCode, stdPrice, rate, stockProcMoneyList, ref fracProcUnit, ref fracProcCd);

                // ②税抜き単価 = 税込み単価 - 税込み単価の消費税
                unitPriceTaxExc = (double)( (decimal)unitPriceTaxInc - (decimal)CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceTaxInc) );
            }
            // 非課税
            else
            {
                // ①税抜き単価 = 基準単価から掛率計算した結果
                unitPriceTaxExc = CalclateUnitPriceByRate(unitPriceKind, fractionProcCode, stdPrice, rate, stockProcMoneyList, ref fracProcUnit, ref fracProcCd);

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
        /// <param name="stockProcMoneyList">仕入金額処理区分設定マスタ</param>
        /// <param name="fracProcUnit">端数処理単位</param>
		/// <param name="fracProcCd">端数処理区分</param>
		/// <returns></returns>
		private double CalclateUnitPriceByRate( UnitPriceKind unitPriceKind, int fractionProcCode, double stdPrice, double rate, List<StockProcMoneyWork> stockProcMoneyList, ref double fracProcUnit, ref int fracProcCd )
		{
			if (( rate == 0 ) || ( stdPrice == 0 )) return 0;

			double unitPrice = ( rate < 0 ) ? stdPrice * ( 100 + rate ) * 0.01 : stdPrice * rate * 0.01;

			SettingFracProcInfo(unitPriceKind, fractionProcCode, unitPrice, stockProcMoneyList ,ref fracProcUnit, ref fracProcCd);

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
		/// 商品連結オブジェクトより、対象日の価格情報を取得します。
		/// </summary>
		/// <param name="targetDay">対象日</param>
		/// <param name="goodsUnitData">商品連結データオブジェクト</param>
		/// <param name="goodsPrice">価格情報オブジェクト</param>
		private void GetPrice( DateTime targetDay, GoodsUnitDataWork goodsUnitData, out GoodsPriceUWork goodsPrice )
		{
			goodsPrice = null;

            if (goodsUnitData == null) return;

            List<GoodsPriceUWork> retList = null;

            if (goodsUnitData.PriceList == null)
            {
                int status = SearchGoodsPrice(goodsUnitData, out retList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return;
            }
            else
            {
                //価格リストがGoodsUnitDataWorkにすでにセットされていた場合は、再読み込みを行わない。
                retList = new List<GoodsPriceUWork>();
                retList.AddRange((GoodsPriceUWork[])goodsUnitData.PriceList.ToArray(typeof(GoodsPriceUWork)));
            }

			List<GoodsPriceUWork> goodsPriceList = retList;

			DateTime dateWk = DateTime.MinValue;
			foreach (GoodsPriceUWork goodsPriceWk in goodsPriceList)
			{
				if (( goodsPriceWk.PriceStartDate <= targetDay ) && ( goodsPriceWk.PriceStartDate > dateWk ))
				{
					dateWk = goodsPriceWk.PriceStartDate;
                    goodsPrice = new GoodsPriceUWork();
                    goodsPrice.CreateDateTime = goodsPriceWk.CreateDateTime;
                    goodsPrice.UpdateDateTime = goodsPriceWk.UpdateDateTime;
                    goodsPrice.EnterpriseCode = goodsPriceWk.EnterpriseCode;
                    goodsPrice.FileHeaderGuid = goodsPriceWk.FileHeaderGuid;
                    goodsPrice.UpdEmployeeCode = goodsPriceWk.UpdEmployeeCode;
                    goodsPrice.UpdAssemblyId1 = goodsPriceWk.UpdAssemblyId1;
                    goodsPrice.UpdAssemblyId2 = goodsPriceWk.UpdAssemblyId2;
                    goodsPrice.LogicalDeleteCode = goodsPriceWk.LogicalDeleteCode;
                    goodsPrice.GoodsMakerCd = goodsPriceWk.GoodsMakerCd;
                    goodsPrice.GoodsNo = goodsPriceWk.GoodsNo;
                    goodsPrice.PriceStartDate = goodsPriceWk.PriceStartDate;
                    goodsPrice.ListPrice = goodsPriceWk.ListPrice;
                    goodsPrice.SalesUnitCost = goodsPriceWk.SalesUnitCost;
                    goodsPrice.StockRate = goodsPriceWk.StockRate;
                    goodsPrice.OpenPriceDiv = goodsPriceWk.OpenPriceDiv;
                    goodsPrice.OfferDate = goodsPriceWk.OfferDate;
                    goodsPrice.UpdateDate = goodsPriceWk.UpdateDate;
				}   
			}
		}

        /// <summary>
        /// 商品価格マスタ検索
        /// </summary>
        /// <param name="goodsUnitData">商品リスト</param>
        /// <param name="goodsPriceList">価格リスト</param>
        private int SearchGoodsPrice(GoodsUnitDataWork goodsUnitData, out List<GoodsPriceUWork> goodsPriceList)
        {
            int status = 0;
            goodsPriceList = new List<GoodsPriceUWork>();

            GoodsPriceUDB goodsPriceUDB = new GoodsPriceUDB();

            object retobj = null;
            GoodsPriceUWork paraWork = new GoodsPriceUWork();
            paraWork.EnterpriseCode = goodsUnitData.EnterpriseCode;
            paraWork.GoodsNo = goodsUnitData.GoodsNo;
            paraWork.GoodsMakerCd = goodsUnitData.GoodsMakerCd;

            ArrayList paraList = new ArrayList();
            paraList.Add(paraWork);

            status = goodsPriceUDB.Search(out retobj, paraList, 0, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList list = retobj as ArrayList;
                goodsPriceList.AddRange((GoodsPriceUWork[])list.ToArray(typeof(GoodsPriceUWork)));

                //価格リストをGoodsUnitDataに退避
                goodsUnitData.PriceList = list;
            }

            return status;

        }

        /// <summary>
        /// 仕入金額端数処理区分設定検索
        /// </summary>
        private List<StockProcMoneyWork> SearchStockProcMoney(string _enterpriseCode)
        {
            List<StockProcMoneyWork> _stockProcMoneyList = new List<StockProcMoneyWork>();

            StockProcMoneyDB stockProcMoneyDB = new StockProcMoneyDB();

            StockProcMoneyWork paraWork = new StockProcMoneyWork();
            paraWork.EnterpriseCode = _enterpriseCode;
            paraWork.FracProcMoneyDiv = -1;
            paraWork.FractionProcCode = -1;

            ArrayList paraList = new ArrayList();
            paraList.Add(paraWork);

            object retobj = null;

            int status = stockProcMoneyDB.Search(out retobj, paraList, 0 ,0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList list = retobj as ArrayList;

                _stockProcMoneyList.AddRange((StockProcMoneyWork[])list.ToArray(typeof(StockProcMoneyWork)));

                _stockProcMoneyList.Sort(new FractionProcMoney.StockProcMoneyComparer());
            }

            return _stockProcMoneyList;
        }

        /// <summary>
        /// 掛率優先管理検索
        /// </summary>
        private List<RateProtyMngWork> SearchRateProtyMng(string _enterpriseCode)
        {
            List<RateProtyMngWork> _rateProtyMngAllList = new List<RateProtyMngWork>();

            RateProtyMngDB rateProtyMngDB = new RateProtyMngDB();

            ArrayList paralist = new ArrayList();
            RateProtyMngWork paraWork = new RateProtyMngWork();
            paraWork.EnterpriseCode = _enterpriseCode;

            paralist.Add(paraWork);

            ReadComCompanyInf(_enterpriseCode);// ADD caohh 2015/03/06 for Redmine#44951

            object rateProtyMngWorkList = null;

            //掛率優先管理の読み込み
            rateProtyMngDB.Search(out rateProtyMngWorkList, paralist, 0 , 0);

            if (rateProtyMngWorkList != null)
            {
                ArrayList list = rateProtyMngWorkList as ArrayList;

                _rateProtyMngAllList = new List<RateProtyMngWork>();
                _rateProtyMngAllList.AddRange((RateProtyMngWork[])list.ToArray(typeof(RateProtyMngWork)));

                // 拠点、単価種類、優先順位でソート
                _rateProtyMngAllList.Sort(new FractionProcMoney.RateProtyMngComparer());
            }
            return _rateProtyMngAllList;
        }

        /// <summary>
        /// 掛率優先管理情報のリストを取得します。
        /// <br>UpdateNote : Redmine#31103棚卸準備処理の速度改良の対応</br>
        /// <br>Programer  : 凌小青</br>
        /// <br>Date       : 2012/07/10</br>
        /// <br>Update Note: 2015/03/23 xuyb</br>
        /// <br>管理番号   : 11070253-00 </br>
        /// <br>           : Redmine#44492の#99 売上月次更新の仕入単価・仕入率算出不具合の修正（#44951の#50のNo.2）対応</br>
        /// </summary>
        /// <returns></returns>
        //private List<RateProtyMngWork> GetRateProtyMngList(string _enterpriseCode, string sectionCode, UnitPriceKind unitPriceKind)//DEL on 2012/07/10 for Redmine#31103
        private List<RateProtyMngWork> GetRateProtyMngList(List<RateProtyMngWork> _rateProtyMngAllList, string _enterpriseCode, string sectionCode, UnitPriceKind unitPriceKind)//ADD  on 2012/07/10 for Redmine#31103
        {
            //----DEL on 2012/07/10 for Redmine#31103 ------->>>>>>
            ////優先管理読み込み
            //List<RateProtyMngWork> _rateProtyMngAllList =  SearchRateProtyMng(_enterpriseCode);
            //----DEL on 2012/07/10 for Redmine#31103 -------<<<<<<

            if (_rateProtyMngAllList == null || _rateProtyMngAllList.Count == 0) return null;

            // 対象拠点分の優先管理を取得
            List<RateProtyMngWork> _lastRateProtyMngList = _rateProtyMngAllList.FindAll(
                                                                    delegate(RateProtyMngWork rateProtyMng)
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
                    delegate(RateProtyMngWork rateProtyMng)
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

            // --------------------- ADD xuyb 2015/03/23 for Redmine#44492 --------------->>>>>
            // 掛け率優先区分は未設定場合
            if (this._ratePriorityDivDic == null ||
                (this._ratePriorityDivDic != null && !this._ratePriorityDivDic.ContainsKey(_enterpriseCode)))
            {
                ReadComCompanyInf(_enterpriseCode);
            }
            // --------------------- ADD xuyb 2015/03/23 for Redmine#44492 ---------------<<<<<
            // --- ADD caohh 2015/03/06 for Redmine#44951 ----->>>>>
            //if (this._ratePriorityDiv == 1)  // DEL xuyb 2015/03/23 for Redmine#44492
            if (this._ratePriorityDivDic[_enterpriseCode] == 1)  // 拠点優先 //ADD xuyb 2015/03/23 for Redmine#44492
            {
                _lastRateProtyMngList.Sort(new FractionProcMoney.RateProtyMngComparerUnitPriceKind());
            }
            // --- ADD caohh 2015/03/06 for Redmine#44951 -----<<<<<

            return _lastRateProtyMngList;

        }

        /// <summary>
        /// 掛率マスタを検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="unitPriceKindList">単価種類リスト</param>
        /// <param name="unitPriceCalcParamList">単価算出パラメータリスト</param>
        /// <param name="rateList">掛率リスト</param>
        /// <param name="rateProtyMngAllList">掛率優先管理リスト</param>
        /// <br>UpdateNote : Redmine#31103棚卸準備処理の速度改良の対応</br>
        /// <br>Programer  : 凌小青</br>
        /// <br>Date       : 2012/07/10</br>
        /// <returns>掛率検索ステータス</returns>
        //private int SearchRate(string enterpriseCode ,List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParamWork> unitPriceCalcParamList, out List<RateWork> rateList)//DEL on 2012/07/10 for Redmine#31103
        private int SearchRate(string enterpriseCode, List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParamWork> unitPriceCalcParamList, out List<RateWork> rateList, List<RateProtyMngWork> rateProtyMngAllList)//ADD on 2012/07/10 for Redmine#31103
        {
            RateDB rateDB = new RateDB();

            rateList = new List<RateWork>();
            List<RateProtyMngWork> rateProtyMngList = null;

            LogWrite("掛率 検索パラメータ作成");

            ArrayList paraList = new ArrayList();
            foreach (UnitPriceKind unitPriceKind in unitPriceKindList)
            {
                List<RateWork> kindRateList = new List<RateWork>();
                foreach (UnitPriceCalcParamWork unitPriceCalcParam in unitPriceCalcParamList)
                {
                    //rateProtyMngList = this.GetRateProtyMngList(enterpriseCode, unitPriceCalcParam.SectionCode, unitPriceKind); //DEL on 2012/07/10 for Redmine#31103
                    rateProtyMngList = this.GetRateProtyMngList(rateProtyMngAllList, enterpriseCode, unitPriceCalcParam.SectionCode, unitPriceKind); //ADD on 2012/07/10 for Redmine#31103

                    if (rateProtyMngList != null && rateProtyMngList.Count > 0)
                    {
                        this.MakeRateReadParam(unitPriceCalcParam, rateProtyMngList, ref kindRateList);
                    }
                }
                paraList.AddRange((RateWork[])kindRateList.ToArray());
            }

            LogWrite("掛率 Search パラメータ:" + rateList.Count.ToString());

            int status = -1;
            if (paraList.Count > 0)
            {
                object rateWorkList = null;

                status = rateDB.Search(out rateWorkList, paraList,0, 0);

                if (rateWorkList != null)
                {
                    ArrayList list = rateWorkList as ArrayList;

                    rateList.AddRange((RateWork[])list.ToArray(typeof(RateWork)));
                }
            }

            LogWrite("掛率取得終了");
            return status;
        }

		/// <summary>
		/// 掛率マスタの読み込みパラメータを生成します。
		/// </summary>
		/// <param name="unitPriceCalcParam">単価算出パラメータ</param>
        /// <param name="rateProtyMngList">掛率優先管理マスタリスト</param>
        /// <param name="rateList">掛率マスタリスト</param>
        private void MakeRateReadParam(UnitPriceCalcParamWork unitPriceCalcParam, List<RateProtyMngWork> rateProtyMngList, ref List<RateWork> rateList)
		{
            foreach (RateProtyMngWork rateProtyMng in rateProtyMngList)
            {
                // 掛率マスタを読み込む条件が全て入力されている場合のみ検索リストに追加
                if (CanCreateCheck(rateProtyMng.RateSettingDivide, unitPriceCalcParam))
                {
                    RateWork rate = CreateRateFromUnitPriceCalcParam((UnitPriceKind)rateProtyMng.UnitPriceKind, rateProtyMng.RateSettingDivide, rateProtyMng.SectionCode, unitPriceCalcParam);

                    RateWork findRate = rateList.Find(
                                        delegate(RateWork rate2)
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

                    rate.EnterpriseCode = rateProtyMng.EnterpriseCode;
                    rate.LotCount = -1;  // ロット数（-1:絞込み無し, -1以外:該当ロット数で絞り込み）
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
        /// <param name="stockProcMoneyList">仕入金額処理区分設定マスタ</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
		/// <param name="fractionProcCd">端数処理区分</param>
		private void SettingFracProcInfo( UnitPriceKind unitPriceKind, int fractionProcCode, double price, List<StockProcMoneyWork> stockProcMoneyList, ref double fractionProcUnit, ref int fractionProcCd )
		{
			if (fractionProcUnit == 0)
			{
				switch (unitPriceKind)
				{
					// 仕入単価
					case UnitPriceKind.UnitCost:
						{
							this.GetStockFractionProcInfo(FractionProcMoney.ctFracProcMoneyDiv_UnitPrice, fractionProcCode, price, stockProcMoneyList, out fractionProcUnit, out fractionProcCd);
							break;
						}
				}
			}
		}

		/// <summary>
		/// 仕入金額処理区分設定マスタより、対象金額に該当する端数処理単位、端数処理コードを取得します。
		/// </summary>
		/// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="price">対象金額</param>
        /// <param name="_stockProcMoneyList">仕入金額処理区分設定マスタ</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
		/// <param name="fractionProcCd">端数処理区分</param>
		private void GetStockFractionProcInfo( int fracProcMoneyDiv, int fractionProcCode, double price, List<StockProcMoneyWork> _stockProcMoneyList, out double fractionProcUnit, out int fractionProcCd )
		{
            fractionProcUnit = FractionProcMoney.GetDefaultFractionProcUnit(fracProcMoneyDiv);
            fractionProcCd = FractionProcMoney.GetDefaultFractionProcCd(fracProcMoneyDiv);

            if (_stockProcMoneyList == null || _stockProcMoneyList.Count == 0) return;

            List<StockProcMoneyWork> stockProcMoneyList = _stockProcMoneyList.FindAll(
                                        delegate(StockProcMoneyWork stockProcMoney)
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


        /// <summary>
        /// 単価種類、掛率設定区分、単価計算パラメータオブジェクトより、掛率マスタオブジェクトを生成します。
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="rateSettingDivide">掛率設定区分</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="unitPriceCalcParam">掛率計算パラメータ</param>
        /// <returns></returns>
        private RateWork CreateRateFromUnitPriceCalcParam(UnitPriceKind unitPriceKind, string rateSettingDivide, string sectionCode, UnitPriceCalcParamWork unitPriceCalcParam)
        {
            RateWork rate = new RateWork();

            rate.UnitPriceKind = ((int)unitPriceKind).ToString();
            rate.RateSettingDivide = rateSettingDivide;
            rate.SectionCode = sectionCode;
            rate.RateMngGoodsCd = GetRateMngCustCd(rateSettingDivide);
            rate.RateMngCustCd = GetRateMngCustCd(rateSettingDivide);
            rate.GoodsNo = IsGoodsNoSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsNo : "";
            rate.GoodsMakerCd = IsMakerSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsMakerCd : 0;
            rate.GoodsRateRank = IsGoodsRateRankSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsRateRank : "";
            rate.GoodsRateGrpCode = IsGoodsRateGrpCodeSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsRateGrpCode : 0;
            rate.BLGroupCode = IsBLGroupCodeSetting(rateSettingDivide) ? unitPriceCalcParam.BLGroupCode : 0;
            rate.BLGoodsCode = IsBLGoodsSetting(rateSettingDivide) ? unitPriceCalcParam.BLGoodsCode : 0;
            rate.CustomerCode = IsCustomerSetting(rateSettingDivide) ? unitPriceCalcParam.CustomerCode : 0;
            rate.CustRateGrpCode = IsCustRateGrpSetting(rateSettingDivide) ? unitPriceCalcParam.CustRateGrpCode : 0;
            rate.SupplierCd = IsSupplierSetting(rateSettingDivide) ? unitPriceCalcParam.SupplierCd : 0;

            return rate;
        }

        /// <summary>
        /// 掛率マスタを読み込む条件が設定されているかチェックします。
        /// </summary>
        /// <param name="rateSettingDivide"></param>
        /// <param name="unitPriceCalcParam"></param>
        /// <returns></returns>
        private bool CanCreateCheck(string rateSettingDivide, UnitPriceCalcParamWork unitPriceCalcParam)
        {
            if (((IsGoodsNoSetting(rateSettingDivide) && (string.IsNullOrEmpty(unitPriceCalcParam.GoodsNo.Trim())))) ||
                ((IsMakerSetting(rateSettingDivide) && (unitPriceCalcParam.GoodsMakerCd == 0))) ||
                ((IsGoodsRateRankSetting(rateSettingDivide) && (string.IsNullOrEmpty(unitPriceCalcParam.GoodsRateRank.Trim())))) ||
                ((IsGoodsRateGrpCodeSetting(rateSettingDivide) && (unitPriceCalcParam.GoodsRateGrpCode == 0))) ||
                ((IsBLGroupCodeSetting(rateSettingDivide) && (unitPriceCalcParam.BLGroupCode == 0))) ||
                ((IsBLGoodsSetting(rateSettingDivide) && (unitPriceCalcParam.BLGoodsCode == 0))) ||
                ((IsCustomerSetting(rateSettingDivide) && (unitPriceCalcParam.CustomerCode == 0))) ||
                ((IsCustRateGrpSetting(rateSettingDivide) && (unitPriceCalcParam.CustRateGrpCode == 0))) ||
                ((IsSupplierSetting(rateSettingDivide) && (unitPriceCalcParam.SupplierCd == 0))))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 得意先が掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public bool IsCustomerSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 0, 1, ctRATEDIVVALUE_Customer);
        }

        /// <summary>
        /// 得意先掛率設定GRが掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public bool IsCustRateGrpSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 0, 1, ctRATEDIVVALUE_CustRateGrp);
        }

        /// <summary>
        /// 仕入先が掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public bool IsSupplierSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 0, 1, ctRATEDIVVALUE_SupplierCd);
        }

        /// <summary>
        /// 商品コードが掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public bool IsGoodsNoSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_Goods);
        }

        /// <summary>
        /// メーカーが掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public bool IsMakerSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_Maker);
        }

        /// <summary>
        /// 層別が掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public bool IsGoodsRateRankSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_GoodsRateRank);
        }

        /// <summary>
        /// 商品掛率グループコードが掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public bool IsGoodsRateGrpCodeSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_GoodsRateGrpCode);
        }

        /// <summary>
        /// BLグループコードが掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public bool IsBLGroupCodeSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_BLGroupCode);
        }

        /// <summary>
        /// BL商品が掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public bool IsBLGoodsSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_BLGoods);
        }

        /// <summary>
        /// 対象文字列中に、比較対象リストに含まれる文字列が存在するかを取得します。
        /// </summary>
        /// <param name="target">対象文字列</param>
        /// <param name="startIndex">文字列中の比較文字開始位置</param>
        /// <param name="length">比較文字列の長さ</param>
        /// <param name="judgmentList">比較対象リスト</param>
        /// <returns>true:存在する</returns>
        private bool IsSetting(string target, int startIndex, int length, List<string> judgmentList)
        {
            bool ret = false;
            if (target.Length >= (startIndex + length))
            {
                if (judgmentList.Contains(target.Substring(startIndex, length))) ret = true;
            }
            return ret;
        }
        #endregion

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

		#endregion

        /// <summary>
        /// 掛率データテーブルフィルター文字列生成
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="unitPriceCalcParam">単価算出パラメータ</param>
        /// <param name="rateSettingDivide">掛率設定区分</param>
        /// <returns></returns>
        private RateWork MakeRateFilter(string sectionCode, UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, string rateSettingDivide)
        {
            RateWork rate = new RateWork();

            // 掛率設定区分に従って設定有無を判断してフィルター用の掛率マスタクラスを生成
            rate.SectionCode = sectionCode;
            rate.UnitPriceKind = ( (int)unitPriceKind ).ToString();
            rate.RateSettingDivide = rateSettingDivide;
            rate.GoodsMakerCd = IsMakerSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsMakerCd : 0;
            rate.GoodsNo = IsGoodsNoSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsNo : string.Empty;
            rate.GoodsRateRank = IsGoodsRateRankSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsRateRank : string.Empty;
            rate.GoodsRateGrpCode = IsGoodsRateGrpCodeSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsRateGrpCode : 0;
            rate.BLGroupCode = IsBLGroupCodeSetting(rateSettingDivide) ? unitPriceCalcParam.BLGroupCode : 0;
            rate.BLGoodsCode = IsBLGoodsSetting(rateSettingDivide) ? unitPriceCalcParam.BLGoodsCode : 0;
            rate.CustomerCode = IsCustomerSetting(rateSettingDivide) ? unitPriceCalcParam.CustomerCode : 0;
            rate.CustRateGrpCode = IsCustRateGrpSetting(rateSettingDivide) ? unitPriceCalcParam.CustRateGrpCode : 0;
            rate.SupplierCd = IsSupplierSetting(rateSettingDivide) ? unitPriceCalcParam.SupplierCd : 0;
            rate.LotCount = unitPriceCalcParam.CountFl;

            return rate;
        }


		/// <summary>
		/// 商品構成情報検索処理
		/// </summary>
		/// <param name="goodsUnitDataList">商品構成情報リスト</param>
		/// <param name="unitPriceCalcParam">単価算出パラメータ</param>
		/// <returns>商品構成情報オブジェクト</returns>
		private GoodsUnitDataWork SearchGoodsUnitData( List<GoodsUnitDataWork> goodsUnitDataList, UnitPriceCalcParamWork unitPriceCalcParam )
		{
			GoodsUnitDataWork retGoodsUnitData = null;

			foreach (GoodsUnitDataWork goodsUnitDataWk in goodsUnitDataList)
			{
				if (( goodsUnitDataWk.GoodsNo == unitPriceCalcParam.GoodsNo ) && ( goodsUnitDataWk.GoodsMakerCd == unitPriceCalcParam.GoodsMakerCd ))
				{
					retGoodsUnitData = goodsUnitDataWk;
                    break; //ADD on 2012/07/10 for Redmine#31103
				}
			}

			return retGoodsUnitData;
		}

		#endregion

        // --- ADD 時シン 2015/06/18 メイゴ レス値引一覧表用レス率（売価率）の算出 ------->>>>>>>>>>>
        /// <summary>
        /// 掛率を使用して売価率を取得します。
        /// </summary>
        /// <param name="unitPriceCalcParamList">売価率取得パラメータオブジェクトリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secList">拠点コード</param>
        /// <param name="rateRetList">売価率結果リスト</param>
        /// <remarks>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/06/18</br>
        /// </remarks>
        public int SalesRateByRateList(List<UnitPriceCalcParamWork> unitPriceCalcParamList, string enterpriseCode, ArrayList secList, out List<RateWork> rateRetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            rateRetList = new List<RateWork>();
            List<RateProtyMngWork> rateProtyMngList = null;
            // 優先管理読み込み
            List<RateProtyMngWork> rateProtyMngAllList = new List<RateProtyMngWork>();
            status = this.SearchRateProtyMngForInventory(enterpriseCode, out rateProtyMngAllList);
            // 優先管理読み込み失敗場合
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            if (unitPriceCalcParamList != null && unitPriceCalcParamList.Count > 0)
            {
                // 掛率優先管理情報を取得する
                rateProtyMngList = this.GetSalesRateProtyMngList(rateProtyMngAllList, enterpriseCode, unitPriceCalcParamList[0].SectionCode, UnitPriceKind.SalesUnitPrice);
                if (rateProtyMngList == null)
                {
                    rateProtyMngList = new List<RateProtyMngWork>();
                }
            }

            // 掛率マスタの読み込み
            status = this.SearchSalesRateForInventoryDis(enterpriseCode, secList);
            // 掛率マスタの読み込み失敗場合s
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            for (int i = 0; i < unitPriceCalcParamList.Count; i++)
            {
                // 売価率を取得する
                status = this.RateByRateListForInventory2(UnitPriceKind.SalesUnitPrice, unitPriceCalcParamList[i], rateProtyMngList, ref rateRetList);
                // 売価率を取得失敗場合
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            }
            return status;
        }

        /// <summary>
        /// 掛率優先順位、掛率マスタによる売価率取得
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="unitPriceCalcParam">仕入率取得パラメータ</param>
        /// <param name="rateProtyMngList">掛率優先管理マスタリスト</param>
        /// <param name="rateRetList">仕入率結果リスト</param>
        /// <remarks>
        /// <br>Note       : 指定された条件の掛率優先順位、掛率マスタによる掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/06/18</br>
        /// </remarks>
        private int RateByRateListForInventory2(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, List<RateProtyMngWork> rateProtyMngList, ref List<RateWork> rateRetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            bool breakFlg = false;

            // 掛率優先順位順によって、売価率取得する
            try
            {
                foreach (RateProtyMngWork rateProtyMng in rateProtyMngList)
                {
                    if (this.RateForInventory2(unitPriceKind, unitPriceCalcParam, rateProtyMng.SectionCode, rateProtyMng, ref rateRetList))
                    {
                        breakFlg = true;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (breakFlg == false)
                {
                    RateWork rateRet = new RateWork();

                    rateRet.UnitPriceKind = ((int)unitPriceKind).ToString();        // 単価種類
                    rateRet.GoodsNo = unitPriceCalcParam.GoodsNo;                   // 商品コード
                    rateRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;         // メーカーコード
                    rateRet.SectionCode = unitPriceCalcParam.SectionCode;           // 拠点コード
                    rateRet.GoodsRateRank = unitPriceCalcParam.GoodsRateRank;       // 層別
                    rateRet.GoodsRateGrpCode = unitPriceCalcParam.GoodsRateGrpCode; // 商品中分類
                    rateRet.BLGoodsCode = unitPriceCalcParam.BLGoodsCode;           // BL商品コード
                    rateRet.BLGroupCode = unitPriceCalcParam.BLGroupCode;           // BLグループコード
                    rateRet.CustRateGrpCode = unitPriceCalcParam.CustRateGrpCode;   // 得意先掛率グループコード
                    rateRetList.Add(rateRet);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }

            return status;
        }

        /// <summary>
        /// 掛率設定区分に従って売価率取得
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="unitPriceCalcParam">売価率取得パラメータオブジェクト</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="rateProtyMng">掛率優先管理マスタオブジェクト</param>
        /// <param name="rateRetList">売価取得結果オブジェクトリスト</param>
        /// <returns>True:売価率取得成功、False:売価率取得失敗</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の掛率優先順位、掛率マスタによる掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/06/18</br>
        /// </remarks>
        private bool RateForInventory2(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, string sectionCode, RateProtyMngWork rateProtyMng, ref List<RateWork> rateRetList)
        {
            RateWork rateCndtn = MakeRateFilter(sectionCode, unitPriceKind, unitPriceCalcParam, rateProtyMng.RateSettingDivide);

            // 予め作っておいたDictionayから条件に合うものを取得
            // もう少しきれいな書き方があるかもしれません
            List<RateWork> tmpList = null;
            Hashtable d2 = (Hashtable)d1[rateCndtn.UnitPriceKind.Trim()];
            if (d2 != null)
            {
                Hashtable d3 = (Hashtable)d2[rateCndtn.RateSettingDivide.Trim()];
                if (d3 != null)
                {
                    Hashtable d4 = (Hashtable)d3[rateCndtn.GoodsNo.Trim()];
                    if (d4 != null)
                    {
                        Hashtable d5 = (Hashtable)d4[rateCndtn.SectionCode.Trim()];
                        if (d5 != null)
                        {
                            Hashtable d6 = (Hashtable)d5[rateCndtn.GoodsMakerCd];
                            if (d6 != null)
                            {
                                Hashtable d7 = (Hashtable)d6[rateCndtn.GoodsRateRank.Trim()];
                                if (d7 != null)
                                {
                                    Hashtable d8 = (Hashtable)d7[rateCndtn.GoodsRateGrpCode];
                                    if (d8 != null)
                                    {
                                        Hashtable d9 = (Hashtable)d8[rateCndtn.BLGroupCode];
                                        if (d9 != null)
                                        {
                                            Hashtable d10 = (Hashtable)d9[rateCndtn.BLGoodsCode];
                                            if (d10 != null)
                                            {
                                                Hashtable d11 = (Hashtable)d10[rateCndtn.CustomerCode];
                                                if (d11 != null)
                                                {
                                                    Hashtable d12 = (Hashtable)d11[rateCndtn.CustRateGrpCode];
                                                    if (d12 != null)
                                                    {
                                                        tmpList = (List<RateWork>)d12[rateCndtn.SupplierCd];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (tmpList == null || tmpList.Count == 0) return false;

            List<RateWork> findList = new List<RateWork>();
            //tmpListからLotCountの条件に合わない物をリムーブ
            for (int i = 0; i < tmpList.Count; i++)
            {
                if (tmpList[i].LotCount >= rateCndtn.LotCount)
                {
                    findList.Add(tmpList[i]);
                }
            }

            if (findList == null || findList.Count == 0) return false;

            findList.Sort(new FractionProcMoney.RateComparer());


            // 先頭行のデータが対象データ
            RateWork rate = new RateWork();
            rate.RateVal = findList[0].RateVal;                             // 売価率
            rate.GoodsNo = unitPriceCalcParam.GoodsNo;                      // 商品コード
            rate.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;            // メーカーコード
            rate.SectionCode = unitPriceCalcParam.SectionCode;              // 拠点コード
            rate.GoodsRateRank = unitPriceCalcParam.GoodsRateRank;          // 層別
            rate.GoodsRateGrpCode = unitPriceCalcParam.GoodsRateGrpCode;    // 商品中分類
            rate.BLGoodsCode = unitPriceCalcParam.BLGoodsCode;              // BL商品コード
            rate.BLGroupCode = unitPriceCalcParam.BLGroupCode;              // BLグループコード
            rate.CustRateGrpCode = unitPriceCalcParam.CustRateGrpCode;   　 // 得意先掛率グループコード
            rateRetList.Add(rate);

            return true;
        }

        /// <summary>
        /// 対象拠点分の優先管理を取得
        /// </summary>
        /// <param name="rateProtyMngAllList">優先管理取得パラメータオブジェクトリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="unitPriceKind">単価種類</param>
        /// <remarks>
        /// <br>UpdateNote : 掛率優先管理情報のリストを取得</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/06/18</br>
        /// </remarks>
        private List<RateProtyMngWork> GetSalesRateProtyMngList(List<RateProtyMngWork> rateProtyMngAllList, string enterpriseCode, string sectionCode, UnitPriceKind unitPriceKind)
        {
            if (rateProtyMngAllList == null || rateProtyMngAllList.Count == 0) return null;

            // 対象拠点分の優先管理を取得
            List<RateProtyMngWork> lastRateProtyMngList = rateProtyMngAllList.FindAll(
                                                                    delegate(RateProtyMngWork rateProtyMng)
                                                                    {
                                                                        if ((rateProtyMng.SectionCode.Trim() == sectionCode.Trim()) &&
                                                                            (rateProtyMng.UnitPriceKind == (int)unitPriceKind) &&
                                                                            (("3".Equals(rateProtyMng.RateMngCustCd.Trim())) ||
                                                                            ("4".Equals(rateProtyMng.RateMngCustCd.Trim()))))
                                                                        {
                                                                            return true;
                                                                        }
                                                                        else
                                                                        {
                                                                            return false;
                                                                        }
                                                                    });
            return lastRateProtyMngList;

        }

        /// <summary>
        /// 掛率マスタ（売価）の取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secList">拠点リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/06/18</br>
        /// </remarks>
        public int SearchSalesRateForInventoryDis(string enterpriseCode, ArrayList secList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            RateDB rateDB = new RateDB();

            List<RateWork> rateList = new List<RateWork>();
            LogWrite("掛率 Search パラメータ:" + rateList.Count.ToString());

            object rateWorkList = null;

            // 売価設定の掛率リストを取得
            status = rateDB.SearchRateForInvoDis(out rateWorkList, enterpriseCode, secList, 1, 0);

            // 検索結果がある場合
            if (rateWorkList != null)
            {
                ArrayList list = rateWorkList as ArrayList;
                ArrayList tempList = new ArrayList();
                foreach (RateWork rateWork in list)
                {
                    // 拠点「00」以外のデータを保存する
                    if (!"00".Equals(rateWork.SectionCode.Trim()))
                    {
                        tempList.Add(rateWork);
                    }
                }

                rateList.AddRange((RateWork[])tempList.ToArray(typeof(RateWork)));
            }

            // 掛率設定マスタの取得
            MakeDictionary(rateList);

            LogWrite("掛率取得終了");
            return status;
        }
        // --- ADD 時シン 2015/06/18 メイゴ レス値引一覧表用レス率（売価率）の算出 ------->>>>>>>>>>>

        // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
        /// <summary>
        /// 掛率を使用して原価単価を算出します。(棚卸専用)
        /// </summary>
        /// <param name="unitPriceCalcParamList">単価計算パラメータオブジェクトリスト</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <param name="rateWorkByGoodsNoDic">単品掛率マスタDic</param>
        /// <br>Update Note: 2013/06/07 wangl2</br>
        /// <br>管理番号   ：10801804-00 2013/06/18配信分</br>
        /// <br>             Redmine#35788：「棚卸準備処理」の原価取得で掛率優先順位が評価されない（№1949）</br>
        /// <br>                             エラー発生時原価が登録されない件の対応でエラー処理追加(#8の件)</br>
        /// <br>Update Note: 2015/03/23 xuyb</br>
        /// <br>管理番号   : 11070253-00 </br>
        /// <br>           : Redmine#44492の#99 売上月次更新の仕入単価・仕入率算出不具合の修正（#44951の#50のNo.2）対応</br>
        /// <br>Update Note: 2020/07/23 譚洪</br>
        /// <br>管理番号   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551：棚卸準備処理を実行すると処理に失敗する現象の解除</br>
        public int CalculateUnitCostPrice(ref List<UnitPriceCalcRetWork> unitPriceCalcRetList, GoodsPriceUWork goodsPrice
            , double taxFractionProcUnit, int taxFractionProcCd, UnitPriceCalcParamWork unitPriceCalcParam, List<StockProcMoneyWork> stockProcMoneyList
            , List<RateProtyMngWork> rateProtyMngAllList, GoodsUnitDataWork goodsUnitData , List<RateWork> rateList) 
        {
            ReadComCompanyInf(goodsUnitData.EnterpriseCode);  //ADD xuyb 2015/03/23 for Redmine#44492

            if (goodsPrice != null && goodsPrice.EnterpriseCode != null && goodsPrice.EnterpriseCode != "")
            {
                double unitPriceTaxExc = 0;
                double unitPriceTaxInc = 0;
                int fractionProcCode = 0;
                double unPrcFracProcUnit = 0;
                int unPrcFracProcDiv = 0;
                double stdPrice = 0;
                int taxationCode = 0;
                double stockRate = 0;
                bool calcPrice = false;
                UnitPrcCalcDiv unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;
                List<RateProtyMngWork> rateProtyMngList = null;

                // 原単価が直接セットされている場合
                if (goodsPrice.SalesUnitCost != 0)
                {
                    calcPrice = true;

                    unitPrcCalcDiv = UnitPrcCalcDiv.Price;

                    // 商品の課税方式に従って分岐
                    switch (goodsUnitData.TaxationDivCd)
                    {
                        case (int)CalculateTax.TaxationCode.TaxInc:
                            unitPriceTaxInc = goodsPrice.SalesUnitCost;
                            unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxInc);
                            break;
                        case (int)CalculateTax.TaxationCode.TaxExc:
                            unitPriceTaxExc = goodsPrice.SalesUnitCost;
                            unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxExc);
                            break;
                        case (int)CalculateTax.TaxationCode.TaxNone:
                            unitPriceTaxExc = goodsPrice.SalesUnitCost;
                            unitPriceTaxInc = goodsPrice.SalesUnitCost;
                            break;
                    }
                    // 転嫁方式「非課税」時は、税込単価に税抜き単価をセット
                    if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                    {
                        unitPriceTaxInc = unitPriceTaxExc;
                    }
                }
                // 仕入率がセットされていて、定価がゼロ以外
                else if ((goodsPrice.StockRate != 0) && (goodsPrice.ListPrice != 0))
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
                        stockProcMoneyList,
                        ref unPrcFracProcUnit,
                        ref unPrcFracProcDiv,
                        out unitPriceTaxExc,
                        out unitPriceTaxInc);
                }

                // ここまでで原価計算された場合は結果をセット
                if (calcPrice)
                {
                    UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                    unitPriceCalcRet.UnitPriceKind = ((int)UnitPriceKind.UnitCost).ToString();
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

                    unitPriceCalcRetList.Add(unitPriceCalcRet);
                }
                else
                {
                    // 掛率優先管理情報を取得する
                    rateProtyMngList = this.GetRateProtyMngList(rateProtyMngAllList, goodsUnitData.EnterpriseCode, unitPriceCalcParam.SectionCode, UnitPriceKind.UnitCost);//ADD on 2012/07/10 for Redmine#31103
                    //----DEL 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                    //if (rateProtyMngList != null)
                    //{
                    //    this.CalculateUnitPriceByRateListForInventory(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList);
                    //}
                    //----DEL 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
                    //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                    if (rateProtyMngList == null)
                    {
                        rateProtyMngList = new List<RateProtyMngWork>();
                    }
                    // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                    //this.CalculateUnitPriceByRateListForInventory(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList);
                    Dictionary<string, RateWork> rateWorkByGoodsNoDic = new Dictionary<string, RateWork>();
                    this.CalculateUnitPriceByRateListForInventory(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList, rateWorkByGoodsNoDic);
                    // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
                    //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
                }
            }
            else
            {
                UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                unitPriceCalcRet.UnitPriceKind = ((int)UnitPriceKind.UnitCost).ToString();       // 単価種類
                unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;             // 商品コード
                unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;   // メーカーコード
                unitPriceCalcRet.SupplierCd = 0;                                   // 仕入先コード

                unitPriceCalcRetList.Add(unitPriceCalcRet);
            }

            return 0;
        }
        // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

        // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
        /// <summary>
        /// 掛率を使用して原価単価を算出します。(棚卸専用)
        /// </summary>
        /// <param name="unitPriceCalcRetList">単価計算パラメータオブジェクトリスト</param>
        /// <param name="goodsPrice">価格マスタ</param>
        /// <param name="taxFractionProcUnit">端数処理単位</param>
        /// <param name="taxFractionProcCd">端数処理区分</param>
        /// <param name="unitPriceCalcParam">単価計算パラメータ</param>
        /// <param name="stockProcMoneyList">仕入金額処理区分マスタリスト</param>
        /// <param name="rateProtyMngAllList">掛率優先管理リスト</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="rateList">掛率リスト</param>
        /// <param name="rateWorkByGoodsNoDic">単品掛率マスタDic</param>
        /// <remarks>
        /// <br>Note        : 掛率を使用して原価単価を算出します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2020/07/23</br>
        /// <br>Update Note : 2021/03/16 譚洪</br>
        /// <br>管理番号    : 11770024-00</br>
        /// <br>             PMKOBETSU-3551 棚卸準備処理と棚卸表示の障害対応</br>  
        /// </remarks>
        public int CalculateUnitCostPrice2(ref List<UnitPriceCalcRetWork> unitPriceCalcRetList, GoodsPriceUWork goodsPrice
            , double taxFractionProcUnit, int taxFractionProcCd, UnitPriceCalcParamWork unitPriceCalcParam, List<StockProcMoneyWork> stockProcMoneyList
            , List<RateProtyMngWork> rateProtyMngAllList, GoodsUnitDataWork goodsUnitData, List<RateWork> rateList, Dictionary<string, RateWork> rateWorkByGoodsNoDic)
        {

            if (goodsPrice != null && goodsPrice.EnterpriseCode != null && goodsPrice.EnterpriseCode != "")
            {
                double unitPriceTaxExc = 0;
                double unitPriceTaxInc = 0;
                int fractionProcCode = 0;
                double unPrcFracProcUnit = 0;
                int unPrcFracProcDiv = 0;
                double stdPrice = 0;
                int taxationCode = 0;
                double stockRate = 0;
                bool calcPrice = false;
                UnitPrcCalcDiv unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;
                List<RateProtyMngWork> rateProtyMngList = null;

                // 原単価が直接セットされている場合
                if (goodsPrice.SalesUnitCost != 0)
                {
                    calcPrice = true;

                    unitPrcCalcDiv = UnitPrcCalcDiv.Price;

                    // 商品の課税方式に従って分岐
                    switch (goodsUnitData.TaxationDivCd)
                    {
                        case (int)CalculateTax.TaxationCode.TaxInc:
                            unitPriceTaxInc = goodsPrice.SalesUnitCost;
                            unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxInc);
                            break;
                        case (int)CalculateTax.TaxationCode.TaxExc:
                            unitPriceTaxExc = goodsPrice.SalesUnitCost;
                            unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxExc);
                            break;
                        case (int)CalculateTax.TaxationCode.TaxNone:
                            unitPriceTaxExc = goodsPrice.SalesUnitCost;
                            unitPriceTaxInc = goodsPrice.SalesUnitCost;
                            break;
                    }
                    // 転嫁方式「非課税」時は、税込単価に税抜き単価をセット
                    if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                    {
                        unitPriceTaxInc = unitPriceTaxExc;
                    }
                }
                // 仕入率がセットされていて、定価がゼロ以外
                else if ((goodsPrice.StockRate != 0) && (goodsPrice.ListPrice != 0))
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
                        stockProcMoneyList,
                        ref unPrcFracProcUnit,
                        ref unPrcFracProcDiv,
                        out unitPriceTaxExc,
                        out unitPriceTaxInc);
                }

                // ここまでで原価計算された場合は結果をセット
                if (calcPrice)
                {
                    UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                    unitPriceCalcRet.UnitPriceKind = ((int)UnitPriceKind.UnitCost).ToString();
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

                    unitPriceCalcRetList.Add(unitPriceCalcRet);
                }
                else
                {
                    // 掛率優先管理情報を取得する
                    // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                    //rateProtyMngList = this.GetRateProtyMngList(rateProtyMngAllList, goodsUnitData.EnterpriseCode, unitPriceCalcParam.SectionCode, UnitPriceKind.UnitCost);//ADD on 2012/07/10 for Redmine#31103
                    rateProtyMngList = this.GetRateProtyMngList(rateProtyMngAllList, goodsPrice.EnterpriseCode, unitPriceCalcParam.SectionCode, UnitPriceKind.UnitCost);
                    // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
                    if (rateProtyMngList == null)
                    {
                        rateProtyMngList = new List<RateProtyMngWork>();
                    }
                    this.CalculateUnitPriceByRateListForInventory(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList, rateWorkByGoodsNoDic);
                }
            }
            else
            {
                UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                unitPriceCalcRet.UnitPriceKind = ((int)UnitPriceKind.UnitCost).ToString();       // 単価種類
                unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;             // 商品コード
                unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;   // メーカーコード
                unitPriceCalcRet.SupplierCd = 0;                                   // 仕入先コード

                unitPriceCalcRetList.Add(unitPriceCalcRet);
            }

            return 0;
        }
        // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<

        // --- ADD yangyi 2013/05/16 for Redmine#35493 ------->>>>>>>>>>>
        /// <summary>
        /// 掛率優先順位、掛率マスタによる単価計算(棚卸専用)
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="unitPriceCalcParam">単価計算パラメータ</param>
        /// <param name="rateProtyMngList">掛率優先管理マスタリスト</param>
        /// <param name="rateList">掛率リスト</param>
        /// <param name="stockProcMoneyList">仕入金額処理区分設定マスタ</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <param name="rateWorkByGoodsNoDic">単品掛率マスタDic</param>
        /// <br>Update Note: 2020/07/23 譚洪</br>
        /// <br>管理番号   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551：棚卸準備処理を実行すると処理に失敗する現象の解除</br>
        // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
        //private void CalculateUnitPriceByRateListForInventory(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, List<RateProtyMngWork> rateProtyMngList, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        private void CalculateUnitPriceByRateListForInventory(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, List<RateProtyMngWork> rateProtyMngList, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList, Dictionary<string, RateWork> rateWorkByGoodsNoDic)
        // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
        {
            bool breakFlg = false;

            // 掛率優先順位順に単価計算する
            try
            {
                foreach (RateProtyMngWork rateProtyMng in rateProtyMngList)
                {
                    // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                    //if (this.CalculateUnitPriceForInventory(unitPriceKind, unitPriceCalcParam, rateProtyMng.SectionCode, rateProtyMng, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList))
                    if (this.CalculateUnitPriceForInventory(unitPriceKind, unitPriceCalcParam, rateProtyMng.SectionCode, rateProtyMng, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList, rateWorkByGoodsNoDic))
                    // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
                    {
                        breakFlg = true;
                        break;
                    }
                }
            }
            finally
            {
                if (breakFlg == false)
                {
                    UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                    unitPriceCalcRet.UnitPriceKind = ((int)unitPriceKind).ToString();  // 単価種類
                    unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;             // 商品コード
                    unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;   // メーカーコード
                    unitPriceCalcRet.SupplierCd = 0;                                   // 仕入先コード

                    unitPriceCalcRetList.Add(unitPriceCalcRet);
                }
            }
        }

        /// <summary>
        /// 掛率設定区分に従って単価を算出します。(棚卸専用)
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="unitPriceCalcParam">単価計算パラメータオブジェクト</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="rateProtyMng">掛率優先管理マスタオブジェクト</param>
        /// <param name="rateList">掛率マスタリスト</param>
        /// <param name="stockProcMoneyList">仕入金額処理区分設定マスタ</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="unitPriceCalcRetList">単価算出結果オブジェクトリスト</param>
        /// <param name="rateWorkByGoodsNoDic">単品掛率マスタDic</param>
        /// <returns>True:単価算出成功、False:単価算出失敗</returns>
        /// <br>Update Note: 2020/07/23 譚洪</br>
        /// <br>管理番号   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551：棚卸準備処理を実行すると処理に失敗する現象の解除</br>
        /// <br>Update Note: 2021/03/16 譚洪</br>
        /// <br>管理番号   : 11770024-00</br>
        /// <br>             PMKOBETSU-3551 棚卸準備処理と棚卸表示の障害対応</br> 
        // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
        //private bool CalculateUnitPriceForInventory(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, string sectionCode, RateProtyMngWork rateProtyMng, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        private bool CalculateUnitPriceForInventory(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, string sectionCode, RateProtyMngWork rateProtyMng, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList, Dictionary<string, RateWork> rateWorkByGoodsNoDic)
        // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
        {
            #region [ 対象の掛率マスタを抽出 ]
            RateWork rateCndtn = MakeRateFilter(sectionCode, unitPriceKind, unitPriceCalcParam, rateProtyMng.RateSettingDivide);

            if (rateList == null || rateList.Count == 0) return false; //ADD 2012/06/08

            // 予め作っておいたDictionayから条件に合うものを取得
            // もう少しきれいな書き方があるかもしれません
            List<RateWork> tmpList = null;
            Hashtable d2 = (Hashtable)d1[rateCndtn.UnitPriceKind.Trim()];
            if (d2 != null)
            {
                Hashtable d3 = (Hashtable)d2[rateCndtn.RateSettingDivide.Trim()];
                if (d3 != null)
                {
                    Hashtable d4 = (Hashtable)d3[rateCndtn.GoodsNo.Trim()];
                    if (d4 != null)
                    {
                        Hashtable d5 = (Hashtable)d4[rateCndtn.SectionCode.Trim()];
                        if (d5 != null)
                        {
                            Hashtable d6 = (Hashtable)d5[rateCndtn.GoodsMakerCd];
                            if (d6 != null)
                            {
                                Hashtable d7 = (Hashtable)d6[rateCndtn.GoodsRateRank.Trim()];
                                if (d7 != null)
                                {
                                    Hashtable d8 = (Hashtable)d7[rateCndtn.GoodsRateGrpCode];
                                    if (d8 != null)
                                    {
                                        Hashtable d9 = (Hashtable)d8[rateCndtn.BLGroupCode];
                                        if (d9 != null)
                                        {
                                            Hashtable d10 = (Hashtable)d9[rateCndtn.BLGoodsCode];
                                            if (d10 != null)
                                            {
                                                Hashtable d11 = (Hashtable)d10[rateCndtn.CustomerCode];
                                                if (d11 != null)
                                                {
                                                    Hashtable d12 = (Hashtable)d11[rateCndtn.CustRateGrpCode];
                                                    if (d12 != null)
                                                    {
                                                        tmpList = (List<RateWork>)d12[rateCndtn.SupplierCd];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
            //if (tmpList == null || tmpList.Count == 0) return false;
            // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
            //// 全社単品掛率データ
            //RateWork rateAllSec = new RateWork();
            //// 全社単品有無フラグ
            //bool rateAllSecFlg = false;
            //// 掛率優先順位が全社単品のパータン
            //if ("6A".Equals(rateProtyMng.RateSettingDivide.Trim()) && "00".Equals(sectionCode.Trim()))
            //{
            //    // 全社単品を取得
            //    string key = "00" + "-" + unitPriceCalcParam.GoodsMakerCd.ToString("D4") + "-" + unitPriceCalcParam.GoodsNo.Trim();
            //    if (rateWorkByGoodsNoDic.ContainsKey(key))
            //    {
            //        rateAllSec = rateWorkByGoodsNoDic[key] as RateWork;
            //        rateAllSecFlg = true;
            //    }
            //}
            // 単品掛率データ
            RateWork rateSec = new RateWork();
            // 単品有無フラグ
            bool rateSecFlg = false;
            // 掛率優先順位が単品のパータン
            if (ctRateSettingDivByGoodsNo.Equals(rateProtyMng.RateSettingDivide.Trim()))
            {
                string key = string.Format(ctDicKeyFmt, sectionCode.Trim(), unitPriceCalcParam.GoodsMakerCd, unitPriceCalcParam.GoodsNo.Trim());
                if (rateWorkByGoodsNoDic.ContainsKey(key))
                {
                    rateSec = rateWorkByGoodsNoDic[key] as RateWork;
                    rateSecFlg = true;
                }
            }
            // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<

            if (tmpList == null || tmpList.Count == 0)
            {
                // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                ////当商品の全社単品掛率もない場合、戻る
                //if (!rateAllSecFlg) return false;
                ////当商品の全社単品がある場合
                //else
                //{
                //    tmpList = new List<RateWork>();
                //    tmpList.Add(rateAllSec);
                //}
                //当商品の単品掛率もない場合、戻る
                if (!rateSecFlg) return false;
                //当商品の単品がある場合
                else
                {
                    tmpList = new List<RateWork>();
                    tmpList.Add(rateSec);
                }
                // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
            }
            // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<

            List<RateWork> findList = new List<RateWork>();
            //tmpListからLotCountの条件に合わない物をリムーブ
            for (int i = 0; i < tmpList.Count; i++)
            {
                if (tmpList[i].LotCount >= rateCndtn.LotCount)
                {
                    findList.Add(tmpList[i]);
                }
            }

            if (findList == null || findList.Count == 0) return false;

            findList.Sort(new FractionProcMoney.RateComparer());

            #endregion

            double stdPrice = 0;			// 基準価格
            double stdPriceWk = stdPrice;	// 基準価格（実際の計算用の値）
            double unitPriceTaxExc = 0;		// 税抜き単価
            double unitPriceTaxInc = 0;		// 税込み単価
            int fractionProcCode = 0;		// 端数処理コード(0:全社)
            int taxationCode = unitPriceCalcParam.TaxationDivCd;	// 課税方式
            int openPriceDiv = 0;
            UnitPrcCalcDiv unitPrcCalcDiv = UnitPrcCalcDiv.Price;
            double count = (unitPriceCalcParam.CountFl == 0) ? 1 : Math.Abs(unitPriceCalcParam.CountFl);	// 数量(0の場合は1つで計算、0以外は絶対値)

            //--------------------------------------------------
            // 端数処理コードの決定
            //--------------------------------------------------
            // 定価、売上単価
            if ((unitPriceKind == UnitPriceKind.ListPrice) || (unitPriceKind == UnitPriceKind.SalesUnitPrice))
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

            if ((unitPriceCalcParam.ConsTaxLayMethod != 9) &&                                 // 転嫁方式「非課税」を除く
                (unitPriceKind == UnitPriceKind.SalesUnitPrice) &&                            // 売上単価
                (unitPriceCalcParam.TotalAmountDispWayCd == 1) &&								// 総額表示する
                (unitPriceCalcParam.TtlAmntDspRateDivCd == 0) &&								// 掛率適用区分「0：税込単価」
                (unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc))	// 外税
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxInc;	// 内税と同じ計算をする
            }

            // 先頭行のデータが対象データ
            RateWork rate = findList[0];

            // 掛率マスタの端数処理単位、端数処理区分は定価計算時のみ使用する（0にすると、金額処理区分設定から取得）
            double unPrcFracProcUnit = (unitPriceKind == UnitPriceKind.ListPrice) ? rate.UnPrcFracProcUnit : 0;
            int unPrcFracProcDiv = (unitPriceKind == UnitPriceKind.ListPrice) ? rate.UnPrcFracProcDiv : 0;

            // 消費税の端数処理単位、端数処理区分
            double taxFractionProcUnit;
            int taxFractionProcCd;

            double rateVal = 0;                 // 掛率

            // 価格情報の取得
            GoodsPriceUWork goodsPrice;
            this.GetPrice(unitPriceCalcParam.PriceApplyDate, goodsUnitData, out goodsPrice);

            if (goodsPrice == null) goodsPrice = new GoodsPriceUWork();

            // 単価種類により処理分岐（単価種類毎の優先順位に従って計算）
            // ※計算方法は同一ですが、仕様変更や追加された場合を考慮して単価種類毎に分けておきます
            switch (unitPriceKind)
            {
                #region ●原価
                case UnitPriceKind.UnitCost:

                    // 仕入消費税の端数処理単位、端数処理区分を取得
                    this.GetStockFractionProcInfo(FractionProcMoney.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.StockCnsTaxFrcProcCd, 0, stockProcMoneyList, out taxFractionProcUnit, out taxFractionProcCd);

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
                        if ((openPriceDiv == 1) && (stdPrice == 0)) return false;

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
                                                     stockProcMoneyList,
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

            UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

            unitPriceCalcRet.UnitPriceKind = ((int)unitPriceKind).ToString();				// 単価種類
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

            #endregion

            unitPriceCalcRetList.Add(unitPriceCalcRet);

            return true;
        }
        // --- ADD yangyi 2013/05/10 for Redmine#35493 -------<<<<<<<<<<<
        
        // --- ADD 陳艶丹 2015/01/27 for Redmine#44581 ------->>>>>>>>>>>
        /// <summary>
        /// 掛率を使用して仕入率を取得します。(棚卸調査表)
        /// </summary>
        /// <param name="unitPriceCalcParamList">仕入率取得パラメータオブジェクトリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secList">拠点コード リスト</param>
        /// <param name="rateRetList">仕入率結果リスト</param>
        /// <remarks>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2015/01/27</br>
        /// </remarks>
        public int RateByRateList(List<UnitPriceCalcParamWork> unitPriceCalcParamList, string enterpriseCode, ArrayList secList, out List<RateWork> rateRetList)
        {
            rateRetList = new List<RateWork>();
            List<RateProtyMngWork> rateProtyMngList = null;
            //掛率マスタの読み込み
            List<RateWork> rateList;
            this.SearchRateForInventoryDis(enterpriseCode, secList, out rateList);

            //優先管理読み込み
            List<RateProtyMngWork> rateProtyMngAllList = new List<RateProtyMngWork>();
            this.SearchRateProtyMngForInventory(enterpriseCode, out rateProtyMngAllList);
            for (int i = 0; i < unitPriceCalcParamList.Count; i++)
            {
                // 掛率優先管理情報を取得する
                rateProtyMngList = this.GetRateProtyMngList(rateProtyMngAllList, enterpriseCode, unitPriceCalcParamList[i].SectionCode, UnitPriceKind.UnitCost);
                if (rateProtyMngList == null)
                {
                    rateProtyMngList = new List<RateProtyMngWork>();
                }
                this.RateByRateListForInventory(UnitPriceKind.UnitCost, unitPriceCalcParamList[i], rateProtyMngList, ref rateRetList);
            }
            return 0;
        }
        /// <summary>
        /// 掛率優先順位、掛率マスタによる仕入率取得(棚卸調査表)
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="unitPriceCalcParam">仕入率取得パラメータ</param>
        /// <param name="rateProtyMngList">掛率優先管理マスタリスト</param>
        /// <param name="rateRetList">仕入率結果リスト</param>
        /// <remarks>
        /// <br>Note       : 指定された条件の掛率優先順位、掛率マスタによる掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2015/01/27</br>
        /// </remarks>
        private void RateByRateListForInventory(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, List<RateProtyMngWork> rateProtyMngList, ref List<RateWork> rateRetList)
        {
            bool breakFlg = false;

            // 掛率優先順位順に単価計算する
            try
            {
                foreach (RateProtyMngWork rateProtyMng in rateProtyMngList)
                {
                    if (this.RateForInventory(unitPriceKind, unitPriceCalcParam, rateProtyMng.SectionCode, rateProtyMng, ref rateRetList))
                    {
                        breakFlg = true;
                        break;
                    }
                }
            }
            finally
            {
                if (breakFlg == false)
                {
                    RateWork rateRet = new RateWork();

                    rateRet.UnitPriceKind = ((int)unitPriceKind).ToString();  // 単価種類
                    rateRet.GoodsNo = unitPriceCalcParam.GoodsNo;             // 商品コード
                    rateRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;   // メーカーコード
                    rateRet.SectionCode = unitPriceCalcParam.SectionCode;     // 拠点コード
                    rateRet.GoodsRateRank = unitPriceCalcParam.GoodsRateRank; // 層別
                    rateRet.GoodsRateGrpCode = unitPriceCalcParam.GoodsRateGrpCode; // 商品中分類
                    rateRet.BLGoodsCode = unitPriceCalcParam.BLGoodsCode;   // BL商品コード
                    rateRet.BLGroupCode = unitPriceCalcParam.BLGroupCode;// BLグループコード
                    rateRetList.Add(rateRet); 
                }
            }
        }

        /// <summary>
        /// 掛率設定区分に従って仕入率取得(棚卸調査表)
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="unitPriceCalcParam">仕入率取得パラメータオブジェクト</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="rateProtyMng">掛率優先管理マスタオブジェクト</param>
        /// <param name="rateList">掛率マスタリスト</param>
        /// <param name="rateRetList">仕入率取得結果オブジェクトリスト</param>
        /// <returns>True:仕入率取得成功、False:仕入率取得失敗</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の掛率優先順位、掛率マスタによる掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2015/01/27</br>
        /// </remarks>
        private bool RateForInventory(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, string sectionCode, RateProtyMngWork rateProtyMng, ref List<RateWork> rateRetList)
        {
            RateWork rateCndtn = MakeRateFilter(sectionCode, unitPriceKind, unitPriceCalcParam, rateProtyMng.RateSettingDivide);

            // 予め作っておいたDictionayから条件に合うものを取得
            // もう少しきれいな書き方があるかもしれません
            List<RateWork> tmpList = null;
            Hashtable d2 = (Hashtable)d1[rateCndtn.UnitPriceKind.Trim()];
            if (d2 != null)
            {
                Hashtable d3 = (Hashtable)d2[rateCndtn.RateSettingDivide.Trim()];
                if (d3 != null)
                {
                    Hashtable d4 = (Hashtable)d3[rateCndtn.GoodsNo.Trim()];
                    if (d4 != null)
                    {
                        Hashtable d5 = (Hashtable)d4[rateCndtn.SectionCode.Trim()];
                        if (d5 != null)
                        {
                            Hashtable d6 = (Hashtable)d5[rateCndtn.GoodsMakerCd];
                            if (d6 != null)
                            {
                                Hashtable d7 = (Hashtable)d6[rateCndtn.GoodsRateRank.Trim()];
                                if (d7 != null)
                                {
                                    Hashtable d8 = (Hashtable)d7[rateCndtn.GoodsRateGrpCode];
                                    if (d8 != null)
                                    {
                                        Hashtable d9 = (Hashtable)d8[rateCndtn.BLGroupCode];
                                        if (d9 != null)
                                        {
                                            Hashtable d10 = (Hashtable)d9[rateCndtn.BLGoodsCode];
                                            if (d10 != null)
                                            {
                                                Hashtable d11 = (Hashtable)d10[rateCndtn.CustomerCode];
                                                if (d11 != null)
                                                {
                                                    Hashtable d12 = (Hashtable)d11[rateCndtn.CustRateGrpCode];
                                                    if (d12 != null)
                                                    {
                                                        tmpList = (List<RateWork>)d12[rateCndtn.SupplierCd];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (tmpList == null || tmpList.Count == 0) return false;

            List<RateWork> findList = new List<RateWork>();
            //tmpListからLotCountの条件に合わない物をリムーブ
            for (int i = 0; i < tmpList.Count; i++)
            {
                if (tmpList[i].LotCount >= rateCndtn.LotCount)
                {
                    findList.Add(tmpList[i]);
                }
            }

            if (findList == null || findList.Count == 0) return false;

            findList.Sort(new FractionProcMoney.RateComparer());
           

            // 先頭行のデータが対象データ
            // ---UPD 2015/03/02 30940 河原林 一生 Shallow Copyにより保存したオブジェクトが上書きされるためDeep Copyで生成する ----------->>>>>>>>>>
            //RateWork rate = findList[0];          
            RateWork rate = new RateWork();
            rate.RateVal = findList[0].RateVal;
            // ---UPD 2015/03/02 30940 河原林 一生 Shallow Copyにより保存したオブジェクトが上書きされるためDeep Copyで生成する -----------<<<<<<<<<<
            rate.GoodsNo = unitPriceCalcParam.GoodsNo;             // 商品コード
            rate.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;   // メーカーコード
            rate.SectionCode = unitPriceCalcParam.SectionCode;     // 拠点コード
            rate.GoodsRateRank = unitPriceCalcParam.GoodsRateRank; // 層別
            rate.GoodsRateGrpCode = unitPriceCalcParam.GoodsRateGrpCode; // 商品中分類
            rate.BLGoodsCode = unitPriceCalcParam.BLGoodsCode;   // BL商品コード
            rate.BLGroupCode = unitPriceCalcParam.BLGroupCode;// BLグループコード

            rateRetList.Add(rate);

            return true;
        }
        // --- ADD 陳艶丹 2015/01/27 for Redmine#44581 -------<<<<<<<<<<<
        

        /// <summary>
        /// ログ出力(DEBUG)処理
        /// </summary>
        /// <param name="pMsg">メッセージ</param>
        public static void LogWrite(string pMsg)
        {
#if LOG
			System.IO.FileStream _fs;										// ファイルストリーム
			System.IO.StreamWriter _sw;										// ストリームwriter
            _fs = new System.IO.FileStream("PMHNB01010R.Log", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
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

        //----DEL 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
        ////----ADD on 2012/07/10 for Redmine#31103 ------->>>>>>
        ///// <summary>
        ///// 掛率を使用して原価単価を算出します。(棚卸専用)
        ///// </summary>
        ///// <param name="unitPriceCalcParamList">単価計算パラメータオブジェクトリスト</param>
        ///// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        ///// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        //public void CalculateUnitCostForInventory(List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, out List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        //{
        //    unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();

        //    this.CalculateUnitPriceProcForInventory(UnitPriceKind.UnitCost, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
        //}
        ////----ADD on 2012/07/10 for Redmine#31103 -------<<<<<<
        //----DEL 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
        //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
        /// <summary>
        /// 掛率を使用して原価単価を算出します。(棚卸専用)
        /// </summary>
        /// <param name="unitPriceCalcParamList">単価計算パラメータオブジェクトリスト</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <br>Update Note: 2020/07/23 譚洪</br>
        /// <br>管理番号   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551：棚卸準備処理を実行すると処理に失敗する現象の解除</br>
        public int CalculateUnitCostForInventory(List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, out List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();

            // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
            //int status = this.CalculateUnitPriceProcForInventory(UnitPriceKind.UnitCost, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
            Dictionary<string, RateWork> rateWorkByGoodsNoDic = new Dictionary<string, RateWork>();
            int status = this.CalculateUnitPriceProcForInventory(UnitPriceKind.UnitCost, unitPriceCalcParamList, goodsUnitDataList, rateWorkByGoodsNoDic, ref unitPriceCalcRetList);
            // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
            return status;
        }
        //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

        // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
        /// <summary>
        /// 掛率を使用して原価単価を算出します。(棚卸専用)
        /// </summary>
        /// <param name="unitPriceCalcParamList">単価計算パラメータオブジェクトリスト</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="rateWorkByGoodsNoDic">単品掛率マスタDic</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <remarks>
        /// <br>Note       : 掛率を使用して原価単価を算出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/07/23</br>
        /// </remarks>
        public int CalculateUnitCostForInventory2(List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, Dictionary<string, RateWork> rateWorkByGoodsNoDic, out List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();

            int status = this.CalculateUnitPriceProcForInventory(UnitPriceKind.UnitCost, unitPriceCalcParamList, goodsUnitDataList, rateWorkByGoodsNoDic, ref unitPriceCalcRetList);
            return status;
        }
        // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<

        //----ADD on 2012/07/10 for Redmine#31103 ------->>>>>>
        /// <summary>
        /// 掛率マスタを検索します。(棚卸専用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="rateList">掛率リスト</param>
        /// <returns>掛率検索ステータス</returns>
        //private int SearchRateForInventory(string enterpriseCode,out List<RateWork> rateList)//DEL yangyi 2013/05/06 Redmine#35493
        public int SearchRateForInventory(string enterpriseCode, out List<RateWork> rateList) //ADD yangyi 2013/05/06 Redmine#35493
        {
            RateDB rateDB = new RateDB();

            rateList = new List<RateWork>();
            LogWrite("掛率 Search パラメータ:" + rateList.Count.ToString());

            int status = -1;
            object rateWorkList = null;

            //status = rateDB.SearchForInventory(out rateWorkList, enterpriseCode, 0, 0);     //DEL yangyi 2013/05/06 Redmine#35493
            status = rateDB.SearchByUnitPriceKind(out rateWorkList, enterpriseCode, 2, 0, 0); //ADD yangyi 2013/05/06 Redmine#35493

            if (rateWorkList != null)
            {
                ArrayList list = rateWorkList as ArrayList;

                rateList.AddRange((RateWork[])list.ToArray(typeof(RateWork)));
            }
            
            MakeDictionary(rateList); //ADD yangyi 2013/05/06 Redmine#35493
            
            LogWrite("掛率取得終了");
            return status;
        }

        // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
        /// <summary>
        /// グループ別掛率マスタを検索する。(棚卸専用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="rateList">掛率リスト</param>
        /// <returns>掛率検索ステータス</returns>
        /// <remarks>
        /// <br>Note       : グループ別掛率マスタを検索します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/07/23</br>
        /// </remarks>
        public int SearchRateForInventory2(string enterpriseCode, out List<RateWork> rateList)
        {
            RateDB rateDB = new RateDB();

            rateList = new List<RateWork>();
            LogWrite("掛率 Search パラメータ:" + rateList.Count.ToString());

            int status = -1;
            object rateWorkList = null;
            //グループ別掛率マスタ検索
            status = rateDB.SearchByUnitPriceKindByGroup(out rateWorkList, enterpriseCode, 0, 0);

            //検索結果をセット
            if (rateWorkList != null)
            {
                ArrayList list = rateWorkList as ArrayList;

                rateList.AddRange((RateWork[])list.ToArray(typeof(RateWork)));
            }

            MakeDictionary(rateList);

            LogWrite("掛率取得終了");
            return status;
        }
        // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
        //----- ADD 2014/05/13 田建委 for Redmine#36564 ------->>>>>
        /// <summary>
        /// 掛率マスタ（原価）の取得(棚卸表示専用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secList">拠点リスト</param>
        /// <param name="makerList">メーカーリスト</param>
        /// <param name="rateList">取得する掛率リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/05/13</br>
        /// </remarks>
        public int SearchRateForInventoryDis(string enterpriseCode, ArrayList secList, out List<RateWork> rateList)
        {
            RateDB rateDB = new RateDB();

            rateList = new List<RateWork>();
            LogWrite("掛率 Search パラメータ:" + rateList.Count.ToString());

            int status = -1;
            object rateWorkList = null;

            // 原価設定の掛率リストを取得
            status = rateDB.SearchRateForInvoDis(out rateWorkList, enterpriseCode, secList, 2, 0);

            if (rateWorkList != null)
            {
                ArrayList list = rateWorkList as ArrayList;

                rateList.AddRange((RateWork[])list.ToArray(typeof(RateWork)));
            }

            MakeDictionary(rateList);
            
            LogWrite("掛率取得終了");
            return status;
        }

        // --- ADD 譚洪 2020/10/20 PMKOBETSU-3551の対応 ------>>>>>
        /// <summary>
        /// 掛率マスタ（原価）の取得(棚卸表示専用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secList">拠点リスト</param>
        /// <param name="rateList">取得する掛率リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/10/20</br>
        /// </remarks>
        public int SearchRateForInventoryDis2(string enterpriseCode, ArrayList secList, out List<RateWork> rateList)
        {
            RateDB rateDB = new RateDB();

            rateList = new List<RateWork>();
            LogWrite("掛率 Search パラメータ:" + rateList.Count.ToString());

            int status = -1;
            object rateWorkList = null;

            // 原価設定の掛率リストを取得
            status = rateDB.SearchRateForInvoDis2(out rateWorkList, enterpriseCode, secList, 2, 0);

            if (rateWorkList != null)
            {
                ArrayList list = rateWorkList as ArrayList;

                rateList.AddRange((RateWork[])list.ToArray(typeof(RateWork)));
            }

            MakeDictionary(rateList);

            LogWrite("掛率取得終了");
            return status;
        }
        // --- ADD 譚洪 2020/10/20 PMKOBETSU-3551の対応 ------<<<<<
        //----- ADD 2014/05/13 田建委 for Redmine#36564 -------<<<<<

        // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
        /// <summary>
        /// RateWorkのDictionary(棚卸専用)
        /// </summary>
        private Hashtable d1 = null;

        /// <summary>
        /// RateWorkのDictionary作成(棚卸専用)
        /// </summary>
        /// <param name="rateList">作成元のList</param>
        /// <remarks>
        /// <br>Note       : RateWorkのDictionary作成処理</br>
        /// <br>Programmer : 22027 橋本　将樹</br>
        /// <br>Date       : 2012.07.19</br>
        /// </remarks>
        private void MakeDictionary(List<RateWork> rateList)
        {
            d1 = new Hashtable();

            foreach (RateWork item in rateList)
            {
                Hashtable d2 = (Hashtable)d1[item.UnitPriceKind.Trim()];
                if (d2 != null)
                {
                    #region d2
                    Hashtable d3 = (Hashtable)d2[item.RateSettingDivide.Trim()];
                    if (d3 != null)
                    {
                        #region d3
                        Hashtable d4 = (Hashtable)d3[item.GoodsNo.Trim()];
                        if (d4 != null)
                        {
                            #region d4
                            Hashtable d5 = (Hashtable)d4[item.SectionCode.Trim()];
                            if (d5 != null)
                            {
                                #region d5
                                Hashtable d6 = (Hashtable)d5[item.GoodsMakerCd];
                                if (d6 != null)
                                {
                                    #region d6
                                    Hashtable d7 = (Hashtable)d6[item.GoodsRateRank.Trim()];
                                    if (d7 != null)
                                    {
                                        #region d7
                                        Hashtable d8 = (Hashtable)d7[item.GoodsRateGrpCode];
                                        if (d8 != null)
                                        {
                                            #region d8
                                            Hashtable d9 = (Hashtable)d8[item.BLGroupCode];
                                            if (d9 != null)
                                            {
                                                #region d9
                                                Hashtable d10 = (Hashtable)d9[item.BLGoodsCode];
                                                if (d10 != null)
                                                {
                                                    #region d10
                                                    Hashtable d11 = (Hashtable)d10[item.CustomerCode];
                                                    if (d11 != null)
                                                    {
                                                        #region d11
                                                        Hashtable d12 = (Hashtable)d11[item.CustRateGrpCode];
                                                        if (d12 != null)
                                                        {
                                                            List<RateWork> list = (List<RateWork>)d12[item.SupplierCd];
                                                            if (list != null) 
                                                            {
                                                                list.Add(item); 
                                                            }
                                                            else 
                                                            {
                                                                list = new List<RateWork>(); 
                                                                list.Add(item);
                                                                d12.Add(item.SupplierCd, list);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            d12 = new Hashtable();
                                                            List<RateWork> list = new List<RateWork>();
                                                            list.Add(item);
                                                            d12.Add(item.SupplierCd, list);
                                                            d11.Add(item.CustRateGrpCode, d12);
                                                        }
                                                        #endregion
                                                    }
                                                    else
                                                    {
                                                        List<RateWork> list = new List<RateWork>();
                                                        list.Add(item);
                                                        Hashtable d12 = new Hashtable();
                                                        d12.Add(item.SupplierCd, list);
                                                        d11 = new Hashtable();
                                                        d11.Add(item.CustRateGrpCode, d12);
                                                        d10.Add(item.CustomerCode, d11);
                                                    }
                                                    #endregion
                                                }
                                                else
                                                {
                                                    List<RateWork> list = new List<RateWork>();
                                                    list.Add(item);
                                                    Hashtable d12 = new Hashtable();
                                                    d12.Add(item.SupplierCd, list);
                                                    Hashtable d11 = new Hashtable();
                                                    d11.Add(item.CustRateGrpCode, d12);
                                                    d10 = new Hashtable();
                                                    d10.Add(item.CustomerCode, d11);
                                                    d9.Add(item.BLGoodsCode, d10);
                                                }
                                                #endregion
                                            }
                                            else
                                            {
                                                List<RateWork> list = new List<RateWork>();
                                                list.Add(item);
                                                Hashtable d12 = new Hashtable();
                                                d12.Add(item.SupplierCd, list);
                                                Hashtable d11 = new Hashtable();
                                                d11.Add(item.CustRateGrpCode, d12);
                                                Hashtable d10 = new Hashtable();
                                                d10.Add(item.CustomerCode, d11);
                                                d9 = new Hashtable();
                                                d9.Add(item.BLGoodsCode, d10);
                                                d8.Add(item.BLGroupCode, d9);
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            List<RateWork> list = new List<RateWork>();
                                            list.Add(item);
                                            Hashtable d12 = new Hashtable();
                                            d12.Add(item.SupplierCd, list);
                                            Hashtable d11 = new Hashtable();
                                            d11.Add(item.CustRateGrpCode, d12);
                                            Hashtable d10 = new Hashtable();
                                            d10.Add(item.CustomerCode, d11);
                                            Hashtable d9 = new Hashtable();
                                            d9.Add(item.BLGoodsCode, d10);
                                            d8 = new Hashtable();
                                            d8.Add(item.BLGroupCode, d9);
                                            d7.Add(item.GoodsRateGrpCode, d8);
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        List<RateWork> list = new List<RateWork>();
                                        list.Add(item);
                                        Hashtable d12 = new Hashtable();
                                        d12.Add(item.SupplierCd, list);
                                        Hashtable d11 = new Hashtable();
                                        d11.Add(item.CustRateGrpCode, d12);
                                        Hashtable d10 = new Hashtable();
                                        d10.Add(item.CustomerCode, d11);
                                        Hashtable d9 = new Hashtable();
                                        d9.Add(item.BLGoodsCode, d10);
                                        Hashtable d8 = new Hashtable();
                                        d8.Add(item.BLGroupCode, d9);
                                        d7 = new Hashtable();
                                        d7.Add(item.GoodsRateGrpCode, d8);
                                        d6.Add(item.GoodsRateRank.Trim(), d7);
                                    }

                                    #endregion
                                }
                                else
                                {
                                    List<RateWork> list = new List<RateWork>();
                                    list.Add(item);
                                    Hashtable d12 = new Hashtable();
                                    d12.Add(item.SupplierCd, list);
                                    Hashtable d11 = new Hashtable();
                                    d11.Add(item.CustRateGrpCode, d12);
                                    Hashtable d10 = new Hashtable();
                                    d10.Add(item.CustomerCode, d11);
                                    Hashtable d9 = new Hashtable();
                                    d9.Add(item.BLGoodsCode, d10);
                                    Hashtable d8 = new Hashtable();
                                    d8.Add(item.BLGroupCode, d9);
                                    Hashtable d7 = new Hashtable();
                                    d7.Add(item.GoodsRateGrpCode, d8);
                                    d6 = new Hashtable();
                                    d6.Add(item.GoodsRateRank.Trim(), d7);
                                    d5.Add(item.GoodsMakerCd, d6);
                                }
                                #endregion
                            }
                            else
                            {
                                List<RateWork> list = new List<RateWork>();
                                list.Add(item);
                                Hashtable d12 = new Hashtable();
                                d12.Add(item.SupplierCd, list);
                                Hashtable d11 = new Hashtable();
                                d11.Add(item.CustRateGrpCode, d12);
                                Hashtable d10 = new Hashtable();
                                d10.Add(item.CustomerCode, d11);
                                Hashtable d9 = new Hashtable();
                                d9.Add(item.BLGoodsCode, d10);
                                Hashtable d8 = new Hashtable();
                                d8.Add(item.BLGroupCode, d9);
                                Hashtable d7 = new Hashtable();
                                d7.Add(item.GoodsRateGrpCode, d8);
                                Hashtable d6 = new Hashtable();
                                d6.Add(item.GoodsRateRank.Trim(), d7);
                                d5 = new Hashtable();
                                d5.Add(item.GoodsMakerCd, d6);
                                d4.Add(item.SectionCode.Trim(), d5);
                            }
                            #endregion
                        }
                        else
                        {
                            List<RateWork> list = new List<RateWork>();
                            list.Add(item);
                            Hashtable d12 = new Hashtable();
                            d12.Add(item.SupplierCd, list);
                            Hashtable d11 = new Hashtable();
                            d11.Add(item.CustRateGrpCode, d12);
                            Hashtable d10 = new Hashtable();
                            d10.Add(item.CustomerCode, d11);
                            Hashtable d9 = new Hashtable();
                            d9.Add(item.BLGoodsCode, d10);
                            Hashtable d8 = new Hashtable();
                            d8.Add(item.BLGroupCode, d9);
                            Hashtable d7 = new Hashtable();
                            d7.Add(item.GoodsRateGrpCode, d8);
                            Hashtable d6 = new Hashtable();
                            d6.Add(item.GoodsRateRank.Trim(), d7);
                            Hashtable d5 = new Hashtable();
                            d5.Add(item.GoodsMakerCd, d6);
                            d4 = new Hashtable();
                            d4.Add(item.SectionCode.Trim(), d5);
                            d3.Add(item.GoodsNo.Trim(), d4);
                        }
                        #endregion
                    }
                    else
                    {
                        List<RateWork> list = new List<RateWork>();
                        list.Add(item);
                        Hashtable d12 = new Hashtable();
                        d12.Add(item.SupplierCd, list);
                        Hashtable d11 = new Hashtable();
                        d11.Add(item.CustRateGrpCode, d12);
                        Hashtable d10 = new Hashtable();
                        d10.Add(item.CustomerCode, d11);
                        Hashtable d9 = new Hashtable();
                        d9.Add(item.BLGoodsCode, d10);
                        Hashtable d8 = new Hashtable();
                        d8.Add(item.BLGroupCode, d9);
                        Hashtable d7 = new Hashtable();
                        d7.Add(item.GoodsRateGrpCode, d8);
                        Hashtable d6 = new Hashtable();
                        d6.Add(item.GoodsRateRank.Trim(), d7);
                        Hashtable d5 = new Hashtable();
                        d5.Add(item.GoodsMakerCd, d6);
                        Hashtable d4 = new Hashtable();
                        d4.Add(item.SectionCode.Trim(), d5);
                        d3 = new Hashtable();
                        d3.Add(item.GoodsNo.Trim(), d4);
                        d2.Add(item.RateSettingDivide.Trim(), d3);
                    }
                    #endregion
                }
                else
                {
                    List<RateWork> list = new List<RateWork>();
                    list.Add(item);
                    Hashtable d12 = new Hashtable();
                    d12.Add(item.SupplierCd, list);
                    Hashtable d11 = new Hashtable();
                    d11.Add(item.CustRateGrpCode, d12);
                    Hashtable d10 = new Hashtable();
                    d10.Add(item.CustomerCode, d11);
                    Hashtable d9 = new Hashtable();
                    d9.Add(item.BLGoodsCode, d10);
                    Hashtable d8 = new Hashtable();
                    d8.Add(item.BLGroupCode, d9);
                    Hashtable d7 = new Hashtable();
                    d7.Add(item.GoodsRateGrpCode, d8);
                    Hashtable d6 = new Hashtable();
                    d6.Add(item.GoodsRateRank.Trim(), d7);
                    Hashtable d5 = new Hashtable();
                    d5.Add(item.GoodsMakerCd, d6);
                    Hashtable d4 = new Hashtable();
                    d4.Add(item.SectionCode.Trim(), d5);
                    Hashtable d3 = new Hashtable();
                    d3.Add(item.GoodsNo.Trim(), d4);
                    d2 = new Hashtable();
                    d2.Add(item.RateSettingDivide.Trim(), d3);
                    d1.Add(item.UnitPriceKind.Trim(), d2);
                }
            }
        }
        // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

        //----ADD on 2012/07/10 for Redmine#31103 -------<<<<<<

        //----DEL 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
        /*
        //----ADD on 2012/07/10 for Redmine#31103 ------->>>>>>
        /// <summary>
        /// 単価計算処理(棚卸専用)
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="unitPriceCalcParam">単価計算パラメータ</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        private void CalculateUnitPriceProcForInventory(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(unitPriceKind);

            this.CalculateUnitPriceProcForInventory(unitPriceKindList, unitPriceCalcParam, goodsUnitData, ref unitPriceCalcRetList);
        }
        //----ADD on 2012/07/10 for Redmine#31103 -------<<<<<<

        //----ADD on 2012/07/10 for Redmine#31103 ------->>>>>>
        /// <summary>
        /// 単価計算処理(棚卸専用)
        /// </summary>
        /// <param name="unitPriceKindList">単価種類リスト</param>
        /// <param name="unitPriceCalcParam">単価計算パラメータ</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        private void CalculateUnitPriceProcForInventory(List<UnitPriceKind> unitPriceKindList, UnitPriceCalcParamWork unitPriceCalcParam, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            // 価格リストが無い場合は処理しない
            if ((goodsUnitData == null) || (goodsUnitData.GoodsNo != unitPriceCalcParam.GoodsNo) || (goodsUnitData.GoodsMakerCd != unitPriceCalcParam.GoodsMakerCd))
            {
                return;
            }
            List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>();
            unitPriceCalcParamList.Add(unitPriceCalcParam);
            List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();

            goodsUnitDataList.Add(goodsUnitData);
            this.CalculateUnitPriceProcForInventory(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
        }
        //----ADD on 2012/07/10 for Redmine#31103 -------<<<<<<

        //----ADD on 2012/07/10 for Redmine#31103 ------->>>>>>
        /// <summary>
        /// 単価計算処理(棚卸専用)
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="unitPriceCalcParamList">単価計算パラメータリスト</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        private void CalculateUnitPriceProcForInventory(UnitPriceKind unitPriceKind, List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(unitPriceKind);
            this.CalculateUnitPriceProcForInventory(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
        }
        //----ADD on 2012/07/10 for Redmine#31103 -------<<<<<<

        //----ADD on 2012/07/10 for Redmine#31103 ------->>>>>>
        /// <summary>
        /// 単価計算処理(棚卸専用)
        /// </summary>
        /// <param name="unitPriceKindList">単価種類リスト</param>
        /// <param name="unitPriceCalcParamList">単価計算パラメータリスト</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        private void CalculateUnitPriceProcForInventory(List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            LogWrite(string.Format("単価算出 開始 {0}件:", unitPriceCalcParamList.Count));

            // パラメータリスト、商品連結データオブジェクトリストが無ければ処理しない
            if ((unitPriceCalcParamList == null) || (unitPriceCalcParamList.Count == 0) || (goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
            {
                return;

            }
            //企業コード取得
            string enterpriseCode = (goodsUnitDataList[0] as GoodsUnitDataWork).EnterpriseCode;

            LogWrite("仕入金額処理区分読み込み");


            //仕入金額処理区分マスタ読み込み
            List<StockProcMoneyWork> stockProcMoneyList = this.SearchStockProcMoney(enterpriseCode);


            LogWrite("掛率読み込み");
            //優先管理読み込み
            List<RateProtyMngWork> rateProtyMngAllList = SearchRateProtyMng(enterpriseCode);
            // 掛率マスタの読み込み
            List<RateWork> rateList;

            int status = this.SearchRateForInventory(enterpriseCode, out rateList);

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
                //this.CalculateUnitCostPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, stockProcMoneyList, ref unitPriceCalcRetList, rateProtyMngAllList);//DEL yangyi 2013/05/17 Redmine#35493
                this.CalculateUnitCostPriceProcForInventory(unitPriceCalcParamList, goodsUnitDataList, rateList, stockProcMoneyList, ref unitPriceCalcRetList, rateProtyMngAllList);//ADD yangyi 2013/05/17Redmine#35493
            }

            LogWrite("単価算出 終了");
        }
        //----ADD on 2012/07/10 for Redmine#31103 -------<<<<<<
        */
        //----DEL 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

        //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
        /// <summary>
        /// 単価計算処理(棚卸専用)
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="unitPriceCalcParam">単価計算パラメータ</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        private int CalculateUnitPriceProcForInventory(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(unitPriceKind);

            int status = this.CalculateUnitPriceProcForInventory(unitPriceKindList, unitPriceCalcParam, goodsUnitData, ref unitPriceCalcRetList);
            return status;
        }

        /// <summary>
        /// 単価計算処理(棚卸専用)
        /// </summary>
        /// <param name="unitPriceKindList">単価種類リスト</param>
        /// <param name="unitPriceCalcParam">単価計算パラメータ</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <br>Update Note: 2020/07/23 譚洪</br>
        /// <br>管理番号   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551：棚卸準備処理を実行すると処理に失敗する現象の解除</br>
        private int CalculateUnitPriceProcForInventory(List<UnitPriceKind> unitPriceKindList, UnitPriceCalcParamWork unitPriceCalcParam, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // 価格リストが無い場合は処理しない
            if ((goodsUnitData == null) || (goodsUnitData.GoodsNo != unitPriceCalcParam.GoodsNo) || (goodsUnitData.GoodsMakerCd != unitPriceCalcParam.GoodsMakerCd))
            {
                return status;
            }
            List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>();
            unitPriceCalcParamList.Add(unitPriceCalcParam);
            List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();

            goodsUnitDataList.Add(goodsUnitData);
            // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
            //status = this.CalculateUnitPriceProcForInventory(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
            Dictionary<string, RateWork> rateWorkByGoodsNoDic = new Dictionary<string, RateWork>();

            status = this.CalculateUnitPriceProcForInventory(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, rateWorkByGoodsNoDic, ref unitPriceCalcRetList);
            // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
            return status;
        }

        /// <summary>
        /// 単価計算処理(棚卸専用)
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="unitPriceCalcParamList">単価計算パラメータリスト</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="rateWorkByGoodsNoDic">単品掛率マスタDic</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <br>Update Note: 2020/07/23 譚洪</br>
        /// <br>管理番号   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551：棚卸準備処理を実行すると処理に失敗する現象の解除</br>  
        // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
        //private int CalculateUnitPriceProcForInventory(UnitPriceKind unitPriceKind, List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        private int CalculateUnitPriceProcForInventory(UnitPriceKind unitPriceKind, List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, Dictionary<string, RateWork> rateWorkByGoodsNoDic, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
        {
            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(unitPriceKind);
            // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
            //int status = this.CalculateUnitPriceProcForInventory(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
            int status = this.CalculateUnitPriceProcForInventory(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, rateWorkByGoodsNoDic, ref unitPriceCalcRetList);
            // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
            return status;
        }

        /// <summary>
        /// 単価計算処理(棚卸専用)
        /// </summary>
        /// <param name="unitPriceKindList">単価種類リスト</param>
        /// <param name="unitPriceCalcParamList">単価計算パラメータリスト</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="rateWorkByGoodsNoDic">単品掛率Dic</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <br>Update Note: 2020/07/23 譚洪</br>
        /// <br>管理番号   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551：棚卸準備処理を実行すると処理に失敗する現象の解除</br>
        // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
        //private int CalculateUnitPriceProcForInventory(List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        private int CalculateUnitPriceProcForInventory(List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, Dictionary<string, RateWork> rateWorkByGoodsNoDic, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            LogWrite(string.Format("単価算出 開始 {0}件:", unitPriceCalcParamList.Count));

            // パラメータリスト、商品連結データオブジェクトリストが無ければ処理しない
            if ((unitPriceCalcParamList == null) || (unitPriceCalcParamList.Count == 0) || (goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
            {
                return status;

            }
            //企業コード取得
            string enterpriseCode = (goodsUnitDataList[0] as GoodsUnitDataWork).EnterpriseCode;

            LogWrite("仕入金額処理区分読み込み");


            //仕入金額処理区分マスタ読み込み
            List<StockProcMoneyWork> stockProcMoneyList = new List<StockProcMoneyWork>();

            status = this.SearchStockProcMoneyForInventory(enterpriseCode, out stockProcMoneyList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                return status;
            }

            LogWrite("掛率読み込み");
            //優先管理読み込み
            List<RateProtyMngWork> rateProtyMngAllList = new List<RateProtyMngWork>();
            status = SearchRateProtyMngForInventory(enterpriseCode, out rateProtyMngAllList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                return status;
            }
            // 掛率マスタの読み込み
            List<RateWork> rateList;

            // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
            //status = this.SearchRateForInventory(enterpriseCode, out rateList);
            status = this.SearchRateForInventory2(enterpriseCode, out rateList);
            // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                return status;

            }else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
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

                // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                //this.CalculateUnitCostPriceProcForInventory(unitPriceCalcParamList, goodsUnitDataList, rateList, stockProcMoneyList, ref unitPriceCalcRetList, rateProtyMngAllList);
                this.CalculateUnitCostPriceProcForInventory(unitPriceCalcParamList, goodsUnitDataList, rateList, stockProcMoneyList, rateWorkByGoodsNoDic, ref unitPriceCalcRetList, rateProtyMngAllList);
                // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
            }

            LogWrite("単価算出 終了");
            return status;
        }
        //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

        // --- ADD yangyi 2013/05/17 for Redmine#35493 ------->>>>>>>>>>>
        /// <summary>
        /// 原価単価計算処理(棚卸専用)
        /// </summary>
        /// <param name="unitPriceCalcParamList">単価算出パラメータリスト</param>
        /// <param name="goodsUnitDataList">商品構成データリスト</param>
        /// <param name="rateList">掛率リスト</param>
        /// <param name="stockProcMoneyList">仕入金額処理区分設定マスタ</param>
        /// <param name="rateWorkByGoodsNoDic">単品掛率マスタDic</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <param name="rateProtyMngAllList">掛率優先管理リスト</param>
        /// <returns></returns>
        /// <br>Update Note: 2013/06/07 wangl2</br>
        /// <br>管理番号   ：10801804-00 2013/06/18配信分</br>
        /// <br>             Redmine#35788：「棚卸準備処理」の原価取得で掛率優先順位が評価されない（№1949）</br>
        /// <br>                             エラー発生時原価が登録されない件の対応でエラー処理追加(#8の件)</br>
        /// <br>Update Note: 2020/07/23 譚洪</br>
        /// <br>管理番号   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551：棚卸準備処理を実行すると処理に失敗する現象の解除</br>
        /// <br>Update Note: 2021/03/16 譚洪</br>
        /// <br>管理番号   : 11770024-00</br>
        /// <br>             PMKOBETSU-3551：棚卸準備処理と棚卸表示の障害対応</br>
        // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
        //private void CalculateUnitCostPriceProcForInventory(List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList, List<RateProtyMngWork> rateProtyMngAllList)
        private void CalculateUnitCostPriceProcForInventory(List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList, Dictionary<string, RateWork> rateWorkByGoodsNoDic, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList, List<RateProtyMngWork> rateProtyMngAllList)
        // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
        {
            List<RateProtyMngWork> rateProtyMngList = null;

            foreach (UnitPriceCalcParamWork unitPriceCalcParam in unitPriceCalcParamList)
            {
                // 消費税の端数処理単位、端数処理区分を取得
                double taxFractionProcUnit;
                int taxFractionProcCd;
                this.GetStockFractionProcInfo(FractionProcMoney.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.StockCnsTaxFrcProcCd, 0, stockProcMoneyList, out taxFractionProcUnit, out taxFractionProcCd);

                UnitPrcCalcDiv unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;

                GoodsUnitDataWork goodsUnitData = SearchGoodsUnitData(goodsUnitDataList, unitPriceCalcParam);
                GoodsPriceUWork goodsPrice;
                bool calcPrice = false;
                this.GetPrice(unitPriceCalcParam.PriceApplyDate, goodsUnitData, out goodsPrice);

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

                    // --- DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                    //// --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                    //// 当商品の価格未設定の場合、単品掛率の価格、仕入率をセットする
                    //if ((goodsPrice.SalesUnitCost == 0) && ((goodsPrice.StockRate == 0 || goodsPrice.ListPrice == 0)))
                    //{
                    //    string key = unitPriceCalcParam.SectionCode.Trim() + "-" + unitPriceCalcParam.GoodsMakerCd.ToString("D4") + "-" + unitPriceCalcParam.GoodsNo.Trim();
                    //    if (rateWorkByGoodsNoDic.ContainsKey(key))
                    //    {
                    //        goodsPrice.SalesUnitCost = rateWorkByGoodsNoDic[key].PriceFl;
                    //        if (goodsPrice.LogicalDeleteCode == 0)
                    //        {
                    //            goodsPrice.StockRate = rateWorkByGoodsNoDic[key].RateVal;
                    //        }
                    //    }
                    //}
                    //// --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
                    // --- DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<

                    // 原単価が直接セットされている場合
                    if (goodsPrice.SalesUnitCost != 0)
                    {
                        calcPrice = true;

                        unitPrcCalcDiv = UnitPrcCalcDiv.Price;

                        // 商品の課税方式に従って分岐
                        switch (goodsUnitData.TaxationDivCd)
                        {
                            case (int)CalculateTax.TaxationCode.TaxInc:
                                unitPriceTaxInc = goodsPrice.SalesUnitCost;
                                unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxInc);
                                break;
                            case (int)CalculateTax.TaxationCode.TaxExc:
                                unitPriceTaxExc = goodsPrice.SalesUnitCost;
                                unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxExc);
                                break;
                            case (int)CalculateTax.TaxationCode.TaxNone:
                                unitPriceTaxExc = goodsPrice.SalesUnitCost;
                                unitPriceTaxInc = goodsPrice.SalesUnitCost;
                                break;
                        }
                        // 転嫁方式「非課税」時は、税込単価に税抜き単価をセット
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            unitPriceTaxInc = unitPriceTaxExc;
                        }
                    }
                    // 仕入率がセットされていて、定価がゼロ以外
                    else if ((goodsPrice.StockRate != 0) && (goodsPrice.ListPrice != 0))
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
                            stockProcMoneyList,
                            ref unPrcFracProcUnit,
                            ref unPrcFracProcDiv,
                            out unitPriceTaxExc,
                            out unitPriceTaxInc);
                    }

                    // ここまでで原価計算された場合は結果をセット
                    if (calcPrice)
                    {
                        UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                        unitPriceCalcRet.UnitPriceKind = ((int)UnitPriceKind.UnitCost).ToString();
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

                        unitPriceCalcRetList.Add(unitPriceCalcRet);
                    }
                    else
                    {
                        // 掛率優先管理情報を取得する
                        rateProtyMngList = this.GetRateProtyMngList(rateProtyMngAllList, goodsUnitData.EnterpriseCode, unitPriceCalcParam.SectionCode, UnitPriceKind.UnitCost);//ADD on 2012/07/10 for Redmine#31103
                        //----DEL 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                        //if (rateProtyMngList != null)
                        //{
                        //    this.CalculateUnitPriceByRateListForInventory(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList);
                        //}
                        //----DEL 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
                        //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                        if (rateProtyMngList == null)
                        {
                            rateProtyMngList = new List<RateProtyMngWork>();
                        }
                        // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                        //this.CalculateUnitPriceByRateListForInventory(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList);
                        this.CalculateUnitPriceByRateListForInventory(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList, rateWorkByGoodsNoDic);
                        // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
                        //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

                    }
                }
                else
                {
                    UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                    unitPriceCalcRet.UnitPriceKind = ((int)UnitPriceKind.UnitCost).ToString();       // 単価種類
                    unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;             // 商品コード
                    unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;   // メーカーコード
                    unitPriceCalcRet.SupplierCd = 0;                                   // 仕入先コード

                    unitPriceCalcRetList.Add(unitPriceCalcRet);
                }
            }
        }
        // --- ADD yangyi 2013/05/17 for Redmine#35493 -------<<<<<<<<<<<

        //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
        /// <summary>
        /// 掛率優先管理検索
        /// </summary>
        public int SearchRateProtyMngForInventory(string _enterpriseCode, out List<RateProtyMngWork> _rateProtyMngAllList)
        {
            _rateProtyMngAllList = new List<RateProtyMngWork>();

            RateProtyMngDB rateProtyMngDB = new RateProtyMngDB();

            ArrayList paralist = new ArrayList();
            RateProtyMngWork paraWork = new RateProtyMngWork();
            paraWork.EnterpriseCode = _enterpriseCode;

            paralist.Add(paraWork);

            ReadComCompanyInf(_enterpriseCode);// ADD caohh 2015/03/06 for Redmine#44951

            object rateProtyMngWorkList = null;

            //掛率優先管理の読み込み
            int status = rateProtyMngDB.Search(out rateProtyMngWorkList, paralist, 0, 0);

            if (rateProtyMngWorkList != null)
            {
                ArrayList list = rateProtyMngWorkList as ArrayList;

                _rateProtyMngAllList = new List<RateProtyMngWork>();
                _rateProtyMngAllList.AddRange((RateProtyMngWork[])list.ToArray(typeof(RateProtyMngWork)));

                // 拠点、単価種類、優先順位でソート
                _rateProtyMngAllList.Sort(new FractionProcMoney.RateProtyMngComparer());
            }
            return status;
        }

        // --- ADD caohh 2015/03/06 for Redmine#44951 ----->>>>>
        /// <summary>
        ///自社設定マスタから掛率優先順位の取得処理
        /// </summary>
        /// <param name="_enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : 自社設定マスタから掛率優先順位の設定を取得します。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2015/03/06</br>
        /// <br>Update Note: 2015/03/23 xuyb</br>
        /// <br>管理番号   : 11070253-00 </br>
        /// <br>           : Redmine#44492の#99 売上月次更新の仕入単価・仕入率算出不具合の修正（#44951の#50のNo.2）対応</br>
        /// </remarks>
        private void ReadComCompanyInf(string _enterpriseCode)
        {
            // リモートオブジェクト取得
            CompanyInfDB companyInfDB = new CompanyInfDB();

            CompanyInfWork companyInfWork = new CompanyInfWork();
            companyInfWork.EnterpriseCode = _enterpriseCode;
            companyInfWork.CompanyCode = 0;	//←取りあえず０固定読み
            object paraObj = companyInfWork;

            if (this._ratePriorityDivDic == null) this._ratePriorityDivDic = new Dictionary<string, int>();  //優先級 // ADD xuyb 2015/03/23 for Redmine#44492
            int status = companyInfDB.Read(ref paraObj, 0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                companyInfWork = (CompanyInfWork)paraObj;
                //this._ratePriorityDiv = companyInfWork.RatePriorityDiv;  // DEL xuyb 2015/03/23 for Redmine#44492
                // --------------------- ADD xuyb 2015/03/23 for Redmine#44492 --------------->>>>>
                if (this._ratePriorityDivDic.ContainsKey(_enterpriseCode))
                {
                    this._ratePriorityDivDic[_enterpriseCode] = companyInfWork.RatePriorityDiv;
                }
                else
                {
                    this._ratePriorityDivDic.Add(_enterpriseCode, companyInfWork.RatePriorityDiv);
                }
                // --------------------- ADD xuyb 2015/03/23 for Redmine#44492 ---------------<<<<<
            }
        }
        // --- ADD caohh 2015/03/06 for Redmine#44951 -----<<<<<

        // <summary>
        /// 仕入金額端数処理区分設定検索
        /// </summary>
        public int SearchStockProcMoneyForInventory(string _enterpriseCode, out List<StockProcMoneyWork> _stockProcMoneyList)
        {
            _stockProcMoneyList = new List<StockProcMoneyWork>();

            StockProcMoneyDB stockProcMoneyDB = new StockProcMoneyDB();

            StockProcMoneyWork paraWork = new StockProcMoneyWork();
            paraWork.EnterpriseCode = _enterpriseCode;
            paraWork.FracProcMoneyDiv = -1;
            paraWork.FractionProcCode = -1;

            ArrayList paraList = new ArrayList();
            paraList.Add(paraWork);

            object retobj = null;

            int status = stockProcMoneyDB.Search(out retobj, paraList, 0, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList list = retobj as ArrayList;

                _stockProcMoneyList.AddRange((StockProcMoneyWork[])list.ToArray(typeof(StockProcMoneyWork)));

                _stockProcMoneyList.Sort(new FractionProcMoney.StockProcMoneyComparer());
            }

            return status;
        }
        //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
	}

}