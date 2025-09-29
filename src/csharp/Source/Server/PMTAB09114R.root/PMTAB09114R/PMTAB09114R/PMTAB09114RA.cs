//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y                                       //
// �v���O��������   �FPMTAB�S�̐ݒ�i���Ӑ�ʁj�}�X�^                   //
// �v���O�����T�v   �FPMTAB�S�̐ݒ�i���Ӑ�ʁj�̓o�^�E�C���E�폜���s�� //
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// �Ǘ��ԍ�  10902622-01     �쐬�S���F���|��
// �C����    2013/05/31�@    �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
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


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMTAB�S�̐ݒ�}�X�^�����e�i���XDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB�S�̐ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���|��</br>
    /// <br>Date       : 2013/05/31</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class PmTabTtlStCustDB : RemoteWithAppLockDB, IPmTabTtlStCustDB
    {
        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^�����e�i���XDB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : ���|��</br>														   
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public PmTabTtlStCustDB()
            :
        base("PMTAB09116D", "Broadleaf.Application.Remoting.ParamData.PmTabTtlStCustWork", "PMTABTTLSTCUSTRF")
        {
        }
        
        #region [Write]
        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="pmTabTtlStCustWork">PmTabTtlStCustWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        public int Write(ref object pmTabTtlStCustWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(pmTabTtlStCustWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteSubSectionProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                pmTabTtlStCustWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PmTabTtlStCustDB.Write(ref object pmTabTtlStCustWork)");
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
        /// PMTAB�S�̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="subSectionWorkList">PmTabTtlStCustWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        private int WriteSubSectionProc(ref ArrayList subSectionWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            StringBuilder sqlTxt = new StringBuilder();   

            try
            {
                if (subSectionWorkList != null)
                {
                    for (int i = 0; i < subSectionWorkList.Count; i++)
                    {
                        PmTabTtlStCustWork pmTabTtlStCustWork = subSectionWorkList[i] as PmTabTtlStCustWork;

                        sqlTxt.Append("SELECT UPDATEDATETIMERF" + Environment.NewLine);
                        sqlTxt.Append(" ,ENTERPRISECODERF" + Environment.NewLine);
                        sqlTxt.Append(" FROM PMTABTTLSTCUSTRF" + Environment.NewLine);
                        sqlTxt.Append("WHERE ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);
                        sqlTxt.Append("AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine);
                        sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);
                        sqlTxt.Remove(0,sqlTxt.Length);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCd = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.EnterpriseCode);
                        findParaCustomerCd.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.CustomerCode);

                        //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                        sqlCommand.CommandTimeout = 600;

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != pmTabTtlStCustWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (pmTabTtlStCustWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlTxt.Append("UPDATE PMTABTTLSTCUSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine);
                            sqlTxt.Append(" , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine);
                            sqlTxt.Append(" , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine);
                            sqlTxt.Append(" , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine);
                            sqlTxt.Append(" , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine);
                            sqlTxt.Append(" , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine);
                            sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine);
                            sqlTxt.Append(" , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine);
                            sqlTxt.Append(" , BLPSENDDIVRF=@BLPSENDDIV" + Environment.NewLine);
                            sqlTxt.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                            sqlTxt.Append("    AND CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine);

                            sqlCommand.CommandText = sqlTxt.ToString();
                            sqlTxt.Remove(0, sqlTxt.Length);

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.EnterpriseCode);
                            findParaCustomerCd.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.CustomerCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmTabTtlStCustWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (pmTabTtlStCustWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //�V�K�쐬����SQL���𐶐�

                            sqlTxt.Append("INSERT INTO PMTABTTLSTCUSTRF" + Environment.NewLine);
                            sqlTxt.Append(" (CREATEDATETIMERF" + Environment.NewLine);
                            sqlTxt.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                            sqlTxt.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                            sqlTxt.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                            sqlTxt.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                            sqlTxt.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                            sqlTxt.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                            sqlTxt.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                            sqlTxt.Append("    ,CUSTOMERCODERF" + Environment.NewLine);
                            sqlTxt.Append("    ,BLPSENDDIVRF" + Environment.NewLine);
                            sqlTxt.Append(" )" + Environment.NewLine);
                            sqlTxt.Append(" VALUES" + Environment.NewLine);
                            sqlTxt.Append(" (@CREATEDATETIME" + Environment.NewLine);
                            sqlTxt.Append("    ,@UPDATEDATETIME" + Environment.NewLine);
                            sqlTxt.Append("    ,@ENTERPRISECODE" + Environment.NewLine);
                            sqlTxt.Append("    ,@FILEHEADERGUID" + Environment.NewLine);
                            sqlTxt.Append("    ,@UPDEMPLOYEECODE" + Environment.NewLine);
                            sqlTxt.Append("    ,@UPDASSEMBLYID1" + Environment.NewLine);
                            sqlTxt.Append("    ,@UPDASSEMBLYID2" + Environment.NewLine);
                            sqlTxt.Append("    ,@LOGICALDELETECODE" + Environment.NewLine);
                            sqlTxt.Append("    ,@CUSTOMERCODE" + Environment.NewLine);
                            sqlTxt.Append("    ,@BLPSENDDIV )" + Environment.NewLine);

                            sqlCommand.CommandText = sqlTxt.ToString();
                            sqlTxt.Remove(0, sqlTxt.Length);

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmTabTtlStCustWork;
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
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.NChar);
                        SqlParameter paraBlpSendDiv = sqlCommand.Parameters.Add("@BLPSENDDIV", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabTtlStCustWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabTtlStCustWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pmTabTtlStCustWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.CustomerCode);
                        paraBlpSendDiv.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.BlpSendDiv);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(pmTabTtlStCustWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            subSectionWorkList = al;

            return status;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ������PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�
        /// </summary>
        /// <param name="pmTabTtlStCustWork">��������</param>
        /// <param name="parsesubSectionWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        public int Search(out object pmTabTtlStCustWork, object parsesubSectionWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            pmTabTtlStCustWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSubSection(out pmTabTtlStCustWork, parsesubSectionWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PmTabTtlStCustDB.Search");
                pmTabTtlStCustWork = new ArrayList();
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
        /// �w�肳�ꂽ������PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objsubSectionWork">��������</param>
        /// <param name="parasubSectionWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        public int SearchSubSection(out object objsubSectionWork, object parasubSectionWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            PmTabTtlStCustWork pmTabTtlStCustWork = null;

            ArrayList subSectionWorkList = parasubSectionWork as ArrayList;
            if (subSectionWorkList == null)
            {
                pmTabTtlStCustWork = parasubSectionWork as PmTabTtlStCustWork;
            }
            else
            {
                if (subSectionWorkList.Count > 0)
                    pmTabTtlStCustWork = subSectionWorkList[0] as PmTabTtlStCustWork;
            }

            int status = SearchSubSectionProc(out subSectionWorkList, pmTabTtlStCustWork, readMode, logicalMode, ref sqlConnection);
            objsubSectionWork = subSectionWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ������PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="subSectionWorkList">��������</param>
        /// <param name="pmTabTtlStCustWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������e-JIBAI�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/30</br>
        private int SearchSubSectionProc(out ArrayList subSectionWorkList, PmTabTtlStCustWork pmTabTtlStCustWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                StringBuilder sqlTxt = new StringBuilder();

                sqlTxt.Append("SELECT" + Environment.NewLine);
                sqlTxt.Append(" PMTABTTLSTCUST.CREATEDATETIMERF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.UPDATEDATETIMERF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.ENTERPRISECODERF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.FILEHEADERGUIDRF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.LOGICALDELETECODERF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.CUSTOMERCODERF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.BLPSENDDIVRF" + Environment.NewLine);
                sqlTxt.Append(" ,CUSTOM.CUSTOMERSNMRF" + Environment.NewLine);
                sqlTxt.Append(" FROM PMTABTTLSTCUSTRF PMTABTTLSTCUST WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlTxt.Append(" LEFT JOIN CUSTOMERRF CUSTOM WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlTxt.Append(" ON  CUSTOM.ENTERPRISECODERF=PMTABTTLSTCUST.ENTERPRISECODERF" + Environment.NewLine);
                sqlTxt.Append(" AND CUSTOM.CUSTOMERCODERF=PMTABTTLSTCUST.CUSTOMERCODERF" + Environment.NewLine);

                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, pmTabTtlStCustWork, logicalMode);

                //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                sqlCommand.CommandTimeout = 600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToSubSectionWorkFromReader(ref myReader));

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
                    if (!myReader.IsClosed) myReader.Close();
            }

            subSectionWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^�߂�f�[�^����_���폜���܂�
        /// </summary>
        /// <param name="pmTabTtlStCustWork">PmTabTtlStCustWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^�߂�f�[�^����_���폜���܂�</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        public int LogicalDelete(ref object pmTabTtlStCustWork)
        {
            return LogicalDeleteSubSection(ref pmTabTtlStCustWork, 0);
        }

        /// <summary>
        /// �_���폜PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���𕜊����܂�
        /// </summary>
        /// <param name="pmTabTtlStCustWork">PmTabTtlStCustWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���𕜊����܂�</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        public int RevivalLogicalDelete(ref object pmTabTtlStCustWork)
        {
            return LogicalDeleteSubSection(ref pmTabTtlStCustWork, 1);
        }

        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="pmTabTtlStCustWork">PmTabTtlStCustWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        private int LogicalDeleteSubSection(ref object pmTabTtlStCustWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(pmTabTtlStCustWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSubSectionProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "PmTabTtlStCustDB.LogicalDeleteCarrier :" + procModestr);

                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="subSectionWorkList">PmTabTtlStCustWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        public int LogicalDeleteSubSectionProc(ref ArrayList subSectionWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSubSectionProcProc(ref subSectionWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="subSectionWorkList">PmTabTtlStCustWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        private int LogicalDeleteSubSectionProcProc(ref ArrayList subSectionWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            StringBuilder sqlTxt = new StringBuilder();

            try
            {
                if (subSectionWorkList != null)
                {
                    for (int i = 0; i < subSectionWorkList.Count; i++)
                    {
                        PmTabTtlStCustWork pmTabTtlStCustWork = subSectionWorkList[i] as PmTabTtlStCustWork;

                        sqlTxt.Append(string.Empty);
                        sqlTxt.Append("SELECT UPDATEDATETIMERF" + Environment.NewLine);
                        sqlTxt.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                        sqlTxt.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                        sqlTxt.Append(" FROM PMTABTTLSTCUSTRF" + Environment.NewLine);
                        sqlTxt.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                        sqlTxt.Append("    AND CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine);

                        sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCd = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.EnterpriseCode);
                        findParaCustomerCd.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.CustomerCode);

                        //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                        sqlCommand.CommandTimeout = 600;

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != pmTabTtlStCustWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                            
                            sqlTxt.Append(string.Empty);
                            sqlTxt.Append("UPDATE PMTABTTLSTCUSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine);
                            sqlTxt.Append(" , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine);
                            sqlTxt.Append(" , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine);
                            sqlTxt.Append(" , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine);
                            sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine);
                            sqlTxt.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                            sqlTxt.Append("    AND CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine);

                            sqlCommand.CommandText = sqlTxt.ToString();

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.EnterpriseCode);
                            findParaCustomerCd.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.CustomerCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmTabTtlStCustWork;
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
                        if (myReader.IsClosed == false) myReader.Close();

                        //�_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) pmTabTtlStCustWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else pmTabTtlStCustWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) pmTabTtlStCustWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabTtlStCustWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(pmTabTtlStCustWork);
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
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            subSectionWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteSubSectionProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PmTabTtlStCustDB.Delete");
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
        /// PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        public int Delete(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(paraobj);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteSubSectionProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PmTabTtlStCustDB.Delete");
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
        /// PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="subSectionWorkList">PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        public int DeleteSubSectionProc(ArrayList subSectionWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSubSectionProcProc(subSectionWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="subSectionWorkList">PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^�߂�f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        private int DeleteSubSectionProcProc(ArrayList subSectionWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlTxt = new StringBuilder();

            try
            {

                for (int i = 0; i < subSectionWorkList.Count; i++)
                {
                    PmTabTtlStCustWork pmTabTtlStCustWork = subSectionWorkList[i] as PmTabTtlStCustWork;

                    sqlTxt.Append(string.Empty);
                    sqlTxt.Append("SELECT UPDATEDATETIMERF" + Environment.NewLine);
                    sqlTxt.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                    sqlTxt.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                    sqlTxt.Append(" FROM PMTABTTLSTCUSTRF" + Environment.NewLine);
                    sqlTxt.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                    sqlTxt.Append("    AND CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine);

                    sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

                    sqlTxt.Remove(0,sqlTxt.Length);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCd= sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.EnterpriseCode);
                    findParaCustomerCd.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.CustomerCode);

                    //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                    sqlCommand.CommandTimeout = 600;

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != pmTabTtlStCustWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlTxt.Append("DELETE" + Environment.NewLine);
                        sqlTxt.Append(" FROM PMTABTTLSTCUSTRF" + Environment.NewLine);
                        sqlTxt.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                        sqlTxt.Append("    AND CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine);

                        sqlCommand.CommandText = sqlTxt.ToString();
                        sqlTxt.Remove(0,sqlTxt.Length);

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.EnterpriseCode);
                        findParaCustomerCd.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.CustomerCode);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
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

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="pmTabTtlStCustWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, PmTabTtlStCustWork pmTabTtlStCustWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "PMTABTTLSTCUST.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND PMTABTTLSTCUST.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND PMTABTTLSTCUST.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //PMTAB�S�̐ݒ蓾�Ӑ�R�[�h
            if (pmTabTtlStCustWork.CustomerCode != 0)
            {
                retstring += "AND PMTABTTLSTCUST.CUSTOMERCODERF=@CUSTOMERCODE ";
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.CustomerCode);
            }

            return retstring;
        }

        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            PmTabTtlStCustWork[] SubSectionWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is PmTabTtlStCustWork)
                    {
                        PmTabTtlStCustWork wkSubSectionWork = paraobj as PmTabTtlStCustWork;
                        if (wkSubSectionWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkSubSectionWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            SubSectionWorkArray = (PmTabTtlStCustWork[])XmlByteSerializer.Deserialize(byteArray, typeof(PmTabTtlStCustWork[]));
                        }
                        catch (Exception) { }
                        if (SubSectionWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(SubSectionWorkArray);
                        }
                        else
                        {
                            try
                            {
                                PmTabTtlStCustWork wkSubSectionWork = (PmTabTtlStCustWork)XmlByteSerializer.Deserialize(byteArray, typeof(PmTabTtlStCustWork));
                                if (wkSubSectionWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkSubSectionWork);
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

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� PmTabTtlStCustWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PmTabTtlStCustWork</returns>
        /// <remarks>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private PmTabTtlStCustWork CopyToSubSectionWorkFromReader(ref SqlDataReader myReader)
        {
            PmTabTtlStCustWork wkSubSectionWork = new PmTabTtlStCustWork();

            #region �N���X�֊i�[
            wkSubSectionWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkSubSectionWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkSubSectionWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkSubSectionWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkSubSectionWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkSubSectionWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkSubSectionWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkSubSectionWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkSubSectionWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkSubSectionWork.CustomerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkSubSectionWork.BlpSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLPSENDDIVRF"));
            #endregion

            return wkSubSectionWork;
        }

        #endregion

    }
}
