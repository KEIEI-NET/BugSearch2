using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting.ParamData
{
	#region ■単価計算パラメータクラス
    /// public class name:   UnitPriceCalcParam
    /// <summary>
    ///                      単価計算パラメータ
    /// </summary>
    /// <remarks>
    /// <br>note             :   単価計算パラメータヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UnitPriceCalcParamWork
    {
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品掛率ランク</summary>
        /// <remarks>層別</remarks>
        private string _goodsRateRank = "";

        /// <summary>商品掛率グループコード</summary>
        /// <remarks>中分類を使用</remarks>
        private Int32 _goodsRateGrpCode;

        /// <summary>BLグループコード</summary>
        private Int32 _bLGroupCode;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先掛率グループコード</summary>
        private Int32 _custRateGrpCode;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>価格適用日</summary>
        private DateTime _priceApplyDate;

        /// <summary>数量</summary>
        private Double _countFl;

        /// <summary>課税区分</summary>
        private Int32 _taxationDivCd;

        /// <summary>税率</summary>
        private Double _taxRate;

        /// <summary>売上消費税端数処理コード</summary>
        /// <remarks>0の場合は標準設定(売上単価、定価を算出する際に使用)</remarks>
        private Int32 _salesCnsTaxFrcProcCd;

        /// <summary>仕入消費税端数処理コード</summary>
        /// <remarks>0の場合は 標準設定(原価単価を算出する際に使用)</remarks>
        private Int32 _stockCnsTaxFrcProcCd;

        /// <summary>総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>総額表示掛率適用区分</summary>
        /// <remarks>0：税込単価, 1:税抜単価</remarks>
        private Int32 _ttlAmntDspRateDivCd;

        /// <summary>売上単価端数処理コード</summary>
        /// <remarks>0の場合は標準設定(売上単価、定価を算出する際に使用)</remarks>
        private Int32 _salesUnPrcFrcProcCd;

        /// <summary>仕入単価端数処理コード</summary>
        /// <remarks>0の場合は 標準設定(原価単価を算出する際に使用)</remarks>
        private Int32 _stockUnPrcFrcProcCd;

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親3:請求子　9:非課税</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>BL商品コード名称</summary>
        private string _bLGoodsName = "";


        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>商品掛率ランクプロパティ</summary>
        /// <value>層別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率ランクプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>商品掛率グループコードプロパティ</summary>
        /// <value>中分類を使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsRateGrpCode
        {
            get { return _goodsRateGrpCode; }
            set { _goodsRateGrpCode = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>得意先掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  PriceApplyDate
        /// <summary>価格適用日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格適用日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PriceApplyDate
        {
            get { return _priceApplyDate; }
            set { _priceApplyDate = value; }
        }

        /// public propaty name  :  CountFl
        /// <summary>数量プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CountFl
        {
            get { return _countFl; }
            set { _countFl = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  TaxRate
        /// <summary>税率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TaxRate
        {
            get { return _taxRate; }
            set { _taxRate = value; }
        }

        /// public propaty name  :  SalesCnsTaxFrcProcCd
        /// <summary>売上消費税端数処理コードプロパティ</summary>
        /// <value>0の場合は標準設定(売上単価、定価を算出する際に使用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上消費税端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCnsTaxFrcProcCd
        {
            get { return _salesCnsTaxFrcProcCd; }
            set { _salesCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  StockCnsTaxFrcProcCd
        /// <summary>仕入消費税端数処理コードプロパティ</summary>
        /// <value>0の場合は 標準設定(原価単価を算出する際に使用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入消費税端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockCnsTaxFrcProcCd
        {
            get { return _stockCnsTaxFrcProcCd; }
            set { _stockCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>総額表示方法区分プロパティ</summary>
        /// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示方法区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TtlAmntDspRateDivCd
        /// <summary>総額表示掛率適用区分プロパティ</summary>
        /// <value>0：税込単価, 1:税抜単価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示掛率適用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TtlAmntDspRateDivCd
        {
            get { return _ttlAmntDspRateDivCd; }
            set { _ttlAmntDspRateDivCd = value; }
        }

        /// public propaty name  :  SalesUnPrcFrcProcCd
        /// <summary>売上単価端数処理コードプロパティ</summary>
        /// <value>0の場合は標準設定(売上単価、定価を算出する際に使用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesUnPrcFrcProcCd
        {
            get { return _salesUnPrcFrcProcCd; }
            set { _salesUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  StockUnPrcFrcProcCd
        /// <summary>仕入単価端数処理コードプロパティ</summary>
        /// <value>0の場合は 標準設定(原価単価を算出する際に使用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockUnPrcFrcProcCd
        {
            get { return _stockUnPrcFrcProcCd; }
            set { _stockUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>消費税転嫁方式プロパティ</summary>
        /// <value>0:伝票単位1:明細単位2:請求親3:請求子　9:非課税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  BLGoodsName
        /// <summary>BL商品コード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }


        /// <summary>
        /// 単価計算パラメータコンストラクタ
        /// </summary>
        /// <returns>UnitPriceCalcParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnitPriceCalcParamクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UnitPriceCalcParamWork()
        {
        }

        /// <summary>
        /// 単価計算パラメータコンストラクタ
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsRateRank">商品掛率ランク(層別)</param>
        /// <param name="goodsRateGrpCode">商品掛率グループコード(中分類を使用)</param>
        /// <param name="bLGroupCode">BLグループコード</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="priceApplyDate">価格適用日</param>
        /// <param name="countFl">数量</param>
        /// <param name="taxationDivCd">課税区分</param>
        /// <param name="taxRate">税率</param>
        /// <param name="salesCnsTaxFrcProcCd">売上消費税端数処理コード(0の場合は標準設定(売上単価、定価を算出する際に使用))</param>
        /// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード(0の場合は 標準設定(原価単価を算出する際に使用))</param>
        /// <param name="totalAmountDispWayCd">総額表示方法区分(0:総額表示しない（税抜き）,1:総額表示する（税込み）)</param>
        /// <param name="ttlAmntDspRateDivCd">総額表示掛率適用区分(0：税込単価, 1:税抜単価)</param>
        /// <param name="salesUnPrcFrcProcCd">売上単価端数処理コード(0の場合は標準設定(売上単価、定価を算出する際に使用))</param>
        /// <param name="stockUnPrcFrcProcCd">仕入単価端数処理コード(0の場合は 標準設定(原価単価を算出する際に使用))</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式(0:伝票単位1:明細単位2:請求親3:請求子　9:非課税)</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <returns>UnitPriceCalcParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnitPriceCalcParamクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UnitPriceCalcParamWork(string sectionCode, Int32 goodsMakerCd, string goodsNo, string goodsRateRank, Int32 goodsRateGrpCode, Int32 bLGroupCode, Int32 bLGoodsCode, Int32 customerCode, Int32 custRateGrpCode, Int32 supplierCd, DateTime priceApplyDate, Double countFl, Int32 taxationDivCd, Double taxRate, Int32 salesCnsTaxFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd, Int32 salesUnPrcFrcProcCd, Int32 stockUnPrcFrcProcCd, Int32 consTaxLayMethod, string bLGoodsName)
        {
            this._sectionCode = sectionCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._goodsRateRank = goodsRateRank;
            this._goodsRateGrpCode = goodsRateGrpCode;
            this._bLGroupCode = bLGroupCode;
            this._bLGoodsCode = bLGoodsCode;
            this._customerCode = customerCode;
            this._custRateGrpCode = custRateGrpCode;
            this._supplierCd = supplierCd;
            this._priceApplyDate = priceApplyDate;
            this._countFl = countFl;
            this._taxationDivCd = taxationDivCd;
            this._taxRate = taxRate;
            this._salesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;
            this._stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
            this._ttlAmntDspRateDivCd = ttlAmntDspRateDivCd;
            this._salesUnPrcFrcProcCd = salesUnPrcFrcProcCd;
            this._stockUnPrcFrcProcCd = stockUnPrcFrcProcCd;
            this._consTaxLayMethod = consTaxLayMethod;
            this._bLGoodsName = bLGoodsName;

        }

        /// <summary>
        /// 単価計算パラメータ複製処理
        /// </summary>
        /// <returns>UnitPriceCalcParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいUnitPriceCalcParamクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UnitPriceCalcParamWork Clone()
        {
            return new UnitPriceCalcParamWork(this._sectionCode, this._goodsMakerCd, this._goodsNo, this._goodsRateRank, this._goodsRateGrpCode, this._bLGroupCode, this._bLGoodsCode, this._customerCode, this._custRateGrpCode, this._supplierCd, this._priceApplyDate, this._countFl, this._taxationDivCd, this._taxRate, this._salesCnsTaxFrcProcCd, this._stockCnsTaxFrcProcCd, this._totalAmountDispWayCd, this._ttlAmntDspRateDivCd, this._salesUnPrcFrcProcCd, this._stockUnPrcFrcProcCd, this._consTaxLayMethod, this._bLGoodsName);
        }

        /// <summary>
        /// 単価計算パラメータ比較処理
        /// </summary>
        /// <param name="target">比較対象のUnitPriceCalcParamクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnitPriceCalcParamクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(UnitPriceCalcParamWork target)
        {
            return ( ( this.SectionCode == target.SectionCode )
                 && ( this.GoodsMakerCd == target.GoodsMakerCd )
                 && ( this.GoodsNo == target.GoodsNo )
                 && ( this.GoodsRateRank == target.GoodsRateRank )
                 && ( this.GoodsRateGrpCode == target.GoodsRateGrpCode )
                 && ( this.BLGroupCode == target.BLGroupCode )
                 && ( this.BLGoodsCode == target.BLGoodsCode )
                 && ( this.CustomerCode == target.CustomerCode )
                 && ( this.CustRateGrpCode == target.CustRateGrpCode )
                 && ( this.SupplierCd == target.SupplierCd )
                 && ( this.PriceApplyDate == target.PriceApplyDate )
                 && ( this.CountFl == target.CountFl )
                 && ( this.TaxationDivCd == target.TaxationDivCd )
                 && ( this.TaxRate == target.TaxRate )
                 && ( this.SalesCnsTaxFrcProcCd == target.SalesCnsTaxFrcProcCd )
                 && ( this.StockCnsTaxFrcProcCd == target.StockCnsTaxFrcProcCd )
                 && ( this.TotalAmountDispWayCd == target.TotalAmountDispWayCd )
                 && ( this.TtlAmntDspRateDivCd == target.TtlAmntDspRateDivCd )
                 && ( this.SalesUnPrcFrcProcCd == target.SalesUnPrcFrcProcCd )
                 && ( this.StockUnPrcFrcProcCd == target.StockUnPrcFrcProcCd )
                 && ( this.ConsTaxLayMethod == target.ConsTaxLayMethod )
                 && ( this.BLGoodsName == target.BLGoodsName ) );
        }

        /// <summary>
        /// 単価計算パラメータ比較処理
        /// </summary>
        /// <param name="unitPriceCalcParam1">
        ///                    比較するUnitPriceCalcParamクラスのインスタンス
        /// </param>
        /// <param name="unitPriceCalcParam2">比較するUnitPriceCalcParamクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnitPriceCalcParamクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(UnitPriceCalcParamWork unitPriceCalcParam1, UnitPriceCalcParamWork unitPriceCalcParam2)
        {
            return ( ( unitPriceCalcParam1.SectionCode == unitPriceCalcParam2.SectionCode )
                 && ( unitPriceCalcParam1.GoodsMakerCd == unitPriceCalcParam2.GoodsMakerCd )
                 && ( unitPriceCalcParam1.GoodsNo == unitPriceCalcParam2.GoodsNo )
                 && ( unitPriceCalcParam1.GoodsRateRank == unitPriceCalcParam2.GoodsRateRank )
                 && ( unitPriceCalcParam1.GoodsRateGrpCode == unitPriceCalcParam2.GoodsRateGrpCode )
                 && ( unitPriceCalcParam1.BLGroupCode == unitPriceCalcParam2.BLGroupCode )
                 && ( unitPriceCalcParam1.BLGoodsCode == unitPriceCalcParam2.BLGoodsCode )
                 && ( unitPriceCalcParam1.CustomerCode == unitPriceCalcParam2.CustomerCode )
                 && ( unitPriceCalcParam1.CustRateGrpCode == unitPriceCalcParam2.CustRateGrpCode )
                 && ( unitPriceCalcParam1.SupplierCd == unitPriceCalcParam2.SupplierCd )
                 && ( unitPriceCalcParam1.PriceApplyDate == unitPriceCalcParam2.PriceApplyDate )
                 && ( unitPriceCalcParam1.CountFl == unitPriceCalcParam2.CountFl )
                 && ( unitPriceCalcParam1.TaxationDivCd == unitPriceCalcParam2.TaxationDivCd )
                 && ( unitPriceCalcParam1.TaxRate == unitPriceCalcParam2.TaxRate )
                 && ( unitPriceCalcParam1.SalesCnsTaxFrcProcCd == unitPriceCalcParam2.SalesCnsTaxFrcProcCd )
                 && ( unitPriceCalcParam1.StockCnsTaxFrcProcCd == unitPriceCalcParam2.StockCnsTaxFrcProcCd )
                 && ( unitPriceCalcParam1.TotalAmountDispWayCd == unitPriceCalcParam2.TotalAmountDispWayCd )
                 && ( unitPriceCalcParam1.TtlAmntDspRateDivCd == unitPriceCalcParam2.TtlAmntDspRateDivCd )
                 && ( unitPriceCalcParam1.SalesUnPrcFrcProcCd == unitPriceCalcParam2.SalesUnPrcFrcProcCd )
                 && ( unitPriceCalcParam1.StockUnPrcFrcProcCd == unitPriceCalcParam2.StockUnPrcFrcProcCd )
                 && ( unitPriceCalcParam1.ConsTaxLayMethod == unitPriceCalcParam2.ConsTaxLayMethod )
                 && ( unitPriceCalcParam1.BLGoodsName == unitPriceCalcParam2.BLGoodsName ) );
        }
        /// <summary>
        /// 単価計算パラメータ比較処理
        /// </summary>
        /// <param name="target">比較対象のUnitPriceCalcParamクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnitPriceCalcParamクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(UnitPriceCalcParamWork target)
        {
            ArrayList resList = new ArrayList();
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsRateRank != target.GoodsRateRank) resList.Add("GoodsRateRank");
            if (this.GoodsRateGrpCode != target.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.PriceApplyDate != target.PriceApplyDate) resList.Add("PriceApplyDate");
            if (this.CountFl != target.CountFl) resList.Add("CountFl");
            if (this.TaxationDivCd != target.TaxationDivCd) resList.Add("TaxationDivCd");
            if (this.TaxRate != target.TaxRate) resList.Add("TaxRate");
            if (this.SalesCnsTaxFrcProcCd != target.SalesCnsTaxFrcProcCd) resList.Add("SalesCnsTaxFrcProcCd");
            if (this.StockCnsTaxFrcProcCd != target.StockCnsTaxFrcProcCd) resList.Add("StockCnsTaxFrcProcCd");
            if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (this.TtlAmntDspRateDivCd != target.TtlAmntDspRateDivCd) resList.Add("TtlAmntDspRateDivCd");
            if (this.SalesUnPrcFrcProcCd != target.SalesUnPrcFrcProcCd) resList.Add("SalesUnPrcFrcProcCd");
            if (this.StockUnPrcFrcProcCd != target.StockUnPrcFrcProcCd) resList.Add("StockUnPrcFrcProcCd");
            if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }

        /// <summary>
        /// 単価計算パラメータ比較処理
        /// </summary>
        /// <param name="unitPriceCalcParam1">比較するUnitPriceCalcParamクラスのインスタンス</param>
        /// <param name="unitPriceCalcParam2">比較するUnitPriceCalcParamクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnitPriceCalcParamクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(UnitPriceCalcParamWork unitPriceCalcParam1, UnitPriceCalcParamWork unitPriceCalcParam2)
        {
            ArrayList resList = new ArrayList();
            if (unitPriceCalcParam1.SectionCode != unitPriceCalcParam2.SectionCode) resList.Add("SectionCode");
            if (unitPriceCalcParam1.GoodsMakerCd != unitPriceCalcParam2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (unitPriceCalcParam1.GoodsNo != unitPriceCalcParam2.GoodsNo) resList.Add("GoodsNo");
            if (unitPriceCalcParam1.GoodsRateRank != unitPriceCalcParam2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (unitPriceCalcParam1.GoodsRateGrpCode != unitPriceCalcParam2.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (unitPriceCalcParam1.BLGroupCode != unitPriceCalcParam2.BLGroupCode) resList.Add("BLGroupCode");
            if (unitPriceCalcParam1.BLGoodsCode != unitPriceCalcParam2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (unitPriceCalcParam1.CustomerCode != unitPriceCalcParam2.CustomerCode) resList.Add("CustomerCode");
            if (unitPriceCalcParam1.CustRateGrpCode != unitPriceCalcParam2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (unitPriceCalcParam1.SupplierCd != unitPriceCalcParam2.SupplierCd) resList.Add("SupplierCd");
            if (unitPriceCalcParam1.PriceApplyDate != unitPriceCalcParam2.PriceApplyDate) resList.Add("PriceApplyDate");
            if (unitPriceCalcParam1.CountFl != unitPriceCalcParam2.CountFl) resList.Add("CountFl");
            if (unitPriceCalcParam1.TaxationDivCd != unitPriceCalcParam2.TaxationDivCd) resList.Add("TaxationDivCd");
            if (unitPriceCalcParam1.TaxRate != unitPriceCalcParam2.TaxRate) resList.Add("TaxRate");
            if (unitPriceCalcParam1.SalesCnsTaxFrcProcCd != unitPriceCalcParam2.SalesCnsTaxFrcProcCd) resList.Add("SalesCnsTaxFrcProcCd");
            if (unitPriceCalcParam1.StockCnsTaxFrcProcCd != unitPriceCalcParam2.StockCnsTaxFrcProcCd) resList.Add("StockCnsTaxFrcProcCd");
            if (unitPriceCalcParam1.TotalAmountDispWayCd != unitPriceCalcParam2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (unitPriceCalcParam1.TtlAmntDspRateDivCd != unitPriceCalcParam2.TtlAmntDspRateDivCd) resList.Add("TtlAmntDspRateDivCd");
            if (unitPriceCalcParam1.SalesUnPrcFrcProcCd != unitPriceCalcParam2.SalesUnPrcFrcProcCd) resList.Add("SalesUnPrcFrcProcCd");
            if (unitPriceCalcParam1.StockUnPrcFrcProcCd != unitPriceCalcParam2.StockUnPrcFrcProcCd) resList.Add("StockUnPrcFrcProcCd");
            if (unitPriceCalcParam1.ConsTaxLayMethod != unitPriceCalcParam2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (unitPriceCalcParam1.BLGoodsName != unitPriceCalcParam2.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }
    }
    #endregion 

	#region ■単価算出結果クラス
    /// public class name:   UnitPriceCalcRet
    /// <summary>
    ///                      単価計算結果
    /// </summary>
    /// <remarks>
    /// <br>note             :   単価計算結果ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UnitPriceCalcRetWork
    {
        /// <summary>単価種類</summary>
        /// <remarks>1:売上単価　2:売上原価　3:仕入単価 4:定価 5:作業原価 6:作業売価</remarks>
        private string _unitPriceKind = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>掛率設定区分</summary>
        /// <remarks>A1,A2等</remarks>
        private string _rateSettingDivide = "";

        /// <summary>掛率設定区分（商品）</summary>
        /// <remarks>A～O　</remarks>
        private string _rateMngGoodsCd = "";

        /// <summary>掛率設定名称（商品）</summary>
        /// <remarks>A： "メーカー＋商品"</remarks>
        private string _rateMngGoodsNm = "";

        /// <summary>掛率設定区分（得意先）</summary>
        /// <remarks>1～9　</remarks>
        private string _rateMngCustCd = "";

        /// <summary>掛率設定名称（得意先）</summary>
        /// <remarks>1： "得意先＋仕入先"</remarks>
        private string _rateMngCustNm = "";

        /// <summary>単価算出区分</summary>
        /// <remarks>1:掛率,2:原価ＵＰ率,3:粗利率</remarks>
        private Int32 _unitPrcCalcDiv;

        /// <summary>価格区分</summary>
        /// <remarks>0:定価 固定</remarks>
        private Int32 _priceDiv;

        /// <summary>基準単価</summary>
        private Double _stdUnitPrice;

        /// <summary>掛率</summary>
        /// <remarks>売価率、原価率、仕入率、定価UP率</remarks>
        private Double _rateVal;

        /// <summary>単価端数処理単位</summary>
        private Double _unPrcFracProcUnit;

        /// <summary>単価端数処理区分</summary>
        private Int32 _unPrcFracProcDiv;

        /// <summary>単価（税抜，浮動）</summary>
        private Double _unitPriceTaxExcFl;

        /// <summary>単価（税込，浮動）</summary>
        private Double _unitPriceTaxIncFl;

        /// <summary>オープン価格区分</summary>
        private Int32 _openPriceDiv;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>掛率優先順位</summary>
        private Int32 _ratePriorityOrder;

        /// <summary>価格開始日</summary>
        /// <remarks>価格マスタの価格開始日</remarks>
        private DateTime _priceStartDate;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;


        /// public propaty name  :  UnitPriceKind
        /// <summary>単価種類プロパティ</summary>
        /// <value>1:売上単価　2:売上原価　3:仕入単価 4:定価 5:作業原価 6:作業売価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価種類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UnitPriceKind
        {
            get { return _unitPriceKind; }
            set { _unitPriceKind = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  RateSettingDivide
        /// <summary>掛率設定区分プロパティ</summary>
        /// <value>A1,A2等</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateSettingDivide
        {
            get { return _rateSettingDivide; }
            set { _rateSettingDivide = value; }
        }

        /// public propaty name  :  RateMngGoodsCd
        /// <summary>掛率設定区分（商品）プロパティ</summary>
        /// <value>A～O　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定区分（商品）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateMngGoodsCd
        {
            get { return _rateMngGoodsCd; }
            set { _rateMngGoodsCd = value; }
        }

        /// public propaty name  :  RateMngGoodsNm
        /// <summary>掛率設定名称（商品）プロパティ</summary>
        /// <value>A： "メーカー＋商品"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定名称（商品）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateMngGoodsNm
        {
            get { return _rateMngGoodsNm; }
            set { _rateMngGoodsNm = value; }
        }

        /// public propaty name  :  RateMngCustCd
        /// <summary>掛率設定区分（得意先）プロパティ</summary>
        /// <value>1～9　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定区分（得意先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateMngCustCd
        {
            get { return _rateMngCustCd; }
            set { _rateMngCustCd = value; }
        }

        /// public propaty name  :  RateMngCustNm
        /// <summary>掛率設定名称（得意先）プロパティ</summary>
        /// <value>1： "得意先＋仕入先"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定名称（得意先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateMngCustNm
        {
            get { return _rateMngCustNm; }
            set { _rateMngCustNm = value; }
        }

        /// public propaty name  :  UnitPrcCalcDiv
        /// <summary>単価算出区分プロパティ</summary>
        /// <value>1:掛率,2:原価ＵＰ率,3:粗利率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価算出区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnitPrcCalcDiv
        {
            get { return _unitPrcCalcDiv; }
            set { _unitPrcCalcDiv = value; }
        }

        /// public propaty name  :  PriceDiv
        /// <summary>価格区分プロパティ</summary>
        /// <value>0:定価 固定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceDiv
        {
            get { return _priceDiv; }
            set { _priceDiv = value; }
        }

        /// public propaty name  :  StdUnitPrice
        /// <summary>基準単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StdUnitPrice
        {
            get { return _stdUnitPrice; }
            set { _stdUnitPrice = value; }
        }

        /// public propaty name  :  RateVal
        /// <summary>掛率プロパティ</summary>
        /// <value>売価率、原価率、仕入率、定価UP率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double RateVal
        {
            get { return _rateVal; }
            set { _rateVal = value; }
        }

        /// public propaty name  :  UnPrcFracProcUnit
        /// <summary>単価端数処理単位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価端数処理単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double UnPrcFracProcUnit
        {
            get { return _unPrcFracProcUnit; }
            set { _unPrcFracProcUnit = value; }
        }

        /// public propaty name  :  UnPrcFracProcDiv
        /// <summary>単価端数処理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価端数処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnPrcFracProcDiv
        {
            get { return _unPrcFracProcDiv; }
            set { _unPrcFracProcDiv = value; }
        }

        /// public propaty name  :  UnitPriceTaxExcFl
        /// <summary>単価（税抜，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double UnitPriceTaxExcFl
        {
            get { return _unitPriceTaxExcFl; }
            set { _unitPriceTaxExcFl = value; }
        }

        /// public propaty name  :  UnitPriceTaxIncFl
        /// <summary>単価（税込，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double UnitPriceTaxIncFl
        {
            get { return _unitPriceTaxIncFl; }
            set { _unitPriceTaxIncFl = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  RatePriorityOrder
        /// <summary>掛率優先順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率優先順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RatePriorityOrder
        {
            get { return _ratePriorityOrder; }
            set { _ratePriorityOrder = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>価格開始日プロパティ</summary>
        /// <value>価格マスタの価格開始日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  PriceStartDateJpFormal
        /// <summary>価格開始日 和暦プロパティ</summary>
        /// <value>価格マスタの価格開始日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriceStartDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _priceStartDate); }
            set { }
        }

        /// public propaty name  :  PriceStartDateJpInFormal
        /// <summary>価格開始日 和暦(略)プロパティ</summary>
        /// <value>価格マスタの価格開始日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriceStartDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _priceStartDate); }
            set { }
        }

        /// public propaty name  :  PriceStartDateAdFormal
        /// <summary>価格開始日 西暦プロパティ</summary>
        /// <value>価格マスタの価格開始日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriceStartDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _priceStartDate); }
            set { }
        }

        /// public propaty name  :  PriceStartDateAdInFormal
        /// <summary>価格開始日 西暦(略)プロパティ</summary>
        /// <value>価格マスタの価格開始日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriceStartDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _priceStartDate); }
            set { }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }


        /// <summary>
        /// 単価計算結果コンストラクタ
        /// </summary>
        /// <returns>UnitPriceCalcRetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnitPriceCalcRetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UnitPriceCalcRetWork()
        {
        }

        /// <summary>
        /// 単価計算結果コンストラクタ
        /// </summary>
        /// <param name="unitPriceKind">単価種類(1:売上単価　2:売上原価　3:仕入単価 4:定価 5:作業原価 6:作業売価)</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="rateSettingDivide">掛率設定区分(A1,A2等)</param>
        /// <param name="rateMngGoodsCd">掛率設定区分（商品）(A～O　)</param>
        /// <param name="rateMngGoodsNm">掛率設定名称（商品）(A： "メーカー＋商品")</param>
        /// <param name="rateMngCustCd">掛率設定区分（得意先）(1～9　)</param>
        /// <param name="rateMngCustNm">掛率設定名称（得意先）(1： "得意先＋仕入先")</param>
        /// <param name="unitPrcCalcDiv">単価算出区分(1:掛率,2:原価ＵＰ率,3:粗利率)</param>
        /// <param name="priceDiv">価格区分(0:定価 固定)</param>
        /// <param name="stdUnitPrice">基準単価</param>
        /// <param name="rateVal">掛率(売価率、原価率、仕入率、定価UP率)</param>
        /// <param name="unPrcFracProcUnit">単価端数処理単位</param>
        /// <param name="unPrcFracProcDiv">単価端数処理区分</param>
        /// <param name="unitPriceTaxExcFl">単価（税抜，浮動）</param>
        /// <param name="unitPriceTaxIncFl">単価（税込，浮動）</param>
        /// <param name="openPriceDiv">オープン価格区分</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="ratePriorityOrder">掛率優先順位</param>
        /// <param name="priceStartDate">価格開始日(価格マスタの価格開始日)</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <returns>UnitPriceCalcRetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnitPriceCalcRetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UnitPriceCalcRetWork(string unitPriceKind, Int32 goodsMakerCd, string goodsNo, string rateSettingDivide, string rateMngGoodsCd, string rateMngGoodsNm, string rateMngCustCd, string rateMngCustNm, Int32 unitPrcCalcDiv, Int32 priceDiv, Double stdUnitPrice, Double rateVal, Double unPrcFracProcUnit, Int32 unPrcFracProcDiv, Double unitPriceTaxExcFl, Double unitPriceTaxIncFl, Int32 openPriceDiv, string sectionCode, Int32 ratePriorityOrder, DateTime priceStartDate, Int32 supplierCd)
        {
            this._unitPriceKind = unitPriceKind;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._rateSettingDivide = rateSettingDivide;
            this._rateMngGoodsCd = rateMngGoodsCd;
            this._rateMngGoodsNm = rateMngGoodsNm;
            this._rateMngCustCd = rateMngCustCd;
            this._rateMngCustNm = rateMngCustNm;
            this._unitPrcCalcDiv = unitPrcCalcDiv;
            this._priceDiv = priceDiv;
            this._stdUnitPrice = stdUnitPrice;
            this._rateVal = rateVal;
            this._unPrcFracProcUnit = unPrcFracProcUnit;
            this._unPrcFracProcDiv = unPrcFracProcDiv;
            this._unitPriceTaxExcFl = unitPriceTaxExcFl;
            this._unitPriceTaxIncFl = unitPriceTaxIncFl;
            this._openPriceDiv = openPriceDiv;
            this._sectionCode = sectionCode;
            this._ratePriorityOrder = ratePriorityOrder;
            this.PriceStartDate = priceStartDate;
            this._supplierCd = supplierCd;

        }

        /// <summary>
        /// 単価計算結果複製処理
        /// </summary>
        /// <returns>UnitPriceCalcRetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいUnitPriceCalcRetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UnitPriceCalcRetWork Clone()
        {
            return new UnitPriceCalcRetWork(this._unitPriceKind, this._goodsMakerCd, this._goodsNo, this._rateSettingDivide, this._rateMngGoodsCd, this._rateMngGoodsNm, this._rateMngCustCd, this._rateMngCustNm, this._unitPrcCalcDiv, this._priceDiv, this._stdUnitPrice, this._rateVal, this._unPrcFracProcUnit, this._unPrcFracProcDiv, this._unitPriceTaxExcFl, this._unitPriceTaxIncFl, this._openPriceDiv, this._sectionCode, this._ratePriorityOrder, this._priceStartDate, this._supplierCd);
        }

        /// <summary>
        /// 単価計算結果比較処理
        /// </summary>
        /// <param name="target">比較対象のUnitPriceCalcRetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnitPriceCalcRetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(UnitPriceCalcRetWork target)
        {
            return ( ( this.UnitPriceKind == target.UnitPriceKind )
                 && ( this.GoodsMakerCd == target.GoodsMakerCd )
                 && ( this.GoodsNo == target.GoodsNo )
                 && ( this.RateSettingDivide == target.RateSettingDivide )
                 && ( this.RateMngGoodsCd == target.RateMngGoodsCd )
                 && ( this.RateMngGoodsNm == target.RateMngGoodsNm )
                 && ( this.RateMngCustCd == target.RateMngCustCd )
                 && ( this.RateMngCustNm == target.RateMngCustNm )
                 && ( this.UnitPrcCalcDiv == target.UnitPrcCalcDiv )
                 && ( this.PriceDiv == target.PriceDiv )
                 && ( this.StdUnitPrice == target.StdUnitPrice )
                 && ( this.RateVal == target.RateVal )
                 && ( this.UnPrcFracProcUnit == target.UnPrcFracProcUnit )
                 && ( this.UnPrcFracProcDiv == target.UnPrcFracProcDiv )
                 && ( this.UnitPriceTaxExcFl == target.UnitPriceTaxExcFl )
                 && ( this.UnitPriceTaxIncFl == target.UnitPriceTaxIncFl )
                 && ( this.OpenPriceDiv == target.OpenPriceDiv )
                 && ( this.SectionCode == target.SectionCode )
                 && ( this.RatePriorityOrder == target.RatePriorityOrder )
                 && ( this.PriceStartDate == target.PriceStartDate )
                 && ( this.SupplierCd == target.SupplierCd ) );
        }

        /// <summary>
        /// 単価計算結果比較処理
        /// </summary>
        /// <param name="unitPriceCalcRet1">
        ///                    比較するUnitPriceCalcRetクラスのインスタンス
        /// </param>
        /// <param name="unitPriceCalcRet2">比較するUnitPriceCalcRetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnitPriceCalcRetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(UnitPriceCalcRetWork unitPriceCalcRet1, UnitPriceCalcRetWork unitPriceCalcRet2)
        {
            return ( ( unitPriceCalcRet1.UnitPriceKind == unitPriceCalcRet2.UnitPriceKind )
                 && ( unitPriceCalcRet1.GoodsMakerCd == unitPriceCalcRet2.GoodsMakerCd )
                 && ( unitPriceCalcRet1.GoodsNo == unitPriceCalcRet2.GoodsNo )
                 && ( unitPriceCalcRet1.RateSettingDivide == unitPriceCalcRet2.RateSettingDivide )
                 && ( unitPriceCalcRet1.RateMngGoodsCd == unitPriceCalcRet2.RateMngGoodsCd )
                 && ( unitPriceCalcRet1.RateMngGoodsNm == unitPriceCalcRet2.RateMngGoodsNm )
                 && ( unitPriceCalcRet1.RateMngCustCd == unitPriceCalcRet2.RateMngCustCd )
                 && ( unitPriceCalcRet1.RateMngCustNm == unitPriceCalcRet2.RateMngCustNm )
                 && ( unitPriceCalcRet1.UnitPrcCalcDiv == unitPriceCalcRet2.UnitPrcCalcDiv )
                 && ( unitPriceCalcRet1.PriceDiv == unitPriceCalcRet2.PriceDiv )
                 && ( unitPriceCalcRet1.StdUnitPrice == unitPriceCalcRet2.StdUnitPrice )
                 && ( unitPriceCalcRet1.RateVal == unitPriceCalcRet2.RateVal )
                 && ( unitPriceCalcRet1.UnPrcFracProcUnit == unitPriceCalcRet2.UnPrcFracProcUnit )
                 && ( unitPriceCalcRet1.UnPrcFracProcDiv == unitPriceCalcRet2.UnPrcFracProcDiv )
                 && ( unitPriceCalcRet1.UnitPriceTaxExcFl == unitPriceCalcRet2.UnitPriceTaxExcFl )
                 && ( unitPriceCalcRet1.UnitPriceTaxIncFl == unitPriceCalcRet2.UnitPriceTaxIncFl )
                 && ( unitPriceCalcRet1.OpenPriceDiv == unitPriceCalcRet2.OpenPriceDiv )
                 && ( unitPriceCalcRet1.SectionCode == unitPriceCalcRet2.SectionCode )
                 && ( unitPriceCalcRet1.RatePriorityOrder == unitPriceCalcRet2.RatePriorityOrder )
                 && ( unitPriceCalcRet1.PriceStartDate == unitPriceCalcRet2.PriceStartDate )
                 && ( unitPriceCalcRet1.SupplierCd == unitPriceCalcRet2.SupplierCd ) );
        }
        /// <summary>
        /// 単価計算結果比較処理
        /// </summary>
        /// <param name="target">比較対象のUnitPriceCalcRetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnitPriceCalcRetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(UnitPriceCalcRetWork target)
        {
            ArrayList resList = new ArrayList();
            if (this.UnitPriceKind != target.UnitPriceKind) resList.Add("UnitPriceKind");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.RateSettingDivide != target.RateSettingDivide) resList.Add("RateSettingDivide");
            if (this.RateMngGoodsCd != target.RateMngGoodsCd) resList.Add("RateMngGoodsCd");
            if (this.RateMngGoodsNm != target.RateMngGoodsNm) resList.Add("RateMngGoodsNm");
            if (this.RateMngCustCd != target.RateMngCustCd) resList.Add("RateMngCustCd");
            if (this.RateMngCustNm != target.RateMngCustNm) resList.Add("RateMngCustNm");
            if (this.UnitPrcCalcDiv != target.UnitPrcCalcDiv) resList.Add("UnitPrcCalcDiv");
            if (this.PriceDiv != target.PriceDiv) resList.Add("PriceDiv");
            if (this.StdUnitPrice != target.StdUnitPrice) resList.Add("StdUnitPrice");
            if (this.RateVal != target.RateVal) resList.Add("RateVal");
            if (this.UnPrcFracProcUnit != target.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
            if (this.UnPrcFracProcDiv != target.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
            if (this.UnitPriceTaxExcFl != target.UnitPriceTaxExcFl) resList.Add("UnitPriceTaxExcFl");
            if (this.UnitPriceTaxIncFl != target.UnitPriceTaxIncFl) resList.Add("UnitPriceTaxIncFl");
            if (this.OpenPriceDiv != target.OpenPriceDiv) resList.Add("OpenPriceDiv");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.RatePriorityOrder != target.RatePriorityOrder) resList.Add("RatePriorityOrder");
            if (this.PriceStartDate != target.PriceStartDate) resList.Add("PriceStartDate");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");

            return resList;
        }

        /// <summary>
        /// 単価計算結果比較処理
        /// </summary>
        /// <param name="unitPriceCalcRet1">比較するUnitPriceCalcRetクラスのインスタンス</param>
        /// <param name="unitPriceCalcRet2">比較するUnitPriceCalcRetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnitPriceCalcRetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(UnitPriceCalcRetWork unitPriceCalcRet1, UnitPriceCalcRetWork unitPriceCalcRet2)
        {
            ArrayList resList = new ArrayList();
            if (unitPriceCalcRet1.UnitPriceKind != unitPriceCalcRet2.UnitPriceKind) resList.Add("UnitPriceKind");
            if (unitPriceCalcRet1.GoodsMakerCd != unitPriceCalcRet2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (unitPriceCalcRet1.GoodsNo != unitPriceCalcRet2.GoodsNo) resList.Add("GoodsNo");
            if (unitPriceCalcRet1.RateSettingDivide != unitPriceCalcRet2.RateSettingDivide) resList.Add("RateSettingDivide");
            if (unitPriceCalcRet1.RateMngGoodsCd != unitPriceCalcRet2.RateMngGoodsCd) resList.Add("RateMngGoodsCd");
            if (unitPriceCalcRet1.RateMngGoodsNm != unitPriceCalcRet2.RateMngGoodsNm) resList.Add("RateMngGoodsNm");
            if (unitPriceCalcRet1.RateMngCustCd != unitPriceCalcRet2.RateMngCustCd) resList.Add("RateMngCustCd");
            if (unitPriceCalcRet1.RateMngCustNm != unitPriceCalcRet2.RateMngCustNm) resList.Add("RateMngCustNm");
            if (unitPriceCalcRet1.UnitPrcCalcDiv != unitPriceCalcRet2.UnitPrcCalcDiv) resList.Add("UnitPrcCalcDiv");
            if (unitPriceCalcRet1.PriceDiv != unitPriceCalcRet2.PriceDiv) resList.Add("PriceDiv");
            if (unitPriceCalcRet1.StdUnitPrice != unitPriceCalcRet2.StdUnitPrice) resList.Add("StdUnitPrice");
            if (unitPriceCalcRet1.RateVal != unitPriceCalcRet2.RateVal) resList.Add("RateVal");
            if (unitPriceCalcRet1.UnPrcFracProcUnit != unitPriceCalcRet2.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
            if (unitPriceCalcRet1.UnPrcFracProcDiv != unitPriceCalcRet2.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
            if (unitPriceCalcRet1.UnitPriceTaxExcFl != unitPriceCalcRet2.UnitPriceTaxExcFl) resList.Add("UnitPriceTaxExcFl");
            if (unitPriceCalcRet1.UnitPriceTaxIncFl != unitPriceCalcRet2.UnitPriceTaxIncFl) resList.Add("UnitPriceTaxIncFl");
            if (unitPriceCalcRet1.OpenPriceDiv != unitPriceCalcRet2.OpenPriceDiv) resList.Add("OpenPriceDiv");
            if (unitPriceCalcRet1.SectionCode != unitPriceCalcRet2.SectionCode) resList.Add("SectionCode");
            if (unitPriceCalcRet1.RatePriorityOrder != unitPriceCalcRet2.RatePriorityOrder) resList.Add("RatePriorityOrder");
            if (unitPriceCalcRet1.PriceStartDate != unitPriceCalcRet2.PriceStartDate) resList.Add("PriceStartDate");
            if (unitPriceCalcRet1.SupplierCd != unitPriceCalcRet2.SupplierCd) resList.Add("SupplierCd");

            return resList;
        }
    }
    #endregion
}
