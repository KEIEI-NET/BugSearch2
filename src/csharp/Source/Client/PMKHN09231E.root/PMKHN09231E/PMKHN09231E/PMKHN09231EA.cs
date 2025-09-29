using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   BLCodeGuide
    /// <summary>
    ///                      BLコードガイドマスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   BLコードガイドマスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/6/24</br>
    /// <br>Genarated Date   :   2008/09/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/9/3  長内</br>
    /// <br>                 :   ○項目追加＆キー変更</br>
    /// <br>                 :   　拠点コード</br>
    /// </remarks>
    public class BLCodeGuide
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

        /// <summary>BLコード表示頁</summary>
        /// <remarks>1～5</remarks>
        private Int32 _bLCodeDspPage;

        /// <summary>BLコード表示行</summary>
        /// <remarks>1～18</remarks>
        private Int32 _bLCodeDspRow;

        /// <summary>BLコード表示列</summary>
        /// <remarks>1～3</remarks>
        private Int32 _bLCodeDspCol;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称</summary>
        /// <remarks>手入力用</remarks>
        private string _bLGoodsName = "";

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

        /// public propaty name  :  BLCodeDspPage
        /// <summary>BLコード表示頁プロパティ</summary>
        /// <value>1～5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード表示頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLCodeDspPage
        {
            get { return _bLCodeDspPage; }
            set { _bLCodeDspPage = value; }
        }

        /// public propaty name  :  BLCodeDspRow
        /// <summary>BLコード表示行プロパティ</summary>
        /// <value>1～18</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード表示行プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLCodeDspRow
        {
            get { return _bLCodeDspRow; }
            set { _bLCodeDspRow = value; }
        }

        /// public propaty name  :  BLCodeDspCol
        /// <summary>BLコード表示列プロパティ</summary>
        /// <value>1～3</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード表示列プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLCodeDspCol
        {
            get { return _bLCodeDspCol; }
            set { _bLCodeDspCol = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsName
        /// <summary>BL商品コード名称プロパティ</summary>
        /// <value>手入力用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
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
        /// BLコードガイドマスタコンストラクタ
        /// </summary>
        /// <returns>BLCodeGuideクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLCodeGuideクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BLCodeGuide()
        {
        }

        /// <summary>
        /// BLコードガイドマスタコンストラクタ
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
        /// <param name="bLCodeDspPage">BLコード表示頁(1～5)</param>
        /// <param name="bLCodeDspRow">BLコード表示行(1～18)</param>
        /// <param name="bLCodeDspCol">BLコード表示列(1～3)</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="bLGoodsName">BL商品コード名称(手入力用)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>BLCodeGuideクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLCodeGuideクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BLCodeGuide(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 bLCodeDspPage, Int32 bLCodeDspRow, Int32 bLCodeDspCol, Int32 bLGoodsCode, string bLGoodsName, string enterpriseName, string updEmployeeName)
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
            this._bLCodeDspPage = bLCodeDspPage;
            this._bLCodeDspRow = bLCodeDspRow;
            this._bLCodeDspCol = bLCodeDspCol;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsName = bLGoodsName;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// BLコードガイドマスタ複製処理
        /// </summary>
        /// <returns>BLCodeGuideクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいBLCodeGuideクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BLCodeGuide Clone()
        {
            return new BLCodeGuide(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._bLCodeDspPage, this._bLCodeDspRow, this._bLCodeDspCol, this._bLGoodsCode, this._bLGoodsName, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// BLコードガイドマスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のBLCodeGuideクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLCodeGuideクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(BLCodeGuide target)
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
                 && (this.BLCodeDspPage == target.BLCodeDspPage)
                 && (this.BLCodeDspRow == target.BLCodeDspRow)
                 && (this.BLCodeDspCol == target.BLCodeDspCol)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// BLコードガイドマスタ比較処理
        /// </summary>
        /// <param name="bLCodeGuide1">
        ///                    比較するBLCodeGuideクラスのインスタンス
        /// </param>
        /// <param name="bLCodeGuide2">比較するBLCodeGuideクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLCodeGuideクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(BLCodeGuide bLCodeGuide1, BLCodeGuide bLCodeGuide2)
        {
            return ((bLCodeGuide1.CreateDateTime == bLCodeGuide2.CreateDateTime)
                 && (bLCodeGuide1.UpdateDateTime == bLCodeGuide2.UpdateDateTime)
                 && (bLCodeGuide1.EnterpriseCode == bLCodeGuide2.EnterpriseCode)
                 && (bLCodeGuide1.FileHeaderGuid == bLCodeGuide2.FileHeaderGuid)
                 && (bLCodeGuide1.UpdEmployeeCode == bLCodeGuide2.UpdEmployeeCode)
                 && (bLCodeGuide1.UpdAssemblyId1 == bLCodeGuide2.UpdAssemblyId1)
                 && (bLCodeGuide1.UpdAssemblyId2 == bLCodeGuide2.UpdAssemblyId2)
                 && (bLCodeGuide1.LogicalDeleteCode == bLCodeGuide2.LogicalDeleteCode)
                 && (bLCodeGuide1.SectionCode == bLCodeGuide2.SectionCode)
                 && (bLCodeGuide1.BLCodeDspPage == bLCodeGuide2.BLCodeDspPage)
                 && (bLCodeGuide1.BLCodeDspRow == bLCodeGuide2.BLCodeDspRow)
                 && (bLCodeGuide1.BLCodeDspCol == bLCodeGuide2.BLCodeDspCol)
                 && (bLCodeGuide1.BLGoodsCode == bLCodeGuide2.BLGoodsCode)
                 && (bLCodeGuide1.BLGoodsName == bLCodeGuide2.BLGoodsName)
                 && (bLCodeGuide1.EnterpriseName == bLCodeGuide2.EnterpriseName)
                 && (bLCodeGuide1.UpdEmployeeName == bLCodeGuide2.UpdEmployeeName));
        }
        /// <summary>
        /// BLコードガイドマスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のBLCodeGuideクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLCodeGuideクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(BLCodeGuide target)
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
            if (this.BLCodeDspPage != target.BLCodeDspPage) resList.Add("BLCodeDspPage");
            if (this.BLCodeDspRow != target.BLCodeDspRow) resList.Add("BLCodeDspRow");
            if (this.BLCodeDspCol != target.BLCodeDspCol) resList.Add("BLCodeDspCol");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// BLコードガイドマスタ比較処理
        /// </summary>
        /// <param name="bLCodeGuide1">比較するBLCodeGuideクラスのインスタンス</param>
        /// <param name="bLCodeGuide2">比較するBLCodeGuideクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLCodeGuideクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(BLCodeGuide bLCodeGuide1, BLCodeGuide bLCodeGuide2)
        {
            ArrayList resList = new ArrayList();
            if (bLCodeGuide1.CreateDateTime != bLCodeGuide2.CreateDateTime) resList.Add("CreateDateTime");
            if (bLCodeGuide1.UpdateDateTime != bLCodeGuide2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (bLCodeGuide1.EnterpriseCode != bLCodeGuide2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (bLCodeGuide1.FileHeaderGuid != bLCodeGuide2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (bLCodeGuide1.UpdEmployeeCode != bLCodeGuide2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (bLCodeGuide1.UpdAssemblyId1 != bLCodeGuide2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (bLCodeGuide1.UpdAssemblyId2 != bLCodeGuide2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (bLCodeGuide1.LogicalDeleteCode != bLCodeGuide2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (bLCodeGuide1.SectionCode != bLCodeGuide2.SectionCode) resList.Add("SectionCode");
            if (bLCodeGuide1.BLCodeDspPage != bLCodeGuide2.BLCodeDspPage) resList.Add("BLCodeDspPage");
            if (bLCodeGuide1.BLCodeDspRow != bLCodeGuide2.BLCodeDspRow) resList.Add("BLCodeDspRow");
            if (bLCodeGuide1.BLCodeDspCol != bLCodeGuide2.BLCodeDspCol) resList.Add("BLCodeDspCol");
            if (bLCodeGuide1.BLGoodsCode != bLCodeGuide2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (bLCodeGuide1.BLGoodsName != bLCodeGuide2.BLGoodsName) resList.Add("BLGoodsName");
            if (bLCodeGuide1.EnterpriseName != bLCodeGuide2.EnterpriseName) resList.Add("EnterpriseName");
            if (bLCodeGuide1.UpdEmployeeName != bLCodeGuide2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
