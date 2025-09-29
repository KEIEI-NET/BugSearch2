using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccTtlSt
    /// <summary>
    ///                      PCC全体設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCC全体設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011.08.01</br>
    /// <br>Genarated Date   :   2011.08.01  (CSharp File Generated Date)</br>   
    /// </remarks>
    public class PccTtlSt
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
        /// <remarks>00は全社</remarks>
        private string _sectionCode = "";

        /// <summary>拠点名称</summary>
        /// <remarks>00は全社</remarks>
        private string _sectionName = "";

        /// <summary>受付従業員コード</summary>
        /// <remarks>PM受注者コード</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>受付従業員名称</summary>
        private string _frontEmployeeNm = "";

        /// <summary>納品区分</summary>
        /// <remarks>0:しない 1:する</remarks>
        private Int32 _deliveredGoodsDiv;

        /// <summary>納品区分名称</summary>
        private string _deliveredGoodsNm = "";

        /// <summary>売上伝票発行区分</summary>
        /// <remarks>0:しない 1:する</remarks>
        private Int32 _salesSlipPrtDiv;

        /// <summary>売上伝票発行区分名称</summary>
        private string _salesSlipPrtNm = "";

        /// <summary>受注伝票印刷区分</summary>
        /// <remarks>0:しない 1:する</remarks>
        private Int32 _acpOdrrSlipPrtDiv;

        /// <summary>受注伝票印刷区分名称</summary>
        private string _acpOdrrSlipPrtNm = "";

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
        /// <value>00は全社</value>
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
        /// <value>00は全社</value>
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

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>受付従業員コードプロパティ</summary>
        /// <value>PM受注者コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>受付従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>納品区分プロパティ</summary>
        /// <value>0:しない 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  DeliveredGoodsNm
        /// <summary>納品区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliveredGoodsNm
        {
            get { return _deliveredGoodsNm; }
            set { _deliveredGoodsNm = value; }
        }

        /// public propaty name  :  SalesSlipPrtDiv
        /// <summary>売上伝票発行区分プロパティ</summary>
        /// <value>0:しない 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipPrtDiv
        {
            get { return _salesSlipPrtDiv; }
            set { _salesSlipPrtDiv = value; }
        }

        /// public propaty name  :  SalesSlipPrtNm
        /// <summary>売上伝票発行区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipPrtNm
        {
            get { return _salesSlipPrtNm; }
            set { _salesSlipPrtNm = value; }
        }

        /// public propaty name  :  AcpOdrrSlipPrtDiv
        /// <summary>受注伝票印刷区分プロパティ</summary>
        /// <value>0:しない 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注伝票印刷区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcpOdrrSlipPrtDiv
        {
            get { return _acpOdrrSlipPrtDiv; }
            set { _acpOdrrSlipPrtDiv = value; }
        }

        /// public propaty name  :  AcpOdrrSlipPrtNm
        /// <summary>受注伝票印刷区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注伝票印刷区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AcpOdrrSlipPrtNm
        {
            get { return _acpOdrrSlipPrtNm; }
            set { _acpOdrrSlipPrtNm = value; }
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
        /// PCC全体設定マスタコンストラクタ
        /// </summary>
        /// <returns>PccTtlStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccTtlStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccTtlSt()
        {
        }

        /// <summary>
        /// PCC全体設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード(00は全社)</param>
        /// <param name="sectionName">拠点名称(00は全社)</param>
        /// <param name="frontEmployeeCd">受付従業員コード(PM受注者コード)</param>
        /// <param name="frontEmployeeNm">受付従業員名称</param>
        /// <param name="deliveredGoodsDiv">納品区分(0:しない 1:する)</param>
        /// <param name="deliveredGoodsNm">納品区分名称</param>
        /// <param name="salesSlipPrtDiv">売上伝票発行区分(0:しない 1:する)</param>
        /// <param name="salesSlipPrtNm">売上伝票発行区分名称</param>
        /// <param name="acpOdrrSlipPrtDiv">受注伝票印刷区分(0:しない 1:する)</param>
        /// <param name="acpOdrrSlipPrtNm">受注伝票印刷区分名称</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>PccTtlStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccTtlStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string sectionName, string frontEmployeeCd, string frontEmployeeNm, Int32 deliveredGoodsDiv, string deliveredGoodsNm, Int32 salesSlipPrtDiv, string salesSlipPrtNm, Int32 acpOdrrSlipPrtDiv, string acpOdrrSlipPrtNm, string enterpriseName, string updEmployeeName)
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
            this._frontEmployeeCd = frontEmployeeCd;
            this._frontEmployeeNm = frontEmployeeNm;
            this._deliveredGoodsDiv = deliveredGoodsDiv;
            this._deliveredGoodsNm = deliveredGoodsNm;
            this._salesSlipPrtDiv = salesSlipPrtDiv;
            this._salesSlipPrtNm = salesSlipPrtNm;
            this._acpOdrrSlipPrtDiv = acpOdrrSlipPrtDiv;
            this._acpOdrrSlipPrtNm = acpOdrrSlipPrtNm;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// PCC全体設定マスタ複製処理
        /// </summary>
        /// <returns>PccTtlStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPccTtlStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccTtlSt Clone()
        {
            return new PccTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._sectionName, this._frontEmployeeCd, this._frontEmployeeNm, this._deliveredGoodsDiv, this._deliveredGoodsNm, this._salesSlipPrtDiv, this._salesSlipPrtNm, this._acpOdrrSlipPrtDiv, this._acpOdrrSlipPrtNm, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// PCC全体設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPccTtlStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccTtlStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PccTtlSt target)
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
                 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
                 && (this.FrontEmployeeNm == target.FrontEmployeeNm)
                 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
                 && (this.DeliveredGoodsNm == target.DeliveredGoodsNm)
                 && (this.SalesSlipPrtDiv == target.SalesSlipPrtDiv)
                 && (this.SalesSlipPrtNm == target.SalesSlipPrtNm)
                 && (this.AcpOdrrSlipPrtDiv == target.AcpOdrrSlipPrtDiv)
                 && (this.AcpOdrrSlipPrtNm == target.AcpOdrrSlipPrtNm)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// PCC全体設定マスタ比較処理
        /// </summary>
        /// <param name="pccTtlSt1">
        ///                    比較するPccTtlStクラスのインスタンス
        /// </param>
        /// <param name="pccTtlSt2">比較するPccTtlStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccTtlStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PccTtlSt pccTtlSt1, PccTtlSt pccTtlSt2)
        {
            return ((pccTtlSt1.CreateDateTime == pccTtlSt2.CreateDateTime)
                 && (pccTtlSt1.UpdateDateTime == pccTtlSt2.UpdateDateTime)
                 && (pccTtlSt1.EnterpriseCode == pccTtlSt2.EnterpriseCode)
                 && (pccTtlSt1.FileHeaderGuid == pccTtlSt2.FileHeaderGuid)
                 && (pccTtlSt1.UpdEmployeeCode == pccTtlSt2.UpdEmployeeCode)
                 && (pccTtlSt1.UpdAssemblyId1 == pccTtlSt2.UpdAssemblyId1)
                 && (pccTtlSt1.UpdAssemblyId2 == pccTtlSt2.UpdAssemblyId2)
                 && (pccTtlSt1.LogicalDeleteCode == pccTtlSt2.LogicalDeleteCode)
                 && (pccTtlSt1.SectionCode == pccTtlSt2.SectionCode)
                 && (pccTtlSt1.SectionName == pccTtlSt2.SectionName)
                 && (pccTtlSt1.FrontEmployeeCd == pccTtlSt2.FrontEmployeeCd)
                 && (pccTtlSt1.FrontEmployeeNm == pccTtlSt2.FrontEmployeeNm)
                 && (pccTtlSt1.DeliveredGoodsDiv == pccTtlSt2.DeliveredGoodsDiv)
                 && (pccTtlSt1.DeliveredGoodsNm == pccTtlSt2.DeliveredGoodsNm)
                 && (pccTtlSt1.SalesSlipPrtDiv == pccTtlSt2.SalesSlipPrtDiv)
                 && (pccTtlSt1.SalesSlipPrtNm == pccTtlSt2.SalesSlipPrtNm)
                 && (pccTtlSt1.AcpOdrrSlipPrtDiv == pccTtlSt2.AcpOdrrSlipPrtDiv)
                 && (pccTtlSt1.AcpOdrrSlipPrtNm == pccTtlSt2.AcpOdrrSlipPrtNm)
                 && (pccTtlSt1.EnterpriseName == pccTtlSt2.EnterpriseName)
                 && (pccTtlSt1.UpdEmployeeName == pccTtlSt2.UpdEmployeeName));
        }
        /// <summary>
        /// PCC全体設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPccTtlStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccTtlStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PccTtlSt target)
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
            if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (this.FrontEmployeeNm != target.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (this.DeliveredGoodsNm != target.DeliveredGoodsNm) resList.Add("DeliveredGoodsNm");
            if (this.SalesSlipPrtDiv != target.SalesSlipPrtDiv) resList.Add("SalesSlipPrtDiv");
            if (this.SalesSlipPrtNm != target.SalesSlipPrtNm) resList.Add("SalesSlipPrtNm");
            if (this.AcpOdrrSlipPrtDiv != target.AcpOdrrSlipPrtDiv) resList.Add("AcpOdrrSlipPrtDiv");
            if (this.AcpOdrrSlipPrtNm != target.AcpOdrrSlipPrtNm) resList.Add("AcpOdrrSlipPrtNm");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// PCC全体設定マスタ比較処理
        /// </summary>
        /// <param name="pccTtlSt1">比較するPccTtlStクラスのインスタンス</param>
        /// <param name="pccTtlSt2">比較するPccTtlStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccTtlStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PccTtlSt pccTtlSt1, PccTtlSt pccTtlSt2)
        {
            ArrayList resList = new ArrayList();
            if (pccTtlSt1.CreateDateTime != pccTtlSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccTtlSt1.UpdateDateTime != pccTtlSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccTtlSt1.EnterpriseCode != pccTtlSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (pccTtlSt1.FileHeaderGuid != pccTtlSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (pccTtlSt1.UpdEmployeeCode != pccTtlSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (pccTtlSt1.UpdAssemblyId1 != pccTtlSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (pccTtlSt1.UpdAssemblyId2 != pccTtlSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (pccTtlSt1.LogicalDeleteCode != pccTtlSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccTtlSt1.SectionCode != pccTtlSt2.SectionCode) resList.Add("SectionCode");
            if (pccTtlSt1.SectionName != pccTtlSt2.SectionName) resList.Add("SectionName");
            if (pccTtlSt1.FrontEmployeeCd != pccTtlSt2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (pccTtlSt1.FrontEmployeeNm != pccTtlSt2.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (pccTtlSt1.DeliveredGoodsDiv != pccTtlSt2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (pccTtlSt1.DeliveredGoodsNm != pccTtlSt2.DeliveredGoodsNm) resList.Add("DeliveredGoodsNm");
            if (pccTtlSt1.SalesSlipPrtDiv != pccTtlSt2.SalesSlipPrtDiv) resList.Add("SalesSlipPrtDiv");
            if (pccTtlSt1.SalesSlipPrtNm != pccTtlSt2.SalesSlipPrtNm) resList.Add("SalesSlipPrtNm");
            if (pccTtlSt1.AcpOdrrSlipPrtDiv != pccTtlSt2.AcpOdrrSlipPrtDiv) resList.Add("AcpOdrrSlipPrtDiv");
            if (pccTtlSt1.AcpOdrrSlipPrtNm != pccTtlSt2.AcpOdrrSlipPrtNm) resList.Add("AcpOdrrSlipPrtNm");
            if (pccTtlSt1.EnterpriseName != pccTtlSt2.EnterpriseName) resList.Add("EnterpriseName");
            if (pccTtlSt1.UpdEmployeeName != pccTtlSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
