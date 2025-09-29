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
// �� �� ��  2009/07/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11870080-00 �쐬�S�� : ���O
// �� �� ��  2022/05/26  �C�����e : PMKOBETSU-4208 �d�q����Ή�
//----------------------------------------------------------------------------//
using System;
using System.Threading;

using Broadleaf.Application.Controller.Other;
using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �`�[��������N���X
    /// </summary>
    public sealed class SCMSalesDataPrinter
    {
        #region <���`�����[�g�̏����݌���>

        /// <summary>���`�����[�g�̏����݌���</summary>
        private SalesSlipWriterParameter _writedSalesSlipParameter;
        /// <summary>���`�����[�g�̏����݌��ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        public SalesSlipWriterParameter WritedSalesSlipParameter
        {
            get { return _writedSalesSlipParameter; }
            set { _writedSalesSlipParameter = value; }
        }

        #endregion // </���`�����[�g�̏����݌���>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SCMSalesDataPrinter() { }

        #endregion // </Constructor>

        /// <summary>
        /// ������܂��B
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.SaveDBData() 2315�s�ڂ��ڐA
        /// </remarks>
        public void Print()
        {
            if (WritedSalesSlipParameter == null) return;

            SlipPrinter slipPrinter = new SlipPrinter(WritedSalesSlipParameter.ParaList);
            //------------------------------------------------------
            // �`�[�������
            //------------------------------------------------------
        #if DEBUG
            slipPrinter.PrintSlipThread();
            return;
        #else
            Thread printSlipThread = new Thread(slipPrinter.PrintSlipThread);
            printSlipThread.Start();
            // --- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�--->>>>>
            //�d��.DX�I�v�V�����L���̏ꍇ�̂�(����X���b�h�������s)
            if (slipPrinter.Opt_PM_EBooks == (int)SlipPrinter.Option.ON) printSlipThread.Join();
            // --- UPD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�---<<<<<
        #endif
        }
    }
}
