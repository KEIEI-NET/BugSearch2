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

using System;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Agent
{
    using LoginWorkerAcs = SingletonPolicy<LoginWorker>;

    #region <�d���}�X�^/>

    /// <summary>
    /// �d���}�X�^DB�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public sealed class SupplierDBAgent
    {
        #region <�d���}�X�^���R�[�h�}�b�v/>

        /// <summary>�d���}�X�^���R�[�h�̃}�b�v</summary>
        /// <remarks>�L�[�F�d����R�[�h("000000")</remarks>
        private readonly IDictionary<string, Supplier> _codedSupplierMap = new Dictionary<string, Supplier>();
        /// <summary>
        /// �d���}�X�^���R�[�h�̃}�b�v���擾���܂��B
        /// </summary>
        /// <value>�d���}�X�^���R�[�h�̃}�b�v</value>
        private IDictionary<string, Supplier> CodedSupplierMap { get { return _codedSupplierMap; } }

        /// <summary>
        /// �L�[���擾���܂��B
        /// </summary>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <returns>�d����R�[�h("000000")</returns>
        private static string GetKey(int supplierCode)
        {
            return supplierCode.ToString("000000");
        }

        #endregion  // <�d���}�X�^���R�[�h�}�b�v/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SupplierDBAgent()
        {
            SupplierAcs supplierAcs = new SupplierAcs();
            {
                ArrayList retList = null;
                int status = supplierAcs.SearchAll(
                    out retList,
                    LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code
                );
                if (status.Equals((int)Result.RemoteStatus.Normal))
                {
                    foreach (Supplier supplier in retList)
                    {
                        if (supplier.LogicalDeleteCode.Equals(0))
                        {
                            string key = GetKey(supplier.SupplierCd);
                            if (!CodedSupplierMap.ContainsKey(key))
                            {
                                CodedSupplierMap.Add(key, supplier);
                            }
                        }
                    }
                }
            }
        }

        #endregion  // <Constructor/>

        #region <����/>

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        /// <returns>
        /// �������ꂽ�d����}�X�^���R�[�h
        /// �i����������Ȃ������ꍇ�A<c>null</c>��Ԃ��܂��j
        /// </returns>
        public Supplier Find(UOESupplierHelper uoeSupplier)
        {
            return CodedSupplierMap[GetKey(uoeSupplier.RealUOESupplier.UOESupplierCd)];
        }

        #endregion  // <����/>
    }

    #endregion  // <�d���}�X�^/>

    #region <�S�̏����ݒ�}�X�^/>

    /// <summary>
    /// �S�̏����ݒ�}�X�^DB�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public sealed class AllDefSetDBAgent
    {
        #region <�S�̏����ݒ�}�X�^���R�[�h/>

        /// <summary>�S�̏����ݒ�}�X�^�̃��R�[�h</summary>
        private readonly AllDefSet _allDefSet;
        /// <summary>
        /// �S�̏����ݒ�}�X�^�̃��R�[�h���擾���܂��B
        /// </summary>
        /// <value>�S�̏����ݒ�}�X�^�̃��R�[�h</value>
        public AllDefSet AllDefSet { get { return _allDefSet; } }

        #endregion  // <�S�̏����ݒ�}�X�^���R�[�h/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public AllDefSetDBAgent()
        {
            _allDefSet = GetAllDefSet(
                LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code,
                LoginWorkerAcs.Instance.Policy.SectionProfile.Code
            );
        }

        /// <summary>
        /// �S�̏����l�ݒ�̃��R�[�h���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�S�̏����l���̃��R�[�h</returns>
        private static AllDefSet GetAllDefSet(
            string enterpriseCode,
            string sectionCode
        )
        {
            AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
            {
                AllDefSet allDefSet = null;
                int status = allDefSetAcs.Read(out allDefSet, enterpriseCode, sectionCode);
                if (allDefSet == null)
                {
                    allDefSet = new AllDefSet();
                }
                return allDefSet;
            }
        }

        #endregion  // <Constructor/>
    }

    #endregion  // <�S�̏����ݒ�}�X�^/>

    #region <�ŗ��ݒ�}�X�^/>

    /// <summary>
    /// �ŗ��ݒ�}�X�^DB�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public sealed class TaxRateSetDBAgent
    {
        #region <�ŗ��ݒ���/>

        /// <summary>�ŗ��ݒ���</summary>
        private readonly TaxRateSet _taxRateSetInfo;
        /// <summary>
        /// �ŗ��ݒ�����擾���܂��B
        /// </summary>
        /// <value>�ŗ��ݒ���</value>
        private TaxRateSet TaxRateSetInfo { get { return _taxRateSetInfo; } }

        #endregion  // <�ŗ��ݒ���/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public TaxRateSetDBAgent()
        {
            _taxRateSetInfo = GetTaxRateSet(LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code);
        }

        /// <summary>
        /// �ŗ��ݒ�����擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�ŗ��ݒ���</returns>
        private static TaxRateSet GetTaxRateSet(string enterpriseCode)
        {
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            {
                TaxRateSet taxRateSet = null;
                int status = taxRateSetAcs.Read(out taxRateSet, enterpriseCode, 0);
                if (taxRateSet == null)
                {
                    taxRateSet = new TaxRateSet();
                }
                return taxRateSet;
            }
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// ���̐ŗ����擾���܂��B
        /// </summary>
        /// <value>���̐ŗ�</value>
        public double TaxRateOfNow
        {
            get
            {
                return GetTaxRate(TaxRateSetInfo, DateTime.Now);
            }
        }

        /// <summary>
        /// �ŗ����擾���܂��B
        /// </summary>
        /// <param name="taxRateSet">�ŗ��ݒ���</param>
        /// <param name="targetDate">�ŗ��K�p��</param>
        /// <returns>TtlAmntDspRateDivCd</returns>
        private static double GetTaxRate(
            TaxRateSet taxRateSet,
            DateTime targetDate
        )
        {
            return TaxRateSetAcs.GetTaxRate(taxRateSet, targetDate);
        }
    }

    #endregion  // <�ŗ��ݒ�}�X�^/>

    #region <UOE�K�C�h���̃}�X�^/>

    /// <summary>
    /// UOE�K�C�h���̃}�X�^
    /// </summary>
    public sealed class UOEGuideNameDBAgent
    {
        #region <UOE�K�C�h���̃R���N�V����/>

        /// <summary>UOE�K�C�h���̃��R�[�h���X�g�̃}�b�v</summary>
        /// <remarks>�L�[�FUOE������R�[�h</remarks>
        private readonly IDictionary<int, IList<UOEGuideName>> _uoeGuideNameMap = new Dictionary<int, IList<UOEGuideName>>();
        /// <summary>
        /// UOE�K�C�h���̃��R�[�h���X�g�̃}�b�v���擾���܂��B
        /// </summary>
        /// <remarks>�L�[�FUOE������R�[�h</remarks>
        /// <value>UOE�K�C�h���̃��R�[�h���X�g�̃}�b�v</value>
        private IDictionary<int, IList<UOEGuideName>> UoeGuideNameMap
        {
            get { return _uoeGuideNameMap; }
        }

        #endregion  // <UOE�K�C�h���̃R���N�V����/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public UOEGuideNameDBAgent()
        {
            UOEGuideNameAcs uoeGuideNameAcs = new UOEGuideNameAcs();
            {
                ArrayList uoeGuideNameList          = new ArrayList();
                UOEGuideName searchingUOEGuideName  = new UOEGuideName();
                {
                    searchingUOEGuideName.EnterpriseCode    = LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code;
                    searchingUOEGuideName.SectionCode       = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
                    searchingUOEGuideName.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;
                    searchingUOEGuideName.UOEGuideDivCd     = 2;    // 2:�[�i�敪
                }
                int status = uoeGuideNameAcs.Search(out uoeGuideNameList, searchingUOEGuideName);
                if (uoeGuideNameList == null || uoeGuideNameList.Count.Equals(0)) return;
                
                foreach (UOEGuideName uoeGuideName in uoeGuideNameList)
                {
                    if (!UoeGuideNameMap.ContainsKey(uoeGuideName.UOESupplierCd))
                    {
                        UoeGuideNameMap.Add(uoeGuideName.UOESupplierCd, new List<UOEGuideName>());
                    }
                    UoeGuideNameMap[uoeGuideName.UOESupplierCd].Add(uoeGuideName);
                }
            }
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// UOE�K�C�h���̃��R�[�h��Ԃ��܂��B
        /// </summary>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <param name="uoeGuideCode">UOE�K�C�h�R�[�h�iUOE�����f�[�^�̔[�i�敪�j</param>
        /// <returns>
        /// �Y������UOE�K�C�h���̃��R�[�h
        /// �i�Y��������̂��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��j
        /// </returns>
        public UOEGuideName Find(
            int uoeSupplierCd,
            string uoeGuideCode
        )
        {
            if (UoeGuideNameMap.ContainsKey(uoeSupplierCd))
            {
                foreach (UOEGuideName uoeGuideName in UoeGuideNameMap[uoeSupplierCd])
                {
                    if (uoeGuideName.UOEGuideCode.Trim().Equals(uoeGuideCode.Trim()))
                    {
                        return uoeGuideName;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }

    #endregion  // <UOE�K�C�h���̃}�X�^/>

    #region <���[�J�[�}�X�^/>

    /// <summary>
    /// ���[�J�[�}�X�^DB�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public sealed class MakerMasterDBAgent
    {
        #region <�{���̃A�N�Z�T/>

        /// <summary></summary>
        private readonly MakerSetAcs _realReader = new MakerSetAcs();
        /// <summary>
        /// 
        /// </summary>
        private MakerSetAcs RealReader { get { return _realReader; } }

        #endregion  // <�{���̃A�N�Z�T/>

        #region <���[�J�[�Z�b�g�̃R���N�V����/>

        /// <summary>���[�J�[�Z�b�g�̃}�b�v�i�L�[�F���[�J�[�R�[�h�j</summary>
        private readonly IDictionary<int, MakerSet> _makerSetMap = new Dictionary<int, MakerSet>();
        /// <summary>
        /// ���[�J�[�Z�b�g�̃}�b�v���擾���܂��B
        /// </summary>
        /// <remarks>�L�[�F���[�J�[�R�[�h</remarks>
        private IDictionary<int, MakerSet> MakerSetMap { get { return _makerSetMap; } }

        #endregion  // <���[�J�[�Z�b�g�̃R���N�V����/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public MakerMasterDBAgent() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// ���[�J�[���������܂��B
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>�Y�����郁�[�J�[�i�Y�����[�J�[�������ꍇ�A<c>null</c>��Ԃ��܂��j</returns>
        public MakerSet Find(int makerCode)
        {
            if (MakerSetMap.ContainsKey(makerCode)) return MakerSetMap[makerCode];

            // 1�p����
            ArrayList searchedRecordList = null;
            // 3�p����
            MakerPrintWork searchingCondition = new MakerPrintWork();
            {
                searchingCondition.GoodsMakerCdSt = makerCode;
                searchingCondition.GoodsMakerCdEd = makerCode;
                searchingCondition.LogicalDeleteCode = 0;
            }

            int status = RealReader.SearchAll(
                out searchedRecordList,
                LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code,
                searchingCondition
            );
            if (!status.Equals((int)Result.RemoteStatus.Normal))
            {
                return null;
            }
            if (searchedRecordList == null || searchedRecordList.Count.Equals(0))
            {
                return null;
            }

            foreach (MakerSet makerSet in searchedRecordList)
            {
                if (!MakerSetMap.ContainsKey(makerCode))
                {
                    MakerSetMap.Add(makerCode, makerSet);
                }
            }

            return MakerSetMap[makerCode];
        }
    }

    #endregion  // <���[�J�[�}�X�^/>
}
