//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : オートバックス設定マスタメンテナンス
// プログラム概要   : オートバックス設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/07/30  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SAndESetting
    /// <summary>
    ///                      オートバックス設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   オートバックス設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/6/25</br>
    /// <br>Genarated Date   :   2009/07/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/7/17  杉村</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   商品メーカーコード１５</br>
    /// <br>                 :   ○キー変更</br>
    /// <br>                 :   3,10→3,9,10</br>
    /// </remarks>
    public class SAndESetting
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

        /// <summary>拠点コード</summary>
        /// <remarks>ログイン担当者の所属拠点コードをセット</remarks>
        private string _sectionCode = "";

        /// <summary>拠点名称</summary>
        /// <remarks>ログイン担当者の所属拠点名称をセット</remarks>
        private string _sectionName = "";


        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先名称</summary>
        /// <remarks>ログイン担当者の所属得意先名称をセット</remarks>
        private string _customerName = "";


        /// <summary>納品先店舗コード</summary>
        private string _addresseeShopCd = "";

        /// <summary>住電管理コード</summary>
        private string _sAndEMngCode = "";

        /// <summary>経費区分</summary>
        private Int32 _expenseDivCd;

        /// <summary>直送区分</summary>
        private Int32 _directSendingCd;

        /// <summary>受注区分</summary>
        private Int32 _acptAnOrderDiv;

        /// <summary>納品者コード</summary>
        private string _delivererCd = "";

        /// <summary>納品者名</summary>
        private string _delivererNm = "";

        /// <summary>納品者住所</summary>
        private string _delivererAddress = "";

        /// <summary>納品者ＴＥＬ</summary>
        private string _delivererPhoneNum = "";

        /// <summary>部品商名</summary>
        private string _tradCompName = "";

        /// <summary>部品商拠点名</summary>
        private string _tradCompSectName = "";

        /// <summary>部品商コード（純正）</summary>
        private string _pureTradCompCd = "";

        /// <summary>部品商仕切率（純正）</summary>
        private Double _pureTradCompRate;

        /// <summary>部品商コード（優良）</summary>
        private string _priTradCompCd = "";

        /// <summary>部品商仕切率（優良）</summary>
        private Double _priTradCompRate;

        /// <summary>AB商品コード</summary>
        private string _aBGoodsCode = "";

        /// <summary>コメント指定区分</summary>
        /// <remarks>"７行目コメント指定区分"</remarks>
        private Int32 _commentReservedDiv;

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

        /// <summary>部品ＯＥＭ区分</summary>
        private Int32 _partsOEMDiv;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";


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

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>ログイン担当者の所属拠点コードをセット</value>
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

        /// public propaty name  :  SectionName
        /// <summary>拠点名称プロパティ</summary>
        /// <value>ログイン担当者の所属拠点名称をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
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

        /// public propaty name  :  CustomerName
        /// <summary>得意先名称プロパティ</summary>
        /// <value>ログイン担当者の所属得意先名称をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
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

        /// public propaty name  :  DirectSendingCd
        /// <summary>直送区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   直送区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DirectSendingCd
        {
            get { return _directSendingCd; }
            set { _directSendingCd = value; }
        }

        /// public propaty name  :  AcptAnOrderDiv
        /// <summary>受注区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOrderDiv
        {
            get { return _acptAnOrderDiv; }
            set { _acptAnOrderDiv = value; }
        }

        /// public propaty name  :  DelivererCd
        /// <summary>納品者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DelivererCd
        {
            get { return _delivererCd; }
            set { _delivererCd = value; }
        }

        /// public propaty name  :  DelivererNm
        /// <summary>納品者名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品者名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DelivererNm
        {
            get { return _delivererNm; }
            set { _delivererNm = value; }
        }

        /// public propaty name  :  DelivererAddress
        /// <summary>納品者住所プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品者住所プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DelivererAddress
        {
            get { return _delivererAddress; }
            set { _delivererAddress = value; }
        }

        /// public propaty name  :  DelivererPhoneNum
        /// <summary>納品者ＴＥＬプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品者ＴＥＬプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DelivererPhoneNum
        {
            get { return _delivererPhoneNum; }
            set { _delivererPhoneNum = value; }
        }

        /// public propaty name  :  TradCompName
        /// <summary>部品商名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TradCompName
        {
            get { return _tradCompName; }
            set { _tradCompName = value; }
        }

        /// public propaty name  :  TradCompSectName
        /// <summary>部品商拠点名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商拠点名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TradCompSectName
        {
            get { return _tradCompSectName; }
            set { _tradCompSectName = value; }
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

        /// public propaty name  :  ABGoodsCode
        /// <summary>AB商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   AB商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ABGoodsCode
        {
            get { return _aBGoodsCode; }
            set { _aBGoodsCode = value; }
        }

        /// public propaty name  :  CommentReservedDiv
        /// <summary>コメント指定区分プロパティ</summary>
        /// <value>"７行目コメント指定区分"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コメント指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CommentReservedDiv
        {
            get { return _commentReservedDiv; }
            set { _commentReservedDiv = value; }
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

        /// public propaty name  :  PartsOEMDiv
        /// <summary>部品ＯＥＭ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品ＯＥＭ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsOEMDiv
        {
            get { return _partsOEMDiv; }
            set { _partsOEMDiv = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>更新従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }


        /// <summary>
        /// オートバックス設定マスタコンストラクタ
        /// </summary>
        /// <returns>SAndESettingクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndESettingクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SAndESetting()
        {
        }

        /// <summary>
        /// オートバックス設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード(ログイン担当者の所属拠点コードをセット)</param>
        /// <param name="sectionName">拠点名称(ログイン担当者の所属拠点名称をセット)</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerName">得意先名称</param>
        /// <param name="addresseeShopCd">納品先店舗コード</param>
        /// <param name="sAndEMngCode">住電管理コード</param>
        /// <param name="expenseDivCd">経費区分</param>
        /// <param name="directSendingCd">直送区分</param>
        /// <param name="acptAnOrderDiv">受注区分</param>
        /// <param name="delivererCd">納品者コード</param>
        /// <param name="delivererNm">納品者名</param>
        /// <param name="delivererAddress">納品者住所</param>
        /// <param name="delivererPhoneNum">納品者ＴＥＬ</param>
        /// <param name="tradCompName">部品商名</param>
        /// <param name="tradCompSectName">部品商拠点名</param>
        /// <param name="pureTradCompCd">部品商コード（純正）</param>
        /// <param name="pureTradCompRate">部品商仕切率（純正）</param>
        /// <param name="priTradCompCd">部品商コード（優良）</param>
        /// <param name="priTradCompRate">部品商仕切率（優良）</param>
        /// <param name="aBGoodsCode">AB商品コード</param>
        /// <param name="commentReservedDiv">コメント指定区分("７行目コメント指定区分")</param>
        /// <param name="goodsMakerCd1">商品メーカーコード１</param>
        /// <param name="goodsMakerCd2">商品メーカーコード２</param>
        /// <param name="goodsMakerCd3">商品メーカーコード３</param>
        /// <param name="goodsMakerCd4">商品メーカーコード４</param>
        /// <param name="goodsMakerCd5">商品メーカーコード５</param>
        /// <param name="goodsMakerCd6">商品メーカーコード６</param>
        /// <param name="goodsMakerCd7">商品メーカーコード７</param>
        /// <param name="goodsMakerCd8">商品メーカーコード８</param>
        /// <param name="goodsMakerCd9">商品メーカーコード９</param>
        /// <param name="goodsMakerCd10">商品メーカーコード１０</param>
        /// <param name="goodsMakerCd11">商品メーカーコード１１</param>
        /// <param name="goodsMakerCd12">商品メーカーコード１２</param>
        /// <param name="goodsMakerCd13">商品メーカーコード１３</param>
        /// <param name="goodsMakerCd14">商品メーカーコード１４</param>
        /// <param name="goodsMakerCd15">商品メーカーコード１５</param>
        /// <param name="partsOEMDiv">部品ＯＥＭ区分</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>SAndESettingクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndESettingクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SAndESetting(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string sectionName, Int32 customerCode, string customerName, string addresseeShopCd, string sAndEMngCode, Int32 expenseDivCd, Int32 directSendingCd, Int32 acptAnOrderDiv, string delivererCd, string delivererNm, string delivererAddress, string delivererPhoneNum, string tradCompName, string tradCompSectName, string pureTradCompCd, Double pureTradCompRate, string priTradCompCd, Double priTradCompRate, string aBGoodsCode, Int32 commentReservedDiv, Int32 goodsMakerCd1, Int32 goodsMakerCd2, Int32 goodsMakerCd3, Int32 goodsMakerCd4, Int32 goodsMakerCd5, Int32 goodsMakerCd6, Int32 goodsMakerCd7, Int32 goodsMakerCd8, Int32 goodsMakerCd9, Int32 goodsMakerCd10, Int32 goodsMakerCd11, Int32 goodsMakerCd12, Int32 goodsMakerCd13, Int32 goodsMakerCd14, Int32 goodsMakerCd15, Int32 partsOEMDiv, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._sectionName = sectionName;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._addresseeShopCd = addresseeShopCd;
            this._sAndEMngCode = sAndEMngCode;
            this._expenseDivCd = expenseDivCd;
            this._directSendingCd = directSendingCd;
            this._acptAnOrderDiv = acptAnOrderDiv;
            this._delivererCd = delivererCd;
            this._delivererNm = delivererNm;
            this._delivererAddress = delivererAddress;
            this._delivererPhoneNum = delivererPhoneNum;
            this._tradCompName = tradCompName;
            this._tradCompSectName = tradCompSectName;
            this._pureTradCompCd = pureTradCompCd;
            this._pureTradCompRate = pureTradCompRate;
            this._priTradCompCd = priTradCompCd;
            this._priTradCompRate = priTradCompRate;
            this._aBGoodsCode = aBGoodsCode;
            this._commentReservedDiv = commentReservedDiv;
            this._goodsMakerCd1 = goodsMakerCd1;
            this._goodsMakerCd2 = goodsMakerCd2;
            this._goodsMakerCd3 = goodsMakerCd3;
            this._goodsMakerCd4 = goodsMakerCd4;
            this._goodsMakerCd5 = goodsMakerCd5;
            this._goodsMakerCd6 = goodsMakerCd6;
            this._goodsMakerCd7 = goodsMakerCd7;
            this._goodsMakerCd8 = goodsMakerCd8;
            this._goodsMakerCd9 = goodsMakerCd9;
            this._goodsMakerCd10 = goodsMakerCd10;
            this._goodsMakerCd11 = goodsMakerCd11;
            this._goodsMakerCd12 = goodsMakerCd12;
            this._goodsMakerCd13 = goodsMakerCd13;
            this._goodsMakerCd14 = goodsMakerCd14;
            this._goodsMakerCd15 = goodsMakerCd15;
            this._partsOEMDiv = partsOEMDiv;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// オートバックス設定マスタ複製処理
        /// </summary>
        /// <returns>SAndESettingクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSAndESettingクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SAndESetting Clone()
        {
            return new SAndESetting(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._sectionName, this._customerCode, this._customerName, this._addresseeShopCd, this._sAndEMngCode, this._expenseDivCd, this._directSendingCd, this._acptAnOrderDiv, this._delivererCd, this._delivererNm, this._delivererAddress, this._delivererPhoneNum, this._tradCompName, this._tradCompSectName, this._pureTradCompCd, this._pureTradCompRate, this._priTradCompCd, this._priTradCompRate, this._aBGoodsCode, this._commentReservedDiv, this._goodsMakerCd1, this._goodsMakerCd2, this._goodsMakerCd3, this._goodsMakerCd4, this._goodsMakerCd5, this._goodsMakerCd6, this._goodsMakerCd7, this._goodsMakerCd8, this._goodsMakerCd9, this._goodsMakerCd10, this._goodsMakerCd11, this._goodsMakerCd12, this._goodsMakerCd13, this._goodsMakerCd14, this._goodsMakerCd15, this._partsOEMDiv, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// オートバックス設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSAndESettingクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndESettingクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SAndESetting target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SectionName == target.SectionName)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerName == target.CustomerName)
                 && (this.AddresseeShopCd == target.AddresseeShopCd)
                 && (this.SAndEMngCode == target.SAndEMngCode)
                 && (this.ExpenseDivCd == target.ExpenseDivCd)
                 && (this.DirectSendingCd == target.DirectSendingCd)
                 && (this.AcptAnOrderDiv == target.AcptAnOrderDiv)
                 && (this.DelivererCd == target.DelivererCd)
                 && (this.DelivererNm == target.DelivererNm)
                 && (this.DelivererAddress == target.DelivererAddress)
                 && (this.DelivererPhoneNum == target.DelivererPhoneNum)
                 && (this.TradCompName == target.TradCompName)
                 && (this.TradCompSectName == target.TradCompSectName)
                 && (this.PureTradCompCd == target.PureTradCompCd)
                 && (this.PureTradCompRate == target.PureTradCompRate)
                 && (this.PriTradCompCd == target.PriTradCompCd)
                 && (this.PriTradCompRate == target.PriTradCompRate)
                 && (this.ABGoodsCode == target.ABGoodsCode)
                 && (this.CommentReservedDiv == target.CommentReservedDiv)
                 && (this.GoodsMakerCd1 == target.GoodsMakerCd1)
                 && (this.GoodsMakerCd2 == target.GoodsMakerCd2)
                 && (this.GoodsMakerCd3 == target.GoodsMakerCd3)
                 && (this.GoodsMakerCd4 == target.GoodsMakerCd4)
                 && (this.GoodsMakerCd5 == target.GoodsMakerCd5)
                 && (this.GoodsMakerCd6 == target.GoodsMakerCd6)
                 && (this.GoodsMakerCd7 == target.GoodsMakerCd7)
                 && (this.GoodsMakerCd8 == target.GoodsMakerCd8)
                 && (this.GoodsMakerCd9 == target.GoodsMakerCd9)
                 && (this.GoodsMakerCd10 == target.GoodsMakerCd10)
                 && (this.GoodsMakerCd11 == target.GoodsMakerCd11)
                 && (this.GoodsMakerCd12 == target.GoodsMakerCd12)
                 && (this.GoodsMakerCd13 == target.GoodsMakerCd13)
                 && (this.GoodsMakerCd14 == target.GoodsMakerCd14)
                 && (this.GoodsMakerCd15 == target.GoodsMakerCd15)
                 && (this.PartsOEMDiv == target.PartsOEMDiv)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// オートバックス設定マスタ比較処理
        /// </summary>
        /// <param name="sAndESetting1">
        ///                    比較するSAndESettingクラスのインスタンス
        /// </param>
        /// <param name="sAndESetting2">比較するSAndESettingクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndESettingクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SAndESetting sAndESetting1, SAndESetting sAndESetting2)
        {
            return ((sAndESetting1.CreateDateTime == sAndESetting2.CreateDateTime)
                 && (sAndESetting1.UpdateDateTime == sAndESetting2.UpdateDateTime)
                 && (sAndESetting1.EnterpriseCode == sAndESetting2.EnterpriseCode)
                 && (sAndESetting1.FileHeaderGuid == sAndESetting2.FileHeaderGuid)
                 && (sAndESetting1.UpdEmployeeCode == sAndESetting2.UpdEmployeeCode)
                 && (sAndESetting1.UpdAssemblyId1 == sAndESetting2.UpdAssemblyId1)
                 && (sAndESetting1.UpdAssemblyId2 == sAndESetting2.UpdAssemblyId2)
                 && (sAndESetting1.LogicalDeleteCode == sAndESetting2.LogicalDeleteCode)
                 && (sAndESetting1.SectionCode == sAndESetting2.SectionCode)
                 && (sAndESetting1.SectionName == sAndESetting2.SectionName)
                 && (sAndESetting1.CustomerCode == sAndESetting2.CustomerCode)
                 && (sAndESetting1.CustomerName == sAndESetting2.CustomerName)
                 && (sAndESetting1.AddresseeShopCd == sAndESetting2.AddresseeShopCd)
                 && (sAndESetting1.SAndEMngCode == sAndESetting2.SAndEMngCode)
                 && (sAndESetting1.ExpenseDivCd == sAndESetting2.ExpenseDivCd)
                 && (sAndESetting1.DirectSendingCd == sAndESetting2.DirectSendingCd)
                 && (sAndESetting1.AcptAnOrderDiv == sAndESetting2.AcptAnOrderDiv)
                 && (sAndESetting1.DelivererCd == sAndESetting2.DelivererCd)
                 && (sAndESetting1.DelivererNm == sAndESetting2.DelivererNm)
                 && (sAndESetting1.DelivererAddress == sAndESetting2.DelivererAddress)
                 && (sAndESetting1.DelivererPhoneNum == sAndESetting2.DelivererPhoneNum)
                 && (sAndESetting1.TradCompName == sAndESetting2.TradCompName)
                 && (sAndESetting1.TradCompSectName == sAndESetting2.TradCompSectName)
                 && (sAndESetting1.PureTradCompCd == sAndESetting2.PureTradCompCd)
                 && (sAndESetting1.PureTradCompRate == sAndESetting2.PureTradCompRate)
                 && (sAndESetting1.PriTradCompCd == sAndESetting2.PriTradCompCd)
                 && (sAndESetting1.PriTradCompRate == sAndESetting2.PriTradCompRate)
                 && (sAndESetting1.ABGoodsCode == sAndESetting2.ABGoodsCode)
                 && (sAndESetting1.CommentReservedDiv == sAndESetting2.CommentReservedDiv)
                 && (sAndESetting1.GoodsMakerCd1 == sAndESetting2.GoodsMakerCd1)
                 && (sAndESetting1.GoodsMakerCd2 == sAndESetting2.GoodsMakerCd2)
                 && (sAndESetting1.GoodsMakerCd3 == sAndESetting2.GoodsMakerCd3)
                 && (sAndESetting1.GoodsMakerCd4 == sAndESetting2.GoodsMakerCd4)
                 && (sAndESetting1.GoodsMakerCd5 == sAndESetting2.GoodsMakerCd5)
                 && (sAndESetting1.GoodsMakerCd6 == sAndESetting2.GoodsMakerCd6)
                 && (sAndESetting1.GoodsMakerCd7 == sAndESetting2.GoodsMakerCd7)
                 && (sAndESetting1.GoodsMakerCd8 == sAndESetting2.GoodsMakerCd8)
                 && (sAndESetting1.GoodsMakerCd9 == sAndESetting2.GoodsMakerCd9)
                 && (sAndESetting1.GoodsMakerCd10 == sAndESetting2.GoodsMakerCd10)
                 && (sAndESetting1.GoodsMakerCd11 == sAndESetting2.GoodsMakerCd11)
                 && (sAndESetting1.GoodsMakerCd12 == sAndESetting2.GoodsMakerCd12)
                 && (sAndESetting1.GoodsMakerCd13 == sAndESetting2.GoodsMakerCd13)
                 && (sAndESetting1.GoodsMakerCd14 == sAndESetting2.GoodsMakerCd14)
                 && (sAndESetting1.GoodsMakerCd15 == sAndESetting2.GoodsMakerCd15)
                 && (sAndESetting1.PartsOEMDiv == sAndESetting2.PartsOEMDiv)
                 && (sAndESetting1.EnterpriseName == sAndESetting2.EnterpriseName)
                 && (sAndESetting1.UpdEmployeeName == sAndESetting2.UpdEmployeeName));
        }
        /// <summary>
        /// オートバックス設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSAndESettingクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndESettingクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SAndESetting target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SectionName != target.SectionName) resList.Add("SectionName");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.AddresseeShopCd != target.AddresseeShopCd) resList.Add("AddresseeShopCd");
            if (this.SAndEMngCode != target.SAndEMngCode) resList.Add("SAndEMngCode");
            if (this.ExpenseDivCd != target.ExpenseDivCd) resList.Add("ExpenseDivCd");
            if (this.DirectSendingCd != target.DirectSendingCd) resList.Add("DirectSendingCd");
            if (this.AcptAnOrderDiv != target.AcptAnOrderDiv) resList.Add("AcptAnOrderDiv");
            if (this.DelivererCd != target.DelivererCd) resList.Add("DelivererCd");
            if (this.DelivererNm != target.DelivererNm) resList.Add("DelivererNm");
            if (this.DelivererAddress != target.DelivererAddress) resList.Add("DelivererAddress");
            if (this.DelivererPhoneNum != target.DelivererPhoneNum) resList.Add("DelivererPhoneNum");
            if (this.TradCompName != target.TradCompName) resList.Add("TradCompName");
            if (this.TradCompSectName != target.TradCompSectName) resList.Add("TradCompSectName");
            if (this.PureTradCompCd != target.PureTradCompCd) resList.Add("PureTradCompCd");
            if (this.PureTradCompRate != target.PureTradCompRate) resList.Add("PureTradCompRate");
            if (this.PriTradCompCd != target.PriTradCompCd) resList.Add("PriTradCompCd");
            if (this.PriTradCompRate != target.PriTradCompRate) resList.Add("PriTradCompRate");
            if (this.ABGoodsCode != target.ABGoodsCode) resList.Add("ABGoodsCode");
            if (this.CommentReservedDiv != target.CommentReservedDiv) resList.Add("CommentReservedDiv");
            if (this.GoodsMakerCd1 != target.GoodsMakerCd1) resList.Add("GoodsMakerCd1");
            if (this.GoodsMakerCd2 != target.GoodsMakerCd2) resList.Add("GoodsMakerCd2");
            if (this.GoodsMakerCd3 != target.GoodsMakerCd3) resList.Add("GoodsMakerCd3");
            if (this.GoodsMakerCd4 != target.GoodsMakerCd4) resList.Add("GoodsMakerCd4");
            if (this.GoodsMakerCd5 != target.GoodsMakerCd5) resList.Add("GoodsMakerCd5");
            if (this.GoodsMakerCd6 != target.GoodsMakerCd6) resList.Add("GoodsMakerCd6");
            if (this.GoodsMakerCd7 != target.GoodsMakerCd7) resList.Add("GoodsMakerCd7");
            if (this.GoodsMakerCd8 != target.GoodsMakerCd8) resList.Add("GoodsMakerCd8");
            if (this.GoodsMakerCd9 != target.GoodsMakerCd9) resList.Add("GoodsMakerCd9");
            if (this.GoodsMakerCd10 != target.GoodsMakerCd10) resList.Add("GoodsMakerCd10");
            if (this.GoodsMakerCd11 != target.GoodsMakerCd11) resList.Add("GoodsMakerCd11");
            if (this.GoodsMakerCd12 != target.GoodsMakerCd12) resList.Add("GoodsMakerCd12");
            if (this.GoodsMakerCd13 != target.GoodsMakerCd13) resList.Add("GoodsMakerCd13");
            if (this.GoodsMakerCd14 != target.GoodsMakerCd14) resList.Add("GoodsMakerCd14");
            if (this.GoodsMakerCd15 != target.GoodsMakerCd15) resList.Add("GoodsMakerCd15");
            if (this.PartsOEMDiv != target.PartsOEMDiv) resList.Add("PartsOEMDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// オートバックス設定マスタ比較処理
        /// </summary>
        /// <param name="sAndESetting1">比較するSAndESettingクラスのインスタンス</param>
        /// <param name="sAndESetting2">比較するSAndESettingクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndESettingクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SAndESetting sAndESetting1, SAndESetting sAndESetting2)
        {
            ArrayList resList = new ArrayList();
            if (sAndESetting1.CreateDateTime != sAndESetting2.CreateDateTime) resList.Add("CreateDateTime");
            if (sAndESetting1.UpdateDateTime != sAndESetting2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (sAndESetting1.EnterpriseCode != sAndESetting2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (sAndESetting1.FileHeaderGuid != sAndESetting2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (sAndESetting1.UpdEmployeeCode != sAndESetting2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (sAndESetting1.UpdAssemblyId1 != sAndESetting2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (sAndESetting1.UpdAssemblyId2 != sAndESetting2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (sAndESetting1.LogicalDeleteCode != sAndESetting2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (sAndESetting1.SectionCode != sAndESetting2.SectionCode) resList.Add("SectionCode");
            if (sAndESetting1.SectionName != sAndESetting2.SectionName) resList.Add("SectionName");
            if (sAndESetting1.CustomerCode != sAndESetting2.CustomerCode) resList.Add("CustomerCode");
            if (sAndESetting1.CustomerName != sAndESetting2.CustomerName) resList.Add("CustomerName");
            if (sAndESetting1.AddresseeShopCd != sAndESetting2.AddresseeShopCd) resList.Add("AddresseeShopCd");
            if (sAndESetting1.SAndEMngCode != sAndESetting2.SAndEMngCode) resList.Add("SAndEMngCode");
            if (sAndESetting1.ExpenseDivCd != sAndESetting2.ExpenseDivCd) resList.Add("ExpenseDivCd");
            if (sAndESetting1.DirectSendingCd != sAndESetting2.DirectSendingCd) resList.Add("DirectSendingCd");
            if (sAndESetting1.AcptAnOrderDiv != sAndESetting2.AcptAnOrderDiv) resList.Add("AcptAnOrderDiv");
            if (sAndESetting1.DelivererCd != sAndESetting2.DelivererCd) resList.Add("DelivererCd");
            if (sAndESetting1.DelivererNm != sAndESetting2.DelivererNm) resList.Add("DelivererNm");
            if (sAndESetting1.DelivererAddress != sAndESetting2.DelivererAddress) resList.Add("DelivererAddress");
            if (sAndESetting1.DelivererPhoneNum != sAndESetting2.DelivererPhoneNum) resList.Add("DelivererPhoneNum");
            if (sAndESetting1.TradCompName != sAndESetting2.TradCompName) resList.Add("TradCompName");
            if (sAndESetting1.TradCompSectName != sAndESetting2.TradCompSectName) resList.Add("TradCompSectName");
            if (sAndESetting1.PureTradCompCd != sAndESetting2.PureTradCompCd) resList.Add("PureTradCompCd");
            if (sAndESetting1.PureTradCompRate != sAndESetting2.PureTradCompRate) resList.Add("PureTradCompRate");
            if (sAndESetting1.PriTradCompCd != sAndESetting2.PriTradCompCd) resList.Add("PriTradCompCd");
            if (sAndESetting1.PriTradCompRate != sAndESetting2.PriTradCompRate) resList.Add("PriTradCompRate");
            if (sAndESetting1.ABGoodsCode != sAndESetting2.ABGoodsCode) resList.Add("ABGoodsCode");
            if (sAndESetting1.CommentReservedDiv != sAndESetting2.CommentReservedDiv) resList.Add("CommentReservedDiv");
            if (sAndESetting1.GoodsMakerCd1 != sAndESetting2.GoodsMakerCd1) resList.Add("GoodsMakerCd1");
            if (sAndESetting1.GoodsMakerCd2 != sAndESetting2.GoodsMakerCd2) resList.Add("GoodsMakerCd2");
            if (sAndESetting1.GoodsMakerCd3 != sAndESetting2.GoodsMakerCd3) resList.Add("GoodsMakerCd3");
            if (sAndESetting1.GoodsMakerCd4 != sAndESetting2.GoodsMakerCd4) resList.Add("GoodsMakerCd4");
            if (sAndESetting1.GoodsMakerCd5 != sAndESetting2.GoodsMakerCd5) resList.Add("GoodsMakerCd5");
            if (sAndESetting1.GoodsMakerCd6 != sAndESetting2.GoodsMakerCd6) resList.Add("GoodsMakerCd6");
            if (sAndESetting1.GoodsMakerCd7 != sAndESetting2.GoodsMakerCd7) resList.Add("GoodsMakerCd7");
            if (sAndESetting1.GoodsMakerCd8 != sAndESetting2.GoodsMakerCd8) resList.Add("GoodsMakerCd8");
            if (sAndESetting1.GoodsMakerCd9 != sAndESetting2.GoodsMakerCd9) resList.Add("GoodsMakerCd9");
            if (sAndESetting1.GoodsMakerCd10 != sAndESetting2.GoodsMakerCd10) resList.Add("GoodsMakerCd10");
            if (sAndESetting1.GoodsMakerCd11 != sAndESetting2.GoodsMakerCd11) resList.Add("GoodsMakerCd11");
            if (sAndESetting1.GoodsMakerCd12 != sAndESetting2.GoodsMakerCd12) resList.Add("GoodsMakerCd12");
            if (sAndESetting1.GoodsMakerCd13 != sAndESetting2.GoodsMakerCd13) resList.Add("GoodsMakerCd13");
            if (sAndESetting1.GoodsMakerCd14 != sAndESetting2.GoodsMakerCd14) resList.Add("GoodsMakerCd14");
            if (sAndESetting1.GoodsMakerCd15 != sAndESetting2.GoodsMakerCd15) resList.Add("GoodsMakerCd15");
            if (sAndESetting1.PartsOEMDiv != sAndESetting2.PartsOEMDiv) resList.Add("PartsOEMDiv");
            if (sAndESetting1.EnterpriseName != sAndESetting2.EnterpriseName) resList.Add("EnterpriseName");
            if (sAndESetting1.UpdEmployeeName != sAndESetting2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
