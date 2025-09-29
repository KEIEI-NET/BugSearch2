//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �S���ҕʎ��яƉ�
// �v���O�����T�v   : �S���ҕʎ��яƉ�ꗗ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���J��
// �C �� ��  2010/07/20  �C�����e : �e�L�X�g�o��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : chenyd
// �C �� ��  2010/08/12  �C�����e : ��QID:13038�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �C �� ��  2010/10/09  �C�����e : ��QID:15880�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : ������
// �C �� ��  2011/03/22  �C�����e : �Ɖ�v���O�����̃��O�o�͑Ή�
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


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �S���ҕʎ��яƉ� �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �S���ҕʎ��яƉ���f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.04.01</br>
    /// <br>Update Note: 2010/08/12 chenyd</br>
    /// <br>            �E��QID:13038 �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2010/08/17�A 2010/08/20�@chenyd</br>
    /// <br>            �E��QID:13038 �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2011/03/22 ������</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class EmployeeResultsListWorkDB : RemoteDB, IEmployeeResultsListDB
    {
        #region Const
        /// <summary> �S�ЃR�[�h [00] </summary>
        private const string WHOLE_SECTION_CODE = "00";
        /// <summary> ���o�^ </summary>
        private const string NOINPUT = "���o�^";
        #endregion

        /// <summary>
        /// �S���ҕʎ��яƉ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public EmployeeResultsListWorkDB()
            :
        base("PMHNB04167D", "Broadleaf.Application.Remoting.ParamData.EmployeeResultsListResultWork", "EmployeeResults") //���N���X�̃R���X�g���N�^
        {
        }

        #region �S���ҕʎ��яƉ�
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̒S���ҕʎ��яƉ�LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="employeeResultsListResultWork">��������</param>
        /// <param name="employeeResultsListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̒S���ҕʎ��яƉ�LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        public int Search(out object employeeResultsListResultWork, object employeeResultsListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            employeeResultsListResultWork = null;

            EmployeeResultsListCndtnWork _employeeResultsListCndtnWork = employeeResultsListCndtnWork as EmployeeResultsListCndtnWork;

            try
            {
                status = SearchProc(out employeeResultsListResultWork, _employeeResultsListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeResultsListWorkDB.Search Exception=" + ex.Message);
                employeeResultsListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̒S���ҕʎ��яƉ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="employeeResultsListResultWork">��������</param>
        /// <param name="_employeeResultsListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̒S���ҕʎ��яƉ�LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2011/03/22 ������</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        /// <br></br>
        private int SearchProc(out object employeeResultsListResultWork, EmployeeResultsListCndtnWork _employeeResultsListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            employeeResultsListResultWork = null;

            ArrayList al = new ArrayList();   //���o����

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();


                // ---ADD 2011/03/22---------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _employeeResultsListCndtnWork.EnterpriseCode, "�S���ҕʎ��яƉ�", "���o�J�n");
                // ---ADD 2011/03/22----------<<<<<

                status = SearchEmployeeResultsProc(ref al, ref sqlConnection, _employeeResultsListCndtnWork, logicalMode);

                // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _employeeResultsListCndtnWork.EnterpriseCode, "�S���ҕʎ��яƉ�", "���o�I��");
                // ---ADD 2011/03/22----------<<<<<
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeResultsListWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            employeeResultsListResultWork = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_employeeResultsListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2010/08/12 chenyd</br>
        /// <br>            �E��QID:13038 �e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: 2010/08/17 chenyd</br>
        /// <br>            �E��QID:13038 �e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: 2010/10/09 �� ��</br>
        /// <br>            �E��QID:15880 �e�L�X�g�o�͑Ή�</br>
        private int SearchEmployeeResultsProc(ref ArrayList al, ref SqlConnection sqlConnection, EmployeeResultsListCndtnWork _employeeResultsListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand(string.Empty, sqlConnection);

                StringBuilder sqlCmd = new StringBuilder(string.Empty);
                if (1 == _employeeResultsListCndtnWork.DuringType)
                {
                    #region ���v Select���쐬
                    sqlCmd.Append(" SELECT");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //���_�R�[�h
                    //    sqlCmd.Append(" A.SECTIONCODE, ");
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        //���_�R�[�h
                        sqlCmd.Append(" A.SECTIONCODE, ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    //�R�[�h
                    sqlCmd.Append(" A.TMPEMPLOYEECODE AS CODE, ");
                    //������z
                    sqlCmd.Append(" (A.SUMSALES + B.SUMSUMSALESB) AS SUMMONEY, ");
                    //�ԕi�z
                    sqlCmd.Append(" (A.SUMRETURNGOODS + B.SUMRETURNGOODSB) AS RETURNMONEY, ");
                    //�l���z
                    sqlCmd.Append(" B.SUMSALESMONEYTAXEXCRFB AS  SUMSALESMONEYTAXEXCRFB, ");
                    //�`�[����
                    sqlCmd.Append(" A.TMPSALESSLIPNUMRF AS TMPSALESSLIPNUMRF, ");
                    //����ڕW�z
                    sqlCmd.Append(" C.SUMSALESTARGETMONEYRF AS SUMSALESTARGETMONEYRF, ");
                    //����
                    sqlCmd.Append(" D.NAMERF AS NAMERF, ");
                    //����
                    sqlCmd.Append(" A.SUMTOTALCOSTRF AS SUMTOTALCOSTRF ");

                    sqlCmd.Append(" FROM");
                    sqlCmd.Append(" (SELECT ");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //���_�R�[�h
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //sqlCmd.Append(" SECTIONCODERF AS SECTIONCODE, ");
                    //    sqlCmd.Append(" RESULTSADDUPSECCDRF AS SECTIONCODE, ");
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        sqlCmd.Append(" RESULTSADDUPSECCDRF AS SECTIONCODE, ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    if (_employeeResultsListCndtnWork.ReferType == 1)
                    {
                        //�S����
                        //sqlCmd.Append(" SALESINPUTCODERF AS TMPEMPLOYEECODE, ");// DEL 2010/08/12 ��QID:13038�Ή�
                        sqlCmd.Append(" SALESEMPLOYEECDRF AS TMPEMPLOYEECODE, ");// ADD 2010/08/12 ��QID:13038�Ή�
                    }
                    else if (_employeeResultsListCndtnWork.ReferType == 2)
                    {
                        //�󒍎�
                        sqlCmd.Append(" FRONTEMPLOYEECDRF AS TMPEMPLOYEECODE, ");

                    }
                    else if (_employeeResultsListCndtnWork.ReferType == 3)
                    {
                        //���s��
                        //sqlCmd.Append(" SALESEMPLOYEECDRF AS TMPEMPLOYEECODE, ");
                        sqlCmd.Append(" SALESINPUTCODERF AS TMPEMPLOYEECODE, ");

                    }

                    sqlCmd.Append(" SUM(CASE WHEN SALESSLIPCDRF=0 AND SALESGOODSCDRF =0 THEN SALESNETPRICERF ELSE 0 END) AS SUMSALES, ");
                    sqlCmd.Append(" SUM(CASE WHEN SALESSLIPCDRF=1 AND SALESGOODSCDRF =0 THEN SALESNETPRICERF ELSE 0 END) AS SUMRETURNGOODS, ");
                    sqlCmd.Append(" COUNT(SALESSLIPNUMRF) AS TMPSALESSLIPNUMRF,");
                    sqlCmd.Append(" SUM(TOTALCOSTRF) AS SUMTOTALCOSTRF");
                    sqlCmd.Append(" FROM SALESHISTORYRF");
                    MakeWhereString_SalesHis(ref sqlCommand, _employeeResultsListCndtnWork, "", sqlCmd, 0);

                    sqlCmd.Append(" ) AS A");
                    sqlCmd.Append(" LEFT OUTER JOIN ");
                    sqlCmd.Append(" (SELECT");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //���_�R�[�h
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //sqlCmd.Append(" E.SECTIONCODERF AS SECTIONCODE, ");// DEL 2010/08/12 ��QID:13038�Ή�
                    //    sqlCmd.Append(" E.RESULTSADDUPSECCDRF AS SECTIONCODE, ");// ADD 2010/08/12 ��QID:13038�Ή�
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        sqlCmd.Append(" E.RESULTSADDUPSECCDRF AS SECTIONCODE, ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    if (_employeeResultsListCndtnWork.ReferType == 1)
                    {
                        //�S����
                        //sqlCmd.Append(" E.SALESINPUTCODERF AS TMPEMPLOYEECODE, ");
                        sqlCmd.Append(" E.SALESEMPLOYEECDRF AS TMPEMPLOYEECODE, ");
                    }
                    else if (_employeeResultsListCndtnWork.ReferType == 2)
                    {
                        //�󒍎�
                        sqlCmd.Append(" E.FRONTEMPLOYEECDRF AS TMPEMPLOYEECODE, ");

                    }
                    else if (_employeeResultsListCndtnWork.ReferType == 3)
                    {
                        //���s��
                        //sqlCmd.Append(" E.SALESEMPLOYEECDRF AS TMPEMPLOYEECODE, ");
                        sqlCmd.Append(" E.SALESINPUTCODERF AS TMPEMPLOYEECODE, ");

                    }
                    sqlCmd.Append(" SUM(CASE WHEN E.SALESSLIPCDRF=0 AND E.SALESGOODSCDRF =0 AND F.SALESSLIPCDDTLRF=2 AND F.SHIPMENTCNTRF =0 THEN F.SALESMONEYTAXEXCRF ELSE 0 END) AS SUMSUMSALESB, ");
                    sqlCmd.Append(" SUM(CASE WHEN E.SALESSLIPCDRF=1 AND E.SALESGOODSCDRF =0 AND F.SALESSLIPCDDTLRF=2 AND F.SHIPMENTCNTRF =0 THEN F.SALESMONEYTAXEXCRF ELSE 0 END) AS SUMRETURNGOODSB, ");
                    sqlCmd.Append(" SUM(CASE WHEN (E.SALESSLIPCDRF=0 OR E.SALESSLIPCDRF=1) AND E.SALESGOODSCDRF =0 AND F.SALESSLIPCDDTLRF=2 AND F.SHIPMENTCNTRF <>0 THEN F.SALESMONEYTAXEXCRF ELSE 0 END) AS SUMSALESMONEYTAXEXCRFB");
                    sqlCmd.Append(" FROM SALESHISTORYRF AS E ");
                    sqlCmd.Append(" LEFT OUTER JOIN SALESHISTDTLRF AS F ");
                    sqlCmd.Append(" ON E.ENTERPRISECODERF=F.ENTERPRISECODERF ");
                    sqlCmd.Append(" AND E.LOGICALDELETECODERF=F.LOGICALDELETECODERF ");
                    sqlCmd.Append(" AND E.ACPTANODRSTATUSRF=F.ACPTANODRSTATUSRF ");
                    sqlCmd.Append(" AND E.SALESSLIPNUMRF=F.SALESSLIPNUMRF ");
                    MakeWhereString_SalesHis(ref sqlCommand, _employeeResultsListCndtnWork, "E.", sqlCmd, 1);
                    sqlCmd.Append(" )AS B ");
                    sqlCmd.Append(" ON A.TMPEMPLOYEECODE = B.TMPEMPLOYEECODE ");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //���_�R�[�h
                    //    sqlCmd.Append(" AND A.SECTIONCODE = B.SECTIONCODE ");
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        //���_�R�[�h
                        sqlCmd.Append(" AND A.SECTIONCODE = B.SECTIONCODE ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    sqlCmd.Append(" LEFT OUTER JOIN ");
                    sqlCmd.Append(" (SELECT ");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    sqlCmd.Append(" SECTIONCODERF, ");
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        sqlCmd.Append(" SECTIONCODERF, ");
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    sqlCmd.Append(" EMPLOYEECODERF, ");
                    sqlCmd.Append(" SUM(SALESTARGETMONEYRF) AS SUMSALESTARGETMONEYRF ");
                    sqlCmd.Append(" FROM EMPSALESTARGETRF ");
                    MakeWhereString_Emp(ref sqlCommand, _employeeResultsListCndtnWork, sqlCmd);
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    sqlCmd.Append(" GROUP BY SECTIONCODERF, EMPLOYEECODERF ");
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        sqlCmd.Append(" GROUP BY SECTIONCODERF, EMPLOYEECODERF ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    else
                        // --- ADD 2010/07/20--------------------------------<<<<<
                        sqlCmd.Append(" GROUP BY EMPLOYEECODERF ");
                    sqlCmd.Append(" )AS C ");
                    sqlCmd.Append(" ON A.TMPEMPLOYEECODE = C.EMPLOYEECODERF ");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //���_�R�[�h
                    //    sqlCmd.Append(" AND A.SECTIONCODE = C.SECTIONCODERF ");
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        //���_�R�[�h
                        sqlCmd.Append(" AND A.SECTIONCODE = C.SECTIONCODERF ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    sqlCmd.Append(" LEFT OUTER JOIN ");
                    sqlCmd.Append(" (SELECT");
                    sqlCmd.Append(" EMPLOYEECODERF, ");
                    sqlCmd.Append(" NAMERF ");
                    sqlCmd.Append(" FROM EMPLOYEERF ");
                    MakeWhereString_Employee(ref sqlCommand, _employeeResultsListCndtnWork, sqlCmd);
                    sqlCmd.Append(" )AS D ");
                    sqlCmd.Append(" ON A.TMPEMPLOYEECODE = D.EMPLOYEECODERF ");
                    // --- UPD 2010/10/09 ---------->>>
                    //sqlCmd.Append(" ORDER BY A.TMPEMPLOYEECODE");
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                    {
                        sqlCmd.Append(" ORDER BY A.SECTIONCODE, A.TMPEMPLOYEECODE");
                    }
                    else if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                    {
                        sqlCmd.Append(" ORDER BY A.TMPEMPLOYEECODE");
                    }
                    // --- UPD 2010/10/09 ----------<<<

                    #endregion
                }
                else
                {
                    #region ���v ���� Select���쐬
                    sqlCmd.Append(" SELECT ");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //���_�R�[�h
                    //    sqlCmd.Append(" A.SECTIONCODE, ");
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        //���_�R�[�h
                        sqlCmd.Append(" A.SECTIONCODE, ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    sqlCmd.Append(" A.TMPEMPLOYEECODE AS CODE, ");
                    sqlCmd.Append(" A.SUMSALES AS SUMMONEY, ");
                    sqlCmd.Append(" A.SUMRETURNGOODS AS RETURNMONEY, ");
                    sqlCmd.Append(" A.SUMDISCOUNTPRICERF AS SUMSALESMONEYTAXEXCRFB, ");
                    sqlCmd.Append(" A.SUMGROSSPROFITRF AS SUMGROSSPROFITRF, ");
                    sqlCmd.Append(" C.SUMSALESTARGETMONEYRF AS SUMSALESTARGETMONEYRF, ");
                    sqlCmd.Append(" D.NAMERF AS NAMERF ");
                    sqlCmd.Append(" FROM ");
                    sqlCmd.Append(" (SELECT ");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //���_�R�[�h
                    //    sqlCmd.Append(" ADDUPSECCODERF AS SECTIONCODE, ");
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        //���_�R�[�h
                        sqlCmd.Append(" ADDUPSECCODERF AS SECTIONCODE, ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    sqlCmd.Append(" EMPLOYEECODERF AS TMPEMPLOYEECODE, ");
                    sqlCmd.Append(" SUM(SALESMONEYRF) AS SUMSALES, ");
                    sqlCmd.Append(" SUM(SALESRETGOODSPRICERF) AS SUMRETURNGOODS, ");
                    sqlCmd.Append(" SUM(DISCOUNTPRICERF) AS SUMDISCOUNTPRICERF, ");
                    sqlCmd.Append(" SUM(GROSSPROFITRF) AS SUMGROSSPROFITRF ");
                    sqlCmd.Append(" FROM MTTLSALESSLIPRF");
                    MakeWhereString_MTtl(ref sqlCommand, _employeeResultsListCndtnWork, sqlCmd);
                    sqlCmd.Append(" ) AS A ");
                    sqlCmd.Append(" LEFT OUTER JOIN ");
                    sqlCmd.Append(" (SELECT ");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //���_�R�[�h
                    //    sqlCmd.Append(" SECTIONCODERF, ");
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        //���_�R�[�h
                        sqlCmd.Append(" SECTIONCODERF, ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    sqlCmd.Append(" EMPLOYEECODERF, ");
                    sqlCmd.Append(" SUM(SALESTARGETMONEYRF) AS SUMSALESTARGETMONEYRF ");
                    sqlCmd.Append(" FROM EMPSALESTARGETRF ");
                    MakeWhereString_Emp(ref sqlCommand, _employeeResultsListCndtnWork, sqlCmd);
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    sqlCmd.Append(" GROUP BY SECTIONCODERF, EMPLOYEECODERF ");
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        sqlCmd.Append(" GROUP BY SECTIONCODERF, EMPLOYEECODERF ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    else
                        // --- ADD 2010/07/20--------------------------------<<<<<
                        sqlCmd.Append(" GROUP BY EMPLOYEECODERF ");
                    sqlCmd.Append(" )AS C ");
                    sqlCmd.Append(" ON A.TMPEMPLOYEECODE = C.EMPLOYEECODERF ");
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //���_�R�[�h
                    //    sqlCmd.Append(" AND A.SECTIONCODE = C.SECTIONCODERF ");
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        //���_�R�[�h
                        sqlCmd.Append(" AND A.SECTIONCODE = C.SECTIONCODERF ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    sqlCmd.Append(" LEFT OUTER JOIN ");
                    sqlCmd.Append(" (SELECT");
                    sqlCmd.Append(" EMPLOYEECODERF, ");
                    sqlCmd.Append(" NAMERF ");
                    sqlCmd.Append(" FROM EMPLOYEERF ");
                    MakeWhereString_Employee(ref sqlCommand, _employeeResultsListCndtnWork, sqlCmd);
                    sqlCmd.Append(" )AS D ");
                    sqlCmd.Append(" ON A.TMPEMPLOYEECODE = D.EMPLOYEECODERF ");
                    // --- UPD 2010/10/09 ---------->>>
                    //sqlCmd.Append(" ORDER BY A.TMPEMPLOYEECODE");
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                    {
                        sqlCmd.Append(" ORDER BY A.SECTIONCODE, A.TMPEMPLOYEECODE");
                    }
                    else if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                    {
                        sqlCmd.Append(" ORDER BY A.TMPEMPLOYEECODE");
                    }
                    // --- UPD 2010/10/09 ----------<<<

                    #endregion
                }

                sqlCommand.CommandText = sqlCmd.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g

                    EmployeeResultsListResultWork wkEmployeeResultsListResultWork = new EmployeeResultsListResultWork();

                    //�]�ƈ��R�[�h
                    string employeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CODE"));
                    wkEmployeeResultsListResultWork.EmployeeCode = employeeCode;

                    //�]�ƈ�����
                    string name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));

                    if (string.IsNullOrEmpty(name))
                    {
                        wkEmployeeResultsListResultWork.EmployeeName = NOINPUT;
                    }
                    else
                    {
                        wkEmployeeResultsListResultWork.EmployeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                    }
                    //������z  ���`�̔���`�[���v�i�Ŕ����j  
                    wkEmployeeResultsListResultWork.BackSalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMMONEY"));
                    //�ԕi���z  �ԕi�`�[�̔���`�[���v�i�Ŕ����j  
                    wkEmployeeResultsListResultWork.RetGoodSalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETURNMONEY"));
                    //�l�����z  ���`�̔���l�����z�v�i�Ŕ����j    
                    wkEmployeeResultsListResultWork.BackSalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESMONEYTAXEXCRFB"));
                    //����ڕW���z
                    wkEmployeeResultsListResultWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESTARGETMONEYRF"));

                    if (1 != _employeeResultsListCndtnWork.DuringType)
                    {
                        //�e�����z GROSSPROFITRF
                        wkEmployeeResultsListResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMGROSSPROFITRF"));
                    }

                    //�������z�v
                    if (1 == _employeeResultsListCndtnWork.DuringType)
                    {
                        wkEmployeeResultsListResultWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMTOTALCOSTRF"));
                    }
                    else
                    {
                        wkEmployeeResultsListResultWork.TotalCost = wkEmployeeResultsListResultWork.BackSalesTotalTaxExc
                            + wkEmployeeResultsListResultWork.RetGoodSalesTotalTaxExc
                            + wkEmployeeResultsListResultWork.BackSalesDisTtlTaxExc
                            - wkEmployeeResultsListResultWork.GrossProfit;
                    }
                    //�`�[����
                    if (1 == _employeeResultsListCndtnWork.DuringType)
                    {
                        wkEmployeeResultsListResultWork.SlipNumCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TMPSALESSLIPNUMRF"));
                    }
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    wkEmployeeResultsListResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODE"));
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17-------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        wkEmployeeResultsListResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODE"));
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    #endregion

                    // --- ADD 2010/09/21 ---------->>>>>
                    if (!string.IsNullOrEmpty(employeeCode.Trim()) && string.IsNullOrEmpty(name))
                    {
                        // �ΏۊO�Ƃ���
                    } 
                    else
                    {
                    // --- ADD 2010/09/21 ----------<<<<<
                        if (1 == _employeeResultsListCndtnWork.DuringType)
                        {
                            al.Add(wkEmployeeResultsListResultWork);
                        }
                        else
                        {
                            if (!(0 == wkEmployeeResultsListResultWork.BackSalesTotalTaxExc
                                && 0 == wkEmployeeResultsListResultWork.RetGoodSalesTotalTaxExc
                                && 0 == wkEmployeeResultsListResultWork.BackSalesDisTtlTaxExc
                                && 0 == wkEmployeeResultsListResultWork.GrossProfit))
                            {
                                al.Add(wkEmployeeResultsListResultWork);
                            }
                        }
                    } // ADD 2010/09/21

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeResultsListWorkDB.SearchEmployeeResultsProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Where�吶������]
        /// <summary>
        /// ���㗚���f�[�^�}�X�^�pWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">��������</param>
        /// <returns>���㗚���f�[�^�}�X�^�pWHERE��</returns>
        /// <br>Note       : ���㗚���f�[�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.11</br>
        private void MakeWhereString_SalesHis(ref SqlCommand sqlCommand, EmployeeResultsListCndtnWork _employeeResultsListCndtnWork, string sTblNm, StringBuilder sqlCmd, int flag)
        {
            #region WHERE���쐬
            sqlCmd.Append(" WHERE ");

            string stringflag = flag.ToString().Trim();
            //��ƃR�[�h
            if (flag == 0)
            {
                sqlCmd.Append(" " + sTblNm + "ENTERPRISECODERF = @ENTERPRISECODEA");
                SqlParameter paraEnterpriseCodeA = sqlCommand.Parameters.Add("@ENTERPRISECODEA", SqlDbType.NChar);
                paraEnterpriseCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.EnterpriseCode);
            }
            else
            {
                sqlCmd.Append(" " + sTblNm + "ENTERPRISECODERF = @ENTERPRISECODEAA");
                SqlParameter paraEnterpriseCodeAA = sqlCommand.Parameters.Add("@ENTERPRISECODEAA", SqlDbType.NChar);
                paraEnterpriseCodeAA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.EnterpriseCode);
            }


            //�폜�敪
            sqlCmd.Append(" AND " + sTblNm + "LOGICALDELETECODERF = 0 ");

            //�󒍃X�e�[�^�X
            sqlCmd.Append(" AND " + sTblNm + "ACPTANODRSTATUSRF = 30 ");

            //�ԓ`�敪
            sqlCmd.Append(" AND " + sTblNm + "DEBITNOTEDIVRF = 0 ");

            //���_�R�[�h
            // --- DEL 2010/08/20-------------------------------->>>>>
            //if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
            //    && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode)))
            // --- DEL 2010/08/20--------------------------------<<<<<
            // --- ADD 2010/08/20-------------------------------->>>>>
            if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
                && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                && "OUTPUT" != _employeeResultsListCndtnWork.ViewFlg)
            // --- ADD 2010/08/20--------------------------------<<<<<
            {
                if (flag == 0)
                {
                    sqlCmd.Append(" AND " + sTblNm + "RESULTSADDUPSECCDRF=@SECTIONCODERFB ");
                    SqlParameter paraSectionCodeB = sqlCommand.Parameters.Add("@SECTIONCODERFB", SqlDbType.NChar);
                    paraSectionCodeB.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.SectionCode);
                }
                else
                {
                    sqlCmd.Append(" AND " + sTblNm + "RESULTSADDUPSECCDRF=@SECTIONCODERFA ");
                    SqlParameter paraSectionCodeA = sqlCommand.Parameters.Add("@SECTIONCODERFA", SqlDbType.NChar);
                    paraSectionCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.SectionCode);
                }
            }
            // --- ADD 2010/09/21-------------------------------->>>>>
            // ���_�R�[�h��"�S��"�ꍇ�̉�ʏo��
            if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
                && (WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                && !"OUTPUT".Equals(_employeeResultsListCndtnWork.ViewFlg))
            {
                if (flag == 0)
                {
                    sqlCmd.Append(" AND " + sTblNm + "RESULTSADDUPSECCDRF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODEA AND LOGICALDELETECODERF = 0) ");
                }
                else
                {
                    sqlCmd.Append(" AND " + sTblNm + "RESULTSADDUPSECCDRF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODEAA AND LOGICALDELETECODERF = 0) ");
                }
            }
            // --- ADD 2010/09/21--------------------------------<<<<<

            // --- DEL 2010/08/20-------------------------------->>>>>
            // --- ADD 2010/07/20-------------------------------->>>>>
            //if (string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)
            //    && (null != _employeeResultsListCndtnWork.SectionCodeList &&
            //    0 != _employeeResultsListCndtnWork.SectionCodeList.Count))
            // --- DEL 2010/08/20--------------------------------<<<<<
            // --- ADD 2010/08/20-------------------------------->>>>>
            if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg
                && (null != _employeeResultsListCndtnWork.SectionCodeList &&
                0 != _employeeResultsListCndtnWork.SectionCodeList.Count))
            // --- ADD 2010/08/20--------------------------------<<<<<
            {
                // ���_�R�[�h
                string sectionString = "";
                foreach (string[] sectionCode in _employeeResultsListCndtnWork.SectionCodeList)
                {
                    if (!string.Empty.Equals(sectionCode[0]))
                    {
                        if (!string.Empty.Equals(sectionString))
                        {
                            sectionString += ",";
                        }
                        sectionString += "'" + sectionCode[0] + "'";
                    }
                }
                if (!string.Empty.Equals(sectionString))
                {
                    // ���_�R�[�h
                    sqlCmd.Append(" AND " + sTblNm + "RESULTSADDUPSECCDRF IN (" + sectionString + ")  ");

                }
            }
            // --- ADD 2010/07/20--------------------------------<<<<<

            //�S����
            if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                || (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode)))
            {
                if (flag == 0)
                {
                    if (_employeeResultsListCndtnWork.ReferType == 1)
                    {
                        ////�S����
                        //if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        //{
                        //    sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF>=@FINDSTEMPLOYEECODERF");
                        //    SqlParameter findStEmployeeCode = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERF", SqlDbType.NChar);
                        //    findStEmployeeCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        //}

                        //if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        //{
                        //    sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF<=@FINDEDEMPLOYEECODERF ");
                        //    SqlParameter findEdEmployeeCode = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERF", SqlDbType.NChar);
                        //    findEdEmployeeCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        //}

                        //���s��
                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF>=@FINDSTEMPLOYEECODERF ");
                            SqlParameter findParaDspcInstsInpEmpCode = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERF", SqlDbType.NChar);
                            findParaDspcInstsInpEmpCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        }

                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF<=@FINDEDEMPLOYEECODERF ");
                            SqlParameter findEdEmployeeCode = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERF", SqlDbType.NChar);
                            findEdEmployeeCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        }

                        // --- ADD 2010/09/21-------------------------------->>>>>
                        // �����ҁA�_���폜�f�[�^���ΏۊO
                        if (flag == 0)
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEA AND LOGICALDELETECODERF = 0) ");
                        }
                        else
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEAA AND LOGICALDELETECODERF = 0) ");
                        }
                        // --- ADD 2010/09/21--------------------------------<<<<<
                    }
                    else if (_employeeResultsListCndtnWork.ReferType == 2)
                    {
                        //�󒍎�
                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "FRONTEMPLOYEECDRF>=@FINDSTEMPLOYEECODERF ");
                            SqlParameter findStEmployeeCode = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERF", SqlDbType.NChar);
                            findStEmployeeCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        }

                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "FRONTEMPLOYEECDRF<=@FINDEDEMPLOYEECODERF ");
                            SqlParameter findEdEmployeeCode = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERF", SqlDbType.NChar);
                            findEdEmployeeCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        }

                        // --- ADD 2010/09/21-------------------------------->>>>>
                        // �󒍎ҁA�_���폜�f�[�^���ΏۊO
                        if (flag == 0)
                        {
                            sqlCmd.Append(" AND " + sTblNm + "FRONTEMPLOYEECDRF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEA AND LOGICALDELETECODERF = 0) ");
                        }
                        else
                        {
                            sqlCmd.Append(" AND " + sTblNm + "FRONTEMPLOYEECDRF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEAA AND LOGICALDELETECODERF = 0) ");
                        }
                        // --- ADD 2010/09/21--------------------------------<<<<<
                    }
                    else if (_employeeResultsListCndtnWork.ReferType == 3)
                    {
                        ////���s��
                        //if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        //{
                        //    sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF>=@FINDSTEMPLOYEECODERF ");
                        //    SqlParameter findParaDspcInstsInpEmpCode = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERF", SqlDbType.NChar);
                        //    findParaDspcInstsInpEmpCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        //}

                        //if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        //{
                        //    sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF<=@FINDEDEMPLOYEECODERF ");
                        //    SqlParameter findEdEmployeeCode = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERF", SqlDbType.NChar);
                        //    findEdEmployeeCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        //}

                        //�S����
                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF>=@FINDSTEMPLOYEECODERF");
                            SqlParameter findStEmployeeCode = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERF", SqlDbType.NChar);
                            findStEmployeeCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        }

                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF<=@FINDEDEMPLOYEECODERF ");
                            SqlParameter findEdEmployeeCode = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERF", SqlDbType.NChar);
                            findEdEmployeeCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        }

                        // --- ADD 2010/09/21-------------------------------->>>>>
                        // �S���ҁA�_���폜�f�[�^���ΏۊO
                        if (flag == 0)
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEA AND LOGICALDELETECODERF = 0) ");
                        }
                        else
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEAA AND LOGICALDELETECODERF = 0) ");
                        }
                        // --- ADD 2010/09/21--------------------------------<<<<<
                    }
                }
                else
                {
                    if (_employeeResultsListCndtnWork.ReferType == 1)
                    {
                        ////�S����
                        //if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        //{
                        //    sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF>=@FINDSTEMPLOYEECODERFA");
                        //    SqlParameter findStEmployeeCodeA = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERFA", SqlDbType.NChar);
                        //    findStEmployeeCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        //}

                        //if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        //{
                        //    sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF<=@FINDEDEMPLOYEECODERFA ");
                        //    SqlParameter findEdEmployeeCodeA = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERFA", SqlDbType.NChar);
                        //    findEdEmployeeCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        //}

                        //���s��
                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF>=@FINDSTEMPLOYEECODERFA ");
                            SqlParameter findParaDspcInstsInpEmpCodeA = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERFA", SqlDbType.NChar);
                            findParaDspcInstsInpEmpCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        }

                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF<=@FINDEDEMPLOYEECODERFA ");
                            SqlParameter findEdEmployeeCodeA = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERFA", SqlDbType.NChar);
                            findEdEmployeeCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        }

                        // --- ADD 2010/09/21-------------------------------->>>>>
                        // ���s�ҁA�_���폜�f�[�^���ΏۊO
                        if (flag == 0)
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEA AND LOGICALDELETECODERF = 0) ");
                        }
                        else
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEAA AND LOGICALDELETECODERF = 0) ");
                        }
                        // --- ADD 2010/09/21--------------------------------<<<<<
                    }
                    else if (_employeeResultsListCndtnWork.ReferType == 2)
                    {
                        //�󒍎�
                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "FRONTEMPLOYEECDRF>=@FINDSTEMPLOYEECODERFA ");
                            SqlParameter findStEmployeeCodeA = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERFA", SqlDbType.NChar);
                            findStEmployeeCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        }

                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "FRONTEMPLOYEECDRF<=@FINDEDEMPLOYEECODERFA ");
                            SqlParameter findEdEmployeeCodeA = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERFA", SqlDbType.NChar);
                            findEdEmployeeCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        }

                        // --- ADD 2010/09/21-------------------------------->>>>>
                        // �󒍎ҁA�_���폜�f�[�^���ΏۊO
                        if (flag == 0)
                        {
                            sqlCmd.Append(" AND " + sTblNm + "FRONTEMPLOYEECDRF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEA AND LOGICALDELETECODERF = 0) ");
                        }
                        else
                        {
                            sqlCmd.Append(" AND " + sTblNm + "FRONTEMPLOYEECDRF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEAA AND LOGICALDELETECODERF = 0) ");
                        }
                        // --- ADD 2010/09/21--------------------------------<<<<<
                    }
                    else if (_employeeResultsListCndtnWork.ReferType == 3)
                    {
                        ////���s��
                        //if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        //{
                        //    sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF>=@FINDSTEMPLOYEECODERFA ");
                        //    SqlParameter findParaDspcInstsInpEmpCodeA = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERFA", SqlDbType.NChar);
                        //    findParaDspcInstsInpEmpCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        //}

                        //if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        //{
                        //    sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF<=@FINDEDEMPLOYEECODERFA ");
                        //    SqlParameter findEdEmployeeCodeA = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERFA", SqlDbType.NChar);
                        //    findEdEmployeeCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        //}

                        //�S����
                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF>=@FINDSTEMPLOYEECODERFA");
                            SqlParameter findStEmployeeCodeA = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERFA", SqlDbType.NChar);
                            findStEmployeeCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        }

                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF<=@FINDEDEMPLOYEECODERFA ");
                            SqlParameter findEdEmployeeCodeA = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERFA", SqlDbType.NChar);
                            findEdEmployeeCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        }

                        // --- ADD 2010/09/21-------------------------------->>>>>
                        // �S���ҁA�_���폜�f�[�^���ΏۊO
                        if (flag == 0)
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEA AND LOGICALDELETECODERF = 0) ");
                        }
                        else
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEAA AND LOGICALDELETECODERF = 0) ");
                        }
                        // --- ADD 2010/09/21--------------------------------<<<<<
                    }
                }
            }

            if (_employeeResultsListCndtnWork.DuringType == 1)
            {
                if (flag == 0)
                {
                    //������t
                    if (_employeeResultsListCndtnWork.St_DuringTime != DateTime.MinValue)
                    {
                        sqlCmd.Append(" AND " + sTblNm + " SALESDATERF>=@STSALESDATE");
                        SqlParameter paraSalesDate = sqlCommand.Parameters.Add("@STSALESDATE", SqlDbType.Int);
                        paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_employeeResultsListCndtnWork.St_DuringTime);
                    }
                    if (_employeeResultsListCndtnWork.Ed_DuringTime != DateTime.MinValue)
                    {
                        sqlCmd.Append(" AND " + sTblNm + "SALESDATERF<=@EDSALESDATE");
                        SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDSALESDATE", SqlDbType.Int);
                        paraEdSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_employeeResultsListCndtnWork.Ed_DuringTime);
                    }

                }
                else
                {
                    //������t
                    if (_employeeResultsListCndtnWork.St_DuringTime != DateTime.MinValue)
                    {
                        sqlCmd.Append(" AND " + sTblNm + " SALESDATERF>=@STSALESDATET");
                        SqlParameter paraSalesDateT = sqlCommand.Parameters.Add("@STSALESDATET", SqlDbType.Int);
                        paraSalesDateT.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_employeeResultsListCndtnWork.St_DuringTime);
                    }
                    if (_employeeResultsListCndtnWork.Ed_DuringTime != DateTime.MinValue)
                    {
                        sqlCmd.Append(" AND " + sTblNm + "SALESDATERF<=@EDSALESDATET");
                        SqlParameter paraEdSalesDateT = sqlCommand.Parameters.Add("@EDSALESDATET", SqlDbType.Int);
                        paraEdSalesDateT.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_employeeResultsListCndtnWork.Ed_DuringTime);
                    }

                }
            }
            else if (_employeeResultsListCndtnWork.DuringType == 2)
            {
                //������t
                if (_employeeResultsListCndtnWork.St_YearMonth != DateTime.MinValue)
                {
                    sqlCmd.Append(" AND " + sTblNm + "SALESDATERF>=@STSALESDATE ");
                    SqlParameter paraSalesDate = sqlCommand.Parameters.Add("@STSALESDATE", SqlDbType.Int);
                    paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_employeeResultsListCndtnWork.St_YearMonth);
                }
                if (_employeeResultsListCndtnWork.Ed_YearMonth != DateTime.MinValue)
                {
                    sqlCmd.Append(" AND " + sTblNm + "SALESDATERF<=@EDSALESDATE ");
                    SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDSALESDATE", SqlDbType.Int);
                    paraEdSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_employeeResultsListCndtnWork.Ed_YearMonth);
                }
            }

            sqlCmd.Append(" GROUP BY ");
            // --- DEL 2010/08/17------------------------------->>>>>
            // --- ADD 2010/07/20-------------------------------->>>>>
            //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
            //    //���_�R�[�h
            //    //sqlCmd.Append(sTblNm + "SECTIONCODERF, "); // DEL 2010/08/12 ��QID:13038�Ή� 
            //    sqlCmd.Append(sTblNm + "RESULTSADDUPSECCDRF, "); // ADD 2010/08/12 ��QID:13038�Ή�
            // --- ADD 2010/07/20--------------------------------<<<<<
            // --- DEL 2010/08/17-------------------------------<<<<<
            // --- ADD 2010/08/17-------------------------------->>>>>
            if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                sqlCmd.Append(sTblNm + "RESULTSADDUPSECCDRF, ");
            // --- ADD 2010/08/17--------------------------------<<<<<
            if (_employeeResultsListCndtnWork.ReferType == 1)
            {
                ////�S����
                //sqlCmd.Append(sTblNm + "SALESINPUTCODERF ");

                //���s��
                sqlCmd.Append(sTblNm + "SALESEMPLOYEECDRF ");
            }
            else if (_employeeResultsListCndtnWork.ReferType == 2)
            {
                //�󒍎�
                sqlCmd.Append(sTblNm + "FRONTEMPLOYEECDRF ");

            }
            else if (_employeeResultsListCndtnWork.ReferType == 3)
            {
                ////���s��
                //sqlCmd.Append(sTblNm + "SALESEMPLOYEECDRF ");

                //�S����
                sqlCmd.Append(sTblNm + "SALESINPUTCODERF ");

            }

            #endregion
        }

        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^�pWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">��������</param>
        /// <returns>�]�ƈ��ʔ���ڕW�ݒ�}�X�^�pWHERE��</returns>
        /// <br>Note       : ���㗚���f�[�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.11</br>
        private void MakeWhereString_Emp(ref SqlCommand sqlCommand, EmployeeResultsListCndtnWork _employeeResultsListCndtnWork, StringBuilder sqlCmd)
        {
            #region WHERE���쐬
            sqlCmd.Append(" WHERE ");

            //��ƃR�[�h
            sqlCmd.Append("ENTERPRISECODERF=@ENTERPRISECODEB");
            SqlParameter paraEnterpriseCodeB = sqlCommand.Parameters.Add("@ENTERPRISECODEB", SqlDbType.NChar);
            paraEnterpriseCodeB.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.EnterpriseCode);

            //�폜�敪
            sqlCmd.Append(" AND LOGICALDELETECODERF = 0 ");

            //�ڕW�ݒ�敪��10:���ԖڕW
            sqlCmd.Append(" AND TARGETSETCDRF = 10 ");

            //�ڕW�Δ�敪��22:���_+�]�ƈ�
            sqlCmd.Append(" AND TARGETCONTRASTCDRF = 22 ");

            //�ڕW�敪�R�[�h����ʂ̓��͒l�u���ԁv�̔N��
            if (_employeeResultsListCndtnWork.DuringType == 1)
            {
                sqlCmd.Append(" AND TARGETDIVIDECODERF=@TARGETDIVIDECODEST ");
                SqlParameter paraTargetDivideCodeSt = sqlCommand.Parameters.Add("@TARGETDIVIDECODEST", SqlDbType.Int);
                paraTargetDivideCodeSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_employeeResultsListCndtnWork.St_DuringTime);

            }
            else if (_employeeResultsListCndtnWork.DuringType == 2 || _employeeResultsListCndtnWork.DuringType == 3)
            {
                if (_employeeResultsListCndtnWork.St_YearMonth != DateTime.MinValue)
                {
                    sqlCmd.Append(" AND TARGETDIVIDECODERF>=@STSALESDATEA ");
                    SqlParameter paraSalesDateA = sqlCommand.Parameters.Add("@STSALESDATEA", SqlDbType.Int);
                    paraSalesDateA.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_employeeResultsListCndtnWork.St_YearMonth);
                }
                if (_employeeResultsListCndtnWork.Ed_YearMonth != DateTime.MinValue)
                {
                    sqlCmd.Append(" AND TARGETDIVIDECODERF<=@EDSALESDATEB ");
                    SqlParameter paraEdSalesDateB = sqlCommand.Parameters.Add("@EDSALESDATEB", SqlDbType.Int);
                    paraEdSalesDateB.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_employeeResultsListCndtnWork.Ed_YearMonth);
                }

            }
            // --- DEL 2010/08/20-------------------------------->>>>>
            //���_�R�[�h
            //if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
            //    && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode)))
            // --- DEL 2010/08/20--------------------------------<<<<<
            // --- ADD 2010/08/20-------------------------------->>>>>
            if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
                && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                && "OUTPUT" != _employeeResultsListCndtnWork.ViewFlg)
            // --- ADD 2010/08/20--------------------------------<<<<<
            {
                sqlCmd.Append(" AND SECTIONCODERF=@SECTIONCODERF ");
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODERF", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.SectionCode);
            }

            // --- ADD 2010/09/21-------------------------------->>>>>
            // ���_�R�[�h��"�S��"�ꍇ�̉�ʏo��
            if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
                && (WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                && !"OUTPUT".Equals(_employeeResultsListCndtnWork.ViewFlg))
            {
                sqlCmd.Append(" AND SECTIONCODERF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODEB2 AND LOGICALDELETECODERF = 0) ");
                SqlParameter paraEnterpriseCodeB2 = sqlCommand.Parameters.Add("@ENTERPRISECODEB2", SqlDbType.NChar);
                paraEnterpriseCodeB2.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.EnterpriseCode);
            }
            // --- ADD 2010/09/21--------------------------------<<<<<

            // --- DEL 2010/08/20-------------------------------->>>>>
            // --- ADD 2010/07/20-------------------------------->>>>>
            //if (string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)
            //    && (null != _employeeResultsListCndtnWork.SectionCodeList &&
            //    0 != _employeeResultsListCndtnWork.SectionCodeList.Count))
            // --- DEL 2010/08/20--------------------------------<<<<<
            // --- ADD 2010/08/20-------------------------------->>>>>
            if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg
                && (null != _employeeResultsListCndtnWork.SectionCodeList &&
                0 != _employeeResultsListCndtnWork.SectionCodeList.Count))
            // --- ADD 2010/08/20--------------------------------<<<<<
            {
                // ���_�R�[�h
                string sectionString = "";
                foreach (string[] sectionCode in _employeeResultsListCndtnWork.SectionCodeList)
                {
                    if (!string.Empty.Equals(sectionCode[0]))
                    {
                        if (!string.Empty.Equals(sectionString))
                        {
                            sectionString += ",";
                        }
                        sectionString += "'" + sectionCode[0] + "'";
                    }
                }
                if (!string.Empty.Equals(sectionString))
                {
                    // ���_�R�[�h
                    sqlCmd.Append(" AND SECTIONCODERF IN (" + sectionString + ")  ");

                }
            }
            // --- ADD 2010/07/20--------------------------------<<<<<

            //�]�ƈ��敪
            sqlCmd.Append(" AND EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD");
            SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
            switch ((int)_employeeResultsListCndtnWork.ReferType)
            {
                case 1:    //Agent   -> �S���ҕ�
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)10);
                    break;
                case 2:   //AcpOdr  -> �󒍎ҕ�
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)20);
                    break;
                case 3:  //Pblsher -> ���s�ҕ�
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)30);
                    break;
                default:
                    break;
            }

            //�]�ƈ��R�[�h
            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
            {
                sqlCmd.Append(" AND EMPLOYEECODERF >= @EMPLOYEECODERFBEF");
                SqlParameter paraEmployeeCdBef = sqlCommand.Parameters.Add("@EMPLOYEECODERFBEF", SqlDbType.NChar);
                paraEmployeeCdBef.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
            }

            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
            {
                sqlCmd.Append(" AND EMPLOYEECODERF <= @EMPLOYEECODERFEND");
                SqlParameter paraEmployeeCdEnd = sqlCommand.Parameters.Add("@EMPLOYEECODERFEND", SqlDbType.NChar);
                paraEmployeeCdEnd.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode);
            }

            // --- ADD 2010/09/21-------------------------------->>>>>
            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode) || !string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
            {
                // �]�ƈ��R�[�h�A�_���폜�f�[�^���ΏۊO
                sqlCmd.Append(" AND EMPLOYEECODERF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEB AND LOGICALDELETECODERF = 0 UNION SELECT DISTINCT '         ' AS EMPLOYEECODERF FROM EMPLOYEERF) ");
            }
            // --- ADD 2010/09/21--------------------------------<<<<<
            #endregion

        }

        /// <summary>
        /// �]�ƈ��}�X�^�pWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">��������</param>
        /// <returns>�]�ƈ��}�X�^�pWHERE��</returns>
        /// <br>Note       : ���㗚���f�[�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.11</br>
        private void MakeWhereString_Employee(ref SqlCommand sqlCommand, EmployeeResultsListCndtnWork _employeeResultsListCndtnWork, StringBuilder sqlCmd)
        {
            #region WHERE���쐬

            sqlCmd.Append(" WHERE ");

            //��ƃR�[�h
            sqlCmd.Append("ENTERPRISECODERF=@ENTERPRISECODEC");
            SqlParameter paraEnterpriseCodeC = sqlCommand.Parameters.Add("@ENTERPRISECODEC", SqlDbType.NChar);
            paraEnterpriseCodeC.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.EnterpriseCode);

            //�폜�敪
            sqlCmd.Append(" AND LOGICALDELETECODERF = 0 ");

            //�]�ƈ��R�[�h
            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
            {
                sqlCmd.Append(" AND EMPLOYEECODERF >= @EMPLOYEECODERFBEFA");
                SqlParameter paraEmployeeCdBefA = sqlCommand.Parameters.Add("@EMPLOYEECODERFBEFA", SqlDbType.NChar);
                paraEmployeeCdBefA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
            }

            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
            {
                sqlCmd.Append(" AND EMPLOYEECODERF <= @EMPLOYEECODERFENDA");
                SqlParameter paraEmployeeCdEndA = sqlCommand.Parameters.Add("@EMPLOYEECODERFENDA", SqlDbType.NChar);
                paraEmployeeCdEndA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode);
            }

            // --- ADD 2010/09/21-------------------------------->>>>>
            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode) || !string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
            {
                // �]�ƈ��R�[�h�A�_���폜�f�[�^���ΏۊO
                sqlCmd.Append(" AND EMPLOYEECODERF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEC AND LOGICALDELETECODERF = 0 UNION SELECT DISTINCT '         ' AS EMPLOYEECODERF FROM EMPLOYEERF) ");
            }
            // --- ADD 2010/09/21--------------------------------<<<<<

            sqlCmd.Append(" GROUP BY ");

            sqlCmd.Append(" EMPLOYEECODERF, NAMERF ");

            #endregion
        }

        /// <summary>
        /// ���㌎���W�v�}�X�^�pWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">��������</param>
        /// <returns>���㌎���W�v�}�X�^�pWHERE��</returns>
        /// <br>Note       : ���㌎���W�v�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.11</br>
        private void MakeWhereString_MTtl(ref SqlCommand sqlCommand, EmployeeResultsListCndtnWork _employeeResultsListCndtnWork, StringBuilder sqlCmd)
        {
            #region WHERE���쐬

            sqlCmd.Append(" WHERE ");

            //��ƃR�[�h
            sqlCmd.Append("ENTERPRISECODERF=@ENTERPRISECODED");
            SqlParameter paraEnterpriseCodeD = sqlCommand.Parameters.Add("@ENTERPRISECODED", SqlDbType.NChar);
            paraEnterpriseCodeD.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.EnterpriseCode);

            //�폜�敪
            sqlCmd.Append(" AND LOGICALDELETECODERF = 0 ");

            //���яW�v�敪=0:���i���v
            sqlCmd.Append(" AND RSLTTTLDIVCDRF = 0 ");
            // --- DEL 2010/08/20-------------------------------->>>>>
            //���_�R�[�h
            //if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
            //    && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode)))
            // --- DEL 2010/08/20--------------------------------<<<<<
            // --- ADD 2010/08/20-------------------------------->>>>>
            if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
                && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                && "OUTPUT" != _employeeResultsListCndtnWork.ViewFlg)
            // --- ADD 2010/08/20--------------------------------<<<<<
            {
                sqlCmd.Append(" AND ADDUPSECCODERF=@ADDUPSECCODERF ");
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@ADDUPSECCODERF", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.SectionCode);
            }

            // --- ADD 2010/09/21-------------------------------->>>>>
            // ���_�R�[�h��"�S��"�ꍇ�̉�ʏo��
            if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
                && (WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                && !"OUTPUT".Equals(_employeeResultsListCndtnWork.ViewFlg))
            {
                sqlCmd.Append(" AND ADDUPSECCODERF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODED AND LOGICALDELETECODERF = 0) ");
            }
            // --- ADD 2010/09/21--------------------------------<<<<<

            // --- DEL 2010/08/20-------------------------------->>>>>
            // --- ADD 2010/07/20-------------------------------->>>>>
            //if (string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)
            //    && (null != _employeeResultsListCndtnWork.SectionCodeList &&
            //    0 != _employeeResultsListCndtnWork.SectionCodeList.Count))
            // --- DEL 2010/08/20--------------------------------<<<<<
            // --- ADD 2010/08/20-------------------------------->>>>>
            if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg
               && (null != _employeeResultsListCndtnWork.SectionCodeList &&
               0 != _employeeResultsListCndtnWork.SectionCodeList.Count))
            // --- ADD 2010/08/20--------------------------------<<<<<
            {
                // ���_�R�[�h
                string sectionString = "";
                foreach (string[] sectionCode in _employeeResultsListCndtnWork.SectionCodeList)
                {
                    if (!string.Empty.Equals(sectionCode[0]))
                    {
                        if (!string.Empty.Equals(sectionString))
                        {
                            sectionString += ",";
                        }
                        sectionString += "'" + sectionCode[0] + "'";
                    }
                }
                if (!string.Empty.Equals(sectionString))
                {
                    // ���_�R�[�h
                    sqlCmd.Append(" AND ADDUPSECCODERF IN (" + sectionString + ")  ");

                }
            }
            // --- ADD 2010/07/20--------------------------------<<<<<

            //�]�ƈ��敪
            sqlCmd.Append(" AND EMPLOYEEDIVCDRF=@EMPLOYEEDIVCDA");
            SqlParameter paraEmployeeDivCdA = sqlCommand.Parameters.Add("@EMPLOYEEDIVCDA", SqlDbType.Int);
            switch ((int)_employeeResultsListCndtnWork.ReferType)
            {
                case 1:    //Agent   -> �S���ҕ�
                    paraEmployeeDivCdA.Value = SqlDataMediator.SqlSetInt32((int)10);
                    break;
                case 2:   //AcpOdr  -> �󒍎ҕ�
                    paraEmployeeDivCdA.Value = SqlDataMediator.SqlSetInt32((int)20);
                    break;
                case 3:  //Pblsher -> ���s�ҕ�
                    paraEmployeeDivCdA.Value = SqlDataMediator.SqlSetInt32((int)30);
                    break;
                default:
                    break;
            }

            //�]�ƈ��R�[�h
            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
            {
                sqlCmd.Append(" AND EMPLOYEECODERF >= @EMPLOYEECODERFBEFB");
                SqlParameter paraEmployeeCdBefB = sqlCommand.Parameters.Add("@EMPLOYEECODERFBEFB", SqlDbType.NChar);
                paraEmployeeCdBefB.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
            }

            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
            {
                sqlCmd.Append(" AND EMPLOYEECODERF <= @EMPLOYEECODERFENDB");
                SqlParameter paraEmployeeCdEndB = sqlCommand.Parameters.Add("@EMPLOYEECODERFENDB", SqlDbType.NChar);
                paraEmployeeCdEndB.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode);
            }

            // --- ADD 2010/09/21-------------------------------->>>>>
            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode) || !string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
            {
                // �]�ƈ��R�[�h�A�_���폜�f�[�^���ΏۊO
                sqlCmd.Append(" AND EMPLOYEECODERF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODED AND LOGICALDELETECODERF = 0 UNION SELECT DISTINCT '         ' AS EMPLOYEECODERF FROM EMPLOYEERF) ");
            }
            // --- ADD 2010/09/21--------------------------------<<<<<

            //�v��N��
            if (_employeeResultsListCndtnWork.St_YearMonth != DateTime.MinValue)
            {
                sqlCmd.Append(" AND ADDUPYEARMONTHRF>=@STSALESDATEC ");
                SqlParameter paraSalesDateC = sqlCommand.Parameters.Add("@STSALESDATEC", SqlDbType.Int);
                paraSalesDateC.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_employeeResultsListCndtnWork.St_YearMonth);
            }
            if (_employeeResultsListCndtnWork.Ed_YearMonth != DateTime.MinValue)
            {
                sqlCmd.Append(" AND ADDUPYEARMONTHRF<=@EDSALESDATED ");
                SqlParameter paraEdSalesDateD = sqlCommand.Parameters.Add("@EDSALESDATED", SqlDbType.Int);
                paraEdSalesDateD.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_employeeResultsListCndtnWork.Ed_YearMonth);
            }
            // --- DEL 2010/08/17-------------------------------->>>>>
            // --- ADD 2010/07/20-------------------------------->>>>>
            //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
            //    sqlCmd.Append(" GROUP BY ADDUPSECCODERF, EMPLOYEECODERF ");
            // --- ADD 2010/08/17-------------------------------->>>>>
            // --- DEL 2010/08/17--------------------------------<<<<<
            if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                sqlCmd.Append(" GROUP BY ADDUPSECCODERF, EMPLOYEECODERF ");
            // --- ADD 2010/08/17--------------------------------<<<<<
            else
                // --- ADD 2010/07/20--------------------------------<<<<<
                sqlCmd.Append(" GROUP BY EMPLOYEECODERF ");

            #endregion

        }

        #endregion [ Where�吶������]
    }
}
