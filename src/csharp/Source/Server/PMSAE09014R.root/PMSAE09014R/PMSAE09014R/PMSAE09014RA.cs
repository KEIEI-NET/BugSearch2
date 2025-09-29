//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �I�[�g�o�b�N�X�ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �I�[�g�o�b�N�X�ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/08/03  �C�����e : �V�K�쐬
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
    /// �I�[�g�o�b�N�X�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.08.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SAndESettingDB : RemoteDB, ISAndESettingDB
    {
        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        public SAndESettingDB()
            : base("PMSAE09016D", "Broadleaf.Application.Remoting.ParamData.SAndESettingWork", "SANDESETTING")
        {

        }

        # region [Delete]
        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">SAndESettingWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        public int Delete(ref object parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {

                SAndESettingWork sAndESettingWork = parabyte as SAndESettingWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.DeleteProc(ref sAndESettingWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException sqex)
            {
                status = base.WriteSQLErrorLog(sqex, "SAndESettingDB.Delete", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndESettingDB.Delete", status);
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
        /// �I�[�g�o�b�N�X�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="sAndESettingWork">�I�[�g�o�b�N�X�ݒ�}�X�^��� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        private int DeleteProc(ref SAndESettingWork sAndESettingWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (sAndESettingWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText = "SELECT UPDATEDATETIMERF FROM SANDESETTINGRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.SectionCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != sAndESettingWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        # region [DELETE��]
                        sqlText = "DELETE FROM SANDESETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.CustomerCode);

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
                status = base.WriteSQLErrorLog(sqlex, "SAndESettingDB.Delete", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndESettingDB.DeleteProc", status);
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
        /// �I�[�g�o�b�N�X�ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outSAndESettingList">��������</param>
        /// <param name="paraSAndESettingWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        public int Search(out object outSAndESettingList, object paraSAndESettingWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _sAndESettingList = null;
            SAndESettingWork sAndESettingWork = null;

            outSAndESettingList = new CustomSerializeArrayList();

            try
            {
                sAndESettingWork = paraSAndESettingWork as SAndESettingWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // ����
                status = this.SearchProc(out _sAndESettingList, sAndESettingWork, readMode, logicalMode, ref sqlConnection);

                if (_sAndESettingList != null)
                {
                    (outSAndESettingList as CustomSerializeArrayList).AddRange(_sAndESettingList);
                }

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SAndESettingDB.Search", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndESettingDB.Search", status);
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
        /// �I�[�g�o�b�N�X�ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="sAndESettingList">��������</param>
        /// <param name="sAndESettingWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        private int SearchProc(out ArrayList sAndESettingList, SAndESettingWork sAndESettingWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                StringBuilder sqlText = new StringBuilder();
                // �R�l�N�V��������
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT��]
                sqlText.Append(" SELECT ");
                sqlText.Append(" A.CREATEDATETIMERF, ");      // �쐬����
                sqlText.Append(" A.ENTERPRISECODERF, ");      // ��ƃR�[�h
                sqlText.Append(" A.FILEHEADERGUIDRF, ");      // GUID
                sqlText.Append(" A.UPDEMPLOYEECODERF, ");     // �X�V�]�ƈ��R�[�h
                sqlText.Append(" A.UPDASSEMBLYID1RF, ");      // �X�V�A�Z���u��ID1
                sqlText.Append(" A.UPDASSEMBLYID2RF, ");      // �X�V�A�Z���u��ID2
                sqlText.Append(" A.UPDATEDATETIMERF, ");      // �X�V����
                sqlText.Append(" A.LOGICALDELETECODERF, ");   // �_���폜�敪
                sqlText.Append(" A.SECTIONCODERF, ");         // ���_�R�[�h
                sqlText.Append(" A.CUSTOMERCODERF, ");        // ���Ӑ�R�[�h
                sqlText.Append(" A.ADDRESSEESHOPCDRF, ");     // �[�i��X�܃R�[�h
                sqlText.Append(" A.SANDEMNGCODERF, ");        // �Z�d�Ǘ��R�[�h
                sqlText.Append(" A.EXPENSEDIVCDRF,");         // �o��敪
                sqlText.Append(" A.DIRECTSENDINGCDRF, ");     // �����敪
                sqlText.Append(" A.ACPTANORDERDIVRF, ");      // �󒍋敪
                sqlText.Append(" A.DELIVERERCDRF, ");         // �[�i�҃R�[�h
                sqlText.Append(" A.DELIVERERNMRF, ");         // �[�i�Җ�
                sqlText.Append(" A.DELIVERERADDRESSRF, ");    // �[�i�ҏZ��
                sqlText.Append(" A.DELIVERERPHONENUMRF, ");   // �[�i�҂s�d�k
                sqlText.Append(" A.TRADCOMPNAMERF, ");        // ���i����
                sqlText.Append(" A.TRADCOMPSECTNAMERF, ");    // ���i�����_��
                sqlText.Append(" A.PURETRADCOMPCDRF, ");      // ���i���R�[�h�i�����j
                sqlText.Append(" A.PURETRADCOMPRATERF, ");    // ���i���d�ؗ��i�����j
                sqlText.Append(" A.PRITRADCOMPCDRF, ");       // ���i���R�[�h�i�D�ǁj
                sqlText.Append(" A.PRITRADCOMPRATERF, ");     // ���i���d�ؗ��i�D�ǁj
                sqlText.Append(" A.ABGOODSCODERF, ");         // AB���i�R�[�h
                sqlText.Append(" A.COMMENTRESERVEDDIVRF, ");  // �R�����g�w��敪
                sqlText.Append(" A.GOODSMAKERCD1RF, ");       // ���i���[�J�[�R�[�h�P
                sqlText.Append(" A.GOODSMAKERCD2RF, ");       // ���i���[�J�[�R�[�h�Q
                sqlText.Append(" A.GOODSMAKERCD3RF, ");       // ���i���[�J�[�R�[�h�R
                sqlText.Append(" A.GOODSMAKERCD4RF, ");       // ���i���[�J�[�R�[�h�S
                sqlText.Append(" A.GOODSMAKERCD5RF, ");       // ���i���[�J�[�R�[�h�T
                sqlText.Append(" A.GOODSMAKERCD6RF, ");       // ���i���[�J�[�R�[�h�U
                sqlText.Append(" A.GOODSMAKERCD7RF, ");       // ���i���[�J�[�R�[�h�V
                sqlText.Append(" A.GOODSMAKERCD8RF, ");       // ���i���[�J�[�R�[�h�W
                sqlText.Append(" A.GOODSMAKERCD9RF, ");       // ���i���[�J�[�R�[�h�X
                sqlText.Append(" A.GOODSMAKERCD10RF, ");      // ���i���[�J�[�R�[�h�P�O
                sqlText.Append(" A.GOODSMAKERCD11RF, ");      // ���i���[�J�[�R�[�h�P�P
                sqlText.Append(" A.GOODSMAKERCD12RF, ");      // ���i���[�J�[�R�[�h�P�Q
                sqlText.Append(" A.GOODSMAKERCD13RF, ");      // ���i���[�J�[�R�[�h�P�R
                sqlText.Append(" A.GOODSMAKERCD14RF, ");      // ���i���[�J�[�R�[�h�P�S
                sqlText.Append(" A.GOODSMAKERCD15RF, ");      // ���i���[�J�[�R�[�h�P�T
                sqlText.Append(" A.PARTSOEMDIVRF, ");         // ���i�n�d�l�敪
                sqlText.Append(" B.SECTIONGUIDENMRF, ");      // ���_�K�C�h����
                sqlText.Append(" C.CUSTOMERSNMRF ");          // ���Ӑ旪��
                sqlText.Append(" FROM SANDESETTINGRF A WITH (READUNCOMMITTED) ");        // �I�[�g�o�b�N�X�ݒ�}�X�^
                sqlText.Append(" LEFT JOIN  SECINFOSETRF B WITH (READUNCOMMITTED) ON "); // ���_���ݒ�}�X�^
                sqlText.Append(" (A.ENTERPRISECODERF= B.ENTERPRISECODERF ");
                sqlText.Append(" AND B.LOGICALDELETECODERF = 0 ");
                sqlText.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF) ");
                sqlText.Append(" LEFT JOIN  CUSTOMERRF C WITH (READUNCOMMITTED) ON ");
                sqlText.Append(" (A.ENTERPRISECODERF= C.ENTERPRISECODERF ");
                sqlText.Append(" AND A.CUSTOMERCODERF = C.CUSTOMERCODERF ");
                sqlText.Append(" AND C.LOGICALDELETECODERF = 0) ");
                sqlCommand.CommandText += sqlText.ToString();
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, sAndESettingWork, logicalMode);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToSAndESettingWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "SAndESettingDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndESettingDB.SearchProc", status);
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

            sAndESettingList = al;

            return status;

        }

        # endregion

        #region [write]
        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="sAndESettingWork">�I�[�g�o�b�N�X�ݒ�}�X�^���</param>
        /// <param name="writeMode">�X�V�敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        public int Write(ref object sAndESettingWork, int writeMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                SAndESettingWork wksAndESettingWork = sAndESettingWork as SAndESettingWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = WriteProc(ref wksAndESettingWork, ref sqlConnection, ref sqlTransaction);

                // �߂�l�Z�b�g
                sAndESettingWork = wksAndESettingWork;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SAndESettingDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndESettingDB.Write", status);
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
        /// �I�[�g�o�b�N�X�ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="sAndESettingWork">�ǉ��E�X�V����I�[�g�o�b�N�X�ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sAndESettingWork �Ɋi�[����Ă���I�[�g�o�b�N�X�ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        private int WriteProc(ref SAndESettingWork sAndESettingWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            SAndESettingWork al = new SAndESettingWork();

            try
            {
                if (sAndESettingWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText = "SELECT UPDATEDATETIMERF FROM SANDESETTINGRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.SectionCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != sAndESettingWork.UpdateDateTime)
                        {
                            if (sAndESettingWork.UpdateDateTime == DateTime.MinValue)
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
                        sqlText = "UPDATE SANDESETTINGRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , CUSTOMERCODERF=@CUSTOMERCODE , ADDRESSEESHOPCDRF=@ADDRESSEESHOPCD , SANDEMNGCODERF=@SANDEMNGCODE , EXPENSEDIVCDRF=@EXPENSEDIVCD , DIRECTSENDINGCDRF=@DIRECTSENDINGCD , ACPTANORDERDIVRF=@ACPTANORDERDIV , DELIVERERCDRF=@DELIVERERCD , DELIVERERNMRF=@DELIVERERNM , DELIVERERADDRESSRF=@DELIVERERADDRESS , DELIVERERPHONENUMRF=@DELIVERERPHONENUM , TRADCOMPNAMERF=@TRADCOMPNAME , TRADCOMPSECTNAMERF=@TRADCOMPSECTNAME , PURETRADCOMPCDRF=@PURETRADCOMPCD , PURETRADCOMPRATERF=@PURETRADCOMPRATE , PRITRADCOMPCDRF=@PRITRADCOMPCD , PRITRADCOMPRATERF=@PRITRADCOMPRATE , ABGOODSCODERF=@ABGOODSCODE , COMMENTRESERVEDDIVRF=@COMMENTRESERVEDDIV , GOODSMAKERCD1RF=@GOODSMAKERCD1 , GOODSMAKERCD2RF=@GOODSMAKERCD2 , GOODSMAKERCD3RF=@GOODSMAKERCD3 , GOODSMAKERCD4RF=@GOODSMAKERCD4 , GOODSMAKERCD5RF=@GOODSMAKERCD5 , GOODSMAKERCD6RF=@GOODSMAKERCD6 , GOODSMAKERCD7RF=@GOODSMAKERCD7 , GOODSMAKERCD8RF=@GOODSMAKERCD8 , GOODSMAKERCD9RF=@GOODSMAKERCD9 , GOODSMAKERCD10RF=@GOODSMAKERCD10 , GOODSMAKERCD11RF=@GOODSMAKERCD11 , GOODSMAKERCD12RF=@GOODSMAKERCD12 , GOODSMAKERCD13RF=@GOODSMAKERCD13 , GOODSMAKERCD14RF=@GOODSMAKERCD14 , GOODSMAKERCD15RF=@GOODSMAKERCD15 , PARTSOEMDIVRF=@PARTSOEMDIV WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.CustomerCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndESettingWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (sAndESettingWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT��]
                        sqlText = "INSERT INTO SANDESETTINGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CUSTOMERCODERF, ADDRESSEESHOPCDRF, SANDEMNGCODERF, EXPENSEDIVCDRF, DIRECTSENDINGCDRF, ACPTANORDERDIVRF, DELIVERERCDRF, DELIVERERNMRF, DELIVERERADDRESSRF, DELIVERERPHONENUMRF, TRADCOMPNAMERF, TRADCOMPSECTNAMERF, PURETRADCOMPCDRF, PURETRADCOMPRATERF, PRITRADCOMPCDRF, PRITRADCOMPRATERF, ABGOODSCODERF, COMMENTRESERVEDDIVRF, GOODSMAKERCD1RF, GOODSMAKERCD2RF, GOODSMAKERCD3RF, GOODSMAKERCD4RF, GOODSMAKERCD5RF, GOODSMAKERCD6RF, GOODSMAKERCD7RF, GOODSMAKERCD8RF, GOODSMAKERCD9RF, GOODSMAKERCD10RF, GOODSMAKERCD11RF, GOODSMAKERCD12RF, GOODSMAKERCD13RF, GOODSMAKERCD14RF, GOODSMAKERCD15RF, PARTSOEMDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @CUSTOMERCODE, @ADDRESSEESHOPCD, @SANDEMNGCODE, @EXPENSEDIVCD, @DIRECTSENDINGCD, @ACPTANORDERDIV, @DELIVERERCD, @DELIVERERNM, @DELIVERERADDRESS, @DELIVERERPHONENUM, @TRADCOMPNAME, @TRADCOMPSECTNAME, @PURETRADCOMPCD, @PURETRADCOMPRATE, @PRITRADCOMPCD, @PRITRADCOMPRATE, @ABGOODSCODE, @COMMENTRESERVEDDIV, @GOODSMAKERCD1, @GOODSMAKERCD2, @GOODSMAKERCD3, @GOODSMAKERCD4, @GOODSMAKERCD5, @GOODSMAKERCD6, @GOODSMAKERCD7, @GOODSMAKERCD8, @GOODSMAKERCD9, @GOODSMAKERCD10, @GOODSMAKERCD11, @GOODSMAKERCD12, @GOODSMAKERCD13, @GOODSMAKERCD14, @GOODSMAKERCD15, @PARTSOEMDIV)";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndESettingWork;
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
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraAddresseeShopCd = sqlCommand.Parameters.Add("@ADDRESSEESHOPCD", SqlDbType.NVarChar);
                    SqlParameter paraSAndEMngCode = sqlCommand.Parameters.Add("@SANDEMNGCODE", SqlDbType.NVarChar);
                    SqlParameter paraExpenseDivCd = sqlCommand.Parameters.Add("@EXPENSEDIVCD", SqlDbType.Int);
                    SqlParameter paraDirectSendingCd = sqlCommand.Parameters.Add("@DIRECTSENDINGCD", SqlDbType.Int);
                    SqlParameter paraAcptAnOrderDiv = sqlCommand.Parameters.Add("@ACPTANORDERDIV", SqlDbType.Int);
                    SqlParameter paraDelivererCd = sqlCommand.Parameters.Add("@DELIVERERCD", SqlDbType.NVarChar);
                    SqlParameter paraDelivererNm = sqlCommand.Parameters.Add("@DELIVERERNM", SqlDbType.NVarChar);
                    SqlParameter paraDelivererAddress = sqlCommand.Parameters.Add("@DELIVERERADDRESS", SqlDbType.NVarChar);
                    SqlParameter paraDelivererPhoneNum = sqlCommand.Parameters.Add("@DELIVERERPHONENUM", SqlDbType.NVarChar);
                    SqlParameter paraTradCompName = sqlCommand.Parameters.Add("@TRADCOMPNAME", SqlDbType.NVarChar);
                    SqlParameter paraTradCompSectName = sqlCommand.Parameters.Add("@TRADCOMPSECTNAME", SqlDbType.NVarChar);
                    SqlParameter paraPureTradCompCd = sqlCommand.Parameters.Add("@PURETRADCOMPCD", SqlDbType.NVarChar);
                    SqlParameter paraPureTradCompRate = sqlCommand.Parameters.Add("@PURETRADCOMPRATE", SqlDbType.Float);
                    SqlParameter paraPriTradCompCd = sqlCommand.Parameters.Add("@PRITRADCOMPCD", SqlDbType.NVarChar);
                    SqlParameter paraPriTradCompRate = sqlCommand.Parameters.Add("@PRITRADCOMPRATE", SqlDbType.Float);
                    SqlParameter paraABGoodsCode = sqlCommand.Parameters.Add("@ABGOODSCODE", SqlDbType.NVarChar);
                    SqlParameter paraCommentReservedDiv = sqlCommand.Parameters.Add("@COMMENTRESERVEDDIV", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd1 = sqlCommand.Parameters.Add("@GOODSMAKERCD1", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd2 = sqlCommand.Parameters.Add("@GOODSMAKERCD2", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd3 = sqlCommand.Parameters.Add("@GOODSMAKERCD3", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd4 = sqlCommand.Parameters.Add("@GOODSMAKERCD4", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd5 = sqlCommand.Parameters.Add("@GOODSMAKERCD5", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd6 = sqlCommand.Parameters.Add("@GOODSMAKERCD6", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd7 = sqlCommand.Parameters.Add("@GOODSMAKERCD7", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd8 = sqlCommand.Parameters.Add("@GOODSMAKERCD8", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd9 = sqlCommand.Parameters.Add("@GOODSMAKERCD9", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd10 = sqlCommand.Parameters.Add("@GOODSMAKERCD10", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd11 = sqlCommand.Parameters.Add("@GOODSMAKERCD11", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd12 = sqlCommand.Parameters.Add("@GOODSMAKERCD12", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd13 = sqlCommand.Parameters.Add("@GOODSMAKERCD13", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd14 = sqlCommand.Parameters.Add("@GOODSMAKERCD14", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd15 = sqlCommand.Parameters.Add("@GOODSMAKERCD15", SqlDbType.Int);
                    SqlParameter paraPartsOEMDiv = sqlCommand.Parameters.Add("@PARTSOEMDIV", SqlDbType.Int);
                    # endregion

                    # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndESettingWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndESettingWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(sAndESettingWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sAndESettingWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sAndESettingWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.SectionCode);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.CustomerCode);
                    paraAddresseeShopCd.Value = SqlDataMediator.SqlSetString(sAndESettingWork.AddresseeShopCd);
                    paraSAndEMngCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.SAndEMngCode);
                    paraExpenseDivCd.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.ExpenseDivCd);
                    paraDirectSendingCd.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.DirectSendingCd);
                    paraAcptAnOrderDiv.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.AcptAnOrderDiv);
                    paraDelivererCd.Value = SqlDataMediator.SqlSetString(sAndESettingWork.DelivererCd);
                    paraDelivererNm.Value = SqlDataMediator.SqlSetString(sAndESettingWork.DelivererNm);
                    paraDelivererAddress.Value = SqlDataMediator.SqlSetString(sAndESettingWork.DelivererAddress);
                    paraDelivererPhoneNum.Value = SqlDataMediator.SqlSetString(sAndESettingWork.DelivererPhoneNum);
                    paraTradCompName.Value = SqlDataMediator.SqlSetString(sAndESettingWork.TradCompName);
                    paraTradCompSectName.Value = SqlDataMediator.SqlSetString(sAndESettingWork.TradCompSectName);
                    paraPureTradCompCd.Value = SqlDataMediator.SqlSetString(sAndESettingWork.PureTradCompCd);
                    paraPureTradCompRate.Value = SqlDataMediator.SqlSetDouble(sAndESettingWork.PureTradCompRate);
                    paraPriTradCompCd.Value = SqlDataMediator.SqlSetString(sAndESettingWork.PriTradCompCd);
                    paraPriTradCompRate.Value = SqlDataMediator.SqlSetDouble(sAndESettingWork.PriTradCompRate);
                    paraABGoodsCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.ABGoodsCode);
                    paraCommentReservedDiv.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.CommentReservedDiv);
                    paraGoodsMakerCd1.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd1);
                    paraGoodsMakerCd2.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd2);
                    paraGoodsMakerCd3.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd3);
                    paraGoodsMakerCd4.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd4);
                    paraGoodsMakerCd5.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd5);
                    paraGoodsMakerCd6.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd6);
                    paraGoodsMakerCd7.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd7);
                    paraGoodsMakerCd8.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd8);
                    paraGoodsMakerCd9.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd9);
                    paraGoodsMakerCd10.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd10);
                    paraGoodsMakerCd11.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd11);
                    paraGoodsMakerCd12.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd12);
                    paraGoodsMakerCd13.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd13);
                    paraGoodsMakerCd14.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd14);
                    paraGoodsMakerCd15.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd15);
                    paraPartsOEMDiv.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.PartsOEMDiv);

                    # endregion

                    sqlCommand.ExecuteNonQuery();
                    al = sAndESettingWork;

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SAndESettingDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndESettingDB.WriteProc", status);
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

            sAndESettingWork = al;

            return status;
        }

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="sAndESettingWork">�_���폜����I�[�g�o�b�N�X�ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        public int LogicalDelete(ref object sAndESettingWork)
        {
            return this.LogicalDeleteProc(ref sAndESettingWork, 0);
        }

        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="sAndESettingWork">�_���폜����������I�[�g�o�b�N�X�ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        public int RevivalLogicalDelete(ref object sAndESettingWork)
        {
            return this.LogicalDeleteProc(ref sAndESettingWork, 1);
        }

        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="sAndESettingWork">�_���폜�𑀍삷��I�[�g�o�b�N�X�ݒ�}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        private int LogicalDeleteProc(ref object sAndESettingWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SAndESettingWork paraList = sAndESettingWork as SAndESettingWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDeleteProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                sAndESettingWork = paraList;

            }
            catch (SqlException sqex)
            {
                status = base.WriteSQLErrorLog(sqex, "SAndESettingDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndESettingDB.LogicalDeleteProc", status);
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
        /// �I�[�g�o�b�N�X�ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="sAndESettingWork">�_���폜�𑀍삷��I�[�g�o�b�N�X�ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        private int LogicalDeleteProc(ref SAndESettingWork sAndESettingWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (sAndESettingWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText = "SELECT UPDATEDATETIMERF,LOGICALDELETECODERF FROM SANDESETTINGRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.SectionCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.CustomerCode);


                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != sAndESettingWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // ���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        # region [UPDATE��]
                        sqlText = "UPDATE SANDESETTINGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.CustomerCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndESettingWork;
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
                        else if (logicalDelCd == 0) sAndESettingWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                        else sAndESettingWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            sAndESettingWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndESettingWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sAndESettingWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sAndESettingWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                    al.Add(sAndESettingWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqex, "SAndESettingDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndESettingDB.DeleteProc", status);
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
        #endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="sAndESettingWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SAndESettingWork sAndESettingWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // ��ƃR�[�h
            retstring += " A.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.EnterpriseCode);

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

            retstring += " ORDER BY " + Environment.NewLine;
            retstring += " A.SECTIONCODERF," + Environment.NewLine;
            retstring += " A.CUSTOMERCODERF" + Environment.NewLine;
            return retstring;
        }

        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SAndESettingWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SupplierWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private SAndESettingWork CopyToSAndESettingWorkFromReader(ref SqlDataReader myReader)
        {
            SAndESettingWork sAndESettingWork = new SAndESettingWork();

            this.CopyToSAndESettingWorkFromReader(ref myReader, ref sAndESettingWork);

            return sAndESettingWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� SAndESettingWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="sAndESettingWork">sAndESettingWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private void CopyToSAndESettingWorkFromReader(ref SqlDataReader myReader, ref SAndESettingWork sAndESettingWork)
        {
            if (myReader != null && sAndESettingWork != null)
            {
                # region �N���X�֊i�[
                sAndESettingWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                sAndESettingWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                sAndESettingWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                sAndESettingWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                sAndESettingWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                sAndESettingWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                sAndESettingWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                sAndESettingWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                sAndESettingWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                sAndESettingWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                sAndESettingWork.AddresseeShopCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEESHOPCDRF"));
                sAndESettingWork.SAndEMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SANDEMNGCODERF"));
                sAndESettingWork.ExpenseDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXPENSEDIVCDRF"));
                sAndESettingWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));
                sAndESettingWork.AcptAnOrderDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANORDERDIVRF"));
                sAndESettingWork.DelivererCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERCDRF"));
                sAndESettingWork.DelivererNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERNMRF"));
                sAndESettingWork.DelivererAddress = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERADDRESSRF"));
                sAndESettingWork.DelivererPhoneNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERPHONENUMRF"));
                sAndESettingWork.TradCompName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPNAMERF"));
                sAndESettingWork.TradCompSectName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPSECTNAMERF"));
                sAndESettingWork.PureTradCompCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PURETRADCOMPCDRF"));
                sAndESettingWork.PureTradCompRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PURETRADCOMPRATERF"));
                sAndESettingWork.PriTradCompCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRITRADCOMPCDRF"));
                sAndESettingWork.PriTradCompRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRITRADCOMPRATERF"));
                sAndESettingWork.ABGoodsCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ABGOODSCODERF"));
                sAndESettingWork.CommentReservedDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMMENTRESERVEDDIVRF"));
                sAndESettingWork.GoodsMakerCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD1RF"));
                sAndESettingWork.GoodsMakerCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD2RF"));
                sAndESettingWork.GoodsMakerCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD3RF"));
                sAndESettingWork.GoodsMakerCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD4RF"));
                sAndESettingWork.GoodsMakerCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD5RF"));
                sAndESettingWork.GoodsMakerCd6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD6RF"));
                sAndESettingWork.GoodsMakerCd7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD7RF"));
                sAndESettingWork.GoodsMakerCd8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD8RF"));
                sAndESettingWork.GoodsMakerCd9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD9RF"));
                sAndESettingWork.GoodsMakerCd10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD10RF"));
                sAndESettingWork.GoodsMakerCd11 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD11RF"));
                sAndESettingWork.GoodsMakerCd12 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD12RF"));
                sAndESettingWork.GoodsMakerCd13 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD13RF"));
                sAndESettingWork.GoodsMakerCd14 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD14RF"));
                sAndESettingWork.GoodsMakerCd15 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD15RF"));
                sAndESettingWork.PartsOEMDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSOEMDIVRF")); 
                sAndESettingWork.SectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                sAndESettingWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
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
        /// <param name="sqlConnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            if (sqlConnection != null)
            {
                // DB�ɐڑ�����Ă��Ȃ��ꍇ�͂����Őڑ�����
                if ((sqlConnection.State & ConnectionState.Open) == 0)
                {
                    sqlConnection.Open();
                }

                // �g�����U�N�V�����̐���(�J�n)
#if DEBUG
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif
            }

            return sqlTransaction;
        }
        # endregion
    }
}
