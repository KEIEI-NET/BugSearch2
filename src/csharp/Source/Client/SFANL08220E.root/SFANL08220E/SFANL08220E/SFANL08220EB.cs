using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   FrePprGrTr
    /// <summary>
    ///                      自由帳票グループ振替マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票グループ振替マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2007/3/19</br>
    /// <br>Genarated Date   :   2007/03/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   22011 柏原　頼人</br>
    /// <br>                 :   2007.06.27 帳票ユーザー枝番コメントを追加</br>
    /// </remarks>
    public class FrePprGrTr
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

        /// <summary>自由帳票グループコード</summary>
        /// <remarks>0:全て,1～:ユーザー登録</remarks>
        private Int32 _freePrtPprGroupCd;

        /// <summary>振替コード</summary>
        private Int32 _transferCode;

        /// <summary>表示順位</summary>
        private Int32 _displayOrder;

        /// <summary>出力名称</summary>
        /// <remarks>ガイド等に表示する名称</remarks>
        private string _displayName = "";

        /// <summary>出力ファイル名</summary>
        /// <remarks>フォームファイルID or フォーマットファイルID</remarks>
        private string _outputFormFileName = "";

        /// <summary>ユーザー帳票ID枝番号</summary>
        private Int32 _userPrtPprIdDerivNo;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>自由帳票グループ名称</summary>
        private string _freePrtPprGroupNm = "";

        /// <summary>帳票ユーザー枝番コメント</summary>
        private string _prtPprUserDerivNoCmt;


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

        /// public propaty name  :  FreePrtPprGroupCd
        /// <summary>自由帳票グループコードプロパティ</summary>
        /// <value>0:全て,1～:ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自由帳票グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FreePrtPprGroupCd
        {
            get { return _freePrtPprGroupCd; }
            set { _freePrtPprGroupCd = value; }
        }

        /// public propaty name  :  TransferCode
        /// <summary>振替コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   振替コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TransferCode
        {
            get { return _transferCode; }
            set { _transferCode = value; }
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

        /// public propaty name  :  DisplayName
        /// <summary>出力名称プロパティ</summary>
        /// <value>ガイド等に表示する名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        /// public propaty name  :  OutputFormFileName
        /// <summary>出力ファイル名プロパティ</summary>
        /// <value>フォームファイルID or フォーマットファイルID</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力ファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OutputFormFileName
        {
            get { return _outputFormFileName; }
            set { _outputFormFileName = value; }
        }

        /// public propaty name  :  UserPrtPprIdDerivNo
        /// <summary>ユーザー帳票ID枝番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザー帳票ID枝番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserPrtPprIdDerivNo
        {
            get { return _userPrtPprIdDerivNo; }
            set { _userPrtPprIdDerivNo = value; }
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

        /// public propaty name  :  FreePrtPprGroupNm
        /// <summary>自由帳票グループ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自由帳票グループ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FreePrtPprGroupNm
        {
            get { return _freePrtPprGroupNm; }
            set { _freePrtPprGroupNm = value; }
        }

        /// public propaty name  :  PrtPprUserDerivNoCmt
        /// <summary>帳票ユーザー枝番コメントプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票ユーザー枝番コメントプロパティ</br>
        /// <br>Programer        :   22011 柏原　頼人</br>
        /// </remarks>
        public string PrtPprUserDerivNoCmt
        {
            get { return _prtPprUserDerivNoCmt; }
            set { _prtPprUserDerivNoCmt = value; }
        }

        /// <summary>
        /// 自由帳票グループ振替マスタコンストラクタ
        /// </summary>
        /// <returns>FrePprGrTrクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePprGrTrクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FrePprGrTr()
        {   
        }

        /// <summary>
        /// 自由帳票グループ振替マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="freePrtPprGroupCd">自由帳票グループコード(0:全て,1～:ユーザー登録)</param>
        /// <param name="transferCode">振替コード</param>
        /// <param name="displayOrder">表示順位</param>
        /// <param name="displayName">出力名称(ガイド等に表示する名称)</param>
        /// <param name="outputFormFileName">出力ファイル名(フォームファイルID or フォーマットファイルID)</param>
        /// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番号</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="freePrtPprGroupNm">自由帳票グループ名称</param>
        /// <param name="prtPprUserDerivNoCmt">帳票ユーザー枝番コメント</param>
        /// <returns>FrePprGrTrクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePprGrTrクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FrePprGrTr(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 freePrtPprGroupCd, Int32 transferCode, Int32 displayOrder, string displayName, string outputFormFileName, Int32 userPrtPprIdDerivNo, string enterpriseName, string updEmployeeName, string freePrtPprGroupNm, string prtPprUserDerivNoCmt)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._freePrtPprGroupCd = freePrtPprGroupCd;
            this._transferCode = transferCode;
            this._displayOrder = displayOrder;
            this._displayName = displayName;
            this._outputFormFileName = outputFormFileName;
            this._userPrtPprIdDerivNo = userPrtPprIdDerivNo;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._freePrtPprGroupNm = freePrtPprGroupNm;
            this._prtPprUserDerivNoCmt = prtPprUserDerivNoCmt;
        }

        /// <summary>
        /// 自由帳票グループ振替マスタ複製処理
        /// </summary>
        /// <returns>FrePprGrTrクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいFrePprGrTrクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FrePprGrTr Clone()
        {
            return new FrePprGrTr(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._freePrtPprGroupCd, this._transferCode, this._displayOrder, this._displayName, this._outputFormFileName, this._userPrtPprIdDerivNo, this._enterpriseName, this._updEmployeeName, this._freePrtPprGroupNm, this._prtPprUserDerivNoCmt);
        }

        /// <summary>
        /// 自由帳票グループ振替マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のFrePprGrTrクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePprGrTrクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(FrePprGrTr target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.FreePrtPprGroupCd == target.FreePrtPprGroupCd)
                 && (this.TransferCode == target.TransferCode)
                 && (this.DisplayOrder == target.DisplayOrder)
                 && (this.DisplayName == target.DisplayName)
                 && (this.OutputFormFileName == target.OutputFormFileName)
                 && (this.UserPrtPprIdDerivNo == target.UserPrtPprIdDerivNo)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.FreePrtPprGroupNm == target.FreePrtPprGroupNm)
                 && (this.PrtPprUserDerivNoCmt == target.PrtPprUserDerivNoCmt)
                 );
        }

        /// <summary>
        /// 自由帳票グループ振替マスタ比較処理
        /// </summary>
        /// <param name="frePprGrTr1">
        ///                    比較するFrePprGrTrクラスのインスタンス
        /// </param>
        /// <param name="frePprGrTr2">比較するFrePprGrTrクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePprGrTrクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(FrePprGrTr frePprGrTr1, FrePprGrTr frePprGrTr2)
        {
            return ((frePprGrTr1.CreateDateTime == frePprGrTr2.CreateDateTime)
                 && (frePprGrTr1.UpdateDateTime == frePprGrTr2.UpdateDateTime)
                 && (frePprGrTr1.EnterpriseCode == frePprGrTr2.EnterpriseCode)
                 && (frePprGrTr1.FileHeaderGuid == frePprGrTr2.FileHeaderGuid)
                 && (frePprGrTr1.UpdEmployeeCode == frePprGrTr2.UpdEmployeeCode)
                 && (frePprGrTr1.UpdAssemblyId1 == frePprGrTr2.UpdAssemblyId1)
                 && (frePprGrTr1.UpdAssemblyId2 == frePprGrTr2.UpdAssemblyId2)
                 && (frePprGrTr1.LogicalDeleteCode == frePprGrTr2.LogicalDeleteCode)
                 && (frePprGrTr1.FreePrtPprGroupCd == frePprGrTr2.FreePrtPprGroupCd)
                 && (frePprGrTr1.TransferCode == frePprGrTr2.TransferCode)
                 && (frePprGrTr1.DisplayOrder == frePprGrTr2.DisplayOrder)
                 && (frePprGrTr1.DisplayName == frePprGrTr2.DisplayName)
                 && (frePprGrTr1.OutputFormFileName == frePprGrTr2.OutputFormFileName)
                 && (frePprGrTr1.UserPrtPprIdDerivNo == frePprGrTr2.UserPrtPprIdDerivNo)
                 && (frePprGrTr1.EnterpriseName == frePprGrTr2.EnterpriseName)
                 && (frePprGrTr1.UpdEmployeeName == frePprGrTr2.UpdEmployeeName)
                 && (frePprGrTr1.FreePrtPprGroupNm == frePprGrTr2.FreePrtPprGroupNm)
                 && (frePprGrTr1.PrtPprUserDerivNoCmt == frePprGrTr2.PrtPprUserDerivNoCmt)
                 );
        }
        /// <summary>
        /// 自由帳票グループ振替マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のFrePprGrTrクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePprGrTrクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(FrePprGrTr target)
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
            if (this.FreePrtPprGroupCd != target.FreePrtPprGroupCd) resList.Add("FreePrtPprGroupCd");
            if (this.TransferCode != target.TransferCode) resList.Add("TransferCode");
            if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
            if (this.DisplayName != target.DisplayName) resList.Add("DisplayName");
            if (this.OutputFormFileName != target.OutputFormFileName) resList.Add("OutputFormFileName");
            if (this.UserPrtPprIdDerivNo != target.UserPrtPprIdDerivNo) resList.Add("UserPrtPprIdDerivNo");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.FreePrtPprGroupNm != target.FreePrtPprGroupNm) resList.Add("FreePrtPprGroupNm");
            if (this.PrtPprUserDerivNoCmt != target.PrtPprUserDerivNoCmt) resList.Add("PrtPprUserDerivNoCmt");


            return resList;
        }

        /// <summary>
        /// 自由帳票グループ振替マスタ比較処理
        /// </summary>
        /// <param name="frePprGrTr1">比較するFrePprGrTrクラスのインスタンス</param>
        /// <param name="frePprGrTr2">比較するFrePprGrTrクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePprGrTrクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(FrePprGrTr frePprGrTr1, FrePprGrTr frePprGrTr2)
        {
            ArrayList resList = new ArrayList();
            if (frePprGrTr1.CreateDateTime != frePprGrTr2.CreateDateTime) resList.Add("CreateDateTime");
            if (frePprGrTr1.UpdateDateTime != frePprGrTr2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (frePprGrTr1.EnterpriseCode != frePprGrTr2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (frePprGrTr1.FileHeaderGuid != frePprGrTr2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (frePprGrTr1.UpdEmployeeCode != frePprGrTr2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (frePprGrTr1.UpdAssemblyId1 != frePprGrTr2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (frePprGrTr1.UpdAssemblyId2 != frePprGrTr2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (frePprGrTr1.LogicalDeleteCode != frePprGrTr2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (frePprGrTr1.FreePrtPprGroupCd != frePprGrTr2.FreePrtPprGroupCd) resList.Add("FreePrtPprGroupCd");
            if (frePprGrTr1.TransferCode != frePprGrTr2.TransferCode) resList.Add("TransferCode");
            if (frePprGrTr1.DisplayOrder != frePprGrTr2.DisplayOrder) resList.Add("DisplayOrder");
            if (frePprGrTr1.DisplayName != frePprGrTr2.DisplayName) resList.Add("DisplayName");
            if (frePprGrTr1.OutputFormFileName != frePprGrTr2.OutputFormFileName) resList.Add("OutputFormFileName");
            if (frePprGrTr1.UserPrtPprIdDerivNo != frePprGrTr2.UserPrtPprIdDerivNo) resList.Add("UserPrtPprIdDerivNo");
            if (frePprGrTr1.EnterpriseName != frePprGrTr2.EnterpriseName) resList.Add("EnterpriseName");
            if (frePprGrTr1.UpdEmployeeName != frePprGrTr2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (frePprGrTr1.FreePrtPprGroupNm != frePprGrTr2.FreePrtPprGroupNm) resList.Add("FreePrtPprGroupNm");
            if (frePprGrTr1.PrtPprUserDerivNoCmt != frePprGrTr2.PrtPprUserDerivNoCmt) resList.Add("PrtPprUserDerivNoCmt");

            return resList;
        }
    }
}
