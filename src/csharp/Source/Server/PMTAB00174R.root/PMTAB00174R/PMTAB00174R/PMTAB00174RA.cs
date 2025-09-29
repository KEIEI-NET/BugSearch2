//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �󒍃}�X�^(�ԗ�)DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : �󒍃}�X�^(�ԗ�)DB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt
// �� �� ��  2013/05/30  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �C�����e�@�\�[�X�`�F�b�N�m�F�����ꗗ��No.12�̑Ή� 
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt
// �� �� ��  2013/06/11  �쐬���e : �V�K�쐬
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
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �󒍃}�X�^(�ԗ�)DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �󒍃}�X�^(�ԗ�)�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : 2013/05/30</br>
    /// </remarks>
    [Serializable]
    public class PmTabAcpOdrCarDB : RemoteWithAppLockDB, IPmTabAcpOdrCarDB
    {

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        /// </remarks>
        public PmTabAcpOdrCarDB()
            //: base("PMJUT01813D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork", "PmTabAcpOdrCarRF")      // DEL huangt 2013/06/11 �\�[�X�`�F�b�N�m�F�����ꗗ��No.12�̑Ή�
            : base("PMTAB00176D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork", "PmTabAcpOdrCarRF")        // ADD huangt 2013/06/11 �\�[�X�`�F�b�N�m�F�����ꗗ��No.12�̑Ή�
        {
        }

        # region [Read]
        /// <summary>
        /// �P��̎󒍃}�X�^(�ԗ�)�����擾���܂��B
        /// </summary>
        /// <param name="pmTabAcpOdrCarObj">PmTabAcpOdrCarWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int Read(ref object pmTabAcpOdrCarObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                PmTabAcpOdrCarWork pmTabAcpOdrCarWork = pmTabAcpOdrCarObj as PmTabAcpOdrCarWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref pmTabAcpOdrCarWork, readMode, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �P��̎󒍃}�X�^(�ԗ�)�����擾���܂��B
        /// </summary>
        /// <param name="pmTabAcpOdrCarWork">PmTabAcpOdrCarWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int Read(ref PmTabAcpOdrCarWork pmTabAcpOdrCarWork, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref pmTabAcpOdrCarWork, readMode, sqlConnection, sqlTransaction);
        }

        // 2009/05/28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �󒍃}�X�^(�ԗ�)��񃊃X�g���擾���܂��B
        /// </summary>
        /// <param name="pmTabAcpOdrCarObj">���o�������X�g(PmTabAcpOdrCarWork)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int ReadAll(ref object pmTabAcpOdrCarObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList paraList = pmTabAcpOdrCarObj as ArrayList;
                ArrayList pmTabAcpOdrCarList = new ArrayList();

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.ReadAll(ref pmTabAcpOdrCarList, paraList, sqlConnection, sqlTransaction);

                pmTabAcpOdrCarObj = pmTabAcpOdrCarList;

            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �P��̎󒍃}�X�^(�ԗ�)�����擾���܂��B
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">���o���ʃ��X�g(PmTabAcpOdrCarWork)</param>
        /// <param name="paraList">���o�������X�g(PmTabAcpOdrCarWork)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int ReadAll(ref ArrayList pmTabAcpOdrCarList, ArrayList paraList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            foreach (PmTabAcpOdrCarWork pmTabAcpOdrCarWork in paraList)
            {
                PmTabAcpOdrCarWork pararetWork = pmTabAcpOdrCarWork;

                status = this.ReadProc(ref pararetWork, 0, sqlConnection, sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    pmTabAcpOdrCarList.Add(pararetWork);
                }
                else
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        return status;
                    }
            }

            //�����̗L���͊֌W�����ňُ�n�ȊO�̓m�[�}���Ƃ���
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            return status;
        }
        // 2009/05/28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// �P��̎󒍃}�X�^(�ԗ�)�����擾���܂��B
        /// </summary>
        /// <param name="pmTabAcpOdrCarWork">PmTabAcpOdrCarWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        private int ReadProc(ref PmTabAcpOdrCarWork pmTabAcpOdrCarWork, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CREATEDATETIMERF " + Environment.NewLine;      // �쐬����
                sqlText += " ,UPDATEDATETIMERF " + Environment.NewLine;      // �X�V����
                sqlText += " ,ENTERPRISECODERF " + Environment.NewLine;      // ��ƃR�[�h
                sqlText += " ,FILEHEADERGUIDRF " + Environment.NewLine;      // GUID
                sqlText += " ,UPDEMPLOYEECODERF " + Environment.NewLine;     // �X�V�]�ƈ��R�[�h
                sqlText += " ,UPDASSEMBLYID1RF " + Environment.NewLine;      // �X�V�A�Z���u��ID1
                sqlText += " ,UPDASSEMBLYID2RF " + Environment.NewLine;      // �X�V�A�Z���u��ID2
                sqlText += " ,LOGICALDELETECODERF " + Environment.NewLine;   // �_���폜�敪
                sqlText += " ,BUSINESSSESSIONIDRF " + Environment.NewLine;	 // �Ɩ��Z�b�V����ID
                sqlText += " ,SEARCHSECTIONCODERF " + Environment.NewLine;   // �������_�R�[�h
                sqlText += " ,PMTABDTLDISCGUIDRF " + Environment.NewLine;    // PMTAB���׎���GUID
                sqlText += " ,DATADELETEDATERF " + Environment.NewLine;      // �f�[�^�폜�\���
                sqlText += " ,ACCEPTANORDERNORF " + Environment.NewLine;     // �󒍔ԍ�
                sqlText += " ,ACPTANODRSTATUSRF " + Environment.NewLine;     // �󒍃X�e�[�^�X
                sqlText += " ,DATAINPUTSYSTEMRF " + Environment.NewLine;     // �f�[�^���̓V�X�e��
                sqlText += " ,CARMNGNORF " + Environment.NewLine;            // �ԗ��Ǘ��ԍ�
                sqlText += " ,CARMNGCODERF " + Environment.NewLine;          // ���q�Ǘ��R�[�h
                sqlText += " ,NUMBERPLATE1CODERF " + Environment.NewLine;    // ���^�������ԍ�
                sqlText += " ,NUMBERPLATE1NAMERF " + Environment.NewLine;    // ���^�����ǖ���
                sqlText += " ,NUMBERPLATE2RF " + Environment.NewLine;        // �ԗ��o�^�ԍ��i��ʁj
                sqlText += " ,NUMBERPLATE3RF " + Environment.NewLine;        // �ԗ��o�^�ԍ��i�J�i�j
                sqlText += " ,NUMBERPLATE4RF " + Environment.NewLine;        // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                sqlText += " ,FIRSTENTRYDATERF " + Environment.NewLine;      // ���N�x
                sqlText += " ,MAKERCODERF " + Environment.NewLine;	         // ���[�J�[�R�[�h
                sqlText += " ,MAKERFULLNAMERF " + Environment.NewLine;       // ���[�J�[�S�p����
                sqlText += " ,MAKERHALFNAMERF " + Environment.NewLine;       // ���[�J�[���p����
                sqlText += " ,MODELCODERF " + Environment.NewLine;           // �Ԏ�R�[�h
                sqlText += " ,MODELSUBCODERF " + Environment.NewLine;        // �Ԏ�T�u�R�[�h
                sqlText += " ,MODELFULLNAMERF " + Environment.NewLine;       // �Ԏ�S�p����
                sqlText += " ,MODELHALFNAMERF " + Environment.NewLine;       // �Ԏ피�p����
                sqlText += " ,EXHAUSTGASSIGNRF " + Environment.NewLine;      // �r�K�X�L��
                sqlText += " ,SERIESMODELRF " + Environment.NewLine;         // �V���[�Y�^��
                sqlText += " ,CATEGORYSIGNMODELRF " + Environment.NewLine;   // �^���i�ޕʋL���j
                sqlText += " ,FULLMODELRF " + Environment.NewLine;           // �^���i�t���^�j
                sqlText += " ,MODELDESIGNATIONNORF " + Environment.NewLine;  // �^���w��ԍ�
                sqlText += " ,CATEGORYNORF " + Environment.NewLine;          // �ޕʔԍ�
                sqlText += " ,FRAMEMODELRF " + Environment.NewLine;          // �ԑ�^��
                sqlText += " ,FRAMENORF " + Environment.NewLine;             // �ԑ�ԍ�
                sqlText += " ,SEARCHFRAMENORF " + Environment.NewLine;       // �ԑ�ԍ��i�����p�j
                sqlText += " ,ENGINEMODELNMRF " + Environment.NewLine;       // �G���W���^������
                sqlText += " ,RELEVANCEMODELRF " + Environment.NewLine;      // �֘A�^��
                sqlText += " ,SUBCARNMCDRF " + Environment.NewLine;          // �T�u�Ԗ��R�[�h
                sqlText += " ,MODELGRADESNAMERF " + Environment.NewLine;     // �^���O���[�h����
                sqlText += " ,COLORCODERF " + Environment.NewLine;           // �J���[�R�[�h
                sqlText += " ,COLORNAME1RF " + Environment.NewLine;          // �J���[����1
                sqlText += " ,TRIMCODERF " + Environment.NewLine;            // �g�����R�[�h
                sqlText += " ,TRIMNAMERF " + Environment.NewLine;            // �g��������
                sqlText += " ,MILEAGERF " + Environment.NewLine;             // �ԗ����s����
                sqlText += " ,FULLMODELFIXEDNOARYRF " + Environment.NewLine; // �t���^���Œ�ԍ��z��
                sqlText += " ,CATEGORYOBJARYRF " + Environment.NewLine;      // �����I�u�W�F�N�g�z��
                sqlText += " ,CARNOTERF " + Environment.NewLine;             // ���q���l
                sqlText += " ,FREESRCHMDLFXDNOARYRF " + Environment.NewLine; // ���R�����^���Œ�ԍ��z��
                sqlText += " ,DOMESTICFOREIGNCODERF " + Environment.NewLine;// ���Y�^�O�ԋ敪
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PMTABACPODRCARRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SEARCHSECTIONCODERF = @FINDSEARCHSECTIONCODE" + Environment.NewLine;
                sqlText += "  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine;

                // PMTAB���׎���GUID
                if (pmTabAcpOdrCarWork.PmTabDtlDiscGuid != "")
                {
                    sqlText += "  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine;
                    SqlParameter findPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@FINDPMTABDTLDISCGUID", SqlDbType.NChar);
                    findPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);
                }
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                sqlCommand.Parameters.Clear();
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findSearchSectionCode = sqlCommand.Parameters.Add("@FINDSEARCHSECTIONCODE", SqlDbType.NChar);
                SqlParameter findBusinessSessionId = sqlCommand.Parameters.Add("@FINDBUSINESSSESSIONID", SqlDbType.NChar);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);
                findSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);
                findBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToPmTabAcpOdrCarWorkFromReader(ref myReader, ref pmTabAcpOdrCarWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region [Delete]
        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���𕨗��폜���܂�
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">�����폜����󒍃}�X�^(�ԗ�)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)���𕨗��폜���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int Delete(object pmTabAcpOdrCarList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = pmTabAcpOdrCarList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���𕨗��폜���܂�
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">�󒍃}�X�^(�ԗ�)�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarList �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)���𕨗��폜���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int Delete(ArrayList pmTabAcpOdrCarList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(pmTabAcpOdrCarList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���𕨗��폜���܂�
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">�󒍃}�X�^(�ԗ�)�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarList �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)���𕨗��폜���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        private int DeleteProc(ArrayList pmTabAcpOdrCarList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pmTabAcpOdrCarList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmTabAcpOdrCarList.Count; i++)
                    {
                        PmTabAcpOdrCarWork pmTabAcpOdrCarWork = pmTabAcpOdrCarList[i] as PmTabAcpOdrCarWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PMTABACPODRCARRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SEARCHSECTIONCODERF = @FINDSEARCHSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine;
                        sqlText += "  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSearchSectionCode = sqlCommand.Parameters.Add("@FINDSEARCHSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findBusinessSessionId = sqlCommand.Parameters.Add("@FINDBUSINESSSESSIONID", SqlDbType.NChar);
                        SqlParameter findPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@FINDPMTABDTLDISCGUID", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);
                        findSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);
                        findBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);
                        findPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != pmTabAcpOdrCarWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  PMTABACPODRCARRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SEARCHSECTIONCODERF = @FINDSEARCHSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine;
                            sqlText += "  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);
                            findSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);
                            findBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);
                            findPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region [Search]
        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">��������</param>
        /// <param name="pmTabAcpOdrCarObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����A�S�Ă̎󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int Search(ref object pmTabAcpOdrCarList, object pmTabAcpOdrCarObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList pmTabAcpOdrCarArray = pmTabAcpOdrCarList as ArrayList;
                PmTabAcpOdrCarWork pmTabAcpOdrCarWork = pmTabAcpOdrCarObj as PmTabAcpOdrCarWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref pmTabAcpOdrCarArray, pmTabAcpOdrCarWork, readMode, logicalMode, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">�󒍃}�X�^(�ԗ�)�����i�[���� ArrayList</param>
        /// <param name="pmTabAcpOdrCarWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����A�S�Ă̎󒍃}�X�^(�ԗ�)��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int Search(ref ArrayList pmTabAcpOdrCarList, PmTabAcpOdrCarWork pmTabAcpOdrCarWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref pmTabAcpOdrCarList, pmTabAcpOdrCarWork, readMode, logicalMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">�󒍃}�X�^(�ԗ�)�����i�[���� ArrayList</param>
        /// <param name="pmTabAcpOdrCarWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����A�S�Ă̎󒍃}�X�^(�ԗ�)��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        private int SearchProc(ref ArrayList pmTabAcpOdrCarList, PmTabAcpOdrCarWork pmTabAcpOdrCarWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CREATEDATETIMERF " + Environment.NewLine;      // �쐬����
                sqlText += " ,UPDATEDATETIMERF " + Environment.NewLine;      // �X�V����
                sqlText += " ,ENTERPRISECODERF " + Environment.NewLine;      // ��ƃR�[�h
                sqlText += " ,FILEHEADERGUIDRF " + Environment.NewLine;      // GUID
                sqlText += " ,UPDEMPLOYEECODERF " + Environment.NewLine;     // �X�V�]�ƈ��R�[�h
                sqlText += " ,UPDASSEMBLYID1RF " + Environment.NewLine;      // �X�V�A�Z���u��ID1
                sqlText += " ,UPDASSEMBLYID2RF " + Environment.NewLine;      // �X�V�A�Z���u��ID2
                sqlText += " ,LOGICALDELETECODERF " + Environment.NewLine;   // �_���폜�敪
                sqlText += " ,BUSINESSSESSIONIDRF " + Environment.NewLine;	 // �Ɩ��Z�b�V����ID
                sqlText += " ,SEARCHSECTIONCODERF " + Environment.NewLine;   // �������_�R�[�h
                sqlText += " ,PMTABDTLDISCGUIDRF " + Environment.NewLine;    // PMTAB���׎���GUID
                sqlText += " ,DATADELETEDATERF " + Environment.NewLine;      // �f�[�^�폜�\���
                sqlText += " ,ACCEPTANORDERNORF " + Environment.NewLine;     // �󒍔ԍ�
                sqlText += " ,ACPTANODRSTATUSRF " + Environment.NewLine;     // �󒍃X�e�[�^�X
                sqlText += " ,DATAINPUTSYSTEMRF " + Environment.NewLine;     // �f�[�^���̓V�X�e��
                sqlText += " ,CARMNGNORF " + Environment.NewLine;            // �ԗ��Ǘ��ԍ�
                sqlText += " ,CARMNGCODERF " + Environment.NewLine;          // ���q�Ǘ��R�[�h
                sqlText += " ,NUMBERPLATE1CODERF " + Environment.NewLine;    // ���^�������ԍ�
                sqlText += " ,NUMBERPLATE1NAMERF " + Environment.NewLine;    // ���^�����ǖ���
                sqlText += " ,NUMBERPLATE2RF " + Environment.NewLine;        // �ԗ��o�^�ԍ��i��ʁj
                sqlText += " ,NUMBERPLATE3RF " + Environment.NewLine;        // �ԗ��o�^�ԍ��i�J�i�j
                sqlText += " ,NUMBERPLATE4RF " + Environment.NewLine;        // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                sqlText += " ,FIRSTENTRYDATERF " + Environment.NewLine;      // ���N�x
                sqlText += " ,MAKERCODERF " + Environment.NewLine;	         // ���[�J�[�R�[�h
                sqlText += " ,MAKERFULLNAMERF " + Environment.NewLine;       // ���[�J�[�S�p����
                sqlText += " ,MAKERHALFNAMERF " + Environment.NewLine;       // ���[�J�[���p����
                sqlText += " ,MODELCODERF " + Environment.NewLine;           // �Ԏ�R�[�h
                sqlText += " ,MODELSUBCODERF " + Environment.NewLine;        // �Ԏ�T�u�R�[�h
                sqlText += " ,MODELFULLNAMERF " + Environment.NewLine;       // �Ԏ�S�p����
                sqlText += " ,MODELHALFNAMERF " + Environment.NewLine;       // �Ԏ피�p����
                sqlText += " ,EXHAUSTGASSIGNRF " + Environment.NewLine;      // �r�K�X�L��
                sqlText += " ,SERIESMODELRF " + Environment.NewLine;         // �V���[�Y�^��
                sqlText += " ,CATEGORYSIGNMODELRF " + Environment.NewLine;   // �^���i�ޕʋL���j
                sqlText += " ,FULLMODELRF " + Environment.NewLine;           // �^���i�t���^�j
                sqlText += " ,MODELDESIGNATIONNORF " + Environment.NewLine;  // �^���w��ԍ�
                sqlText += " ,CATEGORYNORF " + Environment.NewLine;          // �ޕʔԍ�
                sqlText += " ,FRAMEMODELRF " + Environment.NewLine;          // �ԑ�^��
                sqlText += " ,FRAMENORF " + Environment.NewLine;             // �ԑ�ԍ�
                sqlText += " ,SEARCHFRAMENORF " + Environment.NewLine;       // �ԑ�ԍ��i�����p�j
                sqlText += " ,ENGINEMODELNMRF " + Environment.NewLine;       // �G���W���^������
                sqlText += " ,RELEVANCEMODELRF " + Environment.NewLine;      // �֘A�^��
                sqlText += " ,SUBCARNMCDRF " + Environment.NewLine;          // �T�u�Ԗ��R�[�h
                sqlText += " ,MODELGRADESNAMERF " + Environment.NewLine;     // �^���O���[�h����
                sqlText += " ,COLORCODERF " + Environment.NewLine;           // �J���[�R�[�h
                sqlText += " ,COLORNAME1RF " + Environment.NewLine;          // �J���[����1
                sqlText += " ,TRIMCODERF " + Environment.NewLine;            // �g�����R�[�h
                sqlText += " ,TRIMNAMERF " + Environment.NewLine;            // �g��������
                sqlText += " ,MILEAGERF " + Environment.NewLine;             // �ԗ����s����
                sqlText += " ,FULLMODELFIXEDNOARYRF " + Environment.NewLine; // �t���^���Œ�ԍ��z��
                sqlText += " ,CATEGORYOBJARYRF " + Environment.NewLine;      // �����I�u�W�F�N�g�z��
                sqlText += " ,CARNOTERF " + Environment.NewLine;             // ���q���l
                sqlText += " ,FREESRCHMDLFXDNOARYRF " + Environment.NewLine; // ���R�����^���Œ�ԍ��z��
                sqlText += " ,DOMESTICFOREIGNCODERF " + Environment.NewLine;// ���Y�^�O�ԋ敪
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PMTABACPODRCARRF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, pmTabAcpOdrCarWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    pmTabAcpOdrCarList.Add(this.CopyToPmTabAcpOdrCarWorkFromReader(ref myReader));
                }

                if (pmTabAcpOdrCarList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region [Write]
        /// <summary>
        /// �󒍃}�X�^(�ԗ�)����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">�ǉ��E�X�V����󒍃}�X�^(�ԗ�)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarList �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int Write(ref object pmTabAcpOdrCarList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = pmTabAcpOdrCarList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = this.Write(ref paraList, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">�ǉ��E�X�V����󒍃}�X�^(�ԗ�)�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarList �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int Write(ref ArrayList pmTabAcpOdrCarList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref pmTabAcpOdrCarList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">�ǉ��E�X�V����󒍃}�X�^(�ԗ�)�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarList �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        private int WriteProc(ref ArrayList pmTabAcpOdrCarList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (pmTabAcpOdrCarList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmTabAcpOdrCarList.Count; i++)
                    {
                        PmTabAcpOdrCarWork pmTabAcpOdrCarWork = pmTabAcpOdrCarList[i] as PmTabAcpOdrCarWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " FROM" + Environment.NewLine;
                        sqlText += "  PMTABACPODRCARRF" + Environment.NewLine;
                        sqlText += " WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SEARCHSECTIONCODERF = @FINDSEARCHSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine;
                        sqlText += "  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSearchSectionCode = sqlCommand.Parameters.Add("@FINDSEARCHSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findBusinessSessionId = sqlCommand.Parameters.Add("@FINDBUSINESSSESSIONID", SqlDbType.NChar);
                        SqlParameter findPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@FINDPMTABDTLDISCGUID", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);
                        findSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);
                        findBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);
                        findPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            pmTabAcpOdrCarWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
                            pmTabAcpOdrCarWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
                            # region [UPDATE��]

                            sqlText = string.Empty;
                            sqlText += " UPDATE PMTABACPODRCARRF" + Environment.NewLine;
                            sqlText += " SET " + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;      // �쐬����
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;      // �X�V����
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;      // ��ƃR�[�h
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;      // GUID
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;    // �X�V�]�ƈ��R�[�h
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;      // �X�V�A�Z���u��ID1
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;      // �X�V�A�Z���u��ID2
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;     // �_���폜�敪
                            sqlText += " ,BUSINESSSESSIONIDRF = @BUSINESSSESSIONID " + Environment.NewLine;	    // �Ɩ��Z�b�V����ID
                            sqlText += " ,SEARCHSECTIONCODERF = @SEARCHSECTIONCODE " + Environment.NewLine;     // �������_�R�[�h
                            sqlText += " ,PMTABDTLDISCGUIDRF = @PMTABDTLDISCGUID " + Environment.NewLine;       // PMTAB���׎���GUID
                            sqlText += " ,DATADELETEDATERF = @DATADELETEDATE " + Environment.NewLine;           // �f�[�^�폜�\���
                            sqlText += " ,ACCEPTANORDERNORF = @ACCEPTANORDERNO " + Environment.NewLine;         // �󒍔ԍ�
                            sqlText += " ,ACPTANODRSTATUSRF = @ACPTANODRSTATUS " + Environment.NewLine;         // �󒍃X�e�[�^�X
                            sqlText += " ,DATAINPUTSYSTEMRF = @DATAINPUTSYSTEM " + Environment.NewLine;         // �f�[�^���̓V�X�e��
                            sqlText += " ,CARMNGNORF = @CARMNGNO " + Environment.NewLine;                       // �ԗ��Ǘ��ԍ�
                            sqlText += " ,CARMNGCODERF = @CARMNGCODE " + Environment.NewLine;                   // ���q�Ǘ��R�[�h
                            sqlText += " ,NUMBERPLATE1CODERF = @NUMBERPLATE1CODE " + Environment.NewLine;       // ���^�������ԍ�
                            sqlText += " ,NUMBERPLATE1NAMERF = @NUMBERPLATE1NAME " + Environment.NewLine;       // ���^�����ǖ���
                            sqlText += " ,NUMBERPLATE2RF = @NUMBERPLATE2 " + Environment.NewLine;               // �ԗ��o�^�ԍ��i��ʁj
                            sqlText += " ,NUMBERPLATE3RF = @NUMBERPLATE3 " + Environment.NewLine;               // �ԗ��o�^�ԍ��i�J�i�j
                            sqlText += " ,NUMBERPLATE4RF = @NUMBERPLATE4 " + Environment.NewLine;               // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                            sqlText += " ,FIRSTENTRYDATERF = @FIRSTENTRYDATE " + Environment.NewLine;           // ���N�x
                            sqlText += " ,MAKERCODERF = @MAKERCODE " + Environment.NewLine;	                    // ���[�J�[�R�[�h
                            sqlText += " ,MAKERFULLNAMERF = @MAKERFULLNAME " + Environment.NewLine;             // ���[�J�[�S�p����
                            sqlText += " ,MAKERHALFNAMERF = @MAKERHALFNAME " + Environment.NewLine;             // ���[�J�[���p����
                            sqlText += " ,MODELCODERF = @MODELCODE " + Environment.NewLine;                     // �Ԏ�R�[�h
                            sqlText += " ,MODELSUBCODERF =@MODELSUBCODE " + Environment.NewLine;                // �Ԏ�T�u�R�[�h
                            sqlText += " ,MODELFULLNAMERF = @MODELFULLNAME " + Environment.NewLine;             // �Ԏ�S�p����
                            sqlText += " ,MODELHALFNAMERF = @MODELHALFNAME " + Environment.NewLine;             // �Ԏ피�p����
                            sqlText += " ,EXHAUSTGASSIGNRF = @EXHAUSTGASSIGN " + Environment.NewLine;           // �r�K�X�L��
                            sqlText += " ,SERIESMODELRF = @SERIESMODEL " + Environment.NewLine;                 // �V���[�Y�^��
                            sqlText += " ,CATEGORYSIGNMODELRF = @CATEGORYSIGNMODEL " + Environment.NewLine;     // �^���i�ޕʋL���j
                            sqlText += " ,FULLMODELRF = @FULLMODEL " + Environment.NewLine;                     // �^���i�t���^�j
                            sqlText += " ,MODELDESIGNATIONNORF = @MODELDESIGNATIONNO " + Environment.NewLine;   // �^���w��ԍ�
                            sqlText += " ,CATEGORYNORF = @CATEGORYNO " + Environment.NewLine;                   // �ޕʔԍ�
                            sqlText += " ,FRAMEMODELRF = @FRAMEMODEL " + Environment.NewLine;                   // �ԑ�^��
                            sqlText += " ,FRAMENORF = @FRAMENO " + Environment.NewLine;                         // �ԑ�ԍ�
                            sqlText += " ,SEARCHFRAMENORF = @SEARCHFRAMENO " + Environment.NewLine;             // �ԑ�ԍ��i�����p�j
                            sqlText += " ,ENGINEMODELNMRF = @ENGINEMODELNM " + Environment.NewLine;             // �G���W���^������
                            sqlText += " ,RELEVANCEMODELRF = @RELEVANCEMODEL " + Environment.NewLine;           // �֘A�^��
                            sqlText += " ,SUBCARNMCDRF = @SUBCARNMCD " + Environment.NewLine;                   // �T�u�Ԗ��R�[�h
                            sqlText += " ,MODELGRADESNAMERF = @MODELGRADESNAME " + Environment.NewLine;         // �^���O���[�h����
                            sqlText += " ,COLORCODERF = @COLORCODE " + Environment.NewLine;                     // �J���[�R�[�h
                            sqlText += " ,COLORNAME1RF = @COLORNAME1 " + Environment.NewLine;                   // �J���[����1
                            sqlText += " ,TRIMCODERF = @TRIMCODE " + Environment.NewLine;                       // �g�����R�[�h
                            sqlText += " ,TRIMNAMERF = @TRIMNAME " + Environment.NewLine;                       // �g��������
                            sqlText += " ,MILEAGERF = @MILEAGE " + Environment.NewLine;                         // �ԗ����s����
                            sqlText += " ,FULLMODELFIXEDNOARYRF = @FULLMODELFIXEDNOARY " + Environment.NewLine; // �t���^���Œ�ԍ��z��
                            sqlText += " ,CATEGORYOBJARYRF = @CATEGORYOBJARY " + Environment.NewLine;           // �����I�u�W�F�N�g�z��
                            sqlText += " ,CARNOTERF = @CARNOTE " + Environment.NewLine;                         // ���q���l
                            sqlText += " ,FREESRCHMDLFXDNOARYRF = @FREESRCHMDLFXDNOARY " + Environment.NewLine; // ���R�����^���Œ�ԍ��z��
                            sqlText += " ,DOMESTICFOREIGNCODERF = @DOMESTICFOREIGNCODE " + Environment.NewLine; // ���Y�^�O�ԋ敪
                            sqlText += " WHERE " + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  AND SEARCHSECTIONCODERF = @FINDSEARCHSECTIONCODE " + Environment.NewLine;
                            sqlText += "  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID " + Environment.NewLine;
                            sqlText += "  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID " + Environment.NewLine;

                            #endregion

                            // KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);
                            findSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);
                            findBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);
                            findPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmTabAcpOdrCarWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (pmTabAcpOdrCarWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            #region INSERT��

                            sqlText = string.Empty;
                            sqlText += "INSERT INTO PMTABACPODRCARRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF " + Environment.NewLine;      // �쐬����
                            sqlText += " ,UPDATEDATETIMERF " + Environment.NewLine;      // �X�V����
                            sqlText += " ,ENTERPRISECODERF " + Environment.NewLine;      // ��ƃR�[�h
                            sqlText += " ,FILEHEADERGUIDRF " + Environment.NewLine;      // GUID
                            sqlText += " ,UPDEMPLOYEECODERF " + Environment.NewLine;     // �X�V�]�ƈ��R�[�h
                            sqlText += " ,UPDASSEMBLYID1RF " + Environment.NewLine;      // �X�V�A�Z���u��ID1
                            sqlText += " ,UPDASSEMBLYID2RF " + Environment.NewLine;      // �X�V�A�Z���u��ID2
                            sqlText += " ,LOGICALDELETECODERF " + Environment.NewLine;   // �_���폜�敪
                            sqlText += " ,BUSINESSSESSIONIDRF " + Environment.NewLine;	 // �Ɩ��Z�b�V����ID
                            sqlText += " ,SEARCHSECTIONCODERF " + Environment.NewLine;   // �������_�R�[�h
                            sqlText += " ,PMTABDTLDISCGUIDRF " + Environment.NewLine;    // PMTAB���׎���GUID
                            sqlText += " ,DATADELETEDATERF " + Environment.NewLine;      // �f�[�^�폜�\���
                            sqlText += " ,ACCEPTANORDERNORF " + Environment.NewLine;     // �󒍔ԍ�
                            sqlText += " ,ACPTANODRSTATUSRF " + Environment.NewLine;     // �󒍃X�e�[�^�X
                            sqlText += " ,DATAINPUTSYSTEMRF " + Environment.NewLine;     // �f�[�^���̓V�X�e��
                            sqlText += " ,CARMNGNORF " + Environment.NewLine;            // �ԗ��Ǘ��ԍ�
                            sqlText += " ,CARMNGCODERF " + Environment.NewLine;          // ���q�Ǘ��R�[�h
                            sqlText += " ,NUMBERPLATE1CODERF " + Environment.NewLine;    // ���^�������ԍ�
                            sqlText += " ,NUMBERPLATE1NAMERF " + Environment.NewLine;    // ���^�����ǖ���
                            sqlText += " ,NUMBERPLATE2RF " + Environment.NewLine;        // �ԗ��o�^�ԍ��i��ʁj
                            sqlText += " ,NUMBERPLATE3RF " + Environment.NewLine;        // �ԗ��o�^�ԍ��i�J�i�j
                            sqlText += " ,NUMBERPLATE4RF " + Environment.NewLine;        // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                            sqlText += " ,FIRSTENTRYDATERF " + Environment.NewLine;      // ���N�x
                            sqlText += " ,MAKERCODERF " + Environment.NewLine;	         // ���[�J�[�R�[�h
                            sqlText += " ,MAKERFULLNAMERF " + Environment.NewLine;       // ���[�J�[�S�p����
                            sqlText += " ,MAKERHALFNAMERF " + Environment.NewLine;       // ���[�J�[���p����
                            sqlText += " ,MODELCODERF " + Environment.NewLine;           // �Ԏ�R�[�h
                            sqlText += " ,MODELSUBCODERF " + Environment.NewLine;        // �Ԏ�T�u�R�[�h
                            sqlText += " ,MODELFULLNAMERF " + Environment.NewLine;       // �Ԏ�S�p����
                            sqlText += " ,MODELHALFNAMERF " + Environment.NewLine;       // �Ԏ피�p����
                            sqlText += " ,EXHAUSTGASSIGNRF " + Environment.NewLine;      // �r�K�X�L��
                            sqlText += " ,SERIESMODELRF " + Environment.NewLine;         // �V���[�Y�^��
                            sqlText += " ,CATEGORYSIGNMODELRF " + Environment.NewLine;   // �^���i�ޕʋL���j
                            sqlText += " ,FULLMODELRF " + Environment.NewLine;           // �^���i�t���^�j
                            sqlText += " ,MODELDESIGNATIONNORF " + Environment.NewLine;  // �^���w��ԍ�
                            sqlText += " ,CATEGORYNORF " + Environment.NewLine;          // �ޕʔԍ�
                            sqlText += " ,FRAMEMODELRF " + Environment.NewLine;          // �ԑ�^��
                            sqlText += " ,FRAMENORF " + Environment.NewLine;             // �ԑ�ԍ�
                            sqlText += " ,SEARCHFRAMENORF " + Environment.NewLine;       // �ԑ�ԍ��i�����p�j
                            sqlText += " ,ENGINEMODELNMRF " + Environment.NewLine;       // �G���W���^������
                            sqlText += " ,RELEVANCEMODELRF " + Environment.NewLine;      // �֘A�^��
                            sqlText += " ,SUBCARNMCDRF " + Environment.NewLine;          // �T�u�Ԗ��R�[�h
                            sqlText += " ,MODELGRADESNAMERF " + Environment.NewLine;     // �^���O���[�h����
                            sqlText += " ,COLORCODERF " + Environment.NewLine;           // �J���[�R�[�h
                            sqlText += " ,COLORNAME1RF " + Environment.NewLine;          // �J���[����1
                            sqlText += " ,TRIMCODERF " + Environment.NewLine;            // �g�����R�[�h
                            sqlText += " ,TRIMNAMERF " + Environment.NewLine;            // �g��������
                            sqlText += " ,MILEAGERF " + Environment.NewLine;             // �ԗ����s����
                            sqlText += " ,FULLMODELFIXEDNOARYRF " + Environment.NewLine; // �t���^���Œ�ԍ��z��
                            sqlText += " ,CATEGORYOBJARYRF " + Environment.NewLine;      // �����I�u�W�F�N�g�z��
                            sqlText += " ,CARNOTERF " + Environment.NewLine;             // ���q���l
                            sqlText += " ,FREESRCHMDLFXDNOARYRF " + Environment.NewLine; // ���R�����^���Œ�ԍ��z��
                            sqlText += " ,DOMESTICFOREIGNCODERF) " + Environment.NewLine;// ���Y�^�O�ԋ敪
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "  (@CREATEDATETIME " + Environment.NewLine;      // �쐬����
                            sqlText += " ,@UPDATEDATETIME " + Environment.NewLine;       // �X�V����
                            sqlText += " ,@ENTERPRISECODE " + Environment.NewLine;       // ��ƃR�[�h
                            sqlText += " ,@FILEHEADERGUID " + Environment.NewLine;       // GUID
                            sqlText += " ,@UPDEMPLOYEECODE " + Environment.NewLine;      // �X�V�]�ƈ��R�[�h
                            sqlText += " ,@UPDASSEMBLYID1 " + Environment.NewLine;       // �X�V�A�Z���u��ID1
                            sqlText += " ,@UPDASSEMBLYID2 " + Environment.NewLine;       // �X�V�A�Z���u��ID2
                            sqlText += " ,@LOGICALDELETECODE " + Environment.NewLine;    // �_���폜�敪
                            sqlText += " ,@BUSINESSSESSIONID " + Environment.NewLine;	 // �Ɩ��Z�b�V����ID
                            sqlText += " ,@SEARCHSECTIONCODE " + Environment.NewLine;    // �������_�R�[�h
                            sqlText += " ,@PMTABDTLDISCGUID " + Environment.NewLine;     // PMTAB���׎���GUID
                            sqlText += " ,@DATADELETEDATE " + Environment.NewLine;       // �f�[�^�폜�\���
                            sqlText += " ,@ACCEPTANORDERNO " + Environment.NewLine;      // �󒍔ԍ�
                            sqlText += " ,@ACPTANODRSTATUS " + Environment.NewLine;      // �󒍃X�e�[�^�X
                            sqlText += " ,@DATAINPUTSYSTEM " + Environment.NewLine;      // �f�[�^���̓V�X�e��
                            sqlText += " ,@CARMNGNO " + Environment.NewLine;             // �ԗ��Ǘ��ԍ�
                            sqlText += " ,@CARMNGCODE " + Environment.NewLine;           // ���q�Ǘ��R�[�h
                            sqlText += " ,@NUMBERPLATE1CODE " + Environment.NewLine;     // ���^�������ԍ�
                            sqlText += " ,@NUMBERPLATE1NAME " + Environment.NewLine;     // ���^�����ǖ���
                            sqlText += " ,@NUMBERPLATE2 " + Environment.NewLine;         // �ԗ��o�^�ԍ��i��ʁj
                            sqlText += " ,@NUMBERPLATE3 " + Environment.NewLine;         // �ԗ��o�^�ԍ��i�J�i�j
                            sqlText += " ,@NUMBERPLATE4 " + Environment.NewLine;         // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                            sqlText += " ,@FIRSTENTRYDATE " + Environment.NewLine;       // ���N�x
                            sqlText += " ,@MAKERCODE " + Environment.NewLine;	         // ���[�J�[�R�[�h
                            sqlText += " ,@MAKERFULLNAME " + Environment.NewLine;        // ���[�J�[�S�p����
                            sqlText += " ,@MAKERHALFNAME " + Environment.NewLine;        // ���[�J�[���p����
                            sqlText += " ,@MODELCODE " + Environment.NewLine;            // �Ԏ�R�[�h
                            sqlText += " ,@MODELSUBCODE " + Environment.NewLine;         // �Ԏ�T�u�R�[�h
                            sqlText += " ,@MODELFULLNAME " + Environment.NewLine;        // �Ԏ�S�p����
                            sqlText += " ,@MODELHALFNAME " + Environment.NewLine;        // �Ԏ피�p����
                            sqlText += " ,@EXHAUSTGASSIGN " + Environment.NewLine;       // �r�K�X�L��
                            sqlText += " ,@SERIESMODEL " + Environment.NewLine;          // �V���[�Y�^��
                            sqlText += " ,@CATEGORYSIGNMODEL " + Environment.NewLine;    // �^���i�ޕʋL���j
                            sqlText += " ,@FULLMODEL " + Environment.NewLine;            // �^���i�t���^�j
                            sqlText += " ,@MODELDESIGNATIONNO " + Environment.NewLine;   // �^���w��ԍ�
                            sqlText += " ,@CATEGORYNO " + Environment.NewLine;           // �ޕʔԍ�
                            sqlText += " ,@FRAMEMODEL " + Environment.NewLine;           // �ԑ�^��
                            sqlText += " ,@FRAMENO " + Environment.NewLine;              // �ԑ�ԍ�
                            sqlText += " ,@SEARCHFRAMENO " + Environment.NewLine;        // �ԑ�ԍ��i�����p�j
                            sqlText += " ,@ENGINEMODELNM " + Environment.NewLine;        // �G���W���^������
                            sqlText += " ,@RELEVANCEMODEL " + Environment.NewLine;       // �֘A�^��
                            sqlText += " ,@SUBCARNMCD " + Environment.NewLine;           // �T�u�Ԗ��R�[�h
                            sqlText += " ,@MODELGRADESNAME " + Environment.NewLine;      // �^���O���[�h����
                            sqlText += " ,@COLORCODE " + Environment.NewLine;            // �J���[�R�[�h
                            sqlText += " ,@COLORNAME1 " + Environment.NewLine;           // �J���[����1
                            sqlText += " ,@TRIMCODE " + Environment.NewLine;             // �g�����R�[�h
                            sqlText += " ,@TRIMNAME " + Environment.NewLine;             // �g��������
                            sqlText += " ,@MILEAGE " + Environment.NewLine;              // �ԗ����s����
                            sqlText += " ,@FULLMODELFIXEDNOARY " + Environment.NewLine;  // �t���^���Œ�ԍ��z��
                            sqlText += " ,@CATEGORYOBJARY " + Environment.NewLine;       // �����I�u�W�F�N�g�z��
                            sqlText += " ,@CARNOTE " + Environment.NewLine;              // ���q���l
                            sqlText += " ,@FREESRCHMDLFXDNOARY " + Environment.NewLine;  // ���R�����^���Œ�ԍ��z��
                            sqlText += " ,@DOMESTICFOREIGNCODE " + Environment.NewLine;  // ���Y�^�O�ԋ敪
                            sqlText += ")" + Environment.NewLine;

                            #endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmTabAcpOdrCarWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.CommandText = sqlText;

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);                    // �쐬����
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);                    // �X�V����
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);                     // ��ƃR�[�h
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);          // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);                   // �X�V�]�ƈ��R�[�h
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);                  // �X�V�A�Z���u��ID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);                  // �X�V�A�Z���u��ID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);                 // �_���폜�敪
                        SqlParameter paraBusinessSessionId = sqlCommand.Parameters.Add("@BUSINESSSESSIONID", SqlDbType.NChar);               // �Ɩ��Z�b�V����ID
                        SqlParameter paraSearchSectionCode = sqlCommand.Parameters.Add("@SEARCHSECTIONCODE", SqlDbType.NChar);               // �������_�R�[�h
                        SqlParameter paraPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@PMTABDTLDISCGUID", SqlDbType.NChar);	     // PMTAB���׎���GUID
                        SqlParameter paraDataDeleteDate = sqlCommand.Parameters.Add("@DATADELETEDATE", SqlDbType.Int);                       // �f�[�^�폜�\���
                        SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);                     // �󒍔ԍ�
                        SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);                     // �󒍃X�e�[�^�X
                        SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);                     // �f�[�^���̓V�X�e��
                        SqlParameter paraCarMngNo = sqlCommand.Parameters.Add("@CARMNGNO", SqlDbType.Int);                                   // �ԗ��Ǘ��ԍ�
                        SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@CARMNGCODE", SqlDbType.NVarChar);                          //���q�Ǘ��R�[�h
                        SqlParameter paraNumberPlate1Code = sqlCommand.Parameters.Add("@NUMBERPLATE1CODE", SqlDbType.Int);                   // ���^�������ԍ�
                        SqlParameter paraNumberPlate1Name = sqlCommand.Parameters.Add("@NUMBERPLATE1NAME", SqlDbType.NVarChar);              // ���^�����ǖ���
                        SqlParameter paraNumberPlate2 = sqlCommand.Parameters.Add("@NUMBERPLATE2", SqlDbType.NVarChar);                      // �ԗ��o�^�ԍ��i��ʁj
                        SqlParameter paraNumberPlate3 = sqlCommand.Parameters.Add("@NUMBERPLATE3", SqlDbType.NVarChar);                      // �ԗ��o�^�ԍ��i�J�i�j
                        SqlParameter paraNumberPlate4 = sqlCommand.Parameters.Add("@NUMBERPLATE4", SqlDbType.Int);                           // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                        SqlParameter paraFirstEntryDate = sqlCommand.Parameters.Add("@FIRSTENTRYDATE", SqlDbType.Int);                       // ���N�x
                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);                                 // ���[�J�[�R�[�h
                        SqlParameter paraMakerFullName = sqlCommand.Parameters.Add("@MAKERFULLNAME", SqlDbType.NVarChar);                    // ���[�J�[�S�p����
                        SqlParameter paraMakerHalfName = sqlCommand.Parameters.Add("@MAKERHALFNAME", SqlDbType.NVarChar);                    // ���[�J�[���p����
                        SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);                                 // �Ԏ�R�[�h
                        SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);                           // �Ԏ�T�u�R�[�h
                        SqlParameter paraModelFullName = sqlCommand.Parameters.Add("@MODELFULLNAME", SqlDbType.NVarChar);                    // �Ԏ�S�p����
                        SqlParameter paraModelHalfName = sqlCommand.Parameters.Add("@MODELHALFNAME", SqlDbType.NVarChar);                    // �Ԏ피�p����
                        SqlParameter paraExhaustGasSign = sqlCommand.Parameters.Add("@EXHAUSTGASSIGN", SqlDbType.NVarChar);                  // �r�K�X�L��
                        SqlParameter paraSeriesModel = sqlCommand.Parameters.Add("@SERIESMODEL", SqlDbType.NVarChar);                        // �V���[�Y�^��
                        SqlParameter paraCategorySignModel = sqlCommand.Parameters.Add("@CATEGORYSIGNMODEL", SqlDbType.NVarChar);            // �^���i�ޕʋL���j
                        SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FULLMODEL", SqlDbType.NVarChar);                            // �^���i�t���^�j
                        SqlParameter paraModelDesignationNo = sqlCommand.Parameters.Add("@MODELDESIGNATIONNO", SqlDbType.Int);               // �^���w��ԍ�
                        SqlParameter paraCategoryNo = sqlCommand.Parameters.Add("@CATEGORYNO", SqlDbType.Int);                               // �ޕʔԍ�
                        SqlParameter paraFrameModel = sqlCommand.Parameters.Add("@FRAMEMODEL", SqlDbType.NVarChar);                          // �ԑ�^��
                        SqlParameter paraFrameNo = sqlCommand.Parameters.Add("@FRAMENO", SqlDbType.NVarChar);                                // �ԑ�ԍ�
                        SqlParameter paraSearchFrameNo = sqlCommand.Parameters.Add("@SEARCHFRAMENO", SqlDbType.Int);                         // �ԑ�ԍ��i�����p�j
                        SqlParameter paraEngineModelNm = sqlCommand.Parameters.Add("@ENGINEMODELNM", SqlDbType.NVarChar);                    // �G���W���^������
                        SqlParameter paraRelevanceModel = sqlCommand.Parameters.Add("@RELEVANCEMODEL", SqlDbType.NVarChar);                  // �֘A�^��
                        SqlParameter paraSubCarNmCd = sqlCommand.Parameters.Add("@SUBCARNMCD", SqlDbType.Int);                               // �T�u�Ԗ��R�[�h
                        SqlParameter paraModelGradeSname = sqlCommand.Parameters.Add("@MODELGRADESNAME", SqlDbType.NVarChar);                // �^���O���[�h����
                        SqlParameter paraColorCode = sqlCommand.Parameters.Add("@COLORCODE", SqlDbType.NVarChar);                            // �J���[�R�[�h
                        SqlParameter paraColorName1 = sqlCommand.Parameters.Add("@COLORNAME1", SqlDbType.NVarChar);                          // �J���[����1
                        SqlParameter paraTrimCode = sqlCommand.Parameters.Add("@TRIMCODE", SqlDbType.NVarChar);                              // �g�����R�[�h
                        SqlParameter paraTrimName = sqlCommand.Parameters.Add("@TRIMNAME", SqlDbType.NVarChar);                              // �g��������
                        SqlParameter paraMileage = sqlCommand.Parameters.Add("@MILEAGE", SqlDbType.Int);                                     // �ԗ����s����
                        SqlParameter paraFullModelFixedNoAry = sqlCommand.Parameters.Add("@FULLMODELFIXEDNOARY", SqlDbType.VarBinary);       // �t���^���Œ�ԍ��z��
                        SqlParameter paraCategoryObjAry = sqlCommand.Parameters.Add("@CATEGORYOBJARY", SqlDbType.VarBinary);                 // �����I�u�W�F�N�g�z��
                        SqlParameter paraCarNote = sqlCommand.Parameters.Add("@CARNOTE", SqlDbType.NVarChar);                                // ���q���l
                        SqlParameter paraFreeSrchMdlFxdNoAry = sqlCommand.Parameters.Add("@FREESRCHMDLFXDNOARY", SqlDbType.VarBinary);       // ���R�����^���Œ�ԍ��z��
                        SqlParameter paraDomesticForeignCode = sqlCommand.Parameters.Add("@DOMESTICFOREIGNCODE", SqlDbType.Int);             // ���Y�^�O�ԋ敪
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabAcpOdrCarWork.CreateDateTime);        // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabAcpOdrCarWork.UpdateDateTime);        // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);                   // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pmTabAcpOdrCarWork.FileHeaderGuid);                     // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.UpdEmployeeCode);                 // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.UpdAssemblyId1);                   // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.UpdAssemblyId2);                   // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.LogicalDeleteCode);              // �_���폜�敪
                        paraBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);             // �Ɩ��Z�b�V����ID
                        paraSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);             // �������_�R�[�h
                        paraPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);               // PMTAB���׎���GUID
                        paraDataDeleteDate.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.DataDeleteDate);                    // �f�[�^�폜�\���
                        paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.AcceptAnOrderNo);                  // �󒍔ԍ�
                        paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.AcptAnOdrStatus);                  // �󒍃X�e�[�^�X
                        paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.DataInputSystem);                  // �f�[�^���̓V�X�e��
                        paraCarMngNo.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.CarMngNo);                                // �ԗ��Ǘ��ԍ�
                        paraCarMngCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.CarMngCode);                           // ���q�Ǘ��R�[�h
                        paraNumberPlate1Code.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.NumberPlate1Code);                // ���^�������ԍ�
                        paraNumberPlate1Name.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.NumberPlate1Name);               // ���^�����ǖ���
                        paraNumberPlate2.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.NumberPlate2);                       // �ԗ��o�^�ԍ��i��ʁj
                        paraNumberPlate3.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.NumberPlate3);                       // �ԗ��o�^�ԍ��i�J�i�j
                        paraNumberPlate4.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.NumberPlate4);                        // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                        paraFirstEntryDate.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.FirstEntryDate);                    // ���N�x
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.MakerCode);                              // ���[�J�[�R�[�h
                        paraMakerFullName.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.MakerFullName);                     // ���[�J�[�S�p����
                        paraMakerHalfName.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.MakerHalfName);                     // ���[�J�[���p����
                        paraModelCode.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.ModelCode);                              // �Ԏ�R�[�h
                        paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.ModelSubCode);                        // �Ԏ�T�u�R�[�h
                        paraModelFullName.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.ModelFullName);                     // �Ԏ�S�p����
                        paraModelHalfName.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.ModelHalfName);                     // �Ԏ피�p����
                        paraExhaustGasSign.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.ExhaustGasSign);                   // �r�K�X�L��
                        paraSeriesModel.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SeriesModel);                         // �V���[�Y�^��
                        paraCategorySignModel.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.CategorySignModel);             // �^���i�ޕʋL���j
                        paraFullModel.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.FullModel);                             // �^���i�t���^�j
                        paraModelDesignationNo.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.ModelDesignationNo);            // �^���w��ԍ�
                        paraCategoryNo.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.CategoryNo);                            // �ޕʔԍ�
                        paraFrameModel.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.FrameModel);                           // �ԑ�^��
                        paraFrameNo.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.FrameNo);                                 // �ԑ�ԍ�
                        paraSearchFrameNo.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.SearchFrameNo);                      // �ԑ�ԍ��i�����p�j
                        paraEngineModelNm.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EngineModelNm);                     // �G���W���^������
                        paraRelevanceModel.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.RelevanceModel);                   // �֘A�^��
                        paraSubCarNmCd.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.SubCarNmCd);                            // �T�u�Ԗ��R�[�h
                        paraModelGradeSname.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.ModelGradeSname);                 // �^���O���[�h����
                        paraColorCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.ColorCode);                             // �J���[�R�[�h
                        paraColorName1.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.ColorName1);                           // �J���[����1
                        paraTrimCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.TrimCode);                               // �g�����R�[�h
                        paraTrimName.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.TrimName);                               // �g��������
                        paraMileage.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.Mileage);                                  // �ԗ����s����
                        // �t���^���Œ�ԍ��z��
                        // int[] �� byte[] �ɕϊ�
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        foreach (int item in pmTabAcpOdrCarWork.FullModelFixedNoAry)
                            ms.Write(BitConverter.GetBytes(item), 0, sizeof(int));
                        byte[] verbinary = ms.ToArray();
                        ms.Close();

                        paraFullModelFixedNoAry.Value = SqlDataMediator.SqlSetBinary(verbinary);                                      // �t���^���Œ�ԍ��z��

                        paraCategoryObjAry.Value = SqlDataMediator.SqlSetBinary(pmTabAcpOdrCarWork.CategoryObjAry);                   // �����I�u�W�F�N�g�z��
                        paraCarNote.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.CarNote);                                 // ���q���l
                        paraFreeSrchMdlFxdNoAry.Value = SqlDataMediator.SqlSetBinary(pmTabAcpOdrCarWork.FreeSrchMdlFxdNoAry);         // ���R�����^���Œ�ԍ��z��
                        paraDomesticForeignCode.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.DomesticForeignCode);          // ���Y�^�O�ԋ敪

                        #endregion

                        int cnt = sqlCommand.ExecuteNonQuery();
                        al.Add(pmTabAcpOdrCarWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    //sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            pmTabAcpOdrCarList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// �󒍃}�X�^(�ԗ�)����_���폜���܂��B
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">�_���폜����󒍃}�X�^(�ԗ�)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarWork �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)����_���폜���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int LogicalDelete(ref object pmTabAcpOdrCarList)
        {
            return this.LogicalDelete(ref pmTabAcpOdrCarList, 0);
        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���̘_���폜���������܂��B
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">�_���폜����������󒍃}�X�^(�ԗ�)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarWork �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)���̘_���폜���������܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int RevivalLogicalDelete(ref object pmTabAcpOdrCarList)
        {
            return this.LogicalDelete(ref pmTabAcpOdrCarList, 1);
        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">�_���폜�𑀍삷��󒍃}�X�^(�ԗ�)���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarWork �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        private int LogicalDelete(ref object pmTabAcpOdrCarList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = pmTabAcpOdrCarList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">�_���폜�𑀍삷��󒍃}�X�^(�ԗ�)�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarWork �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int LogicalDelete(ref ArrayList pmTabAcpOdrCarList, int procMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref pmTabAcpOdrCarList, procMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">�_���폜�𑀍삷��󒍃}�X�^(�ԗ�)�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarWork �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        private int LogicalDeleteProc(ref ArrayList pmTabAcpOdrCarList, int procMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (pmTabAcpOdrCarList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmTabAcpOdrCarList.Count; i++)
                    {
                        PmTabAcpOdrCarWork pmTabAcpOdrCarWork = pmTabAcpOdrCarList[i] as PmTabAcpOdrCarWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PMTABACPODRCARRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SEARCHSECTIONCODERF = @FINDSEARCHSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine;
                        sqlText += "  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSearchSectionCode = sqlCommand.Parameters.Add("@FINDSEARCHSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findBusinessSessionId = sqlCommand.Parameters.Add("@FINDBUSINESSSESSIONID", SqlDbType.NChar);
                        SqlParameter findPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@FINDPMTABDTLDISCGUID", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);
                        findSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);
                        findBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);
                        findPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != pmTabAcpOdrCarWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  PMTABACPODRCARRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SEARCHSECTIONCODERF = @FINDSEARCHSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine;
                            sqlText += "  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);
                            findSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);
                            findBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);
                            findPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmTabAcpOdrCarWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        // �_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // ���ɍ폜�ς݂̏ꍇ����
                                return status;
                            }
                            else if (logicalDelCd == 0) pmTabAcpOdrCarWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else pmTabAcpOdrCarWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                pmTabAcpOdrCarWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
                            }
                            else
                            {
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // ���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // ���S�폜�̓f�[�^�Ȃ���߂�
                                }

                                return status;
                            }
                        }

                        // Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabAcpOdrCarWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(pmTabAcpOdrCarWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            pmTabAcpOdrCarList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="pmTabAcpOdrCarWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, PmTabAcpOdrCarWork pmTabAcpOdrCarWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // ��ƃR�[�h
            retstring += "  ACAR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // �������_�R�[�h
            if (pmTabAcpOdrCarWork.SearchSectionCode != "")
            {
                retstring += "  AND SEARCHSECTIONCODERF = @FINDSEARCHSECTIONCODE" + Environment.NewLine;
                SqlParameter findSearchSectionCode = sqlCommand.Parameters.Add("@FINDSEARCHSECTIONCODE", SqlDbType.NChar);
                findSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);
            }

            // �Ɩ��Z�b�V����ID
            if (pmTabAcpOdrCarWork.BusinessSessionId != "")
            {
                retstring += "  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine;
                SqlParameter findBusinessSessionId = sqlCommand.Parameters.Add("@FINDBUSINESSSESSIONID", SqlDbType.NChar);
                findBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);
            }

            // PMTAB���׎���GUID
            if (pmTabAcpOdrCarWork.PmTabDtlDiscGuid != "")
            {
                retstring += "  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine;
                SqlParameter findPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@FINDPMTABDTLDISCGUID", SqlDbType.NChar);
                findPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);
            }

            return retstring;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� PmTabAcpOdrCarWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PmTabAcpOdrCarWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        /// </remarks>
        private PmTabAcpOdrCarWork CopyToPmTabAcpOdrCarWorkFromReader(ref SqlDataReader myReader)
        {
            PmTabAcpOdrCarWork pmTabAcpOdrCarWork = new PmTabAcpOdrCarWork();

            this.CopyToPmTabAcpOdrCarWorkFromReader(ref myReader, ref pmTabAcpOdrCarWork);

            return pmTabAcpOdrCarWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� PmTabAcpOdrCarWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="pmTabAcpOdrCarWork">PmTabAcpOdrCarWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        /// </remarks>
        private void CopyToPmTabAcpOdrCarWorkFromReader(ref SqlDataReader myReader, ref PmTabAcpOdrCarWork pmTabAcpOdrCarWork)
        {
            if (myReader != null && pmTabAcpOdrCarWork != null)
            {
                # region �N���X�֊i�[
                pmTabAcpOdrCarWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
                pmTabAcpOdrCarWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
                pmTabAcpOdrCarWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));             // ��ƃR�[�h
                pmTabAcpOdrCarWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
                pmTabAcpOdrCarWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));           // �X�V�]�ƈ��R�[�h
                pmTabAcpOdrCarWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));             // �X�V�A�Z���u��ID1
                pmTabAcpOdrCarWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));             // �X�V�A�Z���u��ID2
                pmTabAcpOdrCarWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));        // �_���폜�敪
                pmTabAcpOdrCarWork.BusinessSessionId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSSESSIONIDRF"));       // �Ɩ��Z�b�V����ID
                pmTabAcpOdrCarWork.SearchSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHSECTIONCODERF"));       // �������_�R�[�h
                pmTabAcpOdrCarWork.PmTabDtlDiscGuid = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMTABDTLDISCGUIDRF"));           // PMTAB���׎���GUID
                pmTabAcpOdrCarWork.DataDeleteDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATADELETEDATERF"));              // �f�[�^�폜�\���
                pmTabAcpOdrCarWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));            // �󒍔ԍ�
                pmTabAcpOdrCarWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));            // �󒍃X�e�[�^�X
                pmTabAcpOdrCarWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));            // �f�[�^���̓V�X�e��
                pmTabAcpOdrCarWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));                          // �ԗ��Ǘ��ԍ�
                pmTabAcpOdrCarWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));                     // ���q�Ǘ��R�[�h
                pmTabAcpOdrCarWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));          // ���^�������ԍ�
                pmTabAcpOdrCarWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));         // ���^�����ǖ���
                pmTabAcpOdrCarWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));                 // �ԗ��o�^�ԍ��i��ʁj
                pmTabAcpOdrCarWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));                 // �ԗ��o�^�ԍ��i�J�i�j
                pmTabAcpOdrCarWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));                  // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                pmTabAcpOdrCarWork.FirstEntryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));              // ���N�x
                pmTabAcpOdrCarWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));                        // ���[�J�[�R�[�h
                pmTabAcpOdrCarWork.MakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERFULLNAMERF"));               // ���[�J�[�S�p����
                pmTabAcpOdrCarWork.MakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERHALFNAMERF"));               // ���[�J�[���p����
                pmTabAcpOdrCarWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));                        // �Ԏ�R�[�h
                pmTabAcpOdrCarWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));                  // �Ԏ�T�u�R�[�h
                pmTabAcpOdrCarWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));               // �Ԏ�S�p����
                pmTabAcpOdrCarWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));               // �Ԏ피�p����
                pmTabAcpOdrCarWork.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));             // �r�K�X�L��
                pmTabAcpOdrCarWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));                   // �V���[�Y�^��
                pmTabAcpOdrCarWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));       // �^���i�ޕʋL���j
                pmTabAcpOdrCarWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));                       // �^���i�t���^�j
                pmTabAcpOdrCarWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));      // �^���w��ԍ�
                pmTabAcpOdrCarWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));                      // �ޕʔԍ�
                pmTabAcpOdrCarWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));                     // �ԑ�^��
                pmTabAcpOdrCarWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));                           // �ԑ�ԍ�
                pmTabAcpOdrCarWork.SearchFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHFRAMENORF"));                // �ԑ�ԍ��i�����p�j
                pmTabAcpOdrCarWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));               // �G���W���^������
                pmTabAcpOdrCarWork.RelevanceModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RELEVANCEMODELRF"));             // �֘A�^��
                pmTabAcpOdrCarWork.SubCarNmCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBCARNMCDRF"));                      // �T�u�Ԗ��R�[�h
                pmTabAcpOdrCarWork.ModelGradeSname = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADESNAMERF"));           // �^���O���[�h����
                pmTabAcpOdrCarWork.ColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORCODERF"));                       // �J���[�R�[�h
                pmTabAcpOdrCarWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));                     // �J���[����1
                pmTabAcpOdrCarWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));                         // �g�����R�[�h
                pmTabAcpOdrCarWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));                         // �g��������
                pmTabAcpOdrCarWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));                            // �ԗ����s����
                byte[] varbinary = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FULLMODELFIXEDNOARYRF"));                         // �t���^���Œ�ԍ��z��

                if (null != varbinary)
                {
                    pmTabAcpOdrCarWork.FullModelFixedNoAry = new int[(int)varbinary.Length / sizeof(int)];

                    for (int idx = 0; idx < pmTabAcpOdrCarWork.FullModelFixedNoAry.Length; idx++)
                    {
                        pmTabAcpOdrCarWork.FullModelFixedNoAry[idx] = BitConverter.ToInt32(varbinary, idx * sizeof(int));
                    }
                }
                else
                {
                    pmTabAcpOdrCarWork.FullModelFixedNoAry = new int[0];
                }
                pmTabAcpOdrCarWork.CategoryObjAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("CATEGORYOBJARYRF"));             // �����I�u�W�F�N�g�z��
                pmTabAcpOdrCarWork.CarNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARNOTERF"));                           // ���q���l
                pmTabAcpOdrCarWork.FreeSrchMdlFxdNoAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FREESRCHMDLFXDNOARYRF"));   // ���R�����^���Œ�ԍ��z��
                pmTabAcpOdrCarWork.DomesticForeignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOMESTICFOREIGNCODERF"));    // ���Y�^�O�ԋ敪
                # endregion
            }
        }
        # endregion
    }
}
