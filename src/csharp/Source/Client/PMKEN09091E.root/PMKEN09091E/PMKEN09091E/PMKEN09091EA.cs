using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PartsSubstU
    /// <summary>
    ///                      部品代替マスタ（ユーザー登録分）
    /// </summary>
    /// <remarks>
    /// <br>note             :   部品代替マスタ（ユーザー登録分）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2008/07/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/10  杉村</br>
    /// <br>                 :   項目追加</br>
    /// <br>                 :   適用終了日（誤削除の復旧）</br>
    /// </remarks>
    public class PartsSubstU
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

        /// <summary>変換元メーカーコード</summary>
        private Int32 _chgSrcMakerCd;

        /// <summary>変換元商品番号</summary>
        private string _chgSrcGoodsNo = "";

        /// <summary>ハイフン無変換元商品番号</summary>
        private string _chgSrcGoodsNoNoneHp = "";

        /// <summary>変換先メーカーコード</summary>
        /// <remarks>商品マスタ商品メーカーコード</remarks>
        private Int32 _chgDestMakerCd;

        /// <summary>変換先商品番号</summary>
        /// <remarks>商品マスタ商品番号</remarks>
        private string _chgDestGoodsNo = "";

        /// <summary>ハイフン無変換先商品番号</summary>
        /// <remarks>変換後ハイフン無商品番号</remarks>
        private string _chgDestGoodsNoNoneHp = "";

        /// <summary>適用開始日</summary>
        private DateTime _applyStaDate;

        /// <summary>適用終了日</summary>
        private DateTime _applyEndDate;

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

        /// public propaty name  :  ChgSrcMakerCd
        /// <summary>変換元メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換元メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChgSrcMakerCd
        {
            get { return _chgSrcMakerCd; }
            set { _chgSrcMakerCd = value; }
        }

        /// public propaty name  :  ChgSrcGoodsNo
        /// <summary>変換元商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換元商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgSrcGoodsNo
        {
            get { return _chgSrcGoodsNo; }
            set { _chgSrcGoodsNo = value; }
        }

        /// public propaty name  :  ChgSrcGoodsNoNoneHp
        /// <summary>ハイフン無変換元商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン無変換元商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgSrcGoodsNoNoneHp
        {
            get { return _chgSrcGoodsNoNoneHp; }
            set { _chgSrcGoodsNoNoneHp = value; }
        }

        /// public propaty name  :  ChgDestMakerCd
        /// <summary>変換先メーカーコードプロパティ</summary>
        /// <value>商品マスタ商品メーカーコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換先メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChgDestMakerCd
        {
            get { return _chgDestMakerCd; }
            set { _chgDestMakerCd = value; }
        }

        /// public propaty name  :  ChgDestGoodsNo
        /// <summary>変換先商品番号プロパティ</summary>
        /// <value>商品マスタ商品番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換先商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgDestGoodsNo
        {
            get { return _chgDestGoodsNo; }
            set { _chgDestGoodsNo = value; }
        }

        /// public propaty name  :  ChgDestGoodsNoNoneHp
        /// <summary>ハイフン無変換先商品番号プロパティ</summary>
        /// <value>変換後ハイフン無商品番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン無変換先商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgDestGoodsNoNoneHp
        {
            get { return _chgDestGoodsNoNoneHp; }
            set { _chgDestGoodsNoNoneHp = value; }
        }

        /// public propaty name  :  ApplyStaDate
        /// <summary>適用開始日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyStaDateJpFormal
        /// <summary>適用開始日 和暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ApplyStaDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _applyStaDate); }
            set { }
        }

        /// public propaty name  :  ApplyStaDateJpInFormal
        /// <summary>適用開始日 和暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ApplyStaDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _applyStaDate); }
            set { }
        }

        /// public propaty name  :  ApplyStaDateAdFormal
        /// <summary>適用開始日 西暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ApplyStaDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _applyStaDate); }
            set { }
        }

        /// public propaty name  :  ApplyStaDateAdInFormal
        /// <summary>適用開始日 西暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ApplyStaDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _applyStaDate); }
            set { }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>適用終了日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
        }

        /// public propaty name  :  ApplyEndDateJpFormal
        /// <summary>適用終了日 和暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ApplyEndDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _applyEndDate); }
            set { }
        }

        /// public propaty name  :  ApplyEndDateJpInFormal
        /// <summary>適用終了日 和暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ApplyEndDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _applyEndDate); }
            set { }
        }

        /// public propaty name  :  ApplyEndDateAdFormal
        /// <summary>適用終了日 西暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ApplyEndDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _applyEndDate); }
            set { }
        }

        /// public propaty name  :  ApplyEndDateAdInFormal
        /// <summary>適用終了日 西暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ApplyEndDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _applyEndDate); }
            set { }
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
        /// 部品代替マスタ（ユーザー登録分）コンストラクタ
        /// </summary>
        /// <returns>PartsSubstUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstUクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsSubstU()
        {
        }

        /// <summary>
        /// 部品代替マスタ（ユーザー登録分）コンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="chgSrcMakerCd">変換元メーカーコード</param>
        /// <param name="chgSrcGoodsNo">変換元商品番号</param>
        /// <param name="chgSrcGoodsNoNoneHp">ハイフン無変換元商品番号</param>
        /// <param name="chgDestMakerCd">変換先メーカーコード(商品マスタ商品メーカーコード)</param>
        /// <param name="chgDestGoodsNo">変換先商品番号(商品マスタ商品番号)</param>
        /// <param name="chgDestGoodsNoNoneHp">ハイフン無変換先商品番号(変換後ハイフン無商品番号)</param>
        /// <param name="applyStaDate">適用開始日</param>
        /// <param name="applyEndDate">適用終了日</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>PartsSubstUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstUクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsSubstU(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 chgSrcMakerCd, string chgSrcGoodsNo, string chgSrcGoodsNoNoneHp, Int32 chgDestMakerCd, string chgDestGoodsNo, string chgDestGoodsNoNoneHp, DateTime applyStaDate, DateTime applyEndDate, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._chgSrcMakerCd = chgSrcMakerCd;
            this._chgSrcGoodsNo = chgSrcGoodsNo;
            this._chgSrcGoodsNoNoneHp = chgSrcGoodsNoNoneHp;
            this._chgDestMakerCd = chgDestMakerCd;
            this._chgDestGoodsNo = chgDestGoodsNo;
            this._chgDestGoodsNoNoneHp = chgDestGoodsNoNoneHp;
            this.ApplyStaDate = applyStaDate;
            this.ApplyEndDate = applyEndDate;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// 部品代替マスタ（ユーザー登録分）複製処理
        /// </summary>
        /// <returns>PartsSubstUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPartsSubstUクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsSubstU Clone()
        {
            return new PartsSubstU(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._chgSrcMakerCd, this._chgSrcGoodsNo, this._chgSrcGoodsNoNoneHp, this._chgDestMakerCd, this._chgDestGoodsNo, this._chgDestGoodsNoNoneHp, this._applyStaDate, this._applyEndDate, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// 部品代替マスタ（ユーザー登録分）比較処理
        /// </summary>
        /// <param name="target">比較対象のPartsSubstUクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstUクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PartsSubstU target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.ChgSrcMakerCd == target.ChgSrcMakerCd)
                 && (this.ChgSrcGoodsNo == target.ChgSrcGoodsNo)
                 && (this.ChgSrcGoodsNoNoneHp == target.ChgSrcGoodsNoNoneHp)
                 && (this.ChgDestMakerCd == target.ChgDestMakerCd)
                 && (this.ChgDestGoodsNo == target.ChgDestGoodsNo)
                 && (this.ChgDestGoodsNoNoneHp == target.ChgDestGoodsNoNoneHp)
                 && (this.ApplyStaDate == target.ApplyStaDate)
                 && (this.ApplyEndDate == target.ApplyEndDate)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 部品代替マスタ（ユーザー登録分）比較処理
        /// </summary>
        /// <param name="partsSubstU1">
        ///                    比較するPartsSubstUクラスのインスタンス
        /// </param>
        /// <param name="partsSubstU2">比較するPartsSubstUクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstUクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PartsSubstU partsSubstU1, PartsSubstU partsSubstU2)
        {
            return ((partsSubstU1.CreateDateTime == partsSubstU2.CreateDateTime)
                 && (partsSubstU1.UpdateDateTime == partsSubstU2.UpdateDateTime)
                 && (partsSubstU1.EnterpriseCode == partsSubstU2.EnterpriseCode)
                 && (partsSubstU1.FileHeaderGuid == partsSubstU2.FileHeaderGuid)
                 && (partsSubstU1.UpdEmployeeCode == partsSubstU2.UpdEmployeeCode)
                 && (partsSubstU1.UpdAssemblyId1 == partsSubstU2.UpdAssemblyId1)
                 && (partsSubstU1.UpdAssemblyId2 == partsSubstU2.UpdAssemblyId2)
                 && (partsSubstU1.LogicalDeleteCode == partsSubstU2.LogicalDeleteCode)
                 && (partsSubstU1.ChgSrcMakerCd == partsSubstU2.ChgSrcMakerCd)
                 && (partsSubstU1.ChgSrcGoodsNo == partsSubstU2.ChgSrcGoodsNo)
                 && (partsSubstU1.ChgSrcGoodsNoNoneHp == partsSubstU2.ChgSrcGoodsNoNoneHp)
                 && (partsSubstU1.ChgDestMakerCd == partsSubstU2.ChgDestMakerCd)
                 && (partsSubstU1.ChgDestGoodsNo == partsSubstU2.ChgDestGoodsNo)
                 && (partsSubstU1.ChgDestGoodsNoNoneHp == partsSubstU2.ChgDestGoodsNoNoneHp)
                 && (partsSubstU1.ApplyStaDate == partsSubstU2.ApplyStaDate)
                 && (partsSubstU1.ApplyEndDate == partsSubstU2.ApplyEndDate)
                 && (partsSubstU1.EnterpriseName == partsSubstU2.EnterpriseName)
                 && (partsSubstU1.UpdEmployeeName == partsSubstU2.UpdEmployeeName));
        }
        /// <summary>
        /// 部品代替マスタ（ユーザー登録分）比較処理
        /// </summary>
        /// <param name="target">比較対象のPartsSubstUクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstUクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PartsSubstU target)
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
            if (this.ChgSrcMakerCd != target.ChgSrcMakerCd) resList.Add("ChgSrcMakerCd");
            if (this.ChgSrcGoodsNo != target.ChgSrcGoodsNo) resList.Add("ChgSrcGoodsNo");
            if (this.ChgSrcGoodsNoNoneHp != target.ChgSrcGoodsNoNoneHp) resList.Add("ChgSrcGoodsNoNoneHp");
            if (this.ChgDestMakerCd != target.ChgDestMakerCd) resList.Add("ChgDestMakerCd");
            if (this.ChgDestGoodsNo != target.ChgDestGoodsNo) resList.Add("ChgDestGoodsNo");
            if (this.ChgDestGoodsNoNoneHp != target.ChgDestGoodsNoNoneHp) resList.Add("ChgDestGoodsNoNoneHp");
            if (this.ApplyStaDate != target.ApplyStaDate) resList.Add("ApplyStaDate");
            if (this.ApplyEndDate != target.ApplyEndDate) resList.Add("ApplyEndDate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// 部品代替マスタ（ユーザー登録分）比較処理
        /// </summary>
        /// <param name="partsSubstU1">比較するPartsSubstUクラスのインスタンス</param>
        /// <param name="partsSubstU2">比較するPartsSubstUクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstUクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PartsSubstU partsSubstU1, PartsSubstU partsSubstU2)
        {
            ArrayList resList = new ArrayList();
            if (partsSubstU1.CreateDateTime != partsSubstU2.CreateDateTime) resList.Add("CreateDateTime");
            if (partsSubstU1.UpdateDateTime != partsSubstU2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (partsSubstU1.EnterpriseCode != partsSubstU2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (partsSubstU1.FileHeaderGuid != partsSubstU2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (partsSubstU1.UpdEmployeeCode != partsSubstU2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (partsSubstU1.UpdAssemblyId1 != partsSubstU2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (partsSubstU1.UpdAssemblyId2 != partsSubstU2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (partsSubstU1.LogicalDeleteCode != partsSubstU2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (partsSubstU1.ChgSrcMakerCd != partsSubstU2.ChgSrcMakerCd) resList.Add("ChgSrcMakerCd");
            if (partsSubstU1.ChgSrcGoodsNo != partsSubstU2.ChgSrcGoodsNo) resList.Add("ChgSrcGoodsNo");
            if (partsSubstU1.ChgSrcGoodsNoNoneHp != partsSubstU2.ChgSrcGoodsNoNoneHp) resList.Add("ChgSrcGoodsNoNoneHp");
            if (partsSubstU1.ChgDestMakerCd != partsSubstU2.ChgDestMakerCd) resList.Add("ChgDestMakerCd");
            if (partsSubstU1.ChgDestGoodsNo != partsSubstU2.ChgDestGoodsNo) resList.Add("ChgDestGoodsNo");
            if (partsSubstU1.ChgDestGoodsNoNoneHp != partsSubstU2.ChgDestGoodsNoNoneHp) resList.Add("ChgDestGoodsNoNoneHp");
            if (partsSubstU1.ApplyStaDate != partsSubstU2.ApplyStaDate) resList.Add("ApplyStaDate");
            if (partsSubstU1.ApplyEndDate != partsSubstU2.ApplyEndDate) resList.Add("ApplyEndDate");
            if (partsSubstU1.EnterpriseName != partsSubstU2.EnterpriseName) resList.Add("EnterpriseName");
            if (partsSubstU1.UpdEmployeeName != partsSubstU2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
