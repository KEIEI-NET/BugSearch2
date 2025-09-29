using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   EnterSchOrderCndtnWork
    /// <summary>
    ///                      ���ɗ\��\���o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���ɗ\��\���o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EnterSchOrderCndtnWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h�i�����w��j</summary>
        private string[] _sectionCodes;

        /// <summary>�J�nUOE������R�[�h</summary>
        private Int32 _st_UOESupplierCd;

        /// <summary>�I��UOE������R�[�h</summary>
        private Int32 _ed_UOESupplierCd;

        /// <summary>������R�[�h�w��(�����w��)</summary>
        private Int32[] _uOESupplierCds;

        /// <summary>�J�n��M���t</summary>
        private DateTime _st_ReceiveDate;

        /// <summary>�I����M���t</summary>
        private DateTime _ed_ReceiveDate;

        /// <summary>����^�C�v</summary>
        /// <remarks>0:���ɕ��̂� 1:���[�J�[�t�H���[���̂݁@2:���i���̂�</remarks>
        private Int32 _printTypeCndtn;


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

        /// public propaty name  :  SectionCodes
        /// <summary>���_�R�[�h�i�����w��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�i�����w��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  St_UOESupplierCd
        /// <summary>�J�nUOE������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nUOE������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_UOESupplierCd
        {
            get { return _st_UOESupplierCd; }
            set { _st_UOESupplierCd = value; }
        }

        /// public propaty name  :  Ed_UOESupplierCd
        /// <summary>�I��UOE������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��UOE������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_UOESupplierCd
        {
            get { return _ed_UOESupplierCd; }
            set { _ed_UOESupplierCd = value; }
        }

        /// public propaty name  :  UOESupplierCds
        /// <summary>������R�[�h�w��(�����w��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�w��(�����w��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] UOESupplierCds
        {
            get { return _uOESupplierCds; }
            set { _uOESupplierCds = value; }
        }

        /// public propaty name  :  St_ReceiveDate
        /// <summary>�J�n��M���t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n��M���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_ReceiveDate
        {
            get { return _st_ReceiveDate; }
            set { _st_ReceiveDate = value; }
        }

        /// public propaty name  :  Ed_ReceiveDate
        /// <summary>�I����M���t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I����M���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_ReceiveDate
        {
            get { return _ed_ReceiveDate; }
            set { _ed_ReceiveDate = value; }
        }

        /// public propaty name  :  PrintTypeCndtn
        /// <summary>����^�C�v�v���p�e�B</summary>
        /// <value>0:���ɕ��̂� 1:���[�J�[�t�H���[���̂݁@2:���i���̂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintTypeCndtn
        {
            get { return _printTypeCndtn; }
            set { _printTypeCndtn = value; }
        }


        /// <summary>
        /// ���ɗ\��\���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>EnterSchOrderCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EnterSchOrderCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EnterSchOrderCndtnWork()
        {
        }

    }
}




