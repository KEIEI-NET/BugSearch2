using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockDayTotalExtractWork
    /// <summary>
    ///                      �d�����v�݌v�\���o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d�����v�݌v�\���o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/09/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockDayTotalExtractWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�S�БI��</summary>
        /// <remarks>true:�S�БI���@false:�e���_�I��</remarks>
        private Boolean _isSelectAllSection;

        /// <summary>�S���_���R�[�h�o��</summary>
        /// <remarks>true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�</remarks>
        private Boolean _isOutputAllSecRec;

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�����^�@���z�񍀖�</remarks>
        private string[] _sectionCd;

        /// <summary>�d����(�J�n)</summary>
        /// <remarks>YYYYMMDD �����͎��� 0</remarks>
        private Int32 _stockDateSt;

        /// <summary>�d����(�I��)</summary>
        /// <remarks>YYYYMMDD �����͎��� 0</remarks>
        private Int32 _stockDateEd;

        /// <summary>�d���S���҃R�[�h(�J�n)</summary>
        /// <remarks>�����͎��͋󕶎�("")</remarks>
        private string _stockAgentCodeSt = "";

        /// <summary>�d���S���҃R�[�h(�I��)</summary>
        /// <remarks>�����͎��͋󕶎�("")</remarks>
        private string _stockAgentCodeEd = "";


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

        /// public propaty name  :  IsSelectAllSection
        /// <summary>�S�БI���v���p�e�B</summary>
        /// <value>true:�S�БI���@false:�e���_�I��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S�БI���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean IsSelectAllSection
        {
            get { return _isSelectAllSection; }
            set { _isSelectAllSection = value; }
        }

        /// public propaty name  :  IsOutputAllSecRec
        /// <summary>�S���_���R�[�h�o�̓v���p�e�B</summary>
        /// <value>true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���_���R�[�h�o�̓v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean IsOutputAllSecRec
        {
            get { return _isOutputAllSecRec; }
            set { _isOutputAllSecRec = value; }
        }

        /// public propaty name  :  SectionCd
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�����^�@���z�񍀖�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCd
        {
            get { return _sectionCd; }
            set { _sectionCd = value; }
        }

        /// public propaty name  :  StockDateSt
        /// <summary>�d����(�J�n)�v���p�e�B</summary>
        /// <value>YYYYMMDD �����͎��� 0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDateSt
        {
            get { return _stockDateSt; }
            set { _stockDateSt = value; }
        }

        /// public propaty name  :  StockDateEd
        /// <summary>�d����(�I��)�v���p�e�B</summary>
        /// <value>YYYYMMDD �����͎��� 0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDateEd
        {
            get { return _stockDateEd; }
            set { _stockDateEd = value; }
        }

        /// public propaty name  :  StockAgentCodeSt
        /// <summary>�d���S���҃R�[�h(�J�n)�v���p�e�B</summary>
        /// <value>�����͎��͋󕶎�("")</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���҃R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentCodeSt
        {
            get { return _stockAgentCodeSt; }
            set { _stockAgentCodeSt = value; }
        }

        /// public propaty name  :  StockAgentCodeEd
        /// <summary>�d���S���҃R�[�h(�I��)�v���p�e�B</summary>
        /// <value>�����͎��͋󕶎�("")</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���҃R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentCodeEd
        {
            get { return _stockAgentCodeEd; }
            set { _stockAgentCodeEd = value; }
        }

        /// <summary>
        /// �d�����v�݌v�\���o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockDayTotalExtractWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockDayTotalExtractWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockDayTotalExtractWork()
        {
        }
    }
}
