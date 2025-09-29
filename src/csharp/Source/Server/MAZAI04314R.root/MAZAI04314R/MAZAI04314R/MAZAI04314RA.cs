
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ɏ󕥗�������DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɏ󕥗��������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21015�@�����@�F��</br>
    /// <br>Date       : 2007.01.18</br>
    /// <br></br>
    /// <br>Update Note: 2007.12.04  980081 �R�c ���F</br>
    /// <br>           : ���ʊ�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2008.02.12  980081 �R�c ���F</br>
    /// <br>           : �L���敪�̃`�F�b�N���ڂ�ύX</br>
    /// <br></br>
    /// <br>Update Note: 2008.06.30  20081</br>
    /// <br>           : �o�l.�m�r�p�ɕύX</br>
    /// <br>Update Note: 2009.04.08  22008</br>
    /// <br>           : MANTIS 12997�A13092</br>
    /// <br>UpdateNote�@ : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
    /// <br>Update Note: 2010/11/15  �{�w�C��</br>
    /// <br>           : PM1014�̑Ή��̂o�l�V�ɍ��킹�Ďd�l�ύX</br>
    /// <br>Update Note: 2011/03/22 ������</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// <br>Update Note: 2012/12/14 �������n</br>
    /// <br>             �݌ɓ��o�ɏƉ�^�C���A�E�g�G���[�Ή�</br>
    /// <br>Update Note: 2013/01/15 FSI���� �G</br>
    /// <br>             �Ǘ�No.541 ���|�I�v�V�����ǉ��Ή�</br>
    /// <br>Update Note: 2017/10/10 3H ������</br>
    /// <br>             �݌ɓ��o�ɏƉ�̑��x���ǑΉ�</br>
    /// </remarks>
    [Serializable]
    public class StockAcPayHisSearchDB : RemoteDB, IStockAcPayHisSearchDB
    {
        //private StockAcPayHistDB _stockAcPayHistDB = new StockAcPayHistDB();

        private enum ct_ProcMode
        {
            StockAcPayHis = 1,
            StockAcPayHisDt = 2
        }

        /// <summary>
        /// �݌Ɏ󕥗�������DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// </remarks>
        public StockAcPayHisSearchDB()
            :
            base("MAZAI04316D", "Broadleaf.Application.Remoting.ParamData.StockAcPayHisSearchWork", "STOCKACPAYHISTRF")
        {
        }

        private MonthlyAddUpDB _monthlyAddUpDB = new MonthlyAddUpDB();
        private TtlDayCalcDB _ttlDayCalcDB = new TtlDayCalcDB();
        private CompanyInfDB _companyInfDB = new CompanyInfDB();

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ󕥗����������LIST��߂��܂�
        /// </summary>
        /// <param name="stockAcPayHisSearchWork">��������</param>
        /// <param name="parastockAcPayHisSearchWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ󕥗����������LIST��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        public int Search(out object stockAcPayHisSearchWork, object parastockAcPayHisSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockAcPayHisSearchWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockAcPayHisSearchProc(out stockAcPayHisSearchWork, parastockAcPayHisSearchWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAcPayHisSearchDB.Search");
                stockAcPayHisSearchWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        // 2008.06.30 add start ----------------------------------------------------->>
        /// <summary>
        /// �݌Ɏ󕥗�������LIST�ƍ݌ɓ��o�ɏƉ�w�b�_����߂��܂�
        /// </summary>
        /// <param name="stockAcPayHisSearchWork">��������</param>
        /// <param name="stockCarEnterCarOutRetWork">��������</param>
        /// <param name="parastockAcPayHisSearchWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɏ󕥗�������LIST�ƍ݌ɓ��o�ɏƉ�w�b�_����߂��܂�</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.30</br>
        /// <br>Update Note: 2010/11/15 �{�w�C��</br>
        ///                  �݌Ɏ󕥗��������݂��Ȃ��ꍇ�ł��A�O�����c�ƌ��݌ɐ���\������悤�ɕύX�B</br>
        /// <br>Update Note: 2011/03/22 ������</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        public int Search(out object stockAcPayHisSearchWork, out object stockCarEnterCarOutRetWork, object parastockAcPayHisSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            stockAcPayHisSearchWork = null;
            stockCarEnterCarOutRetWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // ---ADD 2011/03/22---------->>>>>
                StockAcPayHisSearchParaWork stockacpayhissearchWork = new StockAcPayHisSearchParaWork();
                stockacpayhissearchWork = parastockAcPayHisSearchWork as StockAcPayHisSearchParaWork;

                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, stockacpayhissearchWork.EnterpriseCode, "�݌ɓ��o�ɏƉ�", "���o�J�n");
                // ---ADD 2011/03/22----------<<<<<

                // --- UPD 2010/11/15------ >>>>>>
                status = SearchStockAcPayHisSearchProc(out stockAcPayHisSearchWork, parastockAcPayHisSearchWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    status = SearchStockCarEnterCarOutSearchProc(out stockCarEnterCarOutRetWork, parastockAcPayHisSearchWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                }
                // --- UPD 2010/11/15------ <<<<<<<

                // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, stockacpayhissearchWork.EnterpriseCode, "�݌ɓ��o�ɏƉ�", "���o�I��");
                // ---ADD 2011/03/22----------<<<<<
                return status;
               
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAcPayHisSearchDB.Search");
                stockAcPayHisSearchWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

        }
        // 2008.06.30 add end -------------------------------------------------------<<

        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ󕥗����������LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objstockAcPayHisSearchWork">��������</param>
        /// <param name="parastockAcPayHisSearchWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ󕥗����������LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        public int SearchStockAcPayHisSearchProc(out object objstockAcPayHisSearchWork, object parastockAcPayHisSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            StockAcPayHisSearchParaWork stockacpayhissearchparaWork = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            ArrayList stockacpayhissearchWorkList = null;
            if (parastockAcPayHisSearchWork != null)
                stockacpayhissearchparaWork = parastockAcPayHisSearchWork as StockAcPayHisSearchParaWork;

            status = SearchStockAcPayHisSearchProc(out stockacpayhissearchWorkList, stockacpayhissearchparaWork, readMode, logicalMode, ref sqlConnection);
            retList.Add(stockacpayhissearchWorkList);

            objstockAcPayHisSearchWork = retList;

            return status;
        }

        // 2008.06.30 add start ----------------------------------------------------->>
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ󕥗����������LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objstockAcPayHisSearchWork">��������</param>
        /// <param name="parastockAcPayHisSearchWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ󕥗����������LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.30</br>
        public int SearchStockAcPayHisSearchProc(out object objstockAcPayHisSearchWork, object parastockAcPayHisSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            StockAcPayHisSearchParaWork stockacpayhissearchparaWork = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            ArrayList stockacpayhissearchWorkList = null;
            if (parastockAcPayHisSearchWork != null)
                stockacpayhissearchparaWork = parastockAcPayHisSearchWork as StockAcPayHisSearchParaWork;

            status = SearchStockAcPayHisSearchProc(out stockacpayhissearchWorkList, stockacpayhissearchparaWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            retList.Add(stockacpayhissearchWorkList);

            objstockAcPayHisSearchWork = retList;

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɓ��o�ɏƉ�̃w�b�_���LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="objstockCarEnterCarOutRetWork">��������</param>
        /// <param name="parastockAcPayHisSearchWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɓ��o�ɏƉ�̃w�b�_���LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.30</br>
        public int SearchStockCarEnterCarOutSearchProc(out object objstockCarEnterCarOutRetWork, object parastockAcPayHisSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            StockAcPayHisSearchParaWork stockacpayhissearchparaWork = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            ArrayList stockCarEnterCarOutRetWorkList = null;
            if (parastockAcPayHisSearchWork != null)
                stockacpayhissearchparaWork = parastockAcPayHisSearchWork as StockAcPayHisSearchParaWork;

            status = SearchStockCarEnterCarOutSearchProc(out stockCarEnterCarOutRetWorkList, stockacpayhissearchparaWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            retList.Add(stockCarEnterCarOutRetWorkList);

            objstockCarEnterCarOutRetWork = retList;

            return status;
        }
        // 2008.06.30 add end -------------------------------------------------------<<
        
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ󕥗����������LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockacpayhissearchWorkList">��������</param>
        /// <param name="stockacpayhissearchparaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ󕥗����������LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        public int SearchStockAcPayHisSearchProc(out ArrayList stockacpayhissearchWorkList, StockAcPayHisSearchParaWork stockacpayhissearchparaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchStockAcPayHisSearchProcProc(out stockacpayhissearchWorkList, stockacpayhissearchparaWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ󕥗����������LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockacpayhissearchWorkList">��������</param>
        /// <param name="stockacpayhissearchparaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ󕥗����������LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br>UpdateNote : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
        /// <br>UpdateNote : 2013/01/15 FSI���� �G�@�Ǘ�No.541 ���|�I�v�V�����ǉ��Ή�</br>
        private int SearchStockAcPayHisSearchProcProc(out ArrayList stockacpayhissearchWorkList, StockAcPayHisSearchParaWork stockacpayhissearchparaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            // ---ADD 2013/01/15----->>>>>
            bool hasStkPay = stockacpayhissearchparaWork.HasStkPay;
            // ---ADD 2013/01/15-----<<<<<

            try
            {
                // ---DEL 2013/01/15----->>>>>
                //sqlCommand = new SqlCommand("SELECT DISTINCT STOCKACPAYHISTRF.* FROM STOCKACPAYHISTRF WITH (READUNCOMMITTED) ", sqlConnection);
                // ---DEL 2013/01/15-----<<<<<

                // ---ADD 2013/01/15----->>>>>
                if (hasStkPay)
                {
                    sqlCommand = new SqlCommand("SELECT DISTINCT STOCKACPAYHISTRF.* FROM STOCKACPAYHISTRF WITH (READUNCOMMITTED) ", sqlConnection);
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT DISTINCT STOCKACPAYHISTRF.IOGOODSDAYRF,STOCKACPAYHISTRF.ADDUPADATERF,STOCKACPAYHISTRF.ACPAYSLIPCDRF,CASE WHEN STOCKADJUSTDTL.STOCKADJUSTSLIPNORF IS NULL THEN STOCKACPAYHISTRF.ACPAYSLIPNUMRF ELSE CAST(STOCKADJUSTDTL.STOCKADJUSTSLIPNORF AS nvarchar) END AS ACPAYSLIPNUMRF,STOCKACPAYHISTRF.ACPAYSLIPROWNORF,STOCKACPAYHISTRF.ACPAYHISTDATETIMERF,STOCKACPAYHISTRF.ACPAYTRANSCDRF,STOCKACPAYHISTRF.INPUTSECTIONCDRF,STOCKACPAYHISTRF.INPUTSECTIONGUIDNMRF,STOCKACPAYHISTRF.INPUTAGENCDRF,STOCKACPAYHISTRF.INPUTAGENNMRF,STOCKACPAYHISTRF.MOVESTATUSRF,STOCKACPAYHISTRF.CUSTSLIPNORF,STOCKACPAYHISTRF.SLIPDTLNUMRF,STOCKACPAYHISTRF.ACPAYNOTERF,STOCKACPAYHISTRF.GOODSMAKERCDRF,STOCKACPAYHISTRF.MAKERNAMERF,STOCKACPAYHISTRF.GOODSNORF,STOCKACPAYHISTRF.GOODSNAMERF,STOCKACPAYHISTRF.BLGOODSCODERF,STOCKACPAYHISTRF.BLGOODSFULLNAMERF,STOCKACPAYHISTRF.SECTIONCODERF,STOCKACPAYHISTRF.SECTIONGUIDENMRF,STOCKACPAYHISTRF.WAREHOUSECODERF,STOCKACPAYHISTRF.WAREHOUSENAMERF,STOCKACPAYHISTRF.SHELFNORF,STOCKACPAYHISTRF.BFSECTIONCODERF,STOCKACPAYHISTRF.BFSECTIONGUIDENMRF,STOCKACPAYHISTRF.BFENTERWAREHCODERF,STOCKACPAYHISTRF.BFENTERWAREHNAMERF,STOCKACPAYHISTRF.BFSHELFNORF,STOCKACPAYHISTRF.AFSECTIONCODERF,STOCKACPAYHISTRF.AFSECTIONGUIDENMRF,STOCKACPAYHISTRF.AFENTERWAREHCODERF,STOCKACPAYHISTRF.AFENTERWAREHNAMERF,STOCKACPAYHISTRF.AFSHELFNORF,STOCKACPAYHISTRF.CUSTOMERCODERF,STOCKACPAYHISTRF.CUSTOMERSNMRF,STOCKACPAYHISTRF.SUPPLIERCDRF,STOCKACPAYHISTRF.SUPPLIERSNMRF,STOCKACPAYHISTRF.ARRIVALCNTRF,STOCKACPAYHISTRF.SHIPMENTCNTRF,STOCKACPAYHISTRF.OPENPRICEDIVRF,STOCKACPAYHISTRF.LISTPRICETAXEXCFLRF,STOCKACPAYHISTRF.STOCKUNITPRICEFLRF,STOCKACPAYHISTRF.STOCKPRICERF,STOCKACPAYHISTRF.SALESUNPRCTAXEXCFLRF,STOCKACPAYHISTRF.SALESMONEYRF,STOCKACPAYHISTRF.SUPPLIERSTOCKRF,STOCKACPAYHISTRF.ACPODRCOUNTRF,STOCKACPAYHISTRF.SALESORDERCOUNTRF,STOCKACPAYHISTRF.MOVINGSUPLISTOCKRF,STOCKACPAYHISTRF.NONADDUPSHIPMCNTRF,STOCKACPAYHISTRF.NONADDUPARRGDSCNTRF,STOCKACPAYHISTRF.SHIPMENTPOSCNTRF,STOCKACPAYHISTRF.PRESENTSTOCKCNTRF FROM STOCKACPAYHISTRF WITH (READUNCOMMITTED) LEFT JOIN STOCKDETAILRF AS STOCKDETAIL WITH (READUNCOMMITTED) ON  STOCKACPAYHISTRF.ENTERPRISECODERF = STOCKDETAIL.ENTERPRISECODERF AND STOCKDETAIL.LOGICALDELETECODERF = 0 AND STOCKDETAIL.SUPPLIERFORMALRF = 0 AND STOCKACPAYHISTRF.ACPAYSLIPNUMRF = STOCKDETAIL.SUPPLIERSLIPNORF AND STOCKACPAYHISTRF.SLIPDTLNUMRF = STOCKDETAIL.STOCKSLIPDTLNUMRF AND STOCKACPAYHISTRF.GOODSNORF = STOCKDETAIL.GOODSNORF AND STOCKACPAYHISTRF.GOODSMAKERCDRF = STOCKDETAIL.GOODSMAKERCDRF AND STOCKACPAYHISTRF.WAREHOUSECODERF = STOCKDETAIL.WAREHOUSECODERF LEFT JOIN STOCKADJUSTDTLRF AS STOCKADJUSTDTL WITH (READUNCOMMITTED) ON  STOCKDETAIL.ENTERPRISECODERF = STOCKADJUSTDTL.ENTERPRISECODERF AND STOCKADJUSTDTL.LOGICALDELETECODERF = 0 AND STOCKDETAIL.STOCKSLIPDTLNUMSRCRF = STOCKADJUSTDTL.STOCKSLIPDTLNUMSRCRF AND STOCKDETAIL.GOODSNORF = STOCKADJUSTDTL.GOODSNORF AND STOCKDETAIL.GOODSMAKERCDRF = STOCKADJUSTDTL.GOODSMAKERCDRF AND STOCKDETAIL.WAREHOUSECODERF = STOCKADJUSTDTL.WAREHOUSECODERF ", sqlConnection);
                }
                // ---ADD 2013/01/15-----<<<<<                
                
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockacpayhissearchparaWork, (int)ct_ProcMode.StockAcPayHis, logicalMode);

                sqlCommand.CommandTimeout = 3600; // Add 2012/12/14
                myReader = sqlCommand.ExecuteReader();

                StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork;
                while (myReader.Read())
                {
                    stockAcPayHisSearchRetWork = CopyToStockAcPayHisSearchRetWorkFromReader(ref myReader);
                    al.Add(stockAcPayHisSearchRetWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            // ---ADD 2010/11/15----->>>>>
            foreach (StockAcPayHisSearchRetWork stockAcPayHSWork in al)
            {
                StockAcPayHisSearchRetWork stockAHisSearchRetWork = stockAcPayHSWork;
                stockacpayhissearchparaWork.St_GoodsNo = stockAHisSearchRetWork.GoodsNo;
                stockacpayhissearchparaWork.Ed_GoodsNo = stockAHisSearchRetWork.GoodsNo;
                stockacpayhissearchparaWork.St_GoodsMakerCd = stockAHisSearchRetWork.GoodsMakerCd;
                stockacpayhissearchparaWork.Ed_GoodsMakerCd = stockAHisSearchRetWork.GoodsMakerCd;
                stockacpayhissearchparaWork.St_WarehouseCode = stockAHisSearchRetWork.WarehouseCode;
                stockacpayhissearchparaWork.Ed_WarehouseCode = stockAHisSearchRetWork.WarehouseCode;
                getStockTotel(stockacpayhissearchparaWork, ref stockAHisSearchRetWork, ref sqlConnection);
            }
            // ---ADD 2010/11/15-----<<<<<
            stockacpayhissearchWorkList = al;
            return status;
        }

        // ---ADD 2010/11/15----->>>>>
        /// <summary>
        /// �O�����c�̎擾
        /// </summary>
        /// <param name="stockacpayhissearchparaWork">�����p�����[�^</param>
        /// <param name="stockAcPayHisSearchRetWork">��������</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �O�����c���擾����</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2010/11/15</br>
        private int getStockTotel(StockAcPayHisSearchParaWork stockacpayhissearchparaWork, ref StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork, ref SqlConnection sqlConnection)
        {
            //��ʊJ�n��I����

            DateTime St_AddupDate;
            if (TDateTime.LongDateToDateTime("YYYYMMDD", stockacpayhissearchparaWork.St_IoGoodsDay) != DateTime.MinValue)
            {
                St_AddupDate = TDateTime.LongDateToDateTime("YYYYMMDD", stockacpayhissearchparaWork.St_IoGoodsDay);
            }
            else
            {
                St_AddupDate = stockacpayhissearchparaWork.St_detInputDay;
            }
            DateTime Ed_AddupDate;
            if (TDateTime.LongDateToDateTime("YYYYMMDD", stockacpayhissearchparaWork.Ed_IoGoodsDay) != DateTime.MinValue)
            {
                Ed_AddupDate = TDateTime.LongDateToDateTime("YYYYMMDD", stockacpayhissearchparaWork.Ed_IoGoodsDay);
            }
            else
            {
                Ed_AddupDate = stockacpayhissearchparaWork.Ed_detInputDay;
            }
            DateTime AddupYearMonth = new DateTime();
            int IntAddupYearMonth = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            #region �O�����c���擾����

            //�݌ɗ����f�[�^���O���c��,�c���擾
            ArrayList CompanySettingList = new ArrayList();
            CompanyInfWork CompanyInfWork = new CompanyInfWork();
            CompanyInfWork.EnterpriseCode = stockacpayhissearchparaWork.EnterpriseCode;
            int status = -1;
            try
            {
                // ���Џ��List�擾
                status = _companyInfDB.Search(out CompanySettingList, CompanyInfWork, ref sqlConnection);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    CompanyInfWork = CompanySettingList[0] as CompanyInfWork;
                    FinYearTableGenerator YearTable = new FinYearTableGenerator(CompanyInfWork);
                    // ��ʊJ�n���̌v��N���擾
                    YearTable.GetYearMonth(St_AddupDate, out AddupYearMonth);
                    IntAddupYearMonth = AddupYearMonth.Year * 100 + AddupYearMonth.Month;
                }

                string sqlText = string.Empty;
                sqlText += " SELECT " + Environment.NewLine;
                sqlText += "    SUM(STOCKTOTALRF) AS STOCKTOTAL" + Environment.NewLine;
                sqlText += " FROM STOCKHISTORYRF" + Environment.NewLine;
                sqlText += " WHERE ADDUPYEARMONTHRF=" + Environment.NewLine;
                sqlText += " ( " + Environment.NewLine;
                sqlText += " 	SELECT " + Environment.NewLine;
                sqlText += " 	    MAX(ADDUPYEARMONTHRF)" + Environment.NewLine;
                sqlText += " 	FROM STOCKHISTORYRF" + Environment.NewLine;
                sqlText += "    WHERE ADDUPYEARMONTHRF<@ADDUPYEARMONTH" + Environment.NewLine;
                if (stockacpayhissearchparaWork.SectionCodes != null && stockacpayhissearchparaWork.SectionCodes[0] == "")
                    sqlText += "      AND SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                sqlText += "      AND WAREHOUSECODERF=@WAREHOUSECODE " + Environment.NewLine;
                sqlText += "      AND GOODSNORF=@GOODSNO " + Environment.NewLine;
                sqlText += "      AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sqlText += "      AND GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                sqlText += " ) " + Environment.NewLine;
                if (stockacpayhissearchparaWork.SectionCodes != null && stockacpayhissearchparaWork.SectionCodes[0] == "")
                    sqlText += " AND SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                sqlText += " AND WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                sqlText += " AND GOODSNORF=@GOODSNO" + Environment.NewLine;
                sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sqlText += " AND GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                SqlParameter paraAddupYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);


                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockacpayhissearchparaWork.EnterpriseCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhissearchparaWork.St_GoodsMakerCd);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockacpayhissearchparaWork.St_GoodsNo);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockacpayhissearchparaWork.St_WarehouseCode);
                paraAddupYearMonth.Value = SqlDataMediator.SqlSetInt32(IntAddupYearMonth);

                if (stockacpayhissearchparaWork.SectionCodes != null && stockacpayhissearchparaWork.SectionCodes[0] != "")
                {
                    string sectionCode = stockacpayhissearchparaWork.SectionCodes[0] as string;
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);
                }

                sqlCommand.CommandTimeout = 3600; // Add 2012/12/14
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stockAcPayHisSearchRetWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTAL"));�@// �O���c
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                #endregion
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        // ---ADD 2010/11/15-----<<<<<

        // 2008.06.30 add start ----------------------------------------------------->>
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ󕥗����������LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockacpayhissearchWorkList">��������</param>
        /// <param name="stockacpayhissearchparaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ󕥗����������LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.30</br>
        public int SearchStockAcPayHisSearchProc(out ArrayList stockacpayhissearchWorkList, StockAcPayHisSearchParaWork stockacpayhissearchparaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchStockAcPayHisSearchProcProc(out stockacpayhissearchWorkList, stockacpayhissearchparaWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ󕥗����������LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockacpayhissearchWorkList">��������</param>
        /// <param name="stockacpayhissearchparaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ󕥗����������LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.30</br>
        /// <br>UpdateNote : 2013/01/15 FSI���� �G�@�Ǘ�No.541 ���|�I�v�V�����ǉ��Ή�</br>
        private int SearchStockAcPayHisSearchProcProc( out ArrayList stockacpayhissearchWorkList, StockAcPayHisSearchParaWork stockacpayhissearchparaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            // ---ADD 2013/01/15----->>>>>
            bool hasStkPay = stockacpayhissearchparaWork.HasStkPay;
            // ---ADD 2013/01/15-----<<<<<

            try
            {
                // ---DEL 2013/01/15----->>>>>
                //sqlCommand = new SqlCommand("SELECT DISTINCT STOCKACPAYHISTRF.* FROM STOCKACPAYHISTRF WITH (READUNCOMMITTED) ", sqlConnection, sqlTransaction);
                // ---DEL 2013/01/15-----<<<<<

                // ---ADD 2013/01/15----->>>>>
                if (hasStkPay)
                {
                    sqlCommand = new SqlCommand("SELECT DISTINCT STOCKACPAYHISTRF.* FROM STOCKACPAYHISTRF WITH (READUNCOMMITTED) ", sqlConnection, sqlTransaction);
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT DISTINCT STOCKACPAYHISTRF.IOGOODSDAYRF,STOCKACPAYHISTRF.ADDUPADATERF,STOCKACPAYHISTRF.ACPAYSLIPCDRF,CASE WHEN STOCKADJUSTDTL.STOCKADJUSTSLIPNORF IS NULL THEN STOCKACPAYHISTRF.ACPAYSLIPNUMRF ELSE CAST(STOCKADJUSTDTL.STOCKADJUSTSLIPNORF AS nvarchar) END AS ACPAYSLIPNUMRF,STOCKACPAYHISTRF.ACPAYSLIPROWNORF,STOCKACPAYHISTRF.ACPAYHISTDATETIMERF,STOCKACPAYHISTRF.ACPAYTRANSCDRF,STOCKACPAYHISTRF.INPUTSECTIONCDRF,STOCKACPAYHISTRF.INPUTSECTIONGUIDNMRF,STOCKACPAYHISTRF.INPUTAGENCDRF,STOCKACPAYHISTRF.INPUTAGENNMRF,STOCKACPAYHISTRF.MOVESTATUSRF,STOCKACPAYHISTRF.CUSTSLIPNORF,STOCKACPAYHISTRF.SLIPDTLNUMRF,STOCKACPAYHISTRF.ACPAYNOTERF,STOCKACPAYHISTRF.GOODSMAKERCDRF,STOCKACPAYHISTRF.MAKERNAMERF,STOCKACPAYHISTRF.GOODSNORF,STOCKACPAYHISTRF.GOODSNAMERF,STOCKACPAYHISTRF.BLGOODSCODERF,STOCKACPAYHISTRF.BLGOODSFULLNAMERF,STOCKACPAYHISTRF.SECTIONCODERF,STOCKACPAYHISTRF.SECTIONGUIDENMRF,STOCKACPAYHISTRF.WAREHOUSECODERF,STOCKACPAYHISTRF.WAREHOUSENAMERF,STOCKACPAYHISTRF.SHELFNORF,STOCKACPAYHISTRF.BFSECTIONCODERF,STOCKACPAYHISTRF.BFSECTIONGUIDENMRF,STOCKACPAYHISTRF.BFENTERWAREHCODERF,STOCKACPAYHISTRF.BFENTERWAREHNAMERF,STOCKACPAYHISTRF.BFSHELFNORF,STOCKACPAYHISTRF.AFSECTIONCODERF,STOCKACPAYHISTRF.AFSECTIONGUIDENMRF,STOCKACPAYHISTRF.AFENTERWAREHCODERF,STOCKACPAYHISTRF.AFENTERWAREHNAMERF,STOCKACPAYHISTRF.AFSHELFNORF,STOCKACPAYHISTRF.CUSTOMERCODERF,STOCKACPAYHISTRF.CUSTOMERSNMRF,STOCKACPAYHISTRF.SUPPLIERCDRF,STOCKACPAYHISTRF.SUPPLIERSNMRF,STOCKACPAYHISTRF.ARRIVALCNTRF,STOCKACPAYHISTRF.SHIPMENTCNTRF,STOCKACPAYHISTRF.OPENPRICEDIVRF,STOCKACPAYHISTRF.LISTPRICETAXEXCFLRF,STOCKACPAYHISTRF.STOCKUNITPRICEFLRF,STOCKACPAYHISTRF.STOCKPRICERF,STOCKACPAYHISTRF.SALESUNPRCTAXEXCFLRF,STOCKACPAYHISTRF.SALESMONEYRF,STOCKACPAYHISTRF.SUPPLIERSTOCKRF,STOCKACPAYHISTRF.ACPODRCOUNTRF,STOCKACPAYHISTRF.SALESORDERCOUNTRF,STOCKACPAYHISTRF.MOVINGSUPLISTOCKRF,STOCKACPAYHISTRF.NONADDUPSHIPMCNTRF,STOCKACPAYHISTRF.NONADDUPARRGDSCNTRF,STOCKACPAYHISTRF.SHIPMENTPOSCNTRF,STOCKACPAYHISTRF.PRESENTSTOCKCNTRF FROM STOCKACPAYHISTRF WITH (READUNCOMMITTED) LEFT JOIN STOCKDETAILRF AS STOCKDETAIL WITH (READUNCOMMITTED) ON  STOCKACPAYHISTRF.ENTERPRISECODERF = STOCKDETAIL.ENTERPRISECODERF AND STOCKDETAIL.LOGICALDELETECODERF = 0 AND STOCKDETAIL.SUPPLIERFORMALRF = 0 AND STOCKACPAYHISTRF.ACPAYSLIPNUMRF = STOCKDETAIL.SUPPLIERSLIPNORF AND STOCKACPAYHISTRF.SLIPDTLNUMRF = STOCKDETAIL.STOCKSLIPDTLNUMRF AND STOCKACPAYHISTRF.GOODSNORF = STOCKDETAIL.GOODSNORF AND STOCKACPAYHISTRF.GOODSMAKERCDRF = STOCKDETAIL.GOODSMAKERCDRF AND STOCKACPAYHISTRF.WAREHOUSECODERF = STOCKDETAIL.WAREHOUSECODERF LEFT JOIN STOCKADJUSTDTLRF AS STOCKADJUSTDTL WITH (READUNCOMMITTED) ON  STOCKDETAIL.ENTERPRISECODERF = STOCKADJUSTDTL.ENTERPRISECODERF AND STOCKADJUSTDTL.LOGICALDELETECODERF = 0 AND STOCKDETAIL.STOCKSLIPDTLNUMSRCRF = STOCKADJUSTDTL.STOCKSLIPDTLNUMSRCRF AND STOCKDETAIL.GOODSNORF = STOCKADJUSTDTL.GOODSNORF AND STOCKDETAIL.GOODSMAKERCDRF = STOCKADJUSTDTL.GOODSMAKERCDRF AND STOCKDETAIL.WAREHOUSECODERF = STOCKADJUSTDTL.WAREHOUSECODERF ", sqlConnection, sqlTransaction);
                }
                // ---ADD 2013/01/15-----<<<<<                

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockacpayhissearchparaWork, (int)ct_ProcMode.StockAcPayHis, logicalMode);

                sqlCommand.CommandTimeout = 3600; // Add 2012/12/14
                myReader = sqlCommand.ExecuteReader();

                StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork;
                while (myReader.Read())
                {
                    stockAcPayHisSearchRetWork = CopyToStockAcPayHisSearchRetWorkFromReader(ref myReader);
                    al.Add(stockAcPayHisSearchRetWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            stockacpayhissearchWorkList = al;

            return status;
        }


        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɓ��o�ɏƉ�̃w�b�_���LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="stockCarEnterCarOutRetWorkList">��������</param>
        /// <param name="stockacpayhissearchparaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɓ��o�ɏƉ�̃w�b�_���LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.30</br>
        public int SearchStockCarEnterCarOutSearchProc(out ArrayList stockCarEnterCarOutRetWorkList, StockAcPayHisSearchParaWork stockacpayhissearchparaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {            
            return this.SearchStockCarEnterCarOutSearchProcProc(out stockCarEnterCarOutRetWorkList, stockacpayhissearchparaWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �������ʃN���X�i�[����
        /// </summary>
        /// <param name="al">���ʊi�[ArrayList</param>
        /// <param name="stockHistoryWorkList">�����X�V���X�g</param>
        private int StockStorage(ref List<StockCarEnterCarOutRetWork> al, ref List<StockHistoryWork> stockHistoryWorkList, StockAcPayHisSearchParaWork stockacpayhissearchparaWork, int i,int month)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;


            List<StockCarEnterCarOutRetWork> bl = new List<StockCarEnterCarOutRetWork>();
            
            //�݌ɗ����i�[����
            foreach (StockHistoryWork st in stockHistoryWorkList)
            {
                StockCarEnterCarOutRetWork stockCarEnterCarOutRetWork = new StockCarEnterCarOutRetWork();

                // ���_�R�[�h
                if (stockacpayhissearchparaWork.SectionCodes != null)
                {
                    string Sec = "";
                    foreach (string Secstr in stockacpayhissearchparaWork.SectionCodes)
                    {
                        if (Sec != "")
                        {
                            Sec += ",";
                        }
                        Sec += "'" + Secstr + "'";
                    }

                    if (Sec != "")
                    {
                        if (Sec.Contains(st.SectionCode.Trim()))
                        {
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                // �q�ɃR�[�h
                if (stockacpayhissearchparaWork.St_WarehouseCode != "")
                {
                    if (stockacpayhissearchparaWork.St_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) == 0 ||
                        stockacpayhissearchparaWork.St_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) < 0)
                    {
                    }
                    else
                    {
                        continue;
                    }
                }
                if (stockacpayhissearchparaWork.Ed_WarehouseCode != "")
                {
                    if (stockacpayhissearchparaWork.Ed_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) == 0 ||
                        stockacpayhissearchparaWork.Ed_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) > 0)
                    {
                    }
                    else
                    {
                        continue;
                    }
                }

                // ���[�J�[�R�[�h
                if (stockacpayhissearchparaWork.St_GoodsMakerCd != 0)
                {
                    if (stockacpayhissearchparaWork.St_GoodsMakerCd == st.GoodsMakerCd ||
                        stockacpayhissearchparaWork.St_GoodsMakerCd < st.GoodsMakerCd)
                    {
                    }
                    else
                    {
                        continue;
                    }
                }
                if (stockacpayhissearchparaWork.Ed_GoodsMakerCd != 0)
                {
                    if (stockacpayhissearchparaWork.Ed_GoodsMakerCd == st.GoodsMakerCd ||
                        stockacpayhissearchparaWork.Ed_GoodsMakerCd > st.GoodsMakerCd)
                    {
                    }
                    else
                    {
                        continue;
                    }
                }

                // �i��
                if (stockacpayhissearchparaWork.St_GoodsNo != "")
                {
                    if (stockacpayhissearchparaWork.St_GoodsNo.CompareTo(st.GoodsNo.Trim()) == 0 ||
                        stockacpayhissearchparaWork.St_GoodsNo.CompareTo(st.GoodsNo.Trim()) < 0)
                    {
                    }
                    else
                    {
                        continue;
                    }
                }
                if (stockacpayhissearchparaWork.Ed_GoodsNo != "")
                {
                    if (stockacpayhissearchparaWork.Ed_GoodsNo.CompareTo(st.GoodsNo.Trim()) == 0 ||
                        stockacpayhissearchparaWork.Ed_GoodsNo.CompareTo(st.GoodsNo.Trim()) > 0)
                    {
                    }
                    else
                    {
                        continue;
                    }
                }
                if (al.Count == 0)
                {
                    stockCarEnterCarOutRetWork.StockTotal += st.StockTotal;              // ���݌��͍��Z
                    if (i == (month-2)) stockCarEnterCarOutRetWork.RemainCount += st.StockTotal; // �c���͉�ʊJ�n���̑O���̂�
                    al.Add(stockCarEnterCarOutRetWork);
                }
                else
                {
                    al[0].StockTotal += st.StockTotal;              // ���݌��͍��Z
                    if (i == (month - 2)) al[0].RemainCount += st.StockTotal; // �c���͉�ʊJ�n���̑O���̂�
                }
            }
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }


        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɓ��o�ɏƉ�̃w�b�_���LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="stockCarEnterCarOutRetWorkList">��������</param>
        /// <param name="stockacpayhissearchparaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɓ��o�ɏƉ�̃w�b�_���LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.30</br>
        /// <br>Update Note: 2017/10/10 3H ������</br>
        /// <br>             �݌ɓ��o�ɏƉ�̑��x���ǑΉ�</br>
        private int SearchStockCarEnterCarOutSearchProcProc( out ArrayList stockCarEnterCarOutRetWorkList, StockAcPayHisSearchParaWork stockacpayhissearchparaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            double arriValCnT1 = 0;
            double shipMentCnT1 = 0;

            int i=0;
            
            //��ʊJ�n��I����
            DateTime St_AddupDate = TDateTime.LongDateToDateTime("YYYYMMDD", stockacpayhissearchparaWork.St_IoGoodsDay);
            DateTime Ed_AddupDate = TDateTime.LongDateToDateTime("YYYYMMDD", stockacpayhissearchparaWork.Ed_IoGoodsDay);
            DateTime AddupYearMonth = new DateTime();
            int IntAddupYearMonth = 0;

            ArrayList al = new ArrayList();
            try
            {
                #region 2009/2/20 DEL sakurai
                //bool sale = false, buy = false;
                //status = TestStock(out stockCarEnterCarOutRetWorkList, stockacpayhissearchparaWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction, ref sale, ref buy);
                #endregion

                StockCarEnterCarOutRetWork wkStockCarEnterCarOutRetWork = new StockCarEnterCarOutRetWork();

                string sqlText = string.Empty;

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "     SUM(STOCKACPAYHISTRF.ARRIVALCNTRF) AS ARRIVALCNT" + Environment.NewLine;
                sqlText += "    ,SUM(STOCKACPAYHISTRF.SHIPMENTCNTRF) AS SHIPMENTCNT" + Environment.NewLine;
                sqlText += "FROM STOCKACPAYHISTRF" + Environment.NewLine;
                sqlText += "WHERE STOCKACPAYHISTRF.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                // --- ADD 3H ������ 2017/10/10---------->>>>>
                // �_���폜�敪
                sqlText += "      AND STOCKACPAYHISTRF.LOGICALDELETECODERF IN ( 0, 1, 2, 3 ) " + Environment.NewLine;
                // --- ADD 3H ������ 2017/10/10----------<<<<<
                sqlText += "      AND STOCKACPAYHISTRF.IOGOODSDAYRF>=@STACPAYDATE" + Environment.NewLine;
                sqlText += "      AND STOCKACPAYHISTRF.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                sqlText += "      AND STOCKACPAYHISTRF.GOODSNORF=@GOODSNO" + Environment.NewLine;
                sqlText += "      AND STOCKACPAYHISTRF.WAREHOUSECODERF=@WAREHOUSECD" + Environment.NewLine;

                if (stockacpayhissearchparaWork.SectionCodes != null)
                {
                    string sectionString = "";
                    foreach (string sectionCode in stockacpayhissearchparaWork.SectionCodes)
                    {
                        if (sectionCode != "")
                        {
                            if (sectionString != "") sectionString += ",";
                            sectionString += "'" + sectionCode + "'";
                        }
                    }
                    if (sectionString != "")
                    {
                        sqlText += "  AND STOCKACPAYHISTRF.SECTIONCODERF IN (" + sectionString + ") " + Environment.NewLine;
                    }
                }

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                SqlParameter paraEnterpriseCode1 = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode1.Value = SqlDataMediator.SqlSetString(stockacpayhissearchparaWork.EnterpriseCode);

                SqlParameter paraSTACPAYDATE1 = sqlCommand.Parameters.Add("@STACPAYDATE", SqlDbType.Int);
                paraSTACPAYDATE1.Value = SqlDataMediator.SqlSetInt32(stockacpayhissearchparaWork.St_AcPayDate);

                SqlParameter paraStGoodsMakerCd1 = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd1.Value = SqlDataMediator.SqlSetInt32(stockacpayhissearchparaWork.St_GoodsMakerCd);

                SqlParameter paraStGoodsNo1 = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                paraStGoodsNo1.Value = SqlDataMediator.SqlSetString(stockacpayhissearchparaWork.St_GoodsNo);

                SqlParameter paraStWarehouseCode1 = sqlCommand.Parameters.Add("@WAREHOUSECD", SqlDbType.NChar);
                paraStWarehouseCode1.Value = SqlDataMediator.SqlSetString(stockacpayhissearchparaWork.St_WarehouseCode);

                sqlCommand.CommandTimeout = 3600; // Add 2012/12/14
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    wkStockCarEnterCarOutRetWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNT"));
                    wkStockCarEnterCarOutRetWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                sqlCommand = null;
                if (!myReader.IsClosed) myReader.Close();

                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "     SUM(STOCKACPAYHISTRF.ARRIVALCNTRF) AS ARRIVALCNT1" + Environment.NewLine;
                sqlText += "    ,SUM(STOCKACPAYHISTRF.SHIPMENTCNTRF) AS SHIPMENTCNT1" + Environment.NewLine;
                sqlText += "FROM STOCKACPAYHISTRF" + Environment.NewLine;
                sqlText += "WHERE STOCKACPAYHISTRF.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                // --- ADD 3H ������ 2017/10/10---------->>>>>
                // �_���폜�敪
                sqlText += "      AND STOCKACPAYHISTRF.LOGICALDELETECODERF IN ( 0, 1, 2, 3 ) " + Environment.NewLine;
                // --- ADD 3H ������ 2017/10/10----------<<<<<
                sqlText += "      AND STOCKACPAYHISTRF.ADDUPADATERF>=@STACPAYDATE" + Environment.NewLine;
                sqlText += "      AND STOCKACPAYHISTRF.ADDUPADATERF<@ST_IOGOODSDAY" + Environment.NewLine;
                sqlText += "      AND STOCKACPAYHISTRF.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                sqlText += "      AND STOCKACPAYHISTRF.GOODSNORF=@GOODSNO" + Environment.NewLine;
                sqlText += "      AND STOCKACPAYHISTRF.WAREHOUSECODERF=@WAREHOUSECD" + Environment.NewLine;
                if (stockacpayhissearchparaWork.SectionCodes != null)
                {
                    string sectionString = "";
                    foreach (string sectionCode in stockacpayhissearchparaWork.SectionCodes)
                    {
                        if (sectionCode != "")
                        {
                            if (sectionString != "") sectionString += ",";
                            sectionString += "'" + sectionCode + "'";
                        }
                    }
                    if (sectionString != "")
                    {
                        sqlText += "  AND STOCKACPAYHISTRF.SECTIONCODERF IN (" + sectionString + ") " + Environment.NewLine;
                    }
                }

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);

                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(stockacpayhissearchparaWork.EnterpriseCode);

                SqlParameter paraSTACPAYDATE2 = sqlCommand.Parameters.Add("@STACPAYDATE", SqlDbType.Int);
                paraSTACPAYDATE2.Value = SqlDataMediator.SqlSetInt32(stockacpayhissearchparaWork.St_AcPayDate);

                SqlParameter paraStGoodsMakerCd2 = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd2.Value = SqlDataMediator.SqlSetInt32(stockacpayhissearchparaWork.St_GoodsMakerCd);

                SqlParameter paraStIoGoodsDay2 = sqlCommand.Parameters.Add("@ST_IOGOODSDAY", SqlDbType.Int);
                paraStIoGoodsDay2.Value = SqlDataMediator.SqlSetInt32(stockacpayhissearchparaWork.St_IoGoodsDay);

                SqlParameter paraStGoodsNo2 = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                paraStGoodsNo2.Value = SqlDataMediator.SqlSetString(stockacpayhissearchparaWork.St_GoodsNo);

                SqlParameter paraStWarehouseCode2 = sqlCommand.Parameters.Add("@WAREHOUSECD", SqlDbType.NChar);
                paraStWarehouseCode2.Value = SqlDataMediator.SqlSetString(stockacpayhissearchparaWork.St_WarehouseCode);


                sqlCommand.CommandTimeout = 3600; // Add 2012/12/14
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    arriValCnT1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNT1"));
                    shipMentCnT1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT1"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                sqlCommand = null;
                if (!myReader.IsClosed) myReader.Close();

                #region 2009/2/20 ADD sakurai�@

                //�݌ɗ����f�[�^���O���c��,�c���擾
                ArrayList CompanySettingList  = new ArrayList();
                CompanyInfWork CompanyInfWork = new CompanyInfWork();
                CompanyInfWork.EnterpriseCode = stockacpayhissearchparaWork.EnterpriseCode;

                // ���Џ��List�擾
                status = _companyInfDB.Search(out CompanySettingList, CompanyInfWork, ref sqlConnection);

                if (status == 0)
                {
                    CompanyInfWork = CompanySettingList[0] as CompanyInfWork;
                    FinYearTableGenerator YearTable = new FinYearTableGenerator(CompanyInfWork);
                    // ��ʊJ�n���̌v��N���擾
                    YearTable.GetYearMonth(St_AddupDate, out AddupYearMonth);
                    IntAddupYearMonth = AddupYearMonth.Year*100+AddupYearMonth.Month;
                }

                sqlText = string.Empty;
                sqlText += " SELECT " + Environment.NewLine;
                sqlText += "    SUM(STOCKTOTALRF) AS STOCKTOTAL" + Environment.NewLine;
                sqlText += " FROM STOCKHISTORYRF" + Environment.NewLine;
                sqlText += " WHERE ADDUPYEARMONTHRF=" + Environment.NewLine;
                sqlText += " ( " + Environment.NewLine;
                sqlText += " 	SELECT " + Environment.NewLine;
                sqlText += " 	    MAX(ADDUPYEARMONTHRF)" + Environment.NewLine;
                sqlText += " 	FROM STOCKHISTORYRF" + Environment.NewLine;
                sqlText += "    WHERE ADDUPYEARMONTHRF<@ADDUPYEARMONTH" + Environment.NewLine;
                if (stockacpayhissearchparaWork.SectionCodes != null && stockacpayhissearchparaWork.SectionCodes[0] == "")
                sqlText += "      AND SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                sqlText += "      AND WAREHOUSECODERF=@WAREHOUSECODE " + Environment.NewLine;
                sqlText += "      AND GOODSNORF=@GOODSNO " + Environment.NewLine;
                sqlText += "      AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sqlText += "      AND GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                sqlText += " ) " + Environment.NewLine;
                if (stockacpayhissearchparaWork.SectionCodes != null && stockacpayhissearchparaWork.SectionCodes[0] == "")
                sqlText += " AND SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                sqlText += " AND WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                sqlText += " AND GOODSNORF=@GOODSNO" + Environment.NewLine;
                sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sqlText += " AND GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                SqlParameter paraEnterpriseCode  = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraGoodsMakerCd    = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsNo         = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                SqlParameter paraWarehouseCode   = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                SqlParameter paraAddupYearMonth  = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                

                paraEnterpriseCode.Value  = SqlDataMediator.SqlSetString(stockacpayhissearchparaWork.EnterpriseCode);
                paraGoodsMakerCd.Value    = SqlDataMediator.SqlSetInt32(stockacpayhissearchparaWork.St_GoodsMakerCd);
                paraGoodsNo.Value       = SqlDataMediator.SqlSetString(stockacpayhissearchparaWork.St_GoodsNo);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockacpayhissearchparaWork.St_WarehouseCode);
                paraAddupYearMonth.Value  = SqlDataMediator.SqlSetInt32(IntAddupYearMonth);

                if (stockacpayhissearchparaWork.SectionCodes != null && stockacpayhissearchparaWork.SectionCodes[0] != "")
                {
                    string sectionCode = stockacpayhissearchparaWork.SectionCodes[0] as string;
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);
                }

                sqlCommand.CommandTimeout = 3600; // Add 2012/12/14
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    wkStockCarEnterCarOutRetWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTAL"));�@// �O���c
                    wkStockCarEnterCarOutRetWork.RemainCount = wkStockCarEnterCarOutRetWork.StockTotal + arriValCnT1 - shipMentCnT1;      // �c��
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                #endregion

                #region 2009/2/20 DEL sakurai
                //// 1:TESTSTOCK�Ō��ʃ��X�g��0�Ŋ��A2:����(sale)�����(buy)�̂ǂ��炩���������߂���Ă�����
                //if (stockCarEnterCarOutRetWorkList.Count == 0 && (sale == false || buy == false))
                //{
                //    sqlCommand = null;
                //    if (!myReader.IsClosed) myReader.Close();
 
                //    sqlText = string.Empty;

                //    sqlText += "SELECT" + Environment.NewLine;
                //    sqlText += "     STOCKHISTORYRF.STOCKTOTALRF" + Environment.NewLine;
                //    sqlText += "FROM STOCKHISTORYRF" + Environment.NewLine;
                //    sqlText += "WHERE STOCKHISTORYRF.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                //    sqlText += "      AND STOCKHISTORYRF.ADDUPYEARMONTHRF=@StHisYearMonth" + Environment.NewLine;
                //    sqlText += "      AND STOCKHISTORYRF.WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                //    sqlText += "      AND STOCKHISTORYRF.GOODSNORF=@GOODSNO" + Environment.NewLine;
                //    sqlText += "      AND STOCKHISTORYRF.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;

                //    if (stockacpayhissearchparaWork.SectionCodes != null)
                //    {
                //        string sectionString = "";
                //        foreach (string sectionCode in stockacpayhissearchparaWork.SectionCodes)
                //        {
                //            if (sectionCode != "")
                //            {
                //                if (sectionString != "") sectionString += ",";
                //                sectionString += "'" + sectionCode + "'";
                //            }
                //        }
                //        if (sectionString != "")
                //        {
                //            sqlText += "  AND STOCKHISTORYRF.SECTIONCODERF IN (" + sectionString + ") " + Environment.NewLine;
                //        }
                //    }

                //    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //    SqlParameter paraEnterpriseCode3 = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                //    paraEnterpriseCode3.Value = SqlDataMediator.SqlSetString(stockacpayhissearchparaWork.EnterpriseCode);

                //    SqlParameter paraStHisYearMonth3 = sqlCommand.Parameters.Add("@StHisYearMonth", SqlDbType.Int);
                //    paraStHisYearMonth3.Value = SqlDataMediator.SqlSetInt32(stockacpayhissearchparaWork.St_HisYearMonth);

                //    SqlParameter paraWareHouseCode3 = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                //    paraWareHouseCode3.Value = SqlDataMediator.SqlSetString(stockacpayhissearchparaWork.St_WarehouseCode);

                //    SqlParameter paraGoodsNo3 = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                //    paraGoodsNo3.Value = SqlDataMediator.SqlSetString(stockacpayhissearchparaWork.St_GoodsNo);

                //    SqlParameter paraGoodsMakerCd3 = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                //    paraGoodsMakerCd3.Value = SqlDataMediator.SqlSetInt32(stockacpayhissearchparaWork.St_GoodsMakerCd);

                //    myReader = sqlCommand.ExecuteReader();

                //    while (myReader.Read())
                //    {
                //        wkStockCarEnterCarOutRetWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALRF"));�@//�O���c
                //        wkStockCarEnterCarOutRetWork.RemainCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALRF")) +
                //                                                   arriValCnT1 - shipMentCnT1;
                //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //    }
                //}
                //else
                //{
                //    foreach (StockCarEnterCarOutRetWork stockCarEnter in stockCarEnterCarOutRetWorkList)
                //    {
                //        wkStockCarEnterCarOutRetWork.StockTotal = stockCarEnter.StockTotal;
                //        wkStockCarEnterCarOutRetWork.RemainCount = stockCarEnter.StockTotal + arriValCnT1 - shipMentCnT1;
                //    }
                //}
                #endregion

                al.Add(wkStockCarEnterCarOutRetWork);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            stockCarEnterCarOutRetWorkList = al;

            return status;
        }
        // 2008.06.30 add end -------------------------------------------------------<<
        #endregion

        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɓ��o�ɏƉ�̃w�b�_���LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="stockCarEnterCarOutRetWorkList">��������</param>
        /// <param name="stockacpayhissearchparaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɓ��o�ɏƉ�̃w�b�_���LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.30</br>
        public int TestStock(out ArrayList stockCarEnterCarOutRetWorkList, StockAcPayHisSearchParaWork stockacpayhissearchparaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref bool sale, ref bool buy)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            List<StockCarEnterCarOutRetWork> al = new List<StockCarEnterCarOutRetWork>();

            ArrayList resultList = new ArrayList();

            StockCarEnterCarOutRetWork resultwork = new StockCarEnterCarOutRetWork();

            stockCarEnterCarOutRetWorkList = new ArrayList();
            #region
            int month = 0, i = 0;�@�@//�Ώی���

            int st_subMonth = stockacpayhissearchparaWork.St_IoGoodsDay % 10000;
            int st_day = st_subMonth % 100;
            int st_month = (st_subMonth - st_day) / 100;
            int st_year = (stockacpayhissearchparaWork.St_IoGoodsDay - st_subMonth) / 10000;
            DateTime st_UpDate = new DateTime(st_year, st_month, st_day);�@//�J�n�v��N����

            int ed_subMonth = stockacpayhissearchparaWork.Ed_IoGoodsDay % 10000;
            int ed_day = ed_subMonth % 100;
            int ed_month = (ed_subMonth - ed_day) / 100;
            int ed_year = (stockacpayhissearchparaWork.Ed_IoGoodsDay - ed_subMonth) / 10000;
            DateTime ed_UpDate = new DateTime(ed_year, ed_month, ed_day);�@//�I���v��N����


            DateTime st_BeforUpDate = new DateTime();
            DateTime StockTotalMonth = DateTime.MinValue; // ���߂Ă��Ȃ�����
            #endregion

            try
            {
                ArrayList stockHistoryList = new ArrayList();

                #region �S�Аݒ�
                //if (stockacpayhissearchparaWork.SectionCodes == null)
                //{
                //    CustomSerializeArrayList sectionList = new CustomSerializeArrayList();
                //    SectionInfo sectionInfo = new SectionInfo();
                //    SecInfoSetWork sectionInfoSetWork = new SecInfoSetWork();

                //    sectionInfoSetWork.EnterpriseCode = stockacpayhissearchparaWork.EnterpriseCode;
                //    sectionInfoSetWork.LogicalDeleteCode = 0;

                //    sectionInfo.Search(out sectionList, sectionInfoSetWork, ref sqlConnection, readMode, logicalMode);
                //    ArrayList paraList = ListUtils.Find(sectionList, typeof(SecInfoSetWork), ListUtils.FindType.Array) as ArrayList;

                //    string[] str = new string[paraList.Count];

                //    foreach (SecInfoSetWork sec in paraList)
                //    {
                //        str[i] = sec.SectionCode;
                //        i++;
                //    }
                //    if (str.Length != 0)
                //    {
                //        stockacpayhissearchparaWork.SectionCodes = str;
                //    }
                //}
                #endregion
                foreach (string sectionCode in stockacpayhissearchparaWork.SectionCodes)
                {
                    #region �O�����ߔ͈͓��t�擾
                    DateTime stMonth;
                    DateTime edMonth;
                    DateTime addUpDate;

                    ArrayList beforlist = new ArrayList();
                    CompanyInfWork beforCompanyInfWork = new CompanyInfWork();

                    beforCompanyInfWork.EnterpriseCode = stockacpayhissearchparaWork.EnterpriseCode;

                    status = _companyInfDB.Search(out beforlist, beforCompanyInfWork, ref sqlConnection);

                    beforCompanyInfWork = beforlist[0] as CompanyInfWork;
                    FinYearTableGenerator beforfin = new FinYearTableGenerator(beforCompanyInfWork);

                    beforfin.GetYearMonth(st_UpDate, out addUpDate);                // �v��N���x�擾
                    DateTime beMonth = addUpDate.AddMonths(-1);
                    beforfin.GetDaysFromMonth(beMonth, out stMonth, out edMonth);   // �O���x�̓��t�擾
                    #endregion

                    #region �O�������`�F�b�N����
                    List<TtlDayCalcRetWork> retListsale = new List<TtlDayCalcRetWork>();
                    List<TtlDayCalcRetWork> retListbuy = new List<TtlDayCalcRetWork>();
                    TtlDayCalcParaWork para = new TtlDayCalcParaWork();

                    para.EnterpriseCode = stockacpayhissearchparaWork.EnterpriseCode;
                    para.SectionCode = sectionCode;

                    //DateTime beMonth2 = st_UpDate.AddMonths(-1);
                    //int a = st_UpDate.Year * 10000 + beMonth2.Month * 100 + 100 + edMonth.Day;
                    Int32 iAddUpDate = edMonth.Year * 10000 + edMonth.Month * 100 + edMonth.Day;

                    int StMonth = 0;
                    sale = new bool();
                    buy  = new bool();
                    sale = false;
                    buy  = false;

                    // ���|��O�������߂���Ă��邩��r
                    status = _ttlDayCalcDB.SearchHisMonthlyAccRec(out retListsale, para, ref sqlConnection);
                    
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || retListsale[0].TotalDay < iAddUpDate) 
                    {
                        sale = true;
  
                    }
                    // ���|��O�������߂���Ă��邩��r
                    status = _ttlDayCalcDB.SearchHisMonthlyAccPay(out retListbuy, para, ref sqlConnection);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || retListbuy[0].TotalDay < iAddUpDate)
                    {
                        buy = true;
                    }
                    #endregion


                    // ������(���A��)�ǂ�������������s���Ă��Ȃ�������
                    if (sale == true && buy == true)
                    {
                        #region �N���͈͌v�Z
                        if (StMonth == 0)
                        {
                            
                            if ((retListsale.Count != 0 && retListbuy.Count != 0) && (retListsale[0].TotalDay < retListbuy[0].TotalDay))
                            {
                                //���|�̓��t���傫��������A���|�̓��t�𔽉f
                                StMonth = retListsale[0].TotalDay;
                            }
                            else if ((retListsale.Count != 0 && retListbuy.Count != 0) && (retListsale[0].TotalDay > retListbuy[0].TotalDay))
                            {
                                //���|�̓��t���傫��������A���|�̓��t�𔽉f
                                StMonth = retListbuy[0].TotalDay;
                            }
                            else
                            {
                                //�������܂��ĂȂ���������񌎂𔽉f
                                StMonth = beforCompanyInfWork.CompanyBiginDate;
                            }

                            //Int��DateTime�ɕϊ��@�J�n��
                            StockTotalMonth = new DateTime(StMonth / 10000, (StMonth % 10000) / 100, StMonth % 100);
                        }

                        //beforfin.GetYearMonth(StMonth, out StyearMonth);                // �v��N���x�擾

                        // �O���܂ł̒��߂Ă��Ȃ����̍��v
                        // addupDate ��ʊJ�n�N�� // StockTotalMonth �ŏI����
                        Int32 monthRenge =
                        ((addUpDate.Year) - (StockTotalMonth.Year)) * 12 +
                        (addUpDate.Month) - ((StockTotalMonth.Month)) + 1;

                        #endregion
                        addUpDate = StockTotalMonth.AddMonths(-month);�@//StockTotalMonth�͔N�����Ȃ̂�addupDate���J�E���g�������J�n�̔N���쐬
                        for (i = 0; i < monthRenge; i++)
                        {
                            List<StockHistoryWork> stockHistoryWorkList = new List<StockHistoryWork>();

                            #region �����͈͎擾����
                            ArrayList beforlist2 = new ArrayList();
                            CompanyInfWork beforCompanyInfWork2 = new CompanyInfWork();

                            beforCompanyInfWork2.EnterpriseCode = stockacpayhissearchparaWork.EnterpriseCode;
                            status = _companyInfDB.Search(out beforlist2, beforCompanyInfWork2, ref sqlConnection);
                            beforCompanyInfWork = beforlist2[0] as CompanyInfWork;

                            FinYearTableGenerator beforfin2 = new FinYearTableGenerator(beforCompanyInfWork);
                            DateTime stMonth2 = new DateTime();
                            DateTime edMonth2 = new DateTime();

                            beforfin2.GetDaysFromMonth(addUpDate, out stMonth2, out edMonth2);
                            #endregion


                            #region �����X�V�����[�gSearch
                            // �����X�V�����[�gSearch�Ɏg�p
                            StockHistoryWork stockHistoryWork = new StockHistoryWork();
                            MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork();

                            //���|���E���|���W�v���W���[���p�����[�^�Z�b�g
                            monthlyAddUpWork.EnterpriseCode = stockacpayhissearchparaWork.EnterpriseCode;
                            monthlyAddUpWork.AddUpDateSt = stMonth2;
                            monthlyAddUpWork.AddUpDateEd = edMonth2;
                            monthlyAddUpWork.AddUpSecCode = sectionCode;
                            monthlyAddUpWork.AddUpDate = edMonth2;
                            monthlyAddUpWork.LstMonAddUpProcDay = TDateTime.LongDateToDateTime(stockacpayhissearchparaWork.St_HisYearMonth * 100 + 1).AddMonths(-1);
                            monthlyAddUpWork.AddUpYearMonth = TDateTime.LongDateToDateTime(stockacpayhissearchparaWork.St_HisYearMonth * 100 + 1).AddMonths(-1);

                            string retMsg = null;
                            bool msgDiv = true;

                            // �����X�V�����[�g�݌ɏW�v���\�b�h�Ăяo��
                            status = _monthlyAddUpDB.MakeStockHistoryParameters(ref monthlyAddUpWork, ref stockHistoryWorkList, out msgDiv, out retMsg, ref sqlConnection);
                            #endregion

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockHistoryWorkList.Count != 0)
                            {
                                // �N���X�i�[���\�b�h
                                status = StockStorage(ref al, ref stockHistoryWorkList, stockacpayhissearchparaWork, i, monthRenge);

                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                             (status == (int)ConstantManagement.DB_Status.ctDB_EOF) || stockHistoryWorkList.Count == 0)
                            {
                                //NOT_FOUND,EOF�̏ꍇ�͎���
                            }
                            else
                            {
                                throw new Exception("���|���E���|���W�v���W���[������̎擾�Ɏ��s�B");
                            }
                            addUpDate = addUpDate.AddMonths(1);
                        }
                    }
                    else
                    {
                        continue;
                        //stockCarEnterCarOutRetWorkList = new ArrayList();
                        //return status;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockNoShipmentListWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            foreach (StockCarEnterCarOutRetWork rwork in al)
            {
                rwork.ArrivalCnt = al[0].ArrivalCnt;
                rwork.ShipmentCnt = al[0].ShipmentCnt;
                rwork.StockTotal = al[0].StockTotal;
                rwork.RemainCount = al[0].RemainCount;
                resultList.Add(rwork);
            }
            stockCarEnterCarOutRetWorkList = resultList;
            return status;
        }

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="stockAcPayHisSearchParaWork">���������i�[�N���X</param>
        /// <param name="procMode">���g�p</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br>UpdateNote : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
        /// <br>UpdateNote : 2013/01/15 FSI���� �G�@�Ǘ�No.541 ���|�I�v�V�����ǉ��Ή�</br>
        /// <br>UpdateNote : 2017/10/10 3H �������@�݌ɓ��o�ɏƉ�̑��x���ǑΉ�</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockAcPayHisSearchParaWork stockAcPayHisSearchParaWork, int procMode, ConstantManagement.LogicalMode logicalMode)
        {
            StringBuilder retstring = new StringBuilder();
            retstring.Append("WHERE ");

            // ---ADD 2013/01/15----->>>>>
            bool hasstkpay = stockAcPayHisSearchParaWork.HasStkPay;
            // ---ADD 2013/01/15-----<<<<<

            //��ƃR�[�h
            retstring.Append("STOCKACPAYHISTRF.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockAcPayHisSearchParaWork.EnterpriseCode);
            // --- ADD 3H ������ 2017/10/10---------->>>>>
            // �_���폜�敪
            retstring.Append("AND STOCKACPAYHISTRF.LOGICALDELETECODERF IN ( 0, 1, 2, 3 ) ");
            // --- ADD 3H ������ 2017/10/10----------<<<<<

            // 2008.06.30 del start ------------------------------------>>
            //if (stockAcPayHisSearchParaWork.ValidDivCd == 0)
            //{
            //    retstring.Append("AND STOCKACPAYHISTRF.VALIDDIVCDRF=0 ");
            //}
            //else
            //{
            //    retstring.Append("AND STOCKACPAYHISTRF.VALIDDIVCDRF!=0 ");
            //}
            // 2008.06.30 del end --------------------------------------<<

            //���_�R�[�h
            if (stockAcPayHisSearchParaWork.SectionCodes != null)
            {
                string sectionString = "";
                foreach (string sectionCode in stockAcPayHisSearchParaWork.SectionCodes)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    // 2009/04/08 >>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //retstring.Append("AND STOCKACPAYHISTRF.INPUTSECTIONCDRF IN (" + sectionString + ") ");
                    retstring.Append("AND STOCKACPAYHISTRF.SECTIONCODERF IN (" + sectionString + ") "); 
                    // 2009/04/08 <<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }

            //�J�n���o�ד�
            if (stockAcPayHisSearchParaWork.St_IoGoodsDay > 0)
            {
                retstring.Append("AND (STOCKACPAYHISTRF.IOGOODSDAYRF>=@ST_IOGOODSDAY OR STOCKACPAYHISTRF.ADDUPADATERF>=@ST_IOGOODSDAY) ");
                SqlParameter paraSt_IoGoodsDay = sqlCommand.Parameters.Add("@ST_IOGOODSDAY", SqlDbType.Int);
                paraSt_IoGoodsDay.Value = SqlDataMediator.SqlSetInt32(stockAcPayHisSearchParaWork.St_IoGoodsDay);
            }
            //�I�����o�ד�
            if (stockAcPayHisSearchParaWork.Ed_IoGoodsDay > 0)
            {
                retstring.Append("AND (STOCKACPAYHISTRF.IOGOODSDAYRF<=@ED_IOGOODSDAY OR STOCKACPAYHISTRF.ADDUPADATERF<=@ED_IOGOODSDAY) ");
                SqlParameter paraEd_IoGoodsDay = sqlCommand.Parameters.Add("@ED_IOGOODSDAY", SqlDbType.Int);
                paraEd_IoGoodsDay.Value = SqlDataMediator.SqlSetInt32(stockAcPayHisSearchParaWork.Ed_IoGoodsDay);
            }

            ////�J�n�v���
            //if (stockAcPayHisSearchParaWork.St_AddUpADate > 0)
            //{
            //    retstring.Append("AND STOCKACPAYHISTRF.ADDUPADATERF>=@ST_ADDUPADATE ");
            //    SqlParameter paraSt_AddUpADate = sqlCommand.Parameters.Add("@ST_ADDUPADATE", SqlDbType.Int);
            //    paraSt_AddUpADate.Value = SqlDataMediator.SqlSetInt32(stockAcPayHisSearchParaWork.St_AddUpADate);
            //}
            ////�I���v���
            //if (stockAcPayHisSearchParaWork.Ed_AddUpADate > 0)
            //{
            //    retstring.Append("AND STOCKACPAYHISTRF.ADDUPADATERF<=@ED_ADDUPADATE ");
            //    SqlParameter paraEd_AddUpADate = sqlCommand.Parameters.Add("@ED_ADDUPADATE", SqlDbType.Int);
            //    paraEd_AddUpADate.Value = SqlDataMediator.SqlSetInt32(stockAcPayHisSearchParaWork.Ed_AddUpADate);
            //}

            //�J�n�q�ɃR�[�h
            if (stockAcPayHisSearchParaWork.St_WarehouseCode != "")
            {
                retstring.Append("AND STOCKACPAYHISTRF.WAREHOUSECODERF>=@ST_WAREHOUSECODE ");
                SqlParameter paraSt_WarehouseCode = sqlCommand.Parameters.Add("@ST_WAREHOUSECODE", SqlDbType.NChar);
                paraSt_WarehouseCode.Value = SqlDataMediator.SqlSetString(stockAcPayHisSearchParaWork.St_WarehouseCode);
            }
            //�I���q�ɃR�[�h
            if (stockAcPayHisSearchParaWork.Ed_WarehouseCode != "")
            {
                retstring.Append("AND STOCKACPAYHISTRF.WAREHOUSECODERF<=@ED_WAREHOUSECODE ");
                SqlParameter paraEd_WarehouseCode = sqlCommand.Parameters.Add("@ED_WAREHOUSECODE", SqlDbType.NChar);
                paraEd_WarehouseCode.Value = SqlDataMediator.SqlSetString(stockAcPayHisSearchParaWork.Ed_WarehouseCode);
            }

            //�J�n���[�J�[���i�R�[�h
            if (stockAcPayHisSearchParaWork.St_GoodsMakerCd > 0)
            {
                retstring.Append("AND STOCKACPAYHISTRF.GOODSMAKERCDRF>=@ST_GOODSMAKERCD ");
                SqlParameter paraSt_GoodsMakerCd = sqlCommand.Parameters.Add("@ST_GOODSMAKERCD", SqlDbType.Int);
                paraSt_GoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockAcPayHisSearchParaWork.St_GoodsMakerCd);
            }
            //�I�����[�J�[���i�R�[�h
            if (stockAcPayHisSearchParaWork.Ed_GoodsMakerCd > 0)
            {
                retstring.Append("AND STOCKACPAYHISTRF.GOODSMAKERCDRF<=@ED_GOODSMAKERCD ");
                SqlParameter paraEd_GoodsMakerCd = sqlCommand.Parameters.Add("@ED_GOODSMAKERCD", SqlDbType.Int);
                paraEd_GoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockAcPayHisSearchParaWork.Ed_GoodsMakerCd);
            }

            //�J�n�󕥌��`�[�ԍ�
            if (stockAcPayHisSearchParaWork.St_AcPaySlipNum != "")
            {
                // ---ADD 2010/11/15 ------------------------>>>>>
                //retstring.Append("AND STOCKACPAYHISTRF.ACPAYSLIPNUMRF>=@ST_ACPAYSLIPNUM ");
                //retstring.Append("AND RIGHT('000000000' + STOCKACPAYHISTRF.ACPAYSLIPNUMRF,9)>=@ST_ACPAYSLIPNUM "); // ---DEL 2013/01/15-----
                // ---ADD 2010/11/15 ------------------------<<<<<

                // ---ADD 2013/01/15----->>>>>
                if (hasstkpay)
                {
                    //�݌Ɏ󕥗����f�[�^ 
                    retstring.Append("AND RIGHT('000000000' + STOCKACPAYHISTRF.ACPAYSLIPNUMRF,9)>=@ST_ACPAYSLIPNUM ");
                }
                else
                {
                    //�݌ɒ������׃f�[�^(�݌ɒ������׃f�[�^��NULL�̏ꍇ�݌Ɏ󕥗����f�[�^)
                    retstring.Append("AND (CASE WHEN STOCKADJUSTDTL.STOCKADJUSTSLIPNORF IS NULL THEN RIGHT('000000000' + STOCKACPAYHISTRF.ACPAYSLIPNUMRF,9) ELSE RIGHT('000000000' + CAST(STOCKADJUSTDTL.STOCKADJUSTSLIPNORF AS nvarchar),9) END )>=@ST_ACPAYSLIPNUM  ");                   
                }
                // ---ADD 2013/01/15-----<<<<<

                SqlParameter paraSt_AcPaySlipNum = sqlCommand.Parameters.Add("@ST_ACPAYSLIPNUM", SqlDbType.NChar);
                paraSt_AcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockAcPayHisSearchParaWork.St_AcPaySlipNum);
            }
            //�I���󕥌��`�[�ԍ�
            if (stockAcPayHisSearchParaWork.Ed_AcPaySlipNum != "")
            {
                // ---ADD 2010/11/15 ------------------------>>>>>
                //retstring.Append("AND STOCKACPAYHISTRF.ACPAYSLIPNUMRF<=@ED_ACPAYSLIPNUM ");
                //retstring.Append("AND RIGHT('000000000' + STOCKACPAYHISTRF.ACPAYSLIPNUMRF,9)<=@ED_ACPAYSLIPNUM "); // ---DEL 2013/01/15-----
                // ---ADD 2010/11/15 ------------------------<<<<<                

                // ---ADD 2013/01/15----->>>>>
                if (hasstkpay)
                {
                    //�݌Ɏ󕥗����f�[�^ 
                    retstring.Append("AND RIGHT('000000000' + STOCKACPAYHISTRF.ACPAYSLIPNUMRF,9)<=@ED_ACPAYSLIPNUM ");
                }
                else
                {
                    //�݌ɒ������׃f�[�^(�݌ɒ������׃f�[�^��NULL�̏ꍇ�݌Ɏ󕥗����f�[�^)
                    retstring.Append("AND (CASE WHEN STOCKADJUSTDTL.STOCKADJUSTSLIPNORF IS NULL THEN RIGHT('000000000' + STOCKACPAYHISTRF.ACPAYSLIPNUMRF,9) ELSE RIGHT('000000000' + CAST(STOCKADJUSTDTL.STOCKADJUSTSLIPNORF AS nvarchar),9) END )<=@ED_ACPAYSLIPNUM ");                   
                }
                // ---ADD 2013/01/15-----<<<<<

                SqlParameter paraEd_AcPaySlipNum = sqlCommand.Parameters.Add("@ED_ACPAYSLIPNUM", SqlDbType.NChar);
                paraEd_AcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockAcPayHisSearchParaWork.Ed_AcPaySlipNum);
            }

            //�J�n���i�ԍ�
            if (stockAcPayHisSearchParaWork.St_GoodsNo != "")
            {
                retstring.Append("AND STOCKACPAYHISTRF.GOODSNORF>=@ST_GOODSNO ");
                SqlParameter paraSt_GoodsNo = sqlCommand.Parameters.Add("@ST_GOODSNO", SqlDbType.NChar);
                paraSt_GoodsNo.Value = SqlDataMediator.SqlSetString(stockAcPayHisSearchParaWork.St_GoodsNo);
            }
            //�I�����i�ԍ�
            if (stockAcPayHisSearchParaWork.Ed_GoodsNo != "")
            {
                retstring.Append("AND STOCKACPAYHISTRF.GOODSNORF<=@ED_GOODSNO ");
                SqlParameter paraEd_GoodsNo = sqlCommand.Parameters.Add("@ED_GOODSNO", SqlDbType.NChar);
                paraEd_GoodsNo.Value = SqlDataMediator.SqlSetString(stockAcPayHisSearchParaWork.Ed_GoodsNo);
            }


            //�󕥌��`�[�敪
            if (stockAcPayHisSearchParaWork.AcPaySlipCd > 0)
            {
                retstring.Append("AND STOCKACPAYHISTRF.ACPAYSLIPCDRF=@ACPAYSLIPCD ");
                SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
                paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockAcPayHisSearchParaWork.AcPaySlipCd);
            }
            // ---ADD 2010/11/15 ------------------------>>>>>
            //�J�n���͓�
            if (stockAcPayHisSearchParaWork.St_detInputDay != DateTime.MinValue)
            {
                retstring.Append("AND (STOCKACPAYHISTRF.ACPAYHISTDATETIMERF>=@ST_DETINPUTDAY) ");
                SqlParameter paraSt_detInputDay = sqlCommand.Parameters.Add("@ST_DETINPUTDAY", SqlDbType.BigInt);
                paraSt_detInputDay.Value = SqlDataMediator.SqlSetInt64(stockAcPayHisSearchParaWork.St_detInputDay.Ticks);
                

                retstring.Append("AND (STOCKACPAYHISTRF.ACPAYHISTDATETIMERF<=@ED_DETINPUTDAY) ");
                SqlParameter paraEd_detInputDay = sqlCommand.Parameters.Add("@ED_DETINPUTDAY", SqlDbType.BigInt);
                paraEd_detInputDay.Value = SqlDataMediator.SqlSetInt64(stockAcPayHisSearchParaWork.Ed_detInputDay.Ticks);
            }
            // ---ADD 2010/11/15 ------------------------<<<<<
            return retstring.ToString();
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� StockAcPayHisSearchWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockAcPayHisSearchWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// </remarks>
        private StockAcPayHisSearchRetWork CopyToStockAcPayHisSearchRetWorkFromReader(ref SqlDataReader myReader)
        {
            StockAcPayHisSearchRetWork wkStockAcPayHisSearchRetWork = new StockAcPayHisSearchRetWork();
            #region �N���X�֊i�[
            wkStockAcPayHisSearchRetWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IOGOODSDAYRF"));
            wkStockAcPayHisSearchRetWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            wkStockAcPayHisSearchRetWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
            wkStockAcPayHisSearchRetWork.AcPaySlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACPAYSLIPNUMRF"));
            wkStockAcPayHisSearchRetWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPROWNORF"));
            wkStockAcPayHisSearchRetWork.AcPayHistDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("ACPAYHISTDATETIMERF"));
            wkStockAcPayHisSearchRetWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
            wkStockAcPayHisSearchRetWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTSECTIONCDRF"));
            wkStockAcPayHisSearchRetWork.InputSectionGuidNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTSECTIONGUIDNMRF"));
            wkStockAcPayHisSearchRetWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
            wkStockAcPayHisSearchRetWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
            wkStockAcPayHisSearchRetWork.MoveStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTATUSRF"));
            wkStockAcPayHisSearchRetWork.CustSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTSLIPNORF"));
            wkStockAcPayHisSearchRetWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLIPDTLNUMRF"));
            wkStockAcPayHisSearchRetWork.AcPayNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACPAYNOTERF"));
            wkStockAcPayHisSearchRetWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStockAcPayHisSearchRetWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkStockAcPayHisSearchRetWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStockAcPayHisSearchRetWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkStockAcPayHisSearchRetWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkStockAcPayHisSearchRetWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkStockAcPayHisSearchRetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockAcPayHisSearchRetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkStockAcPayHisSearchRetWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStockAcPayHisSearchRetWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkStockAcPayHisSearchRetWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNORF"));
            wkStockAcPayHisSearchRetWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF"));
            wkStockAcPayHisSearchRetWork.BfSectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDENMRF"));
            wkStockAcPayHisSearchRetWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
            wkStockAcPayHisSearchRetWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
            wkStockAcPayHisSearchRetWork.BfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
            wkStockAcPayHisSearchRetWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF"));
            wkStockAcPayHisSearchRetWork.AfSectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDENMRF"));
            wkStockAcPayHisSearchRetWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
            wkStockAcPayHisSearchRetWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
            wkStockAcPayHisSearchRetWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
            wkStockAcPayHisSearchRetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            //wkStockAcPayHisSearchRetWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF")); // 2008.06.30 del
            //wkStockAcPayHisSearchRetWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF")); // 2008.06.30 del
            wkStockAcPayHisSearchRetWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkStockAcPayHisSearchRetWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
            wkStockAcPayHisSearchRetWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            wkStockAcPayHisSearchRetWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            wkStockAcPayHisSearchRetWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            wkStockAcPayHisSearchRetWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockAcPayHisSearchRetWork.StockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICERF"));
            wkStockAcPayHisSearchRetWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
            wkStockAcPayHisSearchRetWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYRF"));
            wkStockAcPayHisSearchRetWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
            wkStockAcPayHisSearchRetWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
            wkStockAcPayHisSearchRetWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
            wkStockAcPayHisSearchRetWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
            wkStockAcPayHisSearchRetWork.NonAddUpShipmCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NONADDUPSHIPMCNTRF"));
            wkStockAcPayHisSearchRetWork.NonAddUpArrGdsCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NONADDUPARRGDSCNTRF"));
            wkStockAcPayHisSearchRetWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
            wkStockAcPayHisSearchRetWork.PresentStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRESENTSTOCKCNTRF"));
            wkStockAcPayHisSearchRetWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkStockAcPayHisSearchRetWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            #endregion

            return wkStockAcPayHisSearchRetWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
