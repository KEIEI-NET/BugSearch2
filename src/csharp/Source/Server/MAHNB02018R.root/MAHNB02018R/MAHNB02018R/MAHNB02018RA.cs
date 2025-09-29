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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����m�F�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����m�F�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22035 �O�� �O��</br>
    /// <br>Date       : 2007.03.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>           :   2007.11.15  DC.NS �p�ɉ���  ���쏹��</br>
    /// <br></br>
    /// <br>Update Note: �o�l.�m�p�ɕύX </br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.07.01</br>
    /// <br></br>
    /// <br>Update Note: �s��C�� </br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.21</br>
    /// <br></br>
    /// <br>Update Note: �s��C��(�l���E�萔���݂̂̃f�[�^�����o�ΏۂɏC�� MANTIS ID:12645) </br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2009.04.20</br>
    /// <br></br>
    /// <br>Update Note: ���x�`���[�j���O</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/06/02</br>
    /// </remarks>
    [Serializable]
    public class DepsitListWorkDB : RemoteDB, IDepsitListWorkDB
    {
        /// <summary>
        /// �����m�F�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        public DepsitListWorkDB()
            :
        base("MAHNB02016D", "Broadleaf.Application.Remoting.ParamData.DepsitMainListResultWork", "DEPSITMAINRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region �����̂ݎ擾����
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓����m�F�\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="depsitMainListResultWork">�������ʁi�����j</param>
        /// <param name="depsitMainListParamWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����m�F�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.06</br>
        public int SearchDepsitOnly(out object depsitMainListResultWork, object depsitMainListParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            depsitMainListResultWork = null;

            DepsitMainListParamWork _depsitMainListParamWork = depsitMainListParamWork as DepsitMainListParamWork;

            try
            {
                status = SearchDepsitOnlyProc(out depsitMainListResultWork, _depsitMainListParamWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchDepsitOnly Exception=" + ex.Message);
                depsitMainListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓����m�F�\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="depsitMainListResultWork">�������ʁi�����j</param>
        /// <param name="depsitMainListParamWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����m�F�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.06</br>
        private int SearchDepsitOnlyProc(out object depsitMainListResultWork, DepsitMainListParamWork depsitMainListParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //@SqlEncryptInfo sqlEncryptInfo = null;

            depsitMainListResultWork = null;

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

                //@//���Í������i��������
                //@sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF"});
                //@//�Í����L�[OPEN�iSQLException�̉\���L��j
                //@sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //�����f�[�^�擾���s��
                status = SearchDepsitMainAction(ref al, ref sqlConnection, depsitMainListParamWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchDepositOnlyProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    //@//�Í����L�[�N���[�Y
                    //@if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            depsitMainListResultWork = al;

            return status;
        }
        #endregion

        #region ����,�����擾���� [DC.NS�ł̓T�|�[�g���Ă��܂���]
        /*
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓����m�F�\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="depsitMainListResultWork">�������ʁi�����j</param>
        /// <param name="depsitAlwcListResultWork">�������ʁi�����j</param>
        /// <param name="depsitMainListParamWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����m�F�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.06</br>
        public int SearchDepsitAndAllowance(out object depsitMainListResultWork, out object depsitAlwcListResultWork, object depsitMainListParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            depsitMainListResultWork = null;
            depsitAlwcListResultWork = null;

            DepsitMainListParamWork depsitMainListParamWork = depsitMainListParamWork as DepsitMainListParamWork;

            try
            {
                status = SearchDepsitAndAllowanceProc(out depsitMainListResultWork, out depsitAlwcListResultWork, depsitMainListParamWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchDepsitAndAllowance Exception=" + ex.Message);
                depsitMainListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓����m�F�\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="depsitMainListResultWork">�������ʁi�����j</param>
        /// <param name="depsitAlwcListResultWork">�������ʁi�����j</param>
        /// <param name="depsitMainListParamWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����m�F�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.06</br>
        private int SearchDepsitAndAllowanceProc(out object depsitMainListResultWork, out object depsitAlwcListResultWork, DepsitMainListParamWork depsitMainListParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int st1 = status;
            int st2 = status;
            SqlConnection sqlConnection = null;
            SqlEncryptInfo sqlEncryptInfo = null;

            depsitMainListResultWork = null;
            depsitAlwcListResultWork = null;

            ArrayList al = new ArrayList();   //���o����
            ArrayList al2 = new ArrayList();  //���o����

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //���Í������i��������
                sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //�Í����L�[OPEN�iSQLException�̉\���L��j
                sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //�����f�[�^�擾���s��
                st1 = SearchDepsitMainAction(ref al, ref sqlConnection, depsitMainListParamWork, logicalMode);
                //�����f�[�^�擾���s��
                st2 = SearchDepositAlwAction(ref al2, ref sqlConnection, depsitMainListParamWork, logicalMode);

                status = st1;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchDepsitAndAllowanceProc Exception=" + ex.Message);
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

            depsitMainListResultWork = al;
            depsitAlwcListResultWork = al2;

            return status;
        }
        */
        #endregion

        #region �����v�擾����
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓����m�F�\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="depsitMainListResultWork">�������ʁi�����j</param>
        /// <param name="depsitMainListParamWork">�����p�����[�^</param>
        /// <param name="sectionDepositDiv">0:����̂݁A1:���큕���_�R�[�h</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����m�F�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.06</br>
        public int SearchAllTotal(out object depsitMainListResultWork, object depsitMainListParamWork, int sectionDepositDiv, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            depsitMainListResultWork = null;

            DepsitMainListParamWork _depsitMainListParamWork = depsitMainListParamWork as DepsitMainListParamWork;

            try
            {
                status = SearchAllTotalProc(out depsitMainListResultWork, _depsitMainListParamWork, sectionDepositDiv, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchAllTotal Exception=" + ex.Message);
                depsitMainListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓����m�F�\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="depsitMainListResultWork">�������ʁi�����j</param>
        /// <param name="depsitMainListParamWork">�����p�����[�^</param>
        /// <param name="sectionDepositDiv">0:����̂݁A1:���큕���_�R�[�h</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����m�F�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.06</br>
        private int SearchAllTotalProc(out object depsitMainListResultWork, DepsitMainListParamWork depsitMainListParamWork, int sectionDepositDiv, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //@SqlEncryptInfo sqlEncryptInfo = null;

            depsitMainListResultWork = null;

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

                //@//���Í������i��������
                //@sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //@//�Í����L�[OPEN�iSQLException�̉\���L��j
                //@sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //�����v�擾���s��
                status = SearchAllTotalAction(ref al, ref sqlConnection, depsitMainListParamWork, sectionDepositDiv, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchAllTotalProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    //@//�Í����L�[�N���[�Y
                    //@if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            depsitMainListResultWork = al;

            return status;
        }
        #endregion

        #region �����f�[�^�擾�����i���s���j
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="depsitMainListParamWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchDepsitMainAction(ref ArrayList al, ref SqlConnection sqlConnection, DepsitMainListParamWork depsitMainListParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            //int OutPutDiv = 0;�@//�\�[�g����K�p����ׂ̋敪

            try
            {
                string selectTxt = string.Empty;

                #region Select���쐬
                selectTxt += "SELECT DISTINCT" + Environment.NewLine;
                //selectTxt += "     DEPSIT2.CREATEDATETIMERF " + Environment.NewLine; // ADD 2009.02.18
                selectTxt += "     DEPSIT2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DEPOSITDEBITNOTECDRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DEPOSITSLIPNORF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.INPUTDEPOSITSECCDRF" + Environment.NewLine;
                selectTxt += "    ,SEC.SECTIONGUIDENMRF INPUTDEPOSITSECNMRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "    ,SEC1.SECTIONGUIDENMRF ADDUPSECNAMERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.INPUTDAYRF " + Environment.NewLine; // ADD 2009/03/26
                selectTxt += "    ,DEPSIT2.DEPOSITDATERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.ADDUPADATERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DEPOSITTOTALRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DEPOSITRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.FEEDEPOSITRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DISCOUNTDEPOSITRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.AUTODEPOSITCDRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DRAFTDRAWINGDATERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DRAFTKINDRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DRAFTKINDNAMERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DRAFTDIVIDERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DRAFTDIVIDENAMERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DRAFTNORF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DEPOSITAGENTCODERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DEPOSITAGENTNMRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DEPOSITINPUTAGENTCDRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DEPOSITINPUTAGENTNMRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.CLAIMSNMRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.OUTLINERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.BANKCODERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.BANKNAMERF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD1.DEPOSITROWNORF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD1.MONEYKINDCODERF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD1.MONEYKINDNAMERF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD1.MONEYKINDDIVRF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD1.DEPOSITRF DEPOSITDTLRF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD1.VALIDITYTERMRF" + Environment.NewLine;
                selectTxt += "    ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                selectTxt += "    ,EMPLOY.NAMERF" + Environment.NewLine;
                selectTxt += " FROM" + Environment.NewLine;
                selectTxt += "(" + Environment.NewLine;
                selectTxt += " SELECT" + Environment.NewLine;
                selectTxt += "     DEPSIT.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT.ACPTANODRSTATUSRF" + Environment.NewLine;   // ADD 2010/06/02
                selectTxt += "    ,DEPSIT.DEPOSITSLIPNORF" + Environment.NewLine;
                selectTxt += " FROM DEPSITMAINRF DEPSIT " + Environment.NewLine;
                // �C�� 2009/04/20 �������ׂ����݂��Ȃ��Ă����o�Ώۂɂ���(�l���E�萔���݂̂̏ꍇ�A�������ׂ��ł��Ȃ�����) >>>
                //selectTxt += " INNER JOIN DEPSITDTLRF DEPSITD ON DEPSITD.ENTERPRISECODERF=DEPSIT.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " LEFT JOIN DEPSITDTLRF DEPSITD ON DEPSITD.ENTERPRISECODERF=DEPSIT.ENTERPRISECODERF" + Environment.NewLine;
                // �C�� 2009/04/20 <<<
                selectTxt += " AND DEPSITD.ACPTANODRSTATUSRF=DEPSIT.ACPTANODRSTATUSRF" + Environment.NewLine;  // ADD 2010/06/02
                selectTxt += " AND DEPSITD.DEPOSITSLIPNORF=DEPSIT.DEPOSITSLIPNORF" + Environment.NewLine;

                #region WHERE��
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += " DEPSIT.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    selectTxt += " AND DEPSIT.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    selectTxt += " AND DEPSIT.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                }
                //���_�R�[�h    ���z��ŕ����w�肳���
                if (depsitMainListParamWork.DepositAddupSecCodeList != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in depsitMainListParamWork.DepositAddupSecCodeList)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }

                    if (sectionCodestr != "")
                    {
                        selectTxt += " AND DEPSIT.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                    }
                }
                //�����v��������ݒ�
                if (depsitMainListParamWork.St_AddUpADate != 0)
                {
                    selectTxt += " AND DEPSIT.ADDUPADATERF >= " + depsitMainListParamWork.St_AddUpADate.ToString();
                }
                if (depsitMainListParamWork.Ed_AddUpADate != 0)
                {
                    if (depsitMainListParamWork.St_AddUpADate == 0)
                    {
                        selectTxt += " AND (DEPSIT.ADDUPADATERF IS NULL OR";
                    }
                    else
                    {
                        selectTxt += " AND";
                    }
                    selectTxt += " DEPSIT.ADDUPADATERF <= " + depsitMainListParamWork.Ed_AddUpADate.ToString();
                    if (depsitMainListParamWork.St_AddUpADate == 0)
                    {
                        selectTxt += " ) ";
                    }
                }

                //�������͓������ݒ�
                if (depsitMainListParamWork.St_CreateDate != 0)
                {
                    //selectTxt += " AND DEPSIT.DEPOSITDATERF >= " + depsitMainListParamWork.St_CreateDate.ToString();
                    selectTxt += " AND DEPSIT.INPUTDAYRF >= " + depsitMainListParamWork.St_CreateDate.ToString(); // ADD 2009/03/26
                }
                if (depsitMainListParamWork.Ed_CreateDate != 0)
                {
                    if (depsitMainListParamWork.St_CreateDate == 0)
                    {
                        //selectTxt += " AND (DEPSIT.DEPOSITDATERF IS NULL OR";
                        selectTxt += " AND (DEPSIT.INPUTDAYRF IS NULL OR";  //ADD 2009/03/26
                    }
                    else
                    {
                        selectTxt += " AND";
                    }
                    //selectTxt += " DEPSIT.DEPOSITDATERF <= " + depsitMainListParamWork.Ed_CreateDate.ToString();
                    selectTxt += " DEPSIT.INPUTDAYRF <= " + depsitMainListParamWork.Ed_CreateDate.ToString(); // ADD 2009/03/26
                    if (depsitMainListParamWork.St_CreateDate == 0)
                    {
                        selectTxt += " ) ";
                    }
                }

                //���Ӑ�R�[�h�ݒ�
                if (depsitMainListParamWork.St_CustomerCode != 0)
                {
                    selectTxt += " AND DEPSIT.CUSTOMERCODERF>=@STCUSTOMERCODE ";
                }
                if (depsitMainListParamWork.Ed_CustomerCode != 0)
                {
                    selectTxt += " AND DEPSIT.CUSTOMERCODERF<=@EDCUSTOMERCODE ";
                }

                //�J�i�ݒ�
                if (depsitMainListParamWork.St_CustomerKana != "")
                {
                    selectTxt += " AND CUST.KANARF>=@STKANA ";
                }
                if (depsitMainListParamWork.Ed_CustomerKana != "")
                {
                    selectTxt += " AND (CUST.KANARF<=@EDKANA OR CUST.KANARF LIKE @EDKANA) ";
                }

                //�S���ҋ敪
                switch (depsitMainListParamWork.EmployeeKind)
                {
                    case 0:
                        {
                            //���Ӑ�S���Ґݒ�
                            if (depsitMainListParamWork.St_EmployeeCd != "")
                            {
                                selectTxt += " AND CUST.CUSTOMERAGENTCDRF>=@STCUSTOMERAGENTCD ";
                            }
                            if (depsitMainListParamWork.Ed_EmployeeCd != "")
                            {
                                if (depsitMainListParamWork.St_EmployeeCd == "")
                                {
                                    selectTxt += " AND (CUST.CUSTOMERAGENTCDRF IS NULL OR";
                                }
                                else
                                {
                                    selectTxt += " AND (";
                                }

                                selectTxt += " CUST.CUSTOMERAGENTCDRF<=@EDCUSTOMERAGENTCD OR CUST.CUSTOMERAGENTCDRF LIKE @EDCUSTOMERAGENTCD) ";
                            }
                            break;
                        }
                    case 1:
                        {
                            //�W���S���Ґݒ�
                            if (depsitMainListParamWork.St_EmployeeCd != "")
                            {
                                selectTxt += " AND CUST.BILLCOLLECTERCDRF>=@STDEPOSITAGENTCODE ";
                            }
                            if (depsitMainListParamWork.Ed_EmployeeCd != "")
                            {
                                if (depsitMainListParamWork.St_EmployeeCd == "")
                                {
                                    selectTxt += " AND (CUST.BILLCOLLECTERCDRF IS NULL OR";
                                }
                                else
                                {
                                    selectTxt += " AND (";
                                }

                                selectTxt += " CUST.BILLCOLLECTERCDRF<=@EDDEPOSITAGENTCODE OR CUST.BILLCOLLECTERCDRF LIKE @EDDEPOSITAGENTCODE) ";
                            }
                            break;
                        }
                    case 2:
                        {
                            //�����S���Ґݒ�
                            if (depsitMainListParamWork.St_EmployeeCd != "")
                            {
                                selectTxt += " AND DEPSIT.DEPOSITAGENTCODERF>=@STDEPOSITAGENTCODE ";
                            }
                            if (depsitMainListParamWork.Ed_EmployeeCd != "")
                            {
                                if (depsitMainListParamWork.St_EmployeeCd == "")
                                {
                                    selectTxt += " AND (DEPSIT.DEPOSITAGENTCODERF IS NULL OR";
                                }
                                else
                                {
                                    selectTxt += " AND (";
                                }

                                selectTxt += " DEPSIT.DEPOSITAGENTCODERF<=@EDDEPOSITAGENTCODE OR DEPSIT.DEPOSITAGENTCODERF LIKE @EDDEPOSITAGENTCODE) ";
                            }
                            break;
                        }
                    case 3:
                        {
                            //�������͎Ґݒ�
                            if (depsitMainListParamWork.St_EmployeeCd != "")
                            {
                                selectTxt += " AND DEPSIT.DEPOSITINPUTAGENTCDRF>=@STDEPOSITINPUTAGENTCD ";
                            }
                            if (depsitMainListParamWork.Ed_EmployeeCd != "")
                            {
                                if (depsitMainListParamWork.St_EmployeeCd == "")
                                {
                                    selectTxt += " AND (DEPSIT.DEPOSITINPUTAGENTCDRF IS NULL OR";
                                }
                                else
                                {
                                    selectTxt += " AND (";
                                }

                                selectTxt += " DEPSIT.DEPOSITINPUTAGENTCDRF<=@EDDEPOSITINPUTAGENTCD OR DEPSIT.DEPOSITINPUTAGENTCDRF LIKE @EDDEPOSITINPUTAGENTCD) ";
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                //�����`�[�ԍ��ݒ�
                if (depsitMainListParamWork.St_DepositSlipNo != 0)
                {
                    selectTxt += " AND DEPSIT.DEPOSITSLIPNORF>=@STDEPOSITSLIPNO ";
                }
                if (depsitMainListParamWork.Ed_DepositSlipNo != 0)
                {
                    selectTxt += " AND DEPSIT.DEPOSITSLIPNORF<=@EDDEPOSITSLIPNO ";
                }

                //��������ݒ�
                if (depsitMainListParamWork.DepositCdKind != null)
                {
                    if (depsitMainListParamWork.DepositCdKind.Count > 0)
                    {
                        if (Convert.ToInt32(depsitMainListParamWork.DepositCdKind[0]) > -1)
                        {
                            ArrayList DepositKindArray = new ArrayList(depsitMainListParamWork.DepositCdKind);
                            if ((DepositKindArray != null) && (DepositKindArray.Count > 0))
                            {
                                string depositKindint = "";
                                int kindint;
                                for (int i = 0; i < DepositKindArray.Count; i++)
                                {
                                    kindint = Convert.ToInt32(DepositKindArray[i]);
                                    if (kindint != -1)
                                    {
                                        if (depositKindint != "")
                                        {
                                            depositKindint += ",";
                                        }
                                        depositKindint += "'" + kindint + "'";
                                    }
                                }

                                if (depositKindint != "")
                                {
                                    selectTxt += " AND DEPSITD.MONEYKINDCODERF IN (" + depositKindint + ") ";
                                }
                            }
                        }
                    }
                }

                ////�a����敪
                //if (depsitMainListParamWork.DepositCd != -1)
                //{
                //    switch (depsitMainListParamWork.DepositCd)
                //    {
                //        case 0:     // �S��
                //            break;
                //        case 1:     // �ʏ�
                //            selectTxt += " AND DEPSIT.DEPOSITCDRF=0 AND DEPSIT.AUTODEPOSITCDRF=0 ";
                //            break;
                //        case 2:     // �a���
                //            selectTxt += " AND DEPSIT.DEPOSITCDRF=1 ";
                //            break;
                //        case 3:     // ����
                //            selectTxt += " AND DEPSIT.AUTODEPOSITCDRF=1 ";
                //            break;
                //        default:
                //            break;
                //    }
                //}

                // �����敪(0:�S�� 1:�ʏ�����̂� 2:���������̂�)
                switch (depsitMainListParamWork.DepositDiv)
                {
                    case 1:
                        {
                            selectTxt += " AND DEPSIT.AUTODEPOSITCDRF = 0 ";
                            break;
                        }
                    case 2:
                        {
                            selectTxt += " AND DEPSIT.AUTODEPOSITCDRF = 1 ";
                            break;
                        }
                }

                // --- ADD 2008.10.10 ---------->>>>>
                //�����敪AllowanceDiv
                if (depsitMainListParamWork.AllowanceDiv != 0)
                {
                    switch (depsitMainListParamWork.AllowanceDiv)
                    {
                        case 1:  //�����ς�  ���������z[DepositAllowanceRF]�����������c��[DepositAlwcBlnceRF]�̎��A���A0�ȊO
                            //          ���������z[DepositAllowanceRF]��0�ȊO�A���A���������c��[DepositAlwcBlnceRF]=0
                            selectTxt += " AND (DEPSIT.DEPOSITALLOWANCERF!=0 AND DEPSIT.DEPOSITALWCBLNCERF=0) ";
                            break;
                        case 2:  //�ꕔ����  ���������z[DepositAllowanceRF]��0 ���A���������c��[DepositAlwcBlnceRF]��0�̎�
                            selectTxt += " AND (DEPSIT.DEPOSITALLOWANCERF<>0 AND DEPSIT.DEPOSITALWCBLNCERF<>0) ";
                            break;
                        case 3:  //������  ���������z[DepositAllowanceRF]=0�A���A���������c��[DepositAlwcBlnceRF]��0�ȊO
                            selectTxt += " AND (DEPSIT.DEPOSITALLOWANCERF=0 AND DEPSIT.DEPOSITALWCBLNCERF<>0) ";
                            break;
                        default:
                            break;
                    }
                }
                // --- ADD 2008.10.10 ----------<<<<<
                #endregion

                selectTxt += ") AS DEPSIT1" + Environment.NewLine;
                selectTxt += " INNER JOIN DEPSITMAINRF DEPSIT2 ON DEPSIT2.ENTERPRISECODERF=DEPSIT1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND DEPSIT2.ACPTANODRSTATUSRF=DEPSIT1.ACPTANODRSTATUSRF" + Environment.NewLine;  // ADD 2010/06/02
                selectTxt += " AND DEPSIT2.DEPOSITSLIPNORF=DEPSIT1.DEPOSITSLIPNORF" + Environment.NewLine;
                // �C�� 2009/04/20 >>>
                //selectTxt += " INNER JOIN DEPSITDTLRF DEPSITD1 ON DEPSITD1.ENTERPRISECODERF=DEPSIT1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " LEFT JOIN DEPSITDTLRF DEPSITD1 ON DEPSITD1.ENTERPRISECODERF=DEPSIT1.ENTERPRISECODERF" + Environment.NewLine;
                // �C�� 2009/04/20 <<<
                selectTxt += " AND DEPSITD1.ACPTANODRSTATUSRF=DEPSIT1.ACPTANODRSTATUSRF" + Environment.NewLine;  // ADD 2010/06/02
                selectTxt += " AND DEPSITD1.DEPOSITSLIPNORF=DEPSIT1.DEPOSITSLIPNORF" + Environment.NewLine;
                selectTxt += " INNER JOIN SECINFOSETRF SEC ON SEC.ENTERPRISECODERF=DEPSIT1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SEC.SECTIONCODERF=DEPSIT2.INPUTDEPOSITSECCDRF" + Environment.NewLine;
                selectTxt += " INNER JOIN SECINFOSETRF SEC1 ON SEC1.ENTERPRISECODERF=DEPSIT1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SEC1.SECTIONCODERF=DEPSIT2.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += " INNER JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=DEPSIT1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUST.CUSTOMERCODERF=DEPSIT2.CUSTOMERCODERF" + Environment.NewLine;
                //selectTxt += " INNER JOIN EMPLOYEERF EMPLOY ON EMPLOY.ENTERPRISECODERF=DEPSIT1.ENTERPRISECODERF" + Environment.NewLine; // DEL 2008.11.21
                selectTxt += " LEFT JOIN EMPLOYEERF EMPLOY ON EMPLOY.ENTERPRISECODERF=DEPSIT1.ENTERPRISECODERF" + Environment.NewLine;  // ADD 2008.11.21
                selectTxt += " AND EMPLOY.EMPLOYEECODERF=CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Prameter�I�u�W�F�N�g�̍쐬/�l�ݒ�
                SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.EnterpriseCode);


                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                if (depsitMainListParamWork.St_CustomerCode != 0)
                {
                    SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                    paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(depsitMainListParamWork.St_CustomerCode);
                }
                if (depsitMainListParamWork.Ed_CustomerCode != 0)
                {
                    SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                    paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(depsitMainListParamWork.Ed_CustomerCode);
                }

                //�J�i�ݒ�
                if (depsitMainListParamWork.St_CustomerKana != "")
                {
                    SqlParameter paraStCustomerKana = sqlCommand.Parameters.Add("@STKANA", SqlDbType.NVarChar);
                    paraStCustomerKana.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_CustomerKana);
                }
                if (depsitMainListParamWork.Ed_CustomerKana != "")
                {
                    SqlParameter paraEdCustomerKana = sqlCommand.Parameters.Add("@EDKANA", SqlDbType.NVarChar);
                    paraEdCustomerKana.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_CustomerKana + "%");
                }

                //�S���ҋ敪
                switch (depsitMainListParamWork.EmployeeKind)
                {
                    case 0:
                        {
                            //���Ӑ�S���Ґݒ�
                            if (depsitMainListParamWork.St_EmployeeCd != "")
                            {
                                SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STCUSTOMERAGENTCD", SqlDbType.NChar);
                                paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_EmployeeCd);
                            }
                            if (depsitMainListParamWork.Ed_EmployeeCd != "")
                            {
                                SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDCUSTOMERAGENTCD", SqlDbType.NChar);
                                paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_EmployeeCd + "%");
                            }
                            break;
                        }
                    case 1:
                        {
                            //�W���S���Ґݒ�
                            if (depsitMainListParamWork.St_EmployeeCd != "")
                            {
                                SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STDEPOSITAGENTCODE", SqlDbType.NChar);
                                paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_EmployeeCd);
                            }
                            if (depsitMainListParamWork.Ed_EmployeeCd != "")
                            {
                                SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDDEPOSITAGENTCODE", SqlDbType.NChar);
                                paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_EmployeeCd + "%");
                            }
                            break;
                        }
                    case 2:
                        {
                            //�����S���Ґݒ�
                            if (depsitMainListParamWork.St_EmployeeCd != "")
                            {
                                SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STDEPOSITAGENTCODE", SqlDbType.NChar);
                                paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_EmployeeCd);
                            }
                            if (depsitMainListParamWork.Ed_EmployeeCd != "")
                            {
                                SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDDEPOSITAGENTCODE", SqlDbType.NChar);
                                paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_EmployeeCd + "%");
                            }
                            break;
                        }
                    case 3:
                        {
                            //�������͎Ґݒ�
                            if (depsitMainListParamWork.St_EmployeeCd != "")
                            {
                                SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STDEPOSITINPUTAGENTCD", SqlDbType.NChar);
                                paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_EmployeeCd);
                            }
                            if (depsitMainListParamWork.Ed_EmployeeCd != "")
                            {
                                SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDDEPOSITINPUTAGENTCD", SqlDbType.NChar);
                                paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_EmployeeCd + "%");
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                if (depsitMainListParamWork.St_DepositSlipNo != 0)
                {
                    SqlParameter paraStDepositSlipNo = sqlCommand.Parameters.Add("@STDEPOSITSLIPNO", SqlDbType.Int);
                    paraStDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainListParamWork.St_DepositSlipNo);
                }
                if (depsitMainListParamWork.Ed_DepositSlipNo != 0)
                {
                    SqlParameter paraEdDepositSlipNo = sqlCommand.Parameters.Add("@EDDEPOSITSLIPNO", SqlDbType.Int);
                    paraEdDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainListParamWork.Ed_DepositSlipNo);
                }
                #endregion

                ////WHERE���̍쐬
                //sqlCommand.CommandText += MakeWhereString(ref sqlCommand, depsitMainListParamWork, OutPutDiv, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    DepsitMainListResultWork wkDepsitMainListResultWork = new DepsitMainListResultWork();
                    //wkDepsitMainListResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkDepsitMainListResultWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
                    wkDepsitMainListResultWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                    wkDepsitMainListResultWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                    wkDepsitMainListResultWork.InputDepositSecNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECNMRF"));
                    wkDepsitMainListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    wkDepsitMainListResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                    wkDepsitMainListResultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));  // ADD 2009/03/26
                    wkDepsitMainListResultWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
                    wkDepsitMainListResultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    wkDepsitMainListResultWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"));
                    wkDepsitMainListResultWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
                    wkDepsitMainListResultWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));
                    wkDepsitMainListResultWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
                    wkDepsitMainListResultWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                    wkDepsitMainListResultWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                    wkDepsitMainListResultWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                    wkDepsitMainListResultWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                    wkDepsitMainListResultWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                    wkDepsitMainListResultWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                    wkDepsitMainListResultWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                    wkDepsitMainListResultWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                    wkDepsitMainListResultWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                    wkDepsitMainListResultWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTCDRF"));
                    wkDepsitMainListResultWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));
                    wkDepsitMainListResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    wkDepsitMainListResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    wkDepsitMainListResultWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                    wkDepsitMainListResultWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                    wkDepsitMainListResultWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    wkDepsitMainListResultWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                    wkDepsitMainListResultWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                    wkDepsitMainListResultWork.DepositRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITROWNORF"));
                    wkDepsitMainListResultWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
                    wkDepsitMainListResultWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                    wkDepsitMainListResultWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
                    wkDepsitMainListResultWork.DepositDtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITDTLRF"));
                    wkDepsitMainListResultWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
                    wkDepsitMainListResultWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
                    wkDepsitMainListResultWork.CustomerAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                    #endregion

                    al.Add(wkDepsitMainListResultWork);

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
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchDepsitMainAction Exception=" + ex.Message);
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

        #region �����f�[�^�擾�����i���s���j[DC.NS�ł̓T�|�[�g���Ă��܂���]
        /*
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="depsitMainListParamWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchDepositAlwAction(ref ArrayList al, ref SqlConnection sqlConnection, DepsitMainListParamWork depsitMainListParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            int OutPutDiv = 1;

            try
            {
                // �Ώۃe�[�u��
                // DEPOSITMAINRF  DPM   �����}�X�^
                // CUSTOMERRF     CTM   ���Ӑ�}�X�^
                // DEPOSITALWRF   DPA   ���������}�X�^
                // SALESSLIPRF    SLS   ����f�[�^
                // SECINFOSETRF   SIS   ���_���ݒ�}�X�^
                // SECINFOSETRF   SIS2  ���_���ݒ�}�X�^
                // SECINFOSETRF   SIS3  ���_���ݒ�}�X�^

                string SelectDm = "";

                #region Select���쐬
                SelectDm += "SELECT";

                //�����}�X�^���ʎ擾
                SelectDm += " DPA.RECONCILEADDUPDATERF DPA_RECONCILEADDUPDATERF";
                SelectDm += ", DPA.ACCEPTANORDERNORF DPA_ACCEPTANORDERNORF";
                SelectDm += ", SLS.ACPTANODRSTATUSRF SLS_ACPTANODRSTATUSRF";
                SelectDm += ", SLS.SALESSLIPNUMRF SLS_SALESSLIPNUMRF";
                SelectDm += ", SLS.ACPTANODRSLIPNUMRF SLS_ACPTANODRSLIPNUMRF";
                SelectDm += ", SLS.ESTIMATESLIPNORF SLS_ESTIMATESLIPNORF";
                SelectDm += ", SLS.DEBITNOTEDIVRF SLS_DEBITNOTEDIVRF";
                SelectDm += ", SLS.DEBITNLNKACPTANODRRF SLS_DEBITNLNKACPTANODRRF";
                SelectDm += ", SLS.SALESSLIPCDRF SLS_SALESSLIPCDRF";
                SelectDm += ", SLS.SALESFORMALRF SLS_SALESFORMALRF";
                SelectDm += ", SLS.SALESINPSECCDRF SLS_SALESINPSECCDRF";
                SelectDm += ", SIS.SECTIONGUIDENMRF SIS_SALESINPSECNMRF";
                SelectDm += ", SLS.RESULTSADDUPSECCDRF SLS_RESULTSADDUPSECCDRF";
                SelectDm += ", SIS2.SECTIONGUIDENMRF SIS2_RESULTSADDUPSECNMRF";
                SelectDm += ", SLS.UPDATESECCDRF SLS_UPDATESECCDRF";
                SelectDm += ", SIS3.SECTIONGUIDENMRF SIS3_UPDATESECCDRF";
                SelectDm += ", SLS.ESTIMATEDATERF SLS_ESTIMATEDATERF";
                SelectDm += ", SLS.ACCEPTANORDERDATERF SLS_ACCEPTANORDERDATERF";
                SelectDm += ", SLS.SALESDATERF SLS_SALESDATERF";
                SelectDm += ", SLS.ADDUPADATERF SLS_SALESADDUPADATERF";
                SelectDm += ", SLS.ACCRECDIVCDRF SLS_ACCRECDIVCDRF";
                SelectDm += ", SLS.DEMANDABLETTLRF SLS_DEMANDABLETTLRF";
                SelectDm += ", SLS.DEPOSITALLOWANCETTLRF SLS_DEPOSITALLOWANCETTLRF";
                SelectDm += ", SLS.MNYDEPOALLOWANCETTLRF SLS_MNYDEPOALLOWANCETTLRF";
                SelectDm += ", SLS.DEPOSITALWCBLNCERF SLS_DEPOSITALWCBLNCERF";
                SelectDm += ", SLS.CLAIMCODERF SLS_CLAIMCODERF";
                SelectDm += ", SLS.CLAIMNAME1RF SLS_CLAIMNAME1RF";
                SelectDm += ", SLS.CLAIMNAME2RF SLS_CLAIMNAME2RF";
                SelectDm += ", SLS.CUSTOMERCODERF SLS_CUSTOMERCODERF";
                SelectDm += ", SLS.CUSTOMERNAMERF SLS_CUSTOMERNAMERF";
                SelectDm += ", SLS.CUSTOMERNAME2RF SLS_CUSTOMERNAME2RF";
                SelectDm += ", SLS.HONORIFICTITLERF SLS_HONORIFICTITLERF";
                SelectDm += ", SLS.KANARF SLS_KANARF";

                //2007.03.16 22035 �O�� add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
                //����f�[�^�ύX�ɔ����擾���ڒǉ�
                SelectDm += ", SLS.SEARCHSLIPNUMRF SLS_SEARCHSLIPNUMRF";
                SelectDm += ", SLS.SALESSLIPKINDRF SLS_SALESSLIPKINDRF";
                //2007.03.16 22035 �O�� add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<END

                SelectDm += ", DPA.ADDUPSECCODERF DPA_ADDUPSECCODERF";
                SelectDm += ", SIS4.SECTIONGUIDENMRF SIS4_SECTIONGUIDENMRF";
                SelectDm += ", DPA.DEPOSITSLIPNORF DPA_DEPOSITSLIPNORF";

                SelectDm += " FROM DEPSITMAINRF DPM";

                SelectDm += " LEFT JOIN CUSTOMERRF CTM ON CTM.ENTERPRISECODERF=DPM.ENTERPRISECODERF AND CTM.CUSTOMERCODERF=DPM.CUSTOMERCODERF";
                SelectDm += " LEFT JOIN DEPOSITALWRF DPA ON DPA.ENTERPRISECODERF=DPM.ENTERPRISECODERF AND DPA.DEPOSITSLIPNORF=DPM.DEPOSITSLIPNORF";
                SelectDm += " LEFT JOIN SALESSLIPRF SLS ON SLS.ENTERPRISECODERF=DPA.ENTERPRISECODERF AND SLS.ACCEPTANORDERNORF=DPA.ACCEPTANORDERNORF";
                SelectDm += " LEFT JOIN SECINFOSETRF SIS ON SIS.ENTERPRISECODERF=SLS.ENTERPRISECODERF AND SIS.SECTIONCODERF=SLS.SALESINPSECCDRF";
                SelectDm += " LEFT JOIN SECINFOSETRF SIS2 ON SIS2.ENTERPRISECODERF=SLS.ENTERPRISECODERF AND SIS2.SECTIONCODERF=SLS.DEMANDADDUPSECCDRF";
                SelectDm += " LEFT JOIN SECINFOSETRF SIS3 ON SIS3.ENTERPRISECODERF=SLS.ENTERPRISECODERF AND SIS3.SECTIONCODERF=SLS.RESULTSADDUPSECCDRF";
                SelectDm += " LEFT JOIN SECINFOSETRF SIS4 ON SIS4.ENTERPRISECODERF=DPA.ENTERPRISECODERF AND SIS4.SECTIONCODERF=DPA.ADDUPSECCODERF";
                #endregion

                sqlCommand = new SqlCommand(SelectDm, sqlConnection);

                //WHERE���̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, depsitMainListParamWork, OutPutDiv, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    DepsitAlwcListResultWork wkDepsitAlwcListResultWork = new DepsitAlwcListResultWork();

                    //�݌Ɏԗ����o�ɊǗ��}�X�^���ʎ擾���e�i�[
                    wkDepsitAlwcListResultWork.ReconcileAddUpDate  = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DPA_RECONCILEADDUPDATERF"));
                    wkDepsitAlwcListResultWork.AcceptAnOrderNo     = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DPA_ACCEPTANORDERNORF"));
                    wkDepsitAlwcListResultWork.AcptAnOdrStatus     = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_ACPTANODRSTATUSRF"));
                    wkDepsitAlwcListResultWork.SalesSlipNum        = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_SALESSLIPNUMRF"));
                    wkDepsitAlwcListResultWork.AcptAnOdrSlipNum    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_ACPTANODRSLIPNUMRF"));
                    wkDepsitAlwcListResultWork.EstimateSlipNo      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_ESTIMATESLIPNORF"));
                    wkDepsitAlwcListResultWork.DebitNoteDiv        = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_DEBITNOTEDIVRF"));
                    wkDepsitAlwcListResultWork.DebitNLnkAcptAnOdr  = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_DEBITNLNKACPTANODRRF"));
                    wkDepsitAlwcListResultWork.SalesSlipCd         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_SALESSLIPCDRF"));
                    wkDepsitAlwcListResultWork.SalesFormal         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_SALESFORMALRF"));
                    wkDepsitAlwcListResultWork.SalesInpSecCd       = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_SALESINPSECCDRF"));
                    wkDepsitAlwcListResultWork.SalesInpSecNm       = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SIS_SALESINPSECNMRF"));
                    wkDepsitAlwcListResultWork.ResultsAddUpSecCd   = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_RESULTSADDUPSECCDRF"));
                    wkDepsitAlwcListResultWork.ResultsAddUpSecNm   = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SIS2_RESULTSADDUPSECNMRF"));
                    wkDepsitAlwcListResultWork.UpdateSecCd         = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_UPDATESECCDRF"));
                    wkDepsitAlwcListResultWork.UpdateSecNm         = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SIS3_UPDATESECCDRF"));
                    wkDepsitAlwcListResultWork.EstimateDate        = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SLS_ESTIMATEDATERF"));
                    wkDepsitAlwcListResultWork.AcceptAnOrderDate   = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SLS_ACCEPTANORDERDATERF"));
                    wkDepsitAlwcListResultWork.SalesDate           = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SLS_SALESDATERF"));
                    wkDepsitAlwcListResultWork.SalesAddUpADate     = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SLS_SALESADDUPADATERF"));
                    wkDepsitAlwcListResultWork.AccRecDivCd         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_ACCRECDIVCDRF"));
                    wkDepsitAlwcListResultWork.DemandableTtl       = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLS_DEMANDABLETTLRF"));
                    wkDepsitAlwcListResultWork.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLS_DEPOSITALLOWANCETTLRF"));
                    wkDepsitAlwcListResultWork.MnyDepoAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLS_MNYDEPOALLOWANCETTLRF"));
                    wkDepsitAlwcListResultWork.DepositAlwcBlnce    = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLS_DEPOSITALWCBLNCERF"));
                    wkDepsitAlwcListResultWork.ClaimCode           = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_CLAIMCODERF"));
                    wkDepsitAlwcListResultWork.ClaimName1          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_CLAIMNAME1RF"));
                    wkDepsitAlwcListResultWork.ClaimName2          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_CLAIMNAME2RF"));
                    wkDepsitAlwcListResultWork.CustomerCode        = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_CUSTOMERCODERF"));
                    wkDepsitAlwcListResultWork.ClaimName1          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_CUSTOMERNAMERF"));
                    wkDepsitAlwcListResultWork.ClaimName2          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_CUSTOMERNAME2RF"));
                    wkDepsitAlwcListResultWork.HonorificTitle      = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_HONORIFICTITLERF"));
                    wkDepsitAlwcListResultWork.Kana                = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_KANARF"));

                    wkDepsitAlwcListResultWork.DepositAddupSecCd   = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DPA_ADDUPSECCODERF"));
                    wkDepsitAlwcListResultWork.DepositAddupSecNm   = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SIS4_SECTIONGUIDENMRF"));
                    wkDepsitAlwcListResultWork.DepositSlipNo       = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DPA_DEPOSITSLIPNORF"));
                    wkDepsitAlwcListResultWork.SearchSlipNum       = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_SEARCHSLIPNUMRF"));
                    wkDepsitAlwcListResultWork.SalesSlipKind       = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_SALESSLIPKINDRF"));
                    #endregion

                    al.Add(wkDepsitAlwcListResultWork);

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
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchDepsitAlwAction Exception=" + ex.Message);
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

        #region �����v�擾�����i���s���j
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="depsitMainListParamWork">���������i�[�N���X</param>
        /// <param name="sectionDepositDiv">0:����̂݁A1:���큕���_�R�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchAllTotalAction(ref ArrayList al, ref SqlConnection sqlConnection, DepsitMainListParamWork depsitMainListParamWork, int sectionDepositDiv, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            int OutPutDiv = 2;

            try
            {
                string selectTxt = string.Empty;

                #region Select���쐬
                //���_�����큕�a��������������敪�ŏW�v���s���ꍇ
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "     DEPSIT.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "    ,SEC.SECTIONGUIDENMRF ADDUPSECNAMERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT.ADDUPADATERF" + Environment.NewLine;
                selectTxt += "    ,SUM(DEPSIT.DEPOSITTOTALRF) SUM_DEPOSITTOTALRF" + Environment.NewLine;
                selectTxt += "    ,SUM(DEPSIT.DEPOSITRF) SUM_DEPOSITRF" + Environment.NewLine;
                selectTxt += "    ,SUM(DEPSIT.FEEDEPOSITRF) SUM_FEEDEPOSITRF" + Environment.NewLine;
                selectTxt += "    ,SUM(DEPSIT.DISCOUNTDEPOSITRF) SUM_DISCOUNTDEPOSITRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT.AUTODEPOSITCDRF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD.MONEYKINDCODERF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD.MONEYKINDNAMERF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD.MONEYKINDDIVRF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD.DEPOSITRF DEPOSITDTLRF" + Environment.NewLine;
                selectTxt += " FROM DEPSITMAINRF DEPSIT " + Environment.NewLine;
                selectTxt += " LEFT JOIN DEPSITDTLRF DEPSITD ON DEPSITD.ENTERPRISECODERF=DEPSIT.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND DEPSITD.DEPOSITSLIPNORF=DEPSIT.DEPOSITSLIPNORF" + Environment.NewLine;
                selectTxt += " LEFT JOIN SECINFOSETRF SEC ON SEC1.ENTERPRISECODERF=DEPSIT.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SEC.SECTIONCODERF=DEPSIT.AddUpSecCodeRF" + Environment.NewLine;
                selectTxt += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=DEPSIT.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUST.CUSTOMERCODERF=DEPSIT.CUSTOMERCODERF" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                //WHERE���̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, depsitMainListParamWork, OutPutDiv, logicalMode);

                sqlCommand.CommandText += " GROUP BY ";
                if (depsitMainListParamWork.PrintDiv == 3)
                {
                    sqlCommand.CommandText += "DEPSIT.ADDUPADATERF, ";
                }
                if (sectionDepositDiv == 1)
                    sqlCommand.CommandText += "DEPSIT.ADDUPSECCODERF, SEC.SECTIONGUIDENMRF, DEPSITD.MONEYKINDCODERF, DEPSITD.MONEYKINDNAMERF, DEPSITD.MONEYKINDDIVRF, DPM.AUTODEPOSITCDRF ";
                else
                    sqlCommand.CommandText += "DEPSITD.MONEYKINDCODERF, DEPSITD.MONEYKINDNAMERF, DEPSITD.MONEYKINDDIVRF, DPM.AUTODEPOSITCDRF ";

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    DepsitMainListResultWork wkDepsitMainListResultWork = new DepsitMainListResultWork();

                    //�����}�X�^���ʎ擾���e�i�[
                    if (sectionDepositDiv == 1)
                    {
                        wkDepsitMainListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        wkDepsitMainListResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    }
                    if (depsitMainListParamWork.PrintDiv == 3)
                    {
                        wkDepsitMainListResultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    }
                    wkDepsitMainListResultWork.DepositTotal          = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_DEPOSITTOTALRF"));
                    wkDepsitMainListResultWork.Deposit               = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_DEPOSITRF"));
                    wkDepsitMainListResultWork.FeeDeposit            = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_FEEDEPOSITRF"));
                    wkDepsitMainListResultWork.DiscountDeposit       = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_DISCOUNTDEPOSITRF"));
                    wkDepsitMainListResultWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                    wkDepsitMainListResultWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
                    wkDepsitMainListResultWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                    wkDepsitMainListResultWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
                    wkDepsitMainListResultWork.DepositDtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITDTLRF"));
                    #endregion

                    al.Add(wkDepsitMainListResultWork);

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
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchDepsitMainAction Exception=" + ex.Message);
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

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="depsitMainListParamWork">���������i�[�N���X</param>
        /// <param name="outPutDiv">�o�͋敪 0:�����̂݁A1:�����������A2:�����v</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, DepsitMainListParamWork depsitMainListParamWork, int outPutDiv, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE ";

            //��ƃR�[�h
            retstring += " DEPSIT.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND DEPSIT.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND DEPSIT.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //���_�R�[�h    ���z��ŕ����w�肳���
            if (depsitMainListParamWork.DepositAddupSecCodeList != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in depsitMainListParamWork.DepositAddupSecCodeList)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND DEPSIT.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                    //##retstring += " AND DPM.INPUTDEPOSITSECCDRF IN (" + sectionCodestr + ") ";
                }
            }

            //�����v��������ݒ�
            if (depsitMainListParamWork.St_AddUpADate != 0)
            {
                retstring += " AND DEPSIT.ADDUPADATERF >= " + depsitMainListParamWork.St_AddUpADate.ToString();
            }
            if (depsitMainListParamWork.Ed_AddUpADate != 0)
            {
                if (depsitMainListParamWork.St_AddUpADate == 0)
                {
                    retstring += " AND (DEPSIT.ADDUPADATERF IS NULL OR";
                }
                else
                {
                    retstring += " AND";
                }
                retstring += " DEPSIT.ADDUPADATERF <= " + depsitMainListParamWork.Ed_AddUpADate.ToString();
                if (depsitMainListParamWork.St_AddUpADate == 0)
                {
                    retstring += " ) ";
                }
            }

            //�������͓������ݒ�
            if (depsitMainListParamWork.St_CreateDate != 0)
            {
                //retstring += " AND DEPSIT.DEPOSITDATERF >= " + depsitMainListParamWork.St_CreateDate.ToString();
                retstring += " AND DEPSIT.INPUTDAYRF >= " + depsitMainListParamWork.St_CreateDate.ToString();  //ADD 2009/03/26
            }
            if (depsitMainListParamWork.Ed_CreateDate != 0)
            {
                if (depsitMainListParamWork.St_CreateDate == 0)
                {
                    //retstring += " AND (DEPSIT.DEPOSITDATERF IS NULL OR";
                    retstring += " AND (DEPSIT.INPUTDAYRF IS NULL OR";  //ADD 2009/03/26
                }
                else
                {
                    retstring += " AND";
                }
                //retstring += " DEPSIT.DEPOSITDATERF <= " + depsitMainListParamWork.Ed_CreateDate.ToString();
                retstring += " DEPSIT.INPUTDAYRF <= " + depsitMainListParamWork.Ed_CreateDate.ToString();  //ADD 2009/03/26
                if (depsitMainListParamWork.St_CreateDate == 0)
                {
                    retstring += " ) ";
                }
            }

            //���Ӑ�R�[�h�ݒ�
            if (depsitMainListParamWork.St_CustomerCode != 0)
            {
                retstring += " AND DEPSIT.CUSTOMERCODERF>=@STCUSTOMERCODE ";
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(depsitMainListParamWork.St_CustomerCode);
            }
            if (depsitMainListParamWork.Ed_CustomerCode != 0)
            {
                retstring += " AND DEPSIT.CUSTOMERCODERF<=@EDCUSTOMERCODE ";
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(depsitMainListParamWork.Ed_CustomerCode);
            }

            //�J�i�ݒ�
            if (depsitMainListParamWork.St_CustomerKana != "")
            {
                retstring += " AND CUST.KANARF>=@STKANA ";
                SqlParameter paraStCustomerKana = sqlCommand.Parameters.Add("@STKANA", SqlDbType.NVarChar);
                paraStCustomerKana.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_CustomerKana);
            }
            if (depsitMainListParamWork.Ed_CustomerKana != "")
            {
                retstring += " AND (CUST.KANARF<=@EDKANA OR CUST.KANARF LIKE @EDKANA) ";
                SqlParameter paraEdCustomerKana = sqlCommand.Parameters.Add("@EDKANA", SqlDbType.NVarChar);
                paraEdCustomerKana.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_CustomerKana + "%");
            }

            //�S���ҋ敪
            switch(depsitMainListParamWork.EmployeeKind)
            {
                case 0:
                    {
                        //���Ӑ�S���Ґݒ�
                        if (depsitMainListParamWork.St_EmployeeCd != "")
                        {
                            retstring += " AND CUST.CUSTOMERAGENTCDRF>=@STCUSTOMERAGENTCD ";
                            SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STCUSTOMERAGENTCD", SqlDbType.NChar);
                            paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_EmployeeCd);
                        }
                        if (depsitMainListParamWork.Ed_EmployeeCd != "")
                        {
                            if (depsitMainListParamWork.St_EmployeeCd == "")
                            {
                                retstring += " AND (CUST.CUSTOMERAGENTCDRF IS NULL OR";
                            }
                            else
                            {
                                retstring += " AND (";
                            }

                            retstring += " CUST.CUSTOMERAGENTCDRF<=@EDCUSTOMERAGENTCD OR CUST.CUSTOMERAGENTCDRF LIKE @EDCUSTOMERAGENTCD) ";
                            SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDCUSTOMERAGENTCD", SqlDbType.NChar);
                            paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_EmployeeCd + "%");
                        }
                        break;
                    }
                case 1:
                    {
                        //�W���S���Ґݒ�
                        if (depsitMainListParamWork.St_EmployeeCd != "")
                        {
                            retstring += " AND CUST.BILLCOLLECTERCDRF>=@STDEPOSITAGENTCODE ";
                            SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STDEPOSITAGENTCODE", SqlDbType.NChar);
                            paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_EmployeeCd);
                        }
                        if (depsitMainListParamWork.Ed_EmployeeCd != "")
                        {
                            if (depsitMainListParamWork.St_EmployeeCd == "")
                            {
                                retstring += " AND (CUST.BILLCOLLECTERCDRF IS NULL OR";
                            }
                            else
                            {
                                retstring += " AND (";
                            }

                            retstring += " CUST.BILLCOLLECTERCDRF<=@EDDEPOSITAGENTCODE OR CUST.BILLCOLLECTERCDRF LIKE @EDDEPOSITAGENTCODE) ";
                            SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDDEPOSITAGENTCODE", SqlDbType.NChar);
                            paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_EmployeeCd + "%");
                        }
                        break;
                    }
                case 2:
                    {
                        //�����S���Ґݒ�
                        if (depsitMainListParamWork.St_EmployeeCd != "")
                        {
                            retstring += " AND DEPSIT.DEPOSITAGENTCODERF>=@STDEPOSITAGENTCODE ";
                            SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STDEPOSITAGENTCODE", SqlDbType.NChar);
                            paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_EmployeeCd);
                        }
                        if (depsitMainListParamWork.Ed_EmployeeCd != "")
                        {
                            if (depsitMainListParamWork.St_EmployeeCd == "")
                            {
                                retstring += " AND (DEPSIT.DEPOSITAGENTCODERF IS NULL OR";
                            }
                            else
                            {
                                retstring += " AND (";
                            }

                            retstring += " DEPSIT.DEPOSITAGENTCODERF<=@EDDEPOSITAGENTCODE OR DEPSIT.DEPOSITAGENTCODERF LIKE @EDDEPOSITAGENTCODE) ";
                            SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDDEPOSITAGENTCODE", SqlDbType.NChar);
                            paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_EmployeeCd + "%");
                        }
                        break;
                    }
                case 3:
                    {
                        //�������͎Ґݒ�
                        if (depsitMainListParamWork.St_EmployeeCd != "")
                        {
                            retstring += " AND DEPSIT.DEPOSITINPUTAGENTCDRF>=@STDEPOSITINPUTAGENTCD ";
                            SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STDEPOSITINPUTAGENTCD", SqlDbType.NChar);
                            paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_EmployeeCd);
                        }
                        if (depsitMainListParamWork.Ed_EmployeeCd != "")
                        {
                            if (depsitMainListParamWork.St_EmployeeCd == "")
                            {
                                retstring += " AND (DEPSIT.DEPOSITINPUTAGENTCDRF IS NULL OR";
                            }
                            else
                            {
                                retstring += " AND (";
                            }

                            retstring += " DEPSIT.DEPOSITINPUTAGENTCDRF<=@EDDEPOSITINPUTAGENTCD OR DEPSIT.DEPOSITINPUTAGENTCDRF LIKE @EDDEPOSITINPUTAGENTCD) ";
                            SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDDEPOSITINPUTAGENTCD", SqlDbType.NChar);
                            paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_EmployeeCd + "%");
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            //�����`�[�ԍ��ݒ�
            if (depsitMainListParamWork.St_DepositSlipNo != 0)
            {
                retstring += " AND DEPSIT.DEPOSITSLIPNORF>=@STDEPOSITSLIPNO ";
                SqlParameter paraStDepositSlipNo = sqlCommand.Parameters.Add("@STDEPOSITSLIPNO", SqlDbType.Int);
                paraStDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainListParamWork.St_DepositSlipNo);
            }
            if (depsitMainListParamWork.Ed_DepositSlipNo != 0)
            {
                retstring += " AND DEPSIT.DEPOSITSLIPNORF<=@EDDEPOSITSLIPNO ";
                SqlParameter paraEdDepositSlipNo = sqlCommand.Parameters.Add("@EDDEPOSITSLIPNO", SqlDbType.Int);
                paraEdDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainListParamWork.Ed_DepositSlipNo);
            }

            //��������ݒ�
            if (depsitMainListParamWork.DepositCdKind != null)
            {
                if (depsitMainListParamWork.DepositCdKind.Count > 0)
                {
                    if (Convert.ToInt32(depsitMainListParamWork.DepositCdKind[0]) > -1)
                    {
                        ArrayList DepositKindArray = new ArrayList(depsitMainListParamWork.DepositCdKind);
                        if ((DepositKindArray != null) && (DepositKindArray.Count > 0))
                        {
                            string depositKindint = "";
                            int kindint;
                            for (int i = 0; i < DepositKindArray.Count; i++)
                            {
                                kindint = Convert.ToInt32(DepositKindArray[i]);
                                if (kindint != -1)
                                {
                                    if (depositKindint != "")
                                    {
                                        depositKindint += ",";
                                    }
                                    depositKindint += "'" + kindint + "'";
                                }
                            }

                            if (depositKindint != "")
                            {
                                retstring += " AND DEPSITD.MONEYKINDCODERF IN (" + depositKindint + ") ";
                            }
                        }
                    }
                }
            }

            ////�a����敪
            //if (depsitMainListParamWork.DepositCd != -1)
            //{
            //    switch (depsitMainListParamWork.DepositCd)
            //    {
            //        case 0:     // �S��
            //            break;
            //        case 1:     // �ʏ�
            //            retstring += " AND DEPSIT.DEPOSITCDRF=0 AND DEPSIT.AUTODEPOSITCDRF=0 ";
            //            break;
            //        case 2:     // �a���
            //            retstring += " AND DEPSIT.DEPOSITCDRF=1 ";
            //            break;
            //        case 3:     // ����
            //            retstring += " AND DEPSIT.AUTODEPOSITCDRF=1 ";
            //            break;
            //        default:
            //            break;
            //    }
            //}

            // 2008.07.01 del start --------------------------------->>
            //�����敪
            //if (depsitMainListParamWork.AllowanceDiv != -1)
            //{
            //    switch (depsitMainListParamWork.AllowanceDiv)
            //    {
            //        case 0:     // �����ς� (���������c��=0 AND ���������z<>0)
            //            retstring += " AND DEPSIT.DEPOSITALWCBLNCERF=0 AND DEPSIT.DEPOSITALLOWANCERF<>0 ";
            //            break;
            //        case 1:     // �ꕔ���� (���������c��>0 AND ���������z>0)
            //            retstring += " AND DEPSIT.DEPOSITALWCBLNCERF<>0 AND DEPSIT.DEPOSITALLOWANCERF<>0 ";
            //            break;
            //        case 2:     // ������   (���������c��>0 AND ���������z=0)
            //            retstring += " AND DEPSIT.DEPOSITALWCBLNCERF<>0 AND DEPSIT.DEPOSITALLOWANCERF=0 ";
            //            break;
            //        default:
            //            break;
            //    }
            //}
            
            //�����݂̂̏ꍇ�Ƀ\�[�g���쐬
            //if (outPutDiv == 0)
            //{
            //    //�\�[�g��
            //    retstring += " ORDER BY";

                // 2008.02.01 update�@�S�Ўw��̏ꍇ�̎d�l�ύX [ ��ɋ��_�R�[�h���\�[�g�L�[�ɒǉ����� ]
                ////���_�R�[�h���I������Ă��邩
                //if (depsitMainListParamWork.DepositAddupSecCodeList != null)
                //{
                //    //retstring += " DPM.ADDUPSECCODERF, ";
                //    retstring += " DPM.INPUTDEPOSITSECCDRF, ";
                //}
                //
            //    retstring += " DEPSIT.ADDUPSECCODERF, ";
                //##retstring += " DPM.INPUTDEPOSITSECCDRF, ";
            //    switch (depsitMainListParamWork.SortOrder)
            //    {
            //        case 0:
            //            {
            //                retstring += " DEPSIT.ADDUPADATERF, DEPSIT.CUSTOMERCODERF, DEPSIT.DEPOSITSLIPNORF, DEPSIT.DEBITNOTELINKDEPONORF ";
            //                break;
            //            }
            //        case 1:
            //            {
            //                retstring += " DEPSIT.ADDUPADATERF, CUST.KANARF, DEPSIT.CUSTOMERCODERF, DEPSIT.DEPOSITSLIPNORF, DEPSIT.DEBITNOTELINKDEPONORF ";
            //                break;
            //            }
            //        case 2:
            //            {
            //                retstring += " DEPSIT.ADDUPADATERF, ";
            //                switch(depsitMainListParamWork.EmployeeKind)
            //                {
            //                    case 0:
            //                        {
            //                            retstring += " CUST.CUSTOMERAGENTCDRF, ";
            //                            break;
            //                        }
            //                    case 1:
            //                        {
            //                            retstring += " CUST.BILLCOLLECTERCDRF, ";
            //                            break;
            //                        }
            //                    case 2:
            //                        {
            //                            retstring += " DEPSIT.DEPOSITAGENTCODERF, ";
            //                            break;
            //                        }
            //                    case 3:
            //                        {
            //                            retstring += " DEPSIT.DEPOSITINPUTAGENTCDRF, ";
            //                            break;
            //                        }
            //                    default:
            //                        {
            //                            retstring += " CUST.CUSTOMERAGENTCDRF, ";
            //                            break;
            //                        }
            //                }
            //                retstring += " DEPSIT.CUSTOMERCODERF, ";
            //                retstring += " DEPSIT.DEPOSITSLIPNORF, ";
            //                retstring += " DEPSIT.DEBITNOTELINKDEPONORF ";
            //                break;
            //            }
            //        case 3:
            //            {
            //                retstring += " DEPSIT.DEPOSITDATERF ";
            //                break;
            //            }
            //        case 4:
            //            {
            //                retstring += " DEPSIT.ADDUPADATERF ";
            //                break;
            //            }
            //        case 5:
            //            {
            //                retstring += " DEPSIT.DEPOSITSLIPNORF ";
            //                break;
            //            }
            //        default:
            //            {
            //                break;
            //            }
            //    }
            //}
            // 2008.07.01 del end -----------------------------------<<

            #endregion
            return retstring;
        }
    }
}
