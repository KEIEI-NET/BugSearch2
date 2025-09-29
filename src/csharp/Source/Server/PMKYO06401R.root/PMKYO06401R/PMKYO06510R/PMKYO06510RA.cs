//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   �}�X�^����M����                          �@�@  //
// Name Space       :   Broadleaf.Application.Remoting           	    //
//                  :   PMKYO06510R.DLL							        //
// Programmer       :   ������	                                        //
// Date             :   2009.04.30                                      //
//----------------------------------------------------------------------//
// Update Note      :   ���仁@2009.06.12�@							//
//                  :   public Method��SQL�������ʖڑΉ��ɂ���        //
//----------------------------------------------------------------------//
// Update Note      :   ���仁@2011.08.26�@							//
//                  :   DC�������O��DC�e�f�[�^�̃N���A������ǉ�        //
//----------------------------------------------------------------------//
// Update Note      :   FSI�� ���j�@2012.07.26�@						//
//                  :   ���_�Ǘ� ���o�����ǉ��Ή�                       //
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
    /// ���[�U�[�K�C�h�}�X�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�U�[�K�C�h�}�X�^�f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCUserGdBdUDB : RemoteDB
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
        /// ���[�U�[�K�C�h�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCUserGdBdUDB()
            : base("PMKYO06511D", "Broadleaf.Application.Remoting.ParamData.DCUserGdBdUWork", "USERGDBDURF")
        {

        }

        #region [Read]
        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�̌��������i���t�w��j
        /// </summary>
        /// <param name="kubun">�敪</param>
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
        /// <param name="kubun">�敪</param>
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
            DCUserGdBdUWork userGdBdUWork = null;
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
                    userGdBdUWork = new DCUserGdBdUWork();

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
                base.WriteErrorLog(ex, "DCUserGdBdUDB.SearchUserGdBdU Exception=" + ex.Message);
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
        ///  ���[�U�[�K�C�h�}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="dcUserGdBdUWork">���[�U�[�K�C�h�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Delete(DCUserGdBdUWork dcUserGdBdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcUserGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  ���[�U�[�K�C�h�}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="dcUserGdBdUWork">���[�U�[�K�C�h�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        private void DeleteProc(DCUserGdBdUWork dcUserGdBdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE";
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaUserGuideDivCd = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
            SqlParameter findParaGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = dcUserGdBdUWork.EnterpriseCode;
            findParaUserGuideDivCd.Value = dcUserGdBdUWork.UserGuideDivCd;
            findParaGuideCode.Value = dcUserGdBdUWork.GuideCode;


            // ���[�U�[�K�C�h�}�X�^�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�o�^
        /// </summary>
        /// <param name="dcUserGdBdUWork">���[�U�[�K�C�h�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Insert(DCUserGdBdUWork dcUserGdBdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcUserGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�o�^
        /// </summary>
        /// <param name="dcUserGdBdUWork">���[�U�[�K�C�h�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        private void InsertProc(DCUserGdBdUWork dcUserGdBdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
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
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcUserGdBdUWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcUserGdBdUWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcUserGdBdUWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcUserGdBdUWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcUserGdBdUWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcUserGdBdUWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcUserGdBdUWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcUserGdBdUWork.LogicalDeleteCode);
            paraUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(dcUserGdBdUWork.UserGuideDivCd);
            paraGuideCode.Value = SqlDataMediator.SqlSetInt32(dcUserGdBdUWork.GuideCode);
            paraGuideName.Value = SqlDataMediator.SqlSetString(dcUserGdBdUWork.GuideName);
            paraGuideType.Value = SqlDataMediator.SqlSetInt32(dcUserGdBdUWork.GuideType);

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
                    UserGdBuyDivUProcParamWork param = paramList as UserGdBuyDivUProcParamWork;

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
                    userGdBdUArrList.Add(CopyFromMyReaderToDCUserGdBdUWork(myReader));
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCUserGdBdUDB.SearchUserGdBdU Exception=" + ex.Message);
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
        private DCUserGdBdUWork CopyFromMyReaderToDCUserGdBdUWork(SqlDataReader myReader)
        {
            DCUserGdBdUWork userGdBdUWork = new DCUserGdBdUWork();

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
        //    sqlCommand.CommandText = "DELETE FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
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