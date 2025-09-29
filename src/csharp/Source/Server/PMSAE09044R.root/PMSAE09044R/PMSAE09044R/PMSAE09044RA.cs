//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�����e�i���X
// �v���O�����T�v   : ���i�R�[�h�ϊ��̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���c�`�[
// �� �� ��  2020/02/20  �C�����e : �V�K�쐬
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
    /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���c�`�[</br>
    /// <br>Date       : 2020.02.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SAndEMkrGdsCdChgSetDB : RemoteDB, ISAndEMkrGdsCdChgSetDB
    {
        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        public SAndEMkrGdsCdChgSetDB()
            : base("PMSAE09046D", "Broadleaf.Application.Remoting.ParamData.SAndEMkrGdsCdChgWork", "SANDEMKRGDSCDCHGSET")
        {

        }

        # region [Delete]
        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="objectSAndEMkrGdsCdChgWork">SAndEMkrGdsCdChgWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�̃L�[�l����v���郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        public int Delete(ref object objectSAndEMkrGdsCdChgWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // XML�̓ǂݍ���
                SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = objectSAndEMkrGdsCdChgWork as SAndEMkrGdsCdChgWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(ref sAndEMkrGdsCdChgWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEMkrGdsCdChgSetDB.Delete(object)", status);
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
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgWork">���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork �Ɋi�[����Ă��郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        public int Delete(ref SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(ref sAndEMkrGdsCdChgWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgWork">���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork �Ɋi�[����Ă��郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        private int DeleteProc(ref SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (sAndEMkrGdsCdChgWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SANDEMKRGDSCDCHGRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.EnterpriseCode);
                    findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.GoodsMakerCd);
                    findGoodsNo.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != sAndEMkrGdsCdChgWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        # region [DELETE��]
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  SANDEMKRGDSCDCHGRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.EnterpriseCode);
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.GoodsMakerCd);
                        findGoodsNo.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.GoodsNo);
                    
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
                status = base.WriteSQLErrorLog(sqlex, "SAndEMkrGdsCdChgSetDB.DeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEMkrGdsCdChgSetDB.DeleteProc" , status);
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
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outSAndEMkrGdsCdChgWorkList">��������</param>
        /// <param name="paraSAndEMkrGdsCdChgSetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�̃L�[�l����v����A�S�Ẵ��[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        public int Search(out object outSAndEMkrGdsCdChgWorkList, object paraSAndEMkrGdsCdChgSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _sAndEMkrGdsCdChgList = null;
            SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = null;

            outSAndEMkrGdsCdChgWorkList = new CustomSerializeArrayList();

            try
            {
                if (paraSAndEMkrGdsCdChgSetWork is SAndEMkrGdsCdChgWork)
                {
                    sAndEMkrGdsCdChgWork = paraSAndEMkrGdsCdChgSetWork as SAndEMkrGdsCdChgWork;
                }
                else if (paraSAndEMkrGdsCdChgSetWork is ArrayList)
                {
                    if ((paraSAndEMkrGdsCdChgSetWork as ArrayList).Count > 0)
                    {
                        sAndEMkrGdsCdChgWork = (paraSAndEMkrGdsCdChgSetWork as ArrayList)[0] as SAndEMkrGdsCdChgWork;
                    }
                }

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(out _sAndEMkrGdsCdChgList, sAndEMkrGdsCdChgWork, readMode, logicalMode, ref sqlConnection);

                if (_sAndEMkrGdsCdChgList != null)
                {
                    (outSAndEMkrGdsCdChgWorkList as CustomSerializeArrayList).AddRange(_sAndEMkrGdsCdChgList);
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEMkrGdsCdChgSetDB.Search(out object, object, int, LogicalMode)", status);
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
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgList">���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sAndEMkrGdsCdChgWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�̃L�[�l����v����A�S�Ẵ��[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        public int Search(out ArrayList sAndEMkrGdsCdChgList, SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchProc(out sAndEMkrGdsCdChgList, sAndEMkrGdsCdChgWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgList">���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sAndEMkrGdsCdChgWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�̃L�[�l����v����A�S�Ẵ��[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        private int SearchProc(out ArrayList sAndEMkrGdsCdChgList, SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
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
                sqlText += " ,A.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " ,A.GOODSNORF" + Environment.NewLine;
                sqlText += " ,A.ABGOODSCODERF" + Environment.NewLine;
                sqlText += " ,B.MAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM SANDEMKRGDSCDCHGRF AS A" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF AS B" + Environment.NewLine;
                sqlText += " ON A.GOODSMAKERCDRF = B.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND A.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND B.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, sAndEMkrGdsCdChgWork, logicalMode);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToSAndEMkrGdsCdChgWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "SAndEMkrGdsCdChgSetDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEMkrGdsCdChgSetDB.SearchProc" , status);
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

            sAndEMkrGdsCdChgList = al;

            return status;

        }

        # endregion

        # region [Write]
        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="outSAndEMkrGdsCdChgWork">�ǉ��E�X�V���郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���</param>
        /// <param name="writeMode">�X�V�敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : outSAndEMkrGdsCdChgWorkList �Ɋi�[����Ă��郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        public int Write(ref object outSAndEMkrGdsCdChgWork, int writeMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                SAndEMkrGdsCdChgWork wkSAndEMkrGdsCdChgWork = outSAndEMkrGdsCdChgWork as SAndEMkrGdsCdChgWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = this.Write(ref wkSAndEMkrGdsCdChgWork, ref sqlConnection, ref sqlTransaction);

                // �߂�l�Z�b�g
                outSAndEMkrGdsCdChgWork = wkSAndEMkrGdsCdChgWork;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEMkrGdsCdChgSetDB.Write(ref object)", status);
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
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgWork">�ǉ��E�X�V���郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�����i�[����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork �Ɋi�[����Ă��郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        public int Write(ref SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref sAndEMkrGdsCdChgWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgWork">�ǉ��E�X�V���郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork �Ɋi�[����Ă��郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        private int WriteProc(ref SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (sAndEMkrGdsCdChgWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SANDEMKRGDSCDCHGRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += " AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    
                    sqlCommand.CommandText = sqlText;
                    # endregion
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                  
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.EnterpriseCode);
                    findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.GoodsMakerCd);
                    findGoodsNo.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != sAndEMkrGdsCdChgWork.UpdateDateTime)
                        {
                            if (sAndEMkrGdsCdChgWork.UpdateDateTime == DateTime.MinValue)
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
                        sqlText += "  SANDEMKRGDSCDCHGRF" + Environment.NewLine;
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
                        sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                        
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.EnterpriseCode);
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.GoodsMakerCd);
                        findGoodsNo.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.GoodsNo);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndEMkrGdsCdChgWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (sAndEMkrGdsCdChgWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT��]
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO SANDEMKRGDSCDCHGRF" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlText += " ,GOODSNORF" + Environment.NewLine;
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
                        sqlText += " ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlText += " ,@GOODSNO" + Environment.NewLine;
                        sqlText += " ,@ABGOODSCODE" + Environment.NewLine;
                        sqlText += ")" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndEMkrGdsCdChgWork;
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
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                    SqlParameter paraAbgoodsCode = sqlCommand.Parameters.Add("@ABGOODSCODE", SqlDbType.NChar);
                    # endregion

                    # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndEMkrGdsCdChgWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndEMkrGdsCdChgWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(sAndEMkrGdsCdChgWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.LogicalDeleteCode);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.GoodsMakerCd);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.GoodsNo);
                    paraAbgoodsCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.ABGoodsCode);

                    # endregion

                    sqlCommand.ExecuteNonQuery();

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SAndEMkrGdsCdChgSetDB.Write", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEMkrGdsCdChgSetDB.Write" , status);
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
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="objectSAndEMkrGdsCdChgWork">�_���폜���郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork �Ɋi�[����Ă��郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        public int LogicalDelete(ref object objectSAndEMkrGdsCdChgWork)
        {
            return this.LogicalDeleteProc(ref objectSAndEMkrGdsCdChgWork, 0);
        }

        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="objectSAndEMkrGdsCdChgWork">�_���폜���������郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork �Ɋi�[����Ă��郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        public int RevivalLogicalDelete(ref object objectSAndEMkrGdsCdChgWork)
        {
            return this.LogicalDeleteProc(ref objectSAndEMkrGdsCdChgWork, 1);
        }

        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="objectSAndEMkrGdsCdChgWork">�_���폜�𑀍삷�郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork �Ɋi�[����Ă��郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        private int LogicalDeleteProc(ref object objectSAndEMkrGdsCdChgWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SAndEMkrGdsCdChgWork paraList = objectSAndEMkrGdsCdChgWork as SAndEMkrGdsCdChgWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                objectSAndEMkrGdsCdChgWork = paraList;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEMkrGdsCdChgSetDB.LogicalDelete(ref object, int[" + procMode.ToString() + "])", status);
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
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgWork">�_���폜�𑀍삷�郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork �Ɋi�[����Ă��郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        public int LogicalDelete(ref SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref sAndEMkrGdsCdChgWork, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgWork">�_���폜�𑀍삷�郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork �Ɋi�[����Ă��郁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        private int LogicalDeleteProc(ref SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (sAndEMkrGdsCdChgWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "SANDEMKRGDSCDCHGRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.EnterpriseCode);
                    findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.GoodsMakerCd);
                    findGoodsNo.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != sAndEMkrGdsCdChgWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // ���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        # region [UPDATE��]
                        sqlText = string.Empty;
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  SANDEMKRGDSCDCHGRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.EnterpriseCode);
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.GoodsMakerCd);
                        findGoodsNo.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.GoodsNo);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndEMkrGdsCdChgWork;
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
                        else if (logicalDelCd == 0) sAndEMkrGdsCdChgWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                        else sAndEMkrGdsCdChgWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            sAndEMkrGdsCdChgWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndEMkrGdsCdChgWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                    al.Add(sAndEMkrGdsCdChgWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "SAndEMkrGdsCdChgSetDB.LogicalDelete(ref SAndEMkrGdsCdChgWork, ref SqlConnection, ref SqlTransaction)", status);
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
        /// <param name="sAndEMkrGdsCdChgWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // ��ƃR�[�h
            retstring += "  A.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.EnterpriseCode);

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
            retstring += "  A.GOODSMAKERCDRF" + Environment.NewLine;
            retstring += " ,A.GOODSNORF" + Environment.NewLine;

            return retstring;
        }

        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SAndEMkrGdsCdChgWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SAndEMkrGdsCdChgWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private SAndEMkrGdsCdChgWork CopyToSAndEMkrGdsCdChgWorkFromReader(ref SqlDataReader myReader)
        {
            SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = new SAndEMkrGdsCdChgWork();

            this.CopyToSAndEMkrGdsCdChgWorkFromReader(ref myReader, ref sAndEMkrGdsCdChgWork);

            return sAndEMkrGdsCdChgWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� SAndEMkrGdsCdChgWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="sAndEMkrGdsCdChgWork">SAndEMkrGdsCdChgWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private void CopyToSAndEMkrGdsCdChgWorkFromReader(ref SqlDataReader myReader, ref SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork)
        {
            if (myReader != null && sAndEMkrGdsCdChgWork != null)
            {
                # region �N���X�֊i�[
                sAndEMkrGdsCdChgWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                sAndEMkrGdsCdChgWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                sAndEMkrGdsCdChgWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                sAndEMkrGdsCdChgWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                sAndEMkrGdsCdChgWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                sAndEMkrGdsCdChgWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                sAndEMkrGdsCdChgWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                sAndEMkrGdsCdChgWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                sAndEMkrGdsCdChgWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                sAndEMkrGdsCdChgWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                sAndEMkrGdsCdChgWork.ABGoodsCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ABGOODSCODERF"));
                sAndEMkrGdsCdChgWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
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
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
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
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
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
