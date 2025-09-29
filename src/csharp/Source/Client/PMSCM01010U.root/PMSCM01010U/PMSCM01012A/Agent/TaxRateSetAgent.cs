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
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/10/25  �C�����e : 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/01/30  �C�����e : Redmine#41771 ��Q��13�Ή�
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// �ŗ��ݒ�}�X�^�̃A�N�Z�X�N���X�̑㗝�l�N���X
    /// </summary>
    public sealed class TaxRateSetAgent
    {
        #region <�ŗ��ݒ���/>

        /// <summary>�ŗ��ݒ���</summary>
        private readonly TaxRateSet _taxRateSetInfo;
        /// <summary>
        /// �ŗ��ݒ�����擾���܂��B
        /// </summary>
        /// <value>�ŗ��ݒ���</value>
        private TaxRateSet TaxRateSetInfo { get { return _taxRateSetInfo; } }
        //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private static TaxRateSet taxRateSet = null;
        //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/01/30 Redmine#41771-��Q��13�Ή� ---------------------------------->>>>>
        /// <summary>�ŗ�������t</summary>
        private DateTime _taxRateDate;
        /// <summary>
        /// �ŗ�������t
        /// </summary>
        public DateTime TaxRateDate
        {
            get { return _taxRateDate; }
            set { _taxRateDate = value; }
        }

        /// <summary>�L�����Z���敪</summary>
        private short _cancelDiv;
        /// <summary>
        ///  �L�����Z���敪
        /// </summary>
        public short CancelDiv
        {
            get { return _cancelDiv; }
            set { _cancelDiv = value; }
        }
        // ADD 2014/01/30 Redmine#41771-��Q��13�Ή� ----------------------------------<<<<<

        #endregion  // <�ŗ��ݒ���/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        public TaxRateSetAgent(string enterpriseCode)
        {
            _taxRateSetInfo = GetTaxRateSet(enterpriseCode);
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
                //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //TaxRateSet taxRateSet = null;
                if (taxRateSet == null)
                {
                //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    int status = taxRateSetAcs.Read(out taxRateSet, enterpriseCode, 0);
                //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                }
                //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

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

        // ADD 2014/01/30 Redmine#41771-��Q��13�Ή� ---------------------------------------->>>>>
        /// <summary>
        /// �`�[���t�ɂ��ŗ����擾���܂��B
        /// </summary>
        /// <value>���̐ŗ�</value>
        public double TaxRateOfSlesDate
        {
            get
            {
                // �`�[���t���ݒ莞�͐ŗ��[����ݒ�
                if (_taxRateDate == DateTime.MinValue) return 0;

                return GetTaxRate(TaxRateSetInfo, _taxRateDate);
            }
        }
        // ADD 2014/01/30 Redmine#41771-��Q��13�Ή� ----------------------------------------<<<<<

        // ADD 2013/10/25 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή� -------------------------------->>>>> 
        /// <summary>
        /// ����œ]�ŕ������擾���܂��B
        /// </summary>
        /// <value>���̐ŗ�</value>
        public int ConsTaxLayMethod
        {
            get
            {
                return TaxRateSetInfo.ConsTaxLayMethod;
            }
        }
        // ADD 2013/10/25 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή� --------------------------------<<<<< 

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
}
