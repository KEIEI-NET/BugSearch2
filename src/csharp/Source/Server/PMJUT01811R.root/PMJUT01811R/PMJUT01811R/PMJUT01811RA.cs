//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �󒍃}�X�^(�ԗ�)DB�����[�g�I�u�W�F�N�g
//                  :   PMJUT01811R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112�@�v�ۓc
// Date             :   2008.05.28
//----------------------------------------------------------------------
// Update Note      :   ���仁@2009/09/07�@
//                      ���q���l�̒ǉ�
// Update Note      :   2010/04/27 gaoyh
//                  :   �󒍃}�X�^�i�ԗ��j�Ɏ��R�����^���Œ�ԍ��z��̒ǉ�
// Update Note      :   SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ� 
// Programmer       :   FSI���� �G
// Date             :   2013/03/21
// �Ǘ��ԍ�         :   10900269-00
// Update Note      :   PMKOBETSU-4076 �^�C���A�E�g�ݒ�
// Programmer       :   �c����
// Date             :   2020/08/28
// �Ǘ��ԍ�         :   11600006-00
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
using System.IO;
using System.Xml;
using Microsoft.Win32;
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �󒍃}�X�^(�ԗ�)DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �󒍃}�X�^(�ԗ�)�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc</br>
    /// <br>Date       : 2008.05.28</br>
    /// <br></br>
    /// <br>Update Note: 2009/09/07 ����</br>
    /// <br>              ���q���l�̒ǉ�</br>
    /// <br>Update Note      :   2010/04/27 gaoyh</br>
    /// <br>                 :   �󒍃}�X�^�i�ԗ��j�Ɏ��R�����^���Œ�ԍ��z��̒ǉ�</br>
    /// <br>Update Note: 2020/08/28 �c����</br>
    /// <br>             PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br>
    /// </remarks>
    [Serializable]
    public class AcceptOdrCarDB : RemoteWithAppLockDB, IAcceptOdrCarDB
    {
        private bool _CompulsoryDataOverride = false;
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>> 
        // �`�[�X�V�^�C���A�E�g���Ԑݒ�t�@�C��
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XML�t�@�C�����������̃f�t�H���g�l
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        /// <br></br>
        /// <br>Update Note: UOEWEB e-Parts�Ή�</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2009.05.28</br>
        /// </remarks>
        public AcceptOdrCarDB() : base("PMJUT01813D", "Broadleaf.Application.Remoting.ParamData.AcceptOdrCarWork", "ACCEPTODRCARRF")
        {
            this._CompulsoryDataOverride = false;

        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="compulsoryDataOverride">false(�W��):�X�V���t�����l�����ăf�[�^�̍X�V���s���B�@true:�X�V���t�Ȃǂ𖳎����ăf�[�^�̍X�V���s���B</param>
        /// <remarks>
        /// <br>Note       : �{�R���X�g���N�^���g�p����ۂ́ACompulsoryDataOverride�̎戵���ɏ\�����ӂ��鎖</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        /// </remarks>
        public AcceptOdrCarDB(bool compulsoryDataOverride)
            : base("PMJUT01813D", "Broadleaf.Application.Remoting.ParamData.AcceptOdrCarWork", "ACCEPTODRCARRF")
        {
            this._CompulsoryDataOverride = true;
        }

        # region [Read]
        /// <summary>
        /// �P��̎󒍃}�X�^(�ԗ�)�����擾���܂��B
        /// </summary>
        /// <param name="acceptOdrCarObj">AcceptOdrCarWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        public int Read(ref object acceptOdrCarObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                AcceptOdrCarWork acceptOdrCarWork = acceptOdrCarObj as AcceptOdrCarWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref acceptOdrCarWork, readMode, sqlConnection, sqlTransaction);
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
        /// <param name="acceptOdrCarWork">AcceptOdrCarWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        public int Read(ref AcceptOdrCarWork acceptOdrCarWork, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref acceptOdrCarWork, readMode, sqlConnection, sqlTransaction);
        }

        // 2009/05/28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �󒍃}�X�^(�ԗ�)��񃊃X�g���擾���܂��B
        /// </summary>
        /// <param name="acceptOdrCarObj">���o�������X�g(AcceptOdrCarWork)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : 22008�@����</br>
        /// <br>Date       : 2009.05.28</br>
        public int ReadAll(ref object acceptOdrCarObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList paraList = acceptOdrCarObj as ArrayList;
                ArrayList acceptOdrCarList = new ArrayList();

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.ReadAll(ref acceptOdrCarList, paraList ,sqlConnection, sqlTransaction);

                acceptOdrCarObj = acceptOdrCarList;

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
        /// <param name="acceptOdrCarList">���o���ʃ��X�g(AcceptOdrCarWork)</param>
        /// <param name="paraList">���o�������X�g(AcceptOdrCarWork)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : 22008�@����</br>
        /// <br>Date       : 2009.05.28</br>
        public int ReadAll(ref ArrayList acceptOdrCarList, ArrayList paraList ,SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            foreach (AcceptOdrCarWork acceptOdrCarWork in paraList)
            {
                AcceptOdrCarWork pararetWork = acceptOdrCarWork;

                status = this.ReadProc(ref pararetWork, 0, sqlConnection, sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    acceptOdrCarList.Add(pararetWork);
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
        /// <param name="acceptOdrCarWork">AcceptOdrCarWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        /// <br>Update Note: SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        /// <br>Programmer : FSI���� �G</br>
        /// <br>Date       : 2013/03/21</br>
        private int ReadProc(ref AcceptOdrCarWork acceptOdrCarWork, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
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
                sqlText += "  ACAR.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ACAR.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ACAR.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,ACAR.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,ACAR.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,ACAR.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,ACAR.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,ACAR.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,ACAR.ACCEPTANORDERNORF" + Environment.NewLine;
                sqlText += " ,ACAR.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += " ,ACAR.DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlText += " ,ACAR.CARMNGNORF" + Environment.NewLine;
                sqlText += " ,ACAR.CARMNGCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE1CODERF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE1NAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE2RF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE3RF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE4RF" + Environment.NewLine;
                sqlText += " ,ACAR.FIRSTENTRYDATERF" + Environment.NewLine;
                sqlText += " ,ACAR.MAKERCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.MAKERFULLNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.MAKERHALFNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELSUBCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELFULLNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELHALFNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.EXHAUSTGASSIGNRF" + Environment.NewLine;
                sqlText += " ,ACAR.SERIESMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.CATEGORYSIGNMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.FULLMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELDESIGNATIONNORF" + Environment.NewLine;
                sqlText += " ,ACAR.CATEGORYNORF" + Environment.NewLine;
                sqlText += " ,ACAR.FRAMEMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.FRAMENORF" + Environment.NewLine;
                sqlText += " ,ACAR.SEARCHFRAMENORF" + Environment.NewLine;
                sqlText += " ,ACAR.ENGINEMODELNMRF" + Environment.NewLine;
                sqlText += " ,ACAR.RELEVANCEMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.SUBCARNMCDRF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELGRADESNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.COLORCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.COLORNAME1RF" + Environment.NewLine;
                sqlText += " ,ACAR.TRIMCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.TRIMNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.MILEAGERF" + Environment.NewLine;
                sqlText += " ,ACAR.FULLMODELFIXEDNOARYRF" + Environment.NewLine;
                sqlText += " ,ACAR.CATEGORYOBJARYRF" + Environment.NewLine;

                sqlText += " ,ACAR.CARNOTERF " + Environment.NewLine;  // ADD 2009/09/07

                sqlText += " ,ACAR.FREESRCHMDLFXDNOARYRF " + Environment.NewLine;  // ADD 2010/04/27
                sqlText += " ,ACAR.DOMESTICFOREIGNCODERF " + Environment.NewLine;  // ADD 2013/03/21

                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  ACCEPTODRCARRF AS ACAR" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ACAR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND ACAR.ACCEPTANORDERNORF = @FINDACCEPTANORDERNO" + Environment.NewLine;
                sqlText += "  AND ACAR.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                sqlText += "  AND ACAR.DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);
                findAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);
                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);
                findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToAcceptOdrCarWorkFromReader(ref myReader, ref acceptOdrCarWork);
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
        /// <param name="acceptOdrCarList">�����폜����󒍃}�X�^(�ԗ�)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)���𕨗��폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        public int Delete(object acceptOdrCarList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = acceptOdrCarList as ArrayList;

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
        /// <param name="acceptOdrCarList">�󒍃}�X�^(�ԗ�)�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarList �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)���𕨗��폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        public int Delete(ArrayList acceptOdrCarList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(acceptOdrCarList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���𕨗��폜���܂�
        /// </summary>
        /// <param name="acceptOdrCarList">�󒍃}�X�^(�ԗ�)�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarList �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)���𕨗��폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        private int DeleteProc(ArrayList acceptOdrCarList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (acceptOdrCarList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < acceptOdrCarList.Count; i++)
                    {
                        AcceptOdrCarWork acceptOdrCarWork = acceptOdrCarList[i] as AcceptOdrCarWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  ACCEPTODRCARRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ACCEPTANORDERNORF = @FINDACCEPTANORDERNO" + Environment.NewLine;
                        sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += "  AND DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                        SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                        SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);                        

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);
                        findAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);
                        findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != acceptOdrCarWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  ACCEPTODRCARRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND ACCEPTANORDERNORF = @FINDACCEPTANORDERNO" + Environment.NewLine;
                            sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);
                            findAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);
                            findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);
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
        /// <param name="acceptOdrCarList">��������</param>
        /// <param name="acceptOdrCarObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����A�S�Ă̎󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        public int Search(ref object acceptOdrCarList, object acceptOdrCarObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList acceptOdrCarArray = acceptOdrCarList as ArrayList;
                AcceptOdrCarWork acceptOdrCarWork = acceptOdrCarObj as AcceptOdrCarWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref acceptOdrCarArray, acceptOdrCarWork, readMode, logicalMode, sqlConnection, sqlTransaction);
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
        /// <param name="acceptOdrCarList">�󒍃}�X�^(�ԗ�)�����i�[���� ArrayList</param>
        /// <param name="acceptOdrCarWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����A�S�Ă̎󒍃}�X�^(�ԗ�)��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        public int Search(ref ArrayList acceptOdrCarList, AcceptOdrCarWork acceptOdrCarWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref acceptOdrCarList, acceptOdrCarWork, readMode, logicalMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="acceptOdrCarList">�󒍃}�X�^(�ԗ�)�����i�[���� ArrayList</param>
        /// <param name="acceptOdrCarWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����A�S�Ă̎󒍃}�X�^(�ԗ�)��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        /// <br>Update Note: SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        /// <br>Programmer : FSI���� �G</br>
        /// <br>Date       : 2013/03/21</br>
        private int SearchProc(ref ArrayList acceptOdrCarList, AcceptOdrCarWork acceptOdrCarWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
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
                sqlText += "  ACAR.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ACAR.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ACAR.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,ACAR.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,ACAR.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,ACAR.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,ACAR.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,ACAR.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,ACAR.ACCEPTANORDERNORF" + Environment.NewLine;
                sqlText += " ,ACAR.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += " ,ACAR.DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlText += " ,ACAR.CARMNGNORF" + Environment.NewLine;
                sqlText += " ,ACAR.CARMNGCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE1CODERF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE1NAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE2RF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE3RF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE4RF" + Environment.NewLine;
                sqlText += " ,ACAR.FIRSTENTRYDATERF" + Environment.NewLine;
                sqlText += " ,ACAR.MAKERCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.MAKERFULLNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELSUBCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELFULLNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.EXHAUSTGASSIGNRF" + Environment.NewLine;
                sqlText += " ,ACAR.SERIESMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.CATEGORYSIGNMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.FULLMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELDESIGNATIONNORF" + Environment.NewLine;
                sqlText += " ,ACAR.CATEGORYNORF" + Environment.NewLine;
                sqlText += " ,ACAR.FRAMEMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.FRAMENORF" + Environment.NewLine;
                sqlText += " ,ACAR.SEARCHFRAMENORF" + Environment.NewLine;
                sqlText += " ,ACAR.ENGINEMODELNMRF" + Environment.NewLine;
                sqlText += " ,ACAR.RELEVANCEMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.SUBCARNMCDRF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELGRADESNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.COLORCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.COLORNAME1RF" + Environment.NewLine;
                sqlText += " ,ACAR.TRIMCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.TRIMNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.MILEAGERF" + Environment.NewLine;
                sqlText += " ,ACAR.FULLMODELFIXEDNOARYRF" + Environment.NewLine;
                sqlText += " ,ACAR.CARNOTERF " + Environment.NewLine;  // ADD 2009/09/07
                sqlText += " ,ACAR.FREESRCHMDLFXDNOARYRF " + Environment.NewLine;  // ADD 2010/04/27
                sqlText += " ,ACAR.DOMESTICFOREIGNCODERF " + Environment.NewLine;  // ADD 2013/03/21
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  ACCEPTODRCARRF AS ACAR" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, acceptOdrCarWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    acceptOdrCarList.Add(this.CopyToAcceptOdrCarWorkFromReader(ref myReader));
                }

                if (acceptOdrCarList.Count > 0)
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
        /// <param name="acceptOdrCarList">�ǉ��E�X�V����󒍃}�X�^(�ԗ�)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarList �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        public int Write(ref object acceptOdrCarList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = acceptOdrCarList as ArrayList;

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
        /// <param name="acceptOdrCarList">�ǉ��E�X�V����󒍃}�X�^(�ԗ�)�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarList �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        public int Write(ref ArrayList acceptOdrCarList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref acceptOdrCarList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="acceptOdrCarList">�ǉ��E�X�V����󒍃}�X�^(�ԗ�)�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarList �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        /// <br>Update Note: SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        /// <br>Programmer : FSI���� �G</br>
        /// <br>Date       : 2013/03/21</br>
        /// <br>Update Note: PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2020/08/28</br>
        private int WriteProc(ref ArrayList acceptOdrCarList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // �R�}���h�^�C���A�E�g�i�b�j
            this.GetXmlInfo(ref dbCommandTimeout);
            // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

            try
            {
                if (acceptOdrCarList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < acceptOdrCarList.Count; i++)
                    {
                        AcceptOdrCarWork acceptOdrCarWork = acceptOdrCarList[i] as AcceptOdrCarWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  ACAR.CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ACAR.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ACAR.FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  ACCEPTODRCARRF AS ACAR" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ACAR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ACAR.ACCEPTANORDERNORF = @FINDACCEPTANORDERNO" + Environment.NewLine;
                        sqlText += "  AND ACAR.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += "  AND ACAR.DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                        SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                        SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);
                        findAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);
                        findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);

                        sqlCommand.CommandTimeout = dbCommandTimeout; //ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή�
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            if (!this._CompulsoryDataOverride)
                            {
                                // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                                if (_updateDateTime != acceptOdrCarWork.UpdateDateTime)
                                {
                                    if (acceptOdrCarWork.UpdateDateTime == DateTime.MinValue)
                                    {
                                        // �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                    }
                                    else
                                    {
                                        // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    }

                                    return status;
                                }
                            }
                            else
                            {
                                // �����I�Ƀf�[�^���㏑��������ׁA�쐬������t�@�C���w�b�_�[GUID���㏑�����Ă���
                                // ��fileHeader.SetUpdateHeader �ł͂����̍��ڂ��Z�b�g����Ȃ���
                                acceptOdrCarWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
                                acceptOdrCarWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
                            }                                                                                     

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE ACCEPTODRCARRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,ACCEPTANORDERNORF = @ACCEPTANORDERNO" + Environment.NewLine;
                            sqlText += " ,ACPTANODRSTATUSRF = @ACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += " ,DATAINPUTSYSTEMRF = @DATAINPUTSYSTEM" + Environment.NewLine;
                            sqlText += " ,CARMNGNORF = @CARMNGNO" + Environment.NewLine;
                            sqlText += " ,CARMNGCODERF = @CARMNGCODE" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1CODERF = @NUMBERPLATE1CODE" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1NAMERF = @NUMBERPLATE1NAME" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE2RF = @NUMBERPLATE2" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE3RF = @NUMBERPLATE3" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE4RF = @NUMBERPLATE4" + Environment.NewLine;
                            sqlText += " ,FIRSTENTRYDATERF = @FIRSTENTRYDATE" + Environment.NewLine;
                            sqlText += " ,MAKERCODERF = @MAKERCODE" + Environment.NewLine;
                            sqlText += " ,MAKERFULLNAMERF = @MAKERFULLNAME" + Environment.NewLine;
                            sqlText += " ,MAKERHALFNAMERF = @MAKERHALFNAME" + Environment.NewLine;
                            sqlText += " ,MODELCODERF = @MODELCODE" + Environment.NewLine;
                            sqlText += " ,MODELSUBCODERF = @MODELSUBCODE" + Environment.NewLine;
                            sqlText += " ,MODELFULLNAMERF = @MODELFULLNAME" + Environment.NewLine;
                            sqlText += " ,MODELHALFNAMERF = @MODELHALFNAME" + Environment.NewLine;
                            sqlText += " ,EXHAUSTGASSIGNRF = @EXHAUSTGASSIGN" + Environment.NewLine;
                            sqlText += " ,SERIESMODELRF = @SERIESMODEL" + Environment.NewLine;
                            sqlText += " ,CATEGORYSIGNMODELRF = @CATEGORYSIGNMODEL" + Environment.NewLine;
                            sqlText += " ,FULLMODELRF = @FULLMODEL" + Environment.NewLine;
                            sqlText += " ,MODELDESIGNATIONNORF = @MODELDESIGNATIONNO" + Environment.NewLine;
                            sqlText += " ,CATEGORYNORF = @CATEGORYNO" + Environment.NewLine;
                            sqlText += " ,FRAMEMODELRF = @FRAMEMODEL" + Environment.NewLine;
                            sqlText += " ,FRAMENORF = @FRAMENO" + Environment.NewLine;
                            sqlText += " ,SEARCHFRAMENORF = @SEARCHFRAMENO" + Environment.NewLine;
                            sqlText += " ,ENGINEMODELNMRF = @ENGINEMODELNM" + Environment.NewLine;
                            sqlText += " ,RELEVANCEMODELRF = @RELEVANCEMODEL" + Environment.NewLine;
                            sqlText += " ,SUBCARNMCDRF = @SUBCARNMCD" + Environment.NewLine;
                            sqlText += " ,MODELGRADESNAMERF = @MODELGRADESNAME" + Environment.NewLine;
                            sqlText += " ,COLORCODERF = @COLORCODE" + Environment.NewLine;
                            sqlText += " ,COLORNAME1RF = @COLORNAME1" + Environment.NewLine;
                            sqlText += " ,TRIMCODERF = @TRIMCODE" + Environment.NewLine;
                            sqlText += " ,TRIMNAMERF = @TRIMNAME" + Environment.NewLine;
                            sqlText += " ,MILEAGERF = @MILEAGE" + Environment.NewLine;
                            sqlText += " ,FULLMODELFIXEDNOARYRF = @FULLMODELFIXEDNOARY" + Environment.NewLine;
                            sqlText += " ,CATEGORYOBJARYRF = @CATEGORYOBJARY" + Environment.NewLine;
                            sqlText += " ,CARNOTERF = @CARNOTE" + Environment.NewLine; // ADD 2009/09/07
                            sqlText += " ,FREESRCHMDLFXDNOARYRF = @FREESRCHMDLFXDNOARY" + Environment.NewLine; // ADD 2010/04/27
                            sqlText += " ,DOMESTICFOREIGNCODERF = @DOMESTICFOREIGNCODE" + Environment.NewLine;  // ADD 2013/03/21
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND ACCEPTANORDERNORF = @FINDACCEPTANORDERNO" + Environment.NewLine;
                            sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);
                            findAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);
                            findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)acceptOdrCarWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (acceptOdrCarWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO ACCEPTODRCARRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,ACCEPTANORDERNORF" + Environment.NewLine;
                            sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                            sqlText += " ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                            sqlText += " ,CARMNGNORF" + Environment.NewLine;
                            sqlText += " ,CARMNGCODERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1CODERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1NAMERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE2RF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE3RF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE4RF" + Environment.NewLine;
                            sqlText += " ,FIRSTENTRYDATERF" + Environment.NewLine;
                            sqlText += " ,MAKERCODERF" + Environment.NewLine;
                            sqlText += " ,MAKERFULLNAMERF" + Environment.NewLine;
                            sqlText += " ,MAKERHALFNAMERF" + Environment.NewLine;
                            sqlText += " ,MODELCODERF" + Environment.NewLine;
                            sqlText += " ,MODELSUBCODERF" + Environment.NewLine;
                            sqlText += " ,MODELFULLNAMERF" + Environment.NewLine;
                            sqlText += " ,MODELHALFNAMERF" + Environment.NewLine;
                            sqlText += " ,EXHAUSTGASSIGNRF" + Environment.NewLine;
                            sqlText += " ,SERIESMODELRF" + Environment.NewLine;
                            sqlText += " ,CATEGORYSIGNMODELRF" + Environment.NewLine;
                            sqlText += " ,FULLMODELRF" + Environment.NewLine;
                            sqlText += " ,MODELDESIGNATIONNORF" + Environment.NewLine;
                            sqlText += " ,CATEGORYNORF" + Environment.NewLine;
                            sqlText += " ,FRAMEMODELRF" + Environment.NewLine;
                            sqlText += " ,FRAMENORF" + Environment.NewLine;
                            sqlText += " ,SEARCHFRAMENORF" + Environment.NewLine;
                            sqlText += " ,ENGINEMODELNMRF" + Environment.NewLine;
                            sqlText += " ,RELEVANCEMODELRF" + Environment.NewLine;
                            sqlText += " ,SUBCARNMCDRF" + Environment.NewLine;
                            sqlText += " ,MODELGRADESNAMERF" + Environment.NewLine;
                            sqlText += " ,COLORCODERF" + Environment.NewLine;
                            sqlText += " ,COLORNAME1RF" + Environment.NewLine;
                            sqlText += " ,TRIMCODERF" + Environment.NewLine;
                            sqlText += " ,TRIMNAMERF" + Environment.NewLine;
                            sqlText += " ,MILEAGERF" + Environment.NewLine;
                            sqlText += " ,FULLMODELFIXEDNOARYRF" + Environment.NewLine;
                            sqlText += " ,CATEGORYOBJARYRF" + Environment.NewLine;
                            sqlText += " ,CARNOTERF " + Environment.NewLine;  // ADD 2009/09/07
                            sqlText += " ,DOMESTICFOREIGNCODERF " + Environment.NewLine;  // ADD 2013/03/21
                            sqlText += " ,FREESRCHMDLFXDNOARYRF) " + Environment.NewLine;  // ADD 2010/04/27
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "  (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@ACCEPTANORDERNO" + Environment.NewLine;
                            sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += " ,@DATAINPUTSYSTEM" + Environment.NewLine;
                            sqlText += " ,@CARMNGNO" + Environment.NewLine;
                            sqlText += " ,@CARMNGCODE" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE1CODE" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE1NAME" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE2" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE3" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE4" + Environment.NewLine;
                            sqlText += " ,@FIRSTENTRYDATE" + Environment.NewLine;
                            sqlText += " ,@MAKERCODE" + Environment.NewLine;
                            sqlText += " ,@MAKERFULLNAME" + Environment.NewLine;
                            sqlText += " ,@MAKERHALFNAME" + Environment.NewLine;
                            sqlText += " ,@MODELCODE" + Environment.NewLine;
                            sqlText += " ,@MODELSUBCODE" + Environment.NewLine;
                            sqlText += " ,@MODELFULLNAME" + Environment.NewLine;
                            sqlText += " ,@MODELHALFNAME" + Environment.NewLine;
                            sqlText += " ,@EXHAUSTGASSIGN" + Environment.NewLine;
                            sqlText += " ,@SERIESMODEL" + Environment.NewLine;
                            sqlText += " ,@CATEGORYSIGNMODEL" + Environment.NewLine;
                            sqlText += " ,@FULLMODEL" + Environment.NewLine;
                            sqlText += " ,@MODELDESIGNATIONNO" + Environment.NewLine;
                            sqlText += " ,@CATEGORYNO" + Environment.NewLine;
                            sqlText += " ,@FRAMEMODEL" + Environment.NewLine;
                            sqlText += " ,@FRAMENO" + Environment.NewLine;
                            sqlText += " ,@SEARCHFRAMENO" + Environment.NewLine;
                            sqlText += " ,@ENGINEMODELNM" + Environment.NewLine;
                            sqlText += " ,@RELEVANCEMODEL" + Environment.NewLine;
                            sqlText += " ,@SUBCARNMCD" + Environment.NewLine;
                            sqlText += " ,@MODELGRADESNAME" + Environment.NewLine;
                            sqlText += " ,@COLORCODE" + Environment.NewLine;
                            sqlText += " ,@COLORNAME1" + Environment.NewLine;
                            sqlText += " ,@TRIMCODE" + Environment.NewLine;
                            sqlText += " ,@TRIMNAME" + Environment.NewLine;
                            sqlText += " ,@MILEAGE" + Environment.NewLine;
                            sqlText += " ,@FULLMODELFIXEDNOARY" + Environment.NewLine;
                            sqlText += " ,@CATEGORYOBJARY" + Environment.NewLine;
                            sqlText += " ,@CARNOTE" + Environment.NewLine;  // ADD 2009/09/07
                            sqlText += " ,@DOMESTICFOREIGNCODE" + Environment.NewLine;  // ADD 2013/03/21
                            sqlText += " ,@FREESRCHMDLFXDNOARY" + Environment.NewLine;  // ADD 2010/04/27
                            sqlText += ")" + Environment.NewLine;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)acceptOdrCarWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }
                        
                        sqlCommand.CommandText = sqlText;

                        # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);               // �쐬����
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);               // �X�V����
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);                // ��ƃR�[�h
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);     // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);              // �X�V�]�ƈ��R�[�h
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);             // �X�V�A�Z���u��ID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);             // �X�V�A�Z���u��ID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);            // �_���폜�敪
                        SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);                // �󒍔ԍ�
                        SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);                // �󒍃X�e�[�^�X
                        SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);                // �f�[�^���̓V�X�e��
                        SqlParameter paraCarMngNo = sqlCommand.Parameters.Add("@CARMNGNO", SqlDbType.Int);                              // �ԗ��Ǘ��ԍ�
                        SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@CARMNGCODE", SqlDbType.NVarChar);                     // ���q�Ǘ��R�[�h
                        SqlParameter paraNumberPlate1Code = sqlCommand.Parameters.Add("@NUMBERPLATE1CODE", SqlDbType.Int);              // ���^�������ԍ�
                        SqlParameter paraNumberPlate1Name = sqlCommand.Parameters.Add("@NUMBERPLATE1NAME", SqlDbType.NVarChar);         // ���^�����ǖ���
                        SqlParameter paraNumberPlate2 = sqlCommand.Parameters.Add("@NUMBERPLATE2", SqlDbType.NVarChar);                 // �ԗ��o�^�ԍ��i��ʁj
                        SqlParameter paraNumberPlate3 = sqlCommand.Parameters.Add("@NUMBERPLATE3", SqlDbType.NVarChar);                 // �ԗ��o�^�ԍ��i�J�i�j
                        SqlParameter paraNumberPlate4 = sqlCommand.Parameters.Add("@NUMBERPLATE4", SqlDbType.Int);                      // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                        SqlParameter paraFirstEntryDate = sqlCommand.Parameters.Add("@FIRSTENTRYDATE", SqlDbType.Int);                  // ���N�x
                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);                            // ���[�J�[�R�[�h
                        SqlParameter paraMakerFullName = sqlCommand.Parameters.Add("@MAKERFULLNAME", SqlDbType.NVarChar);               // ���[�J�[�S�p����
                        SqlParameter paraMakerHalfName = sqlCommand.Parameters.Add("@MAKERHALFNAME", SqlDbType.NVarChar);               // ���[�J�[���p����
                        SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);                            // �Ԏ�R�[�h
                        SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);                      // �Ԏ�T�u�R�[�h
                        SqlParameter paraModelFullName = sqlCommand.Parameters.Add("@MODELFULLNAME", SqlDbType.NVarChar);               // �Ԏ�S�p����
                        SqlParameter paraModelHalfName = sqlCommand.Parameters.Add("@MODELHALFNAME", SqlDbType.NVarChar);               // �Ԏ피�p����
                        SqlParameter paraExhaustGasSign = sqlCommand.Parameters.Add("@EXHAUSTGASSIGN", SqlDbType.NVarChar);             // �r�K�X�L��
                        SqlParameter paraSeriesModel = sqlCommand.Parameters.Add("@SERIESMODEL", SqlDbType.NVarChar);                   // �V���[�Y�^��
                        SqlParameter paraCategorySignModel = sqlCommand.Parameters.Add("@CATEGORYSIGNMODEL", SqlDbType.NVarChar);       // �^���i�ޕʋL���j
                        SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FULLMODEL", SqlDbType.NVarChar);                       // �^���i�t���^�j
                        SqlParameter paraModelDesignationNo = sqlCommand.Parameters.Add("@MODELDESIGNATIONNO", SqlDbType.Int);          // �^���w��ԍ�
                        SqlParameter paraCategoryNo = sqlCommand.Parameters.Add("@CATEGORYNO", SqlDbType.Int);                          // �ޕʔԍ�
                        SqlParameter paraFrameModel = sqlCommand.Parameters.Add("@FRAMEMODEL", SqlDbType.NVarChar);                     // �ԑ�^��
                        SqlParameter paraFrameNo = sqlCommand.Parameters.Add("@FRAMENO", SqlDbType.NVarChar);                           // �ԑ�ԍ�
                        SqlParameter paraSearchFrameNo = sqlCommand.Parameters.Add("@SEARCHFRAMENO", SqlDbType.Int);                    // �ԑ�ԍ��i�����p�j
                        SqlParameter paraEngineModelNm = sqlCommand.Parameters.Add("@ENGINEMODELNM", SqlDbType.NVarChar);               // �G���W���^������
                        SqlParameter paraRelevanceModel = sqlCommand.Parameters.Add("@RELEVANCEMODEL", SqlDbType.NVarChar);             // �֘A�^��
                        SqlParameter paraSubCarNmCd = sqlCommand.Parameters.Add("@SUBCARNMCD", SqlDbType.Int);                          // �T�u�Ԗ��R�[�h
                        SqlParameter paraModelGradeSname = sqlCommand.Parameters.Add("@MODELGRADESNAME", SqlDbType.NVarChar);           // �^���O���[�h����
                        SqlParameter paraColorCode = sqlCommand.Parameters.Add("@COLORCODE", SqlDbType.NVarChar);                       // �J���[�R�[�h
                        SqlParameter paraColorName1 = sqlCommand.Parameters.Add("@COLORNAME1", SqlDbType.NVarChar);                     // �J���[����1
                        SqlParameter paraTrimCode = sqlCommand.Parameters.Add("@TRIMCODE", SqlDbType.NVarChar);                         // �g�����R�[�h
                        SqlParameter paraTrimName = sqlCommand.Parameters.Add("@TRIMNAME", SqlDbType.NVarChar);                         // �g��������
                        SqlParameter paraMileage = sqlCommand.Parameters.Add("@MILEAGE", SqlDbType.Int);                                // �ԗ����s����
                        SqlParameter paraFullModelFixedNoAry = sqlCommand.Parameters.Add("@FULLMODELFIXEDNOARY", SqlDbType.VarBinary);  // �t���^���Œ�ԍ��z��
                        SqlParameter paraCategoryObjAry = sqlCommand.Parameters.Add("@CATEGORYOBJARY", SqlDbType.VarBinary);            // �����I�u�W�F�N�g�z��
                        SqlParameter paraCarNote = sqlCommand.Parameters.Add("@CARNOTE", SqlDbType.NVarChar);            // ���q���l    // ADD 2009/09/07
                        SqlParameter paraFreeSrchMdlFxdNoAry = sqlCommand.Parameters.Add("@FREESRCHMDLFXDNOARY", SqlDbType.VarBinary);  // ���R�����^���Œ�ԍ��z�� // ADD 2010/04/27
                        SqlParameter paraDomesticForeignCode = sqlCommand.Parameters.Add("@DOMESTICFOREIGNCODE", SqlDbType.Int);        //���Y/�O�ԋ敪 // ADD 2013/03/21
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acceptOdrCarWork.CreateDateTime);   // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acceptOdrCarWork.UpdateDateTime);   // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);              // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(acceptOdrCarWork.FileHeaderGuid);                // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.UpdEmployeeCode);            // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.UpdAssemblyId1);              // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.UpdAssemblyId2);              // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.LogicalDeleteCode);         // �_���폜�敪
                        paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);             // �󒍔ԍ�
                        paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);             // �󒍃X�e�[�^�X
                        paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);             // �f�[�^���̓V�X�e��
                        paraCarMngNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.CarMngNo);                           // �ԗ��Ǘ��ԍ�
                        paraCarMngCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.CarMngCode);                      // ���q�Ǘ��R�[�h
                        paraNumberPlate1Code.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.NumberPlate1Code);           // ���^�������ԍ�
                        paraNumberPlate1Name.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.NumberPlate1Name);          // ���^�����ǖ���
                        paraNumberPlate2.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.NumberPlate2);                  // �ԗ��o�^�ԍ��i��ʁj
                        paraNumberPlate3.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.NumberPlate3);                  // �ԗ��o�^�ԍ��i�J�i�j
                        paraNumberPlate4.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.NumberPlate4);                   // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                       // paraFirstEntryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(acceptOdrCarWork.FirstEntryDate);  // ���N�x
                        paraFirstEntryDate.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.FirstEntryDate);               // ���N�x
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.MakerCode);                         // ���[�J�[�R�[�h
                        paraMakerFullName.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.MakerFullName);                // ���[�J�[�S�p����
                        paraMakerHalfName.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.MakerHalfName);                // ���[�J�[���p����
                        paraModelCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.ModelCode);                         // �Ԏ�R�[�h
                        paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.ModelSubCode);                   // �Ԏ�T�u�R�[�h
                        paraModelFullName.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.ModelFullName);                // �Ԏ�S�p����
                        paraModelHalfName.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.ModelHalfName);                // �Ԏ피�p����
                        paraExhaustGasSign.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.ExhaustGasSign);              // �r�K�X�L��
                        paraSeriesModel.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.SeriesModel);                    // �V���[�Y�^��
                        paraCategorySignModel.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.CategorySignModel);        // �^���i�ޕʋL���j
                        paraFullModel.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.FullModel);                        // �^���i�t���^�j
                        paraModelDesignationNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.ModelDesignationNo);       // �^���w��ԍ�
                        paraCategoryNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.CategoryNo);                       // �ޕʔԍ�
                        paraFrameModel.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.FrameModel);                      // �ԑ�^��
                        paraFrameNo.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.FrameNo);                            // �ԑ�ԍ�
                        paraSearchFrameNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.SearchFrameNo);                 // �ԑ�ԍ��i�����p�j
                        paraEngineModelNm.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EngineModelNm);                // �G���W���^������
                        paraRelevanceModel.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.RelevanceModel);              // �֘A�^��
                        paraSubCarNmCd.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.SubCarNmCd);                       // �T�u�Ԗ��R�[�h
                        paraModelGradeSname.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.ModelGradeSname);            // �^���O���[�h����
                        paraColorCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.ColorCode);                        // �J���[�R�[�h
                        paraColorName1.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.ColorName1);                      // �J���[����1
                        paraTrimCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.TrimCode);                          // �g�����R�[�h
                        paraTrimName.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.TrimName);                          // �g��������
                        paraMileage.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.Mileage);                             // �ԗ����s����

                        paraCarNote.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.CarNote);      // ADD 2009/09/07                        // ���q���l
                        // int[] �� byte[] �ɕϊ�
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        foreach (int item in acceptOdrCarWork.FullModelFixedNoAry)
                            ms.Write(BitConverter.GetBytes(item), 0, sizeof(int));
                        byte[] verbinary = ms.ToArray();
                        ms.Close();

                        paraFullModelFixedNoAry.Value = SqlDataMediator.SqlSetBinary(verbinary);                               // �t���^���Œ�ԍ��z��

                        paraCategoryObjAry.Value = SqlDataMediator.SqlSetBinary(acceptOdrCarWork.CategoryObjAry);              // �����I�u�W�F�N�g�z��

                        // --- ADD 2010/04/27 ---------->>>>>
                        // ���R�����^���Œ�ԍ��z��
                        paraFreeSrchMdlFxdNoAry.Value = SqlDataMediator.SqlSetBinary(acceptOdrCarWork.FreeSrchMdlFxdNoAry);
                        // --- ADD 2010/04/27 ----------<<<<<
                        paraDomesticForeignCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DomesticForeignCode);    // ���Y/�O�ԋ敪 // ADD 2013/03/21
                        # endregion

                        int cnt = sqlCommand.ExecuteNonQuery();
                        al.Add(acceptOdrCarWork);
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

            acceptOdrCarList = al;

            return status;
        }

        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
        #region �ݒ�t�@�C���擾
        /// <summary>
        /// �ݒ�t�@�C���擾
        /// </summary>
        /// <param name="dbCommandTimeout">�^�C���A�E�g����</param>
        /// <remarks>
        /// <br>Note         : �ݒ�t�@�C���擾�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // �����l�ݒ�
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //�^�C���A�E�g���Ԃ��擾
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "�ݒ�t�@�C���擾�G���[");
                }
            }

        }
        #endregion // �ݒ�t�@�C���擾

        #region XML�t�@�C������
        /// <summary>
        /// XML�t�@�C�����擾
        /// </summary>
        /// <returns>XML�t�@�C����</returns>
        /// <remarks>
        /// <br>Note         : XML���擾�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // �J�����g�f�B���N�g���擾
                homeDir = this.GetCurrentDirectory();

                // �f�B���N�g������XML�t�@�C������A��
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // �t�@�C�������݂��Ȃ��ꍇ�͋󔒂ɂ���
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XML�t�@�C������

        #region �J�����g�t�H���_
        /// <summary>
        /// �J�����g�t�H���_�擾
        /// </summary>
        /// <returns>XML�t�@�C����</returns>
        /// <remarks>
        /// <br>Note         : �J�����g�t�H���_�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML�i�[�f�B���N�g���擾
            try
            {
                // dll�i�[�p�X�������f�B���N�g���Ƃ���
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // �����́u\�v�͏�ɂȂ�

                // ���W�X�g�������USER_AP�̃L�[�����擾
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // ���W�X�g�������擾�ł��Ȃ��ꍇ�͏����f�B���N�g�� // �^�p�゠�肦�Ȃ��P�[�X
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // �擾�f�B���N�g�������݂��Ȃ��ꍇ�͏����f�B���N�g����ݒ�
                // �^�p�゠�肦�Ȃ��P�[�X
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_AP��LOG�t�H���_�Ƀ��O�o��
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // �J�����g�t�H���_
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// �󒍃}�X�^(�ԗ�)����_���폜���܂��B
        /// </summary>
        /// <param name="acceptOdrCarList">�_���폜����󒍃}�X�^(�ԗ�)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarWork �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)����_���폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        public int LogicalDelete(ref object acceptOdrCarList)
        {
            return this.LogicalDelete(ref acceptOdrCarList, 0);
        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���̘_���폜���������܂��B
        /// </summary>
        /// <param name="acceptOdrCarList">�_���폜����������󒍃}�X�^(�ԗ�)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarWork �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)���̘_���폜���������܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        public int RevivalLogicalDelete(ref object acceptOdrCarList)
        {
            return this.LogicalDelete(ref acceptOdrCarList, 1);
        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="acceptOdrCarList">�_���폜�𑀍삷��󒍃}�X�^(�ԗ�)���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarWork �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        private int LogicalDelete(ref object acceptOdrCarList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = acceptOdrCarList as ArrayList;

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
        /// <param name="acceptOdrCarList">�_���폜�𑀍삷��󒍃}�X�^(�ԗ�)�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarWork �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        public int LogicalDelete(ref ArrayList acceptOdrCarList, int procMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref acceptOdrCarList, procMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="acceptOdrCarList">�_���폜�𑀍삷��󒍃}�X�^(�ԗ�)�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarWork �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        private int LogicalDeleteProc(ref ArrayList acceptOdrCarList, int procMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (acceptOdrCarList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < acceptOdrCarList.Count; i++)
                    {
                        AcceptOdrCarWork acceptOdrCarWork = acceptOdrCarList[i] as AcceptOdrCarWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  ACAR.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ACAR.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  ACCEPTODRCARRF AS ACAR" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ACAR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ACAR.ACCEPTANORDERNORF = @FINDACCEPTANORDERNO" + Environment.NewLine;
                        sqlText += "  AND ACAR.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += "  AND ACAR.DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                        SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                        SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);
                        findAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);
                        findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != acceptOdrCarWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  ACCEPTODRCARRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND ACCEPTANORDERNORF = @FINDACCEPTANORDERNO" + Environment.NewLine;
                            sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);
                            findAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);
                            findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)acceptOdrCarWork;
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
                            else if (logicalDelCd == 0) acceptOdrCarWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else acceptOdrCarWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                acceptOdrCarWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acceptOdrCarWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(acceptOdrCarWork);
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

            acceptOdrCarList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="acceptOdrCarWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, AcceptOdrCarWork acceptOdrCarWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // ��ƃR�[�h
            retstring += "  ACAR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // �󒍔ԍ�
            if (acceptOdrCarWork.AcceptAnOrderNo > 0)
            {
                retstring += "  AND ACAR.ACCEPTANORDERNORF = @FINDACCEPTANORDERNO" + Environment.NewLine;
                SqlParameter findAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                findAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);
            }

            // �󒍃X�e�[�^�X
            if (acceptOdrCarWork.AcptAnOdrStatus > 0)
            {
                retstring += "  AND ACAR.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);
            }

            // �f�[�^���̓V�X�e��
            if (acceptOdrCarWork.DataInputSystem > -1)
            {
                retstring += "  AND ACAR.DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);
            }

            return retstring;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� AcceptOdrCarWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AcceptOdrCarWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        /// </remarks>
        private AcceptOdrCarWork CopyToAcceptOdrCarWorkFromReader(ref SqlDataReader myReader)
        {
            AcceptOdrCarWork acceptOdrCarWork = new AcceptOdrCarWork();

            this.CopyToAcceptOdrCarWorkFromReader(ref myReader, ref acceptOdrCarWork);

            return acceptOdrCarWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� AcceptOdrCarWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="acceptOdrCarWork">AcceptOdrCarWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        /// <br>Update Note: SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        /// <br>Programmer : FSI���� �G</br>
        /// <br>Date       : 2013/03/21</br>
        /// </remarks>
        private void CopyToAcceptOdrCarWorkFromReader(ref SqlDataReader myReader, ref AcceptOdrCarWork acceptOdrCarWork)
        {
            if (myReader != null && acceptOdrCarWork != null)
            {
                # region �N���X�֊i�[
                acceptOdrCarWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
                acceptOdrCarWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
                acceptOdrCarWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));             // ��ƃR�[�h
                acceptOdrCarWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
                acceptOdrCarWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));           // �X�V�]�ƈ��R�[�h
                acceptOdrCarWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));             // �X�V�A�Z���u��ID1
                acceptOdrCarWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));             // �X�V�A�Z���u��ID2
                acceptOdrCarWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));        // �_���폜�敪
                acceptOdrCarWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));            // �󒍔ԍ�
                acceptOdrCarWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));            // �󒍃X�e�[�^�X
                acceptOdrCarWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));            // �f�[�^���̓V�X�e��
                acceptOdrCarWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));                          // �ԗ��Ǘ��ԍ�
                acceptOdrCarWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));                     // ���q�Ǘ��R�[�h
                acceptOdrCarWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));          // ���^�������ԍ�
                acceptOdrCarWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));         // ���^�����ǖ���
                acceptOdrCarWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));                 // �ԗ��o�^�ԍ��i��ʁj
                acceptOdrCarWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));                 // �ԗ��o�^�ԍ��i�J�i�j
                acceptOdrCarWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));                  // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                //acceptOdrCarWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF")); // ���N�x
                acceptOdrCarWork.FirstEntryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));              // ���N�x
                acceptOdrCarWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));                        // ���[�J�[�R�[�h
                acceptOdrCarWork.MakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERFULLNAMERF"));               // ���[�J�[�S�p����
                acceptOdrCarWork.MakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERHALFNAMERF"));               // ���[�J�[���p����
                acceptOdrCarWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));                        // �Ԏ�R�[�h
                acceptOdrCarWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));                  // �Ԏ�T�u�R�[�h
                acceptOdrCarWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));               // �Ԏ�S�p����
                acceptOdrCarWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));               // �Ԏ피�p����
                acceptOdrCarWork.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));             // �r�K�X�L��
                acceptOdrCarWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));                   // �V���[�Y�^��
                acceptOdrCarWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));       // �^���i�ޕʋL���j
                acceptOdrCarWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));                       // �^���i�t���^�j
                acceptOdrCarWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));      // �^���w��ԍ�
                acceptOdrCarWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));                      // �ޕʔԍ�
                acceptOdrCarWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));                     // �ԑ�^��
                acceptOdrCarWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));                           // �ԑ�ԍ�
                acceptOdrCarWork.SearchFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHFRAMENORF"));                // �ԑ�ԍ��i�����p�j
                acceptOdrCarWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));               // �G���W���^������
                acceptOdrCarWork.RelevanceModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RELEVANCEMODELRF"));             // �֘A�^��
                acceptOdrCarWork.SubCarNmCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBCARNMCDRF"));                      // �T�u�Ԗ��R�[�h
                acceptOdrCarWork.ModelGradeSname = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADESNAMERF"));           // �^���O���[�h����
                acceptOdrCarWork.ColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORCODERF"));                       // �J���[�R�[�h
                acceptOdrCarWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));                     // �J���[����1
                acceptOdrCarWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));                         // �g�����R�[�h
                acceptOdrCarWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));                         // �g��������
                acceptOdrCarWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));                            // �ԗ����s����
                acceptOdrCarWork.CarNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARNOTERF"));                         // ���q���l   // ADD 2009/09/07
                byte[] varbinary = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FULLMODELFIXEDNOARYRF"));                       // �t���^���Œ�ԍ��z��

                acceptOdrCarWork.FullModelFixedNoAry = new int[(int)varbinary.Length / sizeof(int)];

                for (int idx = 0; idx < acceptOdrCarWork.FullModelFixedNoAry.Length; idx++)
                {
                    acceptOdrCarWork.FullModelFixedNoAry[idx] = BitConverter.ToInt32(varbinary, idx * sizeof(int));
                }

                acceptOdrCarWork.CategoryObjAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("CATEGORYOBJARYRF"));             // �����I�u�W�F�N�g�z��
                // --- ADD 2010/04/27 ---------->>>>>
                // ���R�����^���Œ�ԍ��z��
                acceptOdrCarWork.FreeSrchMdlFxdNoAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FREESRCHMDLFXDNOARYRF"));
                // --- ADD 2010/04/27 ----------<<<<<
                acceptOdrCarWork.DomesticForeignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOMESTICFOREIGNCODERF"));    // ���Y/�O�ԋ敪 // ADD 2013/03/21
                # endregion
            }
        }
        # endregion
    }
}
