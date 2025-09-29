//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�R�[�h�ϊ��}�X�^�����e�i���X
// �v���O�����T�v   : ���i�R�[�h�ϊ��̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/08/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�R�[�h�ϊ��}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�R�[�h�ϊ��}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.08.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SAndEGoodsCdChgSetDB : RemoteDB, ISAndEGoodsCdChgSetDB
    {
        /// <summary>
        /// ���i�R�[�h�ϊ��}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        public SAndEGoodsCdChgSetDB()
            : base("PMSAE09026D", "Broadleaf.Application.Remoting.ParamData.SAndEGoodsCdChgWork", "SANDEGOODSCDCHGSET")
        {

        }

        # region [Delete]
        /// <summary>
        /// ���i�R�[�h�ϊ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="objectSAndEGoodsCdChgWork">SAndEGoodsCdChgWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�R�[�h�ϊ��}�X�^�̃L�[�l����v���鏤�i�R�[�h�ϊ��}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        public int Delete(ref object objectSAndEGoodsCdChgWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // XML�̓ǂݍ���
                SAndEGoodsCdChgWork sAndEGoodsCdChgWork = objectSAndEGoodsCdChgWork as SAndEGoodsCdChgWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(ref sAndEGoodsCdChgWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEGoodsCdChgSetDB.Delete(object)", status);
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
        /// ���i�R�[�h�ϊ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="sAndEGoodsCdChgWork">���i�R�[�h�ϊ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEGoodsCdChgWork �Ɋi�[����Ă��鏤�i�R�[�h�ϊ��}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        public int Delete(ref SAndEGoodsCdChgWork sAndEGoodsCdChgWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(ref sAndEGoodsCdChgWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i�R�[�h�ϊ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="sAndEGoodsCdChgWork">���i�R�[�h�ϊ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEGoodsCdChgWork �Ɋi�[����Ă��鏤�i�R�[�h�ϊ��}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        private int DeleteProc(ref SAndEGoodsCdChgWork sAndEGoodsCdChgWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (sAndEGoodsCdChgWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SANDEGOODSCDCHGRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND BLGOODSCODERF = @FINDBLGOODSCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEGoodsCdChgWork.EnterpriseCode);
                    findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(sAndEGoodsCdChgWork.BLGoodsCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != sAndEGoodsCdChgWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        # region [DELETE��]
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  SANDEGOODSCDCHGRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND BLGOODSCODERF = @FINDBLGOODSCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEGoodsCdChgWork.EnterpriseCode);
                        findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(sAndEGoodsCdChgWork.BLGoodsCode);
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
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SAndEGoodsCdChgSetDB.DeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEGoodsCdChgSetDB.DeleteProc" , status);
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
        /// ���i�R�[�h�ϊ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outSAndEGoodsCdChgWorkList">��������</param>
        /// <param name="paraSAndEGoodsCdChgSetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�R�[�h�ϊ��}�X�^�̃L�[�l����v����A�S�Ă̏��i�R�[�h�ϊ��}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        public int Search(out object outSAndEGoodsCdChgWorkList, object paraSAndEGoodsCdChgSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _sAndEGoodsCdChgList = null;
            SAndEGoodsCdChgWork sAndEGoodsCdChgWork = null;

            outSAndEGoodsCdChgWorkList = new CustomSerializeArrayList();

            try
            {
                if (paraSAndEGoodsCdChgSetWork is SAndEGoodsCdChgWork)
                {
                    sAndEGoodsCdChgWork = paraSAndEGoodsCdChgSetWork as SAndEGoodsCdChgWork;
                }
                else if (paraSAndEGoodsCdChgSetWork is ArrayList)
                {
                    if ((paraSAndEGoodsCdChgSetWork as ArrayList).Count > 0)
                    {
                        sAndEGoodsCdChgWork = (paraSAndEGoodsCdChgSetWork as ArrayList)[0] as SAndEGoodsCdChgWork;
                    }
                }

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(out _sAndEGoodsCdChgList, sAndEGoodsCdChgWork, readMode, logicalMode, ref sqlConnection);

                if (_sAndEGoodsCdChgList != null)
                {
                    (outSAndEGoodsCdChgWorkList as CustomSerializeArrayList).AddRange(_sAndEGoodsCdChgList);
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEGoodsCdChgSetDB.Search(out object, object, int, LogicalMode)", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���i�R�[�h�ϊ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="sAndEGoodsCdChgList">���i�R�[�h�ϊ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sAndEGoodsCdChgWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�R�[�h�ϊ��}�X�^�̃L�[�l����v����A�S�Ă̏��i�R�[�h�ϊ��}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        public int Search(out ArrayList sAndEGoodsCdChgList, SAndEGoodsCdChgWork sAndEGoodsCdChgWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchProc(out sAndEGoodsCdChgList, sAndEGoodsCdChgWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// ���i�R�[�h�ϊ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="sAndEGoodsCdChgList">���i�R�[�h�ϊ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sAndEGoodsCdChgWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�R�[�h�ϊ��}�X�^�̃L�[�l����v����A�S�Ă̏��i�R�[�h�ϊ��}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        private int SearchProc(out ArrayList sAndEGoodsCdChgList, SAndEGoodsCdChgWork sAndEGoodsCdChgWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
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
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  A.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,A.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,A.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,A.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,A.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,A.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,A.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,A.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,A.BLGOODSCODERF" + Environment.NewLine;
                sqlText += " ,A.ABGOODSCODERF" + Environment.NewLine;
                sqlText += " ,B.BLGOODSHALFNAMERF" + Environment.NewLine;
                sqlText += " FROM SANDEGOODSCDCHGRF AS A" + Environment.NewLine;
                sqlText += " LEFT JOIN BLGOODSCDURF AS B" + Environment.NewLine;
                sqlText += " ON A.BLGOODSCODERF = B.BLGOODSCODERF" + Environment.NewLine;
                sqlText += " AND A.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND B.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, sAndEGoodsCdChgWork, logicalMode);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToSAndEGoodsCdChgWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "SAndEGoodsCdChgSetDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEGoodsCdChgSetDB.SearchProc" , status);
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

            sAndEGoodsCdChgList = al;

            return status;

        }

        # endregion

        # region [Write]
        /// <summary>
        /// ���i�R�[�h�ϊ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="outSAndEGoodsCdChgWork">�ǉ��E�X�V���鏤�i�R�[�h�ϊ��}�X�^���</param>
        /// <param name="writeMode">�X�V�敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : outSAndEGoodsCdChgWorkList �Ɋi�[����Ă��鏤�i�R�[�h�ϊ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        public int Write(ref object outSAndEGoodsCdChgWork, int writeMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                SAndEGoodsCdChgWork wkSAndEGoodsCdChgWork = outSAndEGoodsCdChgWork as SAndEGoodsCdChgWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = this.Write(ref wkSAndEGoodsCdChgWork, ref sqlConnection, ref sqlTransaction);

                // �߂�l�Z�b�g
                outSAndEGoodsCdChgWork = wkSAndEGoodsCdChgWork;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEGoodsCdChgSetDB.Write(ref object)", status);
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
        /// ���i�R�[�h�ϊ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="sAndEGoodsCdChgWork">�ǉ��E�X�V���鏤�i�R�[�h�ϊ��}�X�^�����i�[����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEGoodsCdChgWork �Ɋi�[����Ă��鏤�i�R�[�h�ϊ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        public int Write(ref SAndEGoodsCdChgWork sAndEGoodsCdChgWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref sAndEGoodsCdChgWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i�R�[�h�ϊ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="sAndEGoodsCdChgWork">�ǉ��E�X�V���鏤�i�R�[�h�ϊ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEGoodsCdChgWork �Ɋi�[����Ă��鏤�i�R�[�h�ϊ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        private int WriteProc(ref SAndEGoodsCdChgWork sAndEGoodsCdChgWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (sAndEGoodsCdChgWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SANDEGOODSCDCHGRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND BLGOODSCODERF = @FINDBLGOODSCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEGoodsCdChgWork.EnterpriseCode);
                    findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(sAndEGoodsCdChgWork.BLGoodsCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != sAndEGoodsCdChgWork.UpdateDateTime)
                        {
                            if (sAndEGoodsCdChgWork.UpdateDateTime == DateTime.MinValue)
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

                        # region [UPDATE��]
                        sqlText = string.Empty;
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  SANDEGOODSCDCHGRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,ABGOODSCODERF = @ABGOODSCODE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND BLGOODSCODERF = @FINDBLGOODSCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEGoodsCdChgWork.EnterpriseCode);
                        findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(sAndEGoodsCdChgWork.BLGoodsCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndEGoodsCdChgWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (sAndEGoodsCdChgWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT��]
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO SANDEGOODSCDCHGRF" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,BLGOODSCODERF" + Environment.NewLine;
                        sqlText += " ,ABGOODSCODERF" + Environment.NewLine;
                        sqlText += ")" + Environment.NewLine;
                        sqlText += "VALUES" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,@BLGOODSCODE" + Environment.NewLine;
                        sqlText += " ,@ABGOODSCODE" + Environment.NewLine;
                        sqlText += ")" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndEGoodsCdChgWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraAbgoodsCode = sqlCommand.Parameters.Add("@ABGOODSCODE", SqlDbType.NChar);
                    # endregion

                    # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndEGoodsCdChgWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndEGoodsCdChgWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEGoodsCdChgWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(sAndEGoodsCdChgWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sAndEGoodsCdChgWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sAndEGoodsCdChgWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sAndEGoodsCdChgWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sAndEGoodsCdChgWork.LogicalDeleteCode);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(sAndEGoodsCdChgWork.BLGoodsCode);
                    paraAbgoodsCode.Value = SqlDataMediator.SqlSetString(sAndEGoodsCdChgWork.ABGoodsCode);

                    # endregion

                    sqlCommand.ExecuteNonQuery();

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SAndEGoodsCdChgSetDB.Write", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEGoodsCdChgSetDB.Write" , status);
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
        /// ���i�R�[�h�ϊ��}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="objectsAndEGoodsCdChgWork">�_���폜���鏤�i�R�[�h�ϊ��}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEGoodsCdChgWork �Ɋi�[����Ă��鏤�i�R�[�h�ϊ��}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        public int LogicalDelete(ref object objectsAndEGoodsCdChgWork)
        {
            return this.LogicalDeleteProc(ref objectsAndEGoodsCdChgWork, 0);
        }

        /// <summary>
        /// ���i�R�[�h�ϊ��}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="objectsAndEGoodsCdChgWork">�_���폜���������鏤�i�R�[�h�ϊ��}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEGoodsCdChgWork �Ɋi�[����Ă��鏤�i�R�[�h�ϊ��}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        public int RevivalLogicalDelete(ref object objectsAndEGoodsCdChgWork)
        {
            return this.LogicalDeleteProc(ref objectsAndEGoodsCdChgWork, 1);
        }

        /// <summary>
        /// ���i�R�[�h�ϊ��}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="objectsAndEGoodsCdChgWork">�_���폜�𑀍삷�鏤�i�R�[�h�ϊ��}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEGoodsCdChgWork �Ɋi�[����Ă��鏤�i�R�[�h�ϊ��}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        private int LogicalDeleteProc(ref object objectsAndEGoodsCdChgWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SAndEGoodsCdChgWork paraList = objectsAndEGoodsCdChgWork as SAndEGoodsCdChgWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                objectsAndEGoodsCdChgWork = paraList;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEGoodsCdChgSetDB.LogicalDelete(ref object, int[" + procMode.ToString() + "])", status);
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
        /// ���i�R�[�h�ϊ��}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="sAndEGoodsCdChgWork">�_���폜�𑀍삷�鏤�i�R�[�h�ϊ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEGoodsCdChgWork �Ɋi�[����Ă��鏤�i�R�[�h�ϊ��}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        public int LogicalDelete(ref SAndEGoodsCdChgWork sAndEGoodsCdChgWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref sAndEGoodsCdChgWork, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i�R�[�h�ϊ��}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="sAndEGoodsCdChgWork">�_���폜�𑀍삷�鏤�i�R�[�h�ϊ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEGoodsCdChgWork �Ɋi�[����Ă��鏤�i�R�[�h�ϊ��}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        private int LogicalDeleteProc(ref SAndEGoodsCdChgWork sAndEGoodsCdChgWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (sAndEGoodsCdChgWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "SANDEGOODSCDCHGRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND BLGOODSCODERF = @FINDBLGOODSCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEGoodsCdChgWork.EnterpriseCode);
                    findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(sAndEGoodsCdChgWork.BLGoodsCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != sAndEGoodsCdChgWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // ���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        # region [UPDATE��]
                        sqlText = string.Empty;
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  SANDEGOODSCDCHGRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND BLGOODSCODERF = @FINDBLGOODSCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEGoodsCdChgWork.EnterpriseCode);
                        findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(sAndEGoodsCdChgWork.BLGoodsCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndEGoodsCdChgWork;
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
                        else if (logicalDelCd == 0) sAndEGoodsCdChgWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                        else sAndEGoodsCdChgWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            sAndEGoodsCdChgWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndEGoodsCdChgWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sAndEGoodsCdChgWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sAndEGoodsCdChgWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sAndEGoodsCdChgWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sAndEGoodsCdChgWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                    al.Add(sAndEGoodsCdChgWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "SAndEGoodsCdChgSetDB.LogicalDelete(ref SAndEGoodsCdChgWork, ref SqlConnection, ref SqlTransaction)", status);
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

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="sAndEGoodsCdChgWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SAndEGoodsCdChgWork sAndEGoodsCdChgWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // ��ƃR�[�h
            retstring += "  A.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEGoodsCdChgWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND A.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND A.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            retstring += " ORDER BY" + Environment.NewLine;
            retstring += " A.BLGOODSCODERF" + Environment.NewLine;

            return retstring;
        }

        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SAndEGoodsCdChgWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SAndEGoodsCdChgWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        private SAndEGoodsCdChgWork CopyToSAndEGoodsCdChgWorkFromReader(ref SqlDataReader myReader)
        {
            SAndEGoodsCdChgWork sAndEGoodsCdChgWork = new SAndEGoodsCdChgWork();

            this.CopyToSAndEGoodsCdChgWorkFromReader(ref myReader, ref sAndEGoodsCdChgWork);

            return sAndEGoodsCdChgWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� SAndEGoodsCdChgWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="sAndEGoodsCdChgWork">SAndEGoodsCdChgWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        private void CopyToSAndEGoodsCdChgWorkFromReader(ref SqlDataReader myReader, ref SAndEGoodsCdChgWork sAndEGoodsCdChgWork)
        {
            if (myReader != null && sAndEGoodsCdChgWork != null)
            {
                # region �N���X�֊i�[
                sAndEGoodsCdChgWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                sAndEGoodsCdChgWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                sAndEGoodsCdChgWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                sAndEGoodsCdChgWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                sAndEGoodsCdChgWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                sAndEGoodsCdChgWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                sAndEGoodsCdChgWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                sAndEGoodsCdChgWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                sAndEGoodsCdChgWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                sAndEGoodsCdChgWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                sAndEGoodsCdChgWork.ABGoodsCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ABGOODSCODERF"));
                # endregion
            }
        }

        # endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            //SqlConnection����
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            //SqlConnection�ڑ�
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            //SqlConnection�Ԃ�
            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
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
