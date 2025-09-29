using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ModelNameU
    /// <summary>
    ///                      車種名称マスタ（ユーザー登録）
    /// </summary>
    /// <remarks>
    /// <br>note             :   車種名称マスタ（ユーザー登録）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/05/27</br>
    /// <br>Genarated Date   :   2008/06/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class ModelNameU
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        /// 
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

        /// <summary>車種コード（ユニーク）</summary>
        /// <remarks>メーカーコード3桁+車種コード3桁+車種サブコード3桁</remarks>
        private Int32 _modelUniqueCode;

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>車種コード</summary>
        /// <remarks>車名ｺｰﾄﾞ(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _modelCode;

        /// <summary>車種サブコード</summary>
        /// <remarks>0～899:提供分,900～ユーザー登録</remarks>
        private Int32 _modelSubCode;

        /// <summary>車種全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _modelFullName = "";

        /// <summary>車種半角名称</summary>
        /// <remarks>正式名称（半角で管理）</remarks>
        private string _modelHalfName = "";

        /// <summary>車種呼び名名称</summary>
        /// <remarks>呼び名（発音で管理）</remarks>
        private string _modelAliasName = "";

        /// <summary>表示区分</summary>
        private Int32 _division;

        /// <summary>表示区分名称</summary>
        private string _divisionName = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>提供データ区分</summary>
        /// <remarks>0:提供データ,1:ユーザーデータ</remarks>
        private Int32 _offerDataDiv;

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

        /// public propaty name  :  ModelUniqueCode
        /// <summary>車種コード（ユニーク）プロパティ</summary>
        /// <value>メーカーコード3桁+車種コード3桁+車種サブコード3桁</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コード（ユニーク）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelUniqueCode
        {
            get { return _modelUniqueCode; }
            set { _modelUniqueCode = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>車種コードプロパティ</summary>
        /// <value>車名ｺｰﾄﾞ(翼) 1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  ModelSubCode
        /// <summary>車種サブコードプロパティ</summary>
        /// <value>0～899:提供分,900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>車種全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  ModelHalfName
        /// <summary>車種半角名称プロパティ</summary>
        /// <value>正式名称（半角で管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種半角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelHalfName
        {
            get { return _modelHalfName; }
            set { _modelHalfName = value; }
        }

        /// public propaty name  :  ModelAliasName
        /// <summary>車種呼び名名称プロパティ</summary>
        /// <value>呼び名（発音で管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種呼び名名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelAliasName
        {
            get { return _modelAliasName; }
            set { _modelAliasName = value; }
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


        /// public propaty name  :  OfferDate
        /// <summary>提供日付</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  OfferDataDiv
        /// <summary>提供データ区分</summary>
        /// <value>0:提供データ,1:ユーザーデータ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDataDiv
        {
            get { return _offerDataDiv; }
            set { _offerDataDiv = value; }
        }

        /// <summary>
        /// 車種名称マスタ（ユーザー登録）コンストラクタ
        /// </summary>
        /// <returns>ModelNameUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNameUクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ModelNameU()
        {
        }

        /// <summary>
        /// 車種名称マスタ（ユーザー登録）コンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="modelUniqueCode">車種コード（ユニーク）(メーカーコード3桁+車種コード3桁+車種サブコード3桁)</param>
        /// <param name="makerCode">メーカーコード(1～899:提供分, 900～ユーザー登録)</param>
        /// <param name="modelCode">車種コード(車名ｺｰﾄﾞ(翼) 1～899:提供分, 900～ユーザー登録)</param>
        /// <param name="modelSubCode">車種サブコード(0～899:提供分,900～ユーザー登録)</param>
        /// <param name="modelFullName">車種全角名称(正式名称（カナ漢字混在で全角管理）)</param>
        /// <param name="modelHalfName">車種半角名称(正式名称（半角で管理）)</param>
        /// <param name="modelAliasName">車種呼び名名称(呼び名（発音で管理）)</param>
        /// <param name="division">表示区分</param>
        /// <param name="divisionName">表示区分名称</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="offerDate">提供日付</param>
        /// <param name="offerDataDiv">提供データ区分</param>
        /// <returns>ModelNameUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNameUクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ModelNameU(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 modelUniqueCode, Int32 makerCode, Int32 modelCode, Int32 modelSubCode, string modelFullName, string modelHalfName, string modelAliasName, Int32 division, string divisionName, string enterpriseName, string updEmployeeName, DateTime offerDate, Int32 offerDataDiv)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._modelUniqueCode = modelUniqueCode;
            this._makerCode = makerCode;
            this._modelCode = modelCode;
            this._modelSubCode = modelSubCode;
            this._modelFullName = modelFullName;
            this._modelHalfName = modelHalfName;
            this._modelAliasName = modelAliasName;
            this._division = division;
            this._divisionName = divisionName;
			this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this.OfferDate = offerDate;
            this._offerDataDiv = offerDataDiv;

        }

        /// <summary>
        /// 車種名称マスタ（ユーザー登録）複製処理
        /// </summary>
        /// <returns>ModelNameUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいModelNameUクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ModelNameU Clone()
        {
            return new ModelNameU(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._modelUniqueCode, this._makerCode, this._modelCode, this._modelSubCode, this._modelFullName, this._modelHalfName, this._modelAliasName, this._division, this._divisionName, this._enterpriseName, this._updEmployeeName, this._offerDate, this._offerDataDiv);
        }

        /// <summary>
        /// 車種名称マスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="target">比較対象のModelNameUクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNameUクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(ModelNameU target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.ModelUniqueCode == target.ModelUniqueCode)
                 && (this.MakerCode == target.MakerCode)
                 && (this.ModelCode == target.ModelCode)
                 && (this.ModelSubCode == target.ModelSubCode)
                 && (this.ModelFullName == target.ModelFullName)
                 && (this.ModelHalfName == target.ModelHalfName)
                 && (this.ModelAliasName == target.ModelAliasName)
                 && (this.Division == target.Division)
                 && (this.DivisionName == target.DivisionName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.OfferDate == target.OfferDate)
                 && (this.OfferDataDiv == target.OfferDataDiv));
        }

        /// <summary>
        /// 車種名称マスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="modelNameU1">
        ///                    比較するModelNameUクラスのインスタンス
        /// </param>
        /// <param name="modelNameU2">比較するModelNameUクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNameUクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(ModelNameU modelNameU1, ModelNameU modelNameU2)
        {
            return ((modelNameU1.CreateDateTime == modelNameU2.CreateDateTime)
                 && (modelNameU1.UpdateDateTime == modelNameU2.UpdateDateTime)
                 && (modelNameU1.EnterpriseCode == modelNameU2.EnterpriseCode)
                 && (modelNameU1.FileHeaderGuid == modelNameU2.FileHeaderGuid)
                 && (modelNameU1.UpdEmployeeCode == modelNameU2.UpdEmployeeCode)
                 && (modelNameU1.UpdAssemblyId1 == modelNameU2.UpdAssemblyId1)
                 && (modelNameU1.UpdAssemblyId2 == modelNameU2.UpdAssemblyId2)
                 && (modelNameU1.LogicalDeleteCode == modelNameU2.LogicalDeleteCode)
                 && (modelNameU1.ModelUniqueCode == modelNameU2.ModelUniqueCode)
                 && (modelNameU1.MakerCode == modelNameU2.MakerCode)
                 && (modelNameU1.ModelCode == modelNameU2.ModelCode)
                 && (modelNameU1.ModelSubCode == modelNameU2.ModelSubCode)
                 && (modelNameU1.ModelFullName == modelNameU2.ModelFullName)
                 && (modelNameU1.ModelHalfName == modelNameU2.ModelHalfName)
                 && (modelNameU1.ModelAliasName == modelNameU2.ModelAliasName)
                 && (modelNameU1.Division == modelNameU2.Division)
                 && (modelNameU1.DivisionName == modelNameU2.DivisionName)
                 && (modelNameU1.EnterpriseName == modelNameU2.EnterpriseName)
                 && (modelNameU1.UpdEmployeeName == modelNameU2.UpdEmployeeName)
                 && (modelNameU1.OfferDate == modelNameU2.OfferDate)
                 && (modelNameU1.OfferDataDiv == modelNameU2.OfferDataDiv));
        }
        /// <summary>
        /// 車種名称マスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="target">比較対象のModelNameUクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNameUクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(ModelNameU target)
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
            if (this.ModelUniqueCode != target.ModelUniqueCode) resList.Add("ModelUniqueCode");
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.ModelCode != target.ModelCode) resList.Add("ModelCode");
            if (this.ModelSubCode != target.ModelSubCode) resList.Add("ModelSubCode");
            if (this.ModelFullName != target.ModelFullName) resList.Add("ModelFullName");
            if (this.ModelHalfName != target.ModelHalfName) resList.Add("ModelHalfName");
            if (this.ModelAliasName != target.ModelAliasName) resList.Add("ModelAliasName");
            if (this.Division != target.Division) resList.Add("Division");
            if (this.DivisionName != target.DivisionName) resList.Add("DivisionName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.OfferDate != target.OfferDate) resList.Add("OfferDate");
            if (this.OfferDataDiv != target.OfferDataDiv) resList.Add("OfferDataDiv");

            return resList;
        }

        /// <summary>
        /// 車種名称マスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="modelNameU1">比較するModelNameUクラスのインスタンス</param>
        /// <param name="modelNameU2">比較するModelNameUクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNameUクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(ModelNameU modelNameU1, ModelNameU modelNameU2)
        {
            ArrayList resList = new ArrayList();
            if (modelNameU1.CreateDateTime != modelNameU2.CreateDateTime) resList.Add("CreateDateTime");
            if (modelNameU1.UpdateDateTime != modelNameU2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (modelNameU1.EnterpriseCode != modelNameU2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (modelNameU1.FileHeaderGuid != modelNameU2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (modelNameU1.UpdEmployeeCode != modelNameU2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (modelNameU1.UpdAssemblyId1 != modelNameU2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (modelNameU1.UpdAssemblyId2 != modelNameU2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (modelNameU1.LogicalDeleteCode != modelNameU2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (modelNameU1.ModelUniqueCode != modelNameU2.ModelUniqueCode) resList.Add("ModelUniqueCode");
            if (modelNameU1.MakerCode != modelNameU2.MakerCode) resList.Add("MakerCode");
            if (modelNameU1.ModelCode != modelNameU2.ModelCode) resList.Add("ModelCode");
            if (modelNameU1.ModelSubCode != modelNameU2.ModelSubCode) resList.Add("ModelSubCode");
            if (modelNameU1.ModelFullName != modelNameU2.ModelFullName) resList.Add("ModelFullName");
            if (modelNameU1.ModelHalfName != modelNameU2.ModelHalfName) resList.Add("ModelHalfName");
            if (modelNameU1.ModelAliasName != modelNameU2.ModelAliasName) resList.Add("ModelAliasName");
            if (modelNameU1.Division != modelNameU2.Division) resList.Add("Division");
            if (modelNameU1.DivisionName != modelNameU2.DivisionName) resList.Add("DivisionName");
            if (modelNameU1.EnterpriseName != modelNameU2.EnterpriseName) resList.Add("EnterpriseName");
            if (modelNameU1.UpdEmployeeName != modelNameU2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (modelNameU1.OfferDate != modelNameU2.OfferDate) resList.Add("OfferDate");
            if (modelNameU1.OfferDataDiv != modelNameU2.OfferDataDiv) resList.Add("OfferDataDiv");

            return resList;
        }
    }
}
