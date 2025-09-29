using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PmTabTtlStSec
    /// <summary>
    ///                      タブレット全体設定マスタ(拠点別)
    /// </summary>
    /// <remarks>
    /// <br>note             :   タブレット全体設定マスタ(拠点別)ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2013/05/31 (CSharp File Generated Date)</br>
    /// </remarks>
    public class PmTabTtlStSec
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

        /// <summary>受信処理起動端末番号コード</summary>
        private Int32 _cashRegisterNo;

        /// <summary>受信処理起動端末番号名称</summary>
        private string _cashRegisterNoNM = "";

        /// <summary>印刷品番選択区分</summary>
        private Int32 _liPriSelPrtGdsNoDiv;

        /// <summary>印刷品番選択区分名称</summary>
        private string _liPriSelPrtGdsNoDivNM = "";

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

        /// public propaty name  :  CashRegisterNo
        /// <summary>受信処理起動端末番号ロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信処理起動端末番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// public propaty name  :  CashRegisterNoNM
        /// <summary>受信処理起動端末番号名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信処理起動端末番号名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CashRegisterNoNM
        {
            get { return _cashRegisterNoNM; }
            set { _cashRegisterNoNM = value; }
        }

        /// public propaty name  :  LiPriSelPrtGdsNoDiv
        /// <summary>印刷品番選択区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷品番選択区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LiPriSelPrtGdsNoDiv
        {
            get { return _liPriSelPrtGdsNoDiv; }
            set { _liPriSelPrtGdsNoDiv = value; }
        }

        /// public propaty name  :  LiPriSelPrtGdsNoDivNM
        /// <summary>印刷品番選択区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷品番選択区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LiPriSelPrtGdsNoDivNM
        {
            get { return _liPriSelPrtGdsNoDivNM; }
            set { _liPriSelPrtGdsNoDivNM = value; }
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
        /// タブレット全体設定マスタ(拠点別)コンストラクタ
        /// </summary>
        /// <returns>PmTabTtlStSecクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmTabTtlStSecクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PmTabTtlStSec ()
        {
        }

        /// <summary>
        /// タブレット全体設定マスタ(拠点別)コンストラクタ
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
        /// <param name="cashRegisterNo">受信処理起動端末コード</param>
        /// <param name="cashRegisterNoNM">受信処理起動端末名称</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="liPriSelPrtGdsNoDiv">印刷品番選択区分</param>
        /// <param name="liPriSelPrtGdsNoDivNM">印刷品番選択区分名称</param>
        /// <returns>PmTabTtlStSecクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmTabTtlStSecクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PmTabTtlStSec(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 cashRegisterNo, string cashRegisterNoNM, Int32 liPriSelPrtGdsNoDiv, string liPriSelPrtGdsNoDivNM, string enterpriseName, string updEmployeeName)
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
            this._cashRegisterNo = cashRegisterNo;
            this._cashRegisterNoNM = cashRegisterNoNM;
            this._liPriSelPrtGdsNoDiv = liPriSelPrtGdsNoDiv;
            this._liPriSelPrtGdsNoDivNM = liPriSelPrtGdsNoDivNM;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// タブレット全体設定マスタ(拠点別)複製処理
        /// </summary>
        /// <returns>PmTabTtlStSecクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPmTabTtlStSecクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PmTabTtlStSec Clone()
        {
            return new PmTabTtlStSec(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._cashRegisterNo, this._cashRegisterNoNM, this._liPriSelPrtGdsNoDiv, this._liPriSelPrtGdsNoDivNM, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// タブレット全体設定マスタ(拠点別)比較処理
        /// </summary>
        /// <param name="target">比較対象のPmTabTtlStSecクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmTabTtlStSecクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PmTabTtlStSec target)
        {
            return ( ( this.CreateDateTime == target.CreateDateTime )
                 && ( this.UpdateDateTime == target.UpdateDateTime )
                 && ( this.EnterpriseCode == target.EnterpriseCode )
                 && ( this.FileHeaderGuid == target.FileHeaderGuid )
                 && ( this.UpdEmployeeCode == target.UpdEmployeeCode )
                 && ( this.UpdAssemblyId1 == target.UpdAssemblyId1 )
                 && ( this.UpdAssemblyId2 == target.UpdAssemblyId2 )
                 && ( this.LogicalDeleteCode == target.LogicalDeleteCode )
                 && ( this.SectionCode == target.SectionCode )
                 && ( this.CashRegisterNo == target.CashRegisterNo)
                 && ( this.CashRegisterNoNM == target.CashRegisterNoNM)
                 && ( this.LiPriSelPrtGdsNoDiv == target.LiPriSelPrtGdsNoDiv)
                 && ( this.LiPriSelPrtGdsNoDivNM == target.LiPriSelPrtGdsNoDivNM)
                 && ( this.EnterpriseName == target.EnterpriseName )
                 && ( this.UpdEmployeeName == target.UpdEmployeeName ) );
        }

        /// <summary>
        /// タブレット全体設定マスタ(拠点別)比較処理
        /// </summary>
        /// <param name="tabTtlStSec1">
        ///                    比較するPmTabTtlStSecクラスのインスタンス
        /// </param>
        /// <param name="tabTtlStSec2">比較するPmTabTtlStSecクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmTabTtlStSecクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PmTabTtlStSec tabTtlStSec1, PmTabTtlStSec tabTtlStSec2)
        {
            return ( ( tabTtlStSec1.CreateDateTime == tabTtlStSec2.CreateDateTime )
                 && ( tabTtlStSec1.UpdateDateTime == tabTtlStSec2.UpdateDateTime )
                 && ( tabTtlStSec1.EnterpriseCode == tabTtlStSec2.EnterpriseCode )
                 && ( tabTtlStSec1.FileHeaderGuid == tabTtlStSec2.FileHeaderGuid )
                 && ( tabTtlStSec1.UpdEmployeeCode == tabTtlStSec2.UpdEmployeeCode )
                 && ( tabTtlStSec1.UpdAssemblyId1 == tabTtlStSec2.UpdAssemblyId1 )
                 && ( tabTtlStSec1.UpdAssemblyId2 == tabTtlStSec2.UpdAssemblyId2 )
                 && ( tabTtlStSec1.LogicalDeleteCode == tabTtlStSec2.LogicalDeleteCode )
                 && ( tabTtlStSec1.SectionCode == tabTtlStSec2.SectionCode )
                 && ( tabTtlStSec1.CashRegisterNo == tabTtlStSec2.CashRegisterNo)
                 && ( tabTtlStSec1.CashRegisterNoNM == tabTtlStSec2.CashRegisterNoNM)
                 && ( tabTtlStSec1.LiPriSelPrtGdsNoDiv == tabTtlStSec2.LiPriSelPrtGdsNoDiv)
                 && ( tabTtlStSec1.LiPriSelPrtGdsNoDivNM == tabTtlStSec2.LiPriSelPrtGdsNoDivNM)
                 && ( tabTtlStSec1.EnterpriseName == tabTtlStSec2.EnterpriseName )
                 && ( tabTtlStSec1.UpdEmployeeName == tabTtlStSec2.UpdEmployeeName ) );
        }
        /// <summary>
        /// タブレット全体設定マスタ(拠点別)比較処理
        /// </summary>
        /// <param name="target">比較対象のPmTabTtlStSecクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmTabTtlStSecクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PmTabTtlStSec target)
        {
            ArrayList resList = new ArrayList();
            if ( this.CreateDateTime != target.CreateDateTime ) resList.Add("CreateDateTime");
            if ( this.UpdateDateTime != target.UpdateDateTime ) resList.Add("UpdateDateTime");
            if ( this.EnterpriseCode != target.EnterpriseCode ) resList.Add("EnterpriseCode");
            if ( this.FileHeaderGuid != target.FileHeaderGuid ) resList.Add("FileHeaderGuid");
            if ( this.UpdEmployeeCode != target.UpdEmployeeCode ) resList.Add("UpdEmployeeCode");
            if ( this.UpdAssemblyId1 != target.UpdAssemblyId1 ) resList.Add("UpdAssemblyId1");
            if ( this.UpdAssemblyId2 != target.UpdAssemblyId2 ) resList.Add("UpdAssemblyId2");
            if ( this.LogicalDeleteCode != target.LogicalDeleteCode ) resList.Add("LogicalDeleteCode");
            if ( this.SectionCode != target.SectionCode ) resList.Add("SectionCode");
            if ( this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
            if ( this.CashRegisterNoNM != target.CashRegisterNoNM) resList.Add("CashRegisterNoNM");
            if ( this.LiPriSelPrtGdsNoDiv != target.LiPriSelPrtGdsNoDiv) resList.Add("LiPriSelPrtGdsNoDiv");
            if (this.LiPriSelPrtGdsNoDivNM != target.LiPriSelPrtGdsNoDivNM) resList.Add("LiPriSelPrtGdsNoDivNM");
            if ( this.EnterpriseName != target.EnterpriseName ) resList.Add("EnterpriseName");
            if ( this.UpdEmployeeName != target.UpdEmployeeName ) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// タブレット全体設定マスタ(拠点別)比較処理
        /// </summary>
        /// <param name="tabTtlStSec1">比較するPmTabTtlStSecクラスのインスタンス</param>
        /// <param name="tabTtlStSec2">比較するPmTabTtlStSecクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmTabTtlStSecクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PmTabTtlStSec tabTtlStSec1, PmTabTtlStSec tabTtlStSec2)
        {
            ArrayList resList = new ArrayList();
            if ( tabTtlStSec1.CreateDateTime != tabTtlStSec2.CreateDateTime ) resList.Add("CreateDateTime");
            if ( tabTtlStSec1.UpdateDateTime != tabTtlStSec2.UpdateDateTime ) resList.Add("UpdateDateTime");
            if ( tabTtlStSec1.EnterpriseCode != tabTtlStSec2.EnterpriseCode ) resList.Add("EnterpriseCode");
            if ( tabTtlStSec1.FileHeaderGuid != tabTtlStSec2.FileHeaderGuid ) resList.Add("FileHeaderGuid");
            if ( tabTtlStSec1.UpdEmployeeCode != tabTtlStSec2.UpdEmployeeCode ) resList.Add("UpdEmployeeCode");
            if ( tabTtlStSec1.UpdAssemblyId1 != tabTtlStSec2.UpdAssemblyId1 ) resList.Add("UpdAssemblyId1");
            if ( tabTtlStSec1.UpdAssemblyId2 != tabTtlStSec2.UpdAssemblyId2 ) resList.Add("UpdAssemblyId2");
            if ( tabTtlStSec1.LogicalDeleteCode != tabTtlStSec2.LogicalDeleteCode ) resList.Add("LogicalDeleteCode");
            if ( tabTtlStSec1.SectionCode != tabTtlStSec2.SectionCode ) resList.Add("SectionCode");
            if ( tabTtlStSec1.CashRegisterNo != tabTtlStSec2.CashRegisterNo) resList.Add("CashRegisterNo");
            if ( tabTtlStSec1.CashRegisterNoNM != tabTtlStSec2.CashRegisterNoNM) resList.Add("CashRegisterNoNM");
            if ( tabTtlStSec1.LiPriSelPrtGdsNoDiv != tabTtlStSec2.LiPriSelPrtGdsNoDiv) resList.Add("LiPriSelPrtGdsNoDiv");
            if ( tabTtlStSec1.LiPriSelPrtGdsNoDivNM != tabTtlStSec2.LiPriSelPrtGdsNoDivNM) resList.Add("LiPriSelPrtGdsNoDivNM");
            if ( tabTtlStSec1.EnterpriseName != tabTtlStSec2.EnterpriseName ) resList.Add("EnterpriseName");
            if ( tabTtlStSec1.UpdEmployeeName != tabTtlStSec2.UpdEmployeeName ) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
