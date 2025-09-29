//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   �}�X�^����M�����@                           �@ //
// Name Space       :   Broadleaf.Application.Remoting           	    //
//                  :   PMKYO06410R.DLL							        //
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
    /// ���_���ݒ�}�X�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���_���ݒ�}�X�^�f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCSecInfoSetDB : RemoteDB
    {
        /// <summary>
        /// ���_���ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCSecInfoSetDB()
            : base("PMKYO06411D", "Broadleaf.Application.Remoting.ParamData.DCSecInfoSetWork", "SECINFOSETRF")
        {

        }

        # region [Read]
        /// <summary>
        /// ���_���ݒ�}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="secInfoSetArrList">���_���ݒ�}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_���ݒ�}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchSecInfoSet(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
           SqlTransaction sqlTransaction, out ArrayList secInfoSetArrList, out string retMessage)
        {
            return SearchSecInfoSetProc(enterpriseCodes, beginningDate,  endingDate,  sqlConnection,
                              sqlTransaction, out secInfoSetArrList, out retMessage);
        }

        /// <summary>
        /// ���_���ݒ�}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="secInfoSetArrList">���_���ݒ�}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_���ݒ�}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br>
        private int SearchSecInfoSetProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList secInfoSetArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            secInfoSetArrList = new ArrayList();
            DCSecInfoSetWork secInfoSetWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SECTIONGUIDENMRF, SECTIONGUIDESNMRF, COMPANYNAMECD1RF, MAINOFFICEFUNCFLAGRF, INTRODUCTIONDATERF, SECTWAREHOUSECD1RF, SECTWAREHOUSECD2RF, SECTWAREHOUSECD3RF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // ���_���ݒ�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    secInfoSetWork = new DCSecInfoSetWork();

                    secInfoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    secInfoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    secInfoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    secInfoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    secInfoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    secInfoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    secInfoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    secInfoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    secInfoSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    secInfoSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    secInfoSetWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    secInfoSetWork.CompanyNameCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECD1RF"));
                    secInfoSetWork.MainOfficeFuncFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINOFFICEFUNCFLAGRF"));
                    secInfoSetWork.IntroductionDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INTRODUCTIONDATERF"));
                    secInfoSetWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD1RF"));
                    secInfoSetWork.SectWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD2RF"));
                    secInfoSetWork.SectWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD3RF"));

                    secInfoSetArrList.Add(secInfoSetWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCSecInfoSetDB.SearchSecInfoSet Exception=" + ex.Message);
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
        ///  ���_���ݒ�}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="dcSecInfoSetWork">���_���ݒ�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���_���ݒ�}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br> 
        public void Delete(DCSecInfoSetWork dcSecInfoSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcSecInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  ���_���ݒ�}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="dcSecInfoSetWork">���_���ݒ�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���_���ݒ�}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br> 
        private void DeleteProc(DCSecInfoSetWork dcSecInfoSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = dcSecInfoSetWork.EnterpriseCode;
            findParaSectionCode.Value = dcSecInfoSetWork.SectionCode;


            // ���_���ݒ�}�X�^�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// ���_���ݒ�}�X�^�o�^
        /// </summary>
        /// <param name="dcSecInfoSetWork">���_���ݒ�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���_���ݒ�}�X�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br> 
        public void Insert(DCSecInfoSetWork dcSecInfoSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcSecInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���_���ݒ�}�X�^�o�^
        /// </summary>
        /// <param name="dcSecInfoSetWork">���_���ݒ�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���_���ݒ�}�X�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br> 
        private void InsertProc(DCSecInfoSetWork dcSecInfoSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "INSERT INTO SECINFOSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SECTIONGUIDENMRF, SECTIONGUIDESNMRF, COMPANYNAMECD1RF, MAINOFFICEFUNCFLAGRF, INTRODUCTIONDATERF, SECTWAREHOUSECD1RF, SECTWAREHOUSECD2RF, SECTWAREHOUSECD3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @SECTIONGUIDENM, @SECTIONGUIDESNM, @COMPANYNAMECD1, @MAINOFFICEFUNCFLAG, @INTRODUCTIONDATE, @SECTWAREHOUSECD1, @SECTWAREHOUSECD2, @SECTWAREHOUSECD3)";

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
            SqlParameter paraSectionGuideNm = sqlCommand.Parameters.Add("@SECTIONGUIDENM", SqlDbType.NVarChar);
            SqlParameter paraSectionGuideSnm = sqlCommand.Parameters.Add("@SECTIONGUIDESNM", SqlDbType.NVarChar);
            SqlParameter paraCompanyNameCd1 = sqlCommand.Parameters.Add("@COMPANYNAMECD1", SqlDbType.Int);
            SqlParameter paraMainOfficeFuncFlag = sqlCommand.Parameters.Add("@MAINOFFICEFUNCFLAG", SqlDbType.Int);
            SqlParameter paraIntroductionDate = sqlCommand.Parameters.Add("@INTRODUCTIONDATE", SqlDbType.Int);
            SqlParameter paraSectWarehouseCd1 = sqlCommand.Parameters.Add("@SECTWAREHOUSECD1", SqlDbType.NChar);
            SqlParameter paraSectWarehouseCd2 = sqlCommand.Parameters.Add("@SECTWAREHOUSECD2", SqlDbType.NChar);
            SqlParameter paraSectWarehouseCd3 = sqlCommand.Parameters.Add("@SECTWAREHOUSECD3", SqlDbType.NChar);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcSecInfoSetWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcSecInfoSetWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcSecInfoSetWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcSecInfoSetWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcSecInfoSetWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcSecInfoSetWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcSecInfoSetWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcSecInfoSetWork.LogicalDeleteCode);
            if (string.IsNullOrEmpty(dcSecInfoSetWork.SectionCode.Trim()))
            {
                paraSectionCode.Value = dcSecInfoSetWork.SectionCode;
            }
            else
            {
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcSecInfoSetWork.SectionCode);
            }
            if (string.IsNullOrEmpty(dcSecInfoSetWork.SectionGuideNm.Trim()))
            {
                paraSectionGuideNm.Value = dcSecInfoSetWork.SectionGuideNm;
            }
            else
            {
                paraSectionGuideNm.Value = SqlDataMediator.SqlSetString(dcSecInfoSetWork.SectionGuideNm);
            }
            if (string.IsNullOrEmpty(dcSecInfoSetWork.SectionGuideSnm.Trim()))
            {
                paraSectionGuideSnm.Value = dcSecInfoSetWork.SectionGuideSnm;
            }
            else
            {
                paraSectionGuideSnm.Value = SqlDataMediator.SqlSetString(dcSecInfoSetWork.SectionGuideSnm);
            }
            paraCompanyNameCd1.Value = SqlDataMediator.SqlSetInt32(dcSecInfoSetWork.CompanyNameCd1);
            paraMainOfficeFuncFlag.Value = SqlDataMediator.SqlSetInt32(dcSecInfoSetWork.MainOfficeFuncFlag);
            paraIntroductionDate.Value = SqlDataMediator.SqlSetInt32(dcSecInfoSetWork.IntroductionDate);
            paraSectWarehouseCd1.Value = SqlDataMediator.SqlSetString(dcSecInfoSetWork.SectWarehouseCd1);
            paraSectWarehouseCd2.Value = SqlDataMediator.SqlSetString(dcSecInfoSetWork.SectWarehouseCd2);
            paraSectWarehouseCd3.Value = SqlDataMediator.SqlSetString(dcSecInfoSetWork.SectWarehouseCd3);


            // ���_���ݒ�}�X�^�f�[�^��o�^����
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
        //    sqlCommand.CommandText = "DELETE FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
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