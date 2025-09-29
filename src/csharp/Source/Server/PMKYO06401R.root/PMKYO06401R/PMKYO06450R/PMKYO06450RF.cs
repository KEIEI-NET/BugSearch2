//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�X�^����M����
// �v���O�����T�v   : �f�[�^�ǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2021 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770021-00 �쐬�S�� : ���O
// �� �� ��  2021/04/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�}�X�^�i�������j�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^�i�������j�f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2021/04/12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCCustomerMemoDB : RemoteDB
    {
        /// <summary>
        /// ���Ӑ�}�X�^�i�������jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2021/04/12</br>
        /// </remarks>
        public DCCustomerMemoDB()
            : base("PMKYO06451D", "Broadleaf.Application.Remoting.ParamData.DCCustomerMemoWork", "CUSTOMERMEMORF")
        {

        }

        #region [Read]
        /// <summary>
        /// ���Ӑ�}�X�^(�������)�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="customerMemoArrList">���Ӑ�}�X�^(�������)�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^(�������)�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2021/04/12</br>
        public int SearchCustomerMemo(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList customerMemoArrList, out string retMessage)
        {
            return SearchCustomerMemoProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                           sqlTransaction, out customerMemoArrList, out retMessage);
        }
        /// <summary>
        /// ���Ӑ�}�X�^(�������)�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="customerMemoArrList">���Ӑ�}�X�^(�������)�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^(�������)�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2021/04/12</br> 
        private int SearchCustomerMemoProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList customerMemoArrList, out string retMessage)
        {
            //������
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            customerMemoArrList = new ArrayList();
            DCCustomerMemoWork customerMemoWork = null;
            retMessage = string.Empty;
            StringBuilder sqlStr = new StringBuilder();
            SqlDataReader myReader = null;

            try
            {
                //SQL�쐬
                sqlStr.Append("SELECT ");
                sqlStr.Append(" CREATEDATETIMERF, ");
                sqlStr.Append(" UPDATEDATETIMERF, ");
                sqlStr.Append(" ENTERPRISECODERF, ");
                sqlStr.Append(" FILEHEADERGUIDRF, ");
                sqlStr.Append(" UPDEMPLOYEECODERF, ");
                sqlStr.Append(" UPDASSEMBLYID1RF, ");
                sqlStr.Append(" UPDASSEMBLYID2RF, ");
                sqlStr.Append(" LOGICALDELETECODERF, ");
                sqlStr.Append(" CUSTOMERCODERF, ");
                sqlStr.Append(" NOTEINFORF, ");
                sqlStr.Append(" ISNULL(DISPLAYDIVCODERF, 0) AS DISPLAYDIVCODERF ");
                sqlStr.Append("FROM ");
                sqlStr.Append(" CUSTOMERMEMORF ");
                sqlStr.Append("WHERE ");
                sqlStr.Append(" ENTERPRISECODERF = @FINDENTERPRISECODE AND ");
                sqlStr.Append(" UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND  ");
                sqlStr.Append(" UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF ");

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr.ToString(), sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                    // �ǂݍ���
                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        customerMemoWork = new DCCustomerMemoWork();

                        customerMemoWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        customerMemoWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        customerMemoWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        customerMemoWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        customerMemoWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        customerMemoWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        customerMemoWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        customerMemoWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        customerMemoWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        customerMemoWork.NoteInfo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTEINFORF"));
                        customerMemoWork.DisplayDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYDIVCODERF"));

                        customerMemoArrList.Add(customerMemoWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCCustomerMemoDB.SearchCustomerMemo Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "DCCustomerMemoDB.SearchCustomerMemo Exception=" + e.Message);
                retMessage = e.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion

        # region [Delete]
        /// <summary>
        ///  ���Ӑ�}�X�^�i�������j�f�[�^�폜
        /// </summary>
        /// <param name="dcCustomerMemoWork">���Ӑ�}�X�^�i�������j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�������j�f�[�^���폜����</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Delete(DCCustomerMemoWork dcCustomerMemoWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcCustomerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }

        /// <summary>
        ///  ���Ӑ�}�X�^�i�������j�f�[�^�폜
        /// </summary>
        /// <param name="dcCustomerMemoWork">���Ӑ�}�X�^�i�������j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�������j�f�[�^���폜����</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2009.04.28</br> 
        private void DeleteProc(DCCustomerMemoWork dcCustomerMemoWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            //������
            StringBuilder sqlStr = new StringBuilder();

            try
            {
                //SQL�쐬
                sqlStr.Append("DELETE ");
                sqlStr.Append("FROM ");
                sqlStr.Append(" CUSTOMERMEMORF ");
                sqlStr.Append("WHERE ");
                sqlStr.Append(" ENTERPRISECODERF = @FINDENTERPRISECODE AND ");
                sqlStr.Append(" CUSTOMERCODERF=@FINDCUSTOMERCODE  ");

                //delete�R�}���h�̐���
                using (sqlCommand = new SqlCommand(sqlStr.ToString(), sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = dcCustomerMemoWork.EnterpriseCode;
                    findParaCustomerCode.Value = dcCustomerMemoWork.CustomerCode;

                    // ���Ӑ�}�X�^�i�������j�f�[�^���폜����
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCCustomerMemoDB.DeleteProc Exception=" + ex.Message);
            }
            catch (Exception e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "DCCustomerMemoDB.DeleteProc Exception=" + e.Message);
            }
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// ���Ӑ�}�X�^�i�������j�o�^
        /// </summary>
        /// <param name="dcCustomerMemoWork">���Ӑ�}�X�^�i�������j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�������j�f�[�^��o�^����</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Insert(DCCustomerMemoWork dcCustomerMemoWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcCustomerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���Ӑ�}�X�^�i�������j�o�^
        /// </summary>
        /// <param name="dcCustomerMemoWork">���Ӑ�}�X�^�i�������j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�������j�f�[�^��o�^����</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2009.04.28</br> 
        private void InsertProc(DCCustomerMemoWork dcCustomerMemoWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            //������
            StringBuilder sqlStr = new StringBuilder();

            try
            {
                //SQL�쐬
                sqlStr.Append("INSERT INTO  ");
                sqlStr.Append(" CUSTOMERMEMORF ");
                sqlStr.Append("(CREATEDATETIMERF, ");
                sqlStr.Append(" UPDATEDATETIMERF, ");
                sqlStr.Append(" ENTERPRISECODERF, ");
                sqlStr.Append(" FILEHEADERGUIDRF, ");
                sqlStr.Append(" UPDEMPLOYEECODERF, ");
                sqlStr.Append(" UPDASSEMBLYID1RF, ");
                sqlStr.Append(" UPDASSEMBLYID2RF, ");
                sqlStr.Append(" LOGICALDELETECODERF, ");
                sqlStr.Append(" CUSTOMERCODERF, ");
                sqlStr.Append(" NOTEINFORF, ");
                sqlStr.Append(" DISPLAYDIVCODERF) ");
                sqlStr.Append("VALUES ");
                sqlStr.Append("(@CREATEDATETIME, ");
                sqlStr.Append(" @UPDATEDATETIME, ");
                sqlStr.Append(" @ENTERPRISECODE, ");
                sqlStr.Append(" @FILEHEADERGUID, ");
                sqlStr.Append(" @UPDEMPLOYEECODE, ");
                sqlStr.Append(" @UPDASSEMBLYID1, ");
                sqlStr.Append(" @UPDASSEMBLYID2, ");
                sqlStr.Append(" @LOGICALDELETECODE, ");
                sqlStr.Append(" @CUSTOMERCODE, ");
                sqlStr.Append(" @NOTEINFORF, ");
                sqlStr.Append(" @DISPLAYDIVCODERF) ");

                //�R�}���h�̐���
                using (sqlCommand = new SqlCommand(sqlStr.ToString(), sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraNoteInfo = sqlCommand.Parameters.Add("@NOTEINFORF", SqlDbType.NVarChar);
                    SqlParameter paraDisplayDivCode = sqlCommand.Parameters.Add("@DISPLAYDIVCODERF", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcCustomerMemoWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcCustomerMemoWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcCustomerMemoWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcCustomerMemoWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcCustomerMemoWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcCustomerMemoWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcCustomerMemoWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerMemoWork.LogicalDeleteCode);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerMemoWork.CustomerCode);
                    paraNoteInfo.Value = SqlDataMediator.SqlSetString(dcCustomerMemoWork.NoteInfo);
                    paraDisplayDivCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerMemoWork.DisplayDivCode);

                    // ���Ӑ�}�X�^�i�������j�f�[�^��o�^����
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCCustomerMemoDB.Insert Exception=" + ex.Message);
            }
            catch (Exception e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "DCCustomerMemoDB.Insert Exception=" + e.Message);
            }
        }
        #endregion

        # region [Clear]
        // R�N���X�� Method��SQL�������ʖ�
        /// <summary>
        /// �f�[�^�N���A
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Clear(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            ClearProc(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// �f�[�^�N���A
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void ClearProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
           //������
            StringBuilder sqlStr = new StringBuilder();

            try
            {
                //SQL�쐬
                sqlStr.Append("DELETE ");
                sqlStr.Append("FROM ");
                sqlStr.Append(" CUSTOMERMEMORF ");
                sqlStr.Append("WHERE ");
                sqlStr.Append(" ENTERPRISECODERF = @FINDENTERPRISECODE ");

                //delete�R�}���h�̐���
                using (sqlCommand = new SqlCommand(sqlStr.ToString(), sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = enterpriseCode;

                    // ���_���ݒ�}�X�^�f�[�^���폜����
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCCustomerMemoDB.Clear Exception=" + ex.Message);
            }
            catch (Exception e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "DCCustomerMemoDB.Clear Exception=" + e.Message);
            }
        }
        #endregion
    }
}