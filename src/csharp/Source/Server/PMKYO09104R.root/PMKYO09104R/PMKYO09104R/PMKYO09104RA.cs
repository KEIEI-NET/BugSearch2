//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_�Ǘ��ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���_�Ǘ��ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/03/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/21  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���_�Ǘ��ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.03.27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SecMngSetDB : RemoteDB, ISecMngSetDB
    {
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public SecMngSetDB()
            : base("PMKYO09106D", "Broadleaf.Application.Remoting.ParamData.SecMngSetWork", "SecMngSetRF")
        {

        }

        # region [Search]
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outSecMngSetList">��������</param>
        /// <param name="paraSecMngSetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�̃L�[�l����v����A�S�Ă̋��_�Ǘ��ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public int Search(out object outSecMngSetList, object paraSecMngSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList _secMngSetList = null;
            SecMngSetWork secMngSetWork = null;

            outSecMngSetList = new CustomSerializeArrayList();

            try
            {
                secMngSetWork = paraSecMngSetWork as SecMngSetWork;
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.SearchProc(out _secMngSetList, secMngSetWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SecMngSetDB.Search(out object, object, int, LogicalMode)", status);
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
            outSecMngSetList = _secMngSetList;
            return status;
        }

        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="secMngSetList">���_�Ǘ��ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="secMngSetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�̃L�[�l����v����A�S�Ă̋��_�Ǘ��ݒ�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        private int SearchProc(out ArrayList secMngSetList, SecMngSetWork secMngSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,KINDRF" + Environment.NewLine;
                sqlText += " ,RECEIVECONDITIONRF" + Environment.NewLine;
                sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                sqlText += " ,SYNCEXECDATERF" + Environment.NewLine;
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				sqlText += " ,SENDDESTSECCODERF" + Environment.NewLine;
				sqlText += " ,AUTOSENDDIVRF" + Environment.NewLine;
				sqlText += " ,SNDFINDATAEDDIVRF" + Environment.NewLine;
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SECMNGSETRF" + Environment.NewLine;
                sqlText += "WHERE " + Environment.NewLine;
                sqlText += "ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += " ORDER BY" + Environment.NewLine;
                sqlText += " SECTIONCODERF" + Environment.NewLine;
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				sqlText += " ,SENDDESTSECCODERF" + Environment.NewLine;
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = secMngSetWork.EnterpriseCode;


                sqlCommand.CommandText += sqlText;
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToSecMngSetWorkFromReader(ref myReader));
                }

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
                status = base.WriteSQLErrorLog(sqlex, "SecMngSetDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SecMngSetDB.SearchProc" + status);
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
            secMngSetList = al;

            return status;
        }
        # endregion

        # region [Write]
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">SecMngSetWork�I�u�W�F�N�g</param>
        /// <param name="writeMode">�X�V�敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public int Write(ref object paraSecMngSetWork, int writeMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // XML�̓ǂݍ���
                //SecMngSetWork secMngSetWork = (SecMngSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngSetWork));
                SecMngSetWork secMngSetWork = paraSecMngSetWork as SecMngSetWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = WriteProc(secMngSetWork, writeMode, ref sqlConnection, ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                //parabyte = XmlByteSerializer.Serialize(secMngSetWork);
                paraSecMngSetWork = secMngSetWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SecMngSetDB.Write(ref object)", status);
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
        /// ���_�Ǘ��ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <remarks>
        /// <param name="secMngSetWork">���_�Ǘ��ݒ�}�X�^���</param>
        /// <param name="writeMode">�X�V�敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        private int WriteProc(SecMngSetWork secMngSetWork, int writeMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SECMNGSETRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND KINDRF = @FINDKIND" + Environment.NewLine;
                sqlText += "  AND RECEIVECONDITIONRF = @FINDRECEIVECONDITION" + Environment.NewLine;
                sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				sqlText += "  AND SENDDESTSECCODERF = @FINDSENDDESTSECCODE" + Environment.NewLine;
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                # endregion

                using (sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaKind = sqlCommand.Parameters.Add("@FINDKIND", SqlDbType.Int);
                    SqlParameter findParaReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITION", SqlDbType.Int);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
					SqlParameter findParaSendSecCode = sqlCommand.Parameters.Add("@FINDSENDDESTSECCODE", SqlDbType.NChar);
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = secMngSetWork.EnterpriseCode;
                    findParaKind.Value = secMngSetWork.Kind;
                    findParaReceiveCondition.Value = secMngSetWork.ReceiveCondition;
                    findParaSectionCode.Value = secMngSetWork.SectionCode;
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
					findParaSendSecCode.Value = secMngSetWork.SendDestSecCode;
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != secMngSetWork.UpdateDateTime)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (secMngSetWork.UpdateDateTime == DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }
                            return status;
                        }

                        # region [UPDATE��]
                        sqlText = string.Empty;
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  SECMNGSETRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,SYNCEXECDATERF = @SYNCEXECDATE" + Environment.NewLine;
						// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
						sqlText += " ,AUTOSENDDIVRF = @AUTOSENDDIV" + Environment.NewLine;
						sqlText += " ,SNDFINDATAEDDIVRF = @SNDFINDATAEDDIV" + Environment.NewLine;
						// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND KINDRF = @FINDKIND" + Environment.NewLine;
                        sqlText += "  AND RECEIVECONDITIONRF = @FINDRECEIVECONDITION" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
						// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
						sqlText += "  AND SENDDESTSECCODERF = @FINDSENDDESTSECCODE" + Environment.NewLine;
						// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = secMngSetWork.EnterpriseCode;
                        findParaKind.Value = secMngSetWork.Kind;
                        findParaReceiveCondition.Value = secMngSetWork.ReceiveCondition;
                        findParaSectionCode.Value = secMngSetWork.SectionCode;
						// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
						findParaSendSecCode.Value = secMngSetWork.SendDestSecCode;
						// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)secMngSetWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (secMngSetWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT��]
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO" + Environment.NewLine;
                        sqlText += "  SECMNGSETRF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "    ,KINDRF" + Environment.NewLine;
                        sqlText += "    ,RECEIVECONDITIONRF" + Environment.NewLine;
                        sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlText += "    ,SYNCEXECDATERF" + Environment.NewLine;
						// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
						sqlText += "    ,SENDDESTSECCODERF" + Environment.NewLine;
						sqlText += "    ,AUTOSENDDIVRF" + Environment.NewLine;
						sqlText += "    ,SNDFINDATAEDDIVRF" + Environment.NewLine;
						// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                        sqlText += " )" + Environment.NewLine;
                        sqlText += " VALUES" + Environment.NewLine;
                        sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                        sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "    ,@KIND" + Environment.NewLine;
                        sqlText += "    ,@RECEIVECONDITION" + Environment.NewLine;
                        sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                        sqlText += "    ,@SYNCEXECDATE" + Environment.NewLine;
						// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
						sqlText += "    ,@SENDDESTSECCODE" + Environment.NewLine;
						sqlText += "    ,@AUTOSENDDIV" + Environment.NewLine;
						sqlText += "    ,@SNDFINDATAEDDIV" + Environment.NewLine;
						// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                        sqlText += " )" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)secMngSetWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraKind = sqlCommand.Parameters.Add("@KIND", SqlDbType.Int);
                    SqlParameter paraReceiveCondition = sqlCommand.Parameters.Add("@RECEIVECONDITION", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
					SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
					SqlParameter paraSendDestSecCode = sqlCommand.Parameters.Add("@SENDDESTSECCODE", SqlDbType.NChar);
					SqlParameter paraAutoSendDiv = sqlCommand.Parameters.Add("@AUTOSENDDIV", SqlDbType.BigInt);
					SqlParameter paraSndFinDataEdDiv = sqlCommand.Parameters.Add("@SNDFINDATAEDDIV", SqlDbType.BigInt);
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngSetWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngSetWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSetWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(secMngSetWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(secMngSetWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(secMngSetWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(secMngSetWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(secMngSetWork.LogicalDeleteCode);
                    paraKind.Value = SqlDataMediator.SqlSetInt32(secMngSetWork.Kind);
                    paraReceiveCondition.Value = SqlDataMediator.SqlSetInt32(secMngSetWork.ReceiveCondition);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(secMngSetWork.SectionCode);
                    paraSyncExecDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngSetWork.SyncExecDate);
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
					paraSendDestSecCode.Value = SqlDataMediator.SqlSetString(secMngSetWork.SendDestSecCode);
					paraAutoSendDiv.Value = SqlDataMediator.SqlSetInt32(secMngSetWork.AutoSendDiv);
					paraSndFinDataEdDiv.Value = SqlDataMediator.SqlSetInt32(secMngSetWork.SndFinDataEdDiv);
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SecMngSetDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SecMngSetDB.Write" + status);
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
        ///  ���_�Ǘ��ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">SecMngSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�̃L�[�l����v���� ���_�Ǘ��ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        public int Delete(ref object paraSecMngSetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // XML�̓ǂݍ���
                //SecMngSetWork secMngSetWork = (SecMngSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngSetWork));
                SecMngSetWork secMngSetWork = paraSecMngSetWork as SecMngSetWork;


                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.DeleteProc(secMngSetWork, ref sqlConnection, ref sqlTransaction);

                paraSecMngSetWork = secMngSetWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SecMngSetDB.Delete(ref object secMngSetWork)", status);
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
        /// ���_�Ǘ��ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <remarks>
        /// <param name="secMngSetWork">���_�Ǘ��ݒ�}�X�^���</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        private int DeleteProc(SecMngSetWork secMngSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SECMNGSETRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND KINDRF = @FINDKIND" + Environment.NewLine;
                sqlText += "  AND RECEIVECONDITIONRF = @FINDRECEIVECONDITION" + Environment.NewLine;
                sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				sqlText += "  AND SENDDESTSECCODERF = @FINDSENDDESTSECCODE" + Environment.NewLine;
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                sqlCommand.CommandText = sqlText;
                # endregion
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaKind = sqlCommand.Parameters.Add("@FINDKIND", SqlDbType.Int);
                SqlParameter findParaReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITION", SqlDbType.Int);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				SqlParameter findParaSendDestSecCode = sqlCommand.Parameters.Add("@FINDSENDDESTSECCODE", SqlDbType.NChar);
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = secMngSetWork.EnterpriseCode;
                findParaKind.Value = secMngSetWork.Kind;
                findParaReceiveCondition.Value = secMngSetWork.ReceiveCondition;
                findParaSectionCode.Value = secMngSetWork.SectionCode;
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				findParaSendDestSecCode.Value = secMngSetWork.SendDestSecCode;
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                    if (_updateDateTime != secMngSetWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }


                    # region [DELETE��]
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SECMNGSETRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND KINDRF = @FINDKIND" + Environment.NewLine;
                    sqlText += "  AND RECEIVECONDITIONRF = @FINDRECEIVECONDITION" + Environment.NewLine;
                    sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
					sqlText += "  AND SENDDESTSECCODERF = @FINDSENDDESTSECCODE" + Environment.NewLine;
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = secMngSetWork.EnterpriseCode;
                    findParaKind.Value = secMngSetWork.Kind;
                    findParaReceiveCondition.Value = secMngSetWork.ReceiveCondition;
                    findParaSectionCode.Value = secMngSetWork.SectionCode;
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
					findParaSendDestSecCode.Value = secMngSetWork.SendDestSecCode;
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
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

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SecMngSetDB.DeleteProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SecMngSetDB.DeleteProc" + status);
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

        # region [LogicalDelete]
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">SecMngSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        public int LogicalDelete(ref object paraSecMngSetWork)
        {
            return this.LogicalDelete(ref paraSecMngSetWork, 0);
        }

        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">�_���폜���������鋒�_�Ǘ��ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object paraSecMngSetWork)
        {
            return this.LogicalDelete(ref paraSecMngSetWork, 1);
        }

        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">�_���폜�𑀍삷�鋒�_�Ǘ��ݒ�}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierWork �Ɋi�[����Ă��鋒�_�Ǘ��ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        private int LogicalDelete(ref object paraSecMngSetWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // XML�̓ǂݍ���
                //SecMngSetWork secMngSetWork = (SecMngSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngSetWork));
                SecMngSetWork secMngSetWork = paraSecMngSetWork as SecMngSetWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDeleteProc(ref secMngSetWork, procMode, ref sqlConnection, ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                //parabyte = XmlByteSerializer.Serialize(secMngSetWork);
                paraSecMngSetWork = secMngSetWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SecMngSetDB.LogicalDelete(ref object, int[" + procMode.ToString() + "])", status);
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
        /// ���_�Ǘ��ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="paraSecMngSetWork">�_���폜�𑀍삷�鋒�_�Ǘ��ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierWork �Ɋi�[����Ă��鋒�_�Ǘ��ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.4.24</br>
        private int LogicalDeleteProc(ref SecMngSetWork paraSecMngSetWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SECMNGSETRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND KINDRF = @FINDKIND" + Environment.NewLine;
                sqlText += "  AND RECEIVECONDITIONRF = @FINDRECEIVECONDITION" + Environment.NewLine;
                sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				sqlText += "  AND SENDDESTSECCODERF = @FINDSENDDESTSECCODE" + Environment.NewLine;
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                # endregion
                using (sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaKind = sqlCommand.Parameters.Add("@FINDKIND", SqlDbType.Int);
                    SqlParameter findParaReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITION", SqlDbType.Int);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
					SqlParameter findParaSendDestSecCode = sqlCommand.Parameters.Add("@FINDSENDDESTSECCODE", SqlDbType.NChar);
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = paraSecMngSetWork.EnterpriseCode;
                    findParaKind.Value = paraSecMngSetWork.Kind;
                    findParaReceiveCondition.Value = paraSecMngSetWork.ReceiveCondition;
                    findParaSectionCode.Value = paraSecMngSetWork.SectionCode;
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
					findParaSendDestSecCode.Value = paraSecMngSetWork.SendDestSecCode;
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != paraSecMngSetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // ���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));


                        # region [UPDATE��]
                        sqlText = string.Empty;
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  SECMNGSETRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND KINDRF = @FINDKIND" + Environment.NewLine;
                        sqlText += "  AND RECEIVECONDITIONRF = @FINDRECEIVECONDITION" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
						// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
						sqlText += "  AND SENDDESTSECCODERF = @FINDSENDDESTSECCODE" + Environment.NewLine;
						// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = paraSecMngSetWork.EnterpriseCode;
                        findParaKind.Value = paraSecMngSetWork.Kind;
                        findParaReceiveCondition.Value = paraSecMngSetWork.ReceiveCondition;
                        findParaSectionCode.Value = paraSecMngSetWork.SectionCode;
						// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
						findParaSendDestSecCode.Value = paraSecMngSetWork.SendDestSecCode;
						// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)paraSecMngSetWork;
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
                        else if (logicalDelCd == 0) paraSecMngSetWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                        else paraSecMngSetWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            paraSecMngSetWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paraSecMngSetWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paraSecMngSetWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paraSecMngSetWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paraSecMngSetWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paraSecMngSetWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SecMngSetDB.LogicalDeleteProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SecMngSetDB.LogicalDeleteProc" + status);
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

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SecMngSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SecMngSetWork</returns>
        /// <remarks>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        private SecMngSetWork CopyToSecMngSetWorkFromReader(ref SqlDataReader myReader)
        {
            SecMngSetWork secMngSetWork = new SecMngSetWork();

            if (myReader != null && secMngSetWork != null)
            {
                # region �N���X�֊i�[
                secMngSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                secMngSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                secMngSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                secMngSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                secMngSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                secMngSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                secMngSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                secMngSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                secMngSetWork.Kind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("KINDRF"));
                secMngSetWork.ReceiveCondition = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIVECONDITIONRF"));
                secMngSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                secMngSetWork.SyncExecDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("SYNCEXECDATERF"));
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				secMngSetWork.SendDestSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDDESTSECCODERF"));
				secMngSetWork.AutoSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOSENDDIVRF"));
				secMngSetWork.SndFinDataEdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDFINDATAEDDIVRF"));
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                # endregion
            }
            return secMngSetWork;
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
