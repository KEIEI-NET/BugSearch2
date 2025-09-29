using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   IsolIslandPrc
    /// <summary>
    ///                      離島価格マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   離島価格マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/05/27</br>
    /// <br>Genarated Date   :   2008/06/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class IsolIslandPrc
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

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>上限金額</summary>
        /// <remarks>金額の場合は整数のみ設定</remarks>
        private Double _upperLimitPrice;

        /// <summary>端数処理単位</summary>
        private Double _fractionProcUnit;

        /// <summary>端数処理区分</summary>
        /// <remarks>1：切捨て,2：四捨五入,3:切上げ</remarks>
        private Int32 _fractionProcCd;

        /// <summary>UP率</summary>
        /// <remarks>価格UP率</remarks>
        private Double _upRate;

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

        /// public propaty name  :  UpperLimitPrice
        /// <summary>上限金額プロパティ</summary>
        /// <value>金額の場合は整数のみ設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   上限金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double UpperLimitPrice
        {
            get { return _upperLimitPrice; }
            set { _upperLimitPrice = value; }
        }

        /// public propaty name  :  FractionProcUnit
        /// <summary>端数処理単位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double FractionProcUnit
        {
            get { return _fractionProcUnit; }
            set { _fractionProcUnit = value; }
        }

        /// public propaty name  :  FractionProcCd
        /// <summary>端数処理区分プロパティ</summary>
        /// <value>1：切捨て,2：四捨五入,3:切上げ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FractionProcCd
        {
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }

        /// public propaty name  :  UpRate
        /// <summary>UP率プロパティ</summary>
        /// <value>価格UP率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UP率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double UpRate
        {
            get { return _upRate; }
            set { _upRate = value; }
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
        /// 離島価格マスタコンストラクタ
        /// </summary>
        /// <returns>IsolIslandPrcクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IsolIslandPrcクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public IsolIslandPrc()
        {
        }

        /// <summary>
        /// 離島価格マスタコンストラクタ
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
        /// <param name="makerCode">メーカーコード(1～899:提供分, 900～ユーザー登録)</param>
        /// <param name="upperLimitPrice">上限金額(金額の場合は整数のみ設定)</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分(1：切捨て,2：四捨五入,3:切上げ)</param>
        /// <param name="upRate">UP率(価格UP率)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>IsolIslandPrcクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IsolIslandPrcクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public IsolIslandPrc(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 makerCode, Double upperLimitPrice, Double fractionProcUnit, Int32 fractionProcCd, Double upRate, string enterpriseName, string updEmployeeName)
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
            this._makerCode = makerCode;
            this._upperLimitPrice = upperLimitPrice;
            this._fractionProcUnit = fractionProcUnit;
            this._fractionProcCd = fractionProcCd;
            this._upRate = upRate;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// 離島価格マスタ複製処理
        /// </summary>
        /// <returns>IsolIslandPrcクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいIsolIslandPrcクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public IsolIslandPrc Clone()
        {
            return new IsolIslandPrc(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._makerCode, this._upperLimitPrice, this._fractionProcUnit, this._fractionProcCd, this._upRate, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// 離島価格マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のIsolIslandPrcクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IsolIslandPrcクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(IsolIslandPrc target)
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
                 && (this.MakerCode == target.MakerCode)
                 && (this.UpperLimitPrice == target.UpperLimitPrice)
                 && (this.FractionProcUnit == target.FractionProcUnit)
                 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.UpRate == target.UpRate)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 離島価格マスタ比較処理
        /// </summary>
        /// <param name="isolIslandPrc1">
        ///                    比較するIsolIslandPrcクラスのインスタンス
        /// </param>
        /// <param name="isolIslandPrc2">比較するIsolIslandPrcクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IsolIslandPrcクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(IsolIslandPrc isolIslandPrc1, IsolIslandPrc isolIslandPrc2)
        {
            return ((isolIslandPrc1.CreateDateTime == isolIslandPrc2.CreateDateTime)
                 && (isolIslandPrc1.UpdateDateTime == isolIslandPrc2.UpdateDateTime)
                 && (isolIslandPrc1.EnterpriseCode == isolIslandPrc2.EnterpriseCode)
                 && (isolIslandPrc1.FileHeaderGuid == isolIslandPrc2.FileHeaderGuid)
                 && (isolIslandPrc1.UpdEmployeeCode == isolIslandPrc2.UpdEmployeeCode)
                 && (isolIslandPrc1.UpdAssemblyId1 == isolIslandPrc2.UpdAssemblyId1)
                 && (isolIslandPrc1.UpdAssemblyId2 == isolIslandPrc2.UpdAssemblyId2)
                 && (isolIslandPrc1.LogicalDeleteCode == isolIslandPrc2.LogicalDeleteCode)
                 && (isolIslandPrc1.SectionCode == isolIslandPrc2.SectionCode)
                 && (isolIslandPrc1.MakerCode == isolIslandPrc2.MakerCode)
                 && (isolIslandPrc1.UpperLimitPrice == isolIslandPrc2.UpperLimitPrice)
                 && (isolIslandPrc1.FractionProcUnit == isolIslandPrc2.FractionProcUnit)
                 && (isolIslandPrc1.FractionProcCd == isolIslandPrc2.FractionProcCd)
                 && (isolIslandPrc1.UpRate == isolIslandPrc2.UpRate)
                 && (isolIslandPrc1.EnterpriseName == isolIslandPrc2.EnterpriseName)
                 && (isolIslandPrc1.UpdEmployeeName == isolIslandPrc2.UpdEmployeeName));
        }
        /// <summary>
        /// 離島価格マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のIsolIslandPrcクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IsolIslandPrcクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(IsolIslandPrc target)
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
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.UpperLimitPrice != target.UpperLimitPrice) resList.Add("UpperLimitPrice");
            if (this.FractionProcUnit != target.FractionProcUnit) resList.Add("FractionProcUnit");
            if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
            if (this.UpRate != target.UpRate) resList.Add("UpRate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// 離島価格マスタ比較処理
        /// </summary>
        /// <param name="isolIslandPrc1">比較するIsolIslandPrcクラスのインスタンス</param>
        /// <param name="isolIslandPrc2">比較するIsolIslandPrcクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IsolIslandPrcクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(IsolIslandPrc isolIslandPrc1, IsolIslandPrc isolIslandPrc2)
        {
            ArrayList resList = new ArrayList();
            if (isolIslandPrc1.CreateDateTime != isolIslandPrc2.CreateDateTime) resList.Add("CreateDateTime");
            if (isolIslandPrc1.UpdateDateTime != isolIslandPrc2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (isolIslandPrc1.EnterpriseCode != isolIslandPrc2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (isolIslandPrc1.FileHeaderGuid != isolIslandPrc2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (isolIslandPrc1.UpdEmployeeCode != isolIslandPrc2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (isolIslandPrc1.UpdAssemblyId1 != isolIslandPrc2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (isolIslandPrc1.UpdAssemblyId2 != isolIslandPrc2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (isolIslandPrc1.LogicalDeleteCode != isolIslandPrc2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (isolIslandPrc1.SectionCode != isolIslandPrc2.SectionCode) resList.Add("SectionCode");
            if (isolIslandPrc1.MakerCode != isolIslandPrc2.MakerCode) resList.Add("MakerCode");
            if (isolIslandPrc1.UpperLimitPrice != isolIslandPrc2.UpperLimitPrice) resList.Add("UpperLimitPrice");
            if (isolIslandPrc1.FractionProcUnit != isolIslandPrc2.FractionProcUnit) resList.Add("FractionProcUnit");
            if (isolIslandPrc1.FractionProcCd != isolIslandPrc2.FractionProcCd) resList.Add("FractionProcCd");
            if (isolIslandPrc1.UpRate != isolIslandPrc2.UpRate) resList.Add("UpRate");
            if (isolIslandPrc1.EnterpriseName != isolIslandPrc2.EnterpriseName) resList.Add("EnterpriseName");
            if (isolIslandPrc1.UpdEmployeeName != isolIslandPrc2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
