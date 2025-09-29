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
using Broadleaf.Library.Diagnostics;// ADD 2019/08/20 ���O PMKOBETSU-647 �����d����M�����G���[�Ή�
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
using System.Xml;
using System.IO;
using Microsoft.Win32;
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ɏ󕥗����f�[�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɏ󕥗����f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21015�@�����@�F��</br>
    /// <br>Date       : 2007.01.30</br>
    /// <br></br>
    /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
    /// <br>Update Note: 30290 ���Ӑ�E�d����؂蕪��</br>
    /// <br>Date       : 2008.04.23</br>
    /// <br>Update Note: 22008 ���� PM.NS�p�ɏC��</br>
    /// <br>Date       : 2008.07.03</br>
    /// <br>Update Note: 2019/08/20 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11500099-00 PMKOBETSU-647</br>
    /// <br>           : �����d����M�����G���[�Ή�</br>
    /// <br>Update Note: 2020/08/28 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11600006-00</br>
    /// <br>             PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br> 
    /// </remarks>
    [Serializable]
    public class StockAcPayHistDB : RemoteDB, IStockAcPayHistDB
    {
        /// <summary>
        /// �݌Ɏ󕥗����f�[�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        /// </remarks>
        public StockAcPayHistDB()
            :
            base("MAZAI04336D", "Broadleaf.Application.Remoting.ParamData.StockAcPayHistWork", "STOCKACPAYHISTRF")
        {
        }
        //----- ADD 2019/08/20 ���O PMKOBETSU-647 �����d����M�����G���[�Ή� ---------->>>>>
        # region �� Const Members ��
        /// <summary>���O�f�[�^�ΏۃA�Z���u��ID</summary>
        private const string AssemblyID = "MAZAI04334R";
        /// <summary>���O�f�[�^�ΏۋN���v���O��������</summary>
        private const string BootProgramNm = "�݌Ɏ󕥗����f�[�^DB�����[�g";
        /// <summary>���O�f�[�^�ΏۃA�Z���u������</summary>
        private const string AssemblyNm = "�݌Ɏ󕥗����f�[�^�o�^";
        /// <summary>���O�f�[�^�ΏۃN���XID</summary>
        private const string ClassID = "StockAcPayHistDB";
        /// <summary>���O�f�[�^�Ώۏ�����</summary>
        private const string ProcNm = "WriteStockAcPayHistProcProc";
        /// <summary>���O�f�[�^���b�Z�[�W</summary>
        private const string Message = "�i���J�b�g�@�`�[�ԍ��F{0}�@���[�J�[���F{1}�@�i���F{2}";
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>> 
        // �`�[�X�V�^�C���A�E�g���Ԑݒ�t�@�C��
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XML�t�@�C�����������̃f�t�H���g�l
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
        # endregion �� Const Members ��
        //----- ADD 2019/08/20 ���O PMKOBETSU-647 �����d����M�����G���[�Ή� ----------<<<<<

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ󕥗����f�[�^���LIST��߂��܂�
        /// </summary>
        /// <param name="stockAcPayHistWork">��������</param>
        /// <param name="parastockAcPayHistWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ󕥗����f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        public int Search(out object stockAcPayHistWork, object parastockAcPayHistWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockAcPayHistWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                StockAcPayHistWork stockacpayhistWork = null;

                ArrayList stockacpayhistWorkList = parastockAcPayHistWork as ArrayList;
                if (stockacpayhistWorkList == null)
                {
                    stockacpayhistWork = parastockAcPayHistWork as StockAcPayHistWork;
                }
                else
                {
                    if (stockacpayhistWorkList.Count > 0)
                        stockacpayhistWork = stockacpayhistWorkList[0] as StockAcPayHistWork;
                }

                status = SearchStockAcPayHistProc(out stockacpayhistWorkList, stockacpayhistWork, readMode, logicalMode, ref sqlConnection);

                CustomSerializeArrayList retList = new CustomSerializeArrayList();
                retList.Add(stockacpayhistWorkList);
                stockAcPayHistWork = retList;
                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAcPayHisDtDB.Search");
                stockAcPayHistWork = new ArrayList();
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
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ󕥗����f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockacpayhistWorkList">��������</param>
        /// <param name="stockacpayhistWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ󕥗����f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        public int SearchStockAcPayHistProc(out ArrayList stockacpayhistWorkList, StockAcPayHistWork stockacpayhistWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return SearchStockAcPayHistProcProc(out stockacpayhistWorkList, stockacpayhistWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ󕥗����f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockacpayhistWorkList">��������</param>
        /// <param name="stockacpayhistWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ󕥗����f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        private int SearchStockAcPayHistProcProc(out ArrayList stockacpayhistWorkList, StockAcPayHistWork stockacpayhistWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,IOGOODSDAYRF" + Environment.NewLine;
                selectTxt += "  ,ADDUPADATERF" + Environment.NewLine;
                selectTxt += "  ,ACPAYSLIPCDRF" + Environment.NewLine;
                selectTxt += "  ,ACPAYSLIPNUMRF" + Environment.NewLine;
                selectTxt += "  ,ACPAYSLIPROWNORF" + Environment.NewLine;
                selectTxt += "  ,ACPAYHISTDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,ACPAYTRANSCDRF" + Environment.NewLine;
                selectTxt += "  ,INPUTSECTIONCDRF" + Environment.NewLine;
                selectTxt += "  ,INPUTSECTIONGUIDNMRF" + Environment.NewLine;
                selectTxt += "  ,INPUTAGENCDRF" + Environment.NewLine;
                selectTxt += "  ,INPUTAGENNMRF" + Environment.NewLine;
                selectTxt += "  ,MOVESTATUSRF" + Environment.NewLine;
                selectTxt += "  ,CUSTSLIPNORF" + Environment.NewLine;
                selectTxt += "  ,SLIPDTLNUMRF" + Environment.NewLine;
                selectTxt += "  ,ACPAYNOTERF" + Environment.NewLine;
                selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGOODSFULLNAMERF" + Environment.NewLine;
                selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,SHELFNORF" + Environment.NewLine;
                selectTxt += "  ,BFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,BFSECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,BFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,BFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,BFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,AFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,AFSECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,AFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,AFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,AFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,OPENPRICEDIVRF" + Environment.NewLine;
                selectTxt += "  ,LISTPRICETAXEXCFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKPRICERF" + Environment.NewLine;
                selectTxt += "  ,SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                selectTxt += "  ,SALESMONEYRF" + Environment.NewLine;
                selectTxt += "  ,SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,NONADDUPSHIPMCNTRF" + Environment.NewLine;
                selectTxt += "  ,NONADDUPARRGDSCNTRF" + Environment.NewLine;
                selectTxt += "  ,SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,PRESENTSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " FROM STOCKACPAYHISTRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockacpayhistWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockAcPayHistWorkFromReader(ref myReader));

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

            stockacpayhistWorkList = al;

            return status;
        }

        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ󕥗����f�[�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">StockAcPayHistWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ󕥗����f�[�^��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                StockAcPayHistWork stockacpayhistWork = new StockAcPayHistWork();

                // XML�̓ǂݍ���
                stockacpayhistWork = (StockAcPayHistWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockAcPayHistWork));
                if (stockacpayhistWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref stockacpayhistWork, readMode, ref sqlConnection);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(stockacpayhistWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAcPayHistDB.Read");
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ󕥗����f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockacpayhistWork">StockAcPayHistWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ󕥗����f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        public int ReadProc(ref StockAcPayHistWork stockacpayhistWork, int readMode, ref SqlConnection sqlConnection)
        {
            return ReadProcProc(ref stockacpayhistWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ󕥗����f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockacpayhistWork">StockAcPayHistWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ󕥗����f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        private int ReadProcProc(ref StockAcPayHistWork stockacpayhistWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,IOGOODSDAYRF" + Environment.NewLine;
                selectTxt += "  ,ADDUPADATERF" + Environment.NewLine;
                selectTxt += "  ,ACPAYSLIPCDRF" + Environment.NewLine;
                selectTxt += "  ,ACPAYSLIPNUMRF" + Environment.NewLine;
                selectTxt += "  ,ACPAYSLIPROWNORF" + Environment.NewLine;
                selectTxt += "  ,ACPAYHISTDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,ACPAYTRANSCDRF" + Environment.NewLine;
                selectTxt += "  ,INPUTSECTIONCDRF" + Environment.NewLine;
                selectTxt += "  ,INPUTSECTIONGUIDNMRF" + Environment.NewLine;
                selectTxt += "  ,INPUTAGENCDRF" + Environment.NewLine;
                selectTxt += "  ,INPUTAGENNMRF" + Environment.NewLine;
                selectTxt += "  ,MOVESTATUSRF" + Environment.NewLine;
                selectTxt += "  ,CUSTSLIPNORF" + Environment.NewLine;
                selectTxt += "  ,SLIPDTLNUMRF" + Environment.NewLine;
                selectTxt += "  ,ACPAYNOTERF" + Environment.NewLine;
                selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGOODSFULLNAMERF" + Environment.NewLine;
                selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,SHELFNORF" + Environment.NewLine;
                selectTxt += "  ,BFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,BFSECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,BFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,BFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,BFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,AFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,AFSECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,AFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,AFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,AFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,OPENPRICEDIVRF" + Environment.NewLine;
                selectTxt += "  ,LISTPRICETAXEXCFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKPRICERF" + Environment.NewLine;
                selectTxt += "  ,SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                selectTxt += "  ,SALESMONEYRF" + Environment.NewLine;
                selectTxt += "  ,SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,NONADDUPSHIPMCNTRF" + Environment.NewLine;
                selectTxt += "  ,NONADDUPARRGDSCNTRF" + Environment.NewLine;
                selectTxt += "  ,SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,PRESENTSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " FROM STOCKACPAYHISTRF" + Environment.NewLine;
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND ACPAYSLIPCDRF=@FINDACPAYSLIPCD" + Environment.NewLine;
                selectTxt += "  AND ACPAYSLIPNUMRF=@FINDACPAYSLIPNUM" + Environment.NewLine;
                selectTxt += "  AND ACPAYSLIPROWNORF=@FINDACPAYSLIPROWNO" + Environment.NewLine;
                selectTxt += "  AND ACPAYHISTDATETIMERF=@FINDACPAYHISTDATETIME" + Environment.NewLine;

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAcPaySlipCd = sqlCommand.Parameters.Add("@FINDACPAYSLIPCD", SqlDbType.Int);
                    SqlParameter findParaAcPaySlipNum = sqlCommand.Parameters.Add("@FINDACPAYSLIPNUM", SqlDbType.NVarChar);
                    SqlParameter findParaAcPaySlipRowNo = sqlCommand.Parameters.Add("@FINDACPAYSLIPROWNO", SqlDbType.Int);
                    SqlParameter findParaAcPayHistDateTime = sqlCommand.Parameters.Add("@FINDACPAYHISTDATETIME", SqlDbType.BigInt);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.EnterpriseCode);
                    findParaAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipCd);
                    findParaAcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AcPaySlipNum);
                    findParaAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipRowNo);
                    findParaAcPayHistDateTime.Value = SqlDataMediator.SqlSetInt64(stockacpayhistWork.AcPayHistDateTime);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        stockacpayhistWork = CopyToStockAcPayHistWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// �݌Ɏ󕥗����f�[�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="stockAcPayHistWork">StockAcPayHistWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɏ󕥗����f�[�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        public int Write(ref object stockAcPayHistWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            try
            {
                ArrayList stockAcPayHistList = null;

                //�p�����[�^�̃L���X�g
                CustomSerializeArrayList csaList = stockAcPayHistWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    ArrayList wkal = csaList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //�݌Ɏ󕥗����}�X�^
                            if (wkal[0] is StockAcPayHistWork) stockAcPayHistList = wkal;
                        }
                    }
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //�L�[�ƂȂ�X�V���t
                long acPayHistDateTime = DateTime.Now.Ticks;

                //�݌Ɏ󕥗����}�X�^Write
                if (stockAcPayHistList != null)
                {
                    status = WriteStockAcPayHistProc(ref stockAcPayHistList, ref sqlConnection, ref sqlTransaction);
                    retList.Add(stockAcPayHistList);

                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                stockAcPayHistWork = retList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAcPayHistDB.Write(ref object stockAcPayHistWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        
        /// <summary>
        /// �݌Ɏ󕥗����f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockAcPayHistWorkList">StockAcPayHistWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɏ󕥗����f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        public int WriteStockAcPayHistProc(ref ArrayList stockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteStockAcPayHistProcProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌Ɏ󕥗����f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockAcPayHistWorkList">StockAcPayHistWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɏ󕥗����f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br>Update Note: 2019/08/20 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11500099-00 PMKOBETSU-647</br>
        /// <br>           : �����d����M�����G���[�Ή�</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        private int WriteStockAcPayHistProcProc(ref ArrayList stockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string selectTxt = "";

            selectTxt += "INSERT INTO STOCKACPAYHISTRF" + Environment.NewLine;
            selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
            selectTxt += "  ,IOGOODSDAYRF" + Environment.NewLine;
            selectTxt += "  ,ADDUPADATERF" + Environment.NewLine;
            selectTxt += "  ,ACPAYSLIPCDRF" + Environment.NewLine;
            selectTxt += "  ,ACPAYSLIPNUMRF" + Environment.NewLine;
            selectTxt += "  ,ACPAYSLIPROWNORF" + Environment.NewLine;
            selectTxt += "  ,ACPAYHISTDATETIMERF" + Environment.NewLine;
            selectTxt += "  ,ACPAYTRANSCDRF" + Environment.NewLine;
            selectTxt += "  ,INPUTSECTIONCDRF" + Environment.NewLine;
            selectTxt += "  ,INPUTSECTIONGUIDNMRF" + Environment.NewLine;
            selectTxt += "  ,INPUTAGENCDRF" + Environment.NewLine;
            selectTxt += "  ,INPUTAGENNMRF" + Environment.NewLine;
            selectTxt += "  ,MOVESTATUSRF" + Environment.NewLine;
            selectTxt += "  ,CUSTSLIPNORF" + Environment.NewLine;
            selectTxt += "  ,SLIPDTLNUMRF" + Environment.NewLine;
            selectTxt += "  ,ACPAYNOTERF" + Environment.NewLine;
            selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
            selectTxt += "  ,MAKERNAMERF" + Environment.NewLine;
            selectTxt += "  ,GOODSNORF" + Environment.NewLine;
            selectTxt += "  ,GOODSNAMERF" + Environment.NewLine;
            selectTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
            selectTxt += "  ,BLGOODSFULLNAMERF" + Environment.NewLine;
            selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
            selectTxt += "  ,SECTIONGUIDENMRF" + Environment.NewLine;
            selectTxt += "  ,WAREHOUSECODERF" + Environment.NewLine;
            selectTxt += "  ,WAREHOUSENAMERF" + Environment.NewLine;
            selectTxt += "  ,SHELFNORF" + Environment.NewLine;
            selectTxt += "  ,BFSECTIONCODERF" + Environment.NewLine;
            selectTxt += "  ,BFSECTIONGUIDENMRF" + Environment.NewLine;
            selectTxt += "  ,BFENTERWAREHCODERF" + Environment.NewLine;
            selectTxt += "  ,BFENTERWAREHNAMERF" + Environment.NewLine;
            selectTxt += "  ,BFSHELFNORF" + Environment.NewLine;
            selectTxt += "  ,AFSECTIONCODERF" + Environment.NewLine;
            selectTxt += "  ,AFSECTIONGUIDENMRF" + Environment.NewLine;
            selectTxt += "  ,AFENTERWAREHCODERF" + Environment.NewLine;
            selectTxt += "  ,AFENTERWAREHNAMERF" + Environment.NewLine;
            selectTxt += "  ,AFSHELFNORF" + Environment.NewLine;
            selectTxt += "  ,CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "  ,CUSTOMERSNMRF" + Environment.NewLine;
            selectTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
            selectTxt += "  ,SUPPLIERSNMRF" + Environment.NewLine;
            selectTxt += "  ,ARRIVALCNTRF" + Environment.NewLine;
            selectTxt += "  ,SHIPMENTCNTRF" + Environment.NewLine;
            selectTxt += "  ,OPENPRICEDIVRF" + Environment.NewLine;
            selectTxt += "  ,LISTPRICETAXEXCFLRF" + Environment.NewLine;
            selectTxt += "  ,STOCKUNITPRICEFLRF" + Environment.NewLine;
            selectTxt += "  ,STOCKPRICERF" + Environment.NewLine;
            selectTxt += "  ,SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
            selectTxt += "  ,SALESMONEYRF" + Environment.NewLine;
            selectTxt += "  ,SUPPLIERSTOCKRF" + Environment.NewLine;
            selectTxt += "  ,ACPODRCOUNTRF" + Environment.NewLine;
            selectTxt += "  ,SALESORDERCOUNTRF" + Environment.NewLine;
            selectTxt += "  ,MOVINGSUPLISTOCKRF" + Environment.NewLine;
            selectTxt += "  ,NONADDUPSHIPMCNTRF" + Environment.NewLine;
            selectTxt += "  ,NONADDUPARRGDSCNTRF" + Environment.NewLine;
            selectTxt += "  ,SHIPMENTPOSCNTRF" + Environment.NewLine;
            selectTxt += "  ,PRESENTSTOCKCNTRF" + Environment.NewLine;
            selectTxt += " )" + Environment.NewLine;
            selectTxt += " VALUES" + Environment.NewLine;
            selectTxt += " (@CREATEDATETIME" + Environment.NewLine;
            selectTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
            selectTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
            selectTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
            selectTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
            selectTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
            selectTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
            selectTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
            selectTxt += "  ,@IOGOODSDAY" + Environment.NewLine;
            selectTxt += "  ,@ADDUPADATE" + Environment.NewLine;
            selectTxt += "  ,@ACPAYSLIPCD" + Environment.NewLine;
            selectTxt += "  ,@ACPAYSLIPNUM" + Environment.NewLine;
            selectTxt += "  ,@ACPAYSLIPROWNO" + Environment.NewLine;
            selectTxt += "  ,@ACPAYHISTDATETIME" + Environment.NewLine;
            selectTxt += "  ,@ACPAYTRANSCD" + Environment.NewLine;
            selectTxt += "  ,@INPUTSECTIONCD" + Environment.NewLine;
            selectTxt += "  ,@INPUTSECTIONGUIDNM" + Environment.NewLine;
            selectTxt += "  ,@INPUTAGENCD" + Environment.NewLine;
            selectTxt += "  ,@INPUTAGENNM" + Environment.NewLine;
            selectTxt += "  ,@MOVESTATUS" + Environment.NewLine;
            selectTxt += "  ,@CUSTSLIPNO" + Environment.NewLine;
            selectTxt += "  ,@SLIPDTLNUM" + Environment.NewLine;
            selectTxt += "  ,@ACPAYNOTE" + Environment.NewLine;
            selectTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
            selectTxt += "  ,@MAKERNAME" + Environment.NewLine;
            selectTxt += "  ,@GOODSNO" + Environment.NewLine;
            selectTxt += "  ,@GOODSNAME" + Environment.NewLine;
            selectTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
            selectTxt += "  ,@BLGOODSFULLNAME" + Environment.NewLine;
            selectTxt += "  ,@SECTIONCODE" + Environment.NewLine;
            selectTxt += "  ,@SECTIONGUIDENM" + Environment.NewLine;
            selectTxt += "  ,@WAREHOUSECODE" + Environment.NewLine;
            selectTxt += "  ,@WAREHOUSENAME" + Environment.NewLine;
            selectTxt += "  ,@SHELFNO" + Environment.NewLine;
            selectTxt += "  ,@BFSECTIONCODE" + Environment.NewLine;
            selectTxt += "  ,@BFSECTIONGUIDENM" + Environment.NewLine;
            selectTxt += "  ,@BFENTERWAREHCODE" + Environment.NewLine;
            selectTxt += "  ,@BFENTERWAREHNAME" + Environment.NewLine;
            selectTxt += "  ,@BFSHELFNO" + Environment.NewLine;
            selectTxt += "  ,@AFSECTIONCODE" + Environment.NewLine;
            selectTxt += "  ,@AFSECTIONGUIDENM" + Environment.NewLine;
            selectTxt += "  ,@AFENTERWAREHCODE" + Environment.NewLine;
            selectTxt += "  ,@AFENTERWAREHNAME" + Environment.NewLine;
            selectTxt += "  ,@AFSHELFNO" + Environment.NewLine;
            selectTxt += "  ,@CUSTOMERCODE" + Environment.NewLine;
            selectTxt += "  ,@CUSTOMERSNM" + Environment.NewLine;
            selectTxt += "  ,@SUPPLIERCD" + Environment.NewLine;
            selectTxt += "  ,@SUPPLIERSNM" + Environment.NewLine;
            selectTxt += "  ,@ARRIVALCNT" + Environment.NewLine;
            selectTxt += "  ,@SHIPMENTCNT" + Environment.NewLine;
            selectTxt += "  ,@OPENPRICEDIV" + Environment.NewLine;
            selectTxt += "  ,@LISTPRICETAXEXCFL" + Environment.NewLine;
            selectTxt += "  ,@STOCKUNITPRICEFL" + Environment.NewLine;
            selectTxt += "  ,@STOCKPRICE" + Environment.NewLine;
            selectTxt += "  ,@SALESUNPRCTAXEXCFL" + Environment.NewLine;
            selectTxt += "  ,@SALESMONEY" + Environment.NewLine;
            selectTxt += "  ,@SUPPLIERSTOCK" + Environment.NewLine;
            selectTxt += "  ,@ACPODRCOUNT" + Environment.NewLine;
            selectTxt += "  ,@SALESORDERCOUNT" + Environment.NewLine;
            selectTxt += "  ,@MOVINGSUPLISTOCK" + Environment.NewLine;
            selectTxt += "  ,@NONADDUPSHIPMCNT" + Environment.NewLine;
            selectTxt += "  ,@NONADDUPARRGDSCNT" + Environment.NewLine;
            selectTxt += "  ,@SHIPMENTPOSCNT" + Environment.NewLine;
            selectTxt += "  ,@PRESENTSTOCKCNT" + Environment.NewLine;
            selectTxt += " )" + Environment.NewLine;

            //�V�K�쐬����SQL���𐶐�
            sqlCommand = new SqlCommand(selectTxt,sqlConnection,sqlTransaction);
            
            #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraIoGoodsDay = sqlCommand.Parameters.Add("@IOGOODSDAY", SqlDbType.Int);
            SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
            SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
            SqlParameter paraAcPaySlipNum = sqlCommand.Parameters.Add("@ACPAYSLIPNUM", SqlDbType.NVarChar);
            SqlParameter paraAcPaySlipRowNo = sqlCommand.Parameters.Add("@ACPAYSLIPROWNO", SqlDbType.Int);
            SqlParameter paraAcPayHistDateTime = sqlCommand.Parameters.Add("@ACPAYHISTDATETIME", SqlDbType.BigInt);
            SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
            SqlParameter paraInputSectionCd = sqlCommand.Parameters.Add("@INPUTSECTIONCD", SqlDbType.NChar);
            SqlParameter paraInputSectionGuidNm = sqlCommand.Parameters.Add("@INPUTSECTIONGUIDNM", SqlDbType.NVarChar);
            SqlParameter paraInputAgenCd = sqlCommand.Parameters.Add("@INPUTAGENCD", SqlDbType.NVarChar);
            SqlParameter paraInputAgenNm = sqlCommand.Parameters.Add("@INPUTAGENNM", SqlDbType.NVarChar);
            SqlParameter paraMoveStatus = sqlCommand.Parameters.Add("@MOVESTATUS", SqlDbType.Int);
            SqlParameter paraCustSlipNo = sqlCommand.Parameters.Add("@CUSTSLIPNO", SqlDbType.NVarChar);
            SqlParameter paraSlipDtlNum = sqlCommand.Parameters.Add("@SLIPDTLNUM", SqlDbType.BigInt);
            SqlParameter paraAcPayNote = sqlCommand.Parameters.Add("@ACPAYNOTE", SqlDbType.NVarChar);
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
            SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
            SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            SqlParameter paraSectionGuideNm = sqlCommand.Parameters.Add("@SECTIONGUIDENM", SqlDbType.NVarChar);
            SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
            SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
            SqlParameter paraShelfNo = sqlCommand.Parameters.Add("@SHELFNO", SqlDbType.NVarChar);
            SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@BFSECTIONCODE", SqlDbType.NChar);
            SqlParameter paraBfSectionGuideNm = sqlCommand.Parameters.Add("@BFSECTIONGUIDENM", SqlDbType.NChar);
            SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@BFENTERWAREHCODE", SqlDbType.NChar);
            SqlParameter paraBfEnterWarehName = sqlCommand.Parameters.Add("@BFENTERWAREHNAME", SqlDbType.NVarChar);
            SqlParameter paraBfShelfNo = sqlCommand.Parameters.Add("@BFSHELFNO", SqlDbType.NVarChar);
            SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@AFSECTIONCODE", SqlDbType.NChar);
            SqlParameter paraAfSectionGuideNm = sqlCommand.Parameters.Add("@AFSECTIONGUIDENM", SqlDbType.NChar);
            SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@AFENTERWAREHCODE", SqlDbType.NChar);
            SqlParameter paraAfEnterWarehName = sqlCommand.Parameters.Add("@AFENTERWAREHNAME", SqlDbType.NVarChar);
            SqlParameter paraAfShelfNo = sqlCommand.Parameters.Add("@AFSHELFNO", SqlDbType.NVarChar);
            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
            SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
            SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
            SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
            SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
            SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
            SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
            SqlParameter paraListPriceTaxExcFl = sqlCommand.Parameters.Add("@LISTPRICETAXEXCFL", SqlDbType.Float);
            SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
            SqlParameter paraStockPrice = sqlCommand.Parameters.Add("@STOCKPRICE", SqlDbType.BigInt);
            SqlParameter paraSalesUnPrcTaxExcFl = sqlCommand.Parameters.Add("@SALESUNPRCTAXEXCFL", SqlDbType.Float);
            SqlParameter paraSalesMoney = sqlCommand.Parameters.Add("@SALESMONEY", SqlDbType.BigInt);
            SqlParameter paraSupplierStock = sqlCommand.Parameters.Add("@SUPPLIERSTOCK", SqlDbType.Float);
            SqlParameter paraAcpOdrCount = sqlCommand.Parameters.Add("@ACPODRCOUNT", SqlDbType.Float);
            SqlParameter paraSalesOrderCount = sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
            SqlParameter paraMovingSupliStock = sqlCommand.Parameters.Add("@MOVINGSUPLISTOCK", SqlDbType.Float);
            SqlParameter paraNonAddUpShipmCnt = sqlCommand.Parameters.Add("@NONADDUPSHIPMCNT", SqlDbType.Float);
            SqlParameter paraNonAddUpArrGdsCnt = sqlCommand.Parameters.Add("@NONADDUPARRGDSCNT", SqlDbType.Float);
            SqlParameter paraShipmentPosCnt = sqlCommand.Parameters.Add("@SHIPMENTPOSCNT", SqlDbType.Float);
            SqlParameter paraPresentStockCnt = sqlCommand.Parameters.Add("@PRESENTSTOCKCNT", SqlDbType.Float);
            #endregion
            
            string field = string.Empty;
            // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // �R�}���h�^�C���A�E�g�i�b�j
            this.GetXmlInfo(ref dbCommandTimeout);
            // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
            try
            {
                if (stockAcPayHistWorkList != null)
                {
                    //�d���h�~�p��Key���쐬
                    int keyCode = 1;
                
                    for (int i = 0; i < stockAcPayHistWorkList.Count; i++)
                    {
                        StockAcPayHistWork stockacpayhistWork = stockAcPayHistWorkList[i] as StockAcPayHistWork;

                        //�o�א��A���א��Ƃ��ɂO�̏ꍇ�͎󕥗������쐬���Ȃ�
                        //if (stockacpayhistWork.ShipmentCnt == 0 && stockacpayhistWork.ArrivalCnt == 0) continue; //���z�������R�[�h���l�����č폜 2009/01/19

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)stockacpayhistWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        //���A�d���̓��͂ŕi�ԕύX���čX�V����p�^�[��������ׁA
                        //�P���R�[�h���f�[�^�X�V������ύX����
                        stockacpayhistWork.AcPayHistDateTime = DateTime.Now.Ticks;

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockacpayhistWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockacpayhistWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockacpayhistWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.LogicalDeleteCode);
                        paraIoGoodsDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockacpayhistWork.IoGoodsDay);
                        paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockacpayhistWork.AddUpADate);
                        paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipCd);
                        paraAcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AcPaySlipNum);
                        paraAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(keyCode);  //���d���p���ڂƂ���B
                        paraAcPayHistDateTime.Value = SqlDataMediator.SqlSetInt64(stockacpayhistWork.AcPayHistDateTime);
                        paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPayTransCd);
                        paraInputSectionCd.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.InputSectionCd);
                        paraInputSectionGuidNm.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.InputSectionGuidNm);
                        paraInputAgenCd.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.InputAgenCd);
                        paraInputAgenNm.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.InputAgenNm);
                        paraMoveStatus.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.MoveStatus);
                        paraCustSlipNo.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.CustSlipNo);
                        paraSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockacpayhistWork.SlipDtlNum);
                        paraAcPayNote.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AcPayNote);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.GoodsMakerCd);
                        paraMakerName.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.MakerName);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.GoodsNo);
                        //----- UPD 2019/08/20 ���O PMKOBETSU-647 �����d����M�����G���[�Ή� ---------->>>>>
                        //paraGoodsName.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.GoodsName);
                        if (!string.IsNullOrEmpty(stockacpayhistWork.GoodsName) && stockacpayhistWork.GoodsName.Length > 40)
                        {
                            paraGoodsName.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.GoodsName.Substring(0, 40));
                            this.WriteOprtnHisLog(ref sqlConnection, ref sqlTransaction, stockacpayhistWork.AcPaySlipNum, stockacpayhistWork.MakerName, stockacpayhistWork.GoodsName.Trim());
                        }
                        else
                        {
                            paraGoodsName.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.GoodsName);
                        }
                        //----- UPD 2019/08/20 ���O PMKOBETSU-647 �����d����M�����G���[�Ή� ----------<<<<<
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.BLGoodsCode);
                        paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.BLGoodsFullName);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.SectionCode);
                        paraSectionGuideNm.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.SectionGuideNm);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.WarehouseCode);
                        paraWarehouseName.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.WarehouseName);
                        paraShelfNo.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.ShelfNo);
                        paraBfSectionCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.BfSectionCode);
                        paraBfSectionGuideNm.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.BfSectionGuideNm);
                        paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.BfEnterWarehCode);
                        paraBfEnterWarehName.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.BfEnterWarehName);
                        paraBfShelfNo.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.BfShelfNo);
                        paraAfSectionCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AfSectionCode);
                        paraAfSectionGuideNm.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AfSectionGuideNm);
                        paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AfEnterWarehCode);
                        paraAfEnterWarehName.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AfEnterWarehName);
                        paraAfShelfNo.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AfShelfNo);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.CustomerCode);
                        paraCustomerSnm.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.CustomerSnm);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.SupplierCd);
                        paraSupplierSnm.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.SupplierSnm);
                        paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.ArrivalCnt);
                        paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.ShipmentCnt);
                        paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.OpenPriceDiv);
                        paraListPriceTaxExcFl.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.ListPriceTaxExcFl);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.StockUnitPriceFl);
                        paraStockPrice.Value = SqlDataMediator.SqlSetInt64(stockacpayhistWork.StockPrice);
                        paraSalesUnPrcTaxExcFl.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.SalesUnPrcTaxExcFl);
                        paraSalesMoney.Value = SqlDataMediator.SqlSetInt64(stockacpayhistWork.SalesMoney);
                        paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.SupplierStock);
                        paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.AcpOdrCount);
                        paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.SalesOrderCount);
                        paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.MovingSupliStock);
                        paraNonAddUpShipmCnt.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.NonAddUpShipmCnt);
                        paraNonAddUpArrGdsCnt.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.NonAddUpArrGdsCnt);
                        paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.ShipmentPosCnt);
                        paraPresentStockCnt.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.PresentStockCnt);
                        #endregion

                        sqlCommand.CommandTimeout = dbCommandTimeout; //ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή�
                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockacpayhistWork);

                        //�L�[���ڃC���N�������g
                        keyCode++;
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex,"",ex.Number);
            }
            catch (Exception ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex.Message);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockAcPayHistWorkList = al;

            return status;
        }

        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
        #region �ݒ�t�@�C���擾
        /// <summary>
        /// �ݒ�t�@�C���擾
        /// </summary>
        /// <param name="dbCommandTimeout">�^�C���A�E�g����</param>
        /// <remarks>
        /// <br>Note         : �ݒ�t�@�C���擾�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // �����l�ݒ�
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //�^�C���A�E�g���Ԃ��擾
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "�ݒ�t�@�C���擾�G���[");
                }
            }

        }
        #endregion // �ݒ�t�@�C���擾

        #region XML�t�@�C������
        /// <summary>
        /// XML�t�@�C�����擾
        /// </summary>
        /// <returns>XML�t�@�C����</returns>
        /// <remarks>
        /// <br>Note         : XML���擾�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // �J�����g�f�B���N�g���擾
                homeDir = this.GetCurrentDirectory();

                // �f�B���N�g������XML�t�@�C������A��
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // �t�@�C�������݂��Ȃ��ꍇ�͋󔒂ɂ���
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XML�t�@�C������

        #region �J�����g�t�H���_
        /// <summary>
        /// �J�����g�t�H���_�擾
        /// </summary>
        /// <returns>XML�t�@�C����</returns>
        /// <remarks>
        /// <br>Note         : �J�����g�t�H���_�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML�i�[�f�B���N�g���擾
            try
            {
                // dll�i�[�p�X�������f�B���N�g���Ƃ���
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // �����́u\�v�͏�ɂȂ�

                // ���W�X�g�������USER_AP�̃L�[�����擾
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // ���W�X�g�������擾�ł��Ȃ��ꍇ�͏����f�B���N�g�� // �^�p�゠�肦�Ȃ��P�[�X
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // �擾�f�B���N�g�������݂��Ȃ��ꍇ�͏����f�B���N�g����ݒ�
                // �^�p�゠�肦�Ȃ��P�[�X
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_AP��LOG�t�H���_�Ƀ��O�o��
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // �J�����g�t�H���_
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// �݌Ɏ󕥗����f�[�^����_���폜���܂�
        /// </summary>
        /// <param name="stockAcPayHistWork">StockAcPayHistWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɏ󕥗����f�[�^����_���폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        public int LogicalDelete(ref object stockAcPayHistWork)
        {
            return LogicalDeleteStockAcPayHist(ref stockAcPayHistWork);
        }

        /// <summary>
        /// �_���폜�݌Ɏ󕥗����f�[�^���𕜊����܂�
        /// </summary>
        /// <param name="stockAcPayHistWork">StockAcPayHistWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�݌Ɏ󕥗����f�[�^���𕜊����܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        public int RevivalLogicalDelete(ref object stockAcPayHistWork)
        {
            return LogicalDeleteStockAcPayHist(ref stockAcPayHistWork);
        }

        /// <summary>
        /// �݌Ɏ󕥗����f�[�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="stockAcPayHistWork">StockAcPayHistWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɏ󕥗����f�[�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        private int LogicalDeleteStockAcPayHist(ref object stockAcPayHistWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            try
            {
                ArrayList stockAcPayHistList = null;

                //�p�����[�^�̃L���X�g
                CustomSerializeArrayList csaList = stockAcPayHistWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    ArrayList wkal = csaList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //�݌Ɏ󕥗����}�X�^
                            if (wkal[0] is StockAcPayHistWork) stockAcPayHistList = wkal;
                        }
                    }
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //�݌Ɏ󕥗���_���폜
                if (stockAcPayHistList != null)
                {
                    status = LogicalDeleteStockAcPayHistProc(ref stockAcPayHistList, ref sqlConnection, ref sqlTransaction);
                    retList.Add(stockAcPayHistList);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                stockAcPayHistWork = retList;
            }
            catch (Exception ex)
            {
                //string procModestr = "";

                base.WriteErrorLog(ex, "StockAcPayHistDB.LogicalDeleteStockAcPayHis");

                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �݌Ɏ󕥗����f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockAcPayHistWorkList">StockAcPayHistWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɏ󕥗����f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        public int LogicalDeleteStockAcPayHistProc(ref ArrayList stockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteStockAcPayHistProcProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌Ɏ󕥗����f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockAcPayHistWorkList">StockAcPayHistWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɏ󕥗����f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        private int LogicalDeleteStockAcPayHistProcProc(ref ArrayList stockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string selectTxt = "";
            
            int logicalDelCd = 0;

            try
            {
                if (stockAcPayHistWorkList != null)
                {
                    for (int i = 0; i < stockAcPayHistWorkList.Count; i++)
                    {
                        StockAcPayHistWork stockacpayhistWork = stockAcPayHistWorkList[i] as StockAcPayHistWork;

                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "  STOCKACPAYHISTRF.UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " ,STOCKACPAYHISTRF.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += " ,STOCKACPAYHISTRF.LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "FROM STOCKACPAYHISTRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     STOCKACPAYHISTRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCKACPAYHISTRF.ACPAYSLIPCDRF=@FINDACPAYSLIPCD" + Environment.NewLine;
                        selectTxt += " AND STOCKACPAYHISTRF.ACPAYSLIPNUMRF=@FINDACPAYSLIPNUM" + Environment.NewLine;
                        selectTxt += " AND STOCKACPAYHISTRF.ACPAYSLIPROWNORF=@FINDACPAYSLIPROWNO" + Environment.NewLine;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaAcPaySlipCd = sqlCommand.Parameters.Add("@FINDACPAYSLIPCD", SqlDbType.Int);
                        SqlParameter findParaAcPaySlipNum = sqlCommand.Parameters.Add("@FINDACPAYSLIPNUM", SqlDbType.NVarChar);
                        SqlParameter findParaAcPaySlipRowNo = sqlCommand.Parameters.Add("@FINDACPAYSLIPROWNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.EnterpriseCode);
                        findParaAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipCd);
                        findParaAcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AcPaySlipNum);
                        findParaAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipRowNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            //if (_updateDateTime != stockacpayhistWork.UpdateDateTime)
                            //{
                            //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            //    sqlCommand.Cancel();
                            //    return status;
                            //}

                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            selectTxt = "";
                            selectTxt += "UPDATE STOCKACPAYHISTRF SET" + Environment.NewLine;
                            selectTxt += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "WHERE" + Environment.NewLine;
                            selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " AND ACPAYSLIPCDRF=@FINDACPAYSLIPCD" + Environment.NewLine;
                            selectTxt += " AND ACPAYSLIPNUMRF=@FINDACPAYSLIPNUM" + Environment.NewLine;
                            selectTxt += " AND ACPAYSLIPROWNORF=@FINDACPAYSLIPROWNO" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.EnterpriseCode);
                            findParaAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipCd);
                            findParaAcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AcPaySlipNum);
                            findParaAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipRowNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockacpayhistWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                            sqlCommand.Cancel();
                            return status;
                        }
                        else if (logicalDelCd == 0) stockacpayhistWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                        else stockacpayhistWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g

                        //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockacpayhistWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockacpayhistWork);
                    }

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
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockAcPayHistWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// �݌Ɏ󕥗����f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">�݌Ɏ󕥗����f�[�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �݌Ɏ󕥗����f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        public int Delete(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            try
            {
                ArrayList stockAcPayHistList = null;

                //�p�����[�^�̃L���X�g
                CustomSerializeArrayList csaList = paraobj as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    ArrayList wkal = csaList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //�݌Ɏ󕥗����}�X�^
                            if (wkal[0] is StockAcPayHistWork) stockAcPayHistList = wkal;
                        }
                    }
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //�݌Ɏ󕥗����폜
                if (stockAcPayHistList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = DeleteStockAcPayHistProc(stockAcPayHistList, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAcPayHistDB.Delete");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// �݌Ɏ󕥗����f�[�^���𕨗��폜���܂�(�O�������SqlConnection, SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockacpayhistWorkList">�݌Ɏ󕥗����f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �݌Ɏ󕥗����f�[�^���𕨗��폜���܂�(�O�������SqlConnection, SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        public int DeleteStockAcPayHistProc(ArrayList stockacpayhistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockAcPayHistProcProc(stockacpayhistWorkList, ref sqlConnection, ref sqlTransaction);
        }
        
        /// <summary>
        /// �݌Ɏ󕥗����f�[�^���𕨗��폜���܂�(�O�������SqlConnection, SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockacpayhistWorkList">�݌Ɏ󕥗����f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �݌Ɏ󕥗����f�[�^���𕨗��폜���܂�(�O�������SqlConnection, SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        private int DeleteStockAcPayHistProcProc(ArrayList stockacpayhistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string selectTxt = "";
            try
            {

                for (int i = 0; i < stockacpayhistWorkList.Count; i++)
                {
                    StockAcPayHistWork stockacpayhistWork = stockacpayhistWorkList[i] as StockAcPayHistWork;

                    selectTxt = "";
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += "  STOCKACPAYHISTRF.UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " ,STOCKACPAYHISTRF.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " ,STOCKACPAYHISTRF.LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += "FROM STOCKACPAYHISTRF" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += "     STOCKACPAYHISTRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND STOCKACPAYHISTRF.ACPAYSLIPCDRF=@FINDACPAYSLIPCD" + Environment.NewLine;
                    selectTxt += " AND STOCKACPAYHISTRF.ACPAYSLIPNUMRF=@FINDACPAYSLIPNUM" + Environment.NewLine;
                    selectTxt += " AND STOCKACPAYHISTRF.ACPAYSLIPROWNORF=@FINDACPAYSLIPROWNO" + Environment.NewLine;

                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAcPaySlipCd = sqlCommand.Parameters.Add("@FINDACPAYSLIPCD", SqlDbType.Int);
                    SqlParameter findParaAcPaySlipNum = sqlCommand.Parameters.Add("@FINDACPAYSLIPNUM", SqlDbType.NVarChar);
                    SqlParameter findParaAcPaySlipRowNo = sqlCommand.Parameters.Add("@FINDACPAYSLIPROWNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.EnterpriseCode);
                    findParaAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipCd);
                    findParaAcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AcPaySlipNum);
                    findParaAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipRowNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != stockacpayhistWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        selectTxt = "";
                        selectTxt += "DELETE" + Environment.NewLine;
                        selectTxt += "FROM STOCKACPAYHISTRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND ACPAYSLIPCDRF=@FINDACPAYSLIPCD" + Environment.NewLine;
                        selectTxt += " AND ACPAYSLIPNUMRF=@FINDACPAYSLIPNUM" + Environment.NewLine;
                        selectTxt += " AND ACPAYSLIPROWNORF=@FINDACPAYSLIPROWNO" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.EnterpriseCode);
                        findParaAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipCd);
                        findParaAcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AcPaySlipNum);
                        findParaAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipRowNo);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="stockAcPayHistWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 ���� DC.NS�p�ɏC��</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockAcPayHistWork stockAcPayHistWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += "     ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //�󕥌��`�[�敪
            if (stockAcPayHistWork.AcPaySlipCd != 0)
            {
                retstring += " AND ACPAYSLIPCDRF=@FINDACPAYSLIPCD" + Environment.NewLine;
                SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@FINDACPAYSLIPCD", SqlDbType.Int);
                paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockAcPayHistWork.AcPaySlipCd);
            }

            //�󕥌��`�[�ԍ�
            if (string.IsNullOrEmpty(stockAcPayHistWork.AcPaySlipNum) == false)
            {
                retstring += " AND ACPAYSLIPNUMRF=@FINDACPAYSLIPNUM" + Environment.NewLine;
                SqlParameter paraAcPaySlipNum = sqlCommand.Parameters.Add("@FINDACPAYSLIPNUM", SqlDbType.NVarChar);
                paraAcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.AcPaySlipNum);
            }

            //�󕥌��s�ԍ�
            if (stockAcPayHistWork.AcPaySlipRowNo != 0)
            {
                retstring += " AND ACPAYSLIPROWNORF=@FINDACPAYSLIPROWNO" + Environment.NewLine;
                SqlParameter paraAcPaySlipRowNo = sqlCommand.Parameters.Add("@FINDACPAYSLIPROWNO", SqlDbType.Int);
                paraAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(stockAcPayHistWork.AcPaySlipRowNo);
            }

            return retstring;
        }
        
        #endregion

        #region [�N���X�i�[����]

        /// <summary>
        /// �N���X�i�[���� Reader �� StockAcPayHistWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockAcPayHistWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.07 ���� DC.NS�p�ɏC��</br>
        /// </remarks>
        public StockAcPayHistWork CopyToStockAcPayHistWorkFromReader(ref SqlDataReader myReader)
        {
            StockAcPayHistWork wkStockAcPayHistWork = new StockAcPayHistWork();

            #region �N���X�֊i�[
            wkStockAcPayHistWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockAcPayHistWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockAcPayHistWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockAcPayHistWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockAcPayHistWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockAcPayHistWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockAcPayHistWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockAcPayHistWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IOGOODSDAYRF"));
            wkStockAcPayHistWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            wkStockAcPayHistWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
            wkStockAcPayHistWork.AcPaySlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACPAYSLIPNUMRF"));
            wkStockAcPayHistWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPROWNORF"));
            wkStockAcPayHistWork.AcPayHistDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPAYHISTDATETIMERF"));
            wkStockAcPayHistWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
            wkStockAcPayHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTSECTIONCDRF"));
            wkStockAcPayHistWork.InputSectionGuidNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTSECTIONGUIDNMRF"));
            wkStockAcPayHistWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
            wkStockAcPayHistWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
            wkStockAcPayHistWork.MoveStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTATUSRF"));
            wkStockAcPayHistWork.CustSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTSLIPNORF"));
            wkStockAcPayHistWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLIPDTLNUMRF"));
            wkStockAcPayHistWork.AcPayNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACPAYNOTERF"));
            wkStockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStockAcPayHistWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkStockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStockAcPayHistWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkStockAcPayHistWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkStockAcPayHistWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkStockAcPayHistWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockAcPayHistWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkStockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStockAcPayHistWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkStockAcPayHistWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNORF"));
            wkStockAcPayHistWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF"));
            wkStockAcPayHistWork.BfSectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDENMRF"));
            wkStockAcPayHistWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
            wkStockAcPayHistWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
            wkStockAcPayHistWork.BfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
            wkStockAcPayHistWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF"));
            wkStockAcPayHistWork.AfSectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDENMRF"));
            wkStockAcPayHistWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
            wkStockAcPayHistWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
            wkStockAcPayHistWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
            wkStockAcPayHistWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkStockAcPayHistWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkStockAcPayHistWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkStockAcPayHistWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkStockAcPayHistWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
            wkStockAcPayHistWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            wkStockAcPayHistWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            wkStockAcPayHistWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            wkStockAcPayHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockAcPayHistWork.StockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICERF"));
            wkStockAcPayHistWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
            wkStockAcPayHistWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYRF"));
            wkStockAcPayHistWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
            wkStockAcPayHistWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
            wkStockAcPayHistWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
            wkStockAcPayHistWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
            wkStockAcPayHistWork.NonAddUpShipmCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NONADDUPSHIPMCNTRF"));
            wkStockAcPayHistWork.NonAddUpArrGdsCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NONADDUPARRGDSCNTRF"));
            wkStockAcPayHistWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
            wkStockAcPayHistWork.PresentStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRESENTSTOCKCNTRF"));
            #endregion

            return wkStockAcPayHistWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.30</br>
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

        //----- ADD 2019/08/20 ���O PMKOBETSU-647 �����d����M�����G���[�Ή� ---------->>>>>
        #region ���엚�����O�������ݏ���
        /// <summary>
        /// ���엚�����O�������ݏ���
        /// </summary>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="slipNo">�`�[�ԍ�</param>
        /// <param name="makerName">���[�J�[��</param>
        /// <param name="goodsName">�i��(�J�b�g�O)</param>
        /// <remarks>
        /// <br>Note       : ���O�o�͏����B</br>
        /// <br>Programer  : ���O</br>
        /// <br>Date       : 2019/08/20</br>
        /// </remarks>
        private void WriteOprtnHisLog(ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string slipNo, string makerName, string goodsName)
        {
            try
            {
                // ���엚�����O�f�[�^�o�^�p���X�g
                ArrayList writeList = new ArrayList();

                # region [�������ݓ��e�̃Z�b�g]
                // ���엚�����O�f�[�^�o�^�p���[�N
                OprtnHisLogWork oprtnhislogWork = new OprtnHisLogWork();
                // ���O�f�[�^�ΏۃA�Z���u��ID
                oprtnhislogWork.LogDataObjAssemblyID = AssemblyID;
                // ���O�f�[�^�ΏۃA�Z���u������
                oprtnhislogWork.LogDataObjAssemblyNm = AssemblyNm;
                // ���O�f�[�^�ΏۃN���XID
                oprtnhislogWork.LogDataObjClassID = ClassID;
                // ���O�f�[�^�Ώۏ�����
                oprtnhislogWork.LogDataObjProcNm = ProcNm;
                // ���O�f�[�^�ΏۋN���v���O��������
                oprtnhislogWork.LogDataObjBootProgramNm = BootProgramNm;
                // ���O�f�[�^�I�y���[�V�����R�[�h
                oprtnhislogWork.LogDataOperationCd = 3;
                // ���O�f�[�^���b�Z�[�W
                oprtnhislogWork.LogDataMassage = string.Format(Message, slipNo, makerName, goodsName);
                // ���O�f�[�^�쐬����
                oprtnhislogWork.LogDataCreateDateTime = DateTime.Now;
                LogTextData logTextData = new LogTextData("", "", 0, new Exception());
                // ���O�f�[�^�[����
                oprtnhislogWork.LogDataMachineName = logTextData.ClientAuthInfoWork.MachineUserId;
                // ���O�f�[�^�S���҃R�[�h
                oprtnhislogWork.LogDataAgentCd = logTextData.EmployeeAuthInfoWork.EmployeeWork.EmployeeCode;
                // ���O�f�[�^�S���Җ�(�S���҃R�[�h)
                oprtnhislogWork.LogDataAgentNm = logTextData.EmployeeAuthInfoWork.EmployeeWork.EmployeeCode;
                // ���O�C�����_�R�[�h
                oprtnhislogWork.LoginSectionCd = logTextData.EmployeeAuthInfoWork.EmployeeWork.BelongSectionCode;
                // ���O�f�[�^�V�X�e���o�[�W����
                oprtnhislogWork.LogDataSystemVersion = this.GetType().Assembly.GetName().Version.ToString();
                // ���O�f�[�^�I�y���[�^�[�f�[�^�������x��
                oprtnhislogWork.LogOperaterDtProcLvl = "0";
                // ���O�f�[�^�I�y���[�^�[�@�\�������x��
                oprtnhislogWork.LogOperaterFuncLvl = "0";
                // ���O�f�[�^��ʋ敪�R�[�h
                oprtnhislogWork.LogDataKindCd = 9;
                // ���O�I�y���[�V�����X�e�[�^�X
                oprtnhislogWork.LogOperationStatus = 0;
                //���O�f�[�^GUID
                Guid guidValue = Guid.NewGuid();
                oprtnhislogWork.LogDataGuid = guidValue;
                writeList.Add(oprtnhislogWork);
                # endregion

                // ���엚�����O�f�[�^�����[�g
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                // ���엚�����O�f�[�^�o�^�������s��
                oprtnHisLogDB.WriteOprtnHisLogProc(ref writeList, ref sqlConnection, ref sqlTransaction);
            }
            catch(Exception ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex.Message);
            }
        }
        #endregion
        //----- ADD 2019/08/20 ���O PMKOBETSU-647 �����d����M�����G���[�Ή� ----------<<<<<
    }
}
