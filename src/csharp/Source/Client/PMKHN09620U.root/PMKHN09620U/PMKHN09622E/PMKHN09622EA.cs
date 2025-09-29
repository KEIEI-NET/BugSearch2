using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SearchCondition
    /// <summary>
    ///                      キャンペーン対象商品設定マスタ抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   キャンペーン対象商品設定マスタ抽出条件クラス</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/04/26</br>
    /// <br>Genarated Date   :   2011/04/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SearchCondition
    {
        /// <summary>企業コード</summary>
        private string _enterpriseCode = "";

        /// <summary>キャンペーンコード</summary>
        private Int32 _campaignCode;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>メーカー（開始）</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>メーカー（終了）</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>ＢＬコード（開始）</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>ＢＬコード（終了）</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>グループコード（開始）</summary>
        private Int32 _bLGroupCodeSt;

        /// <summary>グループコード（終了）</summary>
        private Int32 _bLGroupCodeEd;

        /// <summary>販売区分（開始）</summary>
        private Int32 _salesCodeSt;

        /// <summary>販売区分（終了）</summary>
        private Int32 _salesCodeEd;

        /// <summary>品番*</summary>
        private string _goodsNo = "";

        /// <summary>削除指定区分</summary>
        private Int32 _deleteFlag;

        /// <summary>売価率</summary>
        private Double _rateVal;

        /// <summary>売価率区分</summary>
        private Int32 _rateValDiv;

        /// <summary>売価額</summary>
        private Double _priceFl;

        /// <summary>売価額区分</summary>
        private Int32 _priceFlDiv;

        /// <summary>値引率</summary>
        private Double _discountRate;

        /// <summary>値引率区分</summary>
        private Int32 _discountRateDiv;


        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
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

        /// public propaty name  :  CampaignCode
        /// <summary>キャンペーンコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーンコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
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

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>メーカー（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>メーカー（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>ＢＬコード（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬコード（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>ＢＬコード（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬコード（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  BLGroupCodeSt
        /// <summary>グループコード（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   グループコード（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeSt
        {
            get { return _bLGroupCodeSt; }
            set { _bLGroupCodeSt = value; }
        }

        /// public propaty name  :  BLGroupCodeEd
        /// <summary>グループコード（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   グループコード（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
        }

        /// public propaty name  :  SalesCodeSt
        /// <summary>販売区分（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCodeSt
        {
            get { return _salesCodeSt; }
            set { _salesCodeSt = value; }
        }

        /// public propaty name  :  SalesCodeEd
        /// <summary>販売区分（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCodeEd
        {
            get { return _salesCodeEd; }
            set { _salesCodeEd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>品番*プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番*プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  DeleteFlag
        /// <summary>削除指定区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   削除指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteFlag
        {
            get { return _deleteFlag; }
            set { _deleteFlag = value; }
        }

        /// public propaty name  :  RateVal
        /// <summary>売価率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double RateVal
        {
            get { return _rateVal; }
            set { _rateVal = value; }
        }

        /// public propaty name  :  RateValDiv
        /// <summary>売価率区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価率区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateValDiv
        {
            get { return _rateValDiv; }
            set { _rateValDiv = value; }
        }

        /// public propaty name  :  PriceFl
        /// <summary>売価額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PriceFl
        {
            get { return _priceFl; }
            set { _priceFl = value; }
        }

        /// public propaty name  :  PriceFlDiv
        /// <summary>売価額区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価額区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceFlDiv
        {
            get { return _priceFlDiv; }
            set { _priceFlDiv = value; }
        }

        /// public propaty name  :  PriceFl
        /// <summary>値引率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DiscountRate
        {
            get { return _discountRate; }
            set { _discountRate = value; }
        }

        /// public propaty name  :  PriceFlDiv
        /// <summary>値引率区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引率区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DiscountRateDiv
        {
            get { return _discountRateDiv; }
            set { _discountRateDiv = value; }
        }


        /// <summary>
        /// 仕入データコンストラクタ
        /// </summary>
        /// <returns>SearchConditionクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchConditionクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchCondition()
        {
        }
    }
}
