//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ロールグループ権限設定マスタ                    //
//                      データクラス                                    //
//                  :   PMKHN09722E.DLL                                 //
// Name Space       :   Broadleaf.Application.UIData                    //
// Programmer       :   30746 高川 悟                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   RoleGroupNameSt
    /// <summary>
    ///                      ロールグループ名称設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   ロールグループ設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2013/02/18</br>
    /// <br>Genarated Date   :   2013/02/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class RoleGroupNameSt
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

        /// <summary>ロールグループコード</summary>
        /// <remarks>任意の無重複コードとする（自動付番はしない）</remarks>
        private Int32 _roleGroupCode;

        /// <summary>ロールグループ名称</summary>
        private string _roleGroupName = "";

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

        /// public propaty name  :  RoleGroupCode
        /// <summary>ロールグループコードプロパティ</summary>
        /// <value>任意の無重複コードとする（自動付番はしない）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ルールグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RoleGroupCode
        {
            get { return _roleGroupCode; }
            set { _roleGroupCode = value; }
        }

        /// public propaty name  :  RoleGroupName
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
        /// ロールグループ名称設定マスタコンストラクタ
        /// </summary>
        /// <returns>RoleGroupNameStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupNameStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RoleGroupNameSt()
        {
        }

        /// <summary>
        /// ロールグループ名称設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="roleGroupCode">ロールグループコード(任意の無重複コードとする（自動付番はしない）)</param>
        /// <param name="roleGroupName">ロールグループ名称</param>
        /// <returns>RoleGroupNameStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupNameStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RoleGroupNameSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 roleGroupCode, string roleGroupName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._roleGroupCode = roleGroupCode;
            this._roleGroupName = roleGroupName;

        }

        /// <summary>
        /// ロールグループ名称設定マスタ複製処理
        /// </summary>
        /// <returns>RoleGroupNameStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note             :   自身の内容と等しいRoleGroupNameStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RoleGroupNameSt Clone()
        {
            return new RoleGroupNameSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._roleGroupCode, this._roleGroupName);
        }

        /// <summary>
        ///     ロールグループ名称設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のRoleGroupNameStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupNameStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(RoleGroupNameSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.RoleGroupCode == target.RoleGroupCode)
                 && (this.RoleGroupName == target.RoleGroupName));
        }

        /// <summary>
        /// ロールグループ名称設定マスタ比較処理
        /// </summary>
        /// <param name="roleGroupNameSt1">比較するRoleGroupNameStクラスのインスタンス</param>
        /// <param name="roleGroupNameSt2">比較するRoleGroupNameStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupNameStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(RoleGroupNameSt roleGroupNameSt1, RoleGroupNameSt roleGroupNameSt2)
        {
            return ((roleGroupNameSt1.CreateDateTime == roleGroupNameSt2.CreateDateTime)
                 && (roleGroupNameSt1.UpdateDateTime == roleGroupNameSt2.UpdateDateTime)
                 && (roleGroupNameSt1.EnterpriseCode == roleGroupNameSt2.EnterpriseCode)
                 && (roleGroupNameSt1.FileHeaderGuid == roleGroupNameSt2.FileHeaderGuid)
                 && (roleGroupNameSt1.UpdEmployeeCode == roleGroupNameSt2.UpdEmployeeCode)
                 && (roleGroupNameSt1.UpdAssemblyId1 == roleGroupNameSt2.UpdAssemblyId1)
                 && (roleGroupNameSt1.UpdAssemblyId2 == roleGroupNameSt2.UpdAssemblyId2)
                 && (roleGroupNameSt1.LogicalDeleteCode == roleGroupNameSt2.LogicalDeleteCode)
                 && (roleGroupNameSt1.RoleGroupCode == roleGroupNameSt2.RoleGroupCode)
                 && (roleGroupNameSt1.RoleGroupName == roleGroupNameSt2.RoleGroupName));
        }
        /// <summary>
        /// ロールグループ名称設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のRoleGroupNameStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupNameStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(RoleGroupNameSt target)
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
            if (this.RoleGroupCode != target.RoleGroupCode) resList.Add("RoleGroupCode");
            if (this.RoleGroupName != target.RoleGroupName) resList.Add("RoleGroupName");

            return resList;
        }

        /// <summary>
        /// ロールグループ名称設定マスタ比較処理
        /// </summary>
        /// <param name="roleGroupNameSt1">比較するRoleGroupNameStクラスのインスタンス</param>
        /// <param name="roleGroupNameSt2">比較するRoleGroupNameStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupNameStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(RoleGroupNameSt roleGroupNameSt1, RoleGroupNameSt roleGroupNameSt2)
        {
            ArrayList resList = new ArrayList();
            if (roleGroupNameSt1.CreateDateTime != roleGroupNameSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (roleGroupNameSt1.UpdateDateTime != roleGroupNameSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (roleGroupNameSt1.EnterpriseCode != roleGroupNameSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (roleGroupNameSt1.FileHeaderGuid != roleGroupNameSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (roleGroupNameSt1.UpdEmployeeCode != roleGroupNameSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (roleGroupNameSt1.UpdAssemblyId1 != roleGroupNameSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (roleGroupNameSt1.UpdAssemblyId2 != roleGroupNameSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (roleGroupNameSt1.LogicalDeleteCode != roleGroupNameSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (roleGroupNameSt1.RoleGroupCode != roleGroupNameSt2.RoleGroupCode) resList.Add("RoleGroupCode");
            if (roleGroupNameSt1.RoleGroupName != roleGroupNameSt2.RoleGroupName) resList.Add("RoleGroupName");

            return resList;
        }
    }
}