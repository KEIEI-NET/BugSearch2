using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   BLGoodsCdChgU
    /// <summary>
    ///                      BLコード変換マスタ（ユーザー登録）
    /// </summary>
    /// <remarks>
    /// <br>note             :   BLコード変換マスタ（ユーザー登録）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2012/7/25</br>
    /// <br>Genarated Date   :   2012/07/31  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class BLGoodsCdChgU
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

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>PM側BL商品コード</summary>
        private Int32 _pMBLGoodsCode;

        /// <summary>PM側BL商品コード枝番</summary>
        private Int32 _pMBLGoodsCodeDerivNo;

        /// <summary>SF側BL商品コード</summary>
        private Int32 _sFBLGoodsCode;

        /// <summary>SF側BL商品コード枝番</summary>
        private Int32 _sFBLGoodsCodeDerivNo;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";

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

        /// public propaty name  :  CustomerCode
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

        /// public propaty name  :  PMBLGoodsCode
        /// <summary>PM側BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM側BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PMBLGoodsCode
        {
            get { return _pMBLGoodsCode; }
            set { _pMBLGoodsCode = value; }
        }

        /// public propaty name  :  PMBLGoodsCodeDerivNo
        /// <summary>PM側BL商品コード枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM側BL商品コード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PMBLGoodsCodeDerivNo
        {
            get { return _pMBLGoodsCodeDerivNo; }
            set { _pMBLGoodsCodeDerivNo = value; }
        }

        /// public propaty name  :  SFBLGoodsCode
        /// <summary>SF側BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SF側BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SFBLGoodsCode
        {
            get { return _sFBLGoodsCode; }
            set { _sFBLGoodsCode = value; }
        }

        /// public propaty name  :  SFBLGoodsCodeDerivNo
        /// <summary>SF側BL商品コード枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SF側BL商品コード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SFBLGoodsCodeDerivNo
        {
            get { return _sFBLGoodsCodeDerivNo; }
            set { _sFBLGoodsCodeDerivNo = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL商品コード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
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
        /// BLコード変換マスタ（ユーザー登録）コンストラクタ
        /// </summary>
        /// <returns>BLGoodsCdChgUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLGoodsCdChgUクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BLGoodsCdChgU()
        {
        }

        /// <summary>
        /// BLコード変換マスタ（ユーザー登録）コンストラクタ
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
        /// <param name="customerCode">得意先コード</param>
        /// <param name="pMBLGoodsCode">PM側BL商品コード</param>
        /// <param name="pMBLGoodsCodeDerivNo">PM側BL商品コード枝番</param>
        /// <param name="sFBLGoodsCode">SF側BL商品コード</param>
        /// <param name="sFBLGoodsCodeDerivNo">SF側BL商品コード枝番</param>
        /// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
        /// <param name="bLGoodsHalfName">BL商品コード名称（半角）</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>BLGoodsCdChgUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLGoodsCdChgUクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BLGoodsCdChgU(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 customerCode, Int32 pMBLGoodsCode, Int32 pMBLGoodsCodeDerivNo, Int32 sFBLGoodsCode, Int32 sFBLGoodsCodeDerivNo, string bLGoodsFullName, string bLGoodsHalfName, string enterpriseName, string updEmployeeName)
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
            this._pMBLGoodsCode = pMBLGoodsCode;
            this._pMBLGoodsCodeDerivNo = pMBLGoodsCodeDerivNo;
            this._sFBLGoodsCode = sFBLGoodsCode;
            this._sFBLGoodsCodeDerivNo = sFBLGoodsCodeDerivNo;
            this._bLGoodsFullName = bLGoodsFullName;
            this._bLGoodsHalfName = bLGoodsHalfName;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// BLコード変換マスタ（ユーザー登録）複製処理
        /// </summary>
        /// <returns>BLGoodsCdChgUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいBLGoodsCdChgUクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BLGoodsCdChgU Clone()
        {
            return new BLGoodsCdChgU(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._customerCode, this._pMBLGoodsCode, this._pMBLGoodsCodeDerivNo, this._sFBLGoodsCode, this._sFBLGoodsCodeDerivNo, this._bLGoodsFullName, this._bLGoodsHalfName, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// BLコード変換マスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="target">比較対象のBLGoodsCdChgUクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLGoodsCdChgUクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(BLGoodsCdChgU target)
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
                 && (this.PMBLGoodsCode == target.PMBLGoodsCode)
                 && (this.PMBLGoodsCodeDerivNo == target.PMBLGoodsCodeDerivNo)
                 && (this.SFBLGoodsCode == target.SFBLGoodsCode)
                 && (this.SFBLGoodsCodeDerivNo == target.SFBLGoodsCodeDerivNo)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.BLGoodsHalfName == target.BLGoodsHalfName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// BLコード変換マスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="bLGoodsCdChgU1">
        ///                    比較するBLGoodsCdChgUクラスのインスタンス
        /// </param>
        /// <param name="bLGoodsCdChgU2">比較するBLGoodsCdChgUクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLGoodsCdChgUクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(BLGoodsCdChgU bLGoodsCdChgU1, BLGoodsCdChgU bLGoodsCdChgU2)
        {
            return ((bLGoodsCdChgU1.CreateDateTime == bLGoodsCdChgU2.CreateDateTime)
                 && (bLGoodsCdChgU1.UpdateDateTime == bLGoodsCdChgU2.UpdateDateTime)
                 && (bLGoodsCdChgU1.EnterpriseCode == bLGoodsCdChgU2.EnterpriseCode)
                 && (bLGoodsCdChgU1.FileHeaderGuid == bLGoodsCdChgU2.FileHeaderGuid)
                 && (bLGoodsCdChgU1.UpdEmployeeCode == bLGoodsCdChgU2.UpdEmployeeCode)
                 && (bLGoodsCdChgU1.UpdAssemblyId1 == bLGoodsCdChgU2.UpdAssemblyId1)
                 && (bLGoodsCdChgU1.UpdAssemblyId2 == bLGoodsCdChgU2.UpdAssemblyId2)
                 && (bLGoodsCdChgU1.LogicalDeleteCode == bLGoodsCdChgU2.LogicalDeleteCode)
                 && (bLGoodsCdChgU1.SectionCode == bLGoodsCdChgU2.SectionCode)
                 && (bLGoodsCdChgU1.CustomerCode == bLGoodsCdChgU2.CustomerCode)
                 && (bLGoodsCdChgU1.PMBLGoodsCode == bLGoodsCdChgU2.PMBLGoodsCode)
                 && (bLGoodsCdChgU1.PMBLGoodsCodeDerivNo == bLGoodsCdChgU2.PMBLGoodsCodeDerivNo)
                 && (bLGoodsCdChgU1.SFBLGoodsCode == bLGoodsCdChgU2.SFBLGoodsCode)
                 && (bLGoodsCdChgU1.SFBLGoodsCodeDerivNo == bLGoodsCdChgU2.SFBLGoodsCodeDerivNo)
                 && (bLGoodsCdChgU1.BLGoodsFullName == bLGoodsCdChgU2.BLGoodsFullName)
                 && (bLGoodsCdChgU1.BLGoodsHalfName == bLGoodsCdChgU2.BLGoodsHalfName)
                 && (bLGoodsCdChgU1.EnterpriseName == bLGoodsCdChgU2.EnterpriseName)
                 && (bLGoodsCdChgU1.UpdEmployeeName == bLGoodsCdChgU2.UpdEmployeeName));
        }
        /// <summary>
        /// BLコード変換マスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="target">比較対象のBLGoodsCdChgUクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLGoodsCdChgUクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(BLGoodsCdChgU target)
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
            if (this.PMBLGoodsCode != target.PMBLGoodsCode) resList.Add("PMBLGoodsCode");
            if (this.PMBLGoodsCodeDerivNo != target.PMBLGoodsCodeDerivNo) resList.Add("PMBLGoodsCodeDerivNo");
            if (this.SFBLGoodsCode != target.SFBLGoodsCode) resList.Add("SFBLGoodsCode");
            if (this.SFBLGoodsCodeDerivNo != target.SFBLGoodsCodeDerivNo) resList.Add("SFBLGoodsCodeDerivNo");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.BLGoodsHalfName != target.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// BLコード変換マスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="bLGoodsCdChgU1">比較するBLGoodsCdChgUクラスのインスタンス</param>
        /// <param name="bLGoodsCdChgU2">比較するBLGoodsCdChgUクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLGoodsCdChgUクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(BLGoodsCdChgU bLGoodsCdChgU1, BLGoodsCdChgU bLGoodsCdChgU2)
        {
            ArrayList resList = new ArrayList();
            if (bLGoodsCdChgU1.CreateDateTime != bLGoodsCdChgU2.CreateDateTime) resList.Add("CreateDateTime");
            if (bLGoodsCdChgU1.UpdateDateTime != bLGoodsCdChgU2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (bLGoodsCdChgU1.EnterpriseCode != bLGoodsCdChgU2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (bLGoodsCdChgU1.FileHeaderGuid != bLGoodsCdChgU2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (bLGoodsCdChgU1.UpdEmployeeCode != bLGoodsCdChgU2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (bLGoodsCdChgU1.UpdAssemblyId1 != bLGoodsCdChgU2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (bLGoodsCdChgU1.UpdAssemblyId2 != bLGoodsCdChgU2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (bLGoodsCdChgU1.LogicalDeleteCode != bLGoodsCdChgU2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (bLGoodsCdChgU1.SectionCode != bLGoodsCdChgU2.SectionCode) resList.Add("SectionCode");
            if (bLGoodsCdChgU1.CustomerCode != bLGoodsCdChgU2.CustomerCode) resList.Add("CustomerCode");
            if (bLGoodsCdChgU1.PMBLGoodsCode != bLGoodsCdChgU2.PMBLGoodsCode) resList.Add("PMBLGoodsCode");
            if (bLGoodsCdChgU1.PMBLGoodsCodeDerivNo != bLGoodsCdChgU2.PMBLGoodsCodeDerivNo) resList.Add("PMBLGoodsCodeDerivNo");
            if (bLGoodsCdChgU1.SFBLGoodsCode != bLGoodsCdChgU2.SFBLGoodsCode) resList.Add("SFBLGoodsCode");
            if (bLGoodsCdChgU1.SFBLGoodsCodeDerivNo != bLGoodsCdChgU2.SFBLGoodsCodeDerivNo) resList.Add("SFBLGoodsCodeDerivNo");
            if (bLGoodsCdChgU1.BLGoodsFullName != bLGoodsCdChgU2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (bLGoodsCdChgU1.BLGoodsHalfName != bLGoodsCdChgU2.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
            if (bLGoodsCdChgU1.EnterpriseName != bLGoodsCdChgU2.EnterpriseName) resList.Add("EnterpriseName");
            if (bLGoodsCdChgU1.UpdEmployeeName != bLGoodsCdChgU2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
