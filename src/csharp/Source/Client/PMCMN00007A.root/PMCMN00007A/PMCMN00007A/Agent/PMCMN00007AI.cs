//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���엚���A�N�Z�X
// �v���O�����T�v   : ���_�}�X�^�e�[�u���A�N�Z�X�̃A�N�Z�X���ʂ�ێ����܂��B
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
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    using DBAccessType  = SecInfoSetAcs;
    using DBRecordType  = SecInfoSet;
    using DataSetType   = SectionInfoDataSet;
    using DataTableType = SectionInfoDataSet.SectionInfoDataTable;
    using DataRowType   = SectionInfoDataSet.SectionInfoRow;

    /// <summary>
    /// ���_�}�X�^�e�[�u���A�N�Z�X�N���X�̑㗝�l�N���X
    /// </summary>
    public sealed class SecInfoSetAcsAgent : DBAccessAgent<DBAccessType, DBRecordType, DataSetType>, IDisposable
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
        ~SecInfoSetAcsAgent()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SecInfoSetAcsAgent() : base() { }

        /// <summary>
        /// ���_�}�X�^DB�̃f�[�^�e�[�u�����擾���܂��B
        /// </summary>
        /// <value>���_�}�X�^DB�̃f�[�^�e�[�u��</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataTableType Tbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return DB.SectionInfo;
            }
        }

        /// <summary>
        /// ���_�}�X�^DB�̃��R�[�h���X�g�����������܂��B
        /// </summary>
        /// <remarks>
        /// ���_�}�X�^DB���S���_�̃��R�[�h���擾���܂��B
        /// </remarks>
        protected override void Initialize()
        {
            RecordList.Clear();

            ArrayList searchedRecordArrayList = null;
            int status = RealAccesser.SearchAll(out searchedRecordArrayList, LoginInfoAcquisition.EnterpriseCode);

            // �Y���f�[�^�Ȃ�
            if (status.Equals((int)DBAccessStatus.NoRecord)) return;

            #region <Debug/>

            Debug.Assert(status.Equals((int)DBAccessStatus.Normal), MsgUtil.GetMsg(status, LoginInfoAcquisition.EnterpriseCode));

            #endregion  // <Debug/>

            // �Y���f�[�^����
            foreach (object objSearchedRecord in searchedRecordArrayList)
            {
                DBRecordType searchedRecord = (DBRecordType)objSearchedRecord;
                RecordList.Add(searchedRecord);

                Tbl.AddSectionInfoRow(
                    searchedRecord.SectionCode,
                    searchedRecord.SectionGuideNm
                );
            }
        }

        /// <summary>
        /// ���_���̂��擾���܂��B
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        public string GetSectionName(string sectionCode)
        {
            StringBuilder sqlWhere = new StringBuilder();
            sqlWhere.Append(SectionInfoDataSet.ClmIdx.SectionCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(sectionCode));

            DataRow[] foundRows = Tbl.Select(sqlWhere.ToString());
            if (foundRows.Length > 0)
            {
                return ((SectionInfoDataSet.SectionInfoRow)foundRows[0]).SectionGuideNm;
            }
            else
            {
                return sectionCode;
            }
        }
    }
}
