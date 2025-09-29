//****************************************************************************//
// �V�X�e��         : �񓚑��M����
// �v���O��������   : �񓚑��M�����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/05/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = CustomerInfoAcs;
    using RecordType        = CustomerInfo;

    /// <summary>
    /// ���Ӑ�}�X�^�̃A�N�Z�X�N���X�̑㗝�l�N���X
    /// </summary>
    public sealed class CustomerAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        /// <summary>���O�p�̖���</summary>
        private const string MY_NAME = "CustomerAgent";

        /// <summary>
        /// �I�����C����ʋ敪�񋓌^
        /// </summary>
        public enum OnlineKindDiv : int
        {
            /// <summary>0:�Ȃ�</summary>
            None = 0,
            /// <summary>10:SCM</summary>
            SCM = 10,
            /// <summary>20:TSP.NS</summary>
            TSPNS = 20,
            /// <summary>30:TSP.NS�C�����C��</summary>
            TSPNSinline = 30,
            /// <summary>40:TSP���[��</summary>
            TSPmail = 40
        }

        #region <���Ӑ���>

        /// <summary>���Ӑ���}�b�v</summary>
        private readonly IDictionary<int, CustomerInfo> _customerInfoMap = new Dictionary<int, CustomerInfo>();
        /// <summary>���Ӑ���}�b�v���擾���܂��B</summary>
        public IDictionary<int, CustomerInfo> CustomerInfoMap { get { return _customerInfoMap; } }

        /// <summary>���Ӑ�|���O���[�v�}�b�v</summary>
        private readonly IDictionary<int, List<CustRateGroup>> _customerRateGroupMap = new Dictionary<int, List<CustRateGroup>>();
        /// <summary>���Ӑ�|���O���[�v�}�b�v���擾���܂��B</summary>
        public IDictionary<int, List<CustRateGroup>> CustomerRateGroupMap { get { return _customerRateGroupMap; } }

        #endregion // </���Ӑ���>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public CustomerAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// ���Ӑ�����擾���܂��B
        /// </summary>
        /// <param name="headerRecord">SCM�󒍃f�[�^�̃��R�[�h</param>
        public void TakeCustomerInfo(ISCMOrderHeaderRecord headerRecord)
        {
            TakeCustomerInfo(headerRecord.EnterpriseCode, headerRecord.CustomerCode);
        }

        /// <summary>
        /// ���Ӑ�����擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        public void TakeCustomerInfo(
            string enterpriseCode,
            int customerCode
        )
        {
            #region <Guard Phrase>

            if (CustomerInfoMap.ContainsKey(customerCode))
            {
                return;
            }

            #endregion // </Guard Phrase>

            // ���Ӑ���
            CustomerInfoMap.Add(
                customerCode,
                FindCustomerInfo(enterpriseCode, customerCode)
            );

            // ���Ӑ�|���O���[�v
            CustomerRateGroupMap.Add(
                customerCode,
                FindCustomerRateGroup(enterpriseCode, customerCode)
            );
        }

        #region <����>

        /// <summary>
        /// ���Ӑ�����������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ���</returns>
        private CustomerInfo FindCustomerInfo(
            string enterpriseCode,
            int customerCode
        )
        {
            const string METHOD = "FindCustomerInfo";
            const string INDENT = "\t    ";

            CustomerInfo customerInfo = null;
            {
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "CustomerInfoAcs.ReadDBData()���ďo���c");
                int status = RealAccesser.ReadDBData(
                    enterpriseCode,
                    customerCode,
                    out customerInfo
                );
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "CustomerInfoAcs.ReadDBData()���ďo����");
            }
            return customerInfo ?? new CustomerInfo();
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v�����������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ�|���O���[�v���</returns>
        private List<CustRateGroup> FindCustomerRateGroup(
            string enterpriseCode,
            int customerCode
        )
        {
            List<CustRateGroup> foundCustomerRateGroupList = new List<CustRateGroup>();
            {
                if (!customerCode.Equals(0))
                {
                    CustRateGroupAcs customerRateGroupAcs = new CustRateGroupAcs();

                    ArrayList custRateGroupList = null;
                    customerRateGroupAcs.Search(
                        out custRateGroupList,
                        enterpriseCode,
                        customerCode,
                        ConstantManagement.LogicalMode.GetData0
                    );
                    if ((custRateGroupList != null) && (custRateGroupList.Count > 0))
                    {
                        foundCustomerRateGroupList = new List<CustRateGroup>((CustRateGroup[])custRateGroupList.ToArray(typeof(CustRateGroup)));
                    }
                }
            }
            return foundCustomerRateGroupList;
        }

        #endregion // </����>

        /// <summary>
        /// �������Œ[�������R�[�h���擾���܂��B
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>�������Œ[�������R�[�h</returns>
        public int GetSalesFractionProcCdOfTax(
            int customerCode,
            GoodsUnitData goodsUnitData
        )
        {
            return RealAccesser.GetSalesFractionProcCd(
                goodsUnitData.EnterpriseCode,
                customerCode,
                CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            );
        }

        /// <summary>
        /// ����P���[�������R�[�h���擾���܂��B
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>����P���[�������R�[�h</returns>
        public int GetSalesFractionProcCdOfUnit(
            int customerCode,
            GoodsUnitData goodsUnitData
        )
        {
            return RealAccesser.GetSalesFractionProcCd(
                goodsUnitData.EnterpriseCode,
                customerCode,
                CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd
            );
        }
    }
}
