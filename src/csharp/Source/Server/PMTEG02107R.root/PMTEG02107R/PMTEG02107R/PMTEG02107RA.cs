//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`���ו\DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : ��`���ו\���f�[�^������s���N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���J��
// �� �� ��  2010/4/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Data.SqlTypes;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using Broadleaf.Library.Resources;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ��`���ו\ �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`���ו\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���J��</br>
    /// <br>Date       : 2010.04.28</br>
    /// </remarks>
    [Serializable]
    public class TegataMeisaiListReportResultDB : RemoteDB , ITegataMeisaiListReportResultDB
    {
       #region �N���X�R���X�g���N�^
        /// <summary>
        /// ��`���ו\�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        public TegataMeisaiListReportResultDB()
            : base("PMTEG02109D", "Broadleaf.Application.Remoting.ParamData.TegataMeisaiListReportResultWork", "TegataMeisaiListReportRESULT")
        {

        }
        #endregion

       #region [Search]
        #region �w�肳�ꂽ�����̎�`���ו\�ꗗ�\���LIST�̎擾����
        /// <summary>
        /// �w�肳�ꂽ�����̎�`���ו\�ꗗ�\���LIST��߂��܂�
        /// </summary>
        /// <param name="TegataMeisaiListReportResultWork">��������</param>
        /// <param name="TegataMeisaiListReportParaWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̎�`���ו\���LIST��߂��܂�</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        public int Search(out object TegataMeisaiListReportResultWork, object TegataMeisaiListReportParaWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            TegataMeisaiListReportResultWork = new ArrayList();
            try
            {
                //�R���N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �������s��
                status = SearchProc(out TegataMeisaiListReportResultWork, TegataMeisaiListReportParaWork, ref sqlConnection);
                
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "TegataMeisaiListReportResultDB.Search");
                TegataMeisaiListReportResultWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TegataMeisaiListReportResultDB.Search");
                TegataMeisaiListReportResultWork = new ArrayList();
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
            return status;
        }
        #endregion

        #region �w�肳�ꂽ�����̎�`���ו\�ꗗ�\���LIST(�O�������SqlConnection���g�p)
        /// <summary>
        /// �w�肳�ꂽ�����̎�`���ו\�ꗗ�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="retList">�������ʌ����p�����[�^</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̎�`���ו\�ꗗ�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        private int SearchProc(out object retList, object paraObj, ref SqlConnection sqlConnection)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            TegataMeisaiListReportParaWork paraWork = null;
            paraWork = paraObj as TegataMeisaiListReportParaWork;

            retList = new ArrayList();
            ArrayList al = new ArrayList();

            // ����`�f�[�^sql
            StringBuilder selectTxt1 = new StringBuilder(string.Empty);
            // �x����`�f�[�^sql
            StringBuilder selectTxt2 = new StringBuilder(string.Empty);

            StringBuilder selectTxt = new StringBuilder(string.Empty);

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                // ��ʎw��̎�`�敪���u����`�v�̏ꍇ
                if (0 == paraWork.DraftDivide)
                {
                    selectTxt = MakeSearchSQL1(ref selectTxt1, ref sqlCommand, paraWork);

                }
                // ��ʎw��̎�`�敪���u�x����`�v�̏ꍇ
                else if (1 == paraWork.DraftDivide)
                {
                    selectTxt.Append(MakeSearchSQL2(ref selectTxt2, ref sqlCommand, paraWork));
                }

                // �\�[�g���̐ݒ�
                selectTxt.Append(SortSql(paraWork));

                sqlCommand.CommandText= selectTxt.ToString();
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    al.Add(CopyToTegataMeisaiListReportResultWorkFromReader(ref myReader, paraWork));
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
                status = base.WriteSQLErrorLog(sqlex, "TegataMeisaiListReportResultDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TegataMeisaiListReportResultDB.SearchProc" + status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }
            }
            retList = al;
            return status;
        }
        #endregion

        #region �����p����`�f�[�^�擾����
        /// <summary>
        /// �����p����`�f�[�^�擾����
        /// </summary>
        /// <param name="selectTxt1">sql��</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : �����p����`�f�[�^���擾���܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks> 
        private StringBuilder MakeSearchSQL1(ref StringBuilder selectTxt1, ref SqlCommand sqlCommand, TegataMeisaiListReportParaWork paraWork)
        {
            #region [�擾����]
            selectTxt1 = SelectRow(paraWork, selectTxt1);    
            #endregion
            #region [�e�[�u��]
            selectTxt1.Append("FROM ");
            selectTxt1.Append("RCVDRAFTDATARF A ");               // ����`�f�[�^
            #endregion
            #region [���o����]
            MakeWhereString(ref selectTxt1, ref sqlCommand, paraWork);
            #endregion

            return selectTxt1;
            
        }
        #endregion

        #region �����p�x����`�f�[�^�擾����
        /// <summary>
        /// �����p�x����`�f�[�^�擾����
        /// </summary>
        /// <param name="selectTxt2">sql��</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : �����p�x����`�f�[�^���擾���܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks> 
        private StringBuilder MakeSearchSQL2(ref StringBuilder selectTxt2, ref SqlCommand sqlCommand, TegataMeisaiListReportParaWork paraWork)
        {
            #region [�擾����]
            selectTxt2 = SelectRow(paraWork, selectTxt2);
            #endregion
            #region [�e�[�u��]
            selectTxt2.Append("FROM ");
            selectTxt2.Append("PAYDRAFTDATARF A "); // �x����`�f�[�^
            #endregion
            #region [���o����]
            MakeWhereString(ref selectTxt2, ref sqlCommand, paraWork);
            #endregion

            return selectTxt2;
        }
        #endregion

        #region [�擾����]
        /// <summary>
        /// �擾����
        /// </summary>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="selectTxt">sql��</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        private StringBuilder SelectRow(TegataMeisaiListReportParaWork paraWork, StringBuilder selectTxt)
        {
            //�@��`�敪������`
            if (0 == paraWork.DraftDivide)
            {
                selectTxt.Append("SELECT ");
                selectTxt.Append("A.ENTERPRISECODERF ENTERPRISECODERF, ");            // ��ƃR�[�h
                selectTxt.Append("A.LOGICALDELETECODERF LOGICALDELETECODERF, ");            // �_���폜�敪
                selectTxt.Append("A.RCVDRAFTNORF RCVDRAFTNORF, ");            // ����`�ԍ�
                selectTxt.Append("A.DRAFTKINDCDRF DRAFTKINDCDRF, ");            // ��`���
                selectTxt.Append("A.BANKANDBRANCHCDRF BANKANDBRANCHCDRF, ");            // ��s�E�x�X�R�[�h
                selectTxt.Append("A.BANKANDBRANCHNMRF BANKANDBRANCHNMRF, ");            // ��s�E�x�X����
                selectTxt.Append("A.ADDUPSECCODERF ADDUPSECCODERF, ");            // �v�㋒�_�R�[�h
                selectTxt.Append("A.DRAFTDRAWINGDATERF DRAFTDRAWINGDATERF, ");            // ��`�U�o��
                selectTxt.Append("A.OUTLINE1RF OUTLINE1RF, ");            // �`�[�E�v1
                selectTxt.Append("A.OUTLINE2RF OUTLINE2RF, ");            //�`�[�E�v2
                selectTxt.Append("A.DEPOSITDATERF DEPOSITDATERF, ");            // ������
                selectTxt.Append("A.CUSTOMERCODERF CUSTOMERCODERF, ");            // ���Ӑ�R�[�h
                selectTxt.Append("A.CUSTOMERSNMRF CUSTOMERSNMRF, ");            // ���Ӑ旪��
                selectTxt.Append("A.SECTIONCODERF SECTIONCODERF, ");            // ���_�R�[�h
                selectTxt.Append("A.VALIDITYTERMRF VALIDITYTERMRF, ");            // �L������
                selectTxt.Append("A.DRAFTDIVIDERF DRAFTDIVIDERF, ");            // ��`�敪
                selectTxt.Append("A.DEPOSITRF DEPOSITRF ");                  // �������z
            }
            //�@��`�敪���x����`
            else if (1 == paraWork.DraftDivide)
            {
                selectTxt.Append("SELECT ");
                selectTxt.Append("A.ENTERPRISECODERF ENTERPRISECODERF, ");            // ��ƃR�[�h
                selectTxt.Append("A.LOGICALDELETECODERF LOGICALDELETECODERF, ");            // �_���폜�敪
                selectTxt.Append("A.PAYDRAFTNORF RCVDRAFTNORF, ");            // ����`�ԍ�
                selectTxt.Append("A.DRAFTKINDCDRF DRAFTKINDCDRF, ");            // ��`���
                selectTxt.Append("A.BANKANDBRANCHCDRF BANKANDBRANCHCDRF, ");            // ��s�E�x�X�R�[�h
                selectTxt.Append("A.BANKANDBRANCHNMRF BANKANDBRANCHNMRF, ");            // ��s�E�x�X����
                selectTxt.Append("A.ADDUPSECCODERF ADDUPSECCODERF, ");            // �v�㋒�_�R�[�h
                selectTxt.Append("A.DRAFTDRAWINGDATERF DRAFTDRAWINGDATERF, ");            // ��`�U�o��
                selectTxt.Append("A.OUTLINE1RF OUTLINE1RF, ");            // �`�[�E�v1
                selectTxt.Append("A.OUTLINE2RF OUTLINE2RF, ");            //�`�[�E�v2
                selectTxt.Append("A.PAYMENTDATERF DEPOSITDATERF, ");            // �x����
                selectTxt.Append("A.SUPPLIERCDRF CUSTOMERCODERF, ");            // �d����R�[�h
                selectTxt.Append("A.SUPPLIERSNMRF CUSTOMERSNMRF, ");            //�d���旪��
                selectTxt.Append("A.SECTIONCODERF SECTIONCODERF, ");            // ���_�R�[�h
                selectTxt.Append("A.VALIDITYTERMRF VALIDITYTERMRF, ");            // �L������
                selectTxt.Append("A.DRAFTDIVIDERF DRAFTDIVIDERF, ");            // ��`�敪
                selectTxt.Append("A.PAYMENTRF DEPOSITRF ");                  // �x�����z
            }
            return selectTxt;
        }
        #endregion [�擾����]

        #region [Where���쐬����]
        /// <summary>
        /// ����`�f�[�^�������������񐶐������Ə����l�ݒ菈��
        /// </summary>
        /// <param name="sql">sql��</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">���������i�[�N���X</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        private StringBuilder MakeWhereString(ref StringBuilder sql, ref SqlCommand sqlCommand, TegataMeisaiListReportParaWork paraWork)
        {
            // �_���폜�敪
            sql.Append(" WHERE A.LOGICALDELETECODERF = 0 ");
            // ��ƃR�[�h=�p�����[�^.��ƃR�[�h
            sql.Append(" AND A.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

            // ��ʎw��̎�`�敪���u����`�v�̏ꍇ
            if (paraWork.DraftDivide == 0)
            {
                // ��ʂ̓�����(�J�n)�����͂��ꂽ�ꍇ
                if (paraWork.DepositDateSt != DateTime.MinValue)
                {
                    sql.Append(" AND A.DEPOSITDATERF >= @FINDDEPOSITDATEST ");
                    SqlParameter paraStDepositDate = sqlCommand.Parameters.Add("@FINDDEPOSITDATEST", SqlDbType.Int);
                    paraStDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.DepositDateSt);
                }
                // ��ʂ̓�����(�I��)�����͂��ꂽ�ꍇ
                if (paraWork.DepositDateEd != DateTime.MinValue)
                {
                    sql.Append(" AND A.DEPOSITDATERF <= @FINDDEPOSITDATEED ");
                    SqlParameter paraEdDepositDate = sqlCommand.Parameters.Add("@FINDDEPOSITDATEED", SqlDbType.Int);
                    paraEdDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.DepositDateEd);
                }
            }
            // ��ʎw��̎�`�敪���u�x����`�v�̏ꍇ
            else
            {
                // ��ʂ̎x����(�J�n)�����͂��ꂽ�ꍇ
                if (paraWork.DepositDateSt != DateTime.MinValue)
                {
                    sql.Append(" AND A.PAYMENTDATERF >= @FINDDEPOSITDATEST ");
                    SqlParameter paraStDepositDate = sqlCommand.Parameters.Add("@FINDDEPOSITDATEST", SqlDbType.Int);
                    paraStDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.DepositDateSt);
                }
                // ��ʂ̎x����(�I��)�����͂��ꂽ�ꍇ
                if (paraWork.DepositDateEd != DateTime.MinValue)
                {
                    sql.Append(" AND A.PAYMENTDATERF <= @FINDDEPOSITDATEED ");
                    SqlParameter paraEdDepositDate = sqlCommand.Parameters.Add("@FINDDEPOSITDATEED", SqlDbType.Int);
                    paraEdDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.DepositDateEd);
                }
 
            }

            // ��ʂ̖�����(�J�n)�����͂��ꂽ�ꍇ
            if (paraWork.MaturityDateSt != DateTime.MinValue)
            {
                sql.Append(" AND A.VALIDITYTERMRF >= @FINDMATURITYDATEST ");
                SqlParameter paraStMaturityDate = sqlCommand.Parameters.Add("@FINDMATURITYDATEST", SqlDbType.Int);
                paraStMaturityDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.MaturityDateSt);
            }
            // ��ʂ̖�����(�I��)�����͂��ꂽ�ꍇ
            if (paraWork.MaturityDateEd != DateTime.MinValue)
            {
                sql.Append(" AND A.VALIDITYTERMRF <= @FINDMATURITYDATEED ");
                SqlParameter paraEdMaturityDate = sqlCommand.Parameters.Add("@FINDMATURITYDATEED", SqlDbType.Int);
                paraEdMaturityDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.MaturityDateEd);
            }

            // ��ʂ̋�s�E�x�X�R�[�h(�J�n)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.BankAndBranchCdSt)) �@
            {
                sql.Append(" AND A.BANKANDBRANCHCDRF >= @FINDSTBANKANDBRANCHCD ");
                SqlParameter paraStBankCode = sqlCommand.Parameters.Add("@FINDSTBANKANDBRANCHCD", SqlDbType.Int);
                paraStBankCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.BankAndBranchCdSt));
            }
            // ��ʂ̋�s�E�x�X�R�[�h(�I��)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.BankAndBranchCdEd)) �@
            {
                sql.Append(" AND A.BANKANDBRANCHCDRF <= @FINDEDBANKANDBRANCHCD  ");
                SqlParameter paraEdBankCode = sqlCommand.Parameters.Add("@FINDEDBANKANDBRANCHCD", SqlDbType.Int);
                paraEdBankCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.BankAndBranchCdEd));
            }

            // ��`���
            if (paraWork.DraftKindCds != null)
            {
                string draftKindString = "";
                foreach (string draftKindCode in paraWork.DraftKindCds)
                {
                    if (!string.IsNullOrEmpty(draftKindCode))
                    {
                        if (!string.IsNullOrEmpty(draftKindString))
                        {
                            draftKindString += ",";
                        }
                        draftKindString += "'" + draftKindCode + "'";
                    }
                }
                if (!string.IsNullOrEmpty(draftKindString))
                {
                    // ��`���
                    sql.Append(" AND A.DRAFTKINDCDRF IN (" + draftKindString + ")  ");

                }
            }
            return sql;
        }
        #endregion

        
        #region [�\�[�g����ݒ�]
        /// <summary>
        /// �\�[�g���̐ݒ�
        /// </summary>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : �\�[�g����ݒ肷��</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        private StringBuilder SortSql(TegataMeisaiListReportParaWork paraWork)
        {
            StringBuilder sql = new StringBuilder(string.Empty);
            // ��`�敪������`
            if (paraWork.DraftDivide == 0)
            {
                // ��`�敪������`�A�o�͏�����`��ʁ{��s/�x�X�{�������{������
                if (paraWork.SortOrder == 0)
                {
                    //��`���
                    sql.Append("ORDER BY A.DRAFTKINDCDRF, ");
                    //��s/�x�X
                    sql.Append("A.BANKANDBRANCHCDRF,  ");
                    //������
                    sql.Append("A.DEPOSITDATERF,  ");
                    //������
                    sql.Append("A.VALIDITYTERMRF,   ");
                    //�U�o��
                    sql.Append("A.DRAFTDRAWINGDATERF,  ");
                    //��`�ԍ�
                    sql.Append("A.RCVDRAFTNORF   ");
                }
                // ��`�敪������`�A�o�͏�����s/�x�X�{��`��ʁ{�������{������
                else if (paraWork.SortOrder == 1)
                {
                    //��s/�x�X
                    sql.Append("ORDER BY A.BANKANDBRANCHCDRF,  ");
                    //��`���
                    sql.Append("A.DRAFTKINDCDRF, ");
                    //������
                    sql.Append("A.DEPOSITDATERF,  ");
                    //������
                    sql.Append("A.VALIDITYTERMRF,   ");
                    //�U�o��
                    sql.Append("A.DRAFTDRAWINGDATERF,  ");
                    //��`�ԍ�
                    sql.Append("A.RCVDRAFTNORF  ");

                }
                // ��`�敪������`�A�o�͏����������{��s/�x�X�{��`��ʁ{������
                else
                {
                    //������
                    sql.Append("ORDER BY A.VALIDITYTERMRF,   ");
                    //��s/�x�X
                    sql.Append("A.BANKANDBRANCHCDRF,  ");
                    //��`���
                    sql.Append("A.DRAFTKINDCDRF, ");
                    //������
                    sql.Append("A.DEPOSITDATERF,  ");
                    //�U�o��
                    sql.Append("A.DRAFTDRAWINGDATERF,  ");
                    //��`�ԍ�
                    sql.Append("A.RCVDRAFTNORF  ");

                }
            }
            else
            {
                // ��`�敪���x����`�A�o�͏�����`��ʁ{��s/�x�X�{�x�����{������
                if (paraWork.SortOrder == 0)
                {
                    //��`���
                    sql.Append("ORDER BY A.DRAFTKINDCDRF, ");
                    //��s/�x�X
                    sql.Append("A.BANKANDBRANCHCDRF,  ");
                    //�x����
                    sql.Append("A.PAYMENTDATERF,  ");
                    //������
                    sql.Append("A.VALIDITYTERMRF,   ");
                    //�U�o��
                    sql.Append("A.DRAFTDRAWINGDATERF,  ");
                    //��`�ԍ�
                    sql.Append("A.PAYDRAFTNORF   ");
                }
                //��`�敪���x����`�A�o�͏�����s/�x�X�{��`��ʁ{�x�����{������
                else if (paraWork.SortOrder == 1)
                {
                    //��s/�x�X
                    sql.Append("ORDER BY A.BANKANDBRANCHCDRF,  ");
                    //��`���
                    sql.Append("A.DRAFTKINDCDRF, ");
                    //�x����
                    sql.Append("A.PAYMENTDATERF,  ");
                    //������
                    sql.Append("A.VALIDITYTERMRF,   ");
                    //�U�o��
                    sql.Append("A.DRAFTDRAWINGDATERF,  ");
                    //��`�ԍ�
                    sql.Append("A.PAYDRAFTNORF  ");

                }
                //��`�敪���x����`�A�o�͏����������{��s/�x�X�{��`��ʁ{�x����
                else
                {
                    //������
                    sql.Append("ORDER BY A.VALIDITYTERMRF,   ");
                    //��s/�x�X
                    sql.Append("A.BANKANDBRANCHCDRF,  ");
                    //��`���
                    sql.Append("A.DRAFTKINDCDRF, ");
                    //�x����
                    sql.Append("A.PAYMENTDATERF,  ");
                    //�U�o��
                    sql.Append("A.DRAFTDRAWINGDATERF,  ");
                    //��`�ԍ�
                    sql.Append("A.PAYDRAFTNORF  ");
                }
            }
            return sql;
        }
        #endregion  [�\�[�g����ݒ�]

       #endregion

        #region �N���X�i�[����
        /// <summary>
        /// �N���X�i�[���� Reader �� TegataMeisaiListReportResultWork
        /// </summary>
        /// <param name="paraWork">���������i�[�N���X</param>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// <br>Note       : Reader����TegataMeisaiListReportResultWork�֕ϊ����܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        private TegataMeisaiListReportResultWork CopyToTegataMeisaiListReportResultWorkFromReader(ref SqlDataReader myReader, TegataMeisaiListReportParaWork paraWork)
        {
            TegataMeisaiListReportResultWork listWork = new TegataMeisaiListReportResultWork();
            #region �N���X�֊i�[

            // ��`���
            listWork.DraftKindCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDCDRF"));
            // ��s�E�x�X�R�[�h
            listWork.BankAndBranchCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKANDBRANCHCDRF"));
            // ��s�E�x�X����
            listWork.BankAndBranchNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKANDBRANCHNMRF"));
            // ������/�x����
            listWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
            // �U�o��
            listWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
            // ������
            listWork.ValidityTerm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
            // ��`�敪
            listWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
            // ����`�ԍ�
            listWork.RcvDraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RCVDRAFTNORF"));
            // �v�㋒�_�R�[�h
            listWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            // ���Ӑ�R�[�h
            listWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            // ���Ӑ旪��
            listWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            // �������z/�x�����z
            listWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
            // �`�[�E�v1
            listWork.Outline1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE1RF"));
            // �`�[�E�v2
            listWork.Outline2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE2RF"));

            return listWork;
            #endregion
        }
        #endregion  �N���X�i�[����

       #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.28</br>
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
