//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入チェックリスト
// プログラム概要   : 仕入チェックリスト帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/05/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockSlipCndtn
    /// <summary>
    ///                      仕入データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/03/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class StockSlipCndtn
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

        /// <summary>選択拠点コード</summary>
        private string[] _sectionCodeList;

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

        /// <summary>締日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _totalDay;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先名</summary>
        private string _supplierNm;

        /// <summary>チェック区分</summary>
        /// <remarks>チェック区分(0:PM/仕入先,1:仕入データ重複)</remarks>
        private CheckSectionDivState _checkSectionDiv;

        /// <summary>開始対象日付</summary>
        private DateTime _st_addUpDate;

        /// <summary>終了対象日付</summary>
        private DateTime _ed_addUpDate;

        /// <summary>開始対象日付</summary>
        private DateTime _st_addUpDateShow;

        /// <summary>終了対象日付</summary>
        private DateTime _ed_addUpDateShow;

        /// <summary>テキスト形式</summary>
        /// <remarks>テキスト形式(0:CSV,1:TAB)</remarks>
        private TextTypeDivState _txtStyle;

        /// <summary>仕入日チェック</summary>
        /// <remarks>仕入日チェック(0:なし,1:あり)</remarks>
        private SupDayCheckDivState _supDayCheckDiv;

        /// <summary>拠点チェック</summary>
        /// <remarks>拠点チェック(0:なし,1:あり)</remarks>
        private SectionCdCheckDivState _sectionCdCheckDiv;

        /// <summary>伝票番号チェック</summary>
        /// <remarks>伝票番号チェック(0:通常,1:上6桁のみ,2:下6桁のみ)</remarks>
        private SlipNumCheckDivState _slipNumCheckDiv;

        /// <summary>印刷区分</summary>
        /// <remarks>印刷区分(0:全て,1:不一致分,2:一致分)</remarks>
        private PrintDivState _printDiv;

        /// <summary>テキストファイル名</summary>
        private string _filePath = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>CSVのデータ</summary>
        private ArrayList _csvData;

        /// <summary>
        /// 拠点オプション区分
        /// </summary>
        private bool _isOptSection = false;

        /// <summary>
        /// 全拠点選択区分
        /// </summary>
        private bool _isSelectAllSection = false;

        /// <summary>一致分PM金額合計</summary>
        private long _samePmPrice = 0;
        /// <summary>不一致分PM金額合計</summary>
        private long _diffPmPrice = 0;
        /// <summary>一致分CSV金額合計</summary>
        private long _sameCsvPrice = 0;
        /// <summary>不一致分CSV金額合計</summary>
        private long _diffCsvPrice = 0;
        /// <summary>PM金額総合計</summary>
        private long _totalPmPrice = 0;
        /// <summary>CSV金額総合計</summary>
        private long _totalCsvPrice = 0;
        /// <summary>一致データFLG</summary>
        private bool _sameFlg = false;
        /// <summary>不一致データFLG</summary>
        private bool _diffFlg = false;


        /// <summary>
        /// 一致データFLGプロパティ
        /// </summary>
        public bool SameFlg
        {
            get { return this._sameFlg; }
            set { this._sameFlg = value; }
        }

        /// <summary>
        /// 不一致データFLGプロパティ
        /// </summary>
        public bool DiffFlg
        {
            get { return this._diffFlg; }
            set { this._diffFlg = value; }
        }

        /// <summary>
        /// 一致分PM金額合計プロパティ
        /// </summary>
        public long SamePmPrice
        {
            get { return this._samePmPrice; }
            set { this._samePmPrice = value; }
        }

        /// <summary>
        /// 不一致分PM金額合計プロパティ
        /// </summary>
        public long DiffPmPrice
        {
            get { return this._diffPmPrice; }
            set { this._diffPmPrice = value; }
        }

        /// <summary>
        /// 一致分CSV金額合計プロパティ
        /// </summary>
        public long SameCsvPrice
        {
            get { return this._sameCsvPrice; }
            set { this._sameCsvPrice = value; }
        }

        /// <summary>
        /// 不一致分CSV金額合計プロパティ
        /// </summary>
        public long DiffCsvPrice
        {
            get { return this._diffCsvPrice; }
            set { this._diffCsvPrice = value; }
        }

        /// <summary>
        /// PM総金額合計プロパティ
        /// </summary>
        public long TotalCsvPrice
        {
            get { return this._totalCsvPrice; }
            set { this._totalCsvPrice = value; }
        }

        /// <summary>
        /// CSV総金額合計プロパティ
        /// </summary>
        public long TotalPmPrice
        {
            get { return this._totalPmPrice; }
            set { this._totalPmPrice = value; }
        }


        /// <summary>
        /// 仕入先名プロパティ
        /// </summary>
        public string SupplierNm
        {
            get { return this._supplierNm; }
            set { this._supplierNm = value; }
        }

        /// <summary>
        /// CSVのデータプロパティ
        /// </summary>
        public ArrayList CsvData
        {
            get { return this._csvData; }
            set { this._csvData = value; }
        }


        /// <summary>
        /// 拠点オプション区分プロパティ
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }
        /// <summary>
        /// 全拠点選択区分プロパティ
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }

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

        /// public propaty name  :  SectionCodeList
        /// <summary>選択拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodeList
        {
            get { return _sectionCodeList; }
            set { _sectionCodeList = value; }
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

        /// public propaty name  :  TotalDay
        /// <summary>仕入日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  StockDateJpFormal
        /// <summary>仕入日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _totalDay); }
            set { }
        }

        /// public propaty name  :  StockDateJpInFormal
        /// <summary>仕入日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _totalDay); }
            set { }
        }

        /// public propaty name  :  StockDateAdFormal
        /// <summary>仕入日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _totalDay); }
            set { }
        }

        /// public propaty name  :  StockDateAdInFormal
        /// <summary>仕入日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _totalDay); }
            set { }
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

        /// public propaty name  :  CheckSectionDiv
        /// <summary>チェック区分プロパティ</summary>
        /// <value>チェック区分(0:仕入先,1:仕入データ重複)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェック区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CheckSectionDivState CheckSectionDiv
        {
            get { return _checkSectionDiv; }
            set { _checkSectionDiv = value; }
        }

        /// public propaty name  :  St_addUpDate
        /// <summary>開始対象日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_addUpDate
        {
            get { return _st_addUpDate; }
            set { _st_addUpDate = value; }
        }

        /// public propaty name  :  Ed_addUpDate
        /// <summary>終了対象日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_addUpDate
        {
            get { return _ed_addUpDate; }
            set { _ed_addUpDate = value; }
        }

        /// public propaty name  :  St_addUpDateShow
        /// <summary>開始対象日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_addUpDateShow
        {
            get { return _st_addUpDateShow; }
            set { _st_addUpDateShow = value; }
        }

        /// public propaty name  :  Ed_addUpDateShow
        /// <summary>終了対象日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_addUpDateShow
        {
            get { return _ed_addUpDateShow; }
            set { _ed_addUpDateShow = value; }
        }

        /// public propaty name  :  TxtStyle
        /// <summary>テキスト形式プロパティ</summary>
        /// <value>テキスト形式(0:CSV,1:TAB)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   テキスト形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TextTypeDivState TxtStyle
        {
            get { return _txtStyle; }
            set { _txtStyle = value; }
        }

        /// public propaty name  :  SupDayCheckDiv
        /// <summary>仕入日チェックプロパティ</summary>
        /// <value>仕入日チェック(0:なし,1:あり)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日チェックプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SupDayCheckDivState SupDayCheckDiv
        {
            get { return _supDayCheckDiv; }
            set { _supDayCheckDiv = value; }
        }

        /// public propaty name  :  SectionCdCheckDiv
        /// <summary>拠点チェックプロパティ</summary>
        /// <value>拠点チェック(0:なし,1:あり)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点チェックプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SectionCdCheckDivState SectionCdCheckDiv
        {
            get { return _sectionCdCheckDiv; }
            set { _sectionCdCheckDiv = value; }
        }

        /// public propaty name  :  SlipNumCheckDiv
        /// <summary>伝票番号チェックプロパティ</summary>
        /// <value>伝票番号チェック(0:通常,1:上6桁のみ,2:下6桁のみ)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票番号チェックプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SlipNumCheckDivState SlipNumCheckDiv
        {
            get { return _slipNumCheckDiv; }
            set { _slipNumCheckDiv = value; }
        }

        /// public propaty name  :  PrintDiv
        /// <summary>印刷区分プロパティ</summary>
        /// <value>印刷区分(0:全て,1:不一致分,2:一致分)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrintDivState PrintDiv
        {
            get { return _printDiv; }
            set { _printDiv = value; }
        }

        /// public propaty name  :  FilePath
        /// <summary>テキストファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   テキストファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
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
        /// 仕入データコンストラクタ
        /// </summary>
        /// <returns>StockSlipクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSlipクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockSlipCndtn()
        {
        }

        /// <summary>チェック区分 PM/仕入先</summary>
        public const string ct_CheckSectionDiv_PMSupplier = "ＰＭ／仕入先";
        /// <summary>チェック区分 仕入先データ重複</summary>
        public const string ct_CheckSectionDiv_SupplierDataRep = "仕入データ重複";

        /// <summary>
        /// チェック区分　列挙型
        /// </summary>
        public enum CheckSectionDivState
        {
            /// <summary>PM/仕入先</summary>
            PMSupplier = 0,
            /// <summary>仕入先データ重複</summary>
            SupplierDataRep = 1,
        }

        /// <summary>
        /// チェック区分　名称取得
        /// </summary>
        public string CheckSectionDivName
        {
            get
            {
                switch (this._checkSectionDiv)
                {
                    case CheckSectionDivState.PMSupplier:
                        return ct_CheckSectionDiv_PMSupplier;
                    case CheckSectionDivState.SupplierDataRep:
                        return ct_CheckSectionDiv_SupplierDataRep;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>テキスト形式 CSV</summary>
        public const string ct_TextTypeDiv_CSV = "CSV";
        /// <summary>テキスト形式 TAB</summary>
        public const string ct_TextTypeDiv_TAB = "TAB";

        /// <summary>
        /// テキスト形式　列挙型
        /// </summary>
        public enum TextTypeDivState
        {
            /// <summary>CSV</summary>
            CSV = 0,
            /// <summary>TAB</summary>
            TAB = 1,
        }

        /// <summary>
        /// テキスト形式　名称取得
        /// </summary>
        public string TextTypeDivName
        {
            get
            {
                switch (this._txtStyle)
                {
                    case TextTypeDivState.CSV:
                        return ct_TextTypeDiv_CSV;
                    case TextTypeDivState.TAB:
                        return ct_TextTypeDiv_TAB;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>チェック あり</summary>
        public const string ct_CheckDiv_Check = "あり";
        /// <summary>テキスト形式 なし</summary>
        public const string ct_CheckDiv_None = "なし";

        /// <summary>
        /// 仕入日チェック　列挙型
        /// </summary>
        public enum SupDayCheckDivState
        {
            /// <summary>あり</summary>
            Check = 1,
            /// <summary>なし</summary>
            None = 0,
        }

        /// <summary>
        /// 仕入日チェック　名称取得
        /// </summary>
        public string SupDayCheckDivName
        {
            get
            {
                switch (this._supDayCheckDiv)
                {
                    case SupDayCheckDivState.Check:
                        return ct_CheckDiv_Check;
                    case SupDayCheckDivState.None:
                        return ct_CheckDiv_None;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 拠点チェック　列挙型
        /// </summary>
        public enum SectionCdCheckDivState
        {
            /// <summary>あり</summary>
            Check = 1,
            /// <summary>なし</summary>
            None = 0,
        }

        /// <summary>
        /// 拠点チェック　名称取得
        /// </summary>
        public string SectionCdCheckDivName
        {
            get
            {
                switch (this._sectionCdCheckDiv)
                {
                    case SectionCdCheckDivState.Check:
                        return ct_CheckDiv_Check;
                    case SectionCdCheckDivState.None:
                        return ct_CheckDiv_None;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>伝票番号チェック 通常</summary>
        public const string ct_SlipNumCheckDiv_Normal = "通常";
        /// <summary>伝票番号チェック 上6桁のみ</summary>
        public const string ct_SlipNumCheckDiv_First6 = "上6桁のみ";
        /// <summary>伝票番号チェック 下6桁のみ</summary>
        public const string ct_SlipNumCheckDiv_Last6 = "下6桁のみ";

        /// <summary>
        /// 伝票番号チェック　列挙型
        /// </summary>
        public enum SlipNumCheckDivState
        {
            /// <summary>通常</summary>
            Normal = 0,
            /// <summary>上6桁のみ</summary>
            First6 = 1,
            /// <summary>下6桁のみ</summary>
            Last6 = 2,
        }

        /// <summary>
        /// 拠点チェック　名称取得
        /// </summary>
        public string SlipNumCheckDivName
        {
            get
            {
                switch (this._slipNumCheckDiv)
                {
                    case SlipNumCheckDivState.Normal:
                        return ct_SlipNumCheckDiv_Normal;
                    case SlipNumCheckDivState.First6:
                        return ct_SlipNumCheckDiv_First6;
                    case SlipNumCheckDivState.Last6:
                        return ct_SlipNumCheckDiv_Last6;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>印刷区分 全て</summary>
        public const string ct_PrintDiv_All = "全て";
        /// <summary>印刷区分 不一致分</summary>
        public const string ct_PrintDiv_Different = "不一致分";
        /// <summary>印刷区分 一致分</summary>
        public const string ct_PrintDiv_Same = "一致分";

        /// <summary>
        /// 印刷区分　列挙型
        /// </summary>
        public enum PrintDivState
        {
            /// <summary>全て</summary>
            All = 0,
            /// <summary>不一致分</summary>
            Different = 1,
            /// <summary>一致分</summary>
            Same = 2,
        }

        /// <summary>
        /// 印刷区分　名称取得
        /// </summary>
        public string PrintDivName
        {
            get
            {
                switch (this._printDiv)
                {
                    case PrintDivState.All:
                        return ct_PrintDiv_All;
                    case PrintDivState.Different:
                        return ct_PrintDiv_Different;
                    case PrintDivState.Same:
                        return ct_PrintDiv_Same;
                    default:
                        return string.Empty;
                }
            }
        }


    }
}
