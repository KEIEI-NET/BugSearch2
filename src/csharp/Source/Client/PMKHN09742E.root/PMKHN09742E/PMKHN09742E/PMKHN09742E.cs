//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 従業員ロール設定マスタ
// プログラム概要   : 従業員ロール設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸　伸悟
// 作 成 日  2013/02/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   EmployeeRoleSt
    /// <summary>
    ///                      従業員ロール設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   ロールグループ設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2013/02/07</br>
    /// <br>Genarated Date   :   2013/02/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class EmployeeRoleSt
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

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>ロールグループコード</summary>
        /// <remarks>任意の無重複コードとする（自動付番はしない）</remarks>
        private Int32 _roleGroupCode;

        /// <summary>ロールグループ名称</summary>
        private string _roleGroupName = "";

        /// <summary>従業員名称</summary>
        private string _employeeName = "";

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

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  RoleGroupCode
        /// <summary>ロールグループコードプロパティ</summary>
        /// <value>任意の無重複コードとする（自動付番はしない）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ロールグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RoleGroupCode
        {
            get { return _roleGroupCode; }
            set { _roleGroupCode = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>ロールグループ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ロールグループ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RoleGroupName
        {
            get { return _roleGroupName; }
            set { _roleGroupName = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
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

        /// <summary>
        /// 従業員ロール設定マスタコンストラクタ
        /// </summary>
        /// <returns>EmployeeRoleStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note             :   EmployeeRoleStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EmployeeRoleSt()
        {
        }

        /// <summary>
        /// 従業員ロール設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="roleGroupCode">ロールグループコード(任意の無重複コードとする（自動付番はしない）)</param>
        /// <returns>EmployeeRoleStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note             :   EmployeeRoleStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EmployeeRoleSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string employeeCode, Int32 roleGroupCode, string roleGroupName, string employeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._employeeCode = employeeCode;
            this._roleGroupCode = roleGroupCode;
            this._roleGroupName = roleGroupName;
            this._employeeName = employeeName;
        }

        /// <summary>
        /// 従業員ロール設定マスタ複製処理
        /// </summary>
        /// <returns>EmployeeRoleStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note             :   自身の内容と等しいEmployeeRoleStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EmployeeRoleSt Clone()
        {
            return new EmployeeRoleSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._employeeCode, this._roleGroupCode, this._roleGroupName, this._employeeName);
        }

        /// <summary>
        ///     従業員ロール設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のEmployeeRoleStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note             :   EmployeeRoleStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(EmployeeRoleSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.RoleGroupCode == target.RoleGroupCode));
        }

        /// <summary>
        /// 従業員ロール設定マスタ比較処理
        /// </summary>
        /// <param name="employeeRoleSt1">比較するEmployeeRoleStクラスのインスタンス</param>
        /// <param name="employeeRoleSt2">比較するEmployeeRoleStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note             :   EmployeeRoleStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(EmployeeRoleSt employeeRoleSt1, EmployeeRoleSt employeeRoleSt2)
        {
            return ((employeeRoleSt1.CreateDateTime == employeeRoleSt2.CreateDateTime)
                 && (employeeRoleSt1.UpdateDateTime == employeeRoleSt2.UpdateDateTime)
                 && (employeeRoleSt1.EnterpriseCode == employeeRoleSt2.EnterpriseCode)
                 && (employeeRoleSt1.FileHeaderGuid == employeeRoleSt2.FileHeaderGuid)
                 && (employeeRoleSt1.UpdEmployeeCode == employeeRoleSt2.UpdEmployeeCode)
                 && (employeeRoleSt1.UpdAssemblyId1 == employeeRoleSt2.UpdAssemblyId1)
                 && (employeeRoleSt1.UpdAssemblyId2 == employeeRoleSt2.UpdAssemblyId2)
                 && (employeeRoleSt1.LogicalDeleteCode == employeeRoleSt2.LogicalDeleteCode)
                 && (employeeRoleSt1.EmployeeCode == employeeRoleSt2.EmployeeCode)
                 && (employeeRoleSt1.RoleGroupCode == employeeRoleSt2.RoleGroupCode));
        }
        /// <summary>
        /// 従業員ロール設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のEmployeeRoleStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note             :   EmployeeRoleStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(EmployeeRoleSt target)
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
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.RoleGroupCode != target.RoleGroupCode) resList.Add("RoleGroupCode");

            return resList;
        }

        /// <summary>
        /// 従業員ロール設定マスタ比較処理
        /// </summary>
        /// <param name="employeeRoleSt1">比較するEmployeeRoleStクラスのインスタンス</param>
        /// <param name="employeeRoleSt2">比較するEmployeeRoleStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note             :   EmployeeRoleStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(EmployeeRoleSt employeeRoleSt1, EmployeeRoleSt employeeRoleSt2)
        {
            ArrayList resList = new ArrayList();
            if (employeeRoleSt1.CreateDateTime != employeeRoleSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (employeeRoleSt1.UpdateDateTime != employeeRoleSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (employeeRoleSt1.EnterpriseCode != employeeRoleSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (employeeRoleSt1.FileHeaderGuid != employeeRoleSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (employeeRoleSt1.UpdEmployeeCode != employeeRoleSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (employeeRoleSt1.UpdAssemblyId1 != employeeRoleSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (employeeRoleSt1.UpdAssemblyId2 != employeeRoleSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (employeeRoleSt1.LogicalDeleteCode != employeeRoleSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (employeeRoleSt1.EmployeeCode != employeeRoleSt2.EmployeeCode) resList.Add("EmployeeCode");
            if (employeeRoleSt1.RoleGroupCode != employeeRoleSt2.RoleGroupCode) resList.Add("RoleGroupCode");

            return resList;
        }
    }
}
