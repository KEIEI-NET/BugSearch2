using System;
using System.Collections;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// �x���f�[�^����N���X
    /// </summary>
    public static class PaymentDataUtil
    {
        /// <summary>
        /// �x���`�[�f�[�^�Ǝx�����׃f�[�^�����̂��Ďx���f�[�^���쐬���܂��B
        /// </summary>
        /// <param name="paymentDataWork">�쐬�����x���f�[�^</param>
        /// <param name="paymentSlpWork">�x���`�[�f�[�^</param>
        /// <param name="paymentDtlWorkArray">�x�����׃f�[�^�̔z��</param>
        public static void UnionRef(ref PaymentDataWork paymentDataWork, PaymentSlpWork paymentSlpWork, PaymentDtlWork[] paymentDtlWorkArray)
        {
            if (paymentDataWork != null)
            {
                # region [PaymentDataWork �� PaymentSlpWork]
                if (paymentSlpWork != null)
                {
                    paymentDataWork.CreateDateTime = paymentSlpWork.CreateDateTime;            // �쐬����
                    paymentDataWork.UpdateDateTime = paymentSlpWork.UpdateDateTime;            // �X�V����
                    paymentDataWork.EnterpriseCode = paymentSlpWork.EnterpriseCode;            // ��ƃR�[�h
                    paymentDataWork.FileHeaderGuid = paymentSlpWork.FileHeaderGuid;            // GUID
                    paymentDataWork.UpdEmployeeCode = paymentSlpWork.UpdEmployeeCode;          // �X�V�]�ƈ��R�[�h
                    paymentDataWork.UpdAssemblyId1 = paymentSlpWork.UpdAssemblyId1;            // �X�V�A�Z���u��ID1
                    paymentDataWork.UpdAssemblyId2 = paymentSlpWork.UpdAssemblyId2;            // �X�V�A�Z���u��ID2
                    paymentDataWork.LogicalDeleteCode = paymentSlpWork.LogicalDeleteCode;      // �_���폜�敪
                    paymentDataWork.DebitNoteDiv = paymentSlpWork.DebitNoteDiv;                // �ԓ`�敪
                    paymentDataWork.PaymentSlipNo = paymentSlpWork.PaymentSlipNo;              // �x���`�[�ԍ�
                    paymentDataWork.SupplierFormal = paymentSlpWork.SupplierFormal;            // �d���`��
                    paymentDataWork.SupplierSlipNo = paymentSlpWork.SupplierSlipNo;            // �d���`�[�ԍ�
                    paymentDataWork.SupplierCd = paymentSlpWork.SupplierCd;                    // �d����R�[�h
                    paymentDataWork.SupplierNm1 = paymentSlpWork.SupplierNm1;                  // �d���於1
                    paymentDataWork.SupplierNm2 = paymentSlpWork.SupplierNm2;                  // �d���於2
                    paymentDataWork.SupplierSnm = paymentSlpWork.SupplierSnm;                  // �d���旪��
                    paymentDataWork.PayeeCode = paymentSlpWork.PayeeCode;                      // �x����R�[�h
                    paymentDataWork.PayeeName = paymentSlpWork.PayeeName;                      // �x���於��
                    paymentDataWork.PayeeName2 = paymentSlpWork.PayeeName2;                    // �x���於��2
                    paymentDataWork.PayeeSnm = paymentSlpWork.PayeeSnm;                        // �x���旪��
                    paymentDataWork.PaymentInpSectionCd = paymentSlpWork.PaymentInpSectionCd;  // �x�����͋��_�R�[�h
                    paymentDataWork.AddUpSecCode = paymentSlpWork.AddUpSecCode;                // �v�㋒�_�R�[�h
                    paymentDataWork.UpdateSecCd = paymentSlpWork.UpdateSecCd;                  // �X�V���_�R�[�h
                    paymentDataWork.SubSectionCode = paymentSlpWork.SubSectionCode;            // ����R�[�h
                    paymentDataWork.InputDay = paymentSlpWork.InputDay;                        // ���͓��t  //ADD 2009/03/25
                    paymentDataWork.PaymentDate = paymentSlpWork.PaymentDate;                  // �x�����t
                    paymentDataWork.AddUpADate = paymentSlpWork.AddUpADate;                    // �v����t
                    paymentDataWork.PaymentTotal = paymentSlpWork.PaymentTotal;                // �x���v
                    paymentDataWork.Payment = paymentSlpWork.Payment;                          // �x�����z
                    paymentDataWork.FeePayment = paymentSlpWork.FeePayment;                    // �萔���x���z
                    paymentDataWork.DiscountPayment = paymentSlpWork.DiscountPayment;          // �l���x���z
                    paymentDataWork.AutoPayment = paymentSlpWork.AutoPayment;                  // �����x���敪
                    paymentDataWork.DraftDrawingDate = paymentSlpWork.DraftDrawingDate;        // ��`�U�o��
                    paymentDataWork.DraftKind = paymentSlpWork.DraftKind;                      // ��`���
                    paymentDataWork.DraftKindName = paymentSlpWork.DraftKindName;              // ��`��ޖ���
                    paymentDataWork.DraftDivide = paymentSlpWork.DraftDivide;                  // ��`�敪
                    paymentDataWork.DraftDivideName = paymentSlpWork.DraftDivideName;          // ��`�敪����
                    paymentDataWork.DraftNo = paymentSlpWork.DraftNo;                          // ��`�ԍ�
                    paymentDataWork.DebitNoteLinkPayNo = paymentSlpWork.DebitNoteLinkPayNo;    // �ԍ��x���A���ԍ�
                    paymentDataWork.PaymentAgentCode = paymentSlpWork.PaymentAgentCode;        // �x���S���҃R�[�h
                    paymentDataWork.PaymentAgentName = paymentSlpWork.PaymentAgentName;        // �x���S���Җ���
                    paymentDataWork.PaymentInputAgentCd = paymentSlpWork.PaymentInputAgentCd;  // �x�����͎҃R�[�h
                    paymentDataWork.PaymentInputAgentNm = paymentSlpWork.PaymentInputAgentNm;  // �x�����͎Җ���
                    paymentDataWork.Outline = paymentSlpWork.Outline;                          // �`�[�E�v
                    paymentDataWork.BankCode = paymentSlpWork.BankCode;                        // ��s�R�[�h
                    paymentDataWork.BankName = paymentSlpWork.BankName;                        // ��s����
                }
                # endregion

                # region [PaymentDataWork �� PaymentDtlWork]
                if (paymentDtlWorkArray != null)
                {
                    for (int idx = 0; idx < paymentDtlWorkArray.Length; idx++)
                    {
                        PaymentDtlWork paymentDtlWork = paymentDtlWorkArray[idx];

                        switch (paymentDtlWork.PaymentRowNo)
                        {
                            case 1:
                                {
                                    paymentDataWork.PaymentRowNo1 = paymentDtlWork.PaymentRowNo;     // �x���s�ԍ��P
                                    paymentDataWork.MoneyKindCode1 = paymentDtlWork.MoneyKindCode;   // ����R�[�h�P
                                    paymentDataWork.MoneyKindName1 = paymentDtlWork.MoneyKindName;   // ���햼�̂P
                                    paymentDataWork.MoneyKindDiv1 = paymentDtlWork.MoneyKindDiv;     // ����敪�P
                                    paymentDataWork.Payment1 = paymentDtlWork.Payment;               // �x�����z�P
                                    paymentDataWork.ValidityTerm1 = paymentDtlWork.ValidityTerm;     // �L�������P
                                    break;
                                }
                            case 2:
                                {
                                    paymentDataWork.PaymentRowNo2 = paymentDtlWork.PaymentRowNo;     // �x���s�ԍ��Q
                                    paymentDataWork.MoneyKindCode2 = paymentDtlWork.MoneyKindCode;   // ����R�[�h�Q
                                    paymentDataWork.MoneyKindName2 = paymentDtlWork.MoneyKindName;   // ���햼�̂Q
                                    paymentDataWork.MoneyKindDiv2 = paymentDtlWork.MoneyKindDiv;     // ����敪�Q
                                    paymentDataWork.Payment2 = paymentDtlWork.Payment;               // �x�����z�Q
                                    paymentDataWork.ValidityTerm2 = paymentDtlWork.ValidityTerm;     // �L�������Q
                                    break;
                                }
                            case 3:
                                {
                                    paymentDataWork.PaymentRowNo3 = paymentDtlWork.PaymentRowNo;     // �x���s�ԍ��R
                                    paymentDataWork.MoneyKindCode3 = paymentDtlWork.MoneyKindCode;   // ����R�[�h�R
                                    paymentDataWork.MoneyKindName3 = paymentDtlWork.MoneyKindName;   // ���햼�̂R
                                    paymentDataWork.MoneyKindDiv3 = paymentDtlWork.MoneyKindDiv;     // ����敪�R
                                    paymentDataWork.Payment3 = paymentDtlWork.Payment;               // �x�����z�R
                                    paymentDataWork.ValidityTerm3 = paymentDtlWork.ValidityTerm;     // �L�������R
                                    break;
                                }
                            case 4:
                                {
                                    paymentDataWork.PaymentRowNo4 = paymentDtlWork.PaymentRowNo;     // �x���s�ԍ��S
                                    paymentDataWork.MoneyKindCode4 = paymentDtlWork.MoneyKindCode;   // ����R�[�h�S
                                    paymentDataWork.MoneyKindName4 = paymentDtlWork.MoneyKindName;   // ���햼�̂S
                                    paymentDataWork.MoneyKindDiv4 = paymentDtlWork.MoneyKindDiv;     // ����敪�S
                                    paymentDataWork.Payment4 = paymentDtlWork.Payment;               // �x�����z�S
                                    paymentDataWork.ValidityTerm4 = paymentDtlWork.ValidityTerm;     // �L�������S
                                    break;
                                }
                            case 5:
                                {
                                    paymentDataWork.PaymentRowNo5 = paymentDtlWork.PaymentRowNo;     // �x���s�ԍ��T
                                    paymentDataWork.MoneyKindCode5 = paymentDtlWork.MoneyKindCode;   // ����R�[�h�T
                                    paymentDataWork.MoneyKindName5 = paymentDtlWork.MoneyKindName;   // ���햼�̂T
                                    paymentDataWork.MoneyKindDiv5 = paymentDtlWork.MoneyKindDiv;     // ����敪�T
                                    paymentDataWork.Payment5 = paymentDtlWork.Payment;               // �x�����z�T
                                    paymentDataWork.ValidityTerm5 = paymentDtlWork.ValidityTerm;     // �L�������T
                                    break;
                                }
                            case 6:
                                {
                                    paymentDataWork.PaymentRowNo6 = paymentDtlWork.PaymentRowNo;     // �x���s�ԍ��U
                                    paymentDataWork.MoneyKindCode6 = paymentDtlWork.MoneyKindCode;   // ����R�[�h�U
                                    paymentDataWork.MoneyKindName6 = paymentDtlWork.MoneyKindName;   // ���햼�̂U
                                    paymentDataWork.MoneyKindDiv6 = paymentDtlWork.MoneyKindDiv;     // ����敪�U
                                    paymentDataWork.Payment6 = paymentDtlWork.Payment;               // �x�����z�U
                                    paymentDataWork.ValidityTerm6 = paymentDtlWork.ValidityTerm;     // �L�������U
                                    break;
                                }
                            case 7:
                                {
                                    paymentDataWork.PaymentRowNo7 = paymentDtlWork.PaymentRowNo;     // �x���s�ԍ��V
                                    paymentDataWork.MoneyKindCode7 = paymentDtlWork.MoneyKindCode;   // ����R�[�h�V
                                    paymentDataWork.MoneyKindName7 = paymentDtlWork.MoneyKindName;   // ���햼�̂V
                                    paymentDataWork.MoneyKindDiv7 = paymentDtlWork.MoneyKindDiv;     // ����敪�V
                                    paymentDataWork.Payment7 = paymentDtlWork.Payment;               // �x�����z�V
                                    paymentDataWork.ValidityTerm7 = paymentDtlWork.ValidityTerm;     // �L�������V
                                    break;
                                }
                            case 8:
                                {
                                    paymentDataWork.PaymentRowNo8 = paymentDtlWork.PaymentRowNo;     // �x���s�ԍ��W
                                    paymentDataWork.MoneyKindCode8 = paymentDtlWork.MoneyKindCode;   // ����R�[�h�W
                                    paymentDataWork.MoneyKindName8 = paymentDtlWork.MoneyKindName;   // ���햼�̂W
                                    paymentDataWork.MoneyKindDiv8 = paymentDtlWork.MoneyKindDiv;     // ����敪�W
                                    paymentDataWork.Payment8 = paymentDtlWork.Payment;               // �x�����z�W
                                    paymentDataWork.ValidityTerm8 = paymentDtlWork.ValidityTerm;     // �L�������W
                                    break;
                                }
                            case 9:
                                {
                                    paymentDataWork.PaymentRowNo9 = paymentDtlWork.PaymentRowNo;     // �x���s�ԍ��X
                                    paymentDataWork.MoneyKindCode9 = paymentDtlWork.MoneyKindCode;   // ����R�[�h�X
                                    paymentDataWork.MoneyKindName9 = paymentDtlWork.MoneyKindName;   // ���햼�̂X
                                    paymentDataWork.MoneyKindDiv9 = paymentDtlWork.MoneyKindDiv;     // ����敪�X
                                    paymentDataWork.Payment9 = paymentDtlWork.Payment;               // �x�����z�X
                                    paymentDataWork.ValidityTerm9 = paymentDtlWork.ValidityTerm;     // �L�������X
                                    break;
                                }
                            case 10:
                                {
                                    paymentDataWork.PaymentRowNo10 = paymentDtlWork.PaymentRowNo;    // �x���s�ԍ��P�O
                                    paymentDataWork.MoneyKindCode10 = paymentDtlWork.MoneyKindCode;  // ����R�[�h�P�O
                                    paymentDataWork.MoneyKindName10 = paymentDtlWork.MoneyKindName;  // ���햼�̂P�O
                                    paymentDataWork.MoneyKindDiv10 = paymentDtlWork.MoneyKindDiv;    // ����敪�P�O
                                    paymentDataWork.Payment10 = paymentDtlWork.Payment;              // �x�����z�P�O
                                    paymentDataWork.ValidityTerm10 = paymentDtlWork.ValidityTerm;    // �L�������P�O
                                    break;
                                }
                        }
                    }
                }
                # endregion
            }
        }
        
        /// <summary>
        /// �x���`�[�f�[�^�Ǝx�����׃f�[�^�����̂��Ďx���f�[�^���쐬���܂��B
        /// </summary>
        /// <param name="paymentDataWork">�쐬�����x���f�[�^</param>
        /// <param name="paymentSlpWork">�x���`�[�f�[�^</param>
        /// <param name="paymentDtlWorkArray">�x�����׃f�[�^�̔z��</param>
        public static void Union(out PaymentDataWork paymentDataWork, PaymentSlpWork paymentSlpWork, PaymentDtlWork[] paymentDtlWorkArray)
        {
            paymentDataWork = new PaymentDataWork();
            PaymentDataUtil.UnionRef(ref paymentDataWork, paymentSlpWork, paymentDtlWorkArray);
        }

        /// <summary>
        /// �x���f�[�^���x���`�[�f�[�^�Ǝx�����׃f�[�^�ɕ������܂��B
        /// </summary>
        /// <param name="paymentDataWork">�x���f�[�^</param>
        /// <param name="paymentSlpWork">�������ꂽ�x���`�[�f�[�^</param>
        /// <param name="paymentDtlWorkArray">�������ꂽ�x�����׃f�[�^�̔z��</param>
        public static void DivisionRef(PaymentDataWork paymentDataWork, ref PaymentSlpWork paymentSlpWork, ref PaymentDtlWork[] paymentDtlWorkArray)
        {
            if (paymentDataWork != null && paymentSlpWork != null && paymentDtlWorkArray != null)
            {
                # region [PaymentSlpWork �� PaymentDataWork]
                paymentSlpWork.CreateDateTime = paymentDataWork.CreateDateTime;            // �쐬����
                paymentSlpWork.UpdateDateTime = paymentDataWork.UpdateDateTime;            // �X�V����
                paymentSlpWork.EnterpriseCode = paymentDataWork.EnterpriseCode;            // ��ƃR�[�h
                paymentSlpWork.FileHeaderGuid = paymentDataWork.FileHeaderGuid;            // GUID
                paymentSlpWork.UpdEmployeeCode = paymentDataWork.UpdEmployeeCode;          // �X�V�]�ƈ��R�[�h
                paymentSlpWork.UpdAssemblyId1 = paymentDataWork.UpdAssemblyId1;            // �X�V�A�Z���u��ID1
                paymentSlpWork.UpdAssemblyId2 = paymentDataWork.UpdAssemblyId2;            // �X�V�A�Z���u��ID2
                paymentSlpWork.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;      // �_���폜�敪
                paymentSlpWork.DebitNoteDiv = paymentDataWork.DebitNoteDiv;                // �ԓ`�敪
                paymentSlpWork.PaymentSlipNo = paymentDataWork.PaymentSlipNo;              // �x���`�[�ԍ�
                paymentSlpWork.SupplierFormal = paymentDataWork.SupplierFormal;            // �d���`��
                paymentSlpWork.SupplierSlipNo = paymentDataWork.SupplierSlipNo;            // �d���`�[�ԍ�
                paymentSlpWork.SupplierCd = paymentDataWork.SupplierCd;                    // �d����R�[�h
                paymentSlpWork.SupplierNm1 = paymentDataWork.SupplierNm1;                  // �d���於1
                paymentSlpWork.SupplierNm2 = paymentDataWork.SupplierNm2;                  // �d���於2
                paymentSlpWork.SupplierSnm = paymentDataWork.SupplierSnm;                  // �d���旪��
                paymentSlpWork.PayeeCode = paymentDataWork.PayeeCode;                      // �x����R�[�h
                paymentSlpWork.PayeeName = paymentDataWork.PayeeName;                      // �x���於��
                paymentSlpWork.PayeeName2 = paymentDataWork.PayeeName2;                    // �x���於��2
                paymentSlpWork.PayeeSnm = paymentDataWork.PayeeSnm;                        // �x���旪��
                paymentSlpWork.PaymentInpSectionCd = paymentDataWork.PaymentInpSectionCd;  // �x�����͋��_�R�[�h
                paymentSlpWork.AddUpSecCode = paymentDataWork.AddUpSecCode;                // �v�㋒�_�R�[�h
                paymentSlpWork.UpdateSecCd = paymentDataWork.UpdateSecCd;                  // �X�V���_�R�[�h
                paymentSlpWork.SubSectionCode = paymentDataWork.SubSectionCode;            // ����R�[�h
                paymentSlpWork.InputDay = paymentDataWork.InputDay;                        // ���͓��t  // ADD 2009/03/25
                paymentSlpWork.PaymentDate = paymentDataWork.PaymentDate;                  // �x�����t
                paymentSlpWork.PrePaymentDate = paymentDataWork.PrePaymentDate;            // �O��x�����t // ADD 2011/12/15
                paymentSlpWork.AddUpADate = paymentDataWork.AddUpADate;                    // �v����t
                paymentSlpWork.PaymentTotal = paymentDataWork.PaymentTotal;                // �x���v
                paymentSlpWork.Payment = paymentDataWork.Payment;                          // �x�����z
                paymentSlpWork.FeePayment = paymentDataWork.FeePayment;                    // �萔���x���z
                paymentSlpWork.DiscountPayment = paymentDataWork.DiscountPayment;          // �l���x���z
                paymentSlpWork.AutoPayment = paymentDataWork.AutoPayment;                  // �����x���敪
                paymentSlpWork.DraftDrawingDate = paymentDataWork.DraftDrawingDate;        // ��`�U�o��
                paymentSlpWork.DraftKind = paymentDataWork.DraftKind;                      // ��`���
                paymentSlpWork.DraftKindName = paymentDataWork.DraftKindName;              // ��`��ޖ���
                paymentSlpWork.DraftDivide = paymentDataWork.DraftDivide;                  // ��`�敪
                paymentSlpWork.DraftDivideName = paymentDataWork.DraftDivideName;          // ��`�敪����
                paymentSlpWork.DraftNo = paymentDataWork.DraftNo;                          // ��`�ԍ�
                paymentSlpWork.DebitNoteLinkPayNo = paymentDataWork.DebitNoteLinkPayNo;    // �ԍ��x���A���ԍ�
                paymentSlpWork.PaymentAgentCode = paymentDataWork.PaymentAgentCode;        // �x���S���҃R�[�h
                paymentSlpWork.PaymentAgentName = paymentDataWork.PaymentAgentName;        // �x���S���Җ���
                paymentSlpWork.PaymentInputAgentCd = paymentDataWork.PaymentInputAgentCd;  // �x�����͎҃R�[�h
                paymentSlpWork.PaymentInputAgentNm = paymentDataWork.PaymentInputAgentNm;  // �x�����͎Җ���
                paymentSlpWork.Outline = paymentDataWork.Outline;                          // �`�[�E�v
                paymentSlpWork.BankCode = paymentDataWork.BankCode;                        // ��s�R�[�h
                paymentSlpWork.BankName = paymentDataWork.BankName;                        // ��s����
                # endregion

                # region [PaymentDtlWork[] �� PaymentDataWork]

                ArrayList paymentDtlWorkList = new ArrayList();

                if (paymentDataWork.PaymentRowNo1 > 0)
                {
                    PaymentDtlWork paymentDtlWork1 = new PaymentDtlWork();
                    paymentDtlWork1.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork1.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork1.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork1.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork1.PaymentRowNo = paymentDataWork.PaymentRowNo1;
                    paymentDtlWork1.MoneyKindCode = paymentDataWork.MoneyKindCode1;
                    paymentDtlWork1.MoneyKindName = paymentDataWork.MoneyKindName1;
                    paymentDtlWork1.MoneyKindDiv = paymentDataWork.MoneyKindDiv1;
                    paymentDtlWork1.Payment = paymentDataWork.Payment1;
                    paymentDtlWork1.ValidityTerm = paymentDataWork.ValidityTerm1;
                    paymentDtlWorkList.Add(paymentDtlWork1);
                }
                if (paymentDataWork.PaymentRowNo2 > 0)
                {
                    PaymentDtlWork paymentDtlWork2 = new PaymentDtlWork();
                    paymentDtlWork2.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork2.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork2.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork2.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork2.PaymentRowNo = paymentDataWork.PaymentRowNo2;
                    paymentDtlWork2.MoneyKindCode = paymentDataWork.MoneyKindCode2;
                    paymentDtlWork2.MoneyKindName = paymentDataWork.MoneyKindName2;
                    paymentDtlWork2.MoneyKindDiv = paymentDataWork.MoneyKindDiv2;
                    paymentDtlWork2.Payment = paymentDataWork.Payment2;
                    paymentDtlWork2.ValidityTerm = paymentDataWork.ValidityTerm2;
                    paymentDtlWorkList.Add(paymentDtlWork2);
                }
                if (paymentDataWork.PaymentRowNo3 > 0)
                {
                    PaymentDtlWork paymentDtlWork3 = new PaymentDtlWork();
                    paymentDtlWork3.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork3.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork3.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork3.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork3.PaymentRowNo = paymentDataWork.PaymentRowNo3;
                    paymentDtlWork3.MoneyKindCode = paymentDataWork.MoneyKindCode3;
                    paymentDtlWork3.MoneyKindName = paymentDataWork.MoneyKindName3;
                    paymentDtlWork3.MoneyKindDiv = paymentDataWork.MoneyKindDiv3;
                    paymentDtlWork3.Payment = paymentDataWork.Payment3;
                    paymentDtlWork3.ValidityTerm = paymentDataWork.ValidityTerm3;
                    paymentDtlWorkList.Add(paymentDtlWork3);
                }
                if (paymentDataWork.PaymentRowNo4 > 0)
                {
                    PaymentDtlWork paymentDtlWork4 = new PaymentDtlWork();
                    paymentDtlWork4.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork4.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork4.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork4.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork4.PaymentRowNo = paymentDataWork.PaymentRowNo4;
                    paymentDtlWork4.MoneyKindCode = paymentDataWork.MoneyKindCode4;
                    paymentDtlWork4.MoneyKindName = paymentDataWork.MoneyKindName4;
                    paymentDtlWork4.MoneyKindDiv = paymentDataWork.MoneyKindDiv4;
                    paymentDtlWork4.Payment = paymentDataWork.Payment4;
                    paymentDtlWork4.ValidityTerm = paymentDataWork.ValidityTerm4;
                    paymentDtlWorkList.Add(paymentDtlWork4);
                }
                if (paymentDataWork.PaymentRowNo5 > 0)
                {
                    PaymentDtlWork paymentDtlWork5 = new PaymentDtlWork();
                    paymentDtlWork5.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork5.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork5.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork5.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork5.PaymentRowNo = paymentDataWork.PaymentRowNo5;
                    paymentDtlWork5.MoneyKindCode = paymentDataWork.MoneyKindCode5;
                    paymentDtlWork5.MoneyKindName = paymentDataWork.MoneyKindName5;
                    paymentDtlWork5.MoneyKindDiv = paymentDataWork.MoneyKindDiv5;
                    paymentDtlWork5.Payment = paymentDataWork.Payment5;
                    paymentDtlWork5.ValidityTerm = paymentDataWork.ValidityTerm5;
                    paymentDtlWorkList.Add(paymentDtlWork5);
                }
                if (paymentDataWork.PaymentRowNo6 > 0)
                {
                    PaymentDtlWork paymentDtlWork6 = new PaymentDtlWork();
                    paymentDtlWork6.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork6.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork6.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork6.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork6.PaymentRowNo = paymentDataWork.PaymentRowNo6;
                    paymentDtlWork6.MoneyKindCode = paymentDataWork.MoneyKindCode6;
                    paymentDtlWork6.MoneyKindName = paymentDataWork.MoneyKindName6;
                    paymentDtlWork6.MoneyKindDiv = paymentDataWork.MoneyKindDiv6;
                    paymentDtlWork6.Payment = paymentDataWork.Payment6;
                    paymentDtlWork6.ValidityTerm = paymentDataWork.ValidityTerm6;
                    paymentDtlWorkList.Add(paymentDtlWork6);
                }
                if (paymentDataWork.PaymentRowNo7 > 0)
                {
                    PaymentDtlWork paymentDtlWork7 = new PaymentDtlWork();
                    paymentDtlWork7.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork7.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork7.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork7.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork7.PaymentRowNo = paymentDataWork.PaymentRowNo7;
                    paymentDtlWork7.MoneyKindCode = paymentDataWork.MoneyKindCode7;
                    paymentDtlWork7.MoneyKindName = paymentDataWork.MoneyKindName7;
                    paymentDtlWork7.MoneyKindDiv = paymentDataWork.MoneyKindDiv7;
                    paymentDtlWork7.Payment = paymentDataWork.Payment7;
                    paymentDtlWork7.ValidityTerm = paymentDataWork.ValidityTerm7;
                    paymentDtlWorkList.Add(paymentDtlWork7);
                }
                if (paymentDataWork.PaymentRowNo8 > 0)
                {
                    PaymentDtlWork paymentDtlWork8 = new PaymentDtlWork();
                    paymentDtlWork8.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork8.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork8.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork8.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork8.PaymentRowNo = paymentDataWork.PaymentRowNo8;
                    paymentDtlWork8.MoneyKindCode = paymentDataWork.MoneyKindCode8;
                    paymentDtlWork8.MoneyKindName = paymentDataWork.MoneyKindName8;
                    paymentDtlWork8.MoneyKindDiv = paymentDataWork.MoneyKindDiv8;
                    paymentDtlWork8.Payment = paymentDataWork.Payment8;
                    paymentDtlWork8.ValidityTerm = paymentDataWork.ValidityTerm8;
                    paymentDtlWorkList.Add(paymentDtlWork8);
                }
                if (paymentDataWork.PaymentRowNo9 > 0)
                {
                    PaymentDtlWork paymentDtlWork9 = new PaymentDtlWork();
                    paymentDtlWork9.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork9.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork9.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork9.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork9.PaymentRowNo = paymentDataWork.PaymentRowNo9;
                    paymentDtlWork9.MoneyKindCode = paymentDataWork.MoneyKindCode9;
                    paymentDtlWork9.MoneyKindName = paymentDataWork.MoneyKindName9;
                    paymentDtlWork9.MoneyKindDiv = paymentDataWork.MoneyKindDiv9;
                    paymentDtlWork9.Payment = paymentDataWork.Payment9;
                    paymentDtlWork9.ValidityTerm = paymentDataWork.ValidityTerm9;
                    paymentDtlWorkList.Add(paymentDtlWork9);
                }
                if (paymentDataWork.PaymentRowNo10 > 0)
                {
                    PaymentDtlWork paymentDtlWork10 = new PaymentDtlWork();
                    paymentDtlWork10.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork10.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork10.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork10.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork10.PaymentRowNo = paymentDataWork.PaymentRowNo10;
                    paymentDtlWork10.MoneyKindCode = paymentDataWork.MoneyKindCode10;
                    paymentDtlWork10.MoneyKindName = paymentDataWork.MoneyKindName10;
                    paymentDtlWork10.MoneyKindDiv = paymentDataWork.MoneyKindDiv10;
                    paymentDtlWork10.Payment = paymentDataWork.Payment10;
                    paymentDtlWork10.ValidityTerm = paymentDataWork.ValidityTerm10;
                    paymentDtlWorkList.Add(paymentDtlWork10);
                }

                if (paymentDtlWorkList != null && paymentDtlWorkList.Count > 0)
                {
                    paymentDtlWorkArray = (PaymentDtlWork[])paymentDtlWorkList.ToArray(typeof(PaymentDtlWork));
                }
                # endregion
            }
        }

        /// <summary>
        /// �x���f�[�^���x���`�[�f�[�^�Ǝx�����׃f�[�^�ɕ������܂��B
        /// </summary>
        /// <param name="paymentDataWork">�x���f�[�^</param>
        /// <param name="paymentSlpWork">�������ꂽ�x���`�[�f�[�^</param>
        /// <param name="paymentDtlWorkArray">�������ꂽ�x�����׃f�[�^�̔z��</param>
        public static void Division(PaymentDataWork paymentDataWork, out PaymentSlpWork paymentSlpWork, out PaymentDtlWork[] paymentDtlWorkArray)
        {
            paymentSlpWork = new PaymentSlpWork();
            paymentDtlWorkArray = new PaymentDtlWork[0];
            PaymentDataUtil.DivisionRef(paymentDataWork, ref paymentSlpWork, ref paymentDtlWorkArray);
        }

    }
}
