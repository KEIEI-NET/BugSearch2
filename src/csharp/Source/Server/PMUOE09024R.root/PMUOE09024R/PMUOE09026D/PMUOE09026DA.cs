//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE 発注先マスタデータパラメータ
//                  :   PMUOE09026D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 疋田 勇人
// Date             :   2008.06.06　
// Note             :   ※テーブルにはない追加項目があるので、自動生成時は気をつけてください
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   UOESupplierWork
    /// <summary>
    ///                      UOE発注先ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE発注先ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/12</br>
    /// <br>Genarated Date   :   2009/05/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/8/22  長内</br>
    /// <br>                 :   ○項目追加（キー変更）</br>
    /// <br>                 :   　拠点コード</br>
    /// <br>                 :   　仕入先コード</br>
    /// <br>Update Note      :   2008/9/9  長内</br>
    /// <br>                 :   ○型変更</br>
    /// <br>                 :   　拠点関係の項目をnvarchar⇒ncharに変更</br>
    /// <br>Update Note      :   2008/11/10  杉村</br>
    /// <br>                 :   ○項目変更（型変更に伴いDD名も変更）</br>
    /// <br>                 :   　納品区分</br>
    /// <br>                 :   　↓</br>
    /// <br>                 :   　UOE納品区分</br>
    /// <br>Update Note      :   2009/5/27  杉村</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   ログインタイムアウト</br>
    /// <br>                 :   UOE発注URL</br>
    /// <br>                 :   UOE在庫確認URL</br>
    /// <br>                 :   UOE強制終了URL</br>
    /// <br>                 :   UOEログインURL</br>
    /// <br>                 :   問合せ・発注種別</br>
    /// <br>                 :   e-PartsユーザID</br>
    /// <br>                 :   e-Partsパスワード</br>
    /// <br>Update Note      :   2012/09/10  高川</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   BL管理ユーザーコード</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class UOESupplierWork : IFileHeader
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
        private string _sectionCode = "";

        /// <summary>UOE発注先コード</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE発注先名称</summary>
        private string _uOESupplierName = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>仕入先コード</summary>
        /// <remarks>仕入データ計上時の仕入先コード</remarks>
        private Int32 _supplierCd;

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

        /// <summary>UOEＩＤ番号</summary>
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

        /// <summary>品番印字区分</summary>
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

        /// <summary>ログインタイムアウト</summary>
        /// <remarks>秒</remarks>
        private Int32 _loginTimeoutVal;

        /// <summary>UOE発注URL</summary>
        private string _uOEOrderUrl = "";

        /// <summary>UOE在庫確認URL</summary>
        private string _uOEStockCheckUrl = "";

        /// <summary>UOE強制終了URL</summary>
        private string _uOEForcedTermUrl = "";

        /// <summary>UOEログインURL</summary>
        private string _uOELoginUrl = "";

        /// <summary>問合せ・発注種別</summary>
        /// <remarks>0:発注処理 1:在庫確認</remarks>
        private Int32 _inqOrdDivCd;

        /// <summary>e-PartsユーザID</summary>
        private string _ePartsUserId = "";

        /// <summary>e-Partsパスワード</summary>
        private string _ePartsPassWord = "";

        /// <summary>UOE出庫拠点名称</summary>
        private string _uOEShipSectNm = "";

        /// <summary>UOE売上拠点名称</summary>
        private string _uOESalSectNm = "";

        /// <summary>UOE指定拠点名称</summary>
        private string _uOEReservSectNm = "";

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>発注可能メーカー名称１</summary>
        private string _enableOdrMakerName1 = "";

        /// <summary>発注可能メーカー名称２</summary>
        private string _enableOdrMakerName2 = "";

        /// <summary>発注可能メーカー名称３</summary>
        private string _enableOdrMakerName3 = "";

        /// <summary>発注可能メーカー名称４</summary>
        private string _enableOdrMakerName4 = "";

        /// <summary>発注可能メーカー名称５</summary>
        private string _enableOdrMakerName5 = "";

        /// <summary>発注可能メーカー名称６</summary>
        private string _enableOdrMakerName6 = "";

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

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>仕入データ計上時の仕入先コード</value>
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
        /// <summary>UOEＩＤ番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOEＩＤ番号プロパティ</br>
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
        /// <summary>品番印字区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番印字区分プロパティ</br>
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

        /// public propaty name  :  LoginTimeoutVal
        /// <summary>ログインタイムアウトプロパティ</summary>
        /// <value>秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログインタイムアウトプロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEOrderUrl
        {
            get { return _uOEOrderUrl; }
            set { _uOEOrderUrl = value; }
        }

        /// public propaty name  :  UOEStockCheckUrl
        /// <summary>UOE在庫確認URLプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE在庫確認URLプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEStockCheckUrl
        {
            get { return _uOEStockCheckUrl; }
            set { _uOEStockCheckUrl = value; }
        }

        /// public propaty name  :  UOEForcedTermUrl
        /// <summary>UOE強制終了URLプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE強制終了URLプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEForcedTermUrl
        {
            get { return _uOEForcedTermUrl; }
            set { _uOEForcedTermUrl = value; }
        }

        /// public propaty name  :  UOELoginUrl
        /// <summary>UOEログインURLプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOEログインURLプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOELoginUrl
        {
            get { return _uOELoginUrl; }
            set { _uOELoginUrl = value; }
        }

        /// public propaty name  :  InqOrdDivCd
        /// <summary>問合せ・発注種別プロパティ</summary>
        /// <value>0:発注処理 1:在庫確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ・発注種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EPartsPassWord
        {
            get { return _ePartsPassWord; }
            set { _ePartsPassWord = value; }
        }

        /// public propaty name  :  UOEShipSectNm
        /// <summary>UOE出庫拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE出庫拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEShipSectNm
        {
            get { return _uOEShipSectNm; }
            set { _uOEShipSectNm = value; }
        }

        /// public propaty name  :  UOESalSectNm
        /// <summary>UOE売上拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE売上拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESalSectNm
        {
            get { return _uOESalSectNm; }
            set { _uOESalSectNm = value; }
        }

        /// public propaty name  :  UOEReservSectNm
        /// <summary>UOE指定拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE指定拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEReservSectNm
        {
            get { return _uOEReservSectNm; }
            set { _uOEReservSectNm = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  EnableOdrMakerName1
        /// <summary>発注可能メーカー名称１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注可能メーカー名称１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnableOdrMakerName1
        {
            get { return _enableOdrMakerName1; }
            set { _enableOdrMakerName1 = value; }
        }

        /// public propaty name  :  EnableOdrMakerName2
        /// <summary>発注可能メーカー名称２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注可能メーカー名称２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnableOdrMakerName2
        {
            get { return _enableOdrMakerName2; }
            set { _enableOdrMakerName2 = value; }
        }

        /// public propaty name  :  EnableOdrMakerName3
        /// <summary>発注可能メーカー名称３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注可能メーカー名称３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnableOdrMakerName3
        {
            get { return _enableOdrMakerName3; }
            set { _enableOdrMakerName3 = value; }
        }

        /// public propaty name  :  EnableOdrMakerName4
        /// <summary>発注可能メーカー名称４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注可能メーカー名称４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnableOdrMakerName4
        {
            get { return _enableOdrMakerName4; }
            set { _enableOdrMakerName4 = value; }
        }

        /// public propaty name  :  EnableOdrMakerName5
        /// <summary>発注可能メーカー名称５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注可能メーカー名称５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnableOdrMakerName5
        {
            get { return _enableOdrMakerName5; }
            set { _enableOdrMakerName5 = value; }
        }

        /// public propaty name  :  EnableOdrMakerName6
        /// <summary>発注可能メーカー名称６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注可能メーカー名称６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnableOdrMakerName6
        {
            get { return _enableOdrMakerName6; }
            set { _enableOdrMakerName6 = value; }
        }

        // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  BLMngUserCode
        /// <summary>BL管理ユーザーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL管理ユーザーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLMngUserCode
        {
            get { return _bLMngUserCode; }
            set { _bLMngUserCode = value; }
        }
        // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// UOE発注先ワークコンストラクタ
        /// </summary>
        /// <returns>UOESupplierWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESupplierWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOESupplierWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>UOESupplierWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   UOESupplierWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class UOESupplierWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESupplierWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  UOESupplierWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is UOESupplierWork || graph is ArrayList || graph is UOESupplierWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(UOESupplierWork).FullName));

            if (graph != null && graph is UOESupplierWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UOESupplierWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is UOESupplierWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((UOESupplierWork[])graph).Length;
            }
            else if (graph is UOESupplierWork)
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
            //UOE発注先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESupplierCd
            //UOE発注先名称
            serInfo.MemberInfo.Add(typeof(string)); //UOESupplierName
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //電話番号
            serInfo.MemberInfo.Add(typeof(string)); //TelNo
            //UOE端末コード
            serInfo.MemberInfo.Add(typeof(string)); //UOETerminalCd
            //UOEホストコード
            serInfo.MemberInfo.Add(typeof(string)); //UOEHostCode
            //UOE接続パスワード
            serInfo.MemberInfo.Add(typeof(string)); //UOEConnectPassword
            //UOE接続ユーザID
            serInfo.MemberInfo.Add(typeof(string)); //UOEConnectUserId
            //UOEＩＤ番号
            serInfo.MemberInfo.Add(typeof(string)); //UOEIDNum
            //通信アセンブリID
            serInfo.MemberInfo.Add(typeof(string)); //CommAssemblyId
            //接続バージョン区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ConnectVersionDiv
            //UOE出庫拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //UOEShipSectCd
            //UOE売上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //UOESalSectCd
            //UOE指定拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //UOEReservSectCd
            //受信状況
            serInfo.MemberInfo.Add(typeof(Int32)); //ReceiveCondition
            //代替品番区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SubstPartsNoDiv
            //品番印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsNoPrtCd
            //定価使用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPriceUseDiv
            //仕入データ受信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipDtRecvDiv
            //チェックコード区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CheckCodeDiv
            //業務区分
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessCode
            //UOE指定拠点
            serInfo.MemberInfo.Add(typeof(string)); //UOEResvdSection
            //従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //UOE納品区分
            serInfo.MemberInfo.Add(typeof(string)); //UOEDeliGoodsDiv
            //BO区分
            serInfo.MemberInfo.Add(typeof(string)); //BoCode
            //UOE発注レート
            serInfo.MemberInfo.Add(typeof(string)); //UOEOrderRate
            //発注可能メーカーコード１
            serInfo.MemberInfo.Add(typeof(Int32)); //EnableOdrMakerCd1
            //発注可能メーカーコード２
            serInfo.MemberInfo.Add(typeof(Int32)); //EnableOdrMakerCd2
            //発注可能メーカーコード３
            serInfo.MemberInfo.Add(typeof(Int32)); //EnableOdrMakerCd3
            //発注可能メーカーコード４
            serInfo.MemberInfo.Add(typeof(Int32)); //EnableOdrMakerCd4
            //発注可能メーカーコード５
            serInfo.MemberInfo.Add(typeof(Int32)); //EnableOdrMakerCd5
            //発注可能メーカーコード６
            serInfo.MemberInfo.Add(typeof(Int32)); //EnableOdrMakerCd6
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
            //発注品番ハイフン区分１
            serInfo.MemberInfo.Add(typeof(Int32)); //OdrPrtsNoHyphenCd1
            //発注品番ハイフン区分２
            serInfo.MemberInfo.Add(typeof(Int32)); //OdrPrtsNoHyphenCd2
            //発注品番ハイフン区分３
            serInfo.MemberInfo.Add(typeof(Int32)); //OdrPrtsNoHyphenCd3
            //発注品番ハイフン区分４
            serInfo.MemberInfo.Add(typeof(Int32)); //OdrPrtsNoHyphenCd4
            //発注品番ハイフン区分５
            serInfo.MemberInfo.Add(typeof(Int32)); //OdrPrtsNoHyphenCd5
            //発注品番ハイフン区分６
            serInfo.MemberInfo.Add(typeof(Int32)); //OdrPrtsNoHyphenCd6
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
            //機器番号
            serInfo.MemberInfo.Add(typeof(string)); //instrumentNo
            //UOEテストモード
            serInfo.MemberInfo.Add(typeof(string)); //UOETestMode
            //UOEアイテムコード
            serInfo.MemberInfo.Add(typeof(string)); //UOEItemCd
            //ホンダ担当拠点
            serInfo.MemberInfo.Add(typeof(string)); //HondaSectionCode
            //回答保存フォルダ
            serInfo.MemberInfo.Add(typeof(string)); //AnswerSaveFolder
            //マツダ自拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //MazdaSectionCode
            //緊急区分
            serInfo.MemberInfo.Add(typeof(string)); //EmergencyDiv
            //発注手配区分（ダイハツ）
            serInfo.MemberInfo.Add(typeof(Int32)); //DaihatsuOrdreDiv
            //ログインタイムアウト
            serInfo.MemberInfo.Add(typeof(Int32)); //LoginTimeoutVal
            //UOE発注URL
            serInfo.MemberInfo.Add(typeof(string)); //UOEOrderUrl
            //UOE在庫確認URL
            serInfo.MemberInfo.Add(typeof(string)); //UOEStockCheckUrl
            //UOE強制終了URL
            serInfo.MemberInfo.Add(typeof(string)); //UOEForcedTermUrl
            //UOEログインURL
            serInfo.MemberInfo.Add(typeof(string)); //UOELoginUrl
            //問合せ・発注種別
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
            //e-PartsユーザID
            serInfo.MemberInfo.Add(typeof(string)); //EPartsUserId
            //e-Partsパスワード
            serInfo.MemberInfo.Add(typeof(string)); //EPartsPassWord
            //UOE出庫拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //UOEShipSectNm
            //UOE売上拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //UOESalSectNm
            //UOE指定拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //UOEReservSectNm
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //発注可能メーカー名称１
            serInfo.MemberInfo.Add(typeof(string)); //EnableOdrMakerName1
            //発注可能メーカー名称２
            serInfo.MemberInfo.Add(typeof(string)); //EnableOdrMakerName2
            //発注可能メーカー名称３
            serInfo.MemberInfo.Add(typeof(string)); //EnableOdrMakerName3
            //発注可能メーカー名称４
            serInfo.MemberInfo.Add(typeof(string)); //EnableOdrMakerName4
            //発注可能メーカー名称５
            serInfo.MemberInfo.Add(typeof(string)); //EnableOdrMakerName5
            //発注可能メーカー名称６
            serInfo.MemberInfo.Add(typeof(string)); //EnableOdrMakerName6
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
            //BL管理ユーザーコード
            serInfo.MemberInfo.Add(typeof(string)); //BLMngUserCode
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is UOESupplierWork)
            {
                UOESupplierWork temp = (UOESupplierWork)graph;

                SetUOESupplierWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is UOESupplierWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((UOESupplierWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (UOESupplierWork temp in lst)
                {
                    SetUOESupplierWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// UOESupplierWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 68;// DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
        // 2012/09/10 UPD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
        //private const int currentMemberCount = 74;// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
        private const int currentMemberCount = 75;
        // 2012/09/10 UPD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
        /// <summary>
        ///  UOESupplierWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESupplierWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetUOESupplierWork(System.IO.BinaryWriter writer, UOESupplierWork temp)
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
            //UOE発注先コード
            writer.Write(temp.UOESupplierCd);
            //UOE発注先名称
            writer.Write(temp.UOESupplierName);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //電話番号
            writer.Write(temp.TelNo);
            //UOE端末コード
            writer.Write(temp.UOETerminalCd);
            //UOEホストコード
            writer.Write(temp.UOEHostCode);
            //UOE接続パスワード
            writer.Write(temp.UOEConnectPassword);
            //UOE接続ユーザID
            writer.Write(temp.UOEConnectUserId);
            //UOEＩＤ番号
            writer.Write(temp.UOEIDNum);
            //通信アセンブリID
            writer.Write(temp.CommAssemblyId);
            //接続バージョン区分
            writer.Write(temp.ConnectVersionDiv);
            //UOE出庫拠点コード
            writer.Write(temp.UOEShipSectCd);
            //UOE売上拠点コード
            writer.Write(temp.UOESalSectCd);
            //UOE指定拠点コード
            writer.Write(temp.UOEReservSectCd);
            //受信状況
            writer.Write(temp.ReceiveCondition);
            //代替品番区分
            writer.Write(temp.SubstPartsNoDiv);
            //品番印字区分
            writer.Write(temp.PartsNoPrtCd);
            //定価使用区分
            writer.Write(temp.ListPriceUseDiv);
            //仕入データ受信区分
            writer.Write(temp.StockSlipDtRecvDiv);
            //チェックコード区分
            writer.Write(temp.CheckCodeDiv);
            //業務区分
            writer.Write(temp.BusinessCode);
            //UOE指定拠点
            writer.Write(temp.UOEResvdSection);
            //従業員コード
            writer.Write(temp.EmployeeCode);
            //UOE納品区分
            writer.Write(temp.UOEDeliGoodsDiv);
            //BO区分
            writer.Write(temp.BoCode);
            //UOE発注レート
            writer.Write(temp.UOEOrderRate);
            //発注可能メーカーコード１
            writer.Write(temp.EnableOdrMakerCd1);
            //発注可能メーカーコード２
            writer.Write(temp.EnableOdrMakerCd2);
            //発注可能メーカーコード３
            writer.Write(temp.EnableOdrMakerCd3);
            //発注可能メーカーコード４
            writer.Write(temp.EnableOdrMakerCd4);
            //発注可能メーカーコード５
            writer.Write(temp.EnableOdrMakerCd5);
            //発注可能メーカーコード６
            writer.Write(temp.EnableOdrMakerCd6);
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
            //発注品番ハイフン区分１
            writer.Write(temp.OdrPrtsNoHyphenCd1);
            //発注品番ハイフン区分２
            writer.Write(temp.OdrPrtsNoHyphenCd2);
            //発注品番ハイフン区分３
            writer.Write(temp.OdrPrtsNoHyphenCd3);
            //発注品番ハイフン区分４
            writer.Write(temp.OdrPrtsNoHyphenCd4);
            //発注品番ハイフン区分５
            writer.Write(temp.OdrPrtsNoHyphenCd5);
            //発注品番ハイフン区分６
            writer.Write(temp.OdrPrtsNoHyphenCd6);
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
            //機器番号
            writer.Write(temp.instrumentNo);
            //UOEテストモード
            writer.Write(temp.UOETestMode);
            //UOEアイテムコード
            writer.Write(temp.UOEItemCd);
            //ホンダ担当拠点
            writer.Write(temp.HondaSectionCode);
            //回答保存フォルダ
            writer.Write(temp.AnswerSaveFolder);
            //マツダ自拠点コード
            writer.Write(temp.MazdaSectionCode);
            //緊急区分
            writer.Write(temp.EmergencyDiv);
            //発注手配区分（ダイハツ）
            writer.Write(temp.DaihatsuOrdreDiv);
            //ログインタイムアウト
            writer.Write(temp.LoginTimeoutVal);
            //UOE発注URL
            writer.Write(temp.UOEOrderUrl);
            //UOE在庫確認URL
            writer.Write(temp.UOEStockCheckUrl);
            //UOE強制終了URL
            writer.Write(temp.UOEForcedTermUrl);
            //UOEログインURL
            writer.Write(temp.UOELoginUrl);
            //問合せ・発注種別
            writer.Write(temp.InqOrdDivCd);
            //e-PartsユーザID
            writer.Write(temp.EPartsUserId);
            //e-Partsパスワード
            writer.Write(temp.EPartsPassWord);
            //UOE出庫拠点名称
            writer.Write(temp.UOEShipSectNm);
            //UOE売上拠点名称
            writer.Write(temp.UOESalSectNm);
            //UOE指定拠点名称
            writer.Write(temp.UOEReservSectNm);
            //メーカー名称
            writer.Write(temp.MakerName);
            //発注可能メーカー名称１
            writer.Write(temp.EnableOdrMakerName1);
            //発注可能メーカー名称２
            writer.Write(temp.EnableOdrMakerName2);
            //発注可能メーカー名称３
            writer.Write(temp.EnableOdrMakerName3);
            //発注可能メーカー名称４
            writer.Write(temp.EnableOdrMakerName4);
            //発注可能メーカー名称５
            writer.Write(temp.EnableOdrMakerName5);
            //発注可能メーカー名称６
            writer.Write(temp.EnableOdrMakerName6);
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
            //BL管理ユーザーコード
            writer.Write(temp.BLMngUserCode);
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<

        }

        /// <summary>
        ///  UOESupplierWorkインスタンス取得
        /// </summary>
        /// <returns>UOESupplierWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESupplierWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private UOESupplierWork GetUOESupplierWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            UOESupplierWork temp = new UOESupplierWork();

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
            //UOE発注先コード
            temp.UOESupplierCd = reader.ReadInt32();
            //UOE発注先名称
            temp.UOESupplierName = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //電話番号
            temp.TelNo = reader.ReadString();
            //UOE端末コード
            temp.UOETerminalCd = reader.ReadString();
            //UOEホストコード
            temp.UOEHostCode = reader.ReadString();
            //UOE接続パスワード
            temp.UOEConnectPassword = reader.ReadString();
            //UOE接続ユーザID
            temp.UOEConnectUserId = reader.ReadString();
            //UOEＩＤ番号
            temp.UOEIDNum = reader.ReadString();
            //通信アセンブリID
            temp.CommAssemblyId = reader.ReadString();
            //接続バージョン区分
            temp.ConnectVersionDiv = reader.ReadInt32();
            //UOE出庫拠点コード
            temp.UOEShipSectCd = reader.ReadString();
            //UOE売上拠点コード
            temp.UOESalSectCd = reader.ReadString();
            //UOE指定拠点コード
            temp.UOEReservSectCd = reader.ReadString();
            //受信状況
            temp.ReceiveCondition = reader.ReadInt32();
            //代替品番区分
            temp.SubstPartsNoDiv = reader.ReadInt32();
            //品番印字区分
            temp.PartsNoPrtCd = reader.ReadInt32();
            //定価使用区分
            temp.ListPriceUseDiv = reader.ReadInt32();
            //仕入データ受信区分
            temp.StockSlipDtRecvDiv = reader.ReadInt32();
            //チェックコード区分
            temp.CheckCodeDiv = reader.ReadInt32();
            //業務区分
            temp.BusinessCode = reader.ReadInt32();
            //UOE指定拠点
            temp.UOEResvdSection = reader.ReadString();
            //従業員コード
            temp.EmployeeCode = reader.ReadString();
            //UOE納品区分
            temp.UOEDeliGoodsDiv = reader.ReadString();
            //BO区分
            temp.BoCode = reader.ReadString();
            //UOE発注レート
            temp.UOEOrderRate = reader.ReadString();
            //発注可能メーカーコード１
            temp.EnableOdrMakerCd1 = reader.ReadInt32();
            //発注可能メーカーコード２
            temp.EnableOdrMakerCd2 = reader.ReadInt32();
            //発注可能メーカーコード３
            temp.EnableOdrMakerCd3 = reader.ReadInt32();
            //発注可能メーカーコード４
            temp.EnableOdrMakerCd4 = reader.ReadInt32();
            //発注可能メーカーコード５
            temp.EnableOdrMakerCd5 = reader.ReadInt32();
            //発注可能メーカーコード６
            temp.EnableOdrMakerCd6 = reader.ReadInt32();
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
            //発注品番ハイフン区分１
            temp.OdrPrtsNoHyphenCd1 = reader.ReadInt32();
            //発注品番ハイフン区分２
            temp.OdrPrtsNoHyphenCd2 = reader.ReadInt32();
            //発注品番ハイフン区分３
            temp.OdrPrtsNoHyphenCd3 = reader.ReadInt32();
            //発注品番ハイフン区分４
            temp.OdrPrtsNoHyphenCd4 = reader.ReadInt32();
            //発注品番ハイフン区分５
            temp.OdrPrtsNoHyphenCd5 = reader.ReadInt32();
            //発注品番ハイフン区分６
            temp.OdrPrtsNoHyphenCd6 = reader.ReadInt32();
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
            //機器番号
            temp.instrumentNo = reader.ReadString();
            //UOEテストモード
            temp.UOETestMode = reader.ReadString();
            //UOEアイテムコード
            temp.UOEItemCd = reader.ReadString();
            //ホンダ担当拠点
            temp.HondaSectionCode = reader.ReadString();
            //回答保存フォルダ
            temp.AnswerSaveFolder = reader.ReadString();
            //マツダ自拠点コード
            temp.MazdaSectionCode = reader.ReadString();
            //緊急区分
            temp.EmergencyDiv = reader.ReadString();
            //発注手配区分（ダイハツ）
            temp.DaihatsuOrdreDiv = reader.ReadInt32();
            //ログインタイムアウト
            temp.LoginTimeoutVal = reader.ReadInt32();
            //UOE発注URL
            temp.UOEOrderUrl = reader.ReadString();
            //UOE在庫確認URL
            temp.UOEStockCheckUrl = reader.ReadString();
            //UOE強制終了URL
            temp.UOEForcedTermUrl = reader.ReadString();
            //UOEログインURL
            temp.UOELoginUrl = reader.ReadString();
            //問合せ・発注種別
            temp.InqOrdDivCd = reader.ReadInt32();
            //e-PartsユーザID
            temp.EPartsUserId = reader.ReadString();
            //e-Partsパスワード
            temp.EPartsPassWord = reader.ReadString();
            //UOE出庫拠点名称
            temp.UOEShipSectNm = reader.ReadString();
            //UOE売上拠点名称
            temp.UOESalSectNm = reader.ReadString();
            //UOE指定拠点名称
            temp.UOEReservSectNm = reader.ReadString();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //発注可能メーカー名称１
            temp.EnableOdrMakerName1 = reader.ReadString();
            //発注可能メーカー名称２
            temp.EnableOdrMakerName2 = reader.ReadString();
            //発注可能メーカー名称３
            temp.EnableOdrMakerName3 = reader.ReadString();
            //発注可能メーカー名称４
            temp.EnableOdrMakerName4 = reader.ReadString();
            //発注可能メーカー名称５
            temp.EnableOdrMakerName5 = reader.ReadString();
            //発注可能メーカー名称６
            temp.EnableOdrMakerName6 = reader.ReadString();
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
            //BL管理ユーザーコード
            temp.BLMngUserCode = reader.ReadString();
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<


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
        /// <returns>UOESupplierWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESupplierWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                UOESupplierWork temp = GetUOESupplierWork(reader, serInfo);
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
                    retValue = (UOESupplierWork[])lst.ToArray(typeof(UOESupplierWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
