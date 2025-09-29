//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 重点品目設定マスタ
// プログラム概要   : 重点品目設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ImportantPrtSt
    /// <summary>
    ///                      重点品目設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   重点品目設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    2009/4/13</br>
    /// <br>Genarated Date   :   2009/05/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :    2009/5/11  杉村</br>
    /// <br>                 :   ○項目削除</br>
    /// <br>                 :   仕入先コード</br>
    /// <br>                 :   BLグループコード</br>
    /// </remarks>
    public class ImportantPrtSt
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
        /// <remarks>0は全得意先</remarks>
        private Int32 _customerCode;

        /// <summary>商品中分類コード</summary>
        private Int32 _goodsMGroup;

        /// <summary>BLグループコード</summary>
        private Int32 _bLGroupCode;
        
        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>有効区分</summary>
        /// <remarks>0:有効,1:無効</remarks>
        private Int32 _validDivCd;

        /// <summary>拠点名称</summary>
        private string _sectionNm = "";

        /// <summary>得意先名称</summary>
        private string _customerName = "";

        /// <summary>商品中分類名称</summary>
        private string _goodsMGroupName = "";

        /// <summary>BLグループコード名称</summary>
        private string _bLGroupName = "";

        /// <summary>BL商品コード名称</summary>
        private string _bLGoodsName = "";

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

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
        /// <value>0は全得意先</value>
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

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  ValidDivCd
        /// <summary>有効区分プロパティ</summary>
        /// <value>0:有効,1:無効</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ValidDivCd
        {
            get { return _validDivCd; }
            set { _validDivCd = value; }
        }

        /// public propaty name  :  SectionNm
        /// <summary>拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionNm
        {
            get { return _sectionNm; }
            set { _sectionNm = value; }
        }

        /// public propaty name  :  CustomerName
        /// <summary>得意先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>商品中分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
        }

        /// public propaty name  :  BLGroupName
        /// <summary>BLグループコード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { _bLGroupName = value; }
        }

        /// public propaty name  :  BLGoodsName
        /// <summary>BL商品コード名称プロパティ</summary>
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

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
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
        /// 重点品目設定マスタコンストラクタ
        /// </summary>
        /// <returns>ImportantPrtStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ImportantPrtStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ImportantPrtSt()
        {
        }

        /// <summary>
        /// 重点品目設定マスタコンストラクタ
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
        /// <param name="customerCode">得意先コード(0は全得意先)</param>
        /// <param name="goodsMGroup">商品中分類コード</param>
        /// <param name="bLGroupCode">BLグループコード</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="validDivCd">有効区分(0:有効,1:無効)</param>
        /// <param name="sectionNm">拠点名称</param>
        /// <param name="customerName">得意先名称</param>
        /// <param name="goodsMGroupName">商品中分類名称</param>
        /// <param name="bLGroupName">BLグループコード名称</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierSnm">仕入先略称</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>ImportantPrtStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ImportantPrtStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ImportantPrtSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 customerCode, Int32 goodsMGroup, Int32 bLGroupCode, Int32 bLGoodsCode, Int32 goodsMakerCd, string goodsNo, Int32 validDivCd, string sectionNm, string customerName, string goodsMGroupName, string bLGroupName, string bLGoodsName, string makerName, string goodsName, Int32 supplierCd, string supplierSnm, string enterpriseName, string updEmployeeName)
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
            this._goodsMGroup = goodsMGroup;
            this._bLGroupCode = bLGroupCode;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._validDivCd = validDivCd;
            this._sectionNm = sectionNm;
            this._customerName = customerName;
            this._goodsMGroupName = goodsMGroupName;
            this._bLGroupName = bLGroupName;
            this._bLGoodsName = bLGoodsName;
            this._makerName = makerName;
            this._goodsName = goodsName;
            this._supplierCd = supplierCd;
            this._supplierSnm = supplierSnm;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            
        }

        /// <summary>
        /// 重点品目設定マスタ複製処理
        /// </summary>
        /// <returns>ImportantPrtStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいImportantPrtStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ImportantPrtSt Clone()
        {
            return new ImportantPrtSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._customerCode, this._goodsMGroup, this._bLGroupCode, this._bLGoodsCode, this._goodsMakerCd, this._goodsNo, this._validDivCd, this._sectionNm, this._customerName, this._goodsMGroupName, this._bLGroupName, this._bLGoodsName, this._makerName, this._goodsName, this._supplierCd, this._supplierSnm, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// 重点品目設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のImportantPrtStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ImportantPrtStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(ImportantPrtSt target)
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
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.ValidDivCd == target.ValidDivCd)
                 && (this.SectionNm == target.SectionNm)
                 && (this.CustomerName == target.CustomerName)
                 && (this.GoodsMGroupName == target.GoodsMGroupName)
                 && (this.BLGroupName == target.BLGroupName)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsName == target.GoodsName)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 重点品目設定マスタ比較処理
        /// </summary>
        /// <param name="importantPrtSt1">
        ///                    比較するImportantPrtStクラスのインスタンス
        /// </param>
        /// <param name="importantPrtSt2">比較するImportantPrtStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ImportantPrtStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(ImportantPrtSt importantPrtSt1, ImportantPrtSt importantPrtSt2)
        {
            return ((importantPrtSt1.CreateDateTime == importantPrtSt2.CreateDateTime)
                 && (importantPrtSt1.UpdateDateTime == importantPrtSt2.UpdateDateTime)
                 && (importantPrtSt1.EnterpriseCode == importantPrtSt2.EnterpriseCode)
                 && (importantPrtSt1.FileHeaderGuid == importantPrtSt2.FileHeaderGuid)
                 && (importantPrtSt1.UpdEmployeeCode == importantPrtSt2.UpdEmployeeCode)
                 && (importantPrtSt1.UpdAssemblyId1 == importantPrtSt2.UpdAssemblyId1)
                 && (importantPrtSt1.UpdAssemblyId2 == importantPrtSt2.UpdAssemblyId2)
                 && (importantPrtSt1.LogicalDeleteCode == importantPrtSt2.LogicalDeleteCode)
                 && (importantPrtSt1.SectionCode == importantPrtSt2.SectionCode)
                 && (importantPrtSt1.CustomerCode == importantPrtSt2.CustomerCode)
                 && (importantPrtSt1.GoodsMGroup == importantPrtSt2.GoodsMGroup)
                 && (importantPrtSt1.BLGroupCode == importantPrtSt2.BLGroupCode)
                 && (importantPrtSt1.BLGoodsCode == importantPrtSt2.BLGoodsCode)
                 && (importantPrtSt1.GoodsMakerCd == importantPrtSt2.GoodsMakerCd)
                 && (importantPrtSt1.GoodsNo == importantPrtSt2.GoodsNo)
                 && (importantPrtSt1.ValidDivCd == importantPrtSt2.ValidDivCd)
                 && (importantPrtSt1.SectionNm == importantPrtSt2.SectionNm)
                 && (importantPrtSt1.CustomerName == importantPrtSt2.CustomerName)
                 && (importantPrtSt1.GoodsMGroupName == importantPrtSt2.GoodsMGroupName)
                 && (importantPrtSt1.BLGroupName == importantPrtSt2.BLGroupName)
                 && (importantPrtSt1.BLGoodsName == importantPrtSt2.BLGoodsName)
                 && (importantPrtSt1.MakerName == importantPrtSt2.MakerName)
                 && (importantPrtSt1.GoodsName == importantPrtSt2.GoodsName)
                 && (importantPrtSt1.SupplierCd == importantPrtSt2.SupplierCd)
                 && (importantPrtSt1.SupplierSnm == importantPrtSt2.SupplierSnm)
                 && (importantPrtSt1.EnterpriseName == importantPrtSt2.EnterpriseName)
                 && (importantPrtSt1.UpdEmployeeName == importantPrtSt2.UpdEmployeeName));
        }
        /// <summary>
        /// 重点品目設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のImportantPrtStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ImportantPrtStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(ImportantPrtSt target)
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
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.ValidDivCd != target.ValidDivCd) resList.Add("ValidDivCd");
            if (this.SectionNm != target.SectionNm) resList.Add("SectionNm");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.GoodsMGroupName != target.GoodsMGroupName) resList.Add("GoodsMGroupName");
            if (this.BLGroupName != target.BLGroupName) resList.Add("BLGroupName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            
            return resList;
        }

        /// <summary>
        /// 重点品目設定マスタ比較処理
        /// </summary>
        /// <param name="importantPrtSt1">比較するImportantPrtStクラスのインスタンス</param>
        /// <param name="importantPrtSt2">比較するImportantPrtStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ImportantPrtStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(ImportantPrtSt importantPrtSt1, ImportantPrtSt importantPrtSt2)
        {
            ArrayList resList = new ArrayList();
            if (importantPrtSt1.CreateDateTime != importantPrtSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (importantPrtSt1.UpdateDateTime != importantPrtSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (importantPrtSt1.EnterpriseCode != importantPrtSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (importantPrtSt1.FileHeaderGuid != importantPrtSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (importantPrtSt1.UpdEmployeeCode != importantPrtSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (importantPrtSt1.UpdAssemblyId1 != importantPrtSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (importantPrtSt1.UpdAssemblyId2 != importantPrtSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (importantPrtSt1.LogicalDeleteCode != importantPrtSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (importantPrtSt1.SectionCode != importantPrtSt2.SectionCode) resList.Add("SectionCode");
            if (importantPrtSt1.CustomerCode != importantPrtSt2.CustomerCode) resList.Add("CustomerCode");
            if (importantPrtSt1.GoodsMGroup != importantPrtSt2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (importantPrtSt1.BLGroupCode != importantPrtSt2.BLGroupCode) resList.Add("BLGroupCode");
            if (importantPrtSt1.BLGoodsCode != importantPrtSt2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (importantPrtSt1.GoodsMakerCd != importantPrtSt2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (importantPrtSt1.GoodsNo != importantPrtSt2.GoodsNo) resList.Add("GoodsNo");
            if (importantPrtSt1.ValidDivCd != importantPrtSt2.ValidDivCd) resList.Add("ValidDivCd");
            if (importantPrtSt1.SectionNm != importantPrtSt2.SectionNm) resList.Add("SectionNm");
            if (importantPrtSt1.CustomerName != importantPrtSt2.CustomerName) resList.Add("CustomerName");
            if (importantPrtSt1.GoodsMGroupName != importantPrtSt2.GoodsMGroupName) resList.Add("GoodsMGroupName");
            if (importantPrtSt1.BLGroupName != importantPrtSt2.BLGroupName) resList.Add("BLGroupName");
            if (importantPrtSt1.BLGoodsName != importantPrtSt2.BLGoodsName) resList.Add("BLGoodsName");
            if (importantPrtSt1.MakerName != importantPrtSt2.MakerName) resList.Add("MakerName");
            if (importantPrtSt1.GoodsName != importantPrtSt2.GoodsName) resList.Add("GoodsName");
            if (importantPrtSt1.SupplierCd != importantPrtSt2.SupplierCd) resList.Add("SupplierCd");
            if (importantPrtSt1.SupplierSnm != importantPrtSt2.SupplierSnm) resList.Add("SupplierSnm");
            if (importantPrtSt1.EnterpriseName != importantPrtSt2.EnterpriseName) resList.Add("EnterpriseName");
            if (importantPrtSt1.UpdEmployeeName != importantPrtSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            
            return resList;
        }
    }
}
