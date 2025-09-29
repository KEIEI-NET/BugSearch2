//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   �}�X�^����M����                           �@�@ //
// Name Space       :   Broadleaf.Application.Remoting           	    //
//                  :   PMKYO06550R.DLL							        //
// Programmer       :   ������	                                        //
// Date             :   2009.04.30                                      //
//----------------------------------------------------------------------//
// Update Note      :   ���仁@2009.06.12�@							//
//                  :   public Method��SQL�������ʖڑΉ��ɂ���        //
//----------------------------------------------------------------------//
// Update Note      :   ���仁@2011.08.26�@							//
//                  :   DC�������O��DC�e�f�[�^�̃N���A������ǉ�        //
//----------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

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
    /// ���i��փ}�X�^�i���[�U�[�o�^���j�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCPartsSubstUDB : RemoteDB
    {
        /// <summary>
        /// ���i��փ}�X�^�i���[�U�[�o�^���jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCPartsSubstUDB()
            : base("PMKYO06551D", "Broadleaf.Application.Remoting.ParamData.DCPartsSubstUWork", "PARTSSUBSTURF")
        {

        }

        #region [Read]
        /// <summary>
        /// ���i��փ}�X�^�i���[�U�[�o�^���j�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="partsSubstUArrList">���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchPartsSubstU(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList partsSubstUArrList, out string retMessage)
        {
            return SearchPartsSubstUProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                                       sqlTransaction, out partsSubstUArrList, out retMessage);
        }
        /// <summary>
        /// ���i��փ}�X�^�i���[�U�[�o�^���j�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="partsSubstUArrList">���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchPartsSubstUProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList partsSubstUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            partsSubstUArrList = new ArrayList();
            DCPartsSubstUWork partsSubstUWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CHGSRCMAKERCDRF, CHGSRCGOODSNORF, CHGSRCGOODSNONONEHPRF, CHGDESTMAKERCDRF, CHGDESTGOODSNORF, CHGDESTGOODSNONONEHPRF, APPLYSTADATERF, APPLYENDDATERF FROM PARTSSUBSTURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    partsSubstUWork = new DCPartsSubstUWork();

                    partsSubstUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    partsSubstUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    partsSubstUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    partsSubstUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    partsSubstUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    partsSubstUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    partsSubstUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    partsSubstUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    partsSubstUWork.ChgSrcMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGSRCMAKERCDRF"));
                    partsSubstUWork.ChgSrcGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF"));
                    partsSubstUWork.ChgSrcGoodsNoNoneHp = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNONONEHPRF"));
                    partsSubstUWork.ChgDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGDESTMAKERCDRF"));
                    partsSubstUWork.ChgDestGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
                    partsSubstUWork.ChgDestGoodsNoNoneHp = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNONONEHPRF"));
                    partsSubstUWork.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
                    partsSubstUWork.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));

                    partsSubstUArrList.Add(partsSubstUWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCPartsSubstUDB.SearchPartsSubstU Exception=" + ex.Message);
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
        ///  ���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^�폜
        /// </summary>
        /// <param name="dcPartsSubstUWork">���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(DCPartsSubstUWork dcPartsSubstUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcPartsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  ���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^�폜
        /// </summary>
        /// <param name="dcPartsSubstUWork">���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(DCPartsSubstUWork dcPartsSubstUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM PARTSSUBSTURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO";

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaChgSrcMakerCd = sqlCommand.Parameters.Add("@FINDCHGSRCMAKERCD", SqlDbType.Int);
            SqlParameter findParaChgSrcGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = dcPartsSubstUWork.EnterpriseCode;
            findParaChgSrcMakerCd.Value = dcPartsSubstUWork.ChgSrcMakerCd;
            findParaChgSrcGoodsNo.Value = dcPartsSubstUWork.ChgSrcGoodsNo;

            // ���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// ���i��փ}�X�^�i���[�U�[�o�^���j�o�^
        /// </summary>
        /// <param name="dcPartsSubstUWork">���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(DCPartsSubstUWork dcPartsSubstUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcPartsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���i��փ}�X�^�i���[�U�[�o�^���j�o�^
        /// </summary>
        /// <param name="dcPartsSubstUWork">���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(DCPartsSubstUWork dcPartsSubstUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "INSERT INTO PARTSSUBSTURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CHGSRCMAKERCDRF, CHGSRCGOODSNORF, CHGSRCGOODSNONONEHPRF, CHGDESTMAKERCDRF, CHGDESTGOODSNORF, CHGDESTGOODSNONONEHPRF, APPLYSTADATERF, APPLYENDDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @CHGSRCMAKERCD, @CHGSRCGOODSNO, @CHGSRCGOODSNONONEHP, @CHGDESTMAKERCD, @CHGDESTGOODSNO, @CHGDESTGOODSNONONEHP, @APPLYSTADATE, @APPLYENDDATE)";

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraChgSrcMakerCd = sqlCommand.Parameters.Add("@CHGSRCMAKERCD", SqlDbType.Int);
            SqlParameter paraChgSrcGoodsNo = sqlCommand.Parameters.Add("@CHGSRCGOODSNO", SqlDbType.NVarChar);
            SqlParameter paraChgSrcGoodsNoNoneHp = sqlCommand.Parameters.Add("@CHGSRCGOODSNONONEHP", SqlDbType.NVarChar);
            SqlParameter paraChgDestMakerCd = sqlCommand.Parameters.Add("@CHGDESTMAKERCD", SqlDbType.Int);
            SqlParameter paraChgDestGoodsNo = sqlCommand.Parameters.Add("@CHGDESTGOODSNO", SqlDbType.NVarChar);
            SqlParameter paraChgDestGoodsNoNoneHp = sqlCommand.Parameters.Add("@CHGDESTGOODSNONONEHP", SqlDbType.NVarChar);
            SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
            SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);


            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcPartsSubstUWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcPartsSubstUWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcPartsSubstUWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcPartsSubstUWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcPartsSubstUWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcPartsSubstUWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcPartsSubstUWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcPartsSubstUWork.LogicalDeleteCode);
            paraChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(dcPartsSubstUWork.ChgSrcMakerCd);
            if (string.IsNullOrEmpty(dcPartsSubstUWork.ChgSrcGoodsNo.Trim()))
            {
                paraChgSrcGoodsNo.Value = dcPartsSubstUWork.ChgSrcGoodsNo;
            }
            else
            {
                paraChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(dcPartsSubstUWork.ChgSrcGoodsNo);
            }
            if (string.IsNullOrEmpty(dcPartsSubstUWork.ChgSrcGoodsNoNoneHp.Trim()))
            {
                paraChgSrcGoodsNoNoneHp.Value = dcPartsSubstUWork.ChgSrcGoodsNoNoneHp;
            }
            else
            {
                paraChgSrcGoodsNoNoneHp.Value = SqlDataMediator.SqlSetString(dcPartsSubstUWork.ChgSrcGoodsNoNoneHp);
            }
            paraChgDestMakerCd.Value = SqlDataMediator.SqlSetInt32(dcPartsSubstUWork.ChgDestMakerCd);
            if (string.IsNullOrEmpty(dcPartsSubstUWork.ChgDestGoodsNo.Trim()))
            {
                paraChgDestGoodsNo.Value = dcPartsSubstUWork.ChgDestGoodsNo;
            }
            else
            {
                paraChgDestGoodsNo.Value = SqlDataMediator.SqlSetString(dcPartsSubstUWork.ChgDestGoodsNo);
            }
            if (string.IsNullOrEmpty(dcPartsSubstUWork.ChgDestGoodsNoNoneHp.Trim()))
            {
                paraChgDestGoodsNoNoneHp.Value = dcPartsSubstUWork.ChgDestGoodsNoNoneHp;
            }
            else
            {
                paraChgDestGoodsNoNoneHp.Value = SqlDataMediator.SqlSetString(dcPartsSubstUWork.ChgDestGoodsNoNoneHp);
            }
            paraApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcPartsSubstUWork.ApplyStaDate);
            paraApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcPartsSubstUWork.ApplyEndDate);


            // ���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^��o�^����
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
        //    sqlCommand.CommandText = "DELETE FROM PARTSSUBSTURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
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