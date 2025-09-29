//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : TSP���M�f�[�^�쐬 �����[�g�I�u�W�F�N�g
// �v���O�����T�v   : TSP���M�f�[�^�쐬 �����[�g�I�u�W�F�N�g�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670305-00 �쐬�S�� : ���O
// �� �� ��  2020/11/20  �C�����e : �V�K�쐬
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
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// TSP���M�f�[�^�쐬 �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       :TSP���M�f�[�^�쐬���s���N���X�ł��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2020/11/20</br>
    /// </remarks>
    public class TspSdRvDataDB : RemoteDB, ITspSdRvDataDB
    {
        /// <summary>
        /// �̔ԏ����̋��ʕ��iDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public TspSdRvDataDB()
            : base()
        {
        }

        #region [�̔ԏ���]
        /// <summary>
        /// ���ʒʔԂ��̔Ԃ��܂��B
        /// </summary>
        /// <param name="enterprisecode">��ƃR�[�h���w�肵�܂��B</param>
        /// <param name="sectioncode">���_�R�[�h���w�肵�܂��B</param>
        /// <param name="commonSeqNo">�̔Ԃ������ʒʔԂ�Ԃ��܂��B</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���ʒʔԂ��̔Ԃ��܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public int GetTspCommonSeqNo(string enterprisecode, string sectioncode, out Int64 commonSeqNo)
        {
            // ���ʒʔԂ��̔Ԃ���
            return GetSerialNumber(enterprisecode, sectioncode, (SerialNumberCode)5000, out commonSeqNo);
        }

        /// <summary>
        /// �ʔԂ��̔Ԃ��܂��B
        /// </summary>
        /// <param name="enterprisecode">��ƃR�[�h���w�肵�܂��B</param>
        /// <param name="sectioncode">���_�R�[�h���w�肵�܂��B</param>
        /// <param name="serialnumcd">�ʔԃR�[�h���w�肵�܂��B</param>
        /// <param name="serialnumber">�ԍ��R�[�h�Ɋ�č̔Ԃ��ꂽ�ʔԂ�Ԃ��܂��B</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ʔԂ��̔Ԃ��܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private int GetSerialNumber(string enterprisecode, string sectioncode, SerialNumberCode serialnumcd, out Int64 serialnumber)
        {
            // �����̎����������ʃN���X������ PMCMN00005 �Ɉړ����܂����B
            NumberingManager numberingMng = new NumberingManager();
            return numberingMng.GetSerialNumber(enterprisecode, sectioncode, serialnumcd, out serialnumber);
        }
        #endregion

        #region [Search����]
        /// <summary>
        /// �w�肳�ꂽ������TSP���׃f�[�^LIST�̌�����߂��܂��B
        /// </summary>
        /// <param name="tspDtlWorkPara">��������</param>
        /// <param name="tspDtlWorkList">TSP���׃f�[�^LIST</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ������TSP���׃f�[�^LIST�̌�����߂��܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public int Search(TspDtlWork tspDtlWorkPara, out object tspDtlWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            tspDtlWorkList = null;
            ArrayList retList = null;
            SqlConnection sqlConnection = null;

            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    // ��������
                    TspDtlWork param = tspDtlWorkPara as TspDtlWork;

                    // ����
                    status = SearchProc(param, out retList, ref sqlConnection);
                    // �߂�l�Z�b�g
                    tspDtlWorkList = retList;
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "TspSdRvDataDB.Search", status);
                }
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ������TSP���׃f�[�^LIST�̌�����߂��܂��B
        /// </summary>
        /// <param name="param">��������</param>
        /// <param name="TspDtlWorkList">TSP���׃f�[�^LIST</param>
        /// <param name="sqlConnection">�N�G���R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ������TSP���׃f�[�^LIST�̌�����߂��܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private int SearchProc(TspDtlWork param, out ArrayList TspDtlWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            TspDtlWorkList = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            ArrayList al = new ArrayList();
            using (sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    // �����N�G���̍쐬
                    StringBuilder sqlText = new StringBuilder();
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine("  CREATEDATETIMERF ");                      // �쐬����
                    sqlText.AppendLine("  ,UPDATEDATETIMERF ");                     // �X�V����
                    sqlText.AppendLine("  ,ENTERPRISECODERF ");                     // ��ƃR�[�h
                    sqlText.AppendLine("  ,FILEHEADERGUIDRF ");                     // GUID
                    sqlText.AppendLine("  ,UPDEMPLOYEECODERF ");                    // �X�V�]�ƈ��R�[�h
                    sqlText.AppendLine("  ,UPDASSEMBLYID1RF ");                     // �X�V�A�Z���u��ID1
                    sqlText.AppendLine("  ,UPDASSEMBLYID2RF ");                     // �X�V�A�Z���u��ID2
                    sqlText.AppendLine("  ,LOGICALDELETECODERF ");                  // �_���폜�敪
                    sqlText.AppendLine("  ,SALESSLIPNUMRF ");                       // ����`�[�ԍ�
                    sqlText.AppendLine("  ,ACPTANODRSTATUSRF ");                    // �󒍃X�e�[�^�X
                    sqlText.AppendLine("  ,SALESSLIPDTLNUMRF ");                    // ���㖾�גʔ�
                    sqlText.AppendLine("  ,TSPONLINENORF ");                        // TSP�I�����C���ԍ�
                    sqlText.AppendLine("  ,TSPONLINEROWNORF ");                     // TSP�I�����C���s�ԍ�
                    sqlText.AppendLine(" FROM TSPDTLRF WITH (READUNCOMMITTED) ");
                    // ��������
                    sqlText.AppendLine(MakeWhereString(param, 0, ref sqlCommand));

                    sqlCommand.CommandText = sqlText.ToString();
                    // �����^�C���A�E�g�̐ݒ�(60�b)
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    using (myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            // �������ʂ̊i�[
                            al.Add(CopyToTspDtlWorkFromReader(ref myReader));
                        }
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
                    status = base.WriteSQLErrorLog(sqlex, "TspSdRvDataDB.SearchProc", status);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "TspSdRvDataDB.SearchProc Exception=" + ex.Message);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            TspDtlWorkList = al;

            return status;
        }

        /// <summary>
        /// ����Where���̍쐬
        /// </summary>
        /// <param name="param">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="sqlCommand">�N�G���R�}���h</param>
        /// <returns>����Where��</returns>
        /// <remarks>
        /// <br>Note       : ����Where���̍쐬</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private string MakeWhereString(TspDtlWork param, ConstantManagement.LogicalMode logicalMode, ref SqlCommand sqlCommand)
        {
            StringBuilder sqlText = new StringBuilder();

            sqlText.AppendLine(" WHERE ");

            // ��ƃR�[�h
            sqlText.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(param.EnterpriseCode);

            // �_���폜�敪
            sqlText.AppendLine(" AND LOGICALDELETECODERF=@LOGICALDELETECODE ");
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

            // �󒍃X�e�[�^�X
            sqlText.AppendLine(" AND ACPTANODRSTATUSRF=@ACPTANODRSTATUSRF ");
            SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUSRF", SqlDbType.Int);
            paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(param.AcptAnOdrStatus);

            // ����`�[�ԍ�
            sqlText.AppendLine(" AND SALESSLIPNUMRF=@FINDSALESSLIPNUM ");
            SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
            paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(param.SalesSlipNum);

            return sqlText.ToString();
        }

        /// <summary>
        /// �������ʂ̊i�[
        /// </summary>
        /// <param name="myReader">���ʃ��[�_</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �������ʂ̊i�[</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private TspDtlWork CopyToTspDtlWorkFromReader(ref SqlDataReader myReader)
        {
            TspDtlWork resultWork = new TspDtlWork();
            resultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));      // �쐬����
            resultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));      // �X�V����
            resultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                 // ��ƃR�[�h
            resultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                   // GUID
            resultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));               // �X�V�]�ƈ��R�[�h
            resultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                 // �X�V�A�Z���u��ID1
            resultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                 // �X�V�A�Z���u��ID2
            resultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));            // �_���폜�敪
            resultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));                     // ����`�[�ԍ�
            resultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));                // �󒍃X�e�[�^�X
            resultWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));                // ���㖾�גʔ�
            resultWork.TspOnlineNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TSPONLINENORF"));                        // TSP�I�����C���ԍ�
            resultWork.TspOnlineRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TSPONLINEROWNORF"));                  // TSP�I�����C���s�ԍ�

            return resultWork;
        }
        #endregion

        #region [Write����]
        /// <summary>
        /// TSP���׃f�[�^��o�^�A�X�V���܂��B
        /// </summary>
        /// <param name="tspDtlWorkObj">TSP���׃f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP���׃f�[�^��o�^�A�X�V���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public int Write(ref object tspDtlWorkObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            using (sqlConnection = CreateSqlConnection(true))
            {
                using (sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default))
                {
                    try
                    {
                        // �o�^�f�[�^
                        ArrayList writeList = tspDtlWorkObj as ArrayList;
                        for (int i = 0; i < writeList.Count;i++ )
                        {
                            TspDtlWork tspDtlWork = (TspDtlWork)writeList[i];
                            if (i == 0)
                            {
                                // �폜�������s
                                status = this.DeleteProc(tspDtlWork, ref sqlConnection, ref sqlTransaction);
                            }
                            //�ǉ��������s
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                status = this.InsertProc(tspDtlWork, ref sqlConnection, ref sqlTransaction);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        base.WriteErrorLog(ex, "TspSdRvDataDB.Write", status);
                    }
                    finally
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            if (sqlTransaction.Connection != null)
                            {
                                sqlTransaction.Rollback();
                            }
                        }
                        if (sqlTransaction != null) sqlTransaction.Dispose();
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// TSP���׃f�[�^��o�^���܂��B
        /// </summary>
        /// <param name="tspDtlWork">�o�^�f�[�^</param>
        /// <param name="sqlConnection">�N�G���R�l�N�V����</param>
        /// <param name="sqlTransaction">�N�G���g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP���׃f�[�^��o�^���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private int InsertProc(TspDtlWork tspDtlWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlText.AppendLine(" INSERT INTO TSPDTLRF ( ");
                    sqlText.AppendLine(" CREATEDATETIMERF ");                  // �쐬����
                    sqlText.AppendLine(" ,UPDATEDATETIMERF ");                 // �X�V����
                    sqlText.AppendLine(" ,ENTERPRISECODERF ");                 // ��ƃR�[�h
                    sqlText.AppendLine(" ,FILEHEADERGUIDRF ");                 // GUID
                    sqlText.AppendLine(" ,UPDEMPLOYEECODERF ");                // �X�V�]�ƈ��R�[�h
                    sqlText.AppendLine(" ,UPDASSEMBLYID1RF ");                 // �X�V�A�Z���u��ID1
                    sqlText.AppendLine(" ,UPDASSEMBLYID2RF ");                 // �X�V�A�Z���u��ID2
                    sqlText.AppendLine(" ,LOGICALDELETECODERF ");              // �_���폜�敪
                    sqlText.AppendLine(" ,SALESSLIPNUMRF ");                   // ����`�[�ԍ�
                    sqlText.AppendLine(" ,ACPTANODRSTATUSRF ");                // �󒍃X�e�[�^�X
                    sqlText.AppendLine(" ,SALESSLIPDTLNUMRF ");                // ���㖾�גʔ�
                    sqlText.AppendLine(" ,TSPONLINENORF ");                    // TSP�I�����C���ԍ�
                    sqlText.AppendLine(" ,TSPONLINEROWNORF ");                 // TSP�I�����C���s�ԍ�
                    sqlText.AppendLine(" ) VALUES ( ");
                    sqlText.AppendLine(" @CREATEDATETIME ");                   // �쐬����
                    sqlText.AppendLine(" ,@UPDATEDATETIME ");                  // �X�V����
                    sqlText.AppendLine(" ,@ENTERPRISECODE ");                  // ��ƃR�[�h
                    sqlText.AppendLine(" ,@FILEHEADERGUID ");                  // GUID
                    sqlText.AppendLine(" ,@UPDEMPLOYEECODE ");                 // �X�V�]�ƈ��R�[�h
                    sqlText.AppendLine(" ,@UPDASSEMBLYID1 ");                  // �X�V�A�Z���u��ID1
                    sqlText.AppendLine(" ,@UPDASSEMBLYID2 ");                  // �X�V�A�Z���u��ID2
                    sqlText.AppendLine(" ,@LOGICALDELETECODE ");               // �_���폜�敪
                    sqlText.AppendLine(" ,@SALESSLIPNUM ");                    // ����`�[�ԍ�
                    sqlText.AppendLine(" ,@ACPTANODRSTATUS ");                 // �󒍃X�e�[�^�X
                    sqlText.AppendLine(" ,@SALESSLIPDTLNUM ");                 // ���㖾�גʔ�
                    sqlText.AppendLine(" ,@TSPONLINENO ");                     // TSP�I�����C���ԍ�
                    sqlText.AppendLine(" ,@TSPONLINEROWNO ");                  // TSP�I�����C���s�ԍ�
                    sqlText.AppendLine(" ) ");

                    sqlCommand.CommandText = sqlText.ToString();

                    // �o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)tspDtlWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter paraSalesSlipDtlNum = sqlCommand.Parameters.Add("@SALESSLIPDTLNUM", SqlDbType.BigInt);
                    SqlParameter paraTspOnlineNo = sqlCommand.Parameters.Add("@TSPONLINENO", SqlDbType.Int);
                    SqlParameter paraTspOnlineRowNo = sqlCommand.Parameters.Add("@TSPONLINEROWNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tspDtlWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tspDtlWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(tspDtlWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(tspDtlWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(tspDtlWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(tspDtlWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(tspDtlWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(tspDtlWork.LogicalDeleteCode);
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(tspDtlWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(tspDtlWork.SalesSlipNum);
                    paraSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(tspDtlWork.SalesSlipDtlNum);
                    paraTspOnlineNo.Value = SqlDataMediator.SqlSetInt32(tspDtlWork.TspOnlineNo);
                    paraTspOnlineRowNo.Value = SqlDataMediator.SqlSetInt32(tspDtlWork.TspOnlineRowNo);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                }
                catch (SqlException sqlex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(sqlex, "TspSdRvDataDB.InsertProc", status);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "TspSdRvDataDB.InsertProc Exception==" + ex.Message, status);
                }
            }

            return status;
        }
        #endregion

        #region [Delete����]
        /// <summary>
        /// TSP���׃f�[�^�����S�폜���܂��B
        /// </summary>
        /// <param name="tspDtlWorkObj">TSP���׃f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP���׃f�[�^�����S�폜���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public int Delete(object tspDtlWorkObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�R�l�N�V��������
                using (sqlConnection = CreateSqlConnection(true))
                {
                    // �g�����U�N�V�����J�n
                    using (sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default))
                    {
                        try
                        {
                            TspDtlWork deleteTspDtl = tspDtlWorkObj as TspDtlWork;
                            // �폜�������s
                            status = this.DeleteProc(deleteTspDtl, ref sqlConnection, ref sqlTransaction);
                            
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
                            base.WriteErrorLog(ex, "TspSdRvDataDB.Delete");
                            // ���[���o�b�N
                            if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TspSdRvDataDB.Delete Exception==" + ex.Message, status);

                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// TSP���׃f�[�^�����S�폜���܂��B
        /// </summary>
        /// <param name="tspDtlWork">�폜�f�[�^</param>
        /// <param name="sqlConnection">�N�G���R�l�N�V����</param>
        /// <param name="sqlTransaction">�N�G���g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP���׃f�[�^�����S�폜���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private int DeleteProc(TspDtlWork tspDtlWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
            {
                try
                {
                    StringBuilder sqlTextDel = new StringBuilder();
                    #region
                    sqlTextDel.AppendLine(" DELETE ");
                    sqlTextDel.AppendLine(" FROM ");
                    sqlTextDel.AppendLine(" TSPDTLRF");
                    sqlTextDel.AppendLine(" WHERE ");
                    sqlTextDel.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    sqlTextDel.AppendLine(" AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS ");
                    sqlTextDel.AppendLine(" AND SALESSLIPNUMRF=@FINDSALESSLIPNUM ");
                    #endregion
                    sqlCommand.CommandText = sqlTextDel.ToString();

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tspDtlWork.EnterpriseCode);
                    findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(tspDtlWork.SalesSlipNum);
                    findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(tspDtlWork.AcptAnOdrStatus);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException sqlex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(sqlex, "TspSdRvDataDB.DeleteProc", status);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "TspSdRvDataDB.DeleteProc Exception=" + ex.Message, status);
                }
            }
            return status;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Note       : SqlConnection��������</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
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
        #endregion
    }
}
