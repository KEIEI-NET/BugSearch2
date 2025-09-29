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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ挳������f�[�^���oDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ挳������f�[�^���o�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22035 �O�� �O��</br>
    /// <br>Date       : 2007.05.08</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>           : 2007.12.03 ���ʊ�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>           : 2008.03.13 ���|���[�h�̍ۂɏ���Œ����E�c���������߂��悤�C��</br>
    /// <br></br>
    /// <br>Update Note: 2014/02/20 �{�{ ����</br>
    /// <br>           : �d�|�ꗗ ��2294�Ή�</br>
    /// <br>           : ���㗚���f�[�^�������̃^�C���A�E�g�ݒ��ǉ�(3600�b)</br>
    /// <br>UpdateNote : 2015/09/21 �c�v�t</br>
    /// <br>�Ǘ��ԍ�   : 11170168-00</br>
    /// <br>           : Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�</br>
    /// </remarks>
    [Serializable]
    public class LedgerSalesSlipWorkDB : RemoteDB
    {
        /// <summary>
        /// ���Ӑ挳������f�[�^���oDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        /// </remarks>
        public LedgerSalesSlipWorkDB()
            :
        base("MAHNB04211D", "Broadleaf.Application.Remoting.ParamData.LedgerSalesSlipWork", "SALESHISTORYRF") //���N���X�̃R���X�g���N�^
        {
        }

        private enum PrintMode
        {
            Slip = 0,
            Dtl = 1
        }

        #region ����擾����

        #region ���C��
        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ挳������f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="ledgerSalesSlipWork">�������ʁi����j</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startCustomerCode">���Ӑ�R�[�h(�J�n)</param>
        /// <param name="endCustomerCode">���Ӑ�R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="goodsCdMode">���i�敪 1:����</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓��Ӑ挳������f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        public int SearchSlip(out object ledgerSalesSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startCustomerCode, int endCustomerCode, int startAddUpDate, int endAddUpDate, int goodsCdMode, ref SqlConnection sqlConnection)
        {
            return Search(out ledgerSalesSlipWork, enterpriseCode, addUpSecCodeList, startCustomerCode, endCustomerCode, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, (int)PrintMode.Slip);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ挳������f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="ledgerSalesSlipWork">�������ʁi����j</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startCustomerCode">���Ӑ�R�[�h(�J�n)</param>
        /// <param name="endCustomerCode">���Ӑ�R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="goodsCdMode">���i�敪 1:����</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓��Ӑ挳������f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        public int SearchDtl(out object ledgerSalesSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startCustomerCode, int endCustomerCode, int startAddUpDate, int endAddUpDate, int goodsCdMode, ref SqlConnection sqlConnection)
        {
            return Search(out ledgerSalesSlipWork, enterpriseCode, addUpSecCodeList, startCustomerCode, endCustomerCode, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, (int)PrintMode.Dtl);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ挳������f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="ledgerSalesSlipWork">�������ʁi����j</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startCustomerCode">���Ӑ�R�[�h(�J�n)</param>
        /// <param name="endCustomerCode">���Ӑ�R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="goodsCdMode">���i�敪 1:����</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <param name="printMode">����^�C�v</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓��Ӑ挳������f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        private int Search(out object ledgerSalesSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startCustomerCode, int endCustomerCode, int startAddUpDate, int endAddUpDate, int goodsCdMode, ref SqlConnection sqlConnection, int printMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ledgerSalesSlipWork = null;

            try
            {
                if (printMode == (int)PrintMode.Slip)
                {
                    status = SearchSlipProc(out ledgerSalesSlipWork, enterpriseCode, addUpSecCodeList, startCustomerCode, endCustomerCode, startAddUpDate, endAddUpDate, goodsCdMode ,ref sqlConnection);
                }
                else
                if (printMode == (int)PrintMode.Dtl)
                {
                    status = SearchDtlProc(out ledgerSalesSlipWork, enterpriseCode, addUpSecCodeList, startCustomerCode, endCustomerCode, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "LedgerSalesSlipWorkDB.Search Exception=" + ex.Message);
                ledgerSalesSlipWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        #endregion

        #region �`�[�^�C�v

        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ挳������f�[�^���oLIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="ledgerSalesSlipWork">�������ʁi����j</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startCustomerCode">���Ӑ�R�[�h(�J�n)</param>
        /// <param name="endCustomerCode">���Ӑ�R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="goodsCdMode">���i�敪 1:����</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓��Ӑ挳������f�[�^���oLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        private int SearchSlipProc(out object ledgerSalesSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startCustomerCode, int endCustomerCode, int startAddUpDate, int endAddUpDate, int goodsCdMode ,ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ledgerSalesSlipWork = null;
            ArrayList al = new ArrayList();   //���o����

            string cmdText = string.Empty;

            try
            {
                #region SQL��(����) where���ȍ~�͕ʓr
                cmdText += "SELECT" + Environment.NewLine;
                cmdText += "   SLIP.ENTERPRISECODERF" + Environment.NewLine;
                cmdText += "  ,SLIP.ACPTANODRSTATUSRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESSLIPNUMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SECTIONCODERF" + Environment.NewLine;
                cmdText += "  ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine;
                cmdText += "  ,SLIP.DEBITNLNKSALESSLNUMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESSLIPCDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESGOODSCDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESINPSECCDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.DEMANDADDUPSECCDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.RESULTSADDUPSECCDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.UPDATESECCDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SEARCHSLIPDATERF" + Environment.NewLine;
                cmdText += "  ,SLIP.SHIPMENTDAYRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESDATERF" + Environment.NewLine;
                cmdText += "  ,SLIP.ADDUPADATERF" + Environment.NewLine;
                cmdText += "  ,SLIP.INPUTAGENCDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.INPUTAGENNMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESINPUTCODERF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESINPUTNAMERF" + Environment.NewLine;
                cmdText += "  ,SLIP.FRONTEMPLOYEECDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.FRONTEMPLOYEENMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESEMPLOYEECDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESEMPLOYEENMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESSUBTOTALTAXINCRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESSUBTOTALTAXEXCRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESSUBTOTALTAXRF" + Environment.NewLine;
                cmdText += "  ,SLIP.CLAIMCODERF" + Environment.NewLine;
                cmdText += "  ,SLIP.CLAIMSNMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.CUSTOMERCODERF" + Environment.NewLine;
                cmdText += "  ,SLIP.CUSTOMERNAMERF" + Environment.NewLine;
                cmdText += "  ,SLIP.CUSTOMERNAME2RF" + Environment.NewLine;
                cmdText += "  ,SLIP.CUSTOMERSNMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.HONORIFICTITLERF" + Environment.NewLine;
                cmdText += "  ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SLIPNOTERF" + Environment.NewLine;
                cmdText += "  ,SLIP.SLIPNOTE2RF" + Environment.NewLine;
                cmdText += "  ,SLIP.SLIPNOTE3RF" + Environment.NewLine;
                cmdText += "  ,SLIP.UOEREMARK1RF" + Environment.NewLine;
                cmdText += "  ,SLIP.UOEREMARK2RF" + Environment.NewLine;
                cmdText += "  ,SLIP.ACCRECDIVCDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.CONSTAXLAYMETHODRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESTOTALTAXEXCRF" + Environment.NewLine;
                // --- UPD 2014/02/20 T.Miyamoto ------------------------------>>>>>
                //cmdText += "FROM SALESHISTORYRF AS SLIP" + Environment.NewLine;
                cmdText += "FROM SALESHISTORYRF AS SLIP WITH (READUNCOMMITTED) " + Environment.NewLine;
                // --- UPD 2014/02/20 T.Miyamoto ------------------------------<<<<<
                #endregion
                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
                {
                    // Where���̍쐬
                    bool result = this.MakeWhereString(sqlCommand, enterpriseCode, addUpSecCodeList, startCustomerCode, endCustomerCode, startAddUpDate, endAddUpDate, goodsCdMode);
                    if (!result) return status;

                    // --- ADD 2014/02/20 T.Miyamoto ------------------------------>>>>>
                    //�^�C���A�E�g���Ԃ�ݒ�i�b�j
                    sqlCommand.CommandTimeout = 3600;
                    // --- ADD 2014/02/20 T.Miyamoto ------------------------------<<<<<

                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        try
                        {
                            //���Ӑ挳������f�[�^���X�g�i�[����
                            this.SetListFromSQLReader(ref status, ref al, myReader, (int)PrintMode.Slip);
                        }
                        finally
                        {
                            if (myReader != null) myReader.Close();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "LedgerSalesSlipWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            ledgerSalesSlipWork = al;

            return status;
        }

        /// <summary>
        /// SQL�f�[�^���[�_�[�����Ӑ挳������f�[�^���[�N
        /// </summary>
        /// <param name="_ledgerSalesSlipWork">���Ӑ挳������f�[�^���[�N</param>
        /// <param name="myReader">SQL�f�[�^���[�_�[</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SQL�f�[�^���[�_�[�ɕێ����Ă�����e�𓾈Ӑ挳������f�[�^���[�N�ɃR�s�[���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>		
        private void CopyToDataClassFromSelectData(ref LedgerSalesSlipWork _ledgerSalesSlipWork, SqlDataReader myReader)
        {
            #region ���Ӑ挳������f�[�^���[�N�֊i�[
            _ledgerSalesSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            _ledgerSalesSlipWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            _ledgerSalesSlipWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            _ledgerSalesSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            _ledgerSalesSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            _ledgerSalesSlipWork.DebitNLnkSalesSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEBITNLNKSALESSLNUMRF"));
            _ledgerSalesSlipWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
            _ledgerSalesSlipWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
            _ledgerSalesSlipWork.SalesInpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPSECCDRF"));
            _ledgerSalesSlipWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
            _ledgerSalesSlipWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
            _ledgerSalesSlipWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
            _ledgerSalesSlipWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
            _ledgerSalesSlipWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
            _ledgerSalesSlipWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            _ledgerSalesSlipWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            _ledgerSalesSlipWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
            _ledgerSalesSlipWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
            _ledgerSalesSlipWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
            _ledgerSalesSlipWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
            _ledgerSalesSlipWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
            _ledgerSalesSlipWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
            _ledgerSalesSlipWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
            _ledgerSalesSlipWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
            _ledgerSalesSlipWork.SalesSubtotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));
            _ledgerSalesSlipWork.SalesSubtotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));
            _ledgerSalesSlipWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
            _ledgerSalesSlipWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            _ledgerSalesSlipWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            _ledgerSalesSlipWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            _ledgerSalesSlipWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            _ledgerSalesSlipWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            _ledgerSalesSlipWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            _ledgerSalesSlipWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
            _ledgerSalesSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            _ledgerSalesSlipWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
            _ledgerSalesSlipWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
            _ledgerSalesSlipWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
            _ledgerSalesSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            _ledgerSalesSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            _ledgerSalesSlipWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
            _ledgerSalesSlipWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            _ledgerSalesSlipWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
            #endregion
        }
        #endregion

        #region ���׃^�C�v
        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ挳������f�[�^���oLIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="ledgerSalesSlipWork">��������(����)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startCustomerCode">���Ӑ�R�[�h(�J�n)</param>
        /// <param name="endCustomerCode">���Ӑ�R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="goodsCdMode">���i�敪 1:����</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓��Ӑ挳������f�[�^���oLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.03</br>
        private int SearchDtlProc(out object ledgerSalesSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startCustomerCode, int endCustomerCode, int startAddUpDate, int endAddUpDate, int goodsCdMode ,ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ledgerSalesSlipWork = null;
            ArrayList al = new ArrayList();     //���o����(����)

            string cmdText = string.Empty;

            try
            {
                #region SQL��(����{���㖾��) where���ȍ~�͕ʓr
                cmdText += "SELECT" + Environment.NewLine;
                cmdText += "   SLIP.ENTERPRISECODERF" + Environment.NewLine;
                cmdText += "  ,SLIP.ACPTANODRSTATUSRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESSLIPNUMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SECTIONCODERF" + Environment.NewLine;
                cmdText += "  ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine;
                cmdText += "  ,SLIP.DEBITNLNKSALESSLNUMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESSLIPCDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESGOODSCDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESINPSECCDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.DEMANDADDUPSECCDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.RESULTSADDUPSECCDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.UPDATESECCDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SEARCHSLIPDATERF" + Environment.NewLine;
                cmdText += "  ,SLIP.SHIPMENTDAYRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESDATERF" + Environment.NewLine;
                cmdText += "  ,SLIP.ADDUPADATERF" + Environment.NewLine;
                cmdText += "  ,SLIP.INPUTAGENCDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.INPUTAGENNMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESINPUTCODERF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESINPUTNAMERF" + Environment.NewLine;
                cmdText += "  ,SLIP.FRONTEMPLOYEECDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.FRONTEMPLOYEENMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESEMPLOYEECDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESEMPLOYEENMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESSUBTOTALTAXINCRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESSUBTOTALTAXEXCRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESSUBTOTALTAXRF" + Environment.NewLine;
                cmdText += "  ,SLIP.CLAIMCODERF" + Environment.NewLine;
                cmdText += "  ,SLIP.CLAIMSNMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.CUSTOMERCODERF" + Environment.NewLine;
                cmdText += "  ,SLIP.CUSTOMERNAMERF" + Environment.NewLine;
                cmdText += "  ,SLIP.CUSTOMERNAME2RF" + Environment.NewLine;
                cmdText += "  ,SLIP.CUSTOMERSNMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.HONORIFICTITLERF" + Environment.NewLine;
                cmdText += "  ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SLIPNOTERF" + Environment.NewLine;
                cmdText += "  ,SLIP.SLIPNOTE2RF" + Environment.NewLine;
                cmdText += "  ,SLIP.SLIPNOTE3RF" + Environment.NewLine;
                cmdText += "  ,SLIP.UOEREMARK1RF" + Environment.NewLine;
                cmdText += "  ,SLIP.UOEREMARK2RF" + Environment.NewLine;
                cmdText += "  ,SLIP.ACCRECDIVCDRF" + Environment.NewLine;
                cmdText += "  ,DETAIL.SALESROWNORF" + Environment.NewLine;
                cmdText += "  ,DETAIL.SALESROWDERIVNORF" + Environment.NewLine;
                cmdText += "  ,DETAIL.COMMONSEQNORF" + Environment.NewLine;
                cmdText += "  ,DETAIL.SALESSLIPDTLNUMRF" + Environment.NewLine;
                cmdText += "  ,DETAIL.GOODSNORF" + Environment.NewLine;
                cmdText += "  ,DETAIL.GOODSNAMERF" + Environment.NewLine;
                cmdText += "  ,DETAIL.GOODSNAMEKANARF" + Environment.NewLine;
                cmdText += "  ,DETAIL.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                cmdText += "  ,DETAIL.SALESMONEYTAXEXCRF" + Environment.NewLine;
                cmdText += "  ,DETAIL.SALESPRICECONSTAXRF" + Environment.NewLine;
                cmdText += "  ,DETAIL.SHIPMENTCNTRF" + Environment.NewLine;
                cmdText += "  ,DETAIL.SUPPLIERCDRF" + Environment.NewLine;
                cmdText += "  ,DETAIL.SUPPLIERSNMRF" + Environment.NewLine;
                cmdText += "  ,SLIP.CONSTAXLAYMETHODRF" + Environment.NewLine;
                cmdText += "  ,DETAIL.TAXATIONDIVCDRF" + Environment.NewLine;
                cmdText += "  ,SLIP.SALESTOTALTAXEXCRF" + Environment.NewLine;
                // --- UPD 2014/02/20 T.Miyamoto ------------------------------>>>>>
                //cmdText += "FROM SALESHISTORYRF AS SLIP" + Environment.NewLine;
                cmdText += "FROM SALESHISTORYRF AS SLIP WITH (READUNCOMMITTED) " + Environment.NewLine;
                // --- UPD 2014/02/20 T.Miyamoto ------------------------------<<<<<
                cmdText += "LEFT JOIN SALESHISTDTLRF AS DETAIL ON (SLIP.ENTERPRISECODERF=DETAIL.ENTERPRISECODERF AND SLIP.ACPTANODRSTATUSRF=DETAIL.ACPTANODRSTATUSRF AND SLIP.SALESSLIPNUMRF=DETAIL.SALESSLIPNUMRF ) ";

                #endregion
                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
                {
                    // Where���̍쐬
                    bool result = this.MakeWhereString(sqlCommand, enterpriseCode, addUpSecCodeList, startCustomerCode, endCustomerCode, startAddUpDate, endAddUpDate, goodsCdMode);
                    if (!result) return status;

                    // --- ADD 2014/02/20 T.Miyamoto ------------------------------>>>>>
                    //�^�C���A�E�g���Ԃ�ݒ�i�b�j
                    sqlCommand.CommandTimeout = 3600;
                    // --- ADD 2014/02/20 T.Miyamoto ------------------------------<<<<<

                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        try
                        {
                            //���Ӑ挳������f�[�^���X�g�i�[����
                            this.SetListFromSQLReader(ref status, ref al, myReader ,(int)PrintMode.Dtl);
                        }
                        finally
                        {
                            if (myReader != null) myReader.Close();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "LedgerSalesSlipWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            ledgerSalesSlipWork = al;

            return status;
        }

        /// <summary>
        /// SQL�f�[�^���[�_�[�����Ӑ挳������f�[�^���[�N
        /// </summary>
        /// <param name="_ledgerSalesDetailWork">���Ӑ挳������f�[�^���[�N</param>
        /// <param name="myReader">SQL�f�[�^���[�_�[</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SQL�f�[�^���[�_�[�ɕێ����Ă�����e�𓾈Ӑ挳������f�[�^���[�N(�`�[����)�ɃR�s�[���܂��B</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.03</br>
        private void CopyToDataClassFromSelectDataDetail(ref LedgerSalesDetailWork _ledgerSalesDetailWork, SqlDataReader myReader)
        {
            #region ���Ӑ挳������f�[�^���[�N�֊i�[(�`�[����)
            _ledgerSalesDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            _ledgerSalesDetailWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            _ledgerSalesDetailWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            _ledgerSalesDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            _ledgerSalesDetailWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            _ledgerSalesDetailWork.DebitNLnkSalesSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEBITNLNKSALESSLNUMRF"));
            _ledgerSalesDetailWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
            _ledgerSalesDetailWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
            _ledgerSalesDetailWork.SalesInpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPSECCDRF"));
            _ledgerSalesDetailWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
            _ledgerSalesDetailWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
            _ledgerSalesDetailWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
            _ledgerSalesDetailWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
            _ledgerSalesDetailWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
            _ledgerSalesDetailWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            _ledgerSalesDetailWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            _ledgerSalesDetailWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
            _ledgerSalesDetailWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
            _ledgerSalesDetailWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
            _ledgerSalesDetailWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
            _ledgerSalesDetailWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
            _ledgerSalesDetailWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
            _ledgerSalesDetailWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
            _ledgerSalesDetailWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
            _ledgerSalesDetailWork.SalesSubtotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));
            _ledgerSalesDetailWork.SalesSubtotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));
            _ledgerSalesDetailWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
            _ledgerSalesDetailWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            _ledgerSalesDetailWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            _ledgerSalesDetailWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            _ledgerSalesDetailWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            _ledgerSalesDetailWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            _ledgerSalesDetailWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            _ledgerSalesDetailWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
            _ledgerSalesDetailWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            _ledgerSalesDetailWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
            _ledgerSalesDetailWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
            _ledgerSalesDetailWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
            _ledgerSalesDetailWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            _ledgerSalesDetailWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            _ledgerSalesDetailWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
            _ledgerSalesDetailWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
            _ledgerSalesDetailWork.SalesRowDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWDERIVNORF"));
            _ledgerSalesDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
            _ledgerSalesDetailWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
            _ledgerSalesDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            _ledgerSalesDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            _ledgerSalesDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            _ledgerSalesDetailWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
            _ledgerSalesDetailWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
            _ledgerSalesDetailWork.SalesPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRICECONSTAXRF"));
            _ledgerSalesDetailWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            _ledgerSalesDetailWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            _ledgerSalesDetailWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            _ledgerSalesDetailWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            _ledgerSalesDetailWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            _ledgerSalesDetailWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
            #endregion
        }
        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SQLConnection</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startCustomerCode">���Ӑ�R�[�h(�J�n)</param>
        /// <param name="endCustomerCode">���Ӑ�R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="goodsCdMode">���i�敪���[�h 0:�ʏ� 1:����(4,5,10�����O) 2:���|</param>
        /// <returns>Where����������</returns>
        /// <br>UpdateNote : 2015/09/21 �c�v�t</br>
        /// <br>           : Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�</br> 
        private bool MakeWhereString(SqlCommand sqlCommand, string enterpriseCode, ArrayList addUpSecCodeList, int startCustomerCode, int endCustomerCode, 
            int startAddUpDate, int endAddUpDate, int goodsCdMode)
        {
            #region WHERE���쐬

            sqlCommand.CommandText += " WHERE";

            // ��ƃR�[�h
            sqlCommand.CommandText += " SLIP.ENTERPRISECODERF=@FINDENTERPRISECODE";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            // �_���폜�敪
            sqlCommand.CommandText += " AND SLIP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //������R�[�h
            if (startCustomerCode != 0)
            {
                sqlCommand.CommandText += " AND SLIP.CLAIMCODERF>=@STCLAIMCODE";
                SqlParameter paraStClaimCode = sqlCommand.Parameters.Add("@STCLAIMCODE", SqlDbType.Int);
                paraStClaimCode.Value = SqlDataMediator.SqlSetInt32(startCustomerCode);
            }
            if (endCustomerCode != 0)
            {
                sqlCommand.CommandText += " AND SLIP.CLAIMCODERF<=@EDCLAIMCODE";
                SqlParameter paraEdClaimCode = sqlCommand.Parameters.Add("@EDCLAIMCODE", SqlDbType.Int);
                paraEdClaimCode.Value = SqlDataMediator.SqlSetInt32(endCustomerCode);
            }

            // �v����t
            if (startAddUpDate <= endAddUpDate)
            {
                if (startAddUpDate == endAddUpDate)
                {
                    sqlCommand.CommandText +=" AND SLIP.ADDUPADATERF=@FINDADDUPADATE";
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPADATE", SqlDbType.Int);
                    paraAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
                }
                else
                {
                    sqlCommand.CommandText +=" AND SLIP.ADDUPADATERF>=@FINDSTARTADDUPADATE AND SLIP.ADDUPADATERF<=@FINDENDADDUPADATE";
                    SqlParameter paraStartAddUpDate = sqlCommand.Parameters.Add("@FINDSTARTADDUPADATE", SqlDbType.Int);
                    paraStartAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
                    SqlParameter paraEndAddUpDate = sqlCommand.Parameters.Add("@FINDENDADDUPADATE", SqlDbType.Int);
                    paraEndAddUpDate.Value = SqlDataMediator.SqlSetInt32(endAddUpDate);
                }
            }
            else
            {
                return false;
            }

            // ---------- DEL 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ---------->>>>>
            //// �����v�㋒�_
            //StringBuilder whereSectionCode = new StringBuilder();
            //if (addUpSecCodeList.Count > 0)
            //{
            //    if (addUpSecCodeList.Count == 1)
            //    {
            //        sqlCommand.CommandText += " AND SLIP.DEMANDADDUPSECCDRF='" + addUpSecCodeList[0] + "'";
            //    }
            //    else
            //    {
            //        sqlCommand.CommandText += " AND SLIP.DEMANDADDUPSECCDRF IN (";
            //        string str = "";
            //        for (int ix = 0; ix < addUpSecCodeList.Count; ix++)
            //        {
            //            if (ix != 0)
            //            {
            //                str += ",";
            //            }
            //            str += "'" + addUpSecCodeList[ix] + "'";
            //        }
            //        sqlCommand.CommandText += str + ")";
            //    }
            //}                           
            // ---------- DEL 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ----------<<<<<

            //���㏤�i�敪�̃`�F�b�N
            if (goodsCdMode == 1)
            {
                sqlCommand.CommandText += " AND SLIP.SALESGOODSCDRF!=4 AND SLIP.SALESGOODSCDRF!=5 AND SLIP.SALESGOODSCDRF!=10";
            }

            sqlCommand.CommandText += " ORDER BY SLIP.ACPTANODRSTATUSRF, SLIP.SALESSLIPNUMRF ";

            #endregion
            return true;
        }

        /// <summary>
        /// ���Ӑ挳������f�[�^���X�g�i�[����
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="al">���Ӑ挳������f�[�^���X�g</param>
        /// <param name="myReader">SQLDataReader</param>
        /// <param name="printMode">����^�C�v</param>
        /// <br>Note       : SQLDataReader�̏��𓾈Ӑ挳������f�[�^���X�g�ɃZ�b�g���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>		
        private void SetListFromSQLReader(ref int status, ref ArrayList al, SqlDataReader myReader, int printMode)
        {
            if (al == null)
            {
                al = new ArrayList();
            }

            LedgerSalesSlipWork _ledgerSalesSlipWork;
            LedgerSalesDetailWork _ledgerSalesDetailWork;

            while (myReader.Read())
            {
                _ledgerSalesSlipWork = new LedgerSalesSlipWork();
                _ledgerSalesDetailWork = new LedgerSalesDetailWork();

                //SQL�f�[�^���[�_�[�����Ӑ挳������f�[�^���[�N
                if (printMode == (int)PrintMode.Slip)
                {
                    this.CopyToDataClassFromSelectData(ref _ledgerSalesSlipWork, myReader);
                    al.Add(_ledgerSalesSlipWork);
                }
                else
                if (printMode == (int)PrintMode.Dtl)
                {
                    this.CopyToDataClassFromSelectDataDetail(ref _ledgerSalesDetailWork, myReader);
                    al.Add(_ledgerSalesDetailWork);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
        }

        #endregion
    }
}
