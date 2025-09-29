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
// �� �� ��  2009/04/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ����
// �C �� ��  2009/06/12  �C�����e : public Method��SQL�������ʖڑΉ��ɂ���
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;

using Broadleaf.Library.Data;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�Ǘ����}�X�^READDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�Ǘ����}�X�^����READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APGoodsMngDB : RemoteDB
    {
        /// <summary>
        /// ���i�Ǘ����}�X�^READDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APGoodsMngDB()
            : base("PMKYO06181D", "Broadleaf.Application.Remoting.ParamData.APGoodsMngWork", "GOODSMNGRF")
        {

        }

        #region [Read]
        /// <summary>
        /// ���i�Ǘ����}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="goodsMngArrList">���i�Ǘ����}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchGoodsMng(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList goodsMngArrList, out string retMessage)
        { 
            return SearchGoodsMngProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                                   sqlTransaction, out goodsMngArrList, out retMessage);
        }
        /// <summary>
        /// ���i�Ǘ����}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="goodsMngArrList">���i�Ǘ����}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchGoodsMngProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList goodsMngArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            goodsMngArrList = new ArrayList();
            APGoodsMngWork goodsMngWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, GOODSMGROUPRF, GOODSMAKERCDRF, BLGOODSCODERF, GOODSNORF, SUPPLIERCDRF, SUPPLIERLOTRF FROM GOODSMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMGROUPRF = 0 AND BLGOODSCODERF = 0 AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //���i�Ǘ����}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    goodsMngWork = new APGoodsMngWork();

                    goodsMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    goodsMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    goodsMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    goodsMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    goodsMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    goodsMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    goodsMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    goodsMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    goodsMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    goodsMngWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    goodsMngWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    goodsMngWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    goodsMngWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsMngWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    goodsMngWork.SupplierLot = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERLOTRF"));


                    goodsMngArrList.Add(goodsMngWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APGoodsMngDB.SearchGoodsMng Exception=" + ex.Message);
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
        /// ���i�Ǘ����}�X�^�̌v����������
        /// </summary>
        /// <param name="goodsMngWork">�����I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����}�X�^�f�[�^�v����S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchGoodsMngCount(APGoodsMngWork goodsMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            return SearchGoodsMngCountProc(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���i�Ǘ����}�X�^�̌v����������
        /// </summary>
        /// <param name="goodsMngWork">�����I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����}�X�^�f�[�^�v����S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br>
        private int SearchGoodsMngCountProc(APGoodsMngWork goodsMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF FROM GOODSMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF=@FINDGOODSMGROUP AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE AND GOODSNORF=@FINDGOODSNO";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsMngWork.EnterpriseCode);
                findParaSectionCode.Value = goodsMngWork.SectionCode;
                findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsMngWork.GoodsMGroup);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngWork.GoodsMakerCd);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsMngWork.BLGoodsCode);
                findParaGoodsNo.Value = goodsMngWork.GoodsNo;

                // ���_���ݒ�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APGoodsMngDB.SearchGoodsMngCount Exception=" + ex.Message);
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
        ///  ���i�Ǘ����}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="apGoodsMngWork">���i�Ǘ����}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�Ǘ����}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Delete(APGoodsMngWork apGoodsMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(apGoodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  ���i�Ǘ����}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="apGoodsMngWork">���i�Ǘ����}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�Ǘ����}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        private void DeleteProc(APGoodsMngWork apGoodsMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM GOODSMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF=@FINDGOODSMGROUP AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE AND GOODSNORF=@FINDGOODSNO";

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = apGoodsMngWork.EnterpriseCode;
            findParaSectionCode.Value = apGoodsMngWork.SectionCode;
            findParaGoodsMGroup.Value = apGoodsMngWork.GoodsMGroup;
            findParaGoodsMakerCd.Value = apGoodsMngWork.GoodsMakerCd;
            findParaBLGoodsCode.Value = apGoodsMngWork.BLGoodsCode;
            findParaGoodsNo.Value = apGoodsMngWork.GoodsNo;


            // ���i�Ǘ����}�X�^�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// ���i�Ǘ����}�X�^�o�^
        /// </summary>
        /// <param name="apGoodsMngWork">���i�Ǘ����}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�Ǘ����}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Insert(APGoodsMngWork apGoodsMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(apGoodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���i�Ǘ����}�X�^�o�^
        /// </summary>
        /// <param name="apGoodsMngWork">���i�Ǘ����}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�Ǘ����}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        private void InsertProc(APGoodsMngWork apGoodsMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "INSERT INTO GOODSMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, GOODSMGROUPRF, GOODSMAKERCDRF, BLGOODSCODERF, GOODSNORF, SUPPLIERCDRF, SUPPLIERLOTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @GOODSMGROUP, @GOODSMAKERCD, @BLGOODSCODE, @GOODSNO, @SUPPLIERCD, @SUPPLIERLOT)";

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
            SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
            SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
            SqlParameter paraSupplierLot = sqlCommand.Parameters.Add("@SUPPLIERLOT", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGoodsMngWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGoodsMngWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apGoodsMngWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apGoodsMngWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apGoodsMngWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apGoodsMngWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apGoodsMngWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apGoodsMngWork.LogicalDeleteCode);
            if (string.IsNullOrEmpty(apGoodsMngWork.SectionCode.Trim()))
            {
                paraSectionCode.Value = apGoodsMngWork.SectionCode;
            }
            else
            {
                paraSectionCode.Value = SqlDataMediator.SqlSetString(apGoodsMngWork.SectionCode);
            }
            paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(apGoodsMngWork.GoodsMGroup);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apGoodsMngWork.GoodsMakerCd);
            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(apGoodsMngWork.BLGoodsCode);
            if (string.IsNullOrEmpty(apGoodsMngWork.GoodsNo.Trim()))
            {
                paraGoodsNo.Value = apGoodsMngWork.GoodsNo;
            }
            else
            {
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(apGoodsMngWork.GoodsNo);
            }
            paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(apGoodsMngWork.SupplierCd);
            paraSupplierLot.Value = SqlDataMediator.SqlSetInt32(apGoodsMngWork.SupplierLot);

            // ���i�Ǘ����}�X�^�f�[�^��o�^����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

    }
}

