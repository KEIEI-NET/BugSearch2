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
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/03/15  �C�����e : �@�񓚔[���ŁA�ݒ莞�Ԕ͈͊O�̏ꍇ�͋󔒂�Ԃ�
//                                 �A���㖾�׃f�[�^�̉񓚔[�����Z�b�g����Ȃ��s��̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���X�� ��
// �� �� ��  2010/03/17  �C�����e : ������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���X�� ��
// �� �� ��  2011/01/11  �C�����e : �[���񓚐ݒ�}�X�^�̃��C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/10/11  �C�����e : Redmine#25765�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g�� �F���@30745
// �� �� ��  2012/08/30  �C�����e : 2012/10���z�M�\��SCM��Q��10345�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g�� �F���@30745
// �� �� ��  2015/02/10  �C�����e : SCM������ �񓚔[���敪�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Diagnostics;
// 2010/03/12 Add >>>
using System.Collections;
// 2010/03/12 Add <<<

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SCMDeliDateStAcs;
    using RecordType        = SCMDeliDateSt;

    /// <summary>
    /// SCM�[���ݒ�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public class SCMDeliveryDateSettingAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "SCM�[���ݒ�}�X�^";

        /// <summary>�S���Ӑ�</summary>
        private const int ALL_CUSTOMER_CODE = 0;
        /// <summary>�S��</summary>
        private const string ALL_SECTION_CODE = SecInfoSetAgent.ALL_SECTION_CODE;

        /// <summary>���Ӑ�R�[�h�̃t�H�[�}�b�g</summary>
        private const string CUSTOMER_CODE_FORMAT = "000000000";

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SCMDeliveryDateSettingAgent() : base() { }

        #endregion // </Constructor>

        // 2010/03/17 Add >>>
        List<RecordType> _allList;

        /// <summary>
        /// SCM�[���ݒ���A���Ӑ�R�[�h�A���_�R�[�h�t���Ƀ\�[�g����
        /// </summary>
        /// <remarks></remarks>
        private class EstiamteDefSetComparer : Comparer<RecordType>
        {
            public override int Compare(RecordType x, RecordType y)
            {
                int result = y.CustomerCode.CompareTo(x.CustomerCode);
                if (result != 0) return result;

                result = y.SectionCode.Trim().CompareTo(x.SectionCode.Trim());
                if (result != 0) return result;

                return result;
            }
        }
        // 2010/03/17 Add <<<

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>�Y������SCM���ꉿ�i�ݒ�</returns>
        private RecordType Find(
            string enterpriseCode,
            string sectionCode,
            int customerCode
        )
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatSectionCode(sectionCode)
                + customerCode.ToString(CUSTOMER_CODE_FORMAT);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            // 2010/03/17 >>>
            //// ���Ӑ�R�[�h��D��
            //string param2SectionCode= (customerCode > 0 ? string.Empty : sectionCode);
            //int param3CustomerCode  = customerCode;

            //int status = RealAccesser.Read(out foundRecord, enterpriseCode, param2SectionCode, param3CustomerCode);
            //if (customerCode > 0 && status.Equals((int)ResultUtil.ResultCode.NotFound))
            //{
            //    // ����0���̏ꍇ�A���_�R�[�h�ōČ���
            //    param2SectionCode   = sectionCode;
            //    param3CustomerCode  = 0;
            //    status = RealAccesser.Read(out foundRecord, enterpriseCode, param2SectionCode, param3CustomerCode);
            //}

            //if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            //{
            //    Debug.Assert(false, MY_NAME + "�̌��������s���܂����B");
            //    return null;
            //}

            //if (foundRecord != null && foundRecord.LogicalDeleteCode.Equals(0))
            //{
            //    FoundRecordMap.Add(key, foundRecord);
            //}

            RecordType foundRecord = null;
            if (_allList == null)
            {
                _allList = new List<SCMDeliDateSt>();
                ArrayList al;
                int status = RealAccesser.Search(out al, enterpriseCode);
                if (status.Equals((int)ResultUtil.ResultCode.Normal))
                {
                    if (al != null && al.Count > 0)
                    {
                        foreach (SCMDeliDateSt rec in al)
                        {
                            _allList.Add(rec);
                        }

                        _allList.Sort(new EstiamteDefSetComparer());
                    }
                }
            }

            foundRecord = _allList.Find(
                delegate(RecordType rec)
                {
                    if (rec.CustomerCode == customerCode)
                    {
                        return true;
                    }

                    if (rec.SectionCode.Trim() == sectionCode.Trim() || rec.SectionCode.Trim() == "00")
                    {
                        return true;
                    }
                    return false;
                });

            if (foundRecord != null && foundRecord.LogicalDeleteCode.Equals(0))
            {
                FoundRecordMap.Add(key, foundRecord);
            }
            // 2010/03/17 <<<

            return foundRecord ?? new RecordType();
        }

        /// <summary>
        /// �񓚔[�����������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="isStock">�݌Ƀt���O</param>
        /// <param name="isTrustStock">�ϑ��t���O</param>
        /// <param name="isPriorityStock">�D��t���O</param>
        /// <param name="shelfNo">�I��</param>
        /// <param name="ansDeliDateDiv">�񓚔[���敪</param>
        /// <returns>�Y������񓚔[��</returns>
        public string FindAnswerDelivDate(
            string enterpriseCode,
            string sectionCode,
            // 2011/01/11 >>>
            //int customerCode
            int customerCode,
            bool isStock,
            bool isTrustStock,
            bool isPriorityStock, // ADD 2011/10/11
            string shelfNo
            // 2011/01/11 <<<
            , out short ansDeliDateDiv  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
        )
        {
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // �� �����\�b�h�g�pPG�͎����񓚂݂̂ő�PG����̎Q�Ƃ͖���
            ansDeliDateDiv = 0;
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            SCMDeliDateSt foundDeriveryDateSetting = Find(enterpriseCode, sectionCode, customerCode);
            if (!SCMDataHelper.IsAvailableRecord(foundDeriveryDateSetting)) foundDeriveryDateSetting = null;
            if (foundDeriveryDateSetting == null)
            {
                // ������΁A�S���Ӑ�Ō���
                foundDeriveryDateSetting = Find(enterpriseCode, sectionCode, ALL_CUSTOMER_CODE);
                if (!SCMDataHelper.IsAvailableRecord(foundDeriveryDateSetting)) foundDeriveryDateSetting = null;
                if (foundDeriveryDateSetting == null)
                {
                    // ������΁A�S�ЂŌ���
                    foundDeriveryDateSetting = Find(enterpriseCode, ALL_SECTION_CODE, ALL_CUSTOMER_CODE);
                    if (!SCMDataHelper.IsAvailableRecord(foundDeriveryDateSetting)) foundDeriveryDateSetting = null;
                    if (foundDeriveryDateSetting == null) return string.Empty;
                }
            }

            // 2011/01/11 Add >>>
            // �ϑ��݌ɂ̏ꍇ
            if (isTrustStock)
            {
                // �ϑ��݌ɉ񓚔[���敪���Q�Ƃ��Č���
                switch (foundDeriveryDateSetting.EntStckAnsDeliDtDiv)
                {
                    case 1:  // 1:�I��
                        return shelfNo;
                        break;
                    case 2:  // 2:�ϑ��p�ɐݒ�
                        return foundDeriveryDateSetting.EntStckAnsDeliDate;
                        break;
                    default: // ��L�ȊO�͒ʏ�̍݌ɂƓ����񓚔[�����g�p����
                        break;
                }
            }
            // 2011/01/11 Add <<<

            // ----- ADD 2011/10/11 ----- >>>>>
            // �D��݌ɉ񓚔[�����Q�Ƃ��A�񓚔[����ݒ肷��B
            // �D��݌ɂ̏ꍇ
            if (isPriorityStock)
            {
                // �D��݌ɉ񓚔[���敪���Q�Ƃ��Č���
                switch (foundDeriveryDateSetting.PriStckAnsDeliDtDiv)
                {
                    case 1:  // 1:�D��p�ɐݒ�
                        return foundDeriveryDateSetting.PriStckAnsDeliDate;
                        break;
                    default: // ��L�ȊO�͒ʏ�̍݌ɂƓ����񓚔[�����g�p����
                        break;
                }
            }
            // ----- ADD 2011/10/11 ----- <<<<<

            // �񓚔[���̃��X�g�c�񓚒��؎����Ń\�[�g
            // 2011/01/11 >>>
            //SortedList<int, string> answerDelivDateList = CreateAnswerDelivDateList(foundDeriveryDateSetting);
            // SortedList<int, string> answerDelivDateList = CreateAnswerDelivDateList(foundDeriveryDateSetting, isStock);  // DEL 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
            // string[]��2���̂� 1�ԖځF�񓚔[��  2�ԖځF�񓚔[���敪 Int16��string�ɃL���X�g�������                      // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
            SortedList<int, string[]> answerDelivDateList = CreateAnswerDelivDateList(foundDeriveryDateSetting, isStock);  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
            // 2011/01/11 <<<

            // ���݂̎�������񓚔[���𔻒�
            int now = int.Parse(DateTime.Now.ToString("HHmmss"));
            string answerDelivDate = string.Empty;
            bool find = false;  // 2011/03/11 Add 
            // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region ���\�[�X
            //foreach (KeyValuePair<int, string> answerDelivPair in answerDelivDateList)
            //{
            //    Debug.WriteLine(answerDelivPair.Key.ToString() + " " + answerDelivPair.Value);

            //    //if (string.IsNullOrEmpty(answerDelivDate)) answerDelivDate = answerDelivPair.Value;     // 2010/03/15 Del 

            //    if (answerDelivPair.Key >= now)
            //    {
            //        answerDelivDate = answerDelivPair.Value;
            //        find = true;  // 2011/03/11 Add 
            //        break;
            //    }
            //}
            //if (!find && answerDelivDateList.Count > 0) answerDelivDate = answerDelivDateList.Values[0]; // 2011/03/11 Add
            #endregion
            // �� �����\�b�h�́u���v�̏ꍇ�̂݁@
            // �u���v�̏ꍇ�́A�K��isTrustStock�AisPriorityStock��false�ɂȂ�܂�
            // ��L�A�u�ϑ��݌ɂ̏ꍇ�v�Ɓu�D��݌ɂ̏ꍇ�v�ŉ񓚔[���敪�̐ݒ�͕K�v�����A�ȉ��Őݒ肵�Ă����OK
            foreach (KeyValuePair<int, string[]> answerDelivPair in answerDelivDateList)
            {
                Debug.WriteLine(answerDelivPair.Key.ToString() + " " + answerDelivPair.Value[0]);

                if (answerDelivPair.Key >= now)
                {
                    answerDelivDate = answerDelivPair.Value[0];
                    Int16.TryParse(answerDelivPair.Value[1], out ansDeliDateDiv);
                    find = true;  
                    break;
                }
            }

            if (!find && answerDelivDateList.Count > 0)
            {
                answerDelivDate = answerDelivDateList.Values[0][0];
                Int16.TryParse(answerDelivDateList.Values[0][1], out ansDeliDateDiv);
            }
            // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            return answerDelivDate;
        }

        // 2012/08/30 ADD T.Yoshioka 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �񓚔[�����������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="isStock">�݌Ƀt���O</param>
        /// <param name="isTrustStock">�ϑ��t���O</param>
        /// <param name="isPriorityStock">�D��t���O</param>
        /// <param name="salesOrderCount">������</param>
        /// <param name="stockQty">�݌ɐ���</param>
        /// <param name="ansDeliDateDiv">�񓚔[���敪</param>
        /// <returns>�Y������񓚔[��</returns>
        public string FindAnswerDelivDate2(
            string enterpriseCode,
            string sectionCode,
            int customerCode,
            bool isStock,
            bool isTrustStock,
            bool isPriorityStock,
            double salesOrderCount,
            double stockQty
            ,out Int16 ansDeliDateDiv  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
        )
        {
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // �� �����\�b�h�g�pPG�͎����񓚂݂̂ő�PG����̎Q�Ƃ͖���
            ansDeliDateDiv = 0;
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            SCMDeliDateSt foundDeriveryDateSetting = Find(enterpriseCode, sectionCode, customerCode);
            if (!SCMDataHelper.IsAvailableRecord(foundDeriveryDateSetting)) foundDeriveryDateSetting = null;
            if (foundDeriveryDateSetting == null)
            {
                // ������΁A�S���Ӑ�Ō���
                foundDeriveryDateSetting = Find(enterpriseCode, sectionCode, ALL_CUSTOMER_CODE);
                if (!SCMDataHelper.IsAvailableRecord(foundDeriveryDateSetting)) foundDeriveryDateSetting = null;
                if (foundDeriveryDateSetting == null)
                {
                    // ������΁A�S�ЂŌ���
                    foundDeriveryDateSetting = Find(enterpriseCode, ALL_SECTION_CODE, ALL_CUSTOMER_CODE);
                    if (!SCMDataHelper.IsAvailableRecord(foundDeriveryDateSetting)) foundDeriveryDateSetting = null;
                    if (foundDeriveryDateSetting == null) return string.Empty;
                }
            }

            // �ϑ��݌ɂ̏ꍇ
            if (isTrustStock)
            {
                // �ϑ��݌ɉ񓚔[���敪���ϑ��p�ɐݒ�@�̏ꍇ�i�j
                if (foundDeriveryDateSetting.EntStckAnsDeliDtDiv == 2)
                {
                    if (stockQty <= 0)
                    {
                        ansDeliDateDiv = foundDeriveryDateSetting.EntAnsDelDtWioDiv; // ADD ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                        // �݌ɐ������@�̏ꍇ�i�݌ɐ��ʂ��O�ȉ��j
                        return foundDeriveryDateSetting.EntStcAnsDelDatWiout;
                    }
                    else if ((stockQty - salesOrderCount) < 0)
                    {
                        ansDeliDateDiv = foundDeriveryDateSetting.EntAnsDelDtShoDiv; // ADD ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                        // �݌ɕs���@�̏ꍇ
                        return foundDeriveryDateSetting.EntStcAnsDelDatShort;
                    }
                    else
                    {
                        ansDeliDateDiv = foundDeriveryDateSetting.EntAnsDelDtStcDiv; // ADD ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                        // �݌ɐ��L��@�̏ꍇ
                        return foundDeriveryDateSetting.EntStckAnsDeliDate;
                    }
                }
            }

            // �D��݌ɂ̏ꍇ
            if (isPriorityStock)
            {
                // �ϑ��݌ɉ񓚔[���敪���ϑ��p�ɐݒ�@�̏ꍇ�i�j
                if (foundDeriveryDateSetting.PriStckAnsDeliDtDiv == 1)
                {
                    if (stockQty <= 0)
                    {
                        ansDeliDateDiv = foundDeriveryDateSetting.PriAnsDelDtWioDiv; // ADD ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                        // �݌ɐ������@�̏ꍇ�i�݌ɐ��ʂ��O�ȉ��j
                        return foundDeriveryDateSetting.PriStcAnsDelDatWiout;
                    }
                    else if ((stockQty - salesOrderCount) < 0)
                    {
                        ansDeliDateDiv = foundDeriveryDateSetting.PriAnsDelDtShoDiv; // ADD ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                        // �݌ɕs���@�̏ꍇ
                        return foundDeriveryDateSetting.PriStcAnsDelDatShort;
                    }
                    else
                    {
                        ansDeliDateDiv = foundDeriveryDateSetting.PriAnsDelDtStcDiv; // ADD ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                        // �݌ɐ��L��@�̏ꍇ
                        return foundDeriveryDateSetting.PriStckAnsDeliDate;
                    }
                }
            }

            // ���̑��݌ɂ̏ꍇ
            // �ϑ��݌ɉ񓚔[���敪���ϑ��p�ɐݒ�@�̏ꍇ�i�j
            if (stockQty <= 0)
            {
                ansDeliDateDiv = foundDeriveryDateSetting.AnsDelDtWioStcDiv; // ADD ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                // �݌ɐ������@�̏ꍇ�i�݌ɐ��ʂ��O�ȉ��j
                return foundDeriveryDateSetting.AnsDelDatWithoutStc;
            }
            else if ((stockQty - salesOrderCount) < 0)
            {
                ansDeliDateDiv = foundDeriveryDateSetting.AnsDelDtShoStcDiv; // ADD ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                // �݌ɕs���@�̏ꍇ
                return foundDeriveryDateSetting.AnsDelDatShortOfStc;
            }

            // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region ���\�[�X
            //// �񓚔[���̃��X�g�c�񓚒��؎����Ń\�[�g
            //SortedList<int, string> answerDelivDateList = CreateAnswerDelivDateList(foundDeriveryDateSetting, isStock);
            //// ���݂̎�������񓚔[���𔻒�
            //int now = int.Parse(DateTime.Now.ToString("HHmmss"));
            //string answerDelivDate = string.Empty;
            //bool find = false;
            //foreach (KeyValuePair<int, string> answerDelivPair in answerDelivDateList)
            //{
            //    Debug.WriteLine(answerDelivPair.Key.ToString() + " " + answerDelivPair.Value);

            //    if (answerDelivPair.Key >= now)
            //    {
            //        answerDelivDate = answerDelivPair.Value;
            //        find = true;
            //        break;
            //    }
            //}
            //if (!find && answerDelivDateList.Count > 0) answerDelivDate = answerDelivDateList.Values[0];
            #endregion
            // �񓚔[���̃��X�g�c�񓚒��؎����Ń\�[�g   string[]��2���̂� 1�ԖځF�񓚔[��  2�ԖځF�񓚔[���敪 Int16��string�ɃL���X�g�������
            SortedList<int, string[]> answerDelivDateList = CreateAnswerDelivDateList(foundDeriveryDateSetting, isStock);

            // ���݂̎�������񓚔[���𔻒�
            int now = int.Parse(DateTime.Now.ToString("HHmmss"));
            string answerDelivDate = string.Empty;
            bool find = false;
            foreach (KeyValuePair<int, string[]> answerDelivPair in answerDelivDateList)
            {
                Debug.WriteLine(answerDelivPair.Key.ToString() + " " + answerDelivPair.Value[0]);

                if (answerDelivPair.Key >= now)
                {
                    answerDelivDate = answerDelivPair.Value[0];
                    Int16.TryParse(answerDelivPair.Value[1], out ansDeliDateDiv);
                    find = true;
                    break;
                }
            }
            if (!find && answerDelivDateList.Count > 0)
            {
                answerDelivDate = answerDelivDateList.Values[0][0];
                Int16.TryParse(answerDelivDateList.Values[0][1], out ansDeliDateDiv);
            }
            // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            return answerDelivDate;
        }
        // 2012/08/30 ADD T.Yoshioka 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #region <�񓚔[��>

        /// <summary>
        /// �񓚒��؎����Ń\�[�g���ꂽ�񓚔[�����X�g�𐶐����܂��B
        /// </summary>
        /// <param name="deriveryDateSetting">SCM�[���ݒ�</param>
        /// <param name="isStock">�݌Ƀt���O</param>
        /// <returns>�񓚒��؎����Ń\�[�g���ꂽ�񓚔[�����X�g</returns>
        // 2011/01/11 >>>
        //private static SortedList<int, string> CreateAnswerDelivDateList(SCMDeliDateSt deriveryDateSetting)
        // private static SortedList<int, string> CreateAnswerDelivDateList(SCMDeliDateSt deriveryDateSetting, bool isStock) // DEL 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
        private static SortedList<int, string[]> CreateAnswerDelivDateList(SCMDeliDateSt deriveryDateSetting, bool isStock)  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
        // 2011/01/11 <<<
        {
            // SortedList<int, string> answerDelivDateList = new SortedList<int, string>(); // DEL 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
            SortedList<int, string[]> answerDelivDateList = new SortedList<int, string[]>(); // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
            {
                // 2011/01/11 >>>
                //// �񓚒��؎���1/�񓚔[��1
                //AddItem(
                //    answerDelivDateList,
                //    deriveryDateSetting.AnswerDeadTime1,
                //    deriveryDateSetting.AnswerDelivDate1
                //);
                //// �񓚒��؎���2/�񓚔[��2
                //AddItem(
                //    answerDelivDateList,
                //    deriveryDateSetting.AnswerDeadTime2,
                //    deriveryDateSetting.AnswerDelivDate2
                //);
                //// �񓚒��؎���3/�񓚔[��3
                //AddItem(
                //    answerDelivDateList,
                //    deriveryDateSetting.AnswerDeadTime3,
                //    deriveryDateSetting.AnswerDelivDate3
                //);
                //// �񓚒��؎���4/�񓚔[��4
                //AddItem(
                //    answerDelivDateList,
                //    deriveryDateSetting.AnswerDeadTime4,
                //    deriveryDateSetting.AnswerDelivDate4
                //);
                //// �񓚒��؎���5/�񓚔[��5
                //AddItem(
                //    answerDelivDateList,
                //    deriveryDateSetting.AnswerDeadTime5,
                //    deriveryDateSetting.AnswerDelivDate5
                //);
                //// �񓚒��؎���6/�񓚔[��6
                //AddItem(
                //    answerDelivDateList,
                //    deriveryDateSetting.AnswerDeadTime6,
                //    deriveryDateSetting.AnswerDelivDate6
                //);

                if (!isStock)
                {
                    // �񓚒��؎���1/�񓚔[��1
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime1,
                        deriveryDateSetting.AnswerDelivDate1
                        , deriveryDateSetting.AnsDelDtDiv1  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                    );
                    // �񓚒��؎���2/�񓚔[��2
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime2,
                        deriveryDateSetting.AnswerDelivDate2
                        , deriveryDateSetting.AnsDelDtDiv2  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                    );
                    // �񓚒��؎���3/�񓚔[��3
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime3,
                        deriveryDateSetting.AnswerDelivDate3
                        , deriveryDateSetting.AnsDelDtDiv3  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                    );
                    // �񓚒��؎���4/�񓚔[��4
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime4,
                        deriveryDateSetting.AnswerDelivDate4
                        , deriveryDateSetting.AnsDelDtDiv4  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                    );
                    // �񓚒��؎���5/�񓚔[��5
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime5,
                        deriveryDateSetting.AnswerDelivDate5
                        , deriveryDateSetting.AnsDelDtDiv5  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                    );
                    // �񓚒��؎���6/�񓚔[��6
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime6,
                        deriveryDateSetting.AnswerDelivDate6
                        , deriveryDateSetting.AnsDelDtDiv6  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                    );
                }
                else
                {
                    // �񓚒��؎���1/�񓚔[��1
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime1Stc,
                        deriveryDateSetting.AnswerDelivDate1Stc
                        , deriveryDateSetting.AnsDelDtDiv1Stc  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                    );
                    // �񓚒��؎���2/�񓚔[��2
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime2Stc,
                        deriveryDateSetting.AnswerDelivDate2Stc
                        , deriveryDateSetting.AnsDelDtDiv2Stc  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                    );
                    // �񓚒��؎���3/�񓚔[��3
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime3Stc,
                        deriveryDateSetting.AnswerDelivDate3Stc
                        , deriveryDateSetting.AnsDelDtDiv3Stc  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                    );
                    // �񓚒��؎���4/�񓚔[��4
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime4Stc,
                        deriveryDateSetting.AnswerDelivDate4Stc
                        , deriveryDateSetting.AnsDelDtDiv4Stc  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                    );
                    // �񓚒��؎���5/�񓚔[��5
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime5Stc,
                        deriveryDateSetting.AnswerDelivDate5Stc
                        , deriveryDateSetting.AnsDelDtDiv5Stc  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                    );
                    // �񓚒��؎���6/�񓚔[��6
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime6Stc,
                        deriveryDateSetting.AnswerDelivDate6Stc
                        , deriveryDateSetting.AnsDelDtDiv6Stc  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                    );
                }
                // 2011/01/11 <<<
            }
            return answerDelivDateList;
        }

        /// <summary>
        /// �񓚔[���̃��X�g�ɍ��ڂ�ǉ����܂��B
        /// </summary>
        /// <remarks>
        /// <c>SortedList</c>�̃w���p�֐�
        /// </remarks>
        /// <param name="answerDelivDateList">�񓚔[���̃��X�g</param>
        /// <param name="answerDeadTime">�񓚒��؎���</param>
        /// <param name="answerDelivDate">�񓚔[��</param>
        /// <param name="ansDeliDateDiv">�񓚔[���敪</param>
        private static void AddItem(
            // SortedList<int, string> answerDelivDateList, // DEL 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
            SortedList<int, string[]> answerDelivDateList,  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
            int answerDeadTime,
            string answerDelivDate
            , Int16 ansDeliDateDiv  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
            )
        {
            // �񓚒��؎�����0�̏ꍇ�A����
            if (answerDeadTime.Equals(0)) return;

            // ���o�^�̏ꍇ�A�񓚒��؎����Ɖ񓚔[����ǉ�
            if (!answerDelivDateList.ContainsKey(answerDeadTime))
            {
                // answerDelivDateList.Add(answerDeadTime, answerDelivDate); // DEL 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                answerDelivDateList.Add(answerDeadTime, new string[] { answerDelivDate, ansDeliDateDiv.ToString() });  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�

                return;
            }

            // �o�^�ς̏ꍇ
            // �񓚔[������̏ꍇ�A����
            if (string.IsNullOrEmpty(answerDelivDate)) return;

            // �o�^�ς݂̉񓚔[������̏ꍇ�A�ēo�^
            // if (string.IsNullOrEmpty(answerDelivDateList[answerDeadTime])) // DEL 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
            if (string.IsNullOrEmpty(answerDelivDateList[answerDeadTime][0])) // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
            {
                answerDelivDateList.Remove(answerDeadTime);
                // answerDelivDateList.Add(answerDeadTime, answerDelivDate);  // DEL 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                answerDelivDateList.Add(answerDeadTime, new string[] { answerDelivDate, ansDeliDateDiv.ToString() });  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
            }
        }

        #endregion // </�񓚔[��>
    }
}
