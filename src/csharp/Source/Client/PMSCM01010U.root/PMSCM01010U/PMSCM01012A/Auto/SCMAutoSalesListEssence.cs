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
// �� �� ��  2009/07/02  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30434�@�H�� �b�D 
// �� �� ��  2010/04/21  �C�����e : ���όv��̏ꍇ�A�����A�g�l�����A�L�����y�[���l�����͍s��Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517�@�Ė� �x�� 
// �� �� ��  2010/07/07  �C�����e : ������z�A�������łɂ��Ď����A�g�l�������K�p����Ă��Ȃ��s��̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2010/07/20  �C�����e : �����񓚂̏ꍇ�̒[���������؂�̂ĂɂȂ��Ă��܂��̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : duzg
// �� �� ��  2011/08/15  �C�����e : Redmine#23307�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : wangqx
// �� �� ��  2011/09/29  �C�����e : Redmine#25685�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LIUSY
// �� �� ��  2011/10/10  �C�����e : Redmine#25754 25755�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 �������q
// �� �� ��  2012/07/13  �C�����e : SCM��Q��161 �������ݒ莞�̏�Q�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 �������q
// �� �� ��  2012/11/09  �C�����e : SCM���Ǉ�10337,10338,10341,10364,10431�Ή� PCCforNS�ABLP�̎����񓚔��菈������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g���@�F��
// �� �� ��  2013/01/18  �C�����e : 2013/03/13�z�M SCM��Q��10475�Ή� �����񓚂��x��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30747 �O�ˁ@�L��
// �� �� ��  2013/04/17  �C�����e : 2013/05/22�z�M SCM��Q��10520�Ή� �L�����y�[���l����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �e�c ���V
// �� �� ��  2013/08/07  �C�����e : PM-SCM�d�|�ꗗ��10556�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �����M
// �� �� ��  2013/04/17  �C�����e : �z�M���Ȃ���  Redmine#35271
//			                        No.184 �o�l���G���g���[ �Ή�
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
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2015/01/19  �C�����e : ���R�����h�Ή� ���R�����h�������A�����A�g�l���E�L�����y�[���l���Ή����s��Ȃ�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using System.Windows.Forms;
namespace Broadleaf.Application.Controller.Auto
{
    using SCMTotalSettingServer = SingletonInstance<SCMTotalSettingAgent>;  // SCM�S�̐ݒ�}�X�^

    /// <summary>
    /// �����񓚗p���ナ�X�g�̐����N���X
    /// </summary>
    public sealed class SCMAutoSalesListEssence : SCMSalesListEssence
    {
        private const string MY_NAME = "SCMAutoSalesListEssence";   // ���O�p

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SCMAutoSalesListEssence() : base() { }

        #endregion // </Constructor>

        #region <Override>

        // 2011/02/18 Add >>>
        /// <summary>
        /// �񓚍쐬�敪���擾���܂��B
        /// </summary>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <returns>
        /// �󒍃X�e�[�^�X���u10:���ρv�u30:����v�̏ꍇ�A�u0:�����v��Ԃ��܂��B<br/>
        /// ����ȊO�i�u20:�󒍁v�j�̏ꍇ�A�u1:�蓮(Web)�v��Ԃ��܂��B
        /// </returns>
        protected override int GetAnswerCreateDiv(int acptAnOdrStatus)
        {
            if (
                acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Estimate)
                    ||
                acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Sales)
            )
            {
                return (int)Broadleaf.Application.UIData.Util.AnswerCreateDivValue.Auto;
            }
            return (int)Broadleaf.Application.UIData.Util.AnswerCreateDivValue.ManualWeb;
        }
        // 2011/02/18 Add <<<

        /// <summary>
        /// ���ナ�X�g�𐶐��ł��邩���f���܂��B
        /// </summary>
        /// <param name="scmHeaderRecord">SCM�󒍃f�[�^�̃��R�[�h</param>
        /// <returns>
        /// <c>true</c> :���ナ�X�g�𐶐��ł��܂��B<br/>
        /// <c>false</c>:���ナ�X�g�𐶐��ł��܂���B
        /// </returns>
        /// <see cref="SCMSalesListEssence"/>
        protected override bool CanCreateSalesList(ISCMOrderHeaderRecord scmHeaderRecord)
        {
            SCMTtlSt foundTotalSetting = SCMTotalSettingServer.Singleton.Instance.Find(
                scmHeaderRecord.InqOtherEpCd,
                scmHeaderRecord.InqOtherSecCd
            );
            if (!SCMDataHelper.IsAvailableRecord(foundTotalSetting)) foundTotalSetting = null;
            if (foundTotalSetting != null)
            {
                // UPD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ---------------------------------->>>>>
                #region �폜(SCM���ǂ̈�)
                //if (foundTotalSetting.AutoAnswerDiv.Equals((int)AutoAnswerDiv.All))
                //{
                //    // --- Add 2011/08/15 duzg for Redmine#23307�̑Ή� --->>>
                //    if (scmHeaderRecord.AnswerDivCd.Equals((int)AnswerDivCd.PartAnswer))
                //    {
                //        return true;
                //    }
                //    // --- Add 2011/08/15 duzg for Redmine#23307�̑Ή� ---<<<
                //    return scmHeaderRecord.AnswerDivCd.Equals((int)AnswerDivCd.AnswerCompletion);
                //}
                //else
                //{
                //    return true;
                //}
                #endregion

                // �⍇���E������ʂ��⍇���̎�
                if (scmHeaderRecord.InqOrdDivCd.Equals((int)InqOrdDivCd.Inquiry))
                {
                    // PCC�S�̐ݒ�̎����񓚋敪�i�⍇���j���u����i�S�Ď����񓚁j�v�̎�
                    if (foundTotalSetting.AutoAnsInquiryDiv.Equals((int)AutoAnsInquiryDiv.All))
                    {
                        // �񓚋敪���ꕔ�񓚁A���͉񓚊����̎��A���ナ�X�g�������\
                        if (scmHeaderRecord.AnswerDivCd.Equals((int)AnswerDivCd.PartAnswer))
                        {
                            return true;
                        }
                        return scmHeaderRecord.AnswerDivCd.Equals((int)AnswerDivCd.AnswerCompletion);
                    }
                    else
                    {
                        return true;
                    }
                }
                // �⍇���E������ʂ������̎�
                else if (scmHeaderRecord.InqOrdDivCd.Equals((int)InqOrdDivCd.Order))
                {
                    // PCC�S�̐ݒ�̎����񓚋敪�i�����j���u����i�S�Ď����񓚁j�v�̎�
                    if (foundTotalSetting.AutoAnsOrderDiv.Equals((int)AutoAnsOrderDiv.All))
                    {
                        // �񓚋敪���ꕔ�񓚁A���͉񓚊����̎��A���ナ�X�g�������\
                        if (scmHeaderRecord.AnswerDivCd.Equals((int)AnswerDivCd.PartAnswer))
                        {
                            return true;
                        }
                        return scmHeaderRecord.AnswerDivCd.Equals((int)AnswerDivCd.AnswerCompletion);
                    }
                    else
                    {
                        return true;
                    }
                }
                // UPD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ----------------------------------<<<<<
            }
            return false;
        }

        /// <summary>
        /// ����f�[�^�𔄏ナ�X�g�ɒǉ����܂��B
        /// </summary>
        /// <param name="salesList">���ナ�X�g</param>
        /// <param name="salesSlip">����f�[�^</param>
        /// <see cref="SCMSalesListEssence"/>
        protected override void AddSalesSlipDataToSalesList(
            CustomSerializeArrayList salesList,
            SalesSlip salesSlip
        )
        {
            salesList.Add(CreateSalesSlipWork(salesSlip));
        }

        /// <summary>
        /// ���㖾�׃f�[�^�𔄏ナ�X�g�ɒǉ����܂��B
        /// </summary>
        /// <remarks>
        /// �����A�g�l�����ƃL�����y�[���𔽉f���ASCM�󒍖��׃f�[�^(��)�ւ̓W�J���s���܂��B
        /// </remarks>
        /// <param name="salesList">���ナ�X�g</param>
        /// <param name="salesDetailDataList">���㖾�׃f�[�^�̃��X�g</param>
        /// <see cref="SCMSalesListEssence"/>
        /// <br>UpdateNote : 2011/07/20 杍^ Redmine#22833 �����񓚂̏ꍇ�̒[���������؂�̂ĂɂȂ��Ă��܂��̏C��</br>
        protected override void AddSalesDetailToSalesList(
            CustomSerializeArrayList salesList,
            IList<SalesDetail> salesDetailDataList
        )
        {
            const string METHOD_NAME = "AddSalesDetailToSalesList()";   // ���O�p

            int salesRowNoCount = 0;
            ArrayList salesDetailWorkList = new ArrayList();

            // ADD 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // DEL 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��06.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�j ---------------------------------->>>>>
            //SCMPriceCalculator priceCalculator = new SCMPriceCalculator();
            // DEL 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��06.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�j ----------------------------------<<<<<
            bool first = true;
            // ADD 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            foreach (SalesDetail salesDetail in salesDetailDataList)
            {
                bool isDiscountApply = false; // ADD �����M 2013/04/17 for Redmine#35271
                // ADD 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                if (first)
                {
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("priceCalculator.SetCurrentSCMOrderData  �J�n"));
                    // UPD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��06.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�j ---------------------------------->>>>>
                    //priceCalculator.SetCurrentSCMOrderData(SalesSlipData.CustomerCode, salesDetail);
                    PriceCalculator.SetCurrentSCMOrderData(SalesSlipData.CustomerCode, salesDetail);
                    // UPD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��06.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�j ----------------------------------<<<<<
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("priceCalculator.SetCurrentSCMOrderData  �I��"));
                    first = false;
                }
                // ADD 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                // DEL 2010/04/21 ���όv��̏ꍇ�A�����A�g�l�����A�L�����y�[���l�����͍s��Ȃ� ---------->>>>>
                #region �폜�R�[�h

                //// �����A�g�l�����ƃL�����y�[���𔽉f
                //SCMPriceCalculator priceCalculator = new SCMPriceCalculator();
                //{
                //    priceCalculator.SetCurrentSCMOrderData(SalesSlipData.CustomerCode, salesDetail);
                //    PriceValue priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail, SalesSlipData);
                //    if (!(priceValue.TaxInc.Equals(0.0) && priceValue.TaxExc.Equals(0.0)))
                //    {
                //        salesDetail.SalesUnPrcTaxIncFl = priceValue.TaxInc; // 069.����P��(�ō�, ����)
                //        salesDetail.SalesUnPrcTaxExcFl = priceValue.TaxExc; // 070.����P��(�Ŕ�, ����)
                //    }
                //}

                #endregion // �폜�R�[�h
                // DEL 2010/04/21 ���όv��̏ꍇ�A�����A�g�l�����A�L�����y�[���l�����͍s��Ȃ� ----------<<<<<
                // ADD 2010/04/21 ���όv��̏ꍇ�A�����A�g�l�����A�L�����y�[���l�����͍s��Ȃ� ---------->>>>>

                                // SCM�󒍖��׃f�[�^(��)�֓W�J
                // SCM�i�ڐݒ�ŉ��i���񓚂��Ȃ��P�[�X������̂ŁA�P��������ꍇ�̂�
                ISCMOrderAnswerRecord answerRecord = GetSCMAnswerRecord(salesDetail);
                // UPD 2015/01/19 ���R�����h�Ή� --------------------------------------------------->>>>>
                //if (!IsEstimateAddingUp(salesDetail))
                // ���όv��ƃ��R�����h�������͎����A�g�l���A�L�����y�[���l���ΏۊO
                if (!IsEstimateAddingUp(salesDetail) &&
                    !IsRecommend(salesDetail, answerRecord))
                // UPD 2015/01/19 ���R�����h�Ή� ---------------------------------------------------<<<<<
                {
                    // �����A�g�l�����ƃL�����y�[���𔽉f
                    // DEL 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // SCMPriceCalculator priceCalculator = new SCMPriceCalculator();
                    // DEL 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        // DEL 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        // priceCalculator.SetCurrentSCMOrderData(SalesSlipData.CustomerCode, salesDetail);
                        // DEL 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        PriceValue priceValue;

                        if (salesDetail.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE && answerRecord.InqOrdDivCd == (int)InqOrdDivCd.Order)
                        {
                            // UPD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j ---------------------------------->>>>>
                            //priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail.TaxationDivCd, SalesSlipData.TotalAmountDispWayCd, salesDetail.SalesUnPrcTaxExcFl);
                            priceValue = PriceCalculator.CalcTaxExcAndTaxInc(salesDetail.TaxationDivCd, SalesSlipData.TotalAmountDispWayCd, salesDetail.SalesUnPrcTaxExcFl);
                            // UPD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j ----------------------------------<<<<<
                        }
                        else
                        {
                            // UPD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j ---------------------------------->>>>>
                            //priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail, SalesSlipData);
                            priceValue = PriceCalculator.CalcTaxExcAndTaxInc(salesDetail, SalesSlipData);
                            // UPD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j ----------------------------------<<<<<
                        }


                        if (!(priceValue.TaxInc.Equals(0.0) && priceValue.TaxExc.Equals(0.0)))
                        {
                            salesDetail.SalesUnPrcTaxIncFl = priceValue.TaxInc; // 069.����P��(�ō�, ����)
                            salesDetail.SalesUnPrcTaxExcFl = priceValue.TaxExc; // 070.����P��(�Ŕ�, ����)
                            //>>> 2010/07/07 add
                            // --- DEL 2013/08/07 Y.Wakita ---------->>>>>
                            //salesDetail.SalesMoneyTaxInc = (long)(salesDetail.SalesUnPrcTaxIncFl * salesDetail.ShipmentCnt);    // FIXME:098.������z(�ō���)   �c�Z�o
                            //salesDetail.SalesMoneyTaxExc = (long)(salesDetail.SalesUnPrcTaxExcFl * salesDetail.ShipmentCnt);    // FIXME:099.������z(�Ŕ���)   �c�Z�o
                            // --- DEL 2013/08/07 Y.Wakita ----------<<<<<
                            // --- ADD 2013/08/07 Y.Wakita ---------->>>>>
                            double salesMoneyTaxInc = 0;
                            double salesMoneyTaxExc = 0;

                            // UPD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j ---------------------------------->>>>>
                            //priceCalculator.CalcPrice(salesDetail.TaxationDivCd,
                            //                          (salesDetail.SalesUnPrcTaxExcFl * salesDetail.ShipmentCnt),
                            //                          out salesMoneyTaxExc,
                            //                          out salesMoneyTaxInc);
                            PriceCalculator.CalcPrice(salesDetail.TaxationDivCd,
                                                      (salesDetail.SalesUnPrcTaxExcFl * salesDetail.ShipmentCnt),
                                                      out salesMoneyTaxExc,
                                                      out salesMoneyTaxInc);
                            // UPD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j ----------------------------------<<<<<

                            salesDetail.SalesMoneyTaxInc = (long)salesMoneyTaxInc;    // FIXME:098.������z(�ō���)   �c�Z�o
                            salesDetail.SalesMoneyTaxExc = (long)salesMoneyTaxExc;    // FIXME:099.������z(�Ŕ���)   �c�Z�o
                            // --- ADD 2013/08/07 Y.Wakita ----------<<<<<
                            salesDetail.SalesPriceConsTax = salesDetail.SalesMoneyTaxInc - salesDetail.SalesMoneyTaxExc;        // ������z����Ŋz
                            //<<< 2010/07/07 add
                            // UPD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j ---------------------------------->>>>>
                            //isDiscountApply = priceCalculator.IsDiscountApply; // ADD �����M 2013/04/17 for Redmine#35271
                            isDiscountApply = PriceCalculator.IsDiscountApply; // ADD �����M 2013/04/17 for Redmine#35271
                            // UPD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j ----------------------------------<<<<<
                        }
                    }
                }
                else
                {
                    #region <Log>

                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("�����A�g�l�����ƃL�����y�[���͔��f���܂���B�挩�ςŉ񓚍ςݏ��i�ł�"));

                    #endregion // </Log>
                }
                // ADD 2010/04/21 ���όv��̏ꍇ�A�����A�g�l�����A�L�����y�[���l�����͍s��Ȃ� ----------<<<<<
                SalesDetailWork salesDetailWork = CreateSalesDetailWork(salesDetail);
                {
                    salesDetailWork.SalesRowNo = ++salesRowNoCount; // 012.����s�ԍ�
                    salesDetailWork.SalesSlipDtlNum = 0;            // 018.���㖾�גʔ�
                }
                // --- ADD �����M 2013/04/17 for Redmine#35271 --------->>>>>
                if (isDiscountApply)
                {
                    salesDetailWork.SalesRate = 0.0;
                }
                // --- ADD �����M 2013/04/17 for Redmine#35271 ---------<<<<<
                salesDetailWorkList.Add(salesDetailWork);

                // --- DEL 2013/04/17 �O�� 2013/05/22�z�M�� SCM��Q��10520 --------->>>>>>>>>>>>>>>>>>>>>>>>
                #region �폜
                //// ----- ADD 2011/09/29 ----- >>>>>
                //if (salesDetail.AcceptOrOrderKind != (int)EnumAcceptOrOrderKind.PCCUOE)
                //{
                //// ----- ADD 2011/09/29 ----- <<<<<
                //    // UPD 2012/07/13 SCM��QNo.161 --------------------------------------->>>>>
                //    //if (answerRecord.UnitPrice >= 0)
                //    if (answerRecord.UnitPrice > 0)
                //    // UPD 2012/07/13 SCM��QNo.161 ---------------------------------------<<<<<
                //    {
                //        #region <Log>

                //        string msg = string.Format(
                //            "���i�̍ŏI���ʂ𔽉f���܂��B�񓚃f�[�^.�P��={0} �� {1}�i���_�F{2}, ���[�J�[�F{3}, BL�F{4}, �i�ԁF{5}�j",
                //            answerRecord.UnitPrice,
                //            salesDetail.SalesUnPrcTaxIncFl,
                //            answerRecord.InqOtherSecCd,
                //            answerRecord.GoodsMakerCd,
                //            answerRecord.BLGoodsCode,
                //            answerRecord.GoodsNo
                //        );
                //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                //        #endregion // </Log>
                //        // -----  UPD 2011/07/20  ------------ >>>>>
                //        //answerRecord.UnitPrice = (long)salesDetail.SalesUnPrcTaxExcFl;  // ����P��(�Ŕ�, ����)
                //        answerRecord.UnitPrice = (long)Math.Round(salesDetail.SalesUnPrcTaxExcFl, 0, MidpointRounding.AwayFromZero);
                //        // -----  UPD 2011/07/20  ------------ <<<<<
                //    }
                //    else
                //    {
                //        #region <Log>

                //        string msg = string.Format(
                //            "SCM�i�ڐݒ�Łu�[���v�܂��́u���Ȃ��v�ł��B�񓚃f�[�^.�P��={0} �� 0�i���_�F{1}, ���[�J�[�F{2}, BL�F{3}, �i�ԁF{4}�j",
                //            salesDetail.SalesUnPrcTaxIncFl,
                //            answerRecord.InqOtherSecCd,
                //            answerRecord.GoodsMakerCd,
                //            answerRecord.BLGoodsCode,
                //            answerRecord.GoodsNo
                //        );
                //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                //        #endregion // </Log>

                //        answerRecord.UnitPrice = 0; // SCM�i�ڐݒ�ŉ��i���񓚂��Ȃ��P�[�X
                //    }
                //// ----- ADD 2011/09/29 ----- >>>>>
                //}
                //// ----- ADD 2011/09/29 ----- <<<<<

                //// ----- ADD 2011/10/10 ----- >>>>>
                ////PCCUOE�̏ꍇ
                //else
                //{
                //    if (answerRecord.UnitPrice > 0)
                //    {
                #endregion
                // --- DEL 2013/04/17 �O�� 2013/05/22�z�M�� SCM��Q��10520 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                string msg = string.Format(
                    "���i�̍ŏI���ʂ𔽉f���܂��B�񓚃f�[�^.�P��={0} �� {1}�i���_�F{2}, ���[�J�[�F{3}, BL�F{4}, �i�ԁF{5}�j",
                    answerRecord.UnitPrice,
                    salesDetail.SalesUnPrcTaxIncFl,
                    answerRecord.InqOtherSecCd,
                    answerRecord.GoodsMakerCd,
                    answerRecord.BLGoodsCode,
                    answerRecord.GoodsNo
                );
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                answerRecord.UnitPrice = (long)Math.Round(salesDetail.SalesUnPrcTaxExcFl, 0, MidpointRounding.AwayFromZero);
                // --- DEL 2013/04/17 �O�� 2013/05/22�z�M�� SCM��Q��10520 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //    }
                //}
                //// ----- ADD 2011/10/10 ----- <<<<<
                // --- DEL 2013/04/17 �O�� 2013/05/22�z�M�� SCM��Q��10520 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            }
            salesList.Add(salesDetailWorkList);
        }

        /// <summary>
        /// �����p�̃C���X�^���X�𐶐����܂��B
        /// </summary>
        /// <returns>�����p�̃C���X�^���X</returns>
        /// <see cref="SCMSalesListEssence"/>
        protected override SCMSalesListEssence CreateSplitedEssence()
        {
            return new SCMAutoSalesListEssence();
        }

        #endregion // </Override>
    }
}
