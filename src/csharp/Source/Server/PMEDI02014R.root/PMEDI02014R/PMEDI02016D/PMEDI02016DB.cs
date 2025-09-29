//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上データテキスト出力結果ワーク
// プログラム概要   : 売上データテキスト出力結果ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11370098-00  作成担当 : 陳艶丹
// 作 成 日  2017/11/20   修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   EDISalesResultWork
    /// <summary>
    ///                      売上履歴データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上履歴データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/11/20</br>
    /// <br>Genarated Date   :   2017/11/20  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EDISalesResultWork : IFileHeader
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

        /// <summary>売上日付</summary>
        /// <remarks>(YYYYMMDD)</remarks>
        private Int32 _salesDate;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>販売従業員名称</summary>
        private string _salesEmployeeNm = "";

        /// <summary>伝票備考</summary>
        private string _slipNote = "";

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

        /// <summary>出荷数</summary>
        private Double _shipmentCnt;

        /// <summary>売上金額（税抜き）</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>売上単価（税抜，浮動）</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>定価（税抜，浮動）</summary>
        /// <remarks>税込み</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>車種半角名称</summary>
        /// <remarks>正式名称（半角で管理）</remarks>
        private string _modelHalfName = "";

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _eDIEnterpriseCode = "";

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _eDIAcptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _eDISalesSlipNum = "";

        /// <summary>売上データ作成日時</summary>
        /// <remarks>売上データの作成日時（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _eDISalesCreateDateTime;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _eDICustomerCode;

        /// <summary>連携事業所コード</summary>
        private string _cooperatOfficeCode = "";

        /// <summary>連携得意先コード</summary>
        private string _cooperatCustCode = "";

        /// <summary>部品商コード</summary>
        private string _tradCompCd = "";

        /// <summary>部品商名称</summary>
        private string _tradCompName = "";

        /// <summary>商品コード</summary>
        private string _goodsCode = "";

        /// <summary>値増BL商品コード</summary>
        private Int32 _increaseBLGoodsCode;

        /// <summary>値引BL商品コード</summary>
        private Int32 _discountBLGoodsCode;


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

        /// public propaty name  :  SalesDate
        /// <summary>売上日付プロパティ</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
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

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>販売従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>伝票備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
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

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>定価（税抜，浮動）プロパティ</summary>
        /// <value>税込み</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  ModelHalfName
        /// <summary>車種半角名称プロパティ</summary>
        /// <value>正式名称（半角で管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種半角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelHalfName
        {
            get { return _modelHalfName; }
            set { _modelHalfName = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式（フル型）プロパティ</summary>
        /// <value>フル型式(44桁用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（フル型）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  EDIEnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EDIEnterpriseCode
        {
            get { return _eDIEnterpriseCode; }
            set { _eDIEnterpriseCode = value; }
        }

        /// public propaty name  :  EDIAcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EDIAcptAnOdrStatus
        {
            get { return _eDIAcptAnOdrStatus; }
            set { _eDIAcptAnOdrStatus = value; }
        }

        /// public propaty name  :  EDISalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EDISalesSlipNum
        {
            get { return _eDISalesSlipNum; }
            set { _eDISalesSlipNum = value; }
        }

        /// public propaty name  :  EDISalesCreateDateTime
        /// <summary>売上データ作成日時プロパティ</summary>
        /// <value>売上データの作成日時（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上データ作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime EDISalesCreateDateTime
        {
            get { return _eDISalesCreateDateTime; }
            set { _eDISalesCreateDateTime = value; }
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

        /// public propaty name  :  EDICustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EDICustomerCode
        {
            get { return _eDICustomerCode; }
            set { _eDICustomerCode = value; }
        }

        /// public propaty name  :  CooperatOfficeCode
        /// <summary>連携事業所コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連携事業所コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CooperatOfficeCode
        {
            get { return _cooperatOfficeCode; }
            set { _cooperatOfficeCode = value; }
        }

        /// public propaty name  :  CooperatCustCode
        /// <summary>連携得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連携得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CooperatCustCode
        {
            get { return _cooperatCustCode; }
            set { _cooperatCustCode = value; }
        }

        /// public propaty name  :  TradCompCd
        /// <summary>部品商コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TradCompCd
        {
            get { return _tradCompCd; }
            set { _tradCompCd = value; }
        }

        /// public propaty name  :  TradCompName
        /// <summary>部品商名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TradCompName
        {
            get { return _tradCompName; }
            set { _tradCompName = value; }
        }

        /// public propaty name  :  GoodsCode
        /// <summary>商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsCode
        {
            get { return _goodsCode; }
            set { _goodsCode = value; }
        }

        /// public propaty name  :  IncreaseBLGoodsCode
        /// <summary>値増BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値増BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 IncreaseBLGoodsCode
        {
            get { return _increaseBLGoodsCode; }
            set { _increaseBLGoodsCode = value; }
        }

        /// public propaty name  :  DiscountBLGoodsCode
        /// <summary>値引BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DiscountBLGoodsCode
        {
            get { return _discountBLGoodsCode; }
            set { _discountBLGoodsCode = value; }
        }


        /// <summary>
        /// 売上履歴データワークコンストラクタ
        /// </summary>
        /// <returns>EDISalesResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EDISalesResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EDISalesResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシリアライザです。
    /// </summary>
    /// <returns>EDISalesResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   EDISalesResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class EDISalesResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EDISalesResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EDISalesResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is EDISalesResultWork || graph is ArrayList || graph is EDISalesResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(EDISalesResultWork).FullName));

            if (graph != null && graph is EDISalesResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EDISalesResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is EDISalesResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((EDISalesResultWork[])graph).Length;
            }
            else if (graph is EDISalesResultWork)
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
            //売上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //販売従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeNm
            //伝票備考
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote
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
            //出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //売上単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //車種半角名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelHalfName
            //型式（フル型）
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EDIEnterpriseCode
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //EDIAcptAnOdrStatus
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //EDISalesSlipNum
            //売上データ作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //EDISalesCreateDateTime
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //EDICustomerCode
            //連携事業所コード
            serInfo.MemberInfo.Add(typeof(string)); //CooperatOfficeCode
            //連携得意先コード
            serInfo.MemberInfo.Add(typeof(string)); //CooperatCustCode
            //部品商コード
            serInfo.MemberInfo.Add(typeof(string)); //TradCompCd
            //部品商名称
            serInfo.MemberInfo.Add(typeof(string)); //TradCompName
            //商品コード
            serInfo.MemberInfo.Add(typeof(string)); //GoodsCode
            //値増BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //IncreaseBLGoodsCode
            //値引BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //DiscountBLGoodsCode


            serInfo.Serialize(writer, serInfo);
            if (graph is EDISalesResultWork)
            {
                EDISalesResultWork temp = (EDISalesResultWork)graph;

                SetEDISalesResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is EDISalesResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((EDISalesResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (EDISalesResultWork temp in lst)
                {
                    SetEDISalesResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// EDISalesResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 40;

        /// <summary>
        ///  EDISalesResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EDISalesResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetEDISalesResultWork(System.IO.BinaryWriter writer, EDISalesResultWork temp)
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
            //売上日付
            writer.Write(temp.SalesDate);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //販売従業員名称
            writer.Write(temp.SalesEmployeeNm);
            //伝票備考
            writer.Write(temp.SlipNote);
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
            //出荷数
            writer.Write(temp.ShipmentCnt);
            //売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            //売上単価（税抜，浮動）
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //定価（税抜，浮動）
            writer.Write(temp.ListPriceTaxExcFl);
            //車種半角名称
            writer.Write(temp.ModelHalfName);
            //型式（フル型）
            writer.Write(temp.FullModel);
            //企業コード
            writer.Write(temp.EDIEnterpriseCode);
            //受注ステータス
            writer.Write(temp.EDIAcptAnOdrStatus);
            //売上伝票番号
            writer.Write(temp.EDISalesSlipNum);
            //売上データ作成日時
            writer.Write((Int64)temp.EDISalesCreateDateTime.Ticks);
            //拠点コード
            writer.Write(temp.SectionCode);
            //得意先コード
            writer.Write(temp.EDICustomerCode);
            //連携事業所コード
            writer.Write(temp.CooperatOfficeCode);
            //連携得意先コード
            writer.Write(temp.CooperatCustCode);
            //部品商コード
            writer.Write(temp.TradCompCd);
            //部品商名称
            writer.Write(temp.TradCompName);
            //商品コード
            writer.Write(temp.GoodsCode);
            //値増BL商品コード
            writer.Write(temp.IncreaseBLGoodsCode);
            //値引BL商品コード
            writer.Write(temp.DiscountBLGoodsCode);

        }

        /// <summary>
        ///  EDISalesResultWorkインスタンス取得
        /// </summary>
        /// <returns>EDISalesResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EDISalesResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private EDISalesResultWork GetEDISalesResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            EDISalesResultWork temp = new EDISalesResultWork();

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
            //売上日付
            temp.SalesDate = reader.ReadInt32();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //販売従業員名称
            temp.SalesEmployeeNm = reader.ReadString();
            //伝票備考
            temp.SlipNote = reader.ReadString();
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
            //出荷数
            temp.ShipmentCnt = reader.ReadDouble();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //売上単価（税抜，浮動）
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //定価（税抜，浮動）
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //車種半角名称
            temp.ModelHalfName = reader.ReadString();
            //型式（フル型）
            temp.FullModel = reader.ReadString();
            //企業コード
            temp.EDIEnterpriseCode = reader.ReadString();
            //受注ステータス
            temp.EDIAcptAnOdrStatus = reader.ReadInt32();
            //売上伝票番号
            temp.EDISalesSlipNum = reader.ReadString();
            //売上データ作成日時
            temp.EDISalesCreateDateTime = new DateTime(reader.ReadInt64());
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //得意先コード
            temp.EDICustomerCode = reader.ReadInt32();
            //連携事業所コード
            temp.CooperatOfficeCode = reader.ReadString();
            //連携得意先コード
            temp.CooperatCustCode = reader.ReadString();
            //部品商コード
            temp.TradCompCd = reader.ReadString();
            //部品商名称
            temp.TradCompName = reader.ReadString();
            //商品コード
            temp.GoodsCode = reader.ReadString();
            //値増BL商品コード
            temp.IncreaseBLGoodsCode = reader.ReadInt32();
            //値引BL商品コード
            temp.DiscountBLGoodsCode = reader.ReadInt32();


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
        /// <returns>EDISalesResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EDISalesResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                EDISalesResultWork temp = GetEDISalesResultWork(reader, serInfo);
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
                    retValue = (EDISalesResultWork[])lst.ToArray(typeof(EDISalesResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
