using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Supplier
    /// <summary>
    ///                      仕入先マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2008/04/23  (CSharp File Generated Date)</br>
    /// <br>------------------------------------------------------------------</br>
    /// <br>Update Note      :   2008/05/01 22018 鈴木正臣</br>
    /// <br>                     各種区分名称(readonly string)を追加</br>
    /// <br>Update Note      :   2008/06/19 22018 鈴木正臣</br>
    /// <br>                     各種区分名称取得メソッドを追加(static)</br>
    /// <br>Update Note      :   2009/01/29 30414 忍幸史</br>
    /// <br>                     障害ID:10646対応</br>
    /// </remarks>
    public class Supplier
    {
        # region [（手動追加）]

        /// <summary>敬称　様</summary>
        public static readonly string CST_HonorificTitle_0 = "様";
        /// <summary>敬称　殿</summary>
        public static readonly string CST_HonorificTitle_1 = "殿";
        /// <summary>敬称　御中</summary>
        public static readonly string CST_HonorificTitle_2 = "御中";

        /// <summary>純正区分　純正</summary>
        public static readonly string CST_PureCode_0 = "純正";
        /// <summary>純正区分　優良</summary>
        public static readonly string CST_PureCode_1 = "優良";

        /// <summary>支払月区分　当月</summary>
        public static readonly string CST_PaymentMonthCode_0 = "当月";
        /// <summary>支払月区分　翌月</summary>
        public static readonly string CST_PaymentMonthCode_1 = "翌月";
        /// <summary>支払月区分　翌々月</summary>
        public static readonly string CST_PaymentMonthCode_2 = "翌々月";
        /// <summary>支払月区分　翌々々</summary>
        // --- CHG 2009/01/28 障害ID:10646対応------------------------------------------------------>>>>>
        //public static readonly string CST_PaymentMonthCode_3 = "翌々々";
        public static readonly string CST_PaymentMonthCode_3 = "翌々々月";
        // --- CHG 2009/01/28 障害ID:10646対応------------------------------------------------------<<<<<

        // 2009.02.19 30413 犬飼 得意先マスタと同様に、"税率設定参照"に修正 >>>>>>START
        ///// <summary>消費税転嫁方式参照区分　全体設定参照</summary>
        //public static readonly string CST_SuppCTaxLayRefCd_0 = "全体設定参照";
        /// <summary>消費税転嫁方式参照区分　税率設定参照</summary>
        public static readonly string CST_SuppCTaxLayRefCd_0 = "税率設定参照";
        // 2009.02.19 30413 犬飼 得意先マスタと同様に、"税率設定参照"に修正 <<<<<<END
        /// <summary>消費税転嫁方式参照区分　仕入先参照</summary>
        public static readonly string CST_SuppCTaxLayRefCd_1 = "仕入先参照";

        /// <summary>消費税転嫁方式区分　伝票単位</summary>
        public static readonly string CST_SuppCTaxLayCd_0 = "伝票単位";
        /// <summary>消費税転嫁方式区分　明細単位</summary>
        public static readonly string CST_SuppCTaxLayCd_1 = "明細単位";
        /// <summary>消費税転嫁方式区分　請求単位（請求先）</summary>
        public static readonly string CST_SuppCTaxLayCd_2 = "請求親";
        /// <summary>消費税転嫁方式区分　請求単位（得意先）</summary>
        public static readonly string CST_SuppCTaxLayCd_3 = "請求子";
        /// <summary>消費税転嫁方式区分　非課税</summary>
        public static readonly string CST_SuppCTaxLayCd_9 = "非課税";

        /// <summary>課税方式区分　課税</summary>
        public static readonly string CST_SuppCTaxationCd_0 = "課税";
        /// <summary>課税方式区分　非課税</summary>
        public static readonly string CST_SuppCTaxationCd_1 = "非課税";

        /// <summary>仕入先属性区分　正式取引先</summary>
        public static readonly string CST_SupplierAttributeDiv_0 = "正式取引先";
        /// <summary>仕入先属性区分　社内取引先</summary>
        public static readonly string CST_SupplierAttributeDiv_8 = "社内取引先";
        /// <summary>仕入先属性区分　諸口口座</summary>
        public static readonly string CST_SupplierAttributeDiv_9 = "諸口口座";

        /// <summary>総額表示区分　しない（税抜）</summary>
        public static readonly string CST_SuppTtlAmntDspWayCd_0 = "しない（税抜）";
        /// <summary>総額表示区分　する（税込）</summary>
        public static readonly string CST_SuppTtlAmntDspWayCd_1 = "する（税込）";

        /// <summary>総額表示参照区分　全体設定参照</summary>
        public static readonly string CST_StckTtlAmntDspWayRef_0 = "全体設定参照";
        /// <summary>総額表示参照区分　仕入先参照</summary>
        public static readonly string CST_StckTtlAmntDspWayRef_1 = "仕入先参照";

        /// <summary>支払条件　現金</summary>
        public static readonly string CST_PaymentCond_10 = "現金";
        /// <summary>支払条件　振込</summary>
        public static readonly string CST_PaymentCond_20 = "振込";
        /// <summary>支払条件　小切手</summary>
        public static readonly string CST_PaymentCond_30 = "小切手";
        /// <summary>支払条件　手形</summary>
        public static readonly string CST_PaymentCond_40 = "手形";
        /// <summary>支払条件　手数料</summary>
        public static readonly string CST_PaymentCond_50 = "手数料";
        /// <summary>支払条件　相殺</summary>
        public static readonly string CST_PaymentCond_60 = "相殺";
        /// <summary>支払条件　値引</summary>
        public static readonly string CST_PaymentCond_70 = "値引";
        /// <summary>支払条件　その他</summary>
        public static readonly string CST_PaymentCond_80 = "その他";

        # endregion

        # region [（自動生成）]
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
        /// <remarks>ユーザーガイド（33）</remarks>
        private string _businessTypeName = "";

        /// <summary>販売エリア名称</summary>
        /// <remarks>ユーザーガイド（21）</remarks>
        private string _salesAreaName = "";

        /// <summary>支払先名称</summary>
        /// <remarks>自己結合</remarks>
        private string _payeeName = "";

        /// <summary>支払先名称２</summary>
        /// <remarks>自己結合</remarks>
        private string _payeeName2 = "";

        /// <summary>支払先略称</summary>
        /// <remarks>自己結合</remarks>
        private string _payeeSnm = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>仕入先消費税転嫁方式名称</summary>
        /// <remarks>伝票単位、明細単位、請求単位</remarks>
        private string _suppCTaxLayMethodNm = "";


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
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _createDateTime ); }
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
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _createDateTime ); }
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
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _createDateTime ); }
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
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _createDateTime ); }
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
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _updateDateTime ); }
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
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _updateDateTime ); }
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
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _updateDateTime ); }
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
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _updateDateTime ); }
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
        /// <value>ユーザーガイド（33）</value>
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
        /// <value>ユーザーガイド（21）</value>
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
        /// <value>自己結合</value>
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
        /// <value>自己結合</value>
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
        /// <value>自己結合</value>
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

        /// public propaty name  :  SuppCTaxLayMethodNm
        /// <summary>仕入先消費税転嫁方式名称プロパティ</summary>
        /// <value>伝票単位、明細単位、請求単位</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先消費税転嫁方式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SuppCTaxLayMethodNm
        {
            get { return _suppCTaxLayMethodNm; }
            set { _suppCTaxLayMethodNm = value; }
        }


		/// <summary>
		/// 仕入先マスタコンストラクタ
		/// </summary>
		/// <returns>Supplierクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Supplierクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Supplier()
		{
		}
		/// <summary>
		/// 仕入先マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="supplierCd">仕入先コード</param>
		/// <param name="mngSectionCode">管理拠点コード</param>
		/// <param name="inpSectionCode">入力拠点コード</param>
		/// <param name="paymentSectionCode">支払拠点コード(請求を行う拠点)</param>
		/// <param name="supplierNm1">仕入先名1</param>
		/// <param name="supplierNm2">仕入先名2</param>
		/// <param name="suppHonorificTitle">仕入先敬称</param>
		/// <param name="supplierKana">仕入先カナ</param>
		/// <param name="supplierSnm">仕入先略称</param>
		/// <param name="orderHonorificTtl">発注書敬称</param>
		/// <param name="businessTypeCode">業種コード</param>
		/// <param name="salesAreaCode">販売エリアコード</param>
		/// <param name="supplierPostNo">仕入先郵便番号</param>
		/// <param name="supplierAddr1">仕入先住所1（都道府県市区郡・町村・字）</param>
		/// <param name="supplierAddr3">仕入先住所3（番地）</param>
		/// <param name="supplierAddr4">仕入先住所4（アパート名称）</param>
		/// <param name="supplierTelNo">仕入先電話番号</param>
		/// <param name="supplierTelNo1">仕入先電話番号1</param>
		/// <param name="supplierTelNo2">仕入先電話番号2(FAXで使用)</param>
		/// <param name="pureCode">純正区分(0:純正、1:優良)</param>
		/// <param name="paymentMonthCode">支払月区分コード(0:当月 1:翌月 2:翌々月)</param>
		/// <param name="paymentMonthName">支払月区分名称(当月、翌月、翌々月)</param>
		/// <param name="paymentDay">支払日(DD)</param>
		/// <param name="suppCTaxLayRefCd">仕入先消費税転嫁方式参照区分(0:仕入在庫全体設定マスタ参照　1:得意先仕入情報マスタ参照)</param>
		/// <param name="suppCTaxLayCd">仕入先消費税転嫁方式コード(0:伝票単位 1:明細単位 2:請求単位（請求先）3:請求単位（得意先）9:非課税)</param>
		/// <param name="suppCTaxationCd">仕入先課税方式コード(0:課税 1:非課税)</param>
		/// <param name="suppEnterpriseCd">仕入先企業コード</param>
		/// <param name="payeeCode">支払先コード</param>
		/// <param name="supplierAttributeDiv">仕入先属性区分(0:正式取引先,8:社内取引先,9:諸口口座)</param>
		/// <param name="suppTtlAmntDspWayCd">仕入先総額表示方法区分(０総額表示しない（税抜き） 1:総額表示する（税込み）)</param>
		/// <param name="stckTtlAmntDspWayRef">仕入時総額表示方法参照区分(0:全体設定参照 1:仕入先参照)</param>
		/// <param name="paymentCond">支払条件(10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他)</param>
		/// <param name="paymentTotalDay">支払締日</param>
		/// <param name="paymentSight">支払サイト(手形サイト　180等)</param>
		/// <param name="stockAgentCode">仕入担当者コード</param>
		/// <param name="stockUnPrcFrcProcCd">仕入単価端数処理コード</param>
		/// <param name="stockMoneyFrcProcCd">仕入金額端数処理コード</param>
		/// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード</param>
		/// <param name="nTimeCalcStDate">次回勘定開始日(01～31まで（省略可能）)</param>
		/// <param name="supplierNote1">仕入先備考1</param>
		/// <param name="supplierNote2">仕入先備考2</param>
		/// <param name="supplierNote3">仕入先備考3</param>
		/// <param name="supplierNote4">仕入先備考4</param>
		/// <param name="stockAgentName">仕入担当者名称(従業員マスタ)</param>
		/// <param name="mngSectionName">管理拠点名称(拠点マスタ)</param>
		/// <param name="inpSectionName">入力拠点名称(拠点マスタ)</param>
		/// <param name="paymentSectionName">支払拠点名称(拠点マスタ)</param>
		/// <param name="businessTypeName">業種名称(ユーザーガイド（33）)</param>
		/// <param name="salesAreaName">販売エリア名称(ユーザーガイド（21）)</param>
		/// <param name="payeeName">支払先名称(自己結合)</param>
		/// <param name="payeeName2">支払先名称２(自己結合)</param>
		/// <param name="payeeSnm">支払先略称(自己結合)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="suppCTaxLayMethodNm">仕入先消費税転嫁方式名称(伝票単位、明細単位、請求単位)</param>
		/// <returns>Supplierクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Supplierクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Supplier(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 supplierCd,string mngSectionCode,string inpSectionCode,string paymentSectionCode,string supplierNm1,string supplierNm2,string suppHonorificTitle,string supplierKana,string supplierSnm,string orderHonorificTtl,Int32 businessTypeCode,Int32 salesAreaCode,string supplierPostNo,string supplierAddr1,string supplierAddr3,string supplierAddr4,string supplierTelNo,string supplierTelNo1,string supplierTelNo2,Int32 pureCode,Int32 paymentMonthCode,string paymentMonthName,Int32 paymentDay,Int32 suppCTaxLayRefCd,Int32 suppCTaxLayCd,Int32 suppCTaxationCd,string suppEnterpriseCd,Int32 payeeCode,Int32 supplierAttributeDiv,Int32 suppTtlAmntDspWayCd,Int32 stckTtlAmntDspWayRef,Int32 paymentCond,Int32 paymentTotalDay,Int32 paymentSight,string stockAgentCode,Int32 stockUnPrcFrcProcCd,Int32 stockMoneyFrcProcCd,Int32 stockCnsTaxFrcProcCd,Int32 nTimeCalcStDate,string supplierNote1,string supplierNote2,string supplierNote3,string supplierNote4,string stockAgentName,string mngSectionName,string inpSectionName,string paymentSectionName,string businessTypeName,string salesAreaName,string payeeName,string payeeName2,string payeeSnm,string enterpriseName,string updEmployeeName,string suppCTaxLayMethodNm)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._supplierCd = supplierCd;
			this._mngSectionCode = mngSectionCode;
			this._inpSectionCode = inpSectionCode;
			this._paymentSectionCode = paymentSectionCode;
			this._supplierNm1 = supplierNm1;
			this._supplierNm2 = supplierNm2;
			this._suppHonorificTitle = suppHonorificTitle;
			this._supplierKana = supplierKana;
			this._supplierSnm = supplierSnm;
			this._orderHonorificTtl = orderHonorificTtl;
			this._businessTypeCode = businessTypeCode;
			this._salesAreaCode = salesAreaCode;
			this._supplierPostNo = supplierPostNo;
			this._supplierAddr1 = supplierAddr1;
			this._supplierAddr3 = supplierAddr3;
			this._supplierAddr4 = supplierAddr4;
			this._supplierTelNo = supplierTelNo;
			this._supplierTelNo1 = supplierTelNo1;
			this._supplierTelNo2 = supplierTelNo2;
			this._pureCode = pureCode;
			this._paymentMonthCode = paymentMonthCode;
			this._paymentMonthName = paymentMonthName;
			this._paymentDay = paymentDay;
			this._suppCTaxLayRefCd = suppCTaxLayRefCd;
			this._suppCTaxLayCd = suppCTaxLayCd;
			this._suppCTaxationCd = suppCTaxationCd;
			this._suppEnterpriseCd = suppEnterpriseCd;
			this._payeeCode = payeeCode;
			this._supplierAttributeDiv = supplierAttributeDiv;
			this._suppTtlAmntDspWayCd = suppTtlAmntDspWayCd;
			this._stckTtlAmntDspWayRef = stckTtlAmntDspWayRef;
			this._paymentCond = paymentCond;
			this._paymentTotalDay = paymentTotalDay;
			this._paymentSight = paymentSight;
			this._stockAgentCode = stockAgentCode;
			this._stockUnPrcFrcProcCd = stockUnPrcFrcProcCd;
			this._stockMoneyFrcProcCd = stockMoneyFrcProcCd;
			this._stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;
			this._nTimeCalcStDate = nTimeCalcStDate;
			this._supplierNote1 = supplierNote1;
			this._supplierNote2 = supplierNote2;
			this._supplierNote3 = supplierNote3;
			this._supplierNote4 = supplierNote4;
			this._stockAgentName = stockAgentName;
			this._mngSectionName = mngSectionName;
			this._inpSectionName = inpSectionName;
			this._paymentSectionName = paymentSectionName;
			this._businessTypeName = businessTypeName;
			this._salesAreaName = salesAreaName;
			this._payeeName = payeeName;
			this._payeeName2 = payeeName2;
			this._payeeSnm = payeeSnm;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._suppCTaxLayMethodNm = suppCTaxLayMethodNm;

		}

		/// <summary>
		/// 仕入先マスタ複製処理
		/// </summary>
		/// <returns>Supplierクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSupplierクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Supplier Clone()
		{
			return new Supplier(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._supplierCd,this._mngSectionCode,this._inpSectionCode,this._paymentSectionCode,this._supplierNm1,this._supplierNm2,this._suppHonorificTitle,this._supplierKana,this._supplierSnm,this._orderHonorificTtl,this._businessTypeCode,this._salesAreaCode,this._supplierPostNo,this._supplierAddr1,this._supplierAddr3,this._supplierAddr4,this._supplierTelNo,this._supplierTelNo1,this._supplierTelNo2,this._pureCode,this._paymentMonthCode,this._paymentMonthName,this._paymentDay,this._suppCTaxLayRefCd,this._suppCTaxLayCd,this._suppCTaxationCd,this._suppEnterpriseCd,this._payeeCode,this._supplierAttributeDiv,this._suppTtlAmntDspWayCd,this._stckTtlAmntDspWayRef,this._paymentCond,this._paymentTotalDay,this._paymentSight,this._stockAgentCode,this._stockUnPrcFrcProcCd,this._stockMoneyFrcProcCd,this._stockCnsTaxFrcProcCd,this._nTimeCalcStDate,this._supplierNote1,this._supplierNote2,this._supplierNote3,this._supplierNote4,this._stockAgentName,this._mngSectionName,this._inpSectionName,this._paymentSectionName,this._businessTypeName,this._salesAreaName,this._payeeName,this._payeeName2,this._payeeSnm,this._enterpriseName,this._updEmployeeName,this._suppCTaxLayMethodNm);
		}

		/// <summary>
		/// 仕入先マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のSupplierクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Supplierクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(Supplier target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.MngSectionCode == target.MngSectionCode)
				 && (this.InpSectionCode == target.InpSectionCode)
				 && (this.PaymentSectionCode == target.PaymentSectionCode)
				 && (this.SupplierNm1 == target.SupplierNm1)
				 && (this.SupplierNm2 == target.SupplierNm2)
				 && (this.SuppHonorificTitle == target.SuppHonorificTitle)
				 && (this.SupplierKana == target.SupplierKana)
				 && (this.SupplierSnm == target.SupplierSnm)
				 && (this.OrderHonorificTtl == target.OrderHonorificTtl)
				 && (this.BusinessTypeCode == target.BusinessTypeCode)
				 && (this.SalesAreaCode == target.SalesAreaCode)
				 && (this.SupplierPostNo == target.SupplierPostNo)
				 && (this.SupplierAddr1 == target.SupplierAddr1)
				 && (this.SupplierAddr3 == target.SupplierAddr3)
				 && (this.SupplierAddr4 == target.SupplierAddr4)
				 && (this.SupplierTelNo == target.SupplierTelNo)
				 && (this.SupplierTelNo1 == target.SupplierTelNo1)
				 && (this.SupplierTelNo2 == target.SupplierTelNo2)
				 && (this.PureCode == target.PureCode)
				 && (this.PaymentMonthCode == target.PaymentMonthCode)
				 && (this.PaymentMonthName == target.PaymentMonthName)
				 && (this.PaymentDay == target.PaymentDay)
				 && (this.SuppCTaxLayRefCd == target.SuppCTaxLayRefCd)
				 && (this.SuppCTaxLayCd == target.SuppCTaxLayCd)
				 && (this.SuppCTaxationCd == target.SuppCTaxationCd)
				 && (this.SuppEnterpriseCd == target.SuppEnterpriseCd)
				 && (this.PayeeCode == target.PayeeCode)
				 && (this.SupplierAttributeDiv == target.SupplierAttributeDiv)
				 && (this.SuppTtlAmntDspWayCd == target.SuppTtlAmntDspWayCd)
				 && (this.StckTtlAmntDspWayRef == target.StckTtlAmntDspWayRef)
				 && (this.PaymentCond == target.PaymentCond)
				 && (this.PaymentTotalDay == target.PaymentTotalDay)
				 && (this.PaymentSight == target.PaymentSight)
				 && (this.StockAgentCode == target.StockAgentCode)
				 && (this.StockUnPrcFrcProcCd == target.StockUnPrcFrcProcCd)
				 && (this.StockMoneyFrcProcCd == target.StockMoneyFrcProcCd)
				 && (this.StockCnsTaxFrcProcCd == target.StockCnsTaxFrcProcCd)
				 && (this.NTimeCalcStDate == target.NTimeCalcStDate)
				 && (this.SupplierNote1 == target.SupplierNote1)
				 && (this.SupplierNote2 == target.SupplierNote2)
				 && (this.SupplierNote3 == target.SupplierNote3)
				 && (this.SupplierNote4 == target.SupplierNote4)
				 && (this.StockAgentName == target.StockAgentName)
				 && (this.MngSectionName == target.MngSectionName)
				 && (this.InpSectionName == target.InpSectionName)
				 && (this.PaymentSectionName == target.PaymentSectionName)
				 && (this.BusinessTypeName == target.BusinessTypeName)
				 && (this.SalesAreaName == target.SalesAreaName)
				 && (this.PayeeName == target.PayeeName)
				 && (this.PayeeName2 == target.PayeeName2)
				 && (this.PayeeSnm == target.PayeeSnm)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.SuppCTaxLayMethodNm == target.SuppCTaxLayMethodNm));
		}

		/// <summary>
		/// 仕入先マスタ比較処理
		/// </summary>
		/// <param name="supplier1">
		///                    比較するSupplierクラスのインスタンス
		/// </param>
		/// <param name="supplier2">比較するSupplierクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Supplierクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(Supplier supplier1, Supplier supplier2)
		{
			return ((supplier1.CreateDateTime == supplier2.CreateDateTime)
				 && (supplier1.UpdateDateTime == supplier2.UpdateDateTime)
				 && (supplier1.EnterpriseCode == supplier2.EnterpriseCode)
				 && (supplier1.FileHeaderGuid == supplier2.FileHeaderGuid)
				 && (supplier1.UpdEmployeeCode == supplier2.UpdEmployeeCode)
				 && (supplier1.UpdAssemblyId1 == supplier2.UpdAssemblyId1)
				 && (supplier1.UpdAssemblyId2 == supplier2.UpdAssemblyId2)
				 && (supplier1.LogicalDeleteCode == supplier2.LogicalDeleteCode)
				 && (supplier1.SupplierCd == supplier2.SupplierCd)
				 && (supplier1.MngSectionCode == supplier2.MngSectionCode)
				 && (supplier1.InpSectionCode == supplier2.InpSectionCode)
				 && (supplier1.PaymentSectionCode == supplier2.PaymentSectionCode)
				 && (supplier1.SupplierNm1 == supplier2.SupplierNm1)
				 && (supplier1.SupplierNm2 == supplier2.SupplierNm2)
				 && (supplier1.SuppHonorificTitle == supplier2.SuppHonorificTitle)
				 && (supplier1.SupplierKana == supplier2.SupplierKana)
				 && (supplier1.SupplierSnm == supplier2.SupplierSnm)
				 && (supplier1.OrderHonorificTtl == supplier2.OrderHonorificTtl)
				 && (supplier1.BusinessTypeCode == supplier2.BusinessTypeCode)
				 && (supplier1.SalesAreaCode == supplier2.SalesAreaCode)
				 && (supplier1.SupplierPostNo == supplier2.SupplierPostNo)
				 && (supplier1.SupplierAddr1 == supplier2.SupplierAddr1)
				 && (supplier1.SupplierAddr3 == supplier2.SupplierAddr3)
				 && (supplier1.SupplierAddr4 == supplier2.SupplierAddr4)
				 && (supplier1.SupplierTelNo == supplier2.SupplierTelNo)
				 && (supplier1.SupplierTelNo1 == supplier2.SupplierTelNo1)
				 && (supplier1.SupplierTelNo2 == supplier2.SupplierTelNo2)
				 && (supplier1.PureCode == supplier2.PureCode)
				 && (supplier1.PaymentMonthCode == supplier2.PaymentMonthCode)
				 && (supplier1.PaymentMonthName == supplier2.PaymentMonthName)
				 && (supplier1.PaymentDay == supplier2.PaymentDay)
				 && (supplier1.SuppCTaxLayRefCd == supplier2.SuppCTaxLayRefCd)
				 && (supplier1.SuppCTaxLayCd == supplier2.SuppCTaxLayCd)
				 && (supplier1.SuppCTaxationCd == supplier2.SuppCTaxationCd)
				 && (supplier1.SuppEnterpriseCd == supplier2.SuppEnterpriseCd)
				 && (supplier1.PayeeCode == supplier2.PayeeCode)
				 && (supplier1.SupplierAttributeDiv == supplier2.SupplierAttributeDiv)
				 && (supplier1.SuppTtlAmntDspWayCd == supplier2.SuppTtlAmntDspWayCd)
				 && (supplier1.StckTtlAmntDspWayRef == supplier2.StckTtlAmntDspWayRef)
				 && (supplier1.PaymentCond == supplier2.PaymentCond)
				 && (supplier1.PaymentTotalDay == supplier2.PaymentTotalDay)
				 && (supplier1.PaymentSight == supplier2.PaymentSight)
				 && (supplier1.StockAgentCode == supplier2.StockAgentCode)
				 && (supplier1.StockUnPrcFrcProcCd == supplier2.StockUnPrcFrcProcCd)
				 && (supplier1.StockMoneyFrcProcCd == supplier2.StockMoneyFrcProcCd)
				 && (supplier1.StockCnsTaxFrcProcCd == supplier2.StockCnsTaxFrcProcCd)
				 && (supplier1.NTimeCalcStDate == supplier2.NTimeCalcStDate)
				 && (supplier1.SupplierNote1 == supplier2.SupplierNote1)
				 && (supplier1.SupplierNote2 == supplier2.SupplierNote2)
				 && (supplier1.SupplierNote3 == supplier2.SupplierNote3)
				 && (supplier1.SupplierNote4 == supplier2.SupplierNote4)
				 && (supplier1.StockAgentName == supplier2.StockAgentName)
				 && (supplier1.MngSectionName == supplier2.MngSectionName)
				 && (supplier1.InpSectionName == supplier2.InpSectionName)
				 && (supplier1.PaymentSectionName == supplier2.PaymentSectionName)
				 && (supplier1.BusinessTypeName == supplier2.BusinessTypeName)
				 && (supplier1.SalesAreaName == supplier2.SalesAreaName)
				 && (supplier1.PayeeName == supplier2.PayeeName)
				 && (supplier1.PayeeName2 == supplier2.PayeeName2)
				 && (supplier1.PayeeSnm == supplier2.PayeeSnm)
				 && (supplier1.EnterpriseName == supplier2.EnterpriseName)
				 && (supplier1.UpdEmployeeName == supplier2.UpdEmployeeName)
				 && (supplier1.SuppCTaxLayMethodNm == supplier2.SuppCTaxLayMethodNm));
		}
		/// <summary>
		/// 仕入先マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のSupplierクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Supplierクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(Supplier target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.MngSectionCode != target.MngSectionCode)resList.Add("MngSectionCode");
			if(this.InpSectionCode != target.InpSectionCode)resList.Add("InpSectionCode");
			if(this.PaymentSectionCode != target.PaymentSectionCode)resList.Add("PaymentSectionCode");
			if(this.SupplierNm1 != target.SupplierNm1)resList.Add("SupplierNm1");
			if(this.SupplierNm2 != target.SupplierNm2)resList.Add("SupplierNm2");
			if(this.SuppHonorificTitle != target.SuppHonorificTitle)resList.Add("SuppHonorificTitle");
			if(this.SupplierKana != target.SupplierKana)resList.Add("SupplierKana");
			if(this.SupplierSnm != target.SupplierSnm)resList.Add("SupplierSnm");
			if(this.OrderHonorificTtl != target.OrderHonorificTtl)resList.Add("OrderHonorificTtl");
			if(this.BusinessTypeCode != target.BusinessTypeCode)resList.Add("BusinessTypeCode");
			if(this.SalesAreaCode != target.SalesAreaCode)resList.Add("SalesAreaCode");
			if(this.SupplierPostNo != target.SupplierPostNo)resList.Add("SupplierPostNo");
			if(this.SupplierAddr1 != target.SupplierAddr1)resList.Add("SupplierAddr1");
			if(this.SupplierAddr3 != target.SupplierAddr3)resList.Add("SupplierAddr3");
			if(this.SupplierAddr4 != target.SupplierAddr4)resList.Add("SupplierAddr4");
			if(this.SupplierTelNo != target.SupplierTelNo)resList.Add("SupplierTelNo");
			if(this.SupplierTelNo1 != target.SupplierTelNo1)resList.Add("SupplierTelNo1");
			if(this.SupplierTelNo2 != target.SupplierTelNo2)resList.Add("SupplierTelNo2");
			if(this.PureCode != target.PureCode)resList.Add("PureCode");
			if(this.PaymentMonthCode != target.PaymentMonthCode)resList.Add("PaymentMonthCode");
			if(this.PaymentMonthName != target.PaymentMonthName)resList.Add("PaymentMonthName");
			if(this.PaymentDay != target.PaymentDay)resList.Add("PaymentDay");
			if(this.SuppCTaxLayRefCd != target.SuppCTaxLayRefCd)resList.Add("SuppCTaxLayRefCd");
			if(this.SuppCTaxLayCd != target.SuppCTaxLayCd)resList.Add("SuppCTaxLayCd");
			if(this.SuppCTaxationCd != target.SuppCTaxationCd)resList.Add("SuppCTaxationCd");
			if(this.SuppEnterpriseCd != target.SuppEnterpriseCd)resList.Add("SuppEnterpriseCd");
			if(this.PayeeCode != target.PayeeCode)resList.Add("PayeeCode");
			if(this.SupplierAttributeDiv != target.SupplierAttributeDiv)resList.Add("SupplierAttributeDiv");
			if(this.SuppTtlAmntDspWayCd != target.SuppTtlAmntDspWayCd)resList.Add("SuppTtlAmntDspWayCd");
			if(this.StckTtlAmntDspWayRef != target.StckTtlAmntDspWayRef)resList.Add("StckTtlAmntDspWayRef");
			if(this.PaymentCond != target.PaymentCond)resList.Add("PaymentCond");
			if(this.PaymentTotalDay != target.PaymentTotalDay)resList.Add("PaymentTotalDay");
			if(this.PaymentSight != target.PaymentSight)resList.Add("PaymentSight");
			if(this.StockAgentCode != target.StockAgentCode)resList.Add("StockAgentCode");
			if(this.StockUnPrcFrcProcCd != target.StockUnPrcFrcProcCd)resList.Add("StockUnPrcFrcProcCd");
			if(this.StockMoneyFrcProcCd != target.StockMoneyFrcProcCd)resList.Add("StockMoneyFrcProcCd");
			if(this.StockCnsTaxFrcProcCd != target.StockCnsTaxFrcProcCd)resList.Add("StockCnsTaxFrcProcCd");
			if(this.NTimeCalcStDate != target.NTimeCalcStDate)resList.Add("NTimeCalcStDate");
			if(this.SupplierNote1 != target.SupplierNote1)resList.Add("SupplierNote1");
			if(this.SupplierNote2 != target.SupplierNote2)resList.Add("SupplierNote2");
			if(this.SupplierNote3 != target.SupplierNote3)resList.Add("SupplierNote3");
			if(this.SupplierNote4 != target.SupplierNote4)resList.Add("SupplierNote4");
			if(this.StockAgentName != target.StockAgentName)resList.Add("StockAgentName");
			if(this.MngSectionName != target.MngSectionName)resList.Add("MngSectionName");
			if(this.InpSectionName != target.InpSectionName)resList.Add("InpSectionName");
			if(this.PaymentSectionName != target.PaymentSectionName)resList.Add("PaymentSectionName");
			if(this.BusinessTypeName != target.BusinessTypeName)resList.Add("BusinessTypeName");
			if(this.SalesAreaName != target.SalesAreaName)resList.Add("SalesAreaName");
			if(this.PayeeName != target.PayeeName)resList.Add("PayeeName");
			if(this.PayeeName2 != target.PayeeName2)resList.Add("PayeeName2");
			if(this.PayeeSnm != target.PayeeSnm)resList.Add("PayeeSnm");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.SuppCTaxLayMethodNm != target.SuppCTaxLayMethodNm)resList.Add("SuppCTaxLayMethodNm");

			return resList;
		}

		/// <summary>
		/// 仕入先マスタ比較処理
		/// </summary>
		/// <param name="supplier1">比較するSupplierクラスのインスタンス</param>
		/// <param name="supplier2">比較するSupplierクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Supplierクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(Supplier supplier1, Supplier supplier2)
		{
			ArrayList resList = new ArrayList();
			if(supplier1.CreateDateTime != supplier2.CreateDateTime)resList.Add("CreateDateTime");
			if(supplier1.UpdateDateTime != supplier2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(supplier1.EnterpriseCode != supplier2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(supplier1.FileHeaderGuid != supplier2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(supplier1.UpdEmployeeCode != supplier2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(supplier1.UpdAssemblyId1 != supplier2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(supplier1.UpdAssemblyId2 != supplier2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(supplier1.LogicalDeleteCode != supplier2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(supplier1.SupplierCd != supplier2.SupplierCd)resList.Add("SupplierCd");
			if(supplier1.MngSectionCode != supplier2.MngSectionCode)resList.Add("MngSectionCode");
			if(supplier1.InpSectionCode != supplier2.InpSectionCode)resList.Add("InpSectionCode");
			if(supplier1.PaymentSectionCode != supplier2.PaymentSectionCode)resList.Add("PaymentSectionCode");
			if(supplier1.SupplierNm1 != supplier2.SupplierNm1)resList.Add("SupplierNm1");
			if(supplier1.SupplierNm2 != supplier2.SupplierNm2)resList.Add("SupplierNm2");
			if(supplier1.SuppHonorificTitle != supplier2.SuppHonorificTitle)resList.Add("SuppHonorificTitle");
			if(supplier1.SupplierKana != supplier2.SupplierKana)resList.Add("SupplierKana");
			if(supplier1.SupplierSnm != supplier2.SupplierSnm)resList.Add("SupplierSnm");
			if(supplier1.OrderHonorificTtl != supplier2.OrderHonorificTtl)resList.Add("OrderHonorificTtl");
			if(supplier1.BusinessTypeCode != supplier2.BusinessTypeCode)resList.Add("BusinessTypeCode");
			if(supplier1.SalesAreaCode != supplier2.SalesAreaCode)resList.Add("SalesAreaCode");
			if(supplier1.SupplierPostNo != supplier2.SupplierPostNo)resList.Add("SupplierPostNo");
			if(supplier1.SupplierAddr1 != supplier2.SupplierAddr1)resList.Add("SupplierAddr1");
			if(supplier1.SupplierAddr3 != supplier2.SupplierAddr3)resList.Add("SupplierAddr3");
			if(supplier1.SupplierAddr4 != supplier2.SupplierAddr4)resList.Add("SupplierAddr4");
			if(supplier1.SupplierTelNo != supplier2.SupplierTelNo)resList.Add("SupplierTelNo");
			if(supplier1.SupplierTelNo1 != supplier2.SupplierTelNo1)resList.Add("SupplierTelNo1");
			if(supplier1.SupplierTelNo2 != supplier2.SupplierTelNo2)resList.Add("SupplierTelNo2");
			if(supplier1.PureCode != supplier2.PureCode)resList.Add("PureCode");
			if(supplier1.PaymentMonthCode != supplier2.PaymentMonthCode)resList.Add("PaymentMonthCode");
			if(supplier1.PaymentMonthName != supplier2.PaymentMonthName)resList.Add("PaymentMonthName");
			if(supplier1.PaymentDay != supplier2.PaymentDay)resList.Add("PaymentDay");
			if(supplier1.SuppCTaxLayRefCd != supplier2.SuppCTaxLayRefCd)resList.Add("SuppCTaxLayRefCd");
			if(supplier1.SuppCTaxLayCd != supplier2.SuppCTaxLayCd)resList.Add("SuppCTaxLayCd");
			if(supplier1.SuppCTaxationCd != supplier2.SuppCTaxationCd)resList.Add("SuppCTaxationCd");
			if(supplier1.SuppEnterpriseCd != supplier2.SuppEnterpriseCd)resList.Add("SuppEnterpriseCd");
			if(supplier1.PayeeCode != supplier2.PayeeCode)resList.Add("PayeeCode");
			if(supplier1.SupplierAttributeDiv != supplier2.SupplierAttributeDiv)resList.Add("SupplierAttributeDiv");
			if(supplier1.SuppTtlAmntDspWayCd != supplier2.SuppTtlAmntDspWayCd)resList.Add("SuppTtlAmntDspWayCd");
			if(supplier1.StckTtlAmntDspWayRef != supplier2.StckTtlAmntDspWayRef)resList.Add("StckTtlAmntDspWayRef");
			if(supplier1.PaymentCond != supplier2.PaymentCond)resList.Add("PaymentCond");
			if(supplier1.PaymentTotalDay != supplier2.PaymentTotalDay)resList.Add("PaymentTotalDay");
			if(supplier1.PaymentSight != supplier2.PaymentSight)resList.Add("PaymentSight");
			if(supplier1.StockAgentCode != supplier2.StockAgentCode)resList.Add("StockAgentCode");
			if(supplier1.StockUnPrcFrcProcCd != supplier2.StockUnPrcFrcProcCd)resList.Add("StockUnPrcFrcProcCd");
			if(supplier1.StockMoneyFrcProcCd != supplier2.StockMoneyFrcProcCd)resList.Add("StockMoneyFrcProcCd");
			if(supplier1.StockCnsTaxFrcProcCd != supplier2.StockCnsTaxFrcProcCd)resList.Add("StockCnsTaxFrcProcCd");
			if(supplier1.NTimeCalcStDate != supplier2.NTimeCalcStDate)resList.Add("NTimeCalcStDate");
			if(supplier1.SupplierNote1 != supplier2.SupplierNote1)resList.Add("SupplierNote1");
			if(supplier1.SupplierNote2 != supplier2.SupplierNote2)resList.Add("SupplierNote2");
			if(supplier1.SupplierNote3 != supplier2.SupplierNote3)resList.Add("SupplierNote3");
			if(supplier1.SupplierNote4 != supplier2.SupplierNote4)resList.Add("SupplierNote4");
			if(supplier1.StockAgentName != supplier2.StockAgentName)resList.Add("StockAgentName");
			if(supplier1.MngSectionName != supplier2.MngSectionName)resList.Add("MngSectionName");
			if(supplier1.InpSectionName != supplier2.InpSectionName)resList.Add("InpSectionName");
			if(supplier1.PaymentSectionName != supplier2.PaymentSectionName)resList.Add("PaymentSectionName");
			if(supplier1.BusinessTypeName != supplier2.BusinessTypeName)resList.Add("BusinessTypeName");
			if(supplier1.SalesAreaName != supplier2.SalesAreaName)resList.Add("SalesAreaName");
			if(supplier1.PayeeName != supplier2.PayeeName)resList.Add("PayeeName");
			if(supplier1.PayeeName2 != supplier2.PayeeName2)resList.Add("PayeeName2");
			if(supplier1.PayeeSnm != supplier2.PayeeSnm)resList.Add("PayeeSnm");
			if(supplier1.EnterpriseName != supplier2.EnterpriseName)resList.Add("EnterpriseName");
			if(supplier1.UpdEmployeeName != supplier2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(supplier1.SuppCTaxLayMethodNm != supplier2.SuppCTaxLayMethodNm)resList.Add("SuppCTaxLayMethodNm");

			return resList;
        }
        # endregion

        # region [（手動追加）]
        /// <summary>
        /// 敬称　取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetHonorificTitle( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_HonorificTitle_0;
                case 1:
                    return CST_HonorificTitle_1;
                case 2:
                    return CST_HonorificTitle_2;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 純正区分　名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetPureCodeName( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_PureCode_0;
                case 1:
                    return CST_PureCode_1;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 支払月区分　名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetPaymentMonthCodeName( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_PaymentMonthCode_0;
                case 1:
                    return CST_PaymentMonthCode_1;
                case 2:
                    return CST_PaymentMonthCode_2;
                case 3:
                    return CST_PaymentMonthCode_3;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 消費税転嫁方式参照区分　名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetSuppCTaxLayRefCdName( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_SuppCTaxLayRefCd_0;
                case 1:
                    return CST_SuppCTaxLayRefCd_1;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 消費税転嫁方式区分　名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetSuppCTaxLayCdName( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_SuppCTaxLayCd_0;
                case 1:
                    return CST_SuppCTaxLayCd_1;
                case 2:
                    return CST_SuppCTaxLayCd_2;
                case 3:
                    return CST_SuppCTaxLayCd_3;
                case 9:
                    return CST_SuppCTaxLayCd_9;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 課税方式区分 名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetSuppCTaxationCdName( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_SuppCTaxationCd_0;
                case 1:
                    return CST_SuppCTaxationCd_1;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 仕入先属性区分 名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetSupplierAttributeDivName( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_SupplierAttributeDiv_0;
                case 8:
                    return CST_SupplierAttributeDiv_8;
                case 9:
                    return CST_SupplierAttributeDiv_9;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 総額表示区分 名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetSuppTtlAmntDspWayCdName( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_SuppTtlAmntDspWayCd_0;
                case 1:
                    return CST_SuppTtlAmntDspWayCd_1;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 総額表示参照区分 名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetStckTtlAmntDspWayRefName( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_StckTtlAmntDspWayRef_0;
                case 1:
                    return CST_StckTtlAmntDspWayRef_1;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 支払条件 名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetPaymentCondName( int code )
        {
            switch ( code )
            {
                case 10:
                    return CST_PaymentCond_10;
                case 20:
                    return CST_PaymentCond_20;
                case 30:
                    return CST_PaymentCond_30;
                case 40:
                    return CST_PaymentCond_40;
                case 50:
                    return CST_PaymentCond_50;
                case 60:
                    return CST_PaymentCond_60;
                case 70:
                    return CST_PaymentCond_70;
                case 80:
                    return CST_PaymentCond_80;
                default:
                    return string.Empty;
            }
        }
        # endregion
    }
}
