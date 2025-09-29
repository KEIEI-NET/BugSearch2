//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���쌠���擾���i
// �v���O�����T�v   : �ȉ��̃N���X��Facade(����)�ƂȂ�܂��B
//                  : �E�I�y���[�V�����ݒ�}�X�^�����[�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/08/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
//#define ASSERTION

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    using DBAccessType  = IOperationStDB;
    using DBRecordType  = OperationStWork;
    using DataSetType   = OperationSettingMasterDataSet;
    using DataTableType = OperationSettingMasterDataSet.OperationSettingMasterDataTable;
    using DataRowType   = OperationSettingMasterDataSet.OperationSettingMasterRow;

    #region <�񋓌^/>

    /// <summary>
    /// �I�y���[�V���������i�񋓑́j
    /// </summary>
    public enum OperationLimit : int
    {
        /// <summary>�B�I�y���[�V�����\�Ń��O�������ݕs�v�B</summary>
        Enable = 0,
        /// <summary>��(���O�L�^)�B�I�y���[�V�����\�ŁA���O�������ݕK�v�B</summary>
        EnableWithLog = 1,
        /// <summary>�s�B�I�y���[�V�����͕s�B</summary>
        Disable = 2
    }

    /// <summary>
    /// DB�A�N�Z�X���Ԃ��X�e�[�^�X�l�̗񋓑�
    /// </summary>
    public enum DBAccessStatus : int
    {
        /// <summary>�����Ԃ̒l</summary>
        Normal = (int)ConstantManagement.DB_Status.ctDB_NORMAL,// = 0;
        /// <summary>�Y�����R�[�h�Ȃ�</summary>
        RecordNotFound = 4,
        /// <summary>���R�[�h�����ɑ��݂���</summary>
        RecordIsExisted = 5,
        /// <summary>�Y�����R�[�h�Ȃ�</summary>
        NoRecord = 9,
        /// <summary>�ُ��Ԃ̒l</summary>
        Error = 99,
        /// <summary>�����[�g�G���[</summary>
        RemoteError = 1000
    }

    /// <summary>
    /// DB�A�N�Z�X�̃p�����[�^���l�̗񋓑�
    /// </summary>
    public enum DBAccessParameterNumber
    {
        /// <summary>�f�t�H���g�l</summary>
        Default = 0
    }

    /// <summary>
    /// �J�e�S������
    /// </summary>
    public enum CategoryAttribute : int
    {
        /// <summary>���[���i�Ɩ��j</summary>
        Activity = 0,
        /// <summary>���[���i�����j</summary>
        Authority = 1,
        /// <summary>���̑�</summary>
        Other = 2
    }

    #endregion  // <�񋓌^/>

    /// <summary>
    /// ���쌠���擾���i�N���X
    /// </summary>
    public class OperationLimitation : IDisposable
    {
        #region <IDisposable Member/>

        /// <summary>�����ς݃t���O</summary>
        private bool _disposed;
        /// <summary>
        /// �����ς݃t���O���擾���܂��B
        /// </summary>
        /// <value>��n���ς݃t���O</value>
        public bool Disposed { get { return _disposed; } }

        /// <summary>
        /// �������܂��B
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            _disposed = true;
        }

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="disposing">�}�l�[�W�I�u�W�F�N�g�̏����t���O</param>
        protected virtual void Dispose(bool disposing)
        {
            #region <Guard Phrase/>

            if (Disposed) return;

            #endregion  // <Guard Phrase/>

            // ���}�l�[�W�I�u�W�F�N�g
            if (disposing)
            {
                Reset();
            }
            // ���A���}�l�[�W�I�u�W�F�N�g
        }

        /// <summary>
        /// �f�X�g���N�^
        /// </summary>
        ~OperationLimitation()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        #region <�I�y���[�V�����ݒ�}�X�^DB/>

        /// <summary>�I�y���[�V�����ݒ�}�X�^DB�̃A�N�Z�T</summary>
        private DBAccessType _operationStDBAccesser;
        /// <summary>
        /// �I�y���[�V�����ݒ�}�X�^DB�̃A�N�Z�T���擾���܂��B
        /// </summary>
        /// <value>�I�y���[�V�����ݒ�}�X�^DB�̃A�N�Z�T</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        protected DBAccessType OperationStDBAccesser
        {
            get
            {
                #region <Guard Phrase/>
                
                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_operationStDBAccesser == null)
                {
                    _operationStDBAccesser = MediationOperationStDB.GetOperationStDB();
                }
                return _operationStDBAccesser;
            }
        }

        #endregion  // <�I�y���[�V�����ݒ�}�X�^DB/>

        /// <summary>�S�J�e�S����\���v���O����ID</summary>
        public const string ALL_CATEGORY_ID = "";

        #region <�A�N�Z�T/>

        /// <summary>
        /// ��ƃR�[�h���擾���܂��B
        /// </summary>
        /// <remarks>��2�� + ��2�� + �Ǝ�2�� + ���[�U�[�R�[�h10��</remarks>
        /// <value>��ƃR�[�h</value>
        protected static string EnterpriseCode
        {
            get { return LoginInfoAcquisition.EnterpriseCode; }
        }

        /// <summary>�I�y���[�V�����ݒ�}�X�^DB�̃f�[�^�Z�b�g</summary>
        private DataSetType _operationSettingMasterDB;
        /// <summary>
        /// �I�y���[�V�����ݒ�}�X�^DB�̃f�[�^�Z�b�g���擾���܂��B
        /// </summary>
        /// <value>�I�y���[�V�����ݒ�}�X�^DB�̃f�[�^�Z�b�g</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        protected DataSetType OperationSettingMasterDB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_operationSettingMasterDB == null)
                {
                    _operationSettingMasterDB = new DataSetType();
                }
                return _operationSettingMasterDB;
            }
        }

        /// <summary>
        /// �I�y���[�V�����ݒ�}�X�^DB�̃f�[�^�e�[�u�����擾���܂��B
        /// </summary>
        /// <value>�I�y���[�V�����ݒ�}�X�^DB�̃f�[�^�e�[�u��</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        protected DataTableType MainTbl
        {
            get
            {             
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return OperationSettingMasterDB.OperationSettingMaster;
            }
        }

        /// <summary>�I�y���[�V�����ݒ�}�X�^DB���R�[�h�̃��X�g</summary>
        private List<DBRecordType> _operationStWorkList;
        /// <summary>
        /// �I�y���[�V�����ݒ�}�X�^DB���R�[�h�̃��X�g���擾���܂��B
        /// </summary>
        /// <value>�I�y���[�V�����ݒ�}�X�^DB���R�[�h�̃��X�g</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        protected List<DBRecordType> OperationStWorkList
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_operationStWorkList == null)
                {
                    _operationStWorkList = new List<DBRecordType>();
                    foreach (DataRowType row in MainTbl)
                    {
                        DBRecordType record = new DBRecordType();

                        record.CreateDateTime = row.CreateDateTime;
                        record.UpdateDateTime = row.UpdateDateTime;
                        record.EnterpriseCode = row.EnterpriseCode;
                        record.FileHeaderGuid = row.FileHeaderGuid;
                        record.UpdEmployeeCode = row.UpdEmployeeCode;
                        record.UpdAssemblyId1 = row.UpdAssemblyId1;
                        record.UpdAssemblyId2 = row.UpdAssemblyId2;
                        record.LogicalDeleteCode = row.LogicalDeleteCode;
                        record.OperationStDiv = row.OperationStDiv;
                        record.CategoryCode = row.CategoryCode;
                        record.PgId = row.PgId;
                        record.OperationCode = row.OperationCode;
                        record.AuthorityLevel1 = row.AuthorityLevel1;
                        record.AuthorityLevel2 = row.AuthorityLevel2;
                        record.EmployeeCode = row.EmployeeCode;
                        record.LimitDiv = row.LimitDiv;
                        record.LimitDiv = row.ApplyStartDate;
                        record.ApplyEndDate = row.ApplyEndDate;

                        _operationStWorkList.Add(record);
                    }
                }
                return _operationStWorkList;
            }
        }

        #endregion  // <�A�N�Z�T/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public OperationLimitation() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// �I�y���[�V�����������擾���܂��B
        /// </summary>
        /// <param name="limitDivOfOperationSettingMaster">�I�y���[�V�����ݒ�}�X�^�̐����敪(0:���O 1:����)</param>
        /// <returns>�I�y���[�V�����ݒ�}�X�^�̐����敪 + 1</returns>
        /// <exception cref="InvalidCastException">0:���O �܂��� 1:���� �ȊO�̐����敪���w�肵�܂����B</exception>
        protected static OperationLimit GetOperationLimit(int limitDivOfOperationSettingMaster)
        {
            #region <Guard Phrase/>

            switch ((DataSetType.LimitDiv)limitDivOfOperationSettingMaster)
            {
                case DataSetType.LimitDiv.WithLog:
                    break;
                case DataSetType.LimitDiv.Limitation:
                    break;
            }

            #endregion // <Guard Phrase/>

            return (OperationLimit)(limitDivOfOperationSettingMaster + 1);
        }

        #region <����������/>

        /// <summary>
        /// �����ǂݍ��ݏ������s���܂��B
        /// </summary>
        /// <remarks>
        /// �N�����v���O��������n���ꂽ�J�e�S���[�R�[�h�A�v���O����OD�����ɁA
        /// ���̃v���O�����ƁA���̃v���O�����̑�����J�e�S���[�Ɋւ���S�I�y���[�V�����̑S�ݒ���擾���܂��B
        /// </remarks>
        /// <param name="categoryCode">�N�����v���O�����̃J�e�S���R�[�h</param>
        /// <param name="pgId">�N�����v���O�����̃v���O����ID</param>
        /// <returns>�����ǂݍ��݂ɐ���������true</returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public bool SearchInitial(
            int categoryCode,
            string pgId
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            Reset();

            try
            {
                // �A�N�Z�X������ݒ�
                DBRecordType searchingCondition = new DBRecordType();
                searchingCondition.EnterpriseCode = EnterpriseCode;

                if (categoryCode >= 0)  // TODO:��ƃR�[�h�݂̂̃X�C�b�`
                {
                    // TODO:��ƃR�[�h�ȊO���w�肷��ƃG���[�ƂȂ�H
                    //searchingCondition.CategoryCode = categoryCode;
                    //searchingCondition.PgId = pgId;
                }

                // �A�N�Z�X���ʁi�߂�l�j��ݒ�
                ArrayList searchedRecordList = new ArrayList();

                // �����p�p�����[�^��ݒ�
                object objSearchedRecordList = searchedRecordList;
                object objSearchingCondition = searchingCondition;
                // ����
                int status = OperationStDBAccesser.Search(
                    ref objSearchedRecordList,
                    objSearchingCondition,
                    (int)DBAccessParameterNumber.Default,   // TODO:�K�v�ɉ�����
                    ConstantManagement.LogicalMode.GetData0 // TODO:�K�v�ɉ�����
                );
                if (status.Equals((int)DBAccessStatus.NoRecord)) return true;   // �Y���f�[�^�Ȃ�

                #region <Debug/>

                #if ASSERTION
                    Debug.Assert(status.Equals((int)DBAccessStatus.Normal), MsgUtil.GetMsg(status, categoryCode, pgId));
                #endif

                #endregion  // <Debug/>

                // �Y���f�[�^����
                searchedRecordList = (ArrayList)objSearchedRecordList;  // TODO:�����[�g�A�N�Z�X���ŐV����new���Ă���
                foreach (object objSearchedRecord in searchedRecordList)
                {
                    DBRecordType searchedRecord = (DBRecordType)objSearchedRecord;

                    MainTbl.AddOperationSettingMasterRow(
                        searchedRecord.CreateDateTime,
                        searchedRecord.UpdateDateTime,
                        searchedRecord.EnterpriseCode,
                        searchedRecord.FileHeaderGuid,
                        searchedRecord.UpdEmployeeCode,
                        searchedRecord.UpdAssemblyId1,
                        searchedRecord.UpdAssemblyId2,
                        searchedRecord.LogicalDeleteCode,
                        searchedRecord.OperationStDiv,
                        searchedRecord.CategoryCode,
                        searchedRecord.PgId,
                        searchedRecord.OperationCode,
                        searchedRecord.AuthorityLevel1,
                        searchedRecord.AuthorityLevel2,
                        searchedRecord.EmployeeCode,
                        searchedRecord.LimitDiv,
                        searchedRecord.ApplyStartDate,
                        searchedRecord.ApplyEndDate
                    );
                }

                return true;
            }
            catch (Exception ex) // HACK:IOperationStDB.Search()���������O�́H
            {
                #region <Debug/>

                #if ASSERTION
                    Debug.Assert(false, ex.ToString());
                #endif
                Debug.WriteLine(ex.ToString());

                #endregion  // <Debug/>

                return false;
            }
        }

        /// <summary>
        /// ���Z�b�g���܂��B
        /// </summary>
        private void Reset()
        {
            if (_operationSettingMasterDB != null) _operationSettingMasterDB.Dispose();
            _operationSettingMasterDB = null;

            if (_operationStWorkList != null) _operationStWorkList.Clear();
            _operationStWorkList = null;
        }

        #endregion  // <����������/>

        #region <���쌠���擾����/>

        /// <summary>
        /// ���쌠���擾�������s���܂��B
        /// </summary>
        /// <remarks>
        /// �@�N�����v���O��������n���ꂽ�J�e�S���[�R�[�h�A�v���O����ID�A�I�y���[�V�����R�[�h�A�]�ƈ��f�[�^�����ɁA
        /// �����ǂݍ��ݏ����Ŏ擾�����f�[�^����Y���f�[�^���������܂��B<br/>
        /// �A�J�e�S���S�̐ݒ�ł���ꍇ�A�J�e�S���S�̂̑��쌠����Ԃ��܂��B
        /// </remarks>
        /// <param name="categoryCode">�N�����̃J�e�S���R�[�h</param>
        /// <param name="pgId">�N�����̃v���O����ID</param>
        /// <param name="operationCode">�Ώۂ̃I�y���[�V�����R�[�h</param>
        /// <param name="employee">�Ώۂ̏]�ƈ��i�N�����̓��O�C���S���҂��w�肷��j</param>
        /// <returns>
        /// �EEnable�F�B�I�y���[�V�����\�Ń��O�������ݕs�v�B�c�Y�����R�[�h����<br/>
        /// �EEnableWithLog�F��(���O�L�^)�B�I�y���[�V�����\�ŁA���O�������ݕK�v�B�c�����敪=0:���O<br/>
        /// �EDisable�F�s�B�I�y���[�V�����͕s�B�c�����敪=1:����
        /// </returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        /// <exception cref="ArgumentNullException">�Ώۂ̏]�ƈ���null�ł��B</exception>
        public OperationLimit GetOperationLimit(
            int categoryCode,
            string pgId,
            int operationCode,
            Employee employee
        )
        {
            #region <Guard Pharse/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");
            if (employee == null) throw new ArgumentNullException("employee is null.");

            #endregion  // <Guard Pharse/>

            DataRowType[] categorySettingRows = GetCategorySettingRows(categoryCode, operationCode, employee.EmployeeCode);
            if (categorySettingRows.Length > 0)
            {
                // �J�e�S���S�̐ݒ肠��i��D��j
                const int SINGLE_ROW = 0;   // �P��s
                return GetOperationLimit(categorySettingRows[SINGLE_ROW].LimitDiv);
                //
            }   // �J�e�S���S�̐ݒ�Ȃ�

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(categoryCode, pgId, operationCode));
            // OperationStDiv=2 AND EmployeeCode='employeeCode'
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationStDiv).Append(ADOUtil.EQ);
            sqlWhere.Append((int)DataSetType.OperationStDiv.EmployeeCode).Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.EmployeeCode).Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(employee.EmployeeCode));

            // �]�ƈ��R�[�h�Ŏ擾
            OperationLimit employeeLimit = GetOperationLimitWhere(sqlWhere.ToString());

            // �E��Ŏ擾
            OperationLimit jobTypeLimit = GetOperationLimitWhereAuthorityLevel1(
                categoryCode,
                pgId,
                operationCode,
                employee.AuthorityLevel1
            );

            // �ٗp�`�ԂŎ擾
            OperationLimit employmentFormLimit = GetOperationLimitWhereAuthorityLevel2(
                categoryCode,
                pgId,
                operationCode,
                employee.AuthorityLevel2
            );

            // �Ȃ� < ���O < ���� �̏��ɍł��d����������L���ɂ���
            return (OperationLimit)Math.Max(
                Math.Max((int)jobTypeLimit, (int)employmentFormLimit),
                (int)employeeLimit
            );
        }

        /// <summary>
        /// �I�y���[�V���������̒l���擾���܂��B
        /// </summary>
        /// <param name="filterExpression">�I�y���[�V�����ݒ�}�X�^DB�������������</param>
        /// <returns>
        /// �I�y���[�V���������̒l<br/>
        /// �EEnable�F�B�I�y���[�V�����\�Ń��O�������ݕs�v�B�c�Y�����R�[�h����<br/>
        /// �EEnableWithLog�F��(���O�L�^)�B�I�y���[�V�����\�ŁA���O�������ݕK�v�B�c�����敪=0:���O<br/>
        /// �EDisable�F�s�B�I�y���[�V�����͕s�B�c�����敪=1:����
        /// </returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        /// <exception cref="InvalidCastException">�I�y���[�V�����ݒ�}�X�^.�����敪�̒l���s���ł��B</exception>
        protected OperationLimit GetOperationLimitWhere(string filterExpression)
        {
            #region <Guard Pharse/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Pharse/>

            DataRow[] foundRows = MainTbl.Select(filterExpression);
            // �Y�����R�[�h����
            if (foundRows.Length.Equals(0)) return OperationLimit.EnableWithLog;

            // �Y�����R�[�h����
            // �������x��1(�E��)�A�������x��2(�ٗp�`��)�A�]�ƈ��R�[�h��3�ґ���̂��߁A�P��s�ƂȂ�
            const int SINGLE_ROW = 0;
            DataRowType foundRow = (DataRowType)foundRows[SINGLE_ROW];

            switch (foundRow.LimitDiv)
            {
                case (int)DataSetType.LimitDiv.WithLog:
                    return OperationLimit.EnableWithLog;

                case (int)DataSetType.LimitDiv.Limitation:
                    return OperationLimit.Disable;

                default:
                    throw new InvalidCastException(
                        "�I�y���[�V�����ݒ�}�X�^.�����敪�̒l���s���ł��B(=" + foundRow.LimitDiv.ToString() + ")"  // LITERAL:
                    );
            }
        }

        /// <summary>
        /// �������x��1(�E��)�̏����ő��쌠�����擾���܂��B
        /// </summary>
        /// <remarks>
        /// �J�e�S���S�̐ݒ�ł���ꍇ�A�J�e�S���S�̂̑��쌠����Ԃ��܂��B
        /// </remarks>
        /// <param name="categoryCode">�N�����̃J�e�S���R�[�h</param>
        /// <param name="pgId">�N�����̃v���O����ID</param>
        /// <param name="operationCode">�Ώۂ̃I�y���[�V�����R�[�h</param>
        /// <param name="jobType">�Ώۂ̌������x��1(�E��)</param>
        /// <returns>
        /// �EEnable�F�B�I�y���[�V�����\�Ń��O�������ݕs�v�B�c�Y�����R�[�h����<br/>
        /// �EEnableWithLog�F��(���O�L�^)�B�I�y���[�V�����\�ŁA���O�������ݕK�v�B�c�����敪=0:���O<br/>
        /// �EDisable�F�s�B�I�y���[�V�����͕s�B�c�����敪=1:����
        /// </returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        protected OperationLimit GetOperationLimitWhereAuthorityLevel1(
            int categoryCode,
            string pgId,
            int operationCode,
            int jobType
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            DataRowType[] categorySettingRows = GetCategorySettingRowsWhatAuthorityLevel1(categoryCode, operationCode, jobType);
            if (categorySettingRows.Length > 0)
            {
                // �J�e�S���S�̐ݒ肠��i��D��j
                const int SINGLE_ROW = 0;   // �P��s
                return GetOperationLimit(categorySettingRows[SINGLE_ROW].LimitDiv);
                //
            }   // �J�e�S���S�̐ݒ�Ȃ�

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(categoryCode, pgId, operationCode));
            // OperationStDiv=0 AND AuthorityLevel1=jobType
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationStDiv);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append((int)DataSetType.OperationStDiv.AuthorityLevel1);
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.AuthorityLevel1);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(jobType);

            return GetOperationLimitWhere(sqlWhere.ToString());
        }

        /// <summary>
        /// �������x��2(�ٗp�`��)�̏����ő��쌠�����擾���܂��B
        /// </summary>
        /// <remarks>
        /// �J�e�S���S�̐ݒ�ł���ꍇ�A�J�e�S���S�̂̑��쌠����Ԃ��܂��B
        /// </remarks>
        /// <param name="categoryCode">�N�����̃J�e�S���R�[�h</param>
        /// <param name="pgId">�N�����̃v���O����ID</param>
        /// <param name="operationCode">�Ώۂ̃I�y���[�V�����R�[�h</param>
        /// <param name="employmentForm">�Ώۂ̌������x��2(�ٗp�`��)</param>
        /// <returns>
        /// �EEnable�F�B�I�y���[�V�����\�Ń��O�������ݕs�v�B�c�Y�����R�[�h����<br/>
        /// �EEnableWithLog�F��(���O�L�^)�B�I�y���[�V�����\�ŁA���O�������ݕK�v�B�c�����敪=0:���O<br/>
        /// �EDisable�F�s�B�I�y���[�V�����͕s�B�c�����敪=1:����
        /// </returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        protected OperationLimit GetOperationLimitWhereAuthorityLevel2(
            int categoryCode,
            string pgId,
            int operationCode,
            int employmentForm
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            DataRowType[] categorySettingRows = GetCategorySettingRowsWhatAuthorityLevel2(categoryCode, operationCode, employmentForm);
            if (categorySettingRows.Length > 0)
            {
                // �J�e�S���S�̐ݒ肠��i��D��j
                const int SINGLE_ROW = 0;   // �P��s
                return GetOperationLimit(categorySettingRows[SINGLE_ROW].LimitDiv);
                //
            }   // �J�e�S���S�̐ݒ�Ȃ�

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(categoryCode, pgId, operationCode));
            // OperationStDiv=1 AND AuthorityLevel2=employmentForm
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationStDiv);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append((int)DataSetType.OperationStDiv.AuthorityLevel2);
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.AuthorityLevel2);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(employmentForm);

            return GetOperationLimitWhere(sqlWhere.ToString());
        }

        #endregion  // <���쌠���擾����/>

        #region <�J�e�S���S�̐ݒ�̃f�[�^�s�̎擾/>

        /// <summary>
        /// �J�e�S���S�̐ݒ�̃f�[�^�s���擾���܂��B
        /// </summary>
        /// <remarks>
        /// �w�肵���J�e�S���R�[�h�̃��R�[�h�Ƀv���O����ID�̒l��<code>string.Empty</code>�̂��̂�����΁A
        /// �J�e�S���S�̐ݒ�ƂȂ�܂��B
        /// </remarks>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="jobType">�������x��1(�E��)</param>
        /// <returns>�J�e�S���S�̐ݒ�̃f�[�^�s�z��</returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        protected DataRowType[] GetCategorySettingRowsWhatAuthorityLevel1(
            int categoryCode,
            int operationCode,
            int jobType
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(categoryCode, ALL_CATEGORY_ID, operationCode));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationStDiv);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append((int)DataSetType.OperationStDiv.AuthorityLevel1);
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.AuthorityLevel1);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(jobType);

            return ADOUtil.ConvertAll<DataRowType>(MainTbl.Select(sqlWhere.ToString()));
        }

        /// <summary>
        /// �J�e�S���S�̐ݒ�̃f�[�^�s���擾���܂��B
        /// </summary>
        /// <remarks>
        /// �w�肵���J�e�S���R�[�h�̃��R�[�h�Ƀv���O����ID�̒l��<code>string.Empty</code>�̂��̂�����΁A
        /// �J�e�S���S�̐ݒ�ƂȂ�܂��B
        /// </remarks>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="employmentForm">�������x��2(�ٗp�`��)</param>
        /// <returns>�J�e�S���S�̐ݒ�̃f�[�^�s�z��</returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        protected DataRowType[] GetCategorySettingRowsWhatAuthorityLevel2(
            int categoryCode,
            int operationCode,
            int employmentForm
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(categoryCode, ALL_CATEGORY_ID, operationCode));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationStDiv);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append((int)DataSetType.OperationStDiv.AuthorityLevel2);
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.AuthorityLevel2);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(employmentForm);

            return ADOUtil.ConvertAll<DataRowType>(MainTbl.Select(sqlWhere.ToString()));
        }

        /// <summary>
        /// �J�e�S���S�̐ݒ�̃f�[�^�s���擾���܂��B
        /// </summary>
        /// <remarks>
        /// �w�肵���J�e�S���R�[�h�̃��R�[�h�Ƀv���O����ID�̒l��<code>string.Empty</code>�̂��̂�����΁A
        /// �J�e�S���S�̐ݒ�ƂȂ�܂��B
        /// </remarks>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�J�e�S���S�̐ݒ�̃f�[�^�s�z��</returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        protected DataRowType[] GetCategorySettingRows(
            int categoryCode,
            int operationCode,
            string employeeCode
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(categoryCode, ALL_CATEGORY_ID, operationCode));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationStDiv);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append((int)DataSetType.OperationStDiv.EmployeeCode);
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.EmployeeCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(employeeCode));

            return ADOUtil.ConvertAll<DataRowType>(MainTbl.Select(sqlWhere.ToString()));
        }

        #endregion  // <�J�e�S���S�̐ݒ�̃f�[�^�s�̎擾/>

        #region <SQL��where��/>

        /// <summary>
        /// ��{where����擾���܂��B
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <returns>��ƃR�[�h AND �J�e�S���[�R�[�h AND �v���O����ID</returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        protected string GetBaseWherePhrase(
            int categoryCode,
            string pgId
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            StringBuilder sqlWhere = new StringBuilder();

            sqlWhere.Append(DataSetType.ClmIdx.EnterpriseCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(EnterpriseCode));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.CategoryCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(categoryCode.ToString());
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.PgId);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(pgId));

            return sqlWhere.ToString();
        }

        /// <summary>
        /// ��{where����擾���܂��B
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>��ƃR�[�h AND �J�e�S���[�R�[�h AND '�v���O����ID' AND �I�y���[�V�����R�[�h</returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        protected string GetBaseWherePhrase(
            int categoryCode,
            string pgId,
            int operationCode
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(categoryCode, pgId));

            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(operationCode.ToString());

            return sqlWhere.ToString();
        }

        #endregion  // <SQL��where��/>

        #region <����/>

        /// <summary>
        /// �T������
        /// </summary>
        [Conditional("DEBUG")]
        public void TestSearch()
        {
            OperationStWork searchingCondition = new OperationStWork();
            searchingCondition.EnterpriseCode = "0101150842020000";
            //searchingCondition.CategoryCode = 1;
            //searchingCondition.PgId = "";

            object objSearchingConditionList = searchingCondition;
            object objSearchedRecordList = null;

            IOperationStDB accesser = MediationOperationStDB.GetOperationStDB();
            int status = accesser.Search(ref objSearchedRecordList, objSearchingConditionList, 0, 0);
            if (!status.Equals(0))
            {
                Debug.Assert(false, (status.Equals(9) ? "���R�[�h�Ȃ�" : "���s�F" + status.ToString()));
            }

            ArrayList searchedRecordList = (ArrayList)objSearchedRecordList;

            Debug.WriteLine("�����F" + searchedRecordList.Count.ToString());
        }

        /// <summary>
        /// ��������
        /// </summary>
        [Conditional("DEBUG")]
        public void TestWrite()
        {
            OperationStWork writingCondition = new OperationStWork();
            {
                writingCondition.EnterpriseCode = "0101150842020000";
                writingCondition.CategoryCode = 1;
                writingCondition.PgId = "MAHNB01010U";
                writingCondition.OperationCode = 0;

                writingCondition.OperationStDiv = 0;

                writingCondition.AuthorityLevel1 = 100;
                writingCondition.AuthorityLevel2 = -1;
                writingCondition.EmployeeCode = "0002";

                writingCondition.LimitDiv = 0;

                writingCondition.ApplyStartDate = 20080807;
                writingCondition.ApplyEndDate = 20081231;
            }

            ArrayList writingConditionList = new ArrayList();
            writingConditionList.Add(writingCondition);

            object objWritingConditionList = writingConditionList;

            IOperationStDB accesser = MediationOperationStDB.GetOperationStDB();
            int status = accesser.Write(ref objWritingConditionList);
            if (status.Equals(5))
            {
                Debug.WriteLine("���ɏ������ݍς݂ł��B");
            }
            else if (!status.Equals(0))  // 5�͊��ɏ����Ă���Ƃ����Ӗ�
            {
                Debug.Assert(false, "���s�F" + status.ToString());
            }

            Debug.WriteLine("\n�I�y��DB�ɏ�������OK!\n");
        }

        #endregion  // <����/>

        #region <Public Static Methods/>

        /// <summary>
        /// �J�e�S���[�����擾
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <returns></returns>
        public static CategoryAttribute GetCategoryAttribute(int categoryCode)
        {
            if (( 0 < categoryCode ) && ( categoryCode < 50 ))
            {
                return CategoryAttribute.Activity;
            }
            else if (( 50 <= categoryCode ) && ( categoryCode < 90 ))
            {
                return CategoryAttribute.Authority;
            }
            else
            {
                return CategoryAttribute.Other;
            }
        }

        #endregion
    }
}
