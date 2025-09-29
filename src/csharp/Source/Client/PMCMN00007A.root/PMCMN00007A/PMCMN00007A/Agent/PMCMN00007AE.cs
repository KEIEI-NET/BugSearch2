//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���쌠���ݒ�A�N�Z�X
// �v���O�����T�v   : �]�ƈ��e�[�u���A�N�Z�X�̃A�N�Z�X���ʂ�ێ����܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/07/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using DBAccessType  = EmployeeAcs;
    using DBRecordType  = Employee;
    using DataSetType   = EmployeeMasterDataSet;
    using DataTableType = EmployeeMasterDataSet.EmployeeMasterDataTable;
    using DataRowType   = EmployeeMasterDataSet.EmployeeMasterRow;

    /// <summary>
    /// �]�ƈ��e�[�u���A�N�Z�X�N���X�̑㗝�l�N���X
    /// </summary>
    public sealed class EmployeeAcsAgent : DBAccessAgent<DBAccessType, DBRecordType, DataSetType>, IDisposable
    {
        #region <IDisposable Member/>

        /// <summary>
        /// �������܂��B
        /// </summary>
        void IDisposable.Dispose()
        {
            base.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="disposing">�}�l�[�W�I�u�W�F�N�g�̏����t���O</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            // �}�l�[�W�I�u�W�F�N�g
            if (disposing)
            {
            }
            // �A���}�l�[�W�I�u�W�F�N�g
        }

        /// <summary>
        /// �f�X�g���N�^
        /// </summary>
        ~EmployeeAcsAgent()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        /// <summary>�_���폜�敪�F�L��</summary>
        private const int ENABLED_RECORD = 0;   // HACK:���ʃt�@�C���w�b�_�i0�F�L���j

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public EmployeeAcsAgent() : base() { }

        /// <summary>
        /// �]�ƈ��}�X�^DB�̃f�[�^�e�[�u�����擾���܂��B
        /// </summary>
        /// <value>�]�ƈ��}�X�^DB�̃f�[�^�e�[�u��</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataTableType Tbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return DB.EmployeeMaster;
            }
        }

        /// <summary>�]�ƈ����R�[�h�}�b�v</summary>
        private Dictionary<string, Employee> _recordMap;
        /// <summary>
        /// �]�ƈ����R�[�h�}�b�v���擾���܂��B
        /// </summary>
        /// <value>�]�ƈ����R�[�h�}�b�v</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public Dictionary<string, Employee> RecordMap
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_recordMap == null)
                {
                    _recordMap = new Dictionary<string, Employee>();
                }
                return _recordMap;
            }
        }

        /// <summary>
        /// �]�ƈ����R�[�h���擾���܂��B
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        public Employee FindRecord(string employeeCode)
        {
            return ( this._recordMap.ContainsKey(employeeCode) ) ? this._recordMap[employeeCode] : null;
        }

        /// <summary>
        /// DB�̏]�ƈ��R�[�h�̃t�H�[�}�b�g�ɕϊ����܂��B
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>9�����i�E�X�y�[�X�l�j</returns>
        public static string ConvertEmployeeCodeInDBFormat(string employeeCode)
        {
            const int LENGTH_OF_DB_CODE = 9;
            const char PADDING_CHAR = ' ';
            return employeeCode.PadRight(LENGTH_OF_DB_CODE, PADDING_CHAR);
        }

        /// <summary>
        /// �]�ƈ��}�X�^DB�̃��R�[�h���X�g�����������܂��B
        /// </summary>
        /// <remarks>
        /// �������x���}�X�^DB���S�]�ƈ��̃��R�[�h���擾���܂��B
        /// </remarks>
        protected override void Initialize()
        {
            RecordList.Clear();
            RecordMap.Clear();

            ArrayList searchedRecordArrayList = null;
            ArrayList searchedRecordDetailedArrayList = null;
            // 2008.12.09 modify start [8657]
            int status = RealAccesser.Search(//SearchAll(
                out searchedRecordArrayList,
                out searchedRecordDetailedArrayList,
                LoginInfoAcquisition.EnterpriseCode
            );
            // 2008.12.09 modify end [8657]

            // �Y���f�[�^�Ȃ�
            if (status.Equals((int)DBAccessStatus.NoRecord)) return;

            #region <Debug/>

            Debug.Assert(status.Equals((int)DBAccessStatus.Normal), MsgUtil.GetMsg(status, LoginInfoAcquisition.EnterpriseCode));

            #endregion  // <Debug/>

            // ���_���
            SecInfoSetAcsAgent sectionDB = new SecInfoSetAcsAgent();

            // �Y���f�[�^����
            foreach (object objSearchedRecord in searchedRecordArrayList)
            {
                DBRecordType searchedRecord = (DBRecordType)objSearchedRecord;
                RecordList.Add(searchedRecord);
                RecordMap.Add(searchedRecord.EmployeeCode, searchedRecord);

                if (!searchedRecord.LogicalDeleteCode.Equals(ENABLED_RECORD)) continue;

                // �������_�����ݒ肳��Ȃ����߁A���_���̂��擾���A�ݒ�
                searchedRecord.BelongSectionName = sectionDB.GetSectionName(searchedRecord.BelongSectionCode);

                Tbl.AddEmployeeMasterRow(
                    searchedRecord.EmployeeCode,
                    searchedRecord.Name,
                    searchedRecord.BelongSectionCode,
                    searchedRecord.BelongSectionName,
                    searchedRecord.AuthorityLevel1,
                    searchedRecord.AuthorityLevel2
                );
            }
        }
    }
}
