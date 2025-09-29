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
    /// �Ԏ햼�̃}�X�^READDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ԏ햼�̃}�X�^����READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APModelNameUDB : RemoteDB
    {
        /// <summary>
        /// �Ԏ햼�̃}�X�^READDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APModelNameUDB()
            : base("PMKYO06321D", "Broadleaf.Application.Remoting.ParamData.APModelNameUWork", "MODELNAMEURF")
        {

        }

        #region [Read]
        /// <summary>
        /// �Ԏ햼�̃}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="modelNameUArrList">�Ԏ햼�̃}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchModelNameU(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList modelNameUArrList, out string retMessage)
        {
            return SearchModelNameUProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                                 sqlTransaction, out modelNameUArrList, out retMessage);
        }
        /// <summary>
        /// �Ԏ햼�̃}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="modelNameUArrList">�Ԏ햼�̃}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchModelNameUProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList modelNameUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            modelNameUArrList = new ArrayList();
            APModelNameUWork modelNameUWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, MODELUNIQUECODERF, MAKERCODERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, MODELALIASNAMERF, OFFERDATERF, OFFERDATADIVRF FROM MODELNAMEURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //�Ԏ햼�̃}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    modelNameUWork = new APModelNameUWork();

                    modelNameUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    modelNameUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    modelNameUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    modelNameUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    modelNameUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    modelNameUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    modelNameUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    modelNameUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    modelNameUWork.ModelUniqueCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELUNIQUECODERF"));
                    modelNameUWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    modelNameUWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                    modelNameUWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                    modelNameUWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                    modelNameUWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                    modelNameUWork.ModelAliasName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELALIASNAMERF"));
                    modelNameUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    modelNameUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));

                    modelNameUArrList.Add(modelNameUWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APModelNameUDB.SearchModelNameU Exception=" + ex.Message);
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
        /// �Ԏ햼�̃}�X�^�̌v����������
        /// </summary>
        /// <param name="modelNameUWork">�����I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�v����S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchModelNameUCount(APModelNameUWork modelNameUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            return SearchModelNameUCountProc(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// �Ԏ햼�̃}�X�^�̌v����������
        /// </summary>
        /// <param name="modelNameUWork">�����I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�v����S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br>
        private int SearchModelNameUCountProc(APModelNameUWork modelNameUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF FROM MODELNAMEURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND MODELUNIQUECODERF=@FINDMODELUNIQUECODE";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaModelUniqueCode = sqlCommand.Parameters.Add("@FINDMODELUNIQUECODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.EnterpriseCode);
                findParaModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelUniqueCode);


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
                base.WriteErrorLog(ex, "APSecInfoSetDB.SearchSecInfoSet Exception=" + ex.Message);
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
        ///  �Ԏ햼�̃}�X�^�i���[�U�[�o�^�j�f�[�^�폜
        /// </summary>
        /// <param name="apModelNameUWork">�Ԏ햼�̃}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(APModelNameUWork apModelNameUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(apModelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  �Ԏ햼�̃}�X�^�i���[�U�[�o�^�j�f�[�^�폜
        /// </summary>
        /// <param name="apModelNameUWork">�Ԏ햼�̃}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(APModelNameUWork apModelNameUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM MODELNAMEURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND MODELUNIQUECODERF=@FINDMODELUNIQUECODE";

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaModelUniqueCode = sqlCommand.Parameters.Add("@FINDMODELUNIQUECODE", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = apModelNameUWork.EnterpriseCode;
            findParaModelUniqueCode.Value = apModelNameUWork.ModelUniqueCode;

            // �Ԏ햼�̃}�X�^�i���[�U�[�o�^�j�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// �Ԏ햼�̃}�X�^�i���[�U�[�o�^�j�o�^
        /// </summary>
        /// <param name="apModelNameUWork">�Ԏ햼�̃}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(APModelNameUWork apModelNameUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(apModelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// �Ԏ햼�̃}�X�^�i���[�U�[�o�^�j�o�^
        /// </summary>
        /// <param name="apModelNameUWork">�Ԏ햼�̃}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(APModelNameUWork apModelNameUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "INSERT INTO MODELNAMEURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, MODELUNIQUECODERF, MAKERCODERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, MODELALIASNAMERF, OFFERDATERF, OFFERDATADIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @MODELUNIQUECODE, @MAKERCODE, @MODELCODE, @MODELSUBCODE, @MODELFULLNAME, @MODELHALFNAME, @MODELALIASNAME, @OFFERDATE, @OFFERDATADIV)";

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraModelUniqueCode = sqlCommand.Parameters.Add("@MODELUNIQUECODE", SqlDbType.Int);
            SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
            SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);
            SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);
            SqlParameter paraModelFullName = sqlCommand.Parameters.Add("@MODELFULLNAME", SqlDbType.NVarChar);
            SqlParameter paraModelHalfName = sqlCommand.Parameters.Add("@MODELHALFNAME", SqlDbType.NVarChar);
            SqlParameter paraModelAliasName = sqlCommand.Parameters.Add("@MODELALIASNAME", SqlDbType.NVarChar);
            SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
            SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);


            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apModelNameUWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apModelNameUWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apModelNameUWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apModelNameUWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apModelNameUWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apModelNameUWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apModelNameUWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apModelNameUWork.LogicalDeleteCode);
            paraModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(apModelNameUWork.ModelUniqueCode);
            paraMakerCode.Value = SqlDataMediator.SqlSetInt32(apModelNameUWork.MakerCode);
            paraModelCode.Value = SqlDataMediator.SqlSetInt32(apModelNameUWork.ModelCode);
            paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(apModelNameUWork.ModelSubCode);
            paraModelFullName.Value = SqlDataMediator.SqlSetString(apModelNameUWork.ModelFullName);
            paraModelHalfName.Value = SqlDataMediator.SqlSetString(apModelNameUWork.ModelHalfName);
            paraModelAliasName.Value = SqlDataMediator.SqlSetString(apModelNameUWork.ModelAliasName);
            paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apModelNameUWork.OfferDate);
            paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(apModelNameUWork.OfferDataDiv);

            // �Ԏ햼�̃}�X�^�i���[�U�[�o�^�j�f�[�^��o�^����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion
    }
}






