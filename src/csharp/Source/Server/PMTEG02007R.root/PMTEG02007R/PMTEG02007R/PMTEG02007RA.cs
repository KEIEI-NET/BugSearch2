//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`�m�F�\DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : ��`�m�F�\���f�[�^������s���N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �� �� ��  2010/05/05  �C�����e : �V�K�쐬
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
    /// ��`�m�F�\ �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`�m�F�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���`</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    [Serializable]
    public class TegataConfirmReportResultDB : RemoteDB , ITegataConfirmReportResultDB
    {
       #region �N���X�R���X�g���N�^
        /// <summary>
        /// ��`�m�F�\�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public TegataConfirmReportResultDB()
            : base("PMTEG02009D", "Broadleaf.Application.Remoting.ParamData.TegataConfirmReportResultWork", "TegataConfirmReportRESULT")
        {

        }
        #endregion

       #region [Search]
        #region �w�肳�ꂽ�����̎�`�m�F�\�ꗗ�\���LIST�̎擾����
        /// <summary>
        /// �w�肳�ꂽ�����̎�`�m�F�\�ꗗ�\���LIST��߂��܂�
        /// </summary>
        /// <param name="TegataConfirmReportResultWork">��������</param>
        /// <param name="TegataConfirmReportParaWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̎�`�m�F�\���LIST��߂��܂�</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public int Search(out object TegataConfirmReportResultWork, object TegataConfirmReportParaWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            TegataConfirmReportResultWork = new ArrayList();
            try
            {
                //�R���N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �������s��
                status = SearchProc(out TegataConfirmReportResultWork, TegataConfirmReportParaWork, ref sqlConnection);
                
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "TegataConfirmReportResultDB.Search");
                TegataConfirmReportResultWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TegataConfirmReportResultDB.Search");
                TegataConfirmReportResultWork = new ArrayList();
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

        #region �w�肳�ꂽ�����̎�`�m�F�\�ꗗ�\���LIST(�O�������SqlConnection���g�p)
        /// <summary>
        /// �w�肳�ꂽ�����̎�`�m�F�\�ꗗ�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="retList">�������ʌ����p�����[�^</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̎�`�m�F�\�ꗗ�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private int SearchProc(out object retList, object paraObj, ref SqlConnection sqlConnection)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            TegataConfirmReportParaWork paraWork = null;
            paraWork = paraObj as TegataConfirmReportParaWork;

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
                    al.Add(CopyToTegataConfirmReportResultWorkFromReader(ref myReader, paraWork));
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
                status = base.WriteSQLErrorLog(sqlex, "TegataConfirmReportResultDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TegataConfirmReportResultDB.SearchProc" + status);
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
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks> 
        private StringBuilder MakeSearchSQL1(ref StringBuilder selectTxt1, ref SqlCommand sqlCommand, TegataConfirmReportParaWork paraWork)
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
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks> 
        private StringBuilder MakeSearchSQL2(ref StringBuilder selectTxt2, ref SqlCommand sqlCommand, TegataConfirmReportParaWork paraWork)
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
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private StringBuilder SelectRow(TegataConfirmReportParaWork paraWork, StringBuilder selectTxt)
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
                selectTxt.Append("A.DEPOSITRF DEPOSITRF, ");                  // �������z
                selectTxt.Append("A.DEPOSITSLIPNORF  SLIPNORF, ");                  // �����`�[�ԍ�
                selectTxt.Append("A.DRAFTSTMNTDATERF  DRAFTSTMNTDATERF ");                  // ��`���ϓ�
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
                selectTxt.Append("A.PAYMENTRF DEPOSITRF, ");                  // �x�����z
                selectTxt.Append("A.PAYMENTSLIPNORF  SLIPNORF, ");                  // �x���`�[�ԍ�
                selectTxt.Append("A.DRAFTSTMNTDATERF  DRAFTSTMNTDATERF ");                  // ��`���ϓ�
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
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private StringBuilder MakeWhereString(ref StringBuilder sql, ref SqlCommand sqlCommand, TegataConfirmReportParaWork paraWork)
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
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private StringBuilder SortSql(TegataConfirmReportParaWork paraWork)
        {
            StringBuilder sql = new StringBuilder(string.Empty);
            // ��`�敪������`
            if (paraWork.DraftDivide == 0)
            {
                // ��`�敪������`�A�o�͏���������-��`�ԍ� ��
                //������
                sql.Append("ORDER BY A.DEPOSITDATERF, ");
                //��`�ԍ�
                sql.Append("A.RCVDRAFTNORF   ");
            }
            else
            {
                // ��`�敪���x����`�A�o�͏����x����-��`�ԍ� ��
                //�x����
                sql.Append("ORDER BY A.PAYMENTDATERF, ");
                //��`�ԍ�
                sql.Append("A.PAYDRAFTNORF   ");
            }
            return sql;
        }
        #endregion  [�\�[�g����ݒ�]

       #endregion

        #region �N���X�i�[����
        /// <summary>
        /// �N���X�i�[���� Reader �� TegataConfirmReportResultWork
        /// </summary>
        /// <param name="paraWork">���������i�[�N���X</param>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// <br>Note       : Reader����TegataConfirmReportResultWork�֕ϊ����܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private TegataConfirmReportResultWork CopyToTegataConfirmReportResultWorkFromReader(ref SqlDataReader myReader, TegataConfirmReportParaWork paraWork)
        {
            TegataConfirmReportResultWork listWork = new TegataConfirmReportResultWork();
            #region �N���X�֊i�[

            // ��`���
            listWork.DraftKindCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDCDRF"));
            // ��s�E�x�X�R�[�h
            listWork.BankAndBranchCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKANDBRANCHCDRF"));
            // ��s�E�x�X����
            listWork.BankAndBranchNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKANDBRANCHNMRF"));
            // ������/�x����
            listWork.Date = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
            // �U�o��
            listWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
            // ������
            listWork.ValidityTerm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
            // ��`�敪
            listWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
            // ����`�ԍ�
            listWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RCVDRAFTNORF"));
            // �v�㋒�_�R�[�h
            listWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            // ���Ӑ�R�[�h
            listWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            // ���Ӑ旪��
            listWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            // �������z/�x�����z
            listWork.DepositOrPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
            // �`�[�E�v1
            listWork.Outline1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE1RF"));
            // �`�[�E�v2
            listWork.Outline2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE2RF"));
            // �`�[�ԍ�
            listWork.SlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPNORF"));
            // ��`���ϓ�
            listWork.DraftStmntDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTSTMNTDATERF"));
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
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
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
