using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PartsPosCodeU
    /// <summary>
    ///                      部位コードマスタ（ユーザー登録）
    /// </summary>
    /// <remarks>
    /// <br>note             :   部位コードマスタ（ユーザー登録）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/5/28</br>
    /// <br>Genarated Date   :   2008/06/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PartsPosCodeU
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
        /// <remarks>※未使用</remarks>
        private string _sectionCode = "";

        /// <summary>得意先コード</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>検索部位コード</summary>
        private Int32 _searchPartsPosCode;

        /// <summary>検索部位コード名称</summary>
        /// <remarks>表示順位0、BLコード0の場合部位名称をセット</remarks>
        private string _searchPartsPosName = "";

        /// <summary>検索部位表示順位</summary>
        private Int32 _posDispOrder;

        /// <summary>BLコード</summary>
        /// <remarks>０の場合、部位名称用レコード</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>BLコード枝番</summary>
        /// <remarks>※未使用項目（レイアウトには入れておく）</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>BL名称</summary>
        private string _tbsPartsName = "";

        /// <summary>表示区分</summary>
        private Int32 _division;

        /// <summary>表示区分名称</summary>
        private string _divisionName = "";

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
        /// <value>※未使用</value>
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
        /// <value>納入先の場合の使用可能項目</value>
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

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SearchPartsPosCode
        /// <summary>検索部位コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索部位コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchPartsPosCode
        {
            get { return _searchPartsPosCode; }
            set { _searchPartsPosCode = value; }
        }

        /// public propaty name  :  SearchPartsPosName
        /// <summary>検索部位コード名称プロパティ</summary>
        /// <value>表示順位0、BLコード0の場合部位名称をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索部位コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchPartsPosName
        {
            get { return _searchPartsPosName; }
            set { _searchPartsPosName = value; }
        }

        /// public propaty name  :  PosDispOrder
        /// <summary>検索部位表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索部位表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PosDispOrder
        {
            get { return _posDispOrder; }
            set { _posDispOrder = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>BLコードプロパティ</summary>
        /// <value>０の場合、部位名称用レコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>BLコード枝番プロパティ</summary>
        /// <value>※未使用項目（レイアウトには入れておく）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }

        /// public propaty name  :  TbsPartsName
        /// <summary>BL名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TbsPartsName
        {
            get { return _tbsPartsName; }
            set { _tbsPartsName = value; }
        }

        /// public propaty name  :  Division
        /// <summary>表示区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Division
        {
            get { return _division; }
            set { _division = value; }
        }

        /// public propaty name  :  DivisionName
        /// <summary>表示区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DivisionName
        {
            get { return _divisionName; }
            set { _divisionName = value; }
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
        /// 部位コードマスタ（ユーザー登録）コンストラクタ
        /// </summary>
        /// <returns>PartsPosCodeUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsPosCodeUクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsPosCodeU()
        {
        }

        /// <summary>
        /// 部位コードマスタ（ユーザー登録）コンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード(※未使用)</param>
        /// <param name="customerCode">得意先コード(納入先の場合の使用可能項目)</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="searchPartsPosCode">検索部位コード</param>
        /// <param name="searchPartsPosName">検索部位コード名称(表示順位0、BLコード0の場合部位名称をセット)</param>
        /// <param name="posDispOrder">検索部位表示順位</param>
        /// <param name="tbsPartsCode">BLコード(０の場合、部位名称用レコード)</param>
        /// <param name="tbsPartsCdDerivedNo">BLコード枝番(※未使用項目（レイアウトには入れておく）)</param>
        /// <param name="tbsPartsName">BL名称</param>
        /// <param name="division">表示区分</param>
        /// <param name="divisionName">表示区分名称</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>PartsPosCodeUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsPosCodeUクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsPosCodeU(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 customerCode, string customerSnm, Int32 searchPartsPosCode, string searchPartsPosName, Int32 posDispOrder, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo, string tbsPartsName, Int32 division, string divisionName, string enterpriseName, string updEmployeeName)
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
            this._customerCode = customerCode;
            this._customerSnm = customerSnm;
            this._searchPartsPosCode = searchPartsPosCode;
            this._searchPartsPosName = searchPartsPosName;
            this._posDispOrder = posDispOrder;
            this._tbsPartsCode = tbsPartsCode;
            this._tbsPartsCdDerivedNo = tbsPartsCdDerivedNo;
            this._tbsPartsName = tbsPartsName;
            this._division = division;
            this._divisionName = divisionName;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// 部位コードマスタ（ユーザー登録）複製処理
        /// </summary>
        /// <returns>PartsPosCodeUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPartsPosCodeUクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsPosCodeU Clone()
        {
            return new PartsPosCodeU(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._customerCode, this._customerSnm, this._searchPartsPosCode, this._searchPartsPosName, this._posDispOrder, this._tbsPartsCode, this._tbsPartsCdDerivedNo, this._tbsPartsName, this._division, this._divisionName, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// 部位コードマスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="target">比較対象のPartsPosCodeUクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsPosCodeUクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PartsPosCodeU target)
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
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.SearchPartsPosCode == target.SearchPartsPosCode)
                 && (this.SearchPartsPosName == target.SearchPartsPosName)
                 && (this.PosDispOrder == target.PosDispOrder)
                 && (this.TbsPartsCode == target.TbsPartsCode)
                 && (this.TbsPartsCdDerivedNo == target.TbsPartsCdDerivedNo)
                 && (this.TbsPartsName == target.TbsPartsName)
                 && (this.Division == target.Division)
                 && (this.DivisionName == target.DivisionName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 部位コードマスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="partsPosCodeU1">
        ///                    比較するPartsPosCodeUクラスのインスタンス
        /// </param>
        /// <param name="partsPosCodeU2">比較するPartsPosCodeUクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsPosCodeUクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PartsPosCodeU partsPosCodeU1, PartsPosCodeU partsPosCodeU2)
        {
            return ((partsPosCodeU1.CreateDateTime == partsPosCodeU2.CreateDateTime)
                 && (partsPosCodeU1.UpdateDateTime == partsPosCodeU2.UpdateDateTime)
                 && (partsPosCodeU1.EnterpriseCode == partsPosCodeU2.EnterpriseCode)
                 && (partsPosCodeU1.FileHeaderGuid == partsPosCodeU2.FileHeaderGuid)
                 && (partsPosCodeU1.UpdEmployeeCode == partsPosCodeU2.UpdEmployeeCode)
                 && (partsPosCodeU1.UpdAssemblyId1 == partsPosCodeU2.UpdAssemblyId1)
                 && (partsPosCodeU1.UpdAssemblyId2 == partsPosCodeU2.UpdAssemblyId2)
                 && (partsPosCodeU1.LogicalDeleteCode == partsPosCodeU2.LogicalDeleteCode)
                 && (partsPosCodeU1.SectionCode == partsPosCodeU2.SectionCode)
                 && (partsPosCodeU1.CustomerCode == partsPosCodeU2.CustomerCode)
                 && (partsPosCodeU1.CustomerSnm == partsPosCodeU2.CustomerSnm)
                 && (partsPosCodeU1.SearchPartsPosCode == partsPosCodeU2.SearchPartsPosCode)
                 && (partsPosCodeU1.SearchPartsPosName == partsPosCodeU2.SearchPartsPosName)
                 && (partsPosCodeU1.PosDispOrder == partsPosCodeU2.PosDispOrder)
                 && (partsPosCodeU1.TbsPartsCode == partsPosCodeU2.TbsPartsCode)
                 && (partsPosCodeU1.TbsPartsCdDerivedNo == partsPosCodeU2.TbsPartsCdDerivedNo)
                 && (partsPosCodeU1.TbsPartsName == partsPosCodeU2.TbsPartsName)
                 && (partsPosCodeU1.Division == partsPosCodeU2.Division)
                 && (partsPosCodeU1.DivisionName == partsPosCodeU2.DivisionName)
                 && (partsPosCodeU1.EnterpriseName == partsPosCodeU2.EnterpriseName)
                 && (partsPosCodeU1.UpdEmployeeName == partsPosCodeU2.UpdEmployeeName));
        }
        /// <summary>
        /// 部位コードマスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="target">比較対象のPartsPosCodeUクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsPosCodeUクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PartsPosCodeU target)
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
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.SearchPartsPosCode != target.SearchPartsPosCode) resList.Add("SearchPartsPosCode");
            if (this.SearchPartsPosName != target.SearchPartsPosName) resList.Add("SearchPartsPosName");
            if (this.PosDispOrder != target.PosDispOrder) resList.Add("PosDispOrder");
            if (this.TbsPartsCode != target.TbsPartsCode) resList.Add("TbsPartsCode");
            if (this.TbsPartsCdDerivedNo != target.TbsPartsCdDerivedNo) resList.Add("TbsPartsCdDerivedNo");
            if (this.TbsPartsName != target.TbsPartsName) resList.Add("TbsPartsName");
            if (this.Division != target.Division) resList.Add("Division");
            if (this.DivisionName != target.DivisionName) resList.Add("DivisionName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// 部位コードマスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="partsPosCodeU1">比較するPartsPosCodeUクラスのインスタンス</param>
        /// <param name="partsPosCodeU2">比較するPartsPosCodeUクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsPosCodeUクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PartsPosCodeU partsPosCodeU1, PartsPosCodeU partsPosCodeU2)
        {
            ArrayList resList = new ArrayList();
            if (partsPosCodeU1.CreateDateTime != partsPosCodeU2.CreateDateTime) resList.Add("CreateDateTime");
            if (partsPosCodeU1.UpdateDateTime != partsPosCodeU2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (partsPosCodeU1.EnterpriseCode != partsPosCodeU2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (partsPosCodeU1.FileHeaderGuid != partsPosCodeU2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (partsPosCodeU1.UpdEmployeeCode != partsPosCodeU2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (partsPosCodeU1.UpdAssemblyId1 != partsPosCodeU2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (partsPosCodeU1.UpdAssemblyId2 != partsPosCodeU2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (partsPosCodeU1.LogicalDeleteCode != partsPosCodeU2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (partsPosCodeU1.SectionCode != partsPosCodeU2.SectionCode) resList.Add("SectionCode");
            if (partsPosCodeU1.CustomerCode != partsPosCodeU2.CustomerCode) resList.Add("CustomerCode");
            if (partsPosCodeU1.CustomerSnm != partsPosCodeU2.CustomerSnm) resList.Add("CustomerSnm");
            if (partsPosCodeU1.SearchPartsPosCode != partsPosCodeU2.SearchPartsPosCode) resList.Add("SearchPartsPosCode");
            if (partsPosCodeU1.SearchPartsPosName != partsPosCodeU2.SearchPartsPosName) resList.Add("SearchPartsPosName");
            if (partsPosCodeU1.PosDispOrder != partsPosCodeU2.PosDispOrder) resList.Add("PosDispOrder");
            if (partsPosCodeU1.TbsPartsCode != partsPosCodeU2.TbsPartsCode) resList.Add("TbsPartsCode");
            if (partsPosCodeU1.TbsPartsCdDerivedNo != partsPosCodeU2.TbsPartsCdDerivedNo) resList.Add("TbsPartsCdDerivedNo");
            if (partsPosCodeU1.TbsPartsName != partsPosCodeU2.TbsPartsName) resList.Add("TbsPartsName");
            if (partsPosCodeU1.Division != partsPosCodeU2.Division) resList.Add("Division");
            if (partsPosCodeU1.DivisionName != partsPosCodeU2.DivisionName) resList.Add("DivisionName");
            if (partsPosCodeU1.EnterpriseName != partsPosCodeU2.EnterpriseName) resList.Add("EnterpriseName");
            if (partsPosCodeU1.UpdEmployeeName != partsPosCodeU2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
