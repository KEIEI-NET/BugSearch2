using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RateProcParamWork
    /// <summary>
    ///                      �]�ƈ��ݒ�}�X�^���o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �]�ƈ��ݒ�}�X�^���o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2012/07/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EmployeeProcParamWork
    {
        /// <summary>�J�n����</summary>
        private Int64 _beginningDate;

        /// <summary>�I������</summary>
        private Int64 _endingDate;

        /// <summary>�������_(�J�n)</summary>
        private string _belongSectionCdBegin = "";

        /// <summary>�������_(�I��)</summary>
        private string _belongSectionCdEnd = "";

        /// <summary>�]�ƈ�(�J�n)</summary>
        private string _employeeCdBegin = "";

        /// <summary>�]�ƈ�(�I��)</summary>
        private string _employeeCdEnd = "";


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

        /// public propaty name  :  BelongSectionCdBegin
        /// <summary>�������_(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������_(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BelongSectionCdBeginRF
        {
            get { return _belongSectionCdBegin; }
            set { _belongSectionCdBegin = value; }
        }

        /// public propaty name  :  BelongSectionCdEnd
        /// <summary>�������_(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������_(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BelongSectionCdEndRF
        {
            get { return _belongSectionCdEnd; }
            set { _belongSectionCdEnd = value; }
        }

        /// public propaty name  :  EmployeeCdBegin
        /// <summary>�]�ƈ�(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ�(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCdBeginRF
        {
            get { return _employeeCdBegin; }
            set { _employeeCdBegin = value; }
        }

        /// public propaty name  :  EmployeeCdEnd
        /// <summary>�]�ƈ�(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ�(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCdEndRF
        {
            get { return _employeeCdEnd; }
            set { _employeeCdEnd = value; }
        }


        /// <summary>
        /// �]�ƈ��ݒ�}�X�^���o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>EmployeeProcParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeProcParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EmployeeProcParamWork()
        {
        }

    }
}

