//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���쌠���ݒ�A�N�Z�X
// �v���O�����T�v   : �������x���}�X�^���[�J���A�N�Z�X�̃A�N�Z�X���ʂ�ێ����܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/07/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using DBAccessType  = AuthorityLevelLcDB;
    using DBRecordType  = AuthorityLevel;
    using DataSetType   = AuthorityLevelMasterDataSet;
    using DataTableType = AuthorityLevelMasterDataSet.AuthorityLevelMasterDataTable;
    using DataRowType   = AuthorityLevelMasterDataSet.AuthorityLevelMasterRow;

    using JobTypeDataSet    = AuthorityLevelMasterDataSet;
    using JobTypeDataTable  = AuthorityLevelMasterDataSet.AuthorityLevelMasterDataTable;

    using EmploymentFormDataSet     = AuthorityLevelMasterDataSet;
    using EmploymentFormDataTable   = AuthorityLevelMasterDataSet.AuthorityLevelMasterDataTable;

    /// <summary>
    /// �������x���}�X�^���[�J���A�N�Z�X�N���X�̑㗝�l�N���X
    /// </summary>
    public sealed class AuthorityLevelLcDBAgent : DBAccessAgent<DBAccessType, DBRecordType, DataSetType>, IDisposable
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
                if (_jobTypeTbl != null)
                {
                    _jobTypeTbl.Dispose();
                    _jobTypeTbl = null;
                }
                if (_employmentFormTbl != null)
                {
                    _employmentFormTbl.Dispose();
                    _employmentFormTbl = null;
                }
            }
            // �A���}�l�[�W�I�u�W�F�N�g
        }

        /// <summary>
        /// �f�X�g���N�^
        /// </summary>
        ~AuthorityLevelLcDBAgent()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        #region <�E��/>

        /// <summary>�E��f�[�^�e�[�u��</summary>
        private DataTableType _jobTypeTbl;
        /// <summary>
        /// �E��f�[�^�e�[�u�����擾���܂��B
        /// </summary>
        /// <value>�E��f�[�^�e�[�u��</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataTableType JobTypeTbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_jobTypeTbl == null)
                {
                    string sqlWhere = JobTypeDataSet.ClmIdx.AuthorityLevelDiv.ToString();
                    sqlWhere += ADOUtil.EQ;
                    sqlWhere += ((int)JobTypeDataSet.AuthorityLevelDiv.JobType).ToString();

                    _jobTypeTbl = ADOUtil.CreateDataTable<JobTypeDataTable>(Tbl.Select(sqlWhere));
                }
                return _jobTypeTbl;
            }
        }

        /// <summary>
        /// �E�햼���擾���܂��B
        /// </summary>
        /// <remarks>
        /// �Y�������Ȃ��ꍇ�A<code>string.Empty</code>��Ԃ��܂��B
        /// </remarks>
        /// <param name="authorityLivelCd">�������x���R�[�h</param>
        /// <returns>�E�햼</returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public string GetJobTypeName(int authorityLivelCd)
        {
            #region <Guard Phrase/>
            
            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");
            
            #endregion  // <Guard Phrase/>
            
            return GetAuthorityLevelName(JobTypeTbl, authorityLivelCd);
        }

        #endregion  // <�E��/>

        #region <�ٗp�`��/>

        /// <summary>�ٗp�`�ԃf�[�^�e�[�u��</summary>
        private EmploymentFormDataTable _employmentFormTbl;
        /// <summary>
        /// �ٗp�`�ԃf�[�^�e�[�u�����擾���܂��B
        /// </summary>
        /// <value>�ٗp�`�ԃf�[�^�e�[�u��</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public EmploymentFormDataTable EmploymentFormTbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_employmentFormTbl == null)
                {
                    string sqlWhere = EmploymentFormDataSet.ClmIdx.AuthorityLevelDiv.ToString();
                    sqlWhere += ADOUtil.EQ;
                    sqlWhere += ((int)EmploymentFormDataSet.AuthorityLevelDiv.EmploymentForm).ToString();

                    _employmentFormTbl = ADOUtil.CreateDataTable<EmploymentFormDataTable>(Tbl.Select(sqlWhere));
                }
                return _employmentFormTbl;
            }
        }

        /// <summary>
        /// �ٗp�`�Ԗ����擾���܂��B
        /// </summary>
        /// <remarks>
        /// �Y�������Ȃ��ꍇ�A<code>string.Empty</code>��Ԃ��܂��B
        /// </remarks>
        /// <param name="authorityLivelCd">�������x���R�[�h</param>
        /// <returns>�ٗp�`�Ԗ�</returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public string GetEmploymentFormName(int authorityLivelCd)
        {
            #region <Guard Phrase/>
            
            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");
            
            #endregion  // <Guard Phrase/>
            
            return GetAuthorityLevelName(EmploymentFormTbl, authorityLivelCd);
        }

        #endregion  // <�ٗp�`��/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public AuthorityLevelLcDBAgent() : base() { }

        /// <summary>
        /// �������x���}�X�^DB�̃f�[�^�e�[�u�����擾���܂��B
        /// </summary>
        /// <value>�������x���}�X�^DB�̃f�[�^�e�[�u��</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataTableType Tbl
        {
            get
            {
                #region <Guard Phrase/>
                
                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");
                
                #endregion  // <Guard Phrase/>

                return base.DB.AuthorityLevelMaster;
            }
        }

        /// <summary>
        /// �������x���}�X�^DB�̃��R�[�h���X�g�����������܂��B
        /// </summary>
        /// <remarks>
        /// �������x���}�X�^DB���ȉ��̏����̃��R�[�h���擾���܂��B<br/>
        /// �E�������x���敪 = 0�F�E��<br/>
        /// �E�������x���敪 = 1�F�ٗp�`��
        /// </remarks>
        protected override void Initialize()
        {
            RecordList.Clear();

            // �A�N�Z�X������ݒ�
            List<DBRecordType> searchingConditionList = new List<DBRecordType>();
            {
                // TODO:�������ɍ��킹�ďC��
                DBRecordType condition1 = new DBRecordType();
                condition1.AuthorityLevelDiv = (int)DataSetType.AuthorityLevelDiv.JobType;
                searchingConditionList.Add(condition1);

                DBRecordType condition2 = new DBRecordType();
                condition2.AuthorityLevelDiv = (int)DataSetType.AuthorityLevelDiv.EmploymentForm;
                searchingConditionList.Add(condition2);
                // ��
            }

            #region <�قڂ���/>

            foreach (DBRecordType searchingCondition in searchingConditionList)
            {
                // �A�N�Z�X���ʁi�߂�l�j��ݒ�
                ArrayList searchedRecordList = new ArrayList();

                // �����p�p�����[�^��ݒ�
                object objSearchedRecordList = searchedRecordList;
                object objSearchingCondition = searchingCondition;
                // ����
                int status = RealAccesser.Search(
                    ref objSearchedRecordList,
                    objSearchingCondition,
                    (int)DBAccessParameterNumber.Default,   // TODO:�K�v�ɉ�����
                    ConstantManagement.LogicalMode.GetData0 // TODO:�K�v�ɉ�����
                );
                if (status.Equals((int)DBAccessStatus.NoRecord)) continue;   // �Y���f�[�^�Ȃ�

                #region <Debug/>

                Debug.Assert(status.Equals((int)DBAccessStatus.Normal), MsgUtil.GetMsg(status, searchingCondition.AuthorityLevelDiv));

                #endregion  // <Debug/>

                // �Y���f�[�^����
                searchedRecordList = (ArrayList)objSearchedRecordList;  // TODO:���[�J���A�N�Z�X���ŐV����new���Ă���
                foreach (object objSearchedRecord in searchedRecordList)
                {
                    DBRecordType searchedRecord = (DBRecordType)objSearchedRecord;
                    RecordList.Add(searchedRecord);

                    Tbl.AddAuthorityLevelMasterRow(
                        DateTimeUtil.ToDateTime(searchedRecord.OfferDate),
                        searchedRecord.AuthorityLevelDiv,
                        searchedRecord.AuthorityLevelCd,
                        searchedRecord.AuthorityLevelNm
                    );
                }
            }

            #endregion  // <�قڂ���/>
        }

        /// <summary>
        /// �������x�����̂��擾���܂��B
        /// </summary>
        /// <remarks>
        /// �Y�������Ȃ��ꍇ�A<code>string.Empty</code>��Ԃ��܂��B
        /// </remarks>
        /// <param name="table">�������x���}�X�^DB�̃f�[�^�e�[�u��</param>
        /// <param name="authorityLivelCd">�������x���R�[�h</param>
        /// <returns>�������x������</returns>
        private static string GetAuthorityLevelName(
            DataTableType table,
            int authorityLivelCd
        )
        {
            string sqlWhere = DataSetType.ClmIdx.AuthorityLevelCd.ToString();
            sqlWhere += ADOUtil.EQ + authorityLivelCd.ToString();

            DataRow[] foundRows = table.Select(sqlWhere);
            if (foundRows.Length > 0)
            {
                const int SINGLE_ROW = 0;   // �P��s
                return ((DataRowType)foundRows[SINGLE_ROW]).AuthorityLevelNm;
            }
            return string.Empty;
        }
    }
}
