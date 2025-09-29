//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �t���E�����E�c�l�e�L�X�g�o��
// �v���O�����T�v   : �t���E�����E�c�l�e�L�X�g�o�͂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �C �� ��  2009/06/17  �C�����e : PVCS178 �����e�̔�����@�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : ���R
// �C �� ��  2009/06/17   �C�����e : ����f�[�^���������̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �C �� ��  2009/06/18  �C�����e : PVCS178 �����e�̔�����@�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �C �� ��  2009/06/19  �C�����e : PVCS163 �����e�X�g�d�l��_�Q���J���̗t��������DM÷�ďo��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �C �� ��  2009/06/19  �C�����e : PVCS215 �t���E�����E�c�l�e�L�X�g�o�͂̃����[�g�o�f�Ɋւ���
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �o�͐ݒ�DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�͐ݒ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2009.04.01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class UseMastDB : RemoteDB, IUseMastListDB
    {

        #region �� Public Methods

        /// <summary>
        /// ���Ӑ�f�[�^�̌�������
        /// </summary>
        /// <param name="ListRetWorkList">��������</param>
        /// <param name="ListParaWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�p�����[�^�̏����𖞂����S�Ă̔���f�[�^LIST��߂��܂�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        public int SearchCustomer(out object ListRetWorkList, object ListParaWork)
        {
            ListRetWorkList = null;
            ArrayList al = new ArrayList();
            // ���Ӑ挟��
            int status = SearchProc(out al, ListParaWork);
            ListRetWorkList = al;
            return status;
        }

        /// <summary>
        /// ���_�f�[�^�̌�������
        /// </summary>
        /// <param name="ListRetWorkList">��������</param>
        /// <param name="ListParaWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�p�����[�^�̏����𖞂����S�Ă̔���f�[�^LIST��߂��܂�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        public int SearchSecInfoSet(out object ListRetWorkList, object ListParaWork)
        {
            ListRetWorkList = null;
            ArrayList al = new ArrayList();
            // ���_����
            int status = SearchProc(out al, ListParaWork);
            ListRetWorkList = al;
            return status;
        }

        #endregion

        #region �� Private Methods

        /// <summary>
        /// �}�X�^�f�[�^�̌�������
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="ListParaWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�p�����[�^�̏����𖞂����S�Ă̔���f�[�^LIST��߂��܂�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        private int SearchProc(out ArrayList al, object ListParaWork)
        {
            int ret;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // ��������
            PostcardEnvelopeDMWork postcardEnvelopeDMWork = (PostcardEnvelopeDMWork)ListParaWork;

            //--------------------------
            // �p�����[�^��������
            //--------------------------
            al = new ArrayList();
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null) return status;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlRead = null;
            sqlConnection.Open();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                // ����SQL�̍쐬
                ret = MakeSqlCondition(ref sqlCommand, postcardEnvelopeDMWork);
                if (ret != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return ret;
                }
                // �f�[�^�ǂݍ��� Read
                sqlRead = sqlCommand.ExecuteReader();
                if (sqlRead.HasRows)
                {
                    while (sqlRead.Read())
                    {
                        // ���Ӑ�}�X�^
                        // MODIFY 2009/06/19 --->>>
                        // �t���E�����E�c�l�e�L�X�g�o�͂̃����[�g�o�f�Ɋւ���
                        //if (postcardEnvelopeDMWork.UseMast == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Customer)
                        if (postcardEnvelopeDMWork.UseMast == (int)PostcardEnvelopeDMWork.UseMastDivState.Customer)
                        // MODIFY 2009/06/19 ---<<<
                        {
                            al.Add(ReaderToCustomerSearchResultWork(ref sqlRead));
                        }
                        // ���_�}�X�^
                        // MODIFY 2009/06/19 --->>>
                        // �t���E�����E�c�l�e�L�X�g�o�͂̃����[�g�o�f�Ɋւ���
                        // else if (postcardEnvelopeDMWork.UseMast == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.SecInfo)
                        else if (postcardEnvelopeDMWork.UseMast == (int)PostcardEnvelopeDMWork.UseMastDivState.SecInfo)
                        // MODIFY 2009/06/19 ---<<<
                        {
                            al.Add(ReaderToSecInfoSetSearchResultWork(ref sqlRead));
                        }

                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "PostEnvelDMInstsMainAcs.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PostEnvelDMInstsMainAcs.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlRead != null)
                {
                    sqlRead.Close();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            return status;
        }

        /// <summary>
        /// �p�����[�^���A���I��FROM��AWHERE��𐶐�
        /// </summary>
        /// <param name="sqlCommond">SqlCommand �I�u�W�F�N�g</param>
        /// <param name="postcardEnvelopeDMWork">�����p�����[�^</param>
        /// <remarks>
        /// <br>Note       : SqlDataReader �� PostcardEnvelopeDMWork �ɕϊ�����</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private int MakeSqlCondition(ref SqlCommand sqlCommond, PostcardEnvelopeDMWork postcardEnvelopeDMWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            string fromSentance = string.Empty;

            if (IsValidParameter(postcardEnvelopeDMWork.UseMast))
            {
                // ���Ӑ�}�X�g
                // MODIFY 2009/06/19 --->>>
                // �t���E�����E�c�l�e�L�X�g�o�͂̃����[�g�o�f�Ɋւ���
                // if (postcardEnvelopeDMWork.UseMast == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Customer)
                if (postcardEnvelopeDMWork.UseMast == (int)PostcardEnvelopeDMWork.UseMastDivState.Customer)
                // MODIFY 2009/06/19 ---<<<
                {
                    string tempCtSql = "SELECT DISTINCT CU.MNGSECTIONCODERF, CU.CUSTOMERCODERF, CU.NAMERF, CU.NAME2RF, CU.POSTNORF, CU.ADDRESS1RF, CU.ADDRESS3RF, CU.ADDRESS4RF, CU.HOMETELNORF, CU.OFFICETELNORF, CU.OFFICEFAXNORF, CU.CUSTOMERAGENTRF"
                                + " FROM CUSTOMERRF CU WITH (READUNCOMMITTED)";
                    // �S�Ă̏ꍇ
                    // MODIFY 2009/06/19 --->>>
                    // �t���E�����E�c�l�e�L�X�g�o�͂̃����[�g�o�f�Ɋւ���
                    // if (postcardEnvelopeDMWork.OutShipDiv == (int)PostcardEnvelopeDMTextCndtn.OutShipDivState.All)
                    if (postcardEnvelopeDMWork.OutShipDiv == (int)PostcardEnvelopeDMWork.OutShipDivState.All)
                    // MODIFY 2009/06/19 ---<<<
                    {
                        //�@�����L��
                        postcardEnvelopeDMWork.OutShipDiv = 1;
                        //  �����L�莞��SQL��
                        fromSentance = tempCtSql;
                        MakeCustomerSqlCondition(ref fromSentance, ref sqlCommond, postcardEnvelopeDMWork);
                        //  �`�[�L�莞��SQL��
                        StringBuilder tempStr = new StringBuilder(fromSentance);
                        //  �`�[�L��
                        postcardEnvelopeDMWork.OutShipDiv = 2;
                        fromSentance = tempCtSql;
                        MakeCustomerSqlCondition(ref fromSentance, ref sqlCommond, postcardEnvelopeDMWork);
                        tempStr.Append(" UNION ");
                        // �����L�莞��SQL��+�`�[�L�莞��SQL��
                        tempStr.Append(fromSentance);
                        fromSentance = tempStr.ToString();
                    }
                    else
                    {
                        fromSentance = tempCtSql;
                        MakeCustomerSqlCondition(ref fromSentance, ref sqlCommond, postcardEnvelopeDMWork);
                    }
                    fromSentance += " ORDER BY CU.CUSTOMERCODERF ASC";

                }
                // ���_���}�X�g
                // MODIFY 2009/06/19 --->>>
                // �t���E�����E�c�l�e�L�X�g�o�͂̃����[�g�o�f�Ɋւ���
                //else if (postcardEnvelopeDMWork.UseMast == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.SecInfo)
                else if (postcardEnvelopeDMWork.UseMast == (int)PostcardEnvelopeDMWork.UseMastDivState.SecInfo)
                // MODIFY 2009/06/19 ---<<<
                {
                    fromSentance = "SELECT DISTINCT SE.SECTIONCODERF, CO.COMPANYNAME1RF, CO.COMPANYNAME2RF, CO.POSTNORF, CO.ADDRESS1RF, CO.ADDRESS3RF, CO.ADDRESS4RF, CO.COMPANYTELNO1RF, CO.COMPANYTELNO2RF, CO.COMPANYTELNO3RF "
                                            + " FROM COMPANYNMRF CO WITH (READUNCOMMITTED),SECINFOSETRF SE WITH (READUNCOMMITTED)"
                                            + " WHERE CO.LOGICALDELETECODERF = 0"
                                            + " AND SE.LOGICALDELETECODERF = 0"
                                            + " AND CO.ENTERPRISECODERF = SE.ENTERPRISECODERF"
                                            + " AND CO.COMPANYNAMECDRF = SE.COMPANYNAMECD1RF";
                    MakeSecInfoSqlCondition(ref fromSentance, ref sqlCommond, postcardEnvelopeDMWork);
                }
                sqlCommond.CommandText = fromSentance;
            }
            return status;
        }

        /// <summary>
        /// string���L���ȃp�����[�^���ǂ����𔻒f
        /// </summary>
        /// <param name="value">�����p�����[�^</param>
        /// <returns>�L�����ǂ����̔��f</returns>
        /// <remarks>
        /// <br>Note       : string���L���ȃp�����[�^���ǂ����𔻒f����</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private bool IsValidParameter(string value)
        {
            return !String.IsNullOrEmpty(value);
        }

        /// <summary>
        /// int���L���ȃp�����[�^���ǂ����𔻒f
        /// </summary>
        /// <param name="value">�����p�����[�^</param>
        /// <returns>�L�����ǂ����̔��f</returns>
        /// <remarks>
        /// <br>Note       : string���L���ȃp�����[�^���ǂ����𔻒f����</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private bool IsValidParameter(int value)
        {
            return value >= 0 ? true : false;
        }

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Note       : SqlConnection�𐶐�����</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (string.IsNullOrEmpty(connectionText)) return null;
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }

        /// <summary>
        /// �������ʁ�Work���[�h�I�u�W�F�N�g
        /// </summary>
        /// <param name="sqlRead">���o���� SqlDataReader</param>
        /// <returns>�f�[�^�Z�b�g�ς� SalesDetailsSearchWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : SqlDataReader �� SalesDetailsSearchWork �ɕϊ�����</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private PostCustomerWork ReaderToCustomerSearchResultWork(ref SqlDataReader sqlRead)
        {
            PostCustomerWork customerWork = new PostCustomerWork();
            customerWork.MngSectionCode = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("MNGSECTIONCODERF"));
            customerWork.CustomerCode = SqlDataMediator.SqlGetInt32(sqlRead, sqlRead.GetOrdinal("CUSTOMERCODERF"));
            customerWork.Name = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("NAMERF"));
            customerWork.Name2 = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("NAME2RF"));
            customerWork.PostNo = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("POSTNORF"));
            customerWork.Address1 = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("ADDRESS1RF"));
            customerWork.Address3 = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("ADDRESS3RF"));
            customerWork.Address4 = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("ADDRESS4RF"));
            customerWork.HomeTelNo = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("HOMETELNORF"));
            customerWork.OfficeTelNo = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("OFFICETELNORF"));
            customerWork.OfficeFaxNo = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("OFFICEFAXNORF"));
            customerWork.CustomerAgent = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("CUSTOMERAGENTRF"));
            return customerWork;
        }

        /// <summary>
        /// �������ʁ�Work���[�h�I�u�W�F�N�g
        /// </summary>
        /// <param name="sqlRead">���o���� SqlDataReader</param>
        /// <returns>�f�[�^�Z�b�g�ς� SalesDetailsSearchWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : SqlDataReader �� SalesDetailsSearchWork �ɕϊ�����</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private PostSecInfoSetWork ReaderToSecInfoSetSearchResultWork(ref SqlDataReader sqlRead)
        {
            PostSecInfoSetWork secInfoSetWork = new PostSecInfoSetWork();
            secInfoSetWork.SectionCode = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("SECTIONCODERF"));
            secInfoSetWork.CompanyName1 = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("COMPANYNAME1RF"));
            secInfoSetWork.CompanyName2 = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("COMPANYNAME2RF"));
            secInfoSetWork.PostNo = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("POSTNORF"));
            secInfoSetWork.Address1 = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("ADDRESS1RF"));
            secInfoSetWork.Address3 = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("ADDRESS3RF"));
            secInfoSetWork.Address4 = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("ADDRESS4RF"));
            secInfoSetWork.CompanyTelNo1 = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("COMPANYTELNO1RF"));
            secInfoSetWork.CompanyTelNo2 = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("COMPANYTELNO2RF"));
            secInfoSetWork.CompanyTelNo3 = SqlDataMediator.SqlGetString(sqlRead, sqlRead.GetOrdinal("COMPANYTELNO3RF"));
            return secInfoSetWork;
        }

        /// <summary>
        /// ���_���SQL��WHERE��𐶐�
        /// </summary>
        /// <param name="fromSentance">Sql��</param>
        /// <param name="sqlCommond">SqlCommand �I�u�W�F�N�g</param>
        /// <param name="postcardEnvelopeDMWork">�����p�����[�^</param>
        /// <remarks>
        /// <br>Note       : SqlDataReader �� PostcardEnvelopeDMWork �ɕϊ�����</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void MakeSecInfoSqlCondition(ref string fromSentance, ref SqlCommand sqlCommond, PostcardEnvelopeDMWork postcardEnvelopeDMWork)
        {
            StringBuilder builder = new StringBuilder(fromSentance);
            // ��ƃR�[�h
            if (IsValidParameter(postcardEnvelopeDMWork.EnterpriseCode))
            {
                builder.Append(" AND SE.ENTERPRISECODERF=@FINDENTERPRISECODE");
                SqlParameter enterprisecoderf = sqlCommond.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                enterprisecoderf.Value = SqlDataMediator.SqlSetString(postcardEnvelopeDMWork.EnterpriseCode);
            }
            // ���_�R�[�h
            if (IsValidParameter(postcardEnvelopeDMWork.St_SectionCode))
            {
                builder.Append(" AND SE.SECTIONCODERF >= @FINDSTSECTIONCODERF" + postcardEnvelopeDMWork.UseMast);
                SqlParameter stCustomerCode = sqlCommond.Parameters.Add("@FINDSTSECTIONCODERF" + postcardEnvelopeDMWork.UseMast, SqlDbType.NChar);
                stCustomerCode.Value = SqlDataMediator.SqlSetString(postcardEnvelopeDMWork.St_SectionCode);
            }
            if (IsValidParameter(postcardEnvelopeDMWork.Ed_SectionCode))
            {
                builder.Append(" AND SE.SECTIONCODERF <= @FINDEDSECTIONCODERF" + postcardEnvelopeDMWork.UseMast);
                SqlParameter edCustomerCode = sqlCommond.Parameters.Add("@FINDEDSECTIONCODERF" + postcardEnvelopeDMWork.UseMast, SqlDbType.NChar);
                edCustomerCode.Value = SqlDataMediator.SqlSetString(postcardEnvelopeDMWork.Ed_SectionCode);
            }
            builder.Append(" ORDER BY SE.SECTIONCODERF ASC");
            fromSentance = builder.ToString();
        }

        /// <summary>
        /// ���Ӑ�SQL��WHERE��𐶐�
        /// </summary>
        /// <param name="fromSentance">Sql��</param>
        /// <param name="sqlCommond">SqlCommand �I�u�W�F�N�g</param>
        /// <param name="postcardEnvelopeDMWork">�����p�����[�^</param>
        /// <remarks>
        /// <br>Note       : SqlDataReader �� PostcardEnvelopeDMWork �ɕϊ�����</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void MakeCustomerSqlCondition(ref string fromSentance, ref SqlCommand sqlCommond, PostcardEnvelopeDMWork postcardEnvelopeDMWork)
        {
            StringBuilder builder = new StringBuilder(fromSentance);
            // MODIFY 2009/06/19 --->>>
            // �t���E�����E�c�l�e�L�X�g�o�͂̃����[�g�o�f�Ɋւ���
            // if (postcardEnvelopeDMWork.OutShipDiv == (int)PostcardEnvelopeDMTextCndtn.OutShipDivState.Claim)
            if (postcardEnvelopeDMWork.OutShipDiv == (int)PostcardEnvelopeDMWork.OutShipDivState.Claim)
            // MODIFY 2009/06/19 ---<<<
            {
                builder.Append(", CUSTDMDPRCRF DM WITH (READUNCOMMITTED) WHERE ");
                builder.Append(" CU.ENTERPRISECODERF= DM.ENTERPRISECODERF ");
                builder.Append(" AND CU.CUSTOMERCODERF = DM.CLAIMCODERF ");
                builder.Append(" AND CU.LOGICALDELETECODERF = 0 ");
                builder.Append(" AND DM.LOGICALDELETECODERF = 0");
                // DELETE 2009/06/17 --->>>
                // �����e�̔�����@�ύX
                // builder.Append(" AND CU.MNGSECTIONCODERF = CU.CLAIMSECTIONCODERF");
                // DELETE 2009/06/17 ---<<<
                builder.Append(" AND CU.CUSTOMERCODERF = CU.CLAIMCODERF");
                // DELETE 2009/06/19 --->>>
                // �����e�X�g�d�l��_�Q���J���̗t��������DM÷�ďo��
                //builder.Append(" AND CU.CLAIMSECTIONCODERF = DM.ADDUPSECCODERF");
                // DELETE 2009/06/19 ---<<<
                builder.Append(" AND DM.RESULTSSECTCDRF = 0");
                builder.Append(" AND CU.ACCRECDIVCDRF = 1");
                builder.Append(" AND (DM.LASTTIMEDEMANDRF != 0");
                builder.Append(" OR DM.ACPODRTTL2TMBFBLDMDRF !=0");
                builder.Append(" OR DM.ACPODRTTL3TMBFBLDMDRF !=0");
                builder.Append(" OR DM.SALESSLIPCOUNTRF !=0");
                builder.Append(" OR DM.THISTIMESALESRF != 0");
                builder.Append(" OR DM.THISSALESTAXRF != 0");
                builder.Append(" OR DM.THISSALESPRICRGDSRF !=0");
                builder.Append(" OR DM.THISSALESPRCTAXRGDSRF != 0");
                builder.Append(" OR DM.THISSALESPRICDISRF != 0");
                builder.Append(" OR DM.THISSALESPRCTAXDISRF != 0");
                builder.Append(" OR DM.THISTIMEDMDNRMLRF != 0)");
                if (postcardEnvelopeDMWork.TotalDay != DateTime.MinValue)
                {
                    // ����
                    builder.Append(" AND DM.ADDUPDATERF=@FINDADDUPDATERF");
                    SqlParameter enterprisecoderf1 = sqlCommond.Parameters.Add("@FINDADDUPDATERF", SqlDbType.Int);
                    enterprisecoderf1.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(postcardEnvelopeDMWork.TotalDay);
                }
                // ADD 2009/06/18 --->>>
                // �����e�̔�����@�ύX
                // ���_�R�[�h
                if (IsValidParameter(postcardEnvelopeDMWork.St_SectionCode))
                {
                    // MODIFY 2009/06/19 --->>>
                    // �����e�X�g�d�l��_�Q���J���̗t��������DM÷�ďo��
                    // builder.Append(" AND CU.CLAIMSECTIONCODERF >= @FINDSTCLAIMSECTIONCODERF" + postcardEnvelopeDMWork.OutShipDiv);
                    builder.Append(" AND DM.ADDUPSECCODERF >= @FINDSTCLAIMSECTIONCODERF" + postcardEnvelopeDMWork.OutShipDiv);
                    // MODIFY 2009/06/19 ---<<<
                    SqlParameter stCustomerCode = sqlCommond.Parameters.Add("@FINDSTCLAIMSECTIONCODERF" + postcardEnvelopeDMWork.OutShipDiv, SqlDbType.NChar);
                    stCustomerCode.Value = SqlDataMediator.SqlSetString(postcardEnvelopeDMWork.St_SectionCode);
                }
                if (IsValidParameter(postcardEnvelopeDMWork.Ed_SectionCode))
                {
                    // MODIFY 2009/06/19 --->>>
                    // �����e�X�g�d�l��_�Q���J���̗t��������DM÷�ďo��
                    // builder.Append(" AND CU.CLAIMSECTIONCODERF <= @FINDEDCLAIMSECTIONCODERF" + postcardEnvelopeDMWork.OutShipDiv);
                    builder.Append(" AND DM.ADDUPSECCODERF <= @FINDEDCLAIMSECTIONCODERF" + postcardEnvelopeDMWork.OutShipDiv);
                    // MODIFY 2009/06/19 ---<<<
                    SqlParameter edCustomerCode = sqlCommond.Parameters.Add("@FINDEDCLAIMSECTIONCODERF" + postcardEnvelopeDMWork.OutShipDiv, SqlDbType.NChar);
                    edCustomerCode.Value = SqlDataMediator.SqlSetString(postcardEnvelopeDMWork.Ed_SectionCode);
                }
                // ADD 2009/06/18 ---<<<
            }
            // MODIFY 2009/06/19 --->>>
            // �t���E�����E�c�l�e�L�X�g�o�͂̃����[�g�o�f�Ɋւ���
            // else if (postcardEnvelopeDMWork.OutShipDiv == (int)PostcardEnvelopeDMTextCndtn.OutShipDivState.Slip)
            else if (postcardEnvelopeDMWork.OutShipDiv == (int)PostcardEnvelopeDMWork.OutShipDivState.Slip)
            // MODIFY 2009/06/19 ---<<<
            {
                builder.Append(", SALESSLIPRF SA WITH (READUNCOMMITTED) WHERE ");
                builder.Append(" CU.ENTERPRISECODERF= SA.ENTERPRISECODERF ");
                builder.Append(" AND CU.CUSTOMERCODERF = SA.CUSTOMERCODERF ");
                builder.Append(" AND CU.LOGICALDELETECODERF = 0 ");
                builder.Append(" AND SA.LOGICALDELETECODERF = 0");
                // ADD 2009/06/17 --->>>
                // ����f�[�^���������̒ǉ�
                builder.Append(" AND SA.ACPTANODRSTATUSRF = 30");
                // ADD 2009/06/17 ---<<<

                // DELETE 2009/06/17 --->>>
                // �����e�̔�����@�ύX
                // builder.Append(" AND CU.MNGSECTIONCODERF = CU.CLAIMSECTIONCODERF");
                // DELETE 2009/06/17 ---<<<
                builder.Append(" AND CU.CUSTOMERCODERF = CU.CLAIMCODERF");
                // MODIFY 2009/06/17 --->>>
                // �����e�̔�����@�ύX
                // builder.Append(" AND CU.MNGSECTIONCODERF = SA.SALESINPSECCDRF");
                // DELETE 2009/06/19 --->>>
                // �����e�X�g�d�l��_�Q���J���̗t��������DM÷�ďo��
                // builder.Append(" AND CU.MNGSECTIONCODERF = SA.RESULTSADDUPSECCDRF");
                // DELETE 2009/06/19 ---<<<
                // MODIFY 2009/06/17 ---<<<
                if (postcardEnvelopeDMWork.St_AddUpDay != DateTime.MinValue)
                {
                    // B.������t>=�p�����[�^.�Ώۓ��t(�J�n)
                    builder.Append(" AND SA.SALESDATERF >= @FINDSTSALESDATERF");
                    SqlParameter stAddUpADate = sqlCommond.Parameters.Add("@FINDSTSALESDATERF", SqlDbType.Int);
                    stAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(postcardEnvelopeDMWork.St_AddUpDay);
                }

                if (postcardEnvelopeDMWork.Ed_AddUpDay != DateTime.MinValue)
                {
                    // B.������t<=�p�����[�^.�Ώۓ��t(�I��))
                    builder.Append(" AND SA.SALESDATERF <= @FINDEDSALESDATERF");
                    SqlParameter edAddUpADate = sqlCommond.Parameters.Add("@FINDEDSALESDATERF", SqlDbType.Int);
                    edAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(postcardEnvelopeDMWork.Ed_AddUpDay);
                }
                // ADD 2009/06/18 --->>>
                // �����e�̔�����@�ύX
                // ���_�R�[�h
                if (IsValidParameter(postcardEnvelopeDMWork.St_SectionCode))
                {
                    // MODIFY 2009/06/19 --->>>
                    // �����e�X�g�d�l��_�Q���J���̗t��������DM÷�ďo��
                    //builder.Append(" AND CU.MNGSECTIONCODERF >= @FINDSTMNGSECTIONCODERF" + postcardEnvelopeDMWork.OutShipDiv);
                    builder.Append(" AND SA.RESULTSADDUPSECCDRF >= @FINDSTMNGSECTIONCODERF" + postcardEnvelopeDMWork.OutShipDiv);
                    // MODIFY 2009/06/19 ---<<<
                    SqlParameter stCustomerCode = sqlCommond.Parameters.Add("@FINDSTMNGSECTIONCODERF" + postcardEnvelopeDMWork.OutShipDiv, SqlDbType.NChar);
                    stCustomerCode.Value = SqlDataMediator.SqlSetString(postcardEnvelopeDMWork.St_SectionCode);
                }
                if (IsValidParameter(postcardEnvelopeDMWork.Ed_SectionCode))
                {
                    // MODIFY 2009/06/19 --->>>
                    // �����e�X�g�d�l��_�Q���J���̗t��������DM÷�ďo��
                    //builder.Append(" AND CU.MNGSECTIONCODERF <= @FINDEDMNGSECTIONCODERF" + postcardEnvelopeDMWork.OutShipDiv);
                    builder.Append(" AND SA.RESULTSADDUPSECCDRF <= @FINDEDMNGSECTIONCODERF" + postcardEnvelopeDMWork.OutShipDiv);
                    // MODIFY 2009/06/19 ---<<<
                    SqlParameter edCustomerCode = sqlCommond.Parameters.Add("@FINDEDMNGSECTIONCODERF" + postcardEnvelopeDMWork.OutShipDiv, SqlDbType.NChar);
                    edCustomerCode.Value = SqlDataMediator.SqlSetString(postcardEnvelopeDMWork.Ed_SectionCode);
                }
                // ADD 2009/06/18 ---<<<
            }

            // ��ƃR�[�h
            if (IsValidParameter(postcardEnvelopeDMWork.EnterpriseCode))
            {
                builder.Append(" AND CU.ENTERPRISECODERF=@FINDENTERPRISECODE" + postcardEnvelopeDMWork.OutShipDiv);
                SqlParameter enterprisecoderf = sqlCommond.Parameters.Add("@FINDENTERPRISECODE" + postcardEnvelopeDMWork.OutShipDiv, SqlDbType.NChar);
                enterprisecoderf.Value = SqlDataMediator.SqlSetString(postcardEnvelopeDMWork.EnterpriseCode);
            }
            // DELETE 2009/06/18 --->>>
            // �����e�̔�����@�ύX
            // ���_�R�[�h
            //if (IsValidParameter(postcardEnvelopeDMWork.St_SectionCode))
            //{
            //    builder.Append(" AND CU.MNGSECTIONCODERF >= @FINDSTMNGSECTIONCODERF" + postcardEnvelopeDMWork.OutShipDiv);
            //    SqlParameter stCustomerCode = sqlCommond.Parameters.Add("@FINDSTMNGSECTIONCODERF" + postcardEnvelopeDMWork.OutShipDiv, SqlDbType.NChar);
            //    stCustomerCode.Value = SqlDataMediator.SqlSetString(postcardEnvelopeDMWork.St_SectionCode);
            //}
            //if (IsValidParameter(postcardEnvelopeDMWork.Ed_SectionCode))
            //{
            //    builder.Append(" AND CU.MNGSECTIONCODERF <= @FINDEDMNGSECTIONCODERF" + postcardEnvelopeDMWork.OutShipDiv);
            //    SqlParameter edCustomerCode = sqlCommond.Parameters.Add("@FINDEDMNGSECTIONCODERF" + postcardEnvelopeDMWork.OutShipDiv, SqlDbType.NChar);
            //    edCustomerCode.Value = SqlDataMediator.SqlSetString(postcardEnvelopeDMWork.Ed_SectionCode);
            //}
            // DELETE 2009/06/18 ---<<<
            // ���Ӑ�R�[�h
            if (postcardEnvelopeDMWork.St_CustomerCode != 0)
            {
                builder.Append(" AND CU.CUSTOMERCODERF >= @FINDSTCUSTOMERCODERF" + postcardEnvelopeDMWork.OutShipDiv);
                SqlParameter stCustomerCode = sqlCommond.Parameters.Add("@FINDSTCUSTOMERCODERF" + postcardEnvelopeDMWork.OutShipDiv, SqlDbType.Int);
                stCustomerCode.Value = SqlDataMediator.SqlSetInt32(postcardEnvelopeDMWork.St_CustomerCode);
            }
            if (postcardEnvelopeDMWork.Ed_CustomerCode != 0)
            {
                builder.Append(" AND CU.CUSTOMERCODERF <= @FINDEDCUSTOMERCODERF" + postcardEnvelopeDMWork.OutShipDiv);
                SqlParameter edCustomerCode = sqlCommond.Parameters.Add("@FINDEDCUSTOMERCODERF" + postcardEnvelopeDMWork.OutShipDiv, SqlDbType.Int);
                edCustomerCode.Value = SqlDataMediator.SqlSetInt32(postcardEnvelopeDMWork.Ed_CustomerCode);
            }
            fromSentance = builder.ToString();
        }

        #endregion
    }
}
