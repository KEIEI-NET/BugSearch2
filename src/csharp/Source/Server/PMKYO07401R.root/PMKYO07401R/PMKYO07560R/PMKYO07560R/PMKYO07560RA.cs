//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   DC���o�E�X�VDB����N���X
//                  :   PMKYO07560R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   ���m
// Date             :   2009.3.30
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �C �� ��  2009/06/11  �C�����e : R�N���X��public Method��SQL�������ʖ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/21  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C �� ��  2012/03/16  �C�����e : �^�C���A�E�g�Ή�(30�b��600�b)
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using System.Data;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�ʔ��㌎���W�v�f�[�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�ʔ��㌎���W�v�f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCGoodsMTtlSaSlipDB : RemoteDB
    {
        /// <summary>
        /// ���i�ʔ��㌎���W�v�f�[�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCGoodsMTtlSaSlipDB()
            : base("PMKYO07561D", "Broadleaf.Application.Remoting.ParamData.DCGoodsMTtlSaSlipWork", "GOODSMTTLSASLIPRF")
        {

        }
        #region [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
        // DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
/*
        # region [Read]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// ���i�ʔ��㌎���W�v�f�[�^�擾
        /// </summary>
        /// <param name="goodsMTtlSaSlipList">���i�ʔ��㌎���W�v�f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int Search(out ArrayList goodsMTtlSaSlipList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  goodsMTtlSaSlipList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// ���i�ʔ��㌎���W�v�f�[�^�擾
        /// </summary>
        /// <param name="goodsMTtlSaSlipList">���i�ʔ��㌎���W�v�f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList goodsMTtlSaSlipList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            goodsMTtlSaSlipList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPSECCODERF, ADDUPYEARMONTHRF, RSLTTTLDIVCDRF, EMPLOYEECODERF, CUSTOMERCODERF, BLGOODSCODERF, GOODSMAKERCDRF, GOODSNORF, SUPPLIERCDRF, SALESTIMESRF, TOTALSALESCOUNTRF, SALESMONEYRF, SALESRETGOODSPRICERF, DISCOUNTPRICERF, GROSSPROFITRF FROM GOODSMTTLSASLIPRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME", SqlDbType.BigInt);
            SqlParameter findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME", SqlDbType.BigInt);
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaUpdateEndDateTime.Value = receiveDataWork.StartDateTime;
            findParaUpdateStartDateTime.Value = receiveDataWork.EndDateTime;
            findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;

            // SQL��
			sqlCommand.CommandText = sqlText;
            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {
                goodsMTtlSaSlipList.Add(this.CopyToGoodsMTtlSaSlipWorkFromReader(ref myReader));
            }

            if (goodsMTtlSaSlipList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

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


        /// <summary>
        /// �N���X�i�[���� Reader �� goodsMTtlSaSlipWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private DCGoodsMTtlSaSlipWork CopyToGoodsMTtlSaSlipWorkFromReader(ref SqlDataReader myReader)
        {
            DCGoodsMTtlSaSlipWork goodsMTtlSaSlipWork = new DCGoodsMTtlSaSlipWork();

            this.CopyToGoodsMTtlSaSlipWorkFromReader(ref myReader, ref goodsMTtlSaSlipWork);

            return goodsMTtlSaSlipWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� goodsMTtlSaSlipWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="goodsMTtlSaSlipWork">goodsMTtlSaSlipWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private void CopyToGoodsMTtlSaSlipWorkFromReader(ref SqlDataReader myReader, ref DCGoodsMTtlSaSlipWork goodsMTtlSaSlipWork)
        {
            if (myReader != null && goodsMTtlSaSlipWork != null)
            {
                # region �N���X�֊i�[
                goodsMTtlSaSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                goodsMTtlSaSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                goodsMTtlSaSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                goodsMTtlSaSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                goodsMTtlSaSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                goodsMTtlSaSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                goodsMTtlSaSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                goodsMTtlSaSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                goodsMTtlSaSlipWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                goodsMTtlSaSlipWork.AddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                goodsMTtlSaSlipWork.RsltTtlDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RSLTTTLDIVCDRF"));
                goodsMTtlSaSlipWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                goodsMTtlSaSlipWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                goodsMTtlSaSlipWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                goodsMTtlSaSlipWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                goodsMTtlSaSlipWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                goodsMTtlSaSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                goodsMTtlSaSlipWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMESRF"));
                goodsMTtlSaSlipWork.TotalSalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNTRF"));
                goodsMTtlSaSlipWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYRF"));
                goodsMTtlSaSlipWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                goodsMTtlSaSlipWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                goodsMTtlSaSlipWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITRF"));
                # endregion
            }
        }

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// ���i�ʔ��㌎���W�v�f�[�^�폜
        /// </summary>
        /// <param name="dcGoodsMTtlSaSlipWorkList">���i�ʔ��㌎���W�v�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Delete(ArrayList dcGoodsMTtlSaSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcGoodsMTtlSaSlipWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// ���i�ʔ��㌎���W�v�f�[�^�폜
        /// </summary>
        /// <param name="dcGoodsMTtlSaSlipWorkList">���i�ʔ��㌎���W�v�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcGoodsMTtlSaSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCGoodsMTtlSaSlipWork dcGoodsMTtlSaSlipWork in dcGoodsMTtlSaSlipWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Delete�R�}���h�̐���
                sqlCommand.CommandText = "DELETE FROM GOODSMTTLSASLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH AND RSLTTTLDIVCDRF=@FINDRSLTTTLDIVCD AND EMPLOYEECODERF=@FINDEMPLOYEECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND BLGOODSCODERF=@FINDBLGOODSCODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND SUPPLIERCDRF=@FINDSUPPLIERCD";
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);
                SqlParameter findParaRsltTtlDivCd = sqlCommand.Parameters.Add("@FINDRSLTTTLDIVCD", SqlDbType.Int);
                SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = dcGoodsMTtlSaSlipWork.EnterpriseCode;
                findParaAddUpSecCode.Value = dcGoodsMTtlSaSlipWork.AddUpSecCode;
                findParaAddUpYearMonth.Value = dcGoodsMTtlSaSlipWork.AddUpYearMonth;
                findParaRsltTtlDivCd.Value = dcGoodsMTtlSaSlipWork.RsltTtlDivCd;
                findParaEmployeeCode.Value = dcGoodsMTtlSaSlipWork.EmployeeCode;
                findParaCustomerCode.Value = dcGoodsMTtlSaSlipWork.CustomerCode;
                findParaBLGoodsCode.Value = dcGoodsMTtlSaSlipWork.BLGoodsCode;
                findParaGoodsMakerCd.Value = dcGoodsMTtlSaSlipWork.GoodsMakerCd;
                findParaGoodsNo.Value = dcGoodsMTtlSaSlipWork.GoodsNo;
                findParaSupplierCd.Value = dcGoodsMTtlSaSlipWork.SupplierCd;

                // ���i�ʔ��㌎���W�v�f�[�^���폜����
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// ���i�ʔ��㌎���W�v�f�[�^�o�^
        /// </summary>
        /// <param name="dcGoodsMTtlSaSlipWorkList">���i�ʔ��㌎���W�v�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Insert(ArrayList dcGoodsMTtlSaSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcGoodsMTtlSaSlipWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// ���i�ʔ��㌎���W�v�f�[�^�o�^
        /// </summary>
        /// <param name="dcGoodsMTtlSaSlipWorkList">���i�ʔ��㌎���W�v�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcGoodsMTtlSaSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCGoodsMTtlSaSlipWork dcGoodsMTtlSaSlipWork in dcGoodsMTtlSaSlipWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Delete�R�}���h�̐���
                sqlCommand.CommandText = "INSERT INTO GOODSMTTLSASLIPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPSECCODERF, ADDUPYEARMONTHRF, RSLTTTLDIVCDRF, EMPLOYEECODERF, CUSTOMERCODERF, BLGOODSCODERF, GOODSMAKERCDRF, GOODSNORF, SUPPLIERCDRF, SALESTIMESRF, TOTALSALESCOUNTRF, SALESMONEYRF, SALESRETGOODSPRICERF, DISCOUNTPRICERF, GROSSPROFITRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ADDUPSECCODE, @ADDUPYEARMONTH, @RSLTTTLDIVCD, @EMPLOYEECODE, @CUSTOMERCODE, @BLGOODSCODE, @GOODSMAKERCD, @GOODSNO, @SUPPLIERCD, @SALESTIMES, @TOTALSALESCOUNT, @SALESMONEY, @SALESRETGOODSPRICE, @DISCOUNTPRICE, @GROSSPROFIT)";
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                SqlParameter paraRsltTtlDivCd = sqlCommand.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraSalesTimes = sqlCommand.Parameters.Add("@SALESTIMES", SqlDbType.Int);
                SqlParameter paraTotalSalesCount = sqlCommand.Parameters.Add("@TOTALSALESCOUNT", SqlDbType.Float);
                SqlParameter paraSalesMoney = sqlCommand.Parameters.Add("@SALESMONEY", SqlDbType.BigInt);
                SqlParameter paraSalesRetGoodsPrice = sqlCommand.Parameters.Add("@SALESRETGOODSPRICE", SqlDbType.BigInt);
                SqlParameter paraDiscountPrice = sqlCommand.Parameters.Add("@DISCOUNTPRICE", SqlDbType.BigInt);
                SqlParameter paraGrossProfit = sqlCommand.Parameters.Add("@GROSSPROFIT", SqlDbType.BigInt);


                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcGoodsMTtlSaSlipWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcGoodsMTtlSaSlipWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcGoodsMTtlSaSlipWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcGoodsMTtlSaSlipWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcGoodsMTtlSaSlipWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcGoodsMTtlSaSlipWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcGoodsMTtlSaSlipWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcGoodsMTtlSaSlipWork.LogicalDeleteCode);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(dcGoodsMTtlSaSlipWork.AddUpSecCode);
                paraAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(dcGoodsMTtlSaSlipWork.AddUpYearMonth);
                paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(dcGoodsMTtlSaSlipWork.RsltTtlDivCd);
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(dcGoodsMTtlSaSlipWork.EmployeeCode);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dcGoodsMTtlSaSlipWork.CustomerCode);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(dcGoodsMTtlSaSlipWork.BLGoodsCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(dcGoodsMTtlSaSlipWork.GoodsMakerCd);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(dcGoodsMTtlSaSlipWork.GoodsNo);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(dcGoodsMTtlSaSlipWork.SupplierCd);
                paraSalesTimes.Value = SqlDataMediator.SqlSetInt32(dcGoodsMTtlSaSlipWork.SalesTimes);
                paraTotalSalesCount.Value = SqlDataMediator.SqlSetDouble(dcGoodsMTtlSaSlipWork.TotalSalesCount);
                paraSalesMoney.Value = SqlDataMediator.SqlSetInt64(dcGoodsMTtlSaSlipWork.SalesMoney);
                paraSalesRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(dcGoodsMTtlSaSlipWork.SalesRetGoodsPrice);
                paraDiscountPrice.Value = SqlDataMediator.SqlSetInt64(dcGoodsMTtlSaSlipWork.DiscountPrice);
                paraGrossProfit.Value = SqlDataMediator.SqlSetInt64(dcGoodsMTtlSaSlipWork.GrossProfit);

                // ���i�ʔ��㌎���W�v�f�[�^��o�^����
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

*/
// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        #endregion [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
    }
}
