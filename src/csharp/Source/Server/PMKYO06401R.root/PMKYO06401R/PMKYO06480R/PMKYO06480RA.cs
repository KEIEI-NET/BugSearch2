//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   �}�X�^����M�����@                           �@ //
// Name Space       :   Broadleaf.Application.Remoting           	    //
//                  :   PMKYO06480R.DLL							        //
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
    /// BL���i�R�[�h�}�X�^�i���[�U�[�o�^�j�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : BL���i�R�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCBLGoodsCdUDB : RemoteDB
    {
        /// <summary>
        /// BL���i�R�[�h�}�X�^�i���[�U�[�o�^�jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCBLGoodsCdUDB()
            : base("PMKYO06481D", "Broadleaf.Application.Remoting.ParamData.DCBLGoodsCdUWork", "BLGOODSCDURF")
        {

        }

        #region [Read]
        /// <summary>
        /// BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="bLGoodsCdUArrList">BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchBLGoodsCdU(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList bLGoodsCdUArrList, out string retMessage)
        {
            return SearchBLGoodsCdUProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                                 sqlTransaction, out bLGoodsCdUArrList, out retMessage);
        }
        /// <summary>
        /// BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="bLGoodsCdUArrList">BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchBLGoodsCdUProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList bLGoodsCdUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            bLGoodsCdUArrList = new ArrayList();
            DCBLGoodsCdUWork bLGoodsCdUWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, BLGROUPCODERF, BLGOODSCODERF, BLGOODSFULLNAMERF, BLGOODSHALFNAMERF, BLGOODSGENRECODERF, GOODSRATEGRPCODERF, OFFERDATERF, OFFERDATADIVRF FROM BLGOODSCDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    bLGoodsCdUWork = new DCBLGoodsCdUWork();

                    bLGoodsCdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    bLGoodsCdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    bLGoodsCdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    bLGoodsCdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    bLGoodsCdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    bLGoodsCdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    bLGoodsCdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    bLGoodsCdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    bLGoodsCdUWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    bLGoodsCdUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    bLGoodsCdUWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    bLGoodsCdUWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                    bLGoodsCdUWork.BLGoodsGenreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSGENRECODERF"));
                    bLGoodsCdUWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
                    bLGoodsCdUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    bLGoodsCdUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));


                    bLGoodsCdUArrList.Add(bLGoodsCdUWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCBLGoodsCdUDB.SearchBLGoodsCdU Exception=" + ex.Message);
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
        ///  BL���i�R�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^�폜
        /// </summary>
        /// <param name="dcBLGoodsCdUWork">BL���i�R�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(DCBLGoodsCdUWork dcBLGoodsCdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcBLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  BL���i�R�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^�폜
        /// </summary>
        /// <param name="dcBLGoodsCdUWork">BL���i�R�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(DCBLGoodsCdUWork dcBLGoodsCdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM BLGOODSCDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BLGOODSCODERF=@FINDBLGOODSCODE";
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = dcBLGoodsCdUWork.EnterpriseCode;
            findParaBLGoodsCode.Value = dcBLGoodsCdUWork.BLGoodsCode;


            // BL���i�R�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// BL���i�R�[�h�}�X�^�i���[�U�[�o�^�j�o�^
        /// </summary>
        /// <param name="dcBLGoodsCdUWork">BL���i�R�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(DCBLGoodsCdUWork dcBLGoodsCdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcBLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// BL���i�R�[�h�}�X�^�i���[�U�[�o�^�j�o�^
        /// </summary>
        /// <param name="dcBLGoodsCdUWork">BL���i�R�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(DCBLGoodsCdUWork dcBLGoodsCdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "INSERT INTO BLGOODSCDURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, BLGROUPCODERF, BLGOODSCODERF, BLGOODSFULLNAMERF, BLGOODSHALFNAMERF, BLGOODSGENRECODERF, GOODSRATEGRPCODERF, OFFERDATERF, OFFERDATADIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @BLGROUPCODE, @BLGOODSCODE, @BLGOODSFULLNAME, @BLGOODSHALFNAME, @BLGOODSGENRECODE, @GOODSRATEGRPCODE, @OFFERDATE, @OFFERDATADIV)";

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
            SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
            SqlParameter paraBLGoodsHalfName = sqlCommand.Parameters.Add("@BLGOODSHALFNAME", SqlDbType.NVarChar);
            SqlParameter paraBLGoodsGenreCode = sqlCommand.Parameters.Add("@BLGOODSGENRECODE", SqlDbType.Int);
            SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@GOODSRATEGRPCODE", SqlDbType.Int);
            SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
            SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcBLGoodsCdUWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcBLGoodsCdUWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcBLGoodsCdUWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcBLGoodsCdUWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcBLGoodsCdUWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcBLGoodsCdUWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcBLGoodsCdUWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcBLGoodsCdUWork.LogicalDeleteCode);
            paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(dcBLGoodsCdUWork.BLGroupCode);
            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(dcBLGoodsCdUWork.BLGoodsCode);
            if (string.IsNullOrEmpty(dcBLGoodsCdUWork.BLGoodsFullName.Trim()))
            {
                paraBLGoodsFullName.Value = dcBLGoodsCdUWork.BLGoodsFullName;
            }
            else
            {
                paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(dcBLGoodsCdUWork.BLGoodsFullName);
            }
            if (string.IsNullOrEmpty(dcBLGoodsCdUWork.BLGoodsHalfName.Trim()))
            {
                paraBLGoodsHalfName.Value = dcBLGoodsCdUWork.BLGoodsHalfName;
            }
            else
            {
                paraBLGoodsHalfName.Value = SqlDataMediator.SqlSetString(dcBLGoodsCdUWork.BLGoodsHalfName);
            }
            paraBLGoodsGenreCode.Value = SqlDataMediator.SqlSetInt32(dcBLGoodsCdUWork.BLGoodsGenreCode);
            paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(dcBLGoodsCdUWork.GoodsRateGrpCode);
            paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcBLGoodsCdUWork.OfferDate);
            paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(dcBLGoodsCdUWork.OfferDataDiv);


            // BL���i�R�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^��o�^����
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
        //    sqlCommand.CommandText = "DELETE FROM BLGOODSCDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
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