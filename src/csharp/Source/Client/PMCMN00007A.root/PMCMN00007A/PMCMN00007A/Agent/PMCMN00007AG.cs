//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���쌠���ݒ�A�N�Z�X
// �v���O�����T�v   : �I�y���[�V�����}�X�^���[�J���A�N�Z�X�̃A�N�Z�X���ʂ�ێ����܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/07/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2010/04/02  �C�����e : �Z�L�����e�B�Ǘ����i�̍��������ǑΉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Application.LocalAccess;
//using Broadleaf.Application.Common.Util;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Agent
{
    using DBAccessType  = OperationLcDB;
    using DBRecordType  = Operation;
    using DataSetType   = OperationMasterDataSet;
    using DataTableType = OperationMasterDataSet.OperationMasterDataTable;
    using DataRowType   = OperationMasterDataSet.OperationMasterRow;

    /// <summary>
    /// �I�y���[�V�����}�X�^���[�J���A�N�Z�X�N���X�̑㗝�l�N���X
    /// </summary>
    /// <br>Update Note: 2010/04/02 ������ �Z�L�����e�B�Ǘ����i�̍��������ǑΉ�</br>
    public sealed class OperationLcDBAgent : DBAccessAgent<DBAccessType, DBRecordType, DataSetType>, IDisposable
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
        ~OperationLcDBAgent()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        /// <summary>�S�ẴA�C�e�����Ӗ����鐔�l</summary>
        private const int ALL_ITEM = -1;

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public OperationLcDBAgent() : base() { }

        /// <summary>
        /// �I�y���[�V�����}�X�^DB�̃f�[�^�e�[�u�����擾���܂��B
        /// </summary>
        /// <value>�I�y���[�V�����}�X�^DB�̃f�[�^�e�[�u��</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataTableType Tbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return DB.OperationMaster;
            }
        }

        #region <�J�e�S��/>

        /// <summary>�J�e�S�����܂Ƃ߂��f�[�^�e�[�u��</summary>
        private DataTableType _categoryTbl;
        /// <summary>
        /// �J�e�S�����܂Ƃ߂��f�[�^�e�[�u�����擾���܂��B
        /// </summary>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataTableType CategoryTbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_categoryTbl == null)
                {
                    _categoryTbl = new DataTableType();

                    Dictionary<int, DataRowType> entryRowMap = new Dictionary<int, DataRowType>();
                    foreach (DataRowType opeRow in Tbl)
                    {
                        if (!entryRowMap.ContainsKey(opeRow.CategoryCode))
                        {
                            entryRowMap.Add(opeRow.CategoryCode, opeRow);
                            _categoryTbl.AddOperationMasterRow(
                                opeRow.OfferDate,
                                opeRow.CategoryCode,
                                opeRow.CategoryName,
                                opeRow.CategoryDspOdr,
                                opeRow.PgId,
                                opeRow.PgName,
                                opeRow.PgDspOdr,
                                opeRow.OperationCode,
                                opeRow.OperationName,
                                opeRow.OperationDspOdr
                            );
                        }
                    }
                }
                return _categoryTbl;
            }
        }

        /// <summary>
        /// �J�e�S�����擾���܂��B
        /// </summary>
        /// <param name="pgId">�v���O����ID</param>
        /// <returns>�J�e�S��</returns>
        public CodeNamePair<int> GetCategory(string pgId)
        {
            StringBuilder sqlWhere = new StringBuilder();
            sqlWhere.Append(DataSetType.ClmIdx.PgId);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(pgId));

            DataRow[] foundRows = Tbl.Select(sqlWhere.ToString());
            if (foundRows.Length > 0)
            {
                return new CodeNamePair<int>(
                    ((DataRowType)foundRows[0]).CategoryCode,
                    ((DataRowType)foundRows[0]).CategoryName
                );
            }
            else
            {
                return new CodeNamePair<int>(
                    ALL_ITEM,   // HACK:
                    string.Empty
                );
            }
        }

        #endregion  // <�J�e�S��/>

        #region <�@�\/>

        /// <summary>�@�\���܂Ƃ߂��f�[�^�e�[�u��</summary>
        private DataTableType _pgTbl;
        /// <summary>
        /// �@�\���܂Ƃ߂��f�[�^�e�[�u�����擾���܂��B
        /// </summary>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataTableType PgTbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_pgTbl == null)
                {
                    _pgTbl = GetPgTblWhere(ALL_ITEM);
                }
                return _pgTbl;
            }
        }

        /// <summary>
        /// �@�\�f�[�^�e�[�u�����擾���܂��B
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <returns>�@�\�f�[�^�e�[�u��</returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataTableType GetPgTblWhere(int categoryCode)
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            DataTableType pgTbl = new DataTableType();
            Dictionary<string, DataRowType> entryRowMap = new Dictionary<string, DataRowType>();

            StringBuilder sqlWhere = new StringBuilder();
            if (categoryCode >= 0)
            {
                sqlWhere.Append(DataSetType.ClmIdx.CategoryCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(categoryCode);
            }

            DataRow[] foundDataRows = Tbl.Select(sqlWhere.ToString());
            foreach (DataRow foundDataRow in foundDataRows)
            {
                DataRowType opeRow = (DataRowType)foundDataRow;
                if (!entryRowMap.ContainsKey(opeRow.PgId))
                {
                    entryRowMap.Add(opeRow.PgId, opeRow);
                    pgTbl.AddOperationMasterRow(
                        opeRow.OfferDate,
                        opeRow.CategoryCode,
                        opeRow.CategoryName,
                        opeRow.CategoryDspOdr,
                        opeRow.PgId,
                        opeRow.PgName,
                        opeRow.PgDspOdr,
                        opeRow.OperationCode,
                        opeRow.OperationName,
                        opeRow.OperationDspOdr
                    );
                }
            }
            return pgTbl;
        }

        /// <summary>
        /// �v���O�������̂��擾���܂��B
        /// </summary>
        /// <param name="pgId">�v���O����ID</param>
        /// <returns>�v���O��������</returns>
        public string GetProgramName(string pgId)
        {
            StringBuilder sqlWhere = new StringBuilder();
            sqlWhere.Append(DataSetType.ClmIdx.PgId);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(pgId));

            DataRow[] foundRows = Tbl.Select(sqlWhere.ToString());
            if (foundRows.Length > 0)
            {
                return ((DataRowType)foundRows[0]).PgName;
            }
            else
            {
                return pgId;
            }
        }

        #endregion  // <�@�\/>

        #region <����/>

        #region <�p�~�\��/>

        /// <summary>������܂Ƃ߂��f�[�^�e�[�u��</summary>
        private DataTableType _operationTbl;
        /// <summary>
        /// ������܂Ƃ߂��f�[�^�e�[�u�����擾���܂��B
        /// </summary>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        [Obsolete("�I�y���[�V�����R�[�h�͊e�@�\�ŔC�ӂł��邽�߁A���j�[�N�ȃe�[�u���ɂ͂Ȃ�܂���B")]
        public DataTableType OperationTbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_operationTbl == null)
                {
                    _operationTbl = new DataTableType();

                    Dictionary<int, DataRowType> entryRowMap = new Dictionary<int, DataRowType>();
                    foreach (DataRowType opeRow in Tbl)
                    {
                        if (!entryRowMap.ContainsKey(opeRow.OperationCode))
                        {
                            entryRowMap.Add(opeRow.OperationCode, opeRow);
                            _operationTbl.AddOperationMasterRow(
                                opeRow.OfferDate,
                                opeRow.CategoryCode,
                                opeRow.CategoryName,
                                opeRow.CategoryDspOdr,
                                opeRow.PgId,
                                opeRow.PgName,
                                opeRow.PgDspOdr,
                                opeRow.OperationCode,
                                opeRow.OperationName,
                                opeRow.OperationDspOdr
                            );
                        }
                    }
                }
                return _operationTbl;
            }
        }

        /// <summary>
        /// ����f�[�^�e�[�u�����擾���܂��B
        /// </summary>
        /// <param name="pgId">�v���O����ID</param>
        /// <returns>����f�[�^�e�[�u��</returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        [Obsolete("�J�e�S���R�[�h���w�肵���������S�ł��B")]
        public DataTableType GetOperationTblWhere(string pgId)
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            DataTableType opeTbl = new DataTableType();
            Dictionary<int, DataRowType> entryRowMap = new Dictionary<int, DataRowType>();

            StringBuilder sqlWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(pgId))
            {
                sqlWhere.Append(DataSetType.ClmIdx.PgId);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(ADOUtil.GetString(pgId));
            }

            DataRow[] foundDataRows = Tbl.Select(sqlWhere.ToString());
            foreach (DataRow foundDataRow in foundDataRows)
            {
                DataRowType opeRow = (DataRowType)foundDataRow;
                if (!entryRowMap.ContainsKey(opeRow.OperationCode))
                {
                    entryRowMap.Add(opeRow.OperationCode, opeRow);
                    opeTbl.AddOperationMasterRow(
                        opeRow.OfferDate,
                        opeRow.CategoryCode,
                        opeRow.CategoryName,
                        opeRow.CategoryDspOdr,
                        opeRow.PgId,
                        opeRow.PgName,
                        opeRow.PgDspOdr,
                        opeRow.OperationCode,
                        opeRow.OperationName,
                        opeRow.OperationDspOdr
                    );
                }
            }
            return opeTbl;
        }

        #endregion  // <�p�~�\��/>

        /// <summary>
        /// �ݒ�Ώۂ̃I�y���[�V�����R�[�h���`�F�b�N���܂��B
        /// </summary>
        /// <param name="categoryCode">�J�e�S���[�R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>True:�ݒ�Ώ�</returns>
        public bool IsTargetOperation(int categoryCode, string pgId, int operationCode)
        {
            DataRowType pgSettingRow = this.GetOperationSetting(categoryCode, pgId, operationCode);
            if (pgSettingRow != null) return true;

            DataRowType categorySettingRow = this.GetOperationSetting(categoryCode, OperationLimitation.ALL_CATEGORY_ID, operationCode);

            if (categorySettingRow != null) return true;

            return false;
        }

        /// <summary>
        /// ����e�[�u��
        /// </summary>
        /// <param name="categoryCode">�J�e�S���[�R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>����e�[�u���s</returns>
        private DataRowType GetOperationSetting(int categoryCode, string pgId, int operationCode)
        {
            StringBuilder sqlWhere = new StringBuilder();
            sqlWhere.Append(DataSetType.ClmIdx.CategoryCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(categoryCode);
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.PgId);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(pgId));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(operationCode);

            DataRowType[] foundRows = (DataRowType[])Tbl.Select(sqlWhere.ToString());
            if (foundRows.Length > 0)
            {
                return foundRows[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ����f�[�^�e�[�u�����擾���܂��B
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <returns>����f�[�^�e�[�u��</returns>
        public DataTableType GetOperationTblWhere(
            int categoryCode,
            string pgId
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            DataTableType opeTbl = new DataTableType();

            StringBuilder sqlWhere = new StringBuilder();
            if (categoryCode >= 0)
            {
                sqlWhere.Append(DataSetType.ClmIdx.CategoryCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(categoryCode);
                sqlWhere.Append(ADOUtil.AND);
            }
            sqlWhere.Append(DataSetType.ClmIdx.PgId);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(pgId));

            DataRow[] foundDataRows = Tbl.Select(sqlWhere.ToString());
            foreach (DataRow foundDataRow in foundDataRows)
            {
                DataRowType opeRow = (DataRowType)foundDataRow;
                opeTbl.AddOperationMasterRow(
                    opeRow.OfferDate,
                    opeRow.CategoryCode,
                    opeRow.CategoryName,
                    opeRow.CategoryDspOdr,
                    opeRow.PgId,
                    opeRow.PgName,
                    opeRow.PgDspOdr,
                    opeRow.OperationCode,
                    opeRow.OperationName,
                    opeRow.OperationDspOdr
                );
            }

            return opeTbl;
        }

        /// <summary>
        /// �I�y���[�V�������̂��擾���܂��B
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>�I�y���[�V��������</returns>
        public string GetOperationName(
            int categoryCode,
            string pgId,
            int operationCode
        )
        {
            StringBuilder sqlWhere = new StringBuilder();
            sqlWhere.Append(DataSetType.ClmIdx.CategoryCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(categoryCode);
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.PgId);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(pgId));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(operationCode);

            DataRow[] foundRows = Tbl.Select(sqlWhere.ToString());
            if (foundRows.Length > 0)
            {
                return ((DataRowType)foundRows[0]).OperationName;
            }
            else
            {
                return operationCode.ToString();
            }
        }

        #endregion  // <����/>

        /// <summary>
        /// �I�y���[�V�����}�X�^DB�̃��R�[�h���X�g�����������܂��B
        /// </summary>
        /// <remarks>
        /// �I�y���[�V�����}�X�^DB�̃��R�[�h��S���擾���܂��B
        /// <br>Update Note: 2010/04/02 ������ �Z�L�����e�B�Ǘ����i�̍��������ǑΉ�</br>
        /// </remarks>
        protected override void Initialize()
        {
            RecordList.Clear();

            // --------UPD 2010/04/02-------->>>>>
            #region [DEL]
            //// �A�N�Z�X������ݒ�
            //List<DBRecordType> searchingConditionList = new List<DBRecordType>();
            //{
            //    // TODO:�������ɍ��킹�ďC��
            //    DBRecordType condition1 = new DBRecordType();
            //    condition1.CategoryCode = (int)EntityUtil.CategoryCode.Part;
            //    condition1.OperationCode = ALL_ITEM;
            //    searchingConditionList.Add(condition1);

            //    DBRecordType condition2 = new DBRecordType();
            //    condition2.CategoryCode = (int)EntityUtil.CategoryCode.Entry;
            //    condition2.OperationCode = ALL_ITEM;
            //    searchingConditionList.Add(condition2);

            //    DBRecordType condition3 = new DBRecordType();
            //    condition3.CategoryCode = (int)EntityUtil.CategoryCode.Update;
            //    condition3.OperationCode = ALL_ITEM;
            //    searchingConditionList.Add(condition3);

            //    DBRecordType condition4 = new DBRecordType();
            //    condition4.CategoryCode = (int)EntityUtil.CategoryCode.Reference;
            //    condition4.OperationCode = ALL_ITEM;
            //    searchingConditionList.Add(condition4);

            //    DBRecordType condition5 = new DBRecordType();
            //    condition5.CategoryCode = (int)EntityUtil.CategoryCode.Report;
            //    condition5.OperationCode = ALL_ITEM;
            //    searchingConditionList.Add(condition5);

            //    DBRecordType condition6 = new DBRecordType();
            //    condition6.CategoryCode = (int)EntityUtil.CategoryCode.MasterMaintenance;
            //    condition6.OperationCode = ALL_ITEM;
            //    searchingConditionList.Add(condition6);

            //    DBRecordType condition7 = new DBRecordType();
            //    condition7.CategoryCode = (int)EntityUtil.CategoryCode.Others;
            //    condition7.OperationCode = ALL_ITEM;
            //    searchingConditionList.Add(condition7);

            //    DBRecordType condition8 = new DBRecordType();
            //    condition8.CategoryCode = (int)EntityUtil.CategoryCode.AllSetting;
            //    condition8.OperationCode = ALL_ITEM;
            //    searchingConditionList.Add(condition8);
            //    // ��
            //}
            //#region <�قڂ���/>

            //foreach (DBRecordType searchingCondition in searchingConditionList)
            //{
            //    // �A�N�Z�X���ʁi�߂�l�j��ݒ�
            //    ArrayList searchedRecordList = new ArrayList();

            //    // �����p�p�����[�^��ݒ�
            //    object objSearchedRecordList = searchedRecordList;
            //    object objSearchingCondition = searchingCondition;
            //    // ����
            //    int status = RealAccesser.Search(
            //        ref objSearchedRecordList,
            //        objSearchingCondition,
            //        (int)DBAccessParameterNumber.Default,   // TODO:�K�v�ɉ�����
            //        ConstantManagement.LogicalMode.GetData0 // TODO:�K�v�ɉ�����
            //    );
            //    if (status.Equals((int)DBAccessStatus.NoRecord)) continue;  // �Y���f�[�^�Ȃ�

            //    #region <Debug/>

            //    Debug.Assert(status.Equals((int)DBAccessStatus.Normal), MsgUtil.GetMsg(status, searchingCondition.CategoryCode));

            //    #endregion  // <Debug/>

            //    // �Y���f�[�^����
            //    searchedRecordList = (ArrayList)objSearchedRecordList;  // TODO:���[�J���A�N�Z�X���ŐV����new���Ă���
            //    foreach (object objSearchedRecord in searchedRecordList)
            //    {
            //        DBRecordType searchedRecord = (DBRecordType)objSearchedRecord;
            //        RecordList.Add(searchedRecord);

            //        Tbl.AddOperationMasterRow(
            //            DateTimeUtil.ToDateTime(searchedRecord.OfferDate),
            //            searchedRecord.CategoryCode,
            //            searchedRecord.CategoryName,
            //            searchedRecord.CategoryDspOdr,
            //            searchedRecord.PgId,
            //            searchedRecord.PgName,
            //            searchedRecord.PgDspOdr,
            //            searchedRecord.OperationCode,
            //            searchedRecord.OperationName,
            //            searchedRecord.OperationDspOdr
            //        );
            //    }
            //}

            //#endregion  // <�قڂ���/>
            #endregion

            // �A�N�Z�X���ʁi�߂�l�j��ݒ�
            ArrayList searchedRecordList = new ArrayList();
            // �����p�p�����[�^��ݒ�
            object objSearchedRecordList = searchedRecordList;
            // ����
            int status = RealAccesser.SearchAll(
                ref objSearchedRecordList,
                (int)DBAccessParameterNumber.Default,
                ConstantManagement.LogicalMode.GetData0
            );
            searchedRecordList = (ArrayList)objSearchedRecordList;
            foreach (object objSearchedRecord in searchedRecordList)
            {
                DBRecordType searchedRecord = (DBRecordType)objSearchedRecord;
                RecordList.Add(searchedRecord);

                Tbl.AddOperationMasterRow(
                    DateTimeUtil.ToDateTime(searchedRecord.OfferDate),
                    searchedRecord.CategoryCode,
                    searchedRecord.CategoryName,
                    searchedRecord.CategoryDspOdr,
                    searchedRecord.PgId,
                    searchedRecord.PgName,
                    searchedRecord.PgDspOdr,
                    searchedRecord.OperationCode,
                    searchedRecord.OperationName,
                    searchedRecord.OperationDspOdr
                );
            }
            // --------UPD 2010/04/02--------<<<<<

        }
    }
}
