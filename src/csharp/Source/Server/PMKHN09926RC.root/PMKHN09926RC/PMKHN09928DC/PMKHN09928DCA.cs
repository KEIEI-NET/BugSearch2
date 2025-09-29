//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品テキスト変換データパラメータクラス
// プログラム概要   : 商品テキスト変換抽出結果ワーク
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10802197-00  作成担当 : FSI菅原 庸平
// 作 成 日  K2012/05/28  修正内容 : 新規作成 山形部品個別対応
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   GoodsUWork
	/// <summary>
	///                      商品テキスト変換抽出結果ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   商品テキスト変換抽出結果ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   K2012/05/28  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class GoodsUWork
	{
        /// <summary>企業コード</summary>
        /// <remarks>仕入データ</remarks>
        private string _enterpriseCode = "";

        /// <summary>ログイン従業員の拠点コード</summary>
        /// <remarks>ログイン従業員の拠点コード</remarks>
        private string _loginsectionCode = "";

        /// <summary>現在処理年月度</summary>
        /// <remarks>現在処理年月度</remarks>
        private Int32 _addupyearmonthCd;

		/// <summary>商品番号</summary>
		/// <remarks>商品マスタ(ユーザ登録分)</remarks>
		private string _goodsNo = "";

		/// <summary>商品名称</summary>
		/// <remarks>商品マスタ(ユーザ登録分)</remarks>
		private string _goodsName = "";

		/// <summary>商品メーカーコード</summary>
		/// <remarks>商品マスタ(ユーザ登録分)</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>BL商品コード</summary>
		/// <remarks>商品マスタ(ユーザ登録分)</remarks>
		private Int32 _bLGoodsCode;

		/// <summary>仕入先コード</summary>
		/// <remarks>商品管理情報マスタ</remarks>
		private Int32 _supplierCd;

		/// <summary>定価(浮動)[現在価格]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Double _listPriceNow;

		/// <summary>定価(浮動)[新価格]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Double _listPriceNew;

		/// <summary>価格開始日[新価格]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Int32 _priceStartDateNew;

		/// <summary>仕入率[現在価格]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Double _stockRateNow;

		/// <summary>原価単価[現在価格]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Double _salesUnitCostNow;

        /// <summary>商品掛率ランク(層別)</summary>
        /// <remarks>商品マスタ(ユーザ登録分)</remarks>
        private string _goodsRaterank;

		/// <summary>発注ロット</summary>
		/// <remarks>商品管理情報マスタ</remarks>
		private Int32 _supplierLot;

		/// <summary>商品規格・特記事項</summary>
		/// <remarks>商品マスタ(ユーザ登録分)</remarks>
		private string _goodsSpecialNote = "";

		/// <summary>商品属性</summary>
		/// <remarks>商品マスタ(ユーザ登録分)</remarks>
		private Int32 _goodsKindCode;

		/// <summary>自社分類コード</summary>
		/// <remarks>商品マスタ(ユーザ登録分)</remarks>
		private Int32 _enterpriseGanreCode;

		/// <summary>課税区分</summary>
		/// <remarks>商品マスタ(ユーザ登録分)</remarks>
		private Int32 _taxationDivCd;

		/// <summary>商品備考１</summary>
		/// <remarks>商品マスタ(ユーザ登録分)</remarks>
		private string _goodsNote1 = "";

		/// <summary>商品備考２</summary>
		/// <remarks>商品マスタ(ユーザ登録分)</remarks>
		private string _goodsNote2 = "";

		/// <summary>提供データ区分</summary>
		/// <remarks>商品マスタ(ユーザ登録分)</remarks>
		private Int32 _offerDataDiv;

		/// <summary>価格開始日[No.1]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Int32 _priceStartDate1;

		/// <summary>定価(浮動)[No.1]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Double _listPrice1;

		/// <summary>原価単価[No.1]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Double _salesUnitCost1;

		/// <summary>仕入率[No.1]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Double _stockRate1;

		/// <summary>オープン価格区分[No.1]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Int32 _openPriceDiv1;

		/// <summary>提供日付[No.1]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Int32 _offerDate1;

		/// <summary>価格開始日[No.2]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Int32 _priceStartDate2;

		/// <summary>定価(浮動)[No.2]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Double _listPrice2;

		/// <summary>原価単価[No.2]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Double _salesUnitCost2;

		/// <summary>仕入率[No.2]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Double _stockRate2;

		/// <summary>オープン価格区分[No.2]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Int32 _openPriceDiv2;

		/// <summary>提供日付[No.2]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Int32 _offerDate2;

		/// <summary>価格開始日[No.3]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Int32 _priceStartDate3;

		/// <summary>定価(浮動)[No.3]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Double _listPrice3;

		/// <summary>原価単価[No.3]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Double _salesUnitCost3;

		/// <summary>仕入率[No.3]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Double _stockRate3;

		/// <summary>オープン価格区分[No.3]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Int32 _openPriceDiv3;

		/// <summary>提供日付[No.3]</summary>
		/// <remarks>価格マスタ(ユーザ登録分)</remarks>
		private Int32 _offerDate3;

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>仕入データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  LoginSectionCode
        /// <summary>ログイン従業員の拠点コードプロパティ</summary>
        /// <value>ログイン従業員の拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログイン従業員の拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LoginSectionCode
        {
            get { return _loginsectionCode; }
            set { _loginsectionCode = value; }
        }

        /// public propaty name  :  AddUpYearMonthRFCd
        /// <summary>現在処理年月度</summary>
        /// <value>現在処理年月度</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在処理年月度</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddUpYearMonthCd
        {
            get { return _addupyearmonthCd; }
            set { _addupyearmonthCd = value; }
        }

		/// public propaty name  :  GoodsNo
		/// <summary>商品番号プロパティ</summary>
		/// <value>商品マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>商品名称プロパティ</summary>
		/// <value>商品マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsName
		{
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>商品メーカーコードプロパティ</summary>
		/// <value>商品マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL商品コードプロパティ</summary>
		/// <value>商品マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>仕入先コードプロパティ</summary>
		/// <value>商品管理情報マスタ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCd
		{
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}

		/// public propaty name  :  ListPriceNow
		/// <summary>定価(浮動)[現在価格]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価(浮動)[現在価格]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ListPriceNow
		{
			get{return _listPriceNow;}
			set{_listPriceNow = value;}
		}

		/// public propaty name  :  ListPriceNew
		/// <summary>定価(浮動)[新価格]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価(浮動)[新価格]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ListPriceNew
		{
			get{return _listPriceNew;}
			set{_listPriceNew = value;}
		}

		/// public propaty name  :  PriceStartDateNew
		/// <summary>価格開始日[新価格]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格開始日[新価格]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PriceStartDateNew
		{
			get{return _priceStartDateNew;}
			set{_priceStartDateNew = value;}
		}

		/// public propaty name  :  StockRateNow
		/// <summary>仕入率[現在価格]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入率[現在価格]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockRateNow
		{
			get{return _stockRateNow;}
			set{_stockRateNow = value;}
		}

		/// public propaty name  :  SalesUnitCostNow
		/// <summary>原価単価[現在価格]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原価単価[現在価格]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesUnitCostNow
		{
			get{return _salesUnitCostNow;}
			set{_salesUnitCostNow = value;}
		}

        /// public propaty name  :  GoodsRaterank
        /// <summary>商品掛率ランク(層別)プロパティ</summary>
        /// <value>商品掛率ランク(層別)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
        /// <br>note             :   商品掛率ランク(層別)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public string GoodsRaterank
		{
            get { return _goodsRaterank; }
            set { _goodsRaterank = value; }
		}

		/// public propaty name  :  SupplierLot
		/// <summary>発注ロットプロパティ</summary>
		/// <value>商品管理情報マスタ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注ロットプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierLot
		{
			get{return _supplierLot;}
			set{_supplierLot = value;}
		}

		/// public propaty name  :  GoodsSpecialNote
		/// <summary>商品規格・特記事項プロパティ</summary>
		/// <value>商品マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品規格・特記事項プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsSpecialNote
		{
			get{return _goodsSpecialNote;}
			set{_goodsSpecialNote = value;}
		}

		/// public propaty name  :  GoodsKindCode
		/// <summary>商品属性プロパティ</summary>
		/// <value>商品マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品属性プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsKindCode
		{
			get{return _goodsKindCode;}
			set{_goodsKindCode = value;}
		}

		/// public propaty name  :  EnterpriseGanreCode
		/// <summary>自社分類コードプロパティ</summary>
		/// <value>商品マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EnterpriseGanreCode
		{
			get{return _enterpriseGanreCode;}
			set{_enterpriseGanreCode = value;}
		}

		/// public propaty name  :  TaxationDivCd
		/// <summary>課税区分プロパティ</summary>
		/// <value>商品マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   課税区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TaxationDivCd
		{
			get{return _taxationDivCd;}
			set{_taxationDivCd = value;}
		}

		/// public propaty name  :  GoodsNote1
		/// <summary>商品備考１プロパティ</summary>
		/// <value>商品マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品備考１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNote1
		{
			get{return _goodsNote1;}
			set{_goodsNote1 = value;}
		}

		/// public propaty name  :  GoodsNote2
		/// <summary>商品備考２プロパティ</summary>
		/// <value>商品マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品備考２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNote2
		{
			get{return _goodsNote2;}
			set{_goodsNote2 = value;}
		}

		/// public propaty name  :  OfferDataDiv
		/// <summary>提供データ区分プロパティ</summary>
		/// <value>商品マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   提供データ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OfferDataDiv
		{
			get{return _offerDataDiv;}
			set{_offerDataDiv = value;}
		}

		/// public propaty name  :  PriceStartDate1
		/// <summary>価格開始日[No.1]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格開始日[No.1]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PriceStartDate1
		{
			get{return _priceStartDate1;}
			set{_priceStartDate1 = value;}
		}

		/// public propaty name  :  ListPrice1
		/// <summary>定価(浮動)[No.1]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価(浮動)[No.1]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ListPrice1
		{
			get{return _listPrice1;}
			set{_listPrice1 = value;}
		}

		/// public propaty name  :  SalesUnitCost1
		/// <summary>原価単価[No.1]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原価単価[No.1]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesUnitCost1
		{
			get{return _salesUnitCost1;}
			set{_salesUnitCost1 = value;}
		}

		/// public propaty name  :  StockRate1
		/// <summary>仕入率[No.1]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入率[No.1]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockRate1
		{
			get{return _stockRate1;}
			set{_stockRate1 = value;}
		}

		/// public propaty name  :  OpenPriceDiv1
		/// <summary>オープン価格区分[No.1]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   オープン価格区分[No.1]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OpenPriceDiv1
		{
			get{return _openPriceDiv1;}
			set{_openPriceDiv1 = value;}
		}

		/// public propaty name  :  OfferDate1
		/// <summary>提供日付[No.1]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   提供日付[No.1]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OfferDate1
		{
			get{return _offerDate1;}
			set{_offerDate1 = value;}
		}

		/// public propaty name  :  PriceStartDate2
		/// <summary>価格開始日[No.2]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格開始日[No.2]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PriceStartDate2
		{
			get{return _priceStartDate2;}
			set{_priceStartDate2 = value;}
		}

		/// public propaty name  :  ListPrice2
		/// <summary>定価(浮動)[No.2]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価(浮動)[No.2]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ListPrice2
		{
			get{return _listPrice2;}
			set{_listPrice2 = value;}
		}

		/// public propaty name  :  SalesUnitCost2
		/// <summary>原価単価[No.2]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原価単価[No.2]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesUnitCost2
		{
			get{return _salesUnitCost2;}
			set{_salesUnitCost2 = value;}
		}

		/// public propaty name  :  StockRate2
		/// <summary>仕入率[No.2]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入率[No.2]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockRate2
		{
			get{return _stockRate2;}
			set{_stockRate2 = value;}
		}

		/// public propaty name  :  OpenPriceDiv2
		/// <summary>オープン価格区分[No.2]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   オープン価格区分[No.2]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OpenPriceDiv2
		{
			get{return _openPriceDiv2;}
			set{_openPriceDiv2 = value;}
		}

		/// public propaty name  :  OfferDate2
		/// <summary>提供日付[No.2]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   提供日付[No.2]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OfferDate2
		{
			get{return _offerDate2;}
			set{_offerDate2 = value;}
		}

		/// public propaty name  :  PriceStartDate3
		/// <summary>価格開始日[No.3]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格開始日[No.3]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PriceStartDate3
		{
			get{return _priceStartDate3;}
			set{_priceStartDate3 = value;}
		}

		/// public propaty name  :  ListPrice3
		/// <summary>定価(浮動)[No.3]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価(浮動)[No.3]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ListPrice3
		{
			get{return _listPrice3;}
			set{_listPrice3 = value;}
		}

		/// public propaty name  :  SalesUnitCost3
		/// <summary>原価単価[No.3]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原価単価[No.3]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesUnitCost3
		{
			get{return _salesUnitCost3;}
			set{_salesUnitCost3 = value;}
		}

		/// public propaty name  :  StockRate3
		/// <summary>仕入率[No.3]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入率[No.3]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockRate3
		{
			get{return _stockRate3;}
			set{_stockRate3 = value;}
		}

		/// public propaty name  :  OpenPriceDiv3
		/// <summary>オープン価格区分[No.3]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   オープン価格区分[No.3]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OpenPriceDiv3
		{
			get{return _openPriceDiv3;}
			set{_openPriceDiv3 = value;}
		}

		/// public propaty name  :  OfferDate3
		/// <summary>提供日付[No.3]プロパティ</summary>
		/// <value>価格マスタ(ユーザ登録分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   提供日付[No.3]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OfferDate3
		{
			get{return _offerDate3;}
			set{_offerDate3 = value;}
		}


		/// <summary>
		/// 商品テキスト変換抽出結果ワークコンストラクタ
		/// </summary>
		/// <returns>GoodsUWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsUWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public GoodsUWork()
		{
		}

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>GoodsUWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   GoodsUWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class GoodsUWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GoodsUWork || graph is ArrayList || graph is GoodsUWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(GoodsUWork).FullName));

            if (graph != null && graph is GoodsUWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsUWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }else if (graph is GoodsUWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GoodsUWork[])graph).Length;
            }
            else if (graph is GoodsUWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //定価(浮動)[現在価格]
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceNow
            //定価(浮動)[新価格]
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceNew
            //価格開始日[新価格]
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDateNew
            //仕入率[現在価格]
            serInfo.MemberInfo.Add(typeof(Double)); //StockRateNow
            //原価単価[現在価格]
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCostNow
            //商品掛率ランク(層別)
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRaterank
            //発注ロット
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierLot
            //商品規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //GoodsSpecialNote
            //商品属性
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //自社分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //商品備考１
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote1
            //商品備考２
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote2
            //提供データ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDataDiv
            //価格開始日[No.1]
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate1
            //定価(浮動)[No.1]
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice1
            //原価単価[No.1]
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost1
            //仕入率[No.1]
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate1
            //オープン価格区分[No.1]
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv1
            //提供日付[No.1]
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate1
            //価格開始日[No.2]
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate2
            //定価(浮動)[No.2]
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice2
            //原価単価[No.2]
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost2
            //仕入率[No.2]
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate2
            //オープン価格区分[No.2]
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv2
            //提供日付[No.2]
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate2
            //価格開始日[No.3]
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate3
            //定価(浮動)[No.3]
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice3
            //原価単価[No.3]
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost3
            //仕入率[No.3]
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate3
            //オープン価格区分[No.3]
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv3
            //提供日付[No.3]
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate3


            serInfo.Serialize(writer, serInfo);
            if (graph is GoodsUWork)
            {
                GoodsUWork temp = (GoodsUWork)graph;

                SetGoodsUWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GoodsUWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GoodsUWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GoodsUWork temp in lst)
                {
                    SetGoodsUWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GoodsUWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 38;

        /// <summary>
        ///  GoodsUWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetGoodsUWork(System.IO.BinaryWriter writer, GoodsUWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //定価(浮動)[現在価格]
            writer.Write(temp.ListPriceNow);
            //定価(浮動)[新価格]
            writer.Write(temp.ListPriceNew);
            //価格開始日[新価格]
            writer.Write(temp.PriceStartDateNew);
            //仕入率[現在価格]
            writer.Write(temp.StockRateNow);
            //原価単価[現在価格]
            writer.Write(temp.SalesUnitCostNow);
            //商品掛率ランク(層別)
            writer.Write(temp.GoodsRaterank);
            //発注ロット
            writer.Write(temp.SupplierLot);
            //商品規格・特記事項
            writer.Write(temp.GoodsSpecialNote);
            //商品属性
            writer.Write(temp.GoodsKindCode);
            //自社分類コード
            writer.Write(temp.EnterpriseGanreCode);
            //課税区分
            writer.Write(temp.TaxationDivCd);
            //商品備考１
            writer.Write(temp.GoodsNote1);
            //商品備考２
            writer.Write(temp.GoodsNote2);
            //提供データ区分
            writer.Write(temp.OfferDataDiv);
            //価格開始日[No.1]
            writer.Write(temp.PriceStartDate1);
            //定価(浮動)[No.1]
            writer.Write(temp.ListPrice1);
            //原価単価[No.1]
            writer.Write(temp.SalesUnitCost1);
            //仕入率[No.1]
            writer.Write(temp.StockRate1);
            //オープン価格区分[No.1]
            writer.Write(temp.OpenPriceDiv1);
            //提供日付[No.1]
            writer.Write(temp.OfferDate1);
            //価格開始日[No.2]
            writer.Write(temp.PriceStartDate2);
            //定価(浮動)[No.2]
            writer.Write(temp.ListPrice2);
            //原価単価[No.2]
            writer.Write(temp.SalesUnitCost2);
            //仕入率[No.2]
            writer.Write(temp.StockRate2);
            //オープン価格区分[No.2]
            writer.Write(temp.OpenPriceDiv2);
            //提供日付[No.2]
            writer.Write(temp.OfferDate2);
            //価格開始日[No.3]
            writer.Write(temp.PriceStartDate3);
            //定価(浮動)[No.3]
            writer.Write(temp.ListPrice3);
            //原価単価[No.3]
            writer.Write(temp.SalesUnitCost3);
            //仕入率[No.3]
            writer.Write(temp.StockRate3);
            //オープン価格区分[No.3]
            writer.Write(temp.OpenPriceDiv3);
            //提供日付[No.3]
            writer.Write(temp.OfferDate3);

        }

        /// <summary>
        ///  GoodsUWorkインスタンス取得
        /// </summary>
        /// <returns>GoodsUWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private GoodsUWork GetGoodsUWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            GoodsUWork temp = new GoodsUWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //定価(浮動)[現在価格]
            temp.ListPriceNow = reader.ReadDouble();
            //定価(浮動)[新価格]
            temp.ListPriceNew = reader.ReadDouble();
            //価格開始日[新価格]
            temp.PriceStartDateNew = reader.ReadInt32();
            //仕入率[現在価格]
            temp.StockRateNow = reader.ReadDouble();
            //原価単価[現在価格]
            temp.SalesUnitCostNow = reader.ReadDouble();
            //層別更新区分
            temp.GoodsRaterank = reader.ReadString();
            //発注ロット
            temp.SupplierLot = reader.ReadInt32();
            //商品規格・特記事項
            temp.GoodsSpecialNote = reader.ReadString();
            //商品属性
            temp.GoodsKindCode = reader.ReadInt32();
            //自社分類コード
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //課税区分
            temp.TaxationDivCd = reader.ReadInt32();
            //商品備考１
            temp.GoodsNote1 = reader.ReadString();
            //商品備考２
            temp.GoodsNote2 = reader.ReadString();
            //提供データ区分
            temp.OfferDataDiv = reader.ReadInt32();
            //価格開始日[No.1]
            temp.PriceStartDate1 = reader.ReadInt32();
            //定価(浮動)[No.1]
            temp.ListPrice1 = reader.ReadDouble();
            //原価単価[No.1]
            temp.SalesUnitCost1 = reader.ReadDouble();
            //仕入率[No.1]
            temp.StockRate1 = reader.ReadDouble();
            //オープン価格区分[No.1]
            temp.OpenPriceDiv1 = reader.ReadInt32();
            //提供日付[No.1]
            temp.OfferDate1 = reader.ReadInt32();
            //価格開始日[No.2]
            temp.PriceStartDate2 = reader.ReadInt32();
            //定価(浮動)[No.2]
            temp.ListPrice2 = reader.ReadDouble();
            //原価単価[No.2]
            temp.SalesUnitCost2 = reader.ReadDouble();
            //仕入率[No.2]
            temp.StockRate2 = reader.ReadDouble();
            //オープン価格区分[No.2]
            temp.OpenPriceDiv2 = reader.ReadInt32();
            //提供日付[No.2]
            temp.OfferDate2 = reader.ReadInt32();
            //価格開始日[No.3]
            temp.PriceStartDate3 = reader.ReadInt32();
            //定価(浮動)[No.3]
            temp.ListPrice3 = reader.ReadDouble();
            //原価単価[No.3]
            temp.SalesUnitCost3 = reader.ReadDouble();
            //仕入率[No.3]
            temp.StockRate3 = reader.ReadDouble();
            //オープン価格区分[No.3]
            temp.OpenPriceDiv3 = reader.ReadInt32();
            //提供日付[No.3]
            temp.OfferDate3 = reader.ReadInt32();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>GoodsUWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GoodsUWork temp = GetGoodsUWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (GoodsUWork[])lst.ToArray(typeof(GoodsUWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
