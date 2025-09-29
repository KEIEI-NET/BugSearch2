//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���쌠���ݒ�A�N�Z�X
// �v���O�����T�v   : �I�y���[�V�����ݒ�}�X�^�����[�g�̃A�N�Z�X���ʂ�ێ����܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/08/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    using DBAccessType  = IOperationStDB;
    using DBRecordType  = OperationStWork;
    using DataSetType   = OperationSettingMasterDataSet;
    using DataTableType = OperationSettingMasterDataSet.OperationSettingMasterDataTable;
    using DataRowType   = OperationSettingMasterDataSet.OperationSettingMasterRow;

    /// <summary>
    /// �I�y���[�V�����ݒ�}�X�^�����[�g�N���X�̑㗝�l�N���X
    /// </summary>
    public sealed class OperationStDBAgent : OperationLimitation, IDisposable
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
            #region <Guard Phrase/>
            
            if (Disposed) return;

            #endregion  // <Guard Phrase/>

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
        ~OperationStDBAgent()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// �S�J�e�S�����擾���܂��B
        /// </remarks>
        public OperationStDBAgent() : base()
        {
            SearchAllCategory();
        }

        /// <summary>
        /// �S�J�e�S�����������܂��B
        /// </summary>
        public void SearchAllCategory()
        {
            const int ALL_CATEGORY = -1;
            base.SearchInitial(ALL_CATEGORY, string.Empty);
            return;
        }

        #endregion  // <Constructor/>

        #region <�A�N�Z�T/>

        /// <summary>
        /// ��ƃR�[�h���擾���܂��B
        /// </summary>
        /// <value>��ƃR�[�h</value>
        public new string EnterpriseCode
        {
            get { return OperationLimitation.EnterpriseCode; }
        }

        /// <summary>
        /// �I�y���[�V�����ݒ�}�X�^DB�̃A�N�Z�T���擾���܂��B
        /// </summary>
        /// <value>�I�y���[�V�����ݒ�}�X�^DB�̃A�N�Z�T</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DBAccessType RealAccesser
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return base.OperationStDBAccesser;
            }
        }

        /// <summary>
        /// �I�y���[�V�����ݒ�}�X�^DB�̃��R�[�h���X�g���擾���܂��B
        /// </summary>
        /// <value>�I�y���[�V�����ݒ�}�X�^DB�̃��R�[�h���X�g</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public List<DBRecordType> RecordList
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return base.OperationStWorkList;
            }
        }

        /// <summary>
        /// �I�y���[�V�����ݒ�}�X�^DB�̃f�[�^�Z�b�g���擾���܂��B
        /// </summary>
        /// <value>�I�y���[�V�����ݒ�}�X�^DB�̃f�[�^�Z�b�g</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataSetType DB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return base.OperationSettingMasterDB;
            }
        }

        /// <summary>
        /// �I�y���[�V�����ݒ�}�X�^DB�̃f�[�^�e�[�u�����擾���܂��B
        /// </summary>
        /// <value>�I�y���[�V�����ݒ�}�X�^DB�̃f�[�^�e�[�u��</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataTableType Tbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return base.MainTbl;
            }
        }

        #endregion  // <�A�N�Z�T/>

        #region <���쌠���擾����/>

        /// <summary>
        /// �E��(�������x��1)�̏����ő��쌠�����擾���܂��B
        /// </summary>
        /// <remarks>
        /// �J�e�S���S�̐ݒ�ł���ꍇ�A�J�e�S���S�̂̑��쌠����Ԃ��܂��B
        /// </remarks>
        /// <param name="categoryCode">�N�����̃J�e�S���R�[�h</param>
        /// <param name="pgId">�N�����̃v���O����ID</param>
        /// <param name="operationCode">�Ώۂ̃I�y���[�V�����R�[�h</param>
        /// <param name="authorityLevel1">�Ώۂ̌������x��1(�E��)</param>
        /// <returns>
        /// �EEnable�F�B�I�y���[�V�����\�Ń��O�������ݕs�v�B�c�Y�����R�[�h����<br/>
        /// �EEnableWithLog�F��(���O�L�^)�B�I�y���[�V�����\�ŁA���O�������ݕK�v�B�c�����敪=0:���O<br/>
        /// �EDisable�F�s�B�I�y���[�V�����͕s�B�c�����敪=1:����
        /// </returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public OperationLimit GetOperationLimitFromJobType(
            int categoryCode,
            string pgId,
            int operationCode,
            int authorityLevel1
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            return base.GetOperationLimitWhereAuthorityLevel1(categoryCode, pgId, operationCode, authorityLevel1);
        }

        /// <summary>
        /// �ٗp�`��(�������x��2)�̏����ő��쌠�����擾���܂��B
        /// </summary>
        /// <remarks>
        /// �J�e�S���S�̐ݒ�ł���ꍇ�A�J�e�S���S�̂̑��쌠����Ԃ��܂��B
        /// </remarks>
        /// <param name="categoryCode">�N�����̃J�e�S���R�[�h</param>
        /// <param name="pgId">�N�����̃v���O����ID</param>
        /// <param name="operationCode">�Ώۂ̃I�y���[�V�����R�[�h</param>
        /// <param name="authorityLevel2">�Ώۂ̌������x��2(�ٗp�`��)</param>
        /// <returns>
        /// �EEnable�F�B�I�y���[�V�����\�Ń��O�������ݕs�v�B�c�Y�����R�[�h����<br/>
        /// �EEnableWithLog�F��(���O�L�^)�B�I�y���[�V�����\�ŁA���O�������ݕK�v�B�c�����敪=0:���O<br/>
        /// �EDisable�F�s�B�I�y���[�V�����͕s�B�c�����敪=1:����
        /// </returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public OperationLimit GetOperationLimitFromEmploymentForm(
            int categoryCode,
            string pgId,
            int operationCode,
            int authorityLevel2
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            return base.GetOperationLimitWhereAuthorityLevel2(categoryCode, pgId, operationCode, authorityLevel2);
        }

        #endregion  // <���쌠���擾����/>

        #region <�����ɍ������R�[�h�̎擾/>

        /// <summary>
        /// �����ɍ����E��̃��R�[�h���擾���܂��B
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="authorityLevel1">�������x��1(�E��)</param>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataRowType[] GetRowsWhatIsJobType(
            int categoryCode,
            string pgId,
            int operationCode,
            int authorityLevel1
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(
                categoryCode,
                pgId,
                operationCode,
                (int)DataSetType.OperationStDiv.AuthorityLevel1
            ));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.AuthorityLevel1);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(authorityLevel1);

            return ADOUtil.ConvertAll<DataRowType>(Tbl.Select(sqlWhere.ToString()));
        }

        /// <summary>
        /// �����ɍ����E��̃��R�[�h���擾���܂��B
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="authorityLevel2">�������x��2(�ٗp�`��)</param>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataRowType[] GetRowsWhatIsEmploymentForm(
            int categoryCode,
            string pgId,
            int operationCode,
            int authorityLevel2
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(
                categoryCode,
                pgId,
                operationCode,
                (int)DataSetType.OperationStDiv.AuthorityLevel2
            ));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.AuthorityLevel2);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(authorityLevel2);

            return ADOUtil.ConvertAll<DataRowType>(Tbl.Select(sqlWhere.ToString()));
        }

        /// <summary>
        /// �����ɍ����E��̃��R�[�h���擾���܂��B
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataRowType[] GetRowsWhatIsEmployeeCode(
            int categoryCode,
            string pgId,
            int operationCode,
            string employeeCode
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(
                categoryCode,
                pgId,
                operationCode,
                (int)DataSetType.OperationStDiv.EmployeeCode
            ));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.EmployeeCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(employeeCode));

            return ADOUtil.ConvertAll<DataRowType>(Tbl.Select(sqlWhere.ToString()));
        }

        #endregion  // <�����ɍ������R�[�h�̎擾/>

        #region <�J�e�S���S�̐ݒ�ł��邩�̔���/>

        /// <summary>
        /// �J�e�S���S�̐ݒ�ł��邩���肵�܂��B
        /// </summary>
        /// <remarks>
        /// �w�肵���J�e�S���R�[�h�̃��R�[�h�Ƀv���O����ID�̒l��<code>string.Empty</code>�̂��̂�����΁A
        /// �J�e�S���S�̐ݒ�ƂȂ�܂��B
        /// </remarks>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="authorityLevel1">�������x��1(�E��)</param>
        /// <returns>true :�J�e�S���S�̐ݒ�ł���B<br/>false:�J�e�S���S�̐ݒ�ł͂Ȃ��B</returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public bool IsCategorySettingWhatJobType(
            int categoryCode,
            int operationCode,
            int authorityLevel1
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            return GetCategorySettingRowsWhatAuthorityLevel1(categoryCode, operationCode, authorityLevel1).Length > 0;
        }

        /// <summary>
        /// �J�e�S���S�̐ݒ�ł��邩���肵�܂��B
        /// </summary>
        /// <remarks>
        /// �w�肵���J�e�S���R�[�h�̃��R�[�h�Ƀv���O����ID�̒l��<code>string.Empty</code>�̂��̂�����΁A
        /// �J�e�S���S�̐ݒ�ƂȂ�܂��B
        /// </remarks>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="authorityLevel2">�������x��2(�ٗp�`��)</param>
        /// <returns>true :�J�e�S���S�̐ݒ�ł���B<br/>false:�J�e�S���S�̐ݒ�ł͂Ȃ��B</returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public bool IsCategorySettingWhatEmploymentForm(
            int categoryCode,
            int operationCode,
            int authorityLevel2
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            return GetCategorySettingRowsWhatAuthorityLevel2(categoryCode, operationCode, authorityLevel2).Length > 0;
        }

        /// <summary>
        /// �J�e�S���S�̐ݒ�ł��邩���肵�܂��B
        /// </summary>
        /// <remarks>
        /// �w�肵���J�e�S���R�[�h�̃��R�[�h�Ƀv���O����ID�̒l��<code>string.Empty</code>�̂��̂�����΁A
        /// �J�e�S���S�̐ݒ�ƂȂ�܂��B
        /// </remarks>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>true :�J�e�S���S�̐ݒ�ł���B<br/>false:�J�e�S���S�̐ݒ�ł͂Ȃ��B</returns>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public bool IsCategorySettingWhatEmployeeCode(
            int categoryCode,
            int operationCode,
            string employeeCode
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            return GetCategorySettingRows(categoryCode, operationCode, employeeCode).Length > 0;
        }

        #endregion  // <�J�e�S���S�̐ݒ�ł��邩�̔���/>

        #region <SQL��where��/>

        /// <summary>
        /// ��{where����擾���܂��B
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="operationStDiv">�I�y���[�V�����ݒ�敪</param>
        /// <returns>��ƃR�[�h AND �J�e�S���[�R�[�h AND '�v���O����ID' AND �I�y���[�V�����R�[�h</returns>
        private string GetBaseWherePhrase(
            int categoryCode,
            string pgId,
            int operationCode,
            int operationStDiv
        )
        {
            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(categoryCode, pgId, operationCode));

            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationStDiv);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(operationStDiv);

            return sqlWhere.ToString();
        }

        #endregion  // <SQL��where��/>
    }
}
