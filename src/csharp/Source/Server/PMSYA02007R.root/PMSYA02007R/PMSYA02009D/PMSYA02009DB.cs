//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌別出荷実績表
// プログラム概要   : 車輌別出荷実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/09/15  修正内容 : 新規作成
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

    /// public class name:   CarShipResultWork
    /// <summary>
    ///                      売上履歴データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上履歴データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2009/09/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  杉村</br>
    /// <br>                 :   ○スペルミス修正</br>
    /// <br>                 :   売上値引非課税対象額合計</br>
    /// <br>                 :   売上正価金額</br>
    /// <br>                 :   売上金額消費税額（外税）</br>
    /// <br>Update Note      :   2008/7/29  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   得意先伝票番号</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CarShipResultWork : IFileHeader
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

        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum = "";

        /// <summary>実績計上拠点コード</summary>
        /// <remarks>実績計上を行う企業内の拠点コード</remarks>
        private string _resultsAddUpSecCd = "";

        /// <summary>売上日付</summary>
        /// <remarks>(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

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

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>BLグループコード</summary>
        /// <remarks>旧グループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BLグループコードカナ名称</summary>
        /// <remarks>半角カナ</remarks>
        private string _bLGroupKanaName = "";

        /// <summary>定価（税抜，浮動）</summary>
        /// <remarks>税込み</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>売上単価（税抜，浮動）</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>原価単価</summary>
        private Double _salesUnitCost;

        /// <summary>出荷数</summary>
        private Double _shipmentCnt;

        /// <summary>出荷数(在庫)</summary>
        private Double _shipmentCntIn;

        /// <summary>出荷数(取寄)</summary>
        private Double _shipmentCntNotIn;

        /// <summary>売上在庫取寄せ区分</summary>
        /// <remarks>0:取寄せ，1:在庫</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>売上金額（税抜き）</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>粗利金額</summary>
        private Int64 _grossProfit;

        /// <summary>車両管理番号</summary>
        /// <remarks>自動採番（無重複のシーケンス）PM7での車両SEQ</remarks>
        private Int32 _carMngNo;

        /// <summary>車輌管理コード</summary>
        /// <remarks>※PM7での車両管理番号</remarks>
        private string _carMngCode = "";

        /// <summary>陸運事務局名称</summary>
        private string _numberPlate1Name = "";

        /// <summary>車両登録番号（種別）</summary>
        private string _numberPlate2 = "";

        /// <summary>車両登録番号（カナ）</summary>
        private string _numberPlate3 = "";

        /// <summary>車両登録番号（プレート番号）</summary>
        private Int32 _numberPlate4;

        /// <summary>初年度</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _firstEntryDate;

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>車種コード</summary>
        /// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _modelCode;

        /// <summary>車種サブコード</summary>
        /// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
        private Int32 _modelSubCode;

        /// <summary>車種半角名称</summary>
        /// <remarks>正式名称（半角で管理）</remarks>
        private string _modelHalfName = "";

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>車両走行距離</summary>
        private Int32 _mileage;


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
        public DateTime SalesDate
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

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL商品コード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>旧グループコード</value>
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

        /// public propaty name  :  BLGroupKanaName
        /// <summary>BLグループコードカナ名称プロパティ</summary>
        /// <value>半角カナ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGroupKanaName
        {
            get { return _bLGroupKanaName; }
            set { _bLGroupKanaName = value; }
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

        /// public propaty name  :  SalesUnitCost
        /// <summary>原価単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
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

        /// public propaty name  :  ShipmentCntIn
        /// <summary>出荷数(在庫)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数(在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCntIn
        {
            get { return _shipmentCntIn; }
            set { _shipmentCntIn = value; }
        }

        /// public propaty name  :  ShipmentCntNotIn
        /// <summary>出荷数(取寄)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数(取寄)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCntNotIn
        {
            get { return _shipmentCntNotIn; }
            set { _shipmentCntNotIn = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>売上在庫取寄せ区分プロパティ</summary>
        /// <value>0:取寄せ，1:在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
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

        /// public propaty name  :  GrossProfit
        /// <summary>粗利金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }

        /// public propaty name  :  CarMngNo
        /// <summary>車両管理番号プロパティ</summary>
        /// <value>自動採番（無重複のシーケンス）PM7での車両SEQ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMngNo
        {
            get { return _carMngNo; }
            set { _carMngNo = value; }
        }

        /// public propaty name  :  CarMngCode
        /// <summary>車輌管理コードプロパティ</summary>
        /// <value>※PM7での車両管理番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  NumberPlate1Name
        /// <summary>陸運事務局名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   陸運事務局名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NumberPlate1Name
        {
            get { return _numberPlate1Name; }
            set { _numberPlate1Name = value; }
        }

        /// public propaty name  :  NumberPlate2
        /// <summary>車両登録番号（種別）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（種別）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NumberPlate2
        {
            get { return _numberPlate2; }
            set { _numberPlate2 = value; }
        }

        /// public propaty name  :  NumberPlate3
        /// <summary>車両登録番号（カナ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（カナ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NumberPlate3
        {
            get { return _numberPlate3; }
            set { _numberPlate3 = value; }
        }

        /// public propaty name  :  NumberPlate4
        /// <summary>車両登録番号（プレート番号）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（プレート番号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NumberPlate4
        {
            get { return _numberPlate4; }
            set { _numberPlate4 = value; }
        }

        /// public propaty name  :  FirstEntryDate
        /// <summary>初年度プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime FirstEntryDate
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>車種コードプロパティ</summary>
        /// <value>車名コード(翼) 1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  ModelSubCode
        /// <summary>車種サブコードプロパティ</summary>
        /// <value>0～899:提供分,900～ﾕｰｻﾞｰ登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
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

        /// public propaty name  :  Mileage
        /// <summary>車両走行距離プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両走行距離プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Mileage
        {
            get { return _mileage; }
            set { _mileage = value; }
        }


        /// <summary>
        /// 売上履歴データワークコンストラクタ
        /// </summary>
        /// <returns>CarShipResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarShipResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CarShipResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CarShipResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CarShipResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CarShipResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarShipResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CarShipResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CarShipResultWork || graph is ArrayList || graph is CarShipResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CarShipResultWork).FullName));

            if (graph != null && graph is CarShipResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CarShipResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CarShipResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CarShipResultWork[])graph).Length;
            }
            else if (graph is CarShipResultWork)
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
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //実績計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //売上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
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
            //BL商品コード名称（半角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsHalfName
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BLグループコードカナ名称
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupKanaName
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //売上単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //原価単価
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //出荷数(在庫)
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCntIn
            //出荷数(取寄)
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCntNotIn
            //売上在庫取寄せ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //粗利金額
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //車両管理番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CarMngNo
            //車輌管理コード
            serInfo.MemberInfo.Add(typeof(string)); //CarMngCode
            //陸運事務局名称
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate1Name
            //車両登録番号（種別）
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate2
            //車両登録番号（カナ）
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate3
            //車両登録番号（プレート番号）
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate4
            //初年度
            serInfo.MemberInfo.Add(typeof(Int32)); //FirstEntryDate
            //メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //車種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
            //車種サブコード
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
            //車種半角名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelHalfName
            //型式（フル型）
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //車両走行距離
            serInfo.MemberInfo.Add(typeof(Int32)); //Mileage


            serInfo.Serialize(writer, serInfo);
            if (graph is CarShipResultWork)
            {
                CarShipResultWork temp = (CarShipResultWork)graph;

                SetCarShipResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CarShipResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CarShipResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CarShipResultWork temp in lst)
                {
                    SetCarShipResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CarShipResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 44;

        /// <summary>
        ///  CarShipResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarShipResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCarShipResultWork(System.IO.BinaryWriter writer, CarShipResultWork temp)
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
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //実績計上拠点コード
            writer.Write(temp.ResultsAddUpSecCd);
            //売上日付
            writer.Write((Int64)temp.SalesDate.Ticks);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先略称
            writer.Write(temp.CustomerSnm);
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
            //BL商品コード名称（半角）
            writer.Write(temp.BLGoodsHalfName);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //BLグループコードカナ名称
            writer.Write(temp.BLGroupKanaName);
            //定価（税抜，浮動）
            writer.Write(temp.ListPriceTaxExcFl);
            //売上単価（税抜，浮動）
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //原価単価
            writer.Write(temp.SalesUnitCost);
            //出荷数
            writer.Write(temp.ShipmentCnt);
            //出荷数(在庫)
            writer.Write(temp.ShipmentCntIn);
            //出荷数(取寄)
            writer.Write(temp.ShipmentCntNotIn);
            //売上在庫取寄せ区分
            writer.Write(temp.SalesOrderDivCd);
            //売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //粗利金額
            writer.Write(temp.GrossProfit);
            //車両管理番号
            writer.Write(temp.CarMngNo);
            //車輌管理コード
            writer.Write(temp.CarMngCode);
            //陸運事務局名称
            writer.Write(temp.NumberPlate1Name);
            //車両登録番号（種別）
            writer.Write(temp.NumberPlate2);
            //車両登録番号（カナ）
            writer.Write(temp.NumberPlate3);
            //車両登録番号（プレート番号）
            writer.Write(temp.NumberPlate4);
            //初年度
            writer.Write((Int64)temp.FirstEntryDate.Ticks);
            //メーカーコード
            writer.Write(temp.MakerCode);
            //車種コード
            writer.Write(temp.ModelCode);
            //車種サブコード
            writer.Write(temp.ModelSubCode);
            //車種半角名称
            writer.Write(temp.ModelHalfName);
            //型式（フル型）
            writer.Write(temp.FullModel);
            //車両走行距離
            writer.Write(temp.Mileage);

        }

        /// <summary>
        ///  CarShipResultWorkインスタンス取得
        /// </summary>
        /// <returns>CarShipResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarShipResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CarShipResultWork GetCarShipResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CarShipResultWork temp = new CarShipResultWork();

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
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //実績計上拠点コード
            temp.ResultsAddUpSecCd = reader.ReadString();
            //売上日付
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
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
            //BL商品コード名称（半角）
            temp.BLGoodsHalfName = reader.ReadString();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //BLグループコードカナ名称
            temp.BLGroupKanaName = reader.ReadString();
            //定価（税抜，浮動）
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //売上単価（税抜，浮動）
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //原価単価
            temp.SalesUnitCost = reader.ReadDouble();
            //出荷数
            temp.ShipmentCnt = reader.ReadDouble();
            //出荷数(在庫)
            temp.ShipmentCntIn = reader.ReadDouble();
            //出荷数(取寄)
            temp.ShipmentCntNotIn = reader.ReadDouble();
            //売上在庫取寄せ区分
            temp.SalesOrderDivCd = reader.ReadInt32();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //粗利金額
            temp.GrossProfit = reader.ReadInt64();
            //車両管理番号
            temp.CarMngNo = reader.ReadInt32();
            //車輌管理コード
            temp.CarMngCode = reader.ReadString();
            //陸運事務局名称
            temp.NumberPlate1Name = reader.ReadString();
            //車両登録番号（種別）
            temp.NumberPlate2 = reader.ReadString();
            //車両登録番号（カナ）
            temp.NumberPlate3 = reader.ReadString();
            //車両登録番号（プレート番号）
            temp.NumberPlate4 = reader.ReadInt32();
            //初年度
            temp.FirstEntryDate = new DateTime(reader.ReadInt64());
            //メーカーコード
            temp.MakerCode = reader.ReadInt32();
            //車種コード
            temp.ModelCode = reader.ReadInt32();
            //車種サブコード
            temp.ModelSubCode = reader.ReadInt32();
            //車種半角名称
            temp.ModelHalfName = reader.ReadString();
            //型式（フル型）
            temp.FullModel = reader.ReadString();
            //車両走行距離
            temp.Mileage = reader.ReadInt32();


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
        /// <returns>CarShipResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarShipResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CarShipResultWork temp = GetCarShipResultWork(reader, serInfo);
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
                    retValue = (CarShipResultWork[])lst.ToArray(typeof(CarShipResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }



}
