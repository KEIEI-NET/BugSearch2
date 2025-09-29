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
// �� �� ��  2009/06/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517�@�Ė� �x�� 
// �� �� ��  2010/07/07  �C�����e : �݌ɏ��i���v���z(�Ŕ�)���Z�b�g����Ă��Ȃ��s��̏C��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using SCMTotalSettingServer = SingletonInstance<SCMTotalSettingAgent>;  // SCM�S�̐ݒ�}�X�^

    /// <summary>
    /// SCM�`�[�f�[�^�̐����N���X
    /// </summary>
    public abstract class SCMSlipDataFactory
    {
        #region <SCM�󒍃f�[�^>

        /// <summary>SCM�󒍃f�[�^�̃��R�[�h</summary>
        private readonly ISCMOrderHeaderRecord _scmHeaderRecord;
        /// <summary>SCM�󒍃f�[�^�̃��R�[�h���擾���܂��B</summary>
        protected ISCMOrderHeaderRecord SCMHeaderRecord { get { return _scmHeaderRecord; } }

        #endregion // </SCM�󒍃f�[�^>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="scmHeaderRecord">SCM�󒍃f�[�^�̃��R�[�h</param>
        /// <param name="topPriorityIsSCMTotalSetting">SCM�S�̐ݒ���ŗD�悷��t���O</param>
        protected SCMSlipDataFactory(
            ISCMOrderHeaderRecord scmHeaderRecord,
            bool topPriorityIsSCMTotalSetting
        )
        {
            _scmHeaderRecord = scmHeaderRecord;
            _topPriorityIsSCMTotalSetting = topPriorityIsSCMTotalSetting;
        }

        #endregion // </Constructor>

        #region <SCM�S�̐ݒ�}�X�^>

        /// <summary>SCM�S�̐ݒ���ŗD�悷��t���O</summary>
        private readonly bool _topPriorityIsSCMTotalSetting;
        /// <summary>SCM�S�̐ݒ���ŗD�悷��t���O���擾���܂��B</summary>
        protected bool TopPriorityIsSCMTotalSetting { get { return _topPriorityIsSCMTotalSetting; } }

        /// <summary>
        /// SCM�S�̐ݒ�}�X�^���擾���܂��B
        /// </summary>
        protected static SCMTotalSettingAgent SCMTotalSettingDB
        {
            get { return SCMTotalSettingServer.Singleton.Instance; }
        }

        #endregion // <SCM�S�̐ݒ�}�X�^>

        #region <042.���㕔�i���v(�ō���)>

        /// <summary>
        /// ���㕔�i���v(�ō���)���擾���܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <returns>���㕔�i���v(�ō���) + ���i�l���Ώۊz���v(�ō���)</returns>
        public static long GetSalesPrtTotalTaxInc(SalesSlip salesSlip)
        {
            return salesSlip.SalesPrtSubttlInc + salesSlip.ItdedPartsDisInTax;
        }

        #endregion // </042.���㕔�i���v(�ō���)>

        #region <043.���㕔�i���v(�Ŕ���)>

        /// <summary>
        /// ���㕔�i���v(�Ŕ���)���擾���܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <returns>���㕔�i���v(�Ŕ���) + ���i�l���Ώۊz���v(�Ŕ���)</returns>
        public static long GetSalesPrtTotalTaxExc(SalesSlip salesSlip)
        {
            return salesSlip.SalesPrtSubttlExc + salesSlip.ItdedPartsDisOutTax;
        }

        #endregion // </043.���㕔�i���v(�Ŕ���)>

        #region <044.�����ƍ��v(�ō���)>

        /// <summary>
        /// �����ƍ��v(�ō���)���擾���܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <returns>�����Ə��v(�ō���) + ��ƒl���Ώۊz���v(�ō���)</returns>
        public static long GetSalesWorkTotalTaxInc(SalesSlip salesSlip)
        {
            return salesSlip.SalesWorkSubttlInc + salesSlip.ItdedWorkDisInTax;
        }

        #endregion // </044.�����ƍ��v(�Ŕ���)>

        #region <045.�����ƍ��v(�Ŕ���)>

        /// <summary>
        /// �����ƍ��v(�Ŕ���)���擾���܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <returns>�����Ə��v(�Ŕ���) + ��ƒl���Ώۊz���v(�Ŕ���)</returns>
        public static long GetSalesWorkTotalTaxExc(SalesSlip salesSlip)
        {
            return salesSlip.SalesWorkSubttlExc + salesSlip.ItdedWorkDisOutTax;
        }

        #endregion // </044.�����ƍ��v(�Ŕ���)>

        #region <046.���㏬�v(�ō���)>

        /// <summary>
        /// ���㏬�v(�ō���)���擾���܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <returns>
        /// �l������̖��׋��z�̍��v(��ېŊ܂܂�)
        /// ������`�[���v(�ō���) - ���㏬�v��ېőΏۊz + ����l����ېőΏۊz���v
        ///</returns>
        public static long GetSalesSubtotalTaxInc(SalesSlip salesSlip)
        {
            return salesSlip.SalesTotalTaxInc - salesSlip.SalSubttlSubToTaxFre + salesSlip.ItdedSalesDisTaxFre;
        }

        #endregion // </046.���㏬�v(�ō���)>

        #region <047.���㏬�v(�Ŕ���)>

        /// <summary>
        /// ���㏬�v(�Ŕ���)���擾���܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <returns>
        /// �l������̖��׋��z�̍��v(��ېŊ܂܂�)
        /// ������`�[���v(�Ŕ���) - ���㏬�v��ېőΏۊz + ����l����ېőΏۊz���v
        ///</returns>
        public static long GetSalesSubtotalTaxExc(SalesSlip salesSlip)
        {
            return salesSlip.SalesTotalTaxExc - salesSlip.SalSubttlSubToTaxFre + salesSlip.ItdedSalesDisTaxFre;
        }

        #endregion // </047.���㏬�v(�Ŕ���)>

        #region <052.���㐳�����z>

        /// <summary>
        /// ���㐳�����z���擾���܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <returns>����`�[���v(�Ŕ���) - ����l�����z�v(�Ŕ���)</returns>
        public static long GetSalesNetPrice(SalesSlip salesSlip)
        {
            return salesSlip.SalesTotalTaxExc - salesSlip.SalesDisTtlTaxExc;
        }

        #endregion // </052.���㐳�����z>

        #region <069.���i�l����>

        /// <summary>
        /// ���i�l�������擾���܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <returns>
        /// ���v�ɑ΂��Ă̕��i�l����
        /// �����i�l���Ώۊz���v(�ō���) / ���㕔�i���v(�ō���)
        ///</returns>
        public static double GetPartsDiscountRate(SalesSlip salesSlip)
        {
            if (salesSlip.ItdedPartsDisInTax.Equals(0)) return 0;

            return salesSlip.SalesPrtSubttlInc / salesSlip.ItdedPartsDisInTax;
        }

        #endregion // </069.���i�l����>

        #region <079.���������c��>

        /// <summary>
        /// ���������c�����擾���܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <returns>
        /// ����`�[���v(�ō�) ����œ]�ŕ������u�����]�ŁA��ېŁv�̏ꍇ�͐Ŕ����z
        ///</returns>
        public static long GetConsTaxLayMethod(SalesSlip salesSlip)
        {
            if (salesSlip.ConsTaxLayMethod.Equals((int)ConsTaxLayMethod.Slip)
                    ||
                salesSlip.ConsTaxLayMethod.Equals((int)ConsTaxLayMethod.SlipDetail))
            {
                return salesSlip.SalesTotalTaxInc;
            }
            else
            {
                return salesSlip.SalesTotalTaxExc;
            }
        }

        #endregion // </079.���������c��>

        #region <070.�H���l����>

        /// <summary>
        /// �H���l�������擾���܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <returns>
        /// ���v�ɑ΂��Ă̍H���l����
        /// ����ƒl���Ώۊz���v(�ō���) / �����Ə��v(�ō���)
        ///</returns>
        public static double GetRavorDiscountRate(SalesSlip salesSlip)
        {
            if (salesSlip.ItdedWorkDisInTax.Equals(0)) return 0;

            return salesSlip.SalesWorkSubttlInc / salesSlip.ItdedWorkDisInTax;
        }

        #endregion // </070.�H���l����>

        #region <114.�`�[���s�敪>

        /// <summary>
        /// �`�[���s�敪���擾���܂��B
        /// </summary>
        /// <returns>�`�[���s�敪(0:���Ȃ�/1:����)</returns>
        public abstract int GetSlipPrintDivCd();

        #endregion // </114.�`�[���s�敪>

        #region <115.�`�[���s�ϋ敪>

        /// <summary>
        /// �`�[���s�ϋ敪���擾���܂��B
        /// </summary>
        /// <returns>�`�[���s�ϋ敪(0:�����s/1:���s��)</returns>
        public virtual int GetSlipPrintFinishCd()
        {
            return GetSlipPrintDivCd(); // HACK:�`�[���s�敪�Ɠ����ł悢�H
        }

        #endregion // </115.�`�[���s�ϋ敪>

        #region <128.�݌ɏ��i���v���z(�Ŕ�)>

        /// <summary>
        /// �݌ɏ��i���v���z(�Ŕ�)���擾���܂��B
        /// </summary>
        /// <param name="salesDetailList">���㖾�׃f�[�^�̃��X�g</param>
        /// <returns>�݌Ɏ��敪��0�̖��׋��z�̏W�v</returns>
        public static long GetStockGoodsTtlTaxExc(IList<SalesDetail> salesDetailList)
        {
            long stockGoodsTtlTaxExc = 0;
            foreach (SalesDetail salesDetail in salesDetailList)
            {
                // ����݌Ɏ�񂹋敪(0:���, 1:�݌�)
                // 2010/07/07 >>>
                //if (salesDetail.SalesOrderDivCd.Equals(0))
                if (salesDetail.SalesOrderDivCd.Equals(1))
                // 2010/07/07 <<<
                {
                    stockGoodsTtlTaxExc += salesDetail.SalesMoneyTaxExc;    // ������z(�Ŕ���)
                }
            }
            return stockGoodsTtlTaxExc;
        }

        #endregion // </128.�݌ɏ��i���v���z>

        #region <129.�������i���v���z(�Ŕ�)>

        /// <summary>
        /// �������i���v���z(�Ŕ�)���擾���܂��B
        /// </summary>
        /// <param name="salesDetailList">���㖾�׃f�[�^�̃��X�g</param>
        /// <returns>���i������0�̖��׋��z�̏W�v</returns>
        public static long GetPureGoodsTtlTaxExc(IList<SalesDetail> salesDetailList)
        {
            long pureGoodsTtlTaxExc = 0;
            foreach (SalesDetail salesDetail in salesDetailList)
            {
                // ���i����(0:����, 1:�D��)
                if (salesDetail.GoodsKindCode.Equals(0))
                {
                    pureGoodsTtlTaxExc += salesDetail.SalesMoneyTaxExc; // ������z(�Ŕ���)
                }
            }
            return pureGoodsTtlTaxExc;
        }

        #endregion // </129.�������i���v���z(�Ŕ�)>
    }
}
