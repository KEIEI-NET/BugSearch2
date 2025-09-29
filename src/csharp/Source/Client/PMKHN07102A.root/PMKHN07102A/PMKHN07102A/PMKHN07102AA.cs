//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : ���Ӑ�}�X�^�i�G�N�X�|�[�g�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H��
// �� �� ��  2010/02/01  �C�����e : MANTIS[14951]�Ή��F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S���F������
// �C �� ��  2012/06/12  �C�����e�F��z�Č��ARedmine#30393 
//                                 ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S���F������
// �C �� ��  2012/07/09  �C�����e�F��z�Č��ARedmine#30387 
//                                  ��Q�ꗗ�̎w�ENO.46�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/24  �C�����e �F��z�Č��ARedmine#30387
//                                  ���쌟��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11900025-00 �쐬�S�� �F3H ����
// �C �� ��  2023/06/28  �C�����e �F���Ӑ旪�̃G�N�X�|�[�g�̕s��Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���Ӑ�}�X�^�i�G�N�X�|�[�g�j�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^�i�G�N�X�|�[�g�j�C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2009.05.12</br>
    /// <br>Update Note: 2012/06/12 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
    /// <br>Update Note: 2012/07/09 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.46�̑Ή�</br>
    /// <br>Update Note: 2012/07/24 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ���쌟��</br>
    /// <br>Update Note: 2023/06/28 3H ����</br>
    /// <br>�Ǘ��ԍ�   : 11900025-00 ���Ӑ旪�̃G�N�X�|�[�g�̕s��Ή�</br>
    /// </remarks>
    public class CustomerExportAcs
    {
        #region �� Private Member

        private ICustomerCustomerChangeDB _iCustomerCustomerChangeDB;

        private const string PRINTSET_TABLE = "CustomerExp";
        #endregion

        # region ��Constracter
        /// <summary>
        /// ���Ӑ�}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public CustomerExportAcs()
        {
            this._iCustomerCustomerChangeDB = (ICustomerCustomerChangeDB)MediationCustomerCustomerChangeDB.GetCustomerCustomerChangeDB();
        }
        # endregion

        #region �� ���Ӑ�}�X�^��񌟍�
        /// <summary>
        /// ���Ӑ�}�X�^�f�[�^�擾����
        /// </summary>
        /// <param name="condition">��������</param>
        /// <param name="dataTable">�����f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�f�[�^�擾�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2012/06/12 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
        /// <br>Update Note: 2012/07/24 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ���쌟��</br>
        /// </remarks>
        public int Search(CustomerExportWork condition, out DataTable dataTable)
        {
            int status = 0;
            dataTable = new DataTable(PRINTSET_TABLE);
            CreateDataTable(ref dataTable);

            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;

            CustomerCustomerChangeParamWork customerCustomerChangeParamWork = new CustomerCustomerChangeParamWork();

            customerCustomerChangeParamWork.EnterpriseCode = condition.EnterpriseCode;
            customerCustomerChangeParamWork.StCustomerCode = condition.CustomerCdSt;
            customerCustomerChangeParamWork.EdCustomerCode = condition.CustomerCdEd;
            customerCustomerChangeParamWork.StMngSectionCode = condition.SectionCdSt;
            customerCustomerChangeParamWork.EdMngSectionCode = condition.SectionCdEd;
            customerCustomerChangeParamWork.SearchDiv = 1;// ADD  2012/06/12  ������ Redmine#30393

            object al = null;

            status = _iCustomerCustomerChangeDB.Search(ref al, customerCustomerChangeParamWork, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList retReatList = (ArrayList)al;
                // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
                CustomerInputAcs cust = new CustomerInputAcs();
                int ConsTaxLay = cust.GetConsTaxLayMethod(customerCustomerChangeParamWork.EnterpriseCode, 0);
                int index = 0;
                Dictionary<int, CustomerCustomerChangeResultWork> dict = new Dictionary<int, CustomerCustomerChangeResultWork>();
                int i = 0;
                // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
                foreach (CustomerCustomerChangeResultWork customerCustomerChangeResultWork in retReatList)
                {
                   //ConverToDataSetCustomerInf(customerCustomerChangeResultWork, ref dataTable);// DEL  2012/06/12  ������ Redmine#30393
                    // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
                    if (!dict.ContainsKey(customerCustomerChangeResultWork.CustomerCode))
                        {
                            dict.Add(customerCustomerChangeResultWork.CustomerCode, customerCustomerChangeResultWork);
                            int total = 0;
                            for (int j = i + 1; j < retReatList.Count; j++)
                            {
                                CustomerCustomerChangeResultWork custcust = retReatList[j] as CustomerCustomerChangeResultWork;
                                if (customerCustomerChangeResultWork.CustomerCode == custcust.CustomerCode)
                                {
                                    total += 1;
                                    break;
                                }

                            }
                            if (total == 0) { customerCustomerChangeResultWork.CustRateGrpCode = -1; }
                        }
                        i++;
                        // ------ ADD START 2012/07/24 Redmine#30393 ������ for ���쌟��-------->>>>
                        if (customerCustomerChangeResultWork.CustLogicalDeleteCode != 0) { customerCustomerChangeResultWork.CustRateGrpCode = -1; }
                        // ------ ADD END 2012/07/24 Redmine#30393 ������ for ���쌟��--------<<<<
                        ConverToDataSetCustomerInf(customerCustomerChangeResultWork, ref dataTable, ConsTaxLay, index);
                        ++index; 
                    // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
                }
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }
        #endregion

        #region �� Private Methods
        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2012/06/12 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("CustomerCodeRF", typeof(string));           //  ���Ӑ�R�[�h
            dataTable.Columns.Add("CustomerSubCodeRF", typeof(string));	      //  ���Ӑ�T�u�R�[�h
            dataTable.Columns.Add("NameRF", typeof(string));	              //  ����
            dataTable.Columns.Add("Name2RF", typeof(string));	              //  ����2
            dataTable.Columns.Add("CustomerSnmRF", typeof(string));	          //  ���Ӑ旪��
            dataTable.Columns.Add("KanaRF", typeof(string));	              //  �J�i
            dataTable.Columns.Add("HonorificTitleRF", typeof(string));	      //  �h��
            dataTable.Columns.Add("OutputNameCodeRF", typeof(string));	      //  �����R�[�h
            dataTable.Columns.Add("MngSectionCodeRF", typeof(string));	      //  �Ǘ����_�R�[�h
            dataTable.Columns.Add("CustomerAgentCdRF", typeof(string));	      //  �ڋq�S���]�ƈ��R�[�h

            dataTable.Columns.Add("OldCustomerAgentCdRF", typeof(string));	  //  ���ڋq�S���]�ƈ��R�[�h
            dataTable.Columns.Add("CustAgentChgDateRF", typeof(string));       //  �ڋq�S���ύX��
            dataTable.Columns.Add("TransStopDateRF", typeof(string));	      //  ������~��	
            dataTable.Columns.Add("CarMngDivCdRF", typeof(string));	          //  ���q�Ǘ��敪
            dataTable.Columns.Add("CorporateDivCodeRF", typeof(string));       //  �l�E�@�l�敪
            dataTable.Columns.Add("AcceptWholeSaleRF", typeof(string));	      //  �Ɣ̐�敪
            dataTable.Columns.Add("CustomerAttributeDivRF", typeof(string));	  //  ���Ӑ摮���敪
            dataTable.Columns.Add("CustWarehouseCdRF", typeof(string));	      //  ���Ӑ�D��q�ɃR�[�h
            dataTable.Columns.Add("BusinessTypeCodeRF", typeof(string));       //  �Ǝ�R�[�h
            dataTable.Columns.Add("JobTypeCodeRF", typeof(string));	          //  �E��R�[�h

            dataTable.Columns.Add("SalesAreaCodeRF", typeof(string));	      //  �̔��G���A�R�[�h
            dataTable.Columns.Add("CustAnalysCode1RF", typeof(string));        //  ���Ӑ敪�̓R�[�h1
            dataTable.Columns.Add("CustAnalysCode2RF", typeof(string));	      //  ���Ӑ敪�̓R�[�h2
            dataTable.Columns.Add("CustAnalysCode3RF", typeof(string));	      //  ���Ӑ敪�̓R�[�h3
            dataTable.Columns.Add("CustAnalysCode4RF", typeof(string));	      //  ���Ӑ敪�̓R�[�h4
            dataTable.Columns.Add("CustAnalysCode5RF", typeof(string));	      //  ���Ӑ敪�̓R�[�h5
            dataTable.Columns.Add("CustAnalysCode6RF", typeof(string));	      //  ���Ӑ敪�̓R�[�h6
            dataTable.Columns.Add("ClaimSectionCodeRF", typeof(string));	  //  �������_�R�[�h
            dataTable.Columns.Add("ClaimCodeRF", typeof(string));              //  ������R�[�h
            dataTable.Columns.Add("TotalDayRF", typeof(string));	              //  ����

            dataTable.Columns.Add("CollectMoneyCodeRF", typeof(string));	      //  �W�����敪�R�[�h
            dataTable.Columns.Add("CollectMoneyDayRF", typeof(string));	      //  �W����
            dataTable.Columns.Add("CollectCondRF", typeof(string));	          //  �������
            dataTable.Columns.Add("CollectSightRF", typeof(string));	          //  ����T�C�g
            dataTable.Columns.Add("NTimeCalcStDateRF", typeof(string));        //  ���񊨒�J�n��
            dataTable.Columns.Add("BillCollecterCdRF", typeof(string));	      //  �W���S���]�ƈ��R�[�h
            dataTable.Columns.Add("CustCTaXLayRefCdRF", typeof(string));	      //  ���Ӑ����œ]�ŕ����Q�Ƌ敪
            dataTable.Columns.Add("ConsTaxLayMethodRF", typeof(string));	      //  ����œ]�ŕ���
            dataTable.Columns.Add("SalesUnPrcFrcProcCdRF", typeof(string));	  //  ����P���[�������R�[�h
            dataTable.Columns.Add("SalesMoneyFrcProcCdRF", typeof(string));	  //  ������z�[�������R�[�h

            dataTable.Columns.Add("SalesCnsTaxFrcProcCdRF", typeof(string));   //  �������Œ[�������R�[�h
            dataTable.Columns.Add("CreditMngCodeRF", typeof(string));	      //  �^�M�Ǘ��敪 
            dataTable.Columns.Add("DepoDelCodeRF", typeof(string));	          //  ���������敪
            dataTable.Columns.Add("AccRecDivCdRF", typeof(string));	          //  ���|�敪
            dataTable.Columns.Add("PostNoRF", typeof(string));	              //  �X�֔ԍ�
            dataTable.Columns.Add("Address1RF", typeof(string));	          //  �Z��1�i�s���{���s��S�E�����E���j
            dataTable.Columns.Add("Address3RF", typeof(string));	          //  �Z��3�i�Ԓn�j
            dataTable.Columns.Add("Address4RF", typeof(string));	          //  �Z��4�i�A�p�[�g���́j
            dataTable.Columns.Add("CustomerAgentRF", typeof(string));         //  ���Ӑ�S����

            dataTable.Columns.Add("HomeTelNoRF", typeof(string));             //  �d�b�ԍ��i����j
            dataTable.Columns.Add("OfficeTelNoRF", typeof(string));	          //  �d�b�ԍ��i�Ζ���j
            dataTable.Columns.Add("PortableTelNoRF", typeof(string));	      //  �d�b�ԍ��i�g�сj
            dataTable.Columns.Add("OthersTelNoRF", typeof(string));	          //  �d�b�ԍ��i���̑��j
            dataTable.Columns.Add("HomeFaxNoRF", typeof(string));	          //  FAX�ԍ��i����j
            dataTable.Columns.Add("OfficeFaxNoRF", typeof(string));	          //  FAX�ԍ��i�Ζ���j

            dataTable.Columns.Add("SearchTelNoRF", typeof(string));	          //  �d�b�ԍ��i�����p��4���j
            dataTable.Columns.Add("MainContactCodeRF", typeof(string));	      //  ��A����敪
            dataTable.Columns.Add("Note1RF", typeof(string));	              //  ���l�P
            dataTable.Columns.Add("Note2RF", typeof(string));	              //  ���l�Q
            dataTable.Columns.Add("Note3RF", typeof(string));	              //  ���l�R

            dataTable.Columns.Add("Note4RF", typeof(string));	              //  ���l�S
            dataTable.Columns.Add("Note5RF", typeof(string));	              //  ���l�T 
            dataTable.Columns.Add("Note6RF", typeof(string));	              //  ���l�U
            dataTable.Columns.Add("Note7RF", typeof(string));	              //  ���l�V
            dataTable.Columns.Add("Note8RF", typeof(string));	              //  ���l�W
            dataTable.Columns.Add("Note9RF", typeof(string));	              //  ���l�X
            dataTable.Columns.Add("Note10RF", typeof(string));	              // ���l�P�O
            dataTable.Columns.Add("MainSendMailAddrCdRF", typeof(string));	  //  �呗�M�惁�[���A�h���X�敪
            dataTable.Columns.Add("MailAddress1RF", typeof(string));	      //  ���[���A�h���X1	
            dataTable.Columns.Add("MailSendCode1RF", typeof(string));	      //  ���[�����M�敪�R�[�h1

            dataTable.Columns.Add("MailAddrKindCode1RF", typeof(string));	  //  ���[���A�h���X��ʃR�[�h1
            dataTable.Columns.Add("MailAddress2RF", typeof(string));	      // ���[���A�h���X�Q 
            dataTable.Columns.Add("MailSendCode2RF", typeof(string));	      //  ���[�����M�敪�R�[�h�Q
            dataTable.Columns.Add("MailAddrKindCode2RF", typeof(string));	  //  ���[���A�h���X��ʃR�[�h�Q
            dataTable.Columns.Add("AccountNoInfo1RF", typeof(string));	      //  ��s�����P
            dataTable.Columns.Add("AccountNoInfo2RF", typeof(string));	      //  ��s�����Q
            dataTable.Columns.Add("AccountNoInfo3RF", typeof(string));	      //  ��s�����R
            // DEL 2010/02/01 MANTIS�Ή�[14951]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            //  TODO:�g�p���Ȃ��c�������o�͋敪�R�[�h
            //dataTable.Columns.Add("BillOutputCodeRF", typeof(string));	      //  �������o�͋敪�R�[�h
            // DEL 2010/02/01 MANTIS�Ή�[14951]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<
            dataTable.Columns.Add("ReceiptOutputCodeRF", typeof(string));	  // �̎����o�͋敪�R�[�h
            dataTable.Columns.Add("DmOutCodeRF", typeof(string));	          //  DM�o�͋敪

            dataTable.Columns.Add("SalesSlipPrtDivRF", typeof(string));	      //  ����`�[���s�敪
            dataTable.Columns.Add("AcpOdrrSlipPrtDivRF", typeof(string));	  //  �󒍓`�[���s�敪
            dataTable.Columns.Add("ShipmSlipPrtDivRF", typeof(string));	      //  �o�ד`�[���s�敪
            dataTable.Columns.Add("EstimatePrtDivRF", typeof(string));	      //  ���Ϗ����s�敪	
            dataTable.Columns.Add("UOESlipPrtDivRF", typeof(string));	      // UOE�`�[���s�敪	
            dataTable.Columns.Add("QrcodePrtCdRF", typeof(string));	          //  QR�R�[�h���
            dataTable.Columns.Add("CustSlipNoMngCdRF", typeof(string));	      //  ����`�[�ԍ��Ǘ��敪
            dataTable.Columns.Add("CustomerSlipNoDivRF", typeof(string));	  //  ���Ӑ�`�[�ԍ��敪

            // ADD 2010/02/01 MANTIS�Ή�[14951]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            dataTable.Columns.Add("TotalBillOutputDivRF", typeof(string));      // ���v�������o�͋敪
            dataTable.Columns.Add("DetailBillOutputCodeRF", typeof(string));    // ���א������o�͋敪
            dataTable.Columns.Add("SlipTtlBillOutputDivRF", typeof(string));    // �`�[���v�������o�͋敪
            // ADD 2010/02/01 MANTIS�Ή�[14951]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

            // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
            //dataTable.Columns.Add("CustRateGrpFine", typeof(string));          //���Ӑ�|���O���[�v(�D��)// DEL  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
            dataTable.Columns.Add("CustRateGrpFineAll", typeof(string));          //���Ӑ�|���O���[�v(�D��ALL)// ADD  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
            dataTable.Columns.Add("CustRateGrpPureAll", typeof(string));       //���Ӑ�|���O���[�v(����ALL)
            dataTable.Columns.Add("CustRateGrpPure1", typeof(string));         //���Ӑ�|���O���[�v�����P
            dataTable.Columns.Add("CustRateGrpPure2", typeof(string));         //���Ӑ�|���O���[�v����2
            dataTable.Columns.Add("CustRateGrpPure3", typeof(string));         //���Ӑ�|���O���[�v����3
            dataTable.Columns.Add("CustRateGrpPure4", typeof(string));         //���Ӑ�|���O���[�v����4
            dataTable.Columns.Add("CustRateGrpPure5", typeof(string));         //���Ӑ�|���O���[�v����5
            dataTable.Columns.Add("CustRateGrpPure6", typeof(string));         //���Ӑ�|���O���[�v����6
            dataTable.Columns.Add("CustRateGrpPure7", typeof(string));         //���Ӑ�|���O���[�v����7
            dataTable.Columns.Add("CustRateGrpPure8", typeof(string));         //���Ӑ�|���O���[�v����8
            dataTable.Columns.Add("CustRateGrpPure9", typeof(string));         //���Ӑ�|���O���[�v����9
            dataTable.Columns.Add("CustRateGrpPure10", typeof(string));        //���Ӑ�|���O���[�v�����P0
            dataTable.Columns.Add("CustRateGrpPure11", typeof(string));        //���Ӑ�|���O���[�v�����P1
            dataTable.Columns.Add("CustRateGrpPure12", typeof(string));        //���Ӑ�|���O���[�v�����P2
            dataTable.Columns.Add("CustRateGrpPure13", typeof(string));        //���Ӑ�|���O���[�v�����P3
            dataTable.Columns.Add("CustRateGrpPure14", typeof(string));        //���Ӑ�|���O���[�v�����P4
            dataTable.Columns.Add("CustRateGrpPure15", typeof(string));        //���Ӑ�|���O���[�v�����P5
            dataTable.Columns.Add("CustRateGrpPure16", typeof(string));        //���Ӑ�|���O���[�v�����P6
            dataTable.Columns.Add("CustRateGrpPure17", typeof(string));        //���Ӑ�|���O���[�v�����P7
            dataTable.Columns.Add("CustRateGrpPure18", typeof(string));        //���Ӑ�|���O���[�v�����P8
            dataTable.Columns.Add("CustRateGrpPure19", typeof(string));        //���Ӑ�|���O���[�v�����P9
            dataTable.Columns.Add("CustRateGrpPure20", typeof(string));        //���Ӑ�|���O���[�v����20
            dataTable.Columns.Add("CustRateGrpPure21", typeof(string));        //���Ӑ�|���O���[�v����21
            dataTable.Columns.Add("CustRateGrpPure22", typeof(string));        //���Ӑ�|���O���[�v����22
            dataTable.Columns.Add("CustRateGrpPure23", typeof(string));        //���Ӑ�|���O���[�v����23
            dataTable.Columns.Add("CustRateGrpPure24", typeof(string));        //���Ӑ�|���O���[�v����24
            dataTable.Columns.Add("CustRateGrpPure25", typeof(string));        //���Ӑ�|���O���[�v����25
            //--------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
        }

        /// <summary>
        /// �������ʂ�ConvertToDataSet
        /// </summary>
        /// <param name="customerWork">��������</param>
        /// <param name="dataTable">����DataTable</param>
        /// <param name="ConsTaxLay">����œ]�ŕ���</param>
        /// <param name="para_index">DataTable �s�̕W�I</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataSet�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2012/06/12 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
        /// <br>Update Note: 2023/06/28 3H ����</br>
        /// <br>�Ǘ��ԍ�   : 11900025-00�@���Ӑ旪�̃G�N�X�|�[�g�̕s��Ή�</br>
        /// </remarks>
        //private void ConverToDataSetCustomerInf(CustomerCustomerChangeResultWork customerWork, ref DataTable dataTable)// DEL  2012/06/12  ������ Redmine#30393 
        private void ConverToDataSetCustomerInf(CustomerCustomerChangeResultWork customerWork, ref DataTable dataTable, int ConsTaxLay, int para_index)// ADD  2012/06/12  ������ Redmine#30393 
        {
            // --------------- DEL START 2012/06/12 Redmine#30393 ������-------->>>>
            //DataRow dataRow = dataTable.NewRow();

            //dataRow["CustomerCodeRF"] = AppendZero(customerWork.CustomerCode.ToString(), 8);
            //dataRow["CustomerSubCodeRF"] = customerWork.CustomerSubCode.Trim();
            //dataRow["NameRF"] = GetSubString(customerWork.Name, 30);
            //dataRow["Name2RF"] = GetSubString(customerWork.Name2, 30);
            //dataRow["CustomerSnmRF"] = GetSubString(customerWork.CustomerSnm, 15);
            //dataRow["KanaRF"] = GetSubString(customerWork.Kana, 30);
            //dataRow["HonorificTitleRF"] = GetSubString(customerWork.HonorificTitle, 4);
            //dataRow["OutputNameCodeRF"] = AppendZero(customerWork.OutputNameCode.ToString(), 2);

            //dataRow["MngSectionCodeRF"] = AppendStrZero(customerWork.MngSectionCode, 2);
            //dataRow["CustomerAgentCdRF"] = AppendStrZero(customerWork.CustomerAgentCd, 4);
            //dataRow["OldCustomerAgentCdRF"] = AppendStrZero(customerWork.OldCustomerAgentCd, 4);
            //if (customerWork.CustAgentChgDate == DateTime.MinValue)
            //{
            //    dataRow["CustAgentChgDateRF"] = DBNull.Value;
            //}
            //else
            //{
            //    dataRow["CustAgentChgDateRF"] = TDateTime.DateTimeToLongDate("YYYYMMDD", customerWork.CustAgentChgDate).ToString();
            //}
            //if (customerWork.TransStopDate == DateTime.MinValue)
            //{
            //    dataRow["TransStopDateRF"] = DBNull.Value;
            //}
            //else
            //{
            //    dataRow["TransStopDateRF"] = TDateTime.DateTimeToLongDate("YYYYMMDD", customerWork.TransStopDate).ToString();
            //}

            //dataRow["CarMngDivCdRF"] = customerWork.CarMngDivCd.ToString();
            //dataRow["CorporateDivCodeRF"] = customerWork.CorporateDivCode.ToString();
            //dataRow["AcceptWholeSaleRF"] = customerWork.AcceptWholeSale.ToString();
            //dataRow["CustomerAttributeDivRF"] = customerWork.CustomerAttributeDiv.ToString();
            //dataRow["CustWarehouseCdRF"] = AppendStrZero(customerWork.CustWarehouseCd, 4);
            //dataRow["BusinessTypeCodeRF"] = AppendZero(customerWork.BusinessTypeCode.ToString(), 4);
            //dataRow["JobTypeCodeRF"] = AppendZero(customerWork.JobTypeCode.ToString(), 4);
            //dataRow["SalesAreaCodeRF"] = AppendZero(customerWork.SalesAreaCode.ToString(), 4);
            //dataRow["CustAnalysCode1RF"] = customerWork.CustAnalysCode1.ToString();
            //dataRow["CustAnalysCode2RF"] = customerWork.CustAnalysCode2.ToString();
            //dataRow["CustAnalysCode3RF"] = customerWork.CustAnalysCode3.ToString();
            //dataRow["CustAnalysCode4RF"] = customerWork.CustAnalysCode4.ToString();
            //dataRow["CustAnalysCode5RF"] = customerWork.CustAnalysCode5.ToString();
            //dataRow["CustAnalysCode6RF"] = customerWork.CustAnalysCode6.ToString();

            //dataRow["ClaimSectionCodeRF"] = AppendStrZero(customerWork.ClaimSectionCode, 2);
            //dataRow["ClaimCodeRF"] = AppendZero(customerWork.ClaimCode.ToString(), 8);
            //if (customerWork.TotalDay == 0)
            //{
            //    dataRow["TotalDayRF"] = DBNull.Value;
            //}
            //else
            //{
            //    dataRow["TotalDayRF"] = customerWork.TotalDay.ToString();
            //}

            //dataRow["CollectMoneyCodeRF"] = customerWork.CollectMoneyCode.ToString();
            //if (customerWork.CollectMoneyDay == 0)
            //{
            //    dataRow["CollectMoneyDayRF"] = DBNull.Value;
            //}
            //else
            //{
            //    dataRow["CollectMoneyDayRF"] = customerWork.CollectMoneyDay.ToString();
            //}
            //dataRow["CollectCondRF"] = GetSubString(customerWork.CollectCond.ToString(), 2);
            //dataRow["CollectSightRF"] = GetSubString(customerWork.CollectSight.ToString(), 3);
            //if (customerWork.NTimeCalcStDate == 0)
            //{
            //    dataRow["NTimeCalcStDateRF"] = DBNull.Value;
            //}
            //else
            //{
            //    dataRow["NTimeCalcStDateRF"] = customerWork.NTimeCalcStDate.ToString();
            //}
            //dataRow["BillCollecterCdRF"] = AppendStrZero(customerWork.BillCollecterCd, 4);

            //dataRow["CustCTaXLayRefCdRF"] = customerWork.CustCTaXLayRefCd.ToString();
            //dataRow["ConsTaxLayMethodRF"] = customerWork.ConsTaxLayMethod.ToString();
            //dataRow["SalesUnPrcFrcProcCdRF"] = customerWork.SalesUnPrcFrcProcCd.ToString();
            //dataRow["SalesMoneyFrcProcCdRF"] = customerWork.SalesMoneyFrcProcCd.ToString();
            //dataRow["SalesCnsTaxFrcProcCdRF"] = customerWork.SalesCnsTaxFrcProcCd.ToString();
            //dataRow["CreditMngCodeRF"] = customerWork.CreditMngCode.ToString();
            //dataRow["DepoDelCodeRF"] = customerWork.DepoDelCode.ToString();
            //dataRow["AccRecDivCdRF"] = customerWork.AccRecDivCd.ToString();

            //dataRow["PostNoRF"] = GetSubString(customerWork.PostNo, 10);
            //dataRow["Address1RF"] = GetSubString(customerWork.Address1, 30);
            //dataRow["Address3RF"] = GetSubString(customerWork.Address3, 22);
            //dataRow["Address4RF"] = GetSubString(customerWork.Address4, 30);
            //dataRow["CustomerAgentRF"] = GetSubString(customerWork.CustomerAgent, 20);

            //dataRow["HomeTelNoRF"] = GetSubString(customerWork.HomeTelNo, 16);
            //dataRow["OfficeTelNoRF"] = GetSubString(customerWork.OfficeTelNo, 16);
            //dataRow["PortableTelNoRF"] = GetSubString(customerWork.PortableTelNo, 16);
            //dataRow["OthersTelNoRF"] = GetSubString(customerWork.OthersTelNo, 16);
            //dataRow["HomeFaxNoRF"] = GetSubString(customerWork.HomeFaxNo, 16);
            //dataRow["OfficeFaxNoRF"] = GetSubString(customerWork.OfficeFaxNo, 16);
            //dataRow["SearchTelNoRF"] = GetSubString(customerWork.SearchTelNo, 4);
            //dataRow["MainContactCodeRF"] = customerWork.MainContactCode;

            //dataRow["Note1RF"] = GetSubString(customerWork.Note1, 20);
            //dataRow["Note2RF"] = GetSubString(customerWork.Note2, 20);
            //dataRow["Note3RF"] = GetSubString(customerWork.Note3, 20);
            //dataRow["Note4RF"] = GetSubString(customerWork.Note4, 20);
            //dataRow["Note5RF"] = GetSubString(customerWork.Note5, 20);
            //dataRow["Note6RF"] = GetSubString(customerWork.Note6, 20);
            //dataRow["Note7RF"] = GetSubString(customerWork.Note7, 20);
            //dataRow["Note8RF"] = GetSubString(customerWork.Note8, 20);
            //dataRow["Note9RF"] = GetSubString(customerWork.Note9, 20);
            //dataRow["Note10RF"] = GetSubString(customerWork.Note10, 20);
            //dataRow["MainSendMailAddrCdRF"] = GetSubString(customerWork.MainSendMailAddrCd.ToString(), 64);
            //dataRow["MailAddress1RF"] = GetSubString(customerWork.MailAddress1, 64);
            //dataRow["MailSendCode1RF"] = customerWork.MailSendCode1.ToString();
            //dataRow["MailAddrKindCode1RF"] = customerWork.MailAddrKindCode1.ToString();
            //dataRow["MailAddress2RF"] = GetSubString(customerWork.MailAddress2, 64);
            //dataRow["MailSendCode2RF"] = customerWork.MailSendCode2.ToString();
            //dataRow["MailAddrKindCode2RF"] = customerWork.MailAddrKindCode2.ToString();


            //dataRow["AccountNoInfo1RF"] = GetSubString(customerWork.AccountNoInfo1, 60);
            //dataRow["AccountNoInfo2RF"] = GetSubString(customerWork.AccountNoInfo2, 60);
            //dataRow["AccountNoInfo3RF"] = GetSubString(customerWork.AccountNoInfo3, 60);
            //// DEL 2010/02/01 MANTIS�Ή�[14951]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            //// TODO:�g�p���Ȃ��c�������o�͋敪�R�[�h
            ////dataRow["BillOutputCodeRF"] = customerWork.BillOutputCode.ToString();
            //// DEL 2010/02/01 MANTIS�Ή�[14951]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<
            //dataRow["ReceiptOutputCodeRF"] = customerWork.ReceiptOutputCode.ToString();
            //dataRow["DmOutCodeRF"] = customerWork.DmOutCode.ToString();
            //dataRow["SalesSlipPrtDivRF"] = customerWork.SalesSlipPrtDiv.ToString();
            //dataRow["AcpOdrrSlipPrtDivRF"] = customerWork.AcpOdrrSlipPrtDiv.ToString();
            //dataRow["ShipmSlipPrtDivRF"] = customerWork.ShipmSlipPrtDiv.ToString();
            //dataRow["EstimatePrtDivRF"] = customerWork.EstimatePrtDiv.ToString();
            //dataRow["UOESlipPrtDivRF"] = customerWork.UOESlipPrtDiv.ToString();
            //dataRow["QrcodePrtCdRF"] = customerWork.QrcodePrtCd.ToString();
            //dataRow["CustSlipNoMngCdRF"] = customerWork.CustSlipNoMngCd.ToString();
            //dataRow["CustomerSlipNoDivRF"] = customerWork.CustomerSlipNoDiv.ToString();

            //// ADD 2010/02/01 MANTIS�Ή�[14951]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            //dataRow["TotalBillOutputDivRF"]     = customerWork.TotalBillOutputDiv.ToString();   // ���v�������o�͋敪
            //dataRow["DetailBillOutputCodeRF"]   = customerWork.DetailBillOutputCode.ToString(); // ���א������o�͋敪
            //dataRow["SlipTtlBillOutputDivRF"]   = customerWork.SlipTtlBillOutputDiv.ToString(); // �`�[���v�������o�͋敪
            //// ADD 2010/02/01 MANTIS�Ή�[14951]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

            //dataTable.Rows.Add(dataRow);
            // --------------- DEL END 2012/06/12 Redmine#30393 ������--------<<<<
            // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
            int index = -1;
            if (para_index != 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (dataTable.Rows[i]["CustomerCodeRF"].ToString().Equals(customerWork.CustomerCode.ToString("00000000")))
                    {
                        index = i;
                        break;
                    }
                }
            }
            if (index == -1)
            {
                DataRow dataRow = dataTable.NewRow();
                dataTable.Rows.Add(dataRow);
                index = dataTable.Rows.Count - 1;

            }
            dataTable.Rows[index]["CustomerCodeRF"] = AppendZero(customerWork.CustomerCode.ToString(), 8);
            dataTable.Rows[index]["CustomerSubCodeRF"] = customerWork.CustomerSubCode.Trim();
            dataTable.Rows[index]["NameRF"] = GetSubString(customerWork.Name, 30);
            dataTable.Rows[index]["Name2RF"] = GetSubString(customerWork.Name2, 30);
            //dataTable.Rows[index]["CustomerSnmRF"] = GetSubString(customerWork.CustomerSnm, 15); // DEL 2023/06/28 3H ����
            dataTable.Rows[index]["CustomerSnmRF"] = GetSubString(customerWork.CustomerSnm, 20); // ADD 2023/06/28 3H ����
            dataTable.Rows[index]["KanaRF"] = GetSubString(customerWork.Kana, 30);
            dataTable.Rows[index]["HonorificTitleRF"] = GetSubString(customerWork.HonorificTitle, 4);
            dataTable.Rows[index]["OutputNameCodeRF"] = AppendZero(customerWork.OutputNameCode.ToString(), 1);
            dataTable.Rows[index]["MngSectionCodeRF"] = AppendStrZero(customerWork.MngSectionCode, 2);
            dataTable.Rows[index]["CustomerAgentCdRF"] = AppendStrZero(customerWork.CustomerAgentCd, 4);
            dataTable.Rows[index]["OldCustomerAgentCdRF"] = AppendStrZero(customerWork.OldCustomerAgentCd, 4);
            if (customerWork.CustAgentChgDate == DateTime.MinValue)
            {
                dataTable.Rows[index]["CustAgentChgDateRF"] = DBNull.Value;
            }
            else
            {

                dataTable.Rows[index]["CustAgentChgDateRF"] = TDateTime.DateTimeToLongDate("YYYYMMDD", customerWork.CustAgentChgDate).ToString();
            }
            if (customerWork.TransStopDate == DateTime.MinValue)
            {

                dataTable.Rows[index]["TransStopDateRF"] = DBNull.Value;
            }
            else
            {
                dataTable.Rows[index]["TransStopDateRF"] = TDateTime.DateTimeToLongDate("YYYYMMDD", customerWork.TransStopDate).ToString();
            }

            dataTable.Rows[index]["CarMngDivCdRF"] = customerWork.CarMngDivCd.ToString();
            dataTable.Rows[index]["CorporateDivCodeRF"] = customerWork.CorporateDivCode.ToString();
            dataTable.Rows[index]["AcceptWholeSaleRF"] = customerWork.AcceptWholeSale.ToString();
            dataTable.Rows[index]["CustomerAttributeDivRF"] = customerWork.CustomerAttributeDiv.ToString();
            dataTable.Rows[index]["CustWarehouseCdRF"] = AppendStrZero(customerWork.CustWarehouseCd, 4);
            dataTable.Rows[index]["BusinessTypeCodeRF"] = AppendZero(customerWork.BusinessTypeCode.ToString(), 4);
            dataTable.Rows[index]["JobTypeCodeRF"] = AppendZero(customerWork.JobTypeCode.ToString(), 4);
            dataTable.Rows[index]["SalesAreaCodeRF"] = AppendZero(customerWork.SalesAreaCode.ToString(), 4);
            dataTable.Rows[index]["CustAnalysCode1RF"] = customerWork.CustAnalysCode1.ToString();
            dataTable.Rows[index]["CustAnalysCode2RF"] = customerWork.CustAnalysCode2.ToString();
            dataTable.Rows[index]["CustAnalysCode3RF"] = customerWork.CustAnalysCode3.ToString();
            dataTable.Rows[index]["CustAnalysCode4RF"] = customerWork.CustAnalysCode4.ToString();
            dataTable.Rows[index]["CustAnalysCode5RF"] = customerWork.CustAnalysCode5.ToString();
            dataTable.Rows[index]["CustAnalysCode6RF"] = customerWork.CustAnalysCode6.ToString();

            dataTable.Rows[index]["ClaimSectionCodeRF"] = AppendStrZero(customerWork.ClaimSectionCode, 2);
            dataTable.Rows[index]["ClaimCodeRF"] = AppendZero(customerWork.ClaimCode.ToString(), 8);
            if (customerWork.TotalDay == 0)
            {
                dataTable.Rows[index]["TotalDayRF"] = DBNull.Value;
            }
            else
            {
                dataTable.Rows[index]["TotalDayRF"] = customerWork.TotalDay.ToString();
            }

            dataTable.Rows[index]["CollectMoneyCodeRF"] = customerWork.CollectMoneyCode.ToString();
            if (customerWork.CollectMoneyDay == 0)
            {
                dataTable.Rows[index]["CollectMoneyDayRF"] = DBNull.Value;
            }
            else
            {
                dataTable.Rows[index]["CollectMoneyDayRF"] = customerWork.CollectMoneyDay.ToString();
            }
            dataTable.Rows[index]["CollectCondRF"] = GetSubString(customerWork.CollectCond.ToString(), 2);
            dataTable.Rows[index]["CollectSightRF"] = GetSubString(customerWork.CollectSight.ToString(), 3);
            if (customerWork.NTimeCalcStDate == 0)
            {
                dataTable.Rows[index]["NTimeCalcStDateRF"] = DBNull.Value;
            }
            else
            {
                dataTable.Rows[index]["NTimeCalcStDateRF"] = customerWork.NTimeCalcStDate.ToString();
            }
            dataTable.Rows[index]["BillCollecterCdRF"] = AppendStrZero(customerWork.BillCollecterCd, 4);

            dataTable.Rows[index]["CustCTaXLayRefCdRF"] = customerWork.CustCTaXLayRefCd.ToString();
            if (customerWork.CustCTaXLayRefCd == 0)
            {
                dataTable.Rows[index]["ConsTaxLayMethodRF"] = ConsTaxLay.ToString();
            }
            else
            {
                dataTable.Rows[index]["ConsTaxLayMethodRF"] = customerWork.ConsTaxLayMethod.ToString();
            }
            dataTable.Rows[index]["SalesUnPrcFrcProcCdRF"] = customerWork.SalesUnPrcFrcProcCd.ToString();
            dataTable.Rows[index]["SalesMoneyFrcProcCdRF"] = customerWork.SalesMoneyFrcProcCd.ToString();
            dataTable.Rows[index]["SalesCnsTaxFrcProcCdRF"] = customerWork.SalesCnsTaxFrcProcCd.ToString();
            dataTable.Rows[index]["CreditMngCodeRF"] = customerWork.CreditMngCode.ToString();
            dataTable.Rows[index]["DepoDelCodeRF"] = customerWork.DepoDelCode.ToString();
            dataTable.Rows[index]["AccRecDivCdRF"] = customerWork.AccRecDivCd.ToString();

            dataTable.Rows[index]["PostNoRF"] = GetSubString(customerWork.PostNo, 10);
            dataTable.Rows[index]["Address1RF"] = GetSubString(customerWork.Address1, 30);
            dataTable.Rows[index]["Address3RF"] = GetSubString(customerWork.Address3, 22);
            dataTable.Rows[index]["Address4RF"] = GetSubString(customerWork.Address4, 30);
            dataTable.Rows[index]["CustomerAgentRF"] = GetSubString(customerWork.CustomerAgent, 20);

            dataTable.Rows[index]["HomeTelNoRF"] = GetSubString(customerWork.HomeTelNo, 16);
            dataTable.Rows[index]["OfficeTelNoRF"] = GetSubString(customerWork.OfficeTelNo, 16);
            dataTable.Rows[index]["PortableTelNoRF"] = GetSubString(customerWork.PortableTelNo, 16);
            dataTable.Rows[index]["OthersTelNoRF"] = GetSubString(customerWork.OthersTelNo, 16);
            dataTable.Rows[index]["HomeFaxNoRF"] = GetSubString(customerWork.HomeFaxNo, 16);
            dataTable.Rows[index]["OfficeFaxNoRF"] = GetSubString(customerWork.OfficeFaxNo, 16);
            dataTable.Rows[index]["SearchTelNoRF"] = GetSubString(customerWork.SearchTelNo, 4);
            dataTable.Rows[index]["MainContactCodeRF"] = customerWork.MainContactCode;

            dataTable.Rows[index]["Note1RF"] = GetSubString(customerWork.Note1, 20);
            dataTable.Rows[index]["Note2RF"] = GetSubString(customerWork.Note2, 20);
            dataTable.Rows[index]["Note3RF"] = GetSubString(customerWork.Note3, 20);
            dataTable.Rows[index]["Note4RF"] = GetSubString(customerWork.Note4, 20);
            dataTable.Rows[index]["Note5RF"] = GetSubString(customerWork.Note5, 20);
            dataTable.Rows[index]["Note6RF"] = GetSubString(customerWork.Note6, 20);
            dataTable.Rows[index]["Note7RF"] = GetSubString(customerWork.Note7, 20);
            dataTable.Rows[index]["Note8RF"] = GetSubString(customerWork.Note8, 20);
            dataTable.Rows[index]["Note9RF"] = GetSubString(customerWork.Note9, 20);
            dataTable.Rows[index]["Note10RF"] = GetSubString(customerWork.Note10, 20);
            dataTable.Rows[index]["MainSendMailAddrCdRF"] = GetSubString(customerWork.MainSendMailAddrCd.ToString(), 64);
            dataTable.Rows[index]["MailAddress1RF"] = GetSubString(customerWork.MailAddress1, 64);
            dataTable.Rows[index]["MailSendCode1RF"] = customerWork.MailSendCode1.ToString();
            dataTable.Rows[index]["MailAddrKindCode1RF"] = customerWork.MailAddrKindCode1.ToString();
            dataTable.Rows[index]["MailAddress2RF"] = GetSubString(customerWork.MailAddress2, 64);
            dataTable.Rows[index]["MailSendCode2RF"] = customerWork.MailSendCode2.ToString();
            dataTable.Rows[index]["MailAddrKindCode2RF"] = customerWork.MailAddrKindCode2.ToString();


            dataTable.Rows[index]["AccountNoInfo1RF"] = GetSubString(customerWork.AccountNoInfo1, 60);
            dataTable.Rows[index]["AccountNoInfo2RF"] = GetSubString(customerWork.AccountNoInfo2, 60);
            dataTable.Rows[index]["AccountNoInfo3RF"] = GetSubString(customerWork.AccountNoInfo3, 60);
            dataTable.Rows[index]["ReceiptOutputCodeRF"] = customerWork.ReceiptOutputCode.ToString();
            dataTable.Rows[index]["DmOutCodeRF"] = customerWork.DmOutCode.ToString();
            dataTable.Rows[index]["SalesSlipPrtDivRF"] = customerWork.SalesSlipPrtDiv.ToString();
            dataTable.Rows[index]["AcpOdrrSlipPrtDivRF"] = customerWork.AcpOdrrSlipPrtDiv.ToString();
            dataTable.Rows[index]["ShipmSlipPrtDivRF"] = customerWork.ShipmSlipPrtDiv.ToString();
            dataTable.Rows[index]["EstimatePrtDivRF"] = customerWork.EstimatePrtDiv.ToString();
            dataTable.Rows[index]["UOESlipPrtDivRF"] = customerWork.UOESlipPrtDiv.ToString();
            dataTable.Rows[index]["QrcodePrtCdRF"] = customerWork.QrcodePrtCd.ToString();
            dataTable.Rows[index]["CustSlipNoMngCdRF"] = customerWork.CustSlipNoMngCd.ToString();
            dataTable.Rows[index]["CustomerSlipNoDivRF"] = customerWork.CustomerSlipNoDiv.ToString();

            dataTable.Rows[index]["TotalBillOutputDivRF"] = customerWork.TotalBillOutputDiv.ToString();   // ���v�������o�͋敪
            dataTable.Rows[index]["DetailBillOutputCodeRF"] = customerWork.DetailBillOutputCode.ToString(); // ���א������o�͋敪
            dataTable.Rows[index]["SlipTtlBillOutputDivRF"] = customerWork.SlipTtlBillOutputDiv.ToString(); // �`�[���v�������o�͋敪

            if (customerWork.CustRateGrpCode != -1 && !string.IsNullOrEmpty(customerWork.CustRateGrpCode.ToString().Trim()))
            {
                if (customerWork.RateGPureCode == 1)
                {
                    //dataTable.Rows[index]["CustRateGrpFine"] = customerWork.CustRateGrpCode.ToString("0000");// DEL  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
                    dataTable.Rows[index]["CustRateGrpFineAll"] = customerWork.CustRateGrpCode.ToString("0000");// ADD  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
                }
                else
                {

                    switch (customerWork.GoodsMakerCd)
                    {
                        case 0:
                            dataTable.Rows[index]["CustRateGrpPureAll"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 1:
                            dataTable.Rows[index]["CustRateGrpPure1"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 2:
                            dataTable.Rows[index]["CustRateGrpPure2"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 3:
                            dataTable.Rows[index]["CustRateGrpPure3"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 4:
                            dataTable.Rows[index]["CustRateGrpPure4"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 5:
                            dataTable.Rows[index]["CustRateGrpPure5"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 6:
                            dataTable.Rows[index]["CustRateGrpPure6"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 7:
                            dataTable.Rows[index]["CustRateGrpPure7"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 8:
                            dataTable.Rows[index]["CustRateGrpPure8"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 9:
                            dataTable.Rows[index]["CustRateGrpPure9"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 10:
                            dataTable.Rows[index]["CustRateGrpPure10"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 11:
                            dataTable.Rows[index]["CustRateGrpPure11"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 12:
                            dataTable.Rows[index]["CustRateGrpPure12"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 13:
                            dataTable.Rows[index]["CustRateGrpPure13"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 14:
                            dataTable.Rows[index]["CustRateGrpPure14"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 15:
                            dataTable.Rows[index]["CustRateGrpPure15"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 16:
                            dataTable.Rows[index]["CustRateGrpPure16"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 17:
                            dataTable.Rows[index]["CustRateGrpPure17"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 18:
                            dataTable.Rows[index]["CustRateGrpPure18"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 19:
                            dataTable.Rows[index]["CustRateGrpPure19"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 20:
                            dataTable.Rows[index]["CustRateGrpPure20"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 21:
                            dataTable.Rows[index]["CustRateGrpPure21"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 22:
                            dataTable.Rows[index]["CustRateGrpPure22"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 23:
                            dataTable.Rows[index]["CustRateGrpPure23"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 24:
                            dataTable.Rows[index]["CustRateGrpPure24"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 25:
                            dataTable.Rows[index]["CustRateGrpPure25"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                    }
                }
            }
            else 
            {
                if (customerWork.RateGPureCode == 1)
                {
                    //dataTable.Rows[index]["CustRateGrpFine"] = customerWork.CustRateGrpCode.ToString();// DEL  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
                    dataTable.Rows[index]["CustRateGrpFineAll"] = customerWork.CustRateGrpCode.ToString();// ADD  2012/07/09  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.46�̑Ή�
                }
                else
                {
                    switch (customerWork.GoodsMakerCd)
                    {
                        case 0:
                            dataTable.Rows[index]["CustRateGrpPureAll"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 1:
                            dataTable.Rows[index]["CustRateGrpPure1"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 2:
                            dataTable.Rows[index]["CustRateGrpPure2"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 3:
                            dataTable.Rows[index]["CustRateGrpPure3"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 4:
                            dataTable.Rows[index]["CustRateGrpPure4"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 5:
                            dataTable.Rows[index]["CustRateGrpPure5"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 6:
                            dataTable.Rows[index]["CustRateGrpPure6"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 7:
                            dataTable.Rows[index]["CustRateGrpPure7"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 8:
                            dataTable.Rows[index]["CustRateGrpPure8"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 9:
                            dataTable.Rows[index]["CustRateGrpPure9"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 10:
                            dataTable.Rows[index]["CustRateGrpPure10"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 11:
                            dataTable.Rows[index]["CustRateGrpPure11"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 12:
                            dataTable.Rows[index]["CustRateGrpPure12"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 13:
                            dataTable.Rows[index]["CustRateGrpPure13"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 14:
                            dataTable.Rows[index]["CustRateGrpPure14"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 15:
                            dataTable.Rows[index]["CustRateGrpPure15"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 16:
                            dataTable.Rows[index]["CustRateGrpPure16"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 17:
                            dataTable.Rows[index]["CustRateGrpPure17"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 18:
                            dataTable.Rows[index]["CustRateGrpPure18"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 19:
                            dataTable.Rows[index]["CustRateGrpPure19"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 20:
                            dataTable.Rows[index]["CustRateGrpPure20"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 21:
                            dataTable.Rows[index]["CustRateGrpPure21"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 22:
                            dataTable.Rows[index]["CustRateGrpPure22"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 23:
                            dataTable.Rows[index]["CustRateGrpPure23"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 24:
                            dataTable.Rows[index]["CustRateGrpPure24"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 25:
                            dataTable.Rows[index]["CustRateGrpPure25"] = customerWork.CustRateGrpCode.ToString();
                            break;
                    }
                }
            }
            // ------ DEL START 2012/07/09 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.46�̑Ή�-------->>>>
            //if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpFine"].ToString()))
            //{
            //    dataTable.Rows[index]["CustRateGrpFine"] = "-1";
            //}
            // ------ DEL END 2012/07/09 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.46�̑Ή�--------<<<<
            // ------ ADD START 2012/07/09 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.46�̑Ή�-------->>>>
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpFineAll"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpFineAll"] = "-1";
            }
            // ------ ADD END 2012/07/09 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.46�̑Ή�--------<<<<
            
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPureAll"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPureAll"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure1"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure1"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure2"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure2"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure3"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure3"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure4"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure4"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure5"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure5"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure6"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure6"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure7"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure7"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure8"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure8"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure9"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure9"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure10"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure10"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure11"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure11"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure12"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure12"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure13"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure13"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure14"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure14"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure15"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure15"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure16"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure16"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure17"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure17"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure18"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure18"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure19"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure19"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure20"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure20"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure21"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure21"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure22"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure22"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure23"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure23"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure24"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure24"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure25"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure25"] = "-1";
            }
            // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">��</param>
        /// <remarks>
        /// <br>Note       : AppendZero�s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendZero(string bfString, int maxSize)
        {
            bfString = bfString.Trim();

            StringBuilder tempBuild = new StringBuilder();
            if (bfString != "0")
            {
                if (!String.IsNullOrEmpty(bfString.Trim()) && !bfString.Trim().Equals("0"))
                {
                    for (int i = bfString.Length; i < maxSize; i++)
                    {
                        tempBuild.Append("0");
                    }
                    tempBuild.Append(bfString);
                }
            }
            else
            {
                tempBuild.Append("0");
            }
            return tempBuild.ToString().Trim();
        }

        /// <summary>
        /// GetSubString
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="length">��</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataSet�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetSubString(string bfString, int length)
        {
            bfString = bfString.Trim();
            string afString = "";
            if (bfString.Length > length)
            {
                afString = bfString.Substring(0, length);
            }
            else
            {
                afString = bfString;
            }
            return afString.Trim();
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">��</param>
        /// <remarks>
        /// <br>Note       : AppendZero�s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendStrZero(string bfString, int maxSize)
        {
            StringBuilder tempBuild = new StringBuilder();
            if (String.IsNullOrEmpty(bfString.Trim()) || bfString.Trim().Length == 0)
            {
                for (int i = 0; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
            }
            else
            {
                for (int i = bfString.Length; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
                tempBuild.Append(bfString);
            }
            return tempBuild.ToString().Trim();
        }
        #endregion
    }
}
