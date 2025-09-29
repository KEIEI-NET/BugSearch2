//**********************************************************************
// �V�X�e��         :   PM.NS
// �v���O��������   :   �d�������}�X�^�ꗗ�\��� ��������N���X
// �v���O�����T�v   : �@
//----------------------------------------------------------------------
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�             �쐬�S�� : FSI�����@�v
// �� �� ��  2012/09/07 �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    # region [�d���摍���}�X�^�ꗗ�\����@��������N���X]
    /// <summary>
    /// �d���摍���}�X�^�ꗗ�\����@��������N���X
    /// </summary>
    public class SumSuppStPrintUIParaWork
    {
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>�������_�R�[�h_�J�n</summary>
        private string _sumSectionCodeSt;
        /// <summary>�������_�R�[�h_�I��</summary>
        private string _sumSectionCodeEd;
        /// <summary>�����d����R�[�h_�J�n</summary>
        private Int32 _sumSupplierCdSt;
        /// <summary>�����d����R�[�h_�I��</summary>
        private Int32 _sumSupplierCdEd;
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// �������_�R�[�h_�J�n
        /// </summary>
        public string SumSectionCodeSt
        {
            get { return _sumSectionCodeSt; }
            set { _sumSectionCodeSt = value; }
        }
        /// <summary>
        /// �������_�R�[�h_�I��
        /// </summary>
        public string SumSectionCodeEd
        {
            get { return _sumSectionCodeEd; }
            set { _sumSectionCodeEd = value; }
        }
        /// <summary>
        /// �����d����R�[�h_�J�n
        /// </summary>
        public Int32 SumSupplierCdSt
        {
            get { return _sumSupplierCdSt; }
            set { _sumSupplierCdSt = value; }
        }
        /// <summary>
        /// �����d����R�[�h_�I��
        /// </summary>
        public Int32 SumSupplierCdEd
        {
            get { return _sumSupplierCdEd; }
            set { _sumSupplierCdEd = value; }
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sumSectionCodeSt">�������_�R�[�h_�J�n</param>
        /// <param name="sumSectionCodeEd">�������_�R�[�h_�I��</param>
        /// <param name="sumSupplierCdSt">�����d����R�[�h_�J�n</param>
        /// <param name="sumSupplierCdEd">�����d����R�[�h_�I��</param>
        public SumSuppStPrintUIParaWork(string enterpriseCode, string sumSectionCodeSt, string sumSectionCodeEd, Int32 sumSupplierCdSt, Int32 sumSupplierCdEd)
        {
            _enterpriseCode = enterpriseCode;
            _sumSectionCodeSt = sumSectionCodeSt;
            _sumSectionCodeEd = sumSectionCodeEd;
            _sumSupplierCdSt = sumSupplierCdSt;
            _sumSupplierCdEd = sumSupplierCdEd;
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SumSuppStPrintUIParaWork()
        {
        }

    }
    # endregion
}
