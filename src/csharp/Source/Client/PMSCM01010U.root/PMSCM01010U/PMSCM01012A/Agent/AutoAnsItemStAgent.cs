//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/10/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/11/20  �C�����e : 2012/12/12�z�M�\��V�X�e���e�X�g��Q��30�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/11/20  �C�����e : 2012/12/12�z�M�\��V�X�e���e�X�g��Q��47�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/11/30  �C�����e : 2012/12/12�z�M�\��V�X�e���e�X�g��Q��91�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/02/05  �C�����e : SCM�d�|�ꗗ��10627�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g��
// �� �� ��  2014/05/09  �C�����e : ���x���P�t�F�[�Y�Q��11,��12 �i���^�C�~���O�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/06/06  �C�����e : ���i�ۏ؉�Redmine#1581�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11600006-00 �쐬�S�� : �c����
// �C �� ��  2020/05/15  �C�����e : PMKOBETSU-3932 BLP��Q�i���O�����j
//                                : �����R�[�h�̃��O�o�͋������s��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType = AutoAnsItemStAcs;
    using RecordType = List<AutoAnsItemSt>;

    /// <summary>
    /// �����񓚕i�ڐݒ�}�X�^�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public sealed class AutoAnsItemStAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "AutoAnsItemStAgent";    // ���O�p
        private const string LinkBreak = "\r\n";  //���s
        /// <summary>
        /// �����񓚋敪�񋓌^
        /// </summary>
        public enum AutoAnswerDiv : int
        {
            /// <summary>0:���Ȃ�(�S�Ď蓮��)</summary>
            None = 0,
            /// <summary>1:����(�S�Ď�����)</summary>
            All = 1,
            /// <summary>2:����(�D�揇��)</summary>
            Priority = 2
        }

        /// <summary>
        /// �����񓚋敪�̖��̂��擾���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <returns></returns>
        public static string GetAutoAnswerDivName(AutoAnsItemSt autoAnsItemSt)
        {
            if (autoAnsItemSt == null) return string.Empty;

            switch (autoAnsItemSt.AutoAnswerDiv)
            {
                case (int)AutoAnswerDiv.None:
                    return "���Ȃ�(�S�Ď蓮��)";
                case (int)AutoAnswerDiv.All:
                    return "����(�S�Ď�����)";
                case (int)AutoAnswerDiv.Priority:
                    return "����(�D�揇��)";
                default:
                    return string.Empty;
            }
        }

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        // UPD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� ----------------------------------->>>>>
        //public AutoAnsItemStAgent() { }
        public AutoAnsItemStAgent() : base() { }
        // UPD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� -----------------------------------<<<<<

        #endregion // </Constructor>

        /// <summary>
        /// �����񓚕i�ڐݒ���擾���܂��B
        /// </summary>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>��������(�����񓚕i�ڐݒ�}�X�^�̃��R�[�h���X�g)</returns>
        public RecordType Search(List<GoodsUnitData> goodsUnitDataList, int customerCode)
        {
            // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� ----------------------------------->>>>>
            string key = goodsUnitDataList[0].EnterpriseCode.Trim() + goodsUnitDataList[0].SectionCode.Trim() + customerCode.ToString().Trim();
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }
            // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� -----------------------------------<<<<<
            // 1�p����
            AutoAnsItemStOrder searchingCondition = new AutoAnsItemStOrder();
            {
                // ��ƃR�[�h
                searchingCondition.EnterpriseCode = goodsUnitDataList[0].EnterpriseCode;

                // ���_�R�[�h
                searchingCondition.SectionCode = goodsUnitDataList[0].SectionCode;

                // ���Ӑ�R�[�h
                searchingCondition.St_CustomerCode = customerCode;
                searchingCondition.Ed_CustomerCode = customerCode;

                // ���i�����ރR�[�h
                searchingCondition.St_GoodsMGroup = 0;
                searchingCondition.Ed_GoodsMGroup = int.MaxValue;

                // BL���i�R�[�h
                searchingCondition.St_BLGoodsCode = 0;
                searchingCondition.Ed_BLGoodsCode = int.MaxValue;

                // ���i���[�J�[�R�[�h
                searchingCondition.St_GoodsMakerCd = 0;
                searchingCondition.Ed_GoodsMakerCd = int.MaxValue;

                // BL�O���[�v�R�[�h
                searchingCondition.St_BLGroupCode = 0;
                searchingCondition.Ed_BLGroupCode = int.MaxValue;
            }

            // 2�p����
            List<AutoAnsItemSt> searchedList = null;

            // 3�p����
            string msg = string.Empty;

            // ����
            RealAccesser.EnterpriseCode = goodsUnitDataList[0].EnterpriseCode;
            RealAccesser.SectionCode = goodsUnitDataList[0].SectionCode;
            EasyLogger.Write(MY_NAME, "Search", "�����@�J�n" + "�p�����[�^�F" + GetOrderSearchCondition(searchingCondition));  // ADD 2020/05/15 �c���� PMKOBETSU-3932 BLP��Q�i���O�����j
            int status = RealAccesser.SearchAll(searchingCondition, out searchedList, out msg);
            if (searchedList == null && customerCode > 0)
            {
                // ���Ӑ�R�[�h�Ō������Ă����ꍇ�A���_�R�[�h�ōČ���
                searchingCondition.St_CustomerCode = 0;
                searchingCondition.Ed_CustomerCode = 0;
                searchingCondition.SectionCode = goodsUnitDataList[0].SectionCode;
                status = RealAccesser.Search(searchingCondition, out searchedList, out msg);
            }
            EasyLogger.Write(MY_NAME, "Search", "�����@����");  // ADD 2020/05/15 �c���� PMKOBETSU-3932 BLP��Q�i���O�����j
            // TODO:�S�������ʂ��_���v
            // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� ----------------------------------->>>>>
            FoundRecordMap.Add(key, searchedList ?? new List<AutoAnsItemSt>());
            // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� -----------------------------------<<<<<

            return searchedList ?? new List<AutoAnsItemSt>();
        }


        /// <summary>
        /// �����񓚕i�ڐݒ���擾���܂��B
        /// </summary>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^���X�g</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>��������(�����񓚕i�ڐݒ�}�X�^�̃��R�[�h���X�g)</returns>
        public RecordType Search(IList<SCMGoodsUnitData> scmGoodsUnitDataList, int customerCode)
        {
            // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� ----------------------------------->>>>>
            string key = scmGoodsUnitDataList[0].RealGoodsUnitData.EnterpriseCode + scmGoodsUnitDataList[0].RealGoodsUnitData.SectionCode.Trim() + customerCode.ToString();
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }
            // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� -----------------------------------<<<<<

            // 1�p����
            AutoAnsItemStOrder searchingCondition = new AutoAnsItemStOrder();
            {
                // ��ƃR�[�h
                searchingCondition.EnterpriseCode = scmGoodsUnitDataList[0].RealGoodsUnitData.EnterpriseCode;

                // ���_�R�[�h
                searchingCondition.SectionCode = scmGoodsUnitDataList[0].RealGoodsUnitData.SectionCode;

                // ���Ӑ�R�[�h
                searchingCondition.St_CustomerCode = customerCode;
                searchingCondition.Ed_CustomerCode = customerCode;

                // ���i�����ރR�[�h
                searchingCondition.St_GoodsMGroup = 0;
                searchingCondition.Ed_GoodsMGroup = int.MaxValue;

                // BL���i�R�[�h
                searchingCondition.St_BLGoodsCode = 0;
                searchingCondition.Ed_BLGoodsCode = int.MaxValue;

                // ���i���[�J�[�R�[�h
                searchingCondition.St_GoodsMakerCd = 0;
                searchingCondition.Ed_GoodsMakerCd = int.MaxValue;

                // BL�O���[�v�R�[�h
                searchingCondition.St_BLGroupCode = 0;
                searchingCondition.Ed_BLGroupCode = int.MaxValue;
            }

            // 2�p����
            List<AutoAnsItemSt> searchedList = null;

            // 3�p����
            string msg = string.Empty;

            // ����
            RealAccesser.EnterpriseCode = scmGoodsUnitDataList[0].RealGoodsUnitData.EnterpriseCode;
            RealAccesser.SectionCode = scmGoodsUnitDataList[0].RealGoodsUnitData.SectionCode;
            int status = RealAccesser.SearchAll(searchingCondition, out searchedList, out msg);
            if (searchedList == null && customerCode > 0)
            {
                // ���Ӑ�R�[�h�Ō������Ă����ꍇ�A���_�R�[�h�ōČ���
                searchingCondition.St_CustomerCode = 0;
                searchingCondition.Ed_CustomerCode = 0;
                searchingCondition.SectionCode = scmGoodsUnitDataList[0].RealGoodsUnitData.SectionCode;
                status = RealAccesser.Search(searchingCondition, out searchedList, out msg);
            }

            // TODO:�S�������ʂ��_���v
            // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� ----------------------------------->>>>>
            FoundRecordMap.Add(key, searchedList ?? new List<AutoAnsItemSt>());
            // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� -----------------------------------<<<<<

            return searchedList ?? new List<AutoAnsItemSt>();
        }

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="foundAutoAnsItemStList">�����񓚕i�ڐݒ胊�X�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>��������(�����񓚕i�ڐݒ�)</returns>
        public AutoAnsItemSt Find(
            List<AutoAnsItemSt> foundAutoAnsItemStList,
            GoodsUnitData goodsUnitData,
            int customerCode
        )
        {
            const string METHOD_NAME = "Find(List<AutoAnsItemSt>, GoodsUnitData, int)";  // ���O�p

            // ��������
            AutoAnsItemSt retAutoAnsItemSt = new AutoAnsItemSt();

            // �ꊇ�������ʂ��D�揇�ʂɍ��킹�Č������ʂ𒊏o
            if (customerCode > 0)
            {
                #region  �D�揇��1:���Ӑ�{�����ށ{BL�R�[�h�{���[�J�[

                retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                    delegate(AutoAnsItemSt AutoAnsItemSt)
                    {
                        return IsPriority1(AutoAnsItemSt, goodsUnitData, customerCode);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "�D�揇��1:���Ӑ�(={0})�{������(={1})�{BL�R�[�h(={2})�{���[�J�[(={3}) �Ō�������܂����B",
                        customerCode,
                        goodsUnitData.GoodsMGroup,
                        goodsUnitData.BLGoodsCode,
                        goodsUnitData.GoodsMakerCd
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion

                // ADD 2012/11/30 2012/12/12�z�M�\��V�X�e���e�X�g��Q��91�Ή� ------------------------>>>>>
                #region  �D�揇��2:���Ӑ�{�����ށi���ʁj�{BL�R�[�h�{���[�J�[

                retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                    delegate(AutoAnsItemSt AutoAnsItemSt)
                    {
                        return IsPriority2(AutoAnsItemSt, goodsUnitData, customerCode);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "�D�揇��1:���Ӑ�(={0})�{������(={1})�{BL�R�[�h(={2})�{���[�J�[(={3}) �Ō�������܂����B",
                        customerCode,
                        goodsUnitData.GoodsMGroup,
                        goodsUnitData.BLGoodsCode,
                        goodsUnitData.GoodsMakerCd
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion
                // ADD 2012/11/30 2012/12/12�z�M�\��V�X�e���e�X�g��Q��91�Ή� ------------------------<<<<<

                // DEL 2012/11/20 2012/12/12�z�M�\��V�X�e���e�X�g��Q��47�Ή� ------------------------>>>>>
                #region �폜
                //#region �D�揇��2:���Ӑ�{�����ށ{BL�R�[�h

                //retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                //    delegate(AutoAnsItemSt AutoAnsItemSt)
                //    {
                //        return IsPriority2(AutoAnsItemSt, goodsUnitData, customerCode);
                //    }
                //);
                //if (retAutoAnsItemSt != null)
                //{
                //    #region <Log>

                //    string msg = string.Format(
                //        "�D�揇��2:���Ӑ�(={0})�{������(={1})�{BL�R�[�h(={2}) �Ō�������܂����B",
                //        customerCode,
                //        goodsUnitData.GoodsMGroup,
                //        goodsUnitData.BLGoodsCode
                //    );
                //    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                //    #endregion // </Log>

                //    return retAutoAnsItemSt;
                //}

                //#endregion
                #endregion //�폜
                // DEL 2012/11/20 2012/12/12�z�M�\��V�X�e���e�X�g��Q��47�Ή� ------------------------<<<<<

                #region �D�揇��3:���Ӑ�{�����ށ{���[�J�[

                retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                    delegate(AutoAnsItemSt AutoAnsItemSt)
                    {
                        return IsPriority3(AutoAnsItemSt, goodsUnitData, customerCode);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "�D�揇��3:���Ӑ�(={0})�{������(={1}) �Ō�������܂����B",
                        customerCode,
                        goodsUnitData.GoodsMGroup
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion

                #region �D�揇��4:���Ӑ�{���[�J�[

                retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                    delegate(AutoAnsItemSt AutoAnsItemSt)
                    {
                        return IsPriority4(AutoAnsItemSt, goodsUnitData, customerCode);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "�D�揇��4:���Ӑ�(={0}) �Ō�������܂����B",
                        customerCode
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion
            }
            if (!string.IsNullOrEmpty(goodsUnitData.SectionCode.Trim()))
            {
                #region �D�揇��5:���_�{�����ށ{BL�R�[�h�{���[�J�[

                retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                    delegate(AutoAnsItemSt AutoAnsItemSt)
                    {
                        return IsPriority5(AutoAnsItemSt, goodsUnitData);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "�D�揇��5:���_(={0})�{������(={1})�{BL�R�[�h(={2})�{���[�J�[(={3}) �Ō�������܂����B",
                        goodsUnitData.SectionCode,
                        goodsUnitData.GoodsMGroup,
                        goodsUnitData.BLGoodsCode,
                        goodsUnitData.GoodsMakerCd
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion

                // ADD 2012/11/30 2012/12/12�z�M�\��V�X�e���e�X�g��Q��91�Ή� ------------------------>>>>>
                #region �D�揇��6:���_�{�����ށi���ʁj�{BL�R�[�h�{���[�J�[

                retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                    delegate(AutoAnsItemSt AutoAnsItemSt)
                    {
                        return IsPriority6(AutoAnsItemSt, goodsUnitData);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "�D�揇��5:���_(={0})�{������(={1})�{BL�R�[�h(={2})�{���[�J�[(={3}) �Ō�������܂����B",
                        goodsUnitData.SectionCode,
                        goodsUnitData.GoodsMGroup,
                        goodsUnitData.BLGoodsCode,
                        goodsUnitData.GoodsMakerCd
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion
                // ADD 2012/11/30 2012/12/12�z�M�\��V�X�e���e�X�g��Q��91�Ή� ------------------------<<<<<

                // DEL 2012/11/20 2012/12/12�z�M�\��V�X�e���e�X�g��Q��47�Ή� ------------------------>>>>>
                #region �폜
                //#region �D�揇��6:���_�{�����ށ{BL�R�[�h

                //retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                //    delegate(AutoAnsItemSt AutoAnsItemSt)
                //    {
                //        return IsPriority6(AutoAnsItemSt, goodsUnitData);
                //    }
                //);
                //if (retAutoAnsItemSt != null)
                //{
                //    #region <Log>

                //    string msg = string.Format(
                //        "�D�揇��6:���_(={0})�{������(={1})�{BL�R�[�h(={2}) �Ō�������܂����B",
                //        goodsUnitData.SectionCode,
                //        goodsUnitData.GoodsMGroup,
                //        goodsUnitData.BLGoodsCode
                //    );
                //    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                //    #endregion // </Log>

                //    return retAutoAnsItemSt;
                //}

                //#endregion
                #endregion
                // DEL 2012/11/20 2012/12/12�z�M�\��V�X�e���e�X�g��Q��47�Ή� ------------------------<<<<<

                #region �D�揇��7:���_�{�����ށ{���[�J�[

                retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                    delegate(AutoAnsItemSt AutoAnsItemSt)
                    {
                        return IsPriority7(AutoAnsItemSt, goodsUnitData);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "�D�揇��7:���_(={0})�{������(={1}) �Ō�������܂����B",
                        goodsUnitData.SectionCode,
                        goodsUnitData.GoodsMGroup
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion

                #region �D�揇��8:���_�{���[�J�[

                retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                    delegate(AutoAnsItemSt AutoAnsItemSt)
                    {
                        return IsPriority8(AutoAnsItemSt, goodsUnitData);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "�D�揇��8:���_(={0}) �Ō�������܂����B",
                        goodsUnitData.SectionCode
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion
            }
            else
            {
                retAutoAnsItemSt = null;
                return retAutoAnsItemSt;
            }

            int sectionCode = int.Parse(goodsUnitData.SectionCode.Trim());
            if (sectionCode > 0)
            {
                // UPD 2012/11/20 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��30�Ή� -------------------------->>>>> 
                //goodsUnitData.SectionCode = "00";    // �S�ЂōČ���
                //return Find(foundAutoAnsItemStList, goodsUnitData, customerCode);
                GoodsUnitData retryGoodsUnitData = new GoodsUnitData();
                retryGoodsUnitData = goodsUnitData.Clone();
                retryGoodsUnitData.SectionCode = "00"; //�S�ЂōČ���
                return Find(foundAutoAnsItemStList, retryGoodsUnitData, customerCode);
                // UPD 2012/11/20 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��30�Ή� --------------------------<<<<< 
            }

            return retAutoAnsItemSt;
        }

        #region �D�揇�ʂ̔��f

        /// <summary>
        /// �D�揇��1:���Ӑ�{�����ށ{BL�R�[�h�{���[�J�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�D�揇��1�ł��B<br/>
        /// <c>false</c>:�D�揇��1�ł͂���܂���B
        /// </returns>
        private static bool IsPriority1(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData, int customerCode)
        {
            if ( autoAnsItemSt.PrmSetDtlNo2 == 0 || 
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
            {
                // UPD 2012/11/20 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��47�Ή� --------------------->>>>>
                //return (
                //    autoAnsItemSt.CustomerCode == customerCode
                //        &&
                //    autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
                //        &&
                //    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                //        &&
                //    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                //);
                // UPD 2012/11/30 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��91�Ή� --------------------->>>>>
                //return (
                //    (autoAnsItemSt.CustomerCode == customerCode
                //        &&
                //    autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
                //        &&
                //    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                //        &&
                //    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd) ||

                //    (autoAnsItemSt.CustomerCode == customerCode
                //        &&
                //    autoAnsItemSt.GoodsMGroup == 0
                //        &&
                //    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                //        &&
                //    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd)

                //);
                return (
                    autoAnsItemSt.CustomerCode == customerCode
                        &&
                    autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                );
                // UPD 2012/11/30 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��91�Ή� ---------------------<<<<<
                // UPD 2012/11/20 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��47�Ή� ---------------------<<<<<
            }
            return false;
        }

        // DEL 2012/11/20 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��47�Ή� --------------------->>>>>
        #region �폜
        ///// <summary>
        ///// �D�揇��2:���Ӑ�{�����ށ{BL�R�[�h�ł��邩���f���܂��B
        ///// </summary>
        ///// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        ///// <param name="goodsUnitData">���i�A���f�[�^</param>
        ///// <param name="customerCode">���Ӑ�R�[�h</param>
        ///// <returns>
        ///// <c>true</c> :�D�揇��2�ł��B<br/>
        ///// <c>false</c>:�D�揇��2�ł͂���܂���B
        ///// </returns>
        //private static bool IsPriority2(AutoAnsItemSt autoAnsItemSt,  GoodsUnitData goodsUnitData, int customerCode)
        //{
        //    if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
        //        (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
        //    {
        //        return (
        //            autoAnsItemSt.CustomerCode == customerCode
        //                &&
        //            autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
        //                &&
        //            autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
        //                &&
        //            autoAnsItemSt.GoodsMakerCd == 0
        //        );
        //    }
        //    return false;
        //}
        #endregion
        // DEL 2012/11/20 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��47�Ή� ---------------------<<<<<

        // ADD 2012/11/30 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��91�Ή� --------------------->>>>>
        /// <summary>
        /// �D�揇��2:���Ӑ�{�����ށi���ʁj�{BL�R�[�h�{���[�J�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�D�揇��2�ł��B<br/>
        /// <c>false</c>:�D�揇��2�ł͂���܂���B
        /// </returns>
        private static bool IsPriority2(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData, int customerCode)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == customerCode
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd

                );
            }
            return false;
        }
        // ADD 2012/11/30 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��91�Ή� ---------------------<<<<<

        /// <summary>
        /// �D�揇��3:���Ӑ�{�����ށ{���[�J�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�D�揇��3�ł��B<br/>
        /// <c>false</c>:�D�揇��3�ł͂���܂���B
        /// </returns>
        private static bool IsPriority3(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData, int customerCode)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == customerCode
                        &&
                    autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// �D�揇��4:���Ӑ�{���[�J�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�D�揇��4�ł��B<br/>
        /// <c>false</c>:�D�揇��4�ł͂���܂���B
        /// </returns>
        private static bool IsPriority4(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData, int customerCode)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == customerCode
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// �D�揇��5:���_�{�����ށ{BL�R�[�h�{���[�J�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>
        /// <c>true</c> :�D�揇��5�ł��B<br/>
        /// <c>false</c>:�D�揇��5�ł͂���܂���B
        /// </returns>
        private static bool IsPriority5(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
            {
                // UPD 2012/11/20 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��47�Ή� --------------------->>>>>
                //return (
                //    autoAnsItemSt.SectionCode.Trim() == goodsUnitData.SectionCode.Trim()
                //        &&
                //    autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
                //        &&
                //    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                //        &&
                //    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                //);
                // UPD 2012/11/30 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��91�Ή� --------------------->>>>>
                //return (
                //    (autoAnsItemSt.SectionCode.Trim() == goodsUnitData.SectionCode.Trim()
                //        &&
                //    autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
                //        &&
                //    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                //        &&
                //    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd) ||

                //    (autoAnsItemSt.SectionCode.Trim() == goodsUnitData.SectionCode.Trim()
                //        &&
                //    autoAnsItemSt.GoodsMGroup == 0
                //        &&
                //    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                //        &&
                //    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd)

                //);
                return (
                    autoAnsItemSt.SectionCode.Trim() == goodsUnitData.SectionCode.Trim()
                        &&
                    autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                );
                // UPD 2012/11/30 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��91�Ή� ---------------------<<<<<
                // UPD 2012/11/20 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��47�Ή� ---------------------<<<<<
            }
            return false;
        }

        // DEL 2012/11/20 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��47�Ή� --------------------->>>>>
        #region �폜
        ///// <summary>
        ///// �D�揇��6:���_�{�����ށ{BL�R�[�h�ł��邩���f���܂��B
        ///// </summary>
        ///// <param name="AutoAnsItemSt">�����񓚕i�ڐݒ�</param>
        ///// <param name="AutoAnsItemStOrder">�����񓚕i�ڐݒ����</param>
        ///// <returns>
        ///// <c>true</c> :�D�揇��6�ł��B<br/>
        ///// <c>false</c>:�D�揇��6�ł͂���܂���B
        ///// </returns>
        //private static bool IsPriority6(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData)
        //{
        //    if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
        //        (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
        //    {
        //        return (
        //            autoAnsItemSt.SectionCode.Trim() == goodsUnitData.SectionCode.Trim()
        //                &&
        //            autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
        //                &&
        //            autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
        //                &&
        //            autoAnsItemSt.GoodsMakerCd == 0
        //        );
        //    }
        //    return false;
        //}
        #endregion
        // DEL 2012/11/20 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��47�Ή� ---------------------<<<<<

        // ADD 2012/11/30 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��91�Ή� --------------------->>>>>
        /// <summary>
        /// �D�揇��6:���_�{�����ށi���ʁj�{BL�R�[�h�{���[�J�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>
        /// <c>true</c> :�D�揇��6�ł��B<br/>
        /// <c>false</c>:�D�揇��6�ł͂���܂���B
        /// </returns>
        private static bool IsPriority6(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == goodsUnitData.SectionCode.Trim()
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd

                );
            }
            return false;
        }
        // ADD 2012/11/30 2012/12/12�z�M�\�� �V�X�e���e�X�g��Q��91�Ή� ---------------------<<<<<

        /// <summary>
        /// �D�揇��7:���_�{�����ނł��邩���f���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>
        /// <c>true</c> :�D�揇��7�ł��B<br/>
        /// <c>false</c>:�D�揇��7�ł͂���܂���B
        /// </returns>
        private static bool IsPriority7(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == goodsUnitData.SectionCode.Trim()
                        &&
                    autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// �D�揇��8:���_�ł��邩���f���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>
        /// <c>true</c> :�D�揇��8�ł��B<br/>
        /// <c>false</c>:�D�揇��8�ł͂���܂���B
        /// </returns>
        private static bool IsPriority8(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == goodsUnitData.SectionCode.Trim()
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                );
            }
            return false;
        }

        #endregion // �D�揇�ʂ̔��f

        // ADD 2014/06/06 ���i�ۏ؉�Redmine#1581�Ή� --------------------------------------------------------->>>>>
        /// <summary>
        /// �����񓚕i�ڐݒ�L���b�V�����X�g���N���A���܂��B
        /// </summary>
        /// <returns></returns> 
        public void Clear()
        {
            if (FoundRecordMap != null && FoundRecordMap.Count != 0)
            {
                FoundRecordMap.Clear();
            }
            return;
        }
        // ADD 2014/06/06 ���i�ۏ؉�Redmine#1581�Ή� ---------------------------------------------------------<<<<<

        // ADD 2014/05/09 ���x���P�t�F�[�Y�Q��11,��12 �g��  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �����񓚕i�ڐݒ���擾���܂��B
        /// </summary>
        /// <param name="epCd">��ƃR�[�h</param>
        /// <param name="secCd">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>�����񓚕i�ڐݒ胊�X�g</returns>
        public RecordType Search(string epCd, string secCd, int customerCode)
        {
            string key = epCd.Trim() + secCd.Trim() + customerCode.ToString().Trim();
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            // 1�p����
            AutoAnsItemStOrder searchingCondition = new AutoAnsItemStOrder();
            {
                // ��ƃR�[�h
                searchingCondition.EnterpriseCode = epCd;

                // ���_�R�[�h
                searchingCondition.SectionCode = secCd;

                // ���Ӑ�R�[�h
                searchingCondition.St_CustomerCode = customerCode;
                searchingCondition.Ed_CustomerCode = customerCode;

                // ���i�����ރR�[�h
                searchingCondition.St_GoodsMGroup = 0;
                searchingCondition.Ed_GoodsMGroup = int.MaxValue;

                // BL���i�R�[�h
                searchingCondition.St_BLGoodsCode = 0;
                searchingCondition.Ed_BLGoodsCode = int.MaxValue;

                // ���i���[�J�[�R�[�h
                searchingCondition.St_GoodsMakerCd = 0;
                searchingCondition.Ed_GoodsMakerCd = int.MaxValue;

                // BL�O���[�v�R�[�h
                searchingCondition.St_BLGroupCode = 0;
                searchingCondition.Ed_BLGroupCode = int.MaxValue;
            }

            // 2�p����
            List<AutoAnsItemSt> searchedList = null;

            // 3�p����
            string msg = string.Empty;

            // ����
            RealAccesser.EnterpriseCode = epCd;
            RealAccesser.SectionCode = secCd;
            int status = RealAccesser.SearchAll(searchingCondition, out searchedList, out msg);
            if (searchedList == null && customerCode > 0)
            {
                // ���Ӑ�R�[�h�Ō������Ă����ꍇ�A���_�R�[�h�ōČ���
                searchingCondition.St_CustomerCode = 0;
                searchingCondition.Ed_CustomerCode = 0;
                searchingCondition.SectionCode = secCd;
                status = RealAccesser.Search(searchingCondition, out searchedList, out msg);
            }

            FoundRecordMap.Add(key, searchedList ?? new List<AutoAnsItemSt>());

            return searchedList ?? new List<AutoAnsItemSt>();
        }

        // ADD 2014/05/09 ���x���P�t�F�[�Y�Q��11,��12 �g��  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2020/05/15 �c���� PMKOBETSU-3932 BLP��Q�i���O�����j --------->>>>>
        /// <summary>
        /// �����񓚕i�ڐݒ茟�����������񐶐�
        /// </summary>
        /// <param name="searchingCondition">��������</param>
        /// <returns>��������������</returns>
        /// <remarks>
        /// <br>Note       : �����񓚕i�ڐݒ茟�����������񐶐��������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2020/05/15</br>
        /// </remarks>
        public string GetOrderSearchCondition(AutoAnsItemStOrder searchingCondition)
        {
            string carString = string.Empty;
            try
            {
                carString = LinkBreak + "EnterpriseCode:" + searchingCondition.EnterpriseCode.ToString() + LinkBreak
                     + "St_BLGoodsCode:" + searchingCondition.St_BLGoodsCode.ToString() + LinkBreak
                     + "Ed_BLGoodsCode:" + searchingCondition.Ed_BLGoodsCode.ToString() + LinkBreak
                     + "St_BLGroupCode:" + searchingCondition.St_BLGroupCode.ToString() + LinkBreak
                     + "Ed_BLGroupCode" + searchingCondition.Ed_BLGroupCode.ToString() + LinkBreak
                     + "St_CustomerCode:" + searchingCondition.St_CustomerCode.ToString() + LinkBreak
                     + "Ed_CustomerCode:" + searchingCondition.Ed_CustomerCode.ToString();
            }
            catch (Exception ex)
            {
                carString = LinkBreak + "��������O������" + LinkBreak + ex.ToString();
            }
            return carString;
        }
        // ADD 2020/05/15 �c���� PMKOBETSU-3932 BLP��Q�i���O�����j ---------<<<<<
    }
}
