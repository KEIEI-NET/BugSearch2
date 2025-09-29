//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���엚���A�N�Z�X
// �v���O�����T�v   : ���엚�������[�g�̃A�N�Z�X���ʂ�ێ����܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/08/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Agent
{
    using DBAccessType      = IOprtnHisLogDB;
    using DBRecordType      = OprtnHisLogWork;
    using DBConditionType   = OprtnHisLogSrchWork;
    using DataSetType       = OperationHistoryLogDataSet;
    using DataTableType     = OperationHistoryLogDataSet.OperationHistoryLogDataTable;
    using DataRowType       = OperationHistoryLogDataSet.OperationHistoryLogRow;

    /// <summary>
    /// ���엚�������[�g�N���X�̑㗝�l�N���X
    /// </summary>
    public sealed class OperationHistoryLogAgent : OperationHistoryLog, IDisposable
    {
        #region <IDisposable Member/>

        /// <summary>�����ς݃t���O</summary>
        private bool _disposed;
        /// <summary>
        /// �����ς݃t���O���擾���܂��B
        /// </summary>
        /// <value>�����ς݃t���O</value>
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
        private void Dispose(bool disposing)
        {
            #region <Guard Phrase/>
            
            if (Disposed) return;

            #endregion  // <Guard Phrase/>

            // �}�l�[�W�I�u�W�F�N�g
            if (disposing)
            {
                Reset();
            }
            // �A���}�l�[�W�I�u�W�F�N�g
        }

        /// <summary>
        /// �f�X�g���N�^
        /// </summary>
        ~OperationHistoryLogAgent()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        #region <�A�N�Z�T/>

        /// <summary>
        /// ���엚���f�[�^DB�̃A�N�Z�T���擾���܂��B
        /// </summary>
        /// <value>���엚���f�[�^DB�̃A�N�Z�T</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DBAccessType RealAccesser
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return base.OprtnHisLogDBAccesser;
            }
        }

        /// <summary>���엚���f�[�^DB�̃��R�[�h���X�g</summary>
        private List<DBRecordType> _recordList;
        /// <summary>
        /// ���엚���f�[�^DB�̃��R�[�h���X�g���擾���܂��B
        /// </summary>
        /// <value>���엚���f�[�^DB�̃��R�[�h���X�g</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public List<DBRecordType> RecordList
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_recordList == null)
                {
                    _recordList = new List<DBRecordType>();
                }
                return _recordList;
            }
        }

        /// <summary>���엚���f�[�^DB�̃f�[�^�Z�b�g</summary>
        private DataSetType _db;
        /// <summary>
        /// ���엚���f�[�^DB�̃f�[�^�Z�b�g���擾���܂��B
        /// </summary>
        /// <value>���엚���f�[�^DB�̃f�[�^�Z�b�g</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataSetType DB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_db == null)
                {
                    _db = new DataSetType();
                }
                return _db;
            }
        }

        /// <summary>
        /// ���엚���f�[�^DB�̃f�[�^�e�[�u�����擾���܂��B
        /// </summary>
        /// <value>���엚���f�[�^DB�̃f�[�^�e�[�u��</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataTableType Tbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return DB.OperationHistoryLog;
            }
        }

        #endregion  // <�A�N�Z�T/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public OperationHistoryLogAgent() : base() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// �ێ����Ă��郍�O�����Z�b�g���܂��B
        /// </summary>
        public void Reset()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
            if (_recordList != null)
            {
                _recordList.Clear();
                _recordList = null;
            }
        }

        /// <summary>
        /// ���O���X�V���܂��B
        /// </summary>
        /// <param name="searchingCondition">�X�V�������</param>
        /// <returns>�X�V�������엚�����O�f�[�^�e�[�u��</returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataTableType RefreshLog(DBConditionType searchingCondition)
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            Reset();

            DBConditionType condition = null;
            if (searchingCondition is LogCondition)
            {
                condition = ((LogCondition)searchingCondition).CreateOprtnHisLogSrchWork();
            }
            else
            {
                condition = searchingCondition;
            }

            // �A�N�Z�X���ʁi�߂�l�j��ݒ�
            ArrayList searchedRecordList = new ArrayList();

            // �����p�p�����[�^��ݒ�
            object objSearchedRecordList = searchedRecordList;
            object objSearchingCondition = condition;

            // ����
            int status = RealAccesser.Search(
                ref objSearchedRecordList,
                objSearchingCondition,
                (int)DBAccessParameterNumber.Default,   // TODO:�K�v�ɉ�����
                ConstantManagement.LogicalMode.GetData0 // TODO:�K�v�ɉ�����
            );
            if (status.Equals((int)DBAccessStatus.NoRecord))        return Tbl; // �Y���f�[�^�Ȃ�
            if (status.Equals((int)DBAccessStatus.RecordNotFound))  return Tbl; // �Y���f�[�^�Ȃ�

            #region <Debug/>

            Debug.Assert(status.Equals(0), MsgUtil.GetMsg(status, ""));
            if (status.Equals(0)) Debug.WriteLine("DB�����F" + ((ArrayList)objSearchedRecordList).Count.ToString());

            #endregion  // <Debug/>

            // �Y���f�[�^����
            searchedRecordList = (ArrayList)objSearchedRecordList;  // TODO:�����[�g�A�N�Z�X���ŐV����new���Ă���
            foreach (object objSearchedRecord in searchedRecordList)
            {
                DBRecordType searchedRecord = (DBRecordType)objSearchedRecord;

                RecordList.Add(searchedRecord);

                Tbl.AddOperationHistoryLogRow(
                    searchedRecord.CreateDateTime,
                    searchedRecord.UpdateDateTime,
                    searchedRecord.EnterpriseCode,
                    searchedRecord.FileHeaderGuid,
                    searchedRecord.UpdEmployeeCode,
                    searchedRecord.UpdAssemblyId1,
                    searchedRecord.UpdAssemblyId2,
                    searchedRecord.LogicalDeleteCode,
                    searchedRecord.LogDataCreateDateTime,
                    searchedRecord.LogDataGuid,
                    searchedRecord.LoginSectionCd,
                    searchedRecord.LogDataKindCd,
                    searchedRecord.LogDataMachineName,
                    searchedRecord.LogDataAgentCd,
                    searchedRecord.LogDataAgentNm,
                    searchedRecord.LogDataObjBootProgramNm,
                    searchedRecord.LogDataObjAssemblyID,
                    searchedRecord.LogDataObjAssemblyNm,
                    searchedRecord.LogDataObjClassID,
                    searchedRecord.LogDataObjProcNm,
                    searchedRecord.LogDataOperationCd,
                    searchedRecord.LogOperaterDtProcLvl,
                    searchedRecord.LogOperaterFuncLvl,
                    searchedRecord.LogDataSystemVersion,
                    searchedRecord.LogOperationStatus,
                    searchedRecord.LogDataMassage,
                    searchedRecord.LogOperationData
                );
            }

            return Tbl;
        }

        #region <����/>

        /// <summary>
        /// �T������
        /// </summary>
        [Conditional("DEBUG")]
        public void TestSearch()
        {
            OprtnHisLogSrchWork searchingCondition = new OprtnHisLogSrchWork();
            searchingCondition.EnterpriseCode = "0101150842020000";
            searchingCondition.St_LogDataCreateDateTime = new DateTime(2008, 8, 1, 0, 0, 0);
            searchingCondition.Ed_LogDataCreateDateTime = new DateTime(2008, 8, 31, 23, 59, 59);
            searchingCondition.LogDataKindCd = (int)LogDataKind.OperationLog;

            // �A�N�Z�X���ʁi�߂�l�j��ݒ�
            ArrayList searchedRecordList = new ArrayList();

            // �����p�p�����[�^��ݒ�
            object objSearchedRecordList = searchedRecordList;
            object objSearchingCondition = searchingCondition;
            // ����
            IOprtnHisLogDB accesser = MediationOprtnHisLogDB.GetOprtnHisLogDB();
            int status = accesser.Search(
                ref objSearchedRecordList,
                objSearchingCondition,
                0,
                0
            );
            if (status.Equals(9))
            {
                Debug.WriteLine("���O�����F0");
                return;
            }

            #region <Debug/>

            Debug.Assert(status.Equals(0), MsgUtil.GetMsg(status, ""));

            #endregion  // <Debug/>

            // �Y���f�[�^����
            searchedRecordList = (ArrayList)objSearchedRecordList;  // TODO:�����[�g�A�N�Z�X���ŐV����new���Ă���

            Debug.WriteLine("���O�����F" + searchedRecordList.Count.ToString());
            
        }

        #endregion  // <����/>
    }
}
