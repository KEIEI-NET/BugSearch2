//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーンマスタ印刷
// プログラム概要   : 抽出結果より出力結果イメージ表示・ＰＤＦ出力・印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignMasterPrintWork
    /// <summary>
    ///                      キャンペーンマスタ（印刷）条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   キャンペーンマスタ（印刷）条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/04/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CampaignMasterPrintWork
    {
        # region ■ private field ■
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>発行タイプ</summary>
        /// <remarks>1:メーカー＋品番 2:メーカー＋ＢＬコード 3:メーカー＋グループコード 4:メーカー 5:ＢＬコード 6:販売区分 7:マスタリスト</remarks>
        private Int32 _printType;

        /// <summary>改頁</summary>
        private Int32 _changePage;

        /// <summary>開始キャンペーンコード</summary>
        private Int32 _campaignCodeSt;

        /// <summary>終了キャンペーンコード</summary>
        private Int32 _campaignCodeEd;

        /// <summary>開始拠点コード</summary>
        private string _sectionCodeSt = "";

        /// <summary>終了拠点コード</summary>
        private string _sectionCodeEd = "";

        /// <summary>開始商品メーカーコード</summary>
        private Int32 _goodsMakerCodeSt;

        /// <summary>終了商品メーカーコード</summary>
        private Int32 _goodsMakerCodeEd;

        /// <summary>開始グループコード</summary>
        private Int32 _bLGroupCodeSt;

        /// <summary>終了グループコード</summary>
        private Int32 _bLGroupCodeEd;

        /// <summary>開始ＢＬコードコード</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>終了ＢＬコードコード</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>開始品番</summary>
        private string _goodsNoSt = "";

        /// <summary>終了品番</summary>
        private string _goodsNoEd = "";

        /// <summary>開始販売区分コード</summary>
        private Int32 _salesCodeSt;

        /// <summary>終了販売区分コード</summary>
        private Int32 _salesCodeEd;

        /// <summary>売価率</summary>
        private Double _rateVal;

        /// <summary>売価率指定区分</summary>
        /// <remarks>0:指定なし 1:同じ 2:以上 3:以下</remarks>
        private Int32 _rateValDiv;

        /// <summary>売価額</summary>
        private Double _priceFl;

        /// <summary>売価額指定区分</summary>
        /// <remarks>0:指定なし 1:同じ 2:以上 3:以下</remarks>
        private Int32 _priceFlDiv;

        /// <summary>値引率</summary>
        private Double _discountRate;

        /// <summary>値引率指定区分</summary>
        /// <remarks>0:指定なし 1:同じ 2:以上 3:以下</remarks>
        private Int32 _discountRateDiv;

        /// <summary>削除指定区分</summary>
        /// <remarks>0:有効,1:論理削除</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>開始削除日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeSt;

        /// <summary>終了削除日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeEd;

        # endregion  ■ private field ■

        # region ■ public propaty ■
        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
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

        /// public propaty name  :  PrintType
        /// <summary>印刷パターンプロパティ</summary>
        /// <value>0:拠点 1:拠点-部門 2:拠点-担当者 3:拠点-受注者 4:拠点-発行者 5:拠点-販売区分 6:拠点-商品区分 7:拠点-得意先 8:拠点-業種 9:拠点-地区</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷パターンプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  ChangePage
        /// <summary>改頁プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChangePage
        {
            get { return _changePage; }
            set { _changePage = value; }
        }

        /// public propaty name  :  CampaignCodeSt
        /// <summary>開始キャンペーンコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始キャンペーンコード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignCodeSt
        {
            get { return _campaignCodeSt; }
            set { _campaignCodeSt = value; }
        }

        /// public propaty name  :  CampaignCodeEd
        /// <summary>終了キャンペーンコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了キャンペーンコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignCodeEd
        {
            get { return _campaignCodeEd; }
            set { _campaignCodeEd = value; }
        }

        /// public propaty name  :  SectionCodeSt
        /// <summary>開始拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEd
        /// <summary>終了拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }

        /// public propaty name  :  SubSectionCodeSt
        /// <summary>開始商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCodeSt
        {
            get { return _goodsMakerCodeSt; }
            set { _goodsMakerCodeSt = value; }
        }

        /// public propaty name  :  GoodsMakerCodeEd
        /// <summary>終了商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCodeEd
        {
            get { return _goodsMakerCodeEd; }
            set { _goodsMakerCodeEd = value; }
        }

        /// public propaty name  :  SubSectionCodeSt
        /// <summary>開始グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeSt
        {
            get { return _bLGroupCodeSt; }
            set { _bLGroupCodeSt = value; }
        }

        /// public propaty name  :  GoodsMakerCodeEd
        /// <summary>終了グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>開始ＢＬコードコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始ＢＬコードコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>終了ＢＬコードコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了ＢＬコードコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  GoodsNoSt
        /// <summary>開始品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoSt
        {
            get { return _goodsNoSt; }
            set { _goodsNoSt = value; }
        }

        /// public propaty name  :  GoodsNoEd
        /// <summary>終了品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoEd
        {
            get { return _goodsNoEd; }
            set { _goodsNoEd = value; }
        }

        /// public propaty name  :  SalesCodeSt
        /// <summary>開始販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCodeSt
        {
            get { return _salesCodeSt; }
            set { _salesCodeSt = value; }
        }

        /// public propaty name  :  SalesCodeEd
        /// <summary>終了販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCodeEd
        {
            get { return _salesCodeEd; }
            set { _salesCodeEd = value; }
        }

        /// public propaty name  :  RateVal
        /// <summary>売価率プロパティ</summary>
        /// <value>0:オープン価格</value>
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
        /// <summary>売価率指定区分プロパティ</summary>
        /// <value>0:同じ 1:以上 2:以下</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価率指定区分プロパティ</br>
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
        /// <summary>売価額指定区分プロパティ</summary>
        /// <value>0:同じ 1:以上 2:以下</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価額指定区分プロパティ</br>
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
        /// <summary>値引率指定区分プロパティ</summary>
        /// <value>0:同じ 1:以上 2:以下</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引率指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DiscountRateDiv
        {
            get { return _discountRateDiv; }
            set { _discountRateDiv = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>削除指定区分プロパティ</summary>
        /// <value>0:有効,1:論理削除</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   削除指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  DeleteDateTimeSt
        /// <summary>開始削除日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始削除日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteDateTimeSt
        {
            get { return _deleteDateTimeSt; }
            set { _deleteDateTimeSt = value; }
        }

        /// public propaty name  :  DeleteDateTimeEd
        /// <summary>終了削除日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了削除日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteDateTimeEd
        {
            get { return _deleteDateTimeEd; }
            set { _deleteDateTimeEd = value; }
        }
        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// キャンペーンマスタ（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>CampaignMasterPrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMasterPrintWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignMasterPrintWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
