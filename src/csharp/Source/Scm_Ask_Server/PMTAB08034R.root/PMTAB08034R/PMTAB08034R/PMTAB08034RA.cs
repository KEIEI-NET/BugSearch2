//**********************************************************************
// System           : PM.NS
// Sub System       :
// Program name     : PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^ �����[�g�I�u�W�F�N�g
//                  : PMTAB08034R.DLL
// Name Space       : Broadleaf.Application.Remoting
// Programmer       : 30746 ���� ��
// Date             : 2014/09/26
//----------------------------------------------------------------------
//                  (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Common;
using Broadleaf.Library.Data.SqlClient;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30746 ���� ��</br>
    /// <br>Date       : 2014/09/26</br>  
    /// </remarks>
    [Serializable]
    public class PmtGeneralSrRstDB : RemoteDB, IPmtGeneralSrRstDB
    {
        /// <summary>
        /// PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>
        /// </remarks>
        public PmtGeneralSrRstDB()
            :
            base("PMTAB08036D", "Broadleaf.Application.Remoting.ParamData.PmtGeneralSrRstWork", "PmtGeneralSrRstRF")
        {
        }

        #region �f�[�^�敪�P
        #region [Seacrch]
        /// <summary>
        /// PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^��������
        /// �f�[�^�敪�P�p
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>
        public int SearchForLinkDataCode1(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retObj = null;
            //�R�l�N�V����
            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                sqlConnection.Open();

                ArrayList retList = null;
                PmtGeneralSrRstWork paraPmtGeneralSrRstWork = null;
                paraPmtGeneralSrRstWork = (PmtGeneralSrRstWork)paraObj;
                //�����������s��
                status = this.SearchForLinkDataCode1Proc(out retList, paraPmtGeneralSrRstWork, ref sqlConnection);

                retObj = (object)retList;

                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PmtGeneralSrRstDB.SearchForTablet");
                retObj = new ArrayList();
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
        /// PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�����������s��
        /// �f�[�^�敪�P�p
        /// </summary>
        /// <param name="retList"></param>
        /// <param name="SalesTtlStSearchParaWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>
        private int SearchForLinkDataCode1Proc(out ArrayList retList, PmtGeneralSrRstWork paraPmtGeneralSrRstWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retList = null;

            ArrayList arrayList = new ArrayList();

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT��]
                sqlText.Append("SELECT" + Environment.NewLine);
                sqlText.Append("  CREATEDATETIMERF" + Environment.NewLine);
                sqlText.Append(", UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append(", ENTERPRISECODERF" + Environment.NewLine);
                sqlText.Append(", FILEHEADERGUIDRF" + Environment.NewLine);
                sqlText.Append(", UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlText.Append(", UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlText.Append(", UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlText.Append(", LOGICALDELETECODERF" + Environment.NewLine);
                sqlText.Append(", SEARCHSECTIONCODERF" + Environment.NewLine);
                sqlText.Append(", BUSINESSSESSIONIDRF" + Environment.NewLine);
                sqlText.Append(", LINKDATACODERF" + Environment.NewLine);
                sqlText.Append(", PMTABDTLDISCGUIDRF" + Environment.NewLine);
                sqlText.Append(", PMTABSEARCHROWNUMRF" + Environment.NewLine);
                sqlText.Append(", DATADELETEDATERF" + Environment.NewLine);
                sqlText.Append(", SALESEMPLOYEECDRF" + Environment.NewLine);
                sqlText.Append(", SALESEMPLOYEENMRF" + Environment.NewLine);
                sqlText.Append(", FRONTEMPLOYEECDRF" + Environment.NewLine);
                sqlText.Append(", FRONTEMPLOYEENMRF" + Environment.NewLine);
                sqlText.Append(", SALESINPUTCODERF" + Environment.NewLine);
                sqlText.Append(", SALESINPUTNAMERF" + Environment.NewLine);
                sqlText.Append("FROM" + Environment.NewLine);
                sqlText.Append("  PMTGENERALSRRSTRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append("WHERE" + Environment.NewLine);
                sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);
                sqlText.Append("  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine);
                sqlText.Append("  AND LINKDATACODERF = @FINDLINKDATACODE" + Environment.NewLine);
                sqlText.Append("  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine);
                sqlText.Append("  AND PMTABSEARCHROWNUMRF = @FINDPMTABSEARCHROWNUM" + Environment.NewLine);

                // Select�R�}���h�̐���
                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                // Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaBusinessSessionId = sqlCommand.Parameters.Add("@FINDBUSINESSSESSIONID", SqlDbType.NChar);
                SqlParameter findParaLinkDataCode = sqlCommand.Parameters.Add("@FINDLINKDATACODE", SqlDbType.Int);
                SqlParameter findParaPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@FINDPMTABDTLDISCGUID", SqlDbType.NChar);
                SqlParameter findParaPmTabSearchRowNum = sqlCommand.Parameters.Add("@FINDPMTABSEARCHROWNUM", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraPmtGeneralSrRstWork.EnterpriseCode);
                findParaBusinessSessionId.Value = SqlDataMediator.SqlSetString(paraPmtGeneralSrRstWork.BusinessSessionId);
                findParaLinkDataCode.Value = SqlDataMediator.SqlSetInt(1);
                findParaPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString("dummy");
                findParaPmTabSearchRowNum.Value =SqlDataMediator.SqlSetInt(-1);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    PmtGeneralSrRstWork pmtGeneralSetWork = new PmtGeneralSrRstWork();
                    this.ReaderToPmtGeneralSrRstWork(ref myReader, ref pmtGeneralSetWork);
                    arrayList.Add(pmtGeneralSetWork);
                }
                retList = arrayList;
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�̃��[�J���V���N�p�f�[�^�̎擾�Ɏ��s���܂����B", ex.Number);
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
                    sqlCommand.Dispose();
                }
            }

            return status;

        }

        /// <summary>
        /// PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^��������
        /// �f�[�^�敪�P�p
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="msgDiv">���b�Z�[�W�敪�@[True:���b�Z�[�W�L]</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>
        public int SearchForLinkDataCode1(out object retObj, object paraObj, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            msgDiv = false;
            errMsg = string.Empty;

            retObj = null;
            try
            {
                ArrayList retList = null;
                PmtGeneralSrRstWork paraPmtGeneralSrRstWork = null;
                paraPmtGeneralSrRstWork = (PmtGeneralSrRstWork)paraObj;

                status = this.SearchForLinkDataCode1Proc(out retList, paraPmtGeneralSrRstWork, ref sqlConnection, logicalMode);

                retObj = (object)retList;

                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PmtGeneralSrRstDB.SearchForTablet");

                msgDiv = true;
                errMsg = "PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�̃��[�J���V���N�p�f�[�^�擾�Ɏ��s���܂����B";

                retObj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {

            }
        }

        /// <summary>
        /// PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�����������s��
        /// �f�[�^�敪�P�p
        /// </summary>
        /// <param name="retList"></param>
        /// <param name="SalesTtlStSearchParaWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="readMode"></param>
        /// <param name="logicalMode"></param>
        /// <returns></returns>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>
        private int SearchForLinkDataCode1Proc(out ArrayList retList, PmtGeneralSrRstWork paraPmtGeneralSrRstWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retList = null;

            ArrayList arrayList = new ArrayList();

            try
            {
                StringBuilder sqlText = new StringBuilder();

                # region [SELECT��]
                sqlText.Append("SELECT" + Environment.NewLine);
                sqlText.Append("  CREATEDATETIMERF" + Environment.NewLine);
                sqlText.Append(", UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append(", ENTERPRISECODERF" + Environment.NewLine);
                sqlText.Append(", FILEHEADERGUIDRF" + Environment.NewLine);
                sqlText.Append(", UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlText.Append(", UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlText.Append(", UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlText.Append(", LOGICALDELETECODERF" + Environment.NewLine);
                sqlText.Append(", SEARCHSECTIONCODERF" + Environment.NewLine);
                sqlText.Append(", BUSINESSSESSIONIDRF" + Environment.NewLine);
                sqlText.Append(", LINKDATACODERF" + Environment.NewLine);
                sqlText.Append(", PMTABDTLDISCGUIDRF" + Environment.NewLine);
                sqlText.Append(", PMTABSEARCHROWNUMRF" + Environment.NewLine);
                sqlText.Append(", DATADELETEDATERF" + Environment.NewLine);
                sqlText.Append(", SALESEMPLOYEECDRF" + Environment.NewLine);
                sqlText.Append(", SALESEMPLOYEENMRF" + Environment.NewLine);
                sqlText.Append(", FRONTEMPLOYEECDRF" + Environment.NewLine);
                sqlText.Append(", FRONTEMPLOYEENMRF" + Environment.NewLine);
                sqlText.Append(", SALESINPUTCODERF" + Environment.NewLine);
                sqlText.Append(", SALESINPUTNAMERF" + Environment.NewLine);
                sqlText.Append("FROM" + Environment.NewLine);
                sqlText.Append("  PMTGENERALSRRSTRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append("WHERE" + Environment.NewLine);
                sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);
                sqlText.Append("  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine);
                sqlText.Append("  AND LINKDATACODERF = @FINDLINKDATACODE" + Environment.NewLine);
                sqlText.Append("  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine);
                sqlText.Append("  AND PMTABSEARCHROWNUMRF = @FINDPMTABSEARCHROWNUM" + Environment.NewLine);

                // Select�R�}���h�̐���
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //�f�[�^�Ǎ�
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlText.Append(" AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlText.Append(" AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine);
                }

                # endregion

                sqlCommand.CommandText = sqlText.ToString();

                // Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaBusinessSessionId = sqlCommand.Parameters.Add("@FINDBUSINESSSESSIONID", SqlDbType.NChar);
                SqlParameter findParaLinkDataCode = sqlCommand.Parameters.Add("@FINDLINKDATACODE", SqlDbType.Int);
                SqlParameter findParaPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@FINDPMTABDTLDISCGUID", SqlDbType.NChar);
                SqlParameter findParaPmTabSearchRowNum = sqlCommand.Parameters.Add("@FINDPMTABSEARCHROWNUM", SqlDbType.Int);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraPmtGeneralSrRstWork.EnterpriseCode);
                findParaBusinessSessionId.Value = SqlDataMediator.SqlSetString(paraPmtGeneralSrRstWork.BusinessSessionId);
                findParaLinkDataCode.Value = SqlDataMediator.SqlSetInt(1);
                findParaPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString("dummy");
                findParaPmTabSearchRowNum.Value = SqlDataMediator.SqlSetInt(-1);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt(paraPmtGeneralSrRstWork.LogicalDeleteCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    PmtGeneralSrRstWork pmtGeneralSetWork = new PmtGeneralSrRstWork();
                    this.ReaderToPmtGeneralSrRstWork(ref myReader, ref pmtGeneralSetWork);
                    arrayList.Add(pmtGeneralSetWork);
                }
                retList = arrayList;

                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }

            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�̃��[�J���V���N�p�f�[�^�̎擾�Ɏ��s���܂����B", ex.Number);
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
                    sqlCommand.Dispose();
                }
            }

            return status;

        }
        #endregion

        #region [Write]
        /// <summary>
        /// PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�X�V����
        /// �f�[�^�敪�P�p
        /// </summary>
        /// <param name="PmtGeneralSrRstWork">PmtGeneralSrRstWork�I�u�W�F�N�g</param>
        /// <param name="msgDiv">���b�Z�[�W�敪�@[True:���b�Z�[�W�L]</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^��o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>
        public int WriteForLinkDataCode1(ref object paraList, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            msgDiv = false;
            errMsg = string.Empty;
            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList pmtGeneralSetWorkList = paraList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // write���s
                status = this.WriteForLinkDataCode1Proc(ref pmtGeneralSetWorkList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                msgDiv = true;
                errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
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
        /// PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�X�V�������s��
        /// �f�[�^�敪�P�p
        /// </summary>
        /// <param name="PmtGeneralSrRstListWork">PmtGeneralSrRstWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^��o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>
        private int WriteForLinkDataCode1Proc(ref ArrayList pmtGeneralSrRstWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (pmtGeneralSrRstWorkList != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmtGeneralSrRstWorkList.Count; i++)
                    {
                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();

                        PmtGeneralSrRstWork pmtGeneralSrRstWork = pmtGeneralSrRstWorkList[i] as PmtGeneralSrRstWork;

                        # region [SELECT��]
                        sqlText = new StringBuilder();
                        sqlText.Append("SELECT UPDATEDATETIMERF" + Environment.NewLine);
                        sqlText.Append(" FROM PMTGENERALSRRSTRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                        sqlText.Append(" WHERE" + Environment.NewLine);
                        sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);
                        sqlText.Append("  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine);
                        sqlText.Append("  AND LINKDATACODERF = @FINDLINKDATACODE" + Environment.NewLine);
                        sqlText.Append("  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine);
                        sqlText.Append("  AND PMTABSEARCHROWNUMRF = @FINDPMTABSEARCHROWNUM" + Environment.NewLine);
                        # endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaBusinessSessionId = sqlCommand.Parameters.Add("@FINDBUSINESSSESSIONID", SqlDbType.NChar);
                        SqlParameter findParaLinkDataCode = sqlCommand.Parameters.Add("@FINDLINKDATACODE", SqlDbType.Int);
                        SqlParameter findParaPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@FINDPMTABDTLDISCGUID", SqlDbType.NChar);
                        SqlParameter findParaPmTabSearchRowNum = sqlCommand.Parameters.Add("@FINDPMTABSEARCHROWNUM", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.EnterpriseCode);
                        findParaBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.BusinessSessionId);
                        findParaLinkDataCode.Value = SqlDataMediator.SqlSetInt(1);
                        findParaPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString("dummy");
                        findParaPmTabSearchRowNum.Value = SqlDataMediator.SqlSetInt(-1);

                        sqlCommand.CommandText = sqlText.ToString();
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            # region [UPDATE��]
                            sqlText = new StringBuilder();
                            sqlText.Append("UPDATE PMTGENERALSRRSTRF" + Environment.NewLine);
                            sqlText.Append("SET UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine);
                            sqlText.Append(", ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine);
                            sqlText.Append(", UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine);
                            sqlText.Append(", UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine);
                            sqlText.Append(", UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine);
                            sqlText.Append(", LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine);
                            sqlText.Append(", SEARCHSECTIONCODERF = @SEARCHSECTIONCODE" + Environment.NewLine);
                            sqlText.Append(", BUSINESSSESSIONIDRF = @BUSINESSSESSIONID" + Environment.NewLine);
                            sqlText.Append(", LINKDATACODERF = @LINKDATACODE" + Environment.NewLine);
                            sqlText.Append(", PMTABDTLDISCGUIDRF = @PMTABDTLDISCGUID" + Environment.NewLine);
                            sqlText.Append(", PMTABSEARCHROWNUMRF = @PMTABSEARCHROWNUM" + Environment.NewLine);
                            sqlText.Append(", DATADELETEDATERF = @DATADELETEDATE" + Environment.NewLine);

                            if (!String.IsNullOrEmpty(pmtGeneralSrRstWork.SalesEmployeeCd))
                            {
                                sqlText.Append(", SALESEMPLOYEECDRF = @SALESEMPLOYEECD" + Environment.NewLine);
                                sqlText.Append(", SALESEMPLOYEENMRF = @SALESEMPLOYEENM" + Environment.NewLine);
                            }

                            if (!String.IsNullOrEmpty(pmtGeneralSrRstWork.FrontEmployeeCd))
                            {
                                sqlText.Append(", FRONTEMPLOYEECDRF = @FRONTEMPLOYEECD" + Environment.NewLine);
                                sqlText.Append(", FRONTEMPLOYEENMRF = @FRONTEMPLOYEENM" + Environment.NewLine);
                            }

                            if (!String.IsNullOrEmpty(pmtGeneralSrRstWork.SalesInputCode))
                            {
                                sqlText.Append(", SALESINPUTCODERF = @SALESINPUTCODE" + Environment.NewLine);
                                sqlText.Append(", SALESINPUTNAMERF = @SALESINPUTNAME" + Environment.NewLine);
                            }

                            sqlText.Append("WHERE" + Environment.NewLine);
                            sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);
                            sqlText.Append("  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine);
                            sqlText.Append("  AND LINKDATACODERF = @FINDLINKDATACODE" + Environment.NewLine);
                            sqlText.Append("  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine);
                            sqlText.Append("  AND PMTABSEARCHROWNUMRF = @FINDPMTABSEARCHROWNUM" + Environment.NewLine);

                            sqlCommand.CommandText = sqlText.ToString();

                            // Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.EnterpriseCode);
                            findParaBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.BusinessSessionId);
                            findParaLinkDataCode.Value = SqlDataMediator.SqlSetInt(1);
                            findParaPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString("dummy");
                            findParaPmTabSearchRowNum.Value = SqlDataMediator.SqlSetInt(-1);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmtGeneralSrRstWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            # endregion
                        }
                        else
                        {
                            # region [INSERT��]
                            sqlText = new StringBuilder();
                            sqlText.Append("INSERT INTO PMTGENERALSRRSTRF" + Environment.NewLine);
                            sqlText.Append("( CREATEDATETIMERF" + Environment.NewLine);
                            sqlText.Append(", UPDATEDATETIMERF" + Environment.NewLine);
                            sqlText.Append(", ENTERPRISECODERF" + Environment.NewLine);
                            sqlText.Append(", FILEHEADERGUIDRF" + Environment.NewLine);
                            sqlText.Append(", UPDEMPLOYEECODERF" + Environment.NewLine);
                            sqlText.Append(", UPDASSEMBLYID1RF" + Environment.NewLine);
                            sqlText.Append(", UPDASSEMBLYID2RF" + Environment.NewLine);
                            sqlText.Append(", LOGICALDELETECODERF" + Environment.NewLine);
                            sqlText.Append(", SEARCHSECTIONCODERF" + Environment.NewLine);
                            sqlText.Append(", BUSINESSSESSIONIDRF" + Environment.NewLine);
                            sqlText.Append(", LINKDATACODERF" + Environment.NewLine);
                            sqlText.Append(", PMTABDTLDISCGUIDRF" + Environment.NewLine);
                            sqlText.Append(", PMTABSEARCHROWNUMRF" + Environment.NewLine);
                            sqlText.Append(", DATADELETEDATERF" + Environment.NewLine);
                            sqlText.Append(", SALESEMPLOYEECDRF" + Environment.NewLine);
                            sqlText.Append(", SALESEMPLOYEENMRF" + Environment.NewLine);
                            sqlText.Append(", FRONTEMPLOYEECDRF" + Environment.NewLine);
                            sqlText.Append(", FRONTEMPLOYEENMRF" + Environment.NewLine);
                            sqlText.Append(", SALESINPUTCODERF" + Environment.NewLine);
                            sqlText.Append(", SALESINPUTNAMERF" + Environment.NewLine);
                            sqlText.Append(") " + Environment.NewLine);
                            sqlText.Append("VALUES " + Environment.NewLine);
                            sqlText.Append("(" + Environment.NewLine);
                            sqlText.Append(" @CREATEDATETIME" + Environment.NewLine);
                            sqlText.Append(", @UPDATEDATETIME" + Environment.NewLine);
                            sqlText.Append(", @ENTERPRISECODE" + Environment.NewLine);
                            sqlText.Append(", @FILEHEADERGUID" + Environment.NewLine);
                            sqlText.Append(", @UPDEMPLOYEECODE" + Environment.NewLine);
                            sqlText.Append(", @UPDASSEMBLYID1" + Environment.NewLine);
                            sqlText.Append(", @UPDASSEMBLYID2" + Environment.NewLine);
                            sqlText.Append(", @LOGICALDELETECODE" + Environment.NewLine);
                            sqlText.Append(", @SEARCHSECTIONCODE" + Environment.NewLine);
                            sqlText.Append(", @BUSINESSSESSIONID" + Environment.NewLine);
                            sqlText.Append(", @LINKDATACODE" + Environment.NewLine);
                            sqlText.Append(", @PMTABDTLDISCGUID" + Environment.NewLine);
                            sqlText.Append(", @PMTABSEARCHROWNUM" + Environment.NewLine);
                            sqlText.Append(", @DATADELETEDATE" + Environment.NewLine);
                            sqlText.Append(", @SALESEMPLOYEECD" + Environment.NewLine);
                            sqlText.Append(", @SALESEMPLOYEENM" + Environment.NewLine);
                            sqlText.Append(", @FRONTEMPLOYEECD" + Environment.NewLine);
                            sqlText.Append(", @FRONTEMPLOYEENM" + Environment.NewLine);
                            sqlText.Append(", @SALESINPUTCODE" + Environment.NewLine);
                            sqlText.Append(", @SALESINPUTNAME" + Environment.NewLine);
                            sqlText.Append(")" + Environment.NewLine);
                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmtGeneralSrRstWork;
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
                        SqlParameter paraSearchSectionCode = sqlCommand.Parameters.Add("@SEARCHSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraBusinessSessionId = sqlCommand.Parameters.Add("@BUSINESSSESSIONID", SqlDbType.NChar);
                        SqlParameter paraLinkDataCode = sqlCommand.Parameters.Add("@LINKDATACODE", SqlDbType.Int);
                        SqlParameter paraPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@PMTABDTLDISCGUID", SqlDbType.NChar);
                        SqlParameter paraPmTabSearchRowNum = sqlCommand.Parameters.Add("@PMTABSEARCHROWNUM", SqlDbType.Int);
                        SqlParameter paraDataDeleteDate = sqlCommand.Parameters.Add("@DATADELETEDATE", SqlDbType.Int);
                        SqlParameter paraSalesEmployeeCd = sqlCommand.Parameters.Add("@SALESEMPLOYEECD", SqlDbType.NChar);
                        SqlParameter paraSalesEmployeeNm = sqlCommand.Parameters.Add("@SALESEMPLOYEENM", SqlDbType.NVarChar);
                        SqlParameter paraFrontEmployeeCd = sqlCommand.Parameters.Add("@FRONTEMPLOYEECD", SqlDbType.NChar);
                        SqlParameter paraFrontEmployeeNm = sqlCommand.Parameters.Add("@FRONTEMPLOYEENM", SqlDbType.NVarChar);
                        SqlParameter paraSalesInputCode = sqlCommand.Parameters.Add("@SALESINPUTCODE", SqlDbType.NChar);
                        SqlParameter paraSalesInputName = sqlCommand.Parameters.Add("@SALESINPUTNAME", SqlDbType.NVarChar);
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmtGeneralSrRstWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmtGeneralSrRstWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pmtGeneralSrRstWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmtGeneralSrRstWork.LogicalDeleteCode);
                        paraSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.SearchSectionCode);
                        paraBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.BusinessSessionId);
                        paraLinkDataCode.Value = SqlDataMediator.SqlSetInt32(pmtGeneralSrRstWork.LinkDataCode);
                        paraPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.PmTabDtlDiscGuid);
                        paraPmTabSearchRowNum.Value = SqlDataMediator.SqlSetInt32(pmtGeneralSrRstWork.PmTabSearchRowNum);
                        paraDataDeleteDate.Value = SqlDataMediator.SqlSetInt32(pmtGeneralSrRstWork.DataDeleteDate);

                        if (!string.IsNullOrEmpty(pmtGeneralSrRstWork.SalesEmployeeCd))
                        {
                            paraSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.SalesEmployeeCd);
                            paraSalesEmployeeNm.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.SalesEmployeeNm);
                        }
                        else
                        {
                            paraSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(null);
                            paraSalesEmployeeNm.Value = SqlDataMediator.SqlSetString(null);
                        }

                        if (!string.IsNullOrEmpty(pmtGeneralSrRstWork.FrontEmployeeCd))
                        {
                            paraFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.FrontEmployeeCd);
                            paraFrontEmployeeNm.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.FrontEmployeeNm);
                        }
                        else
                        {
                            paraFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(null);
                            paraFrontEmployeeNm.Value = SqlDataMediator.SqlSetString(null);
                        }

                        if (!string.IsNullOrEmpty(pmtGeneralSrRstWork.SalesInputCode))
                        {
                            paraSalesInputCode.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.SalesInputCode);
                            paraSalesInputName.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.SalesInputName);
                        }
                        else
                        {
                            paraSalesInputCode.Value = SqlDataMediator.SqlSetString(null);
                            paraSalesInputName.Value = SqlDataMediator.SqlSetString(null);
                        }
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(pmtGeneralSrRstWork);
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
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            pmtGeneralSrRstWorkList = al;

            return status;
        }

        #endregion

        #region [Delete]
        /// <summary>
        /// PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�폜����
        /// �f�[�^�敪�P�p
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <param name="msgDiv">���b�Z�[�W�敪�@[True:���b�Z�[�W�L]</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�𕨗��폜���܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>
        /// </remarks>
        public int DeleteForLinkDataCode1(ref object paraList, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msgDiv = false;
            errMsg = string.Empty;

            ArrayList pmtGeneralSetWorkList = paraList as ArrayList;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                if (pmtGeneralSetWorkList != null && pmtGeneralSetWorkList.Count > 0)
                {
                    foreach (PmtGeneralSrRstWork pmtGeneralSetWork in pmtGeneralSetWorkList)
                    {
                        // Delete����
                        status = DeleteForLinkDataCode1Proc(pmtGeneralSetWork, ref sqlConnection, ref sqlTransaction);
                    }
                }


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
            catch (SqlException ex)
            {
                msgDiv = true;
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    errMsg = "PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�̍폜�������Ƀ^�C���A�E�g���������܂����B";
                else
                    errMsg = "PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�̍폜�����Ɏ��s���܂����B";
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();


                status = base.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
            }
            catch (Exception ex)
            {
                msgDiv = true;
                errMsg = "PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�̍폜�����Ɏ��s���܂����B";
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                base.WriteErrorLog(ex, errMsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                    sqlTransaction.Dispose();

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�폜�������s��
        /// �f�[�^�敪�P�p
        /// </summary>
        /// <param name="PmtGeneralSrRstWork">PmtGeneralSrRstWork</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�𕨗��폜���܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>
        /// </remarks>
        private int DeleteForLinkDataCode1Proc(PmtGeneralSrRstWork pmtGeneralSrRstWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                //Select�R�}���h�̐���
                #region [SELECT��]
                sqlText = new StringBuilder();
                sqlText.Append("SELECT" + Environment.NewLine);
                sqlText.Append("   UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("  ,LOGICALDELETECODERF" + Environment.NewLine);
                sqlText.Append(" FROM PMTGENERALSRRSTRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE" + Environment.NewLine);
                sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);
                sqlText.Append("  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine);
                sqlText.Append("  AND LINKDATACODERF = @FINDLINKDATACODE" + Environment.NewLine);
                sqlText.Append("  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine);
                sqlText.Append("  AND PMTABSEARCHROWNUMRF = @FINDPMTABSEARCHROWNUM" + Environment.NewLine);
                #endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaBusinessSessionId = sqlCommand.Parameters.Add("@FINDBUSINESSSESSIONID", SqlDbType.NChar);
                SqlParameter findParaLinkDataCode = sqlCommand.Parameters.Add("@FINDLINKDATACODE", SqlDbType.Int);
                SqlParameter findParaPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@FINDPMTABDTLDISCGUID", SqlDbType.NChar);
                SqlParameter findParaPmTabSearchRowNum = sqlCommand.Parameters.Add("@FINDPMTABSEARCHROWNUM", SqlDbType.Int);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.EnterpriseCode);
                findParaBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.BusinessSessionId);
                findParaLinkDataCode.Value = SqlDataMediator.SqlSetInt(1);
                findParaPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString("dummy");
                findParaPmTabSearchRowNum.Value = SqlDataMediator.SqlSetInt(-1);

                sqlCommand.CommandText = sqlText.ToString();

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != pmtGeneralSrRstWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }

                    //Delete�R�}���h�̐���
                    #region [DELETE��]
                    sqlText = new StringBuilder();
                    sqlText.Append("DELETE" + Environment.NewLine);
                    sqlText.Append(" FROM PMTGENERALSRRSTRF" + Environment.NewLine);
                    sqlText.Append(" WHERE" + Environment.NewLine);
                    sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);
                    sqlText.Append("  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine);
                    sqlText.Append("  AND LINKDATACODERF = @FINDLINKDATACODE" + Environment.NewLine);
                    sqlText.Append("  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine);
                    sqlText.Append("  AND PMTABSEARCHROWNUMRF = @FINDPMTABSEARCHROWNUM" + Environment.NewLine);
                    #endregion

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.EnterpriseCode);
                    findParaBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmtGeneralSrRstWork.BusinessSessionId);
                    findParaLinkDataCode.Value = SqlDataMediator.SqlSetInt(1);
                    findParaPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString("dummy");
                    findParaPmTabSearchRowNum.Value = SqlDataMediator.SqlSetInt(-1);

                    sqlCommand.CommandText = sqlText.ToString();

                }
                else
                {
                    // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                        myReader.Dispose();
                    }

                    return status;
                }

                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                if ((myReader != null) && (!myReader.IsClosed))
                {
                    myReader.Close();
                    myReader.Dispose();
                }

                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�̕����폜�Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�̕����폜�Ɏ��s���܂����B", status);
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
        #endregion �f�[�^�敪�P


        #region [PmtGeneralSrRst]
        /// <summary>
        /// PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�̓Ǎ�����(SqlDataReader)��PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^���[�N(PmtGeneralSrRstWork)�Ɋi�[���܂��B
        /// </summary>
        /// <param name="myReader">PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�̓Ǎ�����</param>
        /// <param name="PmtGeneralSrRstWork">PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^���[�N</param>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>
        private void ReaderToPmtGeneralSrRstWork(ref SqlDataReader myReader, ref PmtGeneralSrRstWork pmtGeneralSetWork)
        {
            if (myReader != null && pmtGeneralSetWork != null)
            {
                # region [�i�[����]
                pmtGeneralSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                pmtGeneralSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                pmtGeneralSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                pmtGeneralSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                pmtGeneralSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                pmtGeneralSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                pmtGeneralSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                pmtGeneralSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                pmtGeneralSetWork.SearchSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHSECTIONCODERF"));
                pmtGeneralSetWork.BusinessSessionId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSSESSIONIDRF"));
                pmtGeneralSetWork.LinkDataCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LINKDATACODERF"));
                pmtGeneralSetWork.PmTabDtlDiscGuid = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMTABDTLDISCGUIDRF"));
                pmtGeneralSetWork.PmTabSearchRowNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PMTABSEARCHROWNUMRF"));
                pmtGeneralSetWork.DataDeleteDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATADELETEDATERF"));
                pmtGeneralSetWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
                pmtGeneralSetWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
                pmtGeneralSetWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
                pmtGeneralSetWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
                pmtGeneralSetWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
                pmtGeneralSetWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
                # endregion
            }
        }
        #endregion

        #region [�R�l�N�V������������]

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_SCM_UserDB);
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

    }
}
