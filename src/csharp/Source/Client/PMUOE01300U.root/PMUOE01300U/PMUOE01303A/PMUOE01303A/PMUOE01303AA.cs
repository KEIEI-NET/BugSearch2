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
//TODO:���|�I�v�V�����Ȃ��t���O�i�f�o�b�O�p�j�������[�X���ɂ͖���`��Ԃɂ��邱�ƁI
//#define HASNOT_STOCKING_PAYMENT_OPTION

using System;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���O�C���S���҃N���X
    /// </summary>
    public sealed class LoginWorker
    {
        #region <��ƃv���t�B�[��/>

        /// <summary>��ƃv���t�B�[��</summary>
        private readonly CodeNamePair<string> _enterpriseProfile;
        /// <summary>
        /// ��ƃv���t�B�[�����擾���܂��B
        /// </summary>
        /// <value>��ƃv���t�B�[��</value>
        public CodeNamePair<string> EnterpriseProfile { get { return _enterpriseProfile; } }

        #endregion  // <��ƃv���t�B�[��/>

        #region <�]�ƈ����/>

        /// <summary>�]�ƈ����</summary>
        private readonly Employee _profile;
        /// <summary>
        /// �]�ƈ������擾���܂��B
        /// </summary>
        public Employee Profile { get { return _profile; } }

        /// <summary>�]�ƈ����̏ڍ�</summary>
        private EmployeeDtl _detail;
        /// <summary>
        /// �]�ƈ����̏ڍׂ��擾���܂��B
        /// </summary>
        /// <value>�]�ƈ����̏ڍ�</value>
        public EmployeeDtl Detail
        {
            get
            {
                if (_detail == null)
                {
                    _detail = GetEmployeeDtl(EnterpriseProfile.Code, Profile.EmployeeCode);
                }
                return _detail;
            }
        }
         
        /// <summary>
        /// �]�ƈ����̏ڍׂ��擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�]�ƈ����̏ڍ�</returns>
        private static EmployeeDtl GetEmployeeDtl(
            string enterpriseCode,
            string employeeCode
        )
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            {
                Employee    employee    = null;
                EmployeeDtl employeeDtl = null;
                int status = employeeAcs.Read(
                    out employee,
                    out employeeDtl,
                    enterpriseCode,
                    employeeCode
                );
                if (employeeDtl == null)
                {
                    employeeDtl = new EmployeeDtl();
                }
                return employeeDtl;
            }
        }

        #endregion  // <�]�ƈ����/>

        #region <���|�I�v�V����/>

        /// <summary>���|�I�v�V��������t���O</summary>
        private readonly bool _hasStockingPaymentOption;
        /// <summary>
        /// ���|�I�v�V��������t���O���擾���܂��B
        /// </summary>
        /// <value>
        /// <c>true </c>:���|�I�v�V��������<br/>
        /// <c>false</c>:���|�I�v�V�����Ȃ�
        /// </value>
        public bool HasStockingPaymentOption
        {
            get
            {
            #if HASNOT_STOCKING_PAYMENT_OPTION
                return false;
            #else
                return _hasStockingPaymentOption;
            #endif
            }
        }

        /// <summary>
        /// ���|�Ǘ����肩���肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :���|�Ǘ�����<br/>
        /// <c>false</c>:���|�Ǘ��Ȃ�
        /// </returns>
        private static bool HasStockingPayment()
        {
            PurchaseStatus purchaseStatus = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment
            );
            return purchaseStatus >= PurchaseStatus.Contract;
        }

        #endregion  // <���|�I�v�V����/>

        #region <�[���ԍ�/>

        /// <summary>�[���ԍ�</summary>
        private readonly int _cashRegisterNo;
        /// <summary>
        /// �[���ԍ����擾���܂��B
        /// </summary>
        /// <value>�[���ԍ�</value>
        public int CashRegisterNo { get { return _cashRegisterNo; } }

        /// <summary>
        /// �[���ԍ����擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns></returns>
        private static int GetCashRegisterNo(string enterpriseCode)
        {
            int cashRegisterNo = 0;

            PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
            {
                int status = posTerminalMgAcs.GetCashRegisterNo(out cashRegisterNo, enterpriseCode);
                if (!status.Equals((int)Result.RemoteStatus.Normal))
                {
                    cashRegisterNo = 0;
                }
            }

            return cashRegisterNo;
        }

        #endregion  // <�[���ԍ�/>

        #region <���_�ݒ�/>

        /// <summary>���_�ݒ�</summary>
        private SecInfoSet _sectionInfo;
        /// <summary>
        /// ���_�ݒ���擾���܂��B
        /// </summary>
        /// <value>���_�ݒ�</value>
        public SecInfoSet SectionInfo
        {
            get
            {
                if (_sectionInfo == null)
                {
                    _sectionInfo = GetSectionInfo(EnterpriseProfile.Code, SectionProfile.Code);
                }
                return _sectionInfo;
            }
        }

        /// <summary>
        /// ���_�ݒ�}�X�^���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_�ݒ�}�X�^���</returns>
        private static SecInfoSet GetSectionInfo(
            string enterpriseCode,
            string sectionCode
        )
        {
            ArrayList secInfoSetList = new ArrayList();

            SecInfoSetAcs sectionInfoAcs = new SecInfoSetAcs();
            int status = sectionInfoAcs.Search(out secInfoSetList, enterpriseCode);
            if (!status.Equals((int)Result.RemoteStatus.Normal) || secInfoSetList == null)
            {
                return new SecInfoSet();
            }

            foreach (SecInfoSet sectionInfo in secInfoSetList)
            {
                if (sectionInfo.SectionCode.Trim().Equals(sectionCode.Trim()))
                {
                    return sectionInfo;
                }
            }

            return new SecInfoSet();
        }

        #endregion  // <���_�ݒ�/>

        #region <UOE���Аݒ�/>

        /// <summary>
        /// �������ɍX�V�敪�񋓑�
        /// </summary>
        public enum OroshishoDistEnterDiv : int
        {
            /// <summary>����</summary>
            Auto = 0,
            /// <summary>�蓮</summary>
            Manual = 1
        }

        /// <summary>
        /// �������_�ݒ�敪�񋓑�
        /// </summary>
        public enum OroshishoDistSectionSetDiv : int
        {
            /// <summary>�d���}�X�^</summary>
            SupplierMaster = 0,
            /// <summary>�����f�[�^</summary>
            OrderData = 1,
            /// <summary>���Ѓ}�X�^</summary>
            UOESettingMaster = 2
        }

        /// <summary>UOE���Аݒ�</summary>
        private UOESetting _uoeSetting;
        /// <summary>
        /// UOE���Аݒ���擾���܂��B
        /// </summary>
        public UOESetting UOESetting
        {
            get
            {
                if (_uoeSetting == null)
                {
                    _uoeSetting = GetUOESetting(EnterpriseProfile.Code, SectionProfile.Code);
                }
                return _uoeSetting;
            }
        }

        /// <summary>
        /// UOE���Аݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>UOE���Аݒ�}�X�^���</returns>
        private static UOESetting GetUOESetting(
            string enterpriseCode,
            string sectionCode
        )
        {
            UOESetting uoeSetting = null;

            // UOE���Аݒ�}�X�^������
            UOESettingAcs uoeSettingAcs = new UOESettingAcs();
            int status = uoeSettingAcs.Read(out uoeSetting, enterpriseCode, sectionCode);
            if (!status.Equals((int)Result.RemoteStatus.Normal))
            {
                return null;
            }

            return uoeSetting;
        }

        #endregion  // <UOE���Аݒ�/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public LoginWorker()
        {
            // ��ƃv���t�B�[��
            _enterpriseProfile = new CodeNamePair<string>(
                LoginInfoAcquisition.EnterpriseCode.Trim(),
                LoginInfoAcquisition.EnterpriseName.Trim()
            );

            // �]�ƈ����
            _profile = LoginInfoAcquisition.Employee.Clone();

            // ���|�I�v�V����
            _hasStockingPaymentOption = HasStockingPayment();

            // �[���ԍ�
            _cashRegisterNo = GetCashRegisterNo(LoginInfoAcquisition.EnterpriseCode.Trim());
        }

        #endregion  // <Constructor/>

        #region <���_�v���t�B�[��/>

        /// <summary>
        /// ���_�v���t�B�[�����擾���܂��B
        /// </summary>
        /// <value>���_�R�[�h����ы��_����</value>
        public CodeNamePair<string> SectionProfile
        {
            get
            {
                return new CodeNamePair<string>(
                    Profile.BelongSectionCode.Trim(),
                    Profile.BelongSectionName.Trim()
                );
            }
        }

        #endregion  // <���_�v���t�B�[��/>
    }
}
