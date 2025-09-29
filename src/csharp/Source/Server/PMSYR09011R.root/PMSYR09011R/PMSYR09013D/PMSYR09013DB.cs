using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CarMngGuideParamWork
    /// <summary>
    ///                      �ԗ��Ǘ��K�C�h�p���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ԗ��Ǘ����[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/09/14  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CarMngGuideParamWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ�`�F�b�N���ǂ���</summary>
        private bool _isCheckCustomerCode;

        /// <summary>���q�Ǘ��R�[�h</summary>
        /// <remarks>��PM7�ł̎ԗ��Ǘ��ԍ�</remarks>
        private string _carMngCode = "";

        /// <summary>�^��</summary>
        private string _kindModel = "";

        /// <summary>�^���`�F�b�N����</summary>
        private Int32 _kindModelType;

        /// <summary>���q���l</summary>
        private string _carNote = "";

        /// <summary>���q���l�`�F�b�N����</summary>
        private Int32 _checkCarNoteType;

        /// <summary>���q�Ǘ��R�[�h�`�F�b�N���ǂ���</summary>
        private bool _isCheckCarMngCode;

        /// <summary>���q�Ǘ��R�[�h�`�F�b�N����</summary>
        private Int32 _checkCarMngCodeType;

        /// <summary>���q�Ǘ��R�[�h�`�F�b�N���ǂ���</summary>
        private bool _isCheckCarMngDivCd;

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

        /// public propaty name  :  KindModel
        /// <summary>�^���v���p�e�B</summary>
        /// <value>��PM7�ł̌^��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string KindModel
        {
            get { return _kindModel; }
            set { _kindModel = value; }
        }

        /// public propaty name  :  CarNote
        /// <summary>���q���l�v���p�e�B</summary>
        /// <value>��PM7�ł̎��q���l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarNote
        {
            get { return _carNote; }
            set { _carNote = value; }
        }

        /// public propaty name  :  CheckCarNoteType
        /// <summary>���q���l�`�F�b�N�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q���l�`�F�b�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CheckCarNoteType
        {
            get { return _checkCarNoteType; }
            set { _checkCarNoteType = value; }
        }

        /// public propaty name  :  CheckCarNoteType
        /// <summary>�^���`�F�b�N�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���`�F�b�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 KindModelType
        {
            get { return _kindModelType; }
            set { _kindModelType = value; }
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

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public CarMngGuideParamWork()
        {
        }
    }
}
