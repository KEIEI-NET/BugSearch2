//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�Ǘ��}�X�^�K�C�h�����������N���X
// �v���O�����T�v   : ���q�Ǘ��}�X�^�K�C�h���o�͂���
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/09/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���q�Ǘ��}�X�^�K�C�h�����������N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����q�Ǘ��}�X�^�K�C�h����������񏉊����y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009/09/07</br>
    /// </remarks>
    public class CarMngGuideParamInfo
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ�`�F�b�N���ǂ���</summary>
        private bool _isCheckCustomerCode;

        /// <summary>���q�Ǘ��R�[�h</summary>
        /// <remarks>��PM7�ł̎ԗ��Ǘ��ԍ�</remarks>
        private string _carMngCode = "";

        /// <summary>���q�Ǘ��R�[�h�`�F�b�N���ǂ���</summary>
        private bool _isCheckCarMngCode;

        /// <summary>���q�Ǘ��R�[�h�`�F�b�N����</summary>
        /// <remarks>0:���S��v�A1:�O����v�A2:�����v�A3:�܂�</remarks>
        private Int32 _checkCarMngCodeType;

        /// <summary>���q�Ǘ��R�[�h�`�F�b�N���ǂ���</summary>
        private bool _isCheckCarMngDivCd;

        /// <summary>���Ӑ���\���t���O</summary>
        private bool _isDispCustomerInfo;

        /// <summary>�V�K�o�^�s�\���t���O</summary>
        private bool _isDispNewRow;

        /// <summary>�K�C�h�N���b�N�t���O</summary>
        private bool _isGuideClick;

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  IsCheckCustomerCode
        /// <summary>���Ӑ�R�[�h�`�F�b�N���ǂ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�`�F�b�N���ǂ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool IsCheckCustomerCode
        {
            get { return _isCheckCustomerCode; }
            set { _isCheckCustomerCode = value; }
        }

        /// public propaty name  :  CarMngCode
        /// <summary>���q�Ǘ��R�[�h�v���p�e�B</summary>
        /// <value>��PM7�ł̎ԗ��Ǘ��ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q�Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  IsCheckCarMngCode
        /// <summary>���q�Ǘ��R�[�h�`�F�b�N���ǂ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q�Ǘ��R�[�h�`�F�b�N���ǂ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool IsCheckCarMngCode
        {
            get { return _isCheckCarMngCode; }
            set { _isCheckCarMngCode = value; }
        }

        /// public propaty name  :  CheckCarMngCodeType
        /// <summary>���q�Ǘ��R�[�h�`�F�b�N�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q�Ǘ��R�[�h�`�F�b�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CheckCarMngCodeType
        {
            get { return _checkCarMngCodeType; }
            set { _checkCarMngCodeType = value; }
        }

        /// public propaty name  :  IsCheckCarMngCode
        /// <summary>���q�Ǘ��敪�`�F�b�N���ǂ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q�Ǘ��敪�`�F�b�N���ǂ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool IsCheckCarMngDivCd
        {
            get { return _isCheckCarMngDivCd; }
            set { _isCheckCarMngDivCd = value; }
        }

        /// public propaty name  :  IsDispCustomerInfo
        /// <summary>���Ӑ�\���t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�\���t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool IsDispCustomerInfo
        {
            get { return _isDispCustomerInfo; }
            set { _isDispCustomerInfo = value; }
        }

        /// public propaty name  :  IsDispNewRow
        /// <summary>�V�K�o�^�s�\���t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�K�o�^�s�\���t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool IsDispNewRow
        {
            get { return _isDispNewRow; }
            set { _isDispNewRow = value; }
        }

        /// public propaty name  :  IsGuideClick
        /// <summary>�K�C�h�N���b�N�t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�C�h�N���b�N�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool IsGuideClick
        {
            get { return _isGuideClick; }
            set { _isGuideClick = value; }
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public CarMngGuideParamInfo()
        {

        }
    }
}
