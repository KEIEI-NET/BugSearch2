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
// �Ǘ��ԍ�              �C���S�� : FSI�� ���j
// �C �� ��  2012/07/26  �C�����e : ���_�Ǘ� ���o�����ǉ��Ή�
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
    /// ���[�U�[�K�C�h�}�X�^READDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�U�[�K�C�h�}�X�^����READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APUserGdBdUDB : RemoteDB
    {
        #region [Private]
        // --- ADD 2012/07/26 -------->>>>>
        private int _CreateDateTime = 0;
        private int _UpdateDateTime = 0;
        private int _EnterpriseCode = 0;
        private int _FileHeaderGuid = 0;
        private int _UpdEmployeeCode = 0;
        private int _UpdAssemblyId1 = 0;
        private int _UpdAssemblyId2 = 0;
        private int _LogicalDeleteCode = 0;
        private int _UserGuideDivCd = 0;
        private int _GuideCode = 0;
        private int _GuideName = 0;
        private int _GuideType = 0;
        // --- ADD 2012/07/26 --------<<<<<
        #endregion

        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^READDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APUserGdBdUDB()
            : base("PMKYO06201D", "Broadleaf.Application.Remoting.ParamData.APUserGdBdUWork", "USERGDBDURF")
        {

        }

        #region [Read]
        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�̌��������i���t�w��j
        /// </summary>
        /// <param name="kubun">���[�U�[�K�C�h�敪</param>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="userGdBdUArrList">���[�U�[�K�C�h�}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchUserGdBdU(Int32 kubun, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
           SqlTransaction sqlTransaction, ref ArrayList userGdBdUArrList, out string retMessage)
        {
            return SearchUserGdBdUProc(kubun, enterpriseCodes, beginningDate, endingDate, sqlConnection,
                             sqlTransaction, ref userGdBdUArrList, out retMessage);
        }
        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�̌��������i���t�w��j
        /// </summary>
        /// <param name="kubun">���[�U�[�K�C�h�敪</param>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="userGdBdUArrList">���[�U�[�K�C�h�}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchUserGdBdUProc(Int32 kubun, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, ref ArrayList userGdBdUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            APUserGdBdUWork userGdBdUWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, USERGUIDEDIVCDRF, GUIDECODERF, GUIDENAMERF, GUIDETYPERF FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCDRF AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUserGuideDivCd = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCDRF", SqlDbType.Int);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(kubun);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //���[�U�[�K�C�h�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    userGdBdUWork = new APUserGdBdUWork();

                    userGdBdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    userGdBdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    userGdBdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    userGdBdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    userGdBdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    userGdBdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    userGdBdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    userGdBdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    userGdBdUWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    userGdBdUWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));
                    userGdBdUWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                    userGdBdUWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDETYPERF"));

                    userGdBdUArrList.Add(userGdBdUWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APUserGdBdUDB.SearchUserGdBdU Exception=" + ex.Message);
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
        /// ���[�U�[�K�C�h�}�X�^�̌v����������
        /// </summary>
        /// <param name="userGdBdUWork">�����I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^�v����S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchUserGdBdUCount(APUserGdBdUWork userGdBdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            return SearchUserGdBdUCountProc(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�̌v����������
        /// </summary>
        /// <param name="userGdBdUWork">�����I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^�v����S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br>
        private int SearchUserGdBdUCountProc(APUserGdBdUWork userGdBdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUserGuideDivCd = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
                SqlParameter findParaGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(userGdBdUWork.EnterpriseCode);
                findParaUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGdBdUWork.UserGuideDivCd);
                findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(userGdBdUWork.GuideCode);

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
        ///  ���[�U�[�K�C�h�}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="apUserGdBdUWork">���[�U�[�K�C�h�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Delete(APUserGdBdUWork apUserGdBdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(apUserGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  ���[�U�[�K�C�h�}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="apUserGdBdUWork">���[�U�[�K�C�h�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        private void DeleteProc(APUserGdBdUWork apUserGdBdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE";
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaUserGuideDivCd = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
            SqlParameter findParaGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = apUserGdBdUWork.EnterpriseCode;
            findParaUserGuideDivCd.Value = apUserGdBdUWork.UserGuideDivCd;
            findParaGuideCode.Value = apUserGdBdUWork.GuideCode;


            // ���[�U�[�K�C�h�}�X�^�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�o�^
        /// </summary>
        /// <param name="apUserGdBdUWork">���[�U�[�K�C�h�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Insert(APUserGdBdUWork apUserGdBdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(apUserGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�o�^
        /// </summary>
        /// <param name="apUserGdBdUWork">���[�U�[�K�C�h�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        private void InsertProc(APUserGdBdUWork apUserGdBdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "INSERT INTO USERGDBDURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, USERGUIDEDIVCDRF, GUIDECODERF, GUIDENAMERF, GUIDETYPERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @USERGUIDEDIVCD, @GUIDECODE, @GUIDENAME, @GUIDETYPE)";

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);
            SqlParameter paraGuideCode = sqlCommand.Parameters.Add("@GUIDECODE", SqlDbType.Int);
            SqlParameter paraGuideName = sqlCommand.Parameters.Add("@GUIDENAME", SqlDbType.NVarChar);
            SqlParameter paraGuideType = sqlCommand.Parameters.Add("@GUIDETYPE", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apUserGdBdUWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apUserGdBdUWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apUserGdBdUWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apUserGdBdUWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apUserGdBdUWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apUserGdBdUWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apUserGdBdUWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apUserGdBdUWork.LogicalDeleteCode);
            paraUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(apUserGdBdUWork.UserGuideDivCd);
            paraGuideCode.Value = SqlDataMediator.SqlSetInt32(apUserGdBdUWork.GuideCode);
            paraGuideName.Value = SqlDataMediator.SqlSetString(apUserGdBdUWork.GuideName);
            paraGuideType.Value = SqlDataMediator.SqlSetInt32(apUserGdBdUWork.GuideType);

            // ���[�U�[�K�C�h�}�X�^�f�[�^��o�^����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region [Read][���_�Ǘ� ���o�����ǉ��Ή�]
        // --- ADD 2012/07/26 ------------------------------------->>>>>
        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�̌��������i�R�[�h�w��j
        /// </summary>
        /// <param name="kubun">���[�U�[�K�C�h�敪</param>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="paramList">��������</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="userGdBdUArrList">���[�U�[�K�C�h�}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : FSI�� ���j</br>
        /// <br>Date       : 2012/07/26</br>
        public int SearchUserGdBdU(Int32 kubun, string enterpriseCodes, object paramList, SqlConnection sqlConnection,
           SqlTransaction sqlTransaction, out ArrayList userGdBdUArrList, out string retMessage)
        {
            return SearchUserGdBdUProc(kubun, enterpriseCodes, paramList, sqlConnection,
                             sqlTransaction, out userGdBdUArrList, out retMessage);
        }

        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�̌��������i�R�[�h�w��j
        /// </summary>
        /// <param name="kubun">���[�U�[�K�C�h�敪</param>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="paramList">��������</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="userGdBdUArrList">���[�U�[�K�C�h�}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : FSI�� ���j</br>
        /// <br>Date       : 2012/07/26</br>
        private int SearchUserGdBdUProc(Int32 kubun, string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList userGdBdUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            userGdBdUArrList = new ArrayList();
            retMessage = string.Empty;
            StringBuilder sqlStr = new StringBuilder();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr.AppendLine("SELECT");
                sqlStr.AppendLine("    CREATEDATETIMERF,");
                sqlStr.AppendLine("    UPDATEDATETIMERF,");
                sqlStr.AppendLine("    ENTERPRISECODERF,");
                sqlStr.AppendLine("    FILEHEADERGUIDRF,");
                sqlStr.AppendLine("    UPDEMPLOYEECODERF,");
                sqlStr.AppendLine("    UPDASSEMBLYID1RF,");
                sqlStr.AppendLine("    UPDASSEMBLYID2RF,");
                sqlStr.AppendLine("    LOGICALDELETECODERF,");
                sqlStr.AppendLine("    USERGUIDEDIVCDRF,");
                sqlStr.AppendLine("    GUIDECODERF,");
                sqlStr.AppendLine("    GUIDENAMERF,");
                sqlStr.AppendLine("    GUIDETYPERF");
                sqlStr.AppendLine("FROM");
                sqlStr.AppendLine("    USERGDBDURF");
                sqlStr.AppendLine("WHERE");
                sqlStr.AppendLine("        ENTERPRISECODERF = @FINDENTERPRISECODE");
                sqlStr.AppendLine("    AND USERGUIDEDIVCDRF = @FINDUSERGUIDEDIVCDRF");

                if (kubun == 71)
                {
                    // �̔��敪
                    APUserGdBuyDivUProcParamWork param = paramList as APUserGdBuyDivUProcParamWork;

                    if (param.UpdateDateTimeBegin != 0)
                    {
                        sqlStr.AppendLine("    AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                        SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                        findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                    }

                    if (param.UpdateDateTimeEnd != 0)
                    {
                        sqlStr.AppendLine("    AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                        SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                        findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                    }

                    // �K�C�h�R�[�h
                    if (param.GuideCodeBeginRF != 0)
                    {
                        sqlStr.AppendLine("    AND GUIDECODERF >= @GUIDECODEBEGINRF");
                        SqlParameter guideCodeBeginRF = sqlCommand.Parameters.Add("@GUIDECODEBEGINRF", SqlDbType.Int);
                        guideCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GuideCodeBeginRF);
                    }

                    if (param.GuideCodeEndRF != 0)
                    {
                        sqlStr.AppendLine("    AND GUIDECODERF <= @GUIDECODEENDRF");
                        SqlParameter guideCodeEndRF = sqlCommand.Parameters.Add("@GUIDECODEENDRF", SqlDbType.Int);
                        guideCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.GuideCodeEndRF);
                    }
                }
                else
                {
                    // ���������͎��s���Ȃ�
                    return status;
                }


                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUserGuideDivCd = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCDRF", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(kubun);

                //���[�U�[�K�C�h�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr.ToString();
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    SetIndex(myReader);
                }

                while (myReader.Read())
                {
                    userGdBdUArrList.Add(CopyFromMyReaderToAPUserGdBdUWork(myReader));
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APUserGdBdUDB.SearchUserGdBdU Exception=" + ex.Message);
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
        /// <br>Programmer : FSI�� ���j</br>
        /// <br>Date       : 2012/07/26</br>
        /// </remarks>
        private void SetIndex(SqlDataReader myReader)
        {
            _CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
            _UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
            _EnterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
            _FileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
            _UpdEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
            _UpdAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
            _UpdAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
            _LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
            _UserGuideDivCd = myReader.GetOrdinal("USERGUIDEDIVCDRF");
            _GuideCode = myReader.GetOrdinal("GUIDECODERF");
            _GuideName = myReader.GetOrdinal("GUIDENAMERF");
            _GuideType = myReader.GetOrdinal("GUIDETYPERF");
        }

        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�f�[�^���擾
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>���[�U�[�K�C�h�}�X�^�f�[�^</returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^�f�[�^��߂��܂�</br>
        /// <br>Programmer : FSI�� ���j</br>
        /// <br>Date       : K2012/07/02</br>
        private APUserGdBdUWork CopyFromMyReaderToAPUserGdBdUWork(SqlDataReader myReader)
        {
            APUserGdBdUWork userGdBdUWork = new APUserGdBdUWork();

            userGdBdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _CreateDateTime);
            userGdBdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _UpdateDateTime);
            userGdBdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _EnterpriseCode);
            userGdBdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _FileHeaderGuid);
            userGdBdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _UpdEmployeeCode);
            userGdBdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _UpdAssemblyId1);
            userGdBdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _UpdAssemblyId2);
            userGdBdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _LogicalDeleteCode);
            userGdBdUWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, _UserGuideDivCd);
            userGdBdUWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, _GuideCode);
            userGdBdUWork.GuideName = SqlDataMediator.SqlGetString(myReader, _GuideName);
            userGdBdUWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, _GuideType);

            return userGdBdUWork;
        }
        // --- ADD 2012/07/26 -------------------------------------<<<<<
        #endregion
    }
}



