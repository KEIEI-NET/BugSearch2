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
// �� �� ��  2009/05/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30434�@�H�� �b�D 
// �� �� ��  2010/04/22  �C�����e : �쐬����锄��f�[�^���u�󒍁v�ƂȂ�(�󒍃X�e�[�^�X���u�󒍁v�ƂȂ�)�ꍇ�A�����񓚂̑ΏۂƂ��Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/05/21  �C�����e : ������I�v�V�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : duzg
// �� �� ��  2010/08/06  �C�����e : Redmine#23307
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : gaofeng
// �� �� ��  2011/08/10  �C�����e : PCCUOE�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �O�ˁ@�L��
// �� �� ��  2012/04/17  �C�����e : ��Q��166 �������ɍ݌ɂ̊m�F���s���悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g���@�F��
// �� �� ��  2012/06/20  �C�����e : SCM��Q��166�A�V�X�e����Q��98�̖߂�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/06/27  �C�����e : SCM��Q��166�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/11/09  �C�����e : SCM���Ǉ�10337,10338,10341,10364,10431�Ή� PCCforNS�ABLP�̎����񓚔��菈������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g��
// �� �� ��  2013/10/18  �C�����e : ���i�ۏ؉�Redmine#551�Ή�
//----------------------------------------------------------------------------//
#define _ENABLED_MARKET_PRICE_ANSWER_DIV_CHECK_ // ���ꉿ�i�񓚋敪�̃`�F�b�N��L���ɂ���t���O ���ʏ�͗L���ɂ��Ă������ƁI
#define _ENABLED_MARKET_PRICE_OPTION_CHECK_ // ����I�v�V�����̃`�F�b�N��L���ɂ���t���O�@���ʏ�͗L���ɂ��邱�Ɓ@2010/05/21 Add

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;
// 2010/05/21 Add >>>
using Broadleaf.Application.Remoting.ParamData; 
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
// 2010/05/21 Add <<<

namespace Broadleaf.Application.Controller.Auto
{
    using SCMOrderHeaderRecordType  = ISCMOrderHeaderRecord;    // SCM�󒍃f�[�^
    using SCMOrderCarRecordType     = ISCMOrderCarRecord;       // SCM�󒍃f�[�^(�ԗ����)
    using SCMOrderDetailRecordType  = ISCMOrderDetailRecord;    // SCM�󒍖��׃f�[�^(�⍇���E����)
    using SCMOrderAnswerRecordType  = ISCMOrderAnswerRecord;    // SCM�󒍖��׃f�[�^(��)

    using SCMMarketPriceServer = SingletonInstance<SCMMarketPriceAgent>;    // SCM���ꉿ�i�ݒ�}�X�^

    /// <summary>
    /// SCM�����p�񓚔��菈���N���X
    /// </summary>
    public sealed class SCMAutoReferee : SCMReferee
    {
        private const string MY_NAME = "SCMAutoReferee";    // ���O�p

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="searcher">SCM��������</param>
        public SCMAutoReferee(SCMSearcher searcher) : base(searcher) { }

        #endregion // </Constructor>

        #region <SCM���ꉿ�i�ݒ�}�X�^>

        /// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^���擾���܂��B
        /// </summary>
        private static SCMMarketPriceAgent MarketPriceDB
        {
            get { return SCMMarketPriceServer.Singleton.Instance; }
        }

        #endregion // </SCM���ꉿ�i�ݒ�}�X�^>

        #region <Override>

        /// <summary>
        /// �񓚗pSCM���t���i�A���f�[�^����̏ꍇ�A���������܂��B
        /// </summary>
        /// <see cref="SCMReferee"/>
        public override void InitializeIfSCMGoodsUnitDataMapIsEmpty()
        {
            if (SCMGoodsUnitDataMap.Count.Equals(0))
            {
                CanReplyAutomatically();
            }
        }

        #region <����񓚗p��SCM���t���i�A���f�[�^�\�z>

        /// <summary>
        /// ������t���񓚗pSCM���t���i�A���f�[�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="detailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</param>
        /// <returns>������t���񓚗pSCM���t���i�A���f�[�^�̃��X�g</returns>
        /// <see cref="SCMReferee"/>
        protected override IList<SCMGoodsUnitData> GetSCMGoodsUnitDataListHavingSobaResponse(SCMOrderDetailRecordType detailRecord)
        {
            const string METHOD_NAME = "GetSCMGoodsUnitDataListHavingSobaResponse()";   // ���O�p

            #region <Guard Phrase>

            // �w�b�_���Ȃ�
            if (!RelationalHeaderMap.ContainsKey(detailRecord.ToRelationKey()))
            {
                Debug.Assert(false, string.Format("���ׂ̃w�b�_�����݂��܂���B�F{0}", detailRecord.ToRelationKey()));
                return new List<SCMGoodsUnitData>();
            }
            else
            {
                // SCM�󒍃f�[�^.�⍇���E������ʂ��u1:�⍇���v�łȂ���Ώ������Ȃ�
                if (!RelationalHeaderMap[detailRecord.ToRelationKey()].InqOrdDivCd.Equals((int)InqOrdDivCdValue.Inquiry))
                {
                    return new List<SCMGoodsUnitData>();
                }
            }

            // �������ʂ��Ȃ�
            if (!Searcher.ResultMap.ContainsKey(detailRecord.ToKey()))
            {
                return new List<SCMGoodsUnitData>();
            }

            #endregion // </Guard Phrase>

            // 2010/05/21 Add >>>

            #region ������I�v�V�����̃`�F�b�N
        #if _ENABLED_MARKET_PRICE_OPTION_CHECK_

            PurchaseStatus psMarketInfo = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_MarketInfo);
            if (psMarketInfo != PurchaseStatus.Contract && psMarketInfo != PurchaseStatus.Trial_Contract)
            {
                #region <Log>

                string msg = "������I�v�V�������_�񂳂�Ă��܂���B";
                msg += Environment.NewLine + SCMDataHelper.GetLabel(detailRecord);
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                return new List<SCMGoodsUnitData>();
            }
        #endif
            #endregion
            // 2010/05/21 Add <<<

            #region <���ꉿ�i�񓚋敪�̃`�F�b�N>

        #if _ENABLED_MARKET_PRICE_ANSWER_DIV_CHECK_

            // SCM���ꉿ�i�ݒ�}�X�^�ɓo�^���Ȃ��܂��͑��ꉿ�i�񓚋敪���u0:���Ȃ��v�̏ꍇ�A�I��
            SCMMrktPriSt scmMarketPriceSetting = SCMMarketPriceServer.Singleton.Instance.Find(
                detailRecord.InqOtherEpCd,
                detailRecord.InqOtherSecCd
            );
            if (!SCMDataHelper.IsAvailableRecord(scmMarketPriceSetting)) scmMarketPriceSetting = null;
            if (
                scmMarketPriceSetting == null
                    ||
                scmMarketPriceSetting.MarketPriceAnswerDiv.Equals((int)MarketPriceAnswerDiv.None)
            )
            {
                #region <Log>

                string msg = "SCM���ꉿ�i�ݒ�}�X�^�ɓo�^���Ȃ� �܂��� SCM���ꉿ�i�ݒ�}�X�^.���ꉿ�i�񓚋敪���u0:���Ȃ��v�ł��B";
                msg += Environment.NewLine + SCMDataHelper.GetLabel(detailRecord);
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                return new List<SCMGoodsUnitData>();
            }

        #endif

            #endregion // </���ꉿ�i�񓚋敪�̃`�F�b�N>

            IList<SCMGoodsUnitData> scmGoodsUnitDataList = new List<SCMGoodsUnitData>();
            {
                // ��������擾
                string relevanceModel = GetRelevanceModel(detailRecord);
                if (string.IsNullOrEmpty(relevanceModel.Trim()))
                {
                    #region <Log>

                    string msg = "�u�i�Ԍ����̂��ߎԗ��������ʂ������v�܂��́u�ԗ��������ʂɗޕʌ^������������v���߁A������̎擾�𒆒f���܂����B";
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return scmGoodsUnitDataList;
                }

                Debug.WriteLine("���׃L�[�F" + detailRecord.ToKey() + ", BL�R�[�h�F" + detailRecord.BLGoodsCode.ToString());
                foreach (GoodsUnitData goodsUnitData in Searcher.ResultMap[detailRecord.ToKey()].GoodsUnitDataList)
                {
                    // ��������擾�pSCM���t���i�A���f�[�^
                    SCMGoodsUnitData gettingCondition = new SCMGoodsUnitData(
                        goodsUnitData,
                        Searcher.ResultMap[detailRecord.ToKey()].SearchedType,
                        detailRecord,
                        GetCustomerCode(detailRecord)
                    );
                    // ��������擾
                    IList<SCMSobaResponseHelper> foundSobaResponseList = MarketPriceDB.GetSobaResponse(
                        detailRecord,
                        relevanceModel,
                        gettingCondition
                    );
                    // ���ꉿ�i��ʂ̐ݒ萔���̑����񂪕Ԃ��Ă���̂ŁA
                    // ���̌������̉񓚗pSCM���t���i�A���f�[�^�𐶐�����
                    foreach (SCMSobaResponseHelper sobaResponse in foundSobaResponseList)
                    {
                        if (!sobaResponse.Exists) continue;

                        SCMGoodsUnitData scmGoodsUnitData = new SCMGoodsUnitData(
                            goodsUnitData,
                            Searcher.ResultMap[detailRecord.ToKey()].SearchedType,
                            detailRecord,
                            GetCustomerCode(detailRecord)
                        );
                        scmGoodsUnitData.AddSobaResponse(sobaResponse);

                        scmGoodsUnitDataList.Add(scmGoodsUnitData);
                    }

                    // 1���ו�(1BL�R�[�h��)�ł悢�̂ŁA�����I�ɏI��
                    return scmGoodsUnitDataList;
                }   // foreach (GoodsUnitData goodsUnitData in Searcher.ResultMap[detailRecord.ToKey()].GoodsUnitDataList)
            }
            return scmGoodsUnitDataList;
        }

        #endregion // </����񓚗p��SCM���t���i�A���f�[�^�\�z>

        // ADD 2010/04/22 �쐬����锄��f�[�^���u�󒍁v�ƂȂ�(�󒍃X�e�[�^�X���u�󒍁v�ƂȂ�)�ꍇ�A�����񓚂̑ΏۂƂ��Ȃ� ---------->>>>>
        #region <����f�[�^���쐬�ł��邩�̔���>

        /// <summary>
        /// ����f�[�^���쐬�ł��邩���f���܂��B
        /// </summary>
        /// <param name="detailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</param>
        /// <param name="scmGoodsUnitDataList">SCM�p�̏��t���i�A���f�[�^�̃��X�g</param>
        /// <returns>
        /// <c>true</c> :����f�[�^���쐬�ł��܂��B<br/>
        /// <c>false</c>:����f�[�^���쐬�ł��܂���B(�󒍃X�e�[�^�X���u�󒍁v�ƂȂ鏤�i���܂݂܂�)
        /// </returns>
        protected override bool CanMakeSalesData(
            ISCMOrderDetailRecord detailRecord,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            const string METHOD_NAME = "CanMakeSalesData()";    // ���O�p

            #region <Guard Phrase>

            if (detailRecord == null || ListUtil.IsNullOrEmpty(scmGoodsUnitDataList)) return false;

            #endregion // </Guard Phrase>
            // --- Add  2011/08/02 duzg for Redmine#23307 --->>>
            // SCM�S�̐ݒ���擾
            SCMTtlSt foundSCMTtlSt = TtlStSettingDB.Find(
                 detailRecord.InqOtherEpCd,
                 detailRecord.InqOtherSecCd
                );
            // --- Add  2011/08/02 duzg for Redmine#23307 ---<<<

            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ---------------------------------->>>>>
            // �D��ݒ�̍i�荞�݌��ʁA�����P�i�Ԃ�
            bool onePureGoodsFlag = IsOnePureGoods(scmGoodsUnitDataList);
            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ----------------------------------<<<<<

            foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
            {
                int acptAnOdrStatus = scmGoodsUnitData.GetAcptAnOdrStatus();
                // UPD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ---------------------------------->>>>>
                #region �폜(SCM���ǂ̈�)
                //// ----- 2011/08/10 ----- >>>>>
                //// SCM�̏ꍇ
                //if (RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM)
                //{
                //// ----- 2011/08/10 ----- <<<<<
                //    if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                //    {
                //        #region <�蓮��>

                //        #region <Log>

                //        string msg = "�󒍃X�e�[�^�X���u�󒍁v�ƂȂ邽�߁A�蓮�񓚂Ƃ��܂����B";
                //        string label = SCMDataHelper.GetLabel(detailRecord) + Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData.RealGoodsUnitData);
                //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                //        #endregion // </Log>

                //        // �蓮�񓚂Ɣ��肳�ꂽSCM�󒍖��׃f�[�^(�⍇���E����)�̃}�b�v�֒ǉ�
                //        if (!ManualSCMDetailRecordMap.ContainsKey(detailRecord.ToKey()))
                //        {
                //            ManualSCMDetailRecordMap.Add(detailRecord.ToKey(), detailRecord);
                //        }

                //        #endregion // </�蓮��>

                //        return false;
                //    }
                //    // --- Add 2011/08/06 duzg for Redmine#23307 --->>>
                //    else if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Sales) && scmGoodsUnitData.GetStockDiv() != (int)StockDiv.Trust
                //        && scmGoodsUnitData.GetStockDiv() != (int)StockDiv.Customer
                //        && scmGoodsUnitData.GetStockDiv() != (int)StockDiv.PriorityWarehouse && foundSCMTtlSt.AutoAnswerDiv != 3)
                //    {
                //        #region <�蓮��>

                //        #region <Log>

                //        string msg = "�ϑ��݌ɂł͂Ȃ��̂ŁA�蓮�񓚂Ƃ��܂����B";
                //        string label = SCMDataHelper.GetLabel(detailRecord) + Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData.RealGoodsUnitData);
                //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                //        #endregion // </Log>

                //        // �蓮�񓚂Ɣ��肳�ꂽSCM�󒍖��׃f�[�^(�⍇���E����)�̃}�b�v�֒ǉ�
                //        if (!ManualSCMDetailRecordMap.ContainsKey(detailRecord.ToKey()))
                //        {
                //            ManualSCMDetailRecordMap.Add(detailRecord.ToKey(), detailRecord);
                //        }

                //        #endregion // </�蓮��>

                //        return false;
                //    }
                //    // --- Add 2011/08/06 duzg for Redmine#23307 ---<<<
                //    /* --- Del 2011/08/06 duzg for Redmine#23307 --->>>
                //    // 2011/02/18 Add >>>
                //    else if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Sales) && scmGoodsUnitData.GetStockDiv() != (int)StockDiv.Trust)
                //    {
                //        #region <�蓮��>

                //        #region <Log>

                //        string msg = "�ϑ��݌ɂł͂Ȃ��̂ŁA�蓮�񓚂Ƃ��܂����B";
                //        string label = SCMDataHelper.GetLabel(detailRecord) + Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData.RealGoodsUnitData);
                //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                //        #endregion // </Log>

                //        // �蓮�񓚂Ɣ��肳�ꂽSCM�󒍖��׃f�[�^(�⍇���E����)�̃}�b�v�֒ǉ�
                //        if (!ManualSCMDetailRecordMap.ContainsKey(detailRecord.ToKey()))
                //        {
                //            ManualSCMDetailRecordMap.Add(detailRecord.ToKey(), detailRecord);
                //        }

                //        #endregion // </�蓮��>

                //        return false;
                //    }
                //    // 2011/02/18 Add <<<
                //     --- Del 2011/08/06 duzg for Redmine#23307 ---<<<*/
                //// ----- 2011/08/10 ----- >>>>>
                //}
                //// PCCUOE�̏ꍇ
                //else
                //{
                //    if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                //    {
                //        #region <�蓮��>

                //        #region <Log>

                //        string msg = "�󒍃X�e�[�^�X���u�󒍁v�ƂȂ邽�߁A�蓮�񓚂Ƃ��܂����B";
                //        string label = SCMDataHelper.GetLabel(detailRecord) + Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData.RealGoodsUnitData);
                //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                //        #endregion // </Log>

                //        // �蓮�񓚂Ɣ��肳�ꂽSCM�󒍖��׃f�[�^(�⍇���E����)�̃}�b�v�֒ǉ�
                //        if (!ManualSCMDetailRecordMap.ContainsKey(detailRecord.ToKey()))
                //        {
                //            ManualSCMDetailRecordMap.Add(detailRecord.ToKey(), detailRecord);
                //        }

                //        #endregion // </�蓮��>

                //        return false;
                //    }
                //    // �����̏ꍇ�A��ϑ��݌ɖ��͍݌ɕs��
                //    else if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Sales) 
                //        && (scmGoodsUnitData.GetStockDiv() != (int)StockDiv.Trust
                //        // UPD 2012/06/27 SCM��Q��166 �݌ɏ��擾----------------------------------->>>>>
                //        // --- UPD �g�� 2012/06/20 SCM��Q��166�A�V�X�e���e�X�g��98�̖߂�   ---------->>>>>
                //        //    || detailRecord.PmPrsntCount < detailRecord.SalesOrderCount))
                //        // --- UPD �O�� 2012/04/17 ��166 ---------->>>>>
                //        //|| scmGoodsUnitData.GetStockQty() < detailRecord.SalesOrderCount))
                //        // --- UPD �O�� 2012/04/17 ��166 ----------<<<<<
                //        // --- UPD �g�� 2012/06/20 SCM��Q��166�A�V�X�e���e�X�g��98�̖߂�   ----------<<<<<
                //        || scmGoodsUnitData.GetStockQty() < detailRecord.SalesOrderCount))
                //        // UPD 2012/06/27 SCM��Q��166 �݌ɏ��擾-----------------------------------<<<<<
                //    {
                //        #region <�蓮��>
                //        string msg = string.Empty;
                //        // ��ϑ��݌�
                //        if (scmGoodsUnitData.GetStockDiv() != (int)StockDiv.Trust)
                //        {
                //            msg = "�ϑ��݌ɂł͂Ȃ��̂ŁA�蓮�񓚂Ƃ��܂����B";
                //        }
                //        // �݌ɕs��
                //        else if (scmGoodsUnitData.GetStockQty() < detailRecord.SalesOrderCount)
                //        {
                //            msg = "�݌ɕs���Ȃ̂ŁA�蓮�񓚂Ƃ��܂����B";
                //        }

                //        #region <Log>

                //        string label = SCMDataHelper.GetLabel(detailRecord) + Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData.RealGoodsUnitData);
                //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                //        #endregion // </Log>

                //        // �蓮�񓚂Ɣ��肳�ꂽSCM�󒍖��׃f�[�^(�⍇���E����)�̃}�b�v�֒ǉ�
                //        if (!ManualSCMDetailRecordMap.ContainsKey(detailRecord.ToKey()))
                //        {
                //            ManualSCMDetailRecordMap.Add(detailRecord.ToKey(), detailRecord);
                //        }

                //        #endregion // </�蓮��>

                //        return false;
                //    }
                //}
                //// ----- 2011/08/10 ----- <<<<<
                #endregion

                // �󒍃X�e�[�^�X���u�󒍁v�̎�
                if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                {
                    #region <�蓮��>

                    #region <Log>

                    string msg = "�󒍃X�e�[�^�X���u�󒍁v�ƂȂ邽�߁A�蓮�񓚂Ƃ��܂����B";
                    string label = SCMDataHelper.GetLabel(detailRecord) + Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData.RealGoodsUnitData);
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                    #endregion // </Log>

                    // �蓮�񓚂Ɣ��肳�ꂽSCM�󒍖��׃f�[�^(�⍇���E����)�̃}�b�v�֒ǉ�
                    if (!ManualSCMDetailRecordMap.ContainsKey(detailRecord.ToKey()))
                    {
                        ManualSCMDetailRecordMap.Add(detailRecord.ToKey(), detailRecord);
                    }

                    #endregion // </�蓮��>

                    return false;
                }

                // �⍇����PCC�S�̐ݒ�̎����񓚋敪�i�⍇���j���u����i�i�荞�ݎ������񓚁j�v�̎�
                if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Estimate)
                    && foundSCMTtlSt.AutoAnsInquiryDiv.Equals((int)AutoAnsInquiryDiv.SelectAuto))
                {
                    // �D��ݒ�ł̍i�荞�݂������P�i�Ԃł͂Ȃ����A�蓮��
                    if (!onePureGoodsFlag)
                    {
                        #region <�蓮��>

                        #region <Log>

                        string msg = "�D��ݒ�ɂ��i�荞�݂ŏ����P�i�Ԃł͂Ȃ����߁A�蓮�񓚂Ƃ��܂����B";
                        string label = SCMDataHelper.GetLabel(detailRecord) + Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData.RealGoodsUnitData);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                        #endregion // </Log>

                        // �蓮�񓚂Ɣ��肳�ꂽSCM�󒍖��׃f�[�^(�⍇���E����)�̃}�b�v�֒ǉ�
                        if (!ManualSCMDetailRecordMap.ContainsKey(detailRecord.ToKey()))
                        {
                            ManualSCMDetailRecordMap.Add(detailRecord.ToKey(), detailRecord);
                        }

                        #endregion // </�蓮��>

                        return false;

                    }
                }
                // ������PCC�S�̐ݒ�̎����񓚋敪�i�����j���u����i�ϑ��q�ɕ��̂ݎ����񓚁j�v�̎�
                if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Sales)
                    && foundSCMTtlSt.AutoAnsOrderDiv.Equals((int)AutoAnsOrderDiv.TrustAuto))
                {
                    // �݌ɋ敪���ϑ��݌ɈȊO�̎��A�蓮��
                    if (!scmGoodsUnitData.GetStockDiv().Equals((int)StockDiv.Trust))
                    {
                        #region <�蓮��>

                        #region <Log>

                        string msg = "�ϑ��݌ɂł͂Ȃ��̂ŁA�蓮�񓚂Ƃ��܂����B";
                        string label = SCMDataHelper.GetLabel(detailRecord) + Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData.RealGoodsUnitData);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                        #endregion // </Log>

                        // �蓮�񓚂Ɣ��肳�ꂽSCM�󒍖��׃f�[�^(�⍇���E����)�̃}�b�v�֒ǉ�
                        if (!ManualSCMDetailRecordMap.ContainsKey(detailRecord.ToKey()))
                        {
                            ManualSCMDetailRecordMap.Add(detailRecord.ToKey(), detailRecord);
                        }

                        #endregion // </�蓮��>

                        return false;
                    }
                }
                // UPD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ----------------------------------<<<<<
            }
            return true;
        }

        #endregion // </����f�[�^���쐬�ł��邩�̔���>
        // ADD 2010/04/22 �쐬����锄��f�[�^���u�󒍁v�ƂȂ�(�󒍃X�e�[�^�X���u�󒍁v�ƂȂ�)�ꍇ�A�����񓚂̑ΏۂƂ��Ȃ� ----------<<<<<

        #endregion // </Override>

        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ---------------------------------->>>>>
        #region <�����P�i�Ԃ̔���>
        /// <summary>
        /// ����1�i�Ԃ����f���܂��B
        /// </summary>
        /// <param name="detailRecordList">SCM�p�̏��t���i�A���f�[�^���X�g</param>
        /// <returns>
        /// <c>true</c> :����1�i�Ԃł��B<br/>
        /// <c>false</c>:����1�i�Ԃł͂���܂���B
        /// </returns>
        protected bool IsOnePureGoods(IList<SCMGoodsUnitData> detailRecordList)
        {
            const string METHOD_NAME = "IsOnePureGoods()";  // ���O�p

            #region <Guard Phrase>

            // ���X�g���Ȃ����Afalse
            if (detailRecordList == null)
            {
                return false;
            }

            #endregion // </Guard Phrase>

            #region <Log>

            string title = "����1�i�Ԃł��邩���蒆...";
            title += Environment.NewLine + SCMDataHelper.GetProfile(detailRecordList);
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(title));

            #endregion // </Log>

            // ������2���ȏ㑶�݂����ꍇ�Afalse
            int pureCount = 0;
            foreach (SCMGoodsUnitData scmgoodsUnitData in detailRecordList)
            {
                GoodsUnitData goodsUnitData = (GoodsUnitData)scmgoodsUnitData.RealGoodsUnitData;
                #region ���όv��p����

                // �O��A����ϣ�ŉ񓚍ςݏ��i�̓`�F�b�N�ΏۂƂ��Ȃ�
                if (goodsUnitData is AnsweredGoodsUnitData)
                {
                    #region <Log>

                    string msg = "����1�i�Ԃ̔�����ȗ����܂��B��O��A����ϣ�ŉ񓚍ςݏ��i�ł�";
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    continue;
                }

                #endregion // ���όv��p����
                // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ----------<<<<<

                // DEL 2013/10/18 �g�� ���i�ۏ؉�Redmine#551 ---------->>>>>>>>>>
                //// ���i�A���f�[�^�̏��i���(��������)���Z�b�g�q�̏ꍇ�A����1�i�Ԃł͂Ȃ��i�蓮�񓚁j
                //if (ContainsSetChildAtGoodsKind(goodsUnitData))
                //{
                //    #region <Log>

                //    string msg = "����1�i�Ԃł͂���܂���B�揤�i�A���f�[�^�̏��i���(��������)���Z�b�g�q";
                //    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                //    #endregion // </Log>

                //    return false;
                //}
                // DEL 2013/10/18 �g�� ���i�ۏ؉�Redmine#551 ----------<<<<<<<<<< 

                // ���i�A���f�[�^�̏��i���(��������)���e�܂��͑�ւ܂��͑�֌݊��ŁA
                // �u�񋟋敪(OfferKubun)�F�����v�̃f�[�^��2���ȏ㑶�݂����ꍇ�A
                // ����1�i�Ԃł͂Ȃ��i�蓮�񓚁j
                if (ContainsParentAtGoodsKind(goodsUnitData) && IsPureAtOfferKubun(goodsUnitData))
                {
                    pureCount++;

                    #region <Log>

                    string msg = "���i�A���f�[�^�̏��i���(��������)���e �܂��� ��� �܂��� ��֌݊��ŁA�u�񋟋敪(OfferKubun)�F�����v�̃f�[�^";
                    msg += Environment.NewLine + "\t" + SCMDataHelper.GetProfile(goodsUnitData);
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    if (pureCount > 1)
                    {
                        #region <Log>

                        msg = "����1�i�Ԃł͂���܂���B";
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return false;
                    }
                }
            }

            #region <Log>

            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("����1�i�Ԃł��B"));

            #endregion // </Log>

            return true;
        }
        #endregion
        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ----------------------------------<<<<<

    }
}
