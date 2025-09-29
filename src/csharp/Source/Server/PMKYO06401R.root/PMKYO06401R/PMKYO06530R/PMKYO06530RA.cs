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
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/07/26  �C�����e : SCM�Ή�-���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/26  �C�����e : DC�������O��DC�e�f�[�^�̃N���A������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/09/08  �C�����e : #23777 �\�[�X���r���[
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : FSI�� ���j
// �C �� ��  2012/07/26  �C�����e : ���_�Ǘ� ���o�����ǉ��Ή�
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
    /// �|���}�X�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^�f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCRateDB : RemoteDB
    {
        #region [Private]
        //ADD 2011/09/08 sundx #23777 �\�[�X���r���[ ------->>>>>
        private int _createDateTime = 0;
        private int _updateDateTime = 0;
        private int _enterpriseCode = 0;
        private int _fileHeaderGuid = 0;
        private int _updEmployeeCode = 0;
        private int _updAssemblyId1 = 0;
        private int _updAssemblyId2 = 0;
        private int _logicalDeleteCode = 0;
        private int _sectionCode = 0;
        private int _unitRateSetDivCd = 0;
        private int _unitPriceKind = 0;
        private int _rateSettingDivide = 0;
        private int _rateMngGoodsCd = 0;
        private int _rateMngGoodsNm = 0;
        private int _rateMngCustCd = 0;
        private int _rateMngCustNm = 0;
        private int _goodsMakerCd = 0;
        private int _goodsNo = 0;
        private int _goodsRateRank = 0;
        private int _goodsRateGrpCode = 0;
        private int _bLGroupCode = 0;
        private int _bLGoodsCode = 0;
        private int _customerCode = 0;
        private int _custRateGrpCode = 0;
        private int _supplierCd = 0;
        private int _lotCount = 0;
        private int _priceFl = 0;
        private int _rateVal = 0;
        private int _upRate = 0;
        private int _grsProfitSecureRate = 0;
        private int _unPrcFracProcUnit = 0;
        private int _unPrcFracProcDiv = 0;
        //ADD 2011/09/08 sundx #23777 �\�[�X���r���[ -------<<<<<
        #endregion

        /// <summary>
        /// �|���}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCRateDB()
            : base("PMKYO06531D", "Broadleaf.Application.Remoting.ParamData.DCRateWork", "RATERF")
        {

        }

        #region [Read]
        /// <summary>
        /// �|���}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="rateArrList">�|���}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        public int SearchRate(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList rateArrList, out string retMessage)
        {
            return SearchRateProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                              sqlTransaction, out rateArrList, out retMessage);
        }
        /// <summary>
        /// �|���}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="rateArrList">�|���}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        private int SearchRateProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList rateArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            rateArrList = new ArrayList();
            DCRateWork rateWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, UNITRATESETDIVCDRF, UNITPRICEKINDRF, RATESETTINGDIVIDERF, RATEMNGGOODSCDRF, RATEMNGGOODSNMRF, RATEMNGCUSTCDRF, RATEMNGCUSTNMRF, GOODSMAKERCDRF, GOODSNORF, GOODSRATERANKRF, GOODSRATEGRPCODERF, BLGROUPCODERF, BLGOODSCODERF, CUSTOMERCODERF, CUSTRATEGRPCODERF, SUPPLIERCDRF, LOTCOUNTRF, PRICEFLRF, RATEVALRF, UPRATERF, GRSPROFITSECURERATERF, UNPRCFRACPROCUNITRF, UNPRCFRACPROCDIVRF FROM RATERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //�|���}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    rateWork = new DCRateWork();

                    rateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    rateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    rateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    rateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    rateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    rateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    rateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    rateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    rateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    rateWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITRATESETDIVCDRF"));
                    rateWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
                    rateWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
                    rateWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
                    rateWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
                    rateWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
                    rateWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
                    rateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    rateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    rateWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                    rateWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
                    rateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    rateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    rateWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    rateWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                    rateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    rateWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNTRF"));
                    rateWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
                    rateWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
                    rateWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));
                    rateWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATERF"));
                    rateWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNPRCFRACPROCUNITRF"));
                    rateWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCFRACPROCDIVRF"));

                    rateArrList.Add(rateWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCRateDB.SearchRate Exception=" + ex.Message);
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
        ///  �|���}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="dcRateWork">�|���}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �|���}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Delete(DCRateWork dcRateWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcRateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  �|���}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="dcRateWork">�|���}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �|���}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        private void DeleteProc(DCRateWork dcRateWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM RATERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND GOODSRATERANKRF=@FINDGOODSRATERANK AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE AND BLGROUPCODERF=@FINDBLGROUPCODE AND BLGOODSCODERF=@FINDBLGOODSCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE AND SUPPLIERCDRF=@FINDSUPPLIERCD ";

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            SqlParameter findParaUnitRateSetDivCd = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
            SqlParameter findParaGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
            SqlParameter findParaGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
            SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
            SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
            SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
            // DEL 2009/06/09 --->>>
            //SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);
            // DEL 2009/06/09 ---<<<
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = dcRateWork.EnterpriseCode;
            findParaSectionCode.Value = dcRateWork.SectionCode;
            findParaUnitRateSetDivCd.Value = dcRateWork.UnitRateSetDivCd;
            findParaGoodsMakerCd.Value = dcRateWork.GoodsMakerCd;
            findParaGoodsNo.Value = dcRateWork.GoodsNo;
            findParaGoodsRateRank.Value = dcRateWork.GoodsRateRank;
            findParaGoodsRateGrpCode.Value = dcRateWork.GoodsRateGrpCode;
            findParaBLGroupCode.Value = dcRateWork.BLGroupCode;
            findParaBLGoodsCode.Value = dcRateWork.BLGoodsCode;
            findParaCustomerCode.Value = dcRateWork.CustomerCode;
            findParaCustRateGrpCode.Value = dcRateWork.CustRateGrpCode;
            findParaSupplierCd.Value = dcRateWork.SupplierCd;
            // DEL 2009/06/09 --->>>
            //findParaLotCount.Value = dcRateWork.LotCount;
            // DEL 2009/06/09 ---<<<


            // �|���}�X�^�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// �|���}�X�^�o�^
        /// </summary>
        /// <param name="dcRateWork">�|���}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �|���}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Insert(DCRateWork dcRateWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcRateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// �|���}�X�^�o�^
        /// </summary>
        /// <param name="dcRateWork">�|���}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �|���}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        private void InsertProc(DCRateWork dcRateWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "INSERT INTO RATERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, UNITRATESETDIVCDRF, UNITPRICEKINDRF, RATESETTINGDIVIDERF, RATEMNGGOODSCDRF, RATEMNGGOODSNMRF, RATEMNGCUSTCDRF, RATEMNGCUSTNMRF, GOODSMAKERCDRF, GOODSNORF, GOODSRATERANKRF, GOODSRATEGRPCODERF, BLGROUPCODERF, BLGOODSCODERF, CUSTOMERCODERF, CUSTRATEGRPCODERF, SUPPLIERCDRF, LOTCOUNTRF, PRICEFLRF, RATEVALRF, UPRATERF, GRSPROFITSECURERATERF, UNPRCFRACPROCUNITRF, UNPRCFRACPROCDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @UNITRATESETDIVCD, @UNITPRICEKIND, @RATESETTINGDIVIDE, @RATEMNGGOODSCD, @RATEMNGGOODSNM, @RATEMNGCUSTCD, @RATEMNGCUSTNM, @GOODSMAKERCD, @GOODSNO, @GOODSRATERANK, @GOODSRATEGRPCODE, @BLGROUPCODE, @BLGOODSCODE, @CUSTOMERCODE, @CUSTRATEGRPCODE, @SUPPLIERCD, @LOTCOUNT, @PRICEFL, @RATEVAL, @UPRATE, @GRSPROFITSECURERATE, @UNPRCFRACPROCUNIT, @UNPRCFRACPROCDIV)";

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
            SqlParameter paraUnitRateSetDivCd = sqlCommand.Parameters.Add("@UNITRATESETDIVCD", SqlDbType.NChar);
            SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@UNITPRICEKIND", SqlDbType.NChar);
            SqlParameter paraRateSettingDivide = sqlCommand.Parameters.Add("@RATESETTINGDIVIDE", SqlDbType.NChar);
            SqlParameter paraRateMngGoodsCd = sqlCommand.Parameters.Add("@RATEMNGGOODSCD", SqlDbType.NChar);
            SqlParameter paraRateMngGoodsNm = sqlCommand.Parameters.Add("@RATEMNGGOODSNM", SqlDbType.NVarChar);
            SqlParameter paraRateMngCustCd = sqlCommand.Parameters.Add("@RATEMNGCUSTCD", SqlDbType.NChar);
            SqlParameter paraRateMngCustNm = sqlCommand.Parameters.Add("@RATEMNGCUSTNM", SqlDbType.NVarChar);
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
            SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
            SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@GOODSRATEGRPCODE", SqlDbType.Int);
            SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
            SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
            SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
            SqlParameter paraLotCount = sqlCommand.Parameters.Add("@LOTCOUNT", SqlDbType.Float);
            SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFL", SqlDbType.Float);
            SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVAL", SqlDbType.Float);
            SqlParameter paraUpRate = sqlCommand.Parameters.Add("@UPRATE", SqlDbType.Float);
            SqlParameter paraGrsProfitSecureRate = sqlCommand.Parameters.Add("@GRSPROFITSECURERATE", SqlDbType.Float);
            SqlParameter paraUnPrcFracProcUnit = sqlCommand.Parameters.Add("@UNPRCFRACPROCUNIT", SqlDbType.Float);
            SqlParameter paraUnPrcFracProcDiv = sqlCommand.Parameters.Add("@UNPRCFRACPROCDIV", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcRateWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcRateWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcRateWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcRateWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcRateWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcRateWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcRateWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcRateWork.LogicalDeleteCode);
            paraSectionCode.Value = SqlDataMediator.SqlSetString(dcRateWork.SectionCode);
            paraUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(dcRateWork.UnitRateSetDivCd);
            paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(dcRateWork.UnitPriceKind);
            paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(dcRateWork.RateSettingDivide);
            paraRateMngGoodsCd.Value = SqlDataMediator.SqlSetString(dcRateWork.RateMngGoodsCd);
            paraRateMngGoodsNm.Value = SqlDataMediator.SqlSetString(dcRateWork.RateMngGoodsNm);
            paraRateMngCustCd.Value = SqlDataMediator.SqlSetString(dcRateWork.RateMngCustCd);
            paraRateMngCustNm.Value = SqlDataMediator.SqlSetString(dcRateWork.RateMngCustNm);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(dcRateWork.GoodsMakerCd);
            if (string.IsNullOrEmpty(dcRateWork.GoodsNo.Trim()))
            {
                paraGoodsNo.Value = dcRateWork.GoodsNo;
            }
            else
            {
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(dcRateWork.GoodsNo);
            }
            if (string.IsNullOrEmpty(dcRateWork.GoodsRateRank.Trim()))
            {
                paraGoodsRateRank.Value = dcRateWork.GoodsRateRank;
            }
            else
            {
                paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(dcRateWork.GoodsRateRank);
            }
            paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(dcRateWork.GoodsRateGrpCode);
            paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(dcRateWork.BLGroupCode);
            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(dcRateWork.BLGoodsCode);
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dcRateWork.CustomerCode);
            paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(dcRateWork.CustRateGrpCode);
            paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(dcRateWork.SupplierCd);
            paraLotCount.Value = SqlDataMediator.SqlSetDouble(dcRateWork.LotCount);
            paraPriceFl.Value = SqlDataMediator.SqlSetDouble(dcRateWork.PriceFl);
            paraRateVal.Value = SqlDataMediator.SqlSetDouble(dcRateWork.RateVal);
            paraUpRate.Value = SqlDataMediator.SqlSetDouble(dcRateWork.UpRate);
            paraGrsProfitSecureRate.Value = SqlDataMediator.SqlSetDouble(dcRateWork.GrsProfitSecureRate);
            paraUnPrcFracProcUnit.Value = SqlDataMediator.SqlSetDouble(dcRateWork.UnPrcFracProcUnit);
            paraUnPrcFracProcDiv.Value = SqlDataMediator.SqlSetInt32(dcRateWork.UnPrcFracProcDiv);

            // �|���}�X�^�f�[�^��o�^����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region 2011/07/26 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j
        #region [Read]
        /// <summary>
        /// �|���}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="paramList">��������</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="rateArrList">�|���}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.07.26</br>
        public int SearchRate(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList rateArrList, out string retMessage)
        {
            return SearchRateProc(enterpriseCodes, paramList, sqlConnection,
                              sqlTransaction, out rateArrList, out retMessage);
        }
        /// <summary>
        /// �|���}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="paramList">��������</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="rateArrList">�|���}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.07.26</br>
        private int SearchRateProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList rateArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            rateArrList = new ArrayList();
            //DCRateWork rateWork = null;//DEL 2011/08/20 �r���[�i�`�F�b�N
            retMessage = string.Empty;
            //string sqlStr = string.Empty;//DEL 2011/09/08 sundx #23777 �\�[�X���r���[
            StringBuilder sqlStr = new StringBuilder();//ADD 2011/09/08 sundx #23777 �\�[�X���r���[
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RateProcParamWork param = paramList as RateProcParamWork;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                #region DEL
                //DEL 2011/09/08 sundx #23777 �\�[�X���r���[ ----------------------------------------------------------------------->>>>>
                //sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, UNITRATESETDIVCDRF, UNITPRICEKINDRF, RATESETTINGDIVIDERF, RATEMNGGOODSCDRF, RATEMNGGOODSNMRF, RATEMNGCUSTCDRF, RATEMNGCUSTNMRF, GOODSMAKERCDRF, GOODSNORF, GOODSRATERANKRF, GOODSRATEGRPCODERF, BLGROUPCODERF, BLGOODSCODERF, CUSTOMERCODERF, CUSTRATEGRPCODERF, SUPPLIERCDRF, LOTCOUNTRF, PRICEFLRF, RATEVALRF, UPRATERF, GRSPROFITSECURERATERF, UNPRCFRACPROCUNITRF, UNPRCFRACPROCDIVRF FROM RATERF ";
                //sqlStr += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";

                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr += " AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr += " AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                //}
                //if (!string.IsNullOrEmpty(param.UnitPriceKindRF))
                //{
                //    sqlStr += " AND UNITPRICEKINDRF = @UNITPRICEKINDBEGINRF";
                //    SqlParameter unitPriceKindBeginRF = sqlCommand.Parameters.Add("@UNITPRICEKINDBEGINRF", SqlDbType.NChar);
                //    unitPriceKindBeginRF.Value = SqlDataMediator.SqlSetString(param.UnitPriceKindRF);
                //}

                //if (param.CustRateGrpCodeBeginRF != 0)
                //{
                //    sqlStr += " AND CUSTRATEGRPCODERF >= @CUSTRATEGRPCODEBEGINRF";
                //    SqlParameter custRateGrpCodeBeginRF = sqlCommand.Parameters.Add("@CUSTRATEGRPCODEBEGINRF", SqlDbType.Int);
                //    custRateGrpCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.CustRateGrpCodeBeginRF);
                //}

                //if (param.CustRateGrpCodeEndRF != 0)
                //{
                //    sqlStr += " AND CUSTRATEGRPCODERF <= @CUSTRATEGRPCODEENDRF";
                //    SqlParameter custRateGrpCodeEndRF = sqlCommand.Parameters.Add("@CUSTRATEGRPCODEENDRF", SqlDbType.Int);
                //    custRateGrpCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.CustRateGrpCodeEndRF);
                //}

                //if (param.CustomerCodeBeginRF != 0)
                //{
                //    sqlStr += " AND CUSTOMERCODERF >= @CUSTOMERCODEBEGINRF";
                //    SqlParameter customerCodeBeginRF = sqlCommand.Parameters.Add("@CUSTOMERCODEBEGINRF", SqlDbType.Int);
                //    customerCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.CustomerCodeBeginRF);
                //}

                //if (param.CustomerCodeEndRF != 0)
                //{
                //    sqlStr += " AND CUSTOMERCODERF <= @CUSTOMERCODEENDRF";
                //    SqlParameter customerCodeEndRF = sqlCommand.Parameters.Add("@CUSTOMERCODEENDRF", SqlDbType.Int);
                //    customerCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.CustomerCodeEndRF);
                //}

                //if (param.SupplierCdBeginRF != 0)
                //{
                //    sqlStr += " AND SUPPLIERCDRF >= @SUPPLIERCDBEGINRF";
                //    SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                //    supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                //}

                //if (param.SupplierCdEndRF != 0)
                //{
                //    sqlStr += " AND SUPPLIERCDRF <= @SUPPLIERCDENDRF";
                //    SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                //    supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                //}

                //if (param.GoodsMakerCdBeginRF != 0)
                //{
                //    sqlStr += " AND GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF";
                //    SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                //    goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
                //}

                //if (param.GoodsMakerCdEndRF != 0)
                //{
                //    sqlStr += " AND GOODSMAKERCDRF <= @GOODSMAKERCDENDRF";
                //    SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                //    goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsRateRankBeginRF))
                //{
                //    sqlStr += " AND GOODSRATERANKRF >= @GOODSRATERANKBEGINRF";
                //    SqlParameter goodsRateRankBeginRF = sqlCommand.Parameters.Add("@GOODSRATERANKBEGINRF", SqlDbType.NChar);
                //    goodsRateRankBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsRateRankBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsRateRankEndRF))
                //{
                //    sqlStr += " AND GOODSRATERANKRF <= @GOODSRATERANKENDRF";
                //    SqlParameter goodsRateRankEndRF = sqlCommand.Parameters.Add("@GOODSRATERANKENDRF", SqlDbType.NChar);
                //    goodsRateRankEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsRateRankEndRF);
                //}

                //if (param.GoodsRateGrpCodeBeginRF != 0)
                //{
                //    sqlStr += " AND GOODSRATEGRPCODERF >= @GOODSRATEGRPCODEBEGINRF";
                //    SqlParameter goodsRateGrpCodeBeginRF = sqlCommand.Parameters.Add("@GOODSRATEGRPCODEBEGINRF", SqlDbType.Int);
                //    goodsRateGrpCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsRateGrpCodeBeginRF);
                //}

                //if (param.GoodsRateGrpCodeEndRF != 0)
                //{
                //    sqlStr += " AND GOODSRATEGRPCODERF <= @GOODSRATEGRPCODEENDRF";
                //    SqlParameter goodsRateGrpCodeEndRF = sqlCommand.Parameters.Add("@GOODSRATEGRPCODEENDRF", SqlDbType.Int);
                //    goodsRateGrpCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsRateGrpCodeEndRF);
                //}

                //if (param.BLGoodsCodeBeginRF != 0)
                //{
                //    sqlStr += " AND BLGOODSCODERF >= @BLGOODSCODEBEGINRF";
                //    SqlParameter bLGoodsCodeBeginRF = sqlCommand.Parameters.Add("@BLGOODSCODEBEGINRF", SqlDbType.Int);
                //    bLGoodsCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeBeginRF);
                //}

                //if (param.BLGoodsCodeEndRF != 0)
                //{
                //    sqlStr += " AND BLGOODSCODERF <= @BLGOODSCODEENDRF";
                //    SqlParameter bLGoodsCodeEndRF = sqlCommand.Parameters.Add("@BLGOODSCODEENDRF", SqlDbType.Int);
                //    bLGoodsCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeEndRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
                //{
                //    sqlStr += " AND GOODSNORF >= @GOODSNOBEGINRF";
                //    SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                //    goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                //{
                //    sqlStr += " AND GOODSNORF <= @GOODSNOENDRF";
                //    SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                //    goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                //}
                //DEL 2011/09/08 sundx #23777 �\�[�X���r���[ -----------------------------------------------------------------------<<<<<
                #endregion
                //ADD 2011/09/08 sundx #23777 �\�[�X���r���[ ----------------------------------------------------------------------->>>>>
                sqlStr.Append("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, UNITRATESETDIVCDRF, UNITPRICEKINDRF, RATESETTINGDIVIDERF, RATEMNGGOODSCDRF, RATEMNGGOODSNMRF, RATEMNGCUSTCDRF, RATEMNGCUSTNMRF, GOODSMAKERCDRF, GOODSNORF, GOODSRATERANKRF, GOODSRATEGRPCODERF, BLGROUPCODERF, BLGOODSCODERF, CUSTOMERCODERF, CUSTRATEGRPCODERF, SUPPLIERCDRF, LOTCOUNTRF, PRICEFLRF, RATEVALRF, UPRATERF, GRSPROFITSECURERATERF, UNPRCFRACPROCUNITRF, UNPRCFRACPROCDIVRF FROM RATERF ");
                sqlStr.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ");

                if (param.UpdateDateTimeBegin != 0)
                {
                    sqlStr.Append(" AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                }
                if (param.UpdateDateTimeEnd != 0)
                {
                    sqlStr.Append(" AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                }
                if (!string.IsNullOrEmpty(param.UnitPriceKindRF))
                {
                    sqlStr.Append(" AND UNITPRICEKINDRF = @UNITPRICEKINDBEGINRF");
                    SqlParameter unitPriceKindBeginRF = sqlCommand.Parameters.Add("@UNITPRICEKINDBEGINRF", SqlDbType.NChar);
                    unitPriceKindBeginRF.Value = SqlDataMediator.SqlSetString(param.UnitPriceKindRF);
                }

                // --- ADD 2012/07/26 ---------->>>>>
                // ���_
                if (!string.IsNullOrEmpty(param.SectionCodeBeginRF))
                {
                    sqlStr.Append(" AND SECTIONCODERF >= @SECTIONCODEBEGINRF");
                    SqlParameter sectionCodeBeginRF = sqlCommand.Parameters.Add("@SECTIONCODEBEGINRF", SqlDbType.NChar);
                    sectionCodeBeginRF.Value = SqlDataMediator.SqlSetString(param.SectionCodeBeginRF);
                }

                if (!string.IsNullOrEmpty(param.SectionCodeEndRF))
                {
                    sqlStr.Append(" AND SECTIONCODERF <= @SECTIONCODEENDRF");
                    SqlParameter sectionCodeEndRF = sqlCommand.Parameters.Add("@SECTIONCODEENDRF", SqlDbType.NChar);
                    sectionCodeEndRF.Value = SqlDataMediator.SqlSetString(param.SectionCodeEndRF);
                }
                // --- ADD 2012/07/26 ----------<<<<<

                if (param.CustRateGrpCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND CUSTRATEGRPCODERF >= @CUSTRATEGRPCODEBEGINRF");
                    SqlParameter custRateGrpCodeBeginRF = sqlCommand.Parameters.Add("@CUSTRATEGRPCODEBEGINRF", SqlDbType.Int);
                    custRateGrpCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.CustRateGrpCodeBeginRF);
                }

                if (param.CustRateGrpCodeEndRF != 0)
                {
                    sqlStr.Append(" AND CUSTRATEGRPCODERF <= @CUSTRATEGRPCODEENDRF");
                    SqlParameter custRateGrpCodeEndRF = sqlCommand.Parameters.Add("@CUSTRATEGRPCODEENDRF", SqlDbType.Int);
                    custRateGrpCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.CustRateGrpCodeEndRF);
                }

                if (param.CustomerCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND CUSTOMERCODERF >= @CUSTOMERCODEBEGINRF");
                    SqlParameter customerCodeBeginRF = sqlCommand.Parameters.Add("@CUSTOMERCODEBEGINRF", SqlDbType.Int);
                    customerCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.CustomerCodeBeginRF);
                }

                if (param.CustomerCodeEndRF != 0)
                {
                    sqlStr.Append(" AND CUSTOMERCODERF <= @CUSTOMERCODEENDRF");
                    SqlParameter customerCodeEndRF = sqlCommand.Parameters.Add("@CUSTOMERCODEENDRF", SqlDbType.Int);
                    customerCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.CustomerCodeEndRF);
                }

                if (param.SupplierCdBeginRF != 0)
                {
                    sqlStr.Append(" AND SUPPLIERCDRF >= @SUPPLIERCDBEGINRF");
                    SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                    supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                }

                if (param.SupplierCdEndRF != 0)
                {
                    sqlStr.Append(" AND SUPPLIERCDRF <= @SUPPLIERCDENDRF");
                    SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                    supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                }

                if (param.GoodsMakerCdBeginRF != 0)
                {
                    sqlStr.Append(" AND GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF");
                    SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                    goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
                }

                if (param.GoodsMakerCdEndRF != 0)
                {
                    sqlStr.Append(" AND GOODSMAKERCDRF <= @GOODSMAKERCDENDRF");
                    SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                    goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
                }

                if (!string.IsNullOrEmpty(param.GoodsRateRankBeginRF))
                {
                    sqlStr.Append(" AND GOODSRATERANKRF >= @GOODSRATERANKBEGINRF");
                    SqlParameter goodsRateRankBeginRF = sqlCommand.Parameters.Add("@GOODSRATERANKBEGINRF", SqlDbType.NChar);
                    goodsRateRankBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsRateRankBeginRF);
                }

                if (!string.IsNullOrEmpty(param.GoodsRateRankEndRF))
                {
                    sqlStr.Append(" AND GOODSRATERANKRF <= @GOODSRATERANKENDRF");
                    SqlParameter goodsRateRankEndRF = sqlCommand.Parameters.Add("@GOODSRATERANKENDRF", SqlDbType.NChar);
                    goodsRateRankEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsRateRankEndRF);
                }

                if (param.GoodsRateGrpCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND GOODSRATEGRPCODERF >= @GOODSRATEGRPCODEBEGINRF");
                    SqlParameter goodsRateGrpCodeBeginRF = sqlCommand.Parameters.Add("@GOODSRATEGRPCODEBEGINRF", SqlDbType.Int);
                    goodsRateGrpCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsRateGrpCodeBeginRF);
                }

                if (param.GoodsRateGrpCodeEndRF != 0)
                {
                    sqlStr.Append(" AND GOODSRATEGRPCODERF <= @GOODSRATEGRPCODEENDRF");
                    SqlParameter goodsRateGrpCodeEndRF = sqlCommand.Parameters.Add("@GOODSRATEGRPCODEENDRF", SqlDbType.Int);
                    goodsRateGrpCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsRateGrpCodeEndRF);
                }

                if (param.BLGoodsCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND BLGOODSCODERF >= @BLGOODSCODEBEGINRF");
                    SqlParameter bLGoodsCodeBeginRF = sqlCommand.Parameters.Add("@BLGOODSCODEBEGINRF", SqlDbType.Int);
                    bLGoodsCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeBeginRF);
                }

                if (param.BLGoodsCodeEndRF != 0)
                {
                    sqlStr.Append(" AND BLGOODSCODERF <= @BLGOODSCODEENDRF");
                    SqlParameter bLGoodsCodeEndRF = sqlCommand.Parameters.Add("@BLGOODSCODEENDRF", SqlDbType.Int);
                    bLGoodsCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeEndRF);
                }

                // --- DEL 2012/07/26 ---------->>>>>
                //if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
                //{
                //    sqlStr.Append(" AND GOODSNORF >= @GOODSNOBEGINRF");
                //    SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                //    goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                //{
                //    sqlStr.Append(" AND GOODSNORF <= @GOODSNOENDRF");
                //    SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                //    goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                //}
                // --- DEL 2012/07/26 ----------<<<<<
                // --- ADD 2012/07/26 ---------->>>>>
                // �i��
                if ("2" == param.SetFunRF)
                {
                    // �P�i�w��

                    // �i�ԗL�w��
                    sqlStr.Append(" AND (GOODSNORF IS NOT NULL) AND (LEN(GOODSNORF) > 0)");

                    if ((!string.IsNullOrEmpty(param.GoodsNoBeginRF)) && (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                        && (param.GoodsNoBeginRF == param.GoodsNoEndRF))
                    {
                        // �P�Ǝw��
                        sqlStr.Append(" AND (GOODSNORF LIKE @GOODSNOBEGINRF)");
                        SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                        param.GoodsNoBeginRF = System.Text.RegularExpressions.Regex.Replace(param.GoodsNoBeginRF, @"\*$", "%"); // �����ɢ*�������ꍇ�͞B�������p�ɒu��
                        goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                    }
                    else
                    {
                        // �͈͎w��
                        if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
                        {
                            sqlStr.Append(" AND GOODSNORF >= @GOODSNOBEGINRF");
                            SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                            goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                        }

                        if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                        {
                            sqlStr.Append(" AND GOODSNORF <= @GOODSNOENDRF");
                            SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                            goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                        }
                    }
                }
                else
                {
                    // �O���[�v�w��
                    sqlStr.Append(" AND ((GOODSNORF IS NULL) OR (LEN(GOODSNORF) = 0))");
                }
                // --- ADD 2012/07/26 ----------<<<<<
                //ADD 2011/09/08 sundx #23777 �\�[�X���r���[ -----------------------------------------------------------------------<<<<<

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);

                //�|���}�X�^�f�[�^�pSQL
                //sqlCommand.CommandText = sqlStr;//DEL 2011/09/08 sundx #23777 �\�[�X���r���[ 
                sqlCommand.CommandText = sqlStr.ToString();//ADD 2011/09/08 sundx #23777 �\�[�X���r���[ 

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();
                //ADD 2011/09/08 sundx #23777 �\�[�X���r���[ ----------------------------->>>>>
                if (myReader.HasRows)
                {
                    SetIndex(myReader);
                }
                //ADD 2011/09/08 sundx #23777 �\�[�X���r���[ -----------------------------<<<<<

                while (myReader.Read())
                {
                    #region DEL
                    //-----DEL 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)----->>>>>
                    //rateWork = new DCRateWork();

                    //rateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    //rateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    //rateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    //rateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    //rateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    //rateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    //rateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    //rateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    //rateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    //rateWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITRATESETDIVCDRF"));
                    //rateWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
                    //rateWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
                    //rateWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
                    //rateWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
                    //rateWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
                    //rateWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
                    //rateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    //rateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    //rateWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                    //rateWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
                    //rateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    //rateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    //rateWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    //rateWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                    //rateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    //rateWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNTRF"));
                    //rateWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
                    //rateWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
                    //rateWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));
                    //rateWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATERF"));
                    //rateWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNPRCFRACPROCUNITRF"));
                    //rateWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCFRACPROCDIVRF"));

                    //rateArrList.Add(rateWork);
                    //-----DEL 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)-----<<<<<
                    #endregion DEL
                    rateArrList.Add(CopyFromMyReaderToDCRateWork(myReader));//ADD 2011/08/20 �r���[�i�`�F�b�N
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCRateDB.SearchRate Exception=" + ex.Message);
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/09/08</br>
        /// </remarks>
        private void SetIndex(SqlDataReader myReader)
        {
            _createDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
            _updateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
            _enterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
            _fileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
            _updEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
            _updAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
            _updAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
            _logicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
            _sectionCode = myReader.GetOrdinal("SECTIONCODERF");
            _unitRateSetDivCd = myReader.GetOrdinal("UNITRATESETDIVCDRF");
            _unitPriceKind = myReader.GetOrdinal("UNITPRICEKINDRF");
            _rateSettingDivide = myReader.GetOrdinal("RATESETTINGDIVIDERF");
            _rateMngGoodsCd = myReader.GetOrdinal("RATEMNGGOODSCDRF");
            _rateMngGoodsNm = myReader.GetOrdinal("RATEMNGGOODSNMRF");
            _rateMngCustCd = myReader.GetOrdinal("RATEMNGCUSTCDRF");
            _rateMngCustNm = myReader.GetOrdinal("RATEMNGCUSTNMRF");
            _goodsMakerCd = myReader.GetOrdinal("GOODSMAKERCDRF");
            _goodsNo = myReader.GetOrdinal("GOODSNORF");
            _goodsRateRank = myReader.GetOrdinal("GOODSRATERANKRF");
            _goodsRateGrpCode = myReader.GetOrdinal("GOODSRATEGRPCODERF");
            _bLGroupCode = myReader.GetOrdinal("BLGROUPCODERF");
            _bLGoodsCode = myReader.GetOrdinal("BLGOODSCODERF");
            _customerCode = myReader.GetOrdinal("CUSTOMERCODERF");
            _custRateGrpCode = myReader.GetOrdinal("CUSTRATEGRPCODERF");
            _supplierCd = myReader.GetOrdinal("SUPPLIERCDRF");
            _lotCount = myReader.GetOrdinal("LOTCOUNTRF");
            _priceFl = myReader.GetOrdinal("PRICEFLRF");
            _rateVal = myReader.GetOrdinal("RATEVALRF");
            _upRate = myReader.GetOrdinal("UPRATERF");
            _grsProfitSecureRate = myReader.GetOrdinal("GRSPROFITSECURERATERF");
            _unPrcFracProcUnit = myReader.GetOrdinal("UNPRCFRACPROCUNITRF");
            _unPrcFracProcDiv = myReader.GetOrdinal("UNPRCFRACPROCDIVRF");

        }
        //-----ADD 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)----->>>>>
        /// <summary>
        /// �|���}�X�^�f�[�^���擾
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>�|���}�X�^�f�[�^</returns>
        /// <br>Note       : �|���}�X�^�f�[�^��߂��܂�</br>
        /// <br>Programmer : �g���Y</br>
        /// <br>Date       : 2011/08/20</br>
        private DCRateWork CopyFromMyReaderToDCRateWork(SqlDataReader myReader)
        {
            DCRateWork rateWork = new DCRateWork();
            #region DEL
            //DEL 2011/09/08 sundx #23777 �\�[�X���r���[ -----------------------------------------------------------------------<<<<<
            //rateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            //rateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            //rateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            //rateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            //rateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            //rateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            //rateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            //rateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //rateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            //rateWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITRATESETDIVCDRF"));
            //rateWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
            //rateWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
            //rateWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
            //rateWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
            //rateWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
            //rateWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
            //rateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            //rateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            //rateWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            //rateWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            //rateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            //rateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            //rateWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            //rateWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            //rateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            //rateWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNTRF"));
            //rateWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
            //rateWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
            //rateWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));
            //rateWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATERF"));
            //rateWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNPRCFRACPROCUNITRF"));
            //rateWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCFRACPROCDIVRF"));
            //DEL 2011/09/08 sundx #23777 �\�[�X���r���[ -----------------------------------------------------------------------<<<<<
            #endregion
            //ADD 2011/09/08 sundx #23777 �\�[�X���r���[ ----------------------------------------------------------------------->>>>>
            rateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _createDateTime);
            rateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _updateDateTime);
            rateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _enterpriseCode);
            rateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _fileHeaderGuid);
            rateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _updEmployeeCode);
            rateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _updAssemblyId1);
            rateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _updAssemblyId2);
            rateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _logicalDeleteCode);
            rateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, _sectionCode);
            rateWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, _unitRateSetDivCd);
            rateWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, _unitPriceKind);
            rateWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, _rateSettingDivide);
            rateWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, _rateMngGoodsCd);
            rateWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, _rateMngGoodsNm);
            rateWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, _rateMngCustCd);
            rateWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, _rateMngCustNm);
            rateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, _goodsMakerCd);
            rateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, _goodsNo);
            rateWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, _goodsRateRank);
            rateWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, _goodsRateGrpCode);
            rateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, _bLGroupCode);
            rateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, _bLGoodsCode);
            rateWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, _customerCode);
            rateWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, _custRateGrpCode);
            rateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, _supplierCd);
            rateWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, _lotCount);
            rateWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, _priceFl);
            rateWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, _rateVal);
            rateWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, _upRate);
            rateWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, _grsProfitSecureRate);
            rateWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, _unPrcFracProcUnit);
            rateWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, _unPrcFracProcDiv);
            //ADD 2011/09/08 sundx #23777 �\�[�X���r���[ -----------------------------------------------------------------------<<<<<

            return rateWork;
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
        //    sqlCommand.CommandText = "DELETE FROM RATERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
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