//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����M�Ώېݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ����M�Ώېݒ�̕ύX���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/04/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11600006-00 �쐬�S�� : ���O
// �C �� ��  2020/09/25  �C�����e : PMKOBETSU-3877�̑Ή�
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
    ///����M�Ώۃ}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����M�Ώۃ}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.04.22</br>
    /// <br>Update Note: 2020/09/25 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11600006-00</br>
    /// <br>           : PMKOBETSU-3877�̑Ή�</br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SecMngSndRcvDB : RemoteDB, ISendSetDB
    {
        /// <summary>
        /// ����M�Ώۃ}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        public SecMngSndRcvDB()
            : base("PMKYO09206D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvWork", "SENDSET")
        {

        }

        # region [Search]
        /// <summary>
        /// ����M�Ώۃ}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outSecMngSndRcvList">��������</param>
        /// <param name="paraSecMngSndRcvWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�Ώۃ}�X�^�̃L�[�l����v����A�S�Ă̑���M�Ώۃ}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        public int Search(out object outSecMngSndRcvList, object paraSecMngSndRcvWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList _secMngSndRcvList = null;
            SecMngSndRcvWork secMngSndRcvWork = null;

            outSecMngSndRcvList = new CustomSerializeArrayList();

            try
            {
                secMngSndRcvWork = paraSecMngSndRcvWork as SecMngSndRcvWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.SearchProc(out _secMngSndRcvList, secMngSndRcvWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);

                if (_secMngSndRcvList != null)
                {
                    (outSecMngSndRcvList as CustomSerializeArrayList).AddRange(_secMngSndRcvList);
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SendSetDB.Search(out object, object, int, LogicalMode)", status);
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
        /// ����M�Ώۏڍ׃}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outSecMngSndRcvDtlList">��������</param>
        /// <param name="paraSecMngSndRcvDtlWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�Ώۏڍ׃}�X�^�̃L�[�l����v����A�S�Ă̑���M�Ώۏڍ׃}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        public int SearchDtl(out object outSecMngSndRcvDtlList, object paraSecMngSndRcvDtlWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList _secMngSndRcvDtlList = null;
            SecMngSndRcvDtlWork secMngSndRcvDtlWork = null;

            outSecMngSndRcvDtlList = new CustomSerializeArrayList();

            try
            {
                secMngSndRcvDtlWork = paraSecMngSndRcvDtlWork as SecMngSndRcvDtlWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.SearchDtlProc(out _secMngSndRcvDtlList, secMngSndRcvDtlWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);

                if (_secMngSndRcvDtlList != null)
                {
                    (outSecMngSndRcvDtlList as CustomSerializeArrayList).AddRange(_secMngSndRcvDtlList);
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SendSetDB.SearchDtl(out object, object, int, LogicalMode)", status);
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
        /// ����M�Ώۃ}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="secMngSndRcvList">����M�Ώۃ}�X�^�����i�[���� ArrayList</param>
        /// <param name="secMngSndRcvWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�Ώۃ}�X�^�̃L�[�l����v����A�S�Ă̑���M�Ώۃ}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877�̑Ή�</br>
        private int SearchProc(out ArrayList secMngSndRcvList, SecMngSndRcvWork secMngSndRcvWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "  SUPL.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,SUPL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,SUPL.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.DISPLAYORDERRF" + Environment.NewLine;
                sqlText += " ,SUPL.MASTERNAMERF" + Environment.NewLine;
                sqlText += " ,SUPL.FILEIDRF" + Environment.NewLine;
                sqlText += " ,SUPL.FILENMRF" + Environment.NewLine;
                sqlText += " ,SUPL.USERGUIDEDIVCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.SECMNGSENDDIVRF" + Environment.NewLine;
                sqlText += " ,SUPL.SECMNGRECVDIVRF" + Environment.NewLine;
                // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
                sqlText += " ,SUPL.ACPTANODRSENDDIVRF" + Environment.NewLine;
                sqlText += " ,SUPL.ACPTANODRRECVDIVRF" + Environment.NewLine;
                sqlText += " ,SUPL.SHIPMENTSENDDIVRF" + Environment.NewLine;
                sqlText += " ,SUPL.SHIPMENTRECVDIVRF" + Environment.NewLine;
                sqlText += " ,SUPL.ESTIMATESENDDIVRF" + Environment.NewLine;
                sqlText += " ,SUPL.ESTIMATERECVDIVRF" + Environment.NewLine;
                // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SECMNGSNDRCVRF AS SUPL WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlCommand.CommandText += sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, secMngSndRcvWork, logicalMode);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToSecMngSndSetWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "SendSetDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SendSetDB.SearchProc" + status);
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

            secMngSndRcvList = al;

            return status;

        }

        /// <summary>
        /// ����M�Ώۏڍ׃}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="secMngSndRcvDtlList">����M�Ώۏڍ׃}�X�^�����i�[���� ArrayList</param>
        /// <param name="secMngSndRcvDtlWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�Ώۏڍ׃}�X�^�̃L�[�l����v����A�S�Ă̑���M�Ώۏڍ׃}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        private int SearchDtlProc(out ArrayList secMngSndRcvDtlList, SecMngSndRcvDtlWork secMngSndRcvDtlWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "  SUPL.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,SUPL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,SUPL.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.FILEIDRF" + Environment.NewLine;
                sqlText += " ,SUPL.FILENMRF" + Environment.NewLine;
                sqlText += " ,SUPL.ITEMIDRF" + Environment.NewLine;
                sqlText += " ,SUPL.ITEMNAMERF" + Environment.NewLine;
                sqlText += " ,SUPL.DATAUPDATEDIVRF" + Environment.NewLine;
                sqlText += " ,SUPL.DISPLAYORDERRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SECMNGSNDRCVDTLRF AS SUPL WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlCommand.CommandText += sqlText;
                sqlCommand.CommandText += MakeDtlWhereString(ref sqlCommand, secMngSndRcvDtlWork, logicalMode);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToSecMngSndDtlSetWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "SendSetDB.SearchDtlProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SendSetDB.SearchDtlProc" + status);
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

            secMngSndRcvDtlList = al;

            return status;

        }

        # endregion

        # region [Write]
        /// <summary>
        /// ����M�Ώۃ}�X�^�����X�V���܂��B
        /// </summary>
        /// <param name="objsecMngSndRcvWorkList">�X�V���鑗��M�Ώۃ}�X�^���</param>
        /// <param name="objsecMngSndRcvDtlWorkList">�X�V���鑗��M�Ώۏڍ׃}�X�^���</param>
        /// <param name="writeMode">�X�V�敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : objsecMngSndRcvWorkList �Ɋi�[����Ă��鑗��M�Ώۃ}�X�^�����X�V���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        public int Write(ref object objsecMngSndRcvWorkList, ref object objsecMngSndRcvDtlWorkList, int writeMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList secMngSndRcvWorkList = objsecMngSndRcvWorkList as ArrayList;

                ArrayList secMngSndRcvDtlWorkList = objsecMngSndRcvDtlWorkList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = this.WriteProc(ref secMngSndRcvWorkList, ref sqlConnection, ref sqlTransaction);

                if (status == 0)
                {
                    status = this.WriteProcDtl(ref secMngSndRcvDtlWorkList, ref sqlConnection, ref sqlTransaction);

                    // �߂�l�Z�b�g
                    objsecMngSndRcvDtlWorkList = secMngSndRcvDtlWorkList;
                }

                // �߂�l�Z�b�g
                objsecMngSndRcvWorkList = secMngSndRcvWorkList;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SendSetDB.Write(ref object)", status);
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
        /// ����M�Ώۃ}�X�^�����X�V���܂��B
        /// </summary>
        /// <param name="secMngSndRcvWorkList">�X�V���鑗��M�Ώۃ}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SecMngSndRcvWork �Ɋi�[����Ă��鑗��M�Ώۃ}�X�^�����X�V���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877�̑Ή�</br>
        private int WriteProc(ref ArrayList secMngSndRcvWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                foreach (SecMngSndRcvWork secMngSndRcvWork in secMngSndRcvWorkList)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SECMNGSNDRCVRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND DISPLAYORDERRF = @FINDDISPLAYORDER" + Environment.NewLine;
                    sqlText += "  AND FILEIDRF = @FINDFILEID" + Environment.NewLine;
                    sqlText += "  AND USERGUIDEDIVCDRF = @FINDUSERGUIDEDIVCD" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findDisplayOrder = sqlCommand.Parameters.Add("@FINDDISPLAYORDER", SqlDbType.Int);
                    SqlParameter findFileId = sqlCommand.Parameters.Add("@FINDFILEID", SqlDbType.NChar);
                    SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.EnterpriseCode);
                    findDisplayOrder.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.DisplayOrder);
                    findFileId.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.FileId);
                    findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.UserGuideDivCd);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != secMngSndRcvWork.UpdateDateTime)
                        {
                            if (secMngSndRcvWork.UpdateDateTime == DateTime.MinValue)
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
                        sqlText += "  SECMNGSNDRCVRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,SECMNGSENDDIVRF = @SECMNGSENDDIV" + Environment.NewLine;
                        sqlText += " ,SECMNGRECVDIVRF = @SECMNGRECVDIV" + Environment.NewLine;
                        // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
                        sqlText += " ,ACPTANODRSENDDIVRF = @ACPTANODRSENDDIV" + Environment.NewLine;
                        sqlText += " ,ACPTANODRRECVDIVRF = @ACPTANODRRECVDIV" + Environment.NewLine;
                        sqlText += " ,SHIPMENTSENDDIVRF = @SHIPMENTSENDDIV" + Environment.NewLine;
                        sqlText += " ,SHIPMENTRECVDIVRF = @SHIPMENTRECVDIV" + Environment.NewLine;
                        sqlText += " ,ESTIMATESENDDIVRF = @ESTIMATESENDDIV" + Environment.NewLine;
                        sqlText += " ,ESTIMATERECVDIVRF = @ESTIMATERECVDIV" + Environment.NewLine;
                        // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND DISPLAYORDERRF = @FINDDISPLAYORDER" + Environment.NewLine;
                        sqlText += "  AND FILEIDRF = @FINDFILEID" + Environment.NewLine;
                        sqlText += "  AND USERGUIDEDIVCDRF = @FINDUSERGUIDEDIVCD" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.EnterpriseCode);
                        findDisplayOrder.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.DisplayOrder);
                        findFileId.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.FileId);
                        findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.UserGuideDivCd);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)secMngSndRcvWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (secMngSndRcvWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }
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
                    SqlParameter paraSecMngSendDiv = sqlCommand.Parameters.Add("@SECMNGSENDDIV", SqlDbType.Int);
                    SqlParameter paraSecMngRecvDiv = sqlCommand.Parameters.Add("@SECMNGRECVDIV", SqlDbType.Int);
                    // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
                    SqlParameter paraAcptAnOdrSendDiv = sqlCommand.Parameters.Add("@ACPTANODRSENDDIV", SqlDbType.Int);
                    SqlParameter paraAcptAnOdrRecvDiv = sqlCommand.Parameters.Add("@ACPTANODRRECVDIV", SqlDbType.Int);
                    SqlParameter paraShipmentSendDiv = sqlCommand.Parameters.Add("@SHIPMENTSENDDIV", SqlDbType.Int);
                    SqlParameter paraShipmentRecvDiv = sqlCommand.Parameters.Add("@SHIPMENTRECVDIV", SqlDbType.Int);
                    SqlParameter paraEstimateSendDiv = sqlCommand.Parameters.Add("@ESTIMATESENDDIV", SqlDbType.Int);
                    SqlParameter paraEstimateRecvDiv = sqlCommand.Parameters.Add("@ESTIMATERECVDIV", SqlDbType.Int);
                    // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
                    # endregion

                    # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngSndRcvWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngSndRcvWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(secMngSndRcvWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.LogicalDeleteCode);
                    paraSecMngSendDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.SecMngSendDiv);
                    paraSecMngRecvDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.SecMngRecvDiv);
                    // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
                    paraAcptAnOdrSendDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.AcptAnOdrSendDiv);
                    paraAcptAnOdrRecvDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.AcptAnOdrRecvDiv);
                    paraShipmentSendDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.ShipmentSendDiv);
                    paraShipmentRecvDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.ShipmentRecvDiv);
                    paraEstimateSendDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.EstimateSendDiv);
                    paraEstimateRecvDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.EstimateRecvDiv);
                    // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
                    # endregion

                    sqlCommand.ExecuteNonQuery();
                    al.Add(secMngSndRcvWork);

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SendSetDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SendSetDB.Write" + status);
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

            secMngSndRcvWorkList = al;

            return status;
        }

        /// <summary>
        /// ����M�Ώۏڍ׃}�X�^�����X�V���܂��B
        /// </summary>
        /// <param name="secMngSndRcvDtlWorkList">�X�V���鑗��M�Ώۏڍ׃}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : enterpriseSetWork �Ɋi�[����Ă��鑗��M�Ώۏڍ׃}�X�^�����X�V���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        private int WriteProcDtl(ref ArrayList secMngSndRcvDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                foreach (SecMngSndRcvDtlWork secMngSndRcvDtlWork in secMngSndRcvDtlWorkList)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SECMNGSNDRCVDTLRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND FILEIDRF = @FINDFILEID" + Environment.NewLine;
                    sqlText += "  AND ITEMIDRF = @FINDITEMID" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findFileId = sqlCommand.Parameters.Add("@FINDFILEID", SqlDbType.NChar);
                    SqlParameter findItemId = sqlCommand.Parameters.Add("@FINDITEMID", SqlDbType.NChar);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.EnterpriseCode);
                    findFileId.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.FileId);
                    findItemId.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.ItemId);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != secMngSndRcvDtlWork.UpdateDateTime)
                        {
                            if (secMngSndRcvDtlWork.UpdateDateTime == DateTime.MinValue)
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
                        sqlText += "  SECMNGSNDRCVDTLRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,DATAUPDATEDIVRF = @DATAUPDATEDIVRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND FILEIDRF = @FINDFILEID" + Environment.NewLine;
                        sqlText += "  AND ITEMIDRF = @FINDITEMID" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.EnterpriseCode);
                        findFileId.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.FileId);
                        findItemId.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.ItemId);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)secMngSndRcvDtlWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (secMngSndRcvDtlWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }
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
                    SqlParameter paraDataUpdateDiv = sqlCommand.Parameters.Add("@DATAUPDATEDIVRF", SqlDbType.Int);
                    # endregion

                    # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngSndRcvDtlWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngSndRcvDtlWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(secMngSndRcvDtlWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvDtlWork.LogicalDeleteCode);
                    paraDataUpdateDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvDtlWork.DataUpdateDiv);

                    # endregion

                    sqlCommand.ExecuteNonQuery();
                    al.Add(secMngSndRcvDtlWork);

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SendSetDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SendSetDB.Write" + status);
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

            secMngSndRcvDtlWorkList = al;

            return status;
        }

        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="secMngSndRcvWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SecMngSndRcvWork secMngSndRcvWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // ��ƃR�[�h
            retstring += "  SUPL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND SUPL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND SUPL.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            retstring += " ORDER BY" + Environment.NewLine;
            retstring += " SUPL.DISPLAYORDERRF" + Environment.NewLine;

            return retstring;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="secMngSndRcvDtlWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        private string MakeDtlWhereString(ref SqlCommand sqlCommand, SecMngSndRcvDtlWork secMngSndRcvDtlWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // ��ƃR�[�h
            retstring += "  SUPL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND SUPL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND SUPL.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            retstring += " ORDER BY" + Environment.NewLine;
            retstring += " SUPL.DISPLAYORDERRF, SUPL.FILEIDRF, SUPL.ITEMIDRF " + Environment.NewLine;

            return retstring;
        }

        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SecMngSndRcvWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SecMngSndRcvWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877�̑Ή�</br>
        /// </remarks>
        private SecMngSndRcvWork CopyToSecMngSndSetWorkFromReader(ref SqlDataReader myReader)
        {
            SecMngSndRcvWork secMngSndRcvWork = new SecMngSndRcvWork();

            if (myReader != null)
            {
                # region �N���X�֊i�[
                secMngSndRcvWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                secMngSndRcvWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                secMngSndRcvWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                secMngSndRcvWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                secMngSndRcvWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                secMngSndRcvWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                secMngSndRcvWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                secMngSndRcvWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                secMngSndRcvWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                secMngSndRcvWork.MasterName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MASTERNAMERF"));
                secMngSndRcvWork.FileId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILEIDRF"));
                secMngSndRcvWork.FileNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILENMRF"));
                secMngSndRcvWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                secMngSndRcvWork.SecMngSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECMNGSENDDIVRF"));
                secMngSndRcvWork.SecMngRecvDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECMNGRECVDIVRF"));
                // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
                secMngSndRcvWork.AcptAnOdrSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSENDDIVRF"));
                secMngSndRcvWork.AcptAnOdrRecvDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRRECVDIVRF"));
                secMngSndRcvWork.ShipmentSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMENTSENDDIVRF"));
                secMngSndRcvWork.ShipmentRecvDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMENTRECVDIVRF"));
                secMngSndRcvWork.EstimateSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATESENDDIVRF"));
                secMngSndRcvWork.EstimateRecvDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATERECVDIVRF"));
                // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
                # endregion
            }

            return secMngSndRcvWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� SecMngSndRcvDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        private SecMngSndRcvDtlWork CopyToSecMngSndDtlSetWorkFromReader(ref SqlDataReader myReader)
        {
            SecMngSndRcvDtlWork secMngSndRcvDtlWork = new SecMngSndRcvDtlWork();

            if (myReader != null)
            {
                # region �N���X�֊i�[
                secMngSndRcvDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                secMngSndRcvDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                secMngSndRcvDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                secMngSndRcvDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                secMngSndRcvDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                secMngSndRcvDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                secMngSndRcvDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                secMngSndRcvDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                secMngSndRcvDtlWork.FileId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILEIDRF"));
                secMngSndRcvDtlWork.FileNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILENMRF"));
                secMngSndRcvDtlWork.ItemId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ITEMIDRF"));
                secMngSndRcvDtlWork.ItemName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ITEMNAMERF"));
                secMngSndRcvDtlWork.DataUpdateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAUPDATEDIVRF"));
                secMngSndRcvDtlWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                # endregion
            }

            return secMngSndRcvDtlWork;
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
        /// <br>Date       : 2009.04.22</br>
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
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
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
