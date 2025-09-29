//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ロールグループ権限設定マスタ                    //
//                      データクラス                                    //
//                  :   PMKHN09731E.DLL                                 //
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
    /// public class name:   RoleGroupAuth
    /// <summary>
    ///                      ロールグループ権限設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   ロールグループ権限設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2013/02/18</br>
    /// <br>Genarated Date   :   2013/02/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class RoleGroupAuth
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
        private Int32 _roleGroupCode;

        /// <summary>ロールカテゴリID</summary>
        private Int32 _roleCategoryID;

        /// <summary>ロールサブカテゴリID</summary>
        private Int32 _roleCategorySubID;

        /// <summary>ロールアイテムID</summary>
        private Int32 _roleItemID;

        /// <summary>ロール制限区分</summary>
        private Int32 _roleLimitDiv;

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

        /// public propaty name  :  RoleCategoryID
        /// <summary>ロールカテゴリIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ロールカテゴリIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RoleCategoryID
        {
            get { return _roleCategoryID; }
            set { _roleCategoryID = value; }
        }

        /// public propaty name  :  RoleCategorySubID
        /// <summary>ロールサブカテゴリIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ロールサブカテゴリIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RoleCategorySubID
        {
            get { return _roleCategorySubID; }
            set { _roleCategorySubID = value; }
        }

        /// public propaty name  :  RoleItemID
        /// <summary>ロールアイテムIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ロールアイテムIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RoleItemID
        {
            get { return _roleItemID; }
            set { _roleItemID = value; }
        }

        /// public propaty name  :  RoleLimitDiv
        /// <summary>ロール制限区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ロール制限区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RoleLimitDiv
        {
            get { return _roleLimitDiv; }
            set { _roleLimitDiv = value; }
        }

        /// <summary>
        /// ロールグループ権限設定マスタコンストラクタ
        /// </summary>
        /// <returns>RoleGroupAuthクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupAuthクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RoleGroupAuth()
        {
        }

        /// <summary>
        /// ロールグループ権限設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="roleGroupCode">ロールグループコード</param>
        /// <param name="roleCategoryID">ロールカテゴリID</param>
        /// <param name="roleCategorySubID">ロールサブカテゴリID</param>
        /// <param name="roleItemID">ロールアイテムID</param>
        /// <param name="roleLimitDiv">ロール制限区分</param>
        /// <returns>RoleGroupAuthクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupAuthクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RoleGroupAuth(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 roleGroupCode, Int32 roleCategoryID, Int32 roleCategorySubID, Int32 roleItemID, Int32 roleLimitDiv)
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
            this._roleCategoryID = roleCategoryID;
            this._roleCategorySubID = roleCategorySubID;
            this._roleItemID = roleItemID;
            this._roleLimitDiv = roleLimitDiv;
        }

        /// <summary>
        /// ロールグループ権限設定マスタ
        /// </summary>
        /// <returns>RoleGroupAuthクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note             :   自身の内容と等しいRoleGroupAuthクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RoleGroupAuth Clone()
        {
            return new RoleGroupAuth(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._roleGroupCode, this._roleCategoryID, this._roleCategorySubID, this._roleItemID, this._roleLimitDiv);
        }

        /// <summary>
        /// ロールグループ権限設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のRoleGroupAuthクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupAuthクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(RoleGroupAuth target)
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
                 && (this.RoleCategoryID == target.RoleCategoryID)
                 && (this.RoleCategorySubID == target.RoleCategorySubID)
                 && (this.RoleItemID == target.RoleItemID)
                 && (this.RoleLimitDiv == target.RoleLimitDiv));
        }

        /// <summary>
        /// ロールグループ権限設定マスタ比較処理
        /// </summary>
        /// <param name="roleGroupAuth1">比較するRoleGroupAuthクラスのインスタンス</param>
        /// <param name="roleGroupAuth2">比較するRoleGroupAuthクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupAuthクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(RoleGroupAuth roleGroupAuth1, RoleGroupAuth roleGroupAuth2)
        {
            return ((roleGroupAuth1.CreateDateTime == roleGroupAuth2.CreateDateTime)
                 && (roleGroupAuth1.UpdateDateTime == roleGroupAuth2.UpdateDateTime)
                 && (roleGroupAuth1.EnterpriseCode == roleGroupAuth2.EnterpriseCode)
                 && (roleGroupAuth1.FileHeaderGuid == roleGroupAuth2.FileHeaderGuid)
                 && (roleGroupAuth1.UpdEmployeeCode == roleGroupAuth2.UpdEmployeeCode)
                 && (roleGroupAuth1.UpdAssemblyId1 == roleGroupAuth2.UpdAssemblyId1)
                 && (roleGroupAuth1.UpdAssemblyId2 == roleGroupAuth2.UpdAssemblyId2)
                 && (roleGroupAuth1.LogicalDeleteCode == roleGroupAuth2.LogicalDeleteCode)
                 && (roleGroupAuth1.RoleGroupCode == roleGroupAuth2.RoleGroupCode)
                 && (roleGroupAuth1.RoleCategoryID == roleGroupAuth2.RoleCategoryID)
                 && (roleGroupAuth1.RoleCategorySubID == roleGroupAuth2.RoleCategorySubID)
                 && (roleGroupAuth1.RoleItemID == roleGroupAuth2.RoleItemID)
                 && (roleGroupAuth1.RoleLimitDiv == roleGroupAuth2.RoleLimitDiv));
        }
        /// <summary>
        /// ロールグループ権限設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のRoleGroupAuthクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupAuthクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(RoleGroupAuth target)
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
            if (this.RoleCategoryID != target.RoleCategoryID) resList.Add("RoleCategoryID");
            if (this.RoleCategorySubID != target.RoleCategorySubID) resList.Add("RoleCategorySubID");
            if (this.RoleItemID != target.RoleItemID) resList.Add("RoleItemID");
            if (this.RoleLimitDiv != target.RoleLimitDiv) resList.Add("RoleLimitDiv");

            return resList;
        }

        /// <summary>
        /// ロールグループ権限設定マスタ比較処理
        /// </summary>
        /// <param name="roleGroupAuth1">比較するRoleGroupAuthクラスのインスタンス</param>
        /// <param name="roleGroupAuth2">比較するRoleGroupAuthクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupAuthクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(RoleGroupAuth roleGroupAuth1, RoleGroupAuth roleGroupAuth2)
        {
            ArrayList resList = new ArrayList();
            if (roleGroupAuth1.CreateDateTime != roleGroupAuth2.CreateDateTime) resList.Add("CreateDateTime");
            if (roleGroupAuth1.UpdateDateTime != roleGroupAuth2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (roleGroupAuth1.EnterpriseCode != roleGroupAuth2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (roleGroupAuth1.FileHeaderGuid != roleGroupAuth2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (roleGroupAuth1.UpdEmployeeCode != roleGroupAuth2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (roleGroupAuth1.UpdAssemblyId1 != roleGroupAuth2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (roleGroupAuth1.UpdAssemblyId2 != roleGroupAuth2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (roleGroupAuth1.LogicalDeleteCode != roleGroupAuth2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (roleGroupAuth1.RoleGroupCode != roleGroupAuth2.RoleGroupCode) resList.Add("RoleGroupCode");
            if (roleGroupAuth1.RoleCategoryID != roleGroupAuth2.RoleCategoryID) resList.Add("RoleCategoryID");
            if (roleGroupAuth1.RoleCategorySubID != roleGroupAuth2.RoleCategorySubID) resList.Add("RoleCategorySubID");
            if (roleGroupAuth1.RoleItemID != roleGroupAuth2.RoleItemID) resList.Add("RoleItemID");
            if (roleGroupAuth1.RoleLimitDiv != roleGroupAuth2.RoleLimitDiv) resList.Add("RoleLimitDiv");

            return resList;
        }
    }
}