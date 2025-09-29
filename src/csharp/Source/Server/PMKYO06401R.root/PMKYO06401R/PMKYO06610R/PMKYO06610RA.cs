//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�X�^����M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/04/29  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/06/09  �C�����e : ���ʃR�[�h�}�X�^�̂s�a�k���C�A�E�g�ύX�ɔ����C�� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/06/09  �C�����e : �}�X�^����M�s���Ή��ɂ��� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ����
// �C �� ��  2009/06/12  �C�����e : public Method��SQL�������ʖڑΉ��ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : 杍^
// �C �� ��  2009/06/24  �C�����e : PVCS#243 �}�X�^����M�����ɂ��� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/26  �C�����e : DC�������O��DC�e�f�[�^�̃N���A������ǉ�
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
    /// ���ʃR�[�h�}�X�^�i���[�U�[�o�^���j�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ʃR�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCPartsPosCodeUDB : RemoteDB
    {
        /// <summary>
        /// ���ʃR�[�h�}�X�^�i���[�U�[�o�^���jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCPartsPosCodeUDB()
            : base("PMKYO06611D", "Broadleaf.Application.Remoting.ParamData.DCPartsPosCodeUWork", "PARTSPOSCODEURF")
        {

        }

        #region [Read]
        /// <summary>
        /// ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="partsPosCodeUArrList">���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchPartsPosCodeU(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList partsPosCodeUArrList, out string retMessage)
        {
            return SearchPartsPosCodeUProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                                sqlTransaction, out partsPosCodeUArrList, out retMessage);
        }
        /// <summary>
        /// ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="partsPosCodeUArrList">���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchPartsPosCodeUProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList partsPosCodeUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            partsPosCodeUArrList = new ArrayList();
            DCPartsPosCodeUWork partsPosCodeUWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                // MOD 2009/06/09 --->>>
                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CUSTOMERCODERF, SEARCHPARTSPOSCODERF, SEARCHPARTSPOSNAMERF, POSDISPORDERRF, TBSPARTSCODERF, TBSPARTSCDDERIVEDNORF, OFFERDATERF, OFFERDATADIVRF FROM PARTSPOSCODEURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                // MOD 2009/06/09 ---<<<
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                // DEL 2009/06/09 --->>>
                //SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                //SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                // DEL 2009/06/09 ---<<<
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                // DEL 2009/06/09 --->>>
                //findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                //findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);
                // DEL 2009/06/09 ---<<<
                //���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    partsPosCodeUWork = new DCPartsPosCodeUWork();

                    partsPosCodeUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    partsPosCodeUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    partsPosCodeUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    partsPosCodeUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    partsPosCodeUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    partsPosCodeUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    partsPosCodeUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    partsPosCodeUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    partsPosCodeUWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    partsPosCodeUWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    partsPosCodeUWork.SearchPartsPosCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHPARTSPOSCODERF"));
                    partsPosCodeUWork.SearchPartsPosName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSPOSNAMERF"));
                    partsPosCodeUWork.PosDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSDISPORDERRF"));
                    partsPosCodeUWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    partsPosCodeUWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    // ADD 2009/06/09 --->>>
                    partsPosCodeUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    partsPosCodeUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
                    // ADD 2009/06/09 ---<<<
                    partsPosCodeUArrList.Add(partsPosCodeUWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCPartsPosCodeUDB.SearchPartsPosCodeU Exception=" + ex.Message);
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
        ///  ���ʃR�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^�폜
        /// </summary>
        /// <param name="dcPartsPosCodeUWork">���ʃR�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(DCPartsPosCodeUWork dcPartsPosCodeUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcPartsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  ���ʃR�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^�폜
        /// </summary>
        /// <param name="dcPartsPosCodeUWork">���ʃR�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(DCPartsPosCodeUWork dcPartsPosCodeUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM PARTSPOSCODEURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            // MOD 2009/06/24 --->>>
            //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            //SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
            // MOD 2009/06/24 ---<<<
            //SqlParameter findParaSearchPartsPosCode = sqlCommand.Parameters.Add("@FINDSEARCHPARTSPOSCODE", SqlDbType.Int);
            //SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = dcPartsPosCodeUWork.EnterpriseCode;
            // MOD 2009/06/24 --->>>
            //findParaSectionCode.Value = dcPartsPosCodeUWork.SectionCode;
            //findParaCustomerCode.Value = dcPartsPosCodeUWork.CustomerCode;
            // MOD 2009/06/24 ---<<<
            //findParaSearchPartsPosCode.Value = dcPartsPosCodeUWork.SearchPartsPosCode;
            //findParaTbsPartsCode.Value = dcPartsPosCodeUWork.TbsPartsCode;

            // ���ʃR�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// ���ʃR�[�h�}�X�^�i���[�U�[�o�^���j�o�^
        /// </summary>
        /// <param name="dcPartsPosCodeUWork">���ʃR�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(DCPartsPosCodeUWork dcPartsPosCodeUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcPartsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }

        /// <summary>
        /// ���ʃR�[�h�}�X�^�i���[�U�[�o�^���j�o�^
        /// </summary>
        /// <param name="dcPartsPosCodeUWork">���ʃR�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(DCPartsPosCodeUWork dcPartsPosCodeUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            // MOD 2009/06/09 --->>>
            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "INSERT INTO PARTSPOSCODEURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CUSTOMERCODERF, SEARCHPARTSPOSCODERF, SEARCHPARTSPOSNAMERF, POSDISPORDERRF, TBSPARTSCODERF, TBSPARTSCDDERIVEDNORF, OFFERDATERF, OFFERDATADIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @CUSTOMERCODE, @SEARCHPARTSPOSCODE, @SEARCHPARTSPOSNAME, @POSDISPORDER, @TBSPARTSCODE, @TBSPARTSCDDERIVEDNO, @OFFERDATE, @OFFERDATADIV)";
            // MOD 2009/06/09 ---<<<
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
            SqlParameter paraSearchPartsPosCode = sqlCommand.Parameters.Add("@SEARCHPARTSPOSCODE", SqlDbType.Int);
            SqlParameter paraSearchPartsPosName = sqlCommand.Parameters.Add("@SEARCHPARTSPOSNAME", SqlDbType.NVarChar);
            SqlParameter paraPosDispOrder = sqlCommand.Parameters.Add("@POSDISPORDER", SqlDbType.Int);
            SqlParameter paraTbsPartsCode = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);
            SqlParameter paraTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@TBSPARTSCDDERIVEDNO", SqlDbType.Int);
            // ADD 2009/06/09 --->>>
            SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
            SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);
            // ADD 2009/06/09 ---<<<

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcPartsPosCodeUWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcPartsPosCodeUWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcPartsPosCodeUWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcPartsPosCodeUWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcPartsPosCodeUWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcPartsPosCodeUWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcPartsPosCodeUWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcPartsPosCodeUWork.LogicalDeleteCode);
            if (string.IsNullOrEmpty(dcPartsPosCodeUWork.SectionCode.Trim()))
            {
                paraSectionCode.Value = dcPartsPosCodeUWork.SectionCode;
            }
            else
            {
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcPartsPosCodeUWork.SectionCode);
            }
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dcPartsPosCodeUWork.CustomerCode);
            paraSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(dcPartsPosCodeUWork.SearchPartsPosCode);
            paraSearchPartsPosName.Value = SqlDataMediator.SqlSetString(dcPartsPosCodeUWork.SearchPartsPosName);
            paraPosDispOrder.Value = SqlDataMediator.SqlSetInt32(dcPartsPosCodeUWork.PosDispOrder);
            paraTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(dcPartsPosCodeUWork.TbsPartsCode);
            paraTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(dcPartsPosCodeUWork.TbsPartsCdDerivedNo);
            paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcPartsPosCodeUWork.OfferDate);
            paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(dcPartsPosCodeUWork.OfferDataDiv);

            // ���ʃR�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^��o�^����
            sqlCommand.ExecuteNonQuery();
        }
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
        //    sqlCommand.CommandText = "DELETE FROM PARTSPOSCODEURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
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