//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^��M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
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
    /// ���㌎���W�v�f�[�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���㌎���W�v�f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCMTtlSalesSlipDB : RemoteDB
    {
        /// <summary>
        /// ���㌎���W�v�f�[�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCMTtlSalesSlipDB()
            : base("PMKYO07551D", "Broadleaf.Application.Remoting.ParamData.DCMTtlSalesSlipWork", "MTTLSALESSLIPRF")
        {

        }
        #region [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
        // DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
/*
        # region [Read]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// ���㌎���W�v�f�[�^�f�[�^�擾
        /// </summary>
        /// <param name="mTtlSalesSlipList">���㌎���W�v�f�[�^�f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int Search(out ArrayList mTtlSalesSlipList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  mTtlSalesSlipList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// ���㌎���W�v�f�[�^�f�[�^�擾
        /// </summary>
        /// <param name="mTtlSalesSlipList">���㌎���W�v�f�[�^�f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList mTtlSalesSlipList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            mTtlSalesSlipList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPSECCODERF, ADDUPYEARMONTHRF, RSLTTTLDIVCDRF, EMPLOYEEDIVCDRF, EMPLOYEECODERF, CUSTOMERCODERF, SUPPLIERCDRF, SALESCODERF, SALESTIMESRF, TOTALSALESCOUNTRF, SALESMONEYRF, SALESRETGOODSPRICERF, DISCOUNTPRICERF, GROSSPROFITRF FROM MTTLSALESSLIPRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";

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
                mTtlSalesSlipList.Add(this.CopyToMTtlSalesSlipWorkFromReader(ref myReader));
            }

            if (mTtlSalesSlipList.Count > 0)
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
        /// �N���X�i�[���� Reader �� acceptOdrCarWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private DCMTtlSalesSlipWork CopyToMTtlSalesSlipWorkFromReader(ref SqlDataReader myReader)
        {
            DCMTtlSalesSlipWork mTtlSalesSlipWork = new DCMTtlSalesSlipWork();

            this.CopyToMTtlSalesSlipWorkFromReader(ref myReader, ref mTtlSalesSlipWork);

            return mTtlSalesSlipWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� mTtlSalesSlipWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mTtlSalesSlipWork">mTtlSalesSlipWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private void CopyToMTtlSalesSlipWorkFromReader(ref SqlDataReader myReader, ref DCMTtlSalesSlipWork mTtlSalesSlipWork)
        {
            if (myReader != null && mTtlSalesSlipWork != null)
            {
                # region �N���X�֊i�[
                mTtlSalesSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                mTtlSalesSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                mTtlSalesSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                mTtlSalesSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                mTtlSalesSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                mTtlSalesSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                mTtlSalesSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                mTtlSalesSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                mTtlSalesSlipWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                mTtlSalesSlipWork.AddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                mTtlSalesSlipWork.RsltTtlDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RSLTTTLDIVCDRF"));
                mTtlSalesSlipWork.EmployeeDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYEEDIVCDRF"));
                mTtlSalesSlipWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                mTtlSalesSlipWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                mTtlSalesSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                mTtlSalesSlipWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                mTtlSalesSlipWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMESRF"));
                mTtlSalesSlipWork.TotalSalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNTRF"));
                mTtlSalesSlipWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYRF"));
                mTtlSalesSlipWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                mTtlSalesSlipWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                mTtlSalesSlipWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITRF"));
                # endregion
            }
        }

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// ���㌎���W�v�f�[�^�폜
        /// </summary>
        /// <param name="dcMTtlSalesSlipWorkList">���㌎���W�v�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Delete(ArrayList dcMTtlSalesSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcMTtlSalesSlipWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// ���㌎���W�v�f�[�^�폜
        /// </summary>
        /// <param name="dcMTtlSalesSlipWorkList">���㌎���W�v�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcMTtlSalesSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCMTtlSalesSlipWork dcMTtlSalesSlipWork in dcMTtlSalesSlipWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Delete�R�}���h�̐���
                sqlCommand.CommandText = "DELETE FROM MTTLSALESSLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH AND RSLTTTLDIVCDRF=@FINDRSLTTTLDIVCD AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD AND EMPLOYEECODERF=@FINDEMPLOYEECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND SUPPLIERCDRF=@FINDSUPPLIERCD AND SALESCODERF=@FINDSALESCODE";
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);
                SqlParameter findParaRsltTtlDivCd = sqlCommand.Parameters.Add("@FINDRSLTTTLDIVCD", SqlDbType.Int);
                SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);
                SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = dcMTtlSalesSlipWork.EnterpriseCode;
                findParaAddUpSecCode.Value = dcMTtlSalesSlipWork.AddUpSecCode;
                findParaAddUpYearMonth.Value = dcMTtlSalesSlipWork.AddUpYearMonth;
                findParaRsltTtlDivCd.Value = dcMTtlSalesSlipWork.RsltTtlDivCd;
                findParaEmployeeDivCd.Value = dcMTtlSalesSlipWork.EmployeeDivCd;
                findParaEmployeeCode.Value = dcMTtlSalesSlipWork.EmployeeCode;
                findParaCustomerCode.Value = dcMTtlSalesSlipWork.CustomerCode;
                findParaSupplierCd.Value = dcMTtlSalesSlipWork.SupplierCd;
                findParaSalesCode.Value = dcMTtlSalesSlipWork.SalesCode;

                // ���㌎���W�v�f�[�^���폜����
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// ���㌎���W�v�f�[�^�o�^
        /// </summary>
        /// <param name="dcMTtlSalesSlipWorkList">���㌎���W�v�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Insert(ArrayList dcMTtlSalesSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcMTtlSalesSlipWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// ���㌎���W�v�f�[�^�o�^
        /// </summary>
        /// <param name="dcMTtlSalesSlipWorkList">���㌎���W�v�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcMTtlSalesSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCMTtlSalesSlipWork dcMTtlSalesSlipWork in dcMTtlSalesSlipWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Delete�R�}���h�̐���
                sqlCommand.CommandText = "INSERT INTO MTTLSALESSLIPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPSECCODERF, ADDUPYEARMONTHRF, RSLTTTLDIVCDRF, EMPLOYEEDIVCDRF, EMPLOYEECODERF, CUSTOMERCODERF, SUPPLIERCDRF, SALESCODERF, SALESTIMESRF, TOTALSALESCOUNTRF, SALESMONEYRF, SALESRETGOODSPRICERF, DISCOUNTPRICERF, GROSSPROFITRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ADDUPSECCODE, @ADDUPYEARMONTH, @RSLTTTLDIVCD, @EMPLOYEEDIVCD, @EMPLOYEECODE, @CUSTOMERCODE, @SUPPLIERCD, @SALESCODE, @SALESTIMES, @TOTALSALESCOUNT, @SALESMONEY, @SALESRETGOODSPRICE, @DISCOUNTPRICE, @GROSSPROFIT)";
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
                SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                SqlParameter paraSalesTimes = sqlCommand.Parameters.Add("@SALESTIMES", SqlDbType.Int);
                SqlParameter paraTotalSalesCount = sqlCommand.Parameters.Add("@TOTALSALESCOUNT", SqlDbType.Float);
                SqlParameter paraSalesMoney = sqlCommand.Parameters.Add("@SALESMONEY", SqlDbType.BigInt);
                SqlParameter paraSalesRetGoodsPrice = sqlCommand.Parameters.Add("@SALESRETGOODSPRICE", SqlDbType.BigInt);
                SqlParameter paraDiscountPrice = sqlCommand.Parameters.Add("@DISCOUNTPRICE", SqlDbType.BigInt);
                SqlParameter paraGrossProfit = sqlCommand.Parameters.Add("@GROSSPROFIT", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcMTtlSalesSlipWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcMTtlSalesSlipWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcMTtlSalesSlipWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcMTtlSalesSlipWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcMTtlSalesSlipWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcMTtlSalesSlipWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcMTtlSalesSlipWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcMTtlSalesSlipWork.LogicalDeleteCode);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(dcMTtlSalesSlipWork.AddUpSecCode);
                paraAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(dcMTtlSalesSlipWork.AddUpYearMonth);
                paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(dcMTtlSalesSlipWork.RsltTtlDivCd);
                paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(dcMTtlSalesSlipWork.EmployeeDivCd);
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(dcMTtlSalesSlipWork.EmployeeCode);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dcMTtlSalesSlipWork.CustomerCode);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(dcMTtlSalesSlipWork.SupplierCd);
                paraSalesCode.Value = SqlDataMediator.SqlSetInt32(dcMTtlSalesSlipWork.SalesCode);
                paraSalesTimes.Value = SqlDataMediator.SqlSetInt32(dcMTtlSalesSlipWork.SalesTimes);
                paraTotalSalesCount.Value = SqlDataMediator.SqlSetDouble(dcMTtlSalesSlipWork.TotalSalesCount);
                paraSalesMoney.Value = SqlDataMediator.SqlSetInt64(dcMTtlSalesSlipWork.SalesMoney);
                paraSalesRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(dcMTtlSalesSlipWork.SalesRetGoodsPrice);
                paraDiscountPrice.Value = SqlDataMediator.SqlSetInt64(dcMTtlSalesSlipWork.DiscountPrice);
                paraGrossProfit.Value = SqlDataMediator.SqlSetInt64(dcMTtlSalesSlipWork.GrossProfit);

                // ���㌎���W�v�f�[�^��o�^����
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

 */
// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        #endregion [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
    }
}
