//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_�Ǘ��ڑ���ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���_�Ǘ��ڑ���ݒ�}�X�^�̓o�^�E�ύX���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data;
using Microsoft.Win32;
using System.IO;
using System.Security;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ڑ���ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ڑ���ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.04.23</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SecMngConnectStDB : RemoteDB, ISecMngConnectStDB
    {
        /// <summary>
        /// �ڑ���ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public SecMngConnectStDB()
            : base("PMKYO09256D", "Broadleaf.Application.Remoting.ParamData.SecMngConnectStWork", "SecMngConnectStRF")
        {

        }

        # region [Search]
        /// <summary>
        /// �ڑ���ݒ�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outSecMngConnectStWorkList">��������</param>
        /// <param name="paraObjSecMngConnectStWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ڑ���ݒ�}�X�^�̃L�[�l����v����A�S�Ă̐ڑ���ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public int Search(out object outSecMngConnectStWorkList, object paraObjSecMngConnectStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _secMngConnectStWorkList = null;
            SecMngConnectStWork secMngConnectStWork = null;

            outSecMngConnectStWorkList = new CustomSerializeArrayList();

            try
            {
                secMngConnectStWork = paraObjSecMngConnectStWork as SecMngConnectStWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // ����
                status = SearchProc(out _secMngConnectStWorkList, secMngConnectStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SecMngConnectStDB.Search", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SecMngConnectStDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            outSecMngConnectStWorkList = _secMngConnectStWorkList;

            return status;
        }

        /// <summary>
        /// �ڑ���ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="secMngConnectStWorkList">��������</param>
        /// <param name="secMngConnectStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ڑ���ݒ�}�X�^�̃L�[�l����v����A�S�Ă̐ڑ���ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        private int SearchProc(out ArrayList secMngConnectStWorkList, SecMngConnectStWork secMngConnectStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                # region [SELECT��]
                sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CONNECTPOINTDIVRF, APSERVERIPADDRESSRF, DBSERVERIPADDRESSRF" + Environment.NewLine;
                sqlText += "FROM SECMNGCONNECTSTRF " + Environment.NewLine;
                sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                //sqlText += "ORDER BY PATTERNNODERIVEDNORF";
                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = secMngConnectStWork.EnterpriseCode;
                findParaSectionCode.Value = secMngConnectStWork.SectionCode;

                sqlCommand.CommandText += sqlText;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToSecMngConnectStWorkFromReader(ref myReader));
                }

                // �������ʂ�����ꍇ
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SecMngConnectStDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SecMngConnectStDB.SearchProc" + status);
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

            secMngConnectStWorkList = al;

            return status;
        }
        # endregion

        # region [Write]
        /// <summary>
        /// �ڑ���ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="objSecMngConnectStWork">SecMngConnectStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ڑ���ݒ�}�X�^��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public int Write(ref object objSecMngConnectStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                SecMngConnectStWork secMngConnectStWork = objSecMngConnectStWork as SecMngConnectStWork;

                status = WriteProc(ref secMngConnectStWork, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    objSecMngConnectStWork = secMngConnectStWork;
                }
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SecMngConnectStDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SecMngConnectStDB.Write", status);
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
        /// �ڑ���ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <remarks>
        /// <param name="secMngConnectStWork">�ڑ���ݒ�}�X�^���</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ڑ���ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        private int WriteProc(ref SecMngConnectStWork secMngConnectStWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM SECMNGCONNECTSTRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion


                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = secMngConnectStWork.EnterpriseCode;
                findParaSectionCode.Value = secMngConnectStWork.SectionCode;

                sqlCommand.CommandText += sqlText;

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    DateTime comUpDateTime = secMngConnectStWork.UpdateDateTime;

                    // �r���`�F�b�N
                    if (_updateDateTime != comUpDateTime)
                    {
                        //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }
                        return status;
                    }

                    # region [UPDATE��]
                    sqlText = string.Empty;
                    sqlText += "UPDATE SECMNGCONNECTSTRF " + Environment.NewLine;
                    sqlText += "SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , CONNECTPOINTDIVRF=@CONNECTPOINTDIV , APSERVERIPADDRESSRF=@APSERVERIPADDRESS , DBSERVERIPADDRESSRF=@DBSERVERIPADDRESS" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = secMngConnectStWork.EnterpriseCode;
                    findParaSectionCode.Value = secMngConnectStWork.SectionCode;

                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)secMngConnectStWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    if (secMngConnectStWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }

                    //�@��ʂ̃f�[�^�Ainsert����
                    # region [INSERT��]
                    sqlText = string.Empty;
                    sqlText = "INSERT INTO SECMNGCONNECTSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CONNECTPOINTDIVRF, APSERVERIPADDRESSRF, DBSERVERIPADDRESSRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @CONNECTPOINTDIV, @APSERVERIPADDRESS, @DBSERVERIPADDRESS)";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //�o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)secMngConnectStWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }

                if (myReader.IsClosed == false) myReader.Close();

                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraConnectPointDiv = sqlCommand.Parameters.Add("@CONNECTPOINTDIV", SqlDbType.Int);
                SqlParameter paraApServerIpAddress = sqlCommand.Parameters.Add("@APSERVERIPADDRESS", SqlDbType.NVarChar);
                SqlParameter paraDbServerIpAddress = sqlCommand.Parameters.Add("@DBSERVERIPADDRESS", SqlDbType.NVarChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngConnectStWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngConnectStWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngConnectStWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(secMngConnectStWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(secMngConnectStWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(secMngConnectStWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(secMngConnectStWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(secMngConnectStWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(secMngConnectStWork.SectionCode);
                paraConnectPointDiv.Value = SqlDataMediator.SqlSetInt32(secMngConnectStWork.ConnectPointDiv);
                paraApServerIpAddress.Value = SqlDataMediator.SqlSetString(secMngConnectStWork.ApServerIpAddress);
                paraDbServerIpAddress.Value = SqlDataMediator.SqlSetString(secMngConnectStWork.DbServerIpAddress);

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SecMngConnectStDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SecMngConnectStDB.Write" + status);
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

        # region UpdateRegistryKeyValue
        /// <summary>
        /// ���W�X�g���̃L�[���ڂ��X�V����
        /// </summary>
        /// <remarks>
        /// <param name="objSecMngConnectStWork">�ڑ���ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���W�X�g���̃L�[���ڂ��X�V���܂�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        public int UpdateRegistryKeyValue(ref object objSecMngConnectStWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                SecMngConnectStWork secMngConnectStWork = objSecMngConnectStWork as SecMngConnectStWork;

                string rKeyName1 = @String.Format("SOFTWARE\\Broadleaf\\Service\\Partsman\\SUMMARY_AP");
                string rKeyName2 = @String.Format("SOFTWARE\\Broadleaf\\Service\\Partsman\\SUMMARY_AP\\SUMMARY_DB");
                RegistryKey rKey1 = Registry.LocalMachine.OpenSubKey(rKeyName1, true);
                RegistryKey rKey2 = Registry.LocalMachine.OpenSubKey(rKeyName2, true);

                if (rKey1 == null)
                {
                    rKey1 = Registry.LocalMachine.CreateSubKey(rKeyName1);
                }

                if (rKey2 == null)
                {
                    rKey2 = Registry.LocalMachine.CreateSubKey(rKeyName2);
                }

                if (rKey1 != null && rKey2 != null)
                {
                    rKey1.SetValue("%Domain%", secMngConnectStWork.ApServerIpAddress, RegistryValueKind.String);
                    rKey2.SetValue("%DataSource%", secMngConnectStWork.DbServerIpAddress, RegistryValueKind.String);

                    // ����%RequiredServerVersion%�����ݎ��ɂ͍X�V�ΏۊO
                    if (rKey1.GetValue("RequiredServerVersion") == null)
                    {
                        rKey1.SetValue("RequiredServerVersion", "0", RegistryValueKind.DWord);
                    }
                }

                objSecMngConnectStWork = secMngConnectStWork;
            }
            catch (IOException)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            catch (SecurityException)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                base.WriteErrorLog(ex, "SecMngConnectStDB.UpdateRegistryKeyValue", status);
            }
            return status;
        }

        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SecMngSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SecMngConnectStWork</returns>
        /// <remarks>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        private SecMngConnectStWork CopyToSecMngConnectStWorkFromReader(ref SqlDataReader myReader)
        {
            SecMngConnectStWork secMngConnectStWork = new SecMngConnectStWork();

            if (myReader != null && secMngConnectStWork != null)
            {
                # region �N���X�֊i�[
                secMngConnectStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                secMngConnectStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                secMngConnectStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                secMngConnectStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                secMngConnectStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                secMngConnectStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                secMngConnectStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                secMngConnectStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                secMngConnectStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                secMngConnectStWork.ConnectPointDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONNECTPOINTDIVRF"));
                secMngConnectStWork.ApServerIpAddress = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("APSERVERIPADDRESSRF"));
                secMngConnectStWork.DbServerIpAddress = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DBSERVERIPADDRESSRF"));

                # endregion
            }
            return secMngConnectStWork;
        }
        # endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DB�ɐڑ�����Ă��Ȃ��ꍇ�͂����Őڑ�����
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // �g�����U�N�V�����̐���(�J�n)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        # endregion
    }
}
