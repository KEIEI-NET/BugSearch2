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
// 作 成 日  2009/08/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SAndESettingWork
    /// <summary>
    ///                      オートバックス設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   オートバックス設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/6/25</br>
    /// <br>Genarated Date   :   2009/08/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/7/17  杉村</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   商品メーカーコード１５</br>
    /// <br>                 :   ○キー変更</br>
    /// <br>                 :   3,10→3,9,10</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SAndESettingWork : IFileHeader
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

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

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

        /// <summary>拠点名称</summary>
        private string _sectionName = "";

        /// <summary>得意先略称</summary>
        private string _customerName = "";


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

        /// public propaty name  :  SectionName
        /// <summary>拠点名称プロパティ</summary>
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

        /// public propaty name  :  CustomerName
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }


        /// <summary>
        /// オートバックス設定ワークコンストラクタ
        /// </summary>
        /// <returns>SAndESettingWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndESettingWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SAndESettingWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SAndESettingWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SAndESettingWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SAndESettingWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndESettingWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SAndESettingWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SAndESettingWork || graph is ArrayList || graph is SAndESettingWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SAndESettingWork).FullName));

            if (graph != null && graph is SAndESettingWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SAndESettingWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SAndESettingWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SAndESettingWork[])graph).Length;
            }
            else if (graph is SAndESettingWork)
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
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //納品先店舗コード
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeShopCd
            //住電管理コード
            serInfo.MemberInfo.Add(typeof(string)); //SAndEMngCode
            //経費区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ExpenseDivCd
            //直送区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DirectSendingCd
            //受注区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOrderDiv
            //納品者コード
            serInfo.MemberInfo.Add(typeof(string)); //DelivererCd
            //納品者名
            serInfo.MemberInfo.Add(typeof(string)); //DelivererNm
            //納品者住所
            serInfo.MemberInfo.Add(typeof(string)); //DelivererAddress
            //納品者ＴＥＬ
            serInfo.MemberInfo.Add(typeof(string)); //DelivererPhoneNum
            //部品商名
            serInfo.MemberInfo.Add(typeof(string)); //TradCompName
            //部品商拠点名
            serInfo.MemberInfo.Add(typeof(string)); //TradCompSectName
            //部品商コード（純正）
            serInfo.MemberInfo.Add(typeof(string)); //PureTradCompCd
            //部品商仕切率（純正）
            serInfo.MemberInfo.Add(typeof(Double)); //PureTradCompRate
            //部品商コード（優良）
            serInfo.MemberInfo.Add(typeof(string)); //PriTradCompCd
            //部品商仕切率（優良）
            serInfo.MemberInfo.Add(typeof(Double)); //PriTradCompRate
            //AB商品コード
            serInfo.MemberInfo.Add(typeof(string)); //ABGoodsCode
            //コメント指定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CommentReservedDiv
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
            //部品ＯＥＭ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsOEMDiv
            //拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionName
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName


            serInfo.Serialize(writer, serInfo);
            if (graph is SAndESettingWork)
            {
                SAndESettingWork temp = (SAndESettingWork)graph;

                SetSAndESettingWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SAndESettingWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SAndESettingWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SAndESettingWork temp in lst)
                {
                    SetSAndESettingWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SAndESettingWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 45;

        /// <summary>
        ///  SAndESettingWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndESettingWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSAndESettingWork(System.IO.BinaryWriter writer, SAndESettingWork temp)
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
            //拠点コード
            writer.Write(temp.SectionCode);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //納品先店舗コード
            writer.Write(temp.AddresseeShopCd);
            //住電管理コード
            writer.Write(temp.SAndEMngCode);
            //経費区分
            writer.Write(temp.ExpenseDivCd);
            //直送区分
            writer.Write(temp.DirectSendingCd);
            //受注区分
            writer.Write(temp.AcptAnOrderDiv);
            //納品者コード
            writer.Write(temp.DelivererCd);
            //納品者名
            writer.Write(temp.DelivererNm);
            //納品者住所
            writer.Write(temp.DelivererAddress);
            //納品者ＴＥＬ
            writer.Write(temp.DelivererPhoneNum);
            //部品商名
            writer.Write(temp.TradCompName);
            //部品商拠点名
            writer.Write(temp.TradCompSectName);
            //部品商コード（純正）
            writer.Write(temp.PureTradCompCd);
            //部品商仕切率（純正）
            writer.Write(temp.PureTradCompRate);
            //部品商コード（優良）
            writer.Write(temp.PriTradCompCd);
            //部品商仕切率（優良）
            writer.Write(temp.PriTradCompRate);
            //AB商品コード
            writer.Write(temp.ABGoodsCode);
            //コメント指定区分
            writer.Write(temp.CommentReservedDiv);
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
            //部品ＯＥＭ区分
            writer.Write(temp.PartsOEMDiv);
            //拠点名称
            writer.Write(temp.SectionName);
            //得意先略称
            writer.Write(temp.CustomerName);

        }

        /// <summary>
        ///  SAndESettingWorkインスタンス取得
        /// </summary>
        /// <returns>SAndESettingWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndESettingWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SAndESettingWork GetSAndESettingWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SAndESettingWork temp = new SAndESettingWork();

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
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //納品先店舗コード
            temp.AddresseeShopCd = reader.ReadString();
            //住電管理コード
            temp.SAndEMngCode = reader.ReadString();
            //経費区分
            temp.ExpenseDivCd = reader.ReadInt32();
            //直送区分
            temp.DirectSendingCd = reader.ReadInt32();
            //受注区分
            temp.AcptAnOrderDiv = reader.ReadInt32();
            //納品者コード
            temp.DelivererCd = reader.ReadString();
            //納品者名
            temp.DelivererNm = reader.ReadString();
            //納品者住所
            temp.DelivererAddress = reader.ReadString();
            //納品者ＴＥＬ
            temp.DelivererPhoneNum = reader.ReadString();
            //部品商名
            temp.TradCompName = reader.ReadString();
            //部品商拠点名
            temp.TradCompSectName = reader.ReadString();
            //部品商コード（純正）
            temp.PureTradCompCd = reader.ReadString();
            //部品商仕切率（純正）
            temp.PureTradCompRate = reader.ReadDouble();
            //部品商コード（優良）
            temp.PriTradCompCd = reader.ReadString();
            //部品商仕切率（優良）
            temp.PriTradCompRate = reader.ReadDouble();
            //AB商品コード
            temp.ABGoodsCode = reader.ReadString();
            //コメント指定区分
            temp.CommentReservedDiv = reader.ReadInt32();
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
            //部品ＯＥＭ区分
            temp.PartsOEMDiv = reader.ReadInt32();
            //拠点名称
            temp.SectionName = reader.ReadString();
            //得意先略称
            temp.CustomerName = reader.ReadString();


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
        /// <returns>SAndESettingWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndESettingWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SAndESettingWork temp = GetSAndESettingWork(reader, serInfo);
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
                    retValue = (SAndESettingWork[])lst.ToArray(typeof(SAndESettingWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}


