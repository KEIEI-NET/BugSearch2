//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�X�^����M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/06/09  �C�����e : �}�X�^����M�s���Ή��ɂ��� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ����
// �C �� ��  2009/06/12  �C�����e : public Method��SQL�������ʖڑΉ��ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/07/26  �C�����e : SCM�Ή�-���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : �g���Y
// �C �� ��  2011/08/20  �C�����e : myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/26  �C�����e : DC�������O��DC�e�f�[�^�̃N���A������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/09/08  �C�����e : #23777 �\�[�X���r���[
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
    /// ���Ӑ�}�X�^�i�|���O���[�v�j�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCCustRateGroupDB : RemoteDB
    {
        /// <summary>
        /// ���Ӑ�}�X�^�i�|���O���[�v�jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCCustRateGroupDB()
            : base("PMKYO06451D", "Broadleaf.Application.Remoting.ParamData.DCCustRateGroupWork", "CUSTRATEGROUPRF")
        {

        }

        #region [Read]
        /// <summary>
        /// ���Ӑ�}�X�^�i�|���O���[�v�j�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="custRateGroupArrList">���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchCustRateGroup(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
           SqlTransaction sqlTransaction, out ArrayList custRateGroupArrList, out string retMessage)
        {
            return SearchCustRateGroupProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                                    sqlTransaction, out custRateGroupArrList, out retMessage);
        }
        /// <summary>
        /// ���Ӑ�}�X�^�i�|���O���[�v�j�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="custRateGroupArrList">���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchCustRateGroupProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList custRateGroupArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            custRateGroupArrList = new ArrayList();
            DCCustRateGroupWork custRateGroupWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, PURECODERF, GOODSMAKERCDRF, CUSTRATEGRPCODERF FROM CUSTRATEGROUPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    custRateGroupWork = new DCCustRateGroupWork();

                    custRateGroupWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    custRateGroupWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    custRateGroupWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    custRateGroupWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    custRateGroupWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    custRateGroupWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    custRateGroupWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    custRateGroupWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    custRateGroupWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    custRateGroupWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                    custRateGroupWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    custRateGroupWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));

                    custRateGroupArrList.Add(custRateGroupWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCCustRateGroupDB.SearchCustRateGroup Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
            return status;
        }
        #endregion

        # region [Delete]
        /// <summary>
        ///  ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^�폜
        /// </summary>
        /// <param name="dcCustRateGroupWork">���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(DCCustRateGroupWork dcCustRateGroupWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcCustRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^�폜
        /// </summary>
        /// <param name="dcCustRateGroupWork">���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(DCCustRateGroupWork dcCustRateGroupWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM CUSTRATEGROUPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE ";
            //Prameter�I�u�W�F�N�g�̍쐬
            // ��ƃR�[�h
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            // ���Ӑ�R�[�h
            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = dcCustRateGroupWork.EnterpriseCode;
            findParaCustomerCode.Value = dcCustRateGroupWork.CustomerCode;

            // ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// ���Ӑ�}�X�^�i�|���O���[�v�j�o�^
        /// </summary>
        /// <param name="dcCustRateGroupWork">���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(DCCustRateGroupWork dcCustRateGroupWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcCustRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���Ӑ�}�X�^�i�|���O���[�v�j�o�^
        /// </summary>
        /// <param name="dcCustRateGroupWork">���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(DCCustRateGroupWork dcCustRateGroupWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "INSERT INTO CUSTRATEGROUPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, PURECODERF, GOODSMAKERCDRF, CUSTRATEGRPCODERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @CUSTOMERCODE, @PURECODE, @GOODSMAKERCD, @CUSTRATEGRPCODE)";

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
            SqlParameter paraPureCode = sqlCommand.Parameters.Add("@PURECODE", SqlDbType.Int);
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
            SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcCustRateGroupWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcCustRateGroupWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcCustRateGroupWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcCustRateGroupWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcCustRateGroupWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcCustRateGroupWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcCustRateGroupWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcCustRateGroupWork.LogicalDeleteCode);
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dcCustRateGroupWork.CustomerCode);
            paraPureCode.Value = SqlDataMediator.SqlSetInt32(dcCustRateGroupWork.PureCode);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(dcCustRateGroupWork.GoodsMakerCd);
            paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(dcCustRateGroupWork.CustRateGrpCode);

            // ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^��o�^����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region 2011/07/26 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j
        #region [Read]
        #region DEL 2011/09/08 sundx #23777 �\�[�X���r���[
        ///// <summary>
        ///// ���Ӑ�}�X�^�i�|���O���[�v�j�̌�������
        ///// </summary>
        ///// <param name="enterpriseCodes">��ƃR�[�h</param>
        ///// <param name="paramList">��������</param>
        ///// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        ///// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        ///// <param name="custRateGroupArrList">���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^�I�u�W�F�N�g</param>
        ///// <param name="retMessage">�߂郁�b�Z�[�W</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^READLIST��S�Ė߂��܂�</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2011.07.26</br>
        //public int SearchCustRateGroup(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //   SqlTransaction sqlTransaction, out ArrayList custRateGroupArrList, out string retMessage)
        //{
        //    return SearchCustRateGroupProc(enterpriseCodes, paramList, sqlConnection,
        //                            sqlTransaction, out custRateGroupArrList, out retMessage);
        //}
        ///// <summary>
        ///// ���Ӑ�}�X�^�i�|���O���[�v�j�̌�������
        ///// </summary>
        ///// <param name="enterpriseCodes">��ƃR�[�h</param>
        ///// <param name="paramList">��������</param>
        ///// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        ///// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        ///// <param name="custRateGroupArrList">���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^�I�u�W�F�N�g</param>
        ///// <param name="retMessage">�߂郁�b�Z�[�W</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^READLIST��S�Ė߂��܂�</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2011.07.26</br>
        //private int SearchCustRateGroupProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList custRateGroupArrList, out string retMessage)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    custRateGroupArrList = new ArrayList();
        //    //DCCustRateGroupWork custRateGroupWork = null;//DEL 2011/08/20 �r���[�i�`�F�b�N
        //    retMessage = string.Empty;
        //    string sqlStr = string.Empty;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;
        //    CustomerProcParamWork param = paramList as CustomerProcParamWork;

        //    try
        //    {
        //        sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //        sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, PURECODERF, GOODSMAKERCDRF, CUSTRATEGRPCODERF FROM CUSTRATEGROUPRF ";
        //        sqlStr += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";

        //        if (param.UpdateDateTimeBegin != 0)
        //        {
        //            sqlStr += " AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
        //            SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
        //            findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
        //        }
        //        if (param.UpdateDateTimeEnd != 0)
        //        {
        //            sqlStr += " AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
        //            SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
        //            findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
        //        }
        //        if (param.CustomerCodeBeginRF != 0)
        //        {
        //            sqlStr += " AND CUSTOMERCODERF >= @CUSTOMERCODEBEGINRF";
        //            SqlParameter customerCodeBeginRF = sqlCommand.Parameters.Add("@CUSTOMERCODEBEGINRF", SqlDbType.Int);
        //            customerCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.CustomerCodeBeginRF);
        //        }
        //        if (param.CustomerCodeEndRF != 0)
        //        {
        //            sqlStr += " AND CUSTOMERCODERF <= @CUSTOMERCODEENDRF";
        //            SqlParameter customerCodeEndRF = sqlCommand.Parameters.Add("@CUSTOMERCODEENDRF", SqlDbType.Int);
        //            customerCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.CustomerCodeEndRF);
        //        }

        //        //Prameter�I�u�W�F�N�g�̍쐬
        //        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

        //        //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);

        //        //���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^�pSQL
        //        sqlCommand.CommandText = sqlStr;

        //        // �ǂݍ���
        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            #region DEL
        //            //-----DEL 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)----->>>>>
        //            //custRateGroupWork = new DCCustRateGroupWork();

        //            //custRateGroupWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //            //custRateGroupWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //            //custRateGroupWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //            //custRateGroupWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //            //custRateGroupWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //            //custRateGroupWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //            //custRateGroupWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //            //custRateGroupWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //            //custRateGroupWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
        //            //custRateGroupWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
        //            //custRateGroupWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
        //            //custRateGroupWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));

        //            //custRateGroupArrList.Add(custRateGroupWork);
        //            //-----DEL 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)-----<<<<<
        //            #endregion DEL
        //            custRateGroupArrList.Add(CopyFromMyReaderToDCCustRateGroupWork(myReader));//ADD 2011/08/20 �r���[�i�`�F�b�N
        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        base.WriteErrorLog(ex, "DCCustRateGroupDB.SearchCustRateGroup Exception=" + ex.Message);
        //        retMessage = ex.Message;
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (myReader != null)
        //            if (!myReader.IsClosed) myReader.Close();

        //        if (sqlCommand != null)
        //        {
        //            sqlCommand.Cancel();
        //            sqlCommand.Dispose();
        //        }
        //    }
        //    return status;
        //}

        ////-----ADD 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)----->>>>>
        ///// <summary>
        ///// ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^���擾
        ///// </summary>
        ///// <param name="myReader">SqlDataReader</param>
        ///// <returns>���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^</returns>
        ///// <br>Note       : ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^��߂��܂�</br>
        ///// <br>Programmer : �g���Y</br>
        ///// <br>Date       : 2011/08/20</br>
        //private DCCustRateGroupWork CopyFromMyReaderToDCCustRateGroupWork(SqlDataReader myReader)
        //{
        //    DCCustRateGroupWork custRateGroupWork = new DCCustRateGroupWork();

        //    custRateGroupWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //    custRateGroupWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //    custRateGroupWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //    custRateGroupWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //    custRateGroupWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //    custRateGroupWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //    custRateGroupWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //    custRateGroupWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //    custRateGroupWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
        //    custRateGroupWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
        //    custRateGroupWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
        //    custRateGroupWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));

        //    return custRateGroupWork;
        //}
        ////-----ADD 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)-----<<<<<
        #endregion
        #endregion
        #endregion 2011/07/26 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j

        // ADD 2011.08.26 ---------->>>>>
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
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Delete�R�}���h�̐���
			sqlCommand.CommandText = "DELETE FROM CUSTRATEGROUPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
			//Prameter�I�u�W�F�N�g�̍쐬
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
			//Parameter�I�u�W�F�N�g�֒l�ݒ�
			findParaEnterpriseCode.Value = enterpriseCode;

			// ���_���ݒ�}�X�^�f�[�^���폜����
			sqlCommand.ExecuteNonQuery();
		}
		#endregion
		// ADD 2011.08.26 ----------<<<<<
    }
}