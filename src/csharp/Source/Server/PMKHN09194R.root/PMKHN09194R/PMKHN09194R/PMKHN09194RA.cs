//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^
// �v���O�����T�v   : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^ DB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// �Ǘ��ԍ�  11500865-00  �쐬�S�� : 杍^
// �� �� ��  2019/09/02   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2019/09/02</br>
    /// </remarks>
    [Serializable]
    public class EmpScSalesTargetDB : RemoteDB, IEmpScSalesTargetDB
    {
        /// <summary>
        /// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public EmpScSalesTargetDB()
            :
            base("PMKHN09196D", "Broadleaf.Application.Remoting.ParamData.EmpScSalesTargetWork", "EMPSCSALESTARGETRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="empScSalesTargetWork">��������</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int Search(out object empScSalesTargetWork, object paraWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            // �R�l�N�V����
            SqlConnection sqlConnection = null;
            // �������ʃ��[�N
            empScSalesTargetWork = null;
            // �R�l�N�V��������
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    // �����������s��
                    return SearchProc(out empScSalesTargetWork, paraWork, readMode, logicalMode, ref sqlConnection);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "EmpScSalesTargetDB.Search");
                    empScSalesTargetWork = new ArrayList();
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objetEmpScSalesTargetWork">��������</param>
        /// <param name="searchParaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int SearchProc(out object objetEmpScSalesTargetWork, object searchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            // �������ʃ��[�N
            SearchEmpScSalesTargetParaWork empScSalesTargetParaWork = null;
            // �����p�����[�^���X�g
            ArrayList empScSalesTargetList = searchParaWork as ArrayList;

            // �P�ꌟ���ꍇ
            if (empScSalesTargetList == null)
            {
                empScSalesTargetParaWork = searchParaWork as SearchEmpScSalesTargetParaWork;
            }
            else
            {
                if (empScSalesTargetList.Count > 0)
                {
                    empScSalesTargetParaWork = empScSalesTargetList[0] as SearchEmpScSalesTargetParaWork;
                }
            }

            // �����������s��
            int status = SearchEmpScSalesTargetProc(out empScSalesTargetList, empScSalesTargetParaWork, readMode, logicalMode, ref sqlConnection);
            // �������ʃ��[�N
            objetEmpScSalesTargetWork = empScSalesTargetList;

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="empScSalesTargetList">��������</param>
        /// <param name="searchParaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int SearchEmpScSalesTargetProc(out ArrayList empScSalesTargetList, SearchEmpScSalesTargetParaWork searchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchEmpSalesTargetProcProc(out empScSalesTargetList, searchParaWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="empScSalesTargetList">��������</param>
        /// <param name="searchParaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        private int SearchEmpSalesTargetProcProc(out ArrayList empScSalesTargetList, SearchEmpScSalesTargetParaWork searchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // �R�}���h
            SqlCommand sqlCommand = null;
            // �������ʃ��X�g
            ArrayList al = new ArrayList();
            empScSalesTargetList = new ArrayList();

            try
            {
                using (sqlCommand = new SqlCommand("", sqlConnection))
                {
                    string selectTxt = string.Empty;
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += " A.CREATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " , A.UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " , A.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " , A.FILEHEADERGUIDRF" + Environment.NewLine;
                    selectTxt += " , A.UPDEMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += " , A.UPDASSEMBLYID1RF" + Environment.NewLine;
                    selectTxt += " , A.UPDASSEMBLYID2RF" + Environment.NewLine;
                    selectTxt += " , A.LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += " , A.TARGETSETCDRF" + Environment.NewLine;
                    selectTxt += " , A.TARGETCONTRASTCDRF" + Environment.NewLine;
                    selectTxt += " , A.TARGETDIVIDECODERF" + Environment.NewLine;
                    selectTxt += " , A.TARGETDIVIDENAMERF" + Environment.NewLine;
                    selectTxt += " , A.SALESCODERF" + Environment.NewLine;
                    selectTxt += " , A.EMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += " , A.APPLYSTADATERF" + Environment.NewLine;
                    selectTxt += " , A.APPLYENDDATERF" + Environment.NewLine;
                    selectTxt += " , A.SALESTARGETMONEYRF" + Environment.NewLine;
                    selectTxt += " , A.SALESTARGETPROFITRF" + Environment.NewLine;
                    selectTxt += " , A.SALESTARGETCOUNTRF" + Environment.NewLine;
                    selectTxt += "  FROM EMPSCSALESTARGETRF AS A WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlCommand.CommandText = selectTxt.ToString();
                    // ��������
                    sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchParaWork, logicalMode);

                    // �N�G�����s���̃^�C���A�E�g���Ԃ�3600�b�ɐݒ肷��
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            // �������ʊi�[
                            al.Add(CopyToEmpSalesTargetWorkFromReader(myReader));
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }

                    // �������ʊi�[
                    empScSalesTargetList = al;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="empScSalesTarget">�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int Write(ref object empScSalesTarget)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            // �R�l�N�V����
            SqlConnection sqlConnection = null;
            // �g�����U�N�V����
            SqlTransaction sqlTransaction = null;

            try
            {
                // �R�l�N�V�����J�n
                using (sqlConnection = CreateSqlConnection(true))
                {
                    // �p�����[�^�̃L���X�g
                    ArrayList paraList = CastToArrayListFromPara(empScSalesTarget);
                    if (paraList == null) return status;

                    // �g�����U�N�V�����J�n
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    // �o�^�������s��
                    status = WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �R�~�b�g
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        // ���[���o�b�N
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                    //�߂�l�Z�b�g
                    empScSalesTarget = paraList;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpScSalesTargetDB.Write");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }

            return status;
        }


        /// <summary>
        /// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="empScSalesTargetList">�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int WriteProc(ref ArrayList empScSalesTargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteEmpScSalesTargetProc(ref empScSalesTargetList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="empScSalesTargetList">�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        private int WriteEmpScSalesTargetProc(ref ArrayList empScSalesTargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            // �R�}���h
            SqlCommand sqlCommand = null;
            // �������ʃ��X�g
            ArrayList al = new ArrayList();

            try
            {
                using (sqlCommand = new SqlCommand("", sqlConnection))
                {
                    string selectTxt = string.Empty;
                    if (empScSalesTargetList != null)
                    {
                        for (int i = 0; i < empScSalesTargetList.Count; i++)
                        {
                            EmpScSalesTargetWork empScSalesTargetWork = empScSalesTargetList[i] as EmpScSalesTargetWork;

                            selectTxt = string.Empty;
                            selectTxt += "SELECT UPDATEDATETIMERF FROM EMPSCSALESTARGETRF" + Environment.NewLine;
                            selectTxt += "WHERE" + Environment.NewLine;
                            selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                            selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                            selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                            selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += " AND SALESCODERF=@FINDSALESCODE" + Environment.NewLine;

                            //Select�R�}���h�̐���
                            sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                            //Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                            SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                            SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                            SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);

                            //Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EnterpriseCode);
                            findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetSetCd);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetContrastCd);
                            findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.TargetDivideCode);
                            findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EmployeeCode);
                            findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.SalesCode);

                            myReader = sqlCommand.ExecuteReader();
                            if (myReader.Read())
                            {
                                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                                if (_updateDateTime != empScSalesTargetWork.UpdateDateTime)
                                {
                                    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                    if (empScSalesTargetWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    sqlCommand.Cancel();
                                    if (myReader.IsClosed == false) myReader.Close();
                                    return status;
                                }

                                selectTxt = string.Empty;
                                selectTxt += "UPDATE EMPSCSALESTARGETRF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                                selectTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                selectTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                selectTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                selectTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                selectTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                selectTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                selectTxt += " , TARGETSETCDRF=@TARGETSETCD" + Environment.NewLine;
                                selectTxt += " , TARGETCONTRASTCDRF=@TARGETCONTRASTCD" + Environment.NewLine;
                                selectTxt += " , TARGETDIVIDECODERF=@TARGETDIVIDECODE" + Environment.NewLine;
                                selectTxt += " , TARGETDIVIDENAMERF=@TARGETDIVIDENAME" + Environment.NewLine;
                                selectTxt += " , SALESCODERF=@SALESCODE" + Environment.NewLine;
                                selectTxt += " , EMPLOYEECODERF=@EMPLOYEECODE" + Environment.NewLine;
                                selectTxt += " , APPLYSTADATERF=@APPLYSTADATE" + Environment.NewLine;
                                selectTxt += " , APPLYENDDATERF=@APPLYENDDATE" + Environment.NewLine;
                                selectTxt += " , SALESTARGETMONEYRF=@SALESTARGETMONEY" + Environment.NewLine;
                                selectTxt += " , SALESTARGETPROFITRF=@SALESTARGETPROFIT" + Environment.NewLine;
                                selectTxt += " , SALESTARGETCOUNTRF=@SALESTARGETCOUNT" + Environment.NewLine;
                                selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                selectTxt += "  AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                                selectTxt += "  AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                                selectTxt += "  AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                                selectTxt += "  AND SALESCODERF=@FINDSALESCODE " + Environment.NewLine;
                                selectTxt += "  AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                                sqlCommand.CommandText = selectTxt;

                                //KEY�R�}���h���Đݒ�
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EnterpriseCode);
                                findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetSetCd);
                                findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetContrastCd);
                                findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.TargetDivideCode);
                                findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.SalesCode);
                                findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EmployeeCode);

                                //�X�V�w�b�_����ݒ�
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)empScSalesTargetWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);
                            }
                            else
                            {
                                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                                if (empScSalesTargetWork.UpdateDateTime > DateTime.MinValue)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                    sqlCommand.Cancel();
                                    if (myReader.IsClosed == false) myReader.Close();
                                    return status;
                                }

                                selectTxt = string.Empty;
                                selectTxt += "INSERT INTO EMPSCSALESTARGETRF" + Environment.NewLine;
                                selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                                selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                                selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                                selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                                selectTxt += "  ,TARGETSETCDRF" + Environment.NewLine;
                                selectTxt += "  ,TARGETCONTRASTCDRF" + Environment.NewLine;
                                selectTxt += "  ,TARGETDIVIDECODERF" + Environment.NewLine;
                                selectTxt += "  ,TARGETDIVIDENAMERF" + Environment.NewLine;
                                selectTxt += "  ,SALESCODERF" + Environment.NewLine;
                                selectTxt += "  ,EMPLOYEECODERF" + Environment.NewLine;
                                selectTxt += "  ,APPLYSTADATERF" + Environment.NewLine;
                                selectTxt += "  ,APPLYENDDATERF" + Environment.NewLine;
                                selectTxt += "  ,SALESTARGETMONEYRF" + Environment.NewLine;
                                selectTxt += "  ,SALESTARGETPROFITRF" + Environment.NewLine;
                                selectTxt += "  ,SALESTARGETCOUNTRF" + Environment.NewLine;
                                selectTxt += " )" + Environment.NewLine;
                                selectTxt += " VALUES" + Environment.NewLine;
                                selectTxt += " (@CREATEDATETIME" + Environment.NewLine;
                                selectTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                                selectTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                                selectTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                                selectTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                selectTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                                selectTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                                selectTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                                selectTxt += "  ,@TARGETSETCD" + Environment.NewLine;
                                selectTxt += "  ,@TARGETCONTRASTCD" + Environment.NewLine;
                                selectTxt += "  ,@TARGETDIVIDECODE" + Environment.NewLine;
                                selectTxt += "  ,@TARGETDIVIDENAME" + Environment.NewLine;
                                selectTxt += "  ,@SALESCODE" + Environment.NewLine;
                                selectTxt += "  ,@EMPLOYEECODE" + Environment.NewLine;
                                selectTxt += "  ,@APPLYSTADATE" + Environment.NewLine;
                                selectTxt += "  ,@APPLYENDDATE" + Environment.NewLine;
                                selectTxt += "  ,@SALESTARGETMONEY" + Environment.NewLine;
                                selectTxt += "  ,@SALESTARGETPROFIT" + Environment.NewLine;
                                selectTxt += "  ,@SALESTARGETCOUNT" + Environment.NewLine;
                                selectTxt += " )" + Environment.NewLine;

                                //�V�K�쐬����SQL���𐶐�
                                sqlCommand.CommandText = selectTxt;
                                //�o�^�w�b�_����ݒ�
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)empScSalesTargetWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                            }
                            if (myReader.IsClosed == false) myReader.Close();

                            #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                            SqlParameter paraTargetSetCd = sqlCommand.Parameters.Add("@TARGETSETCD", SqlDbType.Int);
                            SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                            SqlParameter paraTargetDivideCode = sqlCommand.Parameters.Add("@TARGETDIVIDECODE", SqlDbType.NChar);
                            SqlParameter paraTargetDivideName = sqlCommand.Parameters.Add("@TARGETDIVIDENAME", SqlDbType.NVarChar);
                            SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                            SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                            SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                            SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);
                            SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);
                            SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);

                            #endregion

                            #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(empScSalesTargetWork.CreateDateTime);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(empScSalesTargetWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(empScSalesTargetWork.FileHeaderGuid);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.LogicalDeleteCode);
                            paraTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetSetCd);
                            paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetContrastCd);
                            paraTargetDivideCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.TargetDivideCode);
                            paraTargetDivideName.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.TargetDivideName);
                            paraSalesCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.SalesCode);
                            paraEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EmployeeCode);
                            paraApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(empScSalesTargetWork.ApplyStaDate);
                            paraApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(empScSalesTargetWork.ApplyEndDate);
                            paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(empScSalesTargetWork.SalesTargetMoney);
                            paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(empScSalesTargetWork.SalesTargetProfit);
                            paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(empScSalesTargetWork.SalesTargetCount);
                            #endregion

                            sqlCommand.ExecuteNonQuery();
                            al.Add(empScSalesTargetWork);
                        }
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
            }

            empScSalesTargetList = al;

            return status;
        }
        #endregion

        #region [WriteProc]
        /// <summary>
        /// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^�����X�V���܂�
        /// </summary>
        /// <param name="empScSalesTargetWork">�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g(write�p)</param>
        /// <param name="parabyte">EmpSalesTargetWork�I�u�W�F�N�g(delete�p)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^�����X�V���܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int WriteProc(ref object empScSalesTargetWork, byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �R�l�N�V����
            SqlConnection sqlConnection = null;
            // �g�����U�N�V����
            SqlTransaction sqlTransaction = null;
            try
            {
                // �R�l�N�V��������
                using (sqlConnection = CreateSqlConnection(true))
                {
                    // �p�����[�^�̃L���X�g
                    ArrayList paraWriteList = CastToArrayListFromPara(empScSalesTargetWork);
                    if (paraWriteList == null) return status;

                    ArrayList paraDeleteList = CastToArrayListFromPara(parabyte);
                    if (paraDeleteList == null) return status;

                    // �g�����U�N�V�����J�n
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    // �폜�������s��
                    status = DeleteEmpScSalesTargetProcProc(paraDeleteList, ref sqlConnection, ref sqlTransaction);

                    // �o�^�������s��
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = WriteEmpScSalesTargetProc(ref paraWriteList, ref sqlConnection, ref sqlTransaction);
                    }
                    else
                    {
                        // �Ȃ�
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �R�~�b�g
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        // ���[���o�b�N
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                    //�߂�l�Z�b�g
                    empScSalesTargetWork = paraWriteList;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpScSalesTargetDB.WriteProc");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="empScSalesTargetWork">�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int LogicalDelete(ref object empScSalesTargetWork)
        {
            return LogicalDeleteEmpScSalesTarget(ref empScSalesTargetWork, 0);
        }

        /// <summary>
        /// �_���폜�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="empScSalesTargetWork">�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object empScSalesTargetWork)
        {
            return LogicalDeleteEmpScSalesTarget(ref empScSalesTargetWork, 1);
        }

        /// <summary>
        /// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="empScSalesTargetWork">�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        private int LogicalDeleteEmpScSalesTarget(ref object empScSalesTargetWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // �R�l�N�V����
            SqlConnection sqlConnection = null;
            // �g�����U�N�V����
            SqlTransaction sqlTransaction = null;
            try
            {
                // �R�l�N�V��������
                using (sqlConnection = CreateSqlConnection(true))
                {
                    //�p�����[�^�̃L���X�g
                    ArrayList paraList = CastToArrayListFromPara(empScSalesTargetWork);
                    if (paraList == null) return status;

                    // �g�����U�N�V�����J�n
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    status = LogicalDeleteEmpScSalesTargetProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �R�~�b�g
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        // ���[���o�b�N
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpScSalesTargetDB.LogicalDeleteEmpScSalesTarget");

                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }
            return status;
        }

        /// <summary>
        /// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="empScSalesTargetWorkList">�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int LogicalDeleteEmpScSalesTargetProc(ref ArrayList empScSalesTargetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteEmpScSalesTargetProcProc(ref empScSalesTargetWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="empScSalesTargetWorkList">�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        private int LogicalDeleteEmpScSalesTargetProcProc(ref ArrayList empScSalesTargetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // ���W�b�N�폜�敪
            int logicalDelCd = 0;
            // �R�}���h
            SqlCommand sqlCommand = null;
            // �������ʃ��X�g
            ArrayList al = new ArrayList();

            try
            {
                using (sqlCommand = new SqlCommand("", sqlConnection))
                {
                    string selectTxt = string.Empty;
                    if (empScSalesTargetWorkList != null)
                    {
                        for (int i = 0; i < empScSalesTargetWorkList.Count; i++)
                        {
                            EmpScSalesTargetWork empScSalesTargetWork = empScSalesTargetWorkList[i] as EmpScSalesTargetWork;

                            //Select�R�}���h�̐���
                            selectTxt = string.Empty;
                            selectTxt += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM EMPSCSALESTARGETRF" + Environment.NewLine;
                            selectTxt += "WHERE" + Environment.NewLine;
                            selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                            selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                            selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                            selectTxt += " AND SALESCODERF=@FINDSALESCODE" + Environment.NewLine;
                            selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                            sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                            //Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                            SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                            SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                            SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                            SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                            //Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EnterpriseCode);
                            findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetSetCd);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetContrastCd);
                            findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.TargetDivideCode);
                            findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.SalesCode);
                            findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EmployeeCode);

                            using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                            {
                                if (myReader.Read())
                                {
                                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                                    if (_updateDateTime != empScSalesTargetWork.UpdateDateTime)
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                        sqlCommand.Cancel();
                                        return status;
                                    }
                                    //���݂̘_���폜�敪���擾
                                    logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                                    selectTxt = string.Empty;
                                    selectTxt += "UPDATE EMPSCSALESTARGETRF" + Environment.NewLine;
                                    selectTxt += "SET" + Environment.NewLine;
                                    selectTxt += " UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    selectTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1 " + Environment.NewLine;
                                    selectTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2 " + Environment.NewLine;
                                    selectTxt += ", LOGICALDELETECODERF=@LOGICALDELETECODE " + Environment.NewLine;
                                    selectTxt += "WHERE" + Environment.NewLine;
                                    selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                                    selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                                    selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                                    selectTxt += " AND SALESCODERF=@FINDSALESCODE" + Environment.NewLine;
                                    selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                                    //KEY�R�}���h���Đݒ�
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EnterpriseCode);
                                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetSetCd);
                                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetContrastCd);
                                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.TargetDivideCode);
                                    findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.SalesCode);
                                    findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EmployeeCode);
                                    sqlCommand.CommandText = selectTxt;
                                    //�X�V�w�b�_����ݒ�
                                    object obj = (object)this;
                                    IFileHeader flhd = (IFileHeader)empScSalesTargetWork;
                                    FileHeader fileHeader = new FileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);
                                }
                                else
                                {
                                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                    sqlCommand.Cancel();
                                    return status;
                                }
                                sqlCommand.Cancel();
                            }

                            //�_���폜���[�h�̏ꍇ
                            if (procMode == 0)
                            {
                                if (logicalDelCd == 3)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                                    sqlCommand.Cancel();
                                    return status;
                                }
                                else if (logicalDelCd == 0) empScSalesTargetWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                                else empScSalesTargetWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                            }
                            else
                            {
                                if (logicalDelCd == 1) empScSalesTargetWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                                else
                                {
                                    if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                    else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
                                    sqlCommand.Cancel();
                                    return status;
                                }
                            }

                            //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                            //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(empScSalesTargetWork.UpdateDateTime);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.LogicalDeleteCode);

                            sqlCommand.ExecuteNonQuery();
                            al.Add(empScSalesTargetWork);
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }

            // �������ʃ��X�g�i�[
            empScSalesTargetWorkList = al;

            return status;
        }
        #endregion

        #region [Delete]
        /// <summary>
        /// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // �R�l�N�V����
            SqlConnection sqlConnection = null;
            // �g�����U�N�V����
            SqlTransaction sqlTransaction = null;
            try
            {
                // �R�l�N�V��������
                using (sqlConnection = CreateSqlConnection(true))
                {
                    // �p�����[�^�̃L���X�g
                    ArrayList paraList = CastToArrayListFromPara(parabyte);
                    if (paraList == null) return status;

                    // �g�����U�N�V�����J�n
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    status = DeleteEmpScSalesTargetProc(paraList, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �R�~�b�g
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        // ���[���o�b�N
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpScSalesTargetDB.Delete");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }
            return status;
        }


        /// <summary>
        /// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="empScSalesTargetWorkList">�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int DeleteEmpScSalesTargetProc(ArrayList empScSalesTargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteEmpScSalesTargetProcProc(empScSalesTargetWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="empScSalesTargetWorkList">�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        private int DeleteEmpScSalesTargetProcProc(ArrayList empScSalesTargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // �R�}���h
            SqlCommand sqlCommand = null;

            try
            {
                using (sqlCommand = new SqlCommand("", sqlConnection))
                {
                    string selectTxt = string.Empty;

                    for (int i = 0; i < empScSalesTargetWorkList.Count; i++)
                    {
                        EmpScSalesTargetWork empScSalesTargetWork = empScSalesTargetWorkList[i] as EmpScSalesTargetWork;

                        selectTxt = string.Empty;
                        selectTxt += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM EMPSCSALESTARGETRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                        selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                        selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                        selectTxt += " AND SALESCODERF=@FINDSALESCODE" + Environment.NewLine;
                        selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                        SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EnterpriseCode);
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.TargetDivideCode);
                        findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.SalesCode);
                        findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EmployeeCode);
                        using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                                if (_updateDateTime != empScSalesTargetWork.UpdateDateTime)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    sqlCommand.Cancel();
                                    return status;
                                }

                                selectTxt = string.Empty;
                                selectTxt = "DELETE FROM EMPSCSALESTARGETRF ";
                                selectTxt += " WHERE" + Environment.NewLine;
                                selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                                selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                                selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                                selectTxt += " AND SALESCODERF=@FINDSALESCODE" + Environment.NewLine;
                                selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                                //KEY�R�}���h���Đݒ�
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EnterpriseCode);
                                findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetSetCd);
                                findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetContrastCd);
                                findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.TargetDivideCode);
                                findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.SalesCode);
                                findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EmployeeCode);
                                sqlCommand.CommandText = selectTxt;
                            }
                            else
                            {
                                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                return status;
                            }
                        }

                        sqlCommand.ExecuteNonQuery();
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }
        #endregion

	    #region [Where���쐬����]
	    /// <summary>
	    /// �������������񐶐��{�����l�ݒ�
	    /// </summary>
	    /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="searchParaWork">���������i�[�N���X</param>
	    /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	    /// <returns>Where����������</returns>
        /// <remarks>
	    /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchEmpScSalesTargetParaWork searchParaWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //��ƃR�[�h
		    retstring += "A.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(searchParaWork.EnterpriseCode);

		    //�_���폜�敪
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
                wkstring = "AND A.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND A.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

            //�ڕW�ݒ�敪
            if (searchParaWork.TargetSetCd > 0)
            {
                retstring += "AND A.TARGETSETCDRF=@TARGETSETCD ";
                SqlParameter paraTargetSetCd = sqlCommand.Parameters.Add("@TARGETSETCD", SqlDbType.Int);
                paraTargetSetCd.Value = SqlDataMediator.SqlSetInt32(searchParaWork.TargetSetCd);
            }

            //�ڕW�Δ�敪
            if (searchParaWork.TargetContrastCd > 0)
            {
                retstring += "AND A.TARGETCONTRASTCDRF=@TARGETCONTRASTCD ";
                SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(searchParaWork.TargetContrastCd);
            }

            //�ڕW�敪�R�[�h
            if (searchParaWork.TargetDivideCode != "")
            {
                retstring += "AND A.TARGETDIVIDECODERF>=@TARGETDIVIDECODE1 ";
                retstring += "AND A.TARGETDIVIDECODERF<=@TARGETDIVIDECODE2 ";
                SqlParameter paraTargetDivideCode1 = sqlCommand.Parameters.Add("@TARGETDIVIDECODE1", SqlDbType.NChar);
                SqlParameter paraTargetDivideCode2 = sqlCommand.Parameters.Add("@TARGETDIVIDECODE2", SqlDbType.NChar);
                paraTargetDivideCode1.Value = SqlDataMediator.SqlSetString(searchParaWork.TargetDivideCode);
                int endYearMonth = Convert.ToInt32(searchParaWork.TargetDivideCode) + 99;
                if (endYearMonth % 100 == 0)
                {
                    endYearMonth = Convert.ToInt32(searchParaWork.TargetDivideCode) + 11;
                }
                paraTargetDivideCode2.Value = SqlDataMediator.SqlSetString(endYearMonth.ToString());
            }

            //�]�ƈ��R�[�h
            if (searchParaWork.EmployeeCode != "")
            {
                retstring += "AND A.EMPLOYEECODERF=@EMPLOYEECODE ";
                SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(searchParaWork.EmployeeCode);
            }

            //�̔��敪�R�[�h
            if (searchParaWork.SalesCode > 0)
            {
                retstring += "AND A.SALESCODERF=@SALESCODE ";
                SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                paraSalesCode.Value = SqlDataMediator.SqlSetInt32(searchParaWork.SalesCode);
            }

            //�\�[�g����
            retstring += "ORDER BY A.APPLYSTADATERF,A.APPLYENDDATERF,A.EMPLOYEECODERF,A.SALESCODERF ";

		    return retstring;
		}
	    #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� EmpSalesTargetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>EmpSalesTargetWork</returns>
        /// <remarks>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        private EmpScSalesTargetWork CopyToEmpSalesTargetWorkFromReader(SqlDataReader myReader)
        {
            EmpScSalesTargetWork wkEmpScSalesTarget = new EmpScSalesTargetWork();

            #region �N���X�֊i�[
            wkEmpScSalesTarget.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkEmpScSalesTarget.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkEmpScSalesTarget.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkEmpScSalesTarget.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkEmpScSalesTarget.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkEmpScSalesTarget.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkEmpScSalesTarget.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkEmpScSalesTarget.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkEmpScSalesTarget.TargetSetCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETSETCDRF"));
            wkEmpScSalesTarget.TargetContrastCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETCONTRASTCDRF"));
            wkEmpScSalesTarget.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
            wkEmpScSalesTarget.TargetDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDENAMERF"));
            wkEmpScSalesTarget.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
            wkEmpScSalesTarget.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            wkEmpScSalesTarget.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
            wkEmpScSalesTarget.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
            wkEmpScSalesTarget.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEYRF"));
            wkEmpScSalesTarget.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFITRF"));
            wkEmpScSalesTarget.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNTRF"));
            #endregion

            return wkEmpScSalesTarget;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            EmpScSalesTargetWork[] empScSalesTargetArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is EmpScSalesTargetWork)
                    {
                        EmpScSalesTargetWork wkEmpSalesTargetWork = paraobj as EmpScSalesTargetWork;
                        if (wkEmpSalesTargetWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkEmpSalesTargetWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            empScSalesTargetArray = (EmpScSalesTargetWork[])XmlByteSerializer.Deserialize(byteArray, typeof(EmpScSalesTargetWork[]));
                        }
                        catch (Exception) { }
                        if (empScSalesTargetArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(empScSalesTargetArray);
                        }
                        else
                        {
                            try
                            {
                                EmpScSalesTargetWork wkEmpSalesTargetWork = (EmpScSalesTargetWork)XmlByteSerializer.Deserialize(byteArray, typeof(EmpScSalesTargetWork));
                                if (wkEmpSalesTargetWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkEmpSalesTargetWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //���ɉ������Ȃ�
                }

            return retal;
        }
        #endregion

       #region [�R�l�N�V������������]
        /// <summary>
        /// �R�l�N�V������������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ����� false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Note        : �R�l�N�V���������������s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            // �R�l�N�V��������
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            // �R�l�N�V�����ڑ�
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }
            else
            {
                base.WriteErrorLog("EmpScSalesTargetDB.CreateSqlConnection" + "�R�l�N�V�����擾���s");
            }

            // SqlConnection�Ԃ�
            return retSqlConnection;
        }
        #endregion  // �R�l�N�V������������
    }
}
