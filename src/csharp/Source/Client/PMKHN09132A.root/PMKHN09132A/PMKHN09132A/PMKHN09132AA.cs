//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���쌠���ݒ�A�N�Z�X
// �v���O�����T�v   : �ȉ��̃N���X��Facade(����)�ƂȂ�܂��B
//                  : �E�I�y���[�V�����}�X�^���[�J���A�N�Z�X
//                  : �E�������x���}�X�^���[�J���A�N�Z�X�N���X
//                  : �E�I�y���[�V�����ݒ�}�X�^�����[�g�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/07/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2010/07/08  �C�����e : Mantis.15765�@���ו����я���\�����֕ύX�i�e��\�������擾�j
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
    /// ���쌠���ݒ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// �ȉ��̃N���X��Facade(����)�ƂȂ�܂��B<br/>
    /// �E�I�y���[�V�����}�X�^���[�J���A�N�Z�X<br/>
    /// �E�������x���}�X�^���[�J���A�N�Z�X�N���X<br/>
    /// �E�I�y���[�V�����ݒ�}�X�^�����[�g�N���X<br/>
    /// </remarks>
    public sealed class OperationAuthoritySettingAcs : IDisposable
    {
        #region <Singleton Idiom/>

        /// <summary>�����I�u�W�F�N�g</summary>
        private static readonly object _syncRoot = new object();

        /// <summary>�V���O���g���C���X�^���X</summary>
        private static OperationAuthoritySettingAcs _instance;
        /// <summary>
        /// �V���O���g���C���X�^���X���擾���܂��B
        /// </summary>
        /// <value>���쌠���ݒ�A�N�Z�X�N���X�̃V���O���g���C���X�^���X</value>
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
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        private OperationAuthoritySettingAcs() { }

        #endregion  // <Singleton Idiom/>

        #region <IDisposable Member/>

        /// <summary>�����ς݃t���O</summary>
        private bool _disposed;
        /// <summary>
        /// �����ς݃t���O���擾���܂��B
        /// </summary>
        /// <value>true :�����ς�<br/>false:�������Ă��Ȃ�</value>
        private bool Disposed { get { return _disposed; } }

        /// <summary>
        /// �������܂��B
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            this._disposed = true;
        }

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="disposing">�}�l�[�W�I�u�W�F�N�g�̏����t���O</param>
        private void Dispose(bool disposing)
        {
            #region <Guard Phrase/>

            if (this.Disposed) return;

            #endregion  // <Guard Phrase/>

            // �}�l�[�W�I�u�W�F�N�g
            if (disposing)
            {
                ResetDataSet();
            }
            // �A���}�l�[�W�I�u�W�F�N�g
        }

        /// <summary>
        /// �f�X�g���N�^
        /// </summary>
        ~OperationAuthoritySettingAcs()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        #region �萔
        private const string ctTableName_ActivitySetting = "ActivitySettingTable";
        private const string ctTableName_EmployeeSetting = "EmployeeSettingTable";
        private const string ctTableName_AuthoritySetting = "AuthoritySettingTable";
        #endregion

        #region <�]�ƈ��ʐݒ�p�̃f�B�N�V���i��/>

        private Dictionary<int, List<Employee>> _authorityLevel1EmployeeDictionary;
        private Dictionary<int, List<Employee>> _authorityLevel2EmployeeDictionary;

        #endregion

        #region <DB�A�N�Z�X�㗝�l/>

        #region <�������x���}�X�^���[�J���A�N�Z�X/>

        /// <summary>�������x���}�X�^DB</summary>
        private AuthorityLevelLcDBAgent _authorityLevelMasterDB;
        /// <summary>
        /// �������x���}�X�^DB���擾���܂��B
        /// </summary>
        /// <value>�������x���}�X�^DB</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
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

        #endregion  // <�������x���}�X�^���[�J���A�N�Z�X/>

        #region <�]�ƈ��e�[�u���A�N�Z�X/>

        /// <summary>�]�ƈ��}�X�^DB</summary>
        private EmployeeAcsAgent _employeeMasterDB;
        /// <summary>
        /// �]�ƈ��}�X�^DB���擾���܂��B
        /// </summary>
        /// <value>�]�ƈ��}�X�^DB</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
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

        #endregion  // <�]�ƈ��e�[�u���A�N�Z�X/>

        #region <�I�y���[�V�����}�X�^���[�J���A�N�Z�X/>

        /// <summary>�I�y���[�V�����}�X�^DB</summary>
        private OperationLcDBAgent _operationMasterDB;
        /// <summary>
        /// �I�y���[�V�����}�X�^DB���擾���܂��B
        /// </summary>
        /// <value>�I�y���[�V�����}�X�^DB</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
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

        # endregion // <�I�y���[�V�����}�X�^���[�J���A�N�Z�X/>

        #region <�I�y���[�V�����ݒ�}�X�^�����[�g/>

        /// <summary>�I�y���[�V�����ݒ�}�X�^DB</summary>
        private OperationStDBAgent _operationSettingMasterDB;
        /// <summary>
        /// �I�y���[�V�����ݒ�}�X�^DB���擾���܂��B
        /// </summary>
        /// <value>�I�y���[�V�����ݒ�}�X�^DB</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
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

        #endregion  // <�I�y���[�V�����ݒ�}�X�^�����[�g/>

        #endregion  // <DB�A�N�Z�X�㗝�l/>


        #region <���[��(�Ɩ�)�p�f�[�^�e�[�u��/>
        /// <summary>���[���i�Ɩ��j�p�̃f�[�^�e�[�u��</summary>
        private DataTable _activitySettingTable;

        /// <summary>
        /// ���[���i�Ɩ��j�p�̃f�[�^�e�[�u��
        /// </summary>
        public DataTable ActivitySettingTable
        {
            get 
            {
                return SettingSet.Tables[ctTableName_ActivitySetting];
            }
        }
        #endregion

        #region <���[��(����)�p�f�[�^�e�[�u��/>
        /// <summary>���[���i�����j�p�̃f�[�^�e�[�u��</summary>
        private DataTable _authoritySettingTable;

        /// <summary>
        /// ���[���i�����j�p�̃f�[�^�e�[�u��
        /// </summary>
        public DataTable AuthoritySettingTable
        {
            get
            {
                return SettingSet.Tables[ctTableName_AuthoritySetting];
            }
        }
        #endregion

        #region <�]�ƈ��p�p�f�[�^�e�[�u��/>
        /// <summary>�]�ƈ��ݒ�p�̃f�[�^�e�[�u��</summary>
        private DataTable _employeeSettingTable;

        /// <summary>
        /// �]�ƈ��ݒ�p�̃f�[�^�e�[�u��
        /// </summary>
        public DataTable EmployeeSettingTable
        {
            get
            {
                return SettingSet.Tables[ctTableName_EmployeeSetting];
            }
        }
        #endregion

        #region <���쌠���ݒ��UI�p�f�[�^�Z�b�g/>

        /// <summary>���쌠���ݒ��UI�p�f�[�^�Z�b�g</summary>
        private SettingDataSet _settingSet;
        /// <summary>
        /// ���쌠���ݒ��UI�p�f�[�^�Z�b�g���擾���܂��B
        /// </summary>
        /// <value>���쌠���ݒ��UI�p�f�[�^�Z�b�g</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
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
        /// ���쌠���ݒ��UI�p�f�[�^�Z�b�g�����������܂��B
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
                #region ���[���i�Ɩ��j�ݒ�e�[�u���p�J��������

                // �J�e�S���R�[�h
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.CategoryCodeColumn.ColumnName, typeof(int));
                this._activitySettingTable.Columns[this._settingSet.Setting.CategoryCodeColumn.ColumnName].DefaultValue = 0;
                // �J�e�S������
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.CategoryNameColumn.ColumnName, typeof(string));
                this._activitySettingTable.Columns[this._settingSet.Setting.CategoryNameColumn.ColumnName].DefaultValue = string.Empty;
                this._activitySettingTable.Columns[this._settingSet.Setting.CategoryNameColumn.ColumnName].Caption = this._settingSet.Setting.CategoryNameColumn.Caption;
                // �J�e�S���\������
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.CategoryDspOdrColumn.ColumnName, typeof(int));
                this._activitySettingTable.Columns[this._settingSet.Setting.CategoryDspOdrColumn.ColumnName].DefaultValue = 0;

                // �v���O����ID
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.PgIdColumn.ColumnName, typeof(string));
                this._activitySettingTable.Columns[this._settingSet.Setting.PgIdColumn.ColumnName].DefaultValue = string.Empty;
                // �v���O��������
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.PgNameColumn.ColumnName, typeof(string));
                this._activitySettingTable.Columns[this._settingSet.Setting.PgNameColumn.ColumnName].DefaultValue = string.Empty;
                this._activitySettingTable.Columns[this._settingSet.Setting.PgNameColumn.ColumnName].Caption = this._settingSet.Setting.PgNameColumn.Caption;
                // �v���O�����\������
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.PgDspOdrColumn.ColumnName, typeof(int));
                this._activitySettingTable.Columns[this._settingSet.Setting.PgDspOdrColumn.ColumnName].DefaultValue = 0;

                // �I�y���[�V�����R�[�h
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.OperationCodeColumn.ColumnName, typeof(int));
                this._activitySettingTable.Columns[this._settingSet.Setting.OperationCodeColumn.ColumnName].DefaultValue = 0;
                // �I�y���[�V��������
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.OperationNameColumn.ColumnName, typeof(string));
                this._activitySettingTable.Columns[this._settingSet.Setting.OperationNameColumn.ColumnName].DefaultValue = string.Empty;
                this._activitySettingTable.Columns[this._settingSet.Setting.OperationNameColumn.ColumnName].Caption = this._settingSet.Setting.OperationNameColumn.Caption;
                // �I�y���[�V�����\������
                this._activitySettingTable.Columns.Add(this._settingSet.Setting.OperationDspOdrColumn.ColumnName, typeof(int));
                this._activitySettingTable.Columns[this._settingSet.Setting.OperationDspOdrColumn.ColumnName].DefaultValue = 0;

                foreach (JobTypeDataRow jobTypeDataRow in AuthorityLevelMasterDB.JobTypeTbl)
                {
                    // �Ɩ����̃J������ǉ�
                    this._activitySettingTable.Columns.Add(jobTypeDataRow.AuthorityLevelCd.ToString(), typeof(string));
                    this._activitySettingTable.Columns[jobTypeDataRow.AuthorityLevelCd.ToString()].DefaultValue = OperationLimitToStr(OperationLimit.EnableWithLog);
                    this._activitySettingTable.Columns[jobTypeDataRow.AuthorityLevelCd.ToString()].Caption = jobTypeDataRow.AuthorityLevelNm;
                }

                this._activitySettingTable.PrimaryKey = new DataColumn[]{
                this._activitySettingTable.Columns[this._settingSet.Setting.CategoryCodeColumn.ColumnName],
                this._activitySettingTable.Columns[this._settingSet.Setting.PgIdColumn.ColumnName],
                this._activitySettingTable.Columns[this._settingSet.Setting.OperationCodeColumn.ColumnName]};

                #endregion

                #region ���[���i�����j�ݒ�e�[�u���p�J��������

                // �J�e�S���R�[�h
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.CategoryCodeColumn.ColumnName, typeof(int));
                this._authoritySettingTable.Columns[this._settingSet.Setting.CategoryCodeColumn.ColumnName].DefaultValue = 0;
                // �J�e�S������
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.CategoryNameColumn.ColumnName, typeof(string));
                this._authoritySettingTable.Columns[this._settingSet.Setting.CategoryNameColumn.ColumnName].DefaultValue = string.Empty;
                this._authoritySettingTable.Columns[this._settingSet.Setting.CategoryNameColumn.ColumnName].Caption = this._settingSet.Setting.CategoryNameColumn.Caption;
                // �J�e�S���\������
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.CategoryDspOdrColumn.ColumnName, typeof(int));
                this._authoritySettingTable.Columns[this._settingSet.Setting.CategoryDspOdrColumn.ColumnName].DefaultValue = 0;

                // �v���O����ID
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.PgIdColumn.ColumnName, typeof(string));
                this._authoritySettingTable.Columns[this._settingSet.Setting.PgIdColumn.ColumnName].DefaultValue = string.Empty;
                // �v���O��������
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.PgNameColumn.ColumnName, typeof(string));
                this._authoritySettingTable.Columns[this._settingSet.Setting.PgNameColumn.ColumnName].DefaultValue = string.Empty;
                this._authoritySettingTable.Columns[this._settingSet.Setting.PgNameColumn.ColumnName].Caption = this._settingSet.Setting.PgNameColumn.Caption;
                // �v���O�����\������
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.PgDspOdrColumn.ColumnName, typeof(int));
                this._authoritySettingTable.Columns[this._settingSet.Setting.PgDspOdrColumn.ColumnName].DefaultValue = 0;

                // �I�y���[�V�����R�[�h
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.OperationCodeColumn.ColumnName, typeof(int));
                this._authoritySettingTable.Columns[this._settingSet.Setting.OperationCodeColumn.ColumnName].DefaultValue = 0;
                // �I�y���[�V��������
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.OperationNameColumn.ColumnName, typeof(string));
                this._authoritySettingTable.Columns[this._settingSet.Setting.OperationNameColumn.ColumnName].DefaultValue = string.Empty;
                this._authoritySettingTable.Columns[this._settingSet.Setting.OperationNameColumn.ColumnName].Caption = this._settingSet.Setting.OperationNameColumn.Caption;
                // �I�y���[�V�����\������
                this._authoritySettingTable.Columns.Add(this._settingSet.Setting.OperationDspOdrColumn.ColumnName, typeof(int));
                this._authoritySettingTable.Columns[this._settingSet.Setting.OperationDspOdrColumn.ColumnName].DefaultValue = 0;

                DataView dv = AuthorityLevelMasterDB.EmploymentFormTbl.DefaultView;
                dv.Sort = AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelCd.ToString();

                foreach (DataRowView drv in dv)
                {
                    // �������̃J������ǉ�
                    this._authoritySettingTable.Columns.Add(( (int)drv[AuthorityLevelMasterDB.EmploymentFormTbl.AuthorityLevelCdColumn.ColumnName] ).ToString(), typeof(string));
                    this._authoritySettingTable.Columns[( (int)drv[AuthorityLevelMasterDB.EmploymentFormTbl.AuthorityLevelCdColumn.ColumnName] ).ToString()].DefaultValue = OperationLimitToStr(OperationLimit.EnableWithLog);
                    this._authoritySettingTable.Columns[( (int)drv[AuthorityLevelMasterDB.EmploymentFormTbl.AuthorityLevelCdColumn.ColumnName] ).ToString()].Caption = (string)drv[AuthorityLevelMasterDB.EmploymentFormTbl.AuthorityLevelNmColumn.ColumnName];
                }

                this._authoritySettingTable.PrimaryKey = new DataColumn[]{
                this._authoritySettingTable.Columns[this._settingSet.Setting.CategoryCodeColumn.ColumnName],
                this._authoritySettingTable.Columns[this._settingSet.Setting.PgIdColumn.ColumnName],
                this._authoritySettingTable.Columns[this._settingSet.Setting.OperationCodeColumn.ColumnName]};
                #endregion

                #region �]�ƈ��ݒ�p�e�[�u���p�J��������

                // �J�e�S���R�[�h
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.CategoryCodeColumn.ColumnName, typeof(int));
                this._employeeSettingTable.Columns[this._settingSet.Setting.CategoryCodeColumn.ColumnName].DefaultValue = 0;

                // �J�e�S������
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.CategoryNameColumn.ColumnName, typeof(string));
                this._employeeSettingTable.Columns[this._settingSet.Setting.CategoryNameColumn.ColumnName].DefaultValue = string.Empty;
                this._employeeSettingTable.Columns[this._settingSet.Setting.CategoryNameColumn.ColumnName].Caption = this._settingSet.Setting.CategoryNameColumn.Caption;
                // �J�e�S���\������
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.CategoryDspOdrColumn.ColumnName, typeof(int));
                this._employeeSettingTable.Columns[this._settingSet.Setting.CategoryDspOdrColumn.ColumnName].DefaultValue = 0;

                // �v���O����ID
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.PgIdColumn.ColumnName, typeof(string));
                this._employeeSettingTable.Columns[this._settingSet.Setting.PgIdColumn.ColumnName].DefaultValue = string.Empty;
                // �v���O��������
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.PgNameColumn.ColumnName, typeof(string));
                this._employeeSettingTable.Columns[this._settingSet.Setting.PgNameColumn.ColumnName].DefaultValue = string.Empty;
                this._employeeSettingTable.Columns[this._settingSet.Setting.PgNameColumn.ColumnName].Caption = this._settingSet.Setting.PgNameColumn.Caption;
                // �v���O�����\������
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.PgDspOdrColumn.ColumnName, typeof(int));
                this._employeeSettingTable.Columns[this._settingSet.Setting.PgDspOdrColumn.ColumnName].DefaultValue = 0;

                // �I�y���[�V�����R�[�h
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.OperationCodeColumn.ColumnName, typeof(int));
                this._employeeSettingTable.Columns[this._settingSet.Setting.OperationCodeColumn.ColumnName].DefaultValue = 0;
                // �I�y���[�V��������
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.OperationNameColumn.ColumnName, typeof(string));
                this._employeeSettingTable.Columns[this._settingSet.Setting.OperationNameColumn.ColumnName].DefaultValue = string.Empty;
                this._employeeSettingTable.Columns[this._settingSet.Setting.OperationNameColumn.ColumnName].Caption = this._settingSet.Setting.OperationNameColumn.Caption;
                // �I�y���[�V�����\������
                this._employeeSettingTable.Columns.Add(this._settingSet.Setting.OperationDspOdrColumn.ColumnName, typeof(int));
                this._employeeSettingTable.Columns[this._settingSet.Setting.OperationDspOdrColumn.ColumnName].DefaultValue = 0;

                this._employeeSettingTable.PrimaryKey = new DataColumn[]{
                this._employeeSettingTable.Columns[this._settingSet.Setting.CategoryCodeColumn.ColumnName],
                this._employeeSettingTable.Columns[this._settingSet.Setting.PgIdColumn.ColumnName],
                this._employeeSettingTable.Columns[this._settingSet.Setting.OperationCodeColumn.ColumnName]};

                foreach (Employee employeeRecord in EmployeeMasterDB.RecordList)
                {
                    // �]�ƈ����̃J������ǉ�
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

                #region �J�e�S���[���̃e�[�u���ݒ�
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

                // �e����̐ݒ���擾
                foreach (Operation operationMasterRecord in OperationMasterDB.RecordList)
                {
                    #region <�E��ʂɐݒ�/>

                    foreach (JobTypeDataRow jobTypeRow in AuthorityLevelMasterDB.JobTypeTbl)
                    {
                        OpeSttngDataRow[] opeSettingRows = OperationSettingMasterDB.GetRowsWhatIsJobType(
                            operationMasterRecord.CategoryCode,
                            operationMasterRecord.PgId,
                            operationMasterRecord.OperationCode,
                            jobTypeRow.AuthorityLevelCd
                        );
                        // �I�y���[�V�����ݒ�}�X�^DB�ɊY������E��̐ݒ肪�Ȃ�
                        if (opeSettingRows.Length.Equals(0))
                        {
                            OperationStWork operationSettingMasterRecord = new OperationStWork();
                            operationSettingMasterRecord.EnterpriseCode = OperationSettingMasterDB.EnterpriseCode;
                            operationSettingMasterRecord.OperationStDiv = (int)OperationStDivValue.AuthorityLevel1; // �E��
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
                        // �I�y���[�V�����ݒ�}�X�^DB�ɊY������E��̐ݒ肪����
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

                    #endregion  // <�E��ʂɐݒ�/>

                    #region <�ٗp�`�ԕʂɐݒ�/>

                    foreach (JobTypeDataRow employmentFormRow in AuthorityLevelMasterDB.EmploymentFormTbl)
                    {
                        OpeSttngDataRow[] opeSettingRows = OperationSettingMasterDB.GetRowsWhatIsEmploymentForm(
                            operationMasterRecord.CategoryCode,
                            operationMasterRecord.PgId,
                            operationMasterRecord.OperationCode,
                            employmentFormRow.AuthorityLevelCd
                        );
                        // �I�y���[�V�����ݒ�}�X�^DB�ɊY������ٗp�`�Ԃ̐ݒ肪�Ȃ�
                        if (opeSettingRows.Length.Equals(0))
                        {
                            OperationStWork operationSettingMasterRecord = new OperationStWork();
                            operationSettingMasterRecord.EnterpriseCode = OperationSettingMasterDB.EnterpriseCode;
                            operationSettingMasterRecord.OperationStDiv = (int)OperationStDivValue.AuthorityLevel2; // �ٗp�`��
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
                        // �I�y���[�V�����ݒ�}�X�^DB�ɊY������E��̐ݒ肪����
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

                    #endregion  // <�ٗp�`�ԕʂɐݒ�/>

                    #region <�]�ƈ��ʂɐݒ�/>

                    foreach (Employee employeeRecord in EmployeeMasterDB.RecordList)
                    {
                        OpeSttngDataRow[] opeSettingRows = OperationSettingMasterDB.GetRowsWhatIsEmployeeCode(
                            operationMasterRecord.CategoryCode,
                            operationMasterRecord.PgId,
                            operationMasterRecord.OperationCode,
                            employeeRecord.EmployeeCode
                        );
                        // �I�y���[�V�����ݒ�}�X�^DB�ɊY������]�ƈ��̐ݒ肪�Ȃ�
                        if (opeSettingRows.Length.Equals(0))
                        {
                            OperationStWork operationSettingMasterRecord = new OperationStWork();
                            operationSettingMasterRecord.EnterpriseCode = OperationSettingMasterDB.EnterpriseCode;
                            operationSettingMasterRecord.OperationStDiv = (int)OperationStDivValue.EmployeeCode;    // �]�ƈ�
                            operationSettingMasterRecord.EmployeeCode = employeeRecord.EmployeeCode;

                            SettingState defaultSettingStatus = new EmployeeSettingState(operationMasterRecord, employeeRecord);
                            AddSettengDataRow(operationMasterRecord, operationSettingMasterRecord, defaultSettingStatus);

                            continue;
                        }
                        // �I�y���[�V�����ݒ�}�X�^DB�ɊY������]�ƈ��̐ݒ肪����
                        SettingState settingStatus = new EmployeeSettingState(operationMasterRecord, employeeRecord);
                        AddSettengDataRow(operationMasterRecord, opeSettingRows[SINGLE_ROW], settingStatus);
                    }

                    #endregion  // <�]�ƈ��ʂɐݒ�/>
                }

                #region �Ɩ������ꗗ�p�e�[�u���̐ݒ�
                // �Ɩ��f�B�N�V���i��
                Dictionary<int, string> activityDictionary = new Dictionary<int, string>();
                // �����f�B�N�V���i��
                Dictionary<int, string> authorityDictionary = new Dictionary<int, string>();

                foreach (Employee employeeRecord in EmployeeMasterDB.RecordList)
                {
                    #region �Ɩ��̒ǉ�
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
                        employeeAuthorityRow.BelongSectionNm = employeeRecord.BelongSectionName;    // FIXME:�������_�����Ȃ��H
                        SettingSet.EmployeeAuthority.AddEmployeeAuthorityRow(employeeAuthorityRow);
                    }
                    #endregion

                    #region �����̒ǉ�
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

                #region �]�ƈ��ʂ̐ݒ肩��]�ƈ������ꗗ�ւ̃f�[�^���f

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
                            //row[columnName] = ( (int)drv[this._settingSet.Setting.OperationLimitColumn.ColumnName] == (int)OperationLimit.Disable ) ? "�~" : "��";
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

        #region <���쌠���ݒ�s�̒ǉ�/>

        /// <summary>
        /// ���쌠���ݒ�s��ǉ����܂��B
        /// </summary>
        /// <param name="operationMasterRecord">�I�y���[�V�����}�X�^���R�[�h</param>
        /// <param name="operationSettingMasterRecord">�I�y���[�V�����ݒ�}�X�^���R�[�h</param>
        /// <param name="settingStatus">�ݒ���</param>
        private void AddSettengDataRow(
            Operation operationMasterRecord,
            OperationStWork operationSettingMasterRecord,
            SettingState settingStatus
        )
        {
            long index = SettingSet.Setting.Count + 1;  // �C���f�b�N�X��1�`   
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
        /// ���쌠���ݒ�s��ǉ����܂��B
        /// </summary>
        /// <param name="operationMasterRecord">�I�y���[�V�����}�X�^���R�[�h</param>
        /// <param name="operationSettingMasterRow">�I�y���[�V�����ݒ�}�X�^�s</param>
        /// <param name="settingStatus">�ݒ���</param>
        private void AddSettengDataRow(
            Operation operationMasterRecord,
            OpeSttngDataRow operationSettingMasterRow,
            SettingState settingStatus
        )
        {
            long index = SettingSet.Setting.Count + 1;  // �C���f�b�N�X��1�`
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

        #endregion  // <���쌠���ݒ�s�̒ǉ�/>

        #endregion  // <���쌠���ݒ��UI�p�f�[�^�Z�b�g/>

        #region <���쌠���ꗗ�\����UI�p�f�[�^�e�[�u��/>

        /// <summary>
        /// ���쌠���ꗗ�\����UI�p�f�[�^�e�[�u�����擾���܂��B
        /// </summary>
        /// <value>���쌠���ꗗ�\����UI�p�f�[�^�e�[�u��</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
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

        #endregion  // <���쌠���ꗗ�\����UI�p�f�[�^�e�[�u��/>

        /// <summary>
        /// �ێ����Ă���f�[�^�Z�b�g�����Z�b�g���܂��B
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

        #region �Ɩ��e�[�u���I��l�ύX����

        /// <summary>
        /// �Ɩ��ݒ�e�[�u���I������
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
                        // �������ݗpDB�֔��f����
                        SetSettingSetTable((int)OperationStDivValue.AuthorityLevel1, categoryCode, pgId, operationCode, TStrConv.StrToIntDef(authorityLevelCd.Trim(), 0), 0, string.Empty, (int)operationLimit);

                        // �S�̐ݒ�̏ꍇ�́A�ΏۃJ�e�S���̐ݒ��DB����̒l�ɖ߂�
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
                                        // �C���s�̂�DB�̐ݒ�l���擾����
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


        #region �����e�[�u���I��l�ύX����

        /// <summary>
        /// �����e�[�u���I������
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
                        // �������ݗpDB�֔��f����
                        SetSettingSetTable((int)OperationStDivValue.AuthorityLevel2, categoryCode, pgId, operationCode, 0, TStrConv.StrToIntDef(authorityLevelCd.Trim(), 0), string.Empty, (int)operationLimit);

                        // �S�̐ݒ�̏ꍇ�́A�ΏۃJ�e�S���̐ݒ��DB����̒l�ɖ߂�
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
                                        // �C���s�̂�DB�̐ݒ�l���擾����
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



        #region �]�ƈ��e�[�u���I��l�ύX����

        /// <summary>
        /// �]�ƈ��e�[�u���I��l�ύX����
        /// </summary>
        /// <param name="categoryCode">�J�e�S���[�R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
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
                    // �J�e�S���[�R�[�h�ɏ]���ď�ʐݒ���擾����
                    OperationLimit highRankOperationLimit = this.GetHighRankOperationLimit(categoryCode, pgId, operationCode, employee);

                    DataRow foundRow = this.GetEmployeeSettingRow(categoryCode, pgId, operationCode);
                    DataRow allSettingRow = this.GetEmployeeSettingRow(categoryCode, string.Empty, operationCode);

                    if (foundRow != null)
                    {
                        // ��ʐݒ肪�u�s�v�̏ꍇ�́u�s�v��ݒ�
                        if (highRankOperationLimit == OperationLimit.Disable)
                        {
                            foundRow[employeeCode] = OperationLimitToStr(OperationLimit.Disable);
                        }
                        // �Ώۍs���S�̐ݒ�ȊO�ŁA�S�̐ݒ肪�u�s�v�̏ꍇ�́u�s�v��ݒ�
                        else if (( allSettingRow != null ) && ( foundRow != allSettingRow ) && ( StrToOperationLimit((string)allSettingRow[employeeCode]) == OperationLimit.Disable ))
                        {
                            foundRow[employeeCode] = OperationLimitToStr(OperationLimit.Disable);
                        }
                        else
                        {
                            foundRow[employeeCode] = OperationLimitToStr(operationLimit);

                            // �������ݗpDB�֔��f����
                            SetSettingSetTable((int)OperationStDivValue.EmployeeCode, categoryCode, pgId, operationCode, 0, 0, employee.EmployeeCode, (int)operationLimit);

                            // �S�̐ݒ��ύX�����ꍇ�́A�ΏۃJ�e�S����S�ĕύX����
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
                                        // ��ʐݒ���擾
                                        highRankOperationLimit = this.GetHighRankOperationLimit((int)row[this._settingSet.Setting.CategoryCodeColumn.ColumnName], (string)row[this._settingSet.Setting.PgIdColumn.ColumnName], (int)row[this._settingSet.Setting.OperationCodeColumn.ColumnName], employee);

                                        if (highRankOperationLimit != OperationLimit.Disable)
                                        {
                                            if (operationLimit == OperationLimit.Disable)
                                            {
                                                row[employeeCode] = OperationLimitToStr(operationLimit);
                                            }
                                            else
                                            {
                                                // ��ʐݒ�Łu�s�v�łȂ���΁ADB����̒l�𕜌�����
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
        /// �]�ƈ��e�[�u���I��l�ύX����
        /// </summary>
        /// <param name="categoryCode">�J�e�S���[�R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns></returns>
        public bool EmployeeSettingRowSelectChange(int categoryCode, string pgId, int operationCode, string employeeCode)
        {
            bool ret = false;
            if (this._employeeSettingTable.Columns.Contains(employeeCode))
            {
                Employee employee = this._employeeMasterDB.FindRecord(employeeCode);
                if (employee != null)
                {
                    // �J�e�S���[�R�[�h�ɏ]���ď�ʐݒ���擾����
                    OperationLimit highRankOperationLimit = this.GetHighRankOperationLimit(categoryCode, pgId, operationCode, employee);

                    DataRow foundRow = this.GetEmployeeSettingRow(categoryCode, pgId, operationCode);
                    DataRow allSettingRow = this.GetEmployeeSettingRow(categoryCode, string.Empty, operationCode);

                    if (foundRow != null)
                    {
                        if (highRankOperationLimit == OperationLimit.Disable)
                        {
                            foundRow[employeeCode] = OperationLimitToStr(OperationLimit.Disable);
                        }
                        else if (( allSettingRow != null ) && ( foundRow != allSettingRow ) && ( ( (string)allSettingRow[employeeCode] ) == "�~" ))
                        {
                            foundRow[employeeCode] = OperationLimitToStr(OperationLimit.Disable);
                        }
                        else
                        {
                            // �����_�̑��쌠�����擾
                            OperationLimit operationLimit = StrToOperationLimit((string)foundRow[employeeCode]);
                            operationLimit = GetNextOpertaionLimit(operationLimit);
                            foundRow[employeeCode] = OperationLimitToStr(operationLimit);

                            // �������ݗpDB�֔��f����
                            SetSettingSetTable((int)OperationStDivValue.EmployeeCode, categoryCode, pgId, operationCode, 0, 0, employee.EmployeeCode, (int)operationLimit);

                            // �S�̐ݒ��ύX�����ꍇ�́A�ΏۃJ�e�S����S�ĕύX����
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
                                        // ��ʐݒ���擾
                                        highRankOperationLimit = this.GetHighRankOperationLimit((int)row[this._settingSet.Setting.CategoryCodeColumn.ColumnName], (string)row[this._settingSet.Setting.PgIdColumn.ColumnName], (int)row[this._settingSet.Setting.OperationCodeColumn.ColumnName], employee);

                                        if (highRankOperationLimit != OperationLimit.Disable)
                                        {
                                            if (operationLimit == OperationLimit.Disable)
                                            {
                                                row[employeeCode] = OperationLimitToStr(operationLimit);
                                            }
                                            else
                                            {
                                                // ��ʐݒ�Łu�s�v�łȂ���΁ADB����̒l�𕜌�����
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


        #region <DB�������ݗp�f�[�^�e�[�u������s�擾/>

        /// <summary>
        /// DB�������ݗp�f�[�^�e�[�u������s�擾
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

        #region <DB�������ݗp�f�[�^�e�[�u���ւ̒l���f/>
        /// <summary>
        /// DB�������ݗp�f�[�^�e�[�u���ւ̒l���f
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
                // �f�[�^���ύX���ꂽ�ꍇ�̓}�[�L���O
                if (( row.LimitDiv != operationLimit - 1 ) && ( row.Index > 0 ))
                {
                    row.Index *= ( -1 );
                }
                row.LimitDiv = operationLimit - 1;
                row.OperationLimit = operationLimit;
            }
        }

        #endregion

        # region [�I�y���[�V�����ݒ���]
        /// <summary>
        /// �I�y���[�V�����ݒ���
        /// </summary>
        private struct OperationInfo
        {
            /// <summary>�J�e�S���[�R�[�h</summary>
            private int _categoryCode;
            /// <summary>�v���O����ID</summary>
            private string _pgId;
            /// <summary>�I�y���[�V�����R�[�h</summary>
            private int _operationCode;
            /// <summary>
            /// �J�e�S���[�R�[�h
            /// </summary>
            public int CategoryCode
            {
                get { return _categoryCode; }
                set { _categoryCode = value; }
            }
            /// <summary>
            /// �v���O����ID
            /// </summary>
            public string PgId
            {
                get { return _pgId; }
                set { _pgId = value; }
            }
            /// <summary>
            /// �I�y���[�V�����R�[�h
            /// </summary>
            public int OperationCode
            {
                get { return _operationCode; }
                set { _operationCode = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="categoryCode">�J�e�S���[�R�[�h</param>
            /// <param name="pgId">�v���O����ID</param>
            /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
            public OperationInfo(int categoryCode, string pgId, int operationCode)
            {
                _categoryCode = categoryCode;
                _pgId = pgId;
                _operationCode = operationCode;
            }
        }
        # endregion

        #region ���[���i�Ɩ��j���]�ƈ��e�[�u���ւ̑I��l���f
        /// <summary>
        /// ���[���i�Ɩ��j����]�ƈ��e�[�u���ւ̐ݒ蔽�f����
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

        #region ���[���i�����j���]�ƈ��e�[�u���ւ̑I��l���f

        /// <summary>
        /// ���[���i�����j����]�ƈ��e�[�u���ւ̐ݒ蔽�f����
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

        #region ����s���e�[�u�����]�ƈ��e�[�u���ւ̑I��l���f

        /// <summary>
        /// �]�ƈ��e�[�u���s���ݒ蔽�f����
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
        /// ��ʐݒ�擾����
        /// </summary>
        /// <param name="categoryCode">�J�e�S���[�R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="employee">�]�ƈ��ݒ�}�X�^</param>
        /// <returns>�ݒ�l</returns>
        private OperationLimit GetHighRankOperationLimit(int categoryCode, string pgId, int operationCode, Employee employee)
        {
            OperationLimit operationLimit = OperationLimit.EnableWithLog;
            if (employee != null)
            {
                // �J�e�S���[�R�[�h�ɏ]���ď�ʐݒ���擾����
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
        /// ���[���i�Ɩ��j�ݒ�擾����
        /// </summary>
        /// <param name="categoryCode">�J�e�S���[�R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="authorityLevel1">�������x���P</param>
        /// <returns>�ݒ�</returns>
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
        /// ���[���i�Ɩ��j�ݒ�f�[�^�s�擾����
        /// </summary>
        /// <param name="categoryCode">�J�e�S���[�R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>���[���i�Ɩ��j�ݒ�f�[�^�s</returns>
        private DataRow GetActivitySettingRow(int categoryCode, string pgId, int operationCode)
        {
            return this._activitySettingTable.Rows.Find(new object[] { categoryCode, pgId, operationCode });
        }

        /// <summary>
        /// ���[���i�����j�ݒ�擾����
        /// </summary>
        /// <param name="categoryCode">�J�e�S���[�R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="authorityLevel2">�������x���Q</param>
        /// <returns>�f�[�^�s</returns>
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
        /// ���[���i�����j�ݒ�f�[�^�s�擾����
        /// </summary>
        /// <param name="categoryCode">�J�e�S���[�R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>�f�[�^�s</returns>
        private DataRow GetAuthoritySettingRow(int categoryCode, string pgId, int operationCode)
        {
            return this._authoritySettingTable.Rows.Find(new object[] { categoryCode, pgId, operationCode });
        }

        /// <summary>
        /// �]�ƈ��ݒ�f�[�^�s�擾����
        /// </summary>
        /// <param name="categoryCode">�J�e�S���[�R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>�f�[�^�s</returns>
        private DataRow GetEmployeeSettingRow(int categoryCode, string pgId, int operationCode)
        {
            return this._employeeSettingTable.Rows.Find(new object[] { categoryCode, pgId, operationCode });
        }

        #region <�I�y���[�V�����ݒ�}�X�^��������/>

        /// <summary>
        /// �I�y���[�V�����ݒ�}�X�^DB�ɏ������݂܂��B
        /// </summary>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        /// <returns>���ʃR�[�h�i=0�F����j</returns>
        public int WriteOperationStDB()
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            // �ݒ葀�삪���������̂�ΏۂƂ���
            StringBuilder sqlWhere = new StringBuilder();
            sqlWhere.Append(SettingDataSet.ClmIdx.Index).Append(ADOUtil.LESS).Append(0);

            DataRow[] foundRows = SettingSet.Setting.Select(sqlWhere.ToString());
            if (foundRows.Length.Equals(0)) return (int)DBAccessStatus.Normal;

            // DB�ύX����
            int result = (int)DBAccessStatus.Normal;
            foreach (DataRow foundRow in foundRows)
            {
                SettingDataSet.SettingRow writingRow = (SettingDataSet.SettingRow)foundRow;

                // ���쌠���F�̏ꍇ
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
                        Debug.WriteLine("DB��ɑ��݂��Ȃ��̂ŁA�_���폜�͍s���܂���ł����B");
                    }
                }
                // ���쌠���F�ȊO�̏ꍇ
                else
                {
                    result = WriteOperationStDB(writingRow);
                    if (!result.Equals((int)DBAccessStatus.Normal)) break;
                }

                if (writingRow.Index < 0) writingRow.Index = (-1) * writingRow.Index;
            }

            // ��������DB�̏�Ԃ��擾���Ȃ��ƁA����������ݒ�ł��Ȃ����߁A�Ď擾����
            OperationSettingMasterDB.SearchAllCategory();

            return result;
        }

        /// <summary>
        /// �I�y���[�V�����ݒ�}�X�^DB�ɏ������݂܂��B
        /// </summary>
        /// <param name="writingRow">�������ޓ��e</param>
        /// <returns>���ʃR�[�h�i=0�F����j</returns>
        private int WriteOperationStDB(SettingDataSet.SettingRow writingRow)
        {
            OperationStWork writingCondition = GetWritingCondition(writingRow);
            {
                // LimitDiv         = { 0:���O 1:�s�� }
                // OperationLimit   = { 0:�� 1:���O 2:�s��}
                writingCondition.LimitDiv = writingRow.OperationLimit - 1;
            }

            ArrayList writingConditionList = new ArrayList();
            writingConditionList.Add(writingCondition);

            object objWritingConditionList = writingConditionList;

            int status = OperationSettingMasterDB.RealAccesser.Write(ref objWritingConditionList);
            if (status.Equals((int)DBAccessStatus.RecordIsExisted))
            {
                Debug.WriteLine("\n���ɏ������ݍς݂̃��R�[�h���X�V���܂����B");
                status = (int)DBAccessStatus.Normal;
            }
            else if (!status.Equals((int)DBAccessStatus.Normal))
            {
                Debug.Assert(false, "�������݂Ɏ��s�I�F[" + writingRow.PgId + "]�G" + status.ToString());
            }
            Debug.WriteLine("[" + DateTime.Now.ToString() + "]�������݂ɐ����I\n");

            return status;
        }

        /// <summary>
        /// �I�y���[�V�����ݒ�}�X�^DB����폜���܂��B
        /// </summary>
        /// <param name="deletingRow">�폜������e</param>
        /// <returns>���ʃR�[�h�i=0�F����j</returns>
        private int DeleteOperationStDBPhysically(SettingDataSet.SettingRow deletingRow)
        {
            ArrayList deletingCondition = new ArrayList();
            deletingCondition.Add(GetWritingCondition(deletingRow));

            object objDeletingCondition = deletingCondition;
            
            int status = OperationSettingMasterDB.RealAccesser.Delete(objDeletingCondition);
            if (!status.Equals((int)DBAccessStatus.Normal))
            {
                Debug.Assert(false, "�����폜�Ɏ��s�I");
            }
            Debug.WriteLine("�����폜�ɐ����I");

            return status;
        }

        #region <�X�V�i�폜�j�����̍\�z/>

        /// <summary>
        /// �I�y���[�V�����ݒ�}�X�^DB�̃v���C�}���L�[��where����擾���܂��B
        /// </summary>
        /// <param name="writingRow">����</param>
        /// <returns>�I�y���[�V�����ݒ�}�X�^DB�̃v���C�}���L�[��where��</returns>
        private string GetWhereOperationSettingMasterPrimaryKey(SettingDataSet.SettingRow writingRow)
        {
            StringBuilder sqlWhere = new StringBuilder();
            {
                // ��ƃR�[�h
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.EnterpriseCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(ADOUtil.GetString(writingRow.EnterpriseCode));

                sqlWhere.Append(ADOUtil.AND);

                // �J�e�S���R�[�h
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.CategoryCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(writingRow.CategoryCode);

                sqlWhere.Append(ADOUtil.AND);

                // �v���O����ID
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.PgId);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(ADOUtil.GetString(writingRow.PgId));

                sqlWhere.Append(ADOUtil.AND);

                // �I�y���[�V�����R�[�h
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.OperationCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(writingRow.OperationCode);

                sqlWhere.Append(ADOUtil.AND);

                // �������x��1
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.AuthorityLevel1);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(writingRow.AuthorityLevel1);

                sqlWhere.Append(ADOUtil.AND);

                // �������x��2
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.AuthorityLevel2);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(writingRow.AuthorityLevel2);

                sqlWhere.Append(ADOUtil.AND);

                // �]�ƈ��R�[�h
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.EmployeeCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(ADOUtil.GetString(writingRow.EmployeeCode));
            }
            return sqlWhere.ToString();
        }

        /// <summary>
        /// �I�y���[�V�����ݒ�}�X�^DB�ɏ������ރ��R�[�h���擾���܂��B
        /// </summary>
        /// <param name="writingRow">�������ޓ��e</param>
        /// <returns>�I�y���[�V�����ݒ�}�X�^DB�ɏ������ރ��R�[�h</returns>
        private OperationStWork GetWritingCondition(SettingDataSet.SettingRow writingRow)
        {
            // �v���C�}���L�[�Ō���
            DataRow[] foundRows = OperationSettingMasterDB.Tbl.Select(
                GetWhereOperationSettingMasterPrimaryKey(writingRow)
            );
            OperationStWork writingRecord = new OperationStWork();
            if (foundRows.Length > 0)
            {
                Debug.WriteLine("\n���ɓo�^����Ă��郌�R�[�h���X�V���܂��B");
                // �v���C�}���L�[�Ō��������̂ŁA�P��s�ƂȂ�
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
                Debug.WriteLine("\n���R�[�h��V�K�o�^���܂��B");

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

        #endregion  // <�X�V�i�폜�j�����̍\�z/>

        #endregion  // <�I�y���[�V�����ݒ�}�X�^��������/>

        /// <summary>
        /// �������x�����̂��擾���܂��B
        /// </summary>
        /// <param name="authorityLevelDiv">�������x���敪</param>
        /// <returns>�������x������</returns>
        private static string GetAuthorityLevelName(AuthorityLevelMasterDataSet.AuthorityLevelDiv authorityLevelDiv)
        {
            switch (authorityLevelDiv)
            {
                case AuthorityLevelMasterDataSet.AuthorityLevelDiv.JobType:
                    return "�Ɩ�";      // LITERAL:
                case AuthorityLevelMasterDataSet.AuthorityLevelDiv.EmploymentForm:
                    return "����";  // LITERAL:
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// ���쌠����������
        /// </summary>
        /// <param name="operationLimit"></param>
        /// <returns></returns>
        private static string OperationLimitToStr(OperationLimit operationLimit)
        {
            switch (operationLimit)
            {
                case OperationLimit.Disable:
                    return "�~";
                default:
                    return "��";
            }
        }

        /// <summary>
        /// �����񁨑��쌠��
        /// </summary>
        /// <param name="operatiomlimitMark"></param>
        /// <returns></returns>
        private static OperationLimit StrToOperationLimit(string operatiomlimitMark)
        {

            switch (operatiomlimitMark)
            {
                case "�~":
                    return OperationLimit.Disable;
                default:
                    return OperationLimit.EnableWithLog;
            }
        }

        /// <summary>
        /// ���̑��쌠���擾
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
        /// ���̑��쌠���擾
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
