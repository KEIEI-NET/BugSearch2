//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���Ӑ�ꊇ�C��
// �v���O�����T�v   �F���Ӑ�̕ύX���ꊇ�ōs��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E �K�j
// �C����    2008/11/27     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/07     �C�����e�FMantis�y13030�z�̎����o�͋敪�̒ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/10     �C�����e�FMantis�y9494�z���Ӑ�}�X�^��Write()�ōX�V����悤�ɏC��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30434 �H��
// �C����    2010/01/29     �C�����e�FMantis�y14950�z�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30434 �H��
// �C����    2010/02/24     �C�����e�FMantis�y15033�z�`�[����敪�~5��ǉ�
// ---------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���Ӑ�ꊇ�C���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���Ӑ�ꊇ�C���A�N�Z�X�N���X</br>
    /// <br>Programmer  : 30414 �E �K�j</br>
    /// <br>Date        : 2008/11/20</br>
    /// </remarks>
    public class CustomerCustomerChangeAcs
    {
        #region �� Private Members

        private ICustomerCustomerChangeDB _iCustomerCustomerChangeDB;

        private ICustomerInfoDB _iCustomerInfoDB;   // ADD 2009/04/10

        #endregion �� Private Members


        # region �� Constractor
        /// <summary>
        /// ���Ӑ�ꊇ�C���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ꊇ�C���̃A�N�Z�X�N���X�̃R���X�g���N�^�ł��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public CustomerCustomerChangeAcs()
        {
            this._iCustomerCustomerChangeDB = (ICustomerCustomerChangeDB)MediationCustomerCustomerChangeDB.GetCustomerCustomerChangeDB();
            this._iCustomerInfoDB = (ICustomerInfoDB)MediationCustomerInfoDB.GetCustomerInfoDB();
        }
        # endregion �� Constractor


        #region �� Public Methods
        /// <summary>
        /// �X�V����
        /// </summary>
        /// <param name="customerCustomerChangeList">���Ӑ�ꊇ�C�����X�g</param>
        /// <remarks>
        /// <br>Note       : �X�V�������s���܂��B<br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public int Write(ref ArrayList customerCustomerChangeList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();

                foreach (CustomerCustomerChangeResult para in customerCustomerChangeList)
                {
                    // �N���X�����o�R�s�[����
                    //workList.Add(CopyToCustomerCustomerChangeResultWorkFromCustomerCustomerChangeResult(para));   // DEL 2009/04/10
                    workList.Add(CopyToCustomerWorkFromCustomerCustomerChangeResult(para));                         // ADD 2009/04/10
                }

                object paraObj = workList;
                ArrayList duplicationItemList;

                // �X�V
                //status = this._iCustomerCustomerChangeDB.Write(ref paraObj);                  // DEL 2009/04/10
                status = this._iCustomerInfoDB.Write(ref paraObj, out duplicationItemList);     // ADD 2009/04/10
                if (status == 0)
                {
                    customerCustomerChangeList = new ArrayList();
                    workList = paraObj as ArrayList;

                    //foreach (CustomerCustomerChangeResultWork retWork in workList)    // DEL 2009/04/10
                    foreach (CustomerWork retWork in workList)                          // ADD 2009/04/10
                    {
                        // �N���X�����o�R�s�[����
                        //customerCustomerChangeList.Add(CopyToCustomerCustomerChangeResultFromCustomerCustomerChangeResultWork(retWork));      // DEL 2009/04/10
                        customerCustomerChangeList.Add(CopyToCustomerCustomerChangeResultFromCustomerWork(retWork));                            // ADD 2009/04/10
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="customerCustomerChangeList">���Ӑ�ꊇ�C�����X�g</param>
        /// <param name="para">���Ӑ�ꊇ�C�����X�g��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B<br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public int Search(out List<CustomerCustomerChangeResult> customerCustomerChangeList, CustomerCustomerChangeParam para, ConstantManagement.LogicalMode logicalMode)
        {
            customerCustomerChangeList = new List<CustomerCustomerChangeResult>();

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // �N���X�����o�R�s�[����
                CustomerCustomerChangeParamWork paraWork = CopyToCustomerCustomerChangeParamWorkFromCustomerCustomerChangeParam(para);

                object paraObj = paraWork;
                ArrayList retList = new ArrayList();
                object retObj = retList;

                // ����
                status = this._iCustomerCustomerChangeDB.Search(ref retObj, paraObj, 0, logicalMode);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    
                    foreach (CustomerCustomerChangeResultWork retWork in retList)
                    {
                        // �N���X�����o�R�s�[����
                        customerCustomerChangeList.Add(CopyToCustomerCustomerChangeResultFromCustomerCustomerChangeResultWork(retWork));
                    }

                    // ���Ӑ�R�[�h���Ƀ\�[�g
                    customerCustomerChangeList.Sort(delegate(CustomerCustomerChangeResult x, CustomerCustomerChangeResult y)
                    {
                        if (x.CustomerCode > y.CustomerCode)
                        {
                            return 1;
                        }
                        else if (x.CustomerCode < y.CustomerCode)
                        {
                            return -1;
                        }
                        else
                        {
                            return 0;
                        }
                        
                    });
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }
        #endregion ��Public Methods


        #region �� Private Methods
        /// <summary>
        /// �N���X�����o�R�s�[����(E��D)
        /// </summary>
        /// <param name="para">���Ӑ�ꊇ�C�����o�����N���X</param>
        /// <returns>���Ӑ�ꊇ�C�����o�������[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private CustomerCustomerChangeParamWork CopyToCustomerCustomerChangeParamWorkFromCustomerCustomerChangeParam(CustomerCustomerChangeParam para)
        {
            CustomerCustomerChangeParamWork paraWork = new CustomerCustomerChangeParamWork();

            paraWork.EnterpriseCode = para.EnterpriseCode;          // ��ƃR�[�h
            paraWork.StMngSectionCode = para.StMngSectionCode;      // �J�n�Ǘ����_�R�[�h
            paraWork.EdMngSectionCode = para.EdMngSectionCode;      // �I���Ǘ����_�R�[�h
            paraWork.StCustomerCode = para.StCustomerCode;          // �J�n���Ӑ�
            paraWork.EdCustomerCode = para.EdCustomerCode;          // �I�����Ӑ�
            paraWork.StKana = para.StKana;                          // �J�n�J�i
            paraWork.EdKana = para.EdKana;                          // �I���J�i
            paraWork.StCustomerAgentCd = para.StCustomerAgentCd;    // �J�n�ڋq�S���]�ƈ��R�[�h
            paraWork.EdCustomerAgentCd = para.EdCustomerAgentCd;    // �I���ڋq�S���]�ƈ��R�[�h
            paraWork.StSalesAreaCode = para.StSalesAreaCode;        // �J�n�̔��G���A�R�[�h
            paraWork.EdSalesAreaCode = para.EdSalesAreaCode;        // �I���̔��G���A�R�[�h
            paraWork.StBusinessTypeCode = para.StBusinessTypeCode;  // �J�n�Ǝ�R�[�h
            paraWork.EdBusinessTypeCode = para.EdBusinessTypeCode;  // �I���Ǝ�R�[�h
            paraWork.SearchDiv = para.SearchDiv;                    // �����敪

            return paraWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="retWork">���Ӑ�ꊇ�C�����o�������[�N�N���X</param>
        /// <returns>���Ӑ�ꊇ�C�����o�����N���X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private CustomerCustomerChangeResult CopyToCustomerCustomerChangeResultFromCustomerCustomerChangeResultWork(CustomerCustomerChangeResultWork retWork)
        {
            CustomerCustomerChangeResult ret = new CustomerCustomerChangeResult();

            ret.CreateDateTime = retWork.CreateDateTime;                // �쐬����
            ret.UpdateDateTime = retWork.UpdateDateTime;                // �X�V����
            ret.EnterpriseCode = retWork.EnterpriseCode;                // ��ƃR�[�h
            ret.FileHeaderGuid = retWork.FileHeaderGuid;                // GUID
            ret.UpdEmployeeCode = retWork.UpdEmployeeCode;              // �X�V�]�ƈ��R�[�h
            ret.UpdAssemblyId1 = retWork.UpdAssemblyId1;                // �X�V�A�Z���u��ID1
            ret.UpdAssemblyId2 = retWork.UpdAssemblyId2;                // �X�V�A�Z���u��ID2
            ret.LogicalDeleteCode = retWork.LogicalDeleteCode;          // �_���폜�敪
            ret.CustomerCode = retWork.CustomerCode;                    // ���Ӑ�R�[�h
            ret.CustomerSubCode = retWork.CustomerSubCode;              // ���Ӑ�T�u�R�[�h
            ret.Name = retWork.Name;                                    // ����
            ret.Name2 = retWork.Name2;                                  // ����2
            ret.HonorificTitle = retWork.HonorificTitle;                // �h��
            ret.Kana = retWork.Kana;                                    // �J�i
            ret.CustomerSnm = retWork.CustomerSnm;                      // ���Ӑ旪��
            ret.OutputNameCode = retWork.OutputNameCode;                // �����R�[�h
            ret.OutputName = retWork.OutputName;                        // ��������
            ret.CorporateDivCode = retWork.CorporateDivCode;            // �l�E�@�l�敪
            ret.CustomerAttributeDiv = retWork.CustomerAttributeDiv;    // ���Ӑ摮���敪
            ret.JobTypeCode = retWork.JobTypeCode;                      // �E��R�[�h
            ret.JobTypeName = retWork.JobTypeName;                      // �E�햼��
            ret.BusinessTypeCode = retWork.BusinessTypeCode;            // �Ǝ�R�[�h
            ret.BusinessTypeName = retWork.BusinessTypeName;            // �Ǝ햼��
            ret.SalesAreaCode = retWork.SalesAreaCode;                  // �̔��G���A�R�[�h
            ret.SalesAreaName = retWork.SalesAreaName;                  // �̔��G���A����
            ret.PostNo = retWork.PostNo;                                // �X�֔ԍ�
            ret.Address1 = retWork.Address1;                            // �Z��1�i�s���{���s��S�E�����E���j
            ret.Address3 = retWork.Address3;                            // �Z��3�i�Ԓn�j
            ret.Address4 = retWork.Address4;                            // �Z��4�i�A�p�[�g���́j
            ret.HomeTelNo = retWork.HomeTelNo;                          // �d�b�ԍ��i����j
            ret.OfficeTelNo = retWork.OfficeTelNo;                      // �d�b�ԍ��i�Ζ���j
            ret.PortableTelNo = retWork.PortableTelNo;                  // �d�b�ԍ��i�g�сj
            ret.HomeFaxNo = retWork.HomeFaxNo;                          // FAX�ԍ��i����j
            ret.OfficeFaxNo = retWork.OfficeFaxNo;                      // FAX�ԍ��i�Ζ���j
            ret.OthersTelNo = retWork.OthersTelNo;                      // �d�b�ԍ��i���̑��j
            ret.MainContactCode = retWork.MainContactCode;              // ��A����敪
            ret.SearchTelNo = retWork.SearchTelNo.Trim();               // �d�b�ԍ��i�����p��4���j
            ret.MngSectionCode = retWork.MngSectionCode.Trim();         // �Ǘ����_�R�[�h
            ret.MngSectionName = retWork.MngSectionName;                // �Ǘ����_����
            ret.InpSectionCode = retWork.InpSectionCode.Trim();         // ���͋��_�R�[�h
            ret.CustAnalysCode1 = retWork.CustAnalysCode1;              // ���Ӑ敪�̓R�[�h1
            ret.CustAnalysCode2 = retWork.CustAnalysCode2;              // ���Ӑ敪�̓R�[�h2
            ret.CustAnalysCode3 = retWork.CustAnalysCode3;              // ���Ӑ敪�̓R�[�h3
            ret.CustAnalysCode4 = retWork.CustAnalysCode4;              // ���Ӑ敪�̓R�[�h4
            ret.CustAnalysCode5 = retWork.CustAnalysCode5;              // ���Ӑ敪�̓R�[�h5
            ret.CustAnalysCode6 = retWork.CustAnalysCode6;              // ���Ӑ敪�̓R�[�h6
            ret.BillOutputCode = retWork.BillOutputCode;                // �������o�͋敪�R�[�h
            ret.BillOutputName = retWork.BillOutputName;                // �������o�͋敪����
            ret.TotalDay = retWork.TotalDay;                            // ����
            ret.CollectMoneyCode = retWork.CollectMoneyCode;            // �W�����敪�R�[�h
            ret.CollectMoneyName = retWork.CollectMoneyName;            // �W�����敪����
            ret.CollectMoneyDay = retWork.CollectMoneyDay;              // �W����
            ret.CollectCond = retWork.CollectCond;                      // �������
            ret.CollectSight = retWork.CollectSight;                    // ����T�C�g
            ret.ClaimCode = retWork.ClaimCode;                          // ������R�[�h
            ret.ClaimName = retWork.ClaimName;                          // �����於��
            ret.ClaimName2 = retWork.ClaimName2;                        // �����於��2
            ret.ClaimSnm = retWork.ClaimSnm;                            // �����旪��
            ret.TransStopDate = retWork.TransStopDate;                  // ������~��
            ret.DmOutCode = retWork.DmOutCode;                          // DM�o�͋敪
            ret.DmOutName = retWork.DmOutName;                          // DM�o�͋敪����
            ret.MainSendMailAddrCd = retWork.MainSendMailAddrCd;        // �呗�M�惁�[���A�h���X�敪
            ret.MailAddrKindCode1 = retWork.MailAddrKindCode1;          // ���[���A�h���X��ʃR�[�h1
            ret.MailAddrKindName1 = retWork.MailAddrKindName1;          // ���[���A�h���X��ʖ���1
            ret.MailAddress1 = retWork.MailAddress1;                    // ���[���A�h���X1
            ret.MailSendCode1 = retWork.MailSendCode1;                  // ���[�����M�敪�R�[�h1
            ret.MailSendName1 = retWork.MailSendName1;                  // ���[�����M�敪����1
            ret.MailAddrKindCode2 = retWork.MailAddrKindCode2;          // ���[���A�h���X��ʃR�[�h2
            ret.MailAddrKindName2 = retWork.MailAddrKindName2;          // ���[���A�h���X��ʖ���2
            ret.MailAddress2 = retWork.MailAddress2;                    // ���[���A�h���X2
            ret.MailSendCode2 = retWork.MailSendCode2;                  // ���[�����M�敪�R�[�h2
            ret.MailSendName2 = retWork.MailSendName2;                  // ���[�����M�敪����2
            ret.CustomerAgentCd = retWork.CustomerAgentCd.Trim();       // �ڋq�S���]�ƈ��R�[�h
            ret.CustomerAgentNm = retWork.CustomerAgentNm;              // �ڋq�S���]�ƈ�����
            ret.BillCollecterCd = retWork.BillCollecterCd.Trim();       // �W���S���]�ƈ��R�[�h
            ret.OldCustomerAgentCd = retWork.OldCustomerAgentCd.Trim(); // ���ڋq�S���]�ƈ��R�[�h
            ret.OldCustomerAgentNm = retWork.OldCustomerAgentNm;        // ���ڋq�S���]�ƈ�����
            ret.CustAgentChgDate = retWork.CustAgentChgDate;            // �ڋq�S���ύX��
            ret.AcceptWholeSale = retWork.AcceptWholeSale;              // �Ɣ̐�敪
            ret.CreditMngCode = retWork.CreditMngCode;                  // �^�M�Ǘ��敪
            ret.DepoDelCode = retWork.DepoDelCode;                      // ���������敪
            ret.AccRecDivCd = retWork.AccRecDivCd;                      // ���|�敪
            ret.CustSlipNoMngCd = retWork.CustSlipNoMngCd;              // ����`�[�ԍ��Ǘ��敪
            ret.PureCode = retWork.PureCode;                            // �����敪
            ret.CustCTaXLayRefCd = retWork.CustCTaXLayRefCd;            // ���Ӑ����œ]�ŕ����Q�Ƌ敪
            ret.ConsTaxLayMethod = retWork.ConsTaxLayMethod;            // ����œ]�ŕ���
            ret.TotalAmountDispWayCd = retWork.TotalAmountDispWayCd;    // ���z�\�����@�敪
            ret.TotalAmntDspWayRef = retWork.TotalAmntDspWayRef;        // ���z�\�����@�Q�Ƌ敪
            ret.AccountNoInfo1 = retWork.AccountNoInfo1;                // ��s����1
            ret.AccountNoInfo2 = retWork.AccountNoInfo2;                // ��s����2
            ret.AccountNoInfo3 = retWork.AccountNoInfo3;                // ��s����3
            ret.SalesUnPrcFrcProcCd = retWork.SalesUnPrcFrcProcCd;      // ����P���[�������R�[�h
            ret.SalesMoneyFrcProcCd = retWork.SalesMoneyFrcProcCd;      // ������z�[�������R�[�h
            ret.SalesCnsTaxFrcProcCd = retWork.SalesCnsTaxFrcProcCd;    // �������Œ[�������R�[�h
            ret.CustomerSlipNoDiv = retWork.CustomerSlipNoDiv;          // ���Ӑ�`�[�ԍ��敪
            ret.NTimeCalcStDate = retWork.NTimeCalcStDate;              // ���񊨒�J�n��
            ret.CustomerAgent = retWork.CustomerAgent;                  // ���Ӑ�S����
            ret.ClaimSectionCode = retWork.ClaimSectionCode.Trim();     // �������_�R�[�h
            ret.ClaimSectionName = retWork.ClaimSectionName;            // �������_����
            ret.CarMngDivCd = retWork.CarMngDivCd;                      // ���q�Ǘ��敪
            ret.BillPartsNoPrtCd = retWork.BillPartsNoPrtCd;            // �i�Ԉ󎚋敪(������)
            ret.DeliPartsNoPrtCd = retWork.DeliPartsNoPrtCd;            // �i�Ԉ󎚋敪(�[�i���j
            ret.DefSalesSlipCd = retWork.DefSalesSlipCd;                // �`�[�敪�����l
            ret.LavorRateRank = retWork.LavorRateRank;                  // �H�����o���[�g�����N
            ret.SlipTtlPrn = retWork.SlipTtlPrn;                        // �`�[�^�C�g���p�^�[��
            ret.DepoBankCode = retWork.DepoBankCode;                    // ������s�R�[�h
            ret.DepoBankName = retWork.DepoBankName;                    // ������s����
            ret.CustWarehouseCd = retWork.CustWarehouseCd.Trim();       // ���Ӑ�D��q�ɃR�[�h
            ret.CustWarehouseName = retWork.CustWarehouseName;          // ���Ӑ�D��q�ɖ���
            ret.QrcodePrtCd = retWork.QrcodePrtCd;                      // QR�R�[�h���
            ret.DeliHonorificTtl = retWork.DeliHonorificTtl;            // �[�i���h��
            ret.BillHonorificTtl = retWork.BillHonorificTtl;            // �������h��
            ret.EstmHonorificTtl = retWork.EstmHonorificTtl;            // ���Ϗ��h��
            ret.RectHonorificTtl = retWork.RectHonorificTtl;            // �̎����h��
            ret.DeliHonorTtlPrtDiv = retWork.DeliHonorTtlPrtDiv;        // �[�i���h�̈󎚋敪
            ret.BillHonorTtlPrtDiv = retWork.BillHonorTtlPrtDiv;        // �������h�̈󎚋敪
            ret.EstmHonorTtlPrtDiv = retWork.EstmHonorTtlPrtDiv;        // ���Ϗ��h�̈󎚋敪
            ret.RectHonorTtlPrtDiv = retWork.RectHonorTtlPrtDiv;        // �̎����h�̈󎚋敪
            ret.Note1 = retWork.Note1;                                  // ���l1
            ret.Note2 = retWork.Note2;                                  // ���l2
            ret.Note3 = retWork.Note3;                                  // ���l3
            ret.Note4 = retWork.Note4;                                  // ���l4
            ret.Note5 = retWork.Note5;                                  // ���l5
            ret.Note6 = retWork.Note6;                                  // ���l6
            ret.Note7 = retWork.Note7;                                  // ���l7
            ret.Note8 = retWork.Note8;                                  // ���l8
            ret.Note9 = retWork.Note9;                                  // ���l9
            ret.Note10 = retWork.Note10;                                // ���l10
            ret.CreditMoney = retWork.CreditMoney;                      // �^�M�z[�ϓ����]
            ret.WarningCreditMoney = retWork.WarningCreditMoney;        // �x���^�M�z[�ϓ����]
            ret.PrsntAccRecBalance = retWork.PrsntAccRecBalance;        // ���ݔ��|�c��[�ϓ����]
            ret.RateGPureCode = retWork.RateGPureCode;                  // �����敪[�|��]
            ret.GoodsMakerCd = retWork.GoodsMakerCd;                    // ���i���[�J�[�R�[�h[�|��]
            ret.CustRateGrpCode = retWork.CustRateGrpCode;              // ���Ӑ�|���O���[�v�R�[�h[�|��]
            //ret.EnterpriseName = retWork.EnterpriseName;
            //ret.UpdEmployeeName = retWork.UpdEmployeeName;
            //ret.InpSectionName = retWork.InpSectionName;
            //ret.BillOutPutCodeNm = retWork.BillOutPutCodeNm;
            //ret.BillCollecterNm = retWork.BillCollecterNm;

            // ADD 2009/04/07 ------>>>
            ret.ReceiptOutputCode = retWork.ReceiptOutputCode;          // �̎����o�͋敪�R�[�h
            // ADD 2009/04/07 ------<<<

            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ---------->>>>>
            ret.SalesSlipPrtDiv = retWork.SalesSlipPrtDiv;      // �[�i���o�́i����`�[���s�敪�j
            ret.AcpOdrrSlipPrtDiv = retWork.AcpOdrrSlipPrtDiv;  // �󒍓`�[�o�́i�󒍓`�[���s�敪�j
            ret.ShipmSlipPrtDiv = retWork.ShipmSlipPrtDiv;      // �ݏo�`�[�o�́i�o�ד`�[���s�敪�j
            ret.EstimatePrtDiv = retWork.EstimatePrtDiv;        // ���ϓ`�[�o�́i���ϓ`�[���s�敪�j
            ret.UOESlipPrtDiv = retWork.UOESlipPrtDiv;          // UOE�`�[�o�́iUOE�`�[���s�敪�j
            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ----------<<<<<

            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            ret.TotalBillOutputDiv = retWork.TotalBillOutputDiv;    // ���v�������o�͋敪
            ret.DetailBillOutputCode = retWork.DetailBillOutputCode;// ���א������o�͋敪
            ret.SlipTtlBillOutputDiv = retWork.SlipTtlBillOutputDiv;// �`�[���v�������o�͋敪
            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

            return ret;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(E��D)
        /// </summary>
        /// <param name="retWork">���Ӑ�ꊇ�C�����o�������[�N�N���X</param>
        /// <returns>���Ӑ�ꊇ�C�����o�����N���X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private CustomerCustomerChangeResultWork CopyToCustomerCustomerChangeResultWorkFromCustomerCustomerChangeResult(CustomerCustomerChangeResult ret)
        {
            CustomerCustomerChangeResultWork retWork = new CustomerCustomerChangeResultWork();

            retWork.CreateDateTime = ret.CreateDateTime;                // �쐬����
            retWork.UpdateDateTime = ret.UpdateDateTime;                // �X�V����
            retWork.EnterpriseCode = ret.EnterpriseCode;                // ��ƃR�[�h
            retWork.FileHeaderGuid = ret.FileHeaderGuid;                // GUID
            retWork.UpdEmployeeCode = ret.UpdEmployeeCode;              // �X�V�]�ƈ��R�[�h
            retWork.UpdAssemblyId1 = ret.UpdAssemblyId1;                // �X�V�A�Z���u��ID1
            retWork.UpdAssemblyId2 = ret.UpdAssemblyId2;                // �X�V�A�Z���u��ID2
            retWork.LogicalDeleteCode = ret.LogicalDeleteCode;          // �_���폜�敪
            retWork.CustomerCode = ret.CustomerCode;                    // ���Ӑ�R�[�h
            retWork.CustomerSubCode = ret.CustomerSubCode;              // ���Ӑ�T�u�R�[�h
            retWork.Name = ret.Name;                                    // ����
            retWork.Name2 = ret.Name2;                                  // ����2
            retWork.HonorificTitle = ret.HonorificTitle;                // �h��
            retWork.Kana = ret.Kana;                                    // �J�i
            retWork.CustomerSnm = ret.CustomerSnm;                      // ���Ӑ旪��
            retWork.OutputNameCode = ret.OutputNameCode;                // �����R�[�h
            retWork.OutputName = ret.OutputName;                        // ��������
            retWork.CorporateDivCode = ret.CorporateDivCode;            // �l�E�@�l�敪
            retWork.CustomerAttributeDiv = ret.CustomerAttributeDiv;    // ���Ӑ摮���敪
            retWork.JobTypeCode = ret.JobTypeCode;                      // �E��R�[�h
            retWork.JobTypeName = ret.JobTypeName;                      // �E�햼��
            retWork.BusinessTypeCode = ret.BusinessTypeCode;            // �Ǝ�R�[�h
            retWork.BusinessTypeName = ret.BusinessTypeName;            // �Ǝ햼��
            retWork.SalesAreaCode = ret.SalesAreaCode;                  // �̔��G���A�R�[�h
            retWork.SalesAreaName = ret.SalesAreaName;                  // �̔��G���A����
            retWork.PostNo = ret.PostNo;                                // �X�֔ԍ�
            retWork.Address1 = ret.Address1;                            // �Z��1�i�s���{���s��S�E�����E���j
            retWork.Address3 = ret.Address3;                            // �Z��3�i�Ԓn�j
            retWork.Address4 = ret.Address4;                            // �Z��4�i�A�p�[�g���́j
            retWork.HomeTelNo = ret.HomeTelNo;                          // �d�b�ԍ��i����j
            retWork.OfficeTelNo = ret.OfficeTelNo;                      // �d�b�ԍ��i�Ζ���j
            retWork.PortableTelNo = ret.PortableTelNo;                  // �d�b�ԍ��i�g�сj
            retWork.HomeFaxNo = ret.HomeFaxNo;                          // FAX�ԍ��i����j
            retWork.OfficeFaxNo = ret.OfficeFaxNo;                      // FAX�ԍ��i�Ζ���j
            retWork.OthersTelNo = ret.OthersTelNo;                      // �d�b�ԍ��i���̑��j
            retWork.MainContactCode = ret.MainContactCode;              // ��A����敪
            retWork.SearchTelNo = ret.SearchTelNo;                      // �d�b�ԍ��i�����p��4���j
            retWork.MngSectionCode = ret.MngSectionCode;                // �Ǘ����_�R�[�h
            retWork.MngSectionName = ret.MngSectionName;                // �Ǘ����_����
            retWork.InpSectionCode = ret.InpSectionCode;                // ���͋��_�R�[�h
            retWork.CustAnalysCode1 = ret.CustAnalysCode1;              // ���Ӑ敪�̓R�[�h1
            retWork.CustAnalysCode2 = ret.CustAnalysCode2;              // ���Ӑ敪�̓R�[�h2
            retWork.CustAnalysCode3 = ret.CustAnalysCode3;              // ���Ӑ敪�̓R�[�h3
            retWork.CustAnalysCode4 = ret.CustAnalysCode4;              // ���Ӑ敪�̓R�[�h4
            retWork.CustAnalysCode5 = ret.CustAnalysCode5;              // ���Ӑ敪�̓R�[�h5
            retWork.CustAnalysCode6 = ret.CustAnalysCode6;              // ���Ӑ敪�̓R�[�h6
            retWork.BillOutputCode = ret.BillOutputCode;                // �������o�͋敪�R�[�h
            retWork.BillOutputName = ret.BillOutputName;                // �������o�͋敪����
            retWork.TotalDay = ret.TotalDay;                            // ����
            retWork.CollectMoneyCode = ret.CollectMoneyCode;            // �W�����敪�R�[�h
            retWork.CollectMoneyName = ret.CollectMoneyName;            // �W�����敪����
            retWork.CollectMoneyDay = ret.CollectMoneyDay;              // �W����
            retWork.CollectCond = ret.CollectCond;                      // �������
            retWork.CollectSight = ret.CollectSight;                    // ����T�C�g
            retWork.ClaimCode = ret.ClaimCode;                          // ������R�[�h
            retWork.ClaimName = ret.ClaimName;                          // �����於��
            retWork.ClaimName2 = ret.ClaimName2;                        // �����於��2
            retWork.ClaimSnm = ret.ClaimSnm;                            // �����旪��
            retWork.TransStopDate = ret.TransStopDate;                  // ������~��
            retWork.DmOutCode = ret.DmOutCode;                          // DM�o�͋敪
            retWork.DmOutName = ret.DmOutName;                          // DM�o�͋敪����
            retWork.MainSendMailAddrCd = ret.MainSendMailAddrCd;        // �呗�M�惁�[���A�h���X�敪
            retWork.MailAddrKindCode1 = ret.MailAddrKindCode1;          // ���[���A�h���X��ʃR�[�h1
            retWork.MailAddrKindName1 = ret.MailAddrKindName1;          // ���[���A�h���X��ʖ���1
            retWork.MailAddress1 = ret.MailAddress1;                    // ���[���A�h���X1
            retWork.MailSendCode1 = ret.MailSendCode1;                  // ���[�����M�敪�R�[�h1
            retWork.MailSendName1 = ret.MailSendName1;                  // ���[�����M�敪����1
            retWork.MailAddrKindCode2 = ret.MailAddrKindCode2;          // ���[���A�h���X��ʃR�[�h2
            retWork.MailAddrKindName2 = ret.MailAddrKindName2;          // ���[���A�h���X��ʖ���2
            retWork.MailAddress2 = ret.MailAddress2;                    // ���[���A�h���X2
            retWork.MailSendCode2 = ret.MailSendCode2;                  // ���[�����M�敪�R�[�h2
            retWork.MailSendName2 = ret.MailSendName2;                  // ���[�����M�敪����2
            retWork.CustomerAgentCd = ret.CustomerAgentCd;              // �ڋq�S���]�ƈ��R�[�h
            retWork.CustomerAgentNm = ret.CustomerAgentNm;              // �ڋq�S���]�ƈ�����
            retWork.BillCollecterCd = ret.BillCollecterCd;              // �W���S���]�ƈ��R�[�h
            retWork.OldCustomerAgentCd = ret.OldCustomerAgentCd;        // ���ڋq�S���]�ƈ��R�[�h
            retWork.OldCustomerAgentNm = ret.OldCustomerAgentNm;        // ���ڋq�S���]�ƈ�����
            retWork.CustAgentChgDate = ret.CustAgentChgDate;            // �ڋq�S���ύX��
            retWork.AcceptWholeSale = ret.AcceptWholeSale;              // �Ɣ̐�敪
            retWork.CreditMngCode = ret.CreditMngCode;                  // �^�M�Ǘ��敪
            retWork.DepoDelCode = ret.DepoDelCode;                      // ���������敪
            retWork.AccRecDivCd = ret.AccRecDivCd;                      // ���|�敪
            retWork.CustSlipNoMngCd = ret.CustSlipNoMngCd;              // ����`�[�ԍ��Ǘ��敪
            retWork.PureCode = ret.PureCode;                            // �����敪
            retWork.CustCTaXLayRefCd = ret.CustCTaXLayRefCd;            // ���Ӑ����œ]�ŕ����Q�Ƌ敪
            retWork.ConsTaxLayMethod = ret.ConsTaxLayMethod;            // ����œ]�ŕ���
            retWork.TotalAmountDispWayCd = ret.TotalAmountDispWayCd;    // ���z�\�����@�敪
            retWork.TotalAmntDspWayRef = ret.TotalAmntDspWayRef;        // ���z�\�����@�Q�Ƌ敪
            retWork.AccountNoInfo1 = ret.AccountNoInfo1;                // ��s����1
            retWork.AccountNoInfo2 = ret.AccountNoInfo2;                // ��s����2
            retWork.AccountNoInfo3 = ret.AccountNoInfo3;                // ��s����3
            retWork.SalesUnPrcFrcProcCd = ret.SalesUnPrcFrcProcCd;      // ����P���[�������R�[�h
            retWork.SalesMoneyFrcProcCd = ret.SalesMoneyFrcProcCd;      // ������z�[�������R�[�h
            retWork.SalesCnsTaxFrcProcCd = ret.SalesCnsTaxFrcProcCd;    // �������Œ[�������R�[�h
            retWork.CustomerSlipNoDiv = ret.CustomerSlipNoDiv;          // ���Ӑ�`�[�ԍ��敪
            retWork.NTimeCalcStDate = ret.NTimeCalcStDate;              // ���񊨒�J�n��
            retWork.CustomerAgent = ret.CustomerAgent;                  // ���Ӑ�S����
            retWork.ClaimSectionCode = ret.ClaimSectionCode;            // �������_�R�[�h
            retWork.ClaimSectionName = ret.ClaimSectionName;            // �������_����
            retWork.CarMngDivCd = ret.CarMngDivCd;                      // ���q�Ǘ��敪
            retWork.BillPartsNoPrtCd = ret.BillPartsNoPrtCd;            // �i�Ԉ󎚋敪(������)
            retWork.DeliPartsNoPrtCd = ret.DeliPartsNoPrtCd;            // �i�Ԉ󎚋敪(�[�i���j
            retWork.DefSalesSlipCd = ret.DefSalesSlipCd;                // �`�[�敪�����l
            retWork.LavorRateRank = ret.LavorRateRank;                  // �H�����o���[�g�����N
            retWork.SlipTtlPrn = ret.SlipTtlPrn;                        // �`�[�^�C�g���p�^�[��
            retWork.DepoBankCode = ret.DepoBankCode;                    // ������s�R�[�h
            retWork.DepoBankName = ret.DepoBankName;                    // ������s����
            retWork.CustWarehouseCd = ret.CustWarehouseCd;              // ���Ӑ�D��q�ɃR�[�h
            retWork.CustWarehouseName = ret.CustWarehouseName;          // ���Ӑ�D��q�ɖ���
            retWork.QrcodePrtCd = ret.QrcodePrtCd;                      // QR�R�[�h���
            retWork.DeliHonorificTtl = ret.DeliHonorificTtl;            // �[�i���h��
            retWork.BillHonorificTtl = ret.BillHonorificTtl;            // �������h��
            retWork.EstmHonorificTtl = ret.EstmHonorificTtl;            // ���Ϗ��h��
            retWork.RectHonorificTtl = ret.RectHonorificTtl;            // �̎����h��
            retWork.DeliHonorTtlPrtDiv = ret.DeliHonorTtlPrtDiv;        // �[�i���h�̈󎚋敪
            retWork.BillHonorTtlPrtDiv = ret.BillHonorTtlPrtDiv;        // �������h�̈󎚋敪
            retWork.EstmHonorTtlPrtDiv = ret.EstmHonorTtlPrtDiv;        // ���Ϗ��h�̈󎚋敪
            retWork.RectHonorTtlPrtDiv = ret.RectHonorTtlPrtDiv;        // �̎����h�̈󎚋敪
            retWork.Note1 = ret.Note1;                                  // ���l1
            retWork.Note2 = ret.Note2;                                  // ���l2
            retWork.Note3 = ret.Note3;                                  // ���l3
            retWork.Note4 = ret.Note4;                                  // ���l4
            retWork.Note5 = ret.Note5;                                  // ���l5
            retWork.Note6 = ret.Note6;                                  // ���l6
            retWork.Note7 = ret.Note7;                                  // ���l7
            retWork.Note8 = ret.Note8;                                  // ���l8
            retWork.Note9 = ret.Note9;                                  // ���l9
            retWork.Note10 = ret.Note10;                                // ���l10
            retWork.CreditMoney = ret.CreditMoney;                      // �^�M�z[�ϓ����]
            retWork.WarningCreditMoney = ret.WarningCreditMoney;        // �x���^�M�z[�ϓ����]
            retWork.PrsntAccRecBalance = ret.PrsntAccRecBalance;        // ���ݔ��|�c��[�ϓ����]
            retWork.RateGPureCode = ret.RateGPureCode;                  // �����敪[�|��]
            retWork.GoodsMakerCd = ret.GoodsMakerCd;                    // ���i���[�J�[�R�[�h[�|��]
            retWork.CustRateGrpCode = ret.CustRateGrpCode;              // ���Ӑ�|���O���[�v�R�[�h[�|��]
            //retWork.EnterpriseName = ret.EnterpriseName;
            //retWork.UpdEmployeeName = ret.UpdEmployeeName;
            //retWork.InpSectionName = ret.InpSectionName;
            //retWork.BillOutPutCodeNm = ret.BillOutPutCodeNm;
            //retWork.BillCollecterNm = ret.BillCollecterNm;

            // ADD 2009/04/07 ------>>>
            retWork.ReceiptOutputCode = ret.ReceiptOutputCode;          // �̎����o�͋敪�R�[�h
            // ADD 2009/04/07 ------<<<

            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ---------->>>>>
            retWork.SalesSlipPrtDiv = ret.SalesSlipPrtDiv;      // �[�i���o�́i����`�[���s�敪�j
            retWork.AcpOdrrSlipPrtDiv = ret.AcpOdrrSlipPrtDiv;  // �󒍓`�[�o�́i�󒍓`�[���s�敪�j
            retWork.ShipmSlipPrtDiv = ret.ShipmSlipPrtDiv;      // �ݏo�`�[�o�́i�o�ד`�[���s�敪�j
            retWork.EstimatePrtDiv = ret.EstimatePrtDiv;        // ���ϓ`�[�o�́i���ϓ`�[���s�敪�j
            retWork.UOESlipPrtDiv = ret.UOESlipPrtDiv;          // UOE�`�[�o�́iUOE�`�[���s�敪�j
            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ----------<<<<<

            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            retWork.TotalBillOutputDiv = ret.TotalBillOutputDiv;    // ���v�������o�͋敪
            retWork.DetailBillOutputCode = ret.DetailBillOutputCode;// ���א������o�͋敪
            retWork.SlipTtlBillOutputDiv = ret.SlipTtlBillOutputDiv;// �`�[���v�������o�͋敪
            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

            return retWork;
        }

        // ADD 2009/04/10 ------>>>
        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="retWork">���Ӑ�}�X�^���[�N�N���X</param>
        /// <returns>���Ӑ�ꊇ�C�����o�����N���X</returns>
        /// <remarks>
        /// </remarks>
        private CustomerCustomerChangeResult CopyToCustomerCustomerChangeResultFromCustomerWork(CustomerWork retWork)
        {
            CustomerCustomerChangeResult ret = new CustomerCustomerChangeResult();

            ret.CreateDateTime = retWork.CreateDateTime;                // �쐬����
            ret.UpdateDateTime = retWork.UpdateDateTime;                // �X�V����
            ret.EnterpriseCode = retWork.EnterpriseCode;                // ��ƃR�[�h
            ret.FileHeaderGuid = retWork.FileHeaderGuid;                // GUID
            ret.UpdEmployeeCode = retWork.UpdEmployeeCode;              // �X�V�]�ƈ��R�[�h
            ret.UpdAssemblyId1 = retWork.UpdAssemblyId1;                // �X�V�A�Z���u��ID1
            ret.UpdAssemblyId2 = retWork.UpdAssemblyId2;                // �X�V�A�Z���u��ID2
            ret.LogicalDeleteCode = retWork.LogicalDeleteCode;          // �_���폜�敪
            ret.CustomerCode = retWork.CustomerCode;                    // ���Ӑ�R�[�h
            ret.CustomerSubCode = retWork.CustomerSubCode;              // ���Ӑ�T�u�R�[�h
            ret.Name = retWork.Name;                                    // ����
            ret.Name2 = retWork.Name2;                                  // ����2
            ret.HonorificTitle = retWork.HonorificTitle;                // �h��
            ret.Kana = retWork.Kana;                                    // �J�i
            ret.CustomerSnm = retWork.CustomerSnm;                      // ���Ӑ旪��
            ret.OutputNameCode = retWork.OutputNameCode;                // �����R�[�h
            ret.OutputName = retWork.OutputName;                        // ��������
            ret.CorporateDivCode = retWork.CorporateDivCode;            // �l�E�@�l�敪
            ret.CustomerAttributeDiv = retWork.CustomerAttributeDiv;    // ���Ӑ摮���敪
            ret.JobTypeCode = retWork.JobTypeCode;                      // �E��R�[�h
            ret.JobTypeName = retWork.JobTypeName;                      // �E�햼��
            ret.BusinessTypeCode = retWork.BusinessTypeCode;            // �Ǝ�R�[�h
            ret.BusinessTypeName = retWork.BusinessTypeName;            // �Ǝ햼��
            ret.SalesAreaCode = retWork.SalesAreaCode;                  // �̔��G���A�R�[�h
            ret.SalesAreaName = retWork.SalesAreaName;                  // �̔��G���A����
            ret.PostNo = retWork.PostNo;                                // �X�֔ԍ�
            ret.Address1 = retWork.Address1;                            // �Z��1�i�s���{���s��S�E�����E���j
            ret.Address3 = retWork.Address3;                            // �Z��3�i�Ԓn�j
            ret.Address4 = retWork.Address4;                            // �Z��4�i�A�p�[�g���́j
            ret.HomeTelNo = retWork.HomeTelNo;                          // �d�b�ԍ��i����j
            ret.OfficeTelNo = retWork.OfficeTelNo;                      // �d�b�ԍ��i�Ζ���j
            ret.PortableTelNo = retWork.PortableTelNo;                  // �d�b�ԍ��i�g�сj
            ret.HomeFaxNo = retWork.HomeFaxNo;                          // FAX�ԍ��i����j
            ret.OfficeFaxNo = retWork.OfficeFaxNo;                      // FAX�ԍ��i�Ζ���j
            ret.OthersTelNo = retWork.OthersTelNo;                      // �d�b�ԍ��i���̑��j
            ret.MainContactCode = retWork.MainContactCode;              // ��A����敪
            ret.SearchTelNo = retWork.SearchTelNo.Trim();               // �d�b�ԍ��i�����p��4���j
            ret.MngSectionCode = retWork.MngSectionCode.Trim();         // �Ǘ����_�R�[�h
            ret.MngSectionName = retWork.MngSectionName;                // �Ǘ����_����
            ret.InpSectionCode = retWork.InpSectionCode.Trim();         // ���͋��_�R�[�h
            ret.CustAnalysCode1 = retWork.CustAnalysCode1;              // ���Ӑ敪�̓R�[�h1
            ret.CustAnalysCode2 = retWork.CustAnalysCode2;              // ���Ӑ敪�̓R�[�h2
            ret.CustAnalysCode3 = retWork.CustAnalysCode3;              // ���Ӑ敪�̓R�[�h3
            ret.CustAnalysCode4 = retWork.CustAnalysCode4;              // ���Ӑ敪�̓R�[�h4
            ret.CustAnalysCode5 = retWork.CustAnalysCode5;              // ���Ӑ敪�̓R�[�h5
            ret.CustAnalysCode6 = retWork.CustAnalysCode6;              // ���Ӑ敪�̓R�[�h6
            ret.BillOutputCode = retWork.BillOutputCode;                // �������o�͋敪�R�[�h
            ret.BillOutputName = retWork.BillOutputName;                // �������o�͋敪����
            ret.TotalDay = retWork.TotalDay;                            // ����
            ret.CollectMoneyCode = retWork.CollectMoneyCode;            // �W�����敪�R�[�h
            ret.CollectMoneyName = retWork.CollectMoneyName;            // �W�����敪����
            ret.CollectMoneyDay = retWork.CollectMoneyDay;              // �W����
            ret.CollectCond = retWork.CollectCond;                      // �������
            ret.CollectSight = retWork.CollectSight;                    // ����T�C�g
            ret.ClaimCode = retWork.ClaimCode;                          // ������R�[�h
            ret.ClaimName = retWork.ClaimName;                          // �����於��
            ret.ClaimName2 = retWork.ClaimName2;                        // �����於��2
            ret.ClaimSnm = retWork.ClaimSnm;                            // �����旪��
            ret.TransStopDate = retWork.TransStopDate;                  // ������~��
            ret.DmOutCode = retWork.DmOutCode;                          // DM�o�͋敪
            ret.DmOutName = retWork.DmOutName;                          // DM�o�͋敪����
            ret.MainSendMailAddrCd = retWork.MainSendMailAddrCd;        // �呗�M�惁�[���A�h���X�敪
            ret.MailAddrKindCode1 = retWork.MailAddrKindCode1;          // ���[���A�h���X��ʃR�[�h1
            ret.MailAddrKindName1 = retWork.MailAddrKindName1;          // ���[���A�h���X��ʖ���1
            ret.MailAddress1 = retWork.MailAddress1;                    // ���[���A�h���X1
            ret.MailSendCode1 = retWork.MailSendCode1;                  // ���[�����M�敪�R�[�h1
            ret.MailSendName1 = retWork.MailSendName1;                  // ���[�����M�敪����1
            ret.MailAddrKindCode2 = retWork.MailAddrKindCode2;          // ���[���A�h���X��ʃR�[�h2
            ret.MailAddrKindName2 = retWork.MailAddrKindName2;          // ���[���A�h���X��ʖ���2
            ret.MailAddress2 = retWork.MailAddress2;                    // ���[���A�h���X2
            ret.MailSendCode2 = retWork.MailSendCode2;                  // ���[�����M�敪�R�[�h2
            ret.MailSendName2 = retWork.MailSendName2;                  // ���[�����M�敪����2
            ret.CustomerAgentCd = retWork.CustomerAgentCd.Trim();       // �ڋq�S���]�ƈ��R�[�h
            ret.CustomerAgentNm = retWork.CustomerAgentNm;              // �ڋq�S���]�ƈ�����
            ret.BillCollecterCd = retWork.BillCollecterCd.Trim();       // �W���S���]�ƈ��R�[�h
            ret.OldCustomerAgentCd = retWork.OldCustomerAgentCd.Trim(); // ���ڋq�S���]�ƈ��R�[�h
            ret.OldCustomerAgentNm = retWork.OldCustomerAgentNm;        // ���ڋq�S���]�ƈ�����
            ret.CustAgentChgDate = retWork.CustAgentChgDate;            // �ڋq�S���ύX��
            ret.AcceptWholeSale = retWork.AcceptWholeSale;              // �Ɣ̐�敪
            ret.CreditMngCode = retWork.CreditMngCode;                  // �^�M�Ǘ��敪
            ret.DepoDelCode = retWork.DepoDelCode;                      // ���������敪
            ret.AccRecDivCd = retWork.AccRecDivCd;                      // ���|�敪
            ret.CustSlipNoMngCd = retWork.CustSlipNoMngCd;              // ����`�[�ԍ��Ǘ��敪
            ret.PureCode = retWork.PureCode;                            // �����敪
            ret.CustCTaXLayRefCd = retWork.CustCTaXLayRefCd;            // ���Ӑ����œ]�ŕ����Q�Ƌ敪
            ret.ConsTaxLayMethod = retWork.ConsTaxLayMethod;            // ����œ]�ŕ���
            ret.TotalAmountDispWayCd = retWork.TotalAmountDispWayCd;    // ���z�\�����@�敪
            ret.TotalAmntDspWayRef = retWork.TotalAmntDspWayRef;        // ���z�\�����@�Q�Ƌ敪
            ret.AccountNoInfo1 = retWork.AccountNoInfo1;                // ��s����1
            ret.AccountNoInfo2 = retWork.AccountNoInfo2;                // ��s����2
            ret.AccountNoInfo3 = retWork.AccountNoInfo3;                // ��s����3
            ret.SalesUnPrcFrcProcCd = retWork.SalesUnPrcFrcProcCd;      // ����P���[�������R�[�h
            ret.SalesMoneyFrcProcCd = retWork.SalesMoneyFrcProcCd;      // ������z�[�������R�[�h
            ret.SalesCnsTaxFrcProcCd = retWork.SalesCnsTaxFrcProcCd;    // �������Œ[�������R�[�h
            ret.CustomerSlipNoDiv = retWork.CustomerSlipNoDiv;          // ���Ӑ�`�[�ԍ��敪
            ret.NTimeCalcStDate = retWork.NTimeCalcStDate;              // ���񊨒�J�n��
            ret.CustomerAgent = retWork.CustomerAgent;                  // ���Ӑ�S����
            ret.ClaimSectionCode = retWork.ClaimSectionCode.Trim();     // �������_�R�[�h
            ret.ClaimSectionName = retWork.ClaimSectionName;            // �������_����
            ret.CarMngDivCd = retWork.CarMngDivCd;                      // ���q�Ǘ��敪
            ret.BillPartsNoPrtCd = retWork.BillPartsNoPrtCd;            // �i�Ԉ󎚋敪(������)
            ret.DeliPartsNoPrtCd = retWork.DeliPartsNoPrtCd;            // �i�Ԉ󎚋敪(�[�i���j
            ret.DefSalesSlipCd = retWork.DefSalesSlipCd;                // �`�[�敪�����l
            ret.LavorRateRank = retWork.LavorRateRank;                  // �H�����o���[�g�����N
            ret.SlipTtlPrn = retWork.SlipTtlPrn;                        // �`�[�^�C�g���p�^�[��
            ret.DepoBankCode = retWork.DepoBankCode;                    // ������s�R�[�h
            ret.DepoBankName = retWork.DepoBankName;                    // ������s����
            ret.CustWarehouseCd = retWork.CustWarehouseCd.Trim();       // ���Ӑ�D��q�ɃR�[�h
            ret.CustWarehouseName = retWork.CustWarehouseName;          // ���Ӑ�D��q�ɖ���
            ret.QrcodePrtCd = retWork.QrcodePrtCd;                      // QR�R�[�h���
            ret.DeliHonorificTtl = retWork.DeliHonorificTtl;            // �[�i���h��
            ret.BillHonorificTtl = retWork.BillHonorificTtl;            // �������h��
            ret.EstmHonorificTtl = retWork.EstmHonorificTtl;            // ���Ϗ��h��
            ret.RectHonorificTtl = retWork.RectHonorificTtl;            // �̎����h��
            ret.DeliHonorTtlPrtDiv = retWork.DeliHonorTtlPrtDiv;        // �[�i���h�̈󎚋敪
            ret.BillHonorTtlPrtDiv = retWork.BillHonorTtlPrtDiv;        // �������h�̈󎚋敪
            ret.EstmHonorTtlPrtDiv = retWork.EstmHonorTtlPrtDiv;        // ���Ϗ��h�̈󎚋敪
            ret.RectHonorTtlPrtDiv = retWork.RectHonorTtlPrtDiv;        // �̎����h�̈󎚋敪
            ret.Note1 = retWork.Note1;                                  // ���l1
            ret.Note2 = retWork.Note2;                                  // ���l2
            ret.Note3 = retWork.Note3;                                  // ���l3
            ret.Note4 = retWork.Note4;                                  // ���l4
            ret.Note5 = retWork.Note5;                                  // ���l5
            ret.Note6 = retWork.Note6;                                  // ���l6
            ret.Note7 = retWork.Note7;                                  // ���l7
            ret.Note8 = retWork.Note8;                                  // ���l8
            ret.Note9 = retWork.Note9;                                  // ���l9
            ret.Note10 = retWork.Note10;                                // ���l10
            ret.CreditMoney = retWork.CreditMoney;                      // �^�M�z[�ϓ����]
            ret.WarningCreditMoney = retWork.WarningCreditMoney;        // �x���^�M�z[�ϓ����]
            ret.PrsntAccRecBalance = retWork.PrsntAccRecBalance;        // ���ݔ��|�c��[�ϓ����]
            ret.ReceiptOutputCode = retWork.ReceiptOutputCode;          // �̎����o�͋敪�R�[�h

            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ---------->>>>>
            ret.SalesSlipPrtDiv = retWork.SalesSlipPrtDiv;      // �[�i���o�́i����`�[���s�敪�j
            ret.AcpOdrrSlipPrtDiv = retWork.AcpOdrrSlipPrtDiv;  // �󒍓`�[�o�́i�󒍓`�[���s�敪�j
            ret.ShipmSlipPrtDiv = retWork.ShipmSlipPrtDiv;      // �ݏo�`�[�o�́i�o�ד`�[���s�敪�j
            ret.EstimatePrtDiv = retWork.EstimatePrtDiv;        // ���ϓ`�[�o�́i���ϓ`�[���s�敪�j
            ret.UOESlipPrtDiv = retWork.UOESlipPrtDiv;          // UOE�`�[�o�́iUOE�`�[���s�敪�j
            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ----------<<<<<

            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            ret.TotalBillOutputDiv = retWork.TotalBillOutputDiv;    // ���v�������o�͋敪
            ret.DetailBillOutputCode = retWork.DetailBillOutputCode;// ���א������o�͋敪
            ret.SlipTtlBillOutputDiv = retWork.SlipTtlBillOutputDiv;// �`�[���v�������o�͋敪
            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

            return ret;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(E��D)
        /// </summary>
        /// <param name="retWork">���Ӑ�ꊇ�C�����o�����N���X</param>
        /// <returns>���Ӑ�}�X�^���[�N�N���X</returns>
        /// <remarks>
        /// </remarks>
        private CustomerWork CopyToCustomerWorkFromCustomerCustomerChangeResult(CustomerCustomerChangeResult ret)
        {
            CustomerWork retWork = new CustomerWork();

            retWork.CreateDateTime = ret.CreateDateTime;                // �쐬����
            retWork.UpdateDateTime = ret.UpdateDateTime;                // �X�V����
            retWork.EnterpriseCode = ret.EnterpriseCode;                // ��ƃR�[�h
            retWork.FileHeaderGuid = ret.FileHeaderGuid;                // GUID
            retWork.UpdEmployeeCode = ret.UpdEmployeeCode;              // �X�V�]�ƈ��R�[�h
            retWork.UpdAssemblyId1 = ret.UpdAssemblyId1;                // �X�V�A�Z���u��ID1
            retWork.UpdAssemblyId2 = ret.UpdAssemblyId2;                // �X�V�A�Z���u��ID2
            retWork.LogicalDeleteCode = ret.LogicalDeleteCode;          // �_���폜�敪
            retWork.CustomerCode = ret.CustomerCode;                    // ���Ӑ�R�[�h
            retWork.CustomerSubCode = ret.CustomerSubCode;              // ���Ӑ�T�u�R�[�h
            retWork.Name = ret.Name;                                    // ����
            retWork.Name2 = ret.Name2;                                  // ����2
            retWork.HonorificTitle = ret.HonorificTitle;                // �h��
            retWork.Kana = ret.Kana;                                    // �J�i
            retWork.CustomerSnm = ret.CustomerSnm;                      // ���Ӑ旪��
            retWork.OutputNameCode = ret.OutputNameCode;                // �����R�[�h
            retWork.OutputName = ret.OutputName;                        // ��������
            retWork.CorporateDivCode = ret.CorporateDivCode;            // �l�E�@�l�敪
            retWork.CustomerAttributeDiv = ret.CustomerAttributeDiv;    // ���Ӑ摮���敪
            retWork.JobTypeCode = ret.JobTypeCode;                      // �E��R�[�h
            retWork.JobTypeName = ret.JobTypeName;                      // �E�햼��
            retWork.BusinessTypeCode = ret.BusinessTypeCode;            // �Ǝ�R�[�h
            retWork.BusinessTypeName = ret.BusinessTypeName;            // �Ǝ햼��
            retWork.SalesAreaCode = ret.SalesAreaCode;                  // �̔��G���A�R�[�h
            retWork.SalesAreaName = ret.SalesAreaName;                  // �̔��G���A����
            retWork.PostNo = ret.PostNo;                                // �X�֔ԍ�
            retWork.Address1 = ret.Address1;                            // �Z��1�i�s���{���s��S�E�����E���j
            retWork.Address3 = ret.Address3;                            // �Z��3�i�Ԓn�j
            retWork.Address4 = ret.Address4;                            // �Z��4�i�A�p�[�g���́j
            retWork.HomeTelNo = ret.HomeTelNo;                          // �d�b�ԍ��i����j
            retWork.OfficeTelNo = ret.OfficeTelNo;                      // �d�b�ԍ��i�Ζ���j
            retWork.PortableTelNo = ret.PortableTelNo;                  // �d�b�ԍ��i�g�сj
            retWork.HomeFaxNo = ret.HomeFaxNo;                          // FAX�ԍ��i����j
            retWork.OfficeFaxNo = ret.OfficeFaxNo;                      // FAX�ԍ��i�Ζ���j
            retWork.OthersTelNo = ret.OthersTelNo;                      // �d�b�ԍ��i���̑��j
            retWork.MainContactCode = ret.MainContactCode;              // ��A����敪
            retWork.SearchTelNo = ret.SearchTelNo;                      // �d�b�ԍ��i�����p��4���j
            retWork.MngSectionCode = ret.MngSectionCode;                // �Ǘ����_�R�[�h
            retWork.MngSectionName = ret.MngSectionName;                // �Ǘ����_����
            retWork.InpSectionCode = ret.InpSectionCode;                // ���͋��_�R�[�h
            retWork.CustAnalysCode1 = ret.CustAnalysCode1;              // ���Ӑ敪�̓R�[�h1
            retWork.CustAnalysCode2 = ret.CustAnalysCode2;              // ���Ӑ敪�̓R�[�h2
            retWork.CustAnalysCode3 = ret.CustAnalysCode3;              // ���Ӑ敪�̓R�[�h3
            retWork.CustAnalysCode4 = ret.CustAnalysCode4;              // ���Ӑ敪�̓R�[�h4
            retWork.CustAnalysCode5 = ret.CustAnalysCode5;              // ���Ӑ敪�̓R�[�h5
            retWork.CustAnalysCode6 = ret.CustAnalysCode6;              // ���Ӑ敪�̓R�[�h6
            retWork.BillOutputCode = ret.BillOutputCode;                // �������o�͋敪�R�[�h
            retWork.BillOutputName = ret.BillOutputName;                // �������o�͋敪����
            retWork.TotalDay = ret.TotalDay;                            // ����
            retWork.CollectMoneyCode = ret.CollectMoneyCode;            // �W�����敪�R�[�h
            retWork.CollectMoneyName = ret.CollectMoneyName;            // �W�����敪����
            retWork.CollectMoneyDay = ret.CollectMoneyDay;              // �W����
            retWork.CollectCond = ret.CollectCond;                      // �������
            retWork.CollectSight = ret.CollectSight;                    // ����T�C�g
            retWork.ClaimCode = ret.ClaimCode;                          // ������R�[�h
            retWork.ClaimName = ret.ClaimName;                          // �����於��
            retWork.ClaimName2 = ret.ClaimName2;                        // �����於��2
            retWork.ClaimSnm = ret.ClaimSnm;                            // �����旪��
            retWork.TransStopDate = ret.TransStopDate;                  // ������~��
            retWork.DmOutCode = ret.DmOutCode;                          // DM�o�͋敪
            retWork.DmOutName = ret.DmOutName;                          // DM�o�͋敪����
            retWork.MainSendMailAddrCd = ret.MainSendMailAddrCd;        // �呗�M�惁�[���A�h���X�敪
            retWork.MailAddrKindCode1 = ret.MailAddrKindCode1;          // ���[���A�h���X��ʃR�[�h1
            retWork.MailAddrKindName1 = ret.MailAddrKindName1;          // ���[���A�h���X��ʖ���1
            retWork.MailAddress1 = ret.MailAddress1;                    // ���[���A�h���X1
            retWork.MailSendCode1 = ret.MailSendCode1;                  // ���[�����M�敪�R�[�h1
            retWork.MailSendName1 = ret.MailSendName1;                  // ���[�����M�敪����1
            retWork.MailAddrKindCode2 = ret.MailAddrKindCode2;          // ���[���A�h���X��ʃR�[�h2
            retWork.MailAddrKindName2 = ret.MailAddrKindName2;          // ���[���A�h���X��ʖ���2
            retWork.MailAddress2 = ret.MailAddress2;                    // ���[���A�h���X2
            retWork.MailSendCode2 = ret.MailSendCode2;                  // ���[�����M�敪�R�[�h2
            retWork.MailSendName2 = ret.MailSendName2;                  // ���[�����M�敪����2
            retWork.CustomerAgentCd = ret.CustomerAgentCd;              // �ڋq�S���]�ƈ��R�[�h
            retWork.CustomerAgentNm = ret.CustomerAgentNm;              // �ڋq�S���]�ƈ�����
            retWork.BillCollecterCd = ret.BillCollecterCd;              // �W���S���]�ƈ��R�[�h
            retWork.OldCustomerAgentCd = ret.OldCustomerAgentCd;        // ���ڋq�S���]�ƈ��R�[�h
            retWork.OldCustomerAgentNm = ret.OldCustomerAgentNm;        // ���ڋq�S���]�ƈ�����
            retWork.CustAgentChgDate = ret.CustAgentChgDate;            // �ڋq�S���ύX��
            retWork.AcceptWholeSale = ret.AcceptWholeSale;              // �Ɣ̐�敪
            retWork.CreditMngCode = ret.CreditMngCode;                  // �^�M�Ǘ��敪
            retWork.DepoDelCode = ret.DepoDelCode;                      // ���������敪
            retWork.AccRecDivCd = ret.AccRecDivCd;                      // ���|�敪
            retWork.CustSlipNoMngCd = ret.CustSlipNoMngCd;              // ����`�[�ԍ��Ǘ��敪
            retWork.PureCode = ret.PureCode;                            // �����敪
            retWork.CustCTaXLayRefCd = ret.CustCTaXLayRefCd;            // ���Ӑ����œ]�ŕ����Q�Ƌ敪
            retWork.ConsTaxLayMethod = ret.ConsTaxLayMethod;            // ����œ]�ŕ���
            retWork.TotalAmountDispWayCd = ret.TotalAmountDispWayCd;    // ���z�\�����@�敪
            retWork.TotalAmntDspWayRef = ret.TotalAmntDspWayRef;        // ���z�\�����@�Q�Ƌ敪
            retWork.AccountNoInfo1 = ret.AccountNoInfo1;                // ��s����1
            retWork.AccountNoInfo2 = ret.AccountNoInfo2;                // ��s����2
            retWork.AccountNoInfo3 = ret.AccountNoInfo3;                // ��s����3
            retWork.SalesUnPrcFrcProcCd = ret.SalesUnPrcFrcProcCd;      // ����P���[�������R�[�h
            retWork.SalesMoneyFrcProcCd = ret.SalesMoneyFrcProcCd;      // ������z�[�������R�[�h
            retWork.SalesCnsTaxFrcProcCd = ret.SalesCnsTaxFrcProcCd;    // �������Œ[�������R�[�h
            retWork.CustomerSlipNoDiv = ret.CustomerSlipNoDiv;          // ���Ӑ�`�[�ԍ��敪
            retWork.NTimeCalcStDate = ret.NTimeCalcStDate;              // ���񊨒�J�n��
            retWork.CustomerAgent = ret.CustomerAgent;                  // ���Ӑ�S����
            retWork.ClaimSectionCode = ret.ClaimSectionCode;            // �������_�R�[�h
            retWork.ClaimSectionName = ret.ClaimSectionName;            // �������_����
            retWork.CarMngDivCd = ret.CarMngDivCd;                      // ���q�Ǘ��敪
            retWork.BillPartsNoPrtCd = ret.BillPartsNoPrtCd;            // �i�Ԉ󎚋敪(������)
            retWork.DeliPartsNoPrtCd = ret.DeliPartsNoPrtCd;            // �i�Ԉ󎚋敪(�[�i���j
            retWork.DefSalesSlipCd = ret.DefSalesSlipCd;                // �`�[�敪�����l
            retWork.LavorRateRank = ret.LavorRateRank;                  // �H�����o���[�g�����N
            retWork.SlipTtlPrn = ret.SlipTtlPrn;                        // �`�[�^�C�g���p�^�[��
            retWork.DepoBankCode = ret.DepoBankCode;                    // ������s�R�[�h
            retWork.DepoBankName = ret.DepoBankName;                    // ������s����
            retWork.CustWarehouseCd = ret.CustWarehouseCd;              // ���Ӑ�D��q�ɃR�[�h
            retWork.CustWarehouseName = ret.CustWarehouseName;          // ���Ӑ�D��q�ɖ���
            retWork.QrcodePrtCd = ret.QrcodePrtCd;                      // QR�R�[�h���
            retWork.DeliHonorificTtl = ret.DeliHonorificTtl;            // �[�i���h��
            retWork.BillHonorificTtl = ret.BillHonorificTtl;            // �������h��
            retWork.EstmHonorificTtl = ret.EstmHonorificTtl;            // ���Ϗ��h��
            retWork.RectHonorificTtl = ret.RectHonorificTtl;            // �̎����h��
            retWork.DeliHonorTtlPrtDiv = ret.DeliHonorTtlPrtDiv;        // �[�i���h�̈󎚋敪
            retWork.BillHonorTtlPrtDiv = ret.BillHonorTtlPrtDiv;        // �������h�̈󎚋敪
            retWork.EstmHonorTtlPrtDiv = ret.EstmHonorTtlPrtDiv;        // ���Ϗ��h�̈󎚋敪
            retWork.RectHonorTtlPrtDiv = ret.RectHonorTtlPrtDiv;        // �̎����h�̈󎚋敪
            retWork.Note1 = ret.Note1;                                  // ���l1
            retWork.Note2 = ret.Note2;                                  // ���l2
            retWork.Note3 = ret.Note3;                                  // ���l3
            retWork.Note4 = ret.Note4;                                  // ���l4
            retWork.Note5 = ret.Note5;                                  // ���l5
            retWork.Note6 = ret.Note6;                                  // ���l6
            retWork.Note7 = ret.Note7;                                  // ���l7
            retWork.Note8 = ret.Note8;                                  // ���l8
            retWork.Note9 = ret.Note9;                                  // ���l9
            retWork.Note10 = ret.Note10;                                // ���l10
            retWork.CreditMoney = ret.CreditMoney;                      // �^�M�z[�ϓ����]
            retWork.WarningCreditMoney = ret.WarningCreditMoney;        // �x���^�M�z[�ϓ����]
            retWork.PrsntAccRecBalance = ret.PrsntAccRecBalance;        // ���ݔ��|�c��[�ϓ����]
            retWork.ReceiptOutputCode = ret.ReceiptOutputCode;          // �̎����o�͋敪�R�[�h
            retWork.WriteDiv = 1;                                       // �X�V�敪

            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ---------->>>>>
            retWork.SalesSlipPrtDiv = ret.SalesSlipPrtDiv;      // �[�i���o�́i����`�[���s�敪�j
            retWork.AcpOdrrSlipPrtDiv = ret.AcpOdrrSlipPrtDiv;  // �󒍓`�[�o�́i�󒍓`�[���s�敪�j
            retWork.ShipmSlipPrtDiv = ret.ShipmSlipPrtDiv;      // �ݏo�`�[�o�́i�o�ד`�[���s�敪�j
            retWork.EstimatePrtDiv = ret.EstimatePrtDiv;        // ���ϓ`�[�o�́i���ϓ`�[���s�敪�j
            retWork.UOESlipPrtDiv = ret.UOESlipPrtDiv;          // UOE�`�[�o�́iUOE�`�[���s�敪�j
            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ----------<<<<<

            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            retWork.TotalBillOutputDiv = ret.TotalBillOutputDiv;    // ���v�������o�͋敪
            retWork.DetailBillOutputCode = ret.DetailBillOutputCode;// ���א������o�͋敪
            retWork.SlipTtlBillOutputDiv = ret.SlipTtlBillOutputDiv;// �`�[���v�������o�͋敪
            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

            return retWork;
        }
        // ADD 2009/04/10 ------<<<

        #endregion �� Private Methods
    }
}
