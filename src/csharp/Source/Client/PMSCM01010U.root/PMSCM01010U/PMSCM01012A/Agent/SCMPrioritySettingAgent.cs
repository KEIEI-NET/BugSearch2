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
// �Ǘ��ԍ�              ���C�S�� : duzg
// �� �� ��  2011/07/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              ���C�S�� : duzg
// �� �� ��  2011/08/02  �C�����e : Redmine#23307�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : gaofeng
// �� �� ��  2011/09/19  �C�����e : Redmine#25216�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : liusy
// �� �� ��  2011/09/26  �C�����e : Redmine#25492�̑Ή�
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
using System;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SCMPriorStAcs;
    using RecordType        = SCMPriorSt;

    /// <summary>
    /// SCM�D��ݒ�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public class SCMPrioritySettingAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "SCM�D��ݒ�";
        private const string CLASS_NAME = "SCMPrioritySettingAgent";    // ���O�p

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SCMPrioritySettingAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param> 
        /// <param name="priorAppliDiv">�D��K�p�敪</param>  
        /// <returns>�Y������SCM���ꉿ�i�ݒ� ���w�苒�_�Ō���0�̏ꍇ�A�S�Аݒ�ōČ������܂��B</returns>
        public RecordType Find(
            string enterpriseCode,
            string sectionCode,
            int customerCode,
            int priorAppliDiv)
        {
            #region <Guard Phrase>

            if (string.IsNullOrEmpty(enterpriseCode.Trim()) || string.IsNullOrEmpty(sectionCode.Trim()))
            {
                return new RecordType();
            }

            #endregion // </Guard Phrase>

            const string ALL_SECTION_CODE = SecInfoSetAgent.ALL_SECTION_CODE;   // �S�Аݒ�

            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatSectionCode(sectionCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RecordType foundRecord = null;
            int status = RealAccesser.ReadPCCUOE(out foundRecord, enterpriseCode, sectionCode,customerCode,priorAppliDiv);
            /*if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
                Debug.Assert(false, MY_NAME + "�}�X�^�̌��������s���܂����B");
                int sectionCodeNo = SCMEntityUtil.ConvertNumber(sectionCode.Trim());
                if (sectionCodeNo > 0)
                {
                    //modify by liusy 
                    return Find(enterpriseCode, ALL_SECTION_CODE,0,0);
                }
            }

            if (foundRecord != null && foundRecord.LogicalDeleteCode.Equals(0))
            {
                FoundRecordMap.Add(key, foundRecord);
            }
            else
            {
                int sectionCodeNo = SCMEntityUtil.ConvertNumber(sectionCode.Trim());
                if (sectionCodeNo > 0)
                {
                    // �S�Аݒ�ōČ���
                    //modify by liusy 
                    return Find(enterpriseCode, ALL_SECTION_CODE,0,0);
                }
            }*/

            return foundRecord ?? new RecordType();
        }
        
        /* --- Del 2011/08/02 duzg for Redmine#23307 --->>>
        // --- Add 2011/07/14 duzg for �����񓚂ł���i�ڂ��ϑ��݌ɕ��ȊO���\ --->>>
        /// <summary>SCM�S�̐ݒ�Ώ�</summary>
        private static SCMTtlSt _scmTtlSt = null;

        /// <summary>SCM�S�̐ݒ�Ώۂ��擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>SCM�S�̐ݒ�Ώ� </remarks>
        public static SCMTtlSt ScmTtlSt
        {
            get { return _scmTtlSt; }
            set { _scmTtlSt = value; }
        }
        // --- Add 2011/07/14 duzg for �����񓚂ł���i�ڂ��ϑ��݌ɕ��ȊO���\ ---<<<
         --- Del 2011/08/02 duzg for Redmine#23307 ---<<< */

        //modify by liusy 
        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�Y������SCM���ꉿ�i�ݒ� ���w�苒�_�Ō���0�̏ꍇ�A�S�Аݒ�ōČ������܂��B</returns>
        public RecordType Find(
            string enterpriseCode,
            string sectionCode)
        {
            #region <Guard Phrase>

            if (string.IsNullOrEmpty(enterpriseCode.Trim()) || string.IsNullOrEmpty(sectionCode.Trim()))
            {
                return new RecordType();
            }

            #endregion // </Guard Phrase>

            const string ALL_SECTION_CODE = SecInfoSetAgent.ALL_SECTION_CODE;   // �S�Аݒ�

            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatSectionCode(sectionCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RecordType foundRecord = null;
            int status = RealAccesser.Read(out foundRecord, enterpriseCode, sectionCode, 0, -1);
            if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
                Debug.Assert(false, MY_NAME + "�}�X�^�̌��������s���܂����B");
                int sectionCodeNo = SCMEntityUtil.ConvertNumber(sectionCode.Trim());
                if (sectionCodeNo > 0)
                {
                    return Find(enterpriseCode, ALL_SECTION_CODE);
                }
            }

            if (foundRecord != null && foundRecord.LogicalDeleteCode.Equals(0))
            {
                FoundRecordMap.Add(key, foundRecord);
            }
            else
            {
                int sectionCodeNo = SCMEntityUtil.ConvertNumber(sectionCode.Trim());
                if (sectionCodeNo > 0)
                {
                    // �S�Аݒ�ōČ���
                    return Find(enterpriseCode, ALL_SECTION_CODE);
                }
            }

            return foundRecord ?? new RecordType();
        }
        //modify by liusy 
        #region <�I������>

        /// <summary>
        /// �D��ݒ�R�[�h�񋓌^
        /// </summary>
        public enum PrioritySettingCd : int
        {
            /// <summary>�Ȃ�</summary>
            None = 0,
            /// <summary>�e����</summary>
            RoughRate = 1,
            /// <summary>�P��(��)</summary>
            HighUnitPrice = 2,
            /// <summary>�艿(��)</summary>
            HighListPrice = 3,
            /// <summary>�艿(��)</summary>
            LowListPrice = 4,
            /// <summary>�L�����y�[��</summary>
            Campaign = 5,
            /// <summary>�݌�</summary>
            Stock = 6
        }

        #region <�D��ݒ�R�[�h�őI��>
        /// <summary>
        /// PCCUOE�D��ݒ�őI�����܂��B
        /// </summary>
        /// <param name="prioritySetteing">SCM�D��ݒ�</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <param name="mode">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�I�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        public static IList<SCMGoodsUnitData> PCCUOESelectBySetting(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList,
            int mode
        )
        {
            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();
            //�I����
            if (mode == (int)SelectMode.On)
            {

                //���D�敪
                selectedList = PCCUOESelectByPureDiv(prioritySetteing.SelTgtPureDiv, scmGoodsUnitDataList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //�݌ɋ敪
                selectedList = PCCUOESelectByStckDiv(prioritySetteing.SelTgtStckDiv, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //�L�����y�[���敪
                selectedList = PCCUOESelectByCampDiv(prioritySetteing.SelTgtCampDiv, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //���i�敪�P
                selectedList = PCCUOESelectByPricDiv(prioritySetteing.SelTgtPricDiv1, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //���i�敪�Q
                selectedList = PCCUOESelectByPricDiv(prioritySetteing.SelTgtPricDiv2, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //���i�敪�R
                selectedList = PCCUOESelectByPricDiv(prioritySetteing.SelTgtPricDiv3, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

            }
            //��I����
            else
            {
                //���D�敪
                selectedList = PCCUOESelectByPureDiv(prioritySetteing.UnSelTgtPureDiv, scmGoodsUnitDataList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //�݌ɋ敪
                selectedList = PCCUOESelectByStckDiv(prioritySetteing.UnSelTgtStckDiv, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }


                //�L�����y�[���敪
                selectedList = PCCUOESelectByCampDiv(prioritySetteing.UnSelTgtCampDiv, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //���i�敪�P
                selectedList = PCCUOESelectByPricDiv(prioritySetteing.UnSelTgtPricDiv1, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //���i�敪�Q
                selectedList = PCCUOESelectByPricDiv(prioritySetteing.UnSelTgtPricDiv2, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //���i�敪�R
                selectedList = PCCUOESelectByPricDiv(prioritySetteing.UnSelTgtPricDiv3, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

            }
            return selectedList;
        }

        // ADD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��10.�P���v�Z�ďo�񐔉��� ---------------------------------->>>>>
        /// <summary>
        /// PCCUOE�D��ݒ�őI�����܂��B�i���D�敪�E�݌ɋ敪�̂݁j
        /// </summary>
        /// <param name="prioritySetteing">SCM�D��ݒ�</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <param name="mode">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�I�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        public static IList<SCMGoodsUnitData> PCCUOESelectBySettingForStock(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList,
            int mode
        )
        {
            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();
            //�I����
            if (mode == (int)SelectMode.On)
            {

                //���D�敪
                selectedList = PCCUOESelectByPureDiv(prioritySetteing.SelTgtPureDiv, scmGoodsUnitDataList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //�݌ɋ敪
                selectedList = PCCUOESelectByStckDiv(prioritySetteing.SelTgtStckDiv, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }
            }
            //��I����
            else
            {
                //���D�敪
                selectedList = PCCUOESelectByPureDiv(prioritySetteing.UnSelTgtPureDiv, scmGoodsUnitDataList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //�݌ɋ敪
                selectedList = PCCUOESelectByStckDiv(prioritySetteing.UnSelTgtStckDiv, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }
            }
            return selectedList;
        }
        // ADD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��10.�P���v�Z�ďo�񐔉��� ----------------------------------<<<<<

        /// <summary>
        /// PCCUOE�݌ɋ敪�̗D�攻�f
        /// </summary>
        /// <param name="StckDiv">�D��ݒ�}�X�^�݌ɋ敪</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�i�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        private static IList<SCMGoodsUnitData> PCCUOESelectByStckDiv(int StckDiv, IList<SCMGoodsUnitData> scmGoodsUnitDataList)
        {
            if (StckDiv == 0)
            {
                return scmGoodsUnitDataList;
            }
            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();

            foreach(SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
            {

                if (StckDiv == 2)                     //2:�ϑ��E�D��q�� // DEL 2011/09/19   //ADD 2011/09/26
                //if (StckDiv == 1)                     //1:�ϑ��E�D��q�� // ADD 2011/09/19 //DEL 2011/09/26
                {
                    //�ϑ��q�Ɉ����͗D��q�ɂ̏ꍇ�ASCM���t���i�A���f�[�^�̃��X�g�Ɋi�[����܂�
                    if (scmGoodsUnitData.GetStockDiv() == (int)StockDiv.PriorityWarehouse || scmGoodsUnitData.GetStockDiv() == (int)StockDiv.Trust)
                    {
                        selectedList.Add(scmGoodsUnitData);
                    }
                }
                // ----- ADD 2011/09/26 ----- >>>>>
                // ----- DEL 2011/09/19 ----- >>>>>
                else if (StckDiv == 1)                //1:�݌�
                {
                    //��݌ɂ̏ꍇ�ASCM���t���i�A���f�[�^�̃��X�g�Ɋi�[����܂�
                    if (scmGoodsUnitData.GetStockDiv() != (int)StockDiv.None)
                    {
                        selectedList.Add(scmGoodsUnitData);
                    }
                }
                // ----- DEL 2011/09/19 ----- <<<<<
                // ----- DEL 2011/09/26 ----- <<<<<
                else if (StckDiv == 3)                  //�ϑ��q�� // DEL 2011/09/19     //ADD 2011/09/26
                //else if (StckDiv == 2)                  //�ϑ��q�� // ADD 2011/09/19   //DEL 2011/09/26
                {
                    //�ϑ��q�ɂ̏ꍇ�ASCM���t���i�A���f�[�^�̃��X�g�Ɋi�[����܂�
                    if (scmGoodsUnitData.GetStockDiv() == (int)StockDiv.Trust)
                    {
                        selectedList.Add(scmGoodsUnitData);
                    }
                }
            }
            return selectedList;
 
        }
        /// <summary>
        /// PCCUOE���i�敪�̗D�攻�f
        /// </summary>
        /// <param name="SelTgtPricDiv">�D��ݒ�}�X�^���i�敪</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�i�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        private static IList<SCMGoodsUnitData> PCCUOESelectByPricDiv(int SelTgtPricDiv, IList<SCMGoodsUnitData> scmGoodsUnitDataList)
        {
            //���i�敪���ݒ�̏ꍇ
            if (SelTgtPricDiv == 0)
            {
                return scmGoodsUnitDataList;
            }
            IList<SCMGoodsUnitData> foundList = new List<SCMGoodsUnitData>();
            //1:�e����(��)��D��
            if (SelTgtPricDiv == 1)
            {
                // �e������D��
                foundList = SCMGoodsUnitData.FindHighestRoughRate(scmGoodsUnitDataList);
            }
            //2:�P��(��)��D��
            else if (SelTgtPricDiv == 2)
            {
                // �P��(��)��D��
                foundList = SCMGoodsUnitData.FindHighestUnitPrice(scmGoodsUnitDataList);
            }
            //3:�艿(��)��D��
            else if (SelTgtPricDiv == 3)
            {
                // �艿(��)��D��
                foundList = SCMGoodsUnitData.FindHighestListPrice(scmGoodsUnitDataList);
            }
            //4:�艿(��)��D��
            else if (SelTgtPricDiv == 4)
            {
                // �艿(��)��D��
                foundList = SCMGoodsUnitData.FindLowestListPrice(scmGoodsUnitDataList);
            }
            return foundList;

        }
        /// <summary>
        /// PCCUOE�L�����y�[���敪�̗D�攻�f
        /// </summary>
        /// <param name="SelTgtCampDiv">�D��ݒ�}�X�^�L�����y�[���敪</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�i�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        private static IList<SCMGoodsUnitData> PCCUOESelectByCampDiv(int SelTgtCampDiv, IList<SCMGoodsUnitData> scmGoodsUnitDataList)
        {
            //���i�敪���ݒ�̏ꍇ
            if (SelTgtCampDiv == 0)
            {
                return scmGoodsUnitDataList;
            }
            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();

            foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
            {
                //1:�L�����y�[���L
                if (SelTgtCampDiv == 1)
                {
                    if (scmGoodsUnitData.CampaignInformation.Enabled)
                    {
                        selectedList.Add(scmGoodsUnitData);
                    }
                }

            }
            return selectedList;

        }
        /// <summary>
        /// PCCUOE���D�D�攻�f
        /// </summary>
        /// <param name="SelTgtPureDiv">�D��ݒ�}�X�^���D�敪</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�i�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        private static IList<SCMGoodsUnitData> PCCUOESelectByPureDiv(int SelTgtPureDiv, IList<SCMGoodsUnitData> scmGoodsUnitDataList)
        {

            if (SelTgtPureDiv == 0)
            {
                return scmGoodsUnitDataList;
            }
            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();

            foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
            {
                //1:����
                if (SelTgtPureDiv == 1)
                {
                    if (IsPureAtOfferKubun(scmGoodsUnitData.RealGoodsUnitData))
                    {
                        selectedList.Add(scmGoodsUnitData);
                    }
                }

            }
            return selectedList;

        }
        /// <summary>
        /// �����ł��邩���f���܂��B
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>
        /// <c>true</c> :�����ł��B<br/>
        /// <c>false</c>:�����ł͂���܂���B
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">�񋟋敪�̒l���͈͊O�ł��B</exception>
        private static bool IsPureAtOfferKubun(GoodsUnitData goodsUnitData)
        {
            switch (goodsUnitData.OfferKubun)
            {
                // 2011/02/09 >>>
                //case 0: return false;   // 0:���[�U�[�o�^
                case 0: return !string.IsNullOrEmpty(goodsUnitData.FreSrchPrtPropNo.Trim());   // 0:���[�U�[�o�^
                // 2011/02/09 <<<
                case 1: return true;    // 1:�񋟏����ҏW
                case 2: return false;   // 2:�񋟗D�ǕҏW
                case 3: return true;    // 3:�񋟏���
                case 4: return false;   // 4:�񋟗D��
                case 5: return false;   // 5:TBO
                case 7: return false;   // 7:�I���W�i�����i
                default:
                    throw new ArgumentOutOfRangeException(
                        string.Format("�񋟋敪�̒l���͈͊O�ł��B(={0})", goodsUnitData.OfferKubun)
                    );
            }
        }

        /// <summary>
        /// �D��ݒ�1�őI�����܂��B
        /// </summary>
        /// <param name="prioritySetteing">SCM�D��ݒ�</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�I�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        public static IList<SCMGoodsUnitData> SelectBySetting1(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectBySetting(prioritySetteing.PrioritySettingCd1, scmGoodsUnitDataList, 1);
        }

        /// <summary>
        /// �D��ݒ�2�őI�����܂��B
        /// </summary>
        /// <param name="prioritySetteing">SCM�D��ݒ�</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�I�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        public static IList<SCMGoodsUnitData> SelectBySetting2(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectBySetting(prioritySetteing.PrioritySettingCd2, scmGoodsUnitDataList, 2);
        }

        /// <summary>
        /// �D��ݒ�3�őI�����܂��B
        /// </summary>
        /// <param name="prioritySetteing">SCM�D��ݒ�</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�I�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        public static IList<SCMGoodsUnitData> SelectBySetting3(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectBySetting(prioritySetteing.PrioritySettingCd3, scmGoodsUnitDataList, 3);
        }

        /// <summary>
        /// �D��ݒ�4�őI�����܂��B
        /// </summary>
        /// <param name="prioritySetteing">SCM�D��ݒ�</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�I�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        public static IList<SCMGoodsUnitData> SelectBySetting4(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectBySetting(prioritySetteing.PrioritySettingCd4, scmGoodsUnitDataList, 4);
        }

        /// <summary>
        /// �D��ݒ�5�őI�����܂��B
        /// </summary>
        /// <param name="prioritySetteing">SCM�D��ݒ�</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�I�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        public static IList<SCMGoodsUnitData> SelectBySetting5(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectBySetting(prioritySetteing.PrioritySettingCd5, scmGoodsUnitDataList, 5);
        }

        /// <summary>
        /// �D��ݒ�R�[�h�őI�����܂��B
        /// </summary>
        /// <param name="prioritySetteingCd">�D��ݒ�R�[�h</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <param name="priorityNo"></param>
        /// <returns>�I�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        private static IList<SCMGoodsUnitData> SelectBySetting(
            int prioritySetteingCd,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList,
            int priorityNo
        )
        {
            const string METHOD_NAME = "SelectBySetting()"; // ���O�p
            
            #region <Log>

            string msg = string.Format("�D��ݒ�{0}�őI��...", priorityNo);
            EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            #endregion // </Log>

            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();
            {
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
                {
                    #region Del For Redmine#23307
                    /* --- Del 2011/08/02 duzg for Redmine#23307 --->>>
                    // --- Add 2011/07/14 duzg for �����񓚂ł���i�ڂ��ϑ��݌ɕ��ȊO���\ --->>>
                    bool NOPrcFlg = false;
                    if (scmGoodsUnitData.GetAcptAnOdrStatus() == (int)AcptAnOdrStatus.Estimate)
                    {
                        NOPrcFlg = true;
                    }
                    else
                    {
                        if (IsCampaignSetting(prioritySetteingCd))
                        {
                            // �L�����y�[����D��
                            if (scmGoodsUnitData.CampaignInformation.Enabled)
                            {
                                #region <Log>

                                msg += Environment.NewLine + "�L�����y�[����D�悵�܂��B";
                                msg += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData);
                                EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                                #endregion // </Log>

                                selectedList.Add(scmGoodsUnitData);
                            }
                        }
                        else if (IsStockSetting(prioritySetteingCd))
                        {
                            // �݌ɂ�D��
                            if (scmGoodsUnitData.ExistsStock)
                            {
                                if (ScmTtlSt != null && ScmTtlSt.AutoAnswerDiv == 1)
                                {
                                    if (scmGoodsUnitData.GetStockDiv() == (int)StockDiv.Trust && ScmTtlSt != null && ScmTtlSt.AutoAnswerDiv == 1)
                                    {
                                        #region <Log>

                                        msg += Environment.NewLine + "�ϑ��݌ɂ݂̂�D�悵�܂��B";
                                        msg += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData);
                                        EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                                        #endregion // </Log>

                                        selectedList.Add(scmGoodsUnitData);
                                    }
                                }
                                else if (ScmTtlSt != null && ScmTtlSt.AutoAnswerDiv == 2)
                                {
                                    if (scmGoodsUnitData.GetStockDiv() == (int)StockDiv.Trust
                                        || scmGoodsUnitData.GetStockDiv() == (int)StockDiv.Customer
                                        || scmGoodsUnitData.GetStockDiv() == (int)StockDiv.PriorityWarehouse)
                                    {
                                        #region <Log>

                                        msg += Environment.NewLine + "���Ѝ݌ɂ݂̂�D�悵�܂��B";
                                        msg += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData);
                                        EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                                        #endregion // </Log>

                                        selectedList.Add(scmGoodsUnitData);
                                    }
                                }
                                else
                                {
                                    #region <Log>

                                    msg += Environment.NewLine + "�݌ɂ�D�悵�܂��B";
                                    msg += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData);
                                    EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                                    #endregion // </Log>

                                    selectedList.Add(scmGoodsUnitData);
                                }
                            }
                        }
                    }
                    if (NOPrcFlg)
                    {
                    // --- Add 2011/07/14 duzg for �����񓚂ł���i�ڂ��ϑ��݌ɕ��ȊO���\ ---<<<
                    if (IsCampaignSetting(prioritySetteingCd))
                    {
                        // �L�����y�[����D��
                        if (scmGoodsUnitData.CampaignInformation.Enabled)
                        {
                            #region <Log>

                            msg += Environment.NewLine + "�L�����y�[����D�悵�܂��B";
                            msg += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData);
                            EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                            #endregion // </Log>

                            selectedList.Add(scmGoodsUnitData);
                        }
                    }
                    else if (IsStockSetting(prioritySetteingCd))
                    {
                        // �݌ɂ�D��
                        if (scmGoodsUnitData.ExistsStock)
                        {
                            #region <Log>

                            msg += Environment.NewLine + "�݌ɂ�D�悵�܂��B";
                            msg += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData);
                            EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                            #endregion // </Log>

                            selectedList.Add(scmGoodsUnitData);
                        }
                    }
                    }// Add 2011/07/14 duzg for �����񓚂ł���i�ڂ��ϑ��݌ɕ��ȊO���\
                     --- Del 2011/08/02 duzg for Redmine#23307 ---<<<*/
                    #endregion
                    // --- Add 2011/08/02 duzg for Redmine#23307 --->>>
                    if (IsCampaignSetting(prioritySetteingCd))
                    {
                        // �L�����y�[����D��
                        if (scmGoodsUnitData.CampaignInformation.Enabled)
                        {
                            #region <Log>

                            msg += Environment.NewLine + "�L�����y�[����D�悵�܂��B";
                            msg += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData);
                            EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                            #endregion // </Log>

                            selectedList.Add(scmGoodsUnitData);
                        }
                    }
                    else if (IsStockSetting(prioritySetteingCd))
                    {
                        // �݌ɂ�D��
                        if (scmGoodsUnitData.ExistsStock)
                        {
                            #region <Log>

                            msg += Environment.NewLine + "�݌ɂ�D�悵�܂��B";
                            msg += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData);
                            EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                            #endregion // </Log>

                            selectedList.Add(scmGoodsUnitData);
                        }
                    }
                    // --- Add 2011/08/02 duzg for Redmine#23307 ---<<<
                }
            }
            return selectedList.Count.Equals(0) ? scmGoodsUnitDataList : selectedList;
        }

        /// <summary>
        /// �D��ݒ肪�L�����y�[���ł��邩���f���܂��B
        /// </summary>
        /// <param name="prioritySetteingCd">�D��ݒ�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�L�����y�[���ł��B<br/>
        /// <c>false</c>:�L�����y�[���ł͂���܂���B
        /// </returns>
        private static bool IsCampaignSetting(int prioritySetteingCd)
        {
            return prioritySetteingCd.Equals((int)PrioritySettingCd.Campaign);
        }

        /// <summary>
        /// �D��ݒ肪�݌ɂł��邩���f���܂��B
        /// </summary>
        /// <param name="prioritySetteingCd">�D��ݒ�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�݌ɂł��B<br/>
        /// <c>false</c>:�݌ɂł͂���܂���B
        /// </returns>
        private static bool IsStockSetting(int prioritySetteingCd)
        {
            return prioritySetteingCd.Equals((int)PrioritySettingCd.Stock);
        }

        #endregion // </�D��ݒ�R�[�h�őI��>

        #region <�D�承�i�ݒ�R�[�h�őI��>

        /// <summary>
        /// �D�承�i�ݒ�1�őI�����܂��B
        /// </summary>
        /// <param name="prioritySetteing">SCM�D��ݒ�</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�I�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        public static IList<SCMGoodsUnitData> SelectByPriceSetting1(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectByPriceSetting(prioritySetteing.PriorPriceSetCd1, scmGoodsUnitDataList, 1);
        }

        /// <summary>
        /// �D�承�i�ݒ�2�őI�����܂��B
        /// </summary>
        /// <param name="prioritySetteing">SCM�D��ݒ�</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�I�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        public static IList<SCMGoodsUnitData> SelectByPriceSetting2(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectByPriceSetting(prioritySetteing.PriorPriceSetCd2, scmGoodsUnitDataList, 2);
        }

        /// <summary>
        /// �D�承�i�ݒ�3�őI�����܂��B
        /// </summary>
        /// <param name="prioritySetteing">SCM�D��ݒ�</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�I�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        public static IList<SCMGoodsUnitData> SelectByPriceSetting3(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectByPriceSetting(prioritySetteing.PriorPriceSetCd3, scmGoodsUnitDataList, 3);
        }

        /// <summary>
        /// �D�承�i�ݒ�4�őI�����܂��B
        /// </summary>
        /// <param name="prioritySetteing">SCM�D��ݒ�</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�I�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        public static IList<SCMGoodsUnitData> SelectByPriceSetting4(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectByPriceSetting(prioritySetteing.PriorPriceSetCd4, scmGoodsUnitDataList, 4);
        }

        /// <summary>
        /// �D�承�i�ݒ�5�őI�����܂��B
        /// </summary>
        /// <param name="prioritySetteing">SCM�D��ݒ�</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�I�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        public static IList<SCMGoodsUnitData> SelectByPriceSetting5(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectByPriceSetting(prioritySetteing.PriorPriceSetCd5, scmGoodsUnitDataList, 5);
        }

        /// <summary>
        /// �D�承�i�ݒ�R�[�h�őI�����܂��B
        /// </summary>
        /// <param name="priorPriceSetCd">�D�承�i�ݒ�R�[�h</param>
        /// <param name="scmGoodsUnitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <param name="priorityNo"></param>
        /// <returns>�I�����ꂽSCM���t���i�A���f�[�^�̃��X�g</returns>
        private static IList<SCMGoodsUnitData> SelectByPriceSetting(
            int priorPriceSetCd,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList,
            int priorityNo
        )
        {
            const string METHOD_NAME = "SelectByPriceSetting()";    // ���O�p 

            #region <Log>

            string msg = string.Format("�D�承�i�ݒ�{0}�őI��...", priorityNo);
            EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            #endregion // </Log>

            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();
            {
                if (IsRoughRateSetting(priorPriceSetCd))
                {
                    // �e������D��
                    selectedList = SCMGoodsUnitData.FindHighestRoughRate(scmGoodsUnitDataList);

                    #region <Log>

                    msg += Environment.NewLine + "�e������D�悵�܂��B";
                    msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                    EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>
                }
                else if (IsHighUnitPriceSetting(priorPriceSetCd))
                {
                    // �P��(��)��D��
                    selectedList = SCMGoodsUnitData.FindHighestUnitPrice(scmGoodsUnitDataList);

                    #region <Log>

                    msg += Environment.NewLine + "�P��(��)��D�悵�܂��B";
                    msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                    EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>
                }
                else if (IsHighListPriceSetting(priorPriceSetCd))
                {
                    // �艿(��)��D��
                    selectedList = SCMGoodsUnitData.FindHighestListPrice(scmGoodsUnitDataList);

                    #region <Log>

                    msg += Environment.NewLine + "�艿(��)��D�悵�܂��B";
                    msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                    EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>
                }
                else if (IsLowListPriceSetting(priorPriceSetCd))
                {
                    // �艿(��)��D��
                    selectedList = SCMGoodsUnitData.FindLowestListPrice(scmGoodsUnitDataList);

                    #region <Log>

                    msg += Environment.NewLine + "�艿(��)��D�悵�܂��B";
                    msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                    EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>
                }
                else
                {
                    // ����ȊO
                    return scmGoodsUnitDataList;
                }
            }
            return selectedList.Count.Equals(0) ? scmGoodsUnitDataList : selectedList;
        }

        /// <summary>
        /// �D�承�i�ݒ肪�e�����ł��邩���f���܂��B
        /// </summary>
        /// <param name="priorPriceSetCd">�D�承�i�ݒ�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�e�����ł��B<br/>
        /// <c>false</c>:�e�����ł͂���܂���B
        /// </returns>
        private static bool IsRoughRateSetting(int priorPriceSetCd)
        {
            return priorPriceSetCd.Equals((int)PrioritySettingCd.RoughRate);
        }

        /// <summary>
        /// �D�承�i�ݒ肪�P��(��)�ł��邩���f���܂��B
        /// </summary>
        /// <param name="priorPriceSetCd">�D�承�i�ݒ�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�P��(��)�ł��B<br/>
        /// <c>false</c>:�P��(��)�ł͂���܂���B
        /// </returns>
        private static bool IsHighUnitPriceSetting(int priorPriceSetCd)
        {
            return priorPriceSetCd.Equals((int)PrioritySettingCd.HighUnitPrice);
        }

        /// <summary>
        /// �D�承�i�ݒ肪�艿(��)�ł��邩���f���܂��B
        /// </summary>
        /// <param name="priorPriceSetCd">�D�承�i�ݒ�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�艿(��)�ł��B<br/>
        /// <c>false</c>:�艿(��)�ł͂���܂���B
        /// </returns>
        private static bool IsHighListPriceSetting(int priorPriceSetCd)
        {
            return priorPriceSetCd.Equals((int)PrioritySettingCd.HighListPrice);
        }

        /// <summary>
        /// �D�承�i�ݒ肪�艿(��)�ł��邩���f���܂��B
        /// </summary>
        /// <param name="priorPriceSetCd">�D�承�i�ݒ�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�艿(��)�ł��B<br/>
        /// <c>false</c>:�艿(��)�ł͂���܂���B
        /// </returns>
        private static bool IsLowListPriceSetting(int priorPriceSetCd)
        {
            return priorPriceSetCd.Equals((int)PrioritySettingCd.LowListPrice);
        }

        #endregion // </�D�承�i�ݒ�R�[�h�őI��>

        #endregion // </�I������>
    }
}
