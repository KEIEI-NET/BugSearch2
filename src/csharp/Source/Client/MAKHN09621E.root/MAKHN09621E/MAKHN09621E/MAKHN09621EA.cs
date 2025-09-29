using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsSet
    /// <summary>
    ///                      商品セットマスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品セットマスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2007/4/20</br>
    /// <br>Genarated Date   :   2007/09/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class GoodsSet
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

        /// <summary>親メーカーコード</summary>
        private Int32 _parentGoodsMakerCd;

        /// <summary>親メーカー名</summary>
        private string _parentGoodsMakerName = "";

        /// <summary>親商品番号</summary>
        private string _parentGoodsNo = "";

        /// <summary>親商品名</summary>
        private string _parentGoodsName = "";

        /// <summary>子商品メーカーコード</summary>
        private Int32 _subGoodsMakerCd;

        /// <summary>子商品メーカー名</summary>
        private string _subGoodsMakerName = "";

        /// <summary>子商品番号</summary>
        private string _subGoodsNo = "";

        /// <summary>子商品名</summary>
        private string _subGoodsName = "";

        /// <summary>数量（浮動）</summary>
        private Double _cntFl;

        /// <summary>表示順位</summary>
        private Int32 _displayOrder;

        /// <summary>セット規格・特記事項</summary>
        private string _setSpecialNote = "";

        /// <summary>カタログ図番</summary>
        private string _catalogShapeNo = "";

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

        /// public propaty name  :  ParentGoodsMakerCd
        /// <summary>親メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ParentGoodsMakerCd
        {
            get { return _parentGoodsMakerCd; }
            set { _parentGoodsMakerCd = value; }
        }

        /// public propaty name  :  ParentGoodsMakerName
        /// <summary>親メーカー名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親メーカー名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentGoodsMakerName
        {
            get { return _parentGoodsMakerName; }
            set { _parentGoodsMakerName = value; }
        }

        /// public propaty name  :  ParentGoodsNo
        /// <summary>親商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentGoodsNo
        {
            get { return _parentGoodsNo; }
            set { _parentGoodsNo = value; }
        }

        /// public propaty name  :  ParentGoodsName
        /// <summary>親商品名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親商品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentGoodsName
        {
            get { return _parentGoodsName; }
            set { _parentGoodsName = value; }
        }

        /// public propaty name  :  SubGoodsMakerCd
        /// <summary>子商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   子商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubGoodsMakerCd
        {
            get { return _subGoodsMakerCd; }
            set { _subGoodsMakerCd = value; }
        }

        /// public propaty name  :  SubGoodsMakerName
        /// <summary>子商品メーカー名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   子商品名コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SubGoodsMakerName
        {
            get { return _subGoodsMakerName; }
            set { _subGoodsMakerName = value; }
        }

        /// public propaty name  :  SubGoodsNo
        /// <summary>子商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   子商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SubGoodsNo
        {
            get { return _subGoodsNo; }
            set { _subGoodsNo = value; }
        }

        /// public propaty name  :  SubGoodsName
        /// <summary>子商品名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   子商品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SubGoodsName
        {
            get { return _subGoodsName; }
            set { _subGoodsName = value; }
        }

        /// public propaty name  :  CntFl
        /// <summary>数量（浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   数量（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CntFl
        {
            get { return _cntFl; }
            set { _cntFl = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  SetSpecialNote
        /// <summary>セット規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SetSpecialNote
        {
            get { return _setSpecialNote; }
            set { _setSpecialNote = value; }
        }

        /// public propaty name  :  CatalogShapeNo
        /// <summary>カタログ図番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カタログ図番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CatalogShapeNo
        {
            get { return _catalogShapeNo; }
            set { _catalogShapeNo = value; }
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
        /// 商品セットマスタコンストラクタ
        /// </summary>
        /// <returns>GoodsSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsSet()
        {
        }

        /// <summary>
        /// 商品セットマスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="parentGoodsMakerCd">親メーカーコード</param>
        /// <param name="parentGoodsMakerName">親メーカー名</param>
        /// <param name="parentGoodsNo">親商品番号</param>
        /// <param name="parentGoodsName">親商品名</param>
        /// <param name="subGoodsMakerCd">子商品メーカーコード</param>
        /// <param name="subGoodsMakerName">子商品メーカー名</param>
        /// <param name="subGoodsNo">子商品番号</param>
        /// <param name="subGoodsName">子商品名</param>
        /// <param name="cntFl">数量（浮動）</param>
        /// <param name="displayOrder">表示順位</param>
        /// <param name="setSpecialNote">セット規格・特記事項</param>
        /// <param name="catalogShapeNo">カタログ図番</param>
        /// <param name="division">表示区分</param>
        /// <param name="divisionName">表示区分名称</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>GoodsSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 parentGoodsMakerCd, string parentGoodsMakerName, string parentGoodsNo, string parentGoodsName, Int32 subGoodsMakerCd, string subGoodsMakerName, string subGoodsNo, string subGoodsName, Double cntFl, Int32 displayOrder, string setSpecialNote, string catalogShapeNo, Int32 division, string divisionName, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._parentGoodsMakerCd = parentGoodsMakerCd;
            this._parentGoodsMakerName = parentGoodsMakerName;
            this._parentGoodsNo = parentGoodsNo;
            this._parentGoodsName = parentGoodsName;
            this._subGoodsMakerCd = subGoodsMakerCd;
            this._subGoodsMakerName = subGoodsMakerName;
            this._subGoodsNo = subGoodsNo;
            this._subGoodsName = subGoodsName;
            this._cntFl = cntFl;
            this._displayOrder = displayOrder;
            this._setSpecialNote = setSpecialNote;
            this._catalogShapeNo = catalogShapeNo;
            this._division = division;
            this._divisionName = divisionName;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// 商品セットマスタ複製処理
        /// </summary>
        /// <returns>GoodsSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいGoodsSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsSet Clone()
        {
            return new GoodsSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._parentGoodsMakerCd, this._parentGoodsMakerName, this._parentGoodsNo, this._parentGoodsName, this._subGoodsMakerCd, this._subGoodsMakerName, this._subGoodsNo, this._subGoodsName, this._cntFl, this._displayOrder, this._setSpecialNote, this._catalogShapeNo, this._division, this._divisionName, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// 商品セットマスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のGoodsSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(GoodsSet target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.ParentGoodsMakerCd == target.ParentGoodsMakerCd)
                 && (this.ParentGoodsMakerName == target.ParentGoodsMakerName)
                 && (this.ParentGoodsNo == target.ParentGoodsNo)
                 && (this.ParentGoodsName == target.ParentGoodsName)
                 && (this.SubGoodsMakerCd == target.SubGoodsMakerCd)
                 && (this.SubGoodsMakerName == target.SubGoodsMakerName)
                 && (this.SubGoodsNo == target.SubGoodsNo)
                 && (this.SubGoodsName == target.SubGoodsName)
                 && (this.CntFl == target.CntFl)
                 && (this.DisplayOrder == target.DisplayOrder)
                 && (this.SetSpecialNote == target.SetSpecialNote)
                 && (this.CatalogShapeNo == target.CatalogShapeNo)
                 && (this.Division == target.Division)
                 && (this.DivisionName == target.DivisionName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 商品セットマスタ比較処理
        /// </summary>
        /// <param name="goodsSet1">
        ///                    比較するGoodsSetクラスのインスタンス
        /// </param>
        /// <param name="goodsSet2">比較するGoodsSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(GoodsSet goodsSet1, GoodsSet goodsSet2)
        {
            return ((goodsSet1.CreateDateTime == goodsSet2.CreateDateTime)
                 && (goodsSet1.UpdateDateTime == goodsSet2.UpdateDateTime)
                 && (goodsSet1.EnterpriseCode == goodsSet2.EnterpriseCode)
                 && (goodsSet1.FileHeaderGuid == goodsSet2.FileHeaderGuid)
                 && (goodsSet1.UpdEmployeeCode == goodsSet2.UpdEmployeeCode)
                 && (goodsSet1.UpdAssemblyId1 == goodsSet2.UpdAssemblyId1)
                 && (goodsSet1.UpdAssemblyId2 == goodsSet2.UpdAssemblyId2)
                 && (goodsSet1.LogicalDeleteCode == goodsSet2.LogicalDeleteCode)
                 && (goodsSet1.ParentGoodsMakerCd == goodsSet2.ParentGoodsMakerCd)
                 && (goodsSet1.ParentGoodsMakerName == goodsSet2.ParentGoodsMakerName)
                 && (goodsSet1.ParentGoodsNo == goodsSet2.ParentGoodsNo)
                 && (goodsSet1.ParentGoodsName == goodsSet2.ParentGoodsName)
                 && (goodsSet1.SubGoodsMakerCd == goodsSet2.SubGoodsMakerCd)
                 && (goodsSet1.SubGoodsMakerName == goodsSet2.SubGoodsMakerName)
                 && (goodsSet1.SubGoodsNo == goodsSet2.SubGoodsNo)
                 && (goodsSet1.SubGoodsName == goodsSet2.SubGoodsName)
                 && (goodsSet1.CntFl == goodsSet2.CntFl)
                 && (goodsSet1.DisplayOrder == goodsSet2.DisplayOrder)
                 && (goodsSet1.SetSpecialNote == goodsSet2.SetSpecialNote)
                 && (goodsSet1.CatalogShapeNo == goodsSet2.CatalogShapeNo)
                 && (goodsSet1.Division == goodsSet2.Division)
                 && (goodsSet1.DivisionName == goodsSet2.DivisionName)
                 && (goodsSet1.EnterpriseName == goodsSet2.EnterpriseName)
                 && (goodsSet1.UpdEmployeeName == goodsSet2.UpdEmployeeName));
        }
        /// <summary>
        /// 商品セットマスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のGoodsSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(GoodsSet target)
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
            if (this.ParentGoodsMakerCd != target.ParentGoodsMakerCd) resList.Add("ParentGoodsMakerCd");
            if (this.ParentGoodsMakerName != target.ParentGoodsMakerName) resList.Add("ParentGoodsMakerName");
            if (this.ParentGoodsNo != target.ParentGoodsNo) resList.Add("ParentGoodsNo");
            if (this.ParentGoodsName != target.ParentGoodsName) resList.Add("ParentGoodsName");
            if (this.SubGoodsMakerCd != target.SubGoodsMakerCd) resList.Add("SubGoodsMakerCd");
            if (this.SubGoodsMakerName != target.SubGoodsMakerName) resList.Add("SubGoodsMakerName");
            if (this.SubGoodsNo != target.SubGoodsNo) resList.Add("SubGoodsNo");
            if (this.SubGoodsName != target.SubGoodsName) resList.Add("SubGoodsName");
            if (this.CntFl != target.CntFl) resList.Add("CntFl");
            if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
            if (this.SetSpecialNote != target.SetSpecialNote) resList.Add("SetSpecialNote");
            if (this.CatalogShapeNo != target.CatalogShapeNo) resList.Add("CatalogShapeNo");
            if (this.Division != target.Division) resList.Add("Division");
            if (this.DivisionName != target.DivisionName) resList.Add("DivisionName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// 商品セットマスタ比較処理
        /// </summary>
        /// <param name="goodsSet1">比較するGoodsSetクラスのインスタンス</param>
        /// <param name="goodsSet2">比較するGoodsSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(GoodsSet goodsSet1, GoodsSet goodsSet2)
        {
            ArrayList resList = new ArrayList();
            if (goodsSet1.CreateDateTime != goodsSet2.CreateDateTime) resList.Add("CreateDateTime");
            if (goodsSet1.UpdateDateTime != goodsSet2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (goodsSet1.EnterpriseCode != goodsSet2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (goodsSet1.FileHeaderGuid != goodsSet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (goodsSet1.UpdEmployeeCode != goodsSet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (goodsSet1.UpdAssemblyId1 != goodsSet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (goodsSet1.UpdAssemblyId2 != goodsSet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (goodsSet1.LogicalDeleteCode != goodsSet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (goodsSet1.ParentGoodsMakerCd != goodsSet2.ParentGoodsMakerCd) resList.Add("ParentGoodsMakerCd");
            if (goodsSet1.ParentGoodsMakerName != goodsSet2.ParentGoodsMakerName) resList.Add("ParentGoodsMakerName");
            if (goodsSet1.ParentGoodsNo != goodsSet2.ParentGoodsNo) resList.Add("ParentGoodsNo");
            if (goodsSet1.ParentGoodsName != goodsSet2.ParentGoodsName) resList.Add("ParentGoodsName");
            if (goodsSet1.SubGoodsMakerCd != goodsSet2.SubGoodsMakerCd) resList.Add("SubGoodsMakerCd");
            if (goodsSet1.SubGoodsMakerName != goodsSet2.SubGoodsMakerName) resList.Add("SubGoodsMakerName");
            if (goodsSet1.SubGoodsNo != goodsSet2.SubGoodsNo) resList.Add("SubGoodsNo");
            if (goodsSet1.SubGoodsName != goodsSet2.SubGoodsName) resList.Add("SubGoodsName");
            if (goodsSet1.CntFl != goodsSet2.CntFl) resList.Add("CntFl");
            if (goodsSet1.DisplayOrder != goodsSet2.DisplayOrder) resList.Add("DisplayOrder");
            if (goodsSet1.SetSpecialNote != goodsSet2.SetSpecialNote) resList.Add("SetSpecialNote");
            if (goodsSet1.CatalogShapeNo != goodsSet2.CatalogShapeNo) resList.Add("CatalogShapeNo");
            if (goodsSet1.Division != goodsSet2.Division) resList.Add("Division");
            if (goodsSet1.DivisionName != goodsSet2.DivisionName) resList.Add("DivisionName");
            if (goodsSet1.EnterpriseName != goodsSet2.EnterpriseName) resList.Add("EnterpriseName");
            if (goodsSet1.UpdEmployeeName != goodsSet2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
