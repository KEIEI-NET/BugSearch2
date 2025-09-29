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
// �Ǘ��ԍ�              �C���S�� : 杍^
// �C �� ��  2009/06/24  �C�����e : PVCS#243 �}�X�^����M�����ɂ��� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/07/26  �C�����e : SCM�Ή�-���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : �g���Y
// �C �� ��  2011/08/20  �C�����e : myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������
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
    /// �|���D��Ǘ��}�X�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���D��Ǘ��}�X�^�f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCRateProtyMngDB : RemoteDB
    {
        /// <summary>
        /// �|���D��Ǘ��}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCRateProtyMngDB()
            : base("PMKYO06521D", "Broadleaf.Application.Remoting.ParamData.DCRateProtyMngWork", "RATEPROTYMNGRF")
        {

        }

        #region [Read]
        /// <summary>
        /// �|���D��Ǘ��}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="rateProtyMngArrList">�|���D��Ǘ��}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���D��Ǘ��}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchRateProtyMng(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList rateProtyMngArrList, out string retMessage)
        {
            return SearchRateProtyMngProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                               sqlTransaction, out rateProtyMngArrList, out retMessage);
        }
        /// <summary>
        /// �|���D��Ǘ��}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="rateProtyMngArrList">�|���D��Ǘ��}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���D��Ǘ��}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchRateProtyMngProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList rateProtyMngArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            rateProtyMngArrList = new ArrayList();
            DCRateProtyMngWork rateProtyMngWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, UNITPRICEKINDRF, RATESETTINGDIVIDERF, RATEPRIORITYORDERRF, RATEMNGGOODSCDRF, RATEMNGGOODSNMRF, RATEMNGCUSTCDRF, RATEMNGCUSTNMRF FROM RATEPROTYMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";

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
                //�|���D��Ǘ��}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    rateProtyMngWork = new DCRateProtyMngWork();

                    rateProtyMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    rateProtyMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    rateProtyMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    rateProtyMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    rateProtyMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    rateProtyMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    rateProtyMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    rateProtyMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    rateProtyMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    rateProtyMngWork.UnitPriceKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
                    rateProtyMngWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
                    rateProtyMngWork.RatePriorityOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEPRIORITYORDERRF"));
                    rateProtyMngWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
                    rateProtyMngWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
                    rateProtyMngWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
                    rateProtyMngWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
                    rateProtyMngArrList.Add(rateProtyMngWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCRateProtyMngDB.SearchRateProtyMng Exception=" + ex.Message);
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
        ///  �|���D��Ǘ��}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="dcRateProtyMngWork">�|���D��Ǘ��}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �|���D��Ǘ��}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(DCRateProtyMngWork dcRateProtyMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcRateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  �|���D��Ǘ��}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="dcRateProtyMngWork">�|���D��Ǘ��}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �|���D��Ǘ��}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(DCRateProtyMngWork dcRateProtyMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM RATEPROTYMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            // MOD 2009/06/24 --->>>
            //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            //SqlParameter findParaUnitPriceKind = sqlCommand.Parameters.Add("@FINDUNITPRICEKIND", SqlDbType.Int);
            // MOD 2009/06/24 ---<<<
            //SqlParameter findParaRateSettingDivide = sqlCommand.Parameters.Add("@FINDRATESETTINGDIVIDE", SqlDbType.NChar);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = dcRateProtyMngWork.EnterpriseCode;
            // MOD 2009/06/24 --->>>
            //findParaSectionCode.Value = dcRateProtyMngWork.SectionCode;
            //findParaUnitPriceKind.Value = dcRateProtyMngWork.UnitPriceKind;
            // MOD 2009/06/24 ---<<<
            //findParaRateSettingDivide.Value = dcRateProtyMngWork.RateSettingDivide;


            // �|���D��Ǘ��}�X�^�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// �|���D��Ǘ��}�X�^�o�^
        /// </summary>
        /// <param name="dcRateProtyMngWork">�|���D��Ǘ��}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �|���D��Ǘ��}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(DCRateProtyMngWork dcRateProtyMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcRateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// �|���D��Ǘ��}�X�^�o�^
        /// </summary>
        /// <param name="dcRateProtyMngWork">�|���D��Ǘ��}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �|���D��Ǘ��}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(DCRateProtyMngWork dcRateProtyMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "INSERT INTO RATEPROTYMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, UNITPRICEKINDRF, RATESETTINGDIVIDERF, RATEPRIORITYORDERRF, RATEMNGGOODSCDRF, RATEMNGGOODSNMRF, RATEMNGCUSTCDRF, RATEMNGCUSTNMRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @UNITPRICEKIND, @RATESETTINGDIVIDE, @RATEPRIORITYORDER, @RATEMNGGOODSCD, @RATEMNGGOODSNM, @RATEMNGCUSTCD, @RATEMNGCUSTNM)";

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
            SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@UNITPRICEKIND", SqlDbType.Int);
            SqlParameter paraRateSettingDivide = sqlCommand.Parameters.Add("@RATESETTINGDIVIDE", SqlDbType.NChar);
            SqlParameter paraRatePriorityOrder = sqlCommand.Parameters.Add("@RATEPRIORITYORDER", SqlDbType.Int);
            SqlParameter paraRateMngGoodsCd = sqlCommand.Parameters.Add("@RATEMNGGOODSCD", SqlDbType.NChar);
            SqlParameter paraRateMngGoodsNm = sqlCommand.Parameters.Add("@RATEMNGGOODSNM", SqlDbType.NVarChar);
            SqlParameter paraRateMngCustCd = sqlCommand.Parameters.Add("@RATEMNGCUSTCD", SqlDbType.NChar);
            SqlParameter paraRateMngCustNm = sqlCommand.Parameters.Add("@RATEMNGCUSTNM", SqlDbType.NVarChar);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcRateProtyMngWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcRateProtyMngWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcRateProtyMngWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcRateProtyMngWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcRateProtyMngWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcRateProtyMngWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcRateProtyMngWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcRateProtyMngWork.LogicalDeleteCode);
            if (string.IsNullOrEmpty(dcRateProtyMngWork.SectionCode.Trim()))
            {
                paraSectionCode.Value = dcRateProtyMngWork.SectionCode;
            }
            else
            {
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcRateProtyMngWork.SectionCode);
            }
            paraUnitPriceKind.Value = SqlDataMediator.SqlSetInt32(dcRateProtyMngWork.UnitPriceKind);
            if (string.IsNullOrEmpty(dcRateProtyMngWork.RateSettingDivide.Trim()))
            {
                paraRateSettingDivide.Value = dcRateProtyMngWork.RateSettingDivide;
            }
            else
            {
                paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(dcRateProtyMngWork.RateSettingDivide);
            }
            paraRatePriorityOrder.Value = SqlDataMediator.SqlSetInt32(dcRateProtyMngWork.RatePriorityOrder);
            paraRateMngGoodsCd.Value = SqlDataMediator.SqlSetString(dcRateProtyMngWork.RateMngGoodsCd);
            paraRateMngGoodsNm.Value = SqlDataMediator.SqlSetString(dcRateProtyMngWork.RateMngGoodsNm);
            paraRateMngCustCd.Value = SqlDataMediator.SqlSetString(dcRateProtyMngWork.RateMngCustCd);
            paraRateMngCustNm.Value = SqlDataMediator.SqlSetString(dcRateProtyMngWork.RateMngCustNm);

            // �|���D��Ǘ��}�X�^�f�[�^��o�^����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region 2011/07/26 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j
        #region [Read]
        /// <summary>
        /// �|���D��Ǘ��}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="paramList">��������</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="rateProtyMngArrList">�|���D��Ǘ��}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���D��Ǘ��}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.07.26</br>
        public int SearchRateProtyMng(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList rateProtyMngArrList, out string retMessage)
        {
            return SearchRateProtyMngProc(enterpriseCodes, paramList, sqlConnection,
                               sqlTransaction, out rateProtyMngArrList, out retMessage);
        }
        /// <summary>
        /// �|���D��Ǘ��}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="paramList">��������</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="rateProtyMngArrList">�|���D��Ǘ��}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���D��Ǘ��}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.07.26</br>
        private int SearchRateProtyMngProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList rateProtyMngArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            rateProtyMngArrList = new ArrayList();
            //DCRateProtyMngWork rateProtyMngWork = null;//DEL 2011/08/20 �r���[�i�`�F�b�N
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RateProcParamWork param = paramList as RateProcParamWork;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, UNITPRICEKINDRF, RATESETTINGDIVIDERF, RATEPRIORITYORDERRF, RATEMNGGOODSCDRF, RATEMNGGOODSNMRF, RATEMNGCUSTCDRF, RATEMNGCUSTNMRF FROM RATEPROTYMNGRF ";
                sqlStr += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";

                if (param.UpdateDateTimeBegin != 0)
                {
                    sqlStr += " AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                }
                if (param.UpdateDateTimeEnd != 0)
                {
                    sqlStr += " AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                }
                if (!string.IsNullOrEmpty(param.UnitPriceKindRF))
                {
                    sqlStr += " AND UNITPRICEKINDRF = @UNITPRICEKINDBEGINRF";
                    SqlParameter unitPriceKindBeginRF = sqlCommand.Parameters.Add("@UNITPRICEKINDBEGINRF", SqlDbType.NChar);
                    unitPriceKindBeginRF.Value = SqlDataMediator.SqlSetString(param.UnitPriceKindRF);
                }

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);

                //�|���D��Ǘ��}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region DEL
                    //-----DEL 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)----->>>>>
                    //rateProtyMngWork = new DCRateProtyMngWork();

                    //rateProtyMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    //rateProtyMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    //rateProtyMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    //rateProtyMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    //rateProtyMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    //rateProtyMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    //rateProtyMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    //rateProtyMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    //rateProtyMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    //rateProtyMngWork.UnitPriceKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
                    //rateProtyMngWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
                    //rateProtyMngWork.RatePriorityOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEPRIORITYORDERRF"));
                    //rateProtyMngWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
                    //rateProtyMngWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
                    //rateProtyMngWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
                    //rateProtyMngWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
                    //rateProtyMngArrList.Add(rateProtyMngWork);
                    //-----DEL 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)-----<<<<<
                    #endregion DEL
                    rateProtyMngArrList.Add(CopyFromMyReaderToDCRateProtyMngWork(myReader));//ADD 2011/08/20 �r���[�i�`�F�b�N
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCRateProtyMngDB.SearchRateProtyMng Exception=" + ex.Message);
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

        //-----ADD 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)----->>>>>
        /// <summary>
        /// �|���D��Ǘ��}�X�^�f�[�^���擾
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>�|���D��Ǘ��}�X�^�f�[�^</returns>
        /// <br>Note       : �|���D��Ǘ��}�X�^�f�[�^��߂��܂�</br>
        /// <br>Programmer : �g���Y</br>
        /// <br>Date       : 2011/08/20</br>
        private DCRateProtyMngWork CopyFromMyReaderToDCRateProtyMngWork(SqlDataReader myReader)
        {
            DCRateProtyMngWork rateProtyMngWork = new DCRateProtyMngWork();

            rateProtyMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            rateProtyMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            rateProtyMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            rateProtyMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            rateProtyMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            rateProtyMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            rateProtyMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            rateProtyMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            rateProtyMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            rateProtyMngWork.UnitPriceKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
            rateProtyMngWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
            rateProtyMngWork.RatePriorityOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEPRIORITYORDERRF"));
            rateProtyMngWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
            rateProtyMngWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
            rateProtyMngWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
            rateProtyMngWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));

            return rateProtyMngWork;
        }
        //-----ADD 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)-----<<<<<
        #endregion
        #endregion 2011/07/26 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j

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
        //    sqlCommand.CommandText = "DELETE FROM RATEPROTYMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
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