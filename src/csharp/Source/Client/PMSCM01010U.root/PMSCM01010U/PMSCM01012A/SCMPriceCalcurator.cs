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
// �� �� ��  2009/06/09  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b
// �� �� ��  2011/06/28  �C�����e : �L�����y�[���Ǘ�
//                               :   �L�����y�[���Ǘ��}�X�^�̕ύX�ɔ����ύX�B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/15  �C�����e : Redmine#22829 �����񓚁A�蓮�񓚂̗����Ŕ������̎Z�o���@���s���̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/20  �C�����e : Redmine#22829�u�|���}�X�^/�������v�Ɓu�L�����y�[��/�������v�������q�b�g����ꍇ�A���ו������F�ɂȂ�܂��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS wangqx
// �C �� ��  2011/09/19  �C�����e : Redmine#25267 �艿�i�ō��C�����j�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/09/22  �C�����e : Redmine#25500 PCCUOE�^PM���@������ �L�����y�[���l�������ݒ肳��Ă���ꍇ�̔��P���s���̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����@��
// �C �� ��  2012/10/10  �C�����e : SCM��Q����No10368�Ή� Redmine#25500�̏C�������ɖ߂�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g���@�F��
// �� �� ��  2013/01/18  �C�����e : 2013/03/13�z�M SCM��Q��10475�Ή� �����񓚂��x��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30747 �O�� �L��
// �� �� ��  2012/10/01  �C�����e : 2013/04/10�z�M�� SCM��Q��27 �����A�g�l���͎����񓚎��̂ݓK�p
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 20056 ���n ���
// �� �� ��  2013/04/14  �C�����e : 2013/04/17�z�M�� 10517:�����A�g�l�������������ꍇ�A�[������������ɏ�������Ă��܂���B�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902175-00 �쐬�S�� : �{�{ ����
// �� �� ��  2013/08/07  �C�����e : Redmine#39620(��#128)�Ή�
//                                  ���Аݒ�̊|���D�揇�ʂ��Q�Ƃ���悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �����M
// �� �� ��  2013/04/17  �C�����e : �z�M���Ȃ���  Redmine#35271
//			                        No.184 �o�l���G���g���[ �Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/10/25  �C�����e : 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/01/30  �C�����e : Redmine#41771 ��Q��13�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/02/05  �C�����e : SCM�d�|�ꗗ��10627�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g�� �F��
// �� �� ��  2014/02/05  �C�����e : �d�|�ꗗ��10631 �����񓚑��x���P �|���}�X�^�L���b�V��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070076-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2014/05/08  �C�����e : PM-SCM���x���� �t�F�[�Y�Q�Ή�
//                                : 01.���i�����A�N�Z�X�N���X�␳�����v���p�e�B�Ή�
//                                : 02.���Ӑ�|���O���[�v�}�X�^�擾���ǑΉ��i�񓚔��莞�j
//                                : 03.�ύX�O�P���v�Z�ďo�񐔉��ǑΉ�
//                                : 04.�L�����y�[�������ݒ�}�X�^�擾���ǑΉ�
//                                : 05.���Ӑ�}�X�^�i�`�[�Ǘ��j�擾���ǑΉ�
//                                : 06.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�j
//                                : 07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j
//                                : 08.����f�[�^�������̃V�X�e�����t�擾�Ή�
//                                : 09.���Ӑ�|���O���[�v�}�X�^�擾���ǑΉ��i����f�[�^�������j
//                                : 10.�P���v�Z�ďo�񐔉���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : duzg
// �� �� ��  2014/08/11  �C�����e : ���؁^�����e�X�g��QNo.5
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2015/03/18  �C�����e : SCM������ ���[�J�[��]�������i�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2015/04/01  �C�����e : SCM������ ���[�J�[��]�������i�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11600006-00 �쐬�S�� : �c����
// �C �� ��  2020/05/15  �C�����e : PMKOBETSU-3932 BLP��Q�i���O�����j
//                                : �����R�[�h�̃��O�o�͋������s��
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using SalesProcMoneyServer  = SingletonInstance<SalesProcMoneyAgent>;   // ������z�����敪�}�X�^
    using SCMTotalSettingServer = SingletonInstance<SCMTotalSettingAgent>;  // SCM�S�̐ݒ�}�X�^

    /// <summary>
    /// ���i�Z�o�N���X
    /// </summary>
    public sealed class SCMPriceCalculator
    {
        private const string MY_NAME = "SCMPriceCalculator";    // ���O�p
        /// <summary>�L�����y�[���Ǘ����X�g</summary>
        private CampaignObjGoodsSt campaignMng;      // ADD 2011/07/15

        // -------- ADD �����M 2013/04/17 for Redmine#35271 ------ >>>>>
        /// <summary>���ےl���K�p�t���O</summary>
        private bool _isDiscountApply = false; // ���ےl���K�p����������

        /// <summary>���ےl���K�p�t���O���擾���܂��B</summary>
        public bool IsDiscountApply
        {
            get { return this._isDiscountApply; }
        }
        // -------- ADD �����M 2013/04/17 for Redmine#35271 ------ <<<<<

        // ADD 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // UPD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j ---------------------------------->>>>>
        //CampaignObjGoodsStAcs campaignObjGoodsStAcs = new CampaignObjGoodsStAcs();
        private CampaignObjGoodsStAcs _campaignObjGoodsStAcs;
        private CampaignObjGoodsStAcs CampaignObjGoodsStAcs
        {
            get
            {
                if (this._campaignObjGoodsStAcs == null)
                {
                    this._campaignObjGoodsStAcs = new CampaignObjGoodsStAcs();
                }
                return this._campaignObjGoodsStAcs;
            }
        }
        // UPD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j ----------------------------------<<<<<
        // ADD 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        #region <�i�Ԍ���>

        /// <summary>�i�Ԍ����A�N�Z�T</summary>
        private GoodsAcs _goodsAccesser;
        /// <summary>�i�Ԍ����A�N�Z�T���擾���܂��B</summary>
        private GoodsAcs GoodsAccesser
        {
            get
            {
                if (_goodsAccesser == null)
                {
                    _goodsAccesser = new GoodsAcs(LoginSectionCode);
                    {
                        string msg = string.Empty;
                        _goodsAccesser.SearchInitial(CurrentEnterpriseCode, LoginSectionCode, out msg);
                    }
                }
                return _goodsAccesser;
            }
        }

        #endregion // </�i�Ԍ���>

        #region <���i�n�Z�o>

        /// <summary>���i�n�Z�o</summary>
        private CalculatorAgent _calculator;
        /// <summary>���i�n�Z�o���擾���܂��B</summary>
        private CalculatorAgent Calculator
        {
            get
            {
                if (_calculator == null)
                {
                    _calculator = new CalculatorAgent();
                }
                return _calculator;
            }
        }

        #endregion // </���i�n�Z�o>

        #region <���݂�SCM�󒍃f�[�^>

        /// <summary>���݂̓��Ӑ�R�[�h</summary>
        private int _currentCustomerCode;
        /// <summary>���݂̓��Ӑ�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        private int CurrentCustomerCode { get { return _currentCustomerCode; } }

        /// <summary>���݂�SCM�󒍖��׃f�[�^(�⍇���E����)</summary>
        private ISCMOrderDetailRecord _currentDetailRecord;
        /// <summary>���݂�SCM�󒍖��׃f�[�^(�⍇���E����)���擾�܂��͐ݒ肵�܂��B</summary>
        private ISCMOrderDetailRecord CurrentDetailRecord { get { return _currentDetailRecord; } }

        /// <summary>
        /// ���݂�SCM�󒍃f�[�^��ݒ肵�܂��B
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="detailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</param>
        public void SetCurrentSCMOrderData(
            int customerCode,
            ISCMOrderDetailRecord detailRecord
        )
        {
            _currentCustomerCode = customerCode;
            _currentDetailRecord = detailRecord;
            Calculator.CustomerDB.TakeCustomerInfo(_currentDetailRecord.InqOtherEpCd, _currentCustomerCode);

            _currentTaxRateSet = new TaxRateSetAgent(CurrentEnterpriseCode);

        }

        // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------>>>>>
        /// <summary>
        /// ���݂�SCM�󒍃f�[�^��ݒ肵�܂��B
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="detailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</param>
        /// <param name="headerRecord">SCM�󒍃f�[�^�̃��R�[�h</param>
        public void SetCurrentSCMOrderData(
            int customerCode,
            ISCMOrderDetailRecord detailRecord,
            ISCMOrderHeaderRecord headerRecord
        )
        {
            _currentCustomerCode = customerCode;
            _currentDetailRecord = detailRecord;
            Calculator.CustomerDB.TakeCustomerInfo(_currentDetailRecord.InqOtherEpCd, _currentCustomerCode);

            _currentTaxRateSet = new TaxRateSetAgent(CurrentEnterpriseCode);
            _currentTaxRateSet.TaxRateDate = headerRecord.InquiryDate;
            _currentTaxRateSet.CancelDiv = headerRecord.CancelDiv;
        }
        // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------<<<<<

        /// <summary>
        /// ���݂�SCM�󒍃f�[�^��ݒ肵�܂��B
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        public void SetCurrentSCMOrderData(
            int customerCode,
            SalesDetail salesDetail
        )
        {
            _currentEnterpriseCode  = salesDetail.EnterpriseCode;
            _loginSectionCode       = salesDetail.SectionCode;
            _currentCustomerCode    = customerCode;
            Calculator.CustomerDB.TakeCustomerInfo(_currentEnterpriseCode, _currentCustomerCode);

            _currentTaxRateSet = new TaxRateSetAgent(CurrentEnterpriseCode);
            // ADD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------>>>>>
            _currentTaxRateSet.CancelDiv = 0;
            _currentTaxRateSet.TaxRateDate = salesDetail.SalesDate;
            // ADD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------<<<<<
            _currentDetailRecord = null;
        }

        // ADD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------>>>>>
        /// <summary>
        /// ���݂�SCM�󒍃f�[�^��ݒ肵�܂��B
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        /// <param name="cancelDiv">�L�����Z���敪</param>
        /// <param name="inquryDate">�⍇����</param>
        public void SetCurrentSCMOrderData(
            int customerCode,
            SalesDetail salesDetail,
            short cancelDiv,
            DateTime inquryDate
        )
        {
            _currentEnterpriseCode = salesDetail.EnterpriseCode;
            _loginSectionCode = salesDetail.SectionCode;
            _currentCustomerCode = customerCode;
            Calculator.CustomerDB.TakeCustomerInfo(_currentEnterpriseCode, _currentCustomerCode);

            _currentTaxRateSet = new TaxRateSetAgent(CurrentEnterpriseCode);
            _currentTaxRateSet.CancelDiv = cancelDiv;
            _currentTaxRateSet.TaxRateDate = inquryDate;
            _currentDetailRecord = null;
        }
        // ADD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------<<<<<

        /// <summary>���݂̊�ƃR�[�h</summary>
        private string _currentEnterpriseCode;
        /// <summary>
        /// ���݂̊�ƃR�[�h�擾���܂��B
        /// </summary>
        private string CurrentEnterpriseCode
        {
            get
            {
                if (CurrentDetailRecord != null)
                {
                    return CurrentDetailRecord.InqOtherEpCd;
                }
                else
                {
                    return _currentEnterpriseCode;
                }
            }
        }

        /// <summary>���O�C�����_�R�[�h</summary>
        private string _loginSectionCode;
        /// <summary>
        /// ���O�C�����_�R�[�h���擾���܂��B
        /// </summary>
        private string LoginSectionCode
        {
            get
            {
                return CurrentDetailRecord != null ? CurrentDetailRecord.InqOtherSecCd : _loginSectionCode;
            }
        }

        /// <summary>
        /// ���݂̓��Ӑ�����擾���܂��B
        /// </summary>
        private CustomerInfo CurrentCustomerInfo
        {
            get
            {
                if (Calculator.CustomerDB.CustomerInfoMap.ContainsKey(CurrentCustomerCode))
                {
                    return Calculator.CustomerDB.CustomerInfoMap[CurrentCustomerCode];
                }
                else
                {
                    Calculator.CustomerDB.TakeCustomerInfo(CurrentEnterpriseCode, CurrentCustomerCode);
                    if (Calculator.CustomerDB.CustomerInfoMap.ContainsKey(CurrentCustomerCode))
                    {
                        return Calculator.CustomerDB.CustomerInfoMap[CurrentCustomerCode];
                    }
                    else
                    {
                        return new CustomerInfo();
                    }
                }
            }
        }

        /// <summary>���݂̐ŗ��ݒ�}�X�^</summary>
        private TaxRateSetAgent _currentTaxRateSet;
        /// <summary>���݂̐ŗ��ݒ�}�X�^���擾���܂��B</summary>
        private TaxRateSetAgent CurrentTaxRateSet
        {
            get
            {
                if (_currentTaxRateSet == null)
                {
                    _currentTaxRateSet = new TaxRateSetAgent(CurrentEnterpriseCode);
                }
                return _currentTaxRateSet;
            }
        }

        /// <summary>
        /// ���݂̓��Ӑ�|���O���[�v���擾���܂��B
        /// </summary>
        private List<CustRateGroup> CurrentCustomerRateGroupList
        {
            get
            {
                if (Calculator.CustomerDB.CustomerRateGroupMap.ContainsKey(CurrentCustomerCode))
                {
                    return Calculator.CustomerDB.CustomerRateGroupMap[CurrentCustomerCode];
                }
                else
                {
                    Calculator.CustomerDB.TakeCustomerInfo(CurrentEnterpriseCode, CurrentCustomerCode);
                    if (Calculator.CustomerDB.CustomerRateGroupMap.ContainsKey(CurrentCustomerCode))
                    {
                        return Calculator.CustomerDB.CustomerRateGroupMap[CurrentCustomerCode];
                    }
                    else
                    {
                        return new List<CustRateGroup>();
                    }
                }
            }
        }

        /// <summary>
        /// ���݂�SCM�S�̐ݒ���擾���܂��B
        /// </summary>
        private SCMTtlSt CurrentSCMTotalSetting
        {
            get
            {
                SCMTtlSt scmTtlSt = SCMTotalSettingServer.Singleton.Instance.Find(CurrentEnterpriseCode, LoginSectionCode);
                if (!SCMDataHelper.IsAvailableRecord(scmTtlSt))
                {
                    scmTtlSt = null;
                }
                return scmTtlSt;
            }
        }

        #endregion // </���݂�SCM�󒍃f�[�^>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SCMPriceCalculator() { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="goodsAccesser">�i�Ԍ����A�N�Z�T</param>
        public SCMPriceCalculator(GoodsAcs goodsAccesser)
        {
            _goodsAccesser = goodsAccesser;
        }

        #endregion // </Constructor>

        /// <summary>
        /// �P���Z�o�����iPartsInfoDataSet.CalculateUnitPrice += �f���Q�[�g�Ɏg�p�j
        /// </summary>
        /// <remarks>MAHNB01012AB.cs l.1792 SalesSlipInputAcs.CalculateUnitPrice() ���Q�l</remarks>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�̃��X�g</param>
        /// <param name="unitPriceCalcRetList">�P���Z�o���ʂ̃��X�g</param>
        public void CalculateUnitPrice(
            List<GoodsUnitData> goodsUnitDataList,
            out List<UnitPriceCalcRet> unitPriceCalcRetList
        )
        {
            #region <Guard Phrase>

            unitPriceCalcRetList = null;

            if ((goodsUnitDataList == null) || (goodsUnitDataList.Count.Equals(0))) return;

            #endregion // </Guard Phrase>
            
            SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, false, LoginSectionCode);

            //-----------------------------------------------------------------------------
            // �P�����擾
            //-----------------------------------------------------------------------------
            unitPriceCalcRetList = CalclationUnitPrice(goodsUnitDataList);
        }

        #region <�P���Z�o�����p>

        /// <summary>
        /// ���i�A���f�[�^�s�����ݒ�
        /// </summary>
        /// <remarks>MAHNB01012AD.cs l.1792 SalesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst() ���Q�l</remarks>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�̃��X�g</param>
        /// <param name="isSettingSupplier">???�t���O</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        private void SettingGoodsUnitDataListFromVariousMst(
            ref List<GoodsUnitData> goodsUnitDataList,
            bool isSettingSupplier,
            string sectionCode
        )
        {
            const string METHOD_NAME = "SettingGoodsUnitDataListFromVariousMst()";  // ���O�p

            List<GoodsUnitData> retGoodsUnitDataList = new List<GoodsUnitData>();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                GoodsUnitData retGoodsUnitData = goodsUnitData.Clone();

                #region <Log>

                string msg = string.Format(
                    "���i�A���f�[�^�̕s�����Őݒ肵�����_�R�[�h=�u{0}�v���u{1}�v",
                    retGoodsUnitData.SectionCode,
                    sectionCode
                );
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                retGoodsUnitData.SectionCode = sectionCode;
                EasyLogger.Write(MY_NAME, METHOD_NAME, "���i�A���f�[�^�s�����ݒ� �J�n"); // ADD 2020/05/15 �c���� PMKOBETSU-3932 BLP��Q�i���O�����j
                SettingGoodsUnitDataListFromVariousMst(ref retGoodsUnitData, isSettingSupplier);
                EasyLogger.Write(MY_NAME, METHOD_NAME, "���i�A���f�[�^�s�����ݒ� ����"); // ADD 2020/05/15 �c���� PMKOBETSU-3932 BLP��Q�i���O�����j
                retGoodsUnitDataList.Add(retGoodsUnitData);
            }
            goodsUnitDataList = retGoodsUnitDataList;

            #region <Log>

            string info = "�s�����̐ݒ茋��" + Environment.NewLine + SCMDataHelper.GetProfile(goodsUnitDataList);
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(info));

            #endregion // </Log>
        }

        /// <summary>
        /// ���i�A���f�[�^�s�����ݒ�
        /// </summary>
        /// <remarks>MAHNB01012AD.cs l.1800 SalesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst() ���Q�l</remarks>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="isSettingSupplier">???�t���O</param>
        private void SettingGoodsUnitDataListFromVariousMst(
            ref GoodsUnitData goodsUnitData,
            bool isSettingSupplier
        )
        {
            //GoodsAccesser.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, (isSettingSupplier ? 0 : 1));// Del 2014/08/11 duzg For ���؁^�����e�X�g��QNo.5
            GoodsAccesser.SettingGoodsUnitDataFromVariousMst2(ref goodsUnitData, (isSettingSupplier ? 0 : 1));// Add 2014/08/11 duzg For ���؁^�����e�X�g��QNo.5
        }

        /// <summary>
        /// �P���Z�o���W���[���ɂ��A�P�����Z�o���܂��B
        /// </summary>
        /// <remarks>MAHNB01012AB.cs l.9609 SalesSlipInputAcs.CalclationUnitPrice() ���Q�l</remarks>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <returns></returns>
        private List<UnitPriceCalcRet> CalclationUnitPrice(List<GoodsUnitData> goodsUnitDataList)
        {
            string enterpriseCode   = CurrentEnterpriseCode;    // ��ƃR�[�h
            string sectionCode      = LoginSectionCode;         // ���_�R�[�h

            // �d���P���[�������R�[�h�f�B�N�V���i��
            Dictionary<int, int> stockUnPrcFrcProcCdDic = new Dictionary<int, int>();

            // �d������Œ[�������R�[�h�f�B�N�V���i��
            Dictionary<int, int> stockCnsTaxFrcProcCdDic = new Dictionary<int, int>();

            // ����P���[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesUnPrcFrcProcCd = Calculator.CustomerDB.RealAccesser.GetSalesFractionProcCd(
                enterpriseCode,
                CurrentCustomerCode,
                CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd
            );

            // �������Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = Calculator.CustomerDB.RealAccesser.GetSalesFractionProcCd(
                enterpriseCode,
                CurrentCustomerCode,
                CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            );

            // �d���P���[�������R�[�h
            int stockUnPrcFrcProcCd = 0;
            // �d������Œ[�������R�[�h
            int stockCnsTaxFrcProcCd = 0;

            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            List<GoodsUnitData> tempGoodsUnitDataList = new List<GoodsUnitData>();

            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                GoodsUnitData tempGoodsUnitData = goodsUnitData.Clone();
                tempGoodsUnitDataList.Add(tempGoodsUnitData);

                if ((!goodsUnitData.GoodsMakerCd.Equals(0)) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
                {
                    UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
                    {
                        unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                     // BL�R�[�h
                        unitPriceCalcParam.BLGoodsName = goodsUnitData.BLGoodsFullName;                 // BL�R�[�h����
                        unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                     // BL�O���[�v�R�[�h
                        unitPriceCalcParam.CountFl = 0;                                                 // ����
                        unitPriceCalcParam.CustomerCode = CurrentCustomerCode;                          // ���Ӑ�R�[�h
                        unitPriceCalcParam.CustRateGrpCode = GetCustomerRateGroupCode(goodsUnitData.GoodsMakerCd); // ���Ӑ�|���O���[�v�R�[�h
                        unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                   // ���[�J�[�R�[�h
                        unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                             // ���i�ԍ�
                        unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;           // ���i�|���O���[�v�R�[�h
                        unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                 // ���i�|�������N
                        unitPriceCalcParam.PriceApplyDate = DateTime.Today; �@�@�@�@�@                  // �K�p��
                        unitPriceCalcParam.SalesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;                 // �������Œ[�������R�[�h
                        unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd;                   // ����P���[�������R�[�h
                        unitPriceCalcParam.SectionCode = sectionCode;                                   // ���_�R�[�h
                        if (stockCnsTaxFrcProcCdDic.ContainsKey(goodsUnitData.SupplierCd))
                        {
                            stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCdDic[goodsUnitData.SupplierCd];   // �d������Œ[�������R�[�h(�f�B�N�V���i�����d����}�X�^����擾)
                        }
                        else
                        {
                            stockCnsTaxFrcProcCd = Calculator.SupplierDB.RealAccesser.GetStockFractionProcCd(
                                enterpriseCode,
                                goodsUnitData.SupplierCd,
                                SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd
                            );
                            stockCnsTaxFrcProcCdDic.Add(goodsUnitData.SupplierCd, stockCnsTaxFrcProcCd);
                        }
                        unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;

                        if (stockUnPrcFrcProcCdDic.ContainsKey(goodsUnitData.SupplierCd))
                        {
                            stockUnPrcFrcProcCd = stockUnPrcFrcProcCdDic[goodsUnitData.SupplierCd];     // �d���P���[�������R�[�h(�f�B�N�V���i�����d����}�X�^����擾)
                        }
                        else
                        {
                            stockUnPrcFrcProcCd = Calculator.SupplierDB.RealAccesser.GetStockFractionProcCd(
                                enterpriseCode,
                                goodsUnitData.SupplierCd,
                                SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd
                            );
                            stockUnPrcFrcProcCdDic.Add(goodsUnitData.SupplierCd, stockUnPrcFrcProcCd);
                        }
                        unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;                   // �d���P���[�������R�[�h
                        unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                       // �d����R�[�h
                        unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                 // �ېŋ敪
                        //unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;                       // HACK:�ŗ�
                        //unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd; // HACK:���z�\�����@�敪
                        //unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;	// HACK:���z�\���|���K�p�敪
                        //unitPriceCalcParam.ConsTaxLayMethod = this._salesSlip.ConsTaxLayMethod;         // HACK:����œ]�ŕ���
                        // -- ADD 2011/09/19   ------ >>>>>>
                        // DEL 2013/10/25 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή� -------------------------------->>>>> 
                        //// ���Ӑ���
                        //CustomerInfo customerInfo = Calculator.CustomerDB.CustomerInfoMap[this._currentCustomerCode];
                        //if (customerInfo != null)
                        //{
                        //    unitPriceCalcParam.ConsTaxLayMethod = customerInfo.ConsTaxLayMethod; // 072.����œ]�ŕ����c���Ӑ�}�X�^ or �ŗ��ݒ�}�X�^
                        //}
                        // DEL 2013/10/25 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή� --------------------------------<<<<< 

                        // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------>>>>>
                        //TaxRateSetAgent taxRateSet = new TaxRateSetAgent(enterpriseCode);
                        //{
                        //    unitPriceCalcParam.TaxRate = taxRateSet.TaxRateOfNow;    // 073.����Őŗ��c�ŗ��ݒ�}�X�^
                        //}
                        TaxRateSetAgent taxRateSet = new TaxRateSetAgent(enterpriseCode);
                        if (CurrentTaxRateSet != null)
                        {
                            unitPriceCalcParam.TaxRate = (CurrentTaxRateSet.CancelDiv == 1) ? CurrentTaxRateSet.TaxRateOfSlesDate : CurrentTaxRateSet.TaxRateOfNow; // 073.����Őŗ��c�ŗ��ݒ�}�X�^
                        }
                        else
                        {
                            unitPriceCalcParam.TaxRate = taxRateSet.TaxRateOfNow;    // 073.����Őŗ��c�ŗ��ݒ�}�X�^
                        }
                        // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------<<<<<

                        // DEL 2014/02/05 SCM�d�|�ꗗ��10627�Ή� ----------------------------------->>>>>
                        #region ���\�[�X
                        //// ADD 2013/10/25 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή� -------------------------------->>>>> 
                        //CustomerInfo claim;
                        //// ���Ӑ���擾
                        //CustomerInfo customerInfo = Calculator.CustomerDB.CustomerInfoMap[this._currentCustomerCode];
                        //if (customerInfo != null)
                        //{
                        //    // ��������擾
                        //    int status = Calculator.CustomerDB.RealAccesser.ReadDBData(Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0, customerInfo.EnterpriseCode, customerInfo.ClaimCode, true, false, out claim);
                        //    if (status != (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    {
                        //        claim = new CustomerInfo();
                        //    }

                        //    if (claim != null)
                        //    {
                        //        unitPriceCalcParam.ConsTaxLayMethod = (claim.CustCTaXLayRefCd == 0) ? taxRateSet.ConsTaxLayMethod : claim.ConsTaxLayMethod;
                        //    }
                        //}
                        //// ADD 2013/10/25 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή� --------------------------------<<<<< 
                        #endregion
                        // DEL 2014/02/05 SCM�d�|�ꗗ��10627�Ή� -----------------------------------<<<<<
                        // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� ----------------------------------->>>>>
                        CustomerInfo claim = Calculator.ClaimInfo(this._currentCustomerCode);
                        if (claim != null)
                        {
                            unitPriceCalcParam.ConsTaxLayMethod = claim.CustCTaXLayRefCd == 0 ? taxRateSet.ConsTaxLayMethod : claim.ConsTaxLayMethod;
                        }
                        else
                        {
                            // �����悪�擾�ł��Ȃ��ꍇ�́A�}�X�^�̐ŗ��ݒ���Z�b�g
                            unitPriceCalcParam.ConsTaxLayMethod = taxRateSet.ConsTaxLayMethod;
                        }
                        // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� -----------------------------------<<<<<

                        unitPriceCalcParam.TotalAmountDispWayCd = 0; // ���z�\�����@�敪
                        unitPriceCalcParam.TtlAmntDspRateDivCd = 0;	// ���z�\���|���K�p�敪
                        // -- ADD 2011/09/19   ------ <<<<<<
                    }
                    unitPriceCalcParamList.Add(unitPriceCalcParam);
                }
            }

            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            {
                // --- ADD 2013/08/07 T.Miyamoto ------------------------------>>>>>
                Calculator.RealAccesser.RatePriorityDiv = Calculator.GetCompanyInf(enterpriseCode).RatePriorityDiv; //���Аݒ襊|���D�揇��
                // --- ADD 2013/08/07 T.Miyamoto ------------------------------<<<<<

                // UPD 2014/02/05 ��10631 �g�� �|���}�X�^�L���b�V�� ------->>>>>>>>>>>>>>>>>>>
                #region ���\�[�X
                //Calculator.RealAccesser.CalculateSalesRelevanceUnitPrice(
                //    unitPriceCalcParamList,
                //    tempGoodsUnitDataList,
                //    out unitPriceCalcRetList
                //);
                #endregion
                Calculator.RealAccesser.CalculateSalesRelevanceUnitPriceRateCache(
                    unitPriceCalcParamList,
                    tempGoodsUnitDataList,
                    out unitPriceCalcRetList
                );
                // UPD 2014/02/05 ��10631 �g�� �|���}�X�^�L���b�V�� -------<<<<<<<<<<<<<<<<<<<
            }
            return unitPriceCalcRetList;
        }

        /// <summary>�������[�J�[�ő�R�[�h</summary>
        public const int PURE_GOODS_MAKER_CODE_MAX = 1000;

        /// <summary>
        /// ���Ӑ�|���O���[�v�R�[�h�擾����
        /// </summary>
        /// <remarks>MAHNB01012AB.cs l.9693 SalesSlipInputAcs.GetCustRateGroupCode() ���Q�l</remarks>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <returns>���Ӑ�|���O���[�v�R�[�h</returns>
        private int GetCustomerRateGroupCode(int goodsMakerCode)
        {
            int pureCode = (goodsMakerCode <= PURE_GOODS_MAKER_CODE_MAX ? 0 : 1);   // 0:���� 1:�D��

            // �P�ƃL�[
            CustRateGroup foundCustomerRateGroup = CurrentCustomerRateGroupList.Find(
                delegate(CustRateGroup customerRateGroup)
                {
                    return customerRateGroup.GoodsMakerCd.Equals(goodsMakerCode) && customerRateGroup.PureCode.Equals(pureCode);
                }
            );
            if (foundCustomerRateGroup != null) return foundCustomerRateGroup.CustRateGrpCode;

            // ���ʃL�[
            foundCustomerRateGroup = CurrentCustomerRateGroupList.Find(
                delegate(CustRateGroup customerRateGroup)
                {
                    return customerRateGroup.GoodsMakerCd.Equals(0) && customerRateGroup.PureCode.Equals(pureCode);
                }
            );
            if (foundCustomerRateGroup != null) return foundCustomerRateGroup.CustRateGrpCode;

            return 0;
        }

        #endregion // </�P���Z�o�����p>

        /// <summary>
        /// ���i�v�Z�����iPartsInfoDataSet.CalculatePrice += �f���Q�[�g�Ɏg�p�j
        /// </summary>
        /// <remarks>MAHNB01012AB.cs SalesSlipInputAcs.CalcPrice() 1816�s�ڂ��ڐA</remarks>
        /// <param name="taxationCode"></param>
        /// <param name="unitPrice"></param>
        /// <param name="priceTaxExc"></param>
        /// <param name="priceTaxInc"></param>
        public void CalcPrice(
            int taxationCode,
            double unitPrice,
            out double priceTaxExc,
            out double priceTaxInc
        )
        {
            // ����Œ[�������R�[�h
            int salesCnsTaxFrcProcCd = Calculator.CustomerDB.RealAccesser.GetSalesFractionProcCd(
                CurrentEnterpriseCode,
                CurrentCustomerCode,
                CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            );
            // DEL 2014/02/05 SCM�d�|�ꗗ��10627�Ή� ----------------------------------->>>>>
            #region ���\�[�X
            //// ADD 2013/10/25 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή� -------------------------------->>>>>
            //// ����œ]�ŕ����擾
            //CustomerInfo claim = new CustomerInfo();
            //// ��������擾
            //int status = Calculator.CustomerDB.RealAccesser.ReadDBData(Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0, CurrentCustomerInfo.EnterpriseCode, CurrentCustomerInfo.ClaimCode, true, false, out claim);
            //int ConsTaxLayMethod = (claim.CustCTaXLayRefCd == 0) ? CurrentTaxRateSet.ConsTaxLayMethod : claim.ConsTaxLayMethod;  
            //// ADD 2013/10/25 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή� --------------------------------<<<<<
            #endregion
            // DEL 2014/02/05 SCM�d�|�ꗗ��10627�Ή� -----------------------------------<<<<<

            // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� ----------------------------------->>>>>
            CustomerInfo claim = Calculator.ClaimInfo(CurrentCustomerCode);
            int ConsTaxLayMethod = 0;
            if (claim != null)
            {
                ConsTaxLayMethod = claim.CustCTaXLayRefCd == 0 ? CurrentTaxRateSet.ConsTaxLayMethod : claim.ConsTaxLayMethod;
            }
            else
            {
                // �����悪�擾�ł��Ȃ��ꍇ�́A�}�X�^�̐ŗ��ݒ���Z�b�g
                ConsTaxLayMethod = CurrentTaxRateSet.ConsTaxLayMethod;
            }
            // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� -----------------------------------<<<<<


            CalclatePrice(
                unitPrice,
                taxationCode,
                0,                                      // ���z�\�����@�敪 �c0:���z�\�����Ȃ�(�Ŕ���)
                // UPD 2013/10/25 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή� -------------------------------->>>>>
                //CurrentCustomerInfo.ConsTaxLayMethod,   // ����œ]�ŕ���   �c���Ӑ�}�X�^or�ŗ��ݒ�}�X�^���
                ConsTaxLayMethod,   // ����œ]�ŕ���   �c���Ӑ�}�X�^or�ŗ��ݒ�}�X�^���
                // UPD 2013/10/25 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή� --------------------------------<<<<<
                // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------>>>>>
                //CurrentTaxRateSet.TaxRateOfNow,
                (CurrentTaxRateSet.CancelDiv == 1) ? CurrentTaxRateSet.TaxRateOfSlesDate : CurrentTaxRateSet.TaxRateOfNow,
                // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------<<<<<
                salesCnsTaxFrcProcCd,
                out priceTaxExc,
                out priceTaxInc
            );
        }

        #region <���i�v�Z�����p>

        /// <summary>
        /// �Ώۉ��i����A�Ŕ����z�A�ō����z�A�\�����z���v�Z���܂�
        /// </summary>
        /// <remarks>MAHNB01012AB.cs SalesSlipInputAcs.CalclatePrice() 1834�s�ڂ��ڐA</remarks>
        /// <param name="targetPrice">�Ώۉ��i</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="totalAmountDispWayCd">���z�\���敪</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���</param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="salesCnsTaxFrcProcCd">�������Œ[�������R�[�h</param>
        /// <param name="priceTaxExc">�Ŕ����z</param>
        /// <param name="priceTaxInc">�ō����z</param>
        private void CalclatePrice(
            double targetPrice,
            int taxationCode,
            int totalAmountDispWayCd,
            int consTaxLayMethod,
            double taxRate,
            int salesCnsTaxFrcProcCd,
            out double priceTaxExc,
            out double priceTaxInc
        )
        {
            priceTaxExc = 0;
            priceTaxInc = 0;

            if (targetPrice == 0) return;

            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            GetSalesFractionProcInfo(
                (int)SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax,
                salesCnsTaxFrcProcCd,
                0,
                out taxFracProcUnit,
                out taxFracProcCd
            );

            // ���z�\�����Ȃ�
            if (totalAmountDispWayCd == 0)
            {
                // �ېŋ敪�u��ېŁv�A�]�ŕ����F��ې�
                if ((taxationCode == (int)CalculateTax.TaxationCode.TaxNone) || (consTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt))
                {
                    priceTaxExc = targetPrice;
                    priceTaxInc = targetPrice;
                }
                // �ېŋ敪���u�ېŁi���Łj�v�̏ꍇ
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                    priceTaxInc = targetPrice;
                }
                // �ېŋ敪���u�ېŁv�̏ꍇ
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    priceTaxExc = targetPrice;
                    priceTaxInc = targetPrice + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                }
            }
            // ���z�\������
            else
            {
                // �ېŋ敪�u��ېŁv�A�]�ŕ����F��ې�
                if ((taxationCode == (int)CalculateTax.TaxationCode.TaxNone) || (consTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt))
                {
                    priceTaxExc = targetPrice;
                    priceTaxInc = targetPrice;
                }
                // �ېŋ敪���u�ېŁi���Łj�v�̏ꍇ
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                    priceTaxInc = targetPrice;
                }
                // �ېŋ敪���u�ېŁv�̏ꍇ
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                    priceTaxInc = targetPrice;
                }
            }
        }

        ///// <summary>�[�������Ώۋ��z�敪�i������z�j</summary>
        //public const int ctFracProcMoneyDiv_SalesMoney = 0;
        ///// <summary>�[�������Ώۋ��z�敪�i����Łj</summary>
        //public const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>�[�������Ώۋ��z�敪�i����P���j</summary>
        public const int ctFracProcMoneyDiv_SalesUnitPrice = 2;
        ///// <summary>�[�������Ώۋ��z�敪�i�����P���j</summary>
        //public const int ctFracProcMoneyDiv_SalesUnitCost = 2;
        ///// <summary>�[�������Ώۋ��z�敪�i�������z�j</summary>
        //public const int ctFracProcMoneyDiv_Cost = 0;

        /// <summary>������z�����敪���X�g</summary>
        private List<SalesProcMoney> _salesProcMoneyList;
        /// <summary>������z�����敪���X�g���擾���܂��B</summary>
        private List<SalesProcMoney> SalesProcMoneyList
        {
            get
            {
                if (_salesProcMoneyList == null)
                {
                    _salesProcMoneyList = (List<SalesProcMoney>)SalesProcMoneyServer.Singleton.Instance.Find(
                        CurrentEnterpriseCode
                    );
                }
                return _salesProcMoneyList;
            }
        }

        /// <summary>
        /// �[�������P�ʁA�[�������敪�擾����
        /// </summary>
        /// <remarks>
        /// MAHNB01012AD.cs SalesSlipInputInitDataAcs.GetSalesFractionProcInfo() 1592�s�ڂ��ڐA
        /// </remarks>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        public void GetSalesFractionProcInfo(
            int fracProcMoneyDiv,
            int fractionProcCode,
            double targetPrice,
            out double fractionProcUnit,
            out int fractionProcCd
        )
        {
            //-----------------------------------------------------------------------------
            // �����l
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // �P����0.01�~�P��
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // �P���ȊO��1�~�P��
                    break;
            }
            fractionProcCd = 1;     // �؎̂�

            //-----------------------------------------------------------------------------
            // �R�[�h�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            List<SalesProcMoney> salesProcMoneyList = SalesProcMoneyList.FindAll(
                delegate(SalesProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            
            //-----------------------------------------------------------------------------
            // �\�[�g�i������z�i�����j�j
            //-----------------------------------------------------------------------------
            salesProcMoneyList.Sort(new SalesProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // ������z�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            SalesProcMoney salesProcMoney = salesProcMoneyList.Find(
                delegate(SalesProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // �߂�l�ݒ�
            //-----------------------------------------------------------------------------
            if (salesProcMoney != null)
            {
                fractionProcUnit = salesProcMoney.FractionProcUnit;
                fractionProcCd = salesProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// ������z�����敪�}�X�^��r�N���X(������z(����))
        /// </summary>
        /// <remarks>
        /// MAHNB01012AD.cs SalesSlipInputInitDataAcs 1661�s�ڂ��ڐA
        /// </remarks>
        private class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {
            public override int Compare(SalesProcMoney x, SalesProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        #endregion // </���i�v�Z�����p>

        // --- UPD m.suzuki 2011/06/28 ---------->>>>>
        ///// <summary>
        ///// �L�����y�[���K�p�����iPartsInfoDataSet.ReflectCampaign += �f���Q�[�g�Ɏg�p�j
        ///// </summary>
        ///// <remarks>MAHNB01012AC.cs SalesSlipInputAcs.ReflectAutoDiscount() 14987�s�ڂ��ڐA</remarks>
        ///// <param name="taxationCode"></param>
        ///// <param name="customerCode"></param>
        ///// <param name="goodsMGroup"></param>
        ///// <param name="blGoodsCode"></param>
        ///// <param name="goodsMakerCd"></param>
        ///// <param name="goodsNo"></param>
        ///// <param name="applyDate"></param>
        ///// <param name="price"></param>
        //public void ReflectCampaign(
        //    int taxationCode,
        //    int customerCode,
        //    int goodsMGroup,
        //    int blGoodsCode,
        //    int goodsMakerCd,
        //    string goodsNo,
        //    DateTime applyDate,
        //    ref double price
        //)
        /// <summary>
        /// �L�����y�[���K�p�����iPartsInfoDataSet.ReflectCampaign += �f���Q�[�g�Ɏg�p�j
        /// </summary>
        /// <remarks>MAHNB01012AC.cs SalesSlipInputAcs.ReflectAutoDiscount()�ɑΉ�</remarks>
        /// <param name="taxationCode"></param>
        /// <param name="customerCode"></param>
        /// <param name="blGoodsCode"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        /// <param name="blGroupCode"></param>
        /// <param name="salesCode"></param>
        /// <param name="applyDate"></param>
        /// <param name="price"></param>
        public void ReflectCampaign(
            int taxationCode,
            int customerCode,
            int blGoodsCode,
            int goodsMakerCd,
            string goodsNo,
            int blGroupCode,
            int salesCode,
            DateTime applyDate,
            ref double price
        )
        // --- UPD m.suzuki 2011/06/28 ----------<<<<<
        {
            const string METHOD_NAME = "ReflectCampaign()"; // ���O�p

            // --- UPD m.suzuki 2011/06/28 ---------->>>>>
            //CampaignMngAcs campaignMngAcs = new CampaignMngAcs( CurrentEnterpriseCode, LoginSectionCode );
            //CampaignMng campaignMng;
            //campaignMngAcs.GetRatePriceOfCampaignMng(
            //    out campaignMng,
            //    CurrentEnterpriseCode,
            //    LoginSectionCode,
            //    customerCode,
            //    goodsMakerCd,
            //    goodsMGroup,
            //    blGoodsCode,
            //    goodsNo,
            //    applyDate
            //);

            // DEL 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // CampaignObjGoodsStAcs campaignObjGoodsStAcs = new CampaignObjGoodsStAcs();
            // DEL 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            //CampaignObjGoodsSt campaignMng;   // DEL 2011/07/15

            // UPD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j ---------------------------------->>>>>
            //int status = campaignObjGoodsStAcs.GetRatePriceOfCampaignMng(
            //    out campaignMng,
            //    CurrentEnterpriseCode,
            //    LoginSectionCode,
            //    customerCode,
            //    goodsMakerCd,
            //    blGroupCode,
            //    blGoodsCode,
            //    salesCode,
            //    goodsNo,
            //    applyDate 
            //);
            int status = CampaignObjGoodsStAcs.GetRatePriceOfCampaignMng(
                out campaignMng,
                CurrentEnterpriseCode,
                LoginSectionCode,
                customerCode,
                goodsMakerCd,
                blGroupCode,
                blGoodsCode,
                salesCode,
                goodsNo,
                applyDate
            );
            // UPD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j ----------------------------------<<<<<
            // --- UPD m.suzuki 2011/06/28 ----------<<<<<

            if (campaignMng == null)
            {
                #region <Log>
                // --- UPD m.suzuki 2011/06/28 ---------->>>>>
                //SCMDataHelper.DumpToLog(campaignMngAcs.CachedCampaignMngDic);   // �����p�Ƀ_���v
                //
                //string msg = string.Format(
                //    "�L�����y�[���K�p�����F�L�����y�[���Ǘ���null�ł��B�i��ƁF{0}, ���_�F{1}, ���Ӑ�F{2}, ���[�J�[�F{3}, �����ށF{4}, BL�F{5}, �i�ԁF{6}, �K�p���F{7}�j",
                //    CurrentEnterpriseCode,
                //    LoginSectionCode,
                //    customerCode,
                //    goodsMakerCd,
                //    goodsMGroup,
                //    blGoodsCode,
                //    goodsNo,
                //    applyDate
                //);
                //msg += Environment.NewLine + "\t�L�����y�[���Ǘ��̎擾�󋵁F" + campaignMngAcs.StatusOfResult;
                //EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                string msg = string.Format(
                    "�L�����y�[���K�p�����F�L�����y�[���Ǘ���null�ł��B�i��ƁF{0}, ���_�F{1}, ���Ӑ�F{2}, ���[�J�[�F{3}, �O���[�v : {4}, BL�F{5}, �̔��敪 : {6}, �i�ԁF{7}, �K�p���F{8}�j",
                    CurrentEnterpriseCode,
                    LoginSectionCode,
                    customerCode,
                    goodsMakerCd,
                    blGroupCode,
                    blGoodsCode,
                    salesCode,
                    goodsNo,
                    applyDate
                );
                msg += Environment.NewLine + "\t�L�����y�[���Ǘ��̎擾�󋵁F" + status;
                EasyLogger.WriteDebugLog( MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg( msg ) );
                
                // --- UPD m.suzuki 2011/06/28 ----------<<<<<

                #endregion // </Log>

                return;
            }
            else
            {
                #region <Log>

                // --- UPD m.suzuki 2011/06/28 ---------->>>>>
                //string msg = string.Format(
                //    "�L�����y�[���K�p�����F���Z�O���i={0}, �|��={1}, ���i={2}�i��ƁF{3}, ���_�F{4}, ���Ӑ�F{5}, ���[�J�[�F{6}, �����ށF{7}, BL�F{8}, �i�ԁF{9}, �K�p���F{10}�j�c{11}",
                //    price,
                //    campaignMng.RateVal,
                //    campaignMng.PriceFl,
                //    CurrentEnterpriseCode,
                //    LoginSectionCode,
                //    customerCode,
                //    goodsMakerCd,
                //    goodsMGroup,
                //    blGoodsCode,
                //    goodsNo,
                //    applyDate,
                //    campaignMngAcs.StatusOfResult
                //);
                string msg = string.Format(
                    "�L�����y�[���K�p�����F���Z�O���i={0}, �l����={1}, �|��={2}, ���i={3}�i��ƁF{4}, ���_�F{5}, ���Ӑ�F{6}, ���[�J�[�F{7}, �O���[�v�F{8}, BL�F{9}, �̔��敪 : {10}, �i�ԁF{11}, �K�p���F{12}�j�c{13}",
                    price,
                    campaignMng.DiscountRate,
                    campaignMng.RateVal,
                    campaignMng.PriceFl,
                    CurrentEnterpriseCode,
                    LoginSectionCode,
                    customerCode,
                    goodsMakerCd,
                    blGroupCode,
                    blGoodsCode,
                    salesCode,
                    goodsNo,
                    applyDate,
                    status
                );
                // --- UPD m.suzuki 2011/06/28 ----------<<<<<
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>
            }

            // DEL 2011/07/15 --- >>>>
            // ���i�Ɗ|���͓�ґ���
            // �L�����y�[�����i�K�p
            //if (campaignMng.PriceFl != 0)
            //{
            //    price = campaignMng.PriceFl;
            //}
            //// �L�����y�[���|���K�p
            //else if (campaignMng.RateVal != 0)
            //{
            //    CalclatePriceByRate(taxationCode, campaignMng.RateVal, ref price);
            //}
            //// --- ADD m.suzuki 2011/06/28 ---------->>>>>
            //// �L�����y�[���l�����K�p
            //else if ( campaignMng.DiscountRate != 0 )
            //{
            //    CalclatePriceByRate( taxationCode, GetPriceRateFromDiscountRate( campaignMng.DiscountRate ), ref price );
            //}
            // --- ADD m.suzuki 2011/06/28 ----------<<<<<
            // DEL 2011/07/15 --- <<<<

            #region <Log>

            string after = string.Format(
                "�L�����y�[���K�p�����F���Z�㉿�i={0}",
                price
            );
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(after));

            #endregion // </Log>
        }
        // --- ADD m.suzuki 2011/06/28 ---------->>>>>
        /// <summary>
        /// �l��������̔������Z�o
        /// </summary>
        /// <param name="discountRate"></param>
        /// <returns></returns>
        private double GetPriceRateFromDiscountRate( double discountRate )
        {
            // ������ = 100% - �l����
            return (double)(100.0m - (decimal)discountRate);
        }
        // --- ADD m.suzuki 2011/06/28 ----------<<<<<

        /// <summary>
        /// �����A�g�l�����K�p�����iPartsInfoDataSet.ReflectAutoDiscount += �f���Q�[�g�Ɏg�p�j
        /// </summary>
        /// <remarks>MAHNB01012AC.cs SalesSlipInputAcs.ReflectAutoDiscount() 15017�s�ڂ��ڐA</remarks>
        /// <param name="taxationCode"></param>
        /// <param name="customerCode"></param>
        /// <param name="goodsMGroup"></param>
        /// <param name="blGoodsCode"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        /// <param name="price"></param>
        public void ReflectAutoDiscount(
            int taxationCode,
            int customerCode,
            int goodsMGroup,
            int blGoodsCode,
            int goodsMakerCd,
            string goodsNo,
            ref double price
        )
        {
            const string METHOD_NAME = "ReflectAutoDiscount()"; // ���O�p

            this._isDiscountApply = false; // ADD �����M 2013/04/17 for Redmine#35271

            SCMTtlSt scmTtlSt = CurrentSCMTotalSetting;
            if (scmTtlSt == null)
            {
                #region <Log>

                string msg = "�����A�g�l�����K�p�����FSCM�S�̐ݒ肪null�ł��B";
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                return;
            }
            else
            {
                #region <Log>

                string msg = string.Format(
                    "�����A�g�l�����K�p�����F���Z�O���i={0}, �����A�g�l������={1}, �l�����K�p�敪={2}:{3}",
                    price,
                    scmTtlSt.AutoCooperatDis,
                    scmTtlSt.DiscountApplyCd,
                    SCMDataHelper.GetDiscountApplyName(scmTtlSt)
                );
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>
            }

            double autoCooperatDis = 100.0 - scmTtlSt.AutoCooperatDis;
            switch (scmTtlSt.DiscountApplyCd)
            {
                case 0: // ���Ȃ�
                    break;
                case 1: // �S��
                    {
                        CalclatePriceByRate(taxationCode, autoCooperatDis, ref price);
                        this._isDiscountApply = true; // ADD �����M 2013/04/17 for Redmine#35271
                        break;
                    }
                case 2: // �O���i�ȊO
                    {
                        // �O���i�`�F�b�N
                        if (!SCMOutEquipment.CheckOutEquipment(blGoodsCode))
                        {
                            CalclatePriceByRate(taxationCode, autoCooperatDis, ref price);
                            this._isDiscountApply = true; // ADD �����M 2013/04/17 for Redmine#35271
                        }
                        break;
                    }
                case 3: // �d�_�i��
                    {
                        // �d�_�i�ڃ`�F�b�N
                        if (IsValidImportantPrtSt(LoginSectionCode, customerCode, goodsMakerCd, goodsMGroup, blGoodsCode, goodsNo))
                        {
                            #region <Log>

                            string msg = string.Format(
                                "\t\t�d�_�i�ڂł��B(���_�F{0}, ���Ӑ�F{1}, ���[�J�[�F{2}, �����ށF{3}, BL�F{4}, �i�ԁF{5})",
                                LoginSectionCode,
                                customerCode,
                                goodsMakerCd,
                                goodsMGroup,
                                blGoodsCode,
                                goodsNo
                            );
                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                            #endregion // </Log>

                            CalclatePriceByRate(taxationCode, autoCooperatDis, ref price);
                            this._isDiscountApply = true; // ADD �����M 2013/04/17 for Redmine#35271
                        }
                        else
                        {
                            #region <Log>

                            string msg = string.Format(
                                "\t\t�d�_�i�ڂł͂���܂���(�܂��͗L���敪���u���Ȃ��v�ł�)�B(���_�F{0}, ���Ӑ�F{1}, ���[�J�[�F{2}, �����ށF{3}, BL�F{4}, �i�ԁF{5})",
                                LoginSectionCode,
                                customerCode,
                                goodsMakerCd,
                                goodsMGroup,
                                blGoodsCode,
                                goodsNo
                            );
                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                            #endregion // </Log>
                        }
                        break;
                    }
                default:
                    break;
            }

            #region <Log>

            string after = string.Format(
                "�����A�g�l�����K�p�����F���Z�㉿�i={0} ���ďo�����\�b�h�FCalclatePriceByRate()",
                price
            );
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(after));

            #endregion // </Log>
        }

        #region <�L�����y�[���K�p�����^�����A�g�l�����K�p�����p>

        /// <summary>
        /// �|�������z�擾
        /// </summary>
        /// <remarks>
        /// MAHNB01012AC.cs SalesSlipInputAcs.CalclatePriceByRate() 15051�s�ڂ��ڐA
        /// </remarks>
        /// <param name="taxationDivCd"></param>
        /// <param name="autoCooperatDis"></param>
        /// <param name="price"></param>
        private void CalclatePriceByRate(int taxationDivCd, double autoCooperatDis, ref double price)
        {
            double unitPriceTaxExc = 0;
            double unitPriceTaxInc = 0;

            // ����Œ[������
            int salesCnsTaxFrcProcCd = Calculator.CustomerDB.RealAccesser.GetSalesFractionProcCd(
                CurrentEnterpriseCode,
                CurrentCustomerCode,
                CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            );

            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            GetSalesFractionProcInfo(
                SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax,
                salesCnsTaxFrcProcCd,
                0,
                out taxFracProcUnit,
                out taxFracProcCd
            );

            // ����P���[������
            int frcProcCd = Calculator.CustomerDB.RealAccesser.GetSalesFractionProcCd(
                CurrentEnterpriseCode,
                CurrentCustomerCode,
                CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd
            );
            double fracProcUnit = 0;
            int fracProcDiv = 0;
            GetSalesFractionProcInfo(
                SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_SalesUnitPrice,
                salesCnsTaxFrcProcCd,
                0,
                out fracProcUnit,
                out fracProcDiv
            );

            Calculator.RealAccesser.CalculateUnitPriceByRate(
                UnitPriceCalculation.UnitPriceKind.SalesUnitPrice,
                UnitPriceCalculation.UnitPrcCalcDiv.RateVal,
                0,  // ���z�\�����@�敪�c0:���z�\�����Ȃ�(�Ŕ���)
                0,
                frcProcCd,
                taxationDivCd,
                price,
                // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------>>>>>
                //CurrentTaxRateSet.TaxRateOfNow,
                (CurrentTaxRateSet.CancelDiv == 1) ? CurrentTaxRateSet.TaxRateOfSlesDate : CurrentTaxRateSet.TaxRateOfNow,
                // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------<<<<<
                taxFracProcUnit,
                taxFracProcCd,
                autoCooperatDis,
                ref fracProcUnit,
                ref fracProcDiv,
                out unitPriceTaxExc,
                out unitPriceTaxInc
            );

            if (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
            {
                price = unitPriceTaxInc;
            }
            else
            {
                price = unitPriceTaxExc;
            }
        }

        /// <summary>
        /// �d�_�i�ڏ��擾����
        /// </summary>
        /// <remarks>
        /// MAHNB01012AC.cs SalesSlipInputAcs.GetImportantPrtSt() 15106�s�ڂ��ڐA
        /// </remarks>
        /// <param name="sectionCode"></param>
        /// <param name="customerCode"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsMGroup"></param>
        /// <param name="blGoodsCode"></param>
        /// <param name="goodsNo"></param>
        /// <returns></returns>
        private bool IsValidImportantPrtSt(
            string sectionCode,
            int customerCode,
            int goodsMakerCd,
            int goodsMGroup,
            int blGoodsCode,
            string goodsNo
        )
        {
            ImportantPrtSt importantPrtSt;
            ImportantPrtStAcs importantPrtStAcs = new ImportantPrtStAcs(CurrentEnterpriseCode, sectionCode);
            int st = importantPrtStAcs.GetImportantPrtSt(
                out importantPrtSt,
                CurrentEnterpriseCode,
                LoginSectionCode,
                customerCode,
                goodsMakerCd,
                goodsMGroup,
                blGoodsCode,
                goodsNo
            );

            if (importantPrtSt != null)
            {
                return importantPrtSt.ValidDivCd.Equals(0); // 0:�L��/1:����
            }
            else
            {
                SCMDataHelper.DumpToLog(importantPrtStAcs.CachedImportantPrtStDic); // �����p�Ƀ_���v
            }
            return false;
        }

        #endregion // </�L�����y�[���K�p�����^�����A�g�l�����K�p�����p>

        // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
        #region ���[�J�[��]�������i�p �艿�Z�o
        /// <summary>
        /// �|�������z�擾�i���[�J�[��]�������i�p �艿�Z�o�p�j
        /// </summary>
        /// <remarks>
        /// MAHNB01012AC.cs SalesSlipInputAcs.CalclatePriceByRate() 15051�s�ڂ��ڐA
        /// </remarks>
        /// <param name="taxationDivCd"></param>
        /// <param name="autoCooperatDis"></param>
        /// <param name="price"></param>
        public void CalclatePriceByRateForListPrice(int taxationDivCd, double autoCooperatDis, ref double price)
        {
            // UPD 2015/04/01 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
            #region �폜
            //double unitPriceTaxExc = 0;
            //double unitPriceTaxInc = 0;

            //// ����Œ[������
            //int salesCnsTaxFrcProcCd = Calculator.CustomerDB.RealAccesser.GetSalesFractionProcCd(
            //    CurrentEnterpriseCode,
            //    CurrentCustomerCode,
            //    CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            //);

            //int taxFracProcCd = 0;
            //double taxFracProcUnit = 0;
            //GetSalesFractionProcInfo(
            //    SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax,
            //    salesCnsTaxFrcProcCd,
            //    0,
            //    out taxFracProcUnit,
            //    out taxFracProcCd
            //);

            //// ����P���[������
            //int frcProcCd = Calculator.CustomerDB.RealAccesser.GetSalesFractionProcCd(
            //    CurrentEnterpriseCode,
            //    CurrentCustomerCode,
            //    CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd
            //);
            //double fracProcUnit = 0;
            //int fracProcDiv = 0;
            //GetSalesFractionProcInfo(
            //    SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_SalesUnitPrice,
            //    salesCnsTaxFrcProcCd,
            //    0,
            //    out fracProcUnit,
            //    out fracProcDiv
            //);

            //Calculator.RealAccesser.CalculateUnitPriceByRate(
            //    UnitPriceCalculation.UnitPriceKind.SalesUnitPrice,
            //    UnitPriceCalculation.UnitPrcCalcDiv.RateVal,
            //    0,  // ���z�\�����@�敪�c0:���z�\�����Ȃ�(�Ŕ���)
            //    0,
            //    frcProcCd,
            //    taxationDivCd,
            //    price,
            //    // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------>>>>>
            //    //CurrentTaxRateSet.TaxRateOfNow,
            //    (CurrentTaxRateSet.CancelDiv == 1) ? CurrentTaxRateSet.TaxRateOfSlesDate : CurrentTaxRateSet.TaxRateOfNow,
            //    // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------<<<<<
            //    taxFracProcUnit,
            //    taxFracProcCd,
            //    autoCooperatDis,
            //    ref fracProcUnit,
            //    ref fracProcDiv,
            //    out unitPriceTaxExc,
            //    out unitPriceTaxInc
            //);

            //if (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
            //{
            //    price = unitPriceTaxInc;
            //}
            //else
            //{
            //    price = unitPriceTaxExc;
            //}
            #endregion 

            this.CalclatePriceByRate(taxationDivCd, autoCooperatDis, ref price);

            // UPD 2015/04/01 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
        }
        #endregion
        // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<

        /// <summary>
        /// �Ώۋ��z���A�Ŕ����A�ō��݉��i���v�Z���܂��B(���㖾�׃f�[�^�̔���P�����Čv�Z���Ɏg�p)
        /// </summary>
        /// <remarks>
        /// MAHNB01012AB.cs SalesSlipInputAcs.SalesDetailRowGoodsPriceSetting() 7493�s�ڂ��ڐA
        /// </remarks>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        /// <param name="salesSlip">����f�[�^</param>
        /// <returns>�Ŕ����A�ō��݉��i</returns>
        /// <br>UpdateNote : 2011/07/15 杍^ Redmine#22829 �����񓚁A�蓮�񓚂̗����Ŕ������̎Z�o���@���s���̑Ή�</br>
        /// <br>UpdateNote : 2011/07/20 杍^ Redmine#22829�u�|���}�X�^/�������v�Ɓu�L�����y�[��/�������v�������q�b�g����ꍇ�A���ו������F�ɂȂ�܂��̑Ή�</br>
        /// <br>UpdateNote : 2011/09/22 杍^ Redmine#25500 PCCUOE�^PM���@������ �L�����y�[���l�������ݒ肳��Ă���ꍇ�̔��P���s���̑Ή�</br>
        public PriceValue CalcTaxExcAndTaxInc(
            SalesDetail salesDetail,
            SalesSlip salesSlip
        )
        {
            // 2012/10/10 UPD TAKAGAWA SCM��Q����No10368 ----------------->>>>>>>>>>>>>>>>
            ////double price = salesDetail.SalesUnPrcTaxExcFl;   // DEL 2011/09/22
            //double price = salesDetail.BfSalesUnitPrice;      // ADD 2011/09/22
            double price = salesDetail.SalesUnPrcTaxExcFl;
            // 2012/10/10 UPD TAKAGAWA SCM��Q����No10368 -----------------<<<<<<<<<<<<<<<<
            double stdprice = salesDetail.ListPriceTaxExcFl;   // ADD 2011/07/15
            double priceTaxExc = 0.0;
            double priceTaxInc = 0.0;

            //-----------------------------------------------------------------------------
            // �����A�g�l�������i���f
            //-----------------------------------------------------------------------------
            // --- ADD 2012/10/01 �O�� 2013/04/10�z�M�� SCM��Q��27 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (salesDetail.AutoAnswerDivSCM == 2)
            {
                //>>>2013/04/14
                List<SalesProcMoney> salesProcMoneyList = (List<SalesProcMoney>)SalesProcMoneyServer.Singleton.Instance.Find(salesSlip.EnterpriseCode);
                Calculator.RealAccesser.CacheSalesProcMoneyList(salesProcMoneyList);
                //<<<2013/04/14

                //�����A�g�l���͎����񓚎��̂ݓK�p
                // --- ADD 2012/10/01 �O�� 2013/04/10�z�M�� SCM��Q��27 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                ReflectAutoDiscount(
                    salesDetail.TaxationDivCd,
                    CurrentCustomerCode,
                    salesDetail.GoodsMGroup,
                    salesDetail.BLGoodsCode,
                    salesDetail.GoodsMakerCd,
                    salesDetail.GoodsNo,
                    ref price
                );
                // --- ADD 2012/10/01 �O�� 2013/04/10�z�M�� SCM��Q��27 --------->>>>>>>>>>>>>>>>>>>>>>>>
            }
            // --- ADD 2012/10/01 �O�� 2013/04/10�z�M�� SCM��Q��27 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            //-----------------------------------------------------------------------------
            // �L�����y�[�����i���f
            //-----------------------------------------------------------------------------
            // --- UPD m.suzuki 2011/06/28 ---------->>>>>
            //ReflectCampaign(
            //    salesDetail.TaxationDivCd,
            //    CurrentCustomerCode,
            //    salesDetail.GoodsMGroup,
            //    salesDetail.BLGoodsCode,
            //    salesDetail.GoodsMakerCd,
            //    salesDetail.GoodsNo,
            //    salesSlip.SalesDate,
            //    ref price
            //);
            // --- UPD 2011/07/15 ---------->>>>>
            ReflectCampaign(
                salesDetail.TaxationDivCd,
                CurrentCustomerCode,
                salesDetail.BLGoodsCode,
                salesDetail.GoodsMakerCd,
                salesDetail.GoodsNo,
                salesDetail.BLGroupCode,
                salesDetail.SalesCode,
                salesSlip.SalesDate,
                ref price
            );

            if (campaignMng != null)
            {
                List<SalesProcMoney> salesProcMoneyList = (List<SalesProcMoney>)SalesProcMoneyServer.Singleton.Instance.Find(salesSlip.EnterpriseCode);

                Calculator.RealAccesser.CacheSalesProcMoneyList(salesProcMoneyList);

                salesDetail.CampaignCode = campaignMng.CampaignCode;  // ADD 2011/07/20

                // ���i�Ɗ|���͓�ґ���
                // �L�����y�[�����i�K�p
                if (campaignMng.PriceFl != 0)
                {
                    price = campaignMng.PriceFl;
                    this._isDiscountApply = false; // ADD �����M 2013/04/17 for Redmine#35271
                }
                // �L�����y�[���|���K�p
                else if (campaignMng.RateVal != 0)
                {
                    CalclatePriceByRate(salesDetail.TaxationDivCd, campaignMng.RateVal, ref stdprice);
                    price = stdprice;
                    salesDetail.SalesRate = campaignMng.RateVal;
                    this._isDiscountApply = false; // ADD �����M 2013/04/17 for Redmine#35271
                }
                // �L�����y�[���l�����K�p
                else if (campaignMng.DiscountRate != 0)
                {
                    CalclatePriceByRate(salesDetail.TaxationDivCd, GetPriceRateFromDiscountRate(campaignMng.DiscountRate), ref price);
                    this._isDiscountApply = false; // ADD �����M 2013/04/17 for Redmine#35271
                }
            }
            // --- UPD 2011/07/15 ----------<<<<<
            // --- UPD m.suzuki 2011/06/28 ----------<<<<<
            //-----------------------------------------------------------------------------
            // ���i�ăZ�b�g
            //-----------------------------------------------------------------------------
            CalcTaxExcAndTaxInc(
                salesDetail.TaxationDivCd,
                CurrentCustomerCode,
                // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------>>>>>
                //CurrentTaxRateSet.TaxRateOfNow,
                (CurrentTaxRateSet.CancelDiv == 1) ? CurrentTaxRateSet.TaxRateOfSlesDate : CurrentTaxRateSet.TaxRateOfNow,
                // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------<<<<<
                salesSlip.TotalAmountDispWayCd,
                price,
                out priceTaxExc,
                out priceTaxInc
            );
            return new PriceValue(priceTaxInc, priceTaxExc);
        }
        /// <summary>
        /// �Ώۋ��z���A�Ŕ����A�ō��݉��i���v�Z���܂��B(���㖾�׃f�[�^�̔���P�����Čv�Z���Ɏg�p)
        /// </summary>
        /// <remarks>MAHNB01012AB.cs SalesSlipInputAcs.CalcTaxExcAndTaxInc() 10172�s�ڂ��ڐA</remarks>
        /// <param name="taxationCode">�ېŋ敪
        /// ���Ӑ�R�[�h ��<c>-1</c>���w�肷��ƃf�t�H���g�l���g�p���܂��B
        /// </param>
        /// <param name="totalAmountDispWayCd">���z�\���敪</param>
        /// <param name="displayPrice">�Ώۋ��z</param>

        public PriceValue CalcTaxExcAndTaxInc(
            int taxationCode,
            int totalAmountDispWayCd,
            double displayPrice)
        {

            double priceTaxExc = 0;
            double priceTaxInc = 0;
            //-----------------------------------------------------------------------------
            // ���i�ăZ�b�g
            //-----------------------------------------------------------------------------
                        // ���ŕi
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                CalcTaxInc(
                    taxationCode,
                    CurrentCustomerCode,
                    // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------>>>>>
                    //CurrentTaxRateSet.TaxRateOfNow,
                    (CurrentTaxRateSet.CancelDiv == 1) ? CurrentTaxRateSet.TaxRateOfSlesDate : CurrentTaxRateSet.TaxRateOfNow,
                    // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------<<<<<
                    totalAmountDispWayCd,
                    displayPrice,
                    out priceTaxExc,
                    out priceTaxInc
                );
            }
            else
            {
                CalcTaxExcAndTaxInc(
                    taxationCode,
                    CurrentCustomerCode,
                    // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------>>>>>
                    //CurrentTaxRateSet.TaxRateOfNow,
                    (CurrentTaxRateSet.CancelDiv == 1) ? CurrentTaxRateSet.TaxRateOfSlesDate : CurrentTaxRateSet.TaxRateOfNow,
                    // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------<<<<<
                    totalAmountDispWayCd,
                    displayPrice,
                    out priceTaxExc,
                    out priceTaxInc
                );
            }
            return new PriceValue(priceTaxInc, priceTaxExc);
        }
        /// <summary>
        /// ���ł̏ꍇ�A�ō��݋��z���v�Z���܂��B(���㖾�׃f�[�^�̔���P�����Čv�Z���Ɏg�p)
        /// </summary>
        /// <remarks>MAHNB01012AB.cs SalesSlipInputAcs.CalcTaxExcAndTaxInc() 10172�s�ڂ��ڐA</remarks>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="customerCode">
        /// ���Ӑ�R�[�h ��<c>-1</c>���w�肷��ƃf�t�H���g�l���g�p���܂��B
        /// </param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="totalAmountDispWayCd">���z�\���敪</param>
        /// <param name="displayPrice">�Ώۋ��z</param>
        /// <param name="priceTaxExc">�Ŕ������z</param>
        /// <param name="priceTaxInc">�ō��݋��z</param>
        private void CalcTaxInc(
            int taxationCode,
            int customerCode,
            double taxRate,
            int totalAmountDispWayCd,
            double displayPrice,
            out double priceTaxExc,
            out double priceTaxInc
        )
        {
            priceTaxExc = 0;
            priceTaxInc = 0;

            if (customerCode < 0) customerCode = CurrentCustomerCode;

            // ���Ӑ�}�X�^�������Œ[�����������擾
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            int salesTaxFrcProcCd = customerInfoAcs.GetSalesFractionProcCd(
                CurrentEnterpriseCode,
                customerCode,
                CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            );  // �������Œ[�������R�[�h

            double fracProcUnit;
            int fracProcCd;
            GetStockFractionProcInfo(
                SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax,
                salesTaxFrcProcCd,
                0,
                out fracProcUnit,
                out fracProcCd
            );

                priceTaxExc = displayPrice;
                priceTaxInc = displayPrice + CalculateTax.GetTaxFromPriceExc(taxRate, fracProcUnit, fracProcCd, priceTaxExc);
        }

        /// <summary>
        /// �Ώۋ��z���A�Ŕ����A�ō��݉��i���v�Z���܂��B(���㖾�׃f�[�^�̔���P�����Čv�Z���Ɏg�p)
        /// </summary>
        /// <remarks>MAHNB01012AB.cs SalesSlipInputAcs.CalcTaxExcAndTaxInc() 10172�s�ڂ��ڐA</remarks>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="customerCode">
        /// ���Ӑ�R�[�h ��<c>-1</c>���w�肷��ƃf�t�H���g�l���g�p���܂��B
        /// </param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="totalAmountDispWayCd">���z�\���敪</param>
        /// <param name="displayPrice">�Ώۋ��z</param>
        /// <param name="priceTaxExc">�Ŕ������z</param>
        /// <param name="priceTaxInc">�ō��݋��z</param>
        private void CalcTaxExcAndTaxInc(
            int taxationCode,
            int customerCode,
            double taxRate,
            int totalAmountDispWayCd,
            double displayPrice,
            out double priceTaxExc,
            out double priceTaxInc
        )
        {
            priceTaxExc = 0;
            priceTaxInc = 0;

            if (customerCode < 0) customerCode = CurrentCustomerCode;

            // ���Ӑ�}�X�^�������Œ[���������   ���擾
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            int salesTaxFrcProcCd = customerInfoAcs.GetSalesFractionProcCd(
                CurrentEnterpriseCode,
                customerCode,
                CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            );  // �������Œ[�������R�[�h

            double fracProcUnit;
            int fracProcCd;
            GetStockFractionProcInfo(
                SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax,
                salesTaxFrcProcCd,
                0,
                out fracProcUnit,
                out fracProcCd
            );

            // ���ŕi
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                priceTaxInc = displayPrice;
                priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
            }
            // �O�ŕi
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                // ���z�\�����Ă���ꍇ�͐ō��݉��i
                if (totalAmountDispWayCd == 1)
                {
                    priceTaxInc = displayPrice;
                    priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
                }
                else
                {
                    priceTaxExc = displayPrice;
                    priceTaxInc = displayPrice + CalculateTax.GetTaxFromPriceExc(taxRate, fracProcUnit, fracProcCd, priceTaxExc);
                }
            }
            // ��ېŕi
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            {
                priceTaxExc = displayPrice;
                priceTaxInc = displayPrice;
            }
            else
            {
                priceTaxExc = 0;
                priceTaxInc = 0;
            }
        }

        #region <�Ώۋ��z���A�Ŕ����A�ō��݉��i���v�Z�p>

        #region <�d�����z�����敪�ݒ�}�X�^>

        /// <summary>�d�����z�����敪�ݒ�}�X�^</summary>
        private List<StockProcMoney> _stockProcMoneyList;
        /// <summary>�d�����z�����敪�ݒ�}�X�^���擾���܂��B</summary>
        private List<StockProcMoney> StockProcMoneyList
        {
            get
            {
                if (_stockProcMoneyList == null)
                {
                    StockProcMoneyAcs stockProcMoneyAcs = new StockProcMoneyAcs();
                    {
                        ArrayList aList = null;
                        int status = stockProcMoneyAcs.Search(out aList, CurrentEnterpriseCode);
                        if (aList != null)
                        {
                            _stockProcMoneyList = new List<StockProcMoney>(
                                (StockProcMoney[])aList.ToArray(typeof(StockProcMoney))
                            );
                        }
                        else
                        {
                            _stockProcMoneyList = new List<StockProcMoney>();
                        }
                    }
                }
                return _stockProcMoneyList;
            }
        }

        #endregion // </�d�����z�����敪�ݒ�}�X�^>

        /// <summary>
        /// �[�������P�ʁA�[�������敪�擾����
        /// </summary>
        /// <remarks>MAHNB01012AD.cs SalesSlipInputInitDataAcs.GetStockFractionProcInfo() 1722�s�ڂ��ڐA</remarks>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        private void GetStockFractionProcInfo(
            int fracProcMoneyDiv,
            int fractionProcCode,
            double targetPrice,
            out double fractionProcUnit,
            out int fractionProcCd
        )
        {
            //-----------------------------------------------------------------------------
            // �����l
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // �P����0.01�~�P��
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // �P���ȊO��1�~�P��
                    break;
            }
            fractionProcCd = 1;     // �؎̂�

            //-----------------------------------------------------------------------------
            // �R�[�h�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            List<StockProcMoney> stockProcMoneyList = StockProcMoneyList.FindAll(
                delegate(StockProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // �\�[�g�i������z�i�����j�j
            //-----------------------------------------------------------------------------
            stockProcMoneyList.Sort(new StockProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // ������z�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            StockProcMoney stockProcMoney = stockProcMoneyList.Find(
                delegate(StockProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // �߂�l�ݒ�
            //-----------------------------------------------------------------------------
            if (stockProcMoney != null)
            {
                fractionProcUnit = stockProcMoney.FractionProcUnit;
                fractionProcCd = stockProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// �d�����z�����敪�}�X�^��r�N���X(������z(����))
        /// </summary>
        /// <remarks>MAHNB01012AD.cs SalesSlipInputInitDataAcs.StockProcMoneyComparer 1791�s�ڂ��ڐA</remarks>
        private class StockProcMoneyComparer : Comparer<StockProcMoney>
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override int Compare(StockProcMoney x, StockProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        #endregion // </�Ώۋ��z���A�Ŕ����A�ō��݉��i���v�Z�p>
    }

    /// <summary>
    /// ���i�l�\����
    /// </summary>
    public struct PriceValue
    {
        /// <summary>�ō��ݒl</summary>
        public double TaxInc;
        /// <summary>�Ŕ����l</summary>
        public double TaxExc;

        #region <Constructoe>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="taxInc">�ō��ݒl</param>
        /// <param name="taxExc">�Ŕ����l</param>
        public PriceValue(
            double taxInc,
            double taxExc
        )
        {
            TaxInc = taxInc;
            TaxExc = taxExc;
        }

        #endregion // </Constructor>
    }
}
