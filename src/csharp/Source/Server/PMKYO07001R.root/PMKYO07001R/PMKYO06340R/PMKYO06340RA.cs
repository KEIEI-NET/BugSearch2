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
// �C �� ��  2009/06/11   �C�����e : R�N���X��public Method��SQL�������ʖ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/28  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���|��
// �C �� ��  2011/11/01  �C�����e : Redmine#26228�@���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
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
    /// �݌ɒ������׃f�[�^READDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �f�[�^���M����READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APStockAdjustDtlDB : RemoteDB
    {
        /// <summary>
        /// �݌ɒ������׃f�[�^READDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APStockAdjustDtlDB()
        {
        }
        #region [--- DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
// DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �݌ɒ������׃f�[�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="stockAdjustDtlArrList">�݌ɒ������׃f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ������׃f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.06.11</br>
        /// 
        public int SearchStockAdjustDtl(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage)
        {
            return SearchStockAdjustDtlProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  stockAdjustDtlArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �݌ɒ������׃f�[�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="stockAdjustDtlArrList">�݌ɒ������׃f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ������׃f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.28</br>
        /// 
        private int SearchStockAdjustDtlProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            stockAdjustDtlArrList = new ArrayList();
            APStockAdjustDtlWork stockAdjustDtlWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // �݌ɒ������׃f�[�^�pSQL
				sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stockAdjustDtlWork = new APStockAdjustDtlWork();
                    stockAdjustDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    stockAdjustDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    stockAdjustDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    stockAdjustDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    stockAdjustDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    stockAdjustDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    stockAdjustDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    stockAdjustDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    stockAdjustDtlWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    stockAdjustDtlWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF"));
                    stockAdjustDtlWork.StockAdjustRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTROWNORF"));
                    stockAdjustDtlWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));
                    stockAdjustDtlWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));
                    stockAdjustDtlWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
                    stockAdjustDtlWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
                    stockAdjustDtlWork.AdjustDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
                    stockAdjustDtlWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    stockAdjustDtlWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockAdjustDtlWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockAdjustDtlWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockAdjustDtlWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockAdjustDtlWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    stockAdjustDtlWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
                    stockAdjustDtlWork.AdjustCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
                    stockAdjustDtlWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
                    stockAdjustDtlWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockAdjustDtlWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockAdjustDtlWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    stockAdjustDtlWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    stockAdjustDtlWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    stockAdjustDtlWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
                    stockAdjustDtlWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    stockAdjustDtlWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                    stockAdjustDtlArrList.Add(stockAdjustDtlWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APStockAdjustDtlDB.SearchStockAdjustDtl Exception=" + ex.Message);
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
        /// �݌ɒ������׃f�[�^�X�V
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="stockAdjustDtlList">�݌ɒ������׃f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int UpdateStockAdjustDtl(string enterPriseCode, ArrayList stockAdjustDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateStockAdjustDtlProc(enterPriseCode, stockAdjustDtlList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �݌ɒ������׃f�[�^�X�V
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="stockAdjustDtlList">�݌ɒ������׃f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int UpdateStockAdjustDtlProc(string enterPriseCode, ArrayList stockAdjustDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �S�ăf�[�^���폜����
            status = DeleteStockAdjustDtl(enterPriseCode, stockAdjustDtlList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �o�^����
                status = InsertStockAdjustDtl(enterPriseCode, stockAdjustDtlList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �݌ɒ������׃f�[�^�폜
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="stockAdjustDtlList">�󒍃}�X�^�i�ԗ��j</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int DeleteStockAdjustDtl(string enterPriseCode, ArrayList stockAdjustDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockAdjustDtlProc(enterPriseCode, stockAdjustDtlList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �݌ɒ������׃f�[�^�폜
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="stockAdjustDtlList">�󒍃}�X�^�i�ԗ��j</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int DeleteStockAdjustDtlProc(string enterPriseCode, ArrayList stockAdjustDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockAdjustDtlWork stockAdjustDtlWork in stockAdjustDtlList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "DELETE FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO AND STOCKADJUSTROWNORF=@FINDSTOCKADJUSTROWNO";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);
                SqlParameter findParaStockAdjustRowNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTROWNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaStockAdjustSlipNo.Value = stockAdjustDtlWork.StockAdjustSlipNo;
                findParaStockAdjustRowNo.Value = stockAdjustDtlWork.StockAdjustRowNo;

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
        /// <param name="stockAdjustDtlList">�݌ɒ����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int InsertStockAdjustDtl(string enterPriseCode, ArrayList stockAdjustDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertStockAdjustDtlProc(enterPriseCode, stockAdjustDtlList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �݌ɒ����f�[�^�V�K
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="stockAdjustDtlList">�݌ɒ����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int InsertStockAdjustDtlProc(string enterPriseCode, ArrayList stockAdjustDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockAdjustDtlWork stockAdjustDtlWork in stockAdjustDtlList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "INSERT INTO STOCKADJUSTDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @STOCKADJUSTSLIPNO, @STOCKADJUSTROWNO, @SUPPLIERFORMALSRC, @STOCKSLIPDTLNUMSRC, @ACPAYSLIPCD, @ACPAYTRANSCD, @ADJUSTDATE, @INPUTDAY, @GOODSMAKERCD, @MAKERNAME, @GOODSNO, @GOODSNAME, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @ADJUSTCOUNT, @DTLNOTE, @WAREHOUSECODE, @WAREHOUSENAME, @BLGOODSCODE, @BLGOODSFULLNAME, @WAREHOUSESHELFNO, @LISTPRICEFL, @OPENPRICEDIV, @STOCKPRICETAXEXC)";

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
                SqlParameter paraStockAdjustRowNo = sqlCommand.Parameters.Add("@STOCKADJUSTROWNO", SqlDbType.Int);
                SqlParameter paraSupplierFormalSrc = sqlCommand.Parameters.Add("@SUPPLIERFORMALSRC", SqlDbType.Int);
                SqlParameter paraStockSlipDtlNumSrc = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSRC", SqlDbType.BigInt);
                SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
                SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
                SqlParameter paraAdjustDate = sqlCommand.Parameters.Add("@ADJUSTDATE", SqlDbType.Int);
                SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                SqlParameter paraAdjustCount = sqlCommand.Parameters.Add("@ADJUSTCOUNT", SqlDbType.Float);
                SqlParameter paraDtlNote = sqlCommand.Parameters.Add("@DTLNOTE", SqlDbType.NVarChar);
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                SqlParameter paraListPriceFl = sqlCommand.Parameters.Add("@LISTPRICEFL", SqlDbType.Float);
                SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                SqlParameter paraStockPriceTaxExc = sqlCommand.Parameters.Add("@STOCKPRICETAXEXC", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockAdjustDtlWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockAdjustDtlWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockAdjustDtlWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.SectionCode);
                paraStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.StockAdjustSlipNo);
                paraStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.StockAdjustRowNo);
                paraSupplierFormalSrc.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.SupplierFormalSrc);
                paraStockSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(stockAdjustDtlWork.StockSlipDtlNumSrc);
                paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.AcPaySlipCd);
                paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.AcPayTransCd);
                paraAdjustDate.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.AdjustDate);
                paraInputDay.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.InputDay);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.GoodsMakerCd);
                paraMakerName.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.MakerName);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.GoodsNo);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.GoodsName);
                paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockAdjustDtlWork.StockUnitPriceFl);
                paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockAdjustDtlWork.BfStockUnitPriceFl);
                paraAdjustCount.Value = SqlDataMediator.SqlSetDouble(stockAdjustDtlWork.AdjustCount);
                paraDtlNote.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.DtlNote);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.WarehouseCode);
                paraWarehouseName.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.WarehouseName);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.BLGoodsCode);
                paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.BLGoodsFullName);
                paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.WarehouseShelfNo);
                paraListPriceFl.Value = SqlDataMediator.SqlSetDouble(stockAdjustDtlWork.ListPriceFl);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.OpenPriceDiv);
                paraStockPriceTaxExc.Value = SqlDataMediator.SqlSetInt64(stockAdjustDtlWork.StockPriceTaxExc);

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

        // ----- DEL 2011/11/01 xupz---------->>>>>
        ///// <summary>
        ///// �݌ɒ������׃f�[�^�̌�������
        ///// </summary>
        ///// <param name="enterpriseCodes">��ƃR�[�h</param>
        ///// <param name="beginningDate">�J�n���t</param>
        ///// <param name="endingDate">�I�����t</param>
        ///// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        ///// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        ///// <param name="stockAdjustDtlArrList">�݌ɒ������׃f�[�^�I�u�W�F�N�g</param>
        ///// <param name="retMessage">�߂郁�b�Z�[�W</param>
        ///// <param name="sectionCode">sectionCode</param>
        ///// <returns>STATUS</returns>
        //public int SearchStockAdjustDtlSCM(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage, string sectionCode)
        //{
        //    return SearchStockAdjustDtlSCMProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
        //     sqlTransaction, out  stockAdjustDtlArrList, out  retMessage, sectionCode);
        //}

        ///// <summary>
        ///// �݌ɒ������׃f�[�^�̌�������
        ///// </summary>
        ///// <param name="enterpriseCodes">��ƃR�[�h</param>
        ///// <param name="beginningDate">�J�n���t</param>
        ///// <param name="endingDate">�I�����t</param>
        ///// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        ///// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        ///// <param name="stockAdjustDtlArrList">�݌ɒ������׃f�[�^�I�u�W�F�N�g</param>
        ///// <param name="retMessage">�߂郁�b�Z�[�W</param>
        ///// <param name="sectionCode">sectionCode</param>
        ///// <returns>STATUS</returns>
        //private int SearchStockAdjustDtlSCMProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage, string sectionCode)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    stockAdjustDtlArrList = new ArrayList();
        //    retMessage = string.Empty;
        //    string sqlStr = string.Empty;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;

        //    try
        //    {
        //        sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //        sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF FROM STOCKADJUSTDTLRF WHERE SECTIONCODERF=@FINDSECTIONCODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

        //        //Prameter�I�u�W�F�N�g�̍쐬
        //        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
        //        SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
        //        SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

        //        //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);
        //        findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
        //        findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

        //        // �݌ɒ������׃f�[�^�pSQL
        //        sqlCommand.CommandText = sqlStr;
        //        // �ǂݍ���
        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            stockAdjustDtlArrList.Add(this.CopyToStockAdjustDtlFromReader(ref myReader));
        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        base.WriteErrorLog(ex, "APStockAdjustDtlDB.SearchStockAdjustDtl Exception=" + ex.Message);
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
        // ----- DEL 2011/11/01 xupz----------<<<<<

        // ----- ADD 2011/11/01 xupz---------->>>>>
		/// <summary>
		/// �݌ɒ������׃f�[�^�̌�������
		/// </summary>
		/// <param name="enterpriseCodes">��ƃR�[�h</param>
		/// <param name="beginningDate">�J�n���t</param>
		/// <param name="endingDate">�I�����t</param>
		/// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
		/// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
		/// <param name="stockAdjustDtlArrList">�݌ɒ������׃f�[�^�I�u�W�F�N�g</param>
		/// <param name="retMessage">�߂郁�b�Z�[�W</param>
		/// <param name="sectionCode">sectionCode</param>
		/// <returns>STATUS</returns>
        //public int SearchStockAdjustDtlSCM(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,  // DEL 2011/11/30
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage, string sectionCode)  // DEL 2011/11/30
        //public int SearchStockAdjustDtlSCM(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, SqlConnection sqlConnection,  // ADD 2011/11/30 // DEL 2011/12/06
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage, string sectionCode)  // ADD 2011/11/30  // DEL 2011/12/06
        public int SearchStockAdjustDtlSCM(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, Int64 endingDateTicks, SqlConnection sqlConnection,  // ADD 2011/12/06
    SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage, string sectionCode)  // ADD 2011/12/06
		{
            //return SearchStockAdjustDtlSCMProc(sendMesExtraConDiv,enterpriseCodes, beginningDate, endingDate, syncExecDate, sqlConnection, // DEL 2011/12/06
            // sqlTransaction, out  stockAdjustDtlArrList, out  retMessage, sectionCode);  // DEL 2011/12/06
            return SearchStockAdjustDtlSCMProc(sendMesExtraConDiv, enterpriseCodes, beginningDate, endingDate, syncExecDate, endingDateTicks, sqlConnection, // ADD 2011/12/06
                sqlTransaction, out  stockAdjustDtlArrList, out  retMessage, sectionCode); // ADD 2011/12/06
		}

		/// <summary>
		/// �݌ɒ������׃f�[�^�̌�������
		/// </summary>
		/// <param name="enterpriseCodes">��ƃR�[�h</param>
		/// <param name="beginningDate">�J�n���t</param>
		/// <param name="endingDate">�I�����t</param>
		/// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
		/// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
		/// <param name="stockAdjustDtlArrList">�݌ɒ������׃f�[�^�I�u�W�F�N�g</param>
		/// <param name="retMessage">�߂郁�b�Z�[�W</param>
		/// <param name="sectionCode">sectionCode</param>
		/// <returns>STATUS</returns>
        //private int SearchStockAdjustDtlSCMProc(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,  // DEL 2011/11/30
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage, string sectionCode)  // DEL 2011/11/30
        //private int SearchStockAdjustDtlSCMProc(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, SqlConnection sqlConnection,  // ADD 2011/11/30
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage, string sectionCode)  // ADD 2011/11/30 // DEL 2011/12/06
        private int SearchStockAdjustDtlSCMProc(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, Int64 endingDateTicks, SqlConnection sqlConnection,  // ADD 2011/11/30
            SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage, string sectionCode)  // ADD 2011/12/06
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			stockAdjustDtlArrList = new ArrayList();
			retMessage = string.Empty;
			string sqlStr = string.Empty;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try
			{
				sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);   
                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF FROM STOCKADJUSTDTLRF WHERE SECTIONCODERF=@FINDSECTIONCODE";
                //�f�[�^���M���o�����敪���u�����v�̏ꍇ
                if (sendMesExtraConDiv == 0) 
                {
                    //�݌ɒ������׃f�[�^.�X�V����
                    sqlStr = sqlStr + " AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                }
                //�f�[�^���M���o�����敪���u�`�[���t�v�̏ꍇ
                else if (sendMesExtraConDiv == 1) 
                {
                    //�݌ɒ������׃f�[�^.�������t
                    //sqlStr = sqlStr + " AND ADJUSTDATERF >= @UPDATEDATETIMEBEGRF AND ADJUSTDATERF <= @UPDATEDATETIMEENDRF ";  // DEL 2011/11/30
                    sqlStr = sqlStr + " AND (( ADJUSTDATERF >= @UPDATEDATETIMEBEGRF AND ADJUSTDATERF <= @UPDATEDATETIMEENDRF) "; // ADD 2011/11/30

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
				SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
				SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
				SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);
				findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
				findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // ----- ADD 2011/11/30 tanh---------->>>>>
                //�f�[�^���M���o�����敪���u�`�[�敪�v�̏ꍇ
                if (sendMesExtraConDiv == 1)
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

				// �݌ɒ������׃f�[�^�pSQL
				sqlCommand.CommandText = sqlStr;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // �ǂݍ���
				myReader = sqlCommand.ExecuteReader();

				while (myReader.Read())
				{
					stockAdjustDtlArrList.Add(this.CopyToStockAdjustDtlFromReader(ref myReader));
				}

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex)
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				base.WriteErrorLog(ex, "APStockAdjustDtlDB.SearchStockAdjustDtl Exception=" + ex.Message);
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
		/// �N���X�i�[���� Reader �� stockAdjustDtlWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <returns>�I�u�W�F�N�g</returns>
		/// <remarks>
		/// <br>Programmer : ����</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		private APStockAdjustDtlWork CopyToStockAdjustDtlFromReader(ref SqlDataReader myReader)
		{
			APStockAdjustDtlWork stockAdjustDtlWork = new APStockAdjustDtlWork();

			this.CopyToStockAdjustDtlFromReader(ref myReader, ref stockAdjustDtlWork);

			return stockAdjustDtlWork;
		}

		/// <summary>
		/// �N���X�i�[���� Reader �� stockAdjustDtlWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="stockAdjustDtlWork">stockAdjustDtlWork �I�u�W�F�N�g</param>
		/// <returns>void</returns>
		/// <remarks>
		/// <br>Programmer : ����</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		private void CopyToStockAdjustDtlFromReader(ref SqlDataReader myReader, ref APStockAdjustDtlWork stockAdjustDtlWork)
		{
			if (myReader != null && stockAdjustDtlWork != null)
			{
				# region �N���X�֊i�[
				stockAdjustDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				stockAdjustDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				stockAdjustDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				stockAdjustDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				stockAdjustDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				stockAdjustDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				stockAdjustDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				stockAdjustDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				stockAdjustDtlWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
				stockAdjustDtlWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF"));
				stockAdjustDtlWork.StockAdjustRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTROWNORF"));
				stockAdjustDtlWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));
				stockAdjustDtlWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));
				stockAdjustDtlWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
				stockAdjustDtlWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
				stockAdjustDtlWork.AdjustDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
				stockAdjustDtlWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAYRF"));
				stockAdjustDtlWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
				stockAdjustDtlWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
				stockAdjustDtlWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
				stockAdjustDtlWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
				stockAdjustDtlWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
				stockAdjustDtlWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
				stockAdjustDtlWork.AdjustCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
				stockAdjustDtlWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
				stockAdjustDtlWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
				stockAdjustDtlWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
				stockAdjustDtlWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
				stockAdjustDtlWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
				stockAdjustDtlWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
				stockAdjustDtlWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
				stockAdjustDtlWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
				stockAdjustDtlWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
				# endregion
			}
		}

		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
    }
}