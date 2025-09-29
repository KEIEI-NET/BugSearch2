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
using Broadleaf.Library.Globarization;
// --- ADD 2021/04/08 �^�C���A�E�g�ݒ�ǉ� ------>>>>>
using Broadleaf.Application.Common;
// --- ADD 2021/04/08 �^�C���A�E�g�ݒ�ǉ� ------<<<<<
// --- ADD 2021/06/10 杍^ PMKOBETSU-4144 ----->>>>>
using System.IO;
using Microsoft.Win32;
using System.Threading;
// --- ADD 2021/06/10 杍^ PMKOBETSU-4144 -----<<<<<

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����c�Ɖ�DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����c�Ɖ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.10.15</br>
    /// <br>Update Note: ���N�n��</br>
    /// <br>Date       : 2011/03/22</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// <br>Update Note: �\�[�g����ǉ�</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2018/7/31</br>
    /// <br>Update Note: 2021/04/08 ���X�ؘj</br>
    /// <br>�Ǘ��ԍ�   : 11770032-00</br>
    /// <br>             �^�C���A�E�g�ݒ�ǉ�</br>
    /// <br>Update Note: 2021/06/10 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11770032-00</br>
    /// <br>             PMKOBETSU-4144 �f�b�h���b�N�Ή�</br>
    /// </remarks>
    [Serializable]
    public class OrderListWorkDB : RemoteDB, IOrderListWorkDB
    {
        // --- ADD 2021/06/10 杍^ PMKOBETSU-4144 ----->>>>>
        // ���g���C��-�f�t�H���g�F5��
        private const int RETRY_COUNT_DEFAULT = 5;
        // ���g���C�Ԋu-�f�t�H���g�F60�b
        private const int RETRY_INTERVAL_DEFAULT = 60;
        // ���O�o��PGID
        private const string CURRENT_PGID = "DCHAT02115R";
        // �G���[���b�Z�[�W
        private const string ERR_MEG = "SearchOrderProcRetry�f�b�h���b�N���� ���g���C�񐔁F{0}���";
        // �f�b�h���b�N1205
        private const int DEAD_LOCK_VALUE = 1205;
        // �萔(0)
        private const int ZERO_VALUE = 0;
        // --- ADD 2021/06/10 杍^ PMKOBETSU-4144 -----<<<<<

        /// <summary>
        /// �����c�Ɖ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public OrderListWorkDB()
            :
        base("DCHAT02113D", "Broadleaf.Application.Remoting.ParamData.OrderListResultWork", "STOCKDETAILRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region �����c�Ɖ�
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔����c�Ɖ�LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="orderListResultWork">��������</param>
        /// <param name="orderListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔����c�Ɖ�LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.10.15</br>
        public int Search(out object orderListResultWork, object orderListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            orderListResultWork = null;

            OrderListCndtnWork _orderListCndtnWork = orderListCndtnWork as OrderListCndtnWork;

            try
            {
                status = SearchProc(out orderListResultWork, _orderListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OrderListWorkDB.Search Exception=" + ex.Message);
                orderListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔����c�Ɖ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="orderListResultWork">��������</param>
        /// <param name="_orderListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔����c�Ɖ�LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.10.15</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: ���N�n��</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        /// <br>Update Note: 2021/06/10 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 �f�b�h���b�N�Ή�</br>
        private int SearchProc(out object orderListResultWork, OrderListCndtnWork _orderListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            orderListResultWork = null;

            ArrayList al = new ArrayList();   //���o����

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // --- ADD 2011/03/22----------------------------------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((OrderListCndtnWork)_orderListCndtnWork).EnterpriseCode, "�����c�Ɖ�", "���o�J�n");
                // --- ADD 2011/03/22-----------------------------------<<<<<

                // --- UPD 2021/06/10 杍^ PMKOBETSU-4144 ----->>>>>
                //status = SearchOrderProc(ref al, ref sqlConnection, _orderListCndtnWork, logicalMode);
                // ���g���C��
                int retryCnt = ZERO_VALUE;
                // ���O�o�̓N���X
                OutLogCommon outLogCommonObj = new OutLogCommon();
                // ���g���C�ݒ胏�[�N
                RetrySet retrySettingInfo = new RetrySet();
                // ���g���C�ݒ�擾
                RetryXmlGetCommon retryCommon = new RetryXmlGetCommon();
                retryCommon.GetXmlInfo(CURRENT_PGID, RETRY_COUNT_DEFAULT, RETRY_INTERVAL_DEFAULT, ref retrySettingInfo);

                status = SearchOrderProcRetry(ref al, ref sqlConnection, _orderListCndtnWork, logicalMode, ref retryCnt, outLogCommonObj, retrySettingInfo);
                // --- UPD 2021/06/10 杍^ PMKOBETSU-4144 -----<<<<<

                // --- ADD 2011/03/22----------------------------------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((OrderListCndtnWork)_orderListCndtnWork).EnterpriseCode, "�����c�Ɖ�", "���o�I��");
                // --- ADD 2011/03/22-----------------------------------<<<<<
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OrderListWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            orderListResultWork = al;

            return status;
        }

        // --- ADD 2021/06/10 杍^ PMKOBETSU-4144 ----->>>>>
        /// <summary>
        /// �݌Ƀf�[�^�擾����
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="retryCnt">���g���C��</param>
        /// <param name="outLogCommonObj">���O�o�̓N���X</param>
        /// <param name="retrySettingInfo">���g���C�ݒ胏�[�N</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2021/06/10 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 �f�b�h���b�N�Ή�</br>
        private int SearchOrderProcRetry(ref ArrayList al, ref SqlConnection sqlConnection, OrderListCndtnWork _orderListCndtnWork, ConstantManagement.LogicalMode logicalMode, ref int retryCnt, OutLogCommon outLogCommonObj, RetrySet retrySettingInfo)
        {
            // ���g���C��
            retryCnt++;
            // �������ʏ�����
            al = new ArrayList();

            // �X�e�[�^�X
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // �]�ƈ��擾���ʕ��i
            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();

            status = SearchOrderProc(ref al, ref sqlConnection, _orderListCndtnWork, logicalMode);

            if (status == DEAD_LOCK_VALUE)
            {
                //���O�o��
                outLogCommonObj.OutputServerLog(CURRENT_PGID, string.Format(ERR_MEG, retryCnt.ToString()), serverLoginInfoAcquisition.EnterpriseCode, serverLoginInfoAcquisition.EmployeeCode, null);
                // ���g���C�񐔂܂�
                if (retryCnt >= retrySettingInfo.RetryCount)
                {
                    //����STATUS�l�𕜌�
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                else
                {
                    Thread.Sleep(retrySettingInfo.RetryInterval * 1000);
                    // ���g���C�������s��
                    status = this.SearchOrderProcRetry(ref al, ref sqlConnection, _orderListCndtnWork, logicalMode, ref retryCnt, outLogCommonObj, retrySettingInfo);
                }
            }

            return status;
        }
        // --- ADD 2021/06/10 杍^ PMKOBETSU-4144 -----<<<<<

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: �\�[�g����ǉ�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2018/7/31</br>
        /// <br>Update Note: 2021/04/08 ���X�ؘj</br>
        /// <br>             �^�C���A�E�g�ݒ�ǉ�</br> 
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, OrderListCndtnWork _orderListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select���쐬
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STS.DEBITNOTEDIVRF" + Environment.NewLine;
                selectTxt += "  ,STS.SUPPLIERSLIPCDRF" + Environment.NewLine;
                selectTxt += "  ,STS.PARTYSALESLIPNUMRF" + Environment.NewLine;
                selectTxt += "  ,STS.INPUTDAYRF" + Environment.NewLine;
                selectTxt += "  ,STD.ACCEPTANORDERNORF" + Environment.NewLine;
                selectTxt += "  ,STD.SUPPLIERFORMALRF" + Environment.NewLine;
                selectTxt += "  ,STD.SUPPLIERSLIPNORF" + Environment.NewLine;
                selectTxt += "  ,STD.STOCKROWNORF" + Environment.NewLine;
                selectTxt += "  ,STD.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,STD.STOCKAGENTCODERF" + Environment.NewLine;
                selectTxt += "  ,STD.STOCKAGENTNAMERF" + Environment.NewLine;
                selectTxt += "  ,STD.STOCKINPUTCODERF" + Environment.NewLine;
                selectTxt += "  ,STD.STOCKINPUTNAMERF" + Environment.NewLine;
                selectTxt += "  ,STD.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STD.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,STD.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STD.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,STD.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  ,STD.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,STD.BLGOODSFULLNAMERF" + Environment.NewLine;
                selectTxt += "  ,STD.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,STD.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,STD.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STD.STOCKORDERDIVCDRF" + Environment.NewLine;
                selectTxt += "  ,STD.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                selectTxt += "  ,STD.LISTPRICETAXINCFLRF" + Environment.NewLine;
                selectTxt += "  ,STD.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STD.STOCKUNITTAXPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STD.STOCKPRICECONSTAXRF" + Environment.NewLine;
                selectTxt += "  ,STD.STOCKCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STD.STOCKPRICETAXEXCRF" + Environment.NewLine;
                selectTxt += "  ,STD.STOCKPRICETAXINCRF" + Environment.NewLine;
                selectTxt += "  ,STD.STOCKDTISLIPNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STD.SALESCUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,STD.SALESCUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "  ,STD.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,STD.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,STD.ADDRESSEECODERF" + Environment.NewLine;
                selectTxt += "  ,STD.ADDRESSEENAMERF" + Environment.NewLine;
                selectTxt += "  ,STD.REMAINCNTUPDDATERF" + Environment.NewLine;
                selectTxt += "  ,STD.DIRECTSENDINGCDRF" + Environment.NewLine;
                selectTxt += "  ,STD.ORDERNUMBERRF" + Environment.NewLine;
                selectTxt += "  ,STD.WAYTOORDERRF" + Environment.NewLine;
                selectTxt += "  ,STD.DELIGDSCMPLTDUEDATERF" + Environment.NewLine;
                selectTxt += "  ,STD.EXPECTDELIVERYDATERF" + Environment.NewLine;
                selectTxt += "  ,STD.ORDERCNTRF" + Environment.NewLine;
                selectTxt += "  ,STD.ORDERADJUSTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STD.ORDERREMAINCNTRF" + Environment.NewLine;
                selectTxt += "  ,STD.ORDERFORMISSUEDDIVRF" + Environment.NewLine;
                selectTxt += "  ,STD.ORDERDATACREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STD.SLIPMEMO1RF" + Environment.NewLine;
                selectTxt += "  ,STD.SLIPMEMO2RF" + Environment.NewLine;
                selectTxt += "  ,STD.SLIPMEMO3RF" + Environment.NewLine;
                selectTxt += "  ,STD.INSIDEMEMO1RF" + Environment.NewLine;
                selectTxt += "  ,STD.INSIDEMEMO2RF" + Environment.NewLine;
                selectTxt += "  ,STD.INSIDEMEMO3RF" + Environment.NewLine;
                selectTxt += "  ,STD.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                selectTxt += "  ,STS.SUPPCTAXLAYCDRF" + Environment.NewLine;
                selectTxt += "  ,STS.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
                selectTxt += "  ,STD.TAXATIONCODERF" + Environment.NewLine;
                selectTxt += "FROM STOCKDETAILRF AS STD" + Environment.NewLine;
                selectTxt += "LEFT JOIN STOCKSLIPRF AS STS" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     STS.ENTERPRISECODERF=STD.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STS.SUPPLIERFORMALRF=STD.SUPPLIERFORMALRF" + Environment.NewLine;
                selectTxt += " AND STS.SUPPLIERSLIPNORF=STD.SUPPLIERSLIPNORF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     SEC.ENTERPRISECODERF=STD.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SEC.SECTIONCODERF=STD.SECTIONCODERF" + Environment.NewLine;

                //WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, _orderListCndtnWork, logicalMode);
                
                // ADD 2018/7/31 r.sakurai --------------------------------------->>
                selectTxt += " ORDER BY" + Environment.NewLine;
                selectTxt += "  STD.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,STD.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " ,STD.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += " ,STD.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,STD.GOODSNORF ASC" + Environment.NewLine;
                // ADD 2018/7/31 r.sakurai ---------------------------------------<<

                sqlCommand.CommandText = selectTxt;

                #endregion

                // --- ADD 2021/04/08 �^�C���A�E�g�ݒ�ǉ� ------>>>>>
                // ���̃R�}���h�^�C���A�E�g�������l�ێ�
                int sqlCmdTimeout = sqlCommand.CommandTimeout;
                try
                {
                    // ���ʕ��i�R�}���h�^�C���A�E�g�ݒ�l���擾�iDCHAT02115R_DbCmdTimeout.xml�j
                    CommTimeoutConf ctc = new CommTimeoutConf();
                    sqlCmdTimeout = ctc.GetDbCommandTimeout("DCHAT02115R");
                }
                catch
                {
                    // ��O�������A���̃R�}���h�^�C���A�E�g�g�p
                    sqlCmdTimeout = sqlCommand.CommandTimeout;
                }
                finally
                {
                    // �R�}���h�^�C���A�E�g��ݒ�
                    sqlCommand.CommandTimeout = sqlCmdTimeout;
                }
                // --- ADD 2021/04/08 �^�C���A�E�g�ݒ�ǉ� ------<<<<<

                myReader = sqlCommand.ExecuteReader();  
                
                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    OrderListResultWork wkOrderListResultWork = new OrderListResultWork();
                    
                    //�i�[����
                    wkOrderListResultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    wkOrderListResultWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
                    wkOrderListResultWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                    wkOrderListResultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    wkOrderListResultWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                    wkOrderListResultWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                    wkOrderListResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    wkOrderListResultWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
                    wkOrderListResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkOrderListResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    wkOrderListResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkOrderListResultWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
                    wkOrderListResultWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
                    wkOrderListResultWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
                    wkOrderListResultWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
                    wkOrderListResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkOrderListResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkOrderListResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkOrderListResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkOrderListResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    wkOrderListResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkOrderListResultWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    wkOrderListResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkOrderListResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    wkOrderListResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkOrderListResultWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
                    wkOrderListResultWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    wkOrderListResultWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
                    wkOrderListResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    wkOrderListResultWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
                    wkOrderListResultWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
                    wkOrderListResultWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
                    wkOrderListResultWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                    wkOrderListResultWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
                    wkOrderListResultWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));
                    wkOrderListResultWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));
                    wkOrderListResultWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));
                    wkOrderListResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkOrderListResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkOrderListResultWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
                    wkOrderListResultWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
                    wkOrderListResultWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REMAINCNTUPDDATERF"));
                    wkOrderListResultWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));
                    wkOrderListResultWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
                    wkOrderListResultWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));
                    wkOrderListResultWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
                    wkOrderListResultWork.ExpectDeliveryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EXPECTDELIVERYDATERF"));
                    wkOrderListResultWork.OrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERCNTRF"));
                    wkOrderListResultWork.OrderAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERADJUSTCNTRF"));
                    wkOrderListResultWork.OrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERREMAINCNTRF"));
                    wkOrderListResultWork.OrderFormIssuedDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERFORMISSUEDDIVRF"));
                    wkOrderListResultWork.OrderDataCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ORDERDATACREATEDATERF"));
                    wkOrderListResultWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
                    wkOrderListResultWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
                    wkOrderListResultWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
                    wkOrderListResultWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
                    wkOrderListResultWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
                    wkOrderListResultWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
                    wkOrderListResultWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
                    wkOrderListResultWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
                    wkOrderListResultWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
                    wkOrderListResultWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));

                    #endregion

                    al.Add(wkOrderListResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                // --- UPD 2021/06/10 杍^ PMKOBETSU-4144 ----->>>>>
                //status = base.WriteSQLErrorLog(ex);
                //�f�b�h���b�N�̏ꍇ�A�f�b�h���b�N�l��status�ɃZ�b�g�A��̃��g���C�����ɗ��p
                if (ex.Number == DEAD_LOCK_VALUE)
                {
                    status = DEAD_LOCK_VALUE;
                }
                //�f�b�h���b�N�ȊO�̏ꍇ�A���̂܂�
                else
                {
                    status = base.WriteSQLErrorLog(ex);
                }
                // --- UPD 2021/06/10 杍^ PMKOBETSU-4144 -----<<<<<
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OrderListWorkDB.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, OrderListCndtnWork _orderListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " STD.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_orderListCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STD.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine; 
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STD.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }
            
            //�󒍃X�e�[�^�X(2:����)
            retstring += " AND STD.SUPPLIERFORMALRF=2" + Environment.NewLine;


            //�������@�A��I�����C�����̂�
            if (_orderListCndtnWork.SearchDiv == 1)
            {
                retstring += " AND STD.WAYTOORDERRF=0" + Environment.NewLine;
            }

            //���_�R�[�h
            if (_orderListCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _orderListCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND STD.SECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //�����f�[�^�쐬���ݒ�
            if (_orderListCndtnWork.St_OrderDataCreateDate != DateTime.MinValue)
            {
                retstring += " AND STD.ORDERDATACREATEDATERF>=@STORDERDATACREATEDATE" + Environment.NewLine;
                SqlParameter paraStOrderDataCreateDate = sqlCommand.Parameters.Add("@STORDERDATACREATEDATE", SqlDbType.Int);
                paraStOrderDataCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_orderListCndtnWork.St_OrderDataCreateDate);
            }
            if (_orderListCndtnWork.Ed_OrderDataCreateDate != DateTime.MinValue)
            {
                retstring += " AND STD.ORDERDATACREATEDATERF<=@EDORDERDATACREATEDATE" + Environment.NewLine;
                SqlParameter paraEdOrderDataCreateDate = sqlCommand.Parameters.Add("@EDORDERDATACREATEDATE", SqlDbType.Int);
                paraEdOrderDataCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_orderListCndtnWork.Ed_OrderDataCreateDate);
            }

            //���͓��ݒ�
            if (_orderListCndtnWork.St_InputDay != DateTime.MinValue)
            {
                retstring += " AND STS.INPUTDAYRF>=@STINPUTDAY" + Environment.NewLine;
                SqlParameter paraStInputDay = sqlCommand.Parameters.Add("@STINPUTDAY", SqlDbType.Int);
                paraStInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_orderListCndtnWork.St_InputDay);
            }
            if (_orderListCndtnWork.Ed_InputDay != DateTime.MinValue)
            {
                retstring += " AND STS.INPUTDAYRF<=@EDINPUTDAY" + Environment.NewLine;
                SqlParameter paraEdInputDay = sqlCommand.Parameters.Add("@EDINPUTDAY", SqlDbType.Int);
                paraEdInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_orderListCndtnWork.Ed_InputDay);
            }

            //�v��c�敪
            if (_orderListCndtnWork.AddUpRemDiv == 1)
            {
                //�c����
                retstring += " AND STD.ORDERREMAINCNTRF>0" + Environment.NewLine;
            }
            else
            if (_orderListCndtnWork.AddUpRemDiv == 2)
            {
                //�v��ς�
                retstring += " AND (STD.ORDERREMAINCNTRF<=0 AND STD.STOCKCOUNTRF>0)" + Environment.NewLine;

            }

            //�d���S���҃R�[�h�ݒ�
            if (string.IsNullOrEmpty(_orderListCndtnWork.StockAgentCode) == false)
            {
                retstring += " AND STD.STOCKAGENTCODERF=@STOCKAGENTCODE" + Environment.NewLine;
                SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);
                paraStockAgentCode.Value = SqlDataMediator.SqlSetString(_orderListCndtnWork.StockAgentCode);
            }

            //�d�����͎҃R�[�h�ݒ�
            if (string.IsNullOrEmpty(_orderListCndtnWork.StockInputCode) == false)
            {
                retstring += " AND STD.STOCKINPUTCODERF=@STOCKINPUTCODE" + Environment.NewLine;
                SqlParameter paraStockInputCode = sqlCommand.Parameters.Add("@STOCKINPUTCODE", SqlDbType.NChar);
                paraStockInputCode.Value = SqlDataMediator.SqlSetString(_orderListCndtnWork.StockInputCode);
            }

            //�d����R�[�h�ݒ�
            if (_orderListCndtnWork.SupplierCd != 0)
            {
                retstring += " AND STD.SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(_orderListCndtnWork.SupplierCd);
            }

            //�q�ɃR�[�h�ݒ�
            if (string.IsNullOrEmpty(_orderListCndtnWork.WarehouseCode) == false)
            {
                retstring += " AND STD.WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(_orderListCndtnWork.WarehouseCode);
            }

            //���[�J�[�R�[�h�ݒ�
            if (_orderListCndtnWork.GoodsMakerCd != 0)
            {
                retstring += " AND STD.GOODSMAKERCDRF>=@GOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_orderListCndtnWork.GoodsMakerCd);
            }

            //�����ԍ�
            if (_orderListCndtnWork.OrderNumber != "")
            {
                retstring += " AND STD.ORDERNUMBERRF=@ORDERNUMBER" + Environment.NewLine;
                SqlParameter paraOrderNumber = sqlCommand.Parameters.Add("@ORDERNUMBER", SqlDbType.NVarChar);
                paraOrderNumber.Value = SqlDataMediator.SqlSetString(_orderListCndtnWork.OrderNumber);
            }

            //�i��
            if (string.IsNullOrEmpty(_orderListCndtnWork.GoodsNo) == false)
            {
                retstring += "AND STD.GOODSNORF LIKE @GOODSNO" + Environment.NewLine;
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                //�O����v�����̏ꍇ
                if (_orderListCndtnWork.GoodsNoSrchTyp == 1) _orderListCndtnWork.GoodsNo = _orderListCndtnWork.GoodsNo + "%";
                //�����v�����̏ꍇ
                if (_orderListCndtnWork.GoodsNoSrchTyp == 2) _orderListCndtnWork.GoodsNo = "%" + _orderListCndtnWork.GoodsNo;
                //�B�������̏ꍇ
                if (_orderListCndtnWork.GoodsNoSrchTyp == 3) _orderListCndtnWork.GoodsNo = "%" + _orderListCndtnWork.GoodsNo + "%";

                paraGoodsNo.Value = SqlDataMediator.SqlSetString(_orderListCndtnWork.GoodsNo);
            }

            //���i����
            if (string.IsNullOrEmpty(_orderListCndtnWork.GoodsName) == false)
            {
                retstring += "AND STD.GOODSNAMERF LIKE @GOODSNAME" + Environment.NewLine;
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                //�O����v�����̏ꍇ
                if (_orderListCndtnWork.GoodsNameSrchTyp == 1) _orderListCndtnWork.GoodsName = _orderListCndtnWork.GoodsName + "%";
                //�����v�����̏ꍇ
                if (_orderListCndtnWork.GoodsNameSrchTyp == 2) _orderListCndtnWork.GoodsName = "%" + _orderListCndtnWork.GoodsName;
                //�B�������̏ꍇ
                if (_orderListCndtnWork.GoodsNameSrchTyp == 3) _orderListCndtnWork.GoodsName = "%" + _orderListCndtnWork.GoodsName + "%";

                paraGoodsName.Value = SqlDataMediator.SqlSetString(_orderListCndtnWork.GoodsName);
            }
            #endregion
            return retstring;
        }
    }
}
