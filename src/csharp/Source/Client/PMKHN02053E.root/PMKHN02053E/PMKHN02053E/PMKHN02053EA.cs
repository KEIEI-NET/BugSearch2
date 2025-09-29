//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン実績表
// プログラム概要   : キャンペーン実績表　条件クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/05/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Campaignst
    /// <summary>
    ///  キャンペーン実績表　条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   キャンペーン実績表ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/05/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CampaignRsltList
    {
        # region ■ private field ■

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

        // <summary>集計単位</summary>
        /// <remarks>0:商品別 1:得意先別 2:担当者別</remarks>
        private TotalTypeState _totalType;

        /// <summary>キャンペーン実施拠点</summary>
        private string _campexecSecCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>文字型　※配列項目</remarks>
        private string[] _sectionCodes;

        /// <summary>キャンペーンコード</summary>
        private Int32 _campaignCode;

        /// <summary>キャンペーン名称</summary>
        private string _campaignName = "";

        /// <summary>キャンペーン対象区分</summary>
        /// <remarks>0:全得意先,1:対象得意先,9:中止</remarks>
        private Int32 _campaignObjDiv;

        /// <summary>適用開始日</summary>
        private Int32 _applyStaDate;

        /// <summary>適用終了日</summary>
        private Int32 _applyEndDate;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>開始得意先コード</summary>
        private Int32 _customerCodeSt;

        /// <summary>終了得意先コード</summary>
        private Int32 _customerCodeEd;

        /// <summary>開始従業員コード</summary>
        private string _employeeCodeSt = "";

        /// <summary>終了従業員コード</summary>
        private string _employeeCodeEd = "";

        /// <summary>開始受注者コード</summary>
        private string _acceptOdrCodeSt = "";

        /// <summary>終了受注者コード</summary>
        private string _acceptOdrCodeEd = "";

        /// <summary>開始発行者コード</summary>
        private string _printerCodeSt = "";

        /// <summary>終了発行者コード</summary>
        private string _printerCodeEd = "";

        /// <summary>開始商品メーカーコード</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>終了商品メーカーコード</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>開始商品中分類コード</summary>
        private Int32 _goodsMGroupSt;

        /// <summary>終了商品中分類コード</summary>
        private Int32 _goodsMGroupEd;

        /// <summary>開始BLグループコード</summary>
        private Int32 _bLGroupCodeSt;

        /// <summary>終了BLグループコード</summary>
        private Int32 _bLGroupCodeEd;

        /// <summary>開始BL商品コード</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>終了BL商品コード</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>開始商品番号</summary>
        private string _goodsNoSt = "";

        /// <summary>終了商品番号</summary>
        private string _goodsNoEd = "";

        /// <summary>改頁(拠点毎で改頁)</summary>
        /// <remarks>0:なし 1:あり</remarks>
        private Int32 _crModeSec;

        /// <summary>改頁(担当者毎で改頁)</summary>
        /// <remarks>0:なし 1:あり</remarks>
        private Int32 _crModeEmp;

        /// <summary>改頁(地区毎で改頁)</summary>
        /// <remarks>0:なし 1:あり</remarks>
        private Int32 _crModeArea;

        /// <summary>開始地区コード</summary>
        private Int32 _areaCodeSt;

        /// <summary>終了地区コード</summary>
        private Int32 _areaCodeEd;

        /// <summary>開始対象日付</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonthSt;

        /// <summary>終了対象日付</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonthEd;

        /// <summary>開始対象日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpYearMonthDaySt;

        /// <summary>終了対象日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpYearMonthDayEd;

        /// <summary>出力順</summary>
        /// <remarks>0:グループコード,1:BLコード</remarks>
        private Int32 _outputSort;

        /// <summary>印刷順</summary>
        /// <remarks>0：品番＋メーカー,1：メーカー＋品番</remarks>
        private Int32 _printSort;

        /// <summary>印刷タイプ</summary>
        /// <remarks>0:当月,1:期間,3:日付</remarks>
        private Int32 _printType;

        /// <summary>明細単位</summary>
        /// <remarks>0：品番、1：BLｺｰﾄﾞ、2：ｸﾞﾙｰﾌﾟｺｰﾄﾞ</remarks>
        private Int32 _detail;

        /// <summary>小計単位</summary>
        /// <remarks>0：ｸﾞﾙｰﾌﾟｺｰﾄﾞ、1：BLｺｰﾄﾞ</remarks>
        private Int32 _total;

        /// <summary>開始販売区分コード</summary>
        private Int32 _salesCodeSt;

        /// <summary>終了販売区分コード</summary>
        private Int32 _salesCodeEd;

        # endregion  ■ private field ■

        # region ■ public propaty ■

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

        /// public propaty name  :  TotalType
        /// <summary>帳票集計区分プロパティ</summary>
        /// <value>0:商品別／1:得意先別／2:担当者別／3:倉庫別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票集計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TotalTypeState TotalType
        {
            get { return _totalType; }
            set { _totalType = value; }
        }

        /// public propaty name  :  CampexecSecCode
        /// <summary>キャンペーン実施拠点プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン実施拠点プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CampexecSecCode
        {
            get { return _campexecSecCode; }
            set { _campexecSecCode = value; }
        }

        /// public propaty name  :  SectionCodes
        /// <summary>拠点コードプロパティ</summary>
        /// <value>文字型　※配列項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  CampaignCode
        /// <summary>キャンペーンコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーンコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  CampaignName
        /// <summary>キャンペーン名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CampaignName
        {
            get { return _campaignName; }
            set { _campaignName = value; }
        }

        /// public propaty name  :  CampaignObjDiv
        /// <summary>キャンペーン対象区分プロパティ</summary>
        /// <value>0:全得意先,1:対象得意先,9:中止</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン対象区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignObjDiv
        {
            get { return _campaignObjDiv; }
            set { _campaignObjDiv = value; }
        }

        /// public propaty name  :  ApplyStaDate
        /// <summary>適用開始日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>適用終了日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
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

        // public propaty name  :  CustomerCodeSt
        /// <summary>開始得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        // public propaty name  :  CustomerCodeEd
        /// <summary>終了得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  EmployeeCodeSt
        /// <summary>開始従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCodeSt
        {
            get { return _employeeCodeSt; }
            set { _employeeCodeSt = value; }
        }

        /// public propaty name  :  EmployeeCodeEd
        /// <summary>終了従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCodeEd
        {
            get { return _employeeCodeEd; }
            set { _employeeCodeEd = value; }
        }

        /// public propaty name  :  AcceptOdrCodeSt
        /// <summary>開始受注者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始受注者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AcceptOdrCodeSt
        {
            get { return _acceptOdrCodeSt; }
            set { _acceptOdrCodeSt = value; }
        }

        /// public propaty name  :  AcceptOdrCodeEd
        /// <summary>終了受注者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了受注者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AcceptOdrCodeEd
        {
            get { return _acceptOdrCodeEd; }
            set { _acceptOdrCodeEd = value; }
        }

        /// public propaty name  :  PrinterCodeSt
        /// <summary>開始発行者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了受注者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrinterCodeSt
        {
            get { return _printerCodeSt; }
            set { _printerCodeSt = value; }
        }

        /// public propaty name  :  PrinterCodeEd
        /// <summary>終了発行者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始受注者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrinterCodeEd
        {
            get { return _printerCodeEd; }
            set { _printerCodeEd = value; }
        }

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>開始商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>終了商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  GoodsMGroupSt
        /// <summary>開始商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroupSt
        {
            get { return _goodsMGroupSt; }
            set { _goodsMGroupSt = value; }
        }

        /// public propaty name  :  GoodsMGroupEd
        /// <summary>終了商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroupEd
        {
            get { return _goodsMGroupEd; }
            set { _goodsMGroupEd = value; }
        }

        /// public propaty name  :  BLGroupCodeSt
        /// <summary>開始BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeSt
        {
            get { return _bLGroupCodeSt; }
            set { _bLGroupCodeSt = value; }
        }

        /// public propaty name  :  BLGroupCodeEd
        /// <summary>終了BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>開始BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>終了BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  GoodsNoSt
        /// <summary>開始商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoSt
        {
            get { return _goodsNoSt; }
            set { _goodsNoSt = value; }
        }

        /// public propaty name  :  GoodsNoEd
        /// <summary>終了商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoEd
        {
            get { return _goodsNoEd; }
            set { _goodsNoEd = value; }
        }

        /// public propaty name  :  AddUpYearMonthSt
        /// <summary>開始対象年月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpYearMonthSt
        {
            get { return _addUpYearMonthSt; }
            set { _addUpYearMonthSt = value; }
        }

        /// public propaty name  :  AddUpYearMonthEd
        /// <summary>終了対象年月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpYearMonthEd
        {
            get { return _addUpYearMonthEd; }
            set { _addUpYearMonthEd = value; }
        }

        /// public propaty name  :  AddUpYearMonthDaySt
        /// <summary>開始対象年月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpYearMonthDaySt
        {
            get { return _addUpYearMonthDaySt; }
            set { _addUpYearMonthDaySt = value; }
        }

        /// public propaty name  :  AddUpYearMonthDayEd
        /// <summary>終了対象年月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpYearMonthDayEd
        {
            get { return _addUpYearMonthDayEd; }
            set { _addUpYearMonthDayEd = value; }
        }

        /// public propaty name  :  CrModeSec
        /// <summary>改頁(拠点毎で改頁)プロパティ</summary>
        /// <value>0:なし 1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁(拠点毎で改頁)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CrModeSec
        {
            get { return _crModeSec; }
            set { _crModeSec = value; }
        }

        /// public propaty name  :  CrModeEmp
        /// <summary>改頁(担当者毎で改頁)プロパティ</summary>
        /// <value>0:なし 1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁(担当者毎で改頁)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CrModeEmp
        {
            get { return _crModeEmp; }
            set { _crModeEmp = value; }
        }

        //  dingjx  >>>
        // public propaty name  :  AreaCodeSt
        /// <summary>開始地区コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始地区コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AreaCodeSt
        {
            get { return _areaCodeSt; }
            set { _areaCodeSt = value; }
        }

        // public propaty name  :  AreaCodeEd
        /// <summary>終了地区コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了地区コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AreaCodeEd
        {
            get { return _areaCodeEd; }
            set { _areaCodeEd = value; }
        }

        /// public propaty name  :  CrModeArea
        /// <summary>改頁(地区毎で改頁)プロパティ</summary>
        /// <value>0:なし 1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁(地区毎で改頁)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CrModeArea
        {
            get { return _crModeArea; }
            set { _crModeArea = value; }
        }
        //  dingjx  <<<

        /// public propaty name  :  OutputSort
        /// <summary>出力順プロパティ</summary>
        /// <value>0:グループコード 1:BLコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ソート項目プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OutputSort
        {
            get { return _outputSort; }
            set { _outputSort = value; }
        }

        /// public propaty name  :  PrintSort
        /// <summary>印刷順プロパティ</summary>
        /// <value>0：品番＋メーカー,1：メーカー＋品番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷順プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintSort
        {
            get { return _printSort; }
            set { _printSort = value; }
        }

        /// public propaty name  :  PrintType
        /// <summary>印字タイププロパティ</summary>
        /// <value>0:当月,1:期間,3:日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印字タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  Detail
        /// <summary>明細単位プロパティ</summary>
        /// <value>0：品番＋メーカー,1：メーカー＋品番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }

        /// public propaty name  :  Total
        /// <summary>小計単位プロパティ</summary>
        /// <value>0:当月,1:期間,3:日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Total
        {
            get { return _total; }
            set { _total = value; }
        }


        /// public propaty name  :  SalesCodeSt
        /// <summary>開始販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCodeSt
        {
            get { return _salesCodeSt; }
            set { _salesCodeSt = value; }
        }

        /// public propaty name  :  SalesCodeEd
        /// <summary>終了販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCodeEd
        {
            get { return _salesCodeEd; }
            set { _salesCodeEd = value; }
        }

        # endregion ■ public propaty ■

        # region ■ public method ■
        /// <summary>
        /// キャンペーン実績表コンストラクタ
        /// </summary>
        /// <returns>Campaignstクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Campaignstクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignRsltList()
        {
        }
        
        # endregion ■ public method ■

        # region ■ public propaty (自動生成以外) ■
        /// <summary>
        /// 帳票集計区分　名称取得
        /// </summary>
        public string TotalTypeName
        {
            get
            {
                switch (this._totalType)
                {
                    case TotalTypeState.EachGoods:
                        return ct_totalTypeState_EachGoods;
                    case TotalTypeState.EachCustomer:
                        return ct_totalTypeState_EachCustomer;
                    case TotalTypeState.EachEmployee:
                        return ct_totalTypeState_EachEmployee;
                    case TotalTypeState.EachAcceptOdr:
                        return ct_totalTypeState_EachAcceptOdr;
                    case TotalTypeState.EachPrinter:
                        return ct_totalTypeState_EachPrinter;
                    case TotalTypeState.EachArea:
                        return ct_totalTypeState_EachArea;
                    case TotalTypeState.EachSales:
                        return ct_totalTypeState_EachSales;
                    default:
                        return string.Empty;
                }
            }
        }
        # endregion ■ public propaty (自動生成以外) ■

        # region ■ public Enum (自動生成以外) ■
        /// <summary>
        /// 帳票集計区分　列挙型
        /// </summary>
        public enum TotalTypeState
        {
            /// <summary>商品別</summary>
            EachGoods = 0,
            /// <summary>得意先別</summary>
            EachCustomer = 1,
            /// <summary>担当者別</summary>
            EachEmployee = 2,
            /// <summary>受注者別</summary>
            EachAcceptOdr = 3,
            /// <summary>発行者別</summary>
            EachPrinter = 4,
            /// <summary>地区別</summary>
            EachArea = 5,
            /// <summary>販売区分別</summary>
            EachSales = 6,
        }
        # endregion ■ public Enum (自動生成以外) ■

        #region ■ public const ■
        /// <summary>帳票集計区分　商品別</summary>
        public const string ct_totalTypeState_EachGoods = "商品別";
        /// <summary>帳票集計区分　得意先別</summary>
        public const string ct_totalTypeState_EachCustomer = "得意先別";
        /// <summary>帳票集計区分　担当者別</summary>
        public const string ct_totalTypeState_EachEmployee = "担当者別";
        /// <summary>帳票集計区分　商品別</summary>
        public const string ct_totalTypeState_EachAcceptOdr = "受注者別";
        /// <summary>帳票集計区分　得意先別</summary>
        public const string ct_totalTypeState_EachPrinter = "発行者別";
        /// <summary>帳票集計区分　担当者別</summary>
        public const string ct_totalTypeState_EachArea = "地区別";
        /// <summary>帳票集計区分　担当者別</summary>
        public const string ct_totalTypeState_EachSales = "販売区分別";
        #endregion ■ public const ■
    }
}
