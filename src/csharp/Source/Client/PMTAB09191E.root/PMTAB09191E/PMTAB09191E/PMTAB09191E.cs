//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : PMTAB初期表示従業員設定マスタ
// プログラム概要   : PMTAB初期表示従業員設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/09/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PmtDefEmp
    /// <summary>
    ///                      PMTAB初期表示従業員設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   PMTAB初期表示従業員設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2013/5/28</br>
    /// <br>Genarated Date   :   2014/09/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PmtDefEmp
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

        /// <summary>ログイン担当者コード</summary>
        private string _loginAgenCode = "";

        /// <summary>担当者区分</summary>
        /// <remarks>0:得意先担当者 1:ログイン担当者 2:空白 3:固定値</remarks>
        private Int32 _salesEmpDiv;

        /// <summary>販売従業員コード</summary>
        /// <remarks>計上担当者（担当者）</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>受注者区分</summary>
        /// <remarks>0:得意先担当者 1:ログイン担当者 2:空白 3:固定値</remarks>
        private Int32 _frontEmpDiv;

        /// <summary>受付従業員コード</summary>
        /// <remarks>受付担当者（受注者）</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>発行者区分</summary>
        /// <remarks>0:得意先担当者 1:ログイン担当者 2:空白 3:固定値</remarks>
        private Int32 _salesInputDiv;

        /// <summary>売上入力者コード</summary>
        /// <remarks>入力担当者（発行者）</remarks>
        private string _salesInputCode = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>販売従業員名称</summary>
        private string _salesEmployeeNm = "";


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

        /// public propaty name  :  LoginAgenCode
        /// <summary>ログイン担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログイン担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LoginAgenCode
        {
            get { return _loginAgenCode; }
            set { _loginAgenCode = value; }
        }

        /// public propaty name  :  SalesEmpDiv
        /// <summary>担当者区分プロパティ</summary>
        /// <value>0:得意先担当者 1:ログイン担当者 2:空白 3:固定値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesEmpDiv
        {
            get { return _salesEmpDiv; }
            set { _salesEmpDiv = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>販売従業員コードプロパティ</summary>
        /// <value>計上担当者（担当者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmpDiv
        /// <summary>受注者区分プロパティ</summary>
        /// <value>0:得意先担当者 1:ログイン担当者 2:空白 3:固定値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注者区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FrontEmpDiv
        {
            get { return _frontEmpDiv; }
            set { _frontEmpDiv = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>受付従業員コードプロパティ</summary>
        /// <value>受付担当者（受注者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  SalesInputDiv
        /// <summary>発行者区分プロパティ</summary>
        /// <value>0:得意先担当者 1:ログイン担当者 2:空白 3:固定値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行者区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesInputDiv
        {
            get { return _salesInputDiv; }
            set { _salesInputDiv = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>売上入力者コードプロパティ</summary>
        /// <value>入力担当者（発行者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
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

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>販売従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }


        /// <summary>
        /// PMTAB初期表示従業員設定マスタコンストラクタ
        /// </summary>
        /// <returns>PmtDefEmpクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmtDefEmpクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PmtDefEmp()
        {
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="loginAgenCode">ログイン担当者コード</param>
        /// <param name="salesEmpDiv">担当者区分(0:得意先担当者 1:ログイン担当者 2:空白 3:固定値)</param>
        /// <param name="salesEmployeeCd">販売従業員コード(計上担当者（担当者）)</param>
        /// <param name="frontEmpDiv">受注者区分(0:得意先担当者 1:ログイン担当者 2:空白 3:固定値)</param>
        /// <param name="frontEmployeeCd">受付従業員コード(受付担当者（受注者）)</param>
        /// <param name="salesInputDiv">発行者区分(0:得意先担当者 1:ログイン担当者 2:空白 3:固定値)</param>
        /// <param name="salesInputCode">売上入力者コード(入力担当者（発行者）)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="salesEmployeeNm">販売従業員名称</param>
        /// <returns>PmtDefEmpクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmtDefEmpクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PmtDefEmp(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string loginAgenCode, Int32 salesEmpDiv, string salesEmployeeCd, Int32 frontEmpDiv, string frontEmployeeCd, Int32 salesInputDiv, string salesInputCode, string enterpriseName, string updEmployeeName, string salesEmployeeNm)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._loginAgenCode = loginAgenCode;
            this._salesEmpDiv = salesEmpDiv;
            this._salesEmployeeCd = salesEmployeeCd;
            this._frontEmpDiv = frontEmpDiv;
            this._frontEmployeeCd = frontEmployeeCd;
            this._salesInputDiv = salesInputDiv;
            this._salesInputCode = salesInputCode;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._salesEmployeeNm = salesEmployeeNm;

        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ複製処理
        /// </summary>
        /// <returns>PmtDefEmpクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPmtDefEmpクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PmtDefEmp Clone()
        {
            return new PmtDefEmp(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._loginAgenCode, this._salesEmpDiv, this._salesEmployeeCd, this._frontEmpDiv, this._frontEmployeeCd, this._salesInputDiv, this._salesInputCode, this._enterpriseName, this._updEmployeeName, this._salesEmployeeNm);
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPmtDefEmpクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmtDefEmpクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PmtDefEmp target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.LoginAgenCode == target.LoginAgenCode)
                 && (this.SalesEmpDiv == target.SalesEmpDiv)
                 && (this.SalesEmployeeCd == target.SalesEmployeeCd)
                 && (this.FrontEmpDiv == target.FrontEmpDiv)
                 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
                 && (this.SalesInputDiv == target.SalesInputDiv)
                 && (this.SalesInputCode == target.SalesInputCode)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.SalesEmployeeNm == target.SalesEmployeeNm));
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ比較処理
        /// </summary>
        /// <param name="pmtDefEmp1">
        ///                    比較するPmtDefEmpクラスのインスタンス
        /// </param>
        /// <param name="pmtDefEmp2">比較するPmtDefEmpクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmtDefEmpクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PmtDefEmp pmtDefEmp1, PmtDefEmp pmtDefEmp2)
        {
            return ((pmtDefEmp1.CreateDateTime == pmtDefEmp2.CreateDateTime)
                 && (pmtDefEmp1.UpdateDateTime == pmtDefEmp2.UpdateDateTime)
                 && (pmtDefEmp1.EnterpriseCode == pmtDefEmp2.EnterpriseCode)
                 && (pmtDefEmp1.FileHeaderGuid == pmtDefEmp2.FileHeaderGuid)
                 && (pmtDefEmp1.UpdEmployeeCode == pmtDefEmp2.UpdEmployeeCode)
                 && (pmtDefEmp1.UpdAssemblyId1 == pmtDefEmp2.UpdAssemblyId1)
                 && (pmtDefEmp1.UpdAssemblyId2 == pmtDefEmp2.UpdAssemblyId2)
                 && (pmtDefEmp1.LogicalDeleteCode == pmtDefEmp2.LogicalDeleteCode)
                 && (pmtDefEmp1.LoginAgenCode == pmtDefEmp2.LoginAgenCode)
                 && (pmtDefEmp1.SalesEmpDiv == pmtDefEmp2.SalesEmpDiv)
                 && (pmtDefEmp1.SalesEmployeeCd == pmtDefEmp2.SalesEmployeeCd)
                 && (pmtDefEmp1.FrontEmpDiv == pmtDefEmp2.FrontEmpDiv)
                 && (pmtDefEmp1.FrontEmployeeCd == pmtDefEmp2.FrontEmployeeCd)
                 && (pmtDefEmp1.SalesInputDiv == pmtDefEmp2.SalesInputDiv)
                 && (pmtDefEmp1.SalesInputCode == pmtDefEmp2.SalesInputCode)
                 && (pmtDefEmp1.EnterpriseName == pmtDefEmp2.EnterpriseName)
                 && (pmtDefEmp1.UpdEmployeeName == pmtDefEmp2.UpdEmployeeName)
                 && (pmtDefEmp1.SalesEmployeeNm == pmtDefEmp2.SalesEmployeeNm));
        }
        /// <summary>
        /// PMTAB初期表示従業員設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPmtDefEmpクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmtDefEmpクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PmtDefEmp target)
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
            if (this.LoginAgenCode != target.LoginAgenCode) resList.Add("LoginAgenCode");
            if (this.SalesEmpDiv != target.SalesEmpDiv) resList.Add("SalesEmpDiv");
            if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (this.FrontEmpDiv != target.FrontEmpDiv) resList.Add("FrontEmpDiv");
            if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (this.SalesInputDiv != target.SalesInputDiv) resList.Add("SalesInputDiv");
            if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.SalesEmployeeNm != target.SalesEmployeeNm) resList.Add("SalesEmployeeNm");

            return resList;
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ比較処理
        /// </summary>
        /// <param name="pmtDefEmp1">比較するPmtDefEmpクラスのインスタンス</param>
        /// <param name="pmtDefEmp2">比較するPmtDefEmpクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmtDefEmpクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PmtDefEmp pmtDefEmp1, PmtDefEmp pmtDefEmp2)
        {
            ArrayList resList = new ArrayList();
            if (pmtDefEmp1.CreateDateTime != pmtDefEmp2.CreateDateTime) resList.Add("CreateDateTime");
            if (pmtDefEmp1.UpdateDateTime != pmtDefEmp2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pmtDefEmp1.EnterpriseCode != pmtDefEmp2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (pmtDefEmp1.FileHeaderGuid != pmtDefEmp2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (pmtDefEmp1.UpdEmployeeCode != pmtDefEmp2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (pmtDefEmp1.UpdAssemblyId1 != pmtDefEmp2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (pmtDefEmp1.UpdAssemblyId2 != pmtDefEmp2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (pmtDefEmp1.LogicalDeleteCode != pmtDefEmp2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pmtDefEmp1.LoginAgenCode != pmtDefEmp2.LoginAgenCode) resList.Add("LoginAgenCode");
            if (pmtDefEmp1.SalesEmpDiv != pmtDefEmp2.SalesEmpDiv) resList.Add("SalesEmpDiv");
            if (pmtDefEmp1.SalesEmployeeCd != pmtDefEmp2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (pmtDefEmp1.FrontEmpDiv != pmtDefEmp2.FrontEmpDiv) resList.Add("FrontEmpDiv");
            if (pmtDefEmp1.FrontEmployeeCd != pmtDefEmp2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (pmtDefEmp1.SalesInputDiv != pmtDefEmp2.SalesInputDiv) resList.Add("SalesInputDiv");
            if (pmtDefEmp1.SalesInputCode != pmtDefEmp2.SalesInputCode) resList.Add("SalesInputCode");
            if (pmtDefEmp1.EnterpriseName != pmtDefEmp2.EnterpriseName) resList.Add("EnterpriseName");
            if (pmtDefEmp1.UpdEmployeeName != pmtDefEmp2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (pmtDefEmp1.SalesEmployeeNm != pmtDefEmp2.SalesEmployeeNm) resList.Add("SalesEmployeeNm");

            return resList;
        }
    }
}
