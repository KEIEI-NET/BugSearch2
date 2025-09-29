//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/06/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/04/05  �C�����e : �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �e�c ���V
// �� �� ��  2013/08/07  �C�����e : PM-SCM�d�|�ꗗ��10556�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g��
// �� �� ��  2013/08/07  �C�����e : PM-SCM�d�|�ꗗ��10556�Ή����̏C��
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Other
{
    using SalesTtlStServer      = SingletonInstance<SalesTtlStAgent>;       // ����S�̐ݒ�}�X�^
    using SalesProcMoneyServer  = SingletonInstance<SalesProcMoneyAgent>;   // ������z�����敪�}�X�^
    // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ---------->>>>>
    using SalesDetailTuple = Tuple<
        List<SalesDetailWork>,  // ���㖾�׃f�[�^
        List<AcceptOdrCarWork>, // 
        List<StockSlipWork>,    // �d���f�[�^
        List<StockDetailWork>,  // �d�����׃f�[�^
        List<UOEOrderDtlWork>,  // UOE�󒍃f�[�^
        NullObject,
        NullObject,
        NullObject,
        NullObject,
        NullObject
    >;
    // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ----------<<<<<

    /// <summary>
    /// ����`�[���́A�������ϔ��s����̈ڐA�N���X
    /// </summary>
    public sealed class OtherAppComponent
    {
        #region <��ƃR�[�h>

        /// <summary>��ƃR�[�h</summary>
        private readonly string _enterpriseCode;
        /// <summary>��ƃR�[�h�擾���܂��B</summary>
        private string EnterpriseCode { get { return _enterpriseCode; } }

        #endregion // </��ƃR�[�h>

        #region <���_�R�[�h>

        /// <summary>���_�R�[�h</summary>
        private readonly string _sectionCode;
        /// <summary>���_�R�[�h���擾���܂��B</summary>
        private string SectionCode { get { return _sectionCode; } }

        #endregion // </���_�R�[�h>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        public OtherAppComponent(
            string enterpriseCode,
            string sectionCode
        )
        {
            _enterpriseCode = enterpriseCode;
            _sectionCode    = sectionCode;
        }

        #endregion // </Constructor>

        #region <���` I/O Writer �̓����n�p�����[�^�֘A>

        #region <Const>

        /// <summary>
        /// �󒍃X�e�[�^�X
        /// </summary>
        public enum AcptAnOdrStatusState : int
        {
            /// <summary>����</summary>
            Estimate = 10,
            /// <summary>�P������</summary>
            UnitPriceEstimate = 15,
            /// <summary>��������</summary>
            SearchEstimate = 16,
            /// <summary>��</summary>
            AcceptAnOrder = 20,
            /// <summary>����</summary>
            Sales = 30,
            /// <summary>�ݏo</summary>
            Shipment = 40,
        }

        /// <summary>
        /// ���|�敪
        /// </summary>
        public enum AccRecDivCd : int
        {
            /// <summary>���|�Ȃ�</summary>
            NonAccRec = 0,
            /// <summary>���|</summary>
            AccRec = 1,
        }

        /// <summary>
        /// ���i�敪
        /// </summary>
        public enum SalesGoodsCd : int
        {
            /// <summary>���i</summary>
            Goods = 0,
            /// <summary>���i�O</summary>
            NonGoods = 1,
            /// <summary>����Œ���</summary>
            ConsTaxAdjust = 2,
            /// <summary>�c������</summary>
            BalanceAdjust = 3,
            /// <summary>���|�p����Œ���</summary>
            AccRecConsTaxAdjust = 4,
            /// <summary>���|�p�c������</summary>
            AccRecBalanceAdjust = 5,
        }

        /// <summary>����`�[�ԍ������l</summary>
        public static readonly string ctDefaultSalesSlipNum = string.Empty.PadLeft(9, '0');

        #endregion // </Const>

        /// <summary>
        /// ����S�̐ݒ���擾���܂��B
        /// </summary>
        /// <returns>����S�̐ݒ�</returns>
        private SalesTtlSt GetSalesTtlSt()
        {
            return SalesTtlStServer.Singleton.Instance.Find(EnterpriseCode, SectionCode) ?? new SalesTtlSt();
        }

        /// <summary>�����f�[�^</summary>
        private SearchDepsitMain _depsitMain = new SearchDepsitMain();
        /// <summary>���������f�[�^</summary>
        private SearchDepositAlw _depositAlw = new SearchDepositAlw();

        // MAHNB01012AA 8755�s��
        #region �������f�[�^�I�u�W�F�N�g�擾

        /// <summary>
        /// ���݂̔���f�[�^�I�u�W�F�N�g��������f�[�^�I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="depsitMain">�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="depositAlw">���������f�[�^�I�u�W�F�N�g</param>
        public void GetCurrentDepsitMain(
            ref SalesSlip salesSlip,
            out SearchDepsitMain depsitMain,
            out SearchDepositAlw depositAlw
        )
        {
            depsitMain = new SearchDepsitMain();

            //-----------------------------------------------------------------------------
            // �Ώۋ��z�Z�o
            //-----------------------------------------------------------------------------
            long totalPrice = salesSlip.SalesTotalTaxInc;
            if (salesSlip.TotalAmountDispWayCd == (int)SalesSlipInputAcs.TotalAmountDispWayCd.NoTotalAmount)
            {
                // ���z�\�����Ȃ�
                switch (salesSlip.ConsTaxLayMethod)
                {
                    case 0: // �`�[�]��
                    case 1: // ���ד]��
                        break;
                    case 2: // �����e
                    case 3: // �����q
                    case 9: // ��ې�
                        // �����v
                        totalPrice = salesSlip.ItdedSalesInTax + salesSlip.ItdedSalesOutTax + salesSlip.SalSubttlSubToTaxFre +
                                     salesSlip.ItdedSalesDisOutTax + salesSlip.ItdedSalesDisInTax + salesSlip.ItdedSalesDisTaxFre +
                                     salesSlip.SalAmntConsTaxInclu + salesSlip.SalesDisTtlTaxInclu;
                        break;
                }
            }

            //-----------------------------------------------------------------------------
            // ����`���u����ׁv�A�u���|�����v�A���i�敪�u���i�v�A���������敪�u����v�̏ꍇ�͎��������쐬
            //-----------------------------------------------------------------------------
            if ((salesSlip.AcptAnOdrStatusDisplay == (int)AcptAnOdrStatusState.Sales) &&
                (salesSlip.AccRecDivCd == (int)AccRecDivCd.NonAccRec) &&
                (salesSlip.SalesGoodsCd == (int)SalesGoodsCd.Goods) &&
                (GetSalesTtlSt().AutoDepositCd == (int)SalesSlipInputAcs.AutoDepositCd.Write))
            {
                // �C���`�[�̏ꍇ�̓L���b�V�����Ă���f�[�^����擾����
                if (salesSlip.SalesSlipNum.PadLeft(9, '0') != ctDefaultSalesSlipNum)
                {
                    // ���������f�[�^�쐬���̔���f�[�^�͏C���s�B
                    // ����
                    depsitMain = this._depsitMain.Clone();
                    depositAlw = this._depositAlw.Clone();
                }
                else
                {
                    // �V�K
                    depsitMain = new SearchDepsitMain();
                    depositAlw = new SearchDepositAlw();

                    depsitMain.DepositRowNo[0] = 1; // �����s�ԍ�
                    depsitMain.MoneyKindCode[0] = GetSalesTtlSt().AutoDepoKindCode; // ��������R�[�h
                    depsitMain.MoneyKindName[0] = GetSalesTtlSt().AutoDepoKindName; // �������햼��
                    depsitMain.MoneyKindDiv[0] = GetSalesTtlSt().AutoDepoKindDivCd; // ��������敪

                    depsitMain.ClaimName = salesSlip.ClaimName; // �����於��
                    depsitMain.ClaimName2 = salesSlip.ClaimName2; // �����於�̂Q
                    salesSlip.AutoDepositCd = 1; // ���������敪(1:��������)
                    salesSlip.DepositAlwcBlnce = totalPrice; // ���������c��
                    salesSlip.DepositAllowanceTtl = 0; // �����������v�z
                }
            }
            else
            {
                depsitMain = new SearchDepsitMain();
                depositAlw = new SearchDepositAlw();

                salesSlip.DepositAlwcBlnce = totalPrice; // ���������c��
                salesSlip.DepositAllowanceTtl = 0; // �����������v�z
            }

        }

        #endregion

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="searchDepsitMain">�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="work"></param>
        /// <returns>�������[�N�I�u�W�F�N�g</returns>
        public static DepsitDataWork ParamDataFromUIDataProc(SearchDepsitMain searchDepsitMain, out DepsitMainWork work)
        {
            DepsitDataWork depsitDataWork = new DepsitDataWork();
            DepsitMainWork depsitMainWork = new DepsitMainWork();
            DepsitDtlWork[] depsitDtlWorkArray = new DepsitDtlWork[searchDepsitMain.DepositRowNo.Length];

            depsitMainWork.CreateDateTime = searchDepsitMain.CreateDateTime; // �쐬����
            depsitMainWork.UpdateDateTime = searchDepsitMain.UpdateDateTime; // �X�V����
            depsitMainWork.EnterpriseCode = searchDepsitMain.EnterpriseCode; // ��ƃR�[�h
            depsitMainWork.FileHeaderGuid = searchDepsitMain.FileHeaderGuid; // GUID
            depsitMainWork.UpdEmployeeCode = searchDepsitMain.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            depsitMainWork.UpdAssemblyId1 = searchDepsitMain.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            depsitMainWork.UpdAssemblyId2 = searchDepsitMain.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            depsitMainWork.LogicalDeleteCode = searchDepsitMain.LogicalDeleteCode; // �_���폜�敪
            depsitMainWork.AcptAnOdrStatus = searchDepsitMain.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            depsitMainWork.DepositDebitNoteCd = searchDepsitMain.DepositDebitNoteCd; // �����ԍ��敪
            depsitMainWork.DepositSlipNo = searchDepsitMain.DepositSlipNo; // �����`�[�ԍ�
            depsitMainWork.SalesSlipNum = searchDepsitMain.SalesSlipNum; // ����`�[�ԍ�
            depsitMainWork.InputDepositSecCd = searchDepsitMain.InputDepositSecCd; // �������͋��_�R�[�h
            depsitMainWork.AddUpSecCode = searchDepsitMain.AddUpSecCode; // �v�㋒�_�R�[�h
            depsitMainWork.UpdateSecCd = searchDepsitMain.UpdateSecCd; // �X�V���_�R�[�h
            depsitMainWork.SubSectionCode = searchDepsitMain.SubSectionCode; // ����R�[�h
            depsitMainWork.DepositDate = searchDepsitMain.DepositDate; // �������t
            depsitMainWork.AddUpADate = searchDepsitMain.AddUpADate; // �v����t
            depsitMainWork.DepositTotal = searchDepsitMain.DepositTotal; // �����v
            depsitMainWork.Deposit = searchDepsitMain.Deposit; // �������z
            depsitMainWork.FeeDeposit = searchDepsitMain.FeeDeposit; // �萔�������z
            depsitMainWork.DiscountDeposit = searchDepsitMain.DiscountDeposit; // �l�������z
            depsitMainWork.AutoDepositCd = searchDepsitMain.AutoDepositCd; // ���������敪
            depsitMainWork.DraftDrawingDate = searchDepsitMain.DraftDrawingDate; // ��`�U�o��
            depsitMainWork.DraftKind = searchDepsitMain.DraftKind; // ��`���
            depsitMainWork.DraftKindName = searchDepsitMain.DraftKindName; // ��`��ޖ���
            depsitMainWork.DraftDivide = searchDepsitMain.DraftDivide; // ��`�敪
            depsitMainWork.DraftDivideName = searchDepsitMain.DraftDivideName; // ��`�敪����
            depsitMainWork.DraftNo = searchDepsitMain.DraftNo; // ��`�ԍ�
            depsitMainWork.DepositAllowance = searchDepsitMain.DepositAllowance; // ���������z
            depsitMainWork.DepositAlwcBlnce = searchDepsitMain.DepositAlwcBlnce; // ���������c��
            depsitMainWork.DebitNoteLinkDepoNo = searchDepsitMain.DebitNoteLinkDepoNo; // �ԍ������A���ԍ�
            depsitMainWork.LastReconcileAddUpDt = searchDepsitMain.LastReconcileAddUpDt; // �ŏI�������݌v���
            depsitMainWork.DepositAgentCode = searchDepsitMain.DepositAgentCode; // �����S���҃R�[�h
            depsitMainWork.DepositAgentNm = searchDepsitMain.DepositAgentNm; // �����S���Җ���
            depsitMainWork.DepositInputAgentCd = searchDepsitMain.DepositInputAgentCd; // �������͎҃R�[�h
            depsitMainWork.DepositInputAgentNm = searchDepsitMain.DepositInputAgentNm; // �������͎Җ���
            depsitMainWork.CustomerCode = searchDepsitMain.CustomerCode; // ���Ӑ�R�[�h
            depsitMainWork.CustomerName = searchDepsitMain.CustomerName; // ���Ӑ於��
            depsitMainWork.CustomerName2 = searchDepsitMain.CustomerName2; // ���Ӑ於��2
            depsitMainWork.CustomerSnm = searchDepsitMain.CustomerSnm; // ���Ӑ旪��
            depsitMainWork.ClaimCode = searchDepsitMain.ClaimCode; // ������R�[�h
            depsitMainWork.ClaimName = searchDepsitMain.ClaimName; // �����於��
            depsitMainWork.ClaimName2 = searchDepsitMain.ClaimName2; // �����於��2
            depsitMainWork.ClaimSnm = searchDepsitMain.ClaimSnm; // �����旪��
            depsitMainWork.Outline = searchDepsitMain.Outline; // �`�[�E�v
            depsitMainWork.BankCode = searchDepsitMain.BankCode; // ��s�R�[�h
            depsitMainWork.BankName = searchDepsitMain.BankName; // ��s����

            work = depsitMainWork;

            for (int i = 0; i < searchDepsitMain.DepositRowNo.Length; i++)
            {
                DepsitDtlWork depsitDtlWork = new DepsitDtlWork();
                depsitDtlWork.DepositRowNo = searchDepsitMain.DepositRowNo[i]; // �����s�ԍ�
                depsitDtlWork.MoneyKindCode = searchDepsitMain.MoneyKindCode[i]; // ����R�[�h
                depsitDtlWork.MoneyKindName = searchDepsitMain.MoneyKindName[i]; // ���햼��
                depsitDtlWork.MoneyKindDiv = searchDepsitMain.MoneyKindDiv[i]; // ����敪
                depsitDtlWork.Deposit = searchDepsitMain.DepositDtl[i]; // �������z
                depsitDtlWork.ValidityTerm = searchDepsitMain.ValidityTerm[i]; // �L������
                depsitDtlWorkArray[i] = depsitDtlWork;
            }

            DepsitDataUtil.Union(out depsitDataWork, depsitMainWork, depsitDtlWorkArray);

            return depsitDataWork;
        }

        /// <summary>
        /// ���������f�[�^�̃��[�N�^�֕ϊ����܂��B
        /// </summary>
        /// <param name="src">���������f�[�^</param>
        /// <returns>���������f�[�^�̃��[�N�^</returns>
        public static DepositAlwWork ConvertWork(SearchDepositAlw src)
        {
            DepositAlwWork work = new DepositAlwWork();
            {
                work.AcptAnOdrStatus = src.AcptAnOdrStatus;
                work.AddUpSecCode = src.AddUpSecCode;
                work.CustomerCode = src.CustomerCode;
                work.CustomerName = src.CustomerName;
                work.CustomerName2 = src.CustomerName2;
                work.DebitNoteOffSetCd = src.DebitNoteOffSetCd;
                work.DepositAgentCode = src.DepositAgentCode;
                work.DepositAgentNm = src.DepositAgentNm;
                work.DepositAllowance = src.DepositAllowance;
                work.DepositSlipNo = src.DepositSlipNo;
                work.EnterpriseCode = src.EnterpriseCode;
                work.FileHeaderGuid = src.FileHeaderGuid;
                work.InputDepositSecCd = src.InputDepositSecCd;
                work.LogicalDeleteCode = src.LogicalDeleteCode;
                work.ReconcileAddUpDate = src.ReconcileAddUpDate;
                work.ReconcileDate = src.ReconcileDate;
                work.SalesSlipNum = src.SalesSlipNum;
                work.UpdAssemblyId1 = src.UpdAssemblyId1;
                work.UpdAssemblyId2 = src.UpdAssemblyId2;
                work.UpdateDateTime = src.UpdateDateTime;
                work.UpdEmployeeCode = src.UpdEmployeeCode;
            }
            return work;
        }

        #endregion // </���` I/O Writer �̓����n�p�����[�^�֘A>

        #region <����f�[�^�̎Z�o�֘A>

        // PMMIT01012AC.cs
        /// <summary>
        /// �������ϗp�����l�擾�A�N�Z�X�N���X�̃��v���J
        /// </summary>
        private class EstimateInputInitDataAcs
        {

            #region <��ƃR�[�h>

            /// <summary>��ƃR�[�h</summary>
            private readonly string _enterpriseCode;
            /// <summary>��ƃR�[�h���擾���܂��B</summary>
            private string EnterpriseCode { get { return _enterpriseCode; } }

            #endregion // </��ƃR�[�h>

            #region <���_�R�[�h>

            /// <summary>���_�R�[�h</summary>
            private readonly string _sectionCode;
            /// <summary>���_�R�[�h���擾���܂��B</summary>
            public string SectionCode { get { return _sectionCode; } }

            #endregion // </���_�R�[�h>

            #region <Constructor>

            /// <summary>
            /// �J�X�^���R���X�g���N�^
            /// </summary>
            /// <param name="enterpriseCode">��ƃR�[�h</param>
            /// <param name="sectionCode">���_�R�[�h</param>
            public EstimateInputInitDataAcs(
                string enterpriseCode,
                string sectionCode
            )
            {
                _enterpriseCode = enterpriseCode;
                _sectionCode    = sectionCode;
            }

            #endregion // </Constructor>

            /// <summary>�[�������Ώۋ��z�敪�i����Łj</summary>
            public const int ctFracProcMoneyDiv_Tax = 1;
            /// <summary>�[�������Ώۋ��z�敪�i�P���j</summary>
            public const int ctFracProcMoneyDiv_UnitPrice = 2;

            /// <summary>������z�����敪�ݒ胊�X�g</summary>
            private List<SalesProcMoney> _salesProcMoneyList;
            /// <summary>������z�����敪�ݒ胊�X�g�̃��v���J���擾���܂��B</summary>
            private List<SalesProcMoney> SalesProcMoneyList
            {
                get
                {
                    if (_salesProcMoneyList == null)
                    {
                        _salesProcMoneyList = (List<SalesProcMoney>)SalesProcMoneyServer.Singleton.Instance.Find(
                            EnterpriseCode
                        );
                    }
                    return _salesProcMoneyList;
                }
            }

            // PMMIT01012AC.cs 1314�s��
            #region ��������z�����敪�ݒ�}�X�^ �f�[�^�擾�����֘A

            /// <summary>
            /// ������z�����敪�ݒ�}�X�^���A�Ώۋ��z�ɊY������[�������P�ʁA�[�������R�[�h���擾���܂��B
            /// </summary>
            /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
            /// <param name="fractionProcCode">�[�������R�[�h</param>
            /// <param name="price">�Ώۋ��z</param>
            /// <param name="fractionProcUnit">�[�������P��</param>
            /// <param name="fractionProcCd">�[�������敪</param>
            public void GetSalesFractionProcInfo(
                int fracProcMoneyDiv,
                int fractionProcCode,
                double price,
                out double fractionProcUnit,
                out int fractionProcCd
            )
            {
                //�f�t�H���g
                switch (fracProcMoneyDiv)
                {
                    case ctFracProcMoneyDiv_UnitPrice:	// �P��
                        fractionProcUnit = 0.01;
                        break;
                    default:
                        fractionProcUnit = 1;			// �P���ȊO��1�~�P��
                        break;
                }
                fractionProcCd = 1;     // �؎̂�

                if (SalesProcMoneyList == null || SalesProcMoneyList.Count == 0) return;

                List<SalesProcMoney> salesProcMoneyList = SalesProcMoneyList.FindAll(
                                            delegate(SalesProcMoney salesProcMoney)
                                            {
                                                if ((salesProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                                                    (salesProcMoney.FractionProcCode == fractionProcCode) &&
                                                    (salesProcMoney.UpperLimitPrice >= price))
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    return false;
                                                }
                                            });
                if (salesProcMoneyList != null && salesProcMoneyList.Count > 0)
                {
                    fractionProcUnit = salesProcMoneyList[0].FractionProcUnit;
                    fractionProcCd = salesProcMoneyList[0].FractionProcCd;
                }
            }

            #endregion
        }

        /// <summary>�������ϗp�����l�擾�A�N�Z�X�N���X</summary>
        private EstimateInputInitDataAcs _estimateInputInitDataAcs;
        /// <summary>�������ϗp�����l�擾�A�N�Z�X�N���X�̃��v���J���擾���܂��B</summary>
        private EstimateInputInitDataAcs EstimateInputInitDataAcsReplica
        {
            get
            {
                if (_estimateInputInitDataAcs == null)
                {
                    _estimateInputInitDataAcs = new EstimateInputInitDataAcs(EnterpriseCode, SectionCode);
                }
                return _estimateInputInitDataAcs;
            }
        }

        // PMMIT01012AA.cs 6202�s�� EstimateInputAcs.CalculationSalesTotalPrice()
        /// <summary>
        /// ������z�̍��v���v�Z���܂��B
        /// </summary>
        /// <param name="salesDetailList">���㖾�׃f�[�^���X�g</param>
        /// <param name="consTaxRate">����Őŗ�</param>
        /// <param name="fractionProcCd">����Œ[�������R�[�h</param>
        /// <param name="totalAmountDispWayCd">���z�\�����@�敪</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���</param>
        /// 
        /// <param name="salesTotalTaxInc">����`�[���v�i�ō��j</param>
        /// <param name="salesTotalTaxExc">����`�[���v�i�Ŕ��j</param>
        /// <param name="salesSubtotalTax">���㏬�v�i�Łj</param>
        /// <param name="itdedSalesOutTax">����O�őΏۊz</param>
        /// <param name="itdedSalesInTax">������őΏۊz</param>
        /// <param name="salSubttlSubToTaxFre">���㏬�v��ېőΏۊz</param>
        /// <param name="salesOutTax">������z����Ŋz�i�O�Łj</param>
        /// <param name="salAmntConsTaxInclu">������z����Ŋz�i���Łj</param>
        /// <param name="salesDisTtlTaxExc">����l�����z�v�i�Ŕ��j</param>
        /// <param name="itdedSalesDisOutTax">����l���O�őΏۊz���v</param>
        /// <param name="itdedSalesDisInTax">����l�����őΏۊz���v</param>
        /// <param name="itdedSalesDisTaxFre">����l����ېőΏۊz���v</param>
        /// <param name="salesDisOutTax">����l������Ŋz�i�O�Łj</param>
        /// <param name="salesDisTtlTaxInclu">����l������Ŋz�i���Łj</param>
        /// <param name="totalCost">�������z�v</param>
        /// 
        /// <param name="stockGoodsTtlTaxExc">�݌ɏ��i���v���z(�Ŕ�)</param>
        /// <param name="pureGoodsTtlTaxExc">�������i���v���z(�Ŕ�)</param>
        /// <param name="balanceAdjust">����Œ����z</param>
        /// <param name="taxAdjust">�c�������z</param>
        /// 
        /// <param name="salesPrtSubttlInc">���㕔�i���v�i�ō��j</param>
        /// <param name="salesPrtSubttlExc">���㕔�i���v�i�Ŕ��j</param>
        /// <param name="salesWorkSubttlInc">�����Ə��v�i�ō��j</param>
        /// <param name="salesWorkSubttlExc">�����Ə��v�i�Ŕ��j</param>
        /// <param name="itdedPartsDisInTax">���i�l���Ώۊz���v�i�ō��j</param>
        /// <param name="itdedPartsDisOutTax">���i�l���Ώۊz���v�i�Ŕ��j</param>
        /// <param name="itdedWorkDisInTax">��ƒl���Ώۊz���v�i�ō��j</param>
        /// <param name="itdedWorkDisOutTax">��ƒl���Ώۊz���v�i�Ŕ��j</param>
        /// 
        /// <param name="totalMoneyForGrossProfit">�e���v�Z�p������z</param>
        public void CalculationSalesTotalPrice(
            List<SalesDetail> salesDetailList,
            double consTaxRate,
            int fractionProcCd,
            int totalAmountDispWayCd,
            int consTaxLayMethod,
            // --- DEL 2013/08/07 T.Yoshioka ��10556 ---------->>>>>
            #region ���\�[�X
            //// --- ADD 2013/08/07 Y.Wakita ---------->>>>>
            //string enterpriseCode,
            //int customerCode,

            //out int taxFracProcCd,
            //// --- ADD 2013/08/07 Y.Wakita ----------<<<<<
            #endregion
            // --- DEL 2013/08/07 T.Yoshioka ��10556 ----------<<<<<
            out long salesTotalTaxInc,
            out long salesTotalTaxExc,
            out long salesSubtotalTax,
            out long itdedSalesOutTax,
            out long itdedSalesInTax,
            out long salSubttlSubToTaxFre,
            out long salesOutTax,
            out long salAmntConsTaxInclu,
            out long salesDisTtlTaxExc,
            out long itdedSalesDisOutTax,
            out long itdedSalesDisInTax,
            out long itdedSalesDisTaxFre,
            out long salesDisOutTax,
            out long salesDisTtlTaxInclu,
            out long totalCost,

            out long stockGoodsTtlTaxExc,
            out long pureGoodsTtlTaxExc,
            out long balanceAdjust,
            out long taxAdjust,

            out long salesPrtSubttlInc,
            out long salesPrtSubttlExc,
            out long salesWorkSubttlInc,
            out long salesWorkSubttlExc,
            out long itdedPartsDisInTax,
            out long itdedPartsDisOutTax,
            out long itdedWorkDisInTax,
            out long itdedWorkDisOutTax,

            out long totalMoneyForGrossProfit
        )
        {
            // --- DEL 2013/08/07 T.Yoshioka ��10556 ---------->>>>>
            #region ���\�[�X
            //// --- ADD 2013/08/07 Y.Wakita ---------->>>>>
            //// ���Ӑ�}�X�^�������Œ[�����������擾
            //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            //// ����Œ[������
            //int salesCnsTaxFrcProcCd = customerInfoAcs.GetSalesFractionProcCd(
            //    enterpriseCode,
            //    customerCode,
            //    CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            //);
            //// --- ADD 2013/08/07 Y.Wakita ----------<<<<<
            #endregion
            // --- DEL 2013/08/07 T.Yoshioka ��10556 ----------<<<<<

            // ����Œ[�������P�ʁA�[�������敪���擾
            // --- UPD 2013/08/07 T.Yoshioka ��10556 ---------->>>>>
            #region ���\�[�X
            //// --- DEL 2013/08/07 Y.Wakita ---------->>>>>
            ////int taxFracProcCd = 0;
            //// --- DEL 2013/08/07 Y.Wakita ----------<<<<<
            //double taxFracProcUnit = 0;
            //EstimateInputInitDataAcsReplica.GetSalesFractionProcInfo(
            //    EstimateInputInitDataAcs.ctFracProcMoneyDiv_Tax,
            //    // --- ADD 2013/08/07 Y.Wakita ---------->>>>>
            //    //fractionProcCd,
            //    salesCnsTaxFrcProcCd,
            //    // --- ADD 2013/08/07 Y.Wakita ----------<<<<<
            //    0,
            //    out taxFracProcUnit,
            //    out taxFracProcCd
            //);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            EstimateInputInitDataAcsReplica.GetSalesFractionProcInfo(
                EstimateInputInitDataAcs.ctFracProcMoneyDiv_Tax,
                fractionProcCd,
                0,
                out taxFracProcUnit,
                out taxFracProcCd
            );
            #endregion
            // --- UPD 2013/08/07 T.Yoshioka ��10556 ----------<<<<<

            salesTotalTaxInc = 0;       // ����`�[���v�i�ō��j
            salesTotalTaxExc = 0;       // ����`�[���v�i�Ŕ��j
            salesSubtotalTax = 0;       // ���㏬�v�i�Łj
            itdedSalesOutTax = 0;       // ����O�őΏۊz
            itdedSalesInTax = 0;        // ������őΏۊz
            salSubttlSubToTaxFre = 0;   // ���㏬�v��ېőΏۊz
            salesOutTax = 0;            // ������z����Ŋz�i�O�Łj
            salAmntConsTaxInclu = 0;    // ������z����Ŋz�i���Łj
            salesDisTtlTaxExc = 0;      // ����l�����z�v�i�Ŕ��j
            itdedSalesDisOutTax = 0;    // ����l���O�őΏۊz���v
            itdedSalesDisInTax = 0;     // ����l�����őΏۊz���v
            itdedSalesDisTaxFre = 0;    // ����l����ېőΏۊz���v
            salesDisOutTax = 0;         // ����l������Ŋz�i�O�Łj
            salesDisTtlTaxInclu = 0;    // ����l������Ŋz�i���Łj
            stockGoodsTtlTaxExc = 0;    // �݌ɏ��i���v���z�i�Ŕ��j
            pureGoodsTtlTaxExc = 0;     // �������i���v���z�i�Ŕ��j
            totalCost = 0;              // �������z�v
            taxAdjust = 0;              // ����Œ����z
            balanceAdjust = 0;          // �c�������z
            salesPrtSubttlInc = 0;      // ���㕔�i���v�i�ō��j
            salesPrtSubttlExc = 0;      // ���㕔�i���v�i�Ŕ��j
            salesWorkSubttlInc = 0;     // �����Ə��v�i�ō��j
            salesWorkSubttlExc = 0;     // �����Ə��v�i�Ŕ��j
            itdedPartsDisInTax = 0;     // ���i�l���Ώۊz���v�i�ō��j
            itdedPartsDisOutTax = 0;    // ���i�l���Ώۊz���v�i�Ŕ��j
            itdedWorkDisInTax = 0;      // ��ƒl���Ώۊz���v�i�ō��j
            itdedWorkDisOutTax = 0;     // ��ƒl���Ώۊz���v�i�Ŕ��j
            totalMoneyForGrossProfit = 0; // �e���v�Z�p������z

            long itdedSalesInTax_TaxInc = 0;    // ������őΏۊz�i�ō��j
            long itdedSalesDisInTax_TaxInc = 0; // ����l�����őΏۊz���v�i�ō��j
            long totalMoney_TaxInc_ForGrossProfitMoney = 0;     // �e���v�Z�p������z�v�i���ŏ��i���j
            long totalMoney_TaxExc_ForGrossProfitMoney = 0;     // �e���v�Z�p������z�v�i�O�ŏ��i���j
            long totalMoney_TaxNone_ForGrossProfitMoney = 0;    // �e���v�Z�p������z�v�i��ېŏ��i���j
            long stockGoodsTtlTaxExc_TaxInc = 0;                // �݌ɏ��i���v���z�i�Ŕ��j�i���ŏ��i���j
            long stockGoodsTtlTaxExc_TaxExc = 0;                // �݌ɏ��i���v���z�i�Ŕ��j�i�O�ŏ��i���j
            long stockGoodsTtlTaxExc_TaxNone = 0;               // �݌ɏ��i���v���z�i�Ŕ��j�i��ېŏ��i���j
            long pureGoodsTtlTaxExc_TaxInc = 0;                 // �������i���v���z�i�Ŕ��j�i���ŏ��i���j
            long pureGoodsTtlTaxExc_TaxExc = 0;                 // �������i���v���z�i�Ŕ��j�i�O�ŏ��i���j
            long pureGoodsTtlTaxExc_TaxNone = 0;                // �������i���v���z�i�Ŕ��j�i��ېŏ��i���j

            //-----------------------------------------------------------------------------
            // �v�Z�ɕK�v�ȋ��z�̌v�Z
            //-----------------------------------------------------------------------------
            #region ���v�Z�ɕK�v�ȋ��z�̌v�Z

            foreach (SalesDetail salesDetail in salesDetailList)
            {
                // ����`�[�敪�i���ׁj�ɂ���ďW�v���@���ς�镪
                switch (salesDetail.SalesSlipCdDtl)
                {
                    // ����A�ԕi
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales:
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods:
                        {
                            // �ŋ敪�F�O��
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                // ����O�őΏۊz
                                itdedSalesOutTax += salesDetail.SalesMoneyTaxExc;

                                // ������z����Ŋz�i�O�Łj
                                salesOutTax += salesDetail.SalesPriceConsTax;

                                // �݌ɏ��i���v���z�i�Ŕ��j�i�O�ŏ��i���j
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;

                                // �������i���v���z�i�Ŕ��j�i�O�ŏ��i���j
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                            }
                            // �ŋ敪�F����
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                // ������őΏۊz
                                itdedSalesInTax += salesDetail.SalesMoneyTaxExc;

                                // ������őΏۊz�i�ō��j
                                itdedSalesInTax_TaxInc += salesDetail.SalesMoneyTaxInc;

                                // ������z����Ŋz�i���Łj
                                salAmntConsTaxInclu += salesDetail.SalesPriceConsTax;

                                // �݌ɏ��i���v���z�i�Ŕ��j�i���ŏ��i���j
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                                // �������i���v���z�i�Ŕ��j�i���ŏ��i���j
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                            }
                            // �ŋ敪�F��ې�
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                // ���㏬�v��ېőΏۊz
                                salSubttlSubToTaxFre += salesDetail.SalesMoneyTaxInc;

                                // �݌ɏ��i���v���z�i�Ŕ��j�i��ېŏ��i���j
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                // �������i���v���z�i�Ŕ��j�i��ېŏ��i���j
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;
                            }

                            // ���㕔�i���v�i�ō��j
                            salesPrtSubttlInc += salesDetail.SalesMoneyTaxInc;
                            // ���㕔�i���v�i�Ŕ��j
                            salesPrtSubttlExc += salesDetail.SalesMoneyTaxExc;

                            // �������z�v
                            totalCost += salesDetail.Cost;

                            // �e���v�Z�p������z�v�i���ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // �e���v�Z�p������z�v�i�O�ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // �e���v�Z�p������z�v�i��ېŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            break;
                        }
                    // �l����
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount:
                        {
                            // �ŋ敪�F�O��
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                // ����l���O�őΏۊz���v
                                itdedSalesDisOutTax += salesDetail.SalesMoneyTaxExc;
                                // ����l������Ŋz�i�O�Łj
                                salesDisOutTax += salesDetail.SalesPriceConsTax;

                                // ���i�l�����̏ꍇ
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // �݌ɏ��i���v���z�i�Ŕ��j�i�O�ŏ��i���j
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;

                                    // �������i���v���z�i�Ŕ��j�i�O�ŏ��i���j
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                                }
                            }
                            // �ŋ敪�F����
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                // ����l�����őΏۊz���v
                                itdedSalesDisInTax += salesDetail.SalesMoneyTaxExc;
                                // ����l�����őΏۊz���v�i�ō��j
                                itdedSalesDisInTax_TaxInc += salesDetail.SalesMoneyTaxInc;
                                // ����l������Ŋz�i���Łj
                                salesDisTtlTaxInclu += salesDetail.SalesPriceConsTax;

                                // ���i�l�����̏ꍇ
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // �݌ɏ��i���v���z�i�Ŕ��j�i���ŏ��i���j
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                                    // �������i���v���z�i�Ŕ��j�i���ŏ��i���j
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;
                                }
                            }
                            // �ŋ敪�F��ې�
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                // ����l����ېőΏۊz���v
                                itdedSalesDisTaxFre += salesDetail.SalesMoneyTaxInc;

                                // ���i�l�����̏ꍇ
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // �݌ɏ��i���v���z�i�Ŕ��j�i��ېŏ��i���j
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                    // �������i���v���z�i�Ŕ��j�i��ېŏ��i���j
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                }
                            }

                            // ���i�l���Ώۊz���v�i�ō��j
                            itdedPartsDisInTax += salesDetail.SalesMoneyTaxInc;

                            // ���i�l���Ώۊz���v�i�Ŕ��j
                            itdedPartsDisOutTax += salesDetail.SalesMoneyTaxExc;

                            // �������z�v
                            totalCost += salesDetail.Cost;

                            // �e���v�Z�p������z�v�i���ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // �e���v�Z�p������z�v�i�O�ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // �e���v�Z�p������z�v�i��ېŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            break;
                        }
                    // ����
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Annotation:
                        {
                            break;
                        }
                    // ���
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Work:
                        {
                            // �������z�v
                            totalCost += salesDetail.Cost;

                            // �e���v�Z�p������z�v�i���ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // �e���v�Z�p������z�v�i�O�ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // �e���v�Z�p������z�v�i��ېŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }
                            break;
                        }
                    // ���v
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Subtotal:
                        {
                            break;
                        }
                }

                if (salesDetail.SalesSlipCdDtl != (int)SalesSlipInputAcs.SalesSlipCdDtl.Subtotal)
                {
                    // �c�������z
                    if ((salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.BalanceAdjust) ||
                        (salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecBalanceAdjust))
                    {
                        balanceAdjust += salesDetail.SalesMoneyTaxInc;
                    }

                    // ����Œ����z
                    if ((salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.ConsTaxAdjust) ||
                        (salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecConsTaxAdjust))
                    {
                        taxAdjust += salesDetail.SalesPriceConsTax;
                    }
                }
            }

            // ����l�����z�v�i�Ŕ��j
            salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

            // �e���v�Z�p������z�v
            totalMoneyForGrossProfit = totalMoney_TaxExc_ForGrossProfitMoney + totalMoney_TaxInc_ForGrossProfitMoney + totalMoney_TaxNone_ForGrossProfitMoney;

            // �݌ɏ��i���v���z�i�Ŕ��j
            stockGoodsTtlTaxExc = stockGoodsTtlTaxExc_TaxInc + stockGoodsTtlTaxExc_TaxExc + stockGoodsTtlTaxExc_TaxNone;

            // �������i���v���z�i�Ŕ��j
            pureGoodsTtlTaxExc = pureGoodsTtlTaxExc_TaxInc + pureGoodsTtlTaxExc_TaxExc + pureGoodsTtlTaxExc_TaxNone;

            #endregion

            #region ���]�ŕ����F��ېł̏ꍇ�ɋ��z�𒲐�����
            //-----------------------------------------------------------------------------
            // �]�ŕ����F��ېł̏ꍇ�ɋ��z�𒲐�����
            //-----------------------------------------------------------------------------
            if (consTaxLayMethod == 9)
            {
                // ������z����Ŋz�i�O�Łj
                salesOutTax = 0;

                // ������z����Ŋz�i���Łj
                salAmntConsTaxInclu = 0;

                // ���㏬�v��ېőΏۊz
                salSubttlSubToTaxFre += itdedSalesOutTax + itdedSalesInTax;

                // ����O�őΏۊz
                itdedSalesOutTax = 0;

                // ������őΏۊz
                itdedSalesInTax = 0;

                // ������őΏۊz�i�ō��j
                itdedSalesInTax_TaxInc = 0;

                // ����l������Ŋz�i�O�Łj
                salesDisOutTax = 0;

                // ����l������Ŋz�i���Łj
                salesDisTtlTaxInclu = 0;

                // ����l����ېőΏۊz���v
                itdedSalesDisTaxFre += itdedSalesDisOutTax + itdedSalesDisInTax;

                // ����l���O�őΏۊz���v
                itdedSalesDisOutTax = 0;

                // ����l�����őΏۊz���v
                itdedSalesDisInTax = 0;

                // ����l�����őΏۊz���v�i�ō��j
                itdedSalesDisInTax_TaxInc = 0;

                // ����l�����z�v�i�Ŕ��j
                salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;
            }
            #endregion

            #region ���e����z�Z�o
            //-----------------------------------------------------------------------------
            // �e����z�Z�o
            //-----------------------------------------------------------------------------

            // ���ד]�ňȊO
            if (consTaxLayMethod != 1)
            {
                //-----------------------------------------------------------------------------
                // �@ ����`�[���v�i�Ŕ��j�F����O�őΏۊz + ������őΏۊz + ����l���O�őΏۊz���v + ����l�����őΏۊz���v + ����l����ېőΏۊz���v
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

                //-----------------------------------------------------------------------------
                // �A ����`�[���v�i�ō��j�F ������őΏۊz�i�ō��j + ����O�őΏۊz + ����l�����őΏۊz���v�i�ō��j + ����l���O�őΏۊz���v + ����l����ېőΏۊz���v + (����O�őΏۊz + ����l���O�őΏۊz���v)�~�ŗ�)
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = itdedSalesInTax_TaxInc + itdedSalesOutTax + itdedSalesDisInTax_TaxInc + itdedSalesDisOutTax + itdedSalesDisTaxFre + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // �B ���㏬�v�i�Łj�F�A - �@
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesTotalTaxInc - salesTotalTaxExc;

                //-----------------------------------------------------------------------------
                // �C ������z����Ŋz�i�O�Łj�F����O�őΏۊz �~ �ŗ�
                //-----------------------------------------------------------------------------
                salesOutTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax);

                //-----------------------------------------------------------------------------
                // �D ������z����Ŋz�i�O�Łj(�Ŕ��A�l�����܂�) �F(����O�őΏۊz + ����l���O�őΏۊz���v) �~ �ŗ�
                //-----------------------------------------------------------------------------
                long salesOutTax_All = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // �E ����l������Ŋz�i�O�Łj�F�C - �D
                //-----------------------------------------------------------------------------
                salesDisOutTax = salesOutTax_All - salesOutTax;

                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //-----------------------------------------------------------------------------
                // �F ���㕔�i���v�i�ō��j�F(���㕔�i���v�i�Ŕ��j+ ���i�l���Ώۊz���v�i�Ŕ��j) �~ �ŗ�
                //-----------------------------------------------------------------------------
                salesPrtSubttlInc = salesPrtSubttlExc + itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesPrtSubttlExc + itdedPartsDisOutTax);

                //-----------------------------------------------------------------------------
                // �G ���i�l���Ώۊz���v�i�ō��j�F���i�l���Ώۊz���v�i�Ŕ��j�~ �ŗ�
                //-----------------------------------------------------------------------------
                itdedPartsDisInTax = itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedPartsDisOutTax);
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            // ���ד]��
            else
            {
                //-----------------------------------------------------------------------------
                // �@ ���㏬�v�i�Łj�F������z����Ŋz�i�O�Łj + ������z����Ŋz�i���Łj +  ����l������Ŋz�i�O�Łj + ����l������Ŋz�i���Łj
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesOutTax + salAmntConsTaxInclu + salesDisOutTax + salesDisTtlTaxInclu;

                //-----------------------------------------------------------------------------
                // �A ����`�[���v�i�Ŕ��j�F����O�őΏۊz + ������őΏۊz + ����l���O�őΏۊz���v + ����l�����őΏۊz���v
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax;

                //-----------------------------------------------------------------------------
                // �B ����`�[���v�i�ō��j�F�@ + �A
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            }
            #endregion
        }

        #endregion // </����f�[�^�̎Z�o�֘A>

        // MAHNB01012AB.cs 1310�s�ڂ��ڐA
        /// <summary>
        /// �q�Ƀ��X�g�ʒu�w��ǉ�����
        /// </summary>
        /// <param name="sectWarehouseCdList"></param>
        /// <param name="targetCode"></param>
        /// <param name="index"></param>
        /// <remarks>index�����X�g�����𒴂���ꍇ�A�ŏI�ɒǉ�</remarks>
        public static List<string> AddWarehouseList(List<string> sectWarehouseCdList, string targetCode, int index)
        {
            // �ݒ�R�[�h�s���ȏꍇ
            if ((targetCode == null) || (targetCode.Trim() == string.Empty)) return sectWarehouseCdList;

            List<string> warehouseList = new List<string>();

            // �w��Index�����X�g�����𒴂����ꍇ
            if (sectWarehouseCdList.Count - 1 < index)
            {
                warehouseList.AddRange(sectWarehouseCdList);
                warehouseList.Add(targetCode.Trim());
                return warehouseList;
            }

            int sectIndex = 0;

            for (int i = 0; i < sectWarehouseCdList.Count + 1; i++)
            {
                if (i == index)
                {
                    warehouseList.Add(targetCode.Trim());
                }
                else
                {
                    warehouseList.Add(sectWarehouseCdList[sectIndex]);
                    sectIndex++;
                }
            }
            return warehouseList;
        }

        // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ---------->>>>>
        #region <���όv��֘A>

        /// <summary>�Œ蔄�㖾�גʔ�</summary>
        private const long SALES_SLIP_DTL_NUM = 0;

        // MAHNB01012AA.cs 7789�s��(public int SalesDetailRowSettingFromSalHisRefResultParamWorkList(...))���ڐA
        /// <summary>
        /// ���㖾�׃f�[�^���������܂��B
        /// </summary>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="salesRowNo">�s�ԍ�</param>
        /// <returns>���㖾�׃f�[�^(��1�����o)�Ȃ�</returns>
        public SalesDetailTuple SearchSalesDetail(
            int acptAnOdrStatus,
            string salesSlipNum,
            int salesRowNo
        )
        {
            //---------------------------------------------------
            // ����f�[�^�Ǎ��p�����[�^�Z�b�g
            //---------------------------------------------------
            CustomSerializeArrayList paraList = new CustomSerializeArrayList();
            {
                SalesDetailWork salesDetailWork = new SalesDetailWork();
                {
                    salesDetailWork.EnterpriseCode  = EnterpriseCode;       // ��ƃR�[�h
                    salesDetailWork.AcptAnOdrStatus = acptAnOdrStatus;      // �󒍃X�e�[�^�X
                    salesDetailWork.SalesSlipNum    = salesSlipNum;         // ����`�[�ԍ�
                    salesDetailWork.SalesSlipDtlNum = SALES_SLIP_DTL_NUM;   // ���㖾�גʔ�
                    salesDetailWork.SalesRowNo = salesRowNo;                // ����s�ԍ�

                    paraList.Add(salesDetailWork);
                }
            }

            #region �������[�g�Q�Ɨp�p�����[�^
            //------------------------------------------------------
            // �����[�g�Q�Ɨp�p�����[�^
            //------------------------------------------------------
            IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();           // �����[�g�Q�Ɨp�p�����[�^
            SettingIOWriteCtrlOptWork(OptWorkSettingType.Read, out iOWriteCtrlOptWork); // �����[�g�Q�Ɨp�p�����[�^�ݒ菈��
            paraList.Add(iOWriteCtrlOptWork);
            #endregion

            object paraObj = (object)paraList;
            object retObj = null;
            object retObj2 = null;

            //---------------------------------------------------
            // ����f�[�^�ēǍ�
            //---------------------------------------------------
            IIOWriteControlDB ioWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
            int status = ioWriteControlDB.ReadDetail(ref paraObj, out retObj, out retObj2);

            CustomSerializeArrayList retList = (CustomSerializeArrayList)retObj;
            CustomSerializeArrayList retList2= (CustomSerializeArrayList)retObj2;
            if (retList != null) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //---------------------------------------------------
                // �f�[�^���X�g����
                //---------------------------------------------------
                SalesDetailWork[] salesDetailWorkArray;
                AcceptOdrCarWork[] acceptOdrCarWorkArray;
                StockSlipWork[] stockSlipWorkArray;
                StockDetailWork[] stockDetailWorkArray;
                UOEOrderDtlWork[] uoeOrderDtlWorkArray;
                DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForDetailsReading(
                    retList,
                    retList2,
                    out salesDetailWorkArray,
                    out acceptOdrCarWorkArray,
                    out stockSlipWorkArray,
                    out stockDetailWorkArray,
                    out uoeOrderDtlWorkArray
                );
                return new SalesDetailTuple(
                    new List<SalesDetailWork>(salesDetailWorkArray ?? new SalesDetailWork[0]),
                    new List<AcceptOdrCarWork>(acceptOdrCarWorkArray ?? new AcceptOdrCarWork[0]),
                    new List<StockSlipWork>(stockSlipWorkArray ?? new StockSlipWork[0]),
                    new List<StockDetailWork>(stockDetailWorkArray ?? new StockDetailWork[0]),
                    new List<UOEOrderDtlWork>(uoeOrderDtlWorkArray ?? new UOEOrderDtlWork[0]),
                    new NullObject(),
                    new NullObject(),
                    new NullObject(),
                    new NullObject(),
                    new NullObject()
                );
            }

            return new SalesDetailTuple(
                new List<SalesDetailWork>(new SalesDetailWork[0]),
                new List<AcceptOdrCarWork>(new AcceptOdrCarWork[0]),
                new List<StockSlipWork>(new StockSlipWork[0]),
                new List<StockDetailWork>(new StockDetailWork[0]),
                new List<UOEOrderDtlWork>(new UOEOrderDtlWork[0]),
                new NullObject(),
                new NullObject(),
                new NullObject(),
                new NullObject(),
                new NullObject()
            );
        }

        // MAHNB01012AA.cs 611�s�ڂ��ڐA
        /// <summary>
        /// �����[�g�Q�Ɨp�p�����[�^�ݒ菈��
        /// </summary>
        private enum OptWorkSettingType : int
        {
            /// <summary>�o�^</summary>
            Write = 0,
            /// <summary>�Ǎ�</summary>
            Read = 1,
            /// <summary>�폜</summary>
            Delete = 2,
        }

        // MAHNB01012AA.cs 17154�s�ڂ��ڐA
        /// <summary>
        /// �����[�g�Q�Ɨp�p�����[�^�ݒ菈��
        /// </summary>
        /// <param name="optWorkSettinType"></param>
        /// <param name="iOWriteCtrlOptWork"></param>
        private void SettingIOWriteCtrlOptWork(OptWorkSettingType optWorkSettinType, out IOWriteCtrlOptWork iOWriteCtrlOptWork)
        {
            iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
            {
                SalesTtlSt salesTtlSt = SalesTtlStServer.Singleton.Instance.Find(EnterpriseCode, SectionCode);
                if (salesTtlSt == null) return;

                iOWriteCtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;                              // ����N�_(0:���� 1:�d�� 2:�d�����㓯���v��)
                iOWriteCtrlOptWork.AcpOdrrAddUpRemDiv = salesTtlSt.AcpOdrrAddUpRemDiv;  // �󒍃f�[�^�v��c�敪(0:�c�� 1:�c���Ȃ�)
                iOWriteCtrlOptWork.ShipmAddUpRemDiv = salesTtlSt.ShipmAddUpRemDiv;      // �o�׃f�[�^�v��c�敪(0:�c�� 1:�c���Ȃ�)
                iOWriteCtrlOptWork.EstimateAddUpRemDiv = salesTtlSt.EstmateAddUpRemDiv; // ���σf�[�^�v��c�敪(0:�c�� 1:�c���Ȃ�)
                iOWriteCtrlOptWork.RetGoodsStockEtyDiv = salesTtlSt.RetGoodsStockEtyDiv;// �ԕi���݌ɓo�^�敪
                iOWriteCtrlOptWork.RemainCntMngDiv = 0;                                                                         // �c���Ǘ��敪(0:���� �Œ�Ƃ���)
                iOWriteCtrlOptWork.SupplierSlipDelDiv = salesTtlSt.SupplierSlipDelDiv;  // �d���`�[�폜�敪
                iOWriteCtrlOptWork.CarMngDivCd = 0;                                     // �ԗ��Ǘ��}�X�^�o�^�敪(0:�o�^���Ȃ� 1:�o�^����)
            }
            switch (optWorkSettinType)
            {
                case OptWorkSettingType.Read:
                    break;
                default:
                    throw new NotSupportedException("����`�[�f�[�^�̏�������э폜�����͖��T�|�[�g�ł��B");
            }
        }

        #endregion // </���όv��֘A>
        // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ----------<<<<<
    }
}
