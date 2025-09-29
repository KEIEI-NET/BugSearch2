//****************************************************************************//
// �V�X�e��         : �����d����M����
// �v���O��������   : �����d����M����Controller
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/11/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2009/10/14  �C�����e : ��M�d���ŁA���l���ڂɃX�y�[�X�������Ă����ꍇ�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2012/10/10  �C�����e : Redmine#32725 �����d����M�����^�d���f�[�^�쐬���̋��z�s���̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;       // 2009/10/14 Add

namespace Broadleaf.Application.Controller
{
    using LoginWorkerAcs= SingletonPolicy<LoginWorker>;
    using StockDB       = SingletonPolicy<StockDBAgent>;
    using SupplierDB    = SingletonPolicy<SupplierDBAgent>;
    using GoodsDB       = SingletonPolicy<GoodsDBAgent>;
    using TaxRateSetDB  = SingletonPolicy<TaxRateSetDBAgent>;
    using MakerMasterDB = SingletonPolicy<MakerMasterDBAgent>;

    /// <summary>
    /// �������̎d�����׃f�[�^�̍\�z�҃N���X
    /// </summary>
    public class OrderStockDetailDataBuilder : OrderInformationBuilder
    {
        #region <�i�����/>

        /// <summary>�������̃��b�Z�[�W</summary>
        protected const string NOW_RUNNING = "�d�����׃f�[�^(�������)���쐬��";    // LITERAL:

        /// <summary>�i�����</summary>
        private readonly UpdateProgressEventArgs _progressInfo = new UpdateProgressEventArgs(NOW_RUNNING, 0, 0);
        /// <summary>
        /// �i�������擾���܂��B
        /// </summary>
        protected UpdateProgressEventArgs ProgressInfo { get { return _progressInfo; } }

        /// <summary>�f�o�b�O�p�X�g�b�v�E�H�b�`</summary>
        private readonly Stopwatch _myStopWatch = new Stopwatch();
        /// <summary>
        /// �f�o�b�O�p�X�g�b�v�E�H�b�`���擾���܂��B
        /// </summary>
        /// <value>�f�o�b�O�p�X�g�b�v�E�H�b�`</value>
        private Stopwatch MyStopWatch { get { return _myStopWatch; } } 

        #endregion  // <�i�����/>

        #region <���݂̔������̎d�����׃f�[�^�̃��R�[�h/>

        /// <summary>���݂�UOE�����f�[�^�̖��׃��R�[�h</summary>
        private StockDetailWork _currentStockDetailRecord;
        /// <summary>
        /// ���݂�UOE�����f�[�^�̖��׃��R�[�h�̃A�N�Z�T
        /// </summary>
        /// <value>���݂�UOE�����f�[�^�̖��׃��R�[�h</value>
        private StockDetailWork CurrentStockDetailRecord
        {
            get { return _currentStockDetailRecord; }
            set { _currentStockDetailRecord = value; }
        }

        #endregion  // <���݂̔������̎d�����׃f�[�^�̃��R�[�h/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        /// <param name="receivedTelegramAgreegate">��M�d���̏W����</param>
        /// <param name="observer">�ȈՃI�u�U�[�o�[</param>
        public OrderStockDetailDataBuilder(
            UOESupplierHelper uoeSupplier,
            IAgreegate<ReceivedText> receivedTelegramAgreegate,
            IProgressUpdatable observer
        ) : base(uoeSupplier, receivedTelegramAgreegate, observer)
        { }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// �������̎d�����׃f�[�^�Ɏ�M�d�������UOE�����f�[�^�̓��e���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �������̎d�����׃f�[�^�̍\�z�ɂ����閾���Y�Ƃɂ��ꍇ������
        /// MergeStockUnitPriceFl()�F062.�d���P���i�Ŕ�, �����j���}�[�W
        /// �݂̂ł��B
        /// ��L���\�b�h�ȊO�ł��ꍇ������������������ꍇ�A�����Y�Ɨp�̃T�u�N���X�����������邱�ƁB
        /// </remarks>
        public override void Merge()
        {
            ProgressInfo.IsRunning = true;

            foreach (IList<ReceivedText> uoeSlip in ReceivedTelegramAgreegate.GroupedListMap.Values)
            {
                ProgressInfo.Max += uoeSlip.Count;
            }

            // �o�ד`�[�ԍ��̃��[�v
            foreach (IList<ReceivedText> uoeSlip in ReceivedTelegramAgreegate.GroupedListMap.Values)
            {
                // ����o�ד`�[�ԍ��ɂ������M�e�L�X�g�i���ׁj�̃��[�v
                foreach (ReceivedText receivedTelegram in uoeSlip)
                {
                    Observer.Update(ProgressInfo);

                    bool isNewRecord = false;

                    // UOE�����ԍ��� 0 �̖��ׂɊւ��ẮiUOE�������͊��ɍ쐬����Ă���j
                    // �d�����׃f�[�^�i�����j�̍쐬���s��
                    if (receivedTelegram.IsTelephoneOrder())
                    {
                        // TEL�������i�d���⍇���ԍ� == 0�j�c���ʂɐV�K�o�^
                        CurrentStockDetailRecord = new StockDetailWork();
                        isNewRecord = true;
                    }
                    else
                    {
                        // UOE�������i�d���⍇���ԍ� != 0�j�c�����̃��R�[�h�����ɐV�K�o�^
                        CurrentStockDetailRecord = StockDB.Instance.Policy.FindStockDetailWork(receivedTelegram);
                        if (CurrentStockDetailRecord == null)
                        {
                            CurrentStockDetailRecord = new StockDetailWork();
                            isNewRecord = true;
                            Debug.WriteLine("�I�����C�������̃f�[�^��d�b�����Ƃ݂Ȃ��Ă��܂��B");
                        }
                        if (!isNewRecord)
                        {
                            // �o�^�ς݂̔������͊�{�I�ɂ��̂܂�
                            MergeStockRowNo(receivedTelegram);      // 012.�d���s�ԍ�
                            MergeWarehouseCode(receivedTelegram);   // 044.�q�ɃR�[�h
                            MergeWarehouseName(receivedTelegram);   // 045.�q�ɖ���
                            MergeWarehouseShelfNo(receivedTelegram);// 046.�q�ɒI��
                            MergeStockCount(receivedTelegram);      // 073.�d����
                            MergeDtlRelationGuid(receivedTelegram); // 105.���׊֘A�t��GUID
                            // ----- ADD 2012/10/10 �c���� Redmine#32725 ---------------------->>>>>
                            MergeStockPriceTaxExc(receivedTelegram);    // 078.�d�����z�i�Ŕ����j
                            MergeStockPriceTaxInc(receivedTelegram);    // 079.�d�����z�i�ō��݁j
                            // ----- ADD 2012/10/10 �c���� Redmine#32725 ----------------------<<<<<
                            continue;
                        }
                    }
                    CurrentUnitCost = CalculateUnitCost(receivedTelegram, UoeSupplier);

                    // ��M�d�������UOE�����f�[�^�̓��e���}�[�W
                    MergeEnterpriseCode(receivedTelegram);      // 003.��ƃR�[�h
                    MergeSupplierFormal(receivedTelegram);      // 010.�d���`��
                    MergeStockRowNo(receivedTelegram);          // 012.�d���s�ԍ�
                    MergeSectionCode(receivedTelegram);         // 013.���_�R�[�h
                    MergeSubSectionCode(receivedTelegram);      // 014.����R�[�h
                    MergeStockInputCode(receivedTelegram);      // 022.�d�����͎҃R�[�h
                    MergeStockInputName(receivedTelegram);      // 023.�d�����͎Җ���
                    MergeStockAgentCode(receivedTelegram);      // 024.�d���S���҃R�[�h
                    MergeStockAgentName(receivedTelegram);      // 025.�d���S���Җ���
                    MergeGoodsMakerCd(receivedTelegram);        // 027.���i���[�J�[�R�[�h
                    MergeMakerName(receivedTelegram);           // 028.���[�J�[����
                    MergeMakerKanaName(receivedTelegram);       // 029.���[�J�[�J�i����
                    MergeGoodsNo(receivedTelegram);             // 031.���i�ԍ�
                    MergeGoodsKindCode(receivedTelegram);       // 026.���i�����@�����i�ԍ��Ō����ƂȂ邽�߁A031.���i�ԍ��̃}�[�W��ɏ������s��
                    MergeGoodsName(receivedTelegram);           // 032.���i����
                    MergeGoodsNameKana(receivedTelegram);       // 033.���i���̃J�i
                    MergeGoodsLGroup(receivedTelegram);         // 034.���i�啪�ރR�[�h
                    MergeGoodsLGroupName(receivedTelegram);     // 035.���i�啪�ޖ���
                    MergeGoodsMGroup(receivedTelegram);         // 036.���i�����ރR�[�h
                    MergeGoodsMGroupName(receivedTelegram);     // 037.���i�����ޖ���
                    MergeBLGroupCode(receivedTelegram);         // 038.BL�O���[�v�R�[�h
                    MergeBLGroupName(receivedTelegram);         // 039.BL�O���[�v����
                    MergeBLGoodsCode(receivedTelegram);         // 040.BL���i�R�[�h
                    MergeBLGoodsFullName(receivedTelegram);     // 041.BL���i���́i�S�p�j
                    MergeEnterpriseGanreCode(receivedTelegram); // 042.���Е��ރR�[�h
                    MergeEnterpriseGanreName(receivedTelegram); // 043.���Е��ޖ���
                    MergeWarehouseCode(receivedTelegram);       // 044.�q�ɃR�[�h
                    MergeWarehouseName(receivedTelegram);       // 045.�q�ɖ���
                    MergeWarehouseShelfNo(receivedTelegram);    // 046.�q�ɒI��
                    MergeStockOrderDivCd(receivedTelegram);     // 047.�d���݌Ɏ�񂹋敪
                    MergeOpenPriceDiv(receivedTelegram);        // 048.�I�[�v�����i�敪
                    MergeGoodsRateRank(receivedTelegram);       // 049.���i�|�������N
                    MergeTaxationCode(receivedTelegram);        // 082.�ېŋ敪 ���艿�A�d���P���̉��Z�ɂĎg�p���邽�߁A����ȑO�ɐݒ�
                    MergeListPriceTaxExcFl(receivedTelegram);   // 052.�艿�i�Ŕ�, �����j ��053.�艿�i�ō�, �����j�̉��Z�ɂĎg�p
                    MergeListPriceTaxIncFl(receivedTelegram);   // 053.�艿�i�ō�, �����j
                    MergeStockUnitPriceFl(receivedTelegram);    // 062.�d���P���i�Ŕ�, �����j ��063.�d���P���i�ō�, �����j�̉��Z�ɂĎg�p
                    MergeStockUnitTaxPriceFl(receivedTelegram); // 063.�d���P���i�ō�, �����j
                    MergeStockUnitChngDiv(receivedTelegram);    // 064.�d���P���ύX�敪
                    MergeBfStockUnitPriceFl(receivedTelegram);  // 065.�ύX�O�d���P���i�����j
                    MergeBfListPrice(receivedTelegram);         // 066.�ύX�O�艿
                    MergeStockCount(receivedTelegram);          // 073.�d���� ���d�����z�̉��Z�ɂĎg�p���邽�߁A����ȑO�ɐݒ�
                    MergeOrderCnt(receivedTelegram);            // 074.��������
                    MergeOrderRemainCnt(receivedTelegram);      // 076.�����c��
                    MergeOrderAdjustCnt(receivedTelegram);      // 075.���������� ������������ = �����c�� - ��������
                    MergeStockPriceTaxExc(receivedTelegram);    // 078.�d�����z�i�Ŕ����j
                    MergeStockPriceTaxInc(receivedTelegram);    // 079.�d�����z�i�ō��݁j
                    MergeStockGoodsCd(receivedTelegram);        // 080.�d�����i�敪
                    MergeStockPriceConsTax(receivedTelegram);   // 081.�d�����z����Ŋz
                    MergeSupplierCd(receivedTelegram);          // 092.�d����R�[�h
                    MergeSupplierSnm(receivedTelegram);         // 093.�d���旪��
                    MergeWayToOrder(receivedTelegram);          // 098.�������@
                    MergeOrderDataCreateDate(receivedTelegram); // 102.�����f�[�^�쐬��
                    MergeOrderFormIssuedDiv(receivedTelegram);  // 103.���������s�ϋ敪

                    MergeDtlRelationGuid(receivedTelegram);     // 105.���׊֘A�t��GUID

                    // DB�֑}���p�Ƀ��R�[�h��ǉ�
                    if (isNewRecord)
                    {
                        StockDB.Instance.Policy.AddStockDetailWork(CurrentStockDetailRecord, receivedTelegram);
                    }

                    ProgressInfo.Count++;
                }   // foreach (ReceivedText receivedTelegram in uoeSlip)
            }   // foreach (IList<ReceivedText> uoeSlip in ReceivedTelegramAgreegate.GroupedListMap.Values)

            ProgressInfo.IsRunning = false;
        }

        #endregion  // <Override/>

        #region <003.��ƃR�[�h/>

        /// <summary>
        /// ��ƃR�[�h���}�[�W���܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeEnterpriseCode(ReceivedText receivedTelegram)
        {
            string enterpriseCode = LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code;
            CurrentStockDetailRecord.EnterpriseCode = enterpriseCode;
        }

        #endregion  // <003.��ƃR�[�h/>

        #region <010.�d���`��/>

        /// <summary>
        /// �d���`�����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 2:����
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeSupplierFormal(ReceivedText receivedTelegram)
        {
            const int ORDER = 2;    // ����
            CurrentStockDetailRecord.SupplierFormal = ORDER;
        }

        #endregion  // <010.�d���`��/>

        #region <�d���s�ԍ�/>

        /// <summary>�d���`�[�ԍ��ʂ̎d���s�ԍ��J�E���^�}�b�v�i�L�[�F�d���`�[�ԍ��j</summary>
        private readonly IDictionary<int, int> _stockRowNoCounterMap = new Dictionary<int, int>();
        /// <summary>
        /// �d���`�[�ԍ��ʂ̎d���s�ԍ��J�E���^�}�b�v�i�L�[�F�d���`�[�ԍ��j���擾���܂��B
        /// </summary>
        private IDictionary<int, int> StockRowNoCounterMap { get { return _stockRowNoCounterMap; } }

        /// <summary>
        /// �d���s�ԍ����擾���܂��B
        /// </summary>
        /// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
        /// <returns>
        /// �d���s�ԍ�
        /// �i�{���\�b�h���ďo�����ɃC���N�������g����܂��j
        /// </returns>
        private int GetStockRowNo(int supplierSlipNo)
        {
            if (!StockRowNoCounterMap.ContainsKey(supplierSlipNo))
            {
                StockRowNoCounterMap.Add(supplierSlipNo, 0);
            }
            int nextStockRowNo = ++StockRowNoCounterMap[supplierSlipNo];
            {
                StockRowNoCounterMap[supplierSlipNo] = nextStockRowNo;
            }
            return nextStockRowNo;
        }

        // HACK:�d���s�ԍ��i�d�b�����p�j�̃S�~�|��
        #region <�d�b�����p/>

        ///// <summary>�o�ד`�[�ԍ��ʂ̎d���s�ԍ��J�E���^�}�b�v�i�L�[�F�o�ד`�[�ԍ��j</summary>
        //private readonly IDictionary<string, int> _stockRowNoCounterOfTelOrderMap = new Dictionary<string, int>();
        ///// <summary>
        ///// �o�ד`�[�ԍ��ʂ̎d���s�ԍ��J�E���^�}�b�v�i�L�[�F�o�ד`�[�ԍ��j���擾���܂��B
        ///// </summary>
        //private IDictionary<string, int> StockRowNoCounterOfTelOrderMap { get { return _stockRowNoCounterOfTelOrderMap; } }

        ///// <summary>
        ///// �d���s�ԍ����擾���܂��B�i�d�b�����p�j
        ///// </summary>
        ///// <param name="uoeSectionSlipNo">�o�ד`�[�ԍ�</param>
        ///// <returns>
        ///// �d���s�ԍ�
        ///// �i�{���\�b�h���ďo�����ɃC���N�������g����܂��j
        ///// </returns>
        //private int GetStockRowNoOfTelOrder(string uoeSectionSlipNo)
        //{
        //    if (!StockRowNoCounterOfTelOrderMap.ContainsKey(uoeSectionSlipNo))
        //    {
        //        StockRowNoCounterOfTelOrderMap.Add(uoeSectionSlipNo.Trim(), 0);
        //    }
        //    int nextStockRowNo = ++StockRowNoCounterOfTelOrderMap[uoeSectionSlipNo];
        //    {
        //        StockRowNoCounterOfTelOrderMap[uoeSectionSlipNo] = nextStockRowNo;
        //    }
        //    return nextStockRowNo;
        //}

        #endregion  // <�d�b�����p/>

        #endregion  // <�d���s�ԍ�/>

        #region <012.�d���s�ԍ�/>

        /// <summary>
        /// �d���s�ԍ����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d���`�[�ԍ��P�ʂŘA�ԁi1�`�j
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeStockRowNo(ReceivedText receivedTelegram)
        {
            int stockRowNo = 0;
            if (receivedTelegram.IsTelephoneOrder())
            {
                stockRowNo = GetRowNoOfTelOrder(receivedTelegram.UOESectionSlipNo);
            }
            else
            {
                stockRowNo = GetStockRowNo(CurrentStockDetailRecord.SupplierSlipNo);
            }
            CurrentStockDetailRecord.StockRowNo = stockRowNo;
        }

        #endregion  // <012.�d���s�ԍ�/>

        #region <013.���_�R�[�h/>

        /// <summary>
        /// ���_�R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���O�C�������S���҂��������鋒�_�R�[�h
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeSectionCode(ReceivedText receivedTelegram)
        {
            string sectionCode = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
            CurrentStockDetailRecord.SectionCode = sectionCode;
        }

        #endregion  // <013.���_�R�[�h/>

        #region <014.����R�[�h/>

        /// <summary>
        /// ����R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���O�C�������S���҂��������镔��R�[�h
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeSubSectionCode(ReceivedText receivedTelegram)
        {
            int subSectionCode = LoginWorkerAcs.Instance.Policy.Detail.BelongSubSectionCode;
            CurrentStockDetailRecord.SubSectionCode = subSectionCode;
        }

        #endregion  // <014.����R�[�h/>

        #region <022.�d�����͎҃R�[�h/>

        /// <summary>
        /// �d�����͎҃R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���O�C���S����
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeStockInputCode(ReceivedText receivedTelegram)
        {
            string stockInputCode = LoginWorkerAcs.Instance.Policy.Profile.EmployeeCode;
            CurrentStockDetailRecord.StockInputCode = stockInputCode;
        }

        #endregion  // <022.�d�����͎҃R�[�h/>

        #region <023.�d�����͎Җ���/>

        /// <summary>
        /// �d�����͎Җ������}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���O�C���S���Җ���
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeStockInputName(ReceivedText receivedTelegram)
        {
            string stockInputName = LoginWorkerAcs.Instance.Policy.Profile.Name;
            CurrentStockDetailRecord.StockInputName = stockInputName;
        }

        #endregion  // <023.�d�����͎Җ���/>

        #region <024.�d���S���҃R�[�h/>

        /// <summary>
        /// �d���S���҃R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ������}�X�^�̈˗��ҁi���ݒ莞�̓��O�C���S���ҁj
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeStockAgentCode(ReceivedText receivedTelegram)
        {
            string stockAgentCode = UoeSupplier.AgentProfile.Code;
            if (string.IsNullOrEmpty(stockAgentCode))
            {
                stockAgentCode = LoginWorkerAcs.Instance.Policy.Profile.EmployeeCode;
            }
            CurrentStockDetailRecord.StockAgentCode = stockAgentCode;
        }

        #endregion  // <024.�d���S���҃R�[�h/>

        #region <025.�d���S���Җ���/>

        /// <summary>
        /// �d���S���Җ��̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d���S���҂̖���
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeStockAgentName(ReceivedText receivedTelegram)
        {
            string stockAgentName = UoeSupplier.AgentProfile.Name;
            if (string.IsNullOrEmpty(stockAgentName))
            {
                stockAgentName = LoginWorkerAcs.Instance.Policy.Profile.Name;
            }
            CurrentStockDetailRecord.StockAgentName = stockAgentName;
        }

        #endregion  // <025.�d���S���Җ���/>

        #region <026.���i����/>

        /// <summary>
        /// ���i�������}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���i���o�����N���X
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeGoodsKindCode(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                int goodsKindCode = goodsUnitData.GoodsKindCode;
                CurrentStockDetailRecord.GoodsKindCode = goodsKindCode;
            }
        }

        #endregion  // <026.���i����/>

        #region <027.���i���[�J�[�R�[�h/>

        /// <summary>
        /// ���i���[�J�[�R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����M�d���̃��[�J�[�R�[�h
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeGoodsMakerCd(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //int goodsMakerCd = int.Parse(receivedTelegram.AnswerMakerCode);
            int goodsMakerCd = TStrConv.StrToIntDef(receivedTelegram.AnswerMakerCode.Trim(), 0);
            // 2009/10/14 <<<
            CurrentStockDetailRecord.GoodsMakerCd = goodsMakerCd;
        }

        #endregion  // <027.���i���[�J�[�R�[�h/>

        #region <028.���[�J�[����/>

        /// <summary>
        /// ���[�J�[���̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���[�J�[�}�X�^����
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeMakerName(ReceivedText receivedTelegram)
        {
            MakerSet makerSet = MakerMasterDB.Instance.Policy.Find(CurrentStockDetailRecord.GoodsMakerCd);
            if (makerSet != null)
            {
                string makerName = makerSet.MakerName;
                CurrentStockDetailRecord.MakerName = makerName;
            }
        }

        #endregion  // <028.���[�J�[����/>

        #region <029.���[�J�[�J�i����/>

        /// <summary>
        /// ���[�J�[�J�i���̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���[�J�[�}�X�^����
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeMakerKanaName(ReceivedText receivedTelegram)
        {
            MakerSet makerSet = MakerMasterDB.Instance.Policy.Find(CurrentStockDetailRecord.GoodsMakerCd);
            if (makerSet != null)
            {
                string makerKanaName = makerSet.MakerKanaName;
                CurrentStockDetailRecord.MakerKanaName = makerKanaName;
            }
        }

        #endregion  // <029.���[�J�[�J�i����/>

        #region <031.���i�ԍ�/>

        /// <summary>
        /// ���i�ԍ����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����M�d���̏o�ו��i�ԍ�<br/>
        /// �@���i�ԍ��̃Z�b�g�ɂ���<br/>
        /// �i�Ԃ��X�y�[�X���ɂ͕i�����Z�b�g����
        /// �iSPK�ŗp�i��^�����A�i�Ԃ��X�y�[�X�ŕԂ��Ă���ꍇ������j
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeGoodsNo(ReceivedText receivedTelegram)
        {
            string goodsNo = receivedTelegram.ToGoodsNo();
            CurrentStockDetailRecord.GoodsNo = TrimEndCode(goodsNo);
        }

        #endregion  // <031.���i�ԍ�/>

        #region <032.���i����/>

        /// <summary>
        /// ���i���̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���i���o�����N���X�@���i�Ԗ����ݎ��ɂ͎d���d����̕i�����Z�b�g
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeGoodsName(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                string goodsName = goodsUnitData.GoodsName;
                CurrentStockDetailRecord.GoodsName = goodsName;
            }
            else
            {
                CurrentStockDetailRecord.GoodsName = receivedTelegram.AnswerPartsName;
            }
        }

        #endregion  // <032.���i����/>

        #region <033.���i���̃J�i/>

        /// <summary>
        /// ���i���̃J�i���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���i�A���f�[�^�N���X
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeGoodsNameKana(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                string goodsNameKana = goodsUnitData.GoodsNameKana;
                CurrentStockDetailRecord.GoodsNameKana = goodsNameKana;
            }
        }

        #endregion  // <033.���i���̃J�i/>

        #region <034.���i�啪�ރR�[�h/>

        /// <summary>
        /// ���i�啪�ރR�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���i�A���f�[�^�N���X
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeGoodsLGroup(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                int goodsLGroup = goodsUnitData.GoodsLGroup;
                CurrentStockDetailRecord.GoodsLGroup = goodsLGroup;
            }
        }

        #endregion  // <034.���i�啪�ރR�[�h/>

        #region <035.���i�啪�ޖ���/>

        /// <summary>
        /// ���i�啪�ޖ��̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���i�A���f�[�^�N���X
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeGoodsLGroupName(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                string goodsLGrouName = goodsUnitData.GoodsLGroupName;
                CurrentStockDetailRecord.GoodsLGroupName = goodsLGrouName;
            }
        }

        #endregion  // <035.���i�啪�ޖ���/>

        #region <036.���i�����ރR�[�h/>

        /// <summary>
        /// ���i�����ރR�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���i�A���f�[�^�N���X
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeGoodsMGroup(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                int goodsMGroup = goodsUnitData.GoodsMGroup;
                CurrentStockDetailRecord.GoodsMGroup = goodsMGroup;
            }
        }

        #endregion  // <036.���i�����ރR�[�h/>

        #region <037.���i�����ޖ���/>

        /// <summary>
        /// ���i�����ޖ��̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���i�A���f�[�^�N���X
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeGoodsMGroupName(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                string goodsMGroupName = goodsUnitData.GoodsMGroupName;
                CurrentStockDetailRecord.GoodsMGroupName = goodsMGroupName;
            }
        }

        #endregion  // <037.���i�����ޖ���/>

        #region <038.BL�O���[�v�R�[�h/>

        /// <summary>
        /// BL�O���[�v�R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���i�A���f�[�^�N���X
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeBLGroupCode(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                int blGroupCode = goodsUnitData.BLGroupCode;
                CurrentStockDetailRecord.BLGroupCode = blGroupCode;
            }
        }

        #endregion  // <038.BL�O���[�v�R�[�h/>

        #region <039.BL�O���[�v����/>

        /// <summary>
        /// BL�O���[�v���̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���i�A���f�[�^�N���X
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeBLGroupName(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                string blGroupName = goodsUnitData.BLGroupName;
                CurrentStockDetailRecord.BLGroupName = blGroupName;
            }
        }

        #endregion  // <039.BL�O���[�v����/>

        #region <040.BL���i�R�[�h/>

        /// <summary>
        /// BL���i�R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���i�A���f�[�^�N���X
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeBLGoodsCode(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                int blGoodsCode = goodsUnitData.BLGoodsCode;
                CurrentStockDetailRecord.BLGoodsCode = blGoodsCode;
            }
        }

        #endregion  // <040.BL���i�R�[�h/>

        #region <041.BL���i���́i�S�p�j/>

        /// <summary>
        /// BL���i���́i�S�p�j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���i�A���f�[�^�N���X
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeBLGoodsFullName(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                string blGoodsFullName = goodsUnitData.BLGoodsFullName;
                CurrentStockDetailRecord.BLGoodsFullName = blGoodsFullName;
            }
        }

        #endregion  // <041.BL���i���́i�S�p�j/>

        #region <042.���Е��ރR�[�h/>

        /// <summary>
        /// ���Е��ރR�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���i�A���f�[�^�N���X
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeEnterpriseGanreCode(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                int enterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;
                CurrentStockDetailRecord.EnterpriseGanreCode = enterpriseGanreCode;
            }
        }

        #endregion  // <042.���Е��ރR�[�h/>

        #region <043.���Е��ޖ���/>

        /// <summary>
        /// ���Е��ޖ��̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���i�A���f�[�^�N���X
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeEnterpriseGanreName(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                string enterpriseGanreName = goodsUnitData.EnterpriseGanreName;
                CurrentStockDetailRecord.EnterpriseGanreName = enterpriseGanreName;
            }
        }

        #endregion  // <043.���Е��ޖ���/>

        #region <044.�q�ɃR�[�h/>

        /// <summary>
        /// �q�ɃR�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̓d���⍇���ԍ���<c>0</c>�̏ꍇ�ɂ́A
        /// ���_�ݒ�}�X�^�̑q�ɃR�[�h�i3�j��
        /// ��M�d���̏o�ו��i�ԍ��A���[�J�[�R�[�h��
        /// �݌Ƀ}�X�^�̑��݃`�F�b�N���s�����݂���q�ɃR�[�h���Z�b�g����
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected virtual void MergeWarehouseCode(ReceivedText receivedTelegram)
        {
            UOEOrderDtlWork uoeOrderDetailRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(receivedTelegram);
            if (uoeOrderDetailRecord != null)
            {
                string warehouseCode = uoeOrderDetailRecord.WarehouseCode;
                CurrentStockDetailRecord.WarehouseCode = warehouseCode;
            }
        }

        #endregion  // <044.�q�ɃR�[�h/>

        #region <045.�q�ɖ���/>

        /// <summary>
        /// �q�ɖ��̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̓d���⍇���ԍ���<c>0</c>�̏ꍇ�ɂ́A
        /// ���_�ݒ�}�X�^�̑q�ɃR�[�h�i3�j��
        /// ��M�d���̏o�ו��i�ԍ��A���[�J�[�R�[�h��
        /// �݌Ƀ}�X�^�̑��݃`�F�b�N���s�����݂���q�ɖ��̂��Z�b�g����
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected virtual void MergeWarehouseName(ReceivedText receivedTelegram)
        {
            UOEOrderDtlWork uoeOrderDetailRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(receivedTelegram);
            if (uoeOrderDetailRecord != null)
            {
                string warehouseName = uoeOrderDetailRecord.WarehouseName;
                CurrentStockDetailRecord.WarehouseName = warehouseName;
            }
        }

        #endregion  // <045.�q�ɖ���/>

        #region <046.�q�ɒI��/>

        /// <summary>
        /// �q�ɒI�Ԃ��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̓d���⍇���ԍ���<c>0</c>�̏ꍇ�ɂ́A
        /// ���_�ݒ�}�X�^�̑q�ɃR�[�h�i3�j��
        /// ��M�d���̏o�ו��i�ԍ��A���[�J�[�R�[�h��
        /// �݌Ƀ}�X�^�̑��݃`�F�b�N���s�����݂���q�ɒI�Ԃ��Z�b�g����
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected virtual void MergeWarehouseShelfNo(ReceivedText receivedTelegram)
        {
            UOEOrderDtlWork uoeOrderDetailRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(receivedTelegram);
            if (uoeOrderDetailRecord != null)
            {
                string warehouseShelfNo = uoeOrderDetailRecord.WarehouseShelfNo;
                CurrentStockDetailRecord.WarehouseShelfNo = warehouseShelfNo;
            }
        }

        #endregion  // <046.�q�ɒI��/>

        #region <047.�d���݌Ɏ�񂹋敪/>

        /// <summary>
        /// �d���݌Ɏ�񂹋敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �q�ɃR�[�h��<c>0</c>�ȊO�̏ꍇ�ɂ� 1:�݌�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeStockOrderDivCd(ReceivedText receivedTelegram)
        {
            const int GOODS_IN_STOCK = 1;   // 1:�݌�

            int warehouseCode = 0;
            if (int.TryParse(CurrentStockDetailRecord.WarehouseCode.Trim(), out warehouseCode))
            {
                if (!warehouseCode.Equals(0))
                {
                    CurrentStockDetailRecord.StockOrderDivCd = GOODS_IN_STOCK;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(CurrentStockDetailRecord.WarehouseCode.Trim()))
                {
                    CurrentStockDetailRecord.StockOrderDivCd = GOODS_IN_STOCK;
                }
            }
        }

        #endregion  // <047.�d���݌Ɏ�񂹋敪/>

        #region <048.�I�[�v�����i�敪/>

        /// <summary>
        /// �I�[�v�����i�敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���i�A���f�[�^�N���X
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeOpenPriceDiv(ReceivedText receivedTelegram)
        {
            GoodsPrice goodsPrice = GoodsDB.Instance.Policy.FindFirstGoodsPrice(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsPrice != null)
            {
                int openPriceDiv = goodsPrice.OpenPriceDiv;
                CurrentStockDetailRecord.OpenPriceDiv = openPriceDiv;
            }
        }

        #endregion  // <048.�I�[�v�����i�敪/>

        #region <049.���i�|�������N/>

        /// <summary>
        /// ���i�|�������N���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���i�A���f�[�^�N���X
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeGoodsRateRank(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                string goodsRateRank = goodsUnitData.GoodsRateRank;
                CurrentStockDetailRecord.GoodsRateRank = goodsRateRank;
            }
        }

        #endregion  // <049.���i�|�������N/>

        #region <052.�艿�i�Ŕ�, �����j/>

        /// <summary>
        /// �艿�i�Ŕ�, �����j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����M�d���̒艿
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeListPriceTaxExcFl(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //double listPriceTaxExcFl = double.Parse(receivedTelegram.AnswerListPrice);
            double listPriceTaxExcFl = TStrConv.StrToDoubleDef(receivedTelegram.AnswerListPrice.Trim(), 0);
            // 2009/10/14 <<<
            CurrentStockDetailRecord.ListPriceTaxExcFl = listPriceTaxExcFl;
        }

        #endregion  // <052.�艿�i�Ŕ�, �����j/>

        #region <053.�艿�i�ō�, �����j/>

        /// <summary>
        /// �艿�i�ō�, �����j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �艿�i�Ŕ�, �����j����CalculatePrice���\�b�h���g�p���Z�o
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeListPriceTaxIncFl(ReceivedText receivedTelegram)
        {
            int stockCnsTaxFrcProcCd = 0;   // �d������Œ[�������R�[�h
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                stockCnsTaxFrcProcCd = supplier.StockCnsTaxFrcProcCd;
            }
            UOESendReceiveComponent component = new UOESendReceiveComponent();
            double listPriceTaxIncFl = component.GetStockPriceTaxInc(
                CurrentStockDetailRecord.ListPriceTaxExcFl,
                CurrentStockDetailRecord.TaxationCode,
                stockCnsTaxFrcProcCd
            );
            CurrentStockDetailRecord.ListPriceTaxIncFl = listPriceTaxIncFl;
        }

        #endregion  // <053.�艿�i�ō�, �����j/>

        #region <062.�d���P���i�Ŕ�, �����j/>

        /// <summary>
        /// �d���P���i�Ŕ�, �����j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����M�d���̎d�ؒP��<br/>
        /// �����Y�Ƃ͏����_��1�ʂ܂łƂȂ�10�{�l���Z�b�g����Ă���ׁA�����_�t���ŃZ�b�g<br/>
        /// �����ȊO�͂��̂܂�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeStockUnitPriceFl(ReceivedText receivedTelegram)
        {
            if (UoeSupplier is UOEMeijiDecorator)
            {
                #region <Guard Phrase/>

                // 2009/10/14 >>>
                //int telegramValue= CutOffDecimal(double.Parse(receivedTelegram.AnswerSalesUnitCost.Trim()));
                int telegramValue = CutOffDecimal(TStrConv.StrToDoubleDef(receivedTelegram.AnswerSalesUnitCost.Trim(), 0));
                // 2009/10/14 <<<
                int currentValue = CutOffDecimal(CurrentStockDetailRecord.StockUnitPriceFl);
                if (telegramValue.Equals(currentValue))
                {
                    // FIXME:����M�������Ŗ����p�̏������{�����H
                }

                #endregion  // <Guard Phrase/>

                // 2009/10/14 >>>
                //int nStockUnitPriceFl = int.Parse(receivedTelegram.AnswerSalesUnitCost.Trim());
                int nStockUnitPriceFl = TStrConv.StrToIntDef(receivedTelegram.AnswerSalesUnitCost.Trim(), 0);
                // 2009/10/14 <<<
                CurrentStockDetailRecord.StockUnitPriceFl = ( (double)nStockUnitPriceFl ) / 10.0;
            }
            else
            {
                // 2009/10/14 >>>
                //double stockUnitPriceFl = double.Parse(receivedTelegram.AnswerSalesUnitCost.Trim());
                double stockUnitPriceFl = TStrConv.StrToDoubleDef(receivedTelegram.AnswerSalesUnitCost.Trim(), 0);
                // 2009/10/14 <<<
                CurrentStockDetailRecord.StockUnitPriceFl = stockUnitPriceFl;
            }
        }

        /// <summary>
        /// �����_�ȉ���؂�̂Ă����l���擾���܂��B
        /// </summary>
        /// <param name="doubleNumber"></param>
        /// <returns></returns>
        private static int CutOffDecimal(double doubleNumber)
        {
            string strNumber = doubleNumber.ToString();
            string[] strNumbers = strNumber.Split('.');
            return int.Parse(strNumbers[0]);
        }

        #endregion  // <062.�d���P���i�Ŕ�, �����j/>

        #region <063.�d���P���i�ō�, �����j/>

        /// <summary>
        /// �d���P���i�ō�, �����j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �艿�i�Ŕ�, �����j����CalculatePrice���\�b�h���g�p���Z�o
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeStockUnitTaxPriceFl(ReceivedText receivedTelegram)
        {
            int stockCnsTaxFrcProcCd = 0;   // �d������Œ[�������R�[�h
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                stockCnsTaxFrcProcCd = supplier.StockCnsTaxFrcProcCd;
            }
            UOESendReceiveComponent component = new UOESendReceiveComponent();
            double stockUnitTaxPriceFl = component.GetStockPriceTaxInc(
                CurrentStockDetailRecord.StockUnitPriceFl,
                CurrentStockDetailRecord.TaxationCode,
                stockCnsTaxFrcProcCd
            );
            CurrentStockDetailRecord.StockUnitTaxPriceFl = stockUnitTaxPriceFl;
        }

        #endregion  // <063.�d���P���i�ō�, �����j/>

        #region <064.�d���P���ύX�敪/>

        /// <summary>
        /// �d���P���ύX�敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 0:�ύX�Ȃ�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeStockUnitChngDiv(ReceivedText receivedTelegram)
        {
            const int NOT_CHANGED = 0;  // 0:�ύX�Ȃ�
            CurrentStockDetailRecord.StockUnitChngDiv = NOT_CHANGED;
        }

        #endregion  // <064.�d���P���ύX�敪/>

        #region <065.�ύX�O�d���P���i�����j/>

        /// <summary>
        /// �ύX�O�d���P���i�����j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d���P���i�Ŕ�, ����)
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeBfStockUnitPriceFl(ReceivedText receivedTelegram)
        {
            double bfStockUnitPriceFl = CurrentStockDetailRecord.StockUnitPriceFl;
            CurrentStockDetailRecord.BfStockUnitPriceFl = bfStockUnitPriceFl;
        }

        #endregion  // <065.�ύX�O�d���P���i�����j/>

        #region <066.�ύX�O�艿/>

        /// <summary>
        /// �ύX�O�艿���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �艿�i�Ŕ�, �����j
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeBfListPrice(ReceivedText receivedTelegram)
        {
            double bfListPrice = CurrentStockDetailRecord.ListPriceTaxExcFl;
            CurrentStockDetailRecord.BfListPrice = bfListPrice;
        }

        #endregion  // <066.�ύX�O�艿/>

        #region <073.�d����/>

        /// <summary>
        /// �d�������}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����M�d���̏o�א�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeStockCount(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //double stockCount = double.Parse(receivedTelegram.UOESectOutGoodsCount);
            double stockCount = TStrConv.StrToDoubleDef(receivedTelegram.UOESectOutGoodsCount.Trim(), 0);
            // 2009/10/14 <<<

            if (receivedTelegram.IsTelephoneOrder())
            {
                UOEOrderDtlWork uoeOrderDetailRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(receivedTelegram);
                if (uoeOrderDetailRecord != null)
                {
                    stockCount = uoeOrderDetailRecord.UOESectOutGoodsCnt;
                }
            }

            CurrentStockDetailRecord.StockCount = stockCount;
        }

        #endregion  // <073.�d����/>

        #region <074.��������/>

        /// <summary>
        /// �������ʂ��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����M�d���̎󒍐�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeOrderCnt(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //double orderCnt = double.Parse(receivedTelegram.AcceptAnOrderCount);
            double orderCnt = TStrConv.StrToDoubleDef(receivedTelegram.AcceptAnOrderCount.Trim(), 0);
            // 2009/10/14 <<<
            CurrentStockDetailRecord.OrderCnt = orderCnt;
        }

        #endregion  // <074.��������/>

        #region <075.����������/>

        /// <summary>
        /// ���������ʂ��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���������� = �����c�� - ��������
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeOrderAdjustCnt(ReceivedText receivedTelegram)
        {
            CurrentStockDetailRecord.OrderAdjustCnt
                = CurrentStockDetailRecord.OrderRemainCnt - CurrentStockDetailRecord.OrderCnt;
        }

        #endregion  // <075.����������/>

        #region <076.�����c��/>

        /// <summary>
        /// �����c�����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̏o�א�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeOrderRemainCnt(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //double orderRemainCnt = double.Parse(receivedTelegram.UOESectOutGoodsCount);
            double orderRemainCnt = TStrConv.StrToDoubleDef(receivedTelegram.UOESectOutGoodsCount.Trim(), 0);
            // 2009/10/14 <<<
            CurrentStockDetailRecord.OrderRemainCnt = orderRemainCnt;
        }

        #endregion  // <076.�����c��/>

        #region <078.�d�����z�i�Ŕ����j/>

        /// <summary>
        /// �d�����z�i�Ŕ����j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// CalcTaxExcFromTaxInc���\�b�h���g�p���Z�o
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeStockPriceTaxExc(ReceivedText receivedTelegram)
        {
            int stockMoneyFrcProcCd = 0;    // �d�����z�[�������R�[�h
            int stockCnsTaxFrcProcCd = 0;    // �d������Œ[�������R�[�h
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                stockMoneyFrcProcCd = supplier.StockMoneyFrcProcCd;
                stockCnsTaxFrcProcCd = supplier.StockCnsTaxFrcProcCd;
            }
            long stockPriceTaxInc = 0;  // �d�����z�i�ō��݁j
            long stockPriceTaxExc = 0;  // �d�����z�i�Ŕ����j
            long stockPriceConsTax= 0;  // �d�������
            UOESendReceiveComponent component = new UOESendReceiveComponent();
            {
                if (component.CalculationStockPrice(
                    CurrentStockDetailRecord.StockCount,
                    CurrentStockDetailRecord.StockUnitPriceFl, CurrentStockDetailRecord.TaxationCode,
                    stockMoneyFrcProcCd,
                    stockCnsTaxFrcProcCd,
                    out stockPriceTaxInc,
                    out stockPriceTaxExc,
                    out stockPriceConsTax
                ))
                {
                    CurrentStockDetailRecord.StockPriceTaxInc = stockPriceTaxInc;
                    CurrentStockDetailRecord.StockPriceTaxExc = stockPriceTaxExc;
                    CurrentStockDetailRecord.StockPriceConsTax= stockPriceConsTax;
                }
            }
        }

        #endregion  // <078.�d�����z�i�Ŕ����j/>

        #region <079.�d�����z�i�ō��݁j/>

        /// <summary>
        /// �d�����z�i�ō��݁j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// CalcTaxExcFromTaxExc���\�b�h���g�p���Z�o ��078.�d�����z�i�Ŕ����j�œ����Ƀ}�[�W
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeStockPriceTaxInc(ReceivedText receivedTelegram)
        {

        }

        #endregion  // <079.�d�����z�i�ō��݁j/>

        #region <080.�d�����i�敪/>

        /// <summary>
        /// �d�����i�敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 0:���i
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeStockGoodsCd(ReceivedText receivedTelegram)
        {
            const int GOODS = 0;    // 0:���i
            CurrentStockDetailRecord.StockGoodsCd = GOODS;
        }

        #endregion  // <080.�d�����i�敪/>

        #region <081.�d�����z����Ŋz/>

        /// <summary>
        /// �d�����z����Ŋz���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��078.�d�����z�i�Ŕ����j�œ����Ƀ}�[�W
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeStockPriceConsTax(ReceivedText receivedTelegram) { }

        #endregion  // <081.�d�����z����Ŋz/>

        #region <082.�ېŋ敪/>

        /// <summary>
        /// �ېŋ敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���i�A���f�[�^�N���X
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeTaxationCode(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                int taxationCode = goodsUnitData.TaxationDivCd;
                CurrentStockDetailRecord.TaxationCode = taxationCode;
            }
        }

        #endregion  // <082.�ېŋ敪/>

        #region <092.�d����R�[�h/>

        /// <summary>
        /// �d����R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ������}�X�^��̎d����R�[�h
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeSupplierCd(ReceivedText receivedTelegram)
        {
            int supplierCd = UoeSupplier.RealUOESupplier.UOESupplierCd;
            CurrentStockDetailRecord.SupplierCd = supplierCd;
        }

        #endregion  // <092.�d����R�[�h/>

        #region <093.�d���旪��/>

        /// <summary>
        /// �d���旪�̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����}�X�^�̎d���旪��
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeSupplierSnm(ReceivedText receivedTelegram)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                string supplierSnm = supplier.SupplierSnm;
                CurrentStockDetailRecord.SupplierSnm = supplierSnm;
            }
        }

        #endregion  // <093.�d���旪��/>

        #region <098.�������@/>

        /// <summary>
        /// �������@���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 2:�I�����C������
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeWayToOrder(ReceivedText receivedTelegram)
        {
            const int WAY_OF_ONLINE_ORDER = 2;    // 2:�I�����C������
            CurrentStockDetailRecord.WayToOrder = WAY_OF_ONLINE_ORDER;
        }

        #endregion  // <098.�������@/>

        #region <102.�����f�[�^�쐬��/>

        /// <summary>
        /// �����f�[�^�쐬�����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �V�X�e�����t
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeOrderDataCreateDate(ReceivedText receivedTelegram)
        {
            DateTime orderDataCreateDate = DateTime.Now;
            CurrentStockDetailRecord.OrderDataCreateDate = orderDataCreateDate;
        }

        #endregion  // <102.�����f�[�^�쐬��/>

        #region <103.���������s�ϋ敪/>

        /// <summary>
        /// ���������s�ϋ敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 0:�����s
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeOrderFormIssuedDiv(ReceivedText receivedTelegram)
        {
            const int NOT_ISSUED = 0;   // 0:�����s
            CurrentStockDetailRecord.OrderFormIssuedDiv = NOT_ISSUED;
        }

        #endregion  // <103.���������s�ϋ敪/>

        #region <105.���׊֘A�t��GUID/>

        /// <summary>
        /// ���׊֘A�t��GUID���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �Ή�����UOE�����f�[�^�̃��R�[�h�Ɠ����l
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeDtlRelationGuid(ReceivedText receivedTelegram)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(receivedTelegram);
            if (uoeOrderRecord != null)
            {
                CurrentStockDetailRecord.DtlRelationGuid = uoeOrderRecord.DtlRelationGuid;
            }
            else
            {
                Debug.Assert(false, "�d�����׃f�[�^�ɑΉ�����UOE�����f�[�^������܂���\n" + receivedTelegram.DtlRelationGuid.ToString());
                CurrentStockDetailRecord.DtlRelationGuid = Guid.NewGuid();
            }
        }

        #endregion  // <105.���׊֘A�t��GUID/>

        /// <summary>���݂̒P���v�Z����</summary>
        private UnitPriceCalcRet _currentUnitCost;
        /// <summary>
        /// ���݂̒P���v�Z���ʂ��擾���܂��B
        /// </summary>
        /// <value>���݂̒P���v�Z����</value>
        private UnitPriceCalcRet CurrentUnitCost
        {
            get { return _currentUnitCost; }
            set { _currentUnitCost = value; }
        }

        /// <summary>
        /// �P���v�Z���ʂ��擾���܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <param name="uoeSupplier">UOE������</param>
        /// <returns>�P���v�Z����</returns>
        private static UnitPriceCalcRet CalculateUnitCost(
            ReceivedText receivedTelegram,
            UOESupplierHelper uoeSupplier
        )
        {
            UnitPriceCalcRet unitPriceCalcRet = new UnitPriceCalcRet();
            {
                GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(receivedTelegram, uoeSupplier);
                if (goodsUnitData == null)
                {
                    return ReturnUnitPriceCalcRet(unitPriceCalcRet);
                }

                UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
                {
                    // �p�����[�^�ݒ�
                    unitPriceCalcParam.SectionCode = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;    // ���_�R�[�h
                    unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                           // ���i���[�J�[�R�[�h
                    unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                     // �i��
                    unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                         // ���i�|�������N
                    unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;                   // ���i�|���O���[�v�R�[�h
                    unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                             // BL�O���[�v�R�[�h
                    unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                             // BL���i�R�[�h
                    unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                               // �d����R�[�h
                    unitPriceCalcParam.PriceApplyDate = DateTime.Now;                                       // ���i�K�p��
                    // 2009/10/14 >>>
                    //unitPriceCalcParam.CountFl = double.Parse(receivedTelegram.UOESectOutGoodsCount);       // ����
                    unitPriceCalcParam.CountFl = TStrConv.StrToDoubleDef(receivedTelegram.UOESectOutGoodsCount.Trim(), 0);       // ����
                    // 2009/10/14 <<<
                    unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                         // �ېŋ敪
                    unitPriceCalcParam.TaxRate = TaxRateSetDB.Instance.Policy.TaxRateOfNow;                 // �ŗ�
                    unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;           // �d������Œ[�������R�[�h
                    unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;             // �d���P���[�������R�[�h
                }
                // �����P���v�Z����
                List<UnitPriceCalcRet> unitPriceCalcRetList = null;
                UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
                unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);
                foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
                {
                    if (unitPriceCalcRetWk.UnitPriceKind.Equals(UnitPriceCalculation.ctUnitPriceKind_UnitCost))
                    {
                        // �����P�����擾
                        unitPriceCalcRet = unitPriceCalcRetWk;
                        break;
                    }
                }
            }
            return ReturnUnitPriceCalcRet(unitPriceCalcRet);
        }

        /// <summary>
        /// �P���v�Z���ʂ�Ԃ��܂��B
        /// </summary>
        /// <param name="unitPriceCalcRet">�P���v�Z����</param>
        /// <returns>�P���v�Z����</returns>
        private static UnitPriceCalcRet ReturnUnitPriceCalcRet(UnitPriceCalcRet unitPriceCalcRet)
        {
            if (unitPriceCalcRet == null)
            {
                unitPriceCalcRet = new UnitPriceCalcRet();
            }
            // �P�ʂ��[���̓v���O������������Ƃ̂���
            if (unitPriceCalcRet.UnPrcFracProcUnit.Equals(0.0))
            {
                unitPriceCalcRet.UnPrcFracProcUnit = 1.0;
            }
            return unitPriceCalcRet;
        }
    }
}
