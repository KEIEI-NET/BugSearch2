using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PM7RkSetting
    /// <summary>
    ///                      PM7連携設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   PM7連携設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/7/12</br>
    /// <br>Genarated Date   :   2011/07/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PM7RkSetting
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

        /// <summary>売上連携自動区分</summary>
        /// <remarks>0：しない　1：する 　初期値が「0：しない」</remarks>
        private Int32 _salesRkAutoCode;

        /// <summary>売上連携自動送信間隔</summary>
        private Int64 _salesRkAutoSndTime;

        /// <summary>マスタ連携自動区分</summary>
        /// <remarks>0：しない　1：する 　初期値が「0：しない」</remarks>
        private Int32 _masterRkAutoCode;

        /// <summary>マスタ連携自動受信間隔</summary>
        private Int64 _masterRkAutoRcvTime;

        /// <summary>テキスト格納フォルダ</summary>
        private string _textSaveFolder = "";

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

        /// public propaty name  :  SalesRkAutoCode
        /// <summary>売上連携自動区分プロパティ</summary>
        /// <value>0：しない　1：する 　初期値が「0：しない」</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上連携自動区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesRkAutoCode
        {
            get { return _salesRkAutoCode; }
            set { _salesRkAutoCode = value; }
        }

        /// public propaty name  :  SalesRkAutoSndTime
        /// <summary>売上連携自動送信間隔プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上連携自動送信間隔プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesRkAutoSndTime
        {
            get { return _salesRkAutoSndTime; }
            set { _salesRkAutoSndTime = value; }
        }

        /// public propaty name  :  MasterRkAutoCode
        /// <summary>マスタ連携自動区分プロパティ</summary>
        /// <value>0：しない　1：する 　初期値が「0：しない」</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   マスタ連携自動区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MasterRkAutoCode
        {
            get { return _masterRkAutoCode; }
            set { _masterRkAutoCode = value; }
        }

        /// public propaty name  :  MasterRkAutoRcvTime
        /// <summary>マスタ連携自動受信間隔プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   マスタ連携自動受信間隔プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MasterRkAutoRcvTime
        {
            get { return _masterRkAutoRcvTime; }
            set { _masterRkAutoRcvTime = value; }
        }

        /// public propaty name  :  TextSaveFolder
        /// <summary>テキスト格納フォルダプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   テキスト格納フォルダプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TextSaveFolder
        {
            get { return _textSaveFolder; }
            set { _textSaveFolder = value; }
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
        /// PM7連携設定マスタコンストラクタ
        /// </summary>
        /// <returns>PM7RkSettingクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PM7RkSettingクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PM7RkSetting()
        {
        }

        /// <summary>
        /// PM7連携設定マスタコンストラクタ
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
        /// <param name="salesRkAutoCode">売上連携自動区分(0：しない　1：する 　初期値が「0：しない」)</param>
        /// <param name="salesRkAutoSndTime">売上連携自動送信間隔</param>
        /// <param name="masterRkAutoCode">マスタ連携自動区分(0：しない　1：する 　初期値が「0：しない」)</param>
        /// <param name="masterRkAutoRcvTime">マスタ連携自動受信間隔</param>
        /// <param name="textSaveFolder">テキスト格納フォルダ</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>PM7RkSettingクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PM7RkSettingクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PM7RkSetting(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 salesRkAutoCode, Int64 salesRkAutoSndTime, Int32 masterRkAutoCode, Int64 masterRkAutoRcvTime, string textSaveFolder, string enterpriseName, string updEmployeeName)
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
            this._salesRkAutoCode = salesRkAutoCode;
            this._salesRkAutoSndTime = salesRkAutoSndTime;
            this._masterRkAutoCode = masterRkAutoCode;
            this._masterRkAutoRcvTime = masterRkAutoRcvTime;
            this._textSaveFolder = textSaveFolder;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// PM7連携設定マスタ複製処理
        /// </summary>
        /// <returns>PM7RkSettingクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPM7RkSettingクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PM7RkSetting Clone()
        {
            return new PM7RkSetting(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._salesRkAutoCode, this._salesRkAutoSndTime, this._masterRkAutoCode, this._masterRkAutoRcvTime, this._textSaveFolder, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// PM7連携設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPM7RkSettingクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PM7RkSettingクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PM7RkSetting target)
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
                 && (this.SalesRkAutoCode == target.SalesRkAutoCode)
                 && (this.SalesRkAutoSndTime == target.SalesRkAutoSndTime)
                 && (this.MasterRkAutoCode == target.MasterRkAutoCode)
                 && (this.MasterRkAutoRcvTime == target.MasterRkAutoRcvTime)
                 && (this.TextSaveFolder == target.TextSaveFolder)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// PM7連携設定マスタ比較処理
        /// </summary>
        /// <param name="pM7RkSetting1">
        ///                    比較するPM7RkSettingクラスのインスタンス
        /// </param>
        /// <param name="pM7RkSetting2">比較するPM7RkSettingクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PM7RkSettingクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PM7RkSetting pM7RkSetting1, PM7RkSetting pM7RkSetting2)
        {
            return ((pM7RkSetting1.CreateDateTime == pM7RkSetting2.CreateDateTime)
                 && (pM7RkSetting1.UpdateDateTime == pM7RkSetting2.UpdateDateTime)
                 && (pM7RkSetting1.EnterpriseCode == pM7RkSetting2.EnterpriseCode)
                 && (pM7RkSetting1.FileHeaderGuid == pM7RkSetting2.FileHeaderGuid)
                 && (pM7RkSetting1.UpdEmployeeCode == pM7RkSetting2.UpdEmployeeCode)
                 && (pM7RkSetting1.UpdAssemblyId1 == pM7RkSetting2.UpdAssemblyId1)
                 && (pM7RkSetting1.UpdAssemblyId2 == pM7RkSetting2.UpdAssemblyId2)
                 && (pM7RkSetting1.LogicalDeleteCode == pM7RkSetting2.LogicalDeleteCode)
                 && (pM7RkSetting1.SectionCode == pM7RkSetting2.SectionCode)
                 && (pM7RkSetting1.SalesRkAutoCode == pM7RkSetting2.SalesRkAutoCode)
                 && (pM7RkSetting1.SalesRkAutoSndTime == pM7RkSetting2.SalesRkAutoSndTime)
                 && (pM7RkSetting1.MasterRkAutoCode == pM7RkSetting2.MasterRkAutoCode)
                 && (pM7RkSetting1.MasterRkAutoRcvTime == pM7RkSetting2.MasterRkAutoRcvTime)
                 && (pM7RkSetting1.TextSaveFolder == pM7RkSetting2.TextSaveFolder)
                 && (pM7RkSetting1.EnterpriseName == pM7RkSetting2.EnterpriseName)
                 && (pM7RkSetting1.UpdEmployeeName == pM7RkSetting2.UpdEmployeeName));
        }
        /// <summary>
        /// PM7連携設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPM7RkSettingクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PM7RkSettingクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PM7RkSetting target)
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
            if (this.SalesRkAutoCode != target.SalesRkAutoCode) resList.Add("SalesRkAutoCode");
            if (this.SalesRkAutoSndTime != target.SalesRkAutoSndTime) resList.Add("SalesRkAutoSndTime");
            if (this.MasterRkAutoCode != target.MasterRkAutoCode) resList.Add("MasterRkAutoCode");
            if (this.MasterRkAutoRcvTime != target.MasterRkAutoRcvTime) resList.Add("MasterRkAutoRcvTime");
            if (this.TextSaveFolder != target.TextSaveFolder) resList.Add("TextSaveFolder");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// PM7連携設定マスタ比較処理
        /// </summary>
        /// <param name="pM7RkSetting1">比較するPM7RkSettingクラスのインスタンス</param>
        /// <param name="pM7RkSetting2">比較するPM7RkSettingクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PM7RkSettingクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PM7RkSetting pM7RkSetting1, PM7RkSetting pM7RkSetting2)
        {
            ArrayList resList = new ArrayList();
            if (pM7RkSetting1.CreateDateTime != pM7RkSetting2.CreateDateTime) resList.Add("CreateDateTime");
            if (pM7RkSetting1.UpdateDateTime != pM7RkSetting2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pM7RkSetting1.EnterpriseCode != pM7RkSetting2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (pM7RkSetting1.FileHeaderGuid != pM7RkSetting2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (pM7RkSetting1.UpdEmployeeCode != pM7RkSetting2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (pM7RkSetting1.UpdAssemblyId1 != pM7RkSetting2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (pM7RkSetting1.UpdAssemblyId2 != pM7RkSetting2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (pM7RkSetting1.LogicalDeleteCode != pM7RkSetting2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pM7RkSetting1.SectionCode != pM7RkSetting2.SectionCode) resList.Add("SectionCode");
            if (pM7RkSetting1.SalesRkAutoCode != pM7RkSetting2.SalesRkAutoCode) resList.Add("SalesRkAutoCode");
            if (pM7RkSetting1.SalesRkAutoSndTime != pM7RkSetting2.SalesRkAutoSndTime) resList.Add("SalesRkAutoSndTime");
            if (pM7RkSetting1.MasterRkAutoCode != pM7RkSetting2.MasterRkAutoCode) resList.Add("MasterRkAutoCode");
            if (pM7RkSetting1.MasterRkAutoRcvTime != pM7RkSetting2.MasterRkAutoRcvTime) resList.Add("MasterRkAutoRcvTime");
            if (pM7RkSetting1.TextSaveFolder != pM7RkSetting2.TextSaveFolder) resList.Add("TextSaveFolder");
            if (pM7RkSetting1.EnterpriseName != pM7RkSetting2.EnterpriseName) resList.Add("EnterpriseName");
            if (pM7RkSetting1.UpdEmployeeName != pM7RkSetting2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  