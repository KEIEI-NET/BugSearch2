using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ShipmentPartsDspParamWork
    /// <summary>
    ///                      �o�ו��i�Ɖ�o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �o�ו��i�Ɖ�o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ShipmentPartsDspParamWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�J�n�v��N��</summary>
        private Int32 _stAddUpYearMonth;

        /// <summary>�I���v��N��</summary>
        private Int32 _edAddUpYearMonth;


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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  StAddUpYearMonth
        /// <summary>�J�n�v��N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StAddUpYearMonth
        {
            get { return _stAddUpYearMonth; }
            set { _stAddUpYearMonth = value; }
        }

        /// public propaty name  :  EdAddUpYearMonth
        /// <summary>�I���v��N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdAddUpYearMonth
        {
            get { return _edAddUpYearMonth; }
            set { _edAddUpYearMonth = value; }
        }


        /// <summary>
        /// �o�ו��i�Ɖ�o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ShipmentPartsDspParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ShipmentPartsDspParamWork()
        {
        }

	}
}
