//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   �}�X�^����M�����@                           �@ //
// Name Space       :   Broadleaf.Application.Remoting           	    //
//                  :   PMKYO06490R.DLL							        //
// Programmer       :   ������	                                        //
// Date             :   2009.04.30                                      //
//----------------------------------------------------------------------//
// Update Note      :   ���仁@2009.06.12�@							//
//                  :   public Method��SQL�������ʖڑΉ��ɂ���        //
//----------------------------------------------------------------------//
// Update Note      :   �������@2011.07.26�@							//
//                  :   SCM�Ή�-���_�Ǘ��i10704767-00�j                 //
//----------------------------------------------------------------------//
// Update Note      :   �g���Y�@2011.08.20�@							//
//                  :   myReader����D�N���X�֍��ړ]�L���s���Ă����   //
//                  :   �̓��\�b�h������                                //
//----------------------------------------------------------------------//
// Update Note      :   ���仁@2011.08.26�@							//
//                  :   DC�������O��DC�e�f�[�^�̃N���A������ǉ�        //
//----------------------------------------------------------------------//
// Update Note      :   �������@2011.09.08�@							//
//                  :   #23777 �\�[�X���r���[                           //
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
    /// �������i�}�X�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������i�}�X�^�f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCIsolIslandPrcDB : RemoteDB
    {
        /// <summary>
        /// �������i�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCIsolIslandPrcDB()
            : base("PMKYO06491D", "Broadleaf.Application.Remoting.ParamData.DCIsolIslandPrcWork", "ISOLISLANDPRCRF")
        {

        }

        #region [Read]
        /// <summary>
        /// �������i�}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="isolIslandPrcArrList">�������i�}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �������i�}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchIsolIslandPrc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList isolIslandPrcArrList, out string retMessage)
        {
            return SearchIsolIslandPrcProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                                      sqlTransaction, out isolIslandPrcArrList, out retMessage);
        }
        /// <summary>
        /// �������i�}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="isolIslandPrcArrList">�������i�}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �������i�}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchIsolIslandPrcProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList isolIslandPrcArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            isolIslandPrcArrList = new ArrayList();
            DCIsolIslandPrcWork isolIslandPrcWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, MAKERCODERF, UPPERLIMITPRICERF, FRACTIONPROCUNITRF, FRACTIONPROCCDRF, UPRATERF FROM ISOLISLANDPRCRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //�������i�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    isolIslandPrcWork = new DCIsolIslandPrcWork();

                    isolIslandPrcWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    isolIslandPrcWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    isolIslandPrcWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    isolIslandPrcWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    isolIslandPrcWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    isolIslandPrcWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    isolIslandPrcWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    isolIslandPrcWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    isolIslandPrcWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    isolIslandPrcWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    isolIslandPrcWork.UpperLimitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPPERLIMITPRICERF"));
                    isolIslandPrcWork.FractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF"));
                    isolIslandPrcWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
                    isolIslandPrcWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));


                    isolIslandPrcArrList.Add(isolIslandPrcWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCIsolIslandPrcDB.SearchIsolIslandPrc Exception=" + ex.Message);
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
        ///  �������i�}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="dcIsolIslandPrcWork">�������i�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �������i�}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(DCIsolIslandPrcWork dcIsolIslandPrcWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcIsolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  �������i�}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="dcIsolIslandPrcWork">�������i�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �������i�}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(DCIsolIslandPrcWork dcIsolIslandPrcWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM ISOLISLANDPRCRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAKERCODERF=@FINDMAKERCODE AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            SqlParameter findParaMakerCode = sqlCommand.Parameters.Add("@FINDMAKERCODE", SqlDbType.Int);
            SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = dcIsolIslandPrcWork.EnterpriseCode;
            findParaSectionCode.Value = dcIsolIslandPrcWork.SectionCode;
            findParaMakerCode.Value = dcIsolIslandPrcWork.MakerCode;
            findParaUpperLimitPrice.Value = dcIsolIslandPrcWork.UpperLimitPrice;


            // �������i�}�X�^�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// �������i�}�X�^�o�^
        /// </summary>
        /// <param name="dcIsolIslandPrcWork">�������i�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �������i�}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(DCIsolIslandPrcWork dcIsolIslandPrcWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcIsolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// �������i�}�X�^�o�^
        /// </summary>
        /// <param name="dcIsolIslandPrcWork">�������i�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �������i�}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(DCIsolIslandPrcWork dcIsolIslandPrcWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "INSERT INTO ISOLISLANDPRCRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, MAKERCODERF, UPPERLIMITPRICERF, FRACTIONPROCUNITRF, FRACTIONPROCCDRF, UPRATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @MAKERCODE, @UPPERLIMITPRICE, @FRACTIONPROCUNIT, @FRACTIONPROCCD, @UPRATE)";

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
            SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
            SqlParameter paraUpperLimitPrice = sqlCommand.Parameters.Add("@UPPERLIMITPRICE", SqlDbType.Float);
            SqlParameter paraFractionProcUnit = sqlCommand.Parameters.Add("@FRACTIONPROCUNIT", SqlDbType.Float);
            SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
            SqlParameter paraUpRate = sqlCommand.Parameters.Add("@UPRATE", SqlDbType.Float);


            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcIsolIslandPrcWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcIsolIslandPrcWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcIsolIslandPrcWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcIsolIslandPrcWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcIsolIslandPrcWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcIsolIslandPrcWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcIsolIslandPrcWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcIsolIslandPrcWork.LogicalDeleteCode);
            if (string.IsNullOrEmpty(dcIsolIslandPrcWork.SectionCode.Trim()))
            {
                paraSectionCode.Value = dcIsolIslandPrcWork.SectionCode;
            }
            else
            {
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcIsolIslandPrcWork.SectionCode);
            }
            paraMakerCode.Value = SqlDataMediator.SqlSetInt32(dcIsolIslandPrcWork.MakerCode);
            paraUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(dcIsolIslandPrcWork.UpperLimitPrice);
            paraFractionProcUnit.Value = SqlDataMediator.SqlSetDouble(dcIsolIslandPrcWork.FractionProcUnit);
            paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(dcIsolIslandPrcWork.FractionProcCd);
            paraUpRate.Value = SqlDataMediator.SqlSetDouble(dcIsolIslandPrcWork.UpRate);


            // �������i�}�X�^�f�[�^��o�^����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region 2011/07/26 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j
        #region [Read]
        #region DEL 2011/09/08 sundx #23777 �\�[�X���r���[
        ///// <summary>
        ///// �������i�}�X�^�̌�������
        ///// </summary>
        ///// <param name="enterpriseCodes">��ƃR�[�h</param>
        ///// <param name="paramList">��������</param>
        ///// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        ///// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        ///// <param name="isolIslandPrcArrList">�������i�}�X�^�f�[�^�I�u�W�F�N�g</param>
        ///// <param name="retMessage">�߂郁�b�Z�[�W</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : �������i�}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2011.07.26</br>
        //public int SearchIsolIslandPrc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList isolIslandPrcArrList, out string retMessage)
        //{
        //    return SearchIsolIslandPrcProc(enterpriseCodes, paramList, sqlConnection,
        //                              sqlTransaction, out isolIslandPrcArrList, out retMessage);
        //}
        ///// <summary>
        ///// �������i�}�X�^�̌�������
        ///// </summary>
        ///// <param name="enterpriseCodes">��ƃR�[�h</param>
        ///// <param name="paramList">��������</param>
        ///// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        ///// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        ///// <param name="isolIslandPrcArrList">�������i�}�X�^�f�[�^�I�u�W�F�N�g</param>
        ///// <param name="retMessage">�߂郁�b�Z�[�W</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : �������i�}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2011.07.26</br>
        //private int SearchIsolIslandPrcProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList isolIslandPrcArrList, out string retMessage)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    isolIslandPrcArrList = new ArrayList();
        //    //DCIsolIslandPrcWork isolIslandPrcWork = null;//DEL 2011/08/20 �r���[�i�`�F�b�N
        //    retMessage = string.Empty;
        //    string sqlStr = string.Empty;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;
        //    GoodsProcParamWork param = paramList as GoodsProcParamWork;

        //    try
        //    {
        //        sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //        sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, MAKERCODERF, UPPERLIMITPRICERF, FRACTIONPROCUNITRF, FRACTIONPROCCDRF, UPRATERF FROM ISOLISLANDPRCRF ";
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
        //        if (param.GoodsMakerCdBeginRF != 0)
        //        {
        //            sqlStr += " AND MAKERCODERF >= @GOODSMAKERCDBEGINRF";
        //            SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
        //            goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
        //        }

        //        if (param.GoodsMakerCdEndRF != 0)
        //        {
        //            sqlStr += " AND MAKERCODERF <= @GOODSMAKERCDENDRF";
        //            SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
        //            goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
        //        }

        //        //Prameter�I�u�W�F�N�g�̍쐬
        //        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

        //        //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);

        //        //�������i�}�X�^�f�[�^�pSQL
        //        sqlCommand.CommandText = sqlStr;

        //        // �ǂݍ���
        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            #region DEL
        //            //-----DEL 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)----->>>>>
        //            //isolIslandPrcWork = new DCIsolIslandPrcWork();

        //            //isolIslandPrcWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //            //isolIslandPrcWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //            //isolIslandPrcWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //            //isolIslandPrcWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //            //isolIslandPrcWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //            //isolIslandPrcWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //            //isolIslandPrcWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //            //isolIslandPrcWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //            //isolIslandPrcWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
        //            //isolIslandPrcWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
        //            //isolIslandPrcWork.UpperLimitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPPERLIMITPRICERF"));
        //            //isolIslandPrcWork.FractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF"));
        //            //isolIslandPrcWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
        //            //isolIslandPrcWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));


        //            //isolIslandPrcArrList.Add(isolIslandPrcWork);
        //            //-----DEL 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)-----<<<<<
        //            #endregion DEL
        //            isolIslandPrcArrList.Add(CopyFromMyReaderToDCIsolIslandPrcWork(myReader));//ADD 2011/08/20 �r���[�i�`�F�b�N
        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        base.WriteErrorLog(ex, "DCIsolIslandPrcDB.SearchIsolIslandPrc Exception=" + ex.Message);
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
        ///// �������i�}�X�^�f�[�^���擾
        ///// </summary>
        ///// <param name="myReader">SqlDataReader</param>
        ///// <returns>�������i�}�X�^�f�[�^</returns>
        ///// <br>Note       : �������i�}�X�^�f�[�^��߂��܂�</br>
        ///// <br>Programmer : �g���Y</br>
        ///// <br>Date       : 2011/08/20</br>
        //private DCIsolIslandPrcWork CopyFromMyReaderToDCIsolIslandPrcWork(SqlDataReader myReader)
        //{
        //    DCIsolIslandPrcWork isolIslandPrcWork = new DCIsolIslandPrcWork();

        //    isolIslandPrcWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //    isolIslandPrcWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //    isolIslandPrcWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //    isolIslandPrcWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //    isolIslandPrcWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //    isolIslandPrcWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //    isolIslandPrcWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //    isolIslandPrcWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //    isolIslandPrcWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
        //    isolIslandPrcWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
        //    isolIslandPrcWork.UpperLimitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPPERLIMITPRICERF"));
        //    isolIslandPrcWork.FractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF"));
        //    isolIslandPrcWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
        //    isolIslandPrcWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));

        //    return isolIslandPrcWork;
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
			sqlCommand.CommandText = "DELETE FROM ISOLISLANDPRCRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
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