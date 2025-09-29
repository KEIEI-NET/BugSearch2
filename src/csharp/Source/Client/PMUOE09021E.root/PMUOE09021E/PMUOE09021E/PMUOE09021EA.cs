//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : UOE発注先設定
// プログラム概要   : UOE発注先マスタヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2008/06/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/25  修正内容 : UOE発注先マスタ項目追加の為
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高川 悟
// 修 正 日  2012/09/10  修正内容 : BL管理ユーザーコード対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOESupplier
    /// <summary>
    ///                      UOE発注先マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE発注先マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/12</br>
    /// <br>Genarated Date   :   2008/06/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/06/25 照田 貴志　UOE発注先マスタ項目追加の為</br>
    /// </remarks>
    public class UOESupplier
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

        /// <summary>UOE発注先コード</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE発注先名称</summary>
        private string _uOESupplierName = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>電話番号</summary>
        private string _telNo = "";

        /// <summary>UOE端末コード</summary>
        private string _uOETerminalCd = "";

        /// <summary>UOEホストコード</summary>
        private string _uOEHostCode = "";

        /// <summary>UOE接続パスワード</summary>
        private string _uOEConnectPassword = "";

        /// <summary>UOE接続ユーザID</summary>
        private string _uOEConnectUserId = "";

        /// <summary>UOEID番号</summary>
        private string _uOEIDNum = "";

        /// <summary>通信アセンブリID</summary>
        private string _commAssemblyId = "";

        /// <summary>接続バージョン区分</summary>
        private Int32 _connectVersionDiv;

        /// <summary>UOE出庫拠点コード</summary>
        private string _uOEShipSectCd = "";

        /// <summary>UOE売上拠点コード</summary>
        private string _uOESalSectCd = "";

        /// <summary>UOE指定拠点コード</summary>
        private string _uOEReservSectCd = "";

        /// <summary>受信状況</summary>
        /// <remarks>受信有無区分</remarks>
        private Int32 _receiveCondition;

        /// <summary>代替品番区分</summary>
        private Int32 _substPartsNoDiv;

        /// <summary>品番印刷区分</summary>
        private Int32 _partsNoPrtCd;

        /// <summary>定価使用区分</summary>
        private Int32 _listPriceUseDiv;

        /// <summary>仕入データ受信区分</summary>
        private Int32 _stockSlipDtRecvDiv;

        /// <summary>チェックコード区分</summary>
        private Int32 _checkCodeDiv;

        /// <summary>業務区分</summary>
        private Int32 _businessCode;

        /// <summary>UOE指定拠点</summary>
        private string _uOEResvdSection = "";

        /// <summary>従業員コード</summary>
        /// <remarks>依頼者コード</remarks>
        private string _employeeCode = "";

        ///// <summary>納品区分</summary>
        //private Int32 _deliveredGoodsDiv;

        /// <summary>UOE納品区分</summary>
        private string _uOEDeliGoodsDiv = "";

        /// <summary>BO区分</summary>
        private string _boCode = "";

        /// <summary>UOE発注レート</summary>
        private string _uOEOrderRate = "";

        /// <summary>発注可能メーカーコード１</summary>
        private Int32 _enableOdrMakerCd1;

        /// <summary>発注可能メーカーコード２</summary>
        private Int32 _enableOdrMakerCd2;

        /// <summary>発注可能メーカーコード３</summary>
        private Int32 _enableOdrMakerCd3;

        /// <summary>発注可能メーカーコード４</summary>
        private Int32 _enableOdrMakerCd4;

        /// <summary>発注可能メーカーコード５</summary>
        private Int32 _enableOdrMakerCd5;

        /// <summary>発注可能メーカーコード６</summary>
        private Int32 _enableOdrMakerCd6;

        //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
        /// <summary>発注品番ハイフン区分１</summary>
        private Int32 _odrPrtsNoHyphenCd1;

        /// <summary>発注品番ハイフン区分２</summary>
        private Int32 _odrPrtsNoHyphenCd2;

        /// <summary>発注品番ハイフン区分３</summary>
        private Int32 _odrPrtsNoHyphenCd3;

        /// <summary>発注品番ハイフン区分４</summary>
        private Int32 _odrPrtsNoHyphenCd4;

        /// <summary>発注品番ハイフン区分５</summary>
        private Int32 _odrPrtsNoHyphenCd5;

        /// <summary>発注品番ハイフン区分６</summary>
        private Int32 _odrPrtsNoHyphenCd6;
        //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<

        /// <summary>機器番号</summary>
        private string _instrumentNo = "";

        /// <summary>UOEテストモード</summary>
        private string _uOETestMode = "";

        /// <summary>UOEアイテムコード</summary>
        private string _uOEItemCd = "";

        /// <summary>ホンダ担当拠点</summary>
        private string _hondaSectionCode = "";

        /// <summary>回答保存フォルダ</summary>
        private string _answerSaveFolder = "";

        /// <summary>マツダ自拠点コード</summary>
        private string _mazdaSectionCode = "";

        /// <summary>緊急区分</summary>
        private string _emergencyDiv = "";

        /// <summary>発注手配区分（ダイハツ）</summary>
        private Int32 _daihatsuOrdreDiv;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>業務区分名称</summary>
        private string _businessName = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        // ---ADD 2009/06/01 ------------------------------------->>>>>
        /// <summary>ログインタイムアウト</summary>
        private Int32 _loginTimeoutVal;
        /// <summary>UOE発注URL</summary>
        private string _uoeOrderUrl = "";
        /// <summary>UOE在庫確認URL</summary>
        private string _uoeStockCheckUrl = "";
        /// <summary>UOE強制終了URL</summary>
        private string _uoeForcedTermUrl = "";
        /// <summary>UOEログインURL</summary>
        private string _uoeLoginUrl = "";
        /// <summary>問合せ・発注種別</summary>
        private Int32 _inqOrdDivCd;
        /// <summary>e-PartsユーザID</summary>
        private string _ePartsUserId = "";
        /// <summary>e-Partsパスワード</summary>
        private string _ePartsPassWord = "";
        // ---ADD 2009/06/01 -------------------------------------<<<<<
        // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
        /// <summary>BL管理ユーザーコード</summary>
        private string _bLMngUserCode = "";
        // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<


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

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE発注先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  UOESupplierName
        /// <summary>UOE発注先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uOESupplierName; }
            set { _uOESupplierName = value; }
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

        /// public propaty name  :  TelNo
        /// <summary>電話番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TelNo
        {
            get { return _telNo; }
            set { _telNo = value; }
        }

        /// public propaty name  :  UOETerminalCd
        /// <summary>UOE端末コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE端末コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOETerminalCd
        {
            get { return _uOETerminalCd; }
            set { _uOETerminalCd = value; }
        }

        /// public propaty name  :  UOEHostCode
        /// <summary>UOEホストコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOEホストコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEHostCode
        {
            get { return _uOEHostCode; }
            set { _uOEHostCode = value; }
        }

        /// public propaty name  :  UOEConnectPassword
        /// <summary>UOE接続パスワードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE接続パスワードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEConnectPassword
        {
            get { return _uOEConnectPassword; }
            set { _uOEConnectPassword = value; }
        }

        /// public propaty name  :  UOEConnectUserId
        /// <summary>UOE接続ユーザIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE接続ユーザIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEConnectUserId
        {
            get { return _uOEConnectUserId; }
            set { _uOEConnectUserId = value; }
        }

        /// public propaty name  :  UOEIDNum
        /// <summary>UOEID番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOEID番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEIDNum
        {
            get { return _uOEIDNum; }
            set { _uOEIDNum = value; }
        }

        /// public propaty name  :  CommAssemblyId
        /// <summary>通信アセンブリIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   通信アセンブリIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CommAssemblyId
        {
            get { return _commAssemblyId; }
            set { _commAssemblyId = value; }
        }

        /// public propaty name  :  ConnectVersionDiv
        /// <summary>接続バージョン区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   接続バージョン区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConnectVersionDiv
        {
            get { return _connectVersionDiv; }
            set { _connectVersionDiv = value; }
        }

        /// public propaty name  :  UOEShipSectCd
        /// <summary>UOE出庫拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE出庫拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEShipSectCd
        {
            get { return _uOEShipSectCd; }
            set { _uOEShipSectCd = value; }
        }

        /// public propaty name  :  UOESalSectCd
        /// <summary>UOE売上拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE売上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESalSectCd
        {
            get { return _uOESalSectCd; }
            set { _uOESalSectCd = value; }
        }

        /// public propaty name  :  UOEReservSectCd
        /// <summary>UOE指定拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE指定拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEReservSectCd
        {
            get { return _uOEReservSectCd; }
            set { _uOEReservSectCd = value; }
        }

        /// public propaty name  :  ReceiveCondition
        /// <summary>受信状況プロパティ</summary>
        /// <value>受信有無区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信状況プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReceiveCondition
        {
            get { return _receiveCondition; }
            set { _receiveCondition = value; }
        }

        /// public propaty name  :  SubstPartsNoDiv
        /// <summary>代替品番区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   代替品番区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubstPartsNoDiv
        {
            get { return _substPartsNoDiv; }
            set { _substPartsNoDiv = value; }
        }

        /// public propaty name  :  PartsNoPrtCd
        /// <summary>品番印刷区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番印刷区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsNoPrtCd
        {
            get { return _partsNoPrtCd; }
            set { _partsNoPrtCd = value; }
        }

        /// public propaty name  :  ListPriceUseDiv
        /// <summary>定価使用区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価使用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ListPriceUseDiv
        {
            get { return _listPriceUseDiv; }
            set { _listPriceUseDiv = value; }
        }

        /// public propaty name  :  StockSlipDtRecvDiv
        /// <summary>仕入データ受信区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入データ受信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSlipDtRecvDiv
        {
            get { return _stockSlipDtRecvDiv; }
            set { _stockSlipDtRecvDiv = value; }
        }

        /// public propaty name  :  CheckCodeDiv
        /// <summary>チェックコード区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェックコード区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CheckCodeDiv
        {
            get { return _checkCodeDiv; }
            set { _checkCodeDiv = value; }
        }

        /// public propaty name  :  BusinessCode
        /// <summary>業務区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業務区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessCode
        {
            get { return _businessCode; }
            set { _businessCode = value; }
        }

        /// public propaty name  :  UOEResvdSection
        /// <summary>UOE指定拠点プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE指定拠点プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEResvdSection
        {
            get { return _uOEResvdSection; }
            set { _uOEResvdSection = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// <value>依頼者コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        ///// public propaty name  :  DeliveredGoodsDiv
        ///// <summary>納品区分プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   納品区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 DeliveredGoodsDiv
        //{
        //    get { return _deliveredGoodsDiv; }
        //    set { _deliveredGoodsDiv = value; }
        //}

        /// public propaty name  :  UOEDeliGoodsDiv
        /// <summary>UOE納品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEDeliGoodsDiv
        {
            get { return _uOEDeliGoodsDiv; }
            set { _uOEDeliGoodsDiv = value; }
        }

        /// public propaty name  :  BoCode
        /// <summary>BO区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BoCode
        {
            get { return _boCode; }
            set { _boCode = value; }
        }

        /// public propaty name  :  UOEOrderRate
        /// <summary>UOE発注レートプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注レートプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEOrderRate
        {
            get { return _uOEOrderRate; }
            set { _uOEOrderRate = value; }
        }

        /// public propaty name  :  EnableOdrMakerCd1
        /// <summary>発注可能メーカーコード１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注可能メーカーコード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnableOdrMakerCd1
        {
            get { return _enableOdrMakerCd1; }
            set { _enableOdrMakerCd1 = value; }
        }

        /// public propaty name  :  EnableOdrMakerCd2
        /// <summary>発注可能メーカーコード２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注可能メーカーコード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnableOdrMakerCd2
        {
            get { return _enableOdrMakerCd2; }
            set { _enableOdrMakerCd2 = value; }
        }

        /// public propaty name  :  EnableOdrMakerCd3
        /// <summary>発注可能メーカーコード３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注可能メーカーコード３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnableOdrMakerCd3
        {
            get { return _enableOdrMakerCd3; }
            set { _enableOdrMakerCd3 = value; }
        }

        /// public propaty name  :  EnableOdrMakerCd4
        /// <summary>発注可能メーカーコード４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注可能メーカーコード４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnableOdrMakerCd4
        {
            get { return _enableOdrMakerCd4; }
            set { _enableOdrMakerCd4 = value; }
        }

        /// public propaty name  :  EnableOdrMakerCd5
        /// <summary>発注可能メーカーコード５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注可能メーカーコード５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnableOdrMakerCd5
        {
            get { return _enableOdrMakerCd5; }
            set { _enableOdrMakerCd5 = value; }
        }

        /// public propaty name  :  EnableOdrMakerCd6
        /// <summary>発注可能メーカーコード６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注可能メーカーコード６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnableOdrMakerCd6
        {
            get { return _enableOdrMakerCd6; }
            set { _enableOdrMakerCd6 = value; }
        }
        //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
        /// public propaty name  :  OdrPrtsNoHyphenCd1
        /// <summary>発注品番ハイフン区分１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注品番ハイフン区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OdrPrtsNoHyphenCd1
        {
            get { return _odrPrtsNoHyphenCd1; }
            set { _odrPrtsNoHyphenCd1 = value; }
        }

        /// public propaty name  :  OdrPrtsNoHyphenCd2
        /// <summary>発注品番ハイフン区分２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注品番ハイフン区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OdrPrtsNoHyphenCd2
        {
            get { return _odrPrtsNoHyphenCd2; }
            set { _odrPrtsNoHyphenCd2 = value; }
        }

        /// public propaty name  :  OdrPrtsNoHyphenCd3
        /// <summary>発注品番ハイフン区分３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注品番ハイフン区分３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OdrPrtsNoHyphenCd3
        {
            get { return _odrPrtsNoHyphenCd3; }
            set { _odrPrtsNoHyphenCd3 = value; }
        }

        /// public propaty name  :  OdrPrtsNoHyphenCd4
        /// <summary>発注品番ハイフン区分４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注品番ハイフン区分４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OdrPrtsNoHyphenCd4
        {
            get { return _odrPrtsNoHyphenCd4; }
            set { _odrPrtsNoHyphenCd4 = value; }
        }

        /// public propaty name  :  OdrPrtsNoHyphenCd5
        /// <summary>発注品番ハイフン区分５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注品番ハイフン区分５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OdrPrtsNoHyphenCd5
        {
            get { return _odrPrtsNoHyphenCd5; }
            set { _odrPrtsNoHyphenCd5 = value; }
        }

        /// public propaty name  :  OdrPrtsNoHyphenCd6
        /// <summary>発注品番ハイフン区分６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注品番ハイフン区分６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OdrPrtsNoHyphenCd6
        {
            get { return _odrPrtsNoHyphenCd6; }
            set { _odrPrtsNoHyphenCd6 = value; }
        }
        //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
        /// public propaty name  :  instrumentNo
        /// <summary>機器番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   機器番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string instrumentNo
        {
            get { return _instrumentNo; }
            set { _instrumentNo = value; }
        }

        /// public propaty name  :  UOETestMode
        /// <summary>UOEテストモードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOEテストモードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOETestMode
        {
            get { return _uOETestMode; }
            set { _uOETestMode = value; }
        }

        /// public propaty name  :  UOEItemCd
        /// <summary>UOEアイテムコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOEアイテムコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEItemCd
        {
            get { return _uOEItemCd; }
            set { _uOEItemCd = value; }
        }

        /// public propaty name  :  HondaSectionCode
        /// <summary>ホンダ担当拠点プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ホンダ担当拠点プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HondaSectionCode
        {
            get { return _hondaSectionCode; }
            set { _hondaSectionCode = value; }
        }

        /// public propaty name  :  AnswerSaveFolder
        /// <summary>回答保存フォルダプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答保存フォルダプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerSaveFolder
        {
            get { return _answerSaveFolder; }
            set { _answerSaveFolder = value; }
        }

        /// public propaty name  :  MazdaSectionCode
        /// <summary>マツダ自拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   マツダ自拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MazdaSectionCode
        {
            get { return _mazdaSectionCode; }
            set { _mazdaSectionCode = value; }
        }

        /// public propaty name  :  EmergencyDiv
        /// <summary>緊急区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   緊急区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmergencyDiv
        {
            get { return _emergencyDiv; }
            set { _emergencyDiv = value; }
        }

        /// public propaty name  :  DaihatsuOrdreDiv
        /// <summary>発注手配区分（ダイハツ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注手配区分（ダイハツ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DaihatsuOrdreDiv
        {
            get { return _daihatsuOrdreDiv; }
            set { _daihatsuOrdreDiv = value; }
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

        /// public propaty name  :  BusinessName
        /// <summary>業務区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業務区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BusinessName
        {
            get { return _businessName; }
            set { _businessName = value; }
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

        // ---ADD 2009/06/01 -------------------------------------------------->>>>>
        /// public propaty name  :  LoginTimeoutVal
        /// <summary>ログインタイムアウトプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログインタイムアウトプロパティ</br>
        /// <br>Programer        :   照田 貴志</br>
        /// </remarks>
        public Int32 LoginTimeoutVal
        {
            get { return _loginTimeoutVal; }
            set { _loginTimeoutVal = value; }
        }

        /// public propaty name  :  UOEOrderUrl
        /// <summary>UOE発注URLプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注URLプロパティ</br>
        /// <br>Programer        :   照田 貴志</br>
        /// </remarks>
        public string UOEOrderUrl
        {
            get { return _uoeOrderUrl; }
            set { _uoeOrderUrl = value; }
        }

        /// public propaty name  :  UOEStockCheckUrl
        /// <summary>UOE在庫確認URLプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE在庫確認URLプロパティ</br>
        /// <br>Programer        :   照田 貴志</br>
        /// </remarks>
        public string UOEStockCheckUrl
        {
            get { return _uoeStockCheckUrl; }
            set { _uoeStockCheckUrl = value; }
        }

        /// public propaty name  :  UOEForcedTermUrl
        /// <summary>UOE強制終了URLプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE強制終了URLプロパティ</br>
        /// <br>Programer        :   照田 貴志</br>
        /// </remarks>
        public string UOEForcedTermUrl
        {
            get { return _uoeForcedTermUrl; }
            set { _uoeForcedTermUrl = value; }
        }

        /// public propaty name  :  UOELoginUrl
        /// <summary>UOEログインURLプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOEログインURLプロパティ</br>
        /// <br>Programer        :   照田 貴志</br>
        /// </remarks>
        public string UOELoginUrl
        {
            get { return _uoeLoginUrl; }
            set { _uoeLoginUrl = value; }
        }

        /// public propaty name  :  InqOrdDivCd
        /// <summary>問合せ・発注種別プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ・発注種別プロパティ</br>
        /// <br>Programer        :   照田 貴志</br>
        /// </remarks>
        public Int32 InqOrdDivCd
        {
            get { return _inqOrdDivCd; }
            set { _inqOrdDivCd = value; }
        }

        /// public propaty name  :  EPartsUserId
        /// <summary>e-PartsユーザIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   e-PartsユーザIDプロパティ</br>
        /// <br>Programer        :   照田 貴志</br>
        /// </remarks>
        public string EPartsUserId
        {
            get { return _ePartsUserId; }
            set { _ePartsUserId = value; }
        }

        /// public propaty name  :  EPartsPassWord
        /// <summary>e-Partsパスワードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   e-Partsパスワードプロパティ</br>
        /// <br>Programer        :   照田 貴志</br>
        /// </remarks>
        public string EPartsPassWord
        {
            get { return _ePartsPassWord; }
            set { _ePartsPassWord = value; }
        }
        // ---ADD 2009/06/01 --------------------------------------------------<<<<<
        // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  BLMngUserCode
        /// <summary>BL管理ユーザーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL管理ユーザーコードプロパティ</br>
        /// <br>Programer        :   高川 悟</br>
        /// </remarks>
        public string BLMngUserCode
        {
            get { return _bLMngUserCode; }
            set { _bLMngUserCode = value; }
        }
        // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// UOE発注先マスタコンストラクタ
        /// </summary>
        /// <returns>UOESupplierクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESupplierクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOESupplier()
        {
        }

        /// <summary>
        /// UOE発注先マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <param name="uOESupplierName">UOE発注先名称</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="telNo">電話番号</param>
        /// <param name="uOETerminalCd">UOE端末コード</param>
        /// <param name="uOEHostCode">UOEホストコード</param>
        /// <param name="uOEConnectPassword">UOE接続パスワード</param>
        /// <param name="uOEConnectUserId">UOE接続ユーザID</param>
        /// <param name="uOEIDNum">UOEID番号</param>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <param name="connectVersionDiv">接続バージョン区分</param>
        /// <param name="uOEShipSectCd">UOE出庫拠点コード</param>
        /// <param name="uOESalSectCd">UOE売上拠点コード</param>
        /// <param name="uOEReservSectCd">UOE指定拠点コード</param>
        /// <param name="receiveCondition">受信状況(受信有無区分)</param>
        /// <param name="substPartsNoDiv">代替品番区分</param>
        /// <param name="partsNoPrtCd">品番印刷区分</param>
        /// <param name="listPriceUseDiv">定価使用区分</param>
        /// <param name="stockSlipDtRecvDiv">仕入データ受信区分</param>
        /// <param name="checkCodeDiv">チェックコード区分</param>
        /// <param name="businessCode">業務区分</param>
        /// <param name="uOEResvdSection">UOE指定拠点</param>
        /// <param name="employeeCode">従業員コード(依頼者コード)</param>
        ///// <param name="deliveredGoodsDiv">納品区分</param>
        /// <param name="uOEDeliGoodsDiv">UOE納品区分</param>
        /// <param name="boCode">BO区分</param>
        /// <param name="uOEOrderRate">UOE発注レート</param>
        /// <param name="enableOdrMakerCd1">発注可能メーカーコード１</param>
        /// <param name="enableOdrMakerCd2">発注可能メーカーコード２</param>
        /// <param name="enableOdrMakerCd3">発注可能メーカーコード３</param>
        /// <param name="enableOdrMakerCd4">発注可能メーカーコード４</param>
        /// <param name="enableOdrMakerCd5">発注可能メーカーコード５</param>
        /// <param name="enableOdrMakerCd6">発注可能メーカーコード６</param>
        /// <param name="odrPrtsNoHyphenCd1">発注品番ハイフン区分１</param>
        /// <param name="odrPrtsNoHyphenCd1">発注品番ハイフン区分２</param>
        /// <param name="odrPrtsNoHyphenCd1">発注品番ハイフン区分３</param>
        /// <param name="odrPrtsNoHyphenCd1">発注品番ハイフン区分４</param>
        /// <param name="odrPrtsNoHyphenCd1">発注品番ハイフン区分５</param>
        /// <param name="odrPrtsNoHyphenCd1">発注品番ハイフン区分６</param>
        /// <param name="instrumentNo">機器番号</param>
        /// <param name="uOETestMode">UOEテストモード</param>
        /// <param name="uOEItemCd">UOEアイテムコード</param>
        /// <param name="hondaSectionCode">ホンダ担当拠点</param>
        /// <param name="answerSaveFolder">回答保存フォルダ</param>
        /// <param name="mazdaSectionCode">マツダ自拠点コード</param>
        /// <param name="emergencyDiv">緊急区分</param>
        /// <param name="daihatsuOrdreDiv">発注手配区分（ダイハツ）</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="businessName">業務区分名称</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="loginTimeoutVal">ログインタイムアウト</param>
        /// <param name="uoeOrderUrl">UOE発注URL</param>
        /// <param name="uoeStockCheckUrl">UOE在庫確認URL</param>
        /// <param name="uoeForcedTermUrl">UOE強制終了URL</param>
        /// <param name="uoeLoginUrl">UOEログインURL</param>
        /// <param name="inqOrdDivCd">問合せ・発注種別</param>
        /// <param name="ePartsUserId">e-PartsユーザID</param>
        /// <param name="ePartsPassWord">e-Partsパスワード</param>
        // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
        /// <param name="bLMngUserCode">BL管理ユーザーコード</param>
        // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
        /// <returns>UOESupplierクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESupplierクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public UOESupplier(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 uOESupplierCd, string uOESupplierName, Int32 goodsMakerCd, string telNo, string uOETerminalCd, string uOEHostCode, string uOEConnectPassword, string uOEConnectUserId, string uOEIDNum, string commAssemblyId, Int32 connectVersionDiv, string uOEShipSectCd, string uOESalSectCd, string uOEReservSectCd, Int32 receiveCondition, Int32 substPartsNoDiv, Int32 partsNoPrtCd, Int32 listPriceUseDiv, Int32 stockSlipDtRecvDiv, Int32 checkCodeDiv, Int32 businessCode, string uOEResvdSection, string employeeCode, string uOEDeliGoodsDiv, string boCode, string uOEOrderRate, Int32 enableOdrMakerCd1, Int32 enableOdrMakerCd2, Int32 enableOdrMakerCd3, Int32 enableOdrMakerCd4, Int32 enableOdrMakerCd5, Int32 enableOdrMakerCd6, string instrumentNo, string uOETestMode, string uOEItemCd, string hondaSectionCode, string answerSaveFolder, string mazdaSectionCode, string emergencyDiv, Int32 daihatsuOrdreDiv, string enterpriseName, string updEmployeeName, string businessName, string sectionCode, Int32 supplierCd)      //DEL 2009/06/01
        //public UOESupplier(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 uOESupplierCd, string uOESupplierName, Int32 goodsMakerCd, string telNo, string uOETerminalCd, string uOEHostCode, string uOEConnectPassword, string uOEConnectUserId, string uOEIDNum, string commAssemblyId, Int32 connectVersionDiv, string uOEShipSectCd, string uOESalSectCd, string uOEReservSectCd, Int32 receiveCondition, Int32 substPartsNoDiv, Int32 partsNoPrtCd, Int32 listPriceUseDiv, Int32 stockSlipDtRecvDiv, Int32 checkCodeDiv, Int32 businessCode, string uOEResvdSection, string employeeCode, string uOEDeliGoodsDiv, string boCode, string uOEOrderRate, Int32 enableOdrMakerCd1, Int32 enableOdrMakerCd2, Int32 enableOdrMakerCd3, Int32 enableOdrMakerCd4, Int32 enableOdrMakerCd5, Int32 enableOdrMakerCd6, string instrumentNo, string uOETestMode, string uOEItemCd, string hondaSectionCode, string answerSaveFolder, string mazdaSectionCode, string emergencyDiv, Int32 daihatsuOrdreDiv, string enterpriseName, string updEmployeeName, string businessName, string sectionCode, Int32 supplierCd, Int32 loginTimeoutVal, string uoeOrderUrl, string uoeStockCheckUrl, string uoeForcedTermUrl, string uoeLoginUrl, Int32 inqOrdDivCd, string ePartsUserId, string ePartsPassWord)        //ADD 2009/06/01 // DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
        // 2012/09/10 UPD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
        //public UOESupplier(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 uOESupplierCd, string uOESupplierName, Int32 goodsMakerCd, string telNo, string uOETerminalCd, string uOEHostCode, string uOEConnectPassword, string uOEConnectUserId, string uOEIDNum, string commAssemblyId, Int32 connectVersionDiv, string uOEShipSectCd, string uOESalSectCd, string uOEReservSectCd, Int32 receiveCondition, Int32 substPartsNoDiv, Int32 partsNoPrtCd, Int32 listPriceUseDiv, Int32 stockSlipDtRecvDiv, Int32 checkCodeDiv, Int32 businessCode, string uOEResvdSection, string employeeCode, string uOEDeliGoodsDiv, string boCode, string uOEOrderRate, Int32 enableOdrMakerCd1, Int32 enableOdrMakerCd2, Int32 enableOdrMakerCd3, Int32 enableOdrMakerCd4, Int32 enableOdrMakerCd5, Int32 enableOdrMakerCd6, Int32 odrPrtsNoHyphenCd1, Int32 odrPrtsNoHyphenCd2, Int32 odrPrtsNoHyphenCd3, Int32 odrPrtsNoHyphenCd4, Int32 odrPrtsNoHyphenCd5, Int32 odrPrtsNoHyphenCd6, string instrumentNo, string uOETestMode, string uOEItemCd, string hondaSectionCode, string answerSaveFolder, string mazdaSectionCode, string emergencyDiv, Int32 daihatsuOrdreDiv, string enterpriseName, string updEmployeeName, string businessName, string sectionCode, Int32 supplierCd, Int32 loginTimeoutVal, string uoeOrderUrl, string uoeStockCheckUrl, string uoeForcedTermUrl, string uoeLoginUrl, Int32 inqOrdDivCd, string ePartsUserId, string ePartsPassWord)// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
        public UOESupplier(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 uOESupplierCd, string uOESupplierName, Int32 goodsMakerCd, string telNo, string uOETerminalCd, string uOEHostCode, string uOEConnectPassword, string uOEConnectUserId, string uOEIDNum, string commAssemblyId, Int32 connectVersionDiv, string uOEShipSectCd, string uOESalSectCd, string uOEReservSectCd, Int32 receiveCondition, Int32 substPartsNoDiv, Int32 partsNoPrtCd, Int32 listPriceUseDiv, Int32 stockSlipDtRecvDiv, Int32 checkCodeDiv, Int32 businessCode, string uOEResvdSection, string employeeCode, string uOEDeliGoodsDiv, string boCode, string uOEOrderRate, Int32 enableOdrMakerCd1, Int32 enableOdrMakerCd2, Int32 enableOdrMakerCd3, Int32 enableOdrMakerCd4, Int32 enableOdrMakerCd5, Int32 enableOdrMakerCd6, Int32 odrPrtsNoHyphenCd1, Int32 odrPrtsNoHyphenCd2, Int32 odrPrtsNoHyphenCd3, Int32 odrPrtsNoHyphenCd4, Int32 odrPrtsNoHyphenCd5, Int32 odrPrtsNoHyphenCd6, string instrumentNo, string uOETestMode, string uOEItemCd, string hondaSectionCode, string answerSaveFolder, string mazdaSectionCode, string emergencyDiv, Int32 daihatsuOrdreDiv, string enterpriseName, string updEmployeeName, string businessName, string sectionCode, Int32 supplierCd, Int32 loginTimeoutVal, string uoeOrderUrl, string uoeStockCheckUrl, string uoeForcedTermUrl, string uoeLoginUrl, Int32 inqOrdDivCd, string ePartsUserId, string ePartsPassWord, string bLMngUserCode)
        // 2012/09/10 UPD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._uOESupplierCd = uOESupplierCd;
            this._uOESupplierName = uOESupplierName;
            this._goodsMakerCd = goodsMakerCd;
            this._telNo = telNo;
            this._uOETerminalCd = uOETerminalCd;
            this._uOEHostCode = uOEHostCode;
            this._uOEConnectPassword = uOEConnectPassword;
            this._uOEConnectUserId = uOEConnectUserId;
            this._uOEIDNum = uOEIDNum;
            this._commAssemblyId = commAssemblyId;
            this._connectVersionDiv = connectVersionDiv;
            this._uOEShipSectCd = uOEShipSectCd;
            this._uOESalSectCd = uOESalSectCd;
            this._uOEReservSectCd = uOEReservSectCd;
            this._receiveCondition = receiveCondition;
            this._substPartsNoDiv = substPartsNoDiv;
            this._partsNoPrtCd = partsNoPrtCd;
            this._listPriceUseDiv = listPriceUseDiv;
            this._stockSlipDtRecvDiv = stockSlipDtRecvDiv;
            this._checkCodeDiv = checkCodeDiv;
            this._businessCode = businessCode;
            this._uOEResvdSection = uOEResvdSection;
            this._employeeCode = employeeCode;
            //this._deliveredGoodsDiv = deliveredGoodsDiv;
            this._uOEDeliGoodsDiv = uOEDeliGoodsDiv;
            this._boCode = boCode;
            this._uOEOrderRate = uOEOrderRate;
            this._enableOdrMakerCd1 = enableOdrMakerCd1;
            this._enableOdrMakerCd2 = enableOdrMakerCd2;
            this._enableOdrMakerCd3 = enableOdrMakerCd3;
            this._enableOdrMakerCd4 = enableOdrMakerCd4;
            this._enableOdrMakerCd5 = enableOdrMakerCd5;
            this._enableOdrMakerCd6 = enableOdrMakerCd6;
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
            this._odrPrtsNoHyphenCd1 = odrPrtsNoHyphenCd1;
            this._odrPrtsNoHyphenCd2 = odrPrtsNoHyphenCd2;
            this._odrPrtsNoHyphenCd3 = odrPrtsNoHyphenCd3;
            this._odrPrtsNoHyphenCd4 = odrPrtsNoHyphenCd4;
            this._odrPrtsNoHyphenCd5 = odrPrtsNoHyphenCd5;
            this._odrPrtsNoHyphenCd6 = odrPrtsNoHyphenCd6;
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
            this._instrumentNo = instrumentNo;
            this._uOETestMode = uOETestMode;
            this._uOEItemCd = uOEItemCd;
            this._hondaSectionCode = hondaSectionCode;
            this._answerSaveFolder = answerSaveFolder;
            this._mazdaSectionCode = mazdaSectionCode;
            this._emergencyDiv = emergencyDiv;
            this._daihatsuOrdreDiv = daihatsuOrdreDiv;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._businessName = businessName;
            this._sectionCode = sectionCode;
            this._supplierCd = supplierCd;
            // ---ADD 2009/06/01 --------------------->>>>>
            this._loginTimeoutVal = loginTimeoutVal;
            this._uoeOrderUrl = uoeOrderUrl;
            this._uoeStockCheckUrl = uoeStockCheckUrl;
            this._uoeForcedTermUrl = uoeForcedTermUrl;
            this._uoeLoginUrl = uoeLoginUrl;
            this._inqOrdDivCd = inqOrdDivCd;
            this._ePartsUserId = ePartsUserId;
            this._ePartsPassWord = ePartsPassWord;
            // ---ADD 2009/06/01 ---------------------<<<<<
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
            this._bLMngUserCode = bLMngUserCode;
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// UOE発注先マスタ複製処理
        /// </summary>
        /// <returns>UOESupplierクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいUOESupplierクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOESupplier Clone()
        {
            //return new UOESupplier(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._uOESupplierCd, this._uOESupplierName, this._goodsMakerCd, this._telNo, this._uOETerminalCd, this._uOEHostCode, this._uOEConnectPassword, this._uOEConnectUserId, this._uOEIDNum, this._commAssemblyId, this._connectVersionDiv, this._uOEShipSectCd, this._uOESalSectCd, this._uOEReservSectCd, this._receiveCondition, this._substPartsNoDiv, this._partsNoPrtCd, this._listPriceUseDiv, this._stockSlipDtRecvDiv, this._checkCodeDiv, this._businessCode, this._uOEResvdSection, this._employeeCode, this._uOEDeliGoodsDiv, this._boCode, this._uOEOrderRate, this._enableOdrMakerCd1, this._enableOdrMakerCd2, this._enableOdrMakerCd3, this._enableOdrMakerCd4, this._enableOdrMakerCd5, this._enableOdrMakerCd6, this._instrumentNo, this._uOETestMode, this._uOEItemCd, this._hondaSectionCode, this._answerSaveFolder, this._mazdaSectionCode, this._emergencyDiv, this._daihatsuOrdreDiv, this._enterpriseName, this._updEmployeeName, this._businessName, this._sectionCode, this._supplierCd);     //DEL 2009/06/01
            //return new UOESupplier(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._uOESupplierCd, this._uOESupplierName, this._goodsMakerCd, this._telNo, this._uOETerminalCd, this._uOEHostCode, this._uOEConnectPassword, this._uOEConnectUserId, this._uOEIDNum, this._commAssemblyId, this._connectVersionDiv, this._uOEShipSectCd, this._uOESalSectCd, this._uOEReservSectCd, this._receiveCondition, this._substPartsNoDiv, this._partsNoPrtCd, this._listPriceUseDiv, this._stockSlipDtRecvDiv, this._checkCodeDiv, this._businessCode, this._uOEResvdSection, this._employeeCode, this._uOEDeliGoodsDiv, this._boCode, this._uOEOrderRate, this._enableOdrMakerCd1, this._enableOdrMakerCd2, this._enableOdrMakerCd3, this._enableOdrMakerCd4, this._enableOdrMakerCd5, this._enableOdrMakerCd6, this._instrumentNo, this._uOETestMode, this._uOEItemCd, this._hondaSectionCode, this._answerSaveFolder, this._mazdaSectionCode, this._emergencyDiv, this._daihatsuOrdreDiv, this._enterpriseName, this._updEmployeeName, this._businessName, this._sectionCode, this._supplierCd,this._loginTimeoutVal,this._uoeOrderUrl,this.UOEStockCheckUrl,this.UOEForcedTermUrl,this.UOELoginUrl,this.InqOrdDivCd,this.EPartsUserId,this.EPartsPassWord);       //ADD 2009/06/01// DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
            // 2012/09/10 UPD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
            //return new UOESupplier(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._uOESupplierCd, this._uOESupplierName, this._goodsMakerCd, this._telNo, this._uOETerminalCd, this._uOEHostCode, this._uOEConnectPassword, this._uOEConnectUserId, this._uOEIDNum, this._commAssemblyId, this._connectVersionDiv, this._uOEShipSectCd, this._uOESalSectCd, this._uOEReservSectCd, this._receiveCondition, this._substPartsNoDiv, this._partsNoPrtCd, this._listPriceUseDiv, this._stockSlipDtRecvDiv, this._checkCodeDiv, this._businessCode, this._uOEResvdSection, this._employeeCode, this._uOEDeliGoodsDiv, this._boCode, this._uOEOrderRate, this._enableOdrMakerCd1, this._enableOdrMakerCd2, this._enableOdrMakerCd3, this._enableOdrMakerCd4, this._enableOdrMakerCd5, this._enableOdrMakerCd6, this._odrPrtsNoHyphenCd1, this._odrPrtsNoHyphenCd2, this._odrPrtsNoHyphenCd3, this._odrPrtsNoHyphenCd4, this._odrPrtsNoHyphenCd5, this._odrPrtsNoHyphenCd6, this._instrumentNo, this._uOETestMode, this._uOEItemCd, this._hondaSectionCode, this._answerSaveFolder, this._mazdaSectionCode, this._emergencyDiv, this._daihatsuOrdreDiv, this._enterpriseName, this._updEmployeeName, this._businessName, this._sectionCode, this._supplierCd, this._loginTimeoutVal, this._uoeOrderUrl, this.UOEStockCheckUrl, this.UOEForcedTermUrl, this.UOELoginUrl, this.InqOrdDivCd, this.EPartsUserId, this.EPartsPassWord);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
            return new UOESupplier(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._uOESupplierCd, this._uOESupplierName, this._goodsMakerCd, this._telNo, this._uOETerminalCd, this._uOEHostCode, this._uOEConnectPassword, this._uOEConnectUserId, this._uOEIDNum, this._commAssemblyId, this._connectVersionDiv, this._uOEShipSectCd, this._uOESalSectCd, this._uOEReservSectCd, this._receiveCondition, this._substPartsNoDiv, this._partsNoPrtCd, this._listPriceUseDiv, this._stockSlipDtRecvDiv, this._checkCodeDiv, this._businessCode, this._uOEResvdSection, this._employeeCode, this._uOEDeliGoodsDiv, this._boCode, this._uOEOrderRate, this._enableOdrMakerCd1, this._enableOdrMakerCd2, this._enableOdrMakerCd3, this._enableOdrMakerCd4, this._enableOdrMakerCd5, this._enableOdrMakerCd6, this._odrPrtsNoHyphenCd1, this._odrPrtsNoHyphenCd2, this._odrPrtsNoHyphenCd3, this._odrPrtsNoHyphenCd4, this._odrPrtsNoHyphenCd5, this._odrPrtsNoHyphenCd6, this._instrumentNo, this._uOETestMode, this._uOEItemCd, this._hondaSectionCode, this._answerSaveFolder, this._mazdaSectionCode, this._emergencyDiv, this._daihatsuOrdreDiv, this._enterpriseName, this._updEmployeeName, this._businessName, this._sectionCode, this._supplierCd, this._loginTimeoutVal, this._uoeOrderUrl, this.UOEStockCheckUrl, this.UOEForcedTermUrl, this.UOELoginUrl, this.InqOrdDivCd, this.EPartsUserId, this.EPartsPassWord, this.BLMngUserCode);
            // 2012/09/10 UPD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// UOE発注先マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のUOESupplierクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESupplierクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(UOESupplier target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.UOESupplierName == target.UOESupplierName)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.TelNo == target.TelNo)
                 && (this.UOETerminalCd == target.UOETerminalCd)
                 && (this.UOEHostCode == target.UOEHostCode)
                 && (this.UOEConnectPassword == target.UOEConnectPassword)
                 && (this.UOEConnectUserId == target.UOEConnectUserId)
                 && (this.UOEIDNum == target.UOEIDNum)
                 && (this.CommAssemblyId == target.CommAssemblyId)
                 && (this.ConnectVersionDiv == target.ConnectVersionDiv)
                 && (this.UOEShipSectCd == target.UOEShipSectCd)
                 && (this.UOESalSectCd == target.UOESalSectCd)
                 && (this.UOEReservSectCd == target.UOEReservSectCd)
                 && (this.ReceiveCondition == target.ReceiveCondition)
                 && (this.SubstPartsNoDiv == target.SubstPartsNoDiv)
                 && (this.PartsNoPrtCd == target.PartsNoPrtCd)
                 && (this.ListPriceUseDiv == target.ListPriceUseDiv)
                 && (this.StockSlipDtRecvDiv == target.StockSlipDtRecvDiv)
                 && (this.CheckCodeDiv == target.CheckCodeDiv)
                 && (this.BusinessCode == target.BusinessCode)
                 && (this.UOEResvdSection == target.UOEResvdSection)
                 && (this.EmployeeCode == target.EmployeeCode)
                 //&& (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
                 && (this.UOEDeliGoodsDiv == target.UOEDeliGoodsDiv)
                 && (this.BoCode == target.BoCode)
                 && (this.UOEOrderRate == target.UOEOrderRate)
                 && (this.EnableOdrMakerCd1 == target.EnableOdrMakerCd1)
                 && (this.EnableOdrMakerCd2 == target.EnableOdrMakerCd2)
                 && (this.EnableOdrMakerCd3 == target.EnableOdrMakerCd3)
                 && (this.EnableOdrMakerCd4 == target.EnableOdrMakerCd4)
                 && (this.EnableOdrMakerCd5 == target.EnableOdrMakerCd5)
                 && (this.EnableOdrMakerCd6 == target.EnableOdrMakerCd6)
                 //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                 && (this.OdrPrtsNoHyphenCd1 == target.OdrPrtsNoHyphenCd1)
                 && (this.OdrPrtsNoHyphenCd2 == target.OdrPrtsNoHyphenCd2)
                 && (this.OdrPrtsNoHyphenCd3 == target.OdrPrtsNoHyphenCd3)
                 && (this.OdrPrtsNoHyphenCd4 == target.OdrPrtsNoHyphenCd4)
                 && (this.OdrPrtsNoHyphenCd5 == target.OdrPrtsNoHyphenCd5)
                 && (this.OdrPrtsNoHyphenCd6 == target.OdrPrtsNoHyphenCd6)
                 //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
                 && (this.instrumentNo == target.instrumentNo)
                 && (this.UOETestMode == target.UOETestMode)
                 && (this.UOEItemCd == target.UOEItemCd)
                 && (this.HondaSectionCode == target.HondaSectionCode)
                 && (this.AnswerSaveFolder == target.AnswerSaveFolder)
                 && (this.MazdaSectionCode == target.MazdaSectionCode)
                 && (this.EmergencyDiv == target.EmergencyDiv)
                 && (this.DaihatsuOrdreDiv == target.DaihatsuOrdreDiv)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BusinessName == target.BusinessName)
                 && (this.SectionCode == target.SectionCode)
                 //&& (this.SupplierCd == target.SupplierCd));  //DEL 2009/06/01
                // ---ADD 2009/06/01 ---------------------------------->>>>>
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.LoginTimeoutVal == target.LoginTimeoutVal)
                 && (this.UOEOrderUrl == target.UOEOrderUrl)
                 && (this.UOEStockCheckUrl == target.UOEStockCheckUrl)
                 && (this.UOEForcedTermUrl == target.UOEForcedTermUrl)
                 && (this.UOELoginUrl == target.UOELoginUrl)
                 && (this.InqOrdDivCd == target.InqOrdDivCd)
                 && (this.EPartsUserId == target.EPartsUserId)
                // 2012/09/10 UPD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                 //&& (this.EPartsPassWord == target.EPartsPassWord));
                 && (this.EPartsPassWord == target.EPartsPassWord)
                // 2012/09/10 UPD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
                // ---ADD 2009/06/01 ----------------------------------<<<<<
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                 && (this.BLMngUserCode == target.BLMngUserCode));
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
        }


        /// <summary>
        /// UOE発注先マスタ比較処理
        /// </summary>
        /// <param name="uOESupplier1">
        ///                    比較するUOESupplierクラスのインスタンス
        /// </param>
        /// <param name="uOESupplier2">比較するUOESupplierクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESupplierクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(UOESupplier uOESupplier1, UOESupplier uOESupplier2)
        {
            return ((uOESupplier1.CreateDateTime == uOESupplier2.CreateDateTime)
                 && (uOESupplier1.UpdateDateTime == uOESupplier2.UpdateDateTime)
                 && (uOESupplier1.EnterpriseCode == uOESupplier2.EnterpriseCode)
                 && (uOESupplier1.FileHeaderGuid == uOESupplier2.FileHeaderGuid)
                 && (uOESupplier1.UpdEmployeeCode == uOESupplier2.UpdEmployeeCode)
                 && (uOESupplier1.UpdAssemblyId1 == uOESupplier2.UpdAssemblyId1)
                 && (uOESupplier1.UpdAssemblyId2 == uOESupplier2.UpdAssemblyId2)
                 && (uOESupplier1.LogicalDeleteCode == uOESupplier2.LogicalDeleteCode)
                 && (uOESupplier1.UOESupplierCd == uOESupplier2.UOESupplierCd)
                 && (uOESupplier1.UOESupplierName == uOESupplier2.UOESupplierName)
                 && (uOESupplier1.GoodsMakerCd == uOESupplier2.GoodsMakerCd)
                 && (uOESupplier1.TelNo == uOESupplier2.TelNo)
                 && (uOESupplier1.UOETerminalCd == uOESupplier2.UOETerminalCd)
                 && (uOESupplier1.UOEHostCode == uOESupplier2.UOEHostCode)
                 && (uOESupplier1.UOEConnectPassword == uOESupplier2.UOEConnectPassword)
                 && (uOESupplier1.UOEConnectUserId == uOESupplier2.UOEConnectUserId)
                 && (uOESupplier1.UOEIDNum == uOESupplier2.UOEIDNum)
                 && (uOESupplier1.CommAssemblyId == uOESupplier2.CommAssemblyId)
                 && (uOESupplier1.ConnectVersionDiv == uOESupplier2.ConnectVersionDiv)
                 && (uOESupplier1.UOEShipSectCd == uOESupplier2.UOEShipSectCd)
                 && (uOESupplier1.UOESalSectCd == uOESupplier2.UOESalSectCd)
                 && (uOESupplier1.UOEReservSectCd == uOESupplier2.UOEReservSectCd)
                 && (uOESupplier1.ReceiveCondition == uOESupplier2.ReceiveCondition)
                 && (uOESupplier1.SubstPartsNoDiv == uOESupplier2.SubstPartsNoDiv)
                 && (uOESupplier1.PartsNoPrtCd == uOESupplier2.PartsNoPrtCd)
                 && (uOESupplier1.ListPriceUseDiv == uOESupplier2.ListPriceUseDiv)
                 && (uOESupplier1.StockSlipDtRecvDiv == uOESupplier2.StockSlipDtRecvDiv)
                 && (uOESupplier1.CheckCodeDiv == uOESupplier2.CheckCodeDiv)
                 && (uOESupplier1.BusinessCode == uOESupplier2.BusinessCode)
                 && (uOESupplier1.UOEResvdSection == uOESupplier2.UOEResvdSection)
                 && (uOESupplier1.EmployeeCode == uOESupplier2.EmployeeCode)
                 //&& (uOESupplier1.DeliveredGoodsDiv == uOESupplier2.DeliveredGoodsDiv)
                 && (uOESupplier1.UOEDeliGoodsDiv == uOESupplier2.UOEDeliGoodsDiv)
                 && (uOESupplier1.BoCode == uOESupplier2.BoCode)
                 && (uOESupplier1.UOEOrderRate == uOESupplier2.UOEOrderRate)
                 && (uOESupplier1.EnableOdrMakerCd1 == uOESupplier2.EnableOdrMakerCd1)
                 && (uOESupplier1.EnableOdrMakerCd2 == uOESupplier2.EnableOdrMakerCd2)
                 && (uOESupplier1.EnableOdrMakerCd3 == uOESupplier2.EnableOdrMakerCd3)
                 && (uOESupplier1.EnableOdrMakerCd4 == uOESupplier2.EnableOdrMakerCd4)
                 && (uOESupplier1.EnableOdrMakerCd5 == uOESupplier2.EnableOdrMakerCd5)
                 && (uOESupplier1.EnableOdrMakerCd6 == uOESupplier2.EnableOdrMakerCd6)
                //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                 && (uOESupplier1.OdrPrtsNoHyphenCd1 == uOESupplier2.OdrPrtsNoHyphenCd1)
                 && (uOESupplier1.OdrPrtsNoHyphenCd2 == uOESupplier2.OdrPrtsNoHyphenCd2)
                 && (uOESupplier1.OdrPrtsNoHyphenCd3 == uOESupplier2.OdrPrtsNoHyphenCd3)
                 && (uOESupplier1.OdrPrtsNoHyphenCd4 == uOESupplier2.OdrPrtsNoHyphenCd4)
                 && (uOESupplier1.OdrPrtsNoHyphenCd5 == uOESupplier2.OdrPrtsNoHyphenCd5)
                 && (uOESupplier1.OdrPrtsNoHyphenCd6 == uOESupplier2.OdrPrtsNoHyphenCd6)
                //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
                 && (uOESupplier1.instrumentNo == uOESupplier2.instrumentNo)
                 && (uOESupplier1.UOETestMode == uOESupplier2.UOETestMode)
                 && (uOESupplier1.UOEItemCd == uOESupplier2.UOEItemCd)
                 && (uOESupplier1.HondaSectionCode == uOESupplier2.HondaSectionCode)
                 && (uOESupplier1.AnswerSaveFolder == uOESupplier2.AnswerSaveFolder)
                 && (uOESupplier1.MazdaSectionCode == uOESupplier2.MazdaSectionCode)
                 && (uOESupplier1.EmergencyDiv == uOESupplier2.EmergencyDiv)
                 && (uOESupplier1.DaihatsuOrdreDiv == uOESupplier2.DaihatsuOrdreDiv)
                 && (uOESupplier1.EnterpriseName == uOESupplier2.EnterpriseName)
                 && (uOESupplier1.UpdEmployeeName == uOESupplier2.UpdEmployeeName)
                 && (uOESupplier1.BusinessName == uOESupplier2.BusinessName)
                 && (uOESupplier1.SectionCode == uOESupplier2.SectionCode)
                 //&& (uOESupplier1.SupplierCd == uOESupplier2.SupplierCd));        //DEL 2009/06/01
                 // ---ADD 2009/06/01 ---------------------------------->>>>>
                 && (uOESupplier1.SupplierCd == uOESupplier2.SupplierCd)
                 && (uOESupplier1.LoginTimeoutVal == uOESupplier2.LoginTimeoutVal)
                 && (uOESupplier1.UOEOrderUrl == uOESupplier2.UOEOrderUrl)
                 && (uOESupplier1.UOEStockCheckUrl == uOESupplier2.UOEStockCheckUrl)
                 && (uOESupplier1.UOEForcedTermUrl == uOESupplier2.UOEForcedTermUrl)
                 && (uOESupplier1.UOELoginUrl == uOESupplier2.UOELoginUrl)
                 && (uOESupplier1.InqOrdDivCd == uOESupplier2.InqOrdDivCd)
                 && (uOESupplier1.EPartsUserId == uOESupplier2.EPartsUserId)
                // 2012/09/10 UPD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                // && (uOESupplier1.EPartsPassWord == uOESupplier2.EPartsPassWord));
                 && (uOESupplier1.EPartsPassWord == uOESupplier2.EPartsPassWord)
                // 2012/09/10 UPD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
                // ---ADD 2009/06/01 ----------------------------------<<<<<
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                 && (uOESupplier1.BLMngUserCode == uOESupplier2.BLMngUserCode));
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<

        }
        /// <summary>
        /// UOE発注先マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のUOESupplierクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESupplierクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(UOESupplier target)
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
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.UOESupplierName != target.UOESupplierName) resList.Add("UOESupplierName");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.TelNo != target.TelNo) resList.Add("TelNo");
            if (this.UOETerminalCd != target.UOETerminalCd) resList.Add("UOETerminalCd");
            if (this.UOEHostCode != target.UOEHostCode) resList.Add("UOEHostCode");
            if (this.UOEConnectPassword != target.UOEConnectPassword) resList.Add("UOEConnectPassword");
            if (this.UOEConnectUserId != target.UOEConnectUserId) resList.Add("UOEConnectUserId");
            if (this.UOEIDNum != target.UOEIDNum) resList.Add("UOEIDNum");
            if (this.CommAssemblyId != target.CommAssemblyId) resList.Add("CommAssemblyId");
            if (this.ConnectVersionDiv != target.ConnectVersionDiv) resList.Add("ConnectVersionDiv");
            if (this.UOEShipSectCd != target.UOEShipSectCd) resList.Add("UOEShipSectCd");
            if (this.UOESalSectCd != target.UOESalSectCd) resList.Add("UOESalSectCd");
            if (this.UOEReservSectCd != target.UOEReservSectCd) resList.Add("UOEReservSectCd");
            if (this.ReceiveCondition != target.ReceiveCondition) resList.Add("ReceiveCondition");
            if (this.SubstPartsNoDiv != target.SubstPartsNoDiv) resList.Add("SubstPartsNoDiv");
            if (this.PartsNoPrtCd != target.PartsNoPrtCd) resList.Add("PartsNoPrtCd");
            if (this.ListPriceUseDiv != target.ListPriceUseDiv) resList.Add("ListPriceUseDiv");
            if (this.StockSlipDtRecvDiv != target.StockSlipDtRecvDiv) resList.Add("StockSlipDtRecvDiv");
            if (this.CheckCodeDiv != target.CheckCodeDiv) resList.Add("CheckCodeDiv");
            if (this.BusinessCode != target.BusinessCode) resList.Add("BusinessCode");
            if (this.UOEResvdSection != target.UOEResvdSection) resList.Add("UOEResvdSection");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            //if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (this.UOEDeliGoodsDiv != target.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (this.BoCode != target.BoCode) resList.Add("BoCode");
            if (this.UOEOrderRate != target.UOEOrderRate) resList.Add("UOEOrderRate");
            if (this.EnableOdrMakerCd1 != target.EnableOdrMakerCd1) resList.Add("EnableOdrMakerCd1");
            if (this.EnableOdrMakerCd2 != target.EnableOdrMakerCd2) resList.Add("EnableOdrMakerCd2");
            if (this.EnableOdrMakerCd3 != target.EnableOdrMakerCd3) resList.Add("EnableOdrMakerCd3");
            if (this.EnableOdrMakerCd4 != target.EnableOdrMakerCd4) resList.Add("EnableOdrMakerCd4");
            if (this.EnableOdrMakerCd5 != target.EnableOdrMakerCd5) resList.Add("EnableOdrMakerCd5");
            if (this.EnableOdrMakerCd6 != target.EnableOdrMakerCd6) resList.Add("EnableOdrMakerCd6");
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
            if (this.OdrPrtsNoHyphenCd1 != target.OdrPrtsNoHyphenCd1) resList.Add("OdrPrtsNoHyphenCd1");
            if (this.OdrPrtsNoHyphenCd2 != target.OdrPrtsNoHyphenCd2) resList.Add("OdrPrtsNoHyphenCd2");
            if (this.OdrPrtsNoHyphenCd3 != target.OdrPrtsNoHyphenCd3) resList.Add("OdrPrtsNoHyphenCd3");
            if (this.OdrPrtsNoHyphenCd4 != target.OdrPrtsNoHyphenCd4) resList.Add("OdrPrtsNoHyphenCd4");
            if (this.OdrPrtsNoHyphenCd5 != target.OdrPrtsNoHyphenCd5) resList.Add("OdrPrtsNoHyphenCd5");
            if (this.OdrPrtsNoHyphenCd6 != target.OdrPrtsNoHyphenCd6) resList.Add("OdrPrtsNoHyphenCd6");
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
            if (this.instrumentNo != target.instrumentNo) resList.Add("instrumentNo");
            if (this.UOETestMode != target.UOETestMode) resList.Add("UOETestMode");
            if (this.UOEItemCd != target.UOEItemCd) resList.Add("UOEItemCd");
            if (this.HondaSectionCode != target.HondaSectionCode) resList.Add("HondaSectionCode");
            if (this.AnswerSaveFolder != target.AnswerSaveFolder) resList.Add("AnswerSaveFolder");
            if (this.MazdaSectionCode != target.MazdaSectionCode) resList.Add("MazdaSectionCode");
            if (this.EmergencyDiv != target.EmergencyDiv) resList.Add("EmergencyDiv");
            if (this.DaihatsuOrdreDiv != target.DaihatsuOrdreDiv) resList.Add("DaihatsuOrdreDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BusinessName != target.BusinessName) resList.Add("BusinessName");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            // ---ADD 2009/06/01 ---------------------------------->>>>>
            if (this.LoginTimeoutVal != target.LoginTimeoutVal) resList.Add("LoginTimeoutVal");
            if (this.UOEOrderUrl != target.UOEOrderUrl) resList.Add("UOEOrderUrl");
            if (this.UOEStockCheckUrl != target.UOEStockCheckUrl) resList.Add("UOEStockCheckUrl");
            if (this.UOEForcedTermUrl != target.UOEForcedTermUrl) resList.Add("UOEForcedTermUrl");
            if (this.UOELoginUrl != target.UOELoginUrl) resList.Add("UOELoginUrl");
            if (this.InqOrdDivCd != target.InqOrdDivCd) resList.Add("InqOrdDivCd");
            if (this.EPartsUserId != target.EPartsUserId) resList.Add("EPartsUserId");
            if (this.EPartsPassWord != target.EPartsPassWord) resList.Add("EPartsPassWord");
            // ---ADD 2009/06/01 ----------------------------------<<<<<
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
            if (this.BLMngUserCode != target.BLMngUserCode) resList.Add("BLMngUserCode");
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<

            return resList;
        }

        /// <summary>
        /// UOE発注先マスタ比較処理
        /// </summary>
        /// <param name="uOESupplier1">比較するUOESupplierクラスのインスタンス</param>
        /// <param name="uOESupplier2">比較するUOESupplierクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESupplierクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(UOESupplier uOESupplier1, UOESupplier uOESupplier2)
        {
            ArrayList resList = new ArrayList();
            if (uOESupplier1.CreateDateTime != uOESupplier2.CreateDateTime) resList.Add("CreateDateTime");
            if (uOESupplier1.UpdateDateTime != uOESupplier2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (uOESupplier1.EnterpriseCode != uOESupplier2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (uOESupplier1.FileHeaderGuid != uOESupplier2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (uOESupplier1.UpdEmployeeCode != uOESupplier2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (uOESupplier1.UpdAssemblyId1 != uOESupplier2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (uOESupplier1.UpdAssemblyId2 != uOESupplier2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (uOESupplier1.LogicalDeleteCode != uOESupplier2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (uOESupplier1.UOESupplierCd != uOESupplier2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (uOESupplier1.UOESupplierName != uOESupplier2.UOESupplierName) resList.Add("UOESupplierName");
            if (uOESupplier1.GoodsMakerCd != uOESupplier2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (uOESupplier1.TelNo != uOESupplier2.TelNo) resList.Add("TelNo");
            if (uOESupplier1.UOETerminalCd != uOESupplier2.UOETerminalCd) resList.Add("UOETerminalCd");
            if (uOESupplier1.UOEHostCode != uOESupplier2.UOEHostCode) resList.Add("UOEHostCode");
            if (uOESupplier1.UOEConnectPassword != uOESupplier2.UOEConnectPassword) resList.Add("UOEConnectPassword");
            if (uOESupplier1.UOEConnectUserId != uOESupplier2.UOEConnectUserId) resList.Add("UOEConnectUserId");
            if (uOESupplier1.UOEIDNum != uOESupplier2.UOEIDNum) resList.Add("UOEIDNum");
            if (uOESupplier1.CommAssemblyId != uOESupplier2.CommAssemblyId) resList.Add("CommAssemblyId");
            if (uOESupplier1.ConnectVersionDiv != uOESupplier2.ConnectVersionDiv) resList.Add("ConnectVersionDiv");
            if (uOESupplier1.UOEShipSectCd != uOESupplier2.UOEShipSectCd) resList.Add("UOEShipSectCd");
            if (uOESupplier1.UOESalSectCd != uOESupplier2.UOESalSectCd) resList.Add("UOESalSectCd");
            if (uOESupplier1.UOEReservSectCd != uOESupplier2.UOEReservSectCd) resList.Add("UOEReservSectCd");
            if (uOESupplier1.ReceiveCondition != uOESupplier2.ReceiveCondition) resList.Add("ReceiveCondition");
            if (uOESupplier1.SubstPartsNoDiv != uOESupplier2.SubstPartsNoDiv) resList.Add("SubstPartsNoDiv");
            if (uOESupplier1.PartsNoPrtCd != uOESupplier2.PartsNoPrtCd) resList.Add("PartsNoPrtCd");
            if (uOESupplier1.ListPriceUseDiv != uOESupplier2.ListPriceUseDiv) resList.Add("ListPriceUseDiv");
            if (uOESupplier1.StockSlipDtRecvDiv != uOESupplier2.StockSlipDtRecvDiv) resList.Add("StockSlipDtRecvDiv");
            if (uOESupplier1.CheckCodeDiv != uOESupplier2.CheckCodeDiv) resList.Add("CheckCodeDiv");
            if (uOESupplier1.BusinessCode != uOESupplier2.BusinessCode) resList.Add("BusinessCode");
            if (uOESupplier1.UOEResvdSection != uOESupplier2.UOEResvdSection) resList.Add("UOEResvdSection");
            if (uOESupplier1.EmployeeCode != uOESupplier2.EmployeeCode) resList.Add("EmployeeCode");
            //if (uOESupplier1.DeliveredGoodsDiv != uOESupplier2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (uOESupplier1.UOEDeliGoodsDiv != uOESupplier2.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (uOESupplier1.BoCode != uOESupplier2.BoCode) resList.Add("BoCode");
            if (uOESupplier1.UOEOrderRate != uOESupplier2.UOEOrderRate) resList.Add("UOEOrderRate");
            if (uOESupplier1.EnableOdrMakerCd1 != uOESupplier2.EnableOdrMakerCd1) resList.Add("EnableOdrMakerCd1");
            if (uOESupplier1.EnableOdrMakerCd2 != uOESupplier2.EnableOdrMakerCd2) resList.Add("EnableOdrMakerCd2");
            if (uOESupplier1.EnableOdrMakerCd3 != uOESupplier2.EnableOdrMakerCd3) resList.Add("EnableOdrMakerCd3");
            if (uOESupplier1.EnableOdrMakerCd4 != uOESupplier2.EnableOdrMakerCd4) resList.Add("EnableOdrMakerCd4");
            if (uOESupplier1.EnableOdrMakerCd5 != uOESupplier2.EnableOdrMakerCd5) resList.Add("EnableOdrMakerCd5");
            if (uOESupplier1.EnableOdrMakerCd6 != uOESupplier2.EnableOdrMakerCd6) resList.Add("EnableOdrMakerCd6");
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
            if (uOESupplier1.OdrPrtsNoHyphenCd1 != uOESupplier2.OdrPrtsNoHyphenCd1) resList.Add("OdrPrtsNoHyphenCd1");
            if (uOESupplier1.OdrPrtsNoHyphenCd2 != uOESupplier2.OdrPrtsNoHyphenCd2) resList.Add("OdrPrtsNoHyphenCd2");
            if (uOESupplier1.OdrPrtsNoHyphenCd3 != uOESupplier2.OdrPrtsNoHyphenCd3) resList.Add("OdrPrtsNoHyphenCd3");
            if (uOESupplier1.OdrPrtsNoHyphenCd4 != uOESupplier2.OdrPrtsNoHyphenCd4) resList.Add("OdrPrtsNoHyphenCd4");
            if (uOESupplier1.OdrPrtsNoHyphenCd5 != uOESupplier2.OdrPrtsNoHyphenCd5) resList.Add("OdrPrtsNoHyphenCd5");
            if (uOESupplier1.OdrPrtsNoHyphenCd6 != uOESupplier2.OdrPrtsNoHyphenCd6) resList.Add("OdrPrtsNoHyphenCd6");
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
            if (uOESupplier1.instrumentNo != uOESupplier2.instrumentNo) resList.Add("instrumentNo");
            if (uOESupplier1.UOETestMode != uOESupplier2.UOETestMode) resList.Add("UOETestMode");
            if (uOESupplier1.UOEItemCd != uOESupplier2.UOEItemCd) resList.Add("UOEItemCd");
            if (uOESupplier1.HondaSectionCode != uOESupplier2.HondaSectionCode) resList.Add("HondaSectionCode");
            if (uOESupplier1.AnswerSaveFolder != uOESupplier2.AnswerSaveFolder) resList.Add("AnswerSaveFolder");
            if (uOESupplier1.MazdaSectionCode != uOESupplier2.MazdaSectionCode) resList.Add("MazdaSectionCode");
            if (uOESupplier1.EmergencyDiv != uOESupplier2.EmergencyDiv) resList.Add("EmergencyDiv");
            if (uOESupplier1.DaihatsuOrdreDiv != uOESupplier2.DaihatsuOrdreDiv) resList.Add("DaihatsuOrdreDiv");
            if (uOESupplier1.EnterpriseName != uOESupplier2.EnterpriseName) resList.Add("EnterpriseName");
            if (uOESupplier1.UpdEmployeeName != uOESupplier2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (uOESupplier1.BusinessName != uOESupplier2.BusinessName) resList.Add("BusinessName");
            if (uOESupplier1.SectionCode != uOESupplier2.SectionCode) resList.Add("SectionCode");
            if (uOESupplier1.SupplierCd != uOESupplier2.SupplierCd) resList.Add("SupplierCd");
            // ---ADD 2009/06/01 ---------------------------------->>>>>
            if (uOESupplier1.LoginTimeoutVal != uOESupplier2.LoginTimeoutVal) resList.Add("LoginTimeoutVal");
            if (uOESupplier1.UOEOrderUrl != uOESupplier2.UOEOrderUrl) resList.Add("UOEOrderUrl");
            if (uOESupplier1.UOEStockCheckUrl != uOESupplier2.UOEStockCheckUrl) resList.Add("UOEStockCheckUrl");
            if (uOESupplier1.UOEForcedTermUrl != uOESupplier2.UOEForcedTermUrl) resList.Add("UOEForcedTermUrl");
            if (uOESupplier1.UOELoginUrl != uOESupplier2.UOELoginUrl) resList.Add("UOELoginUrl");
            if (uOESupplier1.InqOrdDivCd != uOESupplier2.InqOrdDivCd) resList.Add("InqOrdDivCd");
            if (uOESupplier1.EPartsUserId != uOESupplier2.EPartsUserId) resList.Add("EPartsUserId");
            if (uOESupplier1.EPartsPassWord != uOESupplier2.EPartsPassWord) resList.Add("EPartsPassWord");
            // ---ADD 2009/06/01 ----------------------------------<<<<<
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
            if (uOESupplier1.BLMngUserCode != uOESupplier2.BLMngUserCode) resList.Add("BLMngUserCode");
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<

            return resList;
        }
    }
}
