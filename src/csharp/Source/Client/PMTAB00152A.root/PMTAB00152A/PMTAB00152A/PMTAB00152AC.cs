//****************************************************************************//
// �V�X�e��         : PMTAB �����񓚏���(�f�[�^�o�^)
// �v���O��������   : PMTAB �����񓚏���(�f�[�^�o�^)�A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : qijh
// �� �� ��  2013/06/29  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
    public partial class TabSCMSalesDataMaker
    {
        /// <summary>
        /// �`�[������f�[�^�\����
        /// </summary>
        public struct SlipPrintInfoValue
        {
            int _acptAnOdrStatus;
            string _salesSlipNum;

            //���ʒ��[�i�����[�g�`�[�ȊO�j����p�t���O�i0�F����A1�F������Ȃ��j
            int _nomalSalesSlipPrintFlag;

            /// <summary>
            /// �`�[������f�[�^�\���̃R���X�g���N�^
            /// </summary>
            /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
            /// <param name="salesSlipNum">����`�[�ԍ�</param>
            /// <param name="nomalPrintFlag">����t���O</param>
            internal SlipPrintInfoValue(int acptAnOdrStatus, string salesSlipNum, int nomalPrintFlag)
            {
                this._acptAnOdrStatus = acptAnOdrStatus;
                this._salesSlipNum = salesSlipNum;
                this._nomalSalesSlipPrintFlag = nomalPrintFlag;
            }

            /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
            internal int AcptAnOdrStatus
            {
                get { return this._acptAnOdrStatus; }
                set { this._acptAnOdrStatus = value; }
            }

            /// <summary>�`�[�ԍ��v���p�e�B</summary>
            internal string SalesSlipNum
            {
                get { return this._salesSlipNum; }
                set { this._salesSlipNum = value; }
            }

            /// <summary>���ʒ��[�i�����[�g�`�[�ȊO�j����p�t���O�v���p�e�B</summary>
            internal int NomalSalesSlipPrintFlag
            {
                get { return this._nomalSalesSlipPrintFlag; }
                set { this._nomalSalesSlipPrintFlag = value; }
            }
        }

        // --------------- ADD END 2013/07/02 wangl2 FOR Redmine#37585-------->>>>
        /// <summary>
        /// ���z�\�����@�敪
        /// </summary>
        public enum TotalAmountDispWayCd : int
        {
            /// <summary>���z�\�����Ȃ�</summary>
            NoTotalAmount = 0,
            /// <summary>���z�\������</summary>
            TotalAmount = 1,
        }

        /// <summary>
        /// �󒍃X�e�[�^�X
        /// </summary>
        public enum AcptAnOdrStatusState : int
        {
            /// <summary>����</summary>
            Estimate = 10,
            /// <summary>�P������</summary>
            UnitPriceEstimate = 15,
            /// <summary>��������</summary>
            SearchEstimate = 16,
            /// <summary>��</summary>
            AcceptAnOrder = 20,
            /// <summary>����</summary>
            Sales = 30,
            /// <summary>�ݏo</summary>
            Shipment = 40,
        }

        /// <summary>
        /// ���|�敪
        /// </summary>
        public enum AccRecDivCd : int
        {
            /// <summary>���|�Ȃ�</summary>
            NonAccRec = 0,
            /// <summary>���|</summary>
            AccRec = 1,
        }

        /// <summary>
        /// ���i�敪
        /// </summary>
        public enum SalesGoodsCd : int
        {
            /// <summary>���i</summary>
            Goods = 0,
            /// <summary>���i�O</summary>
            NonGoods = 1,
            /// <summary>����Œ���</summary>
            ConsTaxAdjust = 2,
            /// <summary>�c������</summary>
            BalanceAdjust = 3,
            /// <summary>���|�p����Œ���</summary>
            AccRecConsTaxAdjust = 4,
            /// <summary>���|�p�c������</summary>
            AccRecBalanceAdjust = 5,
        }

        /// <summary>
        /// ���������敪
        /// </summary>
        public enum AutoDepositCd : int
        {
            /// <summary>�o�^���Ȃ�</summary>
            None = 0,
            /// <summary>�o�^����</summary>
            Write = 1,
        }
        // --------------- ADD END 2013/07/02 wangl2 FOR Redmine#37585--------<<<<
    }
}
