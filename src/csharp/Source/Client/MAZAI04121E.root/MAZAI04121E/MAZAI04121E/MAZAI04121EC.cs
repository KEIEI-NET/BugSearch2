using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockMoveHeader
    /// <summary>
    ///                      在庫移動ヘッダデータ
    /// </summary>
    /// <remarks>
    /// note             :   在庫移動ヘッダデータファイル<br />
    /// Programmer       :   伊藤 豊<br />
    /// Date             :   <br />
    /// Genarated Date   :   2007/01/23<br />
    /// Update Note      :   <br />
    /// </remarks>
    public class StockMoveHeader
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

        /// <summary>在庫移動入力従業員コード</summary>
        private string _StockMvEmpCode = "";

        /// <summary>在庫移動入力従業員名称</summary>
        private string _StockMvEmpName = "";

        /// <summary>出荷予定日</summary>
        private DateTime _ShipmentScdlDay;

        /// <summary>出荷予定日</summary>
        private DateTime _ShipmentFixDay;

        /// <summary>移動元拠点コード</summary>
        private string _BfSectionCode;

        /// <summary>移動元拠点名称</summary>
        private string _BfSectionGuideName;

        /// <summary>移動元倉庫コード</summary>
        private string _BfEnterWarehCode;

        /// <summary>移動元倉庫名称</summary>
        private string _BfEnterWarehName;

        /// <summary>移動先拠点コード</summary>
        private string _AfSectionCode;

        /// <summary>移動先拠点名称</summary>
        private string _AfSectionGuideName;

        /// <summary>移動先倉庫コード</summary>
        private string _AfEnterWarehCode = "";

        /// <summary>移動先倉庫名称</summary>
        private string _AfEnterWarehName = "";

        /// <summary>移動伝票番号</summary>
        private int _StockMoveSlipNo;

        /// <summary>移動伝票発行区分</summary>
        private bool _MoveSlipPrintDiv;

        /// <summary>出荷担当従業員コード</summary>
        private string _ShipAgentCd = "";

        /// <summary>出荷担当従業員名称</summary>
        private string _ShipAgentNm = "";

        /// <summary>引取担当従業員コード</summary>
        private string _ReceiveAgentCd = "";

        /// <summary>引取担当従業員名称</summary>
        private string _ReceiveAgentNm = "";

        /// <summary>入荷日</summary>
        private DateTime _ArrivalGoodsDay;

        /// <summary>伝票摘要</summary>
        private string _OutLine = "";

        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時プロパティ<br />
        /// Programer        :   伊藤 豊<br />
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
        /// note             :   作成日時 和暦プロパティ<br />
        /// Programer        :   伊藤 豊<br />
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
        /// note             :   作成日時 和暦(略)プロパティ<br />
        /// Programer        :   伊藤 豊<br />
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
        /// note             :   作成日時 西暦プロパティ<br />
        /// Programer        :   伊藤 豊<br />
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
        /// note             :   作成日時 西暦(略)プロパティ<br />
        /// Programer        :   伊藤 豊<br />
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
        /// note             :   更新日時プロパティ<br />
        /// Programer        :   伊藤 豊<br />
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
        /// note             :   更新日時 和暦プロパティ<br />
        /// Programer        :   伊藤 豊<br />
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
        /// note             :   更新日時 和暦(略)プロパティ<br />
        /// Programer        :   伊藤 豊<br />
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
        /// note             :   更新日時 西暦プロパティ<br />
        /// Programer        :   伊藤 豊<br />
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
        /// note             :   更新日時 西暦(略)プロパティ<br />
        /// Programer        :   伊藤 豊<br />
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
        /// note             :   企業コードプロパティ<br />
        /// Programer        :   伊藤 豊<br />
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
        /// note             :   GUIDプロパティ<br />
        /// Programer        :   伊藤 豊<br />
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
        /// note             :   更新従業員コードプロパティ<br />
        /// Programer        :   伊藤 豊<br />
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
        /// note             :   更新アセンブリID1プロパティ<br />
        /// Programer        :   伊藤 豊<br />
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
        /// note             :   更新アセンブリID2プロパティ<br />
        /// Programer        :   伊藤 豊<br />
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
        /// note             :   論理削除区分プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  _StockMvEmpCode
        /// <summary>在庫移動入力従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   在庫移動入力従業員コードプロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string StockMvEmpCode
        {
            get { return _StockMvEmpCode; }
            set { _StockMvEmpCode = value; }
        }

        /// public propaty name  :  _StockMvEmpName
        /// <summary>在庫移動入力従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   在庫移動入力従業員名称プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string StockMvEmpName
        {
            get { return _StockMvEmpName; }
            set { _StockMvEmpName = value; }
        }

        /// public propaty name  :  _ShipmentScdlDay
        /// <summary>出荷予定日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   出荷予定日プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public DateTime ShipmentScdlDay
        {
            get { return _ShipmentScdlDay; }
            set { _ShipmentScdlDay = value; }
        }

        /// public propaty name  :  ShipmentScdlDayJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時 和暦プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string ShipmentScdlDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _ShipmentScdlDay); }
            set { }
        }

        /// public propaty name  :  ShipmentScdlDayJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時 和暦(略)プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string ShipmentScdlDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ShipmentScdlDay); }
            set { }
        }

        /// public propaty name  :  ShipmentScdlDayAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時 西暦プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string ShipmentScdlDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ShipmentScdlDay); }
            set { }
        }

        /// public propaty name  :  ShipmentScdlDayAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時 西暦(略)プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string ShipmentScdlDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _ShipmentScdlDay); }
            set { }
        }

        /// public propaty name  :  _ShipmentScdlDay
        /// <summary>出荷予定日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   出荷予定日プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public DateTime ShipmentFixDay
        {
            get { return _ShipmentFixDay; }
            set { _ShipmentFixDay = value; }
        }

        /// public propaty name  :  ShipmentFixDayJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時 和暦プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string ShipmentFixDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _ShipmentFixDay); }
            set { }
        }

        /// public propaty name  :  ShipmentFixDayJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時 和暦(略)プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string ShipmentFixDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ShipmentFixDay); }
            set { }
        }

        /// public propaty name  :  ShipmentFixDayAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時 西暦プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string ShipmentFixDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ShipmentFixDay); }
            set { }
        }

        /// public propaty name  :  ShipmentFixDayAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時 西暦(略)プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string ShipmentFixDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _ShipmentFixDay); }
            set { }
        }

        /// public propaty name  :  _BfSectionCode
        /// <summary>移動元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動元拠点コードプロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string BfSectionCode
        {
            get { return _BfSectionCode; }
            set { _BfSectionCode = value; }
        }

        /// public propaty name  :  _BfSectionGuideName
        /// <summary>移動元拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動元拠点名称プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string BfSectionGuideName
        {
            get { return _BfSectionGuideName; }
            set { _BfSectionGuideName = value; }
        }

        /// public propaty name  :  _BfEnterWarehCode
        /// <summary>移動元倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動元倉庫コードプロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string BfEnterWarehCode
        {
            get { return _BfEnterWarehCode; }
            set { _BfEnterWarehCode = value; }
        }

        /// public propaty name  :  _BfEnterWarehName
        /// <summary>移動元倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動元倉庫名称プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string BfEnterWarehName
        {
            get { return _BfEnterWarehName; }
            set { _BfEnterWarehName = value; }
        }

        /// public propaty name  :  _AfSectionCode
        /// <summary>移動先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動先拠点コードプロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string AfSectionCode
        {
            get { return _AfSectionCode; }
            set { _AfSectionCode = value; }
        }

        /// public propaty name  :  _AfSectionGuideName
        /// <summary>移動先拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動先拠点名称プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string AfSectionGuideName
        {
            get { return _AfSectionGuideName; }
            set { _AfSectionGuideName = value; }
        }

        /// public propaty name  :  _AfEnterWarehCode
        /// <summary>移動先倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動先倉庫コードプロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string AfEnterWarehCode
        {
            get { return _AfEnterWarehCode; }
            set { _AfEnterWarehCode = value; }
        }

        /// public propaty name  :  _AfEnterWarehName
        /// <summary>移動先倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動先倉庫名称プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string AfEnterWarehName
        {
            get { return _AfEnterWarehName; }
            set { _AfEnterWarehName = value; }
        }

        /// public propaty name  :  _StockMoveSlipNo
        /// <summary>移動伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動伝票番号プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public int StockMoveSlipNo
        {
            get { return _StockMoveSlipNo; }
            set { _StockMoveSlipNo = value; }
        }

        /// public propaty name  :  _MoveSlipPrintDiv
        /// <summary>移動伝票発行区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動伝票発行区分プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public bool MoveSlipPrintDiv
        {
            get { return _MoveSlipPrintDiv; }
            set { _MoveSlipPrintDiv = value; }
        }

        /// public propaty name  :  _ShipAgentCd
        /// <summary>出荷担当従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   出荷担当従業員コードプロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string ShipAgentCd
        {
            get { return _ShipAgentCd; }
            set { _ShipAgentCd = value; }
        }

        /// public propaty name  :  _ShipAgentNm
        /// <summary>出荷担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   出荷担当従業員名称プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string ShipAgentNm
        {
            get { return _ShipAgentNm; }
            set { _ShipAgentNm = value; }
        }

        /// public propaty name  :  _ReceiveAgentCd
        /// <summary>引取担当従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   引取担当従業員コードプロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string ReceiveAgentCd
        {
            get { return _ReceiveAgentCd; }
            set { _ReceiveAgentCd = value; }
        }

        /// public propaty name  :  _ReceiveAgentNm
        /// <summary>引取担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   引取担当従業員名称プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string ReceiveAgentNm
        {
            get { return _ReceiveAgentNm; }
            set { _ReceiveAgentNm = value; }
        }

        /// public propaty name  :  _ArrivalGoodsDay
        /// <summary>入荷日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   入荷日プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public DateTime ArrivalGoodsDay
        {
            get { return _ArrivalGoodsDay; }
            set { _ArrivalGoodsDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsDayJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// ------de----------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時 和暦プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string ArrivalGoodsDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _ArrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDayJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時 和暦(略)プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string ArrivalGoodsDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ArrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDayAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時 西暦プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string ArrivalGoodsDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ArrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDayAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時 西暦(略)プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string ArrivalGoodsDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _ArrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  OutLine
        /// <summary>伝票摘要プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   伝票摘要プロパティ<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public string OutLine
        {
            get { return _OutLine; }
            set { _OutLine = value; }
        }

        /// <summary>
        /// 在庫移動ヘッダデータコンストラクタ
        /// </summary>
        /// <returns>StockMoveHeaderクラスのインスタンス</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveHeaderクラスの新しいインスタンスを生成します<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public StockMoveHeader()
        {
        }

        /// <summary>
        /// 在庫移動ヘッダデータコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <returns>StockMoveHeaderクラスのインスタンス</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveHeaderクラスの新しいインスタンスを生成します<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public StockMoveHeader(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string StockMvEmpCode, string StockMvEmpName, DateTime ShipmentScdlDay, DateTime ShipmentFixDay, string BfSectionCode, string BfSectionGuideName, string BfEnterWarehCode, string BfEnterWarehName, string AfSectionCode, string AfSectionGuideName, string AfEnterWarehCode, string AfEnterWarehName, int StockMoveSlipNo, bool MoveSlipPrintDiv, string ShipAgentCd, string ShipAgentNm, string ReceiveAgentCd, string ReceiveAgentNm, DateTime ArrivalGoodsDay, string OutLine)
        {
            this._createDateTime = createDateTime;
            this._updateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._StockMvEmpCode = StockMvEmpCode;
            this._StockMvEmpName = StockMvEmpName;
            this._ShipmentScdlDay = ShipmentScdlDay;
            this._ShipmentFixDay = ShipmentFixDay;
            this._BfSectionCode = BfSectionCode;
            this._BfSectionGuideName = BfSectionGuideName;
            this._BfEnterWarehCode = BfEnterWarehCode;
            this._BfEnterWarehName = BfEnterWarehName;
            this._AfSectionCode = AfSectionCode;
            this._AfSectionGuideName = AfSectionGuideName;
            this._AfEnterWarehCode = AfEnterWarehCode;
            this._AfEnterWarehName = AfEnterWarehName;
            this._StockMoveSlipNo = StockMoveSlipNo;
            this._MoveSlipPrintDiv = MoveSlipPrintDiv;
            this._ShipAgentCd = ShipAgentCd;
            this._ShipAgentNm = ShipAgentNm;
            this._ReceiveAgentCd = ReceiveAgentCd;
            this._ReceiveAgentNm = ReceiveAgentNm;
            this._ArrivalGoodsDay = ArrivalGoodsDay;
            this._OutLine = OutLine;
        }

        /// <summary>
        /// 在庫移動ヘッダデータ複製処理
        /// </summary>
        /// <returns>StockMoveHeaderクラスのインスタンス</returns>
        /// <remarks>
        /// Note　　　　　　 :   自身の内容と等しいStockMoveHeaderクラスのインスタンスを返します<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public StockMoveHeader Clone()
        {
            return new StockMoveHeader(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._StockMvEmpCode, this._StockMvEmpName, this._ShipmentScdlDay, this.ShipmentFixDay, this.BfSectionCode, this.BfSectionGuideName, this.BfEnterWarehCode, this.BfEnterWarehName, this._AfSectionCode, this._AfSectionGuideName, this._AfEnterWarehCode, this._AfEnterWarehName, this.StockMoveSlipNo, this._MoveSlipPrintDiv, this._ShipAgentCd, this._ShipAgentNm, this._ReceiveAgentCd, this._ReceiveAgentNm, this._ArrivalGoodsDay, this._OutLine);
        }

        /// <summary>
        /// 在庫移動ヘッダデータ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockMoveHeaderクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveHeaderクラスの内容が一致するか比較します<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public bool Equals(StockMoveHeader target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.StockMvEmpCode == target.StockMvEmpCode)
                 && (this.StockMvEmpName == target.StockMvEmpName)
                 && (this.ShipmentScdlDay == target.ShipmentScdlDay)
                 && (this.BfSectionCode == target.BfSectionCode)
                 && (this.BfSectionGuideName == target.BfSectionGuideName)
                 && (this.BfEnterWarehCode == target.BfEnterWarehCode)
                 && (this.BfEnterWarehName == target.BfEnterWarehName)
                 && (this.AfSectionCode == target.AfSectionCode)
                 && (this.AfSectionGuideName == target.AfSectionGuideName)
                 && (this.AfEnterWarehCode == target.AfEnterWarehCode)
                 && (this.AfEnterWarehName == target.AfEnterWarehName)
                 && (this.StockMoveSlipNo == target.StockMoveSlipNo)
                 && (this.MoveSlipPrintDiv == target.MoveSlipPrintDiv)
                 && (this.ShipAgentCd == target.ShipAgentCd)
                 && (this.ShipAgentNm == target.ShipAgentNm)
                 && (this.ReceiveAgentCd == target.ReceiveAgentCd)
                 && (this.ReceiveAgentNm == target.ReceiveAgentNm)
                 && (this.ArrivalGoodsDay == target.ArrivalGoodsDay)
                 && (this.OutLine == target.OutLine));
        }

        /// <summary>
        /// 在庫移動ヘッダデータ比較処理
        /// </summary>
        /// <param name="stockMoveHeader1">
        ///                    比較するStockMoveHeaderクラスのインスタンス
        /// </param>
        /// <param name="stockMoveHeader2">比較するStockMoveHeaderクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveHeaderクラスの内容が一致するか比較します<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public static bool Equals(StockMoveHeader stockMoveHeader1, StockMoveHeader stockMoveHeader2)
        {
            return ((stockMoveHeader1.CreateDateTime == stockMoveHeader2.CreateDateTime)
                 && (stockMoveHeader1.UpdateDateTime == stockMoveHeader2.UpdateDateTime)
                 && (stockMoveHeader1.EnterpriseCode == stockMoveHeader2.EnterpriseCode)
                 && (stockMoveHeader1.FileHeaderGuid == stockMoveHeader2.FileHeaderGuid)
                 && (stockMoveHeader1.UpdEmployeeCode == stockMoveHeader2.UpdEmployeeCode)
                 && (stockMoveHeader1.UpdAssemblyId1 == stockMoveHeader2.UpdAssemblyId1)
                 && (stockMoveHeader1.UpdAssemblyId2 == stockMoveHeader2.UpdAssemblyId2)
                 && (stockMoveHeader1.LogicalDeleteCode == stockMoveHeader2.LogicalDeleteCode)
                 && (stockMoveHeader1.StockMvEmpCode == stockMoveHeader2.StockMvEmpCode)
                 && (stockMoveHeader1.StockMvEmpName == stockMoveHeader2.StockMvEmpName)
                 && (stockMoveHeader1.ShipmentScdlDay == stockMoveHeader2.ShipmentScdlDay)
                 && (stockMoveHeader1.BfSectionCode == stockMoveHeader2.BfSectionCode)
                 && (stockMoveHeader1.BfSectionGuideName == stockMoveHeader2.BfSectionGuideName)
                 && (stockMoveHeader1.BfEnterWarehCode == stockMoveHeader2.BfEnterWarehCode)
                 && (stockMoveHeader1.BfEnterWarehName == stockMoveHeader2.BfEnterWarehName)
                 && (stockMoveHeader1.AfSectionCode == stockMoveHeader2.AfSectionCode)
                 && (stockMoveHeader1.AfSectionGuideName == stockMoveHeader2.AfSectionGuideName)
                 && (stockMoveHeader1.AfEnterWarehCode == stockMoveHeader2.AfEnterWarehCode)
                 && (stockMoveHeader1.AfEnterWarehName == stockMoveHeader2.AfEnterWarehName)
                 && (stockMoveHeader1.StockMoveSlipNo == stockMoveHeader2.StockMoveSlipNo)
                 && (stockMoveHeader1.MoveSlipPrintDiv == stockMoveHeader2.MoveSlipPrintDiv)
                 && (stockMoveHeader1.ShipAgentCd == stockMoveHeader2.ShipAgentCd)
                 && (stockMoveHeader1.ShipAgentNm == stockMoveHeader2.ShipAgentNm)
                 && (stockMoveHeader1.ReceiveAgentCd == stockMoveHeader2.ReceiveAgentCd)
                 && (stockMoveHeader1.ReceiveAgentNm == stockMoveHeader2.ReceiveAgentNm)
                 && (stockMoveHeader1.ArrivalGoodsDay == stockMoveHeader2.ArrivalGoodsDay)
                 && (stockMoveHeader1.OutLine == stockMoveHeader2.OutLine));
        }
        /// <summary>
        /// 在庫移動ヘッダデータ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockMoveHeaderクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveHeaderクラスの内容が一致するか比較しし、一致しない項目の名称を返します<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public ArrayList Compare(StockMoveHeader target)
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
            if (this.StockMvEmpCode != target.StockMvEmpCode) resList.Add("StockMvEmpCode");
            if (this.StockMvEmpName != target.StockMvEmpName) resList.Add("StockMvEmpName");
            if (this.ShipmentScdlDay != target.ShipmentScdlDay) resList.Add("ShipmentScdlDay");
            if (this.BfSectionCode != target.BfSectionCode) resList.Add("BfSectionCode");
            if (this.BfSectionGuideName != target.BfSectionGuideName) resList.Add("BfSectionGuideName");
            if (this.BfEnterWarehCode != target.BfEnterWarehCode) resList.Add("BfEnterWarehCode");
            if (this.BfEnterWarehName != target.BfEnterWarehName) resList.Add("BfEnterWarehName");
            if (this.AfSectionCode != target.AfSectionCode) resList.Add("AfSectionCode");
            if (this.AfSectionGuideName != target.AfSectionGuideName) resList.Add("AfSectionGuideName");
            if (this.AfEnterWarehCode != target.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (this.AfEnterWarehName != target.AfEnterWarehName) resList.Add("AfEnterWarehName");
            if (this.StockMoveSlipNo != target.StockMoveSlipNo) resList.Add("StockMoveSlipNo");
            if (this.MoveSlipPrintDiv != target.MoveSlipPrintDiv) resList.Add("MoveSlipPrintDiv");
            if (this.ShipAgentCd != target.ShipAgentCd) resList.Add("ShipAgentCd");
            if (this.ShipAgentNm != target.ShipAgentNm) resList.Add("ShipAgentNm");
            if (this.ReceiveAgentCd != target.ReceiveAgentCd) resList.Add("ReceiveAgentCd");
            if (this.ReceiveAgentNm != target.ReceiveAgentNm) resList.Add("ReceiveAgentNm");
            if (this.ArrivalGoodsDay != target.ArrivalGoodsDay) resList.Add("ArrivalGoodsDay");
            if (this.OutLine != target.OutLine) resList.Add("OutLine");

            return resList;
        }

        /// <summary>
        /// 在庫移動ヘッダデータ比較処理
        /// </summary>
        /// <param name="stockMoveHeader1">比較するStockMoveHeaderクラスのインスタンス</param>
        /// <param name="stockMoveHeader2">比較するStockMoveHeaderクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveHeaderクラスの内容が一致するか比較し、一致しない項目の名称を返します<br />
        /// Programer        :   伊藤 豊<br />
        /// </remarks>
        public static ArrayList Compare(StockMoveHeader stockMoveHeader1, StockMoveHeader stockMoveHeader2)
        {
            ArrayList resList = new ArrayList();
            if (stockMoveHeader1.CreateDateTime != stockMoveHeader2.CreateDateTime) resList.Add("CreateDateTime");
            if (stockMoveHeader1.UpdateDateTime != stockMoveHeader2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (stockMoveHeader1.EnterpriseCode != stockMoveHeader2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockMoveHeader1.FileHeaderGuid != stockMoveHeader2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (stockMoveHeader1.UpdEmployeeCode != stockMoveHeader2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (stockMoveHeader1.UpdAssemblyId1 != stockMoveHeader2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (stockMoveHeader1.UpdAssemblyId2 != stockMoveHeader2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (stockMoveHeader1.LogicalDeleteCode != stockMoveHeader2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stockMoveHeader1.StockMvEmpCode != stockMoveHeader2.StockMvEmpCode) resList.Add("StockMvEmpCode");
            if (stockMoveHeader1.StockMvEmpName != stockMoveHeader2.StockMvEmpName) resList.Add("StockMvEmpName");
            if (stockMoveHeader1.ShipmentScdlDay != stockMoveHeader2.ShipmentScdlDay) resList.Add("ShipmentScdlDay");
            if (stockMoveHeader1.BfSectionCode != stockMoveHeader2.BfSectionCode) resList.Add("BfSectionCode");
            if (stockMoveHeader1.BfSectionGuideName != stockMoveHeader2.BfSectionGuideName) resList.Add("BfSectionGuideName");
            if (stockMoveHeader1.BfEnterWarehCode != stockMoveHeader2.BfEnterWarehCode) resList.Add("BfEnterWarehCode");
            if (stockMoveHeader1.BfEnterWarehName != stockMoveHeader2.BfEnterWarehName) resList.Add("BfEnterWarehName");
            if (stockMoveHeader1.AfSectionCode != stockMoveHeader2.AfSectionCode) resList.Add("AfSectionCode");
            if (stockMoveHeader1.AfSectionGuideName != stockMoveHeader2.AfSectionGuideName) resList.Add("AfSectionGuideName");
            if (stockMoveHeader1.AfEnterWarehCode != stockMoveHeader2.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (stockMoveHeader1.AfEnterWarehName != stockMoveHeader2.AfEnterWarehName) resList.Add("AfEnterWarehName");
            if (stockMoveHeader1.StockMoveSlipNo != stockMoveHeader2.StockMoveSlipNo) resList.Add("StockMoveSlipNo");
            if (stockMoveHeader1.MoveSlipPrintDiv != stockMoveHeader2.MoveSlipPrintDiv) resList.Add("MoveSlipPrintDiv");
            if (stockMoveHeader1.ShipAgentCd != stockMoveHeader2.ShipAgentCd) resList.Add("ShipAgentCd");
            if (stockMoveHeader1.ShipAgentNm != stockMoveHeader2.ShipAgentNm) resList.Add("ShipAgentNm");
            if (stockMoveHeader1.ReceiveAgentCd != stockMoveHeader2.ReceiveAgentCd) resList.Add("ReceiveAgentCd");
            if (stockMoveHeader1.ReceiveAgentNm != stockMoveHeader2.ReceiveAgentNm) resList.Add("ReceiveAgentNm");
            if (stockMoveHeader1.ArrivalGoodsDay != stockMoveHeader2.ArrivalGoodsDay) resList.Add("ArrivalGoodsDay");
            if (stockMoveHeader1.OutLine != stockMoveHeader2.OutLine) resList.Add("OutLine");

            return resList;
        }
    }
}