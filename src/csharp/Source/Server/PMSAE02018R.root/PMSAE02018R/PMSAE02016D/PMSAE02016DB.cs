//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : S&E売上データテキスト出力
// プログラム概要   : S&E売上データテキスト出力帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/08/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesHistoryJoinWork
    /// <summary>
    ///                      売上履歴データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上履歴データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2009/08/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  杉村</br>
    /// <br>                 :   ○スペルミス修正</br>
    /// <br>                 :   売上値引非課税対象額合計</br>
    /// <br>                 :   売上正価金額</br>
    /// <br>                 :   売上金額消費税額（外税）</br>
    /// <br>Update Note      :   2008/7/29  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   得意先伝票番号</br>
    /// <br>Update Note      :   2013/02/25 zhuhh</br>
    /// <br>                 :   Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesHistoryJoinWork : IFileHeader
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>受注ステータス</summary>
        /// <remarks>30:売上</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum = "";

        /// <summary>売上伝票区分</summary>
        /// <remarks>0:売上,1:返品</remarks>
        private Int32 _salesSlipCd;

        /// <summary>実績計上拠点コード</summary>
        /// <remarks>実績計上を行う企業内の拠点コード</remarks>
        private string _resultsAddUpSecCd = "";

        /// <summary>伝票検索日付</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _searchSlipDate;

        /// <summary>計上日付</summary>
        /// <remarks>請求日　(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>売上行番号</summary>
        /// <remarks>一式伝票:ゼロ、セット品の子商品:親商品と同じ行番号</remarks>
        private Int32 _salesRowNo;

        /// <summary>商品メーカーコード</summary>
        /// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称カナ</summary>
        private string _goodsNameKana = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>売上単価（税抜，浮動）</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>BL商品コード（印刷）</summary>
        private Int32 _prtBLGoodsCode;

        /// <summary>出荷数</summary>
        private Double _shipmentCnt;

        /// <summary>売上金額（税抜き）</summary>
        private Int64 _salesMoneyTaxExc;

        // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更----->>>>>
        /// <summary>定価（税抜，浮動）</summary>
        private Double _listPriceTaxExc;
        // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更-----<<<<<
        
        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>商品コード変換AB商品コード</summary>
        private string _aBGoodsCode = "";

        /// <summary>納品先店舗コード</summary>
        private string _addresseeShopCd = "";

        /// <summary>住電管理コード</summary>
        private string _sAndEMngCode = "";

        /// <summary>経費区分</summary>
        private Int32 _expenseDivCd;

        /// <summary>部品商コード（純正）</summary>
        private string _pureTradCompCd = "";

        /// <summary>部品商仕切率（純正）</summary>
        private Double _pureTradCompRate;

        /// <summary>部品商コード（優良）</summary>
        private string _priTradCompCd = "";

        /// <summary>部品商仕切率（優良）</summary>
        private Double _priTradCompRate;

        /// <summary>設定AB商品コード</summary>
        private string _setABGoodsCode = "";

        /// <summary>商品メーカーコード１</summary>
        private Int32 _goodsMakerCd1;

        /// <summary>商品メーカーコード２</summary>
        private Int32 _goodsMakerCd2;

        /// <summary>商品メーカーコード３</summary>
        private Int32 _goodsMakerCd3;

        /// <summary>商品メーカーコード４</summary>
        private Int32 _goodsMakerCd4;

        /// <summary>商品メーカーコード５</summary>
        private Int32 _goodsMakerCd5;

        /// <summary>商品メーカーコード６</summary>
        private Int32 _goodsMakerCd6;

        /// <summary>商品メーカーコード７</summary>
        private Int32 _goodsMakerCd7;

        /// <summary>商品メーカーコード８</summary>
        private Int32 _goodsMakerCd8;

        /// <summary>商品メーカーコード９</summary>
        private Int32 _goodsMakerCd9;

        /// <summary>商品メーカーコード１０</summary>
        private Int32 _goodsMakerCd10;

        /// <summary>商品メーカーコード１１</summary>
        private Int32 _goodsMakerCd11;

        /// <summary>商品メーカーコード１２</summary>
        private Int32 _goodsMakerCd12;

        /// <summary>商品メーカーコード１３</summary>
        private Int32 _goodsMakerCd13;

        /// <summary>商品メーカーコード１４</summary>
        private Int32 _goodsMakerCd14;

        /// <summary>商品メーカーコード１５</summary>
        private Int32 _goodsMakerCd15;

        /// <summary>SE企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _sEEnterpriseCode = "";

        /// <summary>SE受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _sEAcptAnOdrStatus;

        /// <summary>SE売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _sESalesSlipNum = "";

        /// <summary>SE売上データ作成日時</summary>
        /// <remarks>売上データの作成日時（DateTime:精度は100ナノ秒）</remarks>
        private Int64 _sESalesCreateDateTime;


        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>30:売上</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  SalesSlipCd
        /// <summary>売上伝票区分プロパティ</summary>
        /// <value>0:売上,1:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  ResultsAddUpSecCd
        /// <summary>実績計上拠点コードプロパティ</summary>
        /// <value>実績計上を行う企業内の拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ResultsAddUpSecCd
        {
            get { return _resultsAddUpSecCd; }
            set { _resultsAddUpSecCd = value; }
        }

        /// public propaty name  :  SearchSlipDate
        /// <summary>伝票検索日付プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SearchSlipDate
        {
            get { return _searchSlipDate; }
            set { _searchSlipDate = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>計上日付プロパティ</summary>
        /// <value>請求日　(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpADate
        {
            get { return _addUpADate; }
            set { _addUpADate = value; }
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

        /// public propaty name  :  SalesRowNo
        /// <summary>売上行番号プロパティ</summary>
        /// <value>一式伝票:ゼロ、セット品の子商品:親商品と同じ行番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
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

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>売上単価（税抜，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  PrtBLGoodsCode
        /// <summary>BL商品コード（印刷）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード（印刷）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtBLGoodsCode
        {
            get { return _prtBLGoodsCode; }
            set { _prtBLGoodsCode = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>売上金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更----->>>>>
        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>定価（税抜，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExc; }
            set { _listPriceTaxExc = value; }
        }
        // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更-----<<<<<

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

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>帳票印字用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  ABGoodsCode
        /// <summary>商品コード変換AB商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品コード変換AB商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ABGoodsCode
        {
            get { return _aBGoodsCode; }
            set { _aBGoodsCode = value; }
        }

        /// public propaty name  :  AddresseeShopCd
        /// <summary>納品先店舗コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先店舗コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeShopCd
        {
            get { return _addresseeShopCd; }
            set { _addresseeShopCd = value; }
        }

        /// public propaty name  :  SAndEMngCode
        /// <summary>住電管理コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住電管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SAndEMngCode
        {
            get { return _sAndEMngCode; }
            set { _sAndEMngCode = value; }
        }

        /// public propaty name  :  ExpenseDivCd
        /// <summary>経費区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   経費区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ExpenseDivCd
        {
            get { return _expenseDivCd; }
            set { _expenseDivCd = value; }
        }

        /// public propaty name  :  PureTradCompCd
        /// <summary>部品商コード（純正）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商コード（純正）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PureTradCompCd
        {
            get { return _pureTradCompCd; }
            set { _pureTradCompCd = value; }
        }

        /// public propaty name  :  PureTradCompRate
        /// <summary>部品商仕切率（純正）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商仕切率（純正）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PureTradCompRate
        {
            get { return _pureTradCompRate; }
            set { _pureTradCompRate = value; }
        }

        /// public propaty name  :  PriTradCompCd
        /// <summary>部品商コード（優良）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商コード（優良）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriTradCompCd
        {
            get { return _priTradCompCd; }
            set { _priTradCompCd = value; }
        }

        /// public propaty name  :  PriTradCompRate
        /// <summary>部品商仕切率（優良）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商仕切率（優良）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PriTradCompRate
        {
            get { return _priTradCompRate; }
            set { _priTradCompRate = value; }
        }

        /// public propaty name  :  SetABGoodsCode
        /// <summary>設定AB商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   設定AB商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SetABGoodsCode
        {
            get { return _setABGoodsCode; }
            set { _setABGoodsCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd1
        /// <summary>商品メーカーコード１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd1
        {
            get { return _goodsMakerCd1; }
            set { _goodsMakerCd1 = value; }
        }

        /// public propaty name  :  GoodsMakerCd2
        /// <summary>商品メーカーコード２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd2
        {
            get { return _goodsMakerCd2; }
            set { _goodsMakerCd2 = value; }
        }

        /// public propaty name  :  GoodsMakerCd3
        /// <summary>商品メーカーコード３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd3
        {
            get { return _goodsMakerCd3; }
            set { _goodsMakerCd3 = value; }
        }

        /// public propaty name  :  GoodsMakerCd4
        /// <summary>商品メーカーコード４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd4
        {
            get { return _goodsMakerCd4; }
            set { _goodsMakerCd4 = value; }
        }

        /// public propaty name  :  GoodsMakerCd5
        /// <summary>商品メーカーコード５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd5
        {
            get { return _goodsMakerCd5; }
            set { _goodsMakerCd5 = value; }
        }

        /// public propaty name  :  GoodsMakerCd6
        /// <summary>商品メーカーコード６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd6
        {
            get { return _goodsMakerCd6; }
            set { _goodsMakerCd6 = value; }
        }

        /// public propaty name  :  GoodsMakerCd7
        /// <summary>商品メーカーコード７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd7
        {
            get { return _goodsMakerCd7; }
            set { _goodsMakerCd7 = value; }
        }

        /// public propaty name  :  GoodsMakerCd8
        /// <summary>商品メーカーコード８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd8
        {
            get { return _goodsMakerCd8; }
            set { _goodsMakerCd8 = value; }
        }

        /// public propaty name  :  GoodsMakerCd9
        /// <summary>商品メーカーコード９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd9
        {
            get { return _goodsMakerCd9; }
            set { _goodsMakerCd9 = value; }
        }

        /// public propaty name  :  GoodsMakerCd10
        /// <summary>商品メーカーコード１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd10
        {
            get { return _goodsMakerCd10; }
            set { _goodsMakerCd10 = value; }
        }

        /// public propaty name  :  GoodsMakerCd11
        /// <summary>商品メーカーコード１１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード１１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd11
        {
            get { return _goodsMakerCd11; }
            set { _goodsMakerCd11 = value; }
        }

        /// public propaty name  :  GoodsMakerCd12
        /// <summary>商品メーカーコード１２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード１２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd12
        {
            get { return _goodsMakerCd12; }
            set { _goodsMakerCd12 = value; }
        }

        /// public propaty name  :  GoodsMakerCd13
        /// <summary>商品メーカーコード１３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード１３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd13
        {
            get { return _goodsMakerCd13; }
            set { _goodsMakerCd13 = value; }
        }

        /// public propaty name  :  GoodsMakerCd14
        /// <summary>商品メーカーコード１４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード１４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd14
        {
            get { return _goodsMakerCd14; }
            set { _goodsMakerCd14 = value; }
        }

        /// public propaty name  :  GoodsMakerCd15
        /// <summary>商品メーカーコード１５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード１５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd15
        {
            get { return _goodsMakerCd15; }
            set { _goodsMakerCd15 = value; }
        }

        /// public propaty name  :  SEEnterpriseCode
        /// <summary>SE企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SE企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SEEnterpriseCode
        {
            get { return _sEEnterpriseCode; }
            set { _sEEnterpriseCode = value; }
        }

        /// public propaty name  :  SEAcptAnOdrStatus
        /// <summary>SE受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SE受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SEAcptAnOdrStatus
        {
            get { return _sEAcptAnOdrStatus; }
            set { _sEAcptAnOdrStatus = value; }
        }

        /// public propaty name  :  SESalesSlipNum
        /// <summary>SE売上伝票番号プロパティ</summary>
        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SE売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SESalesSlipNum
        {
            get { return _sESalesSlipNum; }
            set { _sESalesSlipNum = value; }
        }

        /// public propaty name  :  SESalesCreateDateTime
        /// <summary>SE売上データ作成日時プロパティ</summary>
        /// <value>売上データの作成日時（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SE売上データ作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SESalesCreateDateTime
        {
            get { return _sESalesCreateDateTime; }
            set { _sESalesCreateDateTime = value; }
        }


        /// <summary>
        /// 売上履歴データワークコンストラクタ
        /// </summary>
        /// <returns>SalesHistoryJoinWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistoryJoinWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesHistoryJoinWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalesHistoryJoinWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesHistoryJoinWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SalesHistoryJoinWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistoryJoinWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2013/02/25 zhuhh</br>
        /// <br>                 :   Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesHistoryJoinWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesHistoryJoinWork || graph is ArrayList || graph is SalesHistoryJoinWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalesHistoryJoinWork).FullName));

            if (graph != null && graph is SalesHistoryJoinWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesHistoryJoinWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesHistoryJoinWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesHistoryJoinWork[])graph).Length;
            }
            else if (graph is SalesHistoryJoinWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //売上伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCd
            //実績計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //伝票検索日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchSlipDate
            //計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //売上行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //売上単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //BL商品コード（印刷）
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtBLGoodsCode
            //出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更----->>>>>
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更-----<<<<<
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //商品コード変換AB商品コード
            serInfo.MemberInfo.Add(typeof(string)); //ABGoodsCode
            //納品先店舗コード
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeShopCd
            //住電管理コード
            serInfo.MemberInfo.Add(typeof(string)); //SAndEMngCode
            //経費区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ExpenseDivCd
            //部品商コード（純正）
            serInfo.MemberInfo.Add(typeof(string)); //PureTradCompCd
            //部品商仕切率（純正）
            serInfo.MemberInfo.Add(typeof(Double)); //PureTradCompRate
            //部品商コード（優良）
            serInfo.MemberInfo.Add(typeof(string)); //PriTradCompCd
            //部品商仕切率（優良）
            serInfo.MemberInfo.Add(typeof(Double)); //PriTradCompRate
            //設定AB商品コード
            serInfo.MemberInfo.Add(typeof(string)); //SetABGoodsCode
            //商品メーカーコード１
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd1
            //商品メーカーコード２
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd2
            //商品メーカーコード３
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd3
            //商品メーカーコード４
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd4
            //商品メーカーコード５
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd5
            //商品メーカーコード６
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd6
            //商品メーカーコード７
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd7
            //商品メーカーコード８
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd8
            //商品メーカーコード９
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd9
            //商品メーカーコード１０
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd10
            //商品メーカーコード１１
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd11
            //商品メーカーコード１２
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd12
            //商品メーカーコード１３
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd13
            //商品メーカーコード１４
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd14
            //商品メーカーコード１５
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd15
            //SE企業コード
            serInfo.MemberInfo.Add(typeof(string)); //SEEnterpriseCode
            //SE受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //SEAcptAnOdrStatus
            //SE売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SESalesSlipNum
            //SE売上データ作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //SESalesCreateDateTime


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesHistoryJoinWork)
            {
                SalesHistoryJoinWork temp = (SalesHistoryJoinWork)graph;

                SetSalesHistoryJoinWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesHistoryJoinWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesHistoryJoinWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesHistoryJoinWork temp in lst)
                {
                    SetSalesHistoryJoinWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesHistoryJoinWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 55;// DEL zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更
        private const int currentMemberCount = 56;// ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更

        /// <summary>
        ///  SalesHistoryJoinWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistoryJoinWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2013/02/25 zhuhh</br>
        /// <br>                 :   Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更</br>
        /// </remarks>
        private void SetSalesHistoryJoinWork(System.IO.BinaryWriter writer, SalesHistoryJoinWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //売上伝票区分
            writer.Write(temp.SalesSlipCd);
            //実績計上拠点コード
            writer.Write(temp.ResultsAddUpSecCd);
            //伝票検索日付
            writer.Write((Int64)temp.SearchSlipDate.Ticks);
            //計上日付
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //売上行番号
            writer.Write(temp.SalesRowNo);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称カナ
            writer.Write(temp.GoodsNameKana);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //売上単価（税抜，浮動）
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //BL商品コード（印刷）
            writer.Write(temp.PrtBLGoodsCode);
            //出荷数
            writer.Write(temp.ShipmentCnt);
            //売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更----->>>>>
            //定価（税抜，浮動）
            writer.Write(temp.ListPriceTaxExcFl);
            // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更-----<<<<<
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //商品コード変換AB商品コード
            writer.Write(temp.ABGoodsCode);
            //納品先店舗コード
            writer.Write(temp.AddresseeShopCd);
            //住電管理コード
            writer.Write(temp.SAndEMngCode);
            //経費区分
            writer.Write(temp.ExpenseDivCd);
            //部品商コード（純正）
            writer.Write(temp.PureTradCompCd);
            //部品商仕切率（純正）
            writer.Write(temp.PureTradCompRate);
            //部品商コード（優良）
            writer.Write(temp.PriTradCompCd);
            //部品商仕切率（優良）
            writer.Write(temp.PriTradCompRate);
            //設定AB商品コード
            writer.Write(temp.SetABGoodsCode);
            //商品メーカーコード１
            writer.Write(temp.GoodsMakerCd1);
            //商品メーカーコード２
            writer.Write(temp.GoodsMakerCd2);
            //商品メーカーコード３
            writer.Write(temp.GoodsMakerCd3);
            //商品メーカーコード４
            writer.Write(temp.GoodsMakerCd4);
            //商品メーカーコード５
            writer.Write(temp.GoodsMakerCd5);
            //商品メーカーコード６
            writer.Write(temp.GoodsMakerCd6);
            //商品メーカーコード７
            writer.Write(temp.GoodsMakerCd7);
            //商品メーカーコード８
            writer.Write(temp.GoodsMakerCd8);
            //商品メーカーコード９
            writer.Write(temp.GoodsMakerCd9);
            //商品メーカーコード１０
            writer.Write(temp.GoodsMakerCd10);
            //商品メーカーコード１１
            writer.Write(temp.GoodsMakerCd11);
            //商品メーカーコード１２
            writer.Write(temp.GoodsMakerCd12);
            //商品メーカーコード１３
            writer.Write(temp.GoodsMakerCd13);
            //商品メーカーコード１４
            writer.Write(temp.GoodsMakerCd14);
            //商品メーカーコード１５
            writer.Write(temp.GoodsMakerCd15);
            //SE企業コード
            writer.Write(temp.SEEnterpriseCode);
            //SE受注ステータス
            writer.Write(temp.SEAcptAnOdrStatus);
            //SE売上伝票番号
            writer.Write(temp.SESalesSlipNum);
            //SE売上データ作成日時
            writer.Write(temp.SESalesCreateDateTime);

        }

        /// <summary>
        ///  SalesHistoryJoinWorkインスタンス取得
        /// </summary>
        /// <returns>SalesHistoryJoinWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistoryJoinWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       :   2013/02/25 zhuhh</br>
        /// <br>                 :   Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更</br>
        /// </remarks>
        private SalesHistoryJoinWork GetSalesHistoryJoinWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SalesHistoryJoinWork temp = new SalesHistoryJoinWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //売上伝票区分
            temp.SalesSlipCd = reader.ReadInt32();
            //実績計上拠点コード
            temp.ResultsAddUpSecCd = reader.ReadString();
            //伝票検索日付
            temp.SearchSlipDate = new DateTime(reader.ReadInt64());
            //計上日付
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //売上行番号
            temp.SalesRowNo = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称カナ
            temp.GoodsNameKana = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //売上単価（税抜，浮動）
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //BL商品コード（印刷）
            temp.PrtBLGoodsCode = reader.ReadInt32();
            //出荷数
            temp.ShipmentCnt = reader.ReadDouble();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更----->>>>>
            //定価（税抜，浮動）
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更-----<<<<<
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //商品コード変換AB商品コード
            temp.ABGoodsCode = reader.ReadString();
            //納品先店舗コード
            temp.AddresseeShopCd = reader.ReadString();
            //住電管理コード
            temp.SAndEMngCode = reader.ReadString();
            //経費区分
            temp.ExpenseDivCd = reader.ReadInt32();
            //部品商コード（純正）
            temp.PureTradCompCd = reader.ReadString();
            //部品商仕切率（純正）
            temp.PureTradCompRate = reader.ReadDouble();
            //部品商コード（優良）
            temp.PriTradCompCd = reader.ReadString();
            //部品商仕切率（優良）
            temp.PriTradCompRate = reader.ReadDouble();
            //設定AB商品コード
            temp.SetABGoodsCode = reader.ReadString();
            //商品メーカーコード１
            temp.GoodsMakerCd1 = reader.ReadInt32();
            //商品メーカーコード２
            temp.GoodsMakerCd2 = reader.ReadInt32();
            //商品メーカーコード３
            temp.GoodsMakerCd3 = reader.ReadInt32();
            //商品メーカーコード４
            temp.GoodsMakerCd4 = reader.ReadInt32();
            //商品メーカーコード５
            temp.GoodsMakerCd5 = reader.ReadInt32();
            //商品メーカーコード６
            temp.GoodsMakerCd6 = reader.ReadInt32();
            //商品メーカーコード７
            temp.GoodsMakerCd7 = reader.ReadInt32();
            //商品メーカーコード８
            temp.GoodsMakerCd8 = reader.ReadInt32();
            //商品メーカーコード９
            temp.GoodsMakerCd9 = reader.ReadInt32();
            //商品メーカーコード１０
            temp.GoodsMakerCd10 = reader.ReadInt32();
            //商品メーカーコード１１
            temp.GoodsMakerCd11 = reader.ReadInt32();
            //商品メーカーコード１２
            temp.GoodsMakerCd12 = reader.ReadInt32();
            //商品メーカーコード１３
            temp.GoodsMakerCd13 = reader.ReadInt32();
            //商品メーカーコード１４
            temp.GoodsMakerCd14 = reader.ReadInt32();
            //商品メーカーコード１５
            temp.GoodsMakerCd15 = reader.ReadInt32();
            //SE企業コード
            temp.SEEnterpriseCode = reader.ReadString();
            //SE受注ステータス
            temp.SEAcptAnOdrStatus = reader.ReadInt32();
            //SE売上伝票番号
            temp.SESalesSlipNum = reader.ReadString();
            //SE売上データ作成日時
            temp.SESalesCreateDateTime = reader.ReadInt64();


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
        /// <returns>SalesHistoryJoinWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistoryJoinWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesHistoryJoinWork temp = GetSalesHistoryJoinWork(reader, serInfo);
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
                    retValue = (SalesHistoryJoinWork[])lst.ToArray(typeof(SalesHistoryJoinWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
