//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限設定アクセス
// プログラム概要   : 以下のクラスのFacade(窓口)となります。
//                  : ・オペレーションマスタローカルアクセス
//                  : ・権限レベルマスタローカルアクセスクラス
//                  : ・オペレーション設定マスタリモートクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2010/07/08  修正内容 : Mantis.15765　明細部並び順を表示順へ変更（各種表示順を取得）
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    using JobTypeDataRow    = AuthorityLevelMasterDataSet.AuthorityLevelMasterRow;
    using EmploymentDataRow = AuthorityLevelMasterDataSet.AuthorityLevelMasterRow;
    using EmployeeDataRow   = EmployeeMasterDataSet.EmployeeMasterRow;

    using OpeSttngDataRow       = OperationSettingMasterDataSet.OperationSettingMasterRow;
    using OperationStDivValue   = OperationSettingMasterDataSet.OperationStDiv;

    /// <summary>
    /// 操作権限設定アクセスクラス
    /// </summary>
    /// <remarks>
    /// 以下のクラスのFacade(窓口)となります。<br/>
    /// ・オペレーションマスタローカルアクセス<br/>
    /// ・権限レベルマスタローカルアクセスクラス<br/>
    /// ・オペレーション設定マスタリモートクラス<br/>
    /// </remarks>
    public sealed class OperationAuthoritySettingAcs : IDisposable
    {
        #region <Singleton Idiom/>

        /// <summary>同期オブジェクト</summary>
        private static readonly object _syncRoot = new object();

        /// <summary>シングルトンインスタンス</summary>
        private static OperationAuthoritySettingAcs _instance;
        /// <summary>
        /// シングルトンインスタンスを取得します。
        /// </summary>
        /// <value>操作権限設定アクセスクラスのシングルトンインスタンス</value>
        public static OperationAuthoritySettingAcs Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new OperationAuthoritySettingAcs();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        private OperationAuthoritySettingAcs() { }

        #endregion  // <Singleton Idiom/>

        #region <IDisposable Member/>

        /// <summary>処分済みフラグ</summary>
        private bool _disposed;
        /// <summary>
        /// 処分済みフラグを取得します。
        /// </summary>
        /// <value>true :処分済み<br/>false:処分していない</value>
        private bool Disposed { get { return _disposed; } }

        /// <summary>
        /// 処分します。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            this._disposed = true;
        }

        /// <summary>
        /// 処分します。
        /// </summary>
        /// <param name="disposing">マネージオブジェクトの処分フラグ</param>
        private void Dispose(bool disposing)
        {
            #region <Guard Phrase/>

            if (this.Disposed) return;

            #endregion  // <Guard Phrase/>

            // マネージオブジェクト
            if (disposing)
            {
                ResetDataSet();
            }
            // アンマネージオブジェクト
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~OperationAuthoritySettingAcs()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        #region 定数
        private const string ctTableName_ActivitySetting = "ActivitySettingTable";
        private const string ctTableName_EmployeeSetting = "EmployeeSettingTable";
        private const string ctTableName_AuthoritySetting = "AuthoritySettingTable";
        #endregion

        #region <従業員別設定用のディクショナリ/>

        private Dictionary<int, List<Employee>> _authorityLevel1EmployeeDictionary;
        private Dictionary<int, List<Employee>> _authorityLevel2EmployeeDictionary;

        #endregion

        #region <DBアクセス代理人/>

        #region <権限レベルマスタローカルアクセス/>

        /// <summary>権限レベルマスタDB</summary>
        private AuthorityLevelLcDBAgent _authorityLevelMasterDB;
        /// <summary>
        /// 権限レベルマスタDBを取得します。
        /// </summary>
        /// <value>権限レベルマスタDB</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public AuthorityLevelLcDBAgent AuthorityLevelMasterDB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_authorityLevelMasterDB == null)
                {
                    _authorityLevelMasterDB = new AuthorityLevelLcDBAgent();
                }
                return _authorityLevelMasterDB;
            }
        }

        #endregion  // <権限レベルマスタローカルアクセス/>

        #region <従業員テーブルアクセス/>

        /// <summary>従業員マスタDB</summary>
        private EmployeeAcsAgent _employeeMasterDB;
        /// <summary>
        /// 従業員マスタDBを取得します。
        /// </summary>
        /// <value>従業員マスタDB</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public EmployeeAcsAgent EmployeeMasterDB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_employeeMasterDB == null)
                {
                    _employeeMasterDB = new EmployeeAcsAgent();
                }
                return _employeeMasterDB;
            }
        }

        #endregion  // <従業員テーブルアクセス/>

        #region <オペレーションマスタローカルアクセス/>

        /// <summary>オペレーションマスタDB</summary>
        private OperationLcDBAgent _operationMasterDB;
        /// <summary>
        /// オペレーションマスタDBを取得します。
        /// </summary>
        /// <value>オペレーションマスタDB</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public OperationLcDBAgent OperationMasterDB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_operationMasterDB == null)
                {
                    _operationMasterDB = new OperationLcDBAgent();
                }
                return _operationMasterDB;
            }
        }

        # endregion // <オペレーションマスタローカルアクセス/>

        #region <オペレーション設定マスタリモート/>

        /// <summary>オペレーション設定マスタDB</summary>
        private OperationStDBAgent _operationSettingMasterDB;
        /// <summary>
        /// オペレーション設定マスタDBを取得します。
        /// </summary>
        /// <value>オペレーション設定マスタDB</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public OperationStDBAgent OperationSettingMasterDB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_operationSettingMasterDB == null)
                {
                    _operationSettingMasterDB = new OperationStDBAgent();
                }
                return _operationSettingMasterDB;
            }
        }

        #endregion  // <オペレーション設定マスタリモート/>

        #endregion  // <DBアクセス代理人/>


        #region <ロール(業務)用データテーブル/>
        /// <summary>ロール（業務）用のデータテーブル</summary>
        private DataTable _activitySettingTable;

        /// <summary>
        /// ロール（業務）用のデータテーブル
        /// </summary>
        public DataTable ActivitySettingTable
        {
            get 
            {
                return SettingSet.Tables[ctTableName_ActivitySetting];
            }
        }
        #endregion

        #region <ロール(権限)用データテーブル/>
        /// <summary>ロール（権限）用のデータテーブル</summary>
        private DataTable _authoritySettingTable;

        /// <summary>
        /// ロール（権限）用のデータテーブル
        /// </summary>
        public DataTable AuthoritySettingTable
        {
            get
            {
                return SettingSet.Tables[ctTableName_AuthoritySetting];
            }
        }
        #endregion

        #region <従業員用用データテーブル/>
        /// <summary>従業員設定用のデータテーブル</summary>
        private DataTable _employeeSettingTable;

        /// <summary>
        /// 従業員設定用のデータテーブル
        /// </summary>
        public DataTable EmployeeSettingTable
        {
            get
            {
                return SettingSet.Tables[ctTableName_EmployeeSetting];
            }
        }
        #endregion

        #region <操作権限設定のUI用データセット/>

        /// <summary>操作権限設定のUI用データセット</summary>
        private SettingDataSet _settingSet;
        /// <summary>
        /// 操作権限設定のUI用データセットを取得します。
        /// </summary>
        /// <value>操作権限設定のUI用データセット</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public SettingDataSet SettingSet
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_settingSet == null)
                {
                    _settingSet = new SettingDataSet();
                    _settingSet.Tables.Add(new DataTable(ctTableName_ActivitySetting));
                    _settingSet.Tables.Add(new DataTable(ctTableName_AuthoritySetting)); 
                    _settingSet.Tables.Add(new DataTable(ctTableName_EmployeeSetting));
                    this._employeeSettingTable = _settingSet.Tables[ctTableName_EmployeeSetting];
                    this._authoritySettingTable = _settingSet.Tables[ctTableName_AuthoritySetting];
                    this._activitySettingTable = _settingSet.Tables[ctTableName_ActivitySetting];
                    InitializeSettingDataSet();
                }
                return _settingSet;
            }
        }

        /// <summary>
        /// 操作権限設定のUI用データセットを初期化します。
        /// </summary>
        private void InitializeSettingDataSet()
        {
            const int SINGLE_ROW = 0;

            SettingSet.EmployeeAuthority.BeginLoadData();
            this._activitySettingTable.BeginLoadData();
            this._authoritySettingTable.BeginLoadData();
            this._employeeSettingTable.BeginLoadData();
            this._authorityLevel1EmployeeDictionary = new Dictionary<int, List<Employee>>();
            this._authorityLevel2EmployeeDictionary = new Dictionary<int, List<Employee>>();
            try
            {
                #region ロール（業務）設定テーブル用カラム生成

                // カテゴリコード
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.CategoryCodeColumn.ColumnName, typeof(int));
                this._activitySettingTable.Columns[this._settingSet.Setting.CategoryCodeColumn.ColumnName].DefaultValue = 0;
                // カテゴリ名称
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.CategoryNameColumn.ColumnName, typeof(string));
                this._activitySettingTable.Columns[this._settingSet.Setting.CategoryNameColumn.ColumnName].DefaultValue = string.Empty;
                this._activitySettingTable.Columns[this._settingSet.Setting.CategoryNameColumn.ColumnName].Caption = this._settingSet.Setting.CategoryNameColumn.Caption;
                // カテゴリ表示順位
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.CategoryDspOdrColumn.ColumnName, typeof(int));
                this._activitySettingTable.Columns[this._settingSet.Setting.CategoryDspOdrColumn.ColumnName].DefaultValue = 0;

                // プログラムID
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.PgIdColumn.ColumnName, typeof(string));
                this._activitySettingTable.Columns[this._settingSet.Setting.PgIdColumn.ColumnName].DefaultValue = string.Empty;
                // プログラム名称
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.PgNameColumn.ColumnName, typeof(string));
                this._activitySettingTable.Columns[this._settingSet.Setting.PgNameColumn.ColumnName].DefaultValue = string.Empty;
                this._activitySettingTable.Columns[this._settingSet.Setting.PgNameColumn.ColumnName].Caption = this._settingSet.Setting.PgNameColumn.Caption;
                // プログラム表示順位
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.PgDspOdrColumn.ColumnName, typeof(int));
                this._activitySettingTable.Columns[this._settingSet.Setting.PgDspOdrColumn.ColumnName].DefaultValue = 0;

                // オペレーションコード
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.OperationCodeColumn.ColumnName, typeof(int));
                this._activitySettingTable.Columns[this._settingSet.Setting.OperationCodeColumn.ColumnName].DefaultValue = 0;
                // オペレーション名称
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.OperationNameColumn.ColumnName, typeof(string));
                this._activitySettingTable.Columns[this._settingSet.Setting.OperationNameColumn.ColumnName].DefaultValue = string.Empty;
                this._activitySettingTable.Columns[this._settingSet.Setting.OperationNameColumn.ColumnName].Caption = this._settingSet.Setting.OperationNameColumn.Caption;
                // オペレーション表示順位
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.OperationDspOdrColumn.ColumnName, typeof(int));
                this._activitySettingTable.Columns[this._settingSet.Setting.OperationDspOdrColumn.ColumnName].DefaultValue = 0;

                foreach (JobTypeDataRow jobTypeDataRow in AuthorityLevelMasterDB.JobTypeTbl)
                {
                    // 業務毎のカラムを追加
                    this._activitySettingTable.Columns.Add(jobTypeDataRow.AuthorityLevelCd.ToString(), typeof(string));
                    this._activitySettingTable.Columns[jobTypeDataRow.AuthorityLevelCd.ToString()].DefaultValue = OperationLimitToStr(OperationLimit.EnableWithLog);
                    this._activitySettingTable.Columns[jobTypeDataRow.AuthorityLevelCd.ToString()].Caption = jobTypeDataRow.AuthorityLevelNm;
                }

                this._activitySettingTable.PrimaryKey = new DataColumn[]{
                this._activitySettingTable.Columns[this._settingSet.Setting.CategoryCodeColumn.ColumnName],
                this._activitySettingTable.Columns[this._settingSet.Setting.PgIdColumn.ColumnName],
                this._activitySettingTable.Columns[this._settingSet.Setting.OperationCodeColumn.ColumnName]};

                #endregion

                #region ロール（権限）設定テーブル用カラム生成

                // カテゴリコード
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.CategoryCodeColumn.ColumnName, typeof(int));
                this._authoritySettingTable.Columns[this._settingSet.Setting.CategoryCodeColumn.ColumnName].DefaultValue = 0;
                // カテゴリ名称
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.CategoryNameColumn.ColumnName, typeof(string));
                this._authoritySettingTable.Columns[this._settingSet.Setting.CategoryNameColumn.ColumnName].DefaultValue = string.Empty;
                this._authoritySettingTable.Columns[this._settingSet.Setting.CategoryNameColumn.ColumnName].Caption = this._settingSet.Setting.CategoryNameColumn.Caption;
                // カテゴリ表示順位
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.CategoryDspOdrColumn.ColumnName, typeof(int));
                this._authoritySettingTable.Columns[this._settingSet.Setting.CategoryDspOdrColumn.ColumnName].DefaultValue = 0;

                // プログラムID
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.PgIdColumn.ColumnName, typeof(string));
                this._authoritySettingTable.Columns[this._settingSet.Setting.PgIdColumn.ColumnName].DefaultValue = string.Empty;
                // プログラム名称
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.PgNameColumn.ColumnName, typeof(string));
                this._authoritySettingTable.Columns[this._settingSet.Setting.PgNameColumn.ColumnName].DefaultValue = string.Empty;
                this._authoritySettingTable.Columns[this._settingSet.Setting.PgNameColumn.ColumnName].Caption = this._settingSet.Setting.PgNameColumn.Caption;
                // プログラム表示順位
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.PgDspOdrColumn.ColumnName, typeof(int));
                this._authoritySettingTable.Columns[this._settingSet.Setting.PgDspOdrColumn.ColumnName].DefaultValue = 0;

                // オペレーションコード
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.OperationCodeColumn.ColumnName, typeof(int));
                this._authoritySettingTable.Columns[this._settingSet.Setting.OperationCodeColumn.ColumnName].DefaultValue = 0;
                // オペレーション名称
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.OperationNameColumn.ColumnName, typeof(string));
                this._authoritySettingTable.Columns[this._settingSet.Setting.OperationNameColumn.ColumnName].DefaultValue = string.Empty;
                this._authoritySettingTable.Columns[this._settingSet.Setting.OperationNameColumn.ColumnName].Caption = this._settingSet.Setting.OperationNameColumn.Caption;
                // オペレーション表示順位
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.OperationDspOdrColumn.ColumnName, typeof(int));
                this._authoritySettingTable.Columns[this._settingSet.Setting.OperationDspOdrColumn.ColumnName].DefaultValue = 0;

                DataView dv = AuthorityLevelMasterDB.EmploymentFormTbl.DefaultView;
                dv.Sort = AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelCd.ToString();

                foreach (DataRowView drv in dv)
                {
                    // 権限毎のカラムを追加
                    this._authoritySettingTable.Columns.Add(( (int)drv[AuthorityLevelMasterDB.EmploymentFormTbl.AuthorityLevelCdColumn.ColumnName] ).ToString(), typeof(string));
                    this._authoritySettingTable.Columns[( (int)drv[AuthorityLevelMasterDB.EmploymentFormTbl.AuthorityLevelCdColumn.ColumnName] ).ToString()].DefaultValue = OperationLimitToStr(OperationLimit.EnableWithLog);
                    this._authoritySettingTable.Columns[( (int)drv[AuthorityLevelMasterDB.EmploymentFormTbl.AuthorityLevelCdColumn.ColumnName] ).ToString()].Caption = (string)drv[AuthorityLevelMasterDB.EmploymentFormTbl.AuthorityLevelNmColumn.ColumnName];
                }

                this._authoritySettingTable.PrimaryKey = new DataColumn[]{
                this._authoritySettingTable.Columns[this._settingSet.Setting.CategoryCodeColumn.ColumnName],
                this._authoritySettingTable.Columns[this._settingSet.Setting.PgIdColumn.ColumnName],
                this._authoritySettingTable.Columns[this._settingSet.Setting.OperationCodeColumn.ColumnName]};
                #endregion

                #region 従業員設定用テーブル用カラム生成

                // カテゴリコード
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.CategoryCodeColumn.ColumnName, typeof(int));
                this._employeeSettingTable.Columns[this._settingSet.Setting.CategoryCodeColumn.ColumnName].DefaultValue = 0;

                // カテゴリ名称
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.CategoryNameColumn.ColumnName, typeof(string));
                this._employeeSettingTable.Columns[this._settingSet.Setting.CategoryNameColumn.ColumnName].DefaultValue = string.Empty;
                this._employeeSettingTable.Columns[this._settingSet.Setting.CategoryNameColumn.ColumnName].Caption = this._settingSet.Setting.CategoryNameColumn.Caption;
                // カテゴリ表示順位
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.CategoryDspOdrColumn.ColumnName, typeof(int));
                this._employeeSettingTable.Columns[this._settingSet.Setting.CategoryDspOdrColumn.ColumnName].DefaultValue = 0;

                // プログラムID
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.PgIdColumn.ColumnName, typeof(string));
                this._employeeSettingTable.Columns[this._settingSet.Setting.PgIdColumn.ColumnName].DefaultValue = string.Empty;
                // プログラム名称
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.PgNameColumn.ColumnName, typeof(string));
                this._employeeSettingTable.Columns[this._settingSet.Setting.PgNameColumn.ColumnName].DefaultValue = string.Empty;
                this._employeeSettingTable.Columns[this._settingSet.Setting.PgNameColumn.ColumnName].Caption = this._settingSet.Setting.PgNameColumn.Caption;
                // プログラム表示順位
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.PgDspOdrColumn.ColumnName, typeof(int));
                this._employeeSettingTable.Columns[this._settingSet.Setting.PgDspOdrColumn.ColumnName].DefaultValue = 0;

                // オペレーションコード
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.OperationCodeColumn.ColumnName, typeof(int));
                this._employeeSettingTable.Columns[this._settingSet.Setting.OperationCodeColumn.ColumnName].DefaultValue = 0;
                // オペレーション名称
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.OperationNameColumn.ColumnName, typeof(string));
                this._employeeSettingTable.Columns[this._settingSet.Setting.OperationNameColumn.ColumnName].DefaultValue = string.Empty;
                this._employeeSettingTable.Columns[this._settingSet.Setting.OperationNameColumn.ColumnName].Caption = this._settingSet.Setting.OperationNameColumn.Caption;
                // オペレーション表示順位
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.OperationDspOdrColumn.ColumnName, typeof(int));
                this._employeeSettingTable.Columns[this._settingSet.Setting.OperationDspOdrColumn.ColumnName].DefaultValue = 0;

                this._employeeSettingTable.PrimaryKey = new DataColumn[]{
                this._employeeSettingTable.Columns[this._settingSet.Setting.CategoryCodeColumn.ColumnName],
                this._employeeSettingTable.Columns[this._settingSet.Setting.PgIdColumn.ColumnName],
                this._employeeSettingTable.Columns[this._settingSet.Setting.OperationCodeColumn.ColumnName]};

                foreach (Employee employeeRecord in EmployeeMasterDB.RecordList)
                {
                    // 従業員毎のカラムを追加
                    this._employeeSettingTable.Columns.Add(employeeRecord.EmployeeCode, typeof(string));
                    this._employeeSettingTable.Columns[employeeRecord.EmployeeCode].DefaultValue = OperationLimitToStr(OperationLimit.EnableWithLog);
                    this._employeeSettingTable.Columns[employeeRecord.EmployeeCode].Caption = employeeRecord.Name.Trim();
                    if (!this._authorityLevel1EmployeeDictionary.ContainsKey(employeeRecord.AuthorityLevel1))
                    {
                        this._authorityLevel1EmployeeDictionary.Add(employeeRecord.AuthorityLevel1, new List<Employee>());
                    }
                    this._authorityLevel1EmployeeDictionary[employeeRecord.AuthorityLevel1].Add(employeeRecord);

                    if (!this._authorityLevel2EmployeeDictionary.ContainsKey(employeeRecord.AuthorityLevel2))
                    {
                        this._authorityLevel2EmployeeDictionary.Add(employeeRecord.AuthorityLevel2, new List<Employee>());
                    }
                    this._authorityLevel2EmployeeDictionary[employeeRecord.AuthorityLevel2].Add(employeeRecord);

                }
                #endregion

                #region カテゴリー毎のテーブル設定
                foreach (Operation operationMasterRecord in OperationMasterDB.RecordList)
                {
                    if (OperationLimitation.GetCategoryAttribute(operationMasterRecord.CategoryCode) == CategoryAttribute.Activity)
                    {
                        DataRow activityRow = this._activitySettingTable.NewRow();
                        activityRow[this._settingSet.Setting.CategoryCodeColumn.ColumnName] = operationMasterRecord.CategoryCode;
                        activityRow[this._settingSet.Setting.CategoryNameColumn.ColumnName] = operationMasterRecord.CategoryName;
                        activityRow[this._settingSet.Setting.PgIdColumn.ColumnName] = operationMasterRecord.PgId;
                        activityRow[this._settingSet.Setting.PgNameColumn.ColumnName] = operationMasterRecord.PgName;
                        activityRow[this._settingSet.Setting.OperationCodeColumn.ColumnName] = operationMasterRecord.OperationCode;
                        activityRow[this._settingSet.Setting.OperationNameColumn.ColumnName] = operationMasterRecord.OperationName;
                        // 2010/07/08 Add >>>
                        activityRow[this._settingSet.Setting.CategoryDspOdrColumn.ColumnName] = operationMasterRecord.CategoryDspOdr;
                        activityRow[this._settingSet.Setting.PgDspOdrColumn.ColumnName] = operationMasterRecord.PgDspOdr;
                        activityRow[this._settingSet.Setting.OperationDspOdrColumn.ColumnName] = operationMasterRecord.OperationDspOdr;
                        // 2010/07/08 Add <<<
                        this._activitySettingTable.Rows.Add(activityRow);
                    }
                    else if (OperationLimitation.GetCategoryAttribute(operationMasterRecord.CategoryCode) == CategoryAttribute.Authority)
                    {
                        DataRow authorityRow = this._authoritySettingTable.NewRow();
                        authorityRow[this._settingSet.Setting.CategoryCodeColumn.ColumnName] = operationMasterRecord.CategoryCode;
                        authorityRow[this._settingSet.Setting.CategoryNameColumn.ColumnName] = operationMasterRecord.CategoryName;
                        authorityRow[this._settingSet.Setting.PgIdColumn.ColumnName] = operationMasterRecord.PgId;
                        authorityRow[this._settingSet.Setting.PgNameColumn.ColumnName] = operationMasterRecord.PgName;
                        authorityRow[this._settingSet.Setting.OperationCodeColumn.ColumnName] = operationMasterRecord.OperationCode;
                        authorityRow[this._settingSet.Setting.OperationNameColumn.ColumnName] = operationMasterRecord.OperationName;
                        // 2010/07/08 Add >>>
                        authorityRow[this._settingSet.Setting.CategoryDspOdrColumn.ColumnName] = operationMasterRecord.CategoryDspOdr;
                        authorityRow[this._settingSet.Setting.PgDspOdrColumn.ColumnName] = operationMasterRecord.PgDspOdr;
                        authorityRow[this._settingSet.Setting.OperationDspOdrColumn.ColumnName] = operationMasterRecord.OperationDspOdr;
                        // 2010/07/08 Add <<<
                        this._authoritySettingTable.Rows.Add(authorityRow);
                    }

                    DataRow employeeRow = this._employeeSettingTable.NewRow();
                    employeeRow[this._settingSet.Setting.CategoryCodeColumn.ColumnName] = operationMasterRecord.CategoryCode;
                    employeeRow[this._settingSet.Setting.CategoryNameColumn.ColumnName] = operationMasterRecord.CategoryName;
                    employeeRow[this._settingSet.Setting.PgIdColumn.ColumnName] = operationMasterRecord.PgId;
                    employeeRow[this._settingSet.Setting.PgNameColumn.ColumnName] = operationMasterRecord.PgName;
                    employeeRow[this._settingSet.Setting.OperationCodeColumn.ColumnName] = operationMasterRecord.OperationCode;
                    employeeRow[this._settingSet.Setting.OperationNameColumn.ColumnName] = operationMasterRecord.OperationName;
                    // 2010/07/08 Add >>>
                    employeeRow[this._settingSet.Setting.CategoryDspOdrColumn.ColumnName] = operationMasterRecord.CategoryDspOdr;
                    employeeRow[this._settingSet.Setting.PgDspOdrColumn.ColumnName] = operationMasterRecord.PgDspOdr;
                    employeeRow[this._settingSet.Setting.OperationDspOdrColumn.ColumnName] = operationMasterRecord.OperationDspOdr;
                    // 2010/07/08 Add <<<
                    this._employeeSettingTable.Rows.Add(employeeRow);
                }
                #endregion

                // 各操作の設定を取得
                foreach (Operation operationMasterRecord in OperationMasterDB.RecordList)
                {
                    #region <職種別に設定/>

                    foreach (JobTypeDataRow jobTypeRow in AuthorityLevelMasterDB.JobTypeTbl)
                    {
                        OpeSttngDataRow[] opeSettingRows = OperationSettingMasterDB.GetRowsWhatIsJobType(
                            operationMasterRecord.CategoryCode,
                            operationMasterRecord.PgId,
                            operationMasterRecord.OperationCode,
                            jobTypeRow.AuthorityLevelCd
                        );
                        // オペレーション設定マスタDBに該当する職種の設定がない
                        if (opeSettingRows.Length.Equals(0))
                        {
                            OperationStWork operationSettingMasterRecord = new OperationStWork();
                            operationSettingMasterRecord.EnterpriseCode = OperationSettingMasterDB.EnterpriseCode;
                            operationSettingMasterRecord.OperationStDiv = (int)OperationStDivValue.AuthorityLevel1; // 職種
                            operationSettingMasterRecord.AuthorityLevel1 = jobTypeRow.AuthorityLevelCd;

                            SettingState defaultSettingStatus = new JobTypeSettingState(
                                operationMasterRecord,
                                jobTypeRow
                            );

                            AddSettengDataRow(operationMasterRecord, operationSettingMasterRecord, defaultSettingStatus);

                            if (this._activitySettingTable.Columns.Contains(jobTypeRow.AuthorityLevelCd.ToString()))
                            {
                                DataRow row = this.GetActivitySettingRow(operationMasterRecord.CategoryCode, operationMasterRecord.PgId, operationMasterRecord.OperationCode);
                                if (row != null)
                                {
                                    row[jobTypeRow.AuthorityLevelCd.ToString()] = OperationLimitToStr(defaultSettingStatus.OperationLimit);
                                }
                            }

                            continue;
                        }
                        // オペレーション設定マスタDBに該当する職種の設定がある
                        SettingState settingStatus = new JobTypeSettingState(operationMasterRecord, jobTypeRow);
                        AddSettengDataRow(operationMasterRecord, opeSettingRows[SINGLE_ROW], settingStatus);

                        if (this._activitySettingTable.Columns.Contains(jobTypeRow.AuthorityLevelCd.ToString()))
                        {
                            DataRow row = this._activitySettingTable.Rows.Find(new object[] { operationMasterRecord.CategoryCode, operationMasterRecord.PgId, operationMasterRecord.OperationCode });
                            if (row != null)
                            {
                                row[jobTypeRow.AuthorityLevelCd.ToString()] = OperationLimitToStr(settingStatus.OperationLimit);
                            }
                        }
                    }

                    #endregion  // <職種別に設定/>

                    #region <雇用形態別に設定/>

                    foreach (JobTypeDataRow employmentFormRow in AuthorityLevelMasterDB.EmploymentFormTbl)
                    {
                        OpeSttngDataRow[] opeSettingRows = OperationSettingMasterDB.GetRowsWhatIsEmploymentForm(
                            operationMasterRecord.CategoryCode,
                            operationMasterRecord.PgId,
                            operationMasterRecord.OperationCode,
                            employmentFormRow.AuthorityLevelCd
                        );
                        // オペレーション設定マスタDBに該当する雇用形態の設定がない
                        if (opeSettingRows.Length.Equals(0))
                        {
                            OperationStWork operationSettingMasterRecord = new OperationStWork();
                            operationSettingMasterRecord.EnterpriseCode = OperationSettingMasterDB.EnterpriseCode;
                            operationSettingMasterRecord.OperationStDiv = (int)OperationStDivValue.AuthorityLevel2; // 雇用形態
                            operationSettingMasterRecord.AuthorityLevel2 = employmentFormRow.AuthorityLevelCd;

                            SettingState defaultSettingStatus = new EmploymentFormSettingState(
                                operationMasterRecord,
                                employmentFormRow
                            );

                            AddSettengDataRow(operationMasterRecord, operationSettingMasterRecord, defaultSettingStatus);

                            if (this._authoritySettingTable.Columns.Contains(employmentFormRow.AuthorityLevelCd.ToString()))
                            {
                                DataRow row = this.GetAuthoritySettingRow(operationMasterRecord.CategoryCode, operationMasterRecord.PgId, operationMasterRecord.OperationCode);
                                if (row != null)
                                {
                                    row[employmentFormRow.AuthorityLevelCd.ToString()] = OperationLimitToStr(defaultSettingStatus.OperationLimit);
                                }
                            }

                            continue;
                        }
                        // オペレーション設定マスタDBに該当する職種の設定がある
                        SettingState settingStatus = new EmploymentFormSettingState(operationMasterRecord, employmentFormRow);
                        AddSettengDataRow(operationMasterRecord, opeSettingRows[SINGLE_ROW], settingStatus);

                        if (this._authoritySettingTable.Columns.Contains(employmentFormRow.AuthorityLevelCd.ToString()))
                        {
                            DataRow row = this.GetAuthoritySettingRow(operationMasterRecord.CategoryCode, operationMasterRecord.PgId, operationMasterRecord.OperationCode);
                            if (row != null)
                            {
                                row[employmentFormRow.AuthorityLevelCd.ToString()] = OperationLimitToStr(settingStatus.OperationLimit);
                            }
                        }
                    }

                    #endregion  // <雇用形態別に設定/>

                    #region <従業員別に設定/>

                    foreach (Employee employeeRecord in EmployeeMasterDB.RecordList)
                    {
                        OpeSttngDataRow[] opeSettingRows = OperationSettingMasterDB.GetRowsWhatIsEmployeeCode(
                            operationMasterRecord.CategoryCode,
                            operationMasterRecord.PgId,
                            operationMasterRecord.OperationCode,
                            employeeRecord.EmployeeCode
                        );
                        // オペレーション設定マスタDBに該当する従業員の設定がない
                        if (opeSettingRows.Length.Equals(0))
                        {
                            OperationStWork operationSettingMasterRecord = new OperationStWork();
                            operationSettingMasterRecord.EnterpriseCode = OperationSettingMasterDB.EnterpriseCode;
                            operationSettingMasterRecord.OperationStDiv = (int)OperationStDivValue.EmployeeCode;    // 従業員
                            operationSettingMasterRecord.EmployeeCode = employeeRecord.EmployeeCode;

                            SettingState defaultSettingStatus = new EmployeeSettingState(operationMasterRecord, employeeRecord);
                            AddSettengDataRow(operationMasterRecord, operationSettingMasterRecord, defaultSettingStatus);

                            continue;
                        }
                        // オペレーション設定マスタDBに該当する従業員の設定がある
                        SettingState settingStatus = new EmployeeSettingState(operationMasterRecord, employeeRecord);
                        AddSettengDataRow(operationMasterRecord, opeSettingRows[SINGLE_ROW], settingStatus);
                    }

                    #endregion  // <従業員別に設定/>
                }

                #region 業務権限一覧用テーブルの設定
                // 業務ディクショナリ
                Dictionary<int, string> activityDictionary = new Dictionary<int, string>();
                // 権限ディクショナリ
                Dictionary<int, string> authorityDictionary = new Dictionary<int, string>();

                foreach (Employee employeeRecord in EmployeeMasterDB.RecordList)
                {
                    #region 業務の追加
                    if (!activityDictionary.ContainsKey(employeeRecord.AuthorityLevel1))
                    {
                        JobTypeDataRow[] jobTypeDataRows = (JobTypeDataRow[])AuthorityLevelMasterDB.JobTypeTbl.Select(string.Format("{0}='{1}'", AuthorityLevelMasterDB.JobTypeTbl.AuthorityLevelCdColumn.ColumnName, employeeRecord.AuthorityLevel1));
                        if (( jobTypeDataRows != null ) && ( jobTypeDataRows.Length > 0 ))
                        {
                            activityDictionary.Add(jobTypeDataRows[0].AuthorityLevelCd, jobTypeDataRows[0].AuthorityLevelNm);
                        }
                    }
                    if (activityDictionary.ContainsKey(employeeRecord.AuthorityLevel1))
                    {
                        SettingDataSet.EmployeeAuthorityRow employeeAuthorityRow = SettingSet.EmployeeAuthority.NewEmployeeAuthorityRow();

                        employeeAuthorityRow.AuthorityLevelDiv = (int)AuthorityLevelMasterDataSet.AuthorityLevelDiv.JobType;
                        employeeAuthorityRow.AuthorityLevelDivName = GetAuthorityLevelName(AuthorityLevelMasterDataSet.AuthorityLevelDiv.JobType);
                        employeeAuthorityRow.AuthorityLevel = employeeRecord.AuthorityLevel1;
                        employeeAuthorityRow.AuthorityLevelName = activityDictionary[employeeRecord.AuthorityLevel1];
                        employeeAuthorityRow.EmployeeCode = employeeRecord.EmployeeCode;
                        employeeAuthorityRow.EmployeeName = employeeRecord.Name;
                        employeeAuthorityRow.BelongSectionCode = employeeRecord.BelongSectionCode;
                        employeeAuthorityRow.BelongSectionNm = employeeRecord.BelongSectionName;    // FIXME:所属拠点名がない？
                        SettingSet.EmployeeAuthority.AddEmployeeAuthorityRow(employeeAuthorityRow);
                    }
                    #endregion

                    #region 権限の追加
                    if (!authorityDictionary.ContainsKey(employeeRecord.AuthorityLevel2))
                    {
                        JobTypeDataRow[] jobTypeDataRows = (JobTypeDataRow[])AuthorityLevelMasterDB.EmploymentFormTbl.Select(string.Format("{0}='{1}'", AuthorityLevelMasterDB.JobTypeTbl.AuthorityLevelCdColumn.ColumnName, employeeRecord.AuthorityLevel2));
                        if (( jobTypeDataRows != null ) && ( jobTypeDataRows.Length > 0 ))
                        {
                            authorityDictionary.Add(jobTypeDataRows[0].AuthorityLevelCd, jobTypeDataRows[0].AuthorityLevelNm);
                        }
                    }
                    if (authorityDictionary.ContainsKey(employeeRecord.AuthorityLevel2))
                    {
                        SettingDataSet.EmployeeAuthorityRow employeeAuthorityRow = SettingSet.EmployeeAuthority.NewEmployeeAuthorityRow();

                        employeeAuthorityRow.AuthorityLevelDiv = (int)AuthorityLevelMasterDataSet.AuthorityLevelDiv.EmploymentForm;
                        employeeAuthorityRow.AuthorityLevelDivName = GetAuthorityLevelName(AuthorityLevelMasterDataSet.AuthorityLevelDiv.EmploymentForm);
                        employeeAuthorityRow.AuthorityLevel = employeeRecord.AuthorityLevel2;
                        employeeAuthorityRow.AuthorityLevelName = authorityDictionary[employeeRecord.AuthorityLevel2];
                        employeeAuthorityRow.EmployeeCode = employeeRecord.EmployeeCode;
                        employeeAuthorityRow.EmployeeName = employeeRecord.Name;
                        employeeAuthorityRow.BelongSectionCode = employeeRecord.BelongSectionCode;
                        employeeAuthorityRow.BelongSectionNm = employeeRecord.BelongSectionName;
                        SettingSet.EmployeeAuthority.AddEmployeeAuthorityRow(employeeAuthorityRow);
                    }
                    #endregion
                }

                #endregion

                #region 従業員別の設定から従業員権限一覧へのデータ反映

                DataView dataView = new DataView(SettingSet.Setting);
                foreach (DataRow row in this._employeeSettingTable.Rows)
                {

                    StringBuilder filter = new StringBuilder();
                    filter.Append(this._settingSet.Setting.CategoryCodeColumn.ColumnName);
                    filter.Append(ADOUtil.EQ);
                    filter.Append(row[this._settingSet.Setting.CategoryCodeColumn.ColumnName]);
                    filter.Append(ADOUtil.AND);
                    filter.Append(this._settingSet.Setting.PgIdColumn.ColumnName);
                    filter.Append(ADOUtil.EQ);
                    filter.Append(ADOUtil.GetString((string)row[this._settingSet.Setting.PgIdColumn.ColumnName]));
                    filter.Append(ADOUtil.AND);
                    filter.Append(this._settingSet.Setting.OperationCodeColumn.ColumnName);
                    filter.Append(ADOUtil.EQ);
                    filter.Append(row[this._settingSet.Setting.OperationCodeColumn.ColumnName]);
                    filter.Append(ADOUtil.AND);
                    filter.Append(this._settingSet.Setting.EmployeeCodeColumn.ColumnName);
                    filter.Append(ADOUtil.NOT);
                    filter.Append(ADOUtil.GetString(string.Empty));

                    dataView.RowFilter = filter.ToString();

                    foreach (DataRowView drv in dataView)
                    {
                        string columnName = (string)drv[this._settingSet.Setting.EmployeeCodeColumn.ColumnName];
                        if (this._employeeSettingTable.Columns.Contains(columnName))
                        {
                            row[columnName] = OperationLimitToStr((OperationLimit)( (int)drv[this._settingSet.Setting.OperationLimitColumn.ColumnName] ));
                            //row[columnName] = ( (int)drv[this._settingSet.Setting.OperationLimitColumn.ColumnName] == (int)OperationLimit.Disable ) ? "×" : "○";
                        }
                    }
                }
                

                #endregion

            }
            finally
            {
                //SettingSet.Setting.EndLoadData();
                SettingSet.EmployeeAuthority.EndLoadData();
                this._activitySettingTable.EndLoadData();
                this._authoritySettingTable.EndLoadData();
                this._employeeSettingTable.EndLoadData();
            }

        }

        #region <操作権限設定行の追加/>

        /// <summary>
        /// 操作権限設定行を追加します。
        /// </summary>
        /// <param name="operationMasterRecord">オペレーションマスタレコード</param>
        /// <param name="operationSettingMasterRecord">オペレーション設定マスタレコード</param>
        /// <param name="settingStatus">設定状態</param>
        private void AddSettengDataRow(
            Operation operationMasterRecord,
            OperationStWork operationSettingMasterRecord,
            SettingState settingStatus
        )
        {
            long index = SettingSet.Setting.Count + 1;  // インデックスは1～   
            SettingSet.Setting.AddSettingRow(
                index,
                DateTimeUtil.ToDateTime(operationMasterRecord.OfferDate),
                operationMasterRecord.CategoryCode,
                operationMasterRecord.CategoryName,
                operationMasterRecord.CategoryDspOdr,
                operationMasterRecord.PgId,
                operationMasterRecord.PgName,
                operationMasterRecord.PgDspOdr,
                operationMasterRecord.OperationCode,
                operationMasterRecord.OperationName,
                operationMasterRecord.OperationDspOdr,

                operationSettingMasterRecord.CreateDateTime,
                operationSettingMasterRecord.UpdateDateTime,
                operationSettingMasterRecord.EnterpriseCode,
                operationSettingMasterRecord.FileHeaderGuid,
                operationSettingMasterRecord.UpdEmployeeCode,
                operationSettingMasterRecord.UpdAssemblyId1,
                operationSettingMasterRecord.UpdAssemblyId2,
                operationSettingMasterRecord.LogicalDeleteCode,
                operationSettingMasterRecord.OperationStDiv,
                operationSettingMasterRecord.AuthorityLevel1,
                operationSettingMasterRecord.AuthorityLevel2,
                operationSettingMasterRecord.EmployeeCode,
                operationSettingMasterRecord.LimitDiv,
                operationSettingMasterRecord.ApplyStartDate,
                operationSettingMasterRecord.ApplyEndDate,

                settingStatus.Admission,
                string.Empty,
                //settingStatus.SettingApp,
                (int)settingStatus.OperationLimit,
                settingStatus.Limitation
            );
        }

        /// <summary>
        /// 操作権限設定行を追加します。
        /// </summary>
        /// <param name="operationMasterRecord">オペレーションマスタレコード</param>
        /// <param name="operationSettingMasterRow">オペレーション設定マスタ行</param>
        /// <param name="settingStatus">設定状態</param>
        private void AddSettengDataRow(
            Operation operationMasterRecord,
            OpeSttngDataRow operationSettingMasterRow,
            SettingState settingStatus
        )
        {
            long index = SettingSet.Setting.Count + 1;  // インデックスは1～
            SettingSet.Setting.AddSettingRow(
                index,
                DateTimeUtil.ToDateTime(operationMasterRecord.OfferDate),
                operationMasterRecord.CategoryCode,
                operationMasterRecord.CategoryName,
                operationMasterRecord.CategoryDspOdr,
                operationMasterRecord.PgId,
                operationMasterRecord.PgName,
                operationMasterRecord.PgDspOdr,
                operationMasterRecord.OperationCode,
                operationMasterRecord.OperationName,
                operationMasterRecord.OperationDspOdr,

                operationSettingMasterRow.CreateDateTime,
                operationSettingMasterRow.UpdateDateTime,
                operationSettingMasterRow.EnterpriseCode,
                operationSettingMasterRow.FileHeaderGuid,
                operationSettingMasterRow.UpdEmployeeCode,
                operationSettingMasterRow.UpdAssemblyId1,
                operationSettingMasterRow.UpdAssemblyId2,
                operationSettingMasterRow.LogicalDeleteCode,
                operationSettingMasterRow.OperationStDiv,
                operationSettingMasterRow.AuthorityLevel1,
                operationSettingMasterRow.AuthorityLevel2,
                operationSettingMasterRow.EmployeeCode,
                operationSettingMasterRow.LimitDiv,
                operationSettingMasterRow.ApplyStartDate,
                operationSettingMasterRow.ApplyEndDate,

                settingStatus.Admission,
                string.Empty,
                //settingStatus.SettingApp,
                (int)settingStatus.OperationLimit,
                settingStatus.Limitation
            );
        }

        #endregion  // <操作権限設定行の追加/>

        #endregion  // <操作権限設定のUI用データセット/>

        #region <操作権限一覧表示のUI用データテーブル/>

        /// <summary>
        /// 操作権限一覧表示のUI用データテーブルを取得します。
        /// </summary>
        /// <value>操作権限一覧表示のUI用データテーブル</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public SettingDataSet.SettingDataTable ViewTable
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return (SettingDataSet.SettingDataTable)SettingSet.Setting;
            }
        }

        #endregion  // <操作権限一覧表示のUI用データテーブル/>

        /// <summary>
        /// 保持しているデータセットをリセットします。
        /// </summary>
        public void ResetDataSet()
        {
            if (_authorityLevelMasterDB != null)
            {
                _authorityLevelMasterDB.Dispose();
                _authorityLevelMasterDB = null;
            }
            if (_employeeMasterDB != null)
            {
                _employeeMasterDB.Dispose();
                _employeeMasterDB = null;
            }
            if (_operationMasterDB != null)
            {
                _operationMasterDB.Dispose();
                _operationMasterDB = null;
            }
            if (_operationSettingMasterDB != null)
            {
                _operationSettingMasterDB.Dispose();
                _operationSettingMasterDB = null;
            }
            if (_settingSet != null)
            {
                _settingSet.Dispose();
                _settingSet = null;
            }
        }

        #region 業務テーブル選択値変更処理

        /// <summary>
        /// 業務設定テーブル選択処理
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <param name="pgId"></param>
        /// <param name="operationCode"></param>
        /// <param name="authorityLevelCd"></param>
        /// <param name="operationLimit"></param>
        /// <returns></returns>
        public bool ActivitySettingSelectValue(int categoryCode, string pgId, int operationCode, string authorityLevelCd, OperationLimit operationLimit)
        {
            bool ret = false;
            if (this._activitySettingTable.Columns.Contains(authorityLevelCd))
            {
                DataRow foundRow = this.GetActivitySettingRow(categoryCode, pgId, operationCode);
                DataRow allSettingRow = this.GetActivitySettingRow(categoryCode, EntityUtil.ALL_PG_ID, operationCode);

                if (foundRow != null)
                {
                    if (( allSettingRow != null ) && ( foundRow != allSettingRow ) && ( StrToOperationLimit((string)allSettingRow[authorityLevelCd]) == OperationLimit.Disable ))
                    {
                    }
                    else
                    {
                        foundRow[authorityLevelCd] = OperationLimitToStr(operationLimit);
                        // 書き込み用DBへ反映する
                        SetSettingSetTable((int)OperationStDivValue.AuthorityLevel1, categoryCode, pgId, operationCode, TStrConv.StrToIntDef(authorityLevelCd.Trim(), 0), 0, string.Empty, (int)operationLimit);

                        // 全体設定の場合は、対象カテゴリの設定をDBからの値に戻す
                        if (pgId == EntityUtil.ALL_PG_ID)
                        {
                            StringBuilder filter = new StringBuilder();
                            filter.Append(this._settingSet.Setting.CategoryCodeColumn.ColumnName);
                            filter.Append(ADOUtil.EQ);
                            filter.Append(categoryCode);
                            filter.Append(ADOUtil.AND);
                            filter.Append(this._settingSet.Setting.PgIdColumn.ColumnName);
                            filter.Append(ADOUtil.NOT);
                            filter.Append(ADOUtil.GetString(pgId));
                            filter.Append(ADOUtil.AND);
                            filter.Append(this._settingSet.Setting.OperationCodeColumn.ColumnName);
                            filter.Append(ADOUtil.EQ);
                            filter.Append(operationCode);

                            DataRow[] rows = this._activitySettingTable.Select(filter.ToString());
                            if (( rows != null ) && ( rows.Length > 0 ))
                            {
                                foreach (DataRow row in rows)
                                {
                                    if (operationLimit == OperationLimit.Disable)
                                    {
                                        row[authorityLevelCd] = OperationLimitToStr(operationLimit);
                                    }
                                    else
                                    {
                                        // 修正行のみDBの設定値を取得する
                                        SettingDataSet.SettingRow settingRow = this.GetSettingRow((int)OperationStDivValue.AuthorityLevel1, categoryCode, (string)row[this._settingSet.Setting.PgIdColumn.ColumnName], operationCode, TStrConv.StrToIntDef(authorityLevelCd.Trim(), 0), 0, string.Empty);

                                        if (( settingRow != null ) && ( settingRow.CreateDateTime != DateTime.MinValue ))
                                        {
                                            row[authorityLevelCd] = OperationLimitToStr((OperationLimit)settingRow.OperationLimit);
                                        }
                                        else
                                        {
                                            row[authorityLevelCd] = OperationLimitToStr(OperationLimit.EnableWithLog);
                                            SetSettingSetTable((int)OperationStDivValue.AuthorityLevel1, categoryCode, (string)row[this._settingSet.Setting.PgIdColumn.ColumnName], operationCode, TStrConv.StrToIntDef(authorityLevelCd.Trim(), 0), 0, string.Empty, (int)OperationLimit.EnableWithLog);
                                        }
                                    }
                                }
                            }
                        }
                        ret = true;
                    }

                }
            }

            return ret;
        }

        #endregion


        #region 権限テーブル選択値変更処理

        /// <summary>
        /// 権限テーブル選択処理
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <param name="pgId"></param>
        /// <param name="operationCode"></param>
        /// <param name="authorityLevelCd"></param>
        /// <param name="operationLimit"></param>
        /// <returns></returns>
        public bool AuthoritySettingSelectValue(int categoryCode, string pgId, int operationCode, string authorityLevelCd, OperationLimit operationLimit)
        {
            bool ret = false;
            if (this._authoritySettingTable.Columns.Contains(authorityLevelCd))
            {
                DataRow foundRow = this.GetAuthoritySettingRow(categoryCode, pgId, operationCode);
                DataRow allSettingRow = this.GetAuthoritySettingRow(categoryCode, EntityUtil.ALL_PG_ID, operationCode);

                if (foundRow != null)
                {
                    if (( allSettingRow != null ) && ( foundRow != allSettingRow ) && ( StrToOperationLimit((string)allSettingRow[authorityLevelCd]) == OperationLimit.Disable ))
                    {
                    }
                    else
                    {
                        foundRow[authorityLevelCd] = OperationLimitToStr(operationLimit);
                        // 書き込み用DBへ反映する
                        SetSettingSetTable((int)OperationStDivValue.AuthorityLevel2, categoryCode, pgId, operationCode, 0, TStrConv.StrToIntDef(authorityLevelCd.Trim(), 0), string.Empty, (int)operationLimit);

                        // 全体設定の場合は、対象カテゴリの設定をDBからの値に戻す
                        if (pgId == EntityUtil.ALL_PG_ID)
                        {
                            StringBuilder filter = new StringBuilder();
                            filter.Append(this._settingSet.Setting.CategoryCodeColumn.ColumnName);
                            filter.Append(ADOUtil.EQ);
                            filter.Append(categoryCode);
                            filter.Append(ADOUtil.AND);
                            filter.Append(this._settingSet.Setting.PgIdColumn.ColumnName);
                            filter.Append(ADOUtil.NOT);
                            filter.Append(ADOUtil.GetString(pgId));
                            filter.Append(ADOUtil.AND);
                            filter.Append(this._settingSet.Setting.OperationCodeColumn.ColumnName);
                            filter.Append(ADOUtil.EQ);
                            filter.Append(operationCode);

                            DataRow[] rows = this._authoritySettingTable.Select(filter.ToString());
                            if (( rows != null ) && ( rows.Length > 0 ))
                            {
                                foreach (DataRow row in rows)
                                {
                                    if (operationLimit == OperationLimit.Disable)
                                    {
                                        row[authorityLevelCd] = OperationLimitToStr(operationLimit);
                                    }
                                    else
                                    {
                                        // 修正行のみDBの設定値を取得する
                                        SettingDataSet.SettingRow settingRow = this.GetSettingRow((int)OperationStDivValue.AuthorityLevel2, categoryCode, (string)row[this._settingSet.Setting.PgIdColumn.ColumnName], operationCode, 0, TStrConv.StrToIntDef(authorityLevelCd.Trim(), 0), string.Empty);
                                        if (( settingRow != null ) && ( settingRow.CreateDateTime != DateTime.MinValue ))
                                        {
                                            row[authorityLevelCd] = OperationLimitToStr((OperationLimit)settingRow.OperationLimit);
                                        }
                                        else
                                        {
                                            row[authorityLevelCd] = OperationLimitToStr(OperationLimit.EnableWithLog);
                                            SetSettingSetTable((int)OperationStDivValue.AuthorityLevel2, categoryCode, (string)row[this._settingSet.Setting.PgIdColumn.ColumnName], operationCode, 0, TStrConv.StrToIntDef(authorityLevelCd.Trim(), 0), string.Empty, (int)OperationLimit.EnableWithLog);
                                        }
                                    }
                                }
                            }
                        }
                        ret = true;
                    }

                }
            }

            return ret;
        }
        #endregion



        #region 従業員テーブル選択値変更処理

        /// <summary>
        /// 従業員テーブル選択値変更処理
        /// </summary>
        /// <param name="categoryCode">カテゴリーコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="operationLimit"></param>
        /// <returns></returns>
        public bool EmployeeSettingSelectValue(int categoryCode, string pgId, int operationCode, string employeeCode, OperationLimit operationLimit)
        {
            bool ret = false;
            if (this._employeeSettingTable.Columns.Contains(employeeCode))
            {
                Employee employee = this._employeeMasterDB.FindRecord(employeeCode);
                if (employee != null)
                {
                    // カテゴリーコードに従って上位設定を取得する
                    OperationLimit highRankOperationLimit = this.GetHighRankOperationLimit(categoryCode, pgId, operationCode, employee);

                    DataRow foundRow = this.GetEmployeeSettingRow(categoryCode, pgId, operationCode);
                    DataRow allSettingRow = this.GetEmployeeSettingRow(categoryCode, string.Empty, operationCode);

                    if (foundRow != null)
                    {
                        // 上位設定が「不可」の場合は「不可」を設定
                        if (highRankOperationLimit == OperationLimit.Disable)
                        {
                            foundRow[employeeCode] = OperationLimitToStr(OperationLimit.Disable);
                        }
                        // 対象行が全体設定以外で、全体設定が「不可」の場合は「不可」を設定
                        else if (( allSettingRow != null ) && ( foundRow != allSettingRow ) && ( StrToOperationLimit((string)allSettingRow[employeeCode]) == OperationLimit.Disable ))
                        {
                            foundRow[employeeCode] = OperationLimitToStr(OperationLimit.Disable);
                        }
                        else
                        {
                            foundRow[employeeCode] = OperationLimitToStr(operationLimit);

                            // 書き込み用DBへ反映する
                            SetSettingSetTable((int)OperationStDivValue.EmployeeCode, categoryCode, pgId, operationCode, 0, 0, employee.EmployeeCode, (int)operationLimit);

                            // 全体設定を変更した場合は、対象カテゴリを全て変更する
                            if (string.IsNullOrEmpty(pgId))
                            {
                                StringBuilder filter = new StringBuilder();
                                filter.Append(this._settingSet.Setting.CategoryCodeColumn.ColumnName);
                                filter.Append(ADOUtil.EQ);
                                filter.Append(categoryCode);
                                filter.Append(ADOUtil.AND);
                                filter.Append(this._settingSet.Setting.PgIdColumn.ColumnName);
                                filter.Append(ADOUtil.NOT);
                                filter.Append(ADOUtil.GetString(pgId));
                                filter.Append(ADOUtil.AND);
                                filter.Append(this._settingSet.Setting.OperationCodeColumn.ColumnName);
                                filter.Append(ADOUtil.EQ);
                                filter.Append(operationCode);

                                DataRow[] rows = this._employeeSettingTable.Select(filter.ToString());
                                if (( rows != null ) && ( rows.Length > 0 ))
                                {
                                    foreach (DataRow row in rows)
                                    {
                                        // 上位設定を取得
                                        highRankOperationLimit = this.GetHighRankOperationLimit((int)row[this._settingSet.Setting.CategoryCodeColumn.ColumnName], (string)row[this._settingSet.Setting.PgIdColumn.ColumnName], (int)row[this._settingSet.Setting.OperationCodeColumn.ColumnName], employee);

                                        if (highRankOperationLimit != OperationLimit.Disable)
                                        {
                                            if (operationLimit == OperationLimit.Disable)
                                            {
                                                row[employeeCode] = OperationLimitToStr(operationLimit);
                                            }
                                            else
                                            {
                                                // 上位設定で「不可」でなければ、DBからの値を復元する
                                                SettingDataSet.SettingRow settingRow = GetSettingRow((int)OperationStDivValue.EmployeeCode, categoryCode, (string)row[this._settingSet.Setting.PgIdColumn.ColumnName], operationCode, 0, 0, employee.EmployeeCode);
                                                if (( settingRow != null ) && ( settingRow.CreateDateTime != DateTime.MinValue ))
                                                {
                                                    row[employeeCode] = OperationLimitToStr((OperationLimit)settingRow.OperationLimit);
                                                }
                                                else
                                                {
                                                    row[employeeCode] = OperationLimitToStr(OperationLimit.EnableWithLog);
                                                    SetSettingSetTable((int)OperationStDivValue.EmployeeCode, categoryCode, (string)row[this._settingSet.Setting.PgIdColumn.ColumnName], operationCode, 0, 0, employee.EmployeeCode, (int)OperationLimit.EnableWithLog);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            ret = true;
                        }

                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// 従業員テーブル選択値変更処理
        /// </summary>
        /// <param name="categoryCode">カテゴリーコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns></returns>
        public bool EmployeeSettingRowSelectChange(int categoryCode, string pgId, int operationCode, string employeeCode)
        {
            bool ret = false;
            if (this._employeeSettingTable.Columns.Contains(employeeCode))
            {
                Employee employee = this._employeeMasterDB.FindRecord(employeeCode);
                if (employee != null)
                {
                    // カテゴリーコードに従って上位設定を取得する
                    OperationLimit highRankOperationLimit = this.GetHighRankOperationLimit(categoryCode, pgId, operationCode, employee);

                    DataRow foundRow = this.GetEmployeeSettingRow(categoryCode, pgId, operationCode);
                    DataRow allSettingRow = this.GetEmployeeSettingRow(categoryCode, string.Empty, operationCode);

                    if (foundRow != null)
                    {
                        if (highRankOperationLimit == OperationLimit.Disable)
                        {
                            foundRow[employeeCode] = OperationLimitToStr(OperationLimit.Disable);
                        }
                        else if (( allSettingRow != null ) && ( foundRow != allSettingRow ) && ( ( (string)allSettingRow[employeeCode] ) == "×" ))
                        {
                            foundRow[employeeCode] = OperationLimitToStr(OperationLimit.Disable);
                        }
                        else
                        {
                            // 現時点の操作権限を取得
                            OperationLimit operationLimit = StrToOperationLimit((string)foundRow[employeeCode]);
                            operationLimit = GetNextOpertaionLimit(operationLimit);
                            foundRow[employeeCode] = OperationLimitToStr(operationLimit);

                            // 書き込み用DBへ反映する
                            SetSettingSetTable((int)OperationStDivValue.EmployeeCode, categoryCode, pgId, operationCode, 0, 0, employee.EmployeeCode, (int)operationLimit);

                            // 全体設定を変更した場合は、対象カテゴリを全て変更する
                            if (string.IsNullOrEmpty(pgId))
                            {
                                StringBuilder filter = new StringBuilder();
                                filter.Append(this._settingSet.Setting.CategoryCodeColumn.ColumnName);
                                filter.Append(ADOUtil.EQ);
                                filter.Append(categoryCode);
                                filter.Append(ADOUtil.AND);
                                filter.Append(this._settingSet.Setting.PgIdColumn.ColumnName);
                                filter.Append(ADOUtil.NOT);
                                filter.Append(ADOUtil.GetString(pgId));
                                filter.Append(ADOUtil.AND);
                                filter.Append(this._settingSet.Setting.OperationCodeColumn.ColumnName);
                                filter.Append(ADOUtil.EQ);
                                filter.Append(operationCode);

                                DataRow[] rows = this._employeeSettingTable.Select(filter.ToString());
                                if (( rows != null ) && ( rows.Length > 0 ))
                                {
                                    foreach (DataRow row in rows)
                                    {
                                        // 上位設定を取得
                                        highRankOperationLimit = this.GetHighRankOperationLimit((int)row[this._settingSet.Setting.CategoryCodeColumn.ColumnName], (string)row[this._settingSet.Setting.PgIdColumn.ColumnName], (int)row[this._settingSet.Setting.OperationCodeColumn.ColumnName], employee);

                                        if (highRankOperationLimit != OperationLimit.Disable)
                                        {
                                            if (operationLimit == OperationLimit.Disable)
                                            {
                                                row[employeeCode] = OperationLimitToStr(operationLimit);
                                            }
                                            else
                                            {
                                                // 上位設定で「不可」でなければ、DBからの値を復元する
                                                SettingDataSet.SettingRow settingRow = GetSettingRow((int)OperationStDivValue.EmployeeCode, categoryCode, (string)row[this._settingSet.Setting.PgIdColumn.ColumnName], operationCode, 0, 0, employee.EmployeeCode);
                                                if (settingRow != null)
                                                {
                                                    row[employeeCode] = OperationLimitToStr((OperationLimit)settingRow.OperationLimit);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            ret = true;
                        }

                    }
                }
            }

            return ret;
        }

        #endregion


        #region <DB書き込み用データテーブルから行取得/>

        /// <summary>
        /// DB書き込み用データテーブルから行取得
        /// </summary>
        /// <param name="operationStDiv"></param>
        /// <param name="categoryCode"></param>
        /// <param name="pgId"></param>
        /// <param name="operationCode"></param>
        /// <param name="authorityLebel1"></param>
        /// <param name="authorityLebel2"></param>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        private SettingDataSet.SettingRow GetSettingRow(int operationStDiv, int categoryCode, string pgId, int operationCode, int authorityLebel1, int authorityLebel2, string employeeCode)
        {
            StringBuilder filter = new StringBuilder();
            filter.Append(this._settingSet.Setting.OperationStDivColumn.ColumnName);
            filter.Append(ADOUtil.EQ);
            filter.Append(operationStDiv);
            filter.Append(ADOUtil.AND);
            filter.Append(this._settingSet.Setting.CategoryCodeColumn.ColumnName);
            filter.Append(ADOUtil.EQ);
            filter.Append(categoryCode);
            filter.Append(ADOUtil.AND);
            filter.Append(this._settingSet.Setting.PgIdColumn.ColumnName);
            filter.Append(ADOUtil.EQ);
            filter.Append(ADOUtil.GetString(pgId));
            filter.Append(ADOUtil.AND);
            filter.Append(this._settingSet.Setting.OperationCodeColumn.ColumnName);
            filter.Append(ADOUtil.EQ);
            filter.Append(operationCode);
            filter.Append(ADOUtil.AND);
            filter.Append(this._settingSet.Setting.AuthorityLevel1Column.ColumnName);
            filter.Append(ADOUtil.EQ);
            filter.Append(authorityLebel1);
            filter.Append(ADOUtil.AND);
            filter.Append(this._settingSet.Setting.AuthorityLevel2Column.ColumnName);
            filter.Append(ADOUtil.EQ);
            filter.Append(authorityLebel2);
            filter.Append(ADOUtil.AND);
            filter.Append(this._settingSet.Setting.EmployeeCodeColumn.ColumnName);
            filter.Append(ADOUtil.EQ);
            filter.Append(ADOUtil.GetString(employeeCode));

            SettingDataSet.SettingRow[] rows = (SettingDataSet.SettingRow[])this._settingSet.Setting.Select(filter.ToString());
            if (( rows != null ) && ( rows.Length > 0 ))
            {
                return rows[0];
            }
            return null;
        }
        #endregion

        #region <DB書き込み用データテーブルへの値反映/>
        /// <summary>
        /// DB書き込み用データテーブルへの値反映
        /// </summary>
        /// <param name="operationStDiv"></param>
        /// <param name="categoryCode"></param>
        /// <param name="pgId"></param>
        /// <param name="operationCode"></param>
        /// <param name="authorityLebel1"></param>
        /// <param name="authorityLebel2"></param>
        /// <param name="employeeCode"></param>
        /// <param name="operationLimit"></param>
        private void SetSettingSetTable(int operationStDiv, int categoryCode, string pgId, int operationCode, int authorityLebel1, int authorityLebel2, string employeeCode, int operationLimit)
        {
            SettingDataSet.SettingRow row = this.GetSettingRow(operationStDiv, categoryCode, pgId, operationCode, authorityLebel1, authorityLebel2, employeeCode);

            if (row != null)
            {
                // データが変更された場合はマーキング
                if (( row.LimitDiv != operationLimit - 1 ) && ( row.Index > 0 ))
                {
                    row.Index *= ( -1 );
                }
                row.LimitDiv = operationLimit - 1;
                row.OperationLimit = operationLimit;
            }
        }

        #endregion

        # region [オペレーション設定情報]
        /// <summary>
        /// オペレーション設定情報
        /// </summary>
        private struct OperationInfo
        {
            /// <summary>カテゴリーコード</summary>
            private int _categoryCode;
            /// <summary>プログラムID</summary>
            private string _pgId;
            /// <summary>オペレーションコード</summary>
            private int _operationCode;
            /// <summary>
            /// カテゴリーコード
            /// </summary>
            public int CategoryCode
            {
                get { return _categoryCode; }
                set { _categoryCode = value; }
            }
            /// <summary>
            /// プログラムID
            /// </summary>
            public string PgId
            {
                get { return _pgId; }
                set { _pgId = value; }
            }
            /// <summary>
            /// オペレーションコード
            /// </summary>
            public int OperationCode
            {
                get { return _operationCode; }
                set { _operationCode = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="categoryCode">カテゴリーコード</param>
            /// <param name="pgId">プログラムID</param>
            /// <param name="operationCode">オペレーションコード</param>
            public OperationInfo(int categoryCode, string pgId, int operationCode)
            {
                _categoryCode = categoryCode;
                _pgId = pgId;
                _operationCode = operationCode;
            }
        }
        # endregion

        #region ロール（業務）→従業員テーブルへの選択値反映
        /// <summary>
        /// ロール（業務）から従業員テーブルへの設定反映処理
        /// </summary>
        public void ActivitySettingToEmployeeSettingReflection()
        {
            Dictionary<OperationInfo, List<int>> disabledOperationInfo = new Dictionary<OperationInfo, List<int>>();
            foreach (DataRow row in this._activitySettingTable.Rows)
            {
                foreach (int authorityLevel1 in this._authorityLevel1EmployeeDictionary.Keys)
                {
                    if (this._activitySettingTable.Columns.Contains(authorityLevel1.ToString()))
                    {
                        OperationInfo operationInfo = new OperationInfo((int)row[this._settingSet.Setting.CategoryCodeColumn.ColumnName], (string)row[this._settingSet.Setting.PgIdColumn.ColumnName], (int)row[this._settingSet.Setting.OperationCodeColumn.ColumnName]);
                        if ((string)row[authorityLevel1.ToString()] == OperationLimitToStr(OperationLimit.Disable))
                        {
                            if (!disabledOperationInfo.ContainsKey(operationInfo))
                            {
                                disabledOperationInfo.Add(operationInfo, new List<int>());
                            }
                            disabledOperationInfo[operationInfo].Add(authorityLevel1);
                        }
                    }
                }
            }

            this.DisabledSettingReflectionEmployeeSetting(0, disabledOperationInfo);
        }
        #endregion

        #region ロール（権限）→従業員テーブルへの選択値反映

        /// <summary>
        /// ロール（権限）から従業員テーブルへの設定反映処理
        /// </summary>
        public void AuthoritySettingToEmployeeSettingReflection()
        {
            Dictionary<OperationInfo, List<int>> disabledOperationInfo = new Dictionary<OperationInfo, List<int>>();
            foreach (DataRow row in this._authoritySettingTable.Rows)
            {
                foreach (int authorityLevel1 in this._authorityLevel2EmployeeDictionary.Keys)
                {
                    if (this._authoritySettingTable.Columns.Contains(authorityLevel1.ToString()))
                    {
                        OperationInfo operationInfo = new OperationInfo((int)row[this._settingSet.Setting.CategoryCodeColumn.ColumnName], (string)row[this._settingSet.Setting.PgIdColumn.ColumnName], (int)row[this._settingSet.Setting.OperationCodeColumn.ColumnName]);
                        if ((string)row[authorityLevel1.ToString()] == OperationLimitToStr(OperationLimit.Disable))
                        {
                            if (!disabledOperationInfo.ContainsKey(operationInfo))
                            {
                                disabledOperationInfo.Add(operationInfo, new List<int>());
                            }
                            disabledOperationInfo[operationInfo].Add(authorityLevel1);
                        }
                    }
                }
            }

            this.DisabledSettingReflectionEmployeeSetting(1, disabledOperationInfo);
        }
        #endregion

        #region 操作不可情報テーブル→従業員テーブルへの選択値反映

        /// <summary>
        /// 従業員テーブル不可情報設定反映処理
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="disabledDictionary"></param>
        private void DisabledSettingReflectionEmployeeSetting(int mode, Dictionary<OperationInfo, List<int>> disabledDictionary)
        {
            Dictionary<int, List<Employee>> targetDictionary = ( mode == 0 ) ? this._authorityLevel1EmployeeDictionary : this._authorityLevel2EmployeeDictionary;

            foreach (OperationInfo operationInfo in disabledDictionary.Keys)
            {
                DataRow row = this._employeeSettingTable.Rows.Find(new object[] { operationInfo.CategoryCode, operationInfo.PgId, operationInfo.OperationCode });

                if (row != null)
                {
                    foreach (int authorityLevel in disabledDictionary[operationInfo])
                    {
                        foreach (Employee employee in targetDictionary[authorityLevel])
                        {
                            if (this._employeeSettingTable.Columns.Contains(employee.EmployeeCode.ToString()))
                            {
                                row[employee.EmployeeCode.ToString()] = OperationLimitToStr(OperationLimit.Disable);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 上位設定取得処理
        /// </summary>
        /// <param name="categoryCode">カテゴリーコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="employee">従業員設定マスタ</param>
        /// <returns>設定値</returns>
        private OperationLimit GetHighRankOperationLimit(int categoryCode, string pgId, int operationCode, Employee employee)
        {
            OperationLimit operationLimit = OperationLimit.EnableWithLog;
            if (employee != null)
            {
                // カテゴリーコードに従って上位設定を取得する
                CategoryAttribute categoryAttribute = OperationLimitation.GetCategoryAttribute(categoryCode);
                
                if (categoryAttribute == CategoryAttribute.Activity)
                {
                    operationLimit = this.GetActivitySetting(categoryCode, pgId, operationCode, employee.AuthorityLevel1);
                }
                else if (categoryAttribute == CategoryAttribute.Authority)
                {
                    operationLimit = this.GetAuthoritySetting(categoryCode, pgId, operationCode, employee.AuthorityLevel2);
                }
            }
            return operationLimit;
        }

        /// <summary>
        /// ロール（業務）設定取得処理
        /// </summary>
        /// <param name="categoryCode">カテゴリーコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="authorityLevel1">権限レベル１</param>
        /// <returns>設定</returns>
        private OperationLimit GetActivitySetting(int categoryCode, string pgId, int operationCode, int authorityLevel1)
        {

            OperationLimit operationLimit = OperationLimit.EnableWithLog;
            DataRow row = this.GetActivitySettingRow(categoryCode, pgId, operationCode);
            if (row != null)
            {
                if (this._activitySettingTable.Columns.Contains(authorityLevel1.ToString()))
                {

                    operationLimit = StrToOperationLimit((string)row[authorityLevel1.ToString()]);
                }
            }

            return operationLimit;
        }

        /// <summary>
        /// ロール（業務）設定データ行取得処理
        /// </summary>
        /// <param name="categoryCode">カテゴリーコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>ロール（業務）設定データ行</returns>
        private DataRow GetActivitySettingRow(int categoryCode, string pgId, int operationCode)
        {
            return this._activitySettingTable.Rows.Find(new object[] { categoryCode, pgId, operationCode });
        }

        /// <summary>
        /// ロール（権限）設定取得処理
        /// </summary>
        /// <param name="categoryCode">カテゴリーコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="authorityLevel2">権限レベル２</param>
        /// <returns>データ行</returns>
        private OperationLimit GetAuthoritySetting(int categoryCode, string pgId, int operationCode, int authorityLevel2)
        {
            OperationLimit operationLimit = OperationLimit.EnableWithLog;

            DataRow row = this.GetAuthoritySettingRow(categoryCode, pgId, operationCode);

            if (row != null)
            {
                if (this._authoritySettingTable.Columns.Contains(authorityLevel2.ToString()))
                {
                    operationLimit = StrToOperationLimit((string)row[authorityLevel2.ToString()]);
                }
            }

            return operationLimit;
        }

        /// <summary>
        /// ロール（権限）設定データ行取得処理
        /// </summary>
        /// <param name="categoryCode">カテゴリーコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>データ行</returns>
        private DataRow GetAuthoritySettingRow(int categoryCode, string pgId, int operationCode)
        {
            return this._authoritySettingTable.Rows.Find(new object[] { categoryCode, pgId, operationCode });
        }

        /// <summary>
        /// 従業員設定データ行取得処理
        /// </summary>
        /// <param name="categoryCode">カテゴリーコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>データ行</returns>
        private DataRow GetEmployeeSettingRow(int categoryCode, string pgId, int operationCode)
        {
            return this._employeeSettingTable.Rows.Find(new object[] { categoryCode, pgId, operationCode });
        }

        #region <オペレーション設定マスタ書き込み/>

        /// <summary>
        /// オペレーション設定マスタDBに書き込みます。
        /// </summary>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        /// <returns>結果コード（=0：正常）</returns>
        public int WriteOperationStDB()
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            // 設定操作があったものを対象とする
            StringBuilder sqlWhere = new StringBuilder();
            sqlWhere.Append(SettingDataSet.ClmIdx.Index).Append(ADOUtil.LESS).Append(0);

            DataRow[] foundRows = SettingSet.Setting.Select(sqlWhere.ToString());
            if (foundRows.Length.Equals(0)) return (int)DBAccessStatus.Normal;

            // DB変更処理
            int result = (int)DBAccessStatus.Normal;
            foreach (DataRow foundRow in foundRows)
            {
                SettingDataSet.SettingRow writingRow = (SettingDataSet.SettingRow)foundRow;

                // 操作権限：可の場合
                if ((writingRow.OperationLimit.Equals((int)OperationLimit.EnableWithLog))||
                    ( writingRow.OperationLimit.Equals((int)OperationLimit.Enable) ))

                {
                    string wherePrimaryKey = GetWhereOperationSettingMasterPrimaryKey(writingRow);
                    if (OperationSettingMasterDB.Tbl.Select(wherePrimaryKey).Length > 0)
                    {
                        result = DeleteOperationStDBPhysically(writingRow);
                        if (!result.Equals((int)DBAccessStatus.Normal)) break;
                    }
                    else
                    {
                        Debug.WriteLine("DB上に存在しないので、論理削除は行いませんでした。");
                    }
                }
                // 操作権限：可以外の場合
                else
                {
                    result = WriteOperationStDB(writingRow);
                    if (!result.Equals((int)DBAccessStatus.Normal)) break;
                }

                if (writingRow.Index < 0) writingRow.Index = (-1) * writingRow.Index;
            }

            // 書き込んだDBの状態を取得しないと、同じ権限を設定できないため、再取得する
            OperationSettingMasterDB.SearchAllCategory();

            return result;
        }

        /// <summary>
        /// オペレーション設定マスタDBに書き込みます。
        /// </summary>
        /// <param name="writingRow">書き込む内容</param>
        /// <returns>結果コード（=0：正常）</returns>
        private int WriteOperationStDB(SettingDataSet.SettingRow writingRow)
        {
            OperationStWork writingCondition = GetWritingCondition(writingRow);
            {
                // LimitDiv         = { 0:ログ 1:不可 }
                // OperationLimit   = { 0:可 1:ログ 2:不可}
                writingCondition.LimitDiv = writingRow.OperationLimit - 1;
            }

            ArrayList writingConditionList = new ArrayList();
            writingConditionList.Add(writingCondition);

            object objWritingConditionList = writingConditionList;

            int status = OperationSettingMasterDB.RealAccesser.Write(ref objWritingConditionList);
            if (status.Equals((int)DBAccessStatus.RecordIsExisted))
            {
                Debug.WriteLine("\n既に書き込み済みのレコードを更新しました。");
                status = (int)DBAccessStatus.Normal;
            }
            else if (!status.Equals((int)DBAccessStatus.Normal))
            {
                Debug.Assert(false, "書き込みに失敗！：[" + writingRow.PgId + "]；" + status.ToString());
            }
            Debug.WriteLine("[" + DateTime.Now.ToString() + "]書き込みに成功！\n");

            return status;
        }

        /// <summary>
        /// オペレーション設定マスタDBから削除します。
        /// </summary>
        /// <param name="deletingRow">削除する内容</param>
        /// <returns>結果コード（=0：正常）</returns>
        private int DeleteOperationStDBPhysically(SettingDataSet.SettingRow deletingRow)
        {
            ArrayList deletingCondition = new ArrayList();
            deletingCondition.Add(GetWritingCondition(deletingRow));

            object objDeletingCondition = deletingCondition;
            
            int status = OperationSettingMasterDB.RealAccesser.Delete(objDeletingCondition);
            if (!status.Equals((int)DBAccessStatus.Normal))
            {
                Debug.Assert(false, "物理削除に失敗！");
            }
            Debug.WriteLine("物理削除に成功！");

            return status;
        }

        #region <更新（削除）条件の構築/>

        /// <summary>
        /// オペレーション設定マスタDBのプライマリキーのwhere句を取得します。
        /// </summary>
        /// <param name="writingRow">条件</param>
        /// <returns>オペレーション設定マスタDBのプライマリキーのwhere句</returns>
        private string GetWhereOperationSettingMasterPrimaryKey(SettingDataSet.SettingRow writingRow)
        {
            StringBuilder sqlWhere = new StringBuilder();
            {
                // 企業コード
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.EnterpriseCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(ADOUtil.GetString(writingRow.EnterpriseCode));

                sqlWhere.Append(ADOUtil.AND);

                // カテゴリコード
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.CategoryCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(writingRow.CategoryCode);

                sqlWhere.Append(ADOUtil.AND);

                // プログラムID
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.PgId);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(ADOUtil.GetString(writingRow.PgId));

                sqlWhere.Append(ADOUtil.AND);

                // オペレーションコード
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.OperationCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(writingRow.OperationCode);

                sqlWhere.Append(ADOUtil.AND);

                // 権限レベル1
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.AuthorityLevel1);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(writingRow.AuthorityLevel1);

                sqlWhere.Append(ADOUtil.AND);

                // 権限レベル2
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.AuthorityLevel2);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(writingRow.AuthorityLevel2);

                sqlWhere.Append(ADOUtil.AND);

                // 従業員コード
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.EmployeeCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(ADOUtil.GetString(writingRow.EmployeeCode));
            }
            return sqlWhere.ToString();
        }

        /// <summary>
        /// オペレーション設定マスタDBに書き込むレコードを取得します。
        /// </summary>
        /// <param name="writingRow">書き込む内容</param>
        /// <returns>オペレーション設定マスタDBに書き込むレコード</returns>
        private OperationStWork GetWritingCondition(SettingDataSet.SettingRow writingRow)
        {
            // プライマリキーで検索
            DataRow[] foundRows = OperationSettingMasterDB.Tbl.Select(
                GetWhereOperationSettingMasterPrimaryKey(writingRow)
            );
            OperationStWork writingRecord = new OperationStWork();
            if (foundRows.Length > 0)
            {
                Debug.WriteLine("\n既に登録されているレコードを更新します。");
                // プライマリキーで検索したので、単一行となる
                OperationSettingMasterDataSet.OperationSettingMasterRow
                    foundRow = (OperationSettingMasterDataSet.OperationSettingMasterRow)foundRows[0];
                writingRecord.ApplyEndDate = foundRow.ApplyEndDate;
                writingRecord.ApplyStartDate = foundRow.ApplyStartDate;
                writingRecord.AuthorityLevel1 = foundRow.AuthorityLevel1;
                writingRecord.AuthorityLevel2 = foundRow.AuthorityLevel2;
                writingRecord.CategoryCode = foundRow.CategoryCode;
                writingRecord.CreateDateTime = foundRow.CreateDateTime;
                writingRecord.EmployeeCode = foundRow.EmployeeCode;
                writingRecord.EnterpriseCode = foundRow.EnterpriseCode;
                writingRecord.FileHeaderGuid = foundRow.FileHeaderGuid;
                writingRecord.LimitDiv = foundRow.LimitDiv;
                writingRecord.LogicalDeleteCode = foundRow.LogicalDeleteCode;
                writingRecord.OperationCode = foundRow.OperationCode;
                writingRecord.OperationStDiv = foundRow.OperationStDiv;
                writingRecord.PgId = foundRow.PgId;
                writingRecord.UpdAssemblyId1 = foundRow.UpdAssemblyId1;
                writingRecord.UpdAssemblyId2 = foundRow.UpdAssemblyId2;
                writingRecord.UpdateDateTime = foundRow.UpdateDateTime;
                writingRecord.UpdEmployeeCode = foundRow.UpdEmployeeCode;
            }
            else
            {
                Debug.WriteLine("\nレコードを新規登録します。");

                writingRecord.EnterpriseCode = writingRow.EnterpriseCode;
                writingRecord.CategoryCode = writingRow.CategoryCode;
                writingRecord.PgId = writingRow.PgId;
                writingRecord.OperationCode = writingRow.OperationCode;
                writingRecord.AuthorityLevel1 = writingRow.AuthorityLevel1;
                writingRecord.AuthorityLevel2 = writingRow.AuthorityLevel2;
                writingRecord.EmployeeCode = writingRow.EmployeeCode;

                writingRecord.OperationStDiv = writingRow.OperationStDiv;
                writingRecord.LimitDiv = writingRow.OperationLimit;

                writingRecord.ApplyStartDate = writingRow.ApplyStartDate;
                writingRecord.ApplyEndDate = writingRow.ApplyEndDate;
            }
            return writingRecord;
        }

        #endregion  // <更新（削除）条件の構築/>

        #endregion  // <オペレーション設定マスタ書き込み/>

        /// <summary>
        /// 権限レベル名称を取得します。
        /// </summary>
        /// <param name="authorityLevelDiv">権限レベル区分</param>
        /// <returns>権限レベル名称</returns>
        private static string GetAuthorityLevelName(AuthorityLevelMasterDataSet.AuthorityLevelDiv authorityLevelDiv)
        {
            switch (authorityLevelDiv)
            {
                case AuthorityLevelMasterDataSet.AuthorityLevelDiv.JobType:
                    return "業務";      // LITERAL:
                case AuthorityLevelMasterDataSet.AuthorityLevelDiv.EmploymentForm:
                    return "権限";  // LITERAL:
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 操作権限→文字列
        /// </summary>
        /// <param name="operationLimit"></param>
        /// <returns></returns>
        private static string OperationLimitToStr(OperationLimit operationLimit)
        {
            switch (operationLimit)
            {
                case OperationLimit.Disable:
                    return "×";
                default:
                    return "○";
            }
        }

        /// <summary>
        /// 文字列→操作権限
        /// </summary>
        /// <param name="operatiomlimitMark"></param>
        /// <returns></returns>
        private static OperationLimit StrToOperationLimit(string operatiomlimitMark)
        {

            switch (operatiomlimitMark)
            {
                case "×":
                    return OperationLimit.Disable;
                default:
                    return OperationLimit.EnableWithLog;
            }
        }

        /// <summary>
        /// 次の操作権限取得
        /// </summary>
        /// <param name="operationLimitMark"></param>
        /// <returns></returns>
        public static OperationLimit GetNextOpertaionLimit(string operationLimitMark)
        {
            OperationLimit operationLimit = StrToOperationLimit(operationLimitMark);
            switch (operationLimit)
            {
                case OperationLimit.Disable:
                    return OperationLimit.EnableWithLog;
                default:
                    return OperationLimit.Disable;
            }
        }


        /// <summary>
        /// 次の操作権限取得
        /// </summary>
        /// <param name="operationLimit"></param>
        /// <returns></returns>
        private static OperationLimit GetNextOpertaionLimit(OperationLimit operationLimit)
        {
            switch (operationLimit)
            {
                case OperationLimit.Disable:
                    return OperationLimit.EnableWithLog;
                default:
                    return OperationLimit.Disable;
            }
        }
    }
}
