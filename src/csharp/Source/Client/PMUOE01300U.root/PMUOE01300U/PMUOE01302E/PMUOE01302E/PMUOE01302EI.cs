//****************************************************************************//
// �V�X�e��         : �����d����M����
// �v���O��������   : �����d����M����Model
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/11/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// UOE������̃w���p�N���X
    /// </summary>
    public class UOESupplierHelper
    {
        #region <�{��/>

        /// <summary>�{����UOE������</summary>
        private readonly UOESupplier _realUOESupplier;
        /// <summary>
        /// �{����UOE��������擾���܂��B
        /// </summary>
        public UOESupplier RealUOESupplier { get { return _realUOESupplier; } }

        #endregion  // <�{��/>

        #region <��ƃv���t�B�[��/>

        /// <summary>��ƃv���t�B�[��</summary>
        private readonly CodeNamePair<string> _enterpriseProfile;
        /// <summary>
        /// ��ƃv���t�B�[�����擾���܂��B
        /// </summary>
        /// <value>��ƃR�[�h����і���</value>
        public CodeNamePair<string> EnterpriseProfile { get { return _enterpriseProfile; } }

        #endregion  // <��ƃv���t�B�[��/>

        #region <�˗���/>

        /// <summary>�˗��҃v���t�B�[��</summary>
        private readonly CodeNamePair<string> _agentProfile;
        /// <summary>
        /// �˗��҃v���t�B�[�����擾���܂��B
        /// </summary>
        /// <value>�]�ƈ��R�[�h����і���</value>
        public CodeNamePair<string> AgentProfile { get { return _agentProfile; } }

        /// <summary>
        /// �]�ƈ��̃v���t�B�[���𐶐����܂��B
        /// </summary>
        /// <param name="enterpriseCide">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�]�ƈ��R�[�h����і���</returns>
        private static CodeNamePair<string> CreateEmployeeProfile(
            string enterpriseCide,
            string employeeCode
        )
        {
            ArrayList searchedEmployeeList = null;
            {
                EmployeeAcs employeeAcs = new EmployeeAcs();
                {
                    ArrayList searchedEmployeeDetailedList = null;
                    int status = employeeAcs.Search(
                        out searchedEmployeeList,
                        out searchedEmployeeDetailedList,
                        enterpriseCide
                    );
                    if (searchedEmployeeList == null || searchedEmployeeList.Count.Equals(0))
                    {
                        return new CodeNamePair<string>(string.Empty, string.Empty);
                    }
                }
            }

            Employee foundEmployee = null;
            {
                foreach (Employee searchedEmployee in searchedEmployeeList)
                {
                    if (searchedEmployee.EmployeeCode.Trim().Equals(employeeCode.Trim()))
                    {
                        foundEmployee = searchedEmployee;
                        break;
                    }
                }
            }
            if (foundEmployee != null)
            {
                return new CodeNamePair<string>(employeeCode, foundEmployee.Name);
            }
            else
            {
                return new CodeNamePair<string>(string.Empty, string.Empty);
            }
        }

        #endregion  // <�˗���/>

        #region <�d���̐�����/>

        /// <summary>�d���̐�����</summary>
        private SendingStockReceptionTelegramEssence _telegramEssence;
        /// <summary>
        /// �d���̐����҂��擾���܂��B
        /// </summary>
        public SendingStockReceptionTelegramEssence TelegramEssence { get { return _telegramEssence; } }

        #endregion  // <�d���̐�����/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realUOESupplier">�{����UOE������</param>
        /// <param name="enterpriseProfile">��ƃv���t�B�[��</param>
        public UOESupplierHelper(
            UOESupplier realUOESupplier,
            CodeNamePair<string> enterpriseProfile
        )
        {
            // �{����UOE������
            _realUOESupplier = realUOESupplier;
            {
                // ID�ԍ��ɒl���ݒ肳��Ă���ƁA�d�����M�����ɂāAID�����������s����
                // �������d����M�ł́AID���������͍s��Ȃ�
                _realUOESupplier.UOEIDNum = string.Empty;
            }

            // ��ƃv���t�B�[��
            _enterpriseProfile = enterpriseProfile;

            // �˗���
            if (string.IsNullOrEmpty(_realUOESupplier.EmployeeCode.Trim()))
            {
                _agentProfile = new CodeNamePair<string>(string.Empty, string.Empty);
            }
            else
            {
                _agentProfile = CreateEmployeeProfile(
                    _enterpriseProfile.Code,
                    _realUOESupplier.EmployeeCode.Trim()
                );
            }

            // �d���̐�����
            _telegramEssence = CreateTelegramEssence();
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// �ڑ��o�[�W�����敪��"�V"�ł��邩���肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�V�ł���<br/>
        /// <c>false</c>:�V�ł͂Ȃ�
        /// </returns>
        public bool IsNewVersion()
        {
            const int NEW_VERSION = 1;  // 0:���^1:�V
            return RealUOESupplier.ConnectVersionDiv.Equals(NEW_VERSION);
        }

        /// <summary>
        /// �d����M�������s���邩���肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�s����B<br/>
        /// <c>false</c>:�s���Ȃ��B
        /// </returns>
        public virtual bool CanReceiveStoking()
        {
            return UOESupplierUtil.HasStockSlipData(RealUOESupplier.StockSlipDtRecvDiv);
        }

        /// <summary>
        /// �d���̐����҂𐶐����܂��B
        /// </summary>
        /// <value>�d���̐�����</value>
        protected virtual SendingStockReceptionTelegramEssence CreateTelegramEssence()
        {
            return new SendingStockReceptionTelegramEssence(
                RealUOESupplier.CommAssemblyId,
                RealUOESupplier.UOESupplierCd,
                RealUOESupplier.UOEHostCode,
                RealUOESupplier.UOEConnectPassword,
                this
            );
        }

        /// <summary>
        /// �����d����M������UOE�������ʂ��擾���܂��B
        /// </summary>
        /// <value>�����d����M������UOE��������</value>
        public virtual EnumUoeConst.ReceivingUOESupplier ReceivingUOESupplierType
        {
            get { return EnumUoeConst.ReceivingUOESupplier.SPK; }
        }

        /// <summary>
        /// �i�Ԍ����p�̃��[�J�[�R�[�h�����𐶐����܂��B
        /// </summary>
        /// <returns>�i�Ԍ����p�̃��[�J�[�R�[�h����</returns>
        public List<int> CreateSearchingMakerCodeListForGoodsAcs()
        {
            List<int> searchingMakerCodeList = new List<int>();
            {
                const int DISABLE_MAKER_CODE = 0;

                int enabledOdrMakerCd = DISABLE_MAKER_CODE;
                for (int i = 0; i < 6; i++)
                {
                    switch (i)
                    {
                        case 0:
                            enabledOdrMakerCd = RealUOESupplier.EnableOdrMakerCd1;
                            break;
                        case 1:
                            enabledOdrMakerCd = RealUOESupplier.EnableOdrMakerCd2;
                            break;
                        case 2:
                            enabledOdrMakerCd = RealUOESupplier.EnableOdrMakerCd3;
                            break;
                        case 3:
                            enabledOdrMakerCd = RealUOESupplier.EnableOdrMakerCd4;
                            break;
                        case 4:
                            enabledOdrMakerCd = RealUOESupplier.EnableOdrMakerCd5;
                            break;
                        case 5:
                            enabledOdrMakerCd = RealUOESupplier.EnableOdrMakerCd6;
                            break;
                    }
                    if (enabledOdrMakerCd.Equals(DISABLE_MAKER_CODE)) continue;

                    searchingMakerCodeList.Add(enabledOdrMakerCd);
                }
            }
            return searchingMakerCodeList;
        }
    }

    #region <SPK(���̑�)/>

    /// <summary>
    /// UOE������FSPK(���̑�)�̑����N���X
    /// </summary>
    public sealed class UOESPKDecorator : UOESupplierHelper
    {
        #region <UOE������/>

        /// <summary>UOE������</summary>
        private readonly UOESupplierHelper _uoeSupplier;
        /// <summary>
        /// UOE��������擾���܂��B
        /// </summary>
        /// <value>UOE������</value>
        private UOESupplierHelper UOESupplier { get { return _uoeSupplier; } }

        #endregion  // <UOE������/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        public UOESPKDecorator(UOESupplierHelper uoeSupplier)
        : base(uoeSupplier.RealUOESupplier, uoeSupplier.EnterpriseProfile)
        {
            _uoeSupplier = uoeSupplier;
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// �d����M�������s���邩���肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�s����B<br/>
        /// <c>false</c>:�s���Ȃ��B
        /// </returns>
        /// <see cref="UOESupplierHelper"/>
        public override bool CanReceiveStoking()
        {
            // �d����M�敪�F���� && ��M�L���敪�F����M�\
            return base.CanReceiveStoking()
                    &&
                RealUOESupplier.ReceiveCondition.Equals((int)UOESupplierUtil.ReceiveConditionDiv.CanSendAndReceive);
        }

        #endregion  // <Override/>
    }

    #endregion  // <SPK(���̑�)/>

    #region <�����Y��/>

    /// <summary>
    /// UOE������F�����Y�Ƃ̑����N���X
    /// </summary>
    public sealed class UOEMeijiDecorator : UOESupplierHelper
    {
        #region <UOE������/>

        /// <summary>UOE������</summary>
        private readonly UOESupplierHelper _uoeSupplier;
        /// <summary>
        /// UOE��������擾���܂��B
        /// </summary>
        /// <value>UOE������</value>
        private UOESupplierHelper UOESupplier { get { return _uoeSupplier; } }

        #endregion  // <UOE������/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        public UOEMeijiDecorator(UOESupplierHelper uoeSupplier)
        : base(uoeSupplier.RealUOESupplier, uoeSupplier.EnterpriseProfile)
        {
            _uoeSupplier = uoeSupplier;
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// �d����M�������s���邩���肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�s����B<br/>
        /// <c>false</c>:�s���Ȃ��B
        /// </returns>
        /// <see cref="UOESupplierHelper"/>
        public override bool CanReceiveStoking()
        {
            // �d����M�敪�F���� && ��M�L���敪�F���M�̂�
            return base.CanReceiveStoking()
                    &&
                RealUOESupplier.ReceiveCondition.Equals((int)UOESupplierUtil.ReceiveConditionDiv.SendOnly);
        }

        /// <summary>
        /// �d���̐����҂𐶐����܂��B
        /// </summary>
        /// <returns>�d���̐�����</returns>
        /// <see cref="UOESupplierHelper"/>
        protected override SendingStockReceptionTelegramEssence CreateTelegramEssence()
        {
            return new SendingStockReceptionTelegramEssence(
                RealUOESupplier.CommAssemblyId,
                RealUOESupplier.UOESupplierCd,
                " ",    // �����Y�Ƃ̏ꍇ�A�z�X�g�R�[�h�̓X�y�[�X
                " ",    // �����Y�Ƃ̏ꍇ�A�p�X���[�h�̓X�y�[�X
                this,
                true    // �����Y�Ƃ̏ꍇ�A�Ǔd���͑��M���Ȃ�
            );
        }

        /// <summary>
        /// �����d����M�����̎�ʂ��擾���܂��B
        /// </summary>
        /// <value>�����d����M�����̎��</value>
        /// <see cref="UOESupplierHelper"/>
        public override EnumUoeConst.ReceivingUOESupplier ReceivingUOESupplierType
        {
            get { return EnumUoeConst.ReceivingUOESupplier.Meiji; }
        }

        #endregion  // <Override/>
    }

    #endregion  // <�����Y��/>

    /// <summary>
    /// UOE�����惆�[�e�B���e�B
    /// </summary>
    public static class UOESupplierUtil
    {
        /// <summary>
        /// ��M�󋵁i��M�L���敪�j�񋓑�
        /// </summary>
        public enum ReceiveConditionDiv : int
        {
            /// <summary>����M�\</summary>
            CanSendAndReceive = 0,
            /// <summary>���M�̂�</summary>
            SendOnly = 1
        }

        /// <summary>
        /// UOE������̃w���p�𐶐����܂��B
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        /// <param name="enterpriseProfile">��ƃv���t�B�[���i�R�[�h�Ɩ��́j</param>
        /// <returns>UOE������̃w���p</returns>
        public static UOESupplierHelper CreateHelper(
            UOESupplier uoeSupplier,
            CodeNamePair<string> enterpriseProfile
        )
        {
            // ����1�F�d����M�敪���L��Ȃ�ASPK(���̑�)�������Y��
            if (!HasStockSlipData(uoeSupplier.StockSlipDtRecvDiv))
            {
                return new UOESupplierHelper(uoeSupplier, enterpriseProfile);
            }

            // ����2�F��M�L���敪
            switch (uoeSupplier.ReceiveCondition)
            {
                case (int)ReceiveConditionDiv.CanSendAndReceive:// 0:����M�\
                    return new UOESPKDecorator(new UOESupplierHelper(uoeSupplier, enterpriseProfile));  // SPK(���̑�)

                case (int)ReceiveConditionDiv.SendOnly:         // 1:���M�̂�
                    return new UOEMeijiDecorator(new UOESupplierHelper(uoeSupplier, enterpriseProfile));// �����Y��

                default:
                    return new UOESupplierHelper(uoeSupplier, enterpriseProfile);
            }
        }

        /// <summary>
        /// �d����M�敪���L�肩���肵�܂��B
        /// </summary>
        /// <param name="stockSlipDtRecvDiv">�d����M�敪</param>
        /// <returns>
        /// <c>true</c> :�L��<br/>
        /// <c>false</c>:����ȊO
        /// </returns>
        public static bool HasStockSlipData(int stockSlipDtRecvDiv)
        {
            const int HAD = 1;  // 1:�L��
            return stockSlipDtRecvDiv.Equals(HAD);
        }
    }
}
