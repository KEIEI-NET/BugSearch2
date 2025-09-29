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
using Broadleaf.Library.Diagnostics;  //ADD 2008/04/24 M.Kubota
using System.Diagnostics;             //ADD 2008/04/24 M.Kubota

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �x��READDB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : �x��READ�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 99033 ��{�@�E</br>
	/// <br>Date       : 2005.08.16</br>
    /// <br>           : 20060904 iwa �������̋��_����͌v�㋒�_�ɕύX</br>
    /// <br></br>
    /// <br>Update Note: 18322 �ؑ� ����</br>
    /// <br>           : 20061222 �g��.NS�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>           : 2007.09.07 ���ʊ.NS�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>           : 2007.12.10 EdiTakeInDate(EDI�捞��)��Int32��DateTime�ɕύX</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>           : 2008.01.30 �p�����[�^�N���X�Ɏ����x���敪�E�d���`�[�ԍ���ǉ�</br>
    /// <br></br>
	/// </remarks>
	[Serializable]
	//public class PaymentReadDB : RemoteDB , IPaymentReadDB          //DEL 2008/04/24 M.Kubota
    public class PaymentReadDB : RemoteWithAppLockDB, IPaymentReadDB  //ADD 2008/04/24 M.Kubota
	{
		/// <summary>
		/// �x��READDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 99033 ��{�@�E</br>
		/// <br>Date       : 2005.08.16</br>
		/// </remarks>
        public PaymentReadDB()
            :
        base("SFSIR02105D", "Broadleaf.Application.Remoting.ParamData.PaymentSlpWork", "PAYMENTSLIPRF") //���N���X�̃R���X�g���N�^
        {
        }

		#region �J�X�^���V���A���C�Y

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎x��READLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="paymentMainWork">��������</param>
        /// <param name="searchParaPaymentRead">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎x��READLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 99033 ��{�@�E</br>
        /// <br>Date       : 2005.08.16</br>
        public int Search(out object paymentMainWork, object searchParaPaymentRead, int readMode, ConstantManagement.LogicalMode logicalMode)
        {		
            bool nextData;
            int retTotalCnt;
            SearchParaPaymentRead _searchParaPaymentRead = searchParaPaymentRead as SearchParaPaymentRead;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            paymentMainWork = null;
            try
            {
                status = SearchProc(out paymentMainWork, out retTotalCnt, out nextData, _searchParaPaymentRead, readMode, logicalMode, 0);
            }
            catch(Exception ex)
            {
                //base.WriteErrorLog(ex,"PaymentReadDB.Search Exception="+ex.Message);  //DEL 2008/04/24 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //--- ADD 2008/04/24 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
                //--- ADD 2008/04/24 M.Kubota ---<<<
            }
            return status;
        }


        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎x��READLIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="paymentMainWork">��������</param>
        /// <param name="retTotalCnt">�����Ώۑ�����</param>		
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="searchParaPaymentRead">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎x��READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 99033 ��{�@�E</br>
        /// <br>Date       : 2005.08.16</br>
        private int SearchProc(out object paymentMainWork, out int retTotalCnt, out bool nextData, SearchParaPaymentRead searchParaPaymentRead, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            SearchParaPaymentRead SPTA = searchParaPaymentRead;
            string enterpriseCode           = SPTA.EnterpriseCode;
            string addUpSecCode             = SPTA.AddUpSecCode;
            int supplierCd                = SPTA.SupplierCd;
            int paymentSlipNo               = SPTA.PaymentSlipNo;
            DateTime paymentCallMonthsStart = SPTA.PaymentCallMonthsStart;
            DateTime paymentCallMonthsEnd = SPTA.PaymentCallMonthsEnd;
            // �� 2008.01.30 980081 a
            Int32 autoPayment = SPTA.AutoPayment;
            Int32 supplierSlipNo = SPTA.SupplierSlipNo;
            // �� 2008.01.30 980081 a

            paymentMainWork = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            //PaymentSlpWork paymentSlpWork = new PaymentSlpWork();  //DEL 2008/04/24 M.Kubota
            //--- ADD 2008/04/24 M.Kubota --->>>
            PaymentSlpWork paymentSlpWork = null;
            PaymentDtlWork[] paymentDtlWorkArray = null;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
            //--- ADD 2008/04/24 M.Kubota ---<<<

            //��������0�ŏ�����
            retTotalCnt = 0;

            //�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
            int _readCnt = readCnt;			
            if (_readCnt > 0) _readCnt += 1;
            //�����R�[�h�����ŏ�����
            nextData = false;

            int sDate  = 0;
            int eDate  = 0;
            try
            {
                sDate = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD", paymentCallMonthsStart);
                eDate = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD", paymentCallMonthsEnd);
            }
            catch(Exception)
            {
                sDate = 0;
                eDate = 0;
            }

            ArrayList al = new ArrayList();
            ArrayList paymentWrkList = new ArrayList();  //ADD 2008/04/24 M.Kubota
            ArrayList paymentDtlList = new ArrayList();  //ADD 2008/04/24 M.Kubota

            try
            {
                # region --- DEL 2008/04/24 M.Kubota --->>>
                //try  //DEL 2008/04/24 M.Kubota
                //{
                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

                //--- �󒍔ԍ��������Ă��Ȃ��ꍇ ----------//
                //SQL������
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();

                //sqlCommand = new SqlCommand("SELECT * FROM PAYMENTSLPRF ", sqlConnection);
                # endregion --- DEL 2008/04/24 M.Kubota ---<<<

                //--- ADD 2008/04/24 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    errmsg += ": �f�[�^�x�[�X�ւ̐ڑ��Ɏ��s���܂���.";
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # region [SELECT��]
                string sqlText = string.Empty;
                if (readCnt <= 0)
                {
                    sqlText += "SELECT" + Environment.NewLine;
                }
                else
                {
                    sqlText += "SELECT TOP " + readCnt.ToString() + Environment.NewLine;
                }
                sqlText += "  PAY.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,PAY.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,PAY.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,PAY.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,PAY.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,PAY.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,PAY.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,PAY.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,PAY.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += " ,PAY.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += " ,PAY.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += " ,PAY.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " ,PAY.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += " ,PAY.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += " ,PAY.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += " ,PAY.PAYEECODERF" + Environment.NewLine;
                sqlText += " ,PAY.PAYEENAMERF" + Environment.NewLine;
                sqlText += " ,PAY.PAYEENAME2RF" + Environment.NewLine;
                sqlText += " ,PAY.PAYEESNMRF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTINPSECTIONCDRF" + Environment.NewLine;
                sqlText += " ,PAY.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += " ,PAY.UPDATESECCDRF" + Environment.NewLine;
                sqlText += " ,PAY.SUBSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTDATERF" + Environment.NewLine;
                sqlText += " ,PAY.ADDUPADATERF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTTOTALRF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTRF" + Environment.NewLine;
                sqlText += " ,PAY.FEEPAYMENTRF" + Environment.NewLine;
                sqlText += " ,PAY.DISCOUNTPAYMENTRF" + Environment.NewLine;
                sqlText += " ,PAY.AUTOPAYMENTRF" + Environment.NewLine;
                sqlText += " ,PAY.DRAFTDRAWINGDATERF" + Environment.NewLine;
                sqlText += " ,PAY.DRAFTKINDRF" + Environment.NewLine;
                sqlText += " ,PAY.DRAFTKINDNAMERF" + Environment.NewLine;
                sqlText += " ,PAY.DRAFTDIVIDERF" + Environment.NewLine;
                sqlText += " ,PAY.DRAFTDIVIDENAMERF" + Environment.NewLine;
                sqlText += " ,PAY.DRAFTNORF" + Environment.NewLine;
                sqlText += " ,PAY.DEBITNOTELINKPAYNORF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTAGENTCODERF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTAGENTNAMERF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTINPUTAGENTCDRF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTINPUTAGENTNMRF" + Environment.NewLine;
                sqlText += " ,PAY.OUTLINERF" + Environment.NewLine;
                sqlText += " ,PAY.BANKCODERF" + Environment.NewLine;
                sqlText += " ,PAY.BANKNAMERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PAYMENTSLPRF AS PAY" + Environment.NewLine;
                # endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                SqlParameter paraReadCount = sqlCommand.Parameters.Add("@READCNT", SqlDbType.Int);
                paraReadCount.Value = SqlDataMediator.SqlSetInt(readCnt);
                //--- ADD 2008/04/24 M.Kubota ---<<<

                //WHERE���̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchParaPaymentRead, logicalMode);

# if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
# endif

                //�x��Ͻ� Read
                //myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);  //DEL 2008/04/24 M.Kubota
                myReader = sqlCommand.ExecuteReader();  //ADD 2008/04/24 M.Kubota

                //int retCnt = 0;  //DEL 2008/04/24 M.Kubota

                while (myReader.Read())
                {
                    # region --- DEL 2008/04/24 M.Kubota --->>>
                    ////�߂�l�J�E���^�J�E���g
                    //retCnt += 1;
                    //if (readCnt > 0)
                    //{
                    //    //�߂�l�̌������擾�w�������𒴂����ꍇ�I��
                    //    if (readCnt < retCnt)
                    //    {
                    //        nextData = true;
                    //        break;
                    //    }
                    //}
                    # endregion --- DEL 2008/04/24 M.Kubota ---<<<

                    //�x���`�[�}�X�^
                    paymentSlpWork = new PaymentSlpWork();
                    #region �x���`�[�}�X�^�N���X�֑��
                    paymentSlpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));         // �쐬����
                    paymentSlpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));         // �X�V����
                    paymentSlpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                    // ��ƃR�[�h
                    paymentSlpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                      // GUID
                    paymentSlpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));                  // �X�V�]�ƈ��R�[�h
                    paymentSlpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                    // �X�V�A�Z���u��ID1
                    paymentSlpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                    // �X�V�A�Z���u��ID2
                    paymentSlpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));               // �_���폜�敪
                    paymentSlpWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));                         // �ԓ`�敪
                    paymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));                       // �x���`�[�ԍ�
                    paymentSlpWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));                     // �d���`��
                    paymentSlpWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));                     // �d���`�[�ԍ�
                    paymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));                             // �d����R�[�h
                    paymentSlpWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));                          // �d���於1
                    paymentSlpWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));                          // �d���於2
                    paymentSlpWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));                          // �d���旪��
                    paymentSlpWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));                               // �x����R�[�h
                    paymentSlpWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));                              // �x���於��
                    paymentSlpWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));                            // �x���於��2
                    paymentSlpWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));                                // �x���旪��
                    paymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));          // �x�����͋��_�R�[�h
                    paymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));                        // �v�㋒�_�R�[�h
                    paymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));                          // �X�V���_�R�[�h
                    paymentSlpWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));                     // ����R�[�h
                    paymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));            // �x�����t
                    paymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));              // �v����t
                    paymentSlpWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));                         // �x���v
                    paymentSlpWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));                                   // �x�����z
                    paymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));                             // �萔���x���z
                    paymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));                   // �l���x���z
                    paymentSlpWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));                           // �����x���敪
                    paymentSlpWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));  // ��`�U�o��
                    paymentSlpWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));                               // ��`���
                    paymentSlpWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));                      // ��`��ޖ���
                    paymentSlpWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));                           // ��`�敪
                    paymentSlpWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));                  // ��`�敪����
                    paymentSlpWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));                                  // ��`�ԍ�
                    paymentSlpWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));             // �ԍ��x���A���ԍ�
                    paymentSlpWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));                // �x���S���҃R�[�h
                    paymentSlpWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));                // �x���S���Җ���
                    paymentSlpWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));          // �x�����͎҃R�[�h
                    paymentSlpWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));          // �x�����͎Җ���
                    paymentSlpWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));                                  // �`�[�E�v
                    paymentSlpWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));                                 // ��s�R�[�h
                    paymentSlpWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));                                // ��s����

                    # region --- DEL 2008/04/24 M.Kubota --->>>
                    //PaymentSlpWork wkPaymentSlpWork = new PaymentSlpWork();

                    //wkPaymentSlpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    //wkPaymentSlpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    //wkPaymentSlpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    //wkPaymentSlpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    //wkPaymentSlpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    //wkPaymentSlpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    //wkPaymentSlpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    //wkPaymentSlpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                    // �� 20061222 18322 c �g��.NS�p�ɕύX
                    //wkPaymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                    //wkPaymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    //wkPaymentSlpWork.Payment   = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("PAYMENTRF"));
                    //wkPaymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                    //wkPaymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                    //wkPaymentSlpWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    //wkPaymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                    //wkPaymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                    //wkPaymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    //wkPaymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    //wkPaymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                    //wkPaymentSlpWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                    //wkPaymentSlpWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                    //wkPaymentSlpWork.PaymentMoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDCODERF"));
                    //wkPaymentSlpWork.PaymentMoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDNAMERF"));
                    //wkPaymentSlpWork.PaymentMoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDDIVRF"));
                    //wkPaymentSlpWork.PaymentDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTDIVNMRF"));
                    //wkPaymentSlpWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
                    //wkPaymentSlpWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                    //wkPaymentSlpWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));

                    //// �ԓ`�敪
                    //wkPaymentSlpWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    //// �x���`�[�ԍ�
                    //wkPaymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                    //// ���Ӑ�R�[�h
                    //wkPaymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    //// ���Ӑ於��
                    //wkPaymentSlpWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    //// ���Ӑ於��2
                    //wkPaymentSlpWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    //// �x�����͋��_�R�[�h
                    //wkPaymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                    //// �v�㋒�_�R�[�h
                    //wkPaymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    //// �X�V���_�R�[�h
                    //wkPaymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                    //// �x�����t
                    //wkPaymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                    //// �v����t
                    //wkPaymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    //// �x������R�[�h
                    //wkPaymentSlpWork.PaymentMoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDCODERF"));
                    //// �x�����햼��
                    //wkPaymentSlpWork.PaymentMoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDNAMERF"));
                    //// �x������敪
                    //wkPaymentSlpWork.PaymentMoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDDIVRF"));
                    //// �x���v
                    //wkPaymentSlpWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                    //// �x�����z
                    //wkPaymentSlpWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                    //// �萔���x���z
                    //wkPaymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                    //// �l���x���z
                    //wkPaymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                    //// ���x�[�g�x���z
                    //wkPaymentSlpWork.RebatePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REBATEPAYMENTRF"));
                    //// �����x���敪
                    //wkPaymentSlpWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                    //// �N���W�b�g�^���[���敪
                    //wkPaymentSlpWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
                    //// �N���W�b�g��ЃR�[�h
                    //wkPaymentSlpWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                    //// ��`�U�o��
                    //wkPaymentSlpWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                    //// ��`�x������
                    //wkPaymentSlpWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                    //// �ԍ��x���A���ԍ�
                    //wkPaymentSlpWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
                    //// �x���S���҃R�[�h
                    //wkPaymentSlpWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
                    //// �x���S���Җ���
                    //// �� 2007.09.07 980081 c
                    ////wkPaymentSlpWork.PaymentAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNMRF"));
                    //wkPaymentSlpWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
                    //// �� 2007.09.07 980081 c
                    //// �`�[�E�v
                    //wkPaymentSlpWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    //// �� 20061222 18322 c
                    //// �� 2007.09.07 980081 a
                    //// �� 2007.12.10 980081 d
                    ////// ���Ӑ搿����R�[�h
                    ////wkPaymentSlpWork.CustClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCLAIMCODERF"));
                    //// �� 2007.12.10 980081 d
                    //// ����R�[�h
                    //wkPaymentSlpWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    //// �ۃR�[�h
                    //wkPaymentSlpWork.MinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINSECTIONCODERF"));
                    //// ��`���
                    //wkPaymentSlpWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                    //// ��`��ޖ���
                    //wkPaymentSlpWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                    //// ��`�敪
                    //wkPaymentSlpWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                    //// ��`�敪����
                    //wkPaymentSlpWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                    //// ��`�ԍ�
                    //wkPaymentSlpWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                    //// �x�����͎҃R�[�h
                    //wkPaymentSlpWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
                    //// �x�����͎Җ���
                    //wkPaymentSlpWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
                    //// ��s�R�[�h
                    //wkPaymentSlpWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                    //// ��s����
                    //wkPaymentSlpWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                    //// �d�c�h���M��
                    //wkPaymentSlpWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                    //// �d�c�h�捞��
                    //// �� 2007.12.10 980081 c
                    ////wkPaymentSlpWork.EdiTakeInDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                    //wkPaymentSlpWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                    //// �� 2007.12.10 980081 c
                    //// �� 2007.12.10 980081 d
                    ////// �e�L�X�g���o��
                    ////wkPaymentSlpWork.TextExtraDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TEXTEXTRADATERF"));
                    //// �� 2007.12.10 980081 d
                    //// �� 2007.09.07 980081 a
                    # endregion
                    #endregion
                    //al.Add(paymentSlpWork);  //DEL 2008/04/24 M.Kubota

                    paymentWrkList.Add(paymentSlpWork);

                    //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;  //DEL 2008/04/24 M.Kubota
                }

                //--- ADD 2008/04/24 M.Kubota --->>>
                if (paymentWrkList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    return status;
                }
                //--- ADD 2008/04/24 M.Kubota ---<<<

                if (!myReader.IsClosed) myReader.Close();
                //sqlConnection.Close();  //DEL 2008/04/24 M.Kubota
                //paymentMainWork = al;  //DEL 2008/04/24 M.Kubota

                //--- ADD 2008/04/24 M.Kubota --->>>

                // �x�����׃f�[�^�ǂݍ��ݏ���
                # region [SELECT��]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  DTL.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,DTL.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,DTL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,DTL.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,DTL.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,DTL.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,DTL.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,DTL.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,DTL.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += " ,DTL.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += " ,DTL.PAYMENTROWNORF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDCODERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDDIVRF" + Environment.NewLine;
                sqlText += " ,DTL.PAYMENTRF" + Environment.NewLine;
                sqlText += " ,DTL.VALIDITYTERMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PAYMENTDTLRF AS DTL" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  DTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND DTL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                sqlText += "  AND DTL.PAYMENTSLIPNORF = @FINDPAYMENTSLIPNO" + Environment.NewLine;
                # endregion

                sqlCommand.CommandText = sqlText;
                sqlCommand.Parameters.Clear();

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);    // �d���`��
                SqlParameter findPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);      // �x���`�[�ԍ�

                foreach (PaymentSlpWork slip in paymentWrkList)
                {
                    if (myReader != null && !myReader.IsClosed)
                        myReader.Close();
                    
                    paymentDtlList.Clear();
                    
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(slip.EnterpriseCode);  // ��ƃR�[�h
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(slip.SupplierFormal);   // �d���`��

                    if (slip.DebitNoteDiv != 1)
                    {
                        // �x���`�[�����`���͌����̏ꍇ
                        findPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(slip.PaymentSlipNo);  // �x���`�[�ԍ�
                    }
                    else
                    {
                        // �x���`�[���ԓ`�̏ꍇ
                        findPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(slip.DebitNoteLinkPayNo);  // �ԍ��x���A���ԍ�
                    }

# if DEBUG
                    Console.Clear();
                    Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
# endif

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        PaymentDtlWork dtl = new PaymentDtlWork();

                        dtl.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
                        dtl.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
                        dtl.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));             // ��ƃR�[�h
                        dtl.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
                        dtl.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));           // �X�V�]�ƈ��R�[�h
                        dtl.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));             // �X�V�A�Z���u��ID1
                        dtl.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));             // �X�V�A�Z���u��ID2
                        dtl.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));        // �_���폜�敪
                        dtl.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));              // �d���`��
                        dtl.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));                // �x���`�[�ԍ�
                        dtl.PaymentRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTROWNORF"));                  // �x���s�ԍ�
                        dtl.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));                // ����R�[�h
                        dtl.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));               // ���햼��
                        dtl.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));                  // ����敪
                        dtl.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));                            // �x�����z
                        dtl.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));   // �L������

                        // �ԓ`�̏ꍇ
                        if (slip.DebitNoteDiv == 1)
                        {
                            dtl.PaymentSlipNo = slip.PaymentSlipNo;
                            dtl.Payment = dtl.Payment * -1;
                        }

                        paymentDtlList.Add(dtl);
                    }

                    paymentDtlWorkArray = (PaymentDtlWork[])paymentDtlList.ToArray(typeof(PaymentDtlWork));

                    // �x���`�[�Ǝx�����ׂ���������
                    PaymentDataWork paymentDataWork = null;
                    PaymentDataUtil.Union(out paymentDataWork, slip, paymentDtlWorkArray);

                    if (paymentDataWork != null)
                    {
                        al.Add(paymentDataWork);
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && al.Count > 0)
                {
                    paymentMainWork = al;
                }
                
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            //--- ADD 2008/04/24 M.Kubota ---<<<
            # region --- DEL 2008/04/24 M.Kubota --->>>
            //catch (SqlException ex) 
            //{
            //    //���N���X�ɗ�O��n���ď������Ă��炤
            //    status = base.WriteSQLErrorLog(ex);
            //}
            //if(!myReader.IsClosed)myReader.Close();
            //sqlConnection.Close();

            //paymentMainWork = al;
            //}
            //catch(Exception ex)
            //{
            //    base.WriteErrorLog(ex,"PaymentReadDB.SearchProc Exception="+ex.Message);
            //    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //}
            # endregion --- DEL 2008/04/24 M.Kubota ---<<<

            return status;
        }

		#endregion

        # region  Where���쐬

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="searchParaPaymentRead">�����p�����[�^�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchParaPaymentRead searchParaPaymentRead, ConstantManagement.LogicalMode logicalMode)
        {

            int sDate  = 0;
            int eDate  = 0;
            try
            {
                sDate = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD", searchParaPaymentRead.PaymentCallMonthsStart);
                eDate = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD", searchParaPaymentRead.PaymentCallMonthsEnd);
            }
            catch(Exception)
            {
                sDate = 0;
                eDate = 0;
            }


            string retstring = "WHERE";

            //��ƃR�[�h
            //retstring += "  ENTERPRISECODERF=@ENTERPRISECODE ";  //DEL 2008/04/24 M.Kubota
            retstring += "  PAY.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(searchParaPaymentRead.EnterpriseCode);

            //�_���폜�敪
            string logidelstr = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                //logidelstr = " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";  //DEL 2008/04/24 M.Kubota
                logidelstr = "  AND PAY.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
            }
            else if	((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                //logidelstr = " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";  //DEL 2008/04/24 M.Kubota
                logidelstr = "  AND PAY.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
            }
            if(logidelstr != "")
            {
                retstring += logidelstr;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value        = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //>>>>20060904 iwa add start
            //�x���v�㋒�_�R�[�h            
            if ((searchParaPaymentRead.AddUpSecCode != null) && (searchParaPaymentRead.AddUpSecCode != ""))
            {
                //���_����
                //retstring += " AND ADDUPSECCODERF=@FINDADDUPSECCODE ";  //DEL 2008/04/24 M.Kubota
                retstring += "  AND PAY.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(searchParaPaymentRead.AddUpSecCode);
            }
            //<<<<20060904 iwa add end
            //>>>>20060904 iwa del start
            //�v�㋒�_�R�[�h            
            //if ((searchParaPaymentRead.AddUpSecCode != null) && (searchParaPaymentRead.AddUpSecCode != ""))
            //{
            //    retstring += " AND ADDUPSECCODERF=@FINDADDUPSECCODE ";
            //    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
            //    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(searchParaPaymentRead.AddUpSecCode);
            //}
            //<<<<20060904 iwa del end

            //�d����R�[�h
            if (searchParaPaymentRead.SupplierCd > 0)
            {
                //retstring += " AND SUPPLIERCDRF=@FINDSUPPLIERCDRF ";  //DEL 2008/04/24 M.Kubota
                retstring += "  AND PAY.SUPPLIERCDRF=@FINDSUPPLIERCDRF" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCDRF", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(searchParaPaymentRead.SupplierCd);
            }

           //�x���`�[�ԍ�
            if (searchParaPaymentRead.PaymentSlipNo > 0)
           {
               //retstring += " AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO ";  //DEL 2008/04/24 M.Kubota
               retstring += "  AND PAY.PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
               SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);
               paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(searchParaPaymentRead.PaymentSlipNo);
           }

            //�x����(�J�n)
            if(sDate > 0)
            {
                //retstring += " AND PAYMENTDATERF>=@FINDSTARTDATE ";  //DEL 2008/04/24 M.Kubota
                retstring += "  AND PAY.PAYMENTDATERF>=@FINDSTARTDATE" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
                SqlParameter paraStartDate = sqlCommand.Parameters.Add("@FINDSTARTDATE", SqlDbType.Int);
                paraStartDate.Value = SqlDataMediator.SqlSetInt32(sDate);
            }

            //�x����(�I��)
            if(eDate > 0)
            {
                //retstring += " AND PAYMENTDATERF<=@FINDENDDATE ";  //DEL 2008/04/24 M.Kubota
                retstring += "  AND PAY.PAYMENTDATERF<=@FINDENDDATE" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
                SqlParameter paraEndDate = sqlCommand.Parameters.Add("@FINDENDDATE", SqlDbType.Int);
                paraEndDate.Value = SqlDataMediator.SqlSetInt32(eDate);
            }
            // �� 2008.01.30 980081 a
            //�����x���敪
            if (searchParaPaymentRead.AutoPayment >= 0)
            {
                //retstring += " AND AUTOPAYMENTRF=@FINDAUTOPAYMENT ";  //DEL 2008/04/24 M.Kubota
                retstring += "  AND PAY.AUTOPAYMENTRF=@FINDAUTOPAYMENT" + Environment.NewLine; //ADD 2008/04/24 M.Kubota
                SqlParameter paraAutoPayment = sqlCommand.Parameters.Add("@FINDAUTOPAYMENT", SqlDbType.Int);
                paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(searchParaPaymentRead.AutoPayment);
            }

            //�d���`�[�ԍ�
            if (searchParaPaymentRead.SupplierSlipNo > 0)
            {
                //retstring += " AND SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO ";  //DEL 2008/04/24 M.Kubota
                retstring += "  AND PAY.SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
                SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(searchParaPaymentRead.SupplierSlipNo);
            }
            // �� 2008.01.30 980081 a

            return retstring;
        }

        # endregion
	}

}



