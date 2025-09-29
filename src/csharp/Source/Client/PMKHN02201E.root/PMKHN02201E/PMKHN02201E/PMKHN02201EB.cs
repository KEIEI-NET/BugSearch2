using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MenueStSet
    /// <summary>
    ///                      メニュー制御設定（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   メニュー制御設定（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2013/02/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class MenueStSet 
    {

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>ソートキー</summary>
        private string _sortKey = "";

        /// <summary>ロールグループコード</summary>
        private Int32 _roleGroupCode;

        /// <summary>ロールグループ名称</summary>
        private string _roleGroupName = "";

        /// <summary>カテゴリ</summary>
        private Int32 _roleCategoryId;

        /// <summary>サブカテゴリ</summary>
        private Int32 _roleCategorySubId;

        /// <summary>アイテム</summary>
        private Int32 _roleItemId;

        /// <summary>システム機能名称</summary>
        private string _systemName = "";

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>従業員名称</summary>
        private string _employeeName = "";

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

        /// public propaty name  :  SortKey
        /// <summary>ソートキープロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ソートキープロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SortKey
        {
            get { return _sortKey; }
            set { _sortKey = value; }
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

        /// public propaty name  :  RoleCategoryId
        /// <summary>カテゴリプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カテゴリプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RoleCategoryId
        {
            get { return _roleCategoryId; }
            set { _roleCategoryId = value; }
        }

        /// public propaty name  :  RoleCategorySubId
        /// <summary>サブカテゴリプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サブカテゴリプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RoleCategorySubId
        {
            get { return _roleCategorySubId; }
            set { _roleCategorySubId = value; }
        }

        /// public propaty name  :  RoleItemId
        /// <summary>アイテムプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   アイテムプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RoleItemId
        {
            get { return _roleItemId; }
            set { _roleItemId = value; }
        }

        /// public propaty name  :  SystemName
        /// <summary>システム機能名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   システム機能名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SystemName
        {
            get { return _systemName; }
            set { _systemName = value; }
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

        /// public propaty name  :  EmployeeName
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

        /// <summary>
        /// メニュー制御設定（印刷）データクラス複製処理
        /// </summary>
        /// <returns>MenueStSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいMenueStSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MenueStSet Clone()
        {
            return new MenueStSet(this._enterpriseCode, this._sortKey, this._roleGroupCode, this._roleGroupName, this._roleCategoryId, this._roleCategorySubId, this._roleItemId, this._systemName, this._employeeCode, this._employeeName);
        }

        /// <summary>
		/// メニュー制御設定（印刷）データクラスワークコンストラクタ
		/// </summary>
		/// <returns>MenueStSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EmployeeSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public MenueStSet()
		{
		}
        
        /// <summary>
        /// メニュー制御設定（印刷）データクラスワークコンストラクタ
        /// </summary>
        public MenueStSet(string EnterpriseCode, string SortKey, Int32 RoleGroupCode, string RoleGroupName, Int32 RoleCategoryId, Int32 RoleCategorySubId, Int32 RoleItemId, string SystemName, string EmployeeCode, string EmployeeName)
        {
            this.EnterpriseCode = EnterpriseCode;
            this._sortKey = SortKey;
            this._roleGroupCode = RoleGroupCode;
            this._roleGroupName = RoleGroupName;
            this._roleCategoryId = RoleCategoryId;
            this._roleCategorySubId = RoleCategorySubId;
            this._roleItemId = RoleItemId;
            this._systemName = SystemName;
            this._employeeCode = EmployeeCode;
            this._employeeName = EmployeeName;
        }
    }
}
