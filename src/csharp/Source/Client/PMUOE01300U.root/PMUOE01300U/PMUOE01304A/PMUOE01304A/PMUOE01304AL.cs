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
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2012/08/06  �C�����e : TEL�������̏ꍇ��UOE�����ԍ��ƍs�ԍ��������I��0�ɂ���B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : yangmj
// �� �� ��  2012/12/10  �C�����e : 1��16���z�M���Aredmine#32926PM�f�[�^�ƘA�g�����Ȃ��̑Ή��B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902931-00 �쐬�S�� : ���N�n��
// �� �� ��  2013/10/09  �C�����e : Redmine 40628��No36�_�A���P���̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  12100013-00 �쐬�S�� : ���O
// �� �� ��  2025/01/10  �C�����e : PMKOBETSU-4369 �R�`���i��_�����d����M�����s��Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Text;       // 2009/10/14 Add

namespace Broadleaf.Application.Controller
{
    using StockDB       = SingletonPolicy<StockDBAgent>;
    using LoginWorkerAcs= SingletonPolicy<LoginWorker>;
    using UOEGuideNameDB= SingletonPolicy<UOEGuideNameDBAgent>;
    using MakerMasterDB = SingletonPolicy<MakerMasterDBAgent>;
    using System.Threading;
    using Broadleaf.Application.Resources;
    using Broadleaf.Application.Common;

    /// <summary>
    /// UOE�����f�[�^�̍\�z�҃N���X
    /// </summary>
    public abstract class UOEOrderDataBuilder : OrderInformationBuilder
    {
        #region <�i�����/>

        /// <summary>�������̃��b�Z�[�W</summary>
        protected const string NOW_RUNNING = "UOE�����f�[�^���쐬��";   // LITERAL:

        /// <summary>�i�����</summary>
        private readonly UpdateProgressEventArgs _progressInfo = new UpdateProgressEventArgs(NOW_RUNNING, 0, 0);
        /// <summary>
        /// �i�������擾���܂��B
        /// </summary>
        protected UpdateProgressEventArgs ProgressInfo { get { return _progressInfo; } }

        #endregion  // <�i�����/>

        #region <�I�����C���s�ԍ��̍̔�/>

        /// <summary>�I�����C���s�ԍ��̃J�E���^</summary>
        protected int _onlineRowNoCount;

        #endregion  // <�I�����C���s�ԍ��̍̔�/>

        #region <���݂�UOE�����f�[�^�̖��׃��R�[�h/>

        /// <summary>���݂�UOE�����f�[�^�̖��׃��R�[�h</summary>
        private UOEOrderDtlWork _currentUOEOrderDetailRecord;
        /// <summary>
        /// ���݂�UOE�����f�[�^�̖��׃��R�[�h�̃A�N�Z�T
        /// </summary>
        /// <value>���݂�UOE�����f�[�^�̖��׃��R�[�h</value>
        protected UOEOrderDtlWork CurrentUOEOrderDetailRecord
        {
            get { return _currentUOEOrderDetailRecord; }
            set { _currentUOEOrderDetailRecord = value; }
        }

        #endregion  // <���݂�UOE�����f�[�^�̖��׃��R�[�h/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        /// <param name="receivedTelegramAgreegate">��M�d���̏W����</param>
        /// <param name="observer">�ȈՃI�u�U�[�o�[</param>
        protected UOEOrderDataBuilder(
            UOESupplierHelper uoeSupplier,
            IAgreegate<ReceivedText> receivedTelegramAgreegate,
            IProgressUpdatable observer
        ) : base(uoeSupplier, receivedTelegramAgreegate, observer)
        { }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// UOE�����f�[�^�Ɏ�M�d���̓��e���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// <br>Update Note: PMKOBETSU-4369 �R�`���i��_�����d����M�����s��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2025/01/10</br>
        /// </remarks>
        public override void Merge()
        {
            ProgressInfo.IsRunning = true;
            ProgressInfo.Max = ReceivedTelegramAgreegate.Size;

            IIterator<ReceivedText> receivedTelegramIterator = ReceivedTelegramAgreegate.CreateIterator();
            while (receivedTelegramIterator.HasNext())
            {
                Observer.Update(ProgressInfo);

                bool isNewRecord = false;

                // �}�[�W����UOE�����f�[�^�̖��׃��R�[�h��ݒ�
                ReceivedText receivedTelegram = receivedTelegramIterator.GetNext();
                if (receivedTelegram.IsTelephoneOrder())
                {
                    // TEL�������i�d���⍇���ԍ� == 0�j�c���ʂɐV�K�o�^
                    CurrentUOEOrderDetailRecord = new UOEOrderDtlWork();
                    isNewRecord = true;
                }
                else
                {
                    // UOE�������i�d���⍇���ԍ� != 0�j�c�����̃��R�[�h�����ɐV�K�o�^
                    CurrentUOEOrderDetailRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(receivedTelegram);
                    if (CurrentUOEOrderDetailRecord == null)
                    {
                        receivedTelegram.IsTelephoneOrderForced = true;
                        CurrentUOEOrderDetailRecord = new UOEOrderDtlWork();
                        isNewRecord = true;
                    }
                }

                // --- ADD 2025/01/10 ���O PMKOBETSU-4369 �R�`���i��_�����d����M�����s��Ή� ----->>>>>
                MergeDtlRelationGiid(receivedTelegram);         // 120.���׊֘A�t��GUID
                if (StockDB.Instance.Policy.FindStockDetailWork(receivedTelegram) == null)
                    receivedTelegram.IsTelephoneOrderForced = true;
                // --- ADD 2025/01/10 ���O PMKOBETSU-4369 �R�`���i��_�����d����M�����s��Ή� -----<<<<<

                // ��M�d���̓��e���}�[�W
                MergeEnterpriseCode(receivedTelegram);          // 003.��ƃR�[�h
                MergeSystemDivCd(receivedTelegram);             // 009.�V�X�e���敪
                // add 2012/08/06 >>>
                if (receivedTelegram.IsTelephoneOrderForced)
                {
                    CurrentUOEOrderDetailRecord.UOESalesOrderNo = 0;
                    CurrentUOEOrderDetailRecord.UOESalesOrderRowNo = 0;
                }
                else
                {
                    // add 2012/08/06 <<<
                    MergeUOESalesOrderNo(receivedTelegram);         // 010.UOE�����ԍ�
                    MergeUOESalesOrderRowNo(receivedTelegram);      // 011.UOE�����s�ԍ�
                }   // add 2012/08/06
                MergeSendTerminalNo(receivedTelegram);          // 012.���M�[���ԍ�
                MergeUOESupplierCd(receivedTelegram);           // 013.UOE������R�[�h
                MergeUOESupplierName(receivedTelegram);         // 014.UOE�����於��
                MergeCommAssemblyId(receivedTelegram);          // 015.�ʐM�A�Z���u��ID
                MergeOnlineNo(receivedTelegram);                // 016.�I�����C���ԍ�
                MergeOnlineRowNo(receivedTelegram);             // 017.�I�����C���s�ԍ�
                MergeInputDay(receivedTelegram);                // 019.���͓�
                MergeDataUpdateDateTime(receivedTelegram);      // 020.�f�[�^�X�V����
                MergeUOEKind(receivedTelegram);                 // 021.UOE���
                MergeSectionCode(receivedTelegram);             // 025.���_�R�[�h
                MergeSubSectionCode(receivedTelegram);          // 026.����R�[�h
                MergeCashRegisterNo(receivedTelegram);          // 029.�[���ԍ�
                MergeSupplierFormal(receivedTelegram);          // 031.�d���`��
                MergeBoCode(receivedTelegram);                  // 034.BO�敪
                MergeUOEDeliGoodsDiv(receivedTelegram);         // 035.�[�i�敪
                MergeDeliveredGoodsDivNm(receivedTelegram);     // 036.�[�i�敪����
                MergeEmployeeCode(receivedTelegram);            // 041.�]�ƈ��R�[�h
                MergeEmployeeName(receivedTelegram);            // 042.�]�ƈ�����
                MergeGoodsMakerCd(receivedTelegram);            // 043.���i���[�J�[�R�[�h
                MergeMakerName(receivedTelegram);               // 044.���[�J�[����
                MergeGoodsNo(receivedTelegram);                 // 045.���i�ԍ�
                MergeGoodsNoNoneHyphen(receivedTelegram);       // 046.�n�C�t�������i�ԍ�
                MergeGoodsName(receivedTelegram);               // 047.���i����
                {
                    MergeWarehouseCode(receivedTelegram);       // 048.�q�ɃR�[�h
                    MergeWarehouseName(receivedTelegram);       // 049.�q�ɖ���
                    MergeWarehouseShelfNo(receivedTelegram);    // 050.�q�ɒI��
                }
                MergeAcceptAnOrderCnt(receivedTelegram);        // 051.�󒍐���
                MergeSupplierCd(receivedTelegram);              // 054.�d����R�[�h
                MergeSupplierSnm(receivedTelegram);             // 055.�d���旪��
                MergeUoeRemark1(receivedTelegram);              // 056.UOE���}�[�N1
                MergeReceiveDate(receivedTelegram);             // 058.��M���t
                MergeReceiveTime(receivedTelegram);             // 059.��M����
                MergeAnswerMakerCd(receivedTelegram);           // 060.�񓚃��[�J�[�R�[�h
                MergeAnswerPartsNo(receivedTelegram);           // 061.�񓚕i��
                MergeAnswerPartsName(receivedTelegram);         // 062.�񓚕i��
                MergeSubstPartsNo(receivedTelegram);            // 063.��֕i��
                {
                    MergeUOESectOutGoodsCnt(receivedTelegram);  // 064.UOE���_�o�ɐ�
                }
                MergeBOShipmentCnt1(receivedTelegram);          // 065.BO�o�ɐ�1
                MergeUOESectionSlipNo(receivedTelegram);        // 074.UOE���_�`�[�ԍ�
                MergeBOSlipNo1(receivedTelegram);               // 075.BO�`�[�ԍ�1
                MergeAnswerListPrice(receivedTelegram);         // 080.�񓚒艿
                {
                    MergeAnswerSalesUnitCost(receivedTelegram); // 081.�񓚌����P��
                    MergeUOEMarkCode(receivedTelegram);         // 106.UOE�}�[�N�R�[�h
                }
                MergeUOECheckCode(receivedTelegram);            // 109.�`�F�b�N�R�[�h
                MergeLineErrorMessage(receivedTelegram);        // 111.���C���G���[
                MergeDataSendCode(receivedTelegram);            // 112.�f�[�^���M�敪
                MergeDataRecoverDiv(receivedTelegram);          // 113.�f�[�^�����敪
                MergeEnterUpdDivSec(receivedTelegram);          // 114.���ɍX�V�敪�i���_�j
                MergeEnterUpdDivBO1(receivedTelegram);          // 115.���ɍX�V�敪�iBO1�j
                MergeEnterUpdDivBO2(receivedTelegram);          // 116.���ɍX�V�敪�iBO2�j
                MergeEnterUpdDivBO3(receivedTelegram);          // 117.���ɍX�V�敪�iBO3�j
                MergeEnterUpdDivMaker(receivedTelegram);        // 118.���ɍX�V�敪�i���[�J�[�j
                MergeEnterUpdDivEO(receivedTelegram);           // 119.���ɍX�V�敪�iEO�j

                //MergeDtlRelationGiid(receivedTelegram);         // 120.���׊֘A�t��GUID // DEL 2025/01/10 ���O PMKOBETSU-4369 �R�`���i��_�����d����M�����s��Ή�

                // DB�֑}���p�Ƀ��R�[�h��ǉ�
                if (isNewRecord)
                {
                    StockDB.Instance.Policy.AddUOEOrderDtlWork(CurrentUOEOrderDetailRecord, receivedTelegram);
                }
                // �����̃��R�[�h�����ɐV�K�o�^����ꍇ�A
                // �������ꂽ�C���X�^���X�̒l��ύX���Ă��邽�߁A�V���ɒǉ�����K�v�Ȃ�

                ProgressInfo.Count++;
            }   // while (receivedTelegramIterator.HasNext())

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
            CurrentUOEOrderDetailRecord.EnterpriseCode = enterpriseCode;
        }

        #endregion  // <003.��ƃR�[�h/>

        #region <009.�V�X�e���敪/>

        /// <summary>
        /// �V�X�e���敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̓d���⍇���ԍ���<c>0</c>�̏ꍇ�ɂ̓Z�b�g���A
        /// <c>0</c>�ȊO�̏ꍇ�ɂ͌��f�[�^�̃V�X�e���敪���Z�b�g
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeSystemDivCd(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                CurrentUOEOrderDetailRecord.SystemDivCd = ReceivedText.SALES_ORDER_NO_BY_TELEPHONE;
            }
        }

        #endregion  // <9.�V�X�e���敪/>

        #region <010.UOE�����ԍ�/>

        /// <summary>
        /// UOE�����ԍ����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̓d���⍇���ԍ�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeUOESalesOrderNo(ReceivedText receivedTelegram)
        {
            int uoeSalesOrderNo = int.Parse(receivedTelegram.UOESalesOrderNo);
            CurrentUOEOrderDetailRecord.UOESalesOrderNo = uoeSalesOrderNo;
        }

        #endregion  // <10.UOE�����ԍ�/>

        #region <011.UOE�����s�ԍ�/>

        /// <summary>
        /// UOE�����s�ԍ����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̉񓚓d���Ή��s
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeUOESalesOrderRowNo(ReceivedText receivedTelegram)
        {
            int uoeSalesOrderRowNo = int.Parse(receivedTelegram.UOESalesOrderRowNo);

            if (receivedTelegram.IsTelephoneOrder() || uoeSalesOrderRowNo.Equals(0))
            {
                uoeSalesOrderRowNo = GetRowNoOfTelOrder(receivedTelegram.UOESectionSlipNo);
            }

            CurrentUOEOrderDetailRecord.UOESalesOrderRowNo = uoeSalesOrderRowNo;
        }

        #endregion  // <011.UOE�����s�ԍ�/>

        #region <012.���M�[���ԍ�/>

        /// <summary>
        /// ���M�[���ԍ����}�[�W���܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeSendTerminalNo(ReceivedText receivedTelegram)
        {
            int sendTerminalNo = LoginWorkerAcs.Instance.Policy.CashRegisterNo;
            CurrentUOEOrderDetailRecord.SendTerminalNo = sendTerminalNo;
        }

        #endregion  // <012.���M�[���ԍ�/>

        #region <013.UOE������R�[�h/>

        /// <summary>
        /// UOE������R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// UI�œ��͂���������R�[�h
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeUOESupplierCd(ReceivedText receivedTelegram)
        {
            int uoeSupplierCd = UoeSupplier.RealUOESupplier.UOESupplierCd;
            CurrentUOEOrderDetailRecord.UOESupplierCd = uoeSupplierCd;
        }

        #endregion  // <013.UOE������R�[�h/>

        #region <014.UOE�����於��/>

        /// <summary>
        /// UOE�����於�̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// UOE������R�[�h�ɑ΂��閼��
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeUOESupplierName(ReceivedText receivedTelegram)
        {
            string uoeSupplierName = UoeSupplier.RealUOESupplier.UOESupplierName.Trim();
            CurrentUOEOrderDetailRecord.UOESupplierName = uoeSupplierName;
        }

        #endregion  // <014.UOE�����於��/>

        #region <015.�ʐM�A�Z���u��ID/>

        /// <summary>
        /// �ʐM�A�Z���u��ID���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// UOE�����}�X�^�̒ʐM�A�Z���u��ID
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeCommAssemblyId(ReceivedText receivedTelegram)
        {
            string commAssemblyId = UoeSupplier.RealUOESupplier.CommAssemblyId.Trim();
            CurrentUOEOrderDetailRecord.CommAssemblyId = commAssemblyId;
        }

        #endregion  // <015.�ʐM�A�Z���u��ID/>

        #region <016.�I�����C���ԍ�/>

        /// <summary>
        /// �I�����C���ԍ����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �����[�g���ō̔Ԃ��邽�߁A<c>0</c>��ݒ�c�����[�g���Ŏ����I��insert����
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeOnlineNo(ReceivedText receivedTelegram)
        {
            const int ONLINE_NO = 0;
            CurrentUOEOrderDetailRecord.OnlineNo = ONLINE_NO;
        }

        #endregion  // <016.�I�����C���ԍ�/>

        #region <017.�I�����C���s�ԍ�/>

        /// <summary>
        /// �I�����C���s�ԍ����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �I�����C���ԍ��ɑ΂���A�ԁ@����M�������ԂɂȂ�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeOnlineRowNo(ReceivedText receivedTelegram)
        {
            int onlineRowNo = ++_onlineRowNoCount;
            CurrentUOEOrderDetailRecord.OnlineRowNo = onlineRowNo;
        }

        #endregion  // <017.�I�����C���s�ԍ�/>

        #region <019.���͓�/>

        /// <summary>
        /// ���͓����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �V�X�e�����t
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeInputDay(ReceivedText receivedTelegram)
        {
            DateTime inputDay = DateTime.Now;
            CurrentUOEOrderDetailRecord.InputDay = inputDay;
        }

        #endregion  // <019.���͓�/>

        #region <020.�f�[�^�X�V����/>

        /// <summary>
        /// �f�[�^�X�V�������}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �V�X�e�����t�E�����i�����\���Ƃ��Ďg�p�j
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeDataUpdateDateTime(ReceivedText receivedTelegram)
        {
            DateTime dataUpdateDateTime = DateTime.Now;
            CurrentUOEOrderDetailRecord.DataUpdateDateTime = dataUpdateDateTime;
        }

        #endregion  // <020.�f�[�^�X�V����/>

        #region <021.UOE���/>

        /// <summary>
        /// UOE��ʂ��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 1:�����d����M
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeUOEKind(ReceivedText receivedTelegram)
        {
            const int UOE_KIND = 1; // 0:UOE�^1:�����d����M
            CurrentUOEOrderDetailRecord.UOEKind = UOE_KIND;
        }

        #endregion  // <021.UOE���/>

        #region <025.���_�R�[�h/>

        /// <summary>
        /// ���_�R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���O�C���S���҂̋��_�R�[�h
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeSectionCode(ReceivedText receivedTelegram)
        {
            string sectionCode = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
            CurrentUOEOrderDetailRecord.SectionCode = sectionCode;
        }

        #endregion  // <025.���_�R�[�h/>

        #region <026.����R�[�h/>

        /// <summary>
        /// ����R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���O�C���S���҂̕���R�[�h
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeSubSectionCode(ReceivedText receivedTelegram)
        {
            int subSectionCode = LoginWorkerAcs.Instance.Policy.Detail.BelongSubSectionCode;
            CurrentUOEOrderDetailRecord.SubSectionCode = subSectionCode;
        }

        #endregion  // <026.����R�[�h/>

        #region <029.�[���ԍ�/>

        /// <summary>
        /// �[���ԍ����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �[���ԍ�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeCashRegisterNo(ReceivedText receivedTelegram)
        {
            int cashRegisterNo = LoginWorkerAcs.Instance.Policy.CashRegisterNo;
            CurrentUOEOrderDetailRecord.CashRegisterNo = cashRegisterNo;
        }

        #endregion  // <029.�[���ԍ�/>

        #region <031.�d���`��/>

        /// <summary>
        /// �d���`�����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̓d���⍇���ԍ���<c>0</c>�̏ꍇ�ɂ́A2:����
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeSupplierFormal(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                const int ORDER = 2;    // 2:����
                CurrentUOEOrderDetailRecord.SupplierFormal = ORDER;
            }
        }

        #endregion  // <031.�d���`��/>

        #region <034.BO�敪/>

        /// <summary>
        /// BO�敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d����BO�敪
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeBoCode(ReceivedText receivedTelegram)
        {
            string boCode = receivedTelegram.BOCode;
            CurrentUOEOrderDetailRecord.BoCode = boCode;
        }

        #endregion  // <034.BO�敪/>

        #region <035.�[�i�敪/>

        /// <summary>
        /// �[�i�敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̔[�i�敪
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeUOEDeliGoodsDiv(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                string uoeDeliGoodsDiv = receivedTelegram.DeliveryGoodsDiv;
                CurrentUOEOrderDetailRecord.UOEDeliGoodsDiv = uoeDeliGoodsDiv;
            }
        }

        #endregion  // <035.�[�i�敪/>

        #region <036.�[�i�敪����/>

        /// <summary>
        /// �[�i�敪���̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// UOE�K�C�h���̃}�X�^����擾
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeDeliveredGoodsDivNm(ReceivedText receivedTelegram)
        {
            UOEGuideName uoeGuideName = UOEGuideNameDB.Instance.Policy.Find(
                UoeSupplier.RealUOESupplier.UOESupplierCd,  // UOE������R�[�h
                CurrentUOEOrderDetailRecord.UOEDeliGoodsDiv // UOE�����f�[�^�̔[�i�敪
            );
            if (uoeGuideName != null)
            {
                string deliveredGoodsDivNm = uoeGuideName.UOEGuideNm;
                CurrentUOEOrderDetailRecord.DeliveredGoodsDivNm = deliveredGoodsDivNm;
            }
        }

        #endregion  // <036.�[�i�敪����/>

        #region <041.�]�ƈ��R�[�h/>

        /// <summary>
        /// �]�ƈ��R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���f�[�^
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeEmployeeCode(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                string employeeCode = LoginWorkerAcs.Instance.Policy.Profile.EmployeeCode;
                CurrentUOEOrderDetailRecord.EmployeeCode = employeeCode;
            }
        }

        #endregion  // <041.�]�ƈ��R�[�h/>

        #region <042.�]�ƈ�����/>

        /// <summary>
        /// �]�ƈ��R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���f�[�^
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeEmployeeName(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                string employeeName = LoginWorkerAcs.Instance.Policy.Profile.Name;
                CurrentUOEOrderDetailRecord.EmployeeName = employeeName;
            }
        }

        #endregion  // <042.�]�ƈ�����/>

        #region <043.���i���[�J�[�R�[�h/>

        /// <summary>
        /// ���i���[�J�[�R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���f�[�^
        /// ��M�d���̓d���⍇���ԍ��ԍ���0�̏ꍇ�ɂ́A��M�d���̃��[�J�[�R�[�h
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeGoodsMakerCd(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                // 2009/10/14 >>>
                //int goodsMakerCd = int.Parse(receivedTelegram.AnswerMakerCode);
                int goodsMakerCd = TStrConv.StrToIntDef(receivedTelegram.AnswerMakerCode.Trim(), 0);
                // 2009/10/14 <<<
                CurrentUOEOrderDetailRecord.GoodsMakerCd = goodsMakerCd;
            }
        }

        #endregion  // <042.���i���[�J�[�R�[�h/>

        #region <044.���[�J�[����/>

        /// <summary>
        /// ���[�J�[���̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���f�[�^
        /// ��M�d���̓d���⍇���ԍ��ԍ���0�̏ꍇ�ɂ́A���[�J�[�R�[�h�ɑ΂��郁�[�J�[���́i���[�J�[�}�X�^���j
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeMakerName(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                MakerSet makerSet = MakerMasterDB.Instance.Policy.Find(CurrentUOEOrderDetailRecord.GoodsMakerCd);
                if (makerSet != null)
                {
                    string makerName = makerSet.MakerName;
                    CurrentUOEOrderDetailRecord.MakerName = makerName;
                }
            }
        }

        #endregion  // <044.���[�J�[����/>

        #region <045.���i�ԍ�/>

        /// <summary>
        /// ���i�ԍ����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̓d���⍇���ԍ���<c>0</c>�̏ꍇ�ɂ́A��M�d���̎󒍕��i�ԍ�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeGoodsNo(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                string goodsNo = receivedTelegram.AcceptPartsNo;
                CurrentUOEOrderDetailRecord.GoodsNo = goodsNo;
            }
        }

        #endregion  // <045.���i�ԍ�/>

        #region <046.�n�C�t�������i�ԍ�/>

        /// <summary>
        /// �n�C�t�������i�ԍ����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̓d���⍇���ԍ���<c>0</c>�̏ꍇ�ɂ́A��M�d���̎󒍕��i�ԍ�����n�C�t���폜
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeGoodsNoNoneHyphen(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                string goodsNoNoneHyphen = receivedTelegram.AcceptPartsNo.Replace("-", string.Empty);
                CurrentUOEOrderDetailRecord.GoodsNoNoneHyphen = goodsNoNoneHyphen;
            }
        }

        #endregion  // <046.�n�C�t�������i�ԍ�/>

        #region <047.���i����/>

        /// <summary>
        /// ���i���̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̓d���⍇���ԍ���<c>0</c>�̏ꍇ�ɂ́A��M�d���̕i��
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeGoodsName(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                string goodsName = receivedTelegram.AnswerPartsName;
                CurrentUOEOrderDetailRecord.GoodsName = goodsName;
            }
        }

        #endregion  // <047.���i����/>

        #region <048.�q�ɃR�[�h/>

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
            if (receivedTelegram.IsTelephoneOrder())
            {
                Stock foundStock = FindStockBy3WarehouseCodes(receivedTelegram);
                if (foundStock != null)
                {
                    CurrentUOEOrderDetailRecord.WarehouseCode = foundStock.WarehouseCode;
                }
            }
        }

        #endregion  // <048.�q�ɃR�[�h/>

        #region <049.�q�ɖ���/>

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
            if (receivedTelegram.IsTelephoneOrder())
            {
                Stock foundStock = FindStockBy3WarehouseCodes(receivedTelegram);
                if (foundStock != null)
                {
                    CurrentUOEOrderDetailRecord.WarehouseName = foundStock.WarehouseName;
                }
            }
        }

        #endregion  // <049.�q�ɖ���/>

        #region <050.�q�ɒI��/>

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
            if (receivedTelegram.IsTelephoneOrder())
            {
                Stock foundStock = FindStockBy3WarehouseCodes(receivedTelegram);
                if (foundStock != null)
                {
                    CurrentUOEOrderDetailRecord.WarehouseShelfNo = foundStock.WarehouseShelfNo;
                }
            }
        }

        #endregion  // <050.�q�ɒI��/>

        #region <051.�󒍐���/>

        /// <summary>
        /// �󒍐��ʂ��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̎󒍐���
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeAcceptAnOrderCnt(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //double acceptAnOrderCnt = double.Parse(receivedTelegram.AcceptAnOrderCount);
            double acceptAnOrderCnt = TStrConv.StrToDoubleDef(receivedTelegram.AcceptAnOrderCount.Trim(), 0);
            // 2009/10/14 <<<
            CurrentUOEOrderDetailRecord.AcceptAnOrderCnt = acceptAnOrderCnt;
        }

        #endregion  // <051.�󒍐���/>

        #region <054.�d����R�[�h/>

        /// <summary>
        /// �d����R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ������}�X�^�̎d����R�[�h
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeSupplierCd(ReceivedText receivedTelegram)
        {
            int supplierCd = UoeSupplier.RealUOESupplier.UOESupplierCd;
            CurrentUOEOrderDetailRecord.SupplierCd = supplierCd;
        }

        #endregion  // <054.�d����R�[�h/>

        #region <055.�d���旪��/>

        /// <summary>
        /// �d���旪�̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ������}�X�^�̎d����R�[�h�ɑ΂��閼��
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeSupplierSnm(ReceivedText receivedTelegram)
        {
            string supplierSnm = UoeSupplier.RealUOESupplier.UOESupplierName;
            CurrentUOEOrderDetailRecord.SupplierSnm = supplierSnm;
        }

        #endregion  // <055.�d���旪��/>

        #region <056.UOE���}�[�N1/>

        /// <summary>
        /// UOE���}�[�N1���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̃��}�[�N�i�g�������ăZ�b�g�j�@�������[�g��*D�̔��f���s���׃g��������
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeUoeRemark1(ReceivedText receivedTelegram)
        {
            string uoeRemark1 = receivedTelegram.UOERemark;
            CurrentUOEOrderDetailRecord.UoeRemark1 = uoeRemark1;
        }

        #endregion  // <056.UOE���}�[�N1/>

        #region <058.��M���t/>

        /// <summary>
        /// ��M���t���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̕��ރR�[�h�iMMDD�j�����H
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeReceiveDate(ReceivedText receivedTelegram)
        {
            ReceivedDate receivedDate = new ReceivedDate(receivedTelegram.ClassifiedCode.Trim());
            DateTime receiveDate = receivedDate.ToDateTime();
            CurrentUOEOrderDetailRecord.ReceiveDate = receiveDate;
        }

        #endregion  // <058.��M���t/>

        #region <059.��M����/>

        /// <summary>
        /// ��M�������}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �V�X�e������
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeReceiveTime(ReceivedText receivedTelegram)
        {
            DateTime systemTime = DateTime.Now;
            int hour= systemTime.Hour;
            int min = systemTime.Minute;
            int sec = systemTime.Second;
            string strSystemTime = hour.ToString("0000") + min.ToString("00") + sec.ToString("00");

            int receiveTime = int.Parse(strSystemTime);
            CurrentUOEOrderDetailRecord.ReceiveTime = receiveTime;
        }

        #endregion  // <059.��M����/>

        #region <060.�񓚃��[�J�[�R�[�h/>

        /// <summary>
        /// �񓚃��[�J�[�R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̃��[�J�[�R�[�h
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeAnswerMakerCd(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //int answerMakerCd = int.Parse(receivedTelegram.AnswerMakerCode);
            int answerMakerCd = TStrConv.StrToIntDef(receivedTelegram.AnswerMakerCode.Trim(), 0);
            // 2009/10/14 <<<
            CurrentUOEOrderDetailRecord.AnswerMakerCd = answerMakerCd;
        }

        #endregion  // <060.�񓚃��[�J�[�R�[�h/>

        #region <061.�񓚕i��/>

        /// <summary>
        /// �񓚕i�Ԃ��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̏o�ו��i�ԍ�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeAnswerPartsNo(ReceivedText receivedTelegram)
        {
            string answerPartsNo = receivedTelegram.AnswerPartsNo;
            CurrentUOEOrderDetailRecord.AnswerPartsNo = answerPartsNo;
        }

        #endregion  // <061.�񓚕i��/>

        #region <062.�񓚕i��/>

        /// <summary>
        /// �񓚕i�����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̕i��
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeAnswerPartsName(ReceivedText receivedTelegram)
        {
            string answerPartsName = receivedTelegram.AnswerPartsName;
            CurrentUOEOrderDetailRecord.AnswerPartsName = TrimEndCode(answerPartsName);
        }

        #endregion  // <062.�񓚕i��/>

        #region <063.��֕i��/>

        /// <summary>
        /// ��֕i�Ԃ��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̎󒍕��i�ԍ��Əo�ו��i�ԍ�������łȂ��ꍇ�ɏo�ו��i�ԍ����Z�b�g
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeSubstPartsNo(ReceivedText receivedTelegram)
        {
            if (!receivedTelegram.AcceptPartsNo.Equals(receivedTelegram.AnswerPartsNo))
            {
                string substPartsNo = receivedTelegram.AnswerPartsNo;
                CurrentUOEOrderDetailRecord.SubstPartsNo = substPartsNo;
            }
        }

        #endregion  // <063.��֕i��/>

        #region <064.UOE���_�o�ɐ�/>

        /// <summary>
        /// UOE���_�o�ɐ����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̏o�א��@����M�d���̗\���R�[�h��0�y�уX�y�[�X�ȊO�̏ꍇ�ɂ̓}�C�i�X�Ƃ���
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected virtual void MergeUOESectOutGoodsCnt(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //int uoeSectOutGoodsCnt = int.Parse(receivedTelegram.UOESectOutGoodsCount);
            int uoeSectOutGoodsCnt = TStrConv.StrToIntDef(receivedTelegram.UOESectOutGoodsCount.Trim(), 0);
            // 2009/10/14 <<<

            string reserveCode = receivedTelegram.UOEMarkCode.Trim();
            if (reserveCode.Equals("0") || string.IsNullOrEmpty(reserveCode))
            {
                CurrentUOEOrderDetailRecord.UOESectOutGoodsCnt = uoeSectOutGoodsCnt;
            }
            else
            {
                if (uoeSectOutGoodsCnt > 0) uoeSectOutGoodsCnt *= (-1);
                CurrentUOEOrderDetailRecord.UOESectOutGoodsCnt = uoeSectOutGoodsCnt;
            }
        }

        #endregion  // <064.UOE���_�o�ɐ�/>

        #region <065.BO�o�ɐ�1/>

        /// <summary>
        /// BO�o�ɐ�1���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d����B/O���@����M�d���̗\���R�[�h��0�y�уX�y�[�X�ȊO�̏ꍇ�ɂ̓}�C�i�X�Ƃ���
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeBOShipmentCnt1(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //int boShipmentCnt1 = int.Parse(receivedTelegram.BOShipmentCount);
            int boShipmentCnt1 = TStrConv.StrToIntDef(receivedTelegram.BOShipmentCount.Trim(), 0);
            // 2009/10/14 <<<

            string reserveCode = receivedTelegram.UOEMarkCode.Trim();
            if (reserveCode.Equals("0") || string.IsNullOrEmpty(reserveCode))
            {
                CurrentUOEOrderDetailRecord.BOShipmentCnt1 = boShipmentCnt1;
            }
            else
            {
                if (boShipmentCnt1 > 0) boShipmentCnt1 *= (-1);
                CurrentUOEOrderDetailRecord.BOShipmentCnt1 = boShipmentCnt1;
            }
        }

        #endregion  // <065.BO�o�ɐ�1/>

        #region <074.UOE���_�`�[�ԍ�/>

        /// <summary>
        /// UOE���_�`�[�ԍ����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̏o�ד`�[�ԍ�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeUOESectionSlipNo(ReceivedText receivedTelegram)
        {
            string uoeSectionSlipNo = receivedTelegram.UOESectionSlipNo;
            CurrentUOEOrderDetailRecord.UOESectionSlipNo = uoeSectionSlipNo;
        }

        #endregion  // <074.UOE���_�`�[�ԍ�/>

        #region <075.BO�`�[�ԍ�1/>

        /// <summary>
        /// BO�`�[�ԍ�1���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d����B/O�o�ד`�[
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeBOSlipNo1(ReceivedText receivedTelegram)
        {
            string boSlipNo1 = receivedTelegram.BOSlipNo;
            CurrentUOEOrderDetailRecord.BOSlipNo1 = boSlipNo1;
        }

        #endregion  // <075.BO�`�[�ԍ�1/>

        #region <080.�񓚒艿/>

        /// <summary>
        /// �񓚒艿���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̒艿
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeAnswerListPrice(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //double answerListPrice = double.Parse(receivedTelegram.AnswerListPrice);
            double answerListPrice = TStrConv.StrToDoubleDef(receivedTelegram.AnswerListPrice.Trim(), 0);
            // 2009/10/14 <<<
            CurrentUOEOrderDetailRecord.AnswerListPrice = answerListPrice;
        }

        #endregion  // <080.�񓚒艿/>

        #region <081.�񓚌����P��/>

        /// <summary>
        /// �񓚌����P�����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̎d�ؒP��
        /// �������Y�Ƃ͏����_1�ʂ܂łƂȂ�10�{�l���Z�b�g����Ă���ׁA�����_�t���ŃZ�b�g�@�����ȊO�͂��̂܂�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected virtual void MergeAnswerSalesUnitCost(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //double answerSalesUnitCost = double.Parse(receivedTelegram.AnswerSalesUnitCost);
            double answerSalesUnitCost = TStrConv.StrToDoubleDef(receivedTelegram.AnswerSalesUnitCost.Trim(), 0);
            // 2009/10/14 <<<
            CurrentUOEOrderDetailRecord.AnswerSalesUnitCost = answerSalesUnitCost;
        }

        #endregion  // <081.�񓚌����P��/>

        #region <106.UOE�}�[�N�R�[�h/>

        /// <summary>
        /// UOE�}�[�N�R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̗\���R�[�h�i�����ȊO��<c>0</c>���Z�b�g�j
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected virtual void MergeUOEMarkCode(ReceivedText receivedTelegram)
        {
            CurrentUOEOrderDetailRecord.UOEMarkCode = "0";
        }

        #endregion  // <106.UOE�}�[�N�R�[�h/>

        #region <109.�`�F�b�N�R�[�h/>

        /// <summary>
        /// �`�F�b�N�R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �`�F�b�N�R�[�h
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeUOECheckCode(ReceivedText receivedTelegram)
        {
            string uoeCheckCode = receivedTelegram.UOECheckCode;
            CurrentUOEOrderDetailRecord.UOECheckCode = uoeCheckCode;
        }
         
        #endregion  // <109.�`�F�b�N�R�[�h/>

        #region <111.���C���G���[/>

        /// <summary>
        /// ���C���G���[���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���C���G���[
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeLineErrorMessage(ReceivedText receivedTelegram)
        {
            string lineErrorMessage = receivedTelegram.LineErrorMessage;
            CurrentUOEOrderDetailRecord.LineErrorMassage = lineErrorMessage;
        }

        #endregion  // <111.���C���G���[/>

        /// <summary>�f�[�^���M/�����敪�̐���I���萔</summary>
        protected const int NORMAL_DATA_STATE = 9;

        #region <112.�f�[�^���M�敪/>

        /// <summary>
        /// �f�[�^���M�敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 9:����I��
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeDataSendCode(ReceivedText receivedTelegram)
        {
            CurrentUOEOrderDetailRecord.DataSendCode = NORMAL_DATA_STATE;
        }

        #endregion  // <112.�f�[�^���M�敪/>

        #region <113.�f�[�^�����敪/>

        /// <summary>
        /// �f�[�^�����敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 9:����I��
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeDataRecoverDiv(ReceivedText receivedTelegram)
        {
            CurrentUOEOrderDetailRecord.DataRecoverDiv = NORMAL_DATA_STATE;
        }

        #endregion  // <113.�f�[�^�����敪/>

        /// <summary>
        /// ���ɍX�V�敪�񋓑�
        /// </summary>
        protected enum EnterUpdateDiv : int
        {
            /// <summary>������</summary>
            NotEnterd = 0,
            /// <summary>���ɍ�</summary>
            Enterd = 1
        }

        #region <114.���ɍX�V�敪�i���_�j/>

        /// <summary>
        /// ���ɍX�V�敪�i���_�j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �������ɍX�V�敪�������c1:���ɍ�<br/>
        /// �������ɍX�V�敪���蓮�c0:������
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeEnterUpdDivSec(ReceivedText receivedTelegram)
        {
            int enterUpdDivSec = (int)EnterUpdateDiv.NotEnterd;
            if (LoginWorkerAcs.Instance.Policy.UOESetting.DistEnterDiv.Equals((int)LoginWorker.OroshishoDistEnterDiv.Auto))
            {
                enterUpdDivSec = (int)EnterUpdateDiv.Enterd;
            }
            CurrentUOEOrderDetailRecord.EnterUpdDivSec = enterUpdDivSec;
        }

        #endregion  // <114.���ɍX�V�敪�i���_�j/>

        #region <115.���ɍX�V�敪�iBO1�j/>

        /// <summary>
        /// ���ɍX�V�敪�iBO1�j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 1:���ɍ�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeEnterUpdDivBO1(ReceivedText receivedTelegram)
        {
            CurrentUOEOrderDetailRecord.EnterUpdDivBO1 = (int)EnterUpdateDiv.Enterd;
        }

        #endregion  // <115.���ɍX�V�敪�iBO1�j/>

        #region <116.���ɍX�V�敪�iBO2�j/>

        /// <summary>
        /// ���ɍX�V�敪�iBO2�j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 1:���ɍ�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeEnterUpdDivBO2(ReceivedText receivedTelegram)
        {
            CurrentUOEOrderDetailRecord.EnterUpdDivBO2 = (int)EnterUpdateDiv.Enterd;
        }

        #endregion  // <116.���ɍX�V�敪�iBO2�j/>

        #region <117.���ɍX�V�敪�iBO3�j/>

        /// <summary>
        /// ���ɍX�V�敪�iBO3�j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 1:���ɍ�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeEnterUpdDivBO3(ReceivedText receivedTelegram)
        {
            CurrentUOEOrderDetailRecord.EnterUpdDivBO3 = (int)EnterUpdateDiv.Enterd;
        }

        #endregion  // <117.���ɍX�V�敪�iBO3�j/>

        #region <118.���ɍX�V�敪�i���[�J�[�j/>

        /// <summary>
        /// ���ɍX�V�敪�i���[�J�[�j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 1:���ɍ�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeEnterUpdDivMaker(ReceivedText receivedTelegram)
        {
            CurrentUOEOrderDetailRecord.EnterUpdDivMaker = (int)EnterUpdateDiv.Enterd;
        }

        #endregion  // <118.���ɍX�V�敪�i���[�J�[�j/>

        #region <119.���ɍX�V�敪�iEO�j/>

        /// <summary>
        /// ���ɍX�V�敪�iEO�j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 1:���ɍ�
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeEnterUpdDivEO(ReceivedText receivedTelegram)
        {
            CurrentUOEOrderDetailRecord.EnterUpdDivEO = (int)EnterUpdateDiv.Enterd;
        }

        #endregion  // <119.���ɍX�V�敪�iEO�j/>

        #region <120.���׊֘A�t��GUID/>

        /// <summary>
        /// ���׊֘A�t��GUID���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �Ή�����d�����׃f�[�^�i�������j�̃��R�[�h�Ɠ����l<br/>
        /// ��M�d���ɂ�GUID���ݒ肳��A
        /// �@��M�d�� - UOE�����f�[�^ - �d�����׃f�[�^�@
        /// �̊֘A�t�����s���܂��B
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected void MergeDtlRelationGiid(ReceivedText receivedTelegram)
        {
            if (CurrentUOEOrderDetailRecord.DtlRelationGuid.Equals(Guid.Empty))
            {
                CurrentUOEOrderDetailRecord.DtlRelationGuid = Guid.NewGuid();
            }
            receivedTelegram.DtlRelationGuid = CurrentUOEOrderDetailRecord.DtlRelationGuid;
        }

        #endregion  // <120.���׊֘A�t��GUID/>
    }

    #region <SPK/>

    /// <summary>
    /// SPK�pUOE�����f�[�^�̍\�z�҃N���X
    /// </summary>
    public sealed class SPKOrderDataBuilder : UOEOrderDataBuilder
    {
        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        /// <param name="receivedTelegramAgreegate">��M�d���̏W����</param>
        /// <param name="observer">�ȈՃI�u�U�[�o�[</param>
        public SPKOrderDataBuilder(
            UOESupplierHelper uoeSupplier,
            IAgreegate<ReceivedText> receivedTelegramAgreegate,
            IProgressUpdatable observer
        ) : base(uoeSupplier, receivedTelegramAgreegate, observer)
        { }

        #endregion  // <Constructor/>
    }

    #endregion  // <SPK/>

    #region <�����Y��/>

    /// <summary>
    /// �����Y�ƗpUOE�����f�[�^�̍\�z�҃N���X
    /// </summary>
    public sealed class MeijiOrderDataBuilder : UOEOrderDataBuilder
    {
        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        /// <param name="receivedTelegramAgreegate">��M�d���̏W����</param>
        /// <param name="observer">�ȈՃI�u�U�[�o�[</param>
        public MeijiOrderDataBuilder(
            UOESupplierHelper uoeSupplier,
            IAgreegate<ReceivedText> receivedTelegramAgreegate,
            IProgressUpdatable observer
        ) : base(uoeSupplier, receivedTelegramAgreegate, observer)
        { }

        #endregion  // <Constructor/>

        /// <summary>"*D"�F��M�d���̃��}�[�N</summary>
        private const string ASTERISK_D_REMARK = "*D";

        // ---- ADD  2013/10/09 ���N�n�� Redmine40628---- >>>>>
        //Thread���A���b�Z�[�W�֌W
        private const string MSGSHOWSOLT = "MSGSHOWSOLT";
        private LocalDataStoreSlot msgShowSolt = null;

        #region ���񋓑�
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>�������[�U</summary>
            OFF = 0,
            /// <summary>�L�����[�U</summary>
            ON = 1,
        }
        #endregion

        /// <summary>�e�L�X�g�o�̓I�v�V�������</summary>
        private int _opt_FuTaBa;//OPT-CPM0110�F�t�^�oUOE�I�v�V�����i�ʁj

        //��pUSB�p
        Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
        // ---- ADD  2013/10/09 ���N�n�� Redmine40628---- <<<<<

        /// <summary>
        /// �q�ɁE�I�Ԃ�ݒ�ł��邩���肵�܂��B
        /// </summary>
        /// <remarks>
        /// �ڑ��悪�����Y�ƂŔ�����}�X�^���Ver��"1:�V"�̏ꍇ�Ń��}�[�N��"*D"���ݒ肳��Ă���ꍇ�͖��ݒ�Ƃ���
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <returns>
        /// <c>true</c> :�ݒ�ł���<br/>
        /// <c>false</c>:�ݒ�ł��Ȃ�
        /// </returns>
        private bool CanSetWarehouse(ReceivedText receivedTelegram)
        {
            //return !(UoeSupplier.IsNewVersion() && receivedTelegram.UOERemark.Trim().Equals(ASTERISK_D_REMARK));// DEL 2012/12/10 yangmj FOR redmine#32926PM�f�[�^�ƘA�g�����Ȃ�
            //----- ADD 2012/12/10 yangmj FOR redmine#32926PM�f�[�^�ƘA�g�����Ȃ�----->>>>>
            //���M�݂̂̏ꍇ�A���}�[�N�̐擪��ʁu*D�v�̏ꍇ�A�ݒ�ł��Ȃ�
            if (UoeSupplier.RealUOESupplier.ReceiveCondition.Equals((int)UOESupplierUtil.ReceiveConditionDiv.SendOnly))
            {
                if (!(string.IsNullOrEmpty(receivedTelegram.UOERemark) || receivedTelegram.UOERemark.Length < 2))
                {
                    return !(UoeSupplier.IsNewVersion() && receivedTelegram.UOERemark.Substring(0, 2).Trim().Equals(ASTERISK_D_REMARK));
                }
                //���M�݂̂̏ꍇ�A���}�[�N�̐擪��ʁu*D�v�ȊO�̏ꍇ�A�ݒ�ł���
                return true;
            }
            else
            {
                //����M�\�̏ꍇ�A���}�[�N��"*D"���ݒ肳��Ă���ꍇ�͖��ݒ�Ƃ���
                return !(UoeSupplier.IsNewVersion() && receivedTelegram.UOERemark.Trim().Equals(ASTERISK_D_REMARK));
            }
            //----- ADD 2012/12/10 yangmj FOR redmine#32926PM�f�[�^�ƘA�g�����Ȃ�-----<<<<<
        }

        #region <Override/>

        /// <summary>
        /// �q�ɃR�[�h���}�[�W���܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        protected override void MergeWarehouseCode(ReceivedText receivedTelegram)
        {
            if (CanSetWarehouse(receivedTelegram))
            {
                base.MergeWarehouseCode(receivedTelegram);
            }
            else
            {
                CurrentUOEOrderDetailRecord.WarehouseCode = string.Empty;
            }
        }

        /// <summary>
        /// �q�ɖ��̂��}�[�W���܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        protected override void MergeWarehouseName(ReceivedText receivedTelegram)
        {
            if (CanSetWarehouse(receivedTelegram))
            {
                base.MergeWarehouseName(receivedTelegram);
            }
            else
            {
                CurrentUOEOrderDetailRecord.WarehouseName = string.Empty;
            }
        }

        /// <summary>
        /// �q�ɒI�Ԃ��}�[�W���܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        protected override void MergeWarehouseShelfNo(ReceivedText receivedTelegram)
        {
            if (CanSetWarehouse(receivedTelegram))
            {
                base.MergeWarehouseShelfNo(receivedTelegram);
            }
            else
            {
                CurrentUOEOrderDetailRecord.WarehouseShelfNo = string.Empty;
            }
        }

        /// <summary>
        /// UOE���_�o�ɐ����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �ڑ��悪�����Y�Ƃ̏ꍇ�ŁA�\���R�[�h��<c>1</c>�̏ꍇ�ɂ�UOE���_�o�ɐ���<c>-1</c>���|����
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected override void MergeUOESectOutGoodsCnt(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //int uoeSectOutGoodsCnt = int.Parse(receivedTelegram.UOESectOutGoodsCount);
            int uoeSectOutGoodsCnt = TStrConv.StrToIntDef(receivedTelegram.UOESectOutGoodsCount.Trim(), 0);
            // 2009/10/14 <<<

            if (receivedTelegram.UOEMarkCode.Trim().Equals("1"))
            {
                CurrentUOEOrderDetailRecord.UOESectOutGoodsCnt = (-1) * uoeSectOutGoodsCnt;
            }
            else
            {
                CurrentUOEOrderDetailRecord.UOESectOutGoodsCnt = uoeSectOutGoodsCnt;
            }
        }

        /// <summary>
        /// �񓚌����P�����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �����Y�Ƃ͏����_��1�ʂ܂łƂȂ�10�{�l���Z�b�g����Ă���ׁA�����_�t���ŃZ�b�g
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected override void MergeAnswerSalesUnitCost(ReceivedText receivedTelegram)
        {
            // ---- ADD  2013/10/09 ���N�n�� Redmine40628---- >>>>>
            //OPT-CPM0110�F�t�^�oUOE�I�v�V�����i�ʁj
            fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);

            if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuTaBa = (int)Option.ON;
            }
            else
            {
                this._opt_FuTaBa = (int)Option.OFF;
            }
            // ---- ADD  2013/10/09 ���N�n�� Redmine40628---- <<<<<
            // 2009/10/14 >>>
            //int nAnswerSalesUnitCost    = int.Parse(receivedTelegram.AnswerSalesUnitCost);
            int nAnswerSalesUnitCost = TStrConv.StrToIntDef(receivedTelegram.AnswerSalesUnitCost.Trim(), 0);
            // 2009/10/14 <<<

            // ---- ADD  2013/10/09 ���N�n�� Redmine40628---- >>>>>
            double answerSalesUnitCost = 0.0;
            //�t�^�oUSB��p
            if (this._opt_FuTaBa == (int)Option.ON)
            {
                msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);

                //������M����(�蓮)�ł���ꍇ
                if (!(Thread.GetData(msgShowSolt) != null
                    && ((Int32)Thread.GetData(msgShowSolt) == 1
                    || (Int32)Thread.GetData(msgShowSolt) == 2
                    || (Int32)Thread.GetData(msgShowSolt) == 3
                    || (Int32)Thread.GetData(msgShowSolt) == 4)))
                {
                    answerSalesUnitCost = ((double)nAnswerSalesUnitCost) / 10.0;
                }
                else
                {
                    answerSalesUnitCost = (double)nAnswerSalesUnitCost;
                }

            }
            else
            {
                answerSalesUnitCost = ((double)nAnswerSalesUnitCost) / 10.0;
            }
            // ---- ADD  2013/10/09 ���N�n�� Redmine40628---- <<<<<

            //double answerSalesUnitCost = ( (double)nAnswerSalesUnitCost ) / 10.0;//DEL  2013/10/09 ���N�n�� Redmine40628

            CurrentUOEOrderDetailRecord.AnswerSalesUnitCost = answerSalesUnitCost;
        }

        /// <summary>
        /// UOE�}�[�N�R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̗\���R�[�h�i�����ȊO��<c>0</c>���Z�b�g�j
        /// </remarks>
        /// <param name="receivedTelegram">��M�d��</param>
        protected override void MergeUOEMarkCode(ReceivedText receivedTelegram)
        {
            string uoeMarkCode = receivedTelegram.UOEMarkCode;
            CurrentUOEOrderDetailRecord.UOEMarkCode = uoeMarkCode;
        }

        #endregion  // <Override/>
    }

    #endregion  // <�����Y��/>
}
