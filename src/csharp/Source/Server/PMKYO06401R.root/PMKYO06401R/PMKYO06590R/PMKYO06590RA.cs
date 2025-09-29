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
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/26  �C�����e : DC�������O��DC�e�f�[�^�̃N���A������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : FSI��k�c �G��
// �C �� ��  2012/07/26  �C�����e : ���_�Ǘ� ���o�����ǉ��Ή�
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
    /// �����}�X�^�i���[�U�[�o�^���j�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����}�X�^�i���[�U�[�o�^���j�f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCJoinPartsUDB : RemoteDB
    {
        #region [Private]
        // --- ADD 2012/07/26 ----------->>>>>
        private int _createDateTime = 0;
        private int _updateDateTime = 0;
        private int _enterpriseCode = 0;
        private int _fileHeaderGuid = 0;
        private int _updEmployeeCode = 0;
        private int _updAssemblyId1 = 0;
        private int _updAssemblyId2 = 0;
        private int _logicalDeleteCode = 0;
        private int _joinDispOrder = 0;
        private int _joinSourceMakerCode = 0;
        private int _joinSourPartsNoWithH = 0;
        private int _joinSourPartsNoNoneH = 0;
        private int _joinDestMakerCd = 0;
        private int _joinDestPartsNo = 0;
        private int _joinQty = 0;
        private int _joinSpecialNote = 0;
        // --- ADD 2012/07/26 -----------<<<<<
        #endregion

        /// <summary>
        /// �����}�X�^�i���[�U�[�o�^���jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCJoinPartsUDB()
            : base("PMKYO06591D", "Broadleaf.Application.Remoting.ParamData.DCJoinPartsUWork", "JOINPARTSURF")
        {

        }

        #region [Read]
        /// <summary>
        /// �����}�X�^�i���[�U�[�o�^���j�̌��������i���t�w��j
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="joinPartsUArrList">�����}�X�^�i���[�U�[�o�^���j�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^�i���[�U�[�o�^���j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        public int SearchJoinPartsU(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
           SqlTransaction sqlTransaction, out ArrayList joinPartsUArrList, out string retMessage)
        {
            return SearchJoinPartsUProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                               sqlTransaction, out joinPartsUArrList, out retMessage);
        }
        /// <summary>
        /// �����}�X�^�i���[�U�[�o�^���j�̌��������i���t�w��j
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="joinPartsUArrList">�����}�X�^�i���[�U�[�o�^���j�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^�i���[�U�[�o�^���j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        private int SearchJoinPartsUProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList joinPartsUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            joinPartsUArrList = new ArrayList();
            DCJoinPartsUWork joinPartsUWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, JOINDISPORDERRF, JOINSOURCEMAKERCODERF, JOINSOURPARTSNOWITHHRF, JOINSOURPARTSNONONEHRF, JOINDESTMAKERCDRF, JOINDESTPARTSNORF, JOINQTYRF, JOINSPECIALNOTERF FROM JOINPARTSURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //�����}�X�^�i���[�U�[�o�^���j�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    joinPartsUWork = new DCJoinPartsUWork();

                    joinPartsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    joinPartsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    joinPartsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    joinPartsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    joinPartsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    joinPartsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    joinPartsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    joinPartsUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    joinPartsUWork.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDISPORDERRF"));
                    joinPartsUWork.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                    joinPartsUWork.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                    joinPartsUWork.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNONONEHRF"));
                    joinPartsUWork.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
                    joinPartsUWork.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
                    joinPartsUWork.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));
                    joinPartsUWork.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSPECIALNOTERF"));

                    joinPartsUArrList.Add(joinPartsUWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCJoinPartsUDB.SearchJoinPartsU Exception=" + ex.Message);
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
        ///  �����}�X�^�i���[�U�[�o�^���j�f�[�^�폜
        /// </summary>
        /// <param name="dcJoinPartsUWork">�����}�X�^�i���[�U�[�o�^���j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �����}�X�^�i���[�U�[�o�^���j�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Delete(DCJoinPartsUWork dcJoinPartsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcJoinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  �����}�X�^�i���[�U�[�o�^���j�f�[�^�폜
        /// </summary>
        /// <param name="dcJoinPartsUWork">�����}�X�^�i���[�U�[�o�^���j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �����}�X�^�i���[�U�[�o�^���j�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        private void DeleteProc(DCJoinPartsUWork dcJoinPartsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM JOINPARTSURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH ";

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaJoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
            SqlParameter findParaJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
            // DEL 2009/06/09 --->>>
            //SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
            //SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);
            // DEL 2009/06/09 ---<<<
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = dcJoinPartsUWork.EnterpriseCode;
            findParaJoinSourceMakerCode.Value = dcJoinPartsUWork.JoinSourceMakerCode;
            findParaJoinSourPartsNoWithH.Value = dcJoinPartsUWork.JoinSourPartsNoWithH;
            // DEL 2009/06/09 --->>>
            //findParaJoinDestMakerCd.Value = dcJoinPartsUWork.JoinDestMakerCd;
            //findParaJoinDestPartsNo.Value = dcJoinPartsUWork.JoinDestPartsNo;
            // DEL 2009/06/09 ---<<<

            // �����}�X�^�i���[�U�[�o�^���j�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// �����}�X�^�i���[�U�[�o�^���j�o�^
        /// </summary>
        /// <param name="dcJoinPartsUWork">�����}�X�^�i���[�U�[�o�^���j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �����}�X�^�i���[�U�[�o�^���j�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Insert(DCJoinPartsUWork dcJoinPartsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcJoinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// �����}�X�^�i���[�U�[�o�^���j�o�^
        /// </summary>
        /// <param name="dcJoinPartsUWork">�����}�X�^�i���[�U�[�o�^���j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �����}�X�^�i���[�U�[�o�^���j�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        private void InsertProc(DCJoinPartsUWork dcJoinPartsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "INSERT INTO JOINPARTSURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, JOINDISPORDERRF, JOINSOURCEMAKERCODERF, JOINSOURPARTSNOWITHHRF, JOINSOURPARTSNONONEHRF, JOINDESTMAKERCDRF, JOINDESTPARTSNORF, JOINQTYRF, JOINSPECIALNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @JOINDISPORDER, @JOINSOURCEMAKERCODE, @JOINSOURPARTSNOWITHH, @JOINSOURPARTSNONONEH, @JOINDESTMAKERCD, @JOINDESTPARTSNO, @JOINQTY, @JOINSPECIALNOTE)";

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraJoinDispOrder = sqlCommand.Parameters.Add("@JOINDISPORDER", SqlDbType.Int);
            SqlParameter paraJoinSourceMakerCode = sqlCommand.Parameters.Add("@JOINSOURCEMAKERCODE", SqlDbType.Int);
            SqlParameter paraJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@JOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
            SqlParameter paraJoinSourPartsNoNoneH = sqlCommand.Parameters.Add("@JOINSOURPARTSNONONEH", SqlDbType.NVarChar);
            SqlParameter paraJoinDestMakerCd = sqlCommand.Parameters.Add("@JOINDESTMAKERCD", SqlDbType.Int);
            SqlParameter paraJoinDestPartsNo = sqlCommand.Parameters.Add("@JOINDESTPARTSNO", SqlDbType.NVarChar);
            SqlParameter paraJoinQty = sqlCommand.Parameters.Add("@JOINQTY", SqlDbType.Float);
            SqlParameter paraJoinSpecialNote = sqlCommand.Parameters.Add("@JOINSPECIALNOTE", SqlDbType.NVarChar);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcJoinPartsUWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcJoinPartsUWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcJoinPartsUWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcJoinPartsUWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcJoinPartsUWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcJoinPartsUWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcJoinPartsUWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcJoinPartsUWork.LogicalDeleteCode);
            paraJoinDispOrder.Value = SqlDataMediator.SqlSetInt32(dcJoinPartsUWork.JoinDispOrder);
            paraJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(dcJoinPartsUWork.JoinSourceMakerCode);
            if (string.IsNullOrEmpty(dcJoinPartsUWork.JoinSourPartsNoWithH.Trim()))
            {
                paraJoinSourPartsNoWithH.Value = dcJoinPartsUWork.JoinSourPartsNoWithH;
            }
            else
            {
                paraJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(dcJoinPartsUWork.JoinSourPartsNoWithH);
            }
            if (string.IsNullOrEmpty(dcJoinPartsUWork.JoinSourPartsNoNoneH.Trim()))
            {
                paraJoinSourPartsNoNoneH.Value = dcJoinPartsUWork.JoinSourPartsNoNoneH;
            }
            else
            {
                paraJoinSourPartsNoNoneH.Value = SqlDataMediator.SqlSetString(dcJoinPartsUWork.JoinSourPartsNoNoneH);
            }
            paraJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(dcJoinPartsUWork.JoinDestMakerCd);
            if (string.IsNullOrEmpty(dcJoinPartsUWork.JoinDestPartsNo.Trim()))
            {
                paraJoinDestPartsNo.Value = dcJoinPartsUWork.JoinDestPartsNo;
            }
            else
            {
                paraJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(dcJoinPartsUWork.JoinDestPartsNo);
            }
            paraJoinQty.Value = SqlDataMediator.SqlSetDouble(dcJoinPartsUWork.JoinQty);
            paraJoinSpecialNote.Value = SqlDataMediator.SqlSetString(dcJoinPartsUWork.JoinSpecialNote);

            // �����}�X�^�i���[�U�[�o�^���j�f�[�^��o�^����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region [Read][���_�Ǘ� ���o�����ǉ��Ή�]
        // --- ADD 2012/07/26 ------------------------------------->>>>>
        /// <summary>
        /// �����}�X�^�i���[�U�[�o�^���j�̌��������i�R�[�h�w��j
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="paramList">��������</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="joinPartsUArrList">�����}�X�^�i���[�U�[�o�^���j�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^�i���[�U�[�o�^���j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : FSI��k�c �G��</br>
        /// <br>Date       : 2012/07/26</br>
        public int SearchJoinPartsU(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList joinPartsUArrList, out string retMessage)
        {
            return SearchJoinPartsUProc(enterpriseCodes, paramList, sqlConnection, sqlTransaction, out joinPartsUArrList, out retMessage);
        }

        /// <summary>
        /// �����}�X�^�i���[�U�[�o�^���j�̌��������i�R�[�h�w��j
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="paramList">��������</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="joinPartsUArrList">�����}�X�^�i���[�U�[�o�^���j�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^�i���[�U�[�o�^���j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : FSI��k�c �G��</br>
        /// <br>Date       : 2012/07/26</br>
        public int SearchJoinPartsUProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList joinPartsUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            joinPartsUArrList = new ArrayList();
            retMessage = string.Empty;
            StringBuilder sqlStr = new StringBuilder();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            JoinPartsUProcParamWork param = paramList as JoinPartsUProcParamWork;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr.AppendLine("SELECT");
                sqlStr.AppendLine("    CREATEDATETIMERF, -- �쐬����");
                sqlStr.AppendLine("    UPDATEDATETIMERF, -- �X�V����");
                sqlStr.AppendLine("    ENTERPRISECODERF, -- ��ƃR�[�h");
                sqlStr.AppendLine("    FILEHEADERGUIDRF, -- GUID");
                sqlStr.AppendLine("    UPDEMPLOYEECODERF, -- �X�V�]�ƈ��R�[�h");
                sqlStr.AppendLine("    UPDASSEMBLYID1RF, -- �X�V�A�Z���u��ID1");
                sqlStr.AppendLine("    UPDASSEMBLYID2RF, -- �X�V�A�Z���u��ID2");
                sqlStr.AppendLine("    LOGICALDELETECODERF, -- �_���폜�敪");
                sqlStr.AppendLine("    JOINDISPORDERRF, -- �����\������");
                sqlStr.AppendLine("    JOINSOURCEMAKERCODERF, -- ���������[�J�[�R�[�h");
                sqlStr.AppendLine("    JOINSOURPARTSNOWITHHRF, -- �������i��(�|�t���i��)");
                sqlStr.AppendLine("    JOINSOURPARTSNONONEHRF, -- �������i��(�|�����i��)");
                sqlStr.AppendLine("    JOINDESTMAKERCDRF, -- �����惁�[�J�[�R�[�h");
                sqlStr.AppendLine("    JOINDESTPARTSNORF, -- ������i��(�|�t���i��)");
                sqlStr.AppendLine("    JOINQTYRF, -- ����QTY");
                sqlStr.AppendLine("    JOINSPECIALNOTERF -- �����K�i�E���L����");
                sqlStr.AppendLine("FROM");
                sqlStr.AppendLine("    JOINPARTSURF");

                #region WHERE
                sqlStr.AppendLine("WHERE");
                sqlStr.AppendLine("        ENTERPRISECODERF = @FINDENTERPRISECODE");

                // �J�n����
                if (param.UpdateDateTimeBegin != 0)
                {
                    sqlStr.Append(" AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                }

                // �I������
                if (param.UpdateDateTimeEnd != 0)
                {
                    sqlStr.Append(" AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                }

                // �������i��
                if (!string.IsNullOrEmpty(param.JoinSourPartsNoWithHBeginRF))
                {
                    sqlStr.Append(" AND JOINSOURPARTSNOWITHHRF >= @JOINSOURPARTSNOWITHHBEGINRF");
                    SqlParameter joinSourPartsNoWithHBeginRF = sqlCommand.Parameters.Add("@JOINSOURPARTSNOWITHHBEGINRF", SqlDbType.NVarChar);
                    joinSourPartsNoWithHBeginRF.Value = SqlDataMediator.SqlSetString(param.JoinSourPartsNoWithHBeginRF);
                }

                if (!string.IsNullOrEmpty(param.JoinSourPartsNoWithHEndRF))
                {
                    sqlStr.Append(" AND JOINSOURPARTSNOWITHHRF <= @JOINSOURPARTSNOWITHHENDRF");
                    SqlParameter joinSourPartsNoWithHEndRF = sqlCommand.Parameters.Add("@JOINSOURPARTSNOWITHHENDRF", SqlDbType.NVarChar);
                    joinSourPartsNoWithHEndRF.Value = SqlDataMediator.SqlSetString(param.JoinSourPartsNoWithHEndRF);
                }

                // ���������[�J�[�R�[�h
                if (param.JoinSourceMakerCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND JOINSOURCEMAKERCODERF >= @JOINSOURCEMAKERCODEBEGINRF");
                    SqlParameter joinSourceMakerCodeBeginRF = sqlCommand.Parameters.Add("@JOINSOURCEMAKERCODEBEGINRF", SqlDbType.Int);
                    joinSourceMakerCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.JoinSourceMakerCodeBeginRF);
                }

                if (param.JoinSourceMakerCodeEndRF != 0)
                {
                    sqlStr.Append(" AND JOINSOURCEMAKERCODERF <= @JOINSOURCEMAKERCODEENDRF");
                    SqlParameter joinSourceMakerCodeEndRF = sqlCommand.Parameters.Add("@JOINSOURCEMAKERCODEENDRF", SqlDbType.Int);
                    joinSourceMakerCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.JoinSourceMakerCodeEndRF);
                }

                // �����\������
                if (param.JoinDispOrderBeginRF != 0)
                {
                    sqlStr.Append(" AND JOINDISPORDERRF >= @JOINDISPORDERBEGINRF");
                    SqlParameter joinDispOrderBeginRF = sqlCommand.Parameters.Add("@JOINDISPORDERBEGINRF", SqlDbType.Int);
                    joinDispOrderBeginRF.Value = SqlDataMediator.SqlSetInt32(param.JoinDispOrderBeginRF);
                }

                if (param.JoinDispOrderEndRF != 0)
                {
                    sqlStr.Append(" AND JOINDISPORDERRF <= @JOINDISPORDERENDRF");
                    SqlParameter joinSourceMakerCodeEndRF = sqlCommand.Parameters.Add("@JOINDISPORDERENDRF", SqlDbType.Int);
                    joinSourceMakerCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.JoinDispOrderEndRF);
                }

                // �����惁�[�J�[�R�[�h
                if (param.JoinDestMakerCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND JOINDESTMAKERCDRF >= @JOINDESTMAKERCODEBEGINRF");
                    SqlParameter joinDestMakerCodeBeginRF = sqlCommand.Parameters.Add("@JOINDESTMAKERCODEBEGINRF", SqlDbType.Int);
                    joinDestMakerCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.JoinDestMakerCodeBeginRF);
                }

                if (param.JoinDestMakerCodeEndRF != 0)
                {
                    sqlStr.Append(" AND JOINDESTMAKERCDRF <= @JOINDESTMAKERCODEENDRF");
                    SqlParameter joinDestMakerCodeEndRF = sqlCommand.Parameters.Add("@JOINDESTMAKERCODEENDRF", SqlDbType.Int);
                    joinDestMakerCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.JoinDestMakerCodeEndRF);
                }

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                #endregion WHERE

                // �����}�X�^�i���[�U�[�o�^���j�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr.ToString();
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    SetIndex(myReader);
                }

                while (myReader.Read())
                {
                    joinPartsUArrList.Add(CopyFromMyReaderToDCJoinPartsUWork(myReader));
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCJoinPartsUDB.SearchJoinPartsU Exception=" + ex.Message);
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

        /// <summary>
        /// �C���f�b�N�X�i�[����
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : �J�����C���f�b�N�X�i�[�������s��</br>
        /// <br>Programmer : FSI��k�c �G��</br>
        /// <br>Date       : 2012/07/26</br>
        /// </remarks>
        private void SetIndex(SqlDataReader myReader)
        {
            _createDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
            _updateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
            _enterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
            _fileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
            _updEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
            _updAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
            _updAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
            _logicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
            _joinDispOrder = myReader.GetOrdinal("JOINDISPORDERRF");
            _joinSourceMakerCode = myReader.GetOrdinal("JOINSOURCEMAKERCODERF");
            _joinSourPartsNoWithH = myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF");
            _joinSourPartsNoNoneH = myReader.GetOrdinal("JOINSOURPARTSNONONEHRF");
            _joinDestMakerCd = myReader.GetOrdinal("JOINDESTMAKERCDRF");
            _joinDestPartsNo = myReader.GetOrdinal("JOINDESTPARTSNORF");
            _joinQty = myReader.GetOrdinal("JOINQTYRF");
            _joinSpecialNote = myReader.GetOrdinal("JOINSPECIALNOTERF");
        }

        /// <summary>
        /// �����}�X�^�i���[�U�[�o�^���j�f�[�^���擾
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>�����}�X�^�i���[�U�[�o�^���j�f�[�^</returns>
        /// <br>Note       : �����}�X�^�i���[�U�[�o�^���j�f�[�^��߂��܂�</br>
        /// <br>Programmer : FSI��k�c �G��</br>
        /// <br>Date       : 2012/07/26</br>
        /// 
        private DCJoinPartsUWork CopyFromMyReaderToDCJoinPartsUWork(SqlDataReader myReader)
        {
            DCJoinPartsUWork joinPartsUWork = new DCJoinPartsUWork();

            joinPartsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _createDateTime);
            joinPartsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _updateDateTime);
            joinPartsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _enterpriseCode);
            joinPartsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _fileHeaderGuid);
            joinPartsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _updEmployeeCode);
            joinPartsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _updAssemblyId1);
            joinPartsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _updAssemblyId2);
            joinPartsUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _logicalDeleteCode);
            joinPartsUWork.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, _joinDispOrder);
            joinPartsUWork.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, _joinSourceMakerCode);
            joinPartsUWork.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, _joinSourPartsNoWithH);
            joinPartsUWork.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, _joinSourPartsNoNoneH);
            joinPartsUWork.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, _joinDestMakerCd);
            joinPartsUWork.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, _joinDestPartsNo);
            joinPartsUWork.JoinQty = SqlDataMediator.SqlGetDouble(myReader, _joinQty);
            joinPartsUWork.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, _joinSpecialNote);

            return joinPartsUWork;
        }
        // --- ADD 2012/07/26 -------------------------------------<<<<<
        #endregion

        // ADD 2011.08.26 ---------->>>>>
        # region [Clear]DEL by Liangsd     2011/09/06
        //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
        //// R�N���X�� Method��SQL�������ʖ�
        ///// <summary>
        ///// �f�[�^�N���A
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        ///// <param name="sqlTransaction">�g�����U�N�V�������</param>
        ///// <param name="sqlCommand">SQL�R�����g</param>
        ///// <returns></returns>
        //public void Clear(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    ClearProc(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        //}
        ///// <summary>
        ///// �f�[�^�N���A
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        ///// <param name="sqlTransaction">�g�����U�N�V�������</param>
        ///// <param name="sqlCommand">SQL�R�����g</param>
        ///// <returns></returns>
        //private void ClearProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //    // Delete�R�}���h�̐���
        //    sqlCommand.CommandText = "DELETE FROM JOINPARTSURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
        //    //Prameter�I�u�W�F�N�g�̍쐬
        //    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //    //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //    findParaEnterpriseCode.Value = enterpriseCode;

        //    // ���_���ݒ�}�X�^�f�[�^���폜����
        //    sqlCommand.ExecuteNonQuery();
        //}
        //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
        #endregion
        // ADD 2011.08.26 ----------<<<<<
    }
}