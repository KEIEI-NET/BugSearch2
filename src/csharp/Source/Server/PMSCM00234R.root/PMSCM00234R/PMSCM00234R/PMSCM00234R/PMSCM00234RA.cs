//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �I�v�V�����Ǘ��}�X�^�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : �I�v�V�����Ǘ��}�X�^�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g��
// �� �� ��  2014/08/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Data.SqlClient;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �I�v�V�����Ǘ��}�X�^DB�������[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I�v�V�����Ǘ��}�X�^�̍X�V������s���N���X�ł��B</br>
    /// <br>Programmer : limm</br>
    /// <br>Date       : 2014/08/05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PMOptMngDB : RemoteDB,IPMOptMngDB
    {
        # region ��Constructor
        /// <summary>
        /// �I�v�V�����Ǘ��}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        /// </remarks>
        public PMOptMngDB() 
        {

        }
        #endregion

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̃I�v�V�����Ǘ��}�X�^LIST��߂��܂�
        /// </summary>
        /// <param name="pMOptMngWorkList">��������</param>
        /// <param name="parapMOptMngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃I�v�V�����Ǘ��}�X�^LIST��߂��܂�</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        public int Search(out object pMOptMngWorkList, object parapMOptMngWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            pMOptMngWorkList = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchProc(out pMOptMngWorkList, parapMOptMngWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMOptMngDB.Search");
                pMOptMngWorkList = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �I�v�V�����Ǘ��}�X�^LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objpMOptMngListWork">��������</param>
        /// <param name="parapMOptMngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃I�v�V�����Ǘ��}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        private int SearchProc(out object objpMOptMngListWork, object parapMOptMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            PMOptMngWork parapMOptMngWk = null;
            ArrayList pMOptMngWorkList = new ArrayList();

            if (parapMOptMngWork == null)
            {
                parapMOptMngWk = new PMOptMngWork();
            }
            else
            {
                parapMOptMngWk = parapMOptMngWork as PMOptMngWork;
            }

            int status = SearchPMOptMngProc(out pMOptMngWorkList, parapMOptMngWk, readMode, logicalMode, ref sqlConnection);
            objpMOptMngListWork = pMOptMngWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃I�v�V�����Ǘ��}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="pMOptMngWorkList">��������</param>
        /// <param name="pMOptMngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃I�v�V�����Ǘ��}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        private int SearchPMOptMngProc(out ArrayList pMOptMngWorkList, PMOptMngWork pMOptMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchPMOptMngProcProc(out pMOptMngWorkList, pMOptMngWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃I�v�V�����Ǘ��}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="pMOptMngWorkList">��������</param>
        /// <param name="pMOptMngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃I�v�V�����Ǘ��}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        private int SearchPMOptMngProcProc(out ArrayList pMOptMngWorkList, PMOptMngWork pMOptMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                StringBuilder selectTxt = new StringBuilder(string.Empty);

                # region SELECT��
                selectTxt.Append("SELECT   CREATEDATETIMERF ");
                selectTxt.Append(" ,UPDATEDATETIMERF ").Append(Environment.NewLine);  
                selectTxt.Append(" ,ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append(" ,FILEHEADERGUIDRF ").Append(Environment.NewLine);
                selectTxt.Append(" ,UPDEMPLOYEECODERF ").Append(Environment.NewLine);
                selectTxt.Append(" ,UPDASSEMBLYID1RF ").Append(Environment.NewLine);
                selectTxt.Append(" ,UPDASSEMBLYID2RF ").Append(Environment.NewLine);
                selectTxt.Append(" ,LOGICALDELETECODERF ").Append(Environment.NewLine);
                selectTxt.Append(" ,SECTIONCODERF ").Append(Environment.NewLine);
                selectTxt.Append(" ,OPTIONCODERF ").Append(Environment.NewLine);
                selectTxt.Append(" ,OPTIONUSEDIVRF ").Append(Environment.NewLine);
                selectTxt.Append("  FROM PMOPTMNGRF  ").Append(Environment.NewLine);
                selectTxt.Append("  WITH (READUNCOMMITTED)").Append(Environment.NewLine);  
                #endregion

                sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, pMOptMngWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToPMOptMngWorkFromReader(ref myReader));

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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            pMOptMngWorkList = al;

            return status;
        }
        #endregion

        #region [SearchAll]
        /// <summary>
        /// �I�v�V�����Ǘ��}�X�^LIST��߂��܂�
        /// </summary>
        /// <param name="pMOptMngWorkList">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃I�v�V�����Ǘ��}�X�^LIST��߂��܂�</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        public int SearchAll(out object pMOptMngWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            pMOptMngWorkList = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchAllProc(out pMOptMngWorkList, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMOptMngDB.Search");
                pMOptMngWorkList = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �I�v�V�����Ǘ��}�X�^LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objpMOptMngListWork">��������</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃I�v�V�����Ǘ��}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        private int SearchAllProc(out object objpMOptMngListWork, ref SqlConnection sqlConnection)
        {
            ArrayList pMOptMngWorkList = new ArrayList();

            int status = SearchAllPMOptMngProc(out pMOptMngWorkList, ref sqlConnection);
            objpMOptMngListWork = pMOptMngWorkList;
            return status;
        }

        /// <summary>
        /// �I�v�V�����Ǘ��}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="pMOptMngWorkList">��������</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃I�v�V�����Ǘ��}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        private int SearchAllPMOptMngProc(out ArrayList pMOptMngWorkList, ref SqlConnection sqlConnection)
        {
            return this.SearchAllPMOptMngProcProc(out pMOptMngWorkList, ref sqlConnection);
        }

        /// <summary>
        /// �I�v�V�����Ǘ��}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="pMOptMngWorkList">��������</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃I�v�V�����Ǘ��}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        private int SearchAllPMOptMngProcProc(out ArrayList pMOptMngWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                # region SELECT��
                string sqlText = string.Empty;
                sqlText = "SELECT CREATEDATETIMERF ,UPDATEDATETIMERF ,ENTERPRISECODERF ,FILEHEADERGUIDRF ,UPDEMPLOYEECODERF ,UPDASSEMBLYID1RF ,UPDASSEMBLYID2RF ,LOGICALDELETECODERF ,SECTIONCODERF ,OPTIONCODERF ,OPTIONUSEDIVRF FROM PMOPTMNGRF WITH (READUNCOMMITTED)";               
                #endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToPMOptMngWorkFromReader(ref myReader));

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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            pMOptMngWorkList = al;

            return status;
        }
        #endregion

        # region [Write]
        /// <summary>
        /// �I�v�V�����Ǘ��}�X�^��ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pMOptMngWorkList">PMOptMngWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pMOptMngWork �Ɋi�[����Ă���X�V���X�g��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        public int Write(ref object pMOptMngWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = pMOptMngWorkList as ArrayList; ;
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //�ǉ��E�X�V���s
                status = WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    pMOptMngWorkList = paraList;
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMOptMngDB.Write(ref object pMOptMngWork)");// ?
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �I�v�V�����Ǘ��}�X�^��ǉ��E�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)�B
        /// </summary>
        /// <param name="pMOptMngWorkList">�ǉ��E�X�V����X�V���X�g���܂� ArrayList</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pMOptMngWorkList �Ɋi�[����Ă���X�V���X�g��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        private int WriteProc(ref ArrayList pMOptMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (pMOptMngWorkList != null)
                {
                    for (int i = 0; i < pMOptMngWorkList.Count; i++)
                    {
                        PMOptMngWork pMOptMngWork = pMOptMngWorkList[i] as PMOptMngWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM PMOPTMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND OPTIONCODERF=@FINDOPTIONCODERF ", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
                        SqlParameter findOptionCode = sqlCommand.Parameters.Add("@FINDOPTIONCODERF", SqlDbType.NChar);  // �I�v�V�����R�[�h
                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.EnterpriseCode);  // ��ƃR�[�h
                        findSectionCode.Value = pMOptMngWork.SectionCode.Trim();   // ���_�R�[�h
                        findOptionCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.OptionCode);  // �I�v�V�����R�[�h

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            # region UPDATE��
                            string sqlText = string.Empty;
                            sqlText = "UPDATE PMOPTMNGRF SET UPDATEDATETIMERF = @UPDATEDATETIME , ENTERPRISECODERF = @ENTERPRISECODE , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 , LOGICALDELETECODERF = @LOGICALDELETECODE , OPTIONUSEDIVRF = @OPTIONUSEDIV WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND SECTIONCODERF = @FINDSECTIONCODE AND OPTIONCODERF = @FINDOPTIONCODERF ";

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.EnterpriseCode);  // ��ƃR�[�h
                            findSectionCode.Value = pMOptMngWork.SectionCode.Trim();   // ���_�R�[�h
                            findOptionCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.OptionCode);  // �I�v�V�����R�[�h


                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pMOptMngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (pMOptMngWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �V�K�쐬����SQL���𐶐�
                            string sqlText = string.Empty;
                            sqlText = "INSERT INTO PMOPTMNGRF (CREATEDATETIMERF ,UPDATEDATETIMERF ,ENTERPRISECODERF ,FILEHEADERGUIDRF ,UPDEMPLOYEECODERF ,UPDASSEMBLYID1RF ,UPDASSEMBLYID2RF ,LOGICALDELETECODERF ,SECTIONCODERF ,OPTIONCODERF ,OPTIONUSEDIVRF ) VALUES (@CREATEDATETIME ,@UPDATEDATETIME ,@ENTERPRISECODE ,@FILEHEADERGUID ,@UPDEMPLOYEECODE ,@UPDASSEMBLYID1 ,@UPDASSEMBLYID2 ,@LOGICALDELETECODE ,@SECTIONCODE ,@OPTIONCODE ,@OPTIONUSEDIV ) ";

                            sqlCommand.CommandText = sqlText;

                            # endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pMOptMngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // �쐬����
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // �X�V����
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // �X�V�]�ƈ��R�[�h
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // �X�V�A�Z���u��ID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // �X�V�A�Z���u��ID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // �_���폜�敪
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
                        SqlParameter paraOptionCode = sqlCommand.Parameters.Add("@OPTIONCODE", SqlDbType.NChar);  // �I�v�V�����R�[�h
                        SqlParameter paraOptionUseDiv = sqlCommand.Parameters.Add("@OPTIONUSEDIV", SqlDbType.Int);  // �I�v�V�������p�敪
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pMOptMngWork.CreateDateTime);  // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pMOptMngWork.UpdateDateTime);  // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.EnterpriseCode);  // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pMOptMngWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pMOptMngWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pMOptMngWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pMOptMngWork.LogicalDeleteCode);  // �_���폜�敪
                        paraSectionCode.Value = pMOptMngWork.SectionCode.Trim();   // ���_�R�[�h
                        paraOptionCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.OptionCode);  // �I�v�V�����R�[�h
                        paraOptionUseDiv.Value = SqlDataMediator.SqlSetInt32(pMOptMngWork.OptionUseDiv);  // �I�v�V�������p�敪
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(pMOptMngWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "WriteProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            pMOptMngWorkList = al;

            return status;
        }

        # endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="pMOptMngWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : limm�@</br>
        /// <br>Date       : 2014/08/05</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, PMOptMngWork pMOptMngWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.EnterpriseCode);

            //���_�R�[�h
            if (string.IsNullOrEmpty(pMOptMngWork.SectionCode) == false)
            {
                retstring += "AND SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.SectionCode);
            }

            //�I�v�V�����R�[�h
            if (string.IsNullOrEmpty(pMOptMngWork.OptionCode) == false)
            {
                retstring += "AND OPTIONCODERF=@OPTIONCODE ";
                SqlParameter paraOptionCode = sqlCommand.Parameters.Add("@OPTIONCODE", SqlDbType.NChar);
                paraOptionCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.OptionCode);
            }

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� PMOptMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PMOptMngWork</returns>
        /// <remarks>
        /// <br>Programmer : limm�@</br>
        /// <br>Date       : 2014/08/05</br>
        /// </remarks>
        private PMOptMngWork CopyToPMOptMngWorkFromReader(ref SqlDataReader myReader)
        {
            PMOptMngWork wkPMOptMngWork = new PMOptMngWork();

            #region �N���X�֊i�[
            wkPMOptMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
            wkPMOptMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
            wkPMOptMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // ��ƃR�[�h
            wkPMOptMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkPMOptMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // �X�V�]�ƈ��R�[�h
            wkPMOptMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // �X�V�A�Z���u��ID1
            wkPMOptMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // �X�V�A�Z���u��ID2
            wkPMOptMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // �_���폜�敪
            wkPMOptMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // ���_�R�[�h
            wkPMOptMngWork.OptionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OPTIONCODERF"));  // �I�v�V�����R�[�h
            wkPMOptMngWork.OptionUseDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPTIONUSEDIVRF"));  // �I�v�V�������p�敪
            #endregion

            return wkPMOptMngWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
                #endregion

    }
}
