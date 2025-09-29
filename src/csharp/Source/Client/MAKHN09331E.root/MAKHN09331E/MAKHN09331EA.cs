using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Warehouse
    /// <summary>
    ///                      倉庫マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   倉庫マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2006/12/22  (CSharp File Generated Date)</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note : 「得意先」「主管倉庫」「在庫一括リマーク」追加、「倉庫備考2～5」削除</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/06/04</br>
    /// -----------------------------------------------------------------------------------
    /// </remarks>
    public class Warehouse
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

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>倉庫備考</summary>
        private string _warehouseNote1 = "";

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>倉庫備考２</summary>
        private string _warehouseNote2 = "";

        /// <summary>倉庫備考３</summary>
        private string _warehouseNote3 = "";

        /// <summary>倉庫備考４</summary>
        private string _warehouseNote4 = "";

        /// <summary>倉庫備考５</summary>
        private string _warehouseNote5 = "";
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>主管倉庫コード</summary>
        private string _mainMngWarehouseCd = "";

        /// <summary>在庫一括リマーク</summary>
        private string _stockBlnktRemark = "";
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

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

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  WarehouseNote1
        /// <summary>倉庫備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseNote1
        {
            get { return _warehouseNote1; }
            set { _warehouseNote1 = value; }
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  WarehouseNote2
        /// <summary>倉庫備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseNote2
        {
            get { return _warehouseNote2; }
            set { _warehouseNote2 = value; }
        }

        /// public propaty name  :  WarehouseNote3
        /// <summary>倉庫備考３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫備考３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseNote3
        {
            get { return _warehouseNote3; }
            set { _warehouseNote3 = value; }
        }

        /// public propaty name  :  WarehouseNote4
        /// <summary>倉庫備考４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫備考４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseNote4
        {
            get { return _warehouseNote4; }
            set { _warehouseNote4 = value; }
        }

        /// public propaty name  :  WarehouseNote5
        /// <summary>倉庫備考５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫備考５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseNote5
        {
            get { return _warehouseNote5; }
            set { _warehouseNote5 = value; }
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

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

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// public property name  :  CustomerCode
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

        /// public property name  :  MainMngWarehouseCd
        /// <summary>主管倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   主管倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MainMngWarehouseCd
        {
            get { return _mainMngWarehouseCd; }
            set { _mainMngWarehouseCd = value; }
        }

        /// public property name  :  StockBlnktRemark
        /// <summary>在庫一括リマークプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫一括リマークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockBlnktRemark
        {
            get { return _stockBlnktRemark; }
            set { _stockBlnktRemark = value; }
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// 倉庫マスタコンストラクタ
        /// </summary>
        /// <returns>Warehouseクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Warehouseクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Warehouse()
        {
        }

        /// <summary>
        /// 倉庫マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="warehouseName">倉庫名称</param>
        /// <param name="warehouseNote1">倉庫備考</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="mainMngWarehouseCd">主管倉庫コード</param>
        /// <param name="stockBlnktRemark">在庫一括リマーク</param>
        /// <returns>Warehouseクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Warehouseクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        public Warehouse(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string warehouseCode, string warehouseName, string warehouseNote1, string warehouseNote2, string warehouseNote3, string warehouseNote4, string warehouseNote5, string enterpriseName, string updEmployeeName)
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        public Warehouse(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string warehouseCode, string warehouseName, string warehouseNote1, string enterpriseName, string updEmployeeName, int customerCode, string mainMngWarehouseCd, string stockBlnktRemark)
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
            this._warehouseCode = warehouseCode;
            this._warehouseName = warehouseName;
            this._warehouseNote1 = warehouseNote1;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._warehouseNote2 = warehouseNote2;
            this._warehouseNote3 = warehouseNote3;
            this._warehouseNote4 = warehouseNote4;
            this._warehouseNote5 = warehouseNote5;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            this._customerCode = customerCode;
            this._mainMngWarehouseCd = mainMngWarehouseCd;
            this._stockBlnktRemark = stockBlnktRemark;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 倉庫マスタ複製処理
        /// </summary>
        /// <returns>Warehouseクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいWarehouseクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Warehouse Clone()
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            return new Warehouse(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._warehouseCode, this._warehouseName, this._warehouseNote1, this._warehouseNote2, this._warehouseNote3, this._warehouseNote4, this._warehouseNote5, this._enterpriseName, this._updEmployeeName);
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            return new Warehouse(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._warehouseCode, this._warehouseName, this._warehouseNote1, this._enterpriseName, this._updEmployeeName, this._customerCode, this._mainMngWarehouseCd, this._stockBlnktRemark);
        }

        /// <summary>
        /// 倉庫マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のWarehouseクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Warehouseクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(Warehouse target)
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
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.WarehouseName == target.WarehouseName)
                 && (this.WarehouseNote1 == target.WarehouseNote1)
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                && (this.WarehouseNote2 == target.WarehouseNote2)
                && (this.WarehouseNote3 == target.WarehouseNote3)
                && (this.WarehouseNote4 == target.WarehouseNote4)
                && (this.WarehouseNote5 == target.WarehouseNote5)
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                 && (this.EnterpriseName == target.EnterpriseName)

                 // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.MainMngWarehouseCd == target.MainMngWarehouseCd)
                 && (this.StockBlnktRemark == target.StockBlnktRemark)
                 // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 倉庫マスタ比較処理
        /// </summary>
        /// <param name="warehouse1">
        ///                    比較するWarehouseクラスのインスタンス
        /// </param>
        /// <param name="warehouse2">比較するWarehouseクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Warehouseクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(Warehouse warehouse1, Warehouse warehouse2)
        {
            return ((warehouse1.CreateDateTime == warehouse2.CreateDateTime)
                 && (warehouse1.UpdateDateTime == warehouse2.UpdateDateTime)
                 && (warehouse1.EnterpriseCode == warehouse2.EnterpriseCode)
                 && (warehouse1.FileHeaderGuid == warehouse2.FileHeaderGuid)
                 && (warehouse1.UpdEmployeeCode == warehouse2.UpdEmployeeCode)
                 && (warehouse1.UpdAssemblyId1 == warehouse2.UpdAssemblyId1)
                 && (warehouse1.UpdAssemblyId2 == warehouse2.UpdAssemblyId2)
                 && (warehouse1.LogicalDeleteCode == warehouse2.LogicalDeleteCode)
                 && (warehouse1.SectionCode == warehouse2.SectionCode)
                 && (warehouse1.WarehouseCode == warehouse2.WarehouseCode)
                 && (warehouse1.WarehouseName == warehouse2.WarehouseName)
                 && (warehouse1.WarehouseNote1 == warehouse2.WarehouseNote1)
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                && (warehouse1.WarehouseNote2 == warehouse2.WarehouseNote2)
                && (warehouse1.WarehouseNote3 == warehouse2.WarehouseNote3)
                && (warehouse1.WarehouseNote4 == warehouse2.WarehouseNote4)
                && (warehouse1.WarehouseNote5 == warehouse2.WarehouseNote5)
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                 && (warehouse1.EnterpriseName == warehouse2.EnterpriseName)

                 // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                 && (warehouse1.CustomerCode == warehouse2.CustomerCode)
                 && (warehouse1.MainMngWarehouseCd == warehouse2.MainMngWarehouseCd)
                 && (warehouse1.StockBlnktRemark == warehouse2.StockBlnktRemark)
                 // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                 && (warehouse1.UpdEmployeeName == warehouse2.UpdEmployeeName));
        }
        /// <summary>
        /// 倉庫マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のWarehouseクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Warehouseクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(Warehouse target)
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
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.WarehouseNote1 != target.WarehouseNote1) resList.Add("WarehouseNote1");
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            if (this.WarehouseNote2 != target.WarehouseNote2) resList.Add("WarehouseNote2");
            if (this.WarehouseNote3 != target.WarehouseNote3) resList.Add("WarehouseNote3");
            if (this.WarehouseNote4 != target.WarehouseNote4) resList.Add("WarehouseNote4");
            if (this.WarehouseNote5 != target.WarehouseNote5) resList.Add("WarehouseNote5");
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.MainMngWarehouseCd != target.MainMngWarehouseCd) resList.Add("MainMngWarehouseCd");
            if (this.StockBlnktRemark != target.StockBlnktRemark) resList.Add("StockBlnktRemark");
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return resList;
        }

        /// <summary>
        /// 倉庫マスタ比較処理
        /// </summary>
        /// <param name="warehouse1">比較するWarehouseクラスのインスタンス</param>
        /// <param name="warehouse2">比較するWarehouseクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Warehouseクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(Warehouse warehouse1, Warehouse warehouse2)
        {
            ArrayList resList = new ArrayList();
            if (warehouse1.CreateDateTime != warehouse2.CreateDateTime) resList.Add("CreateDateTime");
            if (warehouse1.UpdateDateTime != warehouse2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (warehouse1.EnterpriseCode != warehouse2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (warehouse1.FileHeaderGuid != warehouse2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (warehouse1.UpdEmployeeCode != warehouse2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (warehouse1.UpdAssemblyId1 != warehouse2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (warehouse1.UpdAssemblyId2 != warehouse2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (warehouse1.LogicalDeleteCode != warehouse2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (warehouse1.SectionCode != warehouse2.SectionCode) resList.Add("SectionCode");
            if (warehouse1.WarehouseCode != warehouse2.WarehouseCode) resList.Add("WarehouseCode");
            if (warehouse1.WarehouseName != warehouse2.WarehouseName) resList.Add("WarehouseName");
            if (warehouse1.WarehouseNote1 != warehouse2.WarehouseNote1) resList.Add("WarehouseNote1");
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            if (warehouse1.WarehouseNote2 != warehouse2.WarehouseNote2) resList.Add("WarehouseNote2");
            if (warehouse1.WarehouseNote3 != warehouse2.WarehouseNote3) resList.Add("WarehouseNote3");
            if (warehouse1.WarehouseNote4 != warehouse2.WarehouseNote4) resList.Add("WarehouseNote4");
            if (warehouse1.WarehouseNote5 != warehouse2.WarehouseNote5) resList.Add("WarehouseNote5");
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            if (warehouse1.EnterpriseName != warehouse2.EnterpriseName) resList.Add("EnterpriseName");
            if (warehouse1.UpdEmployeeName != warehouse2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            if (warehouse1.CustomerCode != warehouse2.CustomerCode) resList.Add("CustomerCode");
            if (warehouse1.MainMngWarehouseCd != warehouse2.MainMngWarehouseCd) resList.Add("MainMngWarehouseCd");
            if (warehouse1.StockBlnktRemark != warehouse2.StockBlnktRemark) resList.Add("StockBlnktRemark");
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return resList;
        }
    }
}
