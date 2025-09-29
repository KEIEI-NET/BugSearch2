//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   仕入先マスタデータパラメータ
//                  :   PMKHN09026D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112　久保田　誠
// Date             :   2008.4.24
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
    /// public class name:   SupplierWork
    /// <summary>
    ///                      仕入先ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2008/05/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SupplierWork : IFileHeader
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

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>管理拠点コード</summary>
        private string _mngSectionCode = "";

        /// <summary>入力拠点コード</summary>
        private string _inpSectionCode = "";

        /// <summary>支払拠点コード</summary>
        /// <remarks>請求を行う拠点</remarks>
        private string _paymentSectionCode = "";

        /// <summary>仕入先名1</summary>
        private string _supplierNm1 = "";

        /// <summary>仕入先名2</summary>
        private string _supplierNm2 = "";

        /// <summary>仕入先敬称</summary>
        private string _suppHonorificTitle = "";

        /// <summary>仕入先カナ</summary>
        private string _supplierKana = "";

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>発注書敬称</summary>
        private string _orderHonorificTtl = "";

        /// <summary>業種コード</summary>
        private Int32 _businessTypeCode;

        /// <summary>販売エリアコード</summary>
        private Int32 _salesAreaCode;

        /// <summary>仕入先郵便番号</summary>
        private string _supplierPostNo = "";

        /// <summary>仕入先住所1（都道府県市区郡・町村・字）</summary>
        private string _supplierAddr1 = "";

        /// <summary>仕入先住所3（番地）</summary>
        private string _supplierAddr3 = "";

        /// <summary>仕入先住所4（アパート名称）</summary>
        private string _supplierAddr4 = "";

        /// <summary>仕入先電話番号</summary>
        private string _supplierTelNo = "";

        /// <summary>仕入先電話番号1</summary>
        private string _supplierTelNo1 = "";

        /// <summary>仕入先電話番号2</summary>
        /// <remarks>FAXで使用</remarks>
        private string _supplierTelNo2 = "";

        /// <summary>純正区分</summary>
        /// <remarks>0:純正、1:優良</remarks>
        private Int32 _pureCode;

        /// <summary>支払月区分コード</summary>
        /// <remarks>0:当月 1:翌月 2:翌々月</remarks>
        private Int32 _paymentMonthCode;

        /// <summary>支払月区分名称</summary>
        /// <remarks>当月、翌月、翌々月</remarks>
        private string _paymentMonthName = "";

        /// <summary>支払日</summary>
        /// <remarks>DD</remarks>
        private Int32 _paymentDay;

        /// <summary>仕入先消費税転嫁方式参照区分</summary>
        /// <remarks>0:仕入在庫全体設定マスタ参照　1:得意先仕入情報マスタ参照</remarks>
        private Int32 _suppCTaxLayRefCd;

        /// <summary>仕入先消費税転嫁方式コード</summary>
        /// <remarks>0:伝票単位 1:明細単位 2:請求単位（請求先）3:請求単位（得意先）9:非課税</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>仕入先課税方式コード</summary>
        /// <remarks>0:課税 1:非課税</remarks>
        private Int32 _suppCTaxationCd;

        /// <summary>仕入先企業コード</summary>
        private string _suppEnterpriseCd = "";

        /// <summary>支払先コード</summary>
        private Int32 _payeeCode;

        /// <summary>仕入先属性区分</summary>
        /// <remarks>0:正式取引先,8:社内取引先,9:諸口口座</remarks>
        private Int32 _supplierAttributeDiv;

        /// <summary>仕入先総額表示方法区分</summary>
        /// <remarks>０総額表示しない（税抜き） 1:総額表示する（税込み）</remarks>
        private Int32 _suppTtlAmntDspWayCd;

        /// <summary>仕入時総額表示方法参照区分</summary>
        /// <remarks>0:全体設定参照 1:仕入先参照</remarks>
        private Int32 _stckTtlAmntDspWayRef;

        /// <summary>支払条件</summary>
        /// <remarks>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</remarks>
        private Int32 _paymentCond;

        /// <summary>支払締日</summary>
        private Int32 _paymentTotalDay;

        /// <summary>支払サイト</summary>
        /// <remarks>手形サイト　180等</remarks>
        private Int32 _paymentSight;

        /// <summary>仕入担当者コード</summary>
        private string _stockAgentCode = "";

        /// <summary>仕入単価端数処理コード</summary>
        private Int32 _stockUnPrcFrcProcCd;

        /// <summary>仕入金額端数処理コード</summary>
        private Int32 _stockMoneyFrcProcCd;

        /// <summary>仕入消費税端数処理コード</summary>
        private Int32 _stockCnsTaxFrcProcCd;

        /// <summary>次回勘定開始日</summary>
        /// <remarks>01～31まで（省略可能）</remarks>
        private Int32 _nTimeCalcStDate;

        /// <summary>仕入先備考1</summary>
        private string _supplierNote1 = "";

        /// <summary>仕入先備考2</summary>
        private string _supplierNote2 = "";

        /// <summary>仕入先備考3</summary>
        private string _supplierNote3 = "";

        /// <summary>仕入先備考4</summary>
        private string _supplierNote4 = "";

        /// <summary>仕入担当者名称</summary>
        /// <remarks>従業員マスタ</remarks>
        private string _stockAgentName = "";

        /// <summary>管理拠点名称</summary>
        /// <remarks>拠点マスタ</remarks>
        private string _mngSectionName = "";

        /// <summary>入力拠点名称</summary>
        /// <remarks>拠点マスタ</remarks>
        private string _inpSectionName = "";

        /// <summary>支払拠点名称</summary>
        /// <remarks>拠点マスタ</remarks>
        private string _paymentSectionName = "";

        /// <summary>業種名称</summary>
        /// <remarks>ユーザーガイドマスタ (ユーザーガイド区分=33)</remarks>
        private string _businessTypeName = "";

        /// <summary>販売エリア名称</summary>
        /// <remarks>ユーザーガイドマスタ (ユーザーガイド区分=21)</remarks>
        private string _salesAreaName = "";

        /// <summary>支払先名称</summary>
        /// <remarks>得意先コード=支払先コードによる自己結合</remarks>
        private string _payeeName = "";

        /// <summary>支払先名称２</summary>
        /// <remarks>得意先コード=支払先コードによる自己結合</remarks>
        private string _payeeName2 = "";

        /// <summary>支払先略称</summary>
        /// <remarks>得意先コード=支払先コードによる自己結合</remarks>
        private string _payeeSnm = "";


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

        /// public propaty name  :  MngSectionCode
        /// <summary>管理拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        /// public propaty name  :  InpSectionCode
        /// <summary>入力拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InpSectionCode
        {
            get { return _inpSectionCode; }
            set { _inpSectionCode = value; }
        }

        /// public propaty name  :  PaymentSectionCode
        /// <summary>支払拠点コードプロパティ</summary>
        /// <value>請求を行う拠点</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentSectionCode
        {
            get { return _paymentSectionCode; }
            set { _paymentSectionCode = value; }
        }

        /// public propaty name  :  SupplierNm1
        /// <summary>仕入先名1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierNm2
        /// <summary>仕入先名2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm2
        {
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
        }

        /// public propaty name  :  SuppHonorificTitle
        /// <summary>仕入先敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SuppHonorificTitle
        {
            get { return _suppHonorificTitle; }
            set { _suppHonorificTitle = value; }
        }

        /// public propaty name  :  SupplierKana
        /// <summary>仕入先カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierKana
        {
            get { return _supplierKana; }
            set { _supplierKana = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  OrderHonorificTtl
        /// <summary>発注書敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注書敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OrderHonorificTtl
        {
            get { return _orderHonorificTtl; }
            set { _orderHonorificTtl = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>業種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>販売エリアコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SupplierPostNo
        /// <summary>仕入先郵便番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierPostNo
        {
            get { return _supplierPostNo; }
            set { _supplierPostNo = value; }
        }

        /// public propaty name  :  SupplierAddr1
        /// <summary>仕入先住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierAddr1
        {
            get { return _supplierAddr1; }
            set { _supplierAddr1 = value; }
        }

        /// public propaty name  :  SupplierAddr3
        /// <summary>仕入先住所3（番地）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierAddr3
        {
            get { return _supplierAddr3; }
            set { _supplierAddr3 = value; }
        }

        /// public propaty name  :  SupplierAddr4
        /// <summary>仕入先住所4（アパート名称）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierAddr4
        {
            get { return _supplierAddr4; }
            set { _supplierAddr4 = value; }
        }

        /// public propaty name  :  SupplierTelNo
        /// <summary>仕入先電話番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先電話番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierTelNo
        {
            get { return _supplierTelNo; }
            set { _supplierTelNo = value; }
        }

        /// public propaty name  :  SupplierTelNo1
        /// <summary>仕入先電話番号1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先電話番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierTelNo1
        {
            get { return _supplierTelNo1; }
            set { _supplierTelNo1 = value; }
        }

        /// public propaty name  :  SupplierTelNo2
        /// <summary>仕入先電話番号2プロパティ</summary>
        /// <value>FAXで使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先電話番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierTelNo2
        {
            get { return _supplierTelNo2; }
            set { _supplierTelNo2 = value; }
        }

        /// public propaty name  :  PureCode
        /// <summary>純正区分プロパティ</summary>
        /// <value>0:純正、1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PureCode
        {
            get { return _pureCode; }
            set { _pureCode = value; }
        }

        /// public propaty name  :  PaymentMonthCode
        /// <summary>支払月区分コードプロパティ</summary>
        /// <value>0:当月 1:翌月 2:翌々月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払月区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentMonthCode
        {
            get { return _paymentMonthCode; }
            set { _paymentMonthCode = value; }
        }

        /// public propaty name  :  PaymentMonthName
        /// <summary>支払月区分名称プロパティ</summary>
        /// <value>当月、翌月、翌々月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払月区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentMonthName
        {
            get { return _paymentMonthName; }
            set { _paymentMonthName = value; }
        }

        /// public propaty name  :  PaymentDay
        /// <summary>支払日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentDay
        {
            get { return _paymentDay; }
            set { _paymentDay = value; }
        }

        /// public propaty name  :  SuppCTaxLayRefCd
        /// <summary>仕入先消費税転嫁方式参照区分プロパティ</summary>
        /// <value>0:仕入在庫全体設定マスタ参照　1:得意先仕入情報マスタ参照</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先消費税転嫁方式参照区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SuppCTaxLayRefCd
        {
            get { return _suppCTaxLayRefCd; }
            set { _suppCTaxLayRefCd = value; }
        }

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>仕入先消費税転嫁方式コードプロパティ</summary>
        /// <value>0:伝票単位 1:明細単位 2:請求単位（請求先）3:請求単位（得意先）9:非課税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先消費税転嫁方式コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SuppCTaxLayCd
        {
            get { return _suppCTaxLayCd; }
            set { _suppCTaxLayCd = value; }
        }

        /// public propaty name  :  SuppCTaxationCd
        /// <summary>仕入先課税方式コードプロパティ</summary>
        /// <value>0:課税 1:非課税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先課税方式コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SuppCTaxationCd
        {
            get { return _suppCTaxationCd; }
            set { _suppCTaxationCd = value; }
        }

        /// public propaty name  :  SuppEnterpriseCd
        /// <summary>仕入先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SuppEnterpriseCd
        {
            get { return _suppEnterpriseCd; }
            set { _suppEnterpriseCd = value; }
        }

        /// public propaty name  :  PayeeCode
        /// <summary>支払先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  SupplierAttributeDiv
        /// <summary>仕入先属性区分プロパティ</summary>
        /// <value>0:正式取引先,8:社内取引先,9:諸口口座</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先属性区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierAttributeDiv
        {
            get { return _supplierAttributeDiv; }
            set { _supplierAttributeDiv = value; }
        }

        /// public propaty name  :  SuppTtlAmntDspWayCd
        /// <summary>仕入先総額表示方法区分プロパティ</summary>
        /// <value>０総額表示しない（税抜き） 1:総額表示する（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先総額表示方法区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SuppTtlAmntDspWayCd
        {
            get { return _suppTtlAmntDspWayCd; }
            set { _suppTtlAmntDspWayCd = value; }
        }

        /// public propaty name  :  StckTtlAmntDspWayRef
        /// <summary>仕入時総額表示方法参照区分プロパティ</summary>
        /// <value>0:全体設定参照 1:仕入先参照</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入時総額表示方法参照区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StckTtlAmntDspWayRef
        {
            get { return _stckTtlAmntDspWayRef; }
            set { _stckTtlAmntDspWayRef = value; }
        }

        /// public propaty name  :  PaymentCond
        /// <summary>支払条件プロパティ</summary>
        /// <value>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払条件プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentCond
        {
            get { return _paymentCond; }
            set { _paymentCond = value; }
        }

        /// public propaty name  :  PaymentTotalDay
        /// <summary>支払締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentTotalDay
        {
            get { return _paymentTotalDay; }
            set { _paymentTotalDay = value; }
        }

        /// public propaty name  :  PaymentSight
        /// <summary>支払サイトプロパティ</summary>
        /// <value>手形サイト　180等</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払サイトプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentSight
        {
            get { return _paymentSight; }
            set { _paymentSight = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>仕入担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockUnPrcFrcProcCd
        /// <summary>仕入単価端数処理コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockUnPrcFrcProcCd
        {
            get { return _stockUnPrcFrcProcCd; }
            set { _stockUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  StockMoneyFrcProcCd
        /// <summary>仕入金額端数処理コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMoneyFrcProcCd
        {
            get { return _stockMoneyFrcProcCd; }
            set { _stockMoneyFrcProcCd = value; }
        }

        /// public propaty name  :  StockCnsTaxFrcProcCd
        /// <summary>仕入消費税端数処理コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入消費税端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockCnsTaxFrcProcCd
        {
            get { return _stockCnsTaxFrcProcCd; }
            set { _stockCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  NTimeCalcStDate
        /// <summary>次回勘定開始日プロパティ</summary>
        /// <value>01～31まで（省略可能）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   次回勘定開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NTimeCalcStDate
        {
            get { return _nTimeCalcStDate; }
            set { _nTimeCalcStDate = value; }
        }

        /// public propaty name  :  SupplierNote1
        /// <summary>仕入先備考1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNote1
        {
            get { return _supplierNote1; }
            set { _supplierNote1 = value; }
        }

        /// public propaty name  :  SupplierNote2
        /// <summary>仕入先備考2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先備考2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNote2
        {
            get { return _supplierNote2; }
            set { _supplierNote2 = value; }
        }

        /// public propaty name  :  SupplierNote3
        /// <summary>仕入先備考3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先備考3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNote3
        {
            get { return _supplierNote3; }
            set { _supplierNote3 = value; }
        }

        /// public propaty name  :  SupplierNote4
        /// <summary>仕入先備考4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先備考4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNote4
        {
            get { return _supplierNote4; }
            set { _supplierNote4 = value; }
        }

        /// public propaty name  :  StockAgentName
        /// <summary>仕入担当者名称プロパティ</summary>
        /// <value>従業員マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  MngSectionName
        /// <summary>管理拠点名称プロパティ</summary>
        /// <value>拠点マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionName
        {
            get { return _mngSectionName; }
            set { _mngSectionName = value; }
        }

        /// public propaty name  :  InpSectionName
        /// <summary>入力拠点名称プロパティ</summary>
        /// <value>拠点マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InpSectionName
        {
            get { return _inpSectionName; }
            set { _inpSectionName = value; }
        }

        /// public propaty name  :  PaymentSectionName
        /// <summary>支払拠点名称プロパティ</summary>
        /// <value>拠点マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentSectionName
        {
            get { return _paymentSectionName; }
            set { _paymentSectionName = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>業種名称プロパティ</summary>
        /// <value>ユーザーガイドマスタ (ユーザーガイド区分=33)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>販売エリア名称プロパティ</summary>
        /// <value>ユーザーガイドマスタ (ユーザーガイド区分=21)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリア名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  PayeeName
        /// <summary>支払先名称プロパティ</summary>
        /// <value>得意先コード=支払先コードによる自己結合</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
        }

        /// public propaty name  :  PayeeName2
        /// <summary>支払先名称２プロパティ</summary>
        /// <value>得意先コード=支払先コードによる自己結合</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先名称２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeName2
        {
            get { return _payeeName2; }
            set { _payeeName2 = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>支払先略称プロパティ</summary>
        /// <value>得意先コード=支払先コードによる自己結合</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
        }


        /// <summary>
        /// 仕入先ワークコンストラクタ
        /// </summary>
        /// <returns>SupplierWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SupplierWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SupplierWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SupplierWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SupplierWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SupplierWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SupplierWork || graph is ArrayList || graph is SupplierWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SupplierWork).FullName));

            if (graph != null && graph is SupplierWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SupplierWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SupplierWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SupplierWork[])graph).Length;
            }
            else if (graph is SupplierWork)
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
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //管理拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //MngSectionCode
            //入力拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InpSectionCode
            //支払拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //PaymentSectionCode
            //仕入先名1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //仕入先名2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //仕入先敬称
            serInfo.MemberInfo.Add(typeof(string)); //SuppHonorificTitle
            //仕入先カナ
            serInfo.MemberInfo.Add(typeof(string)); //SupplierKana
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //発注書敬称
            serInfo.MemberInfo.Add(typeof(string)); //OrderHonorificTtl
            //業種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //販売エリアコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //仕入先郵便番号
            serInfo.MemberInfo.Add(typeof(string)); //SupplierPostNo
            //仕入先住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add(typeof(string)); //SupplierAddr1
            //仕入先住所3（番地）
            serInfo.MemberInfo.Add(typeof(string)); //SupplierAddr3
            //仕入先住所4（アパート名称）
            serInfo.MemberInfo.Add(typeof(string)); //SupplierAddr4
            //仕入先電話番号
            serInfo.MemberInfo.Add(typeof(string)); //SupplierTelNo
            //仕入先電話番号1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierTelNo1
            //仕入先電話番号2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierTelNo2
            //純正区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PureCode
            //支払月区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentMonthCode
            //支払月区分名称
            serInfo.MemberInfo.Add(typeof(string)); //PaymentMonthName
            //支払日
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentDay
            //仕入先消費税転嫁方式参照区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayRefCd
            //仕入先消費税転嫁方式コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //仕入先課税方式コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxationCd
            //仕入先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //SuppEnterpriseCd
            //支払先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //仕入先属性区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierAttributeDiv
            //仕入先総額表示方法区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppTtlAmntDspWayCd
            //仕入時総額表示方法参照区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StckTtlAmntDspWayRef
            //支払条件
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentCond
            //支払締日
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentTotalDay
            //支払サイト
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentSight
            //仕入担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //仕入単価端数処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //StockUnPrcFrcProcCd
            //仕入金額端数処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoneyFrcProcCd
            //仕入消費税端数処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCnsTaxFrcProcCd
            //次回勘定開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //NTimeCalcStDate
            //仕入先備考1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNote1
            //仕入先備考2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNote2
            //仕入先備考3
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNote3
            //仕入先備考4
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNote4
            //仕入担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //管理拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //MngSectionName
            //入力拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //InpSectionName
            //支払拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //PaymentSectionName
            //業種名称
            serInfo.MemberInfo.Add(typeof(string)); //BusinessTypeName
            //販売エリア名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //支払先名称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName
            //支払先名称２
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName2
            //支払先略称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm


            serInfo.Serialize(writer, serInfo);
            if (graph is SupplierWork)
            {
                SupplierWork temp = (SupplierWork)graph;

                SetSupplierWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SupplierWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SupplierWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SupplierWork temp in lst)
                {
                    SetSupplierWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SupplierWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 60;

        /// <summary>
        ///  SupplierWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSupplierWork(System.IO.BinaryWriter writer, SupplierWork temp)
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
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //管理拠点コード
            writer.Write(temp.MngSectionCode);
            //入力拠点コード
            writer.Write(temp.InpSectionCode);
            //支払拠点コード
            writer.Write(temp.PaymentSectionCode);
            //仕入先名1
            writer.Write(temp.SupplierNm1);
            //仕入先名2
            writer.Write(temp.SupplierNm2);
            //仕入先敬称
            writer.Write(temp.SuppHonorificTitle);
            //仕入先カナ
            writer.Write(temp.SupplierKana);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //発注書敬称
            writer.Write(temp.OrderHonorificTtl);
            //業種コード
            writer.Write(temp.BusinessTypeCode);
            //販売エリアコード
            writer.Write(temp.SalesAreaCode);
            //仕入先郵便番号
            writer.Write(temp.SupplierPostNo);
            //仕入先住所1（都道府県市区郡・町村・字）
            writer.Write(temp.SupplierAddr1);
            //仕入先住所3（番地）
            writer.Write(temp.SupplierAddr3);
            //仕入先住所4（アパート名称）
            writer.Write(temp.SupplierAddr4);
            //仕入先電話番号
            writer.Write(temp.SupplierTelNo);
            //仕入先電話番号1
            writer.Write(temp.SupplierTelNo1);
            //仕入先電話番号2
            writer.Write(temp.SupplierTelNo2);
            //純正区分
            writer.Write(temp.PureCode);
            //支払月区分コード
            writer.Write(temp.PaymentMonthCode);
            //支払月区分名称
            writer.Write(temp.PaymentMonthName);
            //支払日
            writer.Write(temp.PaymentDay);
            //仕入先消費税転嫁方式参照区分
            writer.Write(temp.SuppCTaxLayRefCd);
            //仕入先消費税転嫁方式コード
            writer.Write(temp.SuppCTaxLayCd);
            //仕入先課税方式コード
            writer.Write(temp.SuppCTaxationCd);
            //仕入先企業コード
            writer.Write(temp.SuppEnterpriseCd);
            //支払先コード
            writer.Write(temp.PayeeCode);
            //仕入先属性区分
            writer.Write(temp.SupplierAttributeDiv);
            //仕入先総額表示方法区分
            writer.Write(temp.SuppTtlAmntDspWayCd);
            //仕入時総額表示方法参照区分
            writer.Write(temp.StckTtlAmntDspWayRef);
            //支払条件
            writer.Write(temp.PaymentCond);
            //支払締日
            writer.Write(temp.PaymentTotalDay);
            //支払サイト
            writer.Write(temp.PaymentSight);
            //仕入担当者コード
            writer.Write(temp.StockAgentCode);
            //仕入単価端数処理コード
            writer.Write(temp.StockUnPrcFrcProcCd);
            //仕入金額端数処理コード
            writer.Write(temp.StockMoneyFrcProcCd);
            //仕入消費税端数処理コード
            writer.Write(temp.StockCnsTaxFrcProcCd);
            //次回勘定開始日
            writer.Write(temp.NTimeCalcStDate);
            //仕入先備考1
            writer.Write(temp.SupplierNote1);
            //仕入先備考2
            writer.Write(temp.SupplierNote2);
            //仕入先備考3
            writer.Write(temp.SupplierNote3);
            //仕入先備考4
            writer.Write(temp.SupplierNote4);
            //仕入担当者名称
            writer.Write(temp.StockAgentName);
            //管理拠点名称
            writer.Write(temp.MngSectionName);
            //入力拠点名称
            writer.Write(temp.InpSectionName);
            //支払拠点名称
            writer.Write(temp.PaymentSectionName);
            //業種名称
            writer.Write(temp.BusinessTypeName);
            //販売エリア名称
            writer.Write(temp.SalesAreaName);
            //支払先名称
            writer.Write(temp.PayeeName);
            //支払先名称２
            writer.Write(temp.PayeeName2);
            //支払先略称
            writer.Write(temp.PayeeSnm);

        }

        /// <summary>
        ///  SupplierWorkインスタンス取得
        /// </summary>
        /// <returns>SupplierWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SupplierWork GetSupplierWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SupplierWork temp = new SupplierWork();

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
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //管理拠点コード
            temp.MngSectionCode = reader.ReadString();
            //入力拠点コード
            temp.InpSectionCode = reader.ReadString();
            //支払拠点コード
            temp.PaymentSectionCode = reader.ReadString();
            //仕入先名1
            temp.SupplierNm1 = reader.ReadString();
            //仕入先名2
            temp.SupplierNm2 = reader.ReadString();
            //仕入先敬称
            temp.SuppHonorificTitle = reader.ReadString();
            //仕入先カナ
            temp.SupplierKana = reader.ReadString();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //発注書敬称
            temp.OrderHonorificTtl = reader.ReadString();
            //業種コード
            temp.BusinessTypeCode = reader.ReadInt32();
            //販売エリアコード
            temp.SalesAreaCode = reader.ReadInt32();
            //仕入先郵便番号
            temp.SupplierPostNo = reader.ReadString();
            //仕入先住所1（都道府県市区郡・町村・字）
            temp.SupplierAddr1 = reader.ReadString();
            //仕入先住所3（番地）
            temp.SupplierAddr3 = reader.ReadString();
            //仕入先住所4（アパート名称）
            temp.SupplierAddr4 = reader.ReadString();
            //仕入先電話番号
            temp.SupplierTelNo = reader.ReadString();
            //仕入先電話番号1
            temp.SupplierTelNo1 = reader.ReadString();
            //仕入先電話番号2
            temp.SupplierTelNo2 = reader.ReadString();
            //純正区分
            temp.PureCode = reader.ReadInt32();
            //支払月区分コード
            temp.PaymentMonthCode = reader.ReadInt32();
            //支払月区分名称
            temp.PaymentMonthName = reader.ReadString();
            //支払日
            temp.PaymentDay = reader.ReadInt32();
            //仕入先消費税転嫁方式参照区分
            temp.SuppCTaxLayRefCd = reader.ReadInt32();
            //仕入先消費税転嫁方式コード
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //仕入先課税方式コード
            temp.SuppCTaxationCd = reader.ReadInt32();
            //仕入先企業コード
            temp.SuppEnterpriseCd = reader.ReadString();
            //支払先コード
            temp.PayeeCode = reader.ReadInt32();
            //仕入先属性区分
            temp.SupplierAttributeDiv = reader.ReadInt32();
            //仕入先総額表示方法区分
            temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
            //仕入時総額表示方法参照区分
            temp.StckTtlAmntDspWayRef = reader.ReadInt32();
            //支払条件
            temp.PaymentCond = reader.ReadInt32();
            //支払締日
            temp.PaymentTotalDay = reader.ReadInt32();
            //支払サイト
            temp.PaymentSight = reader.ReadInt32();
            //仕入担当者コード
            temp.StockAgentCode = reader.ReadString();
            //仕入単価端数処理コード
            temp.StockUnPrcFrcProcCd = reader.ReadInt32();
            //仕入金額端数処理コード
            temp.StockMoneyFrcProcCd = reader.ReadInt32();
            //仕入消費税端数処理コード
            temp.StockCnsTaxFrcProcCd = reader.ReadInt32();
            //次回勘定開始日
            temp.NTimeCalcStDate = reader.ReadInt32();
            //仕入先備考1
            temp.SupplierNote1 = reader.ReadString();
            //仕入先備考2
            temp.SupplierNote2 = reader.ReadString();
            //仕入先備考3
            temp.SupplierNote3 = reader.ReadString();
            //仕入先備考4
            temp.SupplierNote4 = reader.ReadString();
            //仕入担当者名称
            temp.StockAgentName = reader.ReadString();
            //管理拠点名称
            temp.MngSectionName = reader.ReadString();
            //入力拠点名称
            temp.InpSectionName = reader.ReadString();
            //支払拠点名称
            temp.PaymentSectionName = reader.ReadString();
            //業種名称
            temp.BusinessTypeName = reader.ReadString();
            //販売エリア名称
            temp.SalesAreaName = reader.ReadString();
            //支払先名称
            temp.PayeeName = reader.ReadString();
            //支払先名称２
            temp.PayeeName2 = reader.ReadString();
            //支払先略称
            temp.PayeeSnm = reader.ReadString();


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
        /// <returns>SupplierWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SupplierWork temp = GetSupplierWork(reader, serInfo);
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
                    retValue = (SupplierWork[])lst.ToArray(typeof(SupplierWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
