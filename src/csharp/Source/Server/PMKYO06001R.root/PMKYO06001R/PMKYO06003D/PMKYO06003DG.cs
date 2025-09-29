using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustomerProcParamWork
    /// <summary>
    ///                      ���Ӑ�}�X�^���o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�}�X�^���o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APCustomerProcParamWork
    {
        /// <summary>�J�n����</summary>
        private Int64 _beginningDate;

        /// <summary>�I������</summary>
        private Int64 _endingDate;

        /// <summary>���Ӑ�(�J�n)</summary>
        private Int32 _customerCodeBegin;

        /// <summary>���Ӑ�(�I��)</summary>
        private Int32 _customerCodeEnd;

        /// <summary>�J�i(�J�n)</summary>
        private string _kanaBegin = "";

        /// <summary>�J�i(�I��)</summary>
        private string _kanaEnd = "";

        /// <summary>�c�Ə�(�J�n)</summary>
        private string _mngSectionCodeBegin = "";

        /// <summary>�c�Ə�(�I��)</summary>
        private string _mngSectionCodeEnd = "";

        /// <summary>�S����(�J�n)</summary>
        private string _customerAgentCdBegin = "";

        /// <summary>�S����(�I��)</summary>
        private string _customerAgentCdEnd = "";

        /// <summary>�n��(�J�n)</summary>
        private Int32 _salesAreaCodeBegin;

        /// <summary>�n��(�I��)</summary>
        private Int32 _salesAreaCodeEnd;

        /// <summary>�Ǝ�(�J�n)</summary>
        private Int32 _businessTypeCodeBegin;

        /// <summary>�Ǝ�(�I��)</summary>
        private Int32 _businessTypeCodeEnd;


        /// public propaty name  :  BeginningDate
        /// <summary>�J�n�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 UpdateDateTimeBegin
        {
            get { return _beginningDate; }
            set { _beginningDate = value; }
        }

        /// public propaty name  :  EndingDate
        /// <summary>�I�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 UpdateDateTimeEnd
        {
            get { return _endingDate; }
            set { _endingDate = value; }
        }

        /// public propaty name  :  CustomerCodeBegin
        /// <summary>���Ӑ�(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeBeginRF
        {
            get { return _customerCodeBegin; }
            set { _customerCodeBegin = value; }
        }

        /// public propaty name  :  CustomerCodeEnd
        /// <summary>���Ӑ�(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeEndRF
        {
            get { return _customerCodeEnd; }
            set { _customerCodeEnd = value; }
        }

        /// public propaty name  :  KanaBegin
        /// <summary>�J�i(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�i(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string KanaBeginRF
        {
            get { return _kanaBegin; }
            set { _kanaBegin = value; }
        }

        /// public propaty name  :  KanaEnd
        /// <summary>�J�i(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�i(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string KanaEndRF
        {
            get { return _kanaEnd; }
            set { _kanaEnd = value; }
        }

        /// public propaty name  :  MngSectionCodeBegin
        /// <summary>�c�Ə�(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c�Ə�(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionCodeBeginRF
        {
            get { return _mngSectionCodeBegin; }
            set { _mngSectionCodeBegin = value; }
        }

        /// public propaty name  :  MngSectionCodeEnd
        /// <summary>�c�Ə�(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c�Ə�(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionCodeEndRF
        {
            get { return _mngSectionCodeEnd; }
            set { _mngSectionCodeEnd = value; }
        }

        /// public propaty name  :  CustomerAgentCdBegin
        /// <summary>�S����(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S����(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgentCdBeginRF
        {
            get { return _customerAgentCdBegin; }
            set { _customerAgentCdBegin = value; }
        }

        /// public propaty name  :  CustomerAgentCdEnd
        /// <summary>�S����(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S����(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgentCdEndRF
        {
            get { return _customerAgentCdEnd; }
            set { _customerAgentCdEnd = value; }
        }

        /// public propaty name  :  SalesAreaCodeBegin
        /// <summary>�n��(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n��(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCodeBeginRF
        {
            get { return _salesAreaCodeBegin; }
            set { _salesAreaCodeBegin = value; }
        }

        /// public propaty name  :  SalesAreaCodeEnd
        /// <summary>�n��(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n��(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCodeEndRF
        {
            get { return _salesAreaCodeEnd; }
            set { _salesAreaCodeEnd = value; }
        }

        /// public propaty name  :  BusinessTypeCodeBegin
        /// <summary>�Ǝ�(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCodeBeginRF
        {
            get { return _businessTypeCodeBegin; }
            set { _businessTypeCodeBegin = value; }
        }

        /// public propaty name  :  BusinessTypeCodeEnd
        /// <summary>�Ǝ�(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCodeEndRF
        {
            get { return _businessTypeCodeEnd; }
            set { _businessTypeCodeEnd = value; }
        }


        /// <summary>
        /// ���Ӑ�}�X�^���o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustomerProcParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerProcParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public APCustomerProcParamWork()
        {
        }

    }
}
