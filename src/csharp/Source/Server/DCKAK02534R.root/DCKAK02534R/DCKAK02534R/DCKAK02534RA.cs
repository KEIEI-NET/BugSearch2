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
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Diagnostics;  //ADD 2008/07/07 D.Tanaka

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �x���m�F�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �x���m�F�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2007.09.20</br>
    /// <br></br>
    /// <br>Update Note: 2007.12.10  980081 �R�c ���F</br>
    /// <br>           : EdiTakeInDate(EDI�捞��)��Int32��DateTime�ɕύX</br>
    /// <br>Update Note: 2008.04.23  30290</br>
    /// <br>           : ���Ӑ楎d���敪���Ή�</br>
    /// <br></br>
    /// <br>Update Note: �o�l.�m�r�p�ɕύX</br>
    /// <br>Date       : 2008/07/07</br>
    /// <br>           : 99076 �c�� ���</br>
    /// </remarks>
    [Serializable]
    //public class PaymentListWorkDB : RemoteDB, IPaymentListWorkDB             DEL 2008/07/07
    public class PaymentListWorkDB : RemoteWithAppLockDB, IPaymentListWorkDB  //ADD 2008/07/07
    {
        /// <summary>
        /// �x���m�F�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.09.20</br>
        /// <br></br>
        /// <br>Note       : 3��Search�͓������ʂ�Ԃ��Ă܂��B�iUI�J�����ɌX�ɕς���\������)</br>
        /// <br>Date       : 2008/07/07</br>
        /// <br>           : 99076 �c�� ���</br>
        /// </remarks>
        public PaymentListWorkDB()
            :
        base("DCKAK02536D", "Broadleaf.Application.Remoting.ParamData.PaymentSlpListResultWork", "PAYMENTSLPRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region �x���m�F�\(�Ȉ�)
        /// <summary>
        /// �x���m�F�\(�����E�ڍ�)LIST��߂��܂�
        /// </summary>
        /// <param name="paymentSlpListResultWork">��������(�����E�ڍ�)</param>
        /// <param name="paymentSlpCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �x���m�F�\(�����E�ڍ�)LIST��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.09.20</br>
        public int SearchDepsitOnly(out object paymentSlpListResultWork, object paymentSlpCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            paymentSlpListResultWork = null;

            PaymentSlpCndtnWork _paymentSlpCndtnWork = paymentSlpCndtnWork as PaymentSlpCndtnWork;

            try
            {
                status = SearchDepsitOnlyProc(out paymentSlpListResultWork, _paymentSlpCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchDepsitOnly Exception=" + ex.Message);
                paymentSlpListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �x���m�F�\(�����E�ڍ�)LIST��߂��܂�
        /// </summary>
        /// <param name="paymentSlpListResultWork">��������(�����E�ڍ�)</param>
        /// <param name="_paymentSlpCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �x���m�F�\(�����E�ڍ�)LIST��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.09.20</br>
        private int SearchDepsitOnlyProc(out object paymentSlpListResultWork, PaymentSlpCndtnWork _paymentSlpCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlEncryptInfo sqlEncryptInfo = null;

            paymentSlpListResultWork = null;

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

                //���Í������i�������� ��2008/07/07 ����̓R�����g�A�E�g�i�Í����͕ʓr�Ή��j
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SUPPLIERRF" });
                //�Í����L�[OPEN�iSQLException�̉\���L��j
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //�x���f�[�^�擾���s��
                status = SearchDepsitOnlyAction(ref al, ref sqlConnection, _paymentSlpCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchDepositOnlyProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    //�Í����L�[�N���[�Y
                    if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            paymentSlpListResultWork = al;

            return status;
        }
        #endregion

        #region �x���m�F�\(����ʏW�v)
        /// <summary>
        /// �x���m�F�\(����ʏW�v)LIST��߂��܂�
        /// </summary>
        /// <param name="paymentSlpListResultWork">��������(�����E�ڍ�)</param>
        /// <param name="paymentSlpCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �x���m�F�\(����ʏW�v)LIST��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.09.20</br>
        public int SearchDepsitKind(out object paymentSlpListResultWork, object paymentSlpCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            paymentSlpListResultWork = null;

            PaymentSlpCndtnWork _paymentSlpCndtnWork = paymentSlpCndtnWork as PaymentSlpCndtnWork;

            try
            {
                status = SearchDepsitKindProc(out paymentSlpListResultWork, _paymentSlpCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchDepsitOnly Exception=" + ex.Message);
                paymentSlpListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �x���m�F�\(����ʏW�v)LIST��߂��܂�
        /// </summary>
        /// <param name="paymentSlpListResultWork">��������(����ʏW�v)</param>
        /// <param name="_paymentSlpCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �x���m�F�\(����ʏW�v)LIST��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.09.20</br>
        private int SearchDepsitKindProc(out object paymentSlpListResultWork, PaymentSlpCndtnWork _paymentSlpCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlEncryptInfo sqlEncryptInfo = null;

            paymentSlpListResultWork = null;

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

                //���Í������i�������� 2008/07/07 ����̓R�����g�A�E�g�i�Í����͕ʓr�Ή��j
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SUPPLIERRF" });
                //�Í����L�[OPEN�iSQLException�̉\���L��j
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //�x���f�[�^�擾���s��
                status = SearchDepsitKindAction(ref al, ref sqlConnection, _paymentSlpCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchDepositKindProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    //�Í����L�[�N���[�Y
                    if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            paymentSlpListResultWork = al;

            return status;
        }
        #endregion

        // 2008/07/07 DEL-Start ��7/8���r���[�ő����v�͕s�v�ƂȂ��� -------------- >>>>>
        #region �x���m�F�\(�����v)
        /*
        /// <summary>
        /// �x���m�F�\(�����v)LIST��߂��܂�
        /// </summary>
        /// <param name="paymentSlpListResultWork">��������(�����v)</param>
        /// <param name="paymentSlpCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sectionDepositDiv">sectionDepositDiv</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �x���m�F�\(�����v)LIST��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.09.20</br>
        public int SearchAllTotal(out object paymentSlpListResultWork, object paymentSlpCndtnWork, int readMode, int sectionDepositDiv, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            paymentSlpListResultWork = null;

            PaymentSlpCndtnWork _paymentSlpCndtnWork = paymentSlpCndtnWork as PaymentSlpCndtnWork;

            try
            {
                status = SearchAllTotalProc(out paymentSlpListResultWork, _paymentSlpCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchAllTotal Exception=" + ex.Message);
                paymentSlpListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �x���m�F�\(�����v)LIST��߂��܂�
        /// </summary>
        /// <param name="paymentSlpListResultWork">��������(�����v)</param>
        /// <param name="_paymentSlpCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �x���m�F�\(�����v)LIST��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.09.20</br>
        private int SearchAllTotalProc(out object paymentSlpListResultWork, PaymentSlpCndtnWork _paymentSlpCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlEncryptInfo sqlEncryptInfo = null;

            paymentSlpListResultWork = null;

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

                //���Í������i��������  2008/07/07 ����̓R�����g�A�E�g�i�Í����͕ʓr�Ή��j
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SUPPLIERRF" });
                //�Í����L�[OPEN�iSQLException�̉\���L��j
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //�����v�擾���s��
                status = SearchAllTotalAction(ref al, ref sqlConnection, _paymentSlpCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchAllTotalProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    //�Í����L�[�N���[�Y
                    if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            paymentSlpListResultWork = al;

            return status;
        }
         */
        #endregion
        // 2008/07/07 DEL-End ---------------------------------------------------- <<<<<


        #region �x���m�F�\(�Ȉ�)�擾����(SQL���s��)
        /// <summary>
        /// �x���m�F�\(�����E�ڍ�)�擾����(SQL���s��)
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_paymentSlpCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchDepsitOnlyAction(ref ArrayList al, ref SqlConnection sqlConnection, PaymentSlpCndtnWork _paymentSlpCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                //--- UPD 2008/07/07 D.Tanaka --->>>
                string sqlText = string.Empty;

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += " SLP.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEECODERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEENAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEENAME2RF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEESNMRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPSECTIONCDRF" + Environment.NewLine;
                sqlText += " ,SECI.SECTIONGUIDESNMRF PAYMENTINPSECTIONNMRF" + Environment.NewLine;
                sqlText += " ,SLP.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += " ,SECI2.SECTIONGUIDESNMRF ADDUPSECNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTDATERF" + Environment.NewLine;
                sqlText += " ,SLP.ADDUPADATERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTTOTALRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.FEEPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.DISCOUNTPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.AUTOPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDRAWINGDATERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTKINDRF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTKINDNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDIVIDERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDIVIDENAMERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTNORF" + Environment.NewLine;
                sqlText += " ,SLP.DEBITNOTELINKPAYNORF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTAGENTCODERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTAGENTNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPUTAGENTCDRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPUTAGENTNMRF" + Environment.NewLine;
                sqlText += " ,SLP.OUTLINERF" + Environment.NewLine;
                sqlText += " ,SLP.BANKCODERF" + Environment.NewLine;
                sqlText += " ,SLP.BANKNAMERF" + Environment.NewLine;
                //sqlText += " ,SLP.CREATEDATETIMERF" + Environment.NewLine; // ADD 2009/02/18
                sqlText += " ,SLP.INPUTDAYRF" + Environment.NewLine; // ADD 2009/03/26
                sqlText += " ,DTL.PAYMENTROWNORF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDCODERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDDIVRF" + Environment.NewLine;
                // �C�� 2009.01.26 >>>
                //sqlText += " ,DTL.PAYMENTRF PAYMENTMEIRF" + Environment.NewLine;
                sqlText += " ,(CASE WHEN DEBITNOTEDIVRF = 1 THEN  DTL.PAYMENTRF * -1 ELSE DTL.PAYMENTRF END) AS PAYMENTMEIRF" + Environment.NewLine;
                // �C�� 2009.01.26 <<<
                sqlText += " ,DTL.VALIDITYTERMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PAYMENTSLPRF AS SLP LEFT OUTER JOIN PAYMENTDTLRF AS DTL" + Environment.NewLine;   // �x���`�[�}�X�^�A�x�����׃f�[�^
                sqlText += "    ON  SLP.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                // �C�� 2009.01.26 >>>
                //sqlText += "    AND SLP.PAYMENTSLIPNORF = DTL.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += "       AND ((SLP.DEBITNOTEDIVRF != 1 AND SLP.PAYMENTSLIPNORF = DTL.PAYMENTSLIPNORF) OR" + Environment.NewLine;
                sqlText += "       (SLP.DEBITNOTEDIVRF = 1 AND SLP.DEBITNOTELINKPAYNORF = DTL.PAYMENTSLIPNORF))" + Environment.NewLine;
                // �C�� 2009.01.26 <<<
                sqlText += "  LEFT OUTER JOIN SUPPLIERRF AS SPPL" + Environment.NewLine;                        // �d����}�X�^
                sqlText += "    ON  SLP.ENTERPRISECODERF = SPPL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.SUPPLIERCDRF = SPPL.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;                      // ���_���ݒ�}�X�^
                sqlText += "    ON  SLP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.PAYMENTINPSECTIONCDRF = SECI.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI2" + Environment.NewLine;
                sqlText += "    ON  SLP.ENTERPRISECODERF = SECI2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.ADDUPSECCODERF = SECI2.SECTIONCODERF" + Environment.NewLine;

                //���x���`�[�͓����[���i����ALL�[���~�j�́w���׃��R�[�h�Ȃ��x�`�[�̓o�^���\�ȈׁA"LEFT OUTER JOIN" �Ƃ���B

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                # region [DC.NS-SQL��]
                /* DEL
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT���̍쐬
                sqlCommand.CommandText += "SELECT " +
                                          "A.DEBITNOTEDIVRF, " +
                                          "A.PAYMENTSLIPNORF, " +
                                          "A.SUPPLIERSLIPNORF, " +
                                          "A.SUPPLIERCDRF, " +
                                          "A.SUPPLIERNM1RF, " +
                                          "A.SUPPLIERNM2RF, " +
                                          "B.KANARF AS KANARF, ";
                if (_paymentSlpCndtnWork.IsOptSection == false)
                {
                    sqlCommand.CommandText += "A.PAYMENTINPSECTIONCDRF, " +
                                              "C.SECTIONGUIDENMRF AS PAYMENTINPSECTIONNMRF, " +
                                              "A.ADDUPSECCODERF, " +
                                              "D.SECTIONGUIDENMRF AS ADDUPSECNAMERF, ";
                }
                else
                {
                    // �S�БI��
                    sqlCommand.CommandText += "'' PAYMENTINPSECTIONCDRF, " +  // �x�����͋��_�R�[�h
                                              "'' PAYMENTINPSECTIONNMRF, " +  // �x�����͋��_����
                                              "'' ADDUPSECCODERF, " +         // �v�㋒�_�R�[�h
                                              "'' ADDUPSECNAMERF, ";          // �v�㋒�_����
                }

                sqlCommand.CommandText += "A.UPDATESECCDRF, " +
                                          "A.SUBSECTIONCODERF, " +
                                          "A.MINSECTIONCODERF, " +
                                          "A.PAYMENTDATERF, " +
                                          "A.ADDUPADATERF, " +
                                          "A.PAYMENTMONEYKINDCODERF, " +
                                          "A.PAYMENTMONEYKINDNAMERF, " +
                                          "A.PAYMENTMONEYKINDDIVRF, " +
                                          "A.PAYMENTTOTALRF, " +
                                          "A.PAYMENTRF, " +
                                          "A.FEEPAYMENTRF, " +
                                          "A.DISCOUNTPAYMENTRF, " +
                                          "A.REBATEPAYMENTRF, " +
                                          "A.AUTOPAYMENTRF, " +
                                          "A.CREDITORLOANCDRF, " +
                                          "A.CREDITCOMPANYCODERF, " +
                                          "A.DRAFTDRAWINGDATERF, " +
                                          "A.DRAFTPAYTIMELIMITRF, " +
                                          "A.DRAFTKINDRF, " +
                                          "A.DRAFTKINDNAMERF, " +
                                          "A.DRAFTDIVIDERF, " +
                                          "A.DRAFTDIVIDENAMERF, " +
                                          "A.DRAFTNORF, " +
                                          "A.DEBITNOTELINKPAYNORF, " +
                                          "A.PAYMENTAGENTCODERF, " +
                                          "A.PAYMENTAGENTNAMERF, " +
                                          "A.PAYMENTINPUTAGENTCDRF, " +
                                          "A.PAYMENTINPUTAGENTNMRF, " +
                                          "A.OUTLINERF, " +
                                          "A.BANKCODERF, " +
                                          "A.BANKNAMERF, " +
                                          "A.EDISENDDATERF, " +
                                          "A.EDITAKEINDATERF, " +
                                          "A.TEXTEXTRADATERF " +
                                          //"E.CREDITCOMPANYNAME " +
                                          "FROM PAYMENTSLPRF A " +
                                          "LEFT JOIN SUPPLIERRF B ON B.ENTERPRISECODERF=A.ENTERPRISECODERF AND B.SUPPLIERCDRF=A.SUPPLIERCDRF " +
                                          "LEFT JOIN SECINFOSETRF C ON C.ENTERPRISECODERF=A.ENTERPRISECODERF AND C.SECTIONCODERF=A.PAYMENTINPSECTIONCDRF " +
                                          "LEFT JOIN SECINFOSETRF D ON D.ENTERPRISECODERF=A.ENTERPRISECODERF AND D.SECTIONCODERF=A.ADDUPSECCODERF ";
                //"LEFT JOIN CREDITCMPRF E ON E.ENTERPRISECODERF=A.ENTERPRISECODERF AND E.CREDITCOMPANYCODERF=A.CREDITCOMPANYCODERF ";
                // ��2008/07/07 A��SLP�AB��SPPL�AC��SECI�AD��SECI2

                 */
                # endregion
                //--- UPD 2008/07/07 D.Tanaka ---<<<

                //WHERE��(ORDER BY�����܂�)�̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _paymentSlpCndtnWork, logicalMode);

#if DEBUG
                Console.Clear();  //ADD 2008/07/07
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));  //ADD 2008/07/07
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    PaymentSlpListResultWork paymentSlpListResultWork = new PaymentSlpListResultWork();

                    // 2008/07/07 UPD-Start -------------------------------------------------- >>>>>
                    #region paymentSlpListResultWork�ɒl���Z�b�g
                    paymentSlpListResultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    paymentSlpListResultWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                    paymentSlpListResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    paymentSlpListResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    paymentSlpListResultWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    paymentSlpListResultWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    paymentSlpListResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    paymentSlpListResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    paymentSlpListResultWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
                    paymentSlpListResultWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
                    paymentSlpListResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                    paymentSlpListResultWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                    paymentSlpListResultWork.PaymentInpSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONNMRF"));
                    paymentSlpListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    paymentSlpListResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                    paymentSlpListResultWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                    paymentSlpListResultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    paymentSlpListResultWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                    paymentSlpListResultWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                    paymentSlpListResultWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                    paymentSlpListResultWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                    paymentSlpListResultWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                    paymentSlpListResultWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                    paymentSlpListResultWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                    paymentSlpListResultWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                    paymentSlpListResultWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                    paymentSlpListResultWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                    paymentSlpListResultWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                    paymentSlpListResultWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
                    paymentSlpListResultWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
                    paymentSlpListResultWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
                    paymentSlpListResultWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
                    paymentSlpListResultWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
                    paymentSlpListResultWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    paymentSlpListResultWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                    paymentSlpListResultWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                    //paymentSlpListResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // ADD 2009/02/18
                    paymentSlpListResultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    paymentSlpListResultWork.PaymentRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTROWNORF"));
                    paymentSlpListResultWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
                    paymentSlpListResultWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                    paymentSlpListResultWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
                    paymentSlpListResultWork.PaymentMei = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTMEIRF"));
                    paymentSlpListResultWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
                    #endregion

                    #region OLD-DC.NS�N���X�֊i�[
                    /*
                    paymentSlpListResultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    paymentSlpListResultWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                    paymentSlpListResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    paymentSlpListResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    paymentSlpListResultWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    paymentSlpListResultWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    paymentSlpListResultWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                    paymentSlpListResultWork.PaymentInpSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONNMRF"));
                    paymentSlpListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    paymentSlpListResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                    paymentSlpListResultWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                    paymentSlpListResultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    paymentSlpListResultWork.PaymentMoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDCODERF"));
                    paymentSlpListResultWork.PaymentMoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDNAMERF"));
                    paymentSlpListResultWork.PaymentMoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDDIVRF"));
                    paymentSlpListResultWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                    paymentSlpListResultWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                    paymentSlpListResultWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                    paymentSlpListResultWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                    paymentSlpListResultWork.RebatePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REBATEPAYMENTRF"));
                    paymentSlpListResultWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                    paymentSlpListResultWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
                    paymentSlpListResultWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                    paymentSlpListResultWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                    paymentSlpListResultWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                    paymentSlpListResultWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                    paymentSlpListResultWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                    paymentSlpListResultWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                    paymentSlpListResultWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                    paymentSlpListResultWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                    paymentSlpListResultWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
                    paymentSlpListResultWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
                    paymentSlpListResultWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
                    paymentSlpListResultWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
                    paymentSlpListResultWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
                    paymentSlpListResultWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    paymentSlpListResultWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                    paymentSlpListResultWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                    paymentSlpListResultWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                    // �� 2007.12.10 980081 c
                    //paymentSlpListResultWork.EdiTakeInDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                    paymentSlpListResultWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                    // �� 2007.12.10 980081 c
                    paymentSlpListResultWork.TextExtraDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TEXTEXTRADATERF"));
                    //paymentSlpListResultWork.CreditCompanyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYNAMERF"));
                    //paymentSlpListResultWork.CashPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHPAYMENTRF"));
                    //paymentSlpListResultWork.TransferPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRANSFERPAYMENTRF"));
                    //paymentSlpListResultWork.DraftPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTPAYMENTRF"));
                    //paymentSlpListResultWork.OffsetPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETPAYMENTRF"));
                    //paymentSlpListResultWork.CheckPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKPAYMENTRF"));
                    //paymentSlpListResultWork.FutureCheckPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUTURECHECKPAYMENTRF"));
                    //paymentSlpListResultWork.OtherPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHERPAYMENTRF"));
                     */
                    #endregion
                    // 2008/07/07 UPD-End ---------------------------------------------------- <<<<<

                    al.Add(paymentSlpListResultWork);

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
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchDepsitOnlyAction Exception=" + ex.Message);
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

        #region �x���m�F�\(����ʏW�v)�擾����(SQL���s��)
        /// <summary>
        /// �x���m�F�\(����ʏW�v)�擾����(SQL���s��)
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_paymentSlpCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchDepsitKindAction(ref ArrayList al, ref SqlConnection sqlConnection, PaymentSlpCndtnWork _paymentSlpCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                //--- UPD 2008/07/07 D.Tanaka --->>>
                string sqlText = string.Empty;

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += " SLP.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEECODERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEENAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEENAME2RF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEESNMRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPSECTIONCDRF" + Environment.NewLine;
                sqlText += " ,SECI.SECTIONGUIDESNMRF PAYMENTINPSECTIONNMRF" + Environment.NewLine;
                sqlText += " ,SLP.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += " ,SECI2.SECTIONGUIDESNMRF ADDUPSECNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTDATERF" + Environment.NewLine;
                sqlText += " ,SLP.ADDUPADATERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTTOTALRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.FEEPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.DISCOUNTPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.AUTOPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDRAWINGDATERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTKINDRF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTKINDNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDIVIDERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDIVIDENAMERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTNORF" + Environment.NewLine;
                sqlText += " ,SLP.DEBITNOTELINKPAYNORF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTAGENTCODERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTAGENTNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPUTAGENTCDRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPUTAGENTNMRF" + Environment.NewLine;
                sqlText += " ,SLP.OUTLINERF" + Environment.NewLine;
                sqlText += " ,SLP.BANKCODERF" + Environment.NewLine;
                sqlText += " ,SLP.BANKNAMERF" + Environment.NewLine;
                sqlText += " ,DTL.PAYMENTROWNORF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDCODERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDDIVRF" + Environment.NewLine;
                // �C�� 2009.01.26 >+>>
                //sqlText += " ,DTL.PAYMENTRF PAYMENTMEIRF" + Environment.NewLine;
                sqlText += " ,(CASE WHEN DEBITNOTEDIVRF = 1 THEN  DTL.PAYMENTRF * -1 ELSE DTL.PAYMENTRF END) AS PAYMENTMEIRF" + Environment.NewLine;
                // �C�� 2009.01.26 <<<
                sqlText += " ,DTL.VALIDITYTERMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PAYMENTSLPRF AS SLP LEFT OUTER JOIN PAYMENTDTLRF AS DTL" + Environment.NewLine;   // �x���`�[�}�X�^�A�x�����׃f�[�^
                sqlText += "    ON  SLP.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                // �C�� 2009.01.26 >>>
                //sqlText += "    AND SLP.PAYMENTSLIPNORF = DTL.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += "       AND ((SLP.DEBITNOTEDIVRF != 1 AND SLP.PAYMENTSLIPNORF = DTL.PAYMENTSLIPNORF) OR" + Environment.NewLine;
                sqlText += "       (SLP.DEBITNOTEDIVRF = 1 AND SLP.DEBITNOTELINKPAYNORF = DTL.PAYMENTSLIPNORF))" + Environment.NewLine;
                // �C�� 2009.01.26 <<<
                sqlText += "  LEFT OUTER JOIN SUPPLIERRF AS SPPL" + Environment.NewLine;                        // �d����}�X�^
                sqlText += "    ON  SLP.ENTERPRISECODERF = SPPL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.SUPPLIERCDRF = SPPL.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;                      // ���_���ݒ�}�X�^
                sqlText += "    ON  SLP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.PAYMENTINPSECTIONCDRF = SECI.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI2" + Environment.NewLine;
                sqlText += "    ON  SLP.ENTERPRISECODERF = SECI2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.ADDUPSECCODERF = SECI2.SECTIONCODERF" + Environment.NewLine;

                //���x���`�[�͓����[���i����ALL�[���~�j�́w���׃��R�[�h�Ȃ��x�`�[�̓o�^���\�ȈׁA"LEFT OUTER JOIN" �Ƃ���B

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //WHERE��(GROUP BY�����܂�)�̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _paymentSlpCndtnWork, logicalMode);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    PaymentSlpListResultWork paymentSlpListResultWork = new PaymentSlpListResultWork();

                    #region paymentSlpListResultWork�ɒl���Z�b�g
                    paymentSlpListResultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    paymentSlpListResultWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                    paymentSlpListResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    paymentSlpListResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    paymentSlpListResultWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    paymentSlpListResultWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    paymentSlpListResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    paymentSlpListResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    paymentSlpListResultWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
                    paymentSlpListResultWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
                    paymentSlpListResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                    paymentSlpListResultWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                    paymentSlpListResultWork.PaymentInpSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONNMRF"));
                    paymentSlpListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    paymentSlpListResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                    paymentSlpListResultWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                    paymentSlpListResultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    paymentSlpListResultWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                    paymentSlpListResultWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                    paymentSlpListResultWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                    paymentSlpListResultWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                    paymentSlpListResultWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                    paymentSlpListResultWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                    paymentSlpListResultWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                    paymentSlpListResultWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                    paymentSlpListResultWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                    paymentSlpListResultWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                    paymentSlpListResultWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                    paymentSlpListResultWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
                    paymentSlpListResultWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
                    paymentSlpListResultWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
                    paymentSlpListResultWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
                    paymentSlpListResultWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
                    paymentSlpListResultWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    paymentSlpListResultWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                    paymentSlpListResultWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                    paymentSlpListResultWork.PaymentRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTROWNORF"));
                    paymentSlpListResultWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
                    paymentSlpListResultWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                    paymentSlpListResultWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
                    paymentSlpListResultWork.PaymentMei = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTMEIRF"));
                    paymentSlpListResultWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
                    #endregion

                    al.Add(paymentSlpListResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }


                # region [DC.NS-SQL�����e����̏W�v]
                /* �폜
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT���̍쐬
                sqlCommand.CommandText += "SELECT ";
                if (_paymentSlpCndtnWork.IsOptSection == false)
                {
                    sqlCommand.CommandText += "A.ADDUPSECCODERF, " +
                                              "D.SECTIONGUIDENMRF AS ADDUPSECNAMERF, ";
                }
                else
                {
                    sqlCommand.CommandText += "'' ADDUPSECCODERF, " +
                                              "'' ADDUPSECNAMERF, ";
                }
                sqlCommand.CommandText += "A.ADDUPADATERF, " +
                                          "A.PAYMENTMONEYKINDDIVRF, " +
                                          "SUM (A.PAYMENTTOTALRF) AS PAYMENTTOTALRF " +
                                          "FROM PAYMENTSLPRF A " +
                                          "LEFT JOIN SECINFOSETRF D ON D.ENTERPRISECODERF=A.ENTERPRISECODERF AND D.SECTIONCODERF=A.ADDUPSECCODERF ";

                //WHERE��(GROUP BY�����܂�)�̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _paymentSlpCndtnWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                bool firstFlg = true;
                DateTime addUpADate = DateTime.MinValue;
                string addUpSecCode = null;
                string addUpSecName = null;
                Int64 cashPayment = 0;
                Int64 transferPayment = 0;
                Int64 draftPayment = 0;
                Int64 offsetPayment = 0;
                Int64 checkPayment = 0;
                Int64 futureCheckPayment = 0;
                Int64 otherPayment = 0;
                Int64 feePayment = 0;
                Int64 discountPayment = 0;
                while (myReader.Read())
                {
                    if (firstFlg == true)
                    {
                        firstFlg = false;
                        addUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));            // �v�㋒�_�R�[�h
                        addUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));            // �v�㋒�_����
                        addUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));  // �v����t 
                    }
                    else if (addUpADate != SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF")) || addUpSecCode != SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF")))
                    {
                        PaymentSlpListResultWork paymentSlpListResultWork = new PaymentSlpListResultWork();
                        #region paymentSlpListResultWork�ɒl���Z�b�g
                        paymentSlpListResultWork.AddUpSecCode = addUpSecCode;
                        paymentSlpListResultWork.AddUpSecName = addUpSecName;
                        paymentSlpListResultWork.AddUpADate = addUpADate;

                        paymentSlpListResultWork.CashPayment = cashPayment;
                        paymentSlpListResultWork.TransferPayment = transferPayment;
                        paymentSlpListResultWork.DraftPayment = draftPayment;
                        paymentSlpListResultWork.OffsetPayment = offsetPayment;
                        paymentSlpListResultWork.CheckPayment = checkPayment;
                        paymentSlpListResultWork.FutureCheckPayment = futureCheckPayment;
                        paymentSlpListResultWork.OtherPayment = otherPayment;
                        paymentSlpListResultWork.FeePayment = feePayment;
                        paymentSlpListResultWork.DiscountPayment = discountPayment;
                        #endregion
                        al.Add(paymentSlpListResultWork);
                        
                        addUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        addUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                        addUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                        cashPayment = 0;
                        transferPayment = 0;
                        draftPayment = 0;
                        offsetPayment = 0;
                        checkPayment = 0;
                        futureCheckPayment = 0;
                        otherPayment = 0;
                        feePayment = 0;
                        discountPayment = 0;
                    }

                    switch (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDDIVRF")))
                    {
                        case 101://����
                            {
                                cashPayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                        case 102://�U��
                            {
                                transferPayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                        case 105://��`
                            {
                                draftPayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                        case 106://���E
                            {
                                offsetPayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                        case 107://���؎�
                            {
                                checkPayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                        case 108://��t���؎�
                            {
                                futureCheckPayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                        case 109://���̑�
                            {
                                otherPayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                        case 110://�萔��
                            {
                                feePayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                        case 111://�l��
                            {
                                discountPayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (firstFlg == false)
                {
                    PaymentSlpListResultWork paymentSlpListResultWork = new PaymentSlpListResultWork();
                    #region paymentSlpListResultWork�ɒl���Z�b�g
                    paymentSlpListResultWork.AddUpSecCode = addUpSecCode;
                    paymentSlpListResultWork.AddUpSecName = addUpSecName;
                    paymentSlpListResultWork.AddUpADate = addUpADate;

                    paymentSlpListResultWork.CashPayment = cashPayment;
                    paymentSlpListResultWork.TransferPayment = transferPayment;
                    paymentSlpListResultWork.DraftPayment = draftPayment;
                    paymentSlpListResultWork.OffsetPayment = offsetPayment;
                    paymentSlpListResultWork.CheckPayment = checkPayment;
                    paymentSlpListResultWork.FutureCheckPayment = futureCheckPayment;
                    paymentSlpListResultWork.OtherPayment = otherPayment;
                    paymentSlpListResultWork.FeePayment = feePayment;
                    paymentSlpListResultWork.DiscountPayment = discountPayment;
                    #endregion
                    al.Add(paymentSlpListResultWork);
                }
                 */
                # endregion
                //--- UPD 2008/07/07 D.Tanaka ---<<<
            }
            
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchDepsitKindAction Exception=" + ex.Message);
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

        // 2008/07/07 DEL-Start ��7/8���r���[�ő����v�͕s�v�ƂȂ��� -------------- >>>>>
        #region �x���m�F�\(�����v)�擾����(SQL���s��)
        /*
        /// <summary>
        /// �x���m�F�\(�����v)�擾����(SQL���s��)
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_paymentSlpCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchAllTotalAction(ref ArrayList al, ref SqlConnection sqlConnection, PaymentSlpCndtnWork _paymentSlpCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                //--- UPD 2008/07/07 D.Tanaka --->>>
                string sqlText = string.Empty;

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += " SLP.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEECODERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEENAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEENAME2RF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEESNMRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPSECTIONCDRF" + Environment.NewLine;
                sqlText += " ,SECI.SECTIONGUIDESNMRF PAYMENTINPSECTIONNMRF" + Environment.NewLine;
                sqlText += " ,SLP.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += " ,SECI2.SECTIONGUIDESNMRF ADDUPSECNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTDATERF" + Environment.NewLine;
                sqlText += " ,SLP.ADDUPADATERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTTOTALRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.FEEPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.DISCOUNTPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.AUTOPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDRAWINGDATERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTKINDRF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTKINDNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDIVIDERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDIVIDENAMERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTNORF" + Environment.NewLine;
                sqlText += " ,SLP.DEBITNOTELINKPAYNORF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTAGENTCODERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTAGENTNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPUTAGENTCDRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPUTAGENTNMRF" + Environment.NewLine;
                sqlText += " ,SLP.OUTLINERF" + Environment.NewLine;
                sqlText += " ,SLP.BANKCODERF" + Environment.NewLine;
                sqlText += " ,SLP.BANKNAMERF" + Environment.NewLine;
                sqlText += " ,DTL.PAYMENTROWNORF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDCODERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDDIVRF" + Environment.NewLine;
                sqlText += " ,DTL.PAYMENTRF PAYMENTMEIRF" + Environment.NewLine;
                sqlText += " ,DTL.VALIDITYTERMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PAYMENTSLPRF AS SLP LEFT OUTER JOIN PAYMENTDTLRF AS DTL" + Environment.NewLine;   // �x���`�[�}�X�^�A�x�����׃f�[�^
                sqlText += "    ON  SLP.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.PAYMENTSLIPNORF = DTL.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SUPPLIERRF AS SPPL" + Environment.NewLine;                        // �d����}�X�^
                sqlText += "    ON  SLP.ENTERPRISECODERF = SPPL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.SUPPLIERCDRF = SPPL.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;                      // ���_���ݒ�}�X�^
                sqlText += "    ON  SLP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.PAYMENTINPSECTIONCDRF = SECI.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI2" + Environment.NewLine;
                sqlText += "    ON  SLP.ENTERPRISECODERF = SECI2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.ADDUPSECCODERF = SECI2.SECTIONCODERF" + Environment.NewLine;

                //���x���`�[�͓����[���i����ALL�[���~�j�́w���׃��R�[�h�Ȃ��x�`�[�̓o�^���\�ȈׁA"LEFT OUTER JOIN" �Ƃ���B

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //WHERE��(GROUP BY�����܂�)�̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _paymentSlpCndtnWork, logicalMode);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    PaymentSlpListResultWork paymentSlpListResultWork = new PaymentSlpListResultWork();

                    #region paymentSlpListResultWork�ɒl���Z�b�g
                    paymentSlpListResultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    paymentSlpListResultWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                    paymentSlpListResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    paymentSlpListResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    paymentSlpListResultWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    paymentSlpListResultWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    paymentSlpListResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    paymentSlpListResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    paymentSlpListResultWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
                    paymentSlpListResultWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
                    paymentSlpListResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                    paymentSlpListResultWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                    paymentSlpListResultWork.PaymentInpSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONNMRF"));
                    paymentSlpListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    paymentSlpListResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                    paymentSlpListResultWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                    paymentSlpListResultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    paymentSlpListResultWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                    paymentSlpListResultWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                    paymentSlpListResultWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                    paymentSlpListResultWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                    paymentSlpListResultWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                    paymentSlpListResultWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                    paymentSlpListResultWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                    paymentSlpListResultWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                    paymentSlpListResultWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                    paymentSlpListResultWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                    paymentSlpListResultWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                    paymentSlpListResultWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
                    paymentSlpListResultWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
                    paymentSlpListResultWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
                    paymentSlpListResultWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
                    paymentSlpListResultWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
                    paymentSlpListResultWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    paymentSlpListResultWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                    paymentSlpListResultWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                    paymentSlpListResultWork.PaymentRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTROWNORF"));
                    paymentSlpListResultWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
                    paymentSlpListResultWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                    paymentSlpListResultWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
                    paymentSlpListResultWork.PaymentMei = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTMEIRF"));
                    paymentSlpListResultWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
                    #endregion

                    al.Add(paymentSlpListResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                // 2008/07/07 �폜
                # region [DC.NS-SQL�����e����̏W�v]
                //sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT���̍쐬
                //sqlCommand.CommandText += "SELECT ";
                //if (_paymentSlpCndtnWork.IsOptSection == false)
                //{
                //    sqlCommand.CommandText += "A.ADDUPSECCODERF, " +
                //                              "D.SECTIONGUIDENMRF AS ADDUPSECNAMERF, ";
                //}
                //else
                //{
                //    sqlCommand.CommandText += "'' ADDUPSECCODERF, " +
                //                              "'' ADDUPSECNAMERF, ";
                //}
                //sqlCommand.CommandText += "A.PAYMENTMONEYKINDCODERF, " +
                //                          "A.PAYMENTMONEYKINDNAMERF, " +
                //                          "SUM (A.PAYMENTTOTALRF) AS PAYMENTTOTALRF, " +
                //                          "SUM (A.PAYMENTRF) AS PAYMENTRF, " +
                //                          "SUM (A.FEEPAYMENTRF) AS FEEPAYMENTRF, " +
                //                          "SUM (A.DISCOUNTPAYMENTRF) AS DISCOUNTPAYMENTRF, " +
                //                          "SUM (A.REBATEPAYMENTRF) AS REBATEPAYMENTRF " +
                //                          "FROM PAYMENTSLPRF A " +
                //                          "LEFT JOIN SECINFOSETRF D ON D.ENTERPRISECODERF=A.ENTERPRISECODERF AND D.SECTIONCODERF=A.ADDUPSECCODERF ";

                //WHERE��(GROUP BY�����܂�)�̍쐬
                //sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _paymentSlpCndtnWork, logicalMode);

                //myReader = sqlCommand.ExecuteReader();

                //while (myReader.Read())
                //{
                //    PaymentSlpListResultWork paymentSlpListResultWork = new PaymentSlpListResultWork();

                //    #region paymentSlpListResultWork�ɒl���Z�b�g
                //    paymentSlpListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                //    paymentSlpListResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                //    paymentSlpListResultWork.PaymentMoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDCODERF"));
                //    paymentSlpListResultWork.PaymentMoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDNAMERF"));
                //    paymentSlpListResultWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                //    paymentSlpListResultWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                //    paymentSlpListResultWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                //    paymentSlpListResultWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                //    paymentSlpListResultWork.RebatePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REBATEPAYMENTRF"));
                //    #endregion

                //    al.Add(paymentSlpListResultWork);

                //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //}
                # endregion
                //--- UPD 2008/07/07 D.Tanaka ---<<<
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchDepsitOnlyAction Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
         */
        #endregion
        // 2008/07/07 DEL-End ---------------------------------------------------- <<<<<

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_paymentSlpCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, PaymentSlpCndtnWork _paymentSlpCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "SLP.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_paymentSlpCndtnWork.EnterpriseCode );

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND SLP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND SLP.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //�x���v�㋒�_�R�[�h
            if (_paymentSlpCndtnWork.IsOptSection == false)
            {
                if (_paymentSlpCndtnWork.PaymentAddupSecCodeList != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _paymentSlpCndtnWork.PaymentAddupSecCodeList)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }

                    if (sectionCodestr != "")
                    {
                        retstring += " AND SLP.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                    }
                }
            }

            //�v��������ݒ�
            if (_paymentSlpCndtnWork.St_AddUpADate != DateTime.MinValue)
            {
                int startymd = TDateTime.DateTimeToLongDate(_paymentSlpCndtnWork.St_AddUpADate);
                retstring += " AND SLP.ADDUPADATERF >= " + startymd.ToString();
            }
            if (_paymentSlpCndtnWork.Ed_AddUpADate != DateTime.MinValue)
            {
                if (_paymentSlpCndtnWork.St_AddUpADate == DateTime.MinValue)
                {
                    retstring += " AND (SLP.ADDUPADATERF IS NULL OR";
                }
                else
                {
                    retstring += " AND";
                }

                int endymd = TDateTime.DateTimeToLongDate(_paymentSlpCndtnWork.Ed_AddUpADate);
                retstring += " SLP.ADDUPADATERF <= " + endymd.ToString();

                if (_paymentSlpCndtnWork.St_AddUpADate == DateTime.MinValue)
                {
                    retstring += " ) ";
                }
            }

            //���͓������ݒ�
            if (_paymentSlpCndtnWork.St_InputDate != DateTime.MinValue)
            {
                int startymd = TDateTime.DateTimeToLongDate(_paymentSlpCndtnWork.St_InputDate);
                //retstring += " AND SLP.PAYMENTDATERF >= " + startymd.ToString();
                retstring += " AND SLP.INPUTDAYRF >= " + startymd.ToString();  // ADD 2009/03/26
            }
            if (_paymentSlpCndtnWork.Ed_InputDate != DateTime.MinValue)
            {
                if (_paymentSlpCndtnWork.St_InputDate == DateTime.MinValue)
                {
                    //retstring += " AND (SLP.PAYMENTDATERF IS NULL OR";
                    retstring += " AND (SLP.INPUTDAYRF IS NULL OR";  // ADD 2009/03/26
                }
                else
                {
                    retstring += " AND";
                }

                int endymd = TDateTime.DateTimeToLongDate(_paymentSlpCndtnWork.Ed_InputDate);
                //retstring += " SLP.PAYMENTDATERF <= " + endymd.ToString();
                retstring += " SLP.INPUTDAYRF <= " + endymd.ToString();  // ADD 2009/03/26

                if (_paymentSlpCndtnWork.St_InputDate == DateTime.MinValue)
                {
                    retstring += " ) ";
                }
            }

            //�x����R�[�h�ݒ�
            if (_paymentSlpCndtnWork.St_PayeeCode != 0)
            {
                retstring += " AND SLP.SUPPLIERCDRF>=@STPAYEECODE";
                SqlParameter paraStPayeeCode = sqlCommand.Parameters.Add("@STPAYEECODE", SqlDbType.Int);
                paraStPayeeCode.Value = SqlDataMediator.SqlSetInt32(_paymentSlpCndtnWork.St_PayeeCode);
            }
            if (_paymentSlpCndtnWork.Ed_PayeeCode != 0)
            {
                retstring += " AND SLP.SUPPLIERCDRF<=@EDPAYEECODE";
                SqlParameter paraEdPayeeCode = sqlCommand.Parameters.Add("@EDPAYEECODE", SqlDbType.Int);
                paraEdPayeeCode.Value = SqlDataMediator.SqlSetInt32(_paymentSlpCndtnWork.Ed_PayeeCode);
            }

            //�J�i�ݒ�
            if (_paymentSlpCndtnWork.St_PayeeKana != "")
            {
                retstring += " AND SPPL.SUPPLIERKANARF>=@STKANA";
                SqlParameter paraStPayeeKana = sqlCommand.Parameters.Add("@STKANA", SqlDbType.NVarChar);
                paraStPayeeKana.Value = SqlDataMediator.SqlSetString(_paymentSlpCndtnWork.St_PayeeKana);
            }
            if (_paymentSlpCndtnWork.Ed_PayeeKana != "")
            {
                retstring += " AND (SPPL.SUPPLIERKANARF<=@EDKANA OR SPPL.SUPPLIERKANARF LIKE @EDKANA)";
                SqlParameter paraEdPayeeKana = sqlCommand.Parameters.Add("@EDKANA", SqlDbType.NVarChar);
                paraEdPayeeKana.Value = SqlDataMediator.SqlSetString(_paymentSlpCndtnWork.Ed_PayeeKana + "% ");
            }

            //�S���ҋ敪�ɂ��`�F�b�N���s���S���ҍ��ڂ�ύX���܂�
            switch (_paymentSlpCndtnWork.EmployeeKindDiv)
            {
                case 0: //�x���S��
                    {
                        if (_paymentSlpCndtnWork.St_EmployeeCode != "")
                        {
                            retstring += " AND SLP.PAYMENTAGENTCODERF>=@STEMPLOYEECODE";
                            SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STEMPLOYEECODE", SqlDbType.NVarChar);
                            paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(_paymentSlpCndtnWork.St_EmployeeCode);
                        }
                        if (_paymentSlpCndtnWork.Ed_EmployeeCode != "")
                        {
                            retstring += " AND SLP.PAYMENTAGENTCODERF<=@EDEMPLOYEECODE";
                            SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDEMPLOYEECODE", SqlDbType.NVarChar);
                            paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(_paymentSlpCndtnWork.Ed_EmployeeCode);
                        }
                        break;
                    }
                case 1: //���͒S��
                    {
                        if (_paymentSlpCndtnWork.St_EmployeeCode != "")
                        {
                            retstring += " AND SLP.PAYMENTINPUTAGENTCDRF>=@STEMPLOYEECODE";
                            SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STEMPLOYEECODE", SqlDbType.NVarChar);
                            paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(_paymentSlpCndtnWork.St_EmployeeCode);
                        }
                        if (_paymentSlpCndtnWork.Ed_EmployeeCode != "")
                        {
                            retstring += " AND SLP.PAYMENTINPUTAGENTCDRF<=@EDEMPLOYEECODE";
                            SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDEMPLOYEECODE", SqlDbType.NVarChar);
                            paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(_paymentSlpCndtnWork.Ed_EmployeeCode);
                        }
                        break;
                    }
            }

            //�x���`�[�ԍ��ݒ�
            if (_paymentSlpCndtnWork.St_PaymentSlipNo != 0)
            {
                retstring += " AND SLP.PAYMENTSLIPNORF>=@STPAYMENTSLIPNO";
                SqlParameter paraStPaymentSlipNo = sqlCommand.Parameters.Add("@STPAYMENTSLIPNO", SqlDbType.Int);
                paraStPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(_paymentSlpCndtnWork.St_PaymentSlipNo);
            }
            if (_paymentSlpCndtnWork.Ed_PaymentSlipNo != 0)
            {
                retstring += " AND SLP.PAYMENTSLIPNORF<=@EDPAYMENTSLIPNO";
                SqlParameter paraEdPaymentSlipNo = sqlCommand.Parameters.Add("@EDPAYMENTSLIPNO", SqlDbType.Int);
                paraEdPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(_paymentSlpCndtnWork.Ed_PaymentSlipNo);
            }

            //�x������ݒ�
            if (_paymentSlpCndtnWork.PaymentKind != null)
            {
                ArrayList paymentKindArray = new ArrayList(_paymentSlpCndtnWork.PaymentKind);
                if ((paymentKindArray != null) && (paymentKindArray.Count > 0))
                {
                    string paymentKindint = "";
                    int kindint;
                    for (int i = 0; i < paymentKindArray.Count; i++)
                    {
                        kindint = Convert.ToInt32(paymentKindArray[i]);
                        if (kindint != -1)
                        {
                            if (paymentKindint != "")
                            {
                                paymentKindint += ",";
                            }
                            paymentKindint += "'" + kindint + "'";
                        }
                    }

                    if (paymentKindint != "")
                    {
                        //retstring += " AND SLP.PAYMENTMONEYKINDCODERF IN (" + paymentKindint + ") ";    2008/07/07 DEL
                        retstring += " AND DTL.MONEYKINDCODERF IN (" + paymentKindint + ") ";           //2008/07/07 ADD
                    }
                }
            }
            #endregion

            #region �\�[�g���쐬
            // 2008/07/07 DEL-Start ��UI���Ń\�[�g����-------------------------------- >>>>>
            /*
            switch (_paymentSlpCndtnWork.PrintDiv)
            {
                case 1: //�����v
                    {
                        if (_paymentSlpCndtnWork.IsOptSection == false)
                        {
                            //retstring += " GROUP BY SLP.ADDUPSECCODERF, SECI2.SECTIONGUIDENMRF, SLP.PAYMENTMONEYKINDCODERF, SLP.PAYMENTMONEYKINDNAMERF ";   2008/07/07 DEL
                            retstring += " GROUP BY SLP.ADDUPSECCODERF, SECI2.SECTIONGUIDESNMRF, DTL.MONEYKINDCODERF, DTL.MONEYKINDNAMERF ";               // 2008/07/07 ADD
                        }
                        else
                        {
                            //retstring += " GROUP BY SLP.PAYMENTMONEYKINDCODERF, SLP.PAYMENTMONEYKINDNAMERF ";  2008/07/07 DEL
                            retstring += " GROUP BY DTL.MONEYKINDCODERF, DTL.MONEYKINDNAMERF ";                //2008/07/07 ADD
                        }
                        break;
                    }
                case 2: //�Ȉ�
                //case 3: //�ڍ�    2008/07/07 DEL
                    {
                        retstring += " ORDER BY ";
                        if (_paymentSlpCndtnWork.IsOptSection == false)
                        {
                            retstring += "SLP.ADDUPSECCODERF, ";      // �v�㋒�_
                        }
                        retstring += "SLP.ADDUPADATERF, ";

                        switch (_paymentSlpCndtnWork.SortOrderDiv)
                        {
                            case 0: //�x����R�[�h��
                                {
                                    retstring += "SLP.SUPPLIERCDRF ";
                                    break;
                                }
                            case 1: //�x����J�i��
                                {
                                    retstring += "SPPL.SUPPLIERKANARF ";
                                    break;
                                }
                            case 2: //�x���S���R�[�h��
                                {
                                    retstring += "SLP.PAYMENTAGENTCODERF ";
                                    break;
                                }
                        }
                        break;
                    }
                //case 4: //����ʏW�v  2008/07/07 DEL
                case 3: //����ʏW�v    2008/07/07 ADD
                    {
                        retstring += " GROUP BY ";

                        if (_paymentSlpCndtnWork.IsOptSection == false)
                        {
                            retstring += "SLP.ADDUPSECCODERF, SECI2.SECTIONGUIDESNMRF, ";   //2008/07/07 ADD
                            //retstring += "SLP.ADDUPSECCODERF, SECI2.SECTIONGUIDENMRF, ";    2008/07/07 DEL
                        }
                        retstring += "SLP.SUPPLIERCDRF, SLP.SUPPLIERSNMRF, DTL.MONEYKINDCODERF, DTL.MONEYKINDNAMERF ";  //2008/07/07 ADD
                        //retstring += "SLP.ADDUPADATERF, SLP.PAYMENTMONEYKINDDIVRF ";                                    2008/07/07 DEL
                        break;
                    }
            }
             */
            // 2008/07/07 DEL-End ---------------------------------------------------- <<<<<
            #endregion
            return retstring;
        }
    }
}
