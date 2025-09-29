//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^���M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/04/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��  2009/06/11  �C�����e : R�N���X��public Method��SQL�������ʖ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/28  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���|��
// �C �� ��  2011/11/01  �C�����e : Redmine#26228 ���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/11/30  �C�����e : Redmine#8293 ���_�Ǘ��^�`�[���t���t���o����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/12/06  �C�����e : Redmine#8293 ��ʂ̏I�����t�{�V�X�e�������d�l�̕ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C �� ��  2012/03/16  �C�����e : �^�C���A�E�g�Ή�(30�b��600�b)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10904597-00 �쐬�S�� : �e�c ���V
// �C �� ��  2014/02/20  �C�����e : �d�|�ꗗ��2292�Ή�
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌ɒ����f�[�^READDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �f�[�^���M����READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APStockAdjustDB : RemoteDB
    {
        /// <summary>
        /// �݌ɒ����f�[�^READDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APStockAdjustDB()
        {
        }
        #region [--- DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
// DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
/*

        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �݌ɒ����f�[�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="stockAdjustArrList">�݌ɒ����f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.06.11</br>
        /// 
        public int SearchStockAdjust(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage)
        {
            return SearchStockAdjustProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  stockAdjustArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �݌ɒ����f�[�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="stockAdjustArrList">�݌ɒ����f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.28</br>
        /// 
        private int SearchStockAdjustProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            stockAdjustArrList = new ArrayList();
            APStockAdjustWork stockAdjustWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // �݌ɒ����f�[�^�pSQL
				sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stockAdjustWork = new APStockAdjustWork();

                    stockAdjustWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    stockAdjustWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    stockAdjustWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    stockAdjustWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    stockAdjustWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    stockAdjustWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    stockAdjustWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    stockAdjustWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    stockAdjustWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    stockAdjustWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF"));
                    stockAdjustWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
                    stockAdjustWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
                    stockAdjustWork.AdjustDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
                    stockAdjustWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    stockAdjustWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                    stockAdjustWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
                    stockAdjustWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
                    stockAdjustWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
                    stockAdjustWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
                    stockAdjustWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
                    stockAdjustWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));

                    stockAdjustArrList.Add(stockAdjustWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APStockAdjustDB.SearchStockAdjust Exception=" + ex.Message);
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
*/
        // DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        #endregion [--- DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]

        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �݌ɒ����f�[�^�X�V
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="stockAdjustList">�݌ɒ����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int UpdateStockAdjust(string enterPriseCode, ArrayList stockAdjustList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateStockAdjustProc(enterPriseCode, stockAdjustList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �݌ɒ����f�[�^�X�V
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="stockAdjustList">�݌ɒ����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int UpdateStockAdjustProc(string enterPriseCode, ArrayList stockAdjustList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �S�ăf�[�^���폜����
            status = DeleteStockAdjust(enterPriseCode, stockAdjustList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �o�^����
                status = InsertStockAdjust(enterPriseCode, stockAdjustList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        /// <summary>
        /// �݌ɒ����f�[�^�폜
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="stockAdjustList">�󒍃}�X�^�i�ԗ��j</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int DeleteStockAdjust(string enterPriseCode, ArrayList stockAdjustList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockAdjustProc(enterPriseCode, stockAdjustList, ref  sqlConnection, ref  sqlTransaction);
        }
        /// <summary>
        /// �݌ɒ����f�[�^�폜
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="stockAdjustList">�󒍃}�X�^�i�ԗ��j</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int DeleteStockAdjustProc(string enterPriseCode, ArrayList stockAdjustList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockAdjustWork stockAdjustWork in stockAdjustList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "DELETE FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaStockAdjustSlipNo.Value = stockAdjustWork.StockAdjustSlipNo;

				sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<

                // ���s
                sqlCommand.ExecuteNonQuery();
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (myReader != null)
            {
                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                myReader.Dispose();
            }

            if (sqlCommand != null)
            {
                sqlCommand.Cancel();
                sqlCommand.Dispose();
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �݌ɒ����f�[�^�V�K
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="stockAdjustList">�݌ɒ����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int InsertStockAdjust(string enterPriseCode, ArrayList stockAdjustList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertStockAdjustProc(enterPriseCode, stockAdjustList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �݌ɒ����f�[�^�V�K
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="stockAdjustList">�݌ɒ����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int InsertStockAdjustProc(string enterPriseCode, ArrayList stockAdjustList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockAdjustWork stockAdjustWork in stockAdjustList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "INSERT INTO STOCKADJUSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @STOCKADJUSTSLIPNO, @ACPAYSLIPCD, @ACPAYTRANSCD, @ADJUSTDATE, @INPUTDAY, @STOCKSECTIONCD, @STOCKINPUTCODE, @STOCKINPUTNAME, @STOCKAGENTCODE, @STOCKAGENTNAME, @STOCKSUBTTLPRICE, @SLIPNOTE)";

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
                SqlParameter paraStockAdjustSlipNo = sqlCommand.Parameters.Add("@STOCKADJUSTSLIPNO", SqlDbType.Int);
                SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
                SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
                SqlParameter paraAdjustDate = sqlCommand.Parameters.Add("@ADJUSTDATE", SqlDbType.Int);
                SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                SqlParameter paraStockSectionCd = sqlCommand.Parameters.Add("@STOCKSECTIONCD", SqlDbType.NChar);
                SqlParameter paraStockInputCode = sqlCommand.Parameters.Add("@STOCKINPUTCODE", SqlDbType.NChar);
                SqlParameter paraStockInputName = sqlCommand.Parameters.Add("@STOCKINPUTNAME", SqlDbType.NVarChar);
                SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);
                SqlParameter paraStockAgentName = sqlCommand.Parameters.Add("@STOCKAGENTNAME", SqlDbType.NVarChar);
                SqlParameter paraStockSubttlPrice = sqlCommand.Parameters.Add("@STOCKSUBTTLPRICE", SqlDbType.BigInt);
                SqlParameter paraSlipNote = sqlCommand.Parameters.Add("@SLIPNOTE", SqlDbType.NVarChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockAdjustWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockAdjustWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockAdjustWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockAdjustWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockAdjustWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockAdjustWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockAdjustWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockAdjustWork.SectionCode);
                paraStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockAdjustWork.StockAdjustSlipNo);
                paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockAdjustWork.AcPaySlipCd);
                paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(stockAdjustWork.AcPayTransCd);
                paraAdjustDate.Value = SqlDataMediator.SqlSetInt32(stockAdjustWork.AdjustDate);
                paraInputDay.Value = SqlDataMediator.SqlSetInt32(stockAdjustWork.InputDay);
                paraStockSectionCd.Value = SqlDataMediator.SqlSetString(stockAdjustWork.StockSectionCd);
                paraStockInputCode.Value = SqlDataMediator.SqlSetString(stockAdjustWork.StockInputCode);
                paraStockInputName.Value = SqlDataMediator.SqlSetString(stockAdjustWork.StockInputName);
                paraStockAgentCode.Value = SqlDataMediator.SqlSetString(stockAdjustWork.StockAgentCode);
                paraStockAgentName.Value = SqlDataMediator.SqlSetString(stockAdjustWork.StockAgentName);
                paraStockSubttlPrice.Value = SqlDataMediator.SqlSetInt64(stockAdjustWork.StockSubttlPrice);
                paraSlipNote.Value = SqlDataMediator.SqlSetString(stockAdjustWork.SlipNote);

				sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<

                sqlCommand.ExecuteNonQuery();
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (myReader != null)
            {
                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                myReader.Dispose();
            }

            if (sqlCommand != null)
            {
                sqlCommand.Cancel();
                sqlCommand.Dispose();
            }

            return status;
        }

		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		// R�N���X��public Method��SQL�������ʖ�

        //----- DEL 2011/11/01 xupz------->>>>>>
        ///// <summary>
        ///// �݌ɒ����f�[�^�̌�������
        ///// </summary>
        ///// <param name="enterpriseCodes">��ƃR�[�h</param>
        ///// <param name="beginningDate">�J�n���t</param>
        ///// <param name="endingDate">�I�����t</param>
        ///// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        ///// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        ///// <param name="stockAdjustArrList">�݌ɒ����f�[�^�I�u�W�F�N�g</param>
        ///// <param name="retMessage">�߂郁�b�Z�[�W</param>
        ///// <param name="SectionCd">SectionCd</param>
        ///// <returns>STATUS</returns>
        //public int SearchStockAdjustSCM(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage, string SectionCd)
        //{
        //    return SearchStockAdjustSCMProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
        //     sqlTransaction, out  stockAdjustArrList, out  retMessage, SectionCd);
        //}

        ///// <summary>
        ///// �݌ɒ����f�[�^�̌�������
        ///// </summary>
        ///// <param name="enterpriseCodes">��ƃR�[�h</param>
        ///// <param name="beginningDate">�J�n���t</param>
        ///// <param name="endingDate">�I�����t</param>
        ///// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        ///// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        ///// <param name="stockAdjustArrList">�݌ɒ����f�[�^�I�u�W�F�N�g</param>
        ///// <param name="retMessage">�߂郁�b�Z�[�W</param>
        ///// <param name="SectionCd">SectionCd</param>
        ///// <returns>STATUS</returns>
        //private int SearchStockAdjustSCMProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage, string SectionCd)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    stockAdjustArrList = new ArrayList();
        //    retMessage = string.Empty;
        //    string sqlStr = string.Empty;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;

        //    try
        //    {
        //        sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //        sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF FROM STOCKADJUSTRF WHERE SECTIONCODERF=@FINDSECTIONCODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

        //        //Prameter�I�u�W�F�N�g�̍쐬
        //        SqlParameter findParaSectionCd = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
        //        SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
        //        SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

        //        //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //        findParaSectionCd.Value = SqlDataMediator.SqlSetString(SectionCd);
        //        findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
        //        findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

        //        // �݌ɒ����f�[�^�pSQL
        //        sqlCommand.CommandText = sqlStr;
        //        // �ǂݍ���
        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            stockAdjustArrList.Add(this.CopyTostockAdjustWorkFromReader(ref myReader));
        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        base.WriteErrorLog(ex, "APStockAdjustDB.SearchStockAdjust Exception=" + ex.Message);
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
        //----- DEL 2011/11/01 xupz-------<<<<<<

        //----- ADD 2011/11/01 xupz------->>>>>>
		/// <summary>
		/// �݌ɒ����f�[�^�̌�������
		/// </summary>
		/// <param name="enterpriseCodes">��ƃR�[�h</param>
		/// <param name="beginningDate">�J�n���t</param>
		/// <param name="endingDate">�I�����t</param>
		/// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
		/// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
		/// <param name="stockAdjustArrList">�݌ɒ����f�[�^�I�u�W�F�N�g</param>
		/// <param name="retMessage">�߂郁�b�Z�[�W</param>
		/// <param name="SectionCd">SectionCd</param>
		/// <returns>STATUS</returns>
        //public int SearchStockAdjustSCM(Int32 sedMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,   // DEL 2011/11/30
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage, string SectionCd)                                          // DEL 2011/11/30
        //public int SearchStockAdjustSCM(Int32 sedMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, SqlConnection sqlConnection,  // ADD 2011/11/30 // DEL 2011/12/06
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage, string SectionCd)    // ADD 2011/11/30 // DEL 2011/12/06
        public int SearchStockAdjustSCM(Int32 sedMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, Int64 endingDateTicks, SqlConnection sqlConnection,  // ADD 2011/12/06
            SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage, string SectionCd)    // ADD 2011/12/06
		{
            //return SearchStockAdjustSCMProc(sedMesExtraConDiv, enterpriseCodes, beginningDate, endingDate, syncExecDate, sqlConnection, // DEL 2011/12/06
            // sqlTransaction, out  stockAdjustArrList, out  retMessage, SectionCd); // DEL 2011/12/06
            return SearchStockAdjustSCMProc(sedMesExtraConDiv, enterpriseCodes, beginningDate, endingDate, syncExecDate, endingDateTicks, sqlConnection, // ADD 2011/12/06
             sqlTransaction, out  stockAdjustArrList, out  retMessage, SectionCd); // ADD 2011/12/06
		} 

		/// <summary>
		/// �݌ɒ����f�[�^�̌�������
		/// </summary>
		/// <param name="enterpriseCodes">��ƃR�[�h</param>
		/// <param name="beginningDate">�J�n���t</param>
		/// <param name="endingDate">�I�����t</param>
		/// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
		/// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
		/// <param name="stockAdjustArrList">�݌ɒ����f�[�^�I�u�W�F�N�g</param>
		/// <param name="retMessage">�߂郁�b�Z�[�W</param>
		/// <param name="SectionCd">SectionCd</param>
		/// <returns>STATUS</returns>
        //private int SearchStockAdjustSCMProc(Int32 sedMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection, // DEL 2011/11/30
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage, string SectionCd)   // DEL 2011/11/30
        //private int SearchStockAdjustSCMProc(Int32 sedMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, SqlConnection sqlConnection, // ADD 2011/11/30 // DEL 2011/12/06
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage, string SectionCd) // ADD 2011/11/30 // DEL 2011/12/06
        private int SearchStockAdjustSCMProc(Int32 sedMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, Int64 endingDateTicks, SqlConnection sqlConnection, // ADD 2011/12/06
            SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage, string SectionCd) // ADD 2011/12/06
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			stockAdjustArrList = new ArrayList();
			retMessage = string.Empty;
			string sqlStr = string.Empty;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try
			{
				sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                //sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF FROM STOCKADJUSTRF WHERE SECTIONCODERF=@FINDSECTIONCODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF FROM STOCKADJUSTRF WHERE SECTIONCODERF=@FINDSECTIONCODE";
                //�f�[�^���M���o�����敪���u�����v�̏ꍇ
                if (sedMesExtraConDiv == 0)
                {
                    //�݌ɒ����f�[�^.�X�V����
                    sqlStr = sqlStr + " AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                }
                //�f�[�^���M���o�����敪���u�`�[���t�v�̏ꍇ 
                else if(sedMesExtraConDiv == 1)
                {
                    //�݌ɒ����f�[�^.�������t
                    //sqlStr = sqlStr + " AND ADJUSTDATERF >= @UPDATEDATETIMEBEGRF AND ADJUSTDATERF <= @UPDATEDATETIMEENDRF ";  // DEL 2011/11/30
                    sqlStr = sqlStr + " AND (( ADJUSTDATERF >= @UPDATEDATETIMEBEGRF AND ADJUSTDATERF <= @UPDATEDATETIMEENDRF )"; // ADD 2011/11/30

                    // ----- ADD 2011/11/30 tanh---------->>>>>
                    // --- UPD 2014/02/20 Y.Wakita ---------->>>>>
                    //sqlStr = sqlStr + " OR ( UPDATEDATETIMERF>=@FINDSYNCEXECDATERF ";
                    sqlStr = sqlStr + " OR ( UPDATEDATETIMERF>@FINDSYNCEXECDATERF ";
                    // --- UPD 2014/02/20 Y.Wakita ----------<<<<<
                    sqlStr = sqlStr + " AND  UPDATEDATETIMERF<=@FINDENDTIMERF ";
                    sqlStr = sqlStr + " AND  ADJUSTDATERF<=@UPDATEDATETIMEENDRF )) ";
                    // ----- ADD 2011/11/30 tanh----------<<<<<<
                }

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaSectionCd = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
				SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
				SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaSectionCd.Value = SqlDataMediator.SqlSetString(SectionCd);
				findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
				findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // ----- ADD 2011/11/30 tanh---------->>>>>
                //�f�[�^���M���o�����敪���u�`�[�敪�v�̏ꍇ
                if (sedMesExtraConDiv == 1)
                {
                    SqlParameter findParaSyncExecDate = sqlCommand.Parameters.Add("@FINDSYNCEXECDATERF", SqlDbType.BigInt);
                    findParaSyncExecDate.Value = SqlDataMediator.SqlSetInt64(syncExecDate);
                    SqlParameter findParaEndTime = sqlCommand.Parameters.Add("@FINDENDTIMERF", SqlDbType.BigInt);
                    // DEL 2011/12/06 ----------- >>>>>>>>>>>>>>>
                    //string endTimeStr = sendDataWork.EndDateTime.ToString();
                    //if (endTimeStr.Length == 8)
                    //{
                    //    DateTime endTime = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                    //                                int.Parse(endTimeStr.Substring(4, 2)),
                    //                                int.Parse(endTimeStr.Substring(6, 2)),
                    //                                23, 59, 59);
                    //    findParaEndTime.Value = endTime.Ticks;
                    //}
                    //else
                    //{
                    //    findParaEndTime.Value = DateTime.MinValue.Ticks;
                    //}
                    // DEL 2011/12/06 ----------- <<<<<<<<<<<<<<<
                    findParaEndTime.Value = SqlDataMediator.SqlSetInt64(endingDateTicks); // ADD 2011/12/06
                }
                // ----- ADD 2011/11/30 tanh----------<<<<<

				// �݌ɒ����f�[�^�pSQL
				sqlCommand.CommandText = sqlStr;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // �ǂݍ���
				myReader = sqlCommand.ExecuteReader();

				while (myReader.Read())
				{
					stockAdjustArrList.Add(this.CopyTostockAdjustWorkFromReader(ref myReader));
				}

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex)
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				base.WriteErrorLog(ex, "APStockAdjustDB.SearchStockAdjust Exception=" + ex.Message);
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
        // ----- ADD 2011/11/01 xupz----------<<<<<

		/// <summary>
		/// �N���X�i�[���� Reader �� aPStockAdjustWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <returns>�I�u�W�F�N�g</returns>
		/// <remarks>
		/// <br>Programmer : ����</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		private APStockAdjustWork CopyTostockAdjustWorkFromReader(ref SqlDataReader myReader)
		{
			APStockAdjustWork stockAdjustWork = new APStockAdjustWork();

			this.CopyTostockAdjustWorkFromReader(ref myReader, ref stockAdjustWork);

			return stockAdjustWork;
		}

		/// <summary>
		/// �N���X�i�[���� Reader �� stockAdjustWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="stockAdjustWork">stockAdjustWork �I�u�W�F�N�g</param>
		/// <returns>void</returns>
		/// <remarks>
		/// <br>Programmer : ����</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		private void CopyTostockAdjustWorkFromReader(ref SqlDataReader myReader, ref APStockAdjustWork stockAdjustWork)
		{
			if (myReader != null && stockAdjustWork != null)
			{
				# region �N���X�֊i�[
				stockAdjustWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				stockAdjustWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				stockAdjustWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				stockAdjustWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				stockAdjustWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				stockAdjustWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				stockAdjustWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				stockAdjustWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				stockAdjustWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
				stockAdjustWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF"));
				stockAdjustWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
				stockAdjustWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
				stockAdjustWork.AdjustDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
				stockAdjustWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAYRF"));
				stockAdjustWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
				stockAdjustWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
				stockAdjustWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
				stockAdjustWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
				stockAdjustWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
				stockAdjustWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
				stockAdjustWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));

				# endregion
			}
		}
		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
    }
}